/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/28/2018
 * Time: 6:32 PM
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

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_MovementPlanner
    {
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.SystemConfiguration_Repo SystemConfigurationrepo = global::PDS_NS.SystemConfiguration_Repo.Instance;


        /// <summary>
        /// Opens the Planning Status Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenPlanningStatusForm_MainMenu()
        {
            int retries = 0;

            //Open Planning Status Form if it's not already open
            if (!SystemConfigurationrepo.Movement_Planning_Status.SelfInfo.Exists(0))
            {
                //Click System Configuration menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
                //Click Movemnt Planning Status in System Configuration menu
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.MovementPlanningStatus.Click();

                //Wait for Planning Staus Form to exist in case of lag
                if (!SystemConfigurationrepo.Movement_Planning_Status.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!SystemConfigurationrepo.Movement_Planning_Status.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!SystemConfigurationrepo.Movement_Planning_Status.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Planning Staus form did not open");
                        return;
                    }
                }
            }

            return;
        }

        /// <summary>
        /// Opens the Movement Planner Configuration Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenMovementPlannerConfigurationForm_MainMenu()
        {
            int retries = 0;

            //Open Movement Planner Configuration Form if it's not already open
            if (!SystemConfigurationrepo.Movement_Planner_Configuration.SelfInfo.Exists(0))
            {
                //Click System Configuration menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButton.Click();
                //Click Movement Planner Configuration in System Configuration menu
                MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.MovementPlannerConfiguration.Click();

                //Wait for Movement Planner Configuration Form to exist in case of lag
                if (!SystemConfigurationrepo.Movement_Planner_Configuration.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!SystemConfigurationrepo.Movement_Planner_Configuration.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!SystemConfigurationrepo.Movement_Planner_Configuration.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Movement Planner Configuration form did not open");
                        return;
                    }
                }
            }

            return;
        }



        /// <summary>
        /// Turns on or off auto router
        /// </summary>
        /// <param name="autoRouterEnabled">Input:Turn on autorouter if true, turns off if false</param>
        /// <param name="closeForms">Input:Close the Movement Planner Configuration</param>
        [UserCodeMethod]
        public static void NS_EnableDisableAutorouter(bool autoRouterEnabled, bool closeForms)
        {
            NS_OpenMovementPlannerConfigurationForm_MainMenu();

            SystemConfigurationrepo.MovementPlannerConfigurationName = "Enable autorouting";
            //Checks if the text value of the cell for autoruter is equal to "TRUE"
            bool currentAutorouterStatus = (SystemConfigurationrepo.Movement_Planner_Configuration.MovementPlannerConfigurationTable.MovementPlannerConfigurationRowByName.Value.GetAttributeValue<string>("Text") == "TRUE") ? true : false;
            if (autoRouterEnabled != currentAutorouterStatus)
            {
                SystemConfigurationrepo.Movement_Planner_Configuration.MovementPlannerConfigurationTable.MovementPlannerConfigurationRowByName.Value.Click();
            }

            Ranorex.Report.Info("Autorouter configured to {"+(autoRouterEnabled ? "Enabled" : "Disabled")+"}.");

            SystemConfigurationrepo.Movement_Planner_Configuration.ApplyButton.Click();

            if (closeForms)
            {
                SystemConfigurationrepo.Movement_Planner_Configuration.CancelButton.Click();
            }
            return;
        }

        /// <summary>
        /// Starts Planning for a region
        /// </summary>
        /// <param name="regionName">Input:Name of the region to start planning</param>
        /// <param name="closeForms">Input:Close the Planning Status Form</param>
        [UserCodeMethod]
        public static void NS_StartPlanningForRegion(string regionName, bool closeForms)
        {
            NS_OpenPlanningStatusForm_MainMenu();

            SystemConfigurationrepo.RegionName = regionName;
            if (!SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Could not find a Planning region with name {"+regionName+"}.");
                return;
            }

            SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.RegionName.Click();

            SystemConfigurationrepo.Movement_Planning_Status.StartPlanningButton.Click();
            int retries = 0;
            while (SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Generating.Text == "NO" && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
                if (retries == 3) {
                    SystemConfigurationrepo.Movement_Planning_Status.StartPlanningButton.Click();
                }
            }

            if (SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Generating.Text == "YES")
            {
                Ranorex.Report.Info("Successfully Planning");
            } else {
                Ranorex.Report.Failure("Planning has failed for region {"+regionName+"}.");
            }

            //Wait for region to finish planning
            retries = 0;
            while (SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Generating.Text == "YES" && retries < 50)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Generating.Text == "YES")
            {
                Ranorex.Report.Failure("Region {"+regionName+"} failed to stop planning");
            }

            if (closeForms)
            {
                SystemConfigurationrepo.Movement_Planning_Status.CloseButton.Click();
            }
            return;
        }

        /// <summary>
        /// Disable Planning for a region
        /// </summary>
        /// <param name="regionName">Input:Name of the region to disable planning</param>
        /// <param name="closeForms">Input:Close the Planning Status Form</param>
        [UserCodeMethod]
        public static void NS_DisablePlanningForRegion(string regionName, bool closeForms)
        {
            NS_OpenPlanningStatusForm_MainMenu();
            //TODO if we add more than one planning region, find planning region, select it, then click
            GeneralUtilities.LeftClickAndWaitForWithRetry(SystemConfigurationrepo.Movement_Planning_Status.DisablePlanningButtonInfo, SystemConfigurationrepo.Movement_Planning_Status.Planning_Status.YesButtonInfo);
            SystemConfigurationrepo.Movement_Planning_Status.Planning_Status.YesButton.Click();
            //TODO validation that planner has stopped planning

            if (closeForms)
            {
                SystemConfigurationrepo.Movement_Planning_Status.CloseButton.Click();
            }
            return;
        }

        /// <summary>
        /// Enable Planning for a region
        /// </summary>
        /// <param name="regionName">Input:Name of the region to enable planning</param>
        /// <param name="closeForms">Input:Close the Planning Status Form</param>
        [UserCodeMethod]
        public static void NS_EnablePlanningForRegion(string regionName, bool closeForms)
        {
            NS_OpenPlanningStatusForm_MainMenu();
            SystemConfigurationrepo.RegionName = regionName;
            int retries = 0;
            while(SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Status.Text.Equals("DISABLED") && retries < 4)
            {
                GeneralUtilities.LeftClickAndWaitForWithRetry(SystemConfigurationrepo.Movement_Planning_Status.EnablePlanningButtonInfo, SystemConfigurationrepo.Movement_Planning_Status.Planning_Status.NoButtonInfo);
                SystemConfigurationrepo.Movement_Planning_Status.Planning_Status.YesButton.Click();
                Ranorex.Delay.Seconds(1);
                retries++;
            }

            if(SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Status.Text.Equals("DISABLED"))
            {
                Report.Error("Failed to enable planning for {"+regionName+"}.");
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Movement_Planning_Status.CloseButtonInfo, SystemConfigurationrepo.Movement_Planning_Status.CloseButtonInfo
                );
            }
            return;
        }
        
        [UserCodeMethod]
        public static void NS_ValidatePlanningStatusForRegion(string regionName, bool validateIsEnabled = true, bool closeForms = true)
        {
            NS_OpenPlanningStatusForm_MainMenu();
            SystemConfigurationrepo.RegionName = regionName;

            bool isEnabled = !SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.PlanningStatusRowByRegionName.Status.Text.Equals("DISABLED");

            string feedbackMessage = string.Format("Expected movement planner status to be enabled '{0}' and actual status is enabled '{1}'", validateIsEnabled, isEnabled);
            if (isEnabled == validateIsEnabled)
            {
                Report.Success("Validation", feedbackMessage);
            } else {
                Report.Failure("Validation", feedbackMessage);
                Report.Screenshot(SystemConfigurationrepo.Movement_Planning_Status.PlanningStatusTable.Self);
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    SystemConfigurationrepo.Movement_Planning_Status.CloseButtonInfo, SystemConfigurationrepo.Movement_Planning_Status.CloseButtonInfo
                );
            }
        }
    }
}
