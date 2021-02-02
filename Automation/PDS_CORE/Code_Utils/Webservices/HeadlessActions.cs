/*
 * Created by Ranorex
 * User: 210057585
 * Date: 5/22/2018
 * Time: 10:33 AM
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
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Globalization;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using PDS_CORE.WebLogic;
using PDS_CORE.Code_Utils.Webservices.Smi;
using PDS_CORE.Code_Utils.Territory;

namespace PDS_CORE.Code_Utils.Webservices
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class HeadlessActions
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        
        public static string AuthorityId="";
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void GetLogicalPosition()
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "LOGICAL_POSITION_SMI_div1";
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "GET_LOGICAL_POSITION";
            string aLanguage = "English";
            string aUser = "";
            string aLogicalPosition = "";
            string aClientId = "";
            stringArray[] anArguements = new stringArray[2];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "HARDWARE_NAME";
            anArguements[0].item[1] = "TMSDV065";
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CLIENT_VERSION";
            anArguements[1].item[1] = "X";

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
        }
        
        
        
        /// <summary>
        /// GetTrackAuthoritySummaryListCall is used to get the Track Authority Summary  data
        /// 
        /// arguments looks like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetTrackAuthoritySummaryListResponse GetTrackAuthoritySummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response = LoadSummaryListCall("MA_SUMMARY_LIST_SMI_"+factory, "MA_SUMMARY_LIST", "GET_MA_SUMMARY_LIST", "English", user, logicalPosition, client, arguments);
        	GetTrackAuthoritySummaryListResponse trackAuthoritySummaryResponse = GetTrackAuthoritySummaryListResponse.loadXml(response[0].item[1]);
        	
        	return trackAuthoritySummaryResponse;
        }

        
        /// <summary>
        /// GetTrainSheetStatusSummaryListCall / InitializeTrainStatusSummaryCall is used to get Train Sheet status Summary data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainSheetStatusSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	return LoadSummaryListCall("TRT_TRAIN_SHEET_SMI_"+factory, "TRT_TRAIN_SHEET", "GET_TRAIN_STATUS_SUMMARY", "English", user, logicalPosition, client, arguments);
        }


        /// <summary>
        /// GetTrainsClearanceSummaryList is used to get the Track Clearance Summary data
        ///
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetTrainClearancesSummaryListResponse GetTrainClearancesSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response = LoadSummaryListCall("TRAIN_CLEARANCE_SUMMARY_LIST_SMI_"+factory, "TRAIN_CLEARANCE_SUMMARY_LIST", "GET_TRAIN_CLEARANCES_SUMMARY", "English", user, logicalPosition, client, arguments);
        	GetTrainClearancesSummaryListResponse trainClearanceSummary = GetTrainClearancesSummaryListResponse.loadXml(response[0].item[1]);
        	return trainClearanceSummary;
        }


        /// <summary>
        /// GetBulletinsNeededSummaryList is used to get the Bulletins Needed Summary data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetBulletinsNeededSummaryListResponse GetBulletinsNeededSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response = LoadSummaryListCall("BULLETINS_NEEDED_SUMMARY_LIST_SMI_"+factory, "BULLETINS_NEEDED_SUMMARY_LIST", "GET_BULLETINS_NEEDED_SUMMARY", "English", user, logicalPosition, client, arguments);
        	GetBulletinsNeededSummaryListResponse bulletinsNeededSummary = GetBulletinsNeededSummaryListResponse.loadXml(response[0].item[1]);
        	return bulletinsNeededSummary;
        }


        /// <summary>
        /// GetBulletinSummaryList is used to get the Bulletins Summary data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetBulletinSummaryListResponse GetBulletinSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response =  LoadSummaryListCall("BULLETIN_SUMMARY_LIST_SMI_"+factory, "BULLETIN_SUMMARY_LIST", "GET_BULLETINS_SUMMARY", "English", user, logicalPosition, client, arguments);
        	GetBulletinSummaryListResponse bulletinSummary = GetBulletinSummaryListResponse.loadXml(response[0].item[1]);
        	return bulletinSummary;
        }


        /// <summary>
        /// GetTagSummaryListCall is used to get the Weather Summary data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetTagSummaryListResponse GetTagSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response =  LoadSummaryListCall("TAG_SUMMARY_LIST_SMI_"+factory, "TAG_SUMMARY_LIST", "GET_TAG_SUMMARY_LIST", "English", user, logicalPosition, client, arguments);
        	GetTagSummaryListResponse tagSummary = GetTagSummaryListResponse.loadXml(response[0].item[1]);
        	return tagSummary;
        }
        

        /// <summary>
        /// GetWeatherAlertSummaryListCall is used to get the Weather Summary data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static GetWeatherAlertSummaryListResponse GetWeatherAlertSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	stringArray[] response = LoadSummaryListCall("WEATHER_INFO_SMI_"+factory, "MA_SUMMARY_LIST", "GET_MA_SUMMARY_LIST", "English", user, logicalPosition, client, arguments);
        	GetWeatherAlertSummaryListResponse weatherAlertSummary = GetWeatherAlertSummaryListResponse.loadXml(response[0].item[1]);
        	return weatherAlertSummary;
        }
        

        // TODO: This has yet to be verified via pds-ui if the variables are correct
        /// <summary>
        /// GetAlertSummaryListCall is used to get the Track Authrotiy Summary  data
        /// 
        /// arguments would look like 1782299552532421808;1782299552532421814
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetAlertSummaryListCall(string factory, string user, string logicalPosition, string client, string arguments)
        {
        	return LoadSummaryListCall("ALERT_EVENT_SMI_"+factory, "ALERT_EVENT", "AE_SUMMARY_INITIALIZE", "English", user, logicalPosition, client, arguments);
        }
        
        /// <summary>
        /// LoadSummaryListCall is a generic back-end function that supports grabbing SummaryList data based on the factory, domain, method and arguments passed in.
        /// Language, user, and logicalPosition are pretty much optional fields.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] LoadSummaryListCall(string factory, string domain, string method, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();
            TerritoryNameIdMap territoryMap = TerritoryNameIdMap.Instance();
            string aFactory = factory;
            string aDomain = domain;
            string aMethod = method;
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            
            string requestList = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><list>";
            
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
                for(int i=0 ; i < argumentList.Length; i++)
                {
                	requestList = requestList + "<dispatch-territory id=\""+territoryMap.lookupTerritoryLoidId(argumentList[i])+"\"/>";
                }
            }
            else
            {
            	if (arguments != "")
            		requestList = requestList + "<dispatch-territory id=\""+territoryMap.lookupTerritoryLoidId(arguments)+"\"/>";
            	
            }
            
            requestList = requestList + "</list>";
            
          
            
            stringArray[] anArguements = new stringArray[1];
            
            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "REQUEST_LIST";
            anArguements[0].item[1] = requestList;

           
            var smiResponse = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", smiResponse.ToString());
            File.WriteAllText("C:\\RanorexReports\\joe.txt", smiResponse[0].item[1]);
            return smiResponse;	
        }
        


        /// <summary>
        /// GetLogicalPositionCall is used to get Logical Position data for a machine
        /// Example Message:
        /// <ns1:smiBridge xmlns:ns1="http://ws.tms.trans.ge.com/">
        ///     <aFactory>LOGICAL_POSITION_SMI_div1</aFactory>
        ///     <aDomain>LOGICAL_POSITION</aDomain>
        ///     <aMethod>GET_LOGICAL_POSITION</aMethod>
        ///     <aLanguage>English</aLanguage>
        ///     <aUser>sdisp1</aUser>
        ///     <aLogicalPosition></aLogicalPosition>
        ///     <aClientId/>
        ///     <anArguements xmlns:ns2="http://jaxb.dev.java.net/array">
        ///         <item>HARDWARE_NAME</item>
        ///         <item>MLBRDC114</item>
        ///     </anArguements>
        ///     <anArguements xmlns:ns2="http://jaxb.dev.java.net/array">
        ///         <item>CLIENT_VERSION</item>
        ///         <item>X</item>
        ///     </anArguements>
        /// </ns1:smiBridge>
        /// 
        /// arguments would look like MLBRDC114;X
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetLogicalPositionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "GET_LOGICAL_POSITION";
            string aLanguage = language;
            string aUser = "";
            string aLogicalPosition = "";
            string aClientId = "";
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "HARDWARE_NAME";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CLIENT_VERSION";
            anArguements[1].item[1] = argumentList[1].ToString();

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
    


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaCreateCall(string factory, string language, string user, string logicalPosition, string viewId, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "FBA_MA_SMI_SMI_"+factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = "-1";

            stringArray[] anArguements = new stringArray[5];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = "CREATE";

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = "FBA_MA";

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = "";

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = viewId;

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            //arguments should be either "T/E" or "R/W"
            
            string data = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><StateInfo><FBA_MA><ADDRESSEE><ADDRESSEE_TYPE><Value><Field>"+arguments+"</Field></Value></ADDRESSEE_TYPE></ADDRESSEE></FBA_MA></StateInfo>";
            anArguements[4].item[1] = data;

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaWriteCall(string factory, string language, string user, string logicalPosition, string viewId, string authorityId, string arguments)
        {
            var writebridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "FBA_MA_SMI_SMI_"+factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = "-1";
            //string[] argumentList;

            stringArray[] anArguements = new stringArray[5];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = "WRITE";
            
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = "FBA_MA";

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = authorityId;

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = viewId;

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = arguments;

            var rawr = writebridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaExitCall(string factory, string language, string user, string logicalPosition, string viewId, string authorityId)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "FBA_MA_SMI_SMI_"+factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = "-1";

            stringArray[] anArguements = new stringArray[4];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = "EXIT";
            
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = "FBA_MA";

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = authorityId;

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = viewId;

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] IssueRWAuthorityCall(string factory, string language, string user, string logicalPosition, string client, string authorityType, string toWorker, string atLocation, string beginStation, string endStation, string track)
        {
            string header = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>";
            string viewId = System.DateTime.Now.ToString("yyyyMMddHHmms");
            string xmlArg = "";
            string authId = "";
            
           
            
            xmlArg = authorityType;
            stringArray[] response = FbaCreateCall(factory, language, user, logicalPosition, viewId, xmlArg);
            StateInfo stateInfo = StateInfo.loadXml(response[1].item[1]);
            authId = stateInfo.FBA_MA.id;
            
            if (AuthorityId == ""){
            	AuthorityId = authId;
            } else {
            	AuthorityId = AuthorityId + "|" + authId;
            }
                  
            
            //TODO: Change Hardcoded values to variables
            xmlArg = header+"<StateInfo><FBA_MA><ADDRESSEE><EMPLOYEE><Value><Field>"+toWorker+"</Field></Value></EMPLOYEE></ADDRESSEE></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><LOCATION><Value><Field>"+atLocation+"</Field></Value></LOCATION></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><LIMITS><WORK><CHECK><Value><Field>Y</Field></Value></CHECK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>"+beginStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"></Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field/></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field/></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            SUBLINE_31Record subline = null;
            foreach (var sub in stateInfo.FBA_MA.LIMITS.WORK.WORK_LIMITS.SUBLINE)
            {
            	if (sub.SUBLINE_id == "31")
            	{
            		subline = sub;
            	}
            }

            xmlArg = header+"<StateInfo><FBA_MA><LIMITS><WORK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>"+subline.BEGIN.POINT+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\""+subline.BEGIN.NAMED_BOUNDARY_id+"\">"+subline.BEGIN.NAMED_BOUNDARY+"</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field>"+endStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field/></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS></FBA_MA></StateInfo>";
            
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            foreach (var sub in stateInfo.FBA_MA.LIMITS.WORK.WORK_LIMITS.SUBLINE)
            {
            	if (sub.SUBLINE_id == "31")
            	{
            		subline = sub;
            	}
            }
			 xmlArg = header+"<StateInfo><FBA_MA><LIMITS><WORK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>"+subline.BEGIN.POINT+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\""+subline.BEGIN.NAMED_BOUNDARY_id+"\">"+subline.BEGIN.NAMED_BOUNDARY+"</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field>"+endStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\""+subline.END.NAMED_BOUNDARY_id+"\">"+subline.END.NAMED_BOUNDARY+"</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field>"+track+"</Field></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS></FBA_MA></StateInfo>";            
            		      
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><ISSUE_BTN><Value><Field>Issue</Field></Value></ISSUE_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><CONTINUE_BTN><Value><Field>Continue</Field></Value></CONTINUE_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
    
            xmlArg = header+"<StateInfo><FBA_MA><ACKNOWLEDGED_BTN><Value><Field>Acknowledge</Field></Value></ACKNOWLEDGED_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            //stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            response = FbaExitCall(factory, language, user, logicalPosition, viewId, authId);
            //stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            
            //var rawr = FbaExitCall(factory, language, user, logicalPosition, client, viewId, authorityId);
            //var rawr = null;
            
            //return rawr;
            Report.Info("Auth",AuthorityId);
            
            return response;
        	
            
        }       
        
        
/// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] IssueRWAuthorityTECall(string factory, string language, string user, string logicalPosition, string client, string authorityType, string toWorker, string atLocation, string beginStation, string endStation, string track,string trainsymbol,string engine,string section)
        {
        	
            string header = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>";
            string viewId = System.DateTime.Now.ToString("yyyyMMddHHmms");
            string xmlArg = "";
            string authId = "";
            
            
            
            string trainsymbole=PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDateNoSection(trainsymbol, section);
            string dateoforigin=PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainsymbol);
            string ddorgin = dateoforigin.Substring(2,2);
            CultureInfo provider = CultureInfo.InvariantCulture;
            System.DateTime  oDate= System.DateTime.ParseExact(dateoforigin,"MMddyyyy",provider);
            
            string dateoforgina= oDate.ToString("MM-dd-yyyy");
            
            stringArray[] smiResponse= IdentifyTrainCall(factory,language,user,logicalPosition,"",section,trainsymbole,ddorgin);
          	string aTrainKeyOut = smiResponse[5].item[1];
          	string[] aTrainKeyList;
          	
          	if (aTrainKeyOut.Contains(";"))
            {
                aTrainKeyList = aTrainKeyOut.Split(';');
            }
            else
            {
                aTrainKeyList = new string[1];
                aTrainKeyList[0] = aTrainKeyOut;
            }
            
            xmlArg = authorityType;
            stringArray[] response = FbaCreateCall(factory, language, user, logicalPosition, viewId, xmlArg);
            StateInfo stateInfo = StateInfo.loadXml(response[1].item[1]);
            authId = stateInfo.FBA_MA.id;
            
            if (AuthorityId == ""){
            	AuthorityId = authId;
            } else {
            	AuthorityId = AuthorityId + "|" + authId;
            }
            
                                
            Report.Info(" orgindate ",dateoforgina);
            
            xmlArg = header+"<StateInfo><FBA_MA><ADDRESSEE><TRAIN_ID><Value><TrainIdField id=\""+aTrainKeyList[0]+"\"><SECTION>"+section+"</SECTION><SYMBOL>"+trainsymbole+"</SYMBOL><ORIGIN_DAY>"+ddorgin+"</ORIGIN_DAY><SCAC>CN</SCAC><ORIGIN_DATE>"+dateoforgina+" 00:00:00 GMT</ORIGIN_DATE></TrainIdField></Value></TRAIN_ID></ADDRESSEE></FBA_MA></StateInfo>";
            
           
            
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            
            
            
            xmlArg = header+"<StateInfo><FBA_MA><ADDRESSEE><LEAD_ENGINE_LIST><Value><List><Item><Field>"+engine+"</Field></Item></List></Value></LEAD_ENGINE_LIST></ADDRESSEE></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
          
            
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            

            xmlArg = header+"<StateInfo><FBA_MA><LOCATION><Value><Field>"+atLocation+"</Field></Value></LOCATION></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
           
            //TODO: Change Hardcoded values to variables
            xmlArg = header+"<StateInfo><FBA_MA><ADDRESSEE><EMPLOYEE><Value><Field>"+toWorker+"</Field></Value></EMPLOYEE></ADDRESSEE></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><LIMITS><WORK><CHECK><Value><Field>Y</Field></Value></CHECK></WORK></LIMITS></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><LIMITS><WORK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>"+beginStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field/></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field/></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
          
            string boundaryId=stateInfo.FBA_MA.LIMITS.WORK.WORK_LIMITS.SUBLINE[0].BEGIN.NAMED_BOUNDARY_id;
            string boundary=stateInfo.FBA_MA.LIMITS.WORK.WORK_LIMITS.SUBLINE[0].BEGIN.NAMED_BOUNDARY;
            
            Report.Info("boundaryId",boundaryId);
            Report.Info("boundary",boundary);
                      
		            
            
            xmlArg= header+ "<StateInfo><FBA_MA><LIMITS><WORK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>"+beginStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\""+boundaryId+"\">"+boundary+"</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field>"+endStation+"</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\""+boundaryId+"\">"+boundary+"</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field>"+track+"</Field></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><ISSUE_BTN><Value><Field>Issue</Field></Value></ISSUE_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);

            xmlArg = header+"<StateInfo><FBA_MA><CONTINUE_BTN><Value><Field>Continue</Field></Value></CONTINUE_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);
            stateInfo = StateInfo.loadXml(response[1].item[1]);
            
            xmlArg = header+"<StateInfo><FBA_MA><ACKNOWLEDGED_BTN><Value><Field>Acknowledge</Field></Value></ACKNOWLEDGED_BTN></FBA_MA></StateInfo>";
            response = FbaWriteCall(factory, language, user, logicalPosition, viewId, authId, xmlArg);

            response = FbaExitCall(factory, language, user, logicalPosition, viewId, authId);

      
            Report.Info("Auth",AuthorityId);
            
            return response;
        	
            
        }  
        
        
/// <summary>
        /// This method used to clearAuthority (R/W)
        /// through SMI Call
        /// Parameter : factory , language , user , logicalPostion , client and authority type
        /// and authority id which is generated by IssueRWAuthority call
        /// </summary>
        [UserCodeMethod]
        public static void ClearRWAuthorityCall(string factory, string language, string user, string logicalPosition, string client, string authorityType, string authority_id)
        {
        	string header = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>";
        	string xmlArg = "";
        	string view_id = System.DateTime.Now.ToString("yyyyMMddHHmms");
        	string current_dt = System.DateTime.Now.ToString(" ddd MMM dd hh:mm:ss yyyy");
        	stringArray[]  response;
        	
        	string ids="";
        	
        	// iterate all authorities from static variable or from parameter
        	
        	if (authority_id =="")
        		ids=AuthorityId;
        	else
        		ids=authority_id;
        	
        	string[] argumentList;
            if (ids.Contains("|"))
	            {
	                argumentList = ids.Split('|');
	            }
	        else
	            {
	                argumentList = new string[1];
	                argumentList[0] = ids;
	            }
    		 
        	 for(int i=0 ; i < argumentList.Length; i++) {
	        	
	        	Report.Info(" Authority to clear ",argumentList[i]);
	        	
	        	response = FbaWriteCallforRestore(factory,language,user,logicalPosition,view_id,argumentList[i]);
	        	StateInfo stateInfo = StateInfo.loadXml(response[1].item[1]);
	        
	        	xmlArg = header+"<StateInfo><FBA_MA><RELEASE><BY><Value><Field>"+stateInfo.FBA_MA.ADDRESSEE.EMPLOYEE+"</Field></Value></BY></RELEASE></FBA_MA></StateInfo>";
	        	response = FbaWriteCall(factory, language, user, logicalPosition, view_id, argumentList[i], xmlArg);
	      
	        	xmlArg = header+"<StateInfo><FBA_MA><CLEAR_BTN><Value><Field>Clear</Field></Value></CLEAR_BTN></FBA_MA></StateInfo>";
	        	response = FbaWriteCall(factory, language, user, logicalPosition, view_id, argumentList[i], xmlArg);
	         	
	        	string data_1 = header + "NOTIFICATION_NOTIFICATION_ACKNOWLEDGED:<html><p>SWITCHES NORMAL TO THE REAR.<p/></p><p color='red' >IS THAT CORRECT?</p></html> "+ current_dt;
	        	string  data_0  = header+"<StateInfo><FBA_MA><Notify><Pending/><Acknowledged><Item type=\"Switch Confirmation\">&amp;lt;html&amp;gt;&amp;lt;p&amp;gt;SWITCHES NORMAL TO THE REAR.&amp;lt;p/&amp;gt;&amp;lt;/p&amp;gt;&amp;lt;p color='red' &amp;gt;IS THAT CORRECT?&amp;lt;/p&amp;gt;&amp;lt;/html&amp;gt;</Item></Acknowledged><Rejected/></Notify></FBA_MA></StateInfo>";
	        	response = FbaWriteCallwithDataAck(factory, language, user, logicalPosition, view_id, argumentList[i], data_0,data_1);
	       	
	        	xmlArg = header+"<StateInfo><FBA_MA><DEACTIVATION_APPROVED_BTN><Value><Field>Acknowledge</Field></Value></DEACTIVATION_APPROVED_BTN></FBA_MA></StateInfo>";
	        	response = FbaWriteCall(factory, language, user, logicalPosition, view_id, argumentList[i], xmlArg);
	        	response = FbaExitCall(factory, language, user, logicalPosition, view_id, argumentList[i]);
        	
	        	Thread.Sleep(1000);
	        }
	        // clear the static variable which holds Authority id sepated by |
	        AuthorityId="";
		
        }       
        


          /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaWriteCallforRestore(string factory, string language, string user, string logicalPosition, string viewId, string authorityId)
        {
            var writebridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "FBA_MA_SMI_SMI_"+factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = "-1";
            //string[] argumentList;

            stringArray[] anArguements = new stringArray[4];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = "RESTORE";
            
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = "FBA_MA";

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = authorityId;

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = viewId;

            var rawr = writebridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        
           /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaWriteCallwithDataAck(string factory, string language, string user, string logicalPosition, string viewId, string authorityId, string arg1,string arg2)
        {
            var writebridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "FBA_MA_SMI_SMI_"+factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = "-1";
            //string[] argumentList;

            stringArray[] anArguements = new stringArray[6];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = "WRITE";
            
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = "FBA_MA";

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = authorityId;

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = viewId;

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = arg1;
            
            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "DATA_1";
            anArguements[5].item[1] = arg2;

            var rawr = writebridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// arguments will be look like key|value;key|value;key|value;train_key  the number of key|value pairs is arbitrary; last element will always be train_key
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] AcceptTaskListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "TASK_LIST_COMMAND";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList = arguments.Split(';');
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "COMMAND_KEY";
            anArguements[0].item[1] = "ACCEPT"; 
            
            //Split the key-value pair by |
            for (int i=0; i < argumentList.Length-1; i++)
            {
            	string[] keyvalue = argumentList[i].Split('|');
	            anArguements[1] = new stringArray();
	            anArguements[1].item = new String[2];
	            anArguements[1].item[0] = keyvalue[0];
	            anArguements[1].item[1] = keyvalue[1];  
            }

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_KEY";
            anArguements[2].item[1] = argumentList[argumentList.Length-1]; //TrainIDKey

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] AcknowledgeAlertEventCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "AlertEventUServiceFactory_";
            string aMethod = "";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] AutoGenerateHelperCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "AUTO_GENERATE_HELPER";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "CALL_DATA_TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CALL_DATA_NEW_VALUE";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] AutorouterPlanInfoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "AUTOROUTER_PLAN_INFO";
            string aMethod = "AutorouterPlanInfoCall:SmiUtils.factoryFromDomain(getDomainName(); getLogicalDivision());";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] CancelTrainClearanceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetApplyCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_APPLY";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FRONT_FLOW_SMI_div0";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetDisableTracklineCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_DISABLE_TRACKLINE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CHANGESET_ID_SELECTED";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetPostApplyCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_POST_APPLY_CHANGE_SET_CHANGES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "CHANGESET_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetPreapplyCheckCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_PREAPPLY_CHECK";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CHANGESET_ID_SELECTED";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "VALIDATE=FALSE";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetUndoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_UNDO_PREAPPLY_CHANGES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ChangeSetValidateCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_PREAPPLY_CHECK";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID_SELECTED";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CHANGESET_ID_SELECTED";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "VALIDATE=TRUE";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] CheckScheduleTemplateExistsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "CHECK_SCHD_TEMPLATE_EXIST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_SYMBOL";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SECTION";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] CleanupTrainClearanceModelsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_SESSIONLESS";
            string aMethod = "CLEANUP_TC_MODELS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] CollectTrainClearanceBulletinsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] CompareTrainClearancesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "ORIGIN_STATION_PASSCOUNT_PAIR";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "INTERMEDIATE_STATION_OPSTA";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "DESTINATION_STATION_PASSCOUNT_PAIR";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "TRAIN_KEY";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ConfirmTrackingRequestCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MOVEMENT_AUTHORITY_TRACKING";
            string aMethod = "TRACKING_REQUEST_CONFIRMED";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "PROPERTY_ACTION_TYPE";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "PROPERTY_TRAIN_KEY";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "PROPERTY_MOVEMENT_AUTHORITY_KEY";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "PROPERTY_TLS_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "PROPERTY_USER_ID";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "PROPERTY_LOGICAL_POSITION";
            anArguements[5].item[1] = argumentList[5];

            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "PROPERTY_SESSION_ID";
            anArguements[6].item[1] = argumentList[6];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] DeleteTaskListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "TASK_LIST_COMMAND";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "COMMAND_KEY=DELETE";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "objectId : objectId key-value pair";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] DeleteWeatherAlertNoticeCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "WEATHER_INFO";
            string aMethod = "DELETE_WEATHER_ALERT_NOTICE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "WX_REPORT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] DisableMovementPlanningCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "MP_STATUS_CHANGE_REQUEST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "REGION_ID";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "ACTION=DISABLE";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] DoNotPlanTrainCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "DO_NOT_PLAN_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "CALL_DATA_TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CALL_DATA_NEW_VALUE";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] EnableMovementPlanningCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "MP_STATUS_CHANGE_REQUEST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "REGION_ID";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "ACTION=ENABLE";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaCleanupCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "FBAM_SMICMD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length+1];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];
            
			anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = "";
            

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaConvertToAuthCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "CONVERT_TO_TRACK_AUTH";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=CONVERT_TO_TRACK_AUTH";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID=";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }



        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaCreateFromAllSublinesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "TAFORM_WITH_ALL_SUBLINES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=TAFORM_WITH_ALL_SUBLINES";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAMEAUTHORITY_ID=";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "VIEW_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "DATA_0";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaCreateFromTracklineCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "CREATE_FROM_TRACKLINE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=CREATE_FROM_TRACKLINE";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID=";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaDrTimeoutCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "DR_TIMEOUT";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=DR_TIMEOUT";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "DATA_1";
            anArguements[5].item[1] = argumentList[5];

            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "DATA_2";
            anArguements[6].item[1] = argumentList[6];

            anArguements[7] = new stringArray();
            anArguements[7].item = new String[2];
            anArguements[7].item[0] = "etc.";
            anArguements[7].item[1] = argumentList[7];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }



        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaMowPrintCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "MOW_PRINT";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=MOW_PRINTID";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaRdCataRejectCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "RD_CATA_WITH_REJECT";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=RD_CATA_WITH_REJECT";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "DATA_1";
            anArguements[5].item[1] = argumentList[5];

            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "DATA_2";
            anArguements[6].item[1] = argumentList[6];

            anArguements[7] = new stringArray();
            anArguements[7].item = new String[2];
            anArguements[7].item[0] = "etc.";
            anArguements[7].item[1] = argumentList[7];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaRecoverCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "RECOVER";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=RECOVER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaRestoreCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "RESTORE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=RESTORE";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaTaskCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "TASK";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=TASK";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID=";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DATA_0";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FbaViewTrainsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA";
            string aMethod = "VIEW_TRAINS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=VIEW_TRAINS";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "VIEW_ID";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FindTrainLastOSCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "FIND_TRAIN_LAST_OS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FrontFlowChangeSetCloseFormCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_CLOSE_FORM";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] FrontFlowChangeSetOpenFormCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_OPEN_FORM";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetAlertEventSummaryListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "AlertEventUServiceFactory_";
            string aMethod = "GetAlertEventSummaryListCall:ALERT_EVENT_U_SERVICE_FACTORY + getLogicalDivision()";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetBulletinDetailsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "BULLETIN_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_KEYALL_BULLETINS";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetBulletinsForRelayCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SHORT_TRAIN_ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "BULLETIN_DATA";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetCachedDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "GET_CACHED_DATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "CONFIG|TNS_TRACKING_CFG";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetDispatchTerritoriesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "GET_DISPATCH_TERR";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "LOGICAL_POSITION_NAME";
            anArguements[0].item[1] = argumentList[0];

            var smiResponse = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", smiResponse.ToString());
            return smiResponse;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetDivisionsForRailroadCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TDL_DELAY_GUIDANCE";
            string aMethod = "GET_DIVISIONS_FOR_RAILROAD";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetLinePlanningTerritoryNamesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_LPT_NAMES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetMpsDateRangesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_PERMSCHD_DATERANGE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SCAC";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SECTION";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetMpsTrainGroupsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_TRAIN_GROUPS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetMpsUnrestrictedTrainGroupsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_UNRESTRICTED_TRAIN_GROUPS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetScacListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_SCAC_LIST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetScheduleAdherenceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_SCHEDULE_ADHERENCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetSpecifyTrainDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_SPECIFY_TRAIN_DATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SECTION";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SYMBOL";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "SCAC_LIST";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "ORIGIN_DATE_LIST";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTopologyInfoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_TOPOLOGY_INFO";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "ID_TYPE";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "info.toString()=YES";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceAssociationListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceEndStationsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRAIN_CLEARANCE_SMI_"+factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length+3];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SHORT_TRAIN_ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "TRAIN_SECTION";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "TRAIN_ORIGIN_DAY";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "TGBO_ORIGINATING_SOURCE";
            anArguements[5].item[1] = "TGBO_Originated";

            
            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "SERVICE_NAME";
            anArguements[6].item[1] = "GET_TC_ENDSTATIONS";
            
            anArguements[7] = new stringArray();
            anArguements[7].item = new String[2];
            anArguements[7].item[0] = "SESSION_INFO";
            anArguements[7].item[1] = "REL_CREW_TC|false;ROUTE_AMBIGUITY|INVALID_ROUTE_AMBIGUITY;ROUTE_TYPE|INVALID_ROUTE_TYPE;SHORT_TRAIN_ID|;TC_LIMIT1|;TC_LIMIT2|;TC_PRELIMINARY_ROUTE|0;TRAIN_IDENTIFIED|false;TRAIN_KEY|0;TRAIN_ORIG_DATE|Jan 01,1970 00:00:00 GMT;TRAIN_SCAC|;TRAIN_SECTION|;TRAIN_SYMBOL|;";
             
               
            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            File.WriteAllText("C:\\RanorexReports\\smi.txt",rawr.ToString());
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceColllectTCBulletinsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRAIN_CLEARANCE_SMI_"+factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
          
            stringArray[] anArguements = new stringArray[2];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SERVICE_NAME";
            anArguements[0].item[1] = "COLLECT_TC_BULLETINS";

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SESSION_INFO";
            anArguements[1].item[1] = arguments;
               
            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            File.WriteAllText("C:\\RanorexReports\\smi.txt",rawr.ToString());
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        
         
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceIssueCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRAIN_CLEARANCE_SMI_"+factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
          
            stringArray[] anArguements = new stringArray[5];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SERVICE_NAME";
            anArguements[0].item[1] = "ISSUE_TRAIN_CLEARANCE";

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SESSION_INFO";
            anArguements[1].item[1] = arguments;
            
            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "PRINT_REQUEST";
            anArguements[2].item[1] = "&lt;PrintRequest&gt;&lt;userId&gt;&lt;/userId&gt;&lt;reportType&gt;TrainClearance&lt;/reportType&gt;&lt;callType&gt;TGBO&lt;/callType&gt;&lt;requestType&gt;ISSUE&lt;/requestType&gt;&lt;terminalOrDeskName&gt;&lt;/terminalOrDeskName&gt;&lt;effectiveDate&gt;&lt;/effectiveDate&gt;&lt;translationType&gt;DISTRIBUTIONLIST&lt;/translationType&gt;&lt;recipient&gt;&lt;recipientName&gt;DOB_TERMINAL&lt;/recipientName&gt;&lt;recipientAddress/&gt;&lt;recipientType&gt;DISTRIBUTIONLIST&lt;/recipientType&gt;&lt;numberOfCopies&gt;1&lt;/numberOfCopies&gt;&lt;/recipient&gt;&lt;/PrintRequest&gt;";
            
            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "REL_CREW_TASK";
            anArguements[3].item[1] = "false";
            
            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "RECIPIENT_TYPE";
            anArguements[4].item[1] = "DISTRIBUTIONLIST";
            
               
            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            File.WriteAllText("C:\\RanorexReports\\smi.txt",rawr.ToString());
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceRouteSpecCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainClearanceRouteSpecCompairCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_SESSIONLESS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SHORT_TRAIN_ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainSheetHeaderCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_TRAIN_SHEET_HEADER";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainSheetHeaderPlanningDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_PLANNING_HEADER_DATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainSheetInfoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_TRAIN_ID";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetTrainSheetSummaryCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "GET_TRAIN_SHEET_SUMMARY";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList = new string[1];

            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetUserAccountsFormDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "UM_USER_ACCOUNT_MANAGEMENT";
            string aMethod = "GET_USER_ACCOUNTS_FORM_DATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetUserPermissionsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "UM_ACCESS_CONTROLS";
            string aMethod = "GET_PERMISSIONS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetUserPreferenceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "UM_ACCESS_CONTROLS";
            string aMethod = "GET_PREFERENCES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetVersionInfoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "VERSION_INFO";
            string aMethod = "GET_VERSION_INFO";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetWeatherAlertNoticeCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "WEATHER_INFO";
            string aMethod = "GET_WEATHER_ALERT_NOTICE_DATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "WX_REPORT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] HandleBulletinPopUpActionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "USER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "BULLETIN_NUMBER";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_KEY";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "ACTION";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "POPUP_TYPE";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] HandleRUMAlertAuthorityActionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FBA_MA_SMI";
            string aMethod = "RUM_ALERT_AUTHORITY_ACTION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "AE_RUM_INFO";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] HandleRUMAlertBulletinActionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

           string aFactory = "TRT_TRAIN_SHEET_SMI_"+factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "RUM_ALERT_BULLETIN_ACTION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "AE_ACTION";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "AE_RUM_SEQ_NUM";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AE_RUM_INFO";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

     
          /// <summary>
        /// This code used to issue TBGO (Train Clearance) using SMICall 
        /// Parameters are logical postion and arguments like section|trainsymbol|DD (ex : 5|A1234|27
        /// </summary>
        [UserCodeMethod]
        public static String TGBOSmiCall(string logicalPosition,string section,string trainsymbol,string dateoforigin)
        {
        	
        
        	stringArray[] smiResponse= IdentifyTrainCall("div1","English","sdisp1",logicalPosition,"",section,trainsymbol,dateoforigin);
          	string aTrainKeyOut = smiResponse[5].item[1];
          	string[] aTrainKeyList;
          	
          	if (aTrainKeyOut.Contains(";"))
            {
                aTrainKeyList = aTrainKeyOut.Split(';');
            }
            else
            {
                aTrainKeyList = new string[1];
                aTrainKeyList[0] = aTrainKeyOut;
            }
          	
          	string aEndStationCallArgs = aTrainKeyList[0]+";"+trainsymbol+section+" "+dateoforigin+";"+trainsymbol+";"+section+";"+dateoforigin;
          	
          	smiResponse = GetTrainClearanceEndStationsCall("div1","English","sdisp1",logicalPosition,"",aEndStationCallArgs);
          	
          	string aSessionInfo = smiResponse[10].item[1];
    
          	smiResponse = GetTrainClearanceColllectTCBulletinsCall("div1","English","sdisp1",logicalPosition,"",aSessionInfo);
          	
          	smiResponse = GetTrainClearanceIssueCall("div1","English","sdisp1",logicalPosition,"",aSessionInfo);
          	string aTgboNo="";
          	
          	if (smiResponse.Length>=5) {
          	                                  
          		 aTgboNo =  smiResponse[5].item[1];
          	} 
        	
          	Report.Info("TBGO # " ,aTgboNo);
          	
        	return aTgboNo;
        		
        }
        
        
        
         /// This code used get Train clearnace number using SMICall
         /// Parameters are logical postion and arguments like section , train symbol and date of orgin
        /// </summary>
        [UserCodeMethod]
        public static String getTrainClearnceNumberSMI(string logicalPosition,string section,string trainsymbol,string dateoforigin)
        {
        	
        
        	stringArray[] smiResponse= IdentifyTrainCall("div1","English","sdisp1",logicalPosition,"",section,trainsymbol,dateoforigin);
          	string aTrainKeyOut = smiResponse[5].item[1];
          	string[] aTrainKeyList;
          	
          	if (aTrainKeyOut.Contains(";"))
            {
                aTrainKeyList = aTrainKeyOut.Split(';');
            }
            else
            {
                aTrainKeyList = new string[1];
                aTrainKeyList[0] = aTrainKeyOut;
            }
          	
          	string aEndStationCallArgs = aTrainKeyList[0]+";"+trainsymbol+section+" "+dateoforigin+";"+trainsymbol+";"+section+";"+dateoforigin;
          	
          	smiResponse = GetTrainClearanceEndStationsCall("div1","English","sdisp1",logicalPosition,"",aEndStationCallArgs);
          	
          	string aTgboNo = smiResponse[11].item[1];
          	
          	Report.Info("TBGO # " ,aTgboNo);
          	
        	return aTgboNo;
        		
        }
        

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] IdentifyTrainCall(string factory, string language, string user, string logicalPosition, string client, string section,string trainsymbol,string dateoforigin)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRT_TRAIN_SHEET_SMI_"+factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "IDENTIFY_TRAIN";
          //  string aMethod="TRAIN_SHEET_IDENTIFY_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            
            stringArray[] anArguements = new stringArray[5];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SECTION";
            anArguements[0].item[1] = section;

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_SYMBOL";
            anArguements[1].item[1] = trainsymbol;

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "ORIGIN_DAY";
            anArguements[2].item[1] = dateoforigin;

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "USER_ID";
            anArguements[3].item[1] = aUser;

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "CONTEXT";
            anArguements[4].item[1] = "FIND_TRAIN";
                                                                   
            var smiResponse = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", smiResponse.ToString());
            return smiResponse;
        }

        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] InitializeAlertEventQueueCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "AlertEventUServiceFactory_";
            string aMethod = "INITIALIZE_ALERT_EVENT_QUEUE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] InitializePositionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "INITIALIZE_POSITION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "LOGICAL_POSITION";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }



        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] IssueTrainClearanceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "SMI_TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "PRINT_REQUEST";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "REL_CREW_TASK";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "RECIPIENT_TYPE";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }


        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] IsHOSLogoffConfirmationDialogRequired(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "LOGICAL_POSITION_SMI";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SERVICE_METHOD=LOGOFF_HOS_DIALOG_REQUIRED";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "USERNAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "LOGICAL_POSITION";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] Logoff(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "LOGICAL_POSITION_SMI";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SERVICE_METHOD=LOGOFF_HOS";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "USERNAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "LOGICAL_POSITION";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "LOGOFF_HOS";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] RelieveUserOfRecord(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "LOGICAL_POSITION";
            string aMethod = "LOGICAL_POSITION_SMI";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SERVICE_METHOD";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "USER";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "LOGICAL_POSITION";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MakeTrainClearanceCurrentCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_SESSIONLESS";
            string aMethod = "SMI_TRAIN_CLEARANCE_SESSIONLESS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SHORT_TRAIN_ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "FIRST_CALL";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWCreateCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWCREATE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "DATA_0";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "USER_IDSTATION_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "MOW_COMMENT";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "TASK_DESCRIPTION";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWGetAuthNoCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWAUTHID";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "USER_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWGetObjectCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWGETOBJECT";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "USER_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWGetSegmentsForTrackCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "SEGMENTSFORTRACK";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "STATION_NAME";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TO_STATION_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "SELECTED_TRACK_NAME";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWGetSwitchCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "SWFROMSTATION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "STATION_NAME";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWGetTrackNamesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "TRACKFROMSTATION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "STATION_NAME";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TO_STATION_NAME";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWHideAuthorityLimitsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOW_HIDE_AUTHORITY_LIMITS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "DATA_0";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DATA_1";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWIsSameDirectionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "ISSAMEDIRECTION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "STATION_NAME";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TO_STATION_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "SELECTED_TRACK_NAME";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "PREV_STATIONNAM";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "PREV_TRACKNAM";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "SL1_STATIONNAM";
            anArguements[5].item[1] = argumentList[5];

            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "SL1_TRACKNAM";
            anArguements[6].item[1] = argumentList[6];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWPdfDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWPDFDATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OBJECT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWShowAuthorityLimitsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOW_SHOW_AUTHORITY_LIMITS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "DATA_0";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWTaskDataCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWTASKDATA";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OBJECT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWTaskDeleteCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWTASKDELETE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OBJECT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWTaskStatusCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWTASKSTATUS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OBJECT_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWTaskUpdateCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOWTASKUPDATE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OBJECT_ID";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "STATUS";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "COMMENTS";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MoWVoidAuthorityCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "MOW_VOID_REQUEST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "DATA_0";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsCheckTrainSheetRecordExistsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "CHECK_TRAINSHEET_RECORD_EXIST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "OPSTA";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "PASS_COUNT";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "ACTIVITY_TYPE";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "DESTINATION";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsGetGroupCategoriesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GROUP_BOF_CATEGORIES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_GROUP";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsGetRangesCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "GET_BOF_DATERANGEDAYS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SCAC";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SECTION";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsGroupBOFExistsCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "CHECK_GROUP_BOF_EXISTS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_CATEGORY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_GROUP";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsPlanningCycleCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "MP_STATUS_CHANGE_REQUEST";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsScheduleExistsForDate2Call(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "SCHEDULE_BOF_EXISTS_FOR_DATE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SCAC";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SECTION";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "EFFECTIVE_FROM_DATE";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] MpsScheduleExistsForDateCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "CHECK_PERMSCHD_EXIST_FOR_DATE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SCAC";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SECTION";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "EFFECTIVE_FROM_DATE";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] OTCCrewLogoffCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "OTC_LOGOFF";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] OpenFormTaskListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "OPEN_FORM";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "COMMAND_KEY=OPEN_FORM";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "OBJECT_ID";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] OpenTrainClearanceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_SESSIONLESS";
            string aMethod = "SMI_TRAIN_CLEARANCE_SESSIONLESS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] OtcBulletinItemSendCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "BULLETIN_CONFIGURATION";
            string aMethod = "OTC_RESEND_BI";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "BULLETIN_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "ADDRESS";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "VOIDED";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] GetBulletinConfiguration(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "BULLETIN_CONFIGURATION";
            string aMethod = "GET_BULLETIN_CONFIGURATION";
            string aLanguage = language;
            string aUser = "";
            string aLogicalPosition = logicalPosition;
            string aClientId = logicalPosition+"TL";
      		stringArray[] anArguements = new stringArray[1];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "LOGICAL_POSITION";
            anArguements[0].item[1] = arguments;

            var smiResponse = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
         //   Report.Debug("Output", smiResponse.ToString());
            return smiResponse;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] PrepareChangeSetCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "FRONT_FLOW:div0";
            string aMethod = "FF_CHANGESET_PREPARATION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TDMS_LABEL_ID";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CHANGESET_ID_SELECTED";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] PrintCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "domain -->";
            string aMethod = "call -->";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "METHOD=";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DOMAIN_NAME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "AUTHORITY_ID";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] RefreshTaskListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TASK_LIST";
            string aMethod = "TASK_LIST_COMMAND";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "COMMAND_KEY";
            anArguements[0].item[1] = argumentList[0];

            var smiResponse = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", smiResponse.ToString());
            return smiResponse;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] RelayBulletinCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_SESSIONLESS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "BULLETIN_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_KEY";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "SHORT_TRAIN_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "ENGINE_OR_EMPLOYEE_NAME";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "ADDRESSEE_LOCATION";
            anArguements[4].item[1] = argumentList[4];

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "TIME_ZONE";
            anArguements[5].item[1] = argumentList[5];

            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "ADDRESSEE_TYPE";
            anArguements[6].item[1] = argumentList[6];

            anArguements[7] = new stringArray();
            anArguements[7].item = new String[2];
            anArguements[7].item[0] = "AUTHORITY_ID";
            anArguements[7].item[1] = argumentList[7];

            anArguements[8] = new stringArray();
            anArguements[8].item = new String[2];
            anArguements[8].item[0] = "OK_DATE_AND_TIME";
            anArguements[8].item[1] = argumentList[8];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] RemoveAddressLineCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "BULLETIN_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_KEY";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "ENGINE_OR_EMPLOYEE_NAME";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] RemoveTrainFromTrackingCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "REMOVE_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "OP_TIME";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "SESSION_ID";
            anArguements[2].item[1] = argumentList[2];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ResetTrainClearanceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] SetTrainClearanceAssociationListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "ASSOCIATE_TRAIN_KEY_LIST";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "ASSOCIATE_SHORT_TRAIN_ID_LIST";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "DISASSOCIATE_TRAIN_KEY_LIST";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "DISASSOCIATE_SHORT_TRAIN_ID_LIST";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] SetTrainClearanceDesignationCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SHORT_TRAIN_ID";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "DESIGNATION_NEW_TRAIN_ID";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "DESIGNATION_NEW_TRAIN_ID_KEY";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] SetTrainClearanceReleaseAndDeleteListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_SUMMARY_REQUEST";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] SetUserPreferenceCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "UM_ACCESS_CONTROLS";
            string aMethod = "SET_PREFERENCES";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "aKey:aPreference key-value pair";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] StartMovementPlanningCycleCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "MOVEMENT_PLANNING_STATUS_CHANGE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "REGION_ID";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TGBOMowTimerSmiCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TIMER_VALUE";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TabBasedTGBOSmiCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SELECTED_TAB";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CALL_TYPE";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TERMINAL_OR_DESK_NAME";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "EFFECTIVE_DATE";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "TRAIN_CLEARANCE_NUMBER";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TerminateShortCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_TRACKING";
            string aMethod = "TERMINATE_SHORT";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainClearanceSpecialInstructions(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SPECIAL_INSTRUCTIONS";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainClearanceValidateStationCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OPSTA";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainClearanceValidateStationListCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE";
            string aMethod = "TRAIN_CLEARANCE";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "key: key_value???";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainClearancesForTrainCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCES_FOR_TRAIN";
            string aMethod = "GET_TRAIN_CLEARANCES_FOR_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "REQUEST_LIST";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainGraphTopologyVersionCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TrainGraph:<logicalDivision>";
            string aMethod = "TRAIN_GRAPH_TOPOLOGY_VERSION";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainSheetIdentifyTrainCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "TRAIN_SHEET_IDENTIFY_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SECTION";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "SYMBOL";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "DAY";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "USER";
            anArguements[3].item[1] = argumentList[3];

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "CONTEXT";
            anArguements[4].item[1] = argumentList[4];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainSheetTerminateTrainCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "TERMINATE_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainSheetUnarriveTrainCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRT_TRAIN_SHEET";
            string aMethod = "UNARRIVE_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_ID_KEY";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] UnyieldingStatusCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "MPS";
            string aMethod = "UNYIELDING_STATUS";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "CALL_DATA_TRAIN_KEY";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "CALL_DATA_NEW_VALUE";
            anArguements[1].item[1] = argumentList[1];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] UpdatePTCTrainDisplayCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_SHEET_PTC";
            string aMethod = "UPDATE_PTC_TRAIN_DISPLAY";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_SCAC";
            anArguements[0].item[1] = argumentList[0];

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "TRAIN_SECTION";
            anArguements[1].item[1] = argumentList[1];

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "TRAIN_SYMBOL";
            anArguements[2].item[1] = argumentList[2];

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "TRAIN_ORIGIN_DATE";
            anArguements[3].item[1] = argumentList[3];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] ValidateStationCall(string factory, string language, string user, string logicalPosition, string client, string arguments)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = factory;
            string aDomain = "TRAIN_CLEARANCE_COMPARISON";
            string aMethod = "SMI_TRAIN_CLEARANCE_COMPARISON";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = client;
            string[] argumentList;
            if (arguments.Contains(";"))
            {
                argumentList = arguments.Split(';');
            }
            else
            {
                argumentList = new string[1];
                argumentList[0] = arguments;
            }
            stringArray[] anArguements = new stringArray[argumentList.Length];

            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "OPSTA";
            anArguements[0].item[1] = argumentList[0];

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] TrainTracking(string factory, string language, string user, string logicalPosition, string client, string trainkey,string deviceid)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRAIN_TRACKING_SMI_"+factory;
            string aDomain = "TRAIN_TRACKING";
            string aMethod = "MOVE_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = logicalPosition+"TL";
            
            stringArray[] anArguements = new stringArray[11];

            
            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "SOURCE_TRAIN_KEY";
            anArguements[0].item[1] = trainkey;

            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "DEVICE_ID";
            anArguements[1].item[1] = deviceid;

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "DEVICE_TYPE";
            anArguements[2].item[1] = "TRACK_LABEL_SYMBOL";

            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "TRACK_TYPE";
            anArguements[3].item[1] = "REGULAR";

            anArguements[4] = new stringArray();
            anArguements[4].item = new String[2];
            anArguements[4].item[0] = "LIST_TYPE";
            anArguements[4].item[1] = "ON_TRACK_LIST";

            anArguements[5] = new stringArray();
            anArguements[5].item = new String[2];
            anArguements[5].item[0] = "USER_ID";
            anArguements[5].item[1] = user;

            
            anArguements[6] = new stringArray();
            anArguements[6].item = new String[2];
            anArguements[6].item[0] = "SESSION_ID";
            anArguements[6].item[1] = logicalPosition+"TL";
            
            anArguements[7] = new stringArray();
            anArguements[7].item = new String[2];
            anArguements[7].item[0] = "OP_TIME";
            anArguements[7].item[1] = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")+ ".918-04:00 US/Eastern"; 
            
            	
            anArguements[8] = new stringArray();
            anArguements[8].item = new String[2];
            anArguements[8].item[0] = "LIST_POSITION";
            anArguements[8].item[1] = "";
             
            anArguements[9] = new stringArray();
            anArguements[9].item = new String[2];
            anArguements[9].item[0] = "TARGET_TRAIN_KEY";
            anArguements[9].item[1] = "0";
             
               anArguements[10] = new stringArray();
            anArguements[10].item = new String[2];
            anArguements[10].item[0] = "LIST_INDEX";
            anArguements[10].item[1] = "0";
            

            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }
        
        
    /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static stringArray[] removeTrainTracking(string factory, string language, string user, string logicalPosition, string client, string trainkey)
        {
            var bridge = new PDS_CORE.WebLogic.SmiBridgeService();

            string aFactory = "TRAIN_TRACKING_SMI_"+factory;
            string aDomain = "TRAIN_TRACKING";
            string aMethod = "REMOVE_TRAIN";
            string aLanguage = language;
            string aUser = user;
            string aLogicalPosition = logicalPosition;
            string aClientId = logicalPosition+"TL";
            
            stringArray[] anArguements = new stringArray[4];

            
            anArguements[0] = new stringArray();
            anArguements[0].item = new String[2];
            anArguements[0].item[0] = "TRAIN_KEY";
            anArguements[0].item[1] = trainkey;
            
            anArguements[1] = new stringArray();
            anArguements[1].item = new String[2];
            anArguements[1].item[0] = "OP_TIME";
            anArguements[1].item[1] = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")+ ".918-04:00 US/Eastern"; 

            anArguements[2] = new stringArray();
            anArguements[2].item = new String[2];
            anArguements[2].item[0] = "USER_ID";
            anArguements[2].item[1] = user;

            
            anArguements[3] = new stringArray();
            anArguements[3].item = new String[2];
            anArguements[3].item[0] = "SESSION_ID";
            anArguements[3].item[1] = logicalPosition+"TL";
            
            
            var rawr = bridge.smiBridge(aFactory, aDomain, aMethod, aLanguage, aUser, aLogicalPosition, aClientId, anArguements);
            Report.Debug("Output", rawr.ToString());
            return rawr;
        }

    }
    
    
    
    
}
