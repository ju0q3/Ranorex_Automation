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
	public partial class MIS_NS_TrainDelay_48 {
		public MIS_NS_TrainDelayHEADER_48 HEADER;
		public MIS_NS_TrainDelayCONTENT_48 CONTENT;

		public static MIS_NS_TrainDelay_48 fromSerializableObject(NS_TrainDelay_48 message) {
			MIS_NS_TrainDelay_48 ns_traindelay_48 = new MIS_NS_TrainDelay_48();
			NS_TrainDelayHEADER_48 header = null;
			NS_TrainDelayCONTENT_48 content = null;
			header = (NS_TrainDelayHEADER_48) message.Items[0];
			content = (NS_TrainDelayCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_TrainDelayHEADER_48 messageheader = new MIS_NS_TrainDelayHEADER_48();

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

				ns_traindelay_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_TrainDelayCONTENT_48 messagecontent = new MIS_NS_TrainDelayCONTENT_48();

				if (content.SCAC != null) {
					messagecontent.SCAC = content.SCAC[0].Value;
					if (messagecontent.SCAC != null) {
						if (messagecontent.SCAC.Length < 0 || messagecontent.SCAC.Length > 4) {
							Ranorex.Report.Failure("Field SCAC expected to be length between or equal to 0 and 4, has length of {" + messagecontent.SCAC.Length.ToString() + "}.");
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

				if (content.FROM_DIVISION_NUMBER != null) {
					messagecontent.FROM_DIVISION_NUMBER = content.FROM_DIVISION_NUMBER[0].Value;
					if (messagecontent.FROM_DIVISION_NUMBER != null) {
						if (messagecontent.FROM_DIVISION_NUMBER.Length < 1 || messagecontent.FROM_DIVISION_NUMBER.Length > 2) {
							Ranorex.Report.Failure("Field FROM_DIVISION_NUMBER expected to be length between or equal to 1 and 2, has length of {" + messagecontent.FROM_DIVISION_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.FROM_DIVISION_NUMBER)) {
							Ranorex.Report.Failure("Field FROM_DIVISION_NUMBER expected to be Numeric, has value of {" + messagecontent.FROM_DIVISION_NUMBER + "}.");
						}
					}
				}

				if (content.FROM_DIVISION != null) {
					messagecontent.FROM_DIVISION = content.FROM_DIVISION[0].Value;
					if (messagecontent.FROM_DIVISION != null) {
						if (messagecontent.FROM_DIVISION.Length < 1 || messagecontent.FROM_DIVISION.Length > 25) {
							Ranorex.Report.Failure("Field FROM_DIVISION expected to be length between or equal to 1 and 25, has length of {" + messagecontent.FROM_DIVISION.Length.ToString() + "}.");
						}
					}
				}

				if (content.FROM_DISTRICT != null) {
					messagecontent.FROM_DISTRICT = content.FROM_DISTRICT[0].Value;
					if (messagecontent.FROM_DISTRICT != null) {
						if (messagecontent.FROM_DISTRICT.Length < 1 || messagecontent.FROM_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field FROM_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.FROM_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.FROM_LOCATION_TYPE != null) {
					messagecontent.FROM_LOCATION_TYPE = content.FROM_LOCATION_TYPE[0].Value;
					if (messagecontent.FROM_LOCATION_TYPE != null) {
						if (messagecontent.FROM_LOCATION_TYPE.Length != 1) {
							Ranorex.Report.Failure("Field FROM_LOCATION_TYPE expected to be length of 1, has length of {" + messagecontent.FROM_LOCATION_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.FROM_LOCATION_TYPE)) {
							Ranorex.Report.Failure("Field FROM_LOCATION_TYPE expected to be Alphabetic, has value of {" + messagecontent.FROM_LOCATION_TYPE + "}.");
						}
						if (messagecontent.FROM_LOCATION_TYPE != "M" && messagecontent.FROM_LOCATION_TYPE != "O") {
							Ranorex.Report.Failure("Field FROM_LOCATION_TYPE expected to be one of the following values {M, O}, but was found to be {" + messagecontent.FROM_LOCATION_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field FROM_LOCATION_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.FROM_LOCATION != null) {
					messagecontent.FROM_LOCATION = content.FROM_LOCATION[0].Value;
					if (messagecontent.FROM_LOCATION != null) {
						if (messagecontent.FROM_LOCATION.Length < 1 || messagecontent.FROM_LOCATION.Length > 10) {
							Ranorex.Report.Failure("Field FROM_LOCATION expected to be length between or equal to 1 and 10, has length of {" + messagecontent.FROM_LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field FROM_LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.END_DIVISION_NUMBER != null) {
					messagecontent.END_DIVISION_NUMBER = content.END_DIVISION_NUMBER[0].Value;
					if (messagecontent.END_DIVISION_NUMBER != null) {
						if (messagecontent.END_DIVISION_NUMBER.Length < 1 || messagecontent.END_DIVISION_NUMBER.Length > 2) {
							Ranorex.Report.Failure("Field END_DIVISION_NUMBER expected to be length between or equal to 1 and 2, has length of {" + messagecontent.END_DIVISION_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.END_DIVISION_NUMBER)) {
							Ranorex.Report.Failure("Field END_DIVISION_NUMBER expected to be Numeric, has value of {" + messagecontent.END_DIVISION_NUMBER + "}.");
						}
					}
				}

				if (content.END_DIVISION != null) {
					messagecontent.END_DIVISION = content.END_DIVISION[0].Value;
					if (messagecontent.END_DIVISION != null) {
						if (messagecontent.END_DIVISION.Length < 1 || messagecontent.END_DIVISION.Length > 25) {
							Ranorex.Report.Failure("Field END_DIVISION expected to be length between or equal to 1 and 25, has length of {" + messagecontent.END_DIVISION.Length.ToString() + "}.");
						}
					}
				}

				if (content.END_DISTRICT != null) {
					messagecontent.END_DISTRICT = content.END_DISTRICT[0].Value;
					if (messagecontent.END_DISTRICT != null) {
						if (messagecontent.END_DISTRICT.Length < 1 || messagecontent.END_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field END_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.END_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.END_LOCATION_TYPE != null) {
					messagecontent.END_LOCATION_TYPE = content.END_LOCATION_TYPE[0].Value;
					if (messagecontent.END_LOCATION_TYPE != null) {
						if (messagecontent.END_LOCATION_TYPE.Length != 1) {
							Ranorex.Report.Failure("Field END_LOCATION_TYPE expected to be length of 1, has length of {" + messagecontent.END_LOCATION_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.END_LOCATION_TYPE)) {
							Ranorex.Report.Failure("Field END_LOCATION_TYPE expected to be Alphabetic, has value of {" + messagecontent.END_LOCATION_TYPE + "}.");
						}
						if (messagecontent.END_LOCATION_TYPE != "M" && messagecontent.END_LOCATION_TYPE != "O") {
							Ranorex.Report.Failure("Field END_LOCATION_TYPE expected to be one of the following values {M, O}, but was found to be {" + messagecontent.END_LOCATION_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field END_LOCATION_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.END_LOCATION != null) {
					messagecontent.END_LOCATION = content.END_LOCATION[0].Value;
					if (messagecontent.END_LOCATION != null) {
						if (messagecontent.END_LOCATION.Length < 1 || messagecontent.END_LOCATION.Length > 10) {
							Ranorex.Report.Failure("Field END_LOCATION expected to be length between or equal to 1 and 10, has length of {" + messagecontent.END_LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field END_LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.DELAY_RECORD_ID != null) {
					messagecontent.DELAY_RECORD_ID = content.DELAY_RECORD_ID[0].Value;
					if (messagecontent.DELAY_RECORD_ID != null) {
						if (messagecontent.DELAY_RECORD_ID.Length < 1 || messagecontent.DELAY_RECORD_ID.Length > 20) {
							Ranorex.Report.Failure("Field DELAY_RECORD_ID expected to be length between or equal to 1 and 20, has length of {" + messagecontent.DELAY_RECORD_ID.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.DELAY_RECORD_ID)) {
							Ranorex.Report.Failure("Field DELAY_RECORD_ID expected to be Numeric, has value of {" + messagecontent.DELAY_RECORD_ID + "}.");
						}
					}
				}

				if (content.DELAY_CODE != null) {
					messagecontent.DELAY_CODE = content.DELAY_CODE[0].Value;
					if (messagecontent.DELAY_CODE != null) {
						if (messagecontent.DELAY_CODE.Length < 1 || messagecontent.DELAY_CODE.Length > 3) {
							Ranorex.Report.Failure("Field DELAY_CODE expected to be length between or equal to 1 and 3, has length of {" + messagecontent.DELAY_CODE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.DELAY_CODE)) {
							Ranorex.Report.Failure("Field DELAY_CODE expected to be Alphabetic, has value of {" + messagecontent.DELAY_CODE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DELAY_CODE is a Mandatory field but was found to be missing from the message");
				}

				if (content.TRANSMISSION_TYPE != null) {
					messagecontent.TRANSMISSION_TYPE = content.TRANSMISSION_TYPE[0].Value;
					if (messagecontent.TRANSMISSION_TYPE != null) {
						if (messagecontent.TRANSMISSION_TYPE.Length != 1) {
							Ranorex.Report.Failure("Field TRANSMISSION_TYPE expected to be length of 1, has length of {" + messagecontent.TRANSMISSION_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.TRANSMISSION_TYPE)) {
							Ranorex.Report.Failure("Field TRANSMISSION_TYPE expected to be Alphabetic, has value of {" + messagecontent.TRANSMISSION_TYPE + "}.");
						}
						if (messagecontent.TRANSMISSION_TYPE != "N" && messagecontent.TRANSMISSION_TYPE != "C" && messagecontent.TRANSMISSION_TYPE != "D") {
							Ranorex.Report.Failure("Field TRANSMISSION_TYPE expected to be one of the following values {N, C, D}, but was found to be {" + messagecontent.TRANSMISSION_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TRANSMISSION_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.USER_ID != null) {
					messagecontent.USER_ID = content.USER_ID[0].Value;
					if (messagecontent.USER_ID != null) {
						if (messagecontent.USER_ID.Length < 1 || messagecontent.USER_ID.Length > 7) {
							Ranorex.Report.Failure("Field USER_ID expected to be length between or equal to 1 and 7, has length of {" + messagecontent.USER_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.SOURCE_SYSTEM != null) {
					messagecontent.SOURCE_SYSTEM = content.SOURCE_SYSTEM[0].Value;
					if (messagecontent.SOURCE_SYSTEM != null) {
						if (messagecontent.SOURCE_SYSTEM.Length < 1 || messagecontent.SOURCE_SYSTEM.Length > 10) {
							Ranorex.Report.Failure("Field SOURCE_SYSTEM expected to be length between or equal to 1 and 10, has length of {" + messagecontent.SOURCE_SYSTEM.Length.ToString() + "}.");
						}
					}
				}

				if (content.BEGIN_DELAY_DATE != null) {
					messagecontent.BEGIN_DELAY_DATE = content.BEGIN_DELAY_DATE[0].Value;
					if (messagecontent.BEGIN_DELAY_DATE != null) {
						if (messagecontent.BEGIN_DELAY_DATE.Length != 8) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_DATE expected to be length of 8, has length of {" + messagecontent.BEGIN_DELAY_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.BEGIN_DELAY_DATE)) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_DATE expected to be Numeric, has value of {" + messagecontent.BEGIN_DELAY_DATE + "}.");
						}
					}
				}

				if (content.BEGIN_DELAY_TIME != null) {
					messagecontent.BEGIN_DELAY_TIME = content.BEGIN_DELAY_TIME[0].Value;
					if (messagecontent.BEGIN_DELAY_TIME != null) {
						if (messagecontent.BEGIN_DELAY_TIME.Length != 4) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_TIME expected to be length of 4, has length of {" + messagecontent.BEGIN_DELAY_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.BEGIN_DELAY_TIME)) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_TIME expected to be Numeric, has value of {" + messagecontent.BEGIN_DELAY_TIME + "}.");
						}
					}
				}

				if (content.BEGIN_DELAY_TIME_ZONE != null) {
					messagecontent.BEGIN_DELAY_TIME_ZONE = content.BEGIN_DELAY_TIME_ZONE[0].Value;
					if (messagecontent.BEGIN_DELAY_TIME_ZONE != null) {
						if (messagecontent.BEGIN_DELAY_TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_TIME_ZONE expected to be length of 1, has length of {" + messagecontent.BEGIN_DELAY_TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.BEGIN_DELAY_TIME_ZONE)) {
							Ranorex.Report.Failure("Field BEGIN_DELAY_TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.BEGIN_DELAY_TIME_ZONE + "}.");
						}
						if (messagecontent.BEGIN_DELAY_TIME_ZONE != "E" && messagecontent.BEGIN_DELAY_TIME_ZONE != "C") {
							Ranorex.Report.Failure("Field BEGIN_DELAY_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + messagecontent.BEGIN_DELAY_TIME_ZONE + "}.");
						}
					}
				}

				if (content.END_DELAY_DATE != null) {
					messagecontent.END_DELAY_DATE = content.END_DELAY_DATE[0].Value;
					if (messagecontent.END_DELAY_DATE != null) {
						if (messagecontent.END_DELAY_DATE.Length != 8) {
							Ranorex.Report.Failure("Field END_DELAY_DATE expected to be length of 8, has length of {" + messagecontent.END_DELAY_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.END_DELAY_DATE)) {
							Ranorex.Report.Failure("Field END_DELAY_DATE expected to be Numeric, has value of {" + messagecontent.END_DELAY_DATE + "}.");
						}
					}
				}

				if (content.END_DELAY_TIME != null) {
					messagecontent.END_DELAY_TIME = content.END_DELAY_TIME[0].Value;
					if (messagecontent.END_DELAY_TIME != null) {
						if (messagecontent.END_DELAY_TIME.Length != 4) {
							Ranorex.Report.Failure("Field END_DELAY_TIME expected to be length of 4, has length of {" + messagecontent.END_DELAY_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.END_DELAY_TIME)) {
							Ranorex.Report.Failure("Field END_DELAY_TIME expected to be Numeric, has value of {" + messagecontent.END_DELAY_TIME + "}.");
						}
					}
				}

				if (content.END_DELAY_TIME_ZONE != null) {
					messagecontent.END_DELAY_TIME_ZONE = content.END_DELAY_TIME_ZONE[0].Value;
					if (messagecontent.END_DELAY_TIME_ZONE != null) {
						if (messagecontent.END_DELAY_TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field END_DELAY_TIME_ZONE expected to be length of 1, has length of {" + messagecontent.END_DELAY_TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.END_DELAY_TIME_ZONE)) {
							Ranorex.Report.Failure("Field END_DELAY_TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.END_DELAY_TIME_ZONE + "}.");
						}
						if (messagecontent.END_DELAY_TIME_ZONE != "E" && messagecontent.END_DELAY_TIME_ZONE != "C") {
							Ranorex.Report.Failure("Field END_DELAY_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + messagecontent.END_DELAY_TIME_ZONE + "}.");
						}
					}
				}

				if (content.DELAY_DURATION != null) {
					messagecontent.DELAY_DURATION = content.DELAY_DURATION[0].Value;
					if (messagecontent.DELAY_DURATION != null) {
						if (messagecontent.DELAY_DURATION.Length != 4) {
							Ranorex.Report.Failure("Field DELAY_DURATION expected to be length of 4, has length of {" + messagecontent.DELAY_DURATION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.DELAY_DURATION)) {
							Ranorex.Report.Failure("Field DELAY_DURATION expected to be Numeric, has value of {" + messagecontent.DELAY_DURATION + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DELAY_DURATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.CREW_ID != null) {
					messagecontent.CREW_ID = content.CREW_ID[0].Value;
					if (messagecontent.CREW_ID != null) {
						if (messagecontent.CREW_ID.Length < 1 || messagecontent.CREW_ID.Length > 10) {
							Ranorex.Report.Failure("Field CREW_ID expected to be length between or equal to 1 and 10, has length of {" + messagecontent.CREW_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.CREW_LINE_SEGMENT != null) {
					messagecontent.CREW_LINE_SEGMENT = content.CREW_LINE_SEGMENT[0].Value;
					if (messagecontent.CREW_LINE_SEGMENT != null) {
						if (messagecontent.CREW_LINE_SEGMENT.Length < 1 || messagecontent.CREW_LINE_SEGMENT.Length > 2) {
							Ranorex.Report.Failure("Field CREW_LINE_SEGMENT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.CREW_LINE_SEGMENT.Length.ToString() + "}.");
						}
					}
				}

				if (content.FREE_FORM_TEXT != null) {
					messagecontent.FREE_FORM_TEXT = content.FREE_FORM_TEXT[0].Value;
					if (messagecontent.FREE_FORM_TEXT != null) {
						if (messagecontent.FREE_FORM_TEXT.Length < 1 || messagecontent.FREE_FORM_TEXT.Length > 250) {
							Ranorex.Report.Failure("Field FREE_FORM_TEXT expected to be length between or equal to 1 and 250, has length of {" + messagecontent.FREE_FORM_TEXT.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_1 != null) {
					messagecontent.FIELD_1 = content.FIELD_1[0].Value;
					if (messagecontent.FIELD_1 != null) {
						if (messagecontent.FIELD_1.Length < 1 || messagecontent.FIELD_1.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_1 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_1.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_2 != null) {
					messagecontent.FIELD_2 = content.FIELD_2[0].Value;
					if (messagecontent.FIELD_2 != null) {
						if (messagecontent.FIELD_2.Length < 1 || messagecontent.FIELD_2.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_2 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_2.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_3 != null) {
					messagecontent.FIELD_3 = content.FIELD_3[0].Value;
					if (messagecontent.FIELD_3 != null) {
						if (messagecontent.FIELD_3.Length < 1 || messagecontent.FIELD_3.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_3 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_3.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_4 != null) {
					messagecontent.FIELD_4 = content.FIELD_4[0].Value;
					if (messagecontent.FIELD_4 != null) {
						if (messagecontent.FIELD_4.Length < 1 || messagecontent.FIELD_4.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_4 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_4.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_5 != null) {
					messagecontent.FIELD_5 = content.FIELD_5[0].Value;
					if (messagecontent.FIELD_5 != null) {
						if (messagecontent.FIELD_5.Length < 1 || messagecontent.FIELD_5.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_5 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_5.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_6 != null) {
					messagecontent.FIELD_6 = content.FIELD_6[0].Value;
					if (messagecontent.FIELD_6 != null) {
						if (messagecontent.FIELD_6.Length < 1 || messagecontent.FIELD_6.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_6 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_6.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_7 != null) {
					messagecontent.FIELD_7 = content.FIELD_7[0].Value;
					if (messagecontent.FIELD_7 != null) {
						if (messagecontent.FIELD_7.Length < 1 || messagecontent.FIELD_7.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_7 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_7.Length.ToString() + "}.");
						}
					}
				}

				if (content.FIELD_8 != null) {
					messagecontent.FIELD_8 = content.FIELD_8[0].Value;
					if (messagecontent.FIELD_8 != null) {
						if (messagecontent.FIELD_8.Length < 1 || messagecontent.FIELD_8.Length > 50) {
							Ranorex.Report.Failure("Field FIELD_8 expected to be length between or equal to 1 and 50, has length of {" + messagecontent.FIELD_8.Length.ToString() + "}.");
						}
					}
				}

				ns_traindelay_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_traindelay_48;
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

		public static void createNS_TrainDelay_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_from_division_number,
			string content_from_division,
			string content_from_district,
			string content_from_location_type,
			string content_from_location,
			string content_end_division_number,
			string content_end_division,
			string content_end_district,
			string content_end_location_type,
			string content_end_location,
			string content_delay_record_id,
			string content_delay_code,
			string content_transmission_type,
			string content_user_id,
			string content_source_system,
			string content_begin_delay_date,
			string content_begin_delay_time,
			string content_begin_delay_time_zone,
			string content_end_delay_date,
			string content_end_delay_time,
			string content_end_delay_time_zone,
			string content_delay_duration,
			string content_crew_id,
			string content_crew_line_segment,
			string content_free_form_text,
			string content_field_1,
			string content_field_2,
			string content_field_3,
			string content_field_4,
			string content_field_5,
			string content_field_6,
			string content_field_7,
			string content_field_8,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainDelay_48 mis_ns_traindelay = buildMIS_NS_TrainDelay_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_from_division_number, content_from_division, content_from_district, content_from_location_type, content_from_location, content_end_division_number, content_end_division, content_end_district, content_end_location_type, content_end_location, content_delay_record_id, content_delay_code, content_transmission_type, content_user_id, content_source_system, content_begin_delay_date, content_begin_delay_time, content_begin_delay_time_zone, content_end_delay_date, content_end_delay_time, content_end_delay_time_zone, content_delay_duration, content_crew_id, content_crew_line_segment, content_free_form_text, content_field_1, content_field_2, content_field_3, content_field_4, content_field_5, content_field_6, content_field_7, content_field_8);

			NS_TrainDelay_48 ns_traindelay = mis_ns_traindelay.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainDelay_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_traindelay);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_traindelay.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_traindelay.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainDelay_48 buildMIS_NS_TrainDelay_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_from_division_number,
			string content_from_division,
			string content_from_district,
			string content_from_location_type,
			string content_from_location,
			string content_end_division_number,
			string content_end_division,
			string content_end_district,
			string content_end_location_type,
			string content_end_location,
			string content_delay_record_id,
			string content_delay_code,
			string content_transmission_type,
			string content_user_id,
			string content_source_system,
			string content_begin_delay_date,
			string content_begin_delay_time,
			string content_begin_delay_time_zone,
			string content_end_delay_date,
			string content_end_delay_time,
			string content_end_delay_time_zone,
			string content_delay_duration,
			string content_crew_id,
			string content_crew_line_segment,
			string content_free_form_text,
			string content_field_1,
			string content_field_2,
			string content_field_3,
			string content_field_4,
			string content_field_5,
			string content_field_6,
			string content_field_7,
			string content_field_8
		) {

			MIS_NS_TrainDelay_48 mis_ns_traindelay = new MIS_NS_TrainDelay_48();

			MIS_NS_TrainDelayHEADER_48 header = new MIS_NS_TrainDelayHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainDelayCONTENT_48 content = new MIS_NS_TrainDelayCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.FROM_DIVISION_NUMBER = content_from_division_number;
			content.FROM_DIVISION = content_from_division;
			content.FROM_DISTRICT = content_from_district;
			content.FROM_LOCATION_TYPE = content_from_location_type;
			content.FROM_LOCATION = content_from_location;
			content.END_DIVISION_NUMBER = content_end_division_number;
			content.END_DIVISION = content_end_division;
			content.END_DISTRICT = content_end_district;
			content.END_LOCATION_TYPE = content_end_location_type;
			content.END_LOCATION = content_end_location;
			content.DELAY_RECORD_ID = content_delay_record_id;
			content.DELAY_CODE = content_delay_code;
			content.TRANSMISSION_TYPE = content_transmission_type;
			content.USER_ID = content_user_id;
			content.SOURCE_SYSTEM = content_source_system;
			content.BEGIN_DELAY_DATE = content_begin_delay_date;
			content.BEGIN_DELAY_TIME = content_begin_delay_time;
			content.BEGIN_DELAY_TIME_ZONE = content_begin_delay_time_zone;
			content.END_DELAY_DATE = content_end_delay_date;
			content.END_DELAY_TIME = content_end_delay_time;
			content.END_DELAY_TIME_ZONE = content_end_delay_time_zone;
			content.DELAY_DURATION = content_delay_duration;
			content.CREW_ID = content_crew_id;
			content.CREW_LINE_SEGMENT = content_crew_line_segment;
			content.FREE_FORM_TEXT = content_free_form_text;
			content.FIELD_1 = content_field_1;
			content.FIELD_2 = content_field_2;
			content.FIELD_3 = content_field_3;
			content.FIELD_4 = content_field_4;
			content.FIELD_5 = content_field_5;
			content.FIELD_6 = content_field_6;
			content.FIELD_7 = content_field_7;
			content.FIELD_8 = content_field_8;

			mis_ns_traindelay.HEADER = header;
			mis_ns_traindelay.CONTENT = content;
			return mis_ns_traindelay;
		}

		public NS_TrainDelay_48 toSerializableObject() {
			NS_TrainDelay_48 ns_traindelay_48 = new NS_TrainDelay_48();
			ns_traindelay_48.Items = new object[2];

			NS_TrainDelayHEADER_48 header = new NS_TrainDelayHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainDelayHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_TrainDelayHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainDelayHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_TrainDelayHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_TrainDelayHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_TrainDelayHEADER_TRACE_ID_48();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_TrainDelayHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_TrainDelayHEADER_MESSAGE_VERSION_48();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_TrainDelayCONTENT_48 content = new NS_TrainDelayCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_TrainDelayCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_TrainDelayCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_TrainDelayCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_TrainDelayCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_TrainDelayCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_TrainDelayCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_TrainDelayCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_TrainDelayCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.FROM_DIVISION_NUMBER != null && CONTENT.FROM_DIVISION_NUMBER != "") {
					content.FROM_DIVISION_NUMBER = new NS_TrainDelayCONTENT_FROM_DIVISION_NUMBER_48[1];
					content.FROM_DIVISION_NUMBER[0] = new NS_TrainDelayCONTENT_FROM_DIVISION_NUMBER_48();
					if (CONTENT.FROM_DIVISION_NUMBER == "Empty") {
						content.FROM_DIVISION_NUMBER[0].Value = "";
					} else {
						content.FROM_DIVISION_NUMBER[0].Value = CONTENT.FROM_DIVISION_NUMBER;
					}
				}

				if (CONTENT.FROM_DIVISION != null && CONTENT.FROM_DIVISION != "") {
					content.FROM_DIVISION = new NS_TrainDelayCONTENT_FROM_DIVISION_48[1];
					content.FROM_DIVISION[0] = new NS_TrainDelayCONTENT_FROM_DIVISION_48();
					if (CONTENT.FROM_DIVISION == "Empty") {
						content.FROM_DIVISION[0].Value = "";
					} else {
						content.FROM_DIVISION[0].Value = CONTENT.FROM_DIVISION;
					}
				}

				if (CONTENT.FROM_DISTRICT != null && CONTENT.FROM_DISTRICT != "") {
					content.FROM_DISTRICT = new NS_TrainDelayCONTENT_FROM_DISTRICT_48[1];
					content.FROM_DISTRICT[0] = new NS_TrainDelayCONTENT_FROM_DISTRICT_48();
					if (CONTENT.FROM_DISTRICT == "Empty") {
						content.FROM_DISTRICT[0].Value = "";
					} else {
						content.FROM_DISTRICT[0].Value = CONTENT.FROM_DISTRICT;
					}
				}

				if (CONTENT.FROM_LOCATION_TYPE != "Null") {
					content.FROM_LOCATION_TYPE = new NS_TrainDelayCONTENT_FROM_LOCATION_TYPE_48[1];
					content.FROM_LOCATION_TYPE[0] = new NS_TrainDelayCONTENT_FROM_LOCATION_TYPE_48();
					content.FROM_LOCATION_TYPE[0].Value = CONTENT.FROM_LOCATION_TYPE;
				}

				if (CONTENT.FROM_LOCATION != "Null") {
					content.FROM_LOCATION = new NS_TrainDelayCONTENT_FROM_LOCATION_48[1];
					content.FROM_LOCATION[0] = new NS_TrainDelayCONTENT_FROM_LOCATION_48();
					content.FROM_LOCATION[0].Value = CONTENT.FROM_LOCATION;
				}

				if (CONTENT.END_DIVISION_NUMBER != null && CONTENT.END_DIVISION_NUMBER != "") {
					content.END_DIVISION_NUMBER = new NS_TrainDelayCONTENT_END_DIVISION_NUMBER_48[1];
					content.END_DIVISION_NUMBER[0] = new NS_TrainDelayCONTENT_END_DIVISION_NUMBER_48();
					if (CONTENT.END_DIVISION_NUMBER == "Empty") {
						content.END_DIVISION_NUMBER[0].Value = "";
					} else {
						content.END_DIVISION_NUMBER[0].Value = CONTENT.END_DIVISION_NUMBER;
					}
				}

				if (CONTENT.END_DIVISION != null && CONTENT.END_DIVISION != "") {
					content.END_DIVISION = new NS_TrainDelayCONTENT_END_DIVISION_48[1];
					content.END_DIVISION[0] = new NS_TrainDelayCONTENT_END_DIVISION_48();
					if (CONTENT.END_DIVISION == "Empty") {
						content.END_DIVISION[0].Value = "";
					} else {
						content.END_DIVISION[0].Value = CONTENT.END_DIVISION;
					}
				}

				if (CONTENT.END_DISTRICT != null && CONTENT.END_DISTRICT != "") {
					content.END_DISTRICT = new NS_TrainDelayCONTENT_END_DISTRICT_48[1];
					content.END_DISTRICT[0] = new NS_TrainDelayCONTENT_END_DISTRICT_48();
					if (CONTENT.END_DISTRICT == "Empty") {
						content.END_DISTRICT[0].Value = "";
					} else {
						content.END_DISTRICT[0].Value = CONTENT.END_DISTRICT;
					}
				}

				if (CONTENT.END_LOCATION_TYPE != "Null") {
					content.END_LOCATION_TYPE = new NS_TrainDelayCONTENT_END_LOCATION_TYPE_48[1];
					content.END_LOCATION_TYPE[0] = new NS_TrainDelayCONTENT_END_LOCATION_TYPE_48();
					content.END_LOCATION_TYPE[0].Value = CONTENT.END_LOCATION_TYPE;
				}

				if (CONTENT.END_LOCATION != "Null") {
					content.END_LOCATION = new NS_TrainDelayCONTENT_END_LOCATION_48[1];
					content.END_LOCATION[0] = new NS_TrainDelayCONTENT_END_LOCATION_48();
					content.END_LOCATION[0].Value = CONTENT.END_LOCATION;
				}

				if (CONTENT.DELAY_RECORD_ID != null && CONTENT.DELAY_RECORD_ID != "") {
					content.DELAY_RECORD_ID = new NS_TrainDelayCONTENT_DELAY_RECORD_ID_48[1];
					content.DELAY_RECORD_ID[0] = new NS_TrainDelayCONTENT_DELAY_RECORD_ID_48();
					if (CONTENT.DELAY_RECORD_ID == "Empty") {
						content.DELAY_RECORD_ID[0].Value = "";
					} else {
						content.DELAY_RECORD_ID[0].Value = CONTENT.DELAY_RECORD_ID;
					}
				}

				if (CONTENT.DELAY_CODE != "Null") {
					content.DELAY_CODE = new NS_TrainDelayCONTENT_DELAY_CODE_48[1];
					content.DELAY_CODE[0] = new NS_TrainDelayCONTENT_DELAY_CODE_48();
					content.DELAY_CODE[0].Value = CONTENT.DELAY_CODE;
				}

				if (CONTENT.TRANSMISSION_TYPE != "Null") {
					content.TRANSMISSION_TYPE = new NS_TrainDelayCONTENT_TRANSMISSION_TYPE_48[1];
					content.TRANSMISSION_TYPE[0] = new NS_TrainDelayCONTENT_TRANSMISSION_TYPE_48();
					content.TRANSMISSION_TYPE[0].Value = CONTENT.TRANSMISSION_TYPE;
				}

				if (CONTENT.USER_ID != null && CONTENT.USER_ID != "") {
					content.USER_ID = new NS_TrainDelayCONTENT_USER_ID_48[1];
					content.USER_ID[0] = new NS_TrainDelayCONTENT_USER_ID_48();
					if (CONTENT.USER_ID == "Empty") {
						content.USER_ID[0].Value = "";
					} else {
						content.USER_ID[0].Value = CONTENT.USER_ID;
					}
				}

				if (CONTENT.SOURCE_SYSTEM != null && CONTENT.SOURCE_SYSTEM != "") {
					content.SOURCE_SYSTEM = new NS_TrainDelayCONTENT_SOURCE_SYSTEM_48[1];
					content.SOURCE_SYSTEM[0] = new NS_TrainDelayCONTENT_SOURCE_SYSTEM_48();
					if (CONTENT.SOURCE_SYSTEM == "Empty") {
						content.SOURCE_SYSTEM[0].Value = "";
					} else {
						content.SOURCE_SYSTEM[0].Value = CONTENT.SOURCE_SYSTEM;
					}
				}

				if (CONTENT.BEGIN_DELAY_DATE != null && CONTENT.BEGIN_DELAY_DATE != "") {
					content.BEGIN_DELAY_DATE = new NS_TrainDelayCONTENT_BEGIN_DELAY_DATE_48[1];
					content.BEGIN_DELAY_DATE[0] = new NS_TrainDelayCONTENT_BEGIN_DELAY_DATE_48();
					if (CONTENT.BEGIN_DELAY_DATE == "Empty") {
						content.BEGIN_DELAY_DATE[0].Value = "";
					} else {
						content.BEGIN_DELAY_DATE[0].Value = CONTENT.BEGIN_DELAY_DATE;
					}
				}

				if (CONTENT.BEGIN_DELAY_TIME != null && CONTENT.BEGIN_DELAY_TIME != "") {
					content.BEGIN_DELAY_TIME = new NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_48[1];
					content.BEGIN_DELAY_TIME[0] = new NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_48();
					if (CONTENT.BEGIN_DELAY_TIME == "Empty") {
						content.BEGIN_DELAY_TIME[0].Value = "";
					} else {
						content.BEGIN_DELAY_TIME[0].Value = CONTENT.BEGIN_DELAY_TIME;
					}
				}

				if (CONTENT.BEGIN_DELAY_TIME_ZONE != null && CONTENT.BEGIN_DELAY_TIME_ZONE != "") {
					content.BEGIN_DELAY_TIME_ZONE = new NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_ZONE_48[1];
					content.BEGIN_DELAY_TIME_ZONE[0] = new NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_ZONE_48();
					if (CONTENT.BEGIN_DELAY_TIME_ZONE == "Empty") {
						content.BEGIN_DELAY_TIME_ZONE[0].Value = "";
					} else {
						content.BEGIN_DELAY_TIME_ZONE[0].Value = CONTENT.BEGIN_DELAY_TIME_ZONE;
					}
				}

				if (CONTENT.END_DELAY_DATE != null && CONTENT.END_DELAY_DATE != "") {
					content.END_DELAY_DATE = new NS_TrainDelayCONTENT_END_DELAY_DATE_48[1];
					content.END_DELAY_DATE[0] = new NS_TrainDelayCONTENT_END_DELAY_DATE_48();
					if (CONTENT.END_DELAY_DATE == "Empty") {
						content.END_DELAY_DATE[0].Value = "";
					} else {
						content.END_DELAY_DATE[0].Value = CONTENT.END_DELAY_DATE;
					}
				}

				if (CONTENT.END_DELAY_TIME != null && CONTENT.END_DELAY_TIME != "") {
					content.END_DELAY_TIME = new NS_TrainDelayCONTENT_END_DELAY_TIME_48[1];
					content.END_DELAY_TIME[0] = new NS_TrainDelayCONTENT_END_DELAY_TIME_48();
					if (CONTENT.END_DELAY_TIME == "Empty") {
						content.END_DELAY_TIME[0].Value = "";
					} else {
						content.END_DELAY_TIME[0].Value = CONTENT.END_DELAY_TIME;
					}
				}

				if (CONTENT.END_DELAY_TIME_ZONE != null && CONTENT.END_DELAY_TIME_ZONE != "") {
					content.END_DELAY_TIME_ZONE = new NS_TrainDelayCONTENT_END_DELAY_TIME_ZONE_48[1];
					content.END_DELAY_TIME_ZONE[0] = new NS_TrainDelayCONTENT_END_DELAY_TIME_ZONE_48();
					if (CONTENT.END_DELAY_TIME_ZONE == "Empty") {
						content.END_DELAY_TIME_ZONE[0].Value = "";
					} else {
						content.END_DELAY_TIME_ZONE[0].Value = CONTENT.END_DELAY_TIME_ZONE;
					}
				}

				if (CONTENT.DELAY_DURATION != "Null") {
					content.DELAY_DURATION = new NS_TrainDelayCONTENT_DELAY_DURATION_48[1];
					content.DELAY_DURATION[0] = new NS_TrainDelayCONTENT_DELAY_DURATION_48();
					content.DELAY_DURATION[0].Value = CONTENT.DELAY_DURATION;
				}

				if (CONTENT.CREW_ID != null && CONTENT.CREW_ID != "") {
					content.CREW_ID = new NS_TrainDelayCONTENT_CREW_ID_48[1];
					content.CREW_ID[0] = new NS_TrainDelayCONTENT_CREW_ID_48();
					if (CONTENT.CREW_ID == "Empty") {
						content.CREW_ID[0].Value = "";
					} else {
						content.CREW_ID[0].Value = CONTENT.CREW_ID;
					}
				}

				if (CONTENT.CREW_LINE_SEGMENT != null && CONTENT.CREW_LINE_SEGMENT != "") {
					content.CREW_LINE_SEGMENT = new NS_TrainDelayCONTENT_CREW_LINE_SEGMENT_48[1];
					content.CREW_LINE_SEGMENT[0] = new NS_TrainDelayCONTENT_CREW_LINE_SEGMENT_48();
					if (CONTENT.CREW_LINE_SEGMENT == "Empty") {
						content.CREW_LINE_SEGMENT[0].Value = "";
					} else {
						content.CREW_LINE_SEGMENT[0].Value = CONTENT.CREW_LINE_SEGMENT;
					}
				}

				if (CONTENT.FREE_FORM_TEXT != null && CONTENT.FREE_FORM_TEXT != "") {
					content.FREE_FORM_TEXT = new NS_TrainDelayCONTENT_FREE_FORM_TEXT_48[1];
					content.FREE_FORM_TEXT[0] = new NS_TrainDelayCONTENT_FREE_FORM_TEXT_48();
					if (CONTENT.FREE_FORM_TEXT == "Empty") {
						content.FREE_FORM_TEXT[0].Value = "";
					} else {
						content.FREE_FORM_TEXT[0].Value = CONTENT.FREE_FORM_TEXT;
					}
				}

				if (CONTENT.FIELD_1 != null && CONTENT.FIELD_1 != "") {
					content.FIELD_1 = new NS_TrainDelayCONTENT_FIELD_1_48[1];
					content.FIELD_1[0] = new NS_TrainDelayCONTENT_FIELD_1_48();
					if (CONTENT.FIELD_1 == "Empty") {
						content.FIELD_1[0].Value = "";
					} else {
						content.FIELD_1[0].Value = CONTENT.FIELD_1;
					}
				}

				if (CONTENT.FIELD_2 != null && CONTENT.FIELD_2 != "") {
					content.FIELD_2 = new NS_TrainDelayCONTENT_FIELD_2_48[1];
					content.FIELD_2[0] = new NS_TrainDelayCONTENT_FIELD_2_48();
					if (CONTENT.FIELD_2 == "Empty") {
						content.FIELD_2[0].Value = "";
					} else {
						content.FIELD_2[0].Value = CONTENT.FIELD_2;
					}
				}

				if (CONTENT.FIELD_3 != null && CONTENT.FIELD_3 != "") {
					content.FIELD_3 = new NS_TrainDelayCONTENT_FIELD_3_48[1];
					content.FIELD_3[0] = new NS_TrainDelayCONTENT_FIELD_3_48();
					if (CONTENT.FIELD_3 == "Empty") {
						content.FIELD_3[0].Value = "";
					} else {
						content.FIELD_3[0].Value = CONTENT.FIELD_3;
					}
				}

				if (CONTENT.FIELD_4 != null && CONTENT.FIELD_4 != "") {
					content.FIELD_4 = new NS_TrainDelayCONTENT_FIELD_4_48[1];
					content.FIELD_4[0] = new NS_TrainDelayCONTENT_FIELD_4_48();
					if (CONTENT.FIELD_4 == "Empty") {
						content.FIELD_4[0].Value = "";
					} else {
						content.FIELD_4[0].Value = CONTENT.FIELD_4;
					}
				}

				if (CONTENT.FIELD_5 != null && CONTENT.FIELD_5 != "") {
					content.FIELD_5 = new NS_TrainDelayCONTENT_FIELD_5_48[1];
					content.FIELD_5[0] = new NS_TrainDelayCONTENT_FIELD_5_48();
					if (CONTENT.FIELD_5 == "Empty") {
						content.FIELD_5[0].Value = "";
					} else {
						content.FIELD_5[0].Value = CONTENT.FIELD_5;
					}
				}

				if (CONTENT.FIELD_6 != null && CONTENT.FIELD_6 != "") {
					content.FIELD_6 = new NS_TrainDelayCONTENT_FIELD_6_48[1];
					content.FIELD_6[0] = new NS_TrainDelayCONTENT_FIELD_6_48();
					if (CONTENT.FIELD_6 == "Empty") {
						content.FIELD_6[0].Value = "";
					} else {
						content.FIELD_6[0].Value = CONTENT.FIELD_6;
					}
				}

				if (CONTENT.FIELD_7 != null && CONTENT.FIELD_7 != "") {
					content.FIELD_7 = new NS_TrainDelayCONTENT_FIELD_7_48[1];
					content.FIELD_7[0] = new NS_TrainDelayCONTENT_FIELD_7_48();
					if (CONTENT.FIELD_7 == "Empty") {
						content.FIELD_7[0].Value = "";
					} else {
						content.FIELD_7[0].Value = CONTENT.FIELD_7;
					}
				}

				if (CONTENT.FIELD_8 != null && CONTENT.FIELD_8 != "") {
					content.FIELD_8 = new NS_TrainDelayCONTENT_FIELD_8_48[1];
					content.FIELD_8[0] = new NS_TrainDelayCONTENT_FIELD_8_48();
					if (CONTENT.FIELD_8 == "Empty") {
						content.FIELD_8[0].Value = "";
					} else {
						content.FIELD_8[0].Value = CONTENT.FIELD_8;
					}
				}

			}

			ns_traindelay_48.Items[0] = header;
			ns_traindelay_48.Items[1] = content;
			return ns_traindelay_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNDLY,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNDLY,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainDelayHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainDelayCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string FROM_DIVISION_NUMBER = "";
		public string FROM_DIVISION = "";
		public string FROM_DISTRICT = "";
		public string FROM_LOCATION_TYPE = "";
		public string FROM_LOCATION = "";
		public string END_DIVISION_NUMBER = "";
		public string END_DIVISION = "";
		public string END_DISTRICT = "";
		public string END_LOCATION_TYPE = "";
		public string END_LOCATION = "";
		public string DELAY_RECORD_ID = "";
		public string DELAY_CODE = "";
		public string TRANSMISSION_TYPE = "";
		public string USER_ID = "";
		public string SOURCE_SYSTEM = "";
		public string BEGIN_DELAY_DATE = "";
		public string BEGIN_DELAY_TIME = "";
		public string BEGIN_DELAY_TIME_ZONE = "";
		public string END_DELAY_DATE = "";
		public string END_DELAY_TIME = "";
		public string END_DELAY_TIME_ZONE = "";
		public string DELAY_DURATION = "";
		public string CREW_ID = "";
		public string CREW_LINE_SEGMENT = "";
		public string FREE_FORM_TEXT = "";
		public string FIELD_1 = "";
		public string FIELD_2 = "";
		public string FIELD_3 = "";
		public string FIELD_4 = "";
		public string FIELD_5 = "";
		public string FIELD_6 = "";
		public string FIELD_7 = "";
		public string FIELD_8 = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainDelay", IsNullable = false)]
	public partial class NS_TrainDelay_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainDelayHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainDelayCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("FROM_DIVISION_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FROM_DIVISION_NUMBER_48[] FROM_DIVISION_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("FROM_DIVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FROM_DIVISION_48[] FROM_DIVISION;

		[System.Xml.Serialization.XmlElementAttribute("FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FROM_DISTRICT_48[] FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("FROM_LOCATION_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FROM_LOCATION_TYPE_48[] FROM_LOCATION_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FROM_LOCATION_48[] FROM_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("END_DIVISION_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DIVISION_NUMBER_48[] END_DIVISION_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("END_DIVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DIVISION_48[] END_DIVISION;

		[System.Xml.Serialization.XmlElementAttribute("END_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DISTRICT_48[] END_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("END_LOCATION_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_LOCATION_TYPE_48[] END_LOCATION_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("END_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_LOCATION_48[] END_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("DELAY_RECORD_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_DELAY_RECORD_ID_48[] DELAY_RECORD_ID;

		[System.Xml.Serialization.XmlElementAttribute("DELAY_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_DELAY_CODE_48[] DELAY_CODE;

		[System.Xml.Serialization.XmlElementAttribute("TRANSMISSION_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_TRANSMISSION_TYPE_48[] TRANSMISSION_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_USER_ID_48[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("SOURCE_SYSTEM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_SOURCE_SYSTEM_48[] SOURCE_SYSTEM;

		[System.Xml.Serialization.XmlElementAttribute("BEGIN_DELAY_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_BEGIN_DELAY_DATE_48[] BEGIN_DELAY_DATE;

		[System.Xml.Serialization.XmlElementAttribute("BEGIN_DELAY_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_48[] BEGIN_DELAY_TIME;

		[System.Xml.Serialization.XmlElementAttribute("BEGIN_DELAY_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_ZONE_48[] BEGIN_DELAY_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("END_DELAY_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DELAY_DATE_48[] END_DELAY_DATE;

		[System.Xml.Serialization.XmlElementAttribute("END_DELAY_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DELAY_TIME_48[] END_DELAY_TIME;

		[System.Xml.Serialization.XmlElementAttribute("END_DELAY_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_END_DELAY_TIME_ZONE_48[] END_DELAY_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("DELAY_DURATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_DELAY_DURATION_48[] DELAY_DURATION;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_CREW_ID_48[] CREW_ID;

		[System.Xml.Serialization.XmlElementAttribute("CREW_LINE_SEGMENT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_CREW_LINE_SEGMENT_48[] CREW_LINE_SEGMENT;

		[System.Xml.Serialization.XmlElementAttribute("FREE_FORM_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FREE_FORM_TEXT_48[] FREE_FORM_TEXT;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_1_48[] FIELD_1;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_2_48[] FIELD_2;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_3", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_3_48[] FIELD_3;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_4", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_4_48[] FIELD_4;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_5", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_5_48[] FIELD_5;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_6", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_6_48[] FIELD_6;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_7", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_7_48[] FIELD_7;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_8", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainDelayCONTENT_FIELD_8_48[] FIELD_8;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FROM_DIVISION_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FROM_DIVISION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FROM_DISTRICT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FROM_LOCATION_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FROM_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DIVISION_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DIVISION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DISTRICT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_LOCATION_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_DELAY_RECORD_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_DELAY_CODE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_TRANSMISSION_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_USER_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_SOURCE_SYSTEM_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_BEGIN_DELAY_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_BEGIN_DELAY_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DELAY_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DELAY_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_END_DELAY_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_DELAY_DURATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_CREW_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_CREW_LINE_SEGMENT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FREE_FORM_TEXT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_1_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_2_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_3_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_4_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_5_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_6_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_7_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainDelayCONTENT_FIELD_8_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}