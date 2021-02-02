using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.PTC
{
	public partial class PTC_DC_TCON_7 {
		public PTC_DC_TCONHEADER_7 HEADER;
		public PTC_DC_TCONCONTENT_7 CONTENT;

		public static PTC_DC_TCON_7 fromSerializableObject(DC_TCON_7 message) {
			PTC_DC_TCON_7 dc_tcon_7 = new PTC_DC_TCON_7();
			DC_TCONHEADER_7 header = null;
			DC_TCONCONTENT_7 content = null;
			header = (DC_TCONHEADER_7) message.Items[0];
			content = (DC_TCONCONTENT_7) message.Items[1];

			if (header != null) {
				PTC_DC_TCONHEADER_7 messageheader = new PTC_DC_TCONHEADER_7();

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

				if (header.MESSAGE_REVISION != null) {
					messageheader.MESSAGE_REVISION = header.MESSAGE_REVISION[0].Value;
					if (messageheader.MESSAGE_REVISION != null) {
						if (messageheader.MESSAGE_REVISION.Length < 1 || messageheader.MESSAGE_REVISION.Length > 3) {
							Ranorex.Report.Failure("Field MESSAGE_REVISION expected to be length between or equal to 1 and 3, has length of {" + messageheader.MESSAGE_REVISION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.MESSAGE_REVISION)) {
							Ranorex.Report.Failure("Field MESSAGE_REVISION expected to be Numeric, has value of {" + messageheader.MESSAGE_REVISION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messageheader.MESSAGE_REVISION);
							if (intConvertedValue < 0 || intConvertedValue > 999) {
								Ranorex.Report.Failure("Field MESSAGE_REVISION expected to have value between 1 and 999, but was found to have a value of " + messageheader.MESSAGE_REVISION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field MESSAGE_REVISION is a Mandatory field but was found to be missing from the message");
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
						if (messageheader.DISTRICT_NAME.Length < 1 || messageheader.DISTRICT_NAME.Length > 25) {
							Ranorex.Report.Failure("Field DISTRICT_NAME expected to be length between or equal to 1 and 25, has length of {" + messageheader.DISTRICT_NAME.Length.ToString() + "}.");
						}
					}
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
						if (messageheader.USER_ID.Length < 1 || messageheader.USER_ID.Length > 7) {
							Ranorex.Report.Failure("Field USER_ID expected to be length between or equal to 1 and 7, has length of {" + messageheader.USER_ID.Length.ToString() + "}.");
						}
					}
				}

				if (header.TRACK_FILE_VERSION != null) {
					messageheader.TRACK_FILE_VERSION = header.TRACK_FILE_VERSION[0].Value;
					if (messageheader.TRACK_FILE_VERSION != null) {
						if (messageheader.TRACK_FILE_VERSION.Length < 1 || messageheader.TRACK_FILE_VERSION.Length > 10) {
							Ranorex.Report.Failure("Field TRACK_FILE_VERSION expected to be length between or equal to 1 and 10, has length of {" + messageheader.TRACK_FILE_VERSION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.TRACK_FILE_VERSION)) {
							Ranorex.Report.Failure("Field TRACK_FILE_VERSION expected to be Numeric, has value of {" + messageheader.TRACK_FILE_VERSION + "}.");
						} else {
							long intConvertedValue = Convert.ToInt64(messageheader.TRACK_FILE_VERSION);
							if (intConvertedValue < 1 || intConvertedValue > 4294967295) {
								Ranorex.Report.Failure("Field TRACK_FILE_VERSION expected to have value between 1 and 4294967295, but was found to have a value of " + messageheader.TRACK_FILE_VERSION + ".");
							}
						}
					}
				}

				if (header.HTRN_SCAC != null) {
					messageheader.HTRN_SCAC = header.HTRN_SCAC[0].Value;
					if (messageheader.HTRN_SCAC != null) {
						if (messageheader.HTRN_SCAC.Length < 1 || messageheader.HTRN_SCAC.Length > 4) {
							Ranorex.Report.Failure("Field HTRN_SCAC expected to be length between or equal to 1 and 4, has length of {" + messageheader.HTRN_SCAC.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.HTRN_SCAC)) {
							Ranorex.Report.Failure("Field HTRN_SCAC expected to be Alphabetic, has value of {" + messageheader.HTRN_SCAC + "}.");
						}
					}
				}

				if (header.HTRN_SYMBOL != null) {
					messageheader.HTRN_SYMBOL = header.HTRN_SYMBOL[0].Value;
					if (messageheader.HTRN_SYMBOL != null) {
						if (messageheader.HTRN_SYMBOL.Length < 1 || messageheader.HTRN_SYMBOL.Length > 10) {
							Ranorex.Report.Failure("Field HTRN_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + messageheader.HTRN_SYMBOL.Length.ToString() + "}.");
						}
					}
				}

				if (header.HTRN_SECTION != null) {
					messageheader.HTRN_SECTION = header.HTRN_SECTION[0].Value;
					if (messageheader.HTRN_SECTION != null) {
						if (messageheader.HTRN_SECTION.Length != 1) {
							Ranorex.Report.Failure("Field HTRN_SECTION expected to be length of 1, has length of {" + messageheader.HTRN_SECTION.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.HTRN_SECTION)) {
							Ranorex.Report.Failure("Field HTRN_SECTION expected to be Numeric, has value of {" + messageheader.HTRN_SECTION + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messageheader.HTRN_SECTION);
							if (intConvertedValue < 1 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field HTRN_SECTION expected to have value between 1 and 9, but was found to have a value of " + messageheader.HTRN_SECTION + ".");
							}
						}
					}
				}

				if (header.HTRN_ORIGIN_DATE != null) {
					messageheader.HTRN_ORIGIN_DATE = header.HTRN_ORIGIN_DATE[0].Value;
					if (messageheader.HTRN_ORIGIN_DATE != null) {
						if (messageheader.HTRN_ORIGIN_DATE.Length != 8) {
							Ranorex.Report.Failure("Field HTRN_ORIGIN_DATE expected to be length of 8, has length of {" + messageheader.HTRN_ORIGIN_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.HTRN_ORIGIN_DATE)) {
							Ranorex.Report.Failure("Field HTRN_ORIGIN_DATE expected to be Numeric, has value of {" + messageheader.HTRN_ORIGIN_DATE + "}.");
						}
					}
				}

				if (header.HENG_ENGINE_INITIAL != null) {
					messageheader.HENG_ENGINE_INITIAL = header.HENG_ENGINE_INITIAL[0].Value;
					if (messageheader.HENG_ENGINE_INITIAL != null) {
						if (messageheader.HENG_ENGINE_INITIAL.Length < 1 || messageheader.HENG_ENGINE_INITIAL.Length > 4) {
							Ranorex.Report.Failure("Field HENG_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + messageheader.HENG_ENGINE_INITIAL.Length.ToString() + "}.");
						}
						if (ContainsDigits(messageheader.HENG_ENGINE_INITIAL)) {
							Ranorex.Report.Failure("Field HENG_ENGINE_INITIAL expected to be Alphabetic, has value of {" + messageheader.HENG_ENGINE_INITIAL + "}.");
						}
					}
				}

				if (header.HENG_ENGINE_NUMBER != null) {
					messageheader.HENG_ENGINE_NUMBER = header.HENG_ENGINE_NUMBER[0].Value;
					if (messageheader.HENG_ENGINE_NUMBER != null) {
						if (messageheader.HENG_ENGINE_NUMBER.Length < 1 || messageheader.HENG_ENGINE_NUMBER.Length > 10) {
							Ranorex.Report.Failure("Field HENG_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + messageheader.HENG_ENGINE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.HENG_ENGINE_NUMBER)) {
							Ranorex.Report.Failure("Field HENG_ENGINE_NUMBER expected to be Numeric, has value of {" + messageheader.HENG_ENGINE_NUMBER + "}.");
						}
					}
				}

				if (header.UID1_TYPE != null) {
					messageheader.UID1_TYPE = header.UID1_TYPE[0].Value;
					if (messageheader.UID1_TYPE != null) {
						if (messageheader.UID1_TYPE.Length < 1 || messageheader.UID1_TYPE.Length > 7) {
							Ranorex.Report.Failure("Field UID1_TYPE expected to be length between or equal to 1 and 7, has length of {" + messageheader.UID1_TYPE.Length.ToString() + "}.");
						}
						if (messageheader.UID1_TYPE != "SYNC") {
							Ranorex.Report.Failure("Field UID1_TYPE expected to be one of the following values {SYNC}, but was found to be {" + messageheader.UID1_TYPE + "}.");
						}
					}
				}

				if (header.UID1 != null) {
					messageheader.UID1 = header.UID1[0].Value;
					if (messageheader.UID1 != null) {
						if (messageheader.UID1.Length < 1 || messageheader.UID1.Length > 10) {
							Ranorex.Report.Failure("Field UID1 expected to be length between or equal to 1 and 10, has length of {" + messageheader.UID1.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.UID1)) {
							Ranorex.Report.Failure("Field UID1 expected to be Numeric, has value of {" + messageheader.UID1 + "}.");
						}
					}
				}

				if (header.UID2_TYPE != null) {
					messageheader.UID2_TYPE = header.UID2_TYPE[0].Value;
					if (messageheader.UID2_TYPE != null) {
						if (messageheader.UID2_TYPE.Length < 1 || messageheader.UID2_TYPE.Length > 7) {
							Ranorex.Report.Failure("Field UID2_TYPE expected to be length between or equal to 1 and 7, has length of {" + messageheader.UID2_TYPE.Length.ToString() + "}.");
						}
						if (messageheader.UID2_TYPE != "SYNCST" && messageheader.UID2_TYPE != "SYNCBI" && messageheader.UID2_TYPE != "SYNCTA" && messageheader.UID2_TYPE != "SYNCEND") {
							Ranorex.Report.Failure("Field UID2_TYPE expected to be one of the following values {SYNCST, SYNCBI, SYNCTA, SYNCEND}, but was found to be {" + messageheader.UID2_TYPE + "}.");
						}
					}
				}

				if (header.UID2 != null) {
					messageheader.UID2 = header.UID2[0].Value;
					if (messageheader.UID2 != null) {
						if (messageheader.UID2.Length < 1 || messageheader.UID2.Length > 10) {
							Ranorex.Report.Failure("Field UID2 expected to be length between or equal to 1 and 10, has length of {" + messageheader.UID2.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messageheader.UID2)) {
							Ranorex.Report.Failure("Field UID2 expected to be Numeric, has value of {" + messageheader.UID2 + "}.");
						}
					}
				}

				dc_tcon_7.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				PTC_DC_TCONCONTENT_7 messagecontent = new PTC_DC_TCONCONTENT_7();

				if (content.TRIGGER_TYPE != null) {
					messagecontent.TRIGGER_TYPE = content.TRIGGER_TYPE[0].Value;
					if (messagecontent.TRIGGER_TYPE != null) {
						if (messagecontent.TRIGGER_TYPE.Length < 4 || messagecontent.TRIGGER_TYPE.Length > 5) {
							Ranorex.Report.Failure("Field TRIGGER_TYPE expected to be length between or equal to 4 and 5, has length of {" + messagecontent.TRIGGER_TYPE.Length.ToString() + "}.");
						}
						if (messagecontent.TRIGGER_TYPE != "UPDT" && messagecontent.TRIGGER_TYPE != "02030" && messagecontent.TRIGGER_TYPE != "CIBOS") {
							Ranorex.Report.Failure("Field TRIGGER_TYPE expected to be one of the following values {UPDT, 02030, CIBOS}, but was found to be {" + messagecontent.TRIGGER_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field TRIGGER_TYPE is a Mandatory field but was found to be missing from the message");
				}

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

				if (content.SYMBOL != null) {
					messagecontent.SYMBOL = content.SYMBOL[0].Value;
					if (messagecontent.SYMBOL != null) {
						if (messagecontent.SYMBOL.Length < 1 || messagecontent.SYMBOL.Length > 10) {
							Ranorex.Report.Failure("Field SYMBOL expected to be length between or equal to 1 and 10, has length of {" + messagecontent.SYMBOL.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SYMBOL is a Mandatory field but was found to be missing from the message");
				}

				if (content.SECTION != null) {
					messagecontent.SECTION = content.SECTION[0].Value;
					if (messagecontent.SECTION != null) {
						if (messagecontent.SECTION.Length != 1) {
							Ranorex.Report.Failure("Field SECTION expected to be length of 1, has length of {" + messagecontent.SECTION.Length.ToString() + "}.");
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

				if (content.SPEED_CLASS != null) {
					messagecontent.SPEED_CLASS = content.SPEED_CLASS[0].Value;
					if (messagecontent.SPEED_CLASS != null) {
						if (messagecontent.SPEED_CLASS.Length < 1 || messagecontent.SPEED_CLASS.Length > 15) {
							Ranorex.Report.Failure("Field SPEED_CLASS expected to be length between or equal to 1 and 15, has length of {" + messagecontent.SPEED_CLASS.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.SPEED_CLASS)) {
							Ranorex.Report.Failure("Field SPEED_CLASS expected to be Alphabetic, has value of {" + messagecontent.SPEED_CLASS + "}.");
						}
						if (messagecontent.SPEED_CLASS != "Freight" && messagecontent.SPEED_CLASS != "Intermodal" && messagecontent.SPEED_CLASS != "Passenger") {
							Ranorex.Report.Failure("Field SPEED_CLASS expected to be one of the following values {Freight, Intermodal, Passenger}, but was found to be {" + messagecontent.SPEED_CLASS + "}.");
						}
					}
				}

				if (content.LOADS != null) {
					messagecontent.LOADS = content.LOADS[0].Value;
					if (messagecontent.LOADS != null) {
						if (messagecontent.LOADS.Length < 1 || messagecontent.LOADS.Length > 3) {
							Ranorex.Report.Failure("Field LOADS expected to be length between or equal to 1 and 3, has length of {" + messagecontent.LOADS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.LOADS)) {
							Ranorex.Report.Failure("Field LOADS expected to be Numeric, has value of {" + messagecontent.LOADS + "}.");
						}
					}
				}

				if (content.EMPTIES != null) {
					messagecontent.EMPTIES = content.EMPTIES[0].Value;
					if (messagecontent.EMPTIES != null) {
						if (messagecontent.EMPTIES.Length < 1 || messagecontent.EMPTIES.Length > 3) {
							Ranorex.Report.Failure("Field EMPTIES expected to be length between or equal to 1 and 3, has length of {" + messagecontent.EMPTIES.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EMPTIES)) {
							Ranorex.Report.Failure("Field EMPTIES expected to be Numeric, has value of {" + messagecontent.EMPTIES + "}.");
						}
					}
				}

				if (content.TONNAGE != null) {
					messagecontent.TONNAGE = content.TONNAGE[0].Value;
					if (messagecontent.TONNAGE != null) {
						if (messagecontent.TONNAGE.Length < 1 || messagecontent.TONNAGE.Length > 5) {
							Ranorex.Report.Failure("Field TONNAGE expected to be length between or equal to 1 and 5, has length of {" + messagecontent.TONNAGE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TONNAGE)) {
							Ranorex.Report.Failure("Field TONNAGE expected to be Numeric, has value of {" + messagecontent.TONNAGE + "}.");
						}
					}
				}

				if (content.LENGTH != null) {
					messagecontent.LENGTH = content.LENGTH[0].Value;
					if (messagecontent.LENGTH != null) {
						if (messagecontent.LENGTH.Length < 1 || messagecontent.LENGTH.Length > 5) {
							Ranorex.Report.Failure("Field LENGTH expected to be length between or equal to 1 and 5, has length of {" + messagecontent.LENGTH.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.LENGTH)) {
							Ranorex.Report.Failure("Field LENGTH expected to be Numeric, has value of {" + messagecontent.LENGTH + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.LENGTH);
							if (intConvertedValue < 1 || intConvertedValue > 21000) {
								Ranorex.Report.Failure("Field LENGTH expected to have value between 1 and 21000, but was found to have a value of " + messagecontent.LENGTH + ".");
							}
						}
					}
				}

				if (content.AXLES != null) {
					messagecontent.AXLES = content.AXLES[0].Value;
					if (messagecontent.AXLES != null) {
						if (messagecontent.AXLES.Length < 1 || messagecontent.AXLES.Length > 4) {
							Ranorex.Report.Failure("Field AXLES expected to be length between or equal to 1 and 4, has length of {" + messagecontent.AXLES.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.AXLES)) {
							Ranorex.Report.Failure("Field AXLES expected to be Numeric, has value of {" + messagecontent.AXLES + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.AXLES);
							if (intConvertedValue < 0 || intConvertedValue > 3996) {
								Ranorex.Report.Failure("Field AXLES expected to have value between 0 and 3996, but was found to have a value of " + messagecontent.AXLES + ".");
							}
						}
					}
				}

				if (content.OPERATIVE_BRAKES != null) {
					messagecontent.OPERATIVE_BRAKES = content.OPERATIVE_BRAKES[0].Value;
					if (messagecontent.OPERATIVE_BRAKES != null) {
						if (messagecontent.OPERATIVE_BRAKES.Length < 1 || messagecontent.OPERATIVE_BRAKES.Length > 3) {
							Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to be length between or equal to 1 and 3, has length of {" + messagecontent.OPERATIVE_BRAKES.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.OPERATIVE_BRAKES)) {
							Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to be Numeric, has value of {" + messagecontent.OPERATIVE_BRAKES + "}.");
						}
					}
				}

				if (content.TOTAL_BRAKING_FORCE != null) {
					messagecontent.TOTAL_BRAKING_FORCE = content.TOTAL_BRAKING_FORCE[0].Value;
					if (messagecontent.TOTAL_BRAKING_FORCE != null) {
						if (messagecontent.TOTAL_BRAKING_FORCE.Length < 1 || messagecontent.TOTAL_BRAKING_FORCE.Length > 8) {
							Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to be length between or equal to 1 and 8, has length of {" + messagecontent.TOTAL_BRAKING_FORCE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TOTAL_BRAKING_FORCE)) {
							Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to be Numeric, has value of {" + messagecontent.TOTAL_BRAKING_FORCE + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.TOTAL_BRAKING_FORCE);
							if (intConvertedValue < 0 || intConvertedValue > 30000000) {
								Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to have value between 0 and 30000000, but was found to have a value of " + messagecontent.TOTAL_BRAKING_FORCE + ".");
							}
						}
					}
				}

				if (content.SPEED_CONSTRAINT != null) {
					messagecontent.SPEED_CONSTRAINT = content.SPEED_CONSTRAINT[0].Value;
					if (messagecontent.SPEED_CONSTRAINT != null) {
						if (messagecontent.SPEED_CONSTRAINT.Length != 1) {
							Ranorex.Report.Failure("Field SPEED_CONSTRAINT expected to be length of 1, has length of {" + messagecontent.SPEED_CONSTRAINT.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.SPEED_CONSTRAINT)) {
							Ranorex.Report.Failure("Field SPEED_CONSTRAINT expected to be Alphabetic, has value of {" + messagecontent.SPEED_CONSTRAINT + "}.");
						}
						if (messagecontent.SPEED_CONSTRAINT != "Y" && messagecontent.SPEED_CONSTRAINT != "N") {
							Ranorex.Report.Failure("Field SPEED_CONSTRAINT expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.SPEED_CONSTRAINT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SPEED_CONSTRAINT is a Mandatory field but was found to be missing from the message");
				}

				if (content.SPEED != null) {
					messagecontent.SPEED = content.SPEED[0].Value;
					if (messagecontent.SPEED != null) {
						if (messagecontent.SPEED.Length < 1 || messagecontent.SPEED.Length > 3) {
							Ranorex.Report.Failure("Field SPEED expected to be length between or equal to 1 and 3, has length of {" + messagecontent.SPEED.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SPEED)) {
							Ranorex.Report.Failure("Field SPEED expected to be Numeric, has value of {" + messagecontent.SPEED + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.SPEED);
							if (intConvertedValue < 1 || intConvertedValue > 125) {
								Ranorex.Report.Failure("Field SPEED expected to have value between 1 and 125, but was found to have a value of " + messagecontent.SPEED + ".");
							}
						}
					}
				}

				if (content.RESTRICTION_COUNT != null) {
					messagecontent.RESTRICTION_COUNT = content.RESTRICTION_COUNT[0].Value;
					if (messagecontent.RESTRICTION_COUNT != null) {
						if (messagecontent.RESTRICTION_COUNT.Length < 1 || messagecontent.RESTRICTION_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field RESTRICTION_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.RESTRICTION_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.RESTRICTION_COUNT)) {
							Ranorex.Report.Failure("Field RESTRICTION_COUNT expected to be Numeric, has value of {" + messagecontent.RESTRICTION_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.RESTRICTION_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 32) {
								Ranorex.Report.Failure("Field RESTRICTION_COUNT expected to have value between 0 and 32, but was found to have a value of " + messagecontent.RESTRICTION_COUNT + ".");
							}
						}
					}
				}
				if (content.RESTRICTION_RECORD != null) {
					for (int i = 0; i < content.RESTRICTION_RECORD.Length; i++) {
						PTC_DC_TCONRESTRICTION_RECORD_7 restriction_record = new PTC_DC_TCONRESTRICTION_RECORD_7();

						if (content.RESTRICTION_RECORD[i].RESTRICTION_TYPE != null) {
							restriction_record.RESTRICTION_TYPE = content.RESTRICTION_RECORD[i].RESTRICTION_TYPE[0].Value;
							if (restriction_record.RESTRICTION_TYPE != null) {
								if (restriction_record.RESTRICTION_TYPE.Length < 1 || restriction_record.RESTRICTION_TYPE.Length > 2) {
									Ranorex.Report.Failure("Field RESTRICTION_TYPE expected to be length between or equal to 1 and 2, has length of {" + restriction_record.RESTRICTION_TYPE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(restriction_record.RESTRICTION_TYPE)) {
									Ranorex.Report.Failure("Field RESTRICTION_TYPE expected to be Numeric, has value of {" + restriction_record.RESTRICTION_TYPE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RESTRICTION_TYPE is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addRESTRICTION_RECORD(restriction_record);
					}
				}

				if (content.PTC_LOCO_ORIENTATION != null) {
					messagecontent.PTC_LOCO_ORIENTATION = content.PTC_LOCO_ORIENTATION[0].Value;
					if (messagecontent.PTC_LOCO_ORIENTATION != null) {
						if (messagecontent.PTC_LOCO_ORIENTATION.Length < 4 || messagecontent.PTC_LOCO_ORIENTATION.Length > 5) {
							Ranorex.Report.Failure("Field PTC_LOCO_ORIENTATION expected to be length between or equal to 4 and 5, has length of {" + messagecontent.PTC_LOCO_ORIENTATION.Length.ToString() + "}.");
						}
						if (messagecontent.PTC_LOCO_ORIENTATION != "FRONT" && messagecontent.PTC_LOCO_ORIENTATION != "BACK") {
							Ranorex.Report.Failure("Field PTC_LOCO_ORIENTATION expected to be one of the following values {FRONT, BACK}, but was found to be {" + messagecontent.PTC_LOCO_ORIENTATION + "}.");
						}
					}
				}

				if (content.PTC_ENGINE_INITIAL != null) {
					messagecontent.PTC_ENGINE_INITIAL = content.PTC_ENGINE_INITIAL[0].Value;
					if (messagecontent.PTC_ENGINE_INITIAL != null) {
						if (messagecontent.PTC_ENGINE_INITIAL.Length < 1 || messagecontent.PTC_ENGINE_INITIAL.Length > 4) {
							Ranorex.Report.Failure("Field PTC_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + messagecontent.PTC_ENGINE_INITIAL.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.PTC_ENGINE_INITIAL)) {
							Ranorex.Report.Failure("Field PTC_ENGINE_INITIAL expected to be Alphabetic, has value of {" + messagecontent.PTC_ENGINE_INITIAL + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field PTC_ENGINE_INITIAL is a Mandatory field but was found to be missing from the message");
				}

				if (content.PTC_ENGINE_NUMBER != null) {
					messagecontent.PTC_ENGINE_NUMBER = content.PTC_ENGINE_NUMBER[0].Value;
					if (messagecontent.PTC_ENGINE_NUMBER != null) {
						if (messagecontent.PTC_ENGINE_NUMBER.Length < 1 || messagecontent.PTC_ENGINE_NUMBER.Length > 10) {
							Ranorex.Report.Failure("Field PTC_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + messagecontent.PTC_ENGINE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.PTC_ENGINE_NUMBER)) {
							Ranorex.Report.Failure("Field PTC_ENGINE_NUMBER expected to be Numeric, has value of {" + messagecontent.PTC_ENGINE_NUMBER + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field PTC_ENGINE_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.ENGINE_COUNT != null) {
					messagecontent.ENGINE_COUNT = content.ENGINE_COUNT[0].Value;
					if (messagecontent.ENGINE_COUNT != null) {
						if (messagecontent.ENGINE_COUNT.Length < 1 || messagecontent.ENGINE_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field ENGINE_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.ENGINE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ENGINE_COUNT)) {
							Ranorex.Report.Failure("Field ENGINE_COUNT expected to be Numeric, has value of {" + messagecontent.ENGINE_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field ENGINE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.ENGINE_RECORD != null) {
					for (int i = 0; i < content.ENGINE_RECORD.Length; i++) {
						PTC_DC_TCONENGINE_RECORD_7 engine_record = new PTC_DC_TCONENGINE_RECORD_7();

						if (content.ENGINE_RECORD[i].POSITION_IN_CONSIST != null) {
							engine_record.POSITION_IN_CONSIST = content.ENGINE_RECORD[i].POSITION_IN_CONSIST[0].Value;
							if (engine_record.POSITION_IN_CONSIST != null) {
								if (engine_record.POSITION_IN_CONSIST.Length < 1 || engine_record.POSITION_IN_CONSIST.Length > 3) {
									Ranorex.Report.Failure("Field POSITION_IN_CONSIST expected to be length between or equal to 1 and 3, has length of {" + engine_record.POSITION_IN_CONSIST.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.POSITION_IN_CONSIST)) {
									Ranorex.Report.Failure("Field POSITION_IN_CONSIST expected to be Numeric, has value of {" + engine_record.POSITION_IN_CONSIST + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.POSITION_IN_CONSIST);
									if (intConvertedValue < 1 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field POSITION_IN_CONSIST expected to have value between 1 and 999, but was found to have a value of " + engine_record.POSITION_IN_CONSIST + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field POSITION_IN_CONSIST is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_INITIAL != null) {
							engine_record.ENGINE_INITIAL = content.ENGINE_RECORD[i].ENGINE_INITIAL[0].Value;
							if (engine_record.ENGINE_INITIAL != null) {
								if (engine_record.ENGINE_INITIAL.Length < 1 || engine_record.ENGINE_INITIAL.Length > 4) {
									Ranorex.Report.Failure("Field ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + engine_record.ENGINE_INITIAL.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.ENGINE_INITIAL)) {
									Ranorex.Report.Failure("Field ENGINE_INITIAL expected to be Alphabetic, has value of {" + engine_record.ENGINE_INITIAL + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_INITIAL is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_NUMBER != null) {
							engine_record.ENGINE_NUMBER = content.ENGINE_RECORD[i].ENGINE_NUMBER[0].Value;
							if (engine_record.ENGINE_NUMBER != null) {
								if (engine_record.ENGINE_NUMBER.Length < 1 || engine_record.ENGINE_NUMBER.Length > 10) {
									Ranorex.Report.Failure("Field ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + engine_record.ENGINE_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.ENGINE_NUMBER)) {
									Ranorex.Report.Failure("Field ENGINE_NUMBER expected to be Numeric, has value of {" + engine_record.ENGINE_NUMBER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_STATUS != null) {
							engine_record.ENGINE_STATUS = content.ENGINE_RECORD[i].ENGINE_STATUS[0].Value;
							if (engine_record.ENGINE_STATUS != null) {
								if (engine_record.ENGINE_STATUS.Length != 1) {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be length of 1, has length of {" + engine_record.ENGINE_STATUS.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.ENGINE_STATUS)) {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be Alphabetic, has value of {" + engine_record.ENGINE_STATUS + "}.");
								}
								if (engine_record.ENGINE_STATUS != "W" && engine_record.ENGINE_STATUS != "T" && engine_record.ENGINE_STATUS != "D" && engine_record.ENGINE_STATUS != "R") {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be one of the following values {W, T, D, R}, but was found to be {" + engine_record.ENGINE_STATUS + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_STATUS is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].WEIGHT != null) {
							engine_record.WEIGHT = content.ENGINE_RECORD[i].WEIGHT[0].Value;
							if (engine_record.WEIGHT != null) {
								if (engine_record.WEIGHT.Length < 1 || engine_record.WEIGHT.Length > 3) {
									Ranorex.Report.Failure("Field WEIGHT expected to be length between or equal to 1 and 3, has length of {" + engine_record.WEIGHT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.WEIGHT)) {
									Ranorex.Report.Failure("Field WEIGHT expected to be Numeric, has value of {" + engine_record.WEIGHT + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.WEIGHT);
									if (intConvertedValue < 1 || intConvertedValue > 400) {
										Ranorex.Report.Failure("Field WEIGHT expected to have value between 1 and 400, but was found to have a value of " + engine_record.WEIGHT + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field WEIGHT is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_LENGTH != null) {
							engine_record.ENGINE_LENGTH = content.ENGINE_RECORD[i].ENGINE_LENGTH[0].Value;
							if (engine_record.ENGINE_LENGTH != null) {
								if (engine_record.ENGINE_LENGTH.Length < 1 || engine_record.ENGINE_LENGTH.Length > 3) {
									Ranorex.Report.Failure("Field ENGINE_LENGTH expected to be length between or equal to 1 and 3, has length of {" + engine_record.ENGINE_LENGTH.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.ENGINE_LENGTH)) {
									Ranorex.Report.Failure("Field ENGINE_LENGTH expected to be Numeric, has value of {" + engine_record.ENGINE_LENGTH + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.ENGINE_LENGTH);
									if (intConvertedValue < 1 || intConvertedValue > 255) {
										Ranorex.Report.Failure("Field ENGINE_LENGTH expected to have value between 1 and 255, but was found to have a value of " + engine_record.ENGINE_LENGTH + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_LENGTH is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].HORSEPOWER != null) {
							engine_record.HORSEPOWER = content.ENGINE_RECORD[i].HORSEPOWER[0].Value;
							if (engine_record.HORSEPOWER != null) {
								if (engine_record.HORSEPOWER.Length < 1 || engine_record.HORSEPOWER.Length > 5) {
									Ranorex.Report.Failure("Field HORSEPOWER expected to be length between or equal to 1 and 5, has length of {" + engine_record.HORSEPOWER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.HORSEPOWER)) {
									Ranorex.Report.Failure("Field HORSEPOWER expected to be Numeric, has value of {" + engine_record.HORSEPOWER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field HORSEPOWER is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].DB_STATUS != null) {
							engine_record.DB_STATUS = content.ENGINE_RECORD[i].DB_STATUS[0].Value;
							if (engine_record.DB_STATUS != null) {
								if (engine_record.DB_STATUS.Length < 5 || engine_record.DB_STATUS.Length > 6) {
									Ranorex.Report.Failure("Field DB_STATUS expected to be length between or equal to 5 and 6, has length of {" + engine_record.DB_STATUS.Length.ToString() + "}.");
								}
								if (engine_record.DB_STATUS != "CUTIN" && engine_record.DB_STATUS != "CUTOUT") {
									Ranorex.Report.Failure("Field DB_STATUS expected to be one of the following values {CUTIN, CUTOUT}, but was found to be {" + engine_record.DB_STATUS + "}.");
								}
							}
						}

						messagecontent.addENGINE_RECORD(engine_record);
					}
				}

				dc_tcon_7.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dc_tcon_7;
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
	public partial class PTC_DC_TCONHEADER_7 {
		public string EVENT_DATE = "";
		public string EVENT_TIME = "";
		public string MESSAGE_ID = "";
		public string SEQUENCE_NUMBER = "";
		public string MESSAGE_VERSION = "";
		public string MESSAGE_REVISION = "";
		public string SOURCE_SYS = "";
		public string DESTINATION_SYS = "";
		public string DISTRICT_NAME = "";
		public string DISTRICT_SCAC = "";
		public string USER_ID = "";
		public string TRACK_FILE_VERSION = "";
		public string HTRN_SCAC = "";
		public string HTRN_SYMBOL = "";
		public string HTRN_SECTION = "";
		public string HTRN_ORIGIN_DATE = "";
		public string HENG_ENGINE_INITIAL = "";
		public string HENG_ENGINE_NUMBER = "";
		public string UID1_TYPE = "";
		public string UID1 = "";
		public string UID2_TYPE = "";
		public string UID2 = "";
	}

	public partial class PTC_DC_TCONCONTENT_7 {
		public string TRIGGER_TYPE = "";
		public string SCAC = "";
		public string SYMBOL = "";
		public string SECTION = "";
		public string ORIGIN_DATE = "";
		public string SPEED_CLASS = "";
		public string LOADS = "";
		public string EMPTIES = "";
		public string TONNAGE = "";
		public string LENGTH = "";
		public string AXLES = "";
		public string OPERATIVE_BRAKES = "";
		public string TOTAL_BRAKING_FORCE = "";
		public string SPEED_CONSTRAINT = "";
		public string SPEED = "";
		public string RESTRICTION_COUNT = "";
		public ArrayList RESTRICTION_RECORD = new ArrayList();
		public string PTC_LOCO_ORIENTATION = "";
		public string PTC_ENGINE_INITIAL = "";
		public string PTC_ENGINE_NUMBER = "";
		public string ENGINE_COUNT = "";
		public ArrayList ENGINE_RECORD = new ArrayList();

		public void addRESTRICTION_RECORD(PTC_DC_TCONRESTRICTION_RECORD_7 restriction_record) {
			this.RESTRICTION_RECORD.Add(restriction_record);
		}

		public void addENGINE_RECORD(PTC_DC_TCONENGINE_RECORD_7 engine_record) {
			this.ENGINE_RECORD.Add(engine_record);
		}
	}

	public partial class PTC_DC_TCONRESTRICTION_RECORD_7 {
		public string RESTRICTION_TYPE = "";
	}

	public partial class PTC_DC_TCONENGINE_RECORD_7 {
		public string POSITION_IN_CONSIST = "";
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string ENGINE_STATUS = "";
		public string WEIGHT = "";
		public string ENGINE_LENGTH = "";
		public string HORSEPOWER = "";
		public string DB_STATUS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DC_TCON_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DC_TCONHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DC_TCONCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("TRIGGER_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_TRIGGER_TYPE_7[] TRIGGER_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SCAC_7[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SYMBOL_7[] SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SECTION_7[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_ORIGIN_DATE_7[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_CLASS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SPEED_CLASS_7[] SPEED_CLASS;

		[System.Xml.Serialization.XmlElementAttribute("LOADS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_LOADS_7[] LOADS;

		[System.Xml.Serialization.XmlElementAttribute("EMPTIES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_EMPTIES_7[] EMPTIES;

		[System.Xml.Serialization.XmlElementAttribute("TONNAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_TONNAGE_7[] TONNAGE;

		[System.Xml.Serialization.XmlElementAttribute("LENGTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_LENGTH_7[] LENGTH;

		[System.Xml.Serialization.XmlElementAttribute("AXLES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_AXLES_7[] AXLES;

		[System.Xml.Serialization.XmlElementAttribute("OPERATIVE_BRAKES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_OPERATIVE_BRAKES_7[] OPERATIVE_BRAKES;

		[System.Xml.Serialization.XmlElementAttribute("TOTAL_BRAKING_FORCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_TOTAL_BRAKING_FORCE_7[] TOTAL_BRAKING_FORCE;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SPEED_CONSTRAINT_7[] SPEED_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_SPEED_7[] SPEED;

		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_RESTRICTION_COUNT_7[] RESTRICTION_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_RESTRICTION_RECORD_7[] RESTRICTION_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("PTC_LOCO_ORIENTATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_PTC_LOCO_ORIENTATION_7[] PTC_LOCO_ORIENTATION;

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_PTC_ENGINE_INITIAL_7[] PTC_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_PTC_ENGINE_NUMBER_7[] PTC_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_ENGINE_COUNT_7[] ENGINE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONCONTENT_ENGINE_RECORD_7[] ENGINE_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_TRIGGER_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SPEED_CLASS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_LOADS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_EMPTIES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_TONNAGE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_LENGTH_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_AXLES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_OPERATIVE_BRAKES_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_TOTAL_BRAKING_FORCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SPEED_CONSTRAINT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_SPEED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_RESTRICTION_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_RESTRICTION_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("RESTRICTION_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7[] RESTRICTION_TYPE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONRESTRICTION_RECORD_RESTRICTION_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_PTC_LOCO_ORIENTATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_PTC_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_PTC_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_ENGINE_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONCONTENT_ENGINE_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("POSITION_IN_CONSIST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_POSITION_IN_CONSIST_7[] POSITION_IN_CONSIST;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_ENGINE_INITIAL_7[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_ENGINE_NUMBER_7[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_ENGINE_STATUS_7[] ENGINE_STATUS;

		[System.Xml.Serialization.XmlElementAttribute("WEIGHT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_WEIGHT_7[] WEIGHT;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_LENGTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_ENGINE_LENGTH_7[] ENGINE_LENGTH;

		[System.Xml.Serialization.XmlElementAttribute("HORSEPOWER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_HORSEPOWER_7[] HORSEPOWER;

		[System.Xml.Serialization.XmlElementAttribute("DB_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DC_TCONENGINE_RECORD_DB_STATUS_7[] DB_STATUS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_POSITION_IN_CONSIST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_ENGINE_STATUS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_WEIGHT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_ENGINE_LENGTH_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_HORSEPOWER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DC_TCONENGINE_RECORD_DB_STATUS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}