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
	public partial class PTC_GD_EA01_7 {
		public PTC_GD_EA01HEADER_7 HEADER;
		public PTC_GD_EA01CONTENT_7 CONTENT;

		public static void createGD_EA01_7(
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
			string content_engine_initial,
			string content_engine_number,
			string content_application_date,
			string content_application_time,
			string content_target_type,
			string content_target_description,
			string content_speed,
			string content_direction,
			string content_he_district,
			string content_he_track,
			string content_he_milepost,
			string content_re_district,
			string content_re_track,
			string content_re_milepost,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_GD_EA01_7 ptc_gd_ea01 = buildPTC_GD_EA01_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_engine_initial, content_engine_number, content_application_date, content_application_time, content_target_type, content_target_description, content_speed, content_direction, content_he_district, content_he_track, content_he_milepost, content_re_district, content_re_track, content_re_milepost);

			GD_EA01_7 gd_ea01 = ptc_gd_ea01.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(GD_EA01_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, gd_ea01);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_ea01.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_ea01.toSteMessageHeader(request, true);
				int receiver_port = 2500;
				using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {
					NetworkStream nw = tcp.GetStream();
					nw.ReadTimeout = 5000; //5 second timeout for read response
					Ranorex.Report.Info(String.Format("Encoding Message {0} for STE {1}:2500", request, hostname));
					Byte[] data = System.Text.Encoding.ASCII.GetBytes(request);
					//log to record we are sending exec
					nw.Write(data, 0, data.Length);
					Thread.Sleep(5);
					nw.Close();
				}
			}
		}

		public static PTC_GD_EA01_7 buildPTC_GD_EA01_7(
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
			string content_engine_initial,
			string content_engine_number,
			string content_application_date,
			string content_application_time,
			string content_target_type,
			string content_target_description,
			string content_speed,
			string content_direction,
			string content_he_district,
			string content_he_track,
			string content_he_milepost,
			string content_re_district,
			string content_re_track,
			string content_re_milepost
		) {

			PTC_GD_EA01_7 ptc_gd_ea01 = new PTC_GD_EA01_7();

			PTC_GD_EA01HEADER_7 header = new PTC_GD_EA01HEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "GD-EA01";
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

			PTC_GD_EA01CONTENT_7 content = new PTC_GD_EA01CONTENT_7();
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.ENGINE_INITIAL = content_engine_initial;
			content.ENGINE_NUMBER = content_engine_number;
			content.APPLICATION_DATE = content_application_date;
			content.APPLICATION_TIME = content_application_time;
			content.TARGET_TYPE = content_target_type;
			content.TARGET_DESCRIPTION = content_target_description;
			content.SPEED = content_speed;
			content.DIRECTION = content_direction;
			content.HE_DISTRICT = content_he_district;
			content.HE_TRACK = content_he_track;
			content.HE_MILEPOST = content_he_milepost;
			content.RE_DISTRICT = content_re_district;
			content.RE_TRACK = content_re_track;
			content.RE_MILEPOST = content_re_milepost;

			ptc_gd_ea01.HEADER = header;
			ptc_gd_ea01.CONTENT = content;
			return ptc_gd_ea01;
		}

		public GD_EA01_7 toSerializableObject() {
			GD_EA01_7 gd_ea01_7 = new GD_EA01_7();
			gd_ea01_7.Items = new object[2];

			GD_EA01HEADER_7 header = new GD_EA01HEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new GD_EA01HEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new GD_EA01HEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new GD_EA01HEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new GD_EA01HEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new GD_EA01HEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new GD_EA01HEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new GD_EA01HEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new GD_EA01HEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new GD_EA01HEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new GD_EA01HEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new GD_EA01HEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new GD_EA01HEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new GD_EA01HEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new GD_EA01HEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new GD_EA01HEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new GD_EA01HEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new GD_EA01HEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new GD_EA01HEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new GD_EA01HEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new GD_EA01HEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new GD_EA01HEADER_USER_ID_7[1];
					header.USER_ID[0] = new GD_EA01HEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new GD_EA01HEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new GD_EA01HEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new GD_EA01HEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new GD_EA01HEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new GD_EA01HEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new GD_EA01HEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new GD_EA01HEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new GD_EA01HEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new GD_EA01HEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new GD_EA01HEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new GD_EA01HEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new GD_EA01HEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new GD_EA01HEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new GD_EA01HEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new GD_EA01HEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new GD_EA01HEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new GD_EA01HEADER_UID1_7[1];
					header.UID1[0] = new GD_EA01HEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new GD_EA01HEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new GD_EA01HEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new GD_EA01HEADER_UID2_7[1];
					header.UID2[0] = new GD_EA01HEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}

			}

			GD_EA01CONTENT_7 content = new GD_EA01CONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != null && CONTENT.SCAC != "") {
					content.SCAC = new GD_EA01CONTENT_SCAC_7[1];
					content.SCAC[0] = new GD_EA01CONTENT_SCAC_7();
					if (CONTENT.SCAC == "Empty") {
						content.SCAC[0].Value = "";
					} else {
						content.SCAC[0].Value = CONTENT.SCAC;
					}
				}

				if (CONTENT.SYMBOL != null && CONTENT.SYMBOL != "") {
					content.SYMBOL = new GD_EA01CONTENT_SYMBOL_7[1];
					content.SYMBOL[0] = new GD_EA01CONTENT_SYMBOL_7();
					if (CONTENT.SYMBOL == "Empty") {
						content.SYMBOL[0].Value = "";
					} else {
						content.SYMBOL[0].Value = CONTENT.SYMBOL;
					}
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new GD_EA01CONTENT_SECTION_7[1];
					content.SECTION[0] = new GD_EA01CONTENT_SECTION_7();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != null && CONTENT.ORIGIN_DATE != "") {
					content.ORIGIN_DATE = new GD_EA01CONTENT_ORIGIN_DATE_7[1];
					content.ORIGIN_DATE[0] = new GD_EA01CONTENT_ORIGIN_DATE_7();
					if (CONTENT.ORIGIN_DATE == "Empty") {
						content.ORIGIN_DATE[0].Value = "";
					} else {
						content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
					}
				}

				if (CONTENT.ENGINE_INITIAL != "Null") {
					content.ENGINE_INITIAL = new GD_EA01CONTENT_ENGINE_INITIAL_7[1];
					content.ENGINE_INITIAL[0] = new GD_EA01CONTENT_ENGINE_INITIAL_7();
					content.ENGINE_INITIAL[0].Value = CONTENT.ENGINE_INITIAL;
				}

				if (CONTENT.ENGINE_NUMBER != "Null") {
					content.ENGINE_NUMBER = new GD_EA01CONTENT_ENGINE_NUMBER_7[1];
					content.ENGINE_NUMBER[0] = new GD_EA01CONTENT_ENGINE_NUMBER_7();
					content.ENGINE_NUMBER[0].Value = CONTENT.ENGINE_NUMBER;
				}

				if (CONTENT.APPLICATION_DATE != "Null") {
					content.APPLICATION_DATE = new GD_EA01CONTENT_APPLICATION_DATE_7[1];
					content.APPLICATION_DATE[0] = new GD_EA01CONTENT_APPLICATION_DATE_7();
					content.APPLICATION_DATE[0].Value = CONTENT.APPLICATION_DATE;
				}

				if (CONTENT.APPLICATION_TIME != "Null") {
					content.APPLICATION_TIME = new GD_EA01CONTENT_APPLICATION_TIME_7[1];
					content.APPLICATION_TIME[0] = new GD_EA01CONTENT_APPLICATION_TIME_7();
					content.APPLICATION_TIME[0].Value = CONTENT.APPLICATION_TIME;
				}

				if (CONTENT.TARGET_TYPE != "Null") {
					content.TARGET_TYPE = new GD_EA01CONTENT_TARGET_TYPE_7[1];
					content.TARGET_TYPE[0] = new GD_EA01CONTENT_TARGET_TYPE_7();
					content.TARGET_TYPE[0].Value = CONTENT.TARGET_TYPE;
				}

				if (CONTENT.TARGET_DESCRIPTION != null && CONTENT.TARGET_DESCRIPTION != "") {
					content.TARGET_DESCRIPTION = new GD_EA01CONTENT_TARGET_DESCRIPTION_7[1];
					content.TARGET_DESCRIPTION[0] = new GD_EA01CONTENT_TARGET_DESCRIPTION_7();
					if (CONTENT.TARGET_DESCRIPTION == "Empty") {
						content.TARGET_DESCRIPTION[0].Value = "";
					} else {
						content.TARGET_DESCRIPTION[0].Value = CONTENT.TARGET_DESCRIPTION;
					}
				}

				if (CONTENT.SPEED != "Null") {
					content.SPEED = new GD_EA01CONTENT_SPEED_7[1];
					content.SPEED[0] = new GD_EA01CONTENT_SPEED_7();
					content.SPEED[0].Value = CONTENT.SPEED;
				}

				if (CONTENT.DIRECTION != null && CONTENT.DIRECTION != "") {
					content.DIRECTION = new GD_EA01CONTENT_DIRECTION_7[1];
					content.DIRECTION[0] = new GD_EA01CONTENT_DIRECTION_7();
					if (CONTENT.DIRECTION == "Empty") {
						content.DIRECTION[0].Value = "";
					} else {
						content.DIRECTION[0].Value = CONTENT.DIRECTION;
					}
				}

				if (CONTENT.HE_DISTRICT != null && CONTENT.HE_DISTRICT != "") {
					content.HE_DISTRICT = new GD_EA01CONTENT_HE_DISTRICT_7[1];
					content.HE_DISTRICT[0] = new GD_EA01CONTENT_HE_DISTRICT_7();
					if (CONTENT.HE_DISTRICT == "Empty") {
						content.HE_DISTRICT[0].Value = "";
					} else {
						content.HE_DISTRICT[0].Value = CONTENT.HE_DISTRICT;
					}
				}

				if (CONTENT.HE_TRACK != null && CONTENT.HE_TRACK != "") {
					content.HE_TRACK = new GD_EA01CONTENT_HE_TRACK_7[1];
					content.HE_TRACK[0] = new GD_EA01CONTENT_HE_TRACK_7();
					if (CONTENT.HE_TRACK == "Empty") {
						content.HE_TRACK[0].Value = "";
					} else {
						content.HE_TRACK[0].Value = CONTENT.HE_TRACK;
					}
				}

				if (CONTENT.HE_MILEPOST != null && CONTENT.HE_MILEPOST != "") {
					content.HE_MILEPOST = new GD_EA01CONTENT_HE_MILEPOST_7[1];
					content.HE_MILEPOST[0] = new GD_EA01CONTENT_HE_MILEPOST_7();
					if (CONTENT.HE_MILEPOST == "Empty") {
						content.HE_MILEPOST[0].Value = "";
					} else {
						content.HE_MILEPOST[0].Value = CONTENT.HE_MILEPOST;
					}
				}

				if (CONTENT.RE_DISTRICT != null && CONTENT.RE_DISTRICT != "") {
					content.RE_DISTRICT = new GD_EA01CONTENT_RE_DISTRICT_7[1];
					content.RE_DISTRICT[0] = new GD_EA01CONTENT_RE_DISTRICT_7();
					if (CONTENT.RE_DISTRICT == "Empty") {
						content.RE_DISTRICT[0].Value = "";
					} else {
						content.RE_DISTRICT[0].Value = CONTENT.RE_DISTRICT;
					}
				}

				if (CONTENT.RE_TRACK != null && CONTENT.RE_TRACK != "") {
					content.RE_TRACK = new GD_EA01CONTENT_RE_TRACK_7[1];
					content.RE_TRACK[0] = new GD_EA01CONTENT_RE_TRACK_7();
					if (CONTENT.RE_TRACK == "Empty") {
						content.RE_TRACK[0].Value = "";
					} else {
						content.RE_TRACK[0].Value = CONTENT.RE_TRACK;
					}
				}

				if (CONTENT.RE_MILEPOST != null && CONTENT.RE_MILEPOST != "") {
					content.RE_MILEPOST = new GD_EA01CONTENT_RE_MILEPOST_7[1];
					content.RE_MILEPOST[0] = new GD_EA01CONTENT_RE_MILEPOST_7();
					if (CONTENT.RE_MILEPOST == "Empty") {
						content.RE_MILEPOST[0].Value = "";
					} else {
						content.RE_MILEPOST[0].Value = CONTENT.RE_MILEPOST;
					}
				}

			}

			gd_ea01_7.Items[0] = header;
			gd_ea01_7.Items[1] = content;
			return gd_ea01_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|GD-EA01|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|GD-EA01|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class PTC_GD_EA01HEADER_7 {
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

	public partial class PTC_GD_EA01CONTENT_7 {
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string APPLICATION_DATE = "";
		public string APPLICATION_TIME = "";
		public string TARGET_TYPE = "";
		public string TARGET_DESCRIPTION = "";
		public string SPEED = "";
		public string DIRECTION = "";
		public string HE_DISTRICT = "";
		public string HE_TRACK = "";
		public string HE_MILEPOST = "";
		public string RE_DISTRICT = "";
		public string RE_TRACK = "";
		public string RE_MILEPOST = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class GD_EA01_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(GD_EA01HEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(GD_EA01CONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01HEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01HEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_ENGINE_INITIAL_7[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_ENGINE_NUMBER_7[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("APPLICATION_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_APPLICATION_DATE_7[] APPLICATION_DATE;

		[System.Xml.Serialization.XmlElementAttribute("APPLICATION_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_APPLICATION_TIME_7[] APPLICATION_TIME;

		[System.Xml.Serialization.XmlElementAttribute("TARGET_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_TARGET_TYPE_7[] TARGET_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("TARGET_DESCRIPTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_TARGET_DESCRIPTION_7[] TARGET_DESCRIPTION;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_SPEED_7[] SPEED;

		[System.Xml.Serialization.XmlElementAttribute("DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_DIRECTION_7[] DIRECTION;

		[System.Xml.Serialization.XmlElementAttribute("HE_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_HE_DISTRICT_7[] HE_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("HE_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_HE_TRACK_7[] HE_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("HE_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_HE_MILEPOST_7[] HE_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("RE_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_RE_DISTRICT_7[] RE_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("RE_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_RE_TRACK_7[] RE_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("RE_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_EA01CONTENT_RE_MILEPOST_7[] RE_MILEPOST;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_APPLICATION_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_APPLICATION_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_TARGET_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_TARGET_DESCRIPTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_SPEED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_DIRECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_HE_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_HE_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_HE_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_RE_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_RE_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_EA01CONTENT_RE_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}