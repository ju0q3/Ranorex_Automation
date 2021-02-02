/*
 * Created by Ranorex
 * User: 212719544
 * Date: 1/10/2020
 * Time: 2:31 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;
using PrimS.Telnet;
using Renci.SshNet;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace OnBoard.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class OnBoardFunctions
    {
        public static OnBoard.OnBoardRepository OnBoardRepo = OnBoard.OnBoardRepository.Instance;
        
        public static int currentZoom = 100;
        public static float buttonsYOffset = .92f;
        public static float buttonsXOffset = .122f;
        public static float buttonsXInitial = .066f;
        public static Location button1xy = new Location(buttonsXInitial + (buttonsXOffset * 0), buttonsYOffset);
        public static Location button2xy = new Location(buttonsXInitial + (buttonsXOffset * 1), buttonsYOffset);
        public static Location button3xy = new Location(buttonsXInitial + (buttonsXOffset * 2), buttonsYOffset);
        public static Location button4xy = new Location(buttonsXInitial + (buttonsXOffset * 3), buttonsYOffset);
        public static Location button5xy = new Location(buttonsXInitial + (buttonsXOffset * 4), buttonsYOffset);
        public static Location button6xy = new Location(buttonsXInitial + (buttonsXOffset * 5), buttonsYOffset);
        public static Location button7xy = new Location(buttonsXInitial + (buttonsXOffset * 6), buttonsYOffset);
        public static Location button8xy = new Location(buttonsXInitial + (buttonsXOffset * 7), buttonsYOffset);
        public static Rectangle topBannerRectangle = new Rectangle(new Point(133, 117), new Size(490, 120));
        //public static Rectangle topBannerRectangle = new Rectangle(new Point(125, 100), new Size(355, 37));
        public static Rectangle mphRectangle = new Rectangle(new Point(255, 50), new Size(140, 52));
        public static Rectangle ptcStatusRectangle = new Rectangle(new Point(480, 100), new Size(140, 30));
        public static Rectangle ptcEngineRectangle = new Rectangle(new Point(480, 75), new Size(140, 30));
        public static Rectangle bannerRectangle = new Rectangle(new Point(0, 453), new Size(605, 80));
        public static Rectangle departRectangle = new Rectangle(new Point(424, 387), new Size(202, 107));
        public static Rectangle syncRectangle = new Rectangle(new Point(179, 388), new Size(171, 97));
        public static Rectangle mainScreenRectangle = new Rectangle(new Point(15, 178), new Size(633, 349));
        //public static Rectangle mainScreenAuthorityLine2ContentRectangle = new Rectangle(new Point(15, 238), new Size(350, 209));
        public static Rectangle mainScreenAuthorityRollupLocationContentRectangle = new Rectangle(new Point(15, 300), new Size(350, 227));
        //public static Rectangle mainScreenNxtTargetRectangle = new Rectangle(new Point(300, 300), new Size(356, 227));
        public static Rectangle mainScreenTitleRectangle = new Rectangle(new Point(15, 147), new Size(630, 110));
        
        
        /// <summary>
        /// Ensures all simulators are running on the OnBoard computer and that the OnBoard is the First Slice.
        /// </summary>
        [UserCodeMethod]
        public static string TelnetIntoCDUsAndReset_OnBoard()
        {
        	string onBoardSimulatorFileLocation = ""; // @"C:\Wabtec\OB-6.3.17.1\Test\System-Test\";
        	//String onBoardSimulatorFileLocation = @"C:\Wabtec\OB-6.3.19.0\Test\System-Test\";
//        	try {
//                onBoardSimulatorFileLocation = TestSuite.Current.Parameters["OnBoardSimulatorFileLocation"];//@"C:\Wabtec\OB-6.3.17.1\Test\System-Test\"; 
//        	} catch {
//        		return "Error: Could not get OnBoardSimulatorFileLocation, please ensure you're running from the test suite level and that the variable is set";
//        	}
        	
        	TelnetResetTask().Wait();

        	//Long delay as slices take a while to sync
        	//Waiting upto 10 mins for CDUs to sync adn restart
        	Ranorex.Delay.Seconds(270);
        	int retries = 0;
        	string onboardText = OCRValidation_OnBoard("MAP", "mainScreen", "100", "true");
        	while((!onboardText.Contains("Success")) && retries < 11)
        	{
        		Ranorex.Delay.Seconds(30);
        		onboardText = OCRValidation_OnBoard("MAP", "mainScreen", "100", "true");
        		retries++;
        	}
        	
        	RecursiveSetSlice1ToPrimary(onBoardSimulatorFileLocation);
        	
            return "Info: Restarted CDU's";
        }
        
        [UserCodeMethod]
        public static string executeITCMCommand_OnBoard(string command)
        {
        	Ranorex.Report.Info("Starting ICSM");
        	SshClient sshClient = new SshClient("10.255.255.20", "root", "ptcuser");
        	sshClient.Connect();
        	SshCommand sc = sshClient.CreateCommand(command);
        	sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(10);
        	sc.Execute();
        	sc.Dispose();
        	sshClient.Disconnect();
        	sshClient.Dispose();
        	Ranorex.Report.Info("Ending ITCM");
        	return "Info: ITCM Command Executed";
        }
        
        public static async Task<string> TelnetResetTask()
        {
        	Ranorex.Report.Info("Starting Telnet Reset Task");
        	string returnString = "";
        	
        	SshClient sshClient = new SshClient("10.255.255.10", "root", "wabtec");
        	sshClient.Connect();
        	SshCommand sc = sshClient.CreateCommand("reboot");
        	sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(10);
        	sc.Execute();
        	sshClient.Disconnect();
        	sc.Dispose();
        	sshClient.Dispose();
        	Ranorex.Report.Info("Completing CDU Reboot");
        	string[] ipList = new string[] {"10.255.255.11", "10.255.255.12", "10.255.255.13"};
        	foreach (string clientIp in ipList)
        	{
        		using (var telnetClient = new PrimS.Telnet.Client(clientIp, 23, new CancellationToken()))
        		{
        			if (!telnetClient.IsConnected)
        			{
        				if (returnString != "")
	        			{
	        				returnString = returnString + "|";
	        			}
	        			returnString = returnString + "Error: Failed to reboot CDU with IP {" + clientIp + "}.";
        			}
        			string s = await telnetClient.ReadAsync(TimeSpan.FromSeconds(10));
        			await telnetClient.Write("root\r\n");
        			s = await telnetClient.ReadAsync(TimeSpan.FromSeconds(10));
        			await telnetClient.Write("wabtec\r\n");
        			s = await telnetClient.ReadAsync(TimeSpan.FromSeconds(10));
        			Ranorex.Delay.Seconds(2);
        			await telnetClient.Write("reboot\r\n");
        			Ranorex.Report.Info("Rebooted CPU: "+clientIp);
        		}
        	}
        	
        	if (returnString == "")
        	{
        		returnString = "Info: Successfully Restarted CDU's";
        	}
        	Ranorex.Report.Info("Ending Telnet Reset Task");
        	return returnString;
        }
        
        public static void OpenComparatorFormIfNotOpen(string onBoardSimulatorFileLocation, string cduIp)
        {
        	Ranorex.Report.Info("CDU IP:"+cduIp);
        	Ranorex.Report.Info("Opening Comparator");
        	OnBoardRepo.cduIp = cduIp;
        	if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
        	{
        		string debugClientName = "";
        		if (cduIp == "10.255.255.11")
    		    {
    		    	debugClientName = @"Vital-DebugClient-Slice1.exe";
        		} else if (cduIp == "10.255.255.12") {
        			debugClientName = @"Vital-DebugClient-Slice2.exe";
        		} else if (cduIp == "10.255.255.13") {
        			debugClientName = @"Vital-DebugClient-Slice3.exe";
        		}
        		Ranorex.Report.Info("Starting CDU");
        		try {
        			Process startDebugProcess = new Process();
        			ProcessStartInfo startDebugProcessInfo = new ProcessStartInfo();

        			startDebugProcessInfo.UseShellExecute = false; //don't want a shell to be the parent process
        			startDebugProcessInfo.WorkingDirectory = onBoardSimulatorFileLocation;
        			startDebugProcessInfo.FileName = onBoardSimulatorFileLocation+debugClientName;
        			//Ranorex.Report.Info("Before Try");
        			
        			//Run script
        			startDebugProcess = Process.Start(startDebugProcessInfo);
        			
        			//Wait up to 30 Secs for process to end
        			startDebugProcess.WaitForExit(30000);
        			startDebugProcess.Close();
        			startDebugProcess.Dispose();
        			Report.Info("Starting Debug Client");
        			Ranorex.Delay.Seconds(5);
        			Ranorex.Report.Info("Waited for 5 Seconds");
        			
        		} catch (Exception e) {
        			throw new Ranorex.ValidationException("{0} Exception", e);
        		}
        		
        		int retries = 0;
        		while (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0) && retries < 3)
        		{
        			Ranorex.Delay.Milliseconds(500);
        			retries++;
        		}
        		
        		if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
        		{
        			//Check if a blank form exists, because then we need to open it to the correct CDU
        			OnBoardRepo.cduIp = "0 Bytes";
        			if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
        			{
        				OnBoardRepo.cduIp = cduIp;
        				Ranorex.Report.Info("No Debug Client Exist, returning from here");
        				return;
        			} else {
        				Ranorex.Report.Info("0 Bytes Else");
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.FileButtonInfo, OnBoardRepo.Debug_Client.FileMenu.SelfInfo);
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.FileMenu.PropertiesInfo, OnBoardRepo.Debug_Client.Properties_Form.SelfInfo);
        				if (OnBoardRepo.Debug_Client.Properties_Form.Router.IPText.TextValue != cduIp)
        				{
        					OnBoardRepo.Debug_Client.Properties_Form.Router.IPText.Click();
        					OnBoardRepo.Debug_Client.Properties_Form.Router.IPText.Element.SetAttributeValue("Text", cduIp);
        					OnBoardRepo.Debug_Client.Properties_Form.Router.IPText.PressKeys("{TAB}");
        				}
        				
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(OnBoardRepo.Debug_Client.Properties_Form.Router.OpenButtonInfo, OnBoardRepo.Debug_Client.Properties_Form.Router.OpenButtonInfo);
        				OnBoardRepo.cduIp = cduIp;
        				if(OnBoardRepo.Debug_Client.Properties_Form.SaveButtonInfo.Exists(0))
        				{
        					OnBoardRepo.Debug_Client.Properties_Form.SaveButton.EnsureVisible();
        				}
        				else
        				{
        					retries = 0;
        					while(!OnBoardRepo.Debug_Client.Properties_Form.SaveButtonInfo.Exists(0) && retries < 10)
        					{
        						Ranorex.Delay.Seconds(2);
        						Ranorex.Report.Info("Save button does not exist");
        						retries++;
        					}
        					Ranorex.Report.Info("Save Outside While button does not exist");
        				}
        				
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Properties_Form.SaveButtonInfo, OnBoardRepo.Debug_Client.Properties_Form.SelfInfo);
        				
        				OnBoardRepo.cduIp = cduIp;
        				Ranorex.Report.Info("Starting new Debug Client");
        			}
        		}
        	}
        	
        	if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.DebugButtonInfo, OnBoardRepo.Debug_Client.DebugMenu.SelfInfo);
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.DebugMenu.GenericInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
        		if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
        		{
        			Ranorex.Report.Info("No Debug Client Exist, even after trying to open, returning from here");
        			return;
        		}
        	}
        	
        	if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo.Exists(0))
        	{
        		OnBoardRepo.Description = "Comparator";
        		PDS_CORE.Code_Utils.GeneralUtilities.DoubleClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.DescriptionInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
        		//This retries in case the comparator form didn't load properly
        		if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.SliceDataInfo.Exists(0))
        		{
        			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
        			PDS_CORE.Code_Utils.GeneralUtilities.DoubleClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.DescriptionInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
        			
        		}
        	}
        	
        	if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.SliceDataInfo.Exists(0))
        	{
        		WinForms.MessageBox.Show("Comparator form is not opening correctly, please fix and press ok", "Error",
                                         WinForms.MessageBoxButtons.OK);
        	}
        	Ranorex.Report.Info("Returning from Open Comparator form method");
        	return;
        }
        
        /// <summary>
        /// Ensures all simulators are running on the OnBoard computer and that the OnBoard is the First Slice.
        /// </summary>
        [UserCodeMethod]
        public static void RecursiveSetSlice1ToPrimary(string onBoardSimulatorFileLocation, int currentAttempt = 0)
        {
        	Report.Info("Setting Slice1 to Primary");
        	//if we get to 5 attempts to make slice 1 the primary, request manual intervention
        	if (currentAttempt == 5)
        	{
        		WinForms.MessageBox.Show("Unable to get Slice 1 to be Primary. Please manually correct CDU configuration", "Error",
                                         WinForms.MessageBoxButtons.OK);
        	}
        	
        	OnBoardRepo.cduIp = "10.255.255.11";
        	OpenComparatorFormIfNotOpen(onBoardSimulatorFileLocation, OnBoardRepo.cduIp);
        	
        	//Make sure it's on the right tab
        	if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.SliceData.Selected)
        	{
        		Ranorex.Report.Info("No Slice Data Comparator Tab open");
        		OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.SliceData.Click();
        	}
        	Ranorex.Report.Info("Checking Slice State");
        	//Check which slice is primary
        	Ranorex.Delay.Seconds(5);
        	string mySliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.MySlice.GetAttributeValue<string>("Text");
        	string leftSliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.LeftSlice.GetAttributeValue<string>("Text");
        	string rightSliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.RightSlice.GetAttributeValue<string>("Text");
        	int retries = 0;
        	while((mySliceState.Equals("RE-SYNC", StringComparison.OrdinalIgnoreCase) ||
        	   leftSliceState.Equals("RE-SYNC", StringComparison.OrdinalIgnoreCase) ||
        	   rightSliceState.Equals("RE-SYNC", StringComparison.OrdinalIgnoreCase)) && retries < 8)
        	{
        		Ranorex.Report.Info("One of the Slice is not completely Sync'ed");
        		Ranorex.Delay.Seconds(30);
        		mySliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.MySlice.GetAttributeValue<string>("Text");
        		leftSliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.LeftSlice.GetAttributeValue<string>("Text");
        		rightSliceState = OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceStateRow.RightSlice.GetAttributeValue<string>("Text");
        	
        		retries++;
        	}
        	Ranorex.Report.Info("MySlice: "+mySliceState);
        	Ranorex.Report.Info("Left Slice: "+leftSliceState);
        	Ranorex.Report.Info("Right Slice: "+rightSliceState);
        	if (mySliceState.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        	{
        		Report.Info("Checking Slice1 details");
        		//Check if onboard is in a serviceable state, otherwise restart it
        		HashSet<Color> colorsFound = new HashSet<Color>();
	        	Bitmap onboardBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
	        	Bitmap bannerBoxBitmap = onboardBitmap.Clone(bannerRectangle, onboardBitmap.PixelFormat);
	        	Color redColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("Red");
	        	
	        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(bannerBoxBitmap);
	        	bool colorInHashSet = colorsFound.Contains(redColor);
	        	if (colorInHashSet)
	        	{
	        		Ranorex.Report.Info("Run stop script after checking Slice State");
	        		RunSimulatorStopScript(onBoardSimulatorFileLocation);
	        		Ranorex.Delay.Seconds(10);
	        		
	        		//Checking if any process still running
	        		
	        		Process [] processes = System.Diagnostics.Process.GetProcesses();
	        		
	        		foreach(var process in processes)
	        		{
	        			if(!String.IsNullOrEmpty(process.MainWindowTitle))
	        			{
	        				Report.Info("Process still running: "+process.MainWindowTitle.ToString());
	        				if(process.MainWindowTitle.Contains("Loco") || process.MainWindowTitle.Contains("Debug Client") || process.MainWindowTitle.Contains("CDU-1")
	        				   || process.MainWindowTitle.Contains("emp_router") || process.MainWindowTitle.Contains("Office 3.0")
	        				   || process.MainWindowTitle.Contains("Wayside Simulator") || process.MainWindowTitle.Contains("IOC Simulator")
	        				   || process.MainWindowTitle.Contains("Wayside Network Server"))
	        				{
	        					process.Kill();
	        					Ranorex.Report.Info("Killing Process:"+process.MainWindowTitle.ToString());
        						Ranorex.Delay.Seconds(5);
	        				}
	        			}
	        			
	        		}
	        		Ranorex.Report.Info("Run start script in slice state");
	        		RunSimulatorStartScript(onBoardSimulatorFileLocation);
	        		RecursiveSetSlice1ToPrimary(onBoardSimulatorFileLocation, currentAttempt++);
	        	} else {
	        		OnBoardRepo.cduIp = "10.255.255.11";
		        	System.DateTime futureTime = System.DateTime.Now.AddMinutes(15);
		        	//Wait up to 15 minutes for all Slices to be in Sync
		        	while ((OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.LeftSlice.GetAttributeValue<string>("Text") != "IN-SYNC" 
		        	        || OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.RightSlice.GetAttributeValue<string>("Text") != "IN-SYNC" 
		        	        || OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.MySlice.GetAttributeValue<string>("Text") != "IN-SYNC") 
		        	        && System.DateTime.Now < futureTime)
		        	{
		        		Ranorex.Report.Info("Wait until all Slices are In Sync, total wait time is 15 mins");
		        		Ranorex.Delay.Seconds(5);
		        	}
		        	
		        	if (OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.LeftSlice.GetAttributeValue<string>("Text") != "IN-SYNC" || OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.RightSlice.GetAttributeValue<string>("Text") != "IN-SYNC" || OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.DataSyncFlagRow.MySlice.GetAttributeValue<string>("Text") != "IN-SYNC")
		        	{
		        		WinForms.MessageBox.Show("One or more of the slices are not in sync, please correct Slice configuration", "Error",
		                                         WinForms.MessageBoxButtons.OK);
		        	}
		        	
		        	if (OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo.Exists(0))
		        	{
		        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
		        	}
		        	if (OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
		        	{
		        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
		        	}
	        	}
	        	
        		return;
        	} else if (rightSliceState.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        	{
        		Ranorex.Report.Info("Right Slice Primary");
        		if (OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceIdRow.RightSlice.GetAttributeValue<string>("Text") == "2")
        		{
        			OnBoardRepo.cduIp = "10.255.255.12";
        		} else {
        			OnBoardRepo.cduIp = "10.255.255.13";
        		}
        	} else if (leftSliceState.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        	{
        		Ranorex.Report.Info("Left Slice Primary");
        		if (OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SliceData.SliceDataTable.SliceIdRow.LeftSlice.GetAttributeValue<string>("Text") == "2")
        		{
        			OnBoardRepo.cduIp = "10.255.255.12";
        		} else {
        			OnBoardRepo.cduIp = "10.255.255.13";
        		}
        	}
        	else
        	{
        		Ranorex.Report.Info("Something went wrong");
        	}
        	
        	OpenComparatorFormIfNotOpen(onBoardSimulatorFileLocation, OnBoardRepo.cduIp);
        	
        	//Make sure it's on the right tab
        	if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.TestFunctions.Selected)
        	{
        		Ranorex.Report.Info("Comparator form not open");
        		OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.ComparatorTabs.TestFunctions.Click();
        	}
        	Ranorex.Report.Info("Flipping primary");
        	OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.TestFunctions.FlipPrimaryButton.Click();
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.SelfInfo);
        	Ranorex.Delay.Seconds(10);
        	
        	RecursiveSetSlice1ToPrimary(onBoardSimulatorFileLocation, currentAttempt++);
        	
        	return;
        }
        
        [UserCodeMethod]
        public static void RunSimulatorStopScript(string onBoardSimulatorFileLocation)
        {
        	string stopSimulatorPath = onBoardSimulatorFileLocation + @"simulators-stop.bat";
        	
        	//run the simulators stop script in case simulators are already running
        	Process stopProcess = new Process();
        	ProcessStartInfo stopProcessInfo = new ProcessStartInfo();

	      	stopProcessInfo.UseShellExecute = false; //don't want a shell to be the parent process
	      	stopProcessInfo.WorkingDirectory = onBoardSimulatorFileLocation;
			stopProcessInfo.FileName = stopSimulatorPath;
			stopProcessInfo.RedirectStandardOutput = true;
			stopProcessInfo.RedirectStandardError = true;
        	stopProcess = Process.Start(stopProcessInfo);
            	
        	string scriptOutput = stopProcess.StandardOutput.ReadToEnd();
        	string scriptErrors = stopProcess.StandardError.ReadToEnd();
        	
        	//Wait up to 4 minutes for process to end
        	Report.Info("Waiting for upto 4 mins to Stop the OnBoard Apps");
        	stopProcess.WaitForExit(240000);
        	stopProcess.Close();
        	stopProcess.Dispose();
        	Report.Info("OnBoard Apps stopped");
        	return;
        }
        
        [UserCodeMethod]
        public static void RunSimulatorStartScript(string onBoardSimulatorFileLocation)
        {
        	string startSimulatorPath = onBoardSimulatorFileLocation + @"simulators-start.bat";
        	
        	//run the simulators stop script in case simulators are already running
        	Process startProcess = new Process();
        	ProcessStartInfo startProcessInfo = new ProcessStartInfo();

	      	startProcessInfo.UseShellExecute = false; //don't want a shell to be the parent process
	      	startProcessInfo.WorkingDirectory = onBoardSimulatorFileLocation;
			startProcessInfo.FileName = startSimulatorPath;
			startProcess = Process.Start(startProcessInfo);
			
			startProcess.WaitForExit(90000);
			startProcess.Close();
			startProcess.Dispose();
			Report.Info("Started Start script");
        	Ranorex.Delay.Seconds(60);
        	Report.Info("Completed Start Script");
        	return;
        }
        
        /// <summary>
        /// Ensures all simulators are running on the OnBoard computer and that the OnBoard is the First Slice.
        /// </summary>
        [UserCodeMethod]
        public static string RestartOnBoardAndSimulators_OnBoard()
        {
        	string onBoardSimulatorFileLocation = "";
        	//string onBoardSimulatorFileLocation = @"C:\Wabtec\OB-6.3.17.1\Test\System-Test\";
        	try {
                onBoardSimulatorFileLocation = TestSuite.Current.Parameters["OnBoardSimulatorFileLocation"];
                //onBoardSimulatorFileLocation = @"C:\Wabtec\OB-6.3.17.1\Test\System-Test\";
        	} catch {
        		return "Error: Could not get OnBoardSimulatorFileLocation, please ensure you're running from the test suite level and that the variable is set";
        	}
        	
        	if (!System.IO.Directory.Exists(onBoardSimulatorFileLocation))
            {
        		return "Error: Directory does not exist for Onboard scripts {" + onBoardSimulatorFileLocation + "}.";
        	}
        	
        	string stopSimulatorPath = onBoardSimulatorFileLocation + @"simulators-stop.bat";
        	string startSimulatorPath = onBoardSimulatorFileLocation + @"simulators-start.bat";
        	
        	if (!System.IO.File.Exists(startSimulatorPath) || !System.IO.File.Exists(stopSimulatorPath))
        	{
        		return "Error: Missing Onboard scripts simulators-start.bat and/or simulators-stop.bat";
        	}
        	
        	Report.Info("Stopping the OnBoard Apps");
        	RunSimulatorStopScript(onBoardSimulatorFileLocation);
        	Ranorex.Delay.Seconds(10);
        	
        	//Checking if any process still running
        	
        	Process [] processes = System.Diagnostics.Process.GetProcesses();
        	
        	foreach(var process in processes)
        	{
        		if(!String.IsNullOrEmpty(process.MainWindowTitle))
        		{
        			if(process.MainWindowTitle.Contains("Loco") || process.MainWindowTitle.Contains("Debug Client") || process.MainWindowTitle.Contains("CDU-1")
        			   || process.MainWindowTitle.Contains("emp_router") || process.MainWindowTitle.Contains("Office 3.0")
        			   || process.MainWindowTitle.Contains("Wayside Simulator") || process.MainWindowTitle.Contains("IOC Simulator")
        			   || process.MainWindowTitle.Contains("Wayside Network Server"))
        			{
        				Report.Info("Process still running: "+process.MainWindowTitle.ToString());
        				process.Kill();
        				Ranorex.Report.Info("Killing Process:"+process.MainWindowTitle.ToString());
        				Ranorex.Delay.Seconds(5);
        			}
        		}
        		
        	}
        	
        	Report.Info("Starting the OnBoard Apps");
        	RunSimulatorStartScript(onBoardSimulatorFileLocation);
        	
        	//Check that we are first slice
        	
        	RecursiveSetSlice1ToPrimary(onBoardSimulatorFileLocation);
            
            return "Info: Onboard simulators have been started and Onboard is Slice 1";
        }
        
        /// <summary>
        /// Adjust the amount the Onboard Simulator is zoomed (Default: 100)
        /// Performs OCR on the Loco screen, then returns the zoom to the previous setting
        /// </summary>
        [UserCodeMethod]
        public static string OCRValidation_OnBoard(string validationText, string functionalArea = "Full", string zoom = "100", string validateExists = "true")
        {
            bool validateExistsBool = true;
            if (!bool.TryParse(validateExists, out validateExistsBool))
            {
                return "Error: OCRValidation_Loco got a validateExists value of {"+ validateExists + "} which could not be converted into a bool";
            }
            
            validationText = validationText.Replace('Z', '2');
            validationText = validationText.Replace("2", "[Z27]");
            validationText = validationText.Replace("f", "[ff`t]");
            validationText = validationText.Replace("o", "[oa]");
            validationText = validationText.Replace('n', 'm');
            validationText = validationText.Replace("m", "[mn]");
            validationText = validationText.Replace("c", "[ce]");
            validationText = validationText.Replace('4', 'A');
            validationText = validationText.Replace("A", "[AR4]");
            validationText = validationText.Replace("U", "[UV]");
            validationText = validationText.Replace('0', 'O');
            validationText = validationText.Replace("O", "[O0D]");
            validationText = validationText.Replace("G", "[6G]");
            validationText = validationText.Replace('5', 'S');
            validationText = validationText.Replace('8', 'S');
            validationText = validationText.Replace("S", "[58Ss]");
            validationText = validationText.Replace("C", "[Cc]");
            validationText = validationText.Replace("T", "[TI]");
            
            string tesseractLocation = @"Tesseract\Tesseract.exe";
            string tempImage = "tempImage.bmp";
            string ocrText = "";
            Report.Info("Validation Text: "+validationText.ToString());
            if (!System.IO.File.Exists(tesseractLocation))
            {
            	Ranorex.Report.Failure("Can't find Tesseract Location");
                return "Failure: Could not find Tesseract.exe";
            }
            
            List<string> validationTexts = validationText.Split(',').ToList();
            
            OnBoardRepo.Onboard_Form.Self.EnsureVisible();
            string zoomBeforeChange = currentZoom.ToString();
            if(!currentZoom.ToString().Equals(zoom))
            {
            	SetOnboardZoom_OnBoard(zoom);	
            }
            
            
            Bitmap bmp = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            Report.Info(bmp.Width.ToString());
            float xPercent = 4.175f;
            float yPercent = 5.5f;
            Bitmap bmp2;
            Graphics testGraphic;
            switch (functionalArea)
            {
            	case "topBanner":
            		bmp2 = bmp.Clone(topBannerRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), topBannerRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 10f;
		        	yPercent = 1f;
		        	break;
		        case "depart":
            		bmp2 = bmp.Clone(departRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), departRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
//		        	xPercent = 7f;
//		        	yPercent = 1f;
		        	break;
		        case "mainScreen":
            		bmp2 = bmp.Clone(mainScreenRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 5f;
		        	yPercent = 6f;
		        	break;
		        	
		        case "locoNumber":
		        	Rectangle locoNumberRectangle = new Rectangle(new Point(550, 70), new Size(100, 40));
            		bmp2 = bmp.Clone(locoNumberRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(550, 70, 100, 40), locoNumberRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;

				case "mainScreenAuthorityDetails":
		        	Rectangle mainScreenAuthorityDetailsRectangle = new Rectangle(new Point(15, 178), new Size(520, 349));
            		bmp2 = bmp.Clone(mainScreenAuthorityDetailsRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.DrawImage(bmp, new Rectangle(0,0,bmp.Width,bmp.Height), mainScreenAuthorityDetailsRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 5f;
		        	yPercent = 6f;
		        	break;
		        	
				//Get the Line 2 or Line 3 Limits without Line 1 void
				case "mainScreenAuthorityLine2":
		        	Rectangle mainScreenAuthorityLine2ContentRectangle = new Rectangle(new Point(20, 256), new Size(300, 35));
            		bmp2 = bmp.Clone(mainScreenAuthorityLine2ContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 35), mainScreenAuthorityLine2ContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        
				//This can be used when line 2 and 3 or line 3 and 4 are there on track authority		        	
		        case "mainScreenAuthorityLine23":
		        	Rectangle mainScreenAuthorityLine23Rectangle = new Rectangle(new Point(20, 256), new Size(320, 90));
            		bmp2 = bmp.Clone(mainScreenAuthorityLine23Rectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 35), mainScreenAuthorityLine23Rectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        
		        		        	
		        case "mainScreenFlashFloodDetails":
		        	Rectangle mainScreenFlashFloodRectangle = new Rectangle(new Point(20, 206), new Size(320, 150));
            		bmp2 = bmp.Clone(mainScreenFlashFloodRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 35), mainScreenFlashFloodRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "mainScreenTOOSDetails":
		        	Rectangle mainScreenTOSRectangle = new Rectangle(new Point(20, 221), new Size(380, 150));
            		bmp2 = bmp.Clone(mainScreenTOSRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 35), mainScreenTOSRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "mainScreenRustyRailDetails":
		        	Rectangle mainScreenRRRectangle = new Rectangle(new Point(20, 190), new Size(380, 150));
            		bmp2 = bmp.Clone(mainScreenRRRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 190, 380, 150), mainScreenRRRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "mainScreenBadFootingPointDetails":
		        	Rectangle mainScreenBFPRectangle = new Rectangle(new Point(20, 201), new Size(400, 150));
            		bmp2 = bmp.Clone(mainScreenBFPRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 202, 400, 150), mainScreenBFPRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "mainScreenFuelDetails":
		        	Rectangle mainScreenFuelRectangle = new Rectangle(new Point(20, 250), new Size(400, 100));
            		bmp2 = bmp.Clone(mainScreenFuelRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 250, 400, 100), mainScreenFuelRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "locoDetails":
		        	Rectangle locoRectangle = new Rectangle(new Point(180, 420), new Size(60, 40));
            		bmp2 = bmp.Clone(locoRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(180, 420, 60, 40), locoRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		        case "mainScreenAuxSpeedDetails":
		        	Rectangle mainScreenAuxSpeedRectangle = new Rectangle(new Point(20, 195), new Size(400, 150));
            		bmp2 = bmp.Clone(mainScreenAuxSpeedRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 195, 400, 150), mainScreenAuxSpeedRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
				//Get the Line 2 or Line 3 Track Name		        	
		        case "mainScreenAuthorityLine2Track":
		        	Rectangle AuthorityLine2MainContentRectangle = new Rectangle(new Point(20, 256), new Size(300, 45));
            		bmp2 = bmp.Clone(AuthorityLine2MainContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 45), AuthorityLine2MainContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
				//2. Proceed fram SC60 to scat ==> 2. Proceed from SC60 to SC34.. It is with line 1 void
				case "mainScreenAuthorityLine2WithLine1":
		        	Rectangle mainScreenAuthorityLine21ContentRectangle = new Rectangle(new Point(20, 272), new Size(155, 35));
            		bmp2 = bmp.Clone(mainScreenAuthorityLine21ContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(20, 272, 155, 35), mainScreenAuthorityLine21ContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 2.50f;
		        	yPercent = 1f;
		        	break;
		        	
		       case "mainScreenAuthorityRollup":
            		bmp2 = bmp.Clone(mainScreenAuthorityRollupLocationContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenAuthorityRollupLocationContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        	
//		        case "mainScreenAuthorityRollup1":
//		        	Rectangle mainScreenAuthorityRollRectangle = new Rectangle(new Point(15, 378), new Size(150, 20));
//            		bmp2 = bmp.Clone(mainScreenAuthorityRollRectangle, bmp.PixelFormat);
//            		testGraphic = Graphics.FromImage(bmp2);
//            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
//            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
//		        	testGraphic.DrawImage(bmp, new Rectangle(15, 378, 150, 20), mainScreenAuthorityRollRectangle, GraphicsUnit.Pixel);
//		        	bmp = bmp2;
//		        	xPercent = 4.175f;
//		        	yPercent = 2f;
//		        	break;
		        
		        //using when line 2&3 along with line 10 present or line 3&4 along with line10 present
		        case "mainScreenAuthorityBox10":
		        	Rectangle mainScreenAuthorityBox10Rectangle = new Rectangle(new Point(15, 347), new Size(345, 57));
            		bmp2 = bmp.Clone(mainScreenAuthorityBox10Rectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(15, 347, 345, 57), mainScreenAuthorityBox10Rectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 2.5f;
		        	break;
		        	
		        case "mainScreenIllinoisFormBLocation1":
		        	Rectangle mainScreenIllinoisFormBRectangle = new Rectangle(new Point(15, 360), new Size(360, 37));
            		bmp2 = bmp.Clone(mainScreenIllinoisFormBRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(15, 360, 360, 57), mainScreenIllinoisFormBRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 2.5f;
		        	break;
		        	
		        case "mainScreenIllinoisFormBLocation2":
		        	Rectangle mainScreenIllinoisFormBLoc2Rectangle = new Rectangle(new Point(15, 380), new Size(45, 20));
            		bmp2 = bmp.Clone(mainScreenIllinoisFormBLoc2Rectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(15, 380, 45, 20), mainScreenIllinoisFormBLoc2Rectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 2.5f;
		        	break;
		        
		        //Using when line 2 and line 10 present
		        case "mainScreenAuthorityBox210":
//		        	Rectangle mainScreenAuthorityBox210Rectangle = new Rectangle(new Point(15, 310), new Size(350, 47));
		        	Rectangle mainScreenAuthorityBox210Rectangle = new Rectangle(new Point(15, 0), new Size(350, 357));
            		bmp2 = bmp.Clone(mainScreenAuthorityBox210Rectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(15, 0, 350, 357), mainScreenAuthorityBox210Rectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 2f;
		        	break;
		        	
		        case "mainScreenNextTarget":
		        	Rectangle mainScreenNxtTargetRectangle = new Rectangle(new Point(150, 325), new Size(bmp.Width-150, 150));
            		bmp2 = bmp.Clone(mainScreenNxtTargetRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenNxtTargetRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        
		        case "mainScreenNextTargetText":
		        	Rectangle mainScreenNxtTargetRectangleText = new Rectangle(new Point(30, 275), new Size(bmp.Width-30, 250));
		        	bmp2 = bmp.Clone(mainScreenNxtTargetRectangleText, bmp.PixelFormat);
		        	testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.SmoothingMode = SmoothingMode.HighQuality;
		        	testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		        	testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenNxtTargetRectangleText, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;

		        	//This verifies NEXT TARGET: SPEED
		        case "mainScreenNextTargetSpeedText":
		        	Rectangle mainScreenNxtTargetSpeedRec = new Rectangle(new Point(300, 285), new Size(bmp.Width-300, 215));
		        	bmp2 = bmp.Clone(mainScreenNxtTargetSpeedRec, bmp.PixelFormat);
		        	testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.SmoothingMode = SmoothingMode.HighQuality;
		        	testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		        	testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenNxtTargetSpeedRec, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        	
		        case "mainScreenNextTargetMPHText":
		        	//Rectangle mainScreenNxtTargetMPHRec = new Rectangle(new Point(450, 275), new Size(183, 135));
		        	Rectangle mainScreenNxtTargetMPHRec = new Rectangle(new Point(405, 285), new Size(188, 125));
		        	bmp2 = bmp.Clone(mainScreenNxtTargetMPHRec, bmp.PixelFormat);
		        	testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.SmoothingMode = SmoothingMode.HighQuality;
		        	testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		        	testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(405, 285, 188, 125), mainScreenNxtTargetMPHRec, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
		        	break;
		        
		        //NEXT TARGET; AUTH Omph
		        case "mainScreenNextTargetAuthText":
		        	Rectangle mainScreenNxtTargetAuthRec = new Rectangle(new Point(50, 275), new Size(bmp.Width-60, 220));
		        	bmp2 = bmp.Clone(mainScreenNxtTargetAuthRec, bmp.PixelFormat);
		        	testGraphic = Graphics.FromImage(bmp2);
		        	testGraphic.SmoothingMode = SmoothingMode.HighQuality;
		        	testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		        	testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenNxtTargetAuthRec, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        	
				case "mainScreenBulletinMPValidations":
		        	Rectangle mainScreenBulletinMPContentRectangle = new Rectangle(new Point(15, 158), new Size(450, 249));
            		bmp2 = bmp.Clone(mainScreenBulletinMPContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenBulletinMPContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        	
		        case "mainScreenBulletin":
		        	Rectangle mainScreenBulletinContentRectangle = new Rectangle(new Point(15, 158), new Size(500, 249));
            		bmp2 = bmp.Clone(mainScreenBulletinContentRectangle, bmp.PixelFormat);
            		testGraphic = Graphics.FromImage(bmp2);
            		testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            		testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            		testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
		        	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenBulletinContentRectangle, GraphicsUnit.Pixel);
		        	bmp = bmp2;
		        	xPercent = 4.175f;
		        	yPercent = 7f;
		        	break;
		        
		        default:
                    //default will do full shot of onBoard
                    break;
            }
            
            
            //We need to write the image for tesseract to read it.
            bmp.Save(tempImage);
            
            Process tesseractProcess = new Process();
            tesseractProcess.StartInfo.UseShellExecute = false;
            tesseractProcess.StartInfo.RedirectStandardOutput = true;
            tesseractProcess.StartInfo.RedirectStandardError = true;
            tesseractProcess.StartInfo.Arguments = @"""" + tempImage + @"""" + @" stdout -l eng";
            tesseractProcess.StartInfo.FileName = tesseractLocation;
            tesseractProcess.Start();
            
            ocrText = tesseractProcess.StandardOutput.ReadToEnd();
            string tesseractError = tesseractProcess.StandardError.ReadToEnd();
            tesseractProcess.WaitForExit(20000);
            
            ocrText = ocrText.Replace("\n", "");
            ocrText = ocrText.Replace("\r", " ");
            
            Ranorex.Report.Info(ocrText);
            Ranorex.Report.Info(tesseractError);
            Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
            
            List<string> resultsStringArray = new List<string>();
            List<string> validationTextsToRemove = new List<string>();
            foreach (string regexValue in validationTexts)
            {
                Regex newTestRegex = new Regex(@".*" + @regexValue + @".*");
                //Check if it exists
                bool regexExists = newTestRegex.IsMatch(ocrText);
                if (validateExistsBool && validateExistsBool == regexExists)
                {
                	resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                    Ranorex.Report.Success("Found text");
                    validationTextsToRemove.Add(@regexValue);
                    //validationTexts.Remove(@regexValue);
                } else if (!validateExistsBool)
                {
                    if (validateExistsBool == regexExists)
                    {
                        resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                    } else {
                        resultsStringArray.Add("Failure: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen, text found is {" + ocrText + "}.");
                    }
                    validationTextsToRemove.Add(@regexValue);
                }
            }
            
            if (!validationTextsToRemove.IsEmpty())
            {
            	foreach (string textToRemove in validationTextsToRemove)
            	{
            		validationTexts.Remove(textToRemove);
            	}
            	
            	validationTextsToRemove.Clear();
            }
            
            if (!validationTexts.IsEmpty())
            {
                //if all validations haven't passed, start image manipulation to make the text more legible
                bmp = ImageBinaryThresholding(bmp);
                
                //We need to write the image for tesseract to read it.
                bmp.Save(tempImage);
                
                tesseractProcess.Start();
            
                ocrText = tesseractProcess.StandardOutput.ReadToEnd();
                tesseractProcess.WaitForExit(20000);
                
                ocrText = ocrText.Replace("\n", "");
                ocrText = ocrText.Replace("\r", " ");
                
                Ranorex.Report.Info("After Image Thresholding: "+ocrText);
            	Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
                
                foreach (string regexValue in validationTexts)
                {
                    Regex newTestRegex = new Regex(@".*" + @regexValue + @".*");
                    //Check if it exists
                    bool regexExists = newTestRegex.IsMatch(ocrText);
                    if (validateExistsBool == regexExists)
                    {
                    	Ranorex.Report.Success("Found text");
                        resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                        validationTextsToRemove.Add(@regexValue);
                    }
                }
            }
            
            if (!validationTextsToRemove.IsEmpty())
            {
            	foreach (string textToRemove in validationTextsToRemove)
            	{
            		validationTexts.Remove(textToRemove);
            	}
            	
            	validationTextsToRemove.Clear();
            }
            
            if (!validationTexts.IsEmpty())
            {
                //if all validations haven't passed, start image manipulation to make the text more legible
                bmp = ImageBinaryThresholding(bmp);
                
                //We need to write the image for tesseract to read it.
                bmp.Save(tempImage);
                
                tesseractProcess.Start();
            
                ocrText = tesseractProcess.StandardOutput.ReadToEnd();
                tesseractProcess.WaitForExit(20000);
                
                ocrText = ocrText.Replace("\n", "");
                ocrText = ocrText.Replace("\r", " ");
                
                Ranorex.Report.Info("Image Thresholding 2nd time");
                Ranorex.Report.Info(ocrText);
            	Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
                
                foreach (string regexValue in validationTexts)
                {
                    Regex newTestRegex = new Regex(@".*" + @regexValue + @".*");
                    //Check if it exists
                    bool regexExists = newTestRegex.IsMatch(ocrText);
                    if (validateExistsBool == regexExists)
                    {
                    	Ranorex.Report.Success("Found text");
                        resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                        validationTextsToRemove.Add(@regexValue);
                    }
                }
            }
            
            if (!validationTextsToRemove.IsEmpty())
            {
            	foreach (string textToRemove in validationTextsToRemove)
            	{
            		validationTexts.Remove(textToRemove);
            	}
            	
            	validationTextsToRemove.Clear();
            }
            
            if (!validationTexts.IsEmpty())
            {
                //if all validations haven't passed, start image manipulation to make the text more legible
                bmp = ResizeImage(bmp, xPercent, yPercent);//, 4.175f, 5.5f);
                
                //We need to write the image for tesseract to read it.
                bmp.Save(tempImage);
                
                tesseractProcess.Start();
            
                ocrText = tesseractProcess.StandardOutput.ReadToEnd();
                tesseractProcess.WaitForExit(20000);
                
                ocrText = ocrText.Replace("\n", "");
                ocrText = ocrText.Replace("\r", " ");
                
                Ranorex.Report.Info(ocrText);
            	Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
                
                foreach (string regexValue in validationTexts)
                {
                    Regex newTestRegex = new Regex(@".*" + @regexValue + @".*");
                    Ranorex.Report.Info("String text: "+regexValue);
                    //Check if it exists
                    bool regexExists = newTestRegex.IsMatch(ocrText);

                    if (validateExistsBool == regexExists)
                    {
                    	Ranorex.Report.Success("Found text");
                        resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                        validationTextsToRemove.Add(@regexValue);
                    }
                }
            }
            
            if (!validationTextsToRemove.IsEmpty())
            {
            	foreach (string textToRemove in validationTextsToRemove)
            	{
            		validationTexts.Remove(textToRemove);
            	}
            	
            	validationTextsToRemove.Clear();
            }
            
            if (!validationTexts.IsEmpty())
            {
                //if all validations haven't passed, start image manipulation to make the text more legible
                bmp = ImageBinaryThresholding(bmp);
                
                //We need to write the image for tesseract to read it.
                bmp.Save(tempImage);
                
                tesseractProcess.Start();
            
                ocrText = tesseractProcess.StandardOutput.ReadToEnd();
                tesseractProcess.WaitForExit(20000);
                
                ocrText = ocrText.Replace("\n", "");
                ocrText = ocrText.Replace("\r", " ");
                
                Ranorex.Report.Info(ocrText);
            	Ranorex.Report.LogData(ReportLevel.Info, "Info", bmp);
                
                foreach (string regexValue in validationTexts)
                {
                    Regex newTestRegex = new Regex(@".*" + @regexValue + @".*");
                    //Check if it exists
                    bool regexExists = newTestRegex.IsMatch(ocrText);
                    if (validateExistsBool == regexExists)
                    {
                    	Ranorex.Report.Success("Found text");
                        resultsStringArray.Add("Success: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen");
                        validationTextsToRemove.Add(@regexValue);
                    } else {
                    	Ranorex.Report.Failure("Not `Found text");
                        resultsStringArray.Add("Failure: " + (regexExists ? "Found":"Did not find") + " Text {" + regexValue + "} on Onboard screen, text found is {" + ocrText + "}.");
                    }
                }
            }
            
            if (!validationTextsToRemove.IsEmpty())
            {
            	foreach (string textToRemove in validationTextsToRemove)
            	{
            		validationTexts.Remove(textToRemove);
            	}
            	
            	validationTextsToRemove.Clear();
            }
            
            System.IO.File.Delete(tempImage);
            bmp.Dispose();
            
            string returnString = string.Join("|", resultsStringArray);
            
            if(!currentZoom.ToString().Equals(zoomBeforeChange.ToString()))
            {
            	SetOnboardZoom_OnBoard(zoomBeforeChange);	
            }
            
            return returnString;
        }
        
        public static Bitmap ResizeImage(Image image, float widthFactor, float heightFactor)
        {
            int newWidth = (int)(image.Width * widthFactor);
            int newHeight = (int)(image.Width * heightFactor);
            Rectangle destRect = new Rectangle(0, 0, newWidth, newHeight);
            Bitmap destImage = new Bitmap(newWidth, newHeight);
            
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            
            using (var graphics =Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            
            return destImage;
        }
        
        public static Bitmap ImageBinaryThresholding(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            Color p;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = image.GetPixel(x, y);
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    avg = avg < 170 ? 255 : 0;
                    image.SetPixel(x, y, Color.FromArgb(p.A, avg, avg, avg));
                }
            }
            return image;
        }
        
       	        /// <summary>
        /// Validates a fence color is on the onboard, either horizontal (x pixels by 1 pixel) or vertical (3 pixels by y pixels)
        /// </summary>
        [UserCodeMethod]
        public static string ValidateMPColorValidation(string milePost, string milePostOffset, string y_offset, string direction, string fenceOrTrackPositions, string color)
        {
        	//OnBoard Current Size is 656x539
            //Get current zoom if not 100, since we don't want to calculate these numbers for each kind of zoom
            int foundZoom = currentZoom;
            if (foundZoom != 100)
            {
                SetOnboardZoom_OnBoard("100");
            }
            
            float milePostFloat;
            if (!float.TryParse(milePost, out milePostFloat))
            {
                return "Error: Could not convert milepost {" + milePost + "} into a float";
            }
            
            int y_offsetValue = 0;
            if (!Int32.TryParse(y_offset, out y_offsetValue))
            {
                return "Error: Could not convert y_offset {" + y_offset + "} into a int";
            }
            
            milePostOffset = (milePostOffset == "" ? "0" : milePostOffset);
            
            float milePostOffsetFloat;
            if (!float.TryParse(milePostOffset, out milePostOffsetFloat))
            {
                return "Error: Could not convert milepost offset {" + milePostOffset + "} into a float";
            }
            
            bool upbound = false;
            if (direction.ToLower().Contains("up"))
            {
                upbound = true;
            }
            
            float totalMilepost = milePostFloat + milePostOffsetFloat;
            
            
            //Onboard shows a total of 6.4 miles
            //Distance to the edge of the train on the onboard is 1.42 miles
            
            //So current train position gives us the total, but we need to know whether we're upBound or downBound for the mileposts
            Bitmap onBoardBmp = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            string currentMilePostNumber = OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue.Trim();
            Report.Info("Current MP: "+currentMilePostNumber);
            string currentMilePostString = "";
            for (int i = 0; i<currentMilePostNumber.Length;i++)
            {
            	if(!Char.IsLetter(currentMilePostNumber[i]))
            	{
            		currentMilePostString += currentMilePostNumber[i];
            	}
            }
            
            float currentMilePostFloat;
            if (!float.TryParse(currentMilePostString, out currentMilePostFloat))
            {
                return "Error: Could not convert current milepost {" + currentMilePostString + "} into a float";
            }
            
            
            //From here, we have the time sensitive information
            Bitmap mainScreenBmp = onBoardBmp.Clone(mainScreenRectangle, onBoardBmp.PixelFormat);
    		Graphics mainScreenGraphic = Graphics.FromImage(mainScreenBmp);
        	mainScreenGraphic.DrawImage(onBoardBmp, new Rectangle(0, 0, onBoardBmp.Width, onBoardBmp.Height), mainScreenRectangle, GraphicsUnit.Pixel);
        	
        	//Now lets get the beginning and end mileposts
        	float beginningMilepost;
        	float endMilepost;
        	float percentageOfTotal;
        	float totalLength = 6.4f;
        	float lengthToTrain = 1.42f;

        	if (upbound)
        	{
        	    beginningMilepost = currentMilePostFloat - lengthToTrain;
        	    endMilepost = beginningMilepost + totalLength;
        	    percentageOfTotal = ((totalMilepost - beginningMilepost)/totalLength);
        	} else {
        	    beginningMilepost = currentMilePostFloat + lengthToTrain;
        	    endMilepost = beginningMilepost - totalLength;
        	    percentageOfTotal = ((beginningMilepost - totalMilepost)/totalLength);
        	}
        	
        	//Now to use the percentages to take a slice of the onboard screen
        	//We do a -1 here because we want the box to be about 3 pixels wide, maybe?
        	int xPixelStart = (int)((float)mainScreenBmp.Width * percentageOfTotal) - 1;
            int xPixelEnd = 10;
//            int yPixelStart = 0;
//            int yPixelEnd = mainScreenBmp.Height-200;

//****************************************************
//            Ranorex.Report.Info("Y: "+yPixelEnd.ToString());
//            Rectangle sliceRectangle = new Rectangle(new Point(xPixelStart, 190), new Size(10, 349));
//            Bitmap sliceBmp = mainScreenBmp.Clone(sliceRectangle, onBoardBmp.PixelFormat);
//    		Graphics sliceGraphic = Graphics.FromImage(sliceBmp);
//    		
//			Report.LogData(ReportLevel.Info, "OnBoard", onBoardBmp);
//    		Report.LogData(ReportLevel.Info, "Main Screen", mainScreenBmp);
//    		Report.LogData(ReportLevel.Info, "Slice Screen", sliceBmp);
//        	sliceGraphic.DrawImage(mainScreenBmp, new Rectangle(0, 0, mainScreenBmp.Width, mainScreenBmp.Height), sliceRectangle, GraphicsUnit.Pixel);

			HashSet<Color> colorsFound = new HashSet<Color>();
			for (int j = 190+y_offsetValue; j<349-y_offsetValue; j++) {
                for (int i = xPixelStart; i<xPixelStart+10; i++) {
                    Color pixelColor = onBoardBmp.GetPixel(i,j);
                    if (!colorsFound.Contains(pixelColor))
                    {
                        colorsFound.Add(pixelColor);
                        Report.Info("Color Added: "+pixelColor.ToString());
                    }
                }
            }


        	Color fenceColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
        	
        	//colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(sliceBmp);
        	bool colorInHashSet = colorsFound.Contains(fenceColor);
        	
        	string imageColorsString = string.Join(", ", colorsFound);
        	Report.Info("Image Colors: "+imageColorsString);
        	Report.Info("Color Expected: "+fenceColor.ToString());
        	
        	if (foundZoom != 100)
            {
                //Change zoom back to zoom before function
                SetOnboardZoom_OnBoard(foundZoom.ToString());
            }
        	
        	if (colorInHashSet)
        	{
        		Report.Success("Success");
        		return "Success: Found fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	} else {
        		Report.Failure("Failure");
        	    return "Failure: Did not find fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	}
//        	
//            //This section COULD be used to changed the value of the y in order to get different length of image slices depending on the fence size.
//            //Not sure what the benefit is to that though.
//            switch (fenceOrTrackPositions.ToLower())
//            {
//                case "track_y":
//                case "vertical":
//                    //startPointY = 0;
//                    break;
//                    
//                case "fence_y1":
//                    //TODO Set fence y1 startPointY
//                    break;
//                    
//                case "fence_y2":
//                    //TODO Set fence y2 startPointY
//                    break;
//                    
//                case "fence_y3":
//                    //TODO Set fence y3 startPointY
//                    break;
//                    
//                default:
//                    return "Error: Fence or Track position of {" + fenceOrTrackPositions + "} has not been made, check spelling";
//            }
            
            //tracklineRectangle
        }

        /// <summary>
        /// Validates a fence color is on the onboard, either horizontal (x pixels by 1 pixel) or vertical (3 pixels by y pixels)
        /// </summary>
        [UserCodeMethod]
        public static string ValidateNoFenceColor_OnBoard(string milePost, string milePostOffset, string direction, string fenceOrTrackPositions, string color)
        {
        	//OnBoard Current Size is 656x539
            //Get current zoom if not 100, since we don't want to calculate these numbers for each kind of zoom
            int foundZoom = currentZoom;
            if (foundZoom != 100)
            {
                SetOnboardZoom_OnBoard("100");
            }
            
            float milePostFloat = 0f;
            if (!float.TryParse(milePost, out milePostFloat))
            {
                return "Error: Could not convert milepost {" + milePost + "} into a float";
            }
            
            milePostOffset = (milePostOffset == "" ? "0" : milePostOffset);
            
            float milePostOffsetFloat;
            if (!float.TryParse(milePostOffset, out milePostOffsetFloat))
            {
                return "Error: Could not convert milepost offset {" + milePostOffset + "} into a float";
            }
            
            bool upbound = false;
            if (direction.ToLower().Contains("up"))
            {
                upbound = true;
            }
            
            float totalMilepost = milePostFloat + milePostOffsetFloat;
            
            
            //Onboard shows a total of 6.4 miles
            //Distance to the edge of the train on the onboard is 1.42 miles
            
            //So current train position gives us the total, but we need to know whether we're upBound or downBound for the mileposts
            Bitmap onBoardBmp = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            string currentMilePostNumber = OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue.Trim();
            Report.Info("Current MP: "+currentMilePostNumber);
            string currentMilePostString = "";
            for (int i = 0; i<currentMilePostNumber.Length;i++)
            {
            	if(!Char.IsLetter(currentMilePostNumber[i]))
            	{
            		currentMilePostString += currentMilePostNumber[i];
            	}
            }
            
            float currentMilePostFloat;
            if (!float.TryParse(currentMilePostString, out currentMilePostFloat))
            {
                return "Error: Could not convert current milepost {" + currentMilePostString + "} into a float";
            }
            
            
            //From here, we have the time sensitive information
            Bitmap mainScreenBmp = onBoardBmp.Clone(mainScreenRectangle, onBoardBmp.PixelFormat);
    		Graphics mainScreenGraphic = Graphics.FromImage(mainScreenBmp);
        	mainScreenGraphic.DrawImage(onBoardBmp, new Rectangle(0, 0, onBoardBmp.Width, onBoardBmp.Height), mainScreenRectangle, GraphicsUnit.Pixel);
        	
        	//Now lets get the beginning and end mileposts
        	float beginningMilepost = 0f;
        	float endMilepost = 0f;
        	float percentageOfTotal = 0f;
        	float totalLength = 6.4f;
        	float lengthToTrain = 1.42f;

        	if (upbound)
        	{
        	    beginningMilepost = currentMilePostFloat - lengthToTrain;
        	    endMilepost = beginningMilepost + totalLength;
        	    percentageOfTotal = ((totalMilepost - beginningMilepost)/totalLength);
        	} else {
        	    beginningMilepost = currentMilePostFloat + lengthToTrain;
        	    endMilepost = beginningMilepost - totalLength;
        	    percentageOfTotal = ((beginningMilepost - totalMilepost)/totalLength);
        	}
        	
        	//Now to use the percentages to take a slice of the onboard screen
        	//We do a -1 here because we want the box to be about 3 pixels wide, maybe?
        	int xPixelStart = (int)((float)mainScreenBmp.Width * percentageOfTotal) - 1;
            int xPixelEnd = 3;
            
            //interim y
//            int yPixelStart = 0;
//            int yPixelEnd = mainScreenBmp.Height - 1;
//            int yPixelStart = 70;
//            int yPixelEnd = 140;
            
//************Fence Y Co-ordinates********************            
            int yPixelStart = 0;
            int yPixelEnd = mainScreenBmp.Height-200;

//****************************************************
//            Ranorex.Report.Info("Y: "+yPixelEnd.ToString());
//            Rectangle sliceRectangle = new Rectangle(new Point(xPixelStart, yPixelStart), new Size(xPixelEnd, yPixelEnd));
//            Bitmap sliceBmp = mainScreenBmp.Clone(sliceRectangle, onBoardBmp.PixelFormat);
//    		Graphics sliceGraphic = Graphics.FromImage(sliceBmp);
//    		
//			Report.LogData(ReportLevel.Info, "OnBoard", onBoardBmp);
//    		Report.LogData(ReportLevel.Info, "Main Screen", mainScreenBmp);
//    		Report.LogData(ReportLevel.Info, "Slice Screen", sliceBmp);
//        	sliceGraphic.DrawImage(mainScreenBmp, new Rectangle(0, 0, mainScreenBmp.Width, mainScreenBmp.Height), sliceRectangle, GraphicsUnit.Pixel);

			HashSet<Color> colorsFound = new HashSet<Color>();
			for (int j = 230; j<349; j++) {
                for (int i = xPixelStart; i<xPixelStart+3; i++) {
                    Color pixelColor = onBoardBmp.GetPixel(i,j);
                    if (!colorsFound.Contains(pixelColor))
                    {
                        colorsFound.Add(pixelColor);
                    }
                }
            }


        	Color fenceColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
        	
        	//colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(sliceBmp);
        	bool colorInHashSet = true;
        	colorInHashSet = colorsFound.Contains(fenceColor);
        	
        	string imageColorsString = string.Join(", ", colorsFound);
        	Report.Info("Color found?"+colorInHashSet.ToString());
        	Report.Info("Image Colors: "+imageColorsString);
        	Report.Info("Color Expected: "+fenceColor.ToString());
        	
        	if (foundZoom != 100)
            {
                //Change zoom back to zoom before function
                SetOnboardZoom_OnBoard(foundZoom.ToString());
            }
        	colorsFound.Clear();
        	onBoardBmp.Dispose();
        	mainScreenBmp.Dispose();
        	
        	if (!colorInHashSet)
        	{
        		Report.Success("Success");
        		colorInHashSet = true;
        		return "Success: Did not find fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	} else {
        		Report.Failure("Failure");
        	    return "Failure: Found fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	}
//        	
//            //This section COULD be used to changed the value of the y in order to get different length of image slices depending on the fence size.
//            //Not sure what the benefit is to that though.
//            switch (fenceOrTrackPositions.ToLower())
//            {
//                case "track_y":
//                case "vertical":
//                    //startPointY = 0;
//                    break;
//                    
//                case "fence_y1":
//                    //TODO Set fence y1 startPointY
//                    break;
//                    
//                case "fence_y2":
//                    //TODO Set fence y2 startPointY
//                    break;
//                    
//                case "fence_y3":
//                    //TODO Set fence y3 startPointY
//                    break;
//                    
//                default:
//                    return "Error: Fence or Track position of {" + fenceOrTrackPositions + "} has not been made, check spelling";
//            }
            
            //tracklineRectangle
        }
        
        /// <summary>
        /// Validates a fence color is on the onboard, either horizontal (x pixels by 1 pixel) or vertical (3 pixels by y pixels)
        /// </summary>
        [UserCodeMethod]
        public static string ValidateFenceColor_OnBoard(string milePost, string milePostOffset, string direction, string fenceOrTrackPositions, string color)
        {
        	//OnBoard Current Size is 656x539
            //Get current zoom if not 100, since we don't want to calculate these numbers for each kind of zoom
            int foundZoom = currentZoom;
            if (foundZoom != 100)
            {
                SetOnboardZoom_OnBoard("100");
            }
            
            float milePostFloat = 0f;
            if (!float.TryParse(milePost, out milePostFloat))
            {
                return "Error: Could not convert milepost {" + milePost + "} into a float";
            }
            
            milePostOffset = (milePostOffset == "" ? "0" : milePostOffset);
            
            float milePostOffsetFloat;
            if (!float.TryParse(milePostOffset, out milePostOffsetFloat))
            {
                return "Error: Could not convert milepost offset {" + milePostOffset + "} into a float";
            }
            
            bool upbound = false;
            if (direction.ToLower().Contains("up"))
            {
                upbound = true;
            }
            
            float totalMilepost = milePostFloat + milePostOffsetFloat;
            
            
            //Onboard shows a total of 6.4 miles
            //Distance to the edge of the train on the onboard is 1.42 miles
            
            //So current train position gives us the total, but we need to know whether we're upBound or downBound for the mileposts
            Bitmap onBoardBmp = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            string currentMilePostNumber = OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue.Trim();
            Report.Info("Current MP: "+currentMilePostNumber);
            string currentMilePostString = "";
            for (int i = 0; i<currentMilePostNumber.Length;i++)
            {
            	if(!Char.IsLetter(currentMilePostNumber[i]))
            	{
            		currentMilePostString += currentMilePostNumber[i];
            	}
            }
            
            float currentMilePostFloat;
            if (!float.TryParse(currentMilePostString, out currentMilePostFloat))
            {
                return "Error: Could not convert current milepost {" + currentMilePostString + "} into a float";
            }
            
            
            //From here, we have the time sensitive information
            Bitmap mainScreenBmp = onBoardBmp.Clone(mainScreenRectangle, onBoardBmp.PixelFormat);
    		Graphics mainScreenGraphic = Graphics.FromImage(mainScreenBmp);
        	mainScreenGraphic.DrawImage(onBoardBmp, new Rectangle(0, 0, onBoardBmp.Width, onBoardBmp.Height), mainScreenRectangle, GraphicsUnit.Pixel);
        	
        	//Now lets get the beginning and end mileposts
        	float beginningMilepost = 0f;
        	float endMilepost = 0f;
        	float percentageOfTotal = 0f;
        	float totalLength = 6.4f;
        	float lengthToTrain = 1.42f;

        	if (upbound)
        	{
        	    beginningMilepost = currentMilePostFloat - lengthToTrain;
        	    endMilepost = beginningMilepost + totalLength;
        	    percentageOfTotal = ((totalMilepost - beginningMilepost)/totalLength);
        	}
        	else
        	{
        		beginningMilepost = currentMilePostFloat + lengthToTrain;
        	    endMilepost = beginningMilepost - totalLength;
        	    percentageOfTotal = ((beginningMilepost - totalMilepost)/totalLength);
        	}
        	
        	//Now to use the percentages to take a slice of the onboard screen
        	//We do a -1 here because we want the box to be about 3 pixels wide, maybe?
        	int xPixelStart = (int)((float)mainScreenBmp.Width * percentageOfTotal) - 1;
            int xPixelEnd = 3;
            
            //interim y
//            int yPixelStart = 0;
//            int yPixelEnd = mainScreenBmp.Height - 1;
//            int yPixelStart = 70;
//            int yPixelEnd = 140;
            
//************Fence Y Co-ordinates********************            
//            int yPixelStart = 60;
//            int yPixelEnd = mainScreenBmp.Height-200;

			int yPixelStart = 220;
            int yPixelEnd = 119;

//****************************************************
//            Ranorex.Report.Info("Y: "+yPixelEnd.ToString());
//            Rectangle sliceRectangle = new Rectangle(new Point(xPixelStart, yPixelStart), new Size(10, yPixelEnd));
//            Bitmap sliceBmp = onBoardBmp.Clone(sliceRectangle, onBoardBmp.PixelFormat);
//    		Graphics sliceGraphic = Graphics.FromImage(sliceBmp);
////    		
//			Report.LogData(ReportLevel.Info, "OnBoard", onBoardBmp);
//	   		Report.LogData(ReportLevel.Info, "Main Screen", mainScreenBmp);
//    		Report.LogData(ReportLevel.Info, "Slice Screen", sliceBmp);
//        	sliceGraphic.DrawImage(mainScreenBmp, new Rectangle(0, 0, mainScreenBmp.Width, mainScreenBmp.Height), sliceRectangle, GraphicsUnit.Pixel);

			HashSet<Color> colorsFound = new HashSet<Color>();
			for (int j = 220; j<319; j++) {
                for (int i = xPixelStart; i<xPixelStart+10; i++) {
                    Color pixelColor = onBoardBmp.GetPixel(i,j);
                    if (!colorsFound.Contains(pixelColor))
                    {
                        colorsFound.Add(pixelColor);
                    }
                }
            }


        	Color fenceColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
        	
        	//colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(sliceBmp);
        	bool colorInHashSet = colorsFound.Contains(fenceColor);
        	
        	string imageColorsString = string.Join(", ", colorsFound);
        	Report.Info("Image Colors: "+imageColorsString);
        	Report.Info("Color Expected: "+fenceColor.ToString());
        	
        	if (foundZoom != 100)
            {
                //Change zoom back to zoom before function
                SetOnboardZoom_OnBoard(foundZoom.ToString());
            }
        	colorsFound.Clear();
        	onBoardBmp.Dispose();
        	mainScreenBmp.Dispose();
        	if (colorInHashSet)
        	{
        		Report.Success("Success");
        		colorInHashSet = false;
        		return "Success: Found fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	} else {
        		Report.Failure("Failure");
        	    return "Failure: Did not find fence color {" + color + "} at milepost {" + milePostFloat.ToString() + "} on the onBoard screen";
        	}
//        	
//            //This section COULD be used to changed the value of the y in order to get different length of image slices depending on the fence size.
//            //Not sure what the benefit is to that though.
//            switch (fenceOrTrackPositions.ToLower())
//            {
//                case "track_y":
//                case "vertical":
//                    //startPointY = 0;
//                    break;
//                    
//                case "fence_y1":
//                    //TODO Set fence y1 startPointY
//                    break;
//                    
//                case "fence_y2":
//                    //TODO Set fence y2 startPointY
//                    break;
//                    
//                case "fence_y3":
//                    //TODO Set fence y3 startPointY
//                    break;
//                    
//                default:
//                    return "Error: Fence or Track position of {" + fenceOrTrackPositions + "} has not been made, check spelling";
//            }
            
            //tracklineRectangle
        }
        
        [UserCodeMethod]
        public static string ValidateTopBannerColor_OnBoard(string color, string colorExists)
        {
        	//Setting default value as True
        	bool validateColorExist = true;
        	if(!Boolean.TryParse(colorExists, out validateColorExist))
        	{
        		return "Failure: Please pass a valid colorExist value either True or False, current value:"+colorExists+".";
        	}
        	
        	HashSet<Color> colorsFound = new HashSet<Color>();
            Color expectedColor =  PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);

            Bitmap itemImage = Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
                	
            for (int j = 117; j<237; j++) {
                for (int i = 113; i<600; i++) {
                    Color pixelColor = itemImage.GetPixel(i,j);
                    if (!colorsFound.Contains(pixelColor))
                    {
                        colorsFound.Add(pixelColor);
                    }
                }
            }

            
            string notFoundColorsString = string.Join(", ", expectedColor);
            string imageColorsString = string.Join(", ", colorsFound);
            
			if(colorsFound.Contains(expectedColor) == validateColorExist)
			{
            	Report.Success("Found Color in the start");
            	itemImage.Dispose();
            	Report.Info("Colors found: "+imageColorsString);
            	return "Success: Color Found?"+validateColorExist.ToString()+" is validated";
                
            }
            
            Report.Failure("Color Not found in Top Banner");
            itemImage.Dispose();
            return "Failure: Colors to search with: "+expectedColor.ToString()+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".";
        }
        
        
        [UserCodeMethod]
        public static string ValidateBulletinAuthorityStateColor_OnBoard(string color, string colorExists)
        {
        	//Setting default value as True
        	bool validateColorExist = true;
        	if(!Boolean.TryParse(colorExists, out validateColorExist))
        	{
        		return "Failure: Please pass a valid colorExist value either True or False, current value:"+colorExists+".";
        	}
        	
        	HashSet<Color> colorsFound = new HashSet<Color>();
            Color expectedColor =  PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);

            Bitmap itemImage = Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            Report.LogData(ReportLevel.Info, "Info", itemImage);
  
            for (int j = 132; j<187; j++) {
            	for (int i = 10; i<590; i++) {
            		Color pixelColor = itemImage.GetPixel(i,j);
            		if (!colorsFound.Contains(pixelColor))
            		{
            			colorsFound.Add(pixelColor);
            		}
            	}
            }
            
            string notFoundColorsString = string.Join(", ", expectedColor);
            string imageColorsString = string.Join(", ", colorsFound);
            
			if(colorsFound.Contains(expectedColor) == validateColorExist)
			{
            	Report.Success("Found Color in the start");
            	itemImage.Dispose();
            	Report.Info("Colors found: "+imageColorsString);
            	return "Success: Color Found?"+validateColorExist.ToString()+" is validated";
                
            }
            
            Report.Failure("Color Not found on the Onboard screen");
            itemImage.Dispose();
            return "Failure: Colors to search with: "+expectedColor.ToString()+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".";
        }
        
        [UserCodeMethod]
        public static string ValidateBannerColor_OnBoard(string color, string colorExists)
        {
        	//Setting default value as True
        	bool validateColorExist = true;
        	if(!Boolean.TryParse(colorExists, out validateColorExist))
        	{
        		return "Failure: Please pass a valid colorExist value either True or False, current value:"+colorExists+".";
        	}
        	HashSet<Color> colorsFound = new HashSet<Color>();
        	//Must use a named color from PDSColors
        	
        	Color expectedColor =  PDS_CORE.Code_Utils.PDSColors.GetColorFromString(color);
            
            Bitmap itemImage = Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);

            for (int j = 453; j<533; j++) {
                for (int i = 0; i<605; i++) {
                    Color pixelColor = itemImage.GetPixel(i,j);
                    if (!colorsFound.Contains(pixelColor))
                    {
                        colorsFound.Add(pixelColor);
                    }
                }
            }
            
			if(colorsFound.Contains(expectedColor) == validateColorExist)
			{
            	Report.Success("Found Color in the start");
            	itemImage.Dispose();
            	return "Success: Color Found?"+validateColorExist.ToString()+" is validated";
                
            }
            
            string notFoundColorsString = string.Join(", ", expectedColor);
            string imageColorsString = string.Join(", ", colorsFound);
            Report.Failure("Color Not found in Banner");
            itemImage.Dispose();
            return "Failure: Colors to search with: "+expectedColor.ToString()+". Colors not found in Image: "+notFoundColorsString+". Colors in image: "+imageColorsString+".";
        }
        
        /// <summary>
        /// Override Governing Signal from the Debug form
        /// </summary>
        [UserCodeMethod]
        public static string OpenMotionControl_OnBoard()
        {
        	if (OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
        	{
        		return "Info: Motion Control already open";
        	}
        	
        	if (!OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
        	{
        		return "Error: Loco Simulator is not currently running";
        	}
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.MainMenuBar.MotionButtonInfo, OnBoardRepo.Loco_Simulator.MotionMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.MotionMenu.ControlsInfo, OnBoardRepo.Motion_Control.SelfInfo);
        	
        	if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
        	{
        		return "Error: Motion Control could not be opened";
        	}
        	
            return "Info: Opened Motion Control";
        }
        
        
        /// <summary>
        /// Adjust the amount the Onboard Simulator is zoomed (Default: 100)
        /// Waits for screen to adjust to new size if different than what's already selected
        /// </summary>
        [UserCodeMethod]
        public static string SetOnboardZoom_OnBoard(string zoom)
        {
        	if (!OnBoardRepo.Onboard_Form.SelfInfo.Exists(0))
        	{
        		return "Error: Onboard simulator is not currently running.";
        	}
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Onboard_Form.MainMenuBar.OptionsButtonInfo, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.SelfInfo, OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.SelfInfo, OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.SelfInfo);
        	
            switch (zoom)
            {
                case "25":
                    //TODO When we can see the elements, check if they're the value first
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N25Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 25;
                    break;
                case "50":
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N50Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 50;
                    break;
                case "75":
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N75Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 75;
                    topBannerRectangle = new Rectangle(new Point(137, 102), new Size(293, 30));
                    mphRectangle = new Rectangle(new Point(245, 57), new Size(116, 43));
                    ptcStatusRectangle = new Rectangle(new Point(438, 102), new Size(116, 25));
                    ptcEngineRectangle = new Rectangle(new Point(438, 82), new Size(116, 25));
                    bannerRectangle = new Rectangle(new Point(10, 365), new Size(550, 50));
                    departRectangle = new Rectangle(new Point(367, 341), new Size(56, 20));
                    break;
                case "100":
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N100Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 100;
                    topBannerRectangle = new Rectangle(new Point(125, 100), new Size(355, 37));
                    mphRectangle = new Rectangle(new Point(255, 50), new Size(140, 52));
                    ptcStatusRectangle = new Rectangle(new Point(480, 100), new Size(140, 30));
                    ptcEngineRectangle = new Rectangle(new Point(480, 75), new Size(140, 30));
                    bannerRectangle = new Rectangle(new Point(0, 403), new Size(605, 60));
                    departRectangle = new Rectangle(new Point(424, 387), new Size(202, 107));
                    break;
                case "200":
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N200Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 200;
                    topBannerRectangle = new Rectangle(new Point(220, 135), new Size(480, 45));
                    mphRectangle = new Rectangle(new Point(400, 67), new Size(189, 70));
                    ptcStatusRectangle = new Rectangle(new Point(712, 135), new Size(189, 40));
                    ptcEngineRectangle = new Rectangle(new Point(712, 101), new Size(189, 40));
                    bannerRectangle = new Rectangle(new Point(8, 561), new Size(885, 81));
                    departRectangle = new Rectangle(new Point(596, 526), new Size(89, 31));
                    break;
                case "400":
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Onboard_Form.OptionsMenu.Configuration.ConfigurationMenu.ResizingMode.ResizingModeMenu.N400Info, OnBoardRepo.Onboard_Form.OptionsMenu.SelfInfo);
                    currentZoom = 400;
                    topBannerRectangle = new Rectangle(new Point(315, 170), new Size(665, 53));
                    mphRectangle = new Rectangle(new Point(580, 73), new Size(238, 88));
                    ptcStatusRectangle = new Rectangle(new Point(1020, 170), new Size(238, 50));
                    ptcEngineRectangle = new Rectangle(new Point(1020, 127), new Size(238, 50));
                    bannerRectangle = new Rectangle(new Point(16, 770), new Size(1250, 125));
                    departRectangle = new Rectangle(new Point(840, 723), new Size(126, 45));
                    break;
                default:
                    return "Error: Zoom is set to an invalid option of {" + zoom + "}, Valid options are 25, 50, 75, 100, 200, and 400";
            }
            
            return "Info: Onboard Zoom set to {" + zoom + "}";
        }
        
        /// <summary>
        /// Presses Key if found from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string EnterNumber_OnBoard(string numericDigits, string numberType)
        {
        	if (numericDigits == "")
        	{
        		return "Info: No digits to enter, returning";
        	}
            //TODO we currently have to assume that all digits are 0, if OCR can perform well enough we can pull each individual digit and do a comparison (May be stored in the log)
            //First check if "Up" is a visible key on the onBoard, then determine how many (Could be a series of up keys to enter a number or could have left right buttons to change which digit is being incremented)
            OnBoardRepo.Onboard_Form.Self.EnsureVisible();
            if(!currentZoom.ToString().Equals("100"))
            {
            	SetOnboardZoom_OnBoard("100");	
            }
            
            if(numberType == "empNum" || numberType == "tcNum")
            {
            	Bitmap bmp = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
            	Rectangle mainScreenEMPText = new Rectangle(new Point(110, 360), new Size(150, 147));
            	Bitmap bmp2 = bmp.Clone(mainScreenEMPText, bmp.PixelFormat);
            	Graphics testGraphic;
            	testGraphic = Graphics.FromImage(bmp2);
            	testGraphic.SmoothingMode = SmoothingMode.HighQuality;
            	testGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            	testGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            	testGraphic.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), mainScreenEMPText, GraphicsUnit.Pixel);
            	bmp = bmp2;
            	Report.LogData(ReportLevel.Info, "OnBoard", bmp);
            	
            	HashSet<Color> colorsFound = new HashSet<Color>();
            	for (int j = 0; j<bmp.Height-1; j++) {
            		for (int i = 0; i<bmp.Width-1; i++) {
            			Color pixelColor = bmp.GetPixel(i,j);
            			if (!colorsFound.Contains(pixelColor))
            			{
            				colorsFound.Add(pixelColor);
            			}
            		}
            	}


            	Color fenceColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("white");
            	
            	//colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(sliceBmp);
            	bool colorInHashSet = colorsFound.Contains(fenceColor);
            	
            	if(colorInHashSet)
            	{
            		return "Warn: OnBoard already Contains Number, not entering it again";
            	}
            	else
            	{
            		Report.Info("Its an empty box");
            	}
            }
            	
            
            List<int> upKeyLocations = new List<int>();
            int downKeyLocation = 0;
            int leftKeyLocation = 0;
            int rightKeyLocation = 0;
            bool rightKeyAssigned = false;
            for (int i = 0; i < LogAgentLoop.buttons.Length; i++)
            {
            	if (LogAgentLoop.buttons[i].Equals("Up", StringComparison.OrdinalIgnoreCase))
                {
                    upKeyLocations.Add(i);
                } else if (LogAgentLoop.buttons[i].Equals("Down", StringComparison.OrdinalIgnoreCase))
                {
                    downKeyLocation = i;
                } else if (LogAgentLoop.buttons[i].Equals("Left", StringComparison.OrdinalIgnoreCase))
                {
                    leftKeyLocation = i;
                } else if (LogAgentLoop.buttons[i].Equals("Right", StringComparison.OrdinalIgnoreCase))
                {
                    rightKeyLocation = i;
                    rightKeyAssigned = true;
                }
            }
            
            //If there are no up buttons, we cannot input digits
            if (upKeyLocations.Count == 0)
            {
                return "Failure: OnBoard does not have buttons on screen for numeric input. Buttons shown are {" + string.Join(",", LogAgentLoop.buttons) + "}";
            }
            
            //Check if the value is actually numeric
            int throwAwayInteger;
            if (!int.TryParse(numericDigits, out throwAwayInteger))
            {
                return "Failure: {" + numericDigits + "} cannot be parsed into an integer to be entered";
            }
            
            //Adding retry logic if the OnBoard is slow and buttons do not showup on time
            int retries = 0;
            while(!rightKeyAssigned && retries < 3)
            {
            	downKeyLocation = 0;
            	leftKeyLocation = 0;
            	rightKeyLocation = 0;
            	upKeyLocations.Clear();
            	for (int i = 0; i < LogAgentLoop.buttons.Length; i++)
            	{
            		if (LogAgentLoop.buttons[i].Equals("Up", StringComparison.OrdinalIgnoreCase))
            		{
            			upKeyLocations.Add(i);
            		} else if (LogAgentLoop.buttons[i].Equals("Down", StringComparison.OrdinalIgnoreCase))
            		{
            			downKeyLocation = i;
            		} else if (LogAgentLoop.buttons[i].Equals("Left", StringComparison.OrdinalIgnoreCase))
            		{
            			leftKeyLocation = i;
            		} else if (LogAgentLoop.buttons[i].Equals("Right", StringComparison.OrdinalIgnoreCase))
            		{
            			rightKeyLocation = i;
            			rightKeyAssigned = true;
            		}
            	}
            	Ranorex.Delay.Seconds(5);
            	retries++;
            }
            
            //If there are only up buttons, it's set up as one button per digit place
            if (!rightKeyAssigned)
            {
                //If there are fewer digits, we can slap some on the front
                while (numericDigits.Length < upKeyLocations.Count)
                {
                    numericDigits = "0" + numericDigits;
                }
                //If it's not the same amount of buttons for the number of digits, we can't accurately represent the value
                if (upKeyLocations.Count != numericDigits.Length)
                {
                	return "Failure: OnBoard does not have enough buttons to input the value {" + numericDigits + "}.";
                }
                
                int index = 0;
                foreach (char charValue in numericDigits)
                {
                    Location buttonLocation = new Location();
                    //Find which button we need to press to increment this digit
                    if (upKeyLocations[index] == 0)
                    {
                        buttonLocation = button1xy;
                    } else if (upKeyLocations[index] == 1)
                    {
                        buttonLocation = button2xy;
                    } else if (upKeyLocations[index] == 2)
                    {
                        buttonLocation = button3xy;
                    } else if (upKeyLocations[index] == 3)
                    {
                        buttonLocation = button4xy;
                    } else if (upKeyLocations[index] == 4)
                    {
                        buttonLocation = button5xy;
                    } else if (upKeyLocations[index] == 5)
                    {
                        buttonLocation = button6xy;
                    } else if (upKeyLocations[index] == 6)
                    {
                        buttonLocation = button7xy;
                    } else if (upKeyLocations[index] == 7)
                    {
                        buttonLocation = button8xy;
                    }
                    
                    int intValue = charValue - '0';
                    for (int i = 0; i < intValue; i++)
                    {
                        LogAgentLoop.lastButton = "";
                        //Press offset buttonxy for the onboard dependent on upKeyLocations[index]
                        OnBoardRepo.Onboard_Form.Self.Click(buttonLocation);
                        Ranorex.Delay.Milliseconds(500);
                        //Going to check for what the last button pressed was from the logs to make sure this was successfully clicked
//                        int retries = 0;
//                        while (!LogAgentLoop.lastButton.Equals("Up", StringComparison.OrdinalIgnoreCase) && retries < 3)
//                        {
//                            Thread.Sleep(1000);
//                            retries++;
//                        }
//                        
//                        //TODO we may need to put a retry of some sort here
//                        if (!LogAgentLoop.lastButton.Equals("Up", StringComparison.OrdinalIgnoreCase))
//                        {
//                            return "Error: Clicked button on onboard but didn't receive response that it was clicked";
//                        }
                    }
                    
                    index++;
                }
            } else {
                //If there's a right button, we will assume there's also other buttons
                //We have to assume the number of digits given is the length of the value we need to supply, as we have no sure way of knowing otherwise
                Location rightButtonLocation = new Location();
                if (rightKeyLocation == 0)
                {
                    rightButtonLocation = button1xy;
                } else if (rightKeyLocation == 1)
                {
                    rightButtonLocation = button2xy;
                } else if (rightKeyLocation == 2)
                {
                    rightButtonLocation = button3xy;
                } else if (rightKeyLocation == 3)
                {
                    rightButtonLocation = button4xy;
                } else if (rightKeyLocation == 4)
                {
                    rightButtonLocation = button5xy;
                } else if (rightKeyLocation == 5)
                {
                    rightButtonLocation = button6xy;
                } else if (rightKeyLocation == 6)
                {
                    rightButtonLocation = button7xy;
                } else if (rightKeyLocation == 7)
                {
                    rightButtonLocation = button8xy;
                }
                
                Location leftButtonLocation = new Location();
                if (leftKeyLocation == 0)
                {
                    leftButtonLocation = button1xy;
                } else if (leftKeyLocation == 1)
                {
                    leftButtonLocation = button2xy;
                } else if (leftKeyLocation == 2)
                {
                    leftButtonLocation = button3xy;
                } else if (leftKeyLocation == 3)
                {
                    leftButtonLocation = button4xy;
                } else if (leftKeyLocation == 4)
                {
                    leftButtonLocation = button5xy;
                } else if (leftKeyLocation == 5)
                {
                    leftButtonLocation = button6xy;
                } else if (leftKeyLocation == 6)
                {
                    leftButtonLocation = button7xy;
                } else if (leftKeyLocation == 7)
                {
                    leftButtonLocation = button8xy;
                }
                
                Location downButtonLocation = new Location();
                if (downKeyLocation == 0)
                {
                    downButtonLocation = button1xy;
                } else if (downKeyLocation == 1)
                {
                    downButtonLocation = button2xy;
                } else if (downKeyLocation == 2)
                {
                    downButtonLocation = button3xy;
                } else if (downKeyLocation == 3)
                {
                    downButtonLocation = button4xy;
                } else if (downKeyLocation == 4)
                {
                    downButtonLocation = button5xy;
                } else if (downKeyLocation == 5)
                {
                    downButtonLocation = button6xy;
                } else if (downKeyLocation == 6)
                {
                    downButtonLocation = button7xy;
                } else if (downKeyLocation == 7)
                {
                    downButtonLocation = button8xy;
                }
                
                //Sometimes there's more than 1 up button, but for putting in a number, the one next to the down button is the right one
                int likelyUpButtonLocation = 0;
                if (upKeyLocations.Contains(downKeyLocation - 1))
                {
                	for (int i = 0; i < upKeyLocations.Count; i++)
                	{
                		if (upKeyLocations[i] == downKeyLocation - 1)
                		{
                			likelyUpButtonLocation = i;
                			break;
                		}
                	}
                }
                
                Location upButtonLocation = new Location();
                if (upKeyLocations[likelyUpButtonLocation] == 0)
                {
                    upButtonLocation = button1xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 1)
                {
                    upButtonLocation = button2xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 2)
                {
                    upButtonLocation = button3xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 3)
                {
                    upButtonLocation = button4xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 4)
                {
                    upButtonLocation = button5xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 5)
                {
                    upButtonLocation = button6xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 6)
                {
                    upButtonLocation = button7xy;
                } else if (upKeyLocations[likelyUpButtonLocation] == 7)
                {
                    upButtonLocation = button8xy;
                }
                
                Location buttonLocation = new Location();
                
                foreach (char charValue in numericDigits)
                {
                    int intValue = charValue - '0';
                    if (intValue < 5)
                    {
                        buttonLocation = upButtonLocation;
                    } else {
                        buttonLocation = downButtonLocation;
                        intValue = 10 - intValue;
                    }
                    
                    for (int i = 0; i < intValue; i++)
                    {
                        OnBoardRepo.Onboard_Form.Self.Click(buttonLocation);
                        Ranorex.Delay.Milliseconds(500);
                        //Going to check for what the last button pressed was from the logs to make sure this was successfully clicked
//                        retries = 0;
//                        while (LogAgentLoop.lastButton != assignedButton && retries < 3)
//                        {
//                            Thread.Sleep(1000);
//                            retries++;
//                        }
//                        
//                        //TODO we may need to put a retry of some sort here
//                        if (LogAgentLoop.lastButton != assignedButton)
//                        {
//                            return "Error: Clicked button on onboard but didn't receive response that it was clicked";
//                        }
                    }
                    
                    //Press the right button to continue the input
                    OnBoardRepo.Onboard_Form.Self.Click(rightButtonLocation);
                    Ranorex.Delay.Milliseconds(500);
                    //Going to check for what the last button pressed was from the logs to make sure this was successfully clicked
//                    retries = 0;
//                    while (!LogAgentLoop.lastButton.Equals("Right", StringComparison.OrdinalIgnoreCase) && retries < 3)
//                    {
//                        Thread.Sleep(1000);
//                        retries++;
//                    }
//                    
//                    //TODO we may need to put a retry of some sort here
//                    if (!LogAgentLoop.lastButton.Equals("Right", StringComparison.OrdinalIgnoreCase))
//                    {
//                        return "Error: Clicked button on onboard but didn't receive response that it was clicked";
//                    }
                }
            }
            return "Info: Input {" + numericDigits + "} into onBoard";
        }
        
        [UserCodeMethod]
        public static string SelectNSLoco_OnBoard()
        {
        	string nsText = OCRValidation_OnBoard("NS","locoDetails", "100","true");
        	string bnsfText = OCRValidation_OnBoard("BNSF","locoDetails", "100","true");
        	string gnwrText = OCRValidation_OnBoard("GNWR","locoDetails", "100","true");
        	string nmrxText = OCRValidation_OnBoard("NMRX","locoDetails", "100","true");
        	int retries = 0;
        	Ranorex.Report.Info("Starting while");
        	Report.Info("NSText: "+nsText);
        	Report.Info("BNSFText: "+bnsfText);
        	while(retries < 50)
        	{
        		if(bnsfText.Contains("Failure"))
        		{
        			if(nsText.Contains("Failure"))
        			{
        				KeyPress_OnBoard("UP-3", "1");
        				nsText = OCRValidation_OnBoard("NS","locoDetails", "100","true");
        				bnsfText = OCRValidation_OnBoard("BNSF","locoDetails", "100","true");
        				gnwrText = OCRValidation_OnBoard("GNWR","locoDetails", "100","true");
        				nmrxText = OCRValidation_OnBoard("NMRX","locoDetails", "100","true");
        				Report.Info("NSText: "+nsText);
        				Report.Info("BNSFText: "+bnsfText);
        				retries++;
        			}
        			else if(nsText.Contains("Success") && (gnwrText.Contains("Success") || nmrxText.Contains("Success")))
        			{
        				KeyPress_OnBoard("UP-3", "1");
        				nsText = OCRValidation_OnBoard("NS","locoDetails", "100","true");
        				bnsfText = OCRValidation_OnBoard("BNSF","locoDetails", "100","true");
        				gnwrText = OCRValidation_OnBoard("GNWR","locoDetails", "100","true");
        				nmrxText = OCRValidation_OnBoard("NMRX","locoDetails", "100","true");
        				Report.Info("NSText: "+nsText);
        				Report.Info("BNSFText: "+bnsfText);
        				retries++;
        			}
        			else
        			{
        				break;
        			}
        				
        			
        		}
        		else if(bnsfText.Contains("Success"))
        		{
        			KeyPress_OnBoard("UP-3", "1");
        			nsText = OCRValidation_OnBoard("NS","locoDetails", "100","true");
        			bnsfText = OCRValidation_OnBoard("BNSF","locoDetails", "100","true");
        			gnwrText = OCRValidation_OnBoard("GNWR","locoDetails", "100","true");
        			nmrxText = OCRValidation_OnBoard("NMRX","locoDetails", "100","true");
        			Report.Info("NSText: "+nsText);
        			Report.Info("BNSFText: "+bnsfText);
        			retries++;
        		}
        			
        	}
        	Ranorex.Report.Info("Ending while");
        	return "Info: Selected NS Loco Type";
        }
        
        /// <summary>
        /// Presses Key if found from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string KeyPress_OnBoard(string key, string numberOfPresses = "1")
        {
        	int numberOfPressesInt = 0;
        	if (!int.TryParse(numberOfPresses, out numberOfPressesInt))
            {
                return "Failure: [" + numberOfPresses + "] Could not be converted to an integer";
            }
        	
        	if (key.Contains("-"))
        	{
        		string[] keySplit = key.Split('-');
        		int keyPlace = 0;
            	if (keySplit.Length == 2 && int.TryParse(keySplit[1], out keyPlace))
            	{
            		
	            	keyPlace--;
	            	
	            	if (LogAgentLoop.buttons[keyPlace].ToLower() != keySplit[0].ToLower())
	            	{
	            		return "Error: Key {" + keySplit[0] + "} could not be found on Onboard Screen at position {" + keySplit[1] + ", keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
	            	}
	            	
	            	switch (keyPlace)
	            	{
	            		case 0:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button1xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 1:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button2xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 2:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button3xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 3:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button4xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 4:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button5xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 5:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button6xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 6:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button7xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            		case 7:
	            			for (int i = 0; i < numberOfPressesInt; i++)
	            			{
		            			OnBoardRepo.Onboard_Form.Self.Click(button8xy);
		            			if (numberOfPressesInt - 1 != i)
		            			{
		            				Ranorex.Delay.Milliseconds(500);
		            			}
	            			}
	            			break;
	            	}
	            	
	            	return "Info: Clicked Key at position " + keySplit[1] + " {" + keySplit[0] + "} " + numberOfPresses + " times.";
            	}
            	
        	}
        	
        	key = key.ToLower();
        	if (LogAgentLoop.buttons[0].ToLower() == key)
            {
            	for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button1xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 1 {" + key + "} " + numberOfPresses + " times.";
        	} else if (LogAgentLoop.buttons[1].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button2xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 2 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[2].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button3xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 3 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[3].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button4xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 4 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[4].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button5xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 5 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[5].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button6xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 6 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[6].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button7xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 7 {" + key + "} " + numberOfPresses + " times.";
            } else if (LogAgentLoop.buttons[7].ToLower() == key)
            {
                for (int i = 0; i < numberOfPressesInt; i++)
    			{
        			OnBoardRepo.Onboard_Form.Self.Click(button8xy);
        			if (numberOfPressesInt - 1 != i)
        			{
        				Ranorex.Delay.Milliseconds(500);
        			}
    			}
                return "Info: Clicked Key at position 8 {" + key + "} " + numberOfPresses + " times.";
            }
            
            return "Error: Key {" + key + "} could not be found on Onboard Screen, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Presses Key only if found from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string KeyPressIfExists_OnBoard(string key)
        {
        	int secondsWaitInt = 10;
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
        	key = key.ToLower();
        	bool keyFound = false;
            
        	while (System.DateTime.Now < expirationTime && !keyFound)
        	{
        		if (LogAgentLoop.buttons[0].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button1xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 1 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[1].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button2xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 2 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[2].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button3xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 3 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[3].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button4xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 4 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[4].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button5xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 5 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[5].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button6xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 6 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[6].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button7xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 7 {" + key + "}.";
        		} else if (LogAgentLoop.buttons[7].ToLower() == key)
        		{
        			OnBoardRepo.Onboard_Form.Self.Click(button8xy);
        			keyFound = true;
        			return "Info: Clicked Key at position 8 {" + key + "}.";
        		}
        	}
            
            return "Info: Key {" + key + "} could not be found on Onboard Screen";
        }
        
        /// <summary>
        /// Waits for key within seconds timeframe from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string KeyWait_OnBoard(string key, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            
            if (key.Contains("-"))
            {
            	string[] keySplit = key.Split('-');
            	int keyPlace = 0;
            	if (keySplit.Length == 2 && int.TryParse(keySplit[1], out keyPlace))
            	{
            		
	            	keyPlace--;
	            	
	            	while (System.DateTime.Now < expirationTime)
	            	{
	            		if (LogAgentLoop.buttons[keyPlace] == keySplit[0])
		                {
		                    return "Info: Found Key at position " + keySplit[1] + " {" + keySplit[0] + "}.";
		                }
		                
		                Thread.Sleep(250);
	            	}
	            	
	            	return "Error: Key {" + keySplit[0] + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds at position {" + keySplit[1] + "}, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
            	}
            }
            key = key.ToLower();
            while (System.DateTime.Now < expirationTime)
            {
                if (LogAgentLoop.buttons[0].ToLower() == key)
                {
                    return "Info: Found Key at position 1 {" + key + "}.";
                } else if (LogAgentLoop.buttons[1].ToLower() == key)
                {
                    return "Info: Found Key at position 2 {" + key + "}.";
                } else if (LogAgentLoop.buttons[2].ToLower() == key)
                {
                    return "Info: Found Key at position 3 {" + key + "}.";
                } else if (LogAgentLoop.buttons[3].ToLower() == key)
                {
                    return "Info: Found Key at position 4 {" + key + "}.";
                } else if (LogAgentLoop.buttons[4].ToLower() == key)
                {
                    return "Info: Found Key at position 5 {" + key + "}.";
                } else if (LogAgentLoop.buttons[5].ToLower() == key)
                {
                    return "Info: Found Key at position 6 {" + key + "}.";
                } else if (LogAgentLoop.buttons[6].ToLower() == key)
                {
                    return "Info: Found Key at position 7 {" + key + "}.";
                } else if (LogAgentLoop.buttons[7].ToLower() == key)
                {
                    return "Info: Found Key at position 8 {" + key + "}.";
                }
                
                Thread.Sleep(250);
            }
            
            return "Error: Key {" + key + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Waits for key to be removed within seconds timeframe from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string KeyWaitRemoval_OnBoard(string key, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            key = key.ToLower();
            while (System.DateTime.Now < expirationTime)
            {
                if (LogAgentLoop.buttons[0].ToLower() == key || LogAgentLoop.buttons[1].ToLower() == key || LogAgentLoop.buttons[2].ToLower() == key
            	   || LogAgentLoop.buttons[3].ToLower() == key || LogAgentLoop.buttons[4].ToLower() == key || LogAgentLoop.buttons[5].ToLower() == key
            	   || LogAgentLoop.buttons[6].ToLower() == key || LogAgentLoop.buttons[7].ToLower() == key)
                {
	                Thread.Sleep(250);
                } else {
                	return "Info: Found Key {" + key + "} Removed.";
                }
            }
            
            return "Error: Key {" + key + "}  found on Onboard Screen within {" + secondsWait + "} seconds, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Waits for key to be removed within seconds timeframe from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string VerifyNoKeys_OnBoard()
        {
        	
        	if (LogAgentLoop.buttons[0].ToLower() == "" && LogAgentLoop.buttons[1].ToLower() == "" && LogAgentLoop.buttons[2].ToLower() == ""
        	    && LogAgentLoop.buttons[3].ToLower() == "" && LogAgentLoop.buttons[4].ToLower() == "" && LogAgentLoop.buttons[5].ToLower() == ""
        	    && LogAgentLoop.buttons[6].ToLower() == "" && LogAgentLoop.buttons[7].ToLower() == "")
        	{
        		return "Info: No Keys Found.";
        	} else {
        		return "Error: Key found on Onboard Screen, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        	}
        	
        }
        
        /// <summary>
        /// Presses Key if found within seconds timeframe from the onBoard logs
        /// </summary>
        [UserCodeMethod]
        public static string KeyWaitPress_OnBoard(string key, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            key = key.ToLower();
            while (System.DateTime.Now < expirationTime)
            {
                if (LogAgentLoop.buttons[0].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button1xy);
                    return "Info: Clicked Key at position 1 {" + key + "}.";
                } else if (LogAgentLoop.buttons[1].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button2xy);
                    return "Info: Clicked Key at position 2 {" + key + "}.";
                } else if (LogAgentLoop.buttons[2].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button3xy);
                    return "Info: Clicked Key at position 3 {" + key + "}.";
                } else if (LogAgentLoop.buttons[3].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button4xy);
                    return "Info: Clicked Key at position 4 {" + key + "}.";
                } else if (LogAgentLoop.buttons[4].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button5xy);
                    return "Info: Clicked Key at position 5 {" + key + "}.";
                } else if (LogAgentLoop.buttons[5].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button6xy);
                    return "Info: Clicked Key at position 6 {" + key + "}.";
                } else if (LogAgentLoop.buttons[6].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button7xy);
                    return "Info: Clicked Key at position 7 {" + key + "}.";
                } else if (LogAgentLoop.buttons[7].ToLower() == key)
                {
                    OnBoardRepo.Onboard_Form.Self.Click(button8xy);
                    return "Info: Clicked Key at position 8 {" + key + "}.";
                }
                
                Thread.Sleep(250);
            }
            
            return "Error: Key {" + key + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Validates a Key Exists
        /// </summary>
        [UserCodeMethod]
        public static string KeyVerify_OnBoard(string key)
        {
        	if (key.Contains("-"))
        	{
        		string[] keySplit = key.Split('-');
        		int keyPlace = 0;
            	if (keySplit.Length == 2 && int.TryParse(keySplit[1], out keyPlace))
            	{
            		
	            	keyPlace--;
	            	
	            	if (LogAgentLoop.buttons[keyPlace] == keySplit[0])
		            {
	            		return "Success: Found Key at position " + keySplit[1] + " {" + keySplit[0] + "}.";
	            	}
	            	
	            	return "Failure: Key {" + keySplit[0] + "} could not be found on Onboard Screen at position " + keySplit[1] + ", keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
            	}
            	
        	}
        	key = key.ToLower();
        	
            if (LogAgentLoop.buttons[0].ToLower() == key)
            {
                return "Success: Found Key at position 1 {" + key + "}.";
            } else if (LogAgentLoop.buttons[1].ToLower() == key)
            {
                return "Success: Found Key at position 2 {" + key + "}.";
            } else if (LogAgentLoop.buttons[2].ToLower() == key)
            {
                return "Success: Found Key at position 3 {" + key + "}.";
            } else if (LogAgentLoop.buttons[3].ToLower() == key)
            {
                return "Success: Found Key at position 4 {" + key + "}.";
            } else if (LogAgentLoop.buttons[4].ToLower() == key)
            {
                return "Success: Found Key at position 5 {" + key + "}.";
            } else if (LogAgentLoop.buttons[5].ToLower() == key)
            {
                return "Success: Found Key at position 6 {" + key + "}.";
            } else if (LogAgentLoop.buttons[6].ToLower() == key)
            {
                return "Success: Found Key at position 7 {" + key + "}.";
            } else if (LogAgentLoop.buttons[7].ToLower() == key)
            {
                return "Success: Found Key at position 8 {" + key + "}.";
            }
            
            return "Failure: Key {" + key + "} could not be found on Onboard Screen, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Validates a Key does not Exist
        /// </summary>
        [UserCodeMethod]
        public static string KeyVerifyNone_OnBoard(string key)
        {
        	key = key.ToLower();
            if (LogAgentLoop.buttons[0] == key)
            {
                return "Failure: Found Key at position 1 {" + key + "}.";
            } else if (LogAgentLoop.buttons[1].ToLower() == key)
            {
                return "Failure: Found Key at position 2 {" + key + "}.";
            } else if (LogAgentLoop.buttons[2].ToLower() == key)
            {
                return "Failure: Found Key at position 3 {" + key + "}.";
            } else if (LogAgentLoop.buttons[3].ToLower() == key)
            {
                return "Failure: Found Key at position 4 {" + key + "}.";
            } else if (LogAgentLoop.buttons[4].ToLower() == key)
            {
                return "Failure: Found Key at position 5 {" + key + "}.";
            } else if (LogAgentLoop.buttons[5].ToLower() == key)
            {
                return "Failure: Found Key at position 6 {" + key + "}.";
            } else if (LogAgentLoop.buttons[6].ToLower() == key)
            {
                return "Failure: Found Key at position 7 {" + key + "}.";
            } else if (LogAgentLoop.buttons[7].ToLower() == key)
            {
                return "Failure: Found Key at position 8 {" + key + "}.";
            }
            
            return "Success: Key {" + key + "} could not be found on Onboard Screen, keys found are {" + string.Join(",", LogAgentLoop.buttons) + "}";
        }
        
        /// <summary>
        /// Waits for a Banner to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string BannerWait_OnBoard(string banner, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            Regex bannerRegex = new Regex(banner);
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            
            while (System.DateTime.Now < expirationTime)
            {
            	Report.Info("Banner found: "+LogAgentLoop.banner);
            	if (bannerRegex.IsMatch(LogAgentLoop.banner))
                {
            		return "Info: Found Banner {" + banner + "}.";
                }
                
                Thread.Sleep(250);
            }
            
            return "Error: Banner {" + banner + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds, banner found is {" + LogAgentLoop.banner + "}";
        }
        
        /// <summary>
        /// Waits for a Banner to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string BannerWaitEqual_OnBoard(string banner, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            
            while (System.DateTime.Now < expirationTime)
            {
            	Report.Info("Banner found: "+LogAgentLoop.banner);
            	if (LogAgentLoop.banner.Equals(banner, StringComparison.OrdinalIgnoreCase))
                {
                    return "Info: Found Banner {" + banner + "}.";
                }
                
                Thread.Sleep(250);
            }
            
            return "Error: Banner {" + banner + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds, banner found is {" + LogAgentLoop.banner + "}";
        }
        
        /// <summary>
        /// Waits for a Banner to disappear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string BannerWaitRemoval_OnBoard(string banner, string secondsWait)
        {
            int timeFrameInSecondsInt = 0;
            if (!int.TryParse(secondsWait, out timeFrameInSecondsInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt);
            Regex bannerRegex = new Regex(banner);
            bool foundMessage = true;
            while (foundMessage && System.DateTime.Now < timeLimit)
            {
            	if(bannerRegex.IsMatch(LogAgentLoop.banner))
            	{
            		foundMessage = true;
            	}
            	else
            	{
            		foundMessage = false;
            	}
            }
            
            if (foundMessage)
            {
                return "Failure: Banner[" + banner + "] still present within {" + secondsWait + "} second timeframe";
            } else {
	            return "Success: [" + banner + "] Banner removed within {" + secondsWait + "} second timeframe";
            }
        }
        
        /// <summary>
        /// Waits for a Banner to disappear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string TopBannerWaitRemoval_OnBoard(string topBanner, string secondsWait)
        {
            int timeFrameInSecondsInt = 0;
            if (!int.TryParse(secondsWait, out timeFrameInSecondsInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt);
            Regex topBannerRegex = new Regex(topBanner);
            bool foundMessage = true;
            while (foundMessage && System.DateTime.Now < timeLimit)
            {
            	if(topBannerRegex.IsMatch(LogAgentLoop.topBanner))
            	{
            		foundMessage = true;
            	}
            	else
            	{
            		foundMessage = false;
            	}
            }
            
            if (foundMessage)
            {
                return "Failure: Banner[" + topBanner + "] still present within {" + secondsWait + "} second timeframe";
            } else {
	            return "Success: [" + topBanner + "] Banner removed within {" + secondsWait + "} second timeframe";
            }
        }
        /// <summary>
        /// Validates Banner appears in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string BannerVerify_OnBoard(string banner)
        {
        	Regex bannerRegex = new Regex(banner);
        	Report.Info("Banner found: "+LogAgentLoop.banner);
        	if (bannerRegex.IsMatch(LogAgentLoop.banner))
            {
                return "Success: Found Banner {" + LogAgentLoop.banner + "}.";
            }
            
            return "Failure: Banner {" + banner + "} could not be found on Onboard Screen, banner found is {" + LogAgentLoop.banner + "}";
        }
        
        
        /// <summary>
        /// Validates Banner appears in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string BannerVerifyEquals_OnBoard(string banner)
        {
        	if (LogAgentLoop.banner.Equals(banner, StringComparison.OrdinalIgnoreCase))
            {
                return "Success: Found Banner {" + LogAgentLoop.banner + "}.";
            }
            
            return "Failure: Banner {" + banner + "} could not be found on Onboard Screen, banner found is {" + LogAgentLoop.banner + "}";
        }
        
        
        
        /// <summary>
        /// Waits for a Top Banner to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string TopBannerWait_OnBoard(string topBanner, string secondsWait)
        {
            int secondsWaitInt = 0;
            if (!int.TryParse(secondsWait, out secondsWaitInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime expirationTime = System.DateTime.Now.AddSeconds(secondsWaitInt);
            
            while (System.DateTime.Now < expirationTime)
            {
                if (LogAgentLoop.topBanner == topBanner)
                {
                    return "Info: Found Top Banner {" + topBanner + "}.";
                }
                
                Thread.Sleep(250);
            }
            
            return "Error: Top banner {" + topBanner + "} could not be found on Onboard Screen within {" + secondsWait + "} seconds, top banner found is {" + LogAgentLoop.topBanner + "}";
        
//        	int timeFrameInSecondsInt = 0;
//            if (!int.TryParse(secondsWait, out timeFrameInSecondsInt))
//            {
//                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
//            }
//            
//            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt);
//            Regex topBannerRegex = new Regex(topBanner);
//            bool foundMessage = false;
//            while (!foundMessage && System.DateTime.Now < timeLimit)
//            {
//            	System.DateTime currentTimeMinusTimeFrame = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt * -1);
//            	List<string> topBannerKeyList = new List<string>(LogAgentLoop.topBannerTimeStamps.Keys);
//            	
//            	foreach (string key in topBannerKeyList)
//            	{
//            		Report.Info("Top Key: "+key);
//            		if(topBannerRegex.IsMatch(key))
//            		{
//            			if (LogAgentLoop.topBannerTimeStamps[key].First.Value > currentTimeMinusTimeFrame)
//            			{
//            				//topBannerKeyList.Clear();
//            				topBannerKeyList.Remove(key);
//            				foundMessage = true;
//            				break;
//            			}
//            		}
//            	}
//            	
//            }
//            
//            if (!foundMessage)
//            {
//                return "Failure: No [" + topBanner + "] Banner found within {" + secondsWait + "} second timeframe";
//            } else {
//	            return "Success: [" + topBanner + "] Banner found within {" + secondsWait + "} second timeframe";
//            }
        }
        
        /// <summary>
        /// Waits for a Top Banner to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string TopBannerWaitWithoutList_OnBoard(string topBanner, string secondsWait)
        {
        	int timeFrameInSecondsInt = 0;
            if (!int.TryParse(secondsWait, out timeFrameInSecondsInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt);
            Regex topBannerRegex = new Regex(topBanner);
            bool foundMessage = false;
            while (!foundMessage && System.DateTime.Now < timeLimit)
            {
            	{
            		if(topBannerRegex.IsMatch(LogAgentLoop.topBanner))
            		{
            			foundMessage = true;
            			break;
            		}
            	}
            	
            }
            
            if (!foundMessage)
            {
                return "Failure: No [" + topBanner + "] Banner found within {" + secondsWait + "} second timeframe";
            } else {
	            return "Success: [" + topBanner + "] Banner found within {" + secondsWait + "} second timeframe";
            }
        }
        
        /// <summary>
        /// Waits for a Horn State to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string HornWait_OnBoard(string horn, string secondsWait)
        {
        	int timeFrameInSecondsInt = 0;
            if (!int.TryParse(secondsWait, out timeFrameInSecondsInt))
            {
                return "Failure: [" + secondsWait + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt);
            bool foundHornState = false;
            while (!foundHornState && System.DateTime.Now < timeLimit)
            {
            	{
            		if(LogAgentLoop.hornState.Equals(horn.ToUpper()))
            		{
            			foundHornState = true;
            			break;
            		}
            	}
            	
            }
            
            if (!foundHornState)
            {
                return "Failure: Horn State not found in [" + horn + "] within {" + secondsWait + "} second timeframe";
            } else {
	            return "Success: Horn State found within {" + secondsWait + "} second timeframe";
            }
        }
        
        public static string hornAction(string action)
        {
        	if(action.ToLower().Equals("start"))
        	{
        		LogAgentLoop.hornValidate = true;
        	}
        	else
        	{
        		LogAgentLoop.hornValidate = false;
        	}
        	return "Success: Horn log action performed";
        }
        /// <summary>
        /// Waits for a Horn State to appear in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string HornVerifyLastBlast_OnBoard(string hornDuration, string hornWithinSeconds)
        {
        	int userHornDuration = 0;
            if (!int.TryParse(hornDuration, out userHornDuration))
            {
                return "Failure: [" + hornDuration + "] Could not be converted to an integer";
            }
            
            int hornTimeFrame = 0;
            if (!int.TryParse(hornWithinSeconds, out hornTimeFrame))
            {
                return "Failure: [" + hornWithinSeconds + "] Could not be converted to an integer";
            }
            
            if(LogAgentLoop.hornEndTime <= (System.DateTime.Now.AddSeconds(240*-1) ))
            {
            	return "Failure: Last Horn found was more than 4 minutes ago";
            }
            
            bool foundHorn = false;
            System.DateTime timeOut = System.DateTime.Now.AddSeconds(20);
            while (!foundHorn && System.DateTime.Now < timeOut)
            {
            	System.DateTime currentTimeMinusTimeFrame = System.DateTime.Now.AddSeconds(hornTimeFrame * -1);
            	List<System.DateTime> hornKeyList = new List<System.DateTime>(LogAgentLoop.HornTimeStamps.Keys);
            	
            	foreach (System.DateTime key in hornKeyList)
            	{
            		Report.Info("Horn Key: "+key);
            		if(key >= currentTimeMinusTimeFrame && key <= System.DateTime.Now)
            		{
            			if (LogAgentLoop.HornTimeStamps[key] == userHornDuration)
            			{
            				foundHorn = true;
            				LogAgentLoop.HornTimeStamps.Clear();
            				break;
            			}
            		}
            	}
            	
            }
            
            if (foundHorn)
            {
            	return "Success: Horn Last Blast duration found {" + userHornDuration.ToString() + "} seconds";
                
            } else {
	            return "Failure: Horn Last Blast duration not found between [" +hornWithinSeconds + "} second timeframe";
            }
        }
        
        /// <summary>
        /// Validates Top Banner appears in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string TopBannerVerify_OnBoard(string topBanner)
        {
        	Regex topBannerRegex = new Regex(topBanner);
        	if (topBannerRegex.IsMatch(LogAgentLoop.topBanner))
            {
                return "Success: Found Top Banner {" + topBanner + "}.";
            }
            
            return "Failure: Top banner {" + topBanner + "} could not be found on Onboard Screen, top banner found is {" + LogAgentLoop.topBanner + "}";
        }
        
        /// <summary>
        /// Validates Top Banner appears in the LogAgent
        /// </summary>
        [UserCodeMethod]
        public static string HornStateVerify_OnBoard(string horn)
        {
        	if (LogAgentLoop.hornState.Equals(horn.ToUpper()))
            {
                return "Success: Found Horn State {" + horn + "}.";
            }
            
            return "Failure: Horn State {" + horn + "} could not be found, current horn state found is {" + LogAgentLoop.hornState + "}";
        }
        
        /// <summary>
        /// Validates Yellow Depart Box Exists
        /// </summary>
        [UserCodeMethod]
        public static string ValidateYellowBoxForDepart_OnBoard(string validateExists)
        {
        	//tested
        	bool validateExistsBool = true;
            if (!bool.TryParse(validateExists, out validateExistsBool))
            {
                return "Error: ValidateYellowBoxForDepart_OnBoard got a validateExists value of {"+ validateExists + "} which could not be converted into a bool";
            }
        	
        	HashSet<Color> colorsFound = new HashSet<Color>();
        	Bitmap onboardBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
        	Bitmap departBoxBitmap = onboardBitmap.Clone(departRectangle, onboardBitmap.PixelFormat);
        	Color ptcDepartYellow = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("PTC_Depart_Yellow");
        	
        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(departBoxBitmap);
        	Report.LogData(ReportLevel.Info, "Info", departBoxBitmap);
        	bool colorInHashSet = colorsFound.Contains(ptcDepartYellow);
        	if (validateExistsBool == colorInHashSet)
        	{
        		Ranorex.Report.Info("Success");
        		return "Success: Yellow Depart box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	} else {
        		Ranorex.Report.Info("Yellow Depart Box Failure");
        		Report.LogData(ReportLevel.Info, "Info", onboardBitmap);
        		Report.LogData(ReportLevel.Info, "Info", departBoxBitmap);
        		return "Failure: Yellow Depart box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	}
        }
        
        /// <summary>
        /// Validates Yellow Park Box Exists
        /// </summary>
        [UserCodeMethod]
        public static string ValidateYellowBoxForPark_OnBoard(string validateExists)
        {
        	//tested
        	bool validateExistsBool = true;
            if (!bool.TryParse(validateExists, out validateExistsBool))
            {
                return "Error: ValidateYellowBoxForDepart_OnBoard got a validateExists value of {"+ validateExists + "} which could not be converted into a bool";
            }
        	
        	HashSet<Color> colorsFound = new HashSet<Color>();
        	Bitmap onboardBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
        	Rectangle parkRectangle = new Rectangle(new Point(350, 365), new Size(100, 50));
        	Bitmap parkBoxBitmap = onboardBitmap.Clone(parkRectangle, onboardBitmap.PixelFormat);
        	Color parkYellow = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("yellow");
        	
        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(parkBoxBitmap);
        	//Report.LogData(ReportLevel.Info, "Info", parkBoxBitmap);
        	bool colorInHashSet = colorsFound.Contains(parkYellow);
        	if (validateExistsBool == colorInHashSet)
        	{
        		Ranorex.Report.Info("Success");
        		return "Success: Yellow Park box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	} else {
        		Ranorex.Report.Info("Yellow Park Box Failure");
        		Report.LogData(ReportLevel.Info, "Info", onboardBitmap);
        		Report.LogData(ReportLevel.Info, "Info", parkBoxBitmap);
        		return "Failure: Yellow Park box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	}
        }
        
        /// <summary>
        /// Validates Yellow Sync Box Exists
        /// </summary>
        [UserCodeMethod]
        public static string ValidateYellowColorForSync_OnBoard(string validateExists)
        {
        	//tested
        	bool validateExistsBool = true;
            if (!bool.TryParse(validateExists, out validateExistsBool))
            {
                return "Error: ValidateYellowBoxForSync_OnBoard got a validateExists value of {"+ validateExists + "} which could not be converted into a bool";
            }
        	
        	HashSet<Color> colorsFound = new HashSet<Color>();
        	Bitmap onboardBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
        	Bitmap syncBitmap = onboardBitmap.Clone(syncRectangle, onboardBitmap.PixelFormat);
        	Color ptcSyncYellow = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("yellow");
        	
        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(syncBitmap);
        	bool colorInHashSet = colorsFound.Contains(ptcSyncYellow);
        	if (validateExistsBool == colorInHashSet)
        	{
        		Ranorex.Report.Info("Success");
        		return "Success: Yellow Sync box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	} else {
        		Ranorex.Report.Info("Yellow Sync Box Failure");
        		Report.LogData(ReportLevel.Info, "Info", onboardBitmap);
        		Report.LogData(ReportLevel.Info, "Info", syncBitmap);
        		return "Failure: Yellow Depart box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	}
        }
        
        /// <summary>
        /// Validates Yellow Non Comm Box Exists
        /// </summary>
        [UserCodeMethod]
        public static string ValidateYellowColorForNonComm_OnBoard(string validateExists)
        {
        	//tested
        	bool validateExistsBool = true;
            if (!bool.TryParse(validateExists, out validateExistsBool))
            {
                return "Error: ValidateYellowBoxForNonComm_OnBoard got a validateExists value of {"+ validateExists + "} which could not be converted into a bool";
            }
        	Rectangle nonCommRectangle = new Rectangle(new Point(500, 388), new Size(150, 97));
        	HashSet<Color> colorsFound = new HashSet<Color>();
        	Bitmap onboardBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Onboard_Form.Self.Element);
        	Bitmap nonCommBitmap = onboardBitmap.Clone(nonCommRectangle, onboardBitmap.PixelFormat);
        	Color ptcSyncYellow = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("yellow");
        	
        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(nonCommBitmap);
        	Report.LogData(ReportLevel.Info, "Info", onboardBitmap);
        	Report.LogData(ReportLevel.Info, "Info", nonCommBitmap);
        	bool colorInHashSet = colorsFound.Contains(ptcSyncYellow);
        	if (validateExistsBool == colorInHashSet)
        	{
        		Ranorex.Report.Info("Success");
        		return "Success: Yellow Non Comm box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	} else {
        		Ranorex.Report.Info("Yellow Non Comm Box Failure");
        		Report.LogData(ReportLevel.Info, "Info", onboardBitmap);
        		Report.LogData(ReportLevel.Info, "Info", nonCommBitmap);
        		return "Failure: Yellow Non Comm box was " + (colorInHashSet ? "found":"not found") + " on the onBoard screen";
        	}
        }
        
        public static string ConsistRequestFix_OnBoard()
        {
        	//If Accept key exists, then we don't have to do this "fix"
        	string key = "accept";
        	if (LogAgentLoop.buttons[0].ToLower() == key || LogAgentLoop.buttons[1].ToLower() == key || LogAgentLoop.buttons[2].ToLower() == key
            	   || LogAgentLoop.buttons[3].ToLower() == key || LogAgentLoop.buttons[4].ToLower() == key || LogAgentLoop.buttons[5].ToLower() == key
            	   || LogAgentLoop.buttons[6].ToLower() == key || LogAgentLoop.buttons[7].ToLower() == key)
        	{
        		return "Info: Consist Request already in proper state";
        	}
        	KeyWaitPress_OnBoard("Modify", "10");
        	KeyWaitPress_OnBoard("Operative Brakes", "10");
        	KeyWait_OnBoard("UP", "10");
        	EnterNumber_OnBoard("010", "");
        	KeyPress_OnBoard("Enter");
        	KeyWait_OnBoard("Locos", "10");
        	
        	if (LogAgentLoop.buttons[0].ToLower() == key || LogAgentLoop.buttons[1].ToLower() == key || LogAgentLoop.buttons[2].ToLower() == key
            	   || LogAgentLoop.buttons[3].ToLower() == key || LogAgentLoop.buttons[4].ToLower() == key || LogAgentLoop.buttons[5].ToLower() == key
            	   || LogAgentLoop.buttons[6].ToLower() == key || LogAgentLoop.buttons[7].ToLower() == key)
        	{
        		return "Info: Set brakes, Loco Orientation already set";
        	}
        	
        	KeyWaitPress_OnBoard("Locos", "10");
        	KeyWaitPress_OnBoard("Modify Loco", "10");
        	KeyWait_OnBoard("UP", "10");
        	//Make it Front
        	//EnterNumber_OnBoard("10000", "");
        	KeyPress_OnBoard("UP-4");
        	KeyWaitPress_OnBoard("Enter", "10");
        	KeyWait_OnBoard("DOWN", "10");
        	KeyPress_OnBoard("Enter");
        	KeyWait_OnBoard("Locos", "10");
        	
        	//If Accept key does not exist now, we have more problems and needs someone to manually fix it
        	if (!(LogAgentLoop.buttons[0].ToLower() == key || LogAgentLoop.buttons[1].ToLower() == key || LogAgentLoop.buttons[2].ToLower() == key
            	   || LogAgentLoop.buttons[3].ToLower() == key || LogAgentLoop.buttons[4].ToLower() == key || LogAgentLoop.buttons[5].ToLower() == key
            	   || LogAgentLoop.buttons[6].ToLower() == key || LogAgentLoop.buttons[7].ToLower() == key))
        	{
        		WinForms.MessageBox.Show("Consist Configuration could not be automatically completed, please fill in consist " +
        		                         "to working state before \"Accept\" key is press (Do not press Accept)", "Error",
        		                         WinForms.MessageBoxButtons.OK);
        	}
        	
        	return "Info: Consist Fix was run as full consist wasn't available from BOS";
        }
        
        public static string ValidateBulletinTextWithoutPrompt_OnBoard(string ocrText, string functionalArea, string zoom, string validateExists)
        {
        	//If Review key exists, then we don't have to do this "fix"
        	string key = "review";
        	if (LogAgentLoop.buttons[0].ToLower() == key || LogAgentLoop.buttons[1].ToLower() == key || LogAgentLoop.buttons[2].ToLower() == key
        	    || LogAgentLoop.buttons[3].ToLower() == key || LogAgentLoop.buttons[4].ToLower() == key || LogAgentLoop.buttons[5].ToLower() == key
        	    || LogAgentLoop.buttons[6].ToLower() == key || LogAgentLoop.buttons[7].ToLower() == key)
        	{
        		return "Failure: Bulletin Prompt is present, no need to validate using Alternative validation";
        	}
        	KeyWaitPress_OnBoard("Mandatory Directives", "10");
        	KeyWaitPress_OnBoard("Bulletins", "10");
        	KeyWaitPress_OnBoard("View Bulletins", "10");
        	KeyWaitPress_OnBoard("View Item", "10");
        	
        	string result = OCRValidation_OnBoard(ocrText, functionalArea, zoom, validateExists);
        	KeyWaitPress_OnBoard("View List", "10");
        	KeyWaitPress_OnBoard("Return", "10");
        	KeyWait_OnBoard("Mandatory Directives", "10");
        	
        	return result;
        	
        }
    }
    
    
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class LogFunctions
    {
        public static OnBoard.OnBoardRepository OnBoardRepo = OnBoard.OnBoardRepository.Instance;
        
        /// <summary>
        /// This popup is created for user to perform BOS validations in the tests and note the pass or fail result
        /// </summary>
        /// <param name="userComments"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static string PopupForBOSValidations(string userComments)
        {
            var prompt = new System.Windows.Forms.Form
            {
                Width = 600,
                Height = 400,
                FormBorderStyle = FormBorderStyle.Sizable,
                Text = "Please Check Comments for Validation Steps to Perform",
                StartPosition = FormStartPosition.CenterScreen,
            };

            var textLabel = new Label
            {
                Left = 10,
                Padding = new Padding(0, 0, 0, 3),
                Text = "Validation Steps",
                Dock = DockStyle.Top
            };

            var textBox = new TextBox
            {
                Left = 4,
                Top = 15,
                Width = prompt.Width - 24,
                Height = prompt.Height - 120,
                Anchor = AnchorStyles.Left,
                Text = userComments,
                Multiline = true,
            };

            textBox.WordWrap = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.AcceptsReturn = true;
            textBox.Enabled = false;
            
            var passButton = new System.Windows.Forms.Button
            {
                Text = @"Pass",
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Yes,
                Dock = DockStyle.Bottom,
            };
            passButton.Click += (sender, e) =>
            {
                prompt.Close();
            };
            var failButton = new System.Windows.Forms.Button
            {
                Text = @"Fail",
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.No,
                Dock = DockStyle.Bottom,
            };

            failButton.Click += (sender, e) =>
            {
                prompt.Close();
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(passButton);
            prompt.Controls.Add(failButton);
            prompt.Controls.Add(textLabel);
            
            if(prompt.ShowDialog() == DialogResult.Yes)
            {
            	return "Success: "+textBox.Text;
            }
            else
            {
            	Report.Failure("No "+textBox.Text);
            	return "Failure: "+textBox.Text;
            }

            //return "Success: ";
        }
        /// <summary>
        /// Override Governing Signal from the Debug form
        /// </summary>
        [UserCodeMethod]
        public static string OverrideGoverningSignal_Debug()
        {
        	//partial tested
            if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return "Error: Debug Client is not open, can't override governing signal";
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.DebugButtonInfo, OnBoardRepo.Debug_Client.DebugMenu.SelfInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.DebugMenu.GenericInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo.Exists(0))
            {
                if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
                {
                    return "Error: Unable to open Debug Client Session from Debug Client";
                }
                
                OnBoardRepo.Description = "Signal Authority Pages...";
                if (!OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.SelfInfo.Exists(0))
                {
                    //close the form
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
                    return "Error: Debug Client Session not populated with Signal Authority Pages";
                }
                PDS_CORE.Code_Utils.GeneralUtilities.DoubleClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.DescriptionInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo);
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
                return "Error: Signal Authority Pages could not be opened from the Debug Client Session Form";
            }
            
            OnBoardRepo.Description = "Current Governing Signal";
            PDS_CORE.Code_Utils.GeneralUtilities.DoubleClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SignalAuthorityPagesTable.SignalAuthorityPagesTableRowByDescription.DescriptionInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.Current_Governing_Signal.SelfInfo);
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.Current_Governing_Signal.SelfInfo.Exists(0))
            {
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo);
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
                return "Error: Current Governing Signal could not be opened from the Signal Authority Pages Form";
            }
            
            //TODO Click the Override Governing Signal Button
            //Also see if there is any indication that current signal has in fact been Overridden
            OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.Current_Governing_Signal.Button4.Click();
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.Current_Governing_Signal.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.Current_Governing_Signal.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
            
            
            return "Info: Overrode Governing Signal";
        }
        
        /// <summary>
        /// Set Switch Position to Normal or Reverse from the Debug form
        /// It is alternate method of using FTT tool
        /// </summary>
        [UserCodeMethod]
        public static string SetSwitchPosition_DebugClient(string position, string enableOrDisable)
        {
        	bool enableOrDisableSwitch = false;
            
            if(!Boolean.TryParse(enableOrDisable, out enableOrDisableSwitch))
            {
            	return "Error: Invalid Enable Or Disable Switch Param";
            }
        	//partial tested
            if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return "Error: Debug Client is not open, can't override governing signal";
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.DebugButtonInfo, OnBoardRepo.Debug_Client.DebugMenu.SelfInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.DebugMenu.GenericInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Signal_Authority_Pages.SelfInfo.Exists(0))
            {
                if (!OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
                {
                    return "Error: Unable to open Debug Client Session from Debug Client";
                }
                
                OnBoardRepo.Description = "Switch Manager";
                if (!OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.SelfInfo.Exists(0))
                {
                    //close the form
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
                    return "Error: Debug Client Session not populated with Signal Authority Pages";
                }
                PDS_CORE.Code_Utils.GeneralUtilities.DoubleClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.DebugClientSessionTable.DebugClientSessionTableRowByDescription.DescriptionInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.SelfInfo);
            }
            
            if (!OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
                return "Error: Signal Authority Pages could not be opened from the Debug Client Session Form";
            }
            
            //Navigate to Switch Test Page tab
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.SwitchStatusTestPageTabInfo,
                                                                         OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button1Info);
            
            switch(position.ToLower())
            {
            	case "normal":
            		OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button2.Click();
            		break;
            		
            	case "reverse":
            		OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button3.Click();
            		break;
            		
            	default: 
            		OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button1.Click();
            		break;
            }
            
            if(enableOrDisableSwitch)
            {
            	OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button4.Click();
            }
            else
            {
            	OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.Button5.Click();
            }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Switch_Manager_Display.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
            
            
            return "Info: Setting the Switch Position from Debug Client";
        }
        
        /// <summary>
        /// Sets the logging level of an item in the log manager
        /// Example is setting the GPS level to 5
        /// </summary>
        [UserCodeMethod]
        public static string ValidateDiagnosticSystemItemSummary_LogManager(string diagnosticSystemItem, string summary)
        {
        	if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return "Error: Debug Client is not open, can't validate Diagnostic System Summary Item";
            }
        	
        	if (!OnBoardRepo.Debug_Client.Diagnostic_Client_Session.SelfInfo.Exists(0))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.DiagnosticsButtonInfo, OnBoardRepo.Debug_Client.DiagnosticsMenu.SelfInfo);
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.DiagnosticsMenu.GenericInfo, OnBoardRepo.Debug_Client.Diagnostic_Client_Session.SelfInfo);
        	}
        	
        	if (!OnBoardRepo.Debug_Client.Diagnostic_Client_Session.SelfInfo.Exists(0))
            {
                return "Error: Could not open Diagnostics Client Session window, can't validate Diagnostic System Summary Item";
            }
        	
        	OnBoardRepo.DiagnosticClientSessionDescription = diagnosticSystemItem;
        	int retries = 0;
        	while (!OnBoardRepo.Debug_Client.Diagnostic_Client_Session.DiagnosticClientSessionTable.DiagnosticClientSessionTableRowByDiagnosticClientSessionDescription.SelfInfo.Exists(0) && retries < 3)
        	{
        		retries++;
        		Ranorex.Delay.Milliseconds(500);
        	}
        	if (!OnBoardRepo.Debug_Client.Diagnostic_Client_Session.DiagnosticClientSessionTable.DiagnosticClientSessionTableRowByDiagnosticClientSessionDescription.SelfInfo.Exists(0))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Diagnostic_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Diagnostic_Client_Session.SelfInfo);
        		return "Error: Could not find row with summary of {" + diagnosticSystemItem + "}, can't validate Diagnostic System Summary Item";
        	}
        	
        	string summaryText = OnBoardRepo.Debug_Client.Diagnostic_Client_Session.DiagnosticClientSessionTable.DiagnosticClientSessionTableRowByDiagnosticClientSessionDescription.Summary.Text;
        	
        	string returnString = "";
        	Regex newTestRegex = new Regex(@summary);
            //Check if it exists
            bool regexExists = newTestRegex.IsMatch(summaryText);
            if (regexExists)
            {
                returnString = "Success: Found summary {" + @summary + "} for Diagnostic Item {" + diagnosticSystemItem + "}.";
            } else {
            	returnString = "Failure: Did not find summary {" + @summary + "} for Diagnostic Item {" + diagnosticSystemItem + "}. Summary found was {" + summaryText + "}";
            }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Diagnostic_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Diagnostic_Client_Session.SelfInfo);
            return returnString;
        }
        
        /// <summary>
        /// Sets the logging level of an item in the log manager
        /// Example is setting the GPS level to 5
        /// </summary>
        [UserCodeMethod]
        public static string SetLoggingLevel_LogManager(string category, string level)
        {
        	//tested
            if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return "Error: Debug Client is not open, can't set logging for category {" + category + "} to level {" + level + "}";
            }
            
            if (!OnBoardRepo.Debug_Client.Log_Manager.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.MainMenuBar.LogButtonInfo, OnBoardRepo.Debug_Client.LogMenu.SelfInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.LogMenu.ManagerInfo, OnBoardRepo.Debug_Client.Log_Manager.SelfInfo);
            }
            
            if (!OnBoardRepo.Debug_Client.Log_Manager.SelfInfo.Exists(0))
            {
                return "Error: Log Manager could not be opened from the Debug Client";
            }
            
            OnBoardRepo.ObjectName = category;
            if (!OnBoardRepo.Debug_Client.Log_Manager.LogManagerTable.LogManagerTableRowByObjectName.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Log_Manager.SelfInfo);
                return "Error: Could not find Category {" + category + "} in the Log Manager Table";
            }
            
            OnBoardRepo.Debug_Client.Log_Manager.LogManagerTable.LogManagerTableRowByObjectName.ObjectName.DoubleClick();
            
            if (!OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.SelfInfo.Exists(0))
            {
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Log_Manager.SelfInfo);
                return "Error: Could not open Log Severity Form for Object Name {" + category + "}.";
            }
            
            OnBoardRepo.LogLevelText = level;
            
            if (!OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.LogLevelList.LogLevelListItemByLogLevelTextInfo.Exists(0))
            {
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.SelfInfo);
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Log_Manager.SelfInfo);
            	return "Error: Could not find log level {" + level + "} in Log Severity Form for Object Name {" + category + "}.";
            }
            
            if (!OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.LogLevelList.LogLevelListItemByLogLevelText.GetAttributeValue<bool>("Selected"))
            {
            	OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.LogLevelList.LogLevelListItemByLogLevelText.Click();
            }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.OkButtonInfo, OnBoardRepo.Debug_Client.Log_Manager.Log_Severity.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Log_Manager.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Log_Manager.SelfInfo);
            
            return "Info: Set logging Level for {" + category + "} to level " + level + " in Log Manager";
        }
        
        /// <summary>
        /// Turns logging on for reading the status of the onboard
        /// </summary>
        [UserCodeMethod]
        public static string TurnOnboardLoggingOn_LogManager()
        {
        	//tested
            if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return "Error: Debug Client is not open, can't open log manager to start log recording";
            }
            
            if (OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo.Exists(0))
            	{
            		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.Comparator_Form.SelfInfo);
            	}
            	
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Debug_Client_Session.WindowControls.CloseInfo, OnBoardRepo.Debug_Client.Debug_Client_Session.SelfInfo);
            }
            
            if (CheckOnboardLoggingOn_LogManager())
            {
            	OnBoardRepo.Debug_Client.RibbonMenu.Record.Click();
            }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Debug_Client.RibbonMenu.RecordInfo, OnBoardRepo.Debug_Client.Save_As.SelfInfo);
            
            OnBoardRepo.Debug_Client.Save_As.SaveButton.Click();
            
            int retries = 0;
            while (!OnBoardRepo.Debug_Client.Save_As.Confirm_Save_As.SelfInfo.Exists(0) && retries < 2)
            {
            	Ranorex.Delay.Milliseconds(500);
            	retries++;
            }
            
            if (OnBoardRepo.Debug_Client.Save_As.Confirm_Save_As.SelfInfo.Exists(0))
            {
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Debug_Client.Save_As.Confirm_Save_As.YesButtonInfo, OnBoardRepo.Debug_Client.Save_As.Confirm_Save_As.SelfInfo);
            }
            
            LogAgentLoop.StartLogAgent();
            
            //Check if any buttons are currently stored, if not, we will hope it's at a Menu 1/Main and click that button twice
            bool buttonsSet = false;
            foreach (string button in LogAgentLoop.buttons)
            {
            	if (!button.IsEmpty())
            	{
            		buttonsSet = true;
            		break;
            	}
            }
            
            if (!buttonsSet)
            {
            	OnBoardRepo.Onboard_Form.Self.Click(OnBoardFunctions.button8xy);
            	Ranorex.Delay.Seconds(1);
            	OnBoardRepo.Onboard_Form.Self.Click(OnBoardFunctions.button8xy);
            }
            
            return "Info: Turned on Logging in Log Manager";
        }
        
        /// <summary>
        /// Checks if logging for the onboard log manager is on
        /// </summary>
        public static bool CheckOnboardLoggingOn_LogManager()
        {
            if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
            {
                return false;
            }
            
            return OnBoardRepo.Debug_Client.RibbonMenu.Record.GetAttributeValue<bool>("Checked");
        }
        
        /// <summary>
        /// Turns logging off for reading the status of the onboard
        /// </summary>
        [UserCodeMethod]
        public static string TurnOnboardLoggingOff_LogManager()
        {
        	//tested
        	if (!OnBoardRepo.Debug_Client.SelfInfo.Exists(0))
        	{
        		return "Error: Debug Client is not open, can't open log manager to start log recording";
        	}
        	
        	LogAgentLoop.StopLogAgent();
        	
        	if (CheckOnboardLoggingOn_LogManager())
        	{
        		OnBoardRepo.Debug_Client.RibbonMenu.Record.Click();
        	}
        	
        	return "Info: Turned off Logging in Log Manager";
        }
        
        /// <summary>
        /// Validates Message was sent via the Log CDU logs
        /// </summary>
        [UserCodeMethod]
        public static string ValidateMessageSent_LogManager(string message, string timeFrameInSeconds = "180")
        {
        	//Default Check time of 30 seconds
            int timeFrameInSecondsInt = 0;
            if (!int.TryParse(timeFrameInSeconds, out timeFrameInSecondsInt))
            {
                return "Failure: [" + timeFrameInSeconds + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(30);
            bool foundMessage = false;
            while (!foundMessage && System.DateTime.Now < timeLimit)
            {
            	System.DateTime currentTimeMinusTimeFrame = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt * -1);
            	if (LogAgentLoop.messageTimeStamps.ContainsKey(message))
            	{
            		if (LogAgentLoop.messageTimeStamps[message].First.Value > currentTimeMinusTimeFrame)
	            	{
	            		foundMessage = true;
	            		break;
	            	}
            	}
            }
            
            if (!foundMessage)
            {
                return "Failure: No [" + message + "] Messages found within {" + timeFrameInSeconds + "} second timeframe";
            } else {
	            return "Success: [" + message + "] Message found within {" + timeFrameInSeconds + "} second timeframe";
            }
        }
        
        /// <summary>
        /// Validates Message was received via the Log CDU logs
        /// </summary>
        [UserCodeMethod]
        public static string ValidateMessageReceived_LogManager(string message, string timeFrameInSeconds = "180")
        {
            //Default Check time of 30 seconds
            int timeFrameInSecondsInt = 0;
            if (!int.TryParse(timeFrameInSeconds, out timeFrameInSecondsInt))
            {
                return "Failure: [" + timeFrameInSeconds + "] Could not be converted to an integer";
            }
            
            System.DateTime timeLimit = System.DateTime.Now.AddSeconds(30);
            bool foundMessage = false;
            while (!foundMessage && System.DateTime.Now < timeLimit)
            {
            	System.DateTime currentTimeMinusTimeFrame = System.DateTime.Now.AddSeconds(timeFrameInSecondsInt * -1);
            	if (LogAgentLoop.messageTimeStamps.ContainsKey(message))
            	{
            		if (LogAgentLoop.messageTimeStamps[message].First.Value > currentTimeMinusTimeFrame)
	            	{
	            		foundMessage = true;
	            		break;
	            	}
            	}
            }
            
            if (!foundMessage)
            {
                return "Failure: No [" + message + "] Messages found within {" + timeFrameInSeconds + "} second timeframe";
            } else {
	            return "Success: [" + message + "] Message found within {" + timeFrameInSeconds + "} second timeframe";
            }
        }
    }
    
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class MotionControl
    {
        public static OnBoard.OnBoardRepository OnBoardRepo = OnBoard.OnBoardRepository.Instance;
        
        public static void OpenMotionControl_MotionControl()
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.MainMenuBar.MotionButtonInfo, OnBoardRepo.Loco_Simulator.MotionMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.MotionMenu.ControlsInfo, OnBoardRepo.Motion_Control.SelfInfo);
        	return;
        }
        
        /// <summary>
        /// Set Position on track for Onboard
        /// </summary>
        [UserCodeMethod]
        public static string SetPosition_MotionControl(string subdivision, string position, string track = "", string isPositionDecimal = "false")
        {
            bool isPositionDecimalBool = true;
            if (!bool.TryParse(isPositionDecimal, out isPositionDecimalBool))
            {
                return "Error: SetPosition_MotionControl got a isPositionDecimal value of {"+ isPositionDecimal + "} which could not be converted into a bool";
            }
            
            if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
            	{
            		OpenMotionControl_MotionControl();
            	} else {
            		return "Error: Motion Control form cannot be opened, Loco Simulator is not open";
            	}
            }
            
            if (OnBoardRepo.Motion_Control.SetPosition.Sub.SubText.SelectedItemText != "NS:"+subdivision)
            {
            	OnBoardRepo.Sub = subdivision;
            	if (!OnBoardRepo.Motion_Control.SetPosition.Sub.SubText.Enabled)
            	{
            		WinForms.MessageBox.Show("The subdivision field on the Motion Control form is disabled, please fix then press ok.", "Error",
		                                         WinForms.MessageBoxButtons.OK);
            	}
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Motion_Control.SetPosition.Sub.SubTextInfo, OnBoardRepo.Motion_Control.SetPosition.Sub.SubList.SelfInfo);
            	if (!OnBoardRepo.Motion_Control.SetPosition.Sub.SubList.SubListItemBySubInfo.Exists(0))
            	{
            		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.SetPosition.Sub.SubTextInfo, OnBoardRepo.Motion_Control.SetPosition.Sub.SubList.SelfInfo);
            		return "Error: Could not find NS:" + subdivision + " in the Motion Control subdivision list";
            	}
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.SetPosition.Sub.SubList.SubListItemBySubInfo, OnBoardRepo.Motion_Control.SetPosition.Sub.SubList.SelfInfo);
            }
            
            if (OnBoardRepo.Motion_Control.SetPosition.Offset.OffsetText.SelectedItemText != "MP")
            {
            	OnBoardRepo.OffsetType = "MP";
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Motion_Control.SetPosition.Offset.OffsetTextInfo, OnBoardRepo.Motion_Control.SetPosition.Offset.OffsetList.SelfInfo);
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.SetPosition.Offset.OffsetList.OffsetListItemByOffsetTypeInfo, OnBoardRepo.Motion_Control.SetPosition.Offset.OffsetList.SelfInfo);
            }
            
            if (OnBoardRepo.Motion_Control.SetPosition.DistanceText.TextValue != position)
            {
            	OnBoardRepo.Motion_Control.SetPosition.DistanceText.Click();
            	OnBoardRepo.Motion_Control.SetPosition.DistanceText.Element.SetAttributeValue("Text", position);
            	OnBoardRepo.Motion_Control.SetPosition.DistanceText.PressKeys("{TAB}");
            }
            
            if (OnBoardRepo.Motion_Control.SetPosition.DecCheckbox.Checked != isPositionDecimalBool)
            {
            	OnBoardRepo.Motion_Control.SetPosition.DecCheckbox.Click();
            }
            
            OnBoardRepo.Motion_Control.SetPosition.SetButton.Click();
            
            int retries = 0;
            while (!OnBoardRepo.Motion_Control.Select_Milepost.SelfInfo.Exists(0) && retries < 2)
            {
            	Ranorex.Delay.Milliseconds(500);
            	retries++;
            }
            
            if (OnBoardRepo.Motion_Control.Select_Milepost.SelfInfo.Exists(0))
            {
            	if (!OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostText.SelectedItemText.Contains(track))
            	{
            		OnBoardRepo.Track = track;
            		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostTextInfo, OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostList.SelfInfo);
            		if (OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostList.SelectMilepostListItemByTrackInfo.Exists(0))
            		{
            			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostList.SelectMilepostListItemByTrackInfo, OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostList.SelfInfo);
            		} else {
            			//if the track we want doesn't exist, just select whatever is currently selected
            			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostTextInfo, OnBoardRepo.Motion_Control.Select_Milepost.SelectMilepost.SelectMilepostList.SelfInfo);
            			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.Select_Milepost.SelectButtonInfo, OnBoardRepo.Motion_Control.Select_Milepost.SelfInfo);
            			return "Error: Could not select track of {" + track + "} in SetPosition Track Selection because it could not be found in the list. Selected default";
            		}
            	}
            	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Motion_Control.Select_Milepost.SelectButtonInfo, OnBoardRepo.Motion_Control.Select_Milepost.SelfInfo);
            }
            
            return "Info: Set Train Position in Motion Control";
        }
        
        /// <summary>
        /// Set Speed on track for Onboard
        /// </summary>
        [UserCodeMethod]
        public static string SetSpeed_MotionControl(string speed)
        {
        	if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
            	{
            		OpenMotionControl_MotionControl();
            	} else {
            		return "Error: Motion Control form cannot be opened, Loco Simulator is not open";
            	}
            }
            
            OnBoardRepo.Motion_Control.SpeedControls.MPH.MPHText.Element.SetAttributeValue("Text", speed);
            OnBoardRepo.Motion_Control.SpeedControls.MPH.MPHText.PressKeys("{TAB}");
            
            OnBoardRepo.Motion_Control.SpeedControls.SetButton.Click();
            return "Info: Set speed to {" + speed + "}.";
        }
        
        
        /// <summary>
        /// Set Speed on track for Onboard
        /// </summary>
        [UserCodeMethod]
        public static string OverridePressureBrake_MotionControl(string boolCheck)
        {
        	if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
            	{
            		OpenMotionControl_MotionControl();
            	} else {
            		return "Error: Motion Control form cannot be opened, Loco Simulator is not open";
            	}
            }
        	bool userCheck = false;
        	if(!Boolean.TryParse(boolCheck, out userCheck))
        	{
        		return "Error: boolCheck value is not a boolean value";
        	}
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.MainMenuBar.LocomotiveButtonInfo,
        	                                                              OnBoardRepo.Loco_Simulator.LocomotiveMenu.SelfInfo);
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.LocomotiveMenu.CSM.SelfInfo,
        	                                                              OnBoardRepo.Loco_Simulator.LocomotiveMenu.CSM.CSMMenu.SelfInfo);
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Loco_Simulator.LocomotiveMenu.CSM.CSMMenu.ViewInfo,
        	                                                              OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.SelfInfo);
        	
        	bool brakePipeCheckState = OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.TamperSwitchOpenCheckbox.Checked;
        	
        	if(userCheck != brakePipeCheckState)
        	{
        		if(userCheck)
        		{
        			PDS_CORE.Code_Utils.GeneralUtilities.CheckCheckboxAndVerifyChecked(OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.TamperSwitchOpenCheckbox);
        		}
        		else
        		{
        			PDS_CORE.Code_Utils.GeneralUtilities.UnCheckCheckboxAndVerify(OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.TamperSwitchOpenCheckbox);
        		}
        		
        		PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.UpdateButtonInfo,
        		                                                                          OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.UpdateButtonInfo);
        		
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.CloseButtonInfo,
        		                                                                      OnBoardRepo.Loco_Simulator.IOCCabSignalMonitor.SelfInfo);
        		
        		return "Info: Brake Pipe set to the appropriate state";
        	}
        	else
        	{
        		return "Info: Brake Pipe Already in the user desired state";
        	}
        	
        	
            
        }
        
        /// <summary>
        /// Set Speed on track for Onboard
        /// </summary>
        [UserCodeMethod]
        public static string SetReverser_MotionControl(string reverser)
        {
        	if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
            	{
            		OpenMotionControl_MotionControl();
            	} else {
            		return "Error: Motion Control form cannot be opened, Loco Simulator is not open";
            	}
            }
        	
        	switch(reverser.ToLower())
        	{
        		case "fwd":
        			OnBoardRepo.Motion_Control.Reverser.ForwardRadioButton.Click();
        			break;
        		case "centered":
        			OnBoardRepo.Motion_Control.Reverser.CenteredRadioButton.Click();
        			break;
        		case "rev":
        			OnBoardRepo.Motion_Control.Reverser.ReverseRadioButton.Click();
        			break;
        			
        		default:
        			return "Error: Invalid reverser position";
        	}
            
            return "Info: Set Reverser to {" + reverser + "}.";
        }
        
        /// <summary>
        /// Set Speed on track for Onboard
        /// </summary>
        [UserCodeMethod]
        public static string StopTrain_MotionControl()
        {
        	if (!OnBoardRepo.Motion_Control.SelfInfo.Exists(0))
            {
            	if (OnBoardRepo.Loco_Simulator.SelfInfo.Exists(0))
            	{
            		OpenMotionControl_MotionControl();
            	} else {
            		return "Error: Motion Control form cannot be opened, Loco Simulator is not open";
            	}
            }
            
            OnBoardRepo.Motion_Control.SpeedControls.StopButton.Click();
            return "Info: Stopped Train by clicking Stop on Motion Control.";
        }
        
        /// <summary>
        /// Waits for speed in Log Manger to show a particular value (if below current speed wait until equal or greater and vis-versa)
        /// Has maximum wait time of 15 minutes
        /// </summary>
        [UserCodeMethod]
        public static string SpeedWait_MotionControl(string speed)
        {
            float speedFloat = 0;
            if (!float.TryParse(speed, out speedFloat))
            {
                return "Failure: [" + speed + "] Could not be converted to a float";
            }
            
            System.DateTime cutOffTime = System.DateTime.Now.AddMinutes(12);
            
            bool speedMet = false;
            bool descendingSpeed = false;
            if (float.Parse(OnBoardRepo.Motion_Control.MotionStatus.CurrentSpeedText.TextValue) > speedFloat)
            {
                descendingSpeed = true;
            }
            while (!speedMet && (System.DateTime.Now < cutOffTime))
            {
                float currentSpeed = float.Parse(OnBoardRepo.Motion_Control.MotionStatus.CurrentSpeedText.TextValue);
                if (descendingSpeed)
                {
                    if (currentSpeed <= speedFloat)
                    {
                        speedMet = true;
                        break;
                    }
                } else {
                    if (currentSpeed >= speedFloat)
                    {
                        speedMet = true;
                        break;
                    }
                }
            }
            
            if (!speedMet)
            {
                return "Error: Speed of {" + speed + "} was not met within 12 minutes";
            }
            
            return "Info: Met speed of {" + speed + "}";
        }
        
        /// <summary>
        /// Waits for MP in Log Manger to show a particular value
        /// Has maximum wait time of 10 minutes
        /// </summary>
        [UserCodeMethod]
        public static string MPWait_MotionControl(string milePost, string direction)
        {
            float mpFloat = 0;
            if (!float.TryParse(milePost, out mpFloat))
            {
                return "Failure: [" + milePost + "] Could not be converted to a float";
            }
            
            System.DateTime cutOffTime = System.DateTime.Now.AddMinutes(10);
            LogAgentLoop.skipLog = true;
            Ranorex.Report.Info("Skipping Log True");
            bool mpMet = false;
            StringBuilder currentMilePostString = new StringBuilder();
            float milePostValue = 0f;
            while (!mpMet && (System.DateTime.Now < cutOffTime))
            {
            	//currentMP.Append(OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue);
                
            	currentMilePostString.Append(Regex.Replace(OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue, "[a-zA-Z]", ""));
//                for (int i = 0; i<currentMP.Length;i++)
//                {
//                	if(!Char.IsLetter(currentMP[i]))
//                	{
//                		currentMilePostString += currentMP[i];
//                	}
//                }
				Ranorex.Report.Info("Current Milepost: "+currentMilePostString.ToString());
                if(!float.TryParse(currentMilePostString.ToString(), out milePostValue))
                {
                	LogAgentLoop.readLog = true;
                	return "Failure: [" + currentMilePostString + "] Value Extracted from Motion Control Could not be converted to a float";
                }
                
                if(direction.ToLower().Equals("up") && milePostValue >= mpFloat)
                {
                	mpMet = true;
                }
                else if(direction.ToLower().Equals("down") && milePostValue <= mpFloat)
                {
                	mpMet = true;
                }
                else
                {
                	mpMet = false;
                }
                
                Ranorex.Delay.Seconds(3);
                currentMilePostString.Clear();
            	milePostValue = 0f;
            }
            LogAgentLoop.skipLog = false;
            Ranorex.Report.Info("Skipping Log False");
            if (!mpMet)
            {
                return "Error: MP of {" + milePost + "} was not met within 10 minutes";
            }
            
            return "Info: Met MP of {" + milePost + "}";
        }
        
        /// <summary>
        /// Waits for MP in Log Manger to show a particular value
        /// Has maximum wait time of 10 minutes
        /// </summary>
        [UserCodeMethod]
        public static string MPVerify_MotionControl(string milePost, string threshold)
        {
            float mpFloat = 0;
            if (!float.TryParse(milePost, out mpFloat))
            {
                return "Failure: [" + milePost + "] Could not be converted to a float";
            }
            
            float mpThresholdFloat = 0;
            if (!float.TryParse(threshold, out mpThresholdFloat))
            {
                return "Failure: [" + threshold + "] Could not be converted to a float";
            }
            
            System.DateTime cutOffTime = System.DateTime.Now.AddMinutes(10);
            
            bool mpMet = false;
           
            
            string currentMP = OnBoardRepo.Motion_Control.CurrentPosition.MilepostText.TextValue;
            
            string currentMilePostString = "";
            for (int i = 0; i<currentMP.Length;i++)
            {
            	if(!Char.IsLetter(currentMP[i]))
            	{
            		currentMilePostString += currentMP[i];
            	}
            }
            float milePostValue = 0f;
            if(!float.TryParse(currentMilePostString, out milePostValue))
            {
            	return "Failure: [" + currentMilePostString + "] Value Extracted from Motion Control Could not be converted to a float";
            }
            
            if((mpFloat >= (milePostValue-mpThresholdFloat)) && (mpFloat <= (milePostValue+mpThresholdFloat)))
            {
            	mpMet = true;
            }
            
            if (!mpMet)
            {
                return "Error: MP of {" + milePost + "} was not verified within 10 minutes";
            }
            
            return "Info: Met MP of {" + milePost + "}";
        }
    
    }
    
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class FieldSimulator
    {
        public static OnBoard.OnBoardRepository OnBoardRepo = OnBoard.OnBoardRepository.Instance;
        
        /// <summary>
        /// Opens the Field Simulator
        /// </summary>
        [UserCodeMethod]
        public static void OpenFieldSimulator_FieldSimulator()
        {
        	//tested
        	if (OnBoardRepo.Field_Simulator.SelfInfo.Exists(0))
        	{
        		return;
        	}
        	
        	string fieldSimulatorExecutableLocation = "";
        	try {
                fieldSimulatorExecutableLocation = TestSuite.Current.Parameters["FieldSimulatorExecutableLocation"];
        	} catch {
        		
        	}
        	
        	if (!System.IO.File.Exists(fieldSimulatorExecutableLocation+@"Field Simulator.exe"))
        	{
        		return;
        	}
        	
        	string fttFileName = fieldSimulatorExecutableLocation+@"Field Simulator.exe";
        	Process startProcess = new Process();
        	ProcessStartInfo startProcessInfo = new ProcessStartInfo();
        	startProcessInfo.UseShellExecute = false;
        	startProcessInfo.WorkingDirectory = fieldSimulatorExecutableLocation;
        	startProcessInfo.FileName = fttFileName;
        	Ranorex.Report.Info("Before Starting the FTT");
        	startProcess = Process.Start(startProcessInfo);
        	startProcess.WaitForExit(30000);
        	startProcess.Close();
        	startProcess.Dispose();
        	Ranorex.Report.Info("FTT Completely started");
        	        	
        	int retries = 0;
        	while (!OnBoardRepo.Field_Simulator.SelfInfo.Exists(0) && retries < 4)
        	{
        		Ranorex.Delay.Seconds(1);
        		retries++;
        	}
        	
        }
        
        /// <summary>
        /// Opens, loads, and starts a Field Simulator scenario
        /// </summary>
        [UserCodeMethod]
        public static string StartAndLoadFieldSimulatorScenario_FieldSimulator(string scenarioFileName)
        {
        	//tested
        	string fieldSimulatorScenarioFileLocation = "";
        	try {
                fieldSimulatorScenarioFileLocation = TestSuite.Current.Parameters["FieldSimulatorScenarioFileLocation"];
        	} catch {
        		
        	}
        	
        	if (!System.IO.Directory.Exists(fieldSimulatorScenarioFileLocation))
            {
        		return "Error: Directory does not exist for Field Simulator scenarios {" + fieldSimulatorScenarioFileLocation + "}.";
        	}
        	
        	string fieldSimulatorScenarioPath = fieldSimulatorScenarioFileLocation + scenarioFileName;
        	
        	if (!System.IO.File.Exists(fieldSimulatorScenarioPath))
        	{
        		return "Error: Missing Field Simulator file {" + fieldSimulatorScenarioPath + "}";
        	}
        	
        	OpenFieldSimulator_FieldSimulator();
        	Ranorex.Report.Info("Completed Opening Field Sumulator");
        	if (!OnBoardRepo.Field_Simulator.SelfInfo.Exists(0))
        	{
        		return "Error: Field Simulator could not be opened";
        	}
        	
        	if (OnBoardRepo.Field_Simulator.RibbonMenu.StopButton.Enabled)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(OnBoardRepo.Field_Simulator.RibbonMenu.StopButtonInfo, OnBoardRepo.Field_Simulator.RibbonMenu.StopButtonInfo);
        	}
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.MainMenuBar.FileButtonInfo, OnBoardRepo.Field_Simulator.FileMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.FileMenu.LoadScenarioInfo, OnBoardRepo.Field_Simulator.Load_Scenario.SelfInfo);
        	
        	if (!OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarText.GetAttributeValue<string>("Text").Equals(fieldSimulatorScenarioFileLocation, StringComparison.OrdinalIgnoreCase))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarDropdownButtonInfo, OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarDropdownMenu.SelfInfo);
        		OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarText.Element.SetAttributeValue("Text", fieldSimulatorScenarioFileLocation);
        		OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarText.PressKeys("{ENTER}");
        	} else {
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarDropdownButtonInfo, OnBoardRepo.Field_Simulator.Load_Scenario.Navigation.NavigationBarDropdownMenu.SelfInfo);
        	}
        	
        	OnBoardRepo.FileName = scenarioFileName;
        	if (!OnBoardRepo.Field_Simulator.Load_Scenario.FileList.FileListItemByFileNameInfo.Exists(0))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.Load_Scenario.CancelButtonInfo, OnBoardRepo.Field_Simulator.Load_Scenario.SelfInfo);
        		return "Error: Could not find file {" + fieldSimulatorScenarioPath + "} in file window of Field Simulator, probable Ranorex click malfunction";
        	}
        	
        	OnBoardRepo.Field_Simulator.Load_Scenario.FileList.FileListItemByFileName.Click();
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.Load_Scenario.OpenButtonInfo, OnBoardRepo.Field_Simulator.Load_Scenario.SelfInfo);
        	
        	//Gotta wait for the file to load
        	Ranorex.Delay.Seconds(10);
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(OnBoardRepo.Field_Simulator.RibbonMenu.RunButtonInfo, OnBoardRepo.Field_Simulator.RibbonMenu.RunButtonInfo);
        	Ranorex.Delay.Seconds(10);
        	return "Info: Loaded and started scenario {" + fieldSimulatorScenarioPath + "} in Field Simulator";
        }
        
        /// <summary>
        /// Set an FTT device to a particular state, like switch or signal
        /// </summary>
        [UserCodeMethod]
        public static string SetFTTDevice_FieldSimulator(string wiu, string deviceType, string device, string state)
        {
            OnBoardRepo.WIUIdNumber = wiu;
            if (!OnBoardRepo.Field_Simulator.WIUByWIUIdNumberInfo.Exists(0))
            {
                WinForms.MessageBox.Show("WIU {" + wiu + "} not found, please ensure the correct Field Simulator Scenario is loaded and running", "Error",
                                         WinForms.MessageBoxButtons.OK);
            }
            HashSet<Color> colorsFound = new HashSet<Color>();
        	Bitmap wiuBitmap = Ranorex.Imaging.CaptureImage(OnBoardRepo.Field_Simulator.WIUByWIUIdNumber.Element);
        	Color wiuGreen = PDS_CORE.Code_Utils.PDSColors.GetColorFromString("Green");
        	
        	colorsFound = PDS_CORE.Code_Utils.GeneralUtilities.GetColorsFromBitmap(wiuBitmap);
        	bool colorInHashSet = colorsFound.Contains(wiuGreen);
        	if (!colorInHashSet)
        	{
        		WinForms.MessageBox.Show("WIU {" + wiu + "} was not found to be active. Please ensure the Field Simulator scenario is running and that the wiu addresses are configured correctly", "Error",
        	                             WinForms.MessageBoxButtons.OK);
        	}
        	
        	var deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2401SouthSignalInfo;
        	
        	switch(device.ToLower())
        	{
        	    case "2401southsignal":
        	    case "02401southsignal":
        			OnBoardRepo.Field_Simulator.AGSNorth.N2401SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2401SouthSignalInfo;
        	        break;
        	        
        	    case "2501southsignal":
        	    case "02501southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2501SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2501SouthSignalInfo;
        	        break;
        	        
        	    case "2601southsignal":
        	    case "02601southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2601SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2601SouthSignalInfo;
        	        break;
        	        
        	    case "2701southsignal":
        	    case "02701southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2701SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2701SouthSignalInfo;
        	        break;
        	        
        	    case "2801southsignal":
        	    case "02801southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2801SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2801SouthSignalInfo;
        	        break;
        	        
        	    case "2901southsignal":
        	    case "02901southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2901SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2901SouthSignalInfo;
        	        break;
        	        
        	    case "4201southsignal":
        	    case "04201southsignal":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N4201SouthSignal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N4201SouthSignalInfo;
        	        break;
        	        
        	    case "2401switch":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2401Switch.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2401SwitchInfo;
        	        break;
        	        
        	    case "2501switch":
        	        OnBoardRepo.Field_Simulator.AGSNorth.N2501Switch.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.AGSNorth.N2501SwitchInfo;
        	        break;
        	        
        	    case "00701northsignal":
        	        OnBoardRepo.Field_Simulator.RLine.N701Signal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.RLine.N701SignalInfo;
        	        break;
        	        
        	     case "00601northsignal":
        	        OnBoardRepo.Field_Simulator.RLine.N601Signal.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.RLine.N601SignalInfo;
        	        break;
        	        
        	    case "14801switch":
        	        OnBoardRepo.Field_Simulator.SCLine.N14801Switch.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.SCLine.N14801SwitchInfo;
        	        break;
        	        
        	    case "14901switch":
        	        OnBoardRepo.Field_Simulator.SCLine.N14901Switch.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.SCLine.N14901SwitchInfo;
        	        break;
        	        
        	    case "15001switch":
        	        OnBoardRepo.Field_Simulator.SCLine.N15001Switch.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.SCLine.N15001SwitchInfo;
        	        break;
        	        
        	    case "16101switch1":
        	        OnBoardRepo.Field_Simulator.SCLine.N16101Switch1.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.SCLine.N16101Switch1Info;
        	        break;
        	        
        	    case "16101switch2":
        	        OnBoardRepo.Field_Simulator.SCLine.N16101Switch2.EnsureVisible();
        	        deviceElement = OnBoardRepo.Field_Simulator.SCLine.N16101Switch2Info;
        	        break;
        	        
        	    default:
        	       return "Error: No device {" + device + "} found for the Field Simulator";
        	}
        	
        	if (deviceType.Equals("Switch", StringComparison.OrdinalIgnoreCase))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
        		switch(state.ToLower())
        		{
//        			case "normal":
//        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.NormalInfo, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
//        				break;
//        			case "reverse":
//        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.ReverseInfo, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
//        				break;
        			case "clearvalue":
        				if (!OnBoardRepo.Field_Simulator.SwitchMenu.ClearStateInfo.Exists(0))
        				{
        					Keyboard.Press(System.Windows.Forms.Keys.Escape);
        					//PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
        					return "Info: Device {" + device + "} is already in the clear state";
        				}
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.ClearStateInfo, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
        				break;
        			default:
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.SelfInfo, OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.ForceStateMenu.SelfInfo);
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.ForceStateMenu.ForcedStateSelectionListButtonInfo, OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.ForceStateMenu.ForcedStateSelectionList.SelfInfo);
        				
        				OnBoardRepo.ForcedStateName = state;
        				if (!OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.ForceStateMenu.ForcedStateSelectionList.ForcedStateValueSelectionListItemByForcedStateNameInfo.Exists(0))
        				{
        					PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
        					return "Error: Could not locate state {" + state.ToUpper() + "} in switch state menu in Field Simulator";
        				}
        				
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SwitchMenu.ForceState.ForceStateMenu.ForcedStateSelectionList.ForcedStateValueSelectionListItemByForcedStateNameInfo, OnBoardRepo.Field_Simulator.SwitchMenu.SelfInfo);
        				break;
        		}
        	} else if (deviceType.Equals("Signal", StringComparison.OrdinalIgnoreCase))
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SignalMenu.SelfInfo);
        		switch(state.ToLower())
        		{
        			case "clearvalue":
        				if (!OnBoardRepo.Field_Simulator.SignalMenu.ClearPTCValueInfo.Exists(0))
        				{
        					Keyboard.Press(System.Windows.Forms.Keys.Escape);
        					//PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SignalMenu.SelfInfo);
        					return "Info: Device {" + device + "} is already in the clear state";
        				}
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SignalMenu.ClearPTCValueInfo, OnBoardRepo.Field_Simulator.SignalMenu.SelfInfo);
        				break;
        			default:
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.SelfInfo, OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.ForcePTCValueMenu.SelfInfo);
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.ForcePTCValueMenu.ForcedPTCValueSelectionListButtonInfo, OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.ForcePTCValueMenu.ForcedPTCValueSelectionList.SelfInfo);
        				
        				OnBoardRepo.ForcedPTCName = state.ToUpper();
        				if (!OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.ForcePTCValueMenu.ForcedPTCValueSelectionList.ForcedPTCValueSelectionListItemByForcedPTCNameInfo.Exists(0))
        				{
        					PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(deviceElement, OnBoardRepo.Field_Simulator.SignalMenu.SelfInfo);
        					return "Error: Could not locate state {" + state.ToUpper() + "} in signal state menu in Field Simulator";
        				}
        				
        				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(OnBoardRepo.Field_Simulator.SignalMenu.ForcePTCValue.ForcePTCValueMenu.ForcedPTCValueSelectionList.ForcedPTCValueSelectionListItemByForcedPTCNameInfo, OnBoardRepo.Field_Simulator.SignalMenu.SelfInfo);
        				break;
        		}
        	} else {
        		return "Error: Device Type of {" + deviceType + "} is an invalid device selection for the Field Simulator";
        	}
        	
        	return "Info: Set Device {" + device + "} to state {" + state + "} in Field Simulator";
        }
    }
}
