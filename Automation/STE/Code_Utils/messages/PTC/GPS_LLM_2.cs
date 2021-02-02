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
	public partial class GPS_LLM_2 {
		public GPS_LLMHEADER_2 HEADER;
		public GPS_LLMCONTENT_2 CONTENT;

		public static void createLLM_2(
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
			string content_engine_initial,
			string content_engine_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_milepost,
			string content_division,
			string content_track,
			string content_source,
			string content_location_event_date,
			string content_location_event_time,
			string content_location_event_timezone,
			string content_report_date,
			string content_report_time,
			string content_report_timezone,
			string content_speed,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			GPS_LLM_2 gps_llm = buildGPS_LLM_2(header_event_date, header_event_time, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, content_engine_initial, content_engine_number, content_scac, content_symbol, content_section, content_origin_date, content_milepost, content_division, content_track, content_source, content_location_event_date, content_location_event_time, content_location_event_timezone, content_report_date, content_report_time, content_report_timezone, content_speed);

			LLM_2 llm = gps_llm.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(LLM_2));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, llm);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = gps_llm.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = gps_llm.toSteMessageHeader(request, true);
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

		public static GPS_LLM_2 buildGPS_LLM_2(
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
			string content_engine_initial,
			string content_engine_number,
			string content_scac,
			string content_symbol,
			string content_section,
			string content_origin_date,
			string content_milepost,
			string content_division,
			string content_track,
			string content_source,
			string content_location_event_date,
			string content_location_event_time,
			string content_location_event_timezone,
			string content_report_date,
			string content_report_time,
			string content_report_timezone,
			string content_speed
		) {

			GPS_LLM_2 gps_llm = new GPS_LLM_2();

			GPS_LLMHEADER_2 header = new GPS_LLMHEADER_2();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "LLM";
			header.SEQUENCE_NUMBER = header_sequence_number;
			header.MESSAGE_VERSION = header_message_version;
			header.MESSAGE_REVISION = header_message_revision;
			header.SOURCE_SYS = header_source_sys;
			header.DESTINATION_SYS = header_destination_sys;
			header.DISTRICT_NAME = header_district_name;
			header.DISTRICT_SCAC = header_district_scac;
			header.USER_ID = header_user_id;

			GPS_LLMCONTENT_2 content = new GPS_LLMCONTENT_2();
			content.ENGINE_INITIAL = content_engine_initial;
			content.ENGINE_NUMBER = content_engine_number;
			content.SCAC = content_scac;
			content.SYMBOL = content_symbol;
			content.SECTION = content_section;
			content.ORIGIN_DATE = content_origin_date;
			content.MILEPOST = content_milepost;
			content.DIVISION = content_division;
			content.TRACK = content_track;
			content.SOURCE = content_source;
			content.LOCATION_EVENT_DATE = content_location_event_date;
			content.LOCATION_EVENT_TIME = content_location_event_time;
			content.LOCATION_EVENT_TIMEZONE = content_location_event_timezone;
			content.REPORT_DATE = content_report_date;
			content.REPORT_TIME = content_report_time;
			content.REPORT_TIMEZONE = content_report_timezone;
			content.SPEED = content_speed;

			gps_llm.HEADER = header;
			gps_llm.CONTENT = content;
			return gps_llm;
		}

		public LLM_2 toSerializableObject() {
			LLM_2 llm_2 = new LLM_2();
			llm_2.Items = new object[2];

			LLMHEADER_2 header = new LLMHEADER_2();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new LLMHEADER_EVENT_DATE_2[1];
					header.EVENT_DATE[0] = new LLMHEADER_EVENT_DATE_2();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new LLMHEADER_EVENT_TIME_2[1];
					header.EVENT_TIME[0] = new LLMHEADER_EVENT_TIME_2();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new LLMHEADER_MESSAGE_ID_2[1];
					header.MESSAGE_ID[0] = new LLMHEADER_MESSAGE_ID_2();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new LLMHEADER_SEQUENCE_NUMBER_2[1];
					header.SEQUENCE_NUMBER[0] = new LLMHEADER_SEQUENCE_NUMBER_2();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new LLMHEADER_MESSAGE_VERSION_2[1];
					header.MESSAGE_VERSION[0] = new LLMHEADER_MESSAGE_VERSION_2();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.MESSAGE_REVISION != "Null") {
					header.MESSAGE_REVISION = new LLMHEADER_MESSAGE_REVISION_2[1];
					header.MESSAGE_REVISION[0] = new LLMHEADER_MESSAGE_REVISION_2();
					header.MESSAGE_REVISION[0].Value = HEADER.MESSAGE_REVISION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new LLMHEADER_SOURCE_SYS_2[1];
					header.SOURCE_SYS[0] = new LLMHEADER_SOURCE_SYS_2();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new LLMHEADER_DESTINATION_SYS_2[1];
					header.DESTINATION_SYS[0] = new LLMHEADER_DESTINATION_SYS_2();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != null && HEADER.DISTRICT_NAME != "") {
					header.DISTRICT_NAME = new LLMHEADER_DISTRICT_NAME_2[1];
					header.DISTRICT_NAME[0] = new LLMHEADER_DISTRICT_NAME_2();
					if (HEADER.DISTRICT_NAME == "Empty") {
						header.DISTRICT_NAME[0].Value = "";
					} else {
						header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
					}
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new LLMHEADER_DISTRICT_SCAC_2[1];
					header.DISTRICT_SCAC[0] = new LLMHEADER_DISTRICT_SCAC_2();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != null && HEADER.USER_ID != "") {
					header.USER_ID = new LLMHEADER_USER_ID_2[1];
					header.USER_ID[0] = new LLMHEADER_USER_ID_2();
					if (HEADER.USER_ID == "Empty") {
						header.USER_ID[0].Value = "";
					} else {
						header.USER_ID[0].Value = HEADER.USER_ID;
					}
				}

			}

			LLMCONTENT_2 content = new LLMCONTENT_2();
			if (this.CONTENT != null) {
				if (CONTENT.ENGINE_INITIAL != "Null") {
					content.ENGINE_INITIAL = new LLMCONTENT_ENGINE_INITIAL_2[1];
					content.ENGINE_INITIAL[0] = new LLMCONTENT_ENGINE_INITIAL_2();
					content.ENGINE_INITIAL[0].Value = CONTENT.ENGINE_INITIAL;
				}

				if (CONTENT.ENGINE_NUMBER != "Null") {
					content.ENGINE_NUMBER = new LLMCONTENT_ENGINE_NUMBER_2[1];
					content.ENGINE_NUMBER[0] = new LLMCONTENT_ENGINE_NUMBER_2();
					content.ENGINE_NUMBER[0].Value = CONTENT.ENGINE_NUMBER;
				}

				if (CONTENT.SCAC != "Null") {
					content.SCAC = new LLMCONTENT_SCAC_2[1];
					content.SCAC[0] = new LLMCONTENT_SCAC_2();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SYMBOL != "Null") {
					content.SYMBOL = new LLMCONTENT_SYMBOL_2[1];
					content.SYMBOL[0] = new LLMCONTENT_SYMBOL_2();
					content.SYMBOL[0].Value = CONTENT.SYMBOL;
				}

				if (CONTENT.SECTION != null && CONTENT.SECTION != "") {
					content.SECTION = new LLMCONTENT_SECTION_2[1];
					content.SECTION[0] = new LLMCONTENT_SECTION_2();
					if (CONTENT.SECTION == "Empty") {
						content.SECTION[0].Value = "";
					} else {
						content.SECTION[0].Value = CONTENT.SECTION;
					}
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new LLMCONTENT_ORIGIN_DATE_2[1];
					content.ORIGIN_DATE[0] = new LLMCONTENT_ORIGIN_DATE_2();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.MILEPOST != "Null") {
					content.MILEPOST = new LLMCONTENT_MILEPOST_2[1];
					content.MILEPOST[0] = new LLMCONTENT_MILEPOST_2();
					content.MILEPOST[0].Value = CONTENT.MILEPOST;
				}

				if (CONTENT.DIVISION != null && CONTENT.DIVISION != "") {
					content.DIVISION = new LLMCONTENT_DIVISION_2[1];
					content.DIVISION[0] = new LLMCONTENT_DIVISION_2();
					if (CONTENT.DIVISION == "Empty") {
						content.DIVISION[0].Value = "";
					} else {
						content.DIVISION[0].Value = CONTENT.DIVISION;
					}
				}

				if (CONTENT.TRACK != null && CONTENT.TRACK != "") {
					content.TRACK = new LLMCONTENT_TRACK_2[1];
					content.TRACK[0] = new LLMCONTENT_TRACK_2();
					if (CONTENT.TRACK == "Empty") {
						content.TRACK[0].Value = "";
					} else {
						content.TRACK[0].Value = CONTENT.TRACK;
					}
				}

				if (CONTENT.SOURCE != "Null") {
					content.SOURCE = new LLMCONTENT_SOURCE_2[1];
					content.SOURCE[0] = new LLMCONTENT_SOURCE_2();
					content.SOURCE[0].Value = CONTENT.SOURCE;
				}

				if (CONTENT.LOCATION_EVENT_DATE != "Null") {
					content.LOCATION_EVENT_DATE = new LLMCONTENT_LOCATION_EVENT_DATE_2[1];
					content.LOCATION_EVENT_DATE[0] = new LLMCONTENT_LOCATION_EVENT_DATE_2();
					content.LOCATION_EVENT_DATE[0].Value = CONTENT.LOCATION_EVENT_DATE;
				}

				if (CONTENT.LOCATION_EVENT_TIME != "Null") {
					content.LOCATION_EVENT_TIME = new LLMCONTENT_LOCATION_EVENT_TIME_2[1];
					content.LOCATION_EVENT_TIME[0] = new LLMCONTENT_LOCATION_EVENT_TIME_2();
					content.LOCATION_EVENT_TIME[0].Value = CONTENT.LOCATION_EVENT_TIME;
				}

				if (CONTENT.LOCATION_EVENT_TIMEZONE != "Null") {
					content.LOCATION_EVENT_TIMEZONE = new LLMCONTENT_LOCATION_EVENT_TIMEZONE_2[1];
					content.LOCATION_EVENT_TIMEZONE[0] = new LLMCONTENT_LOCATION_EVENT_TIMEZONE_2();
					content.LOCATION_EVENT_TIMEZONE[0].Value = CONTENT.LOCATION_EVENT_TIMEZONE;
				}

				if (CONTENT.REPORT_DATE != "Null") {
					content.REPORT_DATE = new LLMCONTENT_REPORT_DATE_2[1];
					content.REPORT_DATE[0] = new LLMCONTENT_REPORT_DATE_2();
					content.REPORT_DATE[0].Value = CONTENT.REPORT_DATE;
				}

				if (CONTENT.REPORT_TIME != "Null") {
					content.REPORT_TIME = new LLMCONTENT_REPORT_TIME_2[1];
					content.REPORT_TIME[0] = new LLMCONTENT_REPORT_TIME_2();
					content.REPORT_TIME[0].Value = CONTENT.REPORT_TIME;
				}

				if (CONTENT.REPORT_TIMEZONE != "Null") {
					content.REPORT_TIMEZONE = new LLMCONTENT_REPORT_TIMEZONE_2[1];
					content.REPORT_TIMEZONE[0] = new LLMCONTENT_REPORT_TIMEZONE_2();
					content.REPORT_TIMEZONE[0].Value = CONTENT.REPORT_TIMEZONE;
				}

				if (CONTENT.SPEED != null && CONTENT.SPEED != "") {
					content.SPEED = new LLMCONTENT_SPEED_2[1];
					content.SPEED[0] = new LLMCONTENT_SPEED_2();
					if (CONTENT.SPEED == "Empty") {
						content.SPEED[0].Value = "";
					} else {
						content.SPEED[0].Value = CONTENT.SPEED;
					}
				}

			}

			llm_2.Items[0] = header;
			llm_2.Items[1] = content;
			return llm_2;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|LLM|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|LLM|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class GPS_LLMHEADER_2 {
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
	}

	public partial class GPS_LLMCONTENT_2 {
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string MILEPOST = "";
		public string DIVISION = "";
		public string TRACK = "";
		public string SOURCE = "";
		public string LOCATION_EVENT_DATE = "";
		public string LOCATION_EVENT_TIME = "";
		public string LOCATION_EVENT_TIMEZONE = "";
		public string REPORT_DATE = "";
		public string REPORT_TIME = "";
		public string REPORT_TIMEZONE = "";
		public string SPEED = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class LLM_2 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(LLMHEADER_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(LLMCONTENT_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_2 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_EVENT_DATE_2[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_EVENT_TIME_2[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_MESSAGE_ID_2[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_SEQUENCE_NUMBER_2[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_MESSAGE_VERSION_2[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_MESSAGE_REVISION_2[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_SOURCE_SYS_2[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_DESTINATION_SYS_2[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_DISTRICT_NAME_2[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_DISTRICT_SCAC_2[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMHEADER_USER_ID_2[] USER_ID;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_EVENT_DATE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_EVENT_TIME_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_MESSAGE_ID_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_SEQUENCE_NUMBER_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_MESSAGE_VERSION_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_MESSAGE_REVISION_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_SOURCE_SYS_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_DESTINATION_SYS_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_DISTRICT_NAME_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_DISTRICT_SCAC_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMHEADER_USER_ID_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_2 {
		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_ENGINE_INITIAL_2[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_ENGINE_NUMBER_2[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_SCAC_2[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_SYMBOL_2[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_SECTION_2[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_ORIGIN_DATE_2[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_MILEPOST_2[] MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("DIVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_DIVISION_2[] DIVISION;

		[System.Xml.Serialization.XmlElementAttribute("TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_TRACK_2[] TRACK;

		[System.Xml.Serialization.XmlElementAttribute("SOURCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_SOURCE_2[] SOURCE;

		[System.Xml.Serialization.XmlElementAttribute("LOCATION_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_LOCATION_EVENT_DATE_2[] LOCATION_EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LOCATION_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_LOCATION_EVENT_TIME_2[] LOCATION_EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("LOCATION_EVENT_TIMEZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_LOCATION_EVENT_TIMEZONE_2[] LOCATION_EVENT_TIMEZONE;

		[System.Xml.Serialization.XmlElementAttribute("REPORT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_REPORT_DATE_2[] REPORT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("REPORT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_REPORT_TIME_2[] REPORT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("REPORT_TIMEZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_REPORT_TIMEZONE_2[] REPORT_TIMEZONE;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public LLMCONTENT_SPEED_2[] SPEED;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_ENGINE_INITIAL_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_ENGINE_NUMBER_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_SCAC_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_SYMBOL_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_SECTION_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_ORIGIN_DATE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_MILEPOST_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_DIVISION_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_TRACK_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_SOURCE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_LOCATION_EVENT_DATE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_LOCATION_EVENT_TIME_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_LOCATION_EVENT_TIMEZONE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_REPORT_DATE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_REPORT_TIME_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_REPORT_TIMEZONE_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class LLMCONTENT_SPEED_2 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}