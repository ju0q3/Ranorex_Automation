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
	public partial class PTC_GD_CACA_7 {
		public PTC_GD_CACAHEADER_7 HEADER;
		public PTC_GD_CACACONTENT_7 CONTENT;
		public string JSONHeader;
		
		public static void createGD_CACA_7(
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
			string content_track_authority_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_action,
			string content_ack_date,
			string content_ack_time,
			string content_engine_initial,
			string content_engine_number,
			string content_direction,
			string content_employee_first,
			string content_employee_middle,
			string content_employee_last,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_GD_CACA_7 ptc_gd_caca = buildPTC_GD_CACA_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_track_authority_number, content_scac, content_symbol, content_section, content_origin_date, content_action, content_ack_date, content_ack_time, content_engine_initial, content_engine_number, content_direction, content_employee_first, content_employee_middle, content_employee_last);
			ptc_gd_caca.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"GD-CACA\",  \"Queue\"\":\"Auto\"}";
				
			GD_CACA_7 gd_caca = ptc_gd_caca.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(GD_CACA_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, gd_caca);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_caca.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_caca.toSteMessageHeader(request);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);

//				request = ptc_gd_caca.toSteMessageHeader(request, true);
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

		public static PTC_GD_CACA_7 buildPTC_GD_CACA_7(
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
			string content_track_authority_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_action,
			string content_ack_date,
			string content_ack_time,
			string content_engine_initial,
			string content_engine_number,
			string content_direction,
			string content_employee_first,
			string content_employee_middle,
			string content_employee_last
		) {

			PTC_GD_CACA_7 ptc_gd_caca = new PTC_GD_CACA_7();

			PTC_GD_CACAHEADER_7 header = new PTC_GD_CACAHEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "GD-CACA";
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

			PTC_GD_CACACONTENT_7 content = new PTC_GD_CACACONTENT_7();
			content.TRACK_AUTHORITY_NUMBER = content_track_authority_number;
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.ACTION = content_action;
			content.ACK_DATE = content_ack_date;
			content.ACK_TIME = content_ack_time;
			content.ENGINE_INITIAL = content_engine_initial;
			content.ENGINE_NUMBER = content_engine_number;
			content.DIRECTION = content_direction;
			content.EMPLOYEE_FIRST = content_employee_first;
			content.EMPLOYEE_MIDDLE = content_employee_middle;
			content.EMPLOYEE_LAST = content_employee_last;

			ptc_gd_caca.HEADER = header;
			ptc_gd_caca.CONTENT = content;
			return ptc_gd_caca;
		}

		public GD_CACA_7 toSerializableObject() {
			GD_CACA_7 gd_caca_7 = new GD_CACA_7();
			gd_caca_7.Items = new object[2];

			GD_CACAHEADER_7 header = new GD_CACAHEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new GD_CACAHEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new GD_CACAHEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new GD_CACAHEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new GD_CACAHEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new GD_CACAHEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new GD_CACAHEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new GD_CACAHEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new GD_CACAHEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new GD_CACAHEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new GD_CACAHEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new GD_CACAHEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new GD_CACAHEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new GD_CACAHEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new GD_CACAHEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new GD_CACAHEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new GD_CACAHEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new GD_CACAHEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new GD_CACAHEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new GD_CACAHEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new GD_CACAHEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new GD_CACAHEADER_USER_ID_7[1];
					header.USER_ID[0] = new GD_CACAHEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new GD_CACAHEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new GD_CACAHEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new GD_CACAHEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new GD_CACAHEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new GD_CACAHEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new GD_CACAHEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new GD_CACAHEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new GD_CACAHEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new GD_CACAHEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new GD_CACAHEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new GD_CACAHEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new GD_CACAHEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new GD_CACAHEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new GD_CACAHEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new GD_CACAHEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new GD_CACAHEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new GD_CACAHEADER_UID1_7[1];
					header.UID1[0] = new GD_CACAHEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new GD_CACAHEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new GD_CACAHEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new GD_CACAHEADER_UID2_7[1];
					header.UID2[0] = new GD_CACAHEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}

			}

			GD_CACACONTENT_7 content = new GD_CACACONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.TRACK_AUTHORITY_NUMBER != "Null") {
					content.TRACK_AUTHORITY_NUMBER = new GD_CACACONTENT_TRACK_AUTHORITY_NUMBER_7[1];
					content.TRACK_AUTHORITY_NUMBER[0] = new GD_CACACONTENT_TRACK_AUTHORITY_NUMBER_7();
					content.TRACK_AUTHORITY_NUMBER[0].Value = CONTENT.TRACK_AUTHORITY_NUMBER;
				}

				if (CONTENT.SCAC != "Null") {
					content.SCAC = new GD_CACACONTENT_SCAC_7[1];
					content.SCAC[0] = new GD_CACACONTENT_SCAC_7();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SYMBOL != "Null") {
					content.SYMBOL = new GD_CACACONTENT_SYMBOL_7[1];
					content.SYMBOL[0] = new GD_CACACONTENT_SYMBOL_7();
					content.SYMBOL[0].Value = CONTENT.SYMBOL;
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new GD_CACACONTENT_SECTION_7[1];
					content.SECTION[0] = new GD_CACACONTENT_SECTION_7();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new GD_CACACONTENT_ORIGIN_DATE_7[1];
					content.ORIGIN_DATE[0] = new GD_CACACONTENT_ORIGIN_DATE_7();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.ACTION != "Null") {
					content.ACTION = new GD_CACACONTENT_ACTION_7[1];
					content.ACTION[0] = new GD_CACACONTENT_ACTION_7();
					content.ACTION[0].Value = CONTENT.ACTION;
				}

				if (CONTENT.ACK_DATE != "Null") {
					content.ACK_DATE = new GD_CACACONTENT_ACK_DATE_7[1];
					content.ACK_DATE[0] = new GD_CACACONTENT_ACK_DATE_7();
					content.ACK_DATE[0].Value = CONTENT.ACK_DATE;
				}

				if (CONTENT.ACK_TIME != "Null") {
					content.ACK_TIME = new GD_CACACONTENT_ACK_TIME_7[1];
					content.ACK_TIME[0] = new GD_CACACONTENT_ACK_TIME_7();
					content.ACK_TIME[0].Value = CONTENT.ACK_TIME;
				}

				if (CONTENT.ENGINE_INITIAL != null && CONTENT.ENGINE_INITIAL != "") {
					content.ENGINE_INITIAL = new GD_CACACONTENT_ENGINE_INITIAL_7[1];
					content.ENGINE_INITIAL[0] = new GD_CACACONTENT_ENGINE_INITIAL_7();
					if (CONTENT.ENGINE_INITIAL == "Empty") {
						content.ENGINE_INITIAL[0].Value = "";
					} else {
						content.ENGINE_INITIAL[0].Value = CONTENT.ENGINE_INITIAL;
					}
				}

				if (CONTENT.ENGINE_NUMBER != null && CONTENT.ENGINE_NUMBER != "") {
					content.ENGINE_NUMBER = new GD_CACACONTENT_ENGINE_NUMBER_7[1];
					content.ENGINE_NUMBER[0] = new GD_CACACONTENT_ENGINE_NUMBER_7();
					if (CONTENT.ENGINE_NUMBER == "Empty") {
						content.ENGINE_NUMBER[0].Value = "";
					} else {
						content.ENGINE_NUMBER[0].Value = CONTENT.ENGINE_NUMBER;
					}
				}

				if (CONTENT.DIRECTION != null && CONTENT.DIRECTION != "") {
					content.DIRECTION = new GD_CACACONTENT_DIRECTION_7[1];
					content.DIRECTION[0] = new GD_CACACONTENT_DIRECTION_7();
					if (CONTENT.DIRECTION == "Empty") {
						content.DIRECTION[0].Value = "";
					} else {
						content.DIRECTION[0].Value = CONTENT.DIRECTION;
					}
				}

				if (CONTENT.EMPLOYEE_FIRST != "Null") {
					content.EMPLOYEE_FIRST = new GD_CACACONTENT_EMPLOYEE_FIRST_7[1];
					content.EMPLOYEE_FIRST[0] = new GD_CACACONTENT_EMPLOYEE_FIRST_7();
					content.EMPLOYEE_FIRST[0].Value = CONTENT.EMPLOYEE_FIRST;
				}

				if (CONTENT.EMPLOYEE_MIDDLE != null && CONTENT.EMPLOYEE_MIDDLE != "") {
					content.EMPLOYEE_MIDDLE = new GD_CACACONTENT_EMPLOYEE_MIDDLE_7[1];
					content.EMPLOYEE_MIDDLE[0] = new GD_CACACONTENT_EMPLOYEE_MIDDLE_7();
					if (CONTENT.EMPLOYEE_MIDDLE == "Empty") {
						content.EMPLOYEE_MIDDLE[0].Value = "";
					} else {
						content.EMPLOYEE_MIDDLE[0].Value = CONTENT.EMPLOYEE_MIDDLE;
					}
				}

				if (CONTENT.EMPLOYEE_LAST != "Null") {
					content.EMPLOYEE_LAST = new GD_CACACONTENT_EMPLOYEE_LAST_7[1];
					content.EMPLOYEE_LAST[0] = new GD_CACACONTENT_EMPLOYEE_LAST_7();
					content.EMPLOYEE_LAST[0].Value = CONTENT.EMPLOYEE_LAST;
				}

			}

			gd_caca_7.Items[0] = header;
			gd_caca_7.Items[1] = content;
			return gd_caca_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|GD-CACA|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|GD-CACA|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class PTC_GD_CACAHEADER_7 {
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

	public partial class PTC_GD_CACACONTENT_7 {
		public string TRACK_AUTHORITY_NUMBER = "";
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string ACTION = "";
		public string ACK_DATE = "";
		public string ACK_TIME = "";
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string DIRECTION = "";
		public string EMPLOYEE_FIRST = "";
		public string EMPLOYEE_MIDDLE = "";
		public string EMPLOYEE_LAST = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class GD_CACA_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(GD_CACAHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(GD_CACACONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACAHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACAHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_TRACK_AUTHORITY_NUMBER_7[] TRACK_AUTHORITY_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ACTION_7[] ACTION;

		[System.Xml.Serialization.XmlElementAttribute("ACK_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ACK_DATE_7[] ACK_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ACK_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ACK_TIME_7[] ACK_TIME;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ENGINE_INITIAL_7[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_ENGINE_NUMBER_7[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_DIRECTION_7[] DIRECTION;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_FIRST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_EMPLOYEE_FIRST_7[] EMPLOYEE_FIRST;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_MIDDLE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_EMPLOYEE_MIDDLE_7[] EMPLOYEE_MIDDLE;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_LAST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_CACACONTENT_EMPLOYEE_LAST_7[] EMPLOYEE_LAST;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_TRACK_AUTHORITY_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ACTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ACK_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ACK_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_DIRECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_EMPLOYEE_FIRST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_EMPLOYEE_MIDDLE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_CACACONTENT_EMPLOYEE_LAST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}