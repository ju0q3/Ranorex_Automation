using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;

namespace STE.Code_Utils.messages.RUM
{
	public partial class RUM_DR_BICR_1 {
		public RUM_DR_BICRHEADER_1 HEADER;
		public RUM_DR_BICRCONTENT_1 CONTENT;

		public static RUM_DR_BICR_1 fromSerializableObject(DR_BICR_1 message) {
			RUM_DR_BICR_1 dr_bicr_1 = new RUM_DR_BICR_1();
			DR_BICRHEADER_1 header = null;
			DR_BICRCONTENT_1 content = null;
			header = (DR_BICRHEADER_1) message.Items[0];
			content = (DR_BICRCONTENT_1) message.Items[1];

			if (header != null) {
				RUM_DR_BICRHEADER_1 messageheader = new RUM_DR_BICRHEADER_1();

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

				dr_bicr_1.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				RUM_DR_BICRCONTENT_1 messagecontent = new RUM_DR_BICRCONTENT_1();

				if (content.REQUEST_ID != null) {
					messagecontent.REQUEST_ID = content.REQUEST_ID[0].Value;
					if (messagecontent.REQUEST_ID != null) {
						if (messagecontent.REQUEST_ID.Length < 1 || messagecontent.REQUEST_ID.Length > 13) {
							Ranorex.Report.Failure("Field REQUEST_ID expected to be length between or equal to 1 and 13, has length of {" + messagecontent.REQUEST_ID.Length.ToString() + "}.");
						}
					}
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

				if (content.FIELD_COUNT != null) {
					messagecontent.FIELD_COUNT = content.FIELD_COUNT[0].Value;
					if (messagecontent.FIELD_COUNT != null) {
						if (messagecontent.FIELD_COUNT.Length < 1 || messagecontent.FIELD_COUNT.Length > 2) {
							Ranorex.Report.Failure("Field FIELD_COUNT expected to be length between or equal to 1 and 2, has length of {" + messagecontent.FIELD_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.FIELD_COUNT)) {
							Ranorex.Report.Failure("Field FIELD_COUNT expected to be Numeric, has value of {" + messagecontent.FIELD_COUNT + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.FIELD_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field FIELD_COUNT expected to have value between 1 and 99, but was found to have a value of " + messagecontent.FIELD_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field FIELD_COUNT is a Mandatory field but was found to be missing from the message");
				}
				if (content.FIELD_RECORD != null) {
					for (int i = 0; i < content.FIELD_RECORD.Length; i++) {
						RUM_DR_BICRFIELD_RECORD_1 field_record = new RUM_DR_BICRFIELD_RECORD_1();

						if (content.FIELD_RECORD[i].FIELD_NUMBER != null) {
							field_record.FIELD_NUMBER = content.FIELD_RECORD[i].FIELD_NUMBER[0].Value;
							if (field_record.FIELD_NUMBER != null) {
								if (field_record.FIELD_NUMBER.Length < 1 || field_record.FIELD_NUMBER.Length > 2) {
									Ranorex.Report.Failure("Field FIELD_NUMBER expected to be length between or equal to 1 and 2, has length of {" + field_record.FIELD_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(field_record.FIELD_NUMBER)) {
									Ranorex.Report.Failure("Field FIELD_NUMBER expected to be Numeric, has value of {" + field_record.FIELD_NUMBER + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(field_record.FIELD_NUMBER);
									if (intConvertedValue < 1 || intConvertedValue > 99) {
										Ranorex.Report.Failure("Field FIELD_NUMBER expected to have value between 1 and 99, but was found to have a value of " + field_record.FIELD_NUMBER + ".");
									}
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

						if (content.FIELD_RECORD[i].FIELD_SIZE != null) {
							field_record.FIELD_SIZE = content.FIELD_RECORD[i].FIELD_SIZE[0].Value;
							if (field_record.FIELD_SIZE != null) {
								if (field_record.FIELD_SIZE.Length < 1 || field_record.FIELD_SIZE.Length > 3) {
									Ranorex.Report.Failure("Field FIELD_SIZE expected to be length between or equal to 1 and 3, has length of {" + field_record.FIELD_SIZE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(field_record.FIELD_SIZE)) {
									Ranorex.Report.Failure("Field FIELD_SIZE expected to be Numeric, has value of {" + field_record.FIELD_SIZE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(field_record.FIELD_SIZE);
									if (intConvertedValue < 1 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field FIELD_SIZE expected to have value between 1 and 999, but was found to have a value of " + field_record.FIELD_SIZE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field FIELD_SIZE is a Mandatory field but was found to be missing from the message");
						}

						if (content.FIELD_RECORD[i].FIXED_TEXT_BEFORE != null) {
							field_record.FIXED_TEXT_BEFORE = content.FIELD_RECORD[i].FIXED_TEXT_BEFORE[0].Value;
							if (field_record.FIXED_TEXT_BEFORE != null) {
								if (field_record.FIXED_TEXT_BEFORE.Length < 1 || field_record.FIXED_TEXT_BEFORE.Length > 60) {
									Ranorex.Report.Failure("Field FIXED_TEXT_BEFORE expected to be length between or equal to 1 and 60, has length of {" + field_record.FIXED_TEXT_BEFORE.Length.ToString() + "}.");
								}
							}
						}

						if (content.FIELD_RECORD[i].FIXED_TEXT_AFTER != null) {
							field_record.FIXED_TEXT_AFTER = content.FIELD_RECORD[i].FIXED_TEXT_AFTER[0].Value;
							if (field_record.FIXED_TEXT_AFTER != null) {
								if (field_record.FIXED_TEXT_AFTER.Length < 1 || field_record.FIXED_TEXT_AFTER.Length > 60) {
									Ranorex.Report.Failure("Field FIXED_TEXT_AFTER expected to be length between or equal to 1 and 60, has length of {" + field_record.FIXED_TEXT_AFTER.Length.ToString() + "}.");
								}
							}
						}

						if (content.FIELD_RECORD[i].REQUIRED != null) {
							field_record.REQUIRED = content.FIELD_RECORD[i].REQUIRED[0].Value;
							if (field_record.REQUIRED != null) {
								if (field_record.REQUIRED.Length != 1) {
									Ranorex.Report.Failure("Field REQUIRED expected to be length of 1, has length of {" + field_record.REQUIRED.Length.ToString() + "}.");
								}
								if (ContainsDigits(field_record.REQUIRED)) {
									Ranorex.Report.Failure("Field REQUIRED expected to be Alphabetic, has value of {" + field_record.REQUIRED + "}.");
								}
								if (field_record.REQUIRED != "Y" && field_record.REQUIRED != "N") {
									Ranorex.Report.Failure("Field REQUIRED expected to be one of the following values {Y, N}, but was found to be {" + field_record.REQUIRED + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field REQUIRED is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addFIELD_RECORD(field_record);
					}
				}

				dr_bicr_1.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return dr_bicr_1;
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
	public partial class RUM_DR_BICRHEADER_1 {
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

	public partial class RUM_DR_BICRCONTENT_1 {
		public string REQUEST_ID = "";
		public string BULLETIN_ITEM_TYPE = "";
		public string FIELD_COUNT = "";
		public ArrayList FIELD_RECORD = new ArrayList();

		public void addFIELD_RECORD(RUM_DR_BICRFIELD_RECORD_1 field_record) {
			this.FIELD_RECORD.Add(field_record);
		}
	}

	public partial class RUM_DR_BICRFIELD_RECORD_1 {
		public string FIELD_NUMBER = "";
		public string FIELD_NAME = "";
		public string FIELD_SIZE = "";
		public string FIXED_TEXT_BEFORE = "";
		public string FIXED_TEXT_AFTER = "";
		public string REQUIRED = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DR_BICR_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DR_BICRHEADER_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DR_BICRCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_1 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_EVENT_DATE_1[] EVENT_DATE;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_EVENT_TIME_1[] EVENT_TIME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_MESSAGE_ID_1[] MESSAGE_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_SEQUENCE_NUMBER_1[] SEQUENCE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_MESSAGE_VERSION_1[] MESSAGE_VERSION;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_SOURCE_SYS_1[] SOURCE_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_DESTINATION_SYS_1[] DESTINATION_SYS;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_DISTRICT_NAME_1[] DISTRICT_NAME;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_DISTRICT_SCAC_1[] DISTRICT_SCAC;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_USER_ID_1[] USER_ID;

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DIVISION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRHEADER_DIVISION_NAME_1[] DIVISION_NAME;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_EVENT_DATE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_EVENT_TIME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_MESSAGE_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_SEQUENCE_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_MESSAGE_VERSION_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_SOURCE_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_DESTINATION_SYS_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_DISTRICT_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_DISTRICT_SCAC_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_USER_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRHEADER_DIVISION_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRCONTENT_1 {
		[System.Xml.Serialization.XmlElementAttribute("REQUEST_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRCONTENT_REQUEST_ID_1[] REQUEST_ID;

		[System.Xml.Serialization.XmlElementAttribute("BULLETIN_ITEM_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRCONTENT_BULLETIN_ITEM_TYPE_1[] BULLETIN_ITEM_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRCONTENT_FIELD_COUNT_1[] FIELD_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRCONTENT_FIELD_RECORD_1[] FIELD_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRCONTENT_REQUEST_ID_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRCONTENT_BULLETIN_ITEM_TYPE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRCONTENT_FIELD_COUNT_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRCONTENT_FIELD_RECORD_1 {
		[System.Xml.Serialization.XmlElementAttribute("FIELD_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_FIELD_NUMBER_1[] FIELD_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_FIELD_NAME_1[] FIELD_NAME;

		[System.Xml.Serialization.XmlElementAttribute("FIELD_SIZE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_FIELD_SIZE_1[] FIELD_SIZE;

		[System.Xml.Serialization.XmlElementAttribute("FIXED_TEXT_BEFORE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_FIXED_TEXT_BEFORE_1[] FIXED_TEXT_BEFORE;

		[System.Xml.Serialization.XmlElementAttribute("FIXED_TEXT_AFTER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_FIXED_TEXT_AFTER_1[] FIXED_TEXT_AFTER;

		[System.Xml.Serialization.XmlElementAttribute("REQUIRED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public DR_BICRFIELD_RECORD_REQUIRED_1[] REQUIRED;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_FIELD_NUMBER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_FIELD_NAME_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_FIELD_SIZE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_FIXED_TEXT_BEFORE_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_FIXED_TEXT_AFTER_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DR_BICRFIELD_RECORD_REQUIRED_1 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}