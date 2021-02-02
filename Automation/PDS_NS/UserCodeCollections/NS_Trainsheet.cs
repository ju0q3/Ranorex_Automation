/*
 * Created by Ranorex
 * User: 212719544
 * Date: 11/6/2018
 * Time: 9:10 AM
 *
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using PDS_CORE.Code_Utils;
using System.Globalization;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Path;
using Ranorex.Core.Testing;
using Oracle.Code_Utils;
using Env.Code_Utils;
using PDS_NS.UserCodeCollections.NS_Oracle;
using Ranorex.Plugin;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Trainsheet
    {

        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
        public static global::PDS_NS.TrainClearance_Repo TrainClearancerepo = global::PDS_NS.TrainClearance_Repo.Instance;
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        public static global::PDS_NS.Trackline_Repo Tracklinerepo = global::PDS_NS.Trackline_Repo.Instance;
        public static int feedbackCounter = 0;
        
        /// <summary>
        /// Opens Trainsheet via the mainmenu, if it is not open
        /// Navigates to Train represented by the trainseed variable
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheet_MainMenu(string trainSeed)
        {
            int retries = 0;
            //If either TrainSeed is not set or nothing is returned for trainID, we will only open the trainsheet and not navigate to a train
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            //Open Trainsheet if it's not already open
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                //Click Trains menu
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                //Click Trainsheet in trains menu
                MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainSheet.Click();

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
            
            if (trainId == null)
            {
                trainId = trainSeed;
            }
            //If TrainId is blank or the existing TrainId on the trainsheet matches the trainId, then we don't need to do anything
            string currentTrainsheetTrainId = Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text");
            if (currentTrainsheetTrainId != trainId)
            {
                Trainsrepo.Train_Sheet.TrainIDText.Element.SetAttributeValue("Text", trainId);
                Trainsrepo.Train_Sheet.TrainIDText.PressKeys("{TAB}");

                retries = 0;
                //Check that origin date appears on the trainsheet, chosen arbitrarily as trains need an origin date.
                //Reasons for needing to retry this is possible ranorex issues or because of delay in MIS propogation
                while ((Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text") != trainId || Trainsrepo.Train_Sheet.OriginDateText.GetAttributeValue<string>("Text") == "") && retries < 5)
                {
                    Ranorex.Delay.Seconds(1);
                    Trainsrepo.Train_Sheet.TrainIDText.Element.SetAttributeValue("Text", trainId);
                    Trainsrepo.Train_Sheet.TrainIDText.PressKeys("{TAB}");
                    retries++;
                }

                if (Trainsrepo.Train_Sheet.OriginDateText.GetAttributeValue<string>("Text") == "" || Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text") != trainId)
                {
                    //collect feedback in case there is any
                    string feedBack = Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text");
                    Ranorex.Report.Error("Unable to access trainsheet for TrainId {"+trainId+"}, Feedback found is {"+feedBack+"}.");
                    return;
                }
            }
            
            return;
        }
        
        /// <summary>
        /// Returns false if the train doesn't exist and true if it does exist
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static bool NS_OpenTrainsheetIfTrainExists_MainMenu(string trainSeed)
        {
            int retries = 0;
            //If either TrainSeed is not set or nothing is returned for trainID, we will only open the trainsheet and not navigate to a train
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return false;
            }
            
            //Open Trainsheet if it's not already open
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                //Click Trains menu
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                //Click Trainsheet in trains menu
                MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainSheet.Click();

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
                        return false;
                    }
                }
            }
            
            if (trainId == null)
            {
                trainId = trainSeed;
            }
            //If TrainId is blank or the existing TrainId on the trainsheet matches the trainId, then we don't need to do anything
            string currentTrainsheetTrainId = Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text");
            if (currentTrainsheetTrainId != trainId)
            {
                Trainsrepo.Train_Sheet.TrainIDText.Element.SetAttributeValue("Text", trainId);
                Trainsrepo.Train_Sheet.TrainIDText.PressKeys("{TAB}");

                retries = 0;
                //Check that origin date appears on the trainsheet, chosen arbitrarily as trains need an origin date.
                //Reasons for needing to retry this is possible ranorex issues or because of delay in MIS propogation
                while ((Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text") != trainId || Trainsrepo.Train_Sheet.OriginDateText.GetAttributeValue<string>("Text") == "") && retries < 5)
                {
                    Ranorex.Delay.Seconds(1);
                    Trainsrepo.Train_Sheet.TrainIDText.Element.SetAttributeValue("Text", trainId);
                    Trainsrepo.Train_Sheet.TrainIDText.PressKeys("{TAB}");
                    retries++;
                }

                if (Trainsrepo.Train_Sheet.OriginDateText.GetAttributeValue<string>("Text") == "" || Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text") != trainId)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                    return false;
                }
            }
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            return true;
        }

        /// <summary>
        /// Opens Train Status Summary via the mainmenu, if it is not open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTrainStatusSummary_MainMenu()
        {
            int retries = 0;

            //Open Train Status Summary if it's not already open
            if (!Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
            {
                //Click Trains menu
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                //Click Train Status Summary in trains menu
                MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainStatusSummary.Click();

                //Wait for Train Status Summary to exist in case of lag
                if (!Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Train Status Summary Form did not open");
                        return;
                    }
                }
                //After it exists, wait for values to start propogating
                retries = 0;
                int trainRows = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.Self.Rows.Count;
                bool finished = false;
                while (!finished && retries < 2)
                {
                    Ranorex.Delay.Seconds(1);
                    //As long as the count changes within the second, we will continue waiting in the loop

                    if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.Self.Rows.Count == 0)
                    {
                        retries++;
                        continue;
                    }

                    if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.Self.Rows.Count != trainRows)
                    {
                        trainRows = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.Self.Rows.Count;
                        continue;
                    }

                    finished = true;
                }

                if (trainRows == 0)
                {
                    Ranorex.Report.Info("No Trains found in Train Status Summary");
                }
            }
            return;
        }


        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Trip Plan tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetTripPlan_MainMenu(string trainSeed)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }
            
            int retries = 0;
            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Trip Plan Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Trip Plan Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("Trip Plan Table failed to load basic trip plan, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Engine tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetEngine_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Engine Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.Engine.EngineTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.Engine.EngineTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Engine Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("Engine Table failed to load engine input row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Crew tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetCrew_MainMenu(string trainSeed)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.GetAttributeValue<bool>("Selected"))
            {
                return;
            }
            
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Crew Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.Crew.CrewTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.Crew.CrewTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Crew Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("Crew Table failed to load crew input row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Train tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetTrain_MainMenu(string trainSeed)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            int retries = 0;
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Train Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for subTabs to Exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo.Exists(0))
            {
                Ranorex.Report.Error("Train Table failed to exist, suspected failure for PDS to properly load Train Sheet");
            }
            
            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Movement tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetMovement_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Movement Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.Movement.MovementInputTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.Movement.MovementInputTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Movement Input Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.Movement.MovementInputTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.Movement.MovementInputTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("Movement Input Table failed to load movement input row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Delay tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetDelay_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select Delay Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.Delay.DelayInputTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.Delay.DelayInputTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Delay Input Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.Delay.DelayInputTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.Delay.DelayInputTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("Delay Input Table failed to load delay input row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the EOT/Caboose tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetEOTCaboose_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.GetAttributeValue<bool>("Selected") && retries < 5)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select EOT Caboose Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.SelfInfo.Exists(0) && retries < 5)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("EOT Caboose Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.Self.Rows.Count == 0 && retries < 5)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("EOT Caboose Table failed to load eot caboose input row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Railcar tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetRailcar_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            //If it's already selected, we're done
            if (Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.GetAttributeValue<bool>("Selected"))
            {
                return;
            }
            Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Click();

            while (!Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.GetAttributeValue<bool>("Selected") && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Click();
                retries++;
            }

            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.GetAttributeValue<bool>("Selected")) {
                Ranorex.Report.Error("Unable to select Railcar Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
            }

            return;
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the History tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetHistory_MainMenu(string trainSeed)
        {
            int retries = 0;
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If it's already selected, we're done
            if (!Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Click();
                
                while (!Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.GetAttributeValue<bool>("Selected") && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Click();
                    retries++;
                }
                
                if (!Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.GetAttributeValue<bool>("Selected")) {
                    Ranorex.Report.Error("Unable to select History Tab for Train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            
            //Wait for table to exist
            retries = 0;
            while (!Trainsrepo.Train_Sheet.History.HistoryTable.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.History.HistoryTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("History Table failed to exist, suspected failure for PDS to properly load Train Sheet");
                return;
            }
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.History.HistoryTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.History.HistoryTable.Self.Rows.Count == 0)
            {
                Ranorex.Report.Error("History Table failed to load a history row, suspected failure for PDS to properly load Train Sheet");
            }

            return;
        }

        public static void NS_OpenPrintDialog_Trainsheet()
        {
            // Assumes train sheet is already open, and already has the correct train/tab present.
            // The method is not informed about where to go. Its scope is to open the print dialog from an open train sheet.
            // Logic to open the train sheet should be handled by another actor.

            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Train sheet is not open");
                return;
            }

            Trainsrepo.Train_Sheet.MainMenuBar.FileButton.Click();
            Trainsrepo.Train_Sheet.FileMenu.Print.Click();

            int iteration = 0;
            while (!Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && iteration < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                if (Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    break;
                }
                iteration++;
            }

            if (!Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("PDS Print Fax Dialog does not exist");
                return;
            }

        }
        
        /// <summary>
        /// Opens Create Train Form via the mainmenu, if it is not open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenCreateTrain_MainMenu()
        {
            int retries = 0;

            if (!Trainsrepo.Create_Train.SelfInfo.Exists(0))
            {
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrainsMenu.CreateTrainInfo,Trainsrepo.Create_Train.SelfInfo);

                if (!Trainsrepo.Create_Train.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Trainsrepo.Create_Train.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Trainsrepo.Create_Train.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Create Train Form did not open");
                    }
                    else
                    {
                    	Ranorex.Report.Info("Create Train form opened successfully");
                    }
                }                
            }
            return;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="quantity"></param>
        /// <param name="type"></param>
        /// <param name="optPrintSelection"></param>
        /// <param name="optNumberCopies"></param>
        [UserCodeMethod]
        public static void NS_PrintFax_PrintDialog_Trainsheet(string name, string address, int quantity, string printType)
        {
            // Assumes train sheet is already open, and already has the correct train/tab present.
            // The method is not informed about where to go. Its scope is to interface with the print dialog.
            // Logic to open the train sheet should be handled by another actor.

            NS_OpenPrintDialog_Trainsheet();

            GeneralUtilities.ClickAndWaitForWithRetry(
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.AdhocButtonInfo,
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo
               );

            Trainsrepo.RecipientIndex = "0";

            // TODO: Logic to validate correct entry? General utils available?
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.Click();
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.PressKeys(name);
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.Click();
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.PressKeys(address);
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.Click();
            Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.PressKeys(quantity.ToString());

            GeneralUtilities.ClickAndWaitForWithRetry(
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.SelfInfo,
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.SelfInfo
               );

            switch (printType.ToLower())
            {
                case "printer":
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Printer.Click();
                    break;
                case "fax":
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Fax.Click();
                    break;
                case "email":
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Email.Click();
                    break;
                case "pager":
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Pager.Click();
                    break;
                default:
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.blank.Click();
                    break;
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.IssueButtonInfo,
                Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo
               );

            // Give the form a moment to close before declaring a failure.
            int iteration = 0;
            while (Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && iteration < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                if (!Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    break;
                }
                iteration++;
            }

            // If the PDS Print/Fix Dialog fails to close, this represents a de-facto failure in creating a PrintFax message.
            // This also necessitates an additional step to close the form manually, so that this does not lead to a cascading failure.
            if (Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.CancelButtonInfo,
                    Trainsrepo.Train_Sheet.PDS_Print_Fax_Dialog.SelfInfo
                   );
                Ranorex.Report.Error("Print form was not successfully closed, and no PrintFax MIS message sent.");
            } else {
                Ranorex.Report.Success("Print form successfully completed.");
            }
        }

        [UserCodeMethod]
        public static void NS_CrewLogoff_Trainsheet(string trainSeed)
        {
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);

            if (!Trainsrepo.Train_Sheet.Crew.PTCLogoffButton.Enabled)
            {
                Report.Error("PTC Logoff button is not enabled");
            } else {
                GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Crew.PTCLogoffButtonInfo, Trainsrepo.Train_Sheet.Crew.Confirm_PTC_Crew_Logoff.YesButtonInfo);

                if (Trainsrepo.Train_Sheet.Crew.Confirm_PTC_Crew_Logoff.SelfInfo.Exists(0))
                {
                    Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Confirm_PTC_Crew_Logoff.Self);
                }
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.Crew.Confirm_PTC_Crew_Logoff.YesButtonInfo,
                    Trainsrepo.Train_Sheet.Crew.Confirm_PTC_Crew_Logoff.YesButtonInfo
                   );
            }

            int retries = 0;
            while (Trainsrepo.Train_Sheet.Crew.PTCLogoffButton.Enabled & retries < 8)
            {
                Ranorex.Delay.Milliseconds(250);
                retries++;
            }

            if (Trainsrepo.Train_Sheet.Crew.PTCLogoffButton.Enabled)
            {
                string trainId = NS_TrainID.GetTrainId(trainSeed);
                Report.Error("Force PTC Logoff failed for train: " + trainId);
            } else {
	                Report.Success("Force PTC Logoff successful.");
            }
        }



        /// <summary>
        /// Open update Tracking, opening the trainsheet and update tracking if necessary
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenUpdateTracking_MainMenu(string trainSeed)
        {
            if (!Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
            {
                NS_OpenTrainsheet_MainMenu(trainSeed);

                Trainsrepo.Train_Sheet.MainMenuBar.EditButton.Click();
                //    			Trainsrepo.Train_Sheet.EditMenu.OpenUpdateTracking.Click();
//
                //    			int retries = 0;
                //    			while (!Trainsrepo.Train_Sheet.Update_Tracking.SelfInfo.Exists(0) && retries < 5)
//	    		{
                //    				if (retries == 2 && Trainsrepo.Train_Sheet.EditMenu.SelfInfo.Exists(0))
                //    				{
                //    					Trainsrepo.Train_Sheet.EditMenu.OpenUpdateTracking.Click();
                //    				}
//	    			Ranorex.Delay.Milliseconds(500);
//	    			retries++;
//	    		}
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EditMenu.OpenUpdateTrackingInfo, Trainsrepo.Update_Tracking.SelfInfo, WinForms.MouseButtons.Left);

                if (!Trainsrepo.Update_Tracking.SelfInfo.Exists(0)) {
                    Ranorex.Report.Error("Unable to open update tracking form for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                }
            }

            return;
        }

        /// <summary>
        /// Close Trainsheet, resetting form if necessary
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseTrainsheet()
        {
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                //Trainsheet is already closed, return
                return;
            }

//			var refreshButton = Trainsrepo.Train_Sheet.TripPlan.ResetButton;
//			//If Reset button is enabled, we should reset before attempting to close
//			if(Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Selected)
//			{
//				refreshButton = Trainsrepo.Train_Sheet.Engine.RefreshResetButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.Crew.ResetButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.Train.RefreshButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.Movement.RefreshButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.Delay.RefreshButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.EOTCaboose.ResetButton;
//			} else if (Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Selected) {
//				refreshButton = Trainsrepo.Train_Sheet.History.RefreshButton;
//			}
//
//			if (refreshButton.Enabled)
//			{
//				refreshButton.Click();
//			}

            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            if (Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Could not close Trainsheet");
            }
            return;
        }

        /// <summary>
        /// Close Train Status Summary
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseTrainStatusSummary()
        {
            Trainsrepo.Train_Status_Summary.WindowControls.Close.Click();
            return;
        }

        /// <summary>
        /// Validate a Line in Trainsheet History via regex or generated regex from BuildTrainHistory
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="TrainHistoryType">Input:one of the cases from function BuildTrainHistory</param>
        /// <param name="optionalDate">opional input</param>
        /// <param name="optionalTime">opional input</param>
        /// <param name="optionalDivision">opional input</param>
        /// <param name="optionalDistrict">opional input</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainSheetHistory(string trainSeed, string TrainHistoryType, string optionalDate, string optionalTime, string optionalDivision, string optionalDistrict, bool closeTrainsheet = false)
        {
            NS_OpenTrainsheetHistory_MainMenu(trainSeed);

            //TrainHistoryType is necessary for a minimum comparison
            if (TrainHistoryType == "")
            {
                Ranorex.Report.Failure("TrainHistoryType is blank, cannot compare to history sheet.");
                if (closeTrainsheet)
                {
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                }
                return;
            }
            //Get how many row to iterate through from the History Table
            int historyRowsNumber = Trainsrepo.Train_Sheet.History.HistoryTable.Self.Rows.Count;

            //if the TrainHistoryType doesn't match a case in BuildTrainHistoryRegex then trainHistoryType is the assumed regex
            string trainHistoryText = BuildTrainHistoryRegex(trainSeed, TrainHistoryType);
            Ranorex.Report.Info("TestStep", "Validating Train History for: "+@trainHistoryText);

            //Creating Regex from string
            Regex regexedString = new Regex(trainHistoryText);

            //Iterating through Train Sheet History rows to check for regex by using the iteration as the index for HistoryTable
            for (int i = 0; i < historyRowsNumber; i++)
            {
                Trainsrepo.HistoryIndex = i.ToString();
                //Pulling the text from the History Entry
                string rowHistoryString = Trainsrepo.Train_Sheet.History.HistoryTable.HistoryRowByIndex.HistoryEntry.GetAttributeValue<string>("Text");
                if (regexedString.IsMatch(rowHistoryString))
                {
                    //If one of the optional values don't match, this may be referring to a different history entry so it will continue to search the table
                    if (optionalDate != "")
                    {
                        string rowDateString = Trainsrepo.Train_Sheet.History.HistoryTable.HistoryRowByIndex.Date.GetAttributeValue<string>("Text");
                        if (!rowDateString.Contains(optionalDate)) {
                            continue;
                        }
                    }

                    if (optionalTime != "")
                    {
                        string rowTimeString = Trainsrepo.Train_Sheet.History.HistoryTable.HistoryRowByIndex.Time.GetAttributeValue<string>("Text");
                        if (!rowTimeString.Contains(optionalTime)) {
                            continue;
                        }
                    }

                    if (optionalDivision != "")
                    {
                        string rowDivisionString = Trainsrepo.Train_Sheet.History.HistoryTable.HistoryRowByIndex.Division.GetAttributeValue<string>("Text");
                        if (!rowDivisionString.Contains(optionalDivision)) {
                            continue;
                        }
                    }

                    if (optionalDistrict != "")
                    {
                        string rowDistrictString = Trainsrepo.Train_Sheet.History.HistoryTable.HistoryRowByIndex.District.GetAttributeValue<string>("Text");
                        if (!rowDistrictString.Contains(optionalDistrict)) {
                            continue;
                        }
                    }

                    Ranorex.Report.Success("Regex: {"+@trainHistoryText+"} found in Train History Line: {"+rowHistoryString+"} For train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    if (closeTrainsheet)
                    {
                        Trainsrepo.Train_Sheet.CancelButton.Click();
                    }
                    return;
                }
            }
            Ranorex.Report.Failure("Regex: {"+@trainHistoryText+"} not found in Train History for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
            if (closeTrainsheet)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
            return;
        }

        /// <summary>
        /// Building the trainsheet history text
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="trainHistoryTextType">Input:one of the cases from function BuildTrainHistoryTextMessage</param>
        /// <returns></returns>
        public static string BuildTrainHistoryRegex(string trainSeed, string trainHistoryTextType)
        {
            string trainHistoryText = trainHistoryTextType;

            switch(trainHistoryTextType)
            {
                case "PTCReRegistration" :
                    trainHistoryText = "PTC re-registration for "+PDS_CORE.Code_Utils.CN_TrainID.GetPTCEngineId(trainSeed)+" with TGBO "+PDS_CORE.Code_Utils.CN_TrainID.GetTrainClearance(trainSeed)+".";
                    break;
                case "PTCCrewLogon" :
                    trainHistoryText = "PTC crew logon with TGBO "+PDS_CORE.Code_Utils.CN_TrainID.GetTrainClearance(trainSeed)+".";
                    break;
                case "PTCCrewInformation" :
                    trainHistoryText = "PTC crew information received for "+PDS_CORE.Code_Utils.CN_TrainID.GetPTCEngineId(trainSeed)+", engineer "+PDS_CORE.Code_Utils.CN_TrainID.GetPTCCrewName(trainSeed)+" from "+PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed)+".";
                    break;
                case "PTCCrewCutOut" :
                    trainHistoryText = "PTC crew cutout by CREW";
                    break;
                case "PTCDispatcherCutOut" :
                    trainHistoryText = "PTC crew cutout by USER";
                    break;
                case "LocomotivestatusreportUpdate" :
                    trainHistoryText = PDS_CORE.Code_Utils.CN_TrainID.GetPTCEngineId(trainSeed)+" reported "+PDS_CORE.Code_Utils.CN_TrainID.GetLocoState(trainSeed)+" at "+System.DateTime.Now.ToString("MM-dd-yyyy")+@".*, account "+PDS_CORE.Code_Utils.CN_TrainID.GetTriggerType(trainSeed)+".";
                    break;
                case "PTCOnStatus" :
                    trainHistoryText = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed)+" with Identifying Engine "+PDS_CORE.Code_Utils.CN_TrainID.GetPTCEngineId(trainSeed)+" reported the PTC Status Initializing.";
                    break;
                case "PTCOffStatus" :
                    trainHistoryText = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed)+" with Identifying Engine  reported the PTC Status Logged-Off.";
                    break;
                case "VoidPSS" :
                    trainHistoryText = "Void Pass Stop Signal for "+ PDS_CORE.Code_Utils.CN_TrainID.GetPTCEngineId(trainSeed);
                    break;
            }
            return trainHistoryText;
        }


        /// <summary>
        /// Completes Trip for train
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="clickOk">Input:clickOk</param>
        [UserCodeMethod]
        public static void NS_CompleteTripPlanForTrain(string trainSeed,bool clickOk)
        {
            NS_Trainsheet.NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            int tripPlanRows = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            int retries = 0;
            while (tripPlanRows == 0 && retries < 3) {
                Ranorex.Delay.Milliseconds(500);
                tripPlanRows = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
                retries++;
            }
            tripPlanRows--;
            //Move to final row to complete trip
            Trainsrepo.TripPlanIndex = tripPlanRows.ToString();
            if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.GetAttributeValue<bool>("Selected"))
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
                //Need to wait for TripPlan Details to update, and since the originate can also be the terminate, there's no data to check for change so have to add a delay
                //Ranorex.Delay.Milliseconds(500);
            }
            string terminationStatus = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusText.GetAttributeValue<string>("Text");
            if (terminationStatus == "Manually Completed" || terminationStatus == "Completed")
            {
                Ranorex.Report.Info("Termination already complete for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                return;
            }
            
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusList.SelfInfo);
            //Set to Manually Complete
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusList.ManuallyCompleted.Click();

            //Move to Terminate location
            if (Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo.Exists(0))
            {
                Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.NoButton.Click();
            }

            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo, Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);

            if(clickOk)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo, Trainsrepo.Train_Sheet.TripPlan.SelfInfo);
                //Trainsrepo.Train_Sheet.OkButton.Click();
            }

            return;
        }

        /// <summary>
        /// Removes all Crews For Train
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_RemoveCrewsForTrain(string trainSeed)
        {
            NS_Trainsheet.NS_OpenTrainsheetCrew_MainMenu(trainSeed);
            int crewMemberRows = Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count;

            for (int i=1; i<crewMemberRows; i++)
            {
                Trainsrepo.CrewIndex = i.ToString();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Self.EnsureVisible();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
                Trainsrepo.Train_Sheet.Crew.CrewMenuCellMenu.DeleteRow.Click();
            }
            Trainsrepo.Train_Sheet.Crew.ApplyButton.Click();
        }

        /// <summary>
        /// Terminates Train
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_TerminateTrain(string trainSeed)
        {
            NS_Trainsheet.NS_OpenTrainsheet_MainMenu(trainSeed);
            //If it's not enabled it can't terminate
            int retries = 0;
            while (!Trainsrepo.Train_Sheet.TerminateButton.Enabled && retries < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                retries++;
            }
            if (!Trainsrepo.Train_Sheet.TerminateButton.Enabled)
            {
                Ranorex.Report.Error("Unable to terminate Train");
                return;
            }

            GeneralUtilities.ClickAndWaitForWithRetry(
                Trainsrepo.Train_Sheet.TerminateButtonInfo,
                Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo
            );

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo,
                Trainsrepo.Train_Sheet.Confirm_Train_Terminate.SelfInfo
            );

            retries = 0;
            while (Trainsrepo.Train_Sheet.TerminateButton.Enabled && retries < 4)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.TerminateButton.Enabled)
            {
                Ranorex.Report.Error("Failed to terminate Train");
            }
            return;
            
        }
        
        /// <summary>
        /// Validates state of terminate train button
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="validateEnabled">Input:validateEnabled</param>
        /// <param name="closeForm">Input:closeForm</param>
        [UserCodeMethod]
        public static void NS_TerminateTrainAndValidateUnsuccessful_Trainsheet(string trainSeed, bool closeForm)
        {
        	NS_Trainsheet.NS_OpenTrainsheet_MainMenu(trainSeed);
        	//If it's not enabled it can't terminate
            int retries = 0;
            while (!Trainsrepo.Train_Sheet.TerminateButton.Enabled && retries < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                retries++;
            }
        	if (!Trainsrepo.Train_Sheet.TerminateButton.Enabled)
        	{
        		Ranorex.Report.Success("Terminate Train Button found to be Disabled");
        		if (closeForm)
	        	{
	        		NS_CloseTrainsheet();
	        	}
        		return;
        	}
        	
        	Trainsrepo.Train_Sheet.TerminateButton.Click();
            Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButton.Click();
            
            retries = 0;
            while (Trainsrepo.Train_Sheet.TerminateButton.Enabled && retries < 4)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (Trainsrepo.Train_Sheet.TerminateButton.Enabled)
            {
            	Ranorex.Report.Success("Terminate Train Button is still Enabled");
            } else {
                Ranorex.Report.Failure("Train was successfully Terminated");
            }
        	
        	if (closeForm)
        	{
        		NS_CloseTrainsheet();
        	}
        	return;
        }

        /// <summary>
        /// Used when automation needs to update an activity based on user defined info.
        /// </summary>
        /// <param name="trainSeed">Key of train to be used</param>
        /// <param name="activity">Activity name of activity to be updated (WARNING:THIS ONLY SEES THE FIRST ACTIVITY FOR ITS TYPE)</param>
        /// <param name="toDistrict">To district location</param>
        /// <param name="toMilepost">To milepost location</param>
        /// <param name="toTrack">To Track selection</param>
        /// <param name="fromDistrict">From district location</param>
        /// <param name="fromMilepost">From milepost location</param>
        /// <param name="fromTrack">From track selection</param>
        /// <param name="closeForms">whether or not we want to close the trainsheet</param>
        /// <param name="expectedFeedback">a non-empty string willcheck for feedback</param>
        [UserCodeMethod]
        public static void NS_UpdateActivityLocation(string trainSeed, string activity, string toDistrict, string toMilepost, string toTrack, string fromDistrict, string fromMilepost, string fromTrack, bool closeForms, string expectedFeedback)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            Trainsrepo.TripPlanActivity = activity;
            Trainsrepo.DistrictName = toDistrict;
            Trainsrepo.TrackName = toTrack;

            if (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.ActivityInfo.Exists(0))
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
            }
            else
            {
                Ranorex.Report.Error("Couldn't find activity: {"+activity+"}.");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }

            //Could check if these values are alrady what we want them to be, but usually we know ahead of time and they aren't which is why we're chaning them
            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.UserDefinedInfo);

            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.UserDefined.Click();

            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrictTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityDistrictList.SelfInfo);
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityDistrictList.ToActivityDistrictListItemByDistrict.EnsureVisible();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityDistrictList.ToActivityDistrictListItemByDistrict.Click();
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.Click();
            Ranorex.Keyboard.Press(Keys.Back);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.PressKeys(toMilepost);
            
            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityTrack.ToActivityTrackTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityTrack.ToActivityTrackList.SelfInfo);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityTrack.ToActivityTrackList.ToActivityTrackListItemByTrackName.EnsureVisible();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityTrack.ToActivityTrackList.ToActivityTrackListItemByTrackName.Click();
            if (!fromDistrict.Equals(""))
            {
            	Trainsrepo.DistrictName = fromDistrict;
	            Trainsrepo.TrackName = fromTrack;
	
	            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrictTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityDistrictList.SelfInfo);
	            
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityDistrictList.FromActivityDistrictListItemByDistrict.EnsureVisible();
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityDistrictList.FromActivityDistrictListItemByDistrict.Click();
	            
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.Click();
	            Ranorex.Keyboard.Press(Keys.Back);
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.PressKeys(fromMilepost);
	            
	            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.SelfInfo);
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackName.EnsureVisible();
	            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackName.Click();           
            }
            
            Trainsrepo.Train_Sheet.TripPlan.ApplyButton.Click();

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }

            return;
        }
        
        [UserCodeMethod]
        public static void NS_UpdateEarliestDepartByMinutes(string trainSeed, string activity, int minutes, bool closeForms, string expectedFeedback)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            Trainsrepo.TripPlanActivity = activity;

            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();

            GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepartInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.CalendarComboBoxInfo);

            string currentTime = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.CalendarComboBox.Element.GetAttributeValueText("text");

            string timeWithoutTZ = currentTime.Substring(0, currentTime.Length-2);
            timeWithoutTZ = timeWithoutTZ + "M"; //Append Meridiem
            string timeZone = currentTime.Substring(currentTime.Length-1);

            System.DateTime departTime = System.DateTime.ParseExact(timeWithoutTZ, "MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture);
            departTime = departTime.AddMinutes(minutes);

            string newTime = departTime.ToString("MM-dd-yyyy hh:mm tt");
            newTime = newTime.Substring(0, newTime.Length-1) + " " + timeZone; //trim meridiem

            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys(newTime); //Seems fragile during testing, to be safe, lets do full entry
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys("{Tab}");

            Trainsrepo.Train_Sheet.TripPlan.ApplyButton.Click();

            if (closeForms)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }

            return;
        }

        /// <summary>
        /// Moves train to particular milepost via the update tracking form
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="milePost">Input:Milepost location for train</param>
        /// <param name="district">Input:district of milepost location, usually only one generally can leave blank</param>
        /// <param name="track">Input:track of milepost location, generally can leave blank</param>
        /// <param name="direction">Input:direction, i.e. North or N</param>
        /// <param name="trackPosition">Input:track position i.e. Departure List or On Track</param>
        /// <param name="closeForms">Input:Closes the trainsheet after updating tracking</param>
        /// <param name="expectedFeedback">Input:If this is supposed to be an error case</param>
        [UserCodeMethod]
        public static void NS_FillUpdateTracking(string trainSeed, string milePost, string district, string track, string direction, string trackPosition, bool closeForms, string expectedFeedback)
        {
            NS_OpenUpdateTracking_MainMenu(trainSeed);

            Trainsrepo.Update_Tracking.MilePostText.Click();
            if (milePost != "") {
                Trainsrepo.Update_Tracking.MilePostText.Element.SetAttributeValue("Text", milePost);
            }
            Trainsrepo.Update_Tracking.MilePostText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Update_Tracking.Feedback, expectedFeedback))
            {
                Trainsrepo.Update_Tracking.CancelButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            if (district != "") {
                IList<ListItem> districtItems = Trainsrepo.Update_Tracking.District.DistrictText.Items;
                bool found = false;
                foreach (ListItem districtItem in districtItems)
                {
                    if (districtItem.GetAttributeValue<string>("Text").Contains(district))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    Trainsrepo.DistrictName = district;
                    Trainsrepo.Update_Tracking.District.DistrictMenuButton.Click();
                    Trainsrepo.Update_Tracking.District.DistrictMenuList.DistrictListItemByDistrictName.Click();
                } else {
                    Trainsrepo.Update_Tracking.District.DistrictText.Element.SetAttributeValue("Text", district);
                }
            }
            Trainsrepo.Update_Tracking.District.DistrictText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Update_Tracking.Feedback, expectedFeedback))
            {
                Trainsrepo.Update_Tracking.CancelButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            if (track != "") {
                IList<ListItem> trackItems = Trainsrepo.Update_Tracking.Track.TrackText.Items;
                bool found = false;
                foreach (ListItem trackItem in trackItems)
                {
                    if (trackItem.GetAttributeValue<string>("Text").Contains(track))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    Trainsrepo.TrackName = track;
                    Trainsrepo.Update_Tracking.Track.TrackMenuButton.Click();
                    Trainsrepo.Update_Tracking.Track.TrackMenuList.TrackListItemByTrackName.Click();
                } else {
                    Trainsrepo.Update_Tracking.Track.TrackText.Element.SetAttributeValue("Text", track);
                }
            }
            Trainsrepo.Update_Tracking.Track.TrackText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Update_Tracking.Feedback, expectedFeedback))
            {
                Trainsrepo.Update_Tracking.CancelButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            if (direction != "") {
                if ((direction == "N" || direction == "North") && !Trainsrepo.Update_Tracking.Direction.NorthRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.NorthRadioButton.Click();
                } else if ((direction == "S" || direction == "South") && !Trainsrepo.Update_Tracking.Direction.SouthRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.SouthRadioButton.Click();
                } else if ((direction == "E" || direction == "East") && !Trainsrepo.Update_Tracking.Direction.EastRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.EastRadioButton.Click();
                } else if ((direction == "W" || direction == "West") && !Trainsrepo.Update_Tracking.Direction.WestRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.WestRadioButton.Click();
                }
            }

            if (trackPosition != "") {
                if ((trackPosition == "On Track" || trackPosition == "OnTrack") && !Trainsrepo.Update_Tracking.Destination.OnTrackRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Destination.OnTrackRadioButton.Click();
                } else if ((trackPosition == "Departure List" || trackPosition == "DepartureList") && !Trainsrepo.Update_Tracking.Destination.DepartureListRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Destination.DepartureListRadioButton.Click();
                }
            }

            Report.Info("Updating tracking for train");
            Trainsrepo.Update_Tracking.OkButton.Click();

            int retries = 0;
            while(Trainsrepo.Update_Tracking.SelfInfo.Exists(0) && retries < 5)
            {
                if (retries == 2)
                {
                    Trainsrepo.Update_Tracking.OkButton.Click();
                }
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
            {
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Update_Tracking.Feedback, expectedFeedback))
                {
                    Trainsrepo.Update_Tracking.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            if(expectedFeedback != "") {
                Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }

            return;

        }
        
        /// <summary>
        /// Moves train to particular milepost via the update tracking form
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="milePost">Input:Milepost location for train</param>
        /// <param name="district">Input:district of milepost location, usually only one generally can leave blank</param>
        /// <param name="track">Input:track of milepost location, generally can leave blank</param>
        /// <param name="direction">Input:direction, i.e. North or N</param>
        /// <param name="trackPosition">Input:track position i.e. Departure List or On Track</param>
        /// <param name="closeForms">Input:Closes the trainsheet after updating tracking</param>
        /// <param name="expectedFeedback">Input:If this is supposed to be an error case</param>
        [UserCodeMethod]
        public static void NS_UpdateTrackingMiddleClickTrackline_Trainsheet(string trainSeed, string trackSection, string direction, string trackPosition, bool closeForms, string expectedFeedback)
        {
            NS_OpenUpdateTracking_MainMenu(trainSeed);
            
            Tracklinerepo.TrackSectionId = trackSection;
            if (!Tracklinerepo.Trackline_Form.TrackSectionObjectInfo.Exists(0))
            {
                Ranorex.Report.Error("Could not find Track Section {" + trackSection + "}. Please ensure the correct territories are in control");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Update_Tracking.CancelButtonInfo, Trainsrepo.Update_Tracking.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            Tracklinerepo.Trackline_Form.TrackSectionObject.EnsureVisible();
            GeneralUtilities.MiddleClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrackSectionObjectInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Mile_Post_Selection.SelfInfo);
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Mile_Post_Selection.MilePostSliderInfo);
            
            if (direction != "") {
                if ((direction == "N" || direction == "North") && !Trainsrepo.Update_Tracking.Direction.NorthRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.NorthRadioButton.Click();
                } else if ((direction == "S" || direction == "South") && !Trainsrepo.Update_Tracking.Direction.SouthRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.SouthRadioButton.Click();
                } else if ((direction == "E" || direction == "East") && !Trainsrepo.Update_Tracking.Direction.EastRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.EastRadioButton.Click();
                } else if ((direction == "W" || direction == "West") && !Trainsrepo.Update_Tracking.Direction.WestRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Direction.WestRadioButton.Click();
                }
            }

            if (trackPosition != "") {
                if ((trackPosition == "On Track" || trackPosition == "OnTrack") && !Trainsrepo.Update_Tracking.Destination.OnTrackRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Destination.OnTrackRadioButton.Click();
                } else if ((trackPosition == "Departure List" || trackPosition == "DepartureList") && !Trainsrepo.Update_Tracking.Destination.DepartureListRadioButton.Checked)
                {
                    Trainsrepo.Update_Tracking.Destination.DepartureListRadioButton.Click();
                }
            }
            
            Trainsrepo.Update_Tracking.OkButton.Click();

            int retries = 0;
            while(Trainsrepo.Update_Tracking.SelfInfo.Exists(0) && retries < 5)
            {
                if (retries == 2)
                {
                    Trainsrepo.Update_Tracking.OkButton.Click();
                }
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            if (Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
            {
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Update_Tracking.Feedback, expectedFeedback))
                {
                    Trainsrepo.Update_Tracking.CancelButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            if(expectedFeedback != "") {
                Ranorex.Report.Failure("Feedback {"+expectedFeedback+"} was not found.");
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }

            return;
        }
        
        [UserCodeMethod]
        public static void NS_PutTrainOnTrackSectionOnTrack_UpdateTracking(string trainSeed, string trackSection, string direction)
        {
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            //Check if train is already on the track section
            Tracklinerepo.TrainId = trainId;
            VMEnvironment vm = VMEnvironment.Instance();
        	Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);
            
        	string trackLabelId = TDMSDb.GetTrackLabelfromAssociatedTrackSectionId(trackSection);
        	
            if (Tracklinerepo.Trackline_Form.TrainObjectInfo.Exists(0))
            {
                string trainsCurrentTrackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
                
                if (trainsCurrentTrackLabelId == trackLabelId)
            	{
            	    return;
            	}
            }
            
            //Check if another train is currently on the track section and remove it if there is
            Tracklinerepo.TLSId = trackLabelId;
            if (Tracklinerepo.Trackline_Form.TrainObjectByTLSIdInfo.Exists(0))
            {
            	Tracklinerepo.Trackline_Form.TrainObjectByTLSId.EnsureVisible();
                GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrainObjectByTLSIdInfo, Tracklinerepo.Trackline_Form.TrainObjectMenu.SelfInfo);
                GeneralUtilities.ClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form.TrainObjectMenu.RemoveTrainInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.YesButtonInfo, Tracklinerepo.Trackline_Form.TracklineGeneratedForms.Confirm_Remove_From_Tracking.SelfInfo);
            }
            
            //Place Train at Track section via update tracking
            NS_UpdateTrackingMiddleClickTrackline_Trainsheet(trainSeed, trackSection, direction, "OnTrack", true, "");
            return;
        }
        
        
        
        public static bool NS_CheckIfTrainOnTrackSection(string trainSeed, string trackSection)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
        	if (trainId == null)
        	{
        		Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
        		return false;
        	}

        	Tracklinerepo.TrainId = trainId;

        	if (!Tracklinerepo.Trackline_Form_By_Train_Id.SelfInfo.Exists(0))
        	{
        		Ranorex.Report.Failure("Train {"+trainId+"} could not be found on any trackline.");
        		return false;
        	}

        	VMEnvironment vm = VMEnvironment.Instance();
        	Oracle.Code_Utils.TDMSActions TDMSDb = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);

        	string TrackLabelId = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObject.GetAttributeValue<string>("Id");
        	string trackSectionId = TDMSDb.GetSectionIdfromAssociatedTrackLabel(TrackLabelId);
        	if (trackSectionId != trackSection)
        	{
        	    return false;
        	}
        	return true;
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


        /// <summary>
        /// Validate the Train Delay in Trainsheet Delay tab
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="State">State of the delay</param>
        /// <param name="Source">Source from where Delay is added</param>
        /// <param name="FromLocation">From MP or Opsta Location</param>
        /// <param name="FromTime">From Time</param>
        /// <param name="ToLocation">To MP or Opsta location</param>
        /// <param name="ToTime">To Time</param>
        /// <param name="RunTime">Actual runtime of the delay</param>
        /// <param name="Code">Delay Code\Reason</param>
        /// <param name="Description">Description of Delay Code</param>
        /// <param name="Duration">Duration</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainDelay(string trainSeed, string optionalState, string optionalSource, string optionalFromLocation, string optionalFromTime, string optionalToLocation, string optionalToTime, string optionalRunTime, string optionalCode, string optionalDescription, string optionalDuration, bool isEnabled, bool closeForms)
        {
            int delayRowCount = 0;
            bool delayFound = false;
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            
            Trainsrepo.Train_Sheet.Delay.RefreshButton.DoubleClick();

            delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            Ranorex.Report.Info("No of rows found in Dealy tab is:- " +delayRowCount);
            //Report.Screenshot(Trainsrepo.Train_Sheet.Self);
            
            for (int i = 0; i < delayRowCount; i++)
            {

                //Get how many row to iterate through from the Delay Table
                Trainsrepo.DelayIndex = i.ToString();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCell.Click();
                string stateValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text");
                string sourceValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text");
                string fromLocationValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text");
                string fromTimeValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromTime.FromTimeText.GetAttributeValue<string>("Text");
                string toLocationValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.GetAttributeValue<string>("Text");
                string toTimeValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToTime.ToTimeText.GetAttributeValue<string>("Text");
                string runTimeValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.RunTime.GetAttributeValue<string>("Text");
                string codeValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text");
                string descriptionValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Description.GetAttributeValue<string>("Text");
                string durationValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text");
                delayFound = true;


                //Pulling the text from the Delay Entry
                //If one of the optional values don't match, this may be referring to a different delay entry so it will continue to search the table
                if (optionalState !=  "")
                {
                    if (!stateValue.Contains(optionalState)) {
                		Report.Info("State = "+stateValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected State value as {" +optionalState+"} and found as {" +stateValue+"}.");
                	}
                }

                if (optionalSource !=  "")
                {
                    if (!sourceValue.Contains(optionalSource)) {
                		Report.Info("Source = "+sourceValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected Source value code as {" +optionalSource+"} and found as {" +sourceValue+"}.");
                	}
                }

                if (optionalFromLocation !=  "")
                {
                    if (!fromLocationValue.Contains(optionalFromLocation)) {
                		Report.Info("From Location = "+fromLocationValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected From Location as {" +optionalFromLocation+"} and found as {" +fromLocationValue+"}.");
                	}
                }

                if (optionalFromTime !=  "")
                {
                    if (!fromTimeValue.Contains(optionalFromTime)) {
                		Report.Info("From Time = "+fromTimeValue);
                        delayFound = false;
                        continue;
                    }
                }

                if (optionalToLocation !=  "")
                {
                    if (!toLocationValue.Contains(optionalToLocation)) {
                		Report.Info("To Location = "+toLocationValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected To Location as {" +optionalToLocation+"} and found as {" +toLocationValue+"}.");
                	}
                }

                if (optionalToTime !=  "")
                {
                    if (!toTimeValue.Contains(optionalToTime)) {
                		Report.Info("To Time = "+toTimeValue);
                        delayFound = false;
                        continue;
                    }
                }

                if (optionalRunTime !=  "")
                {
                    if (!runTimeValue.Contains(optionalRunTime)) {
                		Report.Info("RunTime = "+runTimeValue);
                        delayFound = false;
                        continue;
                    }
                }

                if (optionalCode !=  "")
                {
                    if (!codeValue.Contains(optionalCode)) {
                		Report.Info("Code = "+codeValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected Delay code as {" +optionalCode+"} and found as {" +codeValue+"}.");
                	}
                }

                if (optionalDescription !=  "")
                {
                    if (!descriptionValue.Contains(optionalDescription)) {
                		Report.Info("Description = "+descriptionValue);
                        delayFound = false;
                        continue;
                    }
                }

                if (optionalDuration !=  "")
                {
                    if (!durationValue.Contains(optionalDuration)) {
                		Report.Info("Duration = "+durationValue);
                        delayFound = false;
                        continue;
                    }
                	else
                	{
                		Report.Success("Success","Expected Duration as {" +optionalDuration+"} and found as {" +durationValue+"}.");
                	}
                }
                
                if(isEnabled && delayFound)
                {
                    Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.Click();
                    if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeList.SelfInfo.Exists(0))
                    {
                        Report.Success("Success","Delay row is Enabled for row:"+Trainsrepo.DelayIndex.ToString());
                    }
                    else
                    {
                        Report.Failure("Failure","Delay row is not Enabled");
                    }
                }
                
                if(!isEnabled && delayFound)
                {
                    Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.Click();
                    if(!Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeList.SelfInfo.Exists(0))
                    {
                        Report.Success("Success","Delay row is Disabled");
                    }
                    else
                    {
                        Report.Failure("Failure","Delay row is Enabled");
                    }
                }
                break;
            }
            if(delayFound)
            {
                Ranorex.Report.Success("Train Delay found in Train Delay table for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
            } else {
                Ranorex.Report.Failure("Train Delay Split/Copy not found in Train Delay table for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        [UserCodeMethod]
        public static void NS_ValidateEOTCabooseRecord_TrainSheet(string trainSeed, string engineInitial, string engineNumber, bool validateDoesExist = true)
        {
            NS_OpenTrainsheetEOTCaboose_MainMenu(trainSeed);

            bool wasRecordFound = false;
            string engineRecord = engineInitial + " " + engineNumber;
            string cellContents;

            int rowCount = Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.Self.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                Trainsrepo.EOTCabooseIndex = i.ToString();
                cellContents = getCellContents(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber);
                if (cellContents.Equals(engineRecord))
                {
                    wasRecordFound = true;
                    break;
                }
            }

            string foundFeedback = "Caboose record found with corresponding initial/number: " + engineRecord;
            string notFoundFeedback = "No caboose record found with corresponding initial/number: " + engineRecord;
            reportValidationOutcome(validateDoesExist, wasRecordFound, foundFeedback, notFoundFeedback);
            Ranorex.Report.Screenshot();
        }

        /// <summary>
        /// This is a wrapper method for NS_ValidateCurrentConsistRecord_TrainSheet.
        /// It utilizes the components of a consist object to validate the current consist, rather than its component parts.
        /// </summary>
        /// <param name="trainSeed">Input: trainSeed</param>
        /// <param name="consistSeed">Input: consistSeed</param>
        /// <param name="closeTrainSheet">Input: Boolean for whether or not to close the train sheet following the validation. </param>
        /// <param name="validateDoesExist">Input: Validate whether this record exists (true), or doesn't exist (false). </param>
        [UserCodeMethod]
        public static void NS_ValidateCurrentConsist_ConsistObject_Trainsheet(string trainSeed, string consistSeed, bool closeTrainSheet, bool validateDoesExist = true)
        {
            NS_ConsistObject trainConsist = NS_TrainID.GetConsistObjectFromTrain(trainSeed, consistSeed);

            string numberOfLoads = trainConsist.NumberLoads;
            string numberOfEmpties = trainConsist.NumberEmpties;
            string opsta = trainConsist.ReportingLocation;
            string tons = trainConsist.TrailingTonnage;
            string feet = trainConsist.TrainLength;
            string plateSize = trainConsist.MaxPlateSize;

            NS_ValidateCurrentConsistRecord_TrainSheet(trainSeed, numberOfLoads, numberOfEmpties, opsta, "", tons, feet, plateSize, closeTrainSheet, validateDoesExist);
        }

        [UserCodeMethod]
        public static void NS_ValidateCurrentConsistRecord_TrainSheet(string trainSeed, string numberOfLoads, string numberOfEmpties, string opSta, string name, string tons, string feet, string plateSize, bool closeTrainSheet, bool validateDoesExist = true)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);


            bool wasRecordFound = true;

            int retries = 0;
            while (Trainsrepo.Train_Sheet.CurrentConsistSummary.Loads.TextValue == "" && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            string numLoadsContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.Loads.TextValue;
            string numEmptiesContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.Empties.TextValue;
            string opStaContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.OpSta.TextValue;
            string nameContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.Name.TextValue;
            string tonsContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.Tons.TextValue;
            string feetContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.Feet.TextValue;
            string plateSizeContents = Trainsrepo.Train_Sheet.CurrentConsistSummary.PlateSize.TextValue;

            if (!numLoadsContents.Equals(numberOfLoads))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Number of Loads to be {"+numberOfLoads+"} but was found to be {"+numLoadsContents+"}");
                }
            }

            if (!numEmptiesContents.Equals(numberOfEmpties))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Number of Empties to be {"+numberOfEmpties+"} but was found to be {"+numEmptiesContents+"}");
                }
            }

            if (!opStaContents.Equals(opSta))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Opsta to be {"+opSta+"} but was found to be {"+opStaContents+"}");
                }
            }

            if (!nameContents.Equals(name) && name != "")
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Name to be {"+name+"} but was found to be {"+nameContents+"}");
                }
            }

            if (!tonsContents.Equals(tons))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Number of Tons to be {"+tons+"} but was found to be {"+tonsContents+"}");
                }
            }

            if (!feetContents.Equals(feet))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Number of Feet to be {"+feet+"} but was found to be {"+feetContents+"}");
                }
            }

            if (!plateSizeContents.Equals(plateSize))
            {
                wasRecordFound = false;
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("Expected Max Plate Size to be {"+plateSize+"} but was found to be {"+plateSizeContents+"}");
                }
            }

            if (validateDoesExist && wasRecordFound)
            {
                Ranorex.Report.Success("Consist found with Loads: {"+numberOfLoads+"}, Empties: {"+numberOfEmpties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Feet: {"+feet+"}, and Plate Size: {"+plateSize+"}");
            } else if (!validateDoesExist && !wasRecordFound)
            {
                Ranorex.Report.Success("Consist NOT found with Loads: {"+numberOfLoads+"}, Empties: {"+numberOfEmpties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Feet: {"+feet+"}, and Plate Size: {"+plateSize+"}");
            } else if (!validateDoesExist && wasRecordFound)
            {
                Ranorex.Report.Failure("Consist found with Loads: {"+numberOfLoads+"}, Empties: {"+numberOfEmpties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Feet: {"+feet+"}, and Plate Size: {"+plateSize+"}");
            }

            if (closeTrainSheet)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
            return;
        }
        
        //If engineSeed not given then will rely on the variables given to Validate engine, if engineSeed given and value exist in extra variables, then will validate those instead of the one present in the engineSeed
        [UserCodeMethod]
        public static void NS_ValidateEngineRecord_TrainSheet(
            string trainSeed,
            string engineSeed,
            string position,
            string engineLock,
            string consist,
            string engine,
            string engineId,
            string engineGroup,
            string model,
            string compensatedHP,
            string originLocation,
            string originPassCount,
            string destinationLocation,
            string destinationPassCount,
            string trainControl,
            string dpu,
            string notes,
            bool closeTrainsheet,
            bool validateDoesExist = true
           )
        {
            NS_OpenTrainsheetEngine_MainMenu(trainSeed);

            NS_EngineConsistObject engineObject = NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed);
            if (engineObject == null)
            {
                engineObject = NS_TrainID.CreateEngineConsistRecord(trainSeed, "FakeEngineRecord", "|||||||||||||||||||0|||0||0|", "", "", "", "", "", "", "");
            }
            else
            {
            	Report.Info("Using Object to validate.");
            	NS_TrainID.ReportEngineObjectStatus(trainSeed, engineSeed);
            }

            //Give a chance for engine records to populate
            int retries = 0;
            while ((Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count == 0 || Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count == 1) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            int numberOfEngineRows = Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count;
            if ((numberOfEngineRows == 0 || numberOfEngineRows == 1))
            {
                if (validateDoesExist)
                {
                    Ranorex.Report.Failure("There were no engines found to Validate against");
                } else {
                    Ranorex.Report.Success("No engines found");
                }
                return;
            }

            if (engineId != "")
            {
                Trainsrepo.EngineId = engineId;
            } else {
                Trainsrepo.EngineId = engineObject.EngineInitial +" "+engineObject.EngineNumber;
            }

            //If there are no rows with the trainID, end early
            if (!Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByEngineID.EngineIDInfo.Exists(0))
            {
                if(!validateDoesExist)
                {
                    Ranorex.Report.Success("No Engine Rows with Engine Id of {"+Trainsrepo.EngineId+"}.");
                } else {
                    Ranorex.Report.Failure("No Engine Rows with Engine Id of {"+Trainsrepo.EngineId+"}.");
                }
                return;
            }

            //start at 1 as the 0 index is for inserting an engine
            for (int i = 1; i < numberOfEngineRows; i++)
            {
                Trainsrepo.EngineIndex = i.ToString();

                Report.Screenshot(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Self.Element);
                string foundEngineId = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.EngineID.Text;
                if (engineId != "")
                {
                    if (foundEngineId != engineId)
                    {
                        Ranorex.Report.Info("Found Engine Id of {"+foundEngineId+"} in row {"+i.ToString()+"} did not match inputted Engine Id of {"+engineId+"}.");
                        continue;
                    }
                } else {
                    if (foundEngineId != (engineObject.EngineInitial +" "+engineObject.EngineNumber))
                    {
                        Ranorex.Report.Info("Found Engine Id of {"+foundEngineId+"} in row {"+i.ToString()+"} did not match engineObject Engine Id of {"+engineObject.EngineInitial +" "+engineObject.EngineNumber+"}.");
                        continue;
                    }
                }

                string foundEnginePos = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Position.Text;
                if (position != "")
                {
                    if (foundEnginePos != position)
                    {
                        Ranorex.Report.Info("Found Engine Pos of {"+foundEnginePos+"} in row {"+i.ToString()+"} did not match inputted Engine Pos of {"+position+"}.");
                        continue;
                    }
                } else {
                    if (foundEnginePos != engineObject.EnginePosition)
                    {
                        Ranorex.Report.Info("Found Engine Pos of {"+foundEnginePos+"} in row {"+i.ToString()+"} did not match engineObject Engine Pos of {"+engineObject.EnginePosition+"}.");
                        continue;
                    }
                }

                string foundEngineLock = (Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.LockStatus.Text);
                if (engineLock != "")
                {
                    if (foundEngineLock != engineLock)
                    {
                        Ranorex.Report.Info("Found Engine Lock of {"+foundEngineLock+"} in row {"+i.ToString()+"} did not match inputted Engine Lock of {"+engineLock+"}.");
                        continue;
                    }
                } else {
                    if (foundEngineLock != engineObject.EngineLock)
                    {
                        Ranorex.Report.Info("Found Engine Lock of {"+foundEngineLock+"} in row {"+i.ToString()+"} did not match engineObject Engine Lock of {"+engineObject.EngineLock+"}.");
                        continue;
                    }
                }

                string foundConsist = (Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Consist.Text);
                if (consist != "")
                {
                    if (foundConsist != consist)
                    {
                        Ranorex.Report.Info("Found Consist of {"+foundConsist+"} in row {"+i.ToString()+"} did not match inputted Consist of {"+consist+"}.");
                        continue;
                    }
                }

                string foundEngineStatus = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.Text;
                if (engine != "")
                {
                    if (foundEngineStatus != engine)
                    {
                        Ranorex.Report.Info("Found Engine Status of {"+foundEngineStatus+"} in row {"+i.ToString()+"} did not match inputted Engine Status of {"+engine+"}.");
                        continue;
                    }
                } else {
                    if (foundEngineStatus != engineObject.EngineStatus)
                    {
                        Ranorex.Report.Info("Found Engine Status of {"+foundEngineStatus+"} in row {"+i.ToString()+"} did not match engineObject Engine Status of {"+engineObject.EngineStatus+"}.");
                        continue;
                    }
                }

                string foundEngineGroup = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.Text;
                if (engineGroup != "")
                {
                    if (foundEngineGroup != engineGroup)
                    {
                        Ranorex.Report.Info("Found Engine Group of {"+foundEngineGroup+"} in row {"+i.ToString()+"} did not match inputted Engine Group of {"+engineGroup+"}.");
                        continue;
                    }
                } else {
                    if (foundEngineGroup != engineObject.GroupNumber)
                    {
                        Ranorex.Report.Info("Found Engine Group of {"+foundEngineGroup+"} in row {"+i.ToString()+"} did not match engineObject Engine Group of {"+engineObject.GroupNumber+"}.");
                        continue;
                    }
                }

                string foundEngineModel = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Model.Text;
                if (foundEngineModel == " ")
                {
                    foundEngineModel = "";
                }
                if (model != "")
                {
                    if (foundEngineModel != model)
                    {
                        Ranorex.Report.Info("Found Engine Model of {"+foundEngineModel+"} in row {"+i.ToString()+"} did not match inputted Engine Model of {"+model+"}.");
                        continue;
                    }
                } else {
                    if (foundEngineModel != engineObject.Model)
                    {
                        Ranorex.Report.Info("Found Engine Model of {"+foundEngineModel+"} in row {"+i.ToString()+"} did not match engineObject Engine Model of {"+engineObject.Model+"}.");
                        continue;
                    }
                }

                string foundcompensatedHP = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.CompensatedHP.Text;
                if (compensatedHP != "")
                {
                    if (foundcompensatedHP != compensatedHP)
                    {
                        Ranorex.Report.Info("Found Compensated HP of {"+foundcompensatedHP+"} in row {"+i.ToString()+"} did not match inputted Compensated HP of {"+compensatedHP+"}.");
                        continue;
                    }
                } else {
                    if (foundcompensatedHP != engineObject.CompensatedHP)
                    {
                        Ranorex.Report.Info("Found Compensated HP of {"+foundcompensatedHP+"} in row {"+i.ToString()+"} did not match engineObject Compensated HP of {"+engineObject.CompensatedHP+"}.");
                        continue;
                    }
                }

                string foundOriginLocation = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.GetAttributeValue<string>("StationId");
                if (originLocation != "")
                {
                    if (foundOriginLocation != originLocation)
                    {
                        Ranorex.Report.Info("Found Origin Location of {"+foundOriginLocation+"} in row {"+i.ToString()+"} did not match inputted Origin Location of {"+originLocation+"}.");
                        continue;
                    }
                } else {
                    if (foundOriginLocation != engineObject.OriginLocation)
                    {
                        Ranorex.Report.Info("Found Origin Location of {"+foundOriginLocation+"} in row {"+i.ToString()+"} did not match engineObject Origin Location of {"+engineObject.OriginLocation+"}.");
                        continue;
                    }
                }

                string foundOriginPassCount = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginPassCount.Text;
                if (originPassCount != "")
                {
                    if (foundOriginPassCount != originPassCount)
                    {
                        Ranorex.Report.Info("Found Origin Pass Count of {"+foundOriginPassCount+"} in row {"+i.ToString()+"} did not match inputted Origin Pass Count of {"+originPassCount+"}.");
                        continue;
                    }
                } else {
                    if (foundOriginPassCount != engineObject.OriginPassCount)
                    {
                        Ranorex.Report.Info("Found Origin Pass Count of {"+foundOriginPassCount+"} in row {"+i.ToString()+"} did not match engineObject Origin Pass Count of {"+engineObject.OriginPassCount+"}.");
                        continue;
                    }
                }



                //If it's gotten to this point, we need to verify the details on the other table, so select the row
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click();

                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click();
                //I really hate this delay, if you can think of a better way to ensure the details panel corresponds with the correct row instead of waiting and hoping, please replace this
                Ranorex.Delay.Milliseconds(500);

                string foundDestinationLocation = Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.GetAttributeValue<string>("StationId");
                if (destinationLocation != "")
                {
                    if (foundDestinationLocation != destinationLocation)
                    {
                        Ranorex.Report.Info("Found Destination Location of {"+foundDestinationLocation+"} in row {"+i.ToString()+"} did not match inputted Destination Location of {"+destinationLocation+"}.");
                        continue;
                    }
                } else {
                    if (foundDestinationLocation != engineObject.DestinationLocation)
                    {
                        Ranorex.Report.Info("Found Destination Location of {"+foundDestinationLocation+"} in row {"+i.ToString()+"} did not match engineObject Destination Location of {"+engineObject.DestinationLocation+"}.");
                        continue;
                    }
                }

                string foundDestinationPassCount = Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationPassCount.Text;
                if (destinationPassCount != "")
                {
                    if (foundDestinationPassCount != destinationPassCount)
                    {
                        Ranorex.Report.Info("Found Destination Pass Count of {"+foundDestinationPassCount+"} in row {"+i.ToString()+"} did not match inputted Destination Pass Count of {"+destinationPassCount+"}.");
                        continue;
                    }
                } else {
                    if (foundDestinationPassCount != engineObject.DestinationPassCount)
                    {
                        Ranorex.Report.Info("Found Destination Pass Count of {"+foundDestinationPassCount+"} in row {"+i.ToString()+"} did not match engineObject Destination Pass Count of {"+engineObject.DestinationPassCount+"}.");
                        continue;
                    }
                }

                bool failed = false;
                string foundTrainControls = Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.TrainControl.Text;
                if (trainControl != "")
                {
                    string[] trainControls = trainControl.Split('|');
                    foreach (string splitTrainControl in trainControls)
                    {
                        if (!foundTrainControls.Contains(splitTrainControl))
                        {
                            Ranorex.Report.Info("Found Train Controls of {"+foundTrainControls+"} in row {"+i.ToString()+"} did not match contain Train Control of {"+splitTrainControl+"}.");
                            failed = true;
                        }
                    }
                    if (failed)
                    {
                        continue;
                    }
                } else {
                    List<string> trainControls = new List<string>();
                    if (engineObject.PTC_Equipped == "Y")
                    {
                        trainControls.Add("PTC");
                    }
                    if (engineObject.CS_Equipped == "Y")
                    {
                        trainControls.Add("CS");
                    }
                    if (engineObject.PTS_Equipped == "Y")
                    {
                        trainControls.Add("PTS");
                    }
                    if (engineObject.LSL_Equipped == "Y")
                    {
                        trainControls.Add("LSL");
                    }

                    foreach (string splitTrainControl in trainControls)
                    {
                        if (!foundTrainControls.Contains(splitTrainControl))
                        {
                            Ranorex.Report.Info("Found Train Controls of {"+foundTrainControls+"} in row {"+i.ToString()+"} did not match contain EngineObject Train Control of {"+splitTrainControl+"}.");
                            failed = true;
                        }
                    }
                    if (trainControls.Count == 0)
                    {
                    	if (foundTrainControls != "")
                    	{
                    		Ranorex.Report.Failure("Expected Train control to be empty. Train Control = "+foundTrainControls+".");
                    		failed=true;
                    	}
                    }
                    	
                    if (failed)
                    {
                        continue;
                    }
                }

                string foundDPU = (Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DPUCheckbox.Selected?"Y":"N");
                if (dpu != "")
                {
                    if (foundDPU != dpu)
                    {
                        Ranorex.Report.Info("Found DPU of {"+foundDPU+"} in row {"+i.ToString()+"} did not match inputted DPU of {"+dpu+"}.");
                        continue;
                    }
                } else {
                    if (foundDPU != engineObject.DPU_Status)
                    {
                        Ranorex.Report.Info("Found DPU of {"+foundDPU+"} in row {"+i.ToString()+"} did not match engineObject DPU of {"+engineObject.DPU_Status+"}.");
                        continue;
                    }
                }

                string foundNotes = Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.Note.Text;
                if (foundNotes == " ")
                {
                    foundNotes = "";
                }
                if (notes != "")
                {
                    if (foundNotes != notes)
                    {
                        Ranorex.Report.Info("Found Notes of {"+foundNotes+"} in row {"+i.ToString()+"} did not match inputted Notes of {"+notes+"}.");
                        continue;
                    }
                } else {
                    if (foundNotes != engineObject.Notes)
                    {
                        Ranorex.Report.Info("Found Notes of {"+foundNotes+"} in row {"+i.ToString()+"} did not match engineObject Notes of {"+engineObject.Notes+"}.");
                        continue;
                    }
                }



                if (validateDoesExist)
                {
                    Ranorex.Report.Success("Found Specified Engine");
                } else {
                    Ranorex.Report.Failure("Found Specified Engine");
                }

                if (closeTrainsheet)
                {
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                }
                return;
            }

            if (validateDoesExist)
            {
                Ranorex.Report.Failure("Could not find Specified Engine");
            } else {
                Ranorex.Report.Success("Could not find Specified Engine");
            }

            if (closeTrainsheet)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
            return;
        }

        [UserCodeMethod]
        public static void NS_ValidateEngineLock_TrainSheet(string trainSeed, string engineSeed, bool isLocked)
        {
            // TO THE REVIEWER: This is not finished. It's a work in progress.
            // I'm checking it in as-is in order to baseline the bulletinSeed.

            string engineNumber = NS_TrainID.GetEngineNumber(trainSeed, engineSeed);
            string engineInitial = NS_TrainID.GetEngineInitial(trainSeed, engineSeed);

            Ranorex.Report.Info("TestStep", String.Format("Validating the Position In Consist lock for engine '{0} {1}' is ", engineInitial, engineNumber) + (isLocked? "Locked" : "Unlocked"));

            NS_OpenTrainsheetEngine_MainMenu(trainSeed);
        }

        [UserCodeMethod]
        public static void NS_ValidateConsistSummaryRecordWithObj_TrainSheet(string trainSeed, string consistSeed, string nameOfOpsta, bool closeTrainSheet, bool validateDoesExist, int iteration = 0)
        {
        	NS_ConsistObject consistObj = NS_TrainID.GetConsistObjectFromTrain(trainSeed, consistSeed);
        	NS_ValidateConsistSummaryRecord_TrainSheet(trainSeed, consistObj.ReportingLocation, nameOfOpsta, consistObj.TrailingTonnage, consistObj.TrainLength, consistObj.NumberLoads, consistObj.NumberEmpties, consistObj.ReportingPassCount, closeTrainSheet, validateDoesExist, iteration);
        }
        
        [UserCodeMethod]
        public static void NS_ValidateConsistSummaryRecord_TrainSheet(string trainSeed, string opSta, string name, string tons, string length, string loads, string empties, string passCount, bool closeTrainSheet, bool validateDoesExist = true, int iteration = 0)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Consist Summary Tab on Train Tab.");
                    return;
                }
            }

            bool wasRecordFound = false;

            int rowCount = Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.Self.Rows.Count;
            retries = 0;
            while (rowCount == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                rowCount = Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.Self.Rows.Count;
                retries++;
            }
            for (int i = 0; i < rowCount; i++)
            {
                Trainsrepo.ConsistSummaryIndex=i.ToString();
                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.GetAttributeValue<string>("StationId") != opSta)
                {
                    continue;
                }

                if (name != "")
                {
                	 //seems like pds will autocapitalize opsta name in the records
                	 if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.GetAttributeValue<string>("StationName") != name.ToUpper())
                    {
                        continue;
                    }
                }

                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Tons.GetAttributeValue<string>("Text") != tons)
                {
                    continue;
                }

                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Length.GetAttributeValue<string>("Text") != length)
                {
                    continue;
                }

                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Loads.GetAttributeValue<string>("Text") != loads)
                {
                    continue;
                }

                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Empties.GetAttributeValue<string>("Text") != empties)
                {
                    continue;
                }

                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.PassCount.GetAttributeValue<string>("Text") != passCount)
                {
                    continue;
                }

                wasRecordFound = true;
                break;
            }
            
            //retry in case of MIS message
            if (!wasRecordFound && iteration < 2)
            {
                Ranorex.Delay.Seconds(1);
                Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                NS_ValidateConsistSummaryRecord_TrainSheet(trainSeed, opSta, name, tons, length, loads, empties, passCount, closeTrainSheet, validateDoesExist, iteration + 1);
                return;
            }

            if (wasRecordFound && validateDoesExist)
            {
                Ranorex.Report.Success("Found Train Consist Summary Record of Loads: {"+loads+"}, Empties: {"+empties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Length: {"+length+"}, and Pass Count: {"+passCount+"}");
            } else if (!wasRecordFound && validateDoesExist)
            {
            	Ranorex.Report.Failure("Train Consist Summary Record Not Found for Loads: {"+loads+"}, Empties: {"+empties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Length: {"+length+"}, and Pass Count: {"+passCount+"}");
            
            } else if (!wasRecordFound && !validateDoesExist)
            {
                Ranorex.Report.Success("Train Consist Summary Record Not Found for Loads: {"+loads+"}, Empties: {"+empties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Length: {"+length+"}, and Pass Count: {"+passCount+"}");
            } else if (wasRecordFound && !validateDoesExist)
            {
                Ranorex.Report.Failure("Found Train Consist Summary Record of Loads: {"+loads+"}, Empties: {"+empties+"}, Opsta: {"+opSta+"}, "+((name != "")?"Name: {"+name+"}, ":"") +"Tons: {"+tons+"}, Length: {"+length+"}, and Pass Count: {"+passCount+"}");
            }

            if (closeTrainSheet)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
            return;
        }

        [UserCodeMethod]
        public static void NS_ValidateCrewStatusByLastName_TrainSheet(string trainSeed, string crewLastName, string expectedStatus)
        {
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);
            string trainId = NS_TrainID.GetTrainId(trainSeed);

            Trainsrepo.CrewLastName = crewLastName;
            string cellContents = getCellContents(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByCrewLastName.Status);

            if (cellContents.Equals(expectedStatus))
            {
                Report.Success(String.Format("Crew member '{0}' on train '{1}' has status: '{2}'", crewLastName, trainId, cellContents));
            } else {
                Report.Failure(String.Format("Crew member '{0}' on train '{1}' has status '{2}', but status '{3}' expected.", crewLastName, trainId, cellContents, expectedStatus));
            }

            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.CrewTable.Self);
        }

        [UserCodeMethod]
        public static void NS_UpdateActivityStatus_TrainSheet(string trainSeed, string activityState, string activityType, string opsta, string moveTrain = "yes", bool pressApply = true, bool closeForm=true, string expectedFeedback = "")
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            moveTrain = moveTrain.ToLower();
            // TODO: If there is an activity at the same location with the same activity type, possibly crews) we will have to update this code, but for now, there is no such case in automation
            int rowIteration = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            bool found = false;
            for (int i = 0; i < rowIteration; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                
                if(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LocationInfo.Exists(0))
                {
                    continue;
                }
                
                string foundOpsta = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.Element.GetAttributeValueText("StationId");
                
                if (string.IsNullOrEmpty(foundOpsta))
                {
                    continue;
                }
                
                if (opsta != "")
                {
                    if (!opsta.Equals(foundOpsta))
                    {
                        continue;
                    }
                }
                
                string foundActivityType = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.Text;
                if (activityType != "")
                {
                    if(!foundActivityType.Equals(activityType))
                    {
                        continue;
                    }
                }
                
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
                if (Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusText.Text.Equals(activityState))
                {
                    Ranorex.Report.Error("Activity {"+foundActivityType+"} at opsta {"+foundOpsta+"} already has status {"+activityState+"}.");
                    break;
                }
                
                found = true;
                
                Trainsrepo.StatusName = activityState;
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusList.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusList.StatusListItemByStatusNameInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusList.SelfInfo);
                
                int retries = 0;
                while (!Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                
                if (Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo.Exists(0))
                {
                    if (moveTrain == "yes")
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.YesButtonInfo, Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo);
                        Ranorex.Report.Info("Moving train to Activity {"+foundActivityType+"} at opsta {"+foundOpsta+"}");
                    } else if (moveTrain == "no") {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.NoButtonInfo, Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo);
                        Ranorex.Report.Info("Not moving train to Activity {"+foundActivityType+"} at opsta {"+foundOpsta+"}");
                    } else {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.CancelButtonInfo, Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Move_Train.SelfInfo);
                        Ranorex.Report.Info("Cancelling moving train to Activity {"+foundActivityType+"} at opsta {"+foundOpsta+"}");
                    }
                    
                    if (Trainsrepo.Train_Sheet.Feedback.TextValue.Trim() != "")
                    {
                        ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                        break;
                    }
                }
                
                if (pressApply)
                {
                    Trainsrepo.Train_Sheet.TripPlan.ApplyButton.Click();
                    if (Trainsrepo.Train_Sheet.Feedback.TextValue.Trim() != "")
                    {
                        ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                        break;
                    }
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo, Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
                }
                
            }
            if (!found)
            {
                Ranorex.Report.Error("Could not find activity with activity type of {"+activityType+"} and/or opsta {"+opsta+"}");
                Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self);
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }

        /// <summary>
        /// Validate the state of an activity as given by trip plan, given by activity type.
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="expectedActivityState">The expected activity state for the activity type (e.g. 'In-progress')</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. 'Change Crew')</param>
        [UserCodeMethod]
        public static void NS_ValidateActivityStatus_TrainSheet(string trainSeed, string expectedActivityState, string activityType)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            // Note that this method only works given one instance of the input activity type.
            Trainsrepo.TripPlanActivity = activityType;
            Trainsrepo.StatusName = expectedActivityState;

            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.SelectionCell.Click();

            string currentStatus = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusText.Text.ToString();
            Ranorex.Report.Info("current status: '" + currentStatus + "'");
            if (currentStatus.Equals(expectedActivityState))
            {
                Ranorex.Report.Success("OK for now.");
            }
            else
            {
            	Report.Failure("Current status: '" + currentStatus + "' does not match expected status '"+expectedActivityState+"'.");
            }
        }

        private static string getCellContents(Ranorex.Cell aRepoPath)
        {
            string cellContents = aRepoPath.GetAttributeValue<string>("text");
            return cellContents;
        }

        private static void reportValidationOutcome(bool validateDoesExist, bool wasRecordFound, string foundFeedback, string notFoundFeedback)
        {
            if (validateDoesExist)
            {
                if (wasRecordFound)
                {
                    Ranorex.Report.Success("Validation", foundFeedback);
                } else {
                    Ranorex.Report.Failure("Failure", notFoundFeedback);
                }
            } else {
                if (wasRecordFound)
                {
                    Ranorex.Report.Failure("Failure", foundFeedback);
                } else {
                    Ranorex.Report.Success("Validation", notFoundFeedback);
                }
            }
        }

        /// <summary>
        /// Adding Consist Constraint in the TrainSheet --> Train tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="type"> Type value e.g. Weight, Height, Width, Hazmat Train, Speed or TIH Indicator</param>
        /// <param name="value">value for the type of constraint to be added</param>
        /// <param name="fromOpsta">Opsta from where constraint should start</param>
        /// <param name="fromPassCount">Passcount of the from Opsta</param>
        /// <param name="toOpsta">Opsta till where constraint would be present</param>
        /// <param name="toPassCount">passcount of the to opsta</param>
        /// <param name="createQKS">If a quickstop needs to be created i.e. True or False</param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void addConsistConstraint(string trainSeed, string type, string value, string fromOpsta, string fromPassCount, string toOpsta, string toPassCount, bool createQKS, string expectedFeedback, bool closeForms)
        {
            //Open the trainsheet first and select the Trains tab
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);

            string train_id = NS_TrainID.GetTrainId(trainSeed);

            int retries = 0;

            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraintsInfo,
                                                      Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.SelfInfo);

            //Select the type from the dropdown
            if(type!= "")
            {

                type = type.ToLower();
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.Click();

                if(type == "weight")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.Weight.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else if (type == "height")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.Height.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else if (type == "width")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.Width.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else if (type == "hazmat train" || type == "hazmattrain")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.HazmatTrain.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else if (type == "speed")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.Speed.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else if (type == "tih" || type == "tih indicator")
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeList.TIHIndicator.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Type.TypeText.PressKeys("{TAB}");
                } else
                {
                    Report.Failure("Invalid Type Input" +type);
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please Enter valid value for Type dropdown");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Select or Enter the value and if incorrect value entered and feedback received then it will throw failure and return out of the method
            if(value!= "")
            {
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Value.Click();
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Value.PressKeys(value);
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.Value.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {

                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please provide valid value for Value field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the from Opsta value and throw error if invalid opsta entered
            if(fromOpsta!= "")
            {

                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.FromOpStaName.PressKeys(fromOpsta);
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.FromOpStaName.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please provide valid value for From Opsta field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the passcount value and throw error if invalid passcount provided
            if(fromPassCount!= "")
            {

                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.FromPassCount.PressKeys(fromPassCount);
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.FromPassCount.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {

                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please provide valid value for From Opsta PassCount field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the to Opsta and throw error if invalid Opsta entered
            if(toOpsta!= "")
            {

                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.ToOpStaName.PressKeys(toOpsta);
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.ToOpStaName.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {

                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please provide valid value for To Opsta field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the To PassCount and throw error if invalid value provided
            if(toPassCount!= "")
            {

                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.ToPassCount.PressKeys(toPassCount);
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.ToPassCount.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {

                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            } else
            {
                Report.Failure("Please provide valid value for To Opsta Passcount field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Select the checkbox for createQKS
            if(createQKS)
            {

                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.CreateQKSAtOpSta.Click();
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintInputTable.ConsistConstraintInputRow.ToPassCount.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Report.Failure("Feedback received which was not as expected");
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            }

            //Click on Apply button and retry until apply button is disabled
            retries = 0;
            int innerRetry = 0;
            string currentMouseState = "";
            try
            {
                while(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButton.Enabled && retries < 8)
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButton.Click();

                    currentMouseState = Mouse.Cursor.ToString();

                    while (currentMouseState == "[Cursor: WaitCursor]" && innerRetry < 5)
                    {
                        Thread.Sleep(500);
                        currentMouseState = Mouse.Cursor.ToString();
                        innerRetry++;
                    }
                    Ranorex.Delay.Milliseconds(1000);
                    retries++;
                }


                //TO DO
                //Removing the expectedFeedback once the issue is fixed
                //Expected feedback is added due to a PDS defect and we are making it to be .* for now
//				expectedFeedback = @".*";
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                    Ranorex.Report.Error("Feedback error received");
                }


                if(!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButton.Enabled)
                {
                    Report.Success("Successfully added Consist Constraint for Train: " +train_id);
                } else
                {
                    Report.Failure("Unable to add Consist Constraint for Train: " +train_id);
                }

            }

            catch (Exception ex)
            {
                Ranorex.Report.Info("Exception Thrown:"+ ex.ToString());
            }

            finally
            {


                if(closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
            }
        }

        /// <summary>
        /// Deleting the Consist Constraint in the TrainSheet --> Train tab, assuming there is only 1 record present for the combination of type, fromOpsta and toOpsta
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="type"> Type value e.g. Weight, Height, Width, Hazmat Train, Speed or TIH Indicator</param>
        /// <param name="fromOpsta">Opsta from where constraint should start</param>
        /// <param name="toOpsta">Opsta till where constraint would be present</param>
        /// <param name="refresh">True or False to refresh the forms</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void DeleteConsistConstraint_NS(string trainSeed, string type, string fromOpsta, string toOpsta, bool refresh, bool closeForms)
        {
            int rowCount = 0;
            string constraintType = "";
            string fromOpstaConstraintTable = "";
            string toOpstaConstraintTable = "";
            bool recordDeleted = false;

            //Open the trainsheet first and select the Trains tab
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);

            string train_id = NS_TrainID.GetTrainId(trainSeed);

            int retries = 0;

            while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.GetAttributeValue<bool>("Selected") && retries < 3)
            {
                //Select the Consist Constraints tab and validate if it is selected as it might take time to load in case of huge data
                Ranorex.Delay.Milliseconds(500);
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraintsInfo,
                                                          Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.SelfInfo);
                //Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Click();
                retries++;
            }

            if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.SelfInfo.Exists(0))
            {


                if(!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.SelfInfo.Exists(0))
                {
                    Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                    Ranorex.Report.Failure("There is no Consist Constraint present for the Train");

                } else
                {
                    rowCount = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self.Rows.Count;

                    for(int i=0; i<rowCount; i++)
                    {
                        Trainsrepo.ConsistConstraintIndex = i.ToString();

                        // Retrieve the type, fromOpsta and toOpsta value which will be used to compare it later.
                        constraintType = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.GetAttributeValue<string>("Text");
                        fromOpstaConstraintTable = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("_stationId");
                        toOpstaConstraintTable = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("_stationId");


                        if(constraintType.Equals(type) && fromOpstaConstraintTable.Equals(fromOpsta) && toOpstaConstraintTable.Equals(toOpsta)){
                            
                            //Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self);
                            Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);

                            Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right);
                            Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.DeleteRow.Click();

                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo);

                            
                            
                            
                            if (Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.SelfInfo.Exists(0))
                            {
                                //Determine if it was successfully deleted
                                constraintType = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.GetAttributeValue<string>("Text");
                                fromOpstaConstraintTable = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("_stationId");
                                toOpstaConstraintTable = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("_stationId");
                                if (!(constraintType.Equals(type) && fromOpstaConstraintTable.Equals(fromOpsta) && toOpstaConstraintTable.Equals(toOpsta))){
                                    recordDeleted = true;
                                }
                            } else {
                                recordDeleted = true;
                            }
                            
                            
                            break;

                        }
                    }
                }
                if(recordDeleted)
                {
                    Ranorex.Report.Success("Record Found and successfully deleted");
                }
                else
                {
                    Ranorex.Report.Failure("Record not found or not deleted");
                }
                if (refresh)
                {
                    Trainsrepo.Train_Sheet.Train.RefreshButton.Click();
                }
                if(closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
            }

        }

        /// <summary>
        /// Validating if a Train has TIH Indicator present
        /// </summary>
        /// <param name="trainSeed"></param>
        [UserCodeMethod]
        public static void validateTIHIndicator(string trainSeed)
        {

            string train_id = NS_TrainID.GetTrainId(trainSeed);
            int retry = 0;

            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            //Validate if the TIH Indicator icon is displayed in the TrainSheet Consist Constraints table
            while(!Trainsrepo.Train_Sheet.CurrentConsistSummary.TIH.Element.GetAttributeValueText("icon").Contains("tih_indicator.gif") && retry < 5)
            {
                Ranorex.Delay.Milliseconds(1000);
                retry++;
            }

            if(Trainsrepo.Train_Sheet.CurrentConsistSummary.TIH.Element.GetAttributeValueText("icon").Contains("tih_indicator.gif"))
            {
                Ranorex.Report.Success("TIH Indicator is present on Train: "+train_id);
            } else
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                Ranorex.Report.Failure("TIH Indicator is not present on Train: "+train_id);
            }

            Trainsrepo.Train_Sheet.Self.EnsureVisible();
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,
                                                              Trainsrepo.Train_Sheet.SelfInfo);
        }

        /// <summary>
        /// Add an Engine via the UI
        /// </summary>
        /// <param name="trainSeed"></param>
        [UserCodeMethod]
        public static void NS_ManuallyAddPipedEngine_Trainsheet(string trainSeed, string engineSeeds, string engines, string expectedFeedback, bool closeForms)
        {
            System.DateTime now = System.DateTime.Now;
        	bool finalCloseForms = false;
            string[] splitExpectedFeedback = expectedFeedback.Split('|');
            string iterativeExpectedFeedback = "";
            string[] splitEngineRecords = engines.Split('|');
            int splitLengthOfEngineRecord = splitEngineRecords.Length;
            int currentRecordSize = 26;
            
            if (splitLengthOfEngineRecord%currentRecordSize != 0)
            {
                Ranorex.Report.Error("Engine Record is not divisible by " + currentRecordSize + ", total size of record is {" + splitLengthOfEngineRecord + "}");
                return;
            }
            
            string[] splitEngineSeeds = engineSeeds.Split('|');
            string engineSeed = "";
            int numberOfEngineRecords = splitLengthOfEngineRecord/currentRecordSize;
            
            for (int i = 0; i < numberOfEngineRecords; i++)
            {
                if (expectedFeedback != "")
                {
                    iterativeExpectedFeedback = splitExpectedFeedback[i];
                }
                string engineInitial = splitEngineRecords[i*currentRecordSize];
                string engineNumber = splitEngineRecords[i*currentRecordSize+1];
                string pos = splitEngineRecords[i*currentRecordSize+2];
                bool lockEngine = (splitEngineRecords[i*currentRecordSize+4] == "Y");
                string originPassCount = splitEngineRecords[i*currentRecordSize+5];
                string originLocation = splitEngineRecords[i*currentRecordSize+6];
                string destinationPassCount = splitEngineRecords[i*currentRecordSize+7];
                string destinationLocation = splitEngineRecords[i*currentRecordSize+8];
                string compensatedHP = splitEngineRecords[i*currentRecordSize+9];
                string engineGroup = splitEngineRecords[i*currentRecordSize+10];
                string model = splitEngineRecords[i*currentRecordSize+11];
                string engineStatus = splitEngineRecords[i*currentRecordSize+12];
                bool dpu = (splitEngineRecords[i*currentRecordSize+13] == "Y");
                bool pts = (splitEngineRecords[i*currentRecordSize+14] == "Y");
                bool ptc = (splitEngineRecords[i*currentRecordSize+15] == "Y");
                bool lsl = (splitEngineRecords[i*currentRecordSize+16] == "Y");
                bool cs = (splitEngineRecords[i*currentRecordSize+17] == "Y");
                string notes = splitEngineRecords[i*currentRecordSize+18];
    
                if (closeForms && (i + 1 == numberOfEngineRecords))
                {
                    finalCloseForms = true;
                }
                
                if (i+1 > splitEngineSeeds.Length)
                {
                    engineSeed = "";
                } else {
                    engineSeed = splitEngineSeeds[i];
                }
    
                NS_ManuallyAddEngine_Trainsheet(trainSeed, engineSeed, pos, lockEngine, engineStatus, engineInitial, engineNumber, engineGroup, model, compensatedHP, originLocation, originPassCount, destinationLocation, destinationPassCount, ptc, lsl, pts, cs, dpu, notes, iterativeExpectedFeedback, finalCloseForms, "0");
            }
        }

        /// <summary>
        /// Add an Engine via the UI
        /// </summary>
        /// <param name="trainSeed"></param>
        [UserCodeMethod]
        public static void NS_ManuallyAddEngine_Trainsheet(string trainSeed, string engineSeed, string pos, bool lockEngine, string engineStatus, string engineInitial, string engineNumber, string engineGroup, string model, string compensatedHP, string originLocation, string originPassCount, string destinationLocation, string destinationPassCount, bool ptc, bool lsl, bool pts, bool cs, bool dpu, string notes, string expectedFeedback, bool closeForms, string engineIndex)
        {
            NS_OpenTrainsheetEngine_MainMenu(trainSeed);

            Trainsrepo.EngineIndex = engineIndex;
            Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Position.Click();
            if (pos != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.Element.SetAttributeValue("Text", pos);
            }
            Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Position.PressKeys("{TAB}");

            if (lockEngine)
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.LockStatus.Click();
            }

            if (engineStatus != "")
            {
                if (engineStatus.ToUpper() == "W")
                {
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.PressKeys("w");
                } else if (engineStatus.ToUpper() == "T")
                {
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.PressKeys("t");
                } else if (engineStatus.ToUpper() == "")
                {
                	engineStatus = "D";
                } else if (engineStatus.ToUpper() != "R" && engineStatus.ToUpper() != "D")//D is valid but it cannot be manually input
                {
                    Ranorex.Report.Error("Engine {"+engineStatus+"} is not a valid engine type, select W or T");
                }

                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.PressKeys("{TAB}");
            }


            if (engineInitial != "" || engineNumber != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.EngineID.Click();
                string engineId = "";
                if (engineInitial == "")
                {
                    engineId = engineNumber;
                } else if (engineNumber == "")
                {
                    engineId = engineInitial;
                } else {
                    engineId = engineInitial+" "+engineNumber;
                }
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.Element.SetAttributeValue("Text", engineId);
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.PressKeys("{TAB}");
            }

            if (engineGroup != "")
            {
                if (Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.GetAttributeValue<string>("Text") != engineGroup)
                {
                    Trainsrepo.GroupText = engineGroup;
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.Click();
                    if (Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupList.GroupListItemByGroupTextInfo.Exists(0))
                    {
                        Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupList.GroupListItemByGroupText.Click();
                    } else {
                        Ranorex.Report.Error("Engine Group {"+engineGroup+"} does not exist in the list");
                        Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.Click();
                    }
                }
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.PressKeys("{TAB}");
            }

            if (model != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Model.Click();
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.Element.SetAttributeValue("Text", model);
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Model.PressKeys("{TAB}");
            }

            if (compensatedHP != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.CompensatedHP.Click();
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.Element.SetAttributeValue("Text", compensatedHP);
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.CompensatedHP.PressKeys("{TAB}");
            }

            if (originLocation != "")
            {
//				Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.Click();
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.PressKeys(originLocation);
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.PressKeys("{TAB}");
            }

            if (originPassCount != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginPassCount.Click();
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.TableMaskCellEditor.Element.SetAttributeValue("Text", originPassCount);
                Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginPassCount.PressKeys("{TAB}");
            }

            if (destinationLocation != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.Click();
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.Element.SetAttributeValue("Text", destinationLocation);
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.PressKeys("{TAB}");
            }

            if (destinationPassCount != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationPassCount.Click();
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.TableMaskCellEditor.Element.SetAttributeValue("Text", destinationPassCount);
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationPassCount.PressKeys("{TAB}");
            }

            int retries = 0;
            if (ptc || pts || cs || lsl)
            {
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.TrainControl.Click();
                Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.Self.PressKeys("{ControlKey down}");
                if (ptc)
                {
                    Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.TrainControlList.PTC.Click();
                }
                if (pts)
                {
                    Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.TrainControlList.PTS.Click();
                }
                if (cs)
                {
                    Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.TrainControlList.CS.Click();
                }
                if (lsl)
                {
                    Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.TrainControlList.LSL.Click();
                }
                Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.Self.PressKeys("{ControlKey up}");
                Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.OkButton.Click();
                while(Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    if (retries == 1)
                    {
                        Trainsrepo.Train_Sheet.Engine.Train_Control_Dialog.OkButton.Click();
                    }
                    retries++;
                }
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.TrainControl.PressKeys("{TAB}");
            }



            if (dpu)
            {
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DPUCheckbox.Click();
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DPUCheckbox.PressKeys("{TAB}");
            }



            if (notes != "")
            {
                Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.Note.Click();
                Trainsrepo.Train_Sheet.Engine.Add_Comments.CommentsText.Element.SetAttributeValue("Text", notes);
                Trainsrepo.Train_Sheet.Engine.Add_Comments.OkButton.Click();
                retries = 0;
                while(Trainsrepo.Train_Sheet.Engine.Add_Comments.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    if (retries == 1)
                    {
                        Trainsrepo.Train_Sheet.Engine.Add_Comments.OkButton.Click();
                    }
                    retries++;
                }

            }

            Trainsrepo.Train_Sheet.Engine.ApplyButton.Click();
            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Engine.RefreshResetButton.Click();
                if (closeForms)
                {
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                }
                return;
            } else {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Engine.ApplyButtonInfo, Trainsrepo.Train_Sheet.Engine.ApplyButtonInfo);
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected feedback of {" + expectedFeedback + "}.");
            }

            if (closeForms)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }

            //We need to see if the trainSeed is set and exists in order to add it as an EngineObject to a particular train
            if (trainSeed != "")
            {
                string trainId = NS_TrainID.GetTrainId(trainSeed);
                if (trainId == null)
                {
                    Ranorex.Report.Error("Engine has been manually added, but trainSeed {"+trainSeed+"} does not point to an existing train");
                    return;
                }

                if (engineSeed != "")
                {
                    //Variables not set as part of manual creation of the engine.
                    string engineOrientation = "";
                    string lastServiceDate = "0";
                    string lastServiceLocation = "";
                    string shuckerDevice = "";
                    string testDueDate = "0";
                    string testDueLocatiom = "";
                    string lastFuelDate = "0";
                    string lastFuelLocation = "";
                    string assignedDivision = "";
                    string helperCrewPoolID = "";
                    string defaultDataApplied = "";
                    string reportingPassCount = "";
                    string reportingLocation = "";
                    string reportingSource = "";
                    string purpose = "";


                    string engineRecord = engineInitial+"|"+engineNumber+"|"+pos+"|"+engineOrientation+"|"+(lockEngine?"Y":"N")+"|"+originPassCount+"|"+originLocation+"|"+destinationPassCount+"|"+destinationLocation+"|"+compensatedHP+"|"+engineGroup+"|"+model+"|"+engineStatus+"|"+(dpu?"Y":"N")+"|"+(pts?"Y":"N")+"|"+(ptc?"Y":"N")+"|"+(lsl?"Y":"N")+"|"+(cs?"Y":"N")+"|"+notes+"|"+lastServiceDate+"|"+lastServiceLocation+"|"+shuckerDevice+"|"+testDueDate+"|"+testDueLocatiom+"|"+lastFuelDate+"|"+lastFuelLocation;
                    Ranorex.Report.Info(engineRecord);
                    if(engineIndex=="0")
                    {
                    	NS_TrainID.CreateEngineConsistRecord(trainSeed, engineSeed, engineRecord, assignedDivision, helperCrewPoolID, defaultDataApplied, reportingPassCount, reportingLocation, reportingSource, purpose);
                    }
                    else
                    {
                    	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
                    	NS_EngineConsistObject engineObject = NS_TrainID.GetEngineObjectFromTrain(trainSeed,engineSeed);
                    	string[] engineRecordSplit = engineRecord.Split('|');
                    	
                    	System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
                    	
                    	engineObject.AssignedDivision = assignedDivision;
                    	engineObject.HelperCrewPoolId = helperCrewPoolID;
                    	engineObject.DefaultDataApplied = defaultDataApplied;
                    	engineObject.ReportingPassCount = reportingPassCount;
                    	engineObject.ReportingLocation = reportingLocation;
                    	engineObject.ReportingSource = reportingSource;
                    	engineObject.MessagePurpose = purpose;
                    	engineObject.SCAC = TrainObject.SCAC;
                    	engineObject.Section = TrainObject.TrainSection;
                    	engineObject.TrainSymbol = TrainObject.TrainSymbol;
                    	engineObject.TrainOriginDate = TrainObject.TrainOriginDate;
                    	engineObject.EngineInitial = engineRecordSplit[0];
                    	engineObject.EngineNumber = engineRecordSplit[1];
                    	engineObject.EnginePosition = engineRecordSplit[2];
                    	engineObject.EngineOrientation = engineRecordSplit[3];
                    	engineObject.EngineLock = engineRecordSplit[4];
                    	engineObject.OriginPassCount = engineRecordSplit[5];
                    	engineObject.OriginLocation = engineRecordSplit[6];
                    	engineObject.DestinationPassCount = engineRecordSplit[7];
                    	engineObject.DestinationLocation = engineRecordSplit[8];
                    	engineObject.CompensatedHP = engineRecordSplit[9];
                    	engineObject.GroupNumber = engineRecordSplit[10];
                    	engineObject.Model = engineRecordSplit[11];
                    	engineObject.EngineStatus = engineStatus; //So, this is done because done because engine consist messages treat empty as D
                    	engineObject.DPU_Status = engineRecordSplit[13];
                    	engineObject.PTS_Equipped = engineRecordSplit[14];
                    	engineObject.PTC_Equipped = engineRecordSplit[15];
                    	engineObject.LSL_Equipped = engineRecordSplit[16];
                    	engineObject.CS_Equipped = engineRecordSplit[17];
                    	engineObject.Notes = engineRecordSplit[18];
                    	engineObject.LastServiceLocation = engineRecordSplit[20];
                    	engineObject.ShuckerDevice = engineRecordSplit[21];
                    	engineObject.TestDueLocation = engineRecordSplit[23];
                    	engineObject.LastFuelLocation = engineRecordSplit[25];
                    }
                } else {
                    Ranorex.Report.Info("Manually Added engine not being added to a Train Object");
                }
            } else {
                Ranorex.Report.Info("Manually Added engine not being added to a Train Object");
            }
            return;

        }

        /// <summary>
        /// Method to add crew members over the UI.
        /// The implementation is to be completed later.
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="crewSeed"></param>
        /// <param name="crewMemberRecord"></param>
        /// <param name="optSequenceNumber"></param>
        /// <param name="optCrewLineSegment"></param>
        [UserCodeMethod]
        public static void NS_AddCrewMemberByCrewMemberRecord_Trainsheet(string trainSeed, string crewSeed, string crewMemberRecord, string expectedFeedback, bool closeForms)
        {
            NS_CrewClass.RefactorAndCreateCrewMemberObject_CrewMemberRecords(crewSeed, crewMemberRecord, "", "");
            NS_AddCrewMemberByCrewObject_Trainsheet(trainSeed, crewSeed, expectedFeedback, closeForms);
        }

        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="CrewMember"></param>
        /// <param name="daylightSaving"></param>
        /// <param name="expectedFeedback"></param>
        [UserCodeMethod]
        public static void NS_AddCrewMemberByCrewObject_Trainsheet(string trainSeed, string crewSeed, string expectedFeedback, bool closeForms)
        {
            NS_CrewMemberObject crewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
            string onDutyDateTimeString = NS_FormatDateTime_TrainSheet(crewMember.onDutyDateTime, crewMember.onDutyTimezone);
            string hosExpirationDateTimeString = NS_FormatDateTime_TrainSheet(crewMember.hosExpireDateTime, crewMember.hosExpireTimezone);
            string onTrainDateTimeString = NS_FormatDateTime_TrainSheet(crewMember.onTrainDateTime, crewMember.onTrainTimezone);
            string offDutyDateTimeString = NS_FormatDateTime_TrainSheet(crewMember.offDutyDateTime, crewMember.offDutyTimezone);
            string offTrainDateTimeString = NS_FormatDateTime_TrainSheet(crewMember.offTrainDateTime, crewMember.offTrainTimezone);
            
            NS_ManuallyAddCrew_Trainsheet(trainSeed, crewMember.crewMemberType, crewMember.crewPosition, crewMember.firstInitial, crewMember.middleInitial,
                                          crewMember.lastName, onDutyDateTimeString, crewMember.onDutyLocation, hosExpirationDateTimeString, onTrainDateTimeString,
                                          crewMember.onTrainLocation, crewMember.onPassCount, crewMember.onLocationMP, offDutyDateTimeString, crewMember.offDutyLocation,
                                          offTrainDateTimeString, crewMember.offTrainLocation, crewMember.offPassCount, crewMember.offLocationMP, expectedFeedback, closeForms);
        }

        /// <summary>
        /// Given a train and an existing crew member object, this method will attempt to create a crew emmber through the PDS UI.
        /// If crew member creation is unsuccessful over PDS, then the crew member is removed from the crew group dictionary.
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ManuallyAddCrew_Trainsheet(string trainSeed, string type, string pos, string firstInitial, string middleInitial, string lastName, string onDutyDateTime, string onDutyLocation, string hosExpirationDateTime, string onTrainDateTime, string onTrainLocation, string onTrainPassCount, string onTrainMilepost, string offDutyDateTime, string offDutyLocation, string offTrainDateTime, string offTrainLocation, string offTrainPassCount, string offTrainMilepost, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);

            // New crew row is always index = 0
            Trainsrepo.CrewIndex = "0";

            // Set Crew Member Type.
            // If the member type property isn't set, the method will take the default.
            if (!string.IsNullOrEmpty(type))
            {

                if (type.ToUpper() != Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeText.Text)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeTextInfo,
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.SelfInfo
                       );
                    
                    switch (type.ToUpper())
                    {
                        case "WK":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.Working.Click();
                            break;
                        case "RC":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.ReliefCrew.Click();
                            break;
                        case "DH":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.Deadhead.Click();
                            break;
                        default:
                            Report.Info(string.Format("The crew member type '{0}' is not valid", type));
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(pos))
            {
                if (pos.ToUpper() != Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionText.Text)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionTextInfo,
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SelfInfo
                       );
                    
                    switch (pos.ToUpper())
                    {
                        case "EN":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Engineer.Click();
                            break;
                        case "SE":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SecondEngineer.Click();
                            break;
                        case "FI":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Fireman.Click();
                            break;
                        case "CO":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Conductor.Click();
                            break;
                        case "B1":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakeman1.Click();
                            break;
                        case "B2":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakeman2.Click();
                            break;
                        case "CT":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.ConductorTrainee.Click();
                            break;
                        case "ET":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.EngineerTrainee.Click();
                            break;
                        case "TT":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakemanTrainee.Click();
                            break;
                        default:
                            Report.Info(string.Format("The crew member position '{0}' is not valid", pos));
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(firstInitial))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", firstInitial);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Info("Off Train Time Zone Input Value: "+ offTrainDateTime.ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            

            if (!string.IsNullOrEmpty(middleInitial))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", middleInitial);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", lastName);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(onDutyDateTime))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.Element.SetAttributeValue("Text", onDutyDateTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                    
                }
            }

            // Set on duty location

            if (!string.IsNullOrEmpty(onDutyLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.LocationCellEditor.Element.SetAttributeValue("Text", onDutyLocation);
                Trainsrepo.Train_Sheet.Crew.CrewTable.LocationCellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(hosExpirationDateTime))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.Element.SetAttributeValue("Text", hosExpirationDateTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train time
            if (!string.IsNullOrEmpty(onTrainDateTime))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.PressKeys(onTrainDateTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            // set on train location
            if (!string.IsNullOrEmpty(onTrainLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.PressKeys(onTrainLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train pass count
            if (!string.IsNullOrEmpty(onTrainPassCount))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.PressKeys(onTrainPassCount);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train milepost
            if (!string.IsNullOrEmpty(onTrainMilepost))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.PressKeys(onTrainMilepost);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            // set off duty time
            if (!string.IsNullOrEmpty(offDutyDateTime))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.PressKeys(offDutyDateTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off duty location
            if (!string.IsNullOrEmpty(offDutyLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.PressKeys(offDutyLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train time
            if (!string.IsNullOrEmpty(offTrainDateTime))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.PressKeys(offTrainDateTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.PressKeys("{TAB}");

                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            

            // set off train location
            if (!string.IsNullOrEmpty(offTrainLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.PressKeys(offTrainLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train pass count
            if (!string.IsNullOrEmpty(offTrainPassCount))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.PressKeys(offTrainPassCount);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train location milepost
            if (!string.IsNullOrEmpty(offTrainMilepost))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.PressKeys(offTrainMilepost);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            Trainsrepo.Train_Sheet.Crew.ApplyButton.Click();
            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return false;
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected Feedback of {"+expectedFeedback+"}.");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return false;
            }

            Ranorex.Report.Info("No Feedback message received. successfully added crew member.");
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            
            return true;
        }

        /// <summary>
        /// Method to add crew members over the UI.
        /// The implementation is to be completed later.
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="crewSeed"></param>
        /// <param name="crewMemberRecord"></param>
        /// <param name="optSequenceNumber"></param>
        /// <param name="optCrewLineSegment"></param>
        [UserCodeMethod]
        public static void NS_AddCrewMemberByCrewMemberRecord_TimeZoneValidation_Trainsheet(string trainSeed, string crewSeed, string crewMemberRecord, bool useInvalidDaylightTime, string expectedFeedback, bool closeForms, int expectedFeedbackLocation)
        {
            NS_CrewClass.RefactorAndCreateCrewMemberObject_CrewMemberRecords(crewSeed, crewMemberRecord, "", "");
            NS_AddCrewMemberByCrewObject_TimeZoneValidation_Trainsheet(trainSeed, crewSeed, useInvalidDaylightTime, expectedFeedback, closeForms, expectedFeedbackLocation);
        }
        
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="CrewMember"></param>
        /// <param name="daylightSaving"></param>
        /// <param name="expectedFeedback"></param>
        [UserCodeMethod]
        public static void NS_AddCrewMemberByCrewObject_TimeZoneValidation_Trainsheet(string trainSeed, string crewSeed, bool useInvalidDaylightTime, string expectedFeedback, bool closeForms, int expectedFeedbackLocation)
        {
            NS_CrewMemberObject crewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
            
            NS_ManuallyAddCrew_TimeZoneValidation_Trainsheet(trainSeed, crewMember.crewMemberType, crewMember.crewPosition, crewMember.firstInitial, crewMember.middleInitial,
                                                            crewMember.lastName, crewMember.onDutyDateTime, crewMember.onDutyTimezone, crewMember.onDutyLocation, crewMember.hosExpireDateTime, crewMember.hosExpireTimezone, 
                                                            crewMember.onTrainDateTime, crewMember.onTrainTimezone, crewMember.onTrainLocation, crewMember.onPassCount, crewMember.onLocationMP, 
                                                            crewMember.offDutyDateTime, crewMember.offDutyTimezone, crewMember.offDutyLocation, crewMember.offTrainDateTime, crewMember.offTrainTimezone, 
                                                            crewMember.offTrainLocation, crewMember.offPassCount, crewMember.offLocationMP, expectedFeedback, closeForms, expectedFeedbackLocation, useInvalidDaylightTime);
        }

        /// <summary>
        /// Given a train and an existing crew member object, this method will attempt to create a crew emmber through the PDS UI.
        /// If crew member creation is unsuccessful over PDS, then the crew member is removed from the crew group dictionary.
        /// </summary>
        [UserCodeMethod]
        public static bool NS_ManuallyAddCrew_TimeZoneValidation_Trainsheet(
            string trainSeed, 
            string type, 
            string pos, 
            string firstInitial, 
            string middleInitial, 
            string lastName, 
            System.DateTime? onDutyDateTime, string onDutyDateTimeZone,
            string onDutyLocation, 
            System.DateTime? hosExpirationDateTime, string hosExpirationDateTimeZone,
            System.DateTime? onTrainDateTime, string onTrainDateTimeZone,
            string onTrainLocation, 
            string onTrainPassCount, 
            string onTrainMilepost, 
            System.DateTime? offDutyDateTime, string offDutyDateTimeZone,
            string offDutyLocation, 
            System.DateTime? offTrainDateTime, string offTrainDateTimeZone,
            string offTrainLocation, 
            string offTrainPassCount, 
            string offTrainMilepost, 
            string expectedFeedback, 
            bool closeForms, 
            int expectedFeedbackLocation,
            bool useInvalidDaylightTime
        ) {
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);

            // New crew row is always index = 0
            Trainsrepo.CrewIndex = "0";

            // Set Crew Member Type.
            // If the member type property isn't set, the method will take the default.
            if (!string.IsNullOrEmpty(type))
            {

                if (type.ToUpper() != Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeText.Text)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeTextInfo,
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.SelfInfo
                       );
                    
                    switch (type.ToUpper())
                    {
                        case "WK":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.Working.Click();
                            break;
                        case "RC":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.ReliefCrew.Click();
                            break;
                        case "DH":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.Deadhead.Click();
                            break;
                        default:
                            Report.Info(string.Format("The crew member type '{0}' is not valid", type));
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(pos))
            {
                if (pos.ToUpper() != Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionText.Text)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionTextInfo,
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SelfInfo
                       );
                    
                    switch (pos.ToUpper())
                    {
                        case "EN":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Engineer.Click();
                            break;
                        case "SE":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SecondEngineer.Click();
                            break;
                        case "FI":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Fireman.Click();
                            break;
                        case "CO":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.Conductor.Click();
                            break;
                        case "B1":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakeman1.Click();
                            break;
                        case "B2":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakeman2.Click();
                            break;
                        case "CT":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.ConductorTrainee.Click();
                            break;
                        case "ET":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.EngineerTrainee.Click();
                            break;
                        case "TT":
                            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.TrainmanBrakemanTrainee.Click();
                            break;
                        default:
                            Report.Info(string.Format("The crew member position '{0}' is not valid", pos));
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(firstInitial))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", firstInitial);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Info("Off Train Time Zone Input Value: "+ offTrainDateTime.ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            

            if (!string.IsNullOrEmpty(middleInitial))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", middleInitial);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 2, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", lastName);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 3, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (onDutyDateTime != null)
            {
                string inputTime = NS_FormatDateTime_TrainSheet(onDutyDateTime, onDutyDateTimeZone, useInvalidDaylightTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.Element.SetAttributeValue("Text", inputTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, onDutyDateTime, onDutyDateTimeZone, useInvalidDaylightTime);
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, appendedFeedback, indexLocation: 4, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Feedback);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                    
                }
            }

            // Set on duty location

            if (!string.IsNullOrEmpty(onDutyLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.LocationCellEditor.Element.SetAttributeValue("Text", onDutyLocation);
                Trainsrepo.Train_Sheet.Crew.CrewTable.LocationCellEditor.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 5, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            if (hosExpirationDateTime != null)
            {
                string inputTime = NS_FormatDateTime_TrainSheet(hosExpirationDateTime, hosExpirationDateTimeZone, useInvalidDaylightTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.Element.SetAttributeValue("Text", inputTime);
                Trainsrepo.Train_Sheet.Crew.CrewTable.CalendarCellEditor.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, hosExpirationDateTime, hosExpirationDateTimeZone, useInvalidDaylightTime);
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, appendedFeedback, indexLocation: 6, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train time
            if (onTrainDateTime != null)
            {
                string inputTime = NS_FormatDateTime_TrainSheet(onTrainDateTime, onTrainDateTimeZone, useInvalidDaylightTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.PressKeys(inputTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, onTrainDateTime, onTrainDateTimeZone, useInvalidDaylightTime);
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 7, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            // set on train location
            if (!string.IsNullOrEmpty(onTrainLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.PressKeys(onTrainLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 8, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train pass count
            if (!string.IsNullOrEmpty(onTrainPassCount))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.PressKeys(onTrainPassCount);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 9, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set on train milepost
            if (!string.IsNullOrEmpty(onTrainMilepost))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.PressKeys(onTrainMilepost);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 10, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            // set off duty time
            if (offDutyDateTime != null)
            {
                string inputTime = NS_FormatDateTime_TrainSheet(offDutyDateTime, offDutyDateTimeZone, useInvalidDaylightTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.PressKeys(inputTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.PressKeys("{TAB}");
                
                //Check if this kicked up some FeedBack
                string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, offDutyDateTime, offDutyDateTimeZone, useInvalidDaylightTime);
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, appendedFeedback, indexLocation: 11, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off duty location
            if (!string.IsNullOrEmpty(offDutyLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.PressKeys(offDutyLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 12, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train time
            if (offTrainDateTime != null)
            {
                string inputTime = NS_FormatDateTime_TrainSheet(offTrainDateTime, offTrainDateTimeZone, useInvalidDaylightTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.PressKeys(inputTime);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.PressKeys("{TAB}");

                //Check if this kicked up some FeedBack
                string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, offTrainDateTime, offTrainDateTimeZone, useInvalidDaylightTime);
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, appendedFeedback, indexLocation: 13, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            

            // set off train location
            if (!string.IsNullOrEmpty(offTrainLocation))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.PressKeys(offTrainLocation);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 14, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train pass count
            if (!string.IsNullOrEmpty(offTrainPassCount))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.PressKeys(offTrainPassCount);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 15, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }

            // set off train location milepost
            if (!string.IsNullOrEmpty(offTrainMilepost))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.Click();
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.PressKeys(offTrainMilepost);
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.PressKeys("{TAB}");
                //Check if this kicked up some FeedBack
                if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 16, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return false;
                }
            }
            
            Trainsrepo.Train_Sheet.Crew.ApplyButton.Click();
            //Check if this kicked up some FeedBack
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 17, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return false;
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected Feedback of {"+expectedFeedback+"}.");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return false;
            }

            Ranorex.Report.Info("No Feedback message received. successfully added crew member.");
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            
            return true;
        }


        /// <summary>
        /// valudating Engine postion has Expected Engine Position in Train Sheet
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="engineSeed"></param>
        /// <param name="expectedEnginePosition"></param>
        [UserCodeMethod]
        public static void NS_ValidateEnginePosition_TrainSheet(string trainSeed , string engineSeed, string expectedEnginePosition)
        {

            string engineNumber = NS_TrainID.GetEngineNumber(trainSeed,engineSeed);
            string engineInitial = NS_TrainID.GetEngineInitial(trainSeed,engineSeed);
            string engineRecord = engineInitial + " " + engineNumber;

            if (engineRecord == " ")
            {
                Ranorex.Report.Error(string.Format("No engine record found for train seed '{0}' and engine seed '{1}'", trainSeed, engineSeed));
                return;
            }
            Trainsrepo.EngineId = engineRecord;

            NS_OpenTrainsheetEngine_MainMenu(trainSeed);

            //valudating Engine postion has Expected Engine Position
            //Validating Engine position is Null or Empty

            string enginePosition = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByEngineID.Position.Text.ToString();
            if(string.IsNullOrEmpty(enginePosition))
            {
                Ranorex.Report.Failure("Engine Position is Empty or Null");
            }
            else
            {
                if (enginePosition == expectedEnginePosition)
                {
                    Ranorex.Report.Success(string.Format("Engine '{0}' has the expected engine position: '{1}'", engineRecord, expectedEnginePosition));
                }
                else
                {
                    Ranorex.Report.Failure(string.Format("Engine '{0}' does not have the expected engine position: '{1}'", engineRecord, expectedEnginePosition));
                }

            }
        }
        /// <summary>
        ///  validating Train trip status as either 'Manually Completed' or 'Automatically Completed'
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_ValidateCompleteTripPlanForTrain(string trainSeed)
        {
            //opens train sheet form

            if(!Trainsrepo.Train_Sheet.TripPlan.SelfInfo.Exists(0))
            {

                NS_Trainsheet.NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

            }
            if(Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {

                int tripPlanRows = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
                int retries=0;
                while (tripPlanRows == 0 && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    tripPlanRows = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
                    retries++;
                }


                string terminationStatus = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusText.GetAttributeValue<string>("Text");
                if (terminationStatus == "Manually Completed" || terminationStatus == " Automatic Completed")
                {

                    Ranorex.Report.Success("Train trip got  completed for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}");
                    Ranorex.Report.Success("Status for train is {"+terminationStatus+"}");
                    Trainsrepo.Train_Sheet.OkButton.Click();
                    return;
                }
                else
                {
                    Ranorex.Report.Failure("Train trip  not get completed for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    Ranorex.Report.Failure("Status for train is {"+terminationStatus+"}");
                    Trainsrepo.Train_Sheet.OkButton.Click();
                    return;
                }


            }
            else
            {
                Ranorex.Report.Failure("Train Sheet does not Exist");

            }

        }
        /// <summary>
        ///  validating Train trip status  for Train by activity
        /// </summary>
        /// <param name="trainSeed" ,"activity",optionalLocation,expectedStatus>Input:trainSeed</param>
        /// <param name="expectedActivityState">The expected activity state for the activity type (e.g. 'In-progress')</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. 'Change Crew')</param>

        [UserCodeMethod]
        public static void NS_ValidateTripPlanStatusForTrainByActivity(string trainSeed, string activity, string optionalLocation, string expectedStatus)
        {
            //to open train sheet
            NS_Trainsheet.NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            if(!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Train Sheet does not Exist");
                return;
            }


            int retries=0;
            while (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }

            int tripPlanRows = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;

            if (optionalLocation != "")
            {
                for(int i = 0; i < tripPlanRows; i++)
                {
                    Trainsrepo.TripPlanIndex = i.ToString();
                    
                    if (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.Text.Trim().ToLower() == activity.ToLower())
                    {
                        string currentLocation = "";
                        if(!String.IsNullOrEmpty(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("Text")))
                        {
                            currentLocation = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("StationId");
                        }
                        
                        if(currentLocation.Equals(optionalLocation, StringComparison.OrdinalIgnoreCase))
                        {
                            Report.Info("Actual location " +optionalLocation+ " found "  +currentLocation);
                            break;
                        }
                    }
                    
                }
                //Index will still be set by the for loop
                if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.GetAttributeValue<bool>("Selected"))
                {
                    Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
                    Ranorex.Delay.Milliseconds(500);
                }
            }

            else
            {
                Trainsrepo.TripPlanActivity = activity;
                if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Could not locate a trip plan even with an activity of {"+activity+"}.");
                    return;
                }
                if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.SelectionCell.GetAttributeValue<bool>("Selected"))

                {
                    Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.SelectionCell.Click();
                    Ranorex.Delay.Milliseconds(500);
                }
            }


            string currentStatus = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.Status.StatusText.GetAttributeValue<string>("Text");

            Ranorex.Report.Info("current status: '" + currentStatus + "'");
            if (currentStatus.Equals(expectedStatus))
            {

                Ranorex.Report.Success(string.Format("Status'{0}' got matched with expected value: '{1}'" ,currentStatus , expectedStatus));
            }

            else
            {
                Ranorex.Report.Failure(string.Format("status '{0}' does not match with expected value:  '{1}'", currentStatus, expectedStatus));
            }

            Trainsrepo.Train_Sheet.OkButton.Click();
            return;
        }


        [UserCodeMethod]
        public static void validatePTCCSGNMessage_TrainHistory(string trainSeed, string engineSeed, string crewSeed, string optDistrict)
        {

            string employee_first = NS_CrewClass.GetCrewMemberFirstInitial(crewSeed);
            string employee_middle = NS_CrewClass.GetCrewMemberMiddleInitial(crewSeed);
            string employee_last = NS_CrewClass.GetCrewMemberLastName(crewSeed);

            string engineerName = employee_first + " " + employee_middle + " " + employee_last;
            string engineNumber = NS_TrainID.GetEngineInitial(trainSeed, engineSeed)+ " " +NS_TrainID.GetEngineNumber(trainSeed, engineSeed);

            string CSGNMessage = "PTC crew information received for "+engineNumber+ ", engineer " + engineerName + " from " + NS_TrainID.GetTrainId(trainSeed)+ ".";

            Ranorex.Report.Info(CSGNMessage);
            NS_ValidateTrainSheetHistory(trainSeed, CSGNMessage, "", "", "", optDistrict);
        }
        
        [UserCodeMethod]
        public static void validateBulletinVoidMessage_TrainHistory(string trainSeed, string bulletinSeed, bool closeForm)
        {

            string trainId = NS_TrainID.GetTrainId(trainSeed);
            string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            string bulletinVoidMessage = "Train "+trainId+ " notified of voided Bulletin "+bulletinNumber+".";

            Ranorex.Report.Info(bulletinVoidMessage);
            NS_ValidateTrainSheetHistory(trainSeed, bulletinVoidMessage, "", "", "", "", true);
        }

        [UserCodeMethod]
        public static void validate_PTCCrewLogonMessage_TrainHistory(string trainSeed, string optDistrict)
        {

            string trainClearance = NS_TrainID.GetTrainClearanceNumber(trainSeed);

            string crewLogonMessage = "PTC crew logon with train clearance "+trainClearance+".";

            Ranorex.Report.Info(crewLogonMessage);
            NS_ValidateTrainSheetHistory(trainSeed, crewLogonMessage, "", "", "", optDistrict);
        }

        [UserCodeMethod]
        public static void validate_IssueBulletinRelay_TrainHistory(string trainSeed, string bulletinSeed, string optDistrict, bool closeTrainSheet)
        {
            string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            string bulletinType = NS_Bulletin.GetBulletinType(bulletinSeed);

            string trainHistoryString = "Bulletin "+bulletinNumber+" of type "+bulletinType+@" issued to train .*";
            NS_ValidateTrainSheetHistory(trainSeed, trainHistoryString, "", "", "", optDistrict);
            if (closeTrainSheet)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
        }
        /// <summary>
        ///  Configure and add Status field to display fields
        /// </summary>
        /// <param name="selectableField">Input:"Status"</param>

        [UserCodeMethod]
        public static void NS_AddColumnToTable_TrainStatusSummary(string Column)
        {
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();

            Trainsrepo.FieldName=Column;
            // Verifying Configure menu in the TrainStatusSummary Window
            if(Trainsrepo.Train_Status_Summary.MainMenuBar.ConfigureButtonInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.MainMenuBar.ConfigureButtonInfo,
                                                                              Trainsrepo.Train_Status_Summary.ConfigureMenu.ConfigureSelectedFieldsInfo);

                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.ConfigureMenu.ConfigureSelectedFieldsInfo,
                                                                              Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.SelectableFieldsList.FieldNameListItemByExactFieldNameInfo);
                // Verifying selectableFields'Status' is existing or not in Table
                if(Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.SelectableFieldsList.FieldNameListItemByExactFieldNameInfo.Exists(0))
                {
                    Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.SelectableFieldsList.FieldNameListItemByExactFieldName.Click();
                    Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.AddButton.Click();
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.OkButtonInfo,
                                                                                          Trainsrepo.Train_Status_Summary.ConfigureMenu.ConfigureSelectedFieldsInfo);
                    Ranorex.Report.Success("Expected Column added Succussefully",Column);
                }

                else
                {
                    if(Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.SelectedFieldsList.FieldNameListItemByFieldNameInfo.Exists(0))
                    {

                        Ranorex.Report.Info("Column already added in selected field list");
                        Trainsrepo.Train_Status_Summary.Configure_Selected_Fields.OkButton.Click();
                    }

                    else
                    {
                        Ranorex.Report.Failure("Column is not visible in the list so not able to select the fields");
                    }
                }

                Trainsrepo.Train_Status_Summary.WindowControls.Close.Click();
            }
            else
            {
                Ranorex.Report.Failure("Could not find the Configure menu in the TrainStatusSummary Window");
            }

        }

        /// <summary>
        ///  Validate the Status for the Train in the TrainStatusSummary
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed for the Train ex: "A0,B0 etc "</param>
        /// <param name="expectedStatus">Input:Status for the Train ex: "In, Approach,Arrived"</param>

        [UserCodeMethod]
        public static void NS_validate_StatusInTrainStatusSummary(string trainSeed, string expectedStatus)

        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            Trainsrepo.TrainId=trainId;
            //Checking for the Status Column Present or not in TrainStatusSummary Table
            if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.StatusInfo.Exists(0))
            {

                string currentStatus=Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.Status.GetAttributeValue<string>("Value");

                Ranorex.Report.Info("current status: '" + currentStatus+"'");

                if (currentStatus.Equals(expectedStatus))
                {
                    Ranorex.Report.Success(string.Format("Status'{0}' got matched with expected value: '{1}'" ,currentStatus , expectedStatus));
                }

                else
                {
                    Ranorex.Report.Failure(string.Format("status '{0}' does not match with expected value:  '{1}'", currentStatus, expectedStatus));
                }
                Trainsrepo.Train_Status_Summary.WindowControls.Close.Click();
            }

            else
            {
                Ranorex.Report.Failure("Status Column not found in TrainStatusSummary Window");

            }
        }

        /// <summary>
        /// Validates ETA data record is available in database or not
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="opstaLocation">Input opstaLocation</param>
        /// <param name="isPresent">Input If its true ETA record is present, if false ETA record is not present</param>
        [UserCodeMethod]
        public static void NS_validate_ETArecord_BackFlow(string trainSeed,string opstaLocation,bool IsPresent)
        {
            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            if(trainSymbol!= null)
            {
                Oracle.Code_Utils.ADMSEnvironment.Validate_ETARecord_ADMS(trainSymbol, opstaLocation, originDate, IsPresent);
            }
            else
            {
                Ranorex.Report.Error("Train Symbol is not Valid");
            }

        }

        /// <summary>
        /// Validates Trip plan data recorded in the train sheet or not
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeTrainsheet">Close the train sheet</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlan_Populated(string TrainSeed, bool closeTrainsheet = true)
        {

            NS_Trackline_Validations.NS_OpenTrainSheet_TrackLine(TrainSeed);
            int retries = 0;
            if ( Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.GetAttributeValue<bool>("Selected"))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainIDTextInfo,
                                                          Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo);

                while(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo.Exists(0) && retries < 5)
                {
                    Ranorex.Delay.Milliseconds(1000);
                    retries++;
                }
                Ranorex.Report.Success("TripPlan has Populated for the given Train");
            }
            else
            {
                Ranorex.Report.Failure("No TripPlan Exist For the Given Train");
            }
            if (closeTrainsheet)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }

        /// <summary>
        /// Validates Movement data recorded in the train sheet or not
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeTrainsheet">Close the train sheet</param>
        [UserCodeMethod]
        public static void NS_ValidateMovement_Populated(string TrainSeed, bool closeTrainsheet = true)
        {
            NS_Trackline_Validations.NS_OpenTrainSheet_TrackLine(TrainSeed);
            int retrires = 0;
            Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Click();
            if ( Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.GetAttributeValue<bool>("Selected"))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainIDTextInfo,
                                                          Trainsrepo.Train_Sheet.Movement.MovementTable.SelfInfo);
                while(!Trainsrepo.Train_Sheet.Movement.MovementTable.SelfInfo.Exists(0) && retrires <5)
                {
                    Ranorex.Delay.Milliseconds(1000);
                    retrires++;
                }
                Ranorex.Report.Success(" Moment Data has Populated for the given Train ");
            }
            else
            {
                Ranorex.Report.Failure(" No Movement data Exist for the Train ");
            }
            if (closeTrainsheet)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }

        /// <summary>
        /// Set the Modes for Train in TrainStatus Summary
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="ModeName">ex:if Mode is Manual or Automatic</param>
        [UserCodeMethod]
        public static void NS_Set_TrainMode_TSS(string trainSeed, string modeName, bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            Trainsrepo.TrainId=trainId;
            if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
            {
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
                    if (closeForm)
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);

                    }
                    return;
                }
                switch(modeName.ToLower())
                {
                    case "manual":
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                            Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.ManualInfo,
                            Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo
                        );
                        Ranorex.Report.Success("Mannual Mode has been Set for Train {"+trainId+"}");
                        break;
                    case "automatic":
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                            Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.AutomaticInfo,
                            Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo
                        );
                        Ranorex.Report.Success("Automatic Mode has been Set for Train {"+trainId+"}");
                        break;
                    default:
                        Report.Screenshot(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.Self);
                        Report.Error(string.Format("Mode button '{0}' is not an option for train with seed '{1}'", modeName, trainSeed));
                        break;
                }
                if (closeForm)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);

                }
            }
            else
            {

                Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
            }
        }
        /// <summary>
        /// Validate RemoveTrain Option in Context Menu in Train Status Summary
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="expRemoveTrainOption">Input If it is True ,remove train option is enabled ,else it is disabled</param>
        [UserCodeMethod]
        public static void NS_ValidateRemoveTrainOption_TSS(string trainSeed, bool expRemoveTrainOption,bool closeForm)
        {
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            Trainsrepo.TrainId=trainId;
            if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
            {
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
                }
                bool actRemovTrainEnableStatus = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.RemoveTrain.Enabled;
                if(expRemoveTrainOption == actRemovTrainEnableStatus)
                {
                    Ranorex.Report.Success("Expected RemoveTrain button enable status to be {"+expRemoveTrainOption+"} and found {"+actRemovTrainEnableStatus+"}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected RemoveTrain enable status to be {"+expRemoveTrainOption+"} but found {"+actRemovTrainEnableStatus+"}");
                }

                if (closeForm)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Id {"+trainId+"} does not exist");
            }
        }
        /// <summary>
        /// Validate No train found in Train Status Summary
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        [UserCodeMethod]
        public static void Validate_TrainExists_TrainStatusSummary(string trainSeed,bool validateDoesExist,bool closeForm)
        {
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            Trainsrepo.TrainId=trainId;
            if (!validateDoesExist)
            {

                if (!Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    Ranorex.Report.Success("Train {"+trainId+"} not found in Train Status Summary");
                }
                else
                {
                    Ranorex.Report.Failure("Train Id {"+trainId+"} found in Train Status Summary");
                }

            }
            else
            {

                if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    Ranorex.Report.Success("Train {"+trainId+"}  found in Train Status Summary");
                }
                else
                {
                    Ranorex.Report.Failure("Train Id {"+trainId+"} not  found in Train Status Summary");
                }

            }
            if (closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
            }
        }

        /// <summary>
        /// Add a Delay over the UI
        /// <param name="trainSeed"></param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_AddDelayManually(string trainSeed, string FromLocation, string frominputTimeZone, string toinputTimeZone, string ToLocation, string DelayCode, string Duration, string CrewID, string CrewSegment, string Comments, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            Trainsrepo.DelayIndex = "0";
            System.DateTime origin = System.DateTime.Now;
            if (!string.IsNullOrEmpty(FromLocation))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromLocationFieldCellEditor.Element.SetAttributeValue("Text", FromLocation);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromLocation.PressKeys("{TAB}");
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            string fromTime = null;

            fromTime = NS_FormatDateTime_TrainSheet(origin, frominputTimeZone);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromTimeFieldComboBoxEditor.Element.SetAttributeValue("Text", fromTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromTime.FromTimeText.PressKeys("{TAB}");
            
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(ToLocation))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromLocationFieldCellEditor.Element.SetAttributeValue("Text", ToLocation);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToLocation.PressKeys("{TAB}");
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            string toTime = null;
            origin = origin.AddMinutes(Convert.ToDouble(Duration));
            toTime = NS_FormatDateTime_TrainSheet(origin, toinputTimeZone);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromTimeFieldComboBoxEditor.Element.SetAttributeValue("Text", toTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToTime.ToTimeText.PressKeys("{TAB}");
            
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(DelayCode))
            {
                if (Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.GetAttributeValue<string>("Text") != DelayCode)
                {
                    Trainsrepo.CodeName = DelayCode;
                    //Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.Click();
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeTextInfo, Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.SelfInfo);
                    if (Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.CodeListItemByNameInfo.Exists(0))
                    {
                        Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.CodeListItemByName.Click();
                    }
                    else
                    {
                        Ranorex.Report.Error("Delay Code {" + DelayCode + "} does not exist in the list");
                        Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.Click();
                    }
                }
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(Duration))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Duration.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.TextFieldEditor.Element.SetAttributeValue("Text", Duration);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Duration.PressKeys("{TAB}");
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(CrewID))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Element.SetAttributeValue("Text", CrewID);
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.PressKeys("{TAB}");
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(CrewSegment))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Element.SetAttributeValue("Text", CrewSegment);
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.PressKeys("{TAB}");
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            int retries = 0;
            if (!string.IsNullOrEmpty(Comments))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.Comments.Click();
                Trainsrepo.Train_Sheet.Delay.Add_Comments.CommentsText.Element.SetAttributeValue("Text", Comments);
                Trainsrepo.Train_Sheet.Delay.Add_Comments.OkButton.Click();
                retries = 0;
                while (Trainsrepo.Train_Sheet.Delay.Add_Comments.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    if (retries == 1)
                    {
                        Trainsrepo.Train_Sheet.Delay.Add_Comments.OkButton.Click();
                    }
                    retries++;
                }
            }
            Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            retries = 0;
            while (Trainsrepo.Train_Sheet.Delay.ApplyButton.Enabled && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                if (retries == 1)
                {
                    Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
                }
                retries++;
            }
            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        /// <summary>
        /// Add a Delay over the UI
        /// <param name="trainSeed"></param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_AddDelayManually_TimeZoneValidation(string trainSeed, string FromLocation, bool useInvalidDaylightTime, string frominputTimeZone, string toinputTimeZone, string ToLocation, string DelayCode, string Duration, string CrewID, string CrewSegment, string Comments, string expectedFeedback, bool closeForms, int expectedFeedbackLocation)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            Trainsrepo.DelayIndex = "0";
            System.DateTime origin = System.DateTime.Now;
            if (!string.IsNullOrEmpty(FromLocation))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromLocationFieldCellEditor.Element.SetAttributeValue("Text", FromLocation);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromLocation.PressKeys("{TAB}");
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            string fromTime = null;

            fromTime = NS_FormatDateTime_TrainSheet(origin, frominputTimeZone, useInvalidDaylightTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromTimeFieldComboBoxEditor.Element.SetAttributeValue("Text", fromTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.FromTime.FromTimeText.PressKeys("{TAB}");
            string fromTimeFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, origin, frominputTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, fromTimeFeedback, indexLocation: 2, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(ToLocation))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromLocationFieldCellEditor.Element.SetAttributeValue("Text", ToLocation);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToLocation.PressKeys("{TAB}");
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 3, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            string toTime = null;
            origin = origin.AddMinutes(Convert.ToDouble(Duration));
            toTime = NS_FormatDateTime_TrainSheet(origin, toinputTimeZone, useInvalidDaylightTime);
            string toTimeFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, origin, toinputTimeZone, useInvalidDaylightTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToFromTimeFieldComboBoxEditor.Element.SetAttributeValue("Text", toTime);
            Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.ToTime.ToTimeText.PressKeys("{TAB}");
            
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, toTimeFeedback, indexLocation: 4, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(DelayCode))
            {
                if (Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.GetAttributeValue<string>("Text") != DelayCode)
                {
                    Trainsrepo.CodeName = DelayCode;
                    //Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.Click();
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeTextInfo, Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.SelfInfo);
                    if (Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.CodeListItemByNameInfo.Exists(0))
                    {
                        Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeList.CodeListItemByName.Click();
                    }
                    else
                    {
                        Ranorex.Report.Error("Delay Code {" + DelayCode + "} does not exist in the list");
                        Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Code.CodeText.Click();
                    }
                }
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 5, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(Duration))
            {
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Duration.Click();
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.TextFieldEditor.Element.SetAttributeValue("Text", Duration);
                Trainsrepo.Train_Sheet.Delay.DelayInputTable.DelayInputRow.Duration.PressKeys("{TAB}");
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 6, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(CrewID))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Element.SetAttributeValue("Text", CrewID);
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.PressKeys("{TAB}");
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 7, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (!string.IsNullOrEmpty(CrewSegment))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Element.SetAttributeValue("Text", CrewSegment);
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.PressKeys("{TAB}");
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 8, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            int retries = 0;
            if (!string.IsNullOrEmpty(Comments))
            {
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.Comments.Click();
                Trainsrepo.Train_Sheet.Delay.Add_Comments.CommentsText.Element.SetAttributeValue("Text", Comments);
                Trainsrepo.Train_Sheet.Delay.Add_Comments.OkButton.Click();
                retries = 0;
                while (Trainsrepo.Train_Sheet.Delay.Add_Comments.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    if (retries == 1)
                    {
                        Trainsrepo.Train_Sheet.Delay.Add_Comments.OkButton.Click();
                    }
                    retries++;
                }
            }
            Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
            //Check if this kicked up some FeedBack
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 9, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            retries = 0;
            while (Trainsrepo.Train_Sheet.Delay.ApplyButton.Enabled && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                if (retries == 1)
                {
                    Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
                }
                retries++;
            }
            //Check if this kicked up some FeedBack
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 10, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        private static string NS_FormatDateTime_TrainSheet(System.DateTime inputDateTime, string inputTimeZone, bool useInvalidDaylightTime = false, string inputTimeOffset = "0")
        {
            if (useInvalidDaylightTime)
            {
                return NS_Time.FormatDateTime(
                    inputDateTime: NS_Time.GetNextTransitionDate(inputTime: inputDateTime, inputTimeZone: inputTimeZone),
                    inputTimeZone: inputTimeZone,
                    inputStringOffset: inputTimeOffset,
                    allowEmptyString: false,
                    outputTimeFormat: NS_Time.GetPDSTimeFormat()
                   );
            } else {
                return NS_Time.FormatDateTime(
                    inputDateTime: inputDateTime,
                    inputTimeZone: inputTimeZone,
                    inputStringOffset: inputTimeOffset,
                    allowEmptyString: false,
                    outputTimeFormat: NS_Time.GetPDSTimeFormat()
                   );
            }
        }

        // Our classes include both nullable and non-nullable DateTime objects.
        // This overload allows the user to retrieve a formatted string without needing to check whether their DateTime is nullable.
        private static string NS_FormatDateTime_TrainSheet(System.DateTime? inputDateTime, string inputTimeZone, bool useInvalidDaylightTime = false)
        {
            // At a certain point, various internal object DateTime properties were converted to DateTime? properties. This resolves the issue.
            if (inputDateTime == null)
            {
                return "";
            } 
            System.DateTime notNullableDateTime = (System.DateTime)inputDateTime;
            return NS_FormatDateTime_TrainSheet(inputDateTime: notNullableDateTime, inputTimeZone: inputTimeZone, useInvalidDaylightTime: useInvalidDaylightTime);
        }

        /// <summary>
        /// validating time zone for delay in ADMS.ABF_TDL_TRAIN_DELAY
        /// <param name="trainSeed">Input trainSeed</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTimeZone_Delay_ADMS(string trainSeed, string delayCode, string fromOpsta, string toOpsta, string fromTimeZone, string toTimeZone)
        {
            string trainKey = NS_TrainMiscellaneous.GetTrainKeyFromADMS(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);
            if(!string.IsNullOrEmpty(trainKey))
            {
                Oracle.Code_Utils.ADMSEnvironment.ValidateTimeZone_Delay_ADMS(trainKey, originDate, delayCode, fromOpsta, toOpsta, fromTimeZone, toTimeZone);
            }
            else
            {
                Ranorex.Report.Error("Train Key is not Valid");
            }
        }
        
        /// <summary>
        /// Validate Engine status in ADMS using the engine object
        /// </summary>
        /// <param name="trainSeed">key for train in dictionary</param>
        /// <param name="engineSeed">key for engine in dictionary</param>
        /// <param name="consistStatus">not included in engine object, depends on train status</param>
        /// <param name="eventSubtype">Add, Modify, etc</param>
        [UserCodeMethod]
        public static void NS_ValidateEngineWithObject_ADMS(string trainSeed, string engineSeed, string consistStatus, string eventSubtype)
        {
        	NS_TrainObject train = NS_TrainID.getTrainObject(trainSeed);
        	NS_EngineConsistObject engine = train.GetEngineObject(engineSeed);
         	ADMSEnvironment.ValidateEngine_ADMS(engine.SCAC, engine.TrainSymbol, train.TrainSection, engine.EngineInitial, engine.EngineNumber, engine.ReportingLocation, engine.ReportingPassCount, engine.ReportingSource, engine.EngineStatus, consistStatus, engine.EnginePosition,
        	                       engine.EngineLock, engine.GroupNumber, engine.Model, engine.CompensatedHP, engine.PTS_Equipped, engine.PTC_Equipped, engine.LSL_Equipped, engine.CS_Equipped, engine.Notes, engine.OriginLocation, engine.OriginPassCount, engine.DestinationLocation,
        	                       engine.DestinationPassCount, eventSubtype);
        }
        
        /// <summary>
        /// Validating Time zone backflow ABF_TEC_CREW table in ADMS
        /// <param name="trainSeed">Input: trainSeed to get trainSymbol and originDate</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTimeZoneCrewTable(string trainSeed, string crewSeed)
        {
            //string trainKey = PDS_CORE.Code_Utils.NS_TrainID.GetTrainKey(trainSeed);
            string trainKey = NS_TrainMiscellaneous.GetTrainKeyFromADMS(trainSeed);
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
            string firstName = NS_CrewClass.GetCrewMemberFirstInitial(crewSeed);
            string middleName = NS_CrewClass.GetCrewMemberMiddleInitial(crewSeed);
            string lastName = NS_CrewClass.GetCrewMemberLastName(crewSeed);

            if(trainKey != null || trainKey != "")
            {
                //Get Time zone from ABF_TEC_CREW table in ADMS
                Oracle.Code_Utils.ADMSEnvironment.ValidateCrewTimeZone_ADMS(trainKey, originDate, firstName, middleName, lastName);
            }
            else
            {
                Ranorex.Report.Failure("Unable to find train with Train Symbol: " +trainId);
                return;
            }
        }
        
        /// <summary>
        /// Validates a reporting source from the ADMS Table ABF_TRC_CONSIST_SUMMARY
        /// </summary>
        /// <param name="trainSeed">Seed of train to be validated</param>
        /// <param name="source">TCSM, CD-TCON, or SYSTEM</param>
        /// <param name="reportingSource">Expected reporting source O, C, T, A, G, etc</param>
        /// <param name="eventSubtype">ADD, MODIF, NEW_ENGINE, TRAIN_CONSIST_SUMMARY</param>
        [UserCodeMethod]
        public static void NS_ValidateTCSMReportingSource (string trainSeed, string source, string reportingSource, string eventSubtype, string timeFrameInSeconds)
        {
        	NS_TrainObject trainObj = NS_TrainID.getTrainObject(trainSeed);
        	ADMSEnvironment.ValidateTCSMReportingSource(trainObj.TrainSymbol, source, reportingSource, eventSubtype, timeFrameInSeconds);
        }

        /// <summary>
        /// Compares feedback with regex of expectedFeedback
        /// </summary>
        /// <param name="feedback">Input:feedback</param>
        /// <param name="expectedFeedback">Input:expectedFeedback</param>
        public static bool CheckFeedbackExists(Adapter feedback, string expectedFeedback)
        {
            bool checkFeedbackFlag = false;
            bool failureFound=false;
            string[] expectedFeedbackSplit = expectedFeedback.Split('|');

            Regex expectedFeedbackRegex = new Regex(expectedFeedbackSplit[feedbackCounter]);
            string feedbackText = feedback.GetAttributeValue<string>("Text");
            if ((expectedFeedbackSplit[feedbackCounter] == "" || expectedFeedbackSplit[feedbackCounter] == " ") && (feedbackText == "" || feedbackText == " "))
            {
                checkFeedbackFlag = true;
                failureFound=false;
                Ranorex.Report.Success("Expected no feedback , received no feedback");
            }
            else if (expectedFeedbackSplit[feedbackCounter] != "" && expectedFeedbackRegex.IsMatch(feedbackText))
            {
                checkFeedbackFlag = false;
                failureFound=false;
                Ranorex.Report.Success("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
            }
            else if (expectedFeedbackSplit[feedbackCounter] != "" && !expectedFeedbackRegex.IsMatch(feedbackText))
            {
                checkFeedbackFlag = false;
                failureFound=true;
                Ranorex.Report.Failure("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
            }
            else if (expectedFeedbackSplit[feedbackCounter] == "" && feedbackText != "")
            {
                checkFeedbackFlag = false;
                failureFound=true;
                Ranorex.Report.Failure("Expected Regex feedback of {"+@expectedFeedbackRegex+"} found feedback {"+feedbackText+"}.");
            }
            else
            {
                checkFeedbackFlag = true;
                failureFound=true;
                Ranorex.Report.Failure("Expected {"+@expectedFeedbackRegex+"} and received feedback {"+feedbackText+"} do not match");
            }

            feedbackCounter = feedbackCounter + 1;
            if(feedbackCounter == expectedFeedbackSplit.Length || failureFound==true)
            {
                feedbackCounter = 0;
            }
            return checkFeedbackFlag;
        }

        public static bool ValidateFeedbackExists(Ranorex.Adapter feedback, string expectedFeedback, int indexLocation = 0, int expectedLocation = 0) 
        {
            Regex expFeedback = new Regex(expectedFeedback);
            string feedbackText = feedback.GetAttributeValue<string>("Text").Trim();
            bool isFeedback = feedbackText.Length > 0;
            
            // In the following condition, we're evaluating for feedback where it is not expected.
            if (!indexLocation.Equals(expectedLocation))
            {
                if (isFeedback)
                {
                    // In this condition, feedback is being received where it is not expected.
                    // If feedback exists where it is not being evaluated, then it should be treated with aprehension.
                    Report.Failure("Validation", string.Format("The following feedback appears where it is not expected: '{0}'", feedbackText));
                }
            }

            // In this case, where evaluating feedback where we expect the feedback
            if (indexLocation.Equals(expectedLocation))
            {
                if (expFeedback.IsMatch(expectedFeedback))
                {
                    // We should display a success message if the feedback matches
                    // but not if the feedback is blank
                    if (isFeedback)
                    {
                        Report.Success("Validation", string.Format("Actual feedback matches expected feedback: '{0}'", feedbackText));
                    }
                    
                } else {
                    Report.Failure("Validation", string.Format("Expected feedback does not match actual feedback. Expected: '{0}'; Actual: '{1}'", expectedFeedback, feedbackText));
                }
            }

            return isFeedback;
        }


        /// <summary>
        /// Adding Assigned Work in the TrainSheet --> Train tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="operation"> Type value e.g. Pickup, Setout and Other</param>
        /// <param name="Opsta"></param>
        /// <param name="PassCount"></param>
        /// <param name="loads"></param>
        /// <param name="empties"></param>
        /// <param name="tons"></param>
        /// <param name="lenght"></param>
        /// <param name="note"></param>
        /// <param name="coal"></param>
        /// <param name="needDateTimeOffset"></param>
        /// <param name="needDateTimeZone"></param>
        /// <param name="completionDateTimeOffset"></param>
        /// <param name="completionDateTimeZone"></param>
        /// <param name="coalPermit"></param>
        /// <param name="coalCarsRecords"></param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void AddAssignedWork_Trainsheet(string trainSeed, string operation, string Opsta, string PassCount, string loads, string empties, string tons, string length, string note, bool coal, int needDateTimeOffset, string needDateTimeZone, int completionDateTimeOffset, string completionDateTimeZone, string coalPermit, string coalCarsRecords, string expectedFeedback, bool closeForms)
        {
            //Open the trainsheet first and select the Trains tab
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);

            string train_id = NS_TrainID.GetTrainId(trainSeed);
            int retries=0;
            while(!Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo.Exists(0) && retries<3)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo);
                retries++;
            }
            //Select the operation from the dropdown
            if(operation!= "" && Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo.Exists(0))
            {
                operation = operation.ToLower();
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationTextInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                if(operation == "pickup")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.PickupInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else if (operation == "setout")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SetoutInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else if (operation == "other")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.OtherInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Failure("Invalid Operation Input" +operation);
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            }
            else
            {
                Report.Failure("Please Enter valid value for Operation dropdown or page is not loaded properly.");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the Opsta value and throw error if invalid opsta entered
            if(Opsta!= "")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.OpStaName.PressKeys(Opsta);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.OpStaName.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }
            else
            {
                Report.Failure("Please provide valid value for Opsta field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the PassCount value and throw error if invalid Pass Count entered
            if (!string.IsNullOrEmpty(PassCount))
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.PassCount.PressKeys(PassCount);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.PassCount.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }

            //Fill the loads value and throw error if invalid Pass Count entered
            if(!string.IsNullOrEmpty(loads) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Loads.PressKeys(loads);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Loads.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }

            //Fill the Empties value
            if(!string.IsNullOrEmpty(empties) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Empties.PressKeys(empties);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Empties.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the Tons value
            if(!string.IsNullOrEmpty(tons) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Tons.PressKeys(tons);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Tons.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the length value
            if(!string.IsNullOrEmpty(length) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys(length);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys("{TAB}");

                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the note value
            if(!string.IsNullOrEmpty(note))
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Note.Click();

                if(Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.SelfInfo.Exists(0)){
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.AddCommentsText.PressKeys(note);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.OkButton.Click();
                }
                else
                {
                    Ranorex.Report.Failure("Add comments window does not exist");
                }

                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys("{TAB}");
            }

            //Select the checkbox for Coal
            if(coal && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Coal.Click();
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Coal.PressKeys("{TAB}");
            }

            System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
            System.DateTime needDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(needDateTimeOffset));

            string needDateTimeInput = NS_FormatDateTime_TrainSheet(needDateTime, needDateTimeZone);

            //set need date
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.Click();
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.PressKeys(needDateTimeInput);
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Need Date Time Zone Input Value: "+ needDateTimeInput.ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;

            }

            System.DateTime completionDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(completionDateTimeOffset));
            string completionDateTimeInput = NS_FormatDateTime_TrainSheet(completionDateTime, completionDateTimeZone);
            
            //set completion date
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.Click();
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.PressKeys(completionDateTimeInput);
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.PressKeys("{TAB}");
            Ranorex.Report.Info("ComDatevalue: "+ completionDateTimeInput.ToString());
            
            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Completion Date Time Zone Input Value: "+ completionDateTimeInput.ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the Coal Permit value
            if(!string.IsNullOrEmpty(coalPermit) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CoalPermit.PressKeys(length);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CoalPermit.PressKeys("{TAB}");
            }

            if(!string.IsNullOrEmpty(coalCarsRecords) && operation!= "other")
            {
                string[] coalCarsRecordsElements = coalCarsRecords.Split('|');
                int totalCarsRecord = coalCarsRecordsElements.Length;
                if (totalCarsRecord % 2 == 0)
                {
                    for (int i = 0; i < totalCarsRecord; i= i+2)
                    {
                        string coalCar = coalCarsRecordsElements[i];
                        string coalClassification = coalCarsRecordsElements[i+1];
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys(coalCar);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys(coalClassification);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Invalid assigned record lengths present. Assigned work not created.");
                    return;
                }
            }
            
            Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButton.Click();
            retries = 0;
            while (Trainsrepo.Train_Sheet.Feedback.TextValue == "" && retries < 2)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            	return;
            }
            else
            {
            	GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo, Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo);
            }
            if(expectedFeedback != "")
            {
            	Ranorex.Report.Failure("Did not receive expected feedback of {" + expectedFeedback + "}.");
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        /// <summary>
        /// Adding Assigned Work in the TrainSheet --> Train tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="operation"> Type value e.g. Pickup, Setout and Other</param>
        /// <param name="Opsta"></param>
        /// <param name="PassCount"></param>
        /// <param name="loads"></param>
        /// <param name="empties"></param>
        /// <param name="tons"></param>
        /// <param name="lenght"></param>
        /// <param name="note"></param>
        /// <param name="coal"></param>
        /// <param name="needDateTimeOffset"></param>
        /// <param name="needDateTimeZone"></param>
        /// <param name="completionDateTimeOffset"></param>
        /// <param name="completionDateTimeZone"></param>
        /// <param name="coalPermit"></param>
        /// <param name="coalCarsRecords"></param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void AddAssignedWork_Trainsheet_TimeZoneValidation(
            string trainSeed, string operation, string Opsta, string PassCount, 
            string loads, string empties, string tons, string length, string note, 
            bool coal, int needDateTimeOffset, string needDateTimeZone, 
            int completionDateTimeOffset, string completionDateTimeZone, 
            string coalPermit, string coalCarsRecords, bool useInvalidDaylightTime, 
            string expectedFeedback, bool closeForms, int expectedFeedbackLocation = 0
        ) {
            //Open the trainsheet first and select the Trains tab
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);

            string train_id = NS_TrainID.GetTrainId(trainSeed);
            int retries=0;
            while(!Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo.Exists(0) && retries<3)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo);
                retries++;
            }
            //Select the operation from the dropdown
            if(operation!= "" && Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.SelfInfo.Exists(0))
            {
                operation = operation.ToLower();
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationTextInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                if(operation == "pickup")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.PickupInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else if (operation == "setout")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SetoutInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else if (operation == "other")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.OtherInfo,
                                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationList.SelfInfo);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Operation.OperationText.PressKeys("{TAB}");
                }
                else
                {
                    Report.Failure("Invalid Operation Input" +operation);
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                    return;
                }

            }
            else
            {
                Report.Failure("Please Enter valid value for Operation dropdown or page is not loaded properly.");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the Opsta value and throw error if invalid opsta entered
            if(Opsta!= "")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.OpStaName.PressKeys(Opsta);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.OpStaName.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }
            else
            {
                Report.Failure("Please provide valid value for Opsta field");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the PassCount value and throw error if invalid Pass Count entered
            if (!string.IsNullOrEmpty(PassCount))
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.PassCount.PressKeys(PassCount);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.PassCount.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 2, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }

            //Fill the loads value and throw error if invalid Pass Count entered
            if(!string.IsNullOrEmpty(loads) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Loads.PressKeys(loads);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Loads.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 3, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

            }

            //Fill the Empties value
            if(!string.IsNullOrEmpty(empties) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Empties.PressKeys(empties);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Empties.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 4, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the Tons value
            if(!string.IsNullOrEmpty(tons) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Tons.PressKeys(tons);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Tons.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 5, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the length value
            if(!string.IsNullOrEmpty(length) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys(length);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys("{TAB}");

                if(ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback , expectedFeedback, indexLocation: 6, expectedLocation: expectedFeedbackLocation))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }

            //Fill the note value
            if(!string.IsNullOrEmpty(note))
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Note.Click();

                if(Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.SelfInfo.Exists(0))
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.AddCommentsText.PressKeys(note);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.OkButton.Click();
                }
                else
                {
                    Ranorex.Report.Failure("Add comments window does not exist");
                }

                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Length.PressKeys("{TAB}");
            }

            //Select the checkbox for Coal
            if(coal && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Coal.Click();
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.Coal.PressKeys("{TAB}");
            }

            System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
            System.DateTime needDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(needDateTimeOffset));
            string needDateTimeInput = NS_FormatDateTime_TrainSheet(needDateTime, needDateTimeZone, useInvalidDaylightTime);

            //set need date
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.Click();
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.PressKeys(needDateTimeInput);
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.NeedDate.NeedDateText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            string needDateFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, needDateTime, needDateTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, needDateFeedback, indexLocation: 7, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Need Date Time Zone Input Value: "+ needDateTimeInput.ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;

            }
            
            System.DateTime completionDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(completionDateTimeOffset));
            string completionDateTimeInput = NS_FormatDateTime_TrainSheet(completionDateTime, completionDateTimeZone, useInvalidDaylightTime);

            //set completion date
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.Click();
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.PressKeys(completionDateTimeInput);
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CompletionDate.CompletionDateText.PressKeys("{TAB}");

            //Check if this kicked up some FeedBack
            string compTimeFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, completionDateTime, completionDateTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, compTimeFeedback, indexLocation: 8, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Completion Date Time Zone Input Value: "+ completionDateTimeInput.ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            //Fill the Coal Permit value
            if(!string.IsNullOrEmpty(coalPermit) && operation!= "other")
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CoalPermit.PressKeys(length);
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.AssignedWorkInputRow.CoalPermit.PressKeys("{TAB}");
            }

            if(!string.IsNullOrEmpty(coalCarsRecords) && operation!= "other")
            {
                string[] coalCarsRecordsElements = coalCarsRecords.Split('|');
                int totalCarsRecord = coalCarsRecordsElements.Length;
                if (totalCarsRecord % 2 == 0)
                {
                    for (int i = 0; i < totalCarsRecord; i= i+2)
                    {
                        string coalCar = coalCarsRecordsElements[i];
                        string coalClassification = coalCarsRecordsElements[i+1];
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys(coalCar);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys(coalClassification);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Invalid assigned record lengths present. Assigned work not created.");
                    return;
                }
            }
            
            Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButton.Click();
            retries = 0;
            while (Trainsrepo.Train_Sheet.Feedback.TextValue == "" && retries < 2)
            {
                Ranorex.Delay.Seconds(1);
                retries++;
            }
            
            // No point in using multiple feedback mechanisms inside of one method
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 9, expectedLocation: expectedFeedbackLocation))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            	return;
            }
            else
            {
            	GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo, Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo);
            }
            if(expectedFeedback != "")
            {
            	Ranorex.Report.Failure("Did not receive expected feedback of {" + expectedFeedback + "}.");
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        [UserCodeMethod]
        public static bool validateCurrentConsistSummaryColor_TrainSheet(string type,string opSta, string color, string trainSeed, bool closeForms)
        {
            bool returnValue;
            if(!Trainsrepo.Train_Sheet.SelfInfo.Exists())
            {
                NS_OpenTrainsheet_MainMenu(trainSeed);
            }
            switch(type.ToUpper())
            {
                case "EXCESS DIMENSION":
                    Regex regexedString = new Regex("Excess Dimension: <.*?color:green.*?D<BR>");
                    if (regexedString.IsMatch(PDS_NS.Trackline_Repo.Instance.Trackline_Form_By_Train_Id.TrainObject.Element.GetAttributeValueText("ToolTipText")))
                    {
                        Report.Info("Green color 'D' is shown in front of train Id");
                        returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.ExcessDimension, color, true);
                    }
                    else
                    {
                        Report.Info("Green color 'D' is not shown in front of train Id");
                        returnValue= false;
                    }
                    break;
                case "PLATE SIZE":
                    returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.PlateSize, color, true);
                    break;
                case "HAZMAT TRAIN":
                    returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.Hazmat, color, true);
                    break;

                case "TIH INDICATOR":
                    returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.TIH, color, true);
                    break;

                case "SPEED":
                    returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.Speed, color, true);
                    break;

                case "TC":
                    returnValue= PDS_CORE.Code_Utils.GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.TrainClearanceButton, color, true);
                    break;

                default:
                    Report.Info("Invalid parameter");
                    returnValue= false;
                    break;
            }
            if (closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return returnValue;
        }

        [UserCodeMethod]
        public static void ToggleExcludeFromPlan_TrainSheet(string trainSeed, bool check)
        {
            if(!Trainsrepo.Train_Sheet.SelfInfo.Exists())
            {
                NS_OpenTrainsheet_MainMenu(trainSeed);
            }
            if(check)
            {
                if(Trainsrepo.Train_Sheet.ExcludeFromPlanCheckbox.Checked)
                {
                    Report.Success(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" already Excluded from Plan");
                }
                else
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.ExcludeFromPlanCheckboxInfo,Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo);
                    if(Trainsrepo.Train_Sheet.ExcludeFromPlanCheckbox.Checked)
                    {
                        Report.Success(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" Excluded from Plan");
                    }
                    else
                    {
                        Report.Failure(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" not Excluded from Plan");
                    }
                }
            }
            else
            {
                if(!Trainsrepo.Train_Sheet.ExcludeFromPlanCheckbox.Checked)
                {
                    Report.Success(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" already not Excluded from Plan");
                }
                else
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.ExcludeFromPlanCheckboxInfo,Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo);
                    if(!Trainsrepo.Train_Sheet.ExcludeFromPlanCheckbox.Checked)
                    {
                        Report.Success(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" not Excluded from Plan");
                    }
                    else
                    {
                        Report.Failure(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed) +" Excluded from Plan");
                    }
                }
            }
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
        }

        /// <summary>
        /// Add a _DateTime TimeZon_MovementTab over the UI
        /// <param name="trainSeed"></param>
        /// </summary>
        [UserCodeMethod]
        public static void Add_DateTime_TimeZone_Movement_Tab(string trainSeed, string OpSta, string reportType, string inputTimeZone, bool useInvalidDaylightTime, bool closeForms, string expectedFeedback, int rowNumber = 1, int expectedFeedbackLocation = 0)
        {
            NS_OpenTrainsheetMovement_MainMenu(trainSeed);
            System.DateTime origin = System.DateTime.Now;
            int movementTabel = Trainsrepo.Train_Sheet.Movement.MovementTable.Self.Rows.Count;
            string movementReportType;
            string movemetOpSta;
            bool datafound = false;
            int rowFound = 0;
            if(movementTabel>=1)
            {
                for (int i=0; i<=movementTabel; i++)
                {
                    Trainsrepo.MovementIndex = i.ToString();
                    movemetOpSta = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.OpSta.GetAttributeValue<string>("Text").Trim();
                    movementReportType = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ReportTypeText.GetAttributeValue<string>("Text").Trim();
                    if((movemetOpSta.ToLower() == OpSta.ToLower()) && (movementReportType.ToLower() == reportType.ToLower()))
                    {
                        rowFound++;
                        if(rowFound == rowNumber)
                        {
                            datafound = true;
                            string ReportTime = NS_FormatDateTime_TrainSheet(origin, inputTimeZone, useInvalidDaylightTime);
                            string appendedFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, origin, inputTimeZone, useInvalidDaylightTime);
                            Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ReportTime.ReportTimeText.Click();
                            Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ToFromTimeFieldComboBoxEditor.Element.SetAttributeValue("Text", ReportTime);
                            Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ReportTime.ReportTimeText.PressKeys("{TAB}");
                            
                            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, appendedFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
                            {
                                Trainsrepo.Train_Sheet.Movement.RefreshButton.Click();
                                if (closeForms)
                                {
                                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                                }
                                return;
                            }
                            Trainsrepo.Train_Sheet.Movement.ApplyButton.Click();
                            break;
                        }
                    }

                }
                

                if(datafound)
                {
                    Ranorex.Report.Success("Movement record with expected data found");
                } else {
                    Ranorex.Report.Failure("No Movement record with expected data found");
                }
            }
            else
            {
                Ranorex.Report.Failure("Movement records not found in Movement Tab");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback, indexLocation: 2, expectedLocation: expectedFeedbackLocation))
            {
                Trainsrepo.Train_Sheet.Movement.RefreshButton.Click();
            }
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }

        }
        

        /// <summary>
        /// Validate FindTrainOnTrackline Option in Context Menu in Train Status Summary
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="expRemoveTrainOption">Input If it is True ,remove train option is enabled ,else it is disabled</param>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_ValidateFindTrainOnTracklineEnabled_TSS(string trainSeed, bool enabled, bool closeForm)
        {
            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);

            Trainsrepo.TrainId = trainId;

            if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                   Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);

                bool foundEnabled = Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.FindTrainOnTrackline.Enabled;
                if(enabled == foundEnabled)
                {
                    Ranorex.Report.Success("Expected FindTrainOnTrackline button enable status to be {"+enabled+"} and found {"+foundEnabled+"}");
                }
                else
                {
                    Ranorex.Report.Failure("Expected FindTrainOnTrackline enable status to be {"+enabled+"} but found {"+foundEnabled+"}");
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Id {"+trainId+"} does not exist");
            }
            if (closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
            }
            return;
        }
        /// <summary>
        /// Open Bulletin Relay Form in TrainStatus Summary if not already open
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_OpenBulletinItemRelayForm_TrainStatusSummary(string trainSeed, bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (!Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            {
                // Open train status summary window if not already open
                NS_OpenTrainStatusSummary_MainMenu();
                
                Trainsrepo.TrainId = trainId;
                
                if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                       Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                    
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenBulletinRelayInfo,
                                                                                  Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
                    if (Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Success("Bulletin Item Relay Form Opened for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Failure("Bulletin Item Relay Form Failed to open for Train {"+trainId+"}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
                }
            } else {
                Ranorex.Report.Info("Bulletin Item Relay Form already open");
            }
            if (closeForm)
            {
            	if (Bulletinsrepo.Bulletin_Item_Relay.SelfInfo.Exists(0))
            	{
            		PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Bulletinsrepo.Bulletin_Item_Relay.WindowControls.CloseInfo,Bulletinsrepo.Bulletin_Item_Relay.SelfInfo);
            	}
                if (Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                {
                	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
                }
            }
            return;
        }
        /// <summary>
        /// Opens Train Clearance from Train Status Summary if not already open
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_OpenTrainClearance_TrainStatusSummary(string trainSeed, bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                // Open train status summary window if not already open
                NS_OpenTrainStatusSummary_MainMenu();
                
                Trainsrepo.TrainId = trainId;
                
                if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                       Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                    
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenTrainClearanceInfo,
                                                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
                    if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Success("Train Clearance Form Opened for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Failure("Train Clearance Form Failed to open for Train {"+trainId+"}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
                }
            } else {
                Ranorex.Report.Info("Train Clearance Form already open");
            }
            if (closeForm)
            {
            	if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                {
                    //PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.AdhocButtonInfo,TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
                    TrainClearancerepo.Train_Clearance.WindowControls.Close.Click();
                }
            }
            return;
        }
        /// <summary>
        /// Opens Update Tracking in TrainStatus Summary if not already open
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_OpenUpdateTracking_TrainStatusSummary(string trainSeed,bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (!Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
            {
                // Open train status summary window if not already open
                NS_OpenTrainStatusSummary_MainMenu();
                
                Trainsrepo.TrainId = trainId;
                
                if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                       Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                    
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenUpdateTrackingInfo,
                                                                                  Trainsrepo.Update_Tracking.SelfInfo);
                    if (Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Success("Update Tracking Form Opened for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Failure("Update Tracking Form Failed to open for Train {"+trainId+"}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
                }
            } else {
                Ranorex.Report.Info("Update Tracking Form already open");
            }
            if (closeForm)
            {
            	if (Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Update_Tracking.WindowControls.CloseInfo,Trainsrepo.Update_Tracking.SelfInfo);
                }
            	
                if (Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
                }
            }
            return;
        }
        
        /// <summary>
        /// Open Terminate Short form if not already open
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeForm">ex:closes the Train Status Summary</param>
        [UserCodeMethod]
        public static void NS_OpenTerminateShort_TrainStatusSummary(string trainSeed,bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (!Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
            {
                // Open train status summary window if not already open
                NS_OpenTrainStatusSummary_MainMenu();
                
                Trainsrepo.TrainId = trainId;
                
                if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                       Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                    
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenTerminateShortInfo,
                                                                                  Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                    if (Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Success("Terminate Short Form Opened for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Failure("Terminate Short Form Failed to open for Train {"+trainId+"}");
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
                }
            } else {
                Ranorex.Report.Info("Terminate Short Form already open");
            }
            if (closeForm)
            {
                if (Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                }
                if (Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
                }
            }
            return;
        }

        /// <summary>
        /// Set the Train_Trace_Mode for Train in TrainStatus Summary
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="ModeName">ex:if Mode is ON or OFF</param>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_TrainTraceMode_TSS(string trainSeed ,bool tracemodeOn,bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);

            // Open train status summary window
            NS_OpenTrainStatusSummary_MainMenu();
            Trainsrepo.TrainId = trainId;
            if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
            {
                PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo, Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                if (tracemodeOn)
                {
                    if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.TrainTraceOnInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.TrainTraceOnInfo,Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                        Ranorex.Report.Success("Train Trace On Mode has been Set for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Error("Train Trace On not found in menu");
                    }
                }
                else
                {
                    if (Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.TrainTraceOffInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.TrainTraceOffInfo,Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);
                        Ranorex.Report.Success("Train Trace Off Mode has been Set for Train {"+trainId+"}");
                    } else {
                        Ranorex.Report.Error("Train Trace Off not found in menu");
                    }
                }
                
            }
            else
            {
                Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
            }
            
            if (closeForm)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
            }
            return;
        }

        
        /// <summary>
        /// Verify original trip plan activity details exists or not.
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Opsta Location (ex: 240H)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityExists(string trainSeed, string activityType, string opsta, bool validateExist, bool closeForms)
        {
            //Open TrainSheet
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
            
            bool resultFound = false;
            for (int i=0; i <activity; i++)
            {
            	Trainsrepo.TripPlanIndex = i.ToString();
            	
            	if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) && Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LocationInfo.Exists(0))
            	{
            		string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
            		
            		if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
            		{
            			if(opsta != "")
            			{
            				string currentLocation = "";
            				if(!String.IsNullOrEmpty(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("Text")))
            				{
            					currentLocation = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("StationId");
            				}
            				
            				if(currentLocation.Equals(opsta, StringComparison.OrdinalIgnoreCase))
            				{
            					Report.Info("Actual activity type " +activityList+ " " +currentLocation+ " found " +activityType+ " " +opsta);
            					resultFound = true;
            					break;
            				}
            			}
            			else
            			{
            				resultFound = true;
            				break;
            			}
            		}
            	}
            }
            
            if(resultFound == validateExist)
            {
                Ranorex.Report.Success("Activity type{"+activityType+"} should exist is {" +validateExist+ "}, and actually it is present {" +resultFound+ "}.");
            }
            else
            {
                Ranorex.Report.Failure("Activity type{"+activityType+"} should exist is {" +validateExist+ "}, but actually it is present {" +resultFound+ "}.");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Closes the  Update Tracking Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseUpdateTracking()
        {
            if(Trainsrepo.Update_Tracking.SelfInfo.Exists())
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Update_Tracking.CancelButtonInfo,Trainsrepo.Update_Tracking.SelfInfo);
                Ranorex.Report.Success("Update Tracking Form is closed successfully");
            }
            else
            {
                Ranorex.Report.Failure("Update tracking form is not opened ");
            }
            return;
        }
        /// <summary>
        /// Closes the  Terminate Short Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseTerminateShort_TrainStatusSummary()
        {
            if (Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
                
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.WindowControls.CloseInfo,
                                                                                      Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                Ranorex.Report.Success("Terminate Short Form is closed successfully");
            }
            else
            {
                Ranorex.Report.Failure("Terminate Short form is not opened ");
            }
            return;
        }
        
        /// Validating Time zone backflow ABF_TEC_CREW table in ADMS
        /// <param name="trainSeed">Input: trainSeed to get trainSymbol and originDate</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTimeZoneAssignedWorkTable(string trainSeed)
        {
            string trainKey = NS_TrainMiscellaneous.GetTrainKeyFromADMS(trainSeed);
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
            DataTable messageBackflow;
            if(!string.IsNullOrEmpty(trainKey))
            {
                //Get Time zone from ABF_TEC_CREW table in ADMS
                messageBackflow = Oracle.Code_Utils.ADMSEnvironment.GetAssignedWorkBackflow_ADMS(trainKey);
                NS_OracleTable tbl = new NS_OracleTable(messageBackflow);

                if (tbl.GetRowCount() == 0)
                {
                    Ranorex.Report.Failure(string.Format("There is no record for assigned work given by the following train key: {0}", trainKey));
                }
                else
                {
                    string result_completionDate = tbl.GetCellValue("COMPLETION_DATE_TIMEZONE");
                    string result_needDate = tbl.GetCellValue("NEED_DATE_TIMEZONE");

                    if((result_completionDate == "EDT" || result_completionDate == "EST" || result_completionDate == "CDT" || result_completionDate == "CST") && (result_needDate == "EDT" || result_needDate == "EST" || result_needDate == "CDT" || result_needDate == "CST"))
                    {
                        Ranorex.Report.Success("Time zone records logged in ADMS as Expected for Need Date Time ZOne: '"+result_needDate+"'  Completion Date Time Zone: '"+result_completionDate+"' ");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Expected entry not found in curent result.");
                    }


                }
            }
            else
            {
                Ranorex.Report.Failure("Unable to find train with Train Symbol: " +trainId);
                return;
            }
        }
        
        /// <summary>
        /// Update TripPlan Time in the TrainSheet --> TripPlan tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="activity"> activity value e.g. Terminate, Originate</param>
        /// <param name="earliestArrivalTimeZone"></param>
        /// <param name="earliestArrivalTimeOffset"></param>
        /// <param name="latestArrivalTimeZone"></param>
        /// <param name="latestArrivalTimeOffset"></param>
        /// <param name="earliestDepartTimeZone"></param>
        /// <param name="earliestDepartTimeOffset"></param>
        /// <param name="daylightSaving"></param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void NS_UpdateTripPlanTime(string trainSeed, string activity, string earliestArrivalTimeZone, string earliestArrivalTimeOffset, string latestArrivalTimeZone, string latestArrivalTimeOffset, string earliestDepartTimeZone, string earliestDepartTimeOffset, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            Trainsrepo.TripPlanActivity = activity;
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
            bool activitySelected = (bool)Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Element.GetAttributeValue("Selected");
            
            int retry = 0;
            while (!activitySelected && retry < 3)
            {
                Ranorex.Delay.Milliseconds(100);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
                activitySelected = (bool)Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Element.GetAttributeValue("Selected");
                retry++;
                
            }
            
            System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
            System.DateTime earliestArrivalDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(earliestArrivalTimeOffset));
            
            string earliestArrivalDateTimeInput = NS_FormatDateTime_TrainSheet(earliestArrivalDateTime, earliestArrivalTimeZone);
            
            //Set Earliest Arrival Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys(earliestArrivalDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys("{Tab}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Earliest Arrival Date Time Zone Input Value: "+ earliestArrivalDateTimeInput);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                Trainsrepo.Train_Sheet.TripPlan.ResetButton.Click();
                if(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                                                                      Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo);
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            System.DateTime latestArrivalDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(latestArrivalTimeOffset));
            string latestArrivalDateTimeInput = NS_FormatDateTime_TrainSheet(latestArrivalDateTime, latestArrivalTimeZone);
            
            //Set Latest Arrival Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys(latestArrivalDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys("{Tab}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Latest Arrival Date Time Zone Input Value: "+ earliestArrivalDateTimeInput);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                Trainsrepo.Train_Sheet.TripPlan.ResetButton.Click();
                if(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                                                                      Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo);
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            System.DateTime earliestDepartDateTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(earliestDepartTimeOffset));
            string earliestDepartDateTimeInput = NS_FormatDateTime_TrainSheet(earliestDepartDateTime, earliestDepartTimeZone);
            
            //Set Earliest Depart Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys(earliestDepartDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys("{Tab}");

            //Check if this kicked up some FeedBack
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Earliest Depart Date Time Zone Input Value: "+ earliestDepartDateTimeInput);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                Trainsrepo.Train_Sheet.TripPlan.ResetButton.Click();
                if(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                                                                      Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo);
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                Ranorex.Report.Info("No Feedback message received. successfully modified.");
            }
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        /// <summary>
        /// Update Earliest Depart Time in the TrainSheet and validate if any Feedback --> TripPlan tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="activity"> activity value e.g. Terminate, Originate</param>
        /// <param name="earliestDepartTimeZone">Input: earliestDepartTimeZone</param>
        /// <param name="earliestDepartTimeOffset">Input: earliestDepartTimeOffset</param>
        /// <param name="useInvalidDaylightTime">Input: useInvalidDaylightTime</param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        /// <param name="expectedFeedbackLocation">Input: expectedFeedbackLocation</param>
        [UserCodeMethod]
        public static void NS_UpdateEarliestDepartTime_TripPlan_TimeZoneValidation(string trainSeed, string activity, string earliestDepartTimeZone, string earliestDepartTimeOffset, bool useInvalidDaylightTime, string expectedFeedback, bool closeForms, int expectedFeedbackLocation = 0)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            Trainsrepo.TripPlanActivity = activity;
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
            bool activitySelected = (bool)Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Element.GetAttributeValue("Selected");
            
            int retry = 0;
            while (!activitySelected && retry < 3)
            {
                Ranorex.Delay.Milliseconds(100);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
                activitySelected = (bool)Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Element.GetAttributeValue("Selected");
                retry++;
                
            }

            GeneralUtilities.ClickAndWaitForWithRetry(
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepartInfo, 
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.CalendarComboBoxInfo
            );

            string currentEdt = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.CalendarComboBox.GetAttributeValue<string>("Text");
            System.DateTime currentEdtDateTime = NS_Time.ConvertTimeInputToDateTime(currentEdt);
            
            string finalTimeInput = NS_FormatDateTime_TrainSheet(currentEdtDateTime, earliestDepartTimeZone, useInvalidDaylightTime, earliestDepartTimeOffset);

            //Set Earliest Depart Time
            Report.Info("Entering new EDT time as:-"+finalTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys(finalTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys("{Tab}");
            
            //Check if this kicked up some FeedBack
            string edtFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, finalTimeInput, earliestDepartTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, edtFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Earliest Depart Date Time Zone Input Value: "+ finalTimeInput);
                 
                GeneralUtilities.ClickAndWaitForWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.ResetButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );
                
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
             
            if (closeForms)
            {
                NS_CloseTrainsheet();
            }

        }
        
        /// <summary>
        /// Update TripPlan Time in the TrainSheet --> TripPlan tab
        /// </summary>
        /// <param name="trainSeed">train seed to identify the train</param>
        /// <param name="activity"> activity value e.g. Terminate, Originate</param>
        /// <param name="earliestArrivalTimeZone"></param>
        /// <param name="earliestArrivalTimeOffset"></param>
        /// <param name="latestArrivalTimeZone"></param>
        /// <param name="latestArrivalTimeOffset"></param>
        /// <param name="earliestDepartTimeZone"></param>
        /// <param name="earliestDepartTimeOffset"></param>
        /// <param name="useInvalidDaylightTime"></param>
        /// <param name="expectedFeedback">Feedback to be compared with</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void NS_UpdateTripPlanTime_TimeZoneValidation(string trainSeed, string activity, string earliestArrivalTimeZone, string earliestArrivalTimeOffset, string latestArrivalTimeZone, string latestArrivalTimeOffset, string earliestDepartTimeZone, string earliestDepartTimeOffset,  bool useInvalidDaylightTime, string expectedFeedback, bool closeForms, int expectedFeedbackLocation = 0)
        {
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            Trainsrepo.TripPlanActivity = activity;
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
            bool activitySelected = (bool) Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Element.GetAttributeValue("Selected");
            
            int retry = 0;
            while (!activitySelected && retry < 3)
            {
                Ranorex.Delay.Milliseconds(100);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByActivity.Activity.Click();
                retry++;
                
            }
            
            // If values exist for earliest arrival or latest arrival, then delete.
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys("{Delete}");
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys("{Tab}");

            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys("{Delete}");
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys("{Tab}");
            
            
            System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
            string earliestArrivalDateTimeInput = NS_FormatDateTime_TrainSheet(trainOriginDateTime, earliestArrivalTimeZone, useInvalidDaylightTime, earliestArrivalTimeOffset);

            //Set Earliest Arrival Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys(earliestArrivalDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestArrival.PressKeys("{Tab}");

            //Check if this kicked up some FeedBack
            string eatFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, earliestArrivalDateTimeInput, earliestArrivalTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, eatFeedback, indexLocation: 1, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Earliest Arrival Date Time Zone Input Value: "+ earliestArrivalDateTimeInput);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                GeneralUtilities.ClickAndWaitForWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.ResetButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );
                
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            string latestArrivalDateTimeInput = NS_FormatDateTime_TrainSheet(trainOriginDateTime, latestArrivalTimeZone, useInvalidDaylightTime, latestArrivalTimeOffset);
            
            //Set Latest Arrival Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys(latestArrivalDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LatestArrival.PressKeys("{Tab}");

            //Check if this kicked up some FeedBack
            string latestArrivalFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, latestArrivalDateTimeInput, latestArrivalTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, latestArrivalFeedback, indexLocation: 2, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Latest Arrival Date Time Zone Input Value: "+ earliestArrivalDateTimeInput);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                GeneralUtilities.ClickAndWaitForWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.ResetButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );
                
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            string earliestDepartDateTimeInput = NS_FormatDateTime_TrainSheet(trainOriginDateTime, earliestDepartTimeZone, useInvalidDaylightTime, earliestDepartTimeOffset);
            
            //Set Earliest Depart Time
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.Click();
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys(earliestDepartDateTimeInput);
            Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.EarliestDepart.PressKeys("{Tab}");
            
            //Check if this kicked up some FeedBack
            string edtFeedback = NS_Time.AppendTimeZoneToFeedback(expectedFeedback, earliestDepartDateTimeInput, earliestDepartTimeZone, useInvalidDaylightTime);
            if (ValidateFeedbackExists(Trainsrepo.Train_Sheet.Feedback, edtFeedback, indexLocation: 3, expectedLocation: expectedFeedbackLocation))
            {
                Ranorex.Report.Info("Earliest Depart Date Time Zone Input Value: "+ earliestDepartDateTimeInput);
                 
                GeneralUtilities.ClickAndWaitForWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.ResetButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.YesButtonInfo,
                    Trainsrepo.Train_Sheet.TripPlan.Precision_Dispatch_System_Reset_Changes.SelfInfo
                );
                
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
                Ranorex.Report.Success("No Feedback message received. successfully modified.");
            } else {
                Report.Failure("Error message has appeared, or no error message has appeared where expected.");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self);
                
            }
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        
        /// <summary>
        /// Modify and Validate fields  - Trip Plan
        /// </summary>
        /// <param name="trainSeed">trainseed (Ex: NST001)</param>
        /// <param name="location">Input: opsta location (Ex: 1186)</param>
        ///  <param name="dwell">Input: dwell (ex: 00:56)</param>
        ///  <param name="fromActivityMP">Input: fromActivityMP (Ex: S188)</param>
        ///  <param name="fromactivityDistrict">Input: fromactivityDistrict (Ex: Savannah)</param>
        ///  <param name="fromactivityTracktype">Input: fromactivityTracktype (Ex: MAIN 1)</param>
        ///  <param name="toActivityMP">Input: fromActivity (Ex: S188)</param>
        ///  <param name="expectedFeedback">Input: Feedback error message</param>
        ///  <param name="optionalRowNo">Input:Row number (Ex: 1 or 2 etc)</param>
        /// <param name="reason">Input: reason (Ex:Due to opsta change etc)</param>
        /// <param name="autorouteETD">Input:autorouteETD (Ex:True or False etc)</param>
        /// <param name="offTrack">Input:offTrack (Ex:True or False etc)</param>
        /// <param name="closeForms">True or False to close the forms</param>
        [UserCodeMethod]
        public static void NS_ModifyandValidateFieldEntryErrors_AnyActivity(string trainSeed, string activityType, string location, string dwell, string fromActivityMP, string toActivityMP, string expectedFeedback,
                                                                            string optionalRowNo, string fromactivityDistrict, string fromactivityTrackType, string reason, string autorouteETD, string offTrack, bool closeForm = true)
        {
            //Open TrainSheet
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            int activityCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activityCount.ToString()));
            if(activityCount == 0)
            {
                Ranorex.Report.Failure("Trip Plan doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
                return;
            }
            
            if(optionalRowNo != "")
            {
                Ranorex.Report.Info("Setting to Row number " +optionalRowNo);
                Trainsrepo.TripPlanIndex = optionalRowNo;
            }
            else
            {
                //Move to final row
                Trainsrepo.TripPlanIndex = (activityCount - 1).ToString();
            }
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
            
            if(location != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.PressKeys(location);
                Ranorex.Report.Info("Updated location is " +location);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.PressKeys("{TAB}");
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(dwell != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.PressKeys(dwell);
                Ranorex.Report.Info("Dwell modified value is " +dwell);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.PressKeys("{TAB}");
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(offTrack != "")
            {
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.OffTrack.Text != offTrack)
                {
                    // Check/Uncheck OffTrack checkbox
                    Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.OffTrack.Click();
                    if (Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.OffTrack.Text != offTrack)
                    {
                        Ranorex.Report.Failure("Could not change OffTrack to checked");
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("OffTrack Checkbox current status is " +Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.OffTrack.Text);
                }
                else
                {
                    Ranorex.Report.Info("OffTrack Checkbox is in expected state");
                }
            }
            
            if(toActivityMP != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.PressKeys(toActivityMP);
                Ranorex.Report.Info("Updated ToActivity mile post is " +toActivityMP);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.PressKeys("{TAB}");
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(fromactivityDistrict != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrictText.Click();
                Trainsrepo.DistrictName = fromactivityDistrict;
                if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityDistrictList.FromActivityDistrictListItemByDistrictInfo.Exists(0))
                {
                    Ranorex.Report.Error("Intended From Activity District of {" + fromactivityDistrict +"} could need be found in the district dropdown");
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityDistrictList.FromActivityDistrictListItemByDistrict.Click();
                Ranorex.Report.Info("Successfully selected district " + fromactivityDistrict);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(fromActivityMP != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.PressKeys(fromActivityMP);
                Ranorex.Report.Info("Updated FromActivity mile post is " +fromActivityMP);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.PressKeys("{TAB}");
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(fromactivityTrackType != "")
            {
                Trainsrepo.TrackName = fromactivityTrackType;
                //Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackText.Click();
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackTextInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackNameInfo);
                if (!Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackNameInfo.Exists(0))
                {
                    Ranorex.Report.Error("Intended From Activity Track of {" + fromactivityTrackType + "} could need be found in the Track dropdown");
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                //Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackName.Click();
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackNameInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityTrack.FromActivityTrackList.FromActivityTrackListItemByTrackNameInfo);
                Ranorex.Report.Info("Successfully selected track type " + fromactivityTrackType);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if(autorouteETD != "")
            {
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.AutorouteAtETDCheckbox.Text == "false")
                {
                    //Enable autoRouteETD checkbox
                    Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.AutorouteAtETDCheckbox.Click();
                    if (Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.AutorouteAtETDCheckbox.Text == "false")
                    {
                        Ranorex.Report.Failure("Could not change Autoroute At ETD Checkbox to checked");
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Checkbox is in selected state");
                }
                else
                {
                    //Uncheck autoRouteETD checkbox
                    Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.AutorouteAtETDCheckbox.Click();
                    if (Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.AutorouteAtETDCheckbox.Text == "true")
                    {
                        Ranorex.Report.Failure("Could not change Autoroute At ETD Checkbox to unchecked");
                        if (closeForm)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                    Ranorex.Report.Info("Checkbox is in unselected state");
                }
            }
            
            if(reason != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ReasonText.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ReasonText.PressKeys(reason);
                Ranorex.Report.Info("Train stop changed reason is " +reason);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ReasonText.PressKeys("{TAB}");
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            
            //Click on apply button
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
            
            if (Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") == "" && expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected feedback of {" + expectedFeedback + "}");
            }
            
            if(Miscellaneousrepo.Alert_Event_Popup.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Popup.AcknowledgeButtonInfo, Miscellaneousrepo.Alert_Event_Popup.SelfInfo);
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
            
        }
        
        
        /// <summary>
        /// Validate Trip plan acitivty menu cell menu items
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="activityType">Input:activityType (Ex: WayPoint or TrainStop etc)</param>
        /// <param name="move">Input:move (Ex: True or false)</param>
        /// <param name="insertMove">Input:insertMove (Ex: True or false)</param>
        /// <param name="deleteRow">Input:deleteRow (Ex: True or false)</param>
        /// <param name="undeleteRow">Input:undeleteRow (Ex: True or false)</param>
        /// <param name="createWaypoint">Input:createWaypoint (Ex: True or false)</param>
        /// <param name="park">Input:park (Ex: True or false)</param>
        /// <param name="unpark">Input:unpark (Ex: True or false)</param>
        /// <param name="createRequiredInspection">Input:createRequiredInspection (Ex: True or false)</param>
        /// <param name="createFuelEngines">Input:createFuelEngines (Ex: True or false)</param>
        /// <param name="createPassengerStop">Input:createPassengerStop (Ex: True or false)</param>
        /// <param name="createTrainstop">Input:createTrainstop (Ex: True or false)</param>
        /// <param name="createTraverserailroad">Input:createTraverserailroad (Ex: True or false)</param>
        /// <param name="createTurnpoint">Input:createTurnpoint (Ex: True or false)</param>
        /// <param name="createOverlappedActivity">Input:createOverlappedActivity (Ex: True or false)</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanMenuCell(string trainSeed, string activityType, string move, string insertMove, string deleteRow, string undeleteRow, string createWaypoint, string park, string unpark,
                                                       string createRequiredInspection, string createFuelEngines, string createPassengerStop, string createTrainstop, string createTraverserailroad, string createTurnpoint, string createOverlappedActivity)
        {
            //Open TrainSheet from main menu
            NS_OpenTrainsheet_MainMenu(trainSeed);
            
            GeneralUtilities.CheckWaitState(2);
            int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
            
            for (int i=0; i <activity; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                
                Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellTable.Self.Click(WinForms.MouseButtons.Right);
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.SelfInfo.Exists(0))
                {
                    string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
                    
                    if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                    {
                        bool[] enableActStatusMenuCell = new bool[]
                        {Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.Move.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.InsertMove.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.DeleteRow.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.UndeleteRow.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateWaypoint.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.Park.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.UnPark.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateRequiredInspection.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateFuelEngines.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreatePassengerStop.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTrainStop.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTraverseForeignRailroad.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTurnPoint.Enabled,
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivity.Enabled};

                        string[] enableExpStatusMenuCell = new string[]
                        {move, insertMove, deleteRow, undeleteRow, createWaypoint,
                            park, unpark, createRequiredInspection, createFuelEngines, createPassengerStop,
                            createTrainstop, createTraverserailroad, createTurnpoint, createOverlappedActivity};
                        
                        for(int j = 0; j < enableActStatusMenuCell.Length; j++)
                        {
                            if(enableExpStatusMenuCell[j].ToString() != "")
                            {
                                if(enableActStatusMenuCell[j] == bool.Parse(enableExpStatusMenuCell[j]))
                                {
                                    Ranorex.Report.Success("Activity type: " +activityList+ " " + (j + 1) +  " enable status is expected to be '" + enableExpStatusMenuCell[j] + "' and found '" + enableActStatusMenuCell[j] + "'.");
                                }
                                else
                                {
                                    Ranorex.Report.Failure("Activity type: " +activityList+ " "  + (j + 1) +  " enable status is expected to be '" +enableExpStatusMenuCell[j]+ "' but found '" + enableActStatusMenuCell[j] + "'.");
                                }
                            }
                        }
                    }
                }
            }
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
        }
        
        
        /// <summary>
        /// Add any activity type in trip plan - Train Sheet
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed (Ex: NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "TrainStop' or 'WayPoint' etc)</param>
        /// <param name="opsta">Input:opsta (Ex: 1186)</param>
        /// <param name="dwell">Input: dwell (ex: 00:56)</param>
        /// <param name="fromActivityMP">Input: fromActivityMP (Ex: S188)</param>
        /// <param name="toActivityMP">Input: toActivityMP (Ex: S188)</param>
        /// <param name="expectedFeedback">Input:feedback message</param>
        /// <param name="optionalRowNo">Input:Row number (Ex: 1 or 2 etc)</param>
        /// <param name="overlapActivity">Input:Activity Type via Create overlapped activity (Ex:'TrainStop' or 'WayPoint' etc)</param>
        [UserCodeMethod]
        public static void NS_AddActivityTypeByRow_TripPlan(string trainSeed, string activityType, string opsta, string dwell, string fromActivityMP, string toActivityMP, string expectedFeedback, string optionalRowNo, string overlapActivity)
        {
            //Open TrainSheet from main menu
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            GeneralUtilities.CheckWaitState(2);
            int activityCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activityCount.ToString()));
            if(activityCount == 0)
            {
                Ranorex.Report.Error("Trip Plan doesn't exist");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
                return;
            }
            
            if(optionalRowNo != "")
            {
                
                Trainsrepo.TripPlanIndex = optionalRowNo;
            }
            else
            {
                //Move to final row
                //TODO BE CAREFUL, if your terminate activity is in another district, this will default to that little banner with the district name instead
                Trainsrepo.TripPlanIndex = (activityCount - 1).ToString();
            }
            
            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
            GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCellInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.SelfInfo);
            
            if(Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.SelfInfo.Exists(0))
            {
                if(activityType.ToLower() == "overlappedactivity")
                {
                    //Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivity.Click();
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.SelfInfo);
                    
                    switch(overlapActivity.ToLower())
                    {
                        case "turnpoint":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreateTurnPoint.Click();
                            break;
                            
                        case "requiredinspection":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreateRequiredInspection.Click();
                            break;
                            
                        case "fuelengines":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreateFuelEngines.Click();
                            break;
                            
                        case "passengerstop":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreatePassengerStop.Click();
                            break;
                            
                        case "traverseforeignrailroad":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreateTaverseForeignRailRoad.Click();
                            break;
                            
                        case "waypoint":
                            if(!Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateOverlappedActivityMenu.CreateWaypointInfo.Exists(0))
                            {
                                Ranorex.Report.Info("Waypoint option is not available under Create overlapped activity menu");
                                return;
                            }
                            break;
                        default:
                            Ranorex.Report.Info(string.Format("Overlap Activity type '{0}' is not valid", overlapActivity.ToLower()));
                            break;
                    }
                }
                else
                {
                    switch (activityType.ToLower())
                    {
                        case "waypoint":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateWaypoint.Click();
                            break;
                            
                        case "trainstop":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTrainStop.Click();
                            break;
                            
                        case "requiredinspection":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateRequiredInspection.Click();
                            break;
                            
                        case "fuelengines":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateFuelEngines.Click();
                            break;
                            
                        case "passengerstop":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreatePassengerStop.Click();
                            break;
                            
                        case "traverserailroad":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTraverseForeignRailroad.Click();
                            break;
                            
                        case "turnpoint":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.CreateTurnPoint.Click();
                            break;
                            
                        case "park":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.Park.Click();
                            break;
                            
                        case "unpark":
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.UnPark.Click();
                            break;
                            
                        default:
                            Ranorex.Report.Info(string.Format("Activity type '{0}' is not valid", activityType.ToLower()));
                            break;
                    }
                }
            }
            
            string actFeedback = Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").Trim();
            if( actFeedback!= "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                return;
            }
            
            if(opsta != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.PressKeys(opsta);
                Ranorex.Report.Info("Updated location is " +opsta);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.PressKeys("{TAB}");
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    return;
                }
            }
            
            if(dwell != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.PressKeys(dwell);
                Ranorex.Report.Info("Dwell modified value is " +dwell);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.PressKeys("{TAB}");
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    return;
                }
            }
            
            if(toActivityMP != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.PressKeys(toActivityMP);
                Ranorex.Report.Info("Updated ToActivity mile post is " +toActivityMP);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ToActivityDistrict.ToActivityMilepost.PressKeys("{TAB}");
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    return;
                }
            }
            
            if(fromActivityMP != "")
            {
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.Click();
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.PressKeys(fromActivityMP);
                Ranorex.Report.Info("Updated FromActivity mile post is " +fromActivityMP);
                Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.FromActivityDistrict.FromActivityMilepost.PressKeys("{TAB}");
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                if(Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    return;
                }
            }
            
            if(expectedFeedback == "")
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
                if(Miscellaneousrepo.Alert_Event_Popup.SelfInfo.Exists(0))
                {
                    Miscellaneousrepo.Alert_Event_Popup.AcknowledgeButton.Click();
                }
                //Click on Ok button
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            else
            {
                CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback);
                //Click on cancel button
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        
        /// <summary>
        /// Delete any activityType on TripPlan tab - Train Sheet
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed (Ex: NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "WayPoint' or 'TrainStop' etc)</param>
        /// <param name="opsta">Input:Opsta Location (Ex: 1186)</param>
        [UserCodeMethod]
        public static void NS_DeleteActivity_TripPlan(string trainSeed, string activityType, string opsta)
        {
            //Open TrainSheet from main menu
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
            
            bool resultFound = false;
            for(int i=0; i<activity; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
                Ranorex.Report.Info(activityList);
                
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) && Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LocationInfo.Exists(0))
                {
                    if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                    {
                        string currentLocation = "";
                        if(!String.IsNullOrEmpty(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("Text")))
                        {
                            currentLocation = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("StationId");
                        }
                        
                        if(currentLocation.Equals(opsta))
                        {
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
                            GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCellInfo, Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.SelfInfo);
                            Trainsrepo.Train_Sheet.TripPlan.TripPlanMenuCellMenu.DeleteRow.Click();
                            Ranorex.Report.Info("Deleted Activity type is  " +activityList+ " " +currentLocation);
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo,Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
                            Delay.Milliseconds(500);
                            if(Miscellaneousrepo.Alert_Event_Popup.SelfInfo.Exists(0))
                            {
                                Miscellaneousrepo.Alert_Event_Popup.AcknowledgeButton.Click();
                            }
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                            resultFound = true;
                            return;
                        }
                    }
                }
                if(!resultFound)
                {
                    Report.Info("Activity type has not listed");
                }
            }
        }


        /// <summary>
        /// validate Assigned Work By Opsta
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="operation"></param>
        /// <param name="stations"></param>
        /// <param name="PassCount"></param>
        /// <param name="loads"></param>
        /// <param name="empties"></param>
        /// <param name="tons"></param>
        /// <param name="length"></param>
        /// <param name="closeForms"></param>
        /// <param name="verifyOperation"></param>
        /// <param name="verifyPassCount"></param>
        /// <param name="verifyConsistChange"></param>
        [UserCodeMethod]
        public static void validateAssignedWorkByOpsta(string trainSeed, string operation, string stations, string PassCount, string loads, string empties, string tons,
                                                       string length, string optStatus, bool closeForms, bool verifyOperation, bool verifyPassCount, bool verifyConsistChange)
        {
            //Open the trainsheet first and select the Trains tab
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);

            string train_id = NS_TrainID.GetTrainId(trainSeed);
            int retries=0;
            StringBuilder successResulttxt=new StringBuilder();
            StringBuilder failResulttxt=new StringBuilder();
            string[] station = stations.Split('|');
            for(int i=0;i<station.Length;i++)
            {
                successResulttxt.Clear();
                failResulttxt.Clear();
                Trainsrepo.AssignedWorkOpSta=station[i];
                while(!Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.SelfInfo.Exists(0) && retries<3)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo,
                                                              Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.SelfInfo);
                    retries++;
                }
                if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.OpStaNameInfo.Exists())
                {
                	if(!string.IsNullOrEmpty(optStatus))
                	{
                		string  status = Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Status.GetAttributeValue<string>("Text");
                		if(status.Equals(optStatus))
                		{
                			successResulttxt.Append(" Status = "+optStatus);
                		}
                		else
                		{
                			failResulttxt.Append(" Status = "+optStatus);
                		}
                	}
                	if(verifyOperation)
                    {
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Operation.OperationText.Text==operation)
                        {
                            successResulttxt.Append(" Operation = "+operation);
                        }
                        else
                        {
                            failResulttxt.Append(" Operation = "+operation);
                        }
                    }
                    
                    if(verifyPassCount)
                    {
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.PassCount.Text==PassCount)
                        {
                            successResulttxt.Append(", PassCount = "+PassCount);
                        }
                        else
                        {
                            failResulttxt.Append(", PassCount = "+PassCount);
                        }
                    }
                    
                    if(verifyConsistChange)
                    {
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Loads.Text==loads)
                        {
                            successResulttxt.Append(", Loads = "+loads);
                        }
                        else
                        {
                            failResulttxt.Append(", Loads = "+loads);
                        }
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Empties.Text==empties)
                        {
                            successResulttxt.Append(", Empties = "+empties);
                        }
                        else
                        {
                            failResulttxt.Append(", Empties = "+empties);
                        }
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Tons.Text==tons)
                        {
                            successResulttxt.Append(", Tons = "+tons);
                        }
                        else
                        {
                            failResulttxt.Append(", Tons = "+tons);
                        }
                        if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByOpSta.Length.Text==length)
                        {
                            successResulttxt.Append(", Length = "+length);
                        }
                        else
                        {
                            failResulttxt.Append(", Length = "+length);
                        }
                    }
                    if(successResulttxt.Length!=0)
                    {
                        Report.Success("Success","For station "+station[i]+" - "+successResulttxt.ToString() +" successfully validated.");
                    }
                    if(failResulttxt.Length!=0)
                    {
                        Report.Failure("Failure","For station "+station[i]+" - "+failResulttxt.ToString() +" does not match.");
                    }
                }
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        /// <summary>
        /// Split Or Copy Delay in Delay tab under Trainsheet
        /// </summary>
        /// <param name="trainSeed">Train seed</param>
        /// <param name="fromLocation">From Location eg:240H</param>
        /// <param name="code">code to point the required row eg:ESO</param>
        /// <param name="state">state to point the required row</param>
        /// <param name="closeForms">bool to close the form</param>
        /// <param name="source">Source to point the required row</param>
        /// <param name="duration">Duration to point the required row</param>
        /// <param name="refresh">bool to refresh the delay table</param>
        [UserCodeMethod]
        public static void NS_SplitOrCopyDelay_Trainsheet(string trainSeed, string fromLocation, string code, string state, string source, string duration, bool validateDisabled, bool refresh, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;

            for (int i = 0; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex=i.ToString();
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Equals(state)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(fromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(code)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(source)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(duration))
                {
                    delayRowFound = true;
                    Report.Info("Right click on the record and selected Split/Copy");
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo,Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopyInfo,WinForms.MouseButtons.Right);
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopy.Enabled)
                    {
                        if (!validateDisabled)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopyInfo,Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopyInfo);
                            Report.Info("Split/Copy option is enabled and clicked.");
                        } else {
                            Ranorex.Report.Failure("Expected Split/Copy to be disabled, found to be enabled");
                        }
                        if(refresh)
                        {
                            Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                            Report.Info("Refresh button clicked.");
                        }
                    }
                    else
                    {
                        if (validateDisabled)
                        {
                            Ranorex.Report.Success("Split/Copy found to be disabled");
                        } else {
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self.Element);
                            Report.Failure("Split/Copy option is not enabled.");
                        }
                    }
                    break;
                }
            }
            if (!delayRowFound)
            {
                Ranorex.Report.Failure("Failure","Could not find delay row to Split Or Copy");
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        /// <summary>
        /// Editing particular delay row
        /// </summary>
        /// <param name="trainSeed">Train seed</param>
        /// <param name="filterFromLocation">From Location eg:240H</param>
        /// <param name="filterCode">code to point the required row eg:ESO</param>
        /// <param name="filterState">state to point the required row</param>
        /// <param name="updateCode">code to update the row with</param>
        /// <param name="updateDuration">duration to update the row with</param>
        /// <param name="expectedFeedback">feedback expected if any</param>
        /// <param name="closeForms">bool to close the form</param>
        /// <param name="bulletin">any number to sequence the bulletin</param>
        /// <param name="speed"> speed limit</param>
        /// <param name="crewID">Crew ID</param>
        /// <param name="crewSegment">Crew Segment</param>
        /// <param name="comments">Comments</param>
        /// <param name="filterSource">Source to point the required row</param>
        /// <param name="filterduration">Duration to point the required row</param>
        /// <param name="filterToLocation"></param>
        /// <param name="updateToLocation"></param>
        [UserCodeMethod]
        public static void NS_EditDelay_Trainsheet(string trainSeed, string filterFromLocation, string filterCode, string filterState, string updateCode,
                                                   string updateDuration, string expectedFeedback, bool closeForms, string bulletin, string speed,
                                                   string crewID,string crewSegment, string comments, string filterSource, string filterduration,
                                                   string updateFromLocation,string filterToLocation, string updateToLocation)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;
            
            for (int i = 0; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex=i.ToString();
                
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Contains(filterState)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(filterFromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(filterCode,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(filterSource,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(filterduration,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.GetAttributeValue<string>("Text").Contains(filterToLocation))
                {
                    delayRowFound = true;
                    break;
                }
            }
            if (delayRowFound)
            {
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCell.Click();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.PressKeys(updateFromLocation);
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.PressKeys("{TAB}");
                Trainsrepo.CodeName=updateCode;
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.DoubleClick();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.PressKeys(updateCode);
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.PressKeys("{TAB}");
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.Click();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.PressKeys(updateDuration);
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.PressKeys("{TAB}");
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.Click();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.PressKeys(updateToLocation);
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.PressKeys("{TAB}");
                updateCode=updateCode.ToUpper();
                if(updateCode=="ESO")
                {
                    Trainsrepo.DelaySpecificFieldsName="Bulletin Number";
                    Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Click();
                    Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.PressKeys(bulletin);
                    Trainsrepo.DelaySpecificFieldsName="Speed Limit";
                    Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.Click();
                    Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.PressKeys(speed);
                }
                //To do:
                //Need to update the Usercode with other Delay codes.
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.PressKeys(crewID);
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.Click();
                Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.PressKeys(crewSegment);
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CommentsInfo,Trainsrepo.Train_Sheet.Delay.Add_Comments.SelfInfo);
                if(Trainsrepo.Train_Sheet.Delay.Add_Comments.SelfInfo.Exists(0))
                {
                    Trainsrepo.Train_Sheet.Delay.Add_Comments.CommentsText.Click();
                    Trainsrepo.Train_Sheet.Delay.Add_Comments.CommentsText.PressKeys(comments);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.Add_Comments.OkButtonInfo,Trainsrepo.Train_Sheet.Delay.Add_Comments.SelfInfo);
                }
                Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
                Report.Info("Delay tab changes applied.");
                Report.Screenshot(Trainsrepo.Train_Sheet.Self.Element);
                if(expectedFeedback!="")
                {
                    if(CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                        Report.Info("Delay tab Reset to previous state.");
                    }
                }
            } else {
                Ranorex.Report.Error("Delay Row not found");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }
        /// <summary>
        /// Open Schedule Adherence form if not already open
        /// </summary>
        /// <param name="trainSeed">Input trainSeed</param>
        /// <param name="closeForm">ex:closes the Train Status Summary</param>
        [UserCodeMethod]
        public static void NS_OpenScheduleAdherence_TrainStatusSummary(string trainSeed,bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            
            if (Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo.Exists(0))
            {
                if (Trainsrepo.Train_Status_Summary.Schedule_Adherence.Self.GetAttributeValue<string>("Title").Contains(trainId))
                {
                    Ranorex.Report.Success("Opened Schedule Adherence Form is for Train {"+trainId+"}");
                    
                }
                else
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Schedule_Adherence.WindowControls.CloseInfo,
                                                                                          Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo);
                    
                    Ranorex.Report.Info("Closing the Opened Schedule Adherence Form as it is not for Train {"+trainId+"}");
                }
            }
            else
            {
                // Open train status summary window if not already open
                NS_OpenTrainStatusSummary_MainMenu();
                
                if (!Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo.Exists(0))
                {
                    Trainsrepo.TrainId = trainId;
                    
                    if(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByTrainID.TrainIDInfo,
                                                                                           Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.SelfInfo);

                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.OpenScheduleAdherenceInfo,
                                                                                      Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo);
                        if (Trainsrepo.Train_Status_Summary.Schedule_Adherence.Self.GetAttributeValue<string>("Title").Contains(trainId))
                        {
                            Ranorex.Report.Success("Schedule Adherence Form Opened  for Train {"+trainId+"}");
                        }
                        else
                        {
                            Ranorex.Report.Failure("Schedule Adherence Form Failed to open for Train {"+trainId+"}");
                            
                        }
                    }
                    else
                    {
                        Ranorex.Report.Failure("Failed as Train {"+trainId+"} not found");
                    }
                }

                else
                {
                    Ranorex.Report.Info("Schedule Adherence Form already open");
                }
                if (closeForm)
                {
                	if (Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Schedule_Adherence.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo);
                    }
                	
                    if (Trainsrepo.Train_Status_Summary.SelfInfo.Exists(0))
                    {
                        PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
                    }
                }
                return;
            }
        }
        
        /// <summary>
        /// Validate Schedule Adherence Details
        /// </summary>
        /// <param name="expActivityType">Input expActivityType</param>
        /// <param name="expectedStatus">Input expectedStatus</param>
        /// <param name="expStation">Input expStation</param>
        /// <param name="expOpsta">Input expOpsta</param>
        /// <param name="expAdherence">Input expAdherence</param>
        /// <param name="exp_AdhStatus">Input exp_AdhStatus</param>
        /// <param name="closeForm">ex:closes the  Schedule Adherence and Train Status Summary</param>
        [UserCodeMethod]
        public static void NS_ValidateScheduleAdherenceDetails_TrainStatusSummary(string expActivityType, string expectedStatus, string expStation,string expOpsta, string expAdherence,string exp_AdhStatus ,bool closeForms)
        {
            string currentActivity= "";
            bool resultFound = true;
            
            int rowCount = Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Schedule Adherence.", rowCount.ToString()));
            
            for (int i = 0; i < rowCount; i++)
            {
                resultFound = true;
                
                Trainsrepo.ScheduleAdherenceIndex = i.ToString();
                //Ranorex.Report.Info("Index #: "+i.ToString());
                currentActivity = Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.Activity.GetAttributeValue<string>("CellData").ToString();
                if(Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.ActivityInfo.Exists(0))
                {
                    if (currentActivity.Equals(expActivityType, StringComparison.OrdinalIgnoreCase))
                    {
                        //verifying the Status data
                        string currentStatus= Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.Status.GetAttributeValue<string>("CellData").ToString().Trim();
                        Ranorex.Report.Info("current Status: '" + currentStatus + "'");
                        if (!currentStatus.Equals(expectedStatus, StringComparison.OrdinalIgnoreCase))
                        {
                            resultFound=false;
                            continue;
                            
                        }
                        
                        //verifying the station data
                        string currentStation= Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.Station.GetAttributeValue<string>("CellData").ToString().Trim();
                        Ranorex.Report.Info("current Station: '" + currentStation + "'");
                        if (!currentStation.Equals(expStation, StringComparison.OrdinalIgnoreCase))
                        {
                            resultFound=false;
                            continue;
                        }
                        
                        //verifying the Opsta data
                        string currentOpsta = Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.OPSTA.GetAttributeValue<string>("CellData").ToString();
                        Ranorex.Report.Info("current Opsta: '" + currentOpsta + "'");
                        if(!currentOpsta.Equals(expOpsta, StringComparison.OrdinalIgnoreCase))
                            
                        {
                            resultFound=false;
                            continue;
                        }
                        
                        
                        //verifying the Adherence data
                        string currentAdherence = Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.Adherence.GetAttributeValue<string>("CellData").ToString().Trim();
                        Ranorex.Report.Info("current Adherence: '" + currentAdherence + "'");
                        Regex currentAdherenceRegex = new Regex(expAdherence);
                        
                        if (!currentAdherenceRegex.IsMatch(currentAdherence))
                            
                        {
                            resultFound=false;
                            continue;
                        }
                        
                        //verifying the AdhStatus data
                        string currentAdhStatus = Trainsrepo.Train_Status_Summary.Schedule_Adherence.ScheduleAdherenceTable.ScheduleAdherenceRowByIndex.AdherenceStatus.GetAttributeValue<string>("CellData").ToString().Trim();
                        Ranorex.Report.Info("current AdhStatus: '" + currentAdhStatus + "'");
                        Regex adherenceStatusRegex = new Regex(exp_AdhStatus);
                        if (!adherenceStatusRegex.IsMatch(currentAdhStatus))
                            
                        {
                            resultFound=false;
                            continue;
                            
                        }
                        
                        if (resultFound)
                        {
                            Ranorex.Report.Success("All the values for current activity '"+currentActivity+"' are matched as expected in Schedule_Adherence Form");
                            //Ranorex.Report.Screenshot(Trainsrepo.Train_Status_Summary.Schedule_Adherence.Self);
                            break;
                            
                        }
                        
                    }
                }
            }
            if (!resultFound)
            {
                
                Ranorex.Report.Failure("Values are not matching for current activity'"+currentActivity+"' with the values passed in Schedule_Adherence Form ");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Status_Summary.Schedule_Adherence.Self);
            }
            
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Schedule_Adherence.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.Schedule_Adherence.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,Trainsrepo.Train_Status_Summary.SelfInfo);
            }
            return;
        }
        
        
        
        
        /// <summary>
        /// validate if Split Or Copy option is enable or not for a particular row under Delay tab in Trainsheet form
        /// </summary>
        /// <param name="trainSeed">Train seed</param>
        /// <param name="fromLocation">From Location eg:240H</param>
        /// <param name="code">code to point the required row eg:ESO</param>
        /// <param name="state">state to point the required row</param>
        /// <param name="closeForms">bool to close the form</param>
        /// <param name="source">Source to point the required row</param>
        /// <param name="duration">Duration to point the required row</param>
        /// <param name="enabled">pass a bool to check if it is enabled or disabled</param>
        /// <param name="allRow">pass true to validate all rows</param>
        [UserCodeMethod]
        public static void NS_ValidateDelaySplitOrCopyOption_SingleRow(string trainSeed, string fromLocation, string code, string state, bool closeForms, string source,
                                                                       string duration,bool isEnabled)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;
            if(delayRowCount==0)
            {
                Ranorex.Report.Failure("Failure","Could not find delay row to Split Or Copy");
                return;
            }
            for (int i = 0 ; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex=i.ToString();
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Equals(state,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(fromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(code,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(source,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(duration,StringComparison.OrdinalIgnoreCase))
                {
                    delayRowFound = true;
                    Report.Info("Right click on the record and selected Split/Copy");
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo,Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopyInfo,WinForms.MouseButtons.Right);
                    if(isEnabled)
                    {
                        if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopy.Enabled)
                        {
                            Report.Success("Success","Split/Copy option is enabled for row "+i.ToString()+".");
                        }
                        else
                        {
                            Report.Failure("Failure","Split/Copy option is not enabled for row "+i.ToString()+".");
                        }
                    }
                    else
                    {
                        if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopy.Enabled)
                        {
                            Report.Failure("Failure","Split/Copy option is enabled for row "+i.ToString()+".");
                        }
                        else
                        {
                            Report.Success("Success","Split/Copy option is not enabled for row "+i.ToString()+".");
                        }
                    }
                    break;
                }
            }
            if (!delayRowFound)
            {
                Ranorex.Report.Failure("Failure","Could not find delay row to Split Or Copy");
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        /// <summary>
        /// validate if Split Or Copy option is enable or not for all rows under Delay tab in Trainsheet form
        /// </summary>
        /// <param name="closeForms">bool to close the form</param>
        /// <param name="enabled">pass a bool to check if it is enabled or disabled</param>
        /// <param name="allRow">pass true to validate all rows</param>
        [UserCodeMethod]
        public static void NS_ValidateDelaySplitOrCopyOption_AllRow(string trainSeed, bool isEnabled, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            if(delayRowCount==0)
            {
                Ranorex.Report.Failure("Failure","Could not find delay row to Split Or Copy");
                return;
            }
            for (int i = 0 ; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex=i.ToString();
                Report.Info("Right click on the record and selected Split/Copy on row "+i.ToString()+".");
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo,Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopyInfo,WinForms.MouseButtons.Right);
                if(isEnabled)
                {
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopy.Enabled)
                    {
                        Report.Success("Success","Split/Copy option is enabled for row "+i.ToString()+".");
                    }
                    else
                    {
                        Report.Failure("Failure","Split/Copy option is not enabled for row "+i.ToString()+".");
                    }
                }
                else
                {
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SplitCopy.Enabled)
                    {
                        Report.Failure("Failure","Split/Copy option is enabled for row "+i.ToString()+".");
                    }
                    else
                    {
                        Report.Success("Success","Split/Copy option is not enabled for row "+i.ToString()+".");
                    }
                }
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        /// <summary>
        /// Open the Trainsheet if it's no open, and select the Interactive History tab if it's not selected
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenInteractiveHistory_TrainSheet(string trainSeed, bool closeTrainsheet)
        {
            if (Trainsrepo.Interactive_History.SelfInfo.Exists(0))
            {
                string trainId = NS_TrainID.GetTrainId(trainSeed);
                if (trainId == null)
                {
                    trainId = trainSeed;
                }
                if (Trainsrepo.Interactive_History.TrainIDText.GetAttributeValue<string>("Text") != trainId)
                {
                    Trainsrepo.Interactive_History.TrainIDText.Element.SetAttributeValue("Text", trainId);
                    Trainsrepo.Interactive_History.TrainIDText.PressKeys("{TAB}");
                }
                if (Trainsrepo.Interactive_History.TrainIDText.GetAttributeValue<string>("Text") == trainId)
                {
                    Ranorex.Report.Success("Interactive History Form opened for train {"+Trainsrepo.Interactive_History.TrainIDText.GetAttributeValue<string>("Text")+"}.");
                    return;
                }
            }
            NS_OpenTrainsheet_MainMenu(trainSeed);

            //If the Trainsheet doesn't exist, then the previous call already errored
            if (!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                return;
            }

            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.RibbonMenu.InteractiveHistoryInfo,Trainsrepo.Interactive_History.SelfInfo);
            
            if (!Trainsrepo.Interactive_History.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Interactive History Form failed to appear");
                if(closeTrainsheet)
                {
                    NS_CloseTrainsheet();
                }
                return;
            }
            
            int retries = 0;
            while (Trainsrepo.Interactive_History.TrainIDText.GetAttributeValue<string>("Text").Equals("") && retries < 3)
            {
                retries++;
                Ranorex.Delay.Milliseconds(500);
            }
            
            if(Trainsrepo.Interactive_History.Moves.MovesTable.Self.Rows.Count<1)
            {
                Ranorex.Report.Failure("Interactive History Form failed load moves table or taking longer time to load the details.");
                return;
            }
            else
            {
                Ranorex.Report.Success("Interactive History Form opened for train {"+Trainsrepo.Interactive_History.TrainIDText.GetAttributeValue<string>("Text")+"}.");
            }
            
            if(closeTrainsheet)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
            return;
        }
        
        /// <summary>
        /// Validate Dwell value in Trip plan tab - Train Sheet
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="dwell">Input: dwell (ex: 00:00)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityWithDwellExists(string trainSeed, string activityType, string dwell, bool validateExist, bool closeForms)
        {
            //Open TrainSheet
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
            
            bool resultFound = false;
            for (int i=0; i <activity; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) && Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.DwellInfo.Exists(0))
                {
                    string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
                    
                    if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                    {
                        string currentDwell = "";
                        if(!String.IsNullOrEmpty(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.GetAttributeValue<string>("Text")))
                        {
                            currentDwell = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Dwell.GetAttributeValue<string>("Text");
                        }
                        
                        if(currentDwell.Equals(dwell, StringComparison.OrdinalIgnoreCase))
                        {
                            Report.Info("Actual activity type " +activityList+ " Dwell: " +currentDwell+ " found " +activityType+ " Dwell: " +dwell);
                            resultFound = true;
                            break;
                        }
                    }
                }
            }
            
            if(resultFound == validateExist)
            {
                Ranorex.Report.Success("Activity type should exist is " +validateExist+ ", but actually it is present " +resultFound+ "");
            }
            else
            {
                Ranorex.Report.Failure("Activity type has not listed");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// Right clicks train on trackline and Validate QuickStop
        /// </summary>
        /// <param name="trainSeed">Input:Trainseed</param>
        /// <param name="isQuickStopEnabled">Input: True or false Validate Quick stop option is Enabled or Disabled in Train object menu</param>
        [UserCodeMethod]
        public static void NS_ValidateQuickStop_Trackline(string trainSeed, bool expQuickStopEnabledStatus)
        {
            bool actQuickStopEnabledStatus = false;
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            Tracklinerepo.TrainId = trainId;
            NS_Trackline.MakeTrainVisibleOnTrackline(trainSeed);
            
            GeneralUtilities.RightClickAndWaitForWithRetry(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectInfo, Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.SelfInfo);
            // Validating Quick Stop is Enabled or Disabled in Train object menu
            actQuickStopEnabledStatus = Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.QuickStop.Enabled;
            Ranorex.Report.Info("QuickStop enabled status actual value " +actQuickStopEnabledStatus.ToString());
            
            if(expQuickStopEnabledStatus == actQuickStopEnabledStatus)
            {
                Ranorex.Report.Success("QuickStop menu enabled status expected to be {" +expQuickStopEnabledStatus+ "} and found as {" +actQuickStopEnabledStatus.ToString()+ "}");
            }
            else
            {
                Ranorex.Report.Failure("QuickStop menu enabled status expected to be {" +expQuickStopEnabledStatus+ "} but found as {" +actQuickStopEnabledStatus.ToString()+ "}");
                Ranorex.Report.Screenshot(Tracklinerepo.Trackline_Form_By_Train_Id.TrainObjectMenu.QuickStop.Element);
            }
            return;
        }
        
        /// <summary>
        /// Removes Train from tracking via the trainsheet
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_RemoveTrainFromTracking_Trainsheet(string trainSeed, bool clickYes, bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.MainMenuBar.EditButtonInfo,Trainsrepo.Train_Sheet.EditMenu.SelfInfo);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EditMenu.RemoveTrainInfo,Trainsrepo.Train_Sheet.Confirm_Train_Terminate.SelfInfo);
            
            if (clickYes)
            {
                Ranorex.Report.Info("Pressing Yes button on Remove Train From Tracking Popup");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Confirm_Train_Terminate.YesButtonInfo, Trainsrepo.Train_Sheet.Confirm_Train_Terminate.SelfInfo);
            } else {
                Ranorex.Report.Info("Pressing No button on Remove Train From Tracking Popup");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Confirm_Train_Terminate.NoButtonInfo, Trainsrepo.Train_Sheet.Confirm_Train_Terminate.SelfInfo);
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
            
            return;
        }

        /// <summary>
        /// Validate Moves table in Interactive History form for all tables in the form based on the selection of radio button
        /// </summary>
        /// <param name="trainSeed">trainSeed of the the train to be validated</param>
        /// <param name="movedOpsta">opsta where ever the train has been moved</param>
        /// <param name="milePost"></param>
        /// <param name="reportType"></param>
        /// <param name="direction"></param>
        /// <param name="distance"></param>
        /// <param name="speed"></param>
        /// <param name="source"></param>
        /// <param name="pseudotrain"></param>
        /// <param name="closeForm">true if form to be closed</param>
        [UserCodeMethod]
        public static void NS_ValidateMovesInInteractiveHistory_Trainsheet(string trainSeed, string movedOpsta, string station, string milePost,
                                                                           string reportType, string direction, string distance, string speed, string source,
                                                                           string pseudotrain,bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            NS_OpenInteractiveHistory_TrainSheet(trainSeed,false);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Interactive_History.InteractiveHistoryTabs.RadioButtonMovesInfo,Trainsrepo.Interactive_History.Moves.MovesTable.SelfInfo);
            StringBuilder found=new StringBuilder();
            if(Trainsrepo.Interactive_History.Moves.MovesTable.Self.Rows.Count>1)
            {
                Regex regexedDistance = new Regex(distance);
                Regex regexedSpeed = new Regex(speed);
                Regex regexedPseudo = new Regex(pseudotrain);
                for(int k=0;k<Trainsrepo.Interactive_History.Moves.MovesTable.Self.Rows.Count;k++)
                {
                    Trainsrepo.movesRowIndex=k.ToString();
                    found.Clear();
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Opsta.GetAttributeValue<string>("cellData").Equals(movedOpsta))
                    {
                        found.Append(" { Movement opsta : "+movedOpsta+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Station.GetAttributeValue<string>("cellData").Equals(station))
                    {
                        found.Append(" { Station : "+station+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.MP.GetAttributeValue<string>("cellData").Equals(milePost))
                    {
                        found.Append(" { Milepost : "+milePost+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.ReportType.GetAttributeValue<string>("cellData").Equals(reportType))
                    {
                        found.Append(" { Report Type : "+reportType+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Direction.GetAttributeValue<string>("cellData").Equals(direction))
                    {
                        found.Append(" { Direction : "+direction+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(regexedDistance.IsMatch(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Speed.GetAttributeValue<string>("cellData")))
                    {
                        found.Append(" { Distance : "+distance+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(regexedSpeed.IsMatch(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Speed.GetAttributeValue<string>("cellData")))
                    {
                        found.Append(" { Speed : "+speed+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.Source.GetAttributeValue<string>("cellData").Equals(source))
                    {
                        found.Append(" { Source : "+source+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(regexedPseudo.IsMatch(Trainsrepo.Interactive_History.Moves.MovesTable.MovesRowByMovesIndex.PseudoTrain.GetAttributeValue<string>("cellData")))
                    {
                        found.Append(" { PseudoTrain : "+pseudotrain+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    break;
                }
            }
            if(found.Length>0)
            {
                Report.Success("Movement records with {"+found+"} found.");
            }
            else
            {
                Report.Failure("Movement records do not match with the given data.");
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// Validate Authority table in Interactive History form for all tables in the form based on the selection of radio button
        /// </summary>
        /// <param name="trainSeed">trainSeed of the the train to be validated</param>
        /// <param name="authoritySeeds">multiple authority seeds with '|' delimiter</param>
        /// <param name="closeForm">true if form to be closed</param>
        [UserCodeMethod]
        public static void NS_ValidateTAInInteractiveHistory_Trainsheet(string trainSeed, string authoritySeed, bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            NS_OpenInteractiveHistory_TrainSheet(trainSeed,false);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Interactive_History.InteractiveHistoryTabs.RadioButtonTAInfo,Trainsrepo.Interactive_History.TA.TATable.SelfInfo);
            StringBuilder found=new StringBuilder();
            if(Trainsrepo.Interactive_History.TA.TATable.Self.Rows.Count>0)
            {
                
                for(int i=0;i<Trainsrepo.Interactive_History.TA.TATable.Self.Rows.Count;i++)
                {
                    Trainsrepo.movesRowIndex=i.ToString();
                    found.Clear();
                    if(Trainsrepo.Interactive_History.TA.TATable.TARowByTAIndex.Number.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Authorities.GetAuthorityNumber(authoritySeed).ToLower()))
                    {
                        found.Append(" { Number : "+NS_Authorities.GetAuthorityNumber(authoritySeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TA.TATable.TARowByTAIndex.To.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Authorities.GetAuthorityEngineSeed(authoritySeed).ToLower()))
                    {
                        found.Append(" { To : "+NS_Authorities.GetAuthorityEngineSeed(authoritySeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TA.TATable.TARowByTAIndex.Type.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Authorities.GetAuthorityType(authoritySeed).Insert(1,"/").ToLower()))
                    {
                        found.Append(" { Type : "+NS_Authorities.GetAuthorityType(authoritySeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TA.TATable.TARowByTAIndex.From.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Authorities.GetAuthorityBox2ProceedFrom(authoritySeed).ToLower()))
                    {
                        found.Append(" { From : "+NS_Authorities.GetAuthorityBox2ProceedFrom(authoritySeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    //TO DO: From and To location validation with other boxes need to be updated.
                    if(Trainsrepo.Interactive_History.TA.TATable.TARowByTAIndex.To2.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Authorities.GetAuthorityBox2To1(authoritySeed).ToLower()))
                    {
                        found.Append(" { To location : "+NS_Authorities.GetAuthorityBox2To1(authoritySeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    break;
                }
            }
            if(found.Length>0)
            {
                Report.Success("Track authority records with number {"+found+"} found.");
            }
            else
            {
                Report.Failure("Could not find track authority records with authority seed.");
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// Validate Train clearance table in Interactive History form for all tables in the form based on the selection of radio button
        /// </summary>
        /// <param name="trainSeed">trainSeed of the the train to be validated</param>
        /// <param name="TCStatus">Train clearance issued or not. eg: "issued"</param>
        /// <param name="closeForm">true if form to be closed</param>
        [UserCodeMethod]
        public static void NS_ValidateTCInInteractiveHistory_Trainsheet(string trainSeed, string TCStatus, bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            NS_OpenInteractiveHistory_TrainSheet(trainSeed,false);
            NS_TrainClearance.NS_OpenTrainClearanceSummaryList();
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Interactive_History.InteractiveHistoryTabs.RadioButtonTCInfo,Trainsrepo.Interactive_History.TC.TCTable.SelfInfo);
            TrainClearancerepo.TrainId=NS_TrainID.GetTrainId(trainSeed);
            string trainClearanceNumber = ADMSEnvironment.GetTrainClearanceNumber(NS_TrainID.GetTrainId(trainSeed));
            StringBuilder found = new StringBuilder();
            if(Trainsrepo.Interactive_History.TC.TCTable.Self.Rows.Count>0)
            {
                string associateTimeStampDB="";
                string trainClearanceDetails="";
                System.DateTime associateTimeStampDBDT;
                for(int i=0;i<Trainsrepo.Interactive_History.TC.TCTable.Self.Rows.Count;i++)
                {
                    Trainsrepo.TCRowIndex=i.ToString();
                    found.Clear();
                    TrainClearancerepo.TrainClearanceNumber=trainClearanceNumber;
                    trainClearanceDetails=ADMSEnvironment.GetTrainClearanceDetails_ADMS(trainClearanceNumber);
                    
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.Number.GetAttributeValue<string>("cellData").ToLower().Contains(trainClearanceNumber))
                    {
                        found.Append(" { Clearance Number : "+trainClearanceNumber+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.Status.GetAttributeValue<string>("cellData").ToLower().Contains(TCStatus.ToLower()))
                    {
                        found.Append(" { Status : "+Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.Status.GetAttributeValue<string>("cellData")+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.CrewOriginPassCount.GetAttributeValue<string>("cellData").Contains(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.CrewOriginPassCount.GetAttributeValue<string>("Text").Replace(" / ","/")))
                    {
                        found.Append(" { CrewOrigin/PassCount : "+Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.CrewOriginPassCount.GetAttributeValue<string>("cellData")+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.CrewDestinationPassCount.GetAttributeValue<string>("cellData").Contains(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.CrewDestinationPassCount.GetAttributeValue<string>("Text").Replace(" / ","/")))
                    {
                        found.Append(" { CrewDestination/PassCount : "+Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.CrewDestinationPassCount.GetAttributeValue<string>("cellData")+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    associateTimeStampDB=trainClearanceDetails;
                    associateTimeStampDB=associateTimeStampDB.Substring(associateTimeStampDB.IndexOf("Issued"),27).Replace("Issued","").Replace("A E","").Trim();
                    associateTimeStampDBDT=Convert.ToDateTime(associateTimeStampDB);
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.AssociationTimeStamp.GetAttributeValue<string>("cellData").Replace("A E","").Contains(associateTimeStampDBDT.ToString("M-d H:mm")))
                    {
                        found.Append(" { Association TimeStamp : "+Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.AssociationTimeStamp.GetAttributeValue<string>("cellData")+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.DispatcherInitials.GetAttributeValue<string>("cellData").Contains(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.AssocationDispatcherInitals.GetAttributeValue<string>("Text")))
                    {
                        found.Append(" { Dispatcher Initials : "+Trainsrepo.Interactive_History.TC.TCTable.TCRowByTCIndex.DispatcherInitials.GetAttributeValue<string>("cellData")+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    break;
                }
            }
            if(found.Length>0)
            {
                Report.Success("Train Clearance records {"+found+"} found.");
            }
            else
            {
                Report.Failure("Could not find Train Clearance records with given number.");
            }
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo,TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// Validate Speed Restriction table in Interactive History form for all tables in the form based on the selection of radio button
        /// </summary>
        /// <param name="trainSeed">trainSeed of the the train to be validated</param>
        /// <param name="bulletinType">multiple bulletin types with '|' delimiter</param>
        /// <param name="closeForm">true if form to be closed</param>
        [UserCodeMethod]
        public static void NS_ValidateSRInInteractiveHistory_Trainsheet(string trainSeed, string bulletinSeed, bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            NS_OpenInteractiveHistory_TrainSheet(trainSeed,false);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Interactive_History.InteractiveHistoryTabs.RadioButtonSRInfo,Trainsrepo.Interactive_History.SR.SRTable.SelfInfo);
            StringBuilder found=new StringBuilder();
            if(Trainsrepo.Interactive_History.SR.SRTable.Self.Rows.Count>0)
            {
                DataTable BulletinDateTime= new DataTable();
                System.DateTime finalDate;
                System.DateTime localDate;
                for(int i=0;i<Trainsrepo.Interactive_History.SR.SRTable.Self.Rows.Count;i++)
                {
                    Trainsrepo.SRRowIndex=i.ToString();
                    found.Clear();
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.Number.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinNumber(bulletinSeed).ToLower()))
                    {
                        found.Append(" { Number : "+NS_Bulletin.GetBulletinNumber(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.Type.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinType(bulletinSeed).ToLower()))
                    {
                        found.Append(" { Type : "+NS_Bulletin.GetBulletinType(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.District.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinDistrict(bulletinSeed).ToLower()))
                    {
                        found.Append(" { District : "+NS_Bulletin.GetBulletinDistrict(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.FirstLimit.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinMilepost1(bulletinSeed).ToLower()))
                    {
                        found.Append(" { FirstLimit : "+NS_Bulletin.GetBulletinMilepost1(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.SecondLimit.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinMilepost2(bulletinSeed).ToLower()))
                    {
                        found.Append(" { SecondLimit : "+NS_Bulletin.GetBulletinMilepost2(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    BulletinDateTime=ADMSEnvironment.GetBulletinDatetime_ADMS(NS_Bulletin.GetBulletinNumber(bulletinSeed),NS_Bulletin.GetBulletinType(bulletinSeed),"PENDING_ACTIVE");
                    finalDate = Convert.ToDateTime(BulletinDateTime.Rows[0][0].ToString());
                    localDate = finalDate.ToLocalTime();
                    Regex regexDatetime=new Regex(localDate.ToString("M-d-yyyy h:mm"));
                    string EffectiveDatetimeUI=Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.EffectiveDateTime.GetAttributeValue<string>("cellData");
                    if(regexDatetime.IsMatch(EffectiveDatetimeUI))
                    {
                        found.Append(" { EffectiveDateTime : "+EffectiveDatetimeUI+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    finalDate = Convert.ToDateTime(BulletinDateTime.Rows[0][1].ToString());
                    localDate = finalDate.ToLocalTime();
                    regexDatetime=new Regex(localDate.ToString("M-d-yyyy h:mm"));
                    string ExpirationDateTimeUI=Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.ExpirationDateTime.GetAttributeValue<string>("cellData");
                    if(regexDatetime.IsMatch(ExpirationDateTimeUI))
                    {
                        found.Append(" { ExpirationDateTime : "+ExpirationDateTimeUI+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.TrackName.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinTrackLine(bulletinSeed).ToLower()))
                    {
                        found.Append(" { Track Name : "+NS_Bulletin.GetBulletinTrackLine(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    if(Trainsrepo.Interactive_History.SR.SRTable.SRRowBySRIndex.SpeedLimit.GetAttributeValue<string>("cellData").ToLower().Contains(NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed).ToLower()))
                    {
                        found.Append(" { Speed Limit : "+NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed)+" } ");
                    }
                    else
                    {
                        found.Clear();
                        continue;
                    }
                    
                    break;
                }
            }
            if(found.Length>0)
            {
                Report.Success("Bulletin records with number {"+found+"} found.");
            }
            else
            {
                Report.Failure("Could not find bulletin records with given bulletin seed.");
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// Validate History table in Interactive History form for all tables in the form based on the selection of radio button
        /// </summary>
        /// <param name="trainSeed">trainSeed of the the train to be validated</param>
        /// <param name="historyKeyword">multiple keywords to search for in the history table with '|' delimiter</param>
        /// <param name="closeForm">true if form to be closed</param>
        [UserCodeMethod]
        public static void NS_ValidateHistoryInInteractiveHistory_Trainsheet(string trainSeed, string historyKeyword,string originOpsta, string originStation, string terminateOpsta, string terminateStation, bool closeForm)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            NS_OpenInteractiveHistory_TrainSheet(trainSeed,false);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Interactive_History.InteractiveHistoryTabs.RadioButtonHistoryInfo,Trainsrepo.Interactive_History.History.HistoryTable.SelfInfo);
            if(Trainsrepo.Interactive_History.History.HistoryTable.Self.Rows.Count>0)
            {
                string historyfound="";
                string[] splithistoryKeyword= historyKeyword.Split('|');
                Regex regexedtext;
                string builtString="";
                for(int k=0;k<splithistoryKeyword.Length;k++)
                {
                    for(int i=0;i<Trainsrepo.Interactive_History.History.HistoryTable.Self.Rows.Count;i++)
                    {
                        historyfound="";
                        Trainsrepo.historyRowIndex=i.ToString();
                        regexedtext= new Regex(BuildInteractiveHistoryRegex(trainSeed,splithistoryKeyword[k], originOpsta, originStation, terminateOpsta, terminateStation).ToLower());
                        builtString=Trainsrepo.Interactive_History.History.HistoryTable.HistoryRowByHistoryIndex.History.GetAttributeValue<string>("cellData").Replace("(","").Replace(")","").ToLower();
                        if(regexedtext.IsMatch(builtString))
                        {
                            historyfound=splithistoryKeyword[k];
                            Report.Success("History record with keyword {"+historyfound+"} exists.");
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if(historyfound.Length==0)
                    {
                        Report.Failure("History record with keyword {"+historyfound+"} does not exists.");
                    }
                }
            }
            else
            {
                Report.Failure("History details not loaded for a given train.");
            }
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Interactive_History.WindowControls.CloseInfo,Trainsrepo.Interactive_History.SelfInfo);
                NS_CloseTrainsheet();
            }
        }
        
        /// <summary>
        /// Building the trainsheet history text
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="trainHistoryTextType">Input:one of the cases from function BuildTrainHistoryTextMessage</param>
        /// <returns></returns>
        public static string BuildInteractiveHistoryRegex(string trainSeed, string trainHistoryTextType,string originOpsta, string originStation, string terminateOpsta, string terminateStation)
        {
            string trainHistoryText = trainHistoryTextType;
            switch(trainHistoryTextType)
            {
                case "train scheduling" :
                    trainHistoryText="Scheduled from "+originOpsta + " "+originStation+" to "+terminateOpsta + " "+terminateStation+".";
                    break;
                case "create" :
                    trainHistoryText = "Created.";
                    break;
                case "entering ctc" :
                    trainHistoryText = "Entering control type CTC / NS.";
                    break;
            }
            return trainHistoryText;
        }
        
        /// <summary>
        /// Click on the activity type link and validate Train sheet tabs
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// /<param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 205H etc)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ClickTripPlanActivityLinkAndValidate_Trainsheet(string trainSeed, string activityType, string opsta, bool closeForms)
        {
            //Open TrainSheet
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            int activityCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activityCount.ToString()));
            if(activityCount == 0)
            {
                Ranorex.Report.Failure("Trip Plan doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
                return;
            }
            
            bool resultFound = false;
            string currentLocation = "";
            for (int i=0; i < activityCount; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) && Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LocationInfo.Exists(0))
                {
                    string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
                    if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                    {
                        if(!String.IsNullOrEmpty(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("Text")))
                        {
                            currentLocation = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("StationId");
                        }
                        
                        if(currentLocation.Equals(opsta, StringComparison.OrdinalIgnoreCase))
                        {
                            Report.Info("Actual activity type " +activityList+ " " +currentLocation+ " found " +activityType+ " " +opsta);
                            resultFound = true;
                            break;
                        }
                    }
                }
            }
            
            if(resultFound)
            {
                switch(activityType.ToLower())
                {
                    case "assigned work":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LinkInfo, Trainsrepo.Train_Sheet.Train.AssignedWork.SelfInfo);
                        if (Trainsrepo.Train_Sheet.Train.AssignedWork.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Success("Assigned Work Successfully opened from Trip Plan Link");
                        } else {
                            Ranorex.Report.Failure("Assigned Work Unsuccessfully opened from Trip Plan Link");
                        }
                        break;
                        
                    case "change crew":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LinkInfo, Trainsrepo.Train_Sheet.Crew.SelfInfo);
                        if (Trainsrepo.Train_Sheet.Crew.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Success("Crew Successfully opened from Trip Plan Link");
                        } else {
                            Ranorex.Report.Failure("Crew Unsuccessfully opened from Trip Plan Link");
                        }
                        break;
                        
                    case "change engines":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LinkInfo, Trainsrepo.Train_Sheet.Engine.SelfInfo);
                        if (Trainsrepo.Train_Sheet.Engine.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Success("Engine Successfully opened from Trip Plan Link");
                        } else {
                            Ranorex.Report.Failure("Engine Unsuccessfully opened from Trip Plan Link");
                        }
                        break;
                        
                    default:
                        Ranorex.Report.Error(string.Format("Activity type '{0}' is not valid", activityType.ToLower()));
                        break;
                }
            }
            
            else
            {
                Ranorex.Report.Error("Activity type is not found in Trip Plan tab " +activityType);
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
            }
            
        }
        
        
        /// <summary>
        /// Click Trip Plan link and navigate to trip plan tab in TrainSheet
        /// <param name="opsta">Input: Location (ex: 172H etc)</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClickAssignedWorkTripPlanLinkAndValidate_TrainSheet_AssignedWork(string opsta)
        {
            GeneralUtilities.CheckWaitState(3);
            if(!Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkInputTable.SelfInfo.Exists(0) || !Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.GetAttributeValue<bool>("Selected"))
            {
                Ranorex.Report.Error("Assigned Work Tab not open");
                return;
            }
            
            bool foundAssignedWork = false;
            int assignworkCount = Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Assigned work list in the Train sheet", assignworkCount.ToString()));
            if(assignworkCount == 0)
            {
                Ranorex.Report.Failure("Assigned work doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self.Element);
                return;
            }
            
            for (int i=0; i < assignworkCount; i++)
            {
                Trainsrepo.AssignedWorkIndex = i.ToString();
                string currentassignWorkLocation = Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.OpStaName.GetAttributeValue<string>("StationId");
                
                if(currentassignWorkLocation.Equals(opsta, StringComparison.OrdinalIgnoreCase))
                {
                    Report.Info("Actual assign work location "  +currentassignWorkLocation+ " found "  +opsta);
                    foundAssignedWork = true;
                    break;
                }
            }
            
            if (foundAssignedWork)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.LinkInfo,
                                                          Trainsrepo.Train_Sheet.TripPlan.SelfInfo);
                if (Trainsrepo.Train_Sheet.TripPlan.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Trip Plan Successfully opened from Assigned Work Link");
                } else {
                    Ranorex.Report.Failure("Trip Plan Unsuccessfully opened from Assigned Work Link");
                }
            } else {
                Ranorex.Report.Error("Could not find Assigned Work for opsta {" + opsta + "}");
            }
        }
        
        
        /// <summary>
        /// Validate Crew tab and navigate to trip plan tab in TrainSheet
        /// <param name="opsta">Input: Location (ex: 205H etc)</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClickCrewTripPlanLinkAndValidate_TrainSheet_Crew(string onDutyLocation)
        {
            GeneralUtilities.CheckWaitState(3);
            if(!Trainsrepo.Train_Sheet.Crew.CrewTable.SelfInfo.Exists(0) || !Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.GetAttributeValue<bool>("Selected"))
            {
                Ranorex.Report.Error("Crew Tab not open");
                return;
            }
            
            bool crewFound = false;
            int crewCount = Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} crew details in the Train sheet", crewCount.ToString()));
            if(crewCount == 0)
            {
                Ranorex.Report.Failure("Crew details doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Element);
                return;
            }
            
            for (int i=0; i < crewCount; i++)
            {
                Trainsrepo.CrewIndex = i.ToString();
                string crewDutyLocation = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.GetAttributeValue<string>("StationId");
                
                if(crewDutyLocation.Equals(onDutyLocation, StringComparison.OrdinalIgnoreCase))
                {
                    Report.Info("Actual crew duty location "  +crewDutyLocation+ " found "  +onDutyLocation);
                    crewFound = true;
                    break;
                }
            }
            
            if (crewFound)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLinkInfo,
                                                          Trainsrepo.Train_Sheet.TripPlan.SelfInfo);
                if (Trainsrepo.Train_Sheet.TripPlan.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Trip Plan Successfully opened from Crew Link");
                } else {
                    Ranorex.Report.Failure("Trip Plan Unsuccessfully opened from Crew Link");
                }
            } else {
                Ranorex.Report.Error("Could not find Crew for On Duty Location {" + onDutyLocation + "}");
            }
        }
        
        
        
        /// <summary>
        /// Validate Engine tab and navigate to trip plan tab in TrainSheet
        /// <param name="opsta">Input: Location (ex: 187H etc)</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClickEngineTripPlanLinkAndValidate_TrainSheet_Engine(string engineLocation)
        {
            GeneralUtilities.CheckWaitState(3);
            if(!Trainsrepo.Train_Sheet.Engine.EngineTable.SelfInfo.Exists(0) || !Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.GetAttributeValue<bool>("Selected"))
            {
                Ranorex.Report.Error("Engine Tab not open");
                return;
            }
            
            bool engineFound = false;
            int engineDetailsCount = Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} engine details in the Train sheet", engineDetailsCount.ToString()));
            if(engineDetailsCount == 0)
            {
                Ranorex.Report.Failure("Crew details doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Element);
                return;
            }
            
            for (int i=0; i < engineDetailsCount; i++)
            {
                Trainsrepo.EngineIndex = i.ToString();
                string foundEngineLocation = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.GetAttributeValue<string>("StationId");
                
                if(foundEngineLocation.Equals(engineLocation, StringComparison.OrdinalIgnoreCase))
                {
                    Report.Info("Actual engine location "  +foundEngineLocation+ " found "  +engineLocation);
                    engineFound = true;
                    break;
                }
            }
            
            if (engineFound)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLinkInfo,
                                                          Trainsrepo.Train_Sheet.TripPlan.SelfInfo);
                if (Trainsrepo.Train_Sheet.TripPlan.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Success("Trip Plan Successfully opened from Engine Link");
                } else {
                    Ranorex.Report.Failure("Trip Plan Unsuccessfully opened from Engine Link");
                }
            } else {
                Ranorex.Report.Error("Could not find Engine for Origin Location {" + engineLocation + "}");
            }
        }
        
        
        /// <summary>
        /// Removes all Engine records For Train
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_RemoveEnginerecordsForTrain(string trainSeed, bool closeForms)
        {
            NS_OpenTrainsheetEngine_MainMenu(trainSeed);
            int engineRecords = Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count;
            if(engineRecords == 0)
            {
                Ranorex.Report.Failure("Engine record doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Engine.Self.Element);
                return;
            }

            for (int i=1; i<engineRecords; i++)
            {
                Trainsrepo.EngineIndex = i.ToString();
                GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCellInfo, Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCellInfo);
                Trainsrepo.Train_Sheet.Engine.EngineMenuCellMenu.DeleteRow.Click();
                Ranorex.Report.Info("Engine record has deleted successfully");
            }
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Engine.ApplyButtonInfo,Trainsrepo.Train_Sheet.Engine.ApplyButtonInfo);
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,Trainsrepo.Train_Sheet.OkButtonInfo);
            }

        }
        
        
        /// <summary>
        /// Validate reason value in Trip plan tab - Train Sheet
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="reason">Input: reason (ex: Train navigation)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityWithReasonExists(string trainSeed, string activityType, string reason, bool validateExist, bool closeForms)
        {
            //Open TrainSheet
            NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
            
            int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
            if(activity == 0)
            {
                Ranorex.Report.Failure("Trip Plan doesn't exist or it takes more time to load");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
                if(closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            bool resultFound = false;
            for (int i=0; i <activity; i++)
            {
                Trainsrepo.TripPlanIndex = i.ToString();
                
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) && Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.DwellInfo.Exists(0))
                {
                    string activityList = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
                    
                    if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                    {
                        string currentReason = "";
                        if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ReasonInfo.Exists(0))
                        {
                            Report.Info("Reason link has been found");
                            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ReasonInfo,
                                                                      Trainsrepo.Train_Sheet.TripPlan.Add_Reason_Text.SelfInfo);
                            
                            currentReason = Trainsrepo.Train_Sheet.TripPlan.Add_Reason_Text.ReasonText.GetAttributeValue<string>("Text");
                        }
                        
                        if(currentReason.Equals(reason, StringComparison.OrdinalIgnoreCase))
                        {
                            Report.Info("Actual activity type " +activityList+ " Reason: " +currentReason+ " found " +activityType+ " Reason: " +reason);
                            resultFound = true;
                            break;
                        }
                    }
                }
            }
            
            if(resultFound == validateExist)
            {
                Ranorex.Report.Success("Activity type should exist is " +validateExist+ ", but actually it is present " +resultFound+ "");
            }
            else
            {
                Ranorex.Report.Failure("Activity type has not listed");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
            }
            
            if(Trainsrepo.Train_Sheet.TripPlan.Add_Reason_Text.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.Add_Reason_Text.OkButtonInfo,
                                                          Trainsrepo.Train_Sheet.SelfInfo);
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Validate Scroll-Bar Exists
        /// </summary>
        /// <param name="trainSeed">trainSeed</param>
        /// <param name="validateScrollExists">validateScrollExists bool</param>
        /// <param name="closeForms">closeForms bool</param>
        [UserCodeMethod]
        public static void NS_ValidateScrollBarExists_Trainsheet(string trainSeed, bool validateScrollExists, bool closeForms)
        {
            NS_OpenTrainsheet_MainMenu(trainSeed);
            StringBuilder exist=new StringBuilder("");
            StringBuilder doesNotExist=new StringBuilder("");
            if(Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text").Equals(PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)))
            {
                //Trip plan tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTabInfo,
                                                          Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Trip plan } ");
                }
                else
                {
                    doesNotExist.Append(" { Trip plan } ");
                }
                //Engine tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTabInfo,
                                                          Trainsrepo.Train_Sheet.Engine.EngineTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.Engine.EngineTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Engine } ");
                }
                else
                {
                    doesNotExist.Append(" { Engine } ");
                }
                //Crew tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTabInfo,
                                                          Trainsrepo.Train_Sheet.Crew.CrewTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.Crew.CrewTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Crew } ");
                }
                else
                {
                    doesNotExist.Append(" { Crew } ");
                }
                //Train tab - Consist Summary
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTabInfo,Trainsrepo.Train_Sheet.Train.TrainConsistTabs.SelfInfo);
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummaryInfo,
                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Train - ConsistSummary } ");
                }
                else
                {
                    doesNotExist.Append(" { Train - ConsistSummary } ");
                }
                //Train tab - Assigned Work
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Train - AssignedWork } ");
                }
                else
                {
                    doesNotExist.Append(" { Train - AssignedWork } ");
                }
                //Train tab - Consist Constraints
                if(validateScrollExists)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraintsInfo,
                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.SelfInfo);
                    Delay.Seconds(2);
                    if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.VerticalScrollBarInfo.Exists(0))
                    {
                        exist.Append(" { Train - ConsistConstraints } ");
                    }
                    else
                    {
                        doesNotExist.Append(" { Train - ConsistConstraints } ");
                    }
                }
                //Movement tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTabInfo,
                                                          Trainsrepo.Train_Sheet.Movement.MovementTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.Movement.MovementTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Movement } ");
                }
                else
                {
                    doesNotExist.Append(" { Movement } ");
                }
                //Delay tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTabInfo,
                                                          Trainsrepo.Train_Sheet.Delay.DelayTable.SelfInfo);
                Delay.Seconds(2);
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Delay } ");
                }
                else
                {
                    doesNotExist.Append(" { Delay } ");
                }
                //EOT/Caboose tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTabInfo,
                                                          Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { EOTCaboose } ");
                }
                else
                {
                    doesNotExist.Append(" { EOTCaboose } ");
                }
                //Rail car tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTabInfo,
                                                          Trainsrepo.Train_Sheet.Railcar.RailcarTextInfo);
                if(Trainsrepo.Train_Sheet.Railcar.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { Railcar } ");
                }
                else
                {
                    doesNotExist.Append(" { Railcar } ");
                }
                //History tab
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTabInfo,
                                                          Trainsrepo.Train_Sheet.History.HistoryTable.SelfInfo);
                if(Trainsrepo.Train_Sheet.History.HistoryTable.VerticalScrollBarInfo.Exists(0))
                {
                    exist.Append(" { History } ");
                }
                else
                {
                    doesNotExist.Append(" { History } ");
                }
                if(validateScrollExists)
                {
                    if(exist.Length>0)
                    {
                        Ranorex.Report.Success("Success","Scroll bar exists in "+exist+".");
                    }
                    if(doesNotExist.Length>0)
                    {
                        Ranorex.Report.Error("Failure","Scroll bar does not exists in "+doesNotExist+".");
                    }
                }
                else
                {
                    if(exist.Length>0)
                    {
                        Ranorex.Report.Error("Failure","Scroll bar exists in "+exist+".");
                    }
                    if(doesNotExist.Length>0)
                    {
                        Ranorex.Report.Success("Success","Scroll bar does not exists in "+doesNotExist+".");
                    }
                }
                
                exist.Clear();
                doesNotExist.Clear();
                if(closeForms)
                {
                    NS_CloseTrainsheet();
                }
            }
        }
        
        /// <summary>
        /// Opens Train Schedule from Main Menu if not already open
        /// </summary>
        /// <param name="closeForm">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_OpenTrainSchedule_MainMenu()
        {
            if (Trainsrepo.Train_Schedule.SelfInfo.Exists(0))
            {
                return;
            }
            else
            {
                //click on Train Menu
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo, MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                
                //Click Train Schedule in trains menu
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(MainMenurepo.PDS_Main_Menu.TrainsMenu.TrainScheduleInfo,MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
                if (!Trainsrepo.Train_Schedule.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Failure("Train Schedule Form does not Open");
                } else {
                    Ranorex.Report.Success("Train Schedule Form opened successfully");
                }
            }
            return;
            
        }
        
        [UserCodeMethod]
        public static string NS_FillTrainScheduleHeader_UI(string trainSymbol, string scac, string originDate, string trainGroup, string category, string reportingType)
        {
            string feedback = "";
            Ranorex.Report.Info("Using Train Symbol {"+trainSymbol+"}");
            Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainSymbol);
            Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
            feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (feedback != "")
            {
                return feedback;
            }
            
            //Set SCAC
            if (Trainsrepo.Train_Schedule.SCAC.SCACText.GetAttributeValue<string>("SelectedItemText") != scac)
            {
                Trainsrepo.SCAC = scac;
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACTextInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACList.SCACListItemBySCACInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
            }
            
            Trainsrepo.Train_Schedule.OriginDate.OriginDateText.Element.SetAttributeValue("Text", originDate);
            Trainsrepo.Train_Schedule.OriginDate.OriginDateText.PressKeys("{TAB}");
            feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (feedback != "")
            {
                return feedback;
            }
            
            //Click Open button to fill out the rest of the train schedule header.
            Trainsrepo.Train_Schedule.OpenButton.Click();
            int retries = 0;
            while (Trainsrepo.Train_Schedule.OpenButton.Enabled && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                Trainsrepo.Train_Schedule.OpenButton.Click();
            }
            if (Trainsrepo.Train_Schedule.OpenButton.Enabled)
            {
                feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (feedback != "")
                {
                    return feedback;
                }
            }
            
            //Set Train Group
            if (Trainsrepo.Train_Schedule.TrainGroup.TrainGroupText.GetAttributeValue<string>("SelectedItemText") != trainGroup)
            {
                if (trainGroup != "")
                {
                    Trainsrepo.TrainGroup = trainGroup;
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.TrainGroup.TrainGroupTextInfo, Trainsrepo.Train_Schedule.TrainGroup.TrainGroupTextInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.TrainGroup.TrainGroupList.TrainGroupListItemByTrainGroupInfo, Trainsrepo.Train_Schedule.TrainGroup.TrainGroupList.SelfInfo);
                }
            }
            
            //Set Category
            if (Trainsrepo.Train_Schedule.Category.CategoryText.GetAttributeValue<string>("SelectedItemText") != category)
            {
                Trainsrepo.Category = category;
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.Category.CategoryTextInfo, Trainsrepo.Train_Schedule.Category.CategoryTextInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Category.CategoryList.CategoryListItemByCategoryInfo, Trainsrepo.Train_Schedule.Category.CategoryList.SelfInfo);
            }
            
            //Set Reporting Type
            Trainsrepo.Train_Schedule.ReportingTypeText.Element.SetAttributeValue("Text", reportingType);
            Trainsrepo.Train_Schedule.ReportingTypeText.PressKeys("{TAB}");
            feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (feedback != "")
            {
                return feedback;
            }
            
            return feedback;
        }
        
        [UserCodeMethod]
        public static void NS_CreateTrainScheduleHeader_UI(string trainSeed, string section, string scac, string originDateDayOffset, string trainGroup, string category, string reportingType, string expectedFeedback, bool reset, bool clearForm, bool closeForm)
        {
            NS_OpenTrainSchedule_MainMenu();
            
            string trainSymbol = trainSeed;
            string originDate = originDateDayOffset;
            if (trainSeed.Length <= 3)
            {
                PDS_CORE.Code_Utils.NS_TrainID.CreateTrainID(trainSeed, section, scac, originDateDayOffset);
                trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
                int temp;
                if (Int32.TryParse(originDateDayOffset, out temp))
                {
                    originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
                }
            }
            if (section != "")
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            
            if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
                }
            }
            
            
            string obtainedFeedback = NS_FillTrainScheduleHeader_UI(trainSymbol, scac, originDate, trainGroup, category, reportingType);
            
            if (obtainedFeedback != "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            } else {
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected feedback of {"+expectedFeedback+"}");
                }
            }
            
            if (reset)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            
            if (clearForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
            }
            
            return;
        }
        
        public static string NS_FillTrainScheduleRow(int rowIndex, string opSta, string sta, string std, bool crew, bool setout, bool pickup, bool fuel, bool inspection, bool passenger, bool foreign, bool turnpoint, bool insertRow, bool apply)
        {
            string feedback = "";
            Trainsrepo.TrainScheduleIndex = rowIndex.ToString();
            
            System.DateTime now = System.DateTime.Now;
            
            //If it's already equal we don't need to touch it
            //Set Opsta
            if (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.GetAttributeValue<string>("StationId") != opSta)
            {
                //If the cell editor doesn't exist then we should select it first
                if (!Trainsrepo.Train_Schedule.TrainScheduleTable.OpStaCellEditorInfo.Exists(0))
                {
                    Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.Click();
                }
                
                Trainsrepo.Train_Schedule.TrainScheduleTable.OpStaCellEditor.Element.SetAttributeValue("Text", opSta);
                Trainsrepo.Train_Schedule.TrainScheduleTable.OpStaCellEditor.PressKeys("{TAB}");
                feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (feedback != "")
                {
                    return feedback;
                }
            }

            //If the cell editor doesn't exist then we should select it first
            if (!Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditorInfo.Exists(0))
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.STA.STAText.Click();
            }
            
            Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.Element.SetAttributeValue("Text", sta);
            Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.PressKeys("{TAB}");
            feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (feedback != "")
            {
                return feedback;
            }
            
            
            //Set STD
            //If the cell editor doesn't exist then we should select it first
            if (!Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditorInfo.Exists(0))
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.STD.STDText.Click();
            }
            
            Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.Element.SetAttributeValue("Text", std);
            Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.PressKeys("{TAB}");
            feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (feedback != "")
            {
                return feedback;
            }
            
            bool foundCrew = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Crew.GetAttributeValue<string>("Text") == "true");
            if (foundCrew != crew)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Crew.Click();
            }
            
            bool foundSetOut = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.SetOut.GetAttributeValue<string>("Text") == "true");
            if (foundSetOut != setout)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.SetOut.Click();
            }
            
            bool foundPickup = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Pickup.GetAttributeValue<string>("Text") == "true");
            if (foundPickup != pickup)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Pickup.Click();
            }
            
            bool foundFuel = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Fuel.GetAttributeValue<string>("Text") == "true");
            if (foundFuel != fuel)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Fuel.Click();
            }
            
            bool foundInspection = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Inspection.GetAttributeValue<string>("Text") == "true");
            if (foundInspection != inspection)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Inspection.Click();
            }
            
            bool foundPassenger = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Passenger.GetAttributeValue<string>("Text") == "true");
            if (foundPassenger != passenger)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Passenger.Click();
            }
            
            bool foundForeign = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Foreign.GetAttributeValue<string>("Text") == "true");
            if (foundForeign != foreign)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Foreign.Click();
            }
            
            bool foundTurnPoint = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.TurnPoint.GetAttributeValue<string>("Text") == "true");
            if (foundTurnPoint != turnpoint)
            {
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.TurnPoint.Click();
            }
            
            if (insertRow)
            {
                Trainsrepo.Train_Schedule.InsertRowButton.Click();
                feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (feedback != "")
                {
                    return feedback;
                }
            }
            
            if (apply)
            {
                Trainsrepo.Train_Schedule.ApplyButton.Click();
                feedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (feedback != "")
                {
                    return feedback;
                }
            }
            
            return feedback;
        }
        
        [UserCodeMethod]
        public static void NS_CreateTrainScheduleAddScheduleRow_UI(string trainSeed, string opSta, string staOffsetDays, string staOffsetMinutes, string staTimeZone, string stdOffsetDays, string stdOffsetMinutes, string stdTimeZone, bool crew, bool setout, bool pickup, bool fuel, bool inspection, bool passenger, bool foreign, bool turnpoint, bool insertRow, bool apply, bool reset, bool clearForm, string expectedFeedback, bool closeForms)
        {
            if (!Trainsrepo.Train_Schedule.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Train Schedule form is not open, no row can be added");
            }

            //Find the last row.
            int rowCount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            
            System.DateTime now = System.DateTime.Now;
            
            //Check if sta is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
            string sta = staOffsetMinutes;
            string staText = sta;
            int staOffsetInt;
            if (int.TryParse(staOffsetMinutes, out staOffsetInt) && staOffsetMinutes.Length < 4)
            {
                int staDaysOffsetInt;
                if (int.TryParse(staOffsetDays, out staDaysOffsetInt))
                {
                    sta = now.AddMinutes(staOffsetInt).AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                } else {
                    sta = now.AddMinutes(staOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                }
                if (staTimeZone != "")
                {
                    staText = sta + " " + staTimeZone;
                }
            } else if (int.TryParse(staOffsetMinutes, out staOffsetInt) && staOffsetMinutes.Length == 4)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                System.DateTime AdjustedTime;
                System.DateTime.TryParseExact(staOffsetMinutes, "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                int staDaysOffsetInt;
                if (int.TryParse(staOffsetDays, out staDaysOffsetInt))
                {
                    sta = AdjustedTime.AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                } else {
                    sta = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                }
                
                if (staTimeZone != "")
                {
                    staText = sta + " " + staTimeZone;
                }
            }
            
            
            //Check if std is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
            string std = stdOffsetMinutes;
            string stdText = std;
            int stdOffsetInt;
            if (int.TryParse(stdOffsetMinutes, out stdOffsetInt) && stdOffsetMinutes.Length < 4)
            {
                int stdDaysOffsetInt;
                if (int.TryParse(stdOffsetDays, out stdDaysOffsetInt))
                {
                    std = now.AddMinutes(stdOffsetInt).AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                } else {
                    std = now.AddMinutes(stdOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                }
                if (stdTimeZone != "")
                {
                    stdText = std + " " + stdTimeZone;
                }
            } else if (int.TryParse(stdOffsetMinutes, out stdOffsetInt) && stdOffsetMinutes.Length == 4)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                System.DateTime AdjustedTime;
                System.DateTime.TryParseExact(stdOffsetMinutes, "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                int stdDaysOffsetInt;
                if (int.TryParse(stdOffsetDays, out stdDaysOffsetInt))
                {
                    std = AdjustedTime.AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                } else {
                    std = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                }
                
                if (stdTimeZone != "")
                {
                    stdText = std + " " + stdTimeZone;
                }
            }
            
            string obtainedFeedback = NS_FillTrainScheduleRow(rowCount - 1,opSta, staText, stdText, crew, setout, pickup, fuel, inspection, passenger, foreign, turnpoint, insertRow, apply);
            
            if (obtainedFeedback != "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            } else {
                NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staText, stdText);
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected feedback of {"+expectedFeedback+"}");
                }
            }
            
            if (reset)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            
            if (clearForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
            }
            
            if (closeForms)
            {
                Trainsrepo.Train_Schedule.CancelButton.Click();
                if (Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
            }
            return;

        }
        
        /// <summary>
        /// Create Train Schedule through UI
        /// </summary>
        /// <param name="enabled">ex:closes the form as per the user input</param>
        /// <param name="trainSymbol">train Symbol</param>
        /// <param name="scac">ex:scac</param>
        /// <param name="originDay">ex:originDay</param>
        /// <param name="trainGroup">ex:trainGroup</param>
        /// <param name="category">ex:category</param>
        /// <param name="reportingType">ex:reportingType</param>
        /// <param name="station">ex:station</param>
        /// <param name="STA">ex:STA</param>
        /// <param name="STD">ex:STD</param>
        /// <param name="timeZone">ex:timeZone</param>
        /// <param name="dateFormat">ex:dateFormat</param>
        /// <param name="trainSeed">ex:trainSeed</param>
        /// <param name="section">ex:section</param>
        /// <param name="originDay">ex:originDay</param>
        /// <param name="expectedFeedback">ex:expectedFeedback</param>
        /// <param name="closeForms">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_CreateTrainSchedulePipedStations_UI(string trainSeed, string section, string scac, string originDateDayOffset, string trainGroup, string trainCategory, string reportingType, string stations, bool closeForms)
        {
            //If this function is being used, expected feedback should be nothing as this is the manual equivalent to an MIS message. If you want expected feedback use the parts by themselves
            string expectedFeedback = "";
            bool reset = false;
            bool clearForm = false;
            NS_OpenTrainSchedule_MainMenu();
            
            string trainSymbol = trainSeed;
            string originDate = originDateDayOffset;
            if (trainSeed.Length <= 3)
            {
                PDS_CORE.Code_Utils.NS_TrainID.CreateTrainID(trainSeed, section, scac, originDateDayOffset);
                trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
                originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
            }
            
            if (section != "")
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            
            if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
                }
            }
            
            string obtainedFeedback = NS_FillTrainScheduleHeader_UI(trainSymbol, scac, originDate, trainGroup, trainCategory, reportingType);
            
            if (obtainedFeedback != "")
            {
                Ranorex.Report.Failure("Obtained Feedback {" + obtainedFeedback + "}.");
                return;
            }
            
            string[] stationList = stations.Split('|');
            int elementCount = 19;
            bool insertRow = true;
            bool apply = false;
            bool lastRowCloseForms = false;
            for (int i = 0; i < stationList.Length; i+=elementCount)
            {
                if (i + elementCount + 1 >= stationList.Length)
                {
                    insertRow = false;
                    apply = true;
                    if (closeForms)
                    {
                        lastRowCloseForms = true;
                    }
                }
                NS_CreateTrainScheduleAddScheduleRow_UI(trainSeed, stationList[i+1], stationList[i+2], stationList[i+3], stationList[i+4], stationList[i+5], stationList[i+6], stationList[i+7], (stationList[i+8].ToLower() == "y"), (stationList[i+10].ToLower() == "y"), (stationList[i+11].ToLower() == "y"), (stationList[i+12].ToLower() == "y"), (stationList[i+13].ToLower() == "y"), (stationList[i+14].ToLower() == "y"), (stationList[i+15].ToLower() == "y"), (stationList[i+16].ToLower() == "y"), insertRow, apply, reset, clearForm, expectedFeedback, lastRowCloseForms);
            }
            
            return;
        }
        
        /// <summary>
        /// Edits Train Schedule through UI
        /// </summary>
        /// <param name="enabled">ex:closes the form as per the user input</param>
        /// <param name="trainSymbol">train Symbol</param>
        /// <param name="scac">ex:scac</param>
        /// <param name="originDay">ex:originDay</param>
        /// <param name="trainGroup">ex:trainGroup</param>
        /// <param name="category">ex:category</param>
        /// <param name="reportingType">ex:reportingType</param>
        /// <param name="station">ex:station</param>
        /// <param name="STA">ex:STA</param>
        /// <param name="STD">ex:STD</param>
        /// <param name="timeZone">ex:timeZone</param>
        /// <param name="dateFormat">ex:dateFormat</param>
        /// <param name="trainSeed">ex:trainSeed</param>
        /// <param name="section">ex:section</param>
        /// <param name="originDay">ex:originDay</param>
        /// <param name="expectedFeedback">ex:expectedFeedback</param>
        /// <param name="closeForms">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        public static void NS_EditTrainSchedulePipedStations_UI(string trainSeed, string trainGroup, string trainCategory, string reportingType, string stations, bool reset, bool clearForm, bool closeForms, string expectedFeedback)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
            
            NS_OpenTrainSchedule_MainMenu();
            
            if (section != "")
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            
            if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
                }
            }
            string obtainedFeedback = NS_FillTrainScheduleHeader_UI(trainSymbol, scac, originDate, trainGroup, trainCategory, reportingType);
            
            if (obtainedFeedback != "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                if (reset)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
                if (clearForm)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                }
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    
                }
                return;
            }
            
            //Find the last row.
            int rowCount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            System.DateTime now = System.DateTime.Now;
            int elementCount = 19;
            string[] stationList = stations.Split('|');
            int numberOfStations = stationList.Length / elementCount;
            
            bool insertRow = false;
            
            bool apply = false;
            for (int i = 0; i < numberOfStations; i++)
            {
                if (numberOfStations > rowCount && i < numberOfStations - 1 && i >= rowCount - 1 )
                {
                    insertRow = true;
                } else {
                    insertRow = false;
                }
                if (i == numberOfStations - 1)
                {
                    apply = true;
                }
                //Check if sta is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
                string sta = stationList[(i*elementCount)+3];
                string staText = sta;
                int staOffsetInt;
                if (int.TryParse(stationList[(i*elementCount)+3], out staOffsetInt) && stationList[(i*elementCount)+3].Length < 4)
                {
                    int staDaysOffsetInt;
                    if (int.TryParse(stationList[(i*elementCount)+2], out staDaysOffsetInt))
                    {
                        sta = now.AddMinutes(staOffsetInt).AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    } else {
                        sta = now.AddMinutes(staOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    }
                    if (stationList[(i*elementCount)+4] != "")
                    {
                        staText = sta + " " + stationList[(i*elementCount)+4];
                    }
                } else if (int.TryParse(stationList[(i*elementCount)+3], out staOffsetInt) && stationList[(i*elementCount)+3].Length == 4)
                {
                    CultureInfo enUS = new CultureInfo("en-US");
                    System.DateTime AdjustedTime;
                    System.DateTime.TryParseExact(stationList[(i*elementCount)+3], "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                    int staDaysOffsetInt;
                    if (int.TryParse(stationList[(i*elementCount)+2], out staDaysOffsetInt))
                    {
                        sta = AdjustedTime.AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    } else {
                        sta = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                    }
                    
                    if (stationList[(i*elementCount)+4] != "")
                    {
                        staText = sta + " " + stationList[(i*elementCount)+4];
                    }
                }
                
                
                //Check if std is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
                string std = stationList[(i*elementCount)+6];
                string stdText = std;
                int stdOffsetInt;
                if (int.TryParse(stationList[(i*elementCount)+6], out stdOffsetInt) && stationList[(i*elementCount)+6].Length < 4)
                {
                    int stdDaysOffsetInt;
                    if (int.TryParse(stationList[(i*elementCount)+5], out stdDaysOffsetInt))
                    {
                        std = now.AddMinutes(stdOffsetInt).AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    } else {
                        std = now.AddMinutes(stdOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    }
                    if (stationList[(i*elementCount)+7] != "")
                    {
                        stdText = std + " " + stationList[(i*elementCount)+7];
                    }
                } else if (int.TryParse(stationList[(i*elementCount)+6], out stdOffsetInt) && stationList[(i*elementCount)+6].Length == 4)
                {
                    CultureInfo enUS = new CultureInfo("en-US");
                    System.DateTime AdjustedTime;
                    System.DateTime.TryParseExact(stationList[(i*elementCount)+6], "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                    int stdDaysOffsetInt;
                    if (int.TryParse(stationList[(i*elementCount)+5], out stdDaysOffsetInt))
                    {
                        std = AdjustedTime.AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                    } else {
                        std = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                    }
                    
                    if (stationList[(i*elementCount)+7] != "")
                    {
                        stdText = std + " " + stationList[(i*elementCount)+7];
                    }
                }
                
                obtainedFeedback = NS_FillTrainScheduleRow(i ,stationList[(i*elementCount)+1], staText, stdText, (stationList[(i*elementCount)+8] == "y"), (stationList[(i*elementCount)+9] == "y"), (stationList[(i*elementCount)+10] == "y"), (stationList[(i*elementCount)+11] == "y"), (stationList[(i*elementCount)+12] == "y"), (stationList[(i*elementCount)+13] == "y"), (stationList[(i*elementCount)+14] == "y"), (stationList[(i*elementCount)+15] == "y"), insertRow, apply);
                
                if (obtainedFeedback != "")
                {
                    break;
                } else {
                    if (i >= rowCount)
                    {
                        NS_TrainID.getTrainObject(trainSeed).AddTrainScheduleSTASTDRow(staText, stdText);
                    } else {
                        NS_TrainID.getTrainObject(trainSeed).EditTrainScheduleSTASTDRow(i, staText, stdText);
                    }
                }
            }
            
            if (obtainedFeedback == "")
            {
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected feedback of {"+expectedFeedback+"}");
                }
            } else {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            }
            
            if (reset)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            
            if (clearForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
            }
            
            if (closeForms)
            {
                Trainsrepo.Train_Schedule.CancelButton.Click();
                if (Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
            }
            return;
        }
        
        /// <summary>
        /// Insert Row In TrainSchedule
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="stations">Input:stations</param>
        /// <param name="opsta">Input:opsta</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_InsertRowsPipedStationsByOpsta_UI(string trainSeed, string stations, bool reset, bool clearForm, bool closeForms, string expectedFeedback)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
            
            NS_OpenTrainSchedule_MainMenu();
            
            if (section != "")
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            string obtainedFeedback = "";
            
            if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
                }
            }
            
            if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
            {
                Ranorex.Report.Info("Using Train Symbol {"+trainSymbol+"}");
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainSymbol);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (obtainedFeedback != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                    if (reset)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    }
                    if (clearForm)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        
                    }
                    return;
                }
                
                //Set SCAC
                if (Trainsrepo.Train_Schedule.SCAC.SCACText.GetAttributeValue<string>("SelectedItemText") != scac)
                {
                    Trainsrepo.SCAC = scac;
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACTextInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACList.SCACListItemBySCACInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                }
                
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.Element.SetAttributeValue("Text", originDate);
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.PressKeys("{TAB}");
                obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (obtainedFeedback != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                    if (reset)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    }
                    if (clearForm)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        
                    }
                    return;
                }
                
                //Click Open button to fill out the rest of the train schedule header.
                Trainsrepo.Train_Schedule.OpenButton.Click();
                int retries = 0;
                while (Trainsrepo.Train_Schedule.OpenButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Schedule.OpenButton.Click();
                }
                if (Trainsrepo.Train_Schedule.OpenButton.Enabled)
                {
                    obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                    if (obtainedFeedback != "")
                    {
                        CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                        if (reset)
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        }
                        if (clearForm)
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                        }
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            
                        }
                        return;
                    }
                }
            }
            
            int rowCount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            
            if (rowCount <= 1)
            {
                Ranorex.Report.Error("Train Schedule not successfully loaded for train {" + trainId + "}, schedule may not yet exist");
                
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                
                return;
            }
            
            System.DateTime now = System.DateTime.Now;
            int elementCount = 19;
            string[] stationList = stations.Split('|');
            int numberOfStations = stationList.Length / elementCount;
            
            bool insertRow = false;
            
            bool apply = false;
            for (int i = 0; i < numberOfStations; i++)
            {
                Trainsrepo.TrainScheduleIndex = i.ToString();
                if (stationList[(i*elementCount)+1] != Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.GetAttributeValue<string>("StationId"))
                {
                    if (i+1 > rowCount)
                    {
                        Ranorex.Report.Error("There are insufficient rows for {" + stationList[(i*elementCount)+1] + "} to be inserted.");
                        break;
                    } else {
                        if (numberOfStations == rowCount + 1)
                        {
                            apply = true;
                        }
                        
                        GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.MenuCellInfo, Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.InsertRowInfo, Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.SelfInfo);
                        if (Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count != rowCount + 1)
                        {
                            obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.TextValue;
                            if (obtainedFeedback == "")
                            {
                                Ranorex.Report.Error("Failed to add Row to train Schedule from index {" + (i+1).ToString() + "} with no feedback");
                            }
                            break;
                        }
                        
                        //Check if sta is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
                        string sta = stationList[(i*elementCount)+3];
                        string staText = sta;
                        int staOffsetInt;
                        if (int.TryParse(stationList[(i*elementCount)+3], out staOffsetInt) && stationList[(i*elementCount)+3].Length < 4)
                        {
                            int staDaysOffsetInt;
                            if (int.TryParse(stationList[(i*elementCount)+2], out staDaysOffsetInt))
                            {
                                sta = now.AddMinutes(staOffsetInt).AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            } else {
                                sta = now.AddMinutes(staOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            }
                            if (stationList[(i*elementCount)+4] != "")
                            {
                                staText = sta + " " + stationList[(i*elementCount)+4];
                            }
                        } else if (int.TryParse(stationList[(i*elementCount)+3], out staOffsetInt) && stationList[(i*elementCount)+3].Length == 4)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            System.DateTime AdjustedTime;
                            System.DateTime.TryParseExact(stationList[(i*elementCount)+3], "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                            int staDaysOffsetInt;
                            if (int.TryParse(stationList[(i*elementCount)+2], out staDaysOffsetInt))
                            {
                                sta = AdjustedTime.AddDays(staDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            } else {
                                sta = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                            }
                            
                            if (stationList[(i*elementCount)+4] != "")
                            {
                                staText = sta + " " + stationList[(i*elementCount)+4];
                            }
                        }
                        
                        
                        //Check if std is a int, if it's not, use it as-is and don't bother using a timezone, else convert and use timezone
                        string std = stationList[(i*elementCount)+6];
                        string stdText = std;
                        int stdOffsetInt;
                        if (int.TryParse(stationList[(i*elementCount)+6], out stdOffsetInt) && stationList[(i*elementCount)+6].Length < 4)
                        {
                            int stdDaysOffsetInt;
                            if (int.TryParse(stationList[(i*elementCount)+5], out stdDaysOffsetInt))
                            {
                                std = now.AddMinutes(stdOffsetInt).AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            } else {
                                std = now.AddMinutes(stdOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            }
                            if (stationList[(i*elementCount)+7] != "")
                            {
                                stdText = std + " " + stationList[(i*elementCount)+7];
                            }
                        } else if (int.TryParse(stationList[(i*elementCount)+6], out stdOffsetInt) && stationList[(i*elementCount)+6].Length == 4)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            System.DateTime AdjustedTime;
                            System.DateTime.TryParseExact(stationList[(i*elementCount)+6], "HHmm", enUS, DateTimeStyles.None, out AdjustedTime);
                            int stdDaysOffsetInt;
                            if (int.TryParse(stationList[(i*elementCount)+5], out stdDaysOffsetInt))
                            {
                                std = AdjustedTime.AddDays(stdDaysOffsetInt).ToString("MM-dd-yyyy hh:mm t");
                            } else {
                                std = AdjustedTime.ToString("MM-dd-yyyy hh:mm t");
                            }
                            
                            if (stationList[(i*elementCount)+7] != "")
                            {
                                stdText = std + " " + stationList[(i*elementCount)+7];
                            }
                        }
                        
                        obtainedFeedback = NS_FillTrainScheduleRow(i ,stationList[(i*elementCount)+1], staText, stdText, (stationList[(i*elementCount)+8] == "y"), (stationList[(i*elementCount)+9] == "y"), (stationList[(i*elementCount)+10] == "y"), (stationList[(i*elementCount)+11] == "y"), (stationList[(i*elementCount)+12] == "y"), (stationList[(i*elementCount)+13] == "y"), (stationList[(i*elementCount)+14] == "y"), (stationList[(i*elementCount)+15] == "y"), insertRow, apply);
                        
                        if (obtainedFeedback != "")
                        {
                            break;
                        } else {
                            rowCount++;
                            NS_TrainID.getTrainObject(trainSeed).InsertTrainScheduleSTASTDRow(i, staText, stdText);
                        }
                    }
                }
                
            }
            
            if (obtainedFeedback == "")
            {
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected feedback of {"+expectedFeedback+"}");
                }
            } else {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            }
            
            if (reset)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            
            if (clearForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
            }
            
            if (closeForms)
            {
                Trainsrepo.Train_Schedule.CancelButton.Click();
                if (Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
            }
            return;
        }
        
        // <summary>
        /// Validate Train Schedule through UI
        /// </summary>
        /// <param name="enabled">ex:closes the form as per the user input</param>
        /// <param name="trainSeed">train Symbol</param>
        /// <param name="opsta"></param>
        /// <param name="staOffsetMinutes">ex:originDay</param>
        /// <param name="staTimeZone">ex:trainGroup</param>
        /// <param name="stdOffsetMinutes">ex:category</param>
        /// <param name="stdTimeZone">ex:reportingType</param>
        /// <param name="crew">ex:station</param>
        /// <param name="setout">ex:STA</param>
        /// <param name="pickup">ex:STD</param>
        /// <param name="fuel">ex:timeZone</param>
        /// <param name="inspection">ex:dateFormat</param>
        /// <param name="passenger">ex:trainSeed</param>
        /// <param name="foreign">ex:section</param>
        /// <param name="turnpoint">ex:originDay</param>
        /// <param name="validateDoesExist"></param>
        /// <param name="closeForms">ex:closes the form as per the user input</param>
        [UserCodeMethod]
        
        public static void NS_ValidateTrainScheduleRow_TrainSchedule(string trainSeed, string expOpsta, bool crew, bool setout, bool pickup, bool fuel, bool inspection, bool passenger, bool foreign,
                                                                     bool turnpoint,bool closeForms, bool validateExist)
        {
            NS_OpenTrainSchedule_MainMenu();
            
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            if (section != null)
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            
            //If Train Symbol text is not enabled, it means that line has already been input and Open has been pressed, so skip the first 3 items and open.
            if (Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                //Set Train Symbol and check for feedback
                Ranorex.Report.Info("Using Train Symbol {"+trainSymbol+"}");
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainSymbol);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                if (Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    Ranorex.Report.Error("Got feedback {" + Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") + "} when inputting train symbol  {" + trainSymbol+ "}");
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                    }
                    return;
                }
                
                //Set SCAC
                string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
                if (Trainsrepo.Train_Schedule.SCAC.SCACText.GetAttributeValue<string>("SelectedItemText") != scac)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACTextInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACList.SCACListItemBySCACInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                }
                
                
                string originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.Element.SetAttributeValue("Text", originDate);
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.PressKeys("{TAB}");
                if (Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    Ranorex.Report.Error("Got feedback {" + Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") + "} when inputting origin date  {" + originDate+ "}");
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                    }
                    return;
                }
                
                //Click Open button to fill out the rest of the train schedule header.
                Trainsrepo.Train_Schedule.OpenButton.Click();
                int retries = 0;
                while (Trainsrepo.Train_Schedule.OpenButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Schedule.OpenButton.Click();
                }
                if (Trainsrepo.Train_Schedule.OpenButton.Enabled)
                {
                    if (Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") != "")
                    {
                        Ranorex.Report.Error("Got feedback {" + Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text") + "} when opening Train Schedule");
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                        }
                        return;
                    }
                    
                    Ranorex.Report.Error("No Feedback found but Open Button on Train Schedule is still enabled");
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                    }
                    return;
                }
            }

            int rowcount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            if (rowcount <= 1)
            {
                Ranorex.Report.Error("Train Schedule not successfully loaded for train {" + trainSymbol + "}, schedule may not yet exist");
                if(closeForms)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                }
                return;
            }
            
            Ranorex.Report.Info(String.Format("Found {0} Rows in the Train Schedule Form.", rowcount.ToString()));
            bool resultFound = false;
            for (int i = 0; i < rowcount; i++)
            {
                Trainsrepo.TrainScheduleIndex = i.ToString();
                
                //verifying the Opsta data
                string currentOpsta = Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.GetAttributeValue<string>("StationId").ToString().Trim();
                
                if(!currentOpsta.Equals(expOpsta, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                //Verifying the Crew Value
                bool foundCrew = Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Crew.GetAttributeValue<bool>("Selected");
                
                if (foundCrew != crew)
                {
                    continue;
                }
                
                //Verifying the Crew Value
                bool foundSetOut = Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.SetOut.GetAttributeValue<bool>("Selected");
                
                if (foundSetOut != setout)
                {
                    continue;
                }
                
                //Verifying the Pickup Value
                bool foundPickup = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Pickup.GetAttributeValue<bool>("Selected"));
                
                if (foundPickup != pickup)
                {
                    continue;
                }
                
                //Verifying the Fuel Value
                bool foundFuel = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Fuel.GetAttributeValue<bool>("Selected"));
                
                if (foundFuel != fuel)
                {
                    continue;
                }
                
                //Verifying the Inspection Value
                bool foundInspection = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Inspection.GetAttributeValue<bool>("Selected"));
                
                if (foundInspection != inspection)
                {
                    
                    continue;
                }
                
                //Verifying the Passenger Value
                bool foundPassenger = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Passenger.GetAttributeValue<bool>("Selected"));
                
                if (foundPassenger != passenger)
                {
                    continue;
                }
                
                //Verifying the Foreign Value
                bool foundForeign = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.Foreign.GetAttributeValue<bool>("Selected"));
                
                if (foundForeign != foreign)
                {
                    continue;
                }
                //Verifying the TrunPoint Value
                bool foundTurnPoint = (Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.TurnPoint.GetAttributeValue<bool>("Selected"));
                
                if (foundTurnPoint != turnpoint)
                {
                    continue;
                }
                
                // Verifying the sta Value
                
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.STA.STAText.Click();
                string foundSta = Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.GetAttributeValue<string>("Text");
                string sta = NS_TrainID.getTrainObject(trainSeed).GetTrainScheduleSTASTDForRow(i).STATime;
                
                if (!foundSta.Equals(sta))
                {
                    resultFound = false;
                    continue;
                }
                
                // Verifying the std Value
                
                Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.STA.STAText.PressKeys("{TAB}");
                string foundStd = Trainsrepo.Train_Schedule.TrainScheduleTable.StaAndStdEditor.GetAttributeValue<string>("Text");
                string std = NS_TrainID.getTrainObject(trainSeed).GetTrainScheduleSTASTDForRow(i).STDTime;
                
                if (!foundStd.Equals(std))
                {
                    
                    resultFound = false;
                    continue;
                }
                resultFound = true;
                break;
            }
            
            if (validateExist == resultFound)
            {
                Ranorex.Report.Success("Expected Train Schedule Row was " + (resultFound ? "found" : "not found"));
            }
            else
            {
                Ranorex.Report.Failure("Expected Train Schedule Row was " + (resultFound ? "found" : "not found"));
            }
            
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.WindowControls.CloseInfo,Trainsrepo.Train_Schedule.Save_Changes.SelfInfo);
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Save_Changes.YesButtonInfo,Trainsrepo.Train_Schedule.SelfInfo);
            }
        }
        /// <summary>
        /// Delete TrainSechedule through UI
        /// </summary>
        /// <param name="trainSeed">Input:Trainseed</param>
        /// <param name="closeForms"</param>
        [UserCodeMethod]
        public static void NS_AnnulTrainSchedule_TrainSchedule(string trainSeed, bool closeForms)
        {
            // Open Train Schedule MainMenu
            NS_OpenTrainSchedule_MainMenu();
            
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Info(NS_TrainID.GetTrainId(trainSeed));
                if (trainSeed == "")
                {
                    Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                    return;
                }
                else
                {
                    trainId = trainSeed;
                }
            }
            
            
            //Set Train Symbol
            if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainId.Split(' ')[0])
            {
                if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
                {
                    Trainsrepo.Train_Schedule.ResetButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
                Trainsrepo.Train_Schedule.TrainIDText.Click();
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainId);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.OpenButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
            }

            if (Trainsrepo.Train_Schedule.TrainIDText.Enabled && Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainId.Split(' ')[0])
            {
                Ranorex.Report.Error("Unable to Open schedule for Train Id {"+trainId+"}.");
                Ranorex.Report.Screenshot(Trainsrepo.Train_Schedule.Self.Element);
                if(closeForms)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                }
            }
            
            Ranorex.Report.Info("Opened Train Schedule Form is for TrainId {"+trainId+"}");
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.MainMenuBar.FileButtonInfo, Trainsrepo.Train_Schedule.FileMenu.AnnulInfo);
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.FileMenu.AnnulInfo, Trainsrepo.Train_Schedule.Confirm_Annul.OkButtonInfo);
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Confirm_Annul.OkButtonInfo, Trainsrepo.Train_Schedule.Confirm_Annul.SelfInfo);
            Ranorex.Report.Success("Train Schedule has been annuled for the TrainId {"+trainId+"}");
            
            if(closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
            }
        }
        /// <summary>
        /// Validate No TrainSechedule is present for the Train through UI
        /// </summary>
        /// <param name="trainSeed">Input:Trainseed</param>
        /// <param name="closeForms"</param>
        [UserCodeMethod]
        public static void NS_ValidateNoTrainSchedule_TrainSchedule(string trainSeed, bool closeForms)
        {
            NS_OpenTrainSchedule_MainMenu();
            
            
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            Ranorex.Report.Info(trainId);
            if (trainId == null)
            {
                
                if (trainSeed == "")
                {
                    Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                    return;
                }
                else
                {
                    trainId = trainSeed;
                }
                
            }
            //Set Train Symbol
            if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainId.Split(' ')[0])
            {
                if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
                {
                    Trainsrepo.Train_Schedule.ResetButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
                Trainsrepo.Train_Schedule.TrainIDText.Click();
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainId);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.OpenButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
            }
            int rowcount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            if (rowcount <= 1)
            {
                Ranorex.Report.Success("Train Schedule not loaded for train {" + trainId + "}, schedule does not exist");
                if(closeForms)
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                }
                return;
            }
            else
            {
                Ranorex.Report.Failure("Train Schedule still exist not deleted for train {" + trainId + "}");
                
            }
        }
        
        /// <summary>
        /// Delete Row From Train Schedule
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="opsta">Input:opsta</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_DeleteRowFromTrainScheduleByOpsta(string trainSeed, string opsta, bool apply, bool reset, bool clearForm, bool closeForms, string expectedFeedback)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed).ToString("MM-dd-yyyy");
            
            NS_OpenTrainSchedule_MainMenu();
            
            if (section != "")
            {
                trainSymbol = trainSymbol + "-" + section;
            }
            string obtainedFeedback = "";
            
            if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
            {
                if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
                }
            }
            
            if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainSymbol)
            {
                Ranorex.Report.Info("Using Train Symbol {"+trainSymbol+"}");
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainSymbol);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (obtainedFeedback != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                    if (reset)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    }
                    if (clearForm)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        
                    }
                    return;
                }
                
                //Set SCAC
                if (Trainsrepo.Train_Schedule.SCAC.SCACText.GetAttributeValue<string>("SelectedItemText") != scac)
                {
                    Trainsrepo.SCAC = scac;
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACTextInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.SCAC.SCACList.SCACListItemBySCACInfo, Trainsrepo.Train_Schedule.SCAC.SCACList.SelfInfo);
                }
                
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.Element.SetAttributeValue("Text", originDate);
                Trainsrepo.Train_Schedule.OriginDate.OriginDateText.PressKeys("{TAB}");
                obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                if (obtainedFeedback != "")
                {
                    CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                    if (reset)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                    }
                    if (clearForm)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                    }
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        
                    }
                    return;
                }
                
                //Click Open button to fill out the rest of the train schedule header.
                Trainsrepo.Train_Schedule.OpenButton.Click();
                int retries = 0;
                while (Trainsrepo.Train_Schedule.OpenButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Schedule.OpenButton.Click();
                }
                if (Trainsrepo.Train_Schedule.OpenButton.Enabled)
                {
                    obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
                    if (obtainedFeedback != "")
                    {
                        CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
                        if (reset)
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                        }
                        if (clearForm)
                        {
                            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
                        }
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                            
                        }
                        return;
                    }
                }
            }
            
            int rowCount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            
            if (rowCount <= 1)
            {
                Ranorex.Report.Error("Train Schedule not successfully loaded for train {" + trainId + "}, schedule may not yet exist");
                
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                
                return;
            }
            
            bool foundOpsta = false;
            for (int i = 0; i < rowCount; i++)
            {
                Trainsrepo.TrainScheduleIndex = i.ToString();
                if (opsta == Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.GetAttributeValue<string>("StationId"))
                {
                    foundOpsta = true;
                    GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.MenuCellInfo, Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.DeleteRowInfo, Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleMenuCellMenu.SelfInfo);
                    break;
                }
            }
            
            if (!foundOpsta)
            {
                Ranorex.Report.Error("Could not find opsta {" + opsta + "}");
            }
            
            obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (obtainedFeedback != "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            }
            
            if(apply)
            {
                Trainsrepo.Train_Schedule.ApplyButton.Click();
            }
            
            obtainedFeedback = Trainsrepo.Train_Schedule.Feedback.GetAttributeValue<string>("Text");
            if (obtainedFeedback != "")
            {
                CheckFeedbackExists(Trainsrepo.Train_Schedule.Feedback, expectedFeedback);
            } else {
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not receive expected feedback of {"+expectedFeedback+"}");
                }
            }
            
            if (reset)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.ResetButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            if (clearForm)
            {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.ClearFormButtonInfo, Trainsrepo.Train_Schedule.ApplyButtonInfo);
            }
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo,Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Validate row inserted or deleted From Train Schedule
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="actionType">Input:actionType</param>
        /// <param name="expectedOpsta">Input:expectedOpsta</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateTrainScheduleRowExistsByOpsta_TrainSchedule(string trainSeed, bool validateExists, string expectedOpsta, bool closeForms)
        {
            NS_OpenTrainSchedule_MainMenu();
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            bool resultFound = false;
            if (trainId == null)
            {
                Ranorex.Report.Info(NS_TrainID.GetTrainId(trainSeed));
                if (trainSeed == "")
                {
                    Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                    return;
                }
                else
                {
                    trainId = trainSeed;
                }
            }
            //Set Train Symbol
            if (Trainsrepo.Train_Schedule.TrainIDText.TextValue != trainId.Split(' ')[0])
            {
                if (!Trainsrepo.Train_Schedule.TrainIDText.Enabled)
                {
                    Trainsrepo.Train_Schedule.ResetButton.Click();
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                }
                Trainsrepo.Train_Schedule.TrainIDText.Click();
                Trainsrepo.Train_Schedule.TrainIDText.Element.SetAttributeValue("Text", trainId);
                Trainsrepo.Train_Schedule.TrainIDText.PressKeys("{TAB}");
                PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Schedule.OpenButtonInfo, Trainsrepo.Train_Schedule.OpenButtonInfo);
            }
            int rowcount = Trainsrepo.Train_Schedule.TrainScheduleTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Rows in the Train Schedule Form.", rowcount.ToString()));
            
            if (rowcount <= 1)
            {
                Ranorex.Report.Error("Train Schedule not successfully loaded for train {" + trainId + "}, schedule may not yet exist");
                
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Schedule.CancelButtonInfo, Trainsrepo.Train_Schedule.Cancel_Changes.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.Cancel_Changes.YesButtonInfo, Trainsrepo.Train_Schedule.SelfInfo);
                
                return;
            }
            for (int i = 0; i < rowcount; i++)
            {
                string actualOpsta= Trainsrepo.Train_Schedule.TrainScheduleTable.TrainScheduleRowByIndex.OpSta.GetAttributeValue<string>("StationId");
                if (actualOpsta.Equals(expectedOpsta,StringComparison.OrdinalIgnoreCase))
                {
                    resultFound=true;
                    break;
                }
                
            }

            if(resultFound == validateExists)
            {
                if (validateExists)
                {
                    Ranorex.Report.Success("Found Train Schedule Row with Opsta {" + expectedOpsta + "}");
                } else {
                    Ranorex.Report.Success("Did not find Train Schedule Row with Opsta {" + expectedOpsta + "}");
                }
            } else {
                if (validateExists)
                {
                    Ranorex.Report.Failure("Did not find Train Schedule Row with Opsta {" + expectedOpsta + "}");
                } else {
                    Ranorex.Report.Failure("Found Train Schedule Row with Opsta {" + expectedOpsta + "}");
                }
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Schedule.WindowControls.CloseInfo,Trainsrepo.Train_Schedule.SelfInfo);
            }
        }
        
        /// <summary>
        /// Navigate to Train > Assigned Work, select the new record with Status Eg:'To Do', right click and select Add to Trip Plan
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="status"></param>
        /// <param name="opsta"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_ClickAssignedWorkRowMenuOptionByOpsta_Trainsheet_AssignedWork(string trainSeed, string status, string opsta, string menuOption, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWorkInfo,
                                                      Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.SelfInfo);
            string train_id = NS_TrainID.GetTrainId(trainSeed);
            int rowCount = Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.Self.Rows.Count;
            if (rowCount == 0)
            {
                Ranorex.Report.Failure("No rows in assigned work table.");
                return;
            }
            
            bool foundRow = false;
            for(int i=0; i < rowCount; i++)
            {
                Trainsrepo.AssignedWorkIndex = i.ToString();
                if (Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.OpStaName.GetAttributeValue<string>("StationId").Contains(opsta)
                    && Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Status.GetAttributeValue<string>("Text").Equals(status,StringComparison.OrdinalIgnoreCase))
                {
                    foundRow = true;
                    break;
                }
            }
            
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find assigned work row with opsta {" + opsta + "} and status {" + status + "}.");
                return;
            }
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.MenuCell.Click(Location.UpperLeft);
            
            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right,Location.UpperLeft);
            switch(menuOption.ToUpper())
            {
                case "DELETE":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.Delete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.DeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Option");
                    }
                    else
                    {
                        Report.Failure("Delete button is disabled");
                    }
                    break;
                case "RESET":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.Reset.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.ResetInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Reset Option");
                    }
                    else
                    {
                        Report.Failure("Reset button is disabled");
                    }
                    break;
                case "UNDELETE":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.Undelete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.UndeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Option");
                    }
                    else
                    {
                        Report.Failure("Undelete button is disabled");
                    }
                    break;
                case "ADD":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.AddToTripPlan.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.AddToTripPlanInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Add to Trip Plan Option");
                    }
                    else
                    {
                        Report.Failure("Add To Trip Plan button is disabled");
                    }
                    break;
                case "REMOVE":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.RemoveFromTripPlan.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.RemoveFromTripPlanInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Remove from Trip Plan Option");
                    }
                    else
                    {
                        Report.Failure("Remove From Trip Plan button is disabled");
                    }
                    break;
                case "INSERT":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.InsertRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.InsertRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Insert Row Option");
                    }
                    else
                    {
                        Report.Failure("Insert Row button is disabled");
                    }
                    break;
                case "DELETEROW":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.DeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.DeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Row Option");
                    }
                    else
                    {
                        Report.Failure("Delete Row button is disabled");
                    }
                    break;
                case "UNDELETEROW":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.UndeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.UndeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Row Option");
                    }
                    else
                    {
                        Report.Failure("Undelete Row button is disabled");
                    }
                    break;
                case "MOVE":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.MoveAssignedWork.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.MoveAssignedWorkInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Move Assigned Work Option");
                    }
                    else
                    {
                        Report.Failure("Move Assigned Work button is disabled");
                    }
                    break;
                case "RETRIP":
                    if(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.Retrip.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.RetripInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Retrip Option");
                    }
                    else
                    {
                        Report.Failure("Retrip button is disabled");
                    }
                    break;
                default:
                    Ranorex.Report.Error("Invalid Selection");
                    break;
                    
            }
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo);
            Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButton.Click();
            Report.Info("Clicked on Apply button");

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        /// <summary>
        /// Validate Crew Details if Present in Trainsheet
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="crewSeed">crewSeed</param>
        /// <param name="type">Type of Crew "WK" etc</param>
        /// <param name="status">Status of Crew "A" or "I" etc</param>
        /// <param name="optionalOnTrainPassCount">Optional On Train Passcount</param>
        /// <param name="optionalOnTrainMilepost">Optional On Train Milepost</param>
        /// <param name="optionalOffTrainPassCount">Optional Off Train Passcount</param>
        /// <param name="optionalOffTrainMilepost">Optional Off Train Milepost</param>
        /// <param name="crewPresent">True if crew to be present, else false if not present</param>
        /// <param name="closeForms">True to close Trainsheet, else false to keep it open</param>
        [UserCodeMethod]
        public static void NS_ValidateCrewDetailsExist_TrainSheet(string trainSeed, string crewSeed,string type, string status, string optionalOnTrainPassCount, string optionalOnTrainMilepost, string optionalOffTrainPassCount, string optionalOffTrainMilepost, bool validateCrewRecordExists, bool closeForms)
        {
            int crewRowCount = 0;
            bool crewFound = false;
            
            NS_CrewMemberObject crewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
            
            string crewType = "";
            string crewStatus = "";
            string crewPosition = "";
            string crewFirstName = "";
            string crewMiddleInitial = "";
            string crewLastName = "";
            string crewOnDutyTime = "";
            string crewOnDutyLocation = "";
            string crewHOSExpiration = "";
            string crewOnTrainTime = "";
            string crewOnTrainLocation = "";
            string crewOnTrainPassCount = "";
            string crewOnTrainMilePost = "";
            string crewOffDutyTime = "";
            string crewOffDutyLocation = "";
            string crewOffTrainTime = "";
            string crewOffTrainLocation = "";
            string crewOffTrainPassCount = "";
            string crewOffTrainMilePost = "";
            string crewId = "";
            string segment = "";
            
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);
            
            if(Trainsrepo.Train_Sheet.Crew.CrewTable.SelfInfo.Exists(0))
            {
                crewRowCount = Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count;
                
                if(crewRowCount > 0)
                {
                    for (int i = 1; i < crewRowCount; i++)
                    {
                        Trainsrepo.CrewIndex = i.ToString();
                        crewFound = true;
                        Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click();
                        crewType = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeText.GetAttributeValue<string>("Text");
                        crewStatus = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Status.GetAttributeValue<string>("Text");
                        crewPosition = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionText.GetAttributeValue<string>("Text");
                        crewFirstName = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.GetAttributeValue<string>("Text");
                        crewMiddleInitial = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.GetAttributeValue<string>("Text");
                        crewLastName = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.GetAttributeValue<string>("Text");
                        crewOnDutyTime = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.Element.GetAttributeValueText("Time");
                        crewOnDutyLocation = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.GetAttributeValue<string>("Text");
                        crewHOSExpiration = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.Element.GetAttributeValueText("Time");
                        crewOnTrainTime = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Element.GetAttributeValueText("Time");
                        if(crewOnTrainTime==null)
                        {
                        	crewOnTrainTime="";
                        }
                       
                        crewOnTrainLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.GetAttributeValue<string>("Text");
                        crewOnTrainPassCount = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.GetAttributeValue<string>("Text");
                        crewOnTrainMilePost = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.GetAttributeValue<string>("Text");
                        crewOffDutyTime = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Element.GetAttributeValueText("Time");
                        if(crewOffDutyTime==null)
                        {
                        	crewOffDutyTime="";
                        }
                        crewOffDutyLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.GetAttributeValue<string>("Text");
                        crewOffTrainTime = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Element.GetAttributeValueText("Time");
                        if(crewOffTrainTime==null)
                        {
                        	crewOffTrainTime="";
                        }
                        crewOffTrainLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.GetAttributeValue<string>("Text");
                        crewOffTrainPassCount = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.GetAttributeValue<string>("Text");
                        crewOffTrainMilePost = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.GetAttributeValue<string>("Text");
                        crewId = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.CrewID.GetAttributeValue<string>("Text");
                        segment = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.Segment.GetAttributeValue<string>("Text");
                        
                        if (!type.Equals(crewType))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!status.Equals(crewStatus))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!crewMember.crewPosition.Equals(crewPosition))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!crewMember.firstInitial.Equals(crewFirstName))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!crewMember.middleInitial.Equals(crewMiddleInitial))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!crewMember.lastName.Equals(crewLastName))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if(crewMember.onDutyTimezone.Equals("C"))
                        {
                            if (!crewOnDutyTime.Contains(crewMember.onDutyDateTime.Value.AddHours(01).ToString("ddd MMM dd HH:mm:ss")))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        else
                        {
                            if (!crewOnDutyTime.Contains(crewMember.onDutyDateTime.Value.ToString("ddd MMM dd HH:mm:ss")))
                            {
                            	Report.Info(crewOnDutyTime);
                            	Report.Info(crewMember.onDutyDateTime.Value.ToString("ddd MMM dd HH:mm:ss"));
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        //Timezone validation will only work for Eastern Time as it converts to Eastern time even when mentioned Central timezone
                        if(crewMember.onDutyDateTime.Value.IsDaylightSavingTime())
                        {
                            if (!crewOnDutyTime.Contains("EDT"))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        else
                        {
                            if (!crewOnDutyTime.Contains("EST"))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        if (!crewOnDutyLocation.Contains(crewMember.onDutyLocation))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if(crewMember.hosExpireTimezone.Equals("C"))
                        {
                            if (!crewHOSExpiration.Contains(crewMember.hosExpireDateTime.Value.AddHours(01).ToString("ddd MMM dd HH:mm:ss")))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        else
                        {
                            if (!crewHOSExpiration.Contains(crewMember.hosExpireDateTime.Value.ToString("ddd MMM dd HH:mm:ss")))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        //Timezone validation will only work for Eastern Time as it converts to Eastern time even when mentioned Central timezone
                        if(crewMember.hosExpireDateTime.Value.IsDaylightSavingTime())
                        {
                            if (!crewHOSExpiration.Contains("EDT"))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        else
                        {
                            if (!crewHOSExpiration.Contains("EST"))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        if(crewMember.onTrainDateTime != null)
                        {
                        	if(crewMember.onTrainTimezone.Equals("C"))
                        	{
                        		if (!crewOnTrainTime.Contains(crewMember.onTrainDateTime.Value.AddHours(01).ToString("ddd MMM dd HH:mm:ss")))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOnTrainTime.Contains(crewMember.onTrainDateTime.Value.ToString("ddd MMM dd HH:mm:ss")) )
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	
                        	//Timezone validation will only work for Eastern Time as it converts to Eastern time even when mentioned Central timezone
                        	if(crewMember.onTrainDateTime.Value.IsDaylightSavingTime())
                        	{
                        		if (!crewOnTrainTime.Contains("EDT"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOnTrainTime.Contains("EST"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        }
                        if (!crewOnTrainLocation.Contains(crewMember.onTrainLocation))
                        {
                        	
                            crewFound = false;
                            continue;
                        }
                        
                        if(!string.IsNullOrEmpty(optionalOnTrainPassCount))
                        {
                            if (!crewOnTrainPassCount.Contains(optionalOnTrainPassCount))
                            {
                        	
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalOnTrainMilepost))
                        {
                            if (!crewOnTrainMilePost.Contains(optionalOnTrainMilepost))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        if(crewMember.offDutyDateTime != null)
                        {
                        	if(crewMember.offDutyTimezone.Equals("C"))
                        	{
                        		if (!crewOffDutyTime.Contains(crewMember.offDutyDateTime.Value.AddHours(01).ToString("ddd MMM dd HH:mm:ss")))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOffDutyTime.Contains(crewMember.offDutyDateTime.Value.ToString("ddd MMM dd HH:mm:ss")))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	
                        	//Timezone validation will only work for Eastern Time as it converts to Eastern time even when mentioned Central timezone
                        	if(crewMember.offDutyDateTime.Value.IsDaylightSavingTime())
                        	{
                        		if (!crewOffDutyTime.Contains("EDT"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOffDutyTime.Contains("EST"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        }
                        if (!crewOffDutyLocation.Contains(crewMember.offDutyLocation))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if(crewMember.offTrainDateTime != null)
                        {
                        	if(crewMember.offTrainTimezone.Equals("C"))
                        	{
                        		if (!crewOffTrainTime.Contains(crewMember.offTrainDateTime.Value.AddHours(01).ToString("ddd MMM dd HH:mm:ss")))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOffTrainTime.Contains(crewMember.offTrainDateTime.Value.ToString("ddd MMM dd HH:mm:ss")))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	
                        	if(crewMember.offTrainDateTime.Value.IsDaylightSavingTime())
                        	{
                        		if (!crewOffTrainTime.Contains("EDT"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        	else
                        	{
                        		if (!crewOffTrainTime.Contains("EST"))
                        		{
                        			crewFound = false;
                        			continue;
                        		}
                        	}
                        }
                        if (!crewOffTrainLocation.Contains(crewMember.offTrainLocation))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if(!string.IsNullOrEmpty(optionalOffTrainPassCount))
                        {
                            if (!crewOffTrainPassCount.Equals(optionalOffTrainPassCount))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalOffTrainMilepost))
                        {
                            if (!crewOffTrainMilePost.Contains(optionalOffTrainMilepost))
                            {
                                crewFound = false;
                                continue;
                            }
                        }
                        
                        if (!crewId.Equals(crewMember.crewId))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        if (!segment.Equals(crewMember.segment))
                        {
                            crewFound = false;
                            continue;
                        }
                        
                        break;
                    }
                }
                else
                {
                    Ranorex.Report.Info("Either Crew Data not available or it took more time to load crew table");
                }
                
                if(crewFound == validateCrewRecordExists)
                {
                    Ranorex.Report.Success("Crew details present? "+crewFound.ToString());
                }
                else
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                    Ranorex.Report.Failure("Crew Details did not match the search criteria");
                }
            }
            else
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                Ranorex.Report.Failure("Crew Table does not exist or user did not navigate to Crew table correctly");
            }
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        [UserCodeMethod]
        public static void ValidateMovementInfoRecords_TrainSheet(string trainSeed, string opsta, string optionalStation, string optionalMp, string reportType, string optionalReportTime, string optionalDirection, string optionalDistance, string optionalSpeed, string optionalSource, string optionalPsuedoTrain, bool validateMovementRecordExists, bool closeForms)
        {
            bool recordFound = true;
            int movementCount = 0;
            
            NS_OpenTrainsheetMovement_MainMenu(trainSeed);
            
            if(Trainsrepo.Train_Sheet.Movement.SelfInfo.Exists(0))
            {
                movementCount = Trainsrepo.Train_Sheet.Movement.MovementTable.Self.Rows.Count;
                
                if(movementCount > 0)
                {
                    string movementOpsta = "";
                    string station = "";
                    string mp = "";
                    string movementReportType = "";
                    string reportTime = "";
                    string direction = "";
                    string distance = "";
                    string speed = "";
                    string source = "";
                    string psuedoTrain = "";
                    
                    for(int i=0; i<movementCount;i++)
                    {
                        recordFound = true;
                        Trainsrepo.MovementIndex = i.ToString();
                        
                        movementOpsta = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.OpSta.GetAttributeValue<string>("Text");
                        station = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Station.GetAttributeValue<string>("Text");
                        mp = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Milepost.GetAttributeValue<string>("Text");
                        movementReportType = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ReportTypeText.GetAttributeValue<string>("Text");
                        reportTime = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.ReportTime.ReportTimeText.Element.GetAttributeValueText("Time");
                        direction = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Direction.GetAttributeValue<string>("Text");
                        speed = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Speed.GetAttributeValue<string>("Text");
                        source = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Source.GetAttributeValue<string>("Text");
                        psuedoTrain = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.PseudoTrain.GetAttributeValue<string>("Text");
                        
                        if(!opsta.Equals(movementOpsta))
                        {
                            recordFound = false;
                            continue;
                        }
                        
                        if(!string.IsNullOrEmpty(optionalStation))
                        {
                            if(!optionalStation.Equals(station))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalMp))
                        {
                            if(!mp.Contains(optionalMp))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!reportType.Equals(movementReportType))
                        {
                            recordFound = false;
                            continue;
                        }
                        
                        if(!string.IsNullOrEmpty(optionalReportTime))
                        {
                            if(!reportTime.Contains(optionalReportTime))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalDirection))
                        {
                            if(!optionalDirection.Equals(direction))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalDistance))
                        {
                            if(!distance.Contains(optionalDistance))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalSpeed))
                        {
                            if(!optionalSpeed.Equals(speed))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(optionalPsuedoTrain))
                        {
                            if(!optionalPsuedoTrain.Equals(psuedoTrain))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        break;
                    }
                }
                else
                {
                	if(validateMovementRecordExists)
                	{
                		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Movement.Self);
                		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                		                                                  Trainsrepo.Train_Sheet.SelfInfo);
                		Ranorex.Report.Failure("There are no movement records or it took more time to load");
                		return;
                	}
                	else
                	{
                		Ranorex.Report.Info("There are no movement records or it took more time to load");
                	}
                }
                
                if(recordFound == validateMovementRecordExists)
                {
                	Ranorex.Report.Success("Movement details present? "+recordFound.ToString());
                }
                else
                {
                	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                	                                                  Trainsrepo.Train_Sheet.SelfInfo);
                	Ranorex.Report.Failure("Movement Details did not match the search criteria");
                	return;
                }
            }
            else
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
                Ranorex.Report.Failure("Unable to open Movement tab for the trainsheet");
                return;
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        [UserCodeMethod]
        public static void NS_FillTerminateShort(string fromTrainSeed, string toTrainSeed, string opsta, bool copyTrainEngine, string additionalInfo, string expectedFeedback, bool clickOk, bool closeForms)
        {
            NS_OpenTerminateShort_TrainStatusSummary(fromTrainSeed, false);
            string fromTrainID = NS_TrainID.GetTrainId(fromTrainSeed);
            string toTrainID = NS_TrainID.GetTrainId(toTrainSeed);
            
            string foundFeedback = Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback.TextValue;
            if (foundFeedback != "")
            {
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback, expectedFeedback);
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.AdditionalInfoText, additionalInfo);
                
                if (closeForms)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.CancelButtonInfo,
                                                                                          Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,
                                                                                          Trainsrepo.Train_Status_Summary.SelfInfo);
                }
                return;
            }
            
            if(fromTrainID == null)
            {
                fromTrainID = fromTrainSeed;
            }
            Trainsrepo.Train_Status_Summary.Terminate_Short.FromTrainIDText.Click();
            Trainsrepo.Train_Status_Summary.Terminate_Short.FromTrainIDText.Element.SetAttributeValue("Text",fromTrainID);
            Trainsrepo.Train_Status_Summary.Terminate_Short.FromTrainIDText.PressKeys("{TAB}");
            
            foundFeedback = Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback.TextValue;
            if (foundFeedback != "")
            {
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback, expectedFeedback);
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.AdditionalInfoText, additionalInfo);
                
                if (closeForms)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.CancelButtonInfo,
                                                                                          Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,
                                                                                          Trainsrepo.Train_Status_Summary.SelfInfo);
                }
                return;
            }
            
            if(toTrainID == null)
            {
                toTrainID = toTrainSeed;
            }
            Trainsrepo.Train_Status_Summary.Terminate_Short.ToTrainIDText.Click();
            Trainsrepo.Train_Status_Summary.Terminate_Short.ToTrainIDText.Element.SetAttributeValue("Text",toTrainID);
            Trainsrepo.Train_Status_Summary.Terminate_Short.ToTrainIDText.PressKeys("{TAB}");
            
            foundFeedback = Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback.TextValue;
            if (foundFeedback != "")
            {
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback, expectedFeedback);
                CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.AdditionalInfoText, additionalInfo);
                
                if (closeForms)
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.CancelButtonInfo,
                                                                                          Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,
                                                                                          Trainsrepo.Train_Status_Summary.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Status_Summary.Terminate_Short.OpStaText.Click();
            Trainsrepo.Train_Status_Summary.Terminate_Short.OpStaText.Element.SetAttributeValue("Text",opsta);
            Trainsrepo.Train_Status_Summary.Terminate_Short.OpStaText.PressKeys("{TAB}");
            
            if(copyTrainEngine)
            {
                if(!Trainsrepo.Train_Status_Summary.Terminate_Short.CopyEnginesCheckbox.Checked)
                {
                    Trainsrepo.Train_Status_Summary.Terminate_Short.CopyEnginesCheckbox.Check();
                    Report.Info("Copy Engines Checkbox checked");
                }
                else
                {
                    Report.Info("Copy Engines Checkbox already checked");
                }
            }
            else
            {
                if(Trainsrepo.Train_Status_Summary.Terminate_Short.CopyEnginesCheckbox.Checked)
                {
                    Trainsrepo.Train_Status_Summary.Terminate_Short.CopyEnginesCheckbox.Uncheck();
                    Report.Info("Copy Engines Checkbox unchecked");
                }
                else
                {
                    Report.Info("Copy Engines Checkbox already unchecked");
                }
            }
            
            if(clickOk)
            {
                int retries = 0;
                Trainsrepo.Train_Status_Summary.Terminate_Short.OkButton.Click();
                while(Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0) && Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback.GetAttributeValue<string>("Text") != "" && retries < 3)
                {
                    Trainsrepo.Train_Status_Summary.Terminate_Short.OkButton.Click();
                    Delay.Seconds(3);
                    retries++;
                }
                if(Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
                {
                    foundFeedback = Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback.TextValue;
                    if (foundFeedback != "")
                    {
                        CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.Feedback, expectedFeedback);
                        CheckFeedback(Trainsrepo.Train_Status_Summary.Terminate_Short.AdditionalInfoText, additionalInfo);
                        
                        if (closeForms)
                        {
                            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.CancelButtonInfo,
                                                                                                  Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,
                                                                                                  Trainsrepo.Train_Status_Summary.SelfInfo);
                        }
                        return;
                    }
                }
            }
            
            if (expectedFeedback != "" || additionalInfo != "")
            {
                Ranorex.Report.Failure("Expected Feedback of {"+expectedFeedback+"}, but found none. Expected Additional Information of {"+additionalInfo+"} , but found none.");
            }
            
            if(closeForms)
            {
                if (Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo.Exists(0))
                {
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.Terminate_Short.CancelButtonInfo,
                                                                                          Trainsrepo.Train_Status_Summary.Terminate_Short.SelfInfo);
                    PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Status_Summary.WindowControls.CloseInfo,
                                                                                          Trainsrepo.Train_Status_Summary.SelfInfo);
                }
            }
        }
        /// <summary>
        /// Edit EOT/Caboose row by row
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterType">Type from the row that is to be selected</param>
        /// <param name="filterWorkingStatus">Working status from the row that is to be selected</param>
        /// <param name="filterSymbol">Symbol from the row that is to be selected</param>
        /// <param name="filterOrigin">Origin from the row that is to be selected</param>
        /// <param name="filterDestination">Destination from the row that is to be selected</param>
        /// <param name="updateType">Type that is to be updated</param>
        /// <param name="updateWorkingStatus">Working status that is to be updated</param>
        /// <param name="updateSymbol">Symbol that is to be updated</param>
        /// <param name="updateOrigin">Origin that is to be updated</param>
        /// <param name="updateDestination">Destination that is to be updated</param>
        /// <param name="expectedFeedback">Feedback to be verified</param>
        /// <param name="reset">bool value to reset the values or not</param>
        /// <param name="closeForms">bool value to close the form or not</param>
        [UserCodeMethod]
        public static void EditEOTCaboose_Trainsheet(string trainSeed, string filterType, string filterWorkingStatus, string filterSymbol, string filterOrigin,
                                                     string filterDestination, string updateType, string updateWorkingStatus, string updateSymbol, string updateOrigin,
                                                     string updateDestination, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetEOTCaboose_MainMenu(trainSeed);
            
            int rowCount = Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.Self.Rows.Count;
            bool rowFound = false;
            
            for (int i = 0; i < rowCount; i++)
            {
                Trainsrepo.EOTCabooseIndex=i.ToString();
                
                if(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeText.GetAttributeValue<string>("Text").Equals(filterType,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusText.GetAttributeValue<string>("Text").Equals(filterWorkingStatus,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.GetAttributeValue<string>("Text").Equals(filterSymbol,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.GetAttributeValue<string>("Text").Contains(filterOrigin)
                   && Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.GetAttributeValue<string>("Text").Contains(filterDestination))
                {
                    rowFound = true;
                    break;
                }
            }
            if (rowFound)
            {
                switch (updateType.ToLower())
                {
                    case "eot":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeTextInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.EOTInfo,
                                                                          Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                        Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeText.PressKeys("{TAB}");
                        break;
                    case "caboose":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeTextInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.CabooseInfo,
                                                                          Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                        Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeText.PressKeys("{TAB}");
                        break;
                    default:
                        Report.Error("Error","Invalid selection");
                        break;
                }
                switch (updateWorkingStatus.ToLower())
                {
                    case "working":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusTextInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.WorkingInfo,
                                                                          Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                        Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusText.PressKeys("{TAB}");
                        break;
                    case "deadintow":
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusTextInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.DeadInTowInfo,
                                                                          Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                        Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusText.PressKeys("{TAB}");
                        break;
                    default:
                        Report.Error("Error","Invalid selection");
                        break;
                }
                
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.Click();
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.PressKeys(updateSymbol);
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.PressKeys("{TAB}");
                
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.Click();
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.Element.SetAttributeValue("Text", updateOrigin);
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.PressKeys("{TAB}");
                
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.Click();
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.Element.SetAttributeValue("Text", updateDestination);
                Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.PressKeys("{TAB}");
                
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
                
                if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ApplyButtonInfo,Trainsrepo.Train_Sheet.EOTCaboose.ApplyButtonInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    Ranorex.Report.Info("No Feedback message received. Successfully updated EOT/Caboose.");
                }
            }
            else
            {
                Ranorex.Report.Error("EOT/Caboose Row not found");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Edit Consist Summary
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterOpsta"></param>
        /// <param name="updatePass"></param>
        /// <param name="updateLoads"></param>
        /// <param name="updateEmpties"></param>
        /// <param name="updateTons"></param>
        /// <param name="updateLength"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void EditConsistSummary_Trainsheet(string trainSeed, string filterOpsta, string updateOpsta, string updatePass, string updateLoads, string updateEmpties,
                                                         string updateTons, string updateLength, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Consist Summary Tab on Train Tab.");
                    return;
                }
            }
            bool rowfound=false;
            for(int i=0;i<Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.Self.Rows.Count;i++)
            {
                Trainsrepo.ConsistSummaryIndex=i.ToString();
                if(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.Text.Contains(filterOpsta))
                {
                    rowfound=true;
                    break;
                }
            }
            if(rowfound)
            {
                Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.MenuCell.Click();
                
                if (!updateOpsta.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.GetAttributeValue<string>("StationId"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.PressKeys(updateOpsta);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.PressKeys("{TAB}");
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updatePass.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.PassCount.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.PassCount.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.PassCount.PressKeys(updatePass);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.PassCount.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateLoads.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Loads.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Loads.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Loads.PressKeys(updateLoads);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Loads.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateEmpties.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Empties.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Empties.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Empties.PressKeys(updateEmpties);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Empties.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateTons.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Tons.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Tons.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Tons.PressKeys(updateTons);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Tons.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                
                if (!updateLength.Equals(Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Length.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Length.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Length.PressKeys(updateLength);
                    Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.Length.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButtonInfo);
                    Ranorex.Report.Info("No Feedback message received. Successfully updated Consist Summary.");
                } else {
                    Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "} but got feedback of {" + Trainsrepo.Train_Sheet.Feedback.TextValue + "}.");
                }
            }
            else
            {
                Ranorex.Report.Error("Consist Summary Row not found");
            }
            
            if(closeForms)
            {
                GeneralUtilities.clickItemIfItExists(Trainsrepo.Train_Sheet.CancelButtonInfo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterOpsta"></param>
        /// <param name="operation"></param>
        /// <param name="Opsta"></param>
        /// <param name="PassCount"></param>
        /// <param name="loads"></param>
        /// <param name="empties"></param>
        /// <param name="tons"></param>
        /// <param name="length"></param>
        /// <param name="note"></param>
        /// <param name="coal"></param>
        /// <param name="needDateTimeOffset"></param>
        /// <param name="needDateTimeZone"></param>
        /// <param name="completionDateTimeOffset"></param>
        /// <param name="completionDateTimeZone"></param>
        /// <param name="coalPermit"></param>
        /// <param name="coalCarsRecords"></param>
        /// <param name="daylightSaving"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void EditAssignedWork_Trainsheet(string trainSeed, string filterOpsta, string operation, string opsta, string passCount, string loads,
                                                       string empties, string tons, string length, string note, bool coal, string needDateTimeOffset,
                                                       string needDateTimeZone, string completionDateTimeOffset, string completionDateTimeZone, string coalPermit,
                                                       string coalCarsRecords, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            
            int retries = 0;
            
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWork.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWork.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWork.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWork.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.AssignedWork.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Assigned Work Tab on Train Tab.");
                    return;
                }
            }
            bool rowfound=false;
            for(int i=0;i<Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.Self.Rows.Count;i++)
            {
                Trainsrepo.AssignedWorkIndex=i.ToString();
                if(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.OpStaName.Text.Contains(filterOpsta))
                {
                    rowfound=true;
                    break;
                }
            }
            if(rowfound)
            {
                Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.MenuCell.Click();
                
                if(operation != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationText.Text)
                {
                    operation = operation.ToLower();
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationTextInfo,
                                                              Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.SelfInfo);
                    if(operation == "pickup")
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.PickupInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.SelfInfo);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationText.PressKeys("{TAB}");
                    }
                    else if (operation == "setout")
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.SetoutInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.SelfInfo);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationText.PressKeys("{TAB}");
                    }
                    else if (operation == "other")
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.OtherInfo,
                                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationList.SelfInfo);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Operation.OperationText.PressKeys("{TAB}");
                    }
                    else
                    {
                        Report.Error("Invalid Operation Input" +operation);
                        Trainsrepo.Train_Sheet.CancelButton.Click();
                        return;
                    }

                }
                
                if (filterOpsta != opsta)
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.OpStaName.Click();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.LocationCellEditor.Element.SetAttributeValue("Text", opsta);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.LocationCellEditor.PressKeys("{TAB}");
                }
                
                if (passCount != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.PassCount.Text)
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.PassCount.Click();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.PassCount.PressKeys(passCount);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.PassCount.PressKeys("{TAB}");
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (operation != "other")
                {
                    if (loads != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Loads.Text)
                    {
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Loads.Click();
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Loads.PressKeys(loads);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Loads.PressKeys("{TAB}");
                        if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                        {
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                                  Trainsrepo.Train_Sheet.SelfInfo);
                            }
                            return;
                        }
                    }
                    
                    if (empties != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Empties.Text)
                    {
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Empties.Click();
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Empties.PressKeys(empties);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Empties.PressKeys("{TAB}");
                        if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                        {
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                                  Trainsrepo.Train_Sheet.SelfInfo);
                            }
                            return;
                        }
                    }
                    
                    if (tons != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Tons.Text)
                    {
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Tons.Click();
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Tons.PressKeys(tons);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Tons.PressKeys("{TAB}");
                        if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                        {
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                                  Trainsrepo.Train_Sheet.SelfInfo);
                            }
                            return;
                        }
                    }
                    
                    if (length != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Length.Text)
                    {
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Length.Click();
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Length.PressKeys(length);
                        Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Length.PressKeys("{TAB}");
                        if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                        {
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.RefreshButton.Click();
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                                  Trainsrepo.Train_Sheet.SelfInfo);
                            }
                            return;
                        }
                    }
                }
                
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.NoteInfo,
                                                          Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.SelfInfo);
                if(note != Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.AddCommentsText.TextValue)
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.AddCommentsText.DoubleClick();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.AddCommentsText.PressKeys(note);
                }
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.OkButtonInfo,
                                                                  Trainsrepo.Train_Sheet.Train.AssignedWork.Add_Comments.SelfInfo);
                
                if(coal != bool.Parse(Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Coal.Text))
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Coal.Click();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.Coal.PressKeys("{TAB}");
                }
                if(!string.IsNullOrEmpty(needDateTimeOffset))
                {
                    int needDateTimeOffsetInt = 0;
                    string needDateTimeInput = "";
                    System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
                    if (Int32.TryParse(needDateTimeOffset, out needDateTimeOffsetInt))
                    {
                        System.DateTime needDateTime = trainOriginDateTime.AddMinutes(needDateTimeOffsetInt);
                        needDateTimeInput = NS_FormatDateTime_TrainSheet(needDateTime, needDateTimeZone, false);
                    }
                    else
                    {
                        if (needDateTimeZone != "")
                        {
                            needDateTimeInput = needDateTimeOffset + " " + needDateTimeZone;
                        } else {
                            needDateTimeInput = needDateTimeOffset;
                        }
                    }
                    
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.NeedDate.NeedDateText.Click();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.CalendarCellEditor.Element.SetAttributeValue("Text", needDateTimeInput);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.CalendarCellEditor.PressKeys("{TAB}");
                    
                    if (!CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Info("Need Date Time Zone Input Value: "+ needDateTimeInput);
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;

                    }
                }
                
                if(!string.IsNullOrEmpty(completionDateTimeOffset))
                {
                    int completionDateTimeOffsetInt = 0;
                    string completionDateTimeInput = "";
                    System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
                    if (Int32.TryParse(completionDateTimeOffset, out completionDateTimeOffsetInt))
                    {
                        System.DateTime completionDateTime = trainOriginDateTime.AddMinutes(completionDateTimeOffsetInt);
                        completionDateTimeInput = NS_FormatDateTime_TrainSheet(completionDateTime, completionDateTimeZone, false);
                    }
                    else
                    {
                        if (completionDateTimeZone != "")
                        {
                            completionDateTimeInput = completionDateTimeOffset + " " + completionDateTimeZone;
                        } else {
                            completionDateTimeInput = completionDateTimeOffset;
                        }
                    }
                    
                    
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.CompletionDate.CompletionDateText.Click();
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.CalendarCellEditor.Element.SetAttributeValue("Text", completionDateTimeInput);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.CalendarCellEditor.PressKeys("{TAB}");
                    
                    if (!CheckFeedbackExists(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Info("Completion Date Time Zone Input Value: "+ completionDateTimeInput);
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.AssignedWork.Self);
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if(coalPermit != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.CoalPermit.Text)
                {
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.CoalPermit.PressKeys(coalPermit);
                    Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkTable.AssignedWorkInputRowByIndex.CoalPermit.PressKeys("{TAB}");
                }
                
                
                string[] coalCarsRecordsElements = coalCarsRecords.Split('|');
                int totalCarsRecord = coalCarsRecordsElements.Length;
                if (totalCarsRecord % 2 == 0)
                {
                    for (int i = 0; i < totalCarsRecord/2; i++)
                    {
                        Trainsrepo.AssignedWorkDetailsIndex = i.ToString();
                        string coalCar = coalCarsRecordsElements[2*i];
                        string coalClassification = coalCarsRecordsElements[2*i + 1];
                        if (coalCar != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.Text)
                        {
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.Click();
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys(coalCar);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalCarsByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                        }
                        
                        if (coalClassification != Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.Text)
                        {
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.Click();
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys(coalClassification);
                            Trainsrepo.Train_Sheet.Train.AssignedWork.AssignedWorkDetailsPanel.CoalClassificationByAssignedWorkDetailsIndex.PressKeys("{TAB}");
                        }
                    }
                }
                else
                {
                    Ranorex.Report.Failure("Invalid assigned record lengths present. Assigned work not created.");
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }

                if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.AssignedWork.ApplyButtonInfo);
                    Ranorex.Report.Info("No Feedback message received. successfully updated assigned work.");
                } else {
                    Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "} but got feedback of {" + Trainsrepo.Train_Sheet.Feedback.TextValue + "}.");
                }
            }
            else
            {
                Ranorex.Report.Error("Assigned work Row not found");
            }
            
            if(closeForms)
            {
                NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterType"></param>
        /// <param name="filterFromOpsta"></param>
        /// <param name="filterToOpsta"></param>
        /// <param name="updateType"></param>
        /// <param name="updateValue"></param>
        /// <param name="updateFromOpsta"></param>
        /// <param name="updateToOpsta"></param>
        /// <param name="updateFromPass"></param>
        /// <param name="updateToPass"></param>
        /// <param name="updateQKS"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void EditConsistConstraint_Trainsheet(string trainSeed, string filterType, string filterFromOpsta, string filterToOpsta, string updateType, string updateValue, string updateFromOpsta,
                                                            string updateToOpsta, string updateFromPass, string updateToPass, bool updateQKS, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Consist Constraints Tab on Train Tab.");
                    return;
                }
            }
            
            bool rowfound=false;
            for(int i=0;i<Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self.Rows.Count;i++)
            {
                Trainsrepo.ConsistConstraintIndex=i.ToString();
                
                if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.GetAttributeValue<string>("Text").ToLower().Equals(filterType.ToLower())
                   && Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("Text").Contains(filterFromOpsta)
                   && Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("Text").Contains(filterToOpsta))
                {
                    rowfound=true;
                    break;
                }
            }
            
            if(rowfound)
            {
                Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.MenuCell.Click();
                
                if (!updateType.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.Text, StringComparison.OrdinalIgnoreCase))
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeTextInfo,
                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                    switch (updateType.ToLower())
                    {
                        case "weight":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.WeightInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        case "height":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.HeightInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        case "width":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.WidthInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        case "hazmat":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.HazmatTrainInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        case "speed":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SpeedInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        case "tih":
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.TIHIndicatorInfo,
                                                                              Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeList.SelfInfo);
                            break;
                        default:
                            Report.Error("Invalid Type selection");
                            break;
                    }
                }
                
                if (!updateValue.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Value.Text, StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Value.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Value.PressKeys(updateValue);
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Value.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateFromOpsta.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("StationID"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.PressKeys(updateFromOpsta);
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateFromPass.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromPassCount.Text))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromPassCount.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromPassCount.PressKeys(updateFromPass);
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromPassCount.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateToOpsta.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("StationID"), StringComparison.OrdinalIgnoreCase))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.PressKeys(updateToOpsta);
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if (!updateToPass.Equals(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToPassCount.Text))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToPassCount.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToPassCount.PressKeys(updateToPass);
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToPassCount.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if(updateQKS != (Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.CreateQKSAtOpSta.Text == "true"))
                {
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.CreateQKSAtOpSta.Click();
                    Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.CreateQKSAtOpSta.PressKeys("{TAB}");
                    
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                    {
                        Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistConstraints.Self);
                        Trainsrepo.Train_Sheet.Train.ConsistConstraints.RefreshButton.Click();
                        if (closeForms)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.SelfInfo);
                        }
                        return;
                    }
                }
                
                if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
                {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo);
                    Ranorex.Report.Info("No Feedback message received. Successfully updated Consist Constraint.");
                } else {
                    Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "} but got feedback of {" + Trainsrepo.Train_Sheet.Feedback.TextValue + "}.");
                }
            }
            else
            {
                Ranorex.Report.Error("Consist Constraint Row not found");
            }
            
            if(closeForms)
            {
                NS_CloseTrainsheet();
            }
        }
        
        public static bool EngineRowMatch (string position, string engineConsist, string engineID, string engineGroup, string model, string compensatedHP, string originLocation, string destinationLocation)
        {
        	bool match = true;
        	string matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.EngineID.GetAttributeValue<string>("Text");
        	if (!matchVal.Equals(engineID)) //matching ID is usually a unique identifier, so if it isnt the one we're looking for immediately short circuit evals instead of doing the rest to make sure which woe would do if there were duplicate ids
        	{
        		Report.Info("Found engineID: {"+matchVal+"} does not match expected engine ID {" + engineID +"}.");
        		return false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Position.GetAttributeValue<string>("Text");
        	if (!matchVal.Equals(position)) //matching ID is usually a unique identifier, so if it isnt the one we're looking for immediately short circuit evals instead of doing the rest to make sure which woe would do if there were duplicate ids
        	{
        		Report.Info("Found position: {"+matchVal+"} does not match expected position {" + position +"}.");
        		match = false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.GetAttributeValue<string>("Text");
        	if (!matchVal.Equals(engineConsist)) //matching ID is usually a unique identifier, so if it isnt the one we're looking for immediately short circuit evals instead of doing the rest to make sure which woe would do if there were duplicate ids
        	{
        		Report.Info("Found engine consist: {"+matchVal+"} does not match expected engine consist {" + engineConsist +"}.");
        		match = false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.GetAttributeValue<string>("Text");
    		if (!matchVal.Equals(engineGroup)) //matching ID is usually a unique identifier, so if it isnt the one we're looking for immediately short circuit evals instead of doing the rest to make sure which woe would do if there were duplicate ids
        	{
        		Report.Info("Found engine group {"+matchVal+"} does not match expected engine consist {" + engineGroup +"}.");
        		match = false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Model.GetAttributeValue<string>("Text");
        	if (!matchVal.Equals(model) && !(matchVal.Equals(" ") && model.Equals(""))) //TODO BECAREFUL! by default if no value exists in the engine row, PDS populates it with a whitepsace per my observation. If you observe differently please change this accordingly
        	{
        		Report.Info("Found engine model: {"+matchVal+"} does not match expected engine model {" + model +"}.");
        		match = false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.CompensatedHP.GetAttributeValue<string>("Text");
        	if (!matchVal.Equals(compensatedHP)) //matching ID is usually a unique identifier, so if it isnt the one we're looking for immediately short circuit evals instead of doing the rest to make sure which woe would do if there were duplicate ids
        	{
        		Report.Info("Found engine Compensated Horsepower: {"+matchVal+"} does not match expected engine Compensated Horsepower {" + compensatedHP +"}.");
        		match = false;
        	}
        	matchVal = Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.GetAttributeValue<string>("Text");
        	if (!matchVal.Contains(originLocation))
        	{
        		Report.Info("Found engine origin location: {"+matchVal+"} does not match expected engine origin location {" + originLocation +"}.");
        		match = false;
        	}
        	matchVal= Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.GetAttributeValue<string>("Text");
        	if (!matchVal.Contains(destinationLocation))
        	{
        		Report.Info("Found engine destination location: {"+matchVal+"} does not match expected engine destination location {" + destinationLocation +"}.");
        		match = false;
        	}
        	return match;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterPos"></param>
        /// <param name="filterEngine"></param>
        /// <param name="filterEngineID"></param>
        /// <param name="filterGroup"></param>
        /// <param name="filterModel"></param>
        /// <param name="filterCompHP"></param>
        /// <param name="filterOriginLocation"></param>
        /// <param name="filterDestLocation"></param>
        /// <param name="engineSeed"></param>
        /// <param name="updateEngine"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void EditEngineRecord_Trainsheet(string trainSeed, string filterPos, string filterEngine, string filterEngineID, string filterGroup, string filterModel, string filterCompHP,
                                                       string filterOriginLocation, string filterDestLocation, string engineSeed, string updateEngine, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetEngine_MainMenu(trainSeed);
            
            bool rowFound = false;
            string engineIndex = "";
            for(int i = 0; i<Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count; i++)
            {
                Trainsrepo.EngineIndex=i.ToString();
                engineIndex=i.ToString();
                if(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCellInfo.Exists(0))
                {
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click();
                    
                    if(EngineRowMatch(filterPos, filterEngine, filterEngineID, filterGroup, filterModel, filterCompHP, filterOriginLocation, filterDestLocation))
                    {
                        rowFound=true;
                        break;
                    }
                }
                else
                {
                    Ranorex.Report.Error("Engine Row not found");
                    if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                        return;
                    }
                }
            }
            if(rowFound)
            {
                string[] engines = updateEngine.Split('|');
                string engineInitial = engines[0];
                string engineNumber = engines[1];
                string pos = engines[2];
                bool lockEngine = (engines[4] == "Y");
                string originPassCount = engines[5];
                string originLocation = engines[6];
                string destinationPassCount = engines[7];
                string destinationLocation = engines[8];
                string compensatedHP = engines[9];
                string engineGroup = engines[10];
                string model = engines[11];
                string engineStatus = engines[12];
                bool dpu = (engines[13] == "Y");
                bool pts = (engines[14] == "Y");
                bool ptc = (engines[15] == "Y");
                bool lsl = (engines[16] == "Y");
                bool cs = (engines[17] == "Y");
                string notes = engines[18];
                
                NS_ManuallyAddEngine_Trainsheet(trainSeed,  engineSeed,  pos,  lockEngine,  engineStatus,  engineInitial,  engineNumber,  engineGroup,
                                                model,  compensatedHP,  originLocation,  originPassCount,  destinationLocation,  destinationPassCount,
                                                ptc,  lsl, pts,  cs,  dpu,  notes,  expectedFeedback,  closeForms, engineIndex);
            }
            else
            {
                Ranorex.Report.Failure("Engine Row not found");
            }
        }
        /// <summary>
        /// Modify the crew record
        /// </summary>
        /// <param name="trainSeed">trainSeed</param>
        /// <param name="crewSeed">crewSeed</param>
        /// <param name="type">type of crew</param>
        /// <param name="status">status of the crew</param>
        /// <param name="OnTrainPassCount">On Train Pass Count</param>
        /// <param name="OnTrainMilepost">On Train Milepost</param>
        /// <param name="OffTrainPassCount">Off-Train Pass Count</param>
        /// <param name="OffTrainMilepost">Off-Train Milepost</param>
        /// <param name="daylightSaving">daylight Saving</param>
        /// <param name="expectedFeedback">expected Feedback</param>
        /// <param name="closeForms">close Forms - true or false</param>
        [UserCodeMethod]
        public static void EditCrewRecord_Trainsheet(string trainSeed, string crewSeed, string updateType, string updatePos, string updateFirstInitial, string updateMiddleInitial,
                                                     string updateLastName, string updateOnDutyDateOffsetDays, string updateOnDutyTimeOffsetMinutes, string updateOnDutyTimezone,
                                                     string updateOnDutyLocation, string updateHosExpirationDateOffsetDays, string updateHosExpirationTimeOffsetMinutes,
                                                     string updateHosExpirationTimezone, string updateOnTrainDateOffsetDays, string updateOnTrainTimeOffsetMinutes, string updateOnTrainTimezone,
                                                     string updateOnTrainLocation, string updateOnTrainPassCount, string updateOnTrainMilepost,
                                                     string updateOffDutyDateOffsetDays, string updateOffDutyTimeOffsetMinutes, string updateOffDutyTimezone, string updateOffDutyLocation,
                                                     string updateOffTrainDateOffsetDays, string updateOffTrainTimeOffsetMinutes, string updateOffTrainTimezone, string updateOffTrainLocation,
                                                     string updateOffTrainPassCount, string updateOffTrainMilepost, string expectedFeedback, bool closeForms)
        {
            bool crewFound = false;
            int retries = 0;
            System.DateTime parsedDateTime;
            
            NS_CrewMemberObject crewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
            
            NS_OpenTrainsheetCrew_MainMenu(trainSeed);
            
            if(Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count < 1)
            {
                Ranorex.Report.Error("No Crews found in Crew Table");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            for (int i = 1; i < Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count; i++)
            {
                
                Trainsrepo.CrewIndex = i.ToString();
                if (crewMember.firstInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                    crewMember.middleInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                    crewMember.lastName.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                {
                    crewFound = true;
                    break;
                }
            }
            
            if (!crewFound)
            {
                Ranorex.Report.Error("Crew with Name {" + crewMember.firstInitial + " " + crewMember.middleInitial + " " + crewMember.lastName + "} was not found");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click();
            
            if (!updateType.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeText.Text, StringComparison.OrdinalIgnoreCase))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeTextInfo, Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.SelfInfo);
                Trainsrepo.TypeName = updateType;
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.TypeListItemByNameInfo, Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Type.TypeList.SelfInfo);
                if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                    Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                }
            }
            
            if (!updatePos.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionText.Text, StringComparison.OrdinalIgnoreCase))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionTextInfo, Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SelfInfo);
                Trainsrepo.PositionName = updatePos;
                crewMember.crewPosition=updatePos;
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.PositionListItemByNameInfo, Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.Position.PositionList.SelfInfo);
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.Click();
            if (!updateFirstInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", updateFirstInitial);
                crewMember.firstInitial = updateFirstInitial;
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.Click();
            if (!updateMiddleInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", updateMiddleInitial);
                crewMember.middleInitial = updateMiddleInitial;
            }
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.Click();
            if (!updateLastName.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CellEditor.Element.SetAttributeValue("Text", updateLastName);
                crewMember.lastName = updateLastName;
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text").ToString());
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            System.DateTime now = System.DateTime.Now;
            int updateOnDutyDateOffsetDaysInt;
            int updateOnDutyTimeOffsetMinutesInt;
            string onDutyDateTimeString = "";
            System.DateTime newUpdateOnDutyDateTime = new System.DateTime();
            if (int.TryParse(updateOnDutyDateOffsetDays, out updateOnDutyDateOffsetDaysInt))
            {
                if (crewMember.onDutyDateTime != null)
                {
                    newUpdateOnDutyDateTime = crewMember.onDutyDateTime.Value.AddDays(updateOnDutyDateOffsetDaysInt);
                    if (int.TryParse(updateOnDutyTimeOffsetMinutes, out updateOnDutyTimeOffsetMinutesInt))
                    {
                        newUpdateOnDutyDateTime = newUpdateOnDutyDateTime.AddMinutes(updateOnDutyTimeOffsetMinutesInt);
                    }
                } else {
                    newUpdateOnDutyDateTime = now.AddDays(updateOnDutyDateOffsetDaysInt);
                    if (int.TryParse(updateOnDutyTimeOffsetMinutes, out updateOnDutyTimeOffsetMinutesInt))
                    {
                        newUpdateOnDutyDateTime = newUpdateOnDutyDateTime.AddMinutes(updateOnDutyTimeOffsetMinutesInt);
                    }
                }
                onDutyDateTimeString = newUpdateOnDutyDateTime.ToString("MM-dd-yyyy HH:mm") + (updateOnDutyTimezone != "" ? " " + updateOnDutyTimezone : "");
            } else {
                onDutyDateTimeString = updateOnDutyDateOffsetDays + (updateOnDutyTimezone != "" ? " " + updateOnDutyTimezone : "");
            }
            if (!onDutyDateTimeString.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.Element.SetAttributeValue("Text", onDutyDateTimeString);
                if (System.DateTime.TryParse(onDutyDateTimeString, out parsedDateTime))
                {
                	crewMember.onDutyDateTime = parsedDateTime;
                    crewMember.onDutyTimezone = updateOnDutyTimezone;
                }
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.Click();
            if (!updateOnDutyLocation.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyLocation.Element.SetAttributeValue("Text", updateOnDutyLocation);
                crewMember.onDutyLocation=updateOnDutyLocation;
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            int updateHosExpirationDateOffsetDaysInt;
            int updateHosExpirationTimeOffsetMinutesInt;
            string HosExpirationDateTimeString = "";
            System.DateTime newUpdateHosExpirationDateTime = new System.DateTime();
            if (int.TryParse(updateHosExpirationDateOffsetDays, out updateHosExpirationDateOffsetDaysInt))
            {
                if (crewMember.hosExpireDateTime != null)
                {
                    newUpdateHosExpirationDateTime = crewMember.onDutyDateTime.Value.AddDays(updateHosExpirationDateOffsetDaysInt);
                    if (int.TryParse(updateHosExpirationTimeOffsetMinutes, out updateHosExpirationTimeOffsetMinutesInt))
                    {
                        newUpdateHosExpirationDateTime = newUpdateHosExpirationDateTime.AddMinutes(updateHosExpirationTimeOffsetMinutesInt);
                    }
                } else {
                    newUpdateHosExpirationDateTime = now.AddDays(updateHosExpirationDateOffsetDaysInt);
                    if (int.TryParse(updateHosExpirationTimeOffsetMinutes, out updateHosExpirationTimeOffsetMinutesInt))
                    {
                        newUpdateHosExpirationDateTime = newUpdateHosExpirationDateTime.AddMinutes(updateHosExpirationTimeOffsetMinutesInt);
                    }
                }
                HosExpirationDateTimeString = newUpdateHosExpirationDateTime.ToString("MM-dd-yyyy HH:mm") + (updateHosExpirationTimezone != "" ? " " + updateHosExpirationTimezone : "");
            } else {
                HosExpirationDateTimeString = updateHosExpirationDateOffsetDays + (updateHosExpirationTimezone != "" ? " " + updateHosExpirationTimezone : "");
            }
            if (!HosExpirationDateTimeString.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.Element.SetAttributeValue("Text", HosExpirationDateTimeString);
                if (System.DateTime.TryParse(HosExpirationDateTimeString, out parsedDateTime))
                {
                    crewMember.hosExpireDateTime = parsedDateTime;
                    crewMember.hosExpireTimezone = updateHosExpirationTimezone;
                }
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            int updateOnTrainDateOffsetDaysInt;
            int updateonTrainTimeOffsetMinutesInt;
            string OnTrainDateTimeString = "";
            System.DateTime newUpdateOnTrainDateTime = new System.DateTime();
            if (int.TryParse(updateOnTrainDateOffsetDays, out updateOnTrainDateOffsetDaysInt))
            {
                if (crewMember.onTrainDateTime != null)
                {
                    newUpdateOnTrainDateTime = crewMember.onTrainDateTime.Value.AddDays(updateOnTrainDateOffsetDaysInt);
                    if (int.TryParse(updateOnTrainTimeOffsetMinutes, out updateonTrainTimeOffsetMinutesInt))
                    {
                        newUpdateOnTrainDateTime = newUpdateOnTrainDateTime.AddMinutes(updateonTrainTimeOffsetMinutesInt);
                    }
                } else {
                    newUpdateOnTrainDateTime = now.AddDays(updateOnTrainDateOffsetDaysInt);
                    if (int.TryParse(updateOnTrainTimeOffsetMinutes, out updateonTrainTimeOffsetMinutesInt))
                    {
                        newUpdateOnTrainDateTime = newUpdateOnTrainDateTime.AddMinutes(updateonTrainTimeOffsetMinutesInt);
                    }
                }
                OnTrainDateTimeString = newUpdateOnTrainDateTime.ToString("MM-dd-yyyy HH:mm") + (updateOnTrainTimezone != "" ? " " + updateOnTrainTimezone : "");
            } else {
                OnTrainDateTimeString = updateOnTrainDateOffsetDays + (updateOnTrainTimezone != "" ? " " + updateOnTrainTimezone : "");
            }
            if (!OnTrainDateTimeString.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Element.SetAttributeValue("Text", OnTrainDateTimeString);
                if (System.DateTime.TryParse(OnTrainDateTimeString, out parsedDateTime))
                {
                    crewMember.onTrainDateTime = parsedDateTime;
                    crewMember.onTrainTimezone=updateOnTrainTimezone;
                }
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.Click();
            if (!updateOnTrainLocation.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.Element.SetAttributeValue("Text", updateOnTrainLocation);
                crewMember.onTrainLocation=updateOnTrainLocation;
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.Click();
            if (!updateOnTrainPassCount.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.Element.SetAttributeValue("Text", updateOnTrainPassCount);
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.Click();
            if (!updateOnTrainMilepost.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainMilepost.Element.SetAttributeValue("Text", updateOnTrainMilepost);
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            int updateOffDutyDateOffsetDaysInt;
            int updateOffDutyTimeOffsetMinutesInt;
            string OffDutyDateTimeString = "";
            System.DateTime newUpdateOffDutyDateTime = new System.DateTime();
            if (int.TryParse(updateOffDutyDateOffsetDays, out updateOffDutyDateOffsetDaysInt))
            {
                if (crewMember.offDutyDateTime != null)
                {
                    newUpdateOffDutyDateTime = crewMember.offDutyDateTime.Value.AddDays(updateOffDutyDateOffsetDaysInt);
                    if (int.TryParse(updateOffDutyTimeOffsetMinutes, out updateOffDutyTimeOffsetMinutesInt))
                    {
                        newUpdateOffDutyDateTime = newUpdateOffDutyDateTime.AddMinutes(updateOffDutyTimeOffsetMinutesInt);
                    }
                } else {
                    newUpdateOffDutyDateTime = now.AddDays(updateOffDutyDateOffsetDaysInt);
                    if (int.TryParse(updateOffDutyTimeOffsetMinutes, out updateOffDutyTimeOffsetMinutesInt))
                    {
                        newUpdateOffDutyDateTime = newUpdateOffDutyDateTime.AddMinutes(updateOffDutyTimeOffsetMinutesInt);
                    }
                }
                OffDutyDateTimeString = newUpdateOffDutyDateTime.ToString("MM-dd-yyyy HH:mm") + (updateOffDutyTimezone != "" ? " " + updateOffDutyTimezone : "");
            } else {
                OffDutyDateTimeString = updateOffDutyDateOffsetDays + (updateOffDutyTimezone != "" ? " " + updateOffDutyTimezone : "");
            }
            if (!OffDutyDateTimeString.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Element.SetAttributeValue("Text", OffDutyDateTimeString);
                if (System.DateTime.TryParse(OffDutyDateTimeString, out parsedDateTime))
                {
                    crewMember.offDutyDateTime = parsedDateTime;
                    crewMember.offDutyTimezone = updateOffDutyTimezone;
                }
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.Click();
            if (!updateOffDutyLocation.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.Element.SetAttributeValue("Text", updateOffDutyLocation);
                crewMember.offDutyLocation = updateOffDutyLocation;
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            int updateOffTrainDateOffsetDaysInt;
            int updateOffTrainTimeOffsetMinutesInt;
            string OffTrainDateTimeString = "";
            System.DateTime newUpdateOffTrainDateTime = new System.DateTime();
            if (int.TryParse(updateOffTrainDateOffsetDays, out updateOffTrainDateOffsetDaysInt))
            {
                if (crewMember.offTrainDateTime != null)
                {
                    newUpdateOffTrainDateTime = crewMember.offTrainDateTime.Value.AddDays(updateOffTrainDateOffsetDaysInt);
                    if (int.TryParse(updateOffTrainTimeOffsetMinutes, out updateOffTrainTimeOffsetMinutesInt))
                    {
                        newUpdateOffTrainDateTime = newUpdateOffTrainDateTime.AddMinutes(updateOffTrainTimeOffsetMinutesInt);
                    }
                } else {
                    newUpdateOffTrainDateTime = now.AddDays(updateOffTrainDateOffsetDaysInt);
                    if (int.TryParse(updateOffTrainTimeOffsetMinutes, out updateOffTrainTimeOffsetMinutesInt))
                    {
                        newUpdateOffTrainDateTime = newUpdateOffTrainDateTime.AddMinutes(updateOffTrainTimeOffsetMinutesInt);
                    }
                }
                OffTrainDateTimeString = newUpdateOffTrainDateTime.ToString("MM-dd-yyyy HH:mm") + (updateOffTrainTimezone != "" ? " " + updateOffTrainTimezone : "");
            } else {
                OffTrainDateTimeString = updateOffTrainDateOffsetDays + (updateOffTrainTimezone != "" ? " " + updateOffTrainTimezone : "");
            }
            if (!OffTrainDateTimeString.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Element.SetAttributeValue("Text", OffTrainDateTimeString);
                if (System.DateTime.TryParse(OffTrainDateTimeString, out parsedDateTime))
                {
                    crewMember.offTrainDateTime = parsedDateTime;
                    crewMember.offTrainTimezone = updateOffTrainTimezone;
                }
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.Click();
            if (!updateOffTrainLocation.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.Element.SetAttributeValue("Text", updateOffTrainLocation);
                crewMember.offTrainLocation = updateOffTrainLocation;
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.Click();
            if (!updateOffTrainMilepost.Equals(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
            {
                Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainMilepost.Element.SetAttributeValue("Text", updateOffTrainMilepost);
            }
            Keyboard.Press("{TAB}");
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Feedback.GetAttributeValue<string>("Text"));
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Self);
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            while(Trainsrepo.Train_Sheet.Crew.ApplyButton.Enabled && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                if (retries == 1)
                {
                    Trainsrepo.Train_Sheet.Crew.ApplyButton.Click();
                    Report.Info("Applied changes to crew record");
                }
                retries++;
            }
            
            if (!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Trainsrepo.Train_Sheet.Crew.ResetButton.Click();
                if (closeForms)
                {
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                }
                return;
            } else {
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Crew.ApplyButtonInfo, Trainsrepo.Train_Sheet.Crew.ApplyButtonInfo);
            }
            
            Ranorex.Report.Info("No Feedback message received. successfully updated crew member.");

            if (closeForms)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
        }
        /// <summary>
        /// Validate Consist Constraint Record in Trainsheet form
        /// </summary>
        /// <param name="trainSeed">trainseed of the train whose row need to be validated</param>
        /// <param name="consistType">Type of the consist constraint</param>
        /// <param name="consistValue">Value for the consist constraint</param>
        /// <param name="fromOpsta">Origin opsta</param>
        /// <param name="fromPass">Origin passcount</param>
        /// <param name="toOpsta">Destination opsta</param>
        /// <param name="toPass">Destination passcount</param>
        /// <param name="createQKS">Pass value as True if QKS needs to be created at the given opsta</param>
        /// <param name="closeForms">close forms or not at the end of the function</param>
        /// <param name="validateDoesExist">validate the row for its existance or non-existance</param>
        [UserCodeMethod]
        public static void ValidateConsistConstraintRecord_TrainSheet(string trainSeed, string consistType, string consistValue, string fromOpsta, string fromPass, string toOpsta, string toPass,
                                                                      bool createQKS, bool closeForms, bool validateDoesExist = true)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraints.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Consist Constraints Tab on Train Tab.");
                    return;
                }
            }

            bool wasRecordFound = false;

            int rowCount = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self.Rows.Count;
            retries = 0;
            while (rowCount == 0 && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                rowCount = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self.Rows.Count;
                retries++;
            }
            for (int i = 0; i < rowCount; i++)
            {
                Trainsrepo.ConsistConstraintIndex=i.ToString();
                if(!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.GetAttributeValue<string>("Text").Equals(consistType,StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                
                if(!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Value.GetAttributeValue<string>("Text").Equals(consistValue,StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("Text").Contains(fromOpsta))
                {
                    continue;
                }

                if (!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromPassCount.GetAttributeValue<string>("Text").Equals(fromPass))
                {
                    continue;
                }

                if (!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("Text").Contains(toOpsta))
                {
                    continue;
                }

                if (!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToPassCount.GetAttributeValue<string>("Text").Equals(toPass))
                {
                    continue;
                }

                if (!Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.CreateQKSAtOpSta.GetAttributeValue<string>("Text").Equals(createQKS.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                wasRecordFound = true;
                break;
            }
            
            if (wasRecordFound && validateDoesExist)
            {
                Ranorex.Report.Success("Found Train Consist Constrint Record of Type: {"+consistType+"}, Value: {"+consistValue+"}, From Opsta: {"+fromOpsta+"}, From Passcount: {"+fromPass+"} To Opsta: {"+toOpsta+"}, To Passcount: {"+toPass+"}, and CreateQKS at Opsta: {"+createQKS+"}");
            }
            else if (!wasRecordFound && validateDoesExist)
            {
                Ranorex.Report.Failure("Train Consist Constrint Record Not Found for Type: {"+consistType+"}, Value: {"+consistValue+"}, From Opsta: {"+fromOpsta+"}, From Passcount: {"+fromPass+"} To Opsta: {"+toOpsta+"}, To Passcount: {"+toPass+"}, and CreateQKS at Opsta: {"+createQKS+"}");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }
            else if (!wasRecordFound && !validateDoesExist)
            {
                Ranorex.Report.Success("Train Consist Constrint Record Not Found for Type: {"+consistType+"}, Value: {"+consistValue+"}, From Opsta: {"+fromOpsta+"}, From Passcount: {"+fromPass+"} To Opsta: {"+toOpsta+"}, To Passcount: {"+toPass+"}, and CreateQKS at Opsta: {"+createQKS+"}");
            }
            else if (wasRecordFound && !validateDoesExist)
            {
                Ranorex.Report.Failure("Found Train Consist Constrint Record of Type: {"+consistType+"}, Value: {"+consistValue+"}, From Opsta: {"+fromOpsta+"}, From Passcount: {"+fromPass+"} To Opsta: {"+toOpsta+"}, To Passcount: {"+toPass+"}, and CreateQKS at Opsta: {"+createQKS+"}");
                Trainsrepo.Train_Sheet.CancelButton.Click();
                return;
            }

            if (closeForms)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromTrainSeed"></param>
        /// <param name="toTrainSeed"></param>
        /// <param name="filterPos"></param>
        /// <param name="filterEngine"></param>
        /// <param name="filterEngineID"></param>
        /// <param name="filterGroup"></param>
        /// <param name="filterModel"></param>
        /// <param name="filterCompHP"></param>
        /// <param name="filterOriginLocation"></param>
        /// <param name="filterDestLocation"></param>
        /// <param name="copy"></param>
        [UserCodeMethod]
        public static void CopyEnginefromTraintoTrain_TrainSheet(string fromTrainSeed, string toTrainSeed, string expectedFeedback, bool copy, bool closeForms, string engineSeed, string engineRecord)
        {
            NS_OpenTrainsheetEngine_MainMenu(fromTrainSeed);
            bool rowFound=false;
            string fromTrain_id = NS_TrainID.GetTrainId(fromTrainSeed);
            string ToTrain_id = NS_TrainID.GetTrainId(toTrainSeed);
            string engineIndex="";
            NS_EngineConsistObject engineObject = NS_TrainID.GetEngineObjectFromTrain(fromTrainSeed, engineSeed);
            Report.Screenshot();
            if(Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count>0)
            {
                for(int i=0;i<Trainsrepo.Train_Sheet.Engine.EngineTable.Self.Rows.Count;i++)
                {
                    Trainsrepo.EngineIndex=i.ToString();
                    engineIndex=i.ToString();
                    if(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCellInfo.Exists(0))
                    {
                        Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click();
                        
                        if(Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Position.GetAttributeValue<string>("Text").Equals(engineObject.EnginePosition)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Engine.EngineText.GetAttributeValue<string>("Text").Equals(engineObject.EngineStatus)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.EngineID.GetAttributeValue<string>("Text").Equals(engineObject.EngineInitial+" "+engineObject.EngineNumber)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Group.GroupText.GetAttributeValue<string>("Text").Equals(engineObject.GroupNumber)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.Model.GetAttributeValue<string>("Text").Equals(engineObject.Model)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.CompensatedHP.GetAttributeValue<string>("Text").Equals(engineObject.CompensatedHP)
                           && Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.OriginLocation.GetAttributeValue<string>("Text").Contains(engineObject.OriginLocation)
                           && Trainsrepo.Train_Sheet.Engine.EngineDetailsPanel.DestinationLocation.GetAttributeValue<string>("Text").Contains(engineObject.DestinationLocation))
                        {
                            rowFound=true;
                            break;
                        }
                    }
                    else
                    {
                        Ranorex.Report.Error("Engine Row not found");
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
                        return;
                    }
                }
                if(rowFound)
                {
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click(Location.UpperLeft);
                    Trainsrepo.Train_Sheet.Engine.EngineTable.EngineRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right,Location.UpperLeft);
                    if(Trainsrepo.Train_Sheet.Engine.EngineMenuCellMenu.CopyEngineRecord.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Engine.EngineMenuCellMenu.CopyEngineRecordInfo,
                                                                  Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.SelfInfo);
                        Report.Info("Clicked on Copy Engine Record Option");
                        Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.ToTrainIDText.Click();
                        Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.ToTrainIDText.Element.SetAttributeValue("Text",ToTrain_id);
                        Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.ToTrainIDText.PressKeys("{TAB}");
                        
                        if (!CheckFeedback(Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.Feedback, expectedFeedback))
                        {
                            Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.Feedback.GetAttributeValue<string>("Text"));
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.Self);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.CancelButtonInfo,Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.SelfInfo);
                            }
                            return;
                        }
                        if(copy)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.OkButtonInfo,
                                                                              Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.SelfInfo);                       	
                        	
                        	string assignedDivision = "";
                        	string helperCrewPoolID = "";
                        	string defaultDataApplied = "";
                        	string reportingPassCount = "";
                        	string reportingLocation = "";
                        	string reportingSource = "";
                        	string purpose = "";
                        	
                        	NS_TrainID.CreateEngineConsistRecord(toTrainSeed, engineSeed, engineRecord, assignedDivision, helperCrewPoolID, defaultDataApplied, reportingPassCount, reportingLocation, reportingSource, purpose);
                        	
                            Report.Info("Successfully copied Engine with no feedback");
                        }
                        else
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.CancelButtonInfo,
                                                                              Trainsrepo.Train_Sheet.Engine.Copy_Engine_Record.SelfInfo);
                            Report.Info("Successfully cancelled Engine copy");
                        }
                    }
                    else
                    {
                        Report.Failure("Copy Engine Record button is disabled");
                    }
                }
                else
                {
                    Ranorex.Report.Error("Engine was not found");
                    if (closeForms)
                    {
                        NS_CloseTrainsheet();
                    }
                    return;
                }
            }
            else
            {
                Report.Error("No Engine records found.");
            }
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        [UserCodeMethod]
        public static void CopyCrewFromTrainToTrain_TrainSheet(string fromTrainSeed, string toTrainSeed, string crewSeed, string crewMemberRecord, string expectedFeedback, bool copy, bool closeForms)
        {
            NS_OpenTrainsheetCrew_MainMenu(fromTrainSeed);
            bool crewFound=false;
            string fromTrain_id = NS_TrainID.GetTrainId(fromTrainSeed);
            string ToTrain_id = NS_TrainID.GetTrainId(toTrainSeed);
            NS_CrewMemberObject crewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
            
            if(Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count>0)
            {
                for (int i = 1; i < Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count; i++)
                {
                    
                    Trainsrepo.CrewIndex = i.ToString();
                    if (crewMember.firstInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                        crewMember.middleInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                        crewMember.lastName.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                    {
                        crewFound = true;
                        break;
                    }
                }
                
                Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click();
                if(crewFound)
                {
                    Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click(Location.UpperLeft);
                    Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right,Location.UpperLeft);
                    if(Trainsrepo.Train_Sheet.Crew.CrewMenuCellMenu.CopyCrewRecord.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Crew.CrewMenuCellMenu.CopyCrewRecordInfo,
                                                                  Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.SelfInfo);
                        Report.Info("Clicked on Copy Crew Record Option");
                        Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.ToTrainIDText.Click();
                        Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.ToTrainIDText.Element.SetAttributeValue("Text",ToTrain_id);
                        Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.ToTrainIDText.PressKeys("{TAB}");
                        
                        if (!CheckFeedback(Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.Feedback, expectedFeedback))
                        {
                            Ranorex.Report.Info("Received Feedback message: "+Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.Feedback.GetAttributeValue<string>("Text"));
                            Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.Self);
                            if (closeForms)
                            {
                                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.CancelButtonInfo,Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.SelfInfo);
                            }
                            return;
                        }
                        if(copy)
                        {
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.OkButtonInfo,
                                                                              Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.SelfInfo);
                        	
                        	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.OkButtonInfo,
                        	                                                 Trainsrepo.Train_Sheet.SelfInfo);
                        	
                        	Ranorex.Delay.Seconds(10);
                        	NS_CrewClass.RefactorAndCreateCrewMemberObject_CrewMemberRecords(crewSeed, crewMemberRecord, "", "");
                        	NS_OpenTrainsheetCrew_MainMenu(toTrainSeed);
                        	NS_CrewMemberObject newCrewMember = NS_CrewClass.GetCrewMemberObject(crewSeed);
                        	CultureInfo enUS = new CultureInfo("en-US");
                        	for (int i = 1; i < Trainsrepo.Train_Sheet.Crew.CrewTable.Self.Rows.Count; i++)
                        	{
                        		
                        		Trainsrepo.CrewIndex = i.ToString();
                        		if (newCrewMember.firstInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.FirstInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                        		    newCrewMember.middleInitial.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MiddleInitial.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase) &&
                        		    newCrewMember.lastName.Equals(Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.LastName.GetAttributeValue<string>("Text"), StringComparison.OrdinalIgnoreCase))
                        		{
                        			crewFound = true;
                        			Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.MenuCell.Click();
                        			break;
                        		}
                        	}
                        	string tempDateTime="";
                        	System.DateTime oDate = new System.DateTime();
							tempDateTime = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.OnDutyTime.OnDutyTimeText.Element.GetAttributeValueText("Time");
							
							if(tempDateTime.Contains("EST"))
							{
								tempDateTime = tempDateTime.Replace(" EST", "");
							}
							else if(tempDateTime.Contains("EDT"))
							{
								tempDateTime = tempDateTime.Replace(" EDT", "");
							}
							oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy",CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        	
							newCrewMember.onDutyTime = oDate.ToString("HHmm");
							newCrewMember.onDutyDate = oDate.ToString("MM/dd/yyyy");
							newCrewMember.onDutyDateTime = oDate;
							
							tempDateTime = Trainsrepo.Train_Sheet.Crew.CrewTable.CrewRowByIndex.HOSExpiration.HOSExpirationText.Element.GetAttributeValueText("Time");
							
							if(tempDateTime.Contains("EST"))
							{
								tempDateTime = tempDateTime.Replace(" EST", "");
							}
							else if(tempDateTime.Contains("EDT"))
							{
								tempDateTime = tempDateTime.Replace(" EDT", "");
							}
							oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy",CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
							newCrewMember.hosExpireTime = oDate.ToString("HHmm");
							newCrewMember.hosExpireDate = oDate.ToString("MM/dd/yyyy");
							newCrewMember.hosExpireDateTime = oDate;
                        	
							tempDateTime = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Element.GetAttributeValueText("Time");
							
							if(tempDateTime.Contains("EST"))
							{
								tempDateTime = tempDateTime.Replace(" EST", "");
							}
							else if(tempDateTime.Contains("EDT"))
							{
								tempDateTime = tempDateTime.Replace(" EDT", "");
							}
							oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy",CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
							newCrewMember.offDutyTime = oDate.ToString("HHmm");
							newCrewMember.offDutyDate = oDate.ToString("MM/dd/yyyy");
							newCrewMember.offDutyDateTime = oDate;
														
							if(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Element.GetAttributeValueText("Time")==null)
							{	
								tempDateTime = "";
								newCrewMember.onTrainTime = "";
								newCrewMember.onTrainDate = "";
								newCrewMember.onTrainDateTime = null;
							}
							else
							{	
								tempDateTime=Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainTime.OnTrainText.Element.GetAttributeValueText("Time");
								if(tempDateTime.Contains("EST"))
								{
									tempDateTime = tempDateTime.Replace(" EST", "");
								}
								else if(tempDateTime.Contains("EDT"))
								{
									tempDateTime = tempDateTime.Replace(" EDT", "");
								}
								oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy", CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
								newCrewMember.onTrainTime = oDate.ToString("HHmm");
								newCrewMember.onTrainDate = oDate.ToString("MM/dd/yyyy");
								newCrewMember.onTrainDateTime = oDate;
							}
							
							
                        	newCrewMember.onTrainLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainLocation.GetAttributeValue<string>("Text");
                        	newCrewMember.onPassCount= Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OnTrainPassCount.GetAttributeValue<string>("Text");
                        								
							if(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Element.GetAttributeValueText("Time") == null)
							{	tempDateTime = "";
								newCrewMember.offDutyTime = "";
								newCrewMember.offDutyDate = "";
								newCrewMember.offDutyDateTime = null;
							}
							else
							{	
								tempDateTime=Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyTime.OffDutyTimeText.Element.GetAttributeValueText("Time");
								if(tempDateTime.Contains("EST"))
								{
									tempDateTime = tempDateTime.Replace(" EST", "");
								}
								else if(tempDateTime.Contains("EDT"))
								{
									tempDateTime = tempDateTime.Replace(" EDT", "");
								}
								oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy",CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
								newCrewMember.offDutyTime = oDate.ToString("HHmm");
								newCrewMember.offDutyDate = oDate.ToString("MM/dd/yyyy");
								newCrewMember.offDutyDateTime = oDate;
							}
							
							
                        	newCrewMember.offDutyLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffDutyLocation.GetAttributeValue<string>("Text");
                        	
                        	if(Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Element.GetAttributeValueText("Time")==null)
							{	
                        		tempDateTime = "";
								newCrewMember.offTrainTime = "";
								newCrewMember.offTrainDate = "";
								newCrewMember.offTrainDateTime = null;
                        	}
                        	else
                        	{	
                        		tempDateTime = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainTime.OffTrainTimeText.Element.GetAttributeValueText("Time");
                        		if(tempDateTime.Contains("EST"))
                        		{
                        			tempDateTime = tempDateTime.Replace(" EST", "");
                        		}
                        		else if(tempDateTime.Contains("EDT"))
                        		{
                        			tempDateTime = tempDateTime.Replace(" EDT", "");
                        		}
                        		oDate = System.DateTime.ParseExact(tempDateTime, "ddd MMM dd HH:mm:ss yyyy",CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        		newCrewMember.offTrainTime = oDate.ToString("HHmm");
                        		newCrewMember.offTrainDate = oDate.ToString("MM/dd/yyyy");
                        		newCrewMember.offTrainDateTime = oDate;
                        	}							
							
                        	newCrewMember.offTrainLocation = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainLocation.GetAttributeValue<string>("Text");
                        	newCrewMember.offPassCount = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.OffTrainPassCount.GetAttributeValue<string>("Text");
                        	newCrewMember.crewId = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.CrewID.GetAttributeValue<string>("Text");
                        	newCrewMember.segment = Trainsrepo.Train_Sheet.Crew.CrewDetailsPanel.Segment.GetAttributeValue<string>("Text");
                        }
                        else
                        {
                        	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.CancelButtonInfo,
                        	                                                  Trainsrepo.Train_Sheet.Crew.Copy_Crew_Record.SelfInfo);
                        }
                    }
                    else
                    {
                    	Report.Failure("Copy Crew Record button is disabled");
                    }
                }
                else
                {
                	Ranorex.Report.Error("Crew with Name {" + crewMember.firstInitial + " " + crewMember.middleInitial + " " + crewMember.lastName + "} was not found");
                }
            }
            else
            {
            	Report.Error("No Crew records found.");
            }
            if (closeForms)
            {
            	NS_CloseTrainsheet();
            }
        }
        /// <summary>
        /// Navigate to Train Trainsheet from main menu, and verifies that whether the train clearance is issued or not
        /// </summary>
        /// <param name="trainSeed">Input - trainseed </param>
        [UserCodeMethod]
        public static void NS_ValidateTrainClearanceIssued_Trainsheet(string trainSeed, bool expTrainClearenceIssued = true)
        {
        	NS_OpenTrainsheet_MainMenu(trainSeed);
        	if(expTrainClearenceIssued)
        	{
        		if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.TrainClearanceButton,
        		                                                      "TrainClearanceGreen", true))
        		{
        			Report.Success("Train clearance is issued");
        		}
        		else
        		{
        			Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.CurrentConsistSummary.Self);
        			Report.Failure("Train clearance is not issued");
        		}
        	}
        	else
        	{
        		if(GeneralUtilities.ValidateColorForAnyAdapterByPixel(Trainsrepo.Train_Sheet.CurrentConsistSummary.TrainClearanceButton,
        		                                                      "TrainClearanceGreen", false))
        		{
        			Report.Success("Train has no train clearance");
        		}
        		else
        		{
        			Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.CurrentConsistSummary.Self);
        			Report.Failure("Train has train clearance");
        		}
        	}
        	
        }
        
        [UserCodeMethod]
        public static void NS_ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_ConsistSummary(string trainSeed, string opsta, string menuOption, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummaryInfo,
                                                      Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.SelfInfo);
            
            
            int rowCount = Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.Self.Rows.Count;
            if (rowCount == 0)
            {
                Ranorex.Report.Failure("No rows in consist summary table.");
                return;
            }
            
            bool foundRow = false;
            for(int i=0; i < rowCount; i++)
            {
                Trainsrepo.ConsistSummaryIndex = i.ToString();
                
                if (Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.OpStaName.GetAttributeValue<string>("StationId").Equals(opsta,StringComparison.OrdinalIgnoreCase))
                {
                    foundRow = true;
                    break;
                }
            }
            
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find consist summary row with opsta {" + opsta + "}.");
                return;
            }
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.MenuCell.Click(Location.UpperLeft);
            
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryTable.ConsistSummaryRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right,Location.UpperLeft);
            switch(menuOption.ToUpper())
            {
                case "DELETE":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.Delete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.DeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Option");
                    }
                    else
                    {
                        Report.Failure("Delete button is disabled");
                    }
                    break;
                case "RESET":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.Reset.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.ResetInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Reset Option");
                    }
                    else
                    {
                        Report.Failure("Reset button is disabled");
                    }
                    break;
                case "UNDELETE":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.Undelete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.UndeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Option");
                    }
                    else
                    {
                        Report.Failure("Undelete button is disabled");
                    }
                    break;
                case "INSERTROW":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.InsertRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.InsertRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Insert Row Option");
                    }
                    else
                    {
                        Report.Failure("Insert Row button is disabled");
                    }
                    break;
                case "DELETEROW":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.DeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.DeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Row Option");
                    }
                    else
                    {
                        Report.Failure("Delete Row button is disabled");
                    }
                    break;
                case "UNDELETEROW":
                    if(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.UndeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.UndeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistSummary.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Row Option");
                    }
                    else
                    {
                        Report.Failure("Undelete Row button is disabled");
                    }
                    break;
                default:
                    Ranorex.Report.Error("Invalid Selection");
                    break;
                    
            }
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButtonInfo);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButton.Click();
            Report.Info("Clicked on Apply button");

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        
        [UserCodeMethod]
        public static void NS_ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint(string trainSeed, string fromOpsta, string toOpsta, string type, string menuOption, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistConstraintsInfo,
                                                      Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.SelfInfo);
            
            int rowCount = Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.Self.Rows.Count;
            if (rowCount == 0)
            {
                Ranorex.Report.Failure("No rows in consist constraint table.");
                return;
            }
            
            bool foundRow = false;
            for(int i=0; i < rowCount; i++)
            {
                Trainsrepo.ConsistConstraintIndex = i.ToString();
                
                if (Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.FromOpStaName.GetAttributeValue<string>("Text").Contains(fromOpsta)
                   && Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.ToOpStaName.GetAttributeValue<string>("Text").Contains(toOpsta)
                   && Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.Type.TypeText.GetAttributeValue<string>("Text").Equals(type,StringComparison.OrdinalIgnoreCase))
                {
                    foundRow = true;
                    break;
                }
            }
            
            if (!foundRow)
            {
                Ranorex.Report.Failure("Could not find consist constraint row with From opsta {" + fromOpsta + "}, To opsta {" + toOpsta + "} & Type {" + type + "}.");
                return;
            }
            Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.MenuCell.Click(Location.UpperLeft);
            
            Trainsrepo.Train_Sheet.Train.ConsistConstraints.ConsistConstraintTable.ConsistConstraintRowByIndex.MenuCell.Click(WinForms.MouseButtons.Right,Location.UpperLeft);
            switch(menuOption.ToUpper())
            {
                case "DELETE":
                    if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.DeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.DeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Option");
                    }
                    else
                    {
                        Report.Failure("Delete button is disabled");
                    }
                    break;
                
                case "UNDELETE":
                    if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.UndeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.UndeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Option");
                    }
                    else
                    {
                        Report.Failure("Undelete button is disabled");
                    }
                    break;
                case "INSERT":
                    if(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.InsertRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.InsertRowInfo,
                                                                          Trainsrepo.Train_Sheet.Train.ConsistConstraints.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Insert Row Option");
                    }
                    else
                    {
                        Report.Failure("Insert Row button is disabled");
                    }
                    break;
                default:
                    Ranorex.Report.Error("Invalid Selection");
                    break;
                    
            }
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo,Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButtonInfo);
            Trainsrepo.Train_Sheet.Train.ConsistConstraints.ApplyButton.Click();
            Report.Info("Clicked on Apply button");

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="SCAC"></param>
        [UserCodeMethod]
        public static void NS_ValidateSCAC_Trainsheet(string trainSeed, string SCAC, bool closeForm)
        {
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
        	if(Trainsrepo.Train_Sheet.SCACText.GetAttributeValue<string>("Text").Equals(SCAC,StringComparison.OrdinalIgnoreCase))
        	{
        		Report.Success("Train is created with SCAC : "+SCAC);
        	}
        	else
        	{
        		Report.Failure("Train is not created with SCAC : "+SCAC+" instead is created with "+Trainsrepo.Train_Sheet.SCACText.GetAttributeValue<string>("Text")+".");
        	}
        	if (closeForm)
        	{
        	   NS_CloseTrainsheet();
        	}
        }
        
        
        
        [UserCodeMethod]
        public static void AddConsistSummary_Trainsheet(string trainSeed, string opsta, string passCount, string loads, string empties,
                                                         string tons, string length, string optConsistSeed, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetTrain_MainMenu(trainSeed);
            
            int retries = 0;
            if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
            {
                Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                
                while (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Click();
                    retries++;
                }
                if (!Trainsrepo.Train_Sheet.Train.TrainConsistTabs.ConsistSummary.Selected)
                {
                    Ranorex.Report.Error("Could not switch to Consist Summary Tab on Train Tab.");
                    return;
                }
            }
            
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.OpStaName.Click();
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.OpStaName.PressKeys(opsta);
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.PassCount.Click();
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.PassCount.PressKeys(passCount);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.PassCount.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Loads.PressKeys(loads);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Loads.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Empties.PressKeys(empties);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Empties.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Tons.PressKeys(tons);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Tons.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Length.PressKeys(length);
            Trainsrepo.Train_Sheet.Train.ConsistSummary.ConsistSummaryInputTable.ConsistSummaryInputRow.Length.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            	Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            		                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	}
            	return;
            }
            
            if(string.IsNullOrEmpty(Trainsrepo.Train_Sheet.Feedback.TextValue) && string.IsNullOrEmpty(expectedFeedback))
            {
            	retries = 0;
            	while(Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButton.Enabled && retries < 5)
            	{
            		Trainsrepo.Train_Sheet.Train.ConsistSummary.ApplyButton.Click();
            		Ranorex.Delay.Milliseconds(1000);
            		retries++;
            	}
            	
            	if (!string.IsNullOrEmpty(optConsistSeed))
            	{
            		PDS_CORE.Code_Utils.NS_TrainID.CreateConsistSummaryRecord(trainSeed, optConsistSeed, opsta, passCount, "", "", "", loads, empties, tons, length, "", "", "", "", "", "", "", "");
            	}
            	
            	if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
            	{
            		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Train.ConsistSummary.Self);
            		Trainsrepo.Train_Sheet.Train.ConsistSummary.RefreshButton.Click();
            		if (closeForms)
            		{
            			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            			                                                  Trainsrepo.Train_Sheet.SelfInfo);
            		}
            		return;
            	}
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            	Ranorex.Report.Info("No Feedback message received. Successfully updated Consist Summary.");
            	return;
            }
            
            
            if(closeForms)
            {
                GeneralUtilities.clickItemIfItExists(Trainsrepo.Train_Sheet.CancelButtonInfo);
            }
        }
        
        /// <summary>
        /// Opens and fills Create Train form with a trainId and Clicks Create
        /// </summary>
        /// <param name="trainSeed">trainseed of the train which needs to be created</param>
        /// <param name="timeType">Ordered Called or Start</param>
        /// <param name="dateTimeOffsetMinutes">offSet for datetime, if not convertable int, will use the value itself</param>
        /// <param name="dateTimeTimeZone">If the dateTimeOffsetMinutes is an int, this will be used for the times timeZone</param>
        /// <param name="expectedFeedback">Expected Feedback</param>
        /// <param name="closeForms">Whather to close the forms that were opened</param>
        [UserCodeMethod]
        public static void NS_CreateTrain_CreateTrainForm(string trainSeed, string timeType, string dateTimeOffsetMinutes, string dateTimeTimeZone, string expectedFeedback, bool closeForms)
        {
            NS_OpenCreateTrain_MainMenu();
            
            if(!Trainsrepo.Create_Train.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Create Train Form not open");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CancelButtonInfo,
                                                                      Trainsrepo.Create_Train.SelfInfo);
                }
                return;
            }
            
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                trainId = trainSeed;
            }
            
            Trainsrepo.Create_Train.TrainIDText.Click();
            Trainsrepo.Create_Train.TrainIDText.Element.SetAttributeValue("Text", trainId);
            Trainsrepo.Create_Train.TrainIDText.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Create_Train.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Create_Train.Self);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CancelButtonInfo,
                                                                      Trainsrepo.Create_Train.SelfInfo);
                }
                return;
            }
            
            if (Trainsrepo.Create_Train.TimeType.TimeTypeText.SelectedItemText != timeType)
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Create_Train.TimeType.TimeTypeMenuButtonInfo, Trainsrepo.Create_Train.TimeType.TimeTypeList.SelfInfo);
                Trainsrepo.TimeType = timeType;
                if (!Trainsrepo.Create_Train.TimeType.TimeTypeList.TimeTypeListItemByTimeTypeInfo.Exists(0))
                {
                    Ranorex.Report.Error("Time Type of {" + timeType + "} is not a valid time type in the list");
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CancelButtonInfo,
                                                                          Trainsrepo.Create_Train.SelfInfo);
                    }
                    return;
                }
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.TimeType.TimeTypeList.TimeTypeListItemByTimeTypeInfo,
                                                                  Trainsrepo.Create_Train.TimeType.TimeTypeList.SelfInfo);
                Trainsrepo.Create_Train.TimeType.TimeTypeText.PressKeys("{TAB}");
            }
            
            string dateTimeFormatted = "";
            int dateTimeOffsetMinutesInt = 0;
            if (int.TryParse(dateTimeOffsetMinutes, out dateTimeOffsetMinutesInt))
            {
                //value is int and can be used to increment or decrement the time
                dateTimeFormatted = System.DateTime.Now.AddMinutes(dateTimeOffsetMinutesInt).ToString("MM-dd-yyyy hh:mm t");
                if (dateTimeTimeZone != "")
                {
                    dateTimeFormatted = dateTimeFormatted + " " + dateTimeTimeZone;
                }
            } else {
                dateTimeFormatted = dateTimeOffsetMinutes;
            }
            
            if (Trainsrepo.Create_Train.DateAndTime.DateAndTimeText.Text != dateTimeFormatted)
            {
                Trainsrepo.Create_Train.DateAndTime.DateAndTimeText.Click();
                Trainsrepo.Create_Train.DateAndTime.DateAndTimeText.Element.SetAttributeValue("Text", dateTimeFormatted);
                Trainsrepo.Create_Train.DateAndTime.DateAndTimeText.PressKeys("{TAB}");
                
                if(!CheckFeedback(Trainsrepo.Create_Train.Feedback, expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Create_Train.Self);
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CancelButtonInfo,
                                                                          Trainsrepo.Create_Train.SelfInfo);
                    }
                    return;
                }
            }
            
            Trainsrepo.Create_Train.CreateTrainButton.Click();
            if(!CheckFeedback(Trainsrepo.Create_Train.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Create_Train.Self);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CancelButtonInfo,
                                                                      Trainsrepo.Create_Train.SelfInfo);
                }
                return;
            } else if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "} but got no feedback");
            }
            
            if(Trainsrepo.Create_Train.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Create_Train.CreateTrainButtonInfo, Trainsrepo.Create_Train.SelfInfo);
            }
            
            Ranorex.Report.Info("Successfully created Train");
        }
        
        /// <summary>
        /// Add EOT/Caboose row
        /// </summary>
        /// <param name="trainSeed">Train to add EOT Caboose to</param>
        /// <param name="type">Type of caboose</param>
        /// <param name="workingStatus">Working status of caboose</param>
        /// <param name="initial">Part of the eot caboose id</param>
        /// <param name="number">Part of the eot caboose id</param>
        /// <param name="origin">origin of caboose</param>
        /// <param name="destination">destination of caboose</param>
        /// <param name="expectedFeedback">Feedback to be verified</param>
        /// <param name="closeForms">bool value to close the form or not</param>
        [UserCodeMethod]
        public static void ManuallyAddEOTCaboose_Trainsheet_NS(string trainSeed, string type, string workingStatus, string initial, string number, string origin,
                                                               string destination, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetEOTCaboose_MainMenu(trainSeed);
            
            if (!Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Trainsheet not open to EOT Caboose tab");
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.EOTCabooseIndex = "0";
            
            switch (type.ToLower())
            {
                case "eot":
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeTextInfo,
                                                              Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.EOTInfo,
                                                                      Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                    Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeText.PressKeys("{TAB}");
                    break;
                case "caboose":
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeTextInfo,
                                                              Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.CabooseInfo,
                                                                      Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeList.SelfInfo);
                    Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Type.TypeText.PressKeys("{TAB}");
                    break;
                default:
                    Report.Error("Error", "Invalid selection");
                    break;
            }
            
            switch (workingStatus.ToLower())
            {
                case "working":
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusTextInfo,
                                                              Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.WorkingInfo,
                                                                      Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                    Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusText.PressKeys("{TAB}");
                    break;
                case "deadintow":
                    GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusTextInfo,
                                                              Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.DeadInTowInfo,
                                                                      Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusList.SelfInfo);
                    Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.WorkingStatus.WorkingStatusText.PressKeys("{TAB}");
                    break;
                default:
                    Report.Error("Error","Invalid selection");
                    break;
            }
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            string symbol = initial + " " + number;
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.Click();
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.PressKeys(symbol);
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.InitialAndNumber.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.PressKeys(origin);
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Origin.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.PressKeys(destination);
            Trainsrepo.Train_Sheet.EOTCaboose.EOTCabooseTable.EOTCabooseRowByIndex.Destination.PressKeys("{TAB}");
            
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }

            Trainsrepo.Train_Sheet.EOTCaboose.ApplyButton.Click();
            if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
            {
                Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.EOTCaboose.Self);
                GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo,
                                                                  Trainsrepo.Train_Sheet.EOTCaboose.ResetButtonInfo);
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                      Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Expected feedback of {" + expectedFeedback + "}.");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Adds a comment into Trainsheet History
        /// </summary>
        /// <param name="trainSeed">Train to open the trainsheet history tab for</param>
        /// <param name="comment">Comment to add to the Trainsheet History</param>
        [UserCodeMethod]
        public static void AddCommentAndValidateInTrainsheetHistory_Trainsheet_NS(string trainSeed, string comment)
        {
            NS_OpenTrainsheetHistory_MainMenu(trainSeed);
            if(!Trainsrepo.Train_Sheet.History.HistoryTable.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Cannot find Trainsheet History table");
                return;
            }
            if (!Trainsrepo.Train_Sheet.History.AddCommentButton.Enabled)
            {
                Ranorex.Report.Failure("Cannot find Add Comment button is not enabled");
                return;
            }
            
            GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.History.AddCommentButtonInfo,Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.SelfInfo);
            
            Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.CommentsText.Click();
            Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.CommentsText.Element.SetAttributeValue("Text", comment);
            Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.CommentsText.PressKeys("{TAB}");
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.OkButtonInfo,Trainsrepo.Train_Sheet.History.Train_Sheet_Comment_Dialog.SelfInfo);
            
            Report.Info("Comment added in History Tab.");
            NS_ValidateTrainSheetHistory(trainSeed, comment,"","","","",true);
        }
        
        /// <summary>
        /// Clicks a menu option in the Trainsheet delay table menu cell menu
        /// </summary>
        /// <param name="trainSeed">Train to open the trainsheet delay tab for</param>
        /// <param name="filterFromLocation">From location to filter row by</param>
        /// <param name="filterToLocation">To location to filter row by</param>
        /// <param name="filterSource">Source to filter row by</param>
        /// <param name="filterDuration">Duration to filter row by</param>
        /// <param name="filterCode">Code to filter row by</param>
        /// <param name="filterState">State to filter row by</param>
        /// <param name="menuOption">Working status that is to be updated</param>
        /// <param name="apply">Symbol that is to be updated</param>
        /// <param name="expectedFeedback">Feedback to be verified</param>
        /// <param name="closeForms">bool value to close the form or not</param>
        [UserCodeMethod]
        public static void NS_ClickDelayRowMenuOption_Trainsheet(string trainSeed, string filterFromLocation, string filterToLocation, string filterSource, string filterDuration, string filterCode,
                                                                 string filterState, string menuOption, bool apply, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;
            
            for (int i = 0; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex = i.ToString();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Self.EnsureVisible();
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Contains(filterState)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(filterFromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(filterCode,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(filterSource,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(filterDuration,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.GetAttributeValue<string>("Text").Contains(filterToLocation))
                {
                    delayRowFound = true;
                    break;
                }
            }
            if (!delayRowFound)
            {
                Ranorex.Report.Failure("Could not find delay Row to open menu for");
                return;
            }
            
            GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo,
                                                           Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
            
            switch(menuOption.ToUpper())
            {
                case "DELETE":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Delete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.DeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                    
                case "RESET":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Reset.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.ResetInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Reset Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                case "UNDELETE":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Undelete.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.UndeleteInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Undelete Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                case "INSERTROW":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.InsertRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.InsertRowInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Insert Row Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                    
                case "DELETEROW":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.DeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.DeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Delete Row Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                case "UNDELETEROW":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.UndeleteRow.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.UndeleteRowInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on UndeleteRow Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                case "REVIEW":
                    if(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Review.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Delay.MenuCellMenu.ReviewInfo,
                                                                          Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
                        Report.Info("Clicked on Review Option");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Menu Option {" + menuOption + "} is not Enabled");
                    }
                    break;
                default:
                    Ranorex.Report.Error("Invalid Selection");
                    break;
                    
            }
            
            if (apply)
            {
                Trainsrepo.Train_Sheet.Delay.ApplyButton.Click();
                Report.Info("Clicked on Apply button");
                if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback , expectedFeedback))
                {
                    Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Delay.Self);
                    Trainsrepo.Train_Sheet.EOTCaboose.ResetButton.Click();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                          Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
                } else {
                    GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Delay.ApplyButtonInfo,Trainsrepo.Train_Sheet.Delay.ApplyButtonInfo);
                }
            }
            
            if (expectedFeedback != "")
            {
                Ranorex.Report.Failure("Did not get expected feedback of {" + expectedFeedback + "}.");
            }

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Clicks a menu option in the Trainsheet delay table menu cell menu
        /// </summary>
        /// <param name="trainSeed">Train to open the trainsheet delay tab for</param>
        /// <param name="filterFromLocation">From location to filter row by</param>
        /// <param name="filterToLocation">To location to filter row by</param>
        /// <param name="filterSource">Source to filter row by</param>
        /// <param name="filterDuration">Duration to filter row by</param>
        /// <param name="filterCode">Code to filter row by</param>
        /// <param name="filterState">State to filter row by</param>
        /// <param name="menuOption">Working status that is to be updated</param>
        /// <param name="apply">Symbol that is to be updated</param>
        /// <param name="expectedFeedback">Feedback to be verified</param>
        /// <param name="closeForms">bool value to close the form or not</param>
        [UserCodeMethod]
        public static void NS_ValidateDelayRowMenuOptionEnabled_Trainsheet(string trainSeed, string filterFromLocation, string filterToLocation, string filterSource, string filterDuration, string filterCode,
                                                                        string filterState, string menuOption, bool isEnabled, string expectedFeedback, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;
            
            for (int i = 0; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex = i.ToString();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Self.EnsureVisible();
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Contains(filterState)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(filterFromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(filterCode,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(filterSource,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(filterDuration,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.GetAttributeValue<string>("Text").Contains(filterToLocation))
                {
                    delayRowFound = true;
                    break;
                }
            }
            if (!delayRowFound)
            {
                Ranorex.Report.Failure("Could not find delay Row to open menu for");
                return;
            }
            
            GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo,
                                                           Trainsrepo.Train_Sheet.Delay.MenuCellMenu.SelfInfo);
            bool menuOptionEnabledStatus;
            
            switch(menuOption.ToUpper())
            {
                case "DELETE":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Delete.Enabled;
                    break;
                case "RESET":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Reset.Enabled;
                    break;
                case "UNDELETE":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Undelete.Enabled;
                    break;
                case "INSERTROW":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.InsertRow.Enabled;
                    break;
                case "DELETEROW":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.DeleteRow.Enabled;
                    break;
                case "UNDELETEROW":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.UndeleteRow.Enabled;
                    break;
                case "REVIEW":
                    menuOptionEnabledStatus = Trainsrepo.Train_Sheet.Delay.MenuCellMenu.Review.Enabled;
                    break;
                default:
                    Ranorex.Report.Error("Invalid Selection");
                    if(closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
                    }
                    return;
            }
            
            if(menuOptionEnabledStatus == isEnabled)
            {
                Ranorex.Report.Success("Expected and found Menu Option - " + menuOption + " to be " + (isEnabled ? "Enabled":"Disabled"));
            }
            else
            {
                Ranorex.Report.Failure("Expected Menu Option - " + menuOption + " to be " + (isEnabled ? "Enabled":"Disabled") + " and found to be " + (menuOptionEnabledStatus ? "Enabled":"Disabled") + ".");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
          /// <summary>
        /// To update TrainConsist Summary Records in ConsistObject
        /// </summary>
        /// <param name="trainSeed">trainSeed: to get train object and add in consisit records</param>
        /// <param name="optConsistSeed">optConsistSeed: to update add in consisit records</param>
        /// <param name="opsta">opsta: to update add in consisit records</param>
        /// <param name="loads">loads: to update add in consisit records</param>
        /// <param name="empties">empties: to update add in consisit records</param>
        /// <param name="tons">tons: to update add in consisit records</param>
        /// <param name="length">length: to update add in consisit records</param>
        [UserCodeMethod]
        public static void NS_UpdateTrainConsistSummaryConsistObjectRecords_NS(string trainSeed, string consistSeed, string opsta, string loads, string empties, string tons, string length)
        {
        	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
        	if (TrainObject.ConsistRecordExists(consistSeed))
        	{
        		PDS_CORE.Code_Utils.NS_TrainID.CreateConsistSummaryRecord(trainSeed, consistSeed, opsta, "", "", "", "", loads, empties, tons, length, "", "", "", "", "", "", "", "");
        	}
        	else 
        	{
        		Ranorex.Report.Error("No consist records found for updated consist object record.");
        	}
        }
        
        /// <summary>
        /// Opens express create train form if it is not already opened
        /// </summary>
        public static void OpenExpressCreateTrain_MainMenu()
        {
        	if(!Trainsrepo.Express_Create_Train.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainsButtonInfo,
        		                                          MainMenurepo.PDS_Main_Menu.TrainsMenu.SelfInfo);
        		
        		GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrainsMenu.ExpressCreateTrainInfo,
        		                                          Trainsrepo.Express_Create_Train.SelfInfo);
        		
        		if (!Trainsrepo.Express_Create_Train.SelfInfo.Exists(0))
        		{
        			Ranorex.Report.Error("Unable to open Express Create Train form");
        			return;
        		}
        	}
        	return;
        }
        
        /// <summary>
        /// Express create train/ Train creation from template train
        /// </summary>
        /// <param name="newTrainSeed"></param>
        /// <param name="templateTrainSeed"></param>
        /// <param name="expectedFeedback"></param>
        /// <param name="reset"></param>
        /// <param name="clickOnOk"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_ExpressCreateTrain(string newTrainSeed, string templateTrainSeed, string expectedFeedback, bool reset, bool clickOnOk, bool closeForm, bool closeTrainSheet)
        {
        	string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(templateTrainSeed);
        	if (trainId == null && templateTrainSeed == "")
        	{
        		Ranorex.Report.Error("No TrainId found for trainSeed {"+templateTrainSeed+"}, ensure correct trainSeed and that train was made");
        		return;
        	}
        	
        	string newTrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(newTrainSeed);
        	if(newTrainId == null)
        	{
        		newTrainId = NS_TrainID.CreateTrainID(newTrainSeed);
        	}
        	else
        	{
        		Ranorex.Report.Info("train Seed {"+newTrainSeed+"} has train ID :{"+newTrainId+"}");
        	}
        	
        	//Opens the express create train form if not already opened
        	OpenExpressCreateTrain_MainMenu();
        	
        	if(Trainsrepo.Express_Create_Train.SelfInfo.Exists(0))
        	{
        		Trainsrepo.Express_Create_Train.TemplateTrain.TrainSymbolSectionText.Element.SetAttributeValue("Text", trainId);
        		Trainsrepo.Express_Create_Train.TemplateTrain.TrainSymbolSectionText.PressKeys("{TAB}");
        		
        		if (!NS_Bulletin.CheckFeedback(Trainsrepo.Express_Create_Train.Feedback, expectedFeedback))
        		{
        			if (closeForm)
        			{
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Express_Create_Train.CancelButtonInfo,
        				                                                  Trainsrepo.Express_Create_Train.SelfInfo);
        			}
        			return;
        		}
        		string containingTrainID = Trainsrepo.Express_Create_Train.NewTrain.TrainIDText.GetAttributeValue<string>("Text");
        		Ranorex.Report.Info("Containing: "+containingTrainID);
        		Ranorex.Report.Info("TrainID : "+newTrainId);
        		
        		if(containingTrainID.Contains(newTrainId))
        		{
        			Trainsrepo.Express_Create_Train.NewTrain.TrainIDText.PressKeys("{TAB}");
        		}
        		else
        		{
        			Trainsrepo.Express_Create_Train.NewTrain.TrainIDText.Element.SetAttributeValue("Text", newTrainId+" "+(System.DateTime.Now.Day).ToString());
        			Trainsrepo.Express_Create_Train.NewTrain.TrainIDText.PressKeys("{TAB}");
        		}
        		
        		if (!NS_Bulletin.CheckFeedback(Trainsrepo.Express_Create_Train.Feedback, expectedFeedback))
        		{
        			if (closeForm)
        			{
        				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Express_Create_Train.CancelButtonInfo,
        				                                                  Trainsrepo.Express_Create_Train.SelfInfo);
        			}
        			return;
        		}

        		if(reset)
        		{
        			Trainsrepo.Express_Create_Train.ResetButton.Click();
        			int retries = 0;
        			while(Trainsrepo.Express_Create_Train.TemplateTrain.TrainSymbolSectionText.GetAttributeValue<string>("Text") != "" && retries < 3)
        			{
        				Ranorex.Delay.Milliseconds(500);
        				Trainsrepo.Express_Create_Train.ResetButton.Click();
        				retries++;
        			}
        		}
        		
        		if(clickOnOk)
        		{
        			GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Express_Create_Train.OkButtonInfo,
        			                                          Trainsrepo.Train_Sheet.SelfInfo);
        			if(closeTrainSheet)
        			{
        				NS_CloseTrainsheet();
        				return;
        			}
        			
        		}
        		
        		if(closeForm)
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Express_Create_Train.CancelButtonInfo,
        			                                                  Trainsrepo.Express_Create_Train.SelfInfo);
        		}
        	}
        	else
        	{
        		Ranorex.Report.Error("Create Train From Template form is not opened");
        		return;
        	}
        }
        
        /// <summary>
        /// Validate the Delay Row count in Trainsheet Delay tab
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="expectedDelayRowCount">State of the delay</param>
        /// <param name="closeForms">Source from where Delay is added</param>
        [UserCodeMethod]
        public static void NS_ValidateDelayRowCount_TrainSheetDelay(string trainseed, int expectedDelayRowCount, bool closeForms = true)
        {
        	int actualDelayRowCount = 0;
        	NS_OpenTrainsheetDelay_MainMenu(trainseed);
        	Trainsrepo.Train_Sheet.Delay.RefreshButton.DoubleClick();

        	actualDelayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
        	
        	if(actualDelayRowCount == expectedDelayRowCount)
        	{
        		Ranorex.Report.Success("Expected number of Delay Record to be{"+expectedDelayRowCount+"} and found Delay record is{" +actualDelayRowCount+ "}.");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Expected number of Delay Record to be{" +expectedDelayRowCount+"} but found Delay record is{" +actualDelayRowCount+ "}.");
        		Report.Screenshot(Trainsrepo.Train_Sheet.Delay.DelayTable.Self);
        	}
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        // <summary>
        // Validate a particular Delay Row is enabled or not in 'Train Sheet' Dealy tab
        // </summary>
        // <param name="trainSeed">trainseed</param>
        // <param name="delayRowIndex">Delay row number</param>
        // <param name="expDelayRowEnabled">State of the delay row</param>
        // <param name="closeForms">closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateDelayRowIsEnabled_TrainSheetDelay(string trainseed, int delayRowIndex, bool expDelayRowEnabled, bool closeForms = true)
        {
        	bool actDelayRowEnabled;
        	NS_OpenTrainsheetDelay_MainMenu(trainseed);

        	Trainsrepo.Train_Sheet.Delay.RefreshButton.DoubleClick();

        	Trainsrepo.DelayIndex = delayRowIndex.ToString();

        	Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.DoubleClick();
        	actDelayRowEnabled = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeList.SelfInfo.Exists(0);
        	if(actDelayRowEnabled == expDelayRowEnabled)
        	{
        		Ranorex.Report.Success("Expecteed delay record to be {" +expDelayRowEnabled+ "} for row {" +(delayRowIndex+1)+ "} and found to be {" +actDelayRowEnabled+ "}.");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Expecteed delay record to be {" +expDelayRowEnabled+ "} for row {" +(delayRowIndex+1)+ "} but found to be {" +actDelayRowEnabled+ "}.");
        		Report.Screenshot(Trainsrepo.Train_Sheet.Delay.DelayTable.Self);
        	}
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Validate Delay Specif Fields details of a Delay record for ant Train
        /// </summary>
        /// <param name="trainSeed_trainToValidateDelayRecord">Pass the seed of train for which DelaySpecific records want to validate</param>
        /// <param name="delayCode">Pass the delay code for which user wants to validate DelaySepfic fields</param>
        /// <param name="trainseed_expTrainInDelaySpecificField">Pass the seed of train which user expect in DelaySpecific field</param>
        /// <param name="expCrewId">Pass the expected 'Crew ID' value</param>
        /// <param name="expCrewSegments">Pass the expected 'Crew Segments' value</param>
        /// <param name="expComments">Pass the expected 'Comments' value</param> 
        /// <param name="closeForms">Pass 'TRUE' or 'FALSE'</param>
        [UserCodeMethod]
        public static void NS_ValidateDelaySpecificFields(string trainSeed_trainToValidateDelayRecord, string trainseed_expTrainInDelaySpecificField, string expCrewId, string expCrewSegments, string expComments, string delayCode, bool closeForms = true)
        {
        	int delayRowCount = 0;
        	bool delayCodeFound = false;
        	bool delaySpecificRecordFound = false;
        	NS_OpenTrainsheetDelay_MainMenu(trainSeed_trainToValidateDelayRecord);
        	
        	Trainsrepo.Train_Sheet.Delay.RefreshButton.DoubleClick();

        	delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
        	Ranorex.Report.Info("No of rows found in Dealy tab is:- " +delayRowCount);
        	if(delayRowCount == 0)
        	{
        		Report.Error("Train {" +Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+ "} has no delay record to validate DelaySpecific fields");
        		Report.Screenshot(Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Element);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
        		return;
        	}
        	
        	for (int i = 0; i < delayRowCount; i++)
        	{
        		
        		Trainsrepo.DelayIndex = i.ToString();
        		string codeValue = Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text");
        		
        		if(codeValue.Equals(delayCode) && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCell.Enabled)
        		{
        			delayCodeFound = true;
        			delaySpecificRecordFound = true;
        			GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.MenuCellInfo, Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.SelfInfo);
        			if(trainseed_expTrainInDelaySpecificField != "")
        			{
        				string expTrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainseed_expTrainInDelaySpecificField);
        				Trainsrepo.DelaySpecificFieldsName = "Train ID";
        				string actTrainId = Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.FieldName.GetAttributeValue<string>("Text");
        				if (actTrainId.Contains(expTrainId))
        				{
        					Report.Success("Success","Expected TrainID value as {" +expTrainId+"} and found as {" +actTrainId+"} in Delay Sepecific Field.");
        				}
        				else
        				{
        					delaySpecificRecordFound = false;
        				}
        			}
        			
        			if(expCrewId != "")
        			{
        				string actCrewId = Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewID.GetAttributeValue<string>("Text");
        				if (actCrewId.Contains(expCrewId))
        				{
        					Report.Success("Success","Expected CrewID value as {" +expCrewId+"} and found as {" +actCrewId+"} in Delay Sepecific Field.");
        				}
        				else
        				{
        					delaySpecificRecordFound = false;
        				}
        			}
        			
        			if(expCrewSegments != "")
        			{
        				string actCrewSegments = Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.CrewSegment.GetAttributeValue<string>("Text");
        				if (actCrewSegments.Contains(expCrewSegments))
        				{
        					Report.Success("Success","Expected CrewSegments value as {" +expCrewSegments+"} and found as {" +actCrewSegments+"} in Delay Sepecific Field.");
        				}
        				else
        				{
        					delaySpecificRecordFound = false;
        				}
        			}
        			
        			if(expComments != "")
        			{
        				string actComments = Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.DelaySpecificfieldsRowByFieldName.Comments.GetAttributeValue<string>("Text");
        				if (actComments.Contains(expComments))
        				{
        					Report.Success("Success","Expected Comment value as {" +expComments+"} and found as {" +actComments+"} in Delay Sepecific Field.");
        				}
        				else
        				{
        					delaySpecificRecordFound = false;
        				}
        			}
        			
        			break;
        		}
        	}
        	
        	if(delayCodeFound && delaySpecificRecordFound)
        	{
        		Report.Success("Sucess","All Delay Specific Fields record found as expected for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
        	}
        	else
        	{
        		Report.Failure("Failure","All Delay Specific Fields record not found as expected for train {"+Trainsrepo.Train_Sheet.TrainIDText.GetAttributeValue<string>("Text")+"}.");
        		Report.Screenshot(Trainsrepo.Train_Sheet.Delay.DelaySpecificFieldsPanel.Self);
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        [UserCodeMethod]
        public static void NS_VerifyTrainsheetExistsOrNot(bool expectedFormExist = false)
        {
        	int retries=0;
        	if(!Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
        	{
        		while(!Trainsrepo.Train_Sheet.SelfInfo.Exists(0) && retries<3)
        		{
        			Ranorex.Delay.Milliseconds(300);
        			retries++;
        		}
        	}
        	
        	bool actualFormExists = Trainsrepo.Train_Sheet.SelfInfo.Exists(0);
        	
        	if (actualFormExists && expectedFormExist)
        	{
        		Ranorex.Report.Success("Expected Trainsheet form :{"+expectedFormExist+"} and found actual Trainsheet form :{"+actualFormExists+"}");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Expected Trainsheet form :{"+expectedFormExist+"} and found actual Trainsheet form :{"+actualFormExists+"}");
        	}
        }
        
        /// <summary>
        /// Validate delay invaild time durations feedback
        /// </summary>
        /// <param name="trainSeed">input:trainSeed</param>
        /// <param name="filterFromLocation">input:filterFromLocation</param>
        /// <param name="filterCode">input:filterCode</param>
        /// <param name="filterState">input:filterState</param>
        /// <param name="updateDuration">input:updateDuration</param>
        /// <param name="expectedFeedback">input:expectedFeedback</param>
        /// <param name="filterSource">input:filterSource</param>
        /// <param name="filterduration">input:filterduration</param>
        /// <param name="filterToLocation">input:filterToLocation</param>
        /// <param name="closeForms">input:closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateFeedbackAndEditDelayDurationInvalidTimings(string trainSeed, string filterFromLocation, string filterCode, string filterState, string updateDuration, string expectedFeedback,
                                                                                 string filterSource, string filterduration, string filterToLocation, bool closeForms)
        {
            NS_OpenTrainsheetDelay_MainMenu(trainSeed);
            
            int delayRowCount = Trainsrepo.Train_Sheet.Delay.DelayTable.Self.Rows.Count;
            bool delayRowFound = false;
            
            for (int i = 0; i < delayRowCount; i++)
            {
                Trainsrepo.DelayIndex=i.ToString();
                
                if(Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.State.GetAttributeValue<string>("Text").Contains(filterState)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.FromLocation.GetAttributeValue<string>("Text").Contains(filterFromLocation)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Code.CodeText.GetAttributeValue<string>("Text").Equals(filterCode,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Source.GetAttributeValue<string>("Text").Equals(filterSource,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.GetAttributeValue<string>("Text").Equals(filterduration,StringComparison.OrdinalIgnoreCase)
                   && Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.ToLocation.GetAttributeValue<string>("Text").Contains(filterToLocation))
                {
                    delayRowFound = true;
                    break;
                }
            }
            if (delayRowFound)
            {
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.Click();
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.PressKeys(updateDuration);
                Trainsrepo.Train_Sheet.Delay.DelayTable.DelayRowByIndex.Duration.PressKeys("{TAB}");
                if(expectedFeedback!="")
                {
                    if(!CheckFeedback(Trainsrepo.Train_Sheet.Feedback, expectedFeedback))
                    {
                        Trainsrepo.Train_Sheet.Delay.RefreshButton.Click();
                        Report.Info("Delay tab Reset to previous state.");
                    }
                }
            }
            else {
                Ranorex.Report.Error("Delay Row not found");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Verify activity count in Trip plan
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="expActivityCount">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityCount(string trainSeed, int expActivityCount, bool closeForms)
        {
        	//Open TrainSheet
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
        	
        	int actActivityCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
        	
        	if(expActivityCount == actActivityCount)
        	{
        		Report.Success("Expected Activity count to be{"+expActivityCount+"} and found to be{"+actActivityCount+"}.");
        	}
        	else
        	{
        		Report.Failure("Expected Activity count to be{"+expActivityCount+"} but found to be{"+actActivityCount+"}.");
        		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}

        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }

        /// <summary>
        /// Validate Activity Type Exist or not with Opsta and Pass count in Trip plan
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityWithLocationAndPassCountExists(string trainSeed, string activityType, string opsta, string passCount, bool validateExist, bool closeForms)
        {
        	bool activityFound = false;
        	
        	//Assign the row index value
        	int activityRowIndex = NS_GetActivityRowIndex_Trainsheet(trainSeed, activityType, opsta, passCount);
        	Trainsrepo.TripPlanIndex = activityRowIndex.ToString();
        	
        	activityFound = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.SelfInfo.Exists(0);
        	if(activityFound == validateExist)
        	{
        		Ranorex.Report.Success("ActivityType{"+activityType+"} with Location{"+opsta+"} and PassCount{"+passCount+"} expected to be present{"+validateExist+"} and found to be{"+activityFound+"}.");
        	}
        	else
        	{
        		Ranorex.Report.Failure("ActivityType{"+activityType+"} with Location{"+opsta+"} and PassCount{"+passCount+"} expected to be present{"+validateExist+"} but found to be{"+activityFound+"}.");
        		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}
        }
        
        /// <summary>
        /// Validate one Activity Alternative record for a Acitivity type in Trip Plan details
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        /// <param name="activityAlternativesCount">Input: Activity Alternative row count (ex: 1/2)</param>
        /// <param name="activityAlternativeText">Input: Alternative Text (ex: Automatic, User Deifined, To, From)</param>
        /// <param name="milepost">Input: Milepost (ex: 230.67A, 148.94H)</param>
        /// <param name="track">Input: Track (ex: MAIN 1, MAIN 2, RECEIVING QUEUE)</param>
        /// <param name="district">Input: District (ex: Atlanta North, Atlanta South)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityAlternativeDetails(string trainSeed, string activityType, string opsta, string passCount, int activityAlternativesCount, string activityAlternativeText, string milepost, string track, string district, bool validateExist, bool closeForms = true)
        {
        	
        	//Open TrainSheet
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
        	
        	int activity = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
        	Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", activity.ToString()));
        	
        	bool activityAlternativeFound = false;
        	
        	//Assign the row index value
        	int activityRowIndex = NS_GetActivityRowIndex_Trainsheet(trainSeed, activityType, opsta, passCount);
        	Trainsrepo.TripPlanIndex = activityRowIndex.ToString();
        	
        	if(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.SelfInfo.Exists(0))
        	{
        		Report.Error(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' did not found for the TRAIN- '{3}'", activityType, opsta, passCount, PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)));
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		return;
        	}
        	
        	Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
        	GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationTextInfo,
        	                                              Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.SelfInfo);
        	
        	int actActivityLocationCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.Self.GetAttributeValue<int>("LastVisibleIndex");
        	
        	if(actActivityLocationCount == activityAlternativesCount)
        	{
        		Report.Success("Expected Activity Location count to be{"+activityAlternativesCount+"} and found{" +actActivityLocationCount+ "}.");
        	}
        	else
        	{
        		Report.Failure("Expected Activity Location count to be{"+activityAlternativesCount+"} but found{" +actActivityLocationCount+ "}.");
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
        		return;
        	}
        	
        	for(int j = 0; j <= actActivityLocationCount; j++)
        	{
        		activityAlternativeFound = true;
        		Trainsrepo.ActivityLocationIndex = j.ToString();
        		
        		string act_ActivityAlternativeText = "";
        		string act_Milepost = "";
        		string act_Track = "";
        		string act_District = "";
        		
        		act_ActivityAlternativeText = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("Text");
        		
        		switch (activityAlternativeText.ToLower())
        		{
        			case "automatic":
        			case "user defined":
        				break;
        			case "to":
        				act_Milepost = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("ToLocationAlternative._milepost");
        				act_Track = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("ToLocationAlternative._track");
        				act_District = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("ToLocationAlternative._district");
        				break;
        			case "from":
        				act_Milepost = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("FromLocationAlternative._milepost");
        				act_Track = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("FromLocationAlternative._track");
        				act_District = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.ActivityLocation.ActivityLocationList.ActivityLocationListItemByIndex.GetAttributeValue<string>("FromLocationAlternative._district");
        				break;
        			default:
        				Report.Error("Activity Alternative type is not valid");
        				break;
        		}
        		
        		if(!(activityAlternativeText.ToLower().Equals("to") || activityAlternativeText.ToLower().Equals("from")) || !(act_ActivityAlternativeText.Contains("LocationAlternativePair")))
        		{
        			if(activityAlternativeText != "")
        			{
        				if (!(act_ActivityAlternativeText.Contains(activityAlternativeText)))
        				{
        					Report.Info("Activity Alternative Text = "+act_ActivityAlternativeText);
        					activityAlternativeFound = false;
        					continue;
        				}
        			}
        		}
        		else
        		{
        			if(milepost != "")
        			{
        				if (!act_Milepost.Equals(milepost, StringComparison.OrdinalIgnoreCase))
        				{
        					Report.Info("Milepost = "+act_Milepost);
        					activityAlternativeFound = false;
        					continue;
        				}
        			}
        			
        			if(track != "")
        			{
        				if (!act_Track.Equals(track, StringComparison.OrdinalIgnoreCase))
        				{
        					Report.Info("Track = "+act_Track);
        					activityAlternativeFound = false;
        					continue;
        				}
        			}
        			
        			if(district != "")
        			{
        				if (!act_District.Equals(district, StringComparison.OrdinalIgnoreCase))
        				{
        					Report.Info("District = "+act_District);
        					activityAlternativeFound = false;
        					continue;
        				}
        			}
        		}
        		
        		break;
        	}
        	
        	
        	if(activityAlternativeFound == validateExist)
        	{
        		Report.Success(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' found with Alternative Details as TEXT- '{3}', MILEPOST- '{4}', TRACK- '{5}' and DISTRICT- '{6}' expected to be found '{7}' and found '{8}'",
        		                             activityType, opsta, passCount, activityAlternativeText, milepost, track, district, validateExist, activityAlternativeFound));
        	}
        	else
        	{
        		Report.Failure(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' found with Alternative Details as TEXT- '{3}', MILEPOST- '{4}', TRACK- '{5}' and DISTRICT- '{6}' expected to be found '{7}' and found '{8}'",
        		                             activityType, opsta, passCount, activityAlternativeText, milepost, track, district, validateExist, activityAlternativeFound));
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Validate all Activity Alternative records for a Acitivity type in Trip Plan details
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        /// <param name="activityAlternativesCount">Input: Activity Alternative row count (ex: 1/2)</param>
        /// <param name="activityAlternativesRecord">Input: Alternative Record (ex: Automatic||||User Defined||||To|148.94H|RECEIVING QUEUE|Atlanta South|From|148.94H|RECEIVING QUEUE|Atlanta South)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityAllAlternativeDetails(string trainSeed, string activityType, string opsta, string passCount, int activityAlternativesCount, string activityAlternativesRecord, bool validateExist, bool closeForms = true)
        {
        	string activityAlternativeText = "";
        	string milepost = "";
        	string track = "";
        	string district = "";
        	
        	if (activityAlternativesRecord.Contains("|")) 
        	{
        		string[] activityAlternativeRecord = activityAlternativesRecord.Split('|');
        		int elementCount = 4;
        		
        		for (int i = 0; i < activityAlternativeRecord.Length; i+=elementCount)
        		{
        			activityAlternativeText = activityAlternativeRecord[i];
        			milepost = activityAlternativeRecord[i+1];
        			track = activityAlternativeRecord[i+2];
        			district = activityAlternativeRecord[i+3];
        			
        			NS_ValidateTripPlanActivityAlternativeDetails(trainSeed, activityType, opsta, passCount, activityAlternativesCount, activityAlternativeText, milepost, track, district, validateExist, closeForms);
        		}
        	}
        	else
        	{
        		Report.Error("Activity Alternative Record needs to be passed in a pipe delimited string");
        	}
        }
		 [UserCodeMethod]
        public static void NS_ValidateOptionsEnable_Trainsheet(string menuOption,bool isEnable)
        {
        	if(Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
        	{
        		int retries=0;
        		switch (menuOption.ToLower())
        		{
        			case "tripplan":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.TripPlanTab.Selected)
        				{
        					Report.Success("Trip Plan Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Trip Plan Tab is Enabled="+isEnable.ToString());
        				}        				
        				break;
        			case "enginetab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.EngineTab.Selected)
        				{
        					Report.Success("Engine Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Engine Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "crewtab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.CrewTab.Selected)
        				{
        					Report.Success("Crew Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Crew Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "railcartab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Selected)
        				{
        					Report.Success("Railcar Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Railcar Tab is Enabled="+isEnable.ToString());
        				}
        				if(Trainsrepo.Train_Sheet.TrainSheetTabs.RailcarTab.Selected)
        				{
        					if(isEnable)
        					{
        						GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Sheet.Railcar.RailcarTextInfo,true);
        					}
        					else
        					{
        						GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Sheet.Railcar.RailcarTextInfo,false);
        					}
        				}
        				break;
        			case "traintab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.TrainTab.Selected)
        				{
        					Report.Success("Train Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Train Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "delaytab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.DelayTab.Selected)
        				{
        					Report.Success("Delay Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Delay Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "historytab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.HistoryTab.Selected)
        				{
        					Report.Success("History Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("History Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "eotcaboosetab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.EOTCabooseTab.Selected)
        				{
        					Report.Success("EOTCaboose Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("EOTCaboose Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "movementtab":
        				Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Click();
        				while(!Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Selected && retries<3)
        				{
        					Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Click();
        					retries++;
        				}
        				if(isEnable==Trainsrepo.Train_Sheet.TrainSheetTabs.MovementTab.Selected)
        				{
        					Report.Success("Movement Tab is Enabled="+isEnable.ToString());
        				}
        				else
        				{
        					Report.Failure("Movement Tab is Enabled="+isEnable.ToString());
        				}
        				break;
        			case "terminate":
        				if(isEnable)
        				{
        					GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Sheet.TerminateButtonInfo,true);
        				}
        				else
        				{
        					GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Sheet.TerminateButtonInfo,false);
        				}
        				break;
        			case "trainmanual":
        				if(isEnable)
        				{
        					GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByIndex.CellByIndexInfo,
        					                                               Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.ManualInfo);
        					GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.ManualInfo,true);
        				}
        				else
        				{
        					GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryRowByIndex.CellByIndexInfo,
        					                                               Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.ManualInfo);
        					GeneralUtilities.CheckFieldEnableDisable(Trainsrepo.Train_Status_Summary.TrainStatusSummaryTable.TrainStatusSummaryMenu.ManualInfo,false);
        				}
        				break;
        			default:
        				Ranorex.Report.Failure("Invalid option");
        				break;
        		}
        	}
        	else
        	{
        		Ranorex.Report.Failure("Trainsheet does not exist");
        	}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="filterOpsta"></param>
        /// <param name="filterMilePost"></param>
        /// <param name="filterDirection"></param>
        /// <param name="apply"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void DeleteMovementInfoRecords_TrainSheet(string trainSeed, string filterOpsta, string filterMilePost, string filterDirection, bool apply, bool closeForms)
        {
            bool recordFound = true;
            int movementCount = 0;
            
            NS_OpenTrainsheetMovement_MainMenu(trainSeed);
            
            if(Trainsrepo.Train_Sheet.Movement.SelfInfo.Exists(0))
            {
                movementCount = Trainsrepo.Train_Sheet.Movement.MovementTable.Self.Rows.Count;
                
                if(movementCount > 0)
                {
                    string movementOpsta = "";
                    string movementMilePost = "";
                    string movementDirection = "";
                    for(int i=0; i<movementCount;i++)
                    {
                        recordFound = true;
                        Trainsrepo.MovementIndex = i.ToString();
                        
                        movementOpsta = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.OpSta.GetAttributeValue<string>("Text");
                        movementMilePost = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Milepost.GetAttributeValue<string>("Text");
                        movementDirection = Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.Direction.GetAttributeValue<string>("Text");
                        
                        if(!movementOpsta.Equals(filterOpsta,StringComparison.OrdinalIgnoreCase))
                        {
                            recordFound = false;
                            continue;
                        }
                                                
                        if(!string.IsNullOrEmpty(filterMilePost))
                        {
                            if(!movementMilePost.Contains(filterMilePost))
                            {
                                recordFound = false;
                                continue;
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(filterDirection))
                        {
                            if(!movementDirection.Equals(filterDirection,StringComparison.OrdinalIgnoreCase))
                            {
                                recordFound = false;
                                continue;
                            }
                        }                                                
                        break;
                    }
                }
                else
                {
                	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Movement.Self);
                	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                	                                                  Trainsrepo.Train_Sheet.SelfInfo);
                	Ranorex.Report.Info("There are no movement records or it took more time to load");
                	return;
                }
                
                if(recordFound)
                {
                    Ranorex.Report.Success("Movement details present? "+recordFound.ToString());
                	GeneralUtilities.RightClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.Movement.MovementTable.MovementRowByIndex.MenuCellInfo,Trainsrepo.Train_Sheet.Movement.MenuCellMenu.SelfInfo);
                	GeneralUtilities.MiddleClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.Movement.MenuCellMenu.DeleteRowInfo,Trainsrepo.Train_Sheet.Movement.MenuCellMenu.SelfInfo);
                	GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.Movement.ApplyButtonInfo,Trainsrepo.Train_Sheet.Movement.ApplyButtonInfo, MouseButtons.Left);
                    Ranorex.Report.Info("Movement details modified");
                }
                else
                {
                	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
                	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                	                                                  Trainsrepo.Train_Sheet.SelfInfo);
                	Ranorex.Report.Failure("Movement Details did not match the search criteria");
                	return;
                }
            }
            else
            {
            	Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.Self);
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
            	                                                  Trainsrepo.Train_Sheet.SelfInfo);
            	Ranorex.Report.Failure("Unable to open Movement tab for the trainsheet");
            	return;
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
                                                                  Trainsrepo.Train_Sheet.SelfInfo);
            }
        }
        
        /// <summary>
        /// Get the row index in the Trip Plan tabel based on Activity Type, opsta and passcount
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        public static int NS_GetActivityRowIndex_Trainsheet(string trainSeed, string activityType, string opsta, string passCount)
        {
        	string act_activityType = "";
        	string act_currentLocation = "";
        	string act_currentPassCount = "";
        	int activityRowIndex = 0;
        	bool activityRowFound = false;
        	
        	//Open TrainSheet
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);

        	int rowCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
        	Ranorex.Report.Info(String.Format("Found {0} Row in the Trip Plan.", rowCount.ToString()));
        	
        	for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        	{
        		Trainsrepo.TripPlanIndex = rowIndex.ToString();
        		
        		if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0) &&
        		   Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.LocationInfo.Exists(0) &&
        		   Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.PassCountInfo.Exists(0))
        		{
        			act_activityType = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
        			act_currentLocation = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Location.GetAttributeValue<string>("StationId");
        			act_currentPassCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.PassCount.GetAttributeValue<string>("Text");
        			
        			if(act_activityType.Equals(activityType, StringComparison.OrdinalIgnoreCase) && act_currentLocation.Equals(opsta, StringComparison.OrdinalIgnoreCase) &&
        			                                                                     act_currentPassCount.Equals(passCount, StringComparison.OrdinalIgnoreCase))
        			{
        				activityRowFound = true;
        				activityRowIndex = rowIndex;
        				Report.Info(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' found at RowIndex- '{3}'", activityType, opsta, passCount, rowIndex));
        				break;
        			}
        			else
        			{
        				continue;
        			}
        		}
        		else
        		{
        			Report.Info("Activity details are not present for the row number{" +rowIndex+ "} so moving to next row.");
        		}
        	}
        	
        	if(!activityRowFound)
        	{
        		activityRowIndex = -1;
        	}
        	
        	return activityRowIndex;
        }
        
        /// <summary>
        /// Validate Linkage details for a Acitivity type in Trip Plan details
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        /// <param name="linkageType">Input: linkageType</param>
        /// <param name="linkageTrainID">Input: linkageTrainID</param>
        /// <param name="linkagePassCount">Input: linkagePassCount</param>
        /// <param name="linkageMinimumConnect">Input: linkageMinimumConnect(in SECONDS)</param>
        /// <param name="linkageUnlinkTrainsSelected">Input: linkageUnlinkTrainsSelected (ex: TRUE or FALSE)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanLinkageDetails_Trainsheet(string trainSeed, string activityType, string opsta, string passCount, string linkageType, string linkageTrainSeed, string linkagePassCount, string linkageMinimumConnect, bool linkageUnlinkTrainsSelected, bool validateExist, bool closeForms = true)
        {
        	bool linkageDetailsFound = false;
        	string act_linkageType = "";
        	string act_linkageTrainID = "";
        	string act_inkagePassCount = "";
        	string act_linkageMinimumConnect = "";
        	bool act_linkageUnlinkTrainsSelected = false;
        	string linkageTrainID = "";

        	//Assign the row index value
        	int activityRowIndex = NS_GetActivityRowIndex_Trainsheet(trainSeed, activityType, opsta, passCount);
			Trainsrepo.TripPlanIndex = activityRowIndex.ToString();
			
			if(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.SelfInfo.Exists(0))
        	{
        		Report.Error(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' did not found for the TRAIN- '{3}'", activityType, opsta, passCount, PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)));
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		return;
        	}

        	if(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageTypeInfo.Exists(0) &&
        	   Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageTrainIDInfo.Exists(0) &&
        	   Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkagePassCountInfo.Exists(0) &&
        	   Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageMinimumConnectInfo.Exists(0) &&
        	   Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckboxInfo.Exists(0))
        	{
        		linkageDetailsFound = true;
        		Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCell.Click();
        		act_linkageType = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageType.GetAttributeValue<string>("Text");
        		act_linkageTrainID = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageTrainID.GetAttributeValue<string>("Text");
        		act_inkagePassCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkagePassCount.GetAttributeValue<string>("Text");
        		act_linkageMinimumConnect = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageMinimumConnect.GetAttributeValue<string>("Text");
        		act_linkageUnlinkTrainsSelected = Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckbox.GetAttributeValue<bool>("Selected");
        		
        		if(linkageType != "")
        		{
        			if (!act_linkageType.Equals(linkageType, StringComparison.OrdinalIgnoreCase))
        			{
        				Report.Info("Linakge Type:- "+act_linkageType);
        				linkageDetailsFound = false;
        			}
        		}
        		
        		if(linkageTrainSeed != "")
        		{
        			linkageTrainID = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(linkageTrainSeed);
        			if (!act_linkageTrainID.Equals(linkageTrainID, StringComparison.OrdinalIgnoreCase))
        			{
        				Report.Info("Linakge Train ID:-"+act_linkageTrainID);
        				linkageDetailsFound = false;
        			}
        		}
        		
        		if(linkagePassCount != "")
        		{
        			if (!act_inkagePassCount.Equals(linkagePassCount, StringComparison.OrdinalIgnoreCase))
        			{
        				Report.Info("Linkage Pass Count:- "+act_inkagePassCount);
        				linkageDetailsFound = false;
        			}
        		}
        		
        		if(linkageMinimumConnect != "")
        		{
        			if (!act_linkageMinimumConnect.Equals(linkageMinimumConnect, StringComparison.OrdinalIgnoreCase))
        			{
        				Report.Info("Linkage Minimum Connect in seconds:- "+act_linkageMinimumConnect);
        				linkageDetailsFound = false;
        			}
        		}
        		
        		
        		if (!act_linkageUnlinkTrainsSelected == linkageUnlinkTrainsSelected)
        		{
        			Report.Info("Linkage Unlink Trains Checkbox selected:- "+act_linkageUnlinkTrainsSelected);
        			linkageDetailsFound = false;
        		}
        		
        	}
        	else
        	{
        		Report.Failure("Linkage fields are not present to fetch the details and validate for the Activity Type: " +activityType);
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		return;
        	}
        	
        	if(linkageDetailsFound == validateExist)
        	{
        		Report.Success(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' found with Linkage Details as LINKAGETYPE- '{3}', LINKAGETRAINID- '{4}', LINKAGEPASSCOUNT- '{5}', LINKAGEMINIMUMCONNECT- '{6}', LINKAGEUNLINKTRAINSCHECKBOX- '{7}' expected to be found '{8}' and found '{9}'",
        		                             activityType, opsta, passCount, linkageType, linkageTrainID, linkagePassCount, linkageMinimumConnect, linkageUnlinkTrainsSelected, validateExist, linkageDetailsFound));
        	}
        	else
        	{
        		Report.Failure(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' found with Linkage Details as LINKAGETYPE- '{3}', LINKAGETRAINID- '{4}', LINKAGEPASSCOUNT- '{5}', LINKAGEMINIMUMCONNECT- '{6}', LINKAGEUNLINKTRAINSCHECKBOX- '{7}' expected to be found '{8}' but found '{9}'",
        		                             activityType, opsta, passCount, linkageType, linkageTrainID, linkagePassCount, linkageMinimumConnect, linkageUnlinkTrainsSelected, validateExist, linkageDetailsFound));
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Validate Planning Status Icon Trip Plan details
        /// </summary>
        /// <param name="trainSeed">Input: trainseed</param>
        /// <param name="expPlanningStatus">Input: expPlanningStatus</param>
        /// <param name="closeForms">Input: closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidatePlanningStatusIcon_TrainSheet(string trainSeed, string expPlanningStatus, bool closeForms)
        {
        	
        	//Open TrainSheet
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed);
        	
        	string act_PlanningStatus = Trainsrepo.Train_Sheet.PlanningStatusIcon.GetAttributeValue<string>("ToolTipText");
        	
        	if(act_PlanningStatus.Equals(expPlanningStatus, StringComparison.OrdinalIgnoreCase))
        	{
        		Report.Success("Planning Status expected to be{"+expPlanningStatus+"} and found to be{"+act_PlanningStatus+"}.");
        	}
        	else
        	{
        		Report.Failure("Planning Status expected to be{"+expPlanningStatus+"} but found to be{"+act_PlanningStatus+"}.");
        		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}

        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Verify any exception message on Train in the Train Sheet
        /// </summary>
        /// <param name="trainSeed_toValidate">Input: Pass the trainseed of Train, user wants to validate</param>
        /// <param name="trainSeed_inException">Input: Pass the trainSeed of Train which user expects in Exception message</param>
        /// <param name="expExceptionMsg">Input: expExceptionMsg(e.g. 'Combo End activity for A202 is already completed but Separate Combo activity is still pending' if this 
        ///                               is the message then pass it as 'Combo End activity for TrainId is already completed but Separate Combo activity is still pending')</param>
        /// <param name="validateExist">Input: validateExist</param>
        /// <param name="closeForms">Input: closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateExceptionOnTrain_Trainsheet(string trainSeed_toValidate, string trainSeed_inException, string expExceptionMsg, bool validateExist, bool closeForms)
        {
        	string trainId = "";
        	string exp_ExceptionMsg = "";
        	
        	if(trainSeed_inException != null)
        	{
        		trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed_inException);
        		if (trainId == null)
        		{
        			Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed_inException+"}, ensure correct trainSeed and that train was made");
        			return;
        		}
        	}
        	
        	//Open TrainSheet
        	NS_OpenTrainsheetTripPlan_MainMenu(trainSeed_toValidate);
        	
        	if(expExceptionMsg.Contains("TrainId"))
        	{
        		exp_ExceptionMsg = expExceptionMsg.Replace("TrainId", trainId);
        	}
        	else
        	{
        		exp_ExceptionMsg = expExceptionMsg;
        	}
        	
        	int tripPlanRowCount = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.Self.Rows.Count;
        	Ranorex.Report.Info(String.Format("Found {0} Activity in the Trip Plan.", tripPlanRowCount.ToString()));
        	
        	bool resultFound = false;
        	for (int i=0; i <tripPlanRowCount; i++)
        	{
        		Trainsrepo.TripPlanIndex = i.ToString();
        		
        		if(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.ActivityInfo.Exists(0))
        		{
        			string act_ExceptionMsg = Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.Activity.GetAttributeValue<string>("Text");
        			if(act_ExceptionMsg.Equals(exp_ExceptionMsg, StringComparison.OrdinalIgnoreCase))
        			{
        				Report.Info("Actual Exception Message:- " +act_ExceptionMsg);
        				resultFound = true;
        				break;
        			}
        		}
        	}
        	
        	if(resultFound == validateExist)
        	{
        		Ranorex.Report.Success("Exception Message {"+exp_ExceptionMsg+"} should exist {" +validateExist+ "}, and actually it is present {" +resultFound+ "}.");
        	}
        	else
        	{
        		Ranorex.Report.Failure("Exception Message {"+exp_ExceptionMsg+"} should exist {" +validateExist+ "}, but actually it is present {" +resultFound+ "}.");
        		Ranorex.Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        	}
        	
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// validate PTCCrewLogoff Message_TrainHistory
        /// </summary>
        /// <param name="trainSeed">Input: trainseed</param>
        /// <param name="optDistrict">Input: optDistrict</param>
        /// <param name="signoffType">Input: signoffType</param>
        /// <param name="closeForms">Input: closeForms</param>
        [UserCodeMethod]
        public static void NS_Validate_PTCCrewLogoffMessage_TrainHistory(string trainSeed, string optDistrict, string signoffType, bool closeForm)
        {
        	Trainsrepo.Train_Sheet.History.RefreshButton.DoubleClick();
        	string crewLogoffMessage = "PTC crew logoff by "+signoffType+"";

        	Ranorex.Report.Info(crewLogoffMessage);
        	NS_ValidateTrainSheetHistory(trainSeed, crewLogoffMessage, "", "", "", optDistrict);

        	if (closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
        		                                                  Trainsrepo.Train_Sheet.SelfInfo);
        	}
        }
        
        /// <summary>
        /// Unlink any Activity for a Train
        /// </summary>
        /// <param name="trainSeed">Input: trainseed (ex:NST001)</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Location (ex: 230A)</param>
        /// <param name="passCount">Input: Pass count (ex: 1/2)</param>
        /// <param name="unlinkTrain">Input: unlinkTrain</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_UnlinkActivityForTrain_Trainsheet(string trainSeed, string activityType, string opsta, string passCount, bool unlinkTrain, bool closeForms = true)
        {
        	
        	//Assign the row index value
        	int activityRowIndex = NS_GetActivityRowIndex_Trainsheet(trainSeed, activityType, opsta, passCount);
        	Trainsrepo.TripPlanIndex = activityRowIndex.ToString();
        	
        	if(!Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.SelfInfo.Exists(0))
        	{
        		Report.Error(String.Format("ACTIVITYTYPE- '{0}' with OPSTA- '{1}' and PASSCOUNT- '{2}' did not found for the TRAIN- '{3}'", activityType, opsta, passCount, PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)));
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		return;
        	}
			
        	GeneralUtilities.ClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanTable.TripPlanRowByIndex.MenuCellInfo,
        	                                         Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckboxInfo);
        	
        	if(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckboxInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForAttributeEqualWithRetry(Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckboxInfo,
        		                                                        Trainsrepo.Train_Sheet.TripPlan.TripPlanDetailsPanel.LinkageUnlinkTrainsCheckbox, "Selected", unlinkTrain.ToString(), System.Windows.Forms.MouseButtons.Left);

        	}
        	else
        	{
        		Report.Failure("UnlinkTrainsCheckbox is not present to unlink the train for the Activity Type: " +activityType);
        		Report.Screenshot(Trainsrepo.Train_Sheet.TripPlan.Self.Element);
        		return;
        	}
        	
        	GeneralUtilities.ClickAndWaitForDisabledWithRetry(Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo, Trainsrepo.Train_Sheet.TripPlan.ApplyButtonInfo);
        	
        	if(closeForms)
        	{
        		NS_CloseTrainsheet();
        	}
        }
        
        /// <summary>
        /// validate Entry for a Train in Train History with and without TrainId in history text
        /// </summary>
        /// <param name="trainSeed_toValidateHistory">Input: trainSeed_toValidateHistory</param>
        /// <param name="expHistoryText">Input: expHistoryText</param>
        /// <param name="trainSeed_inHistoryText">Input: trainSeed_inHistoryText</param>
        /// <param name="optDistrict">Input: optDistrict</param>
        /// <param name="closeForms">Input: closeForms</param>
        [UserCodeMethod]
        public static void NS_ValidateEntryForTrain_TrainHistory(string trainSeed_toValidateHistory, string expHistoryText, string trainSeed_inHistoryText, string optDistrict, bool closeForm)
        {
        	string expFinalHistoryText = "";
        	string trainId_inHistoryText = "";
        	
        	if(trainSeed_inHistoryText != null)
        	{
        		trainId_inHistoryText = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed_inHistoryText);
        		if(trainId_inHistoryText == null)
        		{
        			Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed_inHistoryText+"}, ensure correct trainSeed and that train was made");
        			return;
        		}
        	}
        	
        	if(expHistoryText.Contains("TrainId"))
        	{
        		expFinalHistoryText = expHistoryText.Replace("TrainId", trainId_inHistoryText);
        	}
        	else
        	{
        		expFinalHistoryText = expHistoryText;
        	}
        	
        	Ranorex.Report.Info("Expected History Text:-"+expFinalHistoryText);
        	NS_ValidateTrainSheetHistory(trainSeed: trainSeed_toValidateHistory, TrainHistoryType: expFinalHistoryText, optionalDate: "", optionalTime: "", optionalDivision: "", optionalDistrict: optDistrict);

        	if (closeForm)
        	{
        		NS_CloseTrainsheet();
        	}
        }
    }
}