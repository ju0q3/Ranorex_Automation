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
using Oracle.Code_Utils;

namespace STE.Code_Utils.messages.MIS.NS
{
	public partial class MIS_NS_RemedyBulletin_48 {
		public MIS_NS_RemedyBulletinHEADER_48 HEADER;
		public MIS_NS_RemedyBulletinCONTENT_48 CONTENT;
		
		public static MIS_NS_RemedyBulletin_48 fromSerializableObject(NS_RemedyBulletin_48 message) {
			MIS_NS_RemedyBulletin_48 ns_remedybulletin_48 = new MIS_NS_RemedyBulletin_48();
			NS_RemedyBulletinHEADER_48 header = null;
			NS_RemedyBulletinCONTENT_48 content = null;
			header = (NS_RemedyBulletinHEADER_48) message.Items[0];
			content = (NS_RemedyBulletinCONTENT_48) message.Items[1];
			string remedyBulletinUniqueIdConfigValue = CDMSEnvironment.GetCommonConfigValue_CDMS("RST_REMEDY_UNIQUE_ID_CONFIG");
			
			
			if (header != null) {
				MIS_NS_RemedyBulletinHEADER_48 messageheader = new MIS_NS_RemedyBulletinHEADER_48();

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

				ns_remedybulletin_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_RemedyBulletinCONTENT_48 messagecontent = new MIS_NS_RemedyBulletinCONTENT_48();

				if (content.EVENT_DATE != null) {
					messagecontent.EVENT_DATE = content.EVENT_DATE[0].Value;
					if (messagecontent.EVENT_DATE != null) {
						if (messagecontent.EVENT_DATE.Length != 8) {
							Ranorex.Report.Failure("Field EVENT_DATE expected to be length of 8, has length of {" + messagecontent.EVENT_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EVENT_DATE)) {
							Ranorex.Report.Failure("Field EVENT_DATE expected to be Numeric, has value of {" + messagecontent.EVENT_DATE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EVENT_DATE is a Mandatory field but was found to be missing from the message");
				}

				if (content.EVENT_TIME != null) {
					messagecontent.EVENT_TIME = content.EVENT_TIME[0].Value;
					if (messagecontent.EVENT_TIME != null) {
						if (messagecontent.EVENT_TIME.Length != 6) {
							Ranorex.Report.Failure("Field EVENT_TIME expected to be length of 6, has length of {" + messagecontent.EVENT_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EVENT_TIME)) {
							Ranorex.Report.Failure("Field EVENT_TIME expected to be Numeric, has value of {" + messagecontent.EVENT_TIME + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EVENT_TIME is a Mandatory field but was found to be missing from the message");
				}

				if (content.SEQUENCE_NUMBER != null) {
					messagecontent.SEQUENCE_NUMBER = content.SEQUENCE_NUMBER[0].Value;
					if (messagecontent.SEQUENCE_NUMBER != null) {
						if (messagecontent.SEQUENCE_NUMBER.Length < 1 || messagecontent.SEQUENCE_NUMBER.Length > 13) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be length between or equal to 1 to 13, has length of {" + messagecontent.SEQUENCE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SEQUENCE_NUMBER)) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be Numeric, has value of {" + messagecontent.SEQUENCE_NUMBER + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SEQUENCE_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.DIVISION_NAME != null) {
					messagecontent.DIVISION_NAME = content.DIVISION_NAME[0].Value;
					if (messagecontent.DIVISION_NAME != null) {
						if (messagecontent.DIVISION_NAME.Length < 1 || messagecontent.DIVISION_NAME.Length > 25) {
							Ranorex.Report.Failure("Field DIVISION_NAME expected to be length between or equal to 1 and 25, has length of {" + messagecontent.DIVISION_NAME.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DIVISION_NAME is a Mandatory field but was found to be missing from the message");
				}

				if (content.DISTRICT_NAME != null) {
					messagecontent.DISTRICT_NAME = content.DISTRICT_NAME[0].Value;
					if (messagecontent.DISTRICT_NAME != null) {
						if (messagecontent.DISTRICT_NAME.Length < 1 || messagecontent.DISTRICT_NAME.Length > 25) {
							Ranorex.Report.Failure("Field DISTRICT_NAME expected to be length between or equal to 1 and 25, has length of {" + messagecontent.DISTRICT_NAME.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DISTRICT_NAME is a Mandatory field but was found to be missing from the message");
				}

				if (content.SOURCE != null) {
					messagecontent.SOURCE = content.SOURCE[0].Value;
					if (messagecontent.SOURCE != null) {
						if (messagecontent.SOURCE.Length < 1 || messagecontent.SOURCE.Length > 20) {
							Ranorex.Report.Failure("Field SOURCE expected to be length between or equal to 1 and 20, has length of {" + messagecontent.SOURCE.Length.ToString() + "}.");
						}
						if (messagecontent.SOURCE != "Remedy" && messagecontent.SOURCE != "UTCS") {
							Ranorex.Report.Failure("Field SOURCE expected to be one of the following values {Remedy, UTCS}, but was found to be {" + messagecontent.SOURCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SOURCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.SOURCE_ID != null) {
					messagecontent.SOURCE_ID = content.SOURCE_ID[0].Value;
					if (messagecontent.SOURCE_ID != null) {
						if (messagecontent.SOURCE_ID.Length < 1 || messagecontent.SOURCE_ID.Length > 13) {
							Ranorex.Report.Failure("Field SOURCE_ID expected to be length between or equal to 1 and 13, has length of {" + messagecontent.SOURCE_ID.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SOURCE_ID is a Mandatory field but was found to be missing from the message");
				}

				if (content.ACTION != null) {
					messagecontent.ACTION = content.ACTION[0].Value;
					if (messagecontent.ACTION != null) {
						if (messagecontent.ACTION.Length != 1) {
							Ranorex.Report.Failure("Field ACTION expected to be length of 1, has length of {" + messagecontent.ACTION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ACTION)) {
							Ranorex.Report.Failure("Field ACTION expected to be Numeric, has value of {" + messagecontent.ACTION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.ACTION);
							if (intConvertedValue < 1 || intConvertedValue > 6) {
								Ranorex.Report.Failure("Field ACTION expected to have value between 1 and 6, but was found to have a value of " + messagecontent.ACTION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ACTION is a Mandatory field but was found to be missing from the message");
				}

				if (content.COMMENTS != null) {
					messagecontent.COMMENTS = content.COMMENTS[0].Value;
					if (messagecontent.COMMENTS != null) {
						if (messagecontent.COMMENTS.Length < 0 || messagecontent.COMMENTS.Length > 100) {
							Ranorex.Report.Failure("Field COMMENTS expected to be length between or equal to 0 and 100, has length of {" + messagecontent.COMMENTS.Length.ToString() + "}.");
						}
					}
				}

				if (content.BULLETIN_ITEM_TYPE != null) {
					messagecontent.BULLETIN_ITEM_TYPE = content.BULLETIN_ITEM_TYPE[0].Value;
					if (messagecontent.BULLETIN_ITEM_TYPE != null) {
						if (messagecontent.BULLETIN_ITEM_TYPE.Length < 0 || messagecontent.BULLETIN_ITEM_TYPE.Length > 100) {
							Ranorex.Report.Failure("Field BULLETIN_ITEM_TYPE expected to be length between or equal to 0 and 100, has length of {" + messagecontent.BULLETIN_ITEM_TYPE.Length.ToString() + "}.");
						}
					}
				}

				if (content.EFFECTIVE_DATE != null) {
					messagecontent.EFFECTIVE_DATE = content.EFFECTIVE_DATE[0].Value;
					if (messagecontent.EFFECTIVE_DATE != null) {
						if (messagecontent.EFFECTIVE_DATE.Length != 8) {
							Ranorex.Report.Failure("Field EFFECTIVE_DATE expected to be length of 8, has length of {" + messagecontent.EFFECTIVE_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EFFECTIVE_DATE)) {
							Ranorex.Report.Failure("Field EFFECTIVE_DATE expected to be Numeric, has value of {" + messagecontent.EFFECTIVE_DATE + "}.");
						}
					}
				}

				if (content.EFFECTIVE_TIME != null) {
					messagecontent.EFFECTIVE_TIME = content.EFFECTIVE_TIME[0].Value;
					if (messagecontent.EFFECTIVE_TIME != null) {
						if (messagecontent.EFFECTIVE_TIME.Length != 4) {
							Ranorex.Report.Failure("Field EFFECTIVE_TIME expected to be length of 4, has length of {" + messagecontent.EFFECTIVE_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EFFECTIVE_TIME)) {
							Ranorex.Report.Failure("Field EFFECTIVE_TIME expected to be Numeric, has value of {" + messagecontent.EFFECTIVE_TIME + "}.");
						}
					}
				}

				if (content.EFFECTIVE_TIME_ZONE != null) {
					messagecontent.EFFECTIVE_TIME_ZONE = content.EFFECTIVE_TIME_ZONE[0].Value;
					if (messagecontent.EFFECTIVE_TIME_ZONE != null) {
						if (messagecontent.EFFECTIVE_TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field EFFECTIVE_TIME_ZONE expected to be length of 1, has length of {" + messagecontent.EFFECTIVE_TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.EFFECTIVE_TIME_ZONE)) {
							Ranorex.Report.Failure("Field EFFECTIVE_TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.EFFECTIVE_TIME_ZONE + "}.");
						}
						if (messagecontent.EFFECTIVE_TIME_ZONE != "E" && messagecontent.EFFECTIVE_TIME_ZONE != "C") {
							Ranorex.Report.Failure("Field EFFECTIVE_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + messagecontent.EFFECTIVE_TIME_ZONE + "}.");
						}
					}
				}

				if (content.BULLETIN_ITEM_NUMBER != null) {
					messagecontent.BULLETIN_ITEM_NUMBER = content.BULLETIN_ITEM_NUMBER[0].Value;
					if (messagecontent.BULLETIN_ITEM_NUMBER != null) {
						if (messagecontent.BULLETIN_ITEM_NUMBER.Length < 1 || messagecontent.BULLETIN_ITEM_NUMBER.Length > 5) {
							Ranorex.Report.Failure("Field BULLETIN_ITEM_NUMBER expected to be length between or equal to 1 and 5, has length of {" + messagecontent.BULLETIN_ITEM_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.BULLETIN_ITEM_NUMBER)) {
							Ranorex.Report.Failure("Field BULLETIN_ITEM_NUMBER expected to be Numeric, has value of {" + messagecontent.BULLETIN_ITEM_NUMBER + "}.");
						}
					}
				}
				if((remedyBulletinUniqueIdConfigValue == "1" || remedyBulletinUniqueIdConfigValue == "2") && messagecontent.ACTION != "4" )
				{
					if (content.BULLETIN_UNIQUE_ID != null) {
						messagecontent.BULLETIN_UNIQUE_ID = content.BULLETIN_UNIQUE_ID[0].Value;
						if (messagecontent.BULLETIN_UNIQUE_ID != null) {
							if (messagecontent.BULLETIN_UNIQUE_ID.Length < 18 || messagecontent.BULLETIN_UNIQUE_ID.Length > 38) {
								Ranorex.Report.Failure("Field BULLETIN_UNIQUE_ID expected to be length between or equal to 18 and 38, has length of {" + messagecontent.BULLETIN_UNIQUE_ID.Length.ToString() + "}.");
							}
							if (!IsDigitsOnly(messagecontent.BULLETIN_UNIQUE_ID)) {
								Ranorex.Report.Failure("Field BULLETIN_UNIQUE_ID expected to be Numeric, has value of {" + messagecontent.BULLETIN_UNIQUE_ID + "}.");
							}
						}
					} else {
						Ranorex.Report.Failure("Field BULLETIN_UNIQUE_ID is a Mandatory field but was found to be missing from the message");
					}
				}
				if (content.FIELD_COUNT != null) {
					messagecontent.FIELD_COUNT = content.FIELD_COUNT[0].Value;
					if (messagecontent.FIELD_COUNT != null) {
						if (messagecontent.FIELD_COUNT.Length < 1 || messagecontent.FIELD_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field FIELD_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.FIELD_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.FIELD_COUNT)) {
							Ranorex.Report.Failure("Field FIELD_COUNT expected to be Numeric, has value of {" + messagecontent.FIELD_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field FIELD_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.FIELD_RECORD != null) {
					for (int i = 0; i < content.FIELD_RECORD.Length; i++) {
						MIS_NS_RemedyBulletinFIELD_RECORD_48 field_record = new MIS_NS_RemedyBulletinFIELD_RECORD_48();

						if (content.FIELD_RECORD[i].FIELD_NUMBER != null) {
							field_record.FIELD_NUMBER = content.FIELD_RECORD[i].FIELD_NUMBER[0].Value;
							if (field_record.FIELD_NUMBER != null) {
								if (field_record.FIELD_NUMBER.Length < 1 || field_record.FIELD_NUMBER.Length > 2) {
									Ranorex.Report.Failure("Field FIELD_NUMBER expected to be length between or equal to 1 and 2, has length of {" + field_record.FIELD_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(field_record.FIELD_NUMBER)) {
									Ranorex.Report.Failure("Field FIELD_NUMBER expected to be Numeric, has value of {" + field_record.FIELD_NUMBER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field FIELD_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.FIELD_RECORD[i].FIELD_NAME != null) {
							field_record.FIELD_NAME = content.FIELD_RECORD[i].FIELD_NAME[0].Value;
							if (field_record.FIELD_NAME != null) {
								if (field_record.FIELD_NAME.Length < 1 || field_record.FIELD_NAME.Length > 100) {
									Ranorex.Report.Failure("Field FIELD_NAME expected to be length between or equal to 1 and 100, has length of {" + field_record.FIELD_NAME.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field FIELD_NAME is a Mandatory field but was found to be missing from the message");
						}

						if (content.FIELD_RECORD[i].FIELD_CONTENT != null) {
							field_record.FIELD_CONTENT = content.FIELD_RECORD[i].FIELD_CONTENT[0].Value;
							if (field_record.FIELD_CONTENT != null) {
								if (field_record.FIELD_CONTENT.Length < 1 || field_record.FIELD_CONTENT.Length > 999) {
									Ranorex.Report.Failure("Field FIELD_CONTENT expected to be length between or equal to 1 and 999, has length of {" + field_record.FIELD_CONTENT.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addFIELD_RECORD(field_record);
					}
				}

				ns_remedybulletin_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_remedybulletin_48;
		}

		public static bool IsDigitsOnly(string messageField){
			Int64 output;
			return Int64.TryParse(messageField, out output);
		}

		public static bool ContainsDigits(string messageField) {
			foreach (char c in messageField) {
				if (char.IsDigit(c)) {
					return true;
				}
			}
			return false;
		}

		public static void createNS_RemedyBulletin_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_event_date,
			string content_event_time,
			string content_sequence_number,
			string content_division_name,
			string content_district_name,
			string content_source,
			string content_source_id,
			string content_action,
			string content_comments,
			string content_bulletin_item_type,
			string content_effective_date,
			string content_effective_time,
			string content_effective_time_zone,
			string content_bulletin_item_number,
			string content_bulletin_unique_id,
			string content_field_count,
			string content_field_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_RemedyBulletin_48 mis_ns_remedybulletin = buildMIS_NS_RemedyBulletin_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_event_date, content_event_time, content_sequence_number, content_division_name, content_district_name, content_source, content_source_id, content_action, content_comments, content_bulletin_item_type, content_effective_date, content_effective_time, content_effective_time_zone, content_bulletin_item_number, content_bulletin_unique_id, content_field_count, content_field_record);

			NS_RemedyBulletin_48 ns_remedybulletin = mis_ns_remedybulletin.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_RemedyBulletin_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_remedybulletin);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_remedybulletin.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_remedybulletin.toSteMessageHeader(request, true);
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

		public static MIS_NS_RemedyBulletin_48 buildMIS_NS_RemedyBulletin_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_event_date,
			string content_event_time,
			string content_sequence_number,
			string content_division_name,
			string content_district_name,
			string content_source,
			string content_source_id,
			string content_action,
			string content_comments,
			string content_bulletin_item_type,
			string content_effective_date,
			string content_effective_time,
			string content_effective_time_zone,
			string content_bulletin_item_number,
			string content_bulletin_unique_id,
			string content_field_count,
			string content_field_record
		) {

			MIS_NS_RemedyBulletin_48 mis_ns_remedybulletin = new MIS_NS_RemedyBulletin_48();

			MIS_NS_RemedyBulletinHEADER_48 header = new MIS_NS_RemedyBulletinHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_RemedyBulletinCONTENT_48 content = new MIS_NS_RemedyBulletinCONTENT_48();
			content.EVENT_DATE = content_event_date;
			content.EVENT_TIME = content_event_time;
			content.SEQUENCE_NUMBER = content_sequence_number;
			content.DIVISION_NAME = content_division_name;
			content.DISTRICT_NAME = content_district_name;
			content.SOURCE = content_source;
			content.SOURCE_ID = content_source_id;
			content.ACTION = content_action;
			content.COMMENTS = content_comments;
			content.BULLETIN_ITEM_TYPE = content_bulletin_item_type;
			content.EFFECTIVE_DATE = content_effective_date;
			content.EFFECTIVE_TIME = content_effective_time;
			content.EFFECTIVE_TIME_ZONE = content_effective_time_zone;
			content.BULLETIN_ITEM_NUMBER = content_bulletin_item_number;
			content.BULLETIN_UNIQUE_ID = content_bulletin_unique_id;
			content.FIELD_COUNT = content_field_count;
			if (content_field_record != "") {
				string[] field_recordList = content_field_record.Split('|');
				for (int i = 0; i < field_recordList.Length;) {
					MIS_NS_RemedyBulletinFIELD_RECORD_48 field_records = new MIS_NS_RemedyBulletinFIELD_RECORD_48();
					field_records.FIELD_NUMBER = field_recordList[i];i++;
					field_records.FIELD_NAME = field_recordList[i];i++;
					field_records.FIELD_CONTENT = field_recordList[i];i++;
					content.addFIELD_RECORD(field_records);
				}
			}

			mis_ns_remedybulletin.HEADER = header;
			mis_ns_remedybulletin.CONTENT = content;
			return mis_ns_remedybulletin;
		}

		public NS_RemedyBulletin_48 toSerializableObject() {
			NS_RemedyBulletin_48 ns_remedybulletin_48 = new NS_RemedyBulletin_48();
			ns_remedybulletin_48.Items = new object[2];

			NS_RemedyBulletinHEADER_48 header = new NS_RemedyBulletinHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_RemedyBulletinHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_RemedyBulletinHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_RemedyBulletinHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_RemedyBulletinHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != "Null") {
					header.TRACE_ID = new NS_RemedyBulletinHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_RemedyBulletinHEADER_TRACE_ID_48();
					header.TRACE_ID[0].Value = HEADER.TRACE_ID;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new NS_RemedyBulletinHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_RemedyBulletinHEADER_MESSAGE_VERSION_48();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

			}

			NS_RemedyBulletinCONTENT_48 content = new NS_RemedyBulletinCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.EVENT_DATE != "Null") {
					content.EVENT_DATE = new NS_RemedyBulletinCONTENT_EVENT_DATE_48[1];
					content.EVENT_DATE[0] = new NS_RemedyBulletinCONTENT_EVENT_DATE_48();
					content.EVENT_DATE[0].Value = CONTENT.EVENT_DATE;
				}

				if (CONTENT.EVENT_TIME != "Null") {
					content.EVENT_TIME = new NS_RemedyBulletinCONTENT_EVENT_TIME_48[1];
					content.EVENT_TIME[0] = new NS_RemedyBulletinCONTENT_EVENT_TIME_48();
					content.EVENT_TIME[0].Value = CONTENT.EVENT_TIME;
				}

				if (CONTENT.SEQUENCE_NUMBER != "Null") {
					content.SEQUENCE_NUMBER = new NS_RemedyBulletinCONTENT_SEQUENCE_NUMBER_48[1];
					content.SEQUENCE_NUMBER[0] = new NS_RemedyBulletinCONTENT_SEQUENCE_NUMBER_48();
					content.SEQUENCE_NUMBER[0].Value = CONTENT.SEQUENCE_NUMBER;
				}

				if (CONTENT.DIVISION_NAME != "Null") {
					content.DIVISION_NAME = new NS_RemedyBulletinCONTENT_DIVISION_NAME_48[1];
					content.DIVISION_NAME[0] = new NS_RemedyBulletinCONTENT_DIVISION_NAME_48();
					content.DIVISION_NAME[0].Value = CONTENT.DIVISION_NAME;
				}

				if (CONTENT.DISTRICT_NAME != "Null") {
					content.DISTRICT_NAME = new NS_RemedyBulletinCONTENT_DISTRICT_NAME_48[1];
					content.DISTRICT_NAME[0] = new NS_RemedyBulletinCONTENT_DISTRICT_NAME_48();
					content.DISTRICT_NAME[0].Value = CONTENT.DISTRICT_NAME;
				}

				if (CONTENT.SOURCE != "Null") {
					content.SOURCE = new NS_RemedyBulletinCONTENT_SOURCE_48[1];
					content.SOURCE[0] = new NS_RemedyBulletinCONTENT_SOURCE_48();
					content.SOURCE[0].Value = CONTENT.SOURCE;
				}

				if (CONTENT.SOURCE_ID != "Null") {
					content.SOURCE_ID = new NS_RemedyBulletinCONTENT_SOURCE_ID_48[1];
					content.SOURCE_ID[0] = new NS_RemedyBulletinCONTENT_SOURCE_ID_48();
					content.SOURCE_ID[0].Value = CONTENT.SOURCE_ID;
				}

				if (CONTENT.ACTION != "Null") {
					content.ACTION = new NS_RemedyBulletinCONTENT_ACTION_48[1];
					content.ACTION[0] = new NS_RemedyBulletinCONTENT_ACTION_48();
					content.ACTION[0].Value = CONTENT.ACTION;
				}

				if (CONTENT.COMMENTS != null && CONTENT.COMMENTS != "") {
					content.COMMENTS = new NS_RemedyBulletinCONTENT_COMMENTS_48[1];
					content.COMMENTS[0] = new NS_RemedyBulletinCONTENT_COMMENTS_48();
					if (CONTENT.COMMENTS == "Empty") {
						content.COMMENTS[0].Value = "";
					} else {
						content.COMMENTS[0].Value = CONTENT.COMMENTS;
					}
				}

				if (CONTENT.BULLETIN_ITEM_TYPE != null && CONTENT.BULLETIN_ITEM_TYPE != "") {
					content.BULLETIN_ITEM_TYPE = new NS_RemedyBulletinCONTENT_BULLETIN_ITEM_TYPE_48[1];
					content.BULLETIN_ITEM_TYPE[0] = new NS_RemedyBulletinCONTENT_BULLETIN_ITEM_TYPE_48();
					if (CONTENT.BULLETIN_ITEM_TYPE == "Empty") {
						content.BULLETIN_ITEM_TYPE[0].Value = "";
					} else {
						content.BULLETIN_ITEM_TYPE[0].Value = CONTENT.BULLETIN_ITEM_TYPE;
					}
				}

				if (CONTENT.EFFECTIVE_DATE != null && CONTENT.EFFECTIVE_DATE != "") {
					content.EFFECTIVE_DATE = new NS_RemedyBulletinCONTENT_EFFECTIVE_DATE_48[1];
					content.EFFECTIVE_DATE[0] = new NS_RemedyBulletinCONTENT_EFFECTIVE_DATE_48();
					if (CONTENT.EFFECTIVE_DATE == "Empty") {
						content.EFFECTIVE_DATE[0].Value = "";
					} else {
						content.EFFECTIVE_DATE[0].Value = CONTENT.EFFECTIVE_DATE;
					}
				}

				if (CONTENT.EFFECTIVE_TIME != null && CONTENT.EFFECTIVE_TIME != "") {
					content.EFFECTIVE_TIME = new NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_48[1];
					content.EFFECTIVE_TIME[0] = new NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_48();
					if (CONTENT.EFFECTIVE_TIME == "Empty") {
						content.EFFECTIVE_TIME[0].Value = "";
					} else {
						content.EFFECTIVE_TIME[0].Value = CONTENT.EFFECTIVE_TIME;
					}
				}

				if (CONTENT.EFFECTIVE_TIME_ZONE != null && CONTENT.EFFECTIVE_TIME_ZONE != "") {
					content.EFFECTIVE_TIME_ZONE = new NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_ZONE_48[1];
					content.EFFECTIVE_TIME_ZONE[0] = new NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_ZONE_48();
					if (CONTENT.EFFECTIVE_TIME_ZONE == "Empty") {
						content.EFFECTIVE_TIME_ZONE[0].Value = "";
					} else {
						content.EFFECTIVE_TIME_ZONE[0].Value = CONTENT.EFFECTIVE_TIME_ZONE;
					}
				}

				if (CONTENT.BULLETIN_ITEM_NUMBER != null && CONTENT.BULLETIN_ITEM_NUMBER != "") {
					content.BULLETIN_ITEM_NUMBER = new NS_RemedyBulletinCONTENT_BULLETIN_ITEM_NUMBER_48[1];
					content.BULLETIN_ITEM_NUMBER[0] = new NS_RemedyBulletinCONTENT_BULLETIN_ITEM_NUMBER_48();
					if (CONTENT.BULLETIN_ITEM_NUMBER == "Empty") {
						content.BULLETIN_ITEM_NUMBER[0].Value = "";
					} else {
						content.BULLETIN_ITEM_NUMBER[0].Value = CONTENT.BULLETIN_ITEM_NUMBER;
					}
				}

				if (CONTENT.BULLETIN_UNIQUE_ID != "Null") {
					content.BULLETIN_UNIQUE_ID = new NS_RemedyBulletinCONTENT_BULLETIN_UNIQUE_ID_48[1];
					content.BULLETIN_UNIQUE_ID[0] = new NS_RemedyBulletinCONTENT_BULLETIN_UNIQUE_ID_48();
					content.BULLETIN_UNIQUE_ID[0].Value = CONTENT.BULLETIN_UNIQUE_ID;
				}

				if (CONTENT.FIELD_COUNT != "Null") {
					content.FIELD_COUNT = new NS_RemedyBulletinCONTENT_FIELD_COUNT_48[1];
					content.FIELD_COUNT[0] = new NS_RemedyBulletinCONTENT_FIELD_COUNT_48();
					content.FIELD_COUNT[0].Value = CONTENT.FIELD_COUNT;
				}

				if (CONTENT.FIELD_RECORD.Count != 0) {
					int field_recordIndex = 0;
					content.FIELD_RECORD = new NS_RemedyBulletinCONTENT_FIELD_RECORD_48[CONTENT.FIELD_RECORD.Count];
					foreach (MIS_NS_RemedyBulletinFIELD_RECORD_48 FIELD_RECORD in CONTENT.FIELD_RECORD) {
						NS_RemedyBulletinCONTENT_FIELD_RECORD_48 field_record = new NS_RemedyBulletinCONTENT_FIELD_RECORD_48();
						if (FIELD_RECORD.FIELD_NUMBER != "Null") {
							field_record.FIELD_NUMBER = new NS_RemedyBulletinFIELD_RECORD_FIELD_NUMBER_48[1];
							field_record.FIELD_NUMBER[0] = new NS_RemedyBulletinFIELD_RECORD_FIELD_NUMBER_48();
							field_record.FIELD_NUMBER[0].Value = FIELD_RECORD.FIELD_NUMBER;
						}

						if (FIELD_RECORD.FIELD_NAME != "Null") {
							field_record.FIELD_NAME = new NS_RemedyBulletinFIELD_RECORD_FIELD_NAME_48[1];
							field_record.FIELD_NAME[0] = new NS_RemedyBulletinFIELD_RECORD_FIELD_NAME_48();
							field_record.FIELD_NAME[0].Value = FIELD_RECORD.FIELD_NAME;
						}

						if (FIELD_RECORD.FIELD_CONTENT != null && FIELD_RECORD.FIELD_CONTENT != "") {
							field_record.FIELD_CONTENT = new NS_RemedyBulletinFIELD_RECORD_FIELD_CONTENT_48[1];
							field_record.FIELD_CONTENT[0] = new NS_RemedyBulletinFIELD_RECORD_FIELD_CONTENT_48();
							if (FIELD_RECORD.FIELD_CONTENT == "Empty") {
								field_record.FIELD_CONTENT[0].Value = "";
							} else {
								field_record.FIELD_CONTENT[0].Value = FIELD_RECORD.FIELD_CONTENT;
							}
						}

						content.FIELD_RECORD[field_recordIndex] = field_record;
						field_recordIndex++;
					}
				}

			}

			ns_remedybulletin_48.Items[0] = header;
			ns_remedybulletin_48.Items[1] = content;
			return ns_remedybulletin_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,RemedyBulletin,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,RemedyBulletin,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_RemedyBulletinHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_RemedyBulletinCONTENT_48 {
		public string EVENT_DATE = "";
		public string EVENT_TIME = "";
		public string SEQUENCE_NUMBER = "";
		public string DIVISION_NAME = "";
		public string DISTRICT_NAME = "";
		public string SOURCE = "";
		public string SOURCE_ID = "";
		public string ACTION = "";
		public string COMMENTS = "";
		public string BULLETIN_ITEM_TYPE = "";
		public string EFFECTIVE_DATE = "";
		public string EFFECTIVE_TIME = "";
		public string EFFECTIVE_TIME_ZONE = "";
		public string BULLETIN_ITEM_NUMBER = "";
		public string BULLETIN_UNIQUE_ID = "";
		public string FIELD_COUNT = "";
		public ArrayList FIELD_RECORD = new ArrayList();

		public void addFIELD_RECORD(MIS_NS_RemedyBulletinFIELD_RECORD_48 field_record) {
			this.FIELD_RECORD.Add(field_record);
		}
	}

	public partial class MIS_NS_RemedyBulletinFIELD_RECORD_48 {
		public string FIELD_NUMBER = "";
		public string FIELD_NAME = "";
		public string FIELD_CONTENT = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "RemedyBulletin", IsNullable = false)]
	public partial class NS_RemedyBulletin_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_RemedyBulletinHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_RemedyBulletinCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_EVENT_DATE_48[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_EVENT_TIME_48[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_SEQUENCE_NUMBER_48[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_DIVISION_NAME_48[] DIVISION_NAME;

		[System.Xml.Serialization.XmlElementAttribute("DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_DISTRICT_NAME_48[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("SOURCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_SOURCE_48[] SOURCE;

		[System.Xml.Serialization.XmlElementAttribute("SOURCE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_SOURCE_ID_48[] SOURCE_ID;

		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_ACTION_48[] ACTION;

		[System.Xml.Serialization.XmlElementAttribute("COMMENTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_COMMENTS_48[] COMMENTS;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_BULLETIN_ITEM_TYPE_48[] BULLETIN_ITEM_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_EFFECTIVE_DATE_48[] EFFECTIVE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_48[] EFFECTIVE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_ZONE_48[] EFFECTIVE_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_BULLETIN_ITEM_NUMBER_48[] BULLETIN_ITEM_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_UNIQUE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_BULLETIN_UNIQUE_ID_48[] BULLETIN_UNIQUE_ID;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_FIELD_COUNT_48[] FIELD_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinCONTENT_FIELD_RECORD_48[] FIELD_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_EVENT_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_EVENT_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_SEQUENCE_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_DIVISION_NAME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_DISTRICT_NAME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_SOURCE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_SOURCE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_ACTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_COMMENTS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_BULLETIN_ITEM_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_EFFECTIVE_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_EFFECTIVE_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_BULLETIN_ITEM_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_BULLETIN_UNIQUE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_FIELD_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinCONTENT_FIELD_RECORD_48 {
		[System.Xml.Serialization.XmlElementAttribute("FIELD_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinFIELD_RECORD_FIELD_NUMBER_48[] FIELD_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinFIELD_RECORD_FIELD_NAME_48[] FIELD_NAME;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_CONTENT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_RemedyBulletinFIELD_RECORD_FIELD_CONTENT_48[] FIELD_CONTENT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinFIELD_RECORD_FIELD_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinFIELD_RECORD_FIELD_NAME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_RemedyBulletinFIELD_RECORD_FIELD_CONTENT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}