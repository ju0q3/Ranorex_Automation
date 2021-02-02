/*
 * Created by Ranorex
 * User: rolson
 * Date: 12/18/2017
 * Time: 9:33 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Ranorex;
using Ranorex.Core.Repository;
using Env.Code_Utils;

using PDS_CORE.Code_Utils;

namespace STE.Code_Utils
{
	/// <summary>
	/// Really cool STE stuff
	/// </summary>
	public class SteUtils
	{
	    private static string inboundDir = "C:/ste/runtime/stesim/intmsg/";
		private static string inboundMisDir = "C:/ste/runtime/stesim/intmsg/RawMIS/";
		private static string inboundMisArchiveDir = "C:/ste/runtime/stesim/intmsg/RawMIS/archive/";
		private static string inboundPtcDir = "C:/ste/runtime/stesim/intmsg/RawPTC/";
		private static string outboundDir = "C:/ste/runtime/stesim/extmsg/";
        private static int counter = 1;	
        private static string prevTime = System.DateTime.Now.ToString("yyyyMMdd");

		public static global::STE.Ste_Repo Sterepo = global::STE.Ste_Repo.Instance;
        
		public SteUtils()
		{
		}

		public static void PrepareSte(string cadNumber = "", string database = "")
		{
			stopSte();

			startSteRemoteControl(cadNumber: cadNumber, database: database);
			startCadSimController();
			startTestInterface(cadNumber: cadNumber);
		}

		// validateSteIsRunning()

		private static void startSteRemoteControl(string cadNumber, string database)
		{
			startSteRemoteClientProcess();
			
			inputExecutionProfile(cadNumber: cadNumber, database: database);

			waitForExists(repoItem: Sterepo.STE_Remote_Control_Client.SystemControl.StartButtonInfo, maxTimeInSeconds: 8);
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Sterepo.STE_Remote_Control_Client.SystemControl.StartButtonInfo,
				Sterepo.STE_Remote_Control_Client.SelfInfo
			);
		}

		private static void startTestInterface(string cadNumber)
		{
			startTestInterfaceProcess();
			inputCadNumber(cadNumber: cadNumber);

			waitForExists(repoItem: Sterepo.Test_Interface.SelfInfo, maxTimeInSeconds: 8);
		}

		private static void startCadSimController()
		{
			waitForExists(repoItem: Sterepo.CAD_Sim_Controller.StartStopButtonInfo, maxTimeInSeconds: 8);
			
			// This is a corner case where no attempts to harden the code have been successful
			
			// If the resume button appears, then CAD Sim Controller is stopped, and it can also be started
			// If the button does not exist, then the controller is not ready to start. 
			if (Sterepo.CAD_Sim_Controller.ResumeButtonInfo.Exists(0))
			{
				Sterepo.CAD_Sim_Controller.StartStopButton.Click();
			}

			int retries = 0;
			while (!Sterepo.CAD_Sim_Controller.ResumeButtonInfo.Exists(0) && retries < 5)
			{
				Delay.Seconds(1);
				if (Sterepo.CAD_Sim_Controller.ResumeButtonInfo.Exists(0))
				{
					Sterepo.CAD_Sim_Controller.StartStopButton.Click();
				}
				retries++;
			}
		}

		private static void inputExecutionProfile(string cadNumber, string database)
		{
			// TODO: Integrate logic to consume the cad number and database provided by the arguments.
			// This was agreed to be completed at a later date. 

			waitForExists(repoItem: Sterepo.Execution_Profile.ExecutionGroupInfo, maxTimeInSeconds: 8);
			
			VMEnvironment vm = VMEnvironment.Instance();

			string cad = Sterepo.Execution_Profile.ExecutionGroup.GetAttributeValue<string>("Text");
			string expCad = string.Format("CAD_{0}", vm.ste);
			Report.Info("The expected cad string is: " + expCad);

			if (cad != expCad)
			{
				Sterepo.Execution_Profile.ExecutionGroup.Click();
				Sterepo.Execution_Profile.ExecutionGroup.PressKeys("{Delete}");
				Sterepo.Execution_Profile.ExecutionGroup.Element.SetAttributeValue("Text", expCad);
				Sterepo.Execution_Profile.ExecutionGroup.PressKeys("{Tab}");
			}

			if (Sterepo.Execution_Profile.ExecutionGroup.GetAttributeValue<string>("Text") != expCad)
			{
				Report.Error("Execution Profile form has not populated as expected. Check STE.INI and attempt again.");
				Report.Screenshot(Sterepo.Execution_Profile.Self);
				return;
			}

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Sterepo.Execution_Profile.OkButtonInfo,
				Sterepo.Execution_Profile.SelfInfo
			);
		}

		private static void startSteRemoteClientProcess()
		{
			startRuntimeProcess(
				// Test Interface
				inputFile: @"C:\Ste\Runtime\SteAdminEx\SteRemoteControlClient.exe",
				workingDirectory: @"C:\Ste\Runtime\SteAdminEx"
			);
		}

		private static void inputCadNumber(string cadNumber)
		{
			// TODO: Integrate logic to consume the cad number provided by the argument.
			// This was agreed to be completed at a later date. 
			
			waitForExists(repoItem: Sterepo.CAD_Number.SelfInfo, maxTimeInSeconds: 8);
			
			VMEnvironment vm = VMEnvironment.Instance();

			string cad = Sterepo.CAD_Number.EnterCadNumber.GetAttributeValue<string>("Text");

			if (cad != vm.ste)
			{
				Sterepo.CAD_Number.EnterCadNumber.Click();
				Sterepo.CAD_Number.EnterCadNumber.PressKeys("{Delete}");
				Sterepo.CAD_Number.EnterCadNumber.Element.SetAttributeValue("Text", vm.ste);
				Sterepo.CAD_Number.EnterCadNumber.PressKeys("{Tab}");
			}

			if (Sterepo.CAD_Number.EnterCadNumber.GetAttributeValue<string>("Text") != vm.ste)
			{
				Report.Error("Execution Profile form has not populated as expected. Check STE.INI and attempt again.");
				Report.Screenshot(Sterepo.CAD_Number.Self);
				return;
			}

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Sterepo.CAD_Number.OkButtonInfo,
				Sterepo.CAD_Number.SelfInfo
			);
		}

		private static void startTestInterfaceProcess()
		{
			startRuntimeProcess(
				// Test Interface
				inputFile: @"C:\Ste\Runtime\TestInterface\TestInterface.exe",
				workingDirectory: @"C:\Ste\Runtime\TestInterface"
			);
		}

		private static void waitForExists(RepoItemInfo repoItem, int maxTimeInSeconds)
		{
			System.Diagnostics.Stopwatch newWatch = System.Diagnostics.Stopwatch.StartNew();
			while (!repoItem.Exists(0) && (newWatch.Elapsed.Seconds <= maxTimeInSeconds))
			{
				Report.Info(string.Format("Max wait time is {0}s, and {1}s has elapsed. The form is not open.", maxTimeInSeconds.ToString(), newWatch.Elapsed.Seconds));
			}

			if (!repoItem.Exists(0) && (newWatch.Elapsed.Seconds > maxTimeInSeconds))
			{
				Report.Error(string.Format("Repo item '{0}' did not appear within the maximum wait time: '{1}s'", repoItem.ToString(), maxTimeInSeconds.ToString()));
			}
			else
			{
				Report.Success(string.Format("Repo item '{0}' appeared within the allocated time frame of '{1}s'", repoItem.ToString(), maxTimeInSeconds.ToString()));
			}
		}

		private static void waitForNotExists(RepoItemInfo repoItem, int maxTimeInSeconds)
		{
			System.Diagnostics.Stopwatch newWatch = System.Diagnostics.Stopwatch.StartNew();
			while (repoItem.Exists(0) && (newWatch.Elapsed.Seconds <= maxTimeInSeconds))
			{
				Report.Info(string.Format("Max wait time is {0}s, and {1}s has elapsed. The form is open.", maxTimeInSeconds.ToString(), newWatch.Elapsed.Seconds));
			}

			if (repoItem.Exists(0) && (newWatch.Elapsed.Seconds > maxTimeInSeconds))
			{
				Report.Error(string.Format("Repo item '{0}' did not disappear within the maximum wait time: '{1}s'", repoItem.ToString(), maxTimeInSeconds.ToString()));
			}
			else
			{
				Report.Success(string.Format("Repo item '{0}' disappeared within the allocated time frame of '{1}s'", repoItem.ToString(), maxTimeInSeconds.ToString()));
			}
		}

		private static void startRuntimeProcess(string inputFile, string workingDirectory)
		{
			Report.Info("The file name is: " + inputFile);
			Report.Info("The working directory is: " + workingDirectory);
			
			VMEnvironment vm = VMEnvironment.Instance();
			if (!File.Exists(path: inputFile))
			{
				Report.Error(string.Format("Unable to find '{0}' on '{1}'. Please check environment and try again.", inputFile, vm.computer));
				return;
			}
			
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();

			startInfo.FileName 	= inputFile;
			startInfo.WorkingDirectory = workingDirectory;
			try 
			{
				process = Process.Start(startInfo);
			}
			catch (Exception e) 
			{
				throw new Ranorex.ValidationException(e.ToString());
			}			
		}
			
		public static void stopSte()
		{
			LinuxUtils.RunBatchScript("windows_scripts/kill_ste.bat");
			waitForNotExists(repoItem: Sterepo.STE_Remote_Control_Client.SelfInfo, maxTimeInSeconds: 5);
		}

		public static string getFileName()
		{
		    System.DateTime now = System.DateTime.Now;
		    string time = now.ToString("yyyyMMddHHmm_");
		    
		    string shortTime = now.ToString("yyyyMMdd");
		    //Check if date changed
		    if (!shortTime.Equals(prevTime))
		    {
		        counter = 1;
		    }
		    prevTime = shortTime;   
		    
		    string fileName = time+counter.ToString("D6")+".request";
		    counter++;
		    return fileName;
		}
		
		// cleanMessages cleans up messages from previous runs as part of cleanup process
		public static void cleanAllMessages()
		{
			System.IO.DirectoryInfo di;

			di = new System.IO.DirectoryInfo(inboundDir);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			
			di = new System.IO.DirectoryInfo(outboundDir);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			
			di = new System.IO.DirectoryInfo(inboundMisDir);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			
			di = new System.IO.DirectoryInfo(inboundMisArchiveDir);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			
			di = new System.IO.DirectoryInfo(inboundPtcDir);
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
		}
		
		public static string getInboundDir()
		{
		    return inboundDir;
		}
		
		public static string getInboundMisDir()
		{
		    return inboundMisDir;
		}
		
		public static string getInboundPtcDir()
		{
		    return inboundPtcDir;
		}
		
		public static string getInboundMisArchiveDir()
		{
		    return inboundMisArchiveDir;
		}
		
		public static string getOutboundDir()
		{
		    return outboundDir;
		}
	}
}
