using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.RUM
{
	public partial class RUM_DR_AK01_1 {
		public RUM_DR_AK01HEADER_1 HEADER;
		public RUM_DR_AK01CONTENT_1 CONTENT;

		public static RUM_DR_AK01_1 fromSerializableObject(DR_AK01_1 message) {
			RUM_DR_AK01_1 dr_ak01_1 = new RUM_DR_AK01_1();
			DR_AK01HEADER_1 header = null;
			DR_AK01CONTENT_1 content = null;
			header = (DR_AK01HEADER_1) message.Items[0];
			content = (DR_AK01CONTENT_1) message.Items[1];

			if (header != null) {
				RUM_DR_AK01HEADER_1 messageheader = new RUM_DR_AK01HEADER_1();

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

				dr_ak01_1.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				RUM_DR_AK01CONTENT_1 messagecontent = new RUM_DR_AK01CONTENT_1();

				if (content.ACK_SEQUENCE_NUMBER != null) {
					messagecontent.ACK_SEQUENCE_NUMBER = content.ACK_SEQUENCE_NUMBER[0].Value;
					if (messagecontent.ACK_SEQUENCE_NUMBER != null) {
						if (messagecontent.ACK_SEQUENCE_NUMBER.Length < 1 || messagecontent.ACK_SEQUENCE_NUMBER.Length > 13) {
							Ranorex.Report.Failure("Field ACK_SEQUENCE_NUMBER expected to be length between or equal to 1 and 13, has length of {" + messagecontent.ACK_SEQUENCE_NUMBER.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ACK_SEQUENCE_NUMBER)) {
							Ranorex.Report.Failure("Field ACK_SEQUENCE_NUMBER expected to be Numeric, has value of {" + messagecontent.ACK_SEQUENCE_NUMBER + "}.");
						} else {
							long intConvertedValue = Convert.ToInt64(messagecontent.ACK_SEQUENCE_NUMBER);
							if (intConvertedValue < 1 || intConvertedValue > 9999999999999) {
								Ranorex.Report.Failure("Field ACK_SEQUENCE_NUMBER expected to have value between 1 and 9999999999999, but was found to have a value of " + messagecontent.ACK_SEQUENCE_NUMBER + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field ACK_SEQUENCE_NUMBER is a Mandatory field but was found to be missing from the message");
				}

				if (content.RESPONSE_CODE != null) {
					messagecontent.RESPONSE_CODE = content.RESPONSE_CODE[0].Value;
					if (messagecontent.RESPONSE_CODE != null) {
						if (messagecontent.RESPONSE_CODE.Length < 1 || messagecontent.RESPONSE_CODE.Length > 6) {
							Ranorex.Report.Failure("Field RESPONSE_CODE expected to be length between or equal to 1 and 6, has length of {" + messagecontent.RESPONSE_CODE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.RESPONSE_CODE)) {
							Ranorex.Report.Failure("Field RESPONSE_CODE expected to be Alphabetic, has value of {" + messagecontent.RESPONSE_CODE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field RESPONSE_CODE is a Mandatory field but was found to be missing from the message");
				}

				if (content.TEXT != null) {
					messagecontent.TEXT = content.TEXT[0].Value;
					if (messagecontent.TEXT != null) {
						if (messagecontent.TEXT.Length < 1 || messagecontent.TEXT.Length > 255) {
							Ranorex.Report.Failure("Field TEXT expected to be length between or equal to 1 and 255, has length of {" + messagecontent.TEXT.Length.ToString() + "}.");
						}
					}
				}

				dr_ak01_1.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dr_ak01_1;
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
	public partial class RUM_DR_AK01HEADER_1 {
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

	public partial class RUM_DR_AK01CONTENT_1 {
		public string ACK_SEQUENCE_NUMBER = "";
		public string RESPONSE_CODE = "";
		public string TEXT = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DR_AK01_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DR_AK01HEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DR_AK01CONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01HEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01HEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01CONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("ACK_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01CONTENT_ACK_SEQUENCE_NUMBER_1[] ACK_SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("RESPONSE_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01CONTENT_RESPONSE_CODE_1[] RESPONSE_CODE;

		[System.Xml.Serialization.XmlElementAttribute("TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_AK01CONTENT_TEXT_1[] TEXT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01CONTENT_ACK_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01CONTENT_RESPONSE_CODE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_AK01CONTENT_TEXT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}