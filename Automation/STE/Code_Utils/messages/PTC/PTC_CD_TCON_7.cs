using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.MessageQueues;

namespace STE.Code_Utils.messages.PTC
{
	public partial class PTC_CD_TCON_7 {
		public PTC_CD_TCONHEADER_7 HEADER;
		public PTC_CD_TCONCONTENT_7 CONTENT;
		public string JSONHeader;

		public static void createCD_TCON_7(
			string header_event_date,
			string header_event_time,
			string header_sequence_number,
			string header_message_version,
			string header_message_revision,
			string header_source_sys,
			string header_destination_sys,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_htrn_origin_date,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string header_uid1_type,
			string header_uid1,
			string header_uid2_type,
			string header_uid2,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_loads,
			string content_empties,
			string content_tonnage,
			string content_length,
			string content_axles,
			string content_operative_brakes,
			string content_total_braking_force,
			string content_speed_constraint,
			string content_speed,
			string content_restriction_count,
			string content_restriction_record,
			string content_speed_class,
			string content_reporting_district,
			string content_reporting_milepost,
			string content_reporting_track,
			string content_ptc_loco_orientation,
			string content_ptc_engine_initial,
			string content_ptc_engine_number,
			string content_engine_count,
			string content_engine_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_CD_TCON_7 ptc_cd_tcon = buildPTC_CD_TCON_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_loads, content_empties, content_tonnage, content_length, content_axles, content_operative_brakes, content_total_braking_force, content_speed_constraint, content_speed, content_restriction_count, content_restriction_record, content_speed_class, content_reporting_district, content_reporting_milepost, content_reporting_track, content_ptc_loco_orientation, content_ptc_engine_initial, content_ptc_engine_number, content_engine_count, content_engine_record);
			ptc_cd_tcon.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"CD-TCON\",  \"Queue\"\":\"Auto\"}";
			
