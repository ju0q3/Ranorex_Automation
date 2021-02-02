/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/27/2018
 * Time: 9:21 AM
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
using Oracle.Code_Utils;
namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_TrainClearance
    {
        public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static global::PDS_NS.TrainClearance_Repo TrainClearancerepo = global::PDS_NS.TrainClearance_Repo.Instance;
        public static global::PDS_NS.MainMenu_Repo MainMenurepo = global::PDS_NS.MainMenu_Repo.Instance;
        
        /// <summary>
        /// Opens Trainsheet via the mainmenu and clicks the Train Clearance button, if it is not open
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        [UserCodeMethod]
        public static void NS_OpenTrainClearance_Trainsheet(string trainSeed)
        {
            if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                NS_Trainsheet.NS_OpenTrainsheet_MainMenu(trainSeed);
                GeneralUtilities.LeftClickAndWaitForWithRetry(Trainsrepo.Train_Sheet.CurrentConsistSummary.TrainClearanceButtonInfo, TrainClearancerepo.Train_Clearance.SelfInfo);

                if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to open Train Clearance form from Trainsheet for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
                }
            }
            return;
        }
        
        /// <summary>
        /// Opens train clearance form via the mainmenu and by clicking To Train button in Train clearance tab, if it is not open
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTrainClearance_ToTrain_MainMenu(string trainSeed)
        {
            if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainClearanceButtonInfo,
                                                          MainMenurepo.PDS_Main_Menu.TrainClearanceMenu.SelfInfo);
                
                GeneralUtilities.ClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.TrainClearanceMenu.ToTrainInfo,
                                                          TrainClearancerepo.Train_Clearance.SelfInfo);
                
                if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Unable to open Train Clearance form");
                    return;
                }
            }
            
            if (trainSeed != "")
            {
                string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
                if (trainId == null)
                {
                    trainId = trainSeed;
                }
                
                if (!TrainClearancerepo.Train_Clearance.TrainIDText.TextValue.Equals(trainId))
                {
                    if (!TrainClearancerepo.Train_Clearance.TrainIDText.Enabled)
                    {
                        GeneralUtilities.ClickAndWaitForDisabledWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.ResetButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.TrainClearance.ResetButtonInfo);
                    }
                    TrainClearancerepo.Train_Clearance.TrainIDText.Element.SetAttributeValue("Text", trainId);
                    TrainClearancerepo.Train_Clearance.TrainIDText.PressKeys("{TAB}");
                    
                    int retries = 0;
                    while(!TrainClearancerepo.Train_Clearance.TrainIDText.Enabled && retries < 3)
                    {
                        Ranorex.Delay.Milliseconds(500);
                        retries++;
                    }
                }
            }
            return;
        }

        [UserCodeMethod]
        public static void NS_TrainClearanceForm_ValidateFeedbackExists(string trainSeed,string openFrom, bool validateFeedbackExists = true)
        {
            Report.Info("Validating whether feedback appears on attempt to issue train clearance to train with seed: " + trainSeed);
            
            if (!TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
            	//Train Clearance Form can be open from trainsheet or directly from Train Clearance Menu.
            	switch(openFrom.ToLower())
            	{
            			case "trainclearance" :NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
            			break;
            			
            			case "trainsheet" : NS_OpenTrainClearance_Trainsheet(trainSeed);
            			break;
            			
            			default : Ranorex.Report.Info("Invalid Selection");
            			break;
            	}
            }
            int retries =0;
            while(TrainClearancerepo.Train_Clearance.Feedback.GetAttributeValue<string>("Text").Equals("") && retries < 3)
            {
            	Ranorex.Delay.Milliseconds(500);
            	retries++;
            }
            string feedback = TrainClearancerepo.Train_Clearance.Feedback.GetAttributeValue<string>("Text");
            Report.Info("Validation", string.Format("Feedback message: '{0}'", feedback));

            bool feedbackExists = !string.IsNullOrEmpty(feedback.Trim());

            string feedbackMessage = string.Format(
                "Train clearance feedback expected '{0}' and feedback actual '{1}'",
                validateFeedbackExists.ToString(), feedbackExists.ToString()
               );

            if (feedbackExists == validateFeedbackExists)
            {
                Report.Success("Validation", feedbackMessage);
            } else {
                Report.Screenshot(TrainClearancerepo.Train_Clearance.Self);
                Report.Failure("Validation", feedbackMessage);
            }

            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo,
                TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo
               );
        }
        
        [UserCodeMethod]
        public static void NS_OpenTrainClearancePrintDialog_TrainsheetSummary(string trainSeed)
        {
            // TODO: Check if already open
            NS_OpenTrainClearance_Trainsheet(trainSeed);
            
            GeneralUtilities.ClickAndWaitForWithRetry(
                TrainClearancerepo.Train_Clearance.TrainClearance.PrintButtonInfo,
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo
               );
        }
        
        [UserCodeMethod]
        public static void NS_PrintFax_PrintDialog_TrainClearance(string trainSeed, string name, string address, int quantity, string printType)
        {
            NS_OpenTrainClearancePrintDialog_TrainsheetSummary(trainSeed);
            
            GeneralUtilities.ClickAndWaitForWithRetry(
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.AdhocButtonInfo,
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo
               );
            
            TrainClearancerepo.RecipientIndex = "0";
            
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.Click();
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.PressKeys(name);
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.Click();
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.PressKeys(address);
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.Click();
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.PressKeys(quantity.ToString());
            
            GeneralUtilities.ClickAndWaitForWithRetry(
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.SelfInfo,
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.SelfInfo
               );
            
            switch (printType.ToLower())
            {
                case "printer":
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Printer.Click();
                    break;
                case "fax":
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Fax.Click();
                    break;
                case "email":
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Email.Click();
                    break;
                case "pager":
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Pager.Click();
                    break;
                default:
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.blank.Click();
                    break;
            }
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.IssueButtonInfo,
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo
               );
            
            // Give the form a moment to close before declaring a failure.
            int iteration = 0;
            while (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && iteration < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                if (!TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    break;
                }
                iteration++;
            }
            
            // If the PDS Print/Fix Dialog fails to close, this represents a de-facto failure in creating a PrintFax message.
            // This also necessitates an additional step to close the form manually, so that this does not lead to a cascading failure.
            bool isFailure = false;
            if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
                    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo
                   );
                
                isFailure = true;
            }
            
            // Close train clearance form.
            // TODO: Ensure the correct train clearance form is closed?
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                TrainClearancerepo.Train_Clearance.SelfInfo
               );
            
            if (isFailure)
            {
                Ranorex.Report.Error("Print form was not successfully closed, and no PrintFax MIS message was sent.");
            } else {
                Ranorex.Report.Success("Print form successfully completed.");
            }
        }
        
        /// <summary>
        /// Opens Train clearance summary list via the mainmenu if it is not open.
        /// </summary>
        [UserCodeMethod]
        public static void NS_OpenTrainClearanceSummaryList()
        {
            if (!TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo.Exists(0))
            {
                GeneralUtilities.LeftClickAndWaitForWithRetry(MainMenurepo.PDS_Main_Menu.MainMenuBar.TrainClearanceButtonInfo, MainMenurepo.PDS_Main_Menu.TrainClearanceMenu.SelfInfo);
                MainMenurepo.PDS_Main_Menu.TrainClearanceMenu.SummaryList.Click();
                if (!TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo.Exists(0))
                {
                    Ranorex.Report.Error("Failed to Open Train Clearance Summary List");
                }
                
                //After it exists, wait for values to start propogating
                int retries = 0;
                int trainClearanceRows = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count;
                bool finished = false;
                while (!finished && retries < 5)
                {

                    if (TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count == 0)
                    {
                        Ranorex.Delay.Seconds(1);
                        retries++;
                        continue;
                    }

                    if (TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count != trainClearanceRows)
                    {
                        Ranorex.Delay.Seconds(1);
                        trainClearanceRows = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count;
                        continue;
                    }

                    finished = true;
                }
            }
            
            TrainClearancerepo.Train_Clearance_Summary_List.Self.Activate();
            return;
        }
        
        [UserCodeMethod]
        public static void NS_TrainClearance_MakeCurrent_TrainClearanceSummaryList(string trainSeed, string crewOrigin, string crewDestination)
        {
            NS_OpenTrainClearanceSummaryList();
            string trainId = NS_TrainID.GetTrainId(trainSeed);
            
            var summaryListTable = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable;
            
            string makeCurrent = "Make Current";
            TrainClearancerepo.MenuItemName = makeCurrent;
            
            string trainIdValue;
            string crewOriginValue;
            string crewDestinationValue;
            string statusValue = "";
            
            int rowCount = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count;
            bool recordFound = false;
            for (int i = 0; i < rowCount; i++)
            {
                TrainClearancerepo.RowIndex = i.ToString();
                trainIdValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainId);
                crewOriginValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.CrewOriginPassCount);
                crewDestinationValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.CrewDestinationPassCount);
                statusValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.Status);
                
                if (trainIdValue.Equals(trainId) && crewOriginValue.Contains(crewOrigin) && crewDestinationValue.Contains(crewDestination) && statusValue.Equals(""))
                {
                    TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.Self.EnsureVisible();
                    GeneralUtilities.RightClickAndWaitForWithRetry(
                        TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.MenuCellInfo,
                        TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.SelfInfo
                       );
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(
                        TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.MenuItemByNameInfo,
                        TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.SelfInfo
                       );
                    
                    // Verify that the status of train clearance shows as 'CURRENT' in summary list.
                    Delay.Milliseconds(500);
                    statusValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.Status);

                    // Substantial lag could lead to a delay in the UI form updating.
                    int retries = 0;
                    while (!statusValue.Equals("CURRENT") && retries < 8)
                    {
                        statusValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.Status);
                        Delay.Milliseconds(500);
                        retries++;
                    }
                    
                    if (statusValue.Equals("CURRENT"))
                    {
                        recordFound = true;
                        break;
                    }
                    
                }
            }
            
            if (recordFound && statusValue.Equals("CURRENT"))
            {
                Report.Success(String.Format("Train Clearance for train '{0}' made current from '{1}' to '{2}'", trainId, crewOrigin, crewDestination));
            } else {
                Report.Failure(String.Format("No Train Clearance found for train '{0}' from '{1}' to '{2}'", trainId, crewOrigin, crewDestination));
            }
        }
        
        
		/// <summary>
		/// Issues a Train Clearance for a train via the first selection in the Distribution List
		/// </summary>
		/// <param name="trainSeed">Input:trainSeed</param>
		/// <param name="closeForms">Input:Closes Trainsheet form after issuing train clearance</param>
		[UserCodeMethod]
		public static void NS_IssueTrainClearanceIfDoesntExist_Trainsheet(string trainSeed, bool closeForms)
		{
			NS_OpenTrainClearance_Trainsheet(trainSeed);
			
			//Wait for Print Fax dialog to appear
			int retries = 0;
			while (!TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && retries < 2)
			{
			    Ranorex.Delay.Milliseconds(500);
			    retries++;
			}
			
			if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
			{
			    //Issue new Train Clearance
    			TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameText.Click();
    			TrainClearancerepo.NameIndex = "0";
    			TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndex.Click();
    			
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButtonInfo, TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    			
    			if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
    			{
    				Ranorex.Report.Error("Unable to issue Train Clearance for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
    				Ranorex.Report.Screenshot();
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Success("Train Clearance issue successful for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
    				//If this is hit too fast, Ranorex will not open the train clearance. As if it believes the train clearance is still open. Maybe a caching issue?
    				Ranorex.Delay.Seconds(2);
    				NS_OpenTrainClearance_Trainsheet(trainSeed);
    				
    			}
			}
			
			//Get the current Train Clearance Number
			string trainClearanceText = TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceText.GetAttributeValue<string>("InnerText");
			string[] splitTrainClearanceText = trainClearanceText.Split(' ');
			retries = 0;
			//Sometimes it takes longer to load the number
			while (splitTrainClearanceText.Length <= 6 && retries < 3)
			{
			    Ranorex.Delay.Milliseconds(500);
			    trainClearanceText = TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceText.GetAttributeValue<string>("InnerText");
			    splitTrainClearanceText = trainClearanceText.Split(' ');
			    retries++;
			}
			string trainClearanceNumber = splitTrainClearanceText[splitTrainClearanceText.Length - 1];
			int trainClearanceNumberint;
			if (int.TryParse(trainClearanceNumber, out trainClearanceNumberint))
			{
			    PDS_CORE.Code_Utils.NS_TrainID.SetTrainClearanceNumber(trainSeed, trainClearanceNumber);
			} else {
			    Ranorex.Report.Error("Could not get Train Clearance number from form, Train Clearance text found is {" + trainClearanceText + "}.");
			}
			
			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
			
			if (closeForms)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,
				                                                  Trainsrepo.Train_Sheet.SelfInfo);
			}
			return;
		}
        /// <summary>
        /// Issues a Train Clearance for a train via the first selection in the Distribution List
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="closeForms">Input:Closes Trainsheet form after issuing train clearance</param>
        [UserCodeMethod]
        public static void NS_IssueBasicTrainClearance_Trainsheet(string trainSeed, bool closeForms)
        {
            NS_OpenTrainClearance_Trainsheet(trainSeed);
            
            try
            {
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.WaitForExists(10000);
            }
            catch (RanorexException)
            {
                Ranorex.Report.Error("No Print Fax Dialog appeared on train clearance, probably already has a train clearance");
                Ranorex.Report.Screenshot();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo, Trainsrepo.Train_Sheet.SelfInfo);
                }
                return;
            }
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameText.Click();
            TrainClearancerepo.NameIndex = "0";
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndex.Click();
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButtonInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
            
            if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Unable to issue Train Clearance for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
                Ranorex.Report.Screenshot();
            }
            else
            {
                Ranorex.Report.Success("Train Clearance issue successful for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
            }
            
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.CancelButtonInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Removes a Train Clearance for a train via the Train Clearance Summary List
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="closeForms">Input:Closes Summary List form after issuing train clearance</param>
        [UserCodeMethod]
        public static void NS_DisassociateTrainClearance_TrainClearanceSummaryList(string trainSeed, bool closeForms)
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
            NS_OpenTrainClearanceSummaryList();
            
            TrainClearancerepo.TrainId = trainId;
            if (!TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainId.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("No train clearances found for train {" + trainId + "}.");
                Ranorex.Report.Screenshot();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                }
                return;
            }
            while (TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainId.SelfInfo.Exists(0))
            {
                string rowIndex = Convert.ToString(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainId.Self.GetAttributeValue<int>("Index"));
                TrainClearancerepo.RowIndex = rowIndex;
                string trainClearanceNumber = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainClearanceNumber.GetAttributeValue<string>("Text");
                TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainClearanceNumber.EnsureVisible();
                GeneralUtilities.RightClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.MenuCellInfo, TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.SelfInfo);
                TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.AssociateDisassociateTrain.Click();
                TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociatedTrainsList.AssociatedTrainListItemByTrainId.Click();
                TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.DisassociateButton.Click();
                int retries = 0;
                while (!TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (!TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Enabled)
                {
                    Ranorex.Report.Error("Could not apply train clearance disassociation for train {" + trainId + "} and train clearance number {" + trainClearanceNumber + "}.");
                    Ranorex.Report.Screenshot();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                    }
                    return;
                }
                
                TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Click();
                
                retries = 0;
                while (TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Enabled && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Click();
                    retries++;
                }
                if (TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButton.Enabled)
                {
                    Ranorex.Report.Error("Could not apply train clearance disassociation for train {" + trainId + "} and train clearance number {" + trainClearanceNumber + "}.");
                    Ranorex.Report.Screenshot();
                    if (closeForms)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                    }
                    return;
                }
                
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
                Ranorex.Report.Info("Disassociated Train Clearance {"+trainClearanceNumber+"} from train {"+trainId+"}.");
            }
            
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Issues a second Train Clearance for a train, on the condition that a first train clearance has been made.
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="closeForms">Input:Closes Trainsheet form after issuing train clearance</param>
        /// <param name="crewOrigin">Input:The corresponding crew origin station for the train clearance</param>
        /// <param name="crewDestination">Input:The corresponding crew destination station for the train clearance</param>
        [UserCodeMethod]
        public static void NS_IssueTrainClearanceForCrewChange_Trainsheet(string trainSeed, bool closeForms, string crewOrigin, string crewDestination, string expectedFeedback)
        {
            int retries;
            
            NS_OpenTrainClearance_Trainsheet(trainSeed);
            
            GeneralUtilities.LeftClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.ChangeRouteButtonInfo, TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IssueNewCheckboxInfo);
            
            Ranorex.Text crewOriginText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText;
            Ranorex.Text crewDestinationText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText;

            populateTextField(crewOriginText, crewOrigin);
            populateTextField(crewDestinationText, crewDestination);
            
            TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IssueNewCheckbox.Check();
            
