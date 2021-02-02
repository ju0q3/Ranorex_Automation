/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/13/2017
 * Time: 9:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Xml.Serialization;

using STE.Code_Utils.messages.MIS.CN;

namespace STE.Code_Utils.messages.test
{
    /// <summary>
    /// Description of CreateTrainTest.
    /// </summary>
    public class CreateTrainTest
    {
		public CreateTrainTest()
		{
		}
		
		
		public MIS_CrewMemberConfig createCrewMember(DateTime now)
		{
			MIS_CrewMemberConfig crewMember = new MIS_CrewMemberConfig();
			
			MIS_CrewMemberConfigHEADER header = new MIS_CrewMemberConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "CrewMemberConfig";
			crewMember.HEADER = header;
			
			MIS_CrewMemberConfigCONTENT content = new MIS_CrewMemberConfigCONTENT();				
			content.SCAC      = "CN";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE  = now.ToString("MMddyyyy");
			content.CREW_ID      = "CREW1";
			content.CREW_LINE_SEGMENT = "G1";
			content.SEQUENCE_NUMBER = "001";    
			content.NUMBER_OF_CREW_MEMBERS = "1";
			
			
			MIS_CrewMemberConfigCREW_MEMBER_RECORD record = new MIS_CrewMemberConfigCREW_MEMBER_RECORD();
			record.ON_DUTY_LOCATION = "500011";
			record.OFF_DUTY_LOCATION = "500008";
			record.ON_TRAIN_LOCATION = "500011";
			record.ON_TRAIN_PASS_COUNT = "1";
			record.ON_TRAIN_LOCATION_MP = "";
			record.OFF_TRAIN_LOCATION = "500008";
			record.OFF_TRAIN_PASS_COUNT = "1";
			record.OFF_TRAIN_LOCATION_MP = "";
			record.CREW_POSITION = "EN";
			record.CREW_MEMBER_TYPE = "WK";
			record.FIRST_INITIAL = "J";
			record.MIDDLE_INITIAL = "D";
			record.LAST_NAME = "HARRISON";
			record.SOCIAL_SECURITY_NO = "123456789";
			record.EMPLOYEE_ID = "1001";
			record.ON_DUTY_DATE = now.ToString("MMddyyyy");
			record.ON_DUTY_TIME = now.ToString("hhmm");
			record.ON_DUTY_TIME_ZONE = "E";
			record.ON_TRAIN_DATE = now.ToString("MMddyyyy");
			record.ON_TRAIN_TIME = now.ToString("hhmm");
			record.ON_TRAIN_TIME_ZONE = "E";
			record.HOS_EXPIRE_DATE = now.ToString("MMddyyyy");
			record.HOS_EXPIRE_TIME = "1937";
			record.HOS_TIME_ZONE = "E";
			content.addCREW_MEMBER_RECORD(record);
			
			crewMember.CONTENT = content;
			
			return crewMember;
		}    

