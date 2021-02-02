/*
 * Created by Ranorex
 * User: 503052222
 * Date: 1/24/2019
 * Time: 11:56 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Env.Code_Utils;
using PDS_CORE.Code_Utils;
using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_DRA
    {
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.SystemConfiguration_Repo Systemconfigrepo = global::PDS_NS.SystemConfiguration_Repo.Instance;
    	public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
		
		/// <summary>
		/// Opens De Minimis Configaration Information Table if not already open
		/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenDRAConfigTable_MainMenu()
    	{
    		int retries = 0;
 
    		//Open De Minimis Configaration Information Table if it's not already open
    		if (!Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.SelfInfo.Exists(0))
    		{
    			//Click Track System Configuration menu
    			MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
    			//Click De Minimis in System Configuration menu
    			MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.DeMinimisRoutingAreas.Click();
    			Report.Info("De Minimis Configaration Information Table open");
    			//Wait for De Minimis Configaration Information Table to exist in case of lag
    			if (!Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.SelfInfo.Exists(0))
    			{
    				Ranorex.Delay.Milliseconds(500);
    				while (!Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.SelfInfo.Exists(0) && retries < 2) 
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}
    				
    				if (!Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.SelfInfo.Exists(0))
    				{
    					Report.Failure("De Minimis Configaration Information Table did not open");
    					return;
    				}
    			}
    			
    			retries = 0;
    			
    		}
    		
    		return;
    	}
    	
		/// <summary>
		/// Verify De Minimis Configuration table display.
		/// </summary>
		[UserCodeMethod]
		public static void NS_ValidateDRAconfigUIdisplay()
		{
			//Checking after click on Cancel button window get colse or not
			NS_OpenDRAConfigTable_MainMenu();
			if (Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo.Exists(0))
			{
				Systemconfigrepo.De_Minimis_Routing_Areas.CancelButton.Click();
				if(!Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo.Exists(0)){
					Report.Success("De Minimis Routing areas page closed");
				}else{
					Report.Failure("De Minimis Routing areas page not closed");
				}
				
			}
			
			NS_OpenDRAConfigTable_MainMenu();
			
			//Checking after click on File->Close button window get colse or not
			if (Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForWithRetry(Systemconfigrepo.De_Minimis_Routing_Areas.MainMenuBar.FileInfo, Systemconfigrepo.De_Minimis_Routing_Areas.FileMenu.CloseInfo);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Systemconfigrepo.De_Minimis_Routing_Areas.FileMenu.CloseInfo, Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo);
				
				if(!Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo.Exists(0)){
					Report.Success("De Minimis Routing areas page closed");
				}else{
					Report.Failure("De Minimis Routing areas page not closed");
				}
			
			}
		}
    	
		
		/// <summary>
		/// Verify De Minimis Configuration table displayed in alphabetical order based on column Routing Area Name
		/// </summary>
		[UserCodeMethod]
		public static void NS_ValidateDRAConfigTableAlphabeticalOrder()
		{
			
			bool alphabetical = false;
			HashSet<string> dbConfigList = Oracle.Code_Utils.CDMSEnvironment.GetDRAConfig();
			int dbListCount = dbConfigList.Count();
			int dra_configRowsCount = Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.Self.Rows.Count;
			string routing_AreaName = ""; 
			
			int i = 0;
			
			if(dbListCount.Equals(dra_configRowsCount)){
				foreach(string draName in dbConfigList){
					Systemconfigrepo.DeMinimusConfigurationIndex = i.ToString();
					routing_AreaName = Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.DeMinimisConfigInfoRowByIndex.RoutingAreaName.GetAttributeValue<string>("Text");
					
					if(routing_AreaName.Equals(draName)){
						alphabetical = true;
					   }else{
					   	alphabetical = false;
					   	break;
					   }
					
					i = i+1;					
				}
				
				if(!alphabetical){
					Report.Failure("De Minimis configaration information table order is not alphabetical");
				}else{
					Report.Success("List is displayed in alphabetical order based on column routing area name");
				}
			}
			
			if (Systemconfigrepo.De_Minimis_Routing_Areas.SelfInfo.Exists(0))
			{
				Systemconfigrepo.De_Minimis_Routing_Areas.WindowControls.Close.Click();
			}
		
		}
    	
    	
		/// <summary>
		/// Insert new row in CDMS.CFG_DRA_CONFIG table then validated row get inserted and showing alphabetical order in De Minimis Configuration table.
		/// </summary>
		/// <param name="routing_area_name">Input:routing area for DRA area name</param>
		/// <param name="from_opsta">Input: from_opsta for FROM OPSTA value to insert into DB</param>
		/// <param name="to_opsta">Input: to_opsta for FROM OPSTA value to insert into DB</param>
		[UserCodeMethod]
		public static void NS_InsertRowAndValidateDRAConfigTable( string routing_area_name, string from_opsta, string to_opsta, string from_limit_name, string to_limit_name, string from_mp, string to_mp, string fromTerritoryId, string toTerritoryId, string active)
		{
			NS_OpenDRAConfigTable_MainMenu();	
			NS_ValidateDRAConfigTableAlphabeticalOrder();
			bool inserted = Oracle.Code_Utils.CDMSEnvironment.insertDRAConfig(routing_area_name, from_opsta, to_opsta, from_limit_name, to_limit_name, from_mp, to_mp, fromTerritoryId, toTerritoryId, active);
			
			NS_OpenDRAConfigTable_MainMenu();
			
			if(inserted){
				var draConfigTable = Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.Self;
				bool found = false;
				foreach(Row row in draConfigTable.Rows)
				{
					if (row.Cells[0].Text.Equals(routing_area_name))
					{
						Report.Info(String.Format("Found De Minimis configaration information in config table with Routing Area Name: {0}, From Opsta: {1}, From MP: {2}, From Limit Name: {3}, To Opsta: {4}," +
												"To MP: {5}, To Limit Name: {6}", row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text, row.Cells[5].Text, row.Cells[6].Text));
					  
						Report.Success("Verified inserted row is present in DRA config table");
						found = true;
						break;
					}  	
				}
				
				if (!found)
				{
					Report.Failure("De Minimis configaration information not found in config table");
				}
			  
			}
			
			NS_ValidateDRAConfigTableAlphabeticalOrder();
		}
    	
    	
    	
		/// <summary>
		/// Delete row from CDMS.CFG_DRA_CONFIG table then validated row get deleted and not showing in De Minimis Configuration table and validate alphabetical order.
		/// </summary>
		/// <param name="routing_area_name">Input:routing area for DRA area name</param>
		[UserCodeMethod]
		public static void NS_DeleteRowAndValidateDeletedRowNotPresent( string routing_area_name)
		{
			
			bool deleted = Oracle.Code_Utils.CDMSEnvironment.deleteDRAConfig(routing_area_name);
			NS_OpenDRAConfigTable_MainMenu();
			
			if(deleted){
				var draConfigTable = Systemconfigrepo.De_Minimis_Routing_Areas.DeMinimisConfigurationTable.Self;
				bool present = true;
				
				foreach(Row row in draConfigTable.Rows)
				{
					if (!row.Cells[0].Text.Equals(routing_area_name))
					{
					   Report.Success("Verified deleted row is not present in DRA config table");
					   present = false;
					   break;
					}    	            	       
				}
				
				if (present)
				{
					Report.Failure("Configaration information row not deleted sill present in DRA config table");
				}
				
				NS_ValidateDRAConfigTableAlphabeticalOrder();
			}

		}
		
		/// <summary>
		/// Opens up DRA Train Count Summary window from Trains Menu
		/// </summary>
		public static void NS_OpenDRATrainCountSummaryWindow()
		{
			
			if(!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0)) 
			{
			
				GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
			
				MainMenurepo.PDS_Main_Menu.TrainsMenu.DeminimisRoutingTrainCountSummary.Click();
				
				int retries = 0;
				while (!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0) && retries < 3) 
				{
					Ranorex.Delay.Milliseconds(500);
					retries++;
				}
				
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0)) 
				{
					Ranorex.Report.Success("Successfully Opened DRA Train Count Summary Window");
				} else 
				{
					Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Window");
				}
			
			} else if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0)) 
			{
				Ranorex.Report.Success("DRA Train Count Summary Window Already Open");
			} else 
			{
				Ranorex.Report.Failure("Unable to find DRA Train Count Summary Window");
			}
			
		}
		
		/// <summary>
		/// Validates if the train is present in DRA Train Count summary Projected table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Area name</param>
		/// <param name="validateTrainPresent">If true then validates if the train is present in Entered table or if false then validates if train is not present</param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ValidateTrainInProjectedTable(string trainSeed, string draName, bool validateTrainPresent, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			bool trainFound = false;
			int retries = 0;
			Trainsrepo.DRAProjectedTableName = draName;
			
			NS_OpenDRATrainCountSummaryWindow();
			
			if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.SelfInfo.Exists(0))
				{
					//Get the projected table row count
					int projectedRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.Self.Rows.Count;
					
					Ranorex.Report.Info("Count of entries present in Projected Table is " + projectedRowCount.ToString());
					
					while(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.SelfInfo.Exists(0) && !trainFound && retries < 45)
					{
						projectedRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.Self.Rows.Count;
						Ranorex.Report.Info("Count of entries present in Projected Table is " + projectedRowCount.ToString());

						if(projectedRowCount >= 1)
						{
							//Iterate over each row and validate if the train is found
							for(int i = 0; i < projectedRowCount ; i++)
							{
								Trainsrepo.ProjectedIndex = i.ToString();
								train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.TrainId.GetAttributeValue<string>("Text");
								
								if(full_train_id == train_id_table)
								{
									trainFound = true;
									break;
								}
							}
							
							if(closeForms)
							{
								Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
							}
							
						}
						Ranorex.Delay.Seconds(1);
						retries++;
					}

				} 
				else
				{
					if(closeForms)
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				}
				
				//Validate if the user wants train to be present and if train found then throw success message
				if(validateTrainPresent && trainFound)
				{
					
					Ranorex.Report.Success("Train present in Projected Table with Train id: " +full_train_id);
					
				}
				//Validate if the user does not want train to be present and if train not found then throw success message
				else if(!validateTrainPresent && !trainFound)
				{
					Ranorex.Report.Success("Train not present in Projected Table with Train id: " +full_train_id);
					
				}
				//Else throw failure message
				else
				{
					Ranorex.Report.Failure("Train not present in Projected Table with Train Id: " +full_train_id);
					
				}

				
			} else
			{
				Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Window");
			}
		}

		
		
		/// <summary>
		/// Validate the information of train in Projected table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Name in which to find the train</param>
		/// <param name="divisionName">Division Name in which DRA & Train is present</param>
		/// <param name="validateTrainPresent">TRUE if Train Is present, Else False is train is not present</param>
		/// <param name="closeForms">TRUE to close the DRA Train Count Summary Form</param>
		[UserCodeMethod]
		public static void NS_ValidateInformationInProjectedTable(string trainSeed, string draName, string divisionName, bool validateTrainPresent, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			bool trainFound = false;
			int retry = 0;
			int iterations = 0;
			Trainsrepo.DRAProjectedTableName = draName;
			
			while(!trainFound && retry < 3)
			{
				
				if(!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					NS_OpenDRATrainCountSummaryWindow();
				}
				
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					
					if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.SelfInfo.Exists(0))
					{
						//Get the projected table row count
						int projectedRowCount = 0;
						
						while(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.SelfInfo.Exists(0) && !trainFound && iterations < 11)
						{
						
							projectedRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.Self.Rows.Count;
							Ranorex.Report.Info("Count of entries present in Projected Table is " + projectedRowCount.ToString());
						
							if(projectedRowCount >= 1)
							{
								//Iterate over each row and validate if the train is found
								for(int i = 0; i < projectedRowCount ; i++)
								{
									Trainsrepo.ProjectedIndex = i.ToString();
									train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.TrainId.GetAttributeValue<string>("Text");
									
									if(full_train_id == train_id_table)
									{
										//Validate the DRA Name in the Routing Area field
										if(!(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.RoutingArea.GetAttributeValue<string>("Text") == draName))
										{
											Report.Failure("DRA Name does not match");
											return;
										}
										
										//Validate the Division
										if(!(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.DivisionName.GetAttributeValue<string>("Text") == divisionName))
										{
											Report.Failure("DRA Division does not match");
											return;
										}
										
										
										trainFound = true;
										break;
									}
								}
								
							}
							
							if(!trainFound){
								retry++;
								iterations++;
								Ranorex.Delay.Seconds(5);
							}
							
						}

					}
				}
			}

			//Validate if the user wants train to be present and if train found then throw success message
			if(validateTrainPresent && trainFound)
			{
				
				Ranorex.Report.Success("Train present in Projected Table with correct details having Train id: " +full_train_id);
				
			}
			//Validate if the user does not want train to be present and if train not found then throw success message
			else if(!validateTrainPresent && !trainFound)
			{
				Ranorex.Report.Success("Train not present in Projected Table with Train id: " +full_train_id);
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
			}
			//Else throw failure message
			else if (validateTrainPresent && !trainFound)
			{
				Ranorex.Report.Failure("Train not present in Projected Table with Train Id: " +full_train_id);
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
			}
			else
			{
				Ranorex.Report.Failure("Train should not have been present in the table yet is found");
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
			}
		}

		/// <summary>
		/// This user code validates if the train is present in DRA Train Count Summary Entered table or not
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName"> dra name in which user needs to validate the train is present</param>
		/// <param name="validateTrainPresent">If true then it will check if the train  is present, if false then it will check if train not present</param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ValidateTrainInEnteredTable(string trainSeed, string draName, bool validateTrainPresent, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			bool trainFound = false;
			int retries = 0;
			Trainsrepo.DRAEnteredTableName = draName;
			
			NS_OpenDRATrainCountSummaryWindow();
			
			if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.SelfInfo.Exists(0))
				{
					//Getting Entered table counts
					int enteredRowCount = 0;
					
					while(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.SelfInfo.Exists(0) && !trainFound && retries < 45)
					{
						enteredRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.Self.Rows.Count;
						Ranorex.Report.Info("Count of entries present in Entered Table is " + enteredRowCount.ToString());
					
						if(enteredRowCount >= 1)
						{
							//Validating if the train is present in the Entered table by  iterating through each row and break out of the loop when the train is found
							for(int i = 0; i < enteredRowCount ; i++)
							{
								
								Trainsrepo.EnteredIndex = i.ToString();
								train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.DRATrainEnteredCountTableByRow.TrainId.GetAttributeValue<string>("Text");
								
								if(full_train_id == train_id_table)
								{
									trainFound = true;
									break;
								}
								
							}
							
						}
						
						Ranorex.Delay.Seconds(1);
						retries++;
					}
					

				} else
				{
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					Ranorex.Report.Info("Entered Table is not visible for the DRA: " + draName);
					
				}
				
				//If user wants to validate if the train is present and if train is found then throw Success message
				if(validateTrainPresent && trainFound)
				{
					Ranorex.Report.Success("Train present in Entered Table with Train id: " +full_train_id);
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				}
				
				//If the user wants to validate if the train is not present and if train is found then throw success message
				else if(!validateTrainPresent && !trainFound)
				{
					Ranorex.Report.Success("Train not present in Entered Table with Train id: " +full_train_id);
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				}
				// Else throw failure message that train is not present
				else
				{
					Ranorex.Report.Failure("Train not present in Entered Table with Train Id: " +full_train_id);
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				}
				
				
			} else
			{
				Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Window");
			}
		}


		/// <summary>
		/// Validate DRA PopUp Window Not Open
		/// </summary>
		[UserCodeMethod]
		public static bool NS_ValidateDRAPopupNotOpenFunction()
		{
			int retries = 0;
			bool popupOpen = false;
			//Wait for De Minimis PopUp Window to exist in case of lag
			

			while ((!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || !Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)) && retries < 3)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || !Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)){
				Report.Success("Validated De Minimis pop up window not open");
				popupOpen = false;
				return popupOpen;
			}
			
			if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)){
				Report.Failure("De Minimis pop up window open");
				popupOpen = true;
				return popupOpen;
				
			}
			
			return popupOpen;
		}
		
		
		/// <summary>
		/// Validate DRA PopUp Window Open
		/// </summary>
		[UserCodeMethod]
		public static bool NS_ValidateDRAPopupOpen()
		{
			int retries = 0;
			bool present = false;
			
			//Ranorex.Delay.Milliseconds(5000);
			//Wait for De Minimis PopUp Window to exist in case of lag
			while (!(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)) && retries < 5)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			if (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0)) 
			{
				present = true;
				Report.Success("De Minimis Popup is Displayed");
			} else if (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
			{
				present = true;
				Report.Success("De Minimis Popup is Displayed");
			} else
			{
				Report.Failure("De Minimis Popup is NOT Displayed");
			}

			return present;
		}
		
		
		/// <summary>
		/// Get DRA PopUp Entered Count
		/// </summary>
		public static int NS_GetDRAPopupEnteredCount()
		{
			NS_ValidateDRAPopupOpen();
			int traincount_entered_count = 0;
			string popup_entered_count_caption = null;
			
			Ranorex.Delay.Milliseconds(500);
			if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
			{
				popup_entered_count_caption = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.EnteredTrainCountText.TextValue;
				string[] arr_popup_entered_count = popup_entered_count_caption.Split(':');
				traincount_entered_count =  Convert.ToInt32(arr_popup_entered_count[1]);
				return traincount_entered_count;
				
			} else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
			{
				popup_entered_count_caption = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.EnteredTrainCountText.TextValue;
				string[] arr_popup_entered_count = popup_entered_count_caption.Split(':');
				traincount_entered_count =  Convert.ToInt32(arr_popup_entered_count[1]);
				return traincount_entered_count;
			}
			else
			{
				Report.Failure("De Minimis pop up window not open from Get Entered Count");
				return traincount_entered_count;
			}
			
		}
		
		
		/// <summary>
		/// Get DRA PopUp Projected Count
		/// </summary>
		public static int NS_GetDRAPopupProjectedCount()
		{
			
			int popup_projected_count = 0;
			string popup_projected_count_caption= null;
			
			if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
			{
				popup_projected_count_caption = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.ProjectedTrainCountText.TextValue;
				string[] arr_popup_projected_count = popup_projected_count_caption.Split(':');
				popup_projected_count =  Convert.ToInt32(arr_popup_projected_count[1]);
				return popup_projected_count;
			}
			else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)) {
				popup_projected_count_caption = Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.ProjectedTrainCountText.TextValue;
				string[] arr_popup_projected_count = popup_projected_count_caption.Split(':');
				popup_projected_count =  Convert.ToInt32(arr_popup_projected_count[1]);
				return popup_projected_count;
			}
			else
			{
				Report.Failure("De Minimis pop up window not open from Get Projected Count");
				return popup_projected_count;
			}
			
		}
		
		
		/// <summary>
		/// Get DRA Train Count Summary Entred Count by DRA area
		/// </summary>
		/// <param name="dra_area_name">Input:DRA routing area name for Entered count</param>
		public static int NS_GetDRATrainCountSummaryEnteredCount(string dra_area_name)
		{
			NS_OpenDRATrainCountSummaryWindow();
			int traincount_entered_count = 0;
			if (Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				Trainsrepo.DRAAreaName = dra_area_name+" \\(Entered\\)";
				string train_count_entered_count_caption = Trainsrepo.Deminimis_Routing_Train_Count_Summary.ProjectedEnteredCount.TextValue;
				if(train_count_entered_count_caption!=""){
					string[] arr_traincount_entered_count = train_count_entered_count_caption.Split(':');
					traincount_entered_count =  Convert.ToInt32(arr_traincount_entered_count[1]);
					return traincount_entered_count;
				}
			}else{
				Report.Failure("De Minimis Routing Train Count Summary Page not open");
				
			}
			return traincount_entered_count;
		}
		
		
		/// <summary>
		/// Get DRA Train Count Summary Projected Count by DRA area
		/// </summary>
		/// <param name="dra_area_name">Input:DRA routing area name for Projected count</param>
		public static int NS_GetDRATrainCountSummaryProjectedCount(string dra_area_name)
		{
			NS_OpenDRATrainCountSummaryWindow();
			int traincount_projected_count = 0;
			if (Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				Trainsrepo.DRAAreaName = dra_area_name+" \\(Projected\\)";
				string train_count_projected_count_caption = Trainsrepo.Deminimis_Routing_Train_Count_Summary.ProjectedEnteredCount.TextValue;
				
				if(train_count_projected_count_caption!=""){
					string[] arr_traincount_projected_count = train_count_projected_count_caption.Split(':');
					traincount_projected_count =  Convert.ToInt32(arr_traincount_projected_count[1]);
					return traincount_projected_count;
				}
			}else{
				Report.Failure("De Minimis Routing Train Count Summary Page not open");
				
			}
			return traincount_projected_count;
		}
		
		
		/// <summary>
		/// Validate DRA Projected Train Count
		/// </summary>
		/// <param name="dra_area_name">Input:DRA routing area name for Projected count</param>
		[UserCodeMethod]
		public static void NS_ValidateProjectedCount(string dra_area_name, bool closeForms)
		{
			int popupProjectedCount = NS_GetDRAPopupProjectedCount();
			int trainCountSummaryProjectedCount = NS_GetDRATrainCountSummaryProjectedCount(dra_area_name);
			if(popupProjectedCount.Equals(trainCountSummaryProjectedCount)){
				
				Report.Success("Verified Deminimis Routing Pop up and Train Count Summary Page Projected Train Count matched");
			}
			else
			{
				Report.Failure("Deminimis Routing Pop up and Train Count Summary Page Projected Train Count not matching");
			}
			
			if(closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.CloseInfo, Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo);
			}
		}
		
		
		/// <summary>
		/// Validate DRA Entered Train Count
		/// </summary>
		/// <param name="dra_area_name">Input:DRA routing area name for Entered count</param>
		[UserCodeMethod]
		public static void NS_ValidateEnteredCount(string dra_area_name, bool closeForms)
		{
			int retries = 0;
			//Wait for De Minimis PopUp Window to exist in case of lag
			while (!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) && retries < 3)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			int popupEnteredCount = NS_GetDRAPopupEnteredCount();
			int trainCountSummaryEnteredCount = NS_GetDRATrainCountSummaryEnteredCount(dra_area_name);
			if(popupEnteredCount.Equals(trainCountSummaryEnteredCount))
			{
				Report.Success("Verified Deminimis Routing Pop up and Train Count Summary Page Entered Train Count matched");
			}
			else
			{
				Report.Failure("Deminimis Routing Pop up and Train Count Summary Page Entered Train Count not matching");
			}
			
			if(closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.CloseInfo, Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo);
			}
		}
		
	
		/// <summary>
		/// Get te Entered train comments from DRA Train Count Summary
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Area Name in Train Count Summary</param>
		/// <param name="closeForms">TRUE or FALSE</param>
		/// <returns></returns>
		public static string NS_GetDRAEnteredTrainComments(string trainSeed, string draName, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			string comments = "";
			Trainsrepo.DRAEnteredTableName = draName;
			
			if(!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				NS_OpenDRATrainCountSummaryWindow();
			}
			
			if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.SelfInfo.Exists(0))
				{
					//Getting Entered table counts
					int enteredRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.Self.Rows.Count;
					
					Ranorex.Report.Info("Count of entries present in Entered Table is " + enteredRowCount.ToString());
					
					if(enteredRowCount >= 1)
					{
						//Validating if the train is present in the Entered table by  iterating through each row and break out of the loop when the train is found
						for(int i = 0; i < enteredRowCount ; i++)
						{
							Trainsrepo.EnteredIndex = i.ToString();
							train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.DRATrainEnteredCountTableByRow.TrainId.GetAttributeValue<string>("Text");
							
							if(full_train_id == train_id_table)
							{
								//If train found then retrieve the comments
								comments = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.DRATrainEnteredCountTableByRow.Comments.GetAttributeValue<string>("Text");
								break;
							}
						}
						
						if(closeForms)
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
						
						Ranorex.Report.Success("Comments for Train Id: " +train_id+ " is " +comments);
						return comments;
					}
					
					else
					{
						if(closeForms)
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
							
						Ranorex.Report.Error("DRA Entered table not found for DRA Name: " +draName);
						return "";
					}
				} 
				else
				{
					if(closeForms)
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					Ranorex.Report.Error("DRA Entered table not found for DRA Name: " +draName);
					return "";
				}
			} 
			else
			{	
				if(closeForms)
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Window");
				return "";
			}
		}


		/// <summary>
		/// Get the Train Entered Time from DRA Train Count Summary
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Area Name</param>
		/// <param name="closeForms"></param>
		/// <returns></returns>
		public static string NS_GetDRATrainEnteredTime(string trainSeed, string draName, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			string enteredTime = "";
			Trainsrepo.DRAEnteredTableName = draName;
			
			if(!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				NS_OpenDRATrainCountSummaryWindow();
			}
			
			if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.SelfInfo.Exists(0))
				{
					//Getting Entered table counts
					int enteredRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.Self.Rows.Count;
					
					Ranorex.Report.Info("Count of entries present in Entered Table is " + enteredRowCount.ToString());
					
					if(enteredRowCount >= 1)
					{
						//Validating if the train is present in the Entered table by  iterating through each row and break out of the loop when the train is found
						for(int i = 0; i < enteredRowCount ; i++)
						{
							Trainsrepo.EnteredIndex = i.ToString();
							train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.DRATrainEnteredCountTableByRow.TrainId.GetAttributeValue<string>("Text");
							
							if(full_train_id == train_id_table)
							{
								//If train found then get the Entered time for the train
								enteredTime = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainEnteredCountTable.DRATrainEnteredCountTableByRow.EnteredTime.GetAttributeValue<string>("Text");
								break;
							}
						}
						
						if(closeForms)
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
						
						Ranorex.Report.Success("Entered Time for Train Id: " +train_id+ " is " +enteredTime);
						return enteredTime;
					}
					
					else
					{
						if(closeForms)
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
							
						Ranorex.Report.Error("DRA Entered table not found for DRA Name: " +draName);
						return "";
					}
				} 
				else
				{
					if(closeForms)
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					Ranorex.Report.Error("DRA Entered table not found for DRA Name: " +draName);
					return "";
				}
			} 
			else
			{	
				if(closeForms)
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Window");
				return "";
			}
		}

		/// <summary>
		/// Get the Train Projected Time from DRA Train Count Summary
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Area Name</param>
		/// <param name="closeForms"></param>
		/// <returns></returns>
		public static string NS_GetDRATrainProjectedTime(string trainSeed, string draName, bool closeForms)
		{
			string train_id = NS_TrainID.GetTrainId(trainSeed);
			string full_train_id = "NS " + train_id;
			string train_id_table = "";
			string projectedTime = "";
			bool trainFound = false;
			int retry = 0;
			Trainsrepo.DRAProjectedTableName = draName;
			

			while(!trainFound && retry < 3)
			{
				if(!Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					NS_OpenDRATrainCountSummaryWindow();
				}
				
				
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.SelfInfo.Exists(0))
					{
						//Getting Projected table counts
						int projectedRowCount = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.Self.Rows.Count;
						
						Ranorex.Report.Info("Count of entries present in Projected Table is " + projectedRowCount.ToString());
						
						Ranorex.Report.Screenshot(ReportLevel.Info, "Projected Table", "", Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.Self, false, new RecordItemIndex(2));
						if(projectedRowCount >= 1)
						{
							//Validating if the train is present in the Projected table by  iterating through each row and break out of the loop when the train is found
							for(int i = 0; i < projectedRowCount ; i++)
							{
								Trainsrepo.ProjectedIndex = i.ToString();
								train_id_table = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.TrainId.GetAttributeValue<string>("Text");
								
								if(full_train_id == train_id_table)
								{
									//If train found then get the Projected time for the train
									projectedTime = Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRATrainProjectedCountTable.DRAProjectedCountTableByRow.ProjectedTime.GetAttributeValue<string>("Text");
									trainFound = true;
									break;
								}
							}
							
							if(closeForms)
							{
								Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
							}
							
						}
						
						
					}
					
					if(!trainFound)
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						Ranorex.Delay.Milliseconds(1000);
						retry++;
					}
					
				}
				

				
			}
			
			if(!trainFound)
			{
				Ranorex.Report.Failure("Unable to find Train in Projected Table after 3 attempts with Train Id: "+train_id);
				return "";
			} else 
			{
				Ranorex.Report.Success("Projected Time for Train Id: " +train_id+ " is " +projectedTime);
				return projectedTime;
			}
			
		}
		
		/// <summary>
		/// Validate the Comments entered are also updated in CDMS CDF_DRA_ACTION table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ValidateDRAEnteredComments(string trainSeed, string draName, bool closeForms)
		{
			
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string actionTableComments = null;
			string enteredTableComments = null;
			
			if(trainKey!= null || trainKey != "")
			{
				//Get the comments from CFG_DRA_ACTION table in CDMS
				actionTableComments = Oracle.Code_Utils.CDMSEnvironment.GetDRAActionTableComments(trainKey);
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
						
			if(actionTableComments!="" || actionTableComments!= null)
			{
				//Get the Comments for a train from DRA Entered table in DRA Train Count Summary
				enteredTableComments = NS_GetDRAEnteredTrainComments(trainSeed, draName, closeForms);
				
				if(enteredTableComments.Equals(actionTableComments))
				{
				   	Ranorex.Report.Success("Entered Comments are properly updated in DRA Action Table");
				   	
				   	if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				   	
				   	return;
				}
				else
				{
					Ranorex.Report.Failure("Entered Comments are not properly updated in DRA Action table");
					
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					return;
				}
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find Entry in DRA Action table for the Train Id: "+trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
		}
		
		
		/// <summary>
		/// Validate DRA Train Entered Date\Time Matches with Action Table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName"></param>
		/// <param name="closeForms"></param>
		/// <param name="fromOpsta"></param>
		/// <param name="toOpsta"></param>
		[UserCodeMethod]
		public static void NS_ValidateDRAEnteredTimeWithActionTable(string trainSeed, string draName, string fromOpsta, string toOpsta, bool closeForms)
		{
			
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string actionTableEnteredTime = null;
			string enteredTableEnteredTime = null;
			
			NS_OpenDRATrainCountSummaryWindow();
			
			if(trainKey!= null || trainKey != "")
			{
				//Get the Train Entered time from CFG_DRA_ACTION table in CDMS
				actionTableEnteredTime = Oracle.Code_Utils.CDMSEnvironment.GetDRAActionTableEnteredTime(trainKey, fromOpsta, toOpsta);
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
			if(actionTableEnteredTime != "" || actionTableEnteredTime != null)
			{
				System.DateTime finalDate = Convert.ToDateTime(actionTableEnteredTime);
				System.DateTime localDate = finalDate.ToLocalTime();
				
				//Get the Entered time for a train from DRA Train Count Summary Entered table
				enteredTableEnteredTime = NS_GetDRATrainEnteredTime(trainSeed, draName, closeForms);
				
				if(enteredTableEnteredTime.Contains(localDate.ToString("MM/dd/yyyy hh:mm tt")))
				{
				   	Ranorex.Report.Success("Entered Time is correctly updated in DRA Action Table");
				   	
				   	if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				   	
				   	return;
				}
				else
				{
					Ranorex.Report.Failure("Entered Time is not correctly updated in DRA Action table");
					
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					return;
				}
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find Entry in DRA Action table for the Train Id: "+trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
		}
		
		
		/// <summary>
		/// Validate if the Projected Time of Train is properly updated in CFG_DRA_ACTION table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName">DRA Area Name</param>
		/// <param name="closeForms"></param>
		/// <param name="fromOpsta"></param>
		/// <param name="toOpsta"></param>
		[UserCodeMethod]
		public static void NS_ValidateDRAProjectedTimeWithActionTable(string trainSeed, string draName, string fromOpsta, string toOpsta, bool closeForms)
		{
			
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string actionTableProjectedTime = null;
			string projectedTableProjectedTime = null;
			
			NS_OpenDRATrainCountSummaryWindow();
			
			if(trainKey!= null || trainKey != "")
			{
				//Get the Train Projected time from CFG_DRA_ACTION table in CDMS
				actionTableProjectedTime = Oracle.Code_Utils.CDMSEnvironment.GetDRAActionTableProjectedTime(trainKey, fromOpsta, toOpsta);
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
			if(actionTableProjectedTime != "" || actionTableProjectedTime != null)
			{
				System.DateTime finalDate = Convert.ToDateTime(actionTableProjectedTime);
				System.DateTime localDate = finalDate.ToLocalTime();
				
				//Get the Projected time for a train from DRA Train Count Summary Projected table
				projectedTableProjectedTime = NS_GetDRATrainProjectedTime(trainSeed, draName, closeForms);
				
				if(projectedTableProjectedTime == "No Plan Info")
				{
					if(localDate < System.DateTime.Now )
					{
						Ranorex.Report.Success("Projected Time is in past, hence showing No Plan Info");
					}
					
				} else
				{
				
					if(projectedTableProjectedTime.Contains(localDate.ToString("MM/dd/yyyy hh:mm tt")))
					{
						Ranorex.Report.Success("Projected Time is correctly updated in DRA Action Table");
						
						if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
						
						return;
					}
					else
					{
						Ranorex.Report.Failure("Projected Time is not correctly updated in DRA Action table");
						
						if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
						{
							Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
						}
						
						return;
					}
				}
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find Entry in DRA Action table for the Train Id: "+trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
		}


		/// <summary>
		/// Validate if the Train Entered Time is same in Entered table of DRA train Count summary window and in History table in ADMS
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="draName"></param>
		/// <param name="fromOpsta"></param>
		/// <param name="toOpsta"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ValidateDRAEnteredTimeWithHistoryTable(string trainSeed, string draName, string fromOpsta, string toOpsta, bool validateIfPresent, bool closeForms)
		{
			
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string historyTableEnteredTime = null;
			string enteredTableEnteredTime = null;
			
			NS_OpenDRATrainCountSummaryWindow();
			
			if(trainKey != null || trainKey != "")
			{
				//Get the Entered time from ABF_TKG_DRA_HISTORY table for a train in ADMS
				historyTableEnteredTime = Oracle.Code_Utils.ADMSEnvironment.GetDRAHistoryTableEnteredTime(trainKey, fromOpsta, toOpsta);
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
			if(historyTableEnteredTime != "" || historyTableEnteredTime != null)
			{
				System.DateTime finalDate = Convert.ToDateTime(historyTableEnteredTime);
				System.DateTime localDate = finalDate.ToLocalTime();
				
				//Get the Entered time for a train from DRA Train Count Summary Entered table
				enteredTableEnteredTime = NS_GetDRATrainEnteredTime(trainSeed, draName, closeForms);
				Ranorex.Report.Info("Entered Time from table is " + localDate.ToString("MM/dd/yyyy hh:mm"));
				
				//Validate if the Entered time is same in UI and Table
				if(enteredTableEnteredTime.Contains(localDate.ToString("MM/dd/yyyy hh:mm")))
				{
				   	Ranorex.Report.Success("Entered Time is correctly updated in DRA History Table");
				   	
				   	if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
				   	
				   	return;
				}
				else
				{
					Ranorex.Report.Failure("Entered time is not correctly updated in DRA History table");
					
					if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
					{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					}
					
					return;
				}
			} else if (historyTableEnteredTime == "" && !validateIfPresent)
			{
				Ranorex.Report.Success("No Entry present in History table for train id: "+trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			else
			{
				Ranorex.Report.Failure("Unable to find Entry in DRA History table for the Train Id: "+trainId);
				
				if(closeForms && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
				{
						Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
				}
				
				return;
			}
			
		}		
		
		/// <summary>
		/// Validate DRA Popup entry is added in ADMS table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="fromOpsta"></param>
		/// <param name="toOpsta"></param>
		/// <param name="verifyPopUpDisplayed"></param>
		[UserCodeMethod]
		public static void NS_ValidateDRAPopUPDisplayedInADMS(string trainSeed, string fromOpsta, string toOpsta, bool verifyPopUpDisplayed)
		{
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string action = null;
			
			if(trainKey!= null && trainKey != "")
			{
				//Get the Action column value from ABF_TKG_DRA_POPUP_LOG for a train
				action = Oracle.Code_Utils.ADMSEnvironment.GetDRAPopUpDisplayedLogAction(trainKey, fromOpsta, toOpsta);
			} else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				return;
			}
			
			if(verifyPopUpDisplayed)
			{
				//validate the action column value
				if(action == "POP_UP_DISPLAYED_TO_USER")
				{
					Ranorex.Report.Success("DRA Popup Displayed to User");
				} else
				{
					Ranorex.Report.Failure("DRA Popup NOT Displayed to the User");
				}
			} else 
			{
				if(action == "") 
				{
					Ranorex.Report.Success("DRA Popup not displayed to User");
				} else 
				{
					Ranorex.Report.Failure("DRA Popup Displayed to User");
				}
				
			}
			
			return;
		}
		
		
		/// <summary>
		/// Validate DRA Popup entry is added in ADMS table
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="fromOpsta">DRA Area From Opsta</param>
		/// <param name="toOpsta">DRA Area To Opsta</param>
		/// <param name="verifyPopUpAcknowledge">TRUE or FALSE to validate if Acknowledge Popup Entry is present in ADMS table</param>
		[UserCodeMethod]
		public static void NS_ValidateDRAPopUPAcknowledgedInADMS(string trainSeed, string fromOpsta, string toOpsta, bool verifyPopUpAcknowledged)
		{
			string trainId = NS_TrainID.GetTrainId(trainSeed);
			string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
			string trainOriginDate = NS_TrainID.getOriginDate(trainSeed);
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string action = null;
			
			if(trainKey!= null || trainKey != "")
			{
				//Get the Action column value from ABF_TKG_DRA_POPUP_LOG for a train
				action = Oracle.Code_Utils.ADMSEnvironment.GetDRAPopUpAcknowledgedLogAction(trainKey, fromOpsta, toOpsta);
			} else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				return;
			}
			
			if(verifyPopUpAcknowledged)
			{
				//validate the action column value
				if(action == "ACKNOWLEDGE_CLICKED")
				{
					Ranorex.Report.Success("DRA Popup Acknowledged by User");
				} else
				{
					Ranorex.Report.Failure("DRA Popup NOT Acknowledged by User for TRUE flag "+action);
				}
			} else 
			{
				if(action == "") 
				{
					Ranorex.Report.Success("DRA Popup NOT Acknowledged by User");
				} else 
				{
					Ranorex.Report.Failure("There is entry in DRA Popup log with action: "+action);
				}
				
			}
			
			return;
		}
		
		
		/// <summary>
		/// Verify if a train present in Train Status Summary and then drag and drop the train on a track section
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="trackSectionId">track section id on which train needs to be placed</param>
		[UserCodeMethod]
		public static void NS_DragAndDropFromTSS(string trainSeed, string trackSectionId, bool closeTrainStatusSummaryForm)
		{
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			int retries = 0;
			bool dragged = false;
			
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
    		Tracklinerepo.TrackSectionId = trackSectionId ;

			Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.Self.EnsureVisible();

    		//Retry 3 times if the Train is not dragged
    		while(!dragged && retries < 3)
    		{
    			if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Failure("Row with Train Id {"+trainId+"} Not found in Train Status Summary");
    				
    				if (closeTrainStatusSummaryForm)
    				{
    					NS_Trainsheet.NS_CloseTrainStatusSummary();
    				}
    				return;
    			} else
    			{
    				dragAndDrop(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID, Tracklinerepo.Trackline_Form.TrackSectionObject);
    				dragged = true;
    			}
    		}
			
			
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		return;
			
		}
		
		/// <summary>
		/// Verify if a train present in Train Status Summary and then drag and drop the train on a track section
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="trackSectionId">track section id on which train needs to be placed</param>
		[UserCodeMethod]
		public static void NS_DragAndDropFromTSSToTrainOnTrack(string trainSeed1, string trainSeed2, bool closeTrainStatusSummaryForm)
		{
			string trainId1 = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed1);
			string trainId2 = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed2);
			int retries = 0;
			bool dragged = false;
			
    		if (trainId1 == null)
    		{
    			//Assume the trainSeed is supposed to be the trainId since the trainSeed wasn't found for a train that apparently exists
    			trainId1 = trainSeed1;
    		}
    		if (trainId1 == "")
    		{
    			Ranorex.Report.Error("trainSeed is blank");
    			return;
    		}
    		
    		NS_Trainsheet.NS_OpenTrainStatusSummary_MainMenu();
    		Trainsrepo.TrainId = trainId1;
    		Tracklinerepo.TrainId = trainId2 ;

    		//Retry 3 times if the Train is not dragged
    		while(!dragged && retries < 3)
    		{
    			if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Failure("Row with Train Id {"+trainId1+"} Not found in Train Status Summary");
    				
    				if (closeTrainStatusSummaryForm)
    				{
    					NS_Trainsheet.NS_CloseTrainStatusSummary();
    				}
    				return;
    			} else
    			{
    				dragAndDrop(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainID, Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject);
    				dragged = true;
    			}
    		}
			
			
    		if (closeTrainStatusSummaryForm)
    		{
    			NS_Trainsheet.NS_CloseTrainStatusSummary();
    		}
    		return;
			
		}
		
		
		/// <summary>
		/// Drag and Drop Basically train from One Place to Another
		/// </summary>
		/// <param name="fromAdapter">Object to be dragged</param>
		/// <param name="toAdapter">Object where it is to be dragged</param>
		public static void dragAndDrop(Ranorex.Adapter fromAdapter, Ranorex.Adapter toAdapter)
		{
			//If Object visible then drag else mark failure
			if(fromAdapter.EnsureVisible())
			{
				Mouse.MoveTo(fromAdapter);
				Mouse.ButtonDown(WinForms.MouseButtons.Left);
				
				if(toAdapter.EnsureVisible())
				{
					Mouse.MoveTo(toAdapter);
					Mouse.ButtonUp(WinForms.MouseButtons.Left);
				} else
				{
					Ranorex.Report.Failure("Unable to find ToElement");
					return;
				}
				
			} else 
			{
				Ranorex.Report.Failure("Unable to find FromElement");
				return;
			}
			return;	
		}
		
		/// <summary>
		/// Drag Train on a track to another TrackSection
		/// </summary>
		/// <param name="trainSeed"></param>
		/// <param name="trackSection">TrackSectionId</param>
		[UserCodeMethod]
		public static void NS_DragAndDropFromTrackSection(string trainSeed, string trackSection)
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
    		
    		//Find the Train on Track and then move it to another track section
    		Tracklinerepo.TrainId = trainId;
    		Tracklinerepo.TrackSectionId = trackSection ;
    		var trainObject = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject;
    		var trackSectionObject = Tracklinerepo.Trackline_Form.TrackSectionObject;

			dragAndDrop(trainObject, trackSectionObject);
    		
			return;
		}
		
		
		/// <summary>
        /// Acknowledge DRA Pop Up
        /// </summary>
        /// <param name="commentsText">Input:Comments to Input in the Popup</param>
        [UserCodeMethod]
        public static void NS_AcknowledgePopup(string commentsText, bool validatePopupExists, bool validatePinkColor)
        {
            
            int retries = 0;
            //Wait until popup is displayed
			while (!(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)) && retries < 5)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
            
			retries = 0;
            if (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            {
                Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.Self.EnsureVisible();
            
            	//Enter Comments in DRA Popup
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.CommentsText.PressKeys(commentsText);
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.AcknowledgeButton.Click();
            	
            	while(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) && retries < 5)
            	{
            		Ranorex.Delay.Milliseconds(500);
            		retries++;
            	}
            	
            	Ranorex.Report.Info("Bool value is: " +validatePopupExists.ToString());
            	
            	if(validatePopupExists) 
            	{
            	
            		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            		{
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.Self.EnsureVisible();
            
            			//Enter Comments in DRA Popup
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.CommentsText.PressKeys(commentsText);
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.AcknowledgeButton.Click();
            			
            			while(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) && retries < 5)
            			{
            				Ranorex.Delay.Milliseconds(500);
            				retries++;
            			}
            			
            			if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            			{
            				Ranorex.Report.Success("Successfully Acknowledged DRA Popup");
            			} else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) && validatePinkColor)
            			{
            				Ranorex.Report.Success("DRA Popup still Exists");
            			} else
            			{
            				Ranorex.Report.Failure("DRA Popup still Exists at the end");
            			}
            			
            		} else
            		{
            			Ranorex.Report.Success("DRA Popup does not exists as it did not find the popup above");
            		}
            	} else 
            	{
            		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            		{
            			Ranorex.Report.Success("Successfully Acknowledged DRA Popup");
            		} else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) && validatePinkColor)
                  {
                     Ranorex.Report.Success("DRA Popup still Exists");
                  } else
            		{
            			Ranorex.Report.Failure("DRA Popup still Exists at the end");
            		}
            	}
            	
            } else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
            {
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.Self.EnsureVisible();
            
            	//Enter Comments in DRA Popup
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.CommentsText.PressKeys(commentsText);
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.AcknowledgeButton.Click();
            	
            	while(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0) && retries < 5)
            	{
            		Ranorex.Delay.Milliseconds(500);
            		retries++;
            	}
            	
            	if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
            	{
            		Ranorex.Report.Success("Successfully Acknowledged DRA Popup");
            	} else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0) && validatePinkColor)
            	{
            		Ranorex.Report.Success("DRA Popup still Exists");
            	} else 
               {
                  Ranorex.Report.Failure("DRA Popup still Exists");
               }
            	
            	if(validatePopupExists)
            	{
            		if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            		{
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.Self.EnsureVisible();
            			
            			//Enter Comments in DRA Popup
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.CommentsText.PressKeys(commentsText);
            			Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.AcknowledgeButton.Click();
            			
            			while(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0) && retries < 5)
            			{
            				Ranorex.Delay.Milliseconds(500);
            				retries++;
            			}
            			
            			if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
            			{
            				Ranorex.Report.Success("Successfully Acknowledged DRA Popup for Drag And Drop");
            			} else
            			{
            				Ranorex.Report.Failure("DRA Popup still Exists");
            			}
            		} else
            		{
            			Ranorex.Report.Success("DRA Popup is not displayed");
            		}
            		
            	} else 
            	{
            		if(!Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
            		{
            			Ranorex.Report.Success("Successfully Acknowledged DRA Popup");
            		} else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0) && validatePinkColor)
            		{
            			Ranorex.Report.Success("DRA Popup still Exists");
            		} else
            		{
            			Ranorex.Report.Failure("DRA Popup still Exists");
            		}
            	}
            }
        }
        
        /// <summary>
        /// Validate if a train entry is present in CFG_DRA_ACTION table
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="fromOpsta">fromOpsta of DRA Area in which trian should be present</param>
        /// <param name="toOpsta">toOpsta of DRA Area in which trian should be present</param>
        /// <param name="validateIfPresent">TRUE if Train should be present in table else FALSE</param>
		[UserCodeMethod]
		public static void NS_ValidateTrainEntryInActionTable(string trainSeed, string fromOpsta, string toOpsta, bool validateIfPresent)
		{
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string result = null;
			
			if(trainKey!= null || trainKey != "")
			{
				//Get the Train_Key column value from CFG_DRA_ACTION table for a train
				result = Oracle.Code_Utils.CDMSEnvironment.ValidateIfTrainPresentInActionTable(trainKey, fromOpsta, toOpsta);
			} else
			{
				Ranorex.Report.Failure("Unable to find train with Train Seed: " +trainSeed);
				return;
			}
			
			if(validateIfPresent)
			{
				//validate the trainkey column value if train is presnet in DRA Area, else just validate if the result is ""
				if(result == trainKey)
				{
					Ranorex.Report.Success("Train Entry present in CFG_DRA_ACTION table for TrainKey: "+trainKey);
				} else
				{
					Ranorex.Report.Failure("Invalid record for Trainkey: "+trainKey);
				}
			} else 
			{
				if(result == "") 
				{
					Ranorex.Report.Success("Train Entry not present in CFG_DRA_ACTION table for Trainkey: "+trainKey);
				} else 
				{
					Ranorex.Report.Failure("Invalid record for Trainkey: "+trainKey);
				}
				
			}
			
			return;
		}

		/// <summary>
		/// Validate DRA Comment box color
		/// </summary>
		/// <param name="color">color string to be validated if present in DRA Comment box</param>
		/// <param name="validateColorExists">TRUE if user wants to validate if the color exists, else false</param>
		[UserCodeMethod]
		public static void NS_ValidateDRAPopupCommentColor(string color, bool validateColorExists)
		{
			int retries = 0;
			bool colorPresent = false;
            //Wait until popup is displayed
			while (!(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0) || Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0)) && retries < 5)
			{
				Ranorex.Delay.Milliseconds(500);
				retries++;
			}
			
			retries = 0;
            if (Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.SelfInfo.Exists(0))
            {
                Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.Self.EnsureVisible();
            	
                colorPresent = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(
                Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup.CommentsText, 
                color, 
                validateColorExists
                );
            
                	
              	if(colorPresent)
                {
                	Ranorex.Report.Success(color+" is present in DRA Comments Text Box");
                } else {
                	Ranorex.Report.Failure(color+" is not present in DRA Comments Text Box");
                }
            } else if(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.SelfInfo.Exists(0))
            {
            	Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.Self.EnsureVisible();
            	
            	colorPresent = PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(
                Tracklinerepo.Trackline_Form.TracklineGeneratedForms.DeMinimis_Routing_Popup_From_DragAndDrop.CommentsText, 
                color, 
                validateColorExists
                );
            		
            		
                if(colorPresent)
                {
                	Ranorex.Report.Success(color+" is present in DRA Comments Text Box");
                } else {
                	Ranorex.Report.Failure(color+" is not present in DRA Comments Text Box");
                }
            } else 
            {
            	Ranorex.Report.Failure("DRA popup is not visible");
            }
			
		}
		
		/// <summary>
		/// Validate the Entered and Projected Entries if DRA Feature is disabled
		/// </summary>
		/// <param name="validateProjectedEntries">TRUE if user wants to validate Projected Entries, else false</param>
		/// <param name="validateEnteredEntries">TRUE if user wants to validate Entered Entries, else false</param>
		[UserCodeMethod]
		public static void NS_ValidateDRAFeatureDisabledActionTableContent(bool validateProjectedEntries, bool validateEnteredEntries)
		{
			bool projectedEntriesPresent = false;
			bool enteredEntriesPresent = false;
			
			if(validateProjectedEntries)
			{
				projectedEntriesPresent = Oracle.Code_Utils.CDMSEnvironment.CheckProjectedEntriesRemovedInActionTable();
				
				if(projectedEntriesPresent) 
				{
					Ranorex.Report.Success("Projected Entries in CFG_DRA_ACTION table are removed");
				} else 
				{
					Ranorex.Report.Failure("Projected Entries in CFG_DRA_ACTION table are not removed");
				}
			}
			
			if(validateEnteredEntries)
			{
				enteredEntriesPresent = Oracle.Code_Utils.CDMSEnvironment.CheckEnteredEntriesRetainedInActionTable();
				
				if(enteredEntriesPresent) 
				{
					Ranorex.Report.Success("Entered Entries in CFG_DRA_ACTION table are retained");
				} else 
				{
					Ranorex.Report.Failure("Entered Entries in CFG_DRA_ACTION table are not retained");
				}
			}
		}
		
		
		/// <summary>
		/// Enable or Disable DRA Feature from CDMS
		/// </summary>
		/// <param name="disableDRA">TRUE if user wants to disable DRA Feature , else FALSE</param>
		[UserCodeMethod]
		public static void NS_EnableDisableDRAFeature(bool disableDRA)
		{
			
			bool isDRADisable = false;
			if(disableDRA)
			{
				isDRADisable = Oracle.Code_Utils.CDMSEnvironment.updateCFGCommonConfigTab("DRA_FEATURE_ENABLED", "FALSE");
				
				if(isDRADisable) 
				{
					Ranorex.Report.Success("Disabled DRA Feature from CDMS CFG_COMMON_CONFIG_TAB");
				} else 
				{
					Ranorex.Report.Failure("Unable to disable DRA Feature from CDMS CFG_COMMON_CONFIG_TAB");
				}
			} else
			{
				isDRADisable = Oracle.Code_Utils.CDMSEnvironment.updateCFGCommonConfigTab("DRA_FEATURE_ENABLED", "TRUE");
				
				if(isDRADisable) 
				{
					Ranorex.Report.Success("Enabled DRA Feature from CDMS CFG_COMMON_CONFIG_TAB");
				} else 
				{
					Ranorex.Report.Failure("Unable to enable DRA Feature from CDMS CFG_COMMON_CONFIG_TAB");
				}
			}
		}
		
		/// <summary>
		/// Get the projected train count information of train in Projected table before
		/// Acknowledge DRA Popup.
		/// </summary>
		/// <param name="draName">Input: DRA Name to get the projected train count</param>
		[UserCodeMethod]
		public static string NS_GetDRAProjectedCount(string draName){
		
			string projectedCount = "";
			if(draName != null){
				projectedCount = NS_GetDRATrainCountSummaryProjectedCount(draName).ToString().Trim();
				Report.Info("Before Acknowledge DRA Popup Projected train count: "+projectedCount.ToString());
			}
			
			Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
			return projectedCount;
		}
		
		
		/// <summary>
		/// Validate the projected count information of train in Projected table get decreased  by 1 after Acknowledge DRA Popup
		/// </summary>
		/// <param name="draName">Input: DRA Name to get the projected train count</param>
		/// <param name="projectedCount">Input: Get projected count from "NS_GetDRAProjectedCount" this method.</param>
		[UserCodeMethod]
		public static void NS_ValidatedDRAProjectedCountDecreased (string draName, string projectedCount)
		{
			
			int afterPopupAckProjectedCount = NS_GetDRATrainCountSummaryProjectedCount(draName);
			int beforePopupAckprojectedCount = Convert.ToInt32(projectedCount);
			
			if(afterPopupAckProjectedCount == beforePopupAckprojectedCount - 1){
				Ranorex.Report.Success("Verified Projected Train Count is decreased by 1, After Acknowledge DRA Popup Projected train count: "+afterPopupAckProjectedCount.ToString());
			}else{
				Ranorex.Report.Failure("Projected Train Count is Not decreased by 1, After Acknowledge DRA Popup Projected train count: "+afterPopupAckProjectedCount.ToString());
			}
			
			
		}
		
		
		/// <summary>
		/// Get the entered train count information of train in Entered table after
		/// Acknowledge DRA Popup.
		/// </summary>
		/// <param name="draName">Input: DRA Name to get the entered train count</param>
		[UserCodeMethod]
		public static string NS_GetDRAEnteredCount(string draName){
		
			string enteredCount = "";
			if(draName != null){
				enteredCount = NS_GetDRATrainCountSummaryEnteredCount(draName).ToString().Trim();
				Report.Info("Before Acknowledge DRA Popup Entered train count: "+enteredCount.ToString());
			}
			
			Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
			return enteredCount;
		}
		
		
		
		/// <summary>
		/// Validate the entered count information of train in Entered table get increased  by 1 after Acknowledge DRA Popup
		/// </summary>
		/// <param name="draName">Input: DRA Name to get the entered train count</param>
		/// <param name="enteredCount">Input: Get entered count from "NS_GetDRAEnteredCount" this method.</param>
		[UserCodeMethod]
		public static void NS_ValidatedDRAEnteredCountIncreased (string draName, string enteredCount)
		{
			
			int afterPopupAckEnteredCount = NS_GetDRATrainCountSummaryEnteredCount(draName);
			int beforePopupAckenteredCount = Convert.ToInt32(enteredCount);
			
			if(afterPopupAckEnteredCount == beforePopupAckenteredCount + 1){
				Ranorex.Report.Success("Verified Entered Train Count is increased by 1, After Acknowledge DRA Popup Entered train count: "+afterPopupAckEnteredCount.ToString());
			}else{
				Ranorex.Report.Failure("Entered Train Count is Not increased by 1, After Acknowledge DRA Popup Entered train count: "+afterPopupAckEnteredCount.ToString());
			}
			
			Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
			
		}
		
		
		/// <summary>
		/// Validate the DRA Train Count Summary Window Text if No Results present or if Feature is disabled
		/// </summary>
		/// <param name="enteredCount">Input: Get entered count from "NS_GetDRAEnteredCount" this method.</param>
		[UserCodeMethod]
		public static void NS_ValidateDRAFeatureIsDisabledInUI(bool validateFeatureDisabled)
		{
			NS_OpenDRATrainCountSummaryWindow();
			
			if(validateFeatureDisabled && Trainsrepo.Deminimis_Routing_Train_Count_Summary.SelfInfo.Exists(0))
			{
				if(Trainsrepo.Deminimis_Routing_Train_Count_Summary.DRACenterText.GetAttributeValue<string>("Text").Contains("FEATURE IS DISABLED"))
				{
					Ranorex.Report.Success("Feature is Disabled");
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					return;					
				} else 
				{
					Ranorex.Report.Failure("Feature is not Disabled");
					Trainsrepo.Deminimis_Routing_Train_Count_Summary.WindowControls.Close.Click();
					return;
				}
				
			} else 
			{
				Ranorex.Report.Failure("Unable to Open DRA Train Count Summary Page or validateFeatureDisabled var is false");
			}
			
		}
		/// <summary>
		/// To add new dra zone 
		/// </summary>
		/// <param name="labelName">Input: label name to run DRA Tool</param>
		[UserCodeMethod]
		public static void runDRATool(string labelName)
		{
			Report.Info("Running runDraTool Scripts...");
			LinuxUtils.runDRAToolScripts(labelName); //run DRA recalc_dras command
		
		}
		
		/// <summary>
		/// Update Projected Date in CFG_DRA_ACTION table in CDMS
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed to get trainkey</param>
		/// <param name="fromOpsta">Input:fromOpsta to execute Query for Update projected column in CFG_DRA_ACTION Table</param>
		/// <param name="toOpsta">Input:toOpsta to execute Query for Update projected column in CFG_DRA_ACTION Table</param>
		/// <param name="projectedDateOffset">Input: projectedDateOffset for projected date offset ex. +1, -1, +2, -2 </param>
		[UserCodeMethod]
		public static void NS_UpdateProjectedDateActionTable(string trainSeed, string fromOpsta, string toOpsta, int projectedDateOffset)
		{
			
			string trainKey = NS_TrainID.GetTrainKey(trainSeed);
			string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
			
			if(trainKey != null || trainKey != "")
			{
				//Update Projected Date in CFG_DRA_ACTION table in CDMS
				Oracle.Code_Utils.CDMSEnvironment.updateDRAActionTableProjectedDate(trainKey, fromOpsta, toOpsta, projectedDateOffset);
			} 
			else
			{
				Ranorex.Report.Failure("Unable to find train with Train Id: " +trainId);
				return;
			}
			
		}
    }
    	
}

