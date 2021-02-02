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
	public partial class MIS_NS_CrewMember_48 {
		public MIS_NS_CrewMemberHEADER_48 HEADER;
		public MIS_NS_CrewMemberCONTENT_48 CONTENT;

		public static MIS_NS_CrewMember_48 fromSerializableObject(NS_CrewMember_48 message) {
			MIS_NS_CrewMember_48 ns_crewmember_48 = new MIS_NS_CrewMember_48();
			NS_CrewMemberHEADER_48 header = null;
			NS_CrewMemberCONTENT_48 content = null;
			header = (NS_CrewMemberHEADER_48) message.Items[0];
			content = (NS_CrewMemberCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_CrewMemberHEADER_48 messageheader = new MIS_NS_CrewMemberHEADER_48();

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

				ns_crewmember_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_CrewMemberCONTENT_48 messagecontent = new MIS_NS_CrewMemberCONTENT_48();

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

				if (content.CREW_ID != null) {
					messagecontent.CREW_ID = content.CREW_ID[0].Value;
					if (messagecontent.CREW_ID != null) {
						if (messagecontent.CREW_ID.Length < 1 || messagecontent.CREW_ID.Length > 10) {
							Ranorex.Report.Failure("Field CREW_ID expected to be length between or equal to 1 and 10, has length of {" + messagecontent.CREW_ID.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field CREW_ID is a Mandatory field but was found to be missing from the message");
				}

				if (content.CREW_LINE_SEGMENT != null) {
					messagecontent.CREW_LINE_SEGMENT = content.CREW_LINE_SEGMENT[0].Value;
					if (messagecontent.CREW_LINE_SEGMENT != null) {
						if (messagecontent.CREW_LINE_SEGMENT.Length < 1 || messagecontent.CREW_LINE_SEGMENT.Length > 2) {
							Ranorex.Report.Failure("Field CREW_LINE_SEGMENT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.CREW_LINE_SEGMENT.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field CREW_LINE_SEGMENT is a Mandatory field but was found to be missing from the message");
				}

				if (content.SEQUENCE_NUMBER != null) {
					messagecontent.SEQUENCE_NUMBER = content.SEQUENCE_NUMBER[0].Value;
					if (messagecontent.SEQUENCE_NUMBER != null) {
						if (messagecontent.SEQUENCE_NUMBER.Length < 1 || messagecontent.SEQUENCE_NUMBER.Length > 3) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be length between or equal to 1 and 3, has length of {" + messagecontent.SEQUENCE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SEQUENCE_NUMBER)) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be Numeric, has value of {" + messagecontent.SEQUENCE_NUMBER + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SEQUENCE_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.NUMBER_OF_CREW_MEMBERS != null) {
					messagecontent.NUMBER_OF_CREW_MEMBERS = content.NUMBER_OF_CREW_MEMBERS[0].Value;
					if (messagecontent.NUMBER_OF_CREW_MEMBERS != null) {
						if (messagecontent.NUMBER_OF_CREW_MEMBERS.Length != 1) {
							Ranorex.Report.Failure("Field NUMBER_OF_CREW_MEMBERS expected to be length of 1, has length of {" + messagecontent.NUMBER_OF_CREW_MEMBERS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_CREW_MEMBERS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_CREW_MEMBERS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_CREW_MEMBERS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_CREW_MEMBERS);
							if (intConvertedValue < 0 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field NUMBER_OF_CREW_MEMBERS expected to have value between 0 and 9, but was found to have a value of " + messagecontent.NUMBER_OF_CREW_MEMBERS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_CREW_MEMBERS is a Mandatory field but was found to be missing from the message");
				}
				if (content.CREW_MEMBER_RECORD != null) {
					for (int i = 0; i < content.CREW_MEMBER_RECORD.Length; i++) {
						MIS_NS_CrewMemberCREW_MEMBER_RECORD_48 crew_member_record = new MIS_NS_CrewMemberCREW_MEMBER_RECORD_48();

						if (content.CREW_MEMBER_RECORD[i].ON_DUTY_LOCATION != null) {
							crew_member_record.ON_DUTY_LOCATION = content.CREW_MEMBER_RECORD[i].ON_DUTY_LOCATION[0].Value;
							if (crew_member_record.ON_DUTY_LOCATION != null) {
								if (crew_member_record.ON_DUTY_LOCATION.Length < 1 || crew_member_record.ON_DUTY_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field ON_DUTY_LOCATION expected to be length between or equal to 1 and 6, has length of {" + crew_member_record.ON_DUTY_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_DUTY_LOCATION != null) {
							crew_member_record.OFF_DUTY_LOCATION = content.CREW_MEMBER_RECORD[i].OFF_DUTY_LOCATION[0].Value;
							if (crew_member_record.OFF_DUTY_LOCATION != null) {
								if (crew_member_record.OFF_DUTY_LOCATION.Length < 1 || crew_member_record.OFF_DUTY_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field OFF_DUTY_LOCATION expected to be length between or equal to 1 and 6, has length of {" + crew_member_record.OFF_DUTY_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_LOCATION != null) {
							crew_member_record.ON_TRAIN_LOCATION = content.CREW_MEMBER_RECORD[i].ON_TRAIN_LOCATION[0].Value;
							if (crew_member_record.ON_TRAIN_LOCATION != null) {
								if (crew_member_record.ON_TRAIN_LOCATION.Length < 1 || crew_member_record.ON_TRAIN_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field ON_TRAIN_LOCATION expected to be length between or equal to 1 and 6, has length of {" + crew_member_record.ON_TRAIN_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_PASS_COUNT != null) {
							crew_member_record.ON_TRAIN_PASS_COUNT = content.CREW_MEMBER_RECORD[i].ON_TRAIN_PASS_COUNT[0].Value;
							if (crew_member_record.ON_TRAIN_PASS_COUNT != null) {
								if (crew_member_record.ON_TRAIN_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field ON_TRAIN_PASS_COUNT expected to be length of 1, has length of {" + crew_member_record.ON_TRAIN_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.ON_TRAIN_PASS_COUNT)) {
									Ranorex.Report.Failure("Field ON_TRAIN_PASS_COUNT expected to be Numeric, has value of {" + crew_member_record.ON_TRAIN_PASS_COUNT + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_LOCATION_MP != null) {
							crew_member_record.ON_TRAIN_LOCATION_MP = content.CREW_MEMBER_RECORD[i].ON_TRAIN_LOCATION_MP[0].Value;
							if (crew_member_record.ON_TRAIN_LOCATION_MP != null) {
								if (crew_member_record.ON_TRAIN_LOCATION_MP.Length < 1 || crew_member_record.ON_TRAIN_LOCATION_MP.Length > 8) {
									Ranorex.Report.Failure("Field ON_TRAIN_LOCATION_MP expected to be length between or equal to 1 and 8, has length of {" + crew_member_record.ON_TRAIN_LOCATION_MP.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_LOCATION != null) {
							crew_member_record.OFF_TRAIN_LOCATION = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_LOCATION[0].Value;
							if (crew_member_record.OFF_TRAIN_LOCATION != null) {
								if (crew_member_record.OFF_TRAIN_LOCATION.Length < 1 || crew_member_record.OFF_TRAIN_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field OFF_TRAIN_LOCATION expected to be length between or equal to 1 and 6, has length of {" + crew_member_record.OFF_TRAIN_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_PASS_COUNT != null) {
							crew_member_record.OFF_TRAIN_PASS_COUNT = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_PASS_COUNT[0].Value;
							if (crew_member_record.OFF_TRAIN_PASS_COUNT != null) {
								if (crew_member_record.OFF_TRAIN_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field OFF_TRAIN_PASS_COUNT expected to be length of 1, has length of {" + crew_member_record.OFF_TRAIN_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.OFF_TRAIN_PASS_COUNT)) {
									Ranorex.Report.Failure("Field OFF_TRAIN_PASS_COUNT expected to be Numeric, has value of {" + crew_member_record.OFF_TRAIN_PASS_COUNT + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_LOCATION_MP != null) {
							crew_member_record.OFF_TRAIN_LOCATION_MP = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_LOCATION_MP[0].Value;
							if (crew_member_record.OFF_TRAIN_LOCATION_MP != null) {
								if (crew_member_record.OFF_TRAIN_LOCATION_MP.Length < 1 || crew_member_record.OFF_TRAIN_LOCATION_MP.Length > 8) {
									Ranorex.Report.Failure("Field OFF_TRAIN_LOCATION_MP expected to be length between or equal to 1 and 8, has length of {" + crew_member_record.OFF_TRAIN_LOCATION_MP.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].CREW_POSITION != null) {
							crew_member_record.CREW_POSITION = content.CREW_MEMBER_RECORD[i].CREW_POSITION[0].Value;
							if (crew_member_record.CREW_POSITION != null) {
								if (crew_member_record.CREW_POSITION.Length != 2) {
									Ranorex.Report.Failure("Field CREW_POSITION expected to be length of 2, has length of {" + crew_member_record.CREW_POSITION.Length.ToString() + "}.");
								}
								if (crew_member_record.CREW_POSITION != "EN" && crew_member_record.CREW_POSITION != "CO" && crew_member_record.CREW_POSITION != "FI" && crew_member_record.CREW_POSITION != "SE" && crew_member_record.CREW_POSITION != "B1" && crew_member_record.CREW_POSITION != "B2" && crew_member_record.CREW_POSITION != "TT" && crew_member_record.CREW_POSITION != "CT" && crew_member_record.CREW_POSITION != "ET") {
									Ranorex.Report.Failure("Field CREW_POSITION expected to be one of the following values {EN, CO, FI, SE, B1, B2, TT, CT, ET}, but was found to be {" + crew_member_record.CREW_POSITION + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field CREW_POSITION is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].CREW_MEMBER_TYPE != null) {
							crew_member_record.CREW_MEMBER_TYPE = content.CREW_MEMBER_RECORD[i].CREW_MEMBER_TYPE[0].Value;
							if (crew_member_record.CREW_MEMBER_TYPE != null) {
								if (crew_member_record.CREW_MEMBER_TYPE.Length != 2) {
									Ranorex.Report.Failure("Field CREW_MEMBER_TYPE expected to be length of 2, has length of {" + crew_member_record.CREW_MEMBER_TYPE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.CREW_MEMBER_TYPE)) {
									Ranorex.Report.Failure("Field CREW_MEMBER_TYPE expected to be Alphabetic, has value of {" + crew_member_record.CREW_MEMBER_TYPE + "}.");
								}
								if (crew_member_record.CREW_MEMBER_TYPE != "DH" && crew_member_record.CREW_MEMBER_TYPE != "RC" && crew_member_record.CREW_MEMBER_TYPE != "WK") {
									Ranorex.Report.Failure("Field CREW_MEMBER_TYPE expected to be one of the following values {DH, RC, WK}, but was found to be {" + crew_member_record.CREW_MEMBER_TYPE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field CREW_MEMBER_TYPE is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].FIRST_INITIAL != null) {
							crew_member_record.FIRST_INITIAL = content.CREW_MEMBER_RECORD[i].FIRST_INITIAL[0].Value;
							if (crew_member_record.FIRST_INITIAL != null) {
								if (crew_member_record.FIRST_INITIAL.Length != 1) {
									Ranorex.Report.Failure("Field FIRST_INITIAL expected to be length of 1, has length of {" + crew_member_record.FIRST_INITIAL.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.FIRST_INITIAL)) {
									Ranorex.Report.Failure("Field FIRST_INITIAL expected to be Alphabetic, has value of {" + crew_member_record.FIRST_INITIAL + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field FIRST_INITIAL is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].MIDDLE_INITIAL != null) {
							crew_member_record.MIDDLE_INITIAL = content.CREW_MEMBER_RECORD[i].MIDDLE_INITIAL[0].Value;
							if (crew_member_record.MIDDLE_INITIAL != null) {
								if (crew_member_record.MIDDLE_INITIAL.Length != 1) {
									Ranorex.Report.Failure("Field MIDDLE_INITIAL expected to be length of 1, has length of {" + crew_member_record.MIDDLE_INITIAL.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.MIDDLE_INITIAL)) {
									Ranorex.Report.Failure("Field MIDDLE_INITIAL expected to be Alphabetic, has value of {" + crew_member_record.MIDDLE_INITIAL + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].LAST_NAME != null) {
							crew_member_record.LAST_NAME = content.CREW_MEMBER_RECORD[i].LAST_NAME[0].Value;
							if (crew_member_record.LAST_NAME != null) {
								if (crew_member_record.LAST_NAME.Length < 1 || crew_member_record.LAST_NAME.Length > 15) {
									Ranorex.Report.Failure("Field LAST_NAME expected to be length between or equal to 1 and 15, has length of {" + crew_member_record.LAST_NAME.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field LAST_NAME is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].SOCIAL_SECURITY_NO != null) {
							crew_member_record.SOCIAL_SECURITY_NO = content.CREW_MEMBER_RECORD[i].SOCIAL_SECURITY_NO[0].Value;
							if (crew_member_record.SOCIAL_SECURITY_NO != null) {
								if (crew_member_record.SOCIAL_SECURITY_NO.Length != 9) {
									Ranorex.Report.Failure("Field SOCIAL_SECURITY_NO expected to be length of 9, has length of {" + crew_member_record.SOCIAL_SECURITY_NO.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.SOCIAL_SECURITY_NO)) {
									Ranorex.Report.Failure("Field SOCIAL_SECURITY_NO expected to be Numeric, has value of {" + crew_member_record.SOCIAL_SECURITY_NO + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].EMPLOYEE_ID != null) {
							crew_member_record.EMPLOYEE_ID = content.CREW_MEMBER_RECORD[i].EMPLOYEE_ID[0].Value;
							if (crew_member_record.EMPLOYEE_ID != null) {
								if (crew_member_record.EMPLOYEE_ID.Length < 1 || crew_member_record.EMPLOYEE_ID.Length > 9) {
									Ranorex.Report.Failure("Field EMPLOYEE_ID expected to be length between or equal to 1 and 9, has length of {" + crew_member_record.EMPLOYEE_ID.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_DUTY_DATE != null) {
							crew_member_record.ON_DUTY_DATE = content.CREW_MEMBER_RECORD[i].ON_DUTY_DATE[0].Value;
							if (crew_member_record.ON_DUTY_DATE != null) {
								if (crew_member_record.ON_DUTY_DATE.Length != 8) {
									Ranorex.Report.Failure("Field ON_DUTY_DATE expected to be length of 8, has length of {" + crew_member_record.ON_DUTY_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.ON_DUTY_DATE)) {
									Ranorex.Report.Failure("Field ON_DUTY_DATE expected to be Numeric, has value of {" + crew_member_record.ON_DUTY_DATE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ON_DUTY_DATE is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].ON_DUTY_TIME != null) {
							crew_member_record.ON_DUTY_TIME = content.CREW_MEMBER_RECORD[i].ON_DUTY_TIME[0].Value;
							if (crew_member_record.ON_DUTY_TIME != null) {
								if (crew_member_record.ON_DUTY_TIME.Length != 4) {
									Ranorex.Report.Failure("Field ON_DUTY_TIME expected to be length of 4, has length of {" + crew_member_record.ON_DUTY_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.ON_DUTY_TIME)) {
									Ranorex.Report.Failure("Field ON_DUTY_TIME expected to be Numeric, has value of {" + crew_member_record.ON_DUTY_TIME + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ON_DUTY_TIME is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].ON_DUTY_TIME_ZONE != null) {
							crew_member_record.ON_DUTY_TIME_ZONE = content.CREW_MEMBER_RECORD[i].ON_DUTY_TIME_ZONE[0].Value;
							if (crew_member_record.ON_DUTY_TIME_ZONE != null) {
								if (crew_member_record.ON_DUTY_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field ON_DUTY_TIME_ZONE expected to be length of 1, has length of {" + crew_member_record.ON_DUTY_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.ON_DUTY_TIME_ZONE)) {
									Ranorex.Report.Failure("Field ON_DUTY_TIME_ZONE expected to be Alphabetic, has value of {" + crew_member_record.ON_DUTY_TIME_ZONE + "}.");
								}
								if (crew_member_record.ON_DUTY_TIME_ZONE != "E" && crew_member_record.ON_DUTY_TIME_ZONE != "C") {
									Ranorex.Report.Failure("Field ON_DUTY_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + crew_member_record.ON_DUTY_TIME_ZONE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ON_DUTY_TIME_ZONE is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_DATE != null) {
							crew_member_record.ON_TRAIN_DATE = content.CREW_MEMBER_RECORD[i].ON_TRAIN_DATE[0].Value;
							if (crew_member_record.ON_TRAIN_DATE != null) {
								if (crew_member_record.ON_TRAIN_DATE.Length != 8) {
									Ranorex.Report.Failure("Field ON_TRAIN_DATE expected to be length of 8, has length of {" + crew_member_record.ON_TRAIN_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.ON_TRAIN_DATE)) {
									Ranorex.Report.Failure("Field ON_TRAIN_DATE expected to be Numeric, has value of {" + crew_member_record.ON_TRAIN_DATE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_TIME != null) {
							crew_member_record.ON_TRAIN_TIME = content.CREW_MEMBER_RECORD[i].ON_TRAIN_TIME[0].Value;
							if (crew_member_record.ON_TRAIN_TIME != null) {
								if (crew_member_record.ON_TRAIN_TIME.Length != 4) {
									Ranorex.Report.Failure("Field ON_TRAIN_TIME expected to be length of 4, has length of {" + crew_member_record.ON_TRAIN_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.ON_TRAIN_TIME)) {
									Ranorex.Report.Failure("Field ON_TRAIN_TIME expected to be Numeric, has value of {" + crew_member_record.ON_TRAIN_TIME + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].ON_TRAIN_TIME_ZONE != null) {
							crew_member_record.ON_TRAIN_TIME_ZONE = content.CREW_MEMBER_RECORD[i].ON_TRAIN_TIME_ZONE[0].Value;
							if (crew_member_record.ON_TRAIN_TIME_ZONE != null) {
								if (crew_member_record.ON_TRAIN_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field ON_TRAIN_TIME_ZONE expected to be length of 1, has length of {" + crew_member_record.ON_TRAIN_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.ON_TRAIN_TIME_ZONE)) {
									Ranorex.Report.Failure("Field ON_TRAIN_TIME_ZONE expected to be Alphabetic, has value of {" + crew_member_record.ON_TRAIN_TIME_ZONE + "}.");
								}
								if (crew_member_record.ON_TRAIN_TIME_ZONE != "E" && crew_member_record.ON_TRAIN_TIME_ZONE != "C") {
									Ranorex.Report.Failure("Field ON_TRAIN_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + crew_member_record.ON_TRAIN_TIME_ZONE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].HOS_EXPIRE_DATE != null) {
							crew_member_record.HOS_EXPIRE_DATE = content.CREW_MEMBER_RECORD[i].HOS_EXPIRE_DATE[0].Value;
							if (crew_member_record.HOS_EXPIRE_DATE != null) {
								if (crew_member_record.HOS_EXPIRE_DATE.Length != 8) {
									Ranorex.Report.Failure("Field HOS_EXPIRE_DATE expected to be length of 8, has length of {" + crew_member_record.HOS_EXPIRE_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.HOS_EXPIRE_DATE)) {
									Ranorex.Report.Failure("Field HOS_EXPIRE_DATE expected to be Numeric, has value of {" + crew_member_record.HOS_EXPIRE_DATE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field HOS_EXPIRE_DATE is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].HOS_EXPIRE_TIME != null) {
							crew_member_record.HOS_EXPIRE_TIME = content.CREW_MEMBER_RECORD[i].HOS_EXPIRE_TIME[0].Value;
							if (crew_member_record.HOS_EXPIRE_TIME != null) {
								if (crew_member_record.HOS_EXPIRE_TIME.Length != 4) {
									Ranorex.Report.Failure("Field HOS_EXPIRE_TIME expected to be length of 4, has length of {" + crew_member_record.HOS_EXPIRE_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.HOS_EXPIRE_TIME)) {
									Ranorex.Report.Failure("Field HOS_EXPIRE_TIME expected to be Numeric, has value of {" + crew_member_record.HOS_EXPIRE_TIME + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field HOS_EXPIRE_TIME is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].HOS_TIME_ZONE != null) {
							crew_member_record.HOS_TIME_ZONE = content.CREW_MEMBER_RECORD[i].HOS_TIME_ZONE[0].Value;
							if (crew_member_record.HOS_TIME_ZONE != null) {
								if (crew_member_record.HOS_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field HOS_TIME_ZONE expected to be length of 1, has length of {" + crew_member_record.HOS_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.HOS_TIME_ZONE)) {
									Ranorex.Report.Failure("Field HOS_TIME_ZONE expected to be Alphabetic, has value of {" + crew_member_record.HOS_TIME_ZONE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field HOS_TIME_ZONE is a Mandatory field but was found to be missing from the message");
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_DUTY_DATE != null) {
							crew_member_record.OFF_DUTY_DATE = content.CREW_MEMBER_RECORD[i].OFF_DUTY_DATE[0].Value;
							if (crew_member_record.OFF_DUTY_DATE != null) {
								if (crew_member_record.OFF_DUTY_DATE.Length != 8) {
									Ranorex.Report.Failure("Field OFF_DUTY_DATE expected to be length of 8, has length of {" + crew_member_record.OFF_DUTY_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.OFF_DUTY_DATE)) {
									Ranorex.Report.Failure("Field OFF_DUTY_DATE expected to be Numeric, has value of {" + crew_member_record.OFF_DUTY_DATE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_DUTY_TIME != null) {
							crew_member_record.OFF_DUTY_TIME = content.CREW_MEMBER_RECORD[i].OFF_DUTY_TIME[0].Value;
							if (crew_member_record.OFF_DUTY_TIME != null) {
								if (crew_member_record.OFF_DUTY_TIME.Length != 4) {
									Ranorex.Report.Failure("Field OFF_DUTY_TIME expected to be length of 4, has length of {" + crew_member_record.OFF_DUTY_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.OFF_DUTY_TIME)) {
									Ranorex.Report.Failure("Field OFF_DUTY_TIME expected to be Numeric, has value of {" + crew_member_record.OFF_DUTY_TIME + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_DUTY_TIME_ZONE != null) {
							crew_member_record.OFF_DUTY_TIME_ZONE = content.CREW_MEMBER_RECORD[i].OFF_DUTY_TIME_ZONE[0].Value;
							if (crew_member_record.OFF_DUTY_TIME_ZONE != null) {
								if (crew_member_record.OFF_DUTY_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field OFF_DUTY_TIME_ZONE expected to be length of 1, has length of {" + crew_member_record.OFF_DUTY_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.OFF_DUTY_TIME_ZONE)) {
									Ranorex.Report.Failure("Field OFF_DUTY_TIME_ZONE expected to be Alphabetic, has value of {" + crew_member_record.OFF_DUTY_TIME_ZONE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_DATE != null) {
							crew_member_record.OFF_TRAIN_DATE = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_DATE[0].Value;
							if (crew_member_record.OFF_TRAIN_DATE != null) {
								if (crew_member_record.OFF_TRAIN_DATE.Length != 8) {
									Ranorex.Report.Failure("Field OFF_TRAIN_DATE expected to be length of 8, has length of {" + crew_member_record.OFF_TRAIN_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.OFF_TRAIN_DATE)) {
									Ranorex.Report.Failure("Field OFF_TRAIN_DATE expected to be Numeric, has value of {" + crew_member_record.OFF_TRAIN_DATE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_TIME != null) {
							crew_member_record.OFF_TRAIN_TIME = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_TIME[0].Value;
							if (crew_member_record.OFF_TRAIN_TIME != null) {
								if (crew_member_record.OFF_TRAIN_TIME.Length != 4) {
									Ranorex.Report.Failure("Field OFF_TRAIN_TIME expected to be length of 4, has length of {" + crew_member_record.OFF_TRAIN_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.OFF_TRAIN_TIME)) {
									Ranorex.Report.Failure("Field OFF_TRAIN_TIME expected to be Numeric, has value of {" + crew_member_record.OFF_TRAIN_TIME + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].OFF_TRAIN_TIME_ZONE != null) {
							crew_member_record.OFF_TRAIN_TIME_ZONE = content.CREW_MEMBER_RECORD[i].OFF_TRAIN_TIME_ZONE[0].Value;
							if (crew_member_record.OFF_TRAIN_TIME_ZONE != null) {
								if (crew_member_record.OFF_TRAIN_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field OFF_TRAIN_TIME_ZONE expected to be length of 1, has length of {" + crew_member_record.OFF_TRAIN_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.OFF_TRAIN_TIME_ZONE)) {
									Ranorex.Report.Failure("Field OFF_TRAIN_TIME_ZONE expected to be Alphabetic, has value of {" + crew_member_record.OFF_TRAIN_TIME_ZONE + "}.");
								}
								if (crew_member_record.OFF_TRAIN_TIME_ZONE != "E" && crew_member_record.OFF_TRAIN_TIME_ZONE != "C") {
									Ranorex.Report.Failure("Field OFF_TRAIN_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + crew_member_record.OFF_TRAIN_TIME_ZONE + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SCAC != null) {
							crew_member_record.DEST_TRAIN_SCAC = content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SCAC[0].Value;
							if (crew_member_record.DEST_TRAIN_SCAC != null) {
								if (crew_member_record.DEST_TRAIN_SCAC.Length < 1 || crew_member_record.DEST_TRAIN_SCAC.Length > 4) {
									Ranorex.Report.Failure("Field DEST_TRAIN_SCAC expected to be length between or equal to 1 and 4, has length of {" + crew_member_record.DEST_TRAIN_SCAC.Length.ToString() + "}.");
								}
								if (ContainsDigits(crew_member_record.DEST_TRAIN_SCAC)) {
									Ranorex.Report.Failure("Field DEST_TRAIN_SCAC expected to be Alphabetic, has value of {" + crew_member_record.DEST_TRAIN_SCAC + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SECTION != null) {
							crew_member_record.DEST_TRAIN_SECTION = content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SECTION[0].Value;
							if (crew_member_record.DEST_TRAIN_SECTION != null) {
								if (crew_member_record.DEST_TRAIN_SECTION.Length < 0 || crew_member_record.DEST_TRAIN_SECTION.Length > 1) {
									Ranorex.Report.Failure("Field DEST_TRAIN_SECTION expected to be length between or equal to 0 and 1, has length of {" + crew_member_record.DEST_TRAIN_SECTION.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.DEST_TRAIN_SECTION)) {
									Ranorex.Report.Failure("Field DEST_TRAIN_SECTION expected to be Numeric, has value of {" + crew_member_record.DEST_TRAIN_SECTION + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SYMBOL != null) {
							crew_member_record.DEST_TRAIN_SYMBOL = content.CREW_MEMBER_RECORD[i].DEST_TRAIN_SYMBOL[0].Value;
							if (crew_member_record.DEST_TRAIN_SYMBOL != null) {
								if (crew_member_record.DEST_TRAIN_SYMBOL.Length < 1 || crew_member_record.DEST_TRAIN_SYMBOL.Length > 10) {
									Ranorex.Report.Failure("Field DEST_TRAIN_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + crew_member_record.DEST_TRAIN_SYMBOL.Length.ToString() + "}.");
								}
							}
						}

						if (content.CREW_MEMBER_RECORD[i].DEST_TRAIN_ORIGIN_DATE != null) {
							crew_member_record.DEST_TRAIN_ORIGIN_DATE = content.CREW_MEMBER_RECORD[i].DEST_TRAIN_ORIGIN_DATE[0].Value;
							if (crew_member_record.DEST_TRAIN_ORIGIN_DATE != null) {
								if (crew_member_record.DEST_TRAIN_ORIGIN_DATE.Length != 8) {
									Ranorex.Report.Failure("Field DEST_TRAIN_ORIGIN_DATE expected to be length of 8, has length of {" + crew_member_record.DEST_TRAIN_ORIGIN_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(crew_member_record.DEST_TRAIN_ORIGIN_DATE)) {
									Ranorex.Report.Failure("Field DEST_TRAIN_ORIGIN_DATE expected to be Numeric, has value of {" + crew_member_record.DEST_TRAIN_ORIGIN_DATE + "}.");
								}
							}
						}

						messagecontent.addCREW_MEMBER_RECORD(crew_member_record);
					}
				} else {
					Ranorex.Report.Failure("Field CREW_MEMBER_RECORD is a Mandatory field but was found to be missing from the message");
				}

				ns_crewmember_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_crewmember_48;
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

		public static void createNS_CrewMember_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_crew_id,
			string content_crew_line_segment,
			string content_sequence_number,
			string content_number_of_crew_members,
			string content_crew_member_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_CrewMember_48 mis_ns_crewmember = buildMIS_NS_CrewMember_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_crew_id, content_crew_line_segment, content_sequence_number, content_number_of_crew_members, content_crew_member_record);

			NS_CrewMember_48 ns_crewmember = mis_ns_crewmember.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_CrewMember_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_crewmember);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_crewmember.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_crewmember.toSteMessageHeader(request, true);
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

		public static MIS_NS_CrewMember_48 buildMIS_NS_CrewMember_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_crew_id,
			string content_crew_line_segment,
			string content_sequence_number,
			string content_number_of_crew_members,
			string content_crew_member_record
		) {

			MIS_NS_CrewMember_48 mis_ns_crewmember = new MIS_NS_CrewMember_48();

			MIS_NS_CrewMemberHEADER_48 header = new MIS_NS_CrewMemberHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_CrewMemberCONTENT_48 content = new MIS_NS_CrewMemberCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.CREW_ID = content_crew_id;
			content.CREW_LINE_SEGMENT = content_crew_line_segment;
			content.SEQUENCE_NUMBER = content_sequence_number;
			content.NUMBER_OF_CREW_MEMBERS = content_number_of_crew_members;
			if (content_crew_member_record != "") {
				string[] crew_member_recordList = content_crew_member_record.Split('|');
				for (int i = 0; i < crew_member_recordList.Length;) {
					MIS_NS_CrewMemberCREW_MEMBER_RECORD_48 crew_member_records = new MIS_NS_CrewMemberCREW_MEMBER_RECORD_48();
					crew_member_records.ON_DUTY_LOCATION = crew_member_recordList[i];i++;
					crew_member_records.OFF_DUTY_LOCATION = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_LOCATION = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_PASS_COUNT = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_LOCATION_MP = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_LOCATION = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_PASS_COUNT = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_LOCATION_MP = crew_member_recordList[i];i++;
					crew_member_records.CREW_POSITION = crew_member_recordList[i];i++;
					crew_member_records.CREW_MEMBER_TYPE = crew_member_recordList[i];i++;
					crew_member_records.FIRST_INITIAL = crew_member_recordList[i];i++;
					crew_member_records.MIDDLE_INITIAL = crew_member_recordList[i];i++;
					crew_member_records.LAST_NAME = crew_member_recordList[i];i++;
					crew_member_records.SOCIAL_SECURITY_NO = crew_member_recordList[i];i++;
					crew_member_records.EMPLOYEE_ID = crew_member_recordList[i];i++;
					crew_member_records.ON_DUTY_DATE = crew_member_recordList[i];i++;
					crew_member_records.ON_DUTY_TIME = crew_member_recordList[i];i++;
					crew_member_records.ON_DUTY_TIME_ZONE = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_DATE = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_TIME = crew_member_recordList[i];i++;
					crew_member_records.ON_TRAIN_TIME_ZONE = crew_member_recordList[i];i++;
					crew_member_records.HOS_EXPIRE_DATE = crew_member_recordList[i];i++;
					crew_member_records.HOS_EXPIRE_TIME = crew_member_recordList[i];i++;
					crew_member_records.HOS_TIME_ZONE = crew_member_recordList[i];i++;
					crew_member_records.OFF_DUTY_DATE = crew_member_recordList[i];i++;
					crew_member_records.OFF_DUTY_TIME = crew_member_recordList[i];i++;
					crew_member_records.OFF_DUTY_TIME_ZONE = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_DATE = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_TIME = crew_member_recordList[i];i++;
					crew_member_records.OFF_TRAIN_TIME_ZONE = crew_member_recordList[i];i++;
					crew_member_records.DEST_TRAIN_SCAC = crew_member_recordList[i];i++;
					crew_member_records.DEST_TRAIN_SECTION = crew_member_recordList[i];i++;
					crew_member_records.DEST_TRAIN_SYMBOL = crew_member_recordList[i];i++;
					crew_member_records.DEST_TRAIN_ORIGIN_DATE = crew_member_recordList[i];i++;
					content.addCREW_MEMBER_RECORD(crew_member_records);
				}
			}

			mis_ns_crewmember.HEADER = header;
			mis_ns_crewmember.CONTENT = content;
			return mis_ns_crewmember;
		}

		public NS_CrewMember_48 toSerializableObject() {
			NS_CrewMember_48 ns_crewmember_48 = new NS_CrewMember_48();
			ns_crewmember_48.Items = new object[2];

			NS_CrewMemberHEADER_48 header = new NS_CrewMemberHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_CrewMemberHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_CrewMemberHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_CrewMemberHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_CrewMemberHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_CrewMemberHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_CrewMemberHEADER_TRACE_ID_48();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_CrewMemberHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_CrewMemberHEADER_MESSAGE_VERSION_48();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_CrewMemberCONTENT_48 content = new NS_CrewMemberCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_CrewMemberCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_CrewMemberCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_CrewMemberCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_CrewMemberCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_CrewMemberCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_CrewMemberCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_CrewMemberCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_CrewMemberCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.CREW_ID != "Null") {
					content.CREW_ID = new NS_CrewMemberCONTENT_CREW_ID_48[1];
					content.CREW_ID[0] = new NS_CrewMemberCONTENT_CREW_ID_48();
					content.CREW_ID[0].Value = CONTENT.CREW_ID;
				}

				if (CONTENT.CREW_LINE_SEGMENT != "Null") {
					content.CREW_LINE_SEGMENT = new NS_CrewMemberCONTENT_CREW_LINE_SEGMENT_48[1];
					content.CREW_LINE_SEGMENT[0] = new NS_CrewMemberCONTENT_CREW_LINE_SEGMENT_48();
					content.CREW_LINE_SEGMENT[0].Value = CONTENT.CREW_LINE_SEGMENT;
				}

				if (CONTENT.SEQUENCE_NUMBER != "Null") {
					content.SEQUENCE_NUMBER = new NS_CrewMemberCONTENT_SEQUENCE_NUMBER_48[1];
					content.SEQUENCE_NUMBER[0] = new NS_CrewMemberCONTENT_SEQUENCE_NUMBER_48();
					content.SEQUENCE_NUMBER[0].Value = CONTENT.SEQUENCE_NUMBER;
				}

				if (CONTENT.NUMBER_OF_CREW_MEMBERS != "Null") {
					content.NUMBER_OF_CREW_MEMBERS = new NS_CrewMemberCONTENT_NUMBER_OF_CREW_MEMBERS_48[1];
					content.NUMBER_OF_CREW_MEMBERS[0] = new NS_CrewMemberCONTENT_NUMBER_OF_CREW_MEMBERS_48();
					content.NUMBER_OF_CREW_MEMBERS[0].Value = CONTENT.NUMBER_OF_CREW_MEMBERS;
				}

				if (CONTENT.CREW_MEMBER_RECORD.Count != 0) {
					int crew_member_recordIndex = 0;
					content.CREW_MEMBER_RECORD = new NS_CrewMemberCONTENT_CREW_MEMBER_RECORD_48[CONTENT.CREW_MEMBER_RECORD.Count];
					foreach (MIS_NS_CrewMemberCREW_MEMBER_RECORD_48 CREW_MEMBER_RECORD in CONTENT.CREW_MEMBER_RECORD) {
						NS_CrewMemberCONTENT_CREW_MEMBER_RECORD_48 crew_member_record = new NS_CrewMemberCONTENT_CREW_MEMBER_RECORD_48();
						if (CREW_MEMBER_RECORD.ON_DUTY_LOCATION != null && CREW_MEMBER_RECORD.ON_DUTY_LOCATION != "") {
							crew_member_record.ON_DUTY_LOCATION = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_LOCATION_48[1];
							crew_member_record.ON_DUTY_LOCATION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_LOCATION_48();
							if (CREW_MEMBER_RECORD.ON_DUTY_LOCATION == "Empty") {
								crew_member_record.ON_DUTY_LOCATION[0].Value = "";
							} else {
								crew_member_record.ON_DUTY_LOCATION[0].Value = CREW_MEMBER_RECORD.ON_DUTY_LOCATION;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_DUTY_LOCATION != null && CREW_MEMBER_RECORD.OFF_DUTY_LOCATION != "") {
							crew_member_record.OFF_DUTY_LOCATION = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_LOCATION_48[1];
							crew_member_record.OFF_DUTY_LOCATION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_LOCATION_48();
							if (CREW_MEMBER_RECORD.OFF_DUTY_LOCATION == "Empty") {
								crew_member_record.OFF_DUTY_LOCATION[0].Value = "";
							} else {
								crew_member_record.OFF_DUTY_LOCATION[0].Value = CREW_MEMBER_RECORD.OFF_DUTY_LOCATION;
							}
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_LOCATION != null && CREW_MEMBER_RECORD.ON_TRAIN_LOCATION != "") {
							crew_member_record.ON_TRAIN_LOCATION = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_48[1];
							crew_member_record.ON_TRAIN_LOCATION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_LOCATION == "Empty") {
								crew_member_record.ON_TRAIN_LOCATION[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_LOCATION[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_LOCATION;
							}
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_PASS_COUNT != null && CREW_MEMBER_RECORD.ON_TRAIN_PASS_COUNT != "") {
							crew_member_record.ON_TRAIN_PASS_COUNT = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_PASS_COUNT_48[1];
							crew_member_record.ON_TRAIN_PASS_COUNT[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_PASS_COUNT_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_PASS_COUNT == "Empty") {
								crew_member_record.ON_TRAIN_PASS_COUNT[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_PASS_COUNT[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_PASS_COUNT;
							}
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_LOCATION_MP != null && CREW_MEMBER_RECORD.ON_TRAIN_LOCATION_MP != "") {
							crew_member_record.ON_TRAIN_LOCATION_MP = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_MP_48[1];
							crew_member_record.ON_TRAIN_LOCATION_MP[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_MP_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_LOCATION_MP == "Empty") {
								crew_member_record.ON_TRAIN_LOCATION_MP[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_LOCATION_MP[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_LOCATION_MP;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION != null && CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION != "") {
							crew_member_record.OFF_TRAIN_LOCATION = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_48[1];
							crew_member_record.OFF_TRAIN_LOCATION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION == "Empty") {
								crew_member_record.OFF_TRAIN_LOCATION[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_LOCATION[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_PASS_COUNT != null && CREW_MEMBER_RECORD.OFF_TRAIN_PASS_COUNT != "") {
							crew_member_record.OFF_TRAIN_PASS_COUNT = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_PASS_COUNT_48[1];
							crew_member_record.OFF_TRAIN_PASS_COUNT[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_PASS_COUNT_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_PASS_COUNT == "Empty") {
								crew_member_record.OFF_TRAIN_PASS_COUNT[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_PASS_COUNT[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_PASS_COUNT;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION_MP != null && CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION_MP != "") {
							crew_member_record.OFF_TRAIN_LOCATION_MP = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_MP_48[1];
							crew_member_record.OFF_TRAIN_LOCATION_MP[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_MP_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION_MP == "Empty") {
								crew_member_record.OFF_TRAIN_LOCATION_MP[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_LOCATION_MP[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_LOCATION_MP;
							}
						}

						if (CREW_MEMBER_RECORD.CREW_POSITION != "Null") {
							crew_member_record.CREW_POSITION = new NS_CrewMemberCREW_MEMBER_RECORD_CREW_POSITION_48[1];
							crew_member_record.CREW_POSITION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_CREW_POSITION_48();
							crew_member_record.CREW_POSITION[0].Value = CREW_MEMBER_RECORD.CREW_POSITION;
						}

						if (CREW_MEMBER_RECORD.CREW_MEMBER_TYPE != "Null") {
							crew_member_record.CREW_MEMBER_TYPE = new NS_CrewMemberCREW_MEMBER_RECORD_CREW_MEMBER_TYPE_48[1];
							crew_member_record.CREW_MEMBER_TYPE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_CREW_MEMBER_TYPE_48();
							crew_member_record.CREW_MEMBER_TYPE[0].Value = CREW_MEMBER_RECORD.CREW_MEMBER_TYPE;
						}

						if (CREW_MEMBER_RECORD.FIRST_INITIAL != "Null") {
							crew_member_record.FIRST_INITIAL = new NS_CrewMemberCREW_MEMBER_RECORD_FIRST_INITIAL_48[1];
							crew_member_record.FIRST_INITIAL[0] = new NS_CrewMemberCREW_MEMBER_RECORD_FIRST_INITIAL_48();
							crew_member_record.FIRST_INITIAL[0].Value = CREW_MEMBER_RECORD.FIRST_INITIAL;
						}

						if (CREW_MEMBER_RECORD.MIDDLE_INITIAL != null && CREW_MEMBER_RECORD.MIDDLE_INITIAL != "") {
							crew_member_record.MIDDLE_INITIAL = new NS_CrewMemberCREW_MEMBER_RECORD_MIDDLE_INITIAL_48[1];
							crew_member_record.MIDDLE_INITIAL[0] = new NS_CrewMemberCREW_MEMBER_RECORD_MIDDLE_INITIAL_48();
							if (CREW_MEMBER_RECORD.MIDDLE_INITIAL == "Empty") {
								crew_member_record.MIDDLE_INITIAL[0].Value = "";
							} else {
								crew_member_record.MIDDLE_INITIAL[0].Value = CREW_MEMBER_RECORD.MIDDLE_INITIAL;
							}
						}

						if (CREW_MEMBER_RECORD.LAST_NAME != "Null") {
							crew_member_record.LAST_NAME = new NS_CrewMemberCREW_MEMBER_RECORD_LAST_NAME_48[1];
							crew_member_record.LAST_NAME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_LAST_NAME_48();
							crew_member_record.LAST_NAME[0].Value = CREW_MEMBER_RECORD.LAST_NAME;
						}

						if (CREW_MEMBER_RECORD.SOCIAL_SECURITY_NO != null && CREW_MEMBER_RECORD.SOCIAL_SECURITY_NO != "") {
							crew_member_record.SOCIAL_SECURITY_NO = new NS_CrewMemberCREW_MEMBER_RECORD_SOCIAL_SECURITY_NO_48[1];
							crew_member_record.SOCIAL_SECURITY_NO[0] = new NS_CrewMemberCREW_MEMBER_RECORD_SOCIAL_SECURITY_NO_48();
							if (CREW_MEMBER_RECORD.SOCIAL_SECURITY_NO == "Empty") {
								crew_member_record.SOCIAL_SECURITY_NO[0].Value = "";
							} else {
								crew_member_record.SOCIAL_SECURITY_NO[0].Value = CREW_MEMBER_RECORD.SOCIAL_SECURITY_NO;
							}
						}

						if (CREW_MEMBER_RECORD.EMPLOYEE_ID != null && CREW_MEMBER_RECORD.EMPLOYEE_ID != "") {
							crew_member_record.EMPLOYEE_ID = new NS_CrewMemberCREW_MEMBER_RECORD_EMPLOYEE_ID_48[1];
							crew_member_record.EMPLOYEE_ID[0] = new NS_CrewMemberCREW_MEMBER_RECORD_EMPLOYEE_ID_48();
							if (CREW_MEMBER_RECORD.EMPLOYEE_ID == "Empty") {
								crew_member_record.EMPLOYEE_ID[0].Value = "";
							} else {
								crew_member_record.EMPLOYEE_ID[0].Value = CREW_MEMBER_RECORD.EMPLOYEE_ID;
							}
						}

						if (CREW_MEMBER_RECORD.ON_DUTY_DATE != "Null") {
							crew_member_record.ON_DUTY_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_DATE_48[1];
							crew_member_record.ON_DUTY_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_DATE_48();
							crew_member_record.ON_DUTY_DATE[0].Value = CREW_MEMBER_RECORD.ON_DUTY_DATE;
						}

						if (CREW_MEMBER_RECORD.ON_DUTY_TIME != "Null") {
							crew_member_record.ON_DUTY_TIME = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_48[1];
							crew_member_record.ON_DUTY_TIME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_48();
							crew_member_record.ON_DUTY_TIME[0].Value = CREW_MEMBER_RECORD.ON_DUTY_TIME;
						}

						if (CREW_MEMBER_RECORD.ON_DUTY_TIME_ZONE != "Null") {
							crew_member_record.ON_DUTY_TIME_ZONE = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_ZONE_48[1];
							crew_member_record.ON_DUTY_TIME_ZONE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_ZONE_48();
							crew_member_record.ON_DUTY_TIME_ZONE[0].Value = CREW_MEMBER_RECORD.ON_DUTY_TIME_ZONE;
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_DATE != null && CREW_MEMBER_RECORD.ON_TRAIN_DATE != "") {
							crew_member_record.ON_TRAIN_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_DATE_48[1];
							crew_member_record.ON_TRAIN_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_DATE_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_DATE == "Empty") {
								crew_member_record.ON_TRAIN_DATE[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_DATE[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_DATE;
							}
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_TIME != null && CREW_MEMBER_RECORD.ON_TRAIN_TIME != "") {
							crew_member_record.ON_TRAIN_TIME = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_48[1];
							crew_member_record.ON_TRAIN_TIME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_TIME == "Empty") {
								crew_member_record.ON_TRAIN_TIME[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_TIME[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_TIME;
							}
						}

						if (CREW_MEMBER_RECORD.ON_TRAIN_TIME_ZONE != null && CREW_MEMBER_RECORD.ON_TRAIN_TIME_ZONE != "") {
							crew_member_record.ON_TRAIN_TIME_ZONE = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_ZONE_48[1];
							crew_member_record.ON_TRAIN_TIME_ZONE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_ZONE_48();
							if (CREW_MEMBER_RECORD.ON_TRAIN_TIME_ZONE == "Empty") {
								crew_member_record.ON_TRAIN_TIME_ZONE[0].Value = "";
							} else {
								crew_member_record.ON_TRAIN_TIME_ZONE[0].Value = CREW_MEMBER_RECORD.ON_TRAIN_TIME_ZONE;
							}
						}

						if (CREW_MEMBER_RECORD.HOS_EXPIRE_DATE != "Null") {
							crew_member_record.HOS_EXPIRE_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_DATE_48[1];
							crew_member_record.HOS_EXPIRE_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_DATE_48();
							crew_member_record.HOS_EXPIRE_DATE[0].Value = CREW_MEMBER_RECORD.HOS_EXPIRE_DATE;
						}

						if (CREW_MEMBER_RECORD.HOS_EXPIRE_TIME != "Null") {
							crew_member_record.HOS_EXPIRE_TIME = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_TIME_48[1];
							crew_member_record.HOS_EXPIRE_TIME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_TIME_48();
							crew_member_record.HOS_EXPIRE_TIME[0].Value = CREW_MEMBER_RECORD.HOS_EXPIRE_TIME;
						}

						if (CREW_MEMBER_RECORD.HOS_TIME_ZONE != "Null") {
							crew_member_record.HOS_TIME_ZONE = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_TIME_ZONE_48[1];
							crew_member_record.HOS_TIME_ZONE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_HOS_TIME_ZONE_48();
							crew_member_record.HOS_TIME_ZONE[0].Value = CREW_MEMBER_RECORD.HOS_TIME_ZONE;
						}

						if (CREW_MEMBER_RECORD.OFF_DUTY_DATE != null && CREW_MEMBER_RECORD.OFF_DUTY_DATE != "") {
							crew_member_record.OFF_DUTY_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_DATE_48[1];
							crew_member_record.OFF_DUTY_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_DATE_48();
							if (CREW_MEMBER_RECORD.OFF_DUTY_DATE == "Empty") {
								crew_member_record.OFF_DUTY_DATE[0].Value = "";
							} else {
								crew_member_record.OFF_DUTY_DATE[0].Value = CREW_MEMBER_RECORD.OFF_DUTY_DATE;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_DUTY_TIME != null && CREW_MEMBER_RECORD.OFF_DUTY_TIME != "") {
							crew_member_record.OFF_DUTY_TIME = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_48[1];
							crew_member_record.OFF_DUTY_TIME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_48();
							if (CREW_MEMBER_RECORD.OFF_DUTY_TIME == "Empty") {
								crew_member_record.OFF_DUTY_TIME[0].Value = "";
							} else {
								crew_member_record.OFF_DUTY_TIME[0].Value = CREW_MEMBER_RECORD.OFF_DUTY_TIME;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_DUTY_TIME_ZONE != null && CREW_MEMBER_RECORD.OFF_DUTY_TIME_ZONE != "") {
							crew_member_record.OFF_DUTY_TIME_ZONE = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_ZONE_48[1];
							crew_member_record.OFF_DUTY_TIME_ZONE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_ZONE_48();
							if (CREW_MEMBER_RECORD.OFF_DUTY_TIME_ZONE == "Empty") {
								crew_member_record.OFF_DUTY_TIME_ZONE[0].Value = "";
							} else {
								crew_member_record.OFF_DUTY_TIME_ZONE[0].Value = CREW_MEMBER_RECORD.OFF_DUTY_TIME_ZONE;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_DATE != null && CREW_MEMBER_RECORD.OFF_TRAIN_DATE != "") {
							crew_member_record.OFF_TRAIN_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_DATE_48[1];
							crew_member_record.OFF_TRAIN_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_DATE_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_DATE == "Empty") {
								crew_member_record.OFF_TRAIN_DATE[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_DATE[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_DATE;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_TIME != null && CREW_MEMBER_RECORD.OFF_TRAIN_TIME != "") {
							crew_member_record.OFF_TRAIN_TIME = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_48[1];
							crew_member_record.OFF_TRAIN_TIME[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_TIME == "Empty") {
								crew_member_record.OFF_TRAIN_TIME[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_TIME[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_TIME;
							}
						}

						if (CREW_MEMBER_RECORD.OFF_TRAIN_TIME_ZONE != null && CREW_MEMBER_RECORD.OFF_TRAIN_TIME_ZONE != "") {
							crew_member_record.OFF_TRAIN_TIME_ZONE = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_ZONE_48[1];
							crew_member_record.OFF_TRAIN_TIME_ZONE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_ZONE_48();
							if (CREW_MEMBER_RECORD.OFF_TRAIN_TIME_ZONE == "Empty") {
								crew_member_record.OFF_TRAIN_TIME_ZONE[0].Value = "";
							} else {
								crew_member_record.OFF_TRAIN_TIME_ZONE[0].Value = CREW_MEMBER_RECORD.OFF_TRAIN_TIME_ZONE;
							}
						}

						if (CREW_MEMBER_RECORD.DEST_TRAIN_SCAC != null && CREW_MEMBER_RECORD.DEST_TRAIN_SCAC != "") {
							crew_member_record.DEST_TRAIN_SCAC = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SCAC_48[1];
							crew_member_record.DEST_TRAIN_SCAC[0] = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SCAC_48();
							if (CREW_MEMBER_RECORD.DEST_TRAIN_SCAC == "Empty") {
								crew_member_record.DEST_TRAIN_SCAC[0].Value = "";
							} else {
								crew_member_record.DEST_TRAIN_SCAC[0].Value = CREW_MEMBER_RECORD.DEST_TRAIN_SCAC;
							}
						}

						if (CREW_MEMBER_RECORD.DEST_TRAIN_SECTION != null && CREW_MEMBER_RECORD.DEST_TRAIN_SECTION != "") {
							crew_member_record.DEST_TRAIN_SECTION = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SECTION_48[1];
							crew_member_record.DEST_TRAIN_SECTION[0] = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SECTION_48();
							if (CREW_MEMBER_RECORD.DEST_TRAIN_SECTION == "Empty") {
								crew_member_record.DEST_TRAIN_SECTION[0].Value = "";
							} else {
								crew_member_record.DEST_TRAIN_SECTION[0].Value = CREW_MEMBER_RECORD.DEST_TRAIN_SECTION;
							}
						}

						if (CREW_MEMBER_RECORD.DEST_TRAIN_SYMBOL != null && CREW_MEMBER_RECORD.DEST_TRAIN_SYMBOL != "") {
							crew_member_record.DEST_TRAIN_SYMBOL = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SYMBOL_48[1];
							crew_member_record.DEST_TRAIN_SYMBOL[0] = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SYMBOL_48();
							if (CREW_MEMBER_RECORD.DEST_TRAIN_SYMBOL == "Empty") {
								crew_member_record.DEST_TRAIN_SYMBOL[0].Value = "";
							} else {
								crew_member_record.DEST_TRAIN_SYMBOL[0].Value = CREW_MEMBER_RECORD.DEST_TRAIN_SYMBOL;
							}
						}

						if (CREW_MEMBER_RECORD.DEST_TRAIN_ORIGIN_DATE != null && CREW_MEMBER_RECORD.DEST_TRAIN_ORIGIN_DATE != "") {
							crew_member_record.DEST_TRAIN_ORIGIN_DATE = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_ORIGIN_DATE_48[1];
							crew_member_record.DEST_TRAIN_ORIGIN_DATE[0] = new NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_ORIGIN_DATE_48();
							if (CREW_MEMBER_RECORD.DEST_TRAIN_ORIGIN_DATE == "Empty") {
								crew_member_record.DEST_TRAIN_ORIGIN_DATE[0].Value = "";
							} else {
								crew_member_record.DEST_TRAIN_ORIGIN_DATE[0].Value = CREW_MEMBER_RECORD.DEST_TRAIN_ORIGIN_DATE;
							}
						}

						content.CREW_MEMBER_RECORD[crew_member_recordIndex] = crew_member_record;
						crew_member_recordIndex++;
					}
				}

			}

			ns_crewmember_48.Items[0] = header;
			ns_crewmember_48.Items[1] = content;
			return ns_crewmember_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MCRWMEM,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MCRWMEM,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_CrewMemberHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_CrewMemberCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string CREW_ID = "";
		public string CREW_LINE_SEGMENT = "";
		public string SEQUENCE_NUMBER = "";
		public string NUMBER_OF_CREW_MEMBERS = "";
		public ArrayList CREW_MEMBER_RECORD = new ArrayList();

		public void addCREW_MEMBER_RECORD(MIS_NS_CrewMemberCREW_MEMBER_RECORD_48 crew_member_record) {
			this.CREW_MEMBER_RECORD.Add(crew_member_record);
		}
	}

	public partial class MIS_NS_CrewMemberCREW_MEMBER_RECORD_48 {
		public string ON_DUTY_LOCATION = "";
		public string OFF_DUTY_LOCATION = "";
		public string ON_TRAIN_LOCATION = "";
		public string ON_TRAIN_PASS_COUNT = "";
		public string ON_TRAIN_LOCATION_MP = "";
		public string OFF_TRAIN_LOCATION = "";
		public string OFF_TRAIN_PASS_COUNT = "";
		public string OFF_TRAIN_LOCATION_MP = "";
		public string CREW_POSITION = "";
		public string CREW_MEMBER_TYPE = "";
		public string FIRST_INITIAL = "";
		public string MIDDLE_INITIAL = "";
		public string LAST_NAME = "";
		public string SOCIAL_SECURITY_NO = "";
		public string EMPLOYEE_ID = "";
		public string ON_DUTY_DATE = "";
		public string ON_DUTY_TIME = "";
		public string ON_DUTY_TIME_ZONE = "";
		public string ON_TRAIN_DATE = "";
		public string ON_TRAIN_TIME = "";
		public string ON_TRAIN_TIME_ZONE = "";
		public string HOS_EXPIRE_DATE = "";
		public string HOS_EXPIRE_TIME = "";
		public string HOS_TIME_ZONE = "";
		public string OFF_DUTY_DATE = "";
		public string OFF_DUTY_TIME = "";
		public string OFF_DUTY_TIME_ZONE = "";
		public string OFF_TRAIN_DATE = "";
		public string OFF_TRAIN_TIME = "";
		public string OFF_TRAIN_TIME_ZONE = "";
		public string DEST_TRAIN_SCAC = "";
		public string DEST_TRAIN_SECTION = "";
		public string DEST_TRAIN_SYMBOL = "";
		public string DEST_TRAIN_ORIGIN_DATE = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "CrewMember", IsNullable = false)]
	public partial class NS_CrewMember_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_CrewMemberHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_CrewMemberCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_CREW_ID_48[] CREW_ID;

		[System.Xml.Serialization.XmlElementAttribute("CREW_LINE_SEGMENT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_CREW_LINE_SEGMENT_48[] CREW_LINE_SEGMENT;

		[System.Xml.Serialization.XmlElementAttribute("SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_SEQUENCE_NUMBER_48[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_CREW_MEMBERS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_NUMBER_OF_CREW_MEMBERS_48[] NUMBER_OF_CREW_MEMBERS;

		[System.Xml.Serialization.XmlElementAttribute("CREW_MEMBER_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCONTENT_CREW_MEMBER_RECORD_48[] CREW_MEMBER_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_CREW_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_CREW_LINE_SEGMENT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_SEQUENCE_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_NUMBER_OF_CREW_MEMBERS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCONTENT_CREW_MEMBER_RECORD_48 {
		[System.Xml.Serialization.XmlElementAttribute("ON_DUTY_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_LOCATION_48[] ON_DUTY_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("OFF_DUTY_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_LOCATION_48[] OFF_DUTY_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_48[] ON_TRAIN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_PASS_COUNT_48[] ON_TRAIN_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_LOCATION_MP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_MP_48[] ON_TRAIN_LOCATION_MP;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_48[] OFF_TRAIN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_PASS_COUNT_48[] OFF_TRAIN_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_LOCATION_MP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_MP_48[] OFF_TRAIN_LOCATION_MP;

		[System.Xml.Serialization.XmlElementAttribute("CREW_POSITION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_CREW_POSITION_48[] CREW_POSITION;

		[System.Xml.Serialization.XmlElementAttribute("CREW_MEMBER_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_CREW_MEMBER_TYPE_48[] CREW_MEMBER_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("FIRST_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_FIRST_INITIAL_48[] FIRST_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("MIDDLE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_MIDDLE_INITIAL_48[] MIDDLE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("LAST_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_LAST_NAME_48[] LAST_NAME;

		[System.Xml.Serialization.XmlElementAttribute("SOCIAL_SECURITY_NO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_SOCIAL_SECURITY_NO_48[] SOCIAL_SECURITY_NO;

		[System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_EMPLOYEE_ID_48[] EMPLOYEE_ID;

		[System.Xml.Serialization.XmlElementAttribute("ON_DUTY_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_DATE_48[] ON_DUTY_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ON_DUTY_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_48[] ON_DUTY_TIME;

		[System.Xml.Serialization.XmlElementAttribute("ON_DUTY_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_ZONE_48[] ON_DUTY_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_DATE_48[] ON_TRAIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_48[] ON_TRAIN_TIME;

		[System.Xml.Serialization.XmlElementAttribute("ON_TRAIN_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_ZONE_48[] ON_TRAIN_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("HOS_EXPIRE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_DATE_48[] HOS_EXPIRE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HOS_EXPIRE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_TIME_48[] HOS_EXPIRE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HOS_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_HOS_TIME_ZONE_48[] HOS_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("OFF_DUTY_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_DATE_48[] OFF_DUTY_DATE;

		[System.Xml.Serialization.XmlElementAttribute("OFF_DUTY_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_48[] OFF_DUTY_TIME;

		[System.Xml.Serialization.XmlElementAttribute("OFF_DUTY_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_ZONE_48[] OFF_DUTY_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_DATE_48[] OFF_TRAIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_48[] OFF_TRAIN_TIME;

		[System.Xml.Serialization.XmlElementAttribute("OFF_TRAIN_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_ZONE_48[] OFF_TRAIN_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("DEST_TRAIN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SCAC_48[] DEST_TRAIN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("DEST_TRAIN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SECTION_48[] DEST_TRAIN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("DEST_TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SYMBOL_48[] DEST_TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("DEST_TRAIN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_ORIGIN_DATE_48[] DEST_TRAIN_ORIGIN_DATE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_LOCATION_MP_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_LOCATION_MP_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_CREW_POSITION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_CREW_MEMBER_TYPE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_FIRST_INITIAL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_MIDDLE_INITIAL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_LAST_NAME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_SOCIAL_SECURITY_NO_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_EMPLOYEE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_DUTY_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_ON_TRAIN_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_HOS_EXPIRE_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_HOS_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_DUTY_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_OFF_TRAIN_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_CrewMemberCREW_MEMBER_RECORD_DEST_TRAIN_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}