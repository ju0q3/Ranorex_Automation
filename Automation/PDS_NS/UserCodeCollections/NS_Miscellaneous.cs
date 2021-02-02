/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/21/2018
 * Time: 9:31 AM
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

using Oracle.Code_Utils;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Miscellaneous
    {
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        public static global::PDS_NS.TrackAuthorities_Repo TrackAuthorityrepo = global::PDS_NS.TrackAuthorities_Repo.Instance;
        public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
        public static global::PDS_NS.SystemConfiguration_Repo SystemConfigurationrepo = global::PDS_NS.SystemConfiguration_Repo.Instance;
        public static global::PDS_NS.Bulletins_Repo Bulletinsrepo = global::PDS_NS.Bulletins_Repo.Instance;
        public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static global::PDS_NS.TerritoryTransfer_Repo TerritoryTransferrepo = global::PDS_NS.TerritoryTransfer_Repo.Instance;

        private enum AlertQueueSummaryHeaders
        {
            Level = 0,
            ID = 1,
            Generated = 2,
            AlertName = 3,
            Type = 4
        }

        /// <summary>
        /// Opens the Task List Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTaskListForm_MainMenu()
        {
            int retries = 0;

            //Open Task List Form if it's not already open
            if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            {
                //Click Miscellaneous menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton.Click();
                //Click Task List in Miscellaneous menu
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.TaskListInfo,
                                                          Miscellaneousrepo.Task_List.Tasks.TasksTable.SelfInfo);

                //Ensure Task List Tab is selected
                if (!Miscellaneousrepo.Task_List.TaskListTabs.TasksTab.Selected)
                {
                    Miscellaneousrepo.Task_List.TaskListTabs.TasksTab.Click();
                }

                //Wait for Bulletin Input Form to exist in case of lag
                if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Task List form did not open");
                        return;
                    }
                }
            }
            if (!Miscellaneousrepo.Task_List.TaskListTabs.TasksTab.Selected)
            {
                Miscellaneousrepo.Task_List.TaskListTabs.TasksTab.Click();
            }

            //After it exists, wait for values to start propogating
            retries = 0;
            int taskRows = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
            bool finished = false;
            while (!finished && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                //As long as the count changes within the half second, we will continue waiting in the loop

                if (Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count == 0)
                {
                    retries++;
                    continue;
                }

                if (Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count != taskRows)
                {
                    taskRows = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
                    continue;
                }

                finished = true;
            }

            if (taskRows == 0)
            {
                Ranorex.Report.Info("No Tasks found in Task List Form");
            }

            return;
        }

        public static void NS_OpenAudibleAlertCheckout()
        {
            if (Miscellaneousrepo.Audible_Alert_Checkout.NoSoundButtonInfo.Exists(0))
            {
                return;
            }

            GeneralUtilities.ClickAndWaitForWithRetry(
                MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.SelfInfo
               );

            GeneralUtilities.ClickAndWaitForWithRetry(
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.TestAudibleAlertInfo,
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.SelfInfo
               );

            int retries = 0;
            while (!Miscellaneousrepo.Audible_Alert_Checkout.NoSoundButtonInfo.Exists(0) && retries < 3)
            {
                Delay.Milliseconds(250);
                retries++;
            }

            if (!Miscellaneousrepo.Audible_Alert_Checkout.NoSoundButtonInfo.Exists(0))
            {
                Report.Screenshot();
                Report.Error("Unable to open Audible Alert Checkout.");
                return;
            } else {
                Report.Success("Audible Alert Checkout Opened Successfully");
            }
        }

        /// <summary>
        /// Opens the Limit Suggestions Form if not already open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenLimitSuggestionsForm_MainMenu()
        {
            int retries = 0;

            //Open Task List Form if it's not already open
            if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            {
                //Click Miscellaneous menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton.Click();
                //Click Task List in Miscellaneous menu
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.TaskList.Click();

                //Ensure Limit Suggestions Tab is selected
                if (!Miscellaneousrepo.Task_List.TaskListTabs.LimitSuggestionsTab.Selected)
                {
                    Miscellaneousrepo.Task_List.TaskListTabs.LimitSuggestionsTab.Click();
                }

                //Wait for Bulletin Input Form to exist in case of lag
                if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Task List form did not open");
                        return;
                    }
                }
            }
            if (!Miscellaneousrepo.Task_List.TaskListTabs.LimitSuggestionsTab.Selected)
            {
                Miscellaneousrepo.Task_List.TaskListTabs.LimitSuggestionsTab.Click();
            }
            //After it exists, wait for values to start propogating
            retries = 0;
            int limitSuggestionRows = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Rows.Count;
            bool finished = false;
            while (!finished && retries < 2)
            {
                Ranorex.Delay.Milliseconds(500);
                //As long as the count changes within the half second, we will continue waiting in the loop

                if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Rows.Count == 0)
                {
                    retries++;
                    continue;
                }

                if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Rows.Count != limitSuggestionRows)
                {
                    limitSuggestionRows = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Rows.Count;
                    continue;
                }

                finished = true;
            }

            if (limitSuggestionRows == 0)
            {
                Ranorex.Report.Info("No Limit Suggestions found in Task List Form");
            }

            return;
        }

        /// <summary>
        /// Given a pipe-delimited crew member record, this method explicitly adds an employee Id to the pipe-delimited string.
        /// By design, it will only succeed if the crew member already exists in PDS/Oracle.
        /// This method may also represent a temporary solution, allowing for an employee to be transferred to another train without NS object refactoring
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="crewMemberRecord"></param>
        /// <returns></returns>
        [UserCodeMethod]
        public static string NS_AddEmployeeId_CrewRecord(string srcCrewSeed, string crewMemberRecord)
        {
            string[] crewRecordElements = crewMemberRecord.Split('|');

            string outCrewRecord = null;
            string empId = NS_CrewClass.GetCrewMemberEmployeeId(srcCrewSeed);
            if (empId != null)
            {
                crewRecordElements[14] = empId;
                outCrewRecord = String.Join("|", crewRecordElements);
            }
            return outCrewRecord;
        }


        /// <summary>
        /// Verifies *Any* limit suggestion exists
        /// </summary>
        /// <param name="district">Input:district</param>
        [UserCodeMethod]
        public static void NS_VerifyLimitSuggestionPresent(bool suggestionPresent, bool closeForms)
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            int rows = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Rows.Count;
            if (rows > 0 && suggestionPresent)
            {
                Ranorex.Report.Success(rows + " Limit Suggestion(s) present.");
            }
            else if (rows > 0 && !suggestionPresent)
            {
                Ranorex.Report.Failure("Limit Suggestion(s) present.");
            }
            else if (!suggestionPresent)
            {
                Ranorex.Report.Success("No Limit Suggestion(s) present.");
            }
            else
            {
                Ranorex.Report.Failure("No Limit Suggestion(s) present.");
            }
            if (closeForms)
            {
                PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
            }
        }

        /// <summary>
        /// Used as a catch all cleanup for tests that may leave behind suggestions for any train
        /// </summary>
        /// <param name="replacementRWFromLimit">Seed of train that may leave behind a suggestion</param>
        /// <param name="replacementRWToLimit">New RW To limit for replacement authority</param>
        /// <param name="replacementRWTrack">New RW Track value for repalcement authority</param>
        [UserCodeMethod]
        public static void IssueAndVoidALLPotentialTACSuggestions(string replacementRWFromLimit, string replacementRWToLimit, string replacementRWTrack)
        {
            Miscellaneousrepo.LimitSuggestionsIndex = "0";
            string authSeed = "";
            int authSeedIterator = 0;
            while (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByIndex.SelfInfo.Exists(0))
            {
                authSeed = System.DateTime.Now.ToString() + authSeedIterator.ToString();
                authSeedIterator++;
                NS_OpenFirstLimitSuggestion();
                TEtoSimpleRW(replacementRWFromLimit, replacementRWToLimit, replacementRWTrack, "500p");
                NS_Authorities.AddAuthorityObjectFromOpenAuthority(authSeed);
                GeneralUtilities.ClickAndWaitForWithRetry(TrackAuthorityrepo.Create_Track_Authority.IssueButtonInfo, TrackAuthorityrepo.Communications_Exchange_Ok_Authority.SelfInfo);
                NS_Authorities.CompleteAuthorityIssue(authSeed, "Automation", "", "", true);
                TrackAuthorityrepo.Communications_Exchange_Ok_Authority.SelfInfo.WaitForNotExists(5000);
                NS_Authorities.NS_VoidAuthorityFunction(authSeed, "", true, false, true, true);
                Ranorex.Delay.Seconds(2);
            }
        }

        /// <summary>
        /// Used as a targeted cleanup for tests that may leave behind suggestions for a particular train
        /// </summary>
        /// <param name="trainSeed">Seed of train that may leave behind a suggestion</param>
        /// <param name="replacementRWFromLimit">New RW From limit for replacement authority</param>
        /// <param name="replacementRWToLimit">New RW To limit for replacement authority</param>
        /// <param name="replacementRWTrack">New RW Track value for repalcement authority</param>
        [UserCodeMethod]
        public static void IssueAndVoidPotentialTACSuggestion (string trainSeed, string replacementRWFromLimit, string replacementRWToLimit, string replacementRWTrack)
        {
            string authSeed = System.DateTime.Now.ToString();
            Miscellaneousrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            bool result = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists();
            if (!result)
            {
                Ranorex.Report.Info("No cleanup performed for {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}. Suggestion does not exist.");
                return;
            }
            TEtoSimpleRW(replacementRWFromLimit, replacementRWToLimit, replacementRWTrack, "500p");
            GeneralUtilities.ClickAndWaitForWithRetry(TrackAuthorityrepo.Create_Track_Authority.IssueButtonInfo, TrackAuthorityrepo.Communications_Exchange_Ok_Authority.SelfInfo);
            NS_Authorities.CompleteAuthorityIssue(authSeed, "Automation", "", "", false);
            NS_Authorities.NS_VoidAuthorityFunction(authSeed, "", true, false, true, true);
        }

        /// <summary>
        /// Mainly used for changing discarded/leftover suggestions, its easier to make them into RWs especially if thae trains have been completed/removed
        /// </summary>
        /// <param name="fromLimit">New Proceed from limit for the RW authority</param>
        /// <param name="toLimit">New Proceed to limit for the RW authority</param>
        /// <param name="track">New track value for the RW authority</param>
        /// <param name="expirationTime">New expiration time for the new RW authority</param>
        [UserCodeMethod]
        public static void TEtoSimpleRW(string fromLimit, string toLimit, string track, string expirationTime)
        {

            GeneralUtilities.LeftClickAndWaitForWithRetry(TrackAuthorityrepo.Create_Track_Authority.RWRadioInfo, TrackAuthorityrepo.Create_Track_Authority.To.NonEngineToTextInfo);

            TrackAuthorityrepo.Create_Track_Authority.To.NonEngineToText.Click();
            TrackAuthorityrepo.Create_Track_Authority.To.NonEngineToText.Element.SetAttributeValue("text", "Automation");
            TrackAuthorityrepo.Create_Track_Authority.To.NonEngineToText.PressKeys("{Tab}");
            TrackAuthorityrepo.Create_Track_Authority.At.AtText.Click();
            TrackAuthorityrepo.Create_Track_Authority.At.AtText.Element.SetAttributeValue("text", "Nowhere");
            TrackAuthorityrepo.Create_Track_Authority.At.AtText.PressKeys("{Tab}");
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Click();
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenBetween.Element.SetAttributeValue("text", fromLimit);
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenBetween.PressKeys("{Tab}");
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Click();
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenAnd.Element.SetAttributeValue("text", toLimit);
            TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenAnd.PressKeys("{Tab}");
            if (!track.Equals(""))
            {
                TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Click();
                TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.Element.SetAttributeValue("text", track);
                TrackAuthorityrepo.Create_Track_Authority.Box3.WorkBetweenTrack1.PressKeys("{Tab}");
            }
            TrackAuthorityrepo.Create_Track_Authority.Box5.EffectiveUntilText.Click();
            TrackAuthorityrepo.Create_Track_Authority.Box5.EffectiveUntilText.Element.SetAttributeValue("text", expirationTime);
            TrackAuthorityrepo.Create_Track_Authority.Box5.EffectiveUntilText.PressKeys("{Tab}");

        }

        [UserCodeMethod]
        public static bool NS_OpenSuggestionSummaryList (string territory, string trainSeed)
        {
            int retries = 0;

            if (!TrackAuthorityrepo.Limit_Suggestion_Summary_List.SelfInfo.Exists(0))
            {
                while (!TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.SelfInfo.Exists(0) && retries < 2)
                {
                    GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrackAuthoritesButtonInfo, MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.LimitSuggestionSummaryChoiceInfo);
                    MainMenurepo.PDS_Main_Menu.TrackAuthoritiesMenu.LimitSuggestionSummaryChoice.Click();
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                //one last check
                if (!TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.SelfInfo.Exists(0))
                {
                    Report.Failure("Limit Suggestion Summary Choice Menu did not appear.");
                    return false;
                }

                TrackAuthorityrepo.LogicalPosition = territory;
                //Dialog disappears after selecting, no point in retrying loop
                GeneralUtilities.LeftClickAndWaitForWithRetry(TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.LogicalPosition.LogicalDivisionMenuItemInfo, TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionNameInfo);
                TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionName.Click();

                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.OkButtonInfo, TrackAuthorityrepo.Limit_Suggestion_Summary_Choice.SelfInfo);

                retries = 0;

                while (!TrackAuthorityrepo.Limit_Suggestion_Summary_List.SelfInfo.Exists(0) && retries < 2)
                {
                    Delay.Milliseconds(500);
                    retries++;
                }

                if (!TrackAuthorityrepo.Limit_Suggestion_Summary_List.SelfInfo.Exists(0))
                {
                    Report.Failure("Limit Suggestion Summary List did not appear.");
                    return false;
                }

            }

            return true;
        }

        [UserCodeMethod]
        /// <summary>
        /// Used to validate suggestions for the given trainseed are appearing on the summary list as expected
        /// </summary>
        /// <param name="trainSeed">Seed for the train whose suggestion will be validated</param>
        /// <param name="expectedAt">The expected At location that should appear for the suggestion</param>
        /// <param name="expectedFrom">The expected From location that should appear for the suggestion</param>
        /// <param name="expectedTo">The expected To location that should appear for the suggestion</param>
        /// <param name="clearMain">Whether or not we should expected clear main for the suggestion {true} or not {False}</param>
        /// <param name="holdMain">Whether or not we should expected hold main for the suggestion {true} or not {False}</param>
        /// <param name="territory">Territory to be searched for alongside the logical position in the summary list choice form</param>
        public static void NS_ValidateLimitSuggestionContentInSummaryList (string trainSeed, string engineSeed, string expectedAt, string expectedFrom, string expectedTo, bool clearMain, bool holdMain, string territory)
        {
            if (!NS_OpenSuggestionSummaryList(territory, trainSeed))
                return;

            TrackAuthorityrepo.Limit_Suggestion_Summary_List.Self.EnsureVisible();

            int retries = 0;
            TrackAuthorityrepo.TrainId = NS_TrainID.GetTrainId(trainSeed);
            while (!TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists(0) && retries < 3)
            {
                Delay.Milliseconds(500);
                retries++;
            }

            if(!TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists(0))
            {
                Report.Failure("Limit Suggestion did not appear for TrainSeed {"+trainSeed+"}.");
                Report.Screenshot(TrackAuthorityrepo.Limit_Suggestion_Summary_List.Self.Element);
                return;
            }

            //At Validations
            string toValidate;
            string engineId = NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed).EngineNumber;

            //TODO I Feel like this can be neater....almost like a foreach, although syntactically its a bit tricky since you have to assign the repo item, pretty sure
            //it would be easy to turn the variable name into a string literal and use those for the reports though

            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Description.Text;
            if (toValidate.Contains(engineId)) //Please use some common sense for your engine IDs so theyre unique
            {
                Report.Success("Expected Engine: {"+engineId+"} is present.");
            }
            else
            {
                Report.Failure("Expected Engine value: {"+engineId+"} is not present. Description reads: {"+toValidate+"}.");
            }

            //At location
            //TODO ENABLE AFTER FEATURE IS COMPLETE
            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.At.Text;
            if (toValidate.Contains(expectedAt)) //Using contains, want to ignore division/state appended at the end
            {
                Report.Success("Expected At value: {"+expectedAt+"} is present.");
            }
            else
            {
                Report.Failure("Expected At value: {"+expectedAt+"} is not present. At value = {"+toValidate+"}.");
            }

            //from location
            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.From.Text;
            if (toValidate.Contains(expectedFrom))
            {
                Report.Success("Expected From value: {"+expectedFrom+"} is present.");
            }
            else
            {
                Report.Failure("Expected From value: {"+expectedFrom+"} is not present. From value = {"+toValidate+"}.");
            }

            //to location
            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.To.Text;
            if (toValidate.Contains(" "))
                toValidate = toValidate.Substring(0, toValidate.LastIndexOf(' '));
            if (expectedTo.Contains(toValidate))
            {
                Report.Success("Expected To value: {"+toValidate+"} is present from values = {"+expectedTo+"}.");
            }
            else
            {
                Report.Failure("Expected To value: {"+expectedTo+"} is not present. To value = {"+toValidate+"}.");
            }

            //Clear main
            string boolString;
            if (clearMain)
            {
                boolString = "Y";
            }
            else
            {
                boolString = "N";
            }
            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.ClearMain.Text;
            //clear main and hold main are bools, so convert bool to Y or N earlier
            if (boolString.Equals(toValidate))
            {
                Report.Success("Expected Clear Main value: {"+boolString+"} is present.");
            }
            else
            {
                Report.Failure("Expected Clear Main value: {"+boolString+"} is not present. Clear Main value = {"+toValidate+"}.");
            }

            //Hold Main
            if (holdMain)
            {
                boolString = "Y";
            }
            else
            {
                boolString = "N";
            }
            toValidate = TrackAuthorityrepo.Limit_Suggestion_Summary_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.HoldMain.Text;
            //clear main and hold main are bools, so convert bool to Y or N earlier
            if (boolString.Equals(toValidate))
            {
                Report.Success("Expected Hold Main value: {"+boolString+"} is present.");
            }
            else
            {
                Report.Failure("Expected Hold Main value: {"+boolString+"} is not present. Hold Main value = {"+toValidate+"}.");
            }

            Report.Screenshot(TrackAuthorityrepo.Limit_Suggestion_Summary_List.Self.Element);

        }

        [UserCodeMethod]
        public static void NS_ValidateLimitSuggestionContentInTaskList (string trainSeed, string engineSeed, string expectedAt, string expectedFrom, string expectedTo, bool clearMain, bool holdMain)
        {
            if(!NS_OpenSuggestionListForTrain(trainSeed))
            {
                return; //couldnt find the suggestion
            }

            Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.EnsureVisible();

            Miscellaneousrepo.LimitSuggestionsIndex = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Self.Element.GetAttributeValueText("Index");

            //At Validations
            string toValidate;

            //TODO I Feel like this can be neater....almost like a foreach, although syntactically its a bit tricky since you have to assign the repo item, pretty sure
            //it would be easy to turn the variable name into a string literal and use those for the reports though

            string engineId = NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeed).EngineNumber;
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Description.Text;
            if (toValidate.Contains(engineId)) //Please use some common sense for your engine IDs so theyre unique
            {
                Report.Success("Expected Engine: {"+engineId+"} is present.");
            }
            else
            {
                Report.Failure("Expected Engine value: {"+engineId+"} is not present. Description reads: {"+toValidate+"}.");
            }

            //At location
            //TODO ENABLE AFTER FEATURE IS COMPLETE
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.At.Text;
            if (toValidate.Contains(expectedAt)) //Using contains, want to ignore division/state appended at the end
            {
                Report.Success("Expected At value: {"+expectedAt+"} is present.");
            }
            else
            {
                Report.Failure("Expected At value: {"+expectedAt+"} is not present. At value = {"+toValidate+"}.");
            }

            //from location
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.From.Text;
            if (toValidate.Contains(expectedFrom))
            {
                Report.Success("Expected From value: {"+expectedFrom+"} is present.");
            }
            else
            {
                Report.Failure("Expected From value: {"+expectedFrom+"} is not present. From value = {"+toValidate+"}.");
            }

            //to location
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.To.Text;
            if (toValidate.Contains(" "))
                toValidate = toValidate.Substring(0, toValidate.LastIndexOf(' ')); //take care of state appended to end
            //clear main and hold main are bools, so convert bool to Y or N earlier
            if (expectedTo.Contains(toValidate)) //unfortunately, too limits can be inconsistent so this has been flipped
            {
                Report.Success("Expected To value: {"+toValidate+"} is present from values to be validated = {"+expectedTo+"}.");
            }
            else
            {
                Report.Failure("Expected To value: {"+expectedTo+"} is not present. To value = {"+toValidate+"}.");
            }

            //Clear main
            string boolString;
            if (clearMain)
            {
                boolString = "Y";
            }
            else
            {
                boolString = "N";
            }
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.ClearMain.Text;
            if (boolString.Equals(toValidate))
            {
                Report.Success("Expected Clear Main value: {"+boolString+"} is present.");
            }
            else
            {
                Report.Failure("Expected Clear Main value: {"+boolString+"} is not present. Clear Main value = {"+toValidate+"}.");
            }

            //Hold Main
            if (holdMain)
            {
                boolString = "Y";
            }
            else
            {
                boolString = "N";
            }
            toValidate = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.HoldMain.Text;
            //clear main and hold main are bools, so convert bool to Y or N earlier
            if (boolString.Equals(toValidate))
            {
                Report.Success("Expected Hold Main value: {"+boolString+"} is present.");
            }
            else
            {
                Report.Failure("Expected Hold Main value: {"+boolString+"} is not present. Hold Main value = {"+toValidate+"}.");
            }

            Report.Screenshot(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Element);
        }

        [UserCodeMethod]
        public static bool NS_OpenSuggestionListForTrain (string trainSeed)
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            Miscellaneousrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            try
            {
                Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.WaitForExists(20000);
            }
            catch
            {
                Report.Failure("Suggestion for {"+Miscellaneousrepo.TrainId+"} did not appear.");
                Report.Screenshot();
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
                return false;
            }
            return true;
        }

        [UserCodeMethod]
        public static void NS_OpenLimitSuggestion (string trainSeed)
        {
            if(!NS_OpenSuggestionListForTrain(trainSeed))
            {
                return; //couldnt find the suggestion
            }
            Miscellaneousrepo.LimitSuggestionsIndex = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Self.Element.GetAttributeValueText("Index");
            Ranorex.Report.Info(Miscellaneousrepo.LimitSuggestionsIndex);
            try
            {

                Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo.WaitForExists(10000);
                GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo, Miscellaneousrepo.Task_List.OpenInfo);
                GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.OpenInfo, TrackAuthorityrepo.Create_Track_Authority.SelfInfo);
            }
            catch (RanorexException)
            {
                Report.Screenshot(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.Self.Element);
                Report.Failure("Couldn't open authority for {"+trainSeed+"}.");
            }

        }

        [UserCodeMethod]
        public static void NS_OpenFirstLimitSuggestion ()
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            Miscellaneousrepo.LimitSuggestionsIndex = "0";
            if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo.Exists(0))
            {
                int retries = 0;
                while (!TrackAuthorityrepo.Create_Track_Authority.SelfInfo.Exists(0) && retries < 3)
                {
                    GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo, Miscellaneousrepo.Task_List.OpenInfo);
                    Miscellaneousrepo.Task_List.Open.Click();

                    if (!TrackAuthorityrepo.Create_Track_Authority.SelfInfo.Exists(0))
                        Ranorex.Delay.Milliseconds(3000);
                    retries++;
                }

            }
            else
            {
                Ranorex.Report.Info("No limit suggestions are present.");
            }
        }

        [UserCodeMethod]
        public static bool NS_TryOpenLimitSuggestion (string trainSeed)
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            Miscellaneousrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            Miscellaneousrepo.LimitSuggestionsIndex = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Self.Element.GetAttributeValueText("Index");
            Ranorex.Report.Info(Miscellaneousrepo.LimitSuggestionsIndex);
            if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo.Exists())
            {
                GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo, Miscellaneousrepo.Task_List.OpenInfo);
                GeneralUtilities.ClickAndWaitForFormTitleWithRetry(Miscellaneousrepo.Task_List.OpenInfo, "Create Track Authority");
                return true;
            }
            else
            {
                Ranorex.Report.Info("No limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
            }
            return false;
        }

        [UserCodeMethod]
        public static void NS_ThrowAwayLimitSuggestion (string trainSeed)
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            Miscellaneousrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            Miscellaneousrepo.LimitSuggestionsIndex = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.Self.Element.GetAttributeValueText("Index");
            Ranorex.Report.Info(Miscellaneousrepo.LimitSuggestionsIndex);
            if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo.Exists())
            {
                GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionSelection.LimitSuggestionMenuCellInfo, Miscellaneousrepo.Task_List.OpenInfo);
                GeneralUtilities.ClickAndWaitForFormTitleWithRetry(Miscellaneousrepo.Task_List.OpenInfo, "Create Track Authority");
            }
            else
            {
                Ranorex.Report.Info("No limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
                return;
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrackAuthorities_Repo.Instance.Create_Track_Authority.CancelButtonInfo, TrackAuthorities_Repo.Instance.Create_Track_Authority.SelfInfo);
        }

        [UserCodeMethod]
        public static void NS_ValidateLimitSuggestionPresentForTrain (string trainSeed, bool expectedPresence, bool closeForms)
        {
            NS_OpenLimitSuggestionsForm_MainMenu();

            Miscellaneousrepo.TrainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            bool result = Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists();
            if (result && expectedPresence == true)
            {
                Ranorex.Report.Success("Limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
            }
            else if (result && expectedPresence == false)
            {
                Ranorex.Report.Failure("Limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is unexpectedly present.");
            }
            else if (!result && expectedPresence == false)
            {
                for (int x = 0; x < 3; x++) //Used enough, might wanna refactor it
                {
                    Delay.Milliseconds(1000);
                    if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists())
                    {
                        Ranorex.Report.Error("Limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
                        break;
                    }

                    if (x == 2)
                    {
                        Ranorex.Report.Success("No limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
                    }
                }
            }
            else
            {
                for (int x = 0; x < 3; x++) //Used enough, might wanna refactor it
                {
                    Delay.Milliseconds(2000);
                    if (Miscellaneousrepo.Task_List.LimitSuggestions.LimitSuggestionsTable.LimitSuggestionsRowByTrainID.SelfInfo.Exists())
                    {
                        Ranorex.Report.Success("Limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
                        break;
                    }

                    if (x == 2)
                    {
                        Ranorex.Report.Failure("No limit suggestion for train {" + Miscellaneousrepo.TrainId + "} is present.");
                    }
                }
            }

            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
            }
        }

        /// <summary>
        /// Opens a task based on description and employee name
        /// </summary>
        /// <param name="description">Input:Description of the task in the task list</param>
        /// <param name="employeeName">Input:Name of the task Employee</param>
        /// <param name="expectTask">expect Task in task list</param>
        [UserCodeMethod]
        public static void NS_OpenTaskByDescriptionAndEmployeeName(string description, string employeeName, bool expectTask)
        {
            NS_OpenTaskListForm_MainMenu();
            bool taskFound = false;
            Report.Info(String.Format("Validating task in the TaskList list with description: {0} and employee_name(contains): {1}", description, employeeName));
            //Due to delays being possible with the initiation of a Task, multiple iterations may be necessary
            for (int j = 0; j < 5; j++)
            {
                int taskCount = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;

                for(int i = 0; i < taskCount; i++)
                {
                    Miscellaneousrepo.TaskIndex = i.ToString();
                    string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.Trim().ToLower();
                    string employeeNameText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TrainIDEmployeeName.Text.Trim().ToLower();
                    Regex descriptionRegex = new Regex(description.ToLower());
                    Regex employeeNameRegex = new Regex (employeeName.ToLower());
                    if (descriptionRegex.IsMatch(descriptionText) && employeeNameRegex.IsMatch(employeeNameText))
                    {
                        //Open the Task
                        taskFound=true;
                        if(expectTask)
                        {

                        	Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.Self.EnsureVisible();
                            GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
                                                                           Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo);
                            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
                                                                              Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
                        }

                        break;
                    }
                }
                if(taskFound){
                    break;
                }
            }
            if(!expectTask && (taskFound == false))
            {
                Ranorex.Report.Success(String.Format("Task in the tasklist with description: {0} and employee name: {1}", description, employeeName," not found as expected"));
            }
            else if(expectTask && (taskFound == true))
            {
                Ranorex.Report.Success(String.Format("Found task in the Tasklist with description: {0} and employee name: {1}", description, employeeName));
            }
            else
            {
                Ranorex.Report.Failure(String.Format("Could not find task in the Tasklist with description: {0} and employee name: {1}", description, employeeName));
            }
            return;
        }

        /// <summary>
        /// Opens Authority Task assigned to train
        /// </summary>
        [UserCodeMethod]
        public static void OpenTrackAuthorityTaskByTypeAndTrainId(string trainSeed, string engineSeed, string authoritySeed, string taskAuthorityType)
        {
        	string description = "";
        	string empName = "";
        	string engineNumber = PDS_CORE.Code_Utils.NS_TrainID.GetEngineNumber(trainSeed,engineSeed);
        	string trainID = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
        	string authorityNumber = PDS_NS.UserCodeCollections.NS_Authorities.GetAuthorityNumber(authoritySeed);
        	switch(taskAuthorityType.ToLower())
        	{
        		case "issue":
        			description = "Issue Track Authority  addressed to "+trainID+".";
        			Report.Info("Emp Name: "+empName);
        			empName = trainID + @" \(NS "+engineNumber+@"\)";
        			break;
        			
        		case "rollup":
        			description = "Rollup Track Authority "+authorityNumber+" addressed to "+trainID+".";
        			Report.Info("Emp Name: "+empName);
        			empName = trainID + @" \(NS "+engineNumber+@"\)";
        			break;
        			
        		case "void":
        			description = "Void Track Authority "+authorityNumber+" addressed to "+trainID+".";
        			Report.Info("Emp Name: "+empName);
        			empName = trainID + @" \(NS "+engineNumber+@"\)";
        			break;
        			
        		default:
        			Ranorex.Report.Failure("Invalid taskAuthorityType: "+taskAuthorityType);
        			break;
        			
        	}
        	
        	NS_OpenTaskByDescriptionAndEmployeeName(description, empName, true);
        }

        /// <summary>
        /// Opens  AlertEventQueueSummary window
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenAlertEventQueueSummary()
        {
            int retries = 0;
            //Open Alert_Event_Queue Form if it's not already open
            if(!Miscellaneousrepo.Alert_Event_Queue.SelfInfo.Exists(0))
            {
                if(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo.Exists(0)){
                    MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton.Click();
                }
                else
                {
                    Ranorex.Report.Failure("Failure", "Unable to find object" + MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton);
                }

                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.AlertEvents.Self.Click();
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.AlertEvents.AlertEventQueue.Click();
            }

            //Wait for Alert_Event_Queue Form to exist in case of lag
            if (!Miscellaneousrepo.Alert_Event_Queue.SelfInfo.Exists(0))
            {
                Ranorex.Delay.Milliseconds(500);
                while (!Miscellaneousrepo.Alert_Event_Queue.SelfInfo.Exists(0) && retries < 2)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }

                if (!Miscellaneousrepo.Alert_Event_Queue.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("AlertEvent queue summary window did not open");
                    return;
                }

            }
            Ranorex.Report.Success("AlertEvent queue summary window opened");

        }




        /// <summary>
        /// This function  checks alerts is Present or Absent for all  AlertTypes and Acknowledge the All types of Alert.
        /// it takes the paramete of type alert that needs to check.
        /// If AcknowledgeAll is true ,it will acknowledge all else it will acknowlegde only alert type is passing
        /// <param name="alertType">Input: Specify Any alert Type</param>
        /// <param name="acknowledgeAll">Input:True to Acknowledge all or False for Acknowledge only alert type passed </param>
        /// </summary>
        [UserCodeMethod]
        public static void AcknowledgeAlerts_AlertEventQueueSummary(string alertType, bool acknowledgeAll)
        {
            //Open Alert_Event_Queue Form if it's not already open
            NS_OpenAlertEventQueueSummary();

            int alertcount=0;
            // verifying the alert are present in the table or not.
            if(!Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.SelfInfo.Exists(0))
            {
                Report.Info("NO Alerts are present in the AlertQueueSummary");

            }
            else
            {
                // Getting number of alerts present in table and Acknowledging the alerts.
                IList<Ranorex.Row> rows =Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.Self.Rows;
                for(int i = 0; i < rows.Count-1; i = i+2)
                {
                    Miscellaneousrepo.AlertQueueSummaryIndex = i.ToString();
                    Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.Self.Click();
                    //if AcknowledgeAll is false it will acknowledge only alert type passed
                    if (!acknowledgeAll)
                    {
                        if (rows[i].Cells[(int)AlertQueueSummaryHeaders.Type].Text.Contains(alertType))
                        {
                            alertcount++;
                            //Acknowledge the alerts type that are passed
                            if(Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Enabled)
                            {
                                Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Click();
                            }
                        }
                    }
                    else
                    {
                        // Acknowledge all the alert present in it.
                        if (rows[i].Cells[(int)AlertQueueSummaryHeaders.Type].Text.Contains(alertType))
                        {
                            alertcount++;
                        }
                        if(Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Enabled)
                        {
                            Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Click();
                        }
                    }
                }

                Report.Info("Number of alert present is "+alertcount);
            }
        }

        /// <summary>
        /// This function  is Validating whether the Alerts are Acknowledged or not.
        /// The passing arguments should be same as the arguments passed  to AcknowledgeAlertEventQueueSummary function.
        /// <param name="alertType">Input: Specify Any alert Type</param>
        /// <param name="acknowledgeAll">Input:True to verify all types or False for verifying only alert type passed </param>
        /// </summary>
        [UserCodeMethod]
        public static void ValidatesAlertEventQueueSummary(string alertType, bool acknowledgeAll)
        {

            if(!Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.SelfInfo.Exists())
            {
                Report.Info("NO Alerts are present in the AlertQueueSummary");
                return;
            }
            // to count the number of Alerts and unacknowledged alerts in the table
            int AcknowledgeCount = 0 ;
            int AlertCount =1;
            IList<Ranorex.Row> rows =Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.Self.Rows;

            //validating each alert is acknowledged or not present in the table
            for(int i = 0; i < rows.Count-1; i=i+2)
            {
                Miscellaneousrepo.AlertQueueSummaryIndex = i.ToString();
                Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.Self.Click();
                //if Acknowledge all is false it will Verify only alert type passed is acknowledged or not
                if (!acknowledgeAll)
                {
                    //	 Verify Particular passed alerts are acknowledged or not
                    if (rows[i].Cells[(int)AlertQueueSummaryHeaders.Type].Text.Contains(alertType))
                    {
                        if(Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Enabled)
                        {
                            AcknowledgeCount++;
                            Ranorex.Report.Info("Alert Number " + AlertCount + " is not acknowledged " );
                        }
                    }
                }
                else
                {
                    //	 Verify all alerts are acknowledged or not
                    if(Miscellaneousrepo.Alert_Event_Queue.AcknowledgeButton.Enabled)
                    {
                        AcknowledgeCount++;
                        Ranorex.Report.Info( "Alert Number " + AlertCount + " is not acknowledged " );
                    }
                }
                AlertCount++;
            }
            if( AcknowledgeCount > 0)
            {
                Report.Failure("Number of Alerts Not acknowledged :" + AcknowledgeCount);
            }
            else
            {
                Report.Success("All the alerts are Acknowledged");
            }

        }


        /// <summary>
        /// Opens the pending activity summary form from Main menu
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenPendingActivitySummary_MainMenu()
        {
            int retries = 0;

            //Open pending activity summary form if it's not already open
            if (!Miscellaneousrepo.Pending_Activity_Summary.SelfInfo.Exists(0))
            {
                //Click Miscellaneous menu
                MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButton.Click();
                //Click Pending activity summary in Miscellaneous menu
                MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.PendingActivitySummary.Click();

                Ranorex.Report.Info ("Pending activity summary form has loaded");

                //Wait for Pending_Activity_Summary Form to exist in case of delay
                if (!Miscellaneousrepo.Pending_Activity_Summary.SelfInfo.Exists(0))
                {
                    Ranorex.Delay.Milliseconds(500);
                    while (!Miscellaneousrepo.Pending_Activity_Summary.SelfInfo.Exists(0) && retries < 2)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }

                    if (!Miscellaneousrepo.Pending_Activity_Summary.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Pending activity summary form did not open");
                        return;
                    }
                }
                Miscellaneousrepo.Pending_Activity_Summary.WindowControls.Maximize.Click();
            }

            return;
        }

        /// <summary>
        /// Close the pending activity summary form from Miscellaneous
        /// </summary>
        [UserCodeMethod]
        public static void NS_ClosePendingActivitySummary_Miscellaneous_MainMenu()
        {
            // If pending activity summary form already opened
            if (!Miscellaneousrepo.Pending_Activity_Summary.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Pending activity summary form did not open");
            }
            else
            {
                GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.WindowControls.CloseInfo, MainMenurepo.PDS_Main_Menu.MainMenuBar.SelfInfo);
                Ranorex.Report.Info("Pending activity summary form closed");
            }
        }


        /// <summary>
        /// Verify activity details exists in pending activity summary form.
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Opsta Location (ex: 101H)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        [UserCodeMethod]
        public static void NS_ValidateTripPlanActivityExists_PendingActivitySummary(string trainSeed, string activityType, string opsta, bool validateExist)
        {
            GeneralUtilities.CheckWaitState(2);
            int activity = Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.Self.Rows.Count;
            Ranorex.Report.Info(String.Format("Found {0} Activity in the Pending Activity Summary.", activity.ToString()));
            if(activity == 0)
            {
                Ranorex.Report.Failure("Activity doesn't exist or it takes more time to load in PAS form");
                Ranorex.Report.Screenshot(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.Self.Element);
                return;
            }

            bool resultFound = false;
            for (int i=0; i <activity; i++)
            {
                Miscellaneousrepo.PendingActivityIndex = i.ToString();
                string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);

                if(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.SelfInfo.Exists(0))
                {
                    string trainIDPAS = Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.Train.GetAttributeValue<string>("train");
                    if(trainIDPAS.Equals(trainId, StringComparison.OrdinalIgnoreCase))
                    {
                        string activityList = Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.Activity.GetAttributeValue<string>("event");
                        if(activityList.Equals(activityType, StringComparison.OrdinalIgnoreCase))
                        {
                            string currentLocation = "";
                            if(!String.IsNullOrEmpty(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.OpSta.GetAttributeValue<string>("opsta")))
                            {
                                currentLocation = Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.OpSta.GetAttributeValue<string>("opsta");
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
            }

            if(resultFound == validateExist)
            {
                Ranorex.Report.Success("Activity type expected to be " +validateExist+ " and found as " +resultFound+ "");
            }
            else
            {
                Ranorex.Report.Failure("Activity type expected to be " +validateExist+ " but found as " +resultFound+ "");
                Ranorex.Report.Screenshot(Miscellaneousrepo.Pending_Activity_Summary.Self.Element);
            }

        }


        /// <summary>
        /// Open and close Train sheet from PAS
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Opsta Location (ex: 240H)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_OpenTrainsheetFromActivity_PendingActivitySummary(string trainSeed, string activityType, string opsta, bool validateExist, bool closeForms)
        {
            NS_ValidateTripPlanActivityExists_PendingActivitySummary(trainSeed, activityType, opsta, validateExist);
            GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.ActivityInfo,
                                                           Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.MenuCellMenu.SelfInfo);

            GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.MenuCellMenu.OpenTrainSheetInfo,
                                                      Trainsrepo.Train_Sheet.SelfInfo);
            if(Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
            {
                Report.Success("TrainSheet form has been loaded");
            }
            else
            {
                Report.Failure("TrainSheet doesn't exist or load");
            }

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }

        /// <summary>
        /// Open and close update tracking from PAS
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Opsta Location (ex: 240H)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="closeForms">Input: Close forms, True to close the forms</param>
        [UserCodeMethod]
        public static void NS_OpenUpdateTrackingFromActivity_PendingActivitySummary(string trainSeed, string activityType, string opsta, bool validateExist, bool closeForms)
        {
            NS_ValidateTripPlanActivityExists_PendingActivitySummary(trainSeed, activityType, opsta, validateExist);
            GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.ActivityInfo, Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.MenuCellMenu.SelfInfo);

            GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.MenuCellMenu.OpenUpdateTrackingInfo, Trainsrepo.Update_Tracking.SelfInfo);
            if(Trainsrepo.Update_Tracking.SelfInfo.Exists(0))
            {
                Report.Success("Update tracking form has been loaded");
            }
            else
            {
                Report.Failure("Update tracking form doesn't exist");
            }

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Update_Tracking.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
            }
        }


        /// <summary>
        /// Validate and update Trip plan activity details in PAS
        /// </summary>
        /// <param name="trainSeed">trainseed</param>
        /// <param name="activityType">The type of activity that is being validated, as it is stated on Trip Plan (e.g. "Originate' or 'Change Crew' etc)</param>
        /// <param name="opsta">Input: Opsta Location (ex: 240H)</param>
        /// <param name="dwell">Input: Dwell (ex: 00:20)</param>
        /// <param name="reason">Input: Reason (ex: PAS form test)</param>
        /// <param name="location">Input: Location (ex: XXXX)</param>
        /// <param name="validateExist">Input: Validate Exist (ex: True or False)</param>
        /// <param name="expectedFeedback">Input: Feedback(ex: Give your feedback)</param>
        [UserCodeMethod]
        public static void NS_UpdateTripPlanDetails_PendingActivitySummary(string trainSeed, string activityType, string opsta, string dwell, string reason, string location, string expectedFeedback, bool validateExist)
        {
            NS_ValidateTripPlanActivityExists_PendingActivitySummary(trainSeed, activityType, opsta, validateExist);
            GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryTable.PendingActivityRowByIndex.MenuCellInfo, Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.SelfInfo);

            if(dwell != "")
            {
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Dwell.Click();
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Dwell.PressKeys(dwell);
                Ranorex.Report.Info("Dwell modified value is " +dwell);
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Dwell.PressKeys("{TAB}");
            }

            if(reason != "")
            {
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_AssignedWorkDetails.Reason_Text.Click();
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_AssignedWorkDetails.Reason_Text.PressKeys(reason);
                Ranorex.Report.Info("Reason text modified value is " +reason);
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_AssignedWorkDetails.Reason_Text.PressKeys("{TAB}");
            }

            if(location != "")
            {
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Location.Click();
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Location.PressKeys(location);
                Ranorex.Report.Info("Location modified value is " +location);
                Miscellaneousrepo.Pending_Activity_Summary.PendingActivitySummaryDetailsPanel.PendingActivitySummaryDetailsPanel_TripPlanOwner.Location.PressKeys("{TAB}");
                if(Miscellaneousrepo.Pending_Activity_Summary.Feedback.GetAttributeValue<string>("Text") != "")
                {
                    string actualFeedback = Miscellaneousrepo.Pending_Activity_Summary.Feedback.GetAttributeValue<string>("Text").Trim();
                    if(actualFeedback.Equals(expectedFeedback))
                    {
                        Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
                    }
                    else
                    {
                        Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
                    }
                }
            }

            //Click on Apply button
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Pending_Activity_Summary.ApplyButtonInfo, Miscellaneousrepo.Pending_Activity_Summary.ApplyButtonInfo);
        }

        /// <summary>
        /// Set visibility horizons value in Pending activity summary - System Configuration
        /// <param name="activities">Input: Time to be set for Activities (Ex: 240 minutes)/param>
        /// <param name="assignedWork">Input: Time to be set for Assignedwork (Ex:240 minutes)</param>
        /// <param name="exceptions">Input: Time to be set for Exceptions (Ex: 240 minutes)</param>
        /// <param name="crewCall">Input: Time to be set for CrewCall (Ex: 240 minutes)</param>
        /// </summary>
        [UserCodeMethod]
        public static void NS_SetVisibilityHorizons_PendingActivitySummary(string activities, string assignedWork, string exceptions, string crewCall)
        {
            //Open pending activity summary
            GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo,
                                                      MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.SelfInfo);

            GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.SystemConfigurationMenu.PendingActivitySummaryInfo,
                                                      SystemConfigurationrepo.Pending_Activity_Summary.SelfInfo);
            Report.Info("Pending activity summary form has been loaded");
            if( activities != "")
            {
                SystemConfigurationrepo.Pending_Activity_Summary.ActvitesText.Click();
                SystemConfigurationrepo.Pending_Activity_Summary.ActvitesText.Element.SetAttributeValue("Text", activities);
                SystemConfigurationrepo.Pending_Activity_Summary.ActvitesText.PressKeys("{TAB}");
            }

            if( assignedWork != "")
            {
                SystemConfigurationrepo.Pending_Activity_Summary.AssignedWorkText.Click();
                SystemConfigurationrepo.Pending_Activity_Summary.AssignedWorkText.Element.SetAttributeValue("Text", assignedWork);
                SystemConfigurationrepo.Pending_Activity_Summary.AssignedWorkText.PressKeys("{TAB}");
            }

            if( exceptions != "")
            {
                SystemConfigurationrepo.Pending_Activity_Summary.ExceptionsText.Click();
                SystemConfigurationrepo.Pending_Activity_Summary.ExceptionsText.Element.SetAttributeValue("Text", exceptions);
                SystemConfigurationrepo.Pending_Activity_Summary.ExceptionsText.PressKeys("{TAB}");
            }

            if( crewCall != "")
            {
                SystemConfigurationrepo.Pending_Activity_Summary.CrewCallText.Click();
                SystemConfigurationrepo.Pending_Activity_Summary.CrewCallText.Element.SetAttributeValue("Text", crewCall);
                SystemConfigurationrepo.Pending_Activity_Summary.CrewCallText.PressKeys("{TAB}");
            }

            // Click on Apply button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForDisabledWithRetry(SystemConfigurationrepo.Pending_Activity_Summary.ApplyButtonInfo, SystemConfigurationrepo.Pending_Activity_Summary.ApplyButtonInfo);
            Ranorex.Report.Info("Successfully updated visibility horizon parameters in Pending activity summary form");
            // Click on Cancel button
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(SystemConfigurationrepo.Pending_Activity_Summary.CancelButtonInfo, MainMenurepo.PDS_Main_Menu.MainMenuBar.SystemConfigurationButtonInfo);

        }

        /// <summary>
        /// Close the Task List form from Miscellaneous
        /// </summary>
        [UserCodeMethod]
        public static void CloseTaskListForm_Miscellaneous_MainMenu()
        {
            // If Task List form already opened
            if (!Miscellaneousrepo.Task_List.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Task-List form did not open");
            }
            else
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.WindowControls.CloseInfo, Miscellaneousrepo.Task_List.SelfInfo);
                Ranorex.Report.Info("Task-List form is closed");
            }
        }

        /// <summary>
        /// Validate Task List Menu options Enabled or Disabled
        /// </summary>
        /// <param name="description">Input:Description of the task in the task list</param>
        /// <param name="employeeName">Input:Name of the task Employee</param>
        /// <param name="enabledTaskListMenuOption">Pass the options name which is expected to be Enabled(e.g. Open)</param>
        /// <param name="disabledTaskListMenuOption">Pass the options name which is expected to be disabled(e.g. Delete)</param>
        /// <param name="expectTask">expect Task in task list</param>
        [UserCodeMethod]
        public static void NS_ValidateTaskListOptionsEnabledAndDisabled(string description, string employeeName, string enabledTaskListMenuOption, string disabledTaskListMenuOption)
        {
            bool foundTask = false;
            NS_OpenTaskListForm_MainMenu();
            Report.Info(String.Format("Validating authority in the TaskList list with status: {0} employee_name(contains): {1}", description, employeeName));
            int taskCount = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
            for(int i = 0; i < taskCount; i++)
            {
                Miscellaneousrepo.TaskIndex = i.ToString();
                string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
                string employeeNameText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TrainIDEmployeeName.Text.ToLower();
                if (descriptionText.Contains(description.ToLower()) && employeeNameText.Contains(employeeName.ToLower()))
                {
                    foundTask = true;
                    break;
                }
            }

            if (!foundTask)
            {
                Ranorex.Report.Error("Could not find Task with description {" + description + "} and employee name {" + employeeName + "}.");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
                return;
            }

            GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
                                                           Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);

            if(enabledTaskListMenuOption != "")
            {
                string[] expectEnabledList = enabledTaskListMenuOption.Split('|');
                foreach (string expectEnabled in expectEnabledList)
                {
                    if (expectEnabled.ToLower() == "open")
                    {
                        if (Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.Open.Enabled)
                        {
                            Ranorex.Report.Success("Open was found to be enabled in task list");
                        } else {
                            Ranorex.Report.Failure("Open was expected to be enabled and found to be disabled in task list");
                        }
                    } else if (expectEnabled.ToLower() == "delete")
                    {
                        if (Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.Delete.Enabled)
                        {
                            Ranorex.Report.Success("Delete was found to be enabled in task list");
                        } else {
                            Ranorex.Report.Failure("Delete was expected to be enabled and found to be disabled in task list");
                        }
                    } else {
                        Ranorex.Report.Error("Unexpected menu option {" + expectEnabled + "} does not exist");
                    }
                }
            }

            if(disabledTaskListMenuOption != "")
            {
                string[] expectDisabledList = disabledTaskListMenuOption.Split('|');
                foreach (string expectDisabled in expectDisabledList)
                {
                    if (expectDisabled.ToLower() == "open")
                    {
                        if (!Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.Open.Enabled)
                        {
                            Ranorex.Report.Success("Open was found to be disabled in task list");
                        } else {
                            Ranorex.Report.Failure("Open was expected to be disabled and found to be enabled in task list");
                        }
                    } else if (expectDisabled.ToLower() == "delete")
                    {
                        if (!Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.Delete.Enabled)
                        {
                            Ranorex.Report.Success("Delete was found to be disabled in task list");
                        } else {
                            Ranorex.Report.Failure("Delete was expected to be disabled and found to be enabled in task list");
                        }
                    } else {
                        Ranorex.Report.Error("Unexpected menu option {" + expectDisabled + "} does not exist");
                    }
                }
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
        }

        /// <summary>
        /// Validates whether a task exists or not in the Task List
        /// </summary>
        /// <param name="description">Input:Description of the task in the task list</param>
        /// <param name="employeeName">Input:Name of the task Employee</param>
        /// <param name="expectedTask">expect Task in task list</param>
        [UserCodeMethod]
        public static void NS_ValidateTaskExistsByDescriptionAndEmployeeName_TaskList(string description, string employeeName, bool expectedTask)
        {

            bool taskFound = false;
            NS_OpenTaskListForm_MainMenu();
            Report.Info(String.Format("Validating task in the TaskList list with status: {0} employee_name(contains): {1}", description, employeeName));
            int taskCount = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
            for(int i = 0; i < taskCount; i++)
            {
                Miscellaneousrepo.TaskIndex = i.ToString();
                string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
                string employeeNameText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TrainIDEmployeeName.Text.ToLower();
                if (descriptionText.Contains(description.ToLower()) && employeeNameText.Contains(employeeName.ToLower()))
                {
                    taskFound = true;
                    break;
                }

            }
            if(expectedTask == taskFound)
            {
                Ranorex.Report.Success(String.Format("Task " + (!taskFound ? "not " : "") + "found in the tasklist with description: {0} and employee name: {1}", description, employeeName));
            } else {
                Ranorex.Report.Failure(String.Format("Task " + (!taskFound ? "not " : "") + "found in the tasklist with description: {0} and employee name: {1}", description, employeeName));
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
            return;
        }


        /// <summary>
        /// Validates alert level summary in alert event queue
        /// </summary>
        /// <param name="alertLevelSummary">Input:alertLevelSummary</param>
        /// <param name="validateExist">Input:validateExist</param>
        /// <param name="closeForms">Input:closeForms </param>
        [UserCodeMethod]
        public static void NS_ValidateAlertlevelSummary_AlertQueueSummary(string alertLevelSummary, bool validateExist, bool closeForms)
        {
            string expAlertLevelSummary = "";
            bool alertFound = false;

            //Open Alert_Event_Queue Form if it's not already open
            NS_OpenAlertEventQueueSummary();

            int alertCount = Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.Self.Rows.Count;
            Report.Info("Number of rows found in Alert event queue is " +alertCount);

            for(int i = 0; i < alertCount; i++)
            {
                Miscellaneousrepo.AlertQueueSummaryIndex = i.ToString();
                expAlertLevelSummary = Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.LevelSummary.GetAttributeValue<string>("Text");
                Report.Info("Alert level summary is " +expAlertLevelSummary);

                if (expAlertLevelSummary.Contains(alertLevelSummary))
                {
                    alertFound = true;
                    break;
                }
            }

            if(alertFound == validateExist)
            {
                Report.Success("Alert event summary expected to be {"+alertLevelSummary+"} found {"+expAlertLevelSummary+"}");
            }
            else
            {
                Report.Failure("Alert event summary expected to be {"+alertLevelSummary+"} but found {"+expAlertLevelSummary+"}");
                Ranorex.Report.Screenshot(Miscellaneousrepo.Alert_Event_Queue.Self.Element);
            }

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Queue.CloseButtonInfo, Miscellaneousrepo.Alert_Event_Queue.SelfInfo);
            }
        }


        /// <summary>
        /// Validates alert event pop up
        /// </summary>
        /// <param name="alertEvent">Input:alertEvent</param>
        /// <param name="alertSummary">Input:alertSummary</param>
        /// <param name="alertPopup">Input:alertPopup </param>
        /// <param name="acknowledge">Input:acknowledge</param>
        /// <param name="validateExist">Input:validateExist</param>
        /// <param name="closeForms">Input:closeForms </param>
        [UserCodeMethod]
        public static void NS_AcknowledgeValidateAlertEventPopup_AlertQueueSummary(string alertEvent, string alertSummary, bool alertPopup, bool acknowledge, bool validateExist, bool closeForms)
        {
            string acutalAlertEvent = "";
            string acutalAlertSummary = "";
            bool alertFound = false;

            if(alertPopup)
            {
                if(Miscellaneousrepo.Alert_Event_Popup.SelfInfo.Exists(0))
                {
                    acutalAlertEvent= Miscellaneousrepo.Alert_Event_Popup.AlertEventTypeText.GetAttributeValue<string>("AccessibleName").ToString();
                    acutalAlertSummary = Miscellaneousrepo.Alert_Event_Popup.AlertEventText.GetAttributeValue<string>("Text").ToString();
                    alertFound = true;
                }

                if(alertFound == validateExist)
                {
                    Report.Success("Alert event summary expected to be {"+alertEvent+"} and found {"+acutalAlertEvent+"}");
                    Report.Success("Alert event summary expected to be {"+alertSummary+"} and found {"+acutalAlertSummary+"}");
                }
                else
                {
                    Report.Failure("Alert event summary expected to be {"+alertEvent+"} but found {"+acutalAlertEvent+"}");
                    Report.Failure("Alert event summary expected to be {"+alertSummary+"} but found {"+acutalAlertSummary+"}");
                    Ranorex.Report.Screenshot(Miscellaneousrepo.Alert_Event_Popup.Self.Element);
                }

                if(acknowledge)
                {
                    //Click on acknowledge button
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Popup.AcknowledgeButtonInfo,
                                                                      Miscellaneousrepo.Alert_Event_Popup.AcknowledgeButtonInfo);
                }
            }

            else
            {
                Report.Success("Alert event event popup doesn't found");
            }

            if(closeForms)
            {
                //Close forms
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Popup.WindowControls.CloseInfo, Miscellaneousrepo.Alert_Event_Popup.WindowControls.CloseInfo);

            }
        }


        /// <summary>
        /// Validates acknowledge option in alert queue summary
        /// </summary>
        /// <param name="acknowledgeAvail">Input:acknowledgeAvail</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void ValidateAcknowledgeOptionAvail_AlertEventQueueSummary(int alertIndex, bool acknowledgeAvail, bool closeForms)
        {
            //Open Alert_Event_Queue Form if it's not already open
            NS_OpenAlertEventQueueSummary();

            int alertrows = Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.Self.Rows.Count;
            Report.Info(" "+alertrows);

            if(alertrows == 0)
            {
                Report.Error("No Alerts are present in the AlertQueueSummary");
                return;
            }

            Miscellaneousrepo.AlertQueueSummaryIndex = alertIndex.ToString();
            if(acknowledgeAvail && Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.AcknowledgeCell.EnsureVisible())
            {
                Report.Success("Acknowledge option availed in Alert queue summary");

            }
            else
            {
                Report.Failure ("Acknowledge option  not availed in Alert queue summary");
                Report.Screenshot(Miscellaneousrepo.Alert_Event_Queue.Self.Element);
            }

            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Queue.CloseButtonInfo,
                                                                  Miscellaneousrepo.Alert_Event_Queue.CloseButtonInfo);
            }
        }

        /// <summary>
        /// Validates acknowledge option in alert queue summary
        /// </summary>
        /// <param name="color">Input:color</param>
        /// <param name="alertIndex">Input:alertIndex</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void ValidateAlertColor_AlertEventQueueSummary(string color, int alertIndex, bool closeForms)
        {
        	//Open Alert_Event_Queue Form if it's not already open
        	NS_OpenAlertEventQueueSummary();

        	int rows = Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.Self.Rows.Count;
        	Report.Info(" "+rows);

        	if(rows == 0)
        	{
        		Report.Error("No Alerts are present in the AlertQueueSummary");
        		return;
        	}

        	Miscellaneousrepo.AlertQueueSummaryIndex = alertIndex.ToString();
        	if(color.ToLower().Equals("red"))
        	{
        		GeneralUtilities.ValidateColorForAnyAdapterByPixel(Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.LevelSummary, color, true);
        	}
        	else if(color.ToLower().Equals("yellow"))
        	{
        		GeneralUtilities.ValidateColorForAnyAdapterByPixel(Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.LevelSummary, color, true);
        	}
        	else if(color.ToLower().Equals("blue"))
        	{
        		GeneralUtilities.ValidateColorForAnyAdapterByPixel(Miscellaneousrepo.Alert_Event_Queue.AlertQueueSummaryTable.AlertQueueSummaryRowByIndex.LevelSummary, color, true);
        	}
        	else
        	{
        		Ranorex.Report.Failure("Color is not valid");
        	}

        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Alert_Event_Queue.CloseButtonInfo,
        		                                                  Miscellaneousrepo.Alert_Event_Queue.CloseButtonInfo);
        	}
        }

		public static void NS_OpenDispathcherMessageForm_MiscellaneousMenu()
		{
			int retries = 0;
			if (!Miscellaneousrepo.Dispatcher_Messages.SelfInfo.Exists(0))
			{
				//Click Miscellanous menu
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
				                                                                  MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.DispatcherMessagesInfo);
				PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.DispatcherMessagesInfo,
				                                                                      Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
				//Wait for Dispatcher Message Form to exist in case of lag
				if (!Miscellaneousrepo.Dispatcher_Messages.SelfInfo.Exists(0))
				{
					Ranorex.Delay.Milliseconds(500);
					while (!Miscellaneousrepo.Dispatcher_Messages.SelfInfo.Exists(0) && retries < 2)
					{
						Ranorex.Delay.Milliseconds(500);
						retries++;
					}

					if (!Miscellaneousrepo.Dispatcher_Messages.SelfInfo.Exists(0))
					{
						Ranorex.Report.Error("Dispatcher Meassage form did not open");
						return;
					}
				}
			} else {
				Miscellaneousrepo.Dispatcher_Messages.Self.EnsureVisible();
			}
			return;
		}

		/// <summary>
		/// Validate EntryText Message from DispatcherMessage form.
		/// </summary>
		/// <param name="entryText">Input:entryText</param>
		/// <param name="expectecdText">Input:expectecdText</param>
		/// <param name="closeForm">Input:closeForms</param>
		[UserCodeMethod]
		public static void NS_ValidateDispatcherMessageEntryText_MiscellaneousMenu(string divisionName, string territoryName, string expectEntryText, bool closeForm)
		{
			if (territoryName == "" || divisionName == "")
        	{
			    Ranorex.Report.Error("TerritoryName and or divisionName cannot be blank");
			    if(closeForm)
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.CancelButtonInfo,
    				                                                  Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
            return;
          }

    		}
        	Miscellaneousrepo.Division = divisionName;
        	Miscellaneousrepo.Territory = territoryName;
        	NS_OpenDispathcherMessageForm_MiscellaneousMenu();

        	//select division
        	string currentDivision = Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuItem.GetAttributeValue<string>("SelectedItemText");
        	if(currentDivision != Miscellaneousrepo.Division)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuItemInfo,
        		                                          Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo,
        		                                                 Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuList.SelfInfo);
        	}

        	//select territory
        	string currentTerritory = Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuItem.GetAttributeValue<string>("SelectedItemText");
        	if(currentTerritory != Miscellaneousrepo.Territory)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuItemInfo,
        		                                         Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuList.DispatchTerritoryItemByTerritoryNameInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuList.DispatchTerritoryItemByTerritoryNameInfo,
        		                                                 Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuList.SelfInfo);
        	}

			string actEntryText = Miscellaneousrepo.Dispatcher_Messages.DispatcherMessageText.GetAttributeValue<string>("Text").ToLower();

			if (actEntryText.Contains(expectEntryText.ToLower()))
			{
				Ranorex.Report.Success(String.Format(" found in the Dispatcher Message with Text: {0}", actEntryText));
			} else {
				Ranorex.Report.Failure(String.Format("Not found in the Dispatcher Message with Text: {0} ",actEntryText));
			}

			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.CancelButtonInfo,
				                                                  Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
			}
		}

		[UserCodeMethod]
        public static void NS_OpenDispatcherTranferRequestForm_MiscellaneousMainMenu(string optDivision, string optLogicalPosition, string expectedFeedback)
        {
        	int retries = 0;
        	//Open Dispatcher transfer request  Form if it's not already open
        	if (!TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
        	{

        		GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
        		                                          MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.GenerateTransferReportRequestInfo);
        		GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.GenerateTransferReportRequestInfo,
        		                                          Miscellaneousrepo.Generate_Transfer_Report.OkButtonInfo);

        		if(optDivision != "")
        		{
        			Miscellaneousrepo.Division = optDivision;

        			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Generate_Transfer_Report.Division.DivisionMenuItemInfo,
        			                                          Miscellaneousrepo.Generate_Transfer_Report.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);

        			Miscellaneousrepo.Generate_Transfer_Report.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
        		}

        		if(optLogicalPosition != "")
        		{
        			Miscellaneousrepo.LogicalPosition = optLogicalPosition;

        			GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Generate_Transfer_Report.LogicalPosition.LogicalDivisionMenuItemInfo,
        			                                          Miscellaneousrepo.Generate_Transfer_Report.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionNameInfo);

        			Miscellaneousrepo.Generate_Transfer_Report.LogicalPosition.LogicalPositionMenuList.LogicalPositionItemByLogicalPositionName.Click();
        		}

        		//check for feedback
        		if (!CheckFeedback(Miscellaneousrepo.Generate_Transfer_Report.Feedback, expectedFeedback))
        		{
        			GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Generate_Transfer_Report.WindowControls.CloseInfo,
        			                                                  Miscellaneousrepo.Generate_Transfer_Report.SelfInfo);
        			return;
        		}

        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Generate_Transfer_Report.OkButtonInfo,
        		                                                  Miscellaneousrepo.Generate_Transfer_Report.SelfInfo);

        	}
        	else{

        		Ranorex.Report.Success("Dispatcher tranfer report form already open succesfully");
        		return;
        	}
        	while(!TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0) && retries < 5)
        	{

        		Delay.Milliseconds(500);
        		retries++;
        	}
        	if (!TerritoryTransferrepo.Dispatcher_Transfer_Report.SelfInfo.Exists(0))
        	{

        		Ranorex.Report.Error("Dispatcher tranfer report form not open succesfully");
        		return;
        	}
        	else
        	{
        		Ranorex.Report.Success("Dispatcher tranfer report form open succesfully");
        		return;
        	}

        }

        /// <summary>
        /// Create EntryText and Remove EntryText from Dispatcher Message form.
        /// </summary>
        /// <param name="divisionName">Input:divisionName</param>
        /// <param name="territoryName">Input:territoryName</param>
        /// <param name="entryText">Input:entryText</param>
        /// <param name="removeEntryText">Input:removeEntryText</param>
        /// <param name="okButton">Input:okButton</param>
        /// <param name="apply">Input:apply</param>
        /// <param name="closeForms">Input:closeForms</param>
        [UserCodeMethod]
        public static void NS_CreateDispathcherMessageForEntryTextAndRemoveEntryText(string divisionName, string territoryName, string entryText, string removeEntryText, bool okButton, bool apply , bool closeForms)
        {
        	//Exit function if one of the variables isn't populated
        	if (territoryName == "" || divisionName == "")
        	{
        		return;
        	}
        	Miscellaneousrepo.Division= divisionName;
        	Miscellaneousrepo.Territory= territoryName;
        	NS_OpenDispathcherMessageForm_MiscellaneousMenu();
        	string currentDivision = Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuItem.GetAttributeValue<string>("SelectedItemText");
        	if(currentDivision != Miscellaneousrepo.Division)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuItemInfo,
        		                                          Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);
        		Miscellaneousrepo.Dispatcher_Messages.Division.DivisionMenuList.DivisionListItemByDivisionName.Click();
        	}
        	string currentTerritory = Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuItem.GetAttributeValue<string>("SelectedItemText");
        	if(currentTerritory != Miscellaneousrepo.Territory)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuItemInfo,
        		                                         Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuList.DispatchTerritoryItemByTerritoryNameInfo);
        		Miscellaneousrepo.Dispatcher_Messages.DispatchTerritory.DispatchTerritoryMenuList.DispatchTerritoryItemByTerritoryName.Click();
        	}
        	if(entryText != "")
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.DispatcherMessageTextInfo,Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
        		Miscellaneousrepo.Dispatcher_Messages.DispatcherMessageText.Element.SetAttributeValue("text", entryText);
        	}
        	if(removeEntryText != "")
        	{
        		Miscellaneousrepo.Dispatcher_Messages.DispatcherMessageText.Element.SetAttributeValue("text", "");
        	}
        	if(apply)
        	{
        		GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Dispatcher_Messages.ApplyButtonInfo,
        		                                          Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
        	}
        	if(okButton)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.OkButtonInfo,
        		                                                  Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
        	}
        	if(closeForms)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Dispatcher_Messages.CancelButtonInfo,
        		                                                  Miscellaneousrepo.Dispatcher_Messages.SelfInfo);
        	}
        	return;
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
        public static void OpenHelperOperations_MainMenu()
        {
        	if(!Miscellaneousrepo.Helper_Operations.SelfInfo.Exists(0))
        	{
        	if(MainMenurepo.PDS_Main_Menu.SelfInfo.Exists(0))
        	{
        		MainMenurepo.PDS_Main_Menu.Self.Activate();
        	}
        	else
        	{
        		Report.Failure("Main menu does not exist");
        	}
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.MiscellaneousButtonInfo,
        	                                          MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.HelperOperationsInfo);
        	GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MiscellaneousMenu.HelperOperationsInfo,
        	                                          Miscellaneousrepo.Helper_Operations.SelfInfo);
        	}
        	else
        	{
        		Report.Info("Helper operations form already exists");
        	}
        }
        [UserCodeMethod]
        public static void AddHelperOperations(string division, string assistedTrainseed, string originOpsta, string destOpsta,
                                               string originPass, string destPass, string helperTrain1Seed, string helperTrain2Seed,
                                               string helperTrain3Seed, string expectedFeedback, bool apply, bool reset, bool closeForm)
        {
        	OpenHelperOperations_MainMenu();
        	Miscellaneousrepo.Division=division;
        	GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Helper_Operations.Division.DivisionMenuItemInfo,
        	                                          Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);
        	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo,
        	                                          Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);
        	if(!assistedTrainseed.Equals(""))
        	{
        		string assistedTrainId=PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(assistedTrainseed);
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.AssistedTrain,
        		                                              assistedTrainId,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!originOpsta.Equals(""))
        	{
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.AssistedTrainOpStaName,
        		                                              originOpsta,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!originPass.Equals(""))
        	{
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.AssistedTrainPassCount,
        		                                              originPass,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!destOpsta.Equals(""))
        	{
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.CutInOpStaName,
        		                                              destOpsta,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!destPass.Equals(""))
        	{
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.CutInPassCount,
        		                                              destPass,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!helperTrain1Seed.Equals(""))
        	{
        		string helperTrain1Id=PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(helperTrain1Seed);
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.HelperTrain1,
        		                                              helperTrain1Id,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!helperTrain2Seed.Equals(""))
        	{
        		string helperTrain2Id=PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(helperTrain2Seed);
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.HelperTrain2,
        		                                              helperTrain2Id,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(!helperTrain3Seed.Equals(""))
        	{
        		string helperTrain3Id=PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(helperTrain3Seed);
        		GeneralUtilities.clickAndFillCellWithValidate(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsInputTable.HelperTrain3,
        		                                              helperTrain3Id,false);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(apply)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Helper_Operations.ApplyButtonInfo,
        		                                                      Miscellaneousrepo.Helper_Operations.ApplyButtonInfo);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
        	if(reset)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Helper_Operations.RefreshButtonInfo,
        		                                                      Miscellaneousrepo.Helper_Operations.RefreshButtonInfo);
        	}
        	if(closeForm)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Helper_Operations.CancelButtonInfo,
        		                                                      Miscellaneousrepo.Helper_Operations.CancelButtonInfo);
        	}
        }
        [UserCodeMethod]
        public static void DeleteHelperOperations(string division, string assistedTrainseed, string expectedFeedback, bool apply, bool reset, bool closeForm)
        {
        	OpenHelperOperations_MainMenu();
        	Miscellaneousrepo.Division=division;
        	GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Helper_Operations.Division.DivisionMenuItemInfo,
        	                                          Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo);
        	GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.DivisionListItemByDivisionNameInfo,
        	                                                  Miscellaneousrepo.Helper_Operations.Division.DivisionMenuList.SelfInfo);
        	int rowCount=0;
        	bool rowFound=false;
        	if(rowCount<1)
        	{
        		GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Helper_Operations.CancelButtonInfo,
        		                                                      Miscellaneousrepo.Helper_Operations.CancelButtonInfo);
        		Ranorex.Report.Failure("No records found");
        		return;
        	}
        	if(!assistedTrainseed.Equals(""))
        	{
        		for(int i=0;i<rowCount;i++)
        		{
        			string assistedTrainId=PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(assistedTrainseed);
        			if(!assistedTrainId.Equals(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsOutputTable.HelperOperationsRowbyIndex.AssistedTrainInfo))
        			{
        				rowFound=true;
        				Miscellaneousrepo.HelperOperationsIndex=i.ToString();
        				break;
        			}
        		}
        		if(!rowFound)
        		{
        			GeneralUtilities.LeftClickAndWaitForDisabledWithRetry(Miscellaneousrepo.Helper_Operations.CancelButtonInfo,
        			                                                      Miscellaneousrepo.Helper_Operations.CancelButtonInfo);
        			Ranorex.Report.Failure("Expected row not found");
        			return;
        		}

        		GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsOutputTable.HelperOperationsRowbyIndex.MenuCellInfo,
        		                                              Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsOutputTable.MenuCellMenu.SelfInfo);
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsOutputTable.MenuCellMenu.DeleteRowInfo,
        		                                                  Miscellaneousrepo.Helper_Operations.HelperOperationsTable.HelperOperationsOutputTable.MenuCellMenu.SelfInfo);
        		if(Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text") != "")
        		{
        			string actualFeedback = Miscellaneousrepo.Helper_Operations.Feedback.GetAttributeValue<string>("Text").Trim();
        			if(actualFeedback.Equals(expectedFeedback))
        			{
        				Ranorex.Report.Success("Actual Feedback expected to be " +expectedFeedback+ " and found as " +actualFeedback+ "");
        			}
        			else
        			{
        				Ranorex.Report.Failure("Actual Feedback expected to be " +expectedFeedback+ " but found as " +actualFeedback+ "");
        			}
        		}
        	}
		}
    }
}
