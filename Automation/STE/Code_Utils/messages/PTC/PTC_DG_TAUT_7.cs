using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.PTC
{
	public partial class PTC_DG_TAUT_7 {
		public PTC_DG_TAUTHEADER_7 HEADER;
		public PTC_DG_TAUTCONTENT_7 CONTENT;

		public static PTC_DG_TAUT_7 fromSerializableObject(DG_TAUT_7 message) {
			PTC_DG_TAUT_7 dg_taut_7 = new PTC_DG_TAUT_7();
			DG_TAUTHEADER_7 header = null;
			DG_TAUTCONTENT_7 content = null;
			header = (DG_TAUTHEADER_7) message.Items[0];
			content = (DG_TAUTCONTENT_7) message.Items[1];

			if (header != null) {
				PTC_DG_TAUTHEADER_7 messageheader = new PTC_DG_TAUTHEADER_7();

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

				dg_taut_7.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				PTC_DG_TAUTCONTENT_7 messagecontent = new PTC_DG_TAUTCONTENT_7();

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
							if (intConvertedValue < 0 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field ACTION expected to have value between 0 and 3, but was found to have a value of " + messagecontent.ACTION + ".");
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

				if (content.CREW_ACK_TYPE != null) {
					messagecontent.CREW_ACK_TYPE = content.CREW_ACK_TYPE[0].Value;
					if (messagecontent.CREW_ACK_TYPE != null) {
						if (messagecontent.CREW_ACK_TYPE.Length < 3 || messagecontent.CREW_ACK_TYPE.Length > 7) {
							Ranorex.Report.Failure("Field CREW_ACK_TYPE expected to be length between or equal to 3 and 7, has length of {" + messagecontent.CREW_ACK_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.CREW_ACK_TYPE)) {
							Ranorex.Report.Failure("Field CREW_ACK_TYPE expected to be Alphabetic, has value of {" + messagecontent.CREW_ACK_TYPE + "}.");
						}
						if (messagecontent.CREW_ACK_TYPE != "ACK" && messagecontent.CREW_ACK_TYPE != "APPROVE" && messagecontent.CREW_ACK_TYPE != "NONE") {
							Ranorex.Report.Failure("Field CREW_ACK_TYPE expected to be one of the following values {ACK, APPROVE, NONE}, but was found to be {" + messagecontent.CREW_ACK_TYPE + "}.");
						}
					}
				}

				if (content.AUTHORITY_TYPE != null) {
					messagecontent.AUTHORITY_TYPE = content.AUTHORITY_TYPE[0].Value;
					if (messagecontent.AUTHORITY_TYPE != null) {
						if (messagecontent.AUTHORITY_TYPE.Length < 2 || messagecontent.AUTHORITY_TYPE.Length > 3) {
							Ranorex.Report.Failure("Field AUTHORITY_TYPE expected to be length between or equal to 2 and 3, has length of {" + messagecontent.AUTHORITY_TYPE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.AUTHORITY_TYPE)) {
							Ranorex.Report.Failure("Field AUTHORITY_TYPE expected to be Alphabetic, has value of {" + messagecontent.AUTHORITY_TYPE + "}.");
						}
						if (messagecontent.AUTHORITY_TYPE != "TA" && messagecontent.AUTHORITY_TYPE != "EMT" && messagecontent.AUTHORITY_TYPE != "PSS") {
							Ranorex.Report.Failure("Field AUTHORITY_TYPE expected to be one of the following values {TA, EMT, PSS}, but was found to be {" + messagecontent.AUTHORITY_TYPE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field AUTHORITY_TYPE is a Mandatory field but was found to be missing from the message");
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
					if (messagecontent.S2_COUNT != null) {
						if (messagecontent.S2_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S2_COUNT expected to be length of 1, has length of {" + messagecontent.S2_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S2_COUNT)) {
							Ranorex.Report.Failure("Field S2_COUNT expected to be Numeric, has value of {" + messagecontent.S2_COUNT + "}.");
						}
					}
				}
				if (content.S2_RECORD != null) {
					for (int i = 0; i < content.S2_RECORD.Length; i++) {
						PTC_DG_TAUTS2_RECORD_7 s2_record = new PTC_DG_TAUTS2_RECORD_7();

						if (content.S2_RECORD[i].S2_SEQUENCE != null) {
							s2_record.S2_SEQUENCE = content.S2_RECORD[i].S2_SEQUENCE[0].Value;
							if (s2_record.S2_SEQUENCE != null) {
								if (s2_record.S2_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S2_SEQUENCE expected to be length of 1, has length of {" + s2_record.S2_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s2_record.S2_SEQUENCE)) {
									Ranorex.Report.Failure("Field S2_SEQUENCE expected to be Numeric, has value of {" + s2_record.S2_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s2_record.S2_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S2_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s2_record.S2_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_RECORD[i].S2_TO_LOCATION != null) {
							s2_record.S2_TO_LOCATION = content.S2_RECORD[i].S2_TO_LOCATION[0].Value;
							if (s2_record.S2_TO_LOCATION != null) {
								if (s2_record.S2_TO_LOCATION.Length < 1 || s2_record.S2_TO_LOCATION.Length > 24) {
									Ranorex.Report.Failure("Field S2_TO_LOCATION expected to be length between or equal to 1 and 24, has length of {" + s2_record.S2_TO_LOCATION.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_TO_LOCATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_RECORD[i].S2_TRACK_TEXT != null) {
							s2_record.S2_TRACK_TEXT = content.S2_RECORD[i].S2_TRACK_TEXT[0].Value;
							if (s2_record.S2_TRACK_TEXT != null) {
								if (s2_record.S2_TRACK_TEXT.Length < 1 || s2_record.S2_TRACK_TEXT.Length > 32) {
									Ranorex.Report.Failure("Field S2_TRACK_TEXT expected to be length between or equal to 1 and 32, has length of {" + s2_record.S2_TRACK_TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_TRACK_TEXT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS2_RECORD(s2_record);
					}
				}

				if (content.S2_LIMITS_COUNT != null) {
					messagecontent.S2_LIMITS_COUNT = content.S2_LIMITS_COUNT[0].Value;
					if (messagecontent.S2_LIMITS_COUNT != null) {
						if (messagecontent.S2_LIMITS_COUNT.Length < 1 || messagecontent.S2_LIMITS_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field S2_LIMITS_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.S2_LIMITS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S2_LIMITS_COUNT)) {
							Ranorex.Report.Failure("Field S2_LIMITS_COUNT expected to be Numeric, has value of {" + messagecontent.S2_LIMITS_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S2_LIMITS_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field S2_LIMITS_COUNT expected to have value between 0 and 99, but was found to have a value of " + messagecontent.S2_LIMITS_COUNT + ".");
							}
						}
					}
				}
				if (content.S2_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S2_LIMITS_RECORD.Length; i++) {
						PTC_DG_TAUTS2_LIMITS_RECORD_7 s2_limits_record = new PTC_DG_TAUTS2_LIMITS_RECORD_7();

						if (content.S2_LIMITS_RECORD[i].S2_FROM_DISTRICT != null) {
							s2_limits_record.S2_FROM_DISTRICT = content.S2_LIMITS_RECORD[i].S2_FROM_DISTRICT[0].Value;
							if (s2_limits_record.S2_FROM_DISTRICT != null) {
								if (s2_limits_record.S2_FROM_DISTRICT.Length < 1 || s2_limits_record.S2_FROM_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S2_FROM_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s2_limits_record.S2_FROM_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_FROM_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_LIMITS_RECORD[i].S2_FROM_MILEPOST != null) {
							s2_limits_record.S2_FROM_MILEPOST = content.S2_LIMITS_RECORD[i].S2_FROM_MILEPOST[0].Value;
							if (s2_limits_record.S2_FROM_MILEPOST != null) {
								if (s2_limits_record.S2_FROM_MILEPOST.Length < 1 || s2_limits_record.S2_FROM_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S2_FROM_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s2_limits_record.S2_FROM_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_FROM_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_LIMITS_RECORD[i].S2_TO_DISTRICT != null) {
							s2_limits_record.S2_TO_DISTRICT = content.S2_LIMITS_RECORD[i].S2_TO_DISTRICT[0].Value;
							if (s2_limits_record.S2_TO_DISTRICT != null) {
								if (s2_limits_record.S2_TO_DISTRICT.Length < 1 || s2_limits_record.S2_TO_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S2_TO_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s2_limits_record.S2_TO_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_TO_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_LIMITS_RECORD[i].S2_TO_MILEPOST != null) {
							s2_limits_record.S2_TO_MILEPOST = content.S2_LIMITS_RECORD[i].S2_TO_MILEPOST[0].Value;
							if (s2_limits_record.S2_TO_MILEPOST != null) {
								if (s2_limits_record.S2_TO_MILEPOST.Length < 1 || s2_limits_record.S2_TO_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S2_TO_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s2_limits_record.S2_TO_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_TO_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S2_LIMITS_RECORD[i].S2_TRACK != null) {
							s2_limits_record.S2_TRACK = content.S2_LIMITS_RECORD[i].S2_TRACK[0].Value;
							if (s2_limits_record.S2_TRACK != null) {
								if (s2_limits_record.S2_TRACK.Length < 1 || s2_limits_record.S2_TRACK.Length > 32) {
									Ranorex.Report.Failure("Field S2_TRACK expected to be length between or equal to 1 and 32, has length of {" + s2_limits_record.S2_TRACK.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S2_TRACK is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS2_LIMITS_RECORD(s2_limits_record);
					}
				}

				if (content.S3_PRESENCE != null) {
					messagecontent.S3_PRESENCE = content.S3_PRESENCE[0].Value;
					if (messagecontent.S3_PRESENCE != null) {
						if (messagecontent.S3_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S3_PRESENCE expected to be length of 1, has length of {" + messagecontent.S3_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S3_PRESENCE)) {
							Ranorex.Report.Failure("Field S3_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S3_PRESENCE + "}.");
						}
						if (messagecontent.S3_PRESENCE != "Y" && messagecontent.S3_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S3_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S3_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S3_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S3_BETWEEN_LOCATION != null) {
					messagecontent.S3_BETWEEN_LOCATION = content.S3_BETWEEN_LOCATION[0].Value;
					if (messagecontent.S3_BETWEEN_LOCATION != null) {
						if (messagecontent.S3_BETWEEN_LOCATION.Length < 1 || messagecontent.S3_BETWEEN_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S3_BETWEEN_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S3_BETWEEN_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S3_AND_LOCATION != null) {
					messagecontent.S3_AND_LOCATION = content.S3_AND_LOCATION[0].Value;
					if (messagecontent.S3_AND_LOCATION != null) {
						if (messagecontent.S3_AND_LOCATION.Length < 1 || messagecontent.S3_AND_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S3_AND_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S3_AND_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S3_TRACK_COUNT != null) {
					messagecontent.S3_TRACK_COUNT = content.S3_TRACK_COUNT[0].Value;
					if (messagecontent.S3_TRACK_COUNT != null) {
						if (messagecontent.S3_TRACK_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S3_TRACK_COUNT expected to be length of 1, has length of {" + messagecontent.S3_TRACK_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S3_TRACK_COUNT)) {
							Ranorex.Report.Failure("Field S3_TRACK_COUNT expected to be Numeric, has value of {" + messagecontent.S3_TRACK_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S3_TRACK_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 5) {
								Ranorex.Report.Failure("Field S3_TRACK_COUNT expected to have value between 0 and 5, but was found to have a value of " + messagecontent.S3_TRACK_COUNT + ".");
							}
						}
					}
				}
				if (content.S3_TRACK_RECORD != null) {
					for (int i = 0; i < content.S3_TRACK_RECORD.Length; i++) {
						PTC_DG_TAUTS3_TRACK_RECORD_7 s3_track_record = new PTC_DG_TAUTS3_TRACK_RECORD_7();

						if (content.S3_TRACK_RECORD[i].S3_TRACK_SEQUENCE != null) {
							s3_track_record.S3_TRACK_SEQUENCE = content.S3_TRACK_RECORD[i].S3_TRACK_SEQUENCE[0].Value;
							if (s3_track_record.S3_TRACK_SEQUENCE != null) {
								if (s3_track_record.S3_TRACK_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S3_TRACK_SEQUENCE expected to be length of 1, has length of {" + s3_track_record.S3_TRACK_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s3_track_record.S3_TRACK_SEQUENCE)) {
									Ranorex.Report.Failure("Field S3_TRACK_SEQUENCE expected to be Numeric, has value of {" + s3_track_record.S3_TRACK_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s3_track_record.S3_TRACK_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 5) {
										Ranorex.Report.Failure("Field S3_TRACK_SEQUENCE expected to have value between 1 and 5, but was found to have a value of " + s3_track_record.S3_TRACK_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_TRACK_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S3_TRACK_RECORD[i].S3_TRACK_TEXT != null) {
							s3_track_record.S3_TRACK_TEXT = content.S3_TRACK_RECORD[i].S3_TRACK_TEXT[0].Value;
							if (s3_track_record.S3_TRACK_TEXT != null) {
								if (s3_track_record.S3_TRACK_TEXT.Length < 1 || s3_track_record.S3_TRACK_TEXT.Length > 32) {
									Ranorex.Report.Failure("Field S3_TRACK_TEXT expected to be length between or equal to 1 and 32, has length of {" + s3_track_record.S3_TRACK_TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_TRACK_TEXT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS3_TRACK_RECORD(s3_track_record);
					}
				}

				if (content.S3_LIMITS_COUNT != null) {
					messagecontent.S3_LIMITS_COUNT = content.S3_LIMITS_COUNT[0].Value;
					if (messagecontent.S3_LIMITS_COUNT != null) {
						if (messagecontent.S3_LIMITS_COUNT.Length < 1 || messagecontent.S3_LIMITS_COUNT.Length > 3) {
							Ranorex.Report.Failure("Field S3_LIMITS_COUNT expected to be length between or equal to 1 and 3, has length of {" + messagecontent.S3_LIMITS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S3_LIMITS_COUNT)) {
							Ranorex.Report.Failure("Field S3_LIMITS_COUNT expected to be Numeric, has value of {" + messagecontent.S3_LIMITS_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S3_LIMITS_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 205) {
								Ranorex.Report.Failure("Field S3_LIMITS_COUNT expected to have value between 0 and 205, but was found to have a value of " + messagecontent.S3_LIMITS_COUNT + ".");
							}
						}
					}
				}
				if (content.S3_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S3_LIMITS_RECORD.Length; i++) {
						PTC_DG_TAUTS3_LIMITS_RECORD_7 s3_limits_record = new PTC_DG_TAUTS3_LIMITS_RECORD_7();

						if (content.S3_LIMITS_RECORD[i].S3_BETWEEN_DISTRICT != null) {
							s3_limits_record.S3_BETWEEN_DISTRICT = content.S3_LIMITS_RECORD[i].S3_BETWEEN_DISTRICT[0].Value;
							if (s3_limits_record.S3_BETWEEN_DISTRICT != null) {
								if (s3_limits_record.S3_BETWEEN_DISTRICT.Length < 1 || s3_limits_record.S3_BETWEEN_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S3_BETWEEN_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s3_limits_record.S3_BETWEEN_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_BETWEEN_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S3_LIMITS_RECORD[i].S3_BETWEEN_MILEPOST != null) {
							s3_limits_record.S3_BETWEEN_MILEPOST = content.S3_LIMITS_RECORD[i].S3_BETWEEN_MILEPOST[0].Value;
							if (s3_limits_record.S3_BETWEEN_MILEPOST != null) {
								if (s3_limits_record.S3_BETWEEN_MILEPOST.Length < 1 || s3_limits_record.S3_BETWEEN_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S3_BETWEEN_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s3_limits_record.S3_BETWEEN_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_BETWEEN_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S3_LIMITS_RECORD[i].S3_AND_DISTRICT != null) {
							s3_limits_record.S3_AND_DISTRICT = content.S3_LIMITS_RECORD[i].S3_AND_DISTRICT[0].Value;
							if (s3_limits_record.S3_AND_DISTRICT != null) {
								if (s3_limits_record.S3_AND_DISTRICT.Length < 1 || s3_limits_record.S3_AND_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S3_AND_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s3_limits_record.S3_AND_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_AND_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S3_LIMITS_RECORD[i].S3_AND_MILEPOST != null) {
							s3_limits_record.S3_AND_MILEPOST = content.S3_LIMITS_RECORD[i].S3_AND_MILEPOST[0].Value;
							if (s3_limits_record.S3_AND_MILEPOST != null) {
								if (s3_limits_record.S3_AND_MILEPOST.Length < 1 || s3_limits_record.S3_AND_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S3_AND_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s3_limits_record.S3_AND_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_AND_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S3_LIMITS_RECORD[i].S3_TRACK != null) {
							s3_limits_record.S3_TRACK = content.S3_LIMITS_RECORD[i].S3_TRACK[0].Value;
							if (s3_limits_record.S3_TRACK != null) {
								if (s3_limits_record.S3_TRACK.Length < 1 || s3_limits_record.S3_TRACK.Length > 32) {
									Ranorex.Report.Failure("Field S3_TRACK expected to be length between or equal to 1 and 32, has length of {" + s3_limits_record.S3_TRACK.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S3_TRACK is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS3_LIMITS_RECORD(s3_limits_record);
					}
				}

				if (content.S4_PRESENCE != null) {
					messagecontent.S4_PRESENCE = content.S4_PRESENCE[0].Value;
					if (messagecontent.S4_PRESENCE != null) {
						if (messagecontent.S4_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S4_PRESENCE expected to be length of 1, has length of {" + messagecontent.S4_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S4_PRESENCE)) {
							Ranorex.Report.Failure("Field S4_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S4_PRESENCE + "}.");
						}
						if (messagecontent.S4_PRESENCE != "Y" && messagecontent.S4_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S4_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S4_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S4_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S4_FROM_LOCATION != null) {
					messagecontent.S4_FROM_LOCATION = content.S4_FROM_LOCATION[0].Value;
					if (messagecontent.S4_FROM_LOCATION != null) {
						if (messagecontent.S4_FROM_LOCATION.Length < 1 || messagecontent.S4_FROM_LOCATION.Length > 37) {
							Ranorex.Report.Failure("Field S4_FROM_LOCATION expected to be length between or equal to 1 and 37, has length of {" + messagecontent.S4_FROM_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S4_COUNT != null) {
					messagecontent.S4_COUNT = content.S4_COUNT[0].Value;
					if (messagecontent.S4_COUNT != null) {
						if (messagecontent.S4_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S4_COUNT expected to be length of 1, has length of {" + messagecontent.S4_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S4_COUNT)) {
							Ranorex.Report.Failure("Field S4_COUNT expected to be Numeric, has value of {" + messagecontent.S4_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S4_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field S4_COUNT expected to have value between 1 and 3, but was found to have a value of " + messagecontent.S4_COUNT + ".");
							}
						}
					}
				}
				if (content.S4_RECORD != null) {
					for (int i = 0; i < content.S4_RECORD.Length; i++) {
						PTC_DG_TAUTS4_RECORD_7 s4_record = new PTC_DG_TAUTS4_RECORD_7();

						if (content.S4_RECORD[i].S4_SEQUENCE != null) {
							s4_record.S4_SEQUENCE = content.S4_RECORD[i].S4_SEQUENCE[0].Value;
							if (s4_record.S4_SEQUENCE != null) {
								if (s4_record.S4_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S4_SEQUENCE expected to be length of 1, has length of {" + s4_record.S4_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s4_record.S4_SEQUENCE)) {
									Ranorex.Report.Failure("Field S4_SEQUENCE expected to be Numeric, has value of {" + s4_record.S4_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s4_record.S4_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S4_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s4_record.S4_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_RECORD[i].S4_TO_LOCATION != null) {
							s4_record.S4_TO_LOCATION = content.S4_RECORD[i].S4_TO_LOCATION[0].Value;
							if (s4_record.S4_TO_LOCATION != null) {
								if (s4_record.S4_TO_LOCATION.Length < 1 || s4_record.S4_TO_LOCATION.Length > 24) {
									Ranorex.Report.Failure("Field S4_TO_LOCATION expected to be length between or equal to 1 and 24, has length of {" + s4_record.S4_TO_LOCATION.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_TO_LOCATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_RECORD[i].S4_TRACK_TEXT != null) {
							s4_record.S4_TRACK_TEXT = content.S4_RECORD[i].S4_TRACK_TEXT[0].Value;
							if (s4_record.S4_TRACK_TEXT != null) {
								if (s4_record.S4_TRACK_TEXT.Length < 1 || s4_record.S4_TRACK_TEXT.Length > 32) {
									Ranorex.Report.Failure("Field S4_TRACK_TEXT expected to be length between or equal to 1 and 32, has length of {" + s4_record.S4_TRACK_TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_TRACK_TEXT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS4_RECORD(s4_record);
					}
				}

				if (content.S4_LIMITS_COUNT != null) {
					messagecontent.S4_LIMITS_COUNT = content.S4_LIMITS_COUNT[0].Value;
					if (messagecontent.S4_LIMITS_COUNT != null) {
						if (messagecontent.S4_LIMITS_COUNT.Length < 1 || messagecontent.S4_LIMITS_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field S4_LIMITS_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.S4_LIMITS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S4_LIMITS_COUNT)) {
							Ranorex.Report.Failure("Field S4_LIMITS_COUNT expected to be Numeric, has value of {" + messagecontent.S4_LIMITS_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S4_LIMITS_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field S4_LIMITS_COUNT expected to have value between 0 and 99, but was found to have a value of " + messagecontent.S4_LIMITS_COUNT + ".");
							}
						}
					}
				}
				if (content.S4_LIMITS_RECORD != null) {
					for (int i = 0; i < content.S4_LIMITS_RECORD.Length; i++) {
						PTC_DG_TAUTS4_LIMITS_RECORD_7 s4_limits_record = new PTC_DG_TAUTS4_LIMITS_RECORD_7();

						if (content.S4_LIMITS_RECORD[i].S4_FROM_DISTRICT != null) {
							s4_limits_record.S4_FROM_DISTRICT = content.S4_LIMITS_RECORD[i].S4_FROM_DISTRICT[0].Value;
							if (s4_limits_record.S4_FROM_DISTRICT != null) {
								if (s4_limits_record.S4_FROM_DISTRICT.Length < 1 || s4_limits_record.S4_FROM_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S4_FROM_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s4_limits_record.S4_FROM_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_FROM_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_LIMITS_RECORD[i].S4_FROM_MILEPOST != null) {
							s4_limits_record.S4_FROM_MILEPOST = content.S4_LIMITS_RECORD[i].S4_FROM_MILEPOST[0].Value;
							if (s4_limits_record.S4_FROM_MILEPOST != null) {
								if (s4_limits_record.S4_FROM_MILEPOST.Length < 1 || s4_limits_record.S4_FROM_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S4_FROM_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s4_limits_record.S4_FROM_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_FROM_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_LIMITS_RECORD[i].S4_TO_DISTRICT != null) {
							s4_limits_record.S4_TO_DISTRICT = content.S4_LIMITS_RECORD[i].S4_TO_DISTRICT[0].Value;
							if (s4_limits_record.S4_TO_DISTRICT != null) {
								if (s4_limits_record.S4_TO_DISTRICT.Length < 1 || s4_limits_record.S4_TO_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S4_TO_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s4_limits_record.S4_TO_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_TO_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_LIMITS_RECORD[i].S4_TO_MILEPOST != null) {
							s4_limits_record.S4_TO_MILEPOST = content.S4_LIMITS_RECORD[i].S4_TO_MILEPOST[0].Value;
							if (s4_limits_record.S4_TO_MILEPOST != null) {
								if (s4_limits_record.S4_TO_MILEPOST.Length < 1 || s4_limits_record.S4_TO_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S4_TO_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s4_limits_record.S4_TO_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_TO_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S4_LIMITS_RECORD[i].S4_TRACK != null) {
							s4_limits_record.S4_TRACK = content.S4_LIMITS_RECORD[i].S4_TRACK[0].Value;
							if (s4_limits_record.S4_TRACK != null) {
								if (s4_limits_record.S4_TRACK.Length < 1 || s4_limits_record.S4_TRACK.Length > 32) {
									Ranorex.Report.Failure("Field S4_TRACK expected to be length between or equal to 1 and 32, has length of {" + s4_limits_record.S4_TRACK.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S4_TRACK is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS4_LIMITS_RECORD(s4_limits_record);
					}
				}

				if (content.S5_PRESENCE != null) {
					messagecontent.S5_PRESENCE = content.S5_PRESENCE[0].Value;
					if (messagecontent.S5_PRESENCE != null) {
						if (messagecontent.S5_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S5_PRESENCE expected to be length of 1, has length of {" + messagecontent.S5_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S5_PRESENCE)) {
							Ranorex.Report.Failure("Field S5_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S5_PRESENCE + "}.");
						}
						if (messagecontent.S5_PRESENCE != "Y" && messagecontent.S5_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S5_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S5_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S5_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S5_INITAL_UNTIL_DATE != null) {
					messagecontent.S5_INITAL_UNTIL_DATE = content.S5_INITAL_UNTIL_DATE[0].Value;
					if (messagecontent.S5_INITAL_UNTIL_DATE != null) {
						if (messagecontent.S5_INITAL_UNTIL_DATE.Length != 8) {
							Ranorex.Report.Failure("Field S5_INITAL_UNTIL_DATE expected to be length of 8, has length of {" + messagecontent.S5_INITAL_UNTIL_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S5_INITAL_UNTIL_DATE)) {
							Ranorex.Report.Failure("Field S5_INITAL_UNTIL_DATE expected to be Numeric, has value of {" + messagecontent.S5_INITAL_UNTIL_DATE + "}.");
						}
					}
				}

				if (content.S5_INITAL_UNTIL_TIME != null) {
					messagecontent.S5_INITAL_UNTIL_TIME = content.S5_INITAL_UNTIL_TIME[0].Value;
					if (messagecontent.S5_INITAL_UNTIL_TIME != null) {
						if (messagecontent.S5_INITAL_UNTIL_TIME.Length != 4) {
							Ranorex.Report.Failure("Field S5_INITAL_UNTIL_TIME expected to be length of 4, has length of {" + messagecontent.S5_INITAL_UNTIL_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S5_INITAL_UNTIL_TIME)) {
							Ranorex.Report.Failure("Field S5_INITAL_UNTIL_TIME expected to be Numeric, has value of {" + messagecontent.S5_INITAL_UNTIL_TIME + "}.");
						}
					}
				}

				if (content.S5_EXTENDED_UNTIL_DATE != null) {
					messagecontent.S5_EXTENDED_UNTIL_DATE = content.S5_EXTENDED_UNTIL_DATE[0].Value;
					if (messagecontent.S5_EXTENDED_UNTIL_DATE != null) {
						if (messagecontent.S5_EXTENDED_UNTIL_DATE.Length != 8) {
							Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL_DATE expected to be length of 8, has length of {" + messagecontent.S5_EXTENDED_UNTIL_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S5_EXTENDED_UNTIL_DATE)) {
							Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL_DATE expected to be Numeric, has value of {" + messagecontent.S5_EXTENDED_UNTIL_DATE + "}.");
						}
					}
				}

				if (content.S5_EXTENDED_UNTIL_TIME != null) {
					messagecontent.S5_EXTENDED_UNTIL_TIME = content.S5_EXTENDED_UNTIL_TIME[0].Value;
					if (messagecontent.S5_EXTENDED_UNTIL_TIME != null) {
						if (messagecontent.S5_EXTENDED_UNTIL_TIME.Length != 4) {
							Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL_TIME expected to be length of 4, has length of {" + messagecontent.S5_EXTENDED_UNTIL_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S5_EXTENDED_UNTIL_TIME)) {
							Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL_TIME expected to be Numeric, has value of {" + messagecontent.S5_EXTENDED_UNTIL_TIME + "}.");
						}
					}
				}

				if (content.S5_INITIAL_UNTIL != null) {
					messagecontent.S5_INITIAL_UNTIL = content.S5_INITIAL_UNTIL[0].Value;
					if (messagecontent.S5_INITIAL_UNTIL != null) {
						if (messagecontent.S5_INITIAL_UNTIL.Length != 8) {
							Ranorex.Report.Failure("Field S5_INITIAL_UNTIL expected to be length of 8, has length of {" + messagecontent.S5_INITIAL_UNTIL.Length.ToString() + "}.");
						}
					}
				}

				if (content.S5_COUNT != null) {
					messagecontent.S5_COUNT = content.S5_COUNT[0].Value;
					if (messagecontent.S5_COUNT != null) {
						if (messagecontent.S5_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S5_COUNT expected to be length of 1, has length of {" + messagecontent.S5_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S5_COUNT)) {
							Ranorex.Report.Failure("Field S5_COUNT expected to be Numeric, has value of {" + messagecontent.S5_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S5_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field S5_COUNT expected to have value between 0 and 3, but was found to have a value of " + messagecontent.S5_COUNT + ".");
							}
						}
					}
				}
				if (content.S5_RECORD != null) {
					for (int i = 0; i < content.S5_RECORD.Length; i++) {
						PTC_DG_TAUTS5_RECORD_7 s5_record = new PTC_DG_TAUTS5_RECORD_7();

						if (content.S5_RECORD[i].S5_SEQUENCE != null) {
							s5_record.S5_SEQUENCE = content.S5_RECORD[i].S5_SEQUENCE[0].Value;
							if (s5_record.S5_SEQUENCE != null) {
								if (s5_record.S5_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S5_SEQUENCE expected to be length of 1, has length of {" + s5_record.S5_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s5_record.S5_SEQUENCE)) {
									Ranorex.Report.Failure("Field S5_SEQUENCE expected to be Numeric, has value of {" + s5_record.S5_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s5_record.S5_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S5_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s5_record.S5_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S5_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S5_RECORD[i].S5_EXTENDED_UNTIL != null) {
							s5_record.S5_EXTENDED_UNTIL = content.S5_RECORD[i].S5_EXTENDED_UNTIL[0].Value;
							if (s5_record.S5_EXTENDED_UNTIL != null) {
								if (s5_record.S5_EXTENDED_UNTIL.Length != 8) {
									Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL expected to be length of 8, has length of {" + s5_record.S5_EXTENDED_UNTIL.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S5_EXTENDED_UNTIL is a Mandatory field but was found to be missing from the message");
						}

						if (content.S5_RECORD[i].S5_INITIALS != null) {
							s5_record.S5_INITIALS = content.S5_RECORD[i].S5_INITIALS[0].Value;
							if (s5_record.S5_INITIALS != null) {
								if (s5_record.S5_INITIALS.Length < 2 || s5_record.S5_INITIALS.Length > 3) {
									Ranorex.Report.Failure("Field S5_INITIALS expected to be length between or equal to 2 and 3, has length of {" + s5_record.S5_INITIALS.Length.ToString() + "}.");
								}
								if (ContainsDigits(s5_record.S5_INITIALS)) {
									Ranorex.Report.Failure("Field S5_INITIALS expected to be Alphabetic, has value of {" + s5_record.S5_INITIALS + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S5_INITIALS is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS5_RECORD(s5_record);
					}
				}

				if (content.S6_PRESENCE != null) {
					messagecontent.S6_PRESENCE = content.S6_PRESENCE[0].Value;
					if (messagecontent.S6_PRESENCE != null) {
						if (messagecontent.S6_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S6_PRESENCE expected to be length of 1, has length of {" + messagecontent.S6_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S6_PRESENCE)) {
							Ranorex.Report.Failure("Field S6_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S6_PRESENCE + "}.");
						}
						if (messagecontent.S6_PRESENCE != "Y" && messagecontent.S6_PRESENCE != "N" && messagecontent.S6_PRESENCE != "R") {
							Ranorex.Report.Failure("Field S6_PRESENCE expected to be one of the following values {Y, N, R}, but was found to be {" + messagecontent.S6_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S6_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S6_COUNT != null) {
					messagecontent.S6_COUNT = content.S6_COUNT[0].Value;
					if (messagecontent.S6_COUNT != null) {
						if (messagecontent.S6_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S6_COUNT expected to be length of 1, has length of {" + messagecontent.S6_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S6_COUNT)) {
							Ranorex.Report.Failure("Field S6_COUNT expected to be Numeric, has value of {" + messagecontent.S6_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S6_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field S6_COUNT expected to have value between 1 and 3, but was found to have a value of " + messagecontent.S6_COUNT + ".");
							}
						}
					}
				}
				if (content.S6_RECORD != null) {
					for (int i = 0; i < content.S6_RECORD.Length; i++) {
						PTC_DG_TAUTS6_RECORD_7 s6_record = new PTC_DG_TAUTS6_RECORD_7();

						if (content.S6_RECORD[i].S6_SEQUENCE != null) {
							s6_record.S6_SEQUENCE = content.S6_RECORD[i].S6_SEQUENCE[0].Value;
							if (s6_record.S6_SEQUENCE != null) {
								if (s6_record.S6_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S6_SEQUENCE expected to be length of 1, has length of {" + s6_record.S6_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s6_record.S6_SEQUENCE)) {
									Ranorex.Report.Failure("Field S6_SEQUENCE expected to be Numeric, has value of {" + s6_record.S6_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s6_record.S6_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S6_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s6_record.S6_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S6_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S6_RECORD[i].S6_ENGINE_INITIAL != null) {
							s6_record.S6_ENGINE_INITIAL = content.S6_RECORD[i].S6_ENGINE_INITIAL[0].Value;
							if (s6_record.S6_ENGINE_INITIAL != null) {
								if (s6_record.S6_ENGINE_INITIAL.Length < 1 || s6_record.S6_ENGINE_INITIAL.Length > 4) {
									Ranorex.Report.Failure("Field S6_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + s6_record.S6_ENGINE_INITIAL.Length.ToString() + "}.");
								}
								if (ContainsDigits(s6_record.S6_ENGINE_INITIAL)) {
									Ranorex.Report.Failure("Field S6_ENGINE_INITIAL expected to be Alphabetic, has value of {" + s6_record.S6_ENGINE_INITIAL + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S6_ENGINE_INITIAL is a Mandatory field but was found to be missing from the message");
						}

						if (content.S6_RECORD[i].S6_ENGINE_NUMBER != null) {
							s6_record.S6_ENGINE_NUMBER = content.S6_RECORD[i].S6_ENGINE_NUMBER[0].Value;
							if (s6_record.S6_ENGINE_NUMBER != null) {
								if (s6_record.S6_ENGINE_NUMBER.Length < 1 || s6_record.S6_ENGINE_NUMBER.Length > 10) {
									Ranorex.Report.Failure("Field S6_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + s6_record.S6_ENGINE_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s6_record.S6_ENGINE_NUMBER)) {
									Ranorex.Report.Failure("Field S6_ENGINE_NUMBER expected to be Numeric, has value of {" + s6_record.S6_ENGINE_NUMBER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S6_ENGINE_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.S6_RECORD[i].S6_ENGINE_ID != null) {
							s6_record.S6_ENGINE_ID = content.S6_RECORD[i].S6_ENGINE_ID[0].Value;
							if (s6_record.S6_ENGINE_ID != null) {
								if (s6_record.S6_ENGINE_ID.Length < 3 || s6_record.S6_ENGINE_ID.Length > 15) {
									Ranorex.Report.Failure("Field S6_ENGINE_ID expected to be length between or equal to 3 and 15, has length of {" + s6_record.S6_ENGINE_ID.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S6_ENGINE_ID is a Mandatory field but was found to be missing from the message");
						}

						if (content.S6_RECORD[i].S6_DIRECTION != null) {
							s6_record.S6_DIRECTION = content.S6_RECORD[i].S6_DIRECTION[0].Value;
							if (s6_record.S6_DIRECTION != null) {
								if (s6_record.S6_DIRECTION.Length < 4 || s6_record.S6_DIRECTION.Length > 5) {
									Ranorex.Report.Failure("Field S6_DIRECTION expected to be length between or equal to 4 and 5, has length of {" + s6_record.S6_DIRECTION.Length.ToString() + "}.");
								}
								if (ContainsDigits(s6_record.S6_DIRECTION)) {
									Ranorex.Report.Failure("Field S6_DIRECTION expected to be Alphabetic, has value of {" + s6_record.S6_DIRECTION + "}.");
								}
								if (s6_record.S6_DIRECTION != "NORTH" && s6_record.S6_DIRECTION != "SOUTH" && s6_record.S6_DIRECTION != "EAST" && s6_record.S6_DIRECTION != "WEST") {
									Ranorex.Report.Failure("Field S6_DIRECTION expected to be one of the following values {NORTH, SOUTH, EAST, WEST}, but was found to be {" + s6_record.S6_DIRECTION + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S6_DIRECTION is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS6_RECORD(s6_record);
					}
				}

				if (content.S6_AT_DISTRICT != null) {
					messagecontent.S6_AT_DISTRICT = content.S6_AT_DISTRICT[0].Value;
					if (messagecontent.S6_AT_DISTRICT != null) {
						if (messagecontent.S6_AT_DISTRICT.Length < 1 || messagecontent.S6_AT_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field S6_AT_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.S6_AT_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.S6_AT_TRACK != null) {
					messagecontent.S6_AT_TRACK = content.S6_AT_TRACK[0].Value;
					if (messagecontent.S6_AT_TRACK != null) {
						if (messagecontent.S6_AT_TRACK.Length < 1 || messagecontent.S6_AT_TRACK.Length > 32) {
							Ranorex.Report.Failure("Field S6_AT_TRACK expected to be length between or equal to 1 and 32, has length of {" + messagecontent.S6_AT_TRACK.Length.ToString() + "}.");
						}
					}
				}

				if (content.S6_AT_MILEPOST != null) {
					messagecontent.S6_AT_MILEPOST = content.S6_AT_MILEPOST[0].Value;
					if (messagecontent.S6_AT_MILEPOST != null) {
						if (messagecontent.S6_AT_MILEPOST.Length < 1 || messagecontent.S6_AT_MILEPOST.Length > 11) {
							Ranorex.Report.Failure("Field S6_AT_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + messagecontent.S6_AT_MILEPOST.Length.ToString() + "}.");
						}
					}
				}

				if (content.S6_AT_LOCATION != null) {
					messagecontent.S6_AT_LOCATION = content.S6_AT_LOCATION[0].Value;
					if (messagecontent.S6_AT_LOCATION != null) {
						if (messagecontent.S6_AT_LOCATION.Length < 1 || messagecontent.S6_AT_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S6_AT_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S6_AT_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S7_PRESENCE != null) {
					messagecontent.S7_PRESENCE = content.S7_PRESENCE[0].Value;
					if (messagecontent.S7_PRESENCE != null) {
						if (messagecontent.S7_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S7_PRESENCE expected to be length of 1, has length of {" + messagecontent.S7_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S7_PRESENCE)) {
							Ranorex.Report.Failure("Field S7_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S7_PRESENCE + "}.");
						}
						if (messagecontent.S7_PRESENCE != "Y" && messagecontent.S7_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S7_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S7_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S7_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S8_PRESENCE != null) {
					messagecontent.S8_PRESENCE = content.S8_PRESENCE[0].Value;
					if (messagecontent.S8_PRESENCE != null) {
						if (messagecontent.S8_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S8_PRESENCE expected to be length of 1, has length of {" + messagecontent.S8_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S8_PRESENCE)) {
							Ranorex.Report.Failure("Field S8_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S8_PRESENCE + "}.");
						}
						if (messagecontent.S8_PRESENCE != "Y" && messagecontent.S8_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S8_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S8_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S8_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S8_COUNT != null) {
					messagecontent.S8_COUNT = content.S8_COUNT[0].Value;
					if (messagecontent.S8_COUNT != null) {
						if (messagecontent.S8_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S8_COUNT expected to be length of 1, has length of {" + messagecontent.S8_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S8_COUNT)) {
							Ranorex.Report.Failure("Field S8_COUNT expected to be Numeric, has value of {" + messagecontent.S8_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S8_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field S8_COUNT expected to have value between 1 and 3, but was found to have a value of " + messagecontent.S8_COUNT + ".");
							}
						}
					}
				}
				if (content.S8_RECORD != null) {
					for (int i = 0; i < content.S8_RECORD.Length; i++) {
						PTC_DG_TAUTS8_RECORD_7 s8_record = new PTC_DG_TAUTS8_RECORD_7();

						if (content.S8_RECORD[i].S8_SEQUENCE != null) {
							s8_record.S8_SEQUENCE = content.S8_RECORD[i].S8_SEQUENCE[0].Value;
							if (s8_record.S8_SEQUENCE != null) {
								if (s8_record.S8_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S8_SEQUENCE expected to be length of 1, has length of {" + s8_record.S8_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s8_record.S8_SEQUENCE)) {
									Ranorex.Report.Failure("Field S8_SEQUENCE expected to be Numeric, has value of {" + s8_record.S8_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s8_record.S8_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S8_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s8_record.S8_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S8_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S8_RECORD[i].S8_ENGINE_INITIAL != null) {
							s8_record.S8_ENGINE_INITIAL = content.S8_RECORD[i].S8_ENGINE_INITIAL[0].Value;
							if (s8_record.S8_ENGINE_INITIAL != null) {
								if (s8_record.S8_ENGINE_INITIAL.Length < 1 || s8_record.S8_ENGINE_INITIAL.Length > 4) {
									Ranorex.Report.Failure("Field S8_ENGINE_INITIAL expected to be length between or equal to 1 and 4, has length of {" + s8_record.S8_ENGINE_INITIAL.Length.ToString() + "}.");
								}
								if (ContainsDigits(s8_record.S8_ENGINE_INITIAL)) {
									Ranorex.Report.Failure("Field S8_ENGINE_INITIAL expected to be Alphabetic, has value of {" + s8_record.S8_ENGINE_INITIAL + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S8_ENGINE_INITIAL is a Mandatory field but was found to be missing from the message");
						}

						if (content.S8_RECORD[i].S8_ENGINE_NUMBER != null) {
							s8_record.S8_ENGINE_NUMBER = content.S8_RECORD[i].S8_ENGINE_NUMBER[0].Value;
							if (s8_record.S8_ENGINE_NUMBER != null) {
								if (s8_record.S8_ENGINE_NUMBER.Length < 1 || s8_record.S8_ENGINE_NUMBER.Length > 10) {
									Ranorex.Report.Failure("Field S8_ENGINE_NUMBER expected to be length between or equal to 1 and 10, has length of {" + s8_record.S8_ENGINE_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s8_record.S8_ENGINE_NUMBER)) {
									Ranorex.Report.Failure("Field S8_ENGINE_NUMBER expected to be Numeric, has value of {" + s8_record.S8_ENGINE_NUMBER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S8_ENGINE_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.S8_RECORD[i].S8_ENGINE_ID != null) {
							s8_record.S8_ENGINE_ID = content.S8_RECORD[i].S8_ENGINE_ID[0].Value;
							if (s8_record.S8_ENGINE_ID != null) {
								if (s8_record.S8_ENGINE_ID.Length < 3 || s8_record.S8_ENGINE_ID.Length > 15) {
									Ranorex.Report.Failure("Field S8_ENGINE_ID expected to be length between or equal to 3 and 15, has length of {" + s8_record.S8_ENGINE_ID.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S8_ENGINE_ID is a Mandatory field but was found to be missing from the message");
						}

						if (content.S8_RECORD[i].S8_DIRECTION != null) {
							s8_record.S8_DIRECTION = content.S8_RECORD[i].S8_DIRECTION[0].Value;
							if (s8_record.S8_DIRECTION != null) {
								if (s8_record.S8_DIRECTION.Length < 4 || s8_record.S8_DIRECTION.Length > 5) {
									Ranorex.Report.Failure("Field S8_DIRECTION expected to be length between or equal to 4 and 5, has length of {" + s8_record.S8_DIRECTION.Length.ToString() + "}.");
								}
								if (ContainsDigits(s8_record.S8_DIRECTION)) {
									Ranorex.Report.Failure("Field S8_DIRECTION expected to be Alphabetic, has value of {" + s8_record.S8_DIRECTION + "}.");
								}
								if (s8_record.S8_DIRECTION != "NORTH" && s8_record.S8_DIRECTION != "SOUTH" && s8_record.S8_DIRECTION != "EAST" && s8_record.S8_DIRECTION != "WEST") {
									Ranorex.Report.Failure("Field S8_DIRECTION expected to be one of the following values {NORTH, SOUTH, EAST, WEST}, but was found to be {" + s8_record.S8_DIRECTION + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S8_DIRECTION is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addS8_RECORD(s8_record);
					}
				}

				if (content.S9_PRESENCE != null) {
					messagecontent.S9_PRESENCE = content.S9_PRESENCE[0].Value;
					if (messagecontent.S9_PRESENCE != null) {
						if (messagecontent.S9_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S9_PRESENCE expected to be length of 1, has length of {" + messagecontent.S9_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S9_PRESENCE)) {
							Ranorex.Report.Failure("Field S9_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S9_PRESENCE + "}.");
						}
						if (messagecontent.S9_PRESENCE != "Y" && messagecontent.S9_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S9_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S9_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S9_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S10_PRESENCE != null) {
					messagecontent.S10_PRESENCE = content.S10_PRESENCE[0].Value;
					if (messagecontent.S10_PRESENCE != null) {
						if (messagecontent.S10_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S10_PRESENCE expected to be length of 1, has length of {" + messagecontent.S10_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S10_PRESENCE)) {
							Ranorex.Report.Failure("Field S10_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S10_PRESENCE + "}.");
						}
						if (messagecontent.S10_PRESENCE != "Y" && messagecontent.S10_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S10_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S10_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S10_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S10_BETWEEN_LOCATION != null) {
					messagecontent.S10_BETWEEN_LOCATION = content.S10_BETWEEN_LOCATION[0].Value;
					if (messagecontent.S10_BETWEEN_LOCATION != null) {
						if (messagecontent.S10_BETWEEN_LOCATION.Length < 1 || messagecontent.S10_BETWEEN_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S10_BETWEEN_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S10_BETWEEN_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S10_AND_LOCATION != null) {
					messagecontent.S10_AND_LOCATION = content.S10_AND_LOCATION[0].Value;
					if (messagecontent.S10_AND_LOCATION != null) {
						if (messagecontent.S10_AND_LOCATION.Length < 1 || messagecontent.S10_AND_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S10_AND_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S10_AND_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S10_COUNT != null) {
					messagecontent.S10_COUNT = content.S10_COUNT[0].Value;
					if (messagecontent.S10_COUNT != null) {
						if (messagecontent.S10_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S10_COUNT expected to be length of 1, has length of {" + messagecontent.S10_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S10_COUNT)) {
							Ranorex.Report.Failure("Field S10_COUNT expected to be Numeric, has value of {" + messagecontent.S10_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S10_COUNT);
							if (intConvertedValue < 0 || intConvertedValue > 8) {
								Ranorex.Report.Failure("Field S10_COUNT expected to have value between 0 and 8, but was found to have a value of " + messagecontent.S10_COUNT + ".");
							}
						}
					}
				}
				if (content.S10_RECORD != null) {
					for (int i = 0; i < content.S10_RECORD.Length; i++) {
						PTC_DG_TAUTS10_RECORD_7 s10_record = new PTC_DG_TAUTS10_RECORD_7();

						if (content.S10_RECORD[i].S10_BETWEEN_DISTRICT != null) {
							s10_record.S10_BETWEEN_DISTRICT = content.S10_RECORD[i].S10_BETWEEN_DISTRICT[0].Value;
							if (s10_record.S10_BETWEEN_DISTRICT != null) {
								if (s10_record.S10_BETWEEN_DISTRICT.Length < 1 || s10_record.S10_BETWEEN_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S10_BETWEEN_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s10_record.S10_BETWEEN_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S10_BETWEEN_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S10_RECORD[i].S10_BETWEEN_MILEPOST != null) {
							s10_record.S10_BETWEEN_MILEPOST = content.S10_RECORD[i].S10_BETWEEN_MILEPOST[0].Value;
							if (s10_record.S10_BETWEEN_MILEPOST != null) {
								if (s10_record.S10_BETWEEN_MILEPOST.Length < 1 || s10_record.S10_BETWEEN_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S10_BETWEEN_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s10_record.S10_BETWEEN_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S10_BETWEEN_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S10_RECORD[i].S10_AND_DISTRICT != null) {
							s10_record.S10_AND_DISTRICT = content.S10_RECORD[i].S10_AND_DISTRICT[0].Value;
							if (s10_record.S10_AND_DISTRICT != null) {
								if (s10_record.S10_AND_DISTRICT.Length < 1 || s10_record.S10_AND_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field S10_AND_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s10_record.S10_AND_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S10_AND_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S10_RECORD[i].S10_AND_MILEPOST != null) {
							s10_record.S10_AND_MILEPOST = content.S10_RECORD[i].S10_AND_MILEPOST[0].Value;
							if (s10_record.S10_AND_MILEPOST != null) {
								if (s10_record.S10_AND_MILEPOST.Length < 1 || s10_record.S10_AND_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field S10_AND_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s10_record.S10_AND_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S10_AND_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.S10_RECORD[i].S10_TRACK != null) {
							s10_record.S10_TRACK = content.S10_RECORD[i].S10_TRACK[0].Value;
							if (s10_record.S10_TRACK != null) {
								if (s10_record.S10_TRACK.Length < 1 || s10_record.S10_TRACK.Length > 32) {
									Ranorex.Report.Failure("Field S10_TRACK expected to be length between or equal to 1 and 32, has length of {" + s10_record.S10_TRACK.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addS10_RECORD(s10_record);
					}
				}

				if (content.S11_PRESENCE != null) {
					messagecontent.S11_PRESENCE = content.S11_PRESENCE[0].Value;
					if (messagecontent.S11_PRESENCE != null) {
						if (messagecontent.S11_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S11_PRESENCE expected to be length of 1, has length of {" + messagecontent.S11_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S11_PRESENCE)) {
							Ranorex.Report.Failure("Field S11_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S11_PRESENCE + "}.");
						}
						if (messagecontent.S11_PRESENCE != "Y" && messagecontent.S11_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S11_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S11_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S11_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S11_DISTRICT != null) {
					messagecontent.S11_DISTRICT = content.S11_DISTRICT[0].Value;
					if (messagecontent.S11_DISTRICT != null) {
						if (messagecontent.S11_DISTRICT.Length < 1 || messagecontent.S11_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field S11_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.S11_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.S11_MILEPOST != null) {
					messagecontent.S11_MILEPOST = content.S11_MILEPOST[0].Value;
					if (messagecontent.S11_MILEPOST != null) {
						if (messagecontent.S11_MILEPOST.Length != 11) {
							Ranorex.Report.Failure("Field S11_MILEPOST expected to be length of 11, has length of {" + messagecontent.S11_MILEPOST.Length.ToString() + "}.");
						}
					}
				}

				if (content.S11_LOCATION != null) {
					messagecontent.S11_LOCATION = content.S11_LOCATION[0].Value;
					if (messagecontent.S11_LOCATION != null) {
						if (messagecontent.S11_LOCATION.Length < 1 || messagecontent.S11_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field S11_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.S11_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.S11_TRACK != null) {
					messagecontent.S11_TRACK = content.S11_TRACK[0].Value;
					if (messagecontent.S11_TRACK != null) {
						if (messagecontent.S11_TRACK.Length < 1 || messagecontent.S11_TRACK.Length > 32) {
							Ranorex.Report.Failure("Field S11_TRACK expected to be length between or equal to 1 and 32, has length of {" + messagecontent.S11_TRACK.Length.ToString() + "}.");
						}
					}
				}

				if (content.S12_PRESENCE != null) {
					messagecontent.S12_PRESENCE = content.S12_PRESENCE[0].Value;
					if (messagecontent.S12_PRESENCE != null) {
						if (messagecontent.S12_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S12_PRESENCE expected to be length of 1, has length of {" + messagecontent.S12_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S12_PRESENCE)) {
							Ranorex.Report.Failure("Field S12_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S12_PRESENCE + "}.");
						}
						if (messagecontent.S12_PRESENCE != "Y" && messagecontent.S12_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S12_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S12_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S12_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S12_COUNT != null) {
					messagecontent.S12_COUNT = content.S12_COUNT[0].Value;
					if (messagecontent.S12_COUNT != null) {
						if (messagecontent.S12_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field S12_COUNT expected to be length of 1, has length of {" + messagecontent.S12_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S12_COUNT)) {
							Ranorex.Report.Failure("Field S12_COUNT expected to be Numeric, has value of {" + messagecontent.S12_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S12_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 3) {
								Ranorex.Report.Failure("Field S12_COUNT expected to have value between 1 and 3, but was found to have a value of " + messagecontent.S12_COUNT + ".");
							}
						}
					}
				}
				if (content.S12_RWIC_RECORD != null) {
					for (int i = 0; i < content.S12_RWIC_RECORD.Length; i++) {
						PTC_DG_TAUTS12_RWIC_RECORD_7 s12_rwic_record = new PTC_DG_TAUTS12_RWIC_RECORD_7();

						if (content.S12_RWIC_RECORD[i].S12_RWIC_SEQUENCE != null) {
							s12_rwic_record.S12_RWIC_SEQUENCE = content.S12_RWIC_RECORD[i].S12_RWIC_SEQUENCE[0].Value;
							if (s12_rwic_record.S12_RWIC_SEQUENCE != null) {
								if (s12_rwic_record.S12_RWIC_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field S12_RWIC_SEQUENCE expected to be length of 1, has length of {" + s12_rwic_record.S12_RWIC_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s12_rwic_record.S12_RWIC_SEQUENCE)) {
									Ranorex.Report.Failure("Field S12_RWIC_SEQUENCE expected to be Numeric, has value of {" + s12_rwic_record.S12_RWIC_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s12_rwic_record.S12_RWIC_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 3) {
										Ranorex.Report.Failure("Field S12_RWIC_SEQUENCE expected to have value between 1 and 3, but was found to have a value of " + s12_rwic_record.S12_RWIC_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_RWIC_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S12_RWIC_RECORD[i].S12_RWIC != null) {
							s12_rwic_record.S12_RWIC = content.S12_RWIC_RECORD[i].S12_RWIC[0].Value;
							if (s12_rwic_record.S12_RWIC != null) {
								if (s12_rwic_record.S12_RWIC.Length < 1 || s12_rwic_record.S12_RWIC.Length > 19) {
									Ranorex.Report.Failure("Field S12_RWIC expected to be length between or equal to 1 and 19, has length of {" + s12_rwic_record.S12_RWIC.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_RWIC is a Mandatory field but was found to be missing from the message");
						}

						if (content.S12_RWIC_RECORD[i].S12_BETWEEN_LOCATION != null) {
							s12_rwic_record.S12_BETWEEN_LOCATION = content.S12_RWIC_RECORD[i].S12_BETWEEN_LOCATION[0].Value;
							if (s12_rwic_record.S12_BETWEEN_LOCATION != null) {
								if (s12_rwic_record.S12_BETWEEN_LOCATION.Length < 1 || s12_rwic_record.S12_BETWEEN_LOCATION.Length > 24) {
									Ranorex.Report.Failure("Field S12_BETWEEN_LOCATION expected to be length between or equal to 1 and 24, has length of {" + s12_rwic_record.S12_BETWEEN_LOCATION.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_BETWEEN_LOCATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.S12_RWIC_RECORD[i].S12_AND_LOCATION != null) {
							s12_rwic_record.S12_AND_LOCATION = content.S12_RWIC_RECORD[i].S12_AND_LOCATION[0].Value;
							if (s12_rwic_record.S12_AND_LOCATION != null) {
								if (s12_rwic_record.S12_AND_LOCATION.Length < 1 || s12_rwic_record.S12_AND_LOCATION.Length > 24) {
									Ranorex.Report.Failure("Field S12_AND_LOCATION expected to be length between or equal to 1 and 24, has length of {" + s12_rwic_record.S12_AND_LOCATION.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_AND_LOCATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.S12_RWIC_RECORD[i].S12_TRACK_TEXT != null) {
							s12_rwic_record.S12_TRACK_TEXT = content.S12_RWIC_RECORD[i].S12_TRACK_TEXT[0].Value;
							if (s12_rwic_record.S12_TRACK_TEXT != null) {
								if (s12_rwic_record.S12_TRACK_TEXT.Length < 1 || s12_rwic_record.S12_TRACK_TEXT.Length > 32) {
									Ranorex.Report.Failure("Field S12_TRACK_TEXT expected to be length between or equal to 1 and 32, has length of {" + s12_rwic_record.S12_TRACK_TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_TRACK_TEXT is a Mandatory field but was found to be missing from the message");
						}

						if (content.S12_RWIC_RECORD[i].S12_LIMITS_COUNT != null) {
							s12_rwic_record.S12_LIMITS_COUNT = content.S12_RWIC_RECORD[i].S12_LIMITS_COUNT[0].Value;
							if (s12_rwic_record.S12_LIMITS_COUNT != null) {
								if (s12_rwic_record.S12_LIMITS_COUNT.Length < 1 || s12_rwic_record.S12_LIMITS_COUNT.Length > 3) {
									Ranorex.Report.Failure("Field S12_LIMITS_COUNT expected to be length between or equal to 1 and 3, has length of {" + s12_rwic_record.S12_LIMITS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s12_rwic_record.S12_LIMITS_COUNT)) {
									Ranorex.Report.Failure("Field S12_LIMITS_COUNT expected to be Numeric, has value of {" + s12_rwic_record.S12_LIMITS_COUNT + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s12_rwic_record.S12_LIMITS_COUNT);
									if (intConvertedValue < 0 || intConvertedValue > 100) {
										Ranorex.Report.Failure("Field S12_LIMITS_COUNT expected to have value between 0 and 100, but was found to have a value of " + s12_rwic_record.S12_LIMITS_COUNT + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S12_LIMITS_COUNT is a Mandatory field but was found to be missing from the message");
						}
						if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD != null) {
							for (int j = 0; j < content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD.Length; j++) {
								PTC_DG_TAUTS12_LIMITS_RECORD_7 s12_limits_record = new PTC_DG_TAUTS12_LIMITS_RECORD_7();

								if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_BETWEEN_DISTRICT != null) {
									s12_limits_record.S12_BETWEEN_DISTRICT = content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_BETWEEN_DISTRICT[0].Value;
									if (s12_limits_record.S12_BETWEEN_DISTRICT != null) {
										if (s12_limits_record.S12_BETWEEN_DISTRICT.Length < 1 || s12_limits_record.S12_BETWEEN_DISTRICT.Length > 25) {
											Ranorex.Report.Failure("Field S12_BETWEEN_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s12_limits_record.S12_BETWEEN_DISTRICT.Length.ToString() + "}.");
										}
									}
								} else {
									Ranorex.Report.Failure("Field S12_BETWEEN_DISTRICT is a Mandatory field but was found to be missing from the message");
								}

								if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_BETWEEN_MILEPOST != null) {
									s12_limits_record.S12_BETWEEN_MILEPOST = content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_BETWEEN_MILEPOST[0].Value;
									if (s12_limits_record.S12_BETWEEN_MILEPOST != null) {
										if (s12_limits_record.S12_BETWEEN_MILEPOST.Length < 1 || s12_limits_record.S12_BETWEEN_MILEPOST.Length > 11) {
											Ranorex.Report.Failure("Field S12_BETWEEN_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s12_limits_record.S12_BETWEEN_MILEPOST.Length.ToString() + "}.");
										}
									}
								} else {
									Ranorex.Report.Failure("Field S12_BETWEEN_MILEPOST is a Mandatory field but was found to be missing from the message");
								}

								if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_AND_DISTRICT != null) {
									s12_limits_record.S12_AND_DISTRICT = content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_AND_DISTRICT[0].Value;
									if (s12_limits_record.S12_AND_DISTRICT != null) {
										if (s12_limits_record.S12_AND_DISTRICT.Length < 1 || s12_limits_record.S12_AND_DISTRICT.Length > 25) {
											Ranorex.Report.Failure("Field S12_AND_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + s12_limits_record.S12_AND_DISTRICT.Length.ToString() + "}.");
										}
									}
								} else {
									Ranorex.Report.Failure("Field S12_AND_DISTRICT is a Mandatory field but was found to be missing from the message");
								}

								if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_AND_MILEPOST != null) {
									s12_limits_record.S12_AND_MILEPOST = content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_AND_MILEPOST[0].Value;
									if (s12_limits_record.S12_AND_MILEPOST != null) {
										if (s12_limits_record.S12_AND_MILEPOST.Length < 1 || s12_limits_record.S12_AND_MILEPOST.Length > 11) {
											Ranorex.Report.Failure("Field S12_AND_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + s12_limits_record.S12_AND_MILEPOST.Length.ToString() + "}.");
										}
									}
								} else {
									Ranorex.Report.Failure("Field S12_AND_MILEPOST is a Mandatory field but was found to be missing from the message");
								}

								if (content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_TRACK != null) {
									s12_limits_record.S12_TRACK = content.S12_RWIC_RECORD[i].S12_LIMITS_RECORD[j].S12_TRACK[0].Value;
									if (s12_limits_record.S12_TRACK != null) {
										if (s12_limits_record.S12_TRACK.Length < 1 || s12_limits_record.S12_TRACK.Length > 32) {
											Ranorex.Report.Failure("Field S12_TRACK expected to be length between or equal to 1 and 32, has length of {" + s12_limits_record.S12_TRACK.Length.ToString() + "}.");
										}
									}
								} else {
									Ranorex.Report.Failure("Field S12_TRACK is a Mandatory field but was found to be missing from the message");
								}

								s12_rwic_record.addS12_LIMITS_RECORD(s12_limits_record);
							}
						}

						messagecontent.addS12_RWIC_RECORD(s12_rwic_record);
					}
				}

				if (content.S13_PRESENCE != null) {
					messagecontent.S13_PRESENCE = content.S13_PRESENCE[0].Value;
					if (messagecontent.S13_PRESENCE != null) {
						if (messagecontent.S13_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field S13_PRESENCE expected to be length of 1, has length of {" + messagecontent.S13_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.S13_PRESENCE)) {
							Ranorex.Report.Failure("Field S13_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.S13_PRESENCE + "}.");
						}
						if (messagecontent.S13_PRESENCE != "Y" && messagecontent.S13_PRESENCE != "N") {
							Ranorex.Report.Failure("Field S13_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.S13_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field S13_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.S13_COUNT != null) {
					messagecontent.S13_COUNT = content.S13_COUNT[0].Value;
					if (messagecontent.S13_COUNT != null) {
						if (messagecontent.S13_COUNT.Length < 1 || messagecontent.S13_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field S13_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.S13_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.S13_COUNT)) {
							Ranorex.Report.Failure("Field S13_COUNT expected to be Numeric, has value of {" + messagecontent.S13_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.S13_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 22) {
								Ranorex.Report.Failure("Field S13_COUNT expected to have value between 1 and 22, but was found to have a value of " + messagecontent.S13_COUNT + ".");
							}
						}
					}
				}
				if (content.S13_RECORD != null) {
					for (int i = 0; i < content.S13_RECORD.Length; i++) {
						PTC_DG_TAUTS13_RECORD_7 s13_record = new PTC_DG_TAUTS13_RECORD_7();

						if (content.S13_RECORD[i].S13_SEQUENCE != null) {
							s13_record.S13_SEQUENCE = content.S13_RECORD[i].S13_SEQUENCE[0].Value;
							if (s13_record.S13_SEQUENCE != null) {
								if (s13_record.S13_SEQUENCE.Length < 1 || s13_record.S13_SEQUENCE.Length > 2) {
									Ranorex.Report.Failure("Field S13_SEQUENCE expected to be length between or equal to 1 and 2, has length of {" + s13_record.S13_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(s13_record.S13_SEQUENCE)) {
									Ranorex.Report.Failure("Field S13_SEQUENCE expected to be Numeric, has value of {" + s13_record.S13_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(s13_record.S13_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 22) {
										Ranorex.Report.Failure("Field S13_SEQUENCE expected to have value between 1 and 22, but was found to have a value of " + s13_record.S13_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field S13_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.S13_RECORD[i].S13_TEXT != null) {
							s13_record.S13_TEXT = content.S13_RECORD[i].S13_TEXT[0].Value;
							if (s13_record.S13_TEXT != null) {
								if (s13_record.S13_TEXT.Length < 1 || s13_record.S13_TEXT.Length > 62) {
									Ranorex.Report.Failure("Field S13_TEXT expected to be length between or equal to 1 and 62, has length of {" + s13_record.S13_TEXT.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addS13_RECORD(s13_record);
					}
				}

				if (content.T1_PRESENCE != null) {
					messagecontent.T1_PRESENCE = content.T1_PRESENCE[0].Value;
					if (messagecontent.T1_PRESENCE != null) {
						if (messagecontent.T1_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field T1_PRESENCE expected to be length of 1, has length of {" + messagecontent.T1_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.T1_PRESENCE)) {
							Ranorex.Report.Failure("Field T1_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.T1_PRESENCE + "}.");
						}
						if (messagecontent.T1_PRESENCE != "Y" && messagecontent.T1_PRESENCE != "N") {
							Ranorex.Report.Failure("Field T1_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.T1_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field T1_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.T1_COPIED_BY != null) {
					messagecontent.T1_COPIED_BY = content.T1_COPIED_BY[0].Value;
					if (messagecontent.T1_COPIED_BY != null) {
						if (messagecontent.T1_COPIED_BY.Length < 1 || messagecontent.T1_COPIED_BY.Length > 19) {
							Ranorex.Report.Failure("Field T1_COPIED_BY expected to be length between or equal to 1 and 19, has length of {" + messagecontent.T1_COPIED_BY.Length.ToString() + "}.");
						}
					}
				}

				if (content.T1_OK_TIME != null) {
					messagecontent.T1_OK_TIME = content.T1_OK_TIME[0].Value;
					if (messagecontent.T1_OK_TIME != null) {
						if (messagecontent.T1_OK_TIME.Length != 8) {
							Ranorex.Report.Failure("Field T1_OK_TIME expected to be length of 8, has length of {" + messagecontent.T1_OK_TIME.Length.ToString() + "}.");
						}
					}
				}

				if (content.T1_OK_DATE != null) {
					messagecontent.T1_OK_DATE = content.T1_OK_DATE[0].Value;
					if (messagecontent.T1_OK_DATE != null) {
						if (messagecontent.T1_OK_DATE.Length != 10) {
							Ranorex.Report.Failure("Field T1_OK_DATE expected to be length of 10, has length of {" + messagecontent.T1_OK_DATE.Length.ToString() + "}.");
						}
					}
				}

				if (content.T1_DISPATCHER != null) {
					messagecontent.T1_DISPATCHER = content.T1_DISPATCHER[0].Value;
					if (messagecontent.T1_DISPATCHER != null) {
						if (messagecontent.T1_DISPATCHER.Length < 2 || messagecontent.T1_DISPATCHER.Length > 3) {
							Ranorex.Report.Failure("Field T1_DISPATCHER expected to be length between or equal to 2 and 3, has length of {" + messagecontent.T1_DISPATCHER.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.T1_DISPATCHER)) {
							Ranorex.Report.Failure("Field T1_DISPATCHER expected to be Alphabetic, has value of {" + messagecontent.T1_DISPATCHER + "}.");
						}
					}
				}

				if (content.T1_RELAY_EMPLOYEE != null) {
					messagecontent.T1_RELAY_EMPLOYEE = content.T1_RELAY_EMPLOYEE[0].Value;
					if (messagecontent.T1_RELAY_EMPLOYEE != null) {
						if (messagecontent.T1_RELAY_EMPLOYEE.Length < 1 || messagecontent.T1_RELAY_EMPLOYEE.Length > 19) {
							Ranorex.Report.Failure("Field T1_RELAY_EMPLOYEE expected to be length between or equal to 1 and 19, has length of {" + messagecontent.T1_RELAY_EMPLOYEE.Length.ToString() + "}.");
						}
					}
				}

				if (content.T1_RELAY_LOCATION != null) {
					messagecontent.T1_RELAY_LOCATION = content.T1_RELAY_LOCATION[0].Value;
					if (messagecontent.T1_RELAY_LOCATION != null) {
						if (messagecontent.T1_RELAY_LOCATION.Length < 1 || messagecontent.T1_RELAY_LOCATION.Length > 24) {
							Ranorex.Report.Failure("Field T1_RELAY_LOCATION expected to be length between or equal to 1 and 24, has length of {" + messagecontent.T1_RELAY_LOCATION.Length.ToString() + "}.");
						}
					}
				}

				if (content.T2_PRESENCE != null) {
					messagecontent.T2_PRESENCE = content.T2_PRESENCE[0].Value;
					if (messagecontent.T2_PRESENCE != null) {
						if (messagecontent.T2_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field T2_PRESENCE expected to be length of 1, has length of {" + messagecontent.T2_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.T2_PRESENCE)) {
							Ranorex.Report.Failure("Field T2_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.T2_PRESENCE + "}.");
						}
						if (messagecontent.T2_PRESENCE != "Y" && messagecontent.T2_PRESENCE != "N") {
							Ranorex.Report.Failure("Field T2_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.T2_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field T2_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.T2_DISTRICT != null) {
					messagecontent.T2_DISTRICT = content.T2_DISTRICT[0].Value;
					if (messagecontent.T2_DISTRICT != null) {
						if (messagecontent.T2_DISTRICT.Length < 1 || messagecontent.T2_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field T2_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.T2_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.T2_MILEPOST != null) {
					messagecontent.T2_MILEPOST = content.T2_MILEPOST[0].Value;
					if (messagecontent.T2_MILEPOST != null) {
						if (messagecontent.T2_MILEPOST.Length < 1 || messagecontent.T2_MILEPOST.Length > 11) {
							Ranorex.Report.Failure("Field T2_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + messagecontent.T2_MILEPOST.Length.ToString() + "}.");
						}
					}
				}

				if (content.T2_TRACK != null) {
					messagecontent.T2_TRACK = content.T2_TRACK[0].Value;
					if (messagecontent.T2_TRACK != null) {
						if (messagecontent.T2_TRACK.Length < 1 || messagecontent.T2_TRACK.Length > 32) {
							Ranorex.Report.Failure("Field T2_TRACK expected to be length between or equal to 1 and 32, has length of {" + messagecontent.T2_TRACK.Length.ToString() + "}.");
						}
					}
				}

				if (content.T2_COUNT != null) {
					messagecontent.T2_COUNT = content.T2_COUNT[0].Value;
					if (messagecontent.T2_COUNT != null) {
						if (messagecontent.T2_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field T2_COUNT expected to be length of 1, has length of {" + messagecontent.T2_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.T2_COUNT)) {
							Ranorex.Report.Failure("Field T2_COUNT expected to be Numeric, has value of {" + messagecontent.T2_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.T2_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 5) {
								Ranorex.Report.Failure("Field T2_COUNT expected to have value between 1 and 5, but was found to have a value of " + messagecontent.T2_COUNT + ".");
							}
						}
					}
				}
				if (content.T2_RECORD != null) {
					for (int i = 0; i < content.T2_RECORD.Length; i++) {
						PTC_DG_TAUTT2_RECORD_7 t2_record = new PTC_DG_TAUTT2_RECORD_7();

						if (content.T2_RECORD[i].T2_SEQUENCE != null) {
							t2_record.T2_SEQUENCE = content.T2_RECORD[i].T2_SEQUENCE[0].Value;
							if (t2_record.T2_SEQUENCE != null) {
								if (t2_record.T2_SEQUENCE.Length != 1) {
									Ranorex.Report.Failure("Field T2_SEQUENCE expected to be length of 1, has length of {" + t2_record.T2_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(t2_record.T2_SEQUENCE)) {
									Ranorex.Report.Failure("Field T2_SEQUENCE expected to be Numeric, has value of {" + t2_record.T2_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(t2_record.T2_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 5) {
										Ranorex.Report.Failure("Field T2_SEQUENCE expected to have value between 1 and 5, but was found to have a value of " + t2_record.T2_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field T2_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.T2_RECORD[i].T2_ROLLUP_LOCATION != null) {
							t2_record.T2_ROLLUP_LOCATION = content.T2_RECORD[i].T2_ROLLUP_LOCATION[0].Value;
							if (t2_record.T2_ROLLUP_LOCATION != null) {
								if (t2_record.T2_ROLLUP_LOCATION.Length < 1 || t2_record.T2_ROLLUP_LOCATION.Length > 37) {
									Ranorex.Report.Failure("Field T2_ROLLUP_LOCATION expected to be length between or equal to 1 and 37, has length of {" + t2_record.T2_ROLLUP_LOCATION.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field T2_ROLLUP_LOCATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.T2_RECORD[i].T2_ROLLUP_DATE != null) {
							t2_record.T2_ROLLUP_DATE = content.T2_RECORD[i].T2_ROLLUP_DATE[0].Value;
							if (t2_record.T2_ROLLUP_DATE != null) {
								if (t2_record.T2_ROLLUP_DATE.Length != 10) {
									Ranorex.Report.Failure("Field T2_ROLLUP_DATE expected to be length of 10, has length of {" + t2_record.T2_ROLLUP_DATE.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field T2_ROLLUP_DATE is a Mandatory field but was found to be missing from the message");
						}

						if (content.T2_RECORD[i].T2_ROLLUP_TIME != null) {
							t2_record.T2_ROLLUP_TIME = content.T2_RECORD[i].T2_ROLLUP_TIME[0].Value;
							if (t2_record.T2_ROLLUP_TIME != null) {
								if (t2_record.T2_ROLLUP_TIME.Length != 8) {
									Ranorex.Report.Failure("Field T2_ROLLUP_TIME expected to be length of 8, has length of {" + t2_record.T2_ROLLUP_TIME.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field T2_ROLLUP_TIME is a Mandatory field but was found to be missing from the message");
						}

						if (content.T2_RECORD[i].T2_BY != null) {
							t2_record.T2_BY = content.T2_RECORD[i].T2_BY[0].Value;
							if (t2_record.T2_BY != null) {
								if (t2_record.T2_BY.Length < 2 || t2_record.T2_BY.Length > 3) {
									Ranorex.Report.Failure("Field T2_BY expected to be length between or equal to 2 and 3, has length of {" + t2_record.T2_BY.Length.ToString() + "}.");
								}
								if (ContainsDigits(t2_record.T2_BY)) {
									Ranorex.Report.Failure("Field T2_BY expected to be Alphabetic, has value of {" + t2_record.T2_BY + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field T2_BY is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addT2_RECORD(t2_record);
					}
				}

				if (content.T3_PRESENCE != null) {
					messagecontent.T3_PRESENCE = content.T3_PRESENCE[0].Value;
					if (messagecontent.T3_PRESENCE != null) {
						if (messagecontent.T3_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field T3_PRESENCE expected to be length of 1, has length of {" + messagecontent.T3_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.T3_PRESENCE)) {
							Ranorex.Report.Failure("Field T3_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.T3_PRESENCE + "}.");
						}
						if (messagecontent.T3_PRESENCE != "Y" && messagecontent.T3_PRESENCE != "N") {
							Ranorex.Report.Failure("Field T3_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.T3_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field T3_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.T3_CLEAR_TIME != null) {
					messagecontent.T3_CLEAR_TIME = content.T3_CLEAR_TIME[0].Value;
					if (messagecontent.T3_CLEAR_TIME != null) {
						if (messagecontent.T3_CLEAR_TIME.Length != 8) {
							Ranorex.Report.Failure("Field T3_CLEAR_TIME expected to be length of 8, has length of {" + messagecontent.T3_CLEAR_TIME.Length.ToString() + "}.");
						}
					}
				}

				if (content.T3_CLEAR_BY != null) {
					messagecontent.T3_CLEAR_BY = content.T3_CLEAR_BY[0].Value;
					if (messagecontent.T3_CLEAR_BY != null) {
						if (messagecontent.T3_CLEAR_BY.Length < 1 || messagecontent.T3_CLEAR_BY.Length > 19) {
							Ranorex.Report.Failure("Field T3_CLEAR_BY expected to be length between or equal to 1 and 19, has length of {" + messagecontent.T3_CLEAR_BY.Length.ToString() + "}.");
						}
					}
				}

				if (content.RPT_TEXT_COUNT != null) {
					messagecontent.RPT_TEXT_COUNT = content.RPT_TEXT_COUNT[0].Value;
					if (messagecontent.RPT_TEXT_COUNT != null) {
						if (messagecontent.RPT_TEXT_COUNT.Length < 1 || messagecontent.RPT_TEXT_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field RPT_TEXT_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.RPT_TEXT_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.RPT_TEXT_COUNT)) {
							Ranorex.Report.Failure("Field RPT_TEXT_COUNT expected to be Numeric, has value of {" + messagecontent.RPT_TEXT_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.RPT_TEXT_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 93) {
								Ranorex.Report.Failure("Field RPT_TEXT_COUNT expected to have value between 1 and 93, but was found to have a value of " + messagecontent.RPT_TEXT_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field RPT_TEXT_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.RPT_RECORD != null) {
					for (int i = 0; i < content.RPT_RECORD.Length; i++) {
						PTC_DG_TAUTRPT_RECORD_7 rpt_record = new PTC_DG_TAUTRPT_RECORD_7();

						if (content.RPT_RECORD[i].RPT_SEQUENCE != null) {
							rpt_record.RPT_SEQUENCE = content.RPT_RECORD[i].RPT_SEQUENCE[0].Value;
							if (rpt_record.RPT_SEQUENCE != null) {
								if (rpt_record.RPT_SEQUENCE.Length < 1 || rpt_record.RPT_SEQUENCE.Length > 2) {
									Ranorex.Report.Failure("Field RPT_SEQUENCE expected to be length between or equal to 1 and 2, has length of {" + rpt_record.RPT_SEQUENCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(rpt_record.RPT_SEQUENCE)) {
									Ranorex.Report.Failure("Field RPT_SEQUENCE expected to be Numeric, has value of {" + rpt_record.RPT_SEQUENCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(rpt_record.RPT_SEQUENCE);
									if (intConvertedValue < 1 || intConvertedValue > 93) {
										Ranorex.Report.Failure("Field RPT_SEQUENCE expected to have value between 1 and 93, but was found to have a value of " + rpt_record.RPT_SEQUENCE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field RPT_SEQUENCE is a Mandatory field but was found to be missing from the message");
						}

						if (content.RPT_RECORD[i].RPT_TEXT != null) {
							rpt_record.RPT_TEXT = content.RPT_RECORD[i].RPT_TEXT[0].Value;
							if (rpt_record.RPT_TEXT != null) {
								if (rpt_record.RPT_TEXT.Length < 1 || rpt_record.RPT_TEXT.Length > 67) {
							        // MOlson : 6/26/20 - Changing this to Error until PDS fixes RPT_TEXT length
									Ranorex.Report.Error("Field RPT_TEXT expected to be length between or equal to 1 and 67, has length of {" + rpt_record.RPT_TEXT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field RPT_TEXT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addRPT_RECORD(rpt_record);
					}
				} else {
					Ranorex.Report.Failure("Field RPT_RECORD is a Mandatory field but was found to be missing from the message");
				}

				if (content.R251_LIMIT_PRESENCE != null) {
					messagecontent.R251_LIMIT_PRESENCE = content.R251_LIMIT_PRESENCE[0].Value;
					if (messagecontent.R251_LIMIT_PRESENCE != null) {
						if (messagecontent.R251_LIMIT_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field R251_LIMIT_PRESENCE expected to be length of 1, has length of {" + messagecontent.R251_LIMIT_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.R251_LIMIT_PRESENCE)) {
							Ranorex.Report.Failure("Field R251_LIMIT_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.R251_LIMIT_PRESENCE + "}.");
						}
						if (messagecontent.R251_LIMIT_PRESENCE != "Y" && messagecontent.R251_LIMIT_PRESENCE != "N") {
							Ranorex.Report.Failure("Field R251_LIMIT_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.R251_LIMIT_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field R251_LIMIT_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.R251_LIMIT_DISTRICT != null) {
					messagecontent.R251_LIMIT_DISTRICT = content.R251_LIMIT_DISTRICT[0].Value;
					if (messagecontent.R251_LIMIT_DISTRICT != null) {
						if (messagecontent.R251_LIMIT_DISTRICT.Length < 1 || messagecontent.R251_LIMIT_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field R251_LIMIT_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.R251_LIMIT_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.R251_LIMIT_MILEPOST != null) {
					messagecontent.R251_LIMIT_MILEPOST = content.R251_LIMIT_MILEPOST[0].Value;
					if (messagecontent.R251_LIMIT_MILEPOST != null) {
						if (messagecontent.R251_LIMIT_MILEPOST.Length < 1 || messagecontent.R251_LIMIT_MILEPOST.Length > 11) {
							Ranorex.Report.Failure("Field R251_LIMIT_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + messagecontent.R251_LIMIT_MILEPOST.Length.ToString() + "}.");
						}
					}
				}

				if (content.R251_LIMIT_TRACK != null) {
					messagecontent.R251_LIMIT_TRACK = content.R251_LIMIT_TRACK[0].Value;
					if (messagecontent.R251_LIMIT_TRACK != null) {
						if (messagecontent.R251_LIMIT_TRACK.Length < 1 || messagecontent.R251_LIMIT_TRACK.Length > 32) {
							Ranorex.Report.Failure("Field R251_LIMIT_TRACK expected to be length between or equal to 1 and 32, has length of {" + messagecontent.R251_LIMIT_TRACK.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_PRESENCE != null) {
					messagecontent.EMT_PSS_PRESENCE = content.EMT_PSS_PRESENCE[0].Value;
					if (messagecontent.EMT_PSS_PRESENCE != null) {
						if (messagecontent.EMT_PSS_PRESENCE.Length != 1) {
							Ranorex.Report.Failure("Field EMT_PSS_PRESENCE expected to be length of 1, has length of {" + messagecontent.EMT_PSS_PRESENCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.EMT_PSS_PRESENCE)) {
							Ranorex.Report.Failure("Field EMT_PSS_PRESENCE expected to be Alphabetic, has value of {" + messagecontent.EMT_PSS_PRESENCE + "}.");
						}
						if (messagecontent.EMT_PSS_PRESENCE != "Y" && messagecontent.EMT_PSS_PRESENCE != "N") {
							Ranorex.Report.Failure("Field EMT_PSS_PRESENCE expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.EMT_PSS_PRESENCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field EMT_PSS_PRESENCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.EMT_PSS_CREATE_TIME != null) {
					messagecontent.EMT_PSS_CREATE_TIME = content.EMT_PSS_CREATE_TIME[0].Value;
					if (messagecontent.EMT_PSS_CREATE_TIME != null) {
						if (messagecontent.EMT_PSS_CREATE_TIME.Length != 8) {
							Ranorex.Report.Failure("Field EMT_PSS_CREATE_TIME expected to be length of 8, has length of {" + messagecontent.EMT_PSS_CREATE_TIME.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_CREATE_DATE != null) {
					messagecontent.EMT_PSS_CREATE_DATE = content.EMT_PSS_CREATE_DATE[0].Value;
					if (messagecontent.EMT_PSS_CREATE_DATE != null) {
						if (messagecontent.EMT_PSS_CREATE_DATE.Length != 10) {
							Ranorex.Report.Failure("Field EMT_PSS_CREATE_DATE expected to be length of 10, has length of {" + messagecontent.EMT_PSS_CREATE_DATE.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_DISTRICT != null) {
					messagecontent.EMT_PSS_DISTRICT = content.EMT_PSS_DISTRICT[0].Value;
					if (messagecontent.EMT_PSS_DISTRICT != null) {
						if (messagecontent.EMT_PSS_DISTRICT.Length < 1 || messagecontent.EMT_PSS_DISTRICT.Length > 25) {
							Ranorex.Report.Failure("Field EMT_PSS_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + messagecontent.EMT_PSS_DISTRICT.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_SITE_NAME != null) {
					messagecontent.EMT_PSS_SITE_NAME = content.EMT_PSS_SITE_NAME[0].Value;
					if (messagecontent.EMT_PSS_SITE_NAME != null) {
						if (messagecontent.EMT_PSS_SITE_NAME.Length < 1 || messagecontent.EMT_PSS_SITE_NAME.Length > 40) {
							Ranorex.Report.Failure("Field EMT_PSS_SITE_NAME expected to be length between or equal to 1 and 40, has length of {" + messagecontent.EMT_PSS_SITE_NAME.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_DEVICE_ID != null) {
					messagecontent.EMT_PSS_DEVICE_ID = content.EMT_PSS_DEVICE_ID[0].Value;
					if (messagecontent.EMT_PSS_DEVICE_ID != null) {
						if (messagecontent.EMT_PSS_DEVICE_ID.Length < 1 || messagecontent.EMT_PSS_DEVICE_ID.Length > 40) {
							Ranorex.Report.Failure("Field EMT_PSS_DEVICE_ID expected to be length between or equal to 1 and 40, has length of {" + messagecontent.EMT_PSS_DEVICE_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.EMT_PSS_DEVICE_TYPE != null) {
				    messagecontent.EMT_PSS_DEVICE_TYPE = content.EMT_PSS_DEVICE_TYPE[0].Value;
				    if (messagecontent.EMT_PSS_DEVICE_TYPE != null) {
				        if (messagecontent.EMT_PSS_DEVICE_TYPE.Length != 2) {
				            Ranorex.Report.Failure("Field EMT_PSS_DEVICE_TYPE expected to be length of 2, has length of {" + messagecontent.EMT_PSS_DEVICE_TYPE.Length.ToString() + "}.");
				        }
				        if (ContainsDigits(messagecontent.EMT_PSS_DEVICE_TYPE)) {
				            Ranorex.Report.Failure("Field EMT_PSS_DEVICE_TYPE expected to be Alphabetic, has value of {" + messagecontent.EMT_PSS_DEVICE_TYPE + "}.");
				        }
				        //if (messagecontent.EMT_PSS_DEVICE_TYPE != "SQ" && messagecontent.EMT_PSS_DEVICE_TYPE != "SW") {
				        //Ranorex.Report.Failure("Field EMT_PSS_DEVICE_TYPE expected to be one of the following values {SQ, SW}, but was found to be {" + messagecontent.EMT_PSS_DEVICE_TYPE + "}.");
				        if (messagecontent.EMT_PSS_DEVICE_TYPE != "SG") {
				            Ranorex.Report.Failure("Field EMT_PSS_DEVICE_TYPE expected to be one of the following values {SG}, but was found to be {" + messagecontent.EMT_PSS_DEVICE_TYPE + "}.");
				        }
				    }
				}

				if (content.EMT_PSS_LIMITS_COUNT != null) {
					messagecontent.EMT_PSS_LIMITS_COUNT = content.EMT_PSS_LIMITS_COUNT[0].Value;
					if (messagecontent.EMT_PSS_LIMITS_COUNT != null) {
						if (messagecontent.EMT_PSS_LIMITS_COUNT.Length < 1 || messagecontent.EMT_PSS_LIMITS_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field EMT_PSS_LIMITS_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.EMT_PSS_LIMITS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.EMT_PSS_LIMITS_COUNT)) {
							Ranorex.Report.Failure("Field EMT_PSS_LIMITS_COUNT expected to be Numeric, has value of {" + messagecontent.EMT_PSS_LIMITS_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.EMT_PSS_LIMITS_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field EMT_PSS_LIMITS_COUNT expected to have value between 1 and 99, but was found to have a value of " + messagecontent.EMT_PSS_LIMITS_COUNT + ".");
							}
						}
					}
				}
				if (content.EMT_PSS_LIMITS_RECORD != null) {
					for (int i = 0; i < content.EMT_PSS_LIMITS_RECORD.Length; i++) {
						PTC_DG_TAUTEMT_PSS_LIMITS_RECORD_7 emt_pss_limits_record = new PTC_DG_TAUTEMT_PSS_LIMITS_RECORD_7();

						if (content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_FROM_DISTRICT != null) {
							emt_pss_limits_record.EMT_PSS_FROM_DISTRICT = content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_FROM_DISTRICT[0].Value;
							if (emt_pss_limits_record.EMT_PSS_FROM_DISTRICT != null) {
								if (emt_pss_limits_record.EMT_PSS_FROM_DISTRICT.Length < 1 || emt_pss_limits_record.EMT_PSS_FROM_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field EMT_PSS_FROM_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + emt_pss_limits_record.EMT_PSS_FROM_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field EMT_PSS_FROM_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_FROM_MILEPOST != null) {
							emt_pss_limits_record.EMT_PSS_FROM_MILEPOST = content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_FROM_MILEPOST[0].Value;
							if (emt_pss_limits_record.EMT_PSS_FROM_MILEPOST != null) {
								if (emt_pss_limits_record.EMT_PSS_FROM_MILEPOST.Length < 1 || emt_pss_limits_record.EMT_PSS_FROM_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field EMT_PSS_FROM_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + emt_pss_limits_record.EMT_PSS_FROM_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field EMT_PSS_FROM_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TO_DISTRICT != null) {
							emt_pss_limits_record.EMT_PSS_TO_DISTRICT = content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TO_DISTRICT[0].Value;
							if (emt_pss_limits_record.EMT_PSS_TO_DISTRICT != null) {
								if (emt_pss_limits_record.EMT_PSS_TO_DISTRICT.Length < 1 || emt_pss_limits_record.EMT_PSS_TO_DISTRICT.Length > 25) {
									Ranorex.Report.Failure("Field EMT_PSS_TO_DISTRICT expected to be length between or equal to 1 and 25, has length of {" + emt_pss_limits_record.EMT_PSS_TO_DISTRICT.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field EMT_PSS_TO_DISTRICT is a Mandatory field but was found to be missing from the message");
						}

						if (content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TO_MILEPOST != null) {
							emt_pss_limits_record.EMT_PSS_TO_MILEPOST = content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TO_MILEPOST[0].Value;
							if (emt_pss_limits_record.EMT_PSS_TO_MILEPOST != null) {
								if (emt_pss_limits_record.EMT_PSS_TO_MILEPOST.Length < 1 || emt_pss_limits_record.EMT_PSS_TO_MILEPOST.Length > 11) {
									Ranorex.Report.Failure("Field EMT_PSS_TO_MILEPOST expected to be length between or equal to 1 and 11, has length of {" + emt_pss_limits_record.EMT_PSS_TO_MILEPOST.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field EMT_PSS_TO_MILEPOST is a Mandatory field but was found to be missing from the message");
						}

						if (content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TRACK != null) {
							emt_pss_limits_record.EMT_PSS_TRACK = content.EMT_PSS_LIMITS_RECORD[i].EMT_PSS_TRACK[0].Value;
							if (emt_pss_limits_record.EMT_PSS_TRACK != null) {
								if (emt_pss_limits_record.EMT_PSS_TRACK.Length < 1 || emt_pss_limits_record.EMT_PSS_TRACK.Length > 32) {
									Ranorex.Report.Failure("Field EMT_PSS_TRACK expected to be length between or equal to 1 and 32, has length of {" + emt_pss_limits_record.EMT_PSS_TRACK.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field EMT_PSS_TRACK is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addEMT_PSS_LIMITS_RECORD(emt_pss_limits_record);
					}
				}

				dg_taut_7.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dg_taut_7;
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
	public partial class PTC_DG_TAUTHEADER_7 {
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

	public partial class PTC_DG_TAUTCONTENT_7 {
		public string ACTION = "";
		public string VOICE_ACK_REQUIRED = "";
		public string CREW_ACK_REQUIRED = "";
		public string ELECTRONIC_ACK_REQUESTED = "";
		public string CREW_ACK_TYPE = "";
		public string AUTHORITY_TYPE = "";
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
		public string S5_INITAL_UNTIL_DATE = "";
		public string S5_INITAL_UNTIL_TIME = "";
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
		public string RPT_TEXT_COUNT = "";
		public ArrayList RPT_RECORD = new ArrayList();
		public string R251_LIMIT_PRESENCE = "";
		public string R251_LIMIT_DISTRICT = "";
		public string R251_LIMIT_MILEPOST = "";
		public string R251_LIMIT_TRACK = "";
		public string EMT_PSS_PRESENCE = "";
		public string EMT_PSS_CREATE_TIME = "";
		public string EMT_PSS_CREATE_DATE = "";
		public string EMT_PSS_DISTRICT = "";
		public string EMT_PSS_SITE_NAME = "";
		public string EMT_PSS_DEVICE_ID = "";
		public string EMT_PSS_DEVICE_TYPE = "";
		public string EMT_PSS_LIMITS_COUNT = "";
		public ArrayList EMT_PSS_LIMITS_RECORD = new ArrayList();

		public void addS2_RECORD(PTC_DG_TAUTS2_RECORD_7 s2_record) {
			this.S2_RECORD.Add(s2_record);
		}

		public void addS2_LIMITS_RECORD(PTC_DG_TAUTS2_LIMITS_RECORD_7 s2_limits_record) {
			this.S2_LIMITS_RECORD.Add(s2_limits_record);
		}

		public void addS3_TRACK_RECORD(PTC_DG_TAUTS3_TRACK_RECORD_7 s3_track_record) {
			this.S3_TRACK_RECORD.Add(s3_track_record);
		}

		public void addS3_LIMITS_RECORD(PTC_DG_TAUTS3_LIMITS_RECORD_7 s3_limits_record) {
			this.S3_LIMITS_RECORD.Add(s3_limits_record);
		}

		public void addS4_RECORD(PTC_DG_TAUTS4_RECORD_7 s4_record) {
			this.S4_RECORD.Add(s4_record);
		}

		public void addS4_LIMITS_RECORD(PTC_DG_TAUTS4_LIMITS_RECORD_7 s4_limits_record) {
			this.S4_LIMITS_RECORD.Add(s4_limits_record);
		}

		public void addS5_RECORD(PTC_DG_TAUTS5_RECORD_7 s5_record) {
			this.S5_RECORD.Add(s5_record);
		}

		public void addS6_RECORD(PTC_DG_TAUTS6_RECORD_7 s6_record) {
			this.S6_RECORD.Add(s6_record);
		}

		public void addS8_RECORD(PTC_DG_TAUTS8_RECORD_7 s8_record) {
			this.S8_RECORD.Add(s8_record);
		}

		public void addS10_RECORD(PTC_DG_TAUTS10_RECORD_7 s10_record) {
			this.S10_RECORD.Add(s10_record);
		}

		public void addS12_RWIC_RECORD(PTC_DG_TAUTS12_RWIC_RECORD_7 s12_rwic_record) {
			this.S12_RWIC_RECORD.Add(s12_rwic_record);
		}

		public void addS13_RECORD(PTC_DG_TAUTS13_RECORD_7 s13_record) {
			this.S13_RECORD.Add(s13_record);
		}

		public void addT2_RECORD(PTC_DG_TAUTT2_RECORD_7 t2_record) {
			this.T2_RECORD.Add(t2_record);
		}

		public void addRPT_RECORD(PTC_DG_TAUTRPT_RECORD_7 rpt_record) {
			this.RPT_RECORD.Add(rpt_record);
		}

		public void addEMT_PSS_LIMITS_RECORD(PTC_DG_TAUTEMT_PSS_LIMITS_RECORD_7 emt_pss_limits_record) {
			this.EMT_PSS_LIMITS_RECORD.Add(emt_pss_limits_record);
		}
	}

	public partial class PTC_DG_TAUTS2_RECORD_7 {
		public string S2_SEQUENCE = "";
		public string S2_TO_LOCATION = "";
		public string S2_TRACK_TEXT = "";
	}

	public partial class PTC_DG_TAUTS2_LIMITS_RECORD_7 {
		public string S2_FROM_DISTRICT = "";
		public string S2_FROM_MILEPOST = "";
		public string S2_TO_DISTRICT = "";
		public string S2_TO_MILEPOST = "";
		public string S2_TRACK = "";
	}

	public partial class PTC_DG_TAUTS3_TRACK_RECORD_7 {
		public string S3_TRACK_SEQUENCE = "";
		public string S3_TRACK_TEXT = "";
	}

	public partial class PTC_DG_TAUTS3_LIMITS_RECORD_7 {
		public string S3_BETWEEN_DISTRICT = "";
		public string S3_BETWEEN_MILEPOST = "";
		public string S3_AND_DISTRICT = "";
		public string S3_AND_MILEPOST = "";
		public string S3_TRACK = "";
	}

	public partial class PTC_DG_TAUTS4_RECORD_7 {
		public string S4_SEQUENCE = "";
		public string S4_TO_LOCATION = "";
		public string S4_TRACK_TEXT = "";
	}

	public partial class PTC_DG_TAUTS4_LIMITS_RECORD_7 {
		public string S4_FROM_DISTRICT = "";
		public string S4_FROM_MILEPOST = "";
		public string S4_TO_DISTRICT = "";
		public string S4_TO_MILEPOST = "";
		public string S4_TRACK = "";
	}

	public partial class PTC_DG_TAUTS5_RECORD_7 {
		public string S5_SEQUENCE = "";
		public string S5_EXTENDED_UNTIL = "";
		public string S5_INITIALS = "";
	}

	public partial class PTC_DG_TAUTS6_RECORD_7 {
		public string S6_SEQUENCE = "";
		public string S6_ENGINE_INITIAL = "";
		public string S6_ENGINE_NUMBER = "";
		public string S6_ENGINE_ID = "";
		public string S6_DIRECTION = "";
	}

	public partial class PTC_DG_TAUTS8_RECORD_7 {
		public string S8_SEQUENCE = "";
		public string S8_ENGINE_INITIAL = "";
		public string S8_ENGINE_NUMBER = "";
		public string S8_ENGINE_ID = "";
		public string S8_DIRECTION = "";
	}

	public partial class PTC_DG_TAUTS10_RECORD_7 {
		public string S10_BETWEEN_DISTRICT = "";
		public string S10_BETWEEN_MILEPOST = "";
		public string S10_AND_DISTRICT = "";
		public string S10_AND_MILEPOST = "";
		public string S10_TRACK = "";
	}

	public partial class PTC_DG_TAUTS12_RWIC_RECORD_7 {
		public string S12_RWIC_SEQUENCE = "";
		public string S12_RWIC = "";
		public string S12_BETWEEN_LOCATION = "";
		public string S12_AND_LOCATION = "";
		public string S12_TRACK_TEXT = "";
		public string S12_LIMITS_COUNT = "";
		public ArrayList S12_LIMITS_RECORD = new ArrayList();

		public void addS12_LIMITS_RECORD(PTC_DG_TAUTS12_LIMITS_RECORD_7 s12_limits_record) {
			this.S12_LIMITS_RECORD.Add(s12_limits_record);
		}
	}

	public partial class PTC_DG_TAUTS12_LIMITS_RECORD_7 {
		public string S12_BETWEEN_DISTRICT = "";
		public string S12_BETWEEN_MILEPOST = "";
		public string S12_AND_DISTRICT = "";
		public string S12_AND_MILEPOST = "";
		public string S12_TRACK = "";
	}

	public partial class PTC_DG_TAUTS13_RECORD_7 {
		public string S13_SEQUENCE = "";
		public string S13_TEXT = "";
	}

	public partial class PTC_DG_TAUTT2_RECORD_7 {
		public string T2_SEQUENCE = "";
		public string T2_ROLLUP_LOCATION = "";
		public string T2_ROLLUP_DATE = "";
		public string T2_ROLLUP_TIME = "";
		public string T2_BY = "";
	}

	public partial class PTC_DG_TAUTRPT_RECORD_7 {
		public string RPT_SEQUENCE = "";
		public string RPT_TEXT = "";
	}

	public partial class PTC_DG_TAUTEMT_PSS_LIMITS_RECORD_7 {
		public string EMT_PSS_FROM_DISTRICT = "";
		public string EMT_PSS_FROM_MILEPOST = "";
		public string EMT_PSS_TO_DISTRICT = "";
		public string EMT_PSS_TO_MILEPOST = "";
		public string EMT_PSS_TRACK = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DG_TAUT_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DG_TAUTHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DG_TAUTCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_ACTION_7[] ACTION;

		[System.Xml.Serialization.XmlElementAttribute("VOICE_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_VOICE_ACK_REQUIRED_7[] VOICE_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_CREW_ACK_REQUIRED_7[] CREW_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("ELECTRONIC_ACK_REQUESTED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_ELECTRONIC_ACK_REQUESTED_7[] ELECTRONIC_ACK_REQUESTED;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_CREW_ACK_TYPE_7[] CREW_ACK_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("AUTHORITY_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_AUTHORITY_TYPE_7[] AUTHORITY_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("H_TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_TRACK_AUTHORITY_NUMBER_7[] H_TRACK_AUTHORITY_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ADDRESSEE_TYPE_7[] H_ADDRESSEE_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("H_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_SCAC_7[] H_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("H_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_SYMBOL_7[] H_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("H_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_SECTION_7[] H_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("H_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ORIGIN_DATE_7[] H_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("H_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ENGINE_INITIAL_7[] H_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("H_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ENGINE_NUMBER_7[] H_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_COUPLED_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_COUPLED_ENGINE_INITIAL_7[] H_COUPLED_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("H_COUPLED_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_COUPLED_ENGINE_NUMBER_7[] H_COUPLED_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ADDRESSEE_ID_7[] H_ADDRESSEE_ID;

		[System.Xml.Serialization.XmlElementAttribute("H_ADDRESSEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_ADDRESSEE_7[] H_ADDRESSEE;

		[System.Xml.Serialization.XmlElementAttribute("H_AT_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_H_AT_LOCATION_7[] H_AT_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S1_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S1_PRESENCE_7[] S1_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S1_TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S1_TRACK_AUTHORITY_NUMBER_7[] S1_TRACK_AUTHORITY_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("S2_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_PRESENCE_7[] S2_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_FROM_LOCATION_7[] S2_FROM_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S2_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_COUNT_7[] S2_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S2_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_RECORD_7[] S2_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S2_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_LIMITS_COUNT_7[] S2_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S2_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S2_LIMITS_RECORD_7[] S2_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S3_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_PRESENCE_7[] S3_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_BETWEEN_LOCATION_7[] S3_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_AND_LOCATION_7[] S3_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_TRACK_COUNT_7[] S3_TRACK_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_TRACK_RECORD_7[] S3_TRACK_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S3_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_LIMITS_COUNT_7[] S3_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S3_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S3_LIMITS_RECORD_7[] S3_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S4_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_PRESENCE_7[] S4_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_FROM_LOCATION_7[] S4_FROM_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S4_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_COUNT_7[] S4_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S4_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_RECORD_7[] S4_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S4_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_LIMITS_COUNT_7[] S4_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S4_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S4_LIMITS_RECORD_7[] S4_LIMITS_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S5_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_PRESENCE_7[] S5_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITAL_UNTIL_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_INITAL_UNTIL_DATE_7[] S5_INITAL_UNTIL_DATE;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITAL_UNTIL_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_INITAL_UNTIL_TIME_7[] S5_INITAL_UNTIL_TIME;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_EXTENDED_UNTIL_DATE_7[] S5_EXTENDED_UNTIL_DATE;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_EXTENDED_UNTIL_TIME_7[] S5_EXTENDED_UNTIL_TIME;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIAL_UNTIL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_INITIAL_UNTIL_7[] S5_INITIAL_UNTIL;

		[System.Xml.Serialization.XmlElementAttribute("S5_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_COUNT_7[] S5_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S5_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S5_RECORD_7[] S5_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S6_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_PRESENCE_7[] S6_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S6_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_COUNT_7[] S6_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S6_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_RECORD_7[] S6_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_AT_DISTRICT_7[] S6_AT_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_AT_TRACK_7[] S6_AT_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_AT_MILEPOST_7[] S6_AT_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S6_AT_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S6_AT_LOCATION_7[] S6_AT_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S7_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S7_PRESENCE_7[] S7_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S8_PRESENCE_7[] S8_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S8_COUNT_7[] S8_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S8_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S8_RECORD_7[] S8_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S9_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S9_PRESENCE_7[] S9_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S10_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S10_PRESENCE_7[] S10_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S10_BETWEEN_LOCATION_7[] S10_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S10_AND_LOCATION_7[] S10_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S10_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S10_COUNT_7[] S10_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S10_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S10_RECORD_7[] S10_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S11_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S11_PRESENCE_7[] S11_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S11_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S11_DISTRICT_7[] S11_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S11_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S11_MILEPOST_7[] S11_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S11_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S11_LOCATION_7[] S11_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S11_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S11_TRACK_7[] S11_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("S12_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S12_PRESENCE_7[] S12_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S12_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S12_COUNT_7[] S12_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S12_RWIC_RECORD_7[] S12_RWIC_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("S13_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S13_PRESENCE_7[] S13_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("S13_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S13_COUNT_7[] S13_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S13_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_S13_RECORD_7[] S13_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("T1_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_PRESENCE_7[] T1_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T1_COPIED_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_COPIED_BY_7[] T1_COPIED_BY;

		[System.Xml.Serialization.XmlElementAttribute("T1_OK_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_OK_TIME_7[] T1_OK_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T1_OK_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_OK_DATE_7[] T1_OK_DATE;

		[System.Xml.Serialization.XmlElementAttribute("T1_DISPATCHER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_DISPATCHER_7[] T1_DISPATCHER;

		[System.Xml.Serialization.XmlElementAttribute("T1_RELAY_EMPLOYEE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_RELAY_EMPLOYEE_7[] T1_RELAY_EMPLOYEE;

		[System.Xml.Serialization.XmlElementAttribute("T1_RELAY_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T1_RELAY_LOCATION_7[] T1_RELAY_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("T2_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_PRESENCE_7[] T2_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T2_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_DISTRICT_7[] T2_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("T2_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_MILEPOST_7[] T2_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("T2_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_TRACK_7[] T2_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("T2_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_COUNT_7[] T2_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("T2_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T2_RECORD_7[] T2_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("T3_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T3_PRESENCE_7[] T3_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("T3_CLEAR_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T3_CLEAR_TIME_7[] T3_CLEAR_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T3_CLEAR_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_T3_CLEAR_BY_7[] T3_CLEAR_BY;

		[System.Xml.Serialization.XmlElementAttribute("RPT_TEXT_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_RPT_TEXT_COUNT_7[] RPT_TEXT_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("RPT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_RPT_RECORD_7[] RPT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("R251_LIMIT_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_R251_LIMIT_PRESENCE_7[] R251_LIMIT_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("R251_LIMIT_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_R251_LIMIT_DISTRICT_7[] R251_LIMIT_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("R251_LIMIT_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_R251_LIMIT_MILEPOST_7[] R251_LIMIT_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("R251_LIMIT_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_R251_LIMIT_TRACK_7[] R251_LIMIT_TRACK;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_PRESENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_PRESENCE_7[] EMT_PSS_PRESENCE;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_CREATE_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_CREATE_TIME_7[] EMT_PSS_CREATE_TIME;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_CREATE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_CREATE_DATE_7[] EMT_PSS_CREATE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_DISTRICT_7[] EMT_PSS_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_SITE_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_SITE_NAME_7[] EMT_PSS_SITE_NAME;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_DEVICE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_DEVICE_ID_7[] EMT_PSS_DEVICE_ID;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_DEVICE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_DEVICE_TYPE_7[] EMT_PSS_DEVICE_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_LIMITS_COUNT_7[] EMT_PSS_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTCONTENT_EMT_PSS_LIMITS_RECORD_7[] EMT_PSS_LIMITS_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_ACTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_VOICE_ACK_REQUIRED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_CREW_ACK_REQUIRED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_ELECTRONIC_ACK_REQUESTED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_CREW_ACK_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_AUTHORITY_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_TRACK_AUTHORITY_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ADDRESSEE_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_COUPLED_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_COUPLED_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ADDRESSEE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_ADDRESSEE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_H_AT_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S1_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S1_TRACK_AUTHORITY_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_FROM_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S2_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_RECORD_S2_SEQUENCE_7[] S2_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_RECORD_S2_TO_LOCATION_7[] S2_TO_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S2_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_RECORD_S2_TRACK_TEXT_7[] S2_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_RECORD_S2_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_RECORD_S2_TO_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_RECORD_S2_TRACK_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_LIMITS_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S2_LIMITS_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_LIMITS_RECORD_S2_FROM_DISTRICT_7[] S2_FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S2_FROM_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_LIMITS_RECORD_S2_FROM_MILEPOST_7[] S2_FROM_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_LIMITS_RECORD_S2_TO_DISTRICT_7[] S2_TO_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S2_TO_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_LIMITS_RECORD_S2_TO_MILEPOST_7[] S2_TO_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S2_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS2_LIMITS_RECORD_S2_TRACK_7[] S2_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_LIMITS_RECORD_S2_FROM_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_LIMITS_RECORD_S2_FROM_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_LIMITS_RECORD_S2_TO_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_LIMITS_RECORD_S2_TO_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS2_LIMITS_RECORD_S2_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_BETWEEN_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_AND_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_TRACK_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_TRACK_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_TRACK_RECORD_S3_TRACK_SEQUENCE_7[] S3_TRACK_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_TRACK_RECORD_S3_TRACK_TEXT_7[] S3_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_TRACK_RECORD_S3_TRACK_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_TRACK_RECORD_S3_TRACK_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_LIMITS_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S3_LIMITS_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_LIMITS_RECORD_S3_BETWEEN_DISTRICT_7[] S3_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S3_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_LIMITS_RECORD_S3_BETWEEN_MILEPOST_7[] S3_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_LIMITS_RECORD_S3_AND_DISTRICT_7[] S3_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S3_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_LIMITS_RECORD_S3_AND_MILEPOST_7[] S3_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S3_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS3_LIMITS_RECORD_S3_TRACK_7[] S3_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_LIMITS_RECORD_S3_BETWEEN_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_LIMITS_RECORD_S3_BETWEEN_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_LIMITS_RECORD_S3_AND_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_LIMITS_RECORD_S3_AND_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS3_LIMITS_RECORD_S3_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_FROM_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S4_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_RECORD_S4_SEQUENCE_7[] S4_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_RECORD_S4_TO_LOCATION_7[] S4_TO_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S4_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_RECORD_S4_TRACK_TEXT_7[] S4_TRACK_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_RECORD_S4_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_RECORD_S4_TO_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_RECORD_S4_TRACK_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_LIMITS_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S4_LIMITS_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_LIMITS_RECORD_S4_FROM_DISTRICT_7[] S4_FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S4_FROM_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_LIMITS_RECORD_S4_FROM_MILEPOST_7[] S4_FROM_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_LIMITS_RECORD_S4_TO_DISTRICT_7[] S4_TO_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S4_TO_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_LIMITS_RECORD_S4_TO_MILEPOST_7[] S4_TO_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S4_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS4_LIMITS_RECORD_S4_TRACK_7[] S4_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_LIMITS_RECORD_S4_FROM_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_LIMITS_RECORD_S4_FROM_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_LIMITS_RECORD_S4_TO_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_LIMITS_RECORD_S4_TO_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS4_LIMITS_RECORD_S4_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_INITAL_UNTIL_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_INITAL_UNTIL_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_EXTENDED_UNTIL_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_EXTENDED_UNTIL_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_INITIAL_UNTIL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S5_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S5_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS5_RECORD_S5_SEQUENCE_7[] S5_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S5_EXTENDED_UNTIL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS5_RECORD_S5_EXTENDED_UNTIL_7[] S5_EXTENDED_UNTIL;

		[System.Xml.Serialization.XmlElementAttribute("S5_INITIALS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS5_RECORD_S5_INITIALS_7[] S5_INITIALS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS5_RECORD_S5_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS5_RECORD_S5_EXTENDED_UNTIL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS5_RECORD_S5_INITIALS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S6_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS6_RECORD_S6_SEQUENCE_7[] S6_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S6_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS6_RECORD_S6_ENGINE_INITIAL_7[] S6_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("S6_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS6_RECORD_S6_ENGINE_NUMBER_7[] S6_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("S6_ENGINE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS6_RECORD_S6_ENGINE_ID_7[] S6_ENGINE_ID;

		[System.Xml.Serialization.XmlElementAttribute("S6_DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS6_RECORD_S6_DIRECTION_7[] S6_DIRECTION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS6_RECORD_S6_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS6_RECORD_S6_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS6_RECORD_S6_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS6_RECORD_S6_ENGINE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS6_RECORD_S6_DIRECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_AT_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_AT_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_AT_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S6_AT_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S7_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S8_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S8_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S8_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S8_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS8_RECORD_S8_SEQUENCE_7[] S8_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS8_RECORD_S8_ENGINE_INITIAL_7[] S8_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS8_RECORD_S8_ENGINE_NUMBER_7[] S8_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("S8_ENGINE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS8_RECORD_S8_ENGINE_ID_7[] S8_ENGINE_ID;

		[System.Xml.Serialization.XmlElementAttribute("S8_DIRECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS8_RECORD_S8_DIRECTION_7[] S8_DIRECTION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS8_RECORD_S8_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS8_RECORD_S8_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS8_RECORD_S8_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS8_RECORD_S8_ENGINE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS8_RECORD_S8_DIRECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S9_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S10_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S10_BETWEEN_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S10_AND_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S10_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S10_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS10_RECORD_S10_BETWEEN_DISTRICT_7[] S10_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S10_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS10_RECORD_S10_BETWEEN_MILEPOST_7[] S10_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS10_RECORD_S10_AND_DISTRICT_7[] S10_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S10_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS10_RECORD_S10_AND_MILEPOST_7[] S10_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S10_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS10_RECORD_S10_TRACK_7[] S10_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS10_RECORD_S10_BETWEEN_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS10_RECORD_S10_BETWEEN_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS10_RECORD_S10_AND_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS10_RECORD_S10_AND_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS10_RECORD_S10_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S11_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S11_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S11_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S11_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S11_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S12_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S12_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S12_RWIC_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_RWIC_SEQUENCE_7[] S12_RWIC_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S12_RWIC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_RWIC_7[] S12_RWIC;

		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_BETWEEN_LOCATION_7[] S12_BETWEEN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_AND_LOCATION_7[] S12_AND_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("S12_TRACK_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_TRACK_TEXT_7[] S12_TRACK_TEXT;

		[System.Xml.Serialization.XmlElementAttribute("S12_LIMITS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_LIMITS_COUNT_7[] S12_LIMITS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("S12_LIMITS_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_RWIC_RECORD_S12_LIMITS_RECORD_7[] S12_LIMITS_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_RWIC_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_RWIC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_BETWEEN_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_AND_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_TRACK_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_LIMITS_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_RWIC_RECORD_S12_LIMITS_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_LIMITS_RECORD_S12_BETWEEN_DISTRICT_7[] S12_BETWEEN_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S12_BETWEEN_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_LIMITS_RECORD_S12_BETWEEN_MILEPOST_7[] S12_BETWEEN_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_LIMITS_RECORD_S12_AND_DISTRICT_7[] S12_AND_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("S12_AND_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_LIMITS_RECORD_S12_AND_MILEPOST_7[] S12_AND_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("S12_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS12_LIMITS_RECORD_S12_TRACK_7[] S12_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_LIMITS_RECORD_S12_BETWEEN_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_LIMITS_RECORD_S12_BETWEEN_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_LIMITS_RECORD_S12_AND_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_LIMITS_RECORD_S12_AND_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS12_LIMITS_RECORD_S12_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S13_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S13_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_S13_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("S13_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS13_RECORD_S13_SEQUENCE_7[] S13_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("S13_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTS13_RECORD_S13_TEXT_7[] S13_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS13_RECORD_S13_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTS13_RECORD_S13_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_COPIED_BY_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_OK_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_OK_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_DISPATCHER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_RELAY_EMPLOYEE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T1_RELAY_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T2_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("T2_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTT2_RECORD_T2_SEQUENCE_7[] T2_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTT2_RECORD_T2_ROLLUP_LOCATION_7[] T2_ROLLUP_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTT2_RECORD_T2_ROLLUP_DATE_7[] T2_ROLLUP_DATE;

		[System.Xml.Serialization.XmlElementAttribute("T2_ROLLUP_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTT2_RECORD_T2_ROLLUP_TIME_7[] T2_ROLLUP_TIME;

		[System.Xml.Serialization.XmlElementAttribute("T2_BY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTT2_RECORD_T2_BY_7[] T2_BY;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTT2_RECORD_T2_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTT2_RECORD_T2_ROLLUP_LOCATION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTT2_RECORD_T2_ROLLUP_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTT2_RECORD_T2_ROLLUP_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTT2_RECORD_T2_BY_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T3_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T3_CLEAR_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_T3_CLEAR_BY_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_RPT_TEXT_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_RPT_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("RPT_SEQUENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTRPT_RECORD_RPT_SEQUENCE_7[] RPT_SEQUENCE;

		[System.Xml.Serialization.XmlElementAttribute("RPT_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTRPT_RECORD_RPT_TEXT_7[] RPT_TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTRPT_RECORD_RPT_SEQUENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTRPT_RECORD_RPT_TEXT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_R251_LIMIT_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_R251_LIMIT_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_R251_LIMIT_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_R251_LIMIT_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_PRESENCE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_CREATE_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_CREATE_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_SITE_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_DEVICE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_DEVICE_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_LIMITS_COUNT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTCONTENT_EMT_PSS_LIMITS_RECORD_7 {
		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_FROM_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_FROM_DISTRICT_7[] EMT_PSS_FROM_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_FROM_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_FROM_MILEPOST_7[] EMT_PSS_FROM_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_TO_DISTRICT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TO_DISTRICT_7[] EMT_PSS_TO_DISTRICT;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_TO_MILEPOST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TO_MILEPOST_7[] EMT_PSS_TO_MILEPOST;

		[System.Xml.Serialization.XmlElementAttribute("EMT_PSS_TRACK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TRACK_7[] EMT_PSS_TRACK;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_FROM_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_FROM_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TO_DISTRICT_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TO_MILEPOST_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_TAUTEMT_PSS_LIMITS_RECORD_EMT_PSS_TRACK_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}