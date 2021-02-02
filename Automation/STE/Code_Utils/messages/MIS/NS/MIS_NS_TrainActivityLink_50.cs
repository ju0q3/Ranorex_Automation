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

namespace STE.Code_Utils.messages.MIS.NS
{
	public partial class MIS_NS_TrainActivityLink_50 {
		public MIS_NS_TrainActivityLinkHEADER_50 HEADER;
		public MIS_NS_TrainActivityLinkCONTENT_50 CONTENT;

		public static void createNS_TrainActivityLink_50(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_from_scac,
			string content_from_section,
			string content_from_train_symbol,
			string content_from_origin_date,
			string content_minimum_connection_time,
			string content_to_scac,
			string content_to_section,
			string content_to_train_symbol,
			string content_to_origin_date,
			string content_link_unlink,
			string content_link_location,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainActivityLink_50 mis_ns_trainactivitylink = buildMIS_NS_TrainActivityLink_50(header_protocolid, header_msgid, header_trace_id, header_message_version, content_from_scac, content_from_section, content_from_train_symbol, content_from_origin_date, content_minimum_connection_time, content_to_scac, content_to_section, content_to_train_symbol, content_to_origin_date, content_link_unlink, content_link_location);

			NS_TrainActivityLink_50 ns_trainactivitylink = mis_ns_trainactivitylink.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainActivityLink_50));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_trainactivitylink);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainactivitylink.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainactivitylink.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainActivityLink_50 buildMIS_NS_TrainActivityLink_50(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_from_scac,
			string content_from_section,
			string content_from_train_symbol,
			string content_from_origin_date,
			string content_minimum_connection_time,
			string content_to_scac,
			string content_to_section,
			string content_to_train_symbol,
			string content_to_origin_date,
			string content_link_unlink,
			string content_link_location
		) {

			MIS_NS_TrainActivityLink_50 mis_ns_trainactivitylink = new MIS_NS_TrainActivityLink_50();

			MIS_NS_TrainActivityLinkHEADER_50 header = new MIS_NS_TrainActivityLinkHEADER_50();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainActivityLinkCONTENT_50 content = new MIS_NS_TrainActivityLinkCONTENT_50();
			content.FROM_SCAC = content_from_scac;
			content.FROM_SECTION = content_from_section;
			content.FROM_TRAIN_SYMBOL = content_from_train_symbol;
			content.FROM_ORIGIN_DATE = content_from_origin_date;
			content.MINIMUM_CONNECTION_TIME = content_minimum_connection_time;
			content.TO_SCAC = content_to_scac;
			content.TO_SECTION = content_to_section;
			content.TO_TRAIN_SYMBOL = content_to_train_symbol;
			content.TO_ORIGIN_DATE = content_to_origin_date;
			content.LINK_UNLINK = content_link_unlink;
			content.LINK_LOCATION = content_link_location;

			mis_ns_trainactivitylink.HEADER = header;
			mis_ns_trainactivitylink.CONTENT = content;
			return mis_ns_trainactivitylink;
		}

		public NS_TrainActivityLink_50 toSerializableObject() {
			NS_TrainActivityLink_50 ns_trainactivitylink_50 = new NS_TrainActivityLink_50();
			ns_trainactivitylink_50.Items = new object[2];

			NS_TrainActivityLinkHEADER_50 header = new NS_TrainActivityLinkHEADER_50();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainActivityLinkHEADER_PROTOCOLID_50[1];
					header.PROTOCOLID[0] = new NS_TrainActivityLinkHEADER_PROTOCOLID_50();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainActivityLinkHEADER_MSGID_50[1];
					header.MSGID[0] = new NS_TrainActivityLinkHEADER_MSGID_50();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_TrainActivityLinkHEADER_TRACE_ID_50[1];
					header.TRACE_ID[0] = new NS_TrainActivityLinkHEADER_TRACE_ID_50();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_TrainActivityLinkHEADER_MESSAGE_VERSION_50[1];
					header.MESSAGE_VERSION[0] = new NS_TrainActivityLinkHEADER_MESSAGE_VERSION_50();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_TrainActivityLinkCONTENT_50 content = new NS_TrainActivityLinkCONTENT_50();
			if (this.CONTENT != null) {
				if (CONTENT.FROM_SCAC != "Null") {
					content.FROM_SCAC = new NS_TrainActivityLinkCONTENT_FROM_SCAC_50[1];
					content.FROM_SCAC[0] = new NS_TrainActivityLinkCONTENT_FROM_SCAC_50();
					content.FROM_SCAC[0].Value = CONTENT.FROM_SCAC;
				}

				if (CONTENT.FROM_SECTION != "Null") {
					content.FROM_SECTION = new NS_TrainActivityLinkCONTENT_FROM_SECTION_50[1];
					content.FROM_SECTION[0] = new NS_TrainActivityLinkCONTENT_FROM_SECTION_50();
					content.FROM_SECTION[0].Value = CONTENT.FROM_SECTION;
				}

				if (CONTENT.FROM_TRAIN_SYMBOL != "Null") {
					content.FROM_TRAIN_SYMBOL = new NS_TrainActivityLinkCONTENT_FROM_TRAIN_SYMBOL_50[1];
					content.FROM_TRAIN_SYMBOL[0] = new NS_TrainActivityLinkCONTENT_FROM_TRAIN_SYMBOL_50();
					content.FROM_TRAIN_SYMBOL[0].Value = CONTENT.FROM_TRAIN_SYMBOL;
				}

				if (CONTENT.FROM_ORIGIN_DATE != "Null") {
					content.FROM_ORIGIN_DATE = new NS_TrainActivityLinkCONTENT_FROM_ORIGIN_DATE_50[1];
					content.FROM_ORIGIN_DATE[0] = new NS_TrainActivityLinkCONTENT_FROM_ORIGIN_DATE_50();
					content.FROM_ORIGIN_DATE[0].Value = CONTENT.FROM_ORIGIN_DATE;
				}

				if (CONTENT.MINIMUM_CONNECTION_TIME != "Null") {
					content.MINIMUM_CONNECTION_TIME = new NS_TrainActivityLinkCONTENT_MINIMUM_CONNECTION_TIME_50[1];
					content.MINIMUM_CONNECTION_TIME[0] = new NS_TrainActivityLinkCONTENT_MINIMUM_CONNECTION_TIME_50();
					content.MINIMUM_CONNECTION_TIME[0].Value = CONTENT.MINIMUM_CONNECTION_TIME;
				}

				if (CONTENT.TO_SCAC != "Null") {
					content.TO_SCAC = new NS_TrainActivityLinkCONTENT_TO_SCAC_50[1];
					content.TO_SCAC[0] = new NS_TrainActivityLinkCONTENT_TO_SCAC_50();
					content.TO_SCAC[0].Value = CONTENT.TO_SCAC;
				}

				if (CONTENT.TO_SECTION != "Null") {
					content.TO_SECTION = new NS_TrainActivityLinkCONTENT_TO_SECTION_50[1];
					content.TO_SECTION[0] = new NS_TrainActivityLinkCONTENT_TO_SECTION_50();
					content.TO_SECTION[0].Value = CONTENT.TO_SECTION;
				}

				if (CONTENT.TO_TRAIN_SYMBOL != "Null") {
					content.TO_TRAIN_SYMBOL = new NS_TrainActivityLinkCONTENT_TO_TRAIN_SYMBOL_50[1];
					content.TO_TRAIN_SYMBOL[0] = new NS_TrainActivityLinkCONTENT_TO_TRAIN_SYMBOL_50();
					content.TO_TRAIN_SYMBOL[0].Value = CONTENT.TO_TRAIN_SYMBOL;
				}

				if (CONTENT.TO_ORIGIN_DATE != "Null") {
					content.TO_ORIGIN_DATE = new NS_TrainActivityLinkCONTENT_TO_ORIGIN_DATE_50[1];
					content.TO_ORIGIN_DATE[0] = new NS_TrainActivityLinkCONTENT_TO_ORIGIN_DATE_50();
					content.TO_ORIGIN_DATE[0].Value = CONTENT.TO_ORIGIN_DATE;
				}

				if (CONTENT.LINK_UNLINK != "Null") {
					content.LINK_UNLINK = new NS_TrainActivityLinkCONTENT_LINK_UNLINK_50[1];
					content.LINK_UNLINK[0] = new NS_TrainActivityLinkCONTENT_LINK_UNLINK_50();
					content.LINK_UNLINK[0].Value = CONTENT.LINK_UNLINK;
				}

				if (CONTENT.LINK_LOCATION != "Null") {
					content.LINK_LOCATION = new NS_TrainActivityLinkCONTENT_LINK_LOCATION_50[1];
					content.LINK_LOCATION[0] = new NS_TrainActivityLinkCONTENT_LINK_LOCATION_50();
					content.LINK_LOCATION[0].Value = CONTENT.LINK_LOCATION;
				}

			}

			ns_trainactivitylink_50.Items[0] = header;
			ns_trainactivitylink_50.Items[1] = content;
			return ns_trainactivitylink_50;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNATL,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNATL,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainActivityLinkHEADER_50 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainActivityLinkCONTENT_50 {
		public string FROM_SCAC = "";
		public string FROM_SECTION = "";
		public string FROM_TRAIN_SYMBOL = "";
		public string FROM_ORIGIN_DATE = "";
		public string MINIMUM_CONNECTION_TIME = "";
		public string TO_SCAC = "";
		public string TO_SECTION = "";
		public string TO_TRAIN_SYMBOL = "";
		public string TO_ORIGIN_DATE = "";
		public string LINK_UNLINK = "";
		public string LINK_LOCATION = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainActivityLink", IsNullable = false)]
	public partial class NS_TrainActivityLink_50 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainActivityLinkHEADER_50), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainActivityLinkCONTENT_50), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkHEADER_50 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkHEADER_PROTOCOLID_50[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkHEADER_MSGID_50[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkHEADER_TRACE_ID_50[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkHEADER_MESSAGE_VERSION_50[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkHEADER_PROTOCOLID_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkHEADER_MSGID_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkHEADER_TRACE_ID_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkHEADER_MESSAGE_VERSION_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_50 {
		[System.Xml.Serialization.XmlElementAttribute("FROM_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_FROM_SCAC_50[] FROM_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("FROM_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_FROM_SECTION_50[] FROM_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("FROM_TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_FROM_TRAIN_SYMBOL_50[] FROM_TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("FROM_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_FROM_ORIGIN_DATE_50[] FROM_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("MINIMUM_CONNECTION_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_MINIMUM_CONNECTION_TIME_50[] MINIMUM_CONNECTION_TIME;

		[System.Xml.Serialization.XmlElementAttribute("TO_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_TO_SCAC_50[] TO_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("TO_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_TO_SECTION_50[] TO_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TO_TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_TO_TRAIN_SYMBOL_50[] TO_TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("TO_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_TO_ORIGIN_DATE_50[] TO_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LINK_UNLINK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_LINK_UNLINK_50[] LINK_UNLINK;

		[System.Xml.Serialization.XmlElementAttribute("LINK_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainActivityLinkCONTENT_LINK_LOCATION_50[] LINK_LOCATION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_FROM_SCAC_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_FROM_SECTION_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_FROM_TRAIN_SYMBOL_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_FROM_ORIGIN_DATE_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_MINIMUM_CONNECTION_TIME_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_TO_SCAC_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_TO_SECTION_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_TO_TRAIN_SYMBOL_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_TO_ORIGIN_DATE_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_LINK_UNLINK_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainActivityLinkCONTENT_LINK_LOCATION_50 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}