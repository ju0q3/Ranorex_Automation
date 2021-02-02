/*
 * Created by Ranorex
 * User: rpatil30
 * Date: 5/5/2020
 * Time: 9:01 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using Env.Code_Utils;
using PDS_CORE.Code_Utils;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Assignments
    {
    	public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
    	public static global::PDS_NS.Assignments_Repo AssignmentsRepo = global::PDS_NS.Assignments_Repo.Instance;
    	
    	/// <summary>
    	/// Opens Signal Technician Territory Definition
    	/// </summary>
    	[UserCodeMethod]
		public static void NS_OpenSignalTechnicianTerritoryDefinition()
		{
			int retries = 0;

        	//Open User Account Form if it's not already open
        	if (AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Signal Technician Territory Definition is already open.");
        		return;
        	}

        	//Click System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.AssignmentsButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SelfInfo);
        	
        	//Click User Account Form in System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SignalTechTerritoriesInfo,
        	                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
        	
        	//Wait for User Account Form to exist in case of lag
        	while (!AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo.Exists(0)  && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if (!AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo.Exists(0) )
        	{
        		Ranorex.Report.Error("Signal Technician Territory Definition did not open");
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Info("Signal Technician Territory Definition opened");
        	}
		}
    	
		/// <summary>
		/// Add or remove Signal Tech Disptach Positions from Unassigned , All Available or Assigned Dispatch Position.
		/// </summary>
		/// <param name="territoryName"></param>
		/// <param name="dispatchPositonType"></param>
		/// <param name="dispatchPostionName"></param>
		/// <param name="removePosition"></param>
		/// <param name="addPosition"></param>
		/// <param name="reset"></param>
		/// <param name="apply"></param>
		/// <param name="closeForms"></param>
    	[UserCodeMethod]
		public static void NS_ModifyTerritory_SignalTech_TerritoryDefinition(string territoryName, string dispatchPositonType, string dispatchPostionName, bool removePosition, bool addPosition, bool reset, bool apply, bool closeForms)
		{
			NS_OpenSignalTechnicianTerritoryDefinition();
			int listSize = 0;
			if (territoryName != "")
			{
				AssignmentsRepo.SignalTechnicianTerritory = territoryName;
				AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryText.Element.SetAttributeValue("DropDownVisible","True");
				if(AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo.Exists(0))
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo,
					                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo);
				}
				else{
					AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryText.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid territory position. Check data bindings and try again.");
				}
			}
			else
			{
				Ranorex.Report.Error("Territory should not be null");
				if(closeForms)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
        			                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
        		}
			}
			
			
			switch(dispatchPositonType.ToLower())
			{
				case "assignedposition" :
					AssignmentsRepo.AssignedName = dispatchPostionName;
					listSize = AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in Assigned Dispatch Position");
						if(removePosition)
						{
							AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByName.Click();
							AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Signal_Technician_Territory_Definition.RemoveButton.Click();
							if(listSize>AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} removed from {"+dispatchPositonType+"}");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be removed from {"+dispatchPositonType+"}");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in {"+dispatchPositonType+"}");
						return;
					}
					break;
					
				case "unassignedposition":
					AssignmentsRepo.UnassignedName = dispatchPostionName;
					listSize = AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Signal_Technician_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in Unassigned Dispatch Position");
						if(addPosition)
						{
							AssignmentsRepo.Signal_Technician_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByName.Click();
							AssignmentsRepo.Signal_Technician_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Signal_Technician_Territory_Definition.AddButton.Click();
							if(listSize<AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} added to Assigned Dispatch Position");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be added to Assigned Dispatch Position");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in Unassigned Dispatch Position");
						return;
					}
					break;
					
				case "allavailableposition":
					AssignmentsRepo.AvailableName = dispatchPostionName;
					listSize = AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Signal_Technician_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in All Available Dispatch Position");
						if(addPosition)
						{
							AssignmentsRepo.Signal_Technician_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByName.Click();
							AssignmentsRepo.Signal_Technician_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Signal_Technician_Territory_Definition.AddButton.Click();
							if(listSize<AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} added to Assigned Dispatch Position");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be added to Assigned Dispatch Position");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in All Available Dispatch Position");
						return;
					}
					break;
					
				default :
						Ranorex.Report.Error("Invalid Selection List. Valid options are : assignedposition, unassignedposition, allavailableposition");
					break;
			}
			
			if(apply)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.ApplyButtonInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.ApplyButtonInfo);
			}
			
			if(reset)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.ResetButtonInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.ResetButtonInfo);
			}
			
			if(closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
			}
			
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePositionExists_SignalTech_TerritoryDefination(string territoryName, string dispatchPostionName, bool expectedDispPosition = false, bool closeForm = false)
		{
			NS_OpenSignalTechnicianTerritoryDefinition();
			if (territoryName == "")
			{
				Ranorex.Report.Error("Territory should not be null");
				if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
        			                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
        		}
				return;
			}
			else
			{
				AssignmentsRepo.SignalTechnicianTerritory = territoryName;
				AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryText.Element.SetAttributeValue("DropDownVisible","True");
				if(AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo.Exists(0))
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo,
					                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryList.SignalTechnicianTerritoryListItemByNameInfo);
				}
				else{
					AssignmentsRepo.Signal_Technician_Territory_Definition.SignalTechnicianTerritory.SignalTechnicianTerritoryText.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid territory position. Check data bindings and try again.");
				}
			}
			
			bool actualDispPosition = false;
			AssignmentsRepo.AssignedName = dispatchPostionName;
			if(AssignmentsRepo.Signal_Technician_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByNameInfo.Exists(0))
			{
				actualDispPosition = true;
			}
			
			if(actualDispPosition == expectedDispPosition)
			{
				Ranorex.Report.Success("Expected Assigned Dispatch Positon {"+dispatchPostionName+"} to exists as {"+expectedDispPosition+"} and actual found as {"+actualDispPosition+"}");
			}
			else
			{
				Ranorex.Report.Failure("Expected Assigned Dispatch Positon {"+dispatchPostionName+"} to exists as {"+expectedDispPosition+"} and actual found as {"+actualDispPosition+"}");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Signal_Technician_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Signal_Technician_Territory_Definition.SelfInfo);
			}
		}
		
		/// <summary>
    	/// Opens Supervisor Dispatch Territory Definition
    	/// </summary>
    	[UserCodeMethod]
		public static void NS_OpenSupervisorDispatchTerritoryDefinition()
		{
			int retries = 0;

        	//Open User Account Form if it's not already open
        	if (AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Supervisor Dispatch Territory Definition is already open.");
        		return;
        	}

        	//Click System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.AssignmentsButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SelfInfo);
        	
        	//Click Supervisor Dispatch Territory Defination in Assignment menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SupervisorTerritoriesInfo,
        	                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
        	
        	//Wait for Supervisor Dispatch Territory Definition to exist in case of lag
        	while (!AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo.Exists(0)  && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if (!AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo.Exists(0) )
        	{
        		Ranorex.Report.Error("Supervisor Dispatch Territory Definition did not open");
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Info("Supervisor Dispatch Territory Definition opened");
        	}
		}
    	
		/// <summary>
		/// Add or remove SSupervisor Dispatch Territory Positions from Unassigned , All Available or Assigned Dispatch Position.
		/// </summary>
		/// <param name="territoryName"></param>
		/// <param name="dispatchPositonType"></param>
		/// <param name="dispatchPostionName"></param>
		/// <param name="removePosition"></param>
		/// <param name="addPosition"></param>
		/// <param name="reset"></param>
		/// <param name="apply"></param>
		/// <param name="closeForms"></param>
    	[UserCodeMethod]
		public static void NS_ModifyTerritory_SupervisorDispatch_TerritoryDefinition(string territoryName, string dispatchPositonType, string dispatchPostionName, bool removePosition, bool addPosition, bool reset, bool apply, bool closeForms)
		{
			NS_OpenSupervisorDispatchTerritoryDefinition();
			int listSize = 0;
			if (territoryName != "")
			{
				AssignmentsRepo.SupervisorDispatchTerritory = territoryName;
				AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryText.Element.SetAttributeValue("DropDownVisible","True");
				if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo.Exists(0))
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo,
					                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo);
				}
				else{
					AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryText.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid territory position. Check data bindings and try again.");
				}
			}
			else
			{
				Ranorex.Report.Error("Territory should not be null");
				if(closeForms)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
        			                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
        		}
			}
			
			
			switch(dispatchPositonType.ToLower())
			{
				case "assignedposition" :
					AssignmentsRepo.AssignedName = dispatchPostionName;
					listSize = AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in Assigned Dispatch Position");
						if(removePosition)
						{
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByName.Click();
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.RemoveButton.Click();
							if(listSize>AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} removed from {"+dispatchPositonType+"}");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be removed from {"+dispatchPositonType+"}");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in {"+dispatchPositonType+"}");
						return;
					}
					break;
					
				case "unassignedposition":
					AssignmentsRepo.UnassignedName = dispatchPostionName;
					listSize = AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in Unassigned Dispatch Position");
						if(addPosition)
						{
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByName.Click();
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.UnassignedAvailableDispatchPositionsList.UnassignedListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AddButton.Click();
							if(listSize<AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} added to Assigned Dispatch Position");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be added to Assigned Dispatch Position");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in Unassigned Dispatch Position");
						return;
					}
					break;
					
				case "allavailableposition":
					AssignmentsRepo.AvailableName = dispatchPostionName;
					listSize = AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count;
					if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByNameInfo.Exists(0))
					{
						Ranorex.Report.Info("{"+dispatchPostionName+"} found in All Available Dispatch Position");
						if(addPosition)
						{
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByName.Click();
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AllAvailableDispatchPositionsList.AvailableListItemByName.PressKeys(dispatchPostionName);
							AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AddButton.Click();
							if(listSize<AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.Self.Items.Count)
							{
								Ranorex.Report.Success("{"+dispatchPostionName+"} added to Assigned Dispatch Position");
							}
							else
							{
								GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
								Ranorex.Report.Failure("{"+dispatchPostionName+"} could not be added to Assigned Dispatch Position");
								return;
							}
						}
					}
					else
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
						                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
						Ranorex.Report.Failure("{"+dispatchPostionName+"} not found in All Available Dispatch Position");
						return;
					}
					break;
					
				default :
						Ranorex.Report.Error("Invalid Selection List. Valid options are : assignedposition, unassignedposition, allavailableposition");
					break;
			}
			
			if(apply)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.ApplyButtonInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.ApplyButtonInfo);
			}
			
			if(reset)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.ResetButtonInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.ResetButtonInfo);
			}
			
			if(closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
			}
			
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePositionExists_SupervisorDispatch_TerritoryDefinition(string territoryName, string dispatchPostionName, bool expectedDispPosition = false, bool closeForm = false)
		{
			NS_OpenSupervisorDispatchTerritoryDefinition();
			if (territoryName == "")
			{
				Ranorex.Report.Error("Territory should not be null");
				if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
        			                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
        		}
				return;
			}
			else
			{
				AssignmentsRepo.SupervisorDispatchTerritory = territoryName;
				AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryText.Element.SetAttributeValue("DropDownVisible","True");
				if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo.Exists(0))
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo,
					                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryList.SupervisorDispatchTerritoryListItemByNameInfo);
				}
				else{
					AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SupervisorDispatchTerritory.SupervisorDispatchTerritoryText.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid territory position. Check data bindings and try again.");
				}
			}
			
			bool actualDispPosition = false;
			AssignmentsRepo.AssignedName = dispatchPostionName;
			if(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.AssignedDispatchPositionsList.AssignedListItemByNameInfo.Exists(0))
			{
				actualDispPosition = true;
			}
			
			if(actualDispPosition == expectedDispPosition)
			{
				Ranorex.Report.Success("Expected Assigned Dispatch Positon {"+dispatchPostionName+"} to exists as {"+expectedDispPosition+"} and actual found as {"+actualDispPosition+"}");
			}
			else
			{
				Ranorex.Report.Failure("Expected Assigned Dispatch Positon {"+dispatchPostionName+"} to exists as {"+expectedDispPosition+"} and actual found as {"+actualDispPosition+"}");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Supervisor_Dispatch_Territory_Definition.SelfInfo);
			}
		}
		
		//Open Daily Shift Schedule
		public static void NS_OpenDailyShiftSchedule_AssignementMenu()
		{
			if(!AssignmentsRepo.Daily_Shift_Schedule.SelfInfo.Exists(0))
			{
				
				
				//click assignment menu
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.AssignmentsButtonInfo,
				                                          MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SelfInfo);
				
				//click daily shift schedule
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.AssignmentsMenu.DailyShiftScheduleInfo,
				                                          AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
				
				int attempt = 0;
				while(!AssignmentsRepo.Daily_Shift_Schedule.SelfInfo.Exists(0) && attempt<3)
				{
					Ranorex.Delay.Milliseconds(500);
					attempt++;
				}
				
				if(!AssignmentsRepo.Daily_Shift_Schedule.SelfInfo.Exists(0))
				{
					Ranorex.Report.Failure("Failed to open Daily Shift schedule");
				}
				else{
					Ranorex.Report.Success("Daily Shift schedule opened");
				}
			}
			return;
		}
		
		public static void NS_SetDivisionAndScheduleTemplate(string division, string scheduleTemplate)
		{
			AssignmentsRepo.Division = division;
			//select division
			if(!AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuItem.GetAttributeValue<string>("Text").Equals(division,StringComparison.OrdinalIgnoreCase))
			{
				AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuItem.Element.SetAttributeValue("DropDownVisible","True");
				if(AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo.Exists(0))
				{
					Ranorex.Report.Info("TestStep", "Selecting Division {"+division+"}.");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo,
					                                                  AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);	
				}
				else{
					AssignmentsRepo.Daily_Shift_Schedule.Division.DivisionMenuItem.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid division. Check data bindings and try again.");
				}
			}
			
			AssignmentsRepo.ScheduleTemplateName = scheduleTemplate;
			//select schedule template
			if(!AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateText.GetAttributeValue<string>("Text").Equals(scheduleTemplate,StringComparison.OrdinalIgnoreCase))
			{
				AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateText.Element.SetAttributeValue("DropDownVisible","True");

				if(AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo.Exists(0))
				{
					Ranorex.Report.Info("TestStep", "Selecting Schedule Template {"+scheduleTemplate+"}.");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo,
					                                                  AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo);
				}
				else{
					AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateText.Element.SetAttributeValue("DropDownVisible","False");
					Ranorex.Report.Error("Please specify a valid schedule template. Check data bindings and try again.");
				}
			}
		}
		
		/// <summary>
		/// Creates new schedule template by selecting existing template
		/// </summary>
		/// <param name="division"></param>
		/// <param name="selectScheduleTemplate"></param>
		/// <param name="scheduleTemplateName"></param>
		/// <param name="scheduleTemplateDesc"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_SetNewScheduleTemplate_DailyShiftSchedule(string division, string selectScheduleTemplate, string scheduleTemplateName, string scheduleTemplateDesc, bool closeForm = false)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			
			NS_SetDivisionAndScheduleTemplate(division, selectScheduleTemplate);
			
			//click save as 
			GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.SaveAsButtonInfo,
			                                          AssignmentsRepo.Daily_Shift_Schedule.Save_As.SelfInfo);
			
			//enter new template name
			if(scheduleTemplateName != "")
			{
				AssignmentsRepo.Daily_Shift_Schedule.Save_As.ScheduleTemplateNameText.Element.SetAttributeValue("Text", scheduleTemplateName);
			}
			
			//enter new template description
			if(scheduleTemplateDesc != "")
			{
				AssignmentsRepo.Daily_Shift_Schedule.Save_As.ScheduleTemplateDescriptionText.Element.SetAttributeValue("Text", scheduleTemplateDesc);
			}
			
			//click ok to save the template
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.Save_As.OkButtonInfo,
			                                                  AssignmentsRepo.Daily_Shift_Schedule.Save_As.SelfInfo);
		
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		/// <summary>
		/// Validate schedule template exists in schedule template List
		/// </summary>
		/// <param name="scheduleTemplateName"></param>
		/// <param name="expectExists"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_ValidateScheduleTemplateExists_DailyShiftSchedule(string scheduleTemplateName, bool expectExists, bool closeForm)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			bool actualExists = false;
			
			AssignmentsRepo.ScheduleTemplateName = scheduleTemplateName;
			AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateText.Element.SetAttributeValue("DropDownVisible","True");
			
			//check is schedule template name exists
			if(AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo.Exists(0))
			{
				actualExists = true;
			}
			else{
				AssignmentsRepo.Daily_Shift_Schedule.ScheduleTemplate.ScheduleTemplateText.Element.SetAttributeValue("DropDownVisible","False");
			}
			
			//print success if result as expected
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected {"+scheduleTemplateName+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+scheduleTemplateName+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_SetScheduleTimeForDispaterTerritory_DailyShiftSchedule(string division, string selectScheduleTemplate, string time, string timeColumnNumber, bool apply, bool closeForm)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			
			//select Divisoin and schedule template
			NS_SetDivisionAndScheduleTemplate(division, selectScheduleTemplate);
			
			//select dispatch territory tab if not selected.
			if(!AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTab.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTabInfo,
				                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.SelfInfo);
			}
			
			//for new schedule time entry, row index is 0.
			AssignmentsRepo.DispatchTerritoryIndex = "0";
			
			//select timeColumnNumber 1
			switch(timeColumnNumber.ToLower())
			{
				case "timecolumn1" :
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn1.TimeColumn1Text.Click();
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn1.TimeColumn1Text.PressKeys(time);
					Keyboard.Press("{TAB}");
					break;
					
				case "timecolumn2" :
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn2.TimeColumn2Text.Click();
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn2.TimeColumn2Text.PressKeys(time);
					break;
					
				case "timecolumn3" :
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn3.TimeColumn3Text.Click();
					AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByIndex.TimeColumn3.TimeColumn3Text.PressKeys(time);
					Keyboard.Press("{TAB}");
					break;
					
					default: Ranorex.Report.Error("Invalid Time Column. Valid Time Column are : timecolumn1, timecolumn2 and timecolumn3");
					break;
			}
			
			//to apply
			if(apply)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Daily_Shift_Schedule.ApplyButtonInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.ApplyButtonInfo);
			}
			
			
			//to close
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidateScheduleTimeForDispaterTerritory_DailyShiftSchedule(string division, string selectScheduleTemplate, string timeColumnNumber, string time, bool expectExists, bool closeForm)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			
			//select Divisoin and schedule template
			NS_SetDivisionAndScheduleTemplate(division, selectScheduleTemplate);
			
			//select dispatch territory tab if not selected.
			if(!AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTab.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTabInfo,
				                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.SelfInfo);
			}
			
			bool actualExists = false;
			
			//select timeColumnNumber
			switch(timeColumnNumber.ToLower())
			{
				case "timecolumn1" :
					AssignmentsRepo.TimeColumn1Index = timeColumnNumber;
					GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1TextInfo,
					                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1TextInfo);
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.TimeColumnText.GetAttributeValue<string>("Text").Equals(time))
					{
						actualExists = true;
					}
					
					break;
					
				case "timecolumn2" :
					AssignmentsRepo.TimeColumn2Index = timeColumnNumber;
					GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2TextInfo,
					                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2TextInfo);
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.TimeColumnText.GetAttributeValue<string>("Text").Equals(time))
					{
						actualExists = true;
					}
					
					break;
					
				case "timecolumn3" :
					AssignmentsRepo.TimeColumn3Index = timeColumnNumber;
					GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3TextInfo,
					                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3TextInfo);
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.TimeColumnText.GetAttributeValue<string>("Text").Equals(time))
					{
						actualExists = true;
					}
					
					break;
					
					default: Ranorex.Report.Error("Invalid Time Column. Valid Time Column are : timecolumn1, timecolumn2 and timecolumn3");
					break;
					
			}
			
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected {"+time+"} in {"+timeColumnNumber+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+time+"} in {"+timeColumnNumber+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}

			//to close
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ValidatePhysicalPositionForDispaterTerritory_DailyShiftSchedule(string division, string selectScheduleTemplate, string territory, string timeColumnNumber, string physicalPosition , bool expectExists, bool closeForm)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			VMEnvironment vm = VMEnvironment.Instance();
			//select Divisoin and schedule template
			NS_SetDivisionAndScheduleTemplate(division, selectScheduleTemplate);
			
			//set <current physical position>(Logical Position) if physicalPositon is empty 
			string currentPhysicalPosition = "";
			if(physicalPosition == "")
			{
				currentPhysicalPosition = vm.computer;
			}
			else{
				currentPhysicalPosition = physicalPosition;
			}
			
			//select dispatch territory tab if not selected.
			if(!AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTab.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTabInfo,
				                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.SelfInfo);
			}
			
			bool actualExists = false;
			
			// select territory for which time needs to be validated. Keep "" to validate Schedule template time i.e row index = 0
			
			AssignmentsRepo.DispatchTerritoryName = territory;
			

			//select timeColumnNumber
			switch(timeColumnNumber.ToLower())
			{
				case "timecolumn1" :
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1Text.GetAttributeValue<string>("Text").Contains(currentPhysicalPosition))
					{
						actualExists = true;
					}
					
					break;
					
				case "timecolumn2" :
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2Text.GetAttributeValue<string>("Text").Contains(currentPhysicalPosition))
					{
						actualExists = true;
					}
					
					break;
					
				case "timecolumn3" :
					if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3Text.GetAttributeValue<string>("Text").Contains(currentPhysicalPosition))
					{
						actualExists = true;
					}
					
					break;
					
				default: Ranorex.Report.Error("Invalid Time Column. Valid Time Column are : timecolumn1, timecolumn2 and timecolumn3");
					break;
					
			}
			
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected {"+currentPhysicalPosition+"} in {"+timeColumnNumber+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}
			else{
				Ranorex.Report.Failure("Expected {"+currentPhysicalPosition+"} in {"+timeColumnNumber+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}");
			}

			//to close
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void NS_ModifyShiftTimeForDispaterTerritory_DailyShiftSchedule(string division, string selectScheduleTemplate, string territory, string logicalPosition, string timeColumnNumber, bool apply, bool closeForm = false)
		{
			NS_OpenDailyShiftSchedule_AssignementMenu();
			VMEnvironment vm = VMEnvironment.Instance();
			string logicalPositionName = "";
			
			//set <current physical position>(Logical Position) if logicalPosition is empty 
			if(logicalPosition == "")
			{
				logicalPositionName = vm.computer;
			}
			else{
				logicalPositionName = logicalPosition;
			}
			
			//select Divisoin and schedule template
			NS_SetDivisionAndScheduleTemplate(division,selectScheduleTemplate);
			
			//select dispatch territory tab if not selected.
			if(!AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTab.GetAttributeValue<bool>("Selected"))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DailyShiftScheduleTabs.DispatchTerritoryTabInfo,
				                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.SelfInfo);
			}
			
			AssignmentsRepo.DispatchTerritoryName = territory;
			
			// modify TIME in timecolumn with for respective territory
			if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.DispatchTerritoryInfo.Exists(0))
			{
				switch(timeColumnNumber.ToLower())
				{
					case "timecolumn1" :
						AssignmentsRepo.TimeColumn1Name = logicalPositionName;
						GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1TextInfo,
						                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.SelfInfo);
						
						if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.TimeColumn1ListItemByNameInfo.Exists(0))
						{
							AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.TimeColumn1ListItemByName.EnsureVisible();
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.TimeColumn1ListItemByNameInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.TimeColumn1ListItemByNameInfo);
							Ranorex.Report.Success("Shift time column {"+timeColumnNumber+"} for Territory {"+territory+"} has been set");
						}
						else{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1TextInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn1.TimeColumn1List.SelfInfo);
							Ranorex.Report.Error("Please specify a valid Logical Name. Check data bindings and try again.");
						}
						
						break;
						
					case "timecolumn2" :
						AssignmentsRepo.TimeColumn2Name = logicalPositionName;
						GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2TextInfo,
						                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.SelfInfo);
						
						if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.TimeColumn2ListItemByNameInfo.Exists(0))
						{
							AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.TimeColumn2ListItemByName.EnsureVisible();
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.TimeColumn2ListItemByNameInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.TimeColumn2ListItemByNameInfo);
							Ranorex.Report.Success("Shift time column {"+timeColumnNumber+"} for Territory {"+territory+"} has been set");
						}
						else{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2TextInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn2.TimeColumn2List.SelfInfo);
							Ranorex.Report.Error("Please specify a valid Logical Name. Check data bindings and try again.");
						}
						
						break;
						
					case "timecolumn3" :
						AssignmentsRepo.TimeColumn3Name = logicalPositionName;
						GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3TextInfo,
						                                          AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.SelfInfo);
						
						if(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.TimeColumn3ListItemByNameInfo.Exists(0))
						{
							AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.TimeColumn3ListItemByName.EnsureVisible();
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.TimeColumn3ListItemByNameInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.TimeColumn3ListItemByNameInfo);
							Ranorex.Report.Success("Shift time column {"+timeColumnNumber+"} for Territory {"+territory+"} has been set");
						}
						else{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3TextInfo,
							                                                  AssignmentsRepo.Daily_Shift_Schedule.DispatchTerritory.DispatchTerritoryTable.DispatchTerritoryRowByDispatchTerritoryName.TimeColumn3.TimeColumn3List.SelfInfo);
							Ranorex.Report.Error("Please specify a valid Logical Name. Check data bindings and try again.");
						}
						
						break;

					default : Ranorex.Report.Error("Invalid Time column. The valid options are 1,2 and 3.");
						break;
				}
			}
			
			//to apply
			if(apply)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(AssignmentsRepo.Daily_Shift_Schedule.ApplyButtonInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.ApplyButtonInfo);
			}
			
			//to close
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Daily_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Daily_Shift_Schedule.SelfInfo);
			}
		}
		
		//opens Masterr shift schedule form
		public static void NS_OpenMasterShiftSchedule_AssignementMenu()
		{
			if(!AssignmentsRepo.Master_Shift_Schedule.SelfInfo.Exists(0))
			{
				
				GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.AssignmentsButtonInfo,
				                                          MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SelfInfo);
				
				GeneralUtilities.MiddleClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.AssignmentsMenu.MasterShiftScheduleInfo,
				                                                        MainMenurepo.PDS_Main_Menu.AssignmentsMenu.SelfInfo);
				
				int attempt = 0;
				while(!AssignmentsRepo.Master_Shift_Schedule.SelfInfo.Exists(0) && attempt<3)
				{
					Ranorex.Delay.Milliseconds(500);
					attempt++;
				}
				
				if(!AssignmentsRepo.Master_Shift_Schedule.SelfInfo.Exists(0))
				{
					Ranorex.Report.Failure("Failed to open Master Shift schedule");
				}
				else{
					Ranorex.Report.Success("Master Shift schedule opened");
				}
			}
			return;
		}
		
		/// <summary>
		/// Modify schedule template for required Day of the week.
		/// </summary>
		/// <param name="scheduleTemplate"></param>
		/// <param name="dayOfTheWeek"></param>
		/// <param name="clickOk"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule(string scheduleTemplate, string dayOfTheWeek, bool clickOk, bool closeForm)
		{
			NS_OpenMasterShiftSchedule_AssignementMenu();
			
			AssignmentsRepo.WeekDay = dayOfTheWeek;
			
			//set schedule template if it exists for respective Day of the week
			if(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.DayInfo.Exists(0))
			{
				AssignmentsRepo.ScheduleTemplateName = scheduleTemplate;
				GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateTextInfo,
				                                          AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateList.SelfInfo);
				
				if(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo.Exists(0))
				{
					Ranorex.Report.Info("TestStep", "Selecting Schedule Template {"+scheduleTemplate+"}.");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo,
					                                                  AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateList.ScheduleTemplateListItemByNameInfo);
				}
				else{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateTextInfo,
					                                                  AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateList.SelfInfo);
					Ranorex.Report.Error("Please specify a valid schedule template. Check data bindings and try again.");
				}
			}
			else{
				Ranorex.Report.Error("Please specify a valid day of the week. Check data bindings and try again.");
			}
			
			//click ok to apply
			if(clickOk)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.OkButtonInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
				return;
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
			}
		}
		
		/// <summary>
		/// Modify Shift transistion interval value
		/// </summary>
		/// <param name="transitionInterval"></param>
		/// <param name="clickOk"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_ModifyShiftTransitionInterval_MasterShiftSchedule(string transitionInterval, bool clickOk, bool closeForm)
		{
			NS_OpenMasterShiftSchedule_AssignementMenu();
			
			if(transitionInterval != "")
			{
				Ranorex.Report.Info("Teststep", "Setting shift transition interval ");
				AssignmentsRepo.Master_Shift_Schedule.ShiftTransitionIntervalText.PressKeys(transitionInterval);
			}
			else{
				Ranorex.Report.Error("Transition interval is null");
				return;
			}
			
			if(clickOk)
			{
				Ranorex.Report.Info("Teststep", "clicking OK to apply settings ");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.OkButtonInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
				return;
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
			}
		}
		
		/// <summary>
		/// Validates Schedule template is assigned as expected, for required Day of the week.
		/// </summary>
		/// <param name="scheduleTemplate"></param>
		/// <param name="dayOfTheWeek"></param>
		/// <param name="expectExists"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule(string scheduleTemplate, string dayOfTheWeek, bool expectExists, bool closeForm)
		{
			NS_OpenMasterShiftSchedule_AssignementMenu();
			AssignmentsRepo.WeekDay = dayOfTheWeek;
			bool actualExists = false;
			
			//checks schedule template is as expected
			if(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.DayInfo.Exists(0))
			{
				if(AssignmentsRepo.Master_Shift_Schedule.RegularShiftScheduleTable.RegularShiftScheduleRowByWeekDay.ScheduleTemplate.ScheduleTemplateText.GetAttributeValue<string>("Text").Equals(scheduleTemplate,StringComparison.OrdinalIgnoreCase))
				{
					actualExists = true;
				}
			}
			else{
				Ranorex.Report.Error("Please specify a valid day of the week. Check data bindings and try again.");
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected schedule template {"+scheduleTemplate+"} for day:{"+dayOfTheWeek+"} as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected schedule template {"+scheduleTemplate+"} for day:{"+dayOfTheWeek+"} as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
			}
		}
		
		/// <summary>
		/// Validate Shift Transistion Interval value
		/// </summary>
		/// <param name="transitionInterval"></param>
		/// <param name="expectExists"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_ValidateShiftTransitionIntervalExists_MasterShiftSchedule(string transitionInterval, bool expectExists, bool closeForm)
		{
			NS_OpenMasterShiftSchedule_AssignementMenu();

			bool actualExists = false;

			if(AssignmentsRepo.Master_Shift_Schedule.ShiftTransitionIntervalTextInfo.Exists(0))
			{
				if(AssignmentsRepo.Master_Shift_Schedule.ShiftTransitionIntervalText.GetAttributeValue<string>("Text").Equals(transitionInterval))
				{
					actualExists = true;
				}
			}
			else{
				Ranorex.Report.Error("Shift Transition Infromation does not exists");
			}
			
			if(actualExists == expectExists)
			{
				Ranorex.Report.Success("Expected Shift Transition value: {"+transitionInterval+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
			else{
				Ranorex.Report.Failure("Expected Shift Transition value: {"+transitionInterval+"} to exists as {"+expectExists+"} and found as {"+actualExists+"}.");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
			}
		}
		
		/// <summary>
		/// Delete Existing Schedule Template from Available Schedule template List
		/// </summary>
		/// <param name="scheduleTemplate"></param>
		/// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_DeleteScheduleTemplate_MasterShiftSchedule(string scheduleTemplate, bool closeForm)
		{
			NS_OpenMasterShiftSchedule_AssignementMenu();
			
			//Open Delete schedule Template form
			GeneralUtilities.ClickAndWaitForWithRetry(AssignmentsRepo.Master_Shift_Schedule.DeleteScheduleTemplateButtonInfo,
			                                          AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.SelfInfo);
			
			AssignmentsRepo.AvailableScheduleName = scheduleTemplate;
			
			if(AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.AvailableScheduleTemplatesList.AvailableScheduleListItemByNameInfo.Exists(0))
			{
				Ranorex.Report.Info("TestStep", "Selecting schedule template for deleting");
				AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.AvailableScheduleTemplatesList.AvailableScheduleListItemByName.Click();
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.DeleteButtonInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.AvailableScheduleTemplatesList.AvailableScheduleListItemByNameInfo);				
			}
			else{
				Ranorex.Report.Error("Schedule Template name not found in the available list. Verify data binding and try again");
			}
			
			if(closeForm)
			{
				//close delete schedule template
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.Delete_Schedule_Template.SelfInfo);
				
				//close master shift schedule template
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(AssignmentsRepo.Master_Shift_Schedule.WindowControls.CloseInfo,
				                                                  AssignmentsRepo.Master_Shift_Schedule.SelfInfo);
			}
		}
    }
}
