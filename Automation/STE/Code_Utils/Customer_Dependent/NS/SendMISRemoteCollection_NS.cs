/*
 * Created by Ranorex
 * User: 210057585
 * Date: 12/11/2017
 * Time: 11:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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

namespace STE.Code_Utils
{
    /// <summary>
    /// Ranorex User Code collection. A collection is used to publish User Code methods to the User Code library.
    /// </summary>
    [UserCodeCollection]
    public class SendMISRemoteCollection_NS
    {
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void deleteTrainScheduleRemote(string scac, string section, string trainSeed, string hostname) 
        {		
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);       
            STE.Code_Utils.messages.MIS.NS.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfigRemote( scac, section, trainSymbol, hostname);

        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// crewMemberRecords format is as follows with individual crew members separated by |
        /// 
        /// ON_DUTY_LOCATION|OFF_DUTY_LOCATION|ON_TRAIN_LOCATION|ON_TRAIN_passCount|ON_TRAIN_LOCATION_MP|OFF_TRAIN_LOCATION|
        /// OFF_TRAIN_passCount|OFF_TRAIN_LOCATION_MP|CREW_POSITION|CREW_MEMBER_TYPE|FIRST_INITIAL|MIDDLE_INITIAL|LAST_NAME|
        /// SOCIAL_SECURITY_NO|EMPLOYEE_ID|ON_DUTY_TIME|ON_DUTY_timeZone|ON_TRAIN_TIME|ON_TRAIN_timeZone|HOS_EXPIRE_TIME|
        /// HOSE_EXPIRE_timeZone|OFF_DUTY_TIME|OFF_DUTY_timeZone|OFF_TRAIN_TIME|OFF_TRAIN_timeZone|DEST_TRAIN_SCAC|
        /// DEST_TRAIN_SECTION|DEST_trainSymbol|DEST_trainOrigin_TIME
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createCrewCallRemote(string scac, string section, string trainSeed, string crewID, 
                                                string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            STE.Code_Utils.messages.MIS.NS.MIS_CrewCallConfig.createCrewCallConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                 sequenceNumber, crewMemberRecords, hostname);
           
        }
      
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// ptas format is as follows with individual ptas separated by a |
        /// ACTIVITY_TYPE|NEXT_ACTIVITY_LOCATION|PTA_DATE|PTA_TIME|PTA_timeZone
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createMovementInformationRemote(string scac, string section, string trainSeed, string locationType, string dataLocation, string dataPassCount, string dataTrackName, 
                                                           string divisionNumber, string dataDivision, string dataDistrict, string direction, string typeOfReporting, string transmissionType, string reportingTime,
                                                           string reportingTimeZone, string currentCrewDest, string etaTime, string etaTimeZone, string alertEventKey, string deviceID, string ptas, string hostname)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            STE.Code_Utils.messages.MIS.NS.MIS_MovementInformationConfig.createMovementInformationConfigRemote(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
                                                                                       dataDistrict, direction, typeOfReporting, transmissionType,  reportingTime, reportingTimeZone,
                                                                                       currentCrewDest, etaTime, etaTimeZone, alertEventKey, deviceID, ptas, hostname);
           
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void terminateTrainRemote(string scac, string section, string trainSeed, string deleteTrainFlag, string hostname)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
        	STE.Code_Utils.messages.MIS.NS.MIS_TerminateTrainConfig.createTerminateTrainConfigRemote(scac, section, trainSymbol, deleteTrainFlag, hostname);
        }
              
       

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        ///  string stationID, string stationName,
        ///                                            string from_subdivision, string milepost, string to_milepost, string crossing
        /// </summary>
        [UserCodeMethod]
        public static void createWeatherAlertRemote(string protocolID, string msgID, string traceID, string messageVersion, string wxReportID, string operatorInitials, string state, string division, 
                                                    string wxMsgType, string wxCode, string wxCondition, string wxSeverity, string wxDescription, string wxDetails, string timeZone,  string inEffectTime, 
                                                    string untilTime, string wxRecipientID, string wxWarningNumber, string wxWarningVersion, string stations, string hostname)
        {			            
            STE.Code_Utils.messages.MIS.NS.MIS_WeatherAlertConfig.createWeatherAlertConfigRemote(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity, 
                                                                         wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations, hostname);
        }        
    }
}