        public MIS_EngineConsistConfig createEngineConsist(DateTime now)
		{
        	MIS_EngineConsistConfig engine = new MIS_EngineConsistConfig();
        	
        	MIS_EngineConsistConfigHEADER header = new MIS_EngineConsistConfigHEADER();
        	header.PROTOCOLID = "1";
			header.MSGID      = "EngineConsistConfig";
			engine.HEADER = header;
			
        	MIS_EngineConsistConfigCONTENT content = new MIS_EngineConsistConfigCONTENT();
        	content.SCAC = "CN";
        	content.TRAIN_SYMBOL = "1001";
        	content.ORIGIN_DATE = now.ToString("MMddyyyy");
        	content.ASSIGNED_DIVISION = "GULF";
        	content.HELPER_CREW_POOL_ID = "G0001";
        	content.REPORTING_SOURCE = "O";
        	content.REPORTING_LOCATION = "500011";
        	content.REPORTING_PASS_COUNT = "1";
        	content.DEFAULT_DATA_APPLIED = "Y";
        	content.PURPOSE = "R";
        	content.NUMBER_OF_ENGINES = "2";
        		
        	MIS_EngineConsistConfigENGINE_RECORD record1 = new MIS_EngineConsistConfigENGINE_RECORD();
        		
        	record1.ENGINE_INITIAL = "CN";
        	record1.ENGINE_NUMBER = "1001";
        	record1.ENGINE_POSITION = "1";
        	record1.ENGINE_ORIENTATION = "FRONT";
        	record1.ENGINE_LOCK = "N";
        	record1.ORIGIN_PASS_COUNT = "1";
        	record1.ORIGIN_LOCATION = "500011";
        	record1.DESTINATION_PASS_COUNT = "1";
        	record1.DESTINATION_LOCATION = "500008";
        	record1.COMPENSATED_HP = "3000";
        	record1.GROUP_NUMBER = "1";
        	record1.MODEL = "FRT";
        	record1.ENGINE_STATUS = "W";
        	record1.DPU_STATUS = "N";
        	record1.PTS_EQUIPPED = "N";
        	record1.PTC_EQUIPPED = "N";
        	record1.LSL_EQUIPPED = "N";
        	record1.CS_EQUIPPED = "N";
        	record1.NOTES = "Train added by Automation";
        	content.addENGINE_RECORD(record1);
        	
        	MIS_EngineConsistConfigENGINE_RECORD record2 = new MIS_EngineConsistConfigENGINE_RECORD();
        		
        	record2.ENGINE_INITIAL = "CN";
        	record2.ENGINE_NUMBER = "201001";
        	record2.ENGINE_POSITION = "2";
        	record2.ENGINE_ORIENTATION = "FRONT";
        	record2.ENGINE_LOCK = "N";
        	record2.ORIGIN_PASS_COUNT = "1";
        	record2.ORIGIN_LOCATION = "500011";
        	record2.DESTINATION_PASS_COUNT = "1";
        	record2.DESTINATION_LOCATION = "500008";
        	record2.COMPENSATED_HP = "3000";
        	record2.GROUP_NUMBER = "1";
        	record2.MODEL = "FRT";
        	record2.ENGINE_STATUS = "W";
        	record2.DPU_STATUS = "N";
        	record2.PTS_EQUIPPED = "N";
        	record2.PTC_EQUIPPED = "N";
        	record2.LSL_EQUIPPED = "N";
        	record2.CS_EQUIPPED = "N";
        	record2.NOTES = "Train added by Automation";
        	content.addENGINE_RECORD(record2);

        	engine.CONTENT = content;
        	
        	return engine;
        }


		public MIS_EOTCabooseConfig createEot(DateTime now)
		{
			MIS_EOTCabooseConfig eot = new MIS_EOTCabooseConfig();
			
			MIS_EOTCabooseConfigHEADER header = new MIS_EOTCabooseConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "RailCarConsistConfig";
			eot.HEADER = header;
			
			MIS_EOTCabooseConfigCONTENT content = new MIS_EOTCabooseConfigCONTENT();
			content.SCAC = "CN";
			content.SECTION = "";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.EQUIPMENT_CODE = "E";
			content.ORIGIN = "500011";
			content.DESTINATION = "500008";
			content.INITIAL = "CN";
			content.NUMBER = "96989";
			content.WORKING_STATUS = "W";
			
			eot.CONTENT = content;
			
			return eot;
		}

		public MIS_RailCarConsistConfig createRailCar(DateTime now) 
		{
			MIS_RailCarConsistConfig railcar = new MIS_RailCarConsistConfig();
			
			MIS_RailCarConsistConfigHEADER header = new MIS_RailCarConsistConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "RailCarConsistConfig";
			railcar.HEADER = header;
			
			MIS_RailCarConsistConfigCONTENT content = new MIS_RailCarConsistConfigCONTENT();
			content.SCAC = "CN";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.REPORTING_LOCATION = "500011";
			content.REPORTING_PASS_COUNT = "1";
			content.CAR_DATA = "Rail Car Consist Generated via Automation at 11-09-2017 13:30";
			
			railcar.CONTENT = content;
			
			return railcar;
		}

