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
	public partial class MIS_NS_TrainSegment_48 {
		public MIS_NS_TrainSegmentHEADER_48 HEADER;
		public MIS_NS_TrainSegmentCONTENT_48 CONTENT;

		public static MIS_NS_TrainSegment_48 fromSerializableObject(NS_TrainSegment_48 message) {
			MIS_NS_TrainSegment_48 ns_trainsegment_48 = new MIS_NS_TrainSegment_48();
			NS_TrainSegmentHEADER_48 header = null;
			NS_TrainSegmentCONTENT_48 content = null;
			header = (NS_TrainSegmentHEADER_48) message.Items[0];
			content = (NS_TrainSegmentCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_TrainSegmentHEADER_48 messageheader = new MIS_NS_TrainSegmentHEADER_48();

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
				} else {
					Ranorex.Report.Failure("Field TRACE_ID is a Mandatory field but was found to be missing from the message");
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
				} else {
					Ranorex.Report.Failure("Field MESSAGE_VERSION is a Mandatory field but was found to be missing from the message");
				}

				ns_trainsegment_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_TrainSegmentCONTENT_48 messagecontent = new MIS_NS_TrainSegmentCONTENT_48();

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

				if (content.EFFECTIVE_LOCATION != null) {
					messagecontent.EFFECTIVE_LOCATION = content.EFFECTIVE_LOCATION[0].Value;
					if (messagecontent.EFFECTIVE_LOCATION != null) {
						if (messagecontent.EFFECTIVE_LOCATION.Length < 1 || messagecontent.EFFECTIVE_LOCATION.Length > 6) {
							Ranorex.Report.Failure("Field EFFECTIVE_LOCATION expected to be length between or equal to 1 and 6, has length of {" + messagecontent.EFFECTIVE_LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EFFECTIVE_LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.EFFECTIVE_PASS_COUNT != null) {
					messagecontent.EFFECTIVE_PASS_COUNT = content.EFFECTIVE_PASS_COUNT[0].Value;
					if (messagecontent.EFFECTIVE_PASS_COUNT != null) {
						if (messagecontent.EFFECTIVE_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field EFFECTIVE_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.EFFECTIVE_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EFFECTIVE_PASS_COUNT)) {
							Ranorex.Report.Failure("Field EFFECTIVE_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.EFFECTIVE_PASS_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EFFECTIVE_PASS_COUNT is a Mandatory field but was found to be missing from the message");
				}

				if (content.DATE != null) {
					messagecontent.DATE = content.DATE[0].Value;
					if (messagecontent.DATE != null) {
						if (messagecontent.DATE.Length < 0 || messagecontent.DATE.Length > 8) {
							Ranorex.Report.Failure("Field DATE expected to be length between or equal to 0 and 8, has length of {" + messagecontent.DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.DATE)) {
							Ranorex.Report.Failure("Field DATE expected to be Numeric, has value of {" + messagecontent.DATE + "}.");
						}
					}
				}

				if (content.TIME != null) {
					messagecontent.TIME = content.TIME[0].Value;
					if (messagecontent.TIME != null) {
						if (messagecontent.TIME.Length != 4) {
							Ranorex.Report.Failure("Field TIME expected to be length of 4, has length of {" + messagecontent.TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TIME)) {
							Ranorex.Report.Failure("Field TIME expected to be Numeric, has value of {" + messagecontent.TIME + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TIME is a Mandatory field but was found to be missing from the message");
				}

				if (content.TIME_ZONE != null) {
					messagecontent.TIME_ZONE = content.TIME_ZONE[0].Value;
					if (messagecontent.TIME_ZONE != null) {
						if (messagecontent.TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field TIME_ZONE expected to be length of 1, has length of {" + messagecontent.TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.TIME_ZONE)) {
							Ranorex.Report.Failure("Field TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.TIME_ZONE + "}.");
						}
						if (messagecontent.TIME_ZONE != "E" && messagecontent.TIME_ZONE != "C") {
							Ranorex.Report.Failure("Field TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + messagecontent.TIME_ZONE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TIME_ZONE is a Mandatory field but was found to be missing from the message");
				}

				if (content.TIME_TYPE != null) {
					messagecontent.TIME_TYPE = content.TIME_TYPE[0].Value;
					if (messagecontent.TIME_TYPE != null) {
						if (messagecontent.TIME_TYPE.Length != 1) {
							Ranorex.Report.Failure("Field TIME_TYPE expected to be length of 1, has length of {" + messagecontent.TIME_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.TIME_TYPE)) {
							Ranorex.Report.Failure("Field TIME_TYPE expected to be Alphabetic, has value of {" + messagecontent.TIME_TYPE + "}.");
						}
						if (messagecontent.TIME_TYPE != "P" && messagecontent.TIME_TYPE != "O" && messagecontent.TIME_TYPE != "C" && messagecontent.TIME_TYPE != "S" && messagecontent.TIME_TYPE != "D") {
							Ranorex.Report.Failure("Field TIME_TYPE expected to be one of the following values {P, O, C, S, D}, but was found to be {" + messagecontent.TIME_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TIME_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.TRAIN_ORIGIN != null) {
					messagecontent.TRAIN_ORIGIN = content.TRAIN_ORIGIN[0].Value;
					if (messagecontent.TRAIN_ORIGIN != null) {
						if (messagecontent.TRAIN_ORIGIN.Length < 0 || messagecontent.TRAIN_ORIGIN.Length > 6) {
							Ranorex.Report.Failure("Field TRAIN_ORIGIN expected to be length between or equal to 0 and 6, has length of {" + messagecontent.TRAIN_ORIGIN.Length.ToString() + "}.");
						}
					}
				}

				if (content.TRAIN_DESTINATION != null) {
					messagecontent.TRAIN_DESTINATION = content.TRAIN_DESTINATION[0].Value;
					if (messagecontent.TRAIN_DESTINATION != null) {
						if (messagecontent.TRAIN_DESTINATION.Length < 0 || messagecontent.TRAIN_DESTINATION.Length > 6) {
							Ranorex.Report.Failure("Field TRAIN_DESTINATION expected to be length between or equal to 0 and 6, has length of {" + messagecontent.TRAIN_DESTINATION.Length.ToString() + "}.");
						}
					}
				}

				ns_trainsegment_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_trainsegment_48;
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

		public static void createNS_TrainSegment_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_effective_location,
			string content_effective_pass_count,
			string content_date,
			string content_time,
			string content_time_zone,
			string content_time_type,
			string content_train_origin,
			string content_train_destination,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainSegment_48 mis_ns_trainsegment = buildMIS_NS_TrainSegment_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_effective_location, content_effective_pass_count, content_date, content_time, content_time_zone, content_time_type, content_train_origin, content_train_destination);

			NS_TrainSegment_48 ns_trainsegment = mis_ns_trainsegment.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainSegment_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_trainsegment);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainsegment.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainsegment.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainSegment_48 buildMIS_NS_TrainSegment_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_effective_location,
			string content_effective_pass_count,
			string content_date,
			string content_time,
			string content_time_zone,
			string content_time_type,
			string content_train_origin,
			string content_train_destination
		) {

			MIS_NS_TrainSegment_48 mis_ns_trainsegment = new MIS_NS_TrainSegment_48();

			MIS_NS_TrainSegmentHEADER_48 header = new MIS_NS_TrainSegmentHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainSegmentCONTENT_48 content = new MIS_NS_TrainSegmentCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.EFFECTIVE_LOCATION = content_effective_location;
			content.EFFECTIVE_PASS_COUNT = content_effective_pass_count;
			content.DATE = content_date;
			content.TIME = content_time;
			content.TIME_ZONE = content_time_zone;
			content.TIME_TYPE = content_time_type;
			content.TRAIN_ORIGIN = content_train_origin;
			content.TRAIN_DESTINATION = content_train_destination;

			mis_ns_trainsegment.HEADER = header;
			mis_ns_trainsegment.CONTENT = content;
			return mis_ns_trainsegment;
		}

		public NS_TrainSegment_48 toSerializableObject() {
			NS_TrainSegment_48 ns_trainsegment_48 = new NS_TrainSegment_48();
			ns_trainsegment_48.Items = new object[2];

			NS_TrainSegmentHEADER_48 header = new NS_TrainSegmentHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainSegmentHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_TrainSegmentHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainSegmentHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_TrainSegmentHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != "Null") {
					header.TRACE_ID = new NS_TrainSegmentHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_TrainSegmentHEADER_TRACE_ID_48();
					header.TRACE_ID[0].Value = HEADER.TRACE_ID;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new NS_TrainSegmentHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_TrainSegmentHEADER_MESSAGE_VERSION_48();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

			}

			NS_TrainSegmentCONTENT_48 content = new NS_TrainSegmentCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_TrainSegmentCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_TrainSegmentCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_TrainSegmentCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_TrainSegmentCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_TrainSegmentCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_TrainSegmentCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_TrainSegmentCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_TrainSegmentCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.EFFECTIVE_LOCATION != "Null") {
					content.EFFECTIVE_LOCATION = new NS_TrainSegmentCONTENT_EFFECTIVE_LOCATION_48[1];
					content.EFFECTIVE_LOCATION[0] = new NS_TrainSegmentCONTENT_EFFECTIVE_LOCATION_48();
					content.EFFECTIVE_LOCATION[0].Value = CONTENT.EFFECTIVE_LOCATION;
				}

				if (CONTENT.EFFECTIVE_PASS_COUNT != "Null") {
					content.EFFECTIVE_PASS_COUNT = new NS_TrainSegmentCONTENT_EFFECTIVE_PASS_COUNT_48[1];
					content.EFFECTIVE_PASS_COUNT[0] = new NS_TrainSegmentCONTENT_EFFECTIVE_PASS_COUNT_48();
					content.EFFECTIVE_PASS_COUNT[0].Value = CONTENT.EFFECTIVE_PASS_COUNT;
				}

				if (CONTENT.DATE != null && CONTENT.DATE != "") {
					content.DATE = new NS_TrainSegmentCONTENT_DATE_48[1];
					content.DATE[0] = new NS_TrainSegmentCONTENT_DATE_48();
					if (CONTENT.DATE == "Empty") {
						content.DATE[0].Value = "";
					} else {
						content.DATE[0].Value = CONTENT.DATE;
					}
				}

				if (CONTENT.TIME != "Null") {
					content.TIME = new NS_TrainSegmentCONTENT_TIME_48[1];
					content.TIME[0] = new NS_TrainSegmentCONTENT_TIME_48();
					content.TIME[0].Value = CONTENT.TIME;
				}

				if (CONTENT.TIME_ZONE != "Null") {
					content.TIME_ZONE = new NS_TrainSegmentCONTENT_TIME_ZONE_48[1];
					content.TIME_ZONE[0] = new NS_TrainSegmentCONTENT_TIME_ZONE_48();
					content.TIME_ZONE[0].Value = CONTENT.TIME_ZONE;
				}

				if (CONTENT.TIME_TYPE != "Null") {
					content.TIME_TYPE = new NS_TrainSegmentCONTENT_TIME_TYPE_48[1];
					content.TIME_TYPE[0] = new NS_TrainSegmentCONTENT_TIME_TYPE_48();
					content.TIME_TYPE[0].Value = CONTENT.TIME_TYPE;
				}

				if (CONTENT.TRAIN_ORIGIN != null && CONTENT.TRAIN_ORIGIN != "") {
					content.TRAIN_ORIGIN = new NS_TrainSegmentCONTENT_TRAIN_ORIGIN_48[1];
					content.TRAIN_ORIGIN[0] = new NS_TrainSegmentCONTENT_TRAIN_ORIGIN_48();
					if (CONTENT.TRAIN_ORIGIN == "Empty") {
						content.TRAIN_ORIGIN[0].Value = "";
					} else {
						content.TRAIN_ORIGIN[0].Value = CONTENT.TRAIN_ORIGIN;
					}
				}

				if (CONTENT.TRAIN_DESTINATION != null && CONTENT.TRAIN_DESTINATION != "") {
					content.TRAIN_DESTINATION = new NS_TrainSegmentCONTENT_TRAIN_DESTINATION_48[1];
					content.TRAIN_DESTINATION[0] = new NS_TrainSegmentCONTENT_TRAIN_DESTINATION_48();
					if (CONTENT.TRAIN_DESTINATION == "Empty") {
						content.TRAIN_DESTINATION[0].Value = "";
					} else {
						content.TRAIN_DESTINATION[0].Value = CONTENT.TRAIN_DESTINATION;
					}
				}

			}

			ns_trainsegment_48.Items[0] = header;
			ns_trainsegment_48.Items[1] = content;
			return ns_trainsegment_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNCRT,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNCRT,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainSegmentHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainSegmentCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string EFFECTIVE_LOCATION = "";
		public string EFFECTIVE_PASS_COUNT = "";
		public string DATE = "";
		public string TIME = "";
		public string TIME_ZONE = "";
		public string TIME_TYPE = "";
		public string TRAIN_ORIGIN = "";
		public string TRAIN_DESTINATION = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainSegment", IsNullable = false)]
	public partial class NS_TrainSegment_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainSegmentHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainSegmentCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_EFFECTIVE_LOCATION_48[] EFFECTIVE_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_EFFECTIVE_PASS_COUNT_48[] EFFECTIVE_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_DATE_48[] DATE;

		[System.Xml.Serialization.XmlElementAttribute("TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TIME_48[] TIME;

		[System.Xml.Serialization.XmlElementAttribute("TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TIME_ZONE_48[] TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("TIME_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TIME_TYPE_48[] TIME_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_ORIGIN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TRAIN_ORIGIN_48[] TRAIN_ORIGIN;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_DESTINATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainSegmentCONTENT_TRAIN_DESTINATION_48[] TRAIN_DESTINATION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_EFFECTIVE_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_EFFECTIVE_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TIME_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TRAIN_ORIGIN_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainSegmentCONTENT_TRAIN_DESTINATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}