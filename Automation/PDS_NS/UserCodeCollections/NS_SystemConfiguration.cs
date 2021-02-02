/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/24/2018
 * Time: 11:13 AM
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
using System.Xml.Linq;
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
    public class NS_SystemConfiguration
    {
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.SystemConfiguration_Repo SystemConfigurationrepo = global::PDS_NS.SystemConfiguration_Repo.Instance;
        
        /// <summary>
        /// Opens the System Access Control Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenSystemAccessControl_MainMenu()
        {
            int retries = 0;

            //Open System Access Control Form if it's not already open
            if (!SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists(0))
            {
                //Click System Configuration menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
                //Click System Access Control in System Configuration menu
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SystemAccessControl.Click();
                
                //Wait for System Access Control Form to exist in case of lag
                if (!SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!SystemConfigurationrepo.System_Access_Control.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("System Access Control form did not open");
                        return;
                    }
                }
            }
            
            return;
        }
        
        /// <summary>
        /// Sets a permission in System Access Control
        /// </summary>
        /// <param name="function">Input:Which System access control function you want to change permissions</param>
        /// <param name="userType">Input:The user type, i.e. Super Dispatcher</param>
        /// <param name="grantPermission">Input:True for Granted, False for Denied</param>
        /// <param name="closeForm">Input:Close the form after applied</param>
        [UserCodeMethod]
        public static void NS_EditSystemAccessControl(string function, string userType, bool grantPermission, bool closeForm)
        {
            NS_OpenSystemAccessControl_MainMenu();
            
            if (!function.Contains(" ---")) {
                function = " ---" + function;
            }
            
            SystemConfigurationrepo.SystemAccessRowHeaderName = function;
            SystemConfigurationrepo.SystemAccessColumnHeaderName = userType;
            
            if (!SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowHeaderTable.SystemAccessControlRowHeaderByNameInfo.Exists(0))
            {
                Ranorex.Report.Failure("Column Index not found for User " + userType + " in System Access Control Menu, your spelling or my code may be bad");
                return;
            }
            SystemConfigurationrepo.SystemAccessRowIndex = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowHeaderTable.SystemAccessControlRowHeaderByName.GetAttributeValue<int>("RowIndex").ToString();
            
            if(!SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.ColumnHeaderRow.SystemAccessControlColumnHeaderByNameInfo.Exists(0))
            {
                Ranorex.Report.Failure("Row Index not found for Function " + function + " in System Access Control Menu, your spelling or my code may be bad");
                return;
            }
            SystemConfigurationrepo.SystemAccessColumnIndex = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.ColumnHeaderRow.SystemAccessControlColumnHeaderByName.GetAttributeValue<int>("ColumnIndex").ToString();
            
            string currentSetting = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.CellByColumnIndex.GetAttributeValue<string>("Text");
            if ((currentSetting == "") || (currentSetting.Equals("true") && !grantPermission) || (currentSetting.Equals("false") && grantPermission)) {
                
                SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.CellByColumnIndex.Click();
                
                if (grantPermission) {
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.PermissionList.GrantedInfo,
                                                                      SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.PermissionList.SelfInfo);
                    
                } else {
                    SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.PermissionList.Denied.Click();
                }
                
                SystemConfigurationrepo.System_Access_Control.ApplyButton.Click();
                Ranorex.Report.Info("Permission "+function+" for User "+userType+" set to "+(grantPermission ? "Granted": "Denied")+" in System Access Control Menu.");
            } else {
                Ranorex.Report.Info("Permission "+function+" for User "+userType+" was already set to "+(grantPermission ? "Granted": "Denied")+" in System Access Control Menu. No actions taken.");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.System_Access_Control.CancelButtonInfo,
                                                                  SystemConfigurationrepo.System_Access_Control.SelfInfo);
            }
            
            return;
            
        }
        
        /// <summary>
        /// Opens the Bulletin Items form from System Configuration
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenBulletinItems_MainMenu()
        {
            int retries = 0;

            //Open Bulletin Items Form if it's not already open
            if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Click System Configuration menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
                //Click Bulletin Items form in System Configuration menu
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.BulletinItems.Click();
                
                //Wait for Bulletin Items Form to exist in case of delay
                if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Bulletin Items form did not open");
                        return;
                    }
                }
            }
            
            return;
        }
        
        /// <summary>
        /// It Checks or Unchecks the checkboxes in Bulletin Items form, Deployment tab for a particular bulletin item
        /// </summary>
        /// <param name="bulletinName">Bulletin Type for which config needs to be updated</param>
        /// <param name="checkDispatcherViewEnabled">TRUE if need to check the checkbox, else false if need to uncheck it</param>
        /// <param name="checkRemedyTransferRequried">TRUE if need to check the checkbox, else false if need to uncheck it</param>
        /// <param name="checkPTCTransferEnabled">TRUE if need to check the checkbox, else false if need to uncheck it</param>
        /// <param name="apply">TRUE if need to apply changes else false</param>
        [UserCodeMethod]
        public static void NS_EditBulletinItems_DeploymentTab(string bulletinName, bool checkDispatcherViewEnabled, bool checkPTCTransferEnabled, bool checkRemedyTransferRequired, bool apply)
        {
            SystemConfigurationrepo.BulletinName = bulletinName;
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Select the Bulletin type from dropdown if not already selected and if the dropdown is not disabled
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName) && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.Click();
                    } else
                    {
                        Ranorex.Report.Failure("Unable to find Bulletin Type from the dropdown");
                        return;
                    }
                } else if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName))
                {
                    Ranorex.Report.Info("Bulletin Name is already selected");
                } else {
                    Ranorex.Report.Failure("Something wrong happenend while selecting Bulletin Type from dropdown");
                }
                
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.Deployment.Click();
                Ranorex.Delay.Milliseconds(500);
                
                //Check the checkbox only if the state is not the same as user required
                if(checkDispatcherViewEnabled && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked )
                {
                    GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBoxInfo);
                    
                    if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked)
                    {
                        Ranorex.Report.Failure("Unable to check Dispatcher View Enabled checkbox");
                    }
                    
                } else if(!checkDispatcherViewEnabled && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked)
                {
                    GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBoxInfo);
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked)
                    {
                        Ranorex.Report.Failure("Unable to uncheck Dispatcher View Enabled checkbox");
                    }
                    
                }

                if(checkPTCTransferEnabled && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked )
                {
                    GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBoxInfo);
                    
                    if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked)
                    {
                        Ranorex.Report.Failure("Unable to check PTC Transfer Enabled checkbox");
                    }
                    
                } else if(!checkPTCTransferEnabled && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked)
                {
                	GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBoxInfo);
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked)
                    {
                        Ranorex.Report.Failure("Unable to uncheck PTC Transfer Enabled checkbox");
                    }
                    
                }
                
                if (checkRemedyTransferRequired && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBox.Checked)
                {
                	GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBoxInfo);
                	
                	if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBox.Checked)
                	   {
                	   	Ranorex.Report.Failure("Unable to check Remedy Transfer Requried Checkbox");
                	   }
                }
                else if(!checkRemedyTransferRequired && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBox.Checked)
                {
                	GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBoxInfo);
                	
                	if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBox.Checked)
                	{
                		Ranorex.Report.Failure("Unable to uncheck Dispatcher View Enable checkbox");
                	}
                }
                
                //if apply true then apply the changes and close the form, else do not apply the changes and keep the form opem
                if(apply)
                {
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.DoubleClick();
                    }
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0)) //This doesn't make much sense, it does no actual validations here
                    {
                        Ranorex.Report.Success("Updated Deployment Fields Successfully for Bulletin Type: "+bulletinName);
                    } else {
                        Ranorex.Report.Failure("Unable to update Deployment Fields Successfully for Bulletin Type: "+bulletinName);
                    }
                } else
                {
                    Ranorex.Report.Info("Not Applying the changes");
                }
                
            }
        }

        /// <summary>
        /// Set the bulletin type inside of the bulletin configuration form.
        /// </summary>
        /// <param name="bulletinName">Input: bulletinName. The name of the bulletin to be chosen from the drop-down.</param>
        /// <param name="clickApply">Input: clickApply. Click apply once the value has been set.</param>
        public static void NS_SetBulletinType_BulletinItemsForm(string bulletinName, bool clickApply = false)
        {
            SystemConfigurationrepo.BulletinName = bulletinName;
            NS_OpenBulletinItems_MainMenu();

            string successFeedback = string.Format("Bulletin configuration is set to '{0}'", bulletinName);
            if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName))
            {
                Report.Info(successFeedback);
                return;
            }

            if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Enabled)
            {
                Report.Error(string.Format("Unable to properly set the bulletin form to '{0}'", bulletinName));
                return;
            }

            // Given the if conditions above, the form is not set to the 'bulletinName', and is not disabled.
            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButtonInfo,
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.SelfInfo
               );

            if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.SelfInfo
                   );
                Report.Info(successFeedback);
            }
            else
            {
                Report.Error(string.Format("Bulletin name '{0}' not found in the bulletin list dropdown.", bulletinName));
                return;
            }

            if (clickApply)
            {
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo
                       );
                }
                else
                {
                    Report.Error("The apply button is disabled, and could not be pressed.");
                }
                
            }
        }

        /// <summary>
        /// Edit th effective time for a particular bulletin type in the bulletin configuration form.
        /// </summary>
        /// <param name="bulletinName">Input: bulletinName. The name of the bulletin to configure.</param>
        /// <param name="preEffectiveIntervalHours">Input: preEffectiveIntervalHours. Sets the value for Pre-Effective Interval (hours) if provided a value.</param>
        /// <param name="preEffectiveIntervalDays">Input: preEffectiveIntervalDays. Sets the value for Pre-Effective Interval (days) if provided a value.</param>
        /// <param name="ExpireAfterHours">Input: ExpireAfterHours. Sets the value for Auto-Expire after (hours) if provided a value.</param>
        /// <param name="effectiveTimeDelayMinutes">Input: effectiveTimeDelayMinutes. Sets the value for Effective Time Delay (minutes) if provided a value.</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_EditBulletinEffectiveTime_BulletinItemsForm(
            string bulletinName,
            string preEffectiveIntervalHours,
            string preEffectiveIntervalDays,
            string autoExpireAfterHours,
            string effectiveTimeDelayMinutes,
            bool closeForm = true
           ) {
            NS_OpenBulletinItems_MainMenu();
            NS_SetBulletinType_BulletinItemsForm(bulletinName);

            // TODO: This method is begging to be standardized to remove code duplication and/or the risk of a stroke.
            if (!string.IsNullOrEmpty(preEffectiveIntervalHours))
            {
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalHoursText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalHoursText.Element.SetAttributeValue("Text", preEffectiveIntervalHours);
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalHoursText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Error("The Pre-Effective Hours Interval field is not enabled");
                }
            }

            if (!string.IsNullOrEmpty(preEffectiveIntervalDays))
            {
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalDaysText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalDaysText.Element.SetAttributeValue("Text", preEffectiveIntervalDays);
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalDaysText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Error("The Pre-Effective Days Interval field is not enabled");
                }
            }

            if (!string.IsNullOrEmpty(autoExpireAfterHours))
            {
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.AutoExpireHoursText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.AutoExpireHoursText.Element.SetAttributeValue("Text", autoExpireAfterHours);
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.AutoExpireHoursText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Error("The Auto-Expire After Hours field is not enabled");
                }
            }

            if (!string.IsNullOrEmpty(effectiveTimeDelayMinutes))
            {
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.EffectiveTimeDelayMinutesText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.EffectiveTimeDelayMinutesText.Element.SetAttributeValue("Text", effectiveTimeDelayMinutes);
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.EffectiveTimeDelayMinutesText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Error("The Effective Time Delay field is not enabled");
                }
            }

            if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo
                   );
            }

            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo
                   );
            }
        }
        
        /// <summary>
        /// Validate the checkbox status if it is checked or not in Bulletin Items Deployment tab for a Bulletin Type
        /// </summary>
        /// <param name="bulletinName">Bulletin Name to validate</param>
        /// <param name="isDispatcherViewChecked">TRUE if checkbox state is checked, else false if it is unchecked</param>
        /// <param name="isPTCTransferChecked">TRUE if checkbox state is checked, else false if it is unchecked</param>
        /// <param name="closeForm">TRUE if need to close the form, else FALSE to keep it open</param>
        [UserCodeMethod]
        public static void NS_ValidateCheckBox_DeploymentTab(string bulletinName, bool isDispatcherViewChecked, bool isPTCTransferChecked, bool closeForm)
        {
            SystemConfigurationrepo.BulletinName = bulletinName;
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Select the bulletin type from the dropdown only if it not selected and not disabled
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName) && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.Click();
                    } else
                    {
                        Ranorex.Report.Failure("Unable to find Bulletin Type from the dropdown");
                        return;
                    }
                } else if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName))
                {
                    Ranorex.Report.Info("Bulletin Name is already selected");
                } else {
                    Ranorex.Report.Failure("Something wrong happenend while selecting Bulletin Type from dropdown");
                }
                
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.Deployment.Click();
                Ranorex.Delay.Milliseconds(500);
                
                //Validate the Checkbox status and it not the same as user expected then throw failure
                if(isDispatcherViewChecked && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked)
                {
                    
                    Ranorex.Report.Failure("Dispatcher View Enabled checkbox is not checked");
                    
                } else if(!isDispatcherViewChecked && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox.Checked)
                {
                    Ranorex.Report.Failure("Dispatcher View Enabled checkbox is checked");
                    
                }

                if(isPTCTransferChecked && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked )
                {
                    Ranorex.Report.Failure("PTC Transfer CheckBox is not checked");
                    
                } else if(!isPTCTransferChecked && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox.Checked)
                {
                    Ranorex.Report.Failure("Unable to uncheck PTC Transfer Enabled checkbox");
                }
                
                if(closeForm)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                }
            }
        }
        
        [UserCodeMethod]
        public static void NS_ValidateRSTBuliTableInfo(string bulletinName, string ptcTransfer, string operable, string toTransfer)
        {
            bool result = Oracle.Code_Utils.CDMSEnvironment.validateRSTBuliTypeCFG(bulletinName, ptcTransfer, operable, toTransfer);
            int retries = 0;
            while (!result && retries < 3)
            {
            	retries++;
            	Delay.Seconds(1);
            }  
            if(result)
            {
                Ranorex.Report.Success("Bulletin Information is properly updated in RST_BULI_TYPE_CFG table");
            } else {
                Ranorex.Report.Failure("Bulletin Information is not properly updated in RST_BULI_TYPE_CFG table");
            }
        }
        

        /// <summary>
        /// Validate if the Bulletin Types listed in Bulletin Item Name Dropdown are in Ascending order
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateBulletinTypesInAscendingOrder_BulletinItems()
        {
            List<string> bulletinList = new List<string>();
            List<string> sortedbulletinList = new List<string>();
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                int listSize = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.Self.Items.Count;
                Ranorex.Report.Info("List: "+listSize.ToString());
                
                for(int i=0; i< listSize; i++)
                {
                    SystemConfigurationrepo.BulletinNameIndex = i.ToString();
                    bulletinList.Add(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameIndex.GetAttributeValue<string>("Text"));
                }
                //Copy the list
                sortedbulletinList = bulletinList.GetRange(0, listSize);
                
                //Sort the list in Ascending order but also based on Uppercase comparison
                sortedbulletinList.Sort(StringComparer.Ordinal);
                
                for(int i=0; i<listSize;i++)
                {
                    if(bulletinList[i] != sortedbulletinList[i])
                    {
                        Ranorex.Report.Failure("List is not in Sorted Order");
                        return;
                    }
                }
                
                Ranorex.Report.Success("Bulletin Items list is sorted in Ascending order");
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
            }
        }
        
        /// <summary>
        /// If need to cancel the changes made in Bulletin Items form
        /// </summary>
        /// <param name="acknowledgeCancelPopup">TRUE to acknowledge the Popup to cancel the changes</param>
        [UserCodeMethod]
        public static void NS_CancelChangesInBulletinItems(bool acknowledgeCancelPopup)
        {
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButton.Click();
                
                if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Cancel_Popup_Warning.SelfInfo.Exists(0))
                {
                    if(acknowledgeCancelPopup)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Cancel_Popup_Warning.YesButtonInfo,
                                                                                              SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
                    } else
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Cancel_Popup_Warning.NoButtonInfo,
                                                                                      SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
                    }
                }
                
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Successfully Cancelled the Changes in Bulletin Items Form");
                } else if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0) && !acknowledgeCancelPopup)
                {
                    Ranorex.Report.Success("Successfully Clicked on No button in Warning Popup to Cancel the Changes and Form Still Exists");
                } else {
                    Ranorex.Report.Failure("Bulletin Items form is still open");
                }
                

            } else
            {
                Ranorex.Report.Failure("Bulletin Items Form Not Open");
            }
        }
        
        /// <summary>
        /// Validate the state of all the buttons in Bulletins Items form if Enabled or Disabled
        /// </summary>
        /// <param name="okButton">TRUE if the button is enabled, else FALSE</param>
        /// <param name="applyButton">TRUE if the button is enabled, else FALSE</param>
        /// <param name="cancelButton">TRUE if the button is enabled, else FALSE</param>
        /// <param name="resetButton">TRUE if the button is enabled, else FALSE</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinTypeFormButtonsState_BulletinItems(bool okButton, bool applyButton, bool cancelButton, bool resetButton)
        {
            bool okButtonState = false;
            bool applyButtonState = false;
            bool cancelButtonState = false;
            bool resetButtonState = false;
            
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Get the button state for all the buttons in Bulletin Items Form
                okButtonState = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButton.GetAttributeValue<bool>("Enabled");
                applyButtonState = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.GetAttributeValue<bool>("Enabled");
                cancelButtonState = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButton.GetAttributeValue<bool>("Enabled");
                resetButtonState = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ResetButton.GetAttributeValue<bool>("Enabled");
                
                //If Button states is not the same as in the params then throw failure
                if(okButton != okButtonState)
                {
                    Ranorex.Report.Screenshot(ReportLevel.Info, "OK Button", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButton, false, new RecordItemIndex(2));
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                    
                    Ranorex.Report.Failure("Ok Button is in "+okButtonState.ToString()+" state");
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                    return;
                }
                
                if(applyButton != applyButtonState)
                {
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Apply Button", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton, false, new RecordItemIndex(2));
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                    
                    Ranorex.Report.Failure("Apply Button is in "+applyButtonState.ToString()+" state");
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                    return;
                }
                
                if(cancelButton != cancelButtonState)
                {
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Cancel Button", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButton, false, new RecordItemIndex(2));
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                    
                    Ranorex.Report.Failure("Cancel Button is in "+cancelButtonState.ToString()+" state");
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                    return;
                }
                
                if(resetButton != resetButtonState)
                {
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Reset Button", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ResetButton, false, new RecordItemIndex(2));
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                    
                    Ranorex.Report.Failure("Reset Button is in "+resetButtonState.ToString()+" state");
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                    return;
                }
                
                Ranorex.Report.Success("All the Buttons are in desired state");
            }
        }
        
        /// <summary>
        /// Validate if the Bulletin Items Type Definition form is enabled or Not
        /// </summary>
        /// <param name="isEnabled">TRUE to validate if it is enabled else FALSE if it is disabled</param>
        /// <param name="optBulletinType">Bulletin Type name which is optional but need to select it if need to enable all the fields</param>
        /// <param name="closeForm">TRUE if need to close the form, else FALSE</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinTypeDefinitionFormEnabled(bool isEnabled, string optBulletinType, bool closeForm)
        {
            
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                if(optBulletinType != "" && optBulletinType != null)
                {
                    SystemConfigurationrepo.BulletinName = optBulletinType;
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.Click();
                    } else {
                        Ranorex.Report.Failure("Unable to find bulletin type: "+optBulletinType);
                        return;
                    }
                    
                }
                
                //Select Type Definition tab if not selected
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.GetAttributeValue<bool>("Selected"))
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.Click();
                }
                
                //If True then validate all fields are enabled
                if(isEnabled)
                {

                    //Validate Limit Type field is enabled
                    if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.LimitType.LimitTypeText.GetAttributeValue<bool>("Enabled"))
                    {
                        
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Bulletin Item Type Definition Section is not enabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                    //Validate Bulletin Item Content section is enabled
                    if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemContent.BulletinItemContentTable.Self.GetAttributeValue<bool>("Visible"))
                    {
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Bulletin Item Content is not enabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                    //Validate Bulletin Summary List Section is enabled
                    if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.SummaryListText.SummaryListTextTable.Self.GetAttributeValue<bool>("Visible"))
                    {
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Summary List Section is not enabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                } else
                {
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.LimitType.LimitTypeText.GetAttributeValue<bool>("Enabled"))
                    {
                        
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Bulletin Item Type Definition Section is not disabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemContent.BulletinItemContentTable.Self.GetAttributeValue<bool>("Visible"))
                    {
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Bulletin Item Content is not disabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.SummaryListText.SummaryListTextTable.Self.GetAttributeValue<bool>("Visible"))
                    {
                        Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                        Ranorex.Report.Failure("Summary List Section is not disabled");
                        
                        if(closeForm)
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                        }
                        
                        return;
                    }
                    
                }
                
                Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Self, false, new RecordItemIndex(2));
                
                if(closeForm)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.Close.Click();
                }
                
                Ranorex.Report.Success("Bulletin Item Form State Is Correct");
            }
        }

        /// <summary>
        /// Opens Tracking parameters form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTrackingParameters_MainMenu()
        {
            
            int retries = 0;
            
            //Open Tracking parameters Form if it's not already open
            if (!SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                //Click System Configuration menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
                //Click Tracking parameters in System Configuration menu
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrackingParameters.Click();
                Ranorex.Report.Info("Tracking parameters form has opened");
                
                //Wait for Tracking parameters Form to exist in case of lag
                if (!SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (!SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Tracking parameters form did not open");
                        return;
                    }
                }
            }
        }
        
        
        /// <summary>
        /// Set timer for Tracking parameters
        /// </summary>
        /// <param name="timerOccupancy">Input:Setting value for Track occupancy timer</param>
        /// <param name="timerUnoccupancy">Input:Setting value for Track unoccupancy timer</param>
        /// <param name="departureListVisibility">Input:Setting value for Departure list visibility timer</param>
        /// <param name="departureEligibilityLimit">Input:Setting value for Departure eligibility limit timer</param>
        [UserCodeMethod]
        public static void NS_SetTrackingParameters(string timerOccupancy, string timerUnoccupancy, string departureListVisibility, string departureEligibilityLimit)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            //Set Track occupancy timer
            if(timerOccupancy != "")
            {
                // SystemConfigurationrepo.Tracking_Parameters.ConfigureTrainTracking.TrackOccupancyTimersBox.Timer.Click();
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.PressKeys(timerOccupancy);
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.PressKeys("{TAB}");
                NS_TrackingConfigurableParameters_Feedback(timerOccupancy);
            }
            //Set Track unoccupancy timer
            if(timerUnoccupancy != "")
            {

                //  SystemConfigurationrepo.Tracking_Parameters.ConfigureTrainTracking.TRACKUNOCCUPIED.Click();
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.TrackUnoccupiedText.PressKeys(timerUnoccupancy);
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.PressKeys("{TAB}");
                NS_TrackingConfigurableParameters_Feedback(timerUnoccupancy);
            }
            // Set Departure List Visibility timer
            if(departureListVisibility != "")
            {
                
                //	SystemConfigurationrepo.Tracking_Parameters.ConfigureTrainTracking.DepartureTimeInterval.DepartureListVisibility.Click();
                SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureListVisibilityText.PressKeys(departureListVisibility);
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.PressKeys("{TAB}");
                NS_TrackingConfigurableParameters_Feedback(departureListVisibility);
            }
            //Set Departure Eligibility Limit timer
            if(departureEligibilityLimit != "" )
            {

                //	SystemConfigurationrepo.Tracking_Parameters.ConfigureTrainTracking.DepartureTimeInterval.DepartureEligibilityLimit.Click();
                SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureEligibilityLimitText.PressKeys(departureEligibilityLimit);
                SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.PressKeys("{TAB}");
                NS_TrackingConfigurableParameters_Feedback(departureEligibilityLimit);
            }
            //Click on apply button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo);
            //Click on Ok button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.OKButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
        }
        
        /// <summary>
        /// Validate if the Bulletin Name field is enabled or not in Bulletin Items form
        /// </summary>
        /// <param name="isEnabled">TRUE if the field is enabled else FALSE</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinNameIsDisabledOrNot(bool isEnabled)
        {
            //Open Bulletin Items form
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<bool>("Enabled") && isEnabled) {
                    Ranorex.Report.Failure("Bulletin Name dropdown is disabled");
                } else if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<bool>("Enabled") && !isEnabled)
                {
                    Ranorex.Report.Screenshot(ReportLevel.Info, "Bulletin Items Form", "", SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Element, false, new RecordItemIndex(2));
                    Ranorex.Report.Failure("Bulletin Name dropdown is enabled");
                } else {
                    Ranorex.Report.Success("Bulletin Name dropdown is in correct state "+SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<bool>("Enabled").ToString());
                }
            } else
            {
                Ranorex.Report.Failure("Unable to locate Bulletin Items Form");
            }

        }
        
        /// <summary>
        /// Check the Authority checkboxes in Bulletin Items form for a particular bulletin type
        /// </summary>
        /// <param name="bulletinName">Bulletin Type name to be selected from dropdown</param>
        /// <param name="checkTE">TRUE if need to select the TE Authority checkbox, else FALSE</param>
        /// <param name="checkRW">TRUE if need to select the RW Authority checkbox, else FALSE</param>
        /// <param name="checkOT">TRUE if need to select the OT Authority checkbox, else FALSE</param>
        /// <param name="apply">TRUE if need to apply the changes else FALSE to keep the form open</param>
        [UserCodeMethod]
        public static void NS_CheckAuthorityCheckBox_BulletinItems(string bulletinName, bool checkTE, bool checkRW, bool checkOT, bool apply)
        {
            //Open Bulletin Items form
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Select the bulletin type from dropdown if not already selected and if the dropdown is not disabled
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName) && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.Click();
                    } else
                    {
                        Ranorex.Report.Failure("Unable to find Bulletin Type from the dropdown");
                        return;
                    }
                    
                }
                else if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName))
                {
                    Ranorex.Report.Info("Bulletin Name is already selected");
                }
                else
                {
                    Ranorex.Report.Failure("Something wrong happenend while selecting Bulletin Type from dropdown");
                }
                
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.Selected)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.Click();
                }
                else
                {
                    Ranorex.Report.Info("Type Definition tab is already selected in Bulletin Items form");
                }
                
                //Check the authority checkbox based on the user required state
                if(checkTE && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Click();
                }
                else if(!checkTE && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Click();
                }
                else
                {
                    Ranorex.Report.Info("TE Checkbox is in correct state");
                }
                
                if(checkRW && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Click();
                }
                else if(!checkRW && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Click();
                }
                else
                {
                    Ranorex.Report.Info("RW Checkbox is in correct state");
                }
                
                if(checkOT && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Click();
                }
                else if(!checkOT && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Click();
                }
                else
                {
                    Ranorex.Report.Info("OT Checkbox is in correct state");
                }
                
                //if apply is true then apply the changes and close the form, else keep the form open without apply the changes
                if(apply)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Click();
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButton.Click();
                } else {
                    Ranorex.Report.Info("Keeping the Bulletin Items form open without applying changes");
                }
            } else
            {
                Ranorex.Report.Failure("Unable to locate Bulletin Items Form");
            }

        }
        
        /// <summary>
        /// Validate if an Authority Checkbox is checked or not in Bulletin Items form for a particular bulletin type
        /// </summary>
        /// <param name="bulletinName">Bulletin Type for which need to validate the checkbox state</param>
        /// <param name="isTEChecked">TRUE to validate if the TE checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isRWChecked">TRUE to validate if the RW checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isOTChecked">TRUE to validate if the OT checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="closeForm">TRUE to close the form, else FALSE to keep it open</param>
        [UserCodeMethod]
        public static void NS_ValidateAuthorityCheckBoxState_BulletinItems(string bulletinName, bool isTEChecked, bool isRWChecked, bool isOTChecked, bool closeForm)
        {
            //Open Bulletin Items form
            NS_OpenBulletinItems_MainMenu();
            
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName) && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Enabled)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButton.Click();
                    
                    if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
                    {
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.Click();
                    } else
                    {
                        Ranorex.Report.Failure("Unable to find Bulletin Type from the dropdown");
                        return;
                    }
                    
                }
                else if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text").Contains(bulletinName))
                {
                    Ranorex.Report.Info("Bulletin Name is already selected");
                }
                else
                {
                    Ranorex.Report.Failure("Something wrong happenend while selecting Bulletin Type from dropdown");
                }
                
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.Selected)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.TypeDefinition.Click();
                }
                else
                {
                    Ranorex.Report.Info("Type Definition tab is already selected in Bulletin Items form");
                }
                
                
                //Validate the authority checkbox state and it should be the same as user required, else throw failure
                if(isTEChecked && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Checked)
                {
                    Ranorex.Report.Failure("TE Checkbox is not checked");
                }
                else if(!isTEChecked && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.TECheckBox.Checked)
                {
                    Ranorex.Report.Failure("TE Checkbox is not unchecked");
                }
                else
                {
                    Ranorex.Report.Info("TE Checkbox is in correct state");
                }
                
                if(isRWChecked && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Checked)
                {
                    Ranorex.Report.Failure("RW Checkbox is checked");
                }
                else if(!isRWChecked && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.RWCheckBox.Checked)
                {
                    Ranorex.Report.Failure("RW Checkbox is not checked");
                }
                else
                {
                    Ranorex.Report.Info("RW Checkbox is in correct state");
                }
                
                if(isOTChecked && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Checked)
                {
                    Ranorex.Report.Failure("OT Checkbox is checked");
                }
                else if(!isOTChecked && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.OTCheckBox.Checked)
                {
                    Ranorex.Report.Failure("OT Checkbox is not checked");
                }
                else
                {
                    Ranorex.Report.Info("OT Checkbox is in correct state");
                }
                
                if(closeForm)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButton.Click();
                } else
                {
                    Ranorex.Report.Info("Keeping the Bulletin Items form open without applying changes");
                }
            } else
            {
                Ranorex.Report.Failure("Unable to locate Bulletin Items Form");
            }

        }
        
        
        /// <summary>
        /// Check and Uncheck Nopseudo Train ID checkbox in Tracking parameters
        /// </summary>
        /// <param name="checkNoPseudoTrain">Input If its true checkbox gets checked, if false checkbox of No pseudo train ID gets unchecked</param>
        [UserCodeMethod]
        public static void NS_CheckandUncheckNoPseudoTrainCheckBox(bool checkNoPseudoTrain)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            if(checkNoPseudoTrain)
            {
                if(SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
                {
                    //Enable No Pseudo Train Id checkbox
                    PDS_CORE.Code_Utils.GeneralUtilities.CheckCheckboxAndVerifyChecked(SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox);

                    //	Click on apply button
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo);
                    
                    //SystemConfigurationrepo.Tracking_Parameters.OKButton.Click();
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.OKButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                    Ranorex.Report.Info("No Pseudo_TrainID checkbox is in selected state");
                }
            }
            else
            {
                if(SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.Checked)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.Click();
                }
                
                SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.PressKeys("{TAB}");
                
                //Click on apply button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo);
                //Click on OK button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.OKButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                Ranorex.Report.Info("No Pseudo_TrainID checkbox is in default state");
                
            }
        }
        
        
        /// <summary>
        /// Validate tracking parameters - Checkbox of Pseudo Train suppression filters
        /// </summary>
        /// <param name="isNoPseudoTrainChecked">TRUE to validate if the No pseudoTrain checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isSignalSystemChecked">TRUE to validate if the Signal system checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isSwitchChecked">TRUE to validate if the Switch block checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isTrackChecked">TRUE to validate if the Track block checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isControlPointChecked">TRUE to validate if the Control point checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isLocalFieldChecked">TRUE to validate if the is Local field checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isSignalTechChecked">TRUE to validate if the Signal tech checkbox is checked, Else FALSE to validate it is unchecked</param>
        /// <param name="isTrackandTimeChecked">TRUE to validate if the Track and time checkbox is checked, Else FALSE to validate it is unchecked</param>
        [UserCodeMethod]
        public static void NS_ValidatePseudoTrainFiltersCheckbox_TrackingParameters(bool isNoPseudoTrainChecked, bool isSignalSystemChecked, bool isSwitchChecked, bool isTrackChecked, bool isControlPointChecked, bool isLocalFieldChecked, bool isSignalTechChecked, bool isTrackandTimeChecked)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            if(isNoPseudoTrainChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.Checked)
            {
                Ranorex.Report.Success("No pseudoTrain_ID Checkbox is correct state " +isNoPseudoTrainChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("No pseudoTrain_ID Checkbox is incorrect state " +isNoPseudoTrainChecked.ToString());
            }
            if(isSignalSystemChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalSystemSuspendedCheckbox.Checked)
            {
                Ranorex.Report.Success("Signal system suspended Checkbox is correct state " +isSignalSystemChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Signal system suspended Checkbox is not incorrect state " +isSignalSystemChecked.ToString());
            }
            if(isSwitchChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SwitchBlockCheckbox.Checked)
            {
                Ranorex.Report.Success("Switch block Checkbox is correct state " +isSwitchChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Switch block Checkbox is not incorrect state " +isSwitchChecked.ToString());
            }
            if(isTrackChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackBlockCheckbox.Checked)
            {
                Ranorex.Report.Success("Track block Checkbox is checked state " +isTrackChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Track block Checkbox is incorrect state " +isTrackChecked.ToString());
            }
            if(isControlPointChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.ControlPointFailedCheckbox.Checked)
            {
                Ranorex.Report.Success("Control point failed Checkbox is correct state " +isControlPointChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Control point failed Checkbox is incorrect state " +isControlPointChecked.ToString());
            }
            if(isLocalFieldChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.LocalFieldCheckbox.Checked)
            {
                Ranorex.Report.Success("Local Field Checkbox is correct state " +isLocalFieldChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Local Field Checkbox is incorrect state " +isLocalFieldChecked.ToString());
            }
            if(isSignalTechChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalTechControlCheckbox.Checked)
            {
                Ranorex.Report.Success("Signal Tech control Checkbox is correct state " +isSignalTechChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Signal Tech control Checkbox is incorrect state " +isSignalTechChecked.ToString());
            }
            if(isTrackandTimeChecked == SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackAndTimeCheckbox.Checked)
            {
                Ranorex.Report.Success("Track and Time Checkbox is correct state " +isTrackandTimeChecked.ToString());
            }
            else
            {
                Ranorex.Report.Failure("Track and Time Checkbox is incorrect state " +isTrackandTimeChecked.ToString());
            }
        }
        
        /// <summary>
        /// Opens the Alert events configuration if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenAlertEventsConfiguration_MainMenu()
        {
            int retries = 0;

            //Open Alert events configuration Form if it's not already open
            if (SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo.Exists(0))
            {
                if (!SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.DistributionDevicesList.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        SystemConfigurationrepo.Alert_Events_Configuration.AlertEventsConfigurationTabs.DefineAlertEventsTabInfo,
                        SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.DistributionDevicesList.SelfInfo
                    );
                }
                Ranorex.Report.Success("Alert events configuration form is open.");
                return;
            }

            //Click System Configuration menu
            GeneralUtilities.ClickAndWaitForWithRetry(
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo
            );
            
            //Click Alert Events Configuration in System Configuration menu
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.AlertEventsConfigurationInfo,
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo
            );
            
            //Wait for Alert events configuration Form to exist in case of lag
            while (!SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.DistributionDevicesList.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            if (!SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.DistributionDevicesList.SelfInfo.Exists(0))
            {
                Report.Screenshot();
                Ranorex.Report.Error("Alert events configuration form did not open");
                return;
            }
        }
		
        [UserCodeMethod]
        public static void NS_OpenAlertEventsConfiguration_WorkstationAlertHandling()
        {
            NS_OpenAlertEventsConfiguration_MainMenu();

            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.AlertEventsConfigurationTabs.WorkstationAlertHandlingTabInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SelfInfo
            );
        }

        public static void NS_OpenAlertEventsConfiguration_WorkstationAlertHandling(int alertEventNumber)
        {
            NS_SelectAlertEventId_DefineAlertEvents(alertEventNumber);

            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.AlertEventsConfigurationTabs.WorkstationAlertHandlingTabInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SelfInfo
            );
        }


        public static void NS_OpenAlertEventsConfiguration_AlertEventLevelConfiguration()
        {
            NS_OpenAlertEventsConfiguration_MainMenu();

            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.AlertEventsConfigurationTabs.AlertEventLevelConfigurationTabInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.SelfInfo
            );

        }

        [UserCodeMethod]
        public static void NS_EnableRemedyTransfer_BulletinItemConfiguration(string bulletinName, bool doEnable, bool clickApply, bool closeForms)
        {
            // open bulletin item type config and set bulletin name
            NS_SelectBulletinType_BulletinItemConfiguration(bulletinName);

            // Go to deployment tab
            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.DeploymentInfo,
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBoxInfo
            );

            Ranorex.Core.Repository.RepoItemInfo remedyCheckBox = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Deployment.RemedyTransferRequriedCheckBoxInfo;
            if (doEnable)
            {
                GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(remedyCheckBox);
            } else {
                GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(remedyCheckBox);
            }

            if (clickApply)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo
                );
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.WindowControls.CloseInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo
                );
            }
            
        }

        public static void NS_SelectBulletinType_BulletinItemConfiguration(string bulletinName)
        {
            SystemConfigurationrepo.BulletinName = bulletinName;
            NS_OpenBulletinItems_MainMenu();

            if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                Report.Error(string.Format("Bulletin type does not exist: '{0}'", bulletinName));
                return;
            }

            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Element.SetAttributeValue("DropDownVisible", "True");
            if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo
                );
            } else {
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.Element.SetAttributeValue("DropDownVisible", "False");
                Ranorex.Report.Error("Please specify a valid bulletin name. Check data bindings and try again.");
                return;
            }
        }

        public static void NS_SelectAlertEventId_DefineAlertEvents(int alertEventNumber)
        {
            NS_OpenAlertEventsConfiguration_MainMenu();
            
            SystemConfigurationrepo.AlertIdentifierNumber = alertEventNumber.ToString();
            SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeText.Element.SetAttributeValue("DropDownVisible", "True");

            if (SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeList.AlertIdentifierNameTypeListItemByNumberInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeList.AlertIdentifierNameTypeListItemByNumberInfo,
                    SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeList.AlertIdentifierNameTypeListItemByNumberInfo
                );
            } else {
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeText.Element.SetAttributeValue("DropDownVisible", "False");
                Ranorex.Report.Error("Please specify a valid event alert number. Check data bindings and try again.");
            }
        }

        [UserCodeMethod]
        public static void NS_EditAlertEvent_WorkstationAlertHandling(int alertEventNumber, string userType, string alertLevel, bool doCheck = true, bool closeForms=true)
        {
            SystemConfigurationrepo.AlertLevelIndex = (int.Parse(alertLevel) - 1).ToString();

            Ranorex.Core.Repository.RepoItemInfo userCellInfo;
			switch (userType.ToLower())
			{
				case "local":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Local.AlertLevelByIndexInfo;
					break;
				case "dispatcher":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Dispatcher.AlertLevelByIndexInfo;
					break;
				case "dispatcherterritory":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.DispatcherTerritory.AlertLevelByIndexInfo;
					break;
				case "signaltechnician":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SignalTechnician.AlertLevelByIndexInfo;
					break;
				case "signaltechnicianterritory":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SignalTechnicianTerritory.AlertLevelByIndexInfo;
					break;
				case "supervisor":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Supervisor.AlertLevelByIndexInfo;
					break;
				case "supervisorterritory":
					userCellInfo = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SupervisorTerritory.AlertLevelByIndexInfo;
					break;
				default:
					Ranorex.Report.Error("Please specify a valid user type. Check data bindings and try again.");
					return;
			}

             NS_OpenAlertEventsConfiguration_WorkstationAlertHandling(alertEventNumber);
            
            if (!userCellInfo.Exists(0))
            {
                Report.Screenshot(SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Self);
                Report.Error("Alert configuration option does not exist. Check data bindings and try again.");
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Alert_Events_Configuration.WindowControls.CloseInfo,					
                    SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo
                   );
                
                return;
            }

            Ranorex.Cell userCell = userCellInfo.CreateAdapter<Ranorex.Cell>(true);
            bool isChecked = userCell.GetAttributeValue<string>("Text") == "true";

            int retries = 0;
            while ((isChecked != doCheck) && retries < 3)
            {
                userCell.Click();
                Delay.Milliseconds(100);
                isChecked = userCell.GetAttributeValue<string>("Text") == "true";
                retries++;
            }

            string feedbackMessage = string.Format("Alert configuration enabled status is '{0}' and expected status is '{1}'", isChecked, doCheck);
            if (isChecked != doCheck)
            {
                Report.Error(feedbackMessage);
            } else {
                // Nothing to apply if the box was already checked at the outset
                if (SystemConfigurationrepo.Alert_Events_Configuration.ApplyButton.Enabled)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                        SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo,
                        SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo
                    );
                }
                
                Report.Success(feedbackMessage);
            }
			
            if(closeForms)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.WindowControls.CloseInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
            }
            
        }

        [UserCodeMethod]
        public static void NS_CreateAlertEvent_AlertEventConfiguration(int alertEventNumber, string alertEventName, bool closeForm)
        {
            NS_OpenAlertEventsConfiguration_MainMenu();

            SystemConfigurationrepo.AlertIdentifierNumber = alertEventNumber.ToString();
            SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeText.Element.SetAttributeValue("DropDownVisible", "True");

            if (SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeList.AlertIdentifierNameTypeListItemByNumberInfo.Exists(0))
            {
                Ranorex.Report.Info(string.Format("An alert with the number '{0}' already exists.", alertEventNumber.ToString()));
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeList.AlertIdentifierNameTypeListItemByNumber.Click();
                Report.Screenshot(SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.AlertIdentifierNameType.AlertIdentifierNameTypeText);
                
                if (closeForm)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                        SystemConfigurationrepo.Alert_Events_Configuration.WindowControls.CloseInfo,
                        SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo
                    );
                }
                return;
            } 

            GeneralUtilities.ClickAndWaitForWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.CreateButtonInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.CancelButtonInfo
            );

            SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.AlertEventIDText.Element.SetAttributeValue("Text", alertEventNumber.ToString());
            SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.AlertEventNameText.Click();
            SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.AlertEventNameText.Element.SetAttributeValue("Text", alertEventName);

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.OkButtonInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.DefineAlertEvents.Create_External_Alert_Event.SelfInfo
            );

            if (!SystemConfigurationrepo.Alert_Events_Configuration.ApplyButton.Enabled)
            {
                Ranorex.Report.Error("Unable to apply changes. Please check data bindings, and try again.");
                return;
            }

            GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo,
                SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo
            );

            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Alert_Events_Configuration.WindowControls.CloseInfo,
                    SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo
                );
            }
        }
        
        /// <summary>
        /// Check the feedback in TrainSheet Configrable Parameter Form
        /// </summary>
        /// <param name="labelName">Input:labelName :ex:heldTiming/approchTiming</param>
        public static void NS_TrainSheetConfigurableParameters_Feedback(string labelName)
        {
            string feedback = SystemConfigurationrepo.Train_Sheet_Parameters.Feedback.GetAttributeValue<string>("Text");
            
            if(feedback=="")
            {
                Ranorex.Report.Success("Train Status Summary Inclusion Intervals  '"+labelName+"' has been set  ");
            }
            else
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                Ranorex.Report.Failure("Value passed was not in format");
            }
        }
        
        /// <summary>
        /// Set Inclusion Intervals
        /// </summary>
        /// <param name="heldtiming">Input: heldtiming</param>
        /// <param name="heldtiming">Input: approchtiming</param>
        [UserCodeMethod]
        public static void NS_ModifyInclusionIntervals_TrainSheetParameters(string heldTiming, string approachTiming)
        {
            //Open System Configuration
            MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            //Set Approacing timer
            if (approachTiming!="")
            {
                SystemConfigurationrepo.Train_Sheet_Parameters.ApproachingTrainsText.PressKeys(approachTiming);
                SystemConfigurationrepo.Train_Sheet_Parameters.ApproachingTrainsText.PressKeys("{TAB}");
                Ranorex.Report.Info(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback.GetAttributeValue<string>("Text"));
                NS_TrainSheetConfigurableParameters_Feedback(approachTiming);
            }
            //Set Held timer
            if (heldTiming!="")
            {
                SystemConfigurationrepo.Train_Sheet_Parameters.HeldTrainsText.PressKeys(heldTiming);
                SystemConfigurationrepo.Train_Sheet_Parameters.HeldTrainsText.PressKeys("{TAB}");
                NS_TrainSheetConfigurableParameters_Feedback(heldTiming);
            }
            //Click on apply button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
            
            //Click on Ok button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo ,SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            return;
        }
        /// <summary>
        /// Edit Alert events configuration in system configuration
        /// </summary>
        /// <param name="checkDisplaypopup">Input:True to enable checkbox, False to disable checkbox</param>
        [UserCodeMethod]
        public static void NS_EditAlertPopups_AlertEventConfig(bool checkDisplaypopup)
        {
            //int checkBoxCount = 0;
            
            //Open alert events configuration from main menu
            NS_OpenAlertEventsConfiguration_MainMenu();
            
            //click on alert event level configuration tab
            SystemConfigurationrepo.Alert_Events_Configuration.AlertEventsConfigurationTabs.AlertEventLevelConfigurationTab.Click();
            
            int numberOfPopups = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} display pop up in the alert event level configuration table.", numberOfPopups.ToString()));
            
            for (int i = 0; i < numberOfPopups; i++)
            {
                SystemConfigurationrepo.AlertEventLevelIndex = i.ToString();
                string chkBoxStatus = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.GetAttributeValue<string>("Text");
                Ranorex.Report.Info("chkBoxStatus for " +i.ToString()+ " is " + chkBoxStatus);
                
                if(!(chkBoxStatus.Equals(checkDisplaypopup)))
                {
                    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.Click();
                }
                
                //checkBoxCount++;
            }
            
            //Click on apply button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo, SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo);
            
            //Click on ok button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo, SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
            Ranorex.Report.Info("Alert Display pop up checkbox are set to " +checkDisplaypopup);
        }
        
        /// <summary>
        /// To set value for Time values in TrainSheet Configrable Parameter Form
        /// </summary>
        /// <param name="terminateTrainTimeWithCrewTieUp">Input: Time to be set for Terminate Train Time With Crew Tie-up field</param>
        /// <param name="terminateTrainTimeWithOutCrewTieUp">Input: Time to be set for Terminate Train Time Without Crew Tie-up field</param>
        /// <param name="terminateTrainTimeWithUnknownTrainLocation">Input: Time to be set for Terminate Train Time With Unknown Train Location field</param>
        /// <param name="removePlanDataOlderThan">Input: Time to be set for Remove plan data older than field</param>
        [UserCodeMethod]
        public static void NS_TrainSheetConfigurableParameters_TrainSheet_SetTimeValues(string terminateTrainTimeWithCrewTieUp, string terminateTrainTimeWithOutCrewTieUp, string terminateTrainTimeWithUnknownTrainLocation, string removePlanDataOlderThan)
        {
            //Open System Configuration
            MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            // Set Terminate train with crew tie-up Value
            if( terminateTrainTimeWithCrewTieUp != "")
            {
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.Click();
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys(terminateTrainTimeWithCrewTieUp);
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys("{TAB}");
                NS_TrainSheetConfigurableParameters_Feedback(terminateTrainTimeWithCrewTieUp);
            }
            // Set Terminate train without crew tie-up value
            if( terminateTrainTimeWithOutCrewTieUp != "")
            {
                //	SystemConfigurationrepo.TrainSheet_Parameters.TrainSheetConfigurationParameters.TrainSheet.TimeValuesBox.Terminate_Train_Time_without_crew_Field.Click();
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithoutCrewTieUpText.PressKeys(terminateTrainTimeWithOutCrewTieUp);
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys("{TAB}");
                NS_TrainSheetConfigurableParameters_Feedback(terminateTrainTimeWithOutCrewTieUp);
            }
            // Set Terminate Train time with unknown train location value
            if( terminateTrainTimeWithUnknownTrainLocation != "")
            {
                //	SystemConfigurationrepo.TrainSheet_Parameters.TrainSheetConfigurationParameters.TrainSheet.TimeValuesBox.TerminateTrainTimeWithUnknownTrainlocation.Click();
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithUnknownTrainLocationText.PressKeys(terminateTrainTimeWithUnknownTrainLocation);
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys("{TAB}");
                NS_TrainSheetConfigurableParameters_Feedback(terminateTrainTimeWithUnknownTrainLocation);
            }
            // Set Remove Plan Data Older Than value
            if( removePlanDataOlderThan != "" )
            {
                //	SystemConfigurationrepo.TrainSheet_Parameters.TrainSheetConfigurationParameters.TrainSheet.TimeValuesBox.RemovePlandata_Time_Field.Click();
                SystemConfigurationrepo.Train_Sheet_Parameters.RemovePlanDataOlderThanText.PressKeys(removePlanDataOlderThan);
                SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys("{TAB}");
                NS_TrainSheetConfigurableParameters_Feedback(removePlanDataOlderThan);
            }
            // Click on Apply button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
            // Click on OK button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.OkButtonInfo, MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo);
            return;
        }
        
        /// <summary>
        /// Check the feedback in Tracking Configrable Parameter Form
        /// </summary>
        /// <param name="labelName">Input:labelName :ex:timerOccupancy/timerUnoccupancy</param>
        public static void NS_TrackingConfigurableParameters_Feedback(string labelName)
        {
            string feedback = SystemConfigurationrepo.Tracking_Parameters.Feedback.GetAttributeValue<string>("Text");
            if(feedback=="")
            {
                Ranorex.Report.Success("Train Status Summary Inclusion Intervals  '"+labelName+"' has been set  ");
            }
            else
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo, SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                Ranorex.Report.Failure("Value passed was not in format");
            }
        }
        
        /// <summary>
        /// To select the Type of Trackline coloration inside Define Trackline Display popup and change the color
        /// </summary>
        /// <param name="colorOfTrackLineColorationType">Input:colorOfTrackLineColorationType :ex:ColorWhenPending/ColorWhenEffective/ColorOfTracks</param>
        /// <param name="color">Input:color ex:Do not show/Pink/Yellow/Orange</param>
        public static void NS_DefineTrackLineDisplay(string trackLineColorationType, string color)
        {
            switch(trackLineColorationType.ToLower())
            {
                    
                case "colorwhenpending":
                    if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenPending.ColorWhenPendingText.GetAttributeValue<string>("SelectedItemText").Contains(color)) {
                        Ranorex.Report.Info("TestStep", "Selecting Color as {"+color+"}.");
                        SystemConfigurationrepo.Color = color;
                        //Clicking on the Color when pending dropdown
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenPending.ColorWhenPendingText.Click();
                        //Selecting the Color
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenPending.ColorWhenPendingList.ColorWhenPendingListItemByColor.Click();
                    }
                    break;
                    
                case "colorwheneffective":
                    if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenEffective.ColorWhenEffectiveText.GetAttributeValue<string>("SelectedItemText").Contains(color)) {
                        Ranorex.Report.Info("TestStep", "Selecting Color as {"+color+"}.");
                        SystemConfigurationrepo.Color = color;
                        //Clicking on the Color when effective dropdown
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenEffective.ColorWhenEffectiveText.Click();
                        //Selecting the Color
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorWhenEffective.ColorWhenEffectiveList.ColorWhenPendingListItemByColor.Click();
                    }
                    break;
                    
                case "coloroftracks":
                    if (!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorOfTracks.ColorOfTracksText.GetAttributeValue<string>("SelectedItemText").Contains(color)) {
                        Ranorex.Report.Info("TestStep", "Selecting Color as {"+color+"}.");
                        SystemConfigurationrepo.Color = color;
                        //Selecting the Color of tracks dropdown
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorOfTracks.ColorOfTracksText.Click();
                        //Selecting the Color
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.ColorOfTracks.ColorOfTracksList.ColorWhenPendingListItemByColor.Click();
                    }
                    break;
                    
                default:
                    Ranorex.Report.Error("Invalid Trackline coloration Type specified");
                    break;
            }
            return;
        }
        
        /// <summary>
        /// To select the Type of Trackline coloration inside Define Trackline Display popup and change the color
        /// </summary>
        /// <param name="colorOfTrackLineColorationType">Input:colorOfTrackLineColorationType :ex:ColorWhenPending/ColorWhenEffective/ColorOfTracks</param>
        /// <param name="color">Input:color ex:Do not show/Pink/Yellow/Orange</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_EditDefineTracklineDisplayForm_BulletinItemsForm(string bulletinName, string trackLineColorationType, string color, string changeType, string setPriority, string newLabel, bool closeBulletinItemsForm = true, bool applyDefineTracklineDisplayChanges = true)
        {
            //Opens Bulletin items form and select the bulletin of type bulletinName
            NS_OpenBulletinItems_MainMenu();
            NS_SetBulletinType_BulletinItemsForm(bulletinName);
            
            //Cheks whether the Bulletin Items form is Open or not
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //Checking whether the 'Define' button is in enabled State
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.DisplayOnTrackline.DefineButton.Enabled)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.DisplayOnTrackline.DefineButtonInfo,
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.SelfInfo
                       );
                    
                    switch(changeType.ToLower())
                    {
                            case "tracklinecoloration" :NS_DefineTrackLineDisplay(trackLineColorationType, color); //Calling the function to change the color for track line coloration
                            break;
                            
                            case "priorityofbulletins" :NS_SetPriorityForBulletin_DefineTracklineDisplay_BulletinItemsForm(bulletinName, setPriority);
                            break;
                            
                            case "labelofbulletins" :NS_SetBulletinLabel_DefineTracklineDisplay_BulletinItemsForm(bulletinName, newLabel);
                            break;
                            
                            default :Ranorex.Report.Failure("Inavalid selection to change the properties of bulletin in Define Trackline Display form");
                            break;
                    }
                }
                else
                {
                    Report.Error("The Define button is disabled, and could not be pressed.");
                    Ranorex.Report.Screenshot(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.Self);
                }
                
                //To Close the Define Trackline Display Form
                if(applyDefineTracklineDisplayChanges)
                {
                    //Press on Ok button
                    if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.OkButton.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.OkButtonInfo,
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.SelfInfo
                           );
                    }
                    else
                    {
                        Ranorex.Report.Failure("'OK' button is in disabled state");
                        Ranorex.Report.Screenshot(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.Self);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.CancelButtonInfo,
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.SelfInfo
                           );
                    }
                }
                else
                {
                    //Press on Cancel button
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.CancelButtonInfo,
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.SelfInfo
                       );
                    
                }
                
                
                //Clicks on 'Applay' button inside 'Bulletin Items  Configuration Form'
                if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo
                       );
                }
                
                
                //Clicks on 'Cancel' button inside 'Bulletin Items  Configuration Form'
                if (closeBulletinItemsForm)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo,
                        SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo
                       );
                }
            }
            else
            {
                Ranorex.Report.Failure("The bulletin Items form is not opened");
            }
            
        }
        /// <summary>
        /// To Insert row to configure station pair Form
        /// </summary>
        /// <param name="cutoverOpsta">Input:cutoverOpsta </param>
        /// <param name="linkedOpsta">Input:linkedOpsta</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_StationPair(string cutoverOpsta, string linkedOpsta, bool reset, bool apply, string expectedFeedback, bool closeForm)
        {
            int startIndex = 0;
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.StationPairListInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            
            // Verifying Form exist or not
            if (SystemConfigurationrepo.Station_Pair_List.SelfInfo.Exists(0))
            {
                int rowCount = SystemConfigurationrepo.Station_Pair_List.StationPairTable.Self.Rows.Count;
                
                SystemConfigurationrepo.StationPairIndex = startIndex.ToString();
                SystemConfigurationrepo.Station_Pair_List.InsertRowButton.Click();
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.Click();
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.PressKeys(cutoverOpsta);
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Station_Pair_List.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Station_Pair_List.CancelButton.Click();
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
                    }
                    return;
                }
                
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.Click();
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.PressKeys(linkedOpsta);
                SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Station_Pair_List.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
                    }
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("Station Pair List Form does not exist");
                Ranorex.Report.Screenshot("Unable to find the Station_Pair_List form to insert the new row", SystemConfigurationrepo.Station_Pair_List.Self.Element);
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Station_Pair_List.ResetButtonInfo, SystemConfigurationrepo.Station_Pair_List.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo, SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo);
                Ranorex.Report.Info("Added Opsta: cutoverOpsta value as {" + cutoverOpsta + "} and LinkedOpsta value as {" + linkedOpsta + "} ");
            }
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo, SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Delete row from configure station pair Form
        /// </summary>
        /// <param name="cutoverOpsta">Input:cutoverOpsta </param>
        /// <param name="linkedOpsta">Input:linkedOpsta</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteRowByOpstas_StationPair(string cutoverOpsta, string linkedOpsta ,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.StationPairListInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            int rowCount = SystemConfigurationrepo.Station_Pair_List.StationPairTable.Self.Rows.Count;
            bool foundOpsta = false;
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.StationPairIndex = i.ToString();
                string currentCutoverOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.GetAttributeValue<string>("Text");
                string currentLinkedOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.GetAttributeValue<string>("Text");
                
                if ((cutoverOpsta == currentCutoverOpsta) && (linkedOpsta == currentLinkedOpsta))
                {
                    foundOpsta = true;
                    break;
                }
            }
            if (!foundOpsta)
            {
                Ranorex.Report.Failure("Could not find row with opsta {" + cutoverOpsta + "} and {" + linkedOpsta + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the Opsta value in the form", SystemConfigurationrepo.Station_Pair_List.Self.Element);
            } else {
                GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.MenuCellInfo,
                                                               SystemConfigurationrepo.Station_Pair_List.StationPairTable.MenuCellMenu.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.StationPairTable.MenuCellMenu.DeleteRowInfo,
                                                                  SystemConfigurationrepo.Station_Pair_List.StationPairTable.MenuCellMenu.SelfInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo,
                                                                                      SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo);
                Ranorex.Report.Info("Row got deleted Successfully , Deleted Opsta: cutoverOpsta value = {" + cutoverOpsta + "} and LinkedOpsta value = {" + linkedOpsta + "} ");
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo, SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify row in configure station pair Form
        /// </summary>
        /// <param name="cutoverOpsta">Input:cutoverOpsta </param>
        /// <param name="linkedOpsta">Input:linkedOpsta</param>
        /// <param name="reset">Input:reset</param>
        [UserCodeMethod]

        public static void NS_ModifyRowByOpstas_StationPair(string cutoverOpsta, string newCutoverOpsta, string linkedOpsta, string newLinkedOpsta, string expectedFeedback,  bool clickApply, bool closeForms)

        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.StationPairListInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Station_Pair_List.StationPairTable.Self.Rows.Count;
            bool foundOpsta = false;
            string currentCutoverOpsta = "";
            string currentLinkedOpsta = "";
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.StationPairIndex = i.ToString();

                currentCutoverOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.GetAttributeValue<string>("Text");
                currentLinkedOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.GetAttributeValue<string>("Text");
                
                if (currentCutoverOpsta.Equals(cutoverOpsta,StringComparison.OrdinalIgnoreCase) && currentLinkedOpsta.Equals(linkedOpsta,StringComparison.OrdinalIgnoreCase))
                {
                    foundOpsta = true;
                    break;
                }
            }
            
            if (!foundOpsta)
            {
                Ranorex.Report.Failure("Could not find opsta {" + cutoverOpsta + "} and {" + linkedOpsta + "} to modify");
                Ranorex.Report.Screenshot("Unable to find the Opsta value in the form", SystemConfigurationrepo.Station_Pair_List.Self.Element);
            } else {
                if (!currentCutoverOpsta.Equals(newCutoverOpsta,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.DoubleClick();
                    Keyboard.Press("{BACK}");
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.PressKeys(newCutoverOpsta);
                    SystemConfigurationrepo.CutOverOPSTA=newCutoverOpsta;
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAList.CutoverOPSTAListItemByCutoverOPSTA.Click();
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.PressKeys("{TAB}");
                    //Check if this kicked up some FeedBack
                    if (!CheckFeedback(SystemConfigurationrepo.Station_Pair_List.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Station_Pair_List.CancelButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Station_Pair_List.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the cutoverOpsta value from {" + cutoverOpsta + "}  to {" + newCutoverOpsta + "}" );
                } else {
                    Ranorex.Report.Info("Cutover Opsta already set to {" + newCutoverOpsta + "}.");
                }
                
                if (!currentLinkedOpsta.Equals(newLinkedOpsta,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.DoubleClick();
                    Keyboard.Press("{BACK}");
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.PressKeys(newLinkedOpsta);
                    SystemConfigurationrepo.LinkedOPSTA=newLinkedOpsta;
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAList.LinkedOPSTAListItemByLinkedOPSTA.Click();
                    SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some FeedBack
                    if (!CheckFeedback(SystemConfigurationrepo.Station_Pair_List.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Station_Pair_List.CancelButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Station_Pair_List.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the linkedOpsta value from {" + linkedOpsta + "}  to {" + newLinkedOpsta + "}" );
                } else {
                    Ranorex.Report.Info("Linked Opsta already set to {" + newLinkedOpsta + "}.");
                }
            }
            
            if (clickApply)
            {
                SystemConfigurationrepo.Station_Pair_List.ApplyButton.Click();
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Station_Pair_List.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Station_Pair_List.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
                    }
                    return;
                } else if (SystemConfigurationrepo.Station_Pair_List.ApplyButton.Enabled)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo, SystemConfigurationrepo.Station_Pair_List.ApplyButtonInfo);
                }
            }
            
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo, SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            }

        }
        
        /// <summary>
        /// To ValidateS row in configure station pair Form
        /// </summary>
        /// <param name="expectedcutoverOpsta">Input:expectedcutoverOpsta </param>
        /// <param name="expectedlinkedOpsta">Input:expectedlinkedOpsta</param>
        /// <param name="validateExist">Input:validateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void ValidateStationPairRowExistsByOpstas_StaionPair(string expectedcutoverOpsta, string expectedlinkedOpsta, bool expValidateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.StationPairListInfo,
                                                                          SystemConfigurationrepo.Station_Pair_List.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Station_Pair_List.StationPairTable.Self.Rows.Count;
            bool foundOpsta = false;
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.StationPairIndex = i.ToString();
                
                if (SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.SelfInfo.Exists(0))
                {
                    string currentCutoverOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.CutoverOPSTA.CutoverOPSTAText.GetAttributeValue<string>("Text");
                    string currentLinkedOpsta = SystemConfigurationrepo.Station_Pair_List.StationPairTable.StationPairRowByStationPairIndex.LinkedOPSTA.LinkedOPSTAText.GetAttributeValue<string>("Text");
                    
                    if (currentCutoverOpsta.Equals(expectedcutoverOpsta, StringComparison.OrdinalIgnoreCase) && currentLinkedOpsta.Equals(expectedlinkedOpsta, StringComparison.OrdinalIgnoreCase))
                    {
                        foundOpsta=true;
                        break;
                    }
                }
                
            }

            if(foundOpsta == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Station Pair List Row was found with the value as  {" + expectedcutoverOpsta + "} and {" + expectedlinkedOpsta + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected Station Pair List Row was not found with the value as  {" + expectedcutoverOpsta + "} and {" + expectedlinkedOpsta + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected Station Pair List Row was not found with the value as  {" + expectedcutoverOpsta + "} and {" + expectedlinkedOpsta + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Station Pair List Row was found with the value as  {" + expectedcutoverOpsta + "} and {" + expectedlinkedOpsta + "}");
                }
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Station_Pair_List.CancelButtonInfo, SystemConfigurationrepo.Station_Pair_List.SelfInfo);
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
        
        [UserCodeMethod]
        public static void NS_CheckOrUncheck_DisplayOnTrackline_BulletinItemsForm(string bulletinName, bool checkDisplayOnTrackline, bool pressApply = false)
        {
            //Opens Bulletin items form and select the bulletin of type bulletinName
            NS_OpenBulletinItems_MainMenu();
            string actBulletinName = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("Text");
            if (!actBulletinName.Equals(bulletinName))
            {
            	NS_SetBulletinType_BulletinItemsForm(bulletinName);
            }
            //Cheks whether the Bulletin Items form is Open or not
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
            {
                //To check or uncheck the 'Display on trackline' checkbox
                if (checkDisplayOnTrackline != SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.DisplayOnTrackline.DisplayOnTracklineCheckbox.Checked)
                {
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.DisplayOnTrackline.DisplayOnTracklineCheckbox.Click();
                    
                    if (checkDisplayOnTrackline != SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.DisplayOnTrackline.DisplayOnTracklineCheckbox.Checked)
                    {
                        Ranorex.Report.Error("Unable to transition Display On Trackline Checkbox to " + checkDisplayOnTrackline);
                    }
                    else
                    {
                        Ranorex.Report.Info("Switched Display on Trackline Checkbox to " + checkDisplayOnTrackline);
                    }
                }
                else
                {
                    Ranorex.Report.Info("Switched Display on Trackline Checkbox already set to " + checkDisplayOnTrackline);
                }
                
                
                //Clicks on 'Apply' button inside 'Bulletin Items  Configuration Form'
                if(pressApply)
                {
                    if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo);
                    }
                }
            }
            else
            {
                Ranorex.Report.Failure("The bulletin Items form is not opened");
            }
        }
        
        /// <summary>
        /// Changes the priority for specific bulletins
        /// </summary>
        /// <param name="bulletinName">Input:bulletinName</param>
        /// <param name="setPriority">Input:High/Low</param>
        public static void NS_SetPriorityForBulletin_DefineTracklineDisplay_BulletinItemsForm(string bulletinName, string setPriority)
        {
            SystemConfigurationrepo.BulletinName = bulletinName;
            SystemConfigurationrepo.BulletinIndex = "0";
            //Checks whether the Define Trackline Display Form still open
            if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.BulletinTypeList.BulletinTypeListItemByBulletinNameInfo,
                    SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.BulletinTypeList.BulletinTypeListItemByBulletinNameInfo
                   );
                
                //Get the row counts in the list
                int rowCount = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.BulletinTypeList.Self.Items.Count;
                
                if((setPriority.ToLower()).Equals("high"))
                {
                    SystemConfigurationrepo.BulletinIndex = "0";
                    //clicks on Up arrow button utill the bulletin sets on high priority
                    for(int i = 0; i < rowCount+1; i++)
                    {
                        string currentPriorityBulletinName = (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.BulletinTypeList.BulletinTypeListItemByBulletinIndex).ToString();
                        
                        if(!currentPriorityBulletinName.Contains(bulletinName))
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.MoveUpButton.Click();
                        }
                        else
                        {
                            Ranorex.Report.Info("Bulletin {"+bulletinName+"} has set to highest priority");
                            return;
                        }
                    }
                }
                //clicks on Down arrow button utill the bulletin sets on Low priority
                else if((setPriority.ToLower()).Equals("low"))
                {
                    SystemConfigurationrepo.BulletinIndex = (rowCount-1).ToString();
                    for(int i = 0; i < rowCount; i++)
                    {
                        string currentPriorityBulletinName = (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.BulletinTypeList.BulletinTypeListItemByBulletinIndex).ToString();
                        
                        if(!currentPriorityBulletinName.Contains(bulletinName))
                        {
                            SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.MoveDownButton.Click();
                        }
                        else
                        {
                            Ranorex.Report.Info("Bulletin {"+bulletinName+"} has set to Lowest priority");
                            return;
                        }
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Invalid Priority Type");
                }
                
            }
            else
            {
                Ranorex.Report.Failure("The Define Trackline display Form is not opened");
            }
        }
        
        /// <summary>
        /// Changes the label for specific bulletins
        /// </summary
        /// <param name="newLabel">Input: newLabel</param>>
        public static void NS_SetBulletinLabel_DefineTracklineDisplay_BulletinItemsForm(string bulletinName, string newLabel)
        {
            if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.LabelNameText.Enabled)
            {
                Ranorex.Report.Info("TestStep", "Setting bulletin: {"+bulletinName+"} label as {"+newLabel+"}.");
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.LabelNameText.Element.SetAttributeValue("Text", newLabel);
                SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Define_Trackline_Display.LabelNameText.PressKeys("{TAB}");
            }
            else
            {
                Ranorex.Report.Failure("Label Text field is in disabled state unable to enter text");
            }
            return;
        }
        /// <summary>
        /// To Insert row to PrintFaxRecipients Form
        /// </summary>
        /// <param name="recipientName">Input:recipientName </param>
        /// <param name="address">Input:address</param>
        /// <param name="type">Input:type</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_Recipients_PrintFaxRecipients(string recipientName,string address ,string type, bool reset, bool apply, string expectedFeedback, bool closeForms)
        {
            int startIndex = 0;
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            
            // Verifying Recipients Tab  exist or not in Print_Fax_Recipients Form
            if (SystemConfigurationrepo.Print_Fax_Recipients.Recipients.SelfInfo.Exists(0))
            {
                int rowcount = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.Self.Rows.Count;
                
                int retries=0;
                SystemConfigurationrepo.RecipientsIndex = startIndex.ToString();
                
                SystemConfigurationrepo.Print_Fax_Recipients.InsertRowButton.Click();
                int newRowCount = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.Self.Rows.Count;
                
                while (rowcount == newRowCount && retries < 3)
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.InsertRowButton.Click();
                    newRowCount = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.Self.Rows.Count;
                    retries++;
                }
                
                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.RecipientName.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.RecipientName.PressKeys(recipientName);
                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.RecipientName.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }

                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Address.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Address.PressKeys(address);
                SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Address.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
                
                SystemConfigurationrepo.Type=type;
                
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByRecipientName.Type.TypeTextInfo,
                                                          SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByRecipientName.Type.TypeList.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByRecipientName.Type.TypeList.TypeListItemByTypeNameInfo,
                                                                  SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByRecipientName.Type.TypeList.SelfInfo);
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("Recipients Tab under Print/Fax Recipients Form does not exist");
                Ranorex.Report.Screenshot("Unable to find the Recipients Tab under Print/Fax Recipients form to insert the new row", SystemConfigurationrepo.Print_Fax_Recipients.Recipients.Self.Element);
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ResetButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo, SystemConfigurationrepo	.Print_Fax_Recipients.ApplyButtonInfo);
                Ranorex.Report.Info("Row inserted successfully to Recipients Tab under Print/Fax Recipients Form with the Value:- RecipientName as {" + recipientName + "} , Address as {" + address + "} and  Type as {" + type + "}");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }


        /// <summary>
        /// To Delete row from configure Print Fax Recipients Form
        /// </summary>
        /// <param name="recipientName">Input:recipientName </param>
        /// <param name="address">Input:address</param>
        /// <param name="type">Input:type</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteRowByRecipientName_Recipients_Print_Fax_Recipients(string recipientName, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);

            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            
            int rowcount = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.Self.Rows.Count;
            
            bool foundrecipientName = false;
            for (int rowIndex = 0; rowIndex < rowcount; rowIndex++)
            {
                SystemConfigurationrepo.RecipientsIndex = rowIndex.ToString();
                
                string currentRecipientName = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.RecipientName.GetAttributeValue<string>("Text");

                if (currentRecipientName == recipientName)
                {
                    foundrecipientName = true;
                    SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Self.EnsureVisible();

                    if(SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.MenuCellMenu.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.MenuCellMenu.SelfInfo);
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo);
                        Ranorex.Report.Info("Row got deleted Successfully from  Print/Fax Recipients form  , Deleted Value are: RecipientName as {" + recipientName + "}");
                        break;
                    }
                }
            }
            
            if (!foundrecipientName)
            {
                Ranorex.Report.Failure("Could not find row with RecipientName as {" + recipientName + "}  to delete");
                Ranorex.Report.Screenshot("Unable to find the row in the Print/Fax Recipients form", SystemConfigurationrepo.Print_Fax_Recipients.Self.Element);
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To ValidateS row in Print Fax Recipients Form
        /// </summary>
        /// <param name="expectedRecipientName">Input:expectedRecipientName </param>
        /// <param name="expectedAddress">Input:expectedAddress</param>
        /// <param name="expectedType">Input:expectedType</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateRowExistsByRecipientName_Recipients_PrintFaxRecipients(string expectedRecipientName,string expectedAddress, string expectedType ,bool expValidateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            int rowcount = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.Self.Rows.Count;
            bool foundrecipientName = false;
            
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.RecipientsIndex=i.ToString();
                
                if (SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.SelfInfo.Exists(0))
                {
                    string currentRecipientName = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.RecipientName.GetAttributeValue<string>("Text");
                    string currentAddress = SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Address.GetAttributeValue<string>("Text");
                    string currentType= SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Type.TypeText.GetAttributeValue<string>("Text");
                    
                    SystemConfigurationrepo.Print_Fax_Recipients.Recipients.RecipientsTable.RecipientsRowByIndex.Self.EnsureVisible();
                    
                    if (currentRecipientName.Equals(expectedRecipientName, StringComparison.OrdinalIgnoreCase) && currentAddress.Equals(expectedAddress, StringComparison.OrdinalIgnoreCase) && currentType.Equals(expectedType, StringComparison.OrdinalIgnoreCase))
                    {
                        foundrecipientName=true;
                        break;
                    }
                }
            }
            if(foundrecipientName == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Recipients row in Print/Fax Recipients Form  was found with the value as  {" + expectedRecipientName + "}, {" + expectedAddress + "} and {" + expectedType + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected Recipients row in Print/Fax Recipients Form not found with the value as  {" + expectedRecipientName + "}, {" + expectedAddress + "} and {" + expectedType + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected Recipients row in Print/Fax Recipients Form was not found with the value as  {" + expectedRecipientName + "}, {" + expectedAddress + "} and {" + expectedType + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Recipients row in Print/Fax Recipients Form was found with the value as  {" + expectedRecipientName + "}, {" + expectedAddress + "} and {" + expectedType + "}");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To Insert row under train clearance table in PrintFaxRecipients Form
        /// </summary>
        /// <param name="CrewChangeOpSta">Input:CrewChangeOpSta </param>
        /// <param name="RouteOpSta">Input:RouteOpSta</param>
        /// <param name="SCAC">Input:SCAC</param>
        /// <param name="DistributionList">Input:DistributionList</param>
        /// <param name="Division">Input:Division</param>
        /// <param name="DispatchTerritory">Input:DispatchTerritory</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_TrainClearance_PrintFaxRecipients(string CrewChangeOpSta,string RouteOpSta,string SCAC,string DistributionList,string Division,string DispatchTerritory,string expectedFeedback,bool reset, bool apply, bool closeForm)
        {
            int startIndex = 0;
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            

            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.TrainClearanceTabInfo,SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.SelfInfo);
            
            if (SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.SelfInfo.Exists(0))
            {
                int rowCount = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.Self.Rows.Count;
                int retries=0;
                SystemConfigurationrepo.TrainClearanceIndex=startIndex.ToString();
                
                SystemConfigurationrepo.Print_Fax_Recipients.InsertRowButton.Click();
                int newRowCount = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.Self.Rows.Count;
                
                while (rowCount == newRowCount && retries < 3)
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.InsertRowButton.Click();
                    newRowCount = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.Self.Rows.Count;
                    retries++;
                }
                
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.CrewChangeOpSta.CrewChangeOpStaText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.CrewChangeOpSta.CrewChangeOpStaText.PressKeys(CrewChangeOpSta);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.CrewChangeOpSta.CrewChangeOpStaText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
                
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.RouteOpSta.RouteOpStaText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.RouteOpSta.RouteOpStaText.PressKeys(RouteOpSta);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.RouteOpSta.RouteOpStaText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
                // this allows null values so no need to check feedback
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.SCAC.SCACText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.SCAC.SCACText.PressKeys(SCAC);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.SCAC.SCACText.PressKeys("{TAB}");
                

                
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DistributionList.DistributionListText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DistributionList.DistributionListText.PressKeys(DistributionList);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DistributionList.DistributionListText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
                
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.Division.DivisionText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.Division.DivisionText.PressKeys(Division);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.Division.DivisionText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
                
                
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DispatchTerritory.DispatchTerritoryText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DispatchTerritory.DispatchTerritoryText.PressKeys(DispatchTerritory);
                SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.DispatchTerritory.DispatchTerritoryText.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.ResetButton.Click();
                    if (SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                    }
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                    }
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Tab  does not exist under Print/Fax Recipients Form");
                Ranorex.Report.Screenshot("Unable to find the Train Clearance Tab under Print/Fax Recipients Form to insert the new row", SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.Self.Element);
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ResetButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.ResetButtonInfo);
            }
            
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo);
                Ranorex.Report.Info("Added Opsta: CrewChangeOpSta value as {" + CrewChangeOpSta + "} , RouteOpSta value as {" + RouteOpSta + "}, SCAC value as {" + SCAC + "}, DistributionList value as {" + DistributionList + "}," +
                                    "Division value as {" + Division + "}and DispatchTerritory value as {" + DispatchTerritory + "}  added to the Train Clearance tab under Print/Fax Recipients Form ");
            }
            
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To Delete row from TrainClearance_PrintFaxRecipients
        /// </summary>
        /// <param name="CrewChangeOpSta">Input:CrewChangeOpSta </param>
        /// <param name="RouteOpSta">Input:RouteOpSta</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteRow_TrainClearance_PrintFaxRecipients(string CrewChangeOpSta,string RouteOpsta,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.TrainClearanceTabInfo,SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.SelfInfo);

            int rowCount = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.Self.Rows.Count;
            
            bool rowExist = false;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                SystemConfigurationrepo.TrainClearanceIndex = rowIndex.ToString();
                
                string current_CrewChangeOpSta = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.CrewChangeOpSta.CrewChangeOpStaText.GetAttributeValue<string>("Text");
                string current_RouteOpSta = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.RouteOpSta.RouteOpStaText.GetAttributeValue<string>("Text");
                
                if (current_CrewChangeOpSta == CrewChangeOpSta && current_RouteOpSta == RouteOpsta)
                {
                    SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.Self.EnsureVisible();
                    rowExist = true;
                    
                    if (SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.MenuCellMenu.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.MenuCellMenu.SelfInfo);
                        
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo);
                        Ranorex.Report.Info("Row got deleted Successfully , Deleted Value are: CrewChangeOpSta value as {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpsta + "} in Train Clearance tab under Print/Fax Recipients Form ");
                        break;
                    }
                }
            }
            if (!rowExist)
            {
                Ranorex.Report.Failure("Could not find row with the value : CrewChangeOpSta value as {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpsta + "}  in Train Clearance tab under Print/Fax Recipients Form ");
                Ranorex.Report.Screenshot("Unable to find the row in the Train Clearance tab under Print/Fax Recipients form", SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.Self.Element);
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To ValidateS row in Print Fax Recipients Form
        /// </summary>
        /// <param name="CrewChangeOpSta">Input:CrewChangeOpSta </param>
        /// <param name="RouteOpSta">Input:RouteOpSta</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateRowExists_TrainClearance_PrintFaxRecipients(string CrewChangeOpSta,string RouteOpSta, bool expValidateExist,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.TrainClearanceTabInfo,SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.SelfInfo);

            int rowCount = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.Self.Rows.Count;
            bool actValidateExist = false;
            
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                SystemConfigurationrepo.TrainClearanceIndex = rowIndex.ToString();

                if (SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.SelfInfo.Exists(0))
                {
                    string current_CrewChangeOpSta = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.CrewChangeOpSta.CrewChangeOpStaText.GetAttributeValue<string>("Text");
                    string current_RouteOpSta = SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.RouteOpSta.RouteOpStaText.GetAttributeValue<string>("Text");
                    
                    if (current_CrewChangeOpSta == CrewChangeOpSta && current_RouteOpSta == RouteOpSta)
                    {
                        SystemConfigurationrepo.Print_Fax_Recipients.TrainClearance.TrainClearanceTable.TrainClearanceRowByIndex.Self.EnsureVisible();
                        actValidateExist=true;
                        break;
                    }
                }
            }
            if (actValidateExist == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Train Clearance Row in Print/Fax Recipients Form was found with the value as  {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpSta + "} ");
                }
                else
                {
                    Ranorex.Report.Success("Expected Train Clearance Row in Print/Fax Recipients Form was not found with the value as  {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpSta + "} ");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected Train Clearance Row in Print/Fax Recipients Form was found with the value as  {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpSta + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Train Clearance Row in Print/Fax Recipients Form was not found with the value as  {" + CrewChangeOpSta + "}, RouteOpSta value as {" + RouteOpSta + "} ");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To Insert row under train clearance table in PrintFaxRecipients Form
        /// </summary>
        /// <param name="DistributionListName">Input:DistributionListName </param>
        /// <param name="expAvailableRecipient">Input:expAvailableRecipient</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_AddDistributionList_DistributionLists_Print_Fax_Recipients(string distributionListName, string expAvailableRecipient, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                      MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                      SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.DistributionListsTabInfo,
                                                      SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.SelfInfo);

            
            if (SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.SelfInfo.Exists(0))
            {
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.PressKeys(distributionListName);
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.PressKeys("{TAB}");
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.CreateButtonInfo,
                                                                                     SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AvailableRecipientsTable.SelfInfo);
                
                
                int rowcount = SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AvailableRecipientsTable.Self.Rows.Count;
                string[] availableRecipient  = expAvailableRecipient.Split('|');
                for(int j=0; j < availableRecipient.Length; j++)
                {
                    SystemConfigurationrepo.AvailableRecipient = availableRecipient[j];
                    if (!SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AvailableRecipientsTable.AvailableRecipientsRowByAvailableRecipient.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Could not find Recipient {" + availableRecipient[j] + "} in available recipients list");
                    } else {
                        SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AvailableRecipientsTable.AvailableRecipientsRowByAvailableRecipient.Self.EnsureVisible();
                        SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AvailableRecipientsTable.AvailableRecipientsRowByAvailableRecipient.AvailableRecipient.Click();
                        SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.AddButton.Click();
                        
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Print_Fax_Recipients.Feedback, expectedFeedback))
                        {
                            SystemConfigurationrepo.Print_Fax_Recipients.CancelButton.Click();
                            if (closeForm)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
                            }
                            return;
                        }
                    }
                }
            }
            else
            {
                Ranorex.Report.Failure("DistributionLists Tab is not visible in Print/Fax Recipients Form");
                Ranorex.Report.Screenshot("Unable to find DistributionList in Print/Fax Recipients Form",SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.Self.Element);
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ResetButtonInfo,
                                                                              SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.YesButtonInfo,
                                                                  SystemConfigurationrepo.Print_Fax_Recipients.Reset_Forms_Content.SelfInfo);
            }
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo);
                Ranorex.Report.Info("Added AvailableRecipients to DistributionList in Print/Fax Recipients Form " +
                                    "successfully with the value as {" + expAvailableRecipient + "}");
                
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To Delete DistributionList in DistributionLists under PrintFaxRecipients Form
        /// </summary>
        /// <param name="DistributionListName">Input:DistributionListName </param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteDistributionList_DistributionLists_Print_Fax_Recipients(string distributionListName,bool apply,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.DistributionListsTabInfo,SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.SelfInfo);

            
            if (SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameTextInfo.Exists(0))
            {
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.Click();
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.PressKeys(distributionListName);
                SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText.PressKeys("{TAB}");
                
                
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DeleteButtonInfo,
                                                                              SystemConfigurationrepo.Print_Fax_Recipients.Delete_Forms_Content.SelfInfo);
                if ( SystemConfigurationrepo.Print_Fax_Recipients.Delete_Forms_Content.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.Delete_Forms_Content.YesButtonInfo,SystemConfigurationrepo.Print_Fax_Recipients.Delete_Forms_Content.SelfInfo);
                }
            }
            else
            {
                Ranorex.Report.Failure("Could not find  the  DistributionListName in DistributionList in Print/Fax Recipients Form");
                Ranorex.Report.Screenshot("Unable to find DistributionListName in DistributionList in Print/Fax Recipients Form",SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameText);
            }
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.ApplyButtonInfo);
                Ranorex.Report.Info("Deleted DistributionListName successfully with the value as {" + distributionListName + "}");
                
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate DistributionListName in DistributionLists under PrintFaxRecipients Form
        /// </summary>
        /// <param name="DistributionListName">Input:DistributionListName </param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateDistributionList_DistributionLists_Print_Fax_Recipient(string distributionListName, bool expValidateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PrintFaxRecipientsInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.PrintFaxRecipientsTabs.DistributionListsTabInfo,
                                                      SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.SelfInfo);

            bool actValidateExist = false;
            
            SystemConfigurationrepo.DistributionListName = distributionListName;
            
            //SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameMenuButton.Click();
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameMenuButtonInfo,
                                                                          SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameList.SelfInfo);
            
            SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameMenuButton.EnsureVisible();
            
            if(SystemConfigurationrepo.Print_Fax_Recipients.DistributionLists.DistributionListName.DistributionListNameList.DistributionListNameListItemByNameInfo.Exists(0))
            {
                actValidateExist= true;
            }
            
            if (actValidateExist == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected DistributionListName  in Print/Fax Recipients Form was found with the value as  {" + distributionListName + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected DistributionListName  does not exist in Print/Fax Recipients Form with the value as  {" + distributionListName + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected DistributionListName  in Print/Fax Recipients Form was found with the value as  {" + distributionListName + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected DistributionListName  does not exist in Print/Fax Recipients Form with the value as  {" + distributionListName + "}");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Print_Fax_Recipients.CancelButtonInfo, SystemConfigurationrepo.Print_Fax_Recipients.SelfInfo);
            }
        }
        /// To Modify row in configure station pair Form
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="minimumCrewMembers">Input:minimumCrewMembers</param>
        /// <param name="engineAtDeparture">Input:engineAtDeparture</param>
        /// <param name="engineAtArrival">Input:engineAtArrival</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyCrewandEngineData_TrainSheetParameter(string trainGroup, string minimumCrewMembers, bool engineAtDeparture, bool engineAtArrival, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.Self.Rows.Count;
            string current_TrainGroup="";
            string current_MinimumCrewMembers ="";
            bool current_EngineAtDeparture= true;
            bool current_EngineAtArrival = true;
            bool foundTrainGroup = false;
            
            for(int i=0; i < rowCount ;  i++)
            {
                SystemConfigurationrepo.RequiredCrewEngineDataIndex = i.ToString();
                SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.Self.EnsureVisible();
                current_TrainGroup = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.TrainGroup.GetAttributeValue<string>("Text");
                
                if (trainGroup.Equals(current_TrainGroup,StringComparison.OrdinalIgnoreCase))
                {
                    foundTrainGroup = true;
                    current_MinimumCrewMembers = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersText.GetAttributeValue<string>("Text");
                    current_EngineAtDeparture = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureText.GetAttributeValue<bool>("Text");
                    current_EngineAtArrival = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalText.GetAttributeValue<bool>("Text");
                    break;
                }
            }
            if(!foundTrainGroup)
            {
                Ranorex.Report.Failure("Could not find TrainGroup {" + trainGroup + "} to modify");
                Ranorex.Report.Screenshot("Unable to find the trainGroup value in the form", SystemConfigurationrepo.Train_Sheet_Parameters.Self.Element);
            }
            else
            {
                if(!current_MinimumCrewMembers.Equals(minimumCrewMembers,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.CrewMembers = minimumCrewMembers;
                    
                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersTextInfo,
                                                              SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersList.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersList.MinimumCrewMembersListItemByCrewMembersInfo,
                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersList.SelfInfo);
                    
                    SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersText.PressKeys("{TAB}");
                    Ranorex.Report.Info("Updated the minimumCrewMembers value from {" + current_MinimumCrewMembers + "} to {" + minimumCrewMembers + "}" );
                    
                }
                
                else
                {
                    Ranorex.Report.Info("MinimumCrewMembers already set to {" + minimumCrewMembers + "}.");
                }
                
                if(current_EngineAtDeparture != engineAtDeparture)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureTextInfo,
                                                              SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureList.SelfInfo);
                    if (engineAtDeparture)
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureList.True.Click();
                    }
                    else
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureList.False.Click();
                    }
                    
                    SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureText.PressKeys("{TAB}");
                    Ranorex.Report.Info("Updated the minimumCrewMembers value from {" + current_EngineAtDeparture + "} to {" + engineAtDeparture + "}" );
                }
                else
                {
                    Ranorex.Report.Info("EngineAtDeparture already set to {" + engineAtDeparture + "}.");
                }
                
                if(current_EngineAtArrival != engineAtArrival)
                {

                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalTextInfo,
                                                              SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalList.SelfInfo);
                    if(engineAtArrival)
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalList.True.Select();
                    }
                    else
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalList.False.Select();
                    }
                    
                    SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalText.PressKeys("{TAB}");
                    Ranorex.Report.Info("Updated the minimumCrewMembers value from {" + current_EngineAtArrival + "} to {" + engineAtArrival + "}" );
                }
                else
                {
                    Ranorex.Report.Info("EngineAtArrival already set to {" + engineAtArrival + "}.");
                }
            }
            
            if(clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Validate Crew and Engine Data under TrainSheetParameter Form
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="minimumCrewMembers">Input:minimumCrewMembers</param>
        /// <param name="engineAtDeparture">Input:engineAtDeparture</param>
        /// <param name="engineAtArrival">Input:engineAtArrival</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateCrewandEngineData_TrainSheetParameter(string trainGroup, string expMinimumCrewMembers, string expEngineAtDeparture, string expEngineAtArrival, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.Self.Rows.Count;
            
            string currentTrainGroup="";
            string currentMinimumCrewMembers ="";
            string currentEngineAtDeparture= "";
            string currentEngineAtArrival = "";
            
            bool trainGroupFound = false;

            for (int i=0; i < rowCount ;  i++)
            {
                SystemConfigurationrepo.RequiredCrewEngineDataIndex = i.ToString();
                SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.Self.EnsureVisible();
                currentTrainGroup = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.TrainGroup.GetAttributeValue<string>("Text");
                
                if(trainGroup.Equals(currentTrainGroup,StringComparison.OrdinalIgnoreCase))
                {
                    trainGroupFound = true;
                    currentMinimumCrewMembers = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.MinimumCrewMembers.MinimumCrewMembersText.GetAttributeValue<string>("Text");
                    currentEngineAtDeparture = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtDeparture.EngineAtDepartureText.GetAttributeValue<string>("Text");
                    currentEngineAtArrival = SystemConfigurationrepo.Train_Sheet_Parameters.RequiredCrewAndEngineDataTable.RequiredCrewEngineDataRowByRequiredCrewEngineDataIndex.EngineAtArrival.EngineAtArrivalText.GetAttributeValue<string>("Text");
                    
                    if(currentMinimumCrewMembers.Equals(expMinimumCrewMembers,StringComparison.OrdinalIgnoreCase))
                    {
                        Ranorex.Report.Success("Expected MinimumCrewMembers {" + expMinimumCrewMembers + "} got matched with Current MinimumCrewMembers value {" + currentMinimumCrewMembers + "}");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Expected MinimumCrewMembers {" + expMinimumCrewMembers + "} does not match with Current MinimumCrewMembers value {" + currentMinimumCrewMembers + "}");
                        
                    }
                    if(currentEngineAtDeparture.Equals(expEngineAtDeparture.ToUpper(),StringComparison.OrdinalIgnoreCase))
                    {
                        Ranorex.Report.Success("Expected EngineAtDeparture  {" + expEngineAtDeparture + "} got matched with Current EngineAtDeparture value {" + currentEngineAtDeparture + "}");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Expected EngineAtDeparture  {" + expEngineAtDeparture + "} does not match with Current EngineAtDeparture value {" + currentEngineAtDeparture + "}");
                        
                    }

                    if(currentEngineAtArrival.Equals(expEngineAtArrival.ToUpper(),StringComparison.OrdinalIgnoreCase))
                    {
                        Ranorex.Report.Success("Expected EngineAtArrival {" + expEngineAtArrival + "} got matched with Current EngineAtArrival value {" + currentEngineAtArrival + "}");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Expected EngineAtArrival {" + expEngineAtArrival + "} does not match with Current EngineAtArrival value {" + currentEngineAtArrival + "}");
                    }
                }
            }
            
            if(!trainGroupFound)
            {
                Ranorex.Report.Failure("Train Group does not match under TrainSheet Parameter Table");
                Ranorex.Report.Screenshot("Values does not matched in TrainSheet Parameter", SystemConfigurationrepo.Train_Sheet_Parameters.Self.Element);
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Insert row to Configure SCAC List Form
        /// </summary>
        /// <param name="cutoverOpsta">Input:cutoverOpsta </param>
        /// <param name="linkedOpsta">Input:linkedOpsta</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_SCACList(string SCAC, string description, bool reset, bool apply, string expectedFeedback, bool closeForm)
        {
            int startIndex = 0;
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.ScacListInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SelfInfo);
            
            // Verifying Form exist or not
            if (SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
            {
                int rowCount = SystemConfigurationrepo.SCAC_List.SCACListTable.Self.Rows.Count;
                SystemConfigurationrepo.SCACListIndex = startIndex.ToString();
                
                SystemConfigurationrepo.SCAC_List.InsertRowButton.Click();
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SCAC.Click();
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SCAC.PressKeys(SCAC);
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SCAC.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.SCAC_List.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.SCAC_List.CancelButton.Click();
                    
                    if (closeForm && SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.CancelButtonInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SelfInfo);
                    }
                    return;
                }
                
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.Description.Click();
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.Description.PressKeys(description);
                SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.Description.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.SCAC_List.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.SCAC_List.CancelButton.Click();
                    
                    if (closeForm && SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.CancelButtonInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SelfInfo);
                    }
                    return;
                }
            }
            else
            {
                Ranorex.Report.Failure("SCACList Form does not exist");
                Ranorex.Report.Screenshot("Unable to find the SCACList form to insert the new row", SystemConfigurationrepo.SCAC_List.Self.Element);
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.SCAC_List.ResetButtonInfo,
                                                                              SystemConfigurationrepo.SCAC_List.Reset_Forms_Content.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.Reset_Forms_Content.YesButtonInfo,
                                                                  SystemConfigurationrepo.SCAC_List.Reset_Forms_Content.SelfInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.SCAC_List.ApplyButtonInfo, SystemConfigurationrepo.SCAC_List.ApplyButtonInfo);
                Ranorex.Report.Info("Added Values: SCAC value as {" + SCAC + "} and description value as {" + description + "} ");
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.CancelButtonInfo, SystemConfigurationrepo.SCAC_List.SelfInfo);
                
            }
        }
        /// <summary>
        /// To Delete entry under ScacList Form
        /// </summary>
        /// <param name="scac">Input:DistributionListName </param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteRowSCACListRow_bySCAC(string SCAC, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.ScacListInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SelfInfo);
            int rowCount = SystemConfigurationrepo.SCAC_List.SCACListTable.Self.Rows.Count;
            
            bool foundSCAC = false;
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.SCACListIndex = i.ToString();
                string current_SCAC = SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SCAC.GetAttributeValue<string>("Text");
                
                if (SCAC == current_SCAC)
                {
                    SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.Self.EnsureVisible();
                    foundSCAC = true;
                    if (SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.SCAC_List.SCACListTable.MenuCellMenu.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.SCACListTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SCACListTable.MenuCellMenu.SelfInfo);
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.SCAC_List.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.SCAC_List.ApplyButtonInfo);
                        Ranorex.Report.Info("Row got deleted Successfully , Deleted Value are: SCAC value as {" + SCAC + "} in under Configure SCAC List Form ");
                        
                    }
                    break;
                }
            }
            if (!foundSCAC)
            {
                Ranorex.Report.Failure("Could not find row with SCAC as  {" + SCAC + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the SCAC value in the form", SystemConfigurationrepo.SCAC_List.Self.Element);
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.CancelButtonInfo, SystemConfigurationrepo.SCAC_List.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate Scac List Row by Scac in Configure Scac List Form
        /// </summary>
        /// <param name="scac">Input:scac </param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateSCACListRow_bySCAC(string SCAC, bool expValidateExist,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.ScacListInfo,
                                                                          SystemConfigurationrepo.SCAC_List.SelfInfo);
            int rowCount = SystemConfigurationrepo.SCAC_List.SCACListTable.Self.Rows.Count;
            bool foundSCAC = false;
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.SCACListIndex = i.ToString();
                
                if (SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SelfInfo.Exists(0))
                {
                    string current_SCAC = SystemConfigurationrepo.SCAC_List.SCACListTable.ScacListRowBySCACListIndex.SCAC.GetAttributeValue<string>("Text");
                    if (SCAC == current_SCAC)
                    {
                        foundSCAC = true;
                    }
                }
            }
            if(foundSCAC == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Configure SCAC List Row was found with the value as  {" + SCAC + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected Configure SCAC List Row was not found with the value as  {" + SCAC + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected Configure SCAC List Row was not found with the value as  {" + SCAC + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Configure SCAC List Row was found with the value as  {" + SCAC + "}");
                }
            }
            
            //To Close the form
            if(closeForm && SystemConfigurationrepo.SCAC_List.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.SCAC_List.CancelButtonInfo, SystemConfigurationrepo.SCAC_List.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify TimeValues in Train Sheet Parameter
        /// </summary>
        /// <param name="terminateTrainTimeWithCrewTieUp">Input:terminateTrainTimeWithCrewTieUp </param>
        /// <param name="terminateTrainTimeWithoutCrewTieUp">Input:terminateTrainTimeWithoutCrewTieUp</param>
        /// <param name="terminateTrainTimeWithUnknownTrainLocation">Input:terminateTrainTimeWithUnknownTrainLocation</param>
        /// <param name="removePlanDataOlderThan">Input:removePlanDataOlderThan</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyTimeValues_TrainSheetParameter(string terminateTrainTimeWithCrewTieUp, string terminateTrainTimeWithoutCrewTieUp, string terminateTrainTimeWithUnknownTrainLocation, string removePlanDataOlderThan, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                string current_TerminateTrainTimeWithCrewTieUp = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.GetAttributeValue<string>("Text");
                string current_TerminateTrainTimeWithoutCrewTieUp = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithoutCrewTieUpText.GetAttributeValue<string>("Text");
                string current_TerminateTrainTimeWithUnknownTrainLocation = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithUnknownTrainLocationText.GetAttributeValue<string>("Text");
                string current_RemovePlanDataOlderThan = SystemConfigurationrepo.Train_Sheet_Parameters.RemovePlanDataOlderThanText.GetAttributeValue<string>("Text");
                
                //Set Time Values for TerminateTrainTimeWithCrewTieUp
                if (!current_TerminateTrainTimeWithCrewTieUp.Equals(terminateTrainTimeWithCrewTieUp))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys(terminateTrainTimeWithCrewTieUp);
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Info("Updated the TerminateTrainTimeWithCrewTieUp value from {"+current_TerminateTrainTimeWithCrewTieUp+"} to {"+terminateTrainTimeWithCrewTieUp+"}" );
                    }
                    
                }
                else
                {
                    Ranorex.Report.Info("TerminateTrainTimeWithCrewTieUp already set to {"+terminateTrainTimeWithCrewTieUp+"}.");
                }
                
                //Set Time Values for TerminateTrainTimeWithoutCrewTieUp
                if (!current_TerminateTrainTimeWithoutCrewTieUp.Equals(terminateTrainTimeWithoutCrewTieUp))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithoutCrewTieUpText.PressKeys(terminateTrainTimeWithoutCrewTieUp);
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithoutCrewTieUpText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the TerminateTrainTimeWithoutCrewTieUp value from {"+current_TerminateTrainTimeWithoutCrewTieUp+"} to {"+terminateTrainTimeWithoutCrewTieUp+"}" );
                }
                else
                {
                    Ranorex.Report.Info("TerminateTrainTimeWithoutCrewTieUp already set to {"+terminateTrainTimeWithoutCrewTieUp+"}.");
                }
                //Set Time Values for TerminateTrainTimeWithUnknownTrainLocation
                if (!current_TerminateTrainTimeWithUnknownTrainLocation.Equals(terminateTrainTimeWithUnknownTrainLocation))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithUnknownTrainLocationText.PressKeys(terminateTrainTimeWithUnknownTrainLocation);
                    SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithUnknownTrainLocationText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the TerminateTrainTimeWithUnknownTrainLocation value from {"+current_TerminateTrainTimeWithUnknownTrainLocation+"} to {"+terminateTrainTimeWithUnknownTrainLocation+"}" );
                }
                else
                {
                    Ranorex.Report.Info("TerminateTrainTimeWithUnknownTrainLocation  already set to {"+terminateTrainTimeWithUnknownTrainLocation+"}.");
                }
                //Set Time Values for RemovePlanDataOlderThan
                if (!current_RemovePlanDataOlderThan.Equals(removePlanDataOlderThan))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.RemovePlanDataOlderThanText.PressKeys(removePlanDataOlderThan);
                    SystemConfigurationrepo.Train_Sheet_Parameters.RemovePlanDataOlderThanText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the RemovePlanDataOlderThan value from {"+current_RemovePlanDataOlderThan+"} to {"+removePlanDataOlderThan+"}" );
                }
                else
                {
                    Ranorex.Report.Info("RemovePlanDataOlderThan already set to {"+removePlanDataOlderThan+"}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
                Ranorex.Report.Screenshot("Unable to find TrainSheet Parameter Form", SystemConfigurationrepo.Train_Sheet_Parameters.Self.Element);
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo);
            }
            if (apply)
            {
                //Click on apply button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
            }
            if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                //Click on Cancel button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate ModifyTime Values TrainSheetParameter
        /// </summary>
        /// <param name="exp_TerminateTrainTimeWithCrewTieUp">Input:exp_TerminateTrainTimeWithCrewTieUp </param>
        /// <param name="exp_TerminateTrainTimeWithoutCrewTieUp">Input:exp_TerminateTrainTimeWithoutCrewTieUp</param>
        /// <param name="exp_TerminateTrainTimeWithUnknownTrainLocation">Input:exp_TerminateTrainTimeWithUnknownTrainLocation</param>
        /// <param name="exp_RemovePlanDataOlderThan">Input:exp_RemovePlanDataOlderThan</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateTimeValues_TrainSheetParameters(string exp_TerminateTrainTimeWithCrewTieUp, string exp_TerminateTrainTimeWithoutCrewTieUp, string exp_TerminateTrainTimeWithUnknownTrainLocation, string exp_RemovePlanDataOlderThan, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                string current_TerminateTrainTimeWithCrewTieUp = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithCrewTieUpText.GetAttributeValue<string>("Text");
                string current_TerminateTrainTimeWithoutCrewTieUp = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithoutCrewTieUpText.GetAttributeValue<string>("Text");
                string current_TerminateTrainTimeWithUnknownTrainLocation = SystemConfigurationrepo.Train_Sheet_Parameters.TerminateTrainTimeWithUnknownTrainLocationText.GetAttributeValue<string>("Text");
                string current_RemovePlanDataOlderThan = SystemConfigurationrepo.Train_Sheet_Parameters.RemovePlanDataOlderThanText.GetAttributeValue<string>("Text");
                
                if(current_TerminateTrainTimeWithCrewTieUp.Equals(exp_TerminateTrainTimeWithCrewTieUp))
                {
                    Ranorex.Report.Success("Expected TerminateTrainTimeWithCrewTieUp {" + exp_TerminateTrainTimeWithCrewTieUp + "} got matched with Current TerminateTrainTimeWithCrewTieUp value {" + current_TerminateTrainTimeWithCrewTieUp + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TerminateTrainTimeWithCrewTieUp {" + exp_TerminateTrainTimeWithCrewTieUp + "} but found as Current TerminateTrainTimeWithCrewTieUp value {" + current_TerminateTrainTimeWithCrewTieUp + "}");
                }
                
                if(current_TerminateTrainTimeWithoutCrewTieUp.Equals(exp_TerminateTrainTimeWithoutCrewTieUp))
                {
                    Ranorex.Report.Success("Expected TerminateTrainTimeWithoutCrewTieUp {" + exp_TerminateTrainTimeWithoutCrewTieUp + "} got matched with Current TerminateTrainTimeWithCrewTieUp value {" + current_TerminateTrainTimeWithoutCrewTieUp + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TerminateTrainTimeWithoutCrewTieUp  {" + exp_TerminateTrainTimeWithoutCrewTieUp + "}  but found as Current TerminateTrainTimeWithoutCrewTieUp value {" + current_TerminateTrainTimeWithoutCrewTieUp + "}");
                }
                
                if(current_TerminateTrainTimeWithUnknownTrainLocation.Equals(exp_TerminateTrainTimeWithUnknownTrainLocation))
                {
                    Ranorex.Report.Success("Expected TerminateTrainTimeWithUnknownTrainLocation  {" + exp_TerminateTrainTimeWithUnknownTrainLocation + "} got matched with Current TerminateTrainTimeWithUnknownTrainLocation value {" + current_TerminateTrainTimeWithUnknownTrainLocation + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TerminateTrainTimeWithUnknownTrainLocation  {" + exp_TerminateTrainTimeWithUnknownTrainLocation + "} but found as Current EngineAtArrival value {" + current_TerminateTrainTimeWithUnknownTrainLocation + "}");
                }
                
                if(current_RemovePlanDataOlderThan.Equals(exp_RemovePlanDataOlderThan))
                {
                    Ranorex.Report.Success("Expected RemovePlanDataOlderThan {" + exp_RemovePlanDataOlderThan + "} got matched with Current RemovePlanDataOlderThan value {" + current_RemovePlanDataOlderThan + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected RemovePlanDataOlderThan {" + exp_RemovePlanDataOlderThan + "} but found as Current RemovePlanDataOlderThan value {" + current_RemovePlanDataOlderThan + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify formationRequiredForTrainSheetClosure in Train Sheet Parameter
        /// </summary>
        /// <param name="departureTime_Origin">Input:departureTime_Origin </param>
        /// <param name="arrivalTime_Destination">Input:arrivalTime_Destination</param>
        /// <param name="crewChangeWarningInterval">Input:crewChangeWarningInterval</param>
        /// <param name="crewExpirationWarningInterval">Input:crewExpirationWarningInterval</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyInformationRequiredForTrainSheetClosure_TrainSheetParameters(bool departureTimeOrigin, bool arrivalTimeDestination, string crewChangeWarningInterval, string crewExpirationWarningInterval, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                bool foundDepartureTimeOrigin = SystemConfigurationrepo.Train_Sheet_Parameters.DepartureTimeFromOriginCheckbox.GetAttributeValue<bool>("Checked");
                Ranorex.Report.Info(foundDepartureTimeOrigin.ToString());
                if (foundDepartureTimeOrigin != departureTimeOrigin)
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.DepartureTimeFromOriginCheckbox.Click();
                    Ranorex.Report.Info("Updated the TerminateTrainTimeWithCrewTieUp value from {" + foundDepartureTimeOrigin + "}  to {" + departureTimeOrigin + "}" );
                }
                
                bool foundArrivalTimeDestination  = SystemConfigurationrepo.Train_Sheet_Parameters.ArrivalTimeAtDestinationCheckbox.GetAttributeValue<bool>("Checked");
                
                if (foundArrivalTimeDestination != arrivalTimeDestination)
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.ArrivalTimeAtDestinationCheckbox.Click();
                    Ranorex.Report.Info("Updated the TerminateTrainTimeWithCrewTieUp value from {" + foundArrivalTimeDestination + "}  to {" + arrivalTimeDestination + "}" );
                }

                string currentCrewChangeWarningInterval = SystemConfigurationrepo.Train_Sheet_Parameters.CrewChangeWarningIntervalText.GetAttributeValue<string>("Text");
                
                //Set Time Values for arrival Time Destination
                if (!currentCrewChangeWarningInterval.Equals(crewChangeWarningInterval))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.CrewChangeWarningIntervalText.Click();
                    Keyboard.Press("{BACK}");
                    SystemConfigurationrepo.Train_Sheet_Parameters.CrewChangeWarningIntervalText.Element.SetAttributeValue("Text", crewChangeWarningInterval);
                    Keyboard.Press("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Info("Updated the CrewChangeWarningInterval value from {" + currentCrewChangeWarningInterval + "}  to {" + crewChangeWarningInterval + "}" );
                    }
                }
                else
                {
                    Ranorex.Report.Info("CrewChangeWarningInterval already set to {" + crewChangeWarningInterval + "}.");
                }
                
                string currentCrewExpirationWarningInterval = SystemConfigurationrepo.Train_Sheet_Parameters.CrewExpirationWarningIntervalText.GetAttributeValue<string>("Text");

                //Set Time Values for DepartureTime_Origin
                if (!currentCrewExpirationWarningInterval.Equals(crewExpirationWarningInterval))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.CrewExpirationWarningIntervalText.Click();
                    Keyboard.Press("{BACK}");
                    SystemConfigurationrepo.Train_Sheet_Parameters.CrewExpirationWarningIntervalText.Element.SetAttributeValue("Text", crewExpirationWarningInterval);
                    Keyboard.Press("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Info("Updated the CrewExpirationWarningInterval value from {" + currentCrewExpirationWarningInterval + "}  to {" + crewExpirationWarningInterval + "}" );
                    }
                }
                else
                {
                    Ranorex.Report.Info("CrewExpirationWarningInterval already set to {" + crewExpirationWarningInterval + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo);
            }
            if (apply)
            {
                int retries = 0;
                while (!SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(1000);
                    retries++;
                }
                if (!SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButton.Enabled)
                {
                    Ranorex.Report.Error("Apply button did not become Enabled, can't apply");
                } else {
                    //Click on apply button
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo,
                                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
                }
                
                
            }
            if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                //Click on Cancel button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate Information Required For TrainSheet Closure
        /// </summary>
        /// <param name="exp_DepartureTime_Origin">Input:exp_DepartureTime_Origin </param>
        /// <param name="exp_ArrivalTime_Destination">Input:exp_ArrivalTime_Destination</param>
        /// <param name="exp_CrewChangeWarningInterval">Input:exp_CrewChangeWarningInterval</param>
        /// <param name="exp_CrewExpirationWarningInterval">Input:exp_CrewExpirationWarningInterval</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateInformationRequiredForTrainSheetClosure_TrainSheetParameters(bool exp_DepartureTime_Origin , bool exp_ArrivalTime_Destination, string exp_CrewChangeWarningInterval, string exp_CrewExpirationWarningInterval, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            bool foundDepartureTime_Origin  = SystemConfigurationrepo.Train_Sheet_Parameters.DepartureTimeFromOriginCheckbox.GetAttributeValue<bool>("Selected");
            bool foundArrivalTime_Destination  = SystemConfigurationrepo.Train_Sheet_Parameters.ArrivalTimeAtDestinationCheckbox.GetAttributeValue<bool>("Selected");
            string current_CrewChangeWarningInterval = SystemConfigurationrepo.Train_Sheet_Parameters.CrewChangeWarningIntervalText.GetAttributeValue<string>("Text");
            string current_CrewExpirationWarningInterval = SystemConfigurationrepo.Train_Sheet_Parameters.CrewExpirationWarningIntervalText.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                if(foundDepartureTime_Origin == exp_DepartureTime_Origin)
                {
                    Ranorex.Report.Success("Expected DepartureTime_Origin {" + exp_DepartureTime_Origin + "} got matched with Current DepartureTime_Origin value {" + foundDepartureTime_Origin + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected DepartureTime_Origin {" + exp_DepartureTime_Origin + "} but found as Current DepartureTime_Origin value {" + foundDepartureTime_Origin + "}");
                }
                if(foundArrivalTime_Destination == exp_ArrivalTime_Destination)
                {
                    Ranorex.Report.Success("Expected ArrivalTime_Destination {" + exp_ArrivalTime_Destination + "} got matched with Current ArrivalTime_Destination value {" + foundArrivalTime_Destination + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected ArrivalTime_Destination {" + exp_ArrivalTime_Destination + "} but found as Current ArrivalTime_Destination value {" + foundArrivalTime_Destination + "}");
                }
                if(current_CrewChangeWarningInterval.Equals(exp_CrewChangeWarningInterval))
                {
                    Ranorex.Report.Success("Expected CrewChangeWarningInterval {" + exp_CrewChangeWarningInterval + "} got matched with Current CrewChangeWarningInterval value {" + current_CrewChangeWarningInterval + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected CrewChangeWarningInterval {" + exp_CrewChangeWarningInterval + "} but found as Current CrewChangeWarningInterval value {" + current_CrewChangeWarningInterval + "}");
                }
                if(current_CrewExpirationWarningInterval.Equals(exp_CrewExpirationWarningInterval))
                {
                    Ranorex.Report.Success("Expected CrewExpirationWarningInterval {" + exp_CrewExpirationWarningInterval + "} got matched with Current CrewExpirationWarningInterval value {" + current_CrewExpirationWarningInterval + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected CrewExpirationWarningInterval {" + exp_CrewExpirationWarningInterval + "} but found as Current CrewExpirationWarningInterval value {" + current_CrewExpirationWarningInterval + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate Information Required For TrainSheet Closure
        /// </summary>
        /// <param name="exp_HeldTrain">Input:exp_HeldTrain </param>
        /// <param name="exp_ApprochTrain">Input:exp_ApprochTrain</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateSetInclusionIntervals_TrainSheetParameters(string expHeldTrain, string expApprochTrain, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            
            string currentHeldTrain = SystemConfigurationrepo.Train_Sheet_Parameters.HeldTrainsText.GetAttributeValue<string>("Text");
            string currentApprochTrain = SystemConfigurationrepo.Train_Sheet_Parameters.ApproachingTrainsText.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                if(currentHeldTrain.Equals(expHeldTrain))
                {
                    Ranorex.Report.Success("Expected HeldTrain {" + expHeldTrain + "} got matched with Current HeldTrain value {" + currentHeldTrain + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected HeldTrain {" + expHeldTrain + "} but found as Current HeldTrain value {" + currentHeldTrain + "}");
                }
                if(currentApprochTrain.Equals(expApprochTrain))
                {
                    Ranorex.Report.Success("Expected ApprochTrain {" + expApprochTrain + "} got matched with Current ApprochTrain value {" + currentApprochTrain + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected ApprochTrain {" + expApprochTrain + "} but found as Current ApprochTrain value {" + currentApprochTrain + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify TrainSuspensionIntervals in Train Sheet Parameter
        /// </summary>
        /// <param name="departureSuspensionInterval">Input:departureSuspensionInterval </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyTrainSuspensionIntervals_TrainSheetParameters(string departureSuspensionInterval, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                string current_DepartureSuspensionInterval = SystemConfigurationrepo.Train_Sheet_Parameters.DepartureSuspensionIntervalText.GetAttributeValue<string>("Text");
                
                //Set Time Values for arrival Time Destination
                if (!current_DepartureSuspensionInterval.Equals(departureSuspensionInterval))
                {
                    SystemConfigurationrepo.Train_Sheet_Parameters.DepartureSuspensionIntervalText.Click();
                    SystemConfigurationrepo.Train_Sheet_Parameters.DepartureSuspensionIntervalText.PressKeys(departureSuspensionInterval);
                    SystemConfigurationrepo.Train_Sheet_Parameters.DepartureSuspensionIntervalText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Sheet_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Train_Sheet_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
                        }
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Info("Updated the CrewChangeWarningInterval value from {" + current_DepartureSuspensionInterval + "}  to {" + departureSuspensionInterval + "}" );
                    }
                }
                else
                {
                    Ranorex.Report.Info("CrewChangeWarningInterval already set to {" + departureSuspensionInterval + "}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.ResetButtonInfo);
            }
            if (apply)
            {
                //Click on apply button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.ApplyButtonInfo);
            }
            if (closeForm && SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                //Click on Cancel button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo,
                                                                                      SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate Information Required For TrainSheet Closure
        /// </summary>
        /// <param name="exp_HeldTrain">Input:exp_HeldTrain </param>
        /// <param name="exp_ApprochTrain">Input:exp_ApprochTrain</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainSuspensionIntervals_TrainSheetParameters(string expDepartureSuspensionInterval, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainSheetParametersInfo,
                                                                          SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            
            string currentDepartureSuspensionInterval = SystemConfigurationrepo.Train_Sheet_Parameters.DepartureSuspensionIntervalText.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo.Exists(0))
            {
                if(currentDepartureSuspensionInterval.Equals(expDepartureSuspensionInterval))
                {
                    Ranorex.Report.Success("Expected DepartureSuspensionInterval {" + expDepartureSuspensionInterval + "} got matched with Current HeldTrain value {" + currentDepartureSuspensionInterval + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected DepartureSuspensionInterval {" + expDepartureSuspensionInterval + "} but found as Current HeldTrain value {" + currentDepartureSuspensionInterval + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Sheet_Parameters.CancelButtonInfo, SystemConfigurationrepo.Train_Sheet_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify PseudoTrainSuppressionFilters in TrackingParameters
        /// </summary>
        /// <param name="expNoPseudoTrainID">Input:expNoPseudoTrainID </param>
        /// <param name="expSignalSystemSuspended">Input:expSignalSystemSuspended</param>
        /// <param name="expSwitchBlock">Input:expSwitchBlock</param>
        /// <param name="expTrackBlock">Input:expTrackBlock</param>
        /// <param name="expLocalorField">Input:expLocalorField</param>
        /// <param name="expControlPointFailed">Input:expControlPointFailed</param>
        /// <param name="expSignalTechControl">Input:expSignalTechControl</param>
        /// <param name="expTrackandTime">Input:expTrackandTime</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyPseudoTrainSuppressionFilters_TrackingParameters(bool noPseudoTrainID, bool signalSystemSuspended, bool switchBlock, bool trackBlock, bool localField, bool controlPointFailed, bool signalTechControl, bool trackAndTime, bool reset, bool apply, bool closeForm)
        {
            NS_OpenTrackingParameters_MainMenu();
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                bool currentNoPseudoTrainID  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.GetAttributeValue<bool>("Selected");
                bool currentSignalSystemSuspended  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalSystemSuspendedCheckbox.GetAttributeValue<bool>("Selected");
                bool currentSwitchBlock  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SwitchBlockCheckbox.GetAttributeValue<bool>("Selected");
                bool currentTrackBlock  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackBlockCheckbox.GetAttributeValue<bool>("Selected");
                bool currentLocalField  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.LocalFieldCheckbox.GetAttributeValue<bool>("Selected");
                bool currentControlPointFailed  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.ControlPointFailedCheckbox.GetAttributeValue<bool>("Selected");
                bool currentSignalTechControl  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalTechControlCheckbox.GetAttributeValue<bool>("Selected");
                bool currentTrackAndTime  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackAndTimeCheckbox.GetAttributeValue<bool>("Selected");
                
                if(currentNoPseudoTrainID != noPseudoTrainID)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.Click();
                    Ranorex.Report.Info("Updated the NoPseudoTrainID value from {" + currentNoPseudoTrainID + "}  to {" + noPseudoTrainID + "}" );
                }
                if(currentSignalSystemSuspended != signalSystemSuspended)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalSystemSuspendedCheckbox.Click();
                    Ranorex.Report.Info("Updated the signalSystemSuspended value from {" + currentSignalSystemSuspended + "}  to {" + signalSystemSuspended + "}" );
                }
                if(currentSwitchBlock != switchBlock)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SwitchBlockCheckbox.Click();
                    Ranorex.Report.Info("Updated the switchBlock value from {" + currentSwitchBlock + "}  to {" + switchBlock + "}" );
                }
                if(currentTrackBlock != trackBlock)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackBlockCheckbox.Click();
                    Ranorex.Report.Info("Updated the trackBlock value from {" + currentTrackBlock + "}  to {" + trackBlock + "}" );
                }
                if(currentLocalField != localField)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.LocalFieldCheckbox.Click();
                    Ranorex.Report.Info("Updated the localorField value from {" + currentLocalField + "}  to {" + localField + "}" );
                }
                if(currentControlPointFailed != controlPointFailed)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.ControlPointFailedCheckbox.Click();
                    Ranorex.Report.Info("Updated the controlPointFailed value from {" + currentControlPointFailed + "}  to {" + controlPointFailed + "}" );
                }
                if(currentSignalTechControl != signalTechControl)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalTechControlCheckbox.Click();
                    Ranorex.Report.Info("Updated the signalTechControl value from {" + currentSignalTechControl + "}  to {" + signalTechControl + "}" );
                }
                if(currentTrackAndTime != trackAndTime)
                {
                    SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackAndTimeCheckbox.Click();
                    Ranorex.Report.Info("Updated the trackandTime value from {" + currentTrackAndTime + "}  to {" + trackAndTime + "}" );
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter Form doesnot exist");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo,
                                                                                      SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo);
            }
            if (apply)
            {
                int retries = 0;
                while (!SystemConfigurationrepo.Tracking_Parameters.ApplyButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(1000);
                    retries++;
                }
                if (!SystemConfigurationrepo.Tracking_Parameters.ApplyButton.Enabled)
                {
                    Ranorex.Report.Error("Apply button did not become Enabled, can't apply");
                } else {
                    //Click on apply button
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo,
                                                                                          SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo);
                }
            }
            if (closeForm && SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                //Click on Cancel button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                                      SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To verify PseudoTrainSuppressionFilters in TrackingParameters
        /// </summary>
        /// <param name="expNoPseudoTrainID">Input:expNoPseudoTrainID </param>
        /// <param name="expSignalSystemSuspended">Input:expSignalSystemSuspended</param>
        /// <param name="expSwitchBlock">Input:expSwitchBlock</param>
        /// <param name="expTrackBlock">Input:expTrackBlock</param>
        /// <param name="expLocalorField">Input:expLocalorField</param>
        /// <param name="expControlPointFailed">Input:expControlPointFailed</param>
        /// <param name="expSignalTechControl">Input:expSignalTechControl</param>
        /// <param name="expTrackandTime">Input:expTrackandTime</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidatePseudoTrainSuppressionFilters_TrackingParameters(bool expNoPseudoTrainID ,bool expSignalSystemSuspended, bool expSwitchBlock, bool expTrackBlock, bool expLocalorField , bool expControlPointFailed, bool expSignalTechControl, bool expTrackandTime, bool closeForm)
        {
            NS_OpenTrackingParameters_MainMenu();
            
            bool currentNoPseudoTrainID  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.NoPseudoTrainIDCheckbox.GetAttributeValue<bool>("Selected");
            bool currentSignalSystemSuspended  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalSystemSuspendedCheckbox.GetAttributeValue<bool>("Selected");
            bool currentSwitchBlock  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SwitchBlockCheckbox.GetAttributeValue<bool>("Selected");
            bool currentTrackBlock  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackBlockCheckbox.GetAttributeValue<bool>("Selected");
            bool currentLocalorField  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.LocalFieldCheckbox.GetAttributeValue<bool>("Selected");
            bool currentControlPointFailed  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.ControlPointFailedCheckbox.GetAttributeValue<bool>("Selected");
            bool currentSignalTechControl  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.SignalTechControlCheckbox.GetAttributeValue<bool>("Selected");
            bool currentTrackandTime  = SystemConfigurationrepo.Tracking_Parameters.PseudoTrainSuppressionFilters.TrackAndTimeCheckbox.GetAttributeValue<bool>("Selected");
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                if(currentNoPseudoTrainID == expNoPseudoTrainID)
                {
                    Ranorex.Report.Success("Expected NoPseudoTrainID {" + expNoPseudoTrainID + "} got matched with Current NoPseudoTrainID value {" + currentNoPseudoTrainID + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected NoPseudoTrainID {" + expNoPseudoTrainID + "} but found as Current NoPseudoTrainID value {" + currentNoPseudoTrainID + "}");
                }
                
                if(currentSignalSystemSuspended == expSignalSystemSuspended)
                {
                    Ranorex.Report.Success("Expected SignalSystemSuspended {" + expSignalSystemSuspended + "} got matched with Current SignalSystemSuspended value {" + currentSignalSystemSuspended + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected SignalSystemSuspended {" + expSignalSystemSuspended + "} but found as Current SignalSystemSuspended value {" + currentSignalSystemSuspended + "}");
                }
                
                if(currentSwitchBlock == expSwitchBlock)
                {
                    Ranorex.Report.Success("Expected SwitchBlock {" + expSwitchBlock + "} got matched with Current SwitchBlock value {" + currentSwitchBlock + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected SwitchBlock {" + expSwitchBlock + "} but found as Current SwitchBlock value {" + currentSwitchBlock + "}");
                }
                
                if(currentTrackBlock == expTrackBlock)
                {
                    Ranorex.Report.Success("Expected TrackBlock {" + expTrackBlock + "} got matched with Current TrackBlock value {" + currentTrackBlock + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TrackBlock {" + expTrackBlock + "} but found as Current TrackBlock value {" + currentTrackBlock + "}");
                }
                
                if(currentLocalorField == expLocalorField)
                {
                    Ranorex.Report.Success("Expected LocalorField {" + expLocalorField + "} got matched with Current LocalorField value {" + currentLocalorField + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected LocalorField {" + expLocalorField + "} but found as Current LocalorField value {" + currentLocalorField + "}");
                }
                if(currentControlPointFailed == expControlPointFailed)
                {
                    Ranorex.Report.Success("Expected ControlPointFailed {" + expControlPointFailed + "} got matched with Current ControlPointFailed value {" + currentControlPointFailed + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected ControlPointFailed {" + expControlPointFailed + "} but found as Current ControlPointFailed value {" + currentControlPointFailed + "}");
                }
                if(currentSignalTechControl == expSignalTechControl)
                {
                    Ranorex.Report.Success("Expected SignalTechControl {" + expSignalTechControl + "} got matched with Current SignalTechControl value {" + currentSignalTechControl + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected SignalTechControl {" + expSignalTechControl + "} but found as Current SignalTechControl value {" + currentSignalTechControl + "}");
                }
                
                if(currentTrackandTime == expTrackandTime)
                {
                    Ranorex.Report.Success("Expected TrackandTime {" + expTrackandTime + "} got matched with Current TrackandTime value {" + currentTrackandTime + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TrackandTime {" + expTrackandTime + "} but found as Current TrackandTime value {" + currentTrackandTime + "}");
                }
                
            }
            else
            {
                Ranorex.Report.Failure("TrainSheet Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        

        /// <summary>
        /// Validates the pre effective intervalin bulletins item form
        /// </summary>
        /// <param name="bulletinName">Input : bulletinName</param>
        /// <param name="expPreEffcetiveIntervalHours">Input : expPreEffcetiveIntervalHours</param>
        /// <param name="expPreEffcetiveIntervalDays">Input : expPreEffcetiveIntervalDays</param>
        [UserCodeMethod]
        public static void NS_ValidatePreEffectiveInterval_BulletinItemsForm(string bulletinName, string expPreEffectiveIntervalHours, string expPreEffectiveIntervalDays)
        {
            NS_OpenBulletinItems_MainMenu();
            NS_SetBulletinType_BulletinItemsForm(bulletinName);
            
            string actPreEffectiveIntervalHours = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalHoursText.GetAttributeValue<string>("Text");
            string actPreEffectiveIntervalDays = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.PreEffectiveIntervalDaysText.GetAttributeValue<string>("Text");
            
            if(actPreEffectiveIntervalHours.Equals(expPreEffectiveIntervalHours) && actPreEffectiveIntervalDays.Equals(expPreEffectiveIntervalDays))
            {
                Ranorex.Report.Success("Expected pre-effective intervals to be :{"+expPreEffectiveIntervalHours+"}Hrs{"+expPreEffectiveIntervalDays+"}Days and found :{"+actPreEffectiveIntervalHours+"}Hrs{"+actPreEffectiveIntervalDays+"}");
            }
            else
            {
                Ranorex.Report.Screenshot(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.Self);
                Ranorex.Report.Failure("Expected pre-effective intervals to be :{"+expPreEffectiveIntervalHours+"}Hrs{"+expPreEffectiveIntervalDays+"}Days and found :{"+actPreEffectiveIntervalHours+"}Hrs{"+actPreEffectiveIntervalDays+"}");
            }
            
        }
        /// To Validate Track Occupancy Timers in TrackingParameter
        /// </summary>
        /// <param name="expTimerOccupancy">Input:expTimerOccupancy </param>
        /// <param name="expTimerUnoccupancy">Input:expTimerUnoccupancy</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateTrackOccupancyTimers_TrackingParameter(string expTimerOccupancy, string expTimerUnoccupancy, bool closeForm)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            string currentTimerOccupancy = SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.UnidentifiedTrackOccupancyText.GetAttributeValue<string>("Text");
            string currentTimerUnoccupancy = SystemConfigurationrepo.Tracking_Parameters.TrackOccupancyTimers.TrackUnoccupiedText.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                if(currentTimerOccupancy.Equals(expTimerOccupancy))
                {
                    Ranorex.Report.Success("Expected TimerOccupancy {" + expTimerOccupancy + "} got matched with Current TimerOccupancy value {" + currentTimerOccupancy + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TimerOccupancy {" + expTimerOccupancy + "} but found as Current TimerOccupancy value {" + currentTimerOccupancy + "}");
                }
                
                if(currentTimerUnoccupancy.Equals(expTimerUnoccupancy))
                {
                    Ranorex.Report.Success("Expected TimerUnoccupancy {" + expTimerUnoccupancy + "} got matched with Current TimerUnoccupancy value {" + currentTimerUnoccupancy + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TimerUnoccupancy {" + expTimerUnoccupancy + "} but found as Current TimerUnoccupancy value {" + currentTimerUnoccupancy + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Validate Departure Time Interval in TrackingParameter
        /// </summary>
        /// <param name="expDepartureListVisibility">Input:expDepartureListVisibility </param>
        /// <param name="expDepartureEligibilityLimit">Input:expDepartureEligibilityLimit</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateDepartureTimeInterval_TrackingParameter(string expDepartureListVisibility, string expDepartureEligibilityLimit, bool closeForm)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            string currentDepartureListVisibility = SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureListVisibilityText.GetAttributeValue<string>("Text");
            string currentDepartureEligibilityLimit = SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureEligibilityLimitText.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                if(currentDepartureListVisibility.Equals(expDepartureListVisibility))
                {
                    Ranorex.Report.Success("Expected DepartureListVisibility {" + expDepartureListVisibility + "} got matched with Current DepartureListVisibility value {" + currentDepartureListVisibility + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected DepartureListVisibility {" + expDepartureListVisibility + "} but found as Current DepartureListVisibility value {" + currentDepartureListVisibility + "}");
                }
                
                if(currentDepartureEligibilityLimit.Equals(expDepartureEligibilityLimit))
                {
                    Ranorex.Report.Success("Expected DepartureEligibilityLimit {" + expDepartureEligibilityLimit + "} got matched with Current DepartureEligibilityLimit value {" + currentDepartureEligibilityLimit + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected DepartureEligibilityLimit {" + expDepartureEligibilityLimit + "} but found as Current DepartureEligibilityLimit value {" + currentDepartureEligibilityLimit + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify TrackingTolerance in Tracking Parameters
        /// </summary>
        /// <param name="minimumCheckDistance">Input:minimumCheckDistance </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        ///  <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyTrackingTolerance_TrackingParameters(string minimumCheckDistance, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            NS_OpenTrackingParameters_MainMenu();
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                string currentMinimumCheckDistance = SystemConfigurationrepo.Tracking_Parameters.TrackingTolerance.MinimumCheckDistanceText.GetAttributeValue<string>("Text");
                
                //Set minimum Check Distance Value
                if (!currentMinimumCheckDistance.Equals(minimumCheckDistance))
                {
                    SystemConfigurationrepo.Tracking_Parameters.TrackingTolerance.MinimumCheckDistanceText.PressKeys(minimumCheckDistance);
                    SystemConfigurationrepo.Tracking_Parameters.TrackingTolerance.MinimumCheckDistanceText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Tracking_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Tracking_Parameters.ResetButton.Click();
                        
                        if (closeForm && SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                        }
                        return;
                    }
                    else
                    {
                        Ranorex.Report.Info("Updated the MinimumCheckDistance value from {" + currentMinimumCheckDistance + "}  to {" + minimumCheckDistance + "}" );
                    }
                }
                else
                {
                    Ranorex.Report.Info("MinimumCheckDistance already set to {" + minimumCheckDistance + "}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter Form doesnot exist");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo,
                                                                                      SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo);
            }
            if (apply)
            {
                //Click on apply button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo,
                                                                                      SystemConfigurationrepo.Tracking_Parameters.ApplyButtonInfo);
            }
            if (closeForm && SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                //Click on Cancel button
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                                      SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate Departure Time Interval in TrackingParameter
        /// </summary>
        /// <param name="expDepartureListVisibility">Input:expDepartureListVisibility </param>
        /// <param name="expDepartureEligibilityLimit">Input:expDepartureEligibilityLimit</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateTrackingTolerance_TrackingParameters(string expMinimumCheckDistance, bool closeForm)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            string currentMinimumCheckDistance = SystemConfigurationrepo.Tracking_Parameters.TrackingTolerance.MinimumCheckDistanceText.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                if(currentMinimumCheckDistance.Equals(expMinimumCheckDistance))
                {
                    Ranorex.Report.Success("Expected MinimumCheckDistance {" + expMinimumCheckDistance + "} got matched with Current MinimumCheckDistance value {" + currentMinimumCheckDistance + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected MinimumCheckDistance {" + expMinimumCheckDistance + "} but found as Current MinimumCheckDistance value {" + currentMinimumCheckDistance + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter Form doesnot exist");
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To InsertRow in DepartureTimeInterval in TrackingParameter
        /// </summary>
        /// <param name="departureListVisibility">Input:departureListVisibility </param>
        /// <param name="departureEligibilityLimit">Input:departureEligibilityLimit </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyDepartureTimeInterval_TrackingParameter(string departureListVisibility, string departureEligibilityLimit, string expectedFeedback, bool reset, bool apply, bool closeForm)
        {
            //Open Tracking parameters form
            NS_OpenTrackingParameters_MainMenu();
            
            // Verifying Recipients Tab  exist or not in Tracking Parameter Form
            if (SystemConfigurationrepo.Tracking_Parameters.SelfInfo.Exists(0))
            {
                if(departureListVisibility != "")
                {
                    SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureListVisibilityText.PressKeys(departureListVisibility);
                    SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureListVisibilityText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Tracking_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Tracking_Parameters.ResetButton.Click();
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                        }
                        return;
                    }
                }
                if(departureEligibilityLimit != "" )
                {
                    
                    SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureEligibilityLimitText.PressKeys(departureEligibilityLimit);
                    SystemConfigurationrepo.Tracking_Parameters.DepartureTimeInterval.DepartureEligibilityLimitText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Tracking_Parameters.Feedback, expectedFeedback))
                    {
                        SystemConfigurationrepo.Tracking_Parameters.ResetButton.Click();
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                        }
                        return;
                    }
                }
            }
            else
            {
                Ranorex.Report.Failure("Tracking Parameter form does not exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo, SystemConfigurationrepo.Tracking_Parameters.ResetButtonInfo);
            }
            
            // to Apply the Form
            if (apply)
            {
                SystemConfigurationrepo.Tracking_Parameters.ApplyButton.Click();
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Tracking_Parameters.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Tracking_Parameters.ResetButton.Click();
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
                    }
                    return;
                }
                Ranorex.Report.Info("Row inserted successfully to Tracking Parameter Form with the Value:- DepartureListVisibility as {" + departureListVisibility + "} & DepartureEligibilityLimit as {" + departureEligibilityLimit + "}");
                
            }
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Tracking_Parameters.CancelButtonInfo, SystemConfigurationrepo.Tracking_Parameters.SelfInfo);
            }
        }
        /// <summary>
        /// To InsertRow in Engine in ConfigDefaults
        /// </summary>
        /// <param name="expLocomotiveKey">Input:expLocomotiveKey </param>
        /// <param name="expMaxSpeed">Input:expMaxSpeed</param>
        /// <param name="expWeight">Input:expWeight</param>
        /// <param name="expLength">Input:expLength</param>
        /// <param name="expHP">Input:expHP</param>
        /// <param name="expAxles">Input:expAxles</param>
        /// <param name="expCrossSection">Input:expCrossSection</param>
        /// <param name="expStreamLiningCoeffL">Input:expStreamLiningCoeffL</param>
        /// <param name="expStreamLiningCoeffL">Input:expStreamLiningCoeffL</param>
        /// <param name="expStreamLiningCoeffT">Input:expStreamLiningCoeffT</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="apply">Input:apply</param>
        ///  <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_EngineConfig_ConsistDefaults(string locomotiveKey, string maxSpeed, string weight, string length, string hp, string axles, string crossSection, string streamLiningCoeffL, string streamLiningCoeffT, string expectedFeedback,bool reset,bool apply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            if (!SystemConfigurationrepo.Train_Default_Data.EngineConfig.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Engine Tab under Consist Default Form does not exist");
                return;
            }
            
            SystemConfigurationrepo.EngineConfigIndex = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.Self.Rows.Count.ToString();
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.InsertRowButtonInfo, SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.SelfInfo);
            
            SystemConfigurationrepo.EngineConfigIndex = "0";
            
            //set locomotiveKey
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.LocomotiveKey.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", locomotiveKey);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set maxSpeed
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MaxSpeed.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", maxSpeed);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set weight
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Weight.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", weight);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set length
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Length.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", length);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set hp
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.HP.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", hp);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set axles
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Axles.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", axles);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set crossSection
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.CrossSection.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", crossSection);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set streamLiningCoeffL
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffL.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", streamLiningCoeffL);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set streamLiningCoeffT
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffT.Click();
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", streamLiningCoeffT);
            SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                SystemConfigurationrepo.Train_Default_Data.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo, SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                Ranorex.Report.Info("Row inserted successfully to Engine Tab under Consist Default Form with the Value:- locomotiveKey as {" + locomotiveKey + "} ,maxSpeed as {" + maxSpeed + "} ,weight as {" + weight + "} ,length as {" + length + "}, hp as {" + hp + "} ,axles as {" + axles + "}" +
                                    ",crossSection as {" + crossSection + "}, streamLiningCoeffL as {" + streamLiningCoeffL + "} and streamLiningCoeffT as {" + streamLiningCoeffT + "}");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To  Validate RowExist by_Engine_Config Defaults
        /// </summary>
        /// <param name="expLocomotiveKey">Input:expLocomotiveKey </param>
        /// <param name="expMaxSpeed">Input:expMaxSpeed</param>
        /// <param name="expWeight">Input:expWeight</param>
        /// <param name="expLength">Input:expLength</param>
        /// <param name="expHP">Input:expHP</param>
        /// <param name="expAxles">Input:expAxles</param>
        /// <param name="expCrossSection">Input:expCrossSection</param>
        /// <param name="expStreamLiningCoeffL">Input:expStreamLiningCoeffL</param>
        /// <param name="expStreamLiningCoeffL">Input:expStreamLiningCoeffL</param>
        /// <param name="expStreamLiningCoeffT">Input:expStreamLiningCoeffT</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateRowExists_EngineConfig_ConsistDefaults(string expLocomotiveKey, string expMaxSpeed, string expWeight, string expLength, string expHP, string expAxles, string expCrossSection, string expStreamLiningCoeffL, string expStreamLiningCoeffT, bool expValidateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            int rowcount = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.Self.Rows.Count;
            bool foundRow = false;
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.EngineConfigIndex = i.ToString();
                if (SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.SelfInfo.Exists(0))
                {
                    string currentLocomotiveKey = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.LocomotiveKey.GetAttributeValue<string>("Text");
                    string currentMaxSpeed = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MaxSpeed.GetAttributeValue<string>("Text");
                    string currentWeight = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Weight.GetAttributeValue<string>("Text");
                    string currentLength = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Length.GetAttributeValue<string>("Text");
                    string currentHP = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.HP.GetAttributeValue<string>("Text");
                    string currentAxles = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Axles.GetAttributeValue<string>("Text");
                    string currentCrossSection = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.CrossSection.GetAttributeValue<string>("Text");
                    string currentStreamLiningCoeffL =SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffL.GetAttributeValue<string>("Text");
                    string currentStreamLiningCoeffT =SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffT.GetAttributeValue<string>("Text");
                    
                    if ((currentLocomotiveKey.Equals(expLocomotiveKey, StringComparison.OrdinalIgnoreCase))
                        && (currentMaxSpeed.Equals(expMaxSpeed, StringComparison.OrdinalIgnoreCase))
                        && (currentWeight.Equals(expWeight, StringComparison.OrdinalIgnoreCase))
                        && (currentAxles.Equals(expAxles, StringComparison.OrdinalIgnoreCase))
                        && (currentCrossSection.Equals(expCrossSection, StringComparison.OrdinalIgnoreCase))
                        && (currentStreamLiningCoeffL.Equals(expStreamLiningCoeffL, StringComparison.OrdinalIgnoreCase))
                        && (currentStreamLiningCoeffT.Equals(expStreamLiningCoeffT, StringComparison.OrdinalIgnoreCase)))
                    {
                        foundRow = true;
                        break;
                    }
                }
            }
            if(foundRow == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Engine Config row in Consist Defaults Form  was found with the value -: LocomotiveKey as {" + expLocomotiveKey + "} ,MaxSpeed as {" + expMaxSpeed + "} ,Weight as {" + expWeight + "} ,Length as {" + expLength + "}, HP as {" + expHP + "} ,Axles as {" + expAxles + "}" +
                                           ",CrossSection as {" + expCrossSection + "}, StreamLiningCoeffL as {" + expStreamLiningCoeffL + "} and StreamLiningCoeffT as {" + expStreamLiningCoeffT + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected  Engine Config row in Consist Defaults Form  not found with the value -: LocomotiveKey as {" + expLocomotiveKey + "} ,MaxSpeed as {" + expMaxSpeed + "} ,Weight as {" + expWeight + "} ,expLength as {" + expLength + "}, HP as {" + expHP + "} ,Axles as {" + expAxles + "}" +
                                           ",CrossSection as {" + expCrossSection + "}, StreamLiningCoeffL as {" + expStreamLiningCoeffL + "} and StreamLiningCoeffT as {" + expStreamLiningCoeffT + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected  Engine Config row in Consist Defaults Form  not found with the value -: LocomotiveKey as {" + expLocomotiveKey + "} ,MaxSpeed as {" + expMaxSpeed + "} ,Weight as {" + expWeight + "} ,expLength as {" + expLength + "}, HP as {" + expHP + "} ,Axles as {" + expAxles + "}" +
                                           ",CrossSection as {" + expCrossSection + "}, StreamLiningCoeffL as {" + expStreamLiningCoeffL + "} and StreamLiningCoeffT as {" + expStreamLiningCoeffT + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Engine Config row in Consist Defaults Form  was found with the value -: LocomotiveKey as {" + expLocomotiveKey + "} ,MaxSpeed as {" + expMaxSpeed + "} ,Weight as {" + expWeight + "} ,Length as {" + expLength + "}, HP as {" + expHP + "} ,Axles as {" + expAxles + "}" +
                                           ",CrossSection as {" + expCrossSection + "}, StreamLiningCoeffL as {" + expStreamLiningCoeffL + "} and StreamLiningCoeffT as {" + expStreamLiningCoeffT + "}");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To InsertRow Consist ConfigDefaults
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="trainCategory">Input:trainCategory</param>
        /// <param name="loads">Input:loads</param>
        /// <param name="empties">Input:empties</param>
        /// <param name="expHP">Input:expHP</param>
        /// <param name="tonnage">Input:tonnage</param>
        /// <param name="length">Input:length</param>
        /// <param name="carCategory">Input:carCategory</param>
        /// <param name="enginesNumbers">Input:enginesNumbers</param>
        /// <param name="locomotiveKey">Input:locomotiveKey</param>
        /// <param name="height">Input:height</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="apply">Input:apply</param>
        ///  <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_ConsistConfig_ConsistDefaults(string trainGroup, string trainCategory, string loads, string empties, string tonnage, string length, string carCategory ,string numberOfEngines, string locomotiveKey, string height, string expectedFeedback, bool reset, bool apply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.ConsistConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.ConsistConfig.SelfInfo);
            if (!SystemConfigurationrepo.Train_Default_Data.ConsistConfig.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("ConsistConfig Tab in Train Default Data Form does not exist");
                return;
            }
            
            SystemConfigurationrepo.ConsistConfigIndex = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.Self.Rows.Count.ToString();
            
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.InsertRowButtonInfo, SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.SelfInfo);
            
            SystemConfigurationrepo.ConsistConfigIndex = "0";
            //set Train Group
            SystemConfigurationrepo.TrainGroup = trainGroup;
            
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupTextInfo,
                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupList.SelfInfo);
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupList.TrainGroupListItemByTrainGroupInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupList.SelfInfo);
            
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupText.PressKeys("{TAB}");
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Train Category
            SystemConfigurationrepo.TrainCategory = trainCategory;
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryTextInfo,
                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.SelfInfo);
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.TrainCategoryListItemByTrainCategoryInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.SelfInfo);
            
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryText.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Load
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Loads.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", loads);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set empties
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Empties.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", empties);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set tonnage
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Tonnage.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", tonnage);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Length
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Length.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", length);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Car Category
            SystemConfigurationrepo.CarCategory = carCategory;
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryTextInfo,
                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.SelfInfo);
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.CarCategoryListitemByCarCategoryInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.SelfInfo);
            
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryText.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Numeber of Engines
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.NumberOfEngines.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", numberOfEngines);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set Locomotive Key
            SystemConfigurationrepo.LocomotiveKeyIndex = locomotiveKey;
            
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyTextInfo,
                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKey.SelfInfo);
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKey.LocomotiveKeyListItemByLocomotiveKeyIndexInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKey.SelfInfo);
            
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyText.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            //set Height
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Height.Click();
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", height);
            SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo, SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                Ranorex.Report.Info("Row inserted successfully to ConsistConfig Tab in Train Default Data Form Form");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To InsertRow Consist ConfigDefaults
        /// </summary>
        /// <param name="carCategory">Input:carCategory </param>
        /// <param name="axles">Input:axles</param>
        /// <param name="streamLiningL">Input:streamLiningL</param>
        /// <param name="streamLiningT">Input:streamLiningT</param>
        /// <param name="crossSectionL">Input:crossSectionL</param>
        /// <param name="crossSectionT">Input:crossSectionT</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="apply">Input:apply</param>
        ///  <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_InsertRow_RailcarConfig_ConsistDefaults(string carCategory, string axles, string streamLiningL, string streamLiningE, string crossSectionL, string crossSectionE, string expectedFeedback, bool reset, bool apply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.RailcarConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.RailCarConfig.SelfInfo);
            if (!SystemConfigurationrepo.Train_Default_Data.RailCarConfig.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("RailCarConfig Tab in Train Default Data Form does not exist");
                return;
            }
            
            SystemConfigurationrepo.RailCarIndex = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.Self.Rows.Count.ToString();
            
            GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.InsertRowButtonInfo, SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.SelfInfo);
            
            SystemConfigurationrepo.RailCarIndex = "0";
            
            //set Car Category
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CarCategory.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", carCategory);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Axles
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.Axles.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", axles);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Stream Lining L
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningL.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", streamLiningL);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            
            //set Stream Lining E
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningE.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", streamLiningE);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Cross Section L
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionL.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", crossSectionL);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            
            //set Cross Section E
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionE.Click();
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", crossSectionE);
            SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
            
            //Check if this kicked up some Feedback
            if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                }
                return;
            }
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo, SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                Ranorex.Report.Info("Row inserted successfully to ConsistConfig Tab in Train Default Data Form Form");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To  Validate RowExist by_Engine_Config Defaults
        /// </summary>
        /// <param name="expCarCategory">Input:expCarCategory </param>
        /// <param name="expAxles">Input:expAxles</param>
        /// <param name="expStreamLiningL">Input:expStreamLiningL</param>
        /// <param name="expStreamLiningT">Input:expStreamLiningT</param>
        /// <param name="expCrossSectionL">Input:expCrossSectionL</param>
        /// <param name="expCrossSectionT">Input:expCrossSectionT</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateRowExists_RailcarConfig_ConsistDefaults(string expCarCategory, string expAxles, string expStreamLiningL , string expStreamLiningT, string expCrossSectionL, string expCrossSectionT, bool expValidateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.RailcarConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.RailCarConfig.SelfInfo);
            
            int rowcount = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.Self.Rows.Count;
            bool foundRow = false;
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.RailCarIndex = i.ToString();
                if (SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.SelfInfo.Exists(0))
                {
                    string currentCarCategory = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CarCategory.GetAttributeValue<string>("Text");
                    string currentAxles = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.Axles.GetAttributeValue<string>("Text");
                    string currentStreamLiningL = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningL.GetAttributeValue<string>("Text");
                    string currentStreamLiningT = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningE.GetAttributeValue<string>("Text");
                    string currentCrossSectionL = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionL.GetAttributeValue<string>("Text");
                    string currentCrossSectionT = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionE.GetAttributeValue<string>("Text");
                    
                    
                    if ((currentCarCategory.Equals(expCarCategory, StringComparison.OrdinalIgnoreCase))
                        && (currentAxles.Equals(expAxles, StringComparison.OrdinalIgnoreCase))
                        && (currentStreamLiningL.Equals(expStreamLiningL, StringComparison.OrdinalIgnoreCase))
                        && (currentStreamLiningT.Equals(expStreamLiningT, StringComparison.OrdinalIgnoreCase))
                        && (currentCrossSectionL.Equals(expCrossSectionL, StringComparison.OrdinalIgnoreCase))
                        && (currentCrossSectionT.Equals(expCrossSectionT, StringComparison.OrdinalIgnoreCase)))
                    {
                        foundRow = true;
                        break;
                    }
                }
            }
            
            
            if(foundRow == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected RailCar Config row in Consist Defaults Form  was found with the value -: CarCategory as {" + expCarCategory + "} ,Axles as {" + expAxles + "} ,StreamLiningL as {" + expStreamLiningL + "} ,StreamLiningT as {" + expStreamLiningT + "}, CrossSectionL as {" + expCrossSectionL + "} ,CrossSectionT as {" + expCrossSectionT + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected RailCar Config row in Consist Defaults Form  was not found with the value -: CarCategory as {" + expCarCategory + "} ,Axles as {" + expAxles + "} ,StreamLiningL as {" + expStreamLiningL + "} ,StreamLiningT as {" + expStreamLiningT + "}, CrossSectionL as {" + expCrossSectionL + "} ,CrossSectionT as {" + expCrossSectionT + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected RailCar Config row in Consist Defaults Form  was  not found with the value -: CarCategory as {" + expCarCategory + "} ,Axles as {" + expAxles + "} ,StreamLiningL as {" + expStreamLiningL + "} ,StreamLiningT as {" + expStreamLiningT + "}, CrossSectionL as {" + expCrossSectionL + "} ,CrossSectionT as {" + expCrossSectionT + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected RailCar Config row in Consist Defaults Form  was found with the value -: CarCategory as {" + expCarCategory + "} ,Axles as {" + expAxles + "} ,StreamLiningL as {" + expStreamLiningL + "} ,StreamLiningT as {" + expStreamLiningT + "}, CrossSectionL as {" + expCrossSectionL + "} ,CrossSectionT as {" + expCrossSectionT + "}");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Insert Row in TrainGroup under ConfigDefaults
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="description">Input:description</param>
        /// <param name="automaticAssignedWork">Input:automaticAssignedWork</param>
        /// <param name="restrictedScheduleCreation">Input:restrictedScheduleCreation</param>
        /// <param name="doNotPlan">Input:doNotPlan</param>
        /// <param name="passenger">Input:passenger</param>
        /// <param name="helper">Input:helper</param>
        /// <param name="delayThreshold">Input:delayThreshold</param>
        /// <param name="planningCategory">Input:planningCategory</param>
        /// <param name="earlyThreshold">Input:earlyThreshold</param>
        /// <param name="lateThreshold">Input:lateThreshold</param>
        /// <param name="shortCrewLife">Input:shortCrewLife</param>
        /// <param name="color">Input:color</param>
        /// <param name="costCategory">Input:costCategory</param>
        /// <param name="timeFactor">Input:timeFactor</param>
        /// <param name="accelDecel">Input:accelDecel</param>
        /// <param name="maxClearAheadInterval">Input:maxClearAheadInterval</param>
        /// <param name="minClearAheadInterval">Input:minClearAheadInterval</param>
        /// <param name="enableManualRouting">Input:enableManualRouting</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_InsertRow_TrainGroup_ConfigDefaults(string trainGroup, string description, bool automaticAssignedWork, bool restrictedScheduleCreation,bool doNotPlan,bool passenger, bool helper, string delayThreshold, string planningCategory, string earlyThreshold, string lateThreshold,string shortCrewLife, string color, string costCategory,string maxDeratedSpeed, string timeFactor, string accelDecel, string maxClearAheadInterval, string minClearAheadInterval, bool autoHelper, bool enableManualRouting, string expectedFeedback, bool reset,bool apply, bool closeForms)
        {
            int startIndex = 0;
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.TrainGroupInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo);
            if (SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo.Exists(0))
            {
                SystemConfigurationrepo.TrainGroupIndex = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Rows.Count.ToString();
                
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.InsertRowButtonInfo,SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.SelfInfo);
                
                SystemConfigurationrepo.TrainGroupIndex = startIndex.ToString();

                
                //set Train Group
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.PressKeys(trainGroup);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                //set Description
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.PressKeys(description);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                //set Automatic Assigned Work
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.SelfInfo);
                if (automaticAssignedWork)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.False.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkText.PressKeys("{TAB}");
                
                //set Restricted Schedule Creation
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.SelfInfo);
                if (restrictedScheduleCreation)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationList.True.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationText.PressKeys("{TAB}");
                
                
                //set Do Not Plan
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.SelfInfo);
                if (doNotPlan)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.True.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanText.PressKeys("{TAB}");
                
                //set Passenger
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.SelfInfo);
                if (passenger)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.True.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerText.PressKeys("{TAB}");
                
                //set Helper
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.SelfInfo);
                if (helper)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.True.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperText.PressKeys("{TAB}");
                
                //set Delay Threshold
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.PressKeys(delayThreshold);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set Planning Category
                SystemConfigurationrepo.PlanningCategory = planningCategory;
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.PlanningCategoryListItemByPlanningCategoryInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.SelfInfo);
                
                
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryText.PressKeys("{TAB}");
                
                
                //set Early Threshold
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.PressKeys(earlyThreshold);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set late Threshold
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.PressKeys(lateThreshold);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set short Crew Life
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.PressKeys(shortCrewLife);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set color On Network Visibility Console
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.PressKeys(color);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                
                //set Cost Category
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.PressKeys(costCategory);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                //set max Derated Speed
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.PressKeys(maxDeratedSpeed);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set Time Factor
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.PressKeys(timeFactor);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                //set Accel/Decel
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.PressKeys(accelDecel);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set Max Clear Ahead Interval
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.PressKeys(maxClearAheadInterval);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set Min Clear Ahead Interval
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.Click();
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.PressKeys(minClearAheadInterval);
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.PressKeys("{TAB}");
                
                //Check if this kicked up some Feedback
                if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                    }
                    return;
                }
                
                //set Helper
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.SelfInfo);
                if (autoHelper)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.True.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperText.PressKeys("{TAB}");
                
                //set Helper
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingTextInfo,
                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.SelfInfo);
                if (enableManualRouting)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.True.Select();
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.False.Select();
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingText.PressKeys("{TAB}");
                
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
                
            }
            else
            {
                Ranorex.Report.Failure("Train Group Tab in Train Default Data Form does not exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo, SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                Ranorex.Report.Info("Row inserted successfully to ConsistConfig Tab in Train Default Data Form Form");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Delete Consist Configt Row by Locomotive Key
        /// </summary>
        /// <param name="locomotiveKey">Input:locomotiveKey </param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData(string locomotiveKey, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.Self.Rows.Count;
            bool foundRow = false;
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.EngineConfigIndex = i.ToString();
                string currentLocomotiveKey = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.LocomotiveKey.GetAttributeValue<string>("Text");
                if (currentLocomotiveKey == locomotiveKey)
                {
                    foundRow = true;
                    if (SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.MenuCellMenu.SelfInfo);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.MenuCellMenu.SelfInfo);
                        
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                        
                        if (SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.Self.Rows.Count < rowCount)
                        {
                            Ranorex.Report.Success("Row got deleted Successfully , Deleted Value are: locomotiveKey value as {" + locomotiveKey + "} in under Train Default Data Form ");
                        } else {
                            Ranorex.Report.Failure("Was unable to delete the row with locomotiveKey value as {" + locomotiveKey + "}");
                        }
                        
                    }
                    break;
                }
                
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find row with locomotiveKey as  {" + locomotiveKey + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the locomotiveKey value in the form", SystemConfigurationrepo.Train_Default_Data.Self.Element);
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.Train_Default_Data.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To NS_Delete Consist Config Row by TrainGroup
        /// </summary>
        /// <param name="locomotiveKey">Input:locomotiveKey </param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteConsistConfigRowByTrainGroup_TrainDefaultData(string trainGroup, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.ConsistConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.ConsistConfig.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.Self.Rows.Count;
            bool foundRow = false;
            
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.ConsistConfigIndex = i.ToString();
                string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupText.GetAttributeValue<string>("Text");
                
                if (currentTrainGroup == trainGroup)
                {
                    foundRow = true;
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Self.Element.EnsureVisible();
                    if (SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.MenuCellMenu.SelfInfo);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.MenuCellMenu.SelfInfo);
                        
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                        
                        if (SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.Self.Rows.Count < rowCount)
                        {
                            Ranorex.Report.Success("Row got deleted Successfully , Deleted Value are: trainGroup value as {" + trainGroup + "} in under Train Default Data Form ");
                        } else {
                            Ranorex.Report.Failure("Was unable to delete the row with trainGroup value as {" + trainGroup + "}");
                        }
                    }
                    break;
                }
                
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find row with trainGroup as  {" + trainGroup + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the trainGroup value in the form", SystemConfigurationrepo.Train_Default_Data.Self.Element);
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.Train_Default_Data.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
            
        }
        
        /// <summary>
        /// To DeleteRailCartRowByCarCategory
        /// </summary>
        /// <param name="carCategory">Input:carCategory </param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteRailCartRowByCarCategory_TrainDefaultData(string carCategory, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.RailcarConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.RailCarConfig.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.Self.Rows.Count;
            bool foundRow = false;
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.RailCarIndex = i.ToString();
                string currentCarCategory = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CarCategory.GetAttributeValue<string>("Text");
                if (currentCarCategory.ToUpper() == carCategory.ToUpper())
                {
                    foundRow = true;
                    if (SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.MenuCellMenu.SelfInfo);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.MenuCellMenu.SelfInfo);
                        
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                        
                        if (SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.Self.Rows.Count < rowCount)
                        {
                            Ranorex.Report.Success("Row got deleted Successfully , Deleted Value are: Car Category value as {" + carCategory + "} in under Train Default Data Form ");
                        } else {
                            Ranorex.Report.Failure("Was unable to delete the row with Car Category value as {" + carCategory + "}");
                        }
                        
                    }
                    break;
                }
                
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find row with carCategory as  {" + carCategory + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the carCategory value in the form", SystemConfigurationrepo.Train_Default_Data.Self.Element);
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.Train_Default_Data.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To DeleteTrainGrouptRow_byTrainGroup
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_DeleteTrainGrouptRowByTrainGroup_TrainDefaultData(string trainGroup, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.TrainGroupInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo);
            
            int rowcount = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Rows.Count;
            bool foundRow = false;
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.TrainGroupIndex = i.ToString();
                string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.GetAttributeValue<string>("Text");
                if (currentTrainGroup == trainGroup)
                {
                    foundRow = true;
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Self.Element.EnsureVisible();
                    if (SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MenuCellInfo.Exists(0))
                    {
                        GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MenuCellInfo,
                                                                       SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.MenuCellMenu.SelfInfo);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.MenuCellMenu.DeleteRowInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.MenuCellMenu.SelfInfo);
                        
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,
                                                                                              SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
                        if (SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Rows.Count < rowcount)
                        {
                            Ranorex.Report.Success("Row got deleted Successfully , Deleted Value are: Train Group value as {" + trainGroup + "} in under Train Default Data Form ");
                        } else {
                            Ranorex.Report.Failure("Was unable to delete the row with Train Group value as {" + trainGroup + "}");
                        }
                        
                    }
                    break;
                }
                
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find row with trainGroup as  {" + trainGroup + "} to delete");
                Ranorex.Report.Screenshot("Unable to find the trainGroup value in the form", SystemConfigurationrepo.Train_Default_Data.Self.Element);
            }
            //To Close the form
            if(closeForm && SystemConfigurationrepo.Train_Default_Data.SelfInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify EngineConfig in ConsistDefaults
        /// </summary>
        /// <param name="locomotiveKey">Input:locomotiveKey </param>
        /// <param name="maxSpeed">Input:maxSpeed </param>
        /// <param name="weight">Input:weight </param>
        /// <param name="length">Input:length </param>
        /// <param name="HP">Input:HP </param>
        /// <param name="axles">Input:axles </param>
        /// <param name="crossSection">Input:crossSection </param>
        /// <param name="streamLiningCoeffL">Input:streamLiningCoeffL </param>
        /// <param name="streamLiningCoeffE">Input:streamLiningCoeffE </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyEngineConfigByLocomotiveKey_TrainDefaultData(string locomotiveKey, string newMaxSpeed, string newWeight, string newLength, string newHP, string newAxles, string newCrossSection, string newStreamLiningCoeffL, string newStreamLiningCoeffT, string expectedFeedback, bool apply,bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.Self.Rows.Count;
            
            bool foundRow = false;
            
            string currentLocomotiveKey = "";
            string currentMaxSpeed = "";
            string currentWeight = "";
            string currentLength = "";
            string currentHP = "";
            string currentAxles = "";
            string currentCrossSection = "";
            string currentStreamLiningCoeffL = "";
            string currentStreamLiningCoeffT = "";
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.EngineConfigIndex = i.ToString();
                
                currentLocomotiveKey = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.LocomotiveKey.GetAttributeValue<string>("Text");
                
                if (currentLocomotiveKey.Equals(locomotiveKey,StringComparison.OrdinalIgnoreCase))
                {
                    currentMaxSpeed =SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MaxSpeed.GetAttributeValue<string>("Text");
                    currentWeight = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Weight.GetAttributeValue<string>("Text");
                    currentLength = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Length.GetAttributeValue<string>("Text");
                    currentHP =SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.HP.GetAttributeValue<string>("Text");
                    currentAxles = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Axles.GetAttributeValue<string>("Text");
                    currentCrossSection = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.CrossSection.GetAttributeValue<string>("Text");
                    currentStreamLiningCoeffL = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffL.GetAttributeValue<string>("Text");
                    currentStreamLiningCoeffT = SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffT.GetAttributeValue<string>("Text");
                    foundRow = true;
                    break;
                }
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find opsta {" + locomotiveKey + "} to modify");
                Ranorex.Report.Screenshot("Unable to find the Opsta value in the form", SystemConfigurationrepo.Train_Default_Data.EngineConfig.Self.Element);
            }
            
            else
            {
                if(!currentMaxSpeed.Equals(newMaxSpeed,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.MaxSpeed.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newMaxSpeed);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the MaxSpeed value  to {" + newMaxSpeed + "}" );
                }
                else
                {
                    Ranorex.Report.Info("MaxSpeed already set to {" + newMaxSpeed + "}.");
                }
                if(!currentWeight.Equals(newWeight,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Weight.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newWeight);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Weight value  to {" + newWeight + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Weight already set to {" + newWeight + "}.");
                }
                
                if(!currentLength.Equals(newLength,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Length.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newLength);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Length value  to {" + newLength + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Lenght already set to {" + newLength + "}.");
                }
                
                if(!currentAxles.Equals(newAxles,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.HP.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newHP);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the HP value  to {" + newHP + "}" );
                }
                else
                {
                    Ranorex.Report.Info("HP already set to {" + newHP + "}.");
                }
                
                if(!currentAxles.Equals(newAxles,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.Axles.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newAxles);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Axles value  to {" + newAxles + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Axles already set to {" + newAxles + "}.");
                }
                
                if(!currentCrossSection.Equals(newCrossSection,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.CrossSection.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newCrossSection);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the CrossSection value  to {" + newCrossSection + "}" );
                }
                else
                {
                    Ranorex.Report.Info("CrossSection already set to {" + newCrossSection + "}.");
                }
                if(!currentStreamLiningCoeffL.Equals(newStreamLiningCoeffL,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffL.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newStreamLiningCoeffL);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the StreamLiningCoeffL value  to {" + newStreamLiningCoeffL + "}" );
                }
                else
                {
                    Ranorex.Report.Info("StreamLiningCoeffL already set to {" + newStreamLiningCoeffL + "}.");
                }
                
                
                if(!currentStreamLiningCoeffT.Equals(newStreamLiningCoeffT,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.EngineConfigTableRowByEngineConfigIndex.StreamLiningCoeffT.Click();
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newStreamLiningCoeffT);
                    SystemConfigurationrepo.Train_Default_Data.EngineConfig.EngineConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the StreamLiningCoeffT value  to {" + newStreamLiningCoeffT + "}" );
                }
                else
                {
                    Ranorex.Report.Info("StreamLiningCoeffT already set to {" + newStreamLiningCoeffT + "}.");
                }
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
            }
            
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify ConsistConfig in ConsistDefaults
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="newTrainCategory">Input:newTrainCategory </param>
        /// <param name="newLoad">Input:newLoad </param>
        /// <param name="newEmpties">Input:newEmpties </param>
        /// <param name="newTonnage">Input:newTonnage </param>
        /// <param name="newLength">Input:newLength </param>
        /// <param name="newCarCategory">Input:newCarCategory </param>
        /// <param name="newEnginesNumber">Input:newEnginesNumber </param>
        /// <param name="newLocomotiveKey">Input:newLocomotiveKey </param>
        /// <param name="newHeight">Input:newHeight </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyConsistConfigByTrainGroup_TrainDefaultData(string trainGroup, string newTrainCategory, string newLoad, string newEmpties, string newTonnage, string newLength, string newCarCategory, string newEnginesNumber, string newLocomotiveKey, string newHeight, string expectedFeedback, bool apply, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);

            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);

            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.ConsistConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.ConsistConfig.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.Self.Rows.Count;
            bool foundRow = false;
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.ConsistConfigIndex = i.ToString();
                SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Self.Element.EnsureVisible();
                
                string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupText.GetAttributeValue<string>("Text");
                if (currentTrainGroup.Equals(trainGroup,StringComparison.OrdinalIgnoreCase))
                {
                    
                    foundRow = true;
                    break;
                }
            }
            
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find opsta {" + trainGroup + "} to modify");
                Ranorex.Report.Screenshot("Unable to find the Opsta value in the form", SystemConfigurationrepo.Train_Default_Data.ConsistConfig.Self.Element);
            }
            else
            {
                
                string currentTrainCategory = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryText.GetAttributeValue<string>("Text");
                
                if(!currentTrainCategory.Equals(newTrainCategory,StringComparison.OrdinalIgnoreCase))
                {
                    
                    SystemConfigurationrepo.TrainCategory = newTrainCategory;
                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryTextInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.TrainCategoryListItemByTrainCategoryInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryList.SelfInfo);
                    
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the TrainCategory value  to {" + newTrainCategory + "}" );
                }
                else
                {
                    Ranorex.Report.Info("TrainCategory already set to {" + newTrainCategory + "}.");
                }
                string currentLoad = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Loads.GetAttributeValue<string>("Text");
                if(!currentLoad.Equals(newLoad,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Loads.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newLoad);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Loads.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Load value  to {" + newLoad + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Load already set to {" + newLoad + "}.");
                }
                string 	currentEmpties = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Empties.GetAttributeValue<string>("Text");
                if(!currentEmpties.Equals(newEmpties,StringComparison.OrdinalIgnoreCase))
                {
                    
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Empties.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newEmpties);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Empties.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Empties value  to {" + newEmpties + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Empties already set to {" + newEmpties + "}.");
                }
                
                string currentTonnage = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Tonnage.GetAttributeValue<string>("Text");
                if(!currentTonnage.Equals(newTonnage,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Tonnage.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newTonnage);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Tonnage.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Tonnage value  to {" + newTonnage + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Tonnage already set to {" + newTonnage + "}.");
                }
                string currentLength = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Length.GetAttributeValue<string>("Text");
                if(!currentLength.Equals(newLength,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Length.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newLength);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Length.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Length value  to {" + newLength + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Lenght already set to {" + newLength + "}.");
                }
                string currentCarCategory = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryText.GetAttributeValue<string>("Text");
                if(!currentCarCategory.Equals(newCarCategory,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.CarCategory = newCarCategory;
                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryTextInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.CarCategoryListitemByCarCategoryInfo,
                                                                      SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryList.SelfInfo);
                    
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the CarCategory value  to {" + newCarCategory + "}" );
                }
                else
                {
                    Ranorex.Report.Info("CarCategory already set to {" + newCarCategory + "}.");
                }
                string 	currentEnginesNumber = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.NumberOfEngines.GetAttributeValue<string>("Text");
                if(!currentEnginesNumber.Equals(newEnginesNumber,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.NumberOfEngines.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newEnginesNumber);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.NumberOfEngines.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the EnginesNumber value  to {" + newEnginesNumber + "}" );
                }
                else
                {
                    Ranorex.Report.Info("EnginesNumber already set to {" + newEnginesNumber + "}.");
                }
                string currentLocomotiveKey = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyText.GetAttributeValue<string>("Text");
                if(!currentLocomotiveKey.Equals(newLocomotiveKey,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.LocomotiveKeyIndex = newLocomotiveKey;
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyText.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newCarCategory);
                    
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyText.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the LocomotiveKey value  to {" + newLocomotiveKey + "}" );
                }
                else
                {
                    Ranorex.Report.Info("LocomotiveKey already set to {" + newLocomotiveKey + "}.");
                }
                string currentHeight = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Height.GetAttributeValue<string>("Text");
                if(!currentHeight.Equals(newHeight,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Height.Click();
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text",newHeight);
                    SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Height.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Height value  to {" + newHeight + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Height already set to {" + newHeight + "}.");
                }
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
                
            }
            
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);

            }
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify RailCarConfig in ConsistDefaults
        /// </summary>
        /// <param name="carCategory">Input:carCategory </param>
        /// <param name="axles">Input:axles </param>
        /// <param name="streamLiningL">Input:streamLiningL </param>
        /// <param name="streamLiningE">Input:streamLiningE </param>
        /// <param name="crossSectionL">Input:crossSectionL </param>
        /// <param name="crossSectionE">Input:crossSectionE </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ModifyRailCarConfigByCarCategory_TrainDefaultData(string carCategory, string newAxles, string newStreamLiningL, string newStreamLiningE, string newCrossSectionL, string newCrossSectionE, string expectedFeedback, bool apply, bool closeForm)
        {
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.RailcarConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.RailCarConfig.SelfInfo);
            
            int rowCount = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.Self.Rows.Count;
            bool foundRow = false;
            
            string currentCarCategory = "";
            string currentAxles = "";
            string currentStreamLiningL =  "";
            string currentStreamLiningE =  "";
            string currentCrossSectionL =  "";
            string currentCrossSectionE =  "";
            
            for (int i = 0; i < rowCount; i++)
            {
                SystemConfigurationrepo.RailCarIndex = i.ToString();
                
                currentCarCategory = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CarCategory.GetAttributeValue<string>("Text");
                
                if (currentCarCategory.Equals(carCategory,StringComparison.OrdinalIgnoreCase))
                {
                    currentAxles = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.Axles.GetAttributeValue<string>("Text");
                    currentStreamLiningL = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningL.GetAttributeValue<string>("Text");
                    currentStreamLiningE = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningE.GetAttributeValue<string>("Text");
                    currentCrossSectionE = SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionE.GetAttributeValue<string>("Text");
                    
                    foundRow = true;
                    break;
                }
            }
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find opsta {" + carCategory + "} to modify");
                Ranorex.Report.Screenshot("Unable to find the Opsta value in the form", SystemConfigurationrepo.Train_Default_Data.RailCarConfig.Self.Element);
            }
            
            else
            {
                if(!currentAxles.Equals(newAxles,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.Axles.Click();
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newAxles);
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the Axles value  to {" + newAxles + "}" );
                }
                else
                {
                    Ranorex.Report.Info("Axles already set to {" + newAxles + "}.");
                }
                
                if(!currentStreamLiningL.Equals(newStreamLiningL,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningL.Click();
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newStreamLiningL);
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the StreamLiningL value  to {" + newStreamLiningL + "}" );
                }
                else
                {
                    Ranorex.Report.Info("StreamLiningL already set to {" + newStreamLiningL + "}.");
                }
                
                if(!currentStreamLiningE.Equals(newStreamLiningE,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.StreamLiningE.Click();
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newStreamLiningE);
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the StreamLiningE value  to {" + newStreamLiningE + "}" );
                }
                else
                {
                    Ranorex.Report.Info("StreamLiningE already set to {" + newStreamLiningE + "}.");
                }
                
                if(!currentCrossSectionL.Equals(newCrossSectionL,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionL.Click();
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newCrossSectionL);
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the CrossSectionL value  to {" + newCrossSectionL + "}" );
                }
                else
                {
                    Ranorex.Report.Info("CrossSectionL already set to {" + newCrossSectionL + "}.");
                }
                
                
                if(!currentCrossSectionE.Equals(newCrossSectionE,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.RailCarConfigRowByRailCarIndex.CrossSectionE.Click();
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.Element.SetAttributeValue("Text", newCrossSectionE);
                    SystemConfigurationrepo.Train_Default_Data.RailCarConfig.RailCarConfigTable.TableMaskCellEditor.PressKeys("{TAB}");
                    
                    //Check if this kicked up some Feedback
                    if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                              SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Updated the CrossSectionE value  to {" + newCrossSectionE + "}" );
                }
                else
                {
                    Ranorex.Report.Info("CrossSectionE already set to {" + newCrossSectionE + "}.");
                }
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
            }
            
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo,SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Validate RowExists in ConsistConfig tab under ConsistDefaults
        /// </summary>
        /// <param name="expTrainGroup">Input:expCarCategory </param>
        /// <param name="expTrainCategory">Input:expAxles</param>
        /// <param name="expLoads">Input:expStreamLiningL</param>
        /// <param name="expEmpties">Input:expStreamLiningT</param>
        /// <param name="expTonnage">Input:expCrossSectionL</param>
        /// <param name="expLength">Input:expCrossSectionT</param>
        /// <param name="expCarCategory">Input:expCrossSectionT</param>
        /// <param name="expNumberOfEngines">Input:expCrossSectionT</param>
        /// <param name="expLocomotiveKey">Input:expCrossSectionT</param>
        /// <param name="expHeight">Input:expCrossSectionT</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_ValidateConsistConfigRowExists_TrainDefaultData(string expTrainGroup, string expTrainCategory, string expLoads, string expEmpties, string expTonnage, string expLength, string expCarCategory ,string expNumberOfEngines, string expLocomotiveKey, string expHeight, bool validateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.ConsistConfigInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.SelfInfo);
            int rowcount = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.Self.Rows.Count;
            bool foundRow = false;
            
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.ConsistConfigIndex = i.ToString();
                if (SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.SelfInfo.Exists(0))
                {
                    string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainGroup.TrainGroupText.GetAttributeValue<string>("Text");
                    string currentTrainCategory = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.TrainCategory.TrainCategoryText.GetAttributeValue<string>("Text");
                    string currentLoads = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Loads.GetAttributeValue<string>("Text");
                    string currentEmpties = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Empties.GetAttributeValue<string>("Text");
                    string currentTonnage = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Tonnage.GetAttributeValue<string>("Text");
                    string currentLength = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Length.GetAttributeValue<string>("Text");
                    string currentCarCategory = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.CarCategory.CarCategoryText.GetAttributeValue<string>("Text");
                    string currentNumberOfEngines = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.NumberOfEngines.GetAttributeValue<string>("Text");
                    string currentLocomotiveKey = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.LocomotiveKey.LocomotiveKeyText.GetAttributeValue<string>("Text");
                    string currentHeight = SystemConfigurationrepo.Train_Default_Data.ConsistConfig.ConsistConfigTable.ConsistConfigRowByConsistConfigIndex.Height.GetAttributeValue<string>("Text");
                    
                    if ((currentTrainGroup.Equals(expTrainGroup, StringComparison.OrdinalIgnoreCase))
                        && (currentTrainCategory.Equals(expTrainCategory, StringComparison.OrdinalIgnoreCase))
                        && (currentLoads.Equals(expLoads, StringComparison.OrdinalIgnoreCase))
                        && (currentEmpties.Equals(expEmpties, StringComparison.OrdinalIgnoreCase))
                        && (currentTonnage.Equals(expTonnage, StringComparison.OrdinalIgnoreCase))
                        && (currentLength.Equals(expLength, StringComparison.OrdinalIgnoreCase))
                        && (currentCarCategory.Equals(expCarCategory, StringComparison.OrdinalIgnoreCase))
                        && (currentNumberOfEngines.Equals(expNumberOfEngines, StringComparison.OrdinalIgnoreCase))
                        && (currentLocomotiveKey.Equals(expLocomotiveKey, StringComparison.OrdinalIgnoreCase))
                        && (currentHeight.Equals(expHeight, StringComparison.OrdinalIgnoreCase)))
                    {
                        foundRow = true;
                        break;
                    }
                }
            }
            if(foundRow == validateExist)
            {
                if (validateExist)
                {
                    Ranorex.Report.Success("Expected Consist Config row in Consist Defaults Form  was found with the value -: TrainGroup as {" + expTrainGroup + "} ,TrainCategory as {" + expTrainCategory + "} ,Loads as {" + expLoads + "} ,Empties as {" + expEmpties + "}, Tonnage as {" + expTonnage + "} ,Length as {" + expLength + "} , CarCategory as {" + expCarCategory + "} ,NumberOfEngines as {" + expNumberOfEngines + "}, LocomotiveKey as {" + expLocomotiveKey + "} ,Height as {" + expHeight + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected Consist Config row in Consist Defaults Form  was not found with the value -: TrainGroup as {" + expTrainGroup + "} ,TrainCategory as {" + expTrainCategory + "} ,Loads as {" + expLoads + "} ,Empties as {" + expEmpties + "}, Tonnage as {" + expTonnage + "} ,Length as {" + expLength + "} , CarCategory as {" + expCarCategory + "} ,NumberOfEngines as {" + expNumberOfEngines + "}, LocomotiveKey as {" + expLocomotiveKey + "} ,Height as {" + expHeight + "}");
                }
            }
            else
            {
                if (validateExist)
                {
                    Ranorex.Report.Failure("Expected Consist Config row in Consist Defaults Form  was not found with the value -: TrainGroup as {" + expTrainGroup + "} ,TrainCategory as {" + expTrainCategory + "} ,Loads as {" + expLoads + "} ,Empties as {" + expEmpties + "}, Tonnage as {" + expTonnage + "} ,Length as {" + expLength + "} ,CarCategory as {" + expCarCategory + "} ,NumberOfEngines as {" + expNumberOfEngines + "}, LocomotiveKey as {" + expLocomotiveKey + "} ,Height as {" + expHeight + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Consist Config row in Consist Defaults Form  was found with the value -: TrainGroup as {" + expTrainGroup + "} ,TrainCategory as {" + expTrainCategory + "} ,Loads as {" + expLoads + "} ,Empties as {" + expEmpties + "}, Tonnage as {" + expTonnage + "} ,Length as {" + expLength + "} , CarCategory as {" + expCarCategory + "} ,NumberOfEngines as {" + expNumberOfEngines + "}, LocomotiveKey as {" + expLocomotiveKey + "} ,Height as {" + expHeight + "}");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify Row  in TrackAuthority Number Range
        /// </summary>
        /// <param name="minimum">Input:minimum </param>
        /// <param name="newMinimum">Input:newMinimum</param>
        /// <param name="maximum">Input:maximum</param>
        /// <param name="newMaximum">Input:newMaximum</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange(string newMinimum, string newMaximum, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrackAuthorityNumberRangeInfo,
                                                                          SystemConfigurationrepo.Track_Authority_Number_Range.SelfInfo);
            
            string currentMinimum = SystemConfigurationrepo.Track_Authority_Number_Range.MinimumText.GetAttributeValue<string>("Text");
            string currentMaximum = SystemConfigurationrepo.Track_Authority_Number_Range.MaximumText.GetAttributeValue<string>("Text");

            if (!currentMinimum.Equals(newMinimum,StringComparison.OrdinalIgnoreCase))
            {
            	//SystemConfigurationrepo.Track_Authority_Number_Range.MinimumText.Click();
                SystemConfigurationrepo.Track_Authority_Number_Range.MinimumText.PressKeys(newMinimum);
                SystemConfigurationrepo.Track_Authority_Number_Range.MinimumText.PressKeys("{TAB}");
                
                Ranorex.Report.Info("Updated the Minimum value to {" + newMinimum + "}" );
            }
            else
            {
                Ranorex.Report.Info("Minimum value already set to {" + newMinimum + "}.");
            }
            
            if (!currentMaximum.Equals(newMaximum,StringComparison.OrdinalIgnoreCase))
            {
            	//SystemConfigurationrepo.Track_Authority_Number_Range.MaximumText.Click();
                SystemConfigurationrepo.Track_Authority_Number_Range.MaximumText.PressKeys(newMaximum);
                SystemConfigurationrepo.Track_Authority_Number_Range.MaximumText.PressKeys("{TAB}");
                
                Ranorex.Report.Info("Updated the Minimum value  {" + newMaximum + "}" );
            }
            else
            {
                Ranorex.Report.Info("Minimum value already set to {" + newMaximum + "}.");
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Track_Authority_Number_Range.ApplyButtonInfo,SystemConfigurationrepo.Track_Authority_Number_Range.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Track_Authority_Number_Range.CancelButtonInfo, SystemConfigurationrepo.Track_Authority_Number_Range.SelfInfo);
            }
        }
        
        /// <summary>
        /// To  ValidateRow in TrackAuthorityNumberRange
        /// </summary>
        /// <param name="expMinimum">Input:expMinimum </param>
        /// <param name="expMaximum">Input:expMaximum</param>
        /// <param name="expValidateExist">Input:expValidateExist</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTrackAuthorityNumberRange_TrackAuthorityNumberRange(string expMinimum, string expMaximum, bool expValidateExist, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrackAuthorityNumberRangeInfo,
                                                                          SystemConfigurationrepo.Track_Authority_Number_Range.SelfInfo);
        	bool foundValue = false;
        	string currentMinimum = "";
        	string currentMaximum = "";
        	
            if (SystemConfigurationrepo.Track_Authority_Number_Range.SelfInfo.Exists(0))
            {
                currentMinimum = SystemConfigurationrepo.Track_Authority_Number_Range.MinimumText.GetAttributeValue<string>("Text");
                currentMaximum = SystemConfigurationrepo.Track_Authority_Number_Range.MaximumText.GetAttributeValue<string>("Text");
                if (currentMinimum.Equals(expMinimum,StringComparison.OrdinalIgnoreCase) && currentMaximum.Equals(expMaximum,StringComparison.OrdinalIgnoreCase))
                {
                    foundValue = true;
                }
            }
            else
            {
                Ranorex.Report.Failure("Track_Authority_Number_Range Form does not exist");
            }
            if(foundValue == expValidateExist)
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Success("Expected Track_Authority_Number_Range value was found with the value as {" + expMinimum + "} and {" + expMaximum + "}");
                }
                else
                {
                    Ranorex.Report.Success("Expected Track_Authority_Number_Range value was not found with the value as {" + expMinimum + "} and {" + expMaximum + "}");
                }
            }
            else
            {
                if (expValidateExist)
                {
                    Ranorex.Report.Failure("Expected Track_Authority_Number_Range value {" + expMinimum + "} and {" + expMaximum + "} are not matching with the current {" + currentMinimum + "} and {" + currentMaximum + "}");
                }
                else
                {
                   Ranorex.Report.Failure("Expected Track_Authority_Number_Range value {" + expMinimum + "} and {" + expMaximum + "} got matched with the current {" + currentMinimum + "} and {" + currentMaximum + "}");
                }
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Track_Authority_Number_Range.CancelButtonInfo, SystemConfigurationrepo.Track_Authority_Number_Range.SelfInfo);
            }
        }
        
        /// <summary>
        /// To  ModifyRow TrainGroup in ConfigDefaults
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="description">Input:description</param>
        /// <param name="automaticAssignedWork">Input:automaticAssignedWork</param>
        /// <param name="restrictedScheduleCreation">Input:restrictedScheduleCreation</param>
        /// <param name="doNotPlan">Input:doNotPlan</param>
        /// <param name="passenger">Input:passenger</param>
        /// <param name="helper">Input:helper</param>
        /// <param name="delayThreshold">Input:delayThreshold</param>
        /// <param name="planningCategory">Input:planningCategory</param>
        /// <param name="earlyThreshold">Input:earlyThreshold</param>
        /// <param name="lateThreshold">Input:lateThreshold</param>
        /// <param name="shortCrewLife">Input:shortCrewLife</param>
        /// <param name="color">Input:color</param>
        /// <param name="costCategory">Input:costCategory</param>
        /// <param name="timeFactor">Input:timeFactor</param>
        /// <param name="accelDecel">Input:accelDecel</param>
        /// <param name="maxClearAheadInterval">Input:maxClearAheadInterval</param>
        /// <param name="minClearAheadInterval">Input:minClearAheadInterval</param>
        /// <param name="enableManualRouting">Input:enableManualRouting</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyRow_TrainGroup_ConfigDefaults(string trainGroup, string description, bool automaticAssignedWork, bool restrictedScheduleCreation,bool doNotPlan,bool passenger,
                                                                  bool helper, string delayThreshold, string planningCategory, string earlyThreshold, string lateThreshold,string shortCrewLife,
                                                                  string color, string costCategory,string maxDeratedSpeed, string timeFactor, string accelDecel, string maxClearAheadInterval,
                                                                  string minClearAheadsToReserve, bool autoHelper, bool enableManualRouting, string expectedFeedback, bool reset,bool apply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.TrainGroupInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo);
            if (SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo.Exists(0))
            {
                int rowcount = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Rows.Count;
                bool foundRow = false;
                for (int i = 0; i < rowcount; i++)
                {
                    SystemConfigurationrepo.TrainGroupIndex = i.ToString();
                    
                    string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.GetAttributeValue<string>("Text");
                    
                    if (currentTrainGroup.Equals(trainGroup,StringComparison.OrdinalIgnoreCase))
                    {
                        foundRow = true;
                        break;
                    }
                }
                if (!foundRow)
                {
                    Ranorex.Report.Failure("Row not found ");
                }
                else
                {
                    string currentDescription = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.GetAttributeValue<string>("Text");
                    if (!currentDescription.Equals(description,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text",description);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the description value to {" + description + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("description already set to {" + description + "}.");
                    }
                    
                    bool currentAutomaticAssignedWork = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkText.GetAttributeValue<bool>("Selected");
                    if (!currentAutomaticAssignedWork.Equals(automaticAssignedWork))
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkTextInfo,
                                                                  
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.SelfInfo);
                        if (automaticAssignedWork)
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.True.Select();
                            Ranorex.Report.Info("Updated the automaticAssignedWork value to {" + automaticAssignedWork + "}" );
                        }
                        else
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.False.Select();
                            Ranorex.Report.Info("Updated the automaticAssignedWork value to {" + automaticAssignedWork + "}.");
                        }
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkText.PressKeys("{TAB}");
                        
                    }
                    bool currentRestrictedScheduleCreation = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationText.GetAttributeValue<bool>("Selected");
                    if (!currentRestrictedScheduleCreation.Equals(restrictedScheduleCreation))
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkList.SelfInfo);
                        if (restrictedScheduleCreation)
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationList.True.Select();
                            Ranorex.Report.Info("Updated the automaticAssignedWork value to {" + automaticAssignedWork + "}" );
                        }
                        else
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationList.False.Select();
                            Ranorex.Report.Info("Updated the automaticAssignedWork value to {" + automaticAssignedWork + "}" );
                        }
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationText.PressKeys("{TAB}");
                    }
                    bool currentDoNotPlan = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanText.GetAttributeValue<bool>("Selected");
                    if (!currentDoNotPlan.Equals(doNotPlan))
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.SelfInfo);
                        if (doNotPlan)
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.True.Select();
                            Ranorex.Report.Info("Updated the doNotPlan value to {" + doNotPlan + "}" );
                        }
                        else
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanList.False.Select();
                            Ranorex.Report.Info("Updated the doNotPlan value to {" + doNotPlan + "}");
                        }
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanText.PressKeys("{TAB}");
                    }
                    bool currentPassenger = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerText.GetAttributeValue<bool>("Selected");
                    if (!currentPassenger.Equals(passenger))
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.SelfInfo);
                        if (passenger)
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.True.Select();
                            Ranorex.Report.Info("Updated the passenger value to {" + passenger + "}" );
                        }
                        else
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerList.False.Select();
                            Ranorex.Report.Info("Updated the passenger value to {" + passenger + "}.");
                        }
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerText.PressKeys("{TAB}");
                    }
                    bool currentHelper = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperText.GetAttributeValue<bool>("Selected");
                    if (!currentHelper.Equals(helper))
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.SelfInfo);
                        if (helper)
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.True.Select();
                            Ranorex.Report.Info("Updated the helper value to {" + helper + "}" );
                        }
                        else
                        {
                            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperList.False.Select();
                            Ranorex.Report.Info("helper already set to {" + helper + "}.");
                        }
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperText.PressKeys("{TAB}");
                    }

                    string currentDelayThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.GetAttributeValue<string>("Text");
                    if (!currentDelayThreshold.Equals(delayThreshold,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", delayThreshold);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the delayThreshold value to {" + delayThreshold + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("delayThreshold already set to {" + delayThreshold + "}.");
                    }
                    string currentPlanningCategory = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryText.GetAttributeValue<string>("Text");
                    if (!currentPlanningCategory.Equals(planningCategory,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.PlanningCategory = planningCategory;
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.SelfInfo);
                        
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.PlanningCategoryListItemByPlanningCategoryInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryList.SelfInfo);
                        
                        
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryText.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the planningCategory value to {" + planningCategory + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("planningCategory already set to {" + planningCategory + "}.");
                    }
                    string currentEarlyThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.GetAttributeValue<string>("Text");
                    if (!currentEarlyThreshold.Equals(earlyThreshold,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", earlyThreshold);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                    }
                    string currentLateThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.GetAttributeValue<string>("Text");
                    if (!currentLateThreshold.Equals(lateThreshold,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", lateThreshold);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the lateThreshold value to {" + lateThreshold + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("planningCategory already set to {" + lateThreshold + "}.");
                    }
                    string currentShortCrewLife = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.GetAttributeValue<string>("Text");
                    if (!currentShortCrewLife.Equals(shortCrewLife,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", shortCrewLife);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the shortCrewLife value to {" + shortCrewLife + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("shortCrewLife already set to {" + shortCrewLife + "}.");
                    }
                    string currentColor = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.GetAttributeValue<string>("Text");
                    if (!currentColor.Equals(color,StringComparison.OrdinalIgnoreCase))
                        
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.PressKeys(color);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ColorOnNetworkVisibilityConsole.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the color value to {" + color + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("color already set to {" + color + "}.");
                    }
                    string currentCostCategory = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.GetAttributeValue<string>("Text");
                    if (!currentCostCategory.Equals(costCategory,StringComparison.OrdinalIgnoreCase))
                        
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", costCategory);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the costCategory value to {" + costCategory + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("costCategory already set to {" + costCategory + "}.");
                    }
                    string currentMaxDeratedSpeed = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.GetAttributeValue<string>("Text");
                    if (!currentMaxDeratedSpeed.Equals(maxDeratedSpeed,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", maxDeratedSpeed);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the maxDeratedSpeed value to {" + maxDeratedSpeed + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("maxDeratedSpeed already set to {" + maxDeratedSpeed + "}.");
                    }
                    string currentTimeFactor = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.GetAttributeValue<string>("Text");
                    if (!currentTimeFactor.Equals(timeFactor,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", timeFactor);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        
                        //Check if this kicked up some Feedback
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the timeFactor value to {" + timeFactor + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("timeFactor already set to {" + timeFactor + "}");
                    }
                    string currentAccelDecel = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.GetAttributeValue<string>("Text");
                    if (!currentAccelDecel.Equals(accelDecel,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", accelDecel);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the accelDecel value to {" + accelDecel + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("accelDecel already set to {" + accelDecel + "}");
                    }
                    string currentMaxClearAheadInterval = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.GetAttributeValue<string>("Text");
                    if (!currentMaxClearAheadInterval.Equals(maxClearAheadInterval,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", maxClearAheadInterval);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the maxClearAheadInterval value to {" + maxClearAheadInterval + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("maxClearAheadInterval already set to {" + maxClearAheadInterval + "}.");
                    }
                    string currentMinClearAheadsToReserve = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.GetAttributeValue<string>("Text");
                    if (!currentMaxClearAheadInterval.Equals(minClearAheadsToReserve,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.Click();
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.Element.SetAttributeValue("Text", minClearAheadsToReserve);
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TableMaskCellEditor.PressKeys("{TAB}");
                        //Check if this kicked up some Feedback
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Default_Data.Feedback, expectedFeedback))
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo,SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Default_Data.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("Updated the minClearAheadInterval value to {" + minClearAheadsToReserve + "}" );
                    }
                    else
                    {
                        Ranorex.Report.Info("minClearAheadInterval already set to {" + minClearAheadsToReserve + "}.");
                    }
                    bool currentAutoHelper = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperText.GetAttributeValue<bool>("Selected");
                    if (!currentAutoHelper.Equals(autoHelper))
                        GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperTextInfo,
                                                                  SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.SelfInfo);
                    if (autoHelper)
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.True.Select();
                        Ranorex.Report.Info("Updated the autoHelper value to {" + autoHelper + "}" );
                    }
                    else
                    {
                        SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperList.False.Select();
                        Ranorex.Report.Info("Updated the autoHelper value to {" + autoHelper + "}" );
                    }
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperText.PressKeys("{TAB}");
                    
                }
                bool currentEnableManualRouting = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingText.GetAttributeValue<bool>("Selected");
                if (!currentEnableManualRouting.Equals(enableManualRouting))
                    GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingTextInfo,
                                                              SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.SelfInfo);
                if (enableManualRouting)
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.True.Select();
                    Ranorex.Report.Info("Updated the enableManualRouting value to {" + enableManualRouting + "}" );
                }
                else
                {
                    SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingList.False.Select();
                    Ranorex.Report.Info("Updated the enableManualRouting value to {" + enableManualRouting + "}" );
                }
                SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingText.PressKeys("{TAB}");
                
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("Form does not exist");
            }
            
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo, SystemConfigurationrepo.Train_Default_Data.ResetButtonInfo);
            }
            // to Apply the Form
            if (apply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo, SystemConfigurationrepo.Train_Default_Data.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        [UserCodeMethod]
        public static void NS_ModifyDelayType_DelayParameters(string delayTypeCode, string description, string priority, bool reviewNeeded, bool delayEnabled,
                                                              bool deleteEnabled, bool mechanical, string delayCap, string expectedFeedback, bool apply, bool closeForm)
        {
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.DelayParametersInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.DelayParametersTabs.DelayTypeInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayParametersTabs.DelayTypeInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.SelfInfo);
            SystemConfigurationrepo.DelayTypeCode = delayTypeCode;
            SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Self.EnsureVisible();
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.CodeInfo.Exists(0))
            {
                Ranorex.Report.Error("Unable to find Delay Type row with code {" + delayTypeCode + "}");
                if(closeForm)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo, SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                }
            }
            
            //Description
            if(!description.Equals(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Description.DescriptionText.Text))
            {
                SystemConfigurationrepo.Description = description;
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Description.DescriptionText.Click();
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Description.DescriptionList.DescriptionListItemByDescriptionListText.Element.EnsureVisible();
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Description.DescriptionList.DescriptionListItemByDescriptionListText.Click();
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Description.DescriptionText.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //Priority
            if(!priority.Equals(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Priority.Text))
            {
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Priority.Click();
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Priority.Element.SetAttributeValue("Text",priority);
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Priority.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //Review Needed
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededText.Text.Equals(reviewNeeded.ToString().ToUpper()))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededTextInfo,
                                                          SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededList.SelfInfo);
                if(reviewNeeded)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededList.TrueInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededList.SelfInfo);
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededList.FalseInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededList.SelfInfo);
                }
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.ReviewNeeded.ReviewNeededText.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //Delay Enabled
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledText.Text.Equals(delayEnabled.ToString().ToUpper()))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledTextInfo,
                                                          SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledList.SelfInfo);
                if(delayEnabled)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledList.TrueInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledList.SelfInfo);
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledList.FalseInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledList.SelfInfo);
                }
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayEnabled.DelayEnabledText.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //Delete Enabled
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledText.Text.Equals(deleteEnabled.ToString().ToUpper()))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledTextInfo,
                                                          SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledList.SelfInfo);
                if(deleteEnabled)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledList.TrueInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledList.SelfInfo);
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledList.FalseInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledList.SelfInfo);
                }
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DeleteEnabled.DeleteEnabledText.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //Mechanical
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalText.Text.Equals(mechanical.ToString().ToUpper()))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalTextInfo,
                                                          SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalList.SelfInfo);
                if(mechanical)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalList.TrueInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalList.SelfInfo);
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalList.FalseInfo,
                                                                      SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalList.SelfInfo);
                }
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.Mechanical.MechanicalText.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            //DelayCap
            if(!SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayCap.Text.Equals(delayCap))
            {
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayCap.Click();
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayCap.Element.SetAttributeValue("Text",delayCap);
                SystemConfigurationrepo.Delay_Parameters.DelayType.DelayTypeTable.DelayTypeRowByDelayTypeCode.DelayCap.PressKeys("{TAB}");
                Report.Info("Checking Feedback.");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
            }
            // to Apply the Form
            if (apply)
            {
                SystemConfigurationrepo.Delay_Parameters.ApplyButton.Click();
                Report.Info("Changes applied");
                if (!CheckFeedback(SystemConfigurationrepo.Delay_Parameters.Feedback, expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo,SystemConfigurationrepo.Delay_Parameters.ResetButtonInfo);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Delay_Parameters.SelfInfo);
                    }
                    return;
                }
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Delay_Parameters.OkButtonInfo,SystemConfigurationrepo.Delay_Parameters.SelfInfo);
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + " but didn't find any that matched");
            }
        }
        /// <summary>
        /// To NS_Validate TrainGroup Row Exists in TrainDefaultData
        /// </summary>
        /// <param name="trainGroup">Input:trainGroup </param>
        /// <param name="description">Input:description</param>
        /// <param name="automaticAssignedWork">Input:automaticAssignedWork</param>
        /// <param name="restrictedScheduleCreation">Input:restrictedScheduleCreation</param>
        /// <param name="doNotPlan">Input:doNotPlan</param>
        /// <param name="passenger">Input:passenger</param>
        /// <param name="helper">Input:helper</param>
        /// <param name="delayThreshold">Input:delayThreshold</param>
        /// <param name="planningCategory">Input:planningCategory</param>
        /// <param name="earlyThreshold">Input:earlyThreshold</param>
        /// <param name="lateThreshold">Input:lateThreshold</param>
        /// <param name="shortCrewLife">Input:shortCrewLife</param>
        /// <param name="color">Input:color</param>
        /// <param name="costCategory">Input:costCategory</param>
        /// <param name="timeFactor">Input:timeFactor</param>
        /// <param name="accelDecel">Input:accelDecel</param>
        /// <param name="maxClearAheadInterval">Input:maxClearAheadInterval</param>
        /// <param name="minClearAheadInterval">Input:minClearAheadInterval</param>
        /// <param name="enableManualRouting">Input:enableManualRouting</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainGroupRowExists_TrainDefaultData(string expTrainGroup, string expDescription, bool expAutomaticAssignedWork, bool expRestrictedScheduleCreation,bool expDoNotPlan,bool expPassenger,
                                                                           bool expHelper, string expDelayThreshold, string expPlanningCategory, string expEarlyThreshold, string expLateThreshold,string expShortCrewLife,
                                                                           string expColor, string expCostCategory,string expMaxDeratedSpeed, string expTimeFactor, string expAccelDecel, string expMaxClearAheadInterval,
                                                                           string expMinClearAheadInterval, bool expAutoHelper, bool expEnableManualRouting,  bool validateExist, bool closeForm)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainDefaultDataInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Default_Data.ConsistDefaultsTabs.TrainGroupInfo,
                                                                          SystemConfigurationrepo.Train_Default_Data.TrainGroup.SelfInfo);
            
            int rowcount = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Rows.Count;
            bool foundRow = false;
            SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.Self.Element.EnsureVisible();
            for (int i = 0; i < rowcount; i++)
            {
                SystemConfigurationrepo.TrainGroupIndex = i.ToString();

                if (SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.SelfInfo.Exists(0))
                {
                    string currentTrainGroup = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TrainGroup.GetAttributeValue<string>("Text");
                    string currentDescription = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Description.GetAttributeValue<string>("Text");
                    bool currentAutomaticAssignedWork = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutomaticAssignedWork.AutomaticAssignedWorkText.GetAttributeValue<bool>("Selected");
                    bool currentRestrictedScheduleCreation = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.RestrictedScheduleCreation.RestrictedScheduleCreationText.GetAttributeValue<bool>("Selected");
                    bool currentDoNotPlan = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DoNotPlan.DoNotPlanText.GetAttributeValue<bool>("Selected");
                    bool currentPassenger = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Passenger.PassengerText.GetAttributeValue<bool>("Selected");
                    bool currentHelper = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.Helper.HelperText.GetAttributeValue<bool>("Selected");
                    string currentDelayThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.DelayThreshold.GetAttributeValue<string>("Text");
                    string currentPlanningCategory = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.PlanningCategory.PlanningCategoryText.GetAttributeValue<string>("Text");
                    string currentEarlyThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EarlyThreshold.GetAttributeValue<string>("Text");
                    string currentLateThreshold = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.LateThreshold.GetAttributeValue<string>("Text");
                    string currentShortCrewLife = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.ShortCrewLife.GetAttributeValue<string>("Text");
                    string currentCostCategory = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.CostCategory.GetAttributeValue<string>("Text");
                    string currentMaxDeratedSpeed = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxDeratedSpeed.GetAttributeValue<string>("Text");
                    string currentTimeFactor = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.TimeFactor.GetAttributeValue<string>("Text");
                    string currentAccelDecel = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AccelDecel.GetAttributeValue<string>("Text");
                    string currentMaxClearAheadInterval = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MaxClearAheadInterval.GetAttributeValue<string>("Text");
                    string currentMinClearAheadsToReserve = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.MinClearAheadsToReserve.GetAttributeValue<string>("Text");
                    bool currentAutoHelper = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.AutoHelper.AutoHelperText.GetAttributeValue<bool>("Selected");
                    bool currentEnableManualRouting = SystemConfigurationrepo.Train_Default_Data.TrainGroup.TrainGroupTable.TrainGroupRowByTrainGroupIndex.EnableManualRouting.EnableManualRoutingText.GetAttributeValue<bool>("Selected");
                    
                    if ((currentTrainGroup.Trim().Equals(expTrainGroup, StringComparison.OrdinalIgnoreCase))
                        && (currentDescription.Trim().Equals(expDescription, StringComparison.OrdinalIgnoreCase))
                        && (currentAutomaticAssignedWork.Equals(expAutomaticAssignedWork))
                        && (currentRestrictedScheduleCreation.Equals(expRestrictedScheduleCreation))
                        && (currentDoNotPlan.Equals(expDoNotPlan))
                        && (currentPassenger.Equals(expPassenger))
                        && (currentHelper.Equals(expHelper))
                        && (currentPlanningCategory.Trim().Equals(expPlanningCategory, StringComparison.OrdinalIgnoreCase))
                        && (currentEarlyThreshold.Trim().Equals(expEarlyThreshold, StringComparison.OrdinalIgnoreCase))
                        && (currentLateThreshold.Trim().Equals(expLateThreshold, StringComparison.OrdinalIgnoreCase))
                        && (currentShortCrewLife.Trim().Equals(expShortCrewLife, StringComparison.OrdinalIgnoreCase))
                        && (currentCostCategory.Trim().Equals(expCostCategory, StringComparison.OrdinalIgnoreCase))
                        && (currentMaxDeratedSpeed.Trim().Equals(expMaxDeratedSpeed, StringComparison.OrdinalIgnoreCase))
                        && (currentTimeFactor.Trim().Equals(expTimeFactor, StringComparison.OrdinalIgnoreCase))
                        && (currentAccelDecel.Trim().Equals(expAccelDecel, StringComparison.OrdinalIgnoreCase))
                        && (currentMaxClearAheadInterval.Trim().Equals(expMaxClearAheadInterval, StringComparison.OrdinalIgnoreCase))
                        && (currentMinClearAheadsToReserve.Trim().Equals(expMinClearAheadInterval, StringComparison.OrdinalIgnoreCase))
                        && (currentAutoHelper.Equals(expAutoHelper))
                        && (currentEnableManualRouting.Equals(expEnableManualRouting))
                        && (currentDelayThreshold.Trim().Equals(expDelayThreshold, StringComparison.OrdinalIgnoreCase)))
                    {
                        foundRow = true;
                        break;
                    }
                }
            }
            if(foundRow == validateExist)
            {
                if (validateExist)
                {
                    Ranorex.Report.Success("Expected Train Group row in Consist Defaults Form  was found with the values as expected");
                }
                else
                {
                    Ranorex.Report.Success("Expected Train Group row in Consist Defaults Form  was not found with the values as expected");
                }
            }
            else
            {
                if (validateExist)
                {
                    Ranorex.Report.Failure("Expected Train Group row in Consist Defaults Form  was not found");
                }
                else
                {
                    Ranorex.Report.Failure("Expected Train Group row in Consist Defaults Form  was found");
                }
            }
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Default_Data.CancelButtonInfo, SystemConfigurationrepo.Train_Default_Data.SelfInfo);
            }
        }
        
        /// <summary>
        /// To Modify_EnableSystemIssuancesOfTrainClearances_TrainClearance
        /// </summary>
        /// <param name="EnableSystemIssuancesOfTrainClearances">Input:EnableSystemIssuancesOfTrainClearances </param>
        /// <param name="EnableSystemIssuancesOfTrainClearancesHours">Input:EnableSystemIssuancesOfTrainClearancesHours</param>
        /// <param name="EnableSystemIssuancesOfTrainClearancesMinutes">Input:EnableSystemIssuancesOfTrainClearancesMinutes</param>
        /// <param name="restrictedScheduleCreation">Input:restrictedScheduleCreation</param>
        /// <param name="EnableSystemIssuancesOfTrainClearancesMinutes">Input:EnableSystemIssuancesOfTrainClearancesMinutes</param>
        /// <param name="enableManualRouting">Input:enableManualRouting</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams(bool enableSystemIssuancesOfTrainClearances, string enableSystemIssuancesOfTrainClearancesHours, string enableSystemIssuancesOfTrainClearancesMinutes, string expectedFeedback, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                bool currentEnableSystemIssuancesOfTrainClearances  = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesCheckBox.GetAttributeValue<bool>("Selected");
                string currentEnableSystemIssuancesOfTrainClearancesHoursText  = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.GetAttributeValue<string>("Text");
                string currentEnableSystemIssuancesOfTrainClearancesMinutesText  = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesMinutesText.GetAttributeValue<string>("Text");
                if (enableSystemIssuancesOfTrainClearances)
                {
                    if (currentEnableSystemIssuancesOfTrainClearances != enableSystemIssuancesOfTrainClearances)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesCheckBoxInfo,
                                                                                             SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursTextInfo);
                        
                    }
                    if (!currentEnableSystemIssuancesOfTrainClearancesHoursText.Equals(enableSystemIssuancesOfTrainClearancesHours,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.Click();
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.Element.SetAttributeValue("Text", enableSystemIssuancesOfTrainClearancesHours);
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.PressKeys("{TAB}");
                        //Check if this kicked up some FeedBack
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                        {
                            SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Clearance.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("values EnableSystemIssuancesOfTrainClearancesHours {" + enableSystemIssuancesOfTrainClearancesHours + "} is set");
                    }
                    else
                    {
                        Ranorex.Report.Info("Value already set to {" + enableSystemIssuancesOfTrainClearancesHours + "}");
                    }
                    if (!currentEnableSystemIssuancesOfTrainClearancesMinutesText.Equals(enableSystemIssuancesOfTrainClearancesMinutes,StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesMinutesText.Click();
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesMinutesText.Element.SetAttributeValue("Text", enableSystemIssuancesOfTrainClearancesMinutes);
                        SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.PressKeys("{TAB}");
                        //Check if this kicked up some FeedBack
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                        {
                            SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Clearance.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("values EnableSystemIssuancesOfTrainClearancesMinutes {" + enableSystemIssuancesOfTrainClearancesMinutes + "} is set");
                    }
                    else
                    {
                        Ranorex.Report.Info("Value already set to {" + enableSystemIssuancesOfTrainClearancesMinutes + "}");
                    }
                }
                else
                {
                    //Clicking the other checkbox to disable the current one, cannot fill in boxes after
                    if (currentEnableSystemIssuancesOfTrainClearances != enableSystemIssuancesOfTrainClearances)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesCheckBoxInfo,
                                                                                             SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursTextInfo);
                        
                    }
                }
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
                
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify_EnableATaskToManuallyIssueTrainClearance_TrainClearance
        /// </summary>
        /// <param name="EnableATaskToManuallyIssueTrainClearance">Input:EnableATaskToManuallyIssueTrainClearance </param>
        /// <param name="EnableATaskToManuallyIssueTrainClearanceHours">Input:EnableATaskToManuallyIssueTrainClearanceHours</param>
        /// <param name="EnableATaskToManuallyIssueTrainClearanceMinutes">Input:EnableATaskToManuallyIssueTrainClearanceMinutes</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams(bool enableATaskToManuallyIssueTrainClearance, string enableATaskToManuallyIssueTrainClearanceHours, string enableATaskToManuallyIssueTrainClearanceMinutes, string expectedFeedback, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                bool currentEnableATaskToManuallyIssueTrainClearance = SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceCheckBox.GetAttributeValue<bool>("Selected");
                string currentEnableATaskToManuallyIssueTrainClearanceHoursText = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.GetAttributeValue<string>("Text");
                string currentEnableATaskToManuallyIssueTrainClearanceMinutesText = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesMinutesText.GetAttributeValue<string>("Text");
                
                if (enableATaskToManuallyIssueTrainClearance)
                {
                    if(currentEnableATaskToManuallyIssueTrainClearance != enableATaskToManuallyIssueTrainClearance)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceCheckBoxInfo,
                                                                                             SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceHoursTextInfo);
                    }
                    
                    if (!currentEnableATaskToManuallyIssueTrainClearanceHoursText.Equals(enableATaskToManuallyIssueTrainClearanceHours, StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceHoursText.Click();
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceHoursText.Element.SetAttributeValue("Text", enableATaskToManuallyIssueTrainClearanceHours);
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceHoursText.PressKeys("{TAB}");
                        //Check if this kicked up some FeedBack
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                        {
                            SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Clearance.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("values EnableATaskToManuallyIssueTrainClearanceHours {" + enableATaskToManuallyIssueTrainClearanceHours + "} is set");
                    }
                    else
                    {
                        Ranorex.Report.Info("Value already set to {" + enableATaskToManuallyIssueTrainClearanceHours + "}");
                    }
                    if (!currentEnableATaskToManuallyIssueTrainClearanceMinutesText.Equals(enableATaskToManuallyIssueTrainClearanceMinutes, StringComparison.OrdinalIgnoreCase))
                    {
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceMinutesText.Click();
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceMinutesText.Element.SetAttributeValue("Text", enableATaskToManuallyIssueTrainClearanceMinutes);
                        SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceMinutesText.PressKeys("{TAB}");
                        //Check if this kicked up some FeedBack
                        if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                        {
                            SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                                  SystemConfigurationrepo.Train_Clearance.SelfInfo);
                            }
                            return;
                        }
                        Ranorex.Report.Info("values EnableATaskToManuallyIssueTrainClearanceMinutes {" + enableATaskToManuallyIssueTrainClearanceMinutes + "} is set");
                    }
                    else
                    {
                        Ranorex.Report.Info("Value already set to {" + enableATaskToManuallyIssueTrainClearanceMinutes + "}");
                    }
                } else {
                    //Clicking the other checkbox to disable the current one, cannot fill in boxes after
                    if(currentEnableATaskToManuallyIssueTrainClearance != enableATaskToManuallyIssueTrainClearance)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesCheckBoxInfo,
                                                                                             SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursTextInfo);
                    }
                    
                }
                
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("Configure Train Clearance Params Form does not exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        
        /// <summary>
        /// To ModifyTrainClearanceParams_TrainClearance
        /// </summary>
        /// <param name="NumberRangeAvailableToTrainClearancesMinimumText">Input:NumberRangeAvailableToTrainClearancesMinimumText </param>
        /// <param name="NumberRangeAvailableToTrainClearancesMaximumText">Input:NumberRangeAvailableToTrainClearancesMaximumText </param>
        /// <param name="NumberRangeAvailableToBulletinItemsMinimumText">Input:NumberRangeAvailableToBulletinItemsMinimumText</param>
        /// <param name="ProhibitedTrackAlertEventIntervalMinuteText">Input:ProhibitedTrackAlertEventIntervalMinuteText</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTrainClearanceParams_ConfigureTrainClearanceParams(string numberRangeAvailableToTrainClearancesMinimum, string numberRangeAvailableToTrainClearancesMaximum, string numberRangeAvailableToBulletinItemsMinimum, string numberRangeAvailableToBulletinItemsMaximum, string prohibitedTrackAlertEventIntervalHour, string prohibitedTrackAlertEventIntervalMinute, string expectedFeedback, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                string currentNumberRangeAvailableToTrainClearancesMinimumText  = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMinimumText.GetAttributeValue<string>("Text");
                string currentNumberRangeAvailableToTrainClearancesMaximumText  = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMaximumText.GetAttributeValue<string>("Text");
                string currentNumberRangeAvailableToBulletinItemsMinimumText  = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMinimumText.GetAttributeValue<string>("Text");
                string currentNumberRangeAvailableToBulletinItemsMaximumText  = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMaximumText.GetAttributeValue<string>("Text");
                string currentProhibitedTrackAlertEventIntervalHourText  = SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalHourText.GetAttributeValue<string>("Text");
                string currentProhibitedTrackAlertEventIntervalMinuteText  = SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalMinuteText.GetAttributeValue<string>("Text");
                
                SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMinimumText.Click();
                if(!currentNumberRangeAvailableToTrainClearancesMinimumText.Equals(numberRangeAvailableToTrainClearancesMinimum, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMinimumText.PressKeys(numberRangeAvailableToTrainClearancesMinimum);
                    Ranorex.Report.Info("values NumberRangeAvailableToTrainClearancesMinimumText {" + numberRangeAvailableToTrainClearancesMinimum + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + numberRangeAvailableToTrainClearancesMinimum + "}");
                }
                SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMinimumText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if (!currentNumberRangeAvailableToTrainClearancesMaximumText.Equals(numberRangeAvailableToTrainClearancesMaximum, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMaximumText.PressKeys(numberRangeAvailableToTrainClearancesMaximum);
                    Ranorex.Report.Info("values NumberRangeAvailableToTrainClearancesMaximumText {" + numberRangeAvailableToTrainClearancesMaximum + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + numberRangeAvailableToTrainClearancesMaximum + "}");
                }
                
                SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMaximumText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if(!currentNumberRangeAvailableToBulletinItemsMinimumText.Equals(numberRangeAvailableToBulletinItemsMinimum, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMinimumText.PressKeys(numberRangeAvailableToBulletinItemsMinimum);
                    Ranorex.Report.Info("values NumberRangeAvailableToBulletinItemsMinimumText {" + numberRangeAvailableToBulletinItemsMinimum + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + numberRangeAvailableToBulletinItemsMinimum + "}");
                }
                
                SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMinimumText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if (!currentNumberRangeAvailableToBulletinItemsMaximumText.Equals(numberRangeAvailableToBulletinItemsMaximum, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMaximumText.PressKeys(numberRangeAvailableToBulletinItemsMaximum);
                    Ranorex.Report.Info("values NumberRangeAvailableToBulletinItemsMaximumText {" + numberRangeAvailableToBulletinItemsMaximum + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + numberRangeAvailableToBulletinItemsMaximum + "}");
                }
                
                SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMaximumText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if(!currentProhibitedTrackAlertEventIntervalHourText.Equals(prohibitedTrackAlertEventIntervalHour, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalHourText.PressKeys(prohibitedTrackAlertEventIntervalHour);
                    Ranorex.Report.Info("values ProhibitedTrackAlertEventIntervalHourText {" + prohibitedTrackAlertEventIntervalHour + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + prohibitedTrackAlertEventIntervalHour + "}");
                }
                
                SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalHourText.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if (!currentProhibitedTrackAlertEventIntervalMinuteText.Equals(prohibitedTrackAlertEventIntervalMinute, StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalMinuteText.PressKeys(prohibitedTrackAlertEventIntervalMinute);
                    Ranorex.Report.Info("values ProhibitedTrackAlertEventIntervalMinuteText {" + prohibitedTrackAlertEventIntervalMinute + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {" + prohibitedTrackAlertEventIntervalMinute + "}");
                }
                
                SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalMinuteText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance.Feedback, expectedFeedback))
                {
                    SystemConfigurationrepo.Train_Clearance.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
                    }
                    return;
                }
                
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Didn't get expected Feedback of {" + expectedFeedback + "}.");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form does not exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Modify_TC1_TrainClearance
        /// </summary>
        /// <param name="TC1">Input:TC1 </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTC1_ConfigureTrainClearanceParams(string tC1, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TC1Index = "0";
            
            string currentTC1 = SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC1Table.TC1RowByTC1Index.TC1.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if(currentTC1 == null || !currentTC1.Equals(tC1,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC1Table.TC1RowByTC1Index.TC1.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC1Table.TC1RowByTC1Index.TC1.PressKeys(tC1);
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC1Table.TC1RowByTC1Index.TC1.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TC1 {" + tC1 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tC1 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Modify_TC2_TrainClearance
        /// </summary>
        /// <param name="TC2">Input:TC2 </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTC2_ConfigureTrainClearanceParams(string tC2, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TC2Index = "0";
            
            string currentTC2 = SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC2Table.TC2RowByTC2Index.TC2.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTC2 == null || !currentTC2.Equals(tC2,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC2Table.TC2RowByTC2Index.TC2.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC2Table.TC2RowByTC2Index.TC2.PressKeys(tC2);
                    SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC2Table.TC2RowByTC2Index.TC2.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TC2 {" + tC2 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tC2 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify_TSS1_TrainClearance
        /// </summary>
        /// <param name="TSS1">Input:TSS1 </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTSS1_ConfigureTrainClearanceParams(string tSS1, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TSS1Index = "0";
            
            string currentTSS1 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS1Table.TSS1RowByTSS1Index.TSS1.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTSS1 == null || !currentTSS1.Equals(tSS1,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS1Table.TSS1RowByTSS1Index.TSS1.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS1Table.TSS1RowByTSS1Index.TSS1.PressKeys(tSS1);
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS1Table.TSS1RowByTSS1Index.TSS1.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TSS1 {" + tSS1 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tSS1 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify_TSS2_TrainClearance
        /// </summary>
        /// <param name="TSS2">Input:TSS2 </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTSS2_ConfigureTrainClearanceParams(string tSS2, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TSS2Index = "0";
            
            string currentTSS2 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS2Table.TSS2RowByTSS2Index.TSS2.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTSS2 == null || !currentTSS2.Equals(tSS2,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS2Table.TSS2RowByTSS2Index.TSS2.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS2Table.TSS2RowByTSS2Index.TSS2.PressKeys(tSS2);
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS2Table.TSS2RowByTSS2Index.TSS2.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TSS2 {" + tSS2 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tSS2 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify_TSS3_TrainClearance
        /// </summary>
        /// <param name="TSS3">Input:TSS3 </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTSS3_ConfigureTrainClearanceParams(string tSS3, bool reset, bool clickApply, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TSS3Index = "0";
            
            string currentTSS3 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS3Table.TSS3RowByTSS3Index.TSS3.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTSS3 == null || !currentTSS3.Equals(tSS3,StringComparison.OrdinalIgnoreCase))
                {
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS3Table.TSS3RowByTSS3Index.TSS3.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS3Table.TSS3RowByTSS3Index.TSS3.PressKeys(tSS3);
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS3Table.TSS3RowByTSS3Index.TSS3.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TSS3 {" + tSS3 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tSS3 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Modify_TSS4_TrainClearance
        /// </summary>
        /// <param name="TSS4">Input:TSS4 </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyTSS4_ConfigureTrainClearanceParams(string tSS4, bool clickApply, bool reset, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            SystemConfigurationrepo.TSS4Index = "0";
            
            string currentTSS4 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS4Table.TSS4RowByTSS4Index.TSS4.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTSS4 == null || !currentTSS4.Equals(tSS4,StringComparison.OrdinalIgnoreCase))
                {
                    
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS4Table.TSS4RowByTSS4Index.TSS4.Click();
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS4Table.TSS4RowByTSS4Index.TSS4.PressKeys(tSS4);
                    SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS4Table.TSS4RowByTSS4Index.TSS4.PressKeys("{TAB}");
                    
                    Ranorex.Report.Info("values TSS4 {" + tSS4 + "} is set");
                }
                else
                {
                    Ranorex.Report.Info("Value already set to {"+ tSS4 +"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Reset the Form
            if(reset)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance.ResetButtonInfo);
            }
            // to Apply the Form
            if (clickApply)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo,SystemConfigurationrepo.Train_Clearance.ApplyButtonInfo);
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Verify_TSS1_TrainClearance
        /// </summary>
        /// <param name="expTSS1">Input:expTSS1 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTSS1_ConfigureTrainClearanceParams(string expTSS1, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                string currentTSS1 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS1Table.TSS1RowByTSS1Index.TSS1.GetAttributeValue<string>("Text");
                if (currentTSS1.Equals(expTSS1,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TSS1 {" + expTSS1 + "} got matched with Current TSS1 value {" + currentTSS1 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TSS1 {" + expTSS1 + "} but found as Current TSS1 value {" + currentTSS1 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
            
        }
        /// <summary>
        /// To NS_Verify_TSS2_TrainClearance
        /// </summary>
        /// <param name="expTSS2">Input:expTSS2 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTSS2_ConfigureTrainClearanceParams(string expTSS2, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                string currentTSS2 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS2Table.TSS2RowByTSS2Index.TSS2.GetAttributeValue<string>("Text");
                if (currentTSS2.Equals(expTSS2,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TSS2 {" + expTSS2 + "} got matched with Current TSS2 value {" + currentTSS2 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TSS2 {" + expTSS2 + "} but found as Current TSS2 value {" + currentTSS2 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
            
        }
        /// <summary>
        /// To NS_Verify_TSS3_TrainClearance
        /// </summary>
        /// <param name="expTSS3">Input:expTSS3 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTSS3_ConfigureTrainClearanceParams(string expTSS3, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                string currentTSS3 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS3Table.TSS3RowByTSS3Index.TSS3.GetAttributeValue<string>("Text");
                if (currentTSS3.Equals(expTSS3,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TSS3 {" + expTSS3 + "} got matched with Current TSS3 value {" + currentTSS3 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TSS3 {" + expTSS3 + "} but found as Current TSS3 value {" + currentTSS3 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
            
        }
        /// <summary>
        /// To NS_Verify_TSS4_TrainClearance
        /// </summary>
        /// <param name="expTSS4">Input:expTSS4 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTSS4_ConfigureTrainClearanceParams(string expTSS4, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            
            string currentTSS4 = SystemConfigurationrepo.Train_Clearance.TrainSheetSummaryTextBlocks.TSS4Table.TSS4RowByTSS4Index.TSS4.GetAttributeValue<string>("Text");
            
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTSS4.Equals(expTSS4,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TSS4 {" + expTSS4 + "} got matched with Current TSS4 value {" + currentTSS4 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TSS4 {" + expTSS4 + "} but found as Current TSS4 value {" + currentTSS4 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Verify_TC1_TrainClearance
        /// </summary>
        /// <param name="expTC1">Input:expTC1 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTC1_ConfigureTrainClearanceParams(string expTC1, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            string currentTC1 = SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC1Table.TC1RowByTC1Index.TC1.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTC1.Equals(expTC1,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TC1 {" + expTC1 + "} got matched with Current TC1 value {" + currentTC1 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TC1 {" + expTC1 + "} but found as Current TC1 value {" + currentTC1 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To NS_Verify_TC2_TrainClearance
        /// </summary>
        /// <param name="expTC2">Input:expTC2 </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTC2_ConfigureTrainClearanceParams(string expTC2, bool closeForms)
        {
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
                                                                          SystemConfigurationrepo.Train_Clearance.SelfInfo);
            string currentTC2 = SystemConfigurationrepo.Train_Clearance.TrainClearanceTextBlocks.TC2Table.TC2RowByTC2Index.TC2.GetAttributeValue<string>("Text");
            if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
            {
                if (currentTC2.Equals(expTC2,StringComparison.OrdinalIgnoreCase))
                {
                    Ranorex.Report.Success("Expected TC2 {" + expTC2 + "} got matched with Current TC2 value {" + currentTC2 + "}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected TC2 {" + expTC2 + "} but found as Current TC2 value {" + currentTC2 + "}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance Form doesnot exist");
            }
            //To Close the form
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
            }
        }
        /// <summary>
        /// To Validate_TrainClearanceParams_TrainClearance
        /// </summary>
        /// <param name="NumberRangeAvailableToTrainClearancesMinimumText">Input:NumberRangeAvailableToTrainClearancesMinimumText </param>
        /// <param name="NumberRangeAvailableToTrainClearancesMaximumText">Input:NumberRangeAvailableToTrainClearancesMaximumText</param>
        /// <param name="NumberRangeAvailableToBulletinItemsMinimumText">Input:NumberRangeAvailableToBulletinItemsMinimumText</param>
        /// <param name="NumberRangeAvailableToBulletinItemsMinimumText">Input:NumberRangeAvailableToBulletinItemsMinimumText</param>
        /// <param name="ProhibitedTrackAlertEventIntervalHourText">Input:ProhibitedTrackAlertEventIntervalHourText</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainClearanceParams_ConfigureTrainClearanceParams(string numberRangeAvailableToTrainClearancesMinimumText, string numberRangeAvailableToTrainClearancesMaximumText, string numberRangeAvailableToBulletinItemsMinimumText, string numberRangeAvailableToBulletinItemsMaximumText, string prohibitedTrackAlertEventIntervalHourText, string prohibitedTrackAlertEventIntervalMinuteText, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
        	                                                              SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
        	{
        		string currentNumberRangeAvailableToTrainClearancesMinimumText = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMinimumText.GetAttributeValue<string>("Text");
        		string currentNumberRangeAvailableToTrainClearancesMaximumText = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToTrainClearancesMaximumText.GetAttributeValue<string>("Text");
        		string currentNumberRangeAvailableToBulletinItemsMinimumText = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMinimumText.GetAttributeValue<string>("Text");
        		string currentNumberRangeAvailableToBulletinItemsMaximumText = SystemConfigurationrepo.Train_Clearance.NumberRangeAvailableToBulletinItemsMaximumText.GetAttributeValue<string>("Text");
        		string currentProhibitedTrackAlertEventIntervalHourText = SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalHourText.GetAttributeValue<string>("Text");
        		string currentProhibitedTrackAlertEventIntervalMinuteText = SystemConfigurationrepo.Train_Clearance.ProhibitedTrackAlertEventIntervalMinuteText.GetAttributeValue<string>("Text");
        		
        		if(currentNumberRangeAvailableToTrainClearancesMinimumText.Equals(numberRangeAvailableToTrainClearancesMinimumText,StringComparison.OrdinalIgnoreCase) &&
        		   currentNumberRangeAvailableToTrainClearancesMaximumText.Equals(numberRangeAvailableToTrainClearancesMaximumText,StringComparison.OrdinalIgnoreCase) &&
        		   currentNumberRangeAvailableToBulletinItemsMinimumText.Equals(numberRangeAvailableToBulletinItemsMinimumText,StringComparison.OrdinalIgnoreCase) &&
        		   currentNumberRangeAvailableToBulletinItemsMaximumText.Equals(numberRangeAvailableToBulletinItemsMaximumText,StringComparison.OrdinalIgnoreCase) &&
        		   currentProhibitedTrackAlertEventIntervalHourText.Equals(prohibitedTrackAlertEventIntervalHourText,StringComparison.OrdinalIgnoreCase) &&
        		   currentProhibitedTrackAlertEventIntervalMinuteText.Equals(prohibitedTrackAlertEventIntervalMinuteText,StringComparison.OrdinalIgnoreCase))
        		{
        			
        			Ranorex.Report.Success("Expected NumberRangeAvailableToTrainClearancesMinimumText {" + numberRangeAvailableToTrainClearancesMinimumText + "} ,  NumberRangeAvailableToTrainClearancesMaximumText {" + numberRangeAvailableToTrainClearancesMaximumText + "}, NumberRangeAvailableToBulletinItemsMinimumText {" + numberRangeAvailableToBulletinItemsMinimumText + "}, NumberRangeAvailableToBulletinItemsMaximumText {" + numberRangeAvailableToBulletinItemsMaximumText + "}, ProhibitedTrackAlertEventIntervalHourText {" + prohibitedTrackAlertEventIntervalHourText + "}, ProhibitedTrackAlertEventIntervalMinuteText {" + prohibitedTrackAlertEventIntervalMinuteText + "} got matched with currentNumberRangeAvailableToTrainClearancesMinimumText {" + currentNumberRangeAvailableToTrainClearancesMinimumText + "},currentNumberRangeAvailableToTrainClearancesMaximumText {" + currentNumberRangeAvailableToTrainClearancesMaximumText + "},currentNumberRangeAvailableToBulletinItemsMinimumText {" + currentNumberRangeAvailableToBulletinItemsMinimumText + "},currentNumberRangeAvailableToBulletinItemsMaximumText {" + currentNumberRangeAvailableToBulletinItemsMaximumText + "},currentProhibitedTrackAlertEventIntervalHourText {" + currentProhibitedTrackAlertEventIntervalHourText + "}and currentProhibitedTrackAlertEventIntervalMinuteText {" + currentProhibitedTrackAlertEventIntervalMinuteText + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected NumberRangeAvailableToTrainClearancesMinimumText {" + numberRangeAvailableToTrainClearancesMinimumText + "} ,  NumberRangeAvailableToTrainClearancesMaximumText {" + numberRangeAvailableToTrainClearancesMaximumText + "}, NumberRangeAvailableToBulletinItemsMinimumText {" + numberRangeAvailableToBulletinItemsMinimumText + "}, NumberRangeAvailableToBulletinItemsMaximumText {" + numberRangeAvailableToBulletinItemsMaximumText + "}, ProhibitedTrackAlertEventIntervalHourText {" + prohibitedTrackAlertEventIntervalHourText + "}, ProhibitedTrackAlertEventIntervalMinuteText {" + prohibitedTrackAlertEventIntervalMinuteText + "} does not matched with currentNumberRangeAvailableToTrainClearancesMinimumText {" + currentNumberRangeAvailableToTrainClearancesMinimumText + "},currentNumberRangeAvailableToTrainClearancesMaximumText {" + currentNumberRangeAvailableToTrainClearancesMaximumText + "},currentNumberRangeAvailableToBulletinItemsMinimumText {" + currentNumberRangeAvailableToBulletinItemsMinimumText + "},currentNumberRangeAvailableToBulletinItemsMaximumText {" + currentNumberRangeAvailableToBulletinItemsMaximumText + "},currentProhibitedTrackAlertEventIntervalHourText {" + currentProhibitedTrackAlertEventIntervalHourText + "}and currentProhibitedTrackAlertEventIntervalMinuteText {" + currentProhibitedTrackAlertEventIntervalMinuteText + "}");
        			 Ranorex.Report.Screenshot("Unable to find the value in the form", SystemConfigurationrepo.Train_Clearance.Self.Element);
    
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Train Clearance Form doesnot exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	}
        }
        /// <summary>
        /// To Validate_EnableATaskToManuallyIssueTrainClearance_TrainClearance
        /// </summary>
        /// <param name="EnableATaskToManuallyIssueTrainClearance">Input:EnableATaskToManuallyIssueTrainClearance </param>
        /// <param name="EnableATaskToManuallyIssueTrainClearanceHours">Input:EnableATaskToManuallyIssueTrainClearanceHours</param>
        /// <param name="EnableATaskToManuallyIssueTrainClearanceMinutes">Input:EnableATaskToManuallyIssueTrainClearanceMinutes</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams(bool enableATaskToManuallyIssueTrainClearance, string enableATaskToManuallyIssueTrainClearanceHours, string enableATaskToManuallyIssueTrainClearanceMinutes, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
        	                                                              SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
        	{
        		bool currentEnableATaskToManuallyIssueTrainClearance = SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceCheckBox.GetAttributeValue<bool>("Selected");
        		string currentEnableATaskToManuallyIssueTrainClearanceHoursText = SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceHoursText.GetAttributeValue<string>("Text");
        		string currentEnableATaskToManuallyIssueTrainClearanceMinutesText = SystemConfigurationrepo.Train_Clearance.EnableATaskToManuallyIssueTrainClearanceMinutesText.GetAttributeValue<string>("Text");

        		if(currentEnableATaskToManuallyIssueTrainClearance.Equals(enableATaskToManuallyIssueTrainClearance) && currentEnableATaskToManuallyIssueTrainClearanceHoursText.Equals(enableATaskToManuallyIssueTrainClearanceHours, StringComparison.OrdinalIgnoreCase) && currentEnableATaskToManuallyIssueTrainClearanceMinutesText.Equals(enableATaskToManuallyIssueTrainClearanceMinutes, StringComparison.OrdinalIgnoreCase))
        		{
        			Ranorex.Report.Success("Expected enableATaskToManuallyIssueTrainClearance {" + enableATaskToManuallyIssueTrainClearance + "} ,  enableATaskToManuallyIssueTrainClearanceHours {" + enableATaskToManuallyIssueTrainClearanceHours + "} and enableATaskToManuallyIssueTrainClearanceMinutes {" + enableATaskToManuallyIssueTrainClearanceMinutes + "}   got matched with currentEnableATaskToManuallyIssueTrainClearance {" + currentEnableATaskToManuallyIssueTrainClearance + "}, currentEnableATaskToManuallyIssueTrainClearanceHoursText {" + currentEnableATaskToManuallyIssueTrainClearanceHoursText + "} and currentEnableATaskToManuallyIssueTrainClearanceMinutesText {" + currentEnableATaskToManuallyIssueTrainClearanceMinutesText + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected enableATaskToManuallyIssueTrainClearance {" + enableATaskToManuallyIssueTrainClearance + "} ,  enableATaskToManuallyIssueTrainClearanceHours {" + enableATaskToManuallyIssueTrainClearanceHours + "} and enableATaskToManuallyIssueTrainClearanceMinutes {" + enableATaskToManuallyIssueTrainClearanceMinutes + "}   does not matched with currentEnableATaskToManuallyIssueTrainClearance {" + currentEnableATaskToManuallyIssueTrainClearance + "}, currentEnableATaskToManuallyIssueTrainClearanceHoursText {" + currentEnableATaskToManuallyIssueTrainClearanceHoursText + "} and currentEnableATaskToManuallyIssueTrainClearanceMinutesText {" + currentEnableATaskToManuallyIssueTrainClearanceMinutesText + "}");
        			Ranorex.Report.Screenshot("Unable to find the value in the form", SystemConfigurationrepo.Train_Clearance.Self.Element);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Train Clearance Form doesnot exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	}
        }
        /// <summary>
        /// To Validate_EnableATaskToManuallyIssueTrainClearance_TrainClearance
        /// </summary>
        /// <param name="enableSystemIssuancesOfTrainClearances">Input:enableSystemIssuancesOfTrainClearances </param>
        /// <param name="enableSystemIssuancesOfTrainClearancesHours">Input:enableSystemIssuancesOfTrainClearancesHours</param>
        /// <param name="enableSystemIssuancesOfTrainClearancesMinutes">Input:enableSystemIssuancesOfTrainClearancesMinutes</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams(bool enableSystemIssuancesOfTrainClearances, string enableSystemIssuancesOfTrainClearancesHours, string enableSystemIssuancesOfTrainClearancesMinutes, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceInfo,
        	                                                              SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	if (SystemConfigurationrepo.Train_Clearance.SelfInfo.Exists(0))
        	{
        		bool currentEnableSystemIssuancesOfTrainClearances = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesCheckBox.GetAttributeValue<bool>("Selected");
        		string currentEnableSystemIssuancesOfTrainClearancesHoursText = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesHoursText.GetAttributeValue<string>("Text");
        		string currentEnableSystemIssuancesOfTrainClearancesMinutesText = SystemConfigurationrepo.Train_Clearance.EnableSystemIssuancesOfTrainClearancesMinutesText.GetAttributeValue<string>("Text");
        		
        		if(currentEnableSystemIssuancesOfTrainClearances.Equals(enableSystemIssuancesOfTrainClearances) && currentEnableSystemIssuancesOfTrainClearancesHoursText.Equals(enableSystemIssuancesOfTrainClearancesHours,StringComparison.OrdinalIgnoreCase) && currentEnableSystemIssuancesOfTrainClearancesMinutesText.Equals(enableSystemIssuancesOfTrainClearancesMinutes,StringComparison.OrdinalIgnoreCase))
        		{
        			Ranorex.Report.Success("Expected enableSystemIssuancesOfTrainClearances {" + enableSystemIssuancesOfTrainClearances + "} ,  enableSystemIssuancesOfTrainClearancesHours {" + enableSystemIssuancesOfTrainClearancesHours + "} and enableSystemIssuancesOfTrainClearancesMinutes {" + enableSystemIssuancesOfTrainClearancesMinutes + "}   got matched with currentEnableSystemIssuancesOfTrainClearances {" + currentEnableSystemIssuancesOfTrainClearances + "}, currentEnableSystemIssuancesOfTrainClearancesHoursText {" + currentEnableSystemIssuancesOfTrainClearancesHoursText + "} and currentEnableSystemIssuancesOfTrainClearancesMinutesText {" + currentEnableSystemIssuancesOfTrainClearancesMinutesText + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected enableSystemIssuancesOfTrainClearances {" + enableSystemIssuancesOfTrainClearances + "} ,  enableSystemIssuancesOfTrainClearancesHours {" + enableSystemIssuancesOfTrainClearancesHours + "} and enableSystemIssuancesOfTrainClearancesMinutes {" + enableSystemIssuancesOfTrainClearancesMinutes + "}   does not matched with currentEnableSystemIssuancesOfTrainClearances {" + currentEnableSystemIssuancesOfTrainClearances + "}, currentEnableSystemIssuancesOfTrainClearancesHoursText {" + currentEnableSystemIssuancesOfTrainClearancesHoursText + "} and currentEnableSystemIssuancesOfTrainClearancesMinutesText {" + currentEnableSystemIssuancesOfTrainClearancesMinutesText + "}");
        			Ranorex.Report.Screenshot("Unable to find the value in the form", SystemConfigurationrepo.Train_Clearance.Self.Element);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Train Clearance Form doesnot exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance.CancelButtonInfo, SystemConfigurationrepo.Train_Clearance.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_ModifyTimeOutValue_CTC_Parameters
        /// </summary>
        /// <param name="timeOutValue">Input:timeOutValue </param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyGlobalSwitchRequestTimeOutValue_CTCParameters(string timeOutValue, string expectedFeedback, bool reset, bool clickApply, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.CTCParametersInfo,
        	                                                              SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	if (SystemConfigurationrepo.CTC_Parameters.SelfInfo.Exists(0))
        	{
        		string currentTimeOutValue = SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.GetAttributeValue<string>("Text");
        		
        		if (!currentTimeOutValue.Equals(timeOutValue,StringComparison.OrdinalIgnoreCase))
        		{
        			SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.Click();
        			SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.Element.SetAttributeValue("Text", timeOutValue);
        			SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.PressKeys("{TAB}");
        			//Check if this kicked up some FeedBack
        			if (!CheckFeedback(SystemConfigurationrepo.CTC_Parameters.Feedback, expectedFeedback))
        			{
        				SystemConfigurationrepo.CTC_Parameters.CancelButton.Click();
        				if (closeForms)
        				{
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo,
        					                                                  SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        				}
        				return;
        			}
        			Ranorex.Report.Info("values TimeOutValue {" + timeOutValue + "} is set");
        		}
        		else
        		{
        			Ranorex.Report.Info("Value already set to {" + timeOutValue + "}");
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("CTC_Parameters Form does not exist");
        		return;
        	}
        	
        	if (expectedFeedback != "")
        	{
        		Ranorex.Report.Failure("Did not find feedback {" + expectedFeedback + "}");
        	}
        	
        	//To Reset the Form
        	if(reset)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.CTC_Parameters.ResetButtonInfo, SystemConfigurationrepo.CTC_Parameters.ResetButtonInfo);
        	}
        	// to Apply the Form
        	if (clickApply)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.CTC_Parameters.ApplyButtonInfo,SystemConfigurationrepo.CTC_Parameters.ApplyButtonInfo);
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo, SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_ValidateTimeOutValue_CTCParameters
        /// </summary>
        /// <param name="expTimeOutValue">Input:expTimeOutValue </param>
        /// <param name="expSwitchAlert">Input:expSwitchAlert</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateGlobalSwitchRequestTimeOutValue_CTCParameters(string expTimeOutValue, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.CTCParametersInfo,
        	                                                              SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	if (SystemConfigurationrepo.CTC_Parameters.SelfInfo.Exists(0))
        	{
        		string currentTimeOutValue = SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.GetAttributeValue<string>("Text");
        		
        		if(currentTimeOutValue.Equals(expTimeOutValue, StringComparison.OrdinalIgnoreCase))
        		{
        			Ranorex.Report.Success("Expected expTimeOutValue {" + expTimeOutValue + "} got matched with currentTimeOutValue {" + currentTimeOutValue + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected expTimeOutValue {" + expTimeOutValue + "} does not matched with currentTimeOutValue {" + currentTimeOutValue + "}");
        			Ranorex.Report.Screenshot("Unable to find the value in the form", SystemConfigurationrepo.CTC_Parameters.Self.Element);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("CTC_Parameters Form doesnot exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo, SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_Modify_CheckBox_CTCParameters
        /// </summary>
        /// <param name="switchAlert">Input:switchAlert </param>
        /// <param name="reset">Input:reset</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_CheckOrUncheckDisableUnresponsiveSwitchAlertCheckbox_CTCParameters(bool switchAlert, bool reset, bool clickApply, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.CTCParametersInfo,
        	                                                              SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	if (SystemConfigurationrepo.CTC_Parameters.SelfInfo.Exists(0))
        	{
        		bool currentSwitchAlert = SystemConfigurationrepo.CTC_Parameters.DisableUnresponsiveSwitchAlertCheckBox.GetAttributeValue<bool>("Selected");
        		
        		if (currentSwitchAlert != switchAlert)
        		{
        			SystemConfigurationrepo.CTC_Parameters.DisableUnresponsiveSwitchAlertCheckBox.Click();
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("CTC_Parameters Form does not exist");
        	}
        	//To Reset the Form
        	if(reset)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.CTC_Parameters.ResetButtonInfo, SystemConfigurationrepo.CTC_Parameters.ResetButtonInfo);
        	}
        	// to Apply the Form
        	if (clickApply)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.CTC_Parameters.ApplyButtonInfo,SystemConfigurationrepo.CTC_Parameters.ApplyButtonInfo);
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo, SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_ValidateCheckBox_CTCParameters
        /// </summary>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters(bool expSwitchAlert, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.CTCParametersInfo,
        	                                                              SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	
        	
        	if (SystemConfigurationrepo.CTC_Parameters.SelfInfo.Exists(0))
        	{
        		bool currentSwitchAlert = SystemConfigurationrepo.CTC_Parameters.DisableUnresponsiveSwitchAlertCheckBox.GetAttributeValue<bool>("Selected");
        		
        		if(currentSwitchAlert.Equals(expSwitchAlert))
        		{
        			Ranorex.Report.Success("Expected expSwitchAlert {" + expSwitchAlert + "} got matched with currentSwitchAlert {" + currentSwitchAlert + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected expSwitchAlert {" + expSwitchAlert + "}  does not matched currentSwitchAlert {" + currentSwitchAlert + "}");
        			Ranorex.Report.Screenshot("Unable to find the value in the form", SystemConfigurationrepo.CTC_Parameters.Self.Element);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("CTC_Parameters Form does not exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo, SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_ValidateCheckBox_CTCParameters
        /// </summary>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="currentSwitchAlert">Input:currentSwitchAlert </param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateElementEnableDisable_CTCParameters(string elementType, bool enabledDisabled, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.CTCParametersInfo,
        	                                                              SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	bool foundEnabledDisabled = false;
        	
        	if (SystemConfigurationrepo.CTC_Parameters.SelfInfo.Exists(0))
        	{
        		bool currentSwitchAlertState = SystemConfigurationrepo.CTC_Parameters.DisableUnresponsiveSwitchAlertCheckBox.GetAttributeValue<bool>("Selected");

        		switch (elementType.ToUpper())
        		{
        		    case "TEXTBOX":
            		    foundEnabledDisabled = SystemConfigurationrepo.CTC_Parameters.GlobalSwitchRequestTimeOutValueText.GetAttributeValue<bool>("Enabled");
            		    break;
            		case "APPLYBUTTON":
            		    foundEnabledDisabled = SystemConfigurationrepo.CTC_Parameters.ApplyButton.GetAttributeValue<bool>("Enabled");
            		    break;
            		default:
            		    Ranorex.Report.Failure("Element {" + elementType + "} is not a known element type");
            		    break;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("CTC_Parameters Form does not exist");
        	}
        	
        	if(foundEnabledDisabled == enabledDisabled)
        	{
        		Ranorex.Report.Success("Expected CTC_Parameters ElementType {" + elementType + "} was found " + (foundEnabledDisabled ? "Enabled":"Disabled"));
        	} else {
        		Ranorex.Report.Failure("Expected CTC_Parameters ElementType {" + elementType + "} was found " + (foundEnabledDisabled ? "Enabled":"Disabled"));
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.CTC_Parameters.CancelButtonInfo, SystemConfigurationrepo.CTC_Parameters.SelfInfo);
        	}
        }
        /// <summary>
        /// To NS_ModifyWeatherConfiguration
        /// </summary>
        /// <param name="division">Input:division </param>
        /// <param name="StationName">Input:StationName</param>
        /// <param name="weatherReporting">Input:weatherReporting</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ModifyWeatherConfiguration(string division, string stationName, bool weatherReporting, bool reset, bool clickApply, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.WeatherConfigurationInfo,
        	                                                              SystemConfigurationrepo.Weather_Configuration.SelfInfo);
        	
        	string currentDivision = SystemConfigurationrepo.Weather_Configuration.Division.DivisionText.GetAttributeValue<string>("Text");
        	
        	if (SystemConfigurationrepo.Weather_Configuration.SelfInfo.Exists(0))
        	{
        		SystemConfigurationrepo.DivisionList = division;
        		
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Weather_Configuration.Division.DivisionTextInfo,
        		                                                              SystemConfigurationrepo.Weather_Configuration.Division.DivisionList.SelfInfo);
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Weather_Configuration.Division.DivisionList.DivisionListByTextInfo,
        		                                                                     SystemConfigurationrepo.Weather_Configuration.DivisionTable.SelfInfo);
        		SystemConfigurationrepo.StationName = stationName;
        		
        		if(SystemConfigurationrepo.Weather_Configuration.DivisionTable.DivisionRowByStationName.WeatherReportingInfo.Exists(0)
        		   && SystemConfigurationrepo.Weather_Configuration.DivisionTable.DivisionRowByStationName.WeatherReporting.EnsureVisible())
        		{
        			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForObjValueWithRetry(SystemConfigurationrepo.Weather_Configuration.DivisionTable.DivisionRowByStationName.WeatherReportingInfo,
        			                                                                      SystemConfigurationrepo.Weather_Configuration.DivisionTable.DivisionRowByStationName.WeatherReportingInfo, "Text", "true");
        		}
        		else
        		{
        			Ranorex.Report.Error("Could not find station {" +stationName+ "} in available station list");
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Weather Configuration Form doesnot exist");
        	}
        	//To Reset the Form
        	if(reset)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Weather_Configuration.ResetButtonInfo, SystemConfigurationrepo.Weather_Configuration.ResetButtonInfo);
        	}
        	// to Apply the Form
        	if (clickApply)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Weather_Configuration.ApplyButtonInfo, SystemConfigurationrepo.Weather_Configuration.ApplyButtonInfo);
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Weather_Configuration.CancelButtonInfo, SystemConfigurationrepo.Weather_Configuration.SelfInfo);
        	}
        }
        
        /// <summary>
        /// To NS_Validate WeatherConfiguration
        /// </summary>
        /// <param name="division">Input:division </param>
        /// <param name="expStationName">Input:expStationName</param>
        /// <param name="weatherReporting">Input:weatherReporting</param>
        /// <param name="reset">Input:reset</param>
        /// <param name="clickApply">Input:clickApply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateWeatherConfiguration(string division, string stationName, string expWeatherReporting, bool closeForms)
        {
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.WeatherConfigurationInfo,
        	                                                              SystemConfigurationrepo.Weather_Configuration.SelfInfo);
        	string currentDivision = SystemConfigurationrepo.Weather_Configuration.Division.DivisionText.GetAttributeValue<string>("Text");
        	if (SystemConfigurationrepo.Weather_Configuration.SelfInfo.Exists(0))
        	{
        		SystemConfigurationrepo.DivisionList = division;
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Weather_Configuration.Division.DivisionTextInfo,
        		                                                              SystemConfigurationrepo.Weather_Configuration.Division.DivisionList.SelfInfo);
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForEnabledWithRetry(SystemConfigurationrepo.Weather_Configuration.Division.DivisionList.DivisionListByTextInfo,
        		                                                                     SystemConfigurationrepo.Weather_Configuration.DivisionTable.SelfInfo);
        		SystemConfigurationrepo.StationName = stationName;
        		string currentWeatherReporting = SystemConfigurationrepo.Weather_Configuration.DivisionTable.DivisionRowByDivisionIndex.WeatherReporting.GetAttributeValue<string>("Text");
        		if (currentWeatherReporting.Equals(expWeatherReporting))
        		{
        			Ranorex.Report.Success("Expected expWeatherReporting {" +expWeatherReporting+ "} got matched for Station {"+stationName+"} with the value as currentWeatherReporting {" +currentWeatherReporting+ "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected expWeatherReporting {" +expWeatherReporting+ "} did not match for Station {"+stationName+"} with currentWeatherReporting {" +currentWeatherReporting+ "}");
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Weather Configuration Form doesnot exist");
        	}
        	//To Close the form
        	if(closeForms)
        	{
        		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Weather_Configuration.CancelButtonInfo, SystemConfigurationrepo.Weather_Configuration.SelfInfo);
        	}
        }                
        
        
        /// <summary>
        /// Validate alert level Checkbox in Workstation alert handling.
        /// </summary>
        /// <param name="alertEventNumber">Input:alertEventNumber</param>
        /// <param name="userType">Input:userType </param>
        /// <param name="alertLevel">Input:alertLevel </param>
        /// <param name="validateIsChecked">Input:validateIsChecked</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateAlertLevelCheckbox_WorkstationAlertHandling(int alertEventNumber, string userType, string alertLevel, bool validateIsChecked, bool closeForms)
        {
        	NS_OpenAlertEventsConfiguration_WorkstationAlertHandling(alertEventNumber);
        	         	        	        	
        	SystemConfigurationrepo.AlertLevelIndex = (int.Parse(alertLevel) - 1).ToString();
        	string resultFound = "";
        	bool actualResult = false;
        	
        	if (SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.SelfInfo.Exists(0))
        	{
        		switch (userType.ToLower())
        		{
        			case "local":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Local.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "dispatcher":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Dispatcher.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "dispatcherterritory":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.DispatcherTerritory.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "signaltechnician":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SignalTechnician.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "signaltechnicianterritory":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SignalTechnicianTerritory.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "supervisor":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.Supervisor.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			case "supervisorterritory":
        				resultFound = SystemConfigurationrepo.Alert_Events_Configuration.WorkstationAlertHandling.FilterTypeTable.SupervisorTerritory.AlertLevelByIndex.GetAttributeValue<string>("Text");
        				break;
        			default:
        				Ranorex.Report.Error("Please specify a valid user type. Check data bindings and try again.");
        				return;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Error("Workstation alert handling form does not exist");
        		return;
        	}
        	        	
        	actualResult = bool.Parse(resultFound);
        	
        	if(actualResult == validateIsChecked)
        	{
        		Ranorex.Report.Success("User type " +userType+ " alert level " +alertLevel+ " is " +validateIsChecked+ " and actually it is present " +actualResult+ "");
        	} 
        	else
        	{
        		Ranorex.Report.Failure("User type " +userType+ " alert level " +alertLevel+ " is " +validateIsChecked+ " but actually it is present " +actualResult+ "");
        	}
        	
        	if(closeForms)
        	{        		        		        		
        		//Close the forms
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
        		                                                 SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
        	}   
        }


		/// <summary>
		/// InsertRow in TrainClearanceRouteConfiguration form
		/// </summary>
		/// <param name="crewLineSegment"></param>
		/// <param name="trainGroup"></param>
		/// <param name="originateOpsta"></param>
		/// <param name="terminateOpsta"></param>
		/// <param name="limit1Opsta"></param>
		/// <param name="limit2Opsta"></param>
		/// <param name="expectedFeedback"></param>
		/// <param name="reset"></param>
		/// <param name="apply"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_InsertRow_TrainClearanceRouteConfiguration(string crewLineSegment, string trainGroup, string originateOpsta, string terminateOpsta, string limit1Opsta,string limit2Opsta,
		                                                                 string expectedFeedback, bool reset, bool apply, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
			
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceRouteConfigurationInfo,
			                                                              SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
			
			if (!SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Train Clearance Route Configuration Form does not exist");
				return;
			}
			
			SystemConfigurationrepo.CrewLineSegmentIndex = "0";
			GeneralUtilities.LeftClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.InsertRowButtonInfo,
			                                              SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.MenuCellInfo);
			//set Crew Line Segment
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.CrewLineSegment.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.CrewLineSegment.PressKeys(crewLineSegment);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.CrewLineSegment.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			//set Train Group
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TrainGroup.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TrainGroup.PressKeys(trainGroup);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TrainGroup.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			//set Originate OPSTA
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.OriginateOPSTA.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.OriginateOPSTA.PressKeys(originateOpsta);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.OriginateOPSTA.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			//set Terminate OPSTA
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TerminateOPSTA.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TerminateOPSTA.PressKeys(terminateOpsta);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TerminateOPSTA.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			
			//set Limit 1 OPSTA
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit1OPSTA.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit1OPSTA.PressKeys(limit1Opsta);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit1OPSTA.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			//set Limit 2 OPSTA
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit2OPSTA.Click();
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit2OPSTA.PressKeys(limit2Opsta);
			SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit2OPSTA.PressKeys("{TAB}");
			
			//Check if this kicked up some Feedback
			if (!CheckFeedback(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback, expectedFeedback))
			{
				GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
					                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				}
				return;
			}
			else
			{
				if(!String.IsNullOrEmpty(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Feedback.GetAttributeValue<string>("Text")))
				{
					Report.Failure("Feedback not as expected");
					Report.Screenshot(SystemConfigurationrepo.Train_Clearance_Route_Configuration.Self);
					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo, SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
					}
					return;
				}
			}
			
			if (expectedFeedback != "")
			{
				Ranorex.Report.Failure("Did not receive expected Feedback of {" + expectedFeedback + "}.");
			}
			//To Reset the Form
			if(reset)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.ResetButtonInfo);
			}
			// to Apply the Form
			if (apply)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo);
				Ranorex.Report.Info("Row inserted successfully to Train Clearance Route Configuration Form");
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				Report.Info("Train Clearance Route Configuration closed");
			}
		}
		
		/// <summary>
		/// InsertRow in TrainClearanceRouteConfiguration form
		/// </summary>
		/// <param name="crewLineSegment"></param>
		/// <param name="trainGroup"></param>
		/// <param name="originateOpsta"></param>
		/// <param name="terminateOpsta"></param>
		/// <param name="limit1Opsta"></param>
		/// <param name="limit2Opsta"></param>
		/// <param name="expectedFeedback"></param>
		/// <param name="reset"></param>
		/// <param name="apply"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ValidateRow_TrainClearanceRouteConfiguration(string crewLineSegment, string trainGroup, string originateOpsta, string terminateOpsta,
		                                                                   string limit1Opsta,string limit2Opsta, bool validateExists, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
			
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceRouteConfigurationInfo,
			                                                              SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
			
			if (!SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Train Clearance Route Configuration Form does not exist");
				return;
			}
			int retries=0;
			while (!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.SelfInfo.Exists(0) && retries<5)
			{
				Delay.Milliseconds(1000);
				retries++;
			}
			
			bool rowFound=false;
			
			for (int i = 0; i < SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.Self.Rows.Count; i++)
			{
				SystemConfigurationrepo.CrewLineSegmentIndex = i.ToString();
				
				//validate Crew Line Segment
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.CrewLineSegment.GetAttributeValue<string>("CellData").Equals(crewLineSegment,StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				//validate Train Group
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TrainGroup.GetAttributeValue<string>("cellData").Equals(trainGroup,StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				//validate Originate OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.OriginateOPSTA.GetAttributeValue<string>("cellData").Contains(originateOpsta))
				{
					continue;
				}
				//validate Terminate OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TerminateOPSTA.GetAttributeValue<string>("cellData").Contains(terminateOpsta))
				{
					continue;
				}
				//validate Limit 1 OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit1OPSTA.GetAttributeValue<string>("cellData").Contains(limit1Opsta))
				{
					continue;
				}
				//validate Limit 2 OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit2OPSTA.GetAttributeValue<string>("cellData").Contains(limit2Opsta))
				{
					continue;
				}
				rowFound=true;
				break;
			}
			
			if(rowFound == validateExists)
			{
				if (validateExists)
				{
					Ranorex.Report.Success("Expected row in Train Clearance Route Configuration Form was found with the value -: CrewLineSegment as {" + crewLineSegment + "} ,TrainGroup as {" + trainGroup + "} ," +
					                       "OriginateOPSTA as {" + originateOpsta + "} ,TerminateOPSTA as {" + terminateOpsta + "}, Limit1OPSTA as {" + limit1Opsta + "} ,Limit2OPSTA as {" + limit2Opsta + "}");
				}
				else
				{
					Ranorex.Report.Success("Expected row in Train Clearance Route Configuration Form was not found with the value -: CrewLineSegment as {" + crewLineSegment + "} ,TrainGroup as {" + trainGroup + "} ," +
					                       "OriginateOPSTA as {" + originateOpsta + "} ,TerminateOPSTA as {" + terminateOpsta + "}, Limit1OPSTA as {" + limit1Opsta + "} ,Limit2OPSTA as {" + limit2Opsta + "}");
				}
			}
			else
			{
				if (validateExists)
				{
					Ranorex.Report.Failure("Expected row in Train Clearance Route Configuration Form was not found with the value -: CrewLineSegment as {" + crewLineSegment + "} ,TrainGroup as {" + trainGroup + "} ," +
					                       "OriginateOPSTA as {" + originateOpsta + "} ,TerminateOPSTA as {" + terminateOpsta + "}, Limit1OPSTA as {" + limit1Opsta + "} ,Limit2OPSTA as {" + limit2Opsta + "}");
				}
				else
				{
					Ranorex.Report.Failure("Expected row in Train Clearance Route Configuration Form was found with the value -: CrewLineSegment as {" + crewLineSegment + "} ,TrainGroup as {" + trainGroup + "} ," +
					                       "OriginateOPSTA as {" + originateOpsta + "} ,TerminateOPSTA as {" + terminateOpsta + "}, Limit1OPSTA as {" + limit1Opsta + "} ,Limit2OPSTA as {" + limit2Opsta + "}");
				}
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				Report.Info("Train Clearance Route Configuration closed");
			}
		}
		/// <summary>
		/// Click MenuCellMenu Options Train Clearance Route Configuration
		/// </summary>
		/// <param name="crewLineSegment"></param>
		/// <param name="trainGroup"></param>
		/// <param name="originateOpsta"></param>
		/// <param name="terminateOpsta"></param>
		/// <param name="limit1Opsta"></param>
		/// <param name="limit2Opsta"></param>
		/// <param name="menuCellOption"></param>
		/// <param name="apply"></param>
		/// <param name="closeForms"></param>
		[UserCodeMethod]
		public static void NS_ClickMenuCellMenuOptions_TrainClearanceRouteConfiguration(string crewLineSegment, string trainGroup, string originateOpsta, string terminateOpsta,
		                                                                                string limit1Opsta,string limit2Opsta, string menuCellOption, bool apply, bool closeForms)
		{
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
			                                                              MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
			
			PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.TrainClearanceRouteConfigurationInfo,
			                                                              SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
			
			if (!SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo.Exists(0))
			{
				Ranorex.Report.Failure("Train Clearance Route Configuration Form does not exist");
				return;
			}
			int retries=0;
			while (!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.SelfInfo.Exists(0) && retries<5)
			{
				Delay.Milliseconds(1000);
				retries++;
			}
			bool rowFound=false;
			for (int i = 0; i <= SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.Self.Rows.Count; i++)
			{
				SystemConfigurationrepo.CrewLineSegmentIndex = i.ToString();
				
				//validate Crew Line Segment
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.CrewLineSegment.GetAttributeValue<string>("CellData").Equals(crewLineSegment,StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				//validate Train Group
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TrainGroup.GetAttributeValue<string>("cellData").Equals(trainGroup,StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				//validate Originate OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.OriginateOPSTA.GetAttributeValue<string>("cellData").Contains(originateOpsta))
				{
					continue;
				}
				//validate Terminate OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.TerminateOPSTA.GetAttributeValue<string>("cellData").Contains(terminateOpsta))
				{
					continue;
				}
				//validate Limit 1 OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit1OPSTA.GetAttributeValue<string>("cellData").Contains(limit1Opsta))
				{
					continue;
				}
				//validate Limit 2 OPSTA
				if(!SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.Limit2OPSTA.GetAttributeValue<string>("cellData").Contains(limit2Opsta))
				{
					continue;
				}
				rowFound=true;
				break;
			}
			if(rowFound)
			{
				switch (menuCellOption.ToLower())
				{
					case "resetrow":
						GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.MenuCellInfo,
						                                               SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.ResetRowInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.ResetRowInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.SelfInfo);
						break;
					case "deleterow":
						GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.MenuCellInfo,
						                                               SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.DeleteRowInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.DeleteRowInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.SelfInfo);
						break;
					case "insertrow":
						GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.MenuCellInfo,
						                                               SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.InsertRowInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.InsertRowInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.SelfInfo);
						break;
					case "undeleterow":
						GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.MenuCellInfo,
						                                               SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.UndeleteRowInfo);
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.UndeleteRowInfo,
						                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.MenuCellMenu.SelfInfo);
						break;
					default:
						
						break;
				}
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.ApplyButtonInfo,
				                                                  SystemConfigurationrepo.Train_Clearance_Route_Configuration.CrewLineSegmentTable.CrewLineSegmentRowByCrewLineSegmentIndex.SelfInfo);
				Report.Info("Applied changes successfully");
			}
			else
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				Report.Failure("Could not find the row to be identified in the table");
			}
			//To Close the form
			if(closeForms)
			{
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Train_Clearance_Route_Configuration.CancelButtonInfo,
				                                                                      SystemConfigurationrepo.Train_Clearance_Route_Configuration.SelfInfo);
				Report.Info("Train Clearance Route Configuration closed");
			}
		}
		               
         /// <summary>
        /// Edit alert event level in alert event configuration.
        /// </summary>
        /// <param name="alertLevel">Input:alertLevel</param>
        /// <param name="displayPopup">Input:displayPopup </param>
        /// <param name="color">Input:color </param>
        /// <param name="ackReq">Input:ackReq </param>
        /// <param name="displayDuration">Input:displayDuration</param>
        /// <param name="audible">Input:audible</param>
        /// <param name="escalate">Input:escalate</param>
		/// <param name="escalateDelay">Input:escalateDelay</param>        
		/// <param name="closeForms">Input:closeForms</param> 
        [UserCodeMethod]
        public static void NS_EditAlertEventLevel_AlertEventConfiguration(string alertLevel, bool displayPopup, string color, bool ackReq, string displayDuration, bool audible, string audibleDuration, bool escalate, string escalateDelay, bool closeForms)
        {
        	//Open alert event level configuration
        	NS_OpenAlertEventsConfiguration_AlertEventLevelConfiguration();
        	
        	SystemConfigurationrepo.AlertEventLevelIndex = (int.Parse(alertLevel) - 1).ToString();
        	
        	
        	if(!SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.SelfInfo.Exists(0))
        	{
        	    Report.Failure("Alert event level configuration tab does not exist");
        		return;
        	}
        	
        	if (!SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.SelfInfo.Exists(0))
        	{
        	    Report.Failure("No Alert Event Row exists for alert level " + alertLevel);
        	    if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
					                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
				}
				return;
        	}
        	
        	if (displayPopup != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.Text))
        	{
        	    // Check/Uncheck display pop up checkbox
        	    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.Click();
				if (displayPopup != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.Text))
				{
					Ranorex.Report.Failure("Could not change display popup to " + (displayPopup ? "Checked":"Unchecked"));
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
						                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
					}
					return;
				}
				
				Report.Info("Changed Display Popup state to " + (displayPopup ? "Checked":"Unchecked"));
        	}
    		
    		//Set color for alert event level
    		if(color != "")
    		{
    			switch (color.ToUpper())
    			{
    				case "RED":
    					GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorTextInfo,
    					                                          SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.RedInfo);
    					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.RedInfo,
    					                                                  SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.RedInfo);
    					break;
    				case "YELLOW":
    					GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorTextInfo,
    					                                          SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.YellowInfo);
    					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.YellowInfo,
    					                                                  SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.YellowInfo);
    					break;
    				case "BLUE":
    					GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorTextInfo,
    					                                          SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.BlueInfo);
    					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.BlueInfo,
    					                                                  SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorList.BlueInfo);
    					break;
    					
    				default:
    					Ranorex.Report.Error("Color {" + color + "} is invalid, Please check data bindings and try again");
    					return;
    			}
    		}
    		
    		
    		if (ackReq != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AckRequired.Text))
        	{
        	    // Check/Uncheck display pop up checkbox
        	    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AckRequired.Click();
				if (ackReq != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AckRequired.Text))
				{
					Ranorex.Report.Failure("Could not change Ack Requested to " + (ackReq ? "Checked":"Unchecked"));
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
						                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
					}
					return;
				}
				
				Report.Info("Changed Ack Requested state to " + (ackReq ? "Checked":"Unchecked"));
        	}
    		
    		        		
    		// Set dislplay duration in alert event level
    		if(displayDuration != "")
    		{
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayDuration.DoubleClick();
        		SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayDuration.Click();
        		SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayDuration.PressKeys(displayDuration);
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayDuration.PressKeys("{TAB}");
    		}
    		
    		if (audible != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Audible.Text))
        	{
        	    // Check/Uncheck display pop up checkbox
        	    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Audible.Click();
				if (audible != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Audible.Text))
				{
					Ranorex.Report.Failure("Could not change Audible to " + (audible ? "Checked":"Unchecked"));
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
						                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
					}
					return;
				}
				
				Report.Info("Changed Audible state to " + (audible ? "Checked":"Unchecked"));
        	}
    		
    		if (audibleDuration != "")
    		{
    			    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AudibleDuration.DoubleClick();
    		    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AudibleDuration.Click();
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AudibleDuration.PressKeys(audibleDuration);
    			Report.Info("Updated audible duration is " +audibleDuration);
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AudibleDuration.PressKeys("{TAB}");
    		}
    		
    		if (escalate != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Escalate.Text))
        	{
        	    // Check/Uncheck display pop up checkbox
        	    SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Escalate.Click();
				if (escalate != bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Escalate.Text))
				{
					Ranorex.Report.Failure("Could not change Escalate to " + (escalate ? "Checked":"Unchecked"));
					if (closeForms)
					{
						GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
						                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
					}
					return;
				}
				
				Report.Info("Changed Escalate state to " + (escalate ? "Checked":"Unchecked"));
        	}
    		
    		// Set Escalate delay duration in alert event level
    		if(escalateDelay != "")
    		{
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.EscalateDuration.DoubleClick();
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.EscalateDuration.Click();
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.EscalateDuration.PressKeys(escalateDelay);
    			Report.Info("Updated Escalate delay is " +escalateDelay);
    			SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.EscalateDuration.PressKeys("{TAB}");
    		}
        	
        	//Click on apply button
        	GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo, SystemConfigurationrepo.Alert_Events_Configuration.ApplyButtonInfo);
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo, SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
        	}
        	
        	return;
        }
        
        
         /// <summary>
        /// Validate alert event level in Workstation alert handling.
        /// </summary>
        /// <param name="alertLevel">Input:alertLevel</param>
        /// <param name="displayPopup">Input:displayPopup </param>
        /// <param name="color">Input:color </param>
        /// <param name="ackReq">Input:ackReq </param>
        /// <param name="displayDuration">Input:displayDuration</param>
        /// <param name="audible">Input:audible</param>
        /// <param name="escalate">Input:escalate</param>
		/// <param name="escalateDelay">Input:escalateDelay</param>       
		/// <param name="closeForms">Input:closeForms</param> 		
        [UserCodeMethod]
        public static void NS_ValidateAlertEventLevel_AlertEventConfiguration(string alertLevel, bool displayPopup, string color, bool ackReq, string displayDuration, bool audible, string audibleDuration, bool escalate, string escalateDelay, bool closeForms)
        {
        	//Open alert event level configuration
        	NS_OpenAlertEventsConfiguration_AlertEventLevelConfiguration();        	
        	
        	SystemConfigurationrepo.AlertEventLevelIndex = (int.Parse(alertLevel) - 1).ToString();
        	
        	
        	if(!SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.SelfInfo.Exists(0))
        	{
        	    Report.Failure("Alert event level configuration tab does not exist");
        		return;
        	}
        	
        	if (!SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.SelfInfo.Exists(0))
        	{
        	    Report.Failure("No Alert Event Row exists for alert level " + alertLevel);
        	    if (closeForms)
				{
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo,
					                                                  SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
				}
				return;
        	}
        	
        	if(displayPopup.Equals(bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayPopup.Text)))
        	{
        		Ranorex.Report.Success("Display popup Checkbox is correct state ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Display popup Checkbox is incorrect state ");
        	}
        	
        	string actualColor = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Color.ColorText.Text;
        	if(color.Equals(actualColor))
        	{
        		Ranorex.Report.Success("Color expected to be " +color+ " and matches with acutal color " +actualColor+ " ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Color expected to be " +color+ " but matches with acutal color " +actualColor+ " ");
        	}
        	
        	if(ackReq.Equals(bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AckRequired.Text)))
        	{
        		Ranorex.Report.Success("AckRequired Checkbox is correct state");
        	}
        	else
        	{
        		Ranorex.Report.Failure("AckRequired Checkbox is incorrect state");
        	}
        	
        	String actualDisplayDuration = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.DisplayDuration.GetAttributeValue<object>("Time").ToString();
        	if(actualDisplayDuration.Contains(displayDuration))
        	{
        		Ranorex.Report.Success("Display duration value expected to be " +displayDuration+ " and matches with acutal display duration value " +actualDisplayDuration+ " ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Display duration value expected to be " +displayDuration+ " but matches with acutal display duration value " +actualDisplayDuration+ " ");
        	}
        	
        	if(audible.Equals(bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Audible.Text)))
        	{
        		Ranorex.Report.Success("Audible Checkbox is correct state ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Audible Checkbox is incorrect state ");
        	}
        	
        	String actualAudibleDuration = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.AudibleDuration.GetAttributeValue<object>("Time").ToString();
        	if(actualAudibleDuration.Contains(audibleDuration))
        	{
        		Ranorex.Report.Success("Audible Duration expected and found to be " + audibleDuration);
        	}
        	else
        	{
        		Ranorex.Report.Failure("Audible Duration expected to be " + audibleDuration + " but found to be " + actualAudibleDuration);
        	}
        	
        	if(escalate.Equals(bool.Parse(SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.Escalate.Text)))
        	{
        		Ranorex.Report.Success("Escalate Checkbox is correct state ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Escalate Checkbox is incorrect state ");
        	}
        	
        	String actualEscalateDelay = SystemConfigurationrepo.Alert_Events_Configuration.AlertEventLevelConfiguration.AlertEventLevelTable.AlertEventLevelRowByIndex.EscalateDuration.GetAttributeValue<object>("Time").ToString();
        	if(actualEscalateDelay.Contains(escalateDelay))
        	{
        		Ranorex.Report.Success("Escalate Delay value expected to be " +escalateDelay+ " and matches with Escalate Delay duration value " +actualEscalateDelay+ " ");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Escalate Delay value expected to be " +escalateDelay+ " but matches with Escalate Delay duration value " +actualEscalateDelay+ " ");
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Alert_Events_Configuration.OkButtonInfo, SystemConfigurationrepo.Alert_Events_Configuration.SelfInfo);
        	}
        }
        
        public static void NS_OpenManageWorkstationForm_SystemConfiguration()
        {
        	int retries = 0;

        	//Open Manage Workstation Form if it's not already open
        	if (SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Success("Manage workstation form is already open.");
        		return;
        	}

        	//Click System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	
        	//Click Manage Workstation Form in System Configuration menu
        	GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.ManageWorkstationStatusInfo,
        	                                                  MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	
        	//Wait for Manage Workstation Form to exist in case of lag
        	if(!SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo.Exists(0) )
        	{
        		while (!SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo.Exists(0)  && retries < 3)
        		{
        			Ranorex.Delay.Milliseconds(500);
        			retries++;
        		}
        		
        		if (!SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo.Exists(0) )
        		{
        			Ranorex.Report.Error("Manage workstation form did not open");
        			return;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Info("Manage workstation form opened");
        	}
        }
        
        /// <summary>
        /// Place Workstation Out of Service
        /// </summary>
        /// <param name="workstation"></param>
        /// <param name="officeLocation"></param>
        /// <param name="apply"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_PlaceWorkstationOutofService_SystemConfiguration(string workstation,string officeLocation, bool apply,bool closeForms)
        {
        	NS_OpenManageWorkstationForm_SystemConfiguration();
        	int inServiceListSize = SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.Self.Items.Count;
        	
        	if (!SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationText.GetAttributeValue<string>("SelectedItemText").Contains(officeLocation)) {
        		Ranorex.Report.Info("TestStep", "Selecting office location {"+officeLocation+"}.");
        		SystemConfigurationrepo.OfficeLocationName = officeLocation;
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuButton.Click();
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuList.OfficeLocationListItemByName.Click();
        	}
        	
        	SystemConfigurationrepo.WorkstationName = workstation;
        	
        	if(SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.InServiceWorkstationListItemByWorkstationNameInfo.Exists(0)) {
        		Ranorex.Report.Info("TestStep", "Selecting work station {"+workstation+"}.");
        		SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.InServiceWorkstationListItemByWorkstationName.EnsureVisible();
        		SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.InServiceWorkstationListItemByWorkstationName.Click();
        	}
        	else if (SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.OutOfServiceWorkstationListItemByWorkstationNameInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Workstation Already out of service");
        		if(closeForms)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo);
        		}
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Screenshot();
        		Ranorex.Report.Error("Failed to select system {"+workstation+"} from in service workstation list");
        	}
        	
        	SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceButton.DoubleClick();
        		                                         
        	
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.ApplyButtonInfo,
        		                                                  SystemConfigurationrepo.Manage_Workstation_Status.ApplyButtonInfo);
        	}
        	
			if(inServiceListSize>SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.Self.Items.Count)
        	{
        		Ranorex.Report.Success("Workstation {"+workstation+"} has been put Out-Of-service");
        	}
			else
			{
				Ranorex.Report.Failure("Workstation {"+workstation+"} could not be placed Out-Of-service");
			}	
			
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Validate the service status of workstation.
        /// </summary>
        /// <param name="workstation"></param>
        /// <param name="officeLocation"></param>
        /// <param name="status"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_ValidateWorkstationServiceStatus_ManageWorkstationForm(string workstation,string officeLocation,string status,bool closeForms)
        {
        	NS_OpenManageWorkstationForm_SystemConfiguration();
        	
        	if (!SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationText.GetAttributeValue<string>("SelectedItemText").Contains(officeLocation)) {
        		Ranorex.Report.Info("TestStep", "Selecting office location {"+officeLocation+"}.");
        		SystemConfigurationrepo.OfficeLocationName = officeLocation;
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuButton.Click();
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuList.OfficeLocationListItemByName.Click();
        	}
        	
        	SystemConfigurationrepo.WorkstationName = workstation;
        	
        	switch(status.ToLower())
        	{
        		case "inservice" :
        			if(SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.InServiceWorkstationListItemByWorkstationNameInfo.Exists(0)) {
        				Ranorex.Report.Success("Workstation {"+workstation+"} is IN-SERVICE");
        			}
        			else
        			{
        				Ranorex.Report.Failure(workstation+"not found in Workstation IN-SERVICE list");
        				}
        			break;
        			
        		case "outofservice":
        			if(SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.OutOfServiceWorkstationListItemByWorkstationNameInfo.Exists(0)) {
        				Ranorex.Report.Success("Workstation {"+workstation+"} is OUT-OF-SERVICE");
        			}
        			else
        			{
        				Ranorex.Report.Failure(workstation+"not found in Workstation OUT-OF-SERVICE list");
        			}
        			break;
        			
        		default:
        			Ranorex.Report.Error("Invalid selection list");
        			break;
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_PlaceWorkstationInService_ManageWorkstationForm(string workstation,string officeLocation, bool apply,bool closeForms)
        {
        	NS_OpenManageWorkstationForm_SystemConfiguration();
        	int outOfServiceListSize = SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.Self.Items.Count;
        	if (!SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationText.GetAttributeValue<string>("SelectedItemText").Contains(officeLocation)) {
        		Ranorex.Report.Info("TestStep", "Selecting office location {"+officeLocation+"}.");
        		SystemConfigurationrepo.OfficeLocationName = officeLocation;
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuButton.Click();
        		SystemConfigurationrepo.Manage_Workstation_Status.OfficeLocation.OfficeLocationMenuList.OfficeLocationListItemByName.Click();
        	}
        	
        	SystemConfigurationrepo.WorkstationName = workstation;
        	
        	if(SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.OutOfServiceWorkstationListItemByWorkstationNameInfo.Exists(0)) {
        		Ranorex.Report.Info("TestStep", "Selecting work station {"+workstation+"}.");
        		SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.OutOfServiceWorkstationListItemByWorkstationName.EnsureVisible();
        		SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.OutOfServiceWorkstationListItemByWorkstationName.Click();
        	}
        	else if (SystemConfigurationrepo.Manage_Workstation_Status.InServiceWorkstationsList.InServiceWorkstationListItemByWorkstationNameInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Workstation Already In-Service");
        		if(closeForms)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo);
        		}
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Screenshot();
        		Ranorex.Report.Error("Failed to select system {"+workstation+"} from Out-Of-Service workstation list");
        	}
        	
        	SystemConfigurationrepo.Manage_Workstation_Status.InServiceButton.DoubleClick();
        	
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.ApplyButtonInfo,
        		                                                  SystemConfigurationrepo.Manage_Workstation_Status.ApplyButtonInfo);
        	}
        	
			if(outOfServiceListSize>SystemConfigurationrepo.Manage_Workstation_Status.OutOfServiceWorkstationsList.Self.Items.Count)
        	{
        		Ranorex.Report.Success("Workstation {"+workstation+"} has been put In-service");
        	}
			else
			{
				Ranorex.Report.Failure("Workstation {"+workstation+"} could not be placed In-service");
			}
			
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Manage_Workstation_Status.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Manage_Workstation_Status.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Open Assign Function Keys Form
        /// </summary>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_OpenAssignFunctionKeysForm_SystemConfiguratation()
        {
        	int retries = 0;

        	//Open Assign Function key Form if it's not already open
        	if (SystemConfigurationrepo.Assign_Function_Keys.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Info("Assign Function Keys form is already open.");
        		return;
        	}

        	//Click System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	
        	//Click Assign Function key Form in System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.AssignFunctionKeysInfo,
        	                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	
        	//Wait for Assign Function key Form to exist in case of lag
        	while (!SystemConfigurationrepo.Assign_Function_Keys.SelfInfo.Exists(0)  && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if (!SystemConfigurationrepo.Assign_Function_Keys.SelfInfo.Exists(0) )
        	{
        		Ranorex.Report.Error("Assign Function Keys form did not open");
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Info("Assign Function Keys form opened");
        	}
        }
        
        /// <summary>
        /// Remove all Assigned Function Key values
        /// </summary>
        /// <param name="Apply"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_RemoveAllAssignedFunctionKeysValues_SystemConfiguratation(bool apply, bool reset, bool closeForms)
        {
        	NS_OpenAssignFunctionKeysForm_SystemConfiguratation();

        	int columnCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Columns.Count;
        	for (int i = 0; i < columnCount; i++) 
        	{
        		SystemConfigurationrepo.AssignFunctionColumnIndex=i.ToString();
        		int rowCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Rows.Count;
        		for (int j = 0; j < rowCount; j++)
        		{
        			SystemConfigurationrepo.AssignFunctionRowIndex=j.ToString();
        			if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Text != null)
        			{
        			    if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.GetAttributeValue<string>("FunctionKey") != "")
        			    {
                			SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Click();
                			SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.PressKeys("{Delete}");
        			    }
        			}
        		}
        	}
        	
        	if(apply)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Assign_Function_Keys.ApplyButtonInfo,
        		                                                      SystemConfigurationrepo.Assign_Function_Keys.ApplyButtonInfo);
        	}
        	
        	if(reset)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo,
        		                                                      SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo);
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_ValidateAllFunctionKeyValuesAreNotSet_AssignedFunctionKeysForm(bool closeForms)
        {
        	NS_OpenAssignFunctionKeysForm_SystemConfiguratation();
        	int columnCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Columns.Count;
        	int rowCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Rows.Count;
        	
        	bool functionKeyStatus = false;
        	for (int i = 0; i < columnCount; i++)
        	{
        		SystemConfigurationrepo.AssignFunctionColumnIndex = i.ToString();
        		for (int j = 0; j < rowCount; j++)
        		{
        		    SystemConfigurationrepo.AssignFunctionRowIndex = j.ToString();
        		    if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Text != null)
        		    {
            			if(!SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.GetAttributeValue<string>("FunctionKey").Equals(""))
            			{
            				functionKeyStatus = true;
            				break;
            			}
        		    }
        		}
        		if(functionKeyStatus)
        		{
        			Ranorex.Report.Failure("All function key are not removed");
        			return;
        		}
        	}
        	
        	if(!functionKeyStatus)
        	{
        		Ranorex.Report.Success("All function key are removed");
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Assign function key shortcut to system function of PDS
        /// </summary>
        /// <param name="function"></param>
        /// <param name="functionKey"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm(string function, string functionKey, bool apply, bool reset, bool closeForms)
        {
        	NS_OpenAssignFunctionKeysForm_SystemConfiguratation();
        	int columnCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Columns.Count;
        	int rowCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Rows.Count;

        	bool functionKeyStatus = false;
        	if(function.Equals(""))
        	{
        		//resets form if true
        		if(reset)
        		{
        			GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo,
        		                                                      SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo);
        			Ranorex.Report.Success("Form has been Reset");
        			return;
        		}
        		
        		if(closeForms)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        		}
        		Ranorex.Report.Error("Entered Invalid function key or Null. Form has been Reset");
        		return;
        	}
        	for (int i = 0; i < columnCount; i++)
        	{
        		SystemConfigurationrepo.AssignFunctionColumnIndex = i.ToString();
        		for (int j = 0; j < rowCount; j++)
        		{
        			SystemConfigurationrepo.AssignFunctionRowIndex = j.ToString();
        			if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Text != null)
        			{
            			if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.GetAttributeValue<string>("SystemFunction").Equals(function))
            			{
            			    SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Click();
            				if (functionKey.Equals(""))
            				{
            				    SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.PressKeys("{Delete}");
            				} else {
            				    SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.PressKeys("{"+functionKey+"}");
            				}
            				functionKeyStatus = true;
            				break;
            			}
        			}
        		}
        		
        		if (functionKeyStatus)
        		{
        			Ranorex.Report.Info("Function has been set");
        			break;
        		}
        	}
        	
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Assign_Function_Keys.ApplyButtonInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.ApplyButtonInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.OKButtonInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	}
        	
        	if(reset)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo,
        		                                                      SystemConfigurationrepo.Assign_Function_Keys.ResetButtonInfo);
        	}
        	if(functionKeyStatus)
        	{
        		Ranorex.Report.Success("Function Key :{"+functionKey+"} has been set for system function :{"+function+"}");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Function Key :{"+functionKey+"} failed to set for system function :{"+function+"}");
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_ValidateFunctionKeyValues_AssignFunctionKeysForm(string function, string expectedFunctionKey, bool closeForms)
        {
        	NS_OpenAssignFunctionKeysForm_SystemConfiguratation();
        	int columnCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Columns.Count;
        	int rowCount = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.Self.Rows.Count;
        	string actualFunctionKey = "";
        	bool functionNameFound = false;
        	for (int i = 0; i < columnCount; i++)
        	{
        		SystemConfigurationrepo.AssignFunctionColumnIndex = i.ToString();
        		for (int j = 0; j < rowCount; j++)
        		{
        			SystemConfigurationrepo.AssignFunctionRowIndex = j.ToString();
        			if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.Text != null)
        			{
            			if (SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.GetAttributeValue<string>("SystemFunction").Equals(function))
            			{
            				actualFunctionKey = SystemConfigurationrepo.Assign_Function_Keys.AssignFunctionKeysTable.AssignedFunctionKey.Self.GetAttributeValue<string>("FunctionKey");
            				functionNameFound = true;
            				break;
            			}
        			}
        		}
        		
        		//break the loop if function found
        		if(functionNameFound)
        		{
        			Ranorex.Report.Info("Found expected system function");
        			break;
        		}
        	}
        	
        	if(actualFunctionKey.Equals(expectedFunctionKey) && functionNameFound)
        	{
        		Ranorex.Report.Success("Expected Function Key : {"+expectedFunctionKey+"} and found actual Function Key : {"+actualFunctionKey+"}.");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Expected Function Key : {"+expectedFunctionKey+"} and found actual Function Key : {"+actualFunctionKey+"}.");
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Assign_Function_Keys.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Assign_Function_Keys.SelfInfo);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_OpenFormsUsingFunctionKey_AssignFunctionKeys(string functionKey, string formTitle, bool validateFormExists)
        {
        	if(!functionKey.Equals(""))
        	{
        		NS_Utility.NS_ValidateFormExists_FormTitle(formTitle, false);
        		MainMenurepo.PDS_Main_Menu.Self.PressKeys("{"+functionKey+"}");
        		Ranorex.Report.Success("Function key pressed");
        		NS_Utility.NS_ValidateFormExists_FormTitle(formTitle, validateFormExists);
        		
        	}
        	else
        	{
        		Ranorex.Report.Error("Entered Invalid function key or Null");
        	}                                       
        }
        
        /// <summary>
        /// Opens User Accounts form
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenUserAccountsForm_SystemConfiguration()
        {
        	int retries = 0;

        	//Open User Account Form if it's not already open
        	if (SystemConfigurationrepo.User_Accounts.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Info("User Account form is already open.");
        		return;
        	}

        	//Click System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);
        	
        	//Click User Account Form in System Configuration menu
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.UserAccountsInfo,
        	                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        	
        	//Wait for User Account Form to exist in case of lag
        	while (!SystemConfigurationrepo.User_Accounts.SelfInfo.Exists(0)  && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	if (!SystemConfigurationrepo.User_Accounts.SelfInfo.Exists(0) )
        	{
        		Ranorex.Report.Error("User Account form did not open");
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Info("User Account form opened");
        	}
        }
        
        /// <summary>
        /// Add new users to user accounts , validate user ID and Employee ID is valid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="lastName"></param>
        /// <param name="FI"></param>
        /// <param name="MI"></param>
        /// <param name="empId"></param>
        /// <param name="userType"></param>
        /// <param name="status"></param>
        /// <param name="SCAC"></param>
        /// <param name="Restricted"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="checkUserId"></param>
        /// <param name="checkEmpId"></param>
        /// <param name="Apply"></param>
        /// <param name="Reset"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_AddNewUser_UserAccounts(string userId, string lastName, string FI, string MI, string empId, string userType, string status, string scac, string restricted, string expectedFeedback, bool checkUserId, bool checkEmpId, bool apply, bool reset, bool closeForm)
        {
        	NS_OpenUserAccountsForm_SystemConfiguration();
        	bool inputFieldWarningColorExists = false;
        	if (userId.Equals(""))
        	{
        		if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		}
        		Ranorex.Report.Error("User ID cannot be null");
        		return;
        	}
        	else{
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserID.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserID.PressKeys(userId);
        	}
        	Keyboard.Press("{TAB}");
        	
        	if (!CheckFeedback(SystemConfigurationrepo.User_Accounts.Feedback, expectedFeedback))
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		return;
        	}
        	
        	inputFieldWarningColorExists = !PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForAnyAdapterByPixel(SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserID, "textboxwarning", false);
        	
        	if(checkUserId)
        	{
        		if(inputFieldWarningColorExists == checkUserId)
        		{
        			Ranorex.Report.Success("Expected warning for User Id Field : as {"+checkUserId+"} and found as {"+inputFieldWarningColorExists+"}");
        		}
        		else{
        			Ranorex.Report.Screenshot();
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        			Ranorex.Report.Failure("Expected warning for User Id Field: as {"+checkUserId+"} and found as {"+inputFieldWarningColorExists+"}");
        			return;
        		}
        	}
        	
        	bool hasAttributeSet = true;
        	if(!lastName.Equals("")){
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.LastName.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.LastName.PressKeys(lastName);
        		Ranorex.Keyboard.Press("{tab}");
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.LastName.GetAttributeValue<string>("Text").Equals(lastName))
        		{
        			hasAttributeSet = false;
        		}
        	}

        	
        	if(!FI.Equals("")){
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.FirstInitial.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.FirstInitial.PressKeys(FI);
        		Ranorex.Keyboard.Press("{tab}");
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.FirstInitial.GetAttributeValue<string>("Text").Equals(FI))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	

        	
        	if(!MI.Equals("")){
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.MiddleInitial.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.MiddleInitial.PressKeys(MI);
        		Ranorex.Keyboard.Press("{tab}");
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.MiddleInitial.GetAttributeValue<string>("Text").Equals(MI))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	
        	
        	if(!empId.Equals("")){
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.EmployeeID.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.EmployeeID.PressKeys(empId);
        		Ranorex.Keyboard.Press("{tab}");
        	}

        	inputFieldWarningColorExists = !PDS_CORE.Code_Utils.GeneralUtilities.CheckColorForAnyAdapterByPixel(SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.EmployeeID, "textboxwarning", false);
        	if(checkEmpId)
        	{
        		if(inputFieldWarningColorExists == checkEmpId)
        		{
        			Ranorex.Report.Success("Expected warning for Employee Id Field : as {"+checkEmpId+"} and found as {"+inputFieldWarningColorExists+"}");
        		}
        		else{
        			Ranorex.Report.Screenshot();
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        			Ranorex.Report.Failure("Expected warning for  Employee Id Field: as {"+checkEmpId+"} and found as {"+inputFieldWarningColorExists+"}");
        			return;
        		}
        	}
        	
        	
        	if (userType != "")
        	{
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserType.UserTypeText.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserType.UserTypeText.PressKeys(userType);
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserType.UserTypeText.GetAttributeValue<string>("Text").Equals(status))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	
        	if (status != "")
        	{
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Status.StatusText.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Status.StatusText.PressKeys(status);
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Status.StatusText.GetAttributeValue<string>("Text").Equals(status))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	
        	if (scac != "")
        	{
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserSCAC.UserSCACText.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserSCAC.UserSCACText.PressKeys(scac);
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.UserSCAC.UserSCACText.GetAttributeValue<string>("Text").Equals(scac))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	
        	if (restricted != "")
        	{
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Restricted.Click();
        		SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Restricted.PressKeys(restricted);
        		if(!SystemConfigurationrepo.User_Accounts.UserAccounts.AddUserAccountsTable.AddUserRow.Restricted.GetAttributeValue<string>("Text").Equals(restricted))
        		{
        			hasAttributeSet = false;
        		}
        	}
        	
        	if(hasAttributeSet)
        	{
        		Ranorex.Report.Success("The required add user input fields are set");
        	}
        	
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButtonInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButtonInfo);
        	}
        	
        	if(reset)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo);
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.OkButtonInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        	}
        	
        }
        
        /// <summary>
        /// Validate if user exists in User Account based on UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expectUserExists"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ValidateUserExists_UserAccounts(string userId,bool expectUserExists = true, bool closeForm = false)
        {
        	NS_OpenUserAccountsForm_SystemConfiguration();
        	int rowCount = SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.Self.Rows.Count;
        	
        	if (userId.Equals(""))
        	{
        		if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		}
        		Ranorex.Report.Error("User ID cannot be null");
        		return;
        	}
        	
        	bool actualUserExists = false;

        	for (int i = 0; i < rowCount; i++) 
        	{
        		SystemConfigurationrepo.UserAccountsIndex = i.ToString();
        		
        		if(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.UserID.GetAttributeValue<string>("Text").Equals(userId))
        		{
        			actualUserExists =true;
        			break;
        		}
        	}
        	
        	
        	if(actualUserExists == expectUserExists)
        	{
        		Ranorex.Report.Success("Expected User Id {"+expectUserExists+"} and found User Id as {"+actualUserExists+"}");
        	}
        	else
        	{
        		Ranorex.Report.Screenshot();
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		Ranorex.Report.Failure("Expected User Id {"+expectUserExists+"} and found User Id as {"+actualUserExists+"}");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        	}
        }
        
        
        /// <summary>
        /// Validates status of the user based on userID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusType"></param>
        /// <param name="validateStatusExists"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ValidateUserStatus_UserAccounts(string userId, string statusType, bool validateStatusExists,  bool closeForm = false)
        {
        	NS_OpenUserAccountsForm_SystemConfiguration();
        	int rowCount = SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.Self.Rows.Count;
        	if (userId.Equals(""))
        	{
        		if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		}
        		Ranorex.Report.Error("User ID cannot be null");
        		return;
        	}
        	
        	bool actualUserStatus = false;

        	for (int i = 0; i < rowCount; i++) 
        	{
        		SystemConfigurationrepo.UserAccountsIndex = i.ToString();
        		if(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.UserID.GetAttributeValue<string>("Text").Equals(userId))
        		{
        			if(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.StatusImage.GetAttributeValue<string>("Text").Equals(statusType.ToUpper()))
        			actualUserStatus = true;
        			break;
        		}
        	}
        	
        	
        	if(actualUserStatus == validateStatusExists)
        	{
        		Ranorex.Report.Success("Expected User Id: {"+userId+"} Status {"+statusType+"} as {"+validateStatusExists+"} and found as {"+actualUserStatus+"}");
        	}
        	else
        	{
        		Ranorex.Report.Screenshot();
        		Ranorex.Report.Failure("Expected User Id: {"+userId+"} Status {"+statusType+"} as {"+validateStatusExists+"} and found as {"+actualUserStatus+"}");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        	}
        }
        
        
        /// <summary>
        /// Make user active, suspend or delete based on user iD
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="activityType"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ManageUserStatus_UserAccounts(string userId, string activityType,string expectedFeedback, bool closeForm = false)
        {
        	NS_OpenUserAccountsForm_SystemConfiguration();
        	bool activityPerformed = false;
        	string actualFeedback = "";
        	int rowCount = SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.Self.Rows.Count;
        	
        	if (userId.Equals(""))
        	{
        		if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        			                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        		}
        		Ranorex.Report.Error("User ID cannot be null");
        		return;
        	}
        	
        	
        	for (int i = 0; i < rowCount; i++)
        	{
        		SystemConfigurationrepo.UserAccountsIndex = i.ToString();
        		if(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.UserID.GetAttributeValue<string>("Text") == userId)
        		{
        			Ranorex.Report.Info("User ID found");
        			SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.Self.EnsureVisible();
        			
        			switch(activityType.ToLower())
        			{
        				case "suspend" :
        					GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.MenuCellInfo,
        					                                               SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SuspendInfo,
        					                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButton.Click();
        					
        					if (!CheckFeedback(SystemConfigurationrepo.User_Accounts.Feedback, expectedFeedback))
        					{
        						if (closeForm)
        						{
        							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.OkButtonInfo,
        							                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        						}
        						return;
        					}
        					activityPerformed = true;
        					break;
        					
        				case "activate" :
        					GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.MenuCellInfo,
        					                                               SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.MakeActiveInfo,
        					                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButtonInfo,
        					                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButtonInfo);
        					
        					if (!CheckFeedback(SystemConfigurationrepo.User_Accounts.Feedback, expectedFeedback))
        					{
        						if (closeForm)
        						{
        							GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.OkButtonInfo,
        							                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        						}
        						return;
        					}
        					activityPerformed = true;
        					break;
        					
        				case "delete" :
        					GeneralUtilities.RightClickAndWaitForWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.UserAccountsRowByIndex.MenuCellInfo,
        					                                               SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.DeleteRowInfo,
        					                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.UserAccountsTable.MenuCellMenu.SelfInfo);
        					
        					SystemConfigurationrepo.User_Accounts.UserAccounts.ApplyButton.Click();
        					
        					
        					string actualFeedbackText = SystemConfigurationrepo.User_Accounts.Feedback.GetAttributeValue<string>("Text");
        					if(actualFeedbackText != "" && actualFeedbackText != " ")
        					{
        						actualFeedback = Regex.Replace(actualFeedbackText, @"[^A-Za-z]", ""); //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces
        						string expFeedbackText = Regex.Replace(expectedFeedback, @"[^A-Za-z]", "");  //Replaces all the invisible character with nothing, all the words will be appended and forms a single string without any spaces
        						if(actualFeedback.Equals(expFeedbackText))
        						{
        							Ranorex.Report.Success("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+actualFeedbackText+"} are same.");
        							if (closeForm)
        							{
        								GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo,
        								                                                  SystemConfigurationrepo.User_Accounts.UserAccounts.ResetButtonInfo);
        								GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        								                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        							}
        						}
        						else
        						{
        							Ranorex.Report.Screenshot();
        							if (closeForm)
        							{
        								GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        								                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        							}
        							Ranorex.Report.Failure("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+actualFeedbackText+"} are not same.");
        						}
        						return;
        					}
        					else if(expectedFeedback != "")
        					{
        						Ranorex.Report.Failure("Did not receive expected feedback of {" + expectedFeedback + "}.");
        					}
        					
        					activityPerformed = true;
        					break;
        					
        					
        					default :
        						Ranorex.Report.Error("Invalid Selection");
        					break;
        			}
        			if(activityPerformed)
        			{
        				break;
        			}
        		}
        	}
        	
        	if(activityPerformed)
        	{
        		Ranorex.Report.Success("Activity {"+activityType+"} for User ID {"+userId+"} has been performed");
        	}
        	else
        	{
        		Ranorex.Report.Error("Activity {"+activityType+"} for User ID {"+userId+"} has not been performed");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.User_Accounts.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.User_Accounts.SelfInfo);
        	}
        }
        
        public static void NS_OpenConfigureDispatcherTransferReport_SystemConfiguration()
        {
            int retries = 0;

            //Open Dispatcher Transfer Report Form if it's not already open
            if (SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
            {
                Ranorex.Report.Info("Configure Dispatcher Transfer Report form is open.");
                return;
            }

            //Click System Configuration menu
            GeneralUtilities.ClickAndWaitForWithRetry(
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo
            );
            
            //Click Dispatcher Transfer Report in System Configuration menu
            GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.DispatcherTransferReportInfo,
        	                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
           
            
            //Wait for Dispatcher Transfer Reportn Form to exist in case of lag
            while (!SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            if (!SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
            {
                Report.Screenshot();
                Ranorex.Report.Error("Configure Dispatcher Transfer Report form did not open");
                return;
            }
        }
        
         /// <summary>
        /// Set inclusion rule as OPTIONAL, REQUIRED or EXCLUDED
        /// </summary>
        /// <param name="dataItemName"></param>
        /// <param name="setRuleAs"></param>
        /// <param name="apply"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
         public static void NS_ModifySingleInclusionRule_ConfigureDispatcherTransferReport(string dataItemName, string setRuleAs, bool apply, bool closeForm)
         {
         	//open Configure DTR if already not open
         	NS_OpenConfigureDispatcherTransferReport_SystemConfiguration();
         	
         	if(NS_ModifyInclusionRule_ConfigureDispatcherTransferReport(dataItemName, setRuleAs))
         	{
         		Ranorex.Report.Success("Inclusion rule : {"+setRuleAs+"} has be set to dataItem :{"+dataItemName+"}");
         	}
         	else
         	{
         		Ranorex.Report.Failure("Inclusion rule : {"+setRuleAs+"} has be set to dataItem :{"+dataItemName+"}");
         	}
         	
         	//to apply
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.ApplyButtonInfo,
        		                                          SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
         }
       
        public static bool NS_ModifyInclusionRule_ConfigureDispatcherTransferReport(string dataItemName, string setRuleAs)
        {
        	bool hasRuleSet = false;
        	bool found = false;
        	
        	SystemConfigurationrepo.DataItemName = dataItemName;
        	if(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportDataItemName.DispatchersTransferReportDataItemTextInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportDataItemName.InclusionRules.InclusionRulesTextInfo,
        		                                          SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportDataItemName.InclusionRules.InclusionRulesTextInfo);
        		
        		//get all rule names from the list
        		IList<ListItem> rulesList =  SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.Self.Items;
        		
        		foreach (ListItem ruleItem in rulesList)
        		{
        			if (ruleItem.GetAttributeValue<string>("Text").Equals(setRuleAs,StringComparison.OrdinalIgnoreCase))
        			{
        				found = true;
        				break;
        			}
        		}
        		
        		//if the rule is found in list then set it as expected.
        		if(found)
        		{
        			switch(setRuleAs.ToLower())
        			{
        					case "excluded" : GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.ExcludedInfo,
        					                                                                    SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.SelfInfo);
        					hasRuleSet = true;
        					break;
        					
        					case "required" : GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.RequiredInfo,
        					                                                                    SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.SelfInfo);
        					hasRuleSet = true;
        					break;
        					
        					case "optional" : GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.OptionalInfo,
        					                                                                    SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.SelfInfo);
        					hasRuleSet = true;
        					break;
        					
        					default : Ranorex.Report.Error("Invalid rule");
        					break;
        			}
        		}
        		else{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRulesTextInfo,
        			                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.InclusionRules.InclusionRuleList.SelfInfo);
        			Ranorex.Report.Error("Please specify a valid rule. Check data bindings and try again.");
        		}
        	}
        	else{
        		Ranorex.Report.Error("DTR data item name not found, specify a valid data item name. Check data bindings and try again.");
        	}
        	
        	//if rule is set return true
        	if(hasRuleSet)
        	{
        		return true;
        	}
        	else
        	{
        		return false;
        	}
        }
        
        /// <summary>
        /// makes rule Optional,Required or Excluded for DTR
        /// </summary>
        /// <param name="setRuleAs"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ModifyAllInclusionRules_ConfigureDispatcherTransferReport(string setRuleAs, bool apply, bool closeForm)
        {
        	//open configure DTR
        	NS_OpenConfigureDispatcherTransferReport_SystemConfiguration();
        	
        	//get row count from the table to iterate
        	int rowCount = SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.Self.Rows.Count;
        	bool hasAllRulesSet = true;
        	for (int i = 0; i < rowCount; i++) {
        		SystemConfigurationrepo.DispatcherTransferReportIndex = i.ToString();
        		string dataItemName = SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.DispatchersTransferReportDataItemText.GetAttributeValue<string>("Text");
        		
        		//get DTR data Item Name and call the below function to modify the inclusion rule
        		if(!NS_ModifyInclusionRule_ConfigureDispatcherTransferReport(dataItemName, setRuleAs))
        		{
        			hasAllRulesSet = false;
        			break;
        		}
        	}
        	
        	if(hasAllRulesSet)
        	{
        		Ranorex.Report.Success("Inclusion rule : {"+setRuleAs+"} has be set to ALL dataItem");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Inclusion rule : {"+setRuleAs+"} has be not been set to ALL dataItem");
        	}
        	//to apply
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.ApplyButtonInfo,
        		                                          SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        }
        
        public static void NS_ValidaterSingleInclusionRule_ConfigureDispatcherTransferReport(string dataItemName, string expectedRuleName, bool expectExists, bool closeForm)
        {
        	//open configure DTR if already not open
        	NS_OpenConfigureDispatcherTransferReport_SystemConfiguration();
        	bool actualExists = NS_ValidateSingleInclusionRule_ConfigureDispatcherTransferReport(dataItemName, expectedRuleName, expectExists);
        	
        	if(actualExists == expectExists)
        	{
        		Ranorex.Report.Success("Expected Inclusion Rule {"+expectedRuleName+"} as: {"+expectExists+"} and Found as {"+actualExists+"} for {"+dataItemName+"}");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Expected Inclusion Rule {"+expectedRuleName+"} as: {"+expectExists+"} and Found as {"+actualExists+"} for {"+dataItemName+"}");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        }
        
        public static bool NS_ValidateSingleInclusionRule_ConfigureDispatcherTransferReport(string dataItemName, string expectedRuleName, bool expectExists)
        {
        	SystemConfigurationrepo.DataItemName = dataItemName;
        	if(SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportDataItemName.DispatchersTransferReportDataItemTextInfo.Exists(0))
        	{
        		if(!SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportDataItemName.InclusionRules.InclusionRulesText.GetAttributeValue<string>("Text").Equals(expectedRuleName))
        		{
        			return false;
        		}
        	}
        	else{
        		Ranorex.Report.Error("DTR data item name not found, specify a valid data item name. Check data bindings and try again.");
        	}
        	return true;
        }
        
         /// <summary>
        /// validate rules of  DTR
        /// </summary>
        /// <param name="setRuleAs"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ValidateAllInclusionRules_ConfigureDispatcherTransferReport(string expectedRuleName, bool expectExists, bool closeForm)
        {
        	//open configure DTR
        	NS_OpenConfigureDispatcherTransferReport_SystemConfiguration();
        	
        	bool actualExists = true;
        	//get row count from the table to iterate
        	int rowCount = SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.Self.Rows.Count; 
        	for (int i = 0; i < rowCount; i++) {
        		SystemConfigurationrepo.DispatcherTransferReportIndex = i.ToString();
        		string dataItemName = SystemConfigurationrepo.Dispatcher_Transfer_Report.DispatcherTransferReportDataItemsTable.DispatcherTransferReportDataItemsRowByDispatcherTransferReportIndex.DispatchersTransferReportDataItemText.GetAttributeValue<string>("Text");
        		
        		//get DTR data Item Name and call the below function to validate the inclusion rule name
        		if(!NS_ValidateSingleInclusionRule_ConfigureDispatcherTransferReport(dataItemName, expectedRuleName, expectExists))
        		{
        			actualExists = false;
        			break;
        		}
        	}
        	
        	if(actualExists == expectExists)
        	{
        		Ranorex.Report.Success("Expected rule {"+expectedRuleName+"} set for All inclusion rules as {"+expectExists+"} and Found as {"+actualExists+"}");
        	}
        	else{
        		Ranorex.Report.Failure("Expected rule {"+expectedRuleName+"} set for All inclusion rules as {"+expectExists+"} and Found as {"+actualExists+"}");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Dispatcher_Transfer_Report.WindowControls.CloseInfo,
        		                                                  SystemConfigurationrepo.Dispatcher_Transfer_Report.SelfInfo);
        	}
        }
		[UserCodeMethod]
        public static void NS_ValidateOptionsEnable_MovementPlanningStatus(string menuOption,bool isEnable)
        {
            NS_MovementPlanner.NS_OpenPlanningStatusForm_MainMenu();
        	if(SystemConfigurationrepo.Movement_Planning_Status.SelfInfo.Exists(0))
        	{
        		switch (menuOption.ToLower())
        		{
        			case "editmovementplanner":
        				if(isEnable)
        				{
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.EnablePlanningButtonInfo,true);
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.DisablePlanningButtonInfo,true);
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.StartPlanningButtonInfo,true);
        				}
        				else
        				{
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.EnablePlanningButtonInfo,false);
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.DisablePlanningButtonInfo,false);
        					GeneralUtilities.CheckFieldEnableDisable(SystemConfigurationrepo.Movement_Planning_Status.StartPlanningButtonInfo,false);
        				}
        				break;
        			default:
        				Ranorex.Report.Failure("Invalid option");
        				break;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("PDS Main Menu does not exist");
        	}
        }
        
        [UserCodeMethod]
        public static void NS_CheckCautionaryAdvisoryCheckBox_BulletinItems(string bulletinName, bool applyButton, bool okButton, bool doCheck)
        {
            NS_SetBulletinType_BulletinItemsForm(bulletinName);
            if(doCheck && !SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckbox.Checked)
            {
                GeneralUtilities.CheckCheckboxAdapterAndVerifyChecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckboxInfo);
                if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckbox.Checked)
                {
                    Ranorex.Report.Failure("Unable to check Cautionary Advisory Enabled checkbox");
                }
            }
            else if(!doCheck && SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckbox.Checked)
            {
                GeneralUtilities.UncheckCheckboxAdapterAndVerifyUnchecked(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckboxInfo);
                if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckbox.Checked)
                {
                    Ranorex.Report.Failure("Unable to check Cautionary Advisory Enabled checkbox");
                }
            }
            
            if(applyButton)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo);
            }
            
            if(okButton)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
                                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
            }
        }
        
        [UserCodeMethod]
        public static void NS_ValidateCautionaryAdvisoryCheckBoxStatus_BulletinItems(string bulletinName, bool applyButton, bool okButton, bool validateIsChecked)
        {
            bool actCautionaryBoxStatus = false;
            NS_SetBulletinType_BulletinItemsForm(bulletinName);
            actCautionaryBoxStatus = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.CautionaryAdvisory.CautionaryAdvisoryCheckbox.Checked;
            if(actCautionaryBoxStatus == validateIsChecked)
            {
                Ranorex.Report.Success("actual status of Cautinary advisory checkbox is :{"+actCautionaryBoxStatus.ToString()+"} and " +
                                       "expected status of Cautinary advisory checkbox is {"+validateIsChecked.ToString()+"}.");
            }
            else
            {
                Ranorex.Report.Failure("actual status of Cautinary advisory checkbox is :{"+actCautionaryBoxStatus.ToString()+"} and " +
                                       "expected status of Cautinary advisory checkbox is {"+validateIsChecked.ToString()+"}.");
            }
            if(applyButton)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
                                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo);
            }
            
            if(okButton)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
                                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
            }
            return;
        }
        /// <summary>
        ///  Validat SystemAccessControl
        /// </summary>
        /// <param name="function"></param>
        /// <param name="userType"></param>
        /// <param name="grantPermission"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ValidatSystemAccessControl(string function, string userType, bool grantPermission, bool closeForm)
        {
        	NS_OpenSystemAccessControl_MainMenu();
        	
        	if (!function.Contains(" ---"))
        	{
        		function = " ---" + function;
        	}
        	
        	SystemConfigurationrepo.SystemAccessRowHeaderName = function;
        	SystemConfigurationrepo.SystemAccessColumnHeaderName = userType;
        	
        	if (!SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowHeaderTable.SystemAccessControlRowHeaderByNameInfo.Exists(0))
        	{
        		Ranorex.Report.Failure("Column Index not found for User " + userType + " in System Access Control Menu, your spelling or my code may be bad");
        		return;
        	}
        	SystemConfigurationrepo.SystemAccessRowIndex = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.RowHeaderTable.SystemAccessControlRowHeaderByName.GetAttributeValue<int>("RowIndex").ToString();
        	
        	if(!SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.ColumnHeaderRow.SystemAccessControlColumnHeaderByNameInfo.Exists(0))
        	{
        		Ranorex.Report.Failure("Row Index not found for Function " + function + " in System Access Control Menu, your spelling or my code may be bad");
        		return;
        	}
        	SystemConfigurationrepo.SystemAccessColumnIndex = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.ColumnHeaderRow.SystemAccessControlColumnHeaderByName.GetAttributeValue<int>("ColumnIndex").ToString();
        	
        	string actGrantPermission = SystemConfigurationrepo.System_Access_Control.SystemAccessControlTable.SystemAccessControlRowByIndex.CellByColumnIndex.GetAttributeValue<string>("Text");
        	
        	
        	if ((actGrantPermission == "") || (actGrantPermission.Equals("true") && !grantPermission) || (actGrantPermission.Equals("false") && grantPermission))
        	{
        		Ranorex.Report.Failure("Actual status for "+function+" for User "+userType+" is "+(actGrantPermission)+" and Expected to be "+(grantPermission ? "Granted": "Denied")+" in System Access Control Menu.");
        	}
        	else
        	{
        		Ranorex.Report.Success("Actual status for "+function+" for User "+userType+" is "+(actGrantPermission)+" and Expected to be "+(grantPermission ? "Granted": "Denied")+" in System Access Control Menu.");
        	}
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.System_Access_Control.CancelButtonInfo,
        		                                                  SystemConfigurationrepo.System_Access_Control.SelfInfo);
        	}
        	
        	return;
        }
        /// <summary>
        /// Create_DuplicateBulliten_BulletinItemForm
        /// </summary>
        /// <param name="bulletinName"></param>
        /// <param name="newBullitenName"></param>
        /// <param name="expectedFeedback"></param>
        ///  <param name="pressApply"></param>
        /// <param name="pressOk"></param>
        [UserCodeMethod]
        public static void NS_CreateDuplicateBulliten_BulletinItemForm(string bulletinName, string newBullitenName,string expectedFeedback, bool pressApply, bool closeForm)
        {
        	//Opens Bulletin items form and select the bulletin of type bulletinName
        	NS_OpenBulletinItems_MainMenu();
        	if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("The bulletin Items form is not opened");
        		return;
        	}
        	NS_SetBulletinType_BulletinItemsForm(bulletinName);
        	
        	if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.RibbonMenu.DuplicateBulletinButton.Enabled)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.RibbonMenu.DuplicateBulletinButtonInfo,
        		                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Duplicate_Bulletin.SelfInfo);
        		
        		if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Duplicate_Bulletin.SelfInfo.Exists(0))
        		{
        			SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Duplicate_Bulletin.BulletinNameTextField.Element.SetAttributeValue("Text", newBullitenName);
        			
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Duplicate_Bulletin.OKButtonInfo,
        			                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Duplicate_Bulletin.SelfInfo);
        			if (!CheckFeedback(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Feedback, expectedFeedback))
        			{
        				if (closeForm)
        				{
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
        					                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        				}
        				return;
        			}
        			
        		}
        		else
        		{
        			Ranorex.Report.Error("Item you are waiting for is not found");
        		}
        	}
        	else
        	{
        		Ranorex.Report.Error("Cannot click on the Button as it is not enabled");
        	}
        	//Clicks on 'Apply' button inside 'Bulletin Items  Configuration Form'
        	if(pressApply)
        	{
        		if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.SelfInfo.Exists(0))
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.OkButtonInfo,
        			                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.SelfInfo);
        			if (!CheckFeedback(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Feedback, expectedFeedback))
        			{
        				if (closeForm)
        				{
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
        					                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        				}
        				return;
        			}
        			
        		}
        	}
        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo,SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo);
        	}
        }
        /// <summary>
        /// IncludeInTrainClearance_BulletinItemForm
        /// </summary>
        /// <param name="expBulletinName"></param>
        /// <param name="includeInTrainClearanceOption"></param>
        ///  <param name="pressApply"></param>
        /// <param name="pressOk"></param>
        [UserCodeMethod]
        public static void NS_IncludeInTrainClearance_BulletinItemForm(string expBulletinName, string includeInTrainClearanceOption,string expectedFeedback, bool pressApply,bool closeForm)
        {
        	//Opens Bulletin items form and select the bulletin of type bulletinName
        	NS_OpenBulletinItems_MainMenu();
        	if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("The bulletin Items form is not opened");
        		return;
        	}
        	string actBulletinName = SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameText.GetAttributeValue<string>("SelectionText");
        	if (!expBulletinName.Equals(actBulletinName))
        	{
        		NS_SetBulletinType_BulletinItemsForm(expBulletinName);
        	}
        	if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.IncludeInTrainClearance.IncludeInTrainClearanceText.Enabled)
        	{
        		SystemConfigurationrepo.IncludeInTrainClearance = includeInTrainClearanceOption;
        		
        		GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.IncludeInTrainClearance.IncludeInTrainClearanceTextInfo,
        		                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.IncludeInTrainClearance.IncludeInTrainClearanceList.SelfInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.IncludeInTrainClearance.IncludeInTrainClearanceList.IncludeInTrainClearanceListItemByTextInfo,
        		                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.TypeDefinition.BulletinItemTypeDefinition.IncludeInTrainClearance.IncludeInTrainClearanceList.SelfInfo);
        	}

        	if (pressApply)
        	{
        		if (SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButton.Enabled)
        		{
        			GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo);
        			
        			if (!CheckFeedback(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Feedback, expectedFeedback))
        			{
        				if (closeForm)
        				{
        					GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
        					                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        				}
        				return;
        			}
        		}
        		else
        		{
        			Report.Error("The apply button is disabled, and could not be pressed.");
        		}
        		
        	}
        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo,SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo);
        	}
        }
        /// <summary>
        ///  ClickOkONPrecisionDispatchSystemPopup
        /// </summary>
        /// <param name="PrecisionDispatchSystemPopup"></param>
        /// <param name="expectedFeedback"></param>
        ///  <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ClickOk_BulletinItemTypeConfigurationPopup(string expectedFeedback, bool closeForm)
        {
        	if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Bulletin Items Form Not Open");
        		return;
        	}
        	GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.ApplyButtonInfo,
        	                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.SelfInfo);
        	if (!CheckFeedback(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Feedback, expectedFeedback))
        	{
        		if (closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.OkButtonInfo,
        			                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        		}
        		return;
        	}
        	
        	if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.OkButtonInfo,
        			                                                  SystemConfigurationrepo.Bulletin_Item_Type_Configuration.Precision_Dispatch_System_Popup.SelfInfo);
        		
        	} else {
    			Report.Error("The Precision Dispatch System Popup doesnot exist , can't click on ok Button");
    		}
        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo,SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        	}
        }
        /// <summary>
        ///  ClickOkONPrecisionDispatchSystemPopup
        /// </summary>
        /// <param name="bulletinName"></param>
        /// <param name="expValidateExist"></param>
        ///  <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinNameExists_BulletinItemList(string bulletinName, bool expValidateExist, bool closeForm)
        {
        	NS_OpenBulletinItems_MainMenu();
        	bool actValidateExist = false;
        	SystemConfigurationrepo.BulletinName = bulletinName;
        	if(!SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Error("Bulletin Items Form Not Open");
        		return;
        	}
        	GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameListButtonInfo,
        	                                          SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.SelfInfo);
        	
        	SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinName.EnsureVisible();
        	
        	if(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.BulletinName.BulletinNameList.BulletinNameListItemByBulletinNameInfo.Exists(0))
        	{
        		actValidateExist= true;
        	}
        	if (actValidateExist == expValidateExist)
        	{
        		if (expValidateExist)
        		{
        			Ranorex.Report.Success("Expected BulletinName  in .Bulletin Item Type Configuration Form was found with the value as  {" + bulletinName + "}");
        		}
        		else
        		{
        			Ranorex.Report.Success("Expected BulletinName  does not exist in Bulletin Item Type Configuration Form with the value as  {" + bulletinName + "}");
        		}
        	}
        	else
        	{
        		if (expValidateExist)
        		{
        			Ranorex.Report.Failure("Expected BulletinName  in Bulletin Item Type Configuration Form was found with the value as  {" + bulletinName + "}");
        		}
        		else
        		{
        			Ranorex.Report.Failure("Expected BulletinName  does not exist in .Bulletin Item Type Configuration Form with the value as  {" + bulletinName + "}");
        		}
        	}
        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(SystemConfigurationrepo.Bulletin_Item_Type_Configuration.CancelButtonInfo, SystemConfigurationrepo.Bulletin_Item_Type_Configuration.SelfInfo);
        	}
        }
    }
}