		public MIS_TrainConsistSummaryConfig createTrainConsistSummary(DateTime now)
		{
			
			MIS_TrainConsistSummaryConfig summary = new MIS_TrainConsistSummaryConfig();
			
			MIS_TrainConsistSummaryConfigHEADER header = new MIS_TrainConsistSummaryConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "TrainConsistSummaryConfig";
			summary.HEADER = header;
			
			MIS_TrainConsistSummaryConfigCONTENT content = new MIS_TrainConsistSummaryConfigCONTENT();
			content.SCAC = "CN";
			content.SECTION = "";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.REPORTING_LOCATION = "500011";
			content.REPORTING_PASS_COUNT = "1";
			content.REPORTING_SOURCE = "T ";
			content.NUMBER_OF_LOADS = "30";
			content.NUMBER_OF_EMPTIES = "10";
			content.TRAILING_TONNAGE = "1500";
			content.TRAIN_LENGTH = "2940";
			content.AXLES = "76";
			content.OPERATIVE_BRAKES = "19";
			content.TOTAL_BRAKING_FORCE = "500000";
			content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS = "0";
			content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS = "0";
			content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS = "0";
			content.NUMBER_OF_HAZMAT_CONSTRAINTS = "0";
		    summary.CONTENT = content;
		    
		    return summary;
		}

		
		public MIS_TrainDelayConfig createDelay1(DateTime now)
		{
			MIS_TrainDelayConfig delay1 = new MIS_TrainDelayConfig();
			MIS_TrainDelayConfigHEADER header = new MIS_TrainDelayConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "TrainDelayConfig";
			delay1.HEADER = header;

			
			
			MIS_TrainDelayConfigCONTENT content = new MIS_TrainDelayConfigCONTENT();
			
			content.SCAC = "CN";
			content.SECTION = "";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.FROM_LOCATION_TYPE = "R";
			content.FROM_LOCATION = "500011";
			content.END_LOCATION_TYPE = "R";
			content.END_LOCATION = "500008";
			content.DELAY_CODE = "ESO";
			content.TRANSMISSION_TYPE = "N";
			content.DELAY_DURATION = "0010";
			content.CREW_LINE_SEGMENT = "C1";
			content.FREE_FORM_TEXT = "ESO";
			content.FIELD_1 = "f1";
			content.FIELD_2 = "f2";
			content.FIELD_3 = "f3";
			content.FIELD_4 = "f4";
			content.FIELD_5 = "f5";
			content.FIELD_6 = "f6";
			content.FIELD_7 = "f7";
			content.FIELD_8 = "f8";

            delay1.CONTENT = content;
			return delay1;
		}
		
		public MIS_TrainDelayConfig createDelay2(DateTime now)
		{
			MIS_TrainDelayConfig delay2 = new MIS_TrainDelayConfig();
			MIS_TrainDelayConfigHEADER header = new MIS_TrainDelayConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "TrainDelayConfig";
			delay2.HEADER = header;
			
			
			MIS_TrainDelayConfigCONTENT content = new MIS_TrainDelayConfigCONTENT();
		    content.SCAC = "CN";
			content.SECTION = "";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.FROM_LOCATION_TYPE = "R";
			content.FROM_LOCATION = "500011";
			content.END_LOCATION_TYPE = "R";
			content.END_LOCATION = "500008";
			content.DELAY_CODE = "TBL";
			content.TRANSMISSION_TYPE = "N";
			content.DELAY_DURATION = "0010";
			content.CREW_LINE_SEGMENT = "C1";
			content.FREE_FORM_TEXT = "TBL";
			content.FIELD_1 = "f1";
			content.FIELD_2 = "f2";
			content.FIELD_3 = "f3";
			content.FIELD_4 = "f4";
			content.FIELD_5 = "f5";
			content.FIELD_6 = "f6";
			content.FIELD_7 = "f7";
			content.FIELD_8 = "f8";
			
			delay2.CONTENT = content;
			return delay2;
		}


