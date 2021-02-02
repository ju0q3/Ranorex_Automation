/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/29/2018
 * Time: 10:32 AM
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
using PDS_CORE;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using Env.Code_Utils;
using STE.Code_Utils;
using PDS_CORE.Code_Utils;
using Oracle.Code_Utils;
using PDS_NS.CodeUtils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Trackline
    {
    	public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
		public static global::PDS_NS.TerritoryTransfer_Repo TerritoryTransferrepo = global::PDS_NS.TerritoryTransfer_Repo.Instance;

    	[UserCodeMethod]
    	public static void ValidateTrainToolTipContains (string trainSeed, string window, string toolTipText)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline. Not on occupancy");
    			return;
    		}

    		Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.MoveTo(Location.Center);
    		Ranorex.Delay.Seconds(5);
    		//If I'm wrong, feel free to change this, but I believe that there will be many instances where ranorex believes the tooltip is already open, so just keep trying to look for the contains
    		//byte retries = 0;
    		Tracklinerepo.ToolTipText = toolTipText;

    		//    		while(retries < 5)
//    		{
//    			if (Tracklinerepo.Tracklin.Exists())
//    			{
//    				Ranorex.Report.Success("Tool tip contains text: " + toolTipText + ".");
//    				Ranorex.Delay.Milliseconds(500);
//    				return;
//    			}
//    			retries++;
//    		}

    		Ranorex.Report.Failure("Tool tip did not contain text: " + toolTipText + ".");
    		return;

    	}



    	[UserCodeMethod]
        public static void AddQuickStop (string trainSeed, int duration, string trackSection, string mp)
        {
        	string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
        	Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline. Not on occupancy");
    			return;
    		}
    		
    		MakeTrainVisibleOnTrackline(trainSeed);

    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo, Tracklinerepo.Trackline_Form.TrainObjectMenu.QuickStopInfo);
    		Tracklinerepo.Trackline_Form.TrainObjectMenu.QuickStop.MoveTo(Location.LowerCenter);
    		Ranorex.Delay.Seconds(1);
    		Tracklinerepo.TrainMenuName = "30 Minutes";
    		Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.MoveTo();

    		switch (duration)
    		{
    			case (30):
    				if (mp.Equals(""))
    				{
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    				} else
    				{
    					Tracklinerepo.TrainMenuName = "30 Minutes at Milepost...";
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    					SelectMPfromTrackSection(trackSection, mp);
    				}
    				break;

    			case (60):
    				if (mp.Equals(""))
    				{
    					Tracklinerepo.TrainMenuName = "60 Minutes";
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    				} else
    				{
    					Tracklinerepo.TrainMenuName = "60 Minutes at Milepost...";
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    					SelectMPfromTrackSection(trackSection, mp);
    				}
    				break;

    			case (90):
    				if (mp.Equals(""))
    				{
    					Tracklinerepo.TrainMenuName = "90 Minutes";
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    				} else
    				{
    					Tracklinerepo.TrainMenuName = "90 Minutes at Milepost...";
    					Tracklinerepo.Trackline_Form.TrainObjectMenu.TrainMenuItemByName.Click();
    					SelectMPfromTrackSection(trackSection, mp);
    				}
    				break;

    			default:
    				Ranorex.Report.Error("Invalid Quick Stop Duration");
    				break;
    		}
    		//TODO Could include validation of trainsheet that train stop has been added
    		return;
        }

    	/// <summary>
    	/// Helps to set the required Milepost in 'Milepost Selection' slider, 
    	/// Can set Maxvalue, Minvalue, DefaultValue and DesiredValue in Milepost Selection slider.
    	/// </summary>
    	/// <param name="trackSection">Input: Pass the Tracksection Id(e.g. 2079092)</param>
    	/// <param name="mp">Input: Milepost value user wants to enter in Number
    	///                 Pass: Value as 'Maxvalue'
    	///                 Pass: Value as 'Minvalue' </param>
    	///                 Pass: If Milepost value is 'S110', so user needs to pass in number i.e. '110'
    	[UserCodeMethod]
    	public static void SelectMPfromTrackSection (string trackSection, string mp)
    	{
    		Tracklinerepo.TrackSectionId = trackSection;
    		Ranorex.Report.Info("TrackSection Id: " +trackSection);
    		Tracklinerepo.Trackline_Form.TrackSectionObject.Click(System.Windows.Forms.MouseButtons.Middle);
    		
    		int retries = 0;
    		while(!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo.Exists(0) && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
    		retries = 0;
    		mp = mp.ToLower();
    		if(mp.Equals("maxvalue"))
    		{
    			double maxValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.GetAttributeValue<double>("MaxValue");
    			Ranorex.Report.Info("Maximum Milepost value for " +trackSection+ " is:- " +maxValue+ "");
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Element.SetAttributeValue("Value", maxValue);
    			//Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click();
    			while(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo.Exists(0) && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
    			
    		}
    		else if(mp.Equals("minvalue"))
    		{
    			double minValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.GetAttributeValue<double>("MinValue");
    			Ranorex.Report.Info("Minimum Milepost value for " +trackSection+ " is:- " +minValue+ "");
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Element.SetAttributeValue("Value", minValue);
    			//Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click();
    			while(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo.Exists(0) && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
    			
    		}
    		else if(mp != "" && mp !="default")
    		{
    			string mpValueInNumber = Regex.Replace(mp, "[^0-9]", "");
    			double mpValue;
    			double.TryParse(mpValueInNumber, out mpValue);
    			Ranorex.Report.Info("Trying to input Milepost value as :- " + mpValue + "  for Tracksection " +trackSection);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Element.SetAttributeValue("Value", mpValue);
    			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click(Location.LowerCenter);
    			while(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo.Exists(0) && retries < 3)
    			{
    				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click(Location.LowerCenter);
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
    		}
    		else
    		{
    			//TODO Find some way to move slider to specified milepost
    			Ranorex.Report.Info("Default: " +mp);
    			//Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click();
    			while(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo.Exists(0) && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
    			//Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Mile_Post_Selection.MilePostSlider.Click(Location.LowerCenter);
    		}
    		
    		return;
    	}


    	[UserCodeMethod]
    	public static void TrackSectionContextAction (string deviceID, string action)
    	{
        	string[] devices = deviceID.Split('|');
        	//Bulkable in case you need to clear a whole bunch of manual tracks
        	foreach ( string device in devices)
        	{
        		Tracklinerepo.TrackSectionId = device;        		
                //See if the proper menu opened
                GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.SelfInfo);
            
                switch (action.ToUpper())
                {
                		case ("AUTOMATIC:TRACK SECTION"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.TrackSectionInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.TrackSection.Click();
                		      //TODO Validate Trackline Track Section goes from Manual to automatic
                		      break;

            		    case ("AUTOMATIC:CIRCUITS"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.CircuitsInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Automatic.Circuits.Click();
                		      //TODO Validate Trackline Track Sections go from Manual to automatic
                		      break;

            		    case ("MANUAL:TRACK SECTION"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.TrackSectionInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.TrackSection.Click();
                		      //TODO Validate Trackline Track Sections go from Manual to automatic
                		      break;

            		    case ("MANUAL:CIRCUITS"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.CircuitsInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Manual.Circuits.Click();
                		      //TODO Validate Trackline Track Sections go to manual
                		      break;

            		    case ("R-R: STACK R-R CLEAR"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.StackRRClearInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.StackRRClear.Click();
                		      //TODO Implement RR Functions
                		      //TODO Validate Trackline Track Sections go to manual
                		      break;
                		      
                		case ("R-R: R-R CLEAR"):
                		      GeneralUtilities.LeftClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.SelfInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.RRClearInfo);
                		      Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.RRClear.Click(); 
                		      Report.Info("Clicked on RR Clear" +device);
                		      break;

            		      //TODO Implement rest of RR & other context Actions

            		    default:
            		      Ranorex.Report.Failure("Improper Action: " + action + ".");
            		      break;
                }
        	}

            return;
    	}

        /// <summary>
    	/// Ensures a Train symbol on the trackline is visible for manipulation due to being on
    	/// a track with multiple items or a small track section
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	public static void MakeTrainVisibleOnTrackline(string trainSeed)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		Tracklinerepo.TrainId = trainId;
			
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Train with Train Id {"+trainId+"} was not found on any trackline. Ensure proper placement");
    			return;
    		}

    		//Here we will determine if the trainId is visible or in a menu on the trackline. If it's in a menu, it will middle click to make it visible
    		bool visibleOnTrackline = Tracklinerepo.Trackline_Form_By_Train_Id.VisibleTrainObjectInfo.Exists(0);

    		if (visibleOnTrackline)
    		{
    			//Train is already visible
    			Report.Info("Train is already visible");
    			return;
    		} else {
    			Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Middle);
    			int retries = 0;
    			while (!Tracklinerepo.Trackline_Form_By_Train_Id.MenuTrainObjectInfo.Exists(0) && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Middle);
    				retries++;
    			}

    			if (!Tracklinerepo.Trackline_Form_By_Train_Id.MenuTrainObjectInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Unable to display Train Id {"+trainId+"} on Trackline by middle clicking location");
    			}
    			return;
    		}
    	}

    	/// <summary>
    	/// Creates a STE Vehicle which automatically moves the train as long as it has the authority to do so, i.e. lamps
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="startingTrackId">Input:Track Id the train should be at that you're wanting to move</param>
    	/// <param name="trainType">Input:Type of Train, i.e. Freight, Passenger, Unrestricted</param>
    	/// <param name="consistSeed">Input:consistSeed</param>
    	/// <param name="trainSpeedMph">Input:How fast you want the train to move i.e. 100</param>
    	/// <param name="offSetFromStart">Input:Offset in miles from the beginning of the track section</param>
    	/// <param name="direction">Input:whether the train is UpBound or DownBound</param>
    	/// <param name="timeToStart">Input:Time in minutes to begin moving occupancies, CURRENT for now</param>
    	[UserCodeMethod]
    	public static void NS_StartSteVehicle(string trainSeed, string startingTrackId, string trainType, string consistSeed, string trainSpeedMph, string offSetFromStart, string direction, string timeToStart)
        {
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		string trainLength = PDS_CORE.Code_Utils.NS_TrainID.GetConsistObjectFromTrain(trainSeed, consistSeed).TrainLength;
    		SteOccupancyCollection.initializeVehicle(trainId, startingTrackId, trainType, trainLength, trainSpeedMph, offSetFromStart, direction, timeToStart);

    		if (timeToStart == "CURRENT")
            {
            	Tracklinerepo.TrackSectionId = startingTrackId;
            	if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
            	{
            		Ranorex.Report.Info("Could not find track section {"+startingTrackId+"} on any open trackline");
            		return;
            	}
            	Tracklinerepo.Trackline_Form_By_TrackSection_Id.Self.EnsureVisible();
    			Ranorex.Adapter TrainSectionElement = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject;
    			int retries = 0;
    			bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, true);
    			while (!success && retries < 20)
    			{
    				Ranorex.Delay.Seconds(1);
    				success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, true);
    				retries++;
    			}

    			if (!success)
    			{
    				Ranorex.Report.Info("Did not find occupancy at track section {"+startingTrackId+"}");
    			}
            }
    		return;
    	}

    	/// <summary>
    	/// Removes a ste vehicle
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	[UserCodeMethod]
    	public static void NS_RemoveSteVehicleFunction(string trainSeed)
        {
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		SteOccupancyCollection.removeVehicle(trainId);
    		return;
    	}

    	/// <summary>
    	/// Waits for a particular train to arrive at a track section
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="trackSection">Input:Track section for the train to arrive at</param>
    	/// <param name="maxWaitSeconds">Input:Max wait time in seconds</param>
    	[UserCodeMethod]
    	public static void NS_WaitForTrainToArriveAtTrackSection(string trainSeed, string trackSection, int maxWaitSeconds)
        {
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null && trainSeed == "")
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		} else if ( trainId == null)
    		{
    			trainId = trainSeed;
    		}
    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
    			return;
    		}

    		string trackLabelId = "";
    		string trackSectionId = "";
    		VMEnvironment vm = VMEnvironment.Instance();
    		Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);

    		System.DateTime currentTime = System.DateTime.Now;
    		System.DateTime newTimeFromNow = currentTime.AddSeconds(maxWaitSeconds);
    		while (newTimeFromNow > currentTime)
    		{
    			trackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
    			trackSectionId = TDMSDb.GetSectionIdfromAssociatedTrackLabel(trackLabelId);
    			if (trackSection == trackSectionId)
    			{
    				Ranorex.Report.Info("Train {"+trainId+"} arrived at track section {"+trackSection+"} within {"+maxWaitSeconds.ToString()+"} seconds.");
    				return;
    			}
    			currentTime = System.DateTime.Now;
    		}
    		Ranorex.Report.Error("Train {"+trainId+"} did not arrive at track section {"+trackSection+"} within {"+maxWaitSeconds.ToString()+"} seconds but found at {" +trackSectionId+ "}.");
    		Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Train_Id.Self);
    		return;
    	}

    	/// <summary>
    	/// Move occupancies over a series of pipe delimited track sections either in a separate thread, or normal
    	/// </summary>
    	/// <param name="trackSections">Input:Pipe delimited track sections to move the occupancy to</param>
    	/// <param name="timeBetweenMovementsSeconds">Input:Time between each ste message sent to place/remove occupancies</param>
    	/// <param name="optionalNumberOfSectionForOccupancy">Input:How long the occupancy is, such as the train length existing over two track sections. default is 1</param>
    	/// <param name="optionalInBackground">Input:Default False, if True the occupancy changes will be in a separate thread</param>
    	/// <param name="keepFinalOccupancy">Input:If True, the last occupancy in the list of track sections will not be removed</param>
    	/// <param name="placeFirstOccupancy">Input:If False, assumes the first occupancy is already placed and doesn't place it</param>
    	[UserCodeMethod]
    	public static void NS_MoveOccupancyByTrackSectionsFunction(string trackSections, int timeBetweenMovementsSeconds, int optionalNumberOfSectionForOccupancy, bool optionalInBackground, bool keepFinalOccupancy, bool placeFirstOccupancy)
        {
        	if (!optionalInBackground) {
        		MoveOccupancies(trackSections, timeBetweenMovementsSeconds, optionalNumberOfSectionForOccupancy, keepFinalOccupancy, placeFirstOccupancy);
        	} else {
        		var thread = new Thread(() => MoveOccupancies(trackSections, timeBetweenMovementsSeconds, optionalNumberOfSectionForOccupancy, keepFinalOccupancy, placeFirstOccupancy));
        		thread.Start();
        	}
    		return;
        }

        public static void MoveOccupancies(string trackSections, int timeBetweenMovementsSeconds, int optionalNumberOfSectionForOccupancy, bool keepFinalOccupancy, bool placeFirstOccupancy) {
        	//string trackSection = "";
        	if (optionalNumberOfSectionForOccupancy == 0) {
        		Ranorex.Report.Info("Length of Occupancy cannot be zero, assuming it should be one.");
        		optionalNumberOfSectionForOccupancy = 1;
        	}
        	string[] trackSectionsArray = trackSections.Split('|');
        	Ranorex.Report.Info("TestStep","Moving train via occupancy from track " + trackSectionsArray[0] + " to " + trackSectionsArray[trackSectionsArray.Length - 1]);
        	int count = 0;
        	foreach(string trackSection in trackSectionsArray) {
        		if (count == 0 && !placeFirstOccupancy) {
        			count++;
        			continue;
        		}
        		Ranorex.Report.Info("TestStep", "Move Occupancy to Track Section "+trackSection);
        		SteOccupancyCollection.manualOccupancy(trackSection,"Occupied");
        		if (count >= optionalNumberOfSectionForOccupancy) {
        			SteOccupancyCollection.manualOccupancy(trackSectionsArray[count - optionalNumberOfSectionForOccupancy],"NotOccupied");
        			Ranorex.Report.Info("TestStep", "Removing Occupancy for "+trackSectionsArray[count - optionalNumberOfSectionForOccupancy]);
        		}
        		count++;
        		Ranorex.Delay.Seconds(timeBetweenMovementsSeconds);
        	}
        	count--;
        	if (!keepFinalOccupancy) {
        		for (int i = 0; i < optionalNumberOfSectionForOccupancy; i++) {
        			SteOccupancyCollection.manualOccupancy(trackSectionsArray[count - i],"NotOccupied");
        			Ranorex.Report.Info("TestStep", "Removing Occupancy for "+trackSectionsArray[count - i]);
        		}
        	}
        	return;
        }

    	/// <summary>
    	/// Move train over a series of pipe delimited track sections either in a separate thread, or normal via LLM2 Message (TWC Only)
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="engineSeed">Input:engineSeed</param>
    	/// <param name="trackSections">Input:Pipe delimited track sections to move the train to</param>
    	/// <param name="division">Input:What division the train and track sections are in, probably Georgia</param>
    	/// <param name="speed">Input:The speed of the train reported in the message, doesn't seem to matter much for these purposes</param>
    	/// <param name="timeBetweenMovementsSeconds">Input:Time between each ste message sent to place/remove occupancies</param>
    	/// <param name="optionalInBackground">Input:Default False, if True the llm changes will be in a separate thread</param>
    	[UserCodeMethod]
    	public static void NS_MoveTrainViaLLM2byTrackSectionsFunction(string trainSeed, string engineSeed, string trackSections, string division, string speed, string timeBetweenMovementsSeconds, bool optionalInBackground, string hostname)
        {
        	if (!optionalInBackground) {
        		MoveTrainViaLLM2(trainSeed, engineSeed, trackSections, division, speed, timeBetweenMovementsSeconds, hostname);
        	} else {
        		var thread = new Thread(() => MoveTrainViaLLM2(trainSeed, engineSeed, trackSections, division, speed, timeBetweenMovementsSeconds, hostname));
        		thread.Start();
        	}
    		return;
        }

    	/// <summary>
    	/// Move train over a series of pipe delimited track sections either in a separate thread, or normal via LLM2 Message (TWC Only)
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="engineSeed">Input:engineSeed</param>
    	/// <param name="trackSections">Input:Pipe delimited track sections to move the train to</param>
    	/// <param name="division">Input:What division the train and track sections are in, probably Georgia</param>
    	/// <param name="speed">Input:The speed of the train reported in the message, doesn't seem to matter much for these purposes</param>
    	/// <param name="timeBetweenMovementsSeconds">Input:Time between each ste message sent to place/remove occupancies</param>
    	public static void MoveTrainViaLLM2(string trainSeed, string engineSeed, string trackSections, string division, string speed, string timeBetweenMovementsSeconds, string hostname)
        {
    		string [] splitTrackSections = trackSections.Split('|');

        	int delayTime = Convert.ToInt32(timeBetweenMovementsSeconds);
        	string symbol = NS_TrainID.GetTrainSymbol(trainSeed);
        	string scac = NS_TrainID.GetTrainSCAC(trainSeed);
        	string section = NS_TrainID.GetTrainSection(trainSeed);
        	var engineObject = NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed);
        	string engineInitial = engineObject.EngineInitial;
        	string engineNumber = engineObject.EngineNumber;
        	string source = "OTC";

        	foreach (string trackSection in splitTrackSections)
        	{
        		Tracklinerepo.TrackSectionId = trackSection;
        		if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
        		{
        			Ranorex.Report.Error("Could not find Track section {"+trackSection+"} on any open Trackline");
        			continue;
        		}
        		string district = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject.GetAttributeValue<string>("DistrictName");
        		string track = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject.GetAttributeValue<string>("TrackName");
        		//For the purpose of moving track sections, we will select any ol' milepost within the track section and since start MP is available, we will use that.
        		string milepost = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject.GetAttributeValue<string>("StartMP");
                string locationEventDay = "0";
                string reportDay = "0";
        		Ranorex.Delay.Seconds(delayTime);
        		PDS_NS.UserCodeCollections.NS_PTC_Messages.SendLLM_2Simple(trainSeed, engineSeed, milepost, division, track, source, district, speed, locationEventDay, "4", "E", reportDay, "5", "E", hostname);

        		//Now we wait for the LLM to have moved the train to the correct location for a maximum of 10 seconds
        		NS_WaitForTrainToArriveAtTrackSection(trainSeed, trackSection, 10);
        	}

        	return;

    	}

    	/// <summary>
    	/// Places an occupancy on the trackline via ste, if pipes are included, assumes the first trackSection
    	/// </summary>
    	/// <param name="trackSection">Input:Track section to place an occupancy on</param>
    	/// <param name="waitForExists">Input:Waits a certain amount of time for the occupancy to exists, otherwise generates an error</param>
    	[UserCodeMethod]
    	public static void NS_PlaceOccupancyFunction(string trackSection, bool waitForExists)
        {
    		string[] trackIds = trackSection.Split('|');
    		
    		foreach (string track in trackIds)
    		{
            	SteOccupancyCollection.manualOccupancy(track,"Occupied");

	            if (waitForExists)
	            {
	            	Tracklinerepo.TrackSectionId = track;
	            	if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
	            	{
	            		Ranorex.Report.Error("Could not find track section {"+track+"} on any open trackline");
	            		continue;
	            	}
	            	Tracklinerepo.Trackline_Form_By_TrackSection_Id.Self.EnsureVisible();
	    			Ranorex.Adapter TrainSectionElement = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject;
	    			int retries = 0;
	    			bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, true);
	    			while (!success && retries < 20)
	    			{
	    				Ranorex.Delay.Seconds(1);
	    				success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, true);
	    				retries++;
	    			}
	
	    			if (!success)
	    			{
	    				Ranorex.Report.Error("Track at track section {"+track+"} does not have an occupancy");
	    			}
	            }
    		}
            return;
        }
