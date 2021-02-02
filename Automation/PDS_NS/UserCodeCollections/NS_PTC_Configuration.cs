/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/23/2018
 * Time: 7:11 PM
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
    public class NS_PTC_Configuration
    {
        public static PDS_NS.MainMenu_Repo MainMenurepo = PDS_NS.MainMenu_Repo.Instance;
        public static PDS_NS.SystemConfiguration_Repo SystemConfigurationrepo = PDS_NS.SystemConfiguration_Repo.Instance;

        /// <summary>
    	/// Opens the PTC Configuration Form if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPTCConfigurationForm_MainMenu()
    	{
    		int retries = 0;

    		//Open PTC Configuration Form if it's not already open
    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0))
    		{
    			//Click System Configuration menu
    			MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
    			//Click PTC Configuration in system configuration menu
    			MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PositiveTrainControl.Click();

    			//Wait for PTC Configuration Form to exist in case of lag
    			if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0))
    			{
    				Ranorex.Delay.Milliseconds(500);
    				while (!SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0) && retries < 2)
    				{
    					Ranorex.Delay.Milliseconds(500);
    					retries++;
    				}

    				if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0))
    				{
    					Ranorex.Report.Error("System Configuration form did not open");
    					return;
    				}
    			}
    		}
    		return;
    	}

    	/// <summary>
    	/// Opens the PTC Configuration Form on the Application Configuration tab if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu()
    	{
    		NS_OpenPTCConfigurationForm_MainMenu();

    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.ApplicationConfigurationTab.GetAttributeValue<bool>("Selected"))
    		{
    			GeneralUtilities.ClickAndWaitForWithRetry(
					SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.ApplicationConfigurationTabInfo,
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SelfInfo
				);
    		}
    	}

    	[UserCodeMethod]
    	public static void NS_ClosePTCConfigurationForm (bool closeForm)
    	{
    		if (closeForm)
    		{
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo, SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
    		}
    	}
    	/// <summary>
    	/// Opens the PTC Configuration Form on the Communication Configuration tab if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPTCConfigurationForm_CommunicationConfiguration_MainMenu()
    	{
    		NS_OpenPTCConfigurationForm_MainMenu();

    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.CommunicationConfigurationTab.GetAttributeValue<bool>("Selected"))
    		{
    			SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.CommunicationConfigurationTab.Click();
    		}
    	}

    	/// <summary>
    	/// Opens the PTC Configuration Form on the District Configuration tab if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu()
    	{
    		NS_OpenPTCConfigurationForm_MainMenu();

    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.DistrictConfigurationTab.GetAttributeValue<bool>("Selected"))
    		{
	    		int retries = 0;
	    		SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.DistrictConfigurationTab.Click();
	    		while (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.DistrictConfigurationTab.GetAttributeValue<bool>("Selected") && retries < 3)
	    		{
	    			Ranorex.Delay.Milliseconds(500);
	    			SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.DistrictConfigurationTab.Click();
	    			retries++;
	    		}
	    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.DistrictConfigurationTab.GetAttributeValue<bool>("Selected"))
	    		{
	    			Ranorex.Report.Error("Could not switch PTC Configuration Tab to District Configuration");
	    		}
    		}
    		return;
    	}

    	/// <summary>
    	/// Opens the PTC Configuration Form on the Test Trains tab if not already open
    	/// </summary>
    	[UserCodeMethod]
    	public static void NS_OpenPTCConfigurationForm_TestTrains_MainMenu()
    	{
    		NS_OpenPTCConfigurationForm_MainMenu();

    		if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.TestTrainsTab.GetAttributeValue<bool>("Selected"))
    		{
    			SystemConfigurationrepo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.TestTrainsTab.Click();
    		}
    	}

    	[UserCodeMethod]
    	public static void PTCApplicationConfigurationDSSR (bool enableBulletinVoiceAcknowledgement, 
			bool enableBulletinCrewAcknowledgement, 
			bool enableTrackAuthorityCrewAcknowledgement, 
			bool enableGPSTracking, 
			bool enableSwitchPositionAwareness, 
			bool enablePTCCIBOSTraffic, 
			bool enableUnsolictedTCON,
			bool dispatchSuspendAll,
			bool dispatchResumeAll,
			bool saveCurrentDistrictStates,
			bool loadDistrictsFormExpected,
			string loadDistrictsEnabledValidations,
			string okOrCancelLoadSavedDistricts,
			bool closePTCConfigurationForm)
    	{
    		PTCApplicationConfiguration( enableBulletinVoiceAcknowledgement, enableBulletinCrewAcknowledgement, enableTrackAuthorityCrewAcknowledgement, enableGPSTracking, enableSwitchPositionAwareness, enablePTCCIBOSTraffic, enableUnsolictedTCON, false);
    		ConfigureSuspendAll(dispatchSuspendAll);
    		ConfigureResumeAll(dispatchResumeAll);
    		ConfigureSaveCurrentDistrictStates(saveCurrentDistrictStates);
    		
    		if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled && !loadDistrictsFormExpected)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo,
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo
				);
			} 
    		else if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled && loadDistrictsFormExpected)
    		{
    			GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo, SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo);
    			LoadDistrictsToPreviouslySaveConfigurationDSSR(loadDistrictsEnabledValidations, okOrCancelLoadSavedDistricts);
    		
    		}
			
			if (closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
					SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo
				);
			}
    	}
    	
        /// <summary>
		/// Configure PTC
		///
        [UserCodeMethod]
		public static void PTCApplicationConfiguration(
			bool enableBulletinVoiceAcknowledgement, 
			bool enableBulletinCrewAcknowledgement, 
			bool enableTrackAuthorityCrewAcknowledgement, 
			bool enableGPSTracking, 
			bool enableSwitchPositionAwareness, 
			bool enablePTCCIBOSTraffic, 
			bool enableUnsolictedTCON,
			bool closePTCConfigurationForm
		)
		{
			NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();
			
			ConfigureBulletinCrewAck(enableBulletinCrewAcknowledgement);
			ConfigureBulletinVoiceAck(enableBulletinVoiceAcknowledgement);
			ConfigureTrackAuthorityCrewAck(enableTrackAuthorityCrewAcknowledgement);
			ConfigureEnableGPSTracking(enableGPSTracking);
			ConfigureEnableSwitchPositionAwareness(enableSwitchPositionAwareness);
			ConfigureEnablePTCCIBOSDataTraffic(enablePTCCIBOSTraffic);
			ConfigureEnableUnsolicitedTCON(enableUnsolictedTCON);

			// Note: Technically, the additions to this method do not break the original wrapper method
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo,
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo
				);
			}
			
			if (closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
					SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo
				);
			}
			

		}

		/// <summary>
		/// Turns unsolicited tcon setting on or off
		/// </summary>
		/// <param name="On">sets unsolicited tcon to true if true</param>
		/// <param name="closePTCConfigurationForm">Closes the PTC configuration form if true</param>
        [UserCodeMethod]
		public static void NS_ConfigureUnsolicitedTCON(bool On, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();
			ConfigureEnableUnsolicitedTCON(On);

			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
			}

			if(closePTCConfigurationForm)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Click();
			}
		}

      	/// <summary>
		/// Turns Bulletin Item Voice Acknowledgement Required setting on or off
		/// </summary>
		/// <param name="On">sets field to to true if true</param>
		/// <param name="closePTCConfigurationForm">Closes the PTC configuration form if true</param>
      	[UserCodeMethod]
		public static void ConfigureBulletinItemVoiceAcknowledgementRequired_NS(bool On, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();
			ConfigureBulletinVoiceAck(On);

			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled)
			{
				GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo,
				                                                      SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo);
			}

			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}

      	/// <summary>
		/// Turns PTC Setting to Default
		/// </summary>
		/// <param name="On"></param>
		///
      	[UserCodeMethod]
		public static void ConfigureDefaultPTCSettings(bool On, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();

			if (On)
			{
				//Bulletin Voice Ack: False, Bulletin Crew Ack: True, Track Authority Crew Ack: True
				//Enable GPS Tracking: False, Enable Switch Position Awareness: False, Enable PTC CI BOS Traffic: True
				//Enable Unsolicited TCON: False
				PTCApplicationConfiguration(false, true, true, true, false, true, false, true);
			} else {
				//Bulletin Voice Ack: True, Bulletin Crew Ack: True, Track Authority Crew Ack: True
				//Enable GPS Tracking: False, Enable Switch Position Awareness: False, Enable PTC CI BOS Traffic: False
				//Enable Unsolicited TCON: False
				PTCApplicationConfiguration(true, true, true, false, false, false, false, true);
			}

			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
			}

			if(closePTCConfigurationForm)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Click();
			}
		}

		/// <summary>
		/// Select PTC District Settings
		/// </summary>
		///
		[UserCodeMethod]
		public static void NS_ConfigurePTCDistricts(string division, string districts, string districtMode, bool clickApply, bool enablePTCMessages, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();

			var districtConfiguration = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration;

			// Choose Division
			string selectedDivision = districtConfiguration.Division.DivisionMenuItem.SelectedItemText;
			if (selectedDivision != division)
			{
				SystemConfigurationrepo.Division = division;
				districtConfiguration.Division.DivisionMenuItem.Click();
				districtConfiguration.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
			}

			// Define and click coordinates for PTC Mode, whether 'Disable' or 'Enable'.
			string ptcCoordinates;
			string columnIndex;

			switch (districtMode)
			{
				case "Monitor":
					ptcCoordinates = "71;9";
					columnIndex = "1";
					break;
				case "Test":
					ptcCoordinates = "136;9";
					columnIndex = "2";
					break;
				case "Enable":
					ptcCoordinates = "194;9";
					columnIndex = "3";
					break;
				default:
					ptcCoordinates = "10;9";
					columnIndex = "0";
					break;
			}

			// Update PTC permissions for each district as necessary.
			string[] districtList = districts.Split('|');
			foreach (string district in districtList)
			{
				SystemConfigurationrepo.District = district;
				if (!districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("Could not find District {" + district + "} in PTC District Configuration");
					continue;
				}
				if (districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.PTCMode.Text != columnIndex)
				{
					districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.PTCMode.Click(ptcCoordinates);
				}

				bool isChecked = (districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnablePTCMessages.GetAttributeValue<string>("Text") == "true" ? true : false);
				//If the setting is to Disable, we do not have to check this box
				if ((enablePTCMessages != isChecked) && (columnIndex != "0"))
				{
					districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnablePTCMessages.Click();
				}
			}


			if (clickApply)
			{
				GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo,
				                                                      SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo);
			}

			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}
		
		/// <summary>
		/// Select PTC District Settings and handle Error popup if Any form is already open
		/// </summary>
		///
		[UserCodeMethod]
		public static void NS_ConfigurePTCDistrictsAndHandleErrorPopup(string division, string districts, string districtMode, bool clickApply, bool enablePTCMessages, bool invalidStatePopup, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();

			var districtConfiguration = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration;

			// Choose Division
			string selectedDivision = districtConfiguration.Division.DivisionMenuItem.SelectedItemText;
			if (selectedDivision != division)
			{
				SystemConfigurationrepo.Division = division;
				districtConfiguration.Division.DivisionMenuItem.Click();
				districtConfiguration.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
			}

			// Define and click coordinates for PTC Mode, whether 'Disable' or 'Enable'.
			string ptcCoordinates;
			string columnIndex;

			switch (districtMode)
			{
				case "Monitor":
					ptcCoordinates = "71;9";
					columnIndex = "1";
					break;
				case "Test":
					ptcCoordinates = "136;9";
					columnIndex = "2";
					break;
				case "Enable":
					ptcCoordinates = "194;9";
					columnIndex = "3";
					break;
				default:
					ptcCoordinates = "10;9";
					columnIndex = "0";
					break;
			}

			// Update PTC permissions for each district as necessary.
			string[] districtList = districts.Split('|');
			foreach (string district in districtList)
			{
				SystemConfigurationrepo.District = district;
				if (!districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.SelfInfo.Exists(0))
				{
					Ranorex.Report.Error("Could not find District {" + district + "} in PTC District Configuration");
					continue;
				}
				if (districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.PTCMode.Text != columnIndex)
				{
					districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.PTCMode.Click(ptcCoordinates);
				}

				bool isChecked = (districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnablePTCMessages.GetAttributeValue<string>("Text") == "true" ? true : false);
				//If the setting is to Disable, we do not have to check this box
				if ((enablePTCMessages != isChecked) && (columnIndex != "0"))
				{
					districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnablePTCMessages.Click();
				}
			}


			if (clickApply)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
				
				if(invalidStatePopup)
				{
					Ranorex.Report.Info("Invalid PTC State Change Popup Displayed, Cancelling all the changes..");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.InValidPTCDistrictStateChange.OkButtonInfo,
					                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.InValidPTCDistrictStateChange.SelfInfo);
				}
			}

			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}

		/// <summary>
		/// This method should ultimately mimic the existing method to enable PTC messages by district, such that:
		/// 1. This method can become its own user code method, wrapped into a recording that does nothing more than enable BI electronic ack by district.
		/// 2. This method can also be wrapped into the existing method to enable PTC messages, so that we're provided the option of including this method into that process if we choose.
		/// </summary>
		/// <param name="division"></param>
		/// <param name="district"></param>
		/// <param name="enableBIAck"></param>
		/// <param name="clickApply"></param>
		/// <param name="closePTCConfigurationForm"></param>
		[UserCodeMethod]
		public static void NS_ConfigurePTCDistricts_EnableBIAck(string division, string districts, bool enableBIAck, bool clickApply, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();

			if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByIndex.EnableBulletinElectronicAckInfo.Exists(0))
			{
				Report.Info("TODO: Decide on what the reaction should be here from an automation perspective.");
			}

			var districtConfiguration = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration;
			
			// Choose Division
			string selectedDivision = districtConfiguration.Division.DivisionMenuItem.SelectedItemText;
			if (selectedDivision != division)
			{
				SystemConfigurationrepo.Division = division;
				districtConfiguration.Division.DivisionMenuItem.Click();
				districtConfiguration.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
			}

			string[] listOfdistricts = districts.Split('|');
			foreach (string district in listOfdistricts)
			{
				SystemConfigurationrepo.District = district;
	
				bool isChecked = (districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnableBulletinElectronicAck.GetAttributeValue<string>("Text") == "true" ? true : false);
				//If the setting is to Disable, we do not have to check this box
				if (enableBIAck != isChecked)
				{
					// TODO: Create a method to retry a check and uncheck in general utils, so that this can be hardened alongside similar processes that interface with checkboxes.
					districtConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnableBulletinElectronicAck.Click();
				}
			}

			if (clickApply)
			{
				GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo,
				                                                      SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo);
			}
			
			if (closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo, 
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}

		}


		
		[UserCodeMethod]
		public static void ConfigurePTCCrewAcknowledgement(bool Enabled)
		{
			if (Enabled) {
				ConfigureTrackAuthorityCrewAck(true);
			} else {
				ConfigureTrackAuthorityCrewAck(false);
			}
		}

		[UserCodeMethod]
		public static void NS_ResetPTCConfiguration(bool pressReset)
		{
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButton.Enabled && pressReset)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButton.Click();
			}
		}
		
		[UserCodeMethod]
		public static void NS_ApplyPTCConfiguration(bool pressApply)
		{
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled && pressApply)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
			}
		}
		
		public static void ApplyPTCConfiguration()
		{
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
			}
		}

		public static void ApplySystemAccessControl()
		{
			if (SystemConfigurationrepo.System_Access_Control.ApplyButton.Enabled)
			{
				SystemConfigurationrepo.System_Access_Control.ApplyButton.Click();
			}
		}

		public static void CloseSystemAccessControl()
		{
			if (SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(
					SystemConfigurationrepo.System_Access_Control.CancelButtonInfo,
					SystemConfigurationrepo.System_Access_Control.SelfInfo
				);
			}
		}

		public static void OpenSystemAccessControl()
		{
			if (!SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists())
			{
				MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
				MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SystemAccessControl.Click();
			}
		}

		/// <summary>
		/// Turns on PTC Settings in System Access Control
		/// </summary>
		/// <param name="grantPermission"></param>
		///
		[UserCodeMethod]
		public static void NS_SetDefaultSystemAccessControl(bool grantPermission)
		{
			OpenSystemAccessControl();
			if (grantPermission)
			{
				EditPTCConfiguration(true);
				ViewPTCConfiguration(true);
				AllowPTCLogoff(true);
			} else {
				EditPTCConfiguration(false);
				ViewPTCConfiguration(false);
				AllowPTCLogoff(false);
			}
			ApplySystemAccessControl();
			CloseSystemAccessControl();
		}

		public static void ConfigureBulletinVoiceAck(bool On){
			// Electronic Delivery Feature conditionally removes this PTC Configuration Option.
			bool exists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckboxInfo.Exists(0);
			if (exists)
			{
				bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckbox.Checked;
				bool isEnabled = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckbox.Enabled;
				if ((isChecked != On) && isEnabled) 
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckbox.Click();
					if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckbox.Checked != On) {
						Report.Failure("Validation", "PTC setting Configure Bulletin Voice Acknowledgement not properly set");
					} else {
						Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Bulletin Voice Acknowledgement is properly set"); 
					}
				}
			} else {
				Report.Info("The following PTC Configuration Option does not exist: BI Voice Acknowledgment Required. It must be enabled enabled by district.");
			}
		}

		public static void ConfigureSuspendAll(bool suspendAll){
			bool exists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAllInfo.Exists(0);
			if (exists)
			{
				bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll.Checked;
				if (isChecked != suspendAll) 
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll.Click();
					if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll.Checked != suspendAll) {
						Report.Failure("Validation", "Couldn't set Dispatch Suspend All Properly.");
					} else {
						Report.Log(ReportLevel.Success, "Validation", "Dispatch Suspend All properly checked."); 
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll.Checked && suspendAll)
							Report.Failure("Resume should not be enabled while Suspend is enabled.");
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates.Checked && suspendAll)
							Report.Failure("Save Current District States should not be enabled while Suspend is enabled.");
					}
				}
				else
				{
					Report.Info("Suspend All already selected?");
				}
			} else {
				Report.Error("DSSR not enabled?"); //pretty much the only reason for personalized functions for each option
			}
		}
		
		public static void ConfigureResumeAll(bool resumeAll){
			bool exists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAllInfo.Exists(0);
			if (exists)
			{
				bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll.Checked;
				if (isChecked != resumeAll) 
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll.Click();
					if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll.Checked != resumeAll) {
						Report.Failure("Validation", "Couldn't set Dispatch Resume All Properly.");
					} else {
						Report.Log(ReportLevel.Success, "Validation", "Dispatch Resume All properly set."); 
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll.Checked && resumeAll)
							Report.Failure("Suspend should not be enabled while Resume is enabled.");
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates.Checked && resumeAll)
							Report.Failure("Save Current District States should not be enabled while Resume is enabled.");
					}
				}
				else
				{
					Report.Info("Resume All already selected?");
				}
			} else {
				Report.Error("DSSR not enabled?"); //pretty much the only reason for personalized functions for each option
			}
		}
		
		public static void ConfigureSaveCurrentDistrictStates(bool save){
			bool exists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStatesInfo.Exists(0);
			if (exists)
			{
				bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates.Checked;
				if (isChecked != save) 
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates.Click();
					if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates.Checked != save) {
						Report.Failure("Validation", "Couldn't set Save Current District States Properly.");
					} else {
						Report.Log(ReportLevel.Success, "Validation", "Save Current District States properly set."); 
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll.Checked && save)
							Report.Failure("Suspend should not be enabled while Resume is enabled.");
						if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll.Checked && save)
							Report.Failure("Resume All should not be enabled while Resume is enabled.");
					}
				}
				else
				{
					Report.Info("Save Current District States already selected?");
				}
			} else {
				Report.Error("DSSR not enabled?"); //pretty much the only reason for personalized functions for each option
			}
		}
		
		public static void ConfigureBulletinCrewAck(bool On){
			// Electronic Delivery Feature conditionally removes this PTC Configuration Option.
			// TODO: One of many options must be considered offline, in the event that existing recordings are assumed to enable the functionality through this method / checkbox.
			bool exists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckboxInfo.Exists(0);
			if (exists)
			{
				bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckbox.Checked;
				if (isChecked != On) 
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckbox.Click();
					if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckbox.Checked != On) {
						Report.Failure("Validation", "PTC setting Configure Bulletin Crew Acknowledgement not properly set");
					} else {
						Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Bulletin Crew Acknowledgement is properly set"); 
					}
				}
			} else {
				Report.Info("The following PTC Configuration Option does not exist: BI Crew Acknowledgment Required. It must be enabled enabled by district.");
			}
		}

		public static void ConfigureTrackAuthorityCrewAck(bool On){
			bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.TrackAuthorityCrewAcknowledgementRequiredCheckbox.Checked;
			bool isEnabled = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.TrackAuthorityCrewAcknowledgementRequiredCheckbox.Enabled;
			if (isChecked != On && isEnabled) {
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.TrackAuthorityCrewAcknowledgementRequiredCheckbox.Click();
				if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.TrackAuthorityCrewAcknowledgementRequiredCheckbox.Checked != On && isEnabled) {
					Report.Failure("Validation", "PTC setting Configure Track Authority Crew Acknowledgement not properly set");
				} else {
					Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Track Authority Crew Acknowledgement is properly set");
				}
			}
		}

		public static void ConfigureEnableGPSTracking(bool On){
			bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableGPSTrackingCheckbox.Checked;
			if (isChecked != On) {
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableGPSTrackingCheckbox.Click();
				if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableGPSTrackingCheckbox.Checked != On) {
					Report.Failure("Validation", "PTC setting Configure Enable GPS Tracking not properly set");
				} else {
					Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Enable GPS Tracking is properly set");
				}
			}
		}

		public static void ConfigureEnableSwitchPositionAwareness(bool On){
			bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableSwitchPositionAwarenessIndicationsCheckbox.Checked;
			if (isChecked != On) {
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableSwitchPositionAwarenessIndicationsCheckbox.Click();
				if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableSwitchPositionAwarenessIndicationsCheckbox.Checked != On) {
					Report.Failure("Validation", "PTC setting Configure Enable Switch Position Awareness not properly set");
				} else {
					Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Enable Switch Position Awareness is properly set");
				}
			}
		}

		public static void ConfigureEnablePTCCIBOSDataTraffic(bool On){
			bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckbox.Checked;
			if (isChecked != On) {
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckbox.Click();
				if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckbox.Checked != On) {
					Report.Failure("Validation", "PTC setting Configure Enable PTC CI BOS Data Traffic not properly set");
				} else {
					Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Enable PTC CI BOS Data Traffic is properly set");
				}
			}
		}

		public static void ConfigureEnableUnsolicitedTCON(bool On){
			bool isChecked = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableUnsolicitedTCONMessageCheckbox.Checked;
			if (isChecked != On) {
				SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableUnsolicitedTCONMessageCheckbox.Click();
				if (SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableUnsolicitedTCONMessageCheckbox.Checked != On) {
					Report.Failure("Validation", "PTC setting Configure Enable Unsolicited TCON not properly set");
				} else {
					Report.Log(ReportLevel.Success, "Validation", "PTC setting Configure Enable Unsolicited TCON is properly set");
				}
			}
		}

		public static void EditPTCConfiguration(bool grantPermission)
		{
			var repoPath = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowByFunction.EditPTCConfiguration;
			bool isGranted = DefineUserPermissions(repoPath.SuperDispatcher);

			if (isGranted != grantPermission)
			{
				repoPath.SuperDispatcher.Click();
				if (grantPermission)
				{
					repoPath.PermissionList.Granted.Click();
				} else {
					repoPath.PermissionList.Denied.Click();
				}
			}
		}

		public static void ViewPTCConfiguration(bool grantPermission)
		{
			var repoPath = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowByFunction.ViewPTCConfiguration;
			bool isGranted = DefineUserPermissions(repoPath.SuperDispatcher);

			if (isGranted != grantPermission)
			{
				repoPath.SuperDispatcher.Click();
				if (grantPermission)
				{
					repoPath.PermissionList.Granted.Click();
				} else {
					repoPath.PermissionList.Denied.Click();
				}
			}
		}

		public static void AllowPTCLogoff(bool grantPermission)
		{
			var repoPath = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowByFunction.AllowPTCLogoff;
			bool isGranted = DefineUserPermissions(repoPath.SuperDispatcher);

			if (isGranted != grantPermission)
			{
				repoPath.SuperDispatcher.Click();
				if (grantPermission)
				{
					repoPath.PermissionList.Granted.Click();
				} else {
					repoPath.PermissionList.Denied.Click();
				}
			}
		}

		public static bool DefineUserPermissions(Ranorex.Cell aRepoPath)
		{
			string isGrantedString = aRepoPath.GetAttributeValue<string>("Text");
			return isGrantedString.Equals("true");
		}

      /// <summary>
		/// Validates the PTC settings for a multiple/single district
		/// </summary>
		///
		[UserCodeMethod]
		public static void ValidateDistrictConfigurationState_NS(string division, string district, string districtMode, bool enablePTCMessages, bool closePTCConfigurationForm)
		{
			NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();
			
			string[] districtList = district.Split('|');
			
			// Choose Division
			string selectedDivision = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Division.DivisionMenuItem.SelectedItemText;
			if (selectedDivision != division)
			{
				SystemConfigurationrepo.Division = division;
				SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Division.DivisionMenuItem.Click();
				SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
			}
			if(!string.IsNullOrEmpty(district))
			{
				for (int i = 0; i < districtList.Length ; i++)
				{
					district = districtList[i];
					SystemConfigurationrepo.District = district;
					bool foundEnableMessages = Convert.ToBoolean(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.EnablePTCMessages.GetAttributeValue<string>("Text"));
					int foundPTCMode = Convert.ToInt16(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByDistrict.PTCMode.GetAttributeValue<string>("Text"));
					string foundPTCModeText = "";
					switch (foundPTCMode)
					{
						case 0:
							foundPTCModeText = "Disable";
							break;
						case 1:
							foundPTCModeText = "Monitor";
							break;
						case 2:
							foundPTCModeText = "Test";
							break;
						case 3:
							foundPTCModeText = "Enable";
							break;
					}
					
					//Perform Validations
					if (foundEnableMessages != enablePTCMessages)
					{
						Ranorex.Report.Failure("Enabled Messages for PTC District {"+district+"} found to be {"+(foundEnableMessages ? "True":"False")+"} but expected to be {"+(enablePTCMessages ? "True":"False")+"}.");
						if(closePTCConfigurationForm)
						{
							SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Click();
						}
						return;
					}
					
					if (foundPTCModeText != districtMode)
					{
						Ranorex.Report.Failure("District Mode for PTC District {"+district+"} found to be {"+foundPTCModeText+"} but expected to be {"+districtMode+"}.");
						if(closePTCConfigurationForm)
						{
							SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Click();
						}
						return;
					}
					
					Ranorex.Report.Success("Enabled Messages for PTC District {"+district+"} found to be {"+(foundEnableMessages ? "True":"False")+"} And District Mode found to be {"+foundPTCModeText+"}.");
				}
			}
			
			if(closePTCConfigurationForm)
			{
				SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Click();
			}
			return;
		}


		/// <summary>
		/// Validates PTC Message Trafic Settings Buttons Exist or Not
		/// </summary>
		/// <param name="configurationTabName">sets field to eg. Application Configuration or Communication Configuration or District Configuration</param>
		/// <param name="closePTCConfigurationForm">Closes the PTC configuration form if true</param>
		[UserCodeMethod]
		public static void ValidatePTCMessageTrafficSettingsButtonState_NS(string configurationTabName, bool buttonsExist, bool closePTCConfigurationForm)
		{
			configurationTabName = configurationTabName.ToLower();
			if(configurationTabName == "application configuration")
			{
				NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();
			}
			else if (configurationTabName == "communication configuration")
			{
				NS_OpenPTCConfigurationForm_CommunicationConfiguration_MainMenu();
			}
			else if (configurationTabName == "district configuration")
			{
				NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();
			}
			else if (configurationTabName == "test trains")
			{
				NS_OpenPTCConfigurationForm_TestTrains_MainMenu();
			}
			else
			{
				Report.Failure("Invalid Configaration Input " +configurationTabName);
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
				return;
			}

			var LoadButton = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.LoadButtonInfo;
			var saveButton = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.SaveButtonInfo;
			var DisableAllButton = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.DisableAllButtonInfo;

			if(buttonsExist)
			{
				if(LoadButton.Exists(0) && saveButton.Exists(0) && DisableAllButton.Exists(0))
				{
					Ranorex.Report.Success("Under District Configuration Tab in PTC Message Traffic Settings Load, Save and DisableAll Button exists.");
				}

				else
				{
					Ranorex.Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.Self);
					Report.Failure("Under District Configuration Tab in PTC Message Traffic Settings Load, Save and DisableAll Button Not exists.");
					if(closePTCConfigurationForm)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
					}
					return;
				}
			}
			else
			{
				if(!LoadButton.Exists(0) && !saveButton.Exists(0) && !DisableAllButton.Exists(0))
				{
					Ranorex.Report.Success("Under District Configuration Tab in PTC Message Traffic Settings Load, Save and DisableAll Button Not exists.");
				}

				else
				{
					Ranorex.Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.Self);
					Report.Failure("Under District Configuration Tab in PTC Message Traffic Settings Load, Save and DisableAll Button exists.");
					if(closePTCConfigurationForm)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
					}
					return;
				}
			}

			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
			return;
		}


		/// <summary>
		/// Validates District Configuration Tab All buttons state Ex. Enabled or Disabled
		/// </summary>
		/// <param name="loadButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="saveButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="disableAllButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="okButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="applyButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="resetButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="cancelButtonEnabled">Sets field to bool value eg. true or false to validate button is Enabled or Disabled</param>
		/// <param name="closePTCConfigurationForm">Closes the PTC configuration form if true</param>
		[UserCodeMethod]
		public static void ValidateDistrictConfigurationTabButtonsState( bool loadButtonEnabled, bool saveButtonEnabled, bool disableAllButtonEnabled, bool okButtonEnabled, bool applyButtonEnabled, bool resetButtonEnabled, bool cancelButtonEnabled, bool closePTCConfigurationForm)
		{
			if(!SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.SelfInfo.Exists(0))
			{
				Report.Failure("PTC Configuration Window District Configuration Tab is not exists.");
				return;
			}

			Report.Screenshot();
			bool loadBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.LoadButton.Enabled;
			bool saveBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.SaveButton.Enabled;
			bool disableBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.DisableAllButton.Enabled;
			bool okBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.OkButton.Enabled;
			bool applyBtn= SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Enabled;
			bool resetBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButton.Enabled;
			bool cancelBtn = SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButton.Enabled;
			Ranorex.Report.Info("button status: "+loadBtn.ToString());

			if(loadButtonEnabled == loadBtn)
			{
				Ranorex.Report.Success("Load button found to be Enabled: {"+(loadBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Load button found to be Enabled: {"+(loadBtn ? "True":"False")+"}");
			}

			if(saveButtonEnabled == saveBtn)
			{
				Ranorex.Report.Success("Save button found to be Enabled: {"+(saveBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Save button found to be Enabled:{"+(saveBtn ? "True":"False")+"}");
			}

			if(disableAllButtonEnabled == disableBtn)
			{
				Ranorex.Report.Success("Disable All button found to be Enabled:{"+(disableBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Disable All buttons found to be Enabled:{"+(disableBtn ? "True":"False")+"}");
			}

			if(okButtonEnabled == okBtn)
			{
				Ranorex.Report.Success("Ok button found to be Enabled:{"+(okBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Ok button found to be Enabled:{"+(okBtn ? "True":"False")+"}");
			}

			if(applyButtonEnabled == applyBtn)
			{
				Ranorex.Report.Success("Apply button found to be Enabled:{"+(applyBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Apply button found to be Enabled:{"+(applyBtn ? "True":"False")+"}");
			}

			if(resetButtonEnabled == resetBtn)
			{
				Ranorex.Report.Success("Reset button found to be Enabled:{"+(resetBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Reset button found to be Enabled:{"+(resetBtn ? "True":"False")+"}");
			}

			if(cancelButtonEnabled == cancelBtn)
			{
				Ranorex.Report.Success("Cancel button found to be Enabled:{"+(cancelBtn ? "True":"False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("Cancel button found to be Enabled:{"+(cancelBtn ? "True":"False")+"}");
			}


			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}


		/// <summary>
		/// PTC Message Traffic Settings Function
		/// </summary>
		/// <param name="division">Set division name eg. Atlanta South</param>
		/// <param name="district">Set district name eg. Georgia</param>
		/// <param name="districtMode">Set Status eg. Enable or Disable</param>
		/// <param name="clickApply"> Set True or False to click Apply button or Not</param>
		/// <param name="closeConfigurationForm">Closes the PTC configuration form if true</param>
		[UserCodeMethod]
		public static void PTCMessageTrafficSettingsFunction(string division, string districts, string districtMode, bool clickApply,  bool enablePTCMessages, bool optClickLoadMessageTraffic, bool optClickSaveMessageTraffic, string expectedFeedback, bool optClickDisableMessageTraffic, bool optClickCancelDisableAllPopup, bool optClickOkDisableAllPopup, bool optClickReset, bool optClickCancelSavePopup, bool optClickOkSavePopup, bool closePTCConfigurationForm)
		{
			NS_ConfigurePTCDistricts(division, districts, districtMode, clickApply, enablePTCMessages, closePTCConfigurationForm);
			var districtConfiguration = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration;
			if(districtConfiguration.PTCMessageTrafficSettings.SelfInfo.Exists(0))
			{
				if(optClickReset)
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButton.Click();
				}

				if(districtConfiguration.PTCMessageTrafficSettings.LoadButton.Visible && optClickLoadMessageTraffic)
				{
					districtConfiguration.PTCMessageTrafficSettings.LoadButton.Click();
					GeneralUtilities.ClickAndWaitForWithRetry(districtConfiguration.PTCMessageTrafficSettings.LoadButtonInfo, districtConfiguration.PTCMessageTrafficSettings.Load_District_Previous_Saved_Config_Form.SelfInfo);
				}

				if(optClickSaveMessageTraffic)
				{
					GeneralUtilities.ClickAndWaitForWithRetry(districtConfiguration.PTCMessageTrafficSettings.SaveButtonInfo, districtConfiguration.PTCMessageTrafficSettings.SelfInfo);
					if(!enablePTCMessages)
					{
						if (districtConfiguration.PTCMessageTrafficSettings.Save_Alert.SelfInfo.Exists(0))
						{
							Report.Info("Save alert dialog box displayed");
						}
						else
						{
							Report.Failure("Save alert dialog box NOT displayed");
						}
					}
					if(optClickCancelSavePopup)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(districtConfiguration.PTCMessageTrafficSettings.Save_Alert.CancelButtonInfo,
						                                                  districtConfiguration.PTCMessageTrafficSettings.Save_Alert.SelfInfo);

						if (!districtConfiguration.PTCMessageTrafficSettings.Save_Alert.SelfInfo.Exists(0))
						{
							Report.Info("Save alert dialog box closed.");
						}
						else
						{
							Report.Failure("Save alert dialog box still open.");
						}
					}

					if(optClickOkSavePopup)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(districtConfiguration.PTCMessageTrafficSettings.Save_Alert.OKButtonInfo,
						                                                  districtConfiguration.PTCMessageTrafficSettings.Save_Alert.SelfInfo);

					}
				}

				if(!NS_Trainsheet.CheckFeedback(SystemConfigurationrepo.Positive_Train_Control_Configuration.Feedback , expectedFeedback))
				{
					Ranorex.Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.Self);

					if (closePTCConfigurationForm)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
					}
					return;
				}

				if(optClickDisableMessageTraffic)
				{
					GeneralUtilities.ClickAndWaitForWithRetry(districtConfiguration.PTCMessageTrafficSettings.DisableAllButtonInfo, districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.SelfInfo);


					if (districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.SelfInfo.Exists(0))
					{
						Report.Info("Disable All alert dialog box displayed");
					}
					else
					{
						Report.Failure("Disable All alert dialog box NOT displayed");
					}

					if(optClickCancelDisableAllPopup)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.CancelButtonInfo,
						                                                 districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.SelfInfo);

						if (!districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.SelfInfo.Exists(0))
						{
							Report.Info("Disable All alert dialog box closed.");
						}
						else
						{
							Report.Failure("Disable All alert dialog box still open.");
						}

					}

					if(optClickOkDisableAllPopup)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.OKButtonInfo,
						                                                  districtConfiguration.PTCMessageTrafficSettings.Disable_All_Alert.SelfInfo);
					}
				}
			}
			else
			{
				Ranorex.Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.Self);
				Report.Failure("Under District Configuration Tab in PTC Message Traffic Settings Load, Save and DisableAll Button is NOT exists.");
				if(closePTCConfigurationForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
				}
			}

			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                 SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}
		
		/// <summary>
		/// Validates Districts, Division and Value In Previously Saved Configuration Popup.
		/// </summary>
		/// <param name="division">Set division name eg. Atlanta South|Atlanta North|Albany</param>
		/// <param name="district">Set district name eg. Georgia</param>
		/// <param name="status">Set Status eg. Enable or Disable</param>
		/// <param name="clickOkPopup"> Set True or False to click Ok button or Not</param>
		/// <param name="closeConfigurationForm">Closes the PTC configuration form if true</param>
		[UserCodeMethod]
		public static void ValidatePreviouslySavedConfigurationDistricts_NS(string division, string districts, string status,  bool clickOkPopup, bool closeLoadDistrictForm)
		{
			var previous_Saved_Config_Form = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.PTCMessageTrafficSettings.Load_District_Previous_Saved_Config_Form;
			if(previous_Saved_Config_Form.SelfInfo.Exists(0))
			{
				int loadDistrictRowCount = previous_Saved_Config_Form.Load_District_Previous_Saved_Config_Table.Self.Rows.Count;
				string[] districtList = districts.Split('|');
				string district_name = "";
				string division_name = "";
				string status_value = "";
				if(!string.IsNullOrEmpty(districts) && loadDistrictRowCount >= 1)
				{
					for (int i = 0; i < loadDistrictRowCount ; i++)
					{
						string district = districtList[i];
						SystemConfigurationrepo.DivisionTableIndex = i.ToString();
						
						district_name = previous_Saved_Config_Form.Load_District_Previous_Saved_Config_Table.DivisionTableListItemsRowByDivisionTableIndex.DistrictName.GetAttributeValue<string>("Text");
						division_name = previous_Saved_Config_Form.Load_District_Previous_Saved_Config_Table.DivisionTableListItemsRowByDivisionTableIndex.DivisionName.GetAttributeValue<string>("Text");
						status_value = previous_Saved_Config_Form.Load_District_Previous_Saved_Config_Table.DivisionTableListItemsRowByDivisionTableIndex.Value.GetAttributeValue<string>("Text");
						
						if (district_name != district)
						{
							Ranorex.Report.Failure("Previously Saved Configuration District found: {"+(district_name)+"} but expected District: {"+(district)+"} .");
							Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
						}
						if (division_name != division)
						{
							Ranorex.Report.Failure("Previously Saved Configuration Division found: {"+(division_name)+"} but expected Division: {"+(division)+"}.");
							Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
						}
						if (status_value != status)
						{
							Ranorex.Report.Failure("Previously Saved Configuration Value found: {"+(status_value)+"} but expected Status Value: {"+(status)+"}.");
							Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
						}
						
						Ranorex.Report.Success("Previously Saved Configuration District: {"+district_name+"}, Division: {"+(division_name)+"} And Status {"+status_value+"} found as Expected In {"+(i+1)+"} Row.");
					}
				}
				else
				{
					Ranorex.Report.Error("Districts Input Empty or Invalid.");
					Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
				}
				if(clickOkPopup)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(previous_Saved_Config_Form.OKButtonInfo, previous_Saved_Config_Form.SelfInfo);
				}
			}
			else
			{
				Ranorex.Report.Failure("Load Districts to Previously Saved Configuration Popup is not open.");
				if(closeLoadDistrictForm)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(previous_Saved_Config_Form.CancelButtonInfo, previous_Saved_Config_Form.SelfInfo);
				}
			}
			
			if(closeLoadDistrictForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(previous_Saved_Config_Form.CancelButtonInfo, previous_Saved_Config_Form.SelfInfo);
			}
			
		}
		
		/// <summary>
		/// Validates Invalid PTC District State Change Popup Exist.
		/// </summary>
		/// <param name="division">Set division name eg. Atlanta South|Atlanta North|Albany</param>
		/// <param name="district">Set district name eg. Georgia</param>
		/// <param name="districtMode">Set Status eg. Enable or Disable</param>
		/// <param name="clickApply"> Set True or False to click Ok button or Not</param>
		/// <param name="enablePTCMessages">Set True or False to click Ok button or Not</param>
		/// <param name="clickOk">Set True or False to click Ok button or Not</param>
		/// <param name="closePTCConfigurationForm">Closes the PTC configuration form if true</param>
		[UserCodeMethod]
		public static void ValidateInvalidPTCDistrictStateChangeExist_NS(string division, string districts, string districtMode, bool clickApply, bool enablePTCMessages, bool validateExist, bool closePTCConfigurationForm)
		{
			 NS_ConfigurePTCDistricts(
                 division: division, districts: districts, districtMode: districtMode, clickApply: false, enablePTCMessages: enablePTCMessages, closePTCConfigurationForm: false
            );
			SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButton.Click();
			
			if(validateExist) 
			{
				if(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Invalid_PTC_District_State_Change.SelfInfo.Exists(0))
				{
					Ranorex.Report.Success("Invalid PTC District State Change Dialog Box Exist.");
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Invalid_PTC_District_State_Change.OkButtonInfo,
					                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Invalid_PTC_District_State_Change.SelfInfo);
				}
				else
				{
					Ranorex.Report.Failure("Invalid PTC District State Change Dialog Box NOT Exist.");
					Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
				}
			}
			else
			{
				if(!SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Invalid_PTC_District_State_Change.SelfInfo.Exists(0))
				{
					Ranorex.Report.Success("Invalid PTC District State Change Dialog Box NOT Exist.");
				}
				else
				{
					Ranorex.Report.Failure("Invalid PTC District State Change Dialog Box is Exist.");
					Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
				}
			}
			if(closePTCConfigurationForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}

		[UserCodeMethod]
		public static void NS_PTCConfig_ValidateBIAcknowledgmentOptionsExist(bool validateDoExist, bool closeForms)
		{
			// Tough call whether to place here, but given that this is a validation method, any active form must close and re-open before proper validation can occur.
			// As such, this method itself should be responsible for closing any active forms before performing the validation.
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
			
			NS_OpenPTCConfigurationForm_ApplicationConfiguration_MainMenu();

			bool buliVoiceAckExists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckboxInfo.Exists(0);
			bool buliCrewAckExists = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckboxInfo.Exists(0);

			string resultMessage = string.Format(
				"BI acknowledgment options exist (expected): '{0}'. BI voice option exists (actual): '{1}' and BI crew option exists (actual): '{2}'",
				validateDoExist, buliVoiceAckExists, buliCrewAckExists
			);
			
			if ((buliVoiceAckExists == validateDoExist) && (buliCrewAckExists == validateDoExist))
			{
				Report.Success("Validation", resultMessage);
			} else {
				Report.Failure("Validation", resultMessage);
				Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.Self);
			}


			if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}

		public static void NS_PTCConfig_ValidateBIByDistrictColumnExists(bool validateColumnExists, bool closeForms)
		{
			if (SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo.Exists(0))
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
			
			NS_OpenPTCConfigurationForm_DistrictConfiguration_MainMenu();

			bool columnExists = SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.DistrictConfigurationTable.DistrictConfigurationRowByIndex.EnableBulletinElectronicAckInfo.Exists(0);

			string resultMessage = string.Format(
				"Enable BI Electronic Acknowledgment by District. Column exists (actual): '{0}' and column exists (expected): '{1}'",
				columnExists, validateColumnExists
			);
			
			if (columnExists == validateColumnExists)
			{
				Report.Success("Validation", resultMessage);
			} else {
				Report.Failure("Validation", resultMessage);
				Report.Screenshot(SystemConfigurationrepo.Positive_Train_Control_Configuration.DistrictConfiguration.Self);
			}


			if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}
		
		[UserCodeMethod]
		public static void ValidateLoadDistrictsToPreviouslySavedConfigurationEntry (string districtName, string divisionName, string enableOrDisable)
		{
			if (!SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo.Exists(0))
			{
				Report.Failure("Load Districts form not present.");
				return;
			}
			SystemConfigurationrepo.DistrictName = districtName;
			if (SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.DistrictTable.RowByDistrictName.SelfInfo.Exists(0))
			{
				if (SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.DistrictTable.RowByDistrictName.Division.Text.Equals(divisionName) &&
				    SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.DistrictTable.RowByDistrictName.Value.Text.Equals(enableOrDisable))
				{
					Report.Success("District "+districtName+" found with value "+enableOrDisable+".");
					return;
				}
				Report.Failure("District found with unanticipated state " +enableOrDisable+" and divison "+divisionName+".");
				return;
			}
			Report.Failure("District not found in table.");
			Report.Screenshot();

		}
		
		[UserCodeMethod]
		public static void LoadDistrictsToPreviouslySaveConfigurationDSSR (string tableEntries, string okOrCancel)
		{
			if (!SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo.Exists(5000))
			{
				Report.Error("Load Districts popup not present.");
				Report.Screenshot();
				return;
			}
			string[] listOfEntries = tableEntries.Split('|');
			if (listOfEntries.Length%3 != 0)
			{
				Report.Error("Number of entires must be in sets of 3.");
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.ButtonCancelInfo, SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo);
				return;
			}
			
			for (int i =0; i < listOfEntries.Length; i +=3)
			{
				ValidateLoadDistrictsToPreviouslySavedConfigurationEntry(listOfEntries[i], listOfEntries[i+1], listOfEntries[i+2]);
			}
			
			if (okOrCancel.ToLower().Equals("ok") || okOrCancel.ToLower().Equals("true"))
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.ButtonOKInfo, SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo);
			else
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.ButtonCancelInfo, SystemConfigurationrepo.Load_Districts_To_Previously_Saved_Config.SelfInfo);
			
		}
		/// <summary>
        ///  Validat Application Configuration Checkbox Enable
        /// </summary>
        /// <param name="bulletinVoiceAckCheckboxEnabled"></param>
        /// <param name="bulletinCrewAckCheckboxEnabled"></param>
        /// <param name="trackAuthorityCrewAckCheckboxEnabled"></param>
        /// <param name="gpsTrackingCheckboxEnabled"></param>
        /// <param name="switchPositionCheckboxEnabled"></param>
        /// <param name="ptcCIBOSDataTrafficCheckboxEnabled"></param>
        /// <param name="tconMsgCheckboxEnabled"></param>
        /// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_Validate_ApplicationConfigurationCheckboxEnable( bool bulletinVoiceAckCheckboxEnabled, bool bulletinCrewAckCheckboxEnabled,
		                                                                      bool trackAuthorityCrewAckCheckboxEnabled, bool gpsTrackingCheckboxEnabled,
		                                                                      bool switchPositionCheckboxEnabled, bool ptcCIBOSDataTrafficCheckboxEnabled,
		                                                                      bool tconMsgCheckboxEnabled,  bool closeForm)
		{
			NS_OpenPTCConfigurationForm_MainMenu();
			
			
			if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.SelfInfo.Exists(0))
			{
				Report.Error("In PTC Configuration Form, Application Configuration Tab is not exists.");
				return;
			}
			
			bool BulletinItemVoiceAcknowledgementRequiredCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemVoiceAcknowledgementRequiredCheckbox.Enabled;
			bool BulletinItemCrewAcknowledgementRequiredCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.BulletinItemCrewAcknowledgementRequiredCheckbox.Enabled;
			bool TrackAuthorityCrewAcknowledgementRequiredCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.TrackAuthorityCrewAcknowledgementRequiredCheckbox.Enabled;
			bool GPSTrackingCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableGPSTrackingCheckbox.Enabled;
			bool SwitchPositionAwarenessIndicationsCheckbox= SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableSwitchPositionAwarenessIndicationsCheckbox.Enabled;
			bool PTCCIBOSDataTrafficCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckbox.Enabled;
			bool UnsolicitedTCONMessageCheckbox = SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnableUnsolicitedTCONMessageCheckbox.Enabled;
			
			
			if(BulletinItemVoiceAcknowledgementRequiredCheckbox == bulletinVoiceAckCheckboxEnabled)
			{
				Ranorex.Report.Success("BulletinItemVoiceAcknowledgementRequired Checkbox found to be : {"+(BulletinItemVoiceAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("BulletinItemVoiceAcknowledgementRequired Checkbox found to be : {"+(BulletinItemVoiceAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			
			if(BulletinItemCrewAcknowledgementRequiredCheckbox == bulletinCrewAckCheckboxEnabled)
			{
				Ranorex.Report.Success("BulletinItemCrewAcknowledgementRequired Checkbox found to be : {"+(BulletinItemCrewAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("BulletinItemCrewAcknowledgementRequired Checkbox found to be : {"+(BulletinItemCrewAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			if(TrackAuthorityCrewAcknowledgementRequiredCheckbox == trackAuthorityCrewAckCheckboxEnabled)
			{
				Ranorex.Report.Success("TrackAuthorityCrewAcknowledgementRequired Checkbox found to be : {"+(TrackAuthorityCrewAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("TrackAuthorityCrewAcknowledgementRequired Checkbox found to be : {"+(TrackAuthorityCrewAcknowledgementRequiredCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			if(GPSTrackingCheckbox == gpsTrackingCheckboxEnabled)
			{
				Ranorex.Report.Success("TrackAuthorityCrewAcknowledgementRequired Checkbox found to be : {"+(GPSTrackingCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("GPSTracking Checkbox found to be : {"+(GPSTrackingCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			if(SwitchPositionAwarenessIndicationsCheckbox == switchPositionCheckboxEnabled)
			{
				Ranorex.Report.Success("SwitchPositionAwarenessIndications Checkbox found to be : {"+(SwitchPositionAwarenessIndicationsCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("SwitchPositionAwarenessIndications Checkbox found to be : {"+(SwitchPositionAwarenessIndicationsCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			if(PTCCIBOSDataTrafficCheckbox == ptcCIBOSDataTrafficCheckboxEnabled)
			{
				Ranorex.Report.Success("PTCCIBOSDataTraffic Checkbox found to be : {"+(PTCCIBOSDataTrafficCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("PTCCIBOSDataTraffic Checkbox found to be : {"+(PTCCIBOSDataTrafficCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			if(UnsolicitedTCONMessageCheckbox == tconMsgCheckboxEnabled)
			{
				Ranorex.Report.Success("UnsolicitedTCONMessage Checkbox found to be: {"+(UnsolicitedTCONMessageCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			else
			{
				Ranorex.Report.Failure("UnsolicitedTCONMessage Checkbox found to be : {"+(UnsolicitedTCONMessageCheckbox ? "Enabled = True":"Disable = False")+"}");
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}
		[UserCodeMethod]
		public static void NS_AddTestTrain_PTCConfiguration(string trainSeed, string crewSegment,string expectedFeedback, bool reset, bool apply, bool closeForm)
		{
			NS_OpenPTCConfigurationForm_TestTrains_MainMenu();
			if (!SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.SelfInfo.Exists(0))
			{
				Report.Error("In PTC Configuration Form, Test Trains Tab is not exists.");
				return;
			}
			
			int rowCount = SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.Self.Rows.Count;
			
			string SCAC = NS_TrainID.GetTrainSCAC(trainSeed) ?? trainSeed;
        	string section = NS_TrainID.GetTrainSection(trainSeed);
        	string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed) ?? trainSeed;
        	string originDate = NS_TrainID.getOriginDate(trainSeed) ?? trainSeed;

			for (int i = 0; i < rowCount; i++)
			{
				SystemConfigurationrepo.TestTrainsIndex = i.ToString();
				string SCAC_Value = SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.SCAC.GetAttributeValue<string>("Text");
				
				if (!string.IsNullOrEmpty(SCAC_Value))
				{
					continue;	
				}
			
				
				if(!string.IsNullOrEmpty(SCAC))
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.SCAC.Click();
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.SCAC.PressKeys(SCAC);
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.SCAC.PressKeys("{TAB}");
					
					if (!NS_Trainsheet.CheckFeedback(SystemConfigurationrepo.Positive_Train_Control_Configuration.Feedback, expectedFeedback))
					{
						if (closeForm)
						{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
							                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
						}
						return;
					}
				}
				
				if (!string.IsNullOrEmpty(trainSymbol))
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Symbol.Click();
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Symbol.PressKeys(trainSymbol);
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Symbol.PressKeys("{TAB}");
					
					if (!NS_Trainsheet.CheckFeedback(SystemConfigurationrepo.Positive_Train_Control_Configuration.Feedback, expectedFeedback))
					{
						if (closeForm)
						{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
							                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
						}
						return;
					}
				}
				
				if(!string.IsNullOrEmpty(section))
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Section.Click();
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Section.PressKeys(section);
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.Section.PressKeys("{TAB}");
					
				}

				if(!string.IsNullOrEmpty(crewSegment))
				{
					if (crewSegment.Length <= 2)
					{
						SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.CrewSegment.Click();
						SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.CrewSegment.PressKeys(crewSegment);
						SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.CrewSegment.PressKeys("{TAB}");
					}
					if (!NS_Trainsheet.CheckFeedback(SystemConfigurationrepo.Positive_Train_Control_Configuration.Feedback, expectedFeedback))
					{
						if (closeForm)
						{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
							                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
						}
						return;
					}
				}
				if(!string.IsNullOrEmpty(originDate))
				{
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.OriginDate.OriginDateText.Click();
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.OriginDate.OriginDateText.PressKeys(originDate);
					SystemConfigurationrepo.Positive_Train_Control_Configuration.TestTrains.TestTrainsTable.TestTrainsRowByTestTrainsIndex.OriginDate.OriginDateText.PressKeys("{TAB}");
					
					if (!NS_Trainsheet.CheckFeedback(SystemConfigurationrepo.Positive_Train_Control_Configuration.Feedback, expectedFeedback))
					{
						if (closeForm)
						{
							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
							                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
						}
						return;
					}
				}
				break;
			}
			// to Apply the Form
			if (apply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo, SystemConfigurationrepo.Positive_Train_Control_Configuration.ApplyButtonInfo);
				Ranorex.Report.Info("Added Values: SCAC value as {" + SCAC + "}, trainSymbol value as {" +trainSymbol + "}  ,Section value as {" +section  + "},and originDate value as {" + originDate + "} ");
			}
			
			if (reset)
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButtonInfo, SystemConfigurationrepo.Positive_Train_Control_Configuration.ResetButtonInfo);
			}
			if (closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Positive_Train_Control_Configuration.CancelButtonInfo,
				                                                  SystemConfigurationrepo.Positive_Train_Control_Configuration.SelfInfo);
			}
		}
    }
}