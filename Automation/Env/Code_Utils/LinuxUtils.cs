/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/18/2017
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.IO;
using System.Management;
using System.Threading;
using Env.Code_Utils;

namespace Env.Code_Utils
{
	/// <summary>
	/// Description of LinuxUtils.
	/// </summary>
	public class LinuxUtils
	{
		public LinuxUtils()
		{
		}
		
		public static string corruptBulletin(VMEnvironment vm, string labelName, string bulletinNumber)
		{
			//All scripts are driven via bash. Do not use Mintty as it creates a child process for bash and Ranorex will not wait for it to complete
			Process scriptProcess = new Process();
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(Executor)) {
				Ranorex.Report.Error("Missing "+Executor);
				return scriptOutput;
			}
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\bulletinDataCorruptor.sh")) {
				Ranorex.Report.Error("Missing "+vm.baseCoreDir+@"linux_scripts\bulletinDataCorruptor.sh");
				return scriptOutput;
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();
			
			string userName = vm.user;
			string server = vm.server;
			string PdsScriptArguments = @"-l -e "+vm.baseCoreDir+@"linux_scripts\bulletinDataCorruptor.sh -t "+labelName+" -u "+userName+" -r "+server+" -b "+bulletinNumber;
	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = PdsScriptArguments;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	//Write Text to File
            	System.IO.File.WriteAllText(vm.userTempDirectory+"cacheRefreshLog.txt", scriptOutput);
            	
            	
            	//Wait up to 20 seconds for process to end
            	scriptProcess.WaitForExit(20000);
            	
	      	} catch (Exception) {
            	Ranorex.Report.Error("bulletinNumber Corruptor process failed to execute/complete within 20 seconds");
	      	}
			return scriptOutput;
		}
		
		public static string getCacheRefreshInformation(VMEnvironment vm, string labelName, string district, string division, string messageType)
		{
			//All scripts are driven via bash. Do not use Mintty as it creates a child process for bash and Ranorex will not wait for it to complete
			Process scriptProcess = new Process();
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(Executor)) {
				Ranorex.Report.Error("Missing "+Executor);
				return scriptOutput;
			}
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\cacheRefreshChecker.sh")) {
				Ranorex.Report.Error("Missing "+vm.baseCoreDir+@"linux_scripts\cacheRefreshChecker.sh");
				return scriptOutput;
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();
			
			string userName = vm.user;
			string server = vm.server;
			string PdsScriptArguments = @"-l -e "+vm.baseCoreDir+@"linux_scripts\cacheRefreshChecker.sh -t "+labelName+" -u "+userName+" -r "+server+" -d \""+district+"\" -e "+messageType+" -a";
	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = PdsScriptArguments;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	//Write Text to File
            	System.IO.File.WriteAllText(vm.userTempDirectory+"cacheRefreshLog.txt", scriptOutput);
            	
            	
            	//Wait up to 20 seconds for process to end
            	scriptProcess.WaitForExit(20000);
            	
	      	} catch (Exception) {
            	Ranorex.Report.Error("cacheRefreshChecker process failed to execute/complete within 20 seconds");
	      	}
			return scriptOutput;
		}
		
		public static void RunBatchScript(string script, string scriptArguments = "")
		{
			VMEnvironment vm = VMEnvironment.Instance();
			if (script.Contains(vm.baseCoreDir))
			{
				script.Replace(vm.baseCoreDir, "");
			}

			string outScript = string.Format(@"{0}{1}", vm.baseCoreDir, script);

			runBatchScript(vm: vm, script: outScript, scriptArguments: scriptArguments);
		}
		
		public static void runBatchScript(VMEnvironment vm, string script, string scriptArguments)
		{
			Process scriptProcess = new Process();
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = script;
			string fileName = Path.GetFileName(Executor);
			
			if (!File.Exists(script)) {
				throw new Ranorex.ValidationException("Missing "+script);
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();

	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = scriptArguments;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			scriptStartInfo.WorkingDirectory = Path.GetDirectoryName(script);
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	//Write Text to File
            	System.IO.File.WriteAllText(vm.userTempDirectory+fileName.Substring(0, fileName.Length-4)+"_log.txt", scriptOutput);
            	
            	
            	//Wait up to 20 minutes for process to end
            	scriptProcess.WaitForExit(1200000);
            	
	      	} catch (Exception e) {
            	throw new Ranorex.ValidationException("{0} Exception", e);
	      	}
			
			if (scriptErrors.Contains("ERROR:")) {
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
		}
		
		public static void runStartupScript(VMEnvironment vm, string script, string labelName, string db, string type="Label")
		{
			//All scripts are driven via bash. Do not use Mintty as it creates a child process for bash and Ranorex will not wait for it to complete
			Process scriptProcess = new Process();
			string scriptOutput = "";
			string scriptErrors = "";
			string resetTDMS = "0";
			string previousDB = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(Executor)) {
				throw new Ranorex.ValidationException("Missing "+Executor);
			}
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			Report.Info("labelName: " + labelName);
			Report.Info("db: " + db);
			Report.Info("type: " + type);
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();
			
			if (!File.Exists(vm.userTempDirectory+"launcher_last_db_name.txt")) {
				using (var dbFile = System.IO.File.Create(vm.userTempDirectory+"launcher_last_db_name.txt")) {}
			} else {
				previousDB = System.IO.File.ReadAllText(vm.userTempDirectory+"launcher_last_db_name.txt");
			}
			
			if (labelName.Substring(0,2).Equals("CN"))
			{
			    // CN startup uses resetDbs and upgradeDbs so no need to re-reset them on pds startup
			    resetTDMS = "0";
			}
			else if (!previousDB.Equals(db) || previousDB.Equals("")) 
			{
				resetTDMS = "1";
			}
			
			Report.Info("resetTdms: " + resetTDMS);
			
			string PdsScriptArguments = @"-l -e "+vm.baseCoreDir+@"linux_scripts\"+script+" -u "+vm.user+" -r "+vm.server+" -v "+type+" -t "+labelName+" -s "+vm.ste+" -p "+vm.lastLabel+" -d "+db+" -m "+resetTDMS;
			
			Report.Info("Arguments: " + PdsScriptArguments);
			
	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = PdsScriptArguments;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	//Write Text to File
            	System.IO.File.WriteAllText(vm.userTempDirectory+script.Substring(0, script.Length-3)+"_log.txt", scriptOutput);
            	
            	
            	//Wait up to 40 minutes for process to end
            	scriptProcess.WaitForExit(3600000);
            	
	      	} catch (Exception) {
            	throw new Ranorex.ValidationException(script+" process failed to execute/complete within 20 minutes");
	      	}
			
			if (scriptErrors.Contains("ERROR:")) {
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
			return;
		}
		
		public static void runLinuxScript(string script, int timeoutMs = 1800000) {
			//All scripts are driven via bash. Do not use Mintty as it creates a child process for bash and Ranorex will not wait for it to complete
			Process scriptProcess = new Process();
			string scriptOutput = "";
			string scriptErrors = "";
			if (!File.Exists(script)) {
				throw new Ranorex.ValidationException("Missing "+script);
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();

	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = script;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	
            	//Wait up to timeoutMs milliseconds for process to end
            	scriptProcess.WaitForExit(timeoutMs);
            	
	      	} catch (Exception) {
				throw new Ranorex.ValidationException(script+" process failed to execute/complete within " + timeoutMs.ToString() + " milliseconds");
	      	}
			return;
		}
		
		public static void syncEnvironment(VMEnvironment vm, string labelName)
		{
			//All scripts are driven via bash. Do not use Mintty as it creates a child process for bash and Ranorex will not wait for it to complete
			Process scriptProcess = new Process();
			string script = "syncEnvironment.sh";
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();
			
			
			string PdsScriptArguments = vm.baseCoreDir+@"linux_scripts\"+script+" -u "+vm.user+" -r "+vm.server+" -b "+labelName;
	      	scriptStartInfo.UseShellExecute = false; //don't want a shell to be the parent process
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = PdsScriptArguments;
			scriptStartInfo.RedirectStandardOutput = true;
			scriptStartInfo.RedirectStandardError = true;
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	scriptOutput = scriptProcess.StandardOutput.ReadToEnd();
            	scriptErrors = scriptProcess.StandardError.ReadToEnd();
            	
            	//Write Text to File
            	System.IO.File.WriteAllText(vm.userTempDirectory+script.Substring(0, script.Length-3)+"_log.txt", scriptOutput);
            	
            	
            	//Wait up to 20 minutes for process to end
            	scriptProcess.WaitForExit(1200000);
            	
	      	} catch (Exception) {
            	throw new Ranorex.ValidationException(script+" process failed to execute/complete within 20 minutes");
	      	}
			
			if (scriptErrors.Contains("ERROR:")) {
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
			return;
		}
		
		
		
		
		public static void checkCoreFiles(string label)
		{
		    try {
    			VMEnvironment vm = VMEnvironment.Instance();
    			//Setting environment variable for response directory
                string linuxDir = vm.baseDir+"PDS_CORE/linux_scripts/";
                	
    			//ProcessStartInfo tempInfo = new ProcessStartInfo();
    	    	//tempInfo.WorkingDirectory = linuxDir;
    	        //tempInfo.FileName         = @"set_temp.bat";
                //Process temp              = System.Diagnostics.Process.Start(tempInfo);
    
    			
    			string sh = linuxDir+"runpython.sh";
    			
          	    //launch   
    			ProcessStartInfo processInfo = new ProcessStartInfo();
    	    	processInfo.WorkingDirectory = @"C:\cygwin64\bin";
    	        processInfo.FileName         = @"mintty.exe";
    	        processInfo.Arguments        = "-h /bin/bash -l -e "+sh+" -b "+label+" -u "+vm.user+" -p ~"+vm.user+"/checkcorefiles.py -a \""+vm.user+"\" -r "+vm.server;
                Process checkCore            = System.Diagnostics.Process.Start(processInfo);
                
                Thread.Sleep(15000);
                processResponse();
		    } catch (Exception e)
		    {
		        Ranorex.Report.Info("Info", e.ToString());
		    }
		}
      
      public static void populateEmtMileposts(string label, string tdmsLocation)
		{
      		VMEnvironment vm = VMEnvironment.Instance();
      	
      		Process emtProcess = new Process();
			string script = "updateEmtPoints.sh";
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			
			string scriptArguments					= vm.baseCoreDir + @"linux_scripts\" + script + " -u " + vm.user + " -r " + vm.server + " -t " + label + " -l " + tdmsLocation + " -u " + vm.user;
			
			scriptStartInfo.UseShellExecute			= false;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= true;
			scriptStartInfo.RedirectStandardError	= true;
			
			try 
			{
				emtProcess = Process.Start(scriptStartInfo);
				scriptOutput = emtProcess.StandardOutput.ReadToEnd();
				scriptErrors = emtProcess.StandardError.ReadToEnd();
				
				System.IO.File.WriteAllText(vm.userTempDirectory+script.Substring(0, script.Length-3)+"_log.txt", scriptOutput);
				
				emtProcess.WaitForExit(600000);
			} catch (Exception e) {
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
			if (scriptErrors.Contains("ERROR:")) {
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
		}
      
      private static string formatDtdFileName(string fileName)
	  {
		  if (!fileName.ToLower().Contains(".dtd"))
		  {
			  fileName = fileName + ".dtd";
		  }
		  
		  return fileName;
	  }

	  public static void checkAndRenameDtdFile(string originalFileName, string newFileName)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			// Define DTD config directory:
			string dtdConfigDirectory = "/tms/pdswork/" + vm.user + "/pds-server/PDS/data/config/dtd/";
			string origFile = dtdConfigDirectory + formatDtdFileName(originalFileName);
			string cpFile = dtdConfigDirectory + formatDtdFileName(newFileName);
			
			Process coreCheck = new Process();
			string script = "updateDtdFilename.sh";
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) 
			{
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			
			string scriptArguments					= vm.baseCoreDir + @"linux_scripts\" + script + " -u " + vm.user + " -r " + vm.server + " -o " + origFile + " -n " + cpFile;
			
			scriptStartInfo.UseShellExecute			= false;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= true;
			scriptStartInfo.RedirectStandardError	= true;
			
			
			try 
			{
				coreCheck = Process.Start(scriptStartInfo);
				scriptOutput = coreCheck.StandardOutput.ReadToEnd();
				scriptErrors = coreCheck.StandardError.ReadToEnd();
				
				System.IO.File.WriteAllText(vm.userTempDirectory+script.Substring(0, script.Length-3)+"_log.txt", scriptOutput);
				
				coreCheck.WaitForExit();				
			} catch (Exception e) 
			{
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
			if (scriptErrors.Contains("ERROR:")) {
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
		}

		public static void NS_CheckCoreFiles()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process process = new Process();
			string script = "checkcorefiles.sh";
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			
			string scriptArguments					= vm.baseCoreDir + @"linux_scripts\" + script + " -u " + vm.user + " -r " + vm.server;
			
			scriptStartInfo.UseShellExecute			= false;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= true;
			scriptStartInfo.RedirectStandardError	= true;
			
			
			try 
			{
				process = Process.Start(scriptStartInfo);
				scriptOutput = process.StandardOutput.ReadToEnd();
				scriptErrors = process.StandardError.ReadToEnd();
				
				process.WaitForExit();	

			} 
			catch (Exception e) 
			{
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
			
			// If there are matching core files, then they will come after the server name in the standard output.
			if (scriptOutput.Trim().EndsWith(vm.server))
			{
				Report.Success(string.Format("Validation", "No core files found for user '{0}' on server '{1}'", vm.user, vm.server));
			} else {
				Report.Failure(string.Format("Validation", "Core files found for user '{0}' on server '{1}'. Go to /tms/corefiles for more information.", vm.user, vm.server));
				Report.Info(string.Format("Core file output details: '{0}'", scriptOutput));
			}
		}
	  
	    private static void stopAndCleanPds()
		{
			RunShellCommand("stopPDS -e -u $USER -F");
			RunShellCommand("git-clean -e -u $USER -F");
		}

		private static void buildAndCreatePds()
		{
			VMEnvironment vm = VMEnvironment.Instance();

			string dir = "/tms/pdswork/$USER/pds-server/PDS";
			RunShellCommand(string.Format("cd {0} && mvn-setup", dir));
			RunShellCommand(string.Format("cd {0} && createPDS.sh -e -u $USER -d $USER -F", dir));

			RunShellCommand(string.Format(
				"cd {0} && altSte -s {1} {2} -b", dir, vm.ste, vm.ipAddress
			));
		}

		private static void invokePreparePds(string topology = "GA", string division = "div1", bool enableJBoss = false)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			if (division.Contains("|"))
			{
				string[] arr = division.Split('|');
				division = string.Join(" ", arr);
			}

			if (topology != "GA")
			{
				Report.Warn(string.Format("PDS is not using the 'GA' topology. The user has input the following: {0}", topology));
			}

			string dir = "/tms/pdswork/$USER/pds-server/PDS";
			string scriptName = "/tms/pdsgit/$USER/pds-server/bin/preparePDS";

			string cmd = string.Format(
				"cd {0} && {1} -ste {2} -backflow -playback -noclean -run -d {3} {4}",
				dir, scriptName, vm.ste, topology, division
			);

			if (enableJBoss)
			{
				cmd += string.Format(" {0}", "-startjboss");
			}

			Report.Info(string.Format("The following command is being executed to prepare pds: {0}", cmd));
			RunShellCommand(cmd);

		}

		private static void createUsers()
		{
			string dir = "/tms/pdswork/$USER/pds-server/PDS";
			RunShellCommand(string.Format("cd {0} && popL -e -u $USER -F", dir));
		}

		private static void gitCheckoutPds(string branch, string label)
		{
			string dir = "/tms/pdswork/$USER/pds-server/PDS";
			RunShellCommand(string.Format("cd {0} && git reset --hard", dir));
			RunShellCommand(string.Format("cd {0} && git fetch --all && git pull", dir));
			RunShellCommand(string.Format("cd {0} && git checkout {1} && git pull", dir, branch));

			RunShellCommand(string.Format("cd {0} && git checkout {1}", dir, label));
		}

		public static void PreparePds(string branch, string label, string topology = "GA", string division = "div1", bool enableJBoss = false)
		{
			stopAndCleanPds();
			gitCheckoutPds(branch: branch, label: label);
			buildAndCreatePds();
			invokePreparePds(topology: topology, division: division, enableJBoss: enableJBoss);
		}
		
		public static void PopulateRemedyBulletins()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process remBuliProcess = new Process();
			string script = "populateRemedyBulletins.sh";
			string xmlFileName = "BuliTypesString13RR.xml";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			
			// Ensure that shell script exists
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}

			// Ensure that xml file exists
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+xmlFileName)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+xmlFileName);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			
			string scriptArguments					= vm.baseCoreDir + @"linux_scripts\" + script + " -u " + vm.user + " -r " + vm.server + " -x " + xmlFileName;
			
			scriptStartInfo.UseShellExecute			= true;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= false;
			scriptStartInfo.RedirectStandardError	= false;
			
			
			try 
			{
				remBuliProcess = Process.Start(scriptStartInfo);
				remBuliProcess.WaitForExit();				
			} catch (Exception e) {
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
		}

		/// <summary>
		/// We want to encapsulate the shell commenad in double quotes, and with explicit intent.
		/// </summary>
		/// <param name="shellCmd"></param>
		/// <returns></returns>
		private static string formatShellCmd(string shellCmd)
		{
			// Remove any quotes, if exist
			if (shellCmd.Contains("\""))
			{
				shellCmd = shellCmd.Replace("\"", "");
			}

			// Add double quotes
			return string.Format("\"{0}\"", shellCmd);
		}
		
		public static void RunShellCommand(string shellCmd)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process process = new Process();
			string script = "runShellCmd.sh";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			string cmd = formatShellCmd(shellCmd);
			
			// Ensure that shell script exists
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) {
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();

			Report.Info("TestStep", string.Format("Executing the following server side command: {0}", cmd));
			
			string scriptArguments					= vm.baseCoreDir + @"linux_scripts\" + script + " -u " + vm.user + " -r " + vm.server + " -s " + cmd;
			
			scriptStartInfo.UseShellExecute			= true;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= false;
			scriptStartInfo.RedirectStandardError	= false;
			
			try 
			{
				process = Process.Start(scriptStartInfo);
				
				process.WaitForExit();				
			} catch (Exception e) {
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
		}

		public static void PreparePdsUi()
		{
			scpAndUnzipPdsUiFromServer();
		}

		private static void scpAndUnzipPdsUiFromServer()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process process = new Process();
			
			string script = "scp-and-unzip-pds-ui.sh";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			
			if (!File.Exists(Executor)) 
			{
				throw new Ranorex.ValidationException("Missing "+Executor);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			string wsAppFile						= string.Format(@"'{0}jenkins\bin\WsApp.bat'",vm.baseCoreDir);
			string scriptArguments					= @"-l -e " + "'" + vm.baseCoreDir + @"jenkins\" + script + "'" + " " + vm.user + " " + vm.server + " " + wsAppFile;
			scriptStartInfo.UseShellExecute			= true;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= false;
			scriptStartInfo.RedirectStandardError	= false;

			Report.Info("TestSTep", string.Format("Executing the following command: bash {0}", scriptArguments));
			
			try 
			{
				process = Process.Start(scriptStartInfo);
				process.WaitForExit();	
			} 
			catch (Exception e) 
			{
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}

		}

		public static void CleanAutomationRepository()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process process = new Process();
			string script = "git-cleanup.sh";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			
			if (!File.Exists(Executor)) 
			{
				throw new Ranorex.ValidationException("Missing "+Executor);
			}
			
			// Ensure that shell script exists
			if (!File.Exists(vm.baseCoreDir+@"jenkins\"+script)) 
			{
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"jenkins\"+script);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();

			Report.Info("TestStep", string.Format("Executing the following remote script: {0}", script));
			
			string scriptArguments					= @"-l -e " + "'" + vm.baseCoreDir + @"jenkins\" + script + "'";

			Report.Info(string.Format("Executing the following command: bash {0}", scriptArguments));
			
			scriptStartInfo.UseShellExecute			= false;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= true;
			scriptStartInfo.RedirectStandardError	= true;
			
			try 
			{
				process = Process.Start(scriptStartInfo);

				// Wait for up to 40 minutes for the process to end
				process.WaitForExit(2400000);

				// scriptOutput = process.StandardOutput.ReadToEnd();
				// scriptErrors = process.StandardError.ReadToEnd();		
			} 
			catch (Exception e) 
			{
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
		}
		
		public static void checkQ(string label)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			string linuxDir = vm.baseDir+"PDS_CORE/linux_scripts/";
			string view = vm.user+"_cad_"+label;
			string outpath = "/cygdrive/t/Systems/Automation/Results/PDS_Labels/"+label+"/info";

			//ProcessStartInfo tempInfo = new ProcessStartInfo();
	    	//tempInfo.WorkingDirectory = linuxDir;
	        //tempInfo.FileName         = @"set_temp.bat";
            //Process temp              = System.Diagnostics.Process.Start(tempInfo);

			string sh = linuxDir+"runpython.sh";
			
      	    //launch   
			ProcessStartInfo processInfo = new ProcessStartInfo();
	    	processInfo.WorkingDirectory = @"C:\cygwin64\bin";
	        processInfo.FileName         = @"mintty.exe";
	        processInfo.Arguments        = "-h /bin/bash -l -e "+sh+" -b "+label+" -u "+vm.user+" -p ~"+vm.user+"/checkq.py -a \""+vm.user+ " "+vm.project+"\" -r "+vm.server+" -label /tmp/responses/"+vm.user+"/output -d"+outpath;
            Process checkQ               = System.Diagnostics.Process.Start(processInfo);

            Thread.Sleep(15000);
            processResponse();            
		}
		
		public static void checkTraceFiles(string label)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			string linuxDir = vm.baseDir+"PDS_CORE/linux_scripts/";
			string view = vm.user+"_cad_"+label;

			//ProcessStartInfo tempInfo = new ProcessStartInfo();
	    	//tempInfo.WorkingDirectory = linuxDir;
	        //tempInfo.FileName         = @"set_temp.bat";
            //Process temp              = System.Diagnostics.Process.Start(tempInfo);

			string sh = linuxDir+"runpython.sh";
			
      	    //launch   
			ProcessStartInfo processInfo = new ProcessStartInfo();
	    	processInfo.WorkingDirectory = @"C:\cygwin64\bin";
	        processInfo.FileName         = @"mintty.exe";
	        processInfo.Arguments        = "-h /bin/bash -l -e "+sh+" -b "+label+" -u "+vm.user+" -p ~"+vm.user+"/checktracefiles.py -a \""+vm.user+" "+vm.project+"\" -r "+vm.server;
            Process checkTrace           = System.Diagnostics.Process.Start(processInfo);		
			         
            Thread.Sleep(30000);
            processResponse();
		}
		
		public static void checkHealthPDS(string label)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			string linuxDir = vm.baseDir+"PDS_CORE/linux_scripts/";
			string view = vm.user+"_cad_"+label;

			string sh = linuxDir+"runpython.sh";
			
      	    //launch   
			ProcessStartInfo processInfo = new ProcessStartInfo();
	    	processInfo.WorkingDirectory = @"C:\cygwin64\bin";
	        processInfo.FileName         = @"mintty.exe";
	        processInfo.Arguments        = "-h /bin/bash -l -e "+sh+" -b "+label+" -u "+vm.user+" -p ~"+vm.user+"/healthPDS.py -a \""+vm.user+"\" -r "+vm.server;
            Process checkHealth          = System.Diagnostics.Process.Start(processInfo);	

            Thread.Sleep(15000);
            processResponse();            
		}
		
		public static void processStats()
		{
			// TODO part of mpStatsGeneration
		}
		
		public static void stopView(string label, string db, string resetTdms)
		{
			string sh = "stopview.sh";
			cygwinExec(sh, label, db, resetTdms);
		}
		
		public static void cygwinExec(string proc, string label, string db, string resetTdms)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			string linuxDir = vm.baseDir+"PDS_CORE/linux_scripts/";
			string sh = linuxDir+proc;
			
			ProcessStartInfo processInfo = new ProcessStartInfo();
	    	processInfo.WorkingDirectory = @"C:\cygwin64\bin";
	        processInfo.FileName         = @"mintty.exe";
	        processInfo.Arguments        = "-h /bin/bash -l -e "+sh+" -u "+vm.user+" -r "+vm.server+ "-v Label -t "+label+" -p "+label+" -d "+db+" -m "+resetTdms;
            Process checkHealth          = System.Diagnostics.Process.Start(processInfo);		
		}
		
		public static void runDRAToolScripts(string label)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			string linuxDir = vm.baseDir;
			string view = vm.user+"_cad_"+label;
			string outpath = "/cygdrive/t/Systems/Automation/Results/PDS_Labels/"+label+"/info";
			linuxDir = linuxDir.Replace(@"\","/");
			string sh = linuxDir+"linux_scripts/runpython.sh";
			//launch   
			ProcessStartInfo processInfo = new ProcessStartInfo();
			processInfo.WorkingDirectory = @"C:\cygwin64\bin";
			processInfo.FileName         = @"mintty.exe";
	         
			// TODO: Finish the reformatting of this string (it will build in the meantime).
			string ToolScriptArguments     = string.Format(
				"/bin/bash -l -e "+sh+"  -b "+label+" -u "+vm.user+" -p ~"+vm.user+"/draTool.py  -a \""+vm.user+"\" -r "+vm.server
			);
			processInfo.Arguments = ToolScriptArguments;
			Process runDRAToolScripts    = System.Diagnostics.Process.Start(processInfo);
	       
			Report.Info("Arguments: " + ToolScriptArguments);
			Thread.Sleep(15000);            
		}
		
		private static void processResponse()
		{
		    VMEnvironment vm = VMEnvironment.Instance();
		    string responseDir = System.Environment.ExpandEnvironmentVariables(@"%TEMP%/Automation/Results/");
		    
		    string[] files = Directory.GetFiles(responseDir);
		    foreach (string file in files)
		    {
		        string text = File.ReadAllText(file);
		        string[] separator = new string[] {";"};
		        string[] responseArray = text.Split(separator, StringSplitOptions.None);
		            
		        separator = new String[] {","};
		        responseArray = responseArray[0].Split(separator, StringSplitOptions.None);
		        
		        if (responseArray[3].Equals("OK"))
		        {
		            Ranorex.Report.Success(responseArray[4]);
		        }
		        else if (responseArray[3].StartsWith("OK"))
		        {
		            Ranorex.Report.Success(responseArray[3]+", "+responseArray[4]);
		        }
		        else if (responseArray[3].Equals("FAILURE"))
		        {
		            Ranorex.Report.Error(responseArray[4]);		            
		        }
		        else if (responseArray[3].StartsWith("FAILURE"))
		        {
		            Ranorex.Report.Error(responseArray[3]+", "+responseArray[4]);		            
		        }		        
		        
		        System.IO.File.Delete(file);
		    }
		}
		public static string getCCOPLog_Betweentimestamp(string fromTime, string toTime)
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Process dtdProcess = new Process();
			string script = "scpCCOPLogFile.sh";
			string scriptOutput = "";
			string scriptErrors = "";
			string Executor = @"C:\cygwin64\bin\bash.exe";
			
			if (!File.Exists(Executor)) 
			{
				Ranorex.Report.Error("Missing "+Executor);
				return scriptOutput;
			}
			
			if (!File.Exists(vm.baseCoreDir+@"linux_scripts\"+script)) 
			{
				throw new Ranorex.ValidationException("Missing "+vm.baseCoreDir+@"linux_scripts\"+script);
			}
			
			if(File.Exists(@"C:\cygwin64\home\r07000021\output.log"))
			{
				File.Delete(@"C:\cygwin64\home\r07000021\output.log");
				Delay.Milliseconds(5000);
			}
			
			ProcessStartInfo scriptStartInfo 		= new ProcessStartInfo();
			
			string userName = vm.pdsUser;
			string server = vm.wapServer;
	      	
			string scriptArguments					= @"-l -e "+vm.baseCoreDir+@"linux_scripts\scpCCOPLogFile.sh -u " +userName+ " -r " +server+ " -f " +fromTime+ " -t " +toTime;
			scriptStartInfo.UseShellExecute			= false;
			scriptStartInfo.FileName				= Executor;
			scriptStartInfo.Arguments 				= scriptArguments;
			scriptStartInfo.RedirectStandardOutput	= true;
			scriptStartInfo.RedirectStandardError	= true;
			scriptStartInfo.RedirectStandardInput   = true;
			
			
			try 
			{
				
				dtdProcess = Process.Start(scriptStartInfo);
				scriptOutput = dtdProcess.StandardOutput.ReadToEnd();
				scriptErrors = dtdProcess.StandardError.ReadToEnd();
				
				System.IO.File.WriteAllText(vm.userTempDirectory+script.Substring(0, script.Length-3)+"_log.txt", scriptOutput);
//				Ranorex.Report.Info("Output: "+scriptOutput);
//				Ranorex.Report.Info("Error: "+scriptErrors);
				dtdProcess.WaitForExit(20000);				
			} catch (Exception e) {
				throw new Ranorex.ValidationException(script+" contains the following exception: " + e.ToString());
			}
			if (scriptErrors.Contains("ERROR:")) 
			{
				throw new Ranorex.ValidationException("Error in "+script+": "+scriptErrors);
			}
			
			return scriptOutput;
		}

	}	
}
