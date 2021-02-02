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
	public partial class PTC_CD_LOSR_7 {
		public PTC_CD_LOSRHEADER_7 HEADER;
		public PTC_CD_LOSRCONTENT_7 CONTENT;
		public string JSONHeader;
		

		public static void createCD_LOSR_7(
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
			string content_engine_initial,
			string content_engine_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_train_clearance_number,
			string content_trigger_type,
			string content_prev_loco_st_summ,
			string content_prev_loco_state,
			string content_loco_state_summary,
			string content_loco_state,
			string content_loco_state_date,
			string content_loco_state_time,
			string content_state_district,
			string content_state_milepost,
			string content_state_track,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_CD_LOSR_7 ptc_cd_losr = buildPTC_CD_LOSR_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_engine_initial, content_engine_number, content_scac, content_symbol, content_section, content_origin_date, content_train_clearance_number, content_trigger_type, content_prev_loco_st_summ, content_prev_loco_state, content_loco_state_summary, content_loco_state, content_loco_state_date, content_loco_state_time, content_state_district, content_state_milepost, content_state_track);
			ptc_cd_losr.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"CD-LOSR\",  \"Queue\"\":\"Auto\"}";
			
			CD_LOSR_7 cd_losr = ptc_cd_losr.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(CD_LOSR_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, cd_losr);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_cd_losr.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_cd_losr.toSteMessageHeader(request);
                System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(),request);
                
