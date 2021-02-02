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
	public partial class PTC_GD_BUDS_7 {
		public PTC_GD_BUDSHEADER_7 HEADER;
		public PTC_GD_BUDSCONTENT_7 CONTENT;
		public string JSONHeader;
		
		public static void createGD_BUDS_7(
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
			string content_bulletin_item_number,
			string content_action,
			string content_affected_trains,
			string content_train_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			PTC_GD_BUDS_7 ptc_gd_buds = buildPTC_GD_BUDS_7(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac, header_htrn_symbol, header_htrn_section, header_htrn_origin_date, header_heng_engine_initial, header_heng_engine_number, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number, content_action, content_affected_trains, content_train_record);
			ptc_gd_buds.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"GD-BUDS\",  \"Queue\"\":\"Auto\"}";
				
			GD_BUDS_7 gd_buds = ptc_gd_buds.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(GD_BUDS_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, gd_buds);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_buds.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} 
			else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = ptc_gd_buds.toSteMessageHeader(request);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);

//				request = ptc_gd_buds.toSteMessageHeader(request, true);
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

		public static PTC_GD_BUDS_7 buildPTC_GD_BUDS_7(
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
			string content_bulletin_item_number,
			string content_action,
			string content_affected_trains,
			string content_train_record
		) {

			PTC_GD_BUDS_7 ptc_gd_buds = new PTC_GD_BUDS_7();

			PTC_GD_BUDSHEADER_7 header = new PTC_GD_BUDSHEADER_7();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "GD-BUDS";
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
			
			PTC_GD_BUDSCONTENT_7 content = new PTC_GD_BUDSCONTENT_7();
			content.BULLETIN_ITEM_NUMBER = content_bulletin_item_number;
			content.ACTION = content_action;
			content.AFFECTED_TRAINS = content_affected_trains;
			if (content_train_record != "") {
				string[] train_recordList = content_train_record.Split('|');
				for (int i = 0; i < train_recordList.Length;) {
					PTC_GD_BUDSTRAIN_RECORD_7 train_records = new PTC_GD_BUDSTRAIN_RECORD_7();
					train_records.STATUS_CODE = train_recordList[i];i++;
					Ranorex.Report.Info("si"+i);
					train_records.SCAC = train_recordList[i];i++;
					Ranorex.Report.Info("scaci"+i);
					train_records.SYMBOL = train_recordList[i];i++;
					Ranorex.Report.Info("symboli"+i);
					train_records.SECTION = train_recordList[i];i++;
					Ranorex.Report.Info("sectioni"+i);
					train_records.ORIGIN_DATE = train_recordList[i];i++;
					Ranorex.Report.Info("oi"+i);
					content.addTRAIN_RECORD(train_records);
				}
			}

			ptc_gd_buds.HEADER = header;
			ptc_gd_buds.CONTENT = content;
			return ptc_gd_buds;
		}

		public GD_BUDS_7 toSerializableObject() {
			GD_BUDS_7 gd_buds_7 = new GD_BUDS_7();
			gd_buds_7.Items = new object[2];

			GD_BUDSHEADER_7 header = new GD_BUDSHEADER_7();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new GD_BUDSHEADER_EVENT_DATE_7[1];
					header.EVENT_DATE[0] = new GD_BUDSHEADER_EVENT_DATE_7();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new GD_BUDSHEADER_EVENT_TIME_7[1];
					header.EVENT_TIME[0] = new GD_BUDSHEADER_EVENT_TIME_7();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new GD_BUDSHEADER_MESSAGE_ID_7[1];
					header.MESSAGE_ID[0] = new GD_BUDSHEADER_MESSAGE_ID_7();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new GD_BUDSHEADER_SEQUENCE_NUMBER_7[1];
					header.SEQUENCE_NUMBER[0] = new GD_BUDSHEADER_SEQUENCE_NUMBER_7();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new GD_BUDSHEADER_MESSAGE_VERSION_7[1];
					header.MESSAGE_VERSION[0] = new GD_BUDSHEADER_MESSAGE_VERSION_7();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new GD_BUDSHEADER_MESSAGE_REVISION_7[1];
					header.MESSAGE_REVISION[0] = new GD_BUDSHEADER_MESSAGE_REVISION_7();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new GD_BUDSHEADER_SOURCE_SYS_7[1];
					header.SOURCE_SYS[0] = new GD_BUDSHEADER_SOURCE_SYS_7();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new GD_BUDSHEADER_DESTINATION_SYS_7[1];
					header.DESTINATION_SYS[0] = new GD_BUDSHEADER_DESTINATION_SYS_7();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new GD_BUDSHEADER_DISTRICT_NAME_7[1];
					header.DISTRICT_NAME[0] = new GD_BUDSHEADER_DISTRICT_NAME_7();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new GD_BUDSHEADER_DISTRICT_SCAC_7[1];
					header.DISTRICT_SCAC[0] = new GD_BUDSHEADER_DISTRICT_SCAC_7();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new GD_BUDSHEADER_USER_ID_7[1];
					header.USER_ID[0] = new GD_BUDSHEADER_USER_ID_7();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

				if (HEADER.TRACK_FILE_VERSION != null && HEADER.TRACK_FILE_VERSION != "") {
					header.TRACK_FILE_VERSION = new GD_BUDSHEADER_TRACK_FILE_VERSION_7[1];
					header.TRACK_FILE_VERSION[0] = new GD_BUDSHEADER_TRACK_FILE_VERSION_7();
					if (HEADER.TRACK_FILE_VERSION == "Empty") {
						header.TRACK_FILE_VERSION[0].Value = "";
					} else {
						header.TRACK_FILE_VERSION[0].Value = HEADER.TRACK_FILE_VERSION;
					}
				}

				if (HEADER.HTRN_SCAC != null && HEADER.HTRN_SCAC != "") {
					header.HTRN_SCAC = new GD_BUDSHEADER_HTRN_SCAC_7[1];
					header.HTRN_SCAC[0] = new GD_BUDSHEADER_HTRN_SCAC_7();
					if (HEADER.HTRN_SCAC == "Empty") {
						header.HTRN_SCAC[0].Value = "";
					} else {
						header.HTRN_SCAC[0].Value = HEADER.HTRN_SCAC;
					}
				}

				if (HEADER.HTRN_SYMBOL != null && HEADER.HTRN_SYMBOL != "") {
					header.HTRN_SYMBOL = new GD_BUDSHEADER_HTRN_SYMBOL_7[1];
					header.HTRN_SYMBOL[0] = new GD_BUDSHEADER_HTRN_SYMBOL_7();
					if (HEADER.HTRN_SYMBOL == "Empty") {
						header.HTRN_SYMBOL[0].Value = "";
					} else {
						header.HTRN_SYMBOL[0].Value = HEADER.HTRN_SYMBOL;
					}
				}

				if (HEADER.HTRN_SECTION != null && HEADER.HTRN_SECTION != "") {
					header.HTRN_SECTION = new GD_BUDSHEADER_HTRN_SECTION_7[1];
					header.HTRN_SECTION[0] = new GD_BUDSHEADER_HTRN_SECTION_7();
					if (HEADER.HTRN_SECTION == "Empty") {
						header.HTRN_SECTION[0].Value = "";
					} else {
						header.HTRN_SECTION[0].Value = HEADER.HTRN_SECTION;
					}
				}

				if (HEADER.HTRN_ORIGIN_DATE != null && HEADER.HTRN_ORIGIN_DATE != "") {
					header.HTRN_ORIGIN_DATE = new GD_BUDSHEADER_HTRN_ORIGIN_DATE_7[1];
					header.HTRN_ORIGIN_DATE[0] = new GD_BUDSHEADER_HTRN_ORIGIN_DATE_7();
					if (HEADER.HTRN_ORIGIN_DATE == "Empty") {
						header.HTRN_ORIGIN_DATE[0].Value = "";
					} else {
						header.HTRN_ORIGIN_DATE[0].Value = HEADER.HTRN_ORIGIN_DATE;
					}
				}

				if (HEADER.HENG_ENGINE_INITIAL != null && HEADER.HENG_ENGINE_INITIAL != "") {
					header.HENG_ENGINE_INITIAL = new GD_BUDSHEADER_HENG_ENGINE_INITIAL_7[1];
					header.HENG_ENGINE_INITIAL[0] = new GD_BUDSHEADER_HENG_ENGINE_INITIAL_7();
					if (HEADER.HENG_ENGINE_INITIAL == "Empty") {
						header.HENG_ENGINE_INITIAL[0].Value = "";
					} else {
						header.HENG_ENGINE_INITIAL[0].Value = HEADER.HENG_ENGINE_INITIAL;
					}
				}

				if (HEADER.HENG_ENGINE_NUMBER != null && HEADER.HENG_ENGINE_NUMBER != "") {
					header.HENG_ENGINE_NUMBER = new GD_BUDSHEADER_HENG_ENGINE_NUMBER_7[1];
					header.HENG_ENGINE_NUMBER[0] = new GD_BUDSHEADER_HENG_ENGINE_NUMBER_7();
					if (HEADER.HENG_ENGINE_NUMBER == "Empty") {
						header.HENG_ENGINE_NUMBER[0].Value = "";
					} else {
						header.HENG_ENGINE_NUMBER[0].Value = HEADER.HENG_ENGINE_NUMBER;
					}
				}

				if (HEADER.UID1_TYPE != null && HEADER.UID1_TYPE != "") {
					header.UID1_TYPE = new GD_BUDSHEADER_UID1_TYPE_7[1];
					header.UID1_TYPE[0] = new GD_BUDSHEADER_UID1_TYPE_7();
					if (HEADER.UID1_TYPE == "Empty") {
						header.UID1_TYPE[0].Value = "";
					} else {
						header.UID1_TYPE[0].Value = HEADER.UID1_TYPE;
					}
				}

				if (HEADER.UID1 != null && HEADER.UID1 != "") {
					header.UID1 = new GD_BUDSHEADER_UID1_7[1];
					header.UID1[0] = new GD_BUDSHEADER_UID1_7();
					if (HEADER.UID1 == "Empty") {
						header.UID1[0].Value = "";
					} else {
						header.UID1[0].Value = HEADER.UID1;
					}
				}

				if (HEADER.UID2_TYPE != null && HEADER.UID2_TYPE != "") {
					header.UID2_TYPE = new GD_BUDSHEADER_UID2_TYPE_7[1];
					header.UID2_TYPE[0] = new GD_BUDSHEADER_UID2_TYPE_7();
					if (HEADER.UID2_TYPE == "Empty") {
						header.UID2_TYPE[0].Value = "";
					} else {
						header.UID2_TYPE[0].Value = HEADER.UID2_TYPE;
					}
				}

				if (HEADER.UID2 != null && HEADER.UID2 != "") {
					header.UID2 = new GD_BUDSHEADER_UID2_7[1];
					header.UID2[0] = new GD_BUDSHEADER_UID2_7();
					if (HEADER.UID2 == "Empty") {
						header.UID2[0].Value = "";
					} else {
						header.UID2[0].Value = HEADER.UID2;
					}
				}
				
			}
			GD_BUDSCONTENT_7 content = new GD_BUDSCONTENT_7();
			if (this.CONTENT != null) {
				if (CONTENT.BULLETIN_ITEM_NUMBER != "Null") {
					content.BULLETIN_ITEM_NUMBER = new GD_BUDSCONTENT_BULLETIN_ITEM_NUMBER_7[1];
					content.BULLETIN_ITEM_NUMBER[0] = new GD_BUDSCONTENT_BULLETIN_ITEM_NUMBER_7();
					content.BULLETIN_ITEM_NUMBER[0].Value = CONTENT.BULLETIN_ITEM_NUMBER;
				}

				if (CONTENT.ACTION != "Null") {
					content.ACTION = new GD_BUDSCONTENT_ACTION_7[1];
					content.ACTION[0] = new GD_BUDSCONTENT_ACTION_7();
					content.ACTION[0].Value = CONTENT.ACTION;
				}

				if (CONTENT.AFFECTED_TRAINS != "Null") {
					content.AFFECTED_TRAINS = new GD_BUDSCONTENT_AFFECTED_TRAINS_7[1];
					content.AFFECTED_TRAINS[0] = new GD_BUDSCONTENT_AFFECTED_TRAINS_7();
					content.AFFECTED_TRAINS[0].Value = CONTENT.AFFECTED_TRAINS;
				}

				if (CONTENT.TRAIN_RECORD.Count != 0) {
					int train_recordIndex = 0;
					content.TRAIN_RECORD = new GD_BUDSCONTENT_TRAIN_RECORD_7[CONTENT.TRAIN_RECORD.Count];
					foreach (PTC_GD_BUDSTRAIN_RECORD_7 TRAIN_RECORD in CONTENT.TRAIN_RECORD) {
						GD_BUDSCONTENT_TRAIN_RECORD_7 train_record = new GD_BUDSCONTENT_TRAIN_RECORD_7();
						if (TRAIN_RECORD.STATUS_CODE != "Null") {
							train_record.STATUS_CODE = new GD_BUDSTRAIN_RECORD_STATUS_CODE_7[1];
							train_record.STATUS_CODE[0] = new GD_BUDSTRAIN_RECORD_STATUS_CODE_7();
							train_record.STATUS_CODE[0].Value = TRAIN_RECORD.STATUS_CODE;
						}

						if (TRAIN_RECORD.SCAC != "Null") {
							train_record.SCAC = new GD_BUDSTRAIN_RECORD_SCAC_7[1];
							train_record.SCAC[0] = new GD_BUDSTRAIN_RECORD_SCAC_7();
							train_record.SCAC[0].Value = TRAIN_RECORD.SCAC;
						}

						if (TRAIN_RECORD.SYMBOL != "Null") {
							train_record.SYMBOL = new GD_BUDSTRAIN_RECORD_SYMBOL_7[1];
							train_record.SYMBOL[0] = new GD_BUDSTRAIN_RECORD_SYMBOL_7();
							train_record.SYMBOL[0].Value = TRAIN_RECORD.SYMBOL;
						}

						if (TRAIN_RECORD.SECTION != "Null") {
							train_record.SECTION = new GD_BUDSTRAIN_RECORD_SECTION_7[1];
							train_record.SECTION[0] = new GD_BUDSTRAIN_RECORD_SECTION_7();
							train_record.SECTION[0].Value = TRAIN_RECORD.SECTION;
						}

						if (TRAIN_RECORD.ORIGIN_DATE != "Null") {
							train_record.ORIGIN_DATE = new GD_BUDSTRAIN_RECORD_ORIGIN_DATE_7[1];
							train_record.ORIGIN_DATE[0] = new GD_BUDSTRAIN_RECORD_ORIGIN_DATE_7();
							train_record.ORIGIN_DATE[0].Value = TRAIN_RECORD.ORIGIN_DATE;
						}

						content.TRAIN_RECORD[train_recordIndex] = train_record;
						train_recordIndex++;
					}
				}

			}

			gd_buds_7.Items[0] = header;
			gd_buds_7.Items[1] = content;
			return gd_buds_7;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|GD-BUDS|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|GD-BUDS|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	
	
	public partial class PTC_GD_BUDSHEADER_7 {
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
	
	public partial class PTC_GD_BUDSCONTENT_7 {
		public string BULLETIN_ITEM_NUMBER = "";
		public string ACTION = "";
		public string AFFECTED_TRAINS = "";
		public ArrayList TRAIN_RECORD = new ArrayList();

		public void addTRAIN_RECORD(PTC_GD_BUDSTRAIN_RECORD_7 train_record) {
			this.TRAIN_RECORD.Add(train_record);
		}
	}

	public partial class PTC_GD_BUDSTRAIN_RECORD_7 {
		public string STATUS_CODE = "";
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "GD-BUDS", IsNullable = false)]
	public partial class GD_BUDS_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(GD_BUDSHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(GD_BUDSCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}
	
		[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSCONTENT_7 {
		
		private GD_BUDSCONTENT_BULLETIN_ITEM_NUMBER_7 [] BULLETIN_ITEM_NUMBERField;
		private GD_BUDSCONTENT_ACTION_7 [] ACTIONField;
		private GD_BUDSCONTENT_AFFECTED_TRAINS_7 [] AFFECTED_TRAINSField;
		private GD_BUDSCONTENT_TRAIN_RECORD_7 [] TRAIN_RECORDField;
		
		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSCONTENT_BULLETIN_ITEM_NUMBER_7[] BULLETIN_ITEM_NUMBER{
            get { return this.BULLETIN_ITEM_NUMBERField; }
            set { this.BULLETIN_ITEM_NUMBERField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSCONTENT_ACTION_7[] ACTION{
            get { return this.ACTIONField; }
            set { this.ACTIONField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("AFFECTED_TRAINS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSCONTENT_AFFECTED_TRAINS_7[] AFFECTED_TRAINS{
            get { return this.AFFECTED_TRAINSField; }
            set { this.AFFECTED_TRAINSField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSCONTENT_TRAIN_RECORD_7[] TRAIN_RECORD{
            get { return this.TRAIN_RECORDField; }
            set { this.TRAIN_RECORDField = value; }
        }

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSCONTENT_BULLETIN_ITEM_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSCONTENT_ACTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSCONTENT_AFFECTED_TRAINS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSCONTENT_TRAIN_RECORD_7 {
		
		private GD_BUDSTRAIN_RECORD_STATUS_CODE_7[] STATUS_CODEField;
		private GD_BUDSTRAIN_RECORD_SCAC_7[] SCACField;
		private GD_BUDSTRAIN_RECORD_SYMBOL_7[] SYMBOLField;
		private GD_BUDSTRAIN_RECORD_SECTION_7[] SECTIONField;
		private GD_BUDSTRAIN_RECORD_ORIGIN_DATE_7[] ORIGIN_DATEField;
		
		[System.Xml.Serialization.XmlElementAttribute("STATUS_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSTRAIN_RECORD_STATUS_CODE_7[] STATUS_CODE{
            get { return this.STATUS_CODEField; }
            set { this.STATUS_CODEField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSTRAIN_RECORD_SCAC_7[] SCAC{
            get { return this.SCACField; }
            set { this.SCACField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSTRAIN_RECORD_SYMBOL_7[] SYMBOL{
            get { return this.SYMBOLField; }
            set { this.SYMBOLField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSTRAIN_RECORD_SECTION_7[] SECTION{
            get { return this.SECTIONField; }
            set { this.SECTIONField = value; }
        }

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public GD_BUDSTRAIN_RECORD_ORIGIN_DATE_7[] ORIGIN_DATE{
            get { return this.ORIGIN_DATEField; }
            set { this.ORIGIN_DATEField = value; }
        }

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSTRAIN_RECORD_STATUS_CODE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSTRAIN_RECORD_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSTRAIN_RECORD_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSTRAIN_RECORD_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GD_BUDSTRAIN_RECORD_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

}