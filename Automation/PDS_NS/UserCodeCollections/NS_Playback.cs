/*
 * Created by Ranorex
 * User: 503095531
 * Date: 2/22/2019
 * Time: 3:45 PM
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

using Env.Code_Utils;
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Playback
    {
    	public static global::PDS_NS.Playback_Repo Playbackrepo = global::PDS_NS.Playback_Repo.Instance;
    	public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
    	public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
    	public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
    	public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
    	public static global::PDS_NS.TrackAuthorities_Repo Authoritiesrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
    	public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
    	
    	/// <summary>
    	/// Opens the playbackform if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPlaybackConfigurationForm_MainMenu()
    	{
    		if (Playbackrepo.Playback_Setup.SelfInfo.Exists(0))
    		{
    			return;
    		}
    		//Click File Menu
    		MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButton.Click();
			//Click playback
			MainMenurepo.PDS_Main_Menu.FileMenu.PlayBack.Click();
    		
			int retries = 0;
			while (!MainMenurepo.PDS_Main_Menu.Controlling_Territory.SelfInfo.Exists(0) && retries < 2)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			if (MainMenurepo.PDS_Main_Menu.Controlling_Territory.SelfInfo.Exists(0))
			{
				MainMenurepo.PDS_Main_Menu.Controlling_Territory.OkButton.Click();
				Ranorex.Report.Error("Cannot open Playback Configuration form with territories currently controlled");
				return;
			}
			if (MainMenurepo.PDS_Main_Menu.PDS_Message.SelfInfo.Exists(0))
			{
				MainMenurepo.PDS_Main_Menu.PDS_Message.YesButton.Click();
				Ranorex.Report.Info("closed the open forms");
			}
			retries = 0;
			while (!Playbackrepo.Playback_Setup.SelfInfo.Exists(0) && retries <2)
		    {
		    	Ranorex.Delay.Milliseconds(500);
		    	retries++;
		    }
		    if (!Playbackrepo.Playback_Setup.SelfInfo.Exists(0))
		    {
		    	Ranorex.Report.Error("Playback form did not open");
		    }
		    return;
    	}
    	
    	/// <summary>
    	/// Validations for playback Form
    	/// <param name="admsOperational"> INPUT: ADMS Operational radio button should be clicked  </param>
    	/// <param name="tdmsOperation">INPUT: TDMS Operational radio button should be clicked </param>
    	/// <param name="admsDatabaseUser">INPUT: ADMS Database user name</param>
    	/// <param name="admsPassword">INPUT: ADMS Database Password</param>
    	/// <param name="admsDataSource">INPUT: ADMS Datasource </param>
    	/// <param name="tdmsDatabaseUser">INPUT: TDMS Database user name</param>
    	/// <param name="tdmsPassword">INPUT: TDMS Database Password</param>
    	/// <param name="tdmsDataSource">INPUT: TDMS Datasource </param>
    	/// <param name="playbackMonth">INPUT: Month to perform playback</param>
    	/// <param name="playbackYear">INPUT: Year to perform playback</param>
    	/// <param name="playbackDay">INPUT: Day to perform playback</param>
    	/// <param name="playbackStart">INPUT: Time to perform playback</param>
    	/// <param name="playbackSliderDistance">INPUT: from start time to how many hours to perform playback maximum is 4 hours</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_ConfigurePlaybackForm(bool admsOperational, bool tdmsOperational, string admsDatabaseUser, string admsPassword, string admsDataSource, string tdmsDatabaseUser, string tdmsPassword, string tdmsDataSource, string playbackMonth, string playbackYear, string playbackDay, string playbackStart, int playbackSliderDistance, bool GMT, string expectedFeedback)
    	{
    		NS_OpenPlaybackConfigurationForm_MainMenu();
			
    		// Selecting ADMS and TDMS in the playback form
			if (admsOperational)
			{
				if (!Playbackrepo.Playback_Setup.ADMSContainer.Operational.Checked)
				{
					Playbackrepo.Playback_Setup.ADMSContainer.Operational.Click();
				}
			}
			else
			{
				if (!Playbackrepo.Playback_Setup.ADMSContainer.OfflineDatabase.Checked)
				{
					Playbackrepo.Playback_Setup.ADMSContainer.OfflineDatabase.Click();
				}
				
				if (admsDatabaseUser !="")
				{
					
					Playbackrepo.Playback_Setup.ADMSContainer.DatabaseUserText.Click();
					Playbackrepo.Playback_Setup.ADMSContainer.DatabaseUserText.Element.SetAttributeValue("Text", admsDatabaseUser);
				}
				
				Playbackrepo.Playback_Setup.ADMSContainer.DatabaseUserText.PressKeys("{TAB}");
				
				if (admsPassword !="")
				{
					Playbackrepo.Playback_Setup.ADMSContainer.PasswordText.Element.SetAttributeValue("Text", admsPassword);
				}
				
				Playbackrepo.Playback_Setup.ADMSContainer.PasswordText.PressKeys("{TAB}");
				
				if (admsDataSource !="")
				{
					Playbackrepo.Playback_Setup.ADMSContainer.DataSourceText.Element.SetAttributeValue("Text", admsDataSource);
				}
				Playbackrepo.Playback_Setup.ADMSContainer.ConnectButton.Click();
			}
			
			if (tdmsOperational)
			{
				if (!Playbackrepo.Playback_Setup.TDMSContainer.Operational.Checked)
				{
					Playbackrepo.Playback_Setup.TDMSContainer.Operational.Click();
				}
			}
			else 
			{
				if (!Playbackrepo.Playback_Setup.TDMSContainer.OfflineDatabase.Checked)
				{
					Playbackrepo.Playback_Setup.TDMSContainer.OfflineDatabase.Click();
				}
				if(tdmsDatabaseUser !="")
				{
					Playbackrepo.Playback_Setup.TDMSContainer.DatabaseUserText.Click();
					Playbackrepo.Playback_Setup.TDMSContainer.DatabaseUserText.Element.SetAttributeValue("Text", tdmsDatabaseUser);
				}
				
				Playbackrepo.Playback_Setup.TDMSContainer.DatabaseUserText.PressKeys("{TAB}");
				
				if(tdmsPassword !="")
				{
					Playbackrepo.Playback_Setup.TDMSContainer.PasswordText.Element.SetAttributeValue("Text", tdmsPassword);
				}
				
				Playbackrepo.Playback_Setup.TDMSContainer.PasswordText.PressKeys("{TAB}");
				
				if (tdmsDataSource !="")
				{
					Playbackrepo.Playback_Setup.TDMSContainer.DatabaseUserText.Element.SetAttributeValue("Text", tdmsDataSource);
				}
				Playbackrepo.Playback_Setup.TDMSContainer.ConnectButton.Click();
			}			
			// select the month year and date in playback period
			Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuButton.Click();
			if (playbackMonth !="")
			{
			switch (playbackMonth)
			{
				case "January" : 
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.Janurary.Click();
					break;
				case "February" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.February.Click();
					break;
				case "March" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.March.Click();
					break;
				case "April" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.April.Click();
					break;	
				case "May" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.May.Click();
					break;
				case "June" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.June.Click();
					break;
				case "July" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.July.Click();
					break;
				case "August" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.August.Click();
					break;
				case "September" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.September.Click();
					break;
				case "October" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.October.Click();
					break;
				case "November" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.November.Click();
					break;
				case "December" :
					Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Month.MonthMenuList.December.Click();
					break;
				default:
					Ranorex.Report.Info("Could not find Month {"+playbackMonth+"} current month will be selected.");
					break;
			}		
			}
			if(playbackYear != "")
			{
				Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Year.YearText.Click();
				Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Year.YearText.Element.SetAttributeValue("Text", playbackYear);
			}
			if(playbackDay !="")
			{
				Playbackrepo.Day = playbackDay;
				Playbackrepo.Playback_Setup.PlaybackPeriodContainer.CalendarObject.Day.Day.Click();
			}
			Playbackrepo.Playback_Setup.PlaybackPeriodContainer.Start.StartText.Click();
			Playbackrepo.Playback_Setup.PlaybackPeriodContainer.Start.StartText.Element.SetAttributeValue("Text", playbackStart);
			if (playbackSliderDistance < 10 || playbackSliderDistance > 241)
			{
				Ranorex.Report.Error("PlaybackSliderDistance should be inbetween 10 and 241");
			}
			Playbackrepo.Playback_Setup.PlaybackPeriodContainer.EndDateSlider.Element.SetAttributeValue("value", Convert.ToDouble(playbackSliderDistance));
			//To check GMT checkbox for playback to run in GMT time
			if(GMT)
			{
				Playbackrepo.Playback_Setup.PlaybackPeriodContainer.GMT.Click();
			}
			//Check if this kicked up some FeedBack
    		if (!CheckFeedback(Playbackrepo.Playback_Setup.Feedback, expectedFeedback))
			{
				Playbackrepo.Playback_Setup.CancelButton.Click();
				return;
			}
			if(expectedFeedback != "")
			{
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			return;
    		}
    	}
    	/// <summary>
    	/// Compares feedback with regex of expectedFeedback
    	/// </summary>
    	/// <param name="feedback">Input:feedback</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	public static bool CheckFeedback(Adapter feeback, string expectedFeedback)
    	{
    		Regex expectedFeedbackRegex = new Regex(expectedFeedback);
    		string feedbackText = feeback.GetAttributeValue<string>("Text");
    		if (feedbackText == "" || feedbackText == " ")
    		{
    			//No feedback received, return
    			return true;
    		}
    		if (expectedFeedback == "")
    		{
    			Ranorex.Report.Failure("Expected no feedback, got feedback of {"+feedbackText+"}.");
    			return false;
    		}
    		if (expectedFeedbackRegex.IsMatch(feedbackText))
    		{
    			Ranorex.Report.Success("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
    			return false;
    		}
    		return true;
    	}
    	
    	
    	/// <summary>
    	/// Requesting for the Division and Territories to run Playback
    	/// <param name="divisionName">INPUT: Division play has to be performed</param>
    	/// <param name="territoryName">INPUT: Territory play has to be performed</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_PlaybackDivisionTerritoryRequest(string divisionName, string territoryName)
    	{
    		if(territoryName ==" " || divisionName ==" ")
    		{
    			Ranorex.Report.Info("Not able to find the division and territory");
    			return;
    		}
    		Playbackrepo.Division = divisionName;
    		Playbackrepo.Territory = territoryName;
    		
    		string currentDivision = Playbackrepo.Playback_Setup.Division.DivisionMenuButton.GetAttributeValue<string>("SelectedItemText");
    		if (currentDivision != Playbackrepo.Division)
    		{
    			Playbackrepo.Playback_Setup.Division.DivisionMenuButton.Click();
    			if (!Playbackrepo.Playback_Setup.Division.DivisionMenuList.DivisionListItemInfo.Exists(0))
    			{
    				Playbackrepo.Playback_Setup.Division.DivisionMenuButton.Click();
    				Ranorex.Report.Error("Unable to find division {"+divisionName+"} in territoryName transfer");
    				return;
    			}
    			Playbackrepo.Playback_Setup.Division.DivisionMenuList.DivisionListItem.Click();
    		}
    		// Make sure territory name is in requested territory
    		if (!Playbackrepo.Playback_Setup.AvailableTerritoriesList.TerritoryListItemInfo.Exists(0))
			{
				Ranorex.Report.Error("Could not find territory {"+territoryName+"} within territory transfer");
				return;
			}
			// Select territory
			Playbackrepo.Playback_Setup.AvailableTerritoriesList.TerritoryListItem.Click();
			Playbackrepo.Playback_Setup.MoveRightButton.Click();
			Ranorex.Report.Info("TestStep", "Took territory {"+territoryName+"} from division {"+divisionName+"}.");
    	}
    	
    	
    	/// <summary>
    	/// Click ok after all the configuration is done in playback
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_AcceptConfigPlayback()
    	{
    		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(
    			Playbackrepo.Playback_Setup.OkButtonInfo,
    			Playbackrepo.Playback_Setup.SelfInfo
    		);    
    	}
    	
    	/// <summary>
    	/// Noteing down the start time for playback
    	/// <param name="playbackStartTime">INPUT: getting the current time</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static string NS_PlaybackStartTime(string playbackStartTime)
    	{
    		return NS_PlaybackStatTime(playbackStartTime, true);
    	    
    	}
    	
    	/// <summary>
    	/// Noteing down the start time for playback
    	/// <param name="playbackStartTime">INPUT: getting the current time</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static string NS_PlaybackStatTime(string playbackStartTime, bool EST)
    	{
    		if(EST)
    		{
    			playbackStartTime = System.DateTime.Now.ToString("h:mm:ss tt");
    		}
    		else
    		{
    			playbackStartTime = System.DateTime.UtcNow.ToString("h:mm:ss tt");
    			Ranorex.Report.Info(" " +playbackStartTime+ " ");
    		}
    		return playbackStartTime ;
    	}
    	/// <summary>
    	/// To validate the playback controller form and to validate all the actions are placed.
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_ValidatePlaybackController()
    	{
    		if (Playbackrepo.Playback_Controller.Cannot_Perform_Playback.SelfInfo.Exists())
    		{
    			
    			Playbackrepo.Playback_Controller.Cannot_Perform_Playback.OkButton.Click();
    			Playbackrepo.Save_Configuration.NoButton.Click();
    			Ranorex.Report.Error("NO Trackline Snapshort is created for the given Time Period");
    		}
    		int retries = 0;
    		while (!Playbackrepo.Playback_Controller.SelfInfo.Exists(0) && retries <2)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}
    		if (!Playbackrepo.Playback_Controller.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Playback Controller Does not Exist");
    		}
    		else
    		{
    			Ranorex.Report.Success("Playback Controller Exist");
    		}

    	}
    	
    	/// <summary>
    	/// To validate if Bulletins placed in the PDS exist in Playback mode
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_VerifyPlaybackBulletinExist()
    	{
    		int eventGroupRowIndex = Playbackrepo.Playback_Controller.EventGroupTable2.Self.Rows.Count;
    		Ranorex.Report.Info("count present in the eventgrouptable is " + eventGroupRowIndex.ToString());
    		string playbackFormRowValue;
    		string playbackActionRowValue;
    		if(eventGroupRowIndex>=1)
    		{
    			bool issueFlag = false;
    			for (int i=0; i<eventGroupRowIndex; i++)
    			{
    				Playbackrepo.EventGroupRowIndex = i.ToString();
    				playbackFormRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Form.GetAttributeValue<string>("Form");
    				playbackActionRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Action.GetAttributeValue<string>("Action");
    				if (playbackActionRowValue.Equals("ISSUE",StringComparison.OrdinalIgnoreCase) &&
    					playbackFormRowValue.Contains("Bulletin"))
    				{
    					issueFlag = true;
    				}
    			}
    			if (issueFlag)
    			{
    				Ranorex.Report.Success(" Bulletin has been issued ");
    			}
    			else
    			{
    				Ranorex.Report.Failure(" No Bulletin Exist ");
    			}
    		}
    	}
    	/// <summary>
    	/// To validate if TrackAuthorities placed in the PDS exist in Playback mode
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_VerifyPlaybackTrackAuthorityExist()
    	{
    		int eventGroupRowIndex = Playbackrepo.Playback_Controller.EventGroupTable2.Self.Rows.Count;
    		Ranorex.Report.Info("count present in the eventgrouptable is " + eventGroupRowIndex.ToString());
    		string playbackDescriptionRowValue;
    		string playbackActionRowValue;
    		if(eventGroupRowIndex>=1)
    		{
    			
    			bool issueFlag = false;
    			bool continueFlag = false;
    			bool acknowledgeFlag = false;
    			for (int i=0; i<eventGroupRowIndex; i++)
    			{
    				Playbackrepo.EventGroupRowIndex = i.ToString();
    				playbackDescriptionRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Description.GetAttributeValue<string>("Text");
    				playbackActionRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Action.GetAttributeValue<string>("Action");
    				if (playbackActionRowValue.Equals("Issue", StringComparison.OrdinalIgnoreCase) &&
    					playbackDescriptionRowValue.Contains("Create Track Authority"))
    				{
    					issueFlag = true;
    				}
    				else if(playbackActionRowValue.Equals("Continue", StringComparison.OrdinalIgnoreCase) &&
    					playbackDescriptionRowValue.Contains("Communication Exchange Track Authority"))
    				{
    					continueFlag = true;
    				}
    				else if(playbackActionRowValue.Equals("Acknowledge", StringComparison.OrdinalIgnoreCase) &&
    					playbackDescriptionRowValue.Contains("OK Track Authority"))
    				{
    					acknowledgeFlag = true;
    				}
    			}
    			if (issueFlag && continueFlag && acknowledgeFlag)
    			{
    				Ranorex.Report.Success(" Authority has been issued ");
    			}
    			else
    			{
    				Ranorex.Report.Failure(" No Authority has been issued ");
    			}
    		}
    	}
    	
    	
    	/// <summary>
    	/// To validate if Tags placed in the PDS exist in Playback mode
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_VerifyPlaybackTagsExist(string tagType, string actionPerformed)
    	{
    		int eventGroupRowIndex = Playbackrepo.Playback_Controller.EventGroupTable2.Self.Rows.Count;
    		Ranorex.Report.Info("count present in the eventgrouptable is " + eventGroupRowIndex.ToString());
    		string playbackDescriptionRowValue;
    		string playbackActionRowValue;
    		if(eventGroupRowIndex>=1)
    		{
    			bool blockFlag = false;
    			bool okFlag = false;
    			for (int i=0; i<eventGroupRowIndex; i++)
    			{
    				Playbackrepo.EventGroupRowIndex = i.ToString();
    				playbackDescriptionRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Description.GetAttributeValue<string>("Text");
    				playbackActionRowValue = Playbackrepo.Playback_Controller.EventGroupTable2.EventGroupTablebyRow.Action.GetAttributeValue<string>("Action");
    				if (playbackDescriptionRowValue.Equals (tagType) &&
    				    playbackActionRowValue.Equals(actionPerformed))
    				{
    					blockFlag = true;
    				}
    				else if (playbackDescriptionRowValue.Equals(tagType) &&
    				         playbackActionRowValue.Equals("OK"))
    				{
    					okFlag = true;
    				}		
    			}
    			if (actionPerformed == "BLOCK")
    			{
    				if (blockFlag && okFlag)
    				{
    					Ranorex.Report.Success(" "+actionPerformed+" "+tagType+" tag is placed ");
    				}
    				else
    				{
    					Ranorex.Report.Failure(" "+actionPerformed+"  "+tagType+" tag is not placed ");
    				}
    			}
    			else if (actionPerformed == "REMINDER")
    			{
    				if (blockFlag && okFlag)
    				{
    					Ranorex.Report.Success(" "+actionPerformed+" "+tagType+" tag is placed ");
    				}
    				else
    				{
    					Ranorex.Report.Failure(" "+actionPerformed+" "+tagType+" tag is not placed ");
    				}
    			}
    			else if (actionPerformed == "RWP")
    			{
    				if (blockFlag && okFlag)
    				{
    					Ranorex.Report.Success(" "+actionPerformed+" "+tagType+" tag is placed ");
    				}
    				else
    				{
    					Ranorex.Report.Failure(" "+actionPerformed+" "+tagType+" tag is not placed ");
    				}
    			}
    			else if (actionPerformed == "BSOCCP")
    			{
    				if (blockFlag && okFlag)
    				{
    					Ranorex.Report.Success(" "+actionPerformed+" "+tagType+" tag is placed ");
    				}
    				else
    				{
    					Ranorex.Report.Failure(" "+actionPerformed+" "+tagType+" tag is not placed ");
    				}
    			}
    		}
    	}
    	
    	/// <summary>
    	/// Closing the playback controller form
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_ClosePlaybackController()
    	{
    		int retries = 0;
    		while (!Playbackrepo.Playback_Controller.SelfInfo.Exists(0) && retries <2)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}
    		if (Playbackrepo.Playback_Controller.SelfInfo.Exists())
    		{
    			Playbackrepo.Playback_Controller.WindowControls.Close.Click();
    			if (Playbackrepo.Save_Configuration.SelfInfo.Exists())
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Playbackrepo.Save_Configuration.NoButtonInfo,
    				                                                  Playbackrepo.Save_Configuration.SelfInfo);
    			}		
    		}
    		if (MainMenurepo.PDS_Main_Menu.PDS_Message.SelfInfo.Exists())
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.PDS_Message.YesButtonInfo, 
    				                                          MainMenurepo.PDS_Main_Menu.PDS_Message.SelfInfo);
    		}
    	}
    	
    	/// <summary>
    	/// To Play the playback for given time period so that the previous actions will be recorded
    	/// </summary>
    	/// <param name="playbackScaleFactorValue">Input:Sets the value how much to fast forward the playback scaleFactorvalue is between 1.0 to 64.0 where 1.0 is 1 time faster then the regular play option and 64.0 is 7 times faster</param>
    	[UserCodeMethod]
    	public static void NS_PlayPlaybackController(int playbackScaleFactorValue)
    	{
    		// Value 
    		string scaleFactorValue = Playbackrepo.Playback_Controller.ScaleFactor.GetAttributeValue<string>("Text");
    		Playbackrepo.Playback_Controller.PlayButton.Click();
    		int scaleFactorConvertedValue =(int)Convert.ToDouble(scaleFactorValue);
    		while (scaleFactorConvertedValue < playbackScaleFactorValue)
    		{
    			scaleFactorValue = Playbackrepo.Playback_Controller.ScaleFactor.GetAttributeValue<string>("Text");
    			scaleFactorConvertedValue =(int)Convert.ToDouble(scaleFactorValue);
//    			Ranorex.Report.Info(" "+scaleFactorConvertedValue+ "");
    			Playbackrepo.Playback_Controller.IncreaseSpeedButton.Click();
    		}
    		// iterating for maximum 10 mins 
    		int counter = 1;
    		while(Playbackrepo.Playback_Controller.NextEventButton.Enabled)
    		{
    			Ranorex.Delay.Milliseconds(1000);
    			if(counter > 600)
    			{
    				break;
    			}
    			counter++;
    		}
    	}
    	
    	/// <summary>
    	/// Validates Bulletin From Bulletin Summary List using the Bulletins Bulletin Number
    	/// </summary>
    	/// <param name="bulletinSeed">Input:Bulletin Seed of Bulletin to be removed</param>
    	/// <param name="closeBulletinInputForm">Input:Closes the Bulletin Summary List if true</param>
    	[UserCodeMethod]
    	public static void NS_ValidateBulletinNumberExist_PlaybackSummaryList(string bulletinSeed, bool closeBulletinSummaryList = true)
    	{
    		int retry = 0;
    		if ( Playbackrepo.Playback_Controller.SelfInfo.Exists(0))
    		{
    			MainMenurepo.PDS_Main_Menu.MainMenuBar.SummaryLists.Click();
    			MainMenurepo.PDS_Main_Menu.SummaryListsMenu.OpenBulletinItemSummaryList.Click();
    			while(Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.Self.Rows.Count == 0 && retry < 3)
    			{
    				Ranorex.Delay.Milliseconds(1000);
    				retry++;
    			}
    			string targetBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
    			Bulletinsrepo.BulletinNumber = targetBulletinNumber;
    			if (targetBulletinNumber == null)
    			{
    				Ranorex.Report.Error(" There is no Bulletin number exist " );
    				return;
    			}
    			if (!Bulletinsrepo.Bulletin_Summary_List.BulletinSummaryListTable.BulletinSummaryRowByBulletinNumber.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Failure("Bulletin with Bulletin Number {"+targetBulletinNumber+"} was not found in Bulletin Summary List");
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Success("Bulletin Exist in the playback Bulletin Summary Form");
    				
    			}
    			if (closeBulletinSummaryList)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Summary_List.WindowControls.CloseInfo, 
    				                                          Bulletinsrepo.Bulletin_Summary_List.SelfInfo);
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Playback controller does not exist to validate any of the PDS actions");
    		}
    	}
    	
    	/// <summary>
    	/// Validates Authority From Authority Summary List using the Authority Number
    	/// </summary>
    	/// <param name="authoritySeed">Input:Authority Seed of authority to be removed</param>
    	/// <param name="closeAuthorityinInputForm">Input:Closes the Authority Summary List if true</param>
    	[UserCodeMethod]
    	public static void NS_ValidateAuthorityNumber_PlaybackSummaryList(string authoritySeed, bool closeAuthoritySummaryList = true)
    	{
    		int retry = 0;
    		if (Playbackrepo.Playback_Controller.SelfInfo.Exists(0))
    		{
    			MainMenurepo.PDS_Main_Menu.MainMenuBar.SummaryLists.Click();
    			MainMenurepo.PDS_Main_Menu.SummaryListsMenu.OpenTrackAuthoritySummaryList.Click();
    			while(Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.Self.Rows.Count == 0 && retry < 3)
    			{
    				Ranorex.Delay.Milliseconds(1000);
    				retry++;
    			}
    			//If Authority seed doen't exit
    			string targetAuthorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
    			if (targetAuthorityNumber == null)
    			{
    			   Ranorex.Report.Error(" There is no Authority number exist " );
    			   return;
    			}
    			if (!Authoritiesrepo.Track_Authority_Summary_List.TrackAuthoritySummaryListTable.TrackAuthorityRowByAuthorityNumber.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Authority with Authority Number {"+targetAuthorityNumber+"} was not found in Authority summary List");
    			}
    			else
    			{
    				Ranorex.Report.Success("Authority Exist in the Playback Authority Summary List");
    			}
    			if (closeAuthoritySummaryList)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Authoritiesrepo.Track_Authority_Summary_List.WindowControls.CloseInfo,
    				                                                  Authoritiesrepo.Track_Authority_Summary_List.SelfInfo);
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Playback controller does not exist to validate any of the PDS actions");
    		}
    	}
    	
    	
    	/// <summary>
    	/// Validates Tags From Tags Summary List
    	/// </summary>
    	/// <param name="tagName">Input:Tag Name to validate</param>
    	/// <param name="tagType">Input:Tag Type to validate</param>
    	/// <param name="blockingType">Input:Tag block to validate</param>
    	/// <param name="closeForm">Input:Closes the Authority Summary List if true</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTags_PlaybackSummaryList(string tagName, string tagType, string blockingType, bool closeForms, string planThrough)
    	{
    		int retry = 0;
    		if (Playbackrepo.Playback_Controller.SelfInfo.Exists(0))
    		{
    			MainMenurepo.PDS_Main_Menu.MainMenuBar.SummaryLists.Click();
    			MainMenurepo.PDS_Main_Menu.SummaryListsMenu.OpenTagsSummaryList.Click();
    			while(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0 && retry < 3)
    			{
    				Ranorex.Delay.Milliseconds(1000);
    				retry++;
    			}
    			string playbackTagName;
    			string PlaybackType;
    			string playbackBlocking;
    			string playbackPlanThrough;
    			bool tagFlag = false;
    			int tagSummaryListRowIndex = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
    			Ranorex.Report.Info("count present in the tags summarilist table is " + tagSummaryListRowIndex.ToString());
    			Ranorex.Report.Screenshot(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self);
    			for(int i=0; i<tagSummaryListRowIndex; i++)
    			{
    				Miscellaneousrepo.TagsSummaryListIndex = i.ToString();
    				playbackTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
    				PlaybackType = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.Type.GetAttributeValue<string>("Text");
    				playbackBlocking = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.Blocking.GetAttributeValue<string>("Text");
    				playbackPlanThrough = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.PlanThrough.GetAttributeValue<string>("Text");
    				if(playbackTagName.Equals (tagName) &&
    				   PlaybackType.Equals (tagType) && playbackBlocking.Equals (blockingType) && playbackPlanThrough.Equals (planThrough))
    				{
    					tagFlag = true;
    					break;
    				}
    			}
    			if(tagFlag)
    			{
    				Ranorex.Report.Success(" "+tagType+" "+blockingType+" with tag name "+tagName+" is placed ");
    			}
    			else
    			{
    				Ranorex.Report.Failure(" "+tagType+" "+blockingType+" with tag name "+tagName+" is not placed ");
    			}
    			if (closeForms)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo,
    				                                                  Miscellaneousrepo.Tags_Summary_List.SelfInfo);
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Playback controller does not exist to validate any of the PDS actions");
    		}
    	}
    	
    	/// <summary>
    	/// Verifying Short train ID is assoiated with the signal in the controller once the signal is cleard for the train
    	/// </summary>
    	/// <param name="trainSeed">Input:TrainSeed for the train to which signal is cleared</param>
    	[UserCodeMethod]
    	public static void NS_VerifyShortTrainID_PlaybackController(string trainSeed)
    	{
    		string trainId = NS_TrainID.GetTrainSymbol(trainSeed);
    		string originDate = NS_TrainID.getOriginDate(trainSeed).ToString().Substring(2,2);
    		string playbackDescriptionValue;
    		if(Playbackrepo.Playback_Controller.SelfInfo.Exists(0))
    		{
    			int eventGrouprowIndex = Playbackrepo.Playback_Controller.EventGroupTable.Self.Rows.Count;
    			Ranorex.Report.Info("count present in the table is " +eventGrouprowIndex.ToString());
    			if(eventGrouprowIndex>=1)
    			{
    				bool ShortTrainIdAttachedFlag = false;
    				bool ShortTrainIdDetachedFlag= false;
    				for(int i=0; i<eventGrouprowIndex; i++)
    				{
    					Playbackrepo.EventGroupRowIndex = i.ToString();
    					playbackDescriptionValue = Playbackrepo.Playback_Controller.EventGroupTable.EventGroupTablebyRow.Description.GetAttributeValue<string>("Text");
    					if(playbackDescriptionValue.Contains("Attach") &&
    					   playbackDescriptionValue.Contains("Attach ShortTrainId: "+trainId+" "+originDate+" Lamp "))
    					{
    						ShortTrainIdAttachedFlag = true;
    					}
    					else if(playbackDescriptionValue.Contains("Detach") &&
    					        playbackDescriptionValue.Contains("Detach ShortTrainId: "+trainId+" "+originDate+" Lamp "))
    					{
    						ShortTrainIdDetachedFlag = true;
    					}
    				}
    				if (ShortTrainIdAttachedFlag)
    				{
    					Ranorex.Report.Success("Attach ShortTrainId: "+trainId+" "+originDate+" Lamp Exist");
    				}
    				else if(ShortTrainIdDetachedFlag)
    				{
    					Ranorex.Report.Success("Detach ShortTrainId: "+trainId+" "+originDate+" Lamp Exist");
    				}
    				else
    				{
    					Ranorex.Report.Failure("No Short Train ID: "+trainId+" "+originDate+" Found");
    				}
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("No data has been Populated");
    		}
    	}
    	
    	/// <summary>
    	/// Validates the train Key is logged in the ADMS table once the signal is cleared for the train
    	/// </summary>
    	/// <param name="TrainSeed">Input:Train seed to get the train key</param>
    	/// <param name="DeviceID">Input:DeviceID is the signal ID</param>
    	/// <param name="TransactionType">Input:Signal is cleared or stopped if it is cleared then the transactionTpe is attach if it is stopped then it is detach</param>
    	[UserCodeMethod]
    	public static void NS_Validate_TrainKeyLogged_ADMS(string TrainSeed, string DeviceID, string TransactionType)
    	{
    		string trainSymbol = NS_TrainID.GetTrainSymbol(TrainSeed);
			string originDate = NS_TrainID.getOriginDate(TrainSeed);
			string trainKey = NS_TrainID.GetTrainKey(TrainSeed);
			Oracle.Code_Utils.ADMSEnvironment.Validate_TrainKeyLogged_ADMS(DeviceID, TransactionType, trainKey);
    	}
    	
    	/// <summary>
		/// Open Train Sheet from trackLine
		/// </summary>
		/// <param name="trainSeed">Input trainSeed</param>
		[UserCodeMethod]
		public static void NS_OpenTrainSheet_PlaybackTrackLine(string TrainSeed)
		{
			int retries = 0;
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(TrainSeed);
			if (trainId == null)
			{
				Ranorex.Report.Failure(" No TrainId found for trainSeed {"+TrainSeed+"}, ensure correct trainSeed and that train was made ");
				return;
			}
			string trainIdLabel;
			Tracklinerepo.TrainId = trainId;
			if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
			{
				Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
				int trainOnTrackRowIndex = Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.Self.Columns.Count;
				trainIdLabel = Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.TrainIDLabel.GetAttributeValue<string>("Text");
				if (trainIdLabel.Equals(trainId))
				{
					Tracklinerepo.Trackline_Form.TrainOnTrackDepartureListMenu.TrainIdTable.TrainIDLabel.Click(WinForms.MouseButtons.Right);
					Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.OpenTrainSheet.Click();
					//Wait for Trainsheet to exist in case of lag
					if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
					{
						Ranorex.Delay.Milliseconds(500);
						while (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0) && retries < 2)
						{
							Ranorex.Delay.Milliseconds(500);
							retries++;
						}
						
						if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
						{
							Ranorex.Report.Error("Trainsheet did not open");
							return;
						}
					}
				}
			}
			else
			{
				Ranorex.Report.Failure("Train {"+trainId+"} not found on trackline");
				return;
			}
		}
    	
 	     /// <summary>
		/// Validates Trip plan data recorded in the train sheet in playback mode or not
		/// </summary>
		/// <param name="trainSeed">Input trainSeed</param>
		/// <param name="closeTrainsheet">Clos ethe train sheet</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTripPlanInPlayback(string TrainSeed, bool closeTrainsheet = true)
    	{
    		NS_Playback.NS_OpenTrainSheet_PlaybackTrackLine(TrainSeed);
    		int retries = 0;
			if ( Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainIDTextInfo,
				                                          Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo);
				
				while(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo.Exists(0) && retries < 5)
				{
					Ranorex.Delay.Milliseconds(1000);
					retries++;
				}
				Ranorex.Report.Success("TripPlan has Populated for the given Train");
			}
			else
			{
				Ranorex.Report.Failure("No TripPlan Exist For the Given Train");
			}
			if (closeTrainsheet)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
				                                                  Trainsrepo.Train_Sheet.SelfInfo);
			}
			return;
    	}
    	
    	/// <summary>
    	/// To Validate GMT Time Zone
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_ValidateTimeZone(bool DefaultTimeZone)
    	{
    		string PlaybackPeriodStartTime = Playbackrepo.Playback_Controller.PlaybackPeriod.Start.GetAttributeValue<string>("Text");
    		string PlaybackPeriodEndTime = Playbackrepo.Playback_Controller.PlaybackPeriod.End.GetAttributeValue<string>("Text");
    		string playbackTimevalue = Playbackrepo.Playback_Controller.PlaybackTime.GetAttributeValue<string>("Text");
    		string ClockValue = MainMenurepo.PDS_Main_Menu.Clock.GetAttributeValue<string>("Text");
    		bool EDTTimeZone = false;
    		bool GMTTimeZone = false;
    		if (DefaultTimeZone)
    		{
    			if((PlaybackPeriodStartTime.Contains(" EDT") || PlaybackPeriodStartTime.Contains(" EST")) &&
    			   (PlaybackPeriodEndTime.Contains(" EDT") || PlaybackPeriodEndTime.Contains(" EST")) && (playbackTimevalue.Contains(" EDT") || playbackTimevalue.Contains(" EST")) && ClockValue.Contains(" E"))
    			{
    				EDTTimeZone = true;
    			}
    			if (EDTTimeZone)
    			{
    				Ranorex.Report.Success("The TimeZone is in EDT");
    			}
    			else
    			{
    				Ranorex.Report.Failure("The TimeZone is not in EDT");
    			}
    		}
    		else
    		{
    			if(PlaybackPeriodStartTime.Contains(" GMT") &&
    			   PlaybackPeriodEndTime.Contains(" GMT") && playbackTimevalue.Contains(" GMT") && ClockValue.Contains(" G"))
    			{
    				GMTTimeZone = true;
    			}
    			if (GMTTimeZone)
    			{
    				Ranorex.Report.Success("The TimeZone is in GMT");
    			}
    			else
    			{
    				Ranorex.Report.Failure("The TimeZone is not in GMT");
    			}
    		}
    	}
    	
    	/// <summary>
    	/// To verify Playback Rewind is working as expected by checking the playback time after clicking rewind button
    	/// <param name="startTime">Input StartTime when the playback started to play</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_Validate_PlaybackRewind(string startTime)
    	{
    		NS_ValidatePlaybackController();
    		Playbackrepo.Playback_Controller.RestartButton.Click();
    		// getting the playback timer to verify if it got rewined to the start time.
    		string PlaybackTimer = Playbackrepo.Playback_Controller.PlaybackTime.GetAttributeValue<string>("Text");
    		if(PlaybackTimer.Contains( startTime ))
    		{
    			Ranorex.Report.Success(" "+PlaybackTimer+" playback time and "+startTime+" playback start time are as expected ");
    		}
    		else
    		{
    			Ranorex.Report.Failure(" Playback rewind does not happen ");
    		}
    	}
    	
    	/// <summary>
    	/// To Save the PDS action in a file
    	/// <param name="fileName">Input file name to be saved</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_SaveConfigureFile_Playback(string fileName)
    	{
    		GeneralUtilities.ClickAndWaitForWithRetry(Playbackrepo.Playback_Setup.RibbonMenu.SaveConfigurationInfo,
    		                                          Playbackrepo.Playback_Setup.Save_Playback_Configuration.SelfInfo);
    		if (Playbackrepo.Playback_Setup.Save_Playback_Configuration.SelfInfo.Exists())
    		{
    			Playbackrepo.Playback_Setup.Save_Playback_Configuration.FileNameText.Element.SetAttributeValue("Text", fileName);
    		}
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Playbackrepo.Playback_Setup.Save_Playback_Configuration.SaveButtonInfo,
    		                                                  Playbackrepo.Playback_Setup.Save_Playback_Configuration.SelfInfo);
    	}
    	
    	/// <summary>
    	/// To Load the saved file
    	/// <param name="fileName">Input file name to be Loaded</param>
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_LoadConfigurationFile_Playback(string fileName)
    	{
    		GeneralUtilities.ClickAndWaitForWithRetry(Playbackrepo.Playback_Setup.RibbonMenu.LoadConfigurationInfo,
    		                                          Playbackrepo.Playback_Setup.Load_Playback_Configuration.SelfInfo);
    		if (Playbackrepo.Playback_Setup.Load_Playback_Configuration.SelfInfo.Exists())
    		{
    			Playbackrepo.Playback_Setup.Load_Playback_Configuration.FileNameText.Element.SetAttributeValue("Text", fileName);
    		}
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Playbackrepo.Playback_Setup.Load_Playback_Configuration.OpenButtonInfo,
    		                                                  Playbackrepo.Playback_Setup.Load_Playback_Configuration.SelfInfo);
    	}
    }
}
