/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/29/2018
 * Time: 2:21 PM
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
using STE.Code_Utils.messages.MIS.NS;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
    /// <summary>
    /// Description of ReceiveMISMessageCollection.
    /// </summary>
    [UserCodeCollection]
    public class ReceiveMISFileCollection_NS
    {
        public static List<string> msgFilters = new List<string>();
    	
    	[UserCodeMethod]
    	public static void addValueToFilters(string val)
    	{
    		string[] vals;
    		vals = val.Split('|');
    		foreach (string item in vals) {
    			Ranorex.Report.Info("TestStep","Adding " +item+ " to list of filters for STE message validation");
    			msgFilters.Add(item);
    		}
    	}
    	
    	[UserCodeMethod]
    	public static void clearFilters()
    	{
    		Ranorex.Report.Info("Clearing and resetting capacity of list of filters for STE message validation");
    		msgFilters.Clear();
    		msgFilters.TrimExcess();
    	}

		private static MIS_NS_TrainConsistActivity_48 getTrainConsistActivityMessage(int timeInSeconds = 5, bool retry = true)
		{
			MIS_NS_TrainConsistActivity_48 mis_tcam_48 = null;
			mis_tcam_48 = messages.SteMessageFileReader.GetTrainConsistActivityMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_tcam_48;
		}

		private static MIS_NS_EngineConsist_48 getEngineConsistMessage(int timeInSeconds = 5, bool retry = true)
		{
			MIS_NS_EngineConsist_48 mis_engineconsist_48 = null;
			mis_engineconsist_48 = messages.SteMessageFileReader.GetEngineConsistMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_engineconsist_48;
		}

		private static MIS_NS_EOTCaboose_48 getEotCabooseMessage(int timeInSeconds = 5, bool retry = true)
		{
			MIS_NS_EOTCaboose_48 mis_eotcaboose_48 = null;
			mis_eotcaboose_48 = messages.SteMessageFileReader.GetEotCabooseMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_eotcaboose_48;
		}

		private static MIS_NS_CrewMember_48 getCrewMemberMessage(int timeInSeconds = 5, bool retry = true)
		{
			MIS_NS_CrewMember_48 mis_crewmember_48 = null;
			mis_crewmember_48 = messages.SteMessageFileReader.GetCrewMemberMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_crewmember_48;
		}
    	
    	[UserCodeMethod]
        public static bool getMessagePrintFax(string[] filters, int timeInSeconds=5, bool retry=true)
        {
            bool printFax = false;
            printFax = messages.SteMessageFileReader.getMessagePrintFax(filters, timeInSeconds, retry);
            return printFax;
        }

        [UserCodeMethod]
        public static bool getErrorMessage(int timeInSeconds=5, bool retry=true)
        {
            bool errorResult = false;
            errorResult = messages.SteMessageFileReader.getMessageError(msgFilters.ToArray(), timeInSeconds, retry);
            return errorResult;
        }
        
        [UserCodeMethod]
        public static MIS_MovementInformationConfig getMovementInformationMessage(int timeInSeconds=5, bool retry=true)
        {
        	MIS_MovementInformationConfig mimresult = new MIS_MovementInformationConfig();
            mimresult = messages.SteMessageFileReader.getMovementInformationMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
            return mimresult;
        }
        
        [UserCodeMethod]
        public static MIS_ETAInformationConfig getETAInformationMessage(int timeInSeconds=5, bool retry=true)
        {
        	MIS_ETAInformationConfig etaresult = new MIS_ETAInformationConfig();
            etaresult = messages.SteMessageFileReader.getETAInformationMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
            return etaresult;
        }
        
        public static void validateMovementInformationMessage(int timeInSeconds=5, bool retry=true)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	MIS_MovementInformationConfig mis_movementMessage = null;
        	mis_movementMessage = getMovementInformationMessage(timeInSeconds, retry);
        	
        	try {
        		Validate.IsTrue(mis_movementMessage != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }
        
        public static void validatePrintFaxMessage(int timeInSeconds = 5, bool retry = true)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	bool mis_printFax = false;
        	mis_printFax = getMessagePrintFax(msgFilters.ToArray(), timeInSeconds, retry);
        	
        	if (mis_printFax != false)
        	{
        		Ranorex.Report.Success("Validation", "Print fax containing filters found.");
        		foreach (string filter in msgFilters)
        		{
        			Ranorex.Report.Success("Validation", string.Format("Filter found: {0}", filter));
        		}
        	} else {
        		Ranorex.Report.Failure("Validation", "Print fax containing filters not found");
        	}
        	return;
        }


		public static void validateETAInformationMessage(int timeInSeconds=5, bool retry=true)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	MIS_ETAInformationConfig mis_ETAMessage = null;
        	mis_ETAMessage = getETAInformationMessage(timeInSeconds, retry);
        	
        	try {
        		Validate.IsTrue(mis_ETAMessage != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }         

        [UserCodeMethod]
        public static void validateErrorMessage(string filterString, int timeInSeconds=5, bool retry=true, bool validateDoesExist=true)
        {
        	Ranorex.Report.Info("TestStep", "Searching for error messages.");
        	bool errorResult = false;
        	clearFilters();
        	if (!string.IsNullOrEmpty(filterString))
        	{
        		string[] filters = filterString.Split('|');
    			foreach (string filter in filters)
    			{
    				addValueToFilters(filter);
    				Ranorex.Report.Info("TestStep", "Searching for error messages containing the following content: " + filter);
    			}
        	}
        	errorResult = getErrorMessage(timeInSeconds, retry);

        	if (validateDoesExist)
        	{
        		if (errorResult)
        		{
        			Report.Success("Validation", "Error message has been received within " + timeInSeconds.ToString() + " seconds.");
        		} else {
        			Report.Failure("Failure", "No error message has been received within " + timeInSeconds.ToString() + " seconds.");
        		}
        	} else {
        		if (errorResult)
        		{
        			Report.Failure("Failure", "Error message has been received within " + timeInSeconds.ToString() + " seconds.");
        		} else {
        			Report.Success("Validation", "No error message has been received within " + timeInSeconds.ToString() + " seconds.");
        		}
        	}
        }        
       
        
        [UserCodeMethod]
        public static MIS_ErrorMessagesConfig getErrorMessages(string[] filters, int timeInSeconds=5, bool retry=true)
        {
            MIS_ErrorMessagesConfig errorMessages = null;
            errorMessages = messages.SteMessageFileReader.getMessageErrorsNS(filters, timeInSeconds, retry);
            return errorMessages;
        }   

		public static void validateNoMovementInformationMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			MIS_MovementInformationConfig mis_movementMessage = null;
			mis_movementMessage = getMovementInformationMessage(timeInSeconds, retry);
			if (mis_movementMessage == null)
			{
				Ranorex.Report.Success("Ste message containing filters not found");
			} else {
				Ranorex.Report.Failure("Ste message containing filters found");
			}
			return;
		}
        
		public static void validateNoETAInformationMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			MIS_ETAInformationConfig mis_ETAMessage = null;
        	mis_ETAMessage = getETAInformationMessage(timeInSeconds, retry);
			if (mis_ETAMessage == null)
			{
				Ranorex.Report.Success("Ste message containing filters not found");
			} else {
				Ranorex.Report.Failure("Ste message containing filters found");
			}
			return;
		}
		
		[UserCodeMethod]
		public static MIS_NS_RemedyBulletin_48 GetRemedyBulletinMessage(int timeInSeconds=5, bool retry=true)
		{
			MIS_NS_RemedyBulletin_48 mis_remedybulletin = new MIS_NS_RemedyBulletin_48();
			mis_remedybulletin = messages.SteMessageFileReader.getRemedyBulletinMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_remedybulletin;
		}
		
		public static void ValidateRemedyBulletinMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			MIS_NS_RemedyBulletin_48 mis_remedyBulletinMessage = null;
			mis_remedyBulletinMessage = GetRemedyBulletinMessage(timeInSeconds, retry);
			
			try
			{
				Validate.IsTrue(mis_remedyBulletinMessage != null);
			}
			catch(RanorexException)
			{
				Report.Error("STE message containing filters not found");
			}
			return;
		}
		

		[UserCodeMethod]
		public static MIS_ExternalAlertEvent GetExternalAlertEventMessage(int timeInSeconds=5, bool retry=true)
		{
			MIS_ExternalAlertEvent mis_externalAlertMessage = null;
			mis_externalAlertMessage = messages.SteMessageFileReader.getExternalAlertEventContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_externalAlertMessage;
		}
		
		public static void ValidateExternalAlertEventMessage(int timeInSeconds=5, bool retry=true){
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			MIS_ExternalAlertEvent mis_externalAlertMessage = null;
			mis_externalAlertMessage = GetExternalAlertEventMessage(timeInSeconds, retry);
			
			try
			{
				Validate.IsTrue(mis_externalAlertMessage != null);
			}
			catch(RanorexException)
			{
				Report.Error("STE message containing filtes not found");
			}
		}
		
		public static void validateNoExternalAlertEventMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters is not sent within " + timeInSeconds + "-second timespan");
			MIS_ExternalAlertEvent mis_externalAlertMessage = null;
			mis_externalAlertMessage = GetExternalAlertEventMessage(timeInSeconds, retry);
			if (mis_externalAlertMessage == null)
			{
				Ranorex.Report.Success("Ste message containing filters not found");
			} 
			else 
			{
				Ranorex.Report.Failure("Ste message containing filters found");
			}
			return;
		}

		public static void ValidateNoRemedyBulletinMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
			MIS_NS_RemedyBulletin_48 mis_remedybulletin = null;
			mis_remedybulletin = GetRemedyBulletinMessage(timeInSeconds, retry);
			if (mis_remedybulletin == null)
			{
				Ranorex.Report.Success("Ste message containing filters not found");
			}
			else
			{
				Ranorex.Report.Failure("Ste message containing filters found");
			}
			return;
		}
		
		public static MIS_NS_TrainConsistSummary_43 GetTrainConsistMessage(int timeInSeconds=5, bool retry=true)
		{
			MIS_NS_TrainConsistSummary_43 mis_trainconsist = new MIS_NS_TrainConsistSummary_43();
			mis_trainconsist = messages.SteMessageFileReader.getTrainConsistMessageContent_NS(msgFilters.ToArray(), timeInSeconds, retry);
			return mis_trainconsist;
		}
		
		public static void ValidateTrainConsistSummaryMessage(int timeInSeconds=5, bool retry=true)
		{
			Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");			MIS_NS_TrainConsistSummary_43 mis_trainConsistSummaryMessage = null;
			mis_trainConsistSummaryMessage = GetTrainConsistMessage(timeInSeconds, retry);
			
			try
			{
				Validate.IsTrue(mis_trainConsistSummaryMessage != null);
			}
			catch(RanorexException)
			{
				Report.Failure("STE message containing filters not found");
			}
			return;
		}

		public static void ValidateCrewMemberMessage(bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			Report.Info("TestStep", string.Format("Validating that CrewMember message is received within {0} seconds. Expected result: '{1}'.", timeInSeconds.ToString(), validateDoesExist.ToString()));

			MIS_NS_CrewMember_48 mis_crewmember_48 = null;
			mis_crewmember_48 = getCrewMemberMessage(timeInSeconds, retry);
			bool doesExist = (mis_crewmember_48 != null);
			
			string feedbackMessage = string.Format("CrewMember message found: '{0}'. Expected result: '{1}'.", doesExist.ToString(), validateDoesExist.ToString());			
			if (doesExist == validateDoesExist)
			{
				Report.Success("Validation", feedbackMessage);
			} else {
				Report.Failure("Validation", feedbackMessage);
			}
		}

		public static void ValidateEngineConsistMessage(bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			Report.Info("TestStep", string.Format("Validating that EngineConsist message is received within {0} seconds. Expected result: '{1}'.", timeInSeconds.ToString(), validateDoesExist.ToString()));

			MIS_NS_EngineConsist_48 mis_engineconsist_48 = null;
			mis_engineconsist_48 = getEngineConsistMessage(timeInSeconds, retry);
			bool doesExist = (mis_engineconsist_48 != null);
			
			string feedbackMessage = string.Format("EngineConsist message found: '{0}'. Expected result: '{1}'.", doesExist.ToString(), validateDoesExist.ToString());			
			if (doesExist == validateDoesExist)
			{
				Report.Success("Validation", feedbackMessage);
			} else {
				Report.Failure("Validation", feedbackMessage);
			}
		}

		public static void ValidateEotCabooseMessage(bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			Report.Info("TestStep", string.Format("Validating that EOTCaboose message is received within {0} seconds. Expected result: '{1}'.", timeInSeconds.ToString(), validateDoesExist.ToString()));

			MIS_NS_EOTCaboose_48 mis_eotcaboose_48 = null;
			mis_eotcaboose_48 = getEotCabooseMessage(timeInSeconds, retry);
			bool doesExist = (mis_eotcaboose_48 != null);
			
			string feedbackMessage = string.Format("EOTCaboose message found: '{0}'. Expected result: '{1}'.", doesExist.ToString(), validateDoesExist.ToString());			
			if (doesExist == validateDoesExist)
			{
				Report.Success("Validation", feedbackMessage);
			} else {
				Report.Failure("Validation", feedbackMessage);
			}
		}

		public static void ValidateTrainConsistActivityMessage(bool validateDoesExist = true, int timeInSeconds = 5, bool retry = true)
		{
			Report.Info("TestStep", string.Format("Validating that TrainConsistActivity message is received within {0} seconds. Expected result: '{1}'.", timeInSeconds.ToString(), validateDoesExist.ToString()));

			MIS_NS_TrainConsistActivity_48 mis_tcam_48 = null;
			mis_tcam_48 = getTrainConsistActivityMessage(timeInSeconds, retry);
			bool doesExist = (mis_tcam_48 != null);
			
			string feedbackMessage = string.Format("TrainConsistActivity message found: '{0}'. Expected result: '{1}'.", doesExist.ToString(), validateDoesExist.ToString());			
			if (doesExist == validateDoesExist)
			{
				Report.Success("Validation", feedbackMessage);
			} else {
				Report.Failure("Validation", feedbackMessage);
			}
		}
    }
}