		public MIS_TrainScheduleConfig createTrainSchedule(DateTime now)
		{
			MIS_TrainScheduleConfig schedule = new MIS_TrainScheduleConfig();
			
			MIS_TrainScheduleConfigHEADER header = new MIS_TrainScheduleConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "TrainScheduleConfig";
			schedule.HEADER = header;
			
			MIS_TrainScheduleConfigCONTENT content = new MIS_TrainScheduleConfigCONTENT();
            content.SCAC = "CN";
            content.SECTION = "";
            content.TRAIN_SYMBOL = "1001";
            content.ORIGIN_DATE  = now.ToString("MMddyyyy");
            content.REPORT_TYPE = "1";
            content.TRAIN_CATEGORY = "1";
            content.TRAIN_GROUP = "IM";
            content.ORIGIN_LOCATION = "500011";
            content.TERMINATION_LOCATION = "500008";
            content.NUMBER_OF_STATIONS = "3";
            	            
            MIS_TrainScheduleConfigSTATION station1 = new MIS_TrainScheduleConfigSTATION();
            station1.STATION_SEQ_NUM ="1";
            station1.STATION_LOCATION = "500011";
            station1.DAY_OF_STA = "00";
            station1.STA = now.ToString("hhmm");
            station1.STA_ZONE = "E";
            station1.DAY_OF_STD = "00";
            int delay = Int32.Parse(now.ToString("hhmm"));
            delay = delay+100;
            station1.STD = delay.ToString("D4");
            station1.STD_ZONE = "E";
            station1.CREW_CHANGE = "N";
            station1.CREW_LINE_SEGMENT = "G1";
            station1.SETOUT = "N";
            station1.PICKUP = "N";
            station1.FUEL = "N";
            station1.INSPECTION = "N";
            station1.PASSENGER_STOP = "N";
            station1.EXIT_TO_FOREIGN_RAILROAD = "N";
            station1.TURN_POINT = "N";
            content.addSTATION(station1);

            MIS_TrainScheduleConfigSTATION station2 = new MIS_TrainScheduleConfigSTATION();
            station2.STATION_SEQ_NUM = "2";
            station2.STATION_LOCATION = "CENJCT";
            station2.DAY_OF_STA = "00";
            delay = delay + 100;
            station2.STA = delay.ToString("D4");
            station2.STA_ZONE = "E";
            station2.DAY_OF_STD = "00";
            delay = delay + 100;
            station2.STD = delay.ToString("D4");
            station2.STD_ZONE = "E";
            station2.CREW_CHANGE = "N";
            station2.CREW_LINE_SEGMENT = "G1";
            station2.SETOUT = "N";
            station2.PICKUP = "N";
            station2.FUEL = "N";
            station2.INSPECTION = "N";
            station2.PASSENGER_STOP = "N";
            station2.EXIT_TO_FOREIGN_RAILROAD = "N";
            station2.TURN_POINT = "N";
            content.addSTATION(station2);
            		
            MIS_TrainScheduleConfigSTATION station3 = new MIS_TrainScheduleConfigSTATION();
            station3.STATION_SEQ_NUM = "3";
            station3.STATION_LOCATION = "500008";
            station3.DAY_OF_STA = "00";
            delay = delay + 100;
            station3.STA = delay.ToString("D4");
            station3.STA_ZONE = "E";
            station3.DAY_OF_STD = "00";
            delay = delay + 100;
            station3.STD = delay.ToString("D4");
            station3.STD_ZONE = "E";
            station3.CREW_CHANGE = "N";
            station3.CREW_LINE_SEGMENT = "G1";
            station3.SETOUT = "N";
            station3.PICKUP = "N";
            station3.FUEL = "N";
            station3.INSPECTION = "N";
            station3.PASSENGER_STOP = "N";
            station3.EXIT_TO_FOREIGN_RAILROAD = "N";
            station3.TURN_POINT = "N";
            content.addSTATION(station3);
			
            schedule.CONTENT = content;
            
			return schedule;
		}
		
		public MIS_TrainSegmentConfig createTrain(DateTime now)
		{
			MIS_TrainSegmentConfig train = new MIS_TrainSegmentConfig();
			
			MIS_TrainSegmentConfigHEADER header = new MIS_TrainSegmentConfigHEADER();
			header.PROTOCOLID = "1";
			header.MSGID      = "TrainSegmentConfig";
			train.HEADER = header;
				
			MIS_TrainSegmentConfigCONTENT content = new MIS_TrainSegmentConfigCONTENT();
    
			content.SCAC = "CN";
			content.SECTION = "";
			content.TRAIN_SYMBOL = "1001";
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.EFFECTIVE_LOCATION = "500011";
			content.EFFECTIVE_PASS_COUNT = "1";
			content.DATE = now.ToString("MMddyyyy");
			content.TIME = now.ToString("hhmm");
			content.TIME_ZONE = "E";
			content.TIME_TYPE = "C";
			content.TRAIN_ORIGIN = "500011";
			content.TRAIN_DESTINATION = "500008";

			train.CONTENT = content;
			
			return train;
		}

		
    }
}