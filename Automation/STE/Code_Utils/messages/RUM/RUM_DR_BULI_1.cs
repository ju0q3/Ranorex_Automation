using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.RUM
{
	public partial class RUM_DR_BULI_1 {
		public RUM_DR_BULIHEADER_1 HEADER;
		public RUM_DR_BULICONTENT_1 CONTENT;

		public static RUM_DR_BULI_1 fromSerializableObject(DR_BULI_1 message) {
			RUM_DR_BULI_1 dr_buli_1 = new RUM_DR_BULI_1();
			DR_BULIHEADER_1 header = null;
			DR_BULICONTENT_1 content = null;
			header = (DR_BULIHEADER_1) message.Items[0];
			content = (DR_BULICONTENT_1) message.Items[1];

			if (header != null) {
				RUM_DR_BULIHEADER_1 messageheader = new RUM_DR_BULIHEADER_1();

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

				dr_buli_1.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				RUM_DR_BULICONTENT_1 messagecontent = new RUM_DR_BULICONTENT_1();

				if (content.REQUEST_ID != null) {
					messagecontent.REQUEST_ID = content.REQUEST_ID[0].Value;
					if (messagecontent.REQUEST_ID != null) {
						if (messagecontent.REQUEST_ID.Length < 1 || messagecontent.REQUEST_ID.Length > 13) {
							Ranorex.Report.Failure("Field REQUEST_ID expected to be length between or equal to 1 and 13, has length of {" + messagecontent.REQUEST_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.ISSUE_DATE != null) {
					messagecontent.ISSUE_DATE = content.ISSUE_DATE[0].Value;
					if (messagecontent.ISSUE_DATE != null) {
						if (messagecontent.ISSUE_DATE.Length != 8) {
							Ranorex.Report.Failure("Field ISSUE_DATE expected to be length of 8, has length of {" + messagecontent.ISSUE_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ISSUE_DATE)) {
							Ranorex.Report.Failure("Field ISSUE_DATE expected to be Numeric, has value of {" + messagecontent.ISSUE_DATE + "}.");
						}
					}
				}

				if (content.ISSUE_TIME != null) {
					messagecontent.ISSUE_TIME = content.ISSUE_TIME[0].Value;
					if (messagecontent.ISSUE_TIME != null) {
						if (messagecontent.ISSUE_TIME.Length != 4) {
							Ranorex.Report.Failure("Field ISSUE_TIME expected to be length of 4, has length of {" + messagecontent.ISSUE_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ISSUE_TIME)) {
							Ranorex.Report.Failure("Field ISSUE_TIME expected to be Numeric, has value of {" + messagecontent.ISSUE_TIME + "}.");
						}
					}
				}

				if (content.ISSUE_TIME_ZONE != null) {
					messagecontent.ISSUE_TIME_ZONE = content.ISSUE_TIME_ZONE[0].Value;
					if (messagecontent.ISSUE_TIME_ZONE != null) {
						if (messagecontent.ISSUE_TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field ISSUE_TIME_ZONE expected to be length of 1, has length of {" + messagecontent.ISSUE_TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.ISSUE_TIME_ZONE)) {
							Ranorex.Report.Failure("Field ISSUE_TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.ISSUE_TIME_ZONE + "}.");
						}
						if (messagecontent.ISSUE_TIME_ZONE != "E" && messagecontent.ISSUE_TIME_ZONE != "C") {
							Ranorex.Report.Failure("Field ISSUE_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + messagecontent.ISSUE_TIME_ZONE + "}.");
						}
					}
				}

				if (content.DISPATCHER != null) {
					messagecontent.DISPATCHER = content.DISPATCHER[0].Value;
					if (messagecontent.DISPATCHER != null) {
						if (messagecontent.DISPATCHER.Length < 2 || messagecontent.DISPATCHER.Length > 3) {
							Ranorex.Report.Failure("Field DISPATCHER expected to be length between or equal to 2 and 3, has length of {" + messagecontent.DISPATCHER.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.DISPATCHER)) {
							Ranorex.Report.Failure("Field DISPATCHER expected to be Alphabetic, has value of {" + messagecontent.DISPATCHER + "}.");
						}
					}
				}

				if (content.DISPATCHER_RESPONSE != null) {
					messagecontent.DISPATCHER_RESPONSE = content.DISPATCHER_RESPONSE[0].Value;
					if (messagecontent.DISPATCHER_RESPONSE != null) {
						if (messagecontent.DISPATCHER_RESPONSE.Length < 1 || messagecontent.DISPATCHER_RESPONSE.Length > 100) {
							Ranorex.Report.Failure("Field DISPATCHER_RESPONSE expected to be length between or equal to 1 and 100, has length of {" + messagecontent.DISPATCHER_RESPONSE.Length.ToString() + "}.");
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
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.BULLETIN_ITEM_NUMBER);
							if (intConvertedValue < 1 || intConvertedValue > 99999) {
								Ranorex.Report.Failure("Field BULLETIN_ITEM_NUMBER expected to have value between 1 and 99999, but was found to have a value of " + messagecontent.BULLETIN_ITEM_NUMBER + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field BULLETIN_ITEM_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.BULLETIN_ITEM_TYPE != null) {
					messagecontent.BULLETIN_ITEM_TYPE = content.BULLETIN_ITEM_TYPE[0].Value;
					if (messagecontent.BULLETIN_ITEM_TYPE != null) {
						if (messagecontent.BULLETIN_ITEM_TYPE.Length < 1 || messagecontent.BULLETIN_ITEM_TYPE.Length > 100) {
							Ranorex.Report.Failure("Field BULLETIN_ITEM_TYPE expected to be length between or equal to 1 and 100, has length of {" + messagecontent.BULLETIN_ITEM_TYPE.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field BULLETIN_ITEM_TYPE is a Mandatory field but was found to be missing from the message");
				}

				if (content.FROM_LIMIT != null) {
					messagecontent.FROM_LIMIT = content.FROM_LIMIT[0].Value;
					if (messagecontent.FROM_LIMIT != null) {
						if (messagecontent.FROM_LIMIT.Length < 1 || messagecontent.FROM_LIMIT.Length > 27) {
							Ranorex.Report.Failure("Field FROM_LIMIT expected to be length between or equal to 1 and 27, has length of {" + messagecontent.FROM_LIMIT.Length.ToString() + "}.");
						}
					}
				}

				if (content.TO_LIMIT != null) {
					messagecontent.TO_LIMIT = content.TO_LIMIT[0].Value;
					if (messagecontent.TO_LIMIT != null) {
						if (messagecontent.TO_LIMIT.Length < 1 || messagecontent.TO_LIMIT.Length > 27) {
							Ranorex.Report.Failure("Field TO_LIMIT expected to be length between or equal to 1 and 27, has length of {" + messagecontent.TO_LIMIT.Length.ToString() + "}.");
						}
					}
				}

				if (content.EYE_CATCHER_TEXT != null) {
					messagecontent.EYE_CATCHER_TEXT = content.EYE_CATCHER_TEXT[0].Value;
					if (messagecontent.EYE_CATCHER_TEXT != null) {
						if (messagecontent.EYE_CATCHER_TEXT.Length < 1 || messagecontent.EYE_CATCHER_TEXT.Length > 7) {
							Ranorex.Report.Failure("Field EYE_CATCHER_TEXT expected to be length between or equal to 1 and 7, has length of {" + messagecontent.EYE_CATCHER_TEXT.Length.ToString() + "}.");
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
				} else {
					Ranorex.Report.Failure("Field EFFECTIVE_DATE is a Mandatory field but was found to be missing from the message");
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
				} else {
					Ranorex.Report.Failure("Field EFFECTIVE_TIME is a Mandatory field but was found to be missing from the message");
				}

				if (content.EXPIRATION_DATE != null) {
					messagecontent.EXPIRATION_DATE = content.EXPIRATION_DATE[0].Value;
					if (messagecontent.EXPIRATION_DATE != null) {
						if (messagecontent.EXPIRATION_DATE.Length != 8) {
							Ranorex.Report.Failure("Field EXPIRATION_DATE expected to be length of 8, has length of {" + messagecontent.EXPIRATION_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EXPIRATION_DATE)) {
							Ranorex.Report.Failure("Field EXPIRATION_DATE expected to be Numeric, has value of {" + messagecontent.EXPIRATION_DATE + "}.");
						}
					}
				}

				if (content.EXPIRATION_TIME != null) {
					messagecontent.EXPIRATION_TIME = content.EXPIRATION_TIME[0].Value;
					if (messagecontent.EXPIRATION_TIME != null) {
						if (messagecontent.EXPIRATION_TIME.Length != 4) {
							Ranorex.Report.Failure("Field EXPIRATION_TIME expected to be length of 4, has length of {" + messagecontent.EXPIRATION_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EXPIRATION_TIME)) {
							Ranorex.Report.Failure("Field EXPIRATION_TIME expected to be Numeric, has value of {" + messagecontent.EXPIRATION_TIME + "}.");
						}
					}
				}

				if (content.SPEED != null) {
					messagecontent.SPEED = content.SPEED[0].Value;
					if (messagecontent.SPEED != null) {
						if (messagecontent.SPEED.Length < 1 || messagecontent.SPEED.Length > 3) {
							Ranorex.Report.Failure("Field SPEED expected to be length between or equal to 1 and 3, has length of {" + messagecontent.SPEED.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SPEED)) {
							Ranorex.Report.Failure("Field SPEED expected to be Numeric, has value of {" + messagecontent.SPEED + "}.");
						}
					}
				}

				if (content.HEO_SPEED_RESTRICTION != null) {
					messagecontent.HEO_SPEED_RESTRICTION = content.HEO_SPEED_RESTRICTION[0].Value;
					if (messagecontent.HEO_SPEED_RESTRICTION != null) {
						if (messagecontent.HEO_SPEED_RESTRICTION.Length != 1) {
							Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be length of 1, has length of {" + messagecontent.HEO_SPEED_RESTRICTION.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.HEO_SPEED_RESTRICTION)) {
							Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be Alphabetic, has value of {" + messagecontent.HEO_SPEED_RESTRICTION + "}.");
						}
						if (messagecontent.HEO_SPEED_RESTRICTION != "Y" && messagecontent.HEO_SPEED_RESTRICTION != "N") {
							Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.HEO_SPEED_RESTRICTION + "}.");
						}
					}
				}

				if (content.CONTACT != null) {
					messagecontent.CONTACT = content.CONTACT[0].Value;
					if (messagecontent.CONTACT != null) {
						if (messagecontent.CONTACT.Length < 1 || messagecontent.CONTACT.Length > 32) {
							Ranorex.Report.Failure("Field CONTACT expected to be length between or equal to 1 and 32, has length of {" + messagecontent.CONTACT.Length.ToString() + "}.");
						}
					}
				}

				if (content.ROUTE_COUNT != null) {
					messagecontent.ROUTE_COUNT = content.ROUTE_COUNT[0].Value;
					if (messagecontent.ROUTE_COUNT != null) {
						if (messagecontent.ROUTE_COUNT.Length < 1 || messagecontent.ROUTE_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field ROUTE_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.ROUTE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ROUTE_COUNT)) {
							Ranorex.Report.Failure("Field ROUTE_COUNT expected to be Numeric, has value of {" + messagecontent.ROUTE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.ROUTE_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 25) {
								Ranorex.Report.Failure("Field ROUTE_COUNT expected to have value between 0 and 25, but was found to have a value of " + messagecontent.ROUTE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ROUTE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.ROUTE_RECORD != null) {
					for (int i = 0; i < content.ROUTE_RECORD.Length; i++) {
						RUM_DR_BULIROUTE_RECORD_1 route_record = new RUM_DR_BULIROUTE_RECORD_1();

						if (content.ROUTE_RECORD[i].TRACK != null) {
							route_record.TRACK = content.ROUTE_RECORD[i].TRACK[0].Value;
							if (route_record.TRACK != null) {
								if (route_record.TRACK.Length < 1 || route_record.TRACK.Length > 32) {
									Ranorex.Report.Failure("Field TRACK expected to be length between or equal to 1 and 32, has length of {" + route_record.TRACK.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field TRACK is a Mandatory field but was found to be missing from the message");
						}

						if (content.ROUTE_RECORD[i].START_DISTRICT != null) {
							route_record.START_DISTRICT = content.ROUTE_RECORD[i].START_DISTRICT[0].Value;
							if (route_record.START_DISTRICT != null) {
								if (route_record.START_DISTRICT.Length < 1 || route_record.START_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field START_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + route_record.START_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field START_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.ROUTE_RECORD[i].START_MILEPOST != null) {
							route_record.START_MILEPOST = content.ROUTE_RECORD[i].START_MILEPOST[0].Value;
							if (route_record.START_MILEPOST != null) {
								if (route_record.START_MILEPOST.Length < 1 || route_record.START_MILEPOST.Length > 9) {
									Ranorex.Report.Failure("Field START_MILEPOST expected to be length between or equal to 1 and 9, has length of {" + route_record.START_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field START_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.ROUTE_RECORD[i].END_DISTRICT != null) {
							route_record.END_DISTRICT = content.ROUTE_RECORD[i].END_DISTRICT[0].Value;
							if (route_record.END_DISTRICT != null) {
								if (route_record.END_DISTRICT.Length < 1 || route_record.END_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field END_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + route_record.END_DISTRICT.Length.ToString() + "}.");
								}
							}
						}

						if (content.ROUTE_RECORD[i].END_MILEPOST != null) {
							route_record.END_MILEPOST = content.ROUTE_RECORD[i].END_MILEPOST[0].Value;
							if (route_record.END_MILEPOST != null) {
								if (route_record.END_MILEPOST.Length < 1 || route_record.END_MILEPOST.Length > 9) {
									Ranorex.Report.Failure("Field END_MILEPOST expected to be length between or equal to 1 and 9, has length of {" + route_record.END_MILEPOST.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addROUTE_RECORD(route_record);
					}
				}

				if (content.ROUTE_DISTRICT_COUNT != null) {
					messagecontent.ROUTE_DISTRICT_COUNT = content.ROUTE_DISTRICT_COUNT[0].Value;
					if (messagecontent.ROUTE_DISTRICT_COUNT != null) {
						if (messagecontent.ROUTE_DISTRICT_COUNT.Length < 1 || messagecontent.ROUTE_DISTRICT_COUNT.Length > 3) {
							Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT expected to be length between or equal to 1 and 3, has length of {" + messagecontent.ROUTE_DISTRICT_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ROUTE_DISTRICT_COUNT)) {
							Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT expected to be Numeric, has value of {" + messagecontent.ROUTE_DISTRICT_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.ROUTE_DISTRICT_RECORD != null) {
					for (int i = 0; i < content.ROUTE_DISTRICT_RECORD.Length; i++) {
						RUM_DR_BULIROUTE_DISTRICT_RECORD_1 route_district_record = new RUM_DR_BULIROUTE_DISTRICT_RECORD_1();

						if (content.ROUTE_DISTRICT_RECORD[i].ROUTE_DISTRICT_NAME != null) {
							route_district_record.ROUTE_DISTRICT_NAME = content.ROUTE_DISTRICT_RECORD[i].ROUTE_DISTRICT_NAME[0].Value;
							if (route_district_record.ROUTE_DISTRICT_NAME != null) {
								if (route_district_record.ROUTE_DISTRICT_NAME.Length < 1 || route_district_record.ROUTE_DISTRICT_NAME.Length > 25) {
									Ranorex.Report.Failure("Field ROUTE_DISTRICT_NAME expected to be length between or equal to 1 and 25, has length of {" + route_district_record.ROUTE_DISTRICT_NAME.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ROUTE_DISTRICT_NAME is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addROUTE_DISTRICT_RECORD(route_district_record);
					}
				}

				if (content.CROSSING_ID != null) {
					messagecontent.CROSSING_ID = content.CROSSING_ID[0].Value;
					if (messagecontent.CROSSING_ID != null) {
						if (messagecontent.CROSSING_ID.Length != 7) {
							Ranorex.Report.Failure("Field CROSSING_ID expected to be length of 7, has length of {" + messagecontent.CROSSING_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.CROSSING_DISTRICT_COUNT != null) {
					messagecontent.CROSSING_DISTRICT_COUNT = content.CROSSING_DISTRICT_COUNT[0].Value;
					if (messagecontent.CROSSING_DISTRICT_COUNT != null) {
						if (messagecontent.CROSSING_DISTRICT_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field CROSSING_DISTRICT_COUNT expected to be length of 1, has length of {" + messagecontent.CROSSING_DISTRICT_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.CROSSING_DISTRICT_COUNT)) {
							Ranorex.Report.Failure("Field CROSSING_DISTRICT_COUNT expected to be Numeric, has value of {" + messagecontent.CROSSING_DISTRICT_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.CROSSING_DISTRICT_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field CROSSING_DISTRICT_COUNT expected to have value between 1 and 9, but was found to have a value of " + messagecontent.CROSSING_DISTRICT_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field CROSSING_DISTRICT_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.CROSSING_RECORD != null) {
					for (int i = 0; i < content.CROSSING_RECORD.Length; i++) {
						RUM_DR_BULICROSSING_RECORD_1 crossing_record = new RUM_DR_BULICROSSING_RECORD_1();

						if (content.CROSSING_RECORD[i].CROSSING_DISTRICT_NAME != null) {
							crossing_record.CROSSING_DISTRICT_NAME = content.CROSSING_RECORD[i].CROSSING_DISTRICT_NAME[0].Value;
							if (crossing_record.CROSSING_DISTRICT_NAME != null) {
								if (crossing_record.CROSSING_DISTRICT_NAME.Length < 1 || crossing_record.CROSSING_DISTRICT_NAME.Length > 25) {
									Ranorex.Report.Failure("Field CROSSING_DISTRICT_NAME expected to be length between or equal to 1 and 25, has length of {" + crossing_record.CROSSING_DISTRICT_NAME.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field CROSSING_DISTRICT_NAME is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addCROSSING_RECORD(crossing_record);
					}
				}

				if (content.LINE_COUNT != null) {
					messagecontent.LINE_COUNT = content.LINE_COUNT[0].Value;
					if (messagecontent.LINE_COUNT != null) {
						if (messagecontent.LINE_COUNT.Length < 1 || messagecontent.LINE_COUNT.Length > 3) {
							Ranorex.Report.Failure("Field LINE_COUNT expected to be length between or equal to 1 and 3, has length of {" + messagecontent.LINE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.LINE_COUNT)) {
							Ranorex.Report.Failure("Field LINE_COUNT expected to be Numeric, has value of {" + messagecontent.LINE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.LINE_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 100) {
								Ranorex.Report.Failure("Field LINE_COUNT expected to have value between 1 and 100, but was found to have a value of " + messagecontent.LINE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field LINE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.TEXT_RECORD != null) {
					for (int i = 0; i < content.TEXT_RECORD.Length; i++) {
						RUM_DR_BULITEXT_RECORD_1 text_record = new RUM_DR_BULITEXT_RECORD_1();

						if (content.TEXT_RECORD[i].TEXT_SEQUENCE != null) {
							text_record.TEXT_SEQUENCE = content.TEXT_RECORD[i].TEXT_SEQUENCE[0].Value;
							if (text_record.TEXT_SEQUENCE != null) {
								if (text_record.TEXT_SEQUENCE.Length < 1 || text_record.TEXT_SEQUENCE.Length > 3) {
									Ranorex.Report.Failure("Field TEXT_SEQUENCE expected to be length between or equal to 1 and 3, has length of {" + text_record.TEXT_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(text_record.TEXT_SEQUENCE)) {
									Ranorex.Report.Failure("Field TEXT_SEQUENCE expected to be Numeric, has value of {" + text_record.TEXT_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(text_record.TEXT_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 100) {
										Ranorex.Report.Failure("Field TEXT_SEQUENCE expected to have value between 1 and 100, but was found to have a value of " + text_record.TEXT_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field TEXT_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.TEXT_RECORD[i].TEXT != null) {
							text_record.TEXT = content.TEXT_RECORD[i].TEXT[0].Value;
							if (text_record.TEXT != null) {
								if (text_record.TEXT.Length < 1 || text_record.TEXT.Length > 60) {
									Ranorex.Report.Failure("Field TEXT expected to be length between or equal to 1 and 60, has length of {" + text_record.TEXT.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addTEXT_RECORD(text_record);
					}
				}

				if (content.FROM_ZONE_COUNT != null) {
					messagecontent.FROM_ZONE_COUNT = content.FROM_ZONE_COUNT[0].Value;
					if (messagecontent.FROM_ZONE_COUNT != null) {
						if (messagecontent.FROM_ZONE_COUNT.Length < 1 || messagecontent.FROM_ZONE_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field FROM_ZONE_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.FROM_ZONE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.FROM_ZONE_COUNT)) {
							Ranorex.Report.Failure("Field FROM_ZONE_COUNT expected to be Numeric, has value of {" + messagecontent.FROM_ZONE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.FROM_ZONE_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field FROM_ZONE_COUNT expected to have value between 1 and 99, but was found to have a value of " + messagecontent.FROM_ZONE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field FROM_ZONE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.FROM_ZONE_RECORD != null) {
					for (int i = 0; i < content.FROM_ZONE_RECORD.Length; i++) {
						RUM_DR_BULIFROM_ZONE_RECORD_1 from_zone_record = new RUM_DR_BULIFROM_ZONE_RECORD_1();

						if (content.FROM_ZONE_RECORD[i].ZONE_1 != null) {
							from_zone_record.ZONE_1 = content.FROM_ZONE_RECORD[i].ZONE_1[0].Value;
							if (from_zone_record.ZONE_1 != null) {
								if (from_zone_record.ZONE_1.Length < 1 || from_zone_record.ZONE_1.Length > 60) {
									Ranorex.Report.Failure("Field ZONE_1 expected to be length between or equal to 1 and 60, has length of {" + from_zone_record.ZONE_1.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addFROM_ZONE_RECORD(from_zone_record);
					}
				} else {
					Ranorex.Report.Failure("Field FROM_ZONE_RECORD is a Mandatory field but was found to be missing from the message");
				}

				if (content.TO_ZONE_COUNT != null) {
					messagecontent.TO_ZONE_COUNT = content.TO_ZONE_COUNT[0].Value;
					if (messagecontent.TO_ZONE_COUNT != null) {
						if (messagecontent.TO_ZONE_COUNT.Length < 1 || messagecontent.TO_ZONE_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field TO_ZONE_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.TO_ZONE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TO_ZONE_COUNT)) {
							Ranorex.Report.Failure("Field TO_ZONE_COUNT expected to be Numeric, has value of {" + messagecontent.TO_ZONE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.TO_ZONE_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field TO_ZONE_COUNT expected to have value between 1 and 99, but was found to have a value of " + messagecontent.TO_ZONE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field TO_ZONE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.TO_ZONE_RECORD != null) {
					for (int i = 0; i < content.TO_ZONE_RECORD.Length; i++) {
						RUM_DR_BULITO_ZONE_RECORD_1 to_zone_record = new RUM_DR_BULITO_ZONE_RECORD_1();

						if (content.TO_ZONE_RECORD[i].ZONE_2 != null) {
							to_zone_record.ZONE_2 = content.TO_ZONE_RECORD[i].ZONE_2[0].Value;
							if (to_zone_record.ZONE_2 != null) {
								if (to_zone_record.ZONE_2.Length < 1 || to_zone_record.ZONE_2.Length > 60) {
									Ranorex.Report.Failure("Field ZONE_2 expected to be length between or equal to 1 and 60, has length of {" + to_zone_record.ZONE_2.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addTO_ZONE_RECORD(to_zone_record);
					}
				}

				dr_buli_1.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dr_buli_1;
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
	public partial class RUM_DR_BULIHEADER_1 {
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

	public partial class RUM_DR_BULICONTENT_1 {
		public string REQUEST_ID = "";
		public string ISSUE_DATE = "";
		public string ISSUE_TIME = "";
		public string ISSUE_TIME_ZONE = "";
		public string DISPATCHER = "";
		public string DISPATCHER_RESPONSE = "";
		public string BULLETIN_ITEM_NUMBER = "";
		public string BULLETIN_ITEM_TYPE = "";
		public string FROM_LIMIT = "";
		public string TO_LIMIT = "";
		public string EYE_CATCHER_TEXT = "";
		public string EFFECTIVE_DATE = "";
		public string EFFECTIVE_TIME = "";
		public string EXPIRATION_DATE = "";
		public string EXPIRATION_TIME = "";
		public string SPEED = "";
		public string HEO_SPEED_RESTRICTION = "";
		public string CONTACT = "";
		public string ROUTE_COUNT = "";
		public ArrayList ROUTE_RECORD = new ArrayList();
		public string ROUTE_DISTRICT_COUNT = "";
		public ArrayList ROUTE_DISTRICT_RECORD = new ArrayList();
		public string CROSSING_ID = "";
		public string CROSSING_DISTRICT_COUNT = "";
		public ArrayList CROSSING_RECORD = new ArrayList();
		public string LINE_COUNT = "";
		public ArrayList TEXT_RECORD = new ArrayList();
		public string FROM_ZONE_COUNT = "";
		public ArrayList FROM_ZONE_RECORD = new ArrayList();
		public string TO_ZONE_COUNT = "";
		public ArrayList TO_ZONE_RECORD = new ArrayList();

		public void addROUTE_RECORD(RUM_DR_BULIROUTE_RECORD_1 route_record) {
			this.ROUTE_RECORD.Add(route_record);
		}

		public void addROUTE_DISTRICT_RECORD(RUM_DR_BULIROUTE_DISTRICT_RECORD_1 route_district_record) {
			this.ROUTE_DISTRICT_RECORD.Add(route_district_record);
		}

		public void addCROSSING_RECORD(RUM_DR_BULICROSSING_RECORD_1 crossing_record) {
			this.CROSSING_RECORD.Add(crossing_record);
		}

		public void addTEXT_RECORD(RUM_DR_BULITEXT_RECORD_1 text_record) {
			this.TEXT_RECORD.Add(text_record);
		}

		public void addFROM_ZONE_RECORD(RUM_DR_BULIFROM_ZONE_RECORD_1 from_zone_record) {
			this.FROM_ZONE_RECORD.Add(from_zone_record);
		}

		public void addTO_ZONE_RECORD(RUM_DR_BULITO_ZONE_RECORD_1 to_zone_record) {
			this.TO_ZONE_RECORD.Add(to_zone_record);
		}
	}

	public partial class RUM_DR_BULIROUTE_RECORD_1 {
		public string TRACK = "";
		public string START_DISTRICT = "";
		public string START_MILEPOST = "";
		public string END_DISTRICT = "";
		public string END_MILEPOST = "";
	}

	public partial class RUM_DR_BULIROUTE_DISTRICT_RECORD_1 {
		public string ROUTE_DISTRICT_NAME = "";
	}

	public partial class RUM_DR_BULICROSSING_RECORD_1 {
		public string CROSSING_DISTRICT_NAME = "";
	}

	public partial class RUM_DR_BULITEXT_RECORD_1 {
		public string TEXT_SEQUENCE = "";
		public string TEXT = "";
	}

	public partial class RUM_DR_BULIFROM_ZONE_RECORD_1 {
		public string ZONE_1 = "";
	}

	public partial class RUM_DR_BULITO_ZONE_RECORD_1 {
		public string ZONE_2 = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DR_BULI_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DR_BULIHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DR_BULICONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIHEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIHEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_REQUEST_ID_1[] REQUEST_ID;

		[System.Xml.Serialization.XmlElementAttribute("ISSUE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ISSUE_DATE_1[] ISSUE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ISSUE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ISSUE_TIME_1[] ISSUE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("ISSUE_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ISSUE_TIME_ZONE_1[] ISSUE_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("DISPATCHER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_DISPATCHER_1[] DISPATCHER;

		[System.Xml.Serialization.XmlElementAttribute("DISPATCHER_RESPONSE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_DISPATCHER_RESPONSE_1[] DISPATCHER_RESPONSE;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_BULLETIN_ITEM_NUMBER_1[] BULLETIN_ITEM_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_BULLETIN_ITEM_TYPE_1[] BULLETIN_ITEM_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("FROM_LIMIT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_FROM_LIMIT_1[] FROM_LIMIT;

		[System.Xml.Serialization.XmlElementAttribute("TO_LIMIT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_TO_LIMIT_1[] TO_LIMIT;

		[System.Xml.Serialization.XmlElementAttribute("EYE_CATCHER_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_EYE_CATCHER_TEXT_1[] EYE_CATCHER_TEXT;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_EFFECTIVE_DATE_1[] EFFECTIVE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_EFFECTIVE_TIME_1[] EFFECTIVE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("EXPIRATION_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_EXPIRATION_DATE_1[] EXPIRATION_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EXPIRATION_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_EXPIRATION_TIME_1[] EXPIRATION_TIME;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_SPEED_1[] SPEED;

		[System.Xml.Serialization.XmlElementAttribute("HEO_SPEED_RESTRICTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_HEO_SPEED_RESTRICTION_1[] HEO_SPEED_RESTRICTION;

		[System.Xml.Serialization.XmlElementAttribute("CONTACT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_CONTACT_1[] CONTACT;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ROUTE_COUNT_1[] ROUTE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ROUTE_RECORD_1[] ROUTE_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ROUTE_DISTRICT_COUNT_1[] ROUTE_DISTRICT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_ROUTE_DISTRICT_RECORD_1[] ROUTE_DISTRICT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_CROSSING_ID_1[] CROSSING_ID;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_DISTRICT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_CROSSING_DISTRICT_COUNT_1[] CROSSING_DISTRICT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_CROSSING_RECORD_1[] CROSSING_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("LINE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_LINE_COUNT_1[] LINE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("TEXT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_TEXT_RECORD_1[] TEXT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("FROM_ZONE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_FROM_ZONE_COUNT_1[] FROM_ZONE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("FROM_ZONE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_FROM_ZONE_RECORD_1[] FROM_ZONE_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("TO_ZONE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_TO_ZONE_COUNT_1[] TO_ZONE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("TO_ZONE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICONTENT_TO_ZONE_RECORD_1[] TO_ZONE_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_REQUEST_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ISSUE_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ISSUE_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ISSUE_TIME_ZONE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_DISPATCHER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_DISPATCHER_RESPONSE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_BULLETIN_ITEM_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_BULLETIN_ITEM_TYPE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_FROM_LIMIT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_TO_LIMIT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_EYE_CATCHER_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_EFFECTIVE_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_EFFECTIVE_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_EXPIRATION_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_EXPIRATION_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_SPEED_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_HEO_SPEED_RESTRICTION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_CONTACT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ROUTE_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ROUTE_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_RECORD_TRACK_1[] TRACK;

		[System.Xml.Serialization.XmlElementAttribute("START_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_RECORD_START_DISTRICT_1[] START_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("START_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_RECORD_START_MILEPOST_1[] START_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("END_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_RECORD_END_DISTRICT_1[] END_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("END_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_RECORD_END_MILEPOST_1[] END_MILEPOST;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_RECORD_TRACK_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_RECORD_START_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_RECORD_START_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_RECORD_END_DISTRICT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_RECORD_END_MILEPOST_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ROUTE_DISTRICT_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_ROUTE_DISTRICT_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIROUTE_DISTRICT_RECORD_ROUTE_DISTRICT_NAME_1[] ROUTE_DISTRICT_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIROUTE_DISTRICT_RECORD_ROUTE_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_CROSSING_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_CROSSING_DISTRICT_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_CROSSING_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("CROSSING_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULICROSSING_RECORD_CROSSING_DISTRICT_NAME_1[] CROSSING_DISTRICT_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICROSSING_RECORD_CROSSING_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_LINE_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_TEXT_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("TEXT_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULITEXT_RECORD_TEXT_SEQUENCE_1[] TEXT_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULITEXT_RECORD_TEXT_1[] TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULITEXT_RECORD_TEXT_SEQUENCE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULITEXT_RECORD_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_FROM_ZONE_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_FROM_ZONE_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("ZONE_1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULIFROM_ZONE_RECORD_ZONE_1_1[] ZONE_1;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULIFROM_ZONE_RECORD_ZONE_1_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_TO_ZONE_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULICONTENT_TO_ZONE_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("ZONE_2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BULITO_ZONE_RECORD_ZONE_2_1[] ZONE_2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BULITO_ZONE_RECORD_ZONE_2_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}