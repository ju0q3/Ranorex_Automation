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
	public partial class RUM_RD_RTRR_1 {
		public RUM_RD_RTRRHEADER_1 HEADER;
		public RUM_RD_RTRRCONTENT_1 CONTENT;

		public static void createRD_RTRR_1(
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
			string content_track_authority_number,
			string content_track_authority_id,
			string content_rollup_location,
			string content_employee_first,
			string content_employee_middle,
			string content_employee_last,
			string content_spaf_ack,
			string content_ru_comments,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			RUM_RD_RTRR_1 rum_rd_rtrr = buildRUM_RD_RTRR_1(header_event_date, header_event_time, header_sequence_number, header_message_version, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_division_name, content_request_id, content_pf_addressee, content_pf_addressee_type, content_requesting_employee, content_track_authority_number, content_track_authority_id, content_rollup_location, content_employee_first, content_employee_middle, content_employee_last, content_spaf_ack, content_ru_comments);

			RD_RTRR_1 rd_rtrr = rum_rd_rtrr.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(RD_RTRR_1));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, rd_rtrr);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = rum_rd_rtrr.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = rum_rd_rtrr.toSteMessageHeader(request, true);
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

		public static RUM_RD_RTRR_1 buildRUM_RD_RTRR_1(
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
			string content_track_authority_number,
			string content_track_authority_id,
			string content_rollup_location,
			string content_employee_first,
			string content_employee_middle,
			string content_employee_last,
			string content_spaf_ack,
			string content_ru_comments
		) {

			RUM_RD_RTRR_1 rum_rd_rtrr = new RUM_RD_RTRR_1();

			RUM_RD_RTRRHEADER_1 header = new RUM_RD_RTRRHEADER_1();
			header.EVENT_DATE = header_event_date;
			header.EVENT_TIME = header_event_time;
			header.MESSAGE_ID = "RD-RTRR";
			header.SEQUENCE_NUMBER = header_sequence_number;
			header.MESSAGE_VERSION = header_message_version;
			header.SOURCE_SYS = header_source_sys;
			header.DESTINATION_SYS = header_destination_sys;
			header.DISTRICT_NAME = header_district_name;
			header.DISTRICT_SCAC = header_district_scac;
			header.USER_ID = header_user_id;
			header.DIVISION_NAME = header_division_name;

			RUM_RD_RTRRCONTENT_1 content = new RUM_RD_RTRRCONTENT_1();
			content.REQUEST_ID = content_request_id;
			content.PF_ADDRESSEE = content_pf_addressee;
			content.PF_ADDRESSEE_TYPE = content_pf_addressee_type;
			content.REQUESTING_EMPLOYEE = content_requesting_employee;
			content.TRACK_AUTHORITY_NUMBER = content_track_authority_number;
			content.TRACK_AUTHORITY_ID = content_track_authority_id;
			content.ROLLUP_LOCATION = content_rollup_location;
			content.EMPLOYEE_FIRST = content_employee_first;
			content.EMPLOYEE_MIDDLE = content_employee_middle;
			content.EMPLOYEE_LAST = content_employee_last;
			content.SPAF_ACK = content_spaf_ack;
			content.RU_COMMENTS = content_ru_comments;

			rum_rd_rtrr.HEADER = header;
			rum_rd_rtrr.CONTENT = content;
			return rum_rd_rtrr;
		}

		public RD_RTRR_1 toSerializableObject() {
			RD_RTRR_1 rd_rtrr_1 = new RD_RTRR_1();
			rd_rtrr_1.Items = new object[2];

			RD_RTRRHEADER_1 header = new RD_RTRRHEADER_1();
			if (this.HEADER != null) {
				if (HEADER.EVENT_DATE != "Null") {
					header.EVENT_DATE = new RD_RTRRHEADER_EVENT_DATE_1[1];
					header.EVENT_DATE[0] = new RD_RTRRHEADER_EVENT_DATE_1();
					header.EVENT_DATE[0].Value = HEADER.EVENT_DATE;
				}

				if (HEADER.EVENT_TIME != "Null") {
					header.EVENT_TIME = new RD_RTRRHEADER_EVENT_TIME_1[1];
					header.EVENT_TIME[0] = new RD_RTRRHEADER_EVENT_TIME_1();
					header.EVENT_TIME[0].Value = HEADER.EVENT_TIME;
				}

				if (HEADER.MESSAGE_ID != "Null") {
					header.MESSAGE_ID = new RD_RTRRHEADER_MESSAGE_ID_1[1];
					header.MESSAGE_ID[0] = new RD_RTRRHEADER_MESSAGE_ID_1();
					header.MESSAGE_ID[0].Value = HEADER.MESSAGE_ID;
				}

				if (HEADER.SEQUENCE_NUMBER != "Null") {
					header.SEQUENCE_NUMBER = new RD_RTRRHEADER_SEQUENCE_NUMBER_1[1];
					header.SEQUENCE_NUMBER[0] = new RD_RTRRHEADER_SEQUENCE_NUMBER_1();
					header.SEQUENCE_NUMBER[0].Value = HEADER.SEQUENCE_NUMBER;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new RD_RTRRHEADER_MESSAGE_VERSION_1[1];
					header.MESSAGE_VERSION[0] = new RD_RTRRHEADER_MESSAGE_VERSION_1();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

				if (HEADER.SOURCE_SYS != "Null") {
					header.SOURCE_SYS = new RD_RTRRHEADER_SOURCE_SYS_1[1];
					header.SOURCE_SYS[0] = new RD_RTRRHEADER_SOURCE_SYS_1();
					header.SOURCE_SYS[0].Value = HEADER.SOURCE_SYS;
				}

				if (HEADER.DESTINATION_SYS != "Null") {
					header.DESTINATION_SYS = new RD_RTRRHEADER_DESTINATION_SYS_1[1];
					header.DESTINATION_SYS[0] = new RD_RTRRHEADER_DESTINATION_SYS_1();
					header.DESTINATION_SYS[0].Value = HEADER.DESTINATION_SYS;
				}

				if (HEADER.DISTRICT_NAME != "Null") {
					header.DISTRICT_NAME = new RD_RTRRHEADER_DISTRICT_NAME_1[1];
					header.DISTRICT_NAME[0] = new RD_RTRRHEADER_DISTRICT_NAME_1();
					header.DISTRICT_NAME[0].Value = HEADER.DISTRICT_NAME;
				}

				if (HEADER.DISTRICT_SCAC != null && HEADER.DISTRICT_SCAC != "") {
					header.DISTRICT_SCAC = new RD_RTRRHEADER_DISTRICT_SCAC_1[1];
					header.DISTRICT_SCAC[0] = new RD_RTRRHEADER_DISTRICT_SCAC_1();
					if (HEADER.DISTRICT_SCAC == "Empty") {
						header.DISTRICT_SCAC[0].Value = "";
					} else {
						header.DISTRICT_SCAC[0].Value = HEADER.DISTRICT_SCAC;
					}
				}

				if (HEADER.USER_ID != "Null") {
					header.USER_ID = new RD_RTRRHEADER_USER_ID_1[1];
					header.USER_ID[0] = new RD_RTRRHEADER_USER_ID_1();
					header.USER_ID[0].Value = HEADER.USER_ID;
				}

				if (HEADER.DIVISION_NAME != "Null") {
					header.DIVISION_NAME = new RD_RTRRHEADER_DIVISION_NAME_1[1];
					header.DIVISION_NAME[0] = new RD_RTRRHEADER_DIVISION_NAME_1();
					header.DIVISION_NAME[0].Value = HEADER.DIVISION_NAME;
				}

			}

			RD_RTRRCONTENT_1 content = new RD_RTRRCONTENT_1();
			if (this.CONTENT != null) {
				if (CONTENT.REQUEST_ID != null && CONTENT.REQUEST_ID != "") {
					content.REQUEST_ID = new RD_RTRRCONTENT_REQUEST_ID_1[1];
					content.REQUEST_ID[0] = new RD_RTRRCONTENT_REQUEST_ID_1();
					if (CONTENT.REQUEST_ID == "Empty") {
						content.REQUEST_ID[0].Value = "";
					} else {
						content.REQUEST_ID[0].Value = CONTENT.REQUEST_ID;
					}
				}

				if (CONTENT.PF_ADDRESSEE != null && CONTENT.PF_ADDRESSEE != "") {
					content.PF_ADDRESSEE = new RD_RTRRCONTENT_PF_ADDRESSEE_1[1];
					content.PF_ADDRESSEE[0] = new RD_RTRRCONTENT_PF_ADDRESSEE_1();
					if (CONTENT.PF_ADDRESSEE == "Empty") {
						content.PF_ADDRESSEE[0].Value = "";
					} else {
						content.PF_ADDRESSEE[0].Value = CONTENT.PF_ADDRESSEE;
					}
				}

				if (CONTENT.PF_ADDRESSEE_TYPE != null && CONTENT.PF_ADDRESSEE_TYPE != "") {
					content.PF_ADDRESSEE_TYPE = new RD_RTRRCONTENT_PF_ADDRESSEE_TYPE_1[1];
					content.PF_ADDRESSEE_TYPE[0] = new RD_RTRRCONTENT_PF_ADDRESSEE_TYPE_1();
					if (CONTENT.PF_ADDRESSEE_TYPE == "Empty") {
						content.PF_ADDRESSEE_TYPE[0].Value = "";
					} else {
						content.PF_ADDRESSEE_TYPE[0].Value = CONTENT.PF_ADDRESSEE_TYPE;
					}
				}

				if (CONTENT.REQUESTING_EMPLOYEE != "Null") {
					content.REQUESTING_EMPLOYEE = new RD_RTRRCONTENT_REQUESTING_EMPLOYEE_1[1];
					content.REQUESTING_EMPLOYEE[0] = new RD_RTRRCONTENT_REQUESTING_EMPLOYEE_1();
					content.REQUESTING_EMPLOYEE[0].Value = CONTENT.REQUESTING_EMPLOYEE;
				}

				if (CONTENT.TRACK_AUTHORITY_NUMBER != "Null") {
					content.TRACK_AUTHORITY_NUMBER = new RD_RTRRCONTENT_TRACK_AUTHORITY_NUMBER_1[1];
					content.TRACK_AUTHORITY_NUMBER[0] = new RD_RTRRCONTENT_TRACK_AUTHORITY_NUMBER_1();
					content.TRACK_AUTHORITY_NUMBER[0].Value = CONTENT.TRACK_AUTHORITY_NUMBER;
				}
				
				if (CONTENT.TRACK_AUTHORITY_ID != "Null") {
					content.TRACK_AUTHORITY_ID = new RD_RTRRCONTENT_TRACK_AUTHORITY_ID_1[1];
					content.TRACK_AUTHORITY_ID[0] = new RD_RTRRCONTENT_TRACK_AUTHORITY_ID_1();
					content.TRACK_AUTHORITY_ID[0].Value = CONTENT.TRACK_AUTHORITY_ID;
				}

				if (CONTENT.ROLLUP_LOCATION != "Null") {
					content.ROLLUP_LOCATION = new RD_RTRRCONTENT_ROLLUP_LOCATION_1[1];
					content.ROLLUP_LOCATION[0] = new RD_RTRRCONTENT_ROLLUP_LOCATION_1();
					content.ROLLUP_LOCATION[0].Value = CONTENT.ROLLUP_LOCATION;
				}

				if (CONTENT.EMPLOYEE_FIRST != "Null") {
					content.EMPLOYEE_FIRST = new RD_RTRRCONTENT_EMPLOYEE_FIRST_1[1];
					content.EMPLOYEE_FIRST[0] = new RD_RTRRCONTENT_EMPLOYEE_FIRST_1();
					content.EMPLOYEE_FIRST[0].Value = CONTENT.EMPLOYEE_FIRST;
				}

				if (CONTENT.EMPLOYEE_MIDDLE != null && CONTENT.EMPLOYEE_MIDDLE != "") {
					content.EMPLOYEE_MIDDLE = new RD_RTRRCONTENT_EMPLOYEE_MIDDLE_1[1];
					content.EMPLOYEE_MIDDLE[0] = new RD_RTRRCONTENT_EMPLOYEE_MIDDLE_1();
					if (CONTENT.EMPLOYEE_MIDDLE == "Empty") {
						content.EMPLOYEE_MIDDLE[0].Value = "";
					} else {
						content.EMPLOYEE_MIDDLE[0].Value = CONTENT.EMPLOYEE_MIDDLE;
					}
				}

				if (CONTENT.EMPLOYEE_LAST != "Null") {
					content.EMPLOYEE_LAST = new RD_RTRRCONTENT_EMPLOYEE_LAST_1[1];
					content.EMPLOYEE_LAST[0] = new RD_RTRRCONTENT_EMPLOYEE_LAST_1();
					content.EMPLOYEE_LAST[0].Value = CONTENT.EMPLOYEE_LAST;
				}

				if (CONTENT.SPAF_ACK != null && CONTENT.SPAF_ACK != "") {
					content.SPAF_ACK = new RD_RTRRCONTENT_SPAF_ACK_1[1];
					content.SPAF_ACK[0] = new RD_RTRRCONTENT_SPAF_ACK_1();
					if (CONTENT.SPAF_ACK == "Empty") {
						content.SPAF_ACK[0].Value = "";
					} else {
						content.SPAF_ACK[0].Value = CONTENT.SPAF_ACK;
					}
				}

				if (CONTENT.RU_COMMENTS != null && CONTENT.RU_COMMENTS != "") {
					content.RU_COMMENTS = new RD_RTRRCONTENT_RU_COMMENTS_1[1];
					content.RU_COMMENTS[0] = new RD_RTRRCONTENT_RU_COMMENTS_1();
					if (CONTENT.RU_COMMENTS == "Empty") {
						content.RU_COMMENTS[0].Value = "";
					} else {
						content.RU_COMMENTS[0].Value = CONTENT.RU_COMMENTS;
					}
				}

			}

			rd_rtrr_1.Items[0] = header;
			rd_rtrr_1.Items[1] = content;
			return rd_rtrr_1;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRUOTC|RD-RTRR|";
			} else {
				preScript = "RanorexAgent:PASSTHRUOTC|RD-RTRR|";
			}

			string result = preScript + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class RUM_RD_RTRRHEADER_1 {
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

	public partial class RUM_RD_RTRRCONTENT_1 {
		public string REQUEST_ID = "";
		public string PF_ADDRESSEE = "";
		public string PF_ADDRESSEE_TYPE = "";
		public string REQUESTING_EMPLOYEE = "";
		public string TRACK_AUTHORITY_NUMBER = "";
		public string TRACK_AUTHORITY_ID = "";
		public string ROLLUP_LOCATION = "";
		public string EMPLOYEE_FIRST = "";
		public string EMPLOYEE_MIDDLE = "";
		public string EMPLOYEE_LAST = "";
		public string SPAF_ACK = "";
		public string RU_COMMENTS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class RD_RTRR_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(RD_RTRRHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(RD_RTRRCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRHEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRHEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_REQUEST_ID_1[] REQUEST_ID;

		[System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_PF_ADDRESSEE_1[] PF_ADDRESSEE;

		[System.Xml.Serialization.XmlElementAttribute("PF_ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_PF_ADDRESSEE_TYPE_1[] PF_ADDRESSEE_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("REQUESTING_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_REQUESTING_EMPLOYEE_1[] REQUESTING_EMPLOYEE;

		[System.Xml.Serialization.XmlElementAttribute("TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_TRACK_AUTHORITY_NUMBER_1[] TRACK_AUTHORITY_NUMBER;
		
		[System.Xml.Serialization.XmlElementAttribute("TRACK_AUTHORITY_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_TRACK_AUTHORITY_ID_1[] TRACK_AUTHORITY_ID;
		
		[System.Xml.Serialization.XmlElementAttribute("ROLLUP_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_ROLLUP_LOCATION_1[] ROLLUP_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_FIRST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_EMPLOYEE_FIRST_1[] EMPLOYEE_FIRST;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_MIDDLE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_EMPLOYEE_MIDDLE_1[] EMPLOYEE_MIDDLE;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_LAST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_EMPLOYEE_LAST_1[] EMPLOYEE_LAST;

		[System.Xml.Serialization.XmlElementAttribute("SPAF_ACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_SPAF_ACK_1[] SPAF_ACK;

		[System.Xml.Serialization.XmlElementAttribute("RU_COMMENTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public RD_RTRRCONTENT_RU_COMMENTS_1[] RU_COMMENTS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_REQUEST_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_PF_ADDRESSEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_PF_ADDRESSEE_TYPE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_REQUESTING_EMPLOYEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_TRACK_AUTHORITY_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_TRACK_AUTHORITY_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_ROLLUP_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_EMPLOYEE_FIRST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_EMPLOYEE_MIDDLE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_EMPLOYEE_LAST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_SPAF_ACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class RD_RTRRCONTENT_RU_COMMENTS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}