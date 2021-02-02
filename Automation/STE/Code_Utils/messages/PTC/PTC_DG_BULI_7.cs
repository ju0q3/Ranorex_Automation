using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.PTC
{
	public partial class PTC_DG_BULI_7 {
		public PTC_DG_BULIHEADER_7 HEADER;
		public PTC_DG_BULICONTENT_7 CONTENT;

		public static PTC_DG_BULI_7 fromSerializableObject(DG_BULI_7 message) {
			PTC_DG_BULI_7 dg_buli_7 = new PTC_DG_BULI_7();
			DG_BULIHEADER_7 header = null;
			DG_BULICONTENT_7 content = null;
			header = (DG_BULIHEADER_7) message.Items[0];
			content = (DG_BULICONTENT_7) message.Items[1];

			if (header != null) {
				PTC_DG_BULIHEADER_7 messageheader = new PTC_DG_BULIHEADER_7();

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

				dg_buli_7.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				PTC_DG_BULICONTENT_7 messagecontent = new PTC_DG_BULICONTENT_7();

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
							if (intConvertedValue < 0 || intConvertedValue > 1) {
								Ranorex.Report.Failure("Field ACTION expected to have value between 0 and 1, but was found to have a value of " + messagecontent.ACTION + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ACTION is a Mandatory field but was found to be missing from the message");
				}

				if (content.VOICE_ACK_REQUIRED != null) {
					messagecontent.VOICE_ACK_REQUIRED = content.VOICE_ACK_REQUIRED[0].Value;
					if (messagecontent.VOICE_ACK_REQUIRED != null) {
						if (messagecontent.VOICE_ACK_REQUIRED.Length != 1) {
							Ranorex.Report.Failure("Field VOICE_ACK_REQUIRED expected to be length of 1, has length of {" + messagecontent.VOICE_ACK_REQUIRED.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.VOICE_ACK_REQUIRED)) {
							Ranorex.Report.Failure("Field VOICE_ACK_REQUIRED expected to be Alphabetic, has value of {" + messagecontent.VOICE_ACK_REQUIRED + "}.");
						}
						if (messagecontent.VOICE_ACK_REQUIRED != "Y" && messagecontent.VOICE_ACK_REQUIRED != "N") {
							Ranorex.Report.Failure("Field VOICE_ACK_REQUIRED expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.VOICE_ACK_REQUIRED + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field VOICE_ACK_REQUIRED is a Mandatory field but was found to be missing from the message");
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

				if (content.ELECTRONIC_ACK_REQUESTED != null) {
					messagecontent.ELECTRONIC_ACK_REQUESTED = content.ELECTRONIC_ACK_REQUESTED[0].Value;
					if (messagecontent.ELECTRONIC_ACK_REQUESTED != null) {
						if (messagecontent.ELECTRONIC_ACK_REQUESTED.Length != 1) {
							Ranorex.Report.Failure("Field ELECTRONIC_ACK_REQUESTED expected to be length of 1, has length of {" + messagecontent.ELECTRONIC_ACK_REQUESTED.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.ELECTRONIC_ACK_REQUESTED)) {
							Ranorex.Report.Failure("Field ELECTRONIC_ACK_REQUESTED expected to be Alphabetic, has value of {" + messagecontent.ELECTRONIC_ACK_REQUESTED + "}.");
						}
						if (messagecontent.ELECTRONIC_ACK_REQUESTED != "Y" && messagecontent.ELECTRONIC_ACK_REQUESTED != "N") {
							Ranorex.Report.Failure("Field ELECTRONIC_ACK_REQUESTED expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.ELECTRONIC_ACK_REQUESTED + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field ELECTRONIC_ACK_REQUESTED is a Mandatory field but was found to be missing from the message");
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

				if (content.VOID_DATE != null) {
					messagecontent.VOID_DATE = content.VOID_DATE[0].Value;
					if (messagecontent.VOID_DATE != null) {
						if (messagecontent.VOID_DATE.Length != 8) {
							Ranorex.Report.Failure("Field VOID_DATE expected to be length of 8, has length of {" + messagecontent.VOID_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.VOID_DATE)) {
							Ranorex.Report.Failure("Field VOID_DATE expected to be Numeric, has value of {" + messagecontent.VOID_DATE + "}.");
						}
					}
				}

				if (content.VOID_TIME != null) {
					messagecontent.VOID_TIME = content.VOID_TIME[0].Value;
					if (messagecontent.VOID_TIME != null) {
						if (messagecontent.VOID_TIME.Length != 4) {
							Ranorex.Report.Failure("Field VOID_TIME expected to be length of 4, has length of {" + messagecontent.VOID_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.VOID_TIME)) {
							Ranorex.Report.Failure("Field VOID_TIME expected to be Numeric, has value of {" + messagecontent.VOID_TIME + "}.");
						}
					}
				}

				if (content.TOD_FILTER_COUNT != null) {
					messagecontent.TOD_FILTER_COUNT = content.TOD_FILTER_COUNT[0].Value;
					if (messagecontent.TOD_FILTER_COUNT != null) {
						if (messagecontent.TOD_FILTER_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field TOD_FILTER_COUNT expected to be length of 1, has length of {" + messagecontent.TOD_FILTER_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TOD_FILTER_COUNT)) {
							Ranorex.Report.Failure("Field TOD_FILTER_COUNT expected to be Numeric, has value of {" + messagecontent.TOD_FILTER_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.TOD_FILTER_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 7) {
								Ranorex.Report.Failure("Field TOD_FILTER_COUNT expected to have value between 0 and 7, but was found to have a value of " + messagecontent.TOD_FILTER_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field TOD_FILTER_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.TOD_RECORD != null) {
					for (int i = 0; i < content.TOD_RECORD.Length; i++) {
						PTC_DG_BULITOD_RECORD_7 tod_record = new PTC_DG_BULITOD_RECORD_7();

						if (content.TOD_RECORD[i].TOD_DAY_OF_WEEK != null) {
							tod_record.TOD_DAY_OF_WEEK = content.TOD_RECORD[i].TOD_DAY_OF_WEEK[0].Value;
							if (tod_record.TOD_DAY_OF_WEEK != null) {
								if (tod_record.TOD_DAY_OF_WEEK.Length != 1) {
									Ranorex.Report.Failure("Field TOD_DAY_OF_WEEK expected to be length of 1, has length of {" + tod_record.TOD_DAY_OF_WEEK.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(tod_record.TOD_DAY_OF_WEEK)) {
									Ranorex.Report.Failure("Field TOD_DAY_OF_WEEK expected to be Numeric, has value of {" + tod_record.TOD_DAY_OF_WEEK + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(tod_record.TOD_DAY_OF_WEEK);
									if (intConvertedValue < 1 || intConvertedValue > 7) {
										Ranorex.Report.Failure("Field TOD_DAY_OF_WEEK expected to have value between 1 and 7, but was found to have a value of " + tod_record.TOD_DAY_OF_WEEK + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field TOD_DAY_OF_WEEK is a Mandatory field but was found to be missing from the message");
						}

						if (content.TOD_RECORD[i].TOD_START_TIME != null) {
							tod_record.TOD_START_TIME = content.TOD_RECORD[i].TOD_START_TIME[0].Value;
							if (tod_record.TOD_START_TIME != null) {
								if (tod_record.TOD_START_TIME.Length != 4) {
									Ranorex.Report.Failure("Field TOD_START_TIME expected to be length of 4, has length of {" + tod_record.TOD_START_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(tod_record.TOD_START_TIME)) {
									Ranorex.Report.Failure("Field TOD_START_TIME expected to be Numeric, has value of {" + tod_record.TOD_START_TIME + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field TOD_START_TIME is a Mandatory field but was found to be missing from the message");
						}

						if (content.TOD_RECORD[i].TOD_END_TIME != null) {
							tod_record.TOD_END_TIME = content.TOD_RECORD[i].TOD_END_TIME[0].Value;
							if (tod_record.TOD_END_TIME != null) {
								if (tod_record.TOD_END_TIME.Length != 4) {
									Ranorex.Report.Failure("Field TOD_END_TIME expected to be length of 4, has length of {" + tod_record.TOD_END_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(tod_record.TOD_END_TIME)) {
									Ranorex.Report.Failure("Field TOD_END_TIME expected to be Numeric, has value of {" + tod_record.TOD_END_TIME + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field TOD_END_TIME is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addTOD_RECORD(tod_record);
					}
				}

				if (content.SPEED_RESTRICT_CNT != null) {
					messagecontent.SPEED_RESTRICT_CNT = content.SPEED_RESTRICT_CNT[0].Value;
					if (messagecontent.SPEED_RESTRICT_CNT != null) {
						if (messagecontent.SPEED_RESTRICT_CNT.Length < 1 || messagecontent.SPEED_RESTRICT_CNT.Length > 2) {
							Ranorex.Report.Failure("Field SPEED_RESTRICT_CNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.SPEED_RESTRICT_CNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.SPEED_RESTRICT_CNT)) {
							Ranorex.Report.Failure("Field SPEED_RESTRICT_CNT expected to be Numeric, has value of {" + messagecontent.SPEED_RESTRICT_CNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field SPEED_RESTRICT_CNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.SPEED_RECORD != null) {
					for (int i = 0; i < content.SPEED_RECORD.Length; i++) {
						PTC_DG_BULISPEED_RECORD_7 speed_record = new PTC_DG_BULISPEED_RECORD_7();

						if (content.SPEED_RECORD[i].SPEED_CLASS != null) {
							speed_record.SPEED_CLASS = content.SPEED_RECORD[i].SPEED_CLASS[0].Value;
							if (speed_record.SPEED_CLASS != null) {
								if (speed_record.SPEED_CLASS.Length < 3 || speed_record.SPEED_CLASS.Length > 15) {
									Ranorex.Report.Failure("Field SPEED_CLASS expected to be length between or equal to 3 and 15, has length of {" + speed_record.SPEED_CLASS.Length.ToString() + "}.");
								}
								if (ContainsDigits(speed_record.SPEED_CLASS)) {
									Ranorex.Report.Failure("Field SPEED_CLASS expected to be Alphabetic, has value of {" + speed_record.SPEED_CLASS + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field SPEED_CLASS is a Mandatory field but was found to be missing from the message");
						}

						if (content.SPEED_RECORD[i].SPEED != null) {
							speed_record.SPEED = content.SPEED_RECORD[i].SPEED[0].Value;
							if (speed_record.SPEED != null) {
								if (speed_record.SPEED.Length < 1 || speed_record.SPEED.Length > 3) {
									Ranorex.Report.Failure("Field SPEED expected to be length between or equal to 1 and 3, has length of {" + speed_record.SPEED.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(speed_record.SPEED)) {
									Ranorex.Report.Failure("Field SPEED expected to be Numeric, has value of {" + speed_record.SPEED + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field SPEED is a Mandatory field but was found to be missing from the message");
						}

						if (content.SPEED_RECORD[i].HEO_SPEED_RESTRICTION != null) {
							speed_record.HEO_SPEED_RESTRICTION = content.SPEED_RECORD[i].HEO_SPEED_RESTRICTION[0].Value;
							if (speed_record.HEO_SPEED_RESTRICTION != null) {
								if (speed_record.HEO_SPEED_RESTRICTION.Length != 1) {
									Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be length of 1, has length of {" + speed_record.HEO_SPEED_RESTRICTION.Length.ToString() + "}.");
								}
								if (ContainsDigits(speed_record.HEO_SPEED_RESTRICTION)) {
									Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be Alphabetic, has value of {" + speed_record.HEO_SPEED_RESTRICTION + "}.");
								}
								if (speed_record.HEO_SPEED_RESTRICTION != "Y" && speed_record.HEO_SPEED_RESTRICTION != "N") {
									Ranorex.Report.Failure("Field HEO_SPEED_RESTRICTION expected to be one of the following values {Y, N}, but was found to be {" + speed_record.HEO_SPEED_RESTRICTION + "}.");
								}
							}
						}

						if (content.SPEED_RECORD[i].RESTRICTED_SPEED != null) {
							speed_record.RESTRICTED_SPEED = content.SPEED_RECORD[i].RESTRICTED_SPEED[0].Value;
							if (speed_record.RESTRICTED_SPEED != null) {
								if (speed_record.RESTRICTED_SPEED.Length != 1) {
									Ranorex.Report.Failure("Field RESTRICTED_SPEED expected to be length of 1, has length of {" + speed_record.RESTRICTED_SPEED.Length.ToString() + "}.");
								}
								if (ContainsDigits(speed_record.RESTRICTED_SPEED)) {
									Ranorex.Report.Failure("Field RESTRICTED_SPEED expected to be Alphabetic, has value of {" + speed_record.RESTRICTED_SPEED + "}.");
								}
								if (speed_record.RESTRICTED_SPEED != "Y" && speed_record.RESTRICTED_SPEED != "N") {
									Ranorex.Report.Failure("Field RESTRICTED_SPEED expected to be one of the following values {Y, N}, but was found to be {" + speed_record.RESTRICTED_SPEED + "}.");
								}
							}
						}

						messagecontent.addSPEED_RECORD(speed_record);
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

				if (content.XING_WARNING_TYPE != null) {
					messagecontent.XING_WARNING_TYPE = content.XING_WARNING_TYPE[0].Value;
					if (messagecontent.XING_WARNING_TYPE != null) {
						if (messagecontent.XING_WARNING_TYPE.Length < 1 || messagecontent.XING_WARNING_TYPE.Length > 32) {
							Ranorex.Report.Failure("Field XING_WARNING_TYPE expected to be length between or equal to 1 and 32, has length of {" + messagecontent.XING_WARNING_TYPE.Length.ToString() + "}.");
						}
					}
				}

				if (content.ROUTE_COUNT != null) {
					messagecontent.ROUTE_COUNT = content.ROUTE_COUNT[0].Value;
					if (messagecontent.ROUTE_COUNT != null) {
						if (messagecontent.ROUTE_COUNT.Length < 1 || messagecontent.ROUTE_COUNT.Length > 3) {
							Ranorex.Report.Failure("Field ROUTE_COUNT expected to be length between or equal to 1 and 3, has length of {" + messagecontent.ROUTE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ROUTE_COUNT)) {
							Ranorex.Report.Failure("Field ROUTE_COUNT expected to be Numeric, has value of {" + messagecontent.ROUTE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.ROUTE_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 100) {
								Ranorex.Report.Failure("Field ROUTE_COUNT expected to have value between 0 and 100, but was found to have a value of " + messagecontent.ROUTE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ROUTE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.ROUTE_RECORD != null) {
					for (int i = 0; i < content.ROUTE_RECORD.Length; i++) {
						PTC_DG_BULIROUTE_RECORD_7 route_record = new PTC_DG_BULIROUTE_RECORD_7();

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
								if (route_record.START_MILEPOST.Length < 1 || route_record.START_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field START_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + route_record.START_MILEPOST.Length.ToString() + "}.");
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
								if (route_record.END_MILEPOST.Length < 1 || route_record.END_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field END_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + route_record.END_MILEPOST.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addROUTE_RECORD(route_record);
					}
				}

				if (content.ROUTE_DISTRICT_COUNT != null) {
					messagecontent.ROUTE_DISTRICT_COUNT = content.ROUTE_DISTRICT_COUNT[0].Value;
					if (messagecontent.ROUTE_DISTRICT_COUNT != null) {
						if (messagecontent.ROUTE_DISTRICT_COUNT.Length < 1 || messagecontent.ROUTE_DISTRICT_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.ROUTE_DISTRICT_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ROUTE_DISTRICT_COUNT)) {
							Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT expected to be Numeric, has value of {" + messagecontent.ROUTE_DISTRICT_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.ROUTE_DISTRICT_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 50) {
								Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT expected to have value between 0 and 50, but was found to have a value of " + messagecontent.ROUTE_DISTRICT_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ROUTE_DISTRICT_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.ROUTE_DISTRICT_RECORD != null) {
					for (int i = 0; i < content.ROUTE_DISTRICT_RECORD.Length; i++) {
						PTC_DG_BULIROUTE_DISTRICT_RECORD_7 route_district_record = new PTC_DG_BULIROUTE_DISTRICT_RECORD_7();

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
						}
					}
				} else {
					Ranorex.Report.Failure("Field CROSSING_DISTRICT_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.CROSSING_RECORD != null) {
					for (int i = 0; i < content.CROSSING_RECORD.Length; i++) {
						PTC_DG_BULICROSSING_RECORD_7 crossing_record = new PTC_DG_BULICROSSING_RECORD_7();

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

				if (content.SUMMARY_TEXT != null) {
					messagecontent.SUMMARY_TEXT = content.SUMMARY_TEXT[0].Value;
					if (messagecontent.SUMMARY_TEXT != null) {
						if (messagecontent.SUMMARY_TEXT.Length < 1 || messagecontent.SUMMARY_TEXT.Length > 80) {
							Ranorex.Report.Failure("Field SUMMARY_TEXT expected to be length between or equal to 1 and 80, has length of {" + messagecontent.SUMMARY_TEXT.Length.ToString() + "}.");
						}
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
						PTC_DG_BULITEXT_RECORD_7 text_record = new PTC_DG_BULITEXT_RECORD_7();

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
								if (text_record.TEXT.Length < 0 || text_record.TEXT.Length > 60) {
									Ranorex.Report.Failure("Field TEXT expected to be length between or equal to 0 and 60, has length of {" + text_record.TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field TEXT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addTEXT_RECORD(text_record);
					}
				} else {
					Ranorex.Report.Failure("Field TEXT_RECORD is a Mandatory field but was found to be missing from the message");
				}

				if (content.RECEIVE_COUNT != null) {
					messagecontent.RECEIVE_COUNT = content.RECEIVE_COUNT[0].Value;
					if (messagecontent.RECEIVE_COUNT != null) {
						if (messagecontent.RECEIVE_COUNT.Length < 1 || messagecontent.RECEIVE_COUNT.Length > 4) {
							Ranorex.Report.Failure("Field RECEIVE_COUNT expected to be length between or equal to 1 and 4, has length of {" + messagecontent.RECEIVE_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.RECEIVE_COUNT)) {
							Ranorex.Report.Failure("Field RECEIVE_COUNT expected to be Numeric, has value of {" + messagecontent.RECEIVE_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.RECEIVE_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 9999) {
								Ranorex.Report.Failure("Field RECEIVE_COUNT expected to have value between 0 and 9999, but was found to have a value of " + messagecontent.RECEIVE_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field RECEIVE_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.RECEIVE_RECORD != null) {
					for (int i = 0; i < content.RECEIVE_RECORD.Length; i++) {
						PTC_DG_BULIRECEIVE_RECORD_7 receive_record = new PTC_DG_BULIRECEIVE_RECORD_7();

						if (content.RECEIVE_RECORD[i].RECEIVE_SCAC != null) {
							receive_record.RECEIVE_SCAC = content.RECEIVE_RECORD[i].RECEIVE_SCAC[0].Value;
							if (receive_record.RECEIVE_SCAC != null) {
								if (receive_record.RECEIVE_SCAC.Length < 1 || receive_record.RECEIVE_SCAC.Length > 4) {
									Ranorex.Report.Failure("Field RECEIVE_SCAC expected to be length between or equal to 1 and 4, has length of {" + receive_record.RECEIVE_SCAC.Length.ToString() + "}.");
								}
								if (ContainsDigits(receive_record.RECEIVE_SCAC)) {
									Ranorex.Report.Failure("Field RECEIVE_SCAC expected to be Alphabetic, has value of {" + receive_record.RECEIVE_SCAC + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RECEIVE_SCAC is a Mandatory field but was found to be missing from the message");
						}

						if (content.RECEIVE_RECORD[i].RECEIVE_SYMBOL != null) {
							receive_record.RECEIVE_SYMBOL = content.RECEIVE_RECORD[i].RECEIVE_SYMBOL[0].Value;
							if (receive_record.RECEIVE_SYMBOL != null) {
								if (receive_record.RECEIVE_SYMBOL.Length < 1 || receive_record.RECEIVE_SYMBOL.Length > 10) {
									Ranorex.Report.Failure("Field RECEIVE_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + receive_record.RECEIVE_SYMBOL.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RECEIVE_SYMBOL is a Mandatory field but was found to be missing from the message");
						}

						if (content.RECEIVE_RECORD[i].RECEIVE_SECTION != null) {
							receive_record.RECEIVE_SECTION = content.RECEIVE_RECORD[i].RECEIVE_SECTION[0].Value;
							if (receive_record.RECEIVE_SECTION != null) {
								if (receive_record.RECEIVE_SECTION.Length != 1) {
									Ranorex.Report.Failure("Field RECEIVE_SECTION expected to be length of 1, has length of {" + receive_record.RECEIVE_SECTION.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(receive_record.RECEIVE_SECTION)) {
									Ranorex.Report.Failure("Field RECEIVE_SECTION expected to be Numeric, has value of {" + receive_record.RECEIVE_SECTION + "}.");
								}
							}
						}

						if (content.RECEIVE_RECORD[i].RECEIVE_ORIGIN_DATE != null) {
							receive_record.RECEIVE_ORIGIN_DATE = content.RECEIVE_RECORD[i].RECEIVE_ORIGIN_DATE[0].Value;
							if (receive_record.RECEIVE_ORIGIN_DATE != null) {
								if (receive_record.RECEIVE_ORIGIN_DATE.Length != 8) {
									Ranorex.Report.Failure("Field RECEIVE_ORIGIN_DATE expected to be length of 8, has length of {" + receive_record.RECEIVE_ORIGIN_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(receive_record.RECEIVE_ORIGIN_DATE)) {
									Ranorex.Report.Failure("Field RECEIVE_ORIGIN_DATE expected to be Numeric, has value of {" + receive_record.RECEIVE_ORIGIN_DATE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RECEIVE_ORIGIN_DATE is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addRECEIVE_RECORD(receive_record);
					}
				}

				if (content.RETAIN_COUNT != null) {
					messagecontent.RETAIN_COUNT = content.RETAIN_COUNT[0].Value;
					if (messagecontent.RETAIN_COUNT != null) {
						if (messagecontent.RETAIN_COUNT.Length < 1 || messagecontent.RETAIN_COUNT.Length > 4) {
							Ranorex.Report.Failure("Field RETAIN_COUNT expected to be length between or equal to 1 and 4, has length of {" + messagecontent.RETAIN_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.RETAIN_COUNT)) {
							Ranorex.Report.Failure("Field RETAIN_COUNT expected to be Numeric, has value of {" + messagecontent.RETAIN_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.RETAIN_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 9999) {
								Ranorex.Report.Failure("Field RETAIN_COUNT expected to have value between 0 and 9999, but was found to have a value of " + messagecontent.RETAIN_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field RETAIN_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.RETAIN_RECORD != null) {
					for (int i = 0; i < content.RETAIN_RECORD.Length; i++) {
						PTC_DG_BULIRETAIN_RECORD_7 retain_record = new PTC_DG_BULIRETAIN_RECORD_7();

						if (content.RETAIN_RECORD[i].RETAIN_SCAC != null) {
							retain_record.RETAIN_SCAC = content.RETAIN_RECORD[i].RETAIN_SCAC[0].Value;
							if (retain_record.RETAIN_SCAC != null) {
								if (retain_record.RETAIN_SCAC.Length < 1 || retain_record.RETAIN_SCAC.Length > 4) {
									Ranorex.Report.Failure("Field RETAIN_SCAC expected to be length between or equal to 1 and 4, has length of {" + retain_record.RETAIN_SCAC.Length.ToString() + "}.");
								}
								if (ContainsDigits(retain_record.RETAIN_SCAC)) {
									Ranorex.Report.Failure("Field RETAIN_SCAC expected to be Alphabetic, has value of {" + retain_record.RETAIN_SCAC + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RETAIN_SCAC is a Mandatory field but was found to be missing from the message");
						}

						if (content.RETAIN_RECORD[i].RETAIN_SYMBOL != null) {
							retain_record.RETAIN_SYMBOL = content.RETAIN_RECORD[i].RETAIN_SYMBOL[0].Value;
							if (retain_record.RETAIN_SYMBOL != null) {
								if (retain_record.RETAIN_SYMBOL.Length < 1 || retain_record.RETAIN_SYMBOL.Length > 10) {
									Ranorex.Report.Failure("Field RETAIN_SYMBOL expected to be length between or equal to 1 and 10, has length of {" + retain_record.RETAIN_SYMBOL.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RETAIN_SYMBOL is a Mandatory field but was found to be missing from the message");
						}

						if (content.RETAIN_RECORD[i].RETAIN_SECTION != null) {
							retain_record.RETAIN_SECTION = content.RETAIN_RECORD[i].RETAIN_SECTION[0].Value;
							if (retain_record.RETAIN_SECTION != null) {
								if (retain_record.RETAIN_SECTION.Length != 1) {
									Ranorex.Report.Failure("Field RETAIN_SECTION expected to be length of 1, has length of {" + retain_record.RETAIN_SECTION.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(retain_record.RETAIN_SECTION)) {
									Ranorex.Report.Failure("Field RETAIN_SECTION expected to be Numeric, has value of {" + retain_record.RETAIN_SECTION + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(retain_record.RETAIN_SECTION);
									if (intConvertedValue < 1 || intConvertedValue > 9) {
										Ranorex.Report.Failure("Field RETAIN_SECTION expected to have value between 1 and 9, but was found to have a value of " + retain_record.RETAIN_SECTION + ".");
									}
								}
							}
						}

						if (content.RETAIN_RECORD[i].RETAIN_ORIGIN_DATE != null) {
							retain_record.RETAIN_ORIGIN_DATE = content.RETAIN_RECORD[i].RETAIN_ORIGIN_DATE[0].Value;
							if (retain_record.RETAIN_ORIGIN_DATE != null) {
								if (retain_record.RETAIN_ORIGIN_DATE.Length != 8) {
									Ranorex.Report.Failure("Field RETAIN_ORIGIN_DATE expected to be length of 8, has length of {" + retain_record.RETAIN_ORIGIN_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(retain_record.RETAIN_ORIGIN_DATE)) {
									Ranorex.Report.Failure("Field RETAIN_ORIGIN_DATE expected to be Numeric, has value of {" + retain_record.RETAIN_ORIGIN_DATE + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RETAIN_ORIGIN_DATE is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addRETAIN_RECORD(retain_record);
					}
				}

				dg_buli_7.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dg_buli_7;
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
	public partial class PTC_DG_BULIHEADER_7 {
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

	public partial class PTC_DG_BULICONTENT_7 {
		public string ACTION = "";
		public string VOICE_ACK_REQUIRED = "";
		public string CREW_ACK_REQUIRED = "";
		public string ELECTRONIC_ACK_REQUESTED = "";
		public string BULLETIN_ITEM_NUMBER = "";
		public string BULLETIN_ITEM_TYPE = "";
		public string FROM_LIMIT = "";
		public string TO_LIMIT = "";
		public string EYE_CATCHER_TEXT = "";
		public string EFFECTIVE_DATE = "";
		public string EFFECTIVE_TIME = "";
		public string EXPIRATION_DATE = "";
		public string EXPIRATION_TIME = "";
		public string VOID_DATE = "";
		public string VOID_TIME = "";
		public string TOD_FILTER_COUNT = "";
		public ArrayList TOD_RECORD = new ArrayList();
		public string SPEED_RESTRICT_CNT = "";
		public ArrayList SPEED_RECORD = new ArrayList();
		public string CONTACT = "";
		public string XING_WARNING_TYPE = "";
		public string ROUTE_COUNT = "";
		public ArrayList ROUTE_RECORD = new ArrayList();
		public string ROUTE_DISTRICT_COUNT = "";
		public ArrayList ROUTE_DISTRICT_RECORD = new ArrayList();
		public string CROSSING_ID = "";
		public string CROSSING_DISTRICT_COUNT = "";
		public ArrayList CROSSING_RECORD = new ArrayList();
		public string SUMMARY_TEXT = "";
		public string LINE_COUNT = "";
		public ArrayList TEXT_RECORD = new ArrayList();
		public string RECEIVE_COUNT = "";
		public ArrayList RECEIVE_RECORD = new ArrayList();
		public string RETAIN_COUNT = "";
		public ArrayList RETAIN_RECORD = new ArrayList();

		public void addTOD_RECORD(PTC_DG_BULITOD_RECORD_7 tod_record) {
			this.TOD_RECORD.Add(tod_record);
		}

		public void addSPEED_RECORD(PTC_DG_BULISPEED_RECORD_7 speed_record) {
			this.SPEED_RECORD.Add(speed_record);
		}

		public void addROUTE_RECORD(PTC_DG_BULIROUTE_RECORD_7 route_record) {
			this.ROUTE_RECORD.Add(route_record);
		}

		public void addROUTE_DISTRICT_RECORD(PTC_DG_BULIROUTE_DISTRICT_RECORD_7 route_district_record) {
			this.ROUTE_DISTRICT_RECORD.Add(route_district_record);
		}

		public void addCROSSING_RECORD(PTC_DG_BULICROSSING_RECORD_7 crossing_record) {
			this.CROSSING_RECORD.Add(crossing_record);
		}

		public void addTEXT_RECORD(PTC_DG_BULITEXT_RECORD_7 text_record) {
			this.TEXT_RECORD.Add(text_record);
		}

		public void addRECEIVE_RECORD(PTC_DG_BULIRECEIVE_RECORD_7 receive_record) {
			this.RECEIVE_RECORD.Add(receive_record);
		}

		public void addRETAIN_RECORD(PTC_DG_BULIRETAIN_RECORD_7 retain_record) {
			this.RETAIN_RECORD.Add(retain_record);
		}
	}

	public partial class PTC_DG_BULITOD_RECORD_7 {
		public string TOD_DAY_OF_WEEK = "";
		public string TOD_START_TIME = "";
		public string TOD_END_TIME = "";
	}

	public partial class PTC_DG_BULISPEED_RECORD_7 {
		public string SPEED_CLASS = "";
		public string SPEED = "";
		public string HEO_SPEED_RESTRICTION = "";
		public string RESTRICTED_SPEED = "";
	}

	public partial class PTC_DG_BULIROUTE_RECORD_7 {
		public string TRACK = "";
		public string START_DISTRICT = "";
		public string START_MILEPOST = "";
		public string END_DISTRICT = "";
		public string END_MILEPOST = "";
	}

	public partial class PTC_DG_BULIROUTE_DISTRICT_RECORD_7 {
		public string ROUTE_DISTRICT_NAME = "";
	}

	public partial class PTC_DG_BULICROSSING_RECORD_7 {
		public string CROSSING_DISTRICT_NAME = "";
	}

	public partial class PTC_DG_BULITEXT_RECORD_7 {
		public string TEXT_SEQUENCE = "";
		public string TEXT = "";
	}

	public partial class PTC_DG_BULIRECEIVE_RECORD_7 {
		public string RECEIVE_SCAC = "";
		public string RECEIVE_SYMBOL = "";
		public string RECEIVE_SECTION = "";
		public string RECEIVE_ORIGIN_DATE = "";
	}

	public partial class PTC_DG_BULIRETAIN_RECORD_7 {
		public string RETAIN_SCAC = "";
		public string RETAIN_SYMBOL = "";
		public string RETAIN_SECTION = "";
		public string RETAIN_ORIGIN_DATE = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DG_BULI_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DG_BULIHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DG_BULICONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ACTION_7[] ACTION;

		[System.Xml.Serialization.XmlElementAttribute("VOICE_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_VOICE_ACK_REQUIRED_7[] VOICE_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_CREW_ACK_REQUIRED_7[] CREW_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("ELECTRONIC_ACK_REQUESTED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ELECTRONIC_ACK_REQUESTED_7[] ELECTRONIC_ACK_REQUESTED;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_BULLETIN_ITEM_NUMBER_7[] BULLETIN_ITEM_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_BULLETIN_ITEM_TYPE_7[] BULLETIN_ITEM_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("FROM_LIMIT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_FROM_LIMIT_7[] FROM_LIMIT;

		[System.Xml.Serialization.XmlElementAttribute("TO_LIMIT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_TO_LIMIT_7[] TO_LIMIT;

		[System.Xml.Serialization.XmlElementAttribute("EYE_CATCHER_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_EYE_CATCHER_TEXT_7[] EYE_CATCHER_TEXT;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_EFFECTIVE_DATE_7[] EFFECTIVE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EFFECTIVE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_EFFECTIVE_TIME_7[] EFFECTIVE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("EXPIRATION_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_EXPIRATION_DATE_7[] EXPIRATION_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EXPIRATION_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_EXPIRATION_TIME_7[] EXPIRATION_TIME;

		[System.Xml.Serialization.XmlElementAttribute("VOID_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_VOID_DATE_7[] VOID_DATE;

		[System.Xml.Serialization.XmlElementAttribute("VOID_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_VOID_TIME_7[] VOID_TIME;

		[System.Xml.Serialization.XmlElementAttribute("TOD_FILTER_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_TOD_FILTER_COUNT_7[] TOD_FILTER_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("TOD_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_TOD_RECORD_7[] TOD_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_RESTRICT_CNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_SPEED_RESTRICT_CNT_7[] SPEED_RESTRICT_CNT;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_SPEED_RECORD_7[] SPEED_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("CONTACT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_CONTACT_7[] CONTACT;

		[System.Xml.Serialization.XmlElementAttribute("XING_WARNING_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_XING_WARNING_TYPE_7[] XING_WARNING_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ROUTE_COUNT_7[] ROUTE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ROUTE_RECORD_7[] ROUTE_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ROUTE_DISTRICT_COUNT_7[] ROUTE_DISTRICT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_ROUTE_DISTRICT_RECORD_7[] ROUTE_DISTRICT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_CROSSING_ID_7[] CROSSING_ID;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_DISTRICT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_CROSSING_DISTRICT_COUNT_7[] CROSSING_DISTRICT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("CROSSING_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_CROSSING_RECORD_7[] CROSSING_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("SUMMARY_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_SUMMARY_TEXT_7[] SUMMARY_TEXT;

		[System.Xml.Serialization.XmlElementAttribute("LINE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_LINE_COUNT_7[] LINE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("TEXT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_TEXT_RECORD_7[] TEXT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_RECEIVE_COUNT_7[] RECEIVE_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_RECEIVE_RECORD_7[] RECEIVE_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("RETAIN_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_RETAIN_COUNT_7[] RETAIN_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RETAIN_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICONTENT_RETAIN_RECORD_7[] RETAIN_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ACTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_VOICE_ACK_REQUIRED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_CREW_ACK_REQUIRED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ELECTRONIC_ACK_REQUESTED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_BULLETIN_ITEM_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_BULLETIN_ITEM_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_FROM_LIMIT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_TO_LIMIT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_EYE_CATCHER_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_EFFECTIVE_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_EFFECTIVE_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_EXPIRATION_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_EXPIRATION_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_VOID_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_VOID_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_TOD_FILTER_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_TOD_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("TOD_DAY_OF_WEEK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULITOD_RECORD_TOD_DAY_OF_WEEK_7[] TOD_DAY_OF_WEEK;

		[System.Xml.Serialization.XmlElementAttribute("TOD_START_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULITOD_RECORD_TOD_START_TIME_7[] TOD_START_TIME;

		[System.Xml.Serialization.XmlElementAttribute("TOD_END_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULITOD_RECORD_TOD_END_TIME_7[] TOD_END_TIME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULITOD_RECORD_TOD_DAY_OF_WEEK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULITOD_RECORD_TOD_START_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULITOD_RECORD_TOD_END_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_SPEED_RESTRICT_CNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_SPEED_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("SPEED_CLASS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULISPEED_RECORD_SPEED_CLASS_7[] SPEED_CLASS;

		[System.Xml.Serialization.XmlElementAttribute("SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULISPEED_RECORD_SPEED_7[] SPEED;

		[System.Xml.Serialization.XmlElementAttribute("HEO_SPEED_RESTRICTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULISPEED_RECORD_HEO_SPEED_RESTRICTION_7[] HEO_SPEED_RESTRICTION;

		[System.Xml.Serialization.XmlElementAttribute("RESTRICTED_SPEED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULISPEED_RECORD_RESTRICTED_SPEED_7[] RESTRICTED_SPEED;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULISPEED_RECORD_SPEED_CLASS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULISPEED_RECORD_SPEED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULISPEED_RECORD_HEO_SPEED_RESTRICTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULISPEED_RECORD_RESTRICTED_SPEED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_CONTACT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_XING_WARNING_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ROUTE_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ROUTE_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_RECORD_TRACK_7[] TRACK;

		[System.Xml.Serialization.XmlElementAttribute("START_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_RECORD_START_DISTRICT_7[] START_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("START_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_RECORD_START_MILEPOST_7[] START_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("END_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_RECORD_END_DISTRICT_7[] END_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("END_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_RECORD_END_MILEPOST_7[] END_MILEPOST;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_RECORD_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_RECORD_START_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_RECORD_START_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_RECORD_END_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_RECORD_END_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ROUTE_DISTRICT_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_ROUTE_DISTRICT_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("ROUTE_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIROUTE_DISTRICT_RECORD_ROUTE_DISTRICT_NAME_7[] ROUTE_DISTRICT_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIROUTE_DISTRICT_RECORD_ROUTE_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_CROSSING_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_CROSSING_DISTRICT_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_CROSSING_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("CROSSING_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULICROSSING_RECORD_CROSSING_DISTRICT_NAME_7[] CROSSING_DISTRICT_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICROSSING_RECORD_CROSSING_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_SUMMARY_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_LINE_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_TEXT_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("TEXT_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULITEXT_RECORD_TEXT_SEQUENCE_7[] TEXT_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULITEXT_RECORD_TEXT_7[] TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULITEXT_RECORD_TEXT_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULITEXT_RECORD_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_RECEIVE_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_RECEIVE_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRECEIVE_RECORD_RECEIVE_SCAC_7[] RECEIVE_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRECEIVE_RECORD_RECEIVE_SYMBOL_7[] RECEIVE_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRECEIVE_RECORD_RECEIVE_SECTION_7[] RECEIVE_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("RECEIVE_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRECEIVE_RECORD_RECEIVE_ORIGIN_DATE_7[] RECEIVE_ORIGIN_DATE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRECEIVE_RECORD_RECEIVE_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRECEIVE_RECORD_RECEIVE_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRECEIVE_RECORD_RECEIVE_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRECEIVE_RECORD_RECEIVE_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_RETAIN_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULICONTENT_RETAIN_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("RETAIN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRETAIN_RECORD_RETAIN_SCAC_7[] RETAIN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("RETAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRETAIN_RECORD_RETAIN_SYMBOL_7[] RETAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("RETAIN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRETAIN_RECORD_RETAIN_SECTION_7[] RETAIN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("RETAIN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_BULIRETAIN_RECORD_RETAIN_ORIGIN_DATE_7[] RETAIN_ORIGIN_DATE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRETAIN_RECORD_RETAIN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRETAIN_RECORD_RETAIN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRETAIN_RECORD_RETAIN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_BULIRETAIN_RECORD_RETAIN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}