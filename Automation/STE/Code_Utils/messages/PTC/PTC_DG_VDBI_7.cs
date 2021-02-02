using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.PTC
{
	public partial class PTC_DG_VDBI_7 {
		public PTC_DG_VDBIHEADER_7 HEADER;
		public PTC_DG_VDBICONTENT_7 CONTENT;

		public static PTC_DG_VDBI_7 fromSerializableObject(DG_VDBI_7 message) {
			PTC_DG_VDBI_7 dg_vdbi_7 = new PTC_DG_VDBI_7();
			DG_VDBIHEADER_7 header = null;
			DG_VDBICONTENT_7 content = null;
			header = (DG_VDBIHEADER_7) message.Items[0];
			content = (DG_VDBICONTENT_7) message.Items[1];

			if (header != null) {
				PTC_DG_VDBIHEADER_7 messageheader = new PTC_DG_VDBIHEADER_7();

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

				dg_vdbi_7.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				PTC_DG_VDBICONTENT_7 messagecontent = new PTC_DG_VDBICONTENT_7();

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

				dg_vdbi_7.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dg_vdbi_7;
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
	public partial class PTC_DG_VDBIHEADER_7 {
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

	public partial class PTC_DG_VDBICONTENT_7 {
		public string BULLETIN_ITEM_NUMBER = "";
		public string CREW_ACK_REQUIRED = "";
		public string ELECTRONIC_ACK_REQUESTED = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DG_VDBI_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DG_VDBIHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DG_VDBICONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_7 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_EVENT_DATE_7[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_EVENT_TIME_7[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_MESSAGE_ID_7[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_SEQUENCE_NUMBER_7[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_MESSAGE_VERSION_7[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_MESSAGE_REVISION_7[] MESSAGE_REVISION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_SOURCE_SYS_7[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_DESTINATION_SYS_7[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_DISTRICT_NAME_7[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_DISTRICT_SCAC_7[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_USER_ID_7[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_TRACK_FILE_VERSION_7[] TRACK_FILE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HTRN_SCAC_7[] HTRN_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HTRN_SYMBOL_7[] HTRN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HTRN_SECTION_7[] HTRN_SECTION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HTRN_ORIGIN_DATE_7[] HTRN_ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HENG_ENGINE_INITIAL_7[] HENG_ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_HENG_ENGINE_NUMBER_7[] HENG_ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_UID1_TYPE_7[] UID1_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_UID1_7[] UID1;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_UID2_TYPE_7[] UID2_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_UID2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBIHEADER_UID2_7[] UID2;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_UID1_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_UID1_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_UID2_TYPE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBIHEADER_UID2_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBICONTENT_7 {
		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBICONTENT_BULLETIN_ITEM_NUMBER_7[] BULLETIN_ITEM_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("CREW_ACK_REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBICONTENT_CREW_ACK_REQUIRED_7[] CREW_ACK_REQUIRED;

		[System.Xml.Serialization.XmlElementAttribute("ELECTRONIC_ACK_REQUESTED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DG_VDBICONTENT_ELECTRONIC_ACK_REQUESTED_7[] ELECTRONIC_ACK_REQUESTED;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBICONTENT_BULLETIN_ITEM_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBICONTENT_CREW_ACK_REQUIRED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DG_VDBICONTENT_ELECTRONIC_ACK_REQUESTED_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}