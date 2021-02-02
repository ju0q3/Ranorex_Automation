using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;
using STE.Code_Utils.MessageQueues;

namespace STE.Code_Utils.messages.MIS.NS
{
	public partial class MIS_NS_EOTCaboose_48 {
		public MIS_NS_EOTCabooseHEADER_48 HEADER;
		public MIS_NS_EOTCabooseCONTENT_48 CONTENT;

		public static MIS_NS_EOTCaboose_48 fromSerializableObject(NS_EOTCaboose_48 message) {
			MIS_NS_EOTCaboose_48 ns_eotcaboose_48 = new MIS_NS_EOTCaboose_48();
			NS_EOTCabooseHEADER_48 header = null;
			NS_EOTCabooseCONTENT_48 content = null;
			header = (NS_EOTCabooseHEADER_48) message.Items[0];
			content = (NS_EOTCabooseCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_EOTCabooseHEADER_48 messageheader = new MIS_NS_EOTCabooseHEADER_48();

				if (header.PROTOCOLID != null) {
					messageheader.PROTOCOLID = header.PROTOCOLID[0].Value;
				} else {
					Ranorex.Report.Failure("Field PROTOCOLID is a Mandatory field but was found to be missing from the message");
				}

				if (header.MSGID != null) {
					messageheader.MSGID = header.MSGID[0].Value;
				} else {
					Ranorex.Report.Failure("Field MSGID is a Mandatory field but was found to be missing from the message");
				}

				if (header.TRACE_ID != null) {
					messageheader.TRACE_ID = header.TRACE_ID[0].Value;
				}

				if (header.MESSAGE_VERSION != null) {
					messageheader.MESSAGE_VERSION = header.MESSAGE_VERSION[0].Value;
					if (messageheader.MESSAGE_VERSION != null) {
						if (messageheader.MESSAGE_VERSION.Length < 1 || messageheader.MESSAGE_VERSION.Length > 4) {
							Ranorex.Report.Failure("Field MESSAGE_VERSION expected to be length between or equal to 1 and 4, has length of {" + messageheader.MESSAGE_VERSION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.MESSAGE_VERSION)) {
							Ranorex.Report.Failure("Field MESSAGE_VERSION expected to be Numeric, has value of {" + messageheader.MESSAGE_VERSION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messageheader.MESSAGE_VERSION);
							if (intConvertedValue < 0 || intConvertedValue > 9999) {
								Ranorex.Report.Failure("Field MESSAGE_VERSION expected to have value between 0 and 9999, but was found to have a value of " + messageheader.MESSAGE_VERSION + ".");
							}
						}
					}
				}

				ns_eotcaboose_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_EOTCabooseCONTENT_48 messagecontent = new MIS_NS_EOTCabooseCONTENT_48();

				if (content.SCAC != null) {
					messagecontent.SCAC = content.SCAC[0].Value;
					if (messagecontent.SCAC != null) {
						if (messagecontent.SCAC.Length < 1 || messagecontent.SCAC.Length > 4) {
							Ranorex.Report.Failure("Field SCAC expected to be length between or equal to 1 and 4, has length of {" + messagecontent.SCAC.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.SCAC)) {
							Ranorex.Report.Failure("Field SCAC expected to be Alphabetic, has value of {" + messagecontent.SCAC + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SCAC is a Mandatory field but was found to be missing from the message");
				}

				if (content.SECTION != null) {
					messagecontent.SECTION = content.SECTION[0].Value;
					if (messagecontent.SECTION != null) {
						if (messagecontent.SECTION.Length < 0 || messagecontent.SECTION.Length > 1) {
							Ranorex.Report.Failure("Field SECTION expected to be length between or equal to 0 and 1, has length of {" + messagecontent.SECTION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SECTION)) {
							Ranorex.Report.Failure("Field SECTION expected to be Numeric, has value of {" + messagecontent.SECTION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.SECTION);
							if (intConvertedValue < 1 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field SECTION expected to have value between 1 and 9, but was found to have a value of " + messagecontent.SECTION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field SECTION is a Mandatory field but was found to be missing from the message");
				}

				if (content.TRAIN_SYMBOL != null) {
					messagecontent.TRAIN_SYMBOL = content.TRAIN_SYMBOL[0].Value;
					if (messagecontent.TRAIN_SYMBOL != null) {
						if (messagecontent.TRAIN_SYMBOL.Length < 1 || messagecontent.TRAIN_SYMBOL.Length > 10) {
							Ranorex.Report.Failure("Field TRAIN_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + messagecontent.TRAIN_SYMBOL.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TRAIN_SYMBOL is a Mandatory field but was found to be missing from the message");
				}

				if (content.ORIGIN_DATE != null) {
					messagecontent.ORIGIN_DATE = content.ORIGIN_DATE[0].Value;
					if (messagecontent.ORIGIN_DATE != null) {
						if (messagecontent.ORIGIN_DATE.Length != 8) {
							Ranorex.Report.Failure("Field ORIGIN_DATE expected to be length of 8, has length of {" + messagecontent.ORIGIN_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ORIGIN_DATE)) {
							Ranorex.Report.Failure("Field ORIGIN_DATE expected to be Numeric, has value of {" + messagecontent.ORIGIN_DATE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field ORIGIN_DATE is a Mandatory field but was found to be missing from the message");
				}

				if (content.EQUIPMENT_CODE != null) {
					messagecontent.EQUIPMENT_CODE = content.EQUIPMENT_CODE[0].Value;
					if (messagecontent.EQUIPMENT_CODE != null) {
						if (messagecontent.EQUIPMENT_CODE.Length != 1) {
							Ranorex.Report.Failure("Field EQUIPMENT_CODE expected to be length of 1, has length of {" + messagecontent.EQUIPMENT_CODE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.EQUIPMENT_CODE)) {
							Ranorex.Report.Failure("Field EQUIPMENT_CODE expected to be Alphabetic, has value of {" + messagecontent.EQUIPMENT_CODE + "}.");
						}
						if (messagecontent.EQUIPMENT_CODE != "C" && messagecontent.EQUIPMENT_CODE != "E") {
							Ranorex.Report.Failure("Field EQUIPMENT_CODE expected to be one of the following values {C, E}, but was found to be {" + messagecontent.EQUIPMENT_CODE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EQUIPMENT_CODE is a Mandatory field but was found to be missing from the message");
				}

				if (content.ORIGIN != null) {
					messagecontent.ORIGIN = content.ORIGIN[0].Value;
					if (messagecontent.ORIGIN != null) {
						if (messagecontent.ORIGIN.Length < 1 || messagecontent.ORIGIN.Length > 6) {
							Ranorex.Report.Failure("Field ORIGIN expected to be length between or equal to 1 and 6, has length of {" + messagecontent.ORIGIN.Length.ToString() + "}.");
						}
					}
				}

				if (content.DESTINATION != null) {
					messagecontent.DESTINATION = content.DESTINATION[0].Value;
					if (messagecontent.DESTINATION != null) {
						if (messagecontent.DESTINATION.Length < 1 || messagecontent.DESTINATION.Length > 6) {
							Ranorex.Report.Failure("Field DESTINATION expected to be length between or equal to 1 and 6, has length of {" + messagecontent.DESTINATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.INITIAL != null) {
					messagecontent.INITIAL = content.INITIAL[0].Value;
					if (messagecontent.INITIAL != null) {
						if (messagecontent.INITIAL.Length < 1 || messagecontent.INITIAL.Length > 4) {
							Ranorex.Report.Failure("Field INITIAL expected to be length between or equal to 1 and 4, has length of {" + messagecontent.INITIAL.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.INITIAL)) {
							Ranorex.Report.Failure("Field INITIAL expected to be Alphabetic, has value of {" + messagecontent.INITIAL + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field INITIAL is a Mandatory field but was found to be missing from the message");
				}

				if (content.NUMBER != null) {
					messagecontent.NUMBER = content.NUMBER[0].Value;
					if (messagecontent.NUMBER != null) {
						if (messagecontent.NUMBER.Length < 1 || messagecontent.NUMBER.Length > 6) {
							Ranorex.Report.Failure("Field NUMBER expected to be length between or equal to 1 and 6, has length of {" + messagecontent.NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER)) {
							Ranorex.Report.Failure("Field NUMBER expected to be Numeric, has value of {" + messagecontent.NUMBER + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.WORKING_STATUS != null) {
					messagecontent.WORKING_STATUS = content.WORKING_STATUS[0].Value;
					if (messagecontent.WORKING_STATUS != null) {
						if (messagecontent.WORKING_STATUS.Length != 1) {
							Ranorex.Report.Failure("Field WORKING_STATUS expected to be length of 1, has length of {" + messagecontent.WORKING_STATUS.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.WORKING_STATUS)) {
							Ranorex.Report.Failure("Field WORKING_STATUS expected to be Alphabetic, has value of {" + messagecontent.WORKING_STATUS + "}.");
						}
						if (messagecontent.WORKING_STATUS != "W" && messagecontent.WORKING_STATUS != "D") {
							Ranorex.Report.Failure("Field WORKING_STATUS expected to be one of the following values {W, D}, but was found to be {" + messagecontent.WORKING_STATUS + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field WORKING_STATUS is a Mandatory field but was found to be missing from the message");
				}

				ns_eotcaboose_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_eotcaboose_48;
		}

		public static bool IsDigitsOnly(string messageField){
			int output;
			return int.TryParse(messageField, out output);
		}

		public static bool ContainsDigits(string messageField) {
			foreach (char c in messageField) {
				if (char.IsDigit(c)) {
					return true;
				}
			}
			return false;
		}

		public static void createNS_EOTCaboose_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_equipment_code,
			string content_origin,
			string content_destination,
			string content_initial,
			string content_number,
			string content_working_status,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_EOTCaboose_48 mis_ns_eotcaboose = buildMIS_NS_EOTCaboose_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_equipment_code, content_origin, content_destination, content_initial, content_number, content_working_status);

			NS_EOTCaboose_48 ns_eotcaboose = mis_ns_eotcaboose.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_EOTCaboose_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_eotcaboose);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_eotcaboose.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_eotcaboose.toSteMessageHeader(request, true);
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

		public static MIS_NS_EOTCaboose_48 buildMIS_NS_EOTCaboose_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_equipment_code,
			string content_origin,
			string content_destination,
			string content_initial,
			string content_number,
			string content_working_status
		) {

			MIS_NS_EOTCaboose_48 mis_ns_eotcaboose = new MIS_NS_EOTCaboose_48();

			MIS_NS_EOTCabooseHEADER_48 header = new MIS_NS_EOTCabooseHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_EOTCabooseCONTENT_48 content = new MIS_NS_EOTCabooseCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.EQUIPMENT_CODE = content_equipment_code;
			content.ORIGIN = content_origin;
			content.DESTINATION = content_destination;
			content.INITIAL = content_initial;
			content.NUMBER = content_number;
			content.WORKING_STATUS = content_working_status;

			mis_ns_eotcaboose.HEADER = header;
			mis_ns_eotcaboose.CONTENT = content;
			return mis_ns_eotcaboose;
		}

		public NS_EOTCaboose_48 toSerializableObject() {
			NS_EOTCaboose_48 ns_eotcaboose_48 = new NS_EOTCaboose_48();
			ns_eotcaboose_48.Items = new object[2];

			NS_EOTCabooseHEADER_48 header = new NS_EOTCabooseHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_EOTCabooseHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_EOTCabooseHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_EOTCabooseHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_EOTCabooseHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_EOTCabooseHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_EOTCabooseHEADER_TRACE_ID_48();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_EOTCabooseHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_EOTCabooseHEADER_MESSAGE_VERSION_48();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_EOTCabooseCONTENT_48 content = new NS_EOTCabooseCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_EOTCabooseCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_EOTCabooseCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_EOTCabooseCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_EOTCabooseCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_EOTCabooseCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_EOTCabooseCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_EOTCabooseCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_EOTCabooseCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.EQUIPMENT_CODE != "Null") {
					content.EQUIPMENT_CODE = new NS_EOTCabooseCONTENT_EQUIPMENT_CODE_48[1];
					content.EQUIPMENT_CODE[0] = new NS_EOTCabooseCONTENT_EQUIPMENT_CODE_48();
					content.EQUIPMENT_CODE[0].Value = CONTENT.EQUIPMENT_CODE;
				}

				if (CONTENT.ORIGIN != null && CONTENT.ORIGIN != "") {
					content.ORIGIN = new NS_EOTCabooseCONTENT_ORIGIN_48[1];
					content.ORIGIN[0] = new NS_EOTCabooseCONTENT_ORIGIN_48();
					if (CONTENT.ORIGIN == "Empty") {
						content.ORIGIN[0].Value = "";
					} else {
						content.ORIGIN[0].Value = CONTENT.ORIGIN;
					}
				}

				if (CONTENT.DESTINATION != null && CONTENT.DESTINATION != "") {
					content.DESTINATION = new NS_EOTCabooseCONTENT_DESTINATION_48[1];
					content.DESTINATION[0] = new NS_EOTCabooseCONTENT_DESTINATION_48();
					if (CONTENT.DESTINATION == "Empty") {
						content.DESTINATION[0].Value = "";
					} else {
						content.DESTINATION[0].Value = CONTENT.DESTINATION;
					}
				}

				if (CONTENT.INITIAL != "Null") {
					content.INITIAL = new NS_EOTCabooseCONTENT_INITIAL_48[1];
					content.INITIAL[0] = new NS_EOTCabooseCONTENT_INITIAL_48();
					content.INITIAL[0].Value = CONTENT.INITIAL;
				}

				if (CONTENT.NUMBER != "Null") {
					content.NUMBER = new NS_EOTCabooseCONTENT_NUMBER_48[1];
					content.NUMBER[0] = new NS_EOTCabooseCONTENT_NUMBER_48();
					content.NUMBER[0].Value = CONTENT.NUMBER;
				}

				if (CONTENT.WORKING_STATUS != "Null") {
					content.WORKING_STATUS = new NS_EOTCabooseCONTENT_WORKING_STATUS_48[1];
					content.WORKING_STATUS[0] = new NS_EOTCabooseCONTENT_WORKING_STATUS_48();
					content.WORKING_STATUS[0].Value = CONTENT.WORKING_STATUS;
				}

			}

			ns_eotcaboose_48.Items[0] = header;
			ns_eotcaboose_48.Items[1] = content;
			return ns_eotcaboose_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNEOT,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNEOT,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_EOTCabooseHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_EOTCabooseCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string EQUIPMENT_CODE = "";
		public string ORIGIN = "";
		public string DESTINATION = "";
		public string INITIAL = "";
		public string NUMBER = "";
		public string WORKING_STATUS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "EOTCaboose", IsNullable = false)]
	public partial class NS_EOTCaboose_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_EOTCabooseHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_EOTCabooseCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EQUIPMENT_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_EQUIPMENT_CODE_48[] EQUIPMENT_CODE;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_ORIGIN_48[] ORIGIN;

		[System.Xml.Serialization.XmlElementAttribute("DESTINATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_DESTINATION_48[] DESTINATION;

		[System.Xml.Serialization.XmlElementAttribute("INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_INITIAL_48[] INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_NUMBER_48[] NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("WORKING_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EOTCabooseCONTENT_WORKING_STATUS_48[] WORKING_STATUS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_EQUIPMENT_CODE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_ORIGIN_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_DESTINATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_INITIAL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EOTCabooseCONTENT_WORKING_STATUS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}