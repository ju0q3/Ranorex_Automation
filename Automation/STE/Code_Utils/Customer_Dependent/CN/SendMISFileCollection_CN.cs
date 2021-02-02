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
    public class SendMISFileCollection_CN
    {
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void CreateTrain(string scac, string section, string trainSeed, string effectiveLocation, string effectivePasscount, string time, string timeZone, string timeType, string trainOrigin, string trainDestination) {
            
            if (time.Equals("") || time.Equals("current", StringComparison.OrdinalIgnoreCase)) {
                time = System.DateTime.Now.ToString("hhmm");
            }
            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_CreateTrainConfig.createCreateTrainConfig(scac, section, trainSymbol, effectiveLocation, effectivePasscount, time, timeZone, timeType,  trainOrigin, trainDestination, originDate);
            
        }
        
        /// </summary>
        [UserCodeMethod]
        public static void CreateTrainWithDefaults(string trainSeed, string trainOrigin, string trainDestination)
        {
            string scac = "CN";
            string section = "1";
            string effectivePasscount = "1";
            string time = "0";
            string timeZone = "E";
            string timeType = "C";
            string effectiveLocation = trainOrigin;
            
            CreateTrain(scac, section, trainSeed, effectiveLocation, effectivePasscount, time, timeZone, timeType, trainOrigin, trainDestination);
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
        public static void CreateSchedule(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup,
                                          string originLocation, string terminationLocation, string stations, string hostname="local") {
            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.createTrainID(trainSeed, originLocation, terminationLocation, section);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            System.DateTime now = System.DateTime.Now;
            string originDate = now.ToString("MMddyyyy");
            PDS_CORE.Code_Utils.CN_TrainID.setOriginDate(trainSeed,originDate);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleConfig.createTrainScheduleConfig(scac, section, trainSymbol, reportType, trainCategory, trainGroup,
                                                                                                 originLocation, terminationLocation, stations,originDate);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleConfig.createTrainScheduleConfigRemote(scac, section, trainSymbol, reportType, trainCategory, trainGroup,
                                                                                                       originLocation, terminationLocation, stations,originDate, hostname);
            }
        }
        
        [UserCodeMethod]
        public static void CreateSchedule(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup,
                                          string originLocation, string terminationLocation, string stations) {
            
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.createTrainID(trainSeed, originLocation, terminationLocation, section);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            System.DateTime now = System.DateTime.Now;
            string originDate= now.ToString("MMddyyyy");
            PDS_CORE.Code_Utils.CN_TrainID.getTrainObject(trainSeed).originOpsta = originLocation;
            PDS_CORE.Code_Utils.CN_TrainID.getTrainObject(trainSeed).destOpsta = terminationLocation;

            PDS_CORE.Code_Utils.CN_TrainID.setOriginDate(trainSeed,originDate);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleConfig.createTrainScheduleConfig(scac, section, trainSymbol, reportType, trainCategory, trainGroup,
                                                                                             originLocation, terminationLocation, stations,originDate);
        }
        
        [UserCodeMethod]
        public static void CreateScheduleWithDefaults(string trainSeed, string originLocation, string terminationLocation)
        {
            string scac = "CN";
            string section = "1";
            string reportType = "3";
            string trainCategory = "3";
            string trainGroup = "FRT";
            string stations = "Defaults";
            
            CreateSchedule(scac, section, trainSeed, reportType, trainCategory, trainGroup, originLocation, terminationLocation, stations);
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
        public static void createAutomaticEquipmentIdentifier(string scannerReportingKey, string eventalertEventType, string eventalertEventTypeZone, string direction, string engines)
            
        {
            STE.Code_Utils.messages.MIS.CN.MIS_AutomaticEquipmentIdentifier.createAutomaticEquipmentIdentifier(scannerReportingKey, eventalertEventType, eventalertEventTypeZone, direction, engines);
            
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createExternalAlertEventAck(string alertEventKey, string deviceType, string deviceID)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEventAck.createExternalAlertEventAck( alertEventKey,  deviceType, deviceID);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createExternalAlertEvent(string protocolID, string msgID, string traceID, string messageVersion,
                                                    string alertEventKey, string alertEventType, string deviceType, string deviceID,
                                                    string milepost, string subdivision, string division, string direction, string start_time,
                                                    string startTimeZone, string messageText)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEvent.createExternalAlertEvent(protocolID, msgID, traceID, messageVersion,
                                                                                           alertEventKey, alertEventType, deviceType, deviceID, milepost, subdivision,
                                                                                           division, direction, start_time, startTimeZone, messageText);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createExternalAlertEvent(string protocolID, string msgID, string traceID, string messageVersion,
                                                    string alertEventKey, string alertEventType, string deviceType, string deviceID,
                                                    string milepost, string subdivision, string division, string direction, string start_time,
                                                    string startTimeZone, string messageText,string hostname="local")
        {

            if (hostname.Equals("local"))
            {
                
                STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEvent.createExternalAlertEvent(protocolID, msgID, traceID, messageVersion,
                                                                                               alertEventKey, alertEventType, deviceType, deviceID, milepost, subdivision,
                                                                                               division, direction, start_time, startTimeZone, messageText);
            }
            else
            {
                
                STE.Code_Utils.messages.MIS.CN.MIS_ExternalAlertEvent.createExternalAlertEventRemote(protocolID, msgID, traceID, messageVersion,
                                                                                                     alertEventKey, alertEventType, deviceType, deviceID, milepost, subdivision,
                                                                                                     division, direction, start_time, startTimeZone, messageText,hostname);
            }
            
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createEOTCaboose(string scac, string section, string trainSeed, string equipmentCode, string origin,
                                            string destination, string initial, string number, string workingStatus)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_EOTCabooseConfig.createEOTCabooseConfig(scac, section, trainSymbol, equipmentCode, origin, destination, initial, number, workingStatus,originDate);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createEOTCaboose(string scac, string section, string trainSeed, string equipmentCode, string origin,
                                            string destination, string initial, string number, string workingStatus, string hostname)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_EOTCabooseConfig.createEOTCabooseConfigRemote(scac, section, trainSymbol, equipmentCode, origin, destination, initial, number, workingStatus, originDate, hostname);
            
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
        public static void createEngineConsist(string scac, string section, string trainSeed, string assignedDivision, string helperCrewPoolID, string reportingSource,
                                               string reportingLocation, string reportingPassCount, string defaultDataApplied, string purpose, string engines, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            
            PDS_CORE.Code_Utils.CN_TrainID.SetEnginesStringByTrainseed(trainSeed, engines);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_EngineConsistConfig.createEngineConsistConfig(scac, section, trainSymbol, assignedDivision, helperCrewPoolID,
                                                                                                 reportingSource, reportingLocation, reportingPassCount, defaultDataApplied, purpose, engines,originDate);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_EngineConsistConfig.createEngineConsistConfigRemote(scac, section, trainSymbol, assignedDivision, helperCrewPoolID,
                                                                                                       reportingSource, reportingLocation, reportingPassCount, defaultDataApplied, purpose, engines, originDate,hostname);
                
            }
            
        }
        
        [UserCodeMethod]
        public static void createEngineConsist(string scac, string section, string trainSeed, string assignedDivision, string helperCrewPoolID, string reportingSource,
                                               string reportingLocation, string reportingPassCount, string defaultDataApplied, string purpose, string engines)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            
            PDS_CORE.Code_Utils.CN_TrainID.SetEnginesStringByTrainseed(trainSeed, engines);
            
            STE.Code_Utils.messages.MIS.CN.MIS_EngineConsistConfig.createEngineConsistConfig(scac, section, trainSymbol, assignedDivision, helperCrewPoolID,
                                                                                             reportingSource, reportingLocation, reportingPassCount, defaultDataApplied, purpose, engines,originDate);
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void deleteTrainSchedule(string scac, string section, string trainSeed, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfig( scac, section, trainSymbol);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfigRemote( scac, section, trainSymbol, hostname);
            }

        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createCrewMember(string scac, string section, string trainSeed, string crewID,
                                            string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname="local")
            
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_CrewMemberConfig.createCrewMemberConfig(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                                           sequenceNumber, crewMemberRecords,originDate);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_CrewMemberConfig.createCrewMemberConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                                                 sequenceNumber, crewMemberRecords, originDate, hostname);
            }
            
        }
        
        [UserCodeMethod]
        public static void createCrewMember(string scac, string section, string trainSeed, string crewID,
                                            string crewLineSegment, string sequenceNumber, string crewMemberRecords)
            
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_CrewMemberConfig.createCrewMemberConfig(scac, section, trainSymbol, crewID, crewLineSegment,
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
        public static void createCrewCall(string scac, string section, string trainSeed, string crewID,
                                          string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_CrewCallConfig.createCrewCallConfig(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                                       sequenceNumber, crewMemberRecords);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_CrewCallConfig.createCrewCallConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
                                                                                             sequenceNumber, crewMemberRecords, hostname);
            }
            
        }

        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createHourlyWeather(string operatorInitials, string state, string division, string stationID, string stationName, string time, string timeZone,
                                               string tmpf, string dwpf, string hum, string flk, string wdr, string wsp, string gst,  string max, string min, string pc1hr,
                                               string pc6hr, string ssm, string ssp, string brmtr, string vis, string weather, string cvr, string wxw, string cond, string sunr, string suns)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_HourlyWeatherConfig.createHourlyWeatherConfig(operatorInitials, state, division, stationID, stationName, time, timeZone, tmpf, dwpf, hum, flk, wdr,
                                                                                             wsp, gst, max, min, pc1hr, pc6hr, ssm, ssp, brmtr, vis, weather, cvr, wxw, cond, sunr, suns);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createLocomotiveConsist(string scac, string section, string trainSeed, string reportingSource, string location, string loopCounter, string hexa,
                                                   string engineInitial, string engineNumber, string positionInconsist, string originLocation, string destinationLocation,
                                                   string compensatedHP, string facingDirection, string status, string dpuStatus, string pts, string atcs, string verifiedToTrain, string hexaloop)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_LocomotiveConsistConfig.createLocomotiveConsistConfig(scac, section, trainSymbol, reportingSource, location, loopCounter, hexa, engineInitial, engineNumber, positionInconsist, originLocation,
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
        public static void createMovementInformation(string scac, string section, string trainSeed, string locationType, string dataLocation, string dataPassCount, string dataTrackName,
                                                     string divisionNumber, string dataDivision, string dataDistrict, string direction, string typeOfReporting, string transmissionType, string reportingTime,
                                                     string reportingTimeZone, string currentCrewDest, string etaTime, string etaTimeZone, string alertEventKey, string deviceID, string ptas, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_MovementInformationConfig.createMovementInformationConfig(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
                                                                                                             dataDistrict, direction, typeOfReporting, transmissionType,  reportingTime, reportingTimeZone,
                                                                                                             currentCrewDest, etaTime, etaTimeZone, alertEventKey, deviceID, ptas);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_MovementInformationConfig.createMovementInformationConfigRemote(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
                                                                                                                   dataDistrict, direction, typeOfReporting, transmissionType,  reportingTime, reportingTimeZone,
                                                                                                                   currentCrewDest, etaTime, etaTimeZone, alertEventKey, deviceID, ptas, hostname);
            }
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createObjectiveFunction(string type, string scac, string section, string trainSeed, string effectiveTime,  string trainGroup, string trainCategory, string stations, string intervals)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_ObjectiveFunctionConfig.createObjectiveFunctionConfig( type, scac, section, trainSymbol, effectiveTime,  trainGroup, trainCategory, stations, intervals);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createPartialScheduleAnnulment(string scac, string section, string trainSeed, string fromLocation, string fromPassCount, string linkedTrainScac,
                                                          string linkedTrainSection, string linkedTrainSymbol, string linkedTrainOriginTime)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_PartialScheduleAnnulmentConfig.createPartialScheduleAnnulmentConfig(scac, section, trainSymbol, fromLocation, fromPassCount, linkedTrainScac, linkedTrainSection,
                                                                                                                   linkedTrainSymbol, linkedTrainOriginTime);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createRailCarConsist(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string carData)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_RailCarConsistConfig.createRailCarConsistConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, carData, originDate);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createRailCarConsist(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string carData, string hostname)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_RailCarConsistConfig.createRailCarConsistConfigRemote(scac, section, trainSymbol, reportingLocation, reportingPassCount, carData, originDate, hostname);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createResourceAvailability(string scac, string section, string trainSeed, string location, string locationPassCount, string availableTime, string availableTimeZone, string resourceType)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_ResourceAvailabilityConfig.createResourceAvailabilityConfig( scac, section, trainSymbol, location, locationPassCount, availableTime, availableTimeZone, resourceType);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void terminateTrain(string scac, string section, string trainSeed, string deleteTrainFlag, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDateNoSection(trainSeed);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TerminateTrainConfig.createTerminateTrainConfig(scac, section, trainSymbol, deleteTrainFlag);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TerminateTrainConfig.createTerminateTrainConfigRemote(scac, section, trainSymbol, deleteTrainFlag, hostname);
            }
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainActivityLink(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac,
                                                   string toSection, string toTrainSymbol, string toOriginTime, string linkUnlink, string linkLocation)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_TrainActivityLinkConfig.createTrainActivityLinkConfig(fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection,
                                                                                                     toTrainSymbol, toOriginTime, linkUnlink, linkLocation);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainConsist(string scac, string section, string trainSeed, string locationOfUpdate, string numberOfLoadsInTrain, string numberOfEmptiesInTrain,
                                              string trailingTonnage, string trainLength, string loopCounter, string hexa, string consistOperation, string location, string numberOfLoads,
                                              string numberOfEmpties, string tonnage, string length, string hexaloop)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistConfig.createTrainConsistConfig(scac, section, trainSymbol, locationOfUpdate, numberOfLoadsInTrain, numberOfEmptiesInTrain, trailingTonnage,
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
        public static void createTrainConsistActivity(string scac, string section, string trainSeed, string location, string passCount, string reportingSource,
                                                      string estimatedDwellInterval, string maxCarWeightConstraintIndicator, string maxCarWeight, string maxCarWeightTo,
                                                      string maxCarWeightToPassCount, string maxCarHeightConstraintIndicator, string maxCarHeight, string maxCarHeightTo,
                                                      string maxCarHeightToPassCount, string maxCarWidthConstraintIndicator, string maxCarWidth, string maxCarWidthTo,
                                                      string maxCarWidthToPassCount, string hazmatTrainConstraintIndicator, string keyTrainIndicator, string hazmatTrainTo,
                                                      string hazmatTrainToPassCount, string pickupsetOutRecords, string coalClassificationRecords)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistActivityConfig.createTrainConsistActivityConfig(scac, section, trainSymbol, originDate, location, passCount, reportingSource, estimatedDwellInterval,
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
        public static void createTrainConsistSummary(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                     string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                     string totalBrakingForce, string speedConstraint, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string TIHconstraints, string hostname="local")
        {
            createTrainConsistSummary(scac, section, trainSeed, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize,
                                      numberOfLoads, numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes,
                                      totalBrakingForce, speedConstraint, maxCarWeights, maxCarHeights, maxCarWidths, hazmatConstraints, TIHconstraints, "", hostname);
        }
        
        [UserCodeMethod]
        public static void createTrainConsistSummary(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                     string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                     string totalBrakingForce, string speedConstraint, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string TIHconstraints, string purpose = "", string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                                             numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                                             maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, TIHconstraints,originDate, purpose);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfigRemote(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                                                   numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                                                   maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, TIHconstraints,originDate, purpose, hostname);
            }
            
        }
        
        [UserCodeMethod]
        public static void createTrainConsistSummary(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                     string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                     string totalBrakingForce, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string tihConstraints, string purpose = "")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                                         numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                                         maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, tihConstraints, originDate, purpose);
            // MOlson 7/29/20 This needs to exist for compatibility between 3.1+ versions.  This can be safely removed after
            // CN's production versin is 3.4+
            STE.Code_Utils.ReceiveMISFileCollection_CN.clearFilters();
            STE.Code_Utils.ReceiveMISFileCollection_CN.addValueToFilters("<ERROR_TEXT>Invalid tag name: PURPOSE</ERROR_TEXT>");
            if (STE.Code_Utils.ReceiveMISFileCollection_CN.getErrorMessage(5, true))
            {
                Report.Info("Older MIS Train Consist version detected.  Removing PURPOSE tag and re-sending");
                STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                                         numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                                         maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, tihConstraints, originDate, "BLANK");
            }
        }
        
        [UserCodeMethod]
        public static void createTrainConsistSummary(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                     string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
                                                     string totalBrakingForce, string maxCarWeights,string maxCarHeights,string maxCarWidths,string hazmatConstraints, string tihConstraints)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainConsistSummaryConfig.createTrainConsistSummaryConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, reportingSource, speedClass, maxPlateSize, numberOfLoads,
                                                                                                         numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce,
                                                                                                         maxCarWeights, maxCarHeights,maxCarWidths,hazmatConstraints, tihConstraints, originDate, "");
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainDelay(string scac, string section, string trainSeed, string fromDivision, string fromDistrict, string fromLocationType, string fromLocation,
                                            string endDivision, string endDistrict, string endLocationType, string endLocation, string delayRecordID, string delayCode,
                                            string transmissionType, string userID, string beginDelayTime, string beginDelayTimeZone, string endDelayTime, string endDelayTimeZone,
                                            string delayDuration, string crewID, string crewLineSegment, string freeFormText, string field1, string field2, string field3, string field4,
                                            string field5, string field6, string field7, string field8)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainDelayConfig.createTrainDelayConfig( scac, section, trainSymbol, fromDivision, fromDistrict, fromLocationType, fromLocation, endDivision, endDistrict, endLocationType,
                                                                                       endLocation, delayRecordID, delayCode, transmissionType, userID, beginDelayTime, beginDelayTimeZone, endDelayTime, endDelayTimeZone,
                                                                                       delayDuration, crewID, crewLineSegment, freeFormText, field1, field2, field3, field4, field5, field6, field7, field8);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainDelay(string scac, string section, string trainSeed, string fromDivision, string fromDistrict, string fromLocationType, string fromLocation,
                                            string endDivision, string endDistrict, string endLocationType, string endLocation, string delayRecordID, string delayCode,
                                            string transmissionType, string userID, string beginDelayTime, string beginDelayTimeZone, string endDelayTime, string endDelayTimeZone,
                                            string delayDuration, string crewID, string crewLineSegment, string freeFormText, string field1, string field2, string field3, string field4,
                                            string field5, string field6, string field7, string field8, string hostname)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainDelayConfig.createTrainDelayConfigRemote( scac, section, trainSymbol, fromDivision, fromDistrict, fromLocationType, fromLocation, endDivision, endDistrict, endLocationType,
                                                                                             endLocation, delayRecordID, delayCode, transmissionType, userID, beginDelayTime, beginDelayTimeZone, endDelayTime, endDelayTimeZone,
                                                                                             delayDuration, crewID, crewLineSegment, freeFormText, field1, field2, field3, field4, field5, field6, field7, field8, hostname);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTRAINOSCONFIG(string scac, string section, string trainSeed,  string stationSequenceNumber, string osLocation, string cpLocation, string direction,
                                               string reportingType, string transmissionType,  string osTime, string osTimeZone, string currentCrewDestination, string etaTime,
                                               string etaTimeZone, string reporting)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TRAINOSCONFIG.createTRAINOSCONFIG( scac, section, trainSymbol,  stationSequenceNumber, osLocation, cpLocation, direction, reportingType, transmissionType,
                                                                                 osTime, osTimeZone, currentCrewDestination, etaTime, etaTimeZone, reporting);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleAdherence(string scac, string section, string trainSeed, string adherence)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleAdherence.createTrainScheduleAdherence(scac, section, trainSymbol, adherence);
            
        }
        
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleAnnulmentConfig(string scac, string section, string trainSeed, string dateDay = "")
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
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleAnnulmentConfig.createTrainScheduleAnnulmentConfig( scac, section, trainSymbol, dateDay);
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleAnnulmentConfig(string scac, string section, string trainSeed, string hostname,string dateDay = "")
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleAnnulmentConfig.createTrainScheduleAnnulmentConfigRemote( scac, section, trainSymbol, hostname,originDate);
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleCombo(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac, string toSection,
                                                    string toTrainSymbol, string toOriginTime, string linkAndAnnulFromLocation, string linkAndAnnulFromPassCount,
                                                    string unlinkAndAnnulToLocation, string unlinkAndAnnulToPassCount)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleComboConfig.createTrainScheduleComboConfig(fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection, toTrainSymbol, toOriginTime,
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
        public static void createTrainScheduleDiversion(string scac, string section, string trainSeed, string reportType, string trainCategory, string trainGroup,
                                                        string originLocation, string terminationLocation, string stations)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDateNoSection(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleDiversionConfig.createTrainScheduleDiversionConfig( scac, section, trainSymbol, reportType, trainCategory, trainGroup, originLocation, terminationLocation, stations);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTRAINSCHEDULECONFIG(string scac, string section, string trainSeed, string commonName, string effectiveTimeBegin, string effectiveTimeEnd, string trainCategory, string trainSub,
                                                     string trainType, string operatingDays, string origin, string termination, string loopCounter, string hexa, string stationSequenceNumber, string stationName,
                                                     string direction, string dayOfETA, string eta, string dayOfETC, string etc, string dayOfETD, string etd, string crewChange, string reportingType, string setOut,
                                                     string pickup, string fuel, string inspection, string maxCars, string maxTonnage, string maxTrainLength, string minhp, string speedRestriction, string dpu, string hexaloop)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainID(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_TRAINSCHEDULECONFIG.createTRAINSCHEDULECONFIG(scac, section, trainSymbol, commonName, effectiveTimeBegin, effectiveTimeEnd, trainCategory, trainSub, trainType, operatingDays,
                                                                                             origin, termination, loopCounter, hexa, stationSequenceNumber, stationName, direction, dayOfETA, eta, dayOfETC, etc,dayOfETD, etd,
                                                                                             crewChange, reportingType, setOut, pickup, fuel, inspection, maxCars, maxTonnage, maxTrainLength, minhp, speedRestriction, dpu, hexaloop);
            
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainScheduleLink(string fromScac, string fromSection, string fromTrainSymbol, string fromOriginTime, string toScac, string toSection, string toTrainSymbol,
                                                   string toOriginTime, string linkUnlink, string linkLocation)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_TrainScheduleLinkConfig.createTrainScheduleLinkConfig( fromScac, fromSection, fromTrainSymbol, fromOriginTime, toScac, toSection, toTrainSymbol, toOriginTime, linkUnlink, linkLocation);
            
        }
        
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createTrainSegment( string scac,string section, string trainSeed, string effectiveLocation, string effectivePassCount, string timeZone, string timeType,
                                              string trainOrigin, string trainDestination, string hostname="local")

        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainSegmentConfig.createTrainSegmentConfig( scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination,originDate);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_TrainSegmentConfig.createTrainSegmentConfigRemote( scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination,originDate, hostname);
            }
        }
        
        [UserCodeMethod]
        public static void createTrainSegment( string scac,string section, string trainSeed, string effectiveLocation, string effectivePassCount, string timeZone, string timeType,
                                              string trainOrigin, string trainDestination)

        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            
            STE.Code_Utils.messages.MIS.CN.MIS_TrainSegmentConfig.createTrainSegmentConfig( scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination,originDate);
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
        public static void createWeatherAlert(string protocolID, string msgID, string traceID, string messageVersion, string wxReportID, string operatorInitials, string state, string division,
                                              string wxMsgType, string wxCode, string wxCondition, string wxSeverity, string wxDescription, string wxDetails, string timeZone,  string inEffectTime,
                                              string untilTime, string wxRecipientID, string wxWarningNumber, string wxWarningVersion, string stations, string hostname="local")
        {
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.CN.MIS_WeatherAlertConfig.createWeatherAlertConfig(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity,
                                                                                               wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations);
            }
            else
            {
                STE.Code_Utils.messages.MIS.CN.MIS_WeatherAlertConfig.createWeatherAlertConfigRemote(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity,
                                                                                                     wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations, hostname);
            }
        }
        
        [UserCodeMethod]
        public static void createWeatherAlert(string protocolID, string msgID, string traceID, string messageVersion, string wxReportID, string operatorInitials, string state, string division,
                                              string wxMsgType, string wxCode, string wxCondition, string wxSeverity, string wxDescription, string wxDetails, string timeZone,  string inEffectTime,
                                              string untilTime, string wxRecipientID, string wxWarningNumber, string wxWarningVersion, string stations)
        {
            STE.Code_Utils.messages.MIS.CN.MIS_WeatherAlertConfig.createWeatherAlertConfig(protocolID,msgID, traceID, messageVersion, wxReportID, operatorInitials, state, division, wxMsgType, wxCode, wxCondition, wxSeverity,
                                                                                           wxDescription, wxDetails, timeZone,  inEffectTime, untilTime, wxRecipientID, wxWarningNumber, wxWarningVersion, stations);
        }
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void createYardUpdate(string location,string scac, string section, string trainSeed,  string inboundOutbound, string assignedTrack, string milepost, string district,
                                            string outboundTargetTime, string outboundTargetTimeZone, string reasonText, string racfUserID)
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            STE.Code_Utils.messages.MIS.CN.MIS_YardUpdateConfig.createYardUpdateConfig(location, scac, section, trainSymbol, inboundOutbound, assignedTrack, milepost, district, outboundTargetTime,
                                                                                       outboundTargetTimeZone, reasonText, racfUserID);
            
        }
        
        /// <summary>
        /// 
        /// TBGO Train Clearance used for Load testing
        /// </summary>
        [UserCodeMethod]
        public static void createTGBO(string logicalPosition,string section, string trainSeed)
            
        {
            string trainSymbol = PDS_CORE.Code_Utils.CN_TrainID.getTrainIDNoDate(trainSeed);
            trainSymbol = trainSymbol.Remove(trainSymbol.Length-1);
            
            string originDate = PDS_CORE.Code_Utils.CN_TrainID.getOriginDate(trainSeed);
            string ddOrigin = originDate.Substring(2,2);
            
            string aTGBOid = PDS_CORE.Code_Utils.Webservices.HeadlessActions.TGBOSmiCall(logicalPosition,section,trainSymbol,ddOrigin);
            PDS_CORE.Code_Utils.CN_TrainID.SetTrainClearance(trainSeed,aTGBOid);
            
        }

        
    }
}
