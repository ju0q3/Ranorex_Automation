/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/9/2019
 * Time: 1:36 PM
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
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_InputBulletins
    {
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        
        
        /// <summary>
    	/// Fill in the header portion of the Bulletin Input Form
    	/// </summary>
    	/// <param name="district">Input:district</param>
    	/// <param name="type">Input:type</param>
    	public static void InputBulletinHeader(string district, string type)
    	{
    		//If Bulletin doesn't have a set district, assume it's all controlled controlled districts.
    		if (district == "") {
    			district = "All Controlled Districts";
    		}
    		//Select the District from the District List
    		
    		if (!Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItem.GetAttributeValue<string>("SelectedItemText").Contains(district)) {
    			if (!Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItem.Enabled)
    			{
    				GeneralUtilities.ClickAndWaitForEnabledWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItemInfo);
    			}
    			Ranorex.Report.Info("TestStep", "Selecting District {"+district+"}.");
    			Bulletinsrepo.DistrictName = district;
    			GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItemInfo,
    			                                        Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.DistrictListItemByDistrictNameInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.DistrictListItemByDistrictNameInfo);
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuItem.Click();
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.District.DistrictMenuList.DistrictListItemByDistrictName.Click();
    		}
    		
    		GeneralUtilities.CheckWaitState(10);
    		
    		//Bulletin selection is a little different from District, as this element is defaulted to null and you can't do a contains on null
    		if(((Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.SelectedItemIndex == -1) ? true : !Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.GetAttributeValue<string>("SelectedItemText").Contains(type))) {
    			Bulletinsrepo.BulletinTypeName = type;
    			Ranorex.Report.Info("TestStep", "Selecting Bulletin Type {"+type+"}.");
    			GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItemInfo,
    			                                         Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo);
    			GeneralUtilities.CheckWaitState(10);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeName.EnsureVisible();
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeNameInfo);
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuItem.Click();
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.Type.TypeMenuList.TypeListItemByBulletinTypeName.Click();
    		}
    		GeneralUtilities.CheckWaitState(10);
    		return;
    	}
    	
    	/// <summary>
    	/// Creates an Aux Grade Xing Activat Failure, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:dotCrossingId</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxGradeXingActivatFailureBulletin(string bulletinSeed, string district, string dotCrossingId, string at, string milepost, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Aux Grade Xing Activat Failure";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.DOTCrossingId.Click();
    		
    		if (dotCrossingId != "")
    		{
    		    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
    		}
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.DOTCrossingId.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (at != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.At.Element.SetAttributeValue("Text", at);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.At.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Milepost.Element.SetAttributeValue("Text", milepost);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Milepost.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tracks != "")
    		{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Tracks.Element.SetAttributeValue("Text", tracks);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Tracks.PressKeys("{TAB}");
			
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActivationFailure.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Aux Grade Xing Activat Failure at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Aux Grade Xing Activat Failure at MP {"+nearMilepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Aux Grade Xing False Activat, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:dotCrossingId</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxGradeXingFalseActivatBulletin(string bulletinSeed, string district, string dotCrossingId, string at, string milepost, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Aux Grade Xing False Activat";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.DOTCrossingId.Click();
    		
    		if (dotCrossingId != "")
    		{
    		    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
    		}
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.DOTCrossingId.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (at != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.At.Element.SetAttributeValue("Text", at);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.At.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Aux Grade Xing False Activation at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Aux Grade Xing False Activation at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Area Speed Restric Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="track">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryAreaSpeedRestricBulletin(string bulletinSeed, string district, string between, string and, string track, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Area Speed Restric";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Between.Click();
    		
    		if (between != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Between.Element.SetAttributeValue("Text", between);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Between.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (and != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.And.Element.SetAttributeValue("Text", and);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.And.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (track != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Track.Element.SetAttributeValue("Text", track);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Track.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryAreaSpeedRestrict.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary - Area Speed Restric at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, track, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary - Area Speed Restric at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Auxiliary Bad Footing, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="comment">Input:comment</param>
    	/// <param name="issuedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryBadFootingBulletin(string bulletinSeed, string district, string milepost, string comment, string issuedBy, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Bad Footing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Click();
			
			if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (comment != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.BadFootingComment.Element.SetAttributeValue("Text", comment);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.BadFootingComment.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Bad Footing at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Auxiliary Bad Footing at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.NS_CloseBulletinForm();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Bad Footing Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="comment">Input:comment</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryBadFootingBulletin(string bulletinSeed, string district, string milepost, string comment, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Bad Footing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (comment != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.BadFootingComment.Element.SetAttributeValue("Text", comment);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.BadFootingComment.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Bad Footing Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Bad Footing Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.NS_CloseBulletinForm();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Miscellaneous Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="instructions">Input:instructions</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryMiscellaneousBulletin(string bulletinSeed, string district, string milepost, string instructions, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Miscellaneous";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (instructions != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Instructions.Element.SetAttributeValue("Text", instructions);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Instructions.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryMiscellaneous.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Miscellaneous at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Miscellaneous at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Point Speed Restriction Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="on">Input:on</param>
    	/// <param name="speed">Input:speed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryPointSpeedRestrictBulletin(string bulletinSeed, string district, string at, string on, string speed, string account, string effectiveTimeDifference, string untilTimeDifference, string milepost, string expectedFeedback, string issuedBy, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Pt Speed Restrict";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.At.Click();
    		
    		if (at != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.At.Element.SetAttributeValue("Text", milepost);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.At.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (on != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Track.Element.SetAttributeValue("Text", on);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Track.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (speed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.MaximumSpeed.Element.SetAttributeValue("Text", speed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Account.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (issuedBy != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryPointSpeedRestrict.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Point Speed Restrict Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", speed);
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Point Speed Restrict Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Right of Way Cond. Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="instructions">Input:instructions</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryRightOfWayCondBulletin(string bulletinSeed, string district, string milepost, string instructions, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Right of Way Cond.";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (instructions != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Instructions.Element.SetAttributeValue("Text", instructions);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Instructions.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRightOfWayCond.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Right of Way Cond at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Right of Way Cond at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Rusty Rail Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryRustyRailAreaBulletin(string bulletinSeed, string district, string between, string and, string tracks, string account, string effectiveTimeDifference, string untilTimeDifference, string issuedBy, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Rusty Rail - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Between.Click();
    		
    		if (between != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Between.Element.SetAttributeValue("Text", between);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Between.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (and != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.And.Element.SetAttributeValue("Text", and);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.And.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Tracks.Element.SetAttributeValue("Text", tracks);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Tracks.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Account.PressKeys("{TAB}");
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.IssuedBy.PressKeys("{TAB}");
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryRustyRailArea.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary - Rusty Rail - Area at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary - Rusty Rail - Area at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Stop And Flag Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryStopAndFlagBulletin(string bulletinSeed, string district, string approaching, string nearMilepost, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Stop and Flag";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Approaching.Click();
    		
    		if (approaching != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Approaching.Element.SetAttributeValue("Text", approaching);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Approaching.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Tracks.Element.SetAttributeValue("Text", tracks);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Tracks.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Account.PressKeys("{TAB}");
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.IssuedBy.PressKeys("{TAB}");
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryStopAndFlag.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary - Rusty Rail - Area at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary - Rusty Rail - Area at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Tracks Out of Service Bulletin, opening the form if necessary
    	/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reason">Input:reason</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryTracksOutOfServiceBulletin(string bulletinSeed, string district, string milepost, string tracks, string reason, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Tracks Out Service";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (tracks != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Tracks.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Tracks.Element.SetAttributeValue("Text", tracks);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Tracks.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (reason != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Reason.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Reason.Element.SetAttributeValue("Text", reason);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Reason.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfService.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Tracks Out Of Service Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Tracks Out Of Service Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Auxiliary Tracks Out of Svc Exp Bulletin, opening the form if necessary
    	/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reason">Input:reason</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxiliaryTracksOutOfSvcExpBulletin(string bulletinSeed, string district, string milepost, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Auxiliary - Tracks Out Svc Exp";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (tracks != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Tracks.Element.SetAttributeValue("Text", tracks);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Tracks.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Account.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryTracksOutOfServiceExp.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Auxiliary Tracks Out Of Service Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Auxiliary Tracks Out Of Service Form at MP {"+milepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Bad Footing Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputBadFootingAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Bad Footing - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Bad Footing Area Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Bad Footing Area Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Bad Footing Point Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputBadFootingPointBulletin(string bulletinSeed, string district, string milepost, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Bad Footing - Point";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Tracks.TracksButton.PressKeys("{TAB}");
    		
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Account.PressKeys("{TAB}");
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.BadFootingPoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Bad Footing Point Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Bad Footing Point Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Cab Signal Failure Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputCabSignalFailureBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Cab Signal Failure";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Tracks.TracksButton.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CabSignalFailure.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Cab Signal Failure between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Cab Signal Failure between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Crossbucks Damaged or Missing Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:milepost1</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:expectedFeedback</param>
    	/// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm</param>
    	[UserCodeMethod]
    	public static void NS_InputCrossbucksDamagedOrMissingBulletin(string bulletinSeed, string district, string dotCrossingId, string effectiveTimeDifference, string reportedBy, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Crossbucks Damaged or Missing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Click();
    		
    		if (dotCrossingId != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", dotCrossingId);
				Bulletinsrepo.DOTCrossingIdName = dotCrossingId;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
    		}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Crossbucks Damaged Or Missing at Crossing Id {"+dotCrossingId+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Crossbucks Damaged Or Missing at Crossing Id {"+dotCrossingId+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Detour Order COT Territory Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="direction">Input:direction</param>
    	/// <param name="location1">Input:location1</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="location2">Input:location2</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="trackAuthorityMilepostDirection">Input:trackAuthorityMilepostDirection</param>
    	/// <param name="trackAuthorityMilepost">Input:trackAuthorityMilepost</param>
    	/// <param name="trainDispatcherMilepostDirection">Input:trainDispatcherMilepostDirection</param>
    	/// <param name="trainDispatcherMilepost">Input:trainDispatcherMilepost</param>
    	/// <param name="doNotExceedMph">Input:doNotExceedMph</param>
    	/// <param name="doNotExceedMphTrack">Input:doNotExceedMphTrack</param>
    	/// <param name="doNotExceedMphGangName">Input:doNotExceedMphGangName</param>
    	/// <param name="doNotExceedMphTrack2">Input:doNotExceedMphTrack2</param>
    	/// <param name="doNotExceedMphMilepost1">Input:doNotExceedMphMilepost1</param>
    	/// <param name="doNotExceedMphMilepost2">Input:doNotExceedMphMilepost2</param>
    	/// <param name="soundWhistleGangName">Input:soundWhistleGangName</param>
    	/// <param name="leadingEndTrack">Input:leadingEndTrack2</param>
    	/// <param name="leadingEndMilepost1">Input:leadingEndMilepost1</param>
    	/// <param name="leadingEndMilepost2">Input:leadingEndMilepost2</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:expectedFeedback</param>
    	/// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm</param>
    	[UserCodeMethod]
    	public static void NS_InputDetourOrderCOTTerritoryBulletin(string bulletinSeed, string district, string effectiveTimeDifference, string direction, string location1, string milepost1, string location2, string milepost2, string tracks, string trackAuthorityMilepostDirection, string trackAuthorityMilepost, string trainDispatcherMilepostDirection, string trainDispatcherMilepost, string doNotExceedMph, string doNotExceedMphTrack, string doNotExceedMphGangName, string doNotExceedMphTrack2, string doNotExceedMphMilepost1, string doNotExceedMphMilepost2, string soundWhistleGangName, string leadingEndTrack, string leadingEndMilepost1, string leadingEndMilepost2, string issuedBy, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Detour Order - COT Territory";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Effective.EffectiveDateAndTimeText.Click();
    		
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (direction != "")
			{
			    Bulletinsrepo.Direction = direction;
			    GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Direction.DirectionTextInfo,
			                                             Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Direction.DirectionList.DirectionListItemByDirectionInfo);
			    if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Direction.DirectionList.DirectionListItemByDirectionInfo.Exists(0))
			    {
			        Ranorex.Report.Error("Direction of {" + direction + "} does not exist in the direction list");
			    } else {
			        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Direction.DirectionList.DirectionListItemByDirectionInfo, 
			                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Direction.DirectionList.SelfInfo);
			    }
			}
			
			if (location1 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Location1.Element.SetAttributeValue("Text", location1);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Location1.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (location2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Location2.Element.SetAttributeValue("Text", location2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Location2.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2Text.PressKeys("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.Tracks.TracksButton.PressKeys("{TAB}");
			
			if (trackAuthorityMilepostDirection != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepostDirection.TrackAuthorityMilepostDirectionText.Click();
			    Bulletinsrepo.Direction = trackAuthorityMilepostDirection;
			    if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepostDirection.TrackAuthorityMilepostDirectionList.TrackAuthorityMilepostDirectionListItemByDirectionInfo.Exists(0))
			    {
			        Ranorex.Report.Error("Direction of {" + trackAuthorityMilepostDirection + "} does not exist in the direction list");
			    } else {
			        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepostDirection.TrackAuthorityMilepostDirectionList.TrackAuthorityMilepostDirectionListItemByDirectionInfo, 
			                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepostDirection.TrackAuthorityMilepostDirectionList.SelfInfo);
			    }
			}
			
			if (trackAuthorityMilepost != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepost.Element.SetAttributeValue("Text", trackAuthorityMilepost);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrackAuthorityMilepost.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (trainDispatcherMilepostDirection != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepostDirection.TrainDispatcherMilepostDirectionText.Click();
			    Bulletinsrepo.Direction = trainDispatcherMilepostDirection;
			    if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepostDirection.TrainDispatcherMilepostDirectionList.TrainDispatcherMilepostDirectionListItemByDirectionInfo.Exists(0))
			    {
			        Ranorex.Report.Error("Direction of {" + trainDispatcherMilepostDirection + "} does not exist in the direction list");
			    } else {
			        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepostDirection.TrainDispatcherMilepostDirectionList.TrainDispatcherMilepostDirectionListItemByDirectionInfo, 
			                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepostDirection.TrainDispatcherMilepostDirectionList.SelfInfo);
			    }
			}
			
			if (trainDispatcherMilepost != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepost.Element.SetAttributeValue("Text", trainDispatcherMilepost);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.TrainDispatcherMilepost.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMph != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPH.Element.SetAttributeValue("Text", doNotExceedMph);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPH.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMphTrack != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHTrack.Element.SetAttributeValue("Text", doNotExceedMphTrack);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHTrack.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMphGangName != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHGangName.Element.SetAttributeValue("Text", doNotExceedMphGangName);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHGangName.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMphTrack2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHTrack2.Element.SetAttributeValue("Text", doNotExceedMphTrack2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHTrack2.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMphMilepost1 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHMilepost1.Element.SetAttributeValue("Text", doNotExceedMphMilepost1);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHMilepost1.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (doNotExceedMphMilepost2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHMilepost2.Element.SetAttributeValue("Text", doNotExceedMphMilepost2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.DoNotExceedMPHMilepost2.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (soundWhistleGangName != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.SoundWhistleGangName.Element.SetAttributeValue("Text", soundWhistleGangName);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.SoundWhistleGangName.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (leadingEndTrack != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndTrack.Element.SetAttributeValue("Text", leadingEndTrack);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndTrack.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (leadingEndMilepost1 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndMilepost1.Element.SetAttributeValue("Text", leadingEndMilepost1);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndMilepost1.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (leadingEndMilepost2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndMilepost2.Element.SetAttributeValue("Text", leadingEndMilepost2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.LeadingEndMilepost2.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DetourOrderCOTTerritory.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Detour Order COT Territory between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, doNotExceedMph);
			
			Ranorex.Report.Info("TestStep", "Placed Detour Order COT Territory between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates a Device Out of Service Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="device">Input:device</param>
    	/// <param name="reason">Input:reason</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputDeviceOutOfServiceBulletin(string bulletinSeed, string district, string milepost, string tracks, string device, string reason, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Device Out of Service";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Tracks.TracksButton.PressKeys("{TAB}");
			
			if (device != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Device.Element.SetAttributeValue("Text", device);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Device.PressKeys("{TAB}");
			
			if (reason != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Reason.Element.SetAttributeValue("Text", reason);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Reason.PressKeys("{TAB}");
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.IssuedBy.PressKeys("{TAB}");
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.DeviceOutOfService.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Device Out Of Service Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Device Out Of Service Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates a Excessive Dimension Notice Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="heightFeet">Input:heightFeet</param>
    	/// <param name="heightInches">Input:heightInches</param>
    	/// <param name="widthFeet">Input:widthFeet</param>
    	/// <param name="widthInches">Input:widthInches</param>
    	/// <param name="weight">Input:weight</param>
    	/// <param name="tlcFileNumber">Input:tlcFileNumber</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputExcessiveDimensionNoticeBulletin(string bulletinSeed, string district, string trainSeed, string milepost1, string milepost2, string heightFeet, string heightInches, string widthFeet, string widthInches, string weight, string tlcFileNumber, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Excessive Dimension Notice";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Train.Click();
    		
    		if(trainSeed != "")
    		{
    			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    			if (trainId != null) {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Train.Element.SetAttributeValue("Text", trainId);
    			} else {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Train.Element.SetAttributeValue("Text", trainSeed);
    			}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Train.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			GeneralUtilities.CheckWaitState(15);
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			GeneralUtilities.CheckWaitState(15);
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (heightFeet != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.HeightFeet.Element.SetAttributeValue("Text", heightFeet);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.HeightFeet.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (heightInches != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.HeightInches.Element.SetAttributeValue("Text", heightInches);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.HeightInches.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (widthFeet != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.WidthFeet.Element.SetAttributeValue("Text", widthFeet);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.WidthFeet.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (widthInches != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.WidthInches.Element.SetAttributeValue("Text", widthInches);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.WidthInches.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (weight != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Weight.Element.SetAttributeValue("Text", weight);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Weight.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tlcFileNumber != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.TLCFileNumber.Element.SetAttributeValue("Text", tlcFileNumber);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.TLCFileNumber.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ExcessiveDimensionNotice.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Excessive Dimension Notice Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Excessive Dimension Notice Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Flash Flood Warning Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputFlashFloodWarningBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string issuedBy, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = true;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Flash Flood Warning";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FlashFloodWarning.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Flash Flood Warning between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Flash Flood Warning between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	/// <summary>
    	/// Creates a Form Y Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="direction1">Input:direction1</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="direction2">Input:direction2</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="person">Input:person</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="maxSpeed">Input:maxSpeed</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputFormYBulletin(string bulletinSeed, string district, string direction1, string milepost1, string direction2, string milepost2, string person, string effectiveTimeDifference, string untilTimeDifference, string maxSpeed, string expectedFeedback , bool closeForm, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Form Y";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionText.Click();
    		
    		if (direction1 != "")
    		{
    			Bulletinsrepo.DirectionName = direction1;
    			if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionList.DirectionListItemByNameInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Direction of {"+direction1+"} does not exist in the direction list");
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionText.Click();
    			} else {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionList.DirectionListItemByName.Click();
    			}
    		} else {
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionText.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction1.DirectionText.PressKeys("{TAB}");
			string milepost1AtLocation = "";
			string milepost2AtLocation = "";
			if(!String.IsNullOrEmpty(milepost1))
			{
				if(milepost1.Contains("|"))
				{
					milepost1AtLocation = milepost1.Split('|')[1];
				}
				
				milepost1 = milepost1.Split('|')[0];
			}
			if(!String.IsNullOrEmpty(milepost1AtLocation))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.FirstLocation.Click();
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.FirstLocation.Element.SetAttributeValue("Text", milepost1AtLocation);
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.FirstLocation.PressKeys("{TAB}");
			}
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionText.Click();
    		
    		if (direction2 != "")
    		{
    			Bulletinsrepo.DirectionName = direction2;
    			if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionList.DirectionListItemByNameInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Direction of {"+direction2+"} does not exist in the direction list");
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionText.Click();
    			} else {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionList.DirectionListItemByName.Click();
    			}
    		} else {
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionText.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Direction2.DirectionText.PressKeys("{TAB}");
			if(!String.IsNullOrEmpty(milepost2))
			{
				if(milepost2.Contains("|"))
				{
					milepost2AtLocation = milepost2.Split('|')[1];
				}
				
				milepost2 = milepost2.Split('|')[0];
			}
			if(!String.IsNullOrEmpty(milepost2AtLocation))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.SecondLocation.Click();
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.SecondLocation.Element.SetAttributeValue("Text", milepost2AtLocation);
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.SecondLocation.PressKeys("{TAB}");
			}
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			// Close view short tracks form if appears
			NS_Bulletin.NS_CloseViewShortTracksForm_BulletinInputRelayForm();
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
			if (person != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Person.Element.SetAttributeValue("Text", person);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Person.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
			if (maxSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.RestrictedSpeed.Element.SetAttributeValue("Text", maxSpeed);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FormY.RestrictedSpeed.PressKeys("{TAB}");
    		}
			
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}

			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 10) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Form Y Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", maxSpeed);
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.CancelButtonInfo, Bulletinsrepo.Bulletins_Input_Relay.SelfInfo);
			}
			Ranorex.Report.Info("TestStep", "Placed Form Y Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			return;
    	}
		
		/// <summary>
    	/// Creates an Grade Xing Act Failure Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="gradeXingActivationDevicesAt">Input:gradeXingActivationDevicesAt</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputGradeXingActFailureAreaBulletin(string bulletinSeed, string district, string gradeXingActivationDevicesAt, string milepost1, string milepost2, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Grade Xing Act Failure Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.GradeXingActivationDevicesAt.Click();
    		
    		if (gradeXingActivationDevicesAt != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.GradeXingActivationDevicesAt.Element.SetAttributeValue("Text", gradeXingActivationDevicesAt);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.GradeXingActivationDevicesAt.PressKeys("{TAB}");
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActFailureArea.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxiliaryBadFooting.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Grade Xing Act Failure Area between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Grade Xing Act Failure Area between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
		/// <summary>
    	/// Creates an Grade Xing Activation Failure Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:milepost1</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:expectedFeedback</param>
    	/// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm</param>
    	[UserCodeMethod]
    	public static void NS_InputGradeXingActivationFailureBulletin(string bulletinSeed, string district, string dotCrossingId, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Grade Xing Activation Failure";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdText.Click();
    		
    		if (dotCrossingId != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", dotCrossingId);
				Bulletinsrepo.DOTCrossingIdName = dotCrossingId;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.DOTCrossingId.DOTCrossingIdText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingActivationFailure.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			else{
				GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButtonInfo,Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButtonInfo);
			}
			if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Grade Xing Activation Failure at Crossing Id {"+dotCrossingId+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Grade Xing Activation Failure at Crossing Id {"+dotCrossingId+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	/// <summary>
    	/// Creates an Grade Xing False Activation Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:milepost1</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:expectedFeedback</param>
    	/// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm</param>
    	[UserCodeMethod]
    	public static void NS_InputGradeXingFalseActivationBulletin(string bulletinSeed, string district, string dotCrossingId, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Grade Xing False Activation";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdText.Click();
    		
    		if (dotCrossingId != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", dotCrossingId);
				Bulletinsrepo.DOTCrossingIdName = dotCrossingId;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.DOTCrossingId.DOTCrossingIdText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
				
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.GradeXingFalseActivation.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 10) {
				GeneralUtilities.CheckWaitState(10);
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Grade Xing False Activation at Crossing Id {"+dotCrossingId+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Grade Xing False Activation at Crossing Id {"+dotCrossingId+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Illinois Form A Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="subdivision">Input:subdivision</param>
    	/// <param name="currentAsOfTimeDifference">Input:currentAsOfTimeDifference</param>
    	/// <param name="dispatcherInitials">Input:dispatcherInitials</param>
    	/// <param name="formANumber">Input:formANumber</param>
    	/// <param name="numberOfItems">Input:numberOfItems</param>
    	/// <param name="exceptionText">Input:exceptionText</param>
    	/// <param name="subdivision2">Input:subdivision2</param>
    	/// <param name="restrictionText">Input:restrictionText</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputIllinoisFormABulletin(string bulletinSeed, string district, string subdivision, string currentAsOfTimeDifference, string dispatcherInitials, string formANumber, string numberOfItems, string exceptionText, string subdivision2, string restrictionText, string milepost1, string milepost2, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Illinois - Form  A";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Subdivision.Click();
    		
    		if (subdivision != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Subdivision.Element.SetAttributeValue("Text", subdivision);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Subdivision.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(currentAsOfTimeDifference != "")
    		{
    			int currentAsOfTimeDifferenceInt;
    			string currentAsOfTimeDifferenceFormatted;
    			if (int.TryParse(currentAsOfTimeDifference, out currentAsOfTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(currentAsOfTimeDifferenceInt);
        			currentAsOfTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    currentAsOfTimeDifferenceFormatted = currentAsOfTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.CurrentAsOf.CurrentAsOfDateAndTimeText.Element.SetAttributeValue("Text", currentAsOfTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.CurrentAsOf.CurrentAsOfDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (dispatcherInitials != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.DispatcherInitials.Element.SetAttributeValue("Text", dispatcherInitials);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.DispatcherInitials.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (formANumber != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.FormANumber.Element.SetAttributeValue("Text", formANumber);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.FormANumber.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (numberOfItems != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.NumberOfItems.Element.SetAttributeValue("Text", numberOfItems);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.NumberOfItems.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (exceptionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.ExceptionText.Element.SetAttributeValue("Text", exceptionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.ExceptionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (subdivision2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Subdivision2.Element.SetAttributeValue("Text", subdivision2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Subdivision2.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (restrictionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.RestrictionText.Element.SetAttributeValue("Text", restrictionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.RestrictionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormA.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Illinois Form A between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Illinois Form A between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Illinois Form B Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="subdivision">Input:subdivision</param>
    	/// <param name="currentAsOfTimeDifference">Input:currentAsOfTimeDifference</param>
    	/// <param name="dispatcherInitials">Input:dispatcherInitials</param>
    	/// <param name="formBNumber">Input:formANumber</param>
    	/// <param name="numberOfItems">Input:numberOfItems</param>
    	/// <param name="exceptionText">Input:exceptionText</param>
    	/// <param name="subdivision2">Input:subdivision2</param>
    	/// <param name="restrictionText">Input:restrictionText</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputIllinoisFormBBulletin(string bulletinSeed, string district, string subdivision, string currentAsOfTimeDifference, string dispatcherInitials, string formBNumber, string numberOfItems, string exceptionText, string subdivision2, string restrictionText, string milepost1, string milepost2, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Illinois - Form B";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Subdivision.Click();
    		
    		if (subdivision != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Subdivision.Element.SetAttributeValue("Text", subdivision);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Subdivision.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(currentAsOfTimeDifference != "")
    		{
    			int currentAsOfTimeDifferenceInt;
    			string currentAsOfTimeDifferenceFormatted;
    			if (int.TryParse(currentAsOfTimeDifference, out currentAsOfTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(currentAsOfTimeDifferenceInt);
        			currentAsOfTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    currentAsOfTimeDifferenceFormatted = currentAsOfTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.CurrentAsOf.CurrentAsOfDateAndTimeText.Element.SetAttributeValue("Text", currentAsOfTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.CurrentAsOf.CurrentAsOfDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (dispatcherInitials != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.DispatcherInitials.Element.SetAttributeValue("Text", dispatcherInitials);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.DispatcherInitials.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (formBNumber != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.FormBNumber.Element.SetAttributeValue("Text", formBNumber);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.FormBNumber.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (numberOfItems != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.NumberOfItems.Element.SetAttributeValue("Text", numberOfItems);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.NumberOfItems.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (exceptionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.ExceptionText.Element.SetAttributeValue("Text", exceptionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.ExceptionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (subdivision2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Subdivision2.Element.SetAttributeValue("Text", subdivision2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Subdivision2.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (restrictionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.RestrictionText.Element.SetAttributeValue("Text", restrictionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.RestrictionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormB.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Illinois Form B between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Illinois Form B between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Illinois Form C Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="subdivision">Input:subdivision</param>
    	/// <param name="currentAsOfTimeDifference">Input:currentAsOfTimeDifference</param>
    	/// <param name="dispatcherInitials">Input:dispatcherInitials</param>
    	/// <param name="formCNumber">Input:formANumber</param>
    	/// <param name="numberOfItems">Input:numberOfItems</param>
    	/// <param name="exceptionText">Input:exceptionText</param>
    	/// <param name="subdivision2">Input:subdivision2</param>
    	/// <param name="restrictionText">Input:restrictionText</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputIllinoisFormCBulletin(string bulletinSeed, string district, string subdivision, string currentAsOfTimeDifference, string dispatcherInitials, string formCNumber, string numberOfItems, string exceptionText, string subdivision2, string restrictionText, string milepost1, string milepost2, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Illinois - Form C";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Subdivision.Click();
    		
    		if (subdivision != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Subdivision.Element.SetAttributeValue("Text", subdivision);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Subdivision.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(currentAsOfTimeDifference != "")
    		{
    			int currentAsOfTimeDifferenceInt;
    			string currentAsOfTimeDifferenceFormatted;
    			if (int.TryParse(currentAsOfTimeDifference, out currentAsOfTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(currentAsOfTimeDifferenceInt);
        			currentAsOfTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    currentAsOfTimeDifferenceFormatted = currentAsOfTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.CurrentAsOf.CurrentAsOfDateAndTimeText.Element.SetAttributeValue("Text", currentAsOfTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.CurrentAsOf.CurrentAsOfDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (dispatcherInitials != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.DispatcherInitials.Element.SetAttributeValue("Text", dispatcherInitials);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.DispatcherInitials.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (formCNumber != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.FormCNumber.Element.SetAttributeValue("Text", formCNumber);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.FormCNumber.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (numberOfItems != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.NumberOfItems.Element.SetAttributeValue("Text", numberOfItems);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.NumberOfItems.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (exceptionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.ExceptionText.Element.SetAttributeValue("Text", exceptionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.ExceptionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (subdivision2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Subdivision2.Element.SetAttributeValue("Text", subdivision2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Subdivision2.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (restrictionText != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.RestrictionText.Element.SetAttributeValue("Text", restrictionText);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.RestrictionText.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisFormC.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Illinois Form B between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Illinois Form B between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Illinois SR Between WB CA Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="srLocation1">Input:srLocation1</param>
    	/// <param name="srLocation2">Input:srLocation2</param>
    	/// <param name="srTrack">Input:srTrack</param>
    	/// <param name="srSpeed">Input:srSpeed</param>
    	/// <param name="srAccount">Input:srAccount</param>
    	/// <param name="srAdditionComments">Input:srAdditionComments</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputIllinoisSRBetweenWBCABulletin(string bulletinSeed, string district, string srLocation1, string srLocation2, string srTrack, string srSpeed, string srAccount, string srAdditionComments, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string milepost1, string milepost2, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Illinois - SR between WB - CA";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRLocation1.Click();
    		
    		if (srLocation1 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRLocation1.Element.SetAttributeValue("Text", srLocation1);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRLocation1.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (srLocation2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRLocation2.Element.SetAttributeValue("Text", srLocation2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRLocation2.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (srTrack != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRTrack.Element.SetAttributeValue("Text", srTrack);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRTrack.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (srSpeed != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRSpeed.Element.SetAttributeValue("Text", srSpeed);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRSpeed.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (srAccount != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRAccount.Element.SetAttributeValue("Text", srAccount);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRAccount.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (srAdditionComments != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRAdditionalComments.Element.SetAttributeValue("Text", srAdditionComments);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.SRAdditionalComments.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.IssuedBy.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.IllinoisSRBetweenWBCA.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Illinois SR Between WB CA between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Illinois SR Between WB CA between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Key Train Job Briefing Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainId">Input:trainId</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="tonnage">Input:tonnage</param>
    	/// <param name="length">Input:length</param>
    	/// <param name="grade">Input:grade</param>
    	/// <param name="typeOfEquipment">Input:typeOfEquipment</param>
    	/// <param name="numberOfHandBrakes">Input:numberOfHandBrakes</param>
    	/// <param name="c102Performed">Input:c102Performed</param>
    	/// <param name="comments">Input:comments</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputKeyTrainJobBriefingBulletin(string bulletinSeed, string district, string trainId, string milepost, string tracks, string tonnage, string length, string grade, string typeOfEquipment, string numberOfHandBrakes, string c102Performed, string comments, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Key Train Job Briefing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.TrainID.Click();
    		
    		if (trainId != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.TrainID.Element.SetAttributeValue("Text", trainId);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.TrainID.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (tonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tonnage.Element.SetAttributeValue("Text", tonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Tonnage.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (length != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Length.Element.SetAttributeValue("Text", length);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Length.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (grade != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeText.Click();
			    Bulletinsrepo.GradeName = grade;
			    if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeList.GradeListItemByGradeNameInfo.Exists(0))
			    {
			        Ranorex.Report.Error("Grade of {" + grade + "} does not exist in the grade list");
			        Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeText.Click();
			    } else {
			        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeList.GradeListItemByGradeNameInfo, 
			                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeList.SelfInfo);
			    }
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Grade.GradeText.PressKeys("{TAB}");
			
			if (typeOfEquipment != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.TypeOfEquipment.Element.SetAttributeValue("Text", typeOfEquipment);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.TypeOfEquipment.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (numberOfHandBrakes != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Brakes.Element.SetAttributeValue("Text", numberOfHandBrakes);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Brakes.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (c102Performed != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedText.Click();
			    Bulletinsrepo.C102PerformedName = c102Performed;
			    if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedList.C102PerformedListItemByC102PerformedNameInfo.Exists(0))
			    {
			        Ranorex.Report.Error("Grade of {" + c102Performed + "} does not exist in the grade list");
			        Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedText.Click();
			    } else {
			        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedList.C102PerformedListItemByC102PerformedNameInfo, 
			                                                          Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedList.SelfInfo);
			    }
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.C102Performed.C102PerformedText.PressKeys("{TAB}");
			
			if (comments != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Comments.Element.SetAttributeValue("Text", comments);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Comments.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.KeyTrainJobBriefing.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Key Train Job Briefing at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Key Train Job Briefing at MP {"+milepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	/// <summary>
    	/// Creates a District Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="messageDistrict">Input:messageDistrict</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputDistrictMessageBulletin(string bulletinSeed, string district, string messageDistrict, string message, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Message - District";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.District.DistrictText.Click();
    		
    		if (messageDistrict != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.District.DistrictText.Element.SetAttributeValue("Text", messageDistrict);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.District.DistrictText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (message != "")
    		{
    			if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessageInfo.Exists(0))
    			{
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage.Element.SetAttributeValue("Text", message);
    			}
    			else if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage_NSInfo.Exists(0))
    			{
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage_NS.Element.SetAttributeValue("Text", message);
    			}
    			else
    			{
    				Ranorex.Report.Failure("Message field not found in working area");
    			}
    			
    		}
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessageInfo.Exists(0))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage.PressKeys("{TAB}");
    		}
    		else if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage_NSInfo.Exists(0))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.DistrictMessage_NS.PressKeys("{TAB}");
    		}
			
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDistrict.Until.UntilDateAndTimeText.PressKeys("{TAB}");
    		}
			
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete District Message Form at District {"+messageDistrict+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", messageDistrict, "", "");
			Ranorex.Report.Info("TestStep", "Placed District Message Form at District {"+messageDistrict+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	/// <summary>
    	/// Creates a Division Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="division">Input:division</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputDivisionMessageBulletin(string bulletinSeed, string district, string division, string message, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Message - Division";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Division.DivisionText.Click();
    		
    		if (division != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Division.DivisionText.Element.SetAttributeValue("Text", division);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Division.DivisionText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (message != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.DivisionMessage.Element.SetAttributeValue("Text", message);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.DivisionMessage.PressKeys("{TAB}");
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
//    		if(untilTimeDifference != "")
//    		{
//    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
//    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
//    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
//    			
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
//    		}
//			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageDivision.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Division Message Form at Division {"+division+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", district, "", "");
			Ranorex.Report.Info("TestStep", "Placed Division Message Form at Division {"+division+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates a Single Train Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainSeed">Input:trainSeed, if you don't want to use trainSeed, this will use the value if not a valid trainSeed</param>
    	/// <param name="departingFrom">Input:departingFrom</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputSingleTrainMessageBulletin(string bulletinSeed, string district, string trainSeed, string departingFrom, string message, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Message - Single Train";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Train.Click();
    		
    		if (trainSeed != "")
    		{
    			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    			if (trainId == null)
    			{
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Train.Element.SetAttributeValue("Text", trainSeed);
    			} else {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Train.Element.SetAttributeValue("Text", trainId);
    				trainSeed = trainId;
    			}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Train.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (departingFrom != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.DepartingFrom.Element.SetAttributeValue("Text", departingFrom);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.DepartingFrom.PressKeys("{TAB}");
    		
    		if (message != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.TrainMessage.Element.SetAttributeValue("Text", message);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.TrainMessage.PressKeys("{TAB}");
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageSingleTrain.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
			{
				GeneralUtilities.CheckWaitState(10);
				Ranorex.Delay.Seconds(1);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
				                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Single Train Message Form for train {"+trainSeed+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", district, "", "");
			Ranorex.Report.Info("TestStep", "Placed Single Train Message Form for train {"+trainSeed+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates a Train Repeating Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainSeed">Input:trainSeed, if you don't want to use trainSeed, this will use the value if not a valid trainSeed</param>
    	/// <param name="departingFrom">Input:departingFrom</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputTrainRepeatingMessageBulletin(string bulletinSeed, string district, string trainSeed, string departingFrom, string message, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Message - Train Repeating";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Train.Click();
    		
    		if (trainSeed != "")
    		{
    			string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
    			if (trainSymbol == null)
    			{
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Train.Element.SetAttributeValue("Text", trainSeed);
    			} else {
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Train.Element.SetAttributeValue("Text", trainSymbol);
    			}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Train.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (departingFrom != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.DepartingFrom.Element.SetAttributeValue("Text", departingFrom);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.DepartingFrom.PressKeys("{TAB}");
    		
    		if (message != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.TrainMessage.Element.SetAttributeValue("Text", message);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.TrainMessage.PressKeys("{TAB}");
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MessageTrainRepeating.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
			
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
			{
				GeneralUtilities.CheckWaitState(10);
				Ranorex.Delay.Seconds(1);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
				                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
			}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Train Repeating Message Form for train {"+trainSeed+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", district, "", "");
			Ranorex.Report.Info("TestStep", "Placed Train Repeating Message Form for train {"+trainSeed+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Instructions Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="miscInstructions">Input:miscInstructions</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputMiscInstructionsAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string miscInstructions, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Misc Instructions - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2Text.PressKeys("{TAB}");
			GeneralUtilities.CheckWaitState(1);
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (miscInstructions != "")
    		{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.MiscInstructions.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.MiscInstructions.Element.SetAttributeValue("Text", miscInstructions);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.MiscInstructions.PressKeys("{TAB}");
			
			if (issuedBy != "")
    		{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.IssuedBy.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Misc Instructions Area Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Misc Instructions Area Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Instructions Point Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="miscInstructions">Input:miscInstructions</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputMiscInstructionsPointBulletin(string bulletinSeed, string district, string milepost, string miscInstructions, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Misc Instructions - Point";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			
			if (miscInstructions != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.MiscInstructions.Element.SetAttributeValue("Text", miscInstructions);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.MiscInstructions.PressKeys("{TAB}");
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MiscInstructionsPoint.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Misc Instructions Point Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Misc Instructions Point Form at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an MofW Reservation Rest Speed Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="employee">Input:employee</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="zones">Input:zones</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="restrictedSpeed">Input:restrictedSpeed</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputMofWReservationRestSpeedBulletin(string bulletinSeed, string district, string employee, string milepost1, string milepost2, string tracks, string zones, string effectiveTimeDifference, string untilTimeDifference, string restrictedSpeed, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "MofW Reservation - Rest Speed";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Employee.Click();
    		
    		if (employee != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Employee.Element.SetAttributeValue("Text", employee);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Employee.PressKeys("{TAB}");
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (zones != "")
    		{
    			//Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Zones.ZonesButton.Click();
    			GeneralUtilities.ClickAndWaitForWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Zones.ZonesButtonInfo,
    			                                         Bulletinsrepo.Bulletins_Input_Relay.Input.Specify_Zones.SelfInfo);
    			string[] zoneLists = zones.Split('|');
    			if(zoneLists[0] != "")
    			{
    				string[] zoneList1 = zoneLists[0].Split('-');
    				foreach(string zone in zoneList1)
    				{
    					Bulletinsrepo.ZoneName = zone;
    					Bulletinsrepo.Bulletins_Input_Relay.Input.Specify_Zones.ZoneTable1.ZoneTableRowByZoneName.Click();
    				}
    			}
    			
    			if(zoneLists[1] != "")
    			{
    				string[] zoneList2 = zoneLists[0].Split('-');
    				foreach(string zone in zoneList2)
    				{
    					Bulletinsrepo.ZoneName = zone;
    					Bulletinsrepo.Bulletins_Input_Relay.Input.Specify_Zones.ZoneTable2.ZoneTableRowByZoneName.Click();
    				}
    			}
    			
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Specify_Zones.OkButtonInfo,
    			                                                  Bulletinsrepo.Bulletins_Input_Relay.Input.Specify_Zones.SelfInfo);
    		}
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Zones.ZonesButtonInfo.Exists(0))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Zones.ZonesButton.PressKeys("{TAB}");
    		}
			
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
				
			
			if (restrictedSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.RestrictedSpeed.Element.SetAttributeValue("Text", restrictedSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationRestSpeed.RestrictedSpeed.PressKeys("{TAB}");
			
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete MofW Reservation Rest Speed Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, restrictedSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed MofW Reservation Rest Speed Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an MofW Reservation Track Block Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="employeeName">Input:employeeName</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputMofWReservationTrackBlockBulletin(string bulletinSeed, string district, string employeeName, string milepost1, string milepost2, string tracks, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "MofW Reservation - Track Block";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.EmployeeName.Click();
    		
    		if (employeeName != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.EmployeeName.Element.SetAttributeValue("Text", employeeName);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.EmployeeName.PressKeys("{TAB}");
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost1.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost2.MilepostText.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost2.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost2.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost2.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Milepost2.MilepostText.GetAttributeValue<string>("Text");
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.MofWReservationTrackBlock.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete MofW Reservation Track Block between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete MofW Reservation Track Block between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Rusty Rail Conditions Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputRustyRailConditionsAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string account, string effectiveTimeDifference, string untilTimeDifference, string issuedBy, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = @"Rusty Rail Conditions \(Area\)";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Account.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsArea.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Rusty Rail Conditions (Area) between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Complete Rusty Rail Conditions (Area) between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Rusty Rail Conditions Point Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost">Input:milepost1</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputRustyRailConditionsPointBulletin(string bulletinSeed, string district, string milepost, string tracks, string account, string effectiveTimeDifference, string untilTimeDifference, string issuedBy, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = @"Rusty Rail Conditions \(Point\)";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1Text.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1Text.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Milepost.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}

			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Account.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.IssuedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Rusty Rail Conditions Point at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
    			{
    				NS_Bulletin.CloseBulletinItemsForm_NS();
    			}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Rusty Rail Conditions Point at MP {"+milepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Shop Car SO Line Of Road Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainNumber">Input:trainNumber</param>
    	/// <param name="setOutShopCar">Input:setOutShopCar</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="contents">Input:contents</param>
    	/// <param name="natureOfDefect">Input:natureOfDefect</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputShopCarSOLineOfRoadBulletin(string bulletinSeed, string district, string trainNumber, string setOutShopCar, string milepost, string effectiveTimeDifference, string contents, string natureOfDefect, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Shop Car SO Line of Road";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.TrainNumber.Click();
    		
    		if (trainNumber != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.TrainNumber.Element.SetAttributeValue("Text", trainNumber);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.TrainNumber.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (setOutShopCar != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.ShopCar.Element.SetAttributeValue("Text", setOutShopCar);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.ShopCar.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1Text.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Milepost.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RustyRailConditionsPoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (contents != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Contents.Element.SetAttributeValue("Text", contents);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.Contents.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (natureOfDefect != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.NatureOfDefect.Element.SetAttributeValue("Text", natureOfDefect);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ShopCarSOLineOfRoad.NatureOfDefect.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Shop Car SO Line of Road at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
    			{
    				NS_Bulletin.CloseBulletinItemsForm_NS();
    			}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Shop Car SO Line of Road at MP {"+milepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Signal System Suspended Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="authorizedSpeed">Input:authorizedSpeed</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputSignalSystemSuspendedBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string authorizedSpeed, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Signal System Suspended";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			if (authorizedSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.AuthorizedSpeed.Element.SetAttributeValue("Text", authorizedSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.AuthorizedSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SignalSystemSuspended.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Signal System Suspended between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Complete Signal System Suspended between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Speed Area Restriction Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputSpeedAreaRestrictionBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference,string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Speed - Area Restriction";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
    			//If the milepost doesn't contain an empty space, then it doesn't have the full milepost name so we need to get it from the displayed list
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.IssuedBy.PressKeys("{TAB}");
			
    		string effectiveTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, "E", effectiveTimeDifference);
			if (effectiveTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		string untilTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, "E", untilTimeDifference);
			if (untilTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedAreaRestriction.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
			int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
			{
				GeneralUtilities.CheckWaitState(10);
				Ranorex.Delay.Seconds(1);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
				                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
			}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Speed Area Restriction Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed Speed Area Restriction Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Speed Point Restriction Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputSpeedPointRestrictionBulletin(string bulletinSeed, string district, string milepost, string tracks, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Speed - Point Restriction";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			string additionalComments = null;
			if(account.Contains("|"))
			{
				additionalComments = account.Split('|')[1];
			}
			account = account.Split('|')[0];
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Account.PressKeys("{TAB}");
			if(!String.IsNullOrEmpty(additionalComments))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.AdditionalComments.Click();
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.AdditionalComments.Element.SetAttributeValue("Text", additionalComments);
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.AdditionalComments.PressKeys("{TAB}");
			}
			
			
			
			if (issuedBy != "")
    		{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.IssuedBy.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.SpeedPointRestriction.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Speed Point Restriction Form between MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed Speed Point Restriction Form between MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Tracks Out Of Service Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputTracksOutOfServiceAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Tracks Out of Service - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServiceArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Tracks Out Of Service Area Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Tracks Out Of Service Area Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Tracks Out Of Service Point Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputTracksOutOfServicePointBulletin(string bulletinSeed, string district, string milepost, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Tracks Out of Service - Point";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = "";
			postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Tracks.TracksButton.PressKeys("{TAB}");
			
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.TracksOutOfServicePoint.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Tracks Out Of Service Point Form between MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Tracks Out Of Service Point Form between MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an XMER Area Speed Rest Exp Pur Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="track">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputXMERAreaSpeedRestExpPurBulletin(string bulletinSeed, string district, string between, string and, string track, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "XMER - Area Speed Rest Exp Pur";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Between.Click();
    		
    		if (between != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Between.Element.SetAttributeValue("Text", between);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Between.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (and != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.And.Element.SetAttributeValue("Text", and);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.And.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (track != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Track.Element.SetAttributeValue("Text", track);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Track.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestExpPur.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete XMER Area Speed Rest Exp Pur at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, track, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed XMER Area Speed Rest Exp Pur at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an XMER Area Speed Restriction Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="track">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputXMERAreaSpeedRestrictionBulletin(string bulletinSeed, string district, string between, string and, string track, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "XMER - Area Speed Restriction";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Between.Click();
    		
    		if (between != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Between.Element.SetAttributeValue("Text", between);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Between.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (and != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.And.Element.SetAttributeValue("Text", and);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.And.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (track != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Track.Element.SetAttributeValue("Text", track);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Track.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete XMER Area Speed Restriction at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, track, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed XMER Area Speed Restriction at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an XMER Area Speed Restriction 2 Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="between">Input:between</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="maximumSpeed">Input:maximumSpeed</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputXMERAreaSpeedRestriction2Bulletin(string bulletinSeed, string district, string between, string and, string tracks, string maximumSpeed, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "XMER - Area Speed Restriction2";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Between.Click();
    		
    		if (between != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Between.Element.SetAttributeValue("Text", between);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Between.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (and != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.And.Element.SetAttributeValue("Text", and);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.And.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostText.Element.SetAttributeValue("Text", nearMilepost);
				Bulletinsrepo.MilepostName = nearMilepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.NearMilepost.MilepostText.GetAttributeValue<string>("Text");
			
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Tracks.TracksButton.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (maximumSpeed != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.MaximumSpeed.Element.SetAttributeValue("Text", maximumSpeed);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.MaximumSpeed.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMERAreaSpeedRestriction2.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete XMER Area Speed Restriction 2 at MP {"+nearMilepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, maximumSpeed);
			
			Ranorex.Report.Info("TestStep", "Placed XMER Area Speed Restriction 2 at MP {"+nearMilepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Fuel Conservation Directive Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainId">Input:trainId</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="tonnage">Input:tonnage</param>
    	/// <param name="length">Input:length</param>
    	/// <param name="grade">Input:grade</param>
    	/// <param name="typeOfEquipment">Input:typeOfEquipment</param>
    	/// <param name="numberOfHandBrakes">Input:numberOfHandBrakes</param>
    	/// <param name="c102Performed">Input:c102Performed</param>
    	/// <param name="comments">Input:comments</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputFuelConservationDirectiveBulletin(string bulletinSeed, string district, string districtInput, string milepost1, string milepost2, string maxTonnage, string EW, string H5, string coalGrain, string freight, string imml, string ip, string maximumPoweredAxles, string eachDirection, string trailingTonnage, string currentMaximumPower, string r4, string r5, string ip1, string ip2, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Fuel Conservation Directive";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.District.Click();
    		
    		if (districtInput != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.District.Element.SetAttributeValue("Text", districtInput);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.District.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maxTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.MaxTonnage.Element.SetAttributeValue("Text", maxTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.MaxTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (EW != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.EW.Element.SetAttributeValue("Text", EW);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.EW.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (H5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.H5.Element.SetAttributeValue("Text", H5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.H5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
    		
			if (coalGrain != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.CoalGrain.Element.SetAttributeValue("Text", coalGrain);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.CoalGrain.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (freight != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Freight.Element.SetAttributeValue("Text", freight);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Freight.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (imml != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IMML.Element.SetAttributeValue("Text", imml);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IMML.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ip != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IP.Element.SetAttributeValue("Text", ip);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IP.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maximumPoweredAxles != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.MaximumPoweredAxles.Element.SetAttributeValue("Text", maximumPoweredAxles);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.MaximumPoweredAxles.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (eachDirection != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.EachDirection.Element.SetAttributeValue("Text", eachDirection);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.EachDirection.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (trailingTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.TrailingTonnage.Element.SetAttributeValue("Text", trailingTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.TrailingTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (currentMaximumPower != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.CurrentMaximumPower.Element.SetAttributeValue("Text", currentMaximumPower);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.CurrentMaximumPower.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (r4 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.R4.Element.SetAttributeValue("Text", r4);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.R4.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (r5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.R5.Element.SetAttributeValue("Text", r5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.R5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ip1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IP1.Element.SetAttributeValue("Text", ip1);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.IP1.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Location1.Element.SetAttributeValue("Text", milepost1);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Location1.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Location2.Element.SetAttributeValue("Text", milepost2);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Location2.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Fuel Conservation Directive between MP {"+milepost1+"} and {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, milepost1, milepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Fuel Conservation Directive between MP {"+milepost1+"} and {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Fuel Conservation Directive EW Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainId">Input:trainId</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="tonnage">Input:tonnage</param>
    	/// <param name="length">Input:length</param>
    	/// <param name="grade">Input:grade</param>
    	/// <param name="typeOfEquipment">Input:typeOfEquipment</param>
    	/// <param name="numberOfHandBrakes">Input:numberOfHandBrakes</param>
    	/// <param name="c102Performed">Input:c102Performed</param>
    	/// <param name="comments">Input:comments</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputFuelConservationDirectiveEWBulletin(string bulletinSeed, string district, string districtInput, string milepost1, string milepost2, string maxTonnage, string EW, string H5, string coalGrain, string freight, string imml, string ip, string maximumPoweredAxles, string eachDirection, string trailingTonnage, string currentMaximumPower, string r5, string accurateLoco, string ipTrains, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Fuel Conservation Directive_EW";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.District.Click();
    		
    		if (districtInput != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.District.Element.SetAttributeValue("Text", districtInput);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.District.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maxTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.MaxTonnage.Element.SetAttributeValue("Text", maxTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.MaxTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (EW != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.EW.Element.SetAttributeValue("Text", EW);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.EW.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (H5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.H5.Element.SetAttributeValue("Text", H5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.H5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
    		
			if (coalGrain != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.CoalGrain.Element.SetAttributeValue("Text", coalGrain);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.CoalGrain.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (freight != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Freight.Element.SetAttributeValue("Text", freight);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Freight.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (imml != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IMML.Element.SetAttributeValue("Text", imml);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IMML.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ip != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IP.Element.SetAttributeValue("Text", ip);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IP.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maximumPoweredAxles != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.MaximumPoweredAxles.Element.SetAttributeValue("Text", maximumPoweredAxles);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.MaximumPoweredAxles.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (eachDirection != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.EachDirection.Element.SetAttributeValue("Text", eachDirection);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.EachDirection.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (trailingTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.TrailingTonnage.Element.SetAttributeValue("Text", trailingTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.TrailingTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (currentMaximumPower != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.CurrentMaximumPower.Element.SetAttributeValue("Text", currentMaximumPower);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.CurrentMaximumPower.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (r5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.R5.Element.SetAttributeValue("Text", r5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.R5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (accurateLoco != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.AccurateLoco.Element.SetAttributeValue("Text", accurateLoco);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.AccurateLoco.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ipTrains != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IPTrains.Element.SetAttributeValue("Text", ipTrains);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.IPTrains.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Location1.Element.SetAttributeValue("Text", milepost1);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Location1.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Location2.Element.SetAttributeValue("Text", milepost2);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Location2.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_EW.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Fuel Conservation Directive EW between MP {"+milepost1+"} and {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, milepost1, milepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Fuel Conservation Directive EW between MP {"+milepost1+"} and {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Fuel Conservation Directive NS Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="trainId">Input:trainId</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="tonnage">Input:tonnage</param>
    	/// <param name="length">Input:length</param>
    	/// <param name="grade">Input:grade</param>
    	/// <param name="typeOfEquipment">Input:typeOfEquipment</param>
    	/// <param name="numberOfHandBrakes">Input:numberOfHandBrakes</param>
    	/// <param name="c102Performed">Input:c102Performed</param>
    	/// <param name="comments">Input:comments</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputFuelConservationDirectiveNSBulletin(string bulletinSeed, string district, string districtInput, string milepost1, string milepost2, string maxTonnage, string NS, string H5, string coalGrain, string freight, string imml, string ip, string maximumPoweredAxles, string eachDirection, string trailingTonnage, string currentMaximumPower, string r5, string accurateLoco, string ipTrains, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Fuel Conservation Directive_NS";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective.District.Click();
    		
    		if (districtInput != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.District.Element.SetAttributeValue("Text", districtInput);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.District.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maxTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.MaxTonnage.Element.SetAttributeValue("Text", maxTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.MaxTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (NS != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.NS.Element.SetAttributeValue("Text", NS);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.NS.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (H5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.H5.Element.SetAttributeValue("Text", H5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.H5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
    		
			if (coalGrain != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.CoalGrain.Element.SetAttributeValue("Text", coalGrain);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.CoalGrain.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (freight != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Freight.Element.SetAttributeValue("Text", freight);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Freight.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (imml != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IMML.Element.SetAttributeValue("Text", imml);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IMML.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ip != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IP.Element.SetAttributeValue("Text", ip);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IP.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (maximumPoweredAxles != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.MaximumPoweredAxles.Element.SetAttributeValue("Text", maximumPoweredAxles);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.MaximumPoweredAxles.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (eachDirection != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.EachDirection.Element.SetAttributeValue("Text", eachDirection);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.EachDirection.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (trailingTonnage != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.TrailingTonnage.Element.SetAttributeValue("Text", trailingTonnage);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.TrailingTonnage.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (currentMaximumPower != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.CurrentMaximumPower.Element.SetAttributeValue("Text", currentMaximumPower);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.CurrentMaximumPower.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (r5 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.R5.Element.SetAttributeValue("Text", r5);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.R5.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (accurateLoco != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.AccurateLoco.Element.SetAttributeValue("Text", accurateLoco);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.AccurateLoco.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (ipTrains != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IPTrains.Element.SetAttributeValue("Text", ipTrains);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.IPTrains.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Location1.Element.SetAttributeValue("Text", milepost1);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Location1.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Location2.Element.SetAttributeValue("Text", milepost2);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Location2.PressKeys("{TAB}");
    		
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.FuelConservationDirective_NS.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Fuel Conservation Directive NS between MP {"+milepost1+"} and {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, milepost1, milepost2, district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed Fuel Conservation Directive NS between MP {"+milepost1+"} and {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Crossbucks Damaged or Missing Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:milepost1</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:expectedFeedback</param>
    	/// <param name="closeBulletinRelayForm">Input:closeBulletinRelayForm</param>
    	[UserCodeMethod]
    	public static void NS_InputZZXbucksDamagedOrMissingBulletin(string bulletinSeed, string district, string dotCrossingId, string dotCrossingName, string milePost, string effectiveTimeDifference, string reportedBy, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "ZZ X-bucks Damaged or Missing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Click();
    		
    		if (dotCrossingId != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", dotCrossingId);
				Bulletinsrepo.DOTCrossingIdName = dotCrossingId;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdList.DOTCrossingIdListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingId.DOTCrossingIdText.GetAttributeValue<string>("Text");
			
			if (dotCrossingName != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingName.Element.SetAttributeValue("Text", dotCrossingName);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.DOTCrossingName.PressKeys("{TAB}");
			
			if (milePost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.Milepost.MilepostText.Element.SetAttributeValue("Text", milePost);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.Milepost.MilepostText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.Click();
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.CrossbucksDamagedOrMissing.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
    		}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZXbucksDamagedOrMissing.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete ZZ Crossbucks Damaged Or Missing at Crossing Id {"+dotCrossingId+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, "", "");
			
			Ranorex.Report.Info("TestStep", "Placed ZZ Crossbucks Damaged Or Missing at Crossing Id {"+dotCrossingId+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Aux Grade Xing Activat Failure, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:dotCrossingId</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputAuxGradeXingActFailAreaBulletin(string bulletinSeed, string district, string dotCrossingId, string at, string milepost1, string milepost2, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Aux Grade Xing Act Fail Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.DOTCrossingId.Click();
    		
    		if (dotCrossingId != "")
    		{
    		    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
    		}
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.DOTCrossingId.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (at != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.At.Element.SetAttributeValue("Text", at);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.At.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost1 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (milepost2 != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Milepost2.Milepost2Text.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.AuxGradeXingActFailArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Aux Grade Xing Activat Failure at MP {"+at+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, milepost1, milepost2, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Aux Grade Xing Activat Failure at MP {"+at+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Aux Grade Xing False Activat, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:dotCrossingId</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputPowerOffConditionGradeXingBulletin(string bulletinSeed, string district, string dotCrossingId, string foulingGradeCrossing, string milepost, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Power Off Condition Grade Xing";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.DOTCrossingId.Click();
    		
    		if (dotCrossingId != "")
    		{
    		    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
    		}
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.DOTCrossingId.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (foulingGradeCrossing != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.FoulingGradeCrossing.Element.SetAttributeValue("Text", foulingGradeCrossing);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.FoulingGradeCrossing.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PowerOffConditionGradeXing.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Power Off Condition Grade Xing Bulletin at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete Power Off Condition Grade Xing Bulletin at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Right of Way Cond - Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputRightOfWayCondAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Right of Way Cond. - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondArea.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Right of Way Cond - Area Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Right of Way Cond - Area Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
    	/// Creates an Right of Way Cond - Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputRightOfWayCondPointBulletin(string bulletinSeed, string district, string milepost, string tracks, string account, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "Right of Way Cond. - Point";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostText.Click();
    		
    		if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Tracks.TracksButton.PressKeys("{TAB}");
    		
			
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.RightOfWayCondPoint.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Right of Way Cond - Point Form at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Right of Way Cond - Point Form at MP {"+milepost+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	
    	/// <summary>
    	/// Creates an Bad Footing Area Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="milepost1">Input:milepost1</param>
    	/// <param name="milepost2">Input:milepost2</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="account">Input:account</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputXMFBadFootingAreaBulletin(string bulletinSeed, string district, string milepost1, string milepost2, string tracks, string account, string issuedBy, string effectiveTimeDifference, string nearMilepost, string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "XMF - Bad Footing - Area";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1Text.Click();
    		
    		if (milepost1 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1Text.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost1.Milepost1Text.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (milepost2 != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", milepost2);
				Bulletinsrepo.MilepostName = milepost2;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost2.Milepost2List.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost2.Milepost2List.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost2.Milepost2Text.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Keyboard.Press("{TAB}");
			string postValidationMilepost2 = "";
			postValidationMilepost2 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Milepost2.Milepost2Text.GetAttributeValue<string>("Text");
			
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
    		if (tracks != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Tracks.Element.SetAttributeValue("Text", tracks);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Tracks.PressKeys("{TAB}");
    		
			
    		if (account != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Account.Element.SetAttributeValue("Text", account);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Account.PressKeys("{TAB}");
			
			
			if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.IssuedBy.PressKeys("{TAB}");
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			if (nearMilepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Near.Element.SetAttributeValue("Text", nearMilepost);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.XMFBadFootingArea.Near.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete Bad Footing Area Form between MP {"+milepost1+"} and MP {"+milepost2+"}, Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, postValidationMilepost2, district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Bad Footing Area Form between MP {"+milepost1+"} and MP {"+milepost2+"} District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
    	}
    	
    	/// <summary>
		/// Creates ZZGrade Xing Act Failure Bulletin, opening the form if necessary
		/// </summary>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="district">Input:district</param>
		/// <param name="milepost1">Input:milepost1</param>
		/// <param name="dotCrossingId">Input:dotCrossingId</param>
		/// <param name="tracks">Input:tracks</param>
		/// <param name="warningDeviceLocation">Input:DeviceLocation</param>
		/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
		/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
		/// <param name="expectedFeedback">Input:expectedFeedback</param>
		[UserCodeMethod]
		public static void NS_InputZZGradeXingFalseActivationBulletin(string bulletinSeed, string district, string dotCrossingId, string warningDeviceLocation, string milepost1, string trackName, string reportedBy,  string effectiveTimeDifference, string untilTimeDifference,string expectedFeedback, bool pressComplete = true, bool closeBulletinRelayForm = true)
		{
			Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
			NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
			
			Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
			
			string type = "ZZGrade Xing False Activation";
			InputBulletinHeader(district, type);
			
			if(dotCrossingId !="")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.DOTCrossingId.PressKeys("{TAB}");
			
			if(warningDeviceLocation !="")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.At.Click();
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.At.Element.SetAttributeValue("Text", warningDeviceLocation);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.At.PressKeys("{TAB}");
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostText.Click();
			
			if (milepost1 != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost1);
				Bulletinsrepo.MilepostName = milepost1;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost1 = "";
			postValidationMilepost1 = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			//If View Short Tracks Form appears select Show All Tracks
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.SelfInfo.Exists(0))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.View_Short_Tracks_Form.ShowAllTracksButton.Click();
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (trackName != "")
			{
				string [] trackList = trackName.Split('|');
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Tracks.TracksButton.Click();
				foreach (string track in trackList) {
					Bulletinsrepo.TracksName = track;
					if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
					{
						Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Tracks.TracksMenu.TracksMenuitemByName.Click();
					}
				}
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Tracks.TracksButton.Click();
			}
			
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			if(reportedBy !="")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.ReportedBy.PressKeys("{TAB}");
			
			
			string effectiveTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, "E", effectiveTimeDifference);
			Report.Info(string.Format("Effective time: '{0}'", effectiveTime));
			if (effectiveTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			string untilTime = NS_Bulletin.NS_FormatDateTime_Bulletin(System.DateTime.Now, "E", untilTimeDifference);
			if (untilTime != "")
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTime);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingFalseActivation.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			if(expectedFeedback != "") 
			{
				Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			
			int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
    		}
			
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) 
			{
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete ZZGrade Xing Act Failure at MP {"+milepost1+"} Refreshing did not produce the bulletin.");
				if (closeBulletinRelayForm)
				{
					NS_Bulletin.CloseBulletinItemsForm_NS();
				}
				return;
			}
			Delay.Milliseconds(500);
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the bulletin object list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost1, "", district, trackName, "");
			
			Ranorex.Report.Info("Placed ZZGrade Xing Act Failure Buletin at MP {"+milepost1+"}  District {"+district+"}.");
			if (closeBulletinRelayForm)
			{
				NS_Bulletin.CloseBulletinItemsForm_NS();
			}
			return;
		}
		
    	/// <summary>
    	/// Creates an ZZ Grade Xing False Activation, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="dotCrossingId">Input:dotCrossingId</param>
    	/// <param name="at">Input:at</param>
    	/// <param name="milepost">Input:milepost</param>
    	/// <param name="tracks">Input:tracks</param>
    	/// <param name="reportedBy">Input:reportedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="nearMilepost">Input:nearMilepost</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="pressComplete">Input:pressComplete</param>
    	[UserCodeMethod]
    	public static void NS_InputZZGradeXingActFailureBulletin(string bulletinSeed, string district, string dotCrossingId, string at, string milepost, string tracks, string reportedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    	    NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "ZZGrade Xing Act Failure";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.DOTCrossingId.Click();
    		
    		if (dotCrossingId != "")
    		{
    		    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.DOTCrossingId.Element.SetAttributeValue("Text", dotCrossingId);
    		}
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.DOTCrossingId.PressKeys("{TAB}");
    		
    		//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (at != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.WarningDevicesAt.Element.SetAttributeValue("Text", at);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.WarningDevicesAt.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (milepost != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostText.Element.SetAttributeValue("Text", milepost);
				Bulletinsrepo.MilepostName = milepost;
				if (Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostList.MilepostListItemByNameInfo.Exists(0))
				{
					string wholeMilepostName = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostList.MilepostListItemByName.GetAttributeValue<string>("Text");
					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostText.Element.SetAttributeValue("Text", wholeMilepostName);
				}
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostText.PressKeys("{TAB}");
			string postValidationMilepost = Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Milepost.MilepostText.GetAttributeValue<string>("Text");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (tracks != "")
    		{
    			string [] trackList = tracks.Split('|');
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Tracks.TracksButton.Click();
    			foreach (string track in trackList) {
    				Bulletinsrepo.TracksName = track;
    				if (!Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Tracks.TracksMenu.TracksMenuitemByName.GetAttributeValue<bool>("Checked"))
    				{
    					Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Tracks.TracksMenu.TracksMenuitemByName.Click();
    				}
    			}
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Tracks.TracksButton.Click();
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Tracks.TracksButton.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (reportedBy != "")
			{
			    Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.ReportedBy.Element.SetAttributeValue("Text", reportedBy);
			}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.ReportedBy.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt;
    			string effectiveTimeDifferenceFormatted;
    			if (int.TryParse(effectiveTimeDifference, out effectiveTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
        			effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    effectiveTimeDifferenceFormatted = effectiveTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		
    		if(untilTimeDifference != "")
    		{
    			int untilTimeDifferenceInt;
    			string untilTimeDifferenceFormatted;
    			if (int.TryParse(untilTimeDifference, out untilTimeDifferenceInt))
    			{
        			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
        			untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			} else {
    			    untilTimeDifferenceFormatted = untilTimeDifference;
    			}
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.ZZGradeXingActFailure.Until.UntilDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
			else
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
			}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
    		
    		int retries = 0;
    		while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
    		{
    			GeneralUtilities.CheckWaitState(10);
    			Ranorex.Delay.Seconds(1);
    			retries++;
    		}
    		
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
    			                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
    		}
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			NS_Bulletin.CloseBulletinItemsForm_NS();
				return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete ZZ Grade Xing False Activation at MP {"+milepost+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, postValidationMilepost, "", district, tracks, "");
			
			Ranorex.Report.Info("TestStep", "Placed Complete ZZ Grade Xing False Activation at MP {"+milepost+"} District {"+district+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates a District Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="messageDistrict">Input:messageDistrict</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputPTCDistrictMessageBulletin(string bulletinSeed, string district, string messageDistrict, string message, string issuedBy, string effectiveTimeDifference, string untilTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "PTC-District-Message";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.District.DistrictText.Click();
    		
    		if (messageDistrict != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.District.DistrictText.Element.SetAttributeValue("Text", messageDistrict);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.District.DistrictText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (message != "")
    		{
    			if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessageInfo.Exists(0))
    			{
    				Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessage.Element.SetAttributeValue("Text", message);
    			}
    			else
    			{
    				Ranorex.Report.Failure("Message field not found in working area");
    			}
    			
    		}
    		if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessageInfo.Exists(0))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessage.PressKeys("{TAB}");
    		}
    		else if(Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessageInfo.Exists(0))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.DistrictMessage.PressKeys("{TAB}");
    		}
			
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
//    		
//    		if(untilTimeDifference != "")
//    		{
//    			int untilTimeDifferenceInt = Convert.ToInt32(untilTimeDifference);
//    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(untilTimeDifferenceInt);
//    			string untilTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
//    			
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.Until.UntilDateAndTimeText.Element.SetAttributeValue("Text", untilTimeDifferenceFormatted);
//    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDistrict.Until.UntilDateAndTimeText.PressKeys("{TAB}");
//    		}
			
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
			if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
			{
				GeneralUtilities.CheckWaitState(10);
				Ranorex.Delay.Seconds(1);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
				                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
			}
    		
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete PTC District Message Form at District {"+messageDistrict+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", messageDistrict, "", "");
			Ranorex.Report.Info("TestStep", "Placed PTC District Message Form at District {"+messageDistrict+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    	/// <summary>
    	/// Creates a Division Message Bulletin, opening the form if necessary
    	/// </summary>
    	/// <param name="bulletinSeed">Input:bulletinSeed</param>
    	/// <param name="district">Input:district</param>
    	/// <param name="division">Input:division</param>
    	/// <param name="message">Input:message</param>
    	/// <param name="issuedBy">Input:issuedBy</param>
    	/// <param name="effectiveTimeDifference">Input:effectiveTimeDifference</param>
    	/// <param name="untilTimeDifference">Input:untilTimeDifference</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_InputPTCDivisionMessageBulletin(string bulletinSeed, string district, string division, string message, string issuedBy, string effectiveTimeDifference, string expectedFeedback, bool pressComplete = true)
    	{
    		Configuration.Current.Adapter.DefaultUseEnsureVisible = false;
    		NS_Bulletin.NS_OpenBulletinInputForm_MainMenu();
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Self.Activate();
    		
    		string type = "PTC-Division-Message";
    		InputBulletinHeader(district, type);
    		
    		Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.Division.DivisionText.Click();
    		
    		if (division != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.Division.DivisionText.Element.SetAttributeValue("Text", division);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.Division.DivisionText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
    		
    		if (message != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.DivisionMessage.Element.SetAttributeValue("Text", message);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.DivisionMessage.PressKeys("{TAB}");
    		
			
    		if (issuedBy != "")
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.IssuedBy.Element.SetAttributeValue("Text", issuedBy);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.IssuedBy.PressKeys("{TAB}");
    		
			
    		if(effectiveTimeDifference != "")
    		{
    			int effectiveTimeDifferenceInt = Convert.ToInt32(effectiveTimeDifference);
    			System.DateTime newTimeFromNow = System.DateTime.Now.AddMinutes(effectiveTimeDifferenceInt);
    			string effectiveTimeDifferenceFormatted = newTimeFromNow.ToString("MM-dd-yyyy hh:mm t 'E'");
    			
    			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.Effective.EffectiveDateAndTimeText.Element.SetAttributeValue("Text", effectiveTimeDifferenceFormatted);
    		}
			Bulletinsrepo.Bulletins_Input_Relay.Input.BulletinWorkingAreas.PTCMessageDivision.Effective.EffectiveDateAndTimeText.PressKeys("{TAB}");
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
			//Check if this kicked up some FeedBack
			if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
			{
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				return;
			}
			
    		if (!pressComplete)
			{
				Ranorex.Report.Info("PressComplete set to false so ending here.");
				return;
			}
    		else
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.CompleteButton.Click();
				GeneralUtilities.CheckWaitState(10);
    		}
    		
    		//Check if this kicked up some FeedBack
    		if (!NS_Bulletin.CheckFeedback(Bulletinsrepo.Bulletins_Input_Relay.Feedback, expectedFeedback))
    		{
    			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
    			return;
    		}
    		
    		int retries = 0;
			while(!Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0) && retries < 5)
			{
				GeneralUtilities.CheckWaitState(10);
				Ranorex.Delay.Seconds(1);
				retries++;
			}
			
			if(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.OkButtonInfo,
				                                                 Bulletinsrepo.Bulletins_Input_Relay.Input.Authorities_Information.SelfInfo);
			}
			
    		if(expectedFeedback != "") {
    			Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
    			//TODO add in Logic to remove the Bulletin
    			return;
    		}
        	
			int tableItemsBeforeRefresh = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count;
			Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
			int attempts = 0;
			while (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh && attempts < 5) {
				Delay.Milliseconds(500);
				Bulletinsrepo.Bulletins_Input_Relay.Input.RefreshButton.Click();
				GeneralUtilities.CheckWaitState(10);
				attempts++;
			}
			
			if (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count == tableItemsBeforeRefresh) {
				Ranorex.Report.Failure("Failed to Complete PTC Division Message Form at Division {"+division+"}, Refreshing did not produce the bulletin.");
				return;
			}
			
			Bulletinsrepo.BulletinRowIndex = (Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.Self.Rows.Count - 1).ToString();
			string bulletinNumber = Bulletinsrepo.Bulletins_Input_Relay.Input.CurrentItemsTable.BulletinRowByRowIndex.ReferenceNumber.GetAttributeValue<string>("Text");
			//Add Bulletin information to the persistent bulletin list
			NS_Bulletin.CreateBulletinRecord(bulletinSeed, bulletinNumber, type, "", "", district, "", "");
			Ranorex.Report.Info("TestStep", "Placed PTC Division Message Form at Division {"+division+"}.");
			NS_Bulletin.CloseBulletinItemsForm_NS();
			return;
    	}
    	
    }
}