			CD_TCON_7 cd_tcon = ptc_cd_tcon.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(CD_TCON_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, cd_tcon);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_cd_tcon.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_cd_tcon.toSteMessageHeader(request);
                System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(),request);
                
//				request = ptc_cd_tcon.toSteMessageHeader(request, true);
//				int receiver_port = 2500;
//				using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {
//					NetworkStream nw = tcp.GetStream();
//					nw.ReadTimeout = 5000; //5 second timeout for read response
//					Ranorex.Report.Info(String.Format("Encoding Message {0} for STE {1}:2500", request, hostname));
//					Byte[] data = System.Text.Encoding.ASCII.GetBytes(request);
//					//log to record we are sending exec
//					nw.Write(data, 0, data.Length);
//					Thread.Sleep(5);
//					nw.Close();
//				}
			}
		}

		public static PTC_CD_TCON_7 buildPTC_CD_TCON_7(
			string header_event_date,
			string header_event_time,
			string header_sequence_number,
			string header_message_version,
			string header_message_revision,
			string header_source_sys,
			string header_destination_sys,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_htrn_origin_date,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string header_uid1_type,
			string header_uid1,
			string header_uid2_type,
			string header_uid2,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_loads,
			string content_empties,
			string content_tonnage,
			string content_length,
			string content_axles,
			string content_operative_brakes,
			string content_total_braking_force,
			string content_speed_constraint,
			string content_speed,
			string content_restriction_count,
			string content_restriction_record,
			string content_speed_class,
			string content_reporting_district,
			string content_reporting_milepost,
			string content_reporting_track,
			string content_ptc_loco_orientation,
			string content_ptc_engine_initial,
			string content_ptc_engine_number,
			string content_engine_count,
			string content_engine_record
		) {

			PTC_CD_TCON_7 ptc_cd_tcon = new PTC_CD_TCON_7();

			PTC_CD_TCONHEADER_7 header = new PTC_CD_TCONHEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "CD-TCON";
			header.SEQUENCE_NUMBER = header_sequence_number;
			header.MESSAGE_VERSION = header_message_version;
			header.MESSAGE_REVISION = header_message_revision;
			header.SOURCE_SYS = header_source_sys;
			header.DESTINATION_SYS = header_destination_sys;
			header.DISTRICT_NAME = header_district_name;
			header.DISTRICT_SCAC = header_district_scac;
			header.USER_ID = header_user_id;
			header.TRACK_FILE_VERSION = header_track_file_version;
			header.HTRN_SCAC = header_htrn_scac;
			header.HTRN_SYMBOL = header_htrn_symbol;
			header.HTRN_SECTION = header_htrn_section;
			header.HTRN_ORIGIN_DATE = header_htrn_origin_date;
			header.HENG_ENGINE_INITIAL = header_heng_engine_initial;
			header.HENG_ENGINE_NUMBER = header_heng_engine_number;
			header.UID1_TYPE = header_uid1_type;
			header.UID1 = header_uid1;
			header.UID2_TYPE = header_uid2_type;
			header.UID2 = header_uid2;

			PTC_CD_TCONCONTENT_7 content = new PTC_CD_TCONCONTENT_7();
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.LOADS = content_loads;
			content.EMPTIES = content_empties;
			content.TONNAGE = content_tonnage;
			content.LENGTH = content_length;
			content.AXLES = content_axles;
			content.OPERATIVE_BRAKES = content_operative_brakes;
			content.TOTAL_BRAKING_FORCE = content_total_braking_force;
			content.SPEED_CONSTRAINT = content_speed_constraint;
			content.SPEED = content_speed;
			content.RESTRICTION_COUNT = content_restriction_count;
			if (content_restriction_record != "") {
				string[] restriction_recordList = content_restriction_record.Split('|');
				for (int i = 0; i < restriction_recordList.Length;) {
					PTC_CD_TCONRESTRICTION_RECORD_7 restriction_records = new PTC_CD_TCONRESTRICTION_RECORD_7();
					restriction_records.RESTRICTION_TYPE = restriction_recordList[i];i++;
					content.addRESTRICTION_RECORD(restriction_records);
				}
			}
			content.SPEED_CLASS = content_speed_class;
			content.REPORTING_DISTRICT = content_reporting_district;
			content.REPORTING_MILEPOST = content_reporting_milepost;
			content.REPORTING_TRACK = content_reporting_track;
			content.PTC_LOCO_ORIENTATION = content_ptc_loco_orientation;
			content.PTC_ENGINE_INITIAL = content_ptc_engine_initial;
			content.PTC_ENGINE_NUMBER = content_ptc_engine_number;
			content.ENGINE_COUNT = content_engine_count;
			if (content_engine_record != "") {
				string[] engine_recordList = content_engine_record.Split('|');
				for (int i = 0; i < engine_recordList.Length;) {
					PTC_CD_TCONENGINE_RECORD_7 engine_records = new PTC_CD_TCONENGINE_RECORD_7();
					engine_records.POSITION_IN_CONSIST = engine_recordList[i];i++;
					engine_records.ENGINE_INITIAL = engine_recordList[i];i++;
					engine_records.ENGINE_NUMBER = engine_recordList[i];i++;
					engine_records.ENGINE_STATUS = engine_recordList[i];i++;
					engine_records.DB_STATUS = engine_recordList[i];i++;
					content.addENGINE_RECORD(engine_records);
				}
			}

			ptc_cd_tcon.HEADER = header;
			ptc_cd_tcon.CONTENT = content;
			return ptc_cd_tcon;
		}

		public CD_TCON_7 toSerializableObject() {
			CD_TCON_7 cd_tcon_7 = new CD_TCON_7();
			cd_tcon_7.Items = new object[2];

			CD_TCONHEADER_7 header = new CD_TCONHEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new CD_TCONHEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new CD_TCONHEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new CD_TCONHEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new CD_TCONHEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new CD_TCONHEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new CD_TCONHEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new CD_TCONHEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new CD_TCONHEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new CD_TCONHEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new CD_TCONHEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new CD_TCONHEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new CD_TCONHEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new CD_TCONHEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new CD_TCONHEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new CD_TCONHEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new CD_TCONHEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new CD_TCONHEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new CD_TCONHEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new CD_TCONHEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new CD_TCONHEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new CD_TCONHEADER_USER_ID_7[1];
					header.USER_ID[0] = new CD_TCONHEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new CD_TCONHEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new CD_TCONHEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new CD_TCONHEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new CD_TCONHEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new CD_TCONHEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new CD_TCONHEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new CD_TCONHEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new CD_TCONHEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new CD_TCONHEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new CD_TCONHEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new CD_TCONHEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new CD_TCONHEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new CD_TCONHEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new CD_TCONHEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new CD_TCONHEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new CD_TCONHEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new CD_TCONHEADER_UID1_7[1];
					header.UID1[0] = new CD_TCONHEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new CD_TCONHEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new CD_TCONHEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new CD_TCONHEADER_UID2_7[1];
					header.UID2[0] = new CD_TCONHEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}

			}

			CD_TCONCONTENT_7 content = new CD_TCONCONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new CD_TCONCONTENT_SCAC_7[1];
					content.SCAC[0] = new CD_TCONCONTENT_SCAC_7();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SYMBOL != "Null") {
					content.SYMBOL = new CD_TCONCONTENT_SYMBOL_7[1];
					content.SYMBOL[0] = new CD_TCONCONTENT_SYMBOL_7();
					content.SYMBOL[0].Value = CONTENT.SYMBOL;
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new CD_TCONCONTENT_SECTION_7[1];
					content.SECTION[0] = new CD_TCONCONTENT_SECTION_7();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new CD_TCONCONTENT_ORIGIN_DATE_7[1];
					content.ORIGIN_DATE[0] = new CD_TCONCONTENT_ORIGIN_DATE_7();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.LOADS != "Null") {
					content.LOADS = new CD_TCONCONTENT_LOADS_7[1];
					content.LOADS[0] = new CD_TCONCONTENT_LOADS_7();
					content.LOADS[0].Value = CONTENT.LOADS;
				}

				if (CONTENT.EMPTIES != "Null") {
					content.EMPTIES = new CD_TCONCONTENT_EMPTIES_7[1];
					content.EMPTIES[0] = new CD_TCONCONTENT_EMPTIES_7();
					content.EMPTIES[0].Value = CONTENT.EMPTIES;
				}

				if (CONTENT.TONNAGE != "Null") {
					content.TONNAGE = new CD_TCONCONTENT_TONNAGE_7[1];
					content.TONNAGE[0] = new CD_TCONCONTENT_TONNAGE_7();
					content.TONNAGE[0].Value = CONTENT.TONNAGE;
				}

				if (CONTENT.LENGTH != "Null") {
					content.LENGTH = new CD_TCONCONTENT_LENGTH_7[1];
					content.LENGTH[0] = new CD_TCONCONTENT_LENGTH_7();
					content.LENGTH[0].Value = CONTENT.LENGTH;
				}

				if (CONTENT.AXLES != null && CONTENT.AXLES != "") {
					content.AXLES = new CD_TCONCONTENT_AXLES_7[1];
					content.AXLES[0] = new CD_TCONCONTENT_AXLES_7();
					if (CONTENT.AXLES == "Empty") {
						content.AXLES[0].Value = "";
					} else {
						content.AXLES[0].Value = CONTENT.AXLES;
					}
				}

				if (CONTENT.OPERATIVE_BRAKES != null && CONTENT.OPERATIVE_BRAKES != "") {
					content.OPERATIVE_BRAKES = new CD_TCONCONTENT_OPERATIVE_BRAKES_7[1];
					content.OPERATIVE_BRAKES[0] = new CD_TCONCONTENT_OPERATIVE_BRAKES_7();
					if (CONTENT.OPERATIVE_BRAKES == "Empty") {
						content.OPERATIVE_BRAKES[0].Value = "";
					} else {
						content.OPERATIVE_BRAKES[0].Value = CONTENT.OPERATIVE_BRAKES;
					}
				}

				if (CONTENT.TOTAL_BRAKING_FORCE != null && CONTENT.TOTAL_BRAKING_FORCE != "") {
					content.TOTAL_BRAKING_FORCE = new CD_TCONCONTENT_TOTAL_BRAKING_FORCE_7[1];
					content.TOTAL_BRAKING_FORCE[0] = new CD_TCONCONTENT_TOTAL_BRAKING_FORCE_7();
					if (CONTENT.TOTAL_BRAKING_FORCE == "Empty") {
						content.TOTAL_BRAKING_FORCE[0].Value = "";
					} else {
						content.TOTAL_BRAKING_FORCE[0].Value = CONTENT.TOTAL_BRAKING_FORCE;
					}
				}

				if (CONTENT.SPEED_CONSTRAINT != "Null") {
					content.SPEED_CONSTRAINT = new CD_TCONCONTENT_SPEED_CONSTRAINT_7[1];
					content.SPEED_CONSTRAINT[0] = new CD_TCONCONTENT_SPEED_CONSTRAINT_7();
					content.SPEED_CONSTRAINT[0].Value = CONTENT.SPEED_CONSTRAINT;
				}

				if (CONTENT.SPEED != null && CONTENT.SPEED != "") {
					content.SPEED = new CD_TCONCONTENT_SPEED_7[1];
					content.SPEED[0] = new CD_TCONCONTENT_SPEED_7();
					if (CONTENT.SPEED == "Empty") {
						content.SPEED[0].Value = "";
					} else {
						content.SPEED[0].Value = CONTENT.SPEED;
					}
				}

				if (CONTENT.RESTRICTION_COUNT != "Null") {
					content.RESTRICTION_COUNT = new CD_TCONCONTENT_RESTRICTION_COUNT_7[1];
					content.RESTRICTION_COUNT[0] = new CD_TCONCONTENT_RESTRICTION_COUNT_7();
					content.RESTRICTION_COUNT[0].Value = CONTENT.RESTRICTION_COUNT;
				}

				if (CONTENT.RESTRICTION_RECORD.Count != 0) {
					int restriction_recordIndex = 0;
					content.RESTRICTION_RECORD = new CD_TCONCONTENT_RESTRICTION_RECORD_7[CONTENT.RESTRICTION_RECORD.Count];
					foreach (PTC_CD_TCONRESTRICTION_RECORD_7 RESTRICTION_RECORD in CONTENT.RESTRICTION_RECORD) {
						CD_TCONCONTENT_RESTRICTION_RECORD_7 restriction_record = new CD_TCONCONTENT_RESTRICTION_RECORD_7();
						if (RESTRICTION_RECORD.RESTRICTION_TYPE != "Null") {
							restriction_record.RESTRICTION_TYPE = new CD_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7[1];
							restriction_record.RESTRICTION_TYPE[0] = new CD_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7();
							restriction_record.RESTRICTION_TYPE[0].Value = RESTRICTION_RECORD.RESTRICTION_TYPE;
						}

						content.RESTRICTION_RECORD[restriction_recordIndex] = restriction_record;
						restriction_recordIndex++;
					}
				}

				if (CONTENT.SPEED_CLASS != "Null") {
					content.SPEED_CLASS = new CD_TCONCONTENT_SPEED_CLASS_7[1];
					content.SPEED_CLASS[0] = new CD_TCONCONTENT_SPEED_CLASS_7();
					content.SPEED_CLASS[0].Value = CONTENT.SPEED_CLASS;
				}

				if (CONTENT.REPORTING_DISTRICT != null && CONTENT.REPORTING_DISTRICT != "") {
					content.REPORTING_DISTRICT = new CD_TCONCONTENT_REPORTING_DISTRICT_7[1];
					content.REPORTING_DISTRICT[0] = new CD_TCONCONTENT_REPORTING_DISTRICT_7();
					if (CONTENT.REPORTING_DISTRICT == "Empty") {
						content.REPORTING_DISTRICT[0].Value = "";
					} else {
						content.REPORTING_DISTRICT[0].Value = CONTENT.REPORTING_DISTRICT;
					}
				}

				if (CONTENT.REPORTING_MILEPOST != null && CONTENT.REPORTING_MILEPOST != "") {
					content.REPORTING_MILEPOST = new CD_TCONCONTENT_REPORTING_MILEPOST_7[1];
					content.REPORTING_MILEPOST[0] = new CD_TCONCONTENT_REPORTING_MILEPOST_7();
					if (CONTENT.REPORTING_MILEPOST == "Empty") {
						content.REPORTING_MILEPOST[0].Value = "";
					} else {
						content.REPORTING_MILEPOST[0].Value = CONTENT.REPORTING_MILEPOST;
					}
				}

				if (CONTENT.REPORTING_TRACK != null && CONTENT.REPORTING_TRACK != "") {
					content.REPORTING_TRACK = new CD_TCONCONTENT_REPORTING_TRACK_7[1];
					content.REPORTING_TRACK[0] = new CD_TCONCONTENT_REPORTING_TRACK_7();
					if (CONTENT.REPORTING_TRACK == "Empty") {
						content.REPORTING_TRACK[0].Value = "";
					} else {
						content.REPORTING_TRACK[0].Value = CONTENT.REPORTING_TRACK;
					}
				}

				if (CONTENT.PTC_LOCO_ORIENTATION != null && CONTENT.PTC_LOCO_ORIENTATION != "") {
					content.PTC_LOCO_ORIENTATION = new CD_TCONCONTENT_PTC_LOCO_ORIENTATION_7[1];
					content.PTC_LOCO_ORIENTATION[0] = new CD_TCONCONTENT_PTC_LOCO_ORIENTATION_7();
					if (CONTENT.PTC_LOCO_ORIENTATION == "Empty") {
						content.PTC_LOCO_ORIENTATION[0].Value = "";
					} else {
						content.PTC_LOCO_ORIENTATION[0].Value = CONTENT.PTC_LOCO_ORIENTATION;
					}
				}

				if (CONTENT.PTC_ENGINE_INITIAL != "Null") {
					content.PTC_ENGINE_INITIAL = new CD_TCONCONTENT_PTC_ENGINE_INITIAL_7[1];
					content.PTC_ENGINE_INITIAL[0] = new CD_TCONCONTENT_PTC_ENGINE_INITIAL_7();
					content.PTC_ENGINE_INITIAL[0].Value = CONTENT.PTC_ENGINE_INITIAL;
				}

				if (CONTENT.PTC_ENGINE_NUMBER != "Null") {
					content.PTC_ENGINE_NUMBER = new CD_TCONCONTENT_PTC_ENGINE_NUMBER_7[1];
					content.PTC_ENGINE_NUMBER[0] = new CD_TCONCONTENT_PTC_ENGINE_NUMBER_7();
					content.PTC_ENGINE_NUMBER[0].Value = CONTENT.PTC_ENGINE_NUMBER;
				}

				if (CONTENT.ENGINE_COUNT != "Null") {
					content.ENGINE_COUNT = new CD_TCONCONTENT_ENGINE_COUNT_7[1];
					content.ENGINE_COUNT[0] = new CD_TCONCONTENT_ENGINE_COUNT_7();
					content.ENGINE_COUNT[0].Value = CONTENT.ENGINE_COUNT;
				}

				if (CONTENT.ENGINE_RECORD.Count != 0) {
					int engine_recordIndex = 0;
					content.ENGINE_RECORD = new CD_TCONCONTENT_ENGINE_RECORD_7[CONTENT.ENGINE_RECORD.Count];
					foreach (PTC_CD_TCONENGINE_RECORD_7 ENGINE_RECORD in CONTENT.ENGINE_RECORD) {
						CD_TCONCONTENT_ENGINE_RECORD_7 engine_record = new CD_TCONCONTENT_ENGINE_RECORD_7();
						if (ENGINE_RECORD.POSITION_IN_CONSIST != null && ENGINE_RECORD.POSITION_IN_CONSIST != "") {
							engine_record.POSITION_IN_CONSIST = new CD_TCONENGINE_RECORD_POSITION_IN_CONSIST_7[1];
							engine_record.POSITION_IN_CONSIST[0] = new CD_TCONENGINE_RECORD_POSITION_IN_CONSIST_7();
							if (ENGINE_RECORD.POSITION_IN_CONSIST == "Empty") {
								engine_record.POSITION_IN_CONSIST[0].Value = "";
							} else {
								engine_record.POSITION_IN_CONSIST[0].Value = ENGINE_RECORD.POSITION_IN_CONSIST;
							}
						}

						if (ENGINE_RECORD.ENGINE_INITIAL != "Null") {
							engine_record.ENGINE_INITIAL = new CD_TCONENGINE_RECORD_ENGINE_INITIAL_7[1];
							engine_record.ENGINE_INITIAL[0] = new CD_TCONENGINE_RECORD_ENGINE_INITIAL_7();
							engine_record.ENGINE_INITIAL[0].Value = ENGINE_RECORD.ENGINE_INITIAL;
						}

						if (ENGINE_RECORD.ENGINE_NUMBER != "Null") {
							engine_record.ENGINE_NUMBER = new CD_TCONENGINE_RECORD_ENGINE_NUMBER_7[1];
							engine_record.ENGINE_NUMBER[0] = new CD_TCONENGINE_RECORD_ENGINE_NUMBER_7();
							engine_record.ENGINE_NUMBER[0].Value = ENGINE_RECORD.ENGINE_NUMBER;
						}

						if (ENGINE_RECORD.ENGINE_STATUS != "Null") {
							engine_record.ENGINE_STATUS = new CD_TCONENGINE_RECORD_ENGINE_STATUS_7[1];
							engine_record.ENGINE_STATUS[0] = new CD_TCONENGINE_RECORD_ENGINE_STATUS_7();
							engine_record.ENGINE_STATUS[0].Value = ENGINE_RECORD.ENGINE_STATUS;
						}

						if (ENGINE_RECORD.DB_STATUS != null && ENGINE_RECORD.DB_STATUS != "") {
							engine_record.DB_STATUS = new CD_TCONENGINE_RECORD_DB_STATUS_7[1];
							engine_record.DB_STATUS[0] = new CD_TCONENGINE_RECORD_DB_STATUS_7();
							if (ENGINE_RECORD.DB_STATUS == "Empty") {
								engine_record.DB_STATUS[0].Value = "";
							} else {
								engine_record.DB_STATUS[0].Value = ENGINE_RECORD.DB_STATUS;
							}
						}

						content.ENGINE_RECORD[engine_recordIndex] = engine_record;
						engine_recordIndex++;
					}
				}

			}

			cd_tcon_7.Items[0] = header;
			cd_tcon_7.Items[1] = content;
			return cd_tcon_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|CD-TCON|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|CD-TCON|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class PTC_CD_TCONHEADER_7 {
		public string EVENT_DATE = "";
		public string EVENT_TIME = "";
		public string MESSAGE_ID = "";
		public string SEQUENCE_NUMBER = "";
		public string MESSAGE_VERSION = "";
		public string MESSAGE_REVISION = "";
		public string SOURCE_SYS = "";
		public string DESTINATION_SYS = "";
		public string DISTRICT_NAME = "";
		public string DISTRICT_SCAC = "";
		public string USER_ID = "";
		public string TRACK_FILE_VERSION = "";
		public string HTRN_SCAC = "";
		public string HTRN_SYMBOL = "";
		public string HTRN_SECTION = "";
		public string HTRN_ORIGIN_DATE = "";
		public string HENG_ENGINE_INITIAL = "";
		public string HENG_ENGINE_NUMBER = "";
		public string UID1_TYPE = "";
		public string UID1 = "";
		public string UID2_TYPE = "";
		public string UID2 = "";
	}

	public partial class PTC_CD_TCONCONTENT_7 {
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string LOADS = "";
		public string EMPTIES = "";
		public string TONNAGE = "";
		public string LENGTH = "";
		public string AXLES = "";
		public string OPERATIVE_BRAKES = "";
		public string TOTAL_BRAKING_FORCE = "";
		public string SPEED_CONSTRAINT = "";
		public string SPEED = "";
		public string RESTRICTION_COUNT = "";
		public ArrayList RESTRICTION_RECORD = new ArrayList();
		public string SPEED_CLASS = "";
		public string REPORTING_DISTRICT = "";
		public string REPORTING_MILEPOST = "";
		public string REPORTING_TRACK = "";
		public string PTC_LOCO_ORIENTATION = "";
		public string PTC_ENGINE_INITIAL = "";
		public string PTC_ENGINE_NUMBER = "";
		public string ENGINE_COUNT = "";
		public ArrayList ENGINE_RECORD = new ArrayList();

		public void addRESTRICTION_RECORD(PTC_CD_TCONRESTRICTION_RECORD_7 restriction_record) {
			this.RESTRICTION_RECORD.Add(restriction_record);
		}

		public void addENGINE_RECORD(PTC_CD_TCONENGINE_RECORD_7 engine_record) {
			this.ENGINE_RECORD.Add(engine_record);
		}
	}

	public partial class PTC_CD_TCONRESTRICTION_RECORD_7 {
		public string RESTRICTION_TYPE = "";
	}

	public partial class PTC_CD_TCONENGINE_RECORD_7 {
		public string POSITION_IN_CONSIST = "";
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string ENGINE_STATUS = "";
		public string DB_STATUS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class CD_TCON_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(CD_TCONHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(CD_TCONCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LOADS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_LOADS_7[] LOADS;

		[System.Xml.Serialization.XmlElementAttribute("EMPTIES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_EMPTIES_7[] EMPTIES;

		[System.Xml.Serialization.XmlElementAttribute("TONNAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_TONNAGE_7[] TONNAGE;

		[System.Xml.Serialization.XmlElementAttribute("LENGTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_LENGTH_7[] LENGTH;

		[System.Xml.Serialization.XmlElementAttribute("AXLES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_AXLES_7[] AXLES;

		[System.Xml.Serialization.XmlElementAttribute("OPERATIVE_BRAKES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_OPERATIVE_BRAKES_7[] OPERATIVE_BRAKES;

		[System.Xml.Serialization.XmlElementAttribute("TOTAL_BRAKING_FORCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_TOTAL_BRAKING_FORCE_7[] TOTAL_BRAKING_FORCE;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SPEED_CONSTRAINT_7[] SPEED_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SPEED_7[] SPEED;

		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_RESTRICTION_COUNT_7[] RESTRICTION_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_RESTRICTION_RECORD_7[] RESTRICTION_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_CLASS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_SPEED_CLASS_7[] SPEED_CLASS;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_REPORTING_DISTRICT_7[] REPORTING_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_REPORTING_MILEPOST_7[] REPORTING_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_REPORTING_TRACK_7[] REPORTING_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("PTC_LOCO_ORIENTATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_PTC_LOCO_ORIENTATION_7[] PTC_LOCO_ORIENTATION;

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_PTC_ENGINE_INITIAL_7[] PTC_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_PTC_ENGINE_NUMBER_7[] PTC_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_ENGINE_COUNT_7[] ENGINE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONCONTENT_ENGINE_RECORD_7[] ENGINE_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_LOADS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_EMPTIES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_TONNAGE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_LENGTH_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_AXLES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_OPERATIVE_BRAKES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_TOTAL_BRAKING_FORCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SPEED_CONSTRAINT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SPEED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_RESTRICTION_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_RESTRICTION_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7[] RESTRICTION_TYPE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_SPEED_CLASS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_REPORTING_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_REPORTING_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_REPORTING_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_PTC_LOCO_ORIENTATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_PTC_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_PTC_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_ENGINE_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONCONTENT_ENGINE_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("POSITION_IN_CONSIST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONENGINE_RECORD_POSITION_IN_CONSIST_7[] POSITION_IN_CONSIST;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONENGINE_RECORD_ENGINE_INITIAL_7[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONENGINE_RECORD_ENGINE_NUMBER_7[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONENGINE_RECORD_ENGINE_STATUS_7[] ENGINE_STATUS;

		[System.Xml.Serialization.XmlElementAttribute("DB_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_TCONENGINE_RECORD_DB_STATUS_7[] DB_STATUS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONENGINE_RECORD_POSITION_IN_CONSIST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONENGINE_RECORD_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONENGINE_RECORD_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONENGINE_RECORD_ENGINE_STATUS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_TCONENGINE_RECORD_DB_STATUS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}