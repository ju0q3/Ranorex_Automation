/*
 * Created by Ranorex
 * User: 502711712
 * Date: 1/7/2019
 * Time: 2:37 PM
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
using PDS_CORE.Code_Utils;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.Collections;

namespace PDS_NS.UserCodeCollections
{
	/// <summary>
	/// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
	/// </summary>
	[UserCodeCollection]
	public class NS_NVC
	{
		public static PDS_NS.Trains_Repo trainrepo = PDS_NS.Trains_Repo.Instance;
		public static PDS_NS.MainMenu_Repo MainMenurepo = PDS_NS.MainMenu_Repo.Instance;
		
		/// <summary>
		/// Used to ensure NVC is open for any NVC related functions.
		/// </summary>
		[UserCodeMethod]
		public static bool IsNVCOpen ()
		{
			if (!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				//I want this to be destroyed, don't pull it out
				PDS_NS.MainMenu_Repo mainmenurepo = PDS_NS.MainMenu_Repo.Instance;
				mainmenurepo.PDS_Main_Menu.MainMenuBar.TrainsButton.Click();
				mainmenurepo.PDS_Main_Menu.TrainsMenu.NetworkVisibilityConsole.Click();
				//Takes a few seconds to open
				Delay.Seconds(15);
				
				int retries = 0;
				while (!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0) && retries < 5)
				{
					mainmenurepo.PDS_Main_Menu.MainMenuBar.TrainsButton.Click();
					mainmenurepo.PDS_Main_Menu.TrainsMenu.NetworkVisibilityConsole.Click();
					Delay.Seconds(15);
					retries++;
				}
				
				//Wait a little longer after last retry for final check
				if (!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("NVC did not appear.");
					return false;
				}
			}
			
			int retry = 0;
			trainrepo.Network_Visibility_Console.Self.Activate();
			while (!trainrepo.Network_Visibility_Console.Self.EnsureVisible() && retry < 3)
			{
				trainrepo.Network_Visibility_Console.Self.Activate();
				retry++;
			}
			//If it exists, but it's minimized, open a new one.
			if (!trainrepo.Network_Visibility_Console.Self.EnsureVisible())
			{
				Ranorex.Report.Error("Can't bring NVC to the front.");
			}
			
			return true;
		}
		
		/// <summary>
		/// Used to open the specified territory in NVC.
		/// </summary>
		/// <param name="territoryName">Name of territory to be opened in NVC.</param>
		[UserCodeMethod]
		public static bool OpenNVCTerritory (string division, string territory)
		{
			if(!IsNVCGraphOpen())
			{
				return false;
			}
			
			trainrepo.NVCDivision = division;
			trainrepo.NVCTerritory = division + ": " + territory;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			Delay.Milliseconds(200);
			
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo, trainrepo.Network_Visibility_Console.TopologyTree.TerritoryInfo, System.Windows.Forms.MouseButtons.Left);
			
			trainrepo.Network_Visibility_Console.TopologyTree.Territory.Click(Location.CenterLeft);
			Delay.Milliseconds(200);
			
			//          Still looking for a way to validate this was successful
//			Currently, Ranorex cannot see whether or not the tree items are selected
			//            if(!Trains_Repo.Instance.Network_Visibility_Console.MenuBar.Topology.TopologyTree.DivisionTreeItem.TerritoryTreeItem.Self.Checked) {
			//            	Ranorex.Report.Failure("Failed to open desired territory in NVC.");
			//            	return false;
			//            }
//
			//            Ranorex.Report.Success("Desired territory selected in NVC.");
			
			return true;
		}
		
		/// <summary>
		/// Used to open the specified division in NVC.
		/// </summary>
		/// <param name="territoryName">Name of division to be opened in NVC.</param>
		[UserCodeMethod]
		public static bool OpenNVCDivision (string division)
		{
			if(!IsNVCGraphOpen())
			{
				return false;
			}
			
			trainrepo.Division = division;
			trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButton.Click();
			Delay.Milliseconds(200);
			
			trainrepo.Network_Visibility_Console.MenuBar.Topology._OBSOLETED_TopologyTree.DivisionTreeItem.Self.Click(Location.CenterLeft);
			Delay.Milliseconds(200);
			
			//          Still looking for a way to validate this was successful
			return true;
		}
		
		/// <summary>
		/// Checks if the NVC summary list tab is open, if not, open it. First checks if NVC is available and active.
		/// </summary>
		/// <returns>Returns true if the summary list is opened, false if NVC isn't even open or if it fails to open the summary list.</returns>
		[UserCodeMethod]
		public static bool IsNVCSummaryListOpen ()
		{
			
			if(!IsNVCOpen())
			{
				return false;
			}
			
			int retries = 0;
			while (!trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.SelfInfo.Exists(0) && retries < 5)
			{
				trainrepo.Network_Visibility_Console.MenuBar.ViewSummaryList.Click();
				Delay.Seconds(1);
				retries++;
			}
			
//			//Wait a little longer after last retry for final check
//			if (!trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.SelfInfo.Exists(0))
//			{
//				Ranorex.Report.Error("Summary list pane did not appear.");
//				return false;
//			}
//
			return true;
			
		}
		
		[UserCodeMethod]
		public static bool IsNVCGraphOpen ()
		{
			
			if(!IsNVCOpen())
			{
				return false;
			}
			
			int retries = 0;
			while (!trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo.Exists(0) && retries < 5)
			{
				trainrepo.Network_Visibility_Console.MenuBar.ViewGraph.Click();
				Delay.Seconds(1);
				retries++;
			}
			
			//Wait a little longer after last retry for final check
			if (!trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo.Exists(0))
			{
				Ranorex.Report.Error("Graph pane did not appear.");
				return false;
			}
			
			return true;
			
		}
		
		/// <summary>
		/// Used to add planner track restrictions in NVC>
		/// </summary>
		/// <param name="type">PTRs can be of types - 'Speed Restriction', 'Block', 'Prevent Dwell', 'Block Activities', 'Current of Traffic', 'Head Speed Restriction'.</param>
		/// <param name="startMP">Milepost where the restriction range will begin. </param>
		/// <param name="endMP">Milepost where the restriction range will end</param>
		/// <param name="traffic">Direction of traffic affected - 'Upbound', 'Downbound', 'Undefined'.</param>
		/// <param name="speed">Speed restraint. Required for speed restrictions.</param>
		/// <param name="starttime"> Time at which the restriction becomes effective.</param></param>
		/// <param name="endtime">Time at which the restriction ends.</param>
		[UserCodeMethod]
		public static void AddPTR (string type, string startMP, string endMP, string traffic, string speed, string starttime, string endtime, string Reason)
		{
			//probably want a retry here
			//MP Entry
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.FromMP.Click();
			Keyboard.Press(startMP);
			Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			Keyboard.Press(endMP);
			Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			
			//TODO Future functionality for editing Track drop down location
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.RestrictionType.Click();
			switch (type) {
				case "Speed Restriction":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.SpeedRestriction.Click();
					break;
					
				case "Block":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.Block.Click();
					break;
					
				case "Block Activities":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.SystemActivityBlock.Click();
					break;
					
				case "Prevent Dwell":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.PreventDwell.Click();
					break;
					
				case "Current of Traffic":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.CurrentOfTraffic.Click();
					break;
					
				case "Head Speed Restriction":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.HeadEndOnlySpeedRestriction.Click();
					break;
					
				default:
					Ranorex.Report.Error("Incorrect Restriction Type: " + type + ".");
					break;
			}
			
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.Restriction_Configurables.Traffic.Click();
			
			switch (traffic) {
				case "Upbound":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.Upbound.Click();
					break;
					
				case "Downbound":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.Downbound.Click();
					break;
					
				case "Undefined":
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionListItems.Undefined.Click();
					break;
					
				default:
					Ranorex.Report.Error("Unknown traffic flow: " + traffic + ".");
					break;
			}
			
			if (type.Equals("Head Speed Restriction") || type.Equals("Speed Restriction")) {
				trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.Restriction_Configurables.Speed.Click();
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(speed);
				Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			}
			
			//Effective Time
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.EffectiveTime.Click();
			Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			Keyboard.Press(starttime);
			Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			
			//Expires at Time
			if (!endtime.Equals("")) {
				trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.RestrictionInfoPanel.ExpiresAtTime.Click();
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(endtime);
				Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			}
			
			// add Reason
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.ViolationPanel.Reason_Editor_Panel.Reason_For_Change.Element.SetAttributeValue("Text", Reason);
			trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.ViolationPanel.Reason_Editor_Panel.Reason_For_Change.PressKeys("{TAB}");
			//TODO ADD FILTERING CAPABILITIES
			
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SaveInfo, trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo);
			//TODO Check last entry in restriction table, validate it is this restriction
			
			if (trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("Restriction not applied.");
				trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.Cancel.Click();
				trainrepo.NVC_Forms.DiscardChanges.DiscardChanges.Click();
				return;
			}
		}
		
		/// <summary>
		/// Used to validate train status in NVC.
		/// </summary>
		/// <param name="trainID">ID of the train to be validated.</param>
		/// <param name="status">Status in the "Activity on Plan" column of the summary table to be verified. Current possible values are
		/// UNKNOWN, NOT_APPLICABLE, OFF_PLAN, ON_PLAN which are translated.</param>
		[UserCodeMethod]
		public static void VerifyPlanStatus (string trainSeed, string status)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			if (!IsNVCSummaryListOpen())
			{
				return;
			}
			
			switch (status)
			{
				case "Off Plan":
					status = "OFF_PLAN";
					break;
					
				case "On Plan":
					status = "ON_PLAN";
					break;
					
				case "Unknown":
					status = "UNKNOWN";
					break;
					
				case "N/A":
					status = "NOT_APPLICABLE";
					break;
					
				default:
					Ranorex.Report.Error("Invalid status type: " + status + ". Not 'Off Plan', 'On Plan', 'Unknown', 'N/A'.");
					return;
			}
			
			trainrepo.Network_Visibility_Console.SummaryTabs.TrainSummary.Click();
			
			int iterator = 0;
			bool found = false;
			while (found == false && iterator < trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.Self.GetAttributeValue<int>("rowcount"))
			{
				trainrepo.SummaryIndex = iterator.ToString();
				if (trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.TrainId.GetAttributeValue<string>("text").Contains(trainId))
				{
					found = true;
				}
				else
				{
					Ranorex.Report.Info("Found train: " + trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.TrainId.GetAttributeValue<string>("text"));
					iterator++;
				}

			}
			
			if (found == false)
			{
				Ranorex.Report.Error("Train - " + trainId + " not in summary list");
				return;
			}
			else
			{
				string currentStatus = trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.ActivityOnPlan.GetAttributeValue<string>("text");
				if (currentStatus.Equals(status))
				{
					Ranorex.Report.Success("Train confirmed: " + status + ".");
				}
				else
				{
					Ranorex.Report.Error("Train status = " + currentStatus + ". Expected: " + status + ".");
				}
			}
			
		}
		
		/// <summary>
		/// Removes all active Planner Track Restrictions from the system.
		/// </summary>
		[UserCodeMethod]
		public static void RemoveAllPTRs ()
		{
			
			if (!IsNVCSummaryListOpen())
			{
				return;
			}
			NS_OpenRestrictionSummaryTab();
			int restrictionSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Self.Rows.Count;
			Ranorex.Report.Info("count present in Summary Table " +restrictionSummaryCount+ " ");
			if (restrictionSummaryCount >= 1)
			{
				for(int i=0; i<restrictionSummaryCount; i++)
				{
					trainrepo.RestrctionSummary = i.ToString();
					trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.Type.Click();
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.EditRestrictionInfo,
					                                          trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo);
					
					trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.Remove.Click();
					trainrepo.NVC_Forms.RemoveRestriction.RemoveRestriction.Click();
				}
			}
			else
			{
				Ranorex.Report.Info("PTR's does not Exist");
			}
			
		}
		
		/// <summary>
		/// To Open the DesignationSummary Tab
		/// </summary>
		[UserCodeMethod]
		public static void NS_OpenDesignationSummary()
		{
			if (!IsNVCSummaryListOpen())
			{
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.DesignationSummaryInfo,
			                                          trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SelfInfo);
		}
		
		/// <summary>
		/// To Search For an item Through Search Tab in NVC
		/// </summary>
		/// <param name="TrackFeatureId">Input Feature ID to search</param>
		/// <param name="TrackSegmentId">Input Segment ID to search</param>
		[UserCodeMethod]
		public static void NS_SearchForAnItem_NVC(string TrackFeatureId, string TrackSegmentId)
		{
			if(!IsNVCOpen())
			{
				return;
			}
			int ListCount = 0;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search_TabInfo,
			                                          trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchFieldInfo);
			trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchField.Element.SetAttributeValue("Text", TrackFeatureId);
			ListCount = trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchViewPort.ResultsList.Self.Items.Count;
			int retry = 0;
			while(ListCount == 0 && retry<3)
			{
				Delay.Milliseconds(8000);
				ListCount = trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchViewPort.ResultsList.Self.Items.Count;
				Ranorex.Report.Info(" "+ListCount+" ");
				retry ++;
			}
			if(ListCount == 0)
			{
				Ranorex.Report.Failure("No Search value Exist");
			}
			else
			{
				Ranorex.Report.Info(" "+ListCount+ " ");
				for (int i=0; i<ListCount; i++)
				{
					trainrepo.listitemindex = i.ToString();
					String regexPatternString = "\\[.*featureId\\s?=\\s?" + TrackFeatureId + ",.*segmentId\\s?=\\s?" + TrackSegmentId + ".*\\]";
					Regex regexMatcher = new Regex(regexPatternString);
					if (regexMatcher.IsMatch(trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchViewPort.ResultsList.ListItem.Element.GetAttributeValueText("Object")))
					{
						if(trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.ScrollBar.SelfInfo.Exists(0))
						{
							double maxValue = trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.ScrollBar.HorizontalScrollBarObj.GetAttributeValue<double>("MaxValue");
							double minValue = trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.ScrollBar.HorizontalScrollBarObj.GetAttributeValue<double>("MinValue");
							double meanValue = Math.Round((maxValue+minValue)/2);
							trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.ScrollBar.HorizontalScrollBarObj.Element.SetAttributeValue("Value",meanValue.ToString());
						}
						trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.SearchViewPort.ResultsList.ListItem.DoubleClick();
						break;
					}
				}
			}
		}
		
		/// <summary>
		/// To Configure Designation Constraint Form
		/// </summary>
		/// <param name="DesignationPanel">Input Checkbox for Desination Panel</param>
		/// <param name="Reason">Input Reason Field</param>
		[UserCodeMethod]
		public static void NS_Configure_Designation_Constraint(string DesignationPanel, string Reason)
		{
			if (trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo.Exists(0))
			{
				if (DesignationPanel.ToLower() == "upbound")
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferUpboundRadioButton.Click();
				}
				else if (DesignationPanel.ToLower() == "downbound")
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferDownboundRadioButton.Click();
				}
				else if (DesignationPanel.ToLower() == "bidirectional")
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferBidirectionalRadioButton.Click();
				}
				else if (DesignationPanel.ToLower() == "dwell")
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferDwellRadioButton.Click();
				}
				else if (DesignationPanel.ToLower() == "avoidMove")
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.AvoidForMoveRadioButton.Click();
				}
				
				trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.ViolationPanel.ReasonForChangeText.Element.SetAttributeValue("Text", Reason);
				trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.ViolationPanel.ReasonForChangeText.PressKeys("{TAB}");
				int ListCount = trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.ViolationPanel.Feedback.Items.Count;
				if(ListCount == 0)
				{
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.AccessButtons.SaveButton.Click();
				}
				else
				{
					Ranorex.Report.Failure("Failure to Edit Data");
					trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.AccessButtons.CancelButton.Click();
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.DiscardChanges.DiscardChangesInfo,
					                                                  trainrepo.NVC_Forms.DiscardChanges.SelfInfo);
				}
			}
			else
			{
				Ranorex.Report.Failure(" NVC Form Does Not Exist");
			}
		}
		
		[UserCodeMethod]
		public static void NS_EditDesignationSummary(string FeatureId, string DesignationPanel, string Reason, string TrackSegmentId)
		{
			NS_SearchForAnItem_NVC(FeatureId, TrackSegmentId);
			NS_OpenDesignationSummary();
			if (trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.EditDesignationInfo,
				                                          trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo);
				NS_Configure_Designation_Constraint(DesignationPanel, Reason);

			}
			else
			{
				Ranorex.Report.Failure("Designation Summary Tab is not open");
			}
			
		}
		
		
		[UserCodeMethod]
		public static void NS_OpenRestrictionSummaryTab()
		{
			if(!IsNVCOpen())
			{
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.RestrictionSummaryInfo,
			                                          trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SelfInfo);
		}
		
		/// <summary>
		/// Used to add planner track restrictions in NVC>
		/// </summary>
		/// <param name="type">PTRs can be of types - 'Speed Restriction', 'Block', 'Prevent Dwell', 'Block Activities', 'Current of Traffic', 'Head Speed Restriction'.</param>
		/// <param name="startMP">Milepost where the restriction range will begin. </param>
		/// <param name="endMP">Milepost where the restriction range will end</param>
		/// <param name="traffic">Direction of traffic affected - 'Upbound', 'Downbound', 'Undefined'.</param>
		/// <param name="speed">Speed restraint. Required for speed restrictions.</param>
		/// <param name="starttime"> Time at which the restriction becomes effective.</param></param>
		/// <param name="endtime">Time at which the restriction ends.</param>
		[UserCodeMethod]
		public static void NS_AddRestriction(string type, string startMP, string endMP, string traffic, string speed, string starttime, string endtime, string Reason)
		{
			IsNVCSummaryListOpen();
			NS_OpenRestrictionSummaryTab();
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.AddRestrictionInfo, trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo,
			                                          System.Windows.Forms.MouseButtons.Left);
			if (trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo.Exists(0))
			{
				AddPTR(type, startMP, endMP, traffic, speed, starttime, endtime, Reason);
			}
		}
		/// <summary>
		/// Used to Edit planner track restrictions in NVC>
		/// </summary>
		/// <param name="typeValue">PTRs can be of types - 'Speed Restriction', 'Block', 'Prevent Dwell', 'Block Activities', 'Current of Traffic', 'Head Speed Restriction'.</param>
		/// <param name="startMPValue">Milepost where the restriction range will begin. </param>
		/// <param name="endMPValue">Milepost where the restriction range will end</param>
		/// <param name="edittraffic">Direction of traffic affected - 'Upbound', 'Downbound', 'Undefined'.</param>
		/// <param name="editspeed">Speed restraint. Required for speed restrictions.</param>
		/// <param name="editstarttime"> Time at which the restriction becomes effective.</param></param>
		/// <param name="editendtime">Time at which the restriction ends.</param>
		/// <param name="editReason">Reason for editing restriction ends.</param>
		[UserCodeMethod]
		public static void NS_EditRestriction(string typeValue, string startMPValue, string endMPValue, string editType, string editStartMP, string changeEndMP, string editTraffic, string editSpeed, string editStarttime, string editEndtime, string editReason)
		{
			NS_OpenRestrictionSummaryTab();
			if (trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				int restrictionSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Self.Rows.Count;
				Ranorex.Report.Info("count present in Summary Table " +restrictionSummaryCount+ " ");
				string TagType;
				string StartMP;
				string EndMP;
				bool ReasonFieldFlag = false;
				if (restrictionSummaryCount>=1)
				{
					for(int i=0; i<restrictionSummaryCount; i++)
					{
						trainrepo.RestrctionSummary = i.ToString();
						TagType = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.Type.GetAttributeValue<string>("Text").Trim();
						StartMP = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.StartMP.GetAttributeValue<string>("Text").Trim();
						EndMP = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.EndMP.GetAttributeValue<string>("Text").Trim();
						Ranorex.Report.Info(" "+TagType+", "+StartMP+", "+EndMP+" ");
						if ((TagType == typeValue) && (StartMP == startMPValue) && (EndMP == endMPValue))
						{
							ReasonFieldFlag = true;
							break;
						}		
					}
					if (ReasonFieldFlag)
					{
						trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.Type.Click();
						GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.EditRestrictionInfo,
						                                          trainrepo.NVC_Forms.NVC_Planner_Track_Restriction.SelfInfo);
						AddPTR(editType, editStartMP, changeEndMP, editTraffic, editSpeed, editStarttime, editEndtime, editReason);
					}
					else
						{
							Ranorex.Report.Failure(" No Value Exist with the above Details ");
						}
				}
				else
				{
					Ranorex.Report.Failure("No Existing Summary Exist To Edit");
				}
			}
			else
			{
				Ranorex.Report.Failure(" NVC Form Does Not Exist");
			}
		}
		
		[UserCodeMethod]
		public static void NS_OpenClearAheadSummaryTab(string TrackFeatureId, string TrackSegmentId)
		{
			NS_SearchForAnItem_NVC(TrackFeatureId, TrackSegmentId);
			IsNVCSummaryListOpen();
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.ClearAheadInfo,
			                                          trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SelfInfo);
		}
		
		/// <summary>
		/// To add Lamp Route Configuration For NVC
		/// </summary>
		/// <param name="lampName">Input to search lampName</param>
		/// <param name="Station">Input Station name in summary table</param>
		/// <param name="signalClear">Input number of signals to clear</param>
		/// <param name="Requried">Input checkbox to validate</param>
		/// <param name="reason">Input the reason to edit clear Ahead</param>
		[UserCodeMethod]
		public static void NS_ConfigureLampRouteConfiguration(string lampName, string Station, string signalClear, bool requried, string reason)
		{
			int clearAheadSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.Self.Rows.Count;
			Ranorex.Report.Info("count present in Summary Table " +clearAheadSummaryCount+ " ");
			string LampNameType;
			string StationType;
			if (clearAheadSummaryCount>=1)
			{
				for (int i=0; i<clearAheadSummaryCount; i++)
				{
					trainrepo.ClearAhead = i.ToString();
					LampNameType = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.LampName.GetAttributeValue<string>("Text").Trim();
					StationType = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.Station.GetAttributeValue<string>("Text").Trim();
					if ((LampNameType == lampName) && (StationType == Station))
					{
						trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.Station.Click();
						GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.EditConfigurationInfo,
						                                          trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.SelfInfo);
						trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.SignalsToClearAheadPanel.SignalToClearText.Element.SetAttributeValue("Text", signalClear);
						if(requried)
						{
							trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.SignalsToClearAheadPanel.RequriedCheckbox.Click();
						}
						trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.ReasonEditorPanel.ReasonForChangeText.Element.SetAttributeValue("Text", reason);
						trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.ReasonEditorPanel.ReasonForChangeText.PressKeys("{TAB}");
						int ListCount = trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.ListItem.Items.Count;
						if(ListCount == 0)
						{
							trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.AccessButtons.Save.Click();
						}
						else
						{
							Ranorex.Report.Failure("Failure to Edit Data");
							trainrepo.NVC_Forms.NVC_Lamp_Rout_Configuration.AccessButtons.Cancel.Click();
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.DiscardChanges.DiscardChangesInfo,
							                                                  trainrepo.NVC_Forms.DiscardChanges.SelfInfo);
						}
						break;
					}
				}
			}
			else
			{
				Ranorex.Report.Info(" No Date present in the Table ");
			}
		}

		/// <summary>
		/// To Validate Reason Summary Table in Designation Summary
		/// </summary>
		/// <param name="TrackFeatureId">Input Track Feature Id for which reason should be validated</param>
		/// <param name="ReasonField">Input Reason To validate</param>
		[UserCodeMethod]
		public static void NS_ValidateReasonFieldDesignationSummary(string TrackFeatureId, string ReasonField)
		{
			NS_OpenDesignationSummary();
			int designationSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Self.Rows.Count;
			Ranorex.Report.Info("count present in Summary Table " +designationSummaryCount+ " ");
			string FeatureId;
			string Reason;
			bool ReasonFiledFlag = false;
			if(designationSummaryCount>=1)
			{
				for (int i=0; i<designationSummaryCount; i++)
				{
					trainrepo.DesignationSummary = i.ToString();
					FeatureId = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Designation_SummaryByIndex.TrackFeatureId.GetAttributeValue<string>("Text").Trim();
					Reason = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Designation_SummaryByIndex.Reason.GetAttributeValue<string>("Text").Trim();
					Ranorex.Report.Info(" "+FeatureId+" "+Reason+" ");
					if ((FeatureId == TrackFeatureId) && (Reason == ReasonField))
					{
						ReasonFiledFlag = true;
						break;
					}
				}
				if (ReasonFiledFlag)
				{
					Ranorex.Report.Success(" Reason Field Has updated as expected ");
				}
				else
				{
					Ranorex.Report.Failure("Reason Filed is not updated as expected ");
				}
			}
			else
			{
				Ranorex.Report.Failure("Summary Table is Empty to validate");
			}
			
		}
		
		/// <summary>
		/// To Validate Reason Summary Table in Restriction Summary
		/// </summary>
		/// <param name="Type">Input Type which reason should be validated</param>
		/// <param name="Reason">Input Reason To validate</param>
		/// <param name="StartMPValue">Input Start Mile post which reason should be validated</param>
		/// <param name="EndMPValue">Input End Mile Post which reason should be validated</param>
		[UserCodeMethod]
		public static void NS_ValidateReasonFieldRestrictionSummary(string Type, string StartMPValue, string EndMPValue, string Reason)
		{
			NS_OpenRestrictionSummaryTab();
			int restrictionSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Self.Rows.Count;
			Ranorex.Report.Info("count present in Summary Table " +restrictionSummaryCount+ " ");
			string TagType;
			string StartMP;
			string EndMP;
			string ReasonField;
			bool ReasonFieldValidationFlag = false;
			if (restrictionSummaryCount>=1)
			{
				for(int i=0; i<restrictionSummaryCount; i++)
				{
					trainrepo.RestrctionSummary = i.ToString();
					TagType = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.Type.GetAttributeValue<string>("Text").Trim();
					StartMP = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.StartMP.GetAttributeValue<string>("Text").Trim();
					EndMP = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.EndMP.GetAttributeValue<string>("Text").Trim();
					ReasonField = trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SummaryTablePane.Restriction_SummaryByIndex.Restrictions.Reason.GetAttributeValue<string>("Text").Trim();
					Ranorex.Report.Info(" "+TagType+", "+StartMP+", "+EndMP+" ");
					if ((TagType == Type) && (StartMP == StartMPValue) && (EndMP == EndMPValue) && (ReasonField == Reason))
					{
						ReasonFieldValidationFlag = true;
						break;
					}
				}
				if (ReasonFieldValidationFlag)
				{
					Ranorex.Report.Success(" Reason Filed is updated as expected ");
				}
				else
				{
					Ranorex.Report.Failure(" Reason Filed is not updated as expected ");
				}
			}
			else
			{
				Ranorex.Report.Failure("No Existing Summary Exist To Edit");
			}
		}
		
		/// <summary>
		/// To Validate Reason Summary Table in Clear Ahead Summary
		/// </summary>
		/// <param name="LampName">Input Lamp Name for which reason should be validated</param>
		/// <param name="Station">Input Station Name for which reason should be validated</param>
		/// <param name="ReasonField">Input Reason To validate</param>
		[UserCodeMethod]
		public static void NS_ValidateReasonFieldClearAheadSummary(string LampName, string Station, string ReasonField)
		{
			int clearAheadSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.Self.Rows.Count;
			Ranorex.Report.Info("count present in Summary Table " +clearAheadSummaryCount+ " ");
			string LampNameType;
			string StationType;
			string ReasonType;
			bool ReasonFieldFlag = false;
			if (clearAheadSummaryCount>=1)
			{
				for (int i=0; i<clearAheadSummaryCount; i++)
				{
					trainrepo.ClearAhead = i.ToString();
					LampNameType = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.LampName.GetAttributeValue<string>("Text").Trim();
					StationType = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.Station.GetAttributeValue<string>("Text").Trim();
					ReasonType = trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SummaryTablePane.ClearAhead_SummaryByIndex.Reason.GetAttributeValue<string>("Text").Trim();
					if ((LampNameType == LampName) && (StationType == Station) && (ReasonType == ReasonField))
					{
						ReasonFieldFlag = true;
						break;
					}
				}
				if(ReasonFieldFlag)
				{
					Ranorex.Report.Success(" Reason Field Has updated as expected ");
				}
				else
				{
					Ranorex.Report.Failure("Reason Field is not updated as expected ");
				}
			}
			else
			{
				Ranorex.Report.Info(" Summary Table is Empty to validate ");
			}
			
		}
		
		
		/// <summary>
		/// Close NVC Form
		/// </summary>
		[UserCodeMethod]
		public static void NS_CloseNVCForm()
		{
			int retries = 0;
			while (trainrepo.Network_Visibility_Console.SelfInfo.Exists(0) && retries < 3)
			{
				
				trainrepo.Network_Visibility_Console.WindowControls.Close.Click();
				retries++;
			}
		}
		
		//    	[UserCodeMethod]
		//    	public static void ValidateMovementElementContent (string trainSeed, string locationId, string content)
		//    	{
		//    		if (!IsNVCSummaryListOpen)
		//    		{
		//    			return;
		//    		}
//
		//    		trainrepo.Network_Visibility_Console.SummaryTabs.TrainSummary.Click();
		//    		int iterator = 0;
		//    		bool found = false; //TODO break thisout search into its own function
		//    		while (found == false && iterator < trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.Self.GetAttributeValue<int>("rowcount"))
		//    		{
		//    			trainrepo.SummaryIndex = iterator.ToString();
		//    			if (trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.TrainId.GetAttributeValue<string>("text").Contains(trainId))
		//    			{
		//    				found = true;
		//    			}
		//    			else
		//    			{
		//    				Ranorex.Report.Info("Found train: " + trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.TrainId.GetAttributeValue<string>("text"));
		//    				iterator++;
		//    			}
		//    		}
		//    		trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByRow.Trains.TrainId.Click();
		//    		//ClickAndWaitForValue in obj
		//    		//TODO validate the right train appeared in the details tab in the right handside
//
		//    	}
		
		/// <summary>
		/// Open NVC Form
		/// </summary>
		[UserCodeMethod]
		public static void NS_OpenNVCForm()
		{
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				//click windows menu
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
				                                          MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
				
				//click network visibility console
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrainsMenu.NetworkVisibilityConsoleInfo,
				                                          trainrepo.Network_Visibility_Console.SelfInfo);
				
				if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
				{
					Ranorex.Report.Failure("Failed to open NVC form");
				}
				else{
					Ranorex.Report.Success("NVC form opened");
				}
			}
			return;
		}
		
		
		[UserCodeMethod]
		public static void NS_ValidateTerritoryExistsUnderDivision_NVC(string division, string territory, bool expectExists)
		{
			bool actualExists = false;
			trainrepo.NVCDivision = division;
			trainrepo.NVCTerritory = division + ": " + territory;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			trainrepo.Network_Visibility_Console.TopologyTree.Self.Click(Location.CenterLeft);
			
			if(trainrepo.Network_Visibility_Console.TopologyTree.TerritoryInfo.Exists(0))
			{
				actualExists = true;
			}

			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected {"+territory+"} territory to exists as {"+expectExists+"} and actual found {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+territory+"} territory to exists as {"+expectExists+"} and actual found {"+actualExists+"}");
			}
		}
		
		public static bool NS_IsCheckBoxCheckedByPixel_NVC(Adapter checkBoxItem)
		{
			HashSet<Color> colorsFound = new HashSet<Color>();
			HashSet<Color> expectedColors = new HashSet<Color>();
			expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString("black"));
			expectedColors.Add(PDS_CORE.Code_Utils.PDSColors.GetColorFromString("nvccheckbox"));
			
			
			Bitmap originalImage = Imaging.CaptureImage(checkBoxItem);
            int x = Convert.ToInt32(6);
            int width = Convert.ToInt32(9);
            int y = Convert.ToInt32(6);
            int height = Convert.ToInt32(9);
            Rectangle cropTangle = new Rectangle(x, y, width, height);
            
            Bitmap itemImage = new Bitmap(cropTangle.Width, cropTangle.Height);
            Graphics itemGraphics = Graphics.FromImage(itemImage);
            itemGraphics.DrawImage(originalImage, -cropTangle.X, -cropTangle.Y);

            colorsFound = GeneralUtilities.GetColorsFromBitmap(itemImage);
			expectedColors.ExceptWith(colorsFound);
			
			if (expectedColors.Count == 0) {
                return true;
            }

            return false;
		}
		
		[UserCodeMethod]
		public static void NS_CheckTopologyDivisionCheckbox_NVC(string division, bool doCheck)
		{

			trainrepo.NVCDivision = division;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			
            bool isChecked = NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Division);
            
            if(doCheck && !isChecked)
            {
            	trainrepo.Network_Visibility_Console.TopologyTree.Division.Click(Location.CenterLeft);
            	if(!NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Division))
            	{
            		Ranorex.Report.Failure("Unable to check the Division checkbox");
            	}
            }
            else if(!doCheck && isChecked)
            {
            	trainrepo.Network_Visibility_Console.TopologyTree.Division.Click(Location.CenterLeft);
            	if(NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Division))
            	{
            		Ranorex.Report.Failure("Unable to uncheck the Division checkbox");
            	}
            }
		}
		
		[UserCodeMethod]
		public static void NS_ValidateTopologyTerritoryCheckbox_NVC(string division, string territory, bool expectChecked)
		{
			trainrepo.NVCDivision = division;
			trainrepo.NVCTerritory = division + ": " + territory;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			
			if(!trainrepo.Network_Visibility_Console.TopologyTree.TerritoryInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.TopologyTree.Self.Click(Location.CenterLeft);
			}

			bool isChecked = NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Territory);
			
			if(expectChecked == isChecked)
			{
				Ranorex.Report.Success("Expected checkbox {"+territory+"} territory to be checked status as {"+expectChecked+"} and found as {"+isChecked+"}.");
			}
			else
			{
				Ranorex.Report.Failure("Expected checkbox {"+territory+"} territory to be checked status as {"+expectChecked+"} and found as {"+isChecked+"}.");
			}
			
			trainrepo.Network_Visibility_Console.TopologyTree.Self.Click(Location.CenterLeft);
		}
		
		[UserCodeMethod]
		public static void NS_CheckTopologyTerritoryCheckbox_NVC(string division, string territory, bool doCheck)
		{
			trainrepo.NVCDivision = division;
			trainrepo.NVCTerritory = division + ": " + territory;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			
			if(!trainrepo.Network_Visibility_Console.TopologyTree.TerritoryInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.TopologyTree.Self.Click(Location.CenterLeft);
			}
            
			bool isChecked = NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Territory);
            
            if(doCheck && !isChecked)
            {
            	trainrepo.Network_Visibility_Console.TopologyTree.Territory.Click(Location.CenterLeft);
            	if(!NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Territory))
            	{
            		Ranorex.Report.Failure("Unable to check the Division checkbox");
            	}
            }
            else if(!doCheck && isChecked)
            {
            	trainrepo.Network_Visibility_Console.TopologyTree.Territory.Click(Location.CenterLeft);
            	if(NS_IsCheckBoxCheckedByPixel_NVC(trainrepo.Network_Visibility_Console.TopologyTree.Territory))
            	{
            		Ranorex.Report.Failure("Unable to uncheck the Division checkbox");
            	}
            }
		}
		
		[UserCodeMethod]
		public static void NS_ValidateDistrictExistsUnderTerritoryTree_NVC(string division, string territory, string district, bool expectExists)
		{
			bool actualExists = false;
			trainrepo.NVCDivision = division;
			trainrepo.NVCTerritory = division + ": " + territory;
			trainrepo.NVCDistrict = division + ": " + territory + ": " + district;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.Topology.TopologyButtonInfo,
			                                          trainrepo.Network_Visibility_Console.TopologyTree.DivisionInfo);
			
			if(trainrepo.Network_Visibility_Console.TopologyTree.DistrictInfo.Exists(0))
			{
				actualExists = true;
			}

			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected {"+district+"} territory to exists as {"+expectExists+"} and actual found {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+district+"} territory to exists as {"+expectExists+"} and actual found {"+actualExists+"}");
			}
		}
		
		/// <summary>
		/// Modify Application Options:
		///
        [UserCodeMethod]
		public static void NS_ModifyApplicationOptions_NVC(bool doCheckExpert,bool doCheckShowLocalTimeZones,bool doCheckShowTooltops,string selectMode, bool clickExit)
		{
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.NetworkVisibilityMenuButtonInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.SelfInfo);
			
			//check expert checkbox if doCheckExpert is true
			if(doCheckExpert && !trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckboxInfo);
			}
			else if(!doCheckExpert && trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckboxInfo);
			}
			
			//check show local Timezone checkbox if doCheckShowLocalTimeZones is true
			if(doCheckShowLocalTimeZones && !trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckboxInfo);
			}
			else if(!doCheckShowLocalTimeZones && trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckbox.Checked)
			{
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckboxInfo);
			}
			
			//check show tootops checkbox if doCheckShowTooltops is true
			if(doCheckShowTooltops && !trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckboxInfo);
			}
			else if(!doCheckShowTooltops && trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckboxInfo);
			}
			
			//set mode
			switch(selectMode.ToLower())
			{
				case "normal" :
					if (!trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeText.Text.Equals(selectMode)) {
						GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeTextInfo,
						                                          trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.SelfInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.NormalInfo,
						                                                  trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.SelfInfo);
					}
					break;
					
				case "playback" :
					if (!trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeText.Text.Equals(selectMode)) {
						GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeTextInfo,
						                                          trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.SelfInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.PlaybackInfo,
						                                                  trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeList.SelfInfo);
					}
					break;

				default:
					Ranorex.Report.Error("Please specify a valid mode type. Valid options are : Normal and Playback. Check data bindings and try again.");
					break;
			}
			
			
			if (clickExit)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.CloseButtonInfo,
				                                                  trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.SelfInfo);
			}
		}
		
		/// <summary>
		/// validate Application Options checkboxes:
		///
        [UserCodeMethod]
		public static void NS_ValidateApplicationOptionsChecked_NVC(string appOptionName, bool expectChecked)
		{
			bool actualChecked = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.NetworkVisibilityMenuButtonInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.SelfInfo);
			
			//check expert checkbox if doCheckExpert is true
			switch(appOptionName.ToLower())
			{
				case "expert" :
					if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckboxInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ExpertCheckbox.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Expert checkbox not found");
					}
					break;
					
				case "showlocaltimezones" :
					if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckboxInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowLocalTimezonesCheckbox.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show local timezones checkbox not found");
					}
					break;
					
					
				case "showtooltops" :
					if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckboxInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.ShowTooltipsCheckbox.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show tooltops checkbox not found");
					}
					break;
					
				default:
					Ranorex.Report.Error("Please specify a valid application options. Valid options are : expert, showlocaltimezones and showtooltops. Check data bindings and try again.");
					break;
					
			}
			
			if(actualChecked == expectChecked)
			{
				Ranorex.Report.Success("Expected checkbox :{"+appOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
			else{
				Ranorex.Report.Failure("Expected checkbox :{"+appOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
		}
		
		/// <summary>
		/// validate Application Options checkboxes:
		///
        [UserCodeMethod]
		public static void NS_ValidateSelectMode_ApplicationOptionsMenu_NVC(string selectMode, bool expectExists)
		{
			bool actualExists = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.NetworkVisibilityMenuButtonInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.ApplicationOptions.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeTextInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.NetworkVisibilityMenu.Mode.ModeText.GetAttributeValue<string>("SelectedItemText").Equals(selectMode,StringComparison.OrdinalIgnoreCase))
				{
					actualExists = true;
				}
			}else{
				Ranorex.Report.Error("Select mode option not found");
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Mode: {"+selectMode+"} selected to exists as {"+expectExists+"} and actual found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected Mode: {"+selectMode+"} selected to exists as {"+expectExists+"} and actual found as {"+actualExists+"}");
			}
		}
		
		/// <summary>
		/// Select the type of view required
		/// </summary>
		/// <param name="viewType"></param>
		[UserCodeMethod]
		public static void NS_SelectBasicViewType_NVC(string viewType)
		{
			NS_NVC.NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			switch(viewType.ToLower())
			{
					case "graph" : GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.ViewGraphInfo,
					                                                         trainrepo.Network_Visibility_Console.GraphPanelInfo);
					break;
					
					case "metrics" : GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.ViewMetricsInfo,
					                                                           trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo);
					break;
					
					case "summarylist" : GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.ViewSummaryListInfo,
					                                                               trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SelfInfo);
					break;
					
					default : Ranorex.Report.Error("Invalid view type: Valid options are : graph, metrics and summarylist. Check data bindings and try again");
					break;	
			}
		}
		
		/// <summary>
		/// Validates the type of view selected
		/// </summary>
		/// <param name="viewType"></param>
		/// <param name="expectedExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateBasicViewTypeExists_NVC(string viewType, bool expectedExists)
		{
			bool actualExists = false;
			
			switch(viewType.ToLower())
			{
				case "graph" :
					if(trainrepo.Network_Visibility_Console.GraphPanelInfo.Exists(0)){
						actualExists = true;
					}
					break;
					
				case "metrics" :
					if(trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0)){
						actualExists = true;
					}
					break;
					
				case "summarylist" :
					if(trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SelfInfo.Exists(0)){
						actualExists = true;
					}
					break;
					
				default :
					Ranorex.Report.Error("Invalid view type: Valid options are : graph, metrics and summarylist. Check data bindings and try again");
					break;
			}
			
			if(actualExists == expectedExists)
			{
				Ranorex.Report.Success("Expected {"+viewType+"} view to exists as {"+expectedExists+"} and found as {"+actualExists+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected {"+viewType+"} view to exists as {"+expectedExists+"} and found as {"+actualExists+"}.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_SelectTrainColoringMode_NVC(string colorTrainModeBy)
		{
			NS_NVC.NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			trainrepo.TrainColoringModeToolTipText = colorTrainModeBy;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.SelfInfo);
			if(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.TrainColoringModeByToolTipTextInfo.Exists(0))
			{
				Ranorex.Report.Info("TestStep", "Selecting Train coloring mode as {"+colorTrainModeBy+"}.");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.TrainColoringModeByToolTipTextInfo,
				                                                  trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.SelfInfo);
				                                                 
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.SelfInfo);
				Ranorex.Report.Error("Train coloring {"+colorTrainModeBy+"} mode not found ");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateTrainColoringModeSelected_NVC(string colorTrainModeBy, bool expectSelected)
		{
			bool actualSelected = false;
			
			NS_NVC.NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			trainrepo.ColorTrackByName = colorTrainModeBy;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.TrainColoringModeByToolTipTextInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.TrainColoringModeByToolTipText.GetAttributeValue<bool>("Selected"))
				{
					actualSelected = true;
				}
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.TrainColoringMode.TrainColoringModeList.SelfInfo);
				Ranorex.Report.Error("Train coloring mode {"+colorTrainModeBy+"} not found. Check data bindings and try again.");
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected {"+colorTrainModeBy+"} mode to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+colorTrainModeBy+"} mode to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyGeneralGraphOptionsCheckbox_NVC(bool doCheckShowTrainLabel, bool doCheckGroupTrainLabels, bool doCheckShowElementsBeyondResolved,bool doCheckShowUnplannedElements, bool doCheckShowOffTrackElements, bool doCheckShowLeaveRegionElements,bool doCheckSmoothFollowingTrains)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(doCheckShowTrainLabel && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabelsInfo);
			}
			else if(!doCheckShowTrainLabel && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabelsInfo);
			}
			
			if(doCheckGroupTrainLabels && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabels.Checked)
			{
				if(!trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Checked)
				{
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Click();
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabelsInfo);;
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Click();
				}else{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabelsInfo);
				}
			}
			else if(!doCheckGroupTrainLabels && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabels.Checked){
				if(!trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Checked)
				{
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Click();
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabelsInfo);
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Click();
				}else{
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabelsInfo);
				}
			}
			
			if(doCheckShowElementsBeyondResolved && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolvedInfo);
			}
			else if(!doCheckShowElementsBeyondResolved && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolvedInfo);
			}
			
			if(doCheckShowUnplannedElements && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElements.Checked)
			{
				if(!trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Checked)
				{
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Click();
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElementsInfo);
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Click();
				}else{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElementsInfo);
				}
			}
			else if(!doCheckShowUnplannedElements && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElements.Checked) {
				if(!trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Checked)
				{
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Click();
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElementsInfo);
					trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Click();
				}else{
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElementsInfo);
				}
			}
			
			if(doCheckShowOffTrackElements && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElements.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElementsInfo);
			}
			else if(!doCheckShowOffTrackElements && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElements.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElementsInfo);
			}
			
			if(doCheckShowLeaveRegionElements && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElements.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElementsInfo);
			}
			else if(!doCheckShowLeaveRegionElements && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElements.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElementsInfo);
			}
			
			if(doCheckSmoothFollowingTrains && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrains.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrainsInfo);
			}
			else if(!doCheckSmoothFollowingTrains && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrains.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrainsInfo);
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ValidateGeneralGraphOptionsCheckbox_NVC(string generalOptionName, bool expectChecked)
		{
			bool actualChecked = false;
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			
			switch(generalOptionName.ToLower())
			{
				case "showtrainlabels" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabelsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowTrainLabels.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show Train label not found");
					}
					break;
					
				case "grouptrainlabels" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabelsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.GroupTrainLabels.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Group Train labels not found");
					}
					break;
					
					
					
				case "showelementsbeyondresolved" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolvedInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowElementsBeyondResolved.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show Elements Beyond Resolved checkbox not found");
					}
					break;
					
				case "showunplannedelements" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElementsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowUnplannedElements.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show Unplanned Elements Info checkbox not found");
					}
					break;
					
				case "showofftrackelements" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElementsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowOffTrackElements.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show Off Track Elements checkbox not found");
					}
					break;
					
				case "showleaveregionelements" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElementsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.ShowLeaveRegionElements.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Show Leave Region Elements checkbox not found");
					}
					break;
					
				case "smoothfollowingtrains" :
					if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrainsInfo.Exists(0))
					{
						if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SmoothFollowingTrains.Checked)
						{
							actualChecked = true;
						}
					}
					else{
						Ranorex.Report.Error("Smooth Following Trains checkbox not found");
					}
					break;
					
				default:
					Ranorex.Report.Error("Please specify a valid application options. Valid options are :  showtrainlabels, grouptrainlabels, showelementsbeyondresolved, showunplannedelements, showofftrackelements, showleaveregionelements and smoothfollowingtrains. Check data bindings and try again.");
					break;
					
			}
			
			if(actualChecked == expectChecked)
			{
				Ranorex.Report.Success("Expected checkbox :{"+generalOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
			else{
				Ranorex.Report.Failure("Expected checkbox :{"+generalOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyAnimationSpeed_GraphOptions_NVC(string animationSpeed)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.AnimationSpeedInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.AnimationSpeed.Click();
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.AnimationSpeed.Element.SetAttributeValue("Text",animationSpeed);
			}
			else{
				Ranorex.Report.Error("Animation speed option not found");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateAnimationSpeed_GraphOptions_NVC(string animationSpeed, bool expectExist)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			bool actualExists = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.AnimationSpeedInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.AnimationSpeed.GetAttributeValue<string>("Text").Equals(animationSpeed))
				{
					actualExists = true;
				}
			}
			else{
				Ranorex.Report.Error("Animation speed option not found");
			}
			
			if(actualExists == expectExist)
			{
				Ranorex.Report.Success("Expected animation speed:{"+animationSpeed+"} to be exists as {"+expectExist+"} and actual found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected animation speed:{"+animationSpeed+"} to be exists as {"+expectExist+"} and actual found as {"+actualExists+"}");
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ModifyMouseHitProximity_GraphOptions_NVC(string mouseHitProximity)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.MouseHitProximityInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.MouseHitProximity.Click();
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.MouseHitProximity.Element.SetAttributeValue("Text",mouseHitProximity);
			}
			else{
				Ranorex.Report.Error("Mouse Hit Proximity option not found");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateMouseHitProximity_GraphOptions_NVC(string mouseHitProximity, bool expectExist)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			bool actualExists = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.MouseHitProximityInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.MouseHitProximity.GetAttributeValue<string>("Text").Equals(mouseHitProximity))
				{
					actualExists = true;
				}
			}
			else{
				Ranorex.Report.Error("Mouse Hit Proximity option not found");
			}
			
			if(actualExists == expectExist)
			{
				Ranorex.Report.Success("Expected Mouse Hit Proximity value:{"+mouseHitProximity+"} to be exists as {"+expectExist+"} and actual found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected Mouse Hit Proximity value:{"+mouseHitProximity+"} to be exists as {"+expectExist+"} and actual found as {"+actualExists+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyGeneralTimeOptions_GraphOptions_NVC(string timeOption)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			trainrepo.TimeOption = timeOption.ToUpper();
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.TimeOptions.TimeMenuItemInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeList.TimeOptionByNameInfo.Exists(0))
			{
				Ranorex.Report.Info("TestStep", "Selecting Time option as {"+timeOption+"}.");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeList.TimeOptionByNameInfo,
				                                                  trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeList.SelfInfo);
				                                                 
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.TimeOptions.TimeMenuItemInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeList.SelfInfo);
				Ranorex.Report.Error("Time option not found ");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateGeneralTimeOptions_GraphOptions_NVC(string timeOption, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			bool actualSelected = false;
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.General.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.TimeOptionList.TimeOptionText.GetAttributeValue<string>("SelectedItemText").Equals(timeOption,StringComparison.OrdinalIgnoreCase))
			{
				actualSelected = true;
			}
	
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected {"+timeOption+"} Time option to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+timeOption+"} Time option to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}");
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ModifyIconsGraphOptionsCheckbox_NVC(string iconOptionCheckboxName, bool doCheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.SelfInfo);
			
			trainrepo.IconsCheckboxName = iconOptionCheckboxName;
				
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByNameInfo.Exists(0))
			{
				if(doCheck && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByName.Checked)
				{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByNameInfo);
				}
				else if(!doCheck && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByName.Checked){
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByNameInfo);
				}
			}else{
				Ranorex.Report.Error("Icons Option checkbox not found");
			}
			
		}
		
		[UserCodeMethod]
		public static void NS_ValidateIconsGraphOptionsCheckbox_NVC(string iconOptionCheckboxName, bool expectChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.SelfInfo);
			
			trainrepo.IconsCheckboxName = iconOptionCheckboxName;
			bool actualChecked = false;	
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByNameInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Icons.IconsOptionsCheckbox.IconsOptionCheckboxByName.Checked)
				{
					actualChecked = true;
				}
			}else{
				Ranorex.Report.Error("Icons Option checkbox not found");
			}
			
			
			if(actualChecked == expectChecked)
			{
				Ranorex.Report.Success("Expected checkbox :{"+iconOptionCheckboxName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
			else{
				Ranorex.Report.Failure("Expected checkbox :{"+iconOptionCheckboxName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ModifyShowInputVariationCheckbox_TrainVariability_GraphOptions_NVC(bool doCheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckboxInfo.Exists(0))
			{
				if(doCheck && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked)
				{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckboxInfo);
				}
				else if(!doCheck && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked){
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckboxInfo);
				}
			}else{
				Ranorex.Report.Error("Show Input Variation checkbox not found");
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ValidateShowInputVariationOptionsEnabled_TrainVariability_NVC(string inputVariationOptionName, bool isEnabled)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			
			trainrepo.InputVariatonOptionName = inputVariationOptionName;

			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByNameInfo.Exists(0))
			{
				GeneralUtilities.CheckFieldEnableDisable(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByNameInfo, isEnabled);
			}
			else{
				Ranorex.Report.Error(inputVariationOptionName+"Checkbox not found");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC(string inputVariationOptionName, bool doCheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			
			trainrepo.InputVariatonOptionName = inputVariationOptionName;
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked)
			{
				if(doCheck && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByName.Checked)
				{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByNameInfo);
				}
				else if(!doCheck && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByName.Checked){
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByNameInfo);	
				}
			}else{
				Ranorex.Report.Error("Show Input Variation checkbox not checked. Hence the "+inputVariationOptionName+" checkbox is disabled");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateTrainVariabilityOptionsCheckbox_NVC(string inputVariationOptionName, bool expectChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			
			trainrepo.InputVariatonOptionName = inputVariationOptionName;
			bool actualChecked = false;	
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked)
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptionsByName.Checked)
				{
					actualChecked = true;
				}
					
			}else{
				Ranorex.Report.Error("Show Input Variation checkbox not checked. Hence the "+inputVariationOptionName+" checkbox is disabled");
			}
			
			
			if(actualChecked == expectChecked)
			{
				Ranorex.Report.Success("Expected checkbox :{"+inputVariationOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
			else{
				Ranorex.Report.Failure("Expected checkbox :{"+inputVariationOptionName+"} to be checked as {"+expectChecked+"} and actual found as {"+actualChecked+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyPerformanceDifferenceThresholdValue_TrainVariability_NVC(string thresholdValue, string thresholdUnit)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked)
			{
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdValueText.Element.SetAttributeValue("Text",thresholdValue);
				GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitsMenuItemInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitList.SelfInfo);
				switch(thresholdUnit.ToLower())
				{
					case "minutes" :
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitList.MINUTESInfo,
						                                                  trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitList.SelfInfo);
						break;
						
					case "seconds" :
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitList.SECONDSInfo,
						                                                  trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitList.SelfInfo);
						break;
						
					default :
						Ranorex.Report.Error("Invalid option. Valid options are : minutes and seconds. Please check data bindings and try again.");
						break;
				}
				
			}else{
				Ranorex.Report.Error("Show Input Variation checkbox not checked. Hence the Performance Difference threshold value is disabled");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC(string thresholdValue, string thresholdUnit, bool expectExists)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.TrainVariabilityBoxInfo);
			bool actualExists = false;
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.InputVariationOptions.ShowInputVariationCheckbox.Checked)
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdValueText.GetAttributeValue<string>("Text").Equals(thresholdValue,StringComparison.OrdinalIgnoreCase) && 
				   trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.TrainVariability.ThresholdValue.ThresholdUnitText.GetAttributeValue<string>("Text").Equals(thresholdUnit,StringComparison.OrdinalIgnoreCase))
				{
					actualExists = true;
				}
			}else{
				Ranorex.Report.Error("Show Input Variation checkbox not checked. Hence the Performance Difference threshold value is disabled");
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected value & Unit as:{"+thresholdValue+"} & {"+thresholdUnit+"} to be exists as {"+expectExists+"} and actual found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected value & Unit as:{"+thresholdValue+"} & {"+thresholdUnit+"} to be exists as {"+expectExists+"} and actual found as {"+actualExists+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ToggleStationLabels_GraphOption_NVC(string selectStationLabel)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			
			switch(selectStationLabel.ToLower())
			{
					case "opsta" : GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.OPSTA);
					break;
					
					case "stationname" : GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.StationName);
					break;
					
					default : Ranorex.Report.Error("Invalid option. Valid options are : opsta and stationname. Check data bindings and try again.");
					break;
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateStationLabelSelected_GraphOption_NVC(string stationLabel, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			bool actualSelected = false;
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			
			switch(stationLabel.ToLower())
			{
					case "opsta" : if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.OPSTA.GetAttributeValue<bool>("Selected")){
						actualSelected = true;
					}
					break;
					
					case "stationname" : if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.StationName.GetAttributeValue<bool>("Selected")){
						actualSelected = true;
					}
					break;
					
					default : Ranorex.Report.Error("Invalid option. Valid options are : opsta and stationname. Check data bindings and try again.");
					break;
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected station label {"+stationLabel+"} to be selected as {"+expectSelected+"} and found as {"+actualSelected+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected station label {"+stationLabel+"} to be selected as {"+expectSelected+"} and found as {"+actualSelected+"}.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateShowStateAbbreviationCheckboxEnabled_StationLabels_NVC(bool isEnabled)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			

			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviationsInfo.Exists(0))
			{
				GeneralUtilities.CheckFieldEnableDisable(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviationsInfo, isEnabled);
			}
			else{
				Ranorex.Report.Error("Show State Abbreviation Checkbox not found");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyShowStateAbbreviationCheckbox_StationLabels_NVC(bool docheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.StationName.GetAttributeValue<bool>("Selected"))
			{
				if(docheck && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviations.Checked)
				{
					GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviationsInfo);
				}
				else if(!docheck && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviations.Checked){
					GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviationsInfo);
				}
			}
			else{
				Ranorex.Report.Failure("Show State Abbreviation Checkbox is disabled");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateShowStateAbbreviationChecked_StationLabels_NVC(bool isChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.StationName.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.ShowStateAbbreviationsInfo, isChecked);
			}
			else{
				Ranorex.Report.Failure("Show State Abbreviation Checkbox is disabled");
			}
		}
		
		[UserCodeMethod]
		public static void NS_SetMaximumLevelsValue_StationLabels_NVC(string maxLevelValue)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.MaximumLevelsTextInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.MaximumLevelsText.Click();
				trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.MaximumLevelsText.Element.SetAttributeValue("Text",maxLevelValue);
			}
			else{
				Ranorex.Report.Failure("Maximun Level input box not found.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateMaximumLevelsValue_StationLabels_NVC(string maxLevelValue, bool expectExists)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			bool actualExists = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.MaximumLevelsTextInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.StationLabels.StationLabelsOptions.MaximumLevelsText.GetAttributeValue<string>("Text").Equals(maxLevelValue,StringComparison.OrdinalIgnoreCase))
				{
					actualExists = true;					
				}
			}
			else{
				Ranorex.Report.Failure("Maximun Level input box not found.");
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Maximum level value {"+maxLevelValue+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected Maximum level value {"+maxLevelValue+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_SelectTrainOnTrack_TrackOptions_NVC(string trainOnTrackOption)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			trainrepo.TrainOnTrackName = trainOnTrackOption;
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackList.TrainOnTrackListItemByTrainOnTrackNameInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackList.TrainOnTrackListItemByTrainOnTrackNameInfo,
				                                         		trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackList.SelfInfo);
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackList.SelfInfo);
				Ranorex.Report.Error("Train On Track {"+trainOnTrackOption+"} Option not found.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateTrainOnTrackSelected_TrackOptions_NVC(string trainOnTrackOption, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			bool actualSelected = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);

			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.TrainOnTrack.TrainsOnTrackText.GetAttributeValue<string>("SelectedItemText").Equals(trainOnTrackOption,StringComparison.OrdinalIgnoreCase))
			{
				actualSelected = true;
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected train on track option {"+trainOnTrackOption+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected train on track option {"+trainOnTrackOption+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
		}
		
		/// <summary>
		/// selects color track option using approx. shortname
		/// </summary>
		/// <param name="colorTrackByOption"></param>
		[UserCodeMethod]
		public static void NS_SelectColorTrackBy_TrackOptions_NVC(string colorTrackByOption)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			trainrepo.ColorTrackByName = colorTrackByOption;
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByList.ColorTrackByListItemByColorTrackByNameInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByList.ColorTrackByListItemByColorTrackByNameInfo,
				                                         		trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByList.SelfInfo);
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByList.SelfInfo);
				Ranorex.Report.Error("Color track by Option not found.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateColorTrackBySelected_TrackOptions_NVC(string colorTrackByOption, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			bool actualSelected = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);

			if(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ColorTrackBy.ColorTrackByText.GetAttributeValue<string>("SelectedItemText").Contains(colorTrackByOption))
			{
				actualSelected = true;
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected Color track by option {"+colorTrackByOption+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected Color track by option {"+colorTrackByOption+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
		}
		
		/// <summary>
		/// Modify Application Options:
		///
        [UserCodeMethod]
		public static void NS_ModifyTrackOptions_NVC(bool doCheckShowFirstOverTrack ,bool doCheckShowUnblockableCrossings,bool doCheckShowDisconnectedTracks, bool doCheckCompensateForCrossingsWithGaps)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,
			                                          trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			//check ShowFirstOverTrack checkbox if doCheckShowFirstOverTrack is true
			if(doCheckShowFirstOverTrack && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowFirstOverTrack.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowFirstOverTrackInfo);
			}
			else if(!doCheckShowFirstOverTrack && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowFirstOverTrack.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowFirstOverTrackInfo);
			}
			
			//check Show Unblockable Crossings checkbox if doCheckShowUnblockableCrossings is true
			if(doCheckShowUnblockableCrossings && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowUnblockableCrossings.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowUnblockableCrossingsInfo);
			}
			else if(!doCheckShowUnblockableCrossings && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowUnblockableCrossings.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowUnblockableCrossingsInfo);
			}
			
			//check Show Disconnected Tracks checkbox if doCheckShowDisconnectedTracks is true
			if(doCheckShowDisconnectedTracks && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowDisconnectedTracks.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowDisconnectedTracksInfo);
			}
			else if(!doCheckShowDisconnectedTracks && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowDisconnectedTracks.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowDisconnectedTracksInfo);
			}
			
			//check Compensate For Crossings With Gaps checkbox if doCheckCompensateForCrossingsWithGaps is true
			if(doCheckCompensateForCrossingsWithGaps && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.CompensateForCrossingsWithGaps.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.CompensateForCrossingsWithGapsInfo);
			}
			else if(!doCheckCompensateForCrossingsWithGaps && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.CompensateForCrossingsWithGaps.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.CompensateForCrossingsWithGapsInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateTrackOptionsCheckbox_NVC(bool isShowFirstOverTrackChecked, bool isShowUnblockableCrossingsChecked,bool isShowDisconnectedChecked, bool isCompensateForCrossingsWithGapsChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowFirstOverTrackInfo, isShowFirstOverTrackChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowUnblockableCrossingsInfo, isShowUnblockableCrossingsChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.ShowDisconnectedTracksInfo, isShowDisconnectedChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.Track.CompensateForCrossingsWithGapsInfo, isCompensateForCrossingsWithGapsChecked);
		}
		
		/// <summary>
		/// Check or Uncheck Dispatch Constraints Checkboxes
		/// </summary>
		/// <param name="checkSpeedRestrictions"></param>
		/// <param name="checkTrackBlock"></param>
		/// <param name="checkMofWReservations"></param>
		/// <param name="checkAuthoritiesToTrains"></param>
		/// <param name="checkOtherAuthorities"></param>
		/// <param name="checkStopShort"></param>
		/// <param name="checkPermissionToEnterMain"></param>
		/// <param name="checkSwitchBlock"></param>
		/// <param name="checkSignalAuthority"></param>
		/// <param name="checkInferredSignalAuthorities"></param>
		/// <param name="checkSignalBlock"></param>
		[UserCodeMethod]
		public static void NS_ModifyDispatchConstraintsCheckbox_NVC(bool checkSpeedRestrictions, bool checkTrackBlock, bool checkMofWReservations, bool checkAuthoritiesToTrains, bool checkOtherAuthorities, bool checkStopShort, 
		                                                            bool checkPermissionToEnterMain, bool checkSwitchBlock, bool checkSignalAuthority, bool checkInferredSignalAuthorities, bool checkSignalBlock)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			//check Speed Restrictions checkbox if checkSpeedRestrictions is true
			if(checkSpeedRestrictions && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SpeedRestrictionCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SpeedRestrictionCheckboxInfo);
			}
			else if(!checkSpeedRestrictions && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SpeedRestrictionCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SpeedRestrictionCheckboxInfo);
			}
			
			//check Track Block checkbox if checkTrackBlock is true
			if(checkTrackBlock && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.TrackBlockCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.TrackBlockCheckboxInfo);
			}
			else if(!checkTrackBlock && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.TrackBlockCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.TrackBlockCheckboxInfo);
			}
			
			//check MofW Reservations checkbox if checkMofWReservations is true
			if(checkMofWReservations && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.MofWReservationsCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.MofWReservationsCheckboxInfo);
			}
			else if(!checkMofWReservations && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.MofWReservationsCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.MofWReservationsCheckboxInfo);
			}
			
			//check Authorities To Trains checkbox if checkAuthoritiesToTrains is true
			if(checkAuthoritiesToTrains && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.AuthoritiesToTrainsCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.AuthoritiesToTrainsCheckboxInfo);
			}
			else if(!checkAuthoritiesToTrains && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.AuthoritiesToTrainsCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.AuthoritiesToTrainsCheckboxInfo);
			}
			
			//check Other Authorities checkbox if checkOtherAuthorities is true
			if(checkOtherAuthorities && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.OtherAuthoritiesCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.OtherAuthoritiesCheckboxInfo);
			}
			else if(!checkOtherAuthorities && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.OtherAuthoritiesCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.OtherAuthoritiesCheckboxInfo);
			}
			
			//check Stop Short checkbox if checkStopShort is true
			if(checkStopShort && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.StopShortCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.StopShortCheckboxInfo);
			}
			else if(!checkStopShort && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.StopShortCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.StopShortCheckboxInfo);
			}
			
			//check Permission To Enter Main checkbox if checkPermissionToEnterMain is true
			if(checkPermissionToEnterMain && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.PermissionToEnterMainCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.PermissionToEnterMainCheckboxInfo);
			}
			else if(!checkPermissionToEnterMain && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.PermissionToEnterMainCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.PermissionToEnterMainCheckboxInfo);
			}
			
			//check Switch Block checkbox if checkSwitchBlock is true
			if(checkSwitchBlock && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SwitchBlockCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SwitchBlockCheckboxInfo);
			}
			else if(!checkSwitchBlock && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SwitchBlockCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SwitchBlockCheckboxInfo);
			}
			
			
			//check Signal Authority checkbox if checkSignalAuthority is true
			if(checkSignalAuthority && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalAuthorityCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalAuthorityCheckboxInfo);
			}
			else if(!checkSignalAuthority && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalAuthorityCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalAuthorityCheckboxInfo);
			}
			
			//check Inferred Signal Authorities checkbox if checkInferredSignalAuthorities is true
			if(checkInferredSignalAuthorities && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.InferredSignalAuthoritiesCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.InferredSignalAuthoritiesCheckboxInfo);
			}
			else if(!checkInferredSignalAuthorities && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.InferredSignalAuthoritiesCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.InferredSignalAuthoritiesCheckboxInfo);
			}
			
			//check Signal Block checkbox if checkSignalBlock is true
			if(checkSignalBlock && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalBlockCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalBlockCheckboxInfo);
			}
			else if(!checkSignalBlock && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalBlockCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalBlockCheckboxInfo);
			}
		}
		
		/// <summary>
		/// Validate Dispatch Constraints Checkbox checked status
		/// </summary>
		/// <param name="isSpeedRestrictionsChecked"></param>
		/// <param name="isTrackBlockChecked"></param>
		/// <param name="isMofWReservationsChecked"></param>
		/// <param name="isAuthoritiesToTrainsChecked"></param>
		/// <param name="isOtherAuthoritiesChecked"></param>
		/// <param name="isStopShortChecked"></param>
		/// <param name="isPermissionToEnterMainChecked"></param>
		/// <param name="isSwitchBlockChecked"></param>
		/// <param name="isSignalAuthorityChecked"></param>
		/// <param name="isInferredSignalAuthoritiesChecked"></param>
		/// <param name="isSignalBlockChecked"></param>
		[UserCodeMethod]
		public static void NS_ValidateDispatchConstraintsCheckbox_NVC(bool isSpeedRestrictionsChecked, bool isTrackBlockChecked, bool isMofWReservationsChecked, bool isAuthoritiesToTrainsChecked, bool isOtherAuthoritiesChecked, bool isStopShortChecked, 
		                                                              bool isPermissionToEnterMainChecked, bool isSwitchBlockChecked, bool isSignalAuthorityChecked, bool isInferredSignalAuthoritiesChecked, bool isSignalBlockChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
		
			//Validate checkboxes
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SpeedRestrictionCheckboxInfo, isSpeedRestrictionsChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.TrackBlockCheckboxInfo, isTrackBlockChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.MofWReservationsCheckboxInfo, isMofWReservationsChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.AuthoritiesToTrainsCheckboxInfo, isAuthoritiesToTrainsChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.OtherAuthoritiesCheckboxInfo, isOtherAuthoritiesChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.StopShortCheckboxInfo, isStopShortChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.PermissionToEnterMainCheckboxInfo, isPermissionToEnterMainChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SwitchBlockCheckboxInfo, isSwitchBlockChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalAuthorityCheckboxInfo, isSignalAuthorityChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.InferredSignalAuthoritiesCheckboxInfo, isInferredSignalAuthoritiesChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.DispatchConstraints.SignalBlockCheckboxInfo, isSignalBlockChecked);
		}
		
		/// <summary>
		/// Check or uncheck Planner Track Restrictions Checkbox
		/// </summary>
		/// <param name="checkBlock"></param>
		/// <param name="checkSystemActivityBlock"></param>
		/// <param name="checkSpeedRestriction"></param>
		/// <param name="checkPreventDwell"></param>
		/// <param name="checkCurrentOfTraffic"></param>
		[UserCodeMethod]
		public static void NS_ModifyPlannerTrackRestrictionsCheckbox_NVC(bool checkBlock, bool checkSystemActivityBlock, bool checkSpeedRestriction, bool checkPreventDwell, bool checkCurrentOfTraffic)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			//check Block checkbox if checkBlock is true
			if(checkBlock && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.BlockCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.BlockCheckboxInfo);
			}
			else if(!checkBlock && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.BlockCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.BlockCheckboxInfo);
			}
			
			//check System Activity Block checkbox if checkSystemActivityBlock is true
			if(checkSystemActivityBlock && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SystemActivityBlockCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SystemActivityBlockCheckboxInfo);
			}
			else if(!checkSystemActivityBlock && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SystemActivityBlockCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SystemActivityBlockCheckboxInfo);
			}
			
			//check Speed Restriction checkbox if checkSpeedRestriction is true
			if(checkSpeedRestriction && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SpeedRestrictionCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SpeedRestrictionCheckboxInfo);
			}
			else if(!checkSpeedRestriction && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SpeedRestrictionCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SpeedRestrictionCheckboxInfo);
			}
			
			//check Prevent Dwell checkbox if checkPreventDwell is true
			if(checkPreventDwell && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.PreventDwellCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.PreventDwellCheckboxInfo);
			}
			else if(!checkPreventDwell && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.PreventDwellCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.PreventDwellCheckboxInfo);
			}
			
			//check CurrentOfTraffic checkbox if checkCurrentOfTraffic is true
			if(checkCurrentOfTraffic && !trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.CurrentOfTrafficCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.CurrentOfTrafficCheckboxInfo);
			}
			else if(!checkCurrentOfTraffic && trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.CurrentOfTrafficCheckbox.Checked){
				GeneralUtilities.UnCheckCheckboxAdapterAndVerify(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.CurrentOfTrafficCheckboxInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePlannerTrackRestrictionsCheckbox_NVC(bool isBlockChecked, bool isSystemActivityBlockChecked, bool isSpeedRestrictionChecked, bool isPreventDwellChecked, bool isCurrentOfTrafficChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsTextInfo,trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsMenuFormInfo);
			
			//Validate checkboxes
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.BlockCheckboxInfo, isBlockChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SystemActivityBlockCheckboxInfo, isSystemActivityBlockChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.SpeedRestrictionCheckboxInfo, isSpeedRestrictionChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.PreventDwellCheckboxInfo, isPreventDwellChecked);
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.MenuBar.GraphOptionsMenu.GraphOptionsForm.PlannerTrackRestrictions.CurrentOfTrafficCheckboxInfo, isCurrentOfTrafficChecked);
		}
		
				/// <summary>
		/// Takes screenshot and save the file with given fileName
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="clickSave"></param>
		/// <param name="clickCancel"></param>
		[UserCodeMethod]
		public static void NS_SaveScreenshotOfGraph_NVC(string fileName, bool clickSave, bool clickCancel)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.Screenshot.ScreenshotButtonInfo,trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.SelfInfo);
			
			trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.FileName.Element.SetAttributeValue("Text",fileName);
			
			if(clickSave)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.SaveButtonInfo,
				                                                  trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.SelfInfo);
			}
			
			if(clickCancel && !clickSave)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.CancelButtonInfo,
				                                                  trainrepo.Network_Visibility_Console.Screenshot.SaveScreenshotPane.SelfInfo);
			}
		}
		
		/// <summary>
		/// Print the NVC graph
		/// </summary>
		/// <param name="clickOK"></param>
		/// <param name="clickCancel"></param>
		[UserCodeMethod]
		public static void NS_PrintGraph_NVC(bool clickOK, bool clickCancel)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.Print.PrintButtonInfo,trainrepo.Network_Visibility_Console.Print.PrintDialogBox.SelfInfo);
			
			int retries =0;
			while(!trainrepo.Network_Visibility_Console.Print.PrintDialogBox.SelfInfo.Exists(0) && retries<5)
			{
				Ranorex.Delay.Seconds(5);
				retries++;
			}
			
			if(clickOK)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.Print.PrintDialogBox.OKButtonInfo,
				                                                  trainrepo.Network_Visibility_Console.Print.PrintDialogBox.SelfInfo);
			}
			
			if(clickCancel && !clickOK)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.Print.PrintDialogBox.CancelButtonInfo,
				                                                  trainrepo.Network_Visibility_Console.Print.PrintDialogBox.SelfInfo);
			}
		}
		
		/// <summary>
		/// Start , Stop or Sync NVC Graph Animation
		/// </summary>
		/// <param name="startAnimation"></param>
		/// <param name="stopAnimation"></param>
		/// <param name="syncAnimation"></param>
		[UserCodeMethod]
		public static void NS_ToggleAnimationControls_NVC(string toggleName)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			switch(toggleName.ToLower())
			{
				case "start" :
					if(!trainrepo.Network_Visibility_Console.AnimationControls.StartAnimationToggle.Checked)
					{
						GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.AnimationControls.StartAnimationToggleInfo);
					}
					break;
					
				case "stop" :
					if(!trainrepo.Network_Visibility_Console.AnimationControls.StopAnimationToggle.Checked)
					{
						GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.AnimationControls.StopAnimationToggleInfo);
					}
					break;
					
				case "sync" :
					if(!trainrepo.Network_Visibility_Console.AnimationControls.SyncAnimationToggle.Checked)
					{
						GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.AnimationControls.SyncAnimationToggleInfo);
					}
					break;
					
				default :
					Ranorex.Report.Error("Invalid option. Valid options are : start, stop and sync. Check data bindings and try again.");
					break;
			}
		}
		
		/// <summary>
		/// Validate NVC Graph animation Toggles
		/// </summary>
		/// <param name="toggleName"></param>
		/// <param name="expectChecked"></param>
		[UserCodeMethod]
		public static void NS_ValidateAnimationControlToggleSelected_NVC(string toggleName, bool expectChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			switch(toggleName.ToLower())
			{
					case "start" : GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.AnimationControls.StartAnimationToggleInfo , expectChecked);
					break;
					
					case "stop" :	GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.AnimationControls.StopAnimationToggleInfo , expectChecked);
					break;
					
					case "sync" : GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.AnimationControls.SyncAnimationToggleInfo , expectChecked);
					break;
					
					default : Ranorex.Report.Error("Invalid option. Valid options are : start, stop and sync. Check data bindings and try again.");
					break;
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyGraphZoom_NVC(string zoomFunction)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			string initialValue = trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemText.GetAttributeValue<string>("SelectedItemText");
			
			switch(zoomFunction.ToLower())
			{
				case "zoomin" :
					
					Ranorex.Report.Info("TestStep", "Clicking Zoom In button");
					trainrepo.Network_Visibility_Console.GraphZoom.ZoomInButton.Click();
					while(initialValue == trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemText.GetAttributeValue<string>("SelectedItemText"))
					{
						trainrepo.Network_Visibility_Console.GraphZoom.ZoomInButton.Click();
					}
					break;
				
				case "zoomout" :
				
					Ranorex.Report.Info("TestStep", "Clicking Zoom Out button");
					trainrepo.Network_Visibility_Console.GraphZoom.ZoomOutButton.Click();
					while(initialValue == trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemText.GetAttributeValue<string>("SelectedItemText"))
					{
						trainrepo.Network_Visibility_Console.GraphZoom.ZoomOutButton.Click();
					}
					break;
				
				default : 
					Ranorex.Report.Error("Invalid option. Valid options are : zoomin and zoomout. Check data bindings and try again.");
					break;
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateGraphZoomSelectedValue_NVC(int zoomValue, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			bool actualSelected = false;
			float ZoomValueDecimal = (float) zoomValue/100;
			
			if(trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemText.GetAttributeValue<string>("SelectedItemText").Equals(ZoomValueDecimal.ToString(),StringComparison.OrdinalIgnoreCase))
			{
				actualSelected = true;
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected Zoom value {"+zoomValue+"%} to be selected as {"+expectSelected+"} and found as {"+actualSelected+"}");
			}
			else{
				Ranorex.Report.Failure("Expected Zoom value {"+zoomValue+"%} to be selected as {"+expectSelected+"} and found as {"+actualSelected+"}");
			}
		}
		
		[UserCodeMethod]
		public static void NS_SelectGraphZoom_NVC(int zoomValue)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

	        float ZoomValueDecimal = (float) zoomValue/100;
			trainrepo.ZoomValue = (zoomValue%100 == 0)?ZoomValueDecimal.ToString("0.0"):ZoomValueDecimal.ToString();
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemTextInfo,
			                                          trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuList.ZoomMenuListItemByValueInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuList.ZoomMenuListItemByValueInfo,
				                                                  trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuList.SelfInfo);
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuItemTextInfo,
			                                          trainrepo.Network_Visibility_Console.GraphZoom.ZoomMenuList.SelfInfo);
				Ranorex.Report.Error("Please specify a valid zoom value. Check data bindings and try again.");
			}
		}
		
		/// <summary>
		/// Selects Region based on REgion ID in plan metrics
		/// </summary>
		/// <param name="regionID"></param>
		[UserCodeMethod]
		public static void NS_SelectPlanMetricsRegion_NVC(string regionID)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			trainrepo.RegionID = regionID;
			
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;					
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectRegionTextInfo,
			                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.SelfInfo);
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.RegionByIDInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.RegionByIDInfo,
				                                                  trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.SelfInfo);
			}
			else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectRegionTextInfo,
				                                                  trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.SelfInfo);
				Ranorex.Report.Error("Region id not found. Check data bindings and try again.");
			}
		}
		
		/// <summary>
		/// Validates Selected Region ID of Plan Metrics
		/// </summary>
		/// <param name="regionID"></param>
		/// <param name="isSelected"></param>
		[UserCodeMethod]
		public static void NS_ValidatePlanMetricsRegionSelected_NVC(string regionID, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			trainrepo.RegionID = regionID;
			
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			bool actualSelected = false;
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectRegionTextInfo,
			                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.SelfInfo);
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.RegionByIDInfo.Exists(0))
			{
				if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.RegionByID.GetAttributeValue<bool>("Selected"))
				{
					actualSelected = true;
				}
			}else{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectRegionTextInfo,
				                                                  trainrepo.Network_Visibility_Console.PlanMetricsPane.RegionList.SelfInfo);
				Ranorex.Report.Error("Region id not found. Check data bindings and try again.");
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected Region ID :{"+regionID+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected Region ID :{"+regionID+"} to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
		}
		
		
		/// <summary>
		///  toggles between Train Group Tab and Request Statistics Tab of Plan Metrics
		/// </summary>
		/// <param name="tabName"></param>
		[UserCodeMethod]
		public static void NS_TogglePlanMetricsTab_NVC(string tabName)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			NS_SelectBasicViewType_NVC("metrics");
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			switch(tabName.ToLower())
			{
				case "traingroup" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.PlanMetricsTabs.TrainAndGroupMetricsTabInfo,
					                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.SelfInfo);
					break;
					
				case "requeststatistics" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.PlanMetricsTabs.RequestStatisticsTabInfo,
					                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelfInfo);
					break;
					
				default:
					Ranorex.Report.Error("Invalid Tab Name. Valid options are traingroup and requeststatistics. Check Data bindings and try again.");
					break;
					
			}
		}
		
		/// <summary>
		/// Validate if the Plan Metrics tab are selected
		/// </summary>
		/// <param name="tabName">Name of the tab to validate</param>
		/// <param name="expectIsSelected"></param>
		[UserCodeMethod]
		public static void NS_ValidateTabIsSelected_PlanMetrics_NVC(string tabName, bool expectIsSelected)
		{
			bool actualIsSelected = false;
			
			switch(tabName.ToLower())
			{
				case "traingroup" :
					if(trainrepo.Network_Visibility_Console.PlanMetricsPane.PlanMetricsTabs.TrainAndGroupMetricsTab.Selected)
					{
						actualIsSelected = true;
					}
					break;
					
				case "requeststatistics" :
					if(trainrepo.Network_Visibility_Console.PlanMetricsPane.PlanMetricsTabs.RequestStatisticsTab.Selected)
					{
						actualIsSelected = true;
					}
					break;
					
				default:
					Ranorex.Report.Error("Invalid Tab Name. Valid options are traingroup and requeststatistics. Check Data bindings and try again.");
					break;	
			}
			
			if(actualIsSelected == expectIsSelected)
			{
				Ranorex.Report.Success("Expected {"+tabName+"} Tab to be selected as {"+expectIsSelected+"} and actual found as {"+actualIsSelected+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected {"+tabName+"} Tab to be selected as {"+expectIsSelected+"} and actual found as {"+actualIsSelected+"}.");
			}
		}

		/// <summary>
		/// Toggle between View Averages by Train Cost and Group
		/// </summary>
		/// <param name="catagoryType"></param>
		[UserCodeMethod]
		public static void NS_ToggleViewAveragesByCatagory_PlanMetrics_NVC(string catagoryType)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			switch(catagoryType.ToLower())
			{
				case "traincost" :
					if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainCost.Checked)
					{
						GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainCostInfo);
					}
					break;
					
				case "traingroup" :
					if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainGroup.Checked)
					{
						GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainGroupInfo);
					}
					break;
					
				default:
					Ranorex.Report.Error("Invalid option. Valid options are traincost and traingroup. Check data bindings and try again");
					break;
			}
		}
		
		/// <summary>
		/// validates View average by category selected
		/// </summary>
		/// <param name="catagoryType"></param>
		/// <param name="discriminatorName"></param>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateViewAveragesByCategory_PlanMetrics_NVC(string catagoryType, string discriminatorName, bool expectExists)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			trainrepo.DiscriminatorName = discriminatorName;
			
			bool actualExists = false;
			switch(catagoryType.ToLower())
			{
				case "traincost" :
					if(trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainCost.Checked)
					{
						if(trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.GroupMetricsTable.GroupMetricsByDiscriminatorName.DiscriminatorInfo.Exists(0))
						{
							actualExists = true;
						}
					}else{
						Ranorex.Report.Error("Average by Train Cost is not selected");
					}
					break;
					
				case "traingroup" :
					if(trainrepo.Network_Visibility_Console.PlanMetricsPane.AveragesByTrainGroup.Checked)
					{
						if(trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.GroupMetricsTable.GroupMetricsByDiscriminatorName.DiscriminatorInfo.Exists(0))
						{
							actualExists = true;
						}
					}
					else{
						Ranorex.Report.Error("Average by Train Group is not selected");
					}
					break;
					
				default:
					Ranorex.Report.Error("Invalid option. Valid options are traincost and traingroup. Check data bindings and try again");
					break;
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Average By {"+catagoryType+"} table to be displayed as {"+expectExists+"} and actual found as{"+actualExists+"}.");
			}else{
				Ranorex.Report.Failure("Expected Average By {"+catagoryType+"} table to be displayed as {"+expectExists+"} and actual found as{"+actualExists+"}.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateDetailsForValueDisplay_PlanMetrics_NVC(string detailsForValue, bool expectExists)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.DetailsInfo,
			                                          trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.DetailsTabInformation.SelfInfo);
													 
			bool actualExists = false;
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailsForPanel.DetailsForOptionText.TextValue.Equals(detailsForValue,StringComparison.OrdinalIgnoreCase))
			{
				actualExists = true;
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Details for {"+detailsForValue+"} value to be displayed as {"+expectExists+"} and actual found as{"+actualExists+"}.");
			}else{
				Ranorex.Report.Failure("Expected Details for {"+detailsForValue+"} value to be displayed as {"+expectExists+"} and actual found as{"+actualExists+"}.");
			}
			
		}
		
		/// <summary>
		/// Selects a Discriminator Value
		/// </summary>
		/// <param name="discriminatorName"></param>
		[UserCodeMethod]
		public static void NS_SelectDiscriminatorValue_PlanMetrics_NVC(string discriminatorName)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			trainrepo.DiscriminatorName = discriminatorName;
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.GroupMetricsTable.GroupMetricsByDiscriminatorName.DiscriminatorInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.GroupMetricsTable.GroupMetricsByDiscriminatorName.Discriminator.DoubleClick();
			}else{
				Ranorex.Report.Error("Discrimination Value {"+discriminatorName+"} was not found");
			}
		}
		
		/// <summary>
		/// Select train id from Train metrics table 
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void NS_SelectTrainId_TrainAndGroupMetricsTab_NVC(string trainSeed)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                Ranorex.Report.Screenshot();
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
            trainrepo.TrainId = trainId;
            
            if(trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.TrainMetricsTable.TrainMetricsByTrainID.TrainIdInfo.Exists(0))
            {
            	trainrepo.Network_Visibility_Console.PlanMetricsPane.TrainAndGroupMetricsPanel.TrainMetricsTable.TrainMetricsByTrainID.TrainId.DoubleClick();
            }else{
            	Ranorex.Report.Error("Train ID not found.");
            }
		}
		
		/// <summary>
		/// Validate train id and train group value in summary tab
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="trainGroup"></param>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateTrainDetails_BasicInformationTab_NVC(string trainSeed, string trainGroup)
		{
			NS_OpenBasicInformationTab_NVC();
			
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			if (trainId == null && trainSeed == "")
			{
				Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
				Ranorex.Report.Screenshot();
				return;
			} else if (trainId == null)
			{
				trainId = trainSeed;
			}
			
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			trainrepo.PropertyName = "Train ID";
			string actualTrainId = trainrepo.Network_Visibility_Console.PlanMetricsPane.BaiscInformationPanel.TrainDetailsTable.TrainItemByPropertyName.TrainItem.GetAttributeValue<string>("Text");
			
			if(actualTrainId.Contains(trainId))
			{
				Ranorex.Report.Success("Expected Train Id to be {"+trainId+"} and actual found as {"+actualTrainId+"}.");	
			}
			else{
				Ranorex.Report.Failure("Expected Train Id to be {"+trainId+"} and actual found as {"+actualTrainId+"}.");	
			}
			
			trainrepo.PropertyName = "Train Group";
			string actualTrainGroup = trainrepo.Network_Visibility_Console.PlanMetricsPane.BaiscInformationPanel.TrainDetailsTable.TrainItemByPropertyName.TrainItem.GetAttributeValue<string>("Text");
			
			if(actualTrainGroup.Equals(trainGroup,StringComparison.OrdinalIgnoreCase))
			{
				Ranorex.Report.Success("Expected Train Group to be {"+trainGroup+"} and actual found as {"+actualTrainGroup+"}.");	
			}
			else{
				Ranorex.Report.Failure("Expected Train Group to be {"+trainGroup+"} and actual found as {"+actualTrainGroup+"}.");		
			}
			
		}
		
		/// <summary>
		/// Validates Train Route Details
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="trainOpsta"></param>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateTrainRouteDetails_BasicInformationTab_NVC(string trainSeed, string trainOpsta, bool expectExists)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			if (trainId == null && trainSeed == "")
			{
				Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
				Ranorex.Report.Screenshot();
				return;
			} else if (trainId == null)
			{
				trainId = trainSeed;
			}
			
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			NS_SelectBasicViewType_NVC("metrics");
			
			if(!trainrepo.Network_Visibility_Console.PlanMetricsPane.MetricsTabPaneInfo.Exists(0))
			{
				Ranorex.Report.Error("Plan metrics panel not found.");
				return;
			}
			
			trainrepo.TrainOpsta = trainOpsta;
			bool actualExists = false;
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.BaiscInformationPanel.TrainRouteElementsList.TrainRouteElementsListByTrainOpstaInfo.Exists(0))
			{
				actualExists = true;
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Opsta {"+trainOpsta+"} to exists as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}else{
				Ranorex.Report.Failure("Expected Opsta {"+trainOpsta+"} to exists as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}
		}
		
		public static void NS_OpenBasicInformationTab_NVC()
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.BaiscInformationTabInfo,
			                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.BaiscInformationPanel.SelfInfo);		
		}
		
		public static void NS_OpenDetailedInformationTab_NVC()
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.DetailedInformationTabInfo,
			                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.SelfInfo);		
		}
		
		/// <summary>
		/// Validates Detailed Information Tab open
		/// </summary>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateDetailedInformationTabOpen_NVC(bool expectExists)
		{
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			bool actualExists = false;
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.DetailedInformationTabInfo.Exists(0))
			{
				actualExists = true;
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Detailed Information Tab to be open as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}else{
				Ranorex.Report.Failure("Expected Detailed Information Tab to be open as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}
		}
		
		/// <summary>
		/// Validates Basic Information Tab open
		/// </summary>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateBasicInformationTabOpen_NVC(bool expectExists)
		{
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			bool actualExists = false;
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.BaiscInformationTabInfo.Exists(0))
			{
				actualExists = true;
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Baisc Information Tab to be open as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}else{
				Ranorex.Report.Failure("Expected Baisc Information Tab to be open as {"+expectExists+"} and actual found as {"+actualExists+"}.");
			}
		}
		
		/// <summary>
		/// Expand All tree nodes 
		/// </summary>
		[UserCodeMethod]
		public static void NS_ExpandAllDetailedInformationLevelTree_PlanMetrics_NVC()
		{
			NS_OpenDetailedInformationTab_NVC();
			NS_ValidateDetailedInformationTabOpen_NVC(true);
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.DetailedInformationTabInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.DetailedInformationTree.Self.ExpandAll();
			}
			else
			{
				Ranorex.Report.Error("Detailed Information Tab not found");
			}	
		}
		
		/// <summary>
		/// Validates Detailed Information Level Tree Expanded
		/// </summary>
		/// <param name="expectExpanded"></param>
		[UserCodeMethod]
		public static void NS_ValidateDetailedInformationLevelTreeExpanded_PlanMetrics_NVC(bool expectExpanded)
		{
			NS_OpenDetailedInformationTab_NVC();
			NS_ValidateDetailedInformationTabOpen_NVC(true);
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.DetailedInformationTree.ContextTreeItem.Expanded == expectExpanded)
			{
				Ranorex.Report.Success("Context Tree Item is {"+ (expectExpanded? "expanded":"collapsed")+"}.");
			}else{
				Ranorex.Report.Failure("Context Tree Item is {"+ (!expectExpanded? "expanded":"collapsed")+"}.");
			}
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.DetailedInformationTree.ElementsTreeItem.Expanded == expectExpanded)
			{
				Ranorex.Report.Success("Elements Tree Item is {"+ (expectExpanded? "expanded":"collapsed")+"}.");
			}else{
				Ranorex.Report.Failure("Elements Tree Item is {"+ (!expectExpanded? "expanded":"collapsed")+"}.");
			}
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.DetailedInformationTree.TrainStateTreeItem.Expanded == expectExpanded)
			{
				Ranorex.Report.Success("Train State Tree Item is {"+ (expectExpanded? "expanded":"collapsed")+"}.");
			}else{
				Ranorex.Report.Failure("Train State Tree Item is {"+ (!expectExpanded? "expanded":"collapsed")+"}.");
			}			   
		}
		
		/// <summary>
		/// Collapse All Detailed Information Level Tree
		/// </summary>
		[UserCodeMethod]
		public static void NS_CollapseAllDetailedInformationLevelTree_PlanMetrics_NVC()
		{
			NS_OpenDetailedInformationTab_NVC();
			NS_ValidateDetailedInformationTabOpen_NVC(true);
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.DetailedInformationTabInfo.Exists(0))
			{
				trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailedInformationPanel.DetailedInformationTree.Self.CollapseAll();
			}
			else
			{
				Ranorex.Report.Error("Detailed Information Tab not found");
			}	
		}
		
	
		/// <summary>
		/// Open Trainsheet Via  NVC
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void NS_OpenTrainSheet_NVC(string trainSeed)
		{
			if (!trainrepo.Train_Sheet.SelfInfo.Exists(0))
			{
				NS_SelectTrainId_TrainAndGroupMetricsTab_NVC(trainSeed);
				//Click Open Trainsheet button
				GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailsForPanel.OpenTrainSheetButtonInfo,
				                                          trainrepo.Train_Sheet.SelfInfo);

				if (!trainrepo.Train_Sheet.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("Trainsheet did not open");
					return;
				}
			}
		}
		
		/// <summary>
		/// Click Navigate To train Graph button
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void NS_ClickNavigateToTrainGraphButton_NVC(string trainSeed)
		{
			NS_SelectTrainId_TrainAndGroupMetricsTab_NVC(trainSeed);
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailsForPanel.NavigateToGraphButtonInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.DetailsForPanel.NavigateToGraphButtonInfo,
				                                          trainrepo.Network_Visibility_Console.GraphPanelInfo);
			}
		}
		
		/// <summary>
		/// Validates the Request Statistics Tab Information
		/// </summary>
		/// <param name="regionIdValue"></param>
		/// <param name="meetsValue"></param>
		/// <param name="unresolvedTrainsValue"></param>
		/// <param name="plannedTrainsValue"></param>
		[UserCodeMethod]
		public static void NS_ValidateRequestStatisticsInformation_NVC(string regionIdValue, string meetsValue, string unresolvedTrainsValue, string plannedTrainsValue)
		{
			NS_TogglePlanMetricsTab_NVC("RequestStatistics");
			
			string actualRegionIdValue = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.RegionIdValue.GetAttributeValue<string>("Text");
			
			if(actualRegionIdValue.Equals(regionIdValue,StringComparison.OrdinalIgnoreCase))
			{
				Ranorex.Report.Success("Expected RegionId Value to be {"+regionIdValue+"} and acutual found as {"+actualRegionIdValue+"}.");
			}else{
				Ranorex.Report.Failure("Expected RegionId Value to be {"+regionIdValue+"} and acutual found as {"+actualRegionIdValue+"}.");
			}
			
			
			string actualMeetsValue = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.MeetsValue.GetAttributeValue<string>("Text");
			
			if(actualMeetsValue.Equals(meetsValue,StringComparison.OrdinalIgnoreCase))
			{
				Ranorex.Report.Success("Expected Meets Value to be {"+meetsValue+"} and acutual found as {"+actualMeetsValue+"}.");
			}else{
				Ranorex.Report.Failure("Expected Meets Value to be {"+meetsValue+"} and acutual found as {"+actualMeetsValue+"}.");
			}
			
			string actualUnresolvedTrainsValue = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.UnresolvedTrainsValue.GetAttributeValue<string>("Text");
			
			if(actualUnresolvedTrainsValue.Equals(unresolvedTrainsValue,StringComparison.OrdinalIgnoreCase))
			{
				Ranorex.Report.Success("Expected Meets Value to be {"+unresolvedTrainsValue+"} and acutual found as {"+actualUnresolvedTrainsValue+"}.");
			}else{
				Ranorex.Report.Failure("Expected Meets Value to be {"+unresolvedTrainsValue+"} and acutual found as {"+actualUnresolvedTrainsValue+"}.");
			}
			
			string actualPlannedTrainsValue = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.PlannedTrainsValue.GetAttributeValue<string>("Text");
			
			if(actualPlannedTrainsValue.Equals(plannedTrainsValue,StringComparison.OrdinalIgnoreCase))
			{
				Ranorex.Report.Success("Expected Meets Value to be {"+plannedTrainsValue+"} and acutual found as {"+actualPlannedTrainsValue+"}.");
			}else{
				Ranorex.Report.Failure("Expected Meets Value to be {"+plannedTrainsValue+"} and acutual found as {"+actualPlannedTrainsValue+"}.");
			}
		}
		

		public static void NS_ClickPlannedTrainsItem_RequestStatisticsTab_NVC()
		{
			NS_TogglePlanMetricsTab_NVC("RequestStatistics");
			
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.PlannedTrainsValueInfo.Exists(0))
			{
				Ranorex.Report.Info("Teststep","Selecting Planned Trains");
				GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.PlannedTrainsValueInfo,
				                                          trainrepo.Network_Visibility_Console.PlanMetricsPane.SelectedItemsTabs.SelfInfo);
			}else{
				Ranorex.Report.Error("Planned Train info not found");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC(string trainSeed, string trainGroup, string scheduleStatus)
		{
			
			NS_ClickPlannedTrainsItem_RequestStatisticsTab_NVC();
			
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			if (trainId == null && trainSeed == "")
			{
				Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
				Ranorex.Report.Screenshot();
				return;
			} else if (trainId == null)
			{
				trainId = trainSeed;
			}
			trainrepo.TrainId = trainId;
			if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.PlannedTrainsValue.GetAttributeValue<bool>("Selected"))
			{
				if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.TrainIdInfo.Exists(0))
				{
					string actualTrainId = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.TrainId.GetAttributeValue<string>("Text");
				
					if(actualTrainId.Contains(trainId))
					{
						Ranorex.Report.Success("Expected Train Id to be {"+trainId+"} and acutual found as {"+actualTrainId+"}.");
					}else{
						Ranorex.Report.Failure("Expected Train Id to be {"+trainId+"} and acutual found as {"+actualTrainId+"}.");
					}
					
					string actualTrainGroup = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.TrainGroup.GetAttributeValue<string>("Text");
					
					if(actualTrainGroup.Contains(trainGroup))
					{
						Ranorex.Report.Success("Expected Train Group to be {"+trainGroup+"} and acutual found as {"+actualTrainGroup+"}.");
					}else{
						Ranorex.Report.Failure("Expected Train Group to be {"+trainGroup+"} and acutual found as {"+actualTrainGroup+"}.");
					}
					
					string actualScheduleStatus = trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.ScheduleStatus.GetAttributeValue<string>("Text");
					
					if(actualScheduleStatus.Contains(scheduleStatus))
					{
						Ranorex.Report.Success("Expected Schedule Status to be {"+scheduleStatus+"} and acutual found as {"+actualScheduleStatus+"}.");
					}else{
						Ranorex.Report.Failure("Expected Schedule Status to be {"+scheduleStatus+"} and acutual found as {"+actualScheduleStatus+"}.");
					}	
				}
				else
				{
					Ranorex.Report.Error("Planned Train Details Table did not load");
					Ranorex.Report.Screenshot(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.Self);
				}
			}
			else
			{
				Ranorex.Report.Screenshot(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.Self);
				Ranorex.Report.Error("Planned Train Item is not selected");
			}
		}
		
		[UserCodeMethod]
		public static void NS_SelectTrainId_RequestStatisticsTab_NVC(string trainSeed)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                Ranorex.Report.Screenshot();
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            NS_TogglePlanMetricsTab_NVC("RequestStatistics");
			
            trainrepo.TrainId = trainId;
            
            if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.PlannedTrainsValue.GetAttributeValue<bool>("Selected"))
            {
            	if(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.TrainIdInfo.Exists(0))
            	{
            		trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.SelectedListTrainTable.SelectedItemByTrainId.TrainId.DoubleClick();
            	}
            	else
            	{
            		Ranorex.Report.Error("Planned Train Details Table did not load");
            		Ranorex.Report.Screenshot(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.Self);
            	}
            }
            else
            {
            	Ranorex.Report.Screenshot(trainrepo.Network_Visibility_Console.PlanMetricsPane.RequestStatisticsPanel.Self);
            	Ranorex.Report.Error("Planned Train Item is not selected");
            }
		}
		
		/// <summary>
		/// toggle between Summary list tabs of NVC form
		/// </summary>
		/// <param name="tabName"></param>
		[UserCodeMethod]
		public static void NS_ToggleSummaryListTabs_NVC(string tabName)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			
			
			switch(tabName.ToLower())
			{
				case "trainsummary" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.TrainSummaryInfo,
					                                          trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SelfInfo);
					break;
					
				case "warningsummary" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.WarningSummaryInfo,
					                                          trainrepo.Network_Visibility_Console.SummaryListPane.WarningSummary.SelfInfo);
					break;
					
				case "designationsummary" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.DesignationSummaryInfo,
					                                          trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SelfInfo);
					break;
					
				case "restrictionsummary" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.RestrictionSummaryInfo,
					                                          trainrepo.Network_Visibility_Console.SummaryListPane.Restriction_Summary.SelfInfo);
					break;
					
				case "clearahead" :
					GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryTabs.ClearAheadInfo,
					                                          trainrepo.Network_Visibility_Console.SummaryListPane.Clear_Ahead.SelfInfo);
					break;
					
					default :
						Ranorex.Report.Error("Invalid Tab. Valid options are : trainsummary, warningsummary, designationsummary, restrictionsummary and clearahead.");
					break;
			}
		}
		
		/// <summary>
		/// Validate Summary list tab selected
		/// </summary>
		/// <param name="tabName"></param>
		/// <param name="expectSelected"></param>
		[UserCodeMethod]
		public static void NS_ValidateSummaryListTabsSelected_NVC(string tabName, bool expectSelected)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			NS_SelectBasicViewType_NVC("summarylist");
			
			bool actualSelected = false;
			
			switch(tabName.ToLower())
			{
				case "trainsummary" :
					if(trainrepo.Network_Visibility_Console.SummaryTabs.TrainSummary.GetAttributeValue<bool>("Selected"))
					{
						actualSelected = true;
					}
					break;
					
				case "warningsummary" :
					if(trainrepo.Network_Visibility_Console.SummaryTabs.WarningSummary.GetAttributeValue<bool>("Selected"))
					{
						actualSelected = true;
					}
					break;
					
				case "designationsummary" :
					if(trainrepo.Network_Visibility_Console.SummaryTabs.DesignationSummary.GetAttributeValue<bool>("Selected"))
					{
						actualSelected = true;
					}
					break;
					
				case "restrictionsummary" :
					if(trainrepo.Network_Visibility_Console.SummaryTabs.RestrictionSummary.GetAttributeValue<bool>("Selected"))
					{
						actualSelected = true;
					}
					break;
					
				case "clearahead" :
					if(trainrepo.Network_Visibility_Console.SummaryTabs.ClearAhead.GetAttributeValue<bool>("Selected"))
					{
						actualSelected = true;
					}
					break;
					
					default :
						Ranorex.Report.Error("Invalid Tab. Valid options are : trainsummary, warningsummary, designationsummary, restrictionsummary and clearahead.");
					break;
			}
			
			if(actualSelected == expectSelected)
			{
				Ranorex.Report.Success("Expected {"+tabName+"} tab to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}else{
				Ranorex.Report.Failure("Expected {"+tabName+"} tab to be selected as {"+expectSelected+"} and actual found as {"+actualSelected+"}.");
			}
		}
		
		/// <summary>
		/// Select train id from Train Summary List Tab
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void NS_SelectTrainId_TrainSummaryList_NVC(string trainSeed)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                Ranorex.Report.Screenshot();
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			NS_ToggleSummaryListTabs_NVC("trainsummary");
			
            trainrepo.TrainId = trainId;
            
            if(trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByTrainId.TrainIdInfo.Exists(0))
            {
            	trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByTrainId.TrainId.DoubleClick();
            	if(trainrepo.Network_Visibility_Console.SummaryListPane.SummaryTablePane.SummaryTable.ItemsByTrainId.TrainId.GetAttributeValue<bool>("Selected"))
            	{
            		Ranorex.Report.Success("Train Id {"+trainId+"} Selected Successfully.");
            	}
            	else{
            		Ranorex.Report.Failure("Train Id {"+trainId+"} not Selected.");
            	}
            }
            else{
            	Ranorex.Report.Error("Train ID not found.");
            }
		}
		
		/// <summary>
		/// Check or Uncheck Only Show Items On The Graph checkbox
		/// </summary>
		/// <param name="doCheck"></param>
		[UserCodeMethod]
		public static void NS_ModifyOnlyShowItemsOnTheGraphCheckbox_NVC(bool doCheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			
			if(doCheck && !trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOnTheGraphCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAndVerifyChecked(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOnTheGraphCheckbox);
			}
			else if(!doCheck && trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOnTheGraphCheckbox.Checked)
			{
				GeneralUtilities.UncheckCheckboxAndVerifyUnchecked(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOnTheGraphCheckbox);
			}
		}
		
		/// <summary>
		/// Validate checkbox Only Show Items On The Graph
		/// </summary>
		/// <param name="isChecked"></param>
		[UserCodeMethod]
		public static void NS_ValidateIsChecked_OnlyShowGraphItemsCheckbox_NVC(bool isChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			NS_SelectBasicViewType_NVC("summarylist");
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOnTheGraphCheckboxInfo, isChecked);
		}
		
		/// <summary>
		/// Select train id from Train Summary List Tab
		/// </summary>
		/// <param name="trainSeed"></param>
		[UserCodeMethod]
		public static void NS_SelectTrainId_WarningSummaryList_NVC(string trainSeed)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                Ranorex.Report.Screenshot();
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			NS_ToggleSummaryListTabs_NVC("warningsummary");
			
            trainrepo.TrainId = trainId;
            
            if(trainrepo.Network_Visibility_Console.SummaryListPane.WarningSummary.WarningTable.WarningListItemsByTrainId.TrainIdInfo.Exists(0))
            {
            	trainrepo.Network_Visibility_Console.SummaryListPane.WarningSummary.WarningTable.WarningListItemsByTrainId.TrainId.DoubleClick();
            	if(trainrepo.Network_Visibility_Console.SummaryListPane.WarningSummary.WarningTable.WarningListItemsByTrainId.TrainId.GetAttributeValue<bool>("Selected"))
            	{
            		Ranorex.Report.Success("Train Id {"+trainId+"} Selected Successfully.");
            	}
            	else{
            		Ranorex.Report.Failure("Train Id {"+trainId+"} not Selected.");
            	}
            }else{
            	Ranorex.Report.Error("Train ID not found.");
            }
		}
		
		/// <summary>
		/// Check or Uncheck Only Show Items Occurring Now Or In The Next checkbox
		/// </summary>
		/// <param name="doCheck"></param>
		[UserCodeMethod]
		public static void NS_ModifyOnlyShowItemsByTimeCheckbox_NVC(bool doCheck)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			
			if(doCheck && !trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextCheckbox.Checked)
			{
				GeneralUtilities.CheckCheckboxAndVerifyChecked(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextCheckbox);
			}
			else if(!doCheck && trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextCheckbox.Checked)
			{
				GeneralUtilities.UncheckCheckboxAndVerifyUnchecked(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextCheckbox);
			}
		}
		
		/// <summary>
		/// Validate checkbox Only Show Items Occurring Now Or In The Next
		/// </summary>
		/// <param name="isChecked"></param>
		[UserCodeMethod]
		public static void NS_ValidateIsChecked_OnlyShowItemsByTimeCheckbox_NVC(bool isChecked)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}
			
			NS_SelectBasicViewType_NVC("summarylist");
			
			GeneralUtilities.VerifyCheckBoxIsCheckedOrNot(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextCheckboxInfo, isChecked);
		}
		
		/// <summary>
		/// Set Only Show Items Occurring Now Or In The Next Time value
		/// </summary>
		/// <param name="timeValue"></param>
		[UserCodeMethod]
		public static void NS_SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC(string timeValue)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			
			NS_ModifyOnlyShowItemsByTimeCheckbox_NVC(true);
			
			if(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.Enabled)
			{
				trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.Click();
				trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.Element.SetAttributeValue("Text",timeValue);
				trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.PressKeys("{TAB}");
			}
			else{
				Ranorex.Report.Failure("Time value not set as field in not enabled");
			}
		}
		
		/// <summary>
		/// Validate Only Show Items Occurring Now Or In The Next Time
		/// </summary>
		/// <param name="timeValue"></param>
		/// <param name="expectExists"></param>
		[UserCodeMethod]
		public static void NS_ValidateTime_OnlyShowItemsByTimeCheckbox_NVC(string expectedTimeValue, bool expectIsEnabled)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			
			string actualTimeValue = trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.GetAttributeValue<string>("Text");
			bool actualEnabled = false;
			if(actualTimeValue.Equals(expectedTimeValue))
			{
				Ranorex.Report.Success("Expected time value to be set as {"+expectedTimeValue+"} and acutal found as {"+actualTimeValue+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected time value to be set as {"+expectedTimeValue+"} and acutal found as {"+actualTimeValue+"}.");
			}

			
			if(trainrepo.Network_Visibility_Console.SummaryListPane.SortAndFilter.OnlyShowItemsOccurringNowOrInTheNextMinutesText.Enabled)
			{
				actualEnabled = true;
			}
			
			if(actualEnabled == expectIsEnabled)
			{
				Ranorex.Report.Success("Expected time value to Enabled as {"+expectIsEnabled+"} and acutal found as {"+actualEnabled+"}.");
			}else
			{
				Ranorex.Report.Failure("Expected time value to Enabled as {"+expectIsEnabled+"} and acutal found as {"+actualEnabled+"}.");
			}
		}
		
		
		[UserCodeMethod]
		public static void NS_ValidateTrainExists_WarningSummaryTab_NVC(string trainSeed, bool expectExists)
		{
			NS_OpenNVCForm();
			if(!trainrepo.Network_Visibility_Console.SelfInfo.Exists(0))
			{
				Ranorex.Report.Error("NVC form not found.");
				return;
			}

			NS_SelectBasicViewType_NVC("summarylist");
			NS_ToggleSummaryListTabs_NVC("warningsummary");
			
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                Ranorex.Report.Screenshot();
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            trainrepo.TrainId = trainId;
            
            bool actualExists = false;
            
            if(trainrepo.Network_Visibility_Console.SummaryListPane.WarningSummary.WarningTable.WarningListItemsByTrainId.TrainIdInfo.Exists(0))
            {
            	actualExists = true;
            }
            
            if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Train {"+trainId+"} to exists as {"+expectExists+"} and acutal found as {"+actualExists+"}.");
			}else
			{
				Ranorex.Report.Failure("Expected Train {"+trainId+"} to exists as {"+expectExists+"} and acutal found as {"+actualExists+"}.");
			}
		}
		
		public static void OpenTrackDesignationConstraint_NVC(string trackFeatureId, string trackSegmentId)
		{
			if(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo.Exists(0))
			{
				return;
			}
			
			if(!IsNVCOpen())
			{
				return;
			}
			
			
			NS_SearchForAnItem_NVC(trackFeatureId, trackSegmentId);
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.DetailsPane.Tabs.Search.EditDesignationButtonInfo,
			                                          trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo);
			
			int attempts = 0;
			while(!trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.AvoidForMoveRadioButton.Enabled && attempts < 5)
			{
				Ranorex.Delay.Milliseconds(500);
				attempts++;
			}
			
			if(!trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.AvoidForMoveRadioButton.Enabled)
			{
				Ranorex.Report.Failure("Form open but failed to load constraints data");
				Ranorex.Report.Screenshot(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.Self);
			}
		}
		
		public static void NS_ToggleDesignationConstraint(string trackDesignation)
		{	
			switch(trackDesignation.ToLower())
			{
				case "upbound" :
					GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferUpboundRadioButton);
					break;
				case "downbound" :
					GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferDownboundRadioButton);
					break;
				case "bidirectional" :
					GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferBidirectionalRadioButton);
					break;
				case "dwell" :
					GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.PreferDwellRadioButton);
					break;
				case "avoidformove" :
					GeneralUtilities.CheckRadioButtonAndVerifyChecked(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.DesignationPanel.AvoidForMoveRadioButton);
					break;		
				default : 
					Ranorex.Report.Error("Invalid Selection. Valid Options are upbound, downbound, bidirectional, dwell and avoidformove.");
					break;
			}
		}
		
		/// <summary>
		///  Add condition to track by FeatureId and Segment Id
		/// </summary>
		/// <param name="trackFeatureId"></param>
		/// <param name="trackSegmentId"></param>
		/// <param name="trackDesignation"></param>
		/// <param name="preference"></param>
		/// <param name="conditionName"></param>
		/// <param name="conditonType"></param>
		/// <param name="conditionValue"></param>
		/// <param name="clickSave"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_AddCondition_DesignationSummary_NVC(string trackFeatureId, string trackSegmentId, string trackDesignation, string preference, string conditionName, string conditonType, string conditionValue, bool clickSave, bool closeForm)
		{
			OpenTrackDesignationConstraint_NVC(trackFeatureId, trackSegmentId);
			NS_OpenDesignationSummary();
			
			int designationSummaryCount = 0;
			if(trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.SelfInfo.Exists(0))
			{
				designationSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Self.Rows.Count;
			}
			
			
			//Select Preference
			trainrepo.PreferenceName = preference.ToUpper();
			trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.ApplicablitySelectorText.Element.SetAttributeValue("DropDownVisible", "True");
            if (trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.PreferenceList.PreferenceItemByPreferenceNameInfo.Exists(0))
            {
            	Ranorex.Report.Info("Teststep","Selecting Preference");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.PreferenceList.PreferenceItemByPreferenceNameInfo,
                												  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.PreferenceList.SelfInfo);
            } 
            else {
                trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.ApplicablitySelectorText.Element.SetAttributeValue("DropDownVisible", "False");
                Ranorex.Report.Error("Please specify a valid preference name. Check data bindings and try again.");
                return;
            }
            
            //select Track Designation
            NS_ToggleDesignationConstraint(trackDesignation);
            
            //check if add condtion button is enabled
            if(!trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditionButton.Enabled)
            {
            	Ranorex.Report.Failure("Add Condition but not enabled");
            	Ranorex.Report.Screenshot(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.Self);
            }
			
			GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditionButtonInfo,
                                                      trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.RemoveConditionButtonInfo);
            
            
            //select condition
            trainrepo.ConditionName = conditionName;
            trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionMenuItemText.Element.SetAttributeValue("DropDownVisible", "True");
            if (trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionList.ConditionItemByConditionNameInfo.Exists(0))
            {
            	Ranorex.Report.Info("Teststep","Selecting Condition");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionList.ConditionItemByConditionNameInfo,
                												 trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionList.SelfInfo);
            } 
            else {
                trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionMenuItemText.Element.SetAttributeValue("DropDownVisible",  "False");
                Ranorex.Report.Error("Please specify a valid condition name. Check data bindings and try again.");
                return;
            }
            
            //select condition type
            trainrepo.ConditionType = conditonType;
            trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionTypeMenuItemText.Element.SetAttributeValue("DropDownVisible", "True");
            if (trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionTypeList.ConditionTypeItemByConditionTypeInfo.Exists(0))
            {
            	Ranorex.Report.Info("Teststep","Selecting Type");
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionTypeList.ConditionTypeItemByConditionTypeInfo,
            	                                                  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionTypeList.SelfInfo);
            }
            else {
            	trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionTypeMenuItemText.Element.SetAttributeValue("DropDownVisible", "False");
            	Ranorex.Report.Error("Please specify a valid condition type. Check data bindings and try again.");
            	return;
            }
            
            
            //set condition Value
            trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionValue.Click();
            trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionValue.Element.SetAttributeValue("Text", conditionValue);
            trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.FilterEditor.AddConditions.ConditionValue.PressKeys("{TAB}");
            
 
            if(clickSave)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.AccessButtons.SaveButtonInfo,
            	                                                  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo);
            }
            
            if(designationSummaryCount < trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Self.Rows.Count)
            {
            	Ranorex.Report.Success("Condition addded successfully");
            }
            
            if(closeForm)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.Network_Visibility_Console.WindowControls.CloseInfo,
            	                                                  trainrepo.Network_Visibility_Console.SelfInfo);
            }
		}
		
		/// <summary>
		/// VAlidate Track Designation details
		/// </summary>
		/// <param name="trackFeatureId"></param>
		/// <param name="trackDesignation"></param>
		/// <param name="expectExist"></param>
		[UserCodeMethod]
		public static void NS_ValidateTrackDesignationSummary_NVC(string trackFeatureId, string trackDesignation, bool expectExist)
		{
			NS_OpenDesignationSummary();
			int designationSummaryCount = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.Self.Rows.Count;
			string ActualFeatureId;
			string ActualTrackDesignation;
			
			if(designationSummaryCount == 0)
			{
				if(!expectExist)
				{
					Ranorex.Report.Success("Summary Table is Empty");
					return;
				}else{
					Ranorex.Report.Failure("Summary Table is Empty to validate");
					Ranorex.Report.Screenshot(trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.Self);
				}
			}
			
			trainrepo.FeatureId = trackFeatureId;
			if(trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.DesignationSummaryByFeatureId.TrackFeatureIdInfo.Exists(0))
			{
				ActualFeatureId = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.DesignationSummaryByFeatureId.TrackFeatureId.GetAttributeValue<string>("Text").Trim();
				ActualTrackDesignation = trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.DesignationSummaryByFeatureId.TrackDesignation.GetAttributeValue<string>("Text").Trim();
				
				if((ActualFeatureId == trackFeatureId) && (ActualTrackDesignation == trackDesignation))
				{
					Ranorex.Report.Success("Expected Track FeatureId:{"+trackFeatureId+"} & Designation:{"+trackDesignation+"} match with Actual Track FeatureId:{"+ActualFeatureId+"} & Designation:{"+ActualTrackDesignation+"}.");
				}else{
					Ranorex.Report.Failure("Expected Track FeatureId:{"+trackFeatureId+"} & Designation:{"+trackDesignation+"} Do not match with Actual Track FeatureId:{"+ActualFeatureId+"} & Designation:{"+ActualTrackDesignation+"}.");
				}
			}
			else{
				Ranorex.Report.Error("Track Feature Id not found. Check data bindings and try again.");
			}
		}
		
		
		/// <summary>
		/// Remove Designation Constraint of track by FeatureId and Segment Id
		/// </summary>
		/// <param name="trackFeatureId"></param>
		/// <param name="clickRemoveConstraint"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_RemoveConstraint_DesignationSummary_NVC(string trackFeatureId, bool clickRemoveConstraint, bool closeForm)
		{
			NS_OpenDesignationSummary();
			trainrepo.FeatureId = trackFeatureId;
			
			if(trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.DesignationSummaryByFeatureId.TrackFeatureIdInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForEnabledWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.Designation_Summary.SummaryTablePane.DesignationSummaryByFeatureId.TrackFeatureIdInfo,
				                                                 trainrepo.Network_Visibility_Console.SummaryListPane.EditDesignationInfo);	
			}
			else{
				Ranorex.Report.Error("Track feature Id not found. Check Data bindings and try again.");
				return;
			}
			
            GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.Network_Visibility_Console.SummaryListPane.EditDesignationInfo,
				                                          trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo);
            
			//click Remove Button
        	GeneralUtilities.ClickAndWaitForWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.AccessButtons.RemoveButtonInfo,
        	                                                  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.Remove_Constraint.SelfInfo);
			
			//click Remove Constraints Button
			if(clickRemoveConstraint)
			{
				Ranorex.Report.Info("Teststep","Clicking Remove Constraints Button.");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.Remove_Constraint.RemoveConstraintsButtonInfo,
			                                                  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.Remove_Constraint.SelfInfo);
				
			}

            if(closeForm && !clickRemoveConstraint)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.AccessButtons.CancelButtonInfo,
            	                                                  trainrepo.NVC_Forms.NVC_Track_Designation_Constraint.SelfInfo);
            }
		}
	}
}
