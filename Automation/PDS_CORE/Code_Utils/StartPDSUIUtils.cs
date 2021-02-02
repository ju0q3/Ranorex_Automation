/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/16/2017
 * Time: 8:41 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Ranorex;
using Env.Code_Utils;

namespace PDS_CORE.Code_Utils
{
	/// <summary>
	/// Description of StartPDSUiUtils.
	/// </summary>
	public class StartPDSUIUtils
	{
		
		public StartPDSUIUtils()
		{
		}
		
		public static bool mDriveUiStart(string labelName)
		{
			Process scriptProcess = new Process();
			string Executor = "cmd.exe";
			string scriptArguments = @"/C run-pds.bat -noclear";
			if (!File.Exists(@"C:\PDS\"+labelName+@"\run-pds.bat")) {
				return false;
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();
			
			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = scriptArguments;
			scriptStartInfo.WorkingDirectory = @"C:\PDS\"+labelName+@"";
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);

	      	} catch (Exception) {
            	return false;
	      	}
			
			//Gives a 2 minute duration to continue looking for the network login windows, signifying the UI is running
			Ranorex.Core.Element form;
			bool exists = Host.Local.TryFindSingle("form[@title='Network Logon']",120000,out form);
			return exists;
			
		}
	
		public static bool iDriveUiStart(string labelName)
		{
			Process scriptProcess = new Process();
			string Executor = "cmd.exe";
			string scriptArguments = @"/C runClient-automation.bat -version "+labelName;
			if (!File.Exists(@"C:\Pds\runClient-automation.bat")) {
				return false;
			}
			
			ProcessStartInfo scriptStartInfo = new ProcessStartInfo();

			scriptStartInfo.FileName = Executor;
			scriptStartInfo.Arguments = scriptArguments;
			scriptStartInfo.WorkingDirectory = @"C:\Pds";
			
			try {
				//Run script
            	scriptProcess = Process.Start(scriptStartInfo);
            	
	      	} catch (Exception) {
            	return false;
	      	}
			
			//Gives a 5 minute duration to continue looking for the network login windows, signifying the UI is running
			Ranorex.Core.Element form;
			bool exists = Host.Local.TryFindSingle("form[@title='Network Logon']",300000,out form);
			return exists;
		}
	
