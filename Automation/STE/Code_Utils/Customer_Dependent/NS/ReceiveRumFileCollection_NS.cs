/*
 * Created by Ranorex
 * User: 503073759
 * Date: 11/3/2018
 * Time: 1:59 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using STE.Code_Utils.messages.RUM;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class ReceiveRumFileCollection_NS
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
        public static RUM_DR_AK01_1 getMessageDR_AK01_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_AK01_1 rum_dr_ak01 = null;
            rum_dr_ak01 = messages.SteMessageFileReader.getMessageDR_AK01_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_ak01;
        }
        
        [UserCodeMethod]
        public static void validateDR_AK01_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_AK01_1 rum_dr_ak01 = null;
        	rum_dr_ak01 = getMessageDR_AK01_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_ak01 != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }


        [UserCodeMethod]
        public static RUM_DR_BICD_1 getMessageDR_BICD_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_BICD_1 rum_dr_bicd = null;
            rum_dr_bicd = messages.SteMessageFileReader.getMessageDR_BICD_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_bicd;
        }
        
        [UserCodeMethod]
        public static void validateDR_BICD_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BICD_1 rum_dr_bicd = null;
        	rum_dr_bicd = getMessageDR_BICD_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_bicd != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_BICR_1 getMessageDR_BICR_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_BICR_1 rum_dr_bicr = null;
            rum_dr_bicr = messages.SteMessageFileReader.getMessageDR_BICR_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_bicr;
        }
        
        [UserCodeMethod]
        public static void validateDR_BICR_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BICR_1 rum_dr_bicr = null;
        	rum_dr_bicr = getMessageDR_BICR_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_bicr != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }
        
        [UserCodeMethod]
        public static RUM_DR_BIVA_1 getMessageDR_BIVA_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_BIVA_1 rum_dr_biva = null;
            rum_dr_biva = messages.SteMessageFileReader.getMessageDR_BIVA_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_biva;
        }
        
        [UserCodeMethod]
        public static void validateDR_BIVA_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BIVA_1 rum_dr_biva = null;
        	rum_dr_biva = getMessageDR_BIVA_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_biva != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        
        [UserCodeMethod]
        public static RUM_DR_BIVD_1 getMessageDR_BIVD_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_BIVD_1 rum_dr_bivd = null;
            rum_dr_bivd = messages.SteMessageFileReader.getMessageDR_BIVD_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_bivd;
        }
        
        [UserCodeMethod]
        public static void validateDR_BIVD_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BIVD_1 rum_dr_bivd = null;
        	rum_dr_bivd = getMessageDR_BIVD_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_bivd != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_BULI_1 getMessageDR_BULI_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_BULI_1 rum_dr_buli = null;
            rum_dr_buli = messages.SteMessageFileReader.getMessageDR_BULI_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_buli;
        }
        
        
        [UserCodeMethod]
        public static void validateDR_BULI_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BULI_1 rum_dr_buli = null;
        	rum_dr_buli = getMessageDR_BULI_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_buli != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_EROR_1 getMessageDR_EROR_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_EROR_1 rum_dr_eror = null;
            rum_dr_eror = messages.SteMessageFileReader.getMessageDR_EROR_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_eror;
        }
        
        [UserCodeMethod]
        public static void validateDR_EROR_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_EROR_1 rum_dr_eror = null;
        	rum_dr_eror = getMessageDR_EROR_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_eror != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_PTUR_1 getMessageDR_PTUR_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_PTUR_1 rum_dr_ptur = null;
            rum_dr_ptur = messages.SteMessageFileReader.getMessageDR_PTUR_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_ptur;
        }
        
        [UserCodeMethod]
        public static void validateDR_PTUR_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_PTUR_1 rum_dr_ptur = null;
        	rum_dr_ptur = getMessageDR_PTUR_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_ptur != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_RTCD_1 getMessageDR_RTCD_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_RTCD_1 rum_dr_rtcd = null;
            rum_dr_rtcd = messages.SteMessageFileReader.getMessageDR_RTCD_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_rtcd;
        }
        
        [UserCodeMethod]
        public static void validateDR_RTCD_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_RTCD_1 rum_dr_rtcd = null;
        	rum_dr_rtcd = getMessageDR_RTCD_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_rtcd != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_RTED_1 getMessageDR_RTED_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_RTED_1 rum_dr_rted = null;
            rum_dr_rted = messages.SteMessageFileReader.getMessageDR_RTED_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_rted;
        }
        
        [UserCodeMethod]
        public static void validateDR_RTED_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_RTED_1 rum_dr_rted = null;
        	rum_dr_rted = getMessageDR_RTED_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_rted != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_RTRD_1 getMessageDR_RTRD_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_RTRD_1 rum_dr_rtrd = null;
            rum_dr_rtrd = messages.SteMessageFileReader.getMessageDR_RTRD_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_rtrd;
        }
        
        [UserCodeMethod]
        public static void validateDR_RTRD_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_RTRD_1 rum_dr_rtrd = null;
        	rum_dr_rtrd = getMessageDR_RTRD_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_rtrd != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_RTVD_1 getMessageDR_RTVD_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_RTVD_1 rum_dr_rtvd = null;
            rum_dr_rtvd = messages.SteMessageFileReader.getMessageDR_RTVD_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_rtvd;
        }
        
        [UserCodeMethod]
        public static void validateDR_RTVD_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_RTVD_1 rum_dr_rtvd = null;
        	rum_dr_rtvd = getMessageDR_RTVD_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_rtvd != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        [UserCodeMethod]
        public static RUM_DR_TAUT_1 getMessageDR_TAUT_1(int timeInSeconds=5, bool retry=true)
        {
            RUM_DR_TAUT_1 rum_dr_taut = null;
            rum_dr_taut = messages.SteMessageFileReader.getMessageDR_TAUT_1(msgFilters.ToArray(), timeInSeconds, retry);
            return rum_dr_taut;
        }
        
        [UserCodeMethod]
        public static void validateDR_TAUT_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that STE message containing added message filters has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_TAUT_1 rum_dr_taut = null;
        	rum_dr_taut = getMessageDR_TAUT_1(timeInSeconds, retry);
        	try {
        		Validate.IsTrue(rum_dr_taut != null);
        	} catch(RanorexException) {
        		Report.Error("STE message containing filters not found");
        	}
        	return;
        }

        
    	[UserCodeMethod]
    	public static void validateRejectedMessage(int timeInSeconds=5, bool retry=true)
    	{
            bool hasFilter = true;
            bool foundFile = false;
            System.DateTime fromDate;
            System.DateTime toDate;
            List<string> paths;
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
            while (System.DateTime.Now < future && !foundFile) {
            	fromDate = System.DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
	            toDate = System.DateTime.Now;
	            paths = Directory.EnumerateFiles(SteUtils.getInboundPtcDir(), "*", SearchOption.AllDirectories)
	                .Where(path => {
	                   System.DateTime lastWriteTime = File.GetLastWriteTime(path);
	                   return lastWriteTime >= fromDate && lastWriteTime <= toDate;
	                })
	            .ToList();
	            if (paths.Count == 0)
	            {
	            	Ranorex.Report.Failure("No files found within timespan");
	            	Validate.IsTrue(false);
	            }
	            foreach (var path in paths)
	            {
	            	//Ranorex.Report.Info("TestStep","Check file for filters: " + path);
	                using (StreamReader sr = new StreamReader(path))
	                {
	                    string contents = sr.ReadToEnd();
	                    if ((contents.Contains("<ERROR>")) && (contents.Contains("</ERROR>")))
	                    {
		                    foreach (var filter in msgFilters)
			            	{
		                    	Ranorex.Report.Info("TestStep","Checking filter: " + filter);
			            		if(!contents.Contains(filter))
			            		{
			            			hasFilter = false;
			            			break;
			            		}
			            	}
			            	if(hasFilter)
			            	{
			            		foundFile = true;
			            		break;
			            	}
	                    }
	                }
	            }
            }
            Validate.IsTrue(foundFile);
    	}
    	
    	/// <summary>
        /// Validate if there is not DR-Taut message sent
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static void ValidateNoDR_TAUT_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that NO DR-TAUT message has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_TAUT_1 rum_dr_taut = null;
        	rum_dr_taut = getMessageDR_TAUT_1(timeInSeconds, retry);
        	if(rum_dr_taut==null){
        		Ranorex.Report.Success("No DR-TAUT message found");
        	}
        	else{
        		Ranorex.Report.Failure("DR-TAUT message found");
        	}
        	return;
        }
        
        /// <summary>
        /// Validate if there is not DR-BIVA message sent
        /// </summary>
        /// <param name="timeInSeconds">Integer parameter</param>
        /// <param name="retry">Boolean parameter</param>
        [UserCodeMethod]
        public static void ValidateNoDR_BIVA_1(int timeInSeconds, bool retry)
        {
        	Ranorex.Report.Info("TestStep","Validating that NO DR-BIVA message has been sent within a " + timeInSeconds + "-second timespan");
        	RUM_DR_BIVA_1 rum_dr_biva = null;
        	rum_dr_biva = getMessageDR_BIVA_1(timeInSeconds, retry);
        	if(rum_dr_biva==null){
        		Ranorex.Report.Success("No DR-BIVA message found");
        	}
        	else{
        		Ranorex.Report.Failure("DR-BIVA message found");
        	}
        	return;
        }        
    }
}
