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
    public class SendMISMsmqCollection_CN
    {         
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void CreateTrainMsmq(string scac, string section, string trainSeed, string effectiveLocation, string effectivePasscount, string time, string timeZone, string timeType, string trainOrigin, string trainDestination) {
            
            if (time.Equals("") || time.Equals("current", StringComparison.OrdinalIgnoreCase)) {
            	time = System.DateTime.Now.ToString("hhmm");
            }
            
			string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
			trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_CreateTrainConfig.createCreateTrainConfigMsmq(scac, section, trainSymbol, effectiveLocation, effectivePasscount, time, timeZone, timeType,  trainOrigin, trainDestination, originDate);
           
        }
        
        
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
        public static void CreateScheduleMsmq(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup, 
                                          string originLocation, string terminationLocation, string stations) {
            
        	string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.createTrainID(trainSeed, originLocation, terminationLocation, section);
        	trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
        	string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleConfig.createTrainScheduleConfigMsmq(scac, section, trainSymbol, reportType, trainCategory, trainGroup, 
                                                                           originLocation, terminationLocation, stations,originDate);
        }
        
     
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// engines format is as follows with individual engines separated by |
        /// 
        /// ENGINE_INITIAL|ENGINE_NUMBER|ENGINE_POSITION
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createAutomaticEquipmentIdentifierMsmq(string scannerReportingKey, string eventalertEventType, string eventalertEventTypeZone, string direction, string engines)
            
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_AutomaticEquipmentIdentifier.createAutomaticEquipmentIdentifierMsmq(scannerReportingKey, eventalertEventType, eventalertEventTypeZone, direction, engines);
           
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createExternalAlertEventAckMsmq(string alertEventKey, string deviceType, string deviceID)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEventAck.createExternalAlertEventAckMsmq( alertEventKey,  deviceType, deviceID);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createExternalAlertEventMsmq(string protocolID, string msgID, string traceID, string messageVersion,
                                                    string alertEventKey, string alertEventType, string deviceType, string deviceID,
                                                    string milepost, string subdivision, string division, string direction, string start_time, 
                                                    string startTimeZone, string messageText)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEvent.createExternalAlertEventMsmq(protocolID, msgID, traceID, messageVersion, 
        	                                                             alertEventKey, alertEventType, deviceType, deviceID, 
        	                                                             milepost, subdivision, division, direction, start_time,
        	                                                             startTimeZone, messageText);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createEOTCabooseMsmq(string scac, string section, string trainSeed, string equipmentCode, string origin, 
                                                  string destination, string initial, string number, string workingStatus)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
        	STE.Code_Utils.messages.MIS.CN.MIS_EOTCabooseConfig.createEOTCabooseConfigMsmq(scac, section, trainSymbol, equipmentCode, origin, destination, initial, number, workingStatus);
           
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
        public static void createEngineConsistMsmq(string scac, string section, string trainSeed, string assignedDivision, string helperCrewPoolID, string reportingSource, 
                                                     string reportingLocation, string reportingPassCount, string defaultDataApplied, string purpose, string engines)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_EngineConsistConfig.createEngineConsistConfigMsmq(scac, section, trainSymbol, assignedDivision, helperCrewPoolID,
                                                                           reportingSource, reportingLocation, reportingPassCount, defaultDataApplied, purpose, engines,originDate);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void deleteTrainScheduleMsmq(string scac, string section, string trainSeed) 
        {		
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);            
            STE.Code_Utils.messages.MIS.CN.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfigMsmq( scac, section, trainSymbol);

        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCrewMemberMsmq(string scac, string section, string trainSeed, string crewID, 
                                                  string crewLineSegment, string sequenceNumber, string crewMemberRecords)
            
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_CrewMemberConfig.createCrewMemberConfigMsmq(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                     sequenceNumber, crewMemberRecords,originDate);
           
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
        public static void createCrewCallMsmq(string scac, string section, string trainSeed, string crewID, 
                                                string crewLineSegment, string sequenceNumber, string crewMemberRecords)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_CrewCallConfig.createCrewCallConfigMsmq(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                 sequenceNumber, crewMemberRecords);
           
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createHourlyWeatherMsmq(string operatorInitials, string state, string division, string stationID, string stationName, string time, string timeZone, 
                                                     string tmpf, string dwpf, string hum, string flk, string wdr, string wsp, string gst,  string max, string min, string pc1hr,
                                                     string pc6hr, string ssm, string ssp, string brmtr, string vis, string weather, string cvr, string wxw, string cond, string sunr, string suns)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_HourlyWeatherConfig.createHourlyWeatherConfigMsmq(operatorInitials, state, division, stationID, stationName, time, timeZone, tmpf, dwpf, hum, flk, wdr, 
                                                                           wsp, gst, max, min, pc1hr, pc6hr, ssm, ssp, brmtr, vis, weather, cvr, wxw, cond, sunr, suns);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createLocomotiveConsistMsmq(string scac, string section, string trainSeed, string reportingSource, string location, string loopCounter, string hexa, 
                                                         string engineInitial, string engineNumber, string positionInconsist, string originLocation, string destinationLocation,
                                                         string compensatedHP, string facingDirection, string status, string dpuStatus, string pts, string atcs, string verifiedToTrain, string hexaloop)
        {			 
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);            
            STE.Code_Utils.messages.MIS.CN.MIS_LocomotiveConsistConfig.createLocomotiveConsistConfigMsmq(scac, section, trainSymbol, reportingSource, location, loopCounter, hexa, engineInitial, engineNumber, positionInconsist, originLocation, 
                                                                                   destinationLocation, compensatedHP, facingDirection, status, dpuStatus, pts, atcs, verifiedToTrain, hexaloop);
           
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
        public static void createMovementInformationMsmq(string scac, string section, string trainSeed, string locationType, string dataLocation, string dataPassCount, string dataTrackName, 
                                                           string divisionNumber, string dataDivision, string dataDistrict, string direction, string typeOfReporting, string transmissionType, string reportingTime,
                                                           string reportingTimeZone, string currentCrewDest, string etaTime, string etaTimeZone, string alertEventKey, string deviceID, string ptas)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_MovementInformationConfig.createMovementInformationConfigMsmq(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
                                                                                       dataDistrict, direction, typeOfReporting, transmissionType,  reportingTime, reportingTimeZone,
                                                                                       currentCrewDest, etaTime, etaTimeZone, alertEventKey, deviceID, ptas);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createObjectiveFunctionMsmq(string type, string scac, string section, string trainSeed, string effectiveTime,  string trainGroup, string trainCategory, string stations, string intervals)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_ObjectiveFunctionConfig.createObjectiveFunctionConfigMsmq( type, scac, section, trainSymbol, effectiveTime,  trainGroup, trainCategory, stations, intervals);
           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createPartialScheduleAnnulmentMsmq(string scac, string section, string trainSeed, string fromLocation, string fromPassCount, string linkedTrainScac, 
                                                                string linkedTrainSection, string linkedTrainSymbol, string linkedTrainOriginTime)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_PartialScheduleAnnulmentConfig.createPartialScheduleAnnulmentConfigMsmq(scac, section, trainSymbol, fromLocation, fromPassCount, linkedTrainScac, linkedTrainSection,
                                                                                                 linkedTrainSymbol, linkedTrainOriginTime);
           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createRailCarConsistMsmq(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string carData)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
        	STE.Code_Utils.messages.MIS.CN.MIS_RailCarConsistConfig.createRailCarConsistConfigMsmq(scac, section, trainSymbol, reportingLocation, reportingPassCount, carData);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createResourceAvailabilityMsmq(string scac, string section, string trainSeed, string location, string locationPassCount, string availableTime, string availableTimeZone, string resourceType)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_ResourceAvailabilityConfig.createResourceAvailabilityConfigMsmq(scac, section, trainSymbol, location, locationPassCount, availableTime, availableTimeZone, resourceType);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void terminateTrainMsmq(string scac, string section, string trainSeed, string deleteTrainFlag)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_TerminateTrainConfig.createTerminateTrainConfigMsmq(scac, section, trainSymbol, deleteTrainFlag);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainActivityLinkMsmq(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac, 
                                                         string toSection, string toTrainSymbol, string toOriginTime, string linkUnlink, string linkLocation)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_TrainActivityLinkConfig.createTrainActivityLinkConfigMsmq(fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection, 
                                                                                   toTrainSymbol, toOriginTime, linkUnlink, linkLocation);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainConsistMsmq(string scac, string section, string trainSeed, string locationOfUpdate, string numberOfLoadsInTrain, string numberOfEmptiesInTrain, 
                                                    string trailingTonnage, string trainLength, string loopCounter, string hexa, string consistOperation, string location, string numberOfLoads,
                                                    string numberOfEmpties, string tonnage, string length, string hexaloop)
        {		
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed); 
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);            
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistConfig.createTrainConsistConfigMsmq(scac, section, trainSymbol, locationOfUpdate, numberOfLoadsInTrain, numberOfEmptiesInTrain, trailingTonnage, 
                                                                         trainLength, loopCounter, hexa, consistOperation, location, numberOfLoads, numberOfEmpties, tonnage, length, hexaloop);
        }
        
       
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// pickupsetOutRecords format is as follows with individual records separated by a |
        /// 
        /// REPORT_CONSIST_CHANGE_FLAG|CONSIST_OPERATION|numberOfLoads|numberOfEmpties|TONNAGE|LENGTH|COAL_INDICATOR|
        /// COAL_PERMIT_NUMBER|NOTE|COMPLETION_STATUS|COMPLETION_DATE|COMPLETION_TIME|COMPLETION_timeZone|NEED_DATE|
        /// NEED_TIME|NEED_timeZone|AXLES|operativeBrakes|totalBrakingForce
        /// 
        /// coalClassificationRecords format is as follows with individual records separated by a |
        /// COAL_CLASSIFICATION|NUMBER_OF_CARS
        /// 
        /// </summary>
        [UserCodeMethod]
        public static void createTrainConsistActivityMsmq(string scac, string section, string trainSeed, string location, string passCount, string reportingSource, 
                                                            string estimatedDwellInterval, string maxCarWeightConstraintIndicator, string maxCarWeight, string maxCarWeightTo,
                                                            string maxCarWeightToPassCount, string maxCarHeightConstraintIndicator, string maxCarHeight, string maxCarHeightTo,
                                                            string maxCarHeightToPassCount, string maxCarWidthConstraintIndicator, string maxCarWidth, string maxCarWidthTo,
                                                            string maxCarWidthToPassCount, string hazmatTrainConstraintIndicator, string keyTrainIndicator, string hazmatTrainTo,
                                                            string hazmatTrainToPassCount, string pickupsetOutRecords, string coalClassificationRecords)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistActivityConfig.createTrainConsistActivityConfigMsmq(scac, section, trainSymbol, location, passCount, reportingSource, estimatedDwellInterval,
                                                                                         maxCarWeightConstraintIndicator, maxCarWeight, maxCarWeightTo, maxCarWeightToPassCount,
                                                                                         maxCarHeightConstraintIndicator, maxCarHeight, maxCarHeightTo, maxCarHeightToPassCount,
                                                                                         maxCarWidthConstraintIndicator, maxCarWidth, maxCarWidthTo, maxCarWidthToPassCount,
                                                                                         hazmatTrainConstraintIndicator, keyTrainIndicator, hazmatTrainTo, hazmatTrainToPassCount,
                                                                                         pickupsetOutRecords, coalClassificationRecords);
           
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
        /// 
        [UserCodeMethod]
        public static void createTrainConsistSummaryMsmq(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                           string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                           string totalBrakingForce, string speedConstraint, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string tihConstraints)  
        {
            createTrainConsistSummaryMsmq(scac, section, trainSeed, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize,
                                                           numberOfLoads, numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes,
                                                           totalBrakingForce, speedConstraint, maxCarWeights, maxCarHeights, maxCarWidths, hazmatConstraints, tihConstraints, "R");  
        }
        
        [UserCodeMethod]
        public static void createTrainConsistSummaryMsmq(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                           string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                           string totalBrakingForce, string speedConstraint, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string tihConstraints, string purpose = "R")
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfigMsmq(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                       numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                       maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, tihConstraints,originDate, purpose);
           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainDelayMsmq(string scac, string section, string trainSeed, string fromDivision, string fromDistrict, string fromLocationType, string fromLocation, 
                                                  string endDivision, string endDistrict, string endLocationType, string endLocation, string delayRecordID, string delayCode, 
                                                  string transmissionType, string userID, string beginDelayTime, string beginDelayTimeZone, string endDelayTime, string endDelayTimeZone, 
                                                  string delayDuration, string crewID, string crewLineSegment, string freeFormText, string field1, string field2, string field3, string field4, 
                                                  string field5, string field6, string field7, string field8)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainDelayConfig.createTrainDelayConfigMsmq( scac, section, trainSymbol, fromDivision, fromDistrict, fromLocationType, fromLocation, endDivision, endDistrict, endLocationType,
                                                                     endLocation, delayRecordID, delayCode, transmissionType, userID, beginDelayTime, beginDelayTimeZone, endDelayTime, endDelayTimeZone, 
                                                                     delayDuration, crewID, crewLineSegment, freeFormText, field1, field2, field3, field4, field5, field6, field7, field8);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTRAINOSCONFIGMsmq(string scac, string section, string trainSeed,  string stationSequenceNumber, string osLocation, string cpLocation, string direction, 
                                               string reportingType, string transmissionType,  string osTime, string osTimeZone, string currentCrewDestination, string etaTime, 
                                               string etaTimeZone, string reporting)
        {		
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TRAINOSCONFIG.createTRAINOSCONFIGMsmq(scac, section, trainSymbol,  stationSequenceNumber, osLocation, cpLocation, direction, reportingType, transmissionType,
                                                               osTime, osTimeZone, currentCrewDestination, etaTime, etaTimeZone, reporting);
           
        }
               
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleAdherenceMsmq(string scac, string section, string trainSeed, string adherence)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleAdherence.createTrainScheduleAdherenceMsmq(scac, section, trainSymbol, adherence);
           
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleAnnulmentConfigMsmq(string scac, string section, string trainSeed) 
        {			            
            string trainSymbol;
            if (trainSeed.Length == 2)
            {
                trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            }
            else
            {
                trainSymbol = trainSeed;
            }
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleAnnulmentConfig.createTrainScheduleAnnulmentConfigMsmq( scac, section, trainSymbol);           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleComboMsmq(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac, string toSection, 
                                                          string toTrainSymbol, string toOriginTime, string linkAndAnnulFromLocation, string linkAndAnnulFromPassCount, 
                                                          string unlinkAndAnnulToLocation, string unlinkAndAnnulToPassCount)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleComboConfig.createTrainScheduleComboConfigMsmq(fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection, toTrainSymbol, toOriginTime, 
                                                                                     linkAndAnnulFromLocation, linkAndAnnulFromPassCount, unlinkAndAnnulToLocation, unlinkAndAnnulToPassCount);
           
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// 
        /// stations format is as follows with individual stations separated by a | between ANNUL_COMBO_DIVERT and STATION_LOCATION:
        /// 
        /// STATION_LOCATION|DAY_OF_STA|STA|STA_ZONE|DAY_OF_STD|STD|STD_ZONE|CREW_CHANGE|crewLineSegment|
        /// setOutPICKUP|FUEL|INSPECTION|PASSENGER_STOP|EXIT_TO_FOREIGN_RAILROAD|TURN_POIN|ANNUL_COMBO_DIVERT
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleDiversionMsmq(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup, 
                                                              string originLocation, string terminationLocation, string stations)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleDiversionConfig.createTrainScheduleDiversionConfigMsmq( scac, section, trainSymbol, reportType, trainCategory, trainGroup, originLocation, terminationLocation, stations);
           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTRAINSCHEDULECONFIGMsmq(string scac, string section, string trainSeed, string commonName, string effectiveTimeBegin, string effectiveTimeEnd, string trainCategory, string trainSub, 
                                                     string trainType, string operatingDays, string origin, string termination, string loopCounter, string hexa, string stationSequenceNumber, string stationName, 
                                                     string direction, string dayOfETA, string eta, string dayOfETC, string etc, string dayOfETD, string etd, string crewChange, string reportingType, string setOut, 
                                                     string pickup, string fuel, string inspection, string maxCars, string maxTonnage, string maxTrainLength, string minhp, string speedRestriction, string dpu, string hexaloop)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TRAINSCHEDULECONFIG.createTRAINSCHEDULECONFIGMsmq(scac, section, trainSymbol, commonName, effectiveTimeBegin, effectiveTimeEnd, trainCategory, trainSub, trainType, operatingDays,
                                                                           origin, termination, loopCounter, hexa, stationSequenceNumber, stationName, direction, dayOfETA, eta, dayOfETC, etc,dayOfETD, etd, 
                                                                           crewChange, reportingType, setOut, pickup, fuel, inspection, maxCars, maxTonnage, maxTrainLength, minhp, speedRestriction, dpu, hexaloop);
           
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleLinkMsmq(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac, string toSection, string toTrainSymbol, 
                                                         string toOriginTime, string linkUnlink, string linkLocation)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleLinkConfig.createTrainScheduleLinkConfigMsmq( fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection, toTrainSymbol, toOriginTime, linkUnlink, linkLocation);
           
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainSegmentMsmq(string scac, string section, string trainSeed, string effectiveLocation, string effectivePassCount, string timeZone, string timeType, 
                                                    string trainOrigin, string trainDestination)

        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
			string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainSegmentConfig.createTrainSegmentConfigMsmq(scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination,originDate);
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
        public static void createWeatherAlertMsmq(string protocolID, string msgID, string traceID, string messageVersion, string wxReportID, string operatorInitials, string state, string division, 
                                                    string wxMsgType, string wxCode, string wxCondition, string wxSeverity, string wxDescription, string wxDetails, string timeZone,  string inEffectTime, 
                                                    string untilTime, string wxRecipientID, string wxWarningNumber, string wxWarningVersion, string stations)
        {			            
            STE.Code_Utils.messages.MIS.CN.MIS_WeatherAlertConfig.createWeatherAlertConfigMsmq(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity, 
                                                                         wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations);
        }        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createYardUpdateMsmq(string location,string scac, string section, string trainSeed,  string inboundOutbound, string assignedTrack, string milepost, string district, 
                                                  string outboundTargetTime, string outboundTargetTimeZone, string reasonText, string racfUserID)
        {			            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_YardUpdateConfig.createYardUpdateConfigMsmq(location, scac, section, trainSymbol, inboundOutbound, assignedTrack, milepost, district, outboundTargetTime,
                                                                     outboundTargetTimeZone, reasonText, racfUserID);
           
        }
    }
}