		public static void preparePDSUI(string labelName)
		{         
 			VMEnvironment vm = VMEnvironment.Instance();

 			//sync the environment
			LinuxUtils.syncEnvironment(vm, labelName);
			string backupConnectionPropertiesFile = vm.baseCoreDir+"Data/Environment/connection.properties";
			string backupClientPropertiesFile = vm.baseCoreDir+"Data/Environment/client.properties";
			string connectionPropertiesFile = @"C:/Ste/regression_test/PDSTest/data/config/properties/connection.properties";
			string clientPropertiesFile = @"C:/Ste/regression_test/PDSTest/data/config/properties/client.properties";
			string propertyFilesLocal = System.Environment.ExpandEnvironmentVariables(@"%USERPROFILE%/pds-config/properties/");
			
			if (!File.Exists(connectionPropertiesFile) || !File.Exists(clientPropertiesFile)) {
				//copy over property files
				string connectionProperties = System.IO.File.ReadAllText(backupConnectionPropertiesFile);
				connectionProperties = connectionProperties.Replace("INTEGRATIONSERVER", vm.server);
			
				string clientProperties = System.IO.File.ReadAllText(backupClientPropertiesFile);
			
				try {
					System.IO.File.WriteAllText(propertyFilesLocal+"connection.properties", connectionProperties);
					System.IO.File.WriteAllText(propertyFilesLocal+"client.properties", clientProperties);
				} catch (Exception) {
					throw new Ranorex.ValidationException("Unable to write connection and/or client property files");
				}
			} else {
				File.Copy(connectionPropertiesFile, propertyFilesLocal+"connection.properties", true);
				File.Copy(clientPropertiesFile, propertyFilesLocal+"client.properties", true);
			}
			if (!File.Exists(propertyFilesLocal+"connection.properties")) {
				throw new Ranorex.ValidationException("Missing "+propertyFilesLocal+"connection.properties");
			}
			if (!File.Exists(propertyFilesLocal+"client.properties")) {
				throw new Ranorex.ValidationException("Missing "+propertyFilesLocal+"client.properties");
			}
			//Check if current label has already been downloaded from M Drive and is runnable
			string mDrivePathRun = @"C:/PDS/"+labelName+"/pds-ns-config/dev/bin/pds-ui-automation.bat";
			if (File.Exists(mDrivePathRun)) {
			    if (mDriveUiStart(labelName)) {
			    	return;
			    }
			}
			
			//Check if current label has already been installed from I Drive and is runnable
			string iDriveDirectory = "";
			string iDriveInstallName = "";
			foreach (string directory in Directory.GetDirectories(@"C:\PDS"))
            {
				if (!directory.Equals(@"C:\PDS\"+labelName) && directory.EndsWith(labelName))
            	{
            		iDriveDirectory = directory;
            		iDriveInstallName = new DirectoryInfo(iDriveDirectory).Name;
            	}
            }
			if (!iDriveDirectory.Equals("")) {
				if (iDriveUiStart(iDriveInstallName)) {
			    	return;
			    }
			}
			
			
			
			//Begin M Drive installation
			
			
			//download PDS UI
			LinuxUtils.runBatchScript(vm,vm.baseCoreDir+"windows_scripts/download-pds-ui.bat",labelName);
			
			//Check if current label has already been downloaded from M Drive and is runnable
			if (File.Exists(mDrivePathRun)) {
			    if (mDriveUiStart(labelName)) {
			    	return;
			    }
			}
			
			string ErrorString = "M Drive installation was unsuccessful. ";
			
			//Begin I Drive installation if M Drive wasn't successful
			
			
			//run installer for the label
			string iDriveBase = "";
			if (Directory.Exists(@"I:\PDS\")) {
				iDriveBase = @"I:\PDS\";
			} else if (Directory.Exists(@"I:\TMS2\PDS\")) {
				iDriveBase = @"I:\TMS2\PDS\";
			} else {
				throw new Ranorex.ValidationException(ErrorString+"I Drive not properly Mounted");
			}
			LinuxUtils.runBatchScript(vm,iDriveBase+labelName+@"\fullinstall.bat","");
			
			//Get path for directory of newly installed PDS
			foreach (string directory in Directory.GetDirectories(@"C:\PDS"))
            {
				if (!directory.Equals(@"C:\PDS\"+labelName) && directory.EndsWith(labelName))
            	{
            		iDriveDirectory = directory;
            		iDriveInstallName = new DirectoryInfo(iDriveDirectory).Name;
            	}
            }
			
			if (iDriveDirectory.Equals("")) {
				throw new Ranorex.ValidationException(ErrorString+@"No folders found in C:\PDS\ end with view name "
				                                      +labelName+" after I drive installation. ");
			}
			
			//Copy connection.properties into new PDS directory
			try {
				System.IO.File.Copy(propertyFilesLocal+"connection.properties",iDriveDirectory+"/config/properties/connection.properties",true);
			} catch (Exception) {
				throw new Ranorex.ValidationException(ErrorString+"Unable to copy "+propertyFilesLocal+"connection.properties to " + iDriveDirectory+"/config/properties/connection.properties");
			}
			
			//Rename ChooserConfig.xml to stop the option list when starting PDS
			if (System.IO.File.Exists("C:/PDS/ChooserConfig.xml")) {
				try {
					System.IO.File.Copy("C:/PDS/ChooserConfig.xml","C:/PDS/DoNotChooserConfig.xml",true);
					System.IO.File.Delete("C:/PDS/ChooserConfig.xml");
				} catch (Exception) {
			    	throw new Ranorex.ValidationException(ErrorString+"Unable to Rename C:/PDS/ChooserConfig.xml to C:/PDS/DoNotChooserConfig.xml");
				}
			}
			
			//Write rci.txt to point to the folder containing java to run the PDS UI
			try {
				System.IO.File.WriteAllText("C:/PDS/rci.txt", iDriveInstallName+@"\jre7_u15");
			} catch (Exception) {
				throw new Ranorex.ValidationException(ErrorString+"Unable to Write C:/PDS/rci.txt");
			}
			
			//copy contents of runClient.bat to runClient-automation.bat without JAVA references
			string lineToDelete1 = "_JAVA_OPTIONS";
			string lineToDelete2 = "JAVA_TOOL_OPTIONS";
			string line;
			try {
				using (StreamReader reader = new StreamReader("C:/PDS/runClient.bat")) {
					using (StreamWriter writer = new StreamWriter(new FileStream("C:/PDS/runClient-automation.bat", FileMode.Create, FileAccess.Write))) {
						while ((line = reader.ReadLine()) != null) {
							if (line.Contains(lineToDelete1) || line.Contains(lineToDelete2))
								continue;

							writer.WriteLine(line);
						}
					}
				}
			} catch (Exception) {
				throw new Ranorex.ValidationException(ErrorString+"Unable to make C:/PDS/runClient-automation.bat");
			}
			
			if (iDriveUiStart(iDriveInstallName)) {
			    return;
			  }
			throw new Ranorex.ValidationException(ErrorString+"Running I Drive installation has failed");
			
 		}
 	}
}