//				request = ptc_cd_losr.toSteMessageHeader(request, true);
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

		public static PTC_CD_LOSR_7 buildPTC_CD_LOSR_7(
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
			string content_engine_initial,
			string content_engine_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_train_clearance_number,
			string content_trigger_type,
			string content_prev_loco_st_summ,
			string content_prev_loco_state,
			string content_loco_state_summary,
			string content_loco_state,
			string content_loco_state_date,
			string content_loco_state_time,
			string content_state_district,
			string content_state_milepost,
			string content_state_track
		) {

			PTC_CD_LOSR_7 ptc_cd_losr = new PTC_CD_LOSR_7();

			PTC_CD_LOSRHEADER_7 header = new PTC_CD_LOSRHEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "CD-LOSR";
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

			PTC_CD_LOSRCONTENT_7 content = new PTC_CD_LOSRCONTENT_7();
			content.ENGINE_INITIAL = content_engine_initial;
			content.ENGINE_NUMBER = content_engine_number;
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.TRAIN_CLEARANCE_NUMBER = content_train_clearance_number;
			content.TRIGGER_TYPE = content_trigger_type;
			content.PREV_LOCO_ST_SUMM = content_prev_loco_st_summ;
			content.PREV_LOCO_STATE = content_prev_loco_state;
			content.LOCO_STATE_SUMMARY = content_loco_state_summary;
			content.LOCO_STATE = content_loco_state;
			content.LOCO_STATE_DATE = content_loco_state_date;
			content.LOCO_STATE_TIME = content_loco_state_time;
			content.STATE_DISTRICT = content_state_district;
			content.STATE_MILEPOST = content_state_milepost;
			content.STATE_TRACK = content_state_track;

			ptc_cd_losr.HEADER = header;
			ptc_cd_losr.CONTENT = content;
			return ptc_cd_losr;
		}

		public CD_LOSR_7 toSerializableObject() {
			CD_LOSR_7 cd_losr_7 = new CD_LOSR_7();
			cd_losr_7.Items = new object[2];

			CD_LOSRHEADER_7 header = new CD_LOSRHEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new CD_LOSRHEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new CD_LOSRHEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new CD_LOSRHEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new CD_LOSRHEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new CD_LOSRHEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new CD_LOSRHEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new CD_LOSRHEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new CD_LOSRHEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new CD_LOSRHEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new CD_LOSRHEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new CD_LOSRHEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new CD_LOSRHEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new CD_LOSRHEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new CD_LOSRHEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new CD_LOSRHEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new CD_LOSRHEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new CD_LOSRHEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new CD_LOSRHEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new CD_LOSRHEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new CD_LOSRHEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new CD_LOSRHEADER_USER_ID_7[1];
					header.USER_ID[0] = new CD_LOSRHEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new CD_LOSRHEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new CD_LOSRHEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new CD_LOSRHEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new CD_LOSRHEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new CD_LOSRHEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new CD_LOSRHEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new CD_LOSRHEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new CD_LOSRHEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new CD_LOSRHEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new CD_LOSRHEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new CD_LOSRHEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new CD_LOSRHEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new CD_LOSRHEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new CD_LOSRHEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new CD_LOSRHEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new CD_LOSRHEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new CD_LOSRHEADER_UID1_7[1];
					header.UID1[0] = new CD_LOSRHEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new CD_LOSRHEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new CD_LOSRHEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new CD_LOSRHEADER_UID2_7[1];
					header.UID2[0] = new CD_LOSRHEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}

			}

			CD_LOSRCONTENT_7 content = new CD_LOSRCONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.ENGINE_INITIAL != "Null") {
					content.ENGINE_INITIAL = new CD_LOSRCONTENT_ENGINE_INITIAL_7[1];
					content.ENGINE_INITIAL[0] = new CD_LOSRCONTENT_ENGINE_INITIAL_7();
					content.ENGINE_INITIAL[0].Value = CONTENT.ENGINE_INITIAL;
				}

				if (CONTENT.ENGINE_NUMBER != "Null") {
					content.ENGINE_NUMBER = new CD_LOSRCONTENT_ENGINE_NUMBER_7[1];
					content.ENGINE_NUMBER[0] = new CD_LOSRCONTENT_ENGINE_NUMBER_7();
					content.ENGINE_NUMBER[0].Value = CONTENT.ENGINE_NUMBER;
				}

				if (CONTENT.SCAC != "Null") {
					content.SCAC = new CD_LOSRCONTENT_SCAC_7[1];
					content.SCAC[0] = new CD_LOSRCONTENT_SCAC_7();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SYMBOL != "Null") {
					content.SYMBOL = new CD_LOSRCONTENT_SYMBOL_7[1];
					content.SYMBOL[0] = new CD_LOSRCONTENT_SYMBOL_7();
					content.SYMBOL[0].Value = CONTENT.SYMBOL;
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new CD_LOSRCONTENT_SECTION_7[1];
					content.SECTION[0] = new CD_LOSRCONTENT_SECTION_7();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new CD_LOSRCONTENT_ORIGIN_DATE_7[1];
					content.ORIGIN_DATE[0] = new CD_LOSRCONTENT_ORIGIN_DATE_7();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.TRAIN_CLEARANCE_NUMBER != "Null") {
					content.TRAIN_CLEARANCE_NUMBER = new CD_LOSRCONTENT_TRAIN_CLEARANCE_NUMBER_7[1];
					content.TRAIN_CLEARANCE_NUMBER[0] = new CD_LOSRCONTENT_TRAIN_CLEARANCE_NUMBER_7();
					content.TRAIN_CLEARANCE_NUMBER[0].Value = CONTENT.TRAIN_CLEARANCE_NUMBER;
				}

				if (CONTENT.TRIGGER_TYPE != "Null") {
					content.TRIGGER_TYPE = new CD_LOSRCONTENT_TRIGGER_TYPE_7[1];
					content.TRIGGER_TYPE[0] = new CD_LOSRCONTENT_TRIGGER_TYPE_7();
					content.TRIGGER_TYPE[0].Value = CONTENT.TRIGGER_TYPE;
				}

				if (CONTENT.PREV_LOCO_ST_SUMM != null && CONTENT.PREV_LOCO_ST_SUMM != "") {
					content.PREV_LOCO_ST_SUMM = new CD_LOSRCONTENT_PREV_LOCO_ST_SUMM_7[1];
					content.PREV_LOCO_ST_SUMM[0] = new CD_LOSRCONTENT_PREV_LOCO_ST_SUMM_7();
					if (CONTENT.PREV_LOCO_ST_SUMM == "Empty") {
						content.PREV_LOCO_ST_SUMM[0].Value = "";
					} else {
						content.PREV_LOCO_ST_SUMM[0].Value = CONTENT.PREV_LOCO_ST_SUMM;
					}
				}

				if (CONTENT.PREV_LOCO_STATE != null && CONTENT.PREV_LOCO_STATE != "") {
					content.PREV_LOCO_STATE = new CD_LOSRCONTENT_PREV_LOCO_STATE_7[1];
					content.PREV_LOCO_STATE[0] = new CD_LOSRCONTENT_PREV_LOCO_STATE_7();
					if (CONTENT.PREV_LOCO_STATE == "Empty") {
						content.PREV_LOCO_STATE[0].Value = "";
					} else {
						content.PREV_LOCO_STATE[0].Value = CONTENT.PREV_LOCO_STATE;
					}
				}

				if (CONTENT.LOCO_STATE_SUMMARY != "Null") {
					content.LOCO_STATE_SUMMARY = new CD_LOSRCONTENT_LOCO_STATE_SUMMARY_7[1];
					content.LOCO_STATE_SUMMARY[0] = new CD_LOSRCONTENT_LOCO_STATE_SUMMARY_7();
					content.LOCO_STATE_SUMMARY[0].Value = CONTENT.LOCO_STATE_SUMMARY;
				}

				if (CONTENT.LOCO_STATE != "Null") {
					content.LOCO_STATE = new CD_LOSRCONTENT_LOCO_STATE_7[1];
					content.LOCO_STATE[0] = new CD_LOSRCONTENT_LOCO_STATE_7();
					content.LOCO_STATE[0].Value = CONTENT.LOCO_STATE;
				}

				if (CONTENT.LOCO_STATE_DATE != "Null") {
					content.LOCO_STATE_DATE = new CD_LOSRCONTENT_LOCO_STATE_DATE_7[1];
					content.LOCO_STATE_DATE[0] = new CD_LOSRCONTENT_LOCO_STATE_DATE_7();
					content.LOCO_STATE_DATE[0].Value = CONTENT.LOCO_STATE_DATE;
				}

				if (CONTENT.LOCO_STATE_TIME != "Null") {
					content.LOCO_STATE_TIME = new CD_LOSRCONTENT_LOCO_STATE_TIME_7[1];
					content.LOCO_STATE_TIME[0] = new CD_LOSRCONTENT_LOCO_STATE_TIME_7();
					content.LOCO_STATE_TIME[0].Value = CONTENT.LOCO_STATE_TIME;
				}

				if (CONTENT.STATE_DISTRICT != null && CONTENT.STATE_DISTRICT != "") {
					content.STATE_DISTRICT = new CD_LOSRCONTENT_STATE_DISTRICT_7[1];
					content.STATE_DISTRICT[0] = new CD_LOSRCONTENT_STATE_DISTRICT_7();
					if (CONTENT.STATE_DISTRICT == "Empty") {
						content.STATE_DISTRICT[0].Value = "";
					} else {
						content.STATE_DISTRICT[0].Value = CONTENT.STATE_DISTRICT;
					}
				}

				if (CONTENT.STATE_MILEPOST != null && CONTENT.STATE_MILEPOST != "") {
					content.STATE_MILEPOST = new CD_LOSRCONTENT_STATE_MILEPOST_7[1];
					content.STATE_MILEPOST[0] = new CD_LOSRCONTENT_STATE_MILEPOST_7();
					if (CONTENT.STATE_MILEPOST == "Empty") {
						content.STATE_MILEPOST[0].Value = "";
					} else {
						content.STATE_MILEPOST[0].Value = CONTENT.STATE_MILEPOST;
					}
				}

				if (CONTENT.STATE_TRACK != null && CONTENT.STATE_TRACK != "") {
					content.STATE_TRACK = new CD_LOSRCONTENT_STATE_TRACK_7[1];
					content.STATE_TRACK[0] = new CD_LOSRCONTENT_STATE_TRACK_7();
					if (CONTENT.STATE_TRACK == "Empty") {
						content.STATE_TRACK[0].Value = "";
					} else {
						content.STATE_TRACK[0].Value = CONTENT.STATE_TRACK;
					}
				}

			}

			cd_losr_7.Items[0] = header;
			cd_losr_7.Items[1] = content;
			return cd_losr_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|CD-LOSR|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|CD-LOSR|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class PTC_CD_LOSRHEADER_7 {
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

	public partial class PTC_CD_LOSRCONTENT_7 {
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string TRAIN_CLEARANCE_NUMBER = "";
		public string TRIGGER_TYPE = "";
		public string PREV_LOCO_ST_SUMM = "";
		public string PREV_LOCO_STATE = "";
		public string LOCO_STATE_SUMMARY = "";
		public string LOCO_STATE = "";
		public string LOCO_STATE_DATE = "";
		public string LOCO_STATE_TIME = "";
		public string STATE_DISTRICT = "";
		public string STATE_MILEPOST = "";
		public string STATE_TRACK = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class CD_LOSR_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(CD_LOSRHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(CD_LOSRCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_ENGINE_INITIAL_7[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_ENGINE_NUMBER_7[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_CLEARANCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_TRAIN_CLEARANCE_NUMBER_7[] TRAIN_CLEARANCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("TRIGGER_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_TRIGGER_TYPE_7[] TRIGGER_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("PREV_LOCO_ST_SUMM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_PREV_LOCO_ST_SUMM_7[] PREV_LOCO_ST_SUMM;

		[System.Xml.Serialization.XmlElementAttribute("PREV_LOCO_STATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_PREV_LOCO_STATE_7[] PREV_LOCO_STATE;

		[System.Xml.Serialization.XmlElementAttribute("LOCO_STATE_SUMMARY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_LOCO_STATE_SUMMARY_7[] LOCO_STATE_SUMMARY;

		[System.Xml.Serialization.XmlElementAttribute("LOCO_STATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_LOCO_STATE_7[] LOCO_STATE;

		[System.Xml.Serialization.XmlElementAttribute("LOCO_STATE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_LOCO_STATE_DATE_7[] LOCO_STATE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LOCO_STATE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_LOCO_STATE_TIME_7[] LOCO_STATE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("STATE_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_STATE_DISTRICT_7[] STATE_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("STATE_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_STATE_MILEPOST_7[] STATE_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("STATE_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_LOSRCONTENT_STATE_TRACK_7[] STATE_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_TRAIN_CLEARANCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_TRIGGER_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_PREV_LOCO_ST_SUMM_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_PREV_LOCO_STATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_LOCO_STATE_SUMMARY_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_LOCO_STATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_LOCO_STATE_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_LOCO_STATE_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_STATE_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_STATE_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_LOSRCONTENT_STATE_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}