using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.RUM
{
	public partial class RUM_DR_TAUT_1 {
		public RUM_DR_TAUTHEADER_1 HEADER;
		public RUM_DR_TAUTCONTENT_1 CONTENT;

		public static RUM_DR_TAUT_1 fromSerializableObject(DR_TAUT_1 message) {
			RUM_DR_TAUT_1 dr_taut_1 = new RUM_DR_TAUT_1();
			DR_TAUTHEADER_1 header = null;
			DR_TAUTCONTENT_1 content = null;
			header = (DR_TAUTHEADER_1) message.Items[0];
			content = (DR_TAUTCONTENT_1) message.Items[1];

			if (header != null) {
				RUM_DR_TAUTHEADER_1 messageheader = new RUM_DR_TAUTHEADER_1();

				if (header.EVENT_DATE != null) {
					messageheader.EVENT_DATE = header.EVENT_DATE[0].Value;
					if (messageheader.EVENT_DATE != null) {
						if (messageheader.EVENT_DATE.Length != 8) {
							Ranorex.Report.Failure("Field EVENT_DATE expected to be length of 8, has length of {" + messageheader.EVENT_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.EVENT_DATE)) {
							Ranorex.Report.Failure("Field EVENT_DATE expected to be Numeric, has value of {" + messageheader.EVENT_DATE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EVENT_DATE is a Mandatory field but was found to be missing from the message");
				}

				if (header.EVENT_TIME != null) {
					messageheader.EVENT_TIME = header.EVENT_TIME[0].Value;
					if (messageheader.EVENT_TIME != null) {
						if (messageheader.EVENT_TIME.Length != 6) {
							Ranorex.Report.Failure("Field EVENT_TIME expected to be length of 6, has length of {" + messageheader.EVENT_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.EVENT_TIME)) {
							Ranorex.Report.Failure("Field EVENT_TIME expected to be Numeric, has value of {" + messageheader.EVENT_TIME + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EVENT_TIME is a Mandatory field but was found to be missing from the message");
				}

				if (header.MESSAGE_ID != null) {
					messageheader.MESSAGE_ID = header.MESSAGE_ID[0].Value;
					if (messageheader.MESSAGE_ID != null) {
						if (messageheader.MESSAGE_ID.Length < 1 || messageheader.MESSAGE_ID.Length > 7) {
							Ranorex.Report.Failure("Field MESSAGE_ID expected to be length between or equal to 1 and 7, has length of {" + messageheader.MESSAGE_ID.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field MESSAGE_ID is a Mandatory field but was found to be missing from the message");
				}

				if (header.SEQUENCE_NUMBER != null) {
					messageheader.SEQUENCE_NUMBER = header.SEQUENCE_NUMBER[0].Value;
					if (messageheader.SEQUENCE_NUMBER != null) {
						if (messageheader.SEQUENCE_NUMBER.Length < 1 || messageheader.SEQUENCE_NUMBER.Length > 13) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be length between or equal to 1 and 13, has length of {" + messageheader.SEQUENCE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.SEQUENCE_NUMBER)) {
							Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to be Numeric, has value of {" + messageheader.SEQUENCE_NUMBER + "}.");
						} else {
							long intConvertedValue = Convert.ToInt64(messageheader.SEQUENCE_NUMBER);
							if (intConvertedValue < 1 || intConvertedValue > 9999999999999) {
								Ranorex.Report.Failure("Field SEQUENCE_NUMBER expected to have value between 1 and 9999999999999, but was found to have a value of " + messageheader.SEQUENCE_NUMBER + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field SEQUENCE_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (header.MESSAGE_VERSION != null) {
					messageheader.MESSAGE_VERSION = header.MESSAGE_VERSION[0].Value;
					if (messageheader.MESSAGE_VERSION != null) {
						if (messageheader.MESSAGE_VERSION.Length < 1 || messageheader.MESSAGE_VERSION.Length > 3) {
							Ranorex.Report.Failure("Field MESSAGE_VERSION expected to be length between or equal to 1 and 3, has length of {" + messageheader.MESSAGE_VERSION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.MESSAGE_VERSION)) {
							Ranorex.Report.Failure("Field MESSAGE_VERSION expected to be Numeric, has value of {" + messageheader.MESSAGE_VERSION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messageheader.MESSAGE_VERSION);
							if (intConvertedValue < 1 || intConvertedValue > 999) {
								Ranorex.Report.Failure("Field MESSAGE_VERSION expected to have value between 1 and 999, but was found to have a value of " + messageheader.MESSAGE_VERSION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field MESSAGE_VERSION is a Mandatory field but was found to be missing from the message");
				}

				if (header.SOURCE_SYS != null) {
					messageheader.SOURCE_SYS = header.SOURCE_SYS[0].Value;
					if (messageheader.SOURCE_SYS != null) {
						if (messageheader.SOURCE_SYS.Length < 2 || messageheader.SOURCE_SYS.Length > 3) {
							Ranorex.Report.Failure("Field SOURCE_SYS expected to be length between or equal to 2 and 3, has length of {" + messageheader.SOURCE_SYS.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.SOURCE_SYS)) {
							Ranorex.Report.Failure("Field SOURCE_SYS expected to be Alphabetic, has value of {" + messageheader.SOURCE_SYS + "}.");
						}
						if (messageheader.SOURCE_SYS != "CAD" && messageheader.SOURCE_SYS != "GD" && messageheader.SOURCE_SYS != "CI" && messageheader.SOURCE_SYS != "RU") {
							Ranorex.Report.Failure("Field SOURCE_SYS expected to be one of the following values {CAD, GD, CI, RU}, but was found to be {" + messageheader.SOURCE_SYS + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SOURCE_SYS is a Mandatory field but was found to be missing from the message");
				}

				if (header.DESTINATION_SYS != null) {
					messageheader.DESTINATION_SYS = header.DESTINATION_SYS[0].Value;
					if (messageheader.DESTINATION_SYS != null) {
						if (messageheader.DESTINATION_SYS.Length < 2 || messageheader.DESTINATION_SYS.Length > 3) {
							Ranorex.Report.Failure("Field DESTINATION_SYS expected to be length between or equal to 2 and 3, has length of {" + messageheader.DESTINATION_SYS.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.DESTINATION_SYS)) {
							Ranorex.Report.Failure("Field DESTINATION_SYS expected to be Alphabetic, has value of {" + messageheader.DESTINATION_SYS + "}.");
						}
						if (messageheader.DESTINATION_SYS != "CAD" && messageheader.DESTINATION_SYS != "GD" && messageheader.DESTINATION_SYS != "CI" && messageheader.DESTINATION_SYS != "RU") {
							Ranorex.Report.Failure("Field DESTINATION_SYS expected to be one of the following values {CAD, GD, CI, RU}, but was found to be {" + messageheader.DESTINATION_SYS + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DESTINATION_SYS is a Mandatory field but was found to be missing from the message");
				}

				if (header.DISTRICT_NAME != null) {
					messageheader.DISTRICT_NAME = header.DISTRICT_NAME[0].Value;
					if (messageheader.DISTRICT_NAME != null) {
						if (messageheader.DISTRICT_NAME.Length < 0 || messageheader.DISTRICT_NAME.Length > 25) {
							Ranorex.Report.Failure("Field DISTRICT_NAME expected to be length between or equal to 0 and 25, has length of {" + messageheader.DISTRICT_NAME.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DISTRICT_NAME is a Mandatory field but was found to be missing from the message");
				}

				if (header.DISTRICT_SCAC != null) {
					messageheader.DISTRICT_SCAC = header.DISTRICT_SCAC[0].Value;
					if (messageheader.DISTRICT_SCAC != null) {
						if (messageheader.DISTRICT_SCAC.Length < 1 || messageheader.DISTRICT_SCAC.Length > 4) {
							Ranorex.Report.Failure("Field DISTRICT_SCAC expected to be length between or equal to 1 and 4, has length of {" + messageheader.DISTRICT_SCAC.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.DISTRICT_SCAC)) {
							Ranorex.Report.Failure("Field DISTRICT_SCAC expected to be Alphabetic, has value of {" + messageheader.DISTRICT_SCAC + "}.");
						}
					}
				}

				if (header.USER_ID != null) {
					messageheader.USER_ID = header.USER_ID[0].Value;
					if (messageheader.USER_ID != null) {
						if (messageheader.USER_ID.Length < 0 || messageheader.USER_ID.Length > 7) {
							Ranorex.Report.Failure("Field USER_ID expected to be length between or equal to 0 and 7, has length of {" + messageheader.USER_ID.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field USER_ID is a Mandatory field but was found to be missing from the message");
				}

				if (header.DIVISION_NAME != null) {
					messageheader.DIVISION_NAME = header.DIVISION_NAME[0].Value;
					if (messageheader.DIVISION_NAME != null) {
						if (messageheader.DIVISION_NAME.Length < 0 || messageheader.DIVISION_NAME.Length > 24) {
							Ranorex.Report.Failure("Field DIVISION_NAME expected to be length between or equal to 0 and 24, has length of {" + messageheader.DIVISION_NAME.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.DIVISION_NAME)) {
							Ranorex.Report.Failure("Field DIVISION_NAME expected to be Alphabetic, has value of {" + messageheader.DIVISION_NAME + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DIVISION_NAME is a Mandatory field but was found to be missing from the message");
				}

				dr_taut_1.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				RUM_DR_TAUTCONTENT_1 messagecontent = new RUM_DR_TAUTCONTENT_1();

				if (content.REQUEST_ID != null) {
					messagecontent.REQUEST_ID = content.REQUEST_ID[0].Value;
					if (messagecontent.REQUEST_ID != null) {
						if (messagecontent.REQUEST_ID.Length < 1 || messagecontent.REQUEST_ID.Length > 13) {
							Ranorex.Report.Failure("Field REQUEST_ID expected to be length between or equal to 1 and 13, has length of {" + messagecontent.REQUEST_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.REQUESTING_EMPLOYEE != null) {
					messagecontent.REQUESTING_EMPLOYEE = content.REQUESTING_EMPLOYEE[0].Value;
					if (messagecontent.REQUESTING_EMPLOYEE != null) {
						if (messagecontent.REQUESTING_EMPLOYEE.Length < 1 || messagecontent.REQUESTING_EMPLOYEE.Length > 20) {
							Ranorex.Report.Failure("Field REQUESTING_EMPLOYEE expected to be length between or equal to 1 and 20, has length of {" + messagecontent.REQUESTING_EMPLOYEE.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field REQUESTING_EMPLOYEE is a Mandatory field but was found to be missing from the message");
				}

				if (content.DISPATCHER_RESPONSE != null) {
					messagecontent.DISPATCHER_RESPONSE = content.DISPATCHER_RESPONSE[0].Value;
					if (messagecontent.DISPATCHER_RESPONSE != null) {
						if (messagecontent.DISPATCHER_RESPONSE.Length < 1 || messagecontent.DISPATCHER_RESPONSE.Length > 100) {
							Ranorex.Report.Failure("Field DISPATCHER_RESPONSE expected to be length between or equal to 1 and 100, has length of {" + messagecontent.DISPATCHER_RESPONSE.Length.ToString() + "}.");
						}
					}
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
							if (intConvertedValue < 0 || intConvertedValue > 7) {
								Ranorex.Report.Failure("Field ACTION expected to have value between 0 and 7, but was found to have a value of " + messagecontent.ACTION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ACTION is a Mandatory field but was found to be missing from the message");
				}

				if (content.CREW_ACK_REQUIRED != null) {
					messagecontent.CREW_ACK_REQUIRED = content.CREW_ACK_REQUIRED[0].Value;
					if (messagecontent.CREW_ACK_REQUIRED != null) {
						if (messagecontent.CREW_ACK_REQUIRED.Length != 1) {
							Ranorex.Report.Failure("Field CREW_ACK_REQUIRED expected to be length of 1, has length of {" + messagecontent.CREW_ACK_REQUIRED.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.CREW_ACK_REQUIRED)) {
							Ranorex.Report.Failure("Field CREW_ACK_REQUIRED expected to be Alphabetic, has value of {" + messagecontent.CREW_ACK_REQUIRED + "}.");
						}
						if (messagecontent.CREW_ACK_REQUIRED != "Y" && messagecontent.CREW_ACK_REQUIRED != "N") {
							Ranorex.Report.Failure("Field CREW_ACK_REQUIRED expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.CREW_ACK_REQUIRED + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field CREW_ACK_REQUIRED is a Mandatory field but was found to be missing from the message");
				}

				if (content.H_TRACK_AUTHORITY_NUMBER != null) {
					messagecontent.H_TRACK_AUTHORITY_NUMBER = content.H_TRACK_AUTHORITY_NUMBER[0].Value;
					if (messagecontent.H_TRACK_AUTHORITY_NUMBER != null) {
						if (messagecontent.H_TRACK_AUTHORITY_NUMBER.Length < 1 || messagecontent.H_TRACK_AUTHORITY_NUMBER.Length > 6) {
							Ranorex.Report.Failure("Field H_TRACK_AUTHORITY_NUMBER expected to be length between or equal to 1 and 6, has length of {" + messagecontent.H_TRACK_AUTHORITY_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.H_TRACK_AUTHORITY_NUMBER)) {
							Ranorex.Report.Failure("Field H_TRACK_AUTHORITY_NUMBER expected to be Numeric, has value of {" + messagecontent.H_TRACK_AUTHORITY_NUMBER + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.H_TRACK_AUTHORITY_NUMBER);
							if (intConvertedValue < 1 || intConvertedValue > 999999) {
								Ranorex.Report.Failure("Field H_TRACK_AUTHORITY_NUMBER expected to have value between 1 and 999999, but was found to have a value of " + messagecontent.H_TRACK_AUTHORITY_NUMBER + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field H_TRACK_AUTHORITY_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.H_ADDRESSEE_TYPE != null) {
					messagecontent.H_ADDRESSEE_TYPE = content.H_ADDRESSEE_TYPE[0].Value;
					if (messagecontent.H_ADDRESSEE_TYPE != null) {
						if (messagecontent.H_ADDRESSEE_TYPE.Length != 2) {
							Ranorex.Report.Failure("Field H_ADDRESSEE_TYPE expected to be length of 2, has length of {" + messagecontent.H_ADDRESSEE_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.H_ADDRESSEE_TYPE)) {
							Ranorex.Report.Failure("Field H_ADDRESSEE_TYPE expected to be Alphabetic, has value of {" + messagecontent.H_ADDRESSEE_TYPE + "}.");
						}
						if (messagecontent.H_ADDRESSEE_TYPE != "RW" && messagecontent.H_ADDRESSEE_TYPE != "OT" && messagecontent.H_ADDRESSEE_TYPE != "TE") {
							Ranorex.Report.Failure("Field H_ADDRESSEE_TYPE expected to be one of the following values {RW, OT, TE}, but was found to be {" + messagecontent.H_ADDRESSEE_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field H_ADDRESSEE_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.H_SCAC != null) {
					messagecontent.H_SCAC = content.H_SCAC[0].Value;
					if (messagecontent.H_SCAC != null) {
						if (messagecontent.H_SCAC.Length < 1 || messagecontent.H_SCAC.Length > 4) {
							Ranorex.Report.Failure("Field H_SCAC expected to be length between or equal to 1 and 4, has length of {" + messagecontent.H_SCAC.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.H_SCAC)) {
							Ranorex.Report.Failure("Field H_SCAC expected to be Alphabetic, has value of {" + messagecontent.H_SCAC + "}.");
						}
					}
				}

				if (content.H_SYMBOL != null) {
					messagecontent.H_SYMBOL = content.H_SYMBOL[0].Value;
					if (messagecontent.H_SYMBOL != null) {
						if (messagecontent.H_SYMBOL.Length < 1 || messagecontent.H_SYMBOL.Length > 10) {
							Ranorex.Report.Failure("Field H_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + messagecontent.H_SYMBOL.Length.ToString() + "}.");
						}
					}
				}

				if (content.H_SECTION != null) {
					messagecontent.H_SECTION = content.H_SECTION[0].Value;
					if (messagecontent.H_SECTION != null) {
						if (messagecontent.H_SECTION.Length != 1) {
							Ranorex.Report.Failure("Field H_SECTION expected to be length of 1, has length of {" + messagecontent.H_SECTION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.H_SECTION)) {
							Ranorex.Report.Failure("Field H_SECTION expected to be Numeric, has value of {" + messagecontent.H_SECTION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.H_SECTION);
							if (intConvertedValue < 1 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field H_SECTION expected to have value between 1 and 9, but was found to have a value of " + messagecontent.H_SECTION + ".");
							}
						}
					}
				}

				if (content.H_ORIGIN_DATE != null) {
					messagecontent.H_ORIGIN_DATE = content.H_ORIGIN_DATE[0].Value;
					if (messagecontent.H_ORIGIN_DATE != null) {
						if (messagecontent.H_ORIGIN_DATE.Length != 8) {
							Ranorex.Report.Failure("Field H_ORIGIN_DATE expected to be length of 8, has length of {" + messagecontent.H_ORIGIN_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.H_ORIGIN_DATE)) {
							Ranorex.Report.Failure("Field H_ORIGIN_DATE expected to be Numeric, has value of {" + messagecontent.H_ORIGIN_DATE + "}.");
						}
					}
				}

				if (content.H_ENGINE_INITIAL != null) {
					messagecontent.H_ENGINE_INITIAL = content.H_ENGINE_INITIAL[0].Value;
					if (messagecontent.H_ENGINE_INITIAL != null) {
						if (messagecontent.H_ENGINE_INITIAL.Length < 1 || messagecontent.H_ENGINE_INITIAL.Length > 4) {
							Ranorex.Report.Failure("Field H_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + messagecontent.H_ENGINE_INITIAL.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.H_ENGINE_INITIAL)) {
							Ranorex.Report.Failure("Field H_ENGINE_INITIAL expected to be Alphabetic, has value of {" + messagecontent.H_ENGINE_INITIAL + "}.");
						}
					}
				}

				if (content.H_ENGINE_NUMBER != null) {
					messagecontent.H_ENGINE_NUMBER = content.H_ENGINE_NUMBER[0].Value;
					if (messagecontent.H_ENGINE_NUMBER != null) {
						if (messagecontent.H_ENGINE_NUMBER.Length < 1 || messagecontent.H_ENGINE_NUMBER.Length > 10) {
							Ranorex.Report.Failure("Field H_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + messagecontent.H_ENGINE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.H_ENGINE_NUMBER)) {
							Ranorex.Report.Failure("Field H_ENGINE_NUMBER expected to be Numeric, has value of {" + messagecontent.H_ENGINE_NUMBER + "}.");
						}
					}
				}

				if (content.H_COUPLED_ENGINE_INITIAL != null) {
					messagecontent.H_COUPLED_ENGINE_INITIAL = content.H_COUPLED_ENGINE_INITIAL[0].Value;
					if (messagecontent.H_COUPLED_ENGINE_INITIAL != null) {
						if (messagecontent.H_COUPLED_ENGINE_INITIAL.Length < 1 || messagecontent.H_COUPLED_ENGINE_INITIAL.Length > 4) {
							Ranorex.Report.Failure("Field H_COUPLED_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + messagecontent.H_COUPLED_ENGINE_INITIAL.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.H_COUPLED_ENGINE_INITIAL)) {
							Ranorex.Report.Failure("Field H_COUPLED_ENGINE_INITIAL expected to be Alphabetic, has value of {" + messagecontent.H_COUPLED_ENGINE_INITIAL + "}.");
						}
					}
				}

				if (content.H_COUPLED_ENGINE_NUMBER != null) {
					messagecontent.H_COUPLED_ENGINE_NUMBER = content.H_COUPLED_ENGINE_NUMBER[0].Value;
					if (messagecontent.H_COUPLED_ENGINE_NUMBER != null) {
						if (messagecontent.H_COUPLED_ENGINE_NUMBER.Length < 1 || messagecontent.H_COUPLED_ENGINE_NUMBER.Length > 10) {
							Ranorex.Report.Failure("Field H_COUPLED_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + messagecontent.H_COUPLED_ENGINE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.H_COUPLED_ENGINE_NUMBER)) {
							Ranorex.Report.Failure("Field H_COUPLED_ENGINE_NUMBER expected to be Numeric, has value of {" + messagecontent.H_COUPLED_ENGINE_NUMBER + "}.");
						}
					}
				}

				if (content.H_ADDRESSEE_ID != null) {
					messagecontent.H_ADDRESSEE_ID = content.H_ADDRESSEE_ID[0].Value;
					if (messagecontent.H_ADDRESSEE_ID != null) {
						if (messagecontent.H_ADDRESSEE_ID.Length < 1 || messagecontent.H_ADDRESSEE_ID.Length > 19) {
							Ranorex.Report.Failure("Field H_ADDRESSEE_ID expected to be length between or equal to 1 and 19, has length of {" + messagecontent.H_ADDRESSEE_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.H_ADDRESSEE != null) {
					messagecontent.H_ADDRESSEE = content.H_ADDRESSEE[0].Value;
					if (messagecontent.H_ADDRESSEE != null) {
						if (messagecontent.H_ADDRESSEE.Length < 1 || messagecontent.H_ADDRESSEE.Length > 39) {
							Ranorex.Report.Failure("Field H_ADDRESSEE expected to be length between or equal to 1 and 39, has length of {" + messagecontent.H_ADDRESSEE.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field H_ADDRESSEE is a Mandatory field but was found to be missing from the message");
				}

				if (content.H_AT_LOCATION != null) {
					messagecontent.H_AT_LOCATION = content.H_AT_LOCATION[0].Value;
					if (messagecontent.H_AT_LOCATION != null) {
						if (messagecontent.H_AT_LOCATION.Length < 1 || messagecontent.H_AT_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field H_AT_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.H_AT_LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field H_AT_LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.S1_PRESENCE != null) {
					messagecontent.S1_PRESENCE = content.S1_PRESENCE[0].Value;
					if (messagecontent.S1_PRESENCE != null) {
						if (messagecontent.S1_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S1_PRESENCE expected to be length of 1, has length of {" + messagecontent.S1_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S1_PRESENCE)) {
							Ranorex.Report.Failure("Field S1_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S1_PRESENCE + "}.");
						}
						if (messagecontent.S1_PRESENCE != "Y" && messagecontent.S1_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S1_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S1_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S1_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S1_TRACK_AUTHORITY_NUMBER != null) {
					messagecontent.S1_TRACK_AUTHORITY_NUMBER = content.S1_TRACK_AUTHORITY_NUMBER[0].Value;
					if (messagecontent.S1_TRACK_AUTHORITY_NUMBER != null) {
						if (messagecontent.S1_TRACK_AUTHORITY_NUMBER.Length < 1 || messagecontent.S1_TRACK_AUTHORITY_NUMBER.Length > 6) {
							Ranorex.Report.Failure("Field S1_TRACK_AUTHORITY_NUMBER expected to be length between or equal to 1 and 6, has length of {" + messagecontent.S1_TRACK_AUTHORITY_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S1_TRACK_AUTHORITY_NUMBER)) {
							Ranorex.Report.Failure("Field S1_TRACK_AUTHORITY_NUMBER expected to be Numeric, has value of {" + messagecontent.S1_TRACK_AUTHORITY_NUMBER + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S1_TRACK_AUTHORITY_NUMBER);
							if (intConvertedValue < 1 || intConvertedValue > 999999) {
								Ranorex.Report.Failure("Field S1_TRACK_AUTHORITY_NUMBER expected to have value between 1 and 999999, but was found to have a value of " + messagecontent.S1_TRACK_AUTHORITY_NUMBER + ".");
							}
						}
					}
				}

				if (content.S2_PRESENCE != null) {
					messagecontent.S2_PRESENCE = content.S2_PRESENCE[0].Value;
					if (messagecontent.S2_PRESENCE != null) {
						if (messagecontent.S2_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S2_PRESENCE expected to be length of 1, has length of {" + messagecontent.S2_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S2_PRESENCE)) {
							Ranorex.Report.Failure("Field S2_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S2_PRESENCE + "}.");
						}
						if (messagecontent.S2_PRESENCE != "Y" && messagecontent.S2_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S2_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S2_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S2_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S2_FROM_LOCATION != null) {
					messagecontent.S2_FROM_LOCATION = content.S2_FROM_LOCATION[0].Value;
					if (messagecontent.S2_FROM_LOCATION != null) {
						if (messagecontent.S2_FROM_LOCATION.Length < 1 || messagecontent.S2_FROM_LOCATION.Length > 37) {
							Ranorex.Report.Failure("Field S2_FROM_LOCATION expected to be length between or equal to 1 and 37, has length of {" + messagecontent.S2_FROM_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S2_COUNT != null) {
					messagecontent.S2_COUNT = content.S2_COUNT[0].Value;
				}
				if (content.S2_RECORD != null) {
					for (int i = 0; i < content.S2_RECORD.Length; i++) {
						RUM_DR_TAUTS2_RECORD_1 s2_record = new RUM_DR_TAUTS2_RECORD_1();

						if (content.S2_RECORD[i].S2_SEQUENCE != null) {
							s2_record.S2_SEQUENCE = content.S2_RECORD[i].S2_SEQUENCE[0].Value;
						}

						if (content.S2_RECORD[i].S2_TO_LOCATION != null) {
							s2_record.S2_TO_LOCATION = content.S2_RECORD[i].S2_TO_LOCATION[0].Value;
						}

						if (content.S2_RECORD[i].S2_TRACK_TEXT != null) {
							s2_record.S2_TRACK_TEXT = content.S2_RECORD[i].S2_TRACK_TEXT[0].Value;
						}

						messagecontent.addS2_RECORD(s2_record);
					}
				}

				if (content.S2_LIMITS_COUNT != null) {
					messagecontent.S2_LIMITS_COUNT = content.S2_LIMITS_COUNT[0].Value;
				}
				if (content.S2_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S2_LIMITS_RECORD.Length; i++) {
						RUM_DR_TAUTS2_LIMITS_RECORD_1 s2_limits_record = new RUM_DR_TAUTS2_LIMITS_RECORD_1();

						if (content.S2_LIMITS_RECORD[i].S2_FROM_DISTRICT != null) {
							s2_limits_record.S2_FROM_DISTRICT = content.S2_LIMITS_RECORD[i].S2_FROM_DISTRICT[0].Value;
						}

						if (content.S2_LIMITS_RECORD[i].S2_FROM_MILEPOST != null) {
							s2_limits_record.S2_FROM_MILEPOST = content.S2_LIMITS_RECORD[i].S2_FROM_MILEPOST[0].Value;
						}

						if (content.S2_LIMITS_RECORD[i].S2_TO_DISTRICT != null) {
							s2_limits_record.S2_TO_DISTRICT = content.S2_LIMITS_RECORD[i].S2_TO_DISTRICT[0].Value;
						}

						if (content.S2_LIMITS_RECORD[i].S2_TO_MILEPOST != null) {
							s2_limits_record.S2_TO_MILEPOST = content.S2_LIMITS_RECORD[i].S2_TO_MILEPOST[0].Value;
						}

						if (content.S2_LIMITS_RECORD[i].S2_TRACK != null) {
							s2_limits_record.S2_TRACK = content.S2_LIMITS_RECORD[i].S2_TRACK[0].Value;
						}

						messagecontent.addS2_LIMITS_RECORD(s2_limits_record);
					}
				}

				if (content.S3_PRESENCE != null) {
					messagecontent.S3_PRESENCE = content.S3_PRESENCE[0].Value;
				}

				if (content.S3_BETWEEN_LOCATION != null) {
					messagecontent.S3_BETWEEN_LOCATION = content.S3_BETWEEN_LOCATION[0].Value;
				}

				if (content.S3_AND_LOCATION != null) {
					messagecontent.S3_AND_LOCATION = content.S3_AND_LOCATION[0].Value;
				}

				if (content.S3_TRACK_COUNT != null) {
					messagecontent.S3_TRACK_COUNT = content.S3_TRACK_COUNT[0].Value;
				}
				if (content.S3_TRACK_RECORD != null) {
					for (int i = 0; i < content.S3_TRACK_RECORD.Length; i++) {
						RUM_DR_TAUTS3_TRACK_RECORD_1 s3_track_record = new RUM_DR_TAUTS3_TRACK_RECORD_1();

						if (content.S3_TRACK_RECORD[i].S3_TRACK_SEQUENCE != null) {
							s3_track_record.S3_TRACK_SEQUENCE = content.S3_TRACK_RECORD[i].S3_TRACK_SEQUENCE[0].Value;
						}

						if (content.S3_TRACK_RECORD[i].S3_TRACK_TEXT != null) {
							s3_track_record.S3_TRACK_TEXT = content.S3_TRACK_RECORD[i].S3_TRACK_TEXT[0].Value;
						}

						messagecontent.addS3_TRACK_RECORD(s3_track_record);
					}
				}

				if (content.S3_LIMITS_COUNT != null) {
					messagecontent.S3_LIMITS_COUNT = content.S3_LIMITS_COUNT[0].Value;
				}
				if (content.S3_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S3_LIMITS_RECORD.Length; i++) {
						RUM_DR_TAUTS3_LIMITS_RECORD_1 s3_limits_record = new RUM_DR_TAUTS3_LIMITS_RECORD_1();

						if (content.S3_LIMITS_RECORD[i].S3_BETWEEN_DISTRICT != null) {
							s3_limits_record.S3_BETWEEN_DISTRICT = content.S3_LIMITS_RECORD[i].S3_BETWEEN_DISTRICT[0].Value;
						}

						if (content.S3_LIMITS_RECORD[i].S3_BETWEEN_MILEPOST != null) {
							s3_limits_record.S3_BETWEEN_MILEPOST = content.S3_LIMITS_RECORD[i].S3_BETWEEN_MILEPOST[0].Value;
						}

						if (content.S3_LIMITS_RECORD[i].S3_AND_DISTRICT != null) {
							s3_limits_record.S3_AND_DISTRICT = content.S3_LIMITS_RECORD[i].S3_AND_DISTRICT[0].Value;
						}

						if (content.S3_LIMITS_RECORD[i].S3_AND_MILEPOST != null) {
							s3_limits_record.S3_AND_MILEPOST = content.S3_LIMITS_RECORD[i].S3_AND_MILEPOST[0].Value;
						}

						if (content.S3_LIMITS_RECORD[i].S3_TRACK != null) {
							s3_limits_record.S3_TRACK = content.S3_LIMITS_RECORD[i].S3_TRACK[0].Value;
						}

						messagecontent.addS3_LIMITS_RECORD(s3_limits_record);
					}
				}

				if (content.S4_PRESENCE != null) {
					messagecontent.S4_PRESENCE = content.S4_PRESENCE[0].Value;
				}

				if (content.S4_FROM_LOCATION != null) {
					messagecontent.S4_FROM_LOCATION = content.S4_FROM_LOCATION[0].Value;
				}

				if (content.S4_COUNT != null) {
					messagecontent.S4_COUNT = content.S4_COUNT[0].Value;
				}
				if (content.S4_RECORD != null) {
					for (int i = 0; i < content.S4_RECORD.Length; i++) {
						RUM_DR_TAUTS4_RECORD_1 s4_record = new RUM_DR_TAUTS4_RECORD_1();

						if (content.S4_RECORD[i].S4_SEQUENCE != null) {
							s4_record.S4_SEQUENCE = content.S4_RECORD[i].S4_SEQUENCE[0].Value;
						}

						if (content.S4_RECORD[i].S4_TO_LOCATION != null) {
							s4_record.S4_TO_LOCATION = content.S4_RECORD[i].S4_TO_LOCATION[0].Value;
						}

						if (content.S4_RECORD[i].S4_TRACK_TEXT != null) {
							s4_record.S4_TRACK_TEXT = content.S4_RECORD[i].S4_TRACK_TEXT[0].Value;
						}

						messagecontent.addS4_RECORD(s4_record);
					}
				}

				if (content.S4_LIMITS_COUNT != null) {
					messagecontent.S4_LIMITS_COUNT = content.S4_LIMITS_COUNT[0].Value;
				}
				if (content.S4_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S4_LIMITS_RECORD.Length; i++) {
						RUM_DR_TAUTS4_LIMITS_RECORD_1 s4_limits_record = new RUM_DR_TAUTS4_LIMITS_RECORD_1();

						if (content.S4_LIMITS_RECORD[i].S4_FROM_DISTRICT != null) {
							s4_limits_record.S4_FROM_DISTRICT = content.S4_LIMITS_RECORD[i].S4_FROM_DISTRICT[0].Value;
						}

						if (content.S4_LIMITS_RECORD[i].S4_FROM_MILEPOST != null) {
							s4_limits_record.S4_FROM_MILEPOST = content.S4_LIMITS_RECORD[i].S4_FROM_MILEPOST[0].Value;
						}

						if (content.S4_LIMITS_RECORD[i].S4_TO_DISTRICT != null) {
							s4_limits_record.S4_TO_DISTRICT = content.S4_LIMITS_RECORD[i].S4_TO_DISTRICT[0].Value;
						}

						if (content.S4_LIMITS_RECORD[i].S4_TO_MILEPOST != null) {
							s4_limits_record.S4_TO_MILEPOST = content.S4_LIMITS_RECORD[i].S4_TO_MILEPOST[0].Value;
						}

						if (content.S4_LIMITS_RECORD[i].S4_TRACK != null) {
							s4_limits_record.S4_TRACK = content.S4_LIMITS_RECORD[i].S4_TRACK[0].Value;
						}

						messagecontent.addS4_LIMITS_RECORD(s4_limits_record);
					}
				}

				if (content.S5_PRESENCE != null) {
					messagecontent.S5_PRESENCE = content.S5_PRESENCE[0].Value;
				}

				if (content.S5_INITIAL_UNTIL_DATE != null) {
					messagecontent.S5_INITIAL_UNTIL_DATE = content.S5_INITIAL_UNTIL_DATE[0].Value;
				}

				if (content.S5_INITIAL_UNTIL_TIME != null) {
					messagecontent.S5_INITIAL_UNTIL_TIME = content.S5_INITIAL_UNTIL_TIME[0].Value;
				}

				if (content.S5_EXTENDED_UNTIL_DATE != null) {
					messagecontent.S5_EXTENDED_UNTIL_DATE = content.S5_EXTENDED_UNTIL_DATE[0].Value;
				}

				if (content.S5_EXTENDED_UNTIL_TIME != null) {
					messagecontent.S5_EXTENDED_UNTIL_TIME = content.S5_EXTENDED_UNTIL_TIME[0].Value;
				}

				if (content.S5_INITIAL_UNTIL != null) {
					messagecontent.S5_INITIAL_UNTIL = content.S5_INITIAL_UNTIL[0].Value;
				}

				if (content.S5_COUNT != null) {
					messagecontent.S5_COUNT = content.S5_COUNT[0].Value;
				}
				if (content.S5_RECORD != null) {
					for (int i = 0; i < content.S5_RECORD.Length; i++) {
						RUM_DR_TAUTS5_RECORD_1 s5_record = new RUM_DR_TAUTS5_RECORD_1();

						if (content.S5_RECORD[i].S5_SEQUENCE != null) {
							s5_record.S5_SEQUENCE = content.S5_RECORD[i].S5_SEQUENCE[0].Value;
						}

						if (content.S5_RECORD[i].S5_EXTENDED_UNTIL != null) {
							s5_record.S5_EXTENDED_UNTIL = content.S5_RECORD[i].S5_EXTENDED_UNTIL[0].Value;
						}

						if (content.S5_RECORD[i].S5_INITIALS != null) {
							s5_record.S5_INITIALS = content.S5_RECORD[i].S5_INITIALS[0].Value;
						}

						messagecontent.addS5_RECORD(s5_record);
					}
				}

				if (content.S6_PRESENCE != null) {
					messagecontent.S6_PRESENCE = content.S6_PRESENCE[0].Value;
				}

				if (content.S6_COUNT != null) {
					messagecontent.S6_COUNT = content.S6_COUNT[0].Value;
				}
				if (content.S6_RECORD != null) {
					for (int i = 0; i < content.S6_RECORD.Length; i++) {
						RUM_DR_TAUTS6_RECORD_1 s6_record = new RUM_DR_TAUTS6_RECORD_1();

						if (content.S6_RECORD[i].S6_SEQUENCE != null) {
							s6_record.S6_SEQUENCE = content.S6_RECORD[i].S6_SEQUENCE[0].Value;
						}

						if (content.S6_RECORD[i].S6_ENGINE_INITIAL != null) {
							s6_record.S6_ENGINE_INITIAL = content.S6_RECORD[i].S6_ENGINE_INITIAL[0].Value;
						}

						if (content.S6_RECORD[i].S6_ENGINE_ID != null) {
							s6_record.S6_ENGINE_ID = content.S6_RECORD[i].S6_ENGINE_ID[0].Value;
						}

						if (content.S6_RECORD[i].S6_DIRECTION != null) {
							s6_record.S6_DIRECTION = content.S6_RECORD[i].S6_DIRECTION[0].Value;
						}

						messagecontent.addS6_RECORD(s6_record);
					}
				}

				if (content.S6_AT_DISTRICT != null) {
					messagecontent.S6_AT_DISTRICT = content.S6_AT_DISTRICT[0].Value;
				}

				if (content.S6_AT_TRACK != null) {
					messagecontent.S6_AT_TRACK = content.S6_AT_TRACK[0].Value;
				}

				if (content.S6_AT_MILEPOST != null) {
					messagecontent.S6_AT_MILEPOST = content.S6_AT_MILEPOST[0].Value;
				}

				if (content.S6_AT_LOCATION != null) {
					messagecontent.S6_AT_LOCATION = content.S6_AT_LOCATION[0].Value;
				}

				if (content.S7_PRESENCE != null) {
					messagecontent.S7_PRESENCE = content.S7_PRESENCE[0].Value;
				}

				if (content.S8_PRESENCE != null) {
					messagecontent.S8_PRESENCE = content.S8_PRESENCE[0].Value;
				}

				if (content.S8_COUNT != null) {
					messagecontent.S8_COUNT = content.S8_COUNT[0].Value;
				}
				if (content.S8_RECORD != null) {
					for (int i = 0; i < content.S8_RECORD.Length; i++) {
						RUM_DR_TAUTS8_RECORD_1 s8_record = new RUM_DR_TAUTS8_RECORD_1();

						if (content.S8_RECORD[i].S8_SEQUENCE != null) {
							s8_record.S8_SEQUENCE = content.S8_RECORD[i].S8_SEQUENCE[0].Value;
						}

						if (content.S8_RECORD[i].S8_ENGINE_INITIAL != null) {
							s8_record.S8_ENGINE_INITIAL = content.S8_RECORD[i].S8_ENGINE_INITIAL[0].Value;
						}

						if (content.S8_RECORD[i].S8_ENGINE_NUMBER != null) {
							s8_record.S8_ENGINE_NUMBER = content.S8_RECORD[i].S8_ENGINE_NUMBER[0].Value;
						}

						if (content.S8_RECORD[i].S8_ENGINE_ID != null) {
							s8_record.S8_ENGINE_ID = content.S8_RECORD[i].S8_ENGINE_ID[0].Value;
						}

						if (content.S8_RECORD[i].S8_DIRECTION != null) {
							s8_record.S8_DIRECTION = content.S8_RECORD[i].S8_DIRECTION[0].Value;
						}

						messagecontent.addS8_RECORD(s8_record);
					}
				}

				if (content.S9_PRESENCE != null) {
					messagecontent.S9_PRESENCE = content.S9_PRESENCE[0].Value;
				}

				if (content.S10_PRESENCE != null) {
					messagecontent.S10_PRESENCE = content.S10_PRESENCE[0].Value;
				}

				if (content.S10_BETWEEN_LOCATION != null) {
					messagecontent.S10_BETWEEN_LOCATION = content.S10_BETWEEN_LOCATION[0].Value;
				}

				if (content.S10_AND_LOCATION != null) {
					messagecontent.S10_AND_LOCATION = content.S10_AND_LOCATION[0].Value;
				}

				if (content.S10_COUNT != null) {
					messagecontent.S10_COUNT = content.S10_COUNT[0].Value;
				}
				if (content.S10_RECORD != null) {
					for (int i = 0; i < content.S10_RECORD.Length; i++) {
						RUM_DR_TAUTS10_RECORD_1 s10_record = new RUM_DR_TAUTS10_RECORD_1();

						if (content.S10_RECORD[i].S10_BETWEEN_DISTRICT != null) {
							s10_record.S10_BETWEEN_DISTRICT = content.S10_RECORD[i].S10_BETWEEN_DISTRICT[0].Value;
						}

						if (content.S10_RECORD[i].S10_BETWEEN_MILEPOST != null) {
							s10_record.S10_BETWEEN_MILEPOST = content.S10_RECORD[i].S10_BETWEEN_MILEPOST[0].Value;
						}

						if (content.S10_RECORD[i].S10_AND_DISTRICT != null) {
							s10_record.S10_AND_DISTRICT = content.S10_RECORD[i].S10_AND_DISTRICT[0].Value;
						}

						if (content.S10_RECORD[i].S10_AND_MILEPOST != null) {
							s10_record.S10_AND_MILEPOST = content.S10_RECORD[i].S10_AND_MILEPOST[0].Value;
						}

						if (content.S10_RECORD[i].S10_TRACK != null) {
							s10_record.S10_TRACK = content.S10_RECORD[i].S10_TRACK[0].Value;
						}

						messagecontent.addS10_RECORD(s10_record);
					}
				}

				if (content.S11_PRESENCE != null) {
					messagecontent.S11_PRESENCE = content.S11_PRESENCE[0].Value;
				}

				if (content.S11_DISTRICT != null) {
					messagecontent.S11_DISTRICT = content.S11_DISTRICT[0].Value;
				}

				if (content.S11_MILEPOST != null) {
					messagecontent.S11_MILEPOST = content.S11_MILEPOST[0].Value;
				}

				if (content.S11_LOCATION != null) {
					messagecontent.S11_LOCATION = content.S11_LOCATION[0].Value;
				}

				if (content.S11_TRACK != null) {
					messagecontent.S11_TRACK = content.S11_TRACK[0].Value;
				}

				if (content.S12_PRESENCE != null) {
					messagecontent.S12_PRESENCE = content.S12_PRESENCE[0].Value;
				}

				if (content.S12_COUNT != null) {
					messagecontent.S12_COUNT = content.S12_COUNT[0].Value;
				}
				if (content.S12_RWIC_RECORD != null) {
					for (int i = 0; i < content.S12_RWIC_RECORD.Length; i++) {
						RUM_DR_TAUTS12_RWIC_RECORD_1 s12_rwic_record = new RUM_DR_TAUTS12_RWIC_RECORD_1();

						if (content.S12_RWIC_RECORD[i].S12_RWIC_SEQUENCE != null) {
							s12_rwic_record.S12_RWIC_SEQUENCE = content.S12_RWIC_RECORD[i].S12_RWIC_SEQUENCE[0].Value;
						}

						if (content.S12_RWIC_RECORD[i].S12_RWIC != null) {
							s12_rwic_record.S12_RWIC = content.S12_RWIC_RECORD[i].S12_RWIC[0].Value;
						}

						if (content.S12_RWIC_RECORD[i].S12_BETWEEN_LOCATION != null) {
							s12_rwic_record.S12_BETWEEN_LOCATION = content.S12_RWIC_RECORD[i].S12_BETWEEN_LOCATION[0].Value;
						}

						if (content.S12_RWIC_RECORD[i].S12_AND_LOCATION != null) {
							s12_rwic_record.S12_AND_LOCATION = content.S12_RWIC_RECORD[i].S12_AND_LOCATION[0].Value;
						}

						if (content.S12_RWIC_RECORD[i].S12_TRACK_TEXT != null) {
							s12_rwic_record.S12_TRACK_TEXT = content.S12_RWIC_RECORD[i].S12_TRACK_TEXT[0].Value;
						}

						messagecontent.addS12_RWIC_RECORD(s12_rwic_record);
					}
				}

				if (content.S12_LIMITS_COUNT != null) {
					messagecontent.S12_LIMITS_COUNT = content.S12_LIMITS_COUNT[0].Value;
				}
				if (content.S12_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S12_LIMITS_RECORD.Length; i++) {
						RUM_DR_TAUTS12_LIMITS_RECORD_1 s12_limits_record = new RUM_DR_TAUTS12_LIMITS_RECORD_1();

						if (content.S12_LIMITS_RECORD[i].S12_BETWEEN_DISTRICT != null) {
							s12_limits_record.S12_BETWEEN_DISTRICT = content.S12_LIMITS_RECORD[i].S12_BETWEEN_DISTRICT[0].Value;
						}

						if (content.S12_LIMITS_RECORD[i].S12_BETWEEN_MILEPOST != null) {
							s12_limits_record.S12_BETWEEN_MILEPOST = content.S12_LIMITS_RECORD[i].S12_BETWEEN_MILEPOST[0].Value;
						}

						if (content.S12_LIMITS_RECORD[i].S12_AND_DISTRICT != null) {
							s12_limits_record.S12_AND_DISTRICT = content.S12_LIMITS_RECORD[i].S12_AND_DISTRICT[0].Value;
						}

						if (content.S12_LIMITS_RECORD[i].S12_AND_MILEPOST != null) {
							s12_limits_record.S12_AND_MILEPOST = content.S12_LIMITS_RECORD[i].S12_AND_MILEPOST[0].Value;
						}

						if (content.S12_LIMITS_RECORD[i].S12_TRACK != null) {
							s12_limits_record.S12_TRACK = content.S12_LIMITS_RECORD[i].S12_TRACK[0].Value;
						}

						messagecontent.addS12_LIMITS_RECORD(s12_limits_record);
					}
				}

				if (content.S13_PRESENCE != null) {
					messagecontent.S13_PRESENCE = content.S13_PRESENCE[0].Value;
				}

				if (content.S13_COUNT != null) {
					messagecontent.S13_COUNT = content.S13_COUNT[0].Value;
				}
				if (content.S13_RECORD != null) {
					for (int i = 0; i < content.S13_RECORD.Length; i++) {
						RUM_DR_TAUTS13_RECORD_1 s13_record = new RUM_DR_TAUTS13_RECORD_1();

						if (content.S13_RECORD[i].S13_SEQUENCE != null) {
							s13_record.S13_SEQUENCE = content.S13_RECORD[i].S13_SEQUENCE[0].Value;
						}

						if (content.S13_RECORD[i].S13_TEXT != null) {
							s13_record.S13_TEXT = content.S13_RECORD[i].S13_TEXT[0].Value;
						}

						messagecontent.addS13_RECORD(s13_record);
					}
				}

				if (content.T1_PRESENCE != null) {
					messagecontent.T1_PRESENCE = content.T1_PRESENCE[0].Value;
				}

				if (content.T1_COPIED_BY != null) {
					messagecontent.T1_COPIED_BY = content.T1_COPIED_BY[0].Value;
				}

				if (content.T1_OK_TIME != null) {
					messagecontent.T1_OK_TIME = content.T1_OK_TIME[0].Value;
				}

				if (content.T1_OK_DATE != null) {
					messagecontent.T1_OK_DATE = content.T1_OK_DATE[0].Value;
				}

				if (content.T1_DISPATCHER != null) {
					messagecontent.T1_DISPATCHER = content.T1_DISPATCHER[0].Value;
				}

				if (content.T1_RELAY_EMPLOYEE != null) {
					messagecontent.T1_RELAY_EMPLOYEE = content.T1_RELAY_EMPLOYEE[0].Value;
				}

				if (content.T1_RELAY_LOCATION != null) {
					messagecontent.T1_RELAY_LOCATION = content.T1_RELAY_LOCATION[0].Value;
				}

				if (content.T2_PRESENCE != null) {
					messagecontent.T2_PRESENCE = content.T2_PRESENCE[0].Value;
				}

				if (content.T2_DISTRICT != null) {
					messagecontent.T2_DISTRICT = content.T2_DISTRICT[0].Value;
				}

				if (content.T2_MILEPOST != null) {
					messagecontent.T2_MILEPOST = content.T2_MILEPOST[0].Value;
				}

				if (content.T2_TRACK != null) {
					messagecontent.T2_TRACK = content.T2_TRACK[0].Value;
				}

				if (content.T2_COUNT != null) {
					messagecontent.T2_COUNT = content.T2_COUNT[0].Value;
				}
				if (content.T2_RECORD != null) {
					for (int i = 0; i < content.T2_RECORD.Length; i++) {
						RUM_DR_TAUTT2_RECORD_1 t2_record = new RUM_DR_TAUTT2_RECORD_1();

						if (content.T2_RECORD[i].T2_SEQUENCE != null) {
							t2_record.T2_SEQUENCE = content.T2_RECORD[i].T2_SEQUENCE[0].Value;
						}

						if (content.T2_RECORD[i].T2_ROLLUP_LOCATION != null) {
							t2_record.T2_ROLLUP_LOCATION = content.T2_RECORD[i].T2_ROLLUP_LOCATION[0].Value;
						}

						if (content.T2_RECORD[i].T2_ROLLUP_DATE != null) {
							t2_record.T2_ROLLUP_DATE = content.T2_RECORD[i].T2_ROLLUP_DATE[0].Value;
						}

						if (content.T2_RECORD[i].T2_ROLLUP_TIME != null) {
							t2_record.T2_ROLLUP_TIME = content.T2_RECORD[i].T2_ROLLUP_TIME[0].Value;
						}

						if (content.T2_RECORD[i].T2_BY != null) {
							t2_record.T2_BY = content.T2_RECORD[i].T2_BY[0].Value;
						}

						messagecontent.addT2_RECORD(t2_record);
					}
				}

				if (content.T3_PRESENCE != null) {
					messagecontent.T3_PRESENCE = content.T3_PRESENCE[0].Value;
				}

				if (content.T3_CLEAR_TIME != null) {
					messagecontent.T3_CLEAR_TIME = content.T3_CLEAR_TIME[0].Value;
				}

				if (content.T3_CLEAR_BY != null) {
					messagecontent.T3_CLEAR_BY = content.T3_CLEAR_BY[0].Value;
				}

				if (content.T4_HAVE_JOINT_OCCUPANTS != null) {
					messagecontent.T4_HAVE_JOINT_OCCUPANTS = content.T4_HAVE_JOINT_OCCUPANTS[0].Value;
				}

				if (content.RPT_TEXT_COUNT != null) {
					messagecontent.RPT_TEXT_COUNT = content.RPT_TEXT_COUNT[0].Value;
				}
				if (content.RPT_RECORD != null) {
					for (int i = 0; i < content.RPT_RECORD.Length; i++) {
						RUM_DR_TAUTRPT_RECORD_1 rpt_record = new RUM_DR_TAUTRPT_RECORD_1();

						if (content.RPT_RECORD[i].RPT_SEQUENCE != null) {
							rpt_record.RPT_SEQUENCE = content.RPT_RECORD[i].RPT_SEQUENCE[0].Value;
						}

						if (content.RPT_RECORD[i].RPT_TEXT != null) {
							rpt_record.RPT_TEXT = content.RPT_RECORD[i].RPT_TEXT[0].Value;
						}

						messagecontent.addRPT_RECORD(rpt_record);
					}
				}

				if (content.N251_LIMIT_DISTRICT != null) {
					messagecontent.N251_LIMIT_DISTRICT = content.N251_LIMIT_DISTRICT[0].Value;
				}

				if (content.N251_LIMIT_MILEPOST != null) {
					messagecontent.N251_LIMIT_MILEPOST = content.N251_LIMIT_MILEPOST[0].Value;
				}

				if (content.N251_LIMIT_TRACK != null) {
					messagecontent.N251_LIMIT_TRACK = content.N251_LIMIT_TRACK[0].Value;
				}

				dr_taut_1.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dr_taut_1;
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
	}
	public partial class RUM_DR_TAUTHEADER_1 {
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

	public partial class RUM_DR_TAUTCONTENT_1 {
		public string REQUEST_ID = "";
		public string REQUESTING_EMPLOYEE = "";
		public string DISPATCHER_RESPONSE = "";
		public string ACTION = "";
		public string CREW_ACK_REQUIRED = "";
		public string H_TRACK_AUTHORITY_NUMBER = "";
		public string H_ADDRESSEE_TYPE = "";
		public string H_SCAC = "";
		public string H_SYMBOL = "";
		public string H_SECTION = "";
		public string H_ORIGIN_DATE = "";
		public string H_ENGINE_INITIAL = "";
		public string H_ENGINE_NUMBER = "";
		public string H_COUPLED_ENGINE_INITIAL = "";
		public string H_COUPLED_ENGINE_NUMBER = "";
		public string H_ADDRESSEE_ID = "";
		public string H_ADDRESSEE = "";
		public string H_AT_LOCATION = "";
		public string S1_PRESENCE = "";
		public string S1_TRACK_AUTHORITY_NUMBER = "";
		public string S2_PRESENCE = "";
		public string S2_FROM_LOCATION = "";
		public string S2_COUNT = "";
		public ArrayList S2_RECORD = new ArrayList();
		public string S2_LIMITS_COUNT = "";
		public ArrayList S2_LIMITS_RECORD = new ArrayList();
		public string S3_PRESENCE = "";
		public string S3_BETWEEN_LOCATION = "";
		public string S3_AND_LOCATION = "";
		public string S3_TRACK_COUNT = "";
		public ArrayList S3_TRACK_RECORD = new ArrayList();
		public string S3_LIMITS_COUNT = "";
		public ArrayList S3_LIMITS_RECORD = new ArrayList();
		public string S4_PRESENCE = "";
		public string S4_FROM_LOCATION = "";
		public string S4_COUNT = "";
		public ArrayList S4_RECORD = new ArrayList();
		public string S4_LIMITS_COUNT = "";
		public ArrayList S4_LIMITS_RECORD = new ArrayList();
		public string S5_PRESENCE = "";
		public string S5_INITIAL_UNTIL_DATE = "";
		public string S5_INITIAL_UNTIL_TIME = "";
		public string S5_EXTENDED_UNTIL_DATE = "";
		public string S5_EXTENDED_UNTIL_TIME = "";
		public string S5_INITIAL_UNTIL = "";
		public string S5_COUNT = "";
		public ArrayList S5_RECORD = new ArrayList();
		public string S6_PRESENCE = "";
		public string S6_COUNT = "";
		public ArrayList S6_RECORD = new ArrayList();
		public string S6_AT_DISTRICT = "";
		public string S6_AT_TRACK = "";
		public string S6_AT_MILEPOST = "";
		public string S6_AT_LOCATION = "";
		public string S7_PRESENCE = "";
		public string S8_PRESENCE = "";
		public string S8_COUNT = "";
		public ArrayList S8_RECORD = new ArrayList();
		public string S9_PRESENCE = "";
		public string S10_PRESENCE = "";
		public string S10_BETWEEN_LOCATION = "";
		public string S10_AND_LOCATION = "";
		public string S10_COUNT = "";
		public ArrayList S10_RECORD = new ArrayList();
		public string S11_PRESENCE = "";
		public string S11_DISTRICT = "";
		public string S11_MILEPOST = "";
		public string S11_LOCATION = "";
		public string S11_TRACK = "";
		public string S12_PRESENCE = "";
		public string S12_COUNT = "";
		public ArrayList S12_RWIC_RECORD = new ArrayList();
		public string S12_LIMITS_COUNT = "";
		public ArrayList S12_LIMITS_RECORD = new ArrayList();
		public string S13_PRESENCE = "";
		public string S13_COUNT = "";
		public ArrayList S13_RECORD = new ArrayList();
		public string T1_PRESENCE = "";
		public string T1_COPIED_BY = "";
		public string T1_OK_TIME = "";
		public string T1_OK_DATE = "";
		public string T1_DISPATCHER = "";
		public string T1_RELAY_EMPLOYEE = "";
		public string T1_RELAY_LOCATION = "";
		public string T2_PRESENCE = "";
		public string T2_DISTRICT = "";
		public string T2_MILEPOST = "";
		public string T2_TRACK = "";
		public string T2_COUNT = "";
		public ArrayList T2_RECORD = new ArrayList();
		public string T3_PRESENCE = "";
		public string T3_CLEAR_TIME = "";
		public string T3_CLEAR_BY = "";
		public string T4_HAVE_JOINT_OCCUPANTS = "";
		public string RPT_TEXT_COUNT = "";
		public ArrayList RPT_RECORD = new ArrayList();
		public string N251_LIMIT_DISTRICT = "";
		public string N251_LIMIT_MILEPOST = "";
		public string N251_LIMIT_TRACK = "";

		public void addS2_RECORD(RUM_DR_TAUTS2_RECORD_1 s2_record) {
			this.S2_RECORD.Add(s2_record);
		}

		public void addS2_LIMITS_RECORD(RUM_DR_TAUTS2_LIMITS_RECORD_1 s2_limits_record) {
			this.S2_LIMITS_RECORD.Add(s2_limits_record);
		}

		public void addS3_TRACK_RECORD(RUM_DR_TAUTS3_TRACK_RECORD_1 s3_track_record) {
			this.S3_TRACK_RECORD.Add(s3_track_record);
		}

		public void addS3_LIMITS_RECORD(RUM_DR_TAUTS3_LIMITS_RECORD_1 s3_limits_record) {
			this.S3_LIMITS_RECORD.Add(s3_limits_record);
		}

		public void addS4_RECORD(RUM_DR_TAUTS4_RECORD_1 s4_record) {
			this.S4_RECORD.Add(s4_record);
		}

		public void addS4_LIMITS_RECORD(RUM_DR_TAUTS4_LIMITS_RECORD_1 s4_limits_record) {
			this.S4_LIMITS_RECORD.Add(s4_limits_record);
		}

		public void addS5_RECORD(RUM_DR_TAUTS5_RECORD_1 s5_record) {
			this.S5_RECORD.Add(s5_record);
		}

		public void addS6_RECORD(RUM_DR_TAUTS6_RECORD_1 s6_record) {
			this.S6_RECORD.Add(s6_record);
		}

		public void addS8_RECORD(RUM_DR_TAUTS8_RECORD_1 s8_record) {
			this.S8_RECORD.Add(s8_record);
		}

		public void addS10_RECORD(RUM_DR_TAUTS10_RECORD_1 s10_record) {
			this.S10_RECORD.Add(s10_record);
		}

		public void addS12_RWIC_RECORD(RUM_DR_TAUTS12_RWIC_RECORD_1 s12_rwic_record) {
			this.S12_RWIC_RECORD.Add(s12_rwic_record);
		}

		public void addS12_LIMITS_RECORD(RUM_DR_TAUTS12_LIMITS_RECORD_1 s12_limits_record) {
			this.S12_LIMITS_RECORD.Add(s12_limits_record);
		}

		public void addS13_RECORD(RUM_DR_TAUTS13_RECORD_1 s13_record) {
			this.S13_RECORD.Add(s13_record);
		}

		public void addT2_RECORD(RUM_DR_TAUTT2_RECORD_1 t2_record) {
			this.T2_RECORD.Add(t2_record);
		}

		public void addRPT_RECORD(RUM_DR_TAUTRPT_RECORD_1 rpt_record) {
			this.RPT_RECORD.Add(rpt_record);
		}
	}

	public partial class RUM_DR_TAUTS2_RECORD_1 {
		public string S2_SEQUENCE = "";
		public string S2_TO_LOCATION = "";
		public string S2_TRACK_TEXT = "";
	}

	public partial class RUM_DR_TAUTS2_LIMITS_RECORD_1 {
		public string S2_FROM_DISTRICT = "";
		public string S2_FROM_MILEPOST = "";
		public string S2_TO_DISTRICT = "";
		public string S2_TO_MILEPOST = "";
		public string S2_TRACK = "";
	}

	public partial class RUM_DR_TAUTS3_TRACK_RECORD_1 {
		public string S3_TRACK_SEQUENCE = "";
		public string S3_TRACK_TEXT = "";
	}

	public partial class RUM_DR_TAUTS3_LIMITS_RECORD_1 {
		public string S3_BETWEEN_DISTRICT = "";
		public string S3_BETWEEN_MILEPOST = "";
		public string S3_AND_DISTRICT = "";
		public string S3_AND_MILEPOST = "";
		public string S3_TRACK = "";
	}

	public partial class RUM_DR_TAUTS4_RECORD_1 {
		public string S4_SEQUENCE = "";
		public string S4_TO_LOCATION = "";
		public string S4_TRACK_TEXT = "";
	}

	public partial class RUM_DR_TAUTS4_LIMITS_RECORD_1 {
		public string S4_FROM_DISTRICT = "";
		public string S4_FROM_MILEPOST = "";
		public string S4_TO_DISTRICT = "";
		public string S4_TO_MILEPOST = "";
		public string S4_TRACK = "";
	}

	public partial class RUM_DR_TAUTS5_RECORD_1 {
		public string S5_SEQUENCE = "";
		public string S5_EXTENDED_UNTIL = "";
		public string S5_INITIALS = "";
	}

	public partial class RUM_DR_TAUTS6_RECORD_1 {
		public string S6_SEQUENCE = "";
		public string S6_ENGINE_INITIAL = "";
		public string S6_ENGINE_ID = "";
		public string S6_DIRECTION = "";
	}

	public partial class RUM_DR_TAUTS8_RECORD_1 {
		public string S8_SEQUENCE = "";
		public string S8_ENGINE_INITIAL = "";
		public string S8_ENGINE_NUMBER = "";
		public string S8_ENGINE_ID = "";
		public string S8_DIRECTION = "";
	}

	public partial class RUM_DR_TAUTS10_RECORD_1 {
		public string S10_BETWEEN_DISTRICT = "";
		public string S10_BETWEEN_MILEPOST = "";
		public string S10_AND_DISTRICT = "";
		public string S10_AND_MILEPOST = "";
		public string S10_TRACK = "";
	}

	public partial class RUM_DR_TAUTS12_RWIC_RECORD_1 {
		public string S12_RWIC_SEQUENCE = "";
		public string S12_RWIC = "";
		public string S12_BETWEEN_LOCATION = "";
		public string S12_AND_LOCATION = "";
		public string S12_TRACK_TEXT = "";
	}

	public partial class RUM_DR_TAUTS12_LIMITS_RECORD_1 {
		public string S12_BETWEEN_DISTRICT = "";
		public string S12_BETWEEN_MILEPOST = "";
		public string S12_AND_DISTRICT = "";
		public string S12_AND_MILEPOST = "";
		public string S12_TRACK = "";
	}

	public partial class RUM_DR_TAUTS13_RECORD_1 {
		public string S13_SEQUENCE = "";
		public string S13_TEXT = "";
	}

	public partial class RUM_DR_TAUTT2_RECORD_1 {
		public string T2_SEQUENCE = "";
		public string T2_ROLLUP_LOCATION = "";
		public string T2_ROLLUP_DATE = "";
		public string T2_ROLLUP_TIME = "";
		public string T2_BY = "";
	}

	public partial class RUM_DR_TAUTRPT_RECORD_1 {
		public string RPT_SEQUENCE = "";
		public string RPT_TEXT = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DR_TAUT_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DR_TAUTHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DR_TAUTCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTHEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTHEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_REQUEST_ID_1[] REQUEST_ID;

		[System.Xml.Serialization.XmlElementAttribute("REQUESTING_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_REQUESTING_EMPLOYEE_1[] REQUESTING_EMPLOYEE;

		[System.Xml.Serialization.XmlElementAttribute("DISPATCHER_RESPONSE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_DISPATCHER_RESPONSE_1[] DISPATCHER_RESPONSE;

		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_ACTION_1[] ACTION;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_CREW_ACK_REQUIRED_1[] CREW_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("H_TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_TRACK_AUTHORITY_NUMBER_1[] H_TRACK_AUTHORITY_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ADDRESSEE_TYPE_1[] H_ADDRESSEE_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("H_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_SCAC_1[] H_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("H_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_SYMBOL_1[] H_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("H_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_SECTION_1[] H_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("H_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ORIGIN_DATE_1[] H_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("H_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ENGINE_INITIAL_1[] H_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("H_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ENGINE_NUMBER_1[] H_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_COUPLED_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_COUPLED_ENGINE_INITIAL_1[] H_COUPLED_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("H_COUPLED_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_COUPLED_ENGINE_NUMBER_1[] H_COUPLED_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ADDRESSEE_ID_1[] H_ADDRESSEE_ID;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_ADDRESSEE_1[] H_ADDRESSEE;

		[System.Xml.Serialization.XmlElementAttribute("H_AT_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_H_AT_LOCATION_1[] H_AT_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S1_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S1_PRESENCE_1[] S1_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S1_TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S1_TRACK_AUTHORITY_NUMBER_1[] S1_TRACK_AUTHORITY_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("S2_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_PRESENCE_1[] S2_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_FROM_LOCATION_1[] S2_FROM_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S2_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_COUNT_1[] S2_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S2_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_RECORD_1[] S2_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S2_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_LIMITS_COUNT_1[] S2_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S2_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S2_LIMITS_RECORD_1[] S2_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S3_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_PRESENCE_1[] S3_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_BETWEEN_LOCATION_1[] S3_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_AND_LOCATION_1[] S3_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_TRACK_COUNT_1[] S3_TRACK_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_TRACK_RECORD_1[] S3_TRACK_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S3_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_LIMITS_COUNT_1[] S3_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S3_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S3_LIMITS_RECORD_1[] S3_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S4_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_PRESENCE_1[] S4_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_FROM_LOCATION_1[] S4_FROM_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S4_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_COUNT_1[] S4_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S4_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_RECORD_1[] S4_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S4_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_LIMITS_COUNT_1[] S4_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S4_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S4_LIMITS_RECORD_1[] S4_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S5_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_PRESENCE_1[] S5_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIAL_UNTIL_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_INITIAL_UNTIL_DATE_1[] S5_INITIAL_UNTIL_DATE;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIAL_UNTIL_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_INITIAL_UNTIL_TIME_1[] S5_INITIAL_UNTIL_TIME;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_EXTENDED_UNTIL_DATE_1[] S5_EXTENDED_UNTIL_DATE;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_EXTENDED_UNTIL_TIME_1[] S5_EXTENDED_UNTIL_TIME;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIAL_UNTIL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_INITIAL_UNTIL_1[] S5_INITIAL_UNTIL;

		[System.Xml.Serialization.XmlElementAttribute("S5_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_COUNT_1[] S5_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S5_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S5_RECORD_1[] S5_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S6_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_PRESENCE_1[] S6_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S6_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_COUNT_1[] S6_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S6_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_RECORD_1[] S6_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_AT_DISTRICT_1[] S6_AT_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_AT_TRACK_1[] S6_AT_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_AT_MILEPOST_1[] S6_AT_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S6_AT_LOCATION_1[] S6_AT_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S7_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S7_PRESENCE_1[] S7_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S8_PRESENCE_1[] S8_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S8_COUNT_1[] S8_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S8_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S8_RECORD_1[] S8_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S9_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S9_PRESENCE_1[] S9_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S10_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S10_PRESENCE_1[] S10_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S10_BETWEEN_LOCATION_1[] S10_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S10_AND_LOCATION_1[] S10_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S10_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S10_COUNT_1[] S10_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S10_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S10_RECORD_1[] S10_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S11_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S11_PRESENCE_1[] S11_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S11_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S11_DISTRICT_1[] S11_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S11_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S11_MILEPOST_1[] S11_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S11_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S11_LOCATION_1[] S11_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S11_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S11_TRACK_1[] S11_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("S12_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S12_PRESENCE_1[] S12_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S12_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S12_COUNT_1[] S12_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S12_RWIC_RECORD_1[] S12_RWIC_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S12_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S12_LIMITS_COUNT_1[] S12_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S12_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S12_LIMITS_RECORD_1[] S12_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S13_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S13_PRESENCE_1[] S13_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S13_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S13_COUNT_1[] S13_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S13_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_S13_RECORD_1[] S13_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("T1_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_PRESENCE_1[] T1_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T1_COPIED_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_COPIED_BY_1[] T1_COPIED_BY;

		[System.Xml.Serialization.XmlElementAttribute("T1_OK_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_OK_TIME_1[] T1_OK_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T1_OK_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_OK_DATE_1[] T1_OK_DATE;

		[System.Xml.Serialization.XmlElementAttribute("T1_DISPATCHER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_DISPATCHER_1[] T1_DISPATCHER;

		[System.Xml.Serialization.XmlElementAttribute("T1_RELAY_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_RELAY_EMPLOYEE_1[] T1_RELAY_EMPLOYEE;

		[System.Xml.Serialization.XmlElementAttribute("T1_RELAY_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T1_RELAY_LOCATION_1[] T1_RELAY_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("T2_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_PRESENCE_1[] T2_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T2_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_DISTRICT_1[] T2_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("T2_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_MILEPOST_1[] T2_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("T2_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_TRACK_1[] T2_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("T2_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_COUNT_1[] T2_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("T2_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T2_RECORD_1[] T2_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("T3_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T3_PRESENCE_1[] T3_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T3_CLEAR_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T3_CLEAR_TIME_1[] T3_CLEAR_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T3_CLEAR_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T3_CLEAR_BY_1[] T3_CLEAR_BY;

		[System.Xml.Serialization.XmlElementAttribute("T4_HAVE_JOINT_OCCUPANTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_T4_HAVE_JOINT_OCCUPANTS_1[] T4_HAVE_JOINT_OCCUPANTS;

		[System.Xml.Serialization.XmlElementAttribute("RPT_TEXT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_RPT_TEXT_COUNT_1[] RPT_TEXT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RPT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_RPT_RECORD_1[] RPT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("251_LIMIT_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_N251_LIMIT_DISTRICT_1[] N251_LIMIT_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("251_LIMIT_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_N251_LIMIT_MILEPOST_1[] N251_LIMIT_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("251_LIMIT_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTCONTENT_N251_LIMIT_TRACK_1[] N251_LIMIT_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_REQUEST_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_REQUESTING_EMPLOYEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_DISPATCHER_RESPONSE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_ACTION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_CREW_ACK_REQUIRED_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_TRACK_AUTHORITY_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ADDRESSEE_TYPE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_SYMBOL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_SECTION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ORIGIN_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ENGINE_INITIAL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ENGINE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_COUPLED_ENGINE_INITIAL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_COUPLED_ENGINE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ADDRESSEE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_ADDRESSEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_H_AT_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S1_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S1_TRACK_AUTHORITY_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_FROM_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S2_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_RECORD_S2_SEQUENCE_1[] S2_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_RECORD_S2_TO_LOCATION_1[] S2_TO_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S2_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_RECORD_S2_TRACK_TEXT_1[] S2_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_RECORD_S2_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_RECORD_S2_TO_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_RECORD_S2_TRACK_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_LIMITS_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S2_LIMITS_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_LIMITS_RECORD_S2_FROM_DISTRICT_1[] S2_FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_LIMITS_RECORD_S2_FROM_MILEPOST_1[] S2_FROM_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_LIMITS_RECORD_S2_TO_DISTRICT_1[] S2_TO_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_LIMITS_RECORD_S2_TO_MILEPOST_1[] S2_TO_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S2_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS2_LIMITS_RECORD_S2_TRACK_1[] S2_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_LIMITS_RECORD_S2_FROM_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_LIMITS_RECORD_S2_FROM_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_LIMITS_RECORD_S2_TO_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_LIMITS_RECORD_S2_TO_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS2_LIMITS_RECORD_S2_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_BETWEEN_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_AND_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_TRACK_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_TRACK_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_TRACK_RECORD_S3_TRACK_SEQUENCE_1[] S3_TRACK_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_TRACK_RECORD_S3_TRACK_TEXT_1[] S3_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_TRACK_RECORD_S3_TRACK_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_TRACK_RECORD_S3_TRACK_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_LIMITS_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S3_LIMITS_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_LIMITS_RECORD_S3_BETWEEN_DISTRICT_1[] S3_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_LIMITS_RECORD_S3_BETWEEN_MILEPOST_1[] S3_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_LIMITS_RECORD_S3_AND_DISTRICT_1[] S3_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_LIMITS_RECORD_S3_AND_MILEPOST_1[] S3_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS3_LIMITS_RECORD_S3_TRACK_1[] S3_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_LIMITS_RECORD_S3_BETWEEN_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_LIMITS_RECORD_S3_BETWEEN_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_LIMITS_RECORD_S3_AND_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_LIMITS_RECORD_S3_AND_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS3_LIMITS_RECORD_S3_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_FROM_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S4_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_RECORD_S4_SEQUENCE_1[] S4_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_RECORD_S4_TO_LOCATION_1[] S4_TO_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S4_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_RECORD_S4_TRACK_TEXT_1[] S4_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_RECORD_S4_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_RECORD_S4_TO_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_RECORD_S4_TRACK_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_LIMITS_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S4_LIMITS_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_LIMITS_RECORD_S4_FROM_DISTRICT_1[] S4_FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_LIMITS_RECORD_S4_FROM_MILEPOST_1[] S4_FROM_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_LIMITS_RECORD_S4_TO_DISTRICT_1[] S4_TO_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_LIMITS_RECORD_S4_TO_MILEPOST_1[] S4_TO_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S4_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS4_LIMITS_RECORD_S4_TRACK_1[] S4_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_LIMITS_RECORD_S4_FROM_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_LIMITS_RECORD_S4_FROM_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_LIMITS_RECORD_S4_TO_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_LIMITS_RECORD_S4_TO_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS4_LIMITS_RECORD_S4_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_INITIAL_UNTIL_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_INITIAL_UNTIL_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_EXTENDED_UNTIL_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_EXTENDED_UNTIL_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_INITIAL_UNTIL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S5_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S5_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS5_RECORD_S5_SEQUENCE_1[] S5_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS5_RECORD_S5_EXTENDED_UNTIL_1[] S5_EXTENDED_UNTIL;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIALS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS5_RECORD_S5_INITIALS_1[] S5_INITIALS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS5_RECORD_S5_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS5_RECORD_S5_EXTENDED_UNTIL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS5_RECORD_S5_INITIALS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S6_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS6_RECORD_S6_SEQUENCE_1[] S6_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S6_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS6_RECORD_S6_ENGINE_INITIAL_1[] S6_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("S6_ENGINE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS6_RECORD_S6_ENGINE_ID_1[] S6_ENGINE_ID;

		[System.Xml.Serialization.XmlElementAttribute("S6_DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS6_RECORD_S6_DIRECTION_1[] S6_DIRECTION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS6_RECORD_S6_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS6_RECORD_S6_ENGINE_INITIAL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS6_RECORD_S6_ENGINE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS6_RECORD_S6_DIRECTION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_AT_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_AT_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_AT_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S6_AT_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S7_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S8_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S8_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S8_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S8_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS8_RECORD_S8_SEQUENCE_1[] S8_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS8_RECORD_S8_ENGINE_INITIAL_1[] S8_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS8_RECORD_S8_ENGINE_NUMBER_1[] S8_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS8_RECORD_S8_ENGINE_ID_1[] S8_ENGINE_ID;

		[System.Xml.Serialization.XmlElementAttribute("S8_DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS8_RECORD_S8_DIRECTION_1[] S8_DIRECTION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS8_RECORD_S8_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS8_RECORD_S8_ENGINE_INITIAL_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS8_RECORD_S8_ENGINE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS8_RECORD_S8_ENGINE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS8_RECORD_S8_DIRECTION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S9_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S10_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S10_BETWEEN_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S10_AND_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S10_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S10_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS10_RECORD_S10_BETWEEN_DISTRICT_1[] S10_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS10_RECORD_S10_BETWEEN_MILEPOST_1[] S10_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS10_RECORD_S10_AND_DISTRICT_1[] S10_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS10_RECORD_S10_AND_MILEPOST_1[] S10_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S10_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS10_RECORD_S10_TRACK_1[] S10_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS10_RECORD_S10_BETWEEN_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS10_RECORD_S10_BETWEEN_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS10_RECORD_S10_AND_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS10_RECORD_S10_AND_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS10_RECORD_S10_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S11_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S11_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S11_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S11_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S11_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S12_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S12_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S12_RWIC_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_RWIC_RECORD_S12_RWIC_SEQUENCE_1[] S12_RWIC_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_RWIC_RECORD_S12_RWIC_1[] S12_RWIC;

		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_RWIC_RECORD_S12_BETWEEN_LOCATION_1[] S12_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_RWIC_RECORD_S12_AND_LOCATION_1[] S12_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S12_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_RWIC_RECORD_S12_TRACK_TEXT_1[] S12_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_RWIC_RECORD_S12_RWIC_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_RWIC_RECORD_S12_RWIC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_RWIC_RECORD_S12_BETWEEN_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_RWIC_RECORD_S12_AND_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_RWIC_RECORD_S12_TRACK_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S12_LIMITS_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S12_LIMITS_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_LIMITS_RECORD_S12_BETWEEN_DISTRICT_1[] S12_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_LIMITS_RECORD_S12_BETWEEN_MILEPOST_1[] S12_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_LIMITS_RECORD_S12_AND_DISTRICT_1[] S12_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_LIMITS_RECORD_S12_AND_MILEPOST_1[] S12_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S12_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS12_LIMITS_RECORD_S12_TRACK_1[] S12_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_LIMITS_RECORD_S12_BETWEEN_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_LIMITS_RECORD_S12_BETWEEN_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_LIMITS_RECORD_S12_AND_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_LIMITS_RECORD_S12_AND_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS12_LIMITS_RECORD_S12_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S13_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S13_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_S13_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("S13_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS13_RECORD_S13_SEQUENCE_1[] S13_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S13_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTS13_RECORD_S13_TEXT_1[] S13_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS13_RECORD_S13_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTS13_RECORD_S13_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_COPIED_BY_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_OK_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_OK_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_DISPATCHER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_RELAY_EMPLOYEE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T1_RELAY_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T2_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("T2_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTT2_RECORD_T2_SEQUENCE_1[] T2_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTT2_RECORD_T2_ROLLUP_LOCATION_1[] T2_ROLLUP_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTT2_RECORD_T2_ROLLUP_DATE_1[] T2_ROLLUP_DATE;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTT2_RECORD_T2_ROLLUP_TIME_1[] T2_ROLLUP_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T2_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTT2_RECORD_T2_BY_1[] T2_BY;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTT2_RECORD_T2_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTT2_RECORD_T2_ROLLUP_LOCATION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTT2_RECORD_T2_ROLLUP_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTT2_RECORD_T2_ROLLUP_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTT2_RECORD_T2_BY_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T3_PRESENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T3_CLEAR_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T3_CLEAR_BY_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_T4_HAVE_JOINT_OCCUPANTS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_RPT_TEXT_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_RPT_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("RPT_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTRPT_RECORD_RPT_SEQUENCE_1[] RPT_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("RPT_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_TAUTRPT_RECORD_RPT_TEXT_1[] RPT_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTRPT_RECORD_RPT_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTRPT_RECORD_RPT_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_N251_LIMIT_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_N251_LIMIT_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_TAUTCONTENT_N251_LIMIT_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}