//TODO  - 12/2/19 - Roger might need this for incoming change to iterate over all items in trackSection list since he only uses the last one
//    	public static void RemovingLastOccupancyInList (string trackSection, bool waitForNotExist)
//    	{
//    		if (trackSection.Contains("|"))
//    		{
//    			string[] trackIds = trackSection.Split('|');
//    			NS_RemoveOccupancyFunction(trackIds[trackIds.Length-1], waitForNotExist);
//    		}
//    		else
//    			NS_RemoveOccupancyFunction(trackSection, waitForNotExist);
//    	}
    	
    	/// <summary>
    	/// Removes an occupancy on the trackline via ste, if pipes are included, assumes the last trackSection
    	/// </summary>
    	/// <param name="trackSection">Input:Track section to remove an occupancy on</param>
    	/// <param name="waitForNotExist">Input:Wait for Occupancy to no longer be on trackline</param>
    	[UserCodeMethod]
    	public static void NS_RemoveOccupancyFunction(string trackSection, bool waitForNotExist)
        {

    		string[] trackIds = trackSection.Split('|');
    		
    		foreach (string track in trackIds)
	            SteOccupancyCollection.manualOccupancy(track,"NotOccupied");
    		
    		foreach (string track in trackIds)
    		{
	    		if (waitForNotExist)
		            {
		            	Tracklinerepo.TrackSectionId = track;
		            	if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
		            	{
		            		Ranorex.Report.Error("Could not find track section {"+track+"} on any open trackline");
		            		continue;
		            	}
		            	Tracklinerepo.Trackline_Form_By_TrackSection_Id.Self.EnsureVisible();
		    			Ranorex.Adapter TrainSectionElement = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject;
		    			int retries = 0;
		    			bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, false);
		    			while (!success && retries < 20)
		    			{
		    				Ranorex.Delay.Seconds(3);
		    				success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, false);
		    				retries++;
		    			}
		
		    			if (!success)
		    			{
		    				Ranorex.Report.Error("Track at track section {"+track+"} still has occupancy");
		    			}
		            }
    		}
            return;
        }

		/// <summary>
		/// Place a switch on the trackline.
		/// </summary>
		/// <param name="switchId">Input: The device id point of the switch to place on the trackline.</param>
		/// <param name="switchMode">Input: The mode of the switch. Options are 'NORMAL' or 'REVERSE'. Not case sensitive.</param>
		[UserCodeMethod]
		public static void NS_OffPowerSwitchPosition(string switchId, string switchMode)
		{

			Tracklinerepo.SwitchId = switchId;
			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error(string.Format("Unable to find switch '{0}'. Ensure that it is part of controlled territories.", switchId));
			}

			Ranorex.Core.Repository.RepoItemInfo menuOption;
			switch (switchMode.ToLower())
			{
				case "normal":
					menuOption = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchNormalInfo;
					break;
				case "reverse":
					menuOption = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchReverseInfo;
					break;
				default:
					Ranorex.Report.Failure(string.Format("Please specify 'NORMAL' or 'REVERSE' switchMode argument. The current value is '{0}'", switchMode));
					return;
			}
			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo, menuOption);

			Ranorex.Adapter menuButton = menuOption.CreateAdapter<Unknown>(true);
			menuButton.Click();
				}

    	/// <summary>
    	/// Changes switch direction, waiting for the last switch to stop blinking before finishing
    	/// </summary>
    	/// <param name="switchDirection">Input:Switch Menu Item</param>
    	/// <param name="switches">Input:Switch or switch Ids separated by pipe delimiter</param>
    	/// <param name="Transmit">Input:Where to transmit after changing the switch direction</param>
    	[UserCodeMethod]
    	public static void NS_ChangeSwitchDirectionFunction(string switchDirection, string switches, bool Transmit)
        {
        	if (switches == "") {
        		return;
        	}
        	Tracklinerepo.SwitchMenuName = switchDirection;
        	string[] switchList = switches.Split('|');
        	foreach (string switchId in switchList) {
        		Tracklinerepo.SwitchId = switchId;
        		if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SelfInfo.Exists(0))
        		{
        			Ranorex.Report.Error("Switch Id {"+switchId+"} could not be found on any open trackline");
        			continue;
        		}
        		Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right);
        		if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo.Exists(0)) {
        			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.Click(Location.CenterLeft);
        			Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right,Location.LowerCenter);
        		}
        		if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo.Exists(0)) {
        			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.Click(Location.CenterLeft);
        			Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right,Location.LowerRight);
        		}
        		if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo.Exists(0)) {
        			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.Click(Location.CenterLeft);
        			Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.Click(WinForms.MouseButtons.Right,Location.LowerLeft);
        		}
        		Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.Click();
        		
        		// Handel if 'Blocked Switchess' pop-up appear
        		if(Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Blocked_Switch.SelfInfo.Exists(0))
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Blocked_Switch.ContinueButtonInfo,
        			                                                 Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Blocked_Switch.SelfInfo);
		        }
        	}

        	if (Transmit)
        	{
        		Tracklinerepo.Trackline_Form_By_Switch_Id.RibbonMenu.Transmit.Click();
        		int iterations = 0;
            	int maxIterations = 30;
            	while(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations) {
            		Ranorex.Delay.Seconds(1);
            		iterations++;
            	}
            	if (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking")) {
            		Ranorex.Report.Error("Switch did not stop blinking within "+maxIterations.ToString()+" seconds for switch "+Tracklinerepo.SwitchId+". System may be slow or Transmit was not pressed");
            	}
        	}
        	return;
        }

    	/// <summary>
    	/// Waits for a signal to turn solid green or solid red
    	/// </summary>
    	/// <param name="signalId">Input:Signal Id for Trackline lamp</param>
		/// <param name="waitForGreen">Input:waitForGreen</param>
    	[UserCodeMethod]
    	public static void NS_WaitForSignalToTransition(string signalId, bool waitForGreen)
        {
    		Tracklinerepo.LampId = signalId;
        	if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Signal Id {"+signalId+"} could not be found on any open trackline");
        		return;
        	}

        	int retries = 0;
        	bool isLampGreen = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true);
        	while ((Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") || (isLampGreen != waitForGreen)) && retries < 20)
        	{
        		Ranorex.Delay.Seconds(1);
        		isLampGreen = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true);
        		retries++;
        	}

        	if (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") || (isLampGreen != waitForGreen))
        	{
        		Ranorex.Report.Error("Signal with Id {"+signalId+"} failed to finish transitioning to {"+(waitForGreen ? "Green" : "Red")+"}.");
        	}
        	return;
    	}

		/// <summary>
    	/// Waits for a switch to stop blinking. This method should only be used after a transmit has been initiated.
    	/// </summary>
    	/// <param name="switchId">Input:Signal Id for Trackline lamp</param>
    	[UserCodeMethod]
    	public static void NS_WaitForSwitchToTransition(string switchId)
        {
    		Report.Info("TestStep", "Waiting for switch position change to be completed");

    		Tracklinerepo.SwitchId = switchId;
			int waitTimeSeconds = 20;

			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Switch Id {"+switchId+"} could not be found on any open trackline");
        		return;
        	}

			if (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking"))
			{
				int currentWaitTime = 0;
				while (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking") && (currentWaitTime < waitTimeSeconds))
				{
					Ranorex.Delay.Seconds(1);
					currentWaitTime++;
					if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking"))
					{
						Ranorex.Report.Success(string.Format("Switch ID '{0}' transitioned within '{1}' seconds", switchId, waitTimeSeconds));
						return;
					}
				}
			}

			if (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking"))
			{
				Ranorex.Report.Error(string.Format("Switch ID '{0}' did not transition within '{1}' seconds", switchId, waitTimeSeconds));
			}
    	}

    	/// <summary>
    	/// Right clicks train on trackline and completes in progress activity
    	/// </summary>
    	/// <param name="trainSeed">Input:Trainseed</param>
    	[UserCodeMethod]
    	public static void NS_CompleteInProgressActivity_Trackline(string trainSeed)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Train with Train Id {"+trainId+"} was not found on any trackline. Ensure proper placement");
    			return;
    		}    		

    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo, Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo);
    		Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.CompleteInProgressActivity.Click();
    		return;
    	}

		/// <summary>
		/// Issue a PSS on the trackline.
		/// </summary>
		/// <param name="signalId">The signal/lamp Id to be given to create PSS.</param>
		[UserCodeMethod]
		public static void NS_IssuePSS_TrackLine(string signalId)
		{
			Report.Info("TestStep", string.Format("Issuing PSS for signal Id '{0}'", signalId));

			Tracklinerepo.LampId = signalId;
			bool signalExists = Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0);

			if (!signalExists)
			{
				Ranorex.Report.Error(String.Format("Signal Id '{0}' not found in controlled territories", signalId));
				return;
			}

			// Right-click on signal to bring up options for signal, including permission to pass stop
			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.PermissionToPassStopInfo
			);
			// Click on Permission to Pass Stop.
			
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.PermissionToPassStopInfo,
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo
			);
			//Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop
			// if(Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.SelfInfo.Exists(0))
			// {				
			// 	GeneralUtilities.ClickAndWaitForNotExistWithRetry(
			// 	Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.YesButtonInfo,
			// 	Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo);			
			// }
			
			
		}

		/// <summary>
		/// This is a special case. 
		/// When: A switch position change is pending (e.g. normal to reverse) and a PSS is issued through the switch
		/// Then: The track section should not go green until the switch stops blinking
		/// </summary>
		[UserCodeMethod]
		public static void NS_ValidateTrackColorDelay_PendingSwitchAndPSS_Trackline(string switchId, string trackSectionId)
		{
			Report.Info("TestStep", "Validating the PSS route's track color does not transition to green until switch position change is successfully applied.");
			
			Tracklinerepo.SwitchId = switchId;
			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo.Exists(0))
			{
				Report.Error(string.Format("Switch Id: '{0}' not in controlled territories", switchId));
				return;
			}

			Tracklinerepo.TrackSectionId = trackSectionId;
			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo.Exists(0))
			{
				Report.Error(string.Format("Track section Id: '{0}' not in controlled territories", trackSectionId));
				return;
			}

			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking"))
			{
				Report.Error(string.Format("Switch '{0}' is not in transition. Ensure that the request has been transmitted, and try again.", switchId));
				return;
			}

			bool trackColorWasPending = false;
			int iterations = 0;
			while (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking") && iterations < 20)
			{
				trackColorWasPending = GeneralUtilities.CheckColorForAnyAdapterByPixel(
					repoItem: Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject, color: "Green", validateExists: false
				);
				Delay.Seconds(1);
				iterations++;
			}

			if (Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking"))
			{
				Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject);
				Report.Error(string.Format("Switch '{0}' has not properly transitioned, and may have timed-out.", switchId));
				return;
			}

			bool trackColorIsApplied = false;
			trackColorIsApplied = GeneralUtilities.CheckColorForAnyAdapterByPixel(
					repoItem: Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject, color: "Green", validateExists: true
				);
			

			if (trackColorWasPending && trackColorIsApplied)
			{
				Report.Success("Validation", "The PSS route color did not change until the switch position change was complete");
			} else {
				Report.Failure("Validation", "The PSS route color change was not applied at the correct moment.");
			}
		}

		/// <summary>
		/// This method interfaces with a confirmation dialog to change off-power switch position, pending compliance with NS operating rule 1.
		/// </summary>
		/// <param name="switchId">The switch to be changed.</param>
		/// <param name="confirmCompliance">Whether or not to confirm authorization for off-power switch.</param>
		/// <param name="expectedFeedback">Input: Optional feedback to be displayed at the bottom of the trackline window.</param>
		[UserCodeMethod]
		public static void NS_OffPowerSwitch_ConfirmCompliance(string switchId, bool confirmCompliance = true, string expectedFeedback = null)
		{
			string operatingRule = "NS Operating Rule 192";
			Report.Info("TestStep", string.Format("Confirming compliance with '{0}' in order to complete off-power switch position change.", operatingRule));
			Tracklinerepo.SwitchId = switchId;

			Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.Self.EnsureVisible();

			string formContents = Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.SwitchChangeTextLine2.GetAttributeValue<string>("Text");
			if (formContents.Contains(operatingRule))
			{
				Ranorex.Report.Success("Validation", String.Format("Prompt asks the user to confirm compliance with '{0}'.", operatingRule));
			} else {
				Ranorex.Report.Error("Validation", String.Format("No prompt exists to confirm compliance with '{0}'.", operatingRule));
			}

			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.Self);

			if (confirmCompliance)
			{
				// Confirm Off-power switch change Authorization.
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.YesButtonInfo,
					Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.YesButtonInfo
				);

				// TODO: Refine conditions. E.g. switch color / is the switch blinking / etc.
				if (!Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.SelfInfo.Exists(0))
				{
					Ranorex.Report.Success("Off-power switch position change initiated.");
				}

			}
			else
			{
				// Confirm that off-power switch change is not authorized.
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.NoButtonInfo,
					Tracklinerepo.Trackline_Form_By_Switch_Id.TracklineGeneratedForms.Off_Power_Switch_Change.NoButtonInfo
				);
				Ranorex.Report.Success("Off-power switch change successfully cancelled.");
			}

			Ranorex.Delay.Milliseconds(500); // Smallest of delays for error message to appear.
			string feedback = Tracklinerepo.Trackline_Form_By_Switch_Id.Feedback.TextValue.ToString();
			if (string.IsNullOrEmpty(feedback)) // De-facto indication that there are no errors from initiating off-power switch.
			{
				// TODO: The below needs to be kept, but in a stable state.
				// NS_Trackline_Validations.NS_ValidateSwitchBlinking(switchId, true, "blue");
			}

			if (!string.IsNullOrEmpty(expectedFeedback))
			{
				Ranorex.Report.Info("TestStep", "Checking feedback from off-power switch change");
				Ranorex.Report.Info(string.Format("Actual feedback: '{0}'", feedback));
				if (feedback.Contains(expectedFeedback))
				{
					Ranorex.Report.Success(string.Format("Feedback includes '{0}'", expectedFeedback));
				}
				else
				{
					Ranorex.Report.Error(string.Format("Feedback does not include '{0}' as expected", expectedFeedback));
				}
			}
		}

		/// <summary>
		/// Stops the signal on trackline
		/// </summary>
		/// <param name="signalId">Input:Signal ID to clear</param>
		/// <param name="Transmit">Input:Transmit (bool)</param>
		[UserCodeMethod]
		public static void NS_StopSignal(string signalId, bool Transmit)
		{
			Report.Info("TestStep", string.Format("Stopping signal Id '{0}'", signalId));

			Tracklinerepo.LampId = signalId;
			if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
				return;
			}

			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo,
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.StopInfo
			);

			Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Stop.Click();
			Ranorex.Delay.Milliseconds(500);

			int retries = 0;
			while (!Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButtonInfo.Exists(0) && retries < 8)
			{
				Delay.Milliseconds(250);
				retries++;
			}

			if (Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButtonInfo.Exists(0))
			{
				Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButton.Click();
			} else {
				Report.Error("Acknowlegement button has not appeared for stop signal");
			}


			if (Transmit)
			{
				int iterations = 0;
				int maxIterations = 20;
				Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.Click();
				while (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations)
				{
					Ranorex.Delay.Seconds(1);
					iterations++;
				}
			}

			Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.Self);
			return;

		}

		/// <summary>
		/// This method interfaces with a confirmation dialog to issue PSS, pending compliance with NS operating rule 277.
		/// </summary>
		/// <param name="signalId">Signal Id associated with PSS.</param>
		/// <param name="confirmPSS">Whether or not to confirm compliance, and to issue PSS.</param>
		[UserCodeMethod]
		public static void NS_PSS_ConfirmCompliance(string signalId, bool confirmPSS = true)
		{
			Ranorex.Report.Info("TestStep", "Confirming compliance with operating rule 277");
			Tracklinerepo.LampId = signalId;

			if (confirmPSS)
			{
				// Confirm PSS Authorization.
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.YesButtonInfo,
					Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.YesButtonInfo
				);
				Ranorex.Report.Success("PSS Issued successfully.");
			}
			else
			{

				// Confirm that PSS is not authorized.
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.NoButtonInfo,
					Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.NoButtonInfo
				);
				Ranorex.Report.Success("PSS cancelled.");
			}

			Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.Self);
		}

		/// <summary>
		/// Clear Signal by sending request thru STE request file
		/// </summary>
		/// <param name="signalId">Signal id of signal which needs to be cleared</param>
		/// <param name="waitForExists">TRUE if wait to exists for the signal to clear, Else FALSE</param>
		[UserCodeMethod]
    	public static void NS_ClearSignalThruSTE(string signalId, bool waitForExists)
        {
    		if(signalId == "" && signalId == null)
    		{
    			Ranorex.Report.Failure("Please provide correct signal id, Signal Id provided is either null or empty");
    			return;
    		}
            SteOccupancyCollection.SetDevice(signalId,"ClearSignal");

            if (waitForExists)
            {
            	Tracklinerepo.LampId = signalId;
            	if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
            	{
            		Ranorex.Report.Error("Could not find signal {"+signalId+"} on any open trackline");
            		return;
            	}
            	Tracklinerepo.Trackline_Form_By_Signal_Id.Self.EnsureVisible();
    			Ranorex.Adapter signalElement = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject;
    			int retries = 0;
    			bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForTrackSectionAdapterByPixel(signalElement, "Green", true);
    			while (!success && retries < 30)
    			{
    				Ranorex.Delay.Seconds(1);
    				success = PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForTrackSectionAdapterByPixel(signalElement, "Green", true);
    				retries++;
    			}

    			if (!success)
    			{
    				Ranorex.Report.Failure("Did not find signal was cleared for Signal Id {"+signalId+"}");
    			}
            }
            return;
        }
    	
    	/// <summary>
    	/// A helper function for test flow especially movement planner to make sure the train appears in the departure list before starting a movement plan
    	/// </summary>
    	/// <param name="trainSeed">Seed for train that we want to wait for in the departure list</param>
    	/// <param name="maxWaitSeconds">Maximum amount of time ranorex will wait for the given train to exist</param>
    	[UserCodeMethod]
    	public static void NS_WaitForTrainInDepartureList(string trainSeed, int maxWaitSeconds)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		System.DateTime currentTime = System.DateTime.Now;
    		System.DateTime newTimeFromNow = currentTime.AddSeconds(maxWaitSeconds);
    		while (newTimeFromNow > currentTime)
    		{
    			if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    			{
		    		//Category Description of element contains whether it is in the departure list or on track
		    		string tracklineTrainCategory = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("DisplayedType");
		    		if (tracklineTrainCategory == "in the Departure List")
		    		{
		    			Ranorex.Report.Info("Train {"+trainId+"} found in Departure List");
		    			return;
		    		} else {
		    			Ranorex.Report.Failure("Train {"+trainId+"} has appeared on track");
		    			return;
		    		}
    			}
    			currentTime = System.DateTime.Now;
    		}
    		//If we didnt hit one of our other conditions we failed
    		Ranorex.Report.Failure("Train {"+trainId+"} did not appear on trackline.");
    	}
    	
    	///<summary>
    	/// open the Monitor Control Point Communication form
    	/// </summary>
    	/// <param name="deviceId">Input:deviceId</param>
    	[UserCodeMethod]
    	public static void NS_Open_MonitorControlPointCommunication_Form(string deviceId)
    	{
    		Tracklinerepo.ControlPointName = deviceId;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Could not find control point name with device id {"+deviceId+"} on any open trackline");
				return;
			}

    		Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObject.Click();
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo, Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);
    		GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.MonitorControlPointCommunicationsInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.SelfInfo);
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.SelfInfo.Exists(0) )
    		{
    			Report.Success("Monitor control point communication form is opened successfully");
    		}
    		else
    		{
    			Report.Failure(" Failed to open Monitor control point communication form");
    		}
    	}

		[UserCodeMethod]
		public static void NS_CreateRapidRoute_Full_Trackline(
			string objectId1, 
			string objectType1, 
			string rapidRouteOption1,
			string expectedFeedback1,
			string objectId2, 
			string objectType2, 
			string rapidRouteOption2,
			string expectedFeedback2,
			bool transmit, 
			bool clickAcknowledgeIfExists
		) {
			switch (objectType1.ToUpper())
			{
				case "SIGNAL":
					NS_RapidRouteMenuOption_BySignal(signalId: objectId1, rapidRouteOption: rapidRouteOption1, clickAcknowledgeIfExists: clickAcknowledgeIfExists, expectedFeedback: expectedFeedback1);
					break;
				case "TRACK SECTION":
					NS_RapidRouteMenuOption_ByTrackSection(sectionId: objectId1, rapidRouteOption: rapidRouteOption1, clickAcknowledgeIfExists: clickAcknowledgeIfExists, expectedFeedback: expectedFeedback1);
					break;
				default:
					Report.Error(string.Format("Valid object types include 'signal' or 'track section', not '{0}'. Please check bindings and try again.", objectType1));
					return;
			}

			// TODO: Check feeedback

			switch (objectType2.ToUpper())
			{
				case "SIGNAL":
					NS_RapidRouteMenuOption_BySignal(signalId: objectId2, rapidRouteOption: rapidRouteOption2, clickAcknowledgeIfExists: clickAcknowledgeIfExists, expectedFeedback: expectedFeedback2);
					break;
				case "TRACK SECTION":
					NS_RapidRouteMenuOption_ByTrackSection(sectionId: objectId2, rapidRouteOption: rapidRouteOption2, clickAcknowledgeIfExists: clickAcknowledgeIfExists, expectedFeedback: expectedFeedback2);
					break;
				default:
					Report.Error(string.Format("Valid object types include 'signal' or 'track section', not '{0}'. Please check bindings and try again.", objectType2));
					return;
			}

			// TODO: Add logic to exit on fail

			if (transmit)
			{
				//NS_TerritoryTransfer.NS_TransmitControlRequestList();				
				Tracklinerepo.Trackline_Form.RibbonMenu.Transmit.DoubleClick();
			}
			return;

		}

		[UserCodeMethod]
		public static void NS_RapidRouteMenuOption_BySignal(string signalId, string rapidRouteOption, bool clickAcknowledgeIfExists = true, string expectedFeedback = "")
		{
			Tracklinerepo.LampId = signalId;
			if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
			{
				Report.Error(string.Format("Trackline with signal Id '{0}' not in controlled territories", signalId));
				return;
			}
			
			RepoItemInfo repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo;
			switch (rapidRouteOption.ToUpper())
			{
				case "STACK RR CLEAR":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.StackRRClearInfo;
					break;
				case "RR CLEAR":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.RRClearInfo;
					break;
				case "RR STOP":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.RRStopInfo;
					break;
				case "RR FLEETING":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.RRFleetingInfo;
					break;
				case "RR CANCEL FLEETING":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.RRCancelFleetingInfo;
					break;
				default:
					Report.Error(string.Format("The rapid route menu option '{0}' does not exist. Please check bindings and try again.", rapidRouteOption));
					return;
			}

			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo,
				Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo
			);

			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.SelfInfo, repoMenuOption);

			if (!repoMenuOption.CreateAdapter<Unknown>(true).Enabled)
			{
				Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.Self);
				Report.Error(string.Format("The rapid route menu option '{0}' is disabled for signal id '{1}'.", rapidRouteOption, signalId));
				return;
			}
			
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(repoMenuOption, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo);
			
			// Check feedback
			string actualFeedback = Tracklinerepo.Trackline_Form_By_Signal_Id.Feedback.GetAttributeValue<string>("Text");
			if (GeneralUtilities.CheckFeedbackExists(Tracklinerepo.Trackline_Form_By_Signal_Id.Feedback, expectedFeedback))
			{
				Report.Info("Validation", string.Format("No feedback found, or expected feedback matches actual feedback: '{0}'", actualFeedback));
			} else {
				Report.Failure("Validation", string.Format("Expected feedback: '{0}' does not match actual feedback: '{1}'", expectedFeedback, actualFeedback));
				return;
			}

			// Appears for a subset of rapid route options
			NS_CloseSignalStopFormIfExists_Trackline(clickAcknowledgeIfExists);

			actualFeedback = Tracklinerepo.Trackline_Form_By_Signal_Id.Feedback.GetAttributeValue<string>("Text");
			if (GeneralUtilities.CheckFeedbackExists(Tracklinerepo.Trackline_Form_By_Signal_Id.Feedback, expectedFeedback))
			{
				Report.Info("Validation", string.Format("No feedback found, or expected feedback matches actual feedback: '{0}'", actualFeedback));
			} else {
				Report.Failure("Validation", string.Format("Expected feedback: '{0}' does not match actual feedback: '{1}'", expectedFeedback, actualFeedback));
				return;
			}

			Report.Success(string.Format("The rapid route menu option '{0}' has been clicked successfully.", rapidRouteOption));
		}

		public static void NS_RapidRouteMenuOption_ByTrackSection(string sectionId, string rapidRouteOption, bool clickAcknowledgeIfExists = true, string expectedFeedback = "")
		{
			Tracklinerepo.TrackSectionId = sectionId;
			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
			{
				Report.Error(string.Format("Trackline with signal Id '{0}' not in controlled territories", sectionId));
				return;
			}
			
			RepoItemInfo repoMenuOption = Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo;
			switch (rapidRouteOption.ToUpper())
			{
				case "STACK RR CLEAR":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.StackRRClearInfo;
					break;
				case "RR CLEAR":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.RRClearInfo;
					break;
				case "RR STOP":
					repoMenuOption = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.RRStopInfo;
					break;
				default:
					Report.Error(string.Format("The rapid route menu option '{0}' does not exist. Please check bindings and try again.", rapidRouteOption));
					return;
			}
			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo,
				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo
			);
			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.SelfInfo, repoMenuOption);

			if (!repoMenuOption.CreateAdapter<Unknown>(true).Enabled)
			{
				Report.Screenshot(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.Self);
				Report.Error(string.Format("The rapid route menu option '{0}' is disabled for track section id '{1}'.", rapidRouteOption, sectionId));
				return;
			}
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(repoMenuOption, Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo);
			//Check feedback
			string actualFeedback = Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback.GetAttributeValue<string>("Text");
			if (GeneralUtilities.CheckFeedbackExists(Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback, expectedFeedback))
			{
				Report.Info("Validation", string.Format("No feedback found, or expected feedback matches actual feedback: '{0}'", actualFeedback));
			} else {
				Report.Failure("Validation", string.Format("Expected feedback: '{0}' does not match actual feedback: '{1}'", expectedFeedback, actualFeedback));
				return;
			}
			// Appears for a subset of rapid route options
			NS_CloseSignalStopFormIfExists_Trackline(clickAcknowledgeIfExists);			
			actualFeedback = Tracklinerepo.Trackline_Form.Feedback.GetAttributeValue<string>("Text");
			if (GeneralUtilities.CheckFeedbackExists(Tracklinerepo.Trackline_Form.Feedback, expectedFeedback))
			{
				Report.Info("Validation", string.Format("No feedback found, or expected feedback matches actual feedback: '{0}'", actualFeedback));
			} else {
				Report.Failure("Validation", string.Format("Expected feedback: '{0}' does not match actual feedback: '{1}'", expectedFeedback, actualFeedback));
				return;
			}
			
		}

		public static void NS_CloseSignalStopFormIfExists_Trackline(bool clickAcknowledge)
		{
			if (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Signal_Stop_Confirmation.SelfInfo.Exists(0))
			{
				return;
			}			
			if (clickAcknowledge)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButtonInfo,
					Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Signal_Stop_Confirmation.SelfInfo
				);
			}
			else
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Signal_Stop_Confirmation.CancelButtonInfo,
					Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Signal_Stop_Confirmation.SelfInfo
				);
			}
		}

		public static bool ValidateCursorColor(string cursorColor)
		{
			HashSet<Color> colorsFound = new HashSet<Color>();
            
            //Must use a named color from PDSColors
            Color checkColor = PDS_CORE.Code_Utils.PDSColors.GetColorFromString(cursorColor);
            var MouseImage = Ranorex.Mouse.GetCursorImage();
            colorsFound = GeneralUtilities.GetColorsFromBitmap(MouseImage, 1 , 1);
            
            int colorsInMouse = colorsFound.Count;
            if (colorsFound.Contains(checkColor))
            {
                return true;
            }
            else
            {
                return false;
            }
		}
		
		/// <summary>
		/// Right clicks train on trackline and start Train Trace on or off
		/// </summary>
		/// <param name="trainSeed">Input:Trainseed</param>
		/// <param name="tracemodeOn">Input:tracemodeOn</param>
		/// <param name="expectedFeedback">Input:expectedFeedback</param>
		[UserCodeMethod]
		public static void NS_TrainTraceMode_Trackline(string trainSeed, bool tracemodeOn, string expectedFeedback)
		{
			RepoItemInfo trainObject;
			RepoItemInfo traceMode;
			
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			Tracklinerepo.TrainId = trainId;

			if (trainId == null)
			{
				Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
				return;
			}
			
			MakeTrainVisibleOnTrackline(trainSeed);
			
			if(Tracklinerepo.Trackline_Form_By_Train_Id.MenuTrainObjectInfo.Exists(0))
			{
				trainObject = Tracklinerepo.Trackline_Form_By_Train_Id.MenuTrainObjectInfo ;
				
			}
			else
			{
				trainObject = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo;
			}
			
			if (tracemodeOn)
			{
				traceMode = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.TrainTraceOnInfo;
			}
			else
			{
				traceMode = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.TrainTraceOffInfo;
			}
			
			GeneralUtilities.RightClickAndWaitForWithRetry(trainObject, Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo);
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(traceMode, Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo);

			string actualFeedback = Tracklinerepo.Trackline_Form_By_Train_Id.Feedback.GetAttributeValue<string>("Text");
			if (GeneralUtilities.CheckFeedbackExists(Tracklinerepo.Trackline_Form_By_Train_Id.Feedback, expectedFeedback))
			{
				Report.Info("Validation", string.Format("No feedback found, or expected feedback matches actual feedback: '{0}'", actualFeedback));
			}
			else
			{
				Report.Failure("Validation", string.Format("Expected feedback: '{0}' does not match actual feedback: '{1}'", expectedFeedback, actualFeedback));
				Report.Screenshot(Tracklinerepo.Trackline_Form.Self);
				return;
			}

			Report.Success("Train Trace Mode has been Set for Train {"+trainId+"}");
			return;
		}
    }

    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Trackline_Validations
    {
    	public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
    	public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;


    	/// <summary>
    	/// Validates that a particular train is currently sitting on a red trackline occupancy
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainOnAnOccupancy(string trainSeed)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline. Not on occupancy");
    			return;
    		}
    		string TrackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
    		VMEnvironment vm = VMEnvironment.Instance();
    		Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);
    		string trackSectionId = TDMSDb.GetSectionIdfromAssociatedTrackLabel(TrackLabelId);
    		if (trackSectionId == "")
    		{
    			return;
    		}

    		Tracklinerepo.TrackSectionId = trackSectionId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.TrackSectionObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Cannot find Track Section with Id {"+trackSectionId+"} on Trackline with Train {"+trainId+"}");
    			return;
    		}
    		//As of this moment, validating by color seems to be the best option as ui elements don't say when they're occupied
    		//Necessary database data will be in Versant.
    		Tracklinerepo.Trackline_Form_By_Train_Id.Self.EnsureVisible();
    		Ranorex.Adapter TrainSectionElement = Tracklinerepo.Trackline_Form_By_Train_Id.TrackSectionObject;
    		bool success = PDS_CORE.Code_Utils.GeneralUtilities.CheckTrackSectionAdapterForOccupancy(TrainSectionElement, true);
    		if (success)
    		{
    			Ranorex.Report.Success("Occupancy was found under train {"+trainId+"} on track section {"+trackSectionId+"}");
    		} else {
    			Ranorex.Report.Failure("Occupancy was not found under train {"+trainId+"} on track section {"+trackSectionId+"}");
    		}
    		return;
    	}

    	/// <summary>
    	/// Validates that a Train is in the Departure List
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainInDepartureList(string trainSeed,string trackSection)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
    			return;
    		}
    		//Category Description of element contains whether it is in the departure list or on track
    		bool tracklineTrainCategory = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<bool>("DisplayableDepartureTrains");
    		if (tracklineTrainCategory)
    		{
    			Ranorex.Report.Success("Train {"+trainId+"} found in Departure List");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} not found in Departure List");
    		}
    		if(!string.IsNullOrEmpty(trackSection))
    		{
    			VMEnvironment vm = VMEnvironment.Instance();
    			Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);
    			string TrackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
    			string trackSectionId = TDMSDb.GetSectionIdfromAssociatedTrackLabel(TrackLabelId);
    			
    			if(trackSectionId== trackSection)
    			{
    				Ranorex.Report.Success("Train found at trackSectionId {"+trackSectionId+"} matches with TrackSection {"+ trackSection+"}");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Train found at trackSectionId {"+trackSectionId+"} does not matches with TrackSection {"+ trackSection+"}");
    			}
    		}
    	}


    	/// <summary>
    	/// Validates a signal is in the state of stop or proceed by color
    	/// </summary>
    	/// <param name="signalId">Input:Signal Id to Validate</param>
		/// <param name="validateSignalClear">Input:validateSignalClear</param>
    	[UserCodeMethod]
    	public static void NS_ValidateStateOfSignal(string signalId, bool validateSignalClear)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;
    		}

    		if (validateSignalClear)
    		{
    			PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true);
    		} else {
    			PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", false);
    		}
