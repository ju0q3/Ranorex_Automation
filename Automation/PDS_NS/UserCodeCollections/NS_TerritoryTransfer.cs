/*
 * Created by Ranorex
 * User: 503003600
 * Date: 11/8/2018
 * Time: 1:55 PM
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
using PDS_NS.UserCodeCollections;

namespace PDS_NS.CodeUtils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_TerritoryTransfer
    {
    	
    	public static global::PDS_NS.TerritoryTransfer_Repo TerritoryTransferrepo = global::PDS_NS.TerritoryTransfer_Repo.Instance;
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        
        /// <summary>
    	/// Opens the Bulletin Input Form if not already open
    	/// </summary>
        [UserCodeMethod]
        public static void NS_OpenTerritoryTransfer()
        {
        	
        	int retries = 0;

    		//Open Territory Transfer Form if it's not already open
    		if (!TerritoryTransferrepo.Territory_Transfer.SelfInfo.Exists(0))
    		{
    			//Click File menu
    			PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo, MainMenurepo.PDS_Main_Menu.FileMenu.TerritoryTransferInfo);
    			//Click Territory Transfer in file menu
    			MainMenurepo.PDS_Main_Menu.FileMenu.TerritoryTransfer.Click();
    			
    			//Wait for Territory Transfer Form to exist in case of lag
    			if (!TerritoryTransferrepo.Territory_Transfer.SelfInfo.Exists(0))
    			{
    				Ranorex.Delay.Milliseconds(500);
    				while (!TerritoryTransferrepo.Territory_Transfer.SelfInfo.Exists(0) && retries < 2) 
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}
    				
    				if (!TerritoryTransferrepo.Territory_Transfer.SelfInfo.Exists(0))
    				{
    					Ranorex.Report.Error("Territory Transfer form did not open");
    					return;
    				}
    			}	
    		} else {
    			TerritoryTransferrepo.Territory_Transfer.Self.EnsureVisible();
        	}
    		
    		
    		return;
        }

		[UserCodeMethod]
		public static void NS_OpenControlRequestList()
		{
			if (!TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
			{
				int retries = 0;
				while (!TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0) && retries < 3)
				{
					GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.WindowButtonInfo, MainMenurepo.PDS_Main_Menu.WindowMenu.ControlRequestListInfo);
					MainMenurepo.PDS_Main_Menu.WindowMenu.ControlRequestList.Click();
					retries++;
				}
			}
			
			if (!TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
			{
				Report.Error("Unable to open Control Request List.");
			}
			
			// Could be a residual consequence from while loop above.
			if (MainMenurepo.PDS_Main_Menu.WindowMenu.ControlRequestListInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.WindowButtonInfo, MainMenurepo.PDS_Main_Menu.WindowMenu.ControlRequestListInfo);
			}
			
			TerritoryTransferrepo.Control_Request_List.TransmitButton.EnsureVisible();
		}
		
		[UserCodeMethod]
		public static void NS_CloseControlRequestList()
		{
			if(!TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
			{
				Report.Info("Control Request List is not open!!");
				return;
			}
			else
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Control_Request_List.WindowControls.CloseInfo, TerritoryTransferrepo.Control_Request_List.SelfInfo);
			}
			
			if(TerritoryTransferrepo.Control_Request_List.SelfInfo.Exists(0))
			{
				Report.Failure("Failed to close control request list.");
			} else {
				Report.Success("Successfully closed control request list.");
			}
		}
		
		[UserCodeMethod]
		public static void NS_ClearControlRequestList()
		{
			NS_OpenControlRequestList();
			
			// There has been a problem in successfully clearing the CRL list ...
			for (int i = 0; i < 3; i++)
			{
				TerritoryTransferrepo.Control_Request_List.ClearListButton.Click();
				Delay.Milliseconds(250);
			}
			NS_TerritoryTransfer_Validations.NS_ValidateIsClear_ControlRequestList(true);			
		}
		
		[UserCodeMethod]
		public static void NS_TransmitControlRequestList()
		{
			NS_OpenControlRequestList();
			TerritoryTransferrepo.Control_Request_List.TransmitButton.Click();
		}
		
		[UserCodeMethod]
		public static void NS_UndoControlRequestList()
		{
			NS_OpenControlRequestList();
			TerritoryTransferrepo.Control_Request_List.UndoButton.Click();
		}
        
        /// <summary>
    	/// Opens Territory Transfer if necessary and takes a territory
    	/// </summary>
    	/// <param name="divisionName">Input:divisionName</param>
    	/// <param name="territoryName">Input:territoryName</param>
    	/// <param name="closeForms">Input:Close Dispatch Transfer Report and Territory Transfer Form </param>
        [UserCodeMethod]
        public static void NS_RequestTerritory(string divisionName, string territoryName, bool pressApply, bool closeForms)
        {
        	//Exit function if one of the variables isn't populated
        	if (territoryName == "" || divisionName == "") 
        	{
        		return;
        	}
        	
        	if (!territoryName.Contains("-")) {
        		if (!territoryName.EndsWith(" "))
        		{
        			territoryName = territoryName + " ";
        		}
        	}
        	TerritoryTransferrepo.DivisionName = divisionName;
        	TerritoryTransferrepo.TerritoryName = territoryName;
        	
        	NS_OpenTerritoryTransfer();
        	
        	//If All Dispatch Territories Tab is selected, then we don't need to do anything
    		if (!TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.AllDispatchTerritoriesTab.GetAttributeValue<bool>("Selected"))
    		{
    			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.AllDispatchTerritoriesTabInfo,
    			                                          TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.TerritoriesList.SelfInfo);
    		}
        	
        	//Check if Territory is already in held territories
        	if(TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.HeldList.HeldListItemByTerritoryNameInfo.Exists(0)) 
        	{
        		Ranorex.Report.Info("Territory {"+territoryName+"} already in held Territories.");
        		if(closeForms)
	        	{
	        		//Close Territory Transfer
	        		TerritoryTransferrepo.Territory_Transfer.CancelButton.Click();
	        	}
        		return;
        	}
        	//Select division if not selected
        	string currentDivision = TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.Division.DivisionMenuButton.GetAttributeValue<string>("SelectedItemText");
        	if(currentDivision != TerritoryTransferrepo.DivisionName)
        	{
        		TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.Division.DivisionMenuButton.Click();
        		//If we cannot find the division, it was probably a typo or broken server-side Territory population
        		if(!TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.Division.DivisionMenuList.DivisionListItemByNameInfo.Exists(0))
        		{
        			TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.Division.DivisionMenuButton.Click();
        			Ranorex.Report.Error("Unable to find division {"+divisionName+"} in territory transfer");
        			if(closeForms)
		        	{
		        		//Close Territory Transfer
		        		TerritoryTransferrepo.Territory_Transfer.CancelButton.Click();
		        	}
        			return;
        		}
            	TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.Division.DivisionMenuList.DivisionListItemByName.Click();
        	}
        	//Make sure territory name is in Requestable Territories
        	Ranorex.Report.Screenshot(TerritoryTransferrepo.Territory_Transfer.Self);
        	//Ranorex.Report.Info(TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.TerritoriesList.TerritoriesListItemByName.Visible.ToString());
        	int territoryCount = TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.TerritoriesList.Self.GetAttributeValue<int>("LastVisibleIndex");
        	bool foundTerritory = false;
        	string territoryIndexName = "";
        	int retries = 0;

        	for(int i=0; i<=territoryCount; i++)
        	{
        		TerritoryTransferrepo.TerritoryIndex = i.ToString();
        		territoryIndexName = TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.TerritoriesList.TerritoriesListItemByIndex.GetAttributeValue<string>("Text").ToLower();
        		
        		if(territoryIndexName.Contains(territoryName.ToLower()))
        		{
        			foundTerritory = true;
        			break;
        		} 
        		else 
        		{
        			foundTerritory = false;
        		}
        	}
        	if(!foundTerritory)
        	{
        		Ranorex.Report.Error("Could not find territory {"+territoryName+"} in division {"+divisionName+"} within territory transfer");
        		if(closeForms)
	        	{
	        		//Close Territory Transfer
	        		TerritoryTransferrepo.Territory_Transfer.CancelButton.Click();
	        	}
        		return;
        	}
        	TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.TerritoriesList.TerritoriesListItemByIndex.DoubleClick();
        	Ranorex.Report.Info("TestStep", "Took territory {"+territoryName+"} from division {"+divisionName+"}.");
        	
        	if(pressApply)
        	{
        		TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.ApplyButton.Click();
        		while (TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled") && retries < 25)
		        {
					TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.ApplyButton.Click();	
    				Ranorex.Delay.Milliseconds(500);
		        	retries++;
		       	}
    			if (TerritoryTransferrepo.Territory_Transfer.AllDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled"))
    			{
    				Ranorex.Report.Error("Apply Request territory failed!");
    			}
        	}
        	
        	if(closeForms)
        	{
        		retries = 0;
        		//Close Dispatch Transfer Report
        		while(!TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0) && retries < 5)
        		{
        			GeneralUtilities.CheckWaitState(10);
        			Ranorex.Delay.Seconds(2);
        			retries++;
        		}
        		TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButton.Click();
        		
        		//Close Territory Transfer
        		TerritoryTransferrepo.Territory_Transfer.Self.EnsureVisible();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.CancelButtonInfo,
        		                                                  TerritoryTransferrepo.Territory_Transfer.SelfInfo);
        	}
        	return;
        }
        
       	/// <summary>
    	/// Release Territorry Controlled
    	/// </summary>
    	/// <param name="territoryName">Input:territoryName</param>
    	/// <param name="removeButton">Input:removeButton</param>
    	/// <param name="pressApply">Input:pressApply</param>
    	/// <param name="closeForm">Input:closeForm</param>
    	[UserCodeMethod]
        public static void NS_ReleaseTerritory(string territoryName,bool removeButton, bool pressApply, bool closeForm)
        {
        	
        	int retries = 0;
        	
        	//Exit function if the variable isn't populated
        	if (territoryName == "") {
        		return;
        	}
        	
        	if (!territoryName.Contains("-")) {
        		if (!territoryName.EndsWith(" "))
        		{
        			territoryName = territoryName + " ";
        		}
        	}
        	
        	TerritoryTransferrepo.TerritoryName = territoryName;
        	NS_OpenTerritoryTransfer();
        	
        	TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.HeldDispatchTerritoriesTab.Click();
        	
        	//If Held Dispatch Territories Tab is not selected, then select it
    		while (!TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.HeldDispatchTerritoriesTab.GetAttributeValue<bool>("Selected") && retries < 2)
    		{
    			TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.HeldDispatchTerritoriesTab.Click();
    			Ranorex.Delay.Milliseconds(100);
    			retries++;
  			}
			
    		retries = 0;
        	//Check if Territory is in held territories
        	while (!TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByNameInfo.Exists(0) && retries < 2) 
        	{
        		Ranorex.Delay.Milliseconds(100);
    			retries++;
        	} 
        	if (!TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByNameInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Unable to find territory {"+territoryName+"} in held dispatcher territories");
        	}
        	else
        	{
  				retries = 0;	      	
    			if (removeButton) 
    			{
    				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByName.Click();
    				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveButton.Click();
    				
    			} else 
    			{
    				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByName.DoubleClick();
    			}
        		while (!TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ReleaseControlList.ReleaseControlListItemByNameInfo.Exists(0) && retries < 3) 
    			{
        			// if removeButton is set to true territories are release by remove button
        			if (removeButton) 
        			{
        				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByName.Click();
        				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveButton.Click();
        				
        			} 
        			else
        			{
        				// release territories by double clicking on the territory name
        				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByName.DoubleClick();
        			}
        			Ranorex.Delay.Milliseconds(500);
    				retries++;
    			}
        		
        		//Check if the territory is in Held Dispatcher Territories-Release Control
        		if(TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ReleaseControlList.ReleaseControlListItemByNameInfo.Exists(0)) 
        		{
        			Ranorex.Report.Info("Released territory {"+territoryName+"} ");
        			//Apply release teeritory
        			if (pressApply)
    				{
	    				retries = 0;
	    				TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.Click();
		    			while (TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled") && retries < 3)
				        {
							TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.Click();	
		    				Ranorex.Delay.Milliseconds(200);
				        	retries++;
				       	}
		    			if (TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled"))
		    			{
		    				Ranorex.Report.Error("Apply Release territory failed!");
		    			}
			    	    
    				}
        			
        		} 
        		else 
        		{
        			Ranorex.Report.Error("Requested territory {"+territoryName+"} in not Released");	
        		}
        		
        		 				
        	}
			//Close Territory Transfer        	
        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.CancelButtonInfo, TerritoryTransferrepo.Territory_Transfer.SelfInfo);
        	}
			
			return;        	
        			
        }    

      	/// <summary>
    	/// Release All Territorries Controlled 
    	///<param name="pressApply">Input:pressApply</param>
    	///<param name="closeForm">Input:closeForm</param> 
    	/// </summary>
    	[UserCodeMethod]
        public static void NS_ReleaseAllTerritories(bool pressApply, bool closeForm)
        {
        	int retries = 0;
        	NS_OpenTerritoryTransfer();
        	
        	//If Held Dispatch Territories Tab is not selected, then select it
    		if (!TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.HeldDispatchTerritoriesTab.GetAttributeValue<bool>("Selected"))
    		{
    			GeneralUtilities.LeftClickAndWaitForWithRetry(TerritoryTransferrepo.Territory_Transfer.TerritoryTabs.HeldDispatchTerritoriesTabInfo, TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveAllButtonInfo);
    		}
    		
    		while (!TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveAllButton.Enabled && retries < 3)
    		{
    		    Ranorex.Delay.Milliseconds(500);
    		    retries++;
    		}

    		//Click on remove all button to release territories
    		if (TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveAllButton.Enabled)
    		{
    			GeneralUtilities.ClickAndWaitForDisabledWithRetry(TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveAllButtonInfo, TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.RemoveAllButtonInfo);
    			{
	    			retries = 0;
	    			TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.Click();
	    			while (TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled") && retries < 5)
			        {
						TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.Click();	
	    				Ranorex.Delay.Milliseconds(300);
			        	retries++;
			       	}
	    			if (TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.ApplyButton.GetAttributeValue<bool>("Enabled"))
	    			{
	    				Ranorex.Report.Error("Apply Release All territories failed!");
	    			}
    			}
    		} 
    		else
    		{
    			Report.Screenshot();
    			TerritoryTransferrepo.TerritoryIndex = "0";
    			if (!TerritoryTransferrepo.Territory_Transfer.HeldDispatchTerritories.HeldList.HeldListItemByIndexInfo.Exists(0))
    				Report.Warn("No Dispatch territories are currently held.");
    			else
    				Ranorex.Report.Error("Release all territories failed! Remove All did not become enabled.");	
    		}
    		//Close Territory Transfer
    		if (closeForm)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.CancelButtonInfo, TerritoryTransferrepo.Territory_Transfer.SelfInfo);
    		}
    		
    		return;
        }
        
         
        /// <summary>
    	/// Click on 'Territory Transfer' link form main menu
    	/// </summary>
    	[UserCodeMethod]
    	public static void ClickOnTerritoryTransferLinkFromMainMenu()
    	{
    		//Open Territory Transfer Form if it's not already open
    		if (!TerritoryTransferrepo.Territory_Transfer.SelfInfo.Exists(0))
    		{
    			//Click File menu
    			PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo, MainMenurepo.PDS_Main_Menu.FileMenu.TerritoryTransferInfo);
    			
    			//Click Territory Transfer in file menu
    			MainMenurepo.PDS_Main_Menu.FileMenu.TerritoryTransfer.Click();
    			
    		}
    	} 
    	
    	/// <summary>
    	/// Opens track line from main menu if not already open
    	/// </summary>
        [UserCodeMethod]
        public static void NS_OpenTrackLine()
        {
        	int retries = 0;
    		//Open Trackline Form if it's not already open
    		if (!TerritoryTransferrepo.Open_Trackline.SelfInfo.Exists(0))
    		{
    			//Click File menu
    			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo, MainMenurepo.PDS_Main_Menu.FileMenu.OpenTracklineInfo);
    			//Click Open Trackline in file menu
    			GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.FileMenu.OpenTracklineInfo,TerritoryTransferrepo.Open_Trackline.SelfInfo);
    			//Wait for Open Trackline Form to exist in case of lag
    		} 
    		else 
    		{
    			TerritoryTransferrepo.Open_Trackline.Self.EnsureVisible();
        	}
    		
    		while (!TerritoryTransferrepo.Open_Trackline.AvailableList.AvailableListItemByNameInfo.Exists(0) && retries < 3)
    		{
    			Ranorex.Delay.Milliseconds(500);
    			retries++;
    		}
    		
    		if (!TerritoryTransferrepo.Open_Trackline.AvailableList.AvailableListItemByNameInfo.Exists(0))
    		{
    			Ranorex.Report.Error("Territory Open Trackline form did not open with districts.");
    			return;
    		}
    				
    		
    		return;
        }
        
         /// <summary>
    	/// Opens Trackline if necessary to open.
    	/// </summary>
    	/// <param name="divisionName">Input:divisionName</param>
    	/// <param name="territoryName">Input:territoryName</param>
    	/// <param name="closeForms">Input:Close Dispatch Transfer Report and Territory Transfer Form </param>
        [UserCodeMethod]
        public static void NS_Territory_Open_Trackline(string divisionName, string territoryName, bool pressOk, bool closeForms)
        {
        	//Exit function if one of the variables isn't populated
        	if (territoryName == "" || divisionName == "") 
        	{
        		return;
        	}
        	
        	if (!territoryName.Contains("-")) 
        	{
        		if (!territoryName.EndsWith(" "))
        		{
        			territoryName = territoryName + " ";
        		}
        	}
        	TerritoryTransferrepo.DivisionName = divisionName;
        	TerritoryTransferrepo.TerritoryName = territoryName;
        	
        	NS_OpenTrackLine();
        	
        	//Select division if not selected
        	string currentDivision = TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuButton.GetAttributeValue<string>("SelectedItemText");
        	if(currentDivision != TerritoryTransferrepo.DivisionName)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuButtonInfo, 
        			                                                  TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuList.SelfInfo);
        		//If we cannot find the division, it was probably a typo or broken server-side Territory population
        		if(!TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuList.DivisionItemByNameInfo.Exists(0))
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuButtonInfo, 
        			                                                  TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuList.SelfInfo);
        			Ranorex.Report.Error("Unable to find division {"+divisionName+"} in territory transfer");
        			if(closeForms)
		        	{
		        		//Close Territory Transfer
		        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Open_Trackline.CancelButtonInfo, TerritoryTransferrepo.Open_Trackline.SelfInfo);
		        	}
        			return;
        		}
        		
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuList.DivisionItemByNameInfo, 
        			                                                  TerritoryTransferrepo.Open_Trackline.Division.DivisionMenuList.SelfInfo);
        	}
        	
        	int territoryCount = TerritoryTransferrepo.Open_Trackline.AvailableList.Self.GetAttributeValue<int>("LastVisibleIndex");
        	bool foundTerritory = false;
        	string territoryIndexName = "";

        	for(int i=0; i<=territoryCount; i++)
        	{
        		TerritoryTransferrepo.TerritoryIndex = i.ToString();
        		territoryIndexName = TerritoryTransferrepo.Open_Trackline.AvailableList.AvailableListItemByIndex.GetAttributeValue<string>("Text").ToLower();
        		
        		if(territoryIndexName.Contains(territoryName.ToLower()))
        		{
        			foundTerritory = true;
        			break;
        		} 
        		else 
        		{
        			foundTerritory = false;
        		}
        	}
        	if(!foundTerritory)
        	{
        		Ranorex.Report.Error("Could not find territory {"+territoryName+"} in division {"+divisionName+"} within territory transfer");
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Open_Trackline.CancelButtonInfo, TerritoryTransferrepo.Open_Trackline.SelfInfo);
        		return;
        	}
        	TerritoryTransferrepo.Open_Trackline.AvailableList.AvailableListItemByIndex.DoubleClick();
        	Ranorex.Report.Info("TestStep", "Took territory {"+territoryName+"} from division {"+divisionName+"}.");
        	
        	if(pressOk)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Open_Trackline.OkButtonInfo,TerritoryTransferrepo.Open_Trackline.SelfInfo);
        	}
        	
        	if(closeForms)
        	{
        		//Close Dispatch Transfer Report
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        	return;
        }
        /// <summary>
    	/// Opens Territory Transfer if necessary and takes a territory
    	/// </summary>
    	/// <param name="supervisorDispatchGroupName">Input:supervisordispatchGroupName</param>
    	/// <param name="pressApply">Input:pressApply</param>
    	/// <param name="closeForms">Input:Close Dispatch Transfer Report and Territory Transfer Form </param>
        [UserCodeMethod]
        public static void NS_SignalTechnicianOrSupervisorRequestDispatchGroup_TerritoryTransfer(string userType,string dispatchGroup, bool pressApply, bool closeForms)
        {
        	//Exit function if  supervisordispatchGroupName isn't populated
        	if ( dispatchGroup == "")
        	{
        		Ranorex.Report.Error("No Dispatch Group given to be selected, ensure variables are properly bound");
        		return;
        	}

        	TerritoryTransferrepo.DispatchGroup = dispatchGroup;
        	
        	NS_OpenTerritoryTransfer();
        	
        	//Check if DispatchGroup is already in held window:
        	if(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.HeldList.HeldListItemByDispatchGroupInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Dispatch Group {"+dispatchGroup+"} already in held window.");
        		if(closeForms)
        		{
        			//Close Territory Transfer
        			TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.CancelButton.Click();
        		}
        		return;
        	}
        	switch(userType)
        	{

        		case "SupervisorDispatchGroups":
        			//Make sure distpatch group name is in Requestable Territories
        			if(!TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.SupervisorDispatchGroupsList.SupervisorDispatchGroupListItemByDispatchGroupInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find DispatchGroup {"+dispatchGroup+"} within territory transfer");
        				if(closeForms)
        				{
        					//Close Territory Transfer
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.CancelButtonInfo,TerritoryTransferrepo.Territory_Transfer.SelfInfo);
        				}
        				return;
        			}
        			TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.SupervisorDispatchGroupsList.SupervisorDispatchGroupListItemByDispatchGroup.Click();
        			break;

        		case "SignalTechnicianDispatchGroups":
        			//Make sure distpatch group name is in Requestable Territories
        			if(!TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.SignalTechnicianDispatchGroupsList.SignalTechnicianGroupListItemByDispatchGroupInfo.Exists(0))
        			{
        				Ranorex.Report.Error("Could not find DispatchGroup {"+dispatchGroup+"} within territory transfer");
        				if(closeForms)
        				{
        					//Close Territory Transfer
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.CancelButtonInfo,TerritoryTransferrepo.Territory_Transfer.SelfInfo);
        				}
        				return;
        			}
        			TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.SignalTechnicianDispatchGroupsList.SignalTechnicianGroupListItemByDispatchGroup.Click();
        			break;

        	}
        	TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.AddButton.Click();
        	Ranorex.Report.Info("TestStep", "Took dispatch Group {"+dispatchGroup+"} within territory transfer");
       
        	if(pressApply)
        	{
        		int retries = 0;
        		GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.ApplyButtonInfo,TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.Accept_Control.SelfInfo);
        		while (TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.ApplyButtonInfo.Exists(0) && retries < 3)
        		{
        			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.ApplyButtonInfo,TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.Accept_Control.SelfInfo);
        			Ranorex.Delay.Milliseconds(100);
        			
        			retries++;
        		}
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.Accept_Control.CloseButtonInfo,TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.Accept_Control.SelfInfo);

        		if (TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.ApplyButton.GetAttributeValue<bool>("Enabled"))
        		{
        			Ranorex.Report.Error("Apply Request Dispatch Group failed!");
        		}
        	}
        	
        	if(closeForms)
        	{
        		//Close Territory Transfer
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Territory_Transfer.SupervisorWindow.OkButtonInfo,TerritoryTransferrepo.Territory_Transfer.SelfInfo);
        	}
        	return;
        }
        
	}
	
	[UserCodeCollection]
	public class NS_TerritoryTransfer_Validations
	{
		public static global::PDS_NS.TerritoryTransfer_Repo TerritoryTransferrepo = global::PDS_NS.TerritoryTransfer_Repo.Instance;
		public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
		public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
		/// <summary>
		/// Validates expected feedback from CRL form
		/// </summary>
		/// <param name="expectedFeedback">Input: expectedFeedback</param>
		[UserCodeMethod]
		public static void NS_ValidateFeedback_ControlRequestList(string expectedFeedback)
		{
			NS_TerritoryTransfer.NS_OpenControlRequestList();
			
			Ranorex.Delay.Milliseconds(500); // Smallest of delays for error message to appear.
			string feedback = TerritoryTransferrepo.Control_Request_List.Feedback.TextValue.ToString();
			

			Ranorex.Report.Info("TestStep", string.Format("Validating that feedback from Control Request List contains '{0}'", expectedFeedback));
			Ranorex.Report.Info(string.Format("Actual feedback: '{0}'", feedback));
			
			Ranorex.Report.Screenshot(TerritoryTransferrepo.Control_Request_List.Self);
			if (feedback.Contains(expectedFeedback))
			{
				Ranorex.Report.Success(string.Format("Feedback includes '{0}'", expectedFeedback));
			}
			else
			{
				Ranorex.Report.Error(string.Format("Feedback does not include '{0}' as expected", expectedFeedback));
			}
		}
		
		/// <summary>
		/// Validates entry in CRL form
		/// </summary>
		/// <param name="controlPoint">Input:controlPoint</param>
		/// <param name="switchPosition">Input:switchPosition</param>
		/// <param name="validateRecordExists">Input:validateRecordExists</param>
		[UserCodeMethod]
		public static void NS_ValidateEntry_ControlRequestList(string controlPoint, string switchPosition, bool validateRecordExists = true)
		{
			NS_TerritoryTransfer.NS_OpenControlRequestList();
			
			int rowCount = TerritoryTransferrepo.Control_Request_List.ControlRequestTable.Self.Rows.Count - 1;
			
			bool recordFound = false;
			string controlPointOutput;
			string switchPositionOutput;
			for (int i = 0; i < rowCount; i++)
			{
				TerritoryTransferrepo.ControlRequestRowIndex = i.ToString();
				controlPointOutput = TerritoryTransferrepo.Control_Request_List.ControlRequestTable.ControlRequestByRowIndex.ControlPoint.GetAttributeValue<string>("Text");
				switchPositionOutput = TerritoryTransferrepo.Control_Request_List.ControlRequestTable.ControlRequestByRowIndex.RequestedFunction.GetAttributeValue<string>("Text");
				
				
				if (string.IsNullOrEmpty(controlPointOutput) || string.IsNullOrEmpty(switchPositionOutput))
				{
				continue;
				}
				
				if (controlPointOutput.Equals(controlPoint) && switchPositionOutput.Equals(switchPosition))
				{
					recordFound = true;
				}
			}
			
			Ranorex.Report.Screenshot(TerritoryTransferrepo.Control_Request_List.Self);
			
			string foundFeedback = string.Format("Record exists for control point '{0}' and requested function '{1}' in Control Request List.", controlPoint, switchPosition);
			string notFoundFeedback = string.Format("No records exist for control point '{0}' and requested function '{1}' in Control Request List.", controlPoint, switchPosition);
			GeneralUtilities.ReportValidationOutcome(validateRecordExists, recordFound, foundFeedback, notFoundFeedback);
		}

		/// <summary>
		/// Validate that zero records exist in CRL form
		/// </summary>
		/// <param name="validateIsClear">Input:validateIsClear</param>
		[UserCodeMethod]
		public static void NS_ValidateIsClear_ControlRequestList(bool validateIsClear = true)
		{
			NS_TerritoryTransfer.NS_OpenControlRequestList();

			int rowCount = TerritoryTransferrepo.Control_Request_List.ControlRequestTable.Self.Rows.Count;
			bool recordFound = false;
			string controlPointName;
			for (int i = 0; i < rowCount; i++)
			{
				TerritoryTransferrepo.ControlRequestRowIndex = i.ToString();

				// There are several empty records in this table. Therefore, this checks whether or not there is a valid control point listed, which indicates an existing record. 
				controlPointName = TerritoryTransferrepo.Control_Request_List.ControlRequestTable.ControlRequestByRowIndex.ControlPoint.GetAttributeValue<string>("Text");

				if (string.IsNullOrEmpty(controlPointName))
				{
					continue;
				} else {
					recordFound = true;
				}
			}

			Ranorex.Report.Screenshot(TerritoryTransferrepo.Control_Request_List.Self);

			if (validateIsClear != recordFound)
			{
				Report.Success(string.Format("Control Request List clear status is '{0}', while '{1}' was expected", validateIsClear.ToString(), validateIsClear.ToString()));
			} else {
				Report.Failure(string.Format("Control Request List clear status is '{0}', while '{1}' was expected", (!validateIsClear).ToString(), validateIsClear.ToString()));
			}
		}
		
		/// <summary>
		/// Validates whether the Territory Transfer Option is Disabled
		/// </summary>
		/// <param name="expTobeEnabled"></param>
		[UserCodeMethod]
		public static void NS_ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu(bool enabled)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo,
			                                                                  MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo);
			
			bool actualTerritoryTransferOptionState = MainMenurepo.PDS_Main_Menu.FileMenu.TerritoryTransfer.Enabled;
			
			if(actualTerritoryTransferOptionState == enabled)
			{
				Ranorex.Report.Success("Expected Territory Transfer Option  Disabled as {"+enabled+"} and found {"+actualTerritoryTransferOptionState+"}");
			}
			else
			{
				Ranorex.Report.Screenshot(MainMenurepo.PDS_Main_Menu.FileMenu.Self);
				//closing file menu
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo,
				                                                                      MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo);
				Ranorex.Report.Failure("Expected Territory Transfer Option  Disabled as {"+enabled+"} and found {"+actualTerritoryTransferOptionState+"}");
			}
			
			//closing file menu
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.FileButtonInfo,
			                                                                      MainMenurepo.PDS_Main_Menu.FileMenu.SelfInfo);
		}
		/// <summary>
		/// Validate Territory tranferred content from Dispatcher report form.
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="division">Input:division</param>
		/// <param name="dispatchTerritory">Input:dispatchTerritory</param>
		/// <param name="expectedTask">Input:expectedTask</param>
		/// <param name="closeForm">Input:closeForm</param>
		
		[UserCodeMethod]
		public static void NS_ValidateTerritoryTransferredContentFromDispatcherTranferReportForm(string optDivision, string optLogicalPosition, string division, string dispatchTerritory, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			int actRowCount = 0;
			bool taskFound = false;
			string divisionText = "";
			string dispatchTerritoryText = "";
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			if(!TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TerritoryTransferredTabInfo,
				                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.SelfInfo);
			}		
			Report.Info(String.Format("Validating Territory Transferred table with status division: {0} and dispatchTerritory: {1}", division, dispatchTerritory));
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Territory transferred table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				for(int i = 0; i < rowCount; i++)
				{
					TerritoryTransferrepo.TerritoryTransferredRowIndex = i.ToString();
					divisionText = TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.TerritoryTransferredByRowIndex.Division.Text.ToLower();
					dispatchTerritoryText = TerritoryTransferrepo.Dispatcher_Transfer_Report.TerritoryTransferredTable.TerritoryTransferredByRowIndex.DispatchTerritory.Text.ToLower();
					if (divisionText.Contains(division.ToLower()) && dispatchTerritoryText.Contains(dispatchTerritory.ToLower()))
					{
						taskFound = true;
						actRowCount++;
						break;
					}
					
				}
				if(expectedTask == taskFound)
				{
					Ranorex.Report.Success(String.Format("Territory Transferred table"+ (!taskFound ? "not " : "") +"found {0} row in the TerritotyTransferred content with division: {1} and dispatchTerritory: {2}",actRowCount, divisionText, dispatchTerritoryText));
				} else {
					Ranorex.Report.Failure(String.Format("Territory Transferred table"+ (!taskFound ? "not " : "") +"found {0} row in the TerritotyTransferred with division: {1} and dispatchTerritory: {2} ",actRowCount, divisionText, dispatchTerritoryText));
				}
			}
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		/// Validate Dispacher Message content from Dispatcher report form.
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="division">Input:division</param>
		/// <param name="dispatchTerritory">Input:dispatchTerritory</param>
		///<param name="dispatcherMessageContent">Input:dispatcherMessageContent</param>
		/// <param name="expectedTask">Input:expectedTask</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateDispatcherMessageContentFromDispatcherTranferreportForm(string optDivision, string optLogicalPosition, string division, string dispatchTerritory,string dispatcherMessageContent, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			int actRowCount = 0;
			string divisionText = "";
			string dispatchTerritoryText = "";
			string disptcherMessageText = "";
			bool taskFound = false;
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");	
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.DispatcherMessagesTabInfo,
				                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.SelfInfo);
			Report.Info(String.Format("Validating Dispatcher Message content with status division: {0} and dispatchTerritory: {1}", division, dispatchTerritory));
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.Self.Rows.Count;
			while(rowCount == 0 && retries <5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Dispatcher Message table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				for(int i = 0; i < rowCount; i++)
				{
					TerritoryTransferrepo.DispatcherMessagesRowIndex = i.ToString();
					divisionText  = TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.DispatcherMessagesByRowIndex.Division.Text.ToLower();
					dispatchTerritoryText  =  TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.DispatcherMessagesByRowIndex.DispatchTerritory.Text.ToLower();
					disptcherMessageText = TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherMessagesTable.DispatcherMessagesByRowIndex.DispatcherMessage.GetAttributeValue<string>("Value").ToLower();
					if (divisionText.Contains(division.ToLower()) && dispatchTerritoryText.Contains(dispatchTerritory.ToLower()) && disptcherMessageText.Contains(dispatcherMessageContent.ToLower()))
					{
						taskFound = true;
						actRowCount++;
						break;
					}
					
				}
				if(expectedTask == taskFound)
				{
					Ranorex.Report.Success(String.Format("Dispatcher Message table"+ (!taskFound ? "not " : "") +"found {0} row in the Dispatcher Message with division: {1} and dispatchTerritory: {2} and dispatcherMessageContent: {3}",actRowCount, divisionText, dispatchTerritoryText, disptcherMessageText));
				} else {
					Ranorex.Report.Failure(String.Format("Dispatcher Message table"+ (!taskFound ? "not " : "") +"found {0} row in the Dispatcher Message with division: {1} and dispatchTerritory: {2}  and dispatcherMessageContent: {3}",actRowCount, divisionText, dispatchTerritoryText, disptcherMessageText));
				}
			}
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		/// Validate Tasklist content from Dispatcher report form. 
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="expectedTask">Input:expectedTask</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateTaskListContentFromDispatcherTranferReportForm(string optDivision, string optLogicalPosition, string trainSeed, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			bool taskFound = false;
			string taskDescription = "";
			string taskTrainId = "";
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string description = "Create train clearance for "+trainId+"".ToLower();
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TaskListTabInfo,
				                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.TaskListTable.SelfInfo);
			Report.Info(String.Format("Validating TaskList with description : {0} and employeeId {1}", description, trainId));
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TaskListTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TaskListTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Task list table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				for(int i = 0; i < rowCount; i++)
				{
					TerritoryTransferrepo.TaskListRowIndex = i.ToString();
					taskDescription = TerritoryTransferrepo.Dispatcher_Transfer_Report.TaskListTable.TaskListByRowIndex.TaskDescription.Text.ToLower();
					taskTrainId =  TerritoryTransferrepo.Dispatcher_Transfer_Report.TaskListTable.TaskListByRowIndex.TrainIdEmployeeName.Text.ToLower();
					if (taskDescription.Contains(description.ToLower()) && taskTrainId.Contains(trainId.ToLower()))
					{
						taskFound = true;
						break;
					}
					
				}
				if(expectedTask == taskFound)
				{
					Ranorex.Report.Success(String.Format("Tasklist table"+ (!taskFound ? "not " : "") + "found in the tasklist content with description: {0} and employeeId: {1}" ,description, trainId));
				} else {
					Ranorex.Report.Failure(String.Format("Tasklist table" + (!taskFound ? "not " : "") + "found in the tasklist with division: {0} and employeeId: {1}",description, trainId));
				}
			}
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		/// Validate Trains Needing Bulletins content from Dispatcher report form. 
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateTrainsNeedingBulletinsFromDispatcherTranferreportForm(string optDivision, string optLogicalPosition, bool closeForm)
		{
			int retries = 0;
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TrainsNeedingBulletinsTabInfo,
			                                         TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainsNeedingBulletinsTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainsNeedingBulletinsTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainsNeedingBulletinsTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Trains Needing Bulletins table");
				
			}
			else
			{
				Ranorex.Report.Failure("rows{"+rowCount+"} found in Trains Needing Bulletins table");
				
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		/// Validate Train Satus content from Dispatcher report form. 
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateTrainSatusFromDispatcherTranferreportForm(string optDivision, string optLogicalPosition, int expectedRowCount, bool closeForm)
		{
			int retries = 0;
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TrainStatusTabInfo,
			                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainStatusTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainStatusTable.Self.Rows.Count-1;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrainStatusTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Train Satus table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
			return;
				
			}
			else
			{
				if(rowCount == expectedRowCount)
				{
					Ranorex.Report.Success("Found actual row count: "+rowCount+"and expected row count: "+expectedRowCount+"in train status table");
				}
				else{
					Ranorex.Report.Screenshot(TerritoryTransferrepo.Dispatcher_Transfer_Report.Self);
					Ranorex.Report.Failure("Not found actual row count: "+rowCount+"and expected row count: "+expectedRowCount+"in train status table");
				}
				
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		///  Validate Track Authorities content from Dispatcher report form already open.
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="authoritySeed">Input:authoritySeed</param>
		/// <param name="firstPoint">Input:firstPoint</param>
		/// <param name="secondPoint">Input:secondPoint</param>
		/// <param name="track">Input:track</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateTrackAuthoritiesFromDispatcherTranferReportForm(string optDivision, string optLogicalPosition, string authoritySeed, string firstPoint,string secondPoint,string track, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			int actRowCount = 0;
			bool taskFound = false;
			string actFirstPoint = "";
			string actSecondPoint = "";
			string actTrack = "";
			string actAuthorityNumber = "";
			string expAuthorityNumber = NS_Authorities.GetAuthorityNumber(authoritySeed);
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TrackAuthoritiesTabInfo,
			                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.Self.Rows.Count;
				retries++;
			}
			rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.Self.Rows.Count;
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Track Authorities table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				
				for(int i = 0 ; i < rowCount ; i++)
				{
					TerritoryTransferrepo.TrackAuthoritiesRowIndex = i.ToString();
					actFirstPoint = 	TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.TrackAuthoritiesByRowIndex.FirstPoint.Text.ToLower();
					actSecondPoint = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.TrackAuthoritiesByRowIndex.SecondPoint.Text.ToLower();
					actTrack = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.TrackAuthoritiesByRowIndex.Track.Text.ToLower();
					actAuthorityNumber = TerritoryTransferrepo.Dispatcher_Transfer_Report.TrackAuthoritiesTable.TrackAuthoritiesByRowIndex.Number.Text.ToLower();
					actRowCount++;
					if(actAuthorityNumber.Contains(expAuthorityNumber) && actFirstPoint.Contains(firstPoint.ToLower()) && actSecondPoint.Contains(secondPoint.ToLower()) && actTrack.Contains(track.ToLower()))
					{
						taskFound = true;
						break;
					}
				}
			}
			if(expectedTask == taskFound)
			{
				Ranorex.Report.Success(String.Format("Track Authorities table found {0} row in the Track Authorities with AuthorityNumber: {1} and firstpoint: {2} and secondpoint: {3} and Track: {4}",actRowCount, actAuthorityNumber, actFirstPoint, actSecondPoint, actTrack));
				
			}
			else {
				Ranorex.Report.Failure(String.Format("Track Authorities table not found {0} row in the Track Authorities with AuthorityNumber: {1} and firstpoint: {2} and secondpoint: {3} and Track: {4}",actRowCount, actAuthorityNumber, actFirstPoint, actSecondPoint, actTrack));
			}
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}

		/// <summary>
		/// Validate Tags content from Dispatcher report form.
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="tagName">Input:tagName</param>
		/// <param name="tagType">Input:tagType</param>
		/// <param name="opstaBetween">Input:opstaBetween</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateTagsFromDispatcherTranferreportForm(string optDivision, string optLogicalPosition, string tagName, string tagType, string opstaBetween, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			int actRowCount = 0;
			bool taskFound = false;
			string actTagName = "";
			string actTagType = "";
			string actOpsta = "";
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.TagsTabInfo,
			                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.Self.Rows.Count;
			retries = 0;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Tags table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				for(int i = 0 ; i < rowCount ; i++)
				{
					TerritoryTransferrepo.TagsRowIndex = i.ToString();
					actTagName = TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.TagsByRowIndex.TagName.Text.ToLower();
					actTagType = TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.TagsByRowIndex.Type.Text.ToLower();
					actOpsta = TerritoryTransferrepo.Dispatcher_Transfer_Report.TagsTable.TagsByRowIndex.BetweenAt.Text.ToLower();
					actRowCount++;
					if(actTagName.Contains(tagName.ToLower()) && actTagType.Contains(tagType.ToLower()) && actOpsta.Contains(opstaBetween.ToLower()))
					{
						taskFound = true;
						break;
					}
					
				}
			}
			if(expectedTask == taskFound)
			{
				Ranorex.Report.Success(String.Format("Success:Tags Table found {0} row in the tags with TagName: {1} and TagType: {2} and Between: {3}", actRowCount, actTagName, actTagType, actOpsta));
			}
			else {
				Ranorex.Report.Failure(String.Format("Tags Table Not found {0} row in the tags with TagName: {1} and TagType: {2} and Between: {3}", actRowCount, actTagName, actTagType, actOpsta));
			}
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		///  Validate Bulletins content from Dispatcher report form.
		/// </summary>
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// <param name="bulletinSeed">Input:bulletinSeed</param>
		/// <param name="bulletinType">Input:bulletinType</param>
		/// <param name="firstLimit">Input:firstLimit</param>
		/// <param name="secondLimit">Input:secondLimit</param>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateBulletinsFromDispatcherTranferReportForm(string optDivision, string optLogicalPosition, string bulletinSeed, string bulletinType, string firstLimit, string secondLimit, bool expectedTask, bool closeForm)
		{
			int retries = 0;
			int actRowCount = 0;
			string actBulletinNumber = "";
			string actBulletinType = "";
			string actFirstLimit = "";
			string actSecondLimit = "";
			bool taskFound = false;
			string expBulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.BulletinsTabInfo,
			                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Bulletins table");
				if(closeForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
					                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
				}
				return;
			}
			else
			{
				for(int i = 0 ; i < rowCount ; i++)
				{
					TerritoryTransferrepo.BulletinsRowIndex = i.ToString();
					actBulletinNumber = TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.BulletinsByRowIndex.BulletinNumber.Text.ToLower();
					actBulletinType = TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.BulletinsByRowIndex.BulletinType.Text.ToLower();
					actFirstLimit = 	TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.BulletinsByRowIndex.FirstLimit.Text.ToLower();
					actSecondLimit = TerritoryTransferrepo.Dispatcher_Transfer_Report.BulletinsTable.BulletinsByRowIndex.SecondLimit.Text.ToLower();
					actRowCount++;
					if(actBulletinType.Contains(bulletinType.ToLower()) && actFirstLimit.Contains(firstLimit.ToLower()) && actSecondLimit.Contains(secondLimit.ToLower()))
					{
						taskFound = true;
						break;
						
					}
				}
			}
			if(expectedTask == taskFound)
			{
				Ranorex.Report.Success(String.Format( "Bulletins Table found {0} row in the Bulletins with BulletinNumber:{1} and BulletinType: {2} and FirstLimit: {3} and SecondLimit: {4}", actRowCount, actBulletinNumber, actBulletinType, actFirstLimit, actSecondLimit));
			}
			else {
				Ranorex.Report.Failure(String.Format( "Bulletins Table Not found {0} row in the Bulletins with BulletinNumber:{1} and BulletinType: {2} and FirstLimit: {3} and SecondLimit: {4}", actRowCount, actBulletinNumber, actBulletinType, actFirstLimit, actSecondLimit));
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
			return;
		}
		
		/// <summary>
		/// Validate Bulletins content from Dispatcher report form.
		/// <param name="optDivision">Input:optDivision</param>
		/// <param name="optLogicalPosition">Input:optLogicalPosition</param>
		/// </summary>
		/// <param name="closeForm">Input:closeForm</param>
		[UserCodeMethod]
		public static void NS_ValidateHelperOpsFromDispatcherTranferreportForm(string optDivision, string optLogicalPosition, bool closeForm)
		{
			int retries = 0;
			NS_Miscellaneous.NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(optDivision, optLogicalPosition, "");
			GeneralUtilities.ClickAndWaitForWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.DispatcherTransferTabs.HelperOpsTabInfo,
			                                          TerritoryTransferrepo.Dispatcher_Transfer_Report.HelperOpsTable.SelfInfo);
			int rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.HelperOpsTable.Self.Rows.Count;
			while(rowCount == 0 && retries < 5)
			{
				Delay.Milliseconds(500);
				rowCount = TerritoryTransferrepo.Dispatcher_Transfer_Report.HelperOpsTable.Self.Rows.Count;
				retries++;
			}
			if(rowCount == 0)
			{
				Ranorex.Report.Success("No rows found in Helper Ops table");
			}
			else
			{
				Ranorex.Report.Failure("rows{"+rowCount+"} found in Helper Ops table");
				
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TerritoryTransferrepo.Dispatcher_Transfer_Report.CloseButtonInfo,
				                                                  TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo);
			}
		}
	}
}


    

