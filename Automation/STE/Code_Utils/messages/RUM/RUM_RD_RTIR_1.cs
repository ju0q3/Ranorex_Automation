using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;
using STE.Code_Utils.MessageQueues;

namespace STE.Code_Utils.messages.RUM
{
    public partial class RUM_RD_RTIR_1 {
        private RUM_RD_RTIRHEADER_1 thisHEADER;
        private RUM_RD_RTIRCONTENT_1 thisCONTENT;

        public RUM_RD_RTIRHEADER_1 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public RUM_RD_RTIRCONTENT_1 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createRD_RTIR_1(
            //string header_event_date, 
            //string header_event_time, 
            //string header_message_id, 
            //string header_sequence_number, 
            //string header_message_version, 
            //string header_source_sys, 
            //string header_destination_sys, 
            string header_district_name, 
            string header_user_id, 
            string header_division_name, 
            string request_id, 
            string pf_addressee, 
            string pf_addressee_type, 
            string requesting_employee, 
            string addressee_type, 
            string scac, 
            string symbol, 
            string section, 
            string origin_date, 
            string engine_initial, 
            string engine_number, 
            string coupled_engine_initial, 
            string coupled_engine_number, 
            string employee_first, 
            string employee_middle, 
            string employee_last, 
            string addressee_id,
            string ru_comments,
            string at_location, 
            string spaf_ack,
            string have_joint_occupants,
            string s1_track_authority_to_void,
			string s1_track_authority_id,            
            string s2_presence, 
            string s2_from_location, 
            string s2_first_switch, 
            string s2_count, 
            string s2_record, 
            string s3_presence, 
            string s3_between, 
            string s3_between_cp, 
            string s3_os, 
            string s3_and, 
            string s3_and_cp, 
            string s3_track_count, 
            string s3_track_record,            
            string s3_subdivide_from, 
            string s3_subdivide_to, 
            string s3_between_zone_count, 
            string s3_between_zone_record,
            string s3_and_zone_count, 
            string s3_and_zone_record,           
            string s4_presence, 
            string s4_from_location, 
            string s4_first_switch, 
            string s4_count, 
            string s4_record,            
            string s5_until, 
            string s7_hold_main, 
            string s9_clear_main 
        ) {
            RUM_RD_RTIR_1 rD_RTIR = new RUM_RD_RTIR_1();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";


            RUM_RD_RTIRHEADER_1 header = new RUM_RD_RTIRHEADER_1();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmmss");
            header.HEADER_MESSAGE_ID = "RD-RTIR";
            header.HEADER_SEQUENCE_NUMBER = "default"; //I think this is auto generated despite what is put here...
            header.HEADER_MESSAGE_VERSION = "1";
            header.HEADER_SOURCE_SYS = "RU";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_USER_ID = header_user_id;
            header.HEADER_DIVISION_NAME = header_division_name;

            RUM_RD_RTIRCONTENT_1 content = new RUM_RD_RTIRCONTENT_1();
            content.REQUEST_ID = request_id;
            content.PF_ADDRESSEE = pf_addressee;
            content.PF_ADDRESSEE_TYPE = pf_addressee_type;
            content.REQUESTING_EMPLOYEE = requesting_employee;
            content.ADDRESSEE_TYPE = addressee_type;
            content.SCAC = scac;
            content.SYMBOL = symbol;
            content.SECTION = section;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.ENGINE_INITIAL = engine_initial;
            content.ENGINE_NUMBER = engine_number;
            content.COUPLED_ENGINE_INITIAL = coupled_engine_initial;
            content.COUPLED_ENGINE_NUMBER = coupled_engine_number;
            content.EMPLOYEE_FIRST = employee_first;
            content.EMPLOYEE_MIDDLE = employee_middle;
            content.EMPLOYEE_LAST = employee_last;
            content.ADDRESSEE_ID = addressee_id;
            if(ru_comments == "null")
            {
            	content.RU_COMMENTS = null;
            }
            else
            {
            	content.RU_COMMENTS = ru_comments;
            }
            content.AT_LOCATION = at_location;
            content.SPAF_ACK = spaf_ack;
            content.S1_HAVE_JOINT_OCCUPANTS = have_joint_occupants;
            content.S1_TRACK_AUTHORITY_TO_VOID = s1_track_authority_to_void;
            if(String.IsNullOrEmpty(s1_track_authority_id))
            {
            	content.S1_TRACK_AUTHORITY_ID = null;
            }
            else
            {
            	content.S1_TRACK_AUTHORITY_ID = s1_track_authority_id;
            }
            content.S2_PRESENCE = s2_presence;
            if (s2_presence.Equals("Y")) {
	            content.S2_FROM_LOCATION = s2_from_location;
	            content.S2_FIRST_SWITCH = s2_first_switch;
	            content.S2_COUNT = s2_count;
	            string[] s2_recordList = s2_record.Split('|');
	            for (int i = 0; i < s2_recordList.Length;) {
	                RUM_RD_RTIRS2_RECORD_1 s2_records = new RUM_RD_RTIRS2_RECORD_1();
	                s2_records.S2_SEQUENCE = s2_recordList[i];i++;
	                s2_records.S2_TO_LOCATION = s2_recordList[i];i++;
	                s2_records.S2_TRACK = s2_recordList[i];i++;
	                content.addS2_RECORD(s2_records);
	            }
            }

            content.S3_PRESENCE = s3_presence;
            if (s3_presence.Equals("Y")) {
	            content.S3_BETWEEN = s3_between;
	            content.S3_BETWEEN_CP = s3_between_cp;
	            content.S3_OS = s3_os;
	            content.S3_AND = s3_and;
	            content.S3_AND_CP = s3_and_cp;
	            content.S3_TRACK_COUNT = s3_track_count;
	            Ranorex.Report.Info("Track Record: "+s3_track_record.ToString());
            	string[] s3_track_recordList = s3_track_record.Split('|');
            	if(!string.IsNullOrEmpty(s3_track_record.ToString()))
            	{
            		for (int i = 0; i < s3_track_recordList.Length; i++)
            		{
            			RUM_RD_RTIRS3_TRACK_RECORD_1 s3_track_records = new RUM_RD_RTIRS3_TRACK_RECORD_1();
            			s3_track_records.S3_TRACK_SEQUENCE = s3_track_recordList[i];i++;
            			s3_track_records.S3_TRACK_TEXT = s3_track_recordList[i];i++;
            			content.addS3_TRACK_RECORD(s3_track_records);
            		}
            	}
				Ranorex.Report.Info("S3_SUBDIVIDE: "+s3_subdivide_from.ToString());
	            content.S3_SUBDIVIDE_FROM = s3_subdivide_from;
	            content.S3_SUBDIVIDE_TO = s3_subdivide_to;
	            content.S3_BETWEEN_ZONE_COUNT = s3_between_zone_count;
	            Ranorex.Report.Info("Zone List: "+s3_between_zone_record.ToString());
	            //following may need debug
	            if (!s3_between_zone_count.Equals("0")) {
	            	string[] s3_between_zone_recordList = s3_between_zone_record.Split('|');
		            for (int i = 0; i < s3_between_zone_recordList.Length; i++)
		            {
		                RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1 s3_between_zone_records = new RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1();
		                s3_between_zone_records.S3_BETWEEN_ZONE = s3_between_zone_recordList[i];i++;
		                content.addS3_BETWEEN_ZONE_RECORD(s3_between_zone_records);
		            }
	            }
	
	            content.S3_AND_ZONE_COUNT = s3_and_zone_count;
	            //following may need debug
	            if (!s3_and_zone_count.Equals("0")) {
	            	string[] s3_and_zone_recordList = s3_and_zone_record.Split('|');
		            for (int i = 0; i < s3_and_zone_recordList.Length; i++)
		            {
		                RUM_RD_RTIRS3_AND_ZONE_RECORD_1 s3_and_zone_records = new RUM_RD_RTIRS3_AND_ZONE_RECORD_1();
		                s3_and_zone_records.S3_AND_ZONE = s3_and_zone_recordList[i];i++;
		                content.addS3_AND_ZONE_RECORD(s3_and_zone_records);
		            }
	            }
            }

            content.S4_PRESENCE = s4_presence;
            if (s4_presence.Equals("Y")) {
	            content.S4_FROM_LOCATION = s4_from_location;
	            content.S4_FIRST_SWITCH = s4_first_switch;
	            content.S4_COUNT = s4_count;
	            //following may need debug
	        	string[] s4_recordList = s4_record.Split('|');
	            for (int i = 0; i < s4_recordList.Length; i++)
	            {
	                RUM_RD_RTIRS4_RECORD_1 s4_records = new RUM_RD_RTIRS4_RECORD_1();
	                s4_records.S4_SEQUENCE = s4_recordList[i];i++;
	                s4_records.S4_TO_LOCATION = s4_recordList[i];i++;
	                s4_records.S4_TRACK = s4_recordList[i];i++;
	                content.addS4_RECORD(s4_records);
	            }
            }

            content.S5_UNTIL = s5_until;
            content.S7_HOLD_MAIN = s7_hold_main;
            content.S9_CLEAR_MAIN = s9_clear_main;

            rD_RTIR.HEADER = header;
            rD_RTIR.CONTENT = content;

            RD_RTIR_1 rum_rd_rtir = rD_RTIR.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(RD_RTIR_1));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, rum_rd_rtir);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = rD_RTIR.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createRD_RTIR_1Msmq(
            //string header_event_date, 
            //string header_event_time, 
            //string header_message_id, 
            //string header_sequence_number, 
            //string header_message_version, 
            //string header_source_sys, 
            //string header_destination_sys, 
            string header_district_name, 
            string header_user_id, 
            string header_division_name, 
            string request_id, 
            string pf_addressee, 
            string pf_addressee_type, 
            string requesting_employee, 
            string addressee_type, 
            string scac, 
            string symbol, 
            string section, 
            string origin_date, 
            string engine_initial, 
            string engine_number, 
            string coupled_engine_initial, 
            string coupled_engine_number, 
            string employee_first, 
            string employee_middle, 
            string employee_last, 
            string addressee_id,
            string ru_comments,
            string at_location, 
            string spaf_ack, 
            string have_joint_occupants,
            string s1_track_authority_to_void,
			string s1_track_authority_id,             
            string s2_presence, 
            string s2_from_location, 
            string s2_first_switch, 
            string s2_count, 
            string s2_record,
			string s2_sequence, 
            string s2_to_location, 
            string s2_track,            
            string s3_presence, 
            string s3_between, 
            string s3_between_cp, 
            string s3_os, 
            string s3_and, 
            string s3_and_cp, 
            string s3_track_count, 
            string s3_track_record,
			string s3_track_sequence, 
            string s3_track_text,             
            string s3_subdivide_from, 
            string s3_subdivide_to, 
            string s3_between_zone_count, 
            string s3_between_zone_record,
			string s3_between_zone,           
            string s3_and_zone_count, 
            string s3_and_zone_record,
            string s3_and_zone, 
            string s4_presence, 
            string s4_from_location, 
            string s4_first_switch, 
            string s4_count, 
            string s4_record,
			string s4_sequence, 
            string s4_to_location, 
            string s4_track,            
            string s5_until, 
            string s7_hold_main, 
            string s9_clear_main
        ) {
            RUM_RD_RTIR_1 rD_RTIR = new RUM_RD_RTIR_1();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";


            RUM_RD_RTIRHEADER_1 header = new RUM_RD_RTIRHEADER_1();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmmss");
            header.HEADER_MESSAGE_ID = "RD-RTIR";
            header.HEADER_SEQUENCE_NUMBER = "1"; //I think this is auto generated despite what is put here...
            header.HEADER_MESSAGE_VERSION = "1";
            header.HEADER_SOURCE_SYS = "RU";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_USER_ID = header_user_id;
            header.HEADER_DIVISION_NAME = header_division_name;

            RUM_RD_RTIRCONTENT_1 content = new RUM_RD_RTIRCONTENT_1();
            content.REQUEST_ID = request_id;
            content.PF_ADDRESSEE = pf_addressee;
            content.PF_ADDRESSEE_TYPE = pf_addressee_type;
            content.REQUESTING_EMPLOYEE = requesting_employee;
            content.ADDRESSEE_TYPE = addressee_type;
            content.SCAC = scac;
            content.SYMBOL = symbol;
            content.SECTION = section;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.ENGINE_INITIAL = engine_initial;
            content.ENGINE_NUMBER = engine_number;
            content.COUPLED_ENGINE_INITIAL = coupled_engine_initial;
            content.COUPLED_ENGINE_NUMBER = coupled_engine_number;
            content.EMPLOYEE_FIRST = employee_first;
            content.EMPLOYEE_MIDDLE = employee_middle;
            content.EMPLOYEE_LAST = employee_last;
            content.ADDRESSEE_ID = addressee_id;
            if(ru_comments == "null")
            {
            	content.RU_COMMENTS = null;
            }
            else
            {
            	content.RU_COMMENTS = ru_comments;
            }
            content.AT_LOCATION = at_location;
            content.SPAF_ACK = spaf_ack;
            content.S1_HAVE_JOINT_OCCUPANTS = have_joint_occupants;
            content.S1_TRACK_AUTHORITY_TO_VOID = s1_track_authority_to_void;
            if(String.IsNullOrEmpty(s1_track_authority_id))
            {
            	content.S1_TRACK_AUTHORITY_ID = null;
            }
            else
            {
            	content.S1_TRACK_AUTHORITY_ID = s1_track_authority_id;
            }
            content.S2_PRESENCE = s2_presence;
            if (s2_presence.Equals("Y")) {
	            content.S2_FROM_LOCATION = s2_from_location;
	            content.S2_FIRST_SWITCH = s2_first_switch;
	            content.S2_COUNT = s2_count;
	            string[] s2_recordList = s2_record.Split('|');
	            for (int i = 0; i < s2_recordList.Length;) {
	                RUM_RD_RTIRS2_RECORD_1 s2_records = new RUM_RD_RTIRS2_RECORD_1();
	                s2_records.S2_SEQUENCE = s2_recordList[i];i++;
	                s2_records.S2_TO_LOCATION = s2_recordList[i];i++;
	                s2_records.S2_TRACK = s2_recordList[i];i++;
	                content.addS2_RECORD(s2_records);
	            }
            }

            content.S3_PRESENCE = s3_presence;
            if (s3_presence.Equals("Y")) {
	            content.S3_BETWEEN = s3_between;
	            content.S3_BETWEEN_CP = s3_between_cp;
	            content.S3_OS = s3_os;
	            content.S3_AND = s3_and;
	            content.S3_AND_CP = s3_and_cp;
	            content.S3_TRACK_COUNT = s3_track_count;
            	string[] s3_track_recordList = s3_track_record.Split('|');
	            for (int i = 0; i < s3_track_recordList.Length; i++)
	            {
	                RUM_RD_RTIRS3_TRACK_RECORD_1 s3_track_records = new RUM_RD_RTIRS3_TRACK_RECORD_1();
	                s3_track_records.S3_TRACK_SEQUENCE = s3_track_recordList[i];i++;
	                s3_track_records.S3_TRACK_TEXT = s3_track_recordList[i];i++;
	                content.addS3_TRACK_RECORD(s3_track_records);
	            }	
	
	            content.S3_SUBDIVIDE_FROM = s3_subdivide_from;
	            content.S3_SUBDIVIDE_TO = s3_subdivide_to;
	            content.S3_BETWEEN_ZONE_COUNT = s3_between_zone_count;
	            //following may need debug
	            if (!s3_between_zone_count.Equals("0")) {
	            	string[] s3_between_zone_recordList = s3_between_zone_record.Split('|');
		            for (int i = 0; i < s3_between_zone_recordList.Length; i++)
		            {
		                RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1 s3_between_zone_records = new RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1();
		                s3_between_zone_records.S3_BETWEEN_ZONE = s3_between_zone_recordList[i];i++;
		                content.addS3_BETWEEN_ZONE_RECORD(s3_between_zone_records);
		            }
	            }
	
	            content.S3_AND_ZONE_COUNT = s3_and_zone_count;
	            //following may need debug
	            if (!s3_and_zone_count.Equals("0")) {
	            	string[] s3_and_zone_recordList = s3_and_zone_record.Split('|');
		            for (int i = 0; i < s3_and_zone_recordList.Length; i++)
		            {
		                RUM_RD_RTIRS3_AND_ZONE_RECORD_1 s3_and_zone_records = new RUM_RD_RTIRS3_AND_ZONE_RECORD_1();
		                s3_and_zone_records.S3_AND_ZONE = s3_and_zone_recordList[i];i++;
		                content.addS3_AND_ZONE_RECORD(s3_and_zone_records);
		            }
	            }
            }

            content.S4_PRESENCE = s4_presence;
            if (s4_presence.Equals("Y")) {
	            content.S4_FROM_LOCATION = s4_from_location;
	            content.S4_FIRST_SWITCH = s4_first_switch;
	            content.S4_COUNT = s4_count;
	            //following may need debug
	        	string[] s4_recordList = s4_record.Split('|');
	            for (int i = 0; i < s4_recordList.Length; i++)
	            {
	                RUM_RD_RTIRS4_RECORD_1 s4_records = new RUM_RD_RTIRS4_RECORD_1();
	                s4_records.S4_SEQUENCE = s4_recordList[i];i++;
	                s4_records.S4_TO_LOCATION = s4_recordList[i];i++;
	                s4_records.S4_TRACK = s4_recordList[i];i++;
	                content.addS4_RECORD(s4_records);
	            }
            }

            content.S5_UNTIL = s5_until;
            content.S7_HOLD_MAIN = s7_hold_main;
            content.S9_CLEAR_MAIN = s9_clear_main;

            rD_RTIR.HEADER = header;
            rD_RTIR.CONTENT = content;

            RD_RTIR_1 rum_rd_rtir = rD_RTIR.toSerializableObject();
            serializer = new XmlSerializer(typeof(RD_RTIR_1));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, rum_rd_rtir);
            request = rD_RTIR.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "RUM_RD-RTIR");
        }

        public RD_RTIR_1 toSerializableObject() {
            RD_RTIR_1 rd_rtir_1 = new RD_RTIR_1();
            rd_rtir_1.Items = new object[2];

            RD_RTIRHEADER_1 header = new RD_RTIRHEADER_1();
            if (this.HEADER.HEADER_EVENT_DATE != null) {
                header.HEADER_EVENT_DATE = new RD_RTIRHEADERHEADER_EVENT_DATE_1[1];
                RD_RTIRHEADERHEADER_EVENT_DATE_1 header_event_date = new RD_RTIRHEADERHEADER_EVENT_DATE_1();
                header_event_date.Value = this.HEADER.HEADER_EVENT_DATE;
                header.HEADER_EVENT_DATE[0] = header_event_date;
            }

            if (this.HEADER.HEADER_EVENT_TIME != null) {
                header.HEADER_EVENT_TIME = new RD_RTIRHEADERHEADER_EVENT_TIME_1[1];
                RD_RTIRHEADERHEADER_EVENT_TIME_1 header_event_time = new RD_RTIRHEADERHEADER_EVENT_TIME_1();
                header_event_time.Value = this.HEADER.HEADER_EVENT_TIME;
                header.HEADER_EVENT_TIME[0] = header_event_time;
            }

            if (this.HEADER.HEADER_MESSAGE_ID != null) {
                header.HEADER_MESSAGE_ID = new RD_RTIRHEADERHEADER_MESSAGE_ID_1[1];
                RD_RTIRHEADERHEADER_MESSAGE_ID_1 header_message_id = new RD_RTIRHEADERHEADER_MESSAGE_ID_1();
                header_message_id.Value = this.HEADER.HEADER_MESSAGE_ID;
                header.HEADER_MESSAGE_ID[0] = header_message_id;
            }

            if (this.HEADER.HEADER_SEQUENCE_NUMBER != null) {
                header.HEADER_SEQUENCE_NUMBER = new RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1[1];
                RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1 header_sequence_number = new RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1();
                header_sequence_number.Value = this.HEADER.HEADER_SEQUENCE_NUMBER;
                header.HEADER_SEQUENCE_NUMBER[0] = header_sequence_number;
            }

            if (this.HEADER.HEADER_MESSAGE_VERSION != null) {
                header.HEADER_MESSAGE_VERSION = new RD_RTIRHEADERHEADER_MESSAGE_VERSION_1[1];
                RD_RTIRHEADERHEADER_MESSAGE_VERSION_1 header_message_version = new RD_RTIRHEADERHEADER_MESSAGE_VERSION_1();
                header_message_version.Value = this.HEADER.HEADER_MESSAGE_VERSION;
                header.HEADER_MESSAGE_VERSION[0] = header_message_version;
            }

            if (this.HEADER.HEADER_SOURCE_SYS != null) {
                header.HEADER_SOURCE_SYS = new RD_RTIRHEADERHEADER_SOURCE_SYS_1[1];
                RD_RTIRHEADERHEADER_SOURCE_SYS_1 header_source_sys = new RD_RTIRHEADERHEADER_SOURCE_SYS_1();
                header_source_sys.Value = this.HEADER.HEADER_SOURCE_SYS;
                header.HEADER_SOURCE_SYS[0] = header_source_sys;
            }

            if (this.HEADER.HEADER_DESTINATION_SYS != null) {
                header.HEADER_DESTINATION_SYS = new RD_RTIRHEADERHEADER_DESTINATION_SYS_1[1];
                RD_RTIRHEADERHEADER_DESTINATION_SYS_1 header_destination_sys = new RD_RTIRHEADERHEADER_DESTINATION_SYS_1();
                header_destination_sys.Value = this.HEADER.HEADER_DESTINATION_SYS;
                header.HEADER_DESTINATION_SYS[0] = header_destination_sys;
            }

            if (this.HEADER.HEADER_DISTRICT_NAME != null) {
                header.HEADER_DISTRICT_NAME = new RD_RTIRHEADERHEADER_DISTRICT_NAME_1[1];
                RD_RTIRHEADERHEADER_DISTRICT_NAME_1 header_district_name = new RD_RTIRHEADERHEADER_DISTRICT_NAME_1();
                header_district_name.Value = this.HEADER.HEADER_DISTRICT_NAME;
                header.HEADER_DISTRICT_NAME[0] = header_district_name;
            }

            if (this.HEADER.HEADER_USER_ID != null) {
                header.HEADER_USER_ID = new RD_RTIRHEADERHEADER_USER_ID_1[1];
                RD_RTIRHEADERHEADER_USER_ID_1 header_user_id = new RD_RTIRHEADERHEADER_USER_ID_1();
                header_user_id.Value = this.HEADER.HEADER_USER_ID;
                header.HEADER_USER_ID[0] = header_user_id;
            }

            if (this.HEADER.HEADER_DIVISION_NAME != null) {
                header.HEADER_DIVISION_NAME = new RD_RTIRHEADERHEADER_DIVISION_NAME_1[1];
                RD_RTIRHEADERHEADER_DIVISION_NAME_1 header_division_name = new RD_RTIRHEADERHEADER_DIVISION_NAME_1();
                header_division_name.Value = this.HEADER.HEADER_DIVISION_NAME;
                header.HEADER_DIVISION_NAME[0] = header_division_name;
            }

            RD_RTIRCONTENT_1 content = new RD_RTIRCONTENT_1();
            if (this.CONTENT.REQUEST_ID != null) {
                content.REQUEST_ID = new RD_RTIRCONTENTREQUEST_ID_1[1];
                RD_RTIRCONTENTREQUEST_ID_1 request_id = new RD_RTIRCONTENTREQUEST_ID_1();
                request_id.Value = this.CONTENT.REQUEST_ID;
                content.REQUEST_ID[0] = request_id;
            }

            if (this.CONTENT.PF_ADDRESSEE != null) {
                content.PF_ADDRESSEE = new RD_RTIRCONTENTPF_ADDRESSEE_1[1];
                RD_RTIRCONTENTPF_ADDRESSEE_1 pf_addressee = new RD_RTIRCONTENTPF_ADDRESSEE_1();
                pf_addressee.Value = this.CONTENT.PF_ADDRESSEE;
                content.PF_ADDRESSEE[0] = pf_addressee;
            }

            if (this.CONTENT.PF_ADDRESSEE_TYPE != null) {
                content.PF_ADDRESSEE_TYPE = new RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1[1];
                RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1 pf_addressee_type = new RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1();
                pf_addressee_type.Value = this.CONTENT.PF_ADDRESSEE_TYPE;
                content.PF_ADDRESSEE_TYPE[0] = pf_addressee_type;
            }

            if (this.CONTENT.REQUESTING_EMPLOYEE != null) {
                content.REQUESTING_EMPLOYEE = new RD_RTIRCONTENTREQUESTING_EMPLOYEE_1[1];
                RD_RTIRCONTENTREQUESTING_EMPLOYEE_1 requesting_employee = new RD_RTIRCONTENTREQUESTING_EMPLOYEE_1();
                requesting_employee.Value = this.CONTENT.REQUESTING_EMPLOYEE;
                content.REQUESTING_EMPLOYEE[0] = requesting_employee;
            }

            if (this.CONTENT.ADDRESSEE_TYPE != null) {
                content.ADDRESSEE_TYPE = new RD_RTIRCONTENTADDRESSEE_TYPE_1[1];
                RD_RTIRCONTENTADDRESSEE_TYPE_1 addressee_type = new RD_RTIRCONTENTADDRESSEE_TYPE_1();
                addressee_type.Value = this.CONTENT.ADDRESSEE_TYPE;
                content.ADDRESSEE_TYPE[0] = addressee_type;
            }

            if (this.CONTENT.SCAC != null) {
                content.SCAC = new RD_RTIRCONTENTSCAC_1[1];
                RD_RTIRCONTENTSCAC_1 scac = new RD_RTIRCONTENTSCAC_1();
                scac.Value = this.CONTENT.SCAC;
                content.SCAC[0] = scac;
            }

            if (this.CONTENT.SYMBOL != null) {
                content.SYMBOL = new RD_RTIRCONTENTSYMBOL_1[1];
                RD_RTIRCONTENTSYMBOL_1 symbol = new RD_RTIRCONTENTSYMBOL_1();
                symbol.Value = this.CONTENT.SYMBOL;
                content.SYMBOL[0] = symbol;
            }

            if (this.CONTENT.SECTION != null) {
                content.SECTION = new RD_RTIRCONTENTSECTION_1[1];
                RD_RTIRCONTENTSECTION_1 section = new RD_RTIRCONTENTSECTION_1();
                section.Value = this.CONTENT.SECTION;
                content.SECTION[0] = section;
            }

            if (this.CONTENT.ORIGIN_DATE != null) {
                content.ORIGIN_DATE = new RD_RTIRCONTENTORIGIN_DATE_1[1];
                RD_RTIRCONTENTORIGIN_DATE_1 origin_date = new RD_RTIRCONTENTORIGIN_DATE_1();
                origin_date.Value = this.CONTENT.ORIGIN_DATE;
                content.ORIGIN_DATE[0] = origin_date;
            }

            if (this.CONTENT.ENGINE_INITIAL != null) {
                content.ENGINE_INITIAL = new RD_RTIRCONTENTENGINE_INITIAL_1[1];
                RD_RTIRCONTENTENGINE_INITIAL_1 engine_initial = new RD_RTIRCONTENTENGINE_INITIAL_1();
                engine_initial.Value = this.CONTENT.ENGINE_INITIAL;
                content.ENGINE_INITIAL[0] = engine_initial;
            }

            if (this.CONTENT.ENGINE_NUMBER != null) {
                content.ENGINE_NUMBER = new RD_RTIRCONTENTENGINE_NUMBER_1[1];
                RD_RTIRCONTENTENGINE_NUMBER_1 engine_number = new RD_RTIRCONTENTENGINE_NUMBER_1();
                engine_number.Value = this.CONTENT.ENGINE_NUMBER;
                content.ENGINE_NUMBER[0] = engine_number;
            }

            if (this.CONTENT.COUPLED_ENGINE_INITIAL != null) {
                content.COUPLED_ENGINE_INITIAL = new RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1[1];
                RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1 coupled_engine_initial = new RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1();
                coupled_engine_initial.Value = this.CONTENT.COUPLED_ENGINE_INITIAL;
                content.COUPLED_ENGINE_INITIAL[0] = coupled_engine_initial;
            }

            if (this.CONTENT.COUPLED_ENGINE_NUMBER != null) {
                content.COUPLED_ENGINE_NUMBER = new RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1[1];
                RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1 coupled_engine_number = new RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1();
                coupled_engine_number.Value = this.CONTENT.COUPLED_ENGINE_NUMBER;
                content.COUPLED_ENGINE_NUMBER[0] = coupled_engine_number;
            }

            if (this.CONTENT.EMPLOYEE_FIRST != null) {
                content.EMPLOYEE_FIRST = new RD_RTIRCONTENTEMPLOYEE_FIRST_1[1];
                RD_RTIRCONTENTEMPLOYEE_FIRST_1 employee_first = new RD_RTIRCONTENTEMPLOYEE_FIRST_1();
                employee_first.Value = this.CONTENT.EMPLOYEE_FIRST;
                content.EMPLOYEE_FIRST[0] = employee_first;
            }

            if (this.CONTENT.EMPLOYEE_MIDDLE != null) {
                content.EMPLOYEE_MIDDLE = new RD_RTIRCONTENTEMPLOYEE_MIDDLE_1[1];
                RD_RTIRCONTENTEMPLOYEE_MIDDLE_1 employee_middle = new RD_RTIRCONTENTEMPLOYEE_MIDDLE_1();
                employee_middle.Value = this.CONTENT.EMPLOYEE_MIDDLE;
                content.EMPLOYEE_MIDDLE[0] = employee_middle;
            }

            if (this.CONTENT.EMPLOYEE_LAST != null) {
                content.EMPLOYEE_LAST = new RD_RTIRCONTENTEMPLOYEE_LAST_1[1];
                RD_RTIRCONTENTEMPLOYEE_LAST_1 employee_last = new RD_RTIRCONTENTEMPLOYEE_LAST_1();
                employee_last.Value = this.CONTENT.EMPLOYEE_LAST;
                content.EMPLOYEE_LAST[0] = employee_last;
            }

            if (this.CONTENT.ADDRESSEE_ID != null) {
                content.ADDRESSEE_ID = new RD_RTIRCONTENTADDRESSEE_ID_1[1];
                RD_RTIRCONTENTADDRESSEE_ID_1 addressee_id = new RD_RTIRCONTENTADDRESSEE_ID_1();
                addressee_id.Value = this.CONTENT.ADDRESSEE_ID;
                content.ADDRESSEE_ID[0] = addressee_id;
            }
            if (this.CONTENT.RU_COMMENTS != null) {
            	content.RU_COMMENTS = new RD_RTIRCONTENTRU_COMMENTS_1[1];
            	RD_RTIRCONTENTRU_COMMENTS_1 ru_comments = new RD_RTIRCONTENTRU_COMMENTS_1();
            	ru_comments.Value = this.CONTENT.RU_COMMENTS;
            	content.RU_COMMENTS[0] = ru_comments;
            }

            if (this.CONTENT.AT_LOCATION != null) {
                content.AT_LOCATION = new RD_RTIRCONTENTAT_LOCATION_1[1];
                RD_RTIRCONTENTAT_LOCATION_1 at_location = new RD_RTIRCONTENTAT_LOCATION_1();
                at_location.Value = this.CONTENT.AT_LOCATION;
                content.AT_LOCATION[0] = at_location;
            }

            if (this.CONTENT.SPAF_ACK != null) {
                content.SPAF_ACK = new RD_RTIRCONTENTSPAF_ACK_1[1];
                RD_RTIRCONTENTSPAF_ACK_1 spaf_ack = new RD_RTIRCONTENTSPAF_ACK_1();
                spaf_ack.Value = this.CONTENT.SPAF_ACK;
                content.SPAF_ACK[0] = spaf_ack;
            }

            if (this.CONTENT.S1_TRACK_AUTHORITY_TO_VOID != null) {
                content.S1_TRACK_AUTHORITY_TO_VOID = new RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1[1];
                RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1 s1_track_authority_to_void = new RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1();
                s1_track_authority_to_void.Value = this.CONTENT.S1_TRACK_AUTHORITY_TO_VOID;
                content.S1_TRACK_AUTHORITY_TO_VOID[0] = s1_track_authority_to_void;
            }
            
            if (this.CONTENT.S1_TRACK_AUTHORITY_ID != null) {
            	content.S1_TRACK_AUTHORITY_ID = new RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1[1];
            	RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1 s1_track_authority_id = new RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1();
            	s1_track_authority_id.Value = this.CONTENT.S1_TRACK_AUTHORITY_ID;
            	content.S1_TRACK_AUTHORITY_ID[0] = s1_track_authority_id;
            }
            
            
            if (this.CONTENT.S1_HAVE_JOINT_OCCUPANTS != null) {
                content.S1_HAVE_JOINT_OCCUPANTS = new RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1[1];
                RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1 have_joint_occupants = new RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1();
                have_joint_occupants.Value = this.CONTENT.S1_HAVE_JOINT_OCCUPANTS;
                content.S1_HAVE_JOINT_OCCUPANTS[0] = have_joint_occupants;
            }

            if (this.CONTENT.S2_PRESENCE != null) {
                content.S2_PRESENCE = new RD_RTIRCONTENTS2_PRESENCE_1[1];
                RD_RTIRCONTENTS2_PRESENCE_1 s2_presence = new RD_RTIRCONTENTS2_PRESENCE_1();
                s2_presence.Value = this.CONTENT.S2_PRESENCE;
                content.S2_PRESENCE[0] = s2_presence;
            }

            if (this.CONTENT.S2_FROM_LOCATION != null) {
                content.S2_FROM_LOCATION = new RD_RTIRCONTENTS2_FROM_LOCATION_1[1];
                RD_RTIRCONTENTS2_FROM_LOCATION_1 s2_from_location = new RD_RTIRCONTENTS2_FROM_LOCATION_1();
                s2_from_location.Value = this.CONTENT.S2_FROM_LOCATION;
                content.S2_FROM_LOCATION[0] = s2_from_location;
            }

            if (this.CONTENT.S2_FIRST_SWITCH != null) {
                content.S2_FIRST_SWITCH = new RD_RTIRCONTENTS2_FIRST_SWITCH_1[1];
                RD_RTIRCONTENTS2_FIRST_SWITCH_1 s2_first_switch = new RD_RTIRCONTENTS2_FIRST_SWITCH_1();
                s2_first_switch.Value = this.CONTENT.S2_FIRST_SWITCH;
                content.S2_FIRST_SWITCH[0] = s2_first_switch;
            }

            if (this.CONTENT.S2_COUNT != null) {
                content.S2_COUNT = new RD_RTIRCONTENTS2_COUNT_1[1];
                RD_RTIRCONTENTS2_COUNT_1 s2_count = new RD_RTIRCONTENTS2_COUNT_1();
                s2_count.Value = this.CONTENT.S2_COUNT;
                content.S2_COUNT[0] = s2_count;
            }

            int s2_recordIndex = 0;
            content.S2_RECORD = new RD_RTIRCONTENTS2_RECORD_1[this.CONTENT.S2_RECORD.Count];
            foreach (RUM_RD_RTIRS2_RECORD_1 record in this.CONTENT.S2_RECORD) {
                RD_RTIRCONTENTS2_RECORD_1 s2_record_record = new RD_RTIRCONTENTS2_RECORD_1(); 
                if (record.S2_SEQUENCE != null) {
                    s2_record_record.S2_SEQUENCE = new RD_RTIRS2_RECORDS2_SEQUENCE_1[1];
                    RD_RTIRS2_RECORDS2_SEQUENCE_1 s2_record = new RD_RTIRS2_RECORDS2_SEQUENCE_1();
                    s2_record.Value = record.S2_SEQUENCE;
                    s2_record_record.S2_SEQUENCE[0] = s2_record;
                }

                if (record.S2_TO_LOCATION != null) {
                    s2_record_record.S2_TO_LOCATION = new RD_RTIRS2_RECORDS2_TO_LOCATION_1[1];
                    RD_RTIRS2_RECORDS2_TO_LOCATION_1 s2_record = new RD_RTIRS2_RECORDS2_TO_LOCATION_1();
                    s2_record.Value = record.S2_TO_LOCATION;
                    s2_record_record.S2_TO_LOCATION[0] = s2_record;
                }

                if (record.S2_TRACK != null) {
                    s2_record_record.S2_TRACK = new RD_RTIRS2_RECORDS2_TRACK_1[1];
                    RD_RTIRS2_RECORDS2_TRACK_1 s2_record = new RD_RTIRS2_RECORDS2_TRACK_1();
                    s2_record.Value = record.S2_TRACK;
                    s2_record_record.S2_TRACK[0] = s2_record;
                }

                content.S2_RECORD[s2_recordIndex] = s2_record_record;
                s2_recordIndex++;
            }

            if (this.CONTENT.S3_PRESENCE != null) {
                content.S3_PRESENCE = new RD_RTIRCONTENTS3_PRESENCE_1[1];
                RD_RTIRCONTENTS3_PRESENCE_1 s3_presence = new RD_RTIRCONTENTS3_PRESENCE_1();
                s3_presence.Value = this.CONTENT.S3_PRESENCE;
                content.S3_PRESENCE[0] = s3_presence;
            }

            if (this.CONTENT.S3_BETWEEN != null) {
                content.S3_BETWEEN = new RD_RTIRCONTENTS3_BETWEEN_1[1];
                RD_RTIRCONTENTS3_BETWEEN_1 s3_between = new RD_RTIRCONTENTS3_BETWEEN_1();
                s3_between.Value = this.CONTENT.S3_BETWEEN;
                content.S3_BETWEEN[0] = s3_between;
            }

            if (this.CONTENT.S3_BETWEEN_CP != null) {
                content.S3_BETWEEN_CP = new RD_RTIRCONTENTS3_BETWEEN_CP_1[1];
                RD_RTIRCONTENTS3_BETWEEN_CP_1 s3_between_cp = new RD_RTIRCONTENTS3_BETWEEN_CP_1();
                s3_between_cp.Value = this.CONTENT.S3_BETWEEN_CP;
                content.S3_BETWEEN_CP[0] = s3_between_cp;
            }

            if (this.CONTENT.S3_OS != null) {
                content.S3_OS = new RD_RTIRCONTENTS3_OS_1[1];
                RD_RTIRCONTENTS3_OS_1 s3_os = new RD_RTIRCONTENTS3_OS_1();
                s3_os.Value = this.CONTENT.S3_OS;
                content.S3_OS[0] = s3_os;
            }

            if (this.CONTENT.S3_AND != null) {
                content.S3_AND = new RD_RTIRCONTENTS3_AND_1[1];
                RD_RTIRCONTENTS3_AND_1 s3_and = new RD_RTIRCONTENTS3_AND_1();
                s3_and.Value = this.CONTENT.S3_AND;
                content.S3_AND[0] = s3_and;
            }

            if (this.CONTENT.S3_AND_CP != null) {
                content.S3_AND_CP = new RD_RTIRCONTENTS3_AND_CP_1[1];
                RD_RTIRCONTENTS3_AND_CP_1 s3_and_cp = new RD_RTIRCONTENTS3_AND_CP_1();
                s3_and_cp.Value = this.CONTENT.S3_AND_CP;
                content.S3_AND_CP[0] = s3_and_cp;
            }

            if (this.CONTENT.S3_TRACK_COUNT != null) {
                content.S3_TRACK_COUNT = new RD_RTIRCONTENTS3_TRACK_COUNT_1[1];
                RD_RTIRCONTENTS3_TRACK_COUNT_1 s3_track_count = new RD_RTIRCONTENTS3_TRACK_COUNT_1();
                s3_track_count.Value = this.CONTENT.S3_TRACK_COUNT;
                content.S3_TRACK_COUNT[0] = s3_track_count;
            }

            int s3_track_recordIndex = 0;
            content.S3_TRACK_RECORD = new RD_RTIRCONTENTS3_TRACK_RECORD_1[this.CONTENT.S3_TRACK_RECORD.Count];
            foreach (RUM_RD_RTIRS3_TRACK_RECORD_1 record in this.CONTENT.S3_TRACK_RECORD) {
                RD_RTIRCONTENTS3_TRACK_RECORD_1 s3_track_record_record = new RD_RTIRCONTENTS3_TRACK_RECORD_1(); 
                if (record.S3_TRACK_SEQUENCE != null) {
                    s3_track_record_record.S3_TRACK_SEQUENCE = new RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1[1];
                    RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1 s3_track_record = new RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1();
                    s3_track_record.Value = record.S3_TRACK_SEQUENCE;
                    s3_track_record_record.S3_TRACK_SEQUENCE[0] = s3_track_record;
                }

                if (record.S3_TRACK_TEXT != null) {
                    s3_track_record_record.S3_TRACK_TEXT = new RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1[1];
                    RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1 s3_track_record = new RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1();
                    s3_track_record.Value = record.S3_TRACK_TEXT;
                    s3_track_record_record.S3_TRACK_TEXT[0] = s3_track_record;
                }

                content.S3_TRACK_RECORD[s3_track_recordIndex] = s3_track_record_record;
                s3_track_recordIndex++;
            }

            if (this.CONTENT.S3_SUBDIVIDE_FROM != null) {
                content.S3_SUBDIVIDE_FROM = new RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1[1];
                RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1 s3_subdivide_from = new RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1();
                s3_subdivide_from.Value = this.CONTENT.S3_SUBDIVIDE_FROM;
                content.S3_SUBDIVIDE_FROM[0] = s3_subdivide_from;
            }

            if (this.CONTENT.S3_SUBDIVIDE_TO != null) {
                content.S3_SUBDIVIDE_TO = new RD_RTIRCONTENTS3_SUBDIVIDE_TO_1[1];
                RD_RTIRCONTENTS3_SUBDIVIDE_TO_1 s3_subdivide_to = new RD_RTIRCONTENTS3_SUBDIVIDE_TO_1();
                s3_subdivide_to.Value = this.CONTENT.S3_SUBDIVIDE_TO;
                content.S3_SUBDIVIDE_TO[0] = s3_subdivide_to;
            }

            if (this.CONTENT.S3_BETWEEN_ZONE_COUNT != null) {
                content.S3_BETWEEN_ZONE_COUNT = new RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1[1];
                RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1 s3_between_zone_count = new RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1();
                s3_between_zone_count.Value = this.CONTENT.S3_BETWEEN_ZONE_COUNT;
                content.S3_BETWEEN_ZONE_COUNT[0] = s3_between_zone_count;
            }

            int s3_between_zone_recordIndex = 0;
            content.S3_BETWEEN_ZONE_RECORD = new RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1[this.CONTENT.S3_BETWEEN_ZONE_RECORD.Count];
            foreach (RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1 record in this.CONTENT.S3_BETWEEN_ZONE_RECORD) {
                RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1 s3_between_zone_record_record = new RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1(); 
                if (record.S3_BETWEEN_ZONE != null) {
                    s3_between_zone_record_record.S3_BETWEEN_ZONE = new RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1[1];
                    RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1 s3_between_zone_record = new RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1();
                    s3_between_zone_record.Value = record.S3_BETWEEN_ZONE;
                    s3_between_zone_record_record.S3_BETWEEN_ZONE[0] = s3_between_zone_record;
                }

                content.S3_BETWEEN_ZONE_RECORD[s3_between_zone_recordIndex] = s3_between_zone_record_record;
                s3_between_zone_recordIndex++;
            }

            if (this.CONTENT.S3_AND_ZONE_COUNT != null) {
                content.S3_AND_ZONE_COUNT = new RD_RTIRCONTENTS3_AND_ZONE_COUNT_1[1];
                RD_RTIRCONTENTS3_AND_ZONE_COUNT_1 s3_and_zone_count = new RD_RTIRCONTENTS3_AND_ZONE_COUNT_1();
                s3_and_zone_count.Value = this.CONTENT.S3_AND_ZONE_COUNT;
                content.S3_AND_ZONE_COUNT[0] = s3_and_zone_count;
            }

            int s3_and_zone_recordIndex = 0;
            content.S3_AND_ZONE_RECORD = new RD_RTIRCONTENTS3_AND_ZONE_RECORD_1[this.CONTENT.S3_AND_ZONE_RECORD.Count];
            foreach (RUM_RD_RTIRS3_AND_ZONE_RECORD_1 record in this.CONTENT.S3_AND_ZONE_RECORD) {
                RD_RTIRCONTENTS3_AND_ZONE_RECORD_1 s3_and_zone_record_record = new RD_RTIRCONTENTS3_AND_ZONE_RECORD_1(); 
                if (record.S3_AND_ZONE != null) {
                    s3_and_zone_record_record.S3_AND_ZONE = new RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1[1];
                    RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1 s3_and_zone_record = new RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1();
                    s3_and_zone_record.Value = record.S3_AND_ZONE;
                    s3_and_zone_record_record.S3_AND_ZONE[0] = s3_and_zone_record;
                }

                content.S3_AND_ZONE_RECORD[s3_and_zone_recordIndex] = s3_and_zone_record_record;
                s3_and_zone_recordIndex++;
            }

            if (this.CONTENT.S4_PRESENCE != null) {
                content.S4_PRESENCE = new RD_RTIRCONTENTS4_PRESENCE_1[1];
                RD_RTIRCONTENTS4_PRESENCE_1 s4_presence = new RD_RTIRCONTENTS4_PRESENCE_1();
                s4_presence.Value = this.CONTENT.S4_PRESENCE;
                content.S4_PRESENCE[0] = s4_presence;
            }

            if (this.CONTENT.S4_FROM_LOCATION != null) {
                content.S4_FROM_LOCATION = new RD_RTIRCONTENTS4_FROM_LOCATION_1[1];
                RD_RTIRCONTENTS4_FROM_LOCATION_1 s4_from_location = new RD_RTIRCONTENTS4_FROM_LOCATION_1();
                s4_from_location.Value = this.CONTENT.S4_FROM_LOCATION;
                content.S4_FROM_LOCATION[0] = s4_from_location;
            }

            if (this.CONTENT.S4_FIRST_SWITCH != null) {
                content.S4_FIRST_SWITCH = new RD_RTIRCONTENTS4_FIRST_SWITCH_1[1];
                RD_RTIRCONTENTS4_FIRST_SWITCH_1 s4_first_switch = new RD_RTIRCONTENTS4_FIRST_SWITCH_1();
                s4_first_switch.Value = this.CONTENT.S4_FIRST_SWITCH;
                content.S4_FIRST_SWITCH[0] = s4_first_switch;
            }

            if (this.CONTENT.S4_COUNT != null) {
                content.S4_COUNT = new RD_RTIRCONTENTS4_COUNT_1[1];
                RD_RTIRCONTENTS4_COUNT_1 s4_count = new RD_RTIRCONTENTS4_COUNT_1();
                s4_count.Value = this.CONTENT.S4_COUNT;
                content.S4_COUNT[0] = s4_count;
            }

            int s4_recordIndex = 0;
            content.S4_RECORD = new RD_RTIRCONTENTS4_RECORD_1[this.CONTENT.S4_RECORD.Count];
            foreach (RUM_RD_RTIRS4_RECORD_1 record in this.CONTENT.S4_RECORD) {
                RD_RTIRCONTENTS4_RECORD_1 s4_record_record = new RD_RTIRCONTENTS4_RECORD_1(); 
                if (record.S4_SEQUENCE != null) {
                    s4_record_record.S4_SEQUENCE = new RD_RTIRS4_RECORDS4_SEQUENCE_1[1];
                    RD_RTIRS4_RECORDS4_SEQUENCE_1 s4_record = new RD_RTIRS4_RECORDS4_SEQUENCE_1();
                    s4_record.Value = record.S4_SEQUENCE;
                    s4_record_record.S4_SEQUENCE[0] = s4_record;
                }

                if (record.S4_TO_LOCATION != null) {
                    s4_record_record.S4_TO_LOCATION = new RD_RTIRS4_RECORDS4_TO_LOCATION_1[1];
                    RD_RTIRS4_RECORDS4_TO_LOCATION_1 s4_record = new RD_RTIRS4_RECORDS4_TO_LOCATION_1();
                    s4_record.Value = record.S4_TO_LOCATION;
                    s4_record_record.S4_TO_LOCATION[0] = s4_record;
                }

                if (record.S4_TRACK != null) {
                    s4_record_record.S4_TRACK = new RD_RTIRS4_RECORDS4_TRACK_1[1];
                    RD_RTIRS4_RECORDS4_TRACK_1 s4_record = new RD_RTIRS4_RECORDS4_TRACK_1();
                    s4_record.Value = record.S4_TRACK;
                    s4_record_record.S4_TRACK[0] = s4_record;
                }

                content.S4_RECORD[s4_recordIndex] = s4_record_record;
                s4_recordIndex++;
            }

            if (this.CONTENT.S5_UNTIL != null) {
                content.S5_UNTIL = new RD_RTIRCONTENTS5_UNTIL_1[1];
                RD_RTIRCONTENTS5_UNTIL_1 s5_until = new RD_RTIRCONTENTS5_UNTIL_1();
                s5_until.Value = this.CONTENT.S5_UNTIL;
                content.S5_UNTIL[0] = s5_until;
            }

            if (this.CONTENT.S7_HOLD_MAIN != null) {
                content.S7_HOLD_MAIN = new RD_RTIRCONTENTS7_HOLD_MAIN_1[1];
                RD_RTIRCONTENTS7_HOLD_MAIN_1 s7_hold_main = new RD_RTIRCONTENTS7_HOLD_MAIN_1();
                s7_hold_main.Value = this.CONTENT.S7_HOLD_MAIN;
                content.S7_HOLD_MAIN[0] = s7_hold_main;
            }

            if (this.CONTENT.S9_CLEAR_MAIN != null) {
                content.S9_CLEAR_MAIN = new RD_RTIRCONTENTS9_CLEAR_MAIN_1[1];
                RD_RTIRCONTENTS9_CLEAR_MAIN_1 s9_clear_main = new RD_RTIRCONTENTS9_CLEAR_MAIN_1();
                s9_clear_main.Value = this.CONTENT.S9_CLEAR_MAIN;
                content.S9_CLEAR_MAIN[0] = s9_clear_main;
            }

            rd_rtir_1.Items[0] = header;
            rd_rtir_1.Items[1] = content;
            return rd_rtir_1;
        }

        public string toSteMessageHeader(string serializedXml) {
        	int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
            int headerTo   = serializedXml.LastIndexOf("</HEADER>");
            int from = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
            int to   = serializedXml.LastIndexOf("</CONTENT>");
            string header = "PASSTHRUOTC|RD-RTIR|";
            string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(from, to-from);
            return result;
        }

    }

    public partial class RUM_RD_RTIRHEADER_1 {
        private string thisHEADER_EVENT_DATE = "";
        private string thisHEADER_EVENT_TIME = "";
        private string thisHEADER_MESSAGE_ID = "";
        private string thisHEADER_SEQUENCE_NUMBER = "";
        private string thisHEADER_MESSAGE_VERSION = "";
        private string thisHEADER_SOURCE_SYS = "";
        private string thisHEADER_DESTINATION_SYS = "";
        private string thisHEADER_DISTRICT_NAME = "";
        private string thisHEADER_USER_ID = "";
        private string thisHEADER_DIVISION_NAME = "";

        public string HEADER_EVENT_DATE {
            get { return this.thisHEADER_EVENT_DATE; }
            set { this.thisHEADER_EVENT_DATE = value; }
        }

        public string HEADER_EVENT_TIME {
            get { return this.thisHEADER_EVENT_TIME; }
            set { this.thisHEADER_EVENT_TIME = value; }
        }

        public string HEADER_MESSAGE_ID {
            get { return this.thisHEADER_MESSAGE_ID; }
            set { this.thisHEADER_MESSAGE_ID = value; }
        }

        public string HEADER_SEQUENCE_NUMBER {
            get { return this.thisHEADER_SEQUENCE_NUMBER; }
            set { this.thisHEADER_SEQUENCE_NUMBER = value; }
        }

        public string HEADER_MESSAGE_VERSION {
            get { return this.thisHEADER_MESSAGE_VERSION; }
            set { this.thisHEADER_MESSAGE_VERSION = value; }
        }

        public string HEADER_SOURCE_SYS {
            get { return this.thisHEADER_SOURCE_SYS; }
            set { this.thisHEADER_SOURCE_SYS = value; }
        }

        public string HEADER_DESTINATION_SYS {
            get { return this.thisHEADER_DESTINATION_SYS; }
            set { this.thisHEADER_DESTINATION_SYS = value; }
        }

        public string HEADER_DISTRICT_NAME {
            get { return this.thisHEADER_DISTRICT_NAME; }
            set { this.thisHEADER_DISTRICT_NAME = value; }
        }

        public string HEADER_USER_ID {
            get { return this.thisHEADER_USER_ID; }
            set { this.thisHEADER_USER_ID = value; }
        }

        public string HEADER_DIVISION_NAME {
            get { return this.thisHEADER_DIVISION_NAME; }
            set { this.thisHEADER_DIVISION_NAME = value; }
        }

    }

    public partial class RUM_RD_RTIRCONTENT_1 {
        private string thisREQUEST_ID = "";
        private string thisPF_ADDRESSEE = "";
        private string thisPF_ADDRESSEE_TYPE = "";
        private string thisREQUESTING_EMPLOYEE = "";
        private string thisADDRESSEE_TYPE = "";
        private string thisSCAC = "";
        private string thisSYMBOL = "";
        private string thisSECTION = "";
        private string thisORIGIN_DATE = "";
        private string thisENGINE_INITIAL = "";
        private string thisENGINE_NUMBER = "";
        private string thisCOUPLED_ENGINE_INITIAL = "";
        private string thisCOUPLED_ENGINE_NUMBER = "";
        private string thisEMPLOYEE_FIRST = "";
        private string thisEMPLOYEE_MIDDLE = "";
        private string thisEMPLOYEE_LAST = "";
        private string thisADDRESSEE_ID = "";
        private string thisRU_COMMENTS = "";
        private string thisAT_LOCATION = "";
        private string thisSPAF_ACK = "";
        private string thisS1_HAVE_JOINT_OCCUPANTS = "";
        private string thisS1_TRACK_AUTHORITY_TO_VOID = "";
        private string thisS1_TRACK_AUTHORITY_ID = "";
        private string thisS2_PRESENCE = "";
        private string thisS2_FROM_LOCATION = "";
        private string thisS2_FIRST_SWITCH = "";
        private string thisS2_COUNT = "";
        private ArrayList thisS2_RECORD = new ArrayList();
        private string thisS3_PRESENCE = "";
        private string thisS3_BETWEEN = "";
        private string thisS3_BETWEEN_CP = "";
        private string thisS3_OS = "";
        private string thisS3_AND = "";
        private string thisS3_AND_CP = "";
        private string thisS3_TRACK_COUNT = "";
        private ArrayList thisS3_TRACK_RECORD = new ArrayList();
        private string thisS3_SUBDIVIDE_FROM = "";
        private string thisS3_SUBDIVIDE_TO = "";
        private string thisS3_BETWEEN_ZONE_COUNT = "";
        private ArrayList thisS3_BETWEEN_ZONE_RECORD = new ArrayList();
        private string thisS3_AND_ZONE_COUNT = "";
        private ArrayList thisS3_AND_ZONE_RECORD = new ArrayList();
        private string thisS4_PRESENCE = "";
        private string thisS4_FROM_LOCATION = "";
        private string thisS4_FIRST_SWITCH = "";
        private string thisS4_COUNT = "";
        private ArrayList thisS4_RECORD = new ArrayList();
        private string thisS5_UNTIL = "";
        private string thisS7_HOLD_MAIN = "";
        private string thisS9_CLEAR_MAIN = "";

        public string REQUEST_ID {
            get { return this.thisREQUEST_ID; }
            set { this.thisREQUEST_ID = value; }
        }

        public string PF_ADDRESSEE {
            get { return this.thisPF_ADDRESSEE; }
            set { this.thisPF_ADDRESSEE = value; }
        }

        public string PF_ADDRESSEE_TYPE {
            get { return this.thisPF_ADDRESSEE_TYPE; }
            set { this.thisPF_ADDRESSEE_TYPE = value; }
        }

        public string REQUESTING_EMPLOYEE {
            get { return this.thisREQUESTING_EMPLOYEE; }
            set { this.thisREQUESTING_EMPLOYEE = value; }
        }

        public string ADDRESSEE_TYPE {
            get { return this.thisADDRESSEE_TYPE; }
            set { this.thisADDRESSEE_TYPE = value; }
        }

        public string SCAC {
            get { return this.thisSCAC; }
            set { this.thisSCAC = value; }
        }

        public string SYMBOL {
            get { return this.thisSYMBOL; }
            set { this.thisSYMBOL = value; }
        }

        public string SECTION {
            get { return this.thisSECTION; }
            set { this.thisSECTION = value; }
        }

        public string ORIGIN_DATE {
            get { return this.thisORIGIN_DATE; }
            set { this.thisORIGIN_DATE = value; }
        }

        public string ENGINE_INITIAL {
            get { return this.thisENGINE_INITIAL; }
            set { this.thisENGINE_INITIAL = value; }
        }

        public string ENGINE_NUMBER {
            get { return this.thisENGINE_NUMBER; }
            set { this.thisENGINE_NUMBER = value; }
        }

        public string COUPLED_ENGINE_INITIAL {
            get { return this.thisCOUPLED_ENGINE_INITIAL; }
            set { this.thisCOUPLED_ENGINE_INITIAL = value; }
        }

        public string COUPLED_ENGINE_NUMBER {
            get { return this.thisCOUPLED_ENGINE_NUMBER; }
            set { this.thisCOUPLED_ENGINE_NUMBER = value; }
        }

        public string EMPLOYEE_FIRST {
            get { return this.thisEMPLOYEE_FIRST; }
            set { this.thisEMPLOYEE_FIRST = value; }
        }

        public string EMPLOYEE_MIDDLE {
            get { return this.thisEMPLOYEE_MIDDLE; }
            set { this.thisEMPLOYEE_MIDDLE = value; }
        }

        public string EMPLOYEE_LAST {
            get { return this.thisEMPLOYEE_LAST; }
            set { this.thisEMPLOYEE_LAST = value; }
        }

        public string ADDRESSEE_ID {
            get { return this.thisADDRESSEE_ID; }
            set { this.thisADDRESSEE_ID = value; }
        }
        public string RU_COMMENTS {
        	get { return this.thisRU_COMMENTS; }
        	set { this.thisRU_COMMENTS = value; }
        }

        public string AT_LOCATION {
            get { return this.thisAT_LOCATION; }
            set { this.thisAT_LOCATION = value; }
        }

        public string SPAF_ACK {
            get { return this.thisSPAF_ACK; }
            set { this.thisSPAF_ACK = value; }
        }
        
        public string S1_HAVE_JOINT_OCCUPANTS {
            get { return this.thisS1_HAVE_JOINT_OCCUPANTS; }
            set { this.thisS1_HAVE_JOINT_OCCUPANTS = value; }
        }

        public string S1_TRACK_AUTHORITY_TO_VOID {
            get { return this.thisS1_TRACK_AUTHORITY_TO_VOID; }
            set { this.thisS1_TRACK_AUTHORITY_TO_VOID = value; }
        }
        
        public string S1_TRACK_AUTHORITY_ID {
        	get { return this.thisS1_TRACK_AUTHORITY_ID; }
        	set { this.thisS1_TRACK_AUTHORITY_ID = value; }
        }

        public string S2_PRESENCE {
            get { return this.thisS2_PRESENCE; }
            set { this.thisS2_PRESENCE = value; }
        }

        public string S2_FROM_LOCATION {
            get { return this.thisS2_FROM_LOCATION; }
            set { this.thisS2_FROM_LOCATION = value; }
        }

        public string S2_FIRST_SWITCH {
            get { return this.thisS2_FIRST_SWITCH; }
            set { this.thisS2_FIRST_SWITCH = value; }
        }

        public string S2_COUNT {
            get { return this.thisS2_COUNT; }
            set { this.thisS2_COUNT = value; }
        }

        public ArrayList S2_RECORD {
            get { return this.thisS2_RECORD; }
            set { this.thisS2_RECORD = value; }
        }

        public void addS2_RECORD(RUM_RD_RTIRS2_RECORD_1 s2_record) {
            this.S2_RECORD.Add(s2_record);
            this.S2_COUNT = this.S2_RECORD.Count.ToString();
        }

        public void removeS2_RECORD(int index) {
            this.S2_RECORD.RemoveAt(index);
            this.S2_COUNT = this.S2_RECORD.Count.ToString();
        }

        public string S3_PRESENCE {
            get { return this.thisS3_PRESENCE; }
            set { this.thisS3_PRESENCE = value; }
        }

        public string S3_BETWEEN {
            get { return this.thisS3_BETWEEN; }
            set { this.thisS3_BETWEEN = value; }
        }

        public string S3_BETWEEN_CP {
            get { return this.thisS3_BETWEEN_CP; }
            set { this.thisS3_BETWEEN_CP = value; }
        }

        public string S3_OS {
            get { return this.thisS3_OS; }
            set { this.thisS3_OS = value; }
        }

        public string S3_AND {
            get { return this.thisS3_AND; }
            set { this.thisS3_AND = value; }
        }

        public string S3_AND_CP {
            get { return this.thisS3_AND_CP; }
            set { this.thisS3_AND_CP = value; }
        }

        public string S3_TRACK_COUNT {
            get { return this.thisS3_TRACK_COUNT; }
            set { this.thisS3_TRACK_COUNT = value; }
        }

        public ArrayList S3_TRACK_RECORD {
            get { return this.thisS3_TRACK_RECORD; }
            set { this.thisS3_TRACK_RECORD = value; }
        }

        public void addS3_TRACK_RECORD(RUM_RD_RTIRS3_TRACK_RECORD_1 s3_track_record) {
            this.S3_TRACK_RECORD.Add(s3_track_record);
            this.S3_TRACK_COUNT = this.S3_TRACK_RECORD.Count.ToString();
        }

        public void removeS3_TRACK_RECORD(int index) {
            this.S3_TRACK_RECORD.RemoveAt(index);
            this.S3_TRACK_COUNT = this.S3_TRACK_RECORD.Count.ToString();
        }

        public string S3_SUBDIVIDE_FROM {
            get { return this.thisS3_SUBDIVIDE_FROM; }
            set { this.thisS3_SUBDIVIDE_FROM = value; }
        }

        public string S3_SUBDIVIDE_TO {
            get { return this.thisS3_SUBDIVIDE_TO; }
            set { this.thisS3_SUBDIVIDE_TO = value; }
        }

        public string S3_BETWEEN_ZONE_COUNT {
            get { return this.thisS3_BETWEEN_ZONE_COUNT; }
            set { this.thisS3_BETWEEN_ZONE_COUNT = value; }
        }

        public ArrayList S3_BETWEEN_ZONE_RECORD {
            get { return this.thisS3_BETWEEN_ZONE_RECORD; }
            set { this.thisS3_BETWEEN_ZONE_RECORD = value; }
        }

        public void addS3_BETWEEN_ZONE_RECORD(RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1 s3_between_zone_record) {
            this.S3_BETWEEN_ZONE_RECORD.Add(s3_between_zone_record);
            this.S3_BETWEEN_ZONE_COUNT = this.S3_BETWEEN_ZONE_RECORD.Count.ToString();
        }

        public void removeS3_BETWEEN_ZONE_RECORD(int index) {
            this.S3_BETWEEN_ZONE_RECORD.RemoveAt(index);
            this.S3_BETWEEN_ZONE_COUNT = this.S3_BETWEEN_ZONE_RECORD.Count.ToString();
        }

        public string S3_AND_ZONE_COUNT {
            get { return this.thisS3_AND_ZONE_COUNT; }
            set { this.thisS3_AND_ZONE_COUNT = value; }
        }

        public ArrayList S3_AND_ZONE_RECORD {
            get { return this.thisS3_AND_ZONE_RECORD; }
            set { this.thisS3_AND_ZONE_RECORD = value; }
        }

        public void addS3_AND_ZONE_RECORD(RUM_RD_RTIRS3_AND_ZONE_RECORD_1 s3_and_zone_record) {
            this.S3_AND_ZONE_RECORD.Add(s3_and_zone_record);
            this.S3_AND_ZONE_COUNT = this.S3_AND_ZONE_RECORD.Count.ToString();
        }

        public void removeS3_AND_ZONE_RECORD(int index) {
            this.S3_AND_ZONE_RECORD.RemoveAt(index);
            this.S3_AND_ZONE_COUNT = this.S3_AND_ZONE_RECORD.Count.ToString();
        }

        public string S4_PRESENCE {
            get { return this.thisS4_PRESENCE; }
            set { this.thisS4_PRESENCE = value; }
        }

        public string S4_FROM_LOCATION {
            get { return this.thisS4_FROM_LOCATION; }
            set { this.thisS4_FROM_LOCATION = value; }
        }

        public string S4_FIRST_SWITCH {
            get { return this.thisS4_FIRST_SWITCH; }
            set { this.thisS4_FIRST_SWITCH = value; }
        }

        public string S4_COUNT {
            get { return this.thisS4_COUNT; }
            set { this.thisS4_COUNT = value; }
        }

        public ArrayList S4_RECORD {
            get { return this.thisS4_RECORD; }
            set { this.thisS4_RECORD = value; }
        }

        public void addS4_RECORD(RUM_RD_RTIRS4_RECORD_1 s4_record) {
            this.S4_RECORD.Add(s4_record);
            this.S4_COUNT = this.S4_RECORD.Count.ToString();
        }

        public void removeS4_RECORD(int index) {
            this.S4_RECORD.RemoveAt(index);
            this.S4_COUNT = this.S4_RECORD.Count.ToString();
        }

        public string S5_UNTIL {
            get { return this.thisS5_UNTIL; }
            set { this.thisS5_UNTIL = value; }
        }

        public string S7_HOLD_MAIN {
            get { return this.thisS7_HOLD_MAIN; }
            set { this.thisS7_HOLD_MAIN = value; }
        }

        public string S9_CLEAR_MAIN {
            get { return this.thisS9_CLEAR_MAIN; }
            set { this.thisS9_CLEAR_MAIN = value; }
        }

    }

    public partial class RUM_RD_RTIRS2_RECORD_1 {
        private string thisS2_SEQUENCE = "";
        private string thisS2_TO_LOCATION = "";
        private string thisS2_TRACK = "";

        public string S2_SEQUENCE {
            get { return this.thisS2_SEQUENCE; }
            set { this.thisS2_SEQUENCE = value; }
        }

        public string S2_TO_LOCATION {
            get { return this.thisS2_TO_LOCATION; }
            set { this.thisS2_TO_LOCATION = value; }
        }

        public string S2_TRACK {
            get { return this.thisS2_TRACK; }
            set { this.thisS2_TRACK = value; }
        }

    }

    public partial class RUM_RD_RTIRS3_TRACK_RECORD_1 {
        private string thisS3_TRACK_SEQUENCE = "";
        private string thisS3_TRACK_TEXT = "";

        public string S3_TRACK_SEQUENCE {
            get { return this.thisS3_TRACK_SEQUENCE; }
            set { this.thisS3_TRACK_SEQUENCE = value; }
        }

        public string S3_TRACK_TEXT {
            get { return this.thisS3_TRACK_TEXT; }
            set { this.thisS3_TRACK_TEXT = value; }
        }

    }

    public partial class RUM_RD_RTIRS3_BETWEEN_ZONE_RECORD_1 {
        private string thisS3_BETWEEN_ZONE = "";

        public string S3_BETWEEN_ZONE {
            get { return this.thisS3_BETWEEN_ZONE; }
            set { this.thisS3_BETWEEN_ZONE = value; }
        }

    }

    public partial class RUM_RD_RTIRS3_AND_ZONE_RECORD_1 {
        private string thisS3_AND_ZONE = "";

        public string S3_AND_ZONE {
            get { return this.thisS3_AND_ZONE; }
            set { this.thisS3_AND_ZONE = value; }
        }

    }

    public partial class RUM_RD_RTIRS4_RECORD_1 {
        private string thisS4_SEQUENCE = "";
        private string thisS4_TO_LOCATION = "";
        private string thisS4_TRACK = "";

        public string S4_SEQUENCE {
            get { return this.thisS4_SEQUENCE; }
            set { this.thisS4_SEQUENCE = value; }
        }

        public string S4_TO_LOCATION {
            get { return this.thisS4_TO_LOCATION; }
            set { this.thisS4_TO_LOCATION = value; }
        }

        public string S4_TRACK {
            get { return this.thisS4_TRACK; }
            set { this.thisS4_TRACK = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class RD_RTIR_1 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(RD_RTIRHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(RD_RTIRCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


        public object[] Items {
            get {
                return this.itemsField;
            }
    	    set {
    	        this.itemsField = value;
    	    }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADER_1 {
        private RD_RTIRHEADERHEADER_EVENT_DATE_1[] HEADER_EVENT_DATEField;
        private RD_RTIRHEADERHEADER_EVENT_TIME_1[] HEADER_EVENT_TIMEField;
        private RD_RTIRHEADERHEADER_MESSAGE_ID_1[] HEADER_MESSAGE_IDField;
        private RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1[] HEADER_SEQUENCE_NUMBERField;
        private RD_RTIRHEADERHEADER_MESSAGE_VERSION_1[] HEADER_MESSAGE_VERSIONField;
        private RD_RTIRHEADERHEADER_SOURCE_SYS_1[] HEADER_SOURCE_SYSField;
        private RD_RTIRHEADERHEADER_DESTINATION_SYS_1[] HEADER_DESTINATION_SYSField;
        private RD_RTIRHEADERHEADER_DISTRICT_NAME_1[] HEADER_DISTRICT_NAMEField;
        private RD_RTIRHEADERHEADER_USER_ID_1[] HEADER_USER_IDField;
        private RD_RTIRHEADERHEADER_DIVISION_NAME_1[] HEADER_DIVISION_NAMEField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_EVENT_DATE_1[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_EVENT_TIME_1[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_MESSAGE_ID_1[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_MESSAGE_VERSION_1[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_SOURCE_SYS_1[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_DESTINATION_SYS_1[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_DISTRICT_NAME_1[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_USER_ID_1[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRHEADERHEADER_DIVISION_NAME_1[] HEADER_DIVISION_NAME {
            get { return this.HEADER_DIVISION_NAMEField; }
            set { this.HEADER_DIVISION_NAMEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_EVENT_DATE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_EVENT_TIME_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_MESSAGE_ID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_SEQUENCE_NUMBER_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_MESSAGE_VERSION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_SOURCE_SYS_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_DESTINATION_SYS_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_DISTRICT_NAME_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_USER_ID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRHEADERHEADER_DIVISION_NAME_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENT_1 {
        private RD_RTIRCONTENTREQUEST_ID_1[] REQUEST_IDField;
        private RD_RTIRCONTENTPF_ADDRESSEE_1[] PF_ADDRESSEEField;
        private RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1[] PF_ADDRESSEE_TYPEField;
        private RD_RTIRCONTENTREQUESTING_EMPLOYEE_1[] REQUESTING_EMPLOYEEField;
        private RD_RTIRCONTENTADDRESSEE_TYPE_1[] ADDRESSEE_TYPEField;
        private RD_RTIRCONTENTSCAC_1[] SCACField;
        private RD_RTIRCONTENTSYMBOL_1[] SYMBOLField;
        private RD_RTIRCONTENTSECTION_1[] SECTIONField;
        private RD_RTIRCONTENTORIGIN_DATE_1[] ORIGIN_DATEField;
        private RD_RTIRCONTENTENGINE_INITIAL_1[] ENGINE_INITIALField;
        private RD_RTIRCONTENTENGINE_NUMBER_1[] ENGINE_NUMBERField;
        private RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1[] COUPLED_ENGINE_INITIALField;
        private RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1[] COUPLED_ENGINE_NUMBERField;
        private RD_RTIRCONTENTEMPLOYEE_FIRST_1[] EMPLOYEE_FIRSTField;
        private RD_RTIRCONTENTEMPLOYEE_MIDDLE_1[] EMPLOYEE_MIDDLEField;
        private RD_RTIRCONTENTEMPLOYEE_LAST_1[] EMPLOYEE_LASTField;
        private RD_RTIRCONTENTADDRESSEE_ID_1[] ADDRESSEE_IDField;
        private RD_RTIRCONTENTRU_COMMENTS_1[] RU_COMMENTSField;
        private RD_RTIRCONTENTAT_LOCATION_1[] AT_LOCATIONField;
        private RD_RTIRCONTENTSPAF_ACK_1[] SPAF_ACKField;
        private RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1[] S1_TRACK_AUTHORITY_TO_VOIDField;
        private RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1[] S1_TRACK_AUTHORITY_IDField;
        private RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1[] S1_HAVE_JOINT_OCCUPANTSField;
        private RD_RTIRCONTENTS2_PRESENCE_1[] S2_PRESENCEField;
        private RD_RTIRCONTENTS2_FROM_LOCATION_1[] S2_FROM_LOCATIONField;
        private RD_RTIRCONTENTS2_FIRST_SWITCH_1[] S2_FIRST_SWITCHField;
        private RD_RTIRCONTENTS2_COUNT_1[] S2_COUNTField;
        private RD_RTIRCONTENTS2_RECORD_1[] S2_RECORDField;
        private RD_RTIRCONTENTS3_PRESENCE_1[] S3_PRESENCEField;
        private RD_RTIRCONTENTS3_BETWEEN_1[] S3_BETWEENField;
        private RD_RTIRCONTENTS3_BETWEEN_CP_1[] S3_BETWEEN_CPField;
        private RD_RTIRCONTENTS3_OS_1[] S3_OSField;
        private RD_RTIRCONTENTS3_AND_1[] S3_ANDField;
        private RD_RTIRCONTENTS3_AND_CP_1[] S3_AND_CPField;
        private RD_RTIRCONTENTS3_TRACK_COUNT_1[] S3_TRACK_COUNTField;
        private RD_RTIRCONTENTS3_TRACK_RECORD_1[] S3_TRACK_RECORDField;
        private RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1[] S3_SUBDIVIDE_FROMField;
        private RD_RTIRCONTENTS3_SUBDIVIDE_TO_1[] S3_SUBDIVIDE_TOField;
        private RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1[] S3_BETWEEN_ZONE_COUNTField;
        private RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1[] S3_BETWEEN_ZONE_RECORDField;
        private RD_RTIRCONTENTS3_AND_ZONE_COUNT_1[] S3_AND_ZONE_COUNTField;
        private RD_RTIRCONTENTS3_AND_ZONE_RECORD_1[] S3_AND_ZONE_RECORDField;
        private RD_RTIRCONTENTS4_PRESENCE_1[] S4_PRESENCEField;
        private RD_RTIRCONTENTS4_FROM_LOCATION_1[] S4_FROM_LOCATIONField;
        private RD_RTIRCONTENTS4_FIRST_SWITCH_1[] S4_FIRST_SWITCHField;
        private RD_RTIRCONTENTS4_COUNT_1[] S4_COUNTField;
        private RD_RTIRCONTENTS4_RECORD_1[] S4_RECORDField;
        private RD_RTIRCONTENTS5_UNTIL_1[] S5_UNTILField;
        private RD_RTIRCONTENTS7_HOLD_MAIN_1[] S7_HOLD_MAINField;
        private RD_RTIRCONTENTS9_CLEAR_MAIN_1[] S9_CLEAR_MAINField;

        [System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTREQUEST_ID_1[] REQUEST_ID {
            get { return this.REQUEST_IDField; }
            set { this.REQUEST_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTPF_ADDRESSEE_1[] PF_ADDRESSEE {
            get { return this.PF_ADDRESSEEField; }
            set { this.PF_ADDRESSEEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1[] PF_ADDRESSEE_TYPE {
            get { return this.PF_ADDRESSEE_TYPEField; }
            set { this.PF_ADDRESSEE_TYPEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("REQUESTING_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTREQUESTING_EMPLOYEE_1[] REQUESTING_EMPLOYEE {
            get { return this.REQUESTING_EMPLOYEEField; }
            set { this.REQUESTING_EMPLOYEEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTADDRESSEE_TYPE_1[] ADDRESSEE_TYPE {
            get { return this.ADDRESSEE_TYPEField; }
            set { this.ADDRESSEE_TYPEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTSCAC_1[] SCAC {
            get { return this.SCACField; }
            set { this.SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTSYMBOL_1[] SYMBOL {
            get { return this.SYMBOLField; }
            set { this.SYMBOLField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTSECTION_1[] SECTION {
            get { return this.SECTIONField; }
            set { this.SECTIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTORIGIN_DATE_1[] ORIGIN_DATE {
            get { return this.ORIGIN_DATEField; }
            set { this.ORIGIN_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTENGINE_INITIAL_1[] ENGINE_INITIAL {
            get { return this.ENGINE_INITIALField; }
            set { this.ENGINE_INITIALField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTENGINE_NUMBER_1[] ENGINE_NUMBER {
            get { return this.ENGINE_NUMBERField; }
            set { this.ENGINE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("COUPLED_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1[] COUPLED_ENGINE_INITIAL {
            get { return this.COUPLED_ENGINE_INITIALField; }
            set { this.COUPLED_ENGINE_INITIALField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("COUPLED_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1[] COUPLED_ENGINE_NUMBER {
            get { return this.COUPLED_ENGINE_NUMBERField; }
            set { this.COUPLED_ENGINE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_FIRST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTEMPLOYEE_FIRST_1[] EMPLOYEE_FIRST {
            get { return this.EMPLOYEE_FIRSTField; }
            set { this.EMPLOYEE_FIRSTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_MIDDLE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTEMPLOYEE_MIDDLE_1[] EMPLOYEE_MIDDLE {
            get { return this.EMPLOYEE_MIDDLEField; }
            set { this.EMPLOYEE_MIDDLEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_LAST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTEMPLOYEE_LAST_1[] EMPLOYEE_LAST {
            get { return this.EMPLOYEE_LASTField; }
            set { this.EMPLOYEE_LASTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ADDRESSEE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTADDRESSEE_ID_1[] ADDRESSEE_ID {
            get { return this.ADDRESSEE_IDField; }
            set { this.ADDRESSEE_IDField = value; }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("RU_COMMENTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTRU_COMMENTS_1[] RU_COMMENTS {
        	get { return this.RU_COMMENTSField; }
        	set { this.RU_COMMENTSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("AT_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTAT_LOCATION_1[] AT_LOCATION {
            get { return this.AT_LOCATIONField; }
            set { this.AT_LOCATIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SPAF_ACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTSPAF_ACK_1[] SPAF_ACK {
            get { return this.SPAF_ACKField; }
            set { this.SPAF_ACKField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S1_TRACK_AUTHORITY_TO_VOID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1[] S1_TRACK_AUTHORITY_TO_VOID {
            get { return this.S1_TRACK_AUTHORITY_TO_VOIDField; }
            set { this.S1_TRACK_AUTHORITY_TO_VOIDField = value; }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("S1_TRACK_AUTHORITY_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1[] S1_TRACK_AUTHORITY_ID {
            get { return this.S1_TRACK_AUTHORITY_IDField; }
            set { this.S1_TRACK_AUTHORITY_IDField = value; }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("S1_HAVE_JOINT_OCCUPANTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1[] S1_HAVE_JOINT_OCCUPANTS {
            get { return this.S1_HAVE_JOINT_OCCUPANTSField; }
            set { this.S1_HAVE_JOINT_OCCUPANTSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS2_PRESENCE_1[] S2_PRESENCE {
            get { return this.S2_PRESENCEField; }
            set { this.S2_PRESENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS2_FROM_LOCATION_1[] S2_FROM_LOCATION {
            get { return this.S2_FROM_LOCATIONField; }
            set { this.S2_FROM_LOCATIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_FIRST_SWITCH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS2_FIRST_SWITCH_1[] S2_FIRST_SWITCH {
            get { return this.S2_FIRST_SWITCHField; }
            set { this.S2_FIRST_SWITCHField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS2_COUNT_1[] S2_COUNT {
            get { return this.S2_COUNTField; }
            set { this.S2_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS2_RECORD_1[] S2_RECORD {
            get { return this.S2_RECORDField; }
            set { this.S2_RECORDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_PRESENCE_1[] S3_PRESENCE {
            get { return this.S3_PRESENCEField; }
            set { this.S3_PRESENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_BETWEEN_1[] S3_BETWEEN {
            get { return this.S3_BETWEENField; }
            set { this.S3_BETWEENField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_CP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_BETWEEN_CP_1[] S3_BETWEEN_CP {
            get { return this.S3_BETWEEN_CPField; }
            set { this.S3_BETWEEN_CPField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_OS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_OS_1[] S3_OS {
            get { return this.S3_OSField; }
            set { this.S3_OSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_AND", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_AND_1[] S3_AND {
            get { return this.S3_ANDField; }
            set { this.S3_ANDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_AND_CP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_AND_CP_1[] S3_AND_CP {
            get { return this.S3_AND_CPField; }
            set { this.S3_AND_CPField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_TRACK_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_TRACK_COUNT_1[] S3_TRACK_COUNT {
            get { return this.S3_TRACK_COUNTField; }
            set { this.S3_TRACK_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_TRACK_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_TRACK_RECORD_1[] S3_TRACK_RECORD {
            get { return this.S3_TRACK_RECORDField; }
            set { this.S3_TRACK_RECORDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_SUBDIVIDE_FROM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1[] S3_SUBDIVIDE_FROM {
            get { return this.S3_SUBDIVIDE_FROMField; }
            set { this.S3_SUBDIVIDE_FROMField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_SUBDIVIDE_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_SUBDIVIDE_TO_1[] S3_SUBDIVIDE_TO {
            get { return this.S3_SUBDIVIDE_TOField; }
            set { this.S3_SUBDIVIDE_TOField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_ZONE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1[] S3_BETWEEN_ZONE_COUNT {
            get { return this.S3_BETWEEN_ZONE_COUNTField; }
            set { this.S3_BETWEEN_ZONE_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_ZONE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1[] S3_BETWEEN_ZONE_RECORD {
            get { return this.S3_BETWEEN_ZONE_RECORDField; }
            set { this.S3_BETWEEN_ZONE_RECORDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_AND_ZONE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_AND_ZONE_COUNT_1[] S3_AND_ZONE_COUNT {
            get { return this.S3_AND_ZONE_COUNTField; }
            set { this.S3_AND_ZONE_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_AND_ZONE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS3_AND_ZONE_RECORD_1[] S3_AND_ZONE_RECORD {
            get { return this.S3_AND_ZONE_RECORDField; }
            set { this.S3_AND_ZONE_RECORDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS4_PRESENCE_1[] S4_PRESENCE {
            get { return this.S4_PRESENCEField; }
            set { this.S4_PRESENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS4_FROM_LOCATION_1[] S4_FROM_LOCATION {
            get { return this.S4_FROM_LOCATIONField; }
            set { this.S4_FROM_LOCATIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_FIRST_SWITCH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS4_FIRST_SWITCH_1[] S4_FIRST_SWITCH {
            get { return this.S4_FIRST_SWITCHField; }
            set { this.S4_FIRST_SWITCHField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS4_COUNT_1[] S4_COUNT {
            get { return this.S4_COUNTField; }
            set { this.S4_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS4_RECORD_1[] S4_RECORD {
            get { return this.S4_RECORDField; }
            set { this.S4_RECORDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S5_UNTIL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS5_UNTIL_1[] S5_UNTIL {
            get { return this.S5_UNTILField; }
            set { this.S5_UNTILField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S7_HOLD_MAIN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS7_HOLD_MAIN_1[] S7_HOLD_MAIN {
            get { return this.S7_HOLD_MAINField; }
            set { this.S7_HOLD_MAINField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S9_CLEAR_MAIN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRCONTENTS9_CLEAR_MAIN_1[] S9_CLEAR_MAIN {
            get { return this.S9_CLEAR_MAINField; }
            set { this.S9_CLEAR_MAINField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTREQUEST_ID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTPF_ADDRESSEE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTPF_ADDRESSEE_TYPE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTREQUESTING_EMPLOYEE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTADDRESSEE_TYPE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTSCAC_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTSYMBOL_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTSECTION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTORIGIN_DATE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTENGINE_INITIAL_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTENGINE_NUMBER_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTCOUPLED_ENGINE_INITIAL_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTCOUPLED_ENGINE_NUMBER_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTEMPLOYEE_FIRST_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTEMPLOYEE_MIDDLE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTEMPLOYEE_LAST_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTADDRESSEE_ID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")] 
    [System.SerializableAttribute()] 
    [System.Diagnostics.DebuggerStepThroughAttribute()] 
    [System.ComponentModel.DesignerCategoryAttribute("code")] 
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)] 
    public partial class RD_RTIRCONTENTRU_COMMENTS_1 { 
        [System.Xml.Serialization.XmlTextAttribute()] 
 	    public string Value {get; set;} 
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTAT_LOCATION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTSPAF_ACK_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS1_TRACK_AUTHORITY_TO_VOID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS1_TRACK_AUTHORITY_ID_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS1_HAVE_JOINT_OCCUPANTS_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS2_PRESENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS2_FROM_LOCATION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS2_FIRST_SWITCH_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS2_COUNT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_PRESENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_BETWEEN_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_BETWEEN_CP_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_OS_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_AND_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_AND_CP_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_TRACK_COUNT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_SUBDIVIDE_FROM_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_SUBDIVIDE_TO_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_BETWEEN_ZONE_COUNT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_AND_ZONE_COUNT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS4_PRESENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS4_FROM_LOCATION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS4_FIRST_SWITCH_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS4_COUNT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS5_UNTIL_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS7_HOLD_MAIN_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS9_CLEAR_MAIN_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS2_RECORD_1 {
        private RD_RTIRS2_RECORDS2_SEQUENCE_1[] S2_SEQUENCEField;
        private RD_RTIRS2_RECORDS2_TO_LOCATION_1[] S2_TO_LOCATIONField;
        private RD_RTIRS2_RECORDS2_TRACK_1[] S2_TRACKField;

        [System.Xml.Serialization.XmlElementAttribute("S2_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS2_RECORDS2_SEQUENCE_1[] S2_SEQUENCE {
            get { return this.S2_SEQUENCEField; }
            set { this.S2_SEQUENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS2_RECORDS2_TO_LOCATION_1[] S2_TO_LOCATION {
            get { return this.S2_TO_LOCATIONField; }
            set { this.S2_TO_LOCATIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S2_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS2_RECORDS2_TRACK_1[] S2_TRACK {
            get { return this.S2_TRACKField; }
            set { this.S2_TRACKField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS2_RECORDS2_SEQUENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS2_RECORDS2_TO_LOCATION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS2_RECORDS2_TRACK_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_TRACK_RECORD_1 {
        private RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1[] S3_TRACK_SEQUENCEField;
        private RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1[] S3_TRACK_TEXTField;

        [System.Xml.Serialization.XmlElementAttribute("S3_TRACK_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1[] S3_TRACK_SEQUENCE {
            get { return this.S3_TRACK_SEQUENCEField; }
            set { this.S3_TRACK_SEQUENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S3_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1[] S3_TRACK_TEXT {
            get { return this.S3_TRACK_TEXTField; }
            set { this.S3_TRACK_TEXTField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS3_TRACK_RECORDS3_TRACK_SEQUENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS3_TRACK_RECORDS3_TRACK_TEXT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_BETWEEN_ZONE_RECORD_1 {
        private RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1[] S3_BETWEEN_ZONEField;

        [System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1[] S3_BETWEEN_ZONE {
            get { return this.S3_BETWEEN_ZONEField; }
            set { this.S3_BETWEEN_ZONEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS3_BETWEEN_ZONE_RECORDS3_BETWEEN_ZONE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS3_AND_ZONE_RECORD_1 {
        private RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1[] S3_AND_ZONEField;

        [System.Xml.Serialization.XmlElementAttribute("S3_AND_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1[] S3_AND_ZONE {
            get { return this.S3_AND_ZONEField; }
            set { this.S3_AND_ZONEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS3_AND_ZONE_RECORDS3_AND_ZONE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRCONTENTS4_RECORD_1 {
        private RD_RTIRS4_RECORDS4_SEQUENCE_1[] S4_SEQUENCEField;
        private RD_RTIRS4_RECORDS4_TO_LOCATION_1[] S4_TO_LOCATIONField;
        private RD_RTIRS4_RECORDS4_TRACK_1[] S4_TRACKField;

        [System.Xml.Serialization.XmlElementAttribute("S4_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS4_RECORDS4_SEQUENCE_1[] S4_SEQUENCE {
            get { return this.S4_SEQUENCEField; }
            set { this.S4_SEQUENCEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS4_RECORDS4_TO_LOCATION_1[] S4_TO_LOCATION {
            get { return this.S4_TO_LOCATIONField; }
            set { this.S4_TO_LOCATIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("S4_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RD_RTIRS4_RECORDS4_TRACK_1[] S4_TRACK {
            get { return this.S4_TRACKField; }
            set { this.S4_TRACKField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS4_RECORDS4_SEQUENCE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS4_RECORDS4_TO_LOCATION_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class RD_RTIRS4_RECORDS4_TRACK_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