//    		bool signalClear = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true);
//    		if (validateSignalClear != signalClear)
//    		{
//    			if (validateSignalClear)
//    			{
//    				Ranorex.Report.Failure("Signal {"+signalId+"} found not to be clear");
//    			} else {
//    				Ranorex.Report.Failure("Signal {"+signalId+"} found to be clear");
//    			}
//    		} else {
//    			if (validateSignalClear)
//    			{
//    				Ranorex.Report.Success("Signal {"+signalId+"} found to be clear");
//    			} else {
//    				Ranorex.Report.Success("Signal {"+signalId+"} found not to be clear");
//    			}
//    		}
    		return;
    	}

    	/// <summary>
		/// Clear the signal
    	/// </summary>
    	/// <param name="signalId">Input:Signal ID to clear</param>
        /// <param name="Transmit">Input:Transmit as True</param>
		/// <param name="expectedFeedback">Input: expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_ClearSignal(string signalId, bool Transmit,string expectedFeedback = null)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;
    		}
    		Ranorex.Report.Success("Found signal with signal id {"+signalId+"} on one of the open trackline");

    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.ClearInfo);
    		Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Clear.Click();

    		Ranorex.Delay.Milliseconds(500); // Smallest of delays for error message to appear.
			string feedback = Tracklinerepo.Trackline_Form_By_Signal_Id.Feedback.TextValue.ToString();

    		if (!string.IsNullOrEmpty(expectedFeedback))
			{
				Ranorex.Report.Info("TestStep", "Checking feedback from clearing signal");
				Ranorex.Report.Info(string.Format("Actual feedback: '{0}'", feedback));
				if (feedback.Contains(expectedFeedback))
				{
					Ranorex.Report.Success(string.Format("Feedback includes '{0}'", expectedFeedback));
				}
				else
				{
					Ranorex.Report.Error(string.Format("Feedback does not include '{0}' as expected", expectedFeedback));
				}				
			}    		    		

    		if (Transmit)
    		{
    			Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();

        		int iterations = 0;
            	int maxIterations = 20;
            	Ranorex.Delay.Milliseconds(500);
              	Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.Click();
            	while(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations) {
            		Ranorex.Delay.Seconds(1);
            		iterations++;
            	}
            	if (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking")) {
            		Ranorex.Report.Error("Signal did not stop blinking within "+maxIterations.ToString()+" seconds for switch "+Tracklinerepo.SwitchId+". System may be slow or Transmit was not pressed");
            	}

        		if (!PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true)){
        			Ranorex.Report.Error("Signal did not clear");
        		}else {
        			Ranorex.Report.Success("Signal cleared successfully");
        		}
    		}
			return;
    	}

        /// <summary>
        /// This method is to click on Clearing the transmit list operations for trackline
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClearTransmitList()
        {
        	if(Tracklinerepo.Trackline_Form.Self.EnsureVisible())
			{
        		Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.ClearTransmitList.Click();
        	} else
        	{
        		Ranorex.Report.Failure("Unable to find ClearList button");
        	}
        }

		 /// <summary>
        /// This method is to click on 'undo the control request' button
        /// </summary>
        /// <param name="expectedFeedback">Expected feedback, if any, as a result of clicking 'undo request' button</param>
        [UserCodeMethod]
        public static void NS_UndoControlRequest(string expectedFeedback = null)
        {
        	if(!Tracklinerepo.Trackline_Form.SelfInfo.Exists())
			{
        		Ranorex.Report.Failure("Unable to find 'undo control request list' button");
        	}

			string feedback = Tracklinerepo.Trackline_Form.Feedback.TextValue.ToString();
			if (!string.IsNullOrEmpty(expectedFeedback))
			{
				if (feedback.Contains(expectedFeedback))
				{
					Report.Success(string.Format("Actual feedback, '{0}', contains expected feedback, '{1}'", feedback, expectedFeedback));
				}
				else
				{
					Report.Error(string.Format("Actual feedback, '{0}', does not contain expected feedback, '{1}'", feedback, expectedFeedback));
				}
			}
        }

		/// <summary>
		/// Validate that all switch options do appear on the context menu, as anticipated
		/// </summary>
		/// <param name="switchId">Input:switchId</param>
		[UserCodeMethod]
		public static void NS_ValidateSwitch_MenuOptions(string switchId)
		{
			Tracklinerepo.SwitchId = switchId;
			GeneralUtilities.RightClickAndWaitForWithRetry(
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo,
				Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.DBPropertiesInfo
			);

			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.DBPropertiesInfo.Exists(0))
			{
				Ranorex.Report.Error(string.Format("Unable to bring up menu options for switch '{0}'", switchId));
				return;
			}

			bool normalExists = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.NormalInfo.Exists(0);
			bool reverseExists = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.ReverseInfo.Exists(0);
			bool offPowerNormalExists = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchNormalInfo.Exists(0);
			bool offPowerReverseExists = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchReverseInfo.Exists(0);

			string normal = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.Normal.Text;
			string reverse = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.Reverse.Text;
			string offPowerNormal = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchNormal.Text;
			string offPowerReverse = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.OffPowerSwitchReverse.Text;

			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.Self);

			// TODO: Encapsulate in loop. I acknowledge this is repetitive. -DK
			if (normalExists)
			{
				Ranorex.Report.Success("Validation", string.Format("'{0}' menu option exists for switch '{1}'", normal, switchId));
			}

			if (reverseExists)
			{
				Ranorex.Report.Success("Validation", string.Format("'{0}' menu option exists for switch '{1}'", reverse, switchId));
			}

			if (offPowerNormalExists)
			{
				Ranorex.Report.Success("Validation", string.Format("'{0}' menu option exists for switch '{1}'", offPowerNormal, switchId));
			}

			if (offPowerReverseExists)
			{
				Ranorex.Report.Success("Validation", string.Format("'{0}' menu option exists for switch '{1}'", offPowerReverse, switchId));
			}

			// Remove switch context menu
			Tracklinerepo.Trackline_Form_By_Switch_Id.Self.Click(Location.UpperLeft);
		}

        /// <summary>
		/// Validation of a Switch Blinking
		/// </summary>
		/// <param name="Switch_Id">ID of the switch that needs to be validate for Blinking</param>
		/// <param name="validateIsBlinking">Boolean</param>
		/// <param name="optionalColor">Input a color if you'd also like to validate color of the switch</param>
        [UserCodeMethod]
        public static void ValidateSwitchBlinking_NS(string Switch_Id, bool validateIsBlinking = true, string optionalColor = null)
        {
           	Tracklinerepo.SwitchId = Switch_Id;
			if (!Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo.Exists(0))
			{
				Ranorex.Report.Error(string.Format("Switch ID '{0}' not found in controlled territories.", Switch_Id));
				return;
			}

			Report.Info(string.Format("Validating that switch '{0}' blinking state is '{1}'", Switch_Id, validateIsBlinking.ToString()));
			int retries = 0;


			// Sorry, Roger. Blinking state takes a while to transition.
			Delay.Seconds(2);
           	bool isBlinking = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking");

           	while ((isBlinking != validateIsBlinking) && retries < 8)
           	{
           		Ranorex.Delay.Milliseconds(250);
           		isBlinking = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject.GetAttributeValue<bool>("Blinking");
           		retries++;
           	}

			string feedback = string.Format("Switch Id '{0}' has blinking state '{1}' where blinking state '{2}' is expected", Switch_Id, isBlinking, validateIsBlinking);
            if(isBlinking == validateIsBlinking)
        	{
               Ranorex.Report.Success(feedback);
        	}
            else
            {
               Ranorex.Report.Failure(feedback);
			   return;
            }

			if (!string.IsNullOrEmpty(optionalColor))
			{
				Report.Info("TestStep", "Checking whether switch contins the color, " + optionalColor);

				bool colorMatch = false;
				for (int i = 0; i < 10; i++)
				{
					if (GeneralUtilities.CheckColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject, optionalColor, true))
					{
						colorMatch = true;
						Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.Self);
						break;
					}

					Delay.Milliseconds(100);
				}
				if (colorMatch)
				{
					Ranorex.Report.Success("Validation", "Switch color matches expected color: " + optionalColor);
				}
				else
				{
					Ranorex.Report.Error("Validation", "Switch color does not match expected color: " + optionalColor);
				}
			}
    	}


		/// <summary>
		/// Validation of a Signal Blinking
		/// </summary>
		/// <param name="Signal_Id">ID of the signal that needs to be validate for blinking</param>
        [UserCodeMethod]
        public static void NS_ValidateSignalBlinking(string Signal_Id)
        {
            Tracklinerepo.LampId = Signal_Id;
			Ranorex.Delay.Seconds(1);
            if(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking"))
        	{
               Ranorex.Report.Success("Signal {"+Signal_Id+"} is Blinking");
        	}
            else
            {
               Ranorex.Report.Failure("Signal {"+Signal_Id+"} does not blinking");
			   return;
            }

    	}

        /// <summary>
		/// Validate given track section is blinking
		/// </summary>
		/// <param name="trackSectionId">ID of the track section that needs to be validate for blinking</param>
		[UserCodeMethod]
		public static void NS_ValidateTrackBlinking(string trackSectionId, string color, bool blinking)
		{
		    Tracklinerepo.TrackSectionId = trackSectionId;
		    bool result = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject.GetAttributeValue<bool>("Blinking");
		    if(blinking && result)
		    {
		        Ranorex.Report.Success("Track section {"+trackSectionId+"} is Blinking.");
		    }
		    else if (blinking && !result)
		    {
		        Ranorex.Report.Error("Track section {"+trackSectionId+"} is not blinking.");
		    }
		    else if (!blinking && !result)
		    {
		        Ranorex.Report.Success("Track section {"+trackSectionId+"} is not blinking.");
		    }
		    else
		    {
		        Ranorex.Report.Error("Track section {"+trackSectionId+"} is blinking.");
		    }
		    if (!string.IsNullOrEmpty(color))
		    {
		        Report.Info("TestStep", "Checking whether TrackSection contins the color, " + color);
		        bool colorMatch = false;
		        for (int i = 0; i < 10; i++)
		        {
		            if (GeneralUtilities.CheckColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject, color, true))
		            {
		                colorMatch = true;
		                break;
		            }

		            Delay.Milliseconds(100);
		        }
		        if (colorMatch)
		        {
		            Ranorex.Report.Success("Validation", "TrackSection color matches expected color: " + color);
		        }
		        else
		        {
		            Ranorex.Report.Failure("Validation", "TrackSection color does not match expected color: " + color);
		        }
		    }

		}

        /// <summary>
		/// Validate any type Tag color
		/// <param name="objectType">Input: ObjectType like Tracksection, Signal and Switch to validate</param>
		/// <param name="objectIDs">Input: objectIDs refers to Tracksection ID, signal id and switch id to validate</param>
		/// <param name="color">Input: Color refers to validate tag color</param>
		/// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTracklineObjectColor(string objectType, string objectIDs, string color)
        {
        	bool result = false;
        	string[] objects = objectIDs.Split('|');

            foreach(string objectId in objects)
            {
        	    /// Checks for relevant ObjectType
        	    if(objectType.ToUpper().Equals("TRACKSECTION"))
        	    {
        		    Tracklinerepo.TrackSectionId = objectId;
        		    result = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject, color, true);
        	    }
        	    else if (objectType.ToUpper().Equals("SIGNAL"))
        	    {
				    Tracklinerepo.LampId = objectId;
        		    result = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, color, true);
        	    }
        	    else if (objectType.ToUpper().Equals("SWITCH"))
        	    {
				    Tracklinerepo.SwitchId = objectId;
        		    result = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObject, color, true);
        	    }
        	    else if (objectType.ToUpper().Equals("SWITCH HEATER"))
        	    {
				    Tracklinerepo.SwitchHeaterId = objectId;
        		    result = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form.SwitchHeaterObject, color, true);
        	    }
        	    else
        	    {
        		    Ranorex.Report.Failure("ObjectType is not valid");
        	    }
            }
        	if(result)
        	{
        		Ranorex.Report.Success(objectType + ": Trackline tag color of " +color+ " is found as expected");
        	}
        	else
        	{
        		Ranorex.Report.Failure(objectType + ": Trackline tag color of " +color+ " is not found as expected");
        	}
        }

        /// <summary>
		/// Validate tagname on trackline section
		/// <param name="tagName">Input:tagname to check tagname is exists or not</param>
		/// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTagName(string tagName)
        {
        	Tracklinerepo.TagName = tagName;
        	if(Tracklinerepo.Trackline_Form_By_TrackSection_Id.Tags.TrackSectionTagObject.EnsureVisible())
        	{
        	  	   Ranorex.Report.Success("{"+tagName+"} : TagName is found");
        	}
        	else
        	{
        		  Ranorex.Report.Failure("{"+tagName+"} : TagName is not found");
        	}
        }

        /// <summary>
		/// Validates a train is not on any open trackline
		/// <param name="trainSeed">Input:Trainseed of train to validate not on track</param>
		/// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTrainNotOnTracklineFunction(string trainSeed)
        {
        	string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;

    		if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} found on trackline");
    			return;
    		}

    		Ranorex.Report.Success("Train {"+trainId+"} not found on trackline");
    		return;
        }

        /// <summary>
		/// Validates a train is  on any open trackline
		/// <param name="trainSeed">Input:Trainseed of train to validate on track</param>
		/// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTrainOnTracklineFunction(string trainSeed)
        {
        	string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;

    		if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Success("Train {"+trainId+"} found on trackline");
    			return;
    		}

    		Ranorex.Report.Failure("Train {"+trainId+"} not found on trackline");
    		return;
        }


		/// <summary>
		/// Transmit signal on trackline
		/// </summary>
		/// <param name="signalId">Input:Signal ID to Transmit</param>
        [UserCodeMethod]
        public static void NS_TransmitSignalFunction(string signalId)
        {

        	Tracklinerepo.LampId = signalId;
        	if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
        		return;
        	}

        	Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();

        	return;

        }

        /// <summary>
        /// Validate OR 192 box appears following PSS request from user.
        /// </summary>
        /// <param name="signalId">Input:signalId</param>
        /// <param name="confirmationBoxAppears">Input:confirmationBoxAppears</param>
		[UserCodeMethod]
		public static void NS_PSS_ValidateConfirmationBoxExists(string signalId, bool confirmationBoxAppears = true)
        {
        	Tracklinerepo.LampId = signalId;

        	string operatingRule = "NS Operating Rule 277";

			// Wait for confirmation form to appear.
			int retries = 0;
			bool formExists = false;
			while (!formExists && retries < 6)
			{
				formExists = Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.YesButtonInfo.Exists(0);
				Ranorex.Delay.Milliseconds(250);
				retries++;
			}
			// Exit function if the confirmation form does not exist.
			string feedback = string.Format("Confirmation prompt for '{0}' expected result: '{1}', actual result: '{2}'", operatingRule, confirmationBoxAppears, formExists);
			if (formExists != confirmationBoxAppears)
			{
				Report.Failure("Validation", feedback);
				Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Permission_To_Pass_Stop.Self);
			} else {
				Report.Success("Validation", feedback);
			}
        }


        /// <summary>
        /// validate train on trackline
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="trackSection">Input:trackSection</param>
        [UserCodeMethod]
       public static void NS_ValidateTrainOnTrackSection(string trainSeed, string trackSection)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
        	if (trainId == null)
        	{
        		Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
        		return;
        	}

        	Tracklinerepo.TrainId = trainId;

        	if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
        		return;
        	}

        	VMEnvironment vm = VMEnvironment.Instance();
        	Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);

        	string TrackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
        	string trackSectionId = TDMSDb.GetSectionIdfromAssociatedTrackLabel(TrackLabelId);
        	
        	if (trackSectionId != trackSection)
        	{
        		Ranorex.Report.Failure("Train {"+ trainId+"} not found at track section {"+ trackSection+"} and instead found at track section {"+ trackSectionId+"}");
        	} else {
        		Ranorex.Report.Success("Train {"+ trainId+"}found at track section {"+ trackSection+"}");
        	}

        	return;
        }

         /// </summary> Clear Signal by Fleeting </summary>
    	/// <param name="signalId">Input:Signal ID to fleeting signal</param>
        /// <param name="Transmit">Input:Transmit as True for Transmit Signal </param>
    	[UserCodeMethod]
    	public static void NS_FleetingSignal(string signalId, bool Transmit)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;

    		}

    		PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.FleetingInfo);
    		Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Fleeting.Click();

    		if(Transmit)
    		{
    			int retries = 0;
    			Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();
    			while(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
				
    			Delay.Seconds(5);
    			if (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking"))
    			{
    				Ranorex.Report.Error("Fleeting Signal did not stop blinking");
    			}

    			if (PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true))
    			{
    				Ranorex.Report.Info("Fleeting Signal cleared successfully");
    			}
    			else
    			{
    				Ranorex.Report.Error("Fleeting Signal did not clear");
    			}

    		}

        }

		 /// <summary>
        /// Open and closes the convert to Train form
        /// </summary>
         [UserCodeMethod]
         public static void NS_OpenandCloseConvertToTrainForm()
         {
         	Tracklinerepo.TrainId= @"\?";
         	//opens convert to Train form
         	Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
         	// Click on convert to train
         	Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.ConvertToTrain.Click();
         	Ranorex.Report.Info("Convert to Train form has opened successfully");

         	//Click on cancel button to close the form
         	Tracklinerepo.Trackline_Form_By_Train_Id.TracklineGeneratedForms.Pseudo_Train_Objects.CancelButton.Click();
         	Ranorex.Report.Info("Convert to Train form has been closed successfully");
         }

		/// <summary>
    	/// Validates that a pseudo train is exists or not on red trackline
    	/// </summary>
    	/// <param name="validateExists">Input:if true, validates pseudo train exists, if false, validates pseudo train doesn't exist</param>
    	[UserCodeMethod]
    	public static void NS_ValidatePseudoTrainOnAnOccupancy(bool validateExists)
    	{
    		Tracklinerepo.TrainId = @"\?";
    		if (validateExists)
    		{
    			if(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		    {
    			     Ranorex.Report.Success("Pseudo train appears on the trackline");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Pseudo train does not appear on the trackline");
    			}

    		}
    		else
    		{
    			if(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		    {
    				Ranorex.Report.Failure("Pseudo train appears on the trackline");
    			}
    			else
    			{
    				Ranorex.Report.Success("Pseudo train does not appear on the trackline");
    			}
    		}
    	}


    	 /// <summary>
        /// Open and closes the convert to Train form
        /// <param name="trainSeed">Input:trainSeed</param>
		/// </summary>
         [UserCodeMethod]
         public static void NS_ConvertPseudoTrainToTrain(string trainSeed)
         {
         	string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);

			Tracklinerepo.TrainId = @"\?";
			//opens convert to Train form
             Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);

             // Click on convert to train
             Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.ConvertToTrain.Click();
             Ranorex.Report.Info("Convert to Train form has opened successfully");

             //Enter the Train ID
             Tracklinerepo.Trackline_Form_By_Train_Id.TracklineGeneratedForms.Pseudo_Train_Objects.TrainidText.Click();
             Tracklinerepo.Trackline_Form_By_Train_Id.TracklineGeneratedForms.Pseudo_Train_Objects.TrainidText.Element.SetAttributeValue("Text",trainId);
             Tracklinerepo.Trackline_Form_By_Train_Id.TracklineGeneratedForms.Pseudo_Train_Objects.TrainidText.PressKeys("{TAB}");
             Tracklinerepo.Trackline_Form_By_Train_Id.TracklineGeneratedForms.Pseudo_Train_Objects.OkButton.Click();
             //Validating
             Delay.Milliseconds(5000);
             if(!Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
                 {
                    Ranorex.Report.Success("Convert PseudoTrain to Train  has been done successfully");
             	 }
             else
         		{
                    Ranorex.Report.Failure("Convert PseudoTrain to Train  has been Failed");

             	}
         }

         /// <summary>
         /// Open and closes the convert to Train form
         /// <param name="borderTrafficId">Input:borderTrafficId</param>
         /// <param name="transmit">Input:Transmit as True</param>
         /// </summary>
         [UserCodeMethod]
         public static void NS_SetBorderTrafficInBound(string borderTrafficId,bool transmit)
         {
         	Tracklinerepo.BorderTrafficId=borderTrafficId;
         	if(Tracklinerepo.Trackline_Form.BorderTrafficObjectInfo.Exists(0))
         	{
         		Tracklinerepo.Trackline_Form.BorderTrafficObject.Click(WinForms.MouseButtons.Right);
         		Tracklinerepo.Trackline_Form.BorderTrafficObjectMenu.BorderTrafficInBound.Click();


         		if (transmit)
         		{

         			int iterations = 0;
         			int maxIterations = 30;

         			Tracklinerepo.Trackline_Form.RibbonMenu.Transmit.Click();
         			//verifying whether it is transmitted or not
         			while(Tracklinerepo.Trackline_Form.BorderTrafficObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations)
         			{
         				Ranorex.Delay.Seconds(1);
         				iterations++;
         			}
         			if (Tracklinerepo.Trackline_Form.BorderTrafficObject.GetAttributeValue<bool>("Blinking"))
         			{
         				Ranorex.Report.Error("Border Traffic did not stop blinking within "+maxIterations.ToString()+" seconds for switch "+Tracklinerepo.BorderTrafficId+". System may be slow or Transmit was not pressed");
         			}

         			else
         			{
         				Ranorex.Report.Success("Border Traffic cleared successfully for the ID : " +borderTrafficId);
         			}
         		}
         	}
         	else
         	{
         		Ranorex.Report.Failure("BorderTrafficObject doesn't exist for the ID : " +borderTrafficId);
         	}

         }


         /// <summary>
    	/// Restart All Tracklines
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_RestartAllTracklines()
		{
			if (!Tracklinerepo.Trackline_Form.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Trackline is not open");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.MainMenuBar.FileButtonInfo,Tracklinerepo.Trackline_Form.FileMenu.RestartAllTracklinesInfo);
			Tracklinerepo.Trackline_Form.FileMenu.RestartAllTracklines.Click();

			int retries = 0;
			while (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Hard_Trackline_Reset.OkButtonInfo.Exists(0) && retries < 3)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}

			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Hard_Trackline_Reset.OkButton.Click();

			if (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Hard_Trackline_Reset.OkButtonInfo.Exists(0))
			{
				Ranorex.Report.Info("Sucessfully restart all trackline window");
				return;
			}

			Ranorex.Report.Error("Unable to restart all trackline window");
    		return;

    	}

 		/// <summary>
    	/// Acknowledge Stacked Route Overlap DraZone Popup
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_AcknowledgeStackedRouteOverlapDraZonePopup()
		{
			if (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.StackedRoute_Overlap_DeMinimis_Zone_Popup.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Stacked Route Overlap DraZone Popup is not displayed");
				return;
			}


			//Click Acknowledge button and retry until popup is exists
    		int retries = 0;
			while(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.StackedRoute_Overlap_DeMinimis_Zone_Popup.SelfInfo.Exists(0) && retries < 4)
			{

				GeneralUtilities.clickItemIfItExists(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.StackedRoute_Overlap_DeMinimis_Zone_Popup.AcknowledgeInfo);
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}


			if (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.StackedRoute_Overlap_DeMinimis_Zone_Popup.AcknowledgeInfo.Exists(0))
			{
				Ranorex.Report.Error("Unable to Acknowledge Stacked Route Overlap DraZone Popup");
				return;
			}
			else
			{
				Ranorex.Report.Info("Acknowledge Stacked Route Overlap DraZone Popup");
				return;
			}

    	}


    	 /// <summary>
        /// Get the trackline object associated with the tdmsID
        /// </summary>
        /// <param name="signalID">TDMS Lamp ID that of intended signal to clear ex. 904305</param>

        public static void FindSignalByDeviceId_ClickStackRRClear(string signalId)
        {

			Tracklinerepo.LampId = signalId;

			if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;

    		}
			if(signalId != null)
			{
				GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.SelfInfo);
	    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.SelfInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.StackRRClearInfo);
	    		Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.StackRRClear.Click();
	    		Ranorex.Report.Info("Clicked Stack RR clear menu");
			}
			else
			{
				Ranorex.Report.Error("Not able to click Stack RR clear menu");
			}
        }


    	 /// </summary> Clear Signal by StackRR Clear </summary>
    	/// <param name="entrySignalId">Input:entrySignalId for first signal </param>
    	/// <param name="exitSignalId">Input:exitSignalId for second signal </param>
        /// <param name="Transmit">Input:Transmit as True for Transmit Signal </param>
    	[UserCodeMethod]
    	public static void NS_StackRRClearSignal(string entrySignalId, string exitSignalId, bool Transmit)
    	{

    		FindSignalByDeviceId_ClickStackRRClear(entrySignalId);
    		Delay.Seconds(2);
    		FindSignalByDeviceId_ClickStackRRClear(exitSignalId);
    		int retries = 0;
    		if(Transmit)
    		{
    			Tracklinerepo.LampId = entrySignalId;
    			Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();
    			while(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}

    			if (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking"))
    			{
    				Ranorex.Report.Error("Stack RR signal did not stop blinking");
    			}
    			else
    			{
    				Ranorex.Report.Info("Stack RR signal cleared successfully");

    			}
    		}

    	}

    	/// <summary>
    	/// Get the trackline object associated with the tdmsID
    	/// </summary>
    	/// <param name="signalID">TDMS Lamp ID that of intended signal to Stop </param>
    	[UserCodeMethod]
    	public static void FindSignalByDeviceId_ClickRRStop(string signalId)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;
    		}
    		else
    		{
    			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo,
    			                                               Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.SelfInfo);
    			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.SelfInfo,
    			                                               Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.RRStopInfo);
    			Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.RR.RRStop.Click();
    			if (Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButtonInfo.Exists(0))
    			{
    				Tracklinerepo.Trackline_Form_By_Signal_Id.TracklineGeneratedForms.Signal_Stop_Confirmation.AcknowledgeButton.Click();
    			}
    			else
    			{
    				Report.Error("Acknowlegement button has not appeared for stop signal");
    			}
    		}
    	}

    	/// </summary> Stop Signal by RR Stop </summary>
    	/// <param name="entrySignalId">Input:entrySignalId for first signal </param>
    	/// <param name="exitSignalId">Input:exitSignalId for second signal </param>
    	/// <param name="Transmit">Input:Transmit as True for Transmit Signal </param>
    	[UserCodeMethod]
    	public static void NS_StopSignal_RRStop(string entrySignalId, string exitSignalId, bool Transmit)
    	{
    		FindSignalByDeviceId_ClickRRStop(entrySignalId);
    		FindSignalByDeviceId_ClickRRStop(exitSignalId);
    		if (Transmit)
			{
				int iterations = 0;
				int maxIterations = 20;
				Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.Click();
				Tracklinerepo.LampId = exitSignalId;
				while (Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations)
				{
					Ranorex.Delay.Seconds(1);
					iterations++;
				}
			}
			Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.Self);
			return;
    	}

    	[UserCodeMethod]
    	public static void NS_ValidateOrderOfTrains(string trackSectionId, string trainSeed, string direction, int orderOfTrain, string feedback, bool closeForm = true)
    	{
    		Tracklinerepo.TrackSectionId = trackSectionId;
    		if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.SelfInfo.Exists()) //wasnt already open, open it or at least try to
    		{
    			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo, Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.GetOrderOfTrainsInfo);
    			Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.GetOrderOfTrains.Click();
    		}
    		else
    		{
    			Ranorex.Report.Info("Notice: OOT already open.");
    		}
    		
    		int retry = 0;
    		Ranorex.Delay.Seconds(1); //need to give feedback a buffer, it always exists 
    		//Feel free to change the returns if you find a scenario where  a window opens but produces feedback too
    		if (!feedback.Equals("") && Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback.TextValue.Equals(feedback))
			{
				Ranorex.Report.Success("Feedback {"+feedback+"} present.");
				return;
			}
    		else if (!feedback.Equals("") && !Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback.TextValue.Equals(feedback))
			{
				Ranorex.Report.Failure("Feedback {"+feedback+"} is not present. Feedback = \""+Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback.TextValue+"\".");
				return;
			}
    		else //Not expecting feedback make sure it opened
    		{
    			while (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.SelfInfo.Exists() || retry > 3)
    			{
    				GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo, Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.GetOrderOfTrainsInfo);
    				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.GetOrderOfTrains.Click();
    				retry++;
    				Ranorex.Delay.Seconds(1);
    			}
    			//short circuit last repo lookup, if we didnt reach retry == 4 then it exists, if not do one last check
    			if (retry > 3 && Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.SelfInfo.Exists())
    			{
    				Ranorex.Report.Failure("Order of trains not appearing as expected.");
    				return;
    			}
    		}
			
			//Store train name
			Tracklinerepo.OrderOfTrainsIndex = (orderOfTrain*4 + 1).ToString();
			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.OrderOfTrainsTextByOrderOfTrainsIndexInfo.Exists())
			{
				Ranorex.Report.Failure("Train at order position {"+orderOfTrain+"} does not exist on Order of Trains.");
				return;
			}
			string trainText = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.OrderOfTrainsTextByOrderOfTrainsIndex.TextValue;
			
			//Store train direction
			Tracklinerepo.OrderOfTrainsIndex = Tracklinerepo.OrderOfTrainsIndex+3;
			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.OrderOfTrainsTextByOrderOfTrainsIndexInfo.Exists())
			{
				Ranorex.Report.Failure("Direction at order position {"+orderOfTrain+"} does not exist on Order of Trains.");
				return;
			}
			string directionText = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.OrderOfTrainsTextByOrderOfTrainsIndex.TextValue;
			
			//Validate and report
			if (NS_TrainID.GetTrainId(trainSeed).Equals(trainText))
			{
				Ranorex.Report.Success("{"+trainText+"} is in the expected order {"+orderOfTrain+"} in Order of Trains.");
			}
			else
			{
				Ranorex.Report.Failure("Train for {"+trainSeed+"} is not in the correct position/not present in Order of Trains. Expected position {"+orderOfTrain+"} contains {"+trainText+"}.");
			}
			
			//Validate and report direction
			if (direction.Equals(directionText))
			{
				Ranorex.Report.Success("{"+direction+"} is in the expected order {"+orderOfTrain+"} in Order of Trains.");
			}
			else
			{
				Ranorex.Report.Failure("{"+direction+"} is not in the correct position/not present in Order of Trains. Expected position {"+orderOfTrain+"} contains {"+directionText+"}.");
			}
			
			if (closeForm)
			{
				retry = 0;
				while (Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.SelfInfo.Exists() || retry < 3)
				{
					Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.Self.Click(System.Windows.Forms.MouseButtons.Left, Location.UpperRight);
					retry++;
					Ranorex.Delay.Milliseconds(500);
				}
				
				if (Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Order_Of_Trains_Popup.SelfInfo.Exists())
				{
					Ranorex.Report.Error("Couldn't close Order of Trains");
				}
			}
    	}
