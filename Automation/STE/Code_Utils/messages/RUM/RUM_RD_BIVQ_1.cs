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

namespace STE.Code_Utils.messages.RUM
{
	public partial class RUM_RD_BIVQ_1 {
		public RUM_RD_BIVQHEADER_1 HEADER;
		public RUM_RD_BIVQCONTENT_1 CONTENT;

		public static void createRD_BIVQ_1(
			string header_event_date,
			string header_event_time,
			string header_sequence_number,
			string header_message_version,
			string header_source_sys,
			string header_destination_sys,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_division_name,
			string content_request_id,
			string content_pf_addressee,
			string content_pf_addressee_type,
			string content_requesting_employee,
			string content_requesting_employee_note,
			string content_bulletin_item_number,
			string content_bulletin_id,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			RUM_RD_BIVQ_1 rum_rd_bivq = buildRUM_RD_BIVQ_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, content_requesting_employee_note, content_bulletin_item_number, content_bulletin_id);

			RD_BIVQ_1 rd_bivq = rum_rd_bivq.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(RD_BIVQ_1));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, rd_bivq);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = rum_rd_bivq.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = rum_rd_bivq.toSteMessageHeader(request, true);
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

		public static RUM_RD_BIVQ_1 buildRUM_RD_BIVQ_1(
			string header_event_date,
			string header_event_time,
			string header_sequence_number,
			string header_message_version,
			string header_source_sys,
			string header_destination_sys,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_division_name,
			string content_request_id,
			string content_pf_addressee,
			string content_pf_addressee_type,
			string content_requesting_employee,
			string content_requesting_employee_note,
			string content_bulletin_item_number,
			string content_bulletin_id
		) {

			RUM_RD_BIVQ_1 rum_rd_bivq = new RUM_RD_BIVQ_1();

			RUM_RD_BIVQHEADER_1 header = new RUM_RD_BIVQHEADER_1();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "RD-BIVQ";
			header.SEQUENCE_NUMBER = header_sequence_number;
			header.MESSAGE_VERSION = header_message_version;
			header.SOURCE_SYS = header_source_sys;
			header.DESTINATION_SYS = header_destination_sys;
			header.DISTRICT_NAME = header_district_name;
			header.DISTRICT_SCAC = header_district_scac;
			header.USER_ID = header_user_id;
			header.DIVISION_NAME = header_division_name;

			RUM_RD_BIVQCONTENT_1 content = new RUM_RD_BIVQCONTENT_1();
			content.REQUEST_ID = content_request_id;
			content.PF_ADDRESSEE = content_pf_addressee;
			content.PF_ADDRESSEE_TYPE = content_pf_addressee_type;
			content.REQUESTING_EMPLOYEE = content_requesting_employee;
			content.REQUESTING_EMPLOYEE_NOTE = content_requesting_employee_note;
			content.BULLETIN_ITEM_NUMBER = content_bulletin_item_number;
			content.BULLETIN_ID = content_bulletin_id;

			rum_rd_bivq.HEADER = header;
			rum_rd_bivq.CONTENT = content;
			return rum_rd_bivq;
		}

		public RD_BIVQ_1 toSerializableObject() {
			RD_BIVQ_1 rd_bivq_1 = new RD_BIVQ_1();
			rd_bivq_1.Items = new object[2];

			RD_BIVQHEADER_1 header = new RD_BIVQHEADER_1();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new RD_BIVQHEADER_EVENT_DATE_1[1];
					header.EVENT_DATE[0] = new RD_BIVQHEADER_EVENT_DATE_1();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new RD_BIVQHEADER_EVENT_TIME_1[1];
					header.EVENT_TIME[0] = new RD_BIVQHEADER_EVENT_TIME_1();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new RD_BIVQHEADER_MESSAGE_ID_1[1];
					header.MESSAGE_ID[0] = new RD_BIVQHEADER_MESSAGE_ID_1();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new RD_BIVQHEADER_SEQUENCE_NUMBER_1[1];
					header.SEQUENCE_NUMBER[0] = new RD_BIVQHEADER_SEQUENCE_NUMBER_1();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new RD_BIVQHEADER_MESSAGE_VERSION_1[1];
					header.MESSAGE_VERSION[0] = new RD_BIVQHEADER_MESSAGE_VERSION_1();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new RD_BIVQHEADER_SOURCE_SYS_1[1];
					header.SOURCE_SYS[0] = new RD_BIVQHEADER_SOURCE_SYS_1();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new RD_BIVQHEADER_DESTINATION_SYS_1[1];
					header.DESTINATION_SYS[0] = new RD_BIVQHEADER_DESTINATION_SYS_1();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != "Null") {
					header.DISTRICT_NAME = new RD_BIVQHEADER_DISTRICT_NAME_1[1];
					header.DISTRICT_NAME[0] = new RD_BIVQHEADER_DISTRICT_NAME_1();
					header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new RD_BIVQHEADER_DISTRICT_SCAC_1[1];
					header.DISTRICT_SCAC[0] = new RD_BIVQHEADER_DISTRICT_SCAC_1();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != "Null") {
					header.USER_ID = new RD_BIVQHEADER_USER_ID_1[1];
					header.USER_ID[0] = new RD_BIVQHEADER_USER_ID_1();
					header.USER_ID[0].Value = HEADER.USER_ID;
				}

				if (HEADER.DIVISION_NAME != "Null") {
					header.DIVISION_NAME = new RD_BIVQHEADER_DIVISION_NAME_1[1];
					header.DIVISION_NAME[0] = new RD_BIVQHEADER_DIVISION_NAME_1();
					header.DIVISION_NAME[0].Value = HEADER.DIVISION_NAME;
				}

			}

			RD_BIVQCONTENT_1 content = new RD_BIVQCONTENT_1();
			if (this.CONTENT != null) {
				if (CONTENT.REQUEST_ID != null && CONTENT.REQUEST_ID != "") {
					content.REQUEST_ID = new RD_BIVQCONTENT_REQUEST_ID_1[1];
					content.REQUEST_ID[0] = new RD_BIVQCONTENT_REQUEST_ID_1();
					if (CONTENT.REQUEST_ID == "Empty") {
						content.REQUEST_ID[0].Value = "";
					} else {
						content.REQUEST_ID[0].Value = CONTENT.REQUEST_ID;
					}
				}

				if (CONTENT.PF_ADDRESSEE != null && CONTENT.PF_ADDRESSEE != "") {
					content.PF_ADDRESSEE = new RD_BIVQCONTENT_PF_ADDRESSEE_1[1];
					content.PF_ADDRESSEE[0] = new RD_BIVQCONTENT_PF_ADDRESSEE_1();
					if (CONTENT.PF_ADDRESSEE == "Empty") {
						content.PF_ADDRESSEE[0].Value = "";
					} else {
						content.PF_ADDRESSEE[0].Value = CONTENT.PF_ADDRESSEE;
					}
				}

				if (CONTENT.PF_ADDRESSEE_TYPE != null && CONTENT.PF_ADDRESSEE_TYPE != "") {
					content.PF_ADDRESSEE_TYPE = new RD_BIVQCONTENT_PF_ADDRESSEE_TYPE_1[1];
					content.PF_ADDRESSEE_TYPE[0] = new RD_BIVQCONTENT_PF_ADDRESSEE_TYPE_1();
					if (CONTENT.PF_ADDRESSEE_TYPE == "Empty") {
						content.PF_ADDRESSEE_TYPE[0].Value = "";
					} else {
						content.PF_ADDRESSEE_TYPE[0].Value = CONTENT.PF_ADDRESSEE_TYPE;
					}
				}

				if (CONTENT.REQUESTING_EMPLOYEE != "Null") {
					content.REQUESTING_EMPLOYEE = new RD_BIVQCONTENT_REQUESTING_EMPLOYEE_1[1];
					content.REQUESTING_EMPLOYEE[0] = new RD_BIVQCONTENT_REQUESTING_EMPLOYEE_1();
					content.REQUESTING_EMPLOYEE[0].Value = CONTENT.REQUESTING_EMPLOYEE;
				}

				if (CONTENT.REQUESTING_EMPLOYEE_NOTE != null && CONTENT.REQUESTING_EMPLOYEE_NOTE != "") {
					content.REQUESTING_EMPLOYEE_NOTE = new RD_BIVQCONTENT_REQUESTING_EMPLOYEE_NOTE_1[1];
					content.REQUESTING_EMPLOYEE_NOTE[0] = new RD_BIVQCONTENT_REQUESTING_EMPLOYEE_NOTE_1();
					if (CONTENT.REQUESTING_EMPLOYEE_NOTE == "Empty") {
						content.REQUESTING_EMPLOYEE_NOTE[0].Value = "";
					} else {
						content.REQUESTING_EMPLOYEE_NOTE[0].Value = CONTENT.REQUESTING_EMPLOYEE_NOTE;
					}
				}

				if (CONTENT.BULLETIN_ITEM_NUMBER != "Null") {
					content.BULLETIN_ITEM_NUMBER = new RD_BIVQCONTENT_BULLETIN_ITEM_NUMBER_1[1];
					content.BULLETIN_ITEM_NUMBER[0] = new RD_BIVQCONTENT_BULLETIN_ITEM_NUMBER_1();
					content.BULLETIN_ITEM_NUMBER[0].Value = CONTENT.BULLETIN_ITEM_NUMBER;
				}
				
				if (CONTENT.BULLETIN_ID != null && CONTENT.BULLETIN_ID != "") {
					content.BULLETIN_ID = new RD_BIVQCONTENT_BULLETIN_ID_1[1];
					content.BULLETIN_ID[0] = new RD_BIVQCONTENT_BULLETIN_ID_1();
					if (CONTENT.BULLETIN_ID == "Empty") {
						content.BULLETIN_ID[0].Value = "";
					} else {
						content.BULLETIN_ID[0].Value = CONTENT.BULLETIN_ID;
					}
				}

			}

			rd_bivq_1.Items[0] = header;
			rd_bivq_1.Items[1] = content;
			return rd_bivq_1;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|RD-BIVQ|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|RD-BIVQ|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class RUM_RD_BIVQHEADER_1 {
		public string EVENT_DATE = "";
		public string EVENT_TIME = "";
		public string MESSAGE_ID = "";
		public string SEQUENCE_NUMBER = "";
		public string MESSAGE_VERSION = "";
		public string SOURCE_SYS = "";
		public string DESTINATION_SYS = "";
		public string DISTRICT_NAME = "";
		public string DISTRICT_SCAC = "";
		public string USER_ID = "";
		public string DIVISION_NAME = "";
	}

	public partial class RUM_RD_BIVQCONTENT_1 {
		public string REQUEST_ID = "";
		public string PF_ADDRESSEE = "";
		public string PF_ADDRESSEE_TYPE = "";
		public string REQUESTING_EMPLOYEE = "";
		public string REQUESTING_EMPLOYEE_NOTE = "";
		public string BULLETIN_ITEM_NUMBER = "";
		public string BULLETIN_ID = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class RD_BIVQ_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(RD_BIVQHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(RD_BIVQCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQHEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQHEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_REQUEST_ID_1[] REQUEST_ID;

		[System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_PF_ADDRESSEE_1[] PF_ADDRESSEE;

		[System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_PF_ADDRESSEE_TYPE_1[] PF_ADDRESSEE_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("REQUESTING_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_REQUESTING_EMPLOYEE_1[] REQUESTING_EMPLOYEE;

		[System.Xml.Serialization.XmlElementAttribute("REQUESTING_EMPLOYEE_NOTE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_REQUESTING_EMPLOYEE_NOTE_1[] REQUESTING_EMPLOYEE_NOTE;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_BULLETIN_ITEM_NUMBER_1[] BULLETIN_ITEM_NUMBER;
		
		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_BIVQCONTENT_BULLETIN_ID_1[] BULLETIN_ID;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_REQUEST_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_PF_ADDRESSEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_PF_ADDRESSEE_TYPE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_REQUESTING_EMPLOYEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_REQUESTING_EMPLOYEE_NOTE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_BULLETIN_ITEM_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_BIVQCONTENT_BULLETIN_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}