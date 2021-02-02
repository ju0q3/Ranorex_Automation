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
using STE.Code_Utils.messages.MIS.CN;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;


namespace STE.Code_Utils
{
    /// <summary>
    /// Description of ReceiveMISMessageCollection.
    /// </summary>
    [UserCodeCollection]
    public class ReceiveMISFileCollection_CN
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
            mimresult = messages.SteMessageFileReader.getMovementInformationMessageContent_CN(msgFilters.ToArray(), timeInSeconds, retry);
            return mimresult;
        }
        
        public static MIS_MovementInformationConfig getMovementInformationMessagePerf(int timeInSeconds=5, bool retry=true)
        {
        	MIS_MovementInformationConfig mimresult = new MIS_MovementInformationConfig();
            mimresult = messages.SteMessageFileReader.getMovementInformationMessageContent_CNPerf(msgFilters.ToArray(), timeInSeconds, retry);
            return mimresult;
        }
        
        [UserCodeMethod]
        public static MIS_ETAInformationConfig getETAInformationMessage(int timeInSeconds=5, bool retry=true)
        {
        	MIS_ETAInformationConfig etaresult = new MIS_ETAInformationConfig();
            etaresult = messages.SteMessageFileReader.getETAInformationMessageContent_CN(msgFilters.ToArray(), timeInSeconds, retry);
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
        
        public static MIS_MovementInformationConfig validateMovementInformationMessagePerf(int timeInSeconds=5, bool retry=true)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	MIS_MovementInformationConfig mis_movementMessage = null;
        	mis_movementMessage = getMovementInformationMessagePerf(timeInSeconds, retry);
        	
        	try {
        		Validate.IsTrue(mis_movementMessage != null);
				
        		
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return mis_movementMessage;
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
        	if (!string.IsNullOrEmpty(filterString) && validateDoesExist)
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
            errorMessages = messages.SteMessageFileReader.getMessageErrorsCN(filters, timeInSeconds, retry);
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
		 
    }
}