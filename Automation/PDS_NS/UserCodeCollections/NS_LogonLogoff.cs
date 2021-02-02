/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/24/2018
 * Time: 9:38 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using PDS_CORE.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_LogonLogoff
    {
    	public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
    	public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
    	public static global::PDS_NS.TerritoryTransfer_Repo TerritoryTransferrepo = global::PDS_NS.TerritoryTransfer_Repo.Instance;
    	
    	/// <summary>
    	/// Logon to PDS NS Version
    	/// </summary>
    	/// <param name="userId">Input:userId</param>
    	/// <param name="password">Input:password</param>
    	/// <param name="closeForms">Input:Closes forms Audible Alert, Control Request List, and Dispatcher Transfer Report </param>
    	[UserCodeMethod]
    	public static void NS_LogonFunction(string userId, string password, bool closeForms)
    	{
    		int attempts = 0;
			while (!MainMenurepo.Network_Logon.SelfInfo.Exists(0) && !MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0) && attempts < 5)
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			
			if(!MainMenurepo.Network_Logon.SelfInfo.Exists(0) && !MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("PDS network logon form not found or did not reappear after log off");
    			string clientVersion = TestSuite.Current.Parameters["clientVersion"];
    			bool pdsLogonExists = PDS_CORE.Code_Utils.StartPDSUIUtils.mDriveUiStart(clientVersion);
    			if(pdsLogonExists)
    			{
    				Ranorex.Report.Info("Run-PDS batch file executed to bring up PDS UI");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Failed to bring up PDS UI using run-pds bat file");
    			}
    		}
    		MainMenurepo.Network_Logon.UserId.Click();
    		MainMenurepo.Network_Logon.UserId.Element.SetAttributeValue("Text", userId);
    		MainMenurepo.Network_Logon.UserId.PressKeys("{TAB}");
    		
    		MainMenurepo.Network_Logon.Role.PressKeys("{TAB}");
    		
    		MainMenurepo.Network_Logon.Password.Element.SetAttributeValue("Text", password);
    		MainMenurepo.Network_Logon.Password.PressKeys("{TAB}");
    		
    		MainMenurepo.Network_Logon.LogonButton.Click();
    		int retries = 0;
    		while (!MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0) && retries < 5)
    		{
    			Ranorex.Delay.Seconds(1);
    			if (MainMenurepo.Network_Logon.SelfInfo.Exists(0))
    			{
    				MainMenurepo.Network_Logon.LogonButton.Click();
    			}
    			retries++;
    		}
    		
    		if (!MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("PDS Failed to Logon with userId: {"+userId+"} and password: {"+password+"}");
    			return;
    		}
    		
    		if (closeForms)
    		{
    			//Close Audible Alert
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Miscellaneousrepo.Audible_Alert_Checkout.OkButtonInfo,
					Miscellaneousrepo.Audible_Alert_Checkout.SelfInfo
				);
    			
    			//Close Control Request List
    			if (TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
						TerritoryTransferrepo.Control_Request_List.WindowControls.CloseInfo,
						TerritoryTransferrepo.Control_Request_List.SelfInfo
					);
    			}
    			
    			//Close Dispatcher Transfer Report
    			if(TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
    			{
    			    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
						TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
						TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo
					);
    			}
    		}
    		
    		Ranorex.Report.Success("PDS Logged in");
    		return;
    	}

		/// <summary>
		/// This method will allow user to be changed while already logged onto PDS. 
		/// It is worth noting that this automation will succeed if the user does not change during this process.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="password"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_SwitchUserFunction(string userId, string password, string role, string expectedFeedback, bool closeForms)
		{
			int attempts = 0;
			string actualFeedbackText = "";
			
			while (!MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0) && attempts < 3)
			{
				Delay.Milliseconds(250);
				attempts++;
			}

			if (!MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
			{
				Report.Screenshot();
				Report.Error("PDS Main Menu is not available, and user cannot be switched");
				return;
			}

			GeneralUtilities.ClickAndWaitForWithRetry(
				MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo,
				MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo
			);

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				MainMenurepo.PDS_Main_Menu.FileMenu.LogonInfo,
				MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo
			);

			int retries = 0;
			while (!MainMenurepo.Network_Logon.SelfInfo.Exists(0) && retries < 3)
			{
				Delay.Milliseconds(250);
				retries++;
			}

			if (!MainMenurepo.Network_Logon.SelfInfo.Exists(0)) {
				Report.Screenshot();
				Report.Error("PDS Network Logon Form Did Not Appear. Cannot Switch User.");
				return;
			}

			MainMenurepo.Network_Logon.UserId.Click();
    		MainMenurepo.Network_Logon.UserId.Element.SetAttributeValue("Text", userId);
    		MainMenurepo.Network_Logon.UserId.PressKeys("{TAB}");
    		
    		MainMenurepo.Network_Logon.Role.Click();
    		MainMenurepo.Network_Logon.Role.Element.SetAttributeValue("Text", role);
    		MainMenurepo.Network_Logon.Role.PressKeys("{TAB}");

    		MainMenurepo.Network_Logon.Password.Element.SetAttributeValue("Text", password);
    		MainMenurepo.Network_Logon.Password.PressKeys("{TAB}");

//			// TODO: Convert this portion to account for login fail
//			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
//				MainMenurepo.Network_Logon.LogonButtonInfo,
//				MainMenurepo.Network_Logon.SelfInfo
//			);
    		
			MainMenurepo.Network_Logon.LogonButton.Click();
			
			retries=0;
			
			while(MainMenurepo.Network_Logon.SelfInfo.Exists(0) && retries<5)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			//wait to feedback
			attempts=0;
			while((!MainMenurepo.Network_Logon.FeedbackTextInfo.Exists(0) && attempts < 3))
			{
				Delay.Milliseconds(500);
				attempts++;
			}
			
			if(MainMenurepo.Network_Logon.FeedbackTextInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Network_Logon.FeedbackTextInfo,
				                                          MainMenurepo.Network_Logon.Error_Form.SelfInfo);
				//catch appropriate feedback
				if(MainMenurepo.Network_Logon.Error_Form.ErrorMessageTextInfo.Exists(0))
				{
					actualFeedbackText = MainMenurepo.Network_Logon.Error_Form.ErrorMessageText.GetAttributeValue<string>("Text");
				}
				else{
					actualFeedbackText = MainMenurepo.Network_Logon.Error_Form.ErrorMessageStatusText.GetAttributeValue<string>("Text");
				}
				
				string feedbackText = Regex.Replace(actualFeedbackText, @"[^A-Za-z0-9]", ""); //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces
				string expFeedbackText = Regex.Replace(expectedFeedback, @"[^A-Za-z0-9]", "");  //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces
				Regex expectedFeedbackRegex = new Regex(expFeedbackText);
				
				//Match both the texts
				if (expectedFeedbackRegex.IsMatch(feedbackText))
				{
					Ranorex.Report.Success("Expected feedback of {"+expectedFeedback+"} found feedback {"+actualFeedbackText+"}.");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logon.Error_Form.OkButtonInfo,
					                                                  MainMenurepo.Network_Logon.Error_Form.SelfInfo);
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logon.CancelButtonInfo,
					                                                  MainMenurepo.Network_Logon.SelfInfo);
				}
				else
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logon.Error_Form.OkButtonInfo,
					                                                  MainMenurepo.Network_Logon.Error_Form.SelfInfo);
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logon.CancelButtonInfo,
					                                                  MainMenurepo.Network_Logon.SelfInfo);
					Ranorex.Report.Failure("Expected feedback of {"+expectedFeedback+"} found feedback {"+actualFeedbackText+"}.");
				}
				return;
			}
			

			if (closeForms)
    		{
    			if (Miscellaneousrepo.Audible_Alert_Checkout.SelfInfo.Exists(0))
				{
					//Close Audible Alert
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(
						Miscellaneousrepo.Audible_Alert_Checkout.OkButtonInfo,
						Miscellaneousrepo.Audible_Alert_Checkout.SelfInfo
					);
				}				
    			
    			//Close Control Request List
    			if (TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
						TerritoryTransferrepo.Control_Request_List.WindowControls.CloseInfo,
						TerritoryTransferrepo.Control_Request_List.SelfInfo
					);
    			}
    			
    			//Close Dispatcher Transfer Report
    			if(TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
    			{
    			    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
						TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
						TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo
					);
    			}
    		}

			Report.Success(string.Format("Logged into PDS as user: '{0}'", userId));
		}
    	
    	/// <summary>
    	/// Logoff PDS NS Version
    	/// </summary>
    	/// <param name="closeAllForms">Input:Closes All Forms if the prompt appears as part of logoff</param>
    	[UserCodeMethod]
    	public static void NS_LogoffFunction(bool closeForms)
    	{
    		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo,MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo);
    		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.FileMenu.LogoffInfo,MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo);
    		
    		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.Network_Logoff.OkButtonInfo,MainMenurepo.Network_Logoff.Close_All_Forms.SelfInfo);
    		
    		int retries = 0;
    		while (!MainMenurepo.Network_Logoff.Close_All_Forms.SelfInfo.Exists(0) && retries < 2)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}
    		
    		if (MainMenurepo.Network_Logoff.Close_All_Forms.SelfInfo.Exists(0))
    		{
    			if (closeForms)
    			{
    				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logoff.Close_All_Forms.YesButtonInfo,MainMenurepo.Network_Logoff.Close_All_Forms.YesButtonInfo);
    			} else {
    				Ranorex.Report.Error("No Forms expected in logoff, but close all forms prompt appeared");
    				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.Network_Logoff.Close_All_Forms.YesButtonInfo,MainMenurepo.Network_Logoff.Close_All_Forms.YesButtonInfo);
    			}
    		}
    		
    		retries = 0;
    		while (MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0) && retries < 10)
    		{
    			Ranorex.Delay.Milliseconds(2000);
    			retries++;
    		}
    		
    		if (MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("PDS Failed to Logoff");
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Click on 'Logon' link from main menu
    	/// </summary>
    	[UserCodeMethod]
    	public static void ClickOnLogonLinkFromMainMenu()
    	{
    		//Click File menu
    		PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo, MainMenurepo.PDS_Main_Menu.FileMenu.LogonInfo);
    		
    		//Click Territory Transfer in file menu
    		MainMenurepo.PDS_Main_Menu.FileMenu.Logon.Click();	
    	}
    	
    }
}
