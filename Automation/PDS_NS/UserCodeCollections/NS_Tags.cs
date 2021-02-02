/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/30/2018
 * Time: 2:51 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
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
	public class NS_Tags
	{
		public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
		public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
		public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
		
		/// <summary>
		/// Opens the Tag Summary Form if not already open
		/// </summary>
		[UserCodeMethod]
		public static void NS_OpenTagsSummaryList_MainMenu()
		{
			int retries = 0;

			//Open Tags Summary List Form if it's not already open
			if (!Miscellaneousrepo.Tags_Summary_List.SelfInfo.Exists(0))
			{
				//Click Miscellaneous menu
				MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton.Click();
				//Click Tags in Miscellaneous menu
				MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.Tags.Self.Click();
				//Click Tags Summary List in Tags Menu
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.Tags.SummaryListInfo,
				                                          Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.SelfInfo);
				
				//Wait for Tags Summary List Form to exist in case of lag
				if (!Miscellaneousrepo.Tags_Summary_List.SelfInfo.Exists(0))
				{
					Ranorex.Delay.Milliseconds(500);
					while (!Miscellaneousrepo.Tags_Summary_List.SelfInfo.Exists(0) && retries < 2)
					{
						Ranorex.Delay.Milliseconds(500);
						retries++;
					}
					
					if (!Miscellaneousrepo.Tags_Summary_List.SelfInfo.Exists(0))
					{
						Ranorex.Report.Error("Tags Summary List form did not open");
						return;
					}
				}

				retries = 0;
				int tagRows = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
				bool finished = false;
				while (!finished && retries < 6)
				{
					Ranorex.Delay.Milliseconds(1000);
					//As long as the count changes within the half second, we will continue waiting in the loop
					
					if (Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
					{
						retries++;
						continue;
					}
					
					if (Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count != tagRows)
					{
						tagRows = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
						continue;
					}
					
					finished = true;
				}
				
				if (tagRows == 0)
				{
					Ranorex.Report.Screenshot(Miscellaneousrepo.Tags_Summary_List.Self);
					Ranorex.Report.Info("No Tags found in Tag Summary");
				}
			}
			
			return;
		}
		
		/// <summary>
		/// Places a Signal Tag
		/// </summary>
		/// <param name="signalId">Input:Signal Id to put the block on</param>
		/// <param name="tagName">Input:Name of the signal tag</param>
		/// <param name="tagComments">Input:Signal tag comment</param>
		/// <param name="removalDateTime">Input:Time difference in minutes</param>
		/// <param name="planThrough">Input:Whether the planthrough checkbox should be clicked</param>
		/// <param name="expectedFeedback">Input:If feedback is expected, expected regex</param>
		[UserCodeMethod]
		public static void NS_PlaceSignalTag(string signalId, string tagName, string tagComments, string removalDateTime, bool planThrough, string expectedFeedback)
		{
			Tracklinerepo.LampId = signalId;
			if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Signal Id {"+signalId+"} not found on any open trackline");
				return;
			}
			Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.Click(WinForms.MouseButtons.Right);
			Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.PlaceTag.Click();
			
			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Click();
			if (tagName != "")
			{
				bool containedInList = false;
				IList<ListItem> tagNameList = Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Items;
				foreach (ListItem tagNameListItem in tagNameList)
				{
					if (tagNameListItem.Text == tagName)
					{
						containedInList = true;
						break;
					}
				}
				
				if (containedInList)
				{
					Miscellaneousrepo.TagName = tagName;
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameMenuButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameList.TagNameListItemByName.Click();
				} else {
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Element.SetAttributeValue("Text", tagName);
				}
			}
			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.PressKeys("{TAB}");
			
			if (tagComments != "")
			{
				Miscellaneousrepo.Edit_Place_Tag.Comments.Element.SetAttributeValue("Text", tagComments);
			}
			
			if (removalDateTime != "")
			{
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.Click();
				int removalDateTimeInt = Convert.ToInt32(removalDateTime);
				System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(removalDateTimeInt);
				string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.PressKeys("{TAB}");
				
				//Check if this kicked up some FeedBack
				if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback))
				{
					Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
					return;
				}
			}
			
			if (Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Checked != planThrough)
			{
				Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Click();
			}
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			
			int retries = 0;
			while (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0) && retries < 2)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			//Check if this kicked up some FeedBack
			if (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0)) {
				if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback))
				{
					Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
					return;
				}
			}
			
			if(expectedFeedback != "") {
				Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
				//TODO add in Logic to remove the Tag
				return;
			}
		}
		
		/// <summary>
		/// Place a Trackline Tag
		/// </summary>
		[UserCodeMethod]
		public static void NS_PlaceTrackLineTag(string tagType, string tagName, string comments, string untilTimeDifference, string trackSectionID, bool planThrough, string expectedFeedback)
		{
			Tracklinerepo.TrackSectionId = trackSectionID;

			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("TrackSection ID {"+trackSectionID+"} not found on any open trackline");
			}
			
			
			PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo,
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.PlaceTagInfo
			);

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.PlaceTagInfo,
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo
			);
			
			// Checking for Continue with Tag creation form for 13 devices
			if(Miscellaneousrepo.Edit_Place_Tag.Continue_With_Tag_Creation.SelfInfo.Exists())
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Edit_Place_Tag.Continue_With_Tag_Creation.YesButtonInfo, Miscellaneousrepo.Edit_Place_Tag.Continue_With_Tag_Creation.SelfInfo);
				Report.Info(" Closed the Continue with Tag creation form ");
			}

			
			
			
			int attempts = 0;
			while (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.SelfInfo.Exists(0) && attempts < 4)
			{
				Delay.Milliseconds(500);
				attempts++;
			}

			if (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.SelfInfo.Exists(0))
			{
				Report.Screenshot();
				Report.Error("Tag form does not appear.");
				return;
			}

			switch (tagType.ToUpper())
			{
				case "TRACKBLOCK":
					if (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.TrackBlockRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.TrackOptions.TrackBlockRadioButton);						
					}
					break;
				case "REMINDERBLOCK":
					if (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.ReminderTrackTagRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.TrackOptions.ReminderTrackTagRadioButton);						
					}
					break;
				default:
					Report.Error(string.Format("TagType '{0}' for Track tag was not found to be any available type of tag, defaulting to TrackBlock", tagType));
					if (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.TrackBlockRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.TrackOptions.TrackBlockRadioButton);	
					}
					break;
			}

			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Click();
			if (tagName !=""){
				bool containedInList = false;
				IList<ListItem> tagNameList = Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Items;
				foreach (ListItem tagNameListItem in tagNameList)
				{
					if (tagNameListItem.Text == tagName){
						containedInList = true;
						break;
					}
				}
				
				if (containedInList){
					Miscellaneousrepo.TagName = tagName;
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameMenuButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameList.TagNameListItemByName.Click();
				} else {
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Element.SetAttributeValue("Text", tagName);
				}
			}
			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.PressKeys("{TAB}");
			
			//    		Placing comments

			if (comments !=""){
				
				//    			Miscellaneousrepo.Edit_Place_Tag.Comments.Click();
				Miscellaneousrepo.Edit_Place_Tag.Comments.Element.SetAttributeValue("Text", comments);
			}
			
			//    		Placing time
			
			if (untilTimeDifference !=""){
				
				int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
				System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
				string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.PressKeys("{TAB}");
				
			}
			
			//    		Check if this kicked up some FeedBack
			if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback)){
				Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
				return;
			}
			
			int retries = 0;
			while (Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Checked != planThrough && retries < 5){
				Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Click();
				Delay.Milliseconds(500);
				retries++;
			}
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			
			retries = 0;
			while (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0) && retries < 2)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			//Check if this kicked up some FeedBack
			if (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0)) {
				if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback))
				{
					Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
					return;
				}
			}
			
			if(expectedFeedback != "") {
				Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
				return;
			}
		}
		
		/// <summary>
		/// Place a Switch Tag
		/// </summary>
		[UserCodeMethod]
		public static void NS_PlaceSwitchTags(String tagType, String tagName, String comments, String untilTimeDifference, String switchId, bool planThrough, string expectedFeedback)
		{
			Tracklinerepo.SwitchId = switchId;
			if(!Tracklinerepo.Trackline_Form_By_Switch_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Switch Id {"+switchId+"} not found on any open trackline");
				return;
			}
			
			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo,
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.PlaceTagInfo
			);

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.PlaceTagInfo,
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo
			);
			
			int attempts = 0;
			while (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SelfInfo.Exists(0) && attempts < 4)
			{
				Delay.Milliseconds(500);
				attempts++;
			}

			if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SelfInfo.Exists(0))
			{
				Report.Screenshot();
				Report.Error("Tag form has not appeared.");
				return;

			}
			
			//    		Place a TagType

			switch (tagType.ToUpper())
			{
				case "SWITCHBLOCK":
					if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SwitchBlockRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SwitchBlockRadioButton);
					}
					break;
				case "REMINDERSWITCHTAG":
					if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.ReminderSwitchTagRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.ReminderSwitchTagRadioButton);
					}
					break;
				case "ROADWAYWORKERPROTECTION":
					if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.RoadwayWorkerProtectionRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.RoadwayWorkerProtectionRadioButton);
					}
					break;
				case "BLUESIGNAL/OCCUPIEDCAMPCARPROTECTION":
					if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.BlueSignOccupiedCampRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.BlueSignOccupiedCampRadioButton);
					}
					break;
				default:
					// This is a terrible way to handle an incorrect input, and is only being maintained in order to prevent other tests from breaking
					Report.Error(string.Format("Input '{0}' for switch tag was not found to be any available type of tag, defaulting to SwitchBlock", tagType));
					if (!Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SwitchBlockRadioButton.Checked)
					{
						GeneralUtilities.CheckRadioButtonAndVerifyChecked(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SwitchBlockRadioButton);
					}
					break;
			
			}

			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Click();
			if (tagName != ""){
				bool containedInList = false;
				IList<ListItem> tagNameList = Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Items;
				foreach (ListItem tagNameListItem in tagNameList)
				{
					if (tagNameListItem.Text == tagName){
						containedInList = true;
						break;
					}
				}
				
				if (containedInList){
					Miscellaneousrepo.TagName = tagName;
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameMenuButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameList.TagNameListItemByName.Click();
				} else {
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Element.SetAttributeValue("Text", tagName);
				}
			}
			Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.PressKeys("{TAB}");
			
			//    		Place comments

			if (comments !="")
			{
				Miscellaneousrepo.Edit_Place_Tag.Comments.Element.SetAttributeValue("Text", comments);
			}
			
			//    		Place time
			
			if (untilTimeDifference !="")
			{
				int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
				System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
				string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.PressKeys("{TAB}");
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.DoubleClick();
			}
			if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback)){
				Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
				return;
			}
			
			if (Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Checked != planThrough){
				Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Click();
			}
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			
			int retries = 0;
			while (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0) && retries < 2)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			//Check if this kicked up some FeedBack
			if (Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists(0)) {
				if (!CheckFeedback(Miscellaneousrepo.Edit_Place_Tag.Feedback, expectedFeedback))
				{
					Miscellaneousrepo.Edit_Place_Tag.ResetButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.CancelButton.Click();
					return;
				}
			}
			
			if(expectedFeedback != "") {
				Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
				return;
			}
			
		}
		
		[UserCodeMethod]
		public static void NS_EditSwitchTag (string tagName, string newTagName, string comments, string untilTimeDifference, string deviceId, bool planThrough)
		{
			//Open the tag
			Tracklinerepo.SwitchId = deviceId;
			if(!Tracklinerepo.Trackline_Form_By_Switch_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Device Id {"+deviceId+"} not found on any open trackline");
				return;
			}
			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.EnsureVisible();
			Tracklinerepo.SwitchMenuName = tagName;
			byte retries = 0;
			while (retries < 3 && !Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists())
			{
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right);
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OpenTag.Click();
				
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.Click();
				Ranorex.Delay.Seconds(1);
			}
			
			if (!Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists())
			{
				Ranorex.Report.Failure("Couldn't open tag " + tagName + ".");
				return;
			}
			
			//Work through possible edits
			if (!newTagName.Equals(""))
			{
				Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Click();
				bool containedInList = false;
				IList<ListItem> tagNameList = Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Items;
				foreach (ListItem tagNameListItem in tagNameList)
				{
					if (tagNameListItem.Text == tagName){
						containedInList = true;
						break;
					}
				}
				
				if (containedInList){
					Miscellaneousrepo.TagName = tagName;
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameMenuButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameList.TagNameListItemByName.Click();
				} else {
					Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Element.SetAttributeValue("Text", tagName);
				}
				Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.PressKeys("{TAB}");
			}
			
			//Comments
			if (!comments.Equals(""))
			{
				Miscellaneousrepo.Edit_Place_Tag.Comments.Element.SetAttributeValue("Text", comments);
			}
			
			//Place time
			
			if (untilTimeDifference !="")
			{
				int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
				System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
				string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
				Miscellaneousrepo.Edit_Place_Tag.EstimatedRemovalDateTime.EstimatedRemovalDateTimeMenuButton.PressKeys("{TAB}");
			}
			
			if (Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Checked != planThrough){
				Miscellaneousrepo.Edit_Place_Tag.PlanThroughCheckbox.Click();
			}
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
		}
		
		
		/// <summary>
		/// Removes All Signal Tags
		/// </summary>
		/// <param name="signalId">Input:Signal Id to remove tags from</param>
		//    	[UserCodeMethod]
		//    	public static void NS_RemoveAllTagsFromSignal(string signalId, string tagName, string tagComments, string removalDateTime, bool planThrough, string expectedFeedback)
		//        {
		//    		Tracklinerepo.LampId = signalId;
		//    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
		//    		{
		//    			Ranorex.Report.Error("Signal Id {"+signalId+"} not found on any open trackline");
		//    			return;
		//    		}
		//    		Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.Click(WinForms.MouseButtons.Right);
		//    		Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.
		//    	}
		
		/// <summary>
		/// For block tag pop up appears when you remove tag, this method click ok if it appears
		/// </summary>
		public static void HandleBlockTagPopup()
		{
			var Miscellaneousrepo = Miscellaneous_Repo.Instance;
			if(Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.OkButtonInfo.Exists())
			{
				Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentText.Click();
				Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentText.Element.SetAttributeValue("Text", "Automation");
				Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentText.PressKeys("{TAB}");
				Ranorex.Delay.Milliseconds(500);
				Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.OkButton.Click();
			}
		}
		
		/// <summary>
		/// Removes all Tags from the Tag Summary List
		/// </summary>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_RemoveAllTags(bool closeForms)
		{
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info("Initiating removal of all tags from the controlled territories.");
			
			int numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			Miscellaneousrepo.TagsSummaryListIndex = "0";
			
			Ranorex.Report.Info(String.Format("Found {0} tag in the tag list summary.", numberOfTags.ToString()));
			
			for (int i=0; i<numberOfTags; i++)
			{
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
				
				Miscellaneousrepo.Edit_Place_Tag.RemoveButton.Click();
				Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
				HandleBlockTagPopup();
				Delay.Duration(100);
				//    			Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentText.Element.SetAttributeValue("Text", "Automation");
				//    			Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.OkButton.Click();
			}
			
			int retries = 0;
			while (Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count != 0 && retries < 2)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			if (Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count != 0)
			{
				Ranorex.Report.Error("Not all Tags could be removed");
			}
			
			if (closeForms)
			{
				Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
			}
			return;
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
		/// Function that will remove a switch tag.
		/// </summary>
		/// <param name="deviceId"></param>
		[UserCodeMethod]
		public static void NS_RemoveSwitchTagFromTrack (string tagName, string deviceId)
		{
			//Open the tag
			Tracklinerepo.SwitchId = deviceId;
			if(!Tracklinerepo.Trackline_Form_By_Switch_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Device Id {"+deviceId+"} not found on any open trackline");
				return;
			}
			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.EnsureVisible();
			Tracklinerepo.SwitchMenuName = tagName;
			byte retries = 0;
			while (retries < 3 && !Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists())
			{
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right);
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OpenTag.Click();
				
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.Click();
				Ranorex.Delay.Seconds(1);
			}
			
			//If it doesn't show, kill it out
			if (!Miscellaneousrepo.Edit_Place_Tag.SelfInfo.Exists())
			{
				Ranorex.Report.Error("Could not open tag with name " + tagName + ".");
				return;
			}
			
			//Remove should be disabled and greyed out,
			retries = 0;
			while (retries < 3 && !Miscellaneousrepo.Edit_Place_Tag.RemoveButton.Enabled.Equals(false))
			{
				Miscellaneousrepo.Edit_Place_Tag.RemoveButton.Click();
				Ranorex.Delay.Milliseconds(500);
			}
			
			if (!Miscellaneousrepo.Edit_Place_Tag.RemoveButton.Enabled.Equals(false) && Miscellaneousrepo.Edit_Place_Tag.Feedback.TextValue.Equals(""))
			{
				Ranorex.Report.Error("Remove tag button not funtioning properly.");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Edit_Place_Tag.CancelButtonInfo, Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
				return;
			}
			
			if (!Miscellaneousrepo.Edit_Place_Tag.Feedback.TextValue.Equals(""))
			{
				Ranorex.Report.Warn("Unexpected Feedback: " + Miscellaneousrepo.Edit_Place_Tag.Feedback.TextValue + ".");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Edit_Place_Tag.CancelButtonInfo, Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Edit_Place_Tag.OkButtonInfo, Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentTextInfo);
			Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.CommentText.Element.SetAttributeValue("Text", "Automation");
			Miscellaneousrepo.Edit_Place_Tag.Confirm_Block_Removal.OkButton.Click();
			//TODO Validate on trackline that tag has been removed
			return;
		}
		
		/// <summary>
		/// Places Tag type
		/// </summary>
		/// <param name="tagType">Input:TagType options are 'TrackBlock', 'ReminderBlock', 'SwitchBlock', 'ReminderSwitchTag', 'RoadwayWorkerProtection',
		/// 				     	'RoadwayWorkerProtection', 'BlueSignal/OccupiedCampCarProtection', 'signalblock' - Not case sensitive</param>
		/// <param name="objectId">Input:Object Id refers to Tracksection, signal and Switch</param>
		/// <param name="tagName">Input:Name of the tag</param>
		/// <param name="tagComments">Input:tag comment</param>
		/// <param name="removalDateTime">Input:Time difference in minutes</param>
		/// <param name="planThrough">Input:Whether the planthrough checkbox should be clicked</param>
		/// <param name="expectedFeedback">Input:If feedback is expected, expected regex</param>
		[UserCodeMethod]
		public static void NS_PlaceTags(string tagType, string tagName, string comments, string untilTimeDifference, string objectId, bool planThrough, string expectedFeedback)
		{
			switch(tagType.ToLower())
			{
				case "trackblock":
					NS_PlaceTrackLineTag("TrackBlock", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "reminderblock":
					NS_PlaceTrackLineTag("ReminderBlock", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "switchblock":
					NS_PlaceSwitchTags("SwitchBlock", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "reminderswitchtag":
					NS_PlaceSwitchTags("ReminderSwitchTag", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "roadwayworkerprotection":
					NS_PlaceSwitchTags("RoadwayWorkerProtection", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "bluesignal/occupiedcampcarprotection":
					NS_PlaceSwitchTags("BlueSignal/OccupiedCampCarProtection", tagName, comments, untilTimeDifference, objectId, planThrough, expectedFeedback);
					break;
					
				case "signalblock":
					NS_PlaceSignalTag(objectId, tagName, comments, untilTimeDifference, planThrough, expectedFeedback);
					break;
					
				default:
					Ranorex.Report.Error(string.Format("Invalid Tag type. The value given is '{0}'", tagType));
					break;
			}
		}
		
		
		/// <summary>
		/// Selects multiple tracklines/Signals/Switches by holding control and then clicking on each asset.
		/// This would usually be used when issuing multiple tags.
		/// </summary>
		/// <param name="tagtype"> tagType indicates type of tag like Trackline/signal/Switch</param>
		/// <param name="objectIDs"> ojectIDs seperated by '|' or only one object</param>
		[UserCodeMethod]
		public static void NS_HoldCtrlSelectMultipleTrackObjects(string tagType, string objectIDs)
		{
			string[] objects = objectIDs.Split('|');
			
			Keyboard.Down(Keys.ControlKey);
			
			foreach(string objectId in objects)
			{
				var element = FindTrackObjectByContext(tagType, objectId);
				element.Click();
			}
			Keyboard.Up(Keys.ControlKey);
		}
		
		/// <summary>
		/// Get the trackline/Signal/Switch object associated with the tdmsID
		/// </summary>
		/// <param name="tagtype"> tagType indicates type of tag like Trackline/signal/Switch</param>
		/// <param name="tdmsID">tdmsID that of indicates signalID/TrackID/SwitchID</param>
		/// <returns>JavaElement of the object selected</returns>
		public static JavaElement FindTrackObjectByContext(string tagType, string tdmsID)
		{
			JavaElement source;
			var repo = Trackline_Repo.Instance;
			var objInfo =  repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo;
			
			switch(tagType.ToLower())
			{
				case "switchblock":
				case "roadwayworkerprotection":
				case "bluesignal/occupiedcampcarprotection":
					repo.SwitchId = tdmsID;
					objInfo = repo.Trackline_Form_By_Switch_Id.SwitchObjectInfo;
					break;
					
				case "signalblock":
					repo.LampId = tdmsID;
					objInfo = repo.Trackline_Form_By_Signal_Id.SignalObjectInfo;
					break;
				case "trackblock":
					repo.TrackSectionId = tdmsID;
					objInfo = repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo;
					break;
				default:
					Ranorex.Report.Failure("Invalid Tagtype");
					break;
			}
			
			try
			{
				source = Host.Local.FindSingle(objInfo.AbsolutePath).As<JavaElement>();
			}
			catch(ElementNotFoundException ex)
			{
				//Catch and rethrow the error to prevent errors when the asset cannot be found
				Report.Error(String.Format(@"Error finding oject asset by context. Exception information: {0}",ex.Message));
				//throw without specifying the original exception to preserve the stack trace
				throw;
			}
			
			return source;
		}
		
		
		/// <summary>
		/// Edit Tags - TagType or TagName or TagComments
		/// </summary>
		/// <param name="tagType">Input:TagType options are 'TrackBlock', 'ReminderBlock', 'SwitchBlock', 'ReminderSwitchTag', 'RoadwayWorkerProtection',
		///                          'RoadwayWorkerProtection', 'BlueSignal/OccupiedCampCarProtection', 'signalblock' - Not case sensitive</param>
		/// <param name="objectId">Input:Object Id refers to Tracksection, signal and Switch</param>
		/// <param name="comments">Input:Signal tag comment</param>
		/// <param name="editTagName">Input:Name of the tag </param>
		/// <param name="editTagComments">Input:tag comments to modify</param>
		/// <param name="editTagType">Input:TagType</param>

		[UserCodeMethod]
		public static void NS_EditTags(string editTagName, string editTagType, string editTagComments, string tagType, string tagName, string comments, string objectId)
		{
			/// Opens the Tag Summary Form if not already open
			NS_OpenTagsSummaryList_MainMenu();
			
			// Modify Tag from Track block to reminder track type
			if(editTagType != "")
			{
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
				
				if (!Miscellaneousrepo.Edit_Place_Tag.TrackOptions.ReminderTrackTagRadioButton.Checked)
				{
					Miscellaneousrepo.Edit_Place_Tag.TrackOptions.ReminderTrackTagRadioButton.Click();
					Ranorex.Report.Info("Reminder Track type has been selected");
					Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
					HandleBlockTagPopup();
				}
			}
			
			// Modify tagname
			if(editTagName != "")
			{
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
				GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTagInfo,
				                                          Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
				Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.Element.SetAttributeValue("Text", "");
				Miscellaneousrepo.Edit_Place_Tag.TagName.TagNameText.PressKeys(editTagName);
				Ranorex.Report.Info("Renamed Tag name is " +editTagName);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Edit_Place_Tag.OkButtonInfo,
				                                                  Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
			}
			
			//Modify tag comments
			if(editTagComments != "")
			{
				Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
				GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTagInfo,
				                                          Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
				Miscellaneousrepo.Edit_Place_Tag.Comments.Element.SetAttributeValue("Text", "");
				Miscellaneousrepo.Edit_Place_Tag.Comments.PressKeys(editTagComments);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Edit_Place_Tag.OkButtonInfo,
				                                                  Miscellaneousrepo.Edit_Place_Tag.SelfInfo);
			}

			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo,
			                                                  Miscellaneousrepo.Tags_Summary_List.SelfInfo);
		}

		
		
		/// <summary>
		/// Removes Single Tag from the Tag Summary List
		/// </summary>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		/// <param name="tagname">Input: specific tagName to be removed from the tag summary list</param>
		[UserCodeMethod]
		public static void NS_RemoveSingleTag(bool closeForms, string tagName)
		{
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info("Initiating removal of a tag from the controlled territories.");

			if(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
			{
				Ranorex.Report.Info("There are NO tags found in the Table");
				if (closeForms)
				{
					Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
				}
				return;
			}
			
			int numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			string tagValue;
			int count = 0;
			for (int i=0; i<numberOfTags; i++)
			{
				if( count > 0 )
				{
					Report.Info("Removed a tag");
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo, Miscellaneousrepo.Tags_Summary_List.SelfInfo);
					}
					return;
				}
				Miscellaneousrepo.TagsSummaryListIndex = i.ToString();
				tagValue = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				if ( tagValue.Contains(tagName) )
				{
					
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
					
					Miscellaneousrepo.Edit_Place_Tag.RemoveButton.Click();
					Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
					HandleBlockTagPopup();
					count++;
				}
			}
			
			if (closeForms)
			{
				Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
			}
		}
		
		/// <summary>
		/// Opening the Tag summary list table, not modifing anything, Closing it.
		/// </summary>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_OpenTagSummaryAndClose(bool closeForms)
		{
			
			NS_OpenTagsSummaryList_MainMenu();
			Miscellaneousrepo.TagsSummaryListIndex = "0";
			Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
			Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			
			
		}
		
		/// <summary>
		/// Validate the Tag Type
		/// </summary>
		/// <param name="tagname">Input: specific tagName to be validated from the tag summary list</param>
		/// <param name="tagType">Input:tagType to be verified</param>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_ValidateTagTypeExists(string tagName, string tagType, bool closeForms)
		{
			int numberOfTags = 0;
			string retrieveTagName = "";   // To Retrieve tag name from PDS application
			
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info("Validating Modified tag Type");

			if(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
			{
				Ranorex.Report.Failure("There are NO tags to validate");
				if (closeForms)
				{
					Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
				}
				return;
			}
			
			numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			tagType = tagType.ToLower();
			for (int i=0; i < numberOfTags; i++)
			{
				Miscellaneousrepo.TagsSummaryListIndex = i.ToString();
				retrieveTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				if ( retrieveTagName.Equals(tagName))
				{
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
					// Verify for Track Block tag is selected
					if(tagType.Equals("trackblock"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.TrackOptions.TrackBlockRadioButton.Checked)
						{
							Report.Success(" validation of Track Block tag type is successfull");
						}
						else
						{
							Report.Failure("validation of Track Block tag type is failed");
						}
					}
					// Verify for Reminder block tag is selected
					if(tagType.Equals("reminderblock"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.TrackOptions.ReminderTrackTagRadioButton.Checked)
						{
							Report.Success("Validation of Reminder Track tag type is successfull");
						}
						else
						{
							Report.Failure("Validation of Reminder Track tag type is failed");
						}
					}
					// Verify for Switch block tag is selected
					if(tagType.Equals("switchblock"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.SwitchBlockRadioButton.Checked)
						{
							Report.Success("Validation of Switch Block tag type is successfull");
						}
						else
						{
							Report.Failure("Validation of Switch Block tag type is failed");
						}
					}
					// Verify for Reminder Switch tag is selected
					if(tagType.Equals("reminderswitchtag"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.ReminderSwitchTagRadioButton.Checked)
						{
							Report.Success("Vaildation of Reminder Switch tag is successfull");
						}
						else
						{
							Report.Failure("Vaildation of Reminder Switch tag is failed");
						}
					}
					// Verify for Roadway Worker Protection tag is selected
					if(tagType.Equals("roadwayworkerprotection"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.RoadwayWorkerProtectionRadioButton.Checked)
						{
							Report.Success("Validation of Roadway Worker Protection tag type is successfull");
						}
						else
						{
							Report.Failure("Validation of Roadway Worker Protection tag type is failed");
						}
					}
					// Verify for Blue Signal / Occupied Camp Car Protection tag is selected
					if(tagType.Equals("bluesignal/occupiedcampcarprotection"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.SwitchOptions.BlueSignOccupiedCampRadioButton.Checked)
						{
							Report.Success("Validation of Blue Signal / Occupied Camp Car Protection tag type is successful");
						}
						else
						{
							Report.Failure("Validation of Blue Signal / Occupied Camp Car Protection tag type is failed");
						}
					}
					// Verify for Signal block tag is selected
					if(tagType.Equals("signalblock"))
					{
						if(Miscellaneousrepo.Edit_Place_Tag.SignalOptions.SignalBlockRadioButton.Checked)
						{
							Report.Success("Validation of signalblock tag type is successful");
						}
						else
						{
							Report.Failure("Validation of signalblock tag type is failed");
						}
						
					}
				}
				else
				{
					Report.Failure(" Validation of Tag type is failed ");
				}
			}
			if (closeForms)
			{
				Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
			}
		}
		
		/// <summary>
		/// Validate the tag Name
		/// </summary>
		/// <param name="tagName">Input:tagname to be verified</param>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_ValidateTagNameExists_TagSummaryList(string tagName, bool closeForms, bool validateExists)
		{
			int numberOfTags = 0;
			bool tagfound = false;
			string retrieveTagName = "";  // To Retrieve tag name from PDS application
			
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info("Validating Modified tag Name");
			numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			for (int i=0; i<numberOfTags; i++)
			{
				Miscellaneousrepo.TagsSummaryListIndex = i.ToString();
				retrieveTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				Report.Info(retrieveTagName);
				Report.Info(tagName);
				if(tagName.Equals(retrieveTagName))
				{
					tagfound = true;
					break;
				}
				
			}
			if(tagfound == validateExists)
			{
				Ranorex.Report.Success((tagfound ? "Found":"Did not find") + " Tag {" + tagName + "} in Tag Summary List");
			}
			else
			{
				Ranorex.Report.Failure((tagfound ? "Found":"Did not find") + " Tag {" + tagName + "} in Tag Summary List");
			}
			
			if (closeForms)
			{
				Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
			}
		}
		
		/// <summary>
		/// Validate the Edited tag Comment
		/// </summary>
		/// <param name="tagname">Input: specific tagName to be validated from the tag summary list</param>
		/// <param name="tagComment">Input:tagComment to be verified</param>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_ValidateTagCommentExists(string tagName, string tagComment, bool closeForms)
		{
			int numberOfTags = 0;
			string retrieveTagComment = "";    // To Retrieve tag comment from PDS application
			string retrieveTagName = "";      // To Retrieve tag name from PDS application
			
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info(" Validating Modified tag Comment ");

			if(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
			{
				Ranorex.Report.Failure(" There are NO tags to validate ");
				if (closeForms)
				{
					Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
				}
				return;
			}

			numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			for (int i=0; i<numberOfTags; i++)
			{
				Miscellaneousrepo.TagsSummaryListIndex = i.ToString();
				retrieveTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				if ( retrieveTagName.Equals(tagName))
				{
					//   Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
					//   Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
					retrieveTagComment = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.Comments.GetAttributeValue<string>("Text");
					Report.Info(tagComment);
					Report.Info(retrieveTagComment);
					if(tagComment.Equals(retrieveTagComment))
					{
						Report.Success(" Validation of Comments field is successfull ");
					}
					else
					{
						Report.Failure("Validation of Comments field is failed");
					}
				}
				else
				{
					Report.Failure(" Validation of Tag name field is failed ");
				}
			}
			if (closeForms)
			{
				Miscellaneousrepo.Tags_Summary_List.WindowControls.Close.Click();
			}
		}

		/// <summary>
		/// Delete Tags from Edit Tag form
		/// </summary>
		/// <param name="tagname">Input: specific tagName to be validated from the tag summary list</param>
		/// <param name="betweenAtValues">Input:betweenAtValues to be deleted</param>
		/// <param name="andValues">Input:andValues to be deleted(No Value for Switch and Signal objects )</param>
		/// <param name="onTrackValue">Input: Delete specific onTrackValue of TrackSection (No Value for Switch and Signal objects )</param>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_DeleteTag_EditTagForm(string tagName, string betweenAtValue, string andValue, string onTrackValue, bool closeForms)
		{
			string retrieveTagName = "";
			string pdsBetweenAtValue = "";
			string pdsAndValue = "";
			string pdsOnTrackValue = "";
			int numberOfTags_EditTagForm = 0;
			int numberOfTags = 0;
			
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info(" Deleting Tag ");

			if(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
			{
				Ranorex.Report.Failure(" There are NO tags to Delete ");
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo, Miscellaneousrepo.Tags_Summary_List.SelfInfo);
				}
				return;
			}
			
			numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			for (int j = 0; j < numberOfTags; j++)
			{
				Miscellaneousrepo.TagsSummaryListIndex = j.ToString();
				retrieveTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				if ( retrieveTagName.Equals(tagName))
				{
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
					break;
				}
			}
			
			numberOfTags_EditTagForm = Miscellaneousrepo.Edit_Place_Tag.TagTable.Self.Rows.Count;
			for (int i = 0; i < numberOfTags_EditTagForm; i++ )
			{
				Miscellaneousrepo.TagIndex = i.ToString();
				pdsBetweenAtValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.BetweenAt.GetAttributeValue<string>("Text");
				pdsAndValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.And.GetAttributeValue<string>("Text");
				pdsOnTrackValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.OnTrack.GetAttributeValue<string>("Text");

				if( betweenAtValue.Equals(pdsBetweenAtValue) && andValue.Equals(pdsAndValue) && onTrackValue.Equals(pdsOnTrackValue))
				{
					Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.BetweenAt.Click(WinForms.MouseButtons.Right);
					Miscellaneousrepo.Edit_Place_Tag.TagTable.MenuCellMenu.DeleteLine.Click();
					Delay.Milliseconds(500);
					break;
				}
			}
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			HandleBlockTagPopup();
			Report.Info(" Deleted Tag ");

			if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo, Miscellaneousrepo.Tags_Summary_List.SelfInfo);
			}
		}
		
		
		/// <summary>
		/// Validate Deleted Tag from Edit Tag form
		/// </summary>
		/// <param name="tagname">Input: specific tagName to be validated from the tag summary list</param>
		/// <param name="betweenAtValues">Input:betweenAtValues to be Validated</param>
		/// <param name="andValues">Input:andValues to be Validated (No Value for Switch and Signal objects )</param>
		/// <param name="onTrackValue">Input: Validate specific onTrackValue of TrackSection (No Value for Switch and Signal objects )</param>
		/// <param name="closeForms">Input:Closes Tag Summary Form</param>
		[UserCodeMethod]
		public static void NS_Validate_DeleteTag_EditTagForm(string tagName, string betweenAtValue, string andValue, string onTrackValue, bool closeForms)
		{
			string retrieveTagName = "";
			string pdsBetweenAtValue = "";
			string pdsAndValue = "";
			string pdsOnTrackValue = "";
			int numberOfTags_EditTagForm = 0;
			int numberOfTags = 0;
			
			NS_OpenTagsSummaryList_MainMenu();
			Report.Info(" Validating the Deleted tag in Edit Tags Form ");

			if(Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count == 0)
			{
				Ranorex.Report.Failure(" There are NO tags to Validate ");
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo, Miscellaneousrepo.Tags_Summary_List.SelfInfo);
				}
				return;
			}
			
			numberOfTags = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.Self.Rows.Count;
			for (int j = 0; j < numberOfTags; j++)
			{
				Miscellaneousrepo.TagsSummaryListIndex = j.ToString();
				retrieveTagName = Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.TagName.GetAttributeValue<string>("Text");
				if ( retrieveTagName.Equals(tagName))
				{
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.TagsSummaryListRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
					Miscellaneousrepo.Tags_Summary_List.TagsSummaryListTable.MenuCellMenu.OpenTag.Click();
					break;
				}
			}
			
			numberOfTags_EditTagForm = Miscellaneousrepo.Edit_Place_Tag.TagTable.Self.Rows.Count;
			for (int i = 0; i < numberOfTags_EditTagForm; i++ )
			{
				Miscellaneousrepo.TagIndex = i.ToString();
				pdsBetweenAtValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.BetweenAt.GetAttributeValue<string>("Text");
				pdsAndValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.And.GetAttributeValue<string>("Text");
				pdsOnTrackValue = Miscellaneousrepo.Edit_Place_Tag.TagTable.TagRowByIndex.OnTrack.GetAttributeValue<string>("Text");
				if( betweenAtValue.Equals(pdsBetweenAtValue) && andValue.Equals(pdsAndValue) && onTrackValue.Equals(pdsOnTrackValue))
				{
					Report.Failure(" Tag is not Deleted ");
				}
			}
			Report.Success(" Tag of BetweenAt value :" +betweenAtValue + " is Deleted successfully");
			
			Miscellaneousrepo.Edit_Place_Tag.OkButton.Click();
			Report.Info(" Validation of Deleted Tag is Successful ");
			if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Tags_Summary_List.WindowControls.CloseInfo, Miscellaneousrepo.Tags_Summary_List.SelfInfo);
			}
		}
		/// <summary>
		/// Validate All Tags Present on Track Line
		/// </summary>
		/// <param name="tagType">tagType indicates type of tag like Track/signal/Switch</param>
		/// <param name="objectId">Input:Object Id refers to Tracksection, signal and Switch</param>
		/// <param name="tagName">Input: specific tagName to be validated from the tag Track Line</param>
		/// <param name="validateExists">Passing bool value to validate tags present on Track Line</param>
		[UserCodeMethod]
		public static void NS_ValidateTags_Trackline(string tagType ,string objectId,string tagName,bool validateExists)
		{
			
			string tagNameValidate = "";
			switch(tagType.ToLower())
			{
				case "switchblock":
					
					Tracklinerepo.SwitchId = objectId;
					Tracklinerepo.SwitchMenuName = tagName;
					GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo,Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OpenTagInfo);
					GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OpenTagInfo,Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByNameInfo);
					if(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByNameInfo.Exists(0))
					{
						tagNameValidate=Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.GetAttributeValue<string>("AccessibleName");
						if(tagNameValidate.Equals(tagName) && (validateExists==true))
						{
							Ranorex.Report.Success("Tag Name "+tagName+" found on trackline");
						}
						else
						{
							Ranorex.Report.Failure("Tag Name  "+tagName+" not found on trackline");
						}
					}
					
					else
					{
					   if(!validateExists)
						{
							Ranorex.Report.Success("Tag Name  "+tagName+" not found on trackline");
						}
						else
						{
							Ranorex.Report.Failure("Validate Tag Name is failed");
						}
					}
					break;
					
				case "signalblock":
					
					Tracklinerepo.LampId=objectId;
					Tracklinerepo.SignalMenuName = tagName;
					GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo,Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.OpenTagInfo);
					GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.OpenTagInfo,Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SignalMenuItemByNameInfo);
					if(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo.Exists(0))
					{
						tagNameValidate=Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SignalMenuItemByName.GetAttributeValue<string>("AccessibleName");
						if(tagNameValidate.Equals(tagName) && (validateExists==true))
						{
							Ranorex.Report.Success("Tag Name "+tagName+" found on trackline");
						}
						else
						{
							Ranorex.Report.Failure("Tag Name  "+tagName+" not found on trackline");
						}
						
					}
					else 
					{
						if(!validateExists)
						{
							Ranorex.Report.Success("Tag Name  "+tagName+" not found on trackline");
						}
						else
						{
							Ranorex.Report.Failure("Validate Tag Name is failed");
						}
					}
					
					break;
				
				case "trackblock":
					
					Tracklinerepo.TagName = tagName;
					if(Tracklinerepo.Trackline_Form.Tags.TrackSectionTagObjectInfo.Exists(0) && validateExists)
					{
						Ranorex.Report.Success("Tag Name  "+tagName+" found on trackline");
					}
					else 
					{
						if(!validateExists)
						{
							Ranorex.Report.Success("Tag Name "+tagName+" not found on trackline");
						}
						else
						{
							Ranorex.Report.Failure("Validate Tag Name is failed");
						}
					}
					
				    break;
					default:Ranorex.Report.Info("Valid Tag name not found");
					break;
			}
			
			Tracklinerepo.Trackline_Form.Feedback.Click();
			
		}
			
	}
}
