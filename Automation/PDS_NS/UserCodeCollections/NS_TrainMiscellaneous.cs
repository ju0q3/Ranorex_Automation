/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/29/2018
 * Time: 8:48 AM
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
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_TrainMiscellaneous
    {
    	public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
    	public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
    	
    	[UserCodeMethod]
    	public static void NS_ValidateADMSARCoding (string trainSeed, string arCode)
    	{
    		string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
    		ADMSEnvironment.ValidateARCodingInADMS(trainSymbol, arCode);
    	}
    	
    	[UserCodeMethod]
    	public static void NS_ValidateARCoding (string trainSeed, string arCodeText, string color, string problemTrainSeed, bool closeForm)
    	{
    		Trainsrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (Trainsrepo.TrainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		Ranorex.Delay.Seconds(1);
    		if (Trainsrepo.Train_Status_Summary.WindowControls.MaximizeInfo.Exists()) //If it doesnt exist, it's already maximized
    		{
    			Trainsrepo.Train_Status_Summary.WindowControls.Maximize.Click();
    		}
    		
    		if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+Trainsrepo.TrainId+"} could not be found in Train Status Summary.");
    			return;
    		}
    		
    		Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID.MoveTo(Location.Center);
    		//If I'm wrong, feel free to change this, but I believe that there will be many instances where ranorex believes the tooltip is already open, so just keep trying to look for the contains
    		//TODO Create a mapping for PDS colors before putting it into validations
    		color = color.ToLower();
    		if (color.Equals("orange"))
    		{
    			color = "#ffc800"; //TODO add to PDSColor!
    		}
    		Trainsrepo.tooltipText = "Autorouting Mode: <b style=\"color:"+color.ToLower()+"\" / "+arCodeText;
    		Ranorex.Report.Info("Java Object tooltip value: {"+Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID.Element.GetAttributeValueText("ToolTip")+"}");
			if (Trainsrepo.Train_Status_Summary.TSSTooltipInfo.Exists())
   			{
 				Ranorex.Report.Success("Tool tip contains text: " + Trainsrepo.tooltipText + ".");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Tooltip does not contain text " + Trainsrepo.tooltipText + ".");
    		}
    		
    		//Problem train validation if needed
    		if (!problemTrainSeed.Equals(""))
    		{
	    		if (PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(problemTrainSeed) == null)
	    		{
	    			Ranorex.Report.Failure("No TrainId found for problemTrainSeed {"+trainSeed+"}, ensure correct problemTrainSeed and that train was made");
	    			return;
	    		}
	    		
	    		Trainsrepo.tooltipText = "AR Problem Train: <b style=\"color:"+color.ToLower()+"\" / "+PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(problemTrainSeed)+" "+PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(problemTrainSeed);
	    		if (Trainsrepo.Train_Status_Summary.TSSTooltipInfo.Exists())
	   			{
	 				Ranorex.Report.Success("Tool tip contains text: " + Trainsrepo.tooltipText + ".");
	    		}
	    		else
	    		{
	    			Ranorex.Report.Failure("Tooltip does not contain text " + Trainsrepo.tooltipText + ". Check both color and content.");
	    		}
    		}
    		if (closeForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		
    	}
    	
    	/// <summary>
    	/// Validate color of a train box in the Train Status Summary
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="color">Input:color</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainColorExists_TrainStatusSummary(string trainSeed, string color)
    	{
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		
    		Trainsrepo.TrainId = trainId;
    		
    		if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Train Id {"+trainId+"} was not found in the Train Status Summary");
    			return;
    		}
    		
    		Ranorex.Adapter trainImage = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID;
    		PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(trainImage, color, true);
    		return;
    	}
    	
    	
    	/// <summary>
    	/// Validate color of a train box in the Train Status Summary
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="color">Input:color</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainColorExists_Trackline(string trainSeed, string color)
    	{
    		NS_Trackline.MakeTrainVisibleOnTrackline(trainSeed);
    		
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		
    		Tracklinerepo.TrainId = trainId;
    		Tracklinerepo.Trackline_Form_By_Train_Id.Self.EnsureVisible();
    		//First check if the TrainId hidden in a menu exists
    		if (Tracklinerepo.Trackline_Form_By_Train_Id.MenuTrainObjectInfo.Exists(0))
    		{
    			Ranorex.Adapter AlternateTrainIdLocation = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject;
    			PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(AlternateTrainIdLocation, color, true);
    			return;
    		//As long as the train is anywhere on the trackline, this should exist. If the previous one didn't exist then it should be visible
    		} else if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0)) {
    			Ranorex.Adapter TrainIdLocation = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject;
    			PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(TrainIdLocation, color, true);
    			return;
    		} else {
	    		Ranorex.Report.Error("No Train with Train Id {"+trainId+"} found visible on any Trackline");
	    		return;
    		}
    	}
    	
    	/// <summary>
    	/// Complete in progress activity from TSS
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_CompleteInProgressActivity_TrainStatusSummary(string trainSeed, bool closeTrainStatusSummaryForm = true, bool completeActivity = true)
    	{
    	    //TODO Maris fix this
    		if (!completeActivity)
    		{
    			return;
    		}
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			//Assume the trainSeed is supposed to be the trainId since the trainSeed wasn't found for a train that apparently exists
    			trainId = trainSeed;
    		}
    		if (trainId == "")
    		{
    			Ranorex.Report.Error("trainSeed is blank");
    			return;
    		}
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		Trainsrepo.Train_Status_Summary.WindowControls.Maximize.Click();
    		Trainsrepo.TrainId = trainId;
    		if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Row with Train Id {"+trainId+"} Not found in Train Status Summary");
    			return;
    		}
    		Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID.Click(WinForms.MouseButtons.Right);
    		Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.CompleteInProgressActivity.Click();
    		
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Open Train Status Summary if necessary and completes and removes each train.
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_RemoveTrainFromTracking_TrainStatusSummaryFunction(string trainSeed,bool clickYes, bool closeTrainStatusSummaryForm = true)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			//Assume the trainSeed is supposed to be the trainId since the trainSeed wasn't found for a train that apparently exists
    			trainId = trainSeed;
    		}
    		if (trainId == "")
    		{
    			Ranorex.Report.Error("trainSeed is blank");
    			return;
    		}
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		Trainsrepo.TrainId = trainId;
    		Tracklinerepo.TrainId = trainId;
			Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.Self.EnsureVisible();

    		if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
	    	{
	    		Ranorex.Report.Error("Row with Train Id {"+trainId+"} Not found in Train Status Summary");
	    		return;
	    	}
    		if (Tracklinerepo.Trackline_Form.TrainObjectInfo.Exists(0))
    		{
	    		GeneralUtilities.RightClickAndWaitForWithRetry(
					Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
					Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo
				);

				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.RemoveTrainInfo,
					Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo
				);
				
	    		if (clickYes) 
	    		{
	    			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Confirm_Remove_From_Tracking.YesButtonInfo, Trainsrepo.Train_Status_Summary.Confirm_Remove_From_Tracking.SelfInfo);
	    		}
	    		else
	    		{	
	    			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Confirm_Remove_From_Tracking.NoButtonInfo, Trainsrepo.Train_Status_Summary.Confirm_Remove_From_Tracking.SelfInfo);
	    		}
    		} else {
    			Ranorex.Report.Warn("Train {"+trainId+"} does not exist on trackline and so cannot be removed");
    		}
    		
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Remove a train fromt racking via the trackline.
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_RemoveTrainFromTracking_TracklineFunction(string trainSeed)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			//Assume the trainSeed is supposed to be the trainId since the trainSeed wasn't found for a train that apparently exists
    			trainId = trainSeed;
    		}
    		if (trainId == "")
    		{
    			Ranorex.Report.Error("trainSeed is blank");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		
    		//If Train exists nowhere on track, Error and exit
    		if (!Tracklinerepo.Trackline_Form.TrainObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Train {"+trainId+"} does not exist on any open trackline");
    			return;
    		}
    		
    		bool hiddenTrain = false;
    		int retries = 0;
    		//Check if Train is hidden
    		if (Tracklinerepo.Trackline_Form.HiddenTrainObjectItemInfo.Exists(0))
    		{
    			Tracklinerepo.Trackline_Form.HiddenTrainObjectItem.Click(WinForms.MouseButtons.Middle);
    			retries = 0;
    			if (!Tracklinerepo.Trackline_Form.MenuTrainObject.Visible && retries < 2)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				if (!Tracklinerepo.Trackline_Form.MenuTrainObject.Visible)
    				{
    					Tracklinerepo.Trackline_Form.HiddenTrainObjectItem.Click(WinForms.MouseButtons.Middle);
    				}
    				retries++;
    			}
    			Tracklinerepo.Trackline_Form.MenuTrainObject.Click(WinForms.MouseButtons.Right);
    			hiddenTrain = true;
    		} else {
    			//Train is visible
    			Tracklinerepo.Trackline_Form.VisibleTrainObject.Click(WinForms.MouseButtons.Right);
    		}
    		//Click Remove Train
    		Tracklinerepo.Trackline_Form.TrainObjectMenu.RemoveTrain.Click();

    		retries = 0;
    		while(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.SelfInfo.Exists(0) && retries < 3)
    		{
    			retries++;
    			Ranorex.Delay.Milliseconds(1000);
    		}
    		
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.SelfInfo.Exists(0))
    		{
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.YesButton.Click();
    		} 
    		else
    		{
    			Ranorex.Report.Failure("Unable to locate Confirm Remove from Tracking popup");
    		}
    		
    		if (hiddenTrain)
    		{
    			Tracklinerepo.Trackline_Form.HiddenTrainObjectItem.Click(WinForms.MouseButtons.Middle);
    		}
    		
    		retries = 0;
    		while (Tracklinerepo.Trackline_Form.TrainObjectInfo.Exists(0) && retries < 3)
    		{
    			retries++;
    			Ranorex.Delay.Milliseconds(500);
    		}
    		
    		if (!Tracklinerepo.Trackline_Form.TrainObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Info("Removed Train {"+trainId+"} successfully");
    			return;
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Open Train Status Summary if necessary and completes and removes each train.
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_CompleteAndRemoveAllTrains_TrainStatusSummary(bool closeTrainStatusSummaryForm = true)
    	{
    		if (Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
		    {
    			NS_Trainsheet.NS_CloseTrainsheet();
		    }
    		
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		//Find all train elements excluding rows with district information
    		IList<Ranorex.Cell> trainIdCellList = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.Self.Find<Ranorex.Cell>("row/cell[@columnindex='1' and @objectType='TRAIN']");
    		List<string> trainIdList = new List<string>();
    		foreach (Ranorex.Cell x in trainIdCellList)
    		{
    			trainIdList.Add(x.Element.GetAttributeValueText("Value"));
    		}
    		
    		int trainCount = trainIdList.Count;
    		if (trainCount == 0)
    		{
    			Ranorex.Report.Success("All Trains completed and removed");
    			return;
    		}
    		
    		foreach (string trainId in trainIdList)
    		{
    			Trainsrepo.TrainId = trainId;
    			
    			Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID.Click(WinForms.MouseButtons.Right);
    			int retries = 0;
    			while (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo.Exists(0) && retries < 2)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID.Click(WinForms.MouseButtons.Right);
    				retries++;
    			}
    			if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Menu did not appear when right clicking train in train status summary");
    				continue;
    			}
    			Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenTrainSheet.Click();
    			
    			//Complete the trip for the train
    			Ranorex.Report.Info("Completing trip for train {"+trainId+"}.");
    			NS_Trainsheet.NS_CompleteTripPlanForTrain(trainId,false);
    			
    			//Remove train from Tracking
    			Ranorex.Report.Info("Removing train {"+trainId+"} from tracking.");
    			NS_RemoveTrainFromTracking_TrainStatusSummaryFunction(trainId, true, false);
    			
    			Ranorex.Report.Info("Removing crews for train {"+trainId+"}.");
    			NS_Trainsheet.NS_RemoveCrewsForTrain(trainId);
    			
    			NS_Trainsheet.NS_TerminateTrain(trainId);
    			
    			//Determine if train was removed from the Train Status Summary List
    			if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Unable to remove train {"+trainId+"}.");
    			}
    			NS_Trainsheet.NS_CloseTrainsheet();
    		}
    		
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    	}
    	
    	
    	[UserCodeMethod]
		public static void NS_ValidateTIHColorInTSS(string trainSeed, string color, bool closeTrainStatusSummaryForm)
		{
			//ValidateColorForAnyAdapter
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			//Assume the trainSeed is supposed to be the trainId since the trainSeed wasn't found for a train that apparently exists
    			trainId = trainSeed;
    		}
    		if (trainId == "")
    		{
    			Ranorex.Report.Error("trainSeed is blank");
    			return;
    		}
    		
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		Trainsrepo.TrainId = trainId;
			Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.Self.EnsureVisible();
    		
    		if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Row with Train Id {"+trainId+"} Not found in Train Status Summary");
    			
    			if (closeTrainStatusSummaryForm)
    			{
    				NS_Trainsheet.NS_CloseTrainStatusSummary();
    			}
    			return;
    		} else {
    			PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapter(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID, color);
    		}
			
			
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		return;
			
		}
		
		/// <summary>
		/// Retrieve the Trainkey from ADMS and set it in the Train Object for future use in other methods
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void SetTrainKeyFromADMS(string trainSeed)
		{
			string trainKey = GetTrainKeyFromADMS(trainSeed);
			NS_TrainID.SetTrainKey(trainSeed, trainKey);
		}

		public static string GetTrainKeyFromADMS(string trainSeed)
		{
			string trainKey = null;

			// Skip the Oracle query if the train key is already stored in the NS_TrainObject
			string storedTrainKey = NS_TrainID.GetTrainKey(trainSeed);
			if (storedTrainKey != null)
			{
					trainKey = storedTrainKey;
			} else {
					string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
					string originDate = NS_TrainID.getOriginDate(trainSeed);
					string trainSection = NS_TrainID.GetTrainSection(trainSeed);
					string scac = NS_TrainID.GetTrainSCAC(trainSeed);
			
					trainKey = ADMSEnvironment.GetTrainKey(trainSymbol, originDate, trainSection, scac);
					NS_TrainID.SetTrainKey(trainSeed, trainKey);
			}
			return trainKey;
		}

		/// <summary>
		/// Set the Modes for Train in TrainStatus Summary
		/// </summary>
		/// <param name="trainSeed">Input trainSeed</param>
		/// <param name="ModeName">ex:if Mode is Manual or Automatic</param>
		[UserCodeMethod]
		public static void NS_Set_TrainMode_Trackline(string trainSeed ,string modeName,bool closeForm)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			Tracklinerepo.TrainId = trainId;
			
			if(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
			{
				Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
				int retries = 0;
				while (!Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo.Exists(0) && retries < 2)
				{
					Ranorex.Delay.Milliseconds(500);
					Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
					retries++;
				}
				
				if (!Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("Menu did not appear when right clicking train in trackline");
					return;
				}
				switch(modeName.ToUpper())
				{
					case "MANUAL":
						PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.ManualInfo);
						Ranorex.Report.Success("Mannual Mode has been Set for Train {"+trainId+"}");
						break;
					case "AUTOMATIC":
						PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.AutomaticInfo);
						Ranorex.Report.Success("Automatic Mode has been Set for Train {"+trainId+"}");
						break;
					default:
						Report.Info(string.Format("Modes button are not Enabled for Train {"+trainId+"}"));
						break;
				}
			}
			else
			{				
				Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
			}
		}	   	
    }
}
