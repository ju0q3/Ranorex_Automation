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
    public class SendMISRemoteCollection_CN
    {         

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// 
        /// stations format is as follows with individual stations separated by a | between PTC_TRAIN_DEPARTURE and STATION_SEQ_NUM
        /// 
        /// STATION_SEQ_NUM|STATION_LOCATION|DAY_OF_STA|STA_TIME|STA_ZONE|DAY_OF_STD|STD_TIME|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOut|PICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POINT|PTC_TRAIN_ARRIVAL|PTC_TRAIN_DEPARTURE
        /// </summary>
        [UserCodeMethod]
        public static void CreateScheduleRemote(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup, 
                                          string originLocation, string terminationLocation, string stations, string hostname) {
            
        	string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.createTrainID(trainSeed,originLocation, terminationLocation, section);
        	trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
        	System.DateTime now = System.DateTime.Now;
        	string originDate=  now.ToString("MMddyyyy");
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleConfig.createTrainScheduleConfigRemote(scac, section, trainSymbol, reportType, trainCategory, trainGroup, 
                                                                           originLocation, terminationLocation, stations, originDate,hostname);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// engines format is as follows with individual engines separated by |
        /// 
        /// ENGINE_INITIAL|ENGINE_NUMBER|ENGINE_POSITION|ENGINE_ORIENTATION|ENGINE_LOCK|ORIGIN_passCount|originLocation|
        /// DESTINATION_passCount|DESTINATION_LOCATION|COMPENSATED_HP|GROUP_NUMBER|MODEL|ENGINE_STATUS|DPU_STATUS|
        /// PTS_EQUIPPED|PTC_EQUIPPED|LSL_EQUIPPED|CS_EQUIPPED|NOTES|LAST_SERVICE_TIME|LAST_SERVICE_LOCATION|SHUCKER_DEVICE|
        /// TEST_DUE_TIME|TEST_DUE_LOCATION|LAST_FUEL_TIME|LAST_FUEL_LOCATION
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createEngineConsistRemote(string scac, string section, string trainSeed, string assignedDivision, string helperCrewPoolID, string reportingSource, 
                                                     string reportingLocation, string reportingPassCount, string defaultDataApplied, string purpose, string engines, string hostname)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_EngineConsistConfig.createEngineConsistConfigRemote(scac, section, trainSymbol, assignedDivision, helperCrewPoolID,
                                                                           reportingSource, reportingLocation, reportingPassCount, defaultDataApplied, purpose, engines, originDate,hostname);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void deleteTrainScheduleRemote(string scac, string section, string trainSeed, string hostname) 
        {		
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);            
            STE.Code_Utils.messages.MIS.CN.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfigRemote( scac, section, trainSymbol, hostname);

        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCrewMemberRemote(string scac, string section, string trainSeed, string crewID, 
                                                  string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname)
            
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_CrewMemberConfig.createCrewMemberConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                     sequenceNumber, crewMemberRecords,originDate, hostname);
           
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
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_CrewCallConfig.createCrewCallConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
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
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_MovementInformationConfig.createMovementInformationConfigRemote(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
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
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_TerminateTrainConfig.createTerminateTrainConfigRemote(scac, section, trainSymbol, deleteTrainFlag, hostname);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// max_car_weighs format is as follows with individual weights separated by a |
        /// maxCarWeight|maxCarWeightTo|maxCarWeightToPassCount
        /// 
        /// maxCarHeights format is as follows with individual heights separated by a |
        /// maxCarHeight|maxCarHeightTo|maxCarHeightToPassCount        
        /// 
        /// maxCarWidths format is as follows with individual widths separated by a |
        /// maxCarWidth|maxCarWidthTo|maxCarWidthToPassCount
        /// 
        /// hazmatConstraints format is as follows with individual constraints separated by a |
        /// keyTrainIndicator|hazmatTrainTo|KEY_TRAIN_TO_passCount
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createTrainConsistSummaryRemote(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize, 
                                                           string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                           string totalBrakingForce, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string tihConstraints, string hostname, string purpose = "R")
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfigRemote(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                       numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                       maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, tihConstraints,originDate, purpose, hostname);
           
        }
           
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainSegmentRemote( string scac,string section, string trainSeed, string effectiveLocation, string effectivePassCount, string timeZone, string timeType, 
                                                    string trainOrigin, string trainDestination, string hostname)

        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainSegmentConfig.createTrainSegmentConfigRemote( scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination, originDate ,hostname);
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
            STE.Code_Utils.messages.MIS.CN.MIS_WeatherAlertConfig.createWeatherAlertConfigRemote(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity, 
                                                                         wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations, hostname);
        }        
    }
}
