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
	public partial class PTC_CD_CABI_7 {
		public PTC_CD_CABIHEADER_7 HEADER;
		public PTC_CD_CABICONTENT_7 CONTENT;
		public string JSONHeader;

		public static void createCD_CABI_7(
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
			string content_bulletin_item_number,
			string content_crew_ack_type,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_CD_CABI_7 ptc_cd_cabi = buildPTC_CD_CABI_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_scac, content_symbol, content_section, content_origin_date, content_bulletin_item_number, content_crew_ack_type);
			ptc_cd_cabi.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"CD-CABI\",  \"Queue\"\":\"Auto\"}";

			CD_CABI_7 cd_cabi = ptc_cd_cabi.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(CD_CABI_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, cd_cabi);
			fs.Close();

			
			string request = File.ReadAllText(temp+"/temp.request");
			request = ptc_cd_cabi.toSteMessageHeader(request);
			System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			
			
		}

		public static PTC_CD_CABI_7 buildPTC_CD_CABI_7(
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
			string content_bulletin_item_number,
			string content_crew_ack_type
		) {

			PTC_CD_CABI_7 ptc_cd_cabi = new PTC_CD_CABI_7();

			PTC_CD_CABIHEADER_7 header = new PTC_CD_CABIHEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "CD-CABI";
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

			PTC_CD_CABICONTENT_7 content = new PTC_CD_CABICONTENT_7();
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.BULLETIN_ITEM_NUMBER = content_bulletin_item_number;
			content.CREW_ACK_TYPE = content_crew_ack_type;

			ptc_cd_cabi.HEADER = header;
			ptc_cd_cabi.CONTENT = content;
			return ptc_cd_cabi;
		}

		public CD_CABI_7 toSerializableObject() {
			CD_CABI_7 cd_cabi_7 = new CD_CABI_7();
			cd_cabi_7.Items = new object[2];

			CD_CABIHEADER_7 header = new CD_CABIHEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new CD_CABIHEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new CD_CABIHEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new CD_CABIHEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new CD_CABIHEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new CD_CABIHEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new CD_CABIHEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new CD_CABIHEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new CD_CABIHEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new CD_CABIHEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new CD_CABIHEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new CD_CABIHEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new CD_CABIHEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new CD_CABIHEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new CD_CABIHEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new CD_CABIHEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new CD_CABIHEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new CD_CABIHEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new CD_CABIHEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new CD_CABIHEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new CD_CABIHEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new CD_CABIHEADER_USER_ID_7[1];
					header.USER_ID[0] = new CD_CABIHEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new CD_CABIHEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new CD_CABIHEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new CD_CABIHEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new CD_CABIHEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new CD_CABIHEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new CD_CABIHEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new CD_CABIHEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new CD_CABIHEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new CD_CABIHEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new CD_CABIHEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new CD_CABIHEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new CD_CABIHEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new CD_CABIHEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new CD_CABIHEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new CD_CABIHEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new CD_CABIHEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new CD_CABIHEADER_UID1_7[1];
					header.UID1[0] = new CD_CABIHEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new CD_CABIHEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new CD_CABIHEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new CD_CABIHEADER_UID2_7[1];
					header.UID2[0] = new CD_CABIHEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}

			}

			CD_CABICONTENT_7 content = new CD_CABICONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new CD_CABICONTENT_SCAC_7[1];
					content.SCAC[0] = new CD_CABICONTENT_SCAC_7();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SYMBOL != "Null") {
					content.SYMBOL = new CD_CABICONTENT_SYMBOL_7[1];
					content.SYMBOL[0] = new CD_CABICONTENT_SYMBOL_7();
					content.SYMBOL[0].Value = CONTENT.SYMBOL;
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new CD_CABICONTENT_SECTION_7[1];
					content.SECTION[0] = new CD_CABICONTENT_SECTION_7();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new CD_CABICONTENT_ORIGIN_DATE_7[1];
					content.ORIGIN_DATE[0] = new CD_CABICONTENT_ORIGIN_DATE_7();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.BULLETIN_ITEM_NUMBER != "Null") {
					content.BULLETIN_ITEM_NUMBER = new CD_CABICONTENT_BULLETIN_ITEM_NUMBER_7[1];
					content.BULLETIN_ITEM_NUMBER[0] = new CD_CABICONTENT_BULLETIN_ITEM_NUMBER_7();
					content.BULLETIN_ITEM_NUMBER[0].Value = CONTENT.BULLETIN_ITEM_NUMBER;
				}

				if (CONTENT.CREW_ACK_TYPE != "Null") {
					content.CREW_ACK_TYPE = new CD_CABICONTENT_CREW_ACK_TYPE_7[1];
					content.CREW_ACK_TYPE[0] = new CD_CABICONTENT_CREW_ACK_TYPE_7();
					content.CREW_ACK_TYPE[0].Value = CONTENT.CREW_ACK_TYPE;
				}

			}

			cd_cabi_7.Items[0] = header;
			cd_cabi_7.Items[1] = content;
			return cd_cabi_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|CD-CABI|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|CD-CABI|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}

	public partial class PTC_CD_CABIHEADER_7 {
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

	public partial class PTC_CD_CABICONTENT_7 {
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string BULLETIN_ITEM_NUMBER = "";
		public string CREW_ACK_TYPE = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class CD_CABI_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(CD_CABIHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(CD_CABICONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABIHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABIHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_BULLETIN_ITEM_NUMBER_7[] BULLETIN_ITEM_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CABICONTENT_CREW_ACK_TYPE_7[] CREW_ACK_TYPE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_BULLETIN_ITEM_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class CD_CABICONTENT_CREW_ACK_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}