//            GeneralUtilities.LeftClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.OkButtonInfo, TrainClearancerepo.Train_Clearance.Confirm_Message.CreateTaskButtonInfo);
            GeneralUtilities.LeftClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.OkButtonInfo,TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
        	
            if(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
            {
            	string feedbackText =TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text");
            	if(!feedbackText.Equals(""))
            	{
            		if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
            		{
            			if (closeForms)
            			{
            				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
            				                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            			}
            			return;
            		}
            	}
            	
            }
            
        	
            GeneralUtilities.LeftClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.Confirm_Message.CreateTaskButtonInfo, TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButtonInfo);
            
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameText.Click();
            TrainClearancerepo.NameIndex = "0";
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndex.Click();
            
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButton.Click();
            
            retries = 0;
            while (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButton.Click();
                retries++;
            }
            
            if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Unable to issue Train Clearance for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
            }
            
            if (closeForms)
            {
                Trainsrepo.Train_Sheet.CancelButton.Click();
                retries = 0;
                while (Trainsrepo.Train_Sheet.SelfInfo.Exists(0) && retries < 3)
                {
                    Ranorex.Delay.Milliseconds(500);
                    retries++;
                }
                if (Trainsrepo.Train_Sheet.SelfInfo.Exists(0))
                {
                    Trainsrepo.Train_Sheet.CancelButton.Click();
                }
            }
        }

        // testing the utility of these wrappers
        private static string getCellContents(Ranorex.Cell aRepoPath)
        {
            string cellContents = aRepoPath.GetAttributeValue<string>("text");
            return cellContents;
        }

        private static void populateTextField(Ranorex.Text aTextField, string inputText)
        {
            aTextField.Element.SetAttributeValue("Text", inputText);
            aTextField.PressKeys("{TAB}");

            int retries = 0;
            while ((aTextField.GetAttributeValue<string>("Text") != inputText) && retries < 10)
            {
                Ranorex.Delay.Milliseconds(500);
                aTextField.Element.SetAttributeValue("Text", inputText);
                aTextField.PressKeys("{TAB}");
                retries++;
            }

            if (aTextField.GetAttributeValue<string>("Text") == inputText)
            {
                Report.Success("Field populated with the input: " + inputText);
            } else {
                Report.Error(String.Format("The input '{0}' was not populated successfully", inputText));
            }
        }
        
        [UserCodeMethod]
        public static void NS_AssociateTrainClearance_TrainClearanceSummaryList(string trainSeed, bool closeForms, string associateDifferentTrainSeed)
        {
            string trainClearanceNumber = "";
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
            
            if(associateDifferentTrainSeed == "")
            {
            	Ranorex.Report.Error("TrainSeed to associate is not present, please check data bindings.");
            	return;
            }
            
            if(trainId == null)
            {
                Report.Failure("No train found with train Seed :{"+trainSeed+"}");
                //closeForm
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                return;
            }
            
            trainClearanceNumber = NS_TrainID.GetTrainClearanceNumber(trainSeed);
        	if (trainClearanceNumber == null)
        	{
            	trainClearanceNumber = ADMSEnvironment.GetTrainClearanceNumber(NS_TrainID.GetTrainId(trainSeed));
        	}
            
            NS_OpenTrainClearanceSummaryList();
            TrainClearancerepo.TrainId = trainId;
            TrainClearancerepo.TrainClearanceNumber = trainClearanceNumber;
            if (!TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("No train clearances found for train {" + trainId + "}.");
                Ranorex.Report.Screenshot();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                }
                return;
            }
            if (TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.SelfInfo.Exists(0))
            {
                string rowIndex = Convert.ToString(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.Self.GetAttributeValue<int>("Index"));
                TrainClearancerepo.RowIndex = rowIndex;
                TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainClearanceNumber.EnsureVisible();
                
                GeneralUtilities.RightClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.MenuCellInfo,
                                                               TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.SelfInfo);

                GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.AssociateDisassociateTrainInfo,
                                                          TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
                
	            trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(associateDifferentTrainSeed);
	            if (trainId == null)
	            {
	                TrainClearancerepo.TrainId = associateDifferentTrainSeed;
	            }
	            else
	            {
	                TrainClearancerepo.TrainId = trainId;
	            }
	            
	            if (TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.UnassociatedTrainsList.UnassociatedTrainListItemByTrainIdInfo.Exists(0))
	            {
	                GeneralUtilities.ClickAndWaitForEnabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.UnassociatedTrainsList.UnassociatedTrainListItemByTrainIdInfo,
	                                                                 TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociateButtonInfo);
	                
	                GeneralUtilities.ClickAndWaitForEnabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociateButtonInfo,
	                                                                 TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo);
	
	                
	                GeneralUtilities.ClickAndWaitForDisabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo,
	                                                                  TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo);
	                Ranorex.Report.Info("association Train Clearance {"+trainClearanceNumber+"} from train {"+trainId+"}.");
	            } else if (TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociatedTrainsList.AssociatedTrainListItemByTrainIdInfo.Exists(0))
	            {
	            	Ranorex.Report.Info("Train {" + trainId + "} is already associated with train clearance number {"+trainClearanceNumber+"}");
	            } else {
	            	Ranorex.Report.Failure("Train {" + trainId + "} is not in associated, or unassociated list for train clearance number {"+trainClearanceNumber+"}");
	            }
	            
	            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
	            
            } else {
                Ranorex.Report.Failure("Could not find Train Clearance Row by Train Clearance Number");
            }
            
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
            }
            return;
        }
        
        
        
        /// <summary>
        /// Opens the train clearance form from to train , Editis the fiels in train clearance route forms
        /// </summary>
        /// <param name="trainSeed">Input : trainSeed</param>
        /// <param name="crewOriginStation">Input : crewOriginStation</param>
        /// <param name="originPassCount">Input : originPassCount</param>
        /// <param name="intermediateStations">Input : intermediateStations</param>
        /// <param name="crewDestinationStation">Input : crewDestinationStation</param>
        /// <param name="destinationPassCount">Input : destinationPassCount</param>
        /// <param name="issueNew">Input : issueNew</param>
        /// <param name="expectedFeedback">Input : expectedFeedback</param>
        /// <param name="pressOk">Input : pressOk</param>
        /// <param name="closeForm">Input : closeForm</param>
        [UserCodeMethod]
        public static void NS_OpenAndEditTrainClearanceRouteForm_TrainClearanceForm(string trainSeed, string crewOriginStation, string originPassCount, string intermediateStations, string crewDestinationStation, string destinationPassCount, bool issueNew, string expectedFeedback, bool pressOk = false, bool closeForm = false)
        {
            NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
            
            if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
            	                                                  TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
            }
            if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Feedback, expectedFeedback))
            {
            	if (closeForm)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
            		                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
            	}
            	return;
            }
            if (!TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.ChangeRouteButtonInfo,
                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            }
            
            if (TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
            {
                if (issueNew != TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IssueNewCheckbox.Checked)
                {
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IssueNewCheckbox.Click();
                }
                
                if(crewOriginStation != TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText.TextValue)
                {
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText.Click();
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText.Element.SetAttributeValue("Text", crewOriginStation);
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText.PressKeys("{TAB}");
                }
                
                if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                    return;
                }
                
                if(originPassCount != TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationPassCountText.TextValue)
                {
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationPassCountText.Click();
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationPassCountText.Element.SetAttributeValue("Text", originPassCount);
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationPassCountText.PressKeys("{TAB}");
                }
                
                if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                    return;
                }
                
                string[] stations = intermediateStations.Split('|');
                int totalRows = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.Self.Rows.Count;
                TrainClearancerepo.IntermediateStationsIndex = "0";
                TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.IntermediateStationsRowByIndex.IntermediateStationText.Click();
                for(int i = 0; i < totalRows; i++)
                {
                    TrainClearancerepo.IntermediateStationsIndex = i.ToString();
                    if (i <= stations.Length)
                    {
                        if (TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.IntermediateStationsRowByIndex.IntermediateStationText.Text != stations[i])
                        {
                            TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.IntermediateStationsRowByIndex.IntermediateStationText.PressKeys(stations[i]);
                        }
                    } else {
                        TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.IntermediateStationsRowByIndex.IntermediateStationText.PressKeys("{BACK}");
                        
                    }
                    
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.IntermediateStationsTable.IntermediateStationsRowByIndex.IntermediateStationText.PressKeys("{TAB}");
                }
                
                if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                    return;
                }
                
                
                if(crewDestinationStation != TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText.TextValue)
                {
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText.Click();
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText.Element.SetAttributeValue("Text" ,crewDestinationStation);
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText.PressKeys("{TAB}");
                }
                
                if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                }
                
                if(destinationPassCount != TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationPassCountText.TextValue)
                {
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationPassCountText.Click();
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationPassCountText.Element.SetAttributeValue("Text" ,destinationPassCount);
                    TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationPassCountText.PressKeys("{TAB}");
                }
                
                if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                {
                    if (closeForm)
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                    return;
                }
                
                if(pressOk)
                {
                	TrainClearancerepo.Train_Clearance.Train_Clearance_Route.OkButton.Click();
                    Ranorex.Delay.Milliseconds(500);
                    
                    if(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
                    {
                    	if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
                    	{
                    		if (closeForm)
                    		{
                    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                    			                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    		}
                    	} else {
                    		if(!String.IsNullOrEmpty(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text")))
                    		{
                    			Report.Failure("Feedback not as expected");
                    			Report.Screenshot(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Self);
                    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.OkButtonInfo,
                    			                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    		}
                    	}
                    	return;
                    }
                }
                
                if (expectedFeedback != "")
                {
                    Ranorex.Report.Failure("Did not get expected feedback of {" + expectedFeedback + "}.");
                }
                
                if(closeForm)
                {
                    if (TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
                    {
                        GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                          TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                    }
                }
            }
            else
            {
                Ranorex.Report.Screenshot(TrainClearancerepo.Train_Clearance.Self);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
                Ranorex.Report.Error("Train clearance Route form not opened");
                return;
            }
        }
        
        
        /// <summary>
        /// Opens the express create train form from train clearance mainmenu
        /// </summary>
        /// <param name="newTrainSeed"></param>
        /// <param name="templateTrainSeed"></param>
        /// <param name="reset"></param>
        /// <param name="clickOnOk"></param>
        /// <param name="closeForm"></param>
        [UserCodeMethod]
        public static void NS_OpenExpressCreateTrainForm_TrainClearance(string newTrainSeed, bool clickOnYes = true, bool validateFormExists = true, bool closeForm = false)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(newTrainSeed);
            if (trainId == null)
            {
                NS_TrainID.CreateTrainID(newTrainSeed);
            }
            NS_OpenTrainClearance_ToTrain_MainMenu(newTrainSeed);
            
            int retries = 0;
            while(!TrainClearancerepo.Train_Clearance.No_Train_Schedule.SelfInfo.Exists(0) && !TrainClearancerepo.Train_Clearance.Train_Not_Active.SelfInfo.Exists(0)&& retries < 5)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            
            if(TrainClearancerepo.Train_Clearance.No_Train_Schedule.SelfInfo.Exists(0))
            {
                if(clickOnYes)
                {
                    int attempts = 0;
                    TrainClearancerepo.Train_Clearance.No_Train_Schedule.YesButton.Click();
                    while(!Trainsrepo.Express_Create_Train.SelfInfo.Exists(0) && attempts < 3)
                    {
                        TrainClearancerepo.Train_Clearance.No_Train_Schedule.YesButton.Click();
                        Ranorex.Delay.Milliseconds(500);
                        attempts++;
                    }
                    
                    if(!Trainsrepo.Express_Create_Train.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Unable to Open the form to create train");
                        return;
                    }
                    
                    if(validateFormExists)
                    {
                        if(Trainsrepo.Express_Create_Train.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Success("Express create train form exists");
                        }
                        else
                        {
                            Ranorex.Report.Failure("Express create train form does not exists");
                        }
                    }
                }
                else
                {
                    //Pressing on No button will open Train clearence route form
                    GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.No_Train_Schedule.NoButtonInfo,
                                                              TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                }
            }
            else if(TrainClearancerepo.Train_Clearance.Train_Not_Active.SelfInfo.Exists(0))
            {
                

                if(clickOnYes)
                {
                    
                    int attempts = 0;
                    TrainClearancerepo.Train_Clearance.Train_Not_Active.YesButton.Click();
                    while(!Trainsrepo.Create_Train.SelfInfo.Exists(0) && attempts < 3)
                    {
                        TrainClearancerepo.Train_Clearance.Train_Not_Active.YesButton.Click();
                        Ranorex.Delay.Milliseconds(500);
                        attempts++;
                    }
                    
                    if(!Trainsrepo.Create_Train.SelfInfo.Exists(0))
                    {
                        Ranorex.Report.Error("Unable to Open the form to create train");
                        return;
                    }
                    
                    if(validateFormExists)
                    {
                        if(Trainsrepo.Create_Train.SelfInfo.Exists(0))
                        {
                            Ranorex.Report.Success("Create train form exists");
                        }
                        else
                        {
                            Ranorex.Report.Failure("Create train form does not exists");
                        }
                    }
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.Train_Not_Active.NoButtonInfo,
                                                              TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
                    
                }
            }
            else
            {
                Ranorex.Report.Failure("No forms appeared");
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
            }
            
            if(closeForm)
            {
                if (TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                }
                else if(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.SelfInfo);
                }
            }
        }
        
        
        /// <summary>
    	/// Validates the status of Train clearance in TC summary list. 
    	/// </summary>
    	/// <param name="trainSeed"></param>
    	/// <param name="crewOrigin"></param>
    	/// <param name="crewDestination"></param>
    	/// <param name="reqStatus"></param>
    	/// <param name="closeForm"></param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainClearanceStatus_TrainClearanceSummaryList(string trainSeed, string crewOrigin, string crewDestination, string reqStatus, bool closeForm = true)
    	{
    		NS_OpenTrainClearanceSummaryList();
        	string trainId = NS_TrainID.GetTrainId(trainSeed);
        	if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
        	
        	string trainIdValue;
        	string crewOriginValue;
        	string crewDestinationValue;
        	string statusValue = "";
        	
        	int rowCount = TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count;
        	bool recordFound = false;
        	for (int i = 0; i < rowCount; i++)
        	{
        		TrainClearancerepo.RowIndex = i.ToString();
        		trainIdValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainId);
        		crewOriginValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.CrewOriginPassCount);
        		crewDestinationValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.CrewDestinationPassCount);
        		statusValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.Status);
        		if (trainIdValue.Equals(trainId) && crewOriginValue.Contains(crewOrigin) && crewDestinationValue.Contains(crewDestination) && statusValue.Equals(reqStatus, StringComparison.OrdinalIgnoreCase))
        		{
        			TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.Self.EnsureVisible();
        			statusValue = getCellContents(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.Status);
        			
        			if (statusValue.Equals(reqStatus, StringComparison.OrdinalIgnoreCase))
        			{
        				recordFound = true;
        				break;
        			}
        			
        		}
        	}
        	
        	if (recordFound && statusValue.Equals(reqStatus, StringComparison.OrdinalIgnoreCase))
            {
                Report.Success(String.Format("Train Clearance Status for train '{0}' is '{1}' from '{2}' to '{3}'", trainId, statusValue, crewOrigin, crewDestination));
            } else {
                Report.Failure(String.Format("No Train Clearance found for train '{0}' from '{1}' to '{2}'", trainId, crewOrigin, crewDestination));
            }
        	
        	if(closeForm)
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo,
        		                                                  TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
        	}
    	}
    	
    	/// <summary>
    	/// Issue Train clearance for train from mentioned crew orgin and destionation.
    	/// </summary>
    	/// <param name="trainSeed"></param>
    	/// <param name="crewOrigin"></param>
    	/// <param name="crewDestination"></param>
    	/// <param name="expectedFeedback"></param>
    	/// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_IssueTrainClearanceForChangeRoute_TrainClearanceForm(string trainSeed,string crewOrigin, string originPasscount, string crewDestination, string destPasscount, string expectedFeedback, bool closeForms)
        {
        	NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
        	
        	if(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
        	{
        		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
        		                                                  TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
        	}

            GeneralUtilities.LeftClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.ChangeRouteButtonInfo, TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            
            Ranorex.Text crewOriginText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationText;
            Ranorex.Text crewDestinationText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationText;
            Ranorex.Text crewOriginPassCountText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewOriginStationPassCountText;
            Ranorex.Text crewDestinationPassCountText = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CrewDestinationStationPassCountText;

            populateTextField(crewOriginText, crewOrigin);
            populateTextField(crewDestinationText, crewDestination);
            populateTextField(crewOriginPassCountText, originPasscount);
            populateTextField(crewDestinationPassCountText, destPasscount);
            int retries=0;
            while(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0) && retries<3)
            {
            	TrainClearancerepo.Train_Clearance.Train_Clearance_Route.OkButton.Click();
            	Delay.Milliseconds(500);
            	retries++;
            }
        	
            if(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0) && !TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text").Equals(""))
            {
            	string feedbackText =TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text");

            	if (!NS_Bulletin.CheckFeedback(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback, expectedFeedback))
            	{
            		if (closeForms)
            		{
            			GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
            			                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            		}
            		return;
            	}
            }
            else if (TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0) && TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text").Equals(""))
            {
            	Ranorex.Report.Error("Train clearnance change route form is still open");
            	Ranorex.Report.Screenshot();
            	if (closeForms)
            	{
            		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
            		                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            	}
            	return;
            }
            

            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameText.Click();
            TrainClearancerepo.NameIndex = "0";
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndex.Click();
            
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButton.Click();
            
            retries = 0;
            while (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButton.Click();
                retries++;
            }
            if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Unable to issue Train Clearance for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
                TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButton.Click();
            }
            else
            {
            	Ranorex.Report.Success("Train Clearance has been issues successfully for Train {"+trainSeed+"} from {"+crewOrigin+"} to {"+crewDestination+"}");
            }
            
            if (closeForms)
            {
                if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                	                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
                }
            }
        }
        
        [UserCodeMethod]
        public static void NS_IssueTrainClearance__ToTrain_TrainClearanceForm(string trainSeed, bool closeForms)
        {
        	NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
			
        	int attempts=0;
        	while(!TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && attempts <3)
        	{
        		Ranorex.Delay.Milliseconds(500);
                attempts++;
        	}
            
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameText.Click();
            TrainClearancerepo.NameIndex = "0";
            TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndex.Click();
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.IssueButtonInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
            
            if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Unable to issue Train Clearance for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
                Ranorex.Report.Screenshot();
            }
            else
            {
                Ranorex.Report.Success("Train Clearance issue successful for train {"+PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed)+"}");
            }
            
            if (closeForms)
            {
                if (TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                	                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
                }
            }
        }
    }

    
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_TrainClearance_Validations
    {
        public static global::PDS_NS.Trains_Repo Trainsrepo = global::PDS_NS.Trains_Repo.Instance;
        public static global::PDS_NS.TrainClearance_Repo TrainClearancerepo = global::PDS_NS.TrainClearance_Repo.Instance;
        public static global::PDS_NS.Miscellaneous_Repo Miscellaneousrepo = global::PDS_NS.Miscellaneous_Repo.Instance;
        
        /// <summary>
        /// Validates that a bulletin with a particular bulletin number and limits exist in the Train clearance
        /// </summary>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        /// <param name="closeForm">Whether to close the train clearance form</param>
        [UserCodeMethod]
        public static void NS_ValidateBulletinInTrainClearance_Trainsheet(string trainSeed, string bulletinSeed, bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            NS_TrainClearance.NS_OpenTrainClearance_Trainsheet(trainSeed);
            //First Check if the Bulletin Number exists on the form
            string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            TrainClearancerepo.BulletinNumber = bulletinNumber;
            int retries = 0;
            while (!TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceBulletinItemByBulletinNumber.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(500);
                retries++;
            }
            if (!TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceBulletinItemByBulletinNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("Could not find bulletin with bulletin number {"+bulletinNumber+"} in Train Clearance for train {"+trainId+"}");
                if (closeForm)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
                }
                return;
            }
            
            string foundBulletinLimits = TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceBulletinItemByBulletinNumber.BulletinLimits.GetAttributeValue<string>("InnerText");
            string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
            if (!foundBulletinLimits.Contains(milepost1) && milepost1 != "")
            {
                Ranorex.Report.Failure("Train Clearance bulletin with bulletin number {"+bulletinNumber+"} does not contain limit {"+milepost1+"} for train {"+trainId+"}");
                if (closeForm)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
                }
                return;
            }

            string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
            if (!foundBulletinLimits.Contains(milepost2) && milepost2 != "")
            {
                Ranorex.Report.Failure("Train Clearance bulletin with bulletin number {"+bulletinNumber+"} does not contain limit {"+milepost2+"} for train {"+trainId+"}");
                if (closeForm)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
                }
                return;
            }
            Ranorex.Report.Success("Found bulletin with bulletin number {"+bulletinNumber+"} and limits {"+milepost1+"} and {"+milepost2+"} in train clearance for train {"+trainId+"}");
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
            }
            return;
        }
        /// <summary>
        /// Closes the  Train Clearance Form
        /// </summary>
        [UserCodeMethod]
        public static void NS_CloseTrainClearance_TrainStatusSummary()
        {
            if(TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,TrainClearancerepo.Train_Clearance.SelfInfo);
                Ranorex.Report.Success("Train Clearance Form is closed successfully");
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance form is not opened ");
            }
            return;
            
            
        }
        
        /// <summary>
        /// Validate Bulletin text through train clearance form
        /// </summary>
        /// <param name="bulletinSeed">Input:bulletinSeed</param>
        /// <param name="trainSeed">Input:trainSeed</param>
        /// <param name="closeForm">Whether to close the train clearance and train Sheet form</param>
        [UserCodeMethod]
        public static void NS_ValidateSpeedRestrictionBulletin_TrainClearance(string bulletinSeed, string trainSeed, bool closeForm)
        {
            string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
            if (trainId == null)
            {
                Ranorex.Report.Failure("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            }
            NS_TrainClearance.NS_OpenTrainClearance_Trainsheet(trainSeed);
            
            string bulletinNumber = NS_Bulletin.GetBulletinNumber(bulletinSeed);
            TrainClearancerepo.BulletinNumber = bulletinNumber;
            string milepost1 = NS_Bulletin.GetBulletinMilepost1(bulletinSeed);
            string milepost2 = NS_Bulletin.GetBulletinMilepost2(bulletinSeed);
            string trackLine = NS_Bulletin.GetBulletinTrackLine(bulletinSeed);
            string maximumSpeed = NS_Bulletin.GetBulletinMaximumSpeed(bulletinSeed);
            string foundBulletinText = TrainClearancerepo.Train_Clearance.TrainClearance.TrainClearanceHtml.TrainClearanceBulletinItemByBulletinNumber.BulletinText.GetAttributeValue<string>("InnerText");
            string replacement = Regex.Replace(foundBulletinText, @"\t|\n|\r", "");
            string bulletinText = "From "+milepost1+" to "+milepost2+" on "+trackLine.ToUpper();
            Regex bulletinTextRegex = new Regex(bulletinText);
            if (bulletinTextRegex.IsMatch(replacement))
            {
                if(foundBulletinText.Contains(maximumSpeed))
                {
                    Ranorex.Report.Success("Bulletin Text for Bulletin Clearance:",bulletinText);
                }
            }
            else
            {
                Ranorex.Report.Failure("Train Clearance bulletin text  does not contain {"+bulletinText+"}");
            }
            
            if (closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance.SelfInfo);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(Trainsrepo.Train_Sheet.WindowControls.CloseInfo,Trainsrepo.Train_Sheet.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Validates whether train clearance exists in Train clearance summary list
        /// </summary>
        [UserCodeMethod]
        public static void NS_ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList(bool validateExists, bool closeForm)
        {
            NS_TrainClearance.NS_OpenTrainClearanceSummaryList();
            bool trainClearanceTableExists = (TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self.Rows.Count > 0);
            
            if(trainClearanceTableExists == validateExists)
            {
                Ranorex.Report.Success("Expected and found Train Clearance Table " + (validateExists ? "Exists":"does not Exist"));
                
            }
            else
            {
                Ranorex.Report.Screenshot(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.Self);
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo,
                                                                  TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                Ranorex.Report.Failure("Expected Train Clearance Table " + (validateExists ? "to Exist and it does not.":"to not Exist and it does."));
            }
            
            if(closeForm)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo,
                                                                  TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
            }
        }
        
        /// <summary>
        /// Validates whether Train clearance form is opened or not
        /// </summary>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_ValidateTrainClearanceIssueFormExists(bool closeForms, bool validateExists)
        {
            bool formExists = TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0);
            if (formExists == validateExists)
            {
                Ranorex.Report.Success("Expected and found Train Clearance Issue Form " + (formExists ? "to Exist":"to not Exist"));
            }
            else
            {
                Ranorex.Report.Failure("Expected Train Clearance Issue form " + (validateExists ? "to Exist and found it does not.":"to not Exist and found it does."));
                return;
            }
            
            if(closeForms)
            {
                if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
                    
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.SelfInfo);
                }
                else
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                                                                      TrainClearancerepo.Train_Clearance.SelfInfo);
                }
            }
        }
        
        /// <summary>
        /// Validates the feeback generated in Train clearance route form
        /// </summary>
        /// <param name="expectedFeedback">Input: Expected feedback</param>
        /// <param name="closeForms">Input : True/False</param>
        [UserCodeMethod]
        public static void NS_ValidateFeedback_TrainClearanceRoute_TrainClearanceForm(string expectedFeedback, bool closeForms)
        {
            if (!TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo.Exists(0))
            {
                Ranorex.Report.Error("Train clearance Route form is not opened So cannot read the feedback");
                return;
            }

            string actualfeedback = TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Feedback.GetAttributeValue<string>("Text");
            Ranorex.Report.Info("Feedback:"+actualfeedback);
            
            if (expectedFeedback.Equals(actualfeedback))
            {
                Ranorex.Report.Success("Expected feedback as {"+expectedFeedback+"} and found {"+actualfeedback+"}");
            }
            else
            {
                Ranorex.Report.Screenshot(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.Self);
                //closeForm
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
                Ranorex.Report.Failure("Expected feedback as {"+expectedFeedback+"} and found {"+actualfeedback+"}");
            }
            
            if(closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
                                                                  TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
            }
        }
        
        /// <summary>
        /// Re-Associate to Previous Train Clearance
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="closeForms"></param>
        [UserCodeMethod]
        public static void NS_ReAssociateToPreviousTrainClearance_TrainClearanceSummaryList(string trainSeed, bool closeForms)
        {
            string trainClearanceNumber = "";
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
            
            trainClearanceNumber = ADMSEnvironment.GetPreviousTrainClearanceNumber(NS_TrainID.GetTrainId(trainSeed));
            if (trainClearanceNumber == "")
            {
                Ranorex.Report.Failure("Could not get a previous train clearance number for train with Train ID {" + trainId + "}.");
                return;
            }
            
            NS_TrainClearance.NS_OpenTrainClearanceSummaryList();
            TrainClearancerepo.TrainId = trainId;
            TrainClearancerepo.TrainClearanceNumber = trainClearanceNumber;
            if (!TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.SelfInfo.Exists(0))
            {
                Ranorex.Report.Failure("No train clearances found for train {" + trainId + "}.");
                Ranorex.Report.Screenshot();
                if (closeForms)
                {
                    GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
                }
                return;
            }
            
            string rowIndex = Convert.ToString(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByTrainClearanceNumber.Self.GetAttributeValue<int>("Index"));
            TrainClearancerepo.RowIndex = rowIndex;
            TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.CellByColumnName.TrainClearanceNumber.EnsureVisible();
            
            GeneralUtilities.RightClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.TrainClearanceSummaryRowByRowIndex.MenuCellInfo,
                                                           TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.SelfInfo);

            GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.TrainClearanceSummaryListTable.MenuCellMenu.AssociateDisassociateTrainInfo,
                                                      TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
            
            GeneralUtilities.ClickAndWaitForEnabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.UnassociatedTrainsList.UnassociatedTrainListItemByTrainIdInfo,
                                                             TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociateButtonInfo);
            
            GeneralUtilities.ClickAndWaitForEnabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.AssociateButtonInfo,
                                                             TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo);

            
            GeneralUtilities.ClickAndWaitForDisabledWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo,
                                                              TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.ApplyButtonInfo);
            
            GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.CancelButtonInfo, TrainClearancerepo.Train_Clearance_Summary_List.Associate_Train_For_Train_Clearance.SelfInfo);
            Ranorex.Report.Info("Re association Train Clearance {"+trainClearanceNumber+"} from train {"+trainId+"}.");
            
            if (closeForms)
            {
                GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance_Summary_List.WindowControls.CloseInfo, TrainClearancerepo.Train_Clearance_Summary_List.SelfInfo);
            }
            return;
        }
        
        /// <summary>
        /// Complete the pending train clearance from train seed.
        /// </summary>
        /// <param name="trainSeed"></param>
        /// <param name="closeForm"></param>
		[UserCodeMethod]
		public static void NS_CompletePendingTrainClearance_TaskListForm(string trainSeed, bool closeForm)
		{
			NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();
			int numberOfTasks = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
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
			
			for (int i = 0; i < numberOfTasks; i++)
			{
				Miscellaneousrepo.TaskIndex = i.ToString();
				string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
				if(descriptionText.Contains("has a pending"))
				{
					GeneralUtilities.RightClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.MenuCellInfo,
					                                               Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.SelfInfo);
					
					GeneralUtilities.ClickAndWaitForWithRetry(Miscellaneousrepo.Task_List.Tasks.TasksTable.MenuCellMenu.OpenInfo,
					                                          TrainClearancerepo.Train_Clearance.SelfInfo);
					TrainClearancerepo.Train_Clearance.Self.Activate();
					GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
					                                                  TrainClearancerepo.Train_Clearance.SelfInfo);
					Ranorex.Report.Success("Completed the pending Train Clearnance :{"+descriptionText+"}"); 
					break;
				}
			}
			
			if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
			}
		}
		
		/// <summary>
    	/// Validates whether a task exists or not in the Task List
    	/// </summary>
    	/// <param name="description">Input:Description of the task in the task list</param>
    	/// <param name="trainSeed">Input:Train seed</param>
    	/// <param name="expectedTask">expect Task in task list</param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainClearanceByDescriptionAndTrainID_TaskList(string description, string trainSeed, bool expectedTask, bool closeForm)
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
    		bool taskFound = false;
    		NS_Miscellaneous.NS_OpenTaskListForm_MainMenu();
    		Report.Info(String.Format("Validating task in the TaskList list with status: {0} Train ID(contains): {1}", description, trainId));
    		int taskCount = Miscellaneousrepo.Task_List.Tasks.TasksTable.Self.Rows.Count;
    		for(int i = 0; i < taskCount; i++)
    		{
    			Miscellaneousrepo.TaskIndex = i.ToString();
    			string descriptionText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TaskDescription.Text.ToLower();
    			string trainIDText = Miscellaneousrepo.Task_List.Tasks.TasksTable.TaskRowByIndex.TrainIDEmployeeName.Text.ToLower();
    			if (descriptionText.Contains(description.ToLower()) && trainIDText.Contains(trainId.ToLower()))
    			{
    				taskFound = true;
    				break;
    			}
    			
    		}
    		if(expectedTask == taskFound)
    		{
    		    Ranorex.Report.Success(String.Format("Task " + (!taskFound ? "not " : "") + "found in the tasklist with description: {0} and Train ID: {1}", description, trainId));
    		} else {
    			Ranorex.Report.Failure(String.Format("Task " + (!taskFound ? "not " : "") + "found in the tasklist with description: {0} and Train ID: {1}", description, trainId));
    			Ranorex.Report.Screenshot(Miscellaneousrepo.Task_List.Self);
    		}	
    		
    		if(closeForm)
			{
				GeneralUtilities.ClickAndWaitForNotExistWithRetry(Miscellaneousrepo.Task_List.CloseButtonInfo, Miscellaneousrepo.Task_List.SelfInfo);
			}
    	}
    	
    	/// <summary>
    	///  Send Print Fax TrainsheetSummary from TrainClearanceForm
    	/// </summary>
    	/// <param name="trainSeed"></param>
    	/// <param name="closeForm"></param>
    	[UserCodeMethod]
    	public static void NS_SendTrainsheetSummary_Printfax_TrainClearanceForm(string trainSeed, string printFrom,  string name, string address, int quantity,  bool closeForm = true)
    	{
    		NS_TrainClearance.NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
    		int attempts=0;
    		
    		while(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists() && attempts<=3)
    		{
    			Delay.Milliseconds(500);
    			attempts++;
    		}
    		
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
					                                                  TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    		
    		//Switch tab to TrainSheetSummary and check if Send TrainSheetSummary Button is Enabled
    		GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.TrainClearanceTabs.TrainSheetSummaryInfo,
    		                                          TrainClearancerepo.Train_Clearance.TrainSheetSummary.SendTrainSheetSummaryOnlyButtonInfo);
    		
    		GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.TrainSheetSummary.SendTrainSheetSummaryOnlyButtonInfo,
    		                                          TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    		//Select printer
    		// TODO: other options under adhoc needs to be added.
    		switch(printFrom.ToLower())
    		{
    			case "printfax" :
    				GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameTextInfo,
    				                                          TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    				TrainClearancerepo.NameIndex = "1";
    				GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Name.NameList.NameListItemByIndexInfo,
    				                                          TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    				
    				//Click on ok buttion to Print Fax
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.OkButtonInfo,
    				                                                  TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    				break;
    				
    			case "adhoc" : GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.AdhocButtonInfo,
    				                                                         TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo);
    				
    				TrainClearancerepo.RecipientIndex = "0";
    				
    				//Fill the details in the Recipients Table
    				TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.Click();
				    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Name.PressKeys(name);
				    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.Click();
				    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Address.PressKeys(address);
				    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.Click();
				    TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Quantity.PressKeys(quantity.ToString());
            
    				GeneralUtilities.ClickAndWaitForWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.SelfInfo,
    				                                          TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.SelfInfo);
    				
				    //Select type as printer from dropdown
                  	TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.RecipientsTable.RecipientRowByIndex.Type.TypeList.Printer.Click();
				    
				    
				    //Click Ok
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.IssueButtonInfo,
    				                                          TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.Print_Fax_For_Train_AdHoc_Recipients.SelfInfo);
    				                                          
    				break;
    				
    			default: Ranorex.Report.Info("Invalid selection");
    				break;
    		}
    		
    		// Give the form a moment to close before declaring a failure.
            int retries = 0;
            while (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0) && retries < 3)
            {
                Ranorex.Delay.Milliseconds(250);
                if (!TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
                {
                    break;
                }
                retries++;
            }
            
    		bool isFailure = false;
            if (TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo.Exists(0))
            {
               GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
                    											TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
                
                isFailure = true;
            }
            
            // Close train clearance form.
            if(closeForm)
            {
            	GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
                												TrainClearancerepo.Train_Clearance.SelfInfo);
            	Ranorex.Report.Info("Train clearance form close.");
            }
            
            if (isFailure)
            {
                Ranorex.Report.Error("Print form was not successfully closed, and no PrintFax MIS message was sent.");
            } else {
                Ranorex.Report.Success("Print form successfully completed.");
            }
    	}
    	
    	/// <summary>
    	/// Tries to issue train clearnace for train with no schedule and validates feedback
    	/// </summary>
    	/// <param name="trainSeed"></param>
    	/// <param name="expectedFeedback"></param>
    	/// <param name="closeForm"></param>
    	[UserCodeMethod]
    	public static void NS_ValidateTrainClearanceFeedback_TrainClearanceForm(string trainSeed, string expectedFeedback,  bool closeForm = true)
    	{
    		NS_TrainClearance.NS_OpenTrainClearance_ToTrain_MainMenu(trainSeed);
    		
    		string Actualfeedback = NS_TrainClearance.TrainClearancerepo.Train_Clearance.Feedback.GetAttributeValue<string>("Text").ToString();
    		
    		if(Actualfeedback.Equals(expectedFeedback))
    		{
    			Ranorex.Report.Success("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+Actualfeedback+"} are same");
    		}
    		else
    		{
    			Ranorex.Report.Screenshot(NS_TrainClearance.TrainClearancerepo.Train_Clearance.Self);
    			Ranorex.Report.Failure("Expected feedback:{"+expectedFeedback+"} and Actual feedback:{"+Actualfeedback+"} are not same");
    			return;
    		}
    		GeneralUtilities.ClickAndWaitForWithRetry(NS_TrainClearance.TrainClearancerepo.Train_Clearance.No_Train_Schedule.NoButtonInfo,
    		                                          NS_TrainClearance.TrainClearancerepo.Train_Clearance.Train_Clearance_Route.SelfInfo);
    		if (closeForm)
    		{
    			Ranorex.Report.Info("Closing Train clearnace form ");
    			
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(NS_TrainClearance.TrainClearancerepo.Train_Clearance.Train_Clearance_Route.CancelButtonInfo,
    			                                                  NS_TrainClearance.TrainClearancerepo.Train_Clearance.SelfInfo);
    		}
    		return;
    	}
    	
    	/// <summary>
    	/// Open task list and Cancel's the particular Train clearance based on description and Train ID
    	/// </summary>
    	/// <param name="trainSeed"></param>
    	/// <param name="description"></param>
    	/// <param name="expectedFeedback"></param>
    	/// <param name="expectTrainClearance"></param>
    	/// <param name="closeForm"></param>
    	[UserCodeMethod]
    	public static void NS_CancelTrainClearance_Tasklist(string trainSeed, string description, bool closeForm = true)
    	{
    		NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, trainSeed, true);
    		
    		string trainId = PDS_CORE.Code_Utils.NS_TrainID.GetTrainId(trainSeed);
    		if (trainId == null && trainSeed == "")
            {
                Ranorex.Report.Error("No TrainId found for trainSeed {"+trainSeed+"}, ensure correct trainSeed and that train was made");
                return;
            } else if (trainId == null)
            {
                trainId = trainSeed;
            }
    		GeneralUtilities.ClickAndWaitForNotExistWithRetry(TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.CancelButtonInfo,
                    											TrainClearancerepo.Train_Clearance.PDS_Print_Fax_Dialog.SelfInfo);
    		if(NS_TrainClearance.TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
    		{
    			NS_TrainClearance.TrainClearancerepo.Train_Clearance.Self.EnsureVisible();
    			
    			GeneralUtilities.ClickAndWaitForNotExistWithRetry(NS_TrainClearance.TrainClearancerepo.Train_Clearance.TrainClearance.CancelButtonInfo,
    			                                                  NS_TrainClearance.TrainClearancerepo.Train_Clearance.SelfInfo);
    			Ranorex.Report.Success("Train Clearance for Train ID {"+trainId+"} has been cancelled successfully");
    		} else {
    		    Ranorex.Report.Failure("Train Clearance form did not open");
    		    return;
    		}
    		
    		if(closeForm)
    		{
    			NS_Miscellaneous.CloseTaskListForm_Miscellaneous_MainMenu();
    			if(NS_TrainClearance.TrainClearancerepo.Train_Clearance.SelfInfo.Exists(0))
    			{
    				GeneralUtilities.ClickAndWaitForNotExistWithRetry(NS_TrainClearance.TrainClearancerepo.Train_Clearance.WindowControls.CloseInfo,
    				                                                  NS_TrainClearance.TrainClearancerepo.Train_Clearance.SelfInfo);
    				Ranorex.Report.Info("Train Clearance form closed");
    			}
    			else{
    				Ranorex.Report.Info("Train Clearance form not open to be closed");
    				return;
    			}
    		}
    	}
    }
}