//    	
//    	[UserCodeMethod]
//    	public static void NS_ValidateTrainTrace(string trackSectionId, bool painted)
//    	{
//    		Tracklinerepo.TrackSectionId = trackSectionId;
//    		if (Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject.GetAttributeValue
//    	}
    		
    	/// <summary>
		/// Open TrainSheet from trackline
		/// </summary>
		/// <param name="trainSeed">Input trainSeed</param>
    	[UserCodeMethod]
    	public static void NS_OpenTrainSheet_TrackLine(string TrainSeed)
    	{
    		int retries =0;
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(TrainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+TrainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		Tracklinerepo.TrainId = trainId;

    		if (Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo.Exists(0))
    		{
    			Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
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
    		else
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} not found on trackline");
    			return;
    		}
    	}
    	
    	/// <summary>
    	/// Validate the options available in Track section menu is Enabled or Disabled
    	/// </summary>
    	/// <param name="tracksectionIDs">Tracksections to be validated</param>
    	/// <param name="isAutomaticEnabled">Validate Automatic options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isManualEnabled">Validate manual options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isRREnabled">Validate R-R options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isRemoveSignalAuthorityEnabled">Validate removeSignalAuthority options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isPlaceTagEnabled">Validate placeTag options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isIssueTrainOREngineTrackAuthorityEnabled">Validate issueTrainOREngineTrackAuthority options is enabled in Tracksections menu</param>
    	/// <param name="isDBPropertyEnabled">Validate dbProperty options is Enabled or Disabled in Tracksections menu in CTC</param>
    	/// <param name="isGetOrderOfTrainsEnabled">Validate getOrderOfTrains options is Enabled or Disabled in Tracksections menu</param>
    	/// <param name="isPendingActivitySummaryEnabled">Validate pendingActivitySummary options is Enabled or Disabled in Tracksections menu</param>
    	[UserCodeMethod]
    	public static void NS_validateTrackline_MenuOptions_Enabled_or_Disabled(string trackSectionId, string isAutomaticEnabled, string isManualEnabled, string isRREnabled, string isRemoveSignalAuthorityEnabled, string isPlaceTagEnabled, string isIssueTrainOREngineTrackAuthorityEnabled, string isDBPropertyEnabled, string isGetOrderOfTrainsEnabled, string isPendingActivitySummaryEnabled)
    	{
    		string automaticActualValue = "";
    		string manualActualValue = "";
    		string rrActualValue = "";
    		string removeSignalAuthorityActualValue = "";
    		string placeTagActualValue = "";
    		string issueTrainOREngineTrackAuthorityActualValue = "";
    		string dbPropertyActualValue = "";
    		string getOrderOfTrainsActualValue = "";
    		string pendingActivitySummaryActualValue = "";
    		
    		Tracklinerepo.TrackSectionId = trackSectionId;
    		//See if the proper menu opened
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.SelfInfo);
    		if( Tracklinerepo.Trackline_Form.TrackSectionObjectInfo.Exists(0) )
    		{
    			//capturing screenshot
    			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.Self);
    			// Validating Automatic options is Enabled or Disabled in Track object menu
    			if(isAutomaticEnabled != "" )
    			{
    				automaticActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Automatic.Self.Enabled.ToString();
    				if(automaticActualValue.Equals(isAutomaticEnabled))
    				{
    					Report.Success("automatic option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Automatic option is not set as expected");
    				}
    			}
    			
    			// Validating manual options is Enabled or Disabled in Track object menu
    			if(isManualEnabled != "" )
    			{
    				manualActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Manual.Self.Enabled.ToString();
    				if(manualActualValue == isManualEnabled)
    				{
    					Report.Success("Manual option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Manual option is not set as expected ");
    				}
    			}
    			// Validating R-R options is Enabled or Disabled in Track object menu
    			if( isRREnabled != "" )
    			{
    				if(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.SelfInfo.Exists(0))
    				{
    					rrActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RR.Self.Enabled.ToString();
    					if(rrActualValue == isRREnabled)
    					{
    						Report.Success("R-R option is set as expected");
    					}
    					else
    					{
    						Report.Failure("R-R option is not set as expected");
    					}
    				}
    			}
    			// Validating removeSignalAuthority options is Enabled or Disabled in Track object menu
    			if( isRemoveSignalAuthorityEnabled != "" )
    			{
    				removeSignalAuthorityActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RemoveSignalAuthority.Enabled.ToString();
    				if(removeSignalAuthorityActualValue == isRemoveSignalAuthorityEnabled)
    				{
    					Report.Success("Remove Signal Authority option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Remove Signal Authority option is not set as expected");
    				}
    			}
    			// Validating placeTag options is Enabled or Disabled in Track object menu
    			if( isPlaceTagEnabled != "" )
    			{
    				placeTagActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.PlaceTag.Enabled.ToString();
    				if(placeTagActualValue == isPlaceTagEnabled)
    				{
    					Report.Success("Place tag option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Place tag option is not set as expected");
    				}
    			}
    			// Validating issueTrainOREngineTrackAuthority options is Enabled or Disabled in Track object menu
    			if( isIssueTrainOREngineTrackAuthorityEnabled != "" )
    			{
    				issueTrainOREngineTrackAuthorityActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.IssueTrainOrEngineTrackAuthority.Enabled.ToString();
    				if(issueTrainOREngineTrackAuthorityActualValue == isIssueTrainOREngineTrackAuthorityEnabled)
    				{
    					Report.Success("Issue Train OR Engine Track Authority option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Issue train OR Engine Track Authority option is not set as expected");
    				}
    			}
    			// Validating dbProperty options is Enabled or Disabled in Track object menu
    			if( isDBPropertyEnabled != "" )
    			{
    				dbPropertyActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.DBProperties.Enabled.ToString();
    				if(dbPropertyActualValue == isDBPropertyEnabled)
    				{
    					Report.Success("DB Property option is set as expected");
    				}
    				else
    				{
    					Report.Failure("DB Property option is not set as expected");
    				}
    			}
    			// Validating getOrderOfTrains options is Enabled or Disabled in Track object menu
    			if( isGetOrderOfTrainsEnabled != "" )
    			{
    				getOrderOfTrainsActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.GetOrderOfTrains.Enabled.ToString();
    				if(getOrderOfTrainsActualValue == isGetOrderOfTrainsEnabled)
    				{
    					Report.Success("Get order of trains option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Get order of trains option is not set as expected");
    				}
    			}
    			// Validating pendingActivitySummary options is Enabled or Disabled in Track object menu
    			if(isPendingActivitySummaryEnabled != "" )
    			{
    				pendingActivitySummaryActualValue = Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.PendingActivitySummary.Enabled.ToString();
    				if(pendingActivitySummaryActualValue == isPendingActivitySummaryEnabled)
    				{
    					Report.Success("Pending activity summary option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Pending activity summary option is not set as expected");
    				}
    			}
    			// simply cilck on object to close the Trackmenu form
    	        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.ControlPointObjectInfo, Tracklinerepo.Trackline_Form.TrackSectionObjectMenu.SelfInfo);
    		}
    	}
    	
    
    	/// <summary>
    	/// Validate the options available in signal menu is Enabled or Disabled
    	/// </summary>
    	/// <param name="signalIds">signalIds to be validated</param>
    	/// <param name="isClearEnabled">Validate rr options is Enabled or Disabled in signal menu</param>
    	/// <param name="isRREnabled">Validate rr options is Enabled or Disabled in signal menu</param>
    	/// <param name="isSwitchingClearEnabled">Validate switchingClear options is Enabled or Disabled in signal menu</param>
    	/// <param name="isFleetingEnabled">Validate fleeting options is Enabled or Disabled in signal menu</param>
    	/// <param name="isCancelFleetingEnabled">Validate cancel fleeting options is Enabled or Disabled in signal menu</param>
    	/// <param name="isStopEnabled">Validate stop options is Enabled or Disabled in signal menu</param>
    	/// <param name="isPermissionToPassStopEnabled">Validate Permission To Pass Stop options is Enabled or Disabled in signal menu</param>
    	/// <param name="isPlaceTagEnabled">Validate placeTag options is Enabled or Disabled in signal menu</param>
    	/// <param name="isDBPropertyEnabled">Validate dbProperty options is Enabled or Disabled in signal menu</param>
    	[UserCodeMethod]
    	public static void NS_validateSignal_MenuOptions_Enabled_OR_Disabled(string signalId, string isClearEnabled, string isRREnabled, string isSwitchingClearEnabled, string isFleetingEnabled, string isCancelFleetingEnabled, string isStopEnabled, string isPermissionToPassStopEnabled, string isPlaceTagEnabled, string isDBPropertyEnabled)
    	{
    		string clearActualValue = "";
    		string rrActualValue = "";
    		string fleetingActualValue = "";
    		string cancelFleetingActualValue = "";
    		string stopActualValue = "";
    		string permissionToPassStopActualValue = "";
    		string placeTagActualValue = "";
    		string dbPropertiesActualValue = "";
    		
    		Tracklinerepo.LampId = signalId;
    		//See if the proper menu opened
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo);
    		if( Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo.Exists(0) )
    		{
    		    //capturing screenshot
    		    Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Self);
    			// Validating clear options is Enabled or Disabled in signal object menu
    			if( isClearEnabled != "" )
    			{
    				clearActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Clear.Enabled.ToString();
    				if(clearActualValue == isClearEnabled)
    				{
    					Report.Success("Clear option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Clear option is not set as expected");
    				}
    			}
    			// Validating R-R options is Enabled or Disabled in signal object menu
    			if( isRREnabled != "" )
    			{
    				rrActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.RR.Self.Enabled.ToString();
    				if(rrActualValue == isRREnabled)
    				{
    					Report.Success("R-R option is set as expected");
    				}
    				else
    				{
    					Report.Failure("R-R option is not set as expected");
    				}
    			}
    			// Validating switchingClear options is Enabled or Disabled in signal object menu
    			//if( isSwitchingClearEnabled != "" )
    			//{
    			//   			switchingClearActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Enabled.ToString();
    			//    			if(switchingClearActualValue == isSwitchingClearEnabled)
    			//    			{
    			//    				Report.Success("switchingClear option is set as expected");
    			//    			}
    			//    			else
    			//    			{
    			//    				Report.Failure("switchingClear option is not set as expected");
    			//    			}
    			//    		}
    			//}
    			// Validating fleeting options is Enabled or Disabled in signal object menu
    			if( isFleetingEnabled != "" )
    			{
    				fleetingActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Fleeting.Enabled.ToString();
    				if(fleetingActualValue == isFleetingEnabled)
    				{
    					Report.Success("Fleeting option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Fleeting option is not set as expected");
    				}
    			}
    			// Validating CancelFleeting options is Enabled or Disabled in signal object menu
    			if( isCancelFleetingEnabled != "" )
    			{
    				cancelFleetingActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.CancelFleeting.Enabled.ToString();
    				if(cancelFleetingActualValue == isCancelFleetingEnabled)
    				{
    					Report.Success("Cancel fleeting option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Cancel fleeting option is not set as expected");
    				}
    			}
    			// Validating stop options is Enabled or Disabled in signal object menu
    			if( isStopEnabled != "" )
    			{
    				stopActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.Stop.Enabled.ToString();
    				if(stopActualValue == isStopEnabled)
    				{
    					Report.Success("stop option is set as expected");
    				}
    				else
    				{
    					Report.Failure("stop option is not set as expected");
    				}
    			}
    			// Validating PermissionToPassStop options is Enabled or Disabled in signal object menu
    			if( isPermissionToPassStopEnabled != "" )
    			{
    				permissionToPassStopActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.PermissionToPassStop.Enabled.ToString();
    				if(permissionToPassStopActualValue == isPermissionToPassStopEnabled)
    				{
    					Report.Success("PermissionToPassStop option is set as expected");
    				}
    				else
    				{
    					Report.Failure("permissionToPassStop option is not set as expected");
    				}
    			}
    			// Validating placeTag options is Enabled or Disabled in signal object menu
    			if( isPlaceTagEnabled != "" )
    			{
    				placeTagActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.PlaceTag.Enabled.ToString();
    				if(placeTagActualValue == isPlaceTagEnabled)
    				{
    					Report.Success("Place tag option is set as expected");
    				}
    				else
    				{
    					Report.Failure("Place tag option is not set as expected");
    				}
    			}
    			// Validating dbProperty options is Enabled or Disabled in signal object menu
    			if( isDBPropertyEnabled != "" )
    			{
    				dbPropertiesActualValue = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.DBProperties.Enabled.ToString();
    				if(dbPropertiesActualValue == isDBPropertyEnabled)
    				{
    					Report.Success("DB Property option is set as expected ");
    				}
    				else
    				{
    					Report.Failure("DB Property option is not set as expected");
    				}
    			}
    		}
    	}
    	
    	///<summary>
    	/// Validate feedback of Monitor control point communication form
    	/// </summary>
    	/// <param name="ExpectedFeedbackMsg"> Validate feedback message of Monitor control point communication form </param>
    	[UserCodeMethod]
    	public static void NS_Validate_FeedbackMsg_MonitorControlPointCommunicationForm(string expectedFeedbackMsg)
    	{
//    		string actualFeedbackMsg = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.Feedback.GetAttributeValue<string>("Text");
//    		if(expectedFeedbackMsg.Equals(actualFeedbackMsg))
//    		{
//    		   	Report.Success("Expected Feedback message " +expectedFeedbackMsg+ " is displayed");
//    		}
//    		else
//    		{
//    			Report.Failure("Expected Feedback message " +expectedFeedbackMsg+ " is not displayed");
//    		}
    		
    		Regex monitorControlPointCommunicationFormFeedbackMsg = new Regex( expectedFeedbackMsg );
    		string actualFeedbackMsg = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.Feedback.GetAttributeValue<string>("Text");
    		if( monitorControlPointCommunicationFormFeedbackMsg.IsMatch(actualFeedbackMsg) )
    		{
    		   	Report.Success("Expected Feedback message " +expectedFeedbackMsg+ " is displayed");
    		}
    		else
    		{
    			Report.Failure("Expected Feedback message " +expectedFeedbackMsg+ " is not displayed");
    			Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.Self);
    		}
    	}
    	
    	///<summary>
    	/// Validate Monitor control point communication form close
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_Validate_Clear_MonitorControlPointCommunicationTable(bool closeForms)
    	{
    		
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.Self.Rows.Count == 0)
    		{
    		   	Report.Success("Control point communications table is cleared");
    		}
    		else
    		{
    			Report.Failure("Control point communications table is not cleared");
    		}
    		if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.CloseButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.SelfInfo);
				Report.Success("Control point counication form is closed");
			}   		
    	}
    	
    	///<summary>
    	/// Validate Switch direction is Normal or Reverse
    	/// </summary>
    	/// <param name="switchId">Validate the switchId </param>
    	/// <param name="switchDirection"> Validate Switch Normal/Reverse direction</param>
    	[UserCodeMethod]
    	public static void NS_ValidateSwitchDirection(string switchId, string switchDirection )
    	{
    		
    		Tracklinerepo.SwitchId = switchId;
    		Object data = Tracklinerepo.Trackline_Form.SwitchObject.Element.GetAttributeValue("CurrentState");
			Ranorex.Report.Info("Switch Direction:- "+data.ToString());
    		if(data.ToString().Contains(switchDirection))
    		{
    			Report.Success("Switch Direction is as expected " +switchDirection);
    		}
    		else
    		{
    			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.Self);
    			Report.Failure("Switch is not as expected " +switchDirection);
    		}
    	} 
		
    	///<summary>
    	/// Create Permission to enter main Track(EMT)
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed to right click on Train on Trackline.</param>
    	/// <param name="optEngineId">optInput:engineId (ex. NS 501) to fill EngineId In Create permission to Enter Main form if not auto populated.</param>
    	/// <param name="milePost">Input:milePost (ex. 204H)to fill EngineId In Create permission to Enter Main form. </param>
    	/// <param name="optTrack">optInput: optTrack (ex. MAIN 1) to fill Track name In Create permission to Enter Main form if not auto populated.</param>
    	/// <param name="direction">Input:direction (ex.SOUTH,NORTH) to fill EngineId In Create permission to Enter Main form.</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	[UserCodeMethod]
    	public static void NS_IssuePermissionToEnterMainTrack(string trainSeed, string optEngineId, string milePost, string optTrack, string direction, string trackLineWindowName, bool closeForms, string expectedFeedback)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		Tracklinerepo.TrainId = trainId;
    		Tracklinerepo.TracklineWindow = trackLineWindowName;
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}
    		
    		NS_Trackline.MakeTrainVisibleOnTrackline(trainSeed);
    		Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.Click(WinForms.MouseButtons.Right);
    		
    		int attempt=0;
    		while(!Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssuePermissionToEnterMainTrackInfo.Exists(0)&& attempt<3)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			attempt++;
    		}

    		if(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssuePermissionToEnterMainTrackInfo.Exists(0) && 
    		   Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssuePermissionToEnterMainTrack.Enabled)
    		{
    			Ranorex.Report.Info("Issue Permission to Enter Main Track button is displayed.");
    			//Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssuePermissionToEnterMainTrack.Click();
    			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Trackline_Window_Name.TrainObjectMenu.IssuePermissionToEnterMainTrackInfo,
 		                                          Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    		}
    		else
    		{
    			Ranorex.Report.Error("Issue Permission to Enter Main Track button is not present as expected");
    			return;
    		}
    		
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Info("Create Permission to Enter Main Form displayed.");
    			string foundEngineId = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ToEngine.ToEngineText.Text;
    			string foundTrackText =Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Track.TrackText.Text;
    			if(!string.IsNullOrEmpty(optEngineId) && string.IsNullOrEmpty(foundEngineId))
    			{
    				Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ToEngine.ToEngineText.Element.SetAttributeValue("Text", optEngineId);
    			}
    			
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ToEngine.ToEngineText.PressKeys("{TAB}");
    			
    			if(!string.IsNullOrEmpty(milePost))
    			{
    				Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.AtMilepostText.Element.SetAttributeValue("Text", milePost);
    				Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.AtMilepostText.PressKeys("{TAB}");
    			}
    			else
    			{
    				Report.Failure("Please provide milepost value for Permission to enter at field.");
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    				return;
    			}
    			if (!NS_Authorities.CheckFeedback(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Feedback, expectedFeedback))
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    				return;
    			}
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.AtMilepostText.PressKeys("{TAB}");
    			if (!NS_Authorities.CheckFeedback(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Feedback, expectedFeedback))
    			{
    				
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    				return;
    			}
    			
    			if(!string.IsNullOrEmpty(optTrack))
    			{
    				Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Track.TrackText.Element.SetAttributeValue("Text", optTrack);
    			}
    			
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Track.TrackText.PressKeys("{TAB}");
    			bool isDirectionEnabled = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionMenuButton.Enabled;
    			int retries = 0;
    			if (!isDirectionEnabled)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				while (!isDirectionEnabled && retries < 3)
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}
    			}
    			if (isDirectionEnabled)
    			{
    				if (!string.IsNullOrEmpty(direction))
    				{
    					GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionMenuButtonInfo,
    					                                          Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionTextInfo);
    					if (direction.ToUpper() == "SOUTH")
    					{
    						GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.SouthInfo,
    						                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.ProceedingDirectionListItemByDirectionInfo);
    						Report.Info("Selected Direction value: {" + direction + "}");
    					}
    					else if (direction.ToUpper() == "NORTH")
    					{
    						GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.NorthInfo,
    						                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.ProceedingDirectionListItemByDirectionInfo);
    						Report.Info("Selected Direction value: {" + direction + "}");
    					}
    					else if (direction.ToUpper() == "EAST")
    					{
    						GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.EastInfo,
    						                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.ProceedingDirectionListItemByDirectionInfo);
    						Report.Info("Selected Direction value: {" + direction + "}");
    					}
    					else if (direction.ToUpper() == "WEST")
    					{
    						GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.WestInfo,
    						                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionList.ProceedingDirectionListItemByDirectionInfo);
    						Report.Info("Selected Direction value: {" + direction + "}");
    					}
    					else
    					{
    						Ranorex.Report.Failure("Please provide direction correct value for proceeding field.");
    						return;
    					}
    				}
    				else
    				{
    					Report.Failure("Please provide direction value for proceeding field.");
    					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    					return;
    				}
    			}
    			else
    			{
    				Report.Info("Proceeding field button is disabled in EMT Form");
    				Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionMenuButton);
    			}
    			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.ProceedingDirection.ProceedingDirectionText.PressKeys("{TAB}");
    			Delay.Seconds(1);
    			if (!NS_Authorities.CheckFeedback(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Feedback, expectedFeedback))
    			{
    				
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    				return;
    			}
    			else if(expectedFeedback != "")
    			{
    				Ranorex.Report.Failure("Feedback was expected but none was found.");
    			}
    			if (closeForms)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    				Report.Info("Create Permission to Enter Main form is closed.");
    			}
    			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.OkButtonInfo,
    			                                          Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.SelfInfo);
    			}
    		else
    		{
    			Ranorex.Report.Failure("Create Permission to Enter Main window is not present as expected");
    			return;
    		}
    		
    	}
    	
    	///<summary>
    	/// Validate Permission to Enter Main Track Popup Exist.
    	/// </summary>
    	/// <param name="popupText">Input:popupText to validate.</param>
    	/// <param name="clickYes">Input:clickYes (ex.True or False) to issue Permission to enter main Track.</param>
    	/// <param name="clickNo">Input:clickNo (ex.True or False) to deny Permission to enter main Track. </param>
    	/// <param name="clickCancel">Input: clickCancel (ex.True or False) (X button) to close Popup.</param>
    	[UserCodeMethod]
    	public static void NS_ValidatePermissionToEnterMainTrackPopupExist( bool clickNo, bool clickCancel, bool clickYes, bool closeCreatePermissionForms)
    	{
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.SelfInfo.Exists(0))
    		{
    			string foundPopupText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.RuleOR194Text.TextValue;
    			if(foundPopupText == "Have the conditions specified by NS Operating Rule 194 been met?")
    			{
    				Ranorex.Report.Success("Popup Dialog Box Text found {"+foundPopupText+"} as Expected.");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Popup Dialog Box Text found {"+foundPopupText+"} is NOT as Expected.");
    				return;
    			}
    			
    			if(clickNo)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.NoButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.SelfInfo);
    				Report.Info("Clicked No Button.");
    				
    			}
    			else if(clickCancel)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.WindowControls.CloseInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.SelfInfo);
    				Report.Info("Clicked X Button.");
    				
    			}
    			else if(clickYes)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.YesButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.SelfInfo);
    				Report.Info("Clicked Yes Button.");
    			}
    		}
    		else
    		{
    			Ranorex.Report.Failure("Permission To Enter Main Track Popup Dialog Box NOT Exist.");
    			Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track_Popup.Self);
    		}
    		
    		if(closeCreatePermissionForms)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    			Report.Info("Create Permission to Enter Main form is closed.");
    		}
    		
    	}

    	/// <summary>
    	/// Open EMT from trackline
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="trackSectionId">Input:trackSection</param>
    	[UserCodeMethod]
    	public static void NS_OpenEMTOnTrackSection(string trainSeed, string trackSectionId)
    	{
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Permission to enter mian track details window already open.");
    			return;
    		}
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}

    		Tracklinerepo.TrainId = trainId;

    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
    			return;
    		}
    		
    		string trackLabelId = "";
    		trackLabelId = TDMSEnvironment.GetTrackLabeldfromAssociatedSectionId(trackSectionId);
    		Tracklinerepo.DeviceId = trackLabelId;
    		
    		if (!Tracklinerepo.Trackline_Form.EMTObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Unable to display EMT for this train Id: {"+trainId+"} on Trackline.");
    			return;
    		}
    		
    		Tracklinerepo.Trackline_Form.EMTObject.Click(WinForms.MouseButtons.Right);
    		
    		if(Tracklinerepo.Trackline_Form.EMTObjectMenu.ViewPermissionToEnterMainTrackInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.EMTObjectMenu.ViewPermissionToEnterMainTrackInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    		}
    		else
    		{
    			Ranorex.Report.Failure("Menu Item is not displaed after right click.");
    			return;
    		}
    		
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Success("Permission To Enter Main Track deatils info Dialog Box Opened.");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Permission To Enter Main Track deatils info Dialog Box NOT Opened.");
    			Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.Self);
    		}
    	}
    	
    	/// <summary>
    	/// Void EMT from trackline
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="trackSection">Input:trackSection</param>
    	[UserCodeMethod]
    	public static void NS_VoidEMTFromTrackline(string trainSeed, string trackSectionId)
    	{
    		NS_OpenEMTOnTrackSection(trainSeed, trackSectionId);
    		
    		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Failed to Open EMT Details Forms.");
    			return;
    		}
    		bool isRemoveEnabled = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.RemoveButton.Enabled;
    		if(!isRemoveEnabled)
    		{
    			Ranorex.Report.Failure("Remove Button is Disabled.");
    			return;
    		}
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.RemoveButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    		Report.Success("Successfully Voided EMT.");
    	}
    	
    	/// <summary>
    	/// Validate EMT exists on trackline
    	/// </summary>
    	/// <param name="trainSeed">Input:train Seed for EMT to verify</param>
    	/// <param name="trackSectionId">Input:track Section Id for EMT to verify</param>
    	/// <param name="validateExists">Input:if true, validates it exists, if false, validates it doesn't exist</param>
    	[UserCodeMethod]
    	public static void ValidateEMTOnTrackline(string trainSeed, string trackSectionId, bool validateExists)
    	{
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null)
    		{
    			Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
    			return;
    		}

    		Tracklinerepo.TrainId = trainId;
    		if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
    			return;
    		}

    		string trackLabelId = TDMSEnvironment.GetTrackLabeldfromAssociatedSectionId(trackSectionId);
    		Tracklinerepo.DeviceId = trackLabelId;

    		if(validateExists)
    		{
    			if (Tracklinerepo.Trackline_Form.EMTObjectInfo.Exists(0))
    			{
    				Ranorex.Report.Success("EMT found on trackline for this train {"+trainId+"} ");
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Failure("EMT NOT found on trackline for this train {"+trainId+"} ");
    				return;
    			}
    		}
    		else
    		{
    			if (!Tracklinerepo.Trackline_Form.EMTObjectInfo.Exists(0))
    			{
    				Ranorex.Report.Success("EMT NOT found on trackline for this train {"+trainId+"}");
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Failure("EMT found on trackline for this train {"+trainId+"}");
    				return;
    			}
    		}
    	}
    	
    	
    	/// <summary>
    	/// Validate the options available in Switch Heater menu is Enabled or Disabled
    	/// </summary>
    	/// <param name="deviceId">input:switch heater ID</param>
    	/// <param name="expEnableStatusOfONButton">Validate On options is Enabled or disabled in Switch Heater menu</param>
    	/// <param name="expEnableStatusOfOFFButton">Validate Off options is Enabled or disabled in Switch Heater menu</param>
    	[UserCodeMethod]
    	public static void NS_ValidateSwitchHeaterMenuOptionsEnabled(string deviceId, bool validateMenuOptionsExist)
    	{
    		bool actEnableStatusOfONButton;
    		bool actEnableStatusOfOFFButton;

    		
    		Tracklinerepo.SwitchHeaterId=deviceId;
    		
    		//right click on switch heater
    		Tracklinerepo.Trackline_Form.SwitchHeaterObject.Click(WinForms.MouseButtons.Right, Location.LowerRight);
    		
    		if (Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.SelfInfo.Exists(0))
    		{
    			// Validating On options is Enabled or Disabled in Switch Heater menu
    			actEnableStatusOfONButton  = Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.MenuItemOn.GetAttributeValue<bool>("Enabled");
    			Ranorex.Report.Info(actEnableStatusOfONButton.ToString());
    			
    			if(actEnableStatusOfONButton==validateMenuOptionsExist)
    			{
    				Ranorex.Report.Success("Expected enable status of ON button to be {"+validateMenuOptionsExist+"} and found to be {"+actEnableStatusOfONButton+"}.");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Expected enable status of ON button to be {"+validateMenuOptionsExist+"} but found to be {"+actEnableStatusOfONButton+"}.");
    			}

    			// Validating Off options is Enabled or Disabled in Switch Heater menu
    			actEnableStatusOfOFFButton= Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.MenuItemOff.GetAttributeValue<bool>("Enabled");
    			
    			if(actEnableStatusOfOFFButton== validateMenuOptionsExist)
    			{
    				Ranorex.Report.Success("Expected enable status of ON button to be {"+validateMenuOptionsExist+"} and found to be {"+actEnableStatusOfOFFButton+"}.");
    			}
    			else
    			{
    				Ranorex.Report.Failure("Expected enable status of ON button to be {"+validateMenuOptionsExist+"} but found to be {"+actEnableStatusOfOFFButton+"}.");
    			}
    			// simply cilck on object to close the SwitchHeaterObjectMenu form
               GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.ControlPointObjectInfo,
                                                                 Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.SelfInfo);
    		}
    		else 
    		{
    			Ranorex.Report.Error("Unable to find the Switch Heater, please ensure correct Device Id is provided to validate the menu items");
    		}
    	}
    	
    	/// <summary>
    	/// Void EMT from trackline for Un Controlled Territories
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed</param>
    	/// <param name="trackSection">Input:trackSection</param>
    	/// <param name="expectedFeedback">Input:expectedFeedback</param>
    	/// <param name="closeForms">Input:closeForms</param>
    	[UserCodeMethod]
    	public static void NS_EMT_ValidateRemoveButtonStatus(string trainSeed, string trackSectionId, string expectedFeedback, bool removeEnabled, bool closeForms)
    	{
    		NS_OpenEMTOnTrackSection(trainSeed, trackSectionId);
    		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo.Exists(0))
    		{
    			Report.Failure("Failed to Open EMT Details Forms.");
    			return;
    		}
    		
    		bool isRemoveEnabled = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.RemoveButton.Enabled;
    		
    		if(isRemoveEnabled == removeEnabled)
    		{
    			Report.Success("Verified remove button status as expected enabled: {"+isRemoveEnabled+"}.");
    		}
    		else
    		{
    			Report.Failure("Remove button status NOT as expected enabled: {"+isRemoveEnabled+"}.");
    			Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.Self);
    			return;
    		}

    		if (!NS_Authorities.CheckFeedback(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.Feedback, expectedFeedback))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo,
    			                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    			return;
    		}
    		
    		if(closeForms)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    			Report.Info("Closed EMT details form without void EMT.");
    			return;
    		}
    	}
    	
    	/// <summary>
    	/// Close EMT Details Form.
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_CloseEMTDetailsForm()
    	{
    		int retries = 0;
    		while (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo.Exists(0) && retries < 3)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}
    		
    		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find Close button for EMT Details Form.");
    			return;
    		}
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    		Report.Info("Closed EMT details form.");
    	}
		
		/// <summary>
    	/// Validate the options available in Switch section menu are Enabled or Disabled
    	/// </summary>
    	/// <param name="switchId">SwitchId to be validated</param>
    	/// <param name="enabledMenuOptions">Pass the options name which is expected to be Enabled(e.g. Normal|Reverse|Place Tag) 
    	///                                  and user can keep this param as blank also, If does not want to validate any option as Enabled</param>
    	/// <param name="disabledMenuOptions">Pass the options name which is expected to be disabled(e.g. DB Properties|Move Authority Blocked Switch Normal)
    	///                                   and user can keep this param as blank also, If does not want to validate any option as Disabled</param>
    	[UserCodeMethod]
    	public static void ValidateSwitch_MenuOptions_Enabled_or_Disabled(string switchId, string enabledMenuOptions, string disabledMenuOptions)
    	{
    		bool actMenuOptionExist;
    		bool actEnableStatusOfOption;
    		bool validateOptions = true;
    		string[] enabledMenuOptionsArray = {};
    		string[] disabledMenuOptionsArray = {};
    			
    		//  Assign the swictId to repo variable
    		Tracklinerepo.SwitchId = switchId;
    		
    		if(enabledMenuOptions != "")
    		{
    			enabledMenuOptionsArray = enabledMenuOptions.Split('|');
    		}
    		
    		if(disabledMenuOptions != "")
    		{
    			disabledMenuOptionsArray = disabledMenuOptions.Split('|');
    		}
    		
    		//See if the proper menu opened
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectInfo,
    		                                               Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo);
    		
    		if(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo.Exists(0))
    		{
    			// Validate Enable Options
    			for(int i = 0; i < enabledMenuOptionsArray.Length; i++)
    			{
    				Tracklinerepo.SwitchMenuName = enabledMenuOptionsArray[i];
    				
    				actMenuOptionExist = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByNameInfo.Exists(0);
    				actEnableStatusOfOption = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.Enabled;
    				
    				if(actMenuOptionExist && actEnableStatusOfOption)
    				{
    					Ranorex.Report.Success("Expected enable status of {" +enabledMenuOptionsArray[i]+ "} option to be{True} and found{"+actEnableStatusOfOption+"}.");
    				}
    				else
    				{
    					Ranorex.Report.Failure("Expected enable status of {" +enabledMenuOptionsArray[i]+ "} option to be{True} but found{"+actEnableStatusOfOption+"}.");
    					validateOptions = false;
    				}
    			}
    			
    			// Validate Disable Options
    			for(int j = 0; j < disabledMenuOptionsArray.Length; j++)
    			{
    				Tracklinerepo.SwitchMenuName = disabledMenuOptionsArray[j];
    				
    				actMenuOptionExist = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByNameInfo.Exists(0);
    				actEnableStatusOfOption = Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SwitchMenuItemByName.Enabled;
    				
    				if(actMenuOptionExist && !(actEnableStatusOfOption))
    				{
    					Ranorex.Report.Success("Expected enable status of {" +disabledMenuOptionsArray[j]+ "} option to be{False} and found{"+actEnableStatusOfOption+"}.");
    				}
    				else
    				{
    					Ranorex.Report.Failure("Expected enable status of {" +disabledMenuOptionsArray[j]+ "} option to be{False} but found{"+actEnableStatusOfOption+"}.");
    					validateOptions = false;
    				}
    			}
    			
    			if(!validateOptions)
    			{
    			  Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.Self);
    			}
    			
    			// simply cilck on object to close the SwitchObjectmenu form
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.ControlPointObjectInfo,
    			                                                  Tracklinerepo.Trackline_Form_By_Switch_Id.SwitchObjectMenu.SelfInfo);
    		}
    		else
    		{
    			Report.Failure("Not able to find switch with SwitchId {"+switchId+"} in open Tracklines.");
    		}
    	}

    	/// <summary>
		//// Changes switch direction and validate feedback if any
    	/// </summary>
    	/// <param name="switchDirection">Input:Switch Menu Item</param>
    	/// <param name="switches">Input:Switch or switch Ids separated by pipe delimiter</param>
    	/// <param name="Transmit">Input:Where to transmit after changing the switch direction</param>
        /// <param name="expectedFeedback">Input: expectedFeedback</param>
    	[UserCodeMethod]
    	public static void ChangeSwitchDirection_ValidateFeedback(string switchDirection, string switchId, bool transmit, string expectedFeedback)
    	{
    	    // Assign switchId to repo variable
    		Tracklinerepo.SwitchId = switchId;
    		
    		NS_Trackline.NS_ChangeSwitchDirectionFunction(switchDirection, switchId, transmit);
    		
    		Ranorex.Delay.Milliseconds(500); // Smallest of delays for error message to appear.
			string actualFeedback = Tracklinerepo.Trackline_Form_By_Switch_Id.Feedback.TextValue.ToString();

    		if (!string.IsNullOrEmpty(expectedFeedback))
			{
				Ranorex.Report.Info("TestStep", "Checking feedback while changing switch direction");
				Ranorex.Report.Info(string.Format("Actual feedback: '{0}'", actualFeedback));
				if (actualFeedback.Contains(expectedFeedback))
				{
					Ranorex.Report.Success(string.Format("Feedback includes '{0}'", expectedFeedback));
				}
				else
				{
					Ranorex.Report.Failure(string.Format("Feedback does not include '{0}' as expected", expectedFeedback));
					Report.Screenshot(Tracklinerepo.Trackline_Form_By_Switch_Id.Self);
				}
			}

    	}

    	///<summary>
    	/// Turn On/Off SnowMelter
    	/// </summary>
    	/// <param name="deviceId">Input:Signal ID to clear</param>
    	/// <param name="clickType">Input:clickType for ex: right or left</param>
    	/// <param name="turnOn">Input:turn snow melter on or off</param>
    	/// <param name="transmit">Transmit snow melter on off indications</param>
    	/// <param name="expectDeviceBlink">Expect Snow Melter Blink Input: True or False</param>
    	[UserCodeMethod]
    	public static void NS_TurnOnOffSnowMelter_Trackline(string deviceId, string clickType, bool turnOn, bool transmit, bool expectDeviceBlink)
    	{
    		Tracklinerepo.SwitchHeaterId = deviceId;
    		
    		if (Tracklinerepo.Trackline_Form.SwitchHeaterObjectInfo.Exists(0))
    		{
    			Ranorex.Report.Info("Found Switch Heater with device Id {"+deviceId+"}");
    			if (turnOn)
    			{
    				
    				if (clickType.ToLower() == "right")
    				{
    					//right click on switch heater
    					Tracklinerepo.Trackline_Form.SwitchHeaterObject.Click(WinForms.MouseButtons.Right, Location.LowerRight);
    					Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.MenuItemOn.Click();
    					Ranorex.Report.Info("Switch Heater Turned ON successfully with the right click");
    				}
    				else if(clickType.ToLower() == "left")
    				{
    					//left click on switch heater
    					Tracklinerepo.Trackline_Form.SwitchHeaterObject.Click(WinForms.MouseButtons.Left, Location.LowerLeft);
    					Ranorex.Report.Info("Switch Heater Turned ON successfully with the left click");
    				}
    				else
    				{
    					Ranorex.Report.Error("Invalid Click Type" );
    					
    				}
    			} else {
    				
    				if (clickType.ToLower() == "right")
    				{
    					//right click on switch heater
    					Tracklinerepo.Trackline_Form.SwitchHeaterObject.Click(WinForms.MouseButtons.Right, Location.LowerRight);
    					Tracklinerepo.Trackline_Form.SwitchHeaterObjectMenu.MenuItemOff.Click();
    					Ranorex.Report.Info("Switch Heater Turned Off successfully with the right click");
    				}
    				else if(clickType.ToLower() == "left")
    				{
    					//left click on switch heater
    					Tracklinerepo.Trackline_Form.SwitchHeaterObject.Click(WinForms.MouseButtons.Left, Location.LowerLeft);
    					Ranorex.Report.Info("Switch Heater Turned Off successfully with the left click");
    				}
    				else
    				{
    					Ranorex.Report.Error("Invalid Click Type" );
    					
    				}
    			}
    			
    			int iterations = 0;
    			int maxIterations = 10;
    			if(transmit)
    			{
    				if(clickType.ToLower() == "left")
    				{
    					NS_TerritoryTransfer.NS_TransmitControlRequestList();
    					NS_TerritoryTransfer.NS_CloseControlRequestList();
    				}
    				else
    				{
    					Tracklinerepo.Trackline_Form.RibbonMenu.Transmit.Click();
    				}
    				
    				//verifying whether it is transmitted or not
    				while(Tracklinerepo.Trackline_Form.SwitchHeaterObject.GetAttributeValue<bool>("Blinking") && iterations < maxIterations)
    				{
    					Ranorex.Delay.Seconds(1);
    					iterations++;
    				}
    				
    				bool actualBlinkState = Tracklinerepo.Trackline_Form.SwitchHeaterObject.GetAttributeValue<bool>("Blinking");
    				bool isSnowMelterIndicating = TDMSEnvironment.GetIndicatingStateMiscellaneousDevice(deviceId);
    				
    				//When CDMS flag is set and the state of Indicating snow melter is changed - on/off it continues to blink until external alert message is sent
    				if (isSnowMelterIndicating)
    				{
    					Ranorex.Report.Info("Device is an Indicating Switch Heater");
    					if (expectDeviceBlink == actualBlinkState)
    					{
    						Ranorex.Report.Success("Switch Heater is "+(actualBlinkState ? "Blinking":"Solid") + " as expected");
    					}
    					else{
    						Ranorex.Report.Failure("Switch Heater is "+(actualBlinkState ? "Blinking":"Solid") +" and is not as expected");
    						Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.SwitchHeaterObject.Element);
    					}
    				}
    				else{
    					
    					Ranorex.Report.Info("Device is a Non-Indicating Switch Heater");
    					if(actualBlinkState)
    					{
    						Ranorex.Report.Failure("Switch Heater did not stop blinking within "+maxIterations.ToString()+" seconds for switch heater "+Tracklinerepo.SwitchHeaterId+". System may be slow");
    						Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form.SwitchHeaterObject.Element);
    					}
    					else{
    						Ranorex.Report.Success("Switch Heater turned "+(turnOn ? "on":"off") + " successfully for the ID : " +deviceId);
    					}
    				}
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Switch Heater Object doesn't exist for the ID : " +deviceId);
    		}
    	}

		///<summary>
    	/// Right click on control point and select control point menu options whichever user required
    	/// </summary>
    	/// <param name="deviceName">Input the deviceName </param>
    	/// <param name="controlpointMenuOption">Input control point menu option</param>
    	[UserCodeMethod]
    	public static void NS_SelectControlMenuOption_ControlPoint(string deviceName, string controlpointMenuOption)
    	{
    		Tracklinerepo.ControlPointName = deviceName;
    		Tracklinerepo.ControlPointMenuName = controlpointMenuOption;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find device with device id {"+deviceName+"} on any open trackline");
    			return;
    		}
    		
    		//Click on control point and wait for control point menu appears
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
    		                                               Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);    		
    		int retries = 0;
    		while (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo.Exists(0) && retries < 3)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}

    		if (Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo.Exists(0))
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.ControlPointMenuItemByNameInfo,
    			                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);
    			Report.Success("Clicked on control point menu option: " +controlpointMenuOption);
    		} else {
    			Report.Failure("Invalid device name {"+deviceName+"} control point menu option {"+controlpointMenuOption+"} not clicked");
    			Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.Self);
    		}
    	}	
    	
    	/// <summary>
    	/// Validate indication colour of control point
    	/// </summary>
    	/// <param name="controlPoint">Input: controlPoint (Ex: Grove)</param>
    	/// <param name="color">Input: Color (Ex: Green)</param>
    	[UserCodeMethod]
    	public static void NS_Validate_IndicationColorOfControlPoint(string controlPoint, string color)
    	{
    		Tracklinerepo.ControlPointName = controlPoint;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find Opsta {"+controlPoint+"} on any open trackline");
    			return;
    		}
    		    		
    		if(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo.Exists(0))
    		{
    			if(GeneralUtilities.CheckColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObject, color, true))
    			{
    				Ranorex.Report.Success("Validation", "Opsta color matches expected color: " + color);
    			}
    			else
    			{
    				Ranorex.Report.Failure("Validation", "Opsta color does not match as expected color: " + color);
    				Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.Self);
    			}
    		}
    		else
    		{
    			Ranorex.Report.Failure(" Control point object does not exist to validate color");
    		}
    	}
    	
    	
    	 /// <summary> Cancel Fleeting and transmit</summary>
    	/// <param name="signalId">Input:Signal ID to cancel fleeting</param>
        /// <param name="Transmit">Input:Transmit as True for Transmit</param>
    	[UserCodeMethod]
    	public static void NS_CancelFleetingSignal(string signalId, bool Transmit)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;
    		}

    		PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.CancelFleetingInfo);    		
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.CancelFleetingInfo,
    		                                                  Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo
    		                                                 );

    		if(Transmit)
    		{
    			int retries = 0;
    			Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();
    			while(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && retries < 3)
    			{
    				Ranorex.Delay.Milliseconds(500);
    				retries++;    				
    			}
    			if(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking"))
    			{
    				Ranorex.Report.Error("Signal did not stop blinking");
    			}
    			
    			if (PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject, "Green", true))
    			{
    				Ranorex.Report.Info("Cancel Fleeting signal successfully");
    			}
    			else
    			{
    				Ranorex.Report.Error("Cancel Fleeting did not clear");
    			}
    		}
    	}
    	
    	
    	 /// <summary> Switching clear and transmit</summary>
    	/// <param name="signalId">Input:Signal ID to switch clear</param>
        /// <param name="Transmit">Input:Transmit as True for Transmit</param>
    	[UserCodeMethod]
    	public static void NS_SwitchingClear_Signal(string signalId, bool Transmit)
    	{
    		Tracklinerepo.LampId = signalId;
    		if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
    			return;
    		}

    		PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo, Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SwitchingClearInfo);
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SwitchingClearInfo,
    		                                                  Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo
    		                                                 );
    		if(Transmit)
    		{
    			int retries = 0;
    			Tracklinerepo.Trackline_Form_By_Signal_Id.RibbonMenu.Transmit.DoubleClick();
    			while(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking") && retries < 20)
    			{
    				Ranorex.Delay.Milliseconds(1000);
    				retries++;
    			}
    			
    			if(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObject.GetAttributeValue<bool>("Blinking"))
    			{
    				Ranorex.Report.Error("Signal did not stop blinking");
    			}
    			
    			Ranorex.Report.Info("Switching clear has done successfully");
    		}
    	}
    	
    	 /// <summary> Validate clear option not present under signal object menu</summary>
    	/// <param name="signalId">Input:Signal ID to switch clear</param>
        /// <param name="expClearIsPresent">Input:expClearIsPresent as True for Clear option present</param>
        [UserCodeMethod]
        public static void NS_Validate_ClearOptionIsNotPresent_Trackline(string signalId, bool expClearIsPresent)
        {
        	Tracklinerepo.LampId = signalId;
        	if (!Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Could not find signal with signal id {"+signalId+"} on any open trackline");
        		return;
        	}
        	PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectInfo,
        	                                                                   Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.SelfInfo);
        	
        	bool actClearIsPresent = Tracklinerepo.Trackline_Form_By_Signal_Id.SignalObjectMenu.ClearInfo.Exists(0);
        	
        	if(actClearIsPresent == expClearIsPresent)
        	{
        		Report.Success("Clear option expected exist status to be{"+expClearIsPresent+"} and found{" +actClearIsPresent+ "}.");
        	}
        	else
        	{
        		Report.Failure("Clear option expected exist status to be{"+expClearIsPresent+"} but found{" +actClearIsPresent+ "}.");
        	}
        }
        
        
         ///<summary>
    	/// Validate records in monitor control point communication form
    	/// </summary>
    	/// <param name="type">Input:type (ex: I or C or R)</param>
    	/// <param name="atcsAddress">Input:Address of the contorl point 550264012</param>
    	/// <param name="bitArray">Input:Pipe separated list for the bits, need 8 or 16 bits</param>
    	[UserCodeMethod]
    	public static void NS_ValidateRecords_MonitorControlPointForm(string type, string atcsAddress, string bitArray, bool closeForms)
    	{
    	    if (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.SelfInfo.Exists(0))
    	    {
    	        Ranorex.Report.Error("Monitor Control Points Form not open");
    	        return;
    	    }
    	    
    	    string[] separatedBitArray = bitArray.Split('|');
    	    if (!(separatedBitArray.Length == 8 || separatedBitArray.Length == 16))
    	    {
    	        Ranorex.Report.Error("bitArray must have either 8 or 16 digits, please correct the data in your datasheet");
    	        return;
    	    }
    	    int tableRows = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.Self.Rows.Count;
    	    bool rowFound = false;
    	    for (int i = 0; i < tableRows; i++)
    	    {
    	        Tracklinerepo.ControlPointCommunicationsIndex = i.ToString();
    	        if (!type.Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.Type.Text))
	            {
	                continue;
	            }
    	        
    	        if (!atcsAddress.Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.ATCSAddress.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[0].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N11.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[1].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N12.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[2].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N13.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[3].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N14.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[4].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N15.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[5].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N16.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[6].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N17.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (!separatedBitArray[7].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N18.Text))
    	        {
    	            continue;
    	        }
    	        
    	        if (separatedBitArray.Length > 8)
    	        {
    	            if (!separatedBitArray[8].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N21.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[9].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N22.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[10].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N23.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[11].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N24.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[12].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N25.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[13].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N26.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[14].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N27.Text))
        	        {
        	            continue;
        	        }
    	            
    	            if (!separatedBitArray[15].Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N28.Text))
        	        {
        	            continue;
        	        }
    	        } else {
    	            //Make sure there is no data in these cells if we're expected a size of 8
    	            if (!"".Equals(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.ControlPointCommunicationsTable.ControlPointCommunicationsRowByControlPointCommunicationsIndex.N21.Text))
        	        {
        	            continue;
        	        }
    	        }
    	        
    	        rowFound = true;
    	        break;
    	    }
    	    
    	    if (rowFound)
    	    {
    	        string successString = "";
    	        if (separatedBitArray.Length > 8)
    	        {
    	            successString = "Found Type: {" + type + "} ATCS Address: {" + atcsAddress + "} 2NWK: {" + separatedBitArray[0] + "} 2RWK: {" + separatedBitArray[1] + "} 4NWK: {" + separatedBitArray[2] + "} 4RWK: {" + separatedBitArray[3] + 
    	                "} 1TK: {" + separatedBitArray[4] + "} 3TK: {" + separatedBitArray[5] + "} 24LK: {" + separatedBitArray[6] + "} M1SA: {" + separatedBitArray[7] + "} 2SAK: {" + separatedBitArray[8] + "} 1NAK: {" + separatedBitArray[9] + 
    	                "} 2-3: {" + separatedBitArray[10] + "} 2-4: {" + separatedBitArray[11] + "} DCK: {" + separatedBitArray[12] + "} DOK: {" + separatedBitArray[13] + "} POK: {" + separatedBitArray[14] + "} LCK: {" + separatedBitArray[15] + "}";
    	        } else {
    	            successString = "Found Type: {" + type + "} ATCS Address: {" + atcsAddress + "} 2NWZ: {" + separatedBitArray[0] + "} 2RWZ: {" + separatedBitArray[1] + "} 1NGZ: {" + separatedBitArray[2] + "} 1SGZ: {" + separatedBitArray[3] + 
    	                "} 1-5: {" + separatedBitArray[4] + "} 1-6: {" + separatedBitArray[5] + "} 1-7: {" + separatedBitArray[6] + "} 1-8: {" + separatedBitArray[7] + "}";
    	        }
    	        Ranorex.Report.Success(successString);
    	    } else {
    	        string failureString = "";
    	        if (separatedBitArray.Length > 8)
    	        {
    	            failureString = "Did not find row with Type: {" + type + "} ATCS Address: {" + atcsAddress + "} 2NWK: {" + separatedBitArray[0] + "} 2RWK: {" + separatedBitArray[1] + "} 4NWK: {" + separatedBitArray[2] + "} 4RWK: {" + separatedBitArray[3] + 
    	                "} 1TK: {" + separatedBitArray[4] + "} 3TK: {" + separatedBitArray[5] + "} 24LK: {" + separatedBitArray[6] + "} M1SA: {" + separatedBitArray[7] + "} 2SAK: {" + separatedBitArray[8] + "} 1NAK: {" + separatedBitArray[9] + 
    	                "} 2-3: {" + separatedBitArray[10] + "} 2-4: {" + separatedBitArray[11] + "} DCK: {" + separatedBitArray[12] + "} DOK: {" + separatedBitArray[13] + "} POK: {" + separatedBitArray[14] + "} LCK: {" + separatedBitArray[15] + "}";
    	        } else {
    	            failureString = "Did not find row with Type: {" + type + "} ATCS Address: {" + atcsAddress + "} 2NWZ: {" + separatedBitArray[0] + "} 2RWZ: {" + separatedBitArray[1] + "} 1NGZ: {" + separatedBitArray[2] + "} 1SGZ: {" + separatedBitArray[3] + 
    	                "} 1-5: {" + separatedBitArray[4] + "} 1-6: {" + separatedBitArray[5] + "} 1-7: {" + separatedBitArray[6] + "} 1-8: {" + separatedBitArray[7] + "}";
    	        }
    	        Ranorex.Report.Failure(failureString);
    	    }
    	    
    	    if (closeForms)
    	    {
    	        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.CloseButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Monitor_Control_Point_Communications.SelfInfo);
    	    }
    	    return;
    	}	
    	///<summary>
    	/// Validate EMT Issue dDetails
    	/// </summary>
    	/// <param name="trainSeed">Input:trainSeed to right click on Train on Trackline.</param>
    	/// <param name="trackSectionId">Input:trackSectionId</param>
    	/// <param name="expEngineId">optInput:engineId (ex. NS 501).</param>
    	/// <param name="milePost">Input:milePost (ex. 204H).</param>
    	/// <param name="expTrackId">optInput: expTrackId (ex. MAIN 1).</param>//
    	/// <param name="expProceedingDirection">Input:direction (ex.SOUTH,NORTH)</param>
    	/// <param name="closeForms">Input:closeForms</param>
    	[UserCodeMethod]
    	public static void NS_ValidateEMTDetails(string trainSeed, string trackSectionId, string milePost, string direction, string track)
    	{
    		NS_OpenEMTOnTrackSection(trainSeed, trackSectionId);
    		 
    		
    		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Failed to Open EMT Details Forms.");
    			return;
    		}
    		System.DateTime now = System.DateTime.Now;
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		trainId =  trainId +" "+ now.ToString("MM-dd-yyyy") + " NS";
    		
    		
    		string actTrainID = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.TrainIdText.GetAttributeValue<string>("Text");
    		string trackText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.TrackText.GetAttributeValue<string>("Text");
    		string atMilepostText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.AtMilepostText.GetAttributeValue<string>("Text");
    		string proceedingDirectionText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.ProceedingDirectionText.GetAttributeValue<string>("Text");
    		string trainIdText = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.TrainIdText.GetAttributeValue<string>("Text");
			if (trainId == actTrainID) 
			{
				Ranorex.Report.Success("Expected trainId to be {"+trainId+"} and found to be {"+actTrainID+"}.");	
			}
			else
    		{
    			Ranorex.Report.Failure("Expected trainId to be {"+trainId+"} but found to be {"+actTrainID+"}.");
    		}
    		if(atMilepostText == milePost)
    		{
    			Ranorex.Report.Success("Expected milepost to be {"+milePost+"} and found to be {"+atMilepostText+"}.");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Expected milepost to be {"+milePost+"} but found to be {"+atMilepostText+"}.");
    		}
    		if(proceedingDirectionText == direction)
    		{
    			Ranorex.Report.Success("Expected direction to be {"+direction+"} and found to be {"+proceedingDirectionText+"}.");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Expected direction to be {"+direction+"} but found to be {"+proceedingDirectionText+"}.");
    		}
    		if(trackText == track)
    		{
    			Ranorex.Report.Success("Expected track to be {"+track+"} and found to be {"+trackText+"}.");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Expected track to be {"+track+"} but found to be {"+trackText+"}.");
    		}
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.CloseButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Permission_To_Enter_Main_Track.SelfInfo);
    		Report.Success("Successfully Validate EMT Details.");
    	}
		
		
    	///<summary>
    	/// Verify stacked routes count on Trackline - control point 
    	/// </summary>
    	/// <param name="deviceName">Input the deviceName(Ex: Wells)</param>
    	/// <param name="expectedCount">Input control point menu option</param>
    	[UserCodeMethod]
    	public static void NS_ValidateStackedRouteCount(string deviceName, int expectedCount)
    	{
    		string stackedRouteName = "";
    		Tracklinerepo.ControlPointName = deviceName;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find device with device name as {"+deviceName+"} on any open trackline");
    			return;
    		}    	
    		
    		// Click on control point to load context menu
    		GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
    		                                          Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.SelfInfo);
    		
    		if(!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.SelfInfo.Exists(0))
    		{
    			Report.Info("No stacked route found");
    			return;
    		}
   		
    		int actualCount = Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.Self.Rows.Count;    		
    		Report.Info("Stacked Route count is " +actualCount);
    		    		
    		if(actualCount == expectedCount)
    		{
    			Report.Success("Stacked Route count expected to be {"+expectedCount+"} and found {"+actualCount+"}");
    		}     		
    		
    		else
    		{
    			Report.Failure("Stacked Route count expected to be {"+expectedCount+"} but found {"+actualCount+"}");
    			Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.Self);
    		}
    		
    		for (int i = 0; i < actualCount; i++)
    		{
    			Tracklinerepo.StackedRouteIndex = i.ToString();
    			
    			stackedRouteName = Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.StackedRouteTableRowByIndex.DeviceName.GetAttributeValue<string>("Limits");
    			Report.Info("Stacked Route name is " +stackedRouteName);
    			
    			if(stackedRouteName.Equals(deviceName))
    			{
    				Report.Success("Stacked Route name expected to be {"+deviceName+"} and found {"+stackedRouteName+"}");
    			}
    			else
    			{
    				Report.Failure("Stacked Route name expected to be {"+deviceName+"} and found {"+stackedRouteName+"}");
    				Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.Self);
    			}
    		}
    		
    	}
    	
    	
    	///<summary>
    	/// Validate train trace route for stacked routes
    	/// </summary>
    	/// <param name="deviceName">Input: deviceName(Ex: Wells)</param>
    	/// <param name="leftOrRightClick">Input:leftclick to left click on route, rightclick right clicks route and selects Trace Route</param>    
    	[UserCodeMethod]
    	public static void NS_LeftOrRightClickStackedRouteForTraceRoute_ControlPoint(string deviceName, string leftOrRightClick)
    	{
    		string stackedRouteName = "";
    		Tracklinerepo.ControlPointName = deviceName;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find device with device name as {"+deviceName+"} on any open trackline");
    			return;
    		}
    		
    		// Click on control point to load context menu
    		GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
    		                                          Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.SelfInfo);
    		
    		int count = Tracklinerepo.Trackline_Form.ControlPointStackedRouteMenu.StackedRouteTable.Self.Rows.Count;
    		
    		if(count == 0)
    		{
    			Ranorex.Report.Failure("No stacked route found");
    			Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.Self);
    			return;
    		}
    		
    		bool stackedRouteFound = false;
    		for (int i = 0; i < count; i++)
			{
				Tracklinerepo.StackedRouteIndex = i.ToString();
				stackedRouteName = Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.StackedRouteTableRowByIndex.DeviceName.GetAttributeValue<string>("Limits");
				
				if(stackedRouteName.Equals(deviceName))
				{
				    stackedRouteFound = true;
				    switch(leftOrRightClick.ToLower())
            		{
            			case "leftclick":
            				Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.StackedRouteTableRowByIndex.DeviceName.Click(Location.UpperLeft);
            				break;
            				
            			case "rightclick":
            				
        					// Right click on device name
        					Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.StackedRouteTableRowByIndex.DeviceName.Click(WinForms.MouseButtons.Right, Location.UpperLeft);
        					//Click on TraceRoute
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.TraceRouteInfo,
        					                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.SelfInfo);
            				break;
            				
                        default:
            				Ranorex.Report.Error(leftOrRightClick + " is not a valid choice for clicking the stacked route");
            				break;
            		}
				}
    		}
    		
    		if (!stackedRouteFound)
    		{
    		    Ranorex.Report.Failure("Could not find stacked route with Name {" + deviceName + "}");
    		    return;
    		}
    		
    	}
		
    	///<summary>
    	/// validate train trace color on tracksection
    	/// </summary>
    	/// <param name="trackSectionIds">Input:trackSection (Ex: 41488)</param>
    	/// <param name="expTraceColor">Input:onTraceColor (Ex: Yellow)</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainTraceColor(string trackSectionIds, string expTraceColor)
    	{
    		string[] trackIds = trackSectionIds.Split('|');
    		List<string> trackSectionSuccesses = new List<string>();
    		List<string> trackSectionFailures = new List<string>();
    		foreach(string trackId in trackIds)
    		{
    			Tracklinerepo.TrackSectionId = trackId;
    			if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObject, expTraceColor, true))
    			{
    			    trackSectionSuccesses.Add(trackId);
    			}
    			else
    			{
    			    trackSectionFailures.Add(trackId);
    			}
    		}
    		
    		if (trackSectionSuccesses.Count > 0)
    		{
    		    Ranorex.Report.Success("The following Track Sections had the correct Trace Route Color {" + string.Join(", ", trackSectionSuccesses) + "}");
    		}
    		if (trackSectionFailures.Count > 0)
    		{
    		    Ranorex.Report.Failure("The following Track Sections did not have the correct Trace Route Color {" + string.Join(", ", trackSectionFailures) + "}");
    		}
    		return;
    	}
    	
    	        	
    	
		///<summary>
    	/// Click on control point then stacked route option and transmit
    	/// </summary>
    	/// <param name="opsta">Input:opsta (Ex: Wells)</param>
    	/// <param name="stackedRouteOption">Input: stackedRouteOption (Ex: Trace Route or Move to Bottom)</param>
    	/// <param name="transmit">Input:transmit (Ex:True or False)</param>    
		[UserCodeMethod]    	
    	public static void NS_SelectStackedRouteOption_ControlPoint(string deviceName, string stackedRouteOption, bool transmit)
    	{
    		Tracklinerepo.ControlPointName = deviceName;
    		if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find device with device name as {"+deviceName+"} on any open trackline");
    			return;
    		}
    		
    		// Click on control point to load context menu
    		GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
													Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.SelfInfo);
    		
    		// Click on device name  		
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.StackedRouteTable.SelfInfo, Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.SelfInfo);
    			
    		switch (stackedRouteOption.ToUpper())
    		{
    			case "MOVE TO TOP":
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.MoveToTopInfo,
    				                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.SelfInfo);
    				break;
    			case "MOVE TO BOTTOM":
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.MoveToBottomInfo,
    				                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointStackedRouteMenu.SelfInfo);
    				break;
    			case "DELETE":
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.DeleteInfo,
    				                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.SelfInfo);
    				break;
    			case "TRACE ROUTE":
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.TraceRouteInfo,
    				                                                  Tracklinerepo.Trackline_Form_By_ControlPoint_Name.StackedRouteContextMenu.SelfInfo);
    				break;
    			default:
    				Report.Error(string.Format("Invalid stacked route option '{0}'. Please check bindings and try again.", stackedRouteOption));
    				return;
    		}
    		
    		// Then transmit finally.
    		if(transmit)
    		{
    			Tracklinerepo.Trackline_Form.RibbonMenu.Transmit.Click();
    			Report.Info("Clicked Transmit");    		    		
    		}
    	}    	    	    	
    	
    	
    	/// <summary>
        /// This method is to click continue or cancel button and clear transmit list for trackline
        /// </summary>
        /// <param name="clickContinue">Input:Clicks continue if true, cancel if false</param>
        [UserCodeMethod]
        public static void NS_ClickContinueOrCancel_ClearSignalFailedPopup(bool clickContinue)
        {
        	if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Clear_Signal_Failed_Popup.SelfInfo.Exists(0))
        	{
        		if(clickContinue)
        		{        			
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Clear_Signal_Failed_Popup.ContinueButtonInfo,
        			                                                  Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo);
        			Ranorex.Report.Info("Clicked on continue button");        			
        		}
        		else
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Clear_Signal_Failed_Popup.CancelButtonInfo,
        			                                                  Tracklinerepo.Trackline_Form_By_Signal_Id.SelfInfo);
        			Ranorex.Report.Info("Clicked on cancel button");
        		}
        	}
        }
        
    	
    	///<summary>
    	/// Right click on tracksection and remove Signal authority
    	/// </summary>
    	/// <param name="trackSection">Input:opsta (Ex: Wells)</param>
    	/// <param name="expectedFeedback">Input: expectedFeedback</param>
    	/// <param name="removeAuthority">Input:True clicks yes on remove authority popup, false clicks no </param>
		[UserCodeMethod]    	
    	public static void NS_RemoveSignalAuthority(string trackSection, string expectedFeedback, bool removeAuthority)
    	{
    		Tracklinerepo.TrackSectionId = trackSection;
    		if (!Tracklinerepo.Trackline_Form.SelfInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Could not find track section as {"+trackSection+"} on any open trackline");
    			return;
    		}
    		
    		GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo,
    		                                               Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo);
    		//Click on Removal signal authority
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RemoveSignalAuthorityInfo,
    		                                                  Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo);
    		
    		GeneralUtilities.CheckWaitState(1);
    		string feedback = Tracklinerepo.Trackline_Form_By_TrackSection_Id.Feedback.TextValue;
    		
    		if (!string.IsNullOrEmpty(expectedFeedback))
    		{
    			Ranorex.Report.Info("TestStep", "Checking feedback from Remove signal authority");
    			Ranorex.Report.Info(string.Format("Actual feedback: '{0}'", feedback));
    			if (feedback.Equals(expectedFeedback))
    			{
    				Ranorex.Report.Success(string.Format("Feedback matches '{0}'", expectedFeedback));
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Error(string.Format("Feedback does not match '{0}' as expected", expectedFeedback));
    			}
    		}
    		
    		if(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Remove_Signal_Authority.SelfInfo.Exists(0))
    		{
    			if (removeAuthority)
    			{
    				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Remove_Signal_Authority.YesButton.Click();
    				Ranorex.Report.Info("Signal authority has been removed for track section " +trackSection);
    				Report.Screenshot(Tracklinerepo.Trackline_Form_By_TrackSection_Id.Self);
    			}
    			else
    			{
    				Tracklinerepo.Trackline_Form_By_TrackSection_Id.TracklineGeneratedForms.Remove_Signal_Authority.NoButton.Click();
    				Ranorex.Report.Info("Signal authority not removed for track section " +trackSection);
    				Report.Screenshot(Tracklinerepo.Trackline_Form_By_TrackSection_Id.Self);
    			}
    		}
    		else
    		{    			
    			Ranorex.Report.Error("Remove signal authority pop up doesn't exist");
    		}
    	}
    	
    	/// <summary>
    	/// Validate Weather Alert is recevied or not at opstas
    	/// </summary>
    	/// <param name="controlPointName">Input: controlPoint (Ex: Grove, Finch)</param>
    	/// <param name="expWeatherAlertMessage">Create WeatherAlert : Pass expected 'WeatherAlert' message after creating 
    	///                                      Clear WeatherAlert: Keep this param as blank</param>
    	/// <param name="expWeatherAlert">Create WeatherAlert - TRUE 
    	///                               Clear WeatherAlert - FAlSE</param>
    	[UserCodeMethod]
    	public static void ValidateWeatherAlertMessage_ControlPoint(string controlPointName, string expWeatherAlertMessage, bool expWeatherAlert)
    	{
    		string[] controlPoints = controlPointName.Split('|');
    		
    		if(controlPoints.Length >= 1)
    		{
    			for(int i = 0; i < controlPoints.Length; i++)
    			{
    				Tracklinerepo.ControlPointName = controlPoints[i];
    				
    				if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
    				{
    					Ranorex.Report.Error("Could not find Opsta {"+controlPoints[i]+"} on any open trackline");
    					return;
    				}
    				
    				if(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo.Exists(0))
    				{
    					
    					Object weatherAlertInfo = Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObject.Element.GetAttributeValue("WeatherAlertNoticeInfo");
    					string actWeatherAlertInfo = weatherAlertInfo.ToString();
    					
    					if(expWeatherAlert)
    					{
    						if(actWeatherAlertInfo.Contains(expWeatherAlertMessage) == expWeatherAlert)
    						{
    							Ranorex.Report.Success("Validation", "Expected WeatherAlert info is receivied at {" +controlPoints[i]+"}.");
    						}
    						else
    						{
    							Ranorex.Report.Failure("Validation", "Did not receive expected WeatherAlert info at {" +controlPoints[i]+ "}.");
    							Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.Self);
    						}
    					}
    					else
    					{
    						if((actWeatherAlertInfo == "") || (actWeatherAlertInfo == "[]"))
    						{
    							Ranorex.Report.Success("Validation", "No WeatherAlert is receivied at {" +controlPoints[i]+"}.");
    						}
    						else
    						{
    							Ranorex.Report.Failure("Validation", "Expected no WeatherAlert but found WeatherAlert at {" +controlPoints[i]+ "}.");
    							Report.Screenshot(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.Self);
    						}
    					}
    				}
    				else
    				{
    					Ranorex.Report.Failure("Control point object does not exist to validate WeatherAlert");
    				}
    			}
    		}
    		else
    		{
    			Ranorex.Report.Failure("Pass atleast one valid ControlPoint name");
    		}
    	}
    	/// </summary>
    	/// <param name="popupText">Input:popupText to validate.</param>
    	/// <param name="clickYes">Input:clickYes (ex.True or False) to issue Permission to enter main Track.</param>
    	/// <param name="clickNo">Input:clickNo (ex.True or False) to deny Permission to enter main Track. </param>
    	/// <param name="clickCancel">Input: clickCancel (ex.True or False) (X button) to close Popup.</param>
    	[UserCodeMethod]
    	public static void NS_ValidateNotificationpPopupExist( bool clickYes, bool clickNo, bool clickCancel, bool closeCreatePermissionForms)
    	{
    		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.SelfInfo.Exists(0))
    		{
    			 if(clickYes)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.YesButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.SelfInfo);
    				Report.Info("Clicked Yes Button.");
    			}
    			else if(clickNo)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.NoButtonInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.SelfInfo);
    				Report.Info("Clicked No Button.");	
    			}
    			else if(clickCancel)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.WindowControls.CloseInfo,
    				                                                  Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.SelfInfo);
    				Report.Info("Clicked X Button.");
    			}
    		}
    		else
    		{
    			Ranorex.Report.Failure("Notification Popup Dialog Box NOT Exist.");
    			Report.Screenshot(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.Notification_Popup.Self);
    		}
    		
    		if(closeCreatePermissionForms)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.CancelButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Create_Permission_To_Enter_Main.SelfInfo);
    			Report.Info("Create Permission to Enter Main form is closed.");
    		}
    	}
    	
        [UserCodeMethod]
        public static void ValidateOptionsEnable_Trackline(string menuOption,bool isEnable, string deviceId)
        {        	
        	switch (menuOption.ToLower())
        	{
        		case "monitorcontrolpoint":
        			Tracklinerepo.ControlPointName = deviceId;
        			if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find control point name with device id {"+deviceId+"} on any open trackline");
        				return;
        			}

        			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
        			                                               Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);
        			if(isEnable)
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.MonitorControlPointCommunicationsInfo,true);
        			}
        			else
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.MonitorControlPointCommunicationsInfo,false);
        			}
        			break;
        		case "transfertosignaltechnician":
        			Tracklinerepo.ControlPointName = deviceId;
        			if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find control point name with device id {"+deviceId+"} on any open trackline");
        				return;
        			}

        			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
        			                                               Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);
        			if(isEnable)
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.TransferToSignalTechInfo,true);
        			}
        			else
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.TransferToSignalTechInfo,false);
        			}
        			break;
        		case "transfertodispatcher":
        			Tracklinerepo.ControlPointName = deviceId;
        			if (!Tracklinerepo.Trackline_Form_By_ControlPoint_Name.SelfInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find control point name with device id {"+deviceId+"} on any open trackline");
        				return;
        			}

        			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectInfo,
        			                                               Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.SelfInfo);
        			if(isEnable)
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.TransferToDispatcherInfo,true);
        			}
        			else
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_ControlPoint_Name.ControlPointObjectMenu.TransferToDispatcherInfo,false);
        			}
        			break;
        		case "tracksectiontomanual":
        			Tracklinerepo.TrackSectionId = deviceId;
        			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find tracksection with device id {"+deviceId+"} on any open trackline");
        				return;
        			}

        			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo,
        			                                               Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo);
        			if(isEnable)
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Manual.TrackSectionInfo,true);
        			}
        			else
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Manual.TrackSectionInfo,false);
        			}
        			break;
        		case "removesignalauthority":
        			Tracklinerepo.TrackSectionId = deviceId;
        			if (!Tracklinerepo.Trackline_Form_By_TrackSection_Id.SelfInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find tracksection with device id {"+deviceId+"} on any open trackline");
        				return;
        			}

        			GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo,
        			                                               Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.SelfInfo);
        			if(isEnable)
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RemoveSignalAuthorityInfo,true);
        			}
        			else
        			{
        				GeneralUtilities.CheckFieldEnableDisable(Tracklinerepo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.RemoveSignalAuthorityInfo,false);
        			}
        			break;
        		default:
        			Ranorex.Report.Failure("Invalid option");
        			break;
        	}
        }
    }
}