/*
 * Created by Ranorex
 * User: 503073759
 * Date: 10/25/2018
 * Time: 6:20 AM
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

namespace STE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class SendMISFileCollection_NS
    {
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void NS_CreateTrain(string scac, string section, string trainSeed, string effectiveLocation, string effectivePasscount, string time, string timeZone, string timeType, string trainOrigin, string trainDestination) {
//
//            if (time.Equals("") || time.Equals("current", StringComparison.OrdinalIgnoreCase)) {
//            	time = System.DateTime.Now.ToString("hhmm");
//            }
//
//			string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
//			string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
//            STE.Code_Utils.messages.MIS.NS.MIS_CreateTrainConfig.createCreateTrainConfig(scac, section, trainSymbol, effectiveLocation, effectivePasscount, time, timeZone, timeType,  trainOrigin, trainDestination, originDate);
//
//        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
//        [UserCodeMethod]
//        public static void NS_CreateTrainSegment(string scac, string section, string trainSeed, string effectiveLocation, string effectivePassCount, string timeZone, string timeType,
//                                              string trainOrigin, string trainDestination, string hostname="local")
//
//        {
//            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
//
//            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
//
//
//            if (hostname.Equals("local"))
//            {
//                STE.Code_Utils.messages.MIS.NS.MIS_TrainSegmentConfig.createTrainSegmentConfig(scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination,originDate);
//            }
//            else
//            {
//            	STE.Code_Utils.messages.MIS.NS.MIS_TrainSegmentConfig.createTrainSegmentConfigRemote(scac, section, trainSymbol, effectiveLocation, effectivePassCount, timeZone, timeType, trainOrigin, trainDestination, originDate,hostname);
//            }
//        }

        /// <summary>
        /// Terminate the train from PDS by sending MIS message
        /// </summary>
        [UserCodeMethod]
        public static void NS_TerminateTrain(string trainSeed, bool deleteTrain)
        {
        	string SCAC = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string trainSection = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            string deleteTrainFlag = "N";

            if(deleteTrain)
            {
            	deleteTrainFlag = "Y";
            }

            if (trainSymbol != "" || trainSymbol != null)
            {
        	    STE.Code_Utils.messages.MIS.NS.MIS_TerminateTrainConfig.createTerminateTrainConfig(SCAC, trainSection, trainSymbol, deleteTrainFlag);
            } else
            {
            	Ranorex.Report.Error("Unable to find train with Trainseed: " +trainSeed);
            }
        }

        

	    /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreatePartialScheduleAnnulment(string scac, string section, string trainSeed, string fromLocation, string fromPassCount, string linkedTrainScac,
                                                          string linkedTrainSection, string linkedTrainSymbol, string linkedTrainOriginTime)
        {
        	string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
        	STE.Code_Utils.messages.MIS.NS.MIS_PartialScheduleAnnulmentConfig.createPartialScheduleAnnulmentConfig(scac, section, trainSymbol, fromLocation, fromPassCount, linkedTrainScac, linkedTrainSection,
                                                                                                 linkedTrainSymbol, linkedTrainOriginTime);

        }

	    /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_DeleteTrainSchedule(string scac, string section, string trainSeed, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.NS.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfig( scac, section, trainSymbol);
            }
            else
            {
            	STE.Code_Utils.messages.MIS.NS.MIS_DeleteTrainScheduleConfig.createDeleteTrainScheduleConfigRemote( scac, section, trainSymbol, hostname);
            }

        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreateTrainConsist(string scac, string section, string trainSeed, string locationOfUpdate, string numberOfLoadsInTrain, string numberOfEmptiesInTrain,
                                              string trailingTonnage, string trainLength, string loopCounter, string hexa, string consistOperation, string location, string numberOfLoads,
                                              string numberOfEmpties, string tonnage, string length, string hexaloop)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            STE.Code_Utils.messages.MIS.NS.MIS_TrainConsistConfig.createTrainConsistConfig(scac, section, trainSymbol, locationOfUpdate, numberOfLoadsInTrain, numberOfEmptiesInTrain, trailingTonnage,
                                                                         				trainLength, loopCounter, hexa, consistOperation, location, numberOfLoads, numberOfEmpties, tonnage, length, hexaloop);
        }


//        [UserCodeMethod]
//        public static void NS_CreateEngineConsist(string trainSeed, string engineSeed, string assignedDivision, string helperCrewPoolID,
//                                               string reportingSource, string reportingLocation, string reportingPassCount, string defaultDataApplied, string purpose, string engines)
//        {
//
//            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
//            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
//            string section = NS_TrainID.GetTrainSection(trainSeed);
//            string[] engineSeeds = engineSeed.Split('|');
//            List<string> enginesToBeMade = new List<string>();
//            string[] step1 = engines.Split('|');
//            for (int i = 0; i < step1.Length; i+=28)
//            {
//                string[] current = new string[28];
//                Array.Copy(step1, i, current, 0, 28);
//                enginesToBeMade.Add(string.Join("|", current));
//            }
//            if (engineSeeds.Length != enginesToBeMade.Count)
//            {
//                Ranorex.Report.Error("Number of seeds and number of trains being made doesn't match. Aborting Engine Consists creation.");
//                return;
//            }
//            List<NS_EngineConsistObject> listOfEngines = new List<NS_EngineConsistObject>();
//            for (int i = 0; i < enginesToBeMade.Count; i++)
//            {
//                
//                NS_EngineConsistObject EngineObject = NS_TrainID.CreateEngineConsistRecord(trainSeed, engineSeeds[i], enginesToBeMade[i], assignedDivision, helperCrewPoolID, defaultDataApplied, reportingPassCount, reportingLocation, reportingSource, purpose);
//                listOfEngines.Add(EngineObject);
//                if (EngineObject.Equals(null))
//                {
//                    Ranorex.Report.Warn("Could not fetch engine from trainSeed.");
//                    return;
//                }
//            }
//            
//            STE.Code_Utils.messages.MIS.NS.MIS_EngineConsistConfig.createEngineConsistConfig(listOfEngines);
//        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreateLocomotiveConsist(string scac, string section, string trainSeed, string reportingSource, string location, string loopCounter, string hexa,
                                                   string engineInitial, string engineNumber, string positionInconsist, string originLocation, string destinationLocation,
                                                   string compensatedHP, string facingDirection, string status, string dpuStatus, string pts, string atcs, string verifiedToTrain, string hexaloop)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            STE.Code_Utils.messages.MIS.NS.MIS_LocomotiveConsistConfig.createLocomotiveConsistConfig(scac, section, trainSymbol, reportingSource, location, loopCounter, hexa, engineInitial, engineNumber, positionInconsist, originLocation,
                                                                                   				  destinationLocation, compensatedHP, facingDirection, status, dpuStatus, pts, atcs, verifiedToTrain, hexaloop);

        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreateRailCarConsist(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string carData)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.NS.MIS_RailCarConsistConfig.createRailCarConsistConfig(scac, section, trainSymbol, reportingLocation, reportingPassCount, carData, originDate);

        }

        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the User Code library
        /// within a User Code collection.
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreateRailCarConsist(string scac, string section, string trainSeed, string reportingLocation, string reportingPassCount, string carData, string hostname)
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            string originDate = PDS_CORE.Code_Utils.NS_TrainID.getOriginDate(trainSeed);
        	STE.Code_Utils.messages.MIS.NS.MIS_RailCarConsistConfig.createRailCarConsistConfigRemote(scac, section, trainSymbol, reportingLocation, reportingPassCount, carData, originDate, hostname);

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
        /// HOS_EXPIRE_timeZone|OFF_DUTY_TIME|OFF_DUTY_timeZone|OFF_TRAIN_TIME|OFF_TRAIN_timeZone|DEST_TRAIN_SCAC|
        /// DEST_TRAIN_SECTION|DEST_trainSymbol|DEST_trainOrigin_TIME
        ///
        /// </summary>
        [UserCodeMethod]
        public static void NS_CreateCrewCall(string scac, string section, string trainSeed, string crewID,
                                          string crewLineSegment, string sequenceNumber, string crewMemberRecords, string hostname="local")
        {
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);

            if (hostname.Equals("local"))
            {
                STE.Code_Utils.messages.MIS.NS.MIS_CrewCallConfig.createCrewCallConfig(scac, section, trainSymbol, crewID, crewLineSegment,
            	                                                                    sequenceNumber, crewMemberRecords);
            }
            else
            {
            	STE.Code_Utils.messages.MIS.NS.MIS_CrewCallConfig.createCrewCallConfigRemote(scac, section, trainSymbol, crewID, crewLineSegment,
            	                                                                          sequenceNumber, crewMemberRecords, hostname);
            }
        }


        [UserCodeMethod]
        public static void NS_CreateTrainEngineConsistSummary(string trainSeed, string consistReportingLocation, string consistReportingPassCount, string consistReportingSource,
	                                                       string numberOfLoads, string numberOfEmpties, string trailingTonnage, string trainLength, string axles, string operativeBrakes,
	                                                       string totalBrakingForce, string maxCarWeights, string maxCarHeights, string maxCarWidths, string hazmatConstraints, // End of consist attributes
	                                                       string assignedDivision, string helperCrewPoolID,  string engineReportingSource, string engineReportingLocation, string engineReportingPassCount,
	                                                       string defaultDataApplied, string purpose, string engines, // End of engine attributes, beginning of EOT attributes
	                                                       string equipmentCode, string origin, string destination, string initial, string number, string workingStatus,
                                                           bool isEngineSCACMissing, bool isConsistSCACMissing, bool isEOTSCACMissing, bool isEngineSymbolMissing, bool isConsistSymbolMissing, bool isEOTSymbolMissing,
                                                           bool isEngineDateMissing, bool isConsistDateMissing, bool isEOTDateMissing,
                                                           string optMessageTraceId = "1", string optEngineTraceId = "1", string optEOTTraceId = "1", string optConsistTraceId = "1")

        {
        	string protocolId = "1";
        	string msgId = "";
        	string msgVersion = "0";

            string traceId = "1";
            string messageTraceId = string.IsNullOrEmpty(optMessageTraceId) ? traceId : optMessageTraceId;
            string engineTraceId = string.IsNullOrEmpty(optEngineTraceId) ? traceId : optEngineTraceId;
            string eotTraceId = string.IsNullOrEmpty(optEOTTraceId) ? traceId : optEOTTraceId;
            string consistTraceId = string.IsNullOrEmpty(optConsistTraceId) ? traceId : optConsistTraceId;

            string trainSymbol = NS_TrainID.GetTrainSymbol(trainSeed);
            string scac = NS_TrainID.GetTrainSCAC(trainSeed);
            string section = NS_TrainID.GetTrainSection(trainSeed);
            string originDate = NS_TrainID.getOriginDate(trainSeed);

            string engineSCAC = defineOrReportVariableContents(scac, isEngineSCACMissing, "SCAC (Engine Consist)");
            string consistSCAC = defineOrReportVariableContents(scac, isConsistSCACMissing, "SCAC (TCSM)");
            string eotSCAC = defineOrReportVariableContents(scac, isEOTSCACMissing, "SCAC (EOT)");
            string engineTrainSymbol = defineOrReportVariableContents(trainSymbol, isEngineSymbolMissing, "Train Symbol (Engine Consist)");
            string consistTrainSymbol = defineOrReportVariableContents(trainSymbol, isConsistSymbolMissing, "Train Symbol (TCSM)");
            string eotTrainSymbol = defineOrReportVariableContents(trainSymbol, isEOTSymbolMissing, "Train Symbol (EOT)");
            string engineDate = defineOrReportVariableContents(originDate, isEngineDateMissing, "Origin Date (Engine Consist)");
            string consistDate = defineOrReportVariableContents(originDate, isConsistDateMissing, "Origin Date (TCSM)");
            string eotDate = defineOrReportVariableContents(originDate, isEOTDateMissing, "Origin Date (EOT)");
            
            string reporting_date = "";
            string reporting_time = "";
            string reporting_time_zone = "";
            string tih_constraints = "";
			string max_plate_size = "";
			string speed_class = "";
			
			
			string number_of_tih_constraints = (tih_constraints.Split('|').Length/3).ToString();
			string number_of_max_car_weights = (maxCarWeights.Split('|').Length/3).ToString();
			string number_of_max_car_heights = (maxCarHeights.Split('|').Length/3).ToString();
			string number_of_max_car_widths = (maxCarWidths.Split('|').Length/3).ToString();
			string number_of_hazmat_constraints = (hazmatConstraints.Split('|').Length/3).ToString();
			
			System.DateTime now = System.DateTime.Now;
			string[] splitEngineRecords = engines.Split('|');
            int splitLengthOfEngineRecord = splitEngineRecords.Length;
            int currentRecordSize = 26;
            
            if (splitLengthOfEngineRecord%currentRecordSize != 0)
            {
                Ranorex.Report.Error("Engine Record is not divisible by " + currentRecordSize + ", total size of record is {" + splitLengthOfEngineRecord + "}");
                return;
            }
            
            int numberOfEngineRecords = splitLengthOfEngineRecord/currentRecordSize;
            string numberOfEngines = numberOfEngineRecords.ToString();
            for (int i = 0; i < splitLengthOfEngineRecord; i = i + currentRecordSize)
            {
                int next_service_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+19], out next_service_date_offset_int) && splitEngineRecords[i+19].Length < 8)
            	{
            		splitEngineRecords[i+19] = now.AddDays(next_service_date_offset_int).ToString("MMddyyyy");
            	}
                
                int fra_test_due_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+22], out fra_test_due_date_offset_int) && splitEngineRecords[i+22].Length < 8)
            	{
            		splitEngineRecords[i+22] = now.AddDays(fra_test_due_date_offset_int).ToString("MMddyyyy");
            	}
                
                int last_fuel_date_offset_int = 0;
                if (Int32.TryParse(splitEngineRecords[i+24], out last_fuel_date_offset_int) && splitEngineRecords[i+24].Length < 8)
            	{
            		splitEngineRecords[i+24] = now.AddDays(last_fuel_date_offset_int).ToString("MMddyyyy");
            	}
            }
        	
            engines = string.Join("|", splitEngineRecords);

            STE.Code_Utils.messages.MIS.NS.MIS_TrainEngineConsistSummaryConfig.createTrainEngineConsistSummaryConfig(protocolId, msgId, messageTraceId, msgVersion, protocolId, msgId, engineTraceId, msgVersion, engineSCAC, section, engineTrainSymbol,
                                                                                                                  engineDate, assignedDivision, helperCrewPoolID, engineReportingSource, engineReportingLocation, engineReportingPassCount,
                                                                                                                  defaultDataApplied, purpose, numberOfEngines, engines, // end of engine attributes, beginning of eot attributes
                                                                                                                  protocolId, msgId, eotTraceId, msgVersion, eotSCAC, section, eotTrainSymbol, eotDate, equipmentCode,
                                                                                                                  origin, destination, initial, number, workingStatus, // end of eot attributes, beginning of consist attributes
                                                                                                                  protocolId, msgId, consistTraceId, msgVersion, consistSCAC, section, consistTrainSymbol, consistDate, consistReportingLocation,
                                                                                                                  consistReportingPassCount, reporting_date, reporting_time, reporting_time_zone, consistReportingSource, number_of_tih_constraints, 
                                                                                                                  tih_constraints, max_plate_size, numberOfLoads, numberOfEmpties, trailingTonnage, trainLength, axles, operativeBrakes, totalBrakingForce, 
                                                                                                                  speed_class, number_of_max_car_weights, maxCarWeights, number_of_max_car_heights, maxCarHeights, number_of_max_car_widths, maxCarWidths, 
                                                                                                                  number_of_hazmat_constraints, hazmatConstraints);

        }

        private static string defineOrReportVariableContents(string definedVariable, bool isVariableMissing, string variableName)
        {
        	string outputVariable = "";
        	if (!isVariableMissing)
        	{
        		outputVariable = definedVariable;
        	} else {
        		Ranorex.Report.Info("TestStep", "The following field is blank: " + variableName);
        	}
        	return outputVariable;
        }

        /// <summary>
        /// Sending Automatic Equipment Identifier message
        /// </summary>
        /// <param name="scanner_reporting_key">Reporting location at which AEI is scanned</param>
        /// <param name="event_start_time">Start time for the AEI message, usually it should be 0</param>
        /// <param name="event_start_time_zone"> Timezone for the message for NS it will be E or C</param>
        /// <param name="direction"> Direction of the train movement E, W, N or S</param>
		/// <param name="trainSeed">TrainSeed</param>
		/// <param name="engineSeedList">List of EngineSeeds separated by pipe e.g. engineSeed1|engineSeed2</param>
        [UserCodeMethod]
        public static void NS_AutomaticEquipmentIdentifier(string scanner_reporting_key, string event_start_time, string event_start_time_zone, string direction, string trainSeed, string engineSeedList)
        {
        	List<NS_EngineConsistObject> engineObjectList = new List<NS_EngineConsistObject>();
        	if (engineSeedList.Contains("|"))
            {
                string[] engineList = engineSeedList.Split('|');

                for (int i = 0; i < engineList.Length; i++)
                {
                	engineObjectList.Add(NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineList[i]));
                }

        	} else {
        		engineObjectList.Add(NS_TrainID.GetEngineObjectFromTrain(trainSeed, engineSeedList));
        	}

        	STE.Code_Utils.messages.MIS.NS.MIS_AutomaticEquipmentIdentifier.createAutomaticEquipmentIdentifier(scanner_reporting_key, event_start_time, event_start_time_zone, direction, engineObjectList);

        }
        /// <summary>
        /// Yard update message which is sent when a train comes out of the yard
		/// until a train does not come out of yard it is not tracked. Sending yard update message will do that.
        /// Maris: Renamed outboundTargetTime to include offset, this makes it much more clear when binding variables and constructing data for testing
		/// </summary>
        [UserCodeMethod]
        public static void NS_UpdateYardMessage(string terminalLocation, string trainSeed,string inboundOutbound,
                                                string assignedTrack,string milepost,string district,string outboundTargetTimeOffset,
                                                string outboundTargetTimeZone,string reasonText)
        {
	        	string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
	            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
	            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
        		STE.Code_Utils.messages.MIS.NS.MIS_YardUpdateConfig.createYardUpdateConfig(terminalLocation,scac,section,trainSymbol,inboundOutbound,assignedTrack,milepost,
        		                                                                        district,outboundTargetTimeOffset,outboundTargetTimeZone,reasonText,"");
        }

        /// <summary>
        /// create MovementInformation MIS
        /// </summary>
        [UserCodeMethod]
        public static void NS_createMovementInformation(string scac, string section, string trainSeed, string locationType, string dataLocation, string dataPassCount, string dataTrackName,
                                                           string divisionNumber, string dataDivision, string dataDistrict, string direction, string typeOfReporting, string transmissionType, string reportingTime,
                                                           string reportingTimeZone, string currentCrewDest, string etaTimeZone, string alertEventKey, string deviceID, string ptas)
        {
            string etaTime = null;
            //string reportingTime = null;
            string trainSymbol = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSymbol(trainSeed);
            STE.Code_Utils.messages.MIS.NS.MIS_MovementInformationConfig.createMovementInformationConfig(scac, section, trainSymbol, locationType, dataLocation, dataPassCount, dataTrackName, divisionNumber, dataDivision,
                                                                                       dataDistrict, direction, typeOfReporting, transmissionType,  reportingTime, reportingTimeZone,
                                                                                       currentCrewDest, etaTime, etaTimeZone, alertEventKey, deviceID, ptas);

        }
        /// <summary>
        /// Sending   ExternalAlertEvent message
        /// </summary>
        /// <param name="alert_event_key">alert event key for ex: 51</param>
        /// <param name="alert_event_type">alert event type for ex: 32 to turn ON Switch heater and 33 to turn OFF Switch heater</param>
        /// <param name="device_type">type of device for ex: Locomotive ,wayside device </param>
        /// <param name="device_id">ID of device </param>
        /// <param name="milepost">milepost of track </param>
        /// <param name="subdivision">subdivision</param>
        /// <param name="division">division , for ex:Georgia</param>
        /// <param name="direction">direction for ex: N or S</param>
        /// <param name="start_time">start_time to Trun on or off switch heater </param>
        /// <param name="start_time_zone">start_time_zone fpr ex: Eastern or Central</param>
        /// <param name="message_text">Message Text</param>
        [UserCodeMethod]
        public static void NS_CreateExternalAlertEvent(string alert_event_key, string alert_event_type,string device_type,string device_id,string milepost,string division,string direction,string start_time_offset_minutes,string start_date_offset_days,string start_time_zone,string message_text)
        {
        	string protocolid="";
        	string msgid="";
        	string trace_id="";
        	string message_version="";
        	
        	System.DateTime now = System.DateTime.Now;
        	
        	string start_time;
        	int start_time_offset_int = 0;
        	if (Int32.TryParse(start_time_offset_minutes, out start_time_offset_int))
        	{
        		start_time = now.AddMinutes(start_time_offset_int).ToString("HHmm");
        	} else {
        		start_time = start_time_offset_minutes;
        	}
        	
        	string start_date;
        	int start_date_offset_int = 0;
        	if (Int32.TryParse(start_date_offset_days, out start_date_offset_int))
        	{
        		start_date = now.AddDays(start_date_offset_int).ToString("MMddyyyy");
        	} else {
        		start_date = start_date_offset_days;
        	}
            
        	STE.Code_Utils.messages.MIS.NS.MIS_ExternalAlertEvent.createExternalAlertEvent(protocolid,msgid,trace_id, message_version,alert_event_key,alert_event_type,device_type,device_id,milepost,division,direction,start_time,start_date,start_time_zone,message_text);
        	
        }
        
        /// <summary>
        /// Sends MIS message to Create/Clear/Update Weather Alert
        /// </summary>
        /// <param name="wx_report_id">Input: wx_report_id</param>
        /// <param name="operator_initials">Input: operator_initials</param>
        /// <param name="state">Input: state</param>
        /// <param name="division">Input: division</param>
        /// <param name="wx_msg_type">Input: wx_msg_type</param>
        /// <param name="wx_code">Input: wx_code</param>
        /// <param name="wx_condition">Input: wx_condition</param>
        /// <param name="wx_severity">Input: wx_severity</param>
        /// <param name="wx_description">Input: wx_description</param>
        /// <param name="wx_details">Input: wx_details</param>
        /// <param name="time_zone">Message Text</param>
        /// <param name="in_effect_time_offset_minutes">Input: in_effect_time_offset_minutes</param>
        /// <param name="until_time_offset_minutes">Input: until_time_offset_minutes</param>
        /// <param name="wx_recipient_id">Input: wx_recipient_id</param>
        /// <param name="wx_warning_number">Input: wx_warning_number</param>
        /// <param name="wx_warning_version">Input: wx_warning_version</param>
        /// <param name="stations">Input: stations</param>
        [UserCodeMethod]
        public static void NS_SendWeatherAlert(string wx_report_id, string operator_initials, string state, string division, string wx_msg_type, string wx_code, string wx_condition, string wx_severity, string wx_description, string wx_details, 
                                                 string time_zone, string in_effect_time_offset_minutes, string until_time_offset_minutes, string wx_recipient_id, string wx_warning_number, string wx_warning_version, string stations)
        {
        	string protocolid="";
        	string msgid="";
        	string trace_id="";
        	string message_version="";
            
        	STE.Code_Utils.messages.MIS.NS.MIS_WeatherAlertConfig.createWeatherAlertConfig(protocolid,msgid,trace_id,message_version,wx_report_id,operator_initials,state,division,wx_msg_type,wx_code,wx_condition,wx_severity,wx_description,
        	                                                                               wx_details,time_zone,in_effect_time_offset_minutes,until_time_offset_minutes,wx_recipient_id,wx_warning_number,wx_warning_version, stations);
        	
        }

        [UserCodeMethod]
        public static void NS_CreateHourlyWeather(string operator_initials, string state, string division, string station_id, string station_name, string offsetDate, string offsetHours, string offsetMinutes, 
                                                  string time_zone, string tempFahrenheit, string dewPointFahrenheit, string relativeHumidity, string feelsLike, string windDirectionDegrees,
                                                  string windSpeedMph, string windSpeedGustMph, string sixHourMaxTemperature, string sixHourMinTemperature, string hourlyPrecipitationInches, string sixHourPrecipitationInches,
                                                  string sunshineMinutes, string sunshinePercentPossible, string barometricPressureInches, string horizontalVisibilityMiles, string weatherDescription,
                                                  string cloudCoverPercent, string weatherCode, string weatherCondition, string sunriseTimeHHMM, string sunsetTimeHHMM)
        {
            
            string protocolid="";
        	string msgid="";
        	string trace_id="";
        	string message_version="";
            string hostname = "";
            
            System.DateTime now = System.DateTime.Now;

            string date = now.AddDays(Convert.ToDouble(offsetDate)).ToString("MMddyyyy");
            string time = now.AddHours(Convert.ToDouble(offsetHours)).AddMinutes(Convert.ToDouble(offsetMinutes)).ToString("HHmm");
            
            STE.Code_Utils.messages.MIS.NS.MIS_NS_HourlyWeather_48.createNS_HourlyWeather_48(
                header_protocolid: protocolid, header_msgid: msgid, header_trace_id: trace_id, header_message_version: message_version,
                content_operator_initials: operator_initials, content_state: state, content_division: division, content_station_id: station_id, content_station_name: station_name, content_date: date, content_time: time, content_time_zone: time_zone, 
                content_tmpf: tempFahrenheit, content_dwpf: dewPointFahrenheit, content_hum: relativeHumidity, content_flk: feelsLike, content_wdr: windDirectionDegrees, content_wsp: windSpeedMph, content_gst: windSpeedGustMph, 
                content_max: sixHourMaxTemperature, content_min: sixHourMinTemperature, content_pc1hr: hourlyPrecipitationInches, content_pc6hr: sixHourPrecipitationInches, content_ssm: sunshineMinutes, content_ssp: sunshinePercentPossible, 
                content_brmtr: barometricPressureInches, content_vis: horizontalVisibilityMiles, content_weather: weatherDescription, content_cvr: cloudCoverPercent, content_wxw: weatherCode, 
                content_cond: weatherCondition, content_sunr: sunriseTimeHHMM, content_suns: sunsetTimeHHMM, hostname: hostname
            );
        } 
    }
}
