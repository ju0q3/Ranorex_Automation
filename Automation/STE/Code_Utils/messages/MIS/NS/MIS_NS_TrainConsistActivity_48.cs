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
	public partial class MIS_NS_TrainConsistActivity_48 {
		public MIS_NS_TrainConsistActivityHEADER_48 HEADER;
		public MIS_NS_TrainConsistActivityCONTENT_48 CONTENT;

		public static MIS_NS_TrainConsistActivity_48 fromSerializableObject(NS_TrainConsistActivity_48 message) {
			MIS_NS_TrainConsistActivity_48 ns_trainconsistactivity_48 = new MIS_NS_TrainConsistActivity_48();
			NS_TrainConsistActivityHEADER_48 header = null;
			NS_TrainConsistActivityCONTENT_48 content = null;
			header = (NS_TrainConsistActivityHEADER_48) message.Items[0];
			content = (NS_TrainConsistActivityCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_TrainConsistActivityHEADER_48 messageheader = new MIS_NS_TrainConsistActivityHEADER_48();

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

				ns_trainconsistactivity_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_TrainConsistActivityCONTENT_48 messagecontent = new MIS_NS_TrainConsistActivityCONTENT_48();

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
							if (intConvertedValue < 0 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field SECTION expected to have value between 0 and 9, but was found to have a value of " + messagecontent.SECTION + ".");
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

				if (content.LOCATION != null) {
					messagecontent.LOCATION = content.LOCATION[0].Value;
					if (messagecontent.LOCATION != null) {
						if (messagecontent.LOCATION.Length < 1 || messagecontent.LOCATION.Length > 6) {
							Ranorex.Report.Failure("Field LOCATION expected to be length between or equal to 1 and 6, has length of {" + messagecontent.LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.PASS_COUNT != null) {
					messagecontent.PASS_COUNT = content.PASS_COUNT[0].Value;
					if (messagecontent.PASS_COUNT != null) {
						if (messagecontent.PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field PASS_COUNT expected to be length of 1, has length of {" + messagecontent.PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.PASS_COUNT)) {
							Ranorex.Report.Failure("Field PASS_COUNT expected to be Numeric, has value of {" + messagecontent.PASS_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field PASS_COUNT is a Mandatory field but was found to be missing from the message");
				}

				if (content.REPORTING_SOURCE != null) {
					messagecontent.REPORTING_SOURCE = content.REPORTING_SOURCE[0].Value;
					if (messagecontent.REPORTING_SOURCE != null) {
						if (messagecontent.REPORTING_SOURCE.Length != 1) {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be length of 1, has length of {" + messagecontent.REPORTING_SOURCE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.REPORTING_SOURCE)) {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be Alphabetic, has value of {" + messagecontent.REPORTING_SOURCE + "}.");
						}
						if (messagecontent.REPORTING_SOURCE != "T" && messagecontent.REPORTING_SOURCE != "") {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be one of the following values {T, }, but was found to be {" + messagecontent.REPORTING_SOURCE + "}.");
						}
					}
				}

				if (content.ESTIMATED_DWELL_INTERVAL != null) {
					messagecontent.ESTIMATED_DWELL_INTERVAL = content.ESTIMATED_DWELL_INTERVAL[0].Value;
					if (messagecontent.ESTIMATED_DWELL_INTERVAL != null) {
						if (messagecontent.ESTIMATED_DWELL_INTERVAL.Length != 4) {
							Ranorex.Report.Failure("Field ESTIMATED_DWELL_INTERVAL expected to be length of 4, has length of {" + messagecontent.ESTIMATED_DWELL_INTERVAL.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.ESTIMATED_DWELL_INTERVAL)) {
							Ranorex.Report.Failure("Field ESTIMATED_DWELL_INTERVAL expected to be Numeric, has value of {" + messagecontent.ESTIMATED_DWELL_INTERVAL + "}.");
						}
					}
				}

				if (content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR != null) {
					messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR = content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR[0].Value;
					if (messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR != null) {
						if (messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR expected to be length of 1, has length of {" + messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR)) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR expected to be Alphabetic, has value of {" + messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR + "}.");
						}
						if (messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR != "Y" && messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR != "N") {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR is a Mandatory field but was found to be missing from the message");
				}

				if (content.MAX_CAR_WEIGHT != null) {
					messagecontent.MAX_CAR_WEIGHT = content.MAX_CAR_WEIGHT[0].Value;
					if (messagecontent.MAX_CAR_WEIGHT != null) {
						if (messagecontent.MAX_CAR_WEIGHT.Length < 1 || messagecontent.MAX_CAR_WEIGHT.Length > 6) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT expected to be length between or equal to 1 and 6, has length of {" + messagecontent.MAX_CAR_WEIGHT.Length.ToString() + "}.");
						}
					}
				}

				if (content.MAX_CAR_WEIGHT_TO != null) {
					messagecontent.MAX_CAR_WEIGHT_TO = content.MAX_CAR_WEIGHT_TO[0].Value;
					if (messagecontent.MAX_CAR_WEIGHT_TO != null) {
						if (messagecontent.MAX_CAR_WEIGHT_TO.Length < 1 || messagecontent.MAX_CAR_WEIGHT_TO.Length > 6) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO expected to be length between or equal to 1 and 6, has length of {" + messagecontent.MAX_CAR_WEIGHT_TO.Length.ToString() + "}.");
						}
					}
				}

				if (content.MAX_CAR_WEIGHT_TO_PASS_COUNT != null) {
					messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT = content.MAX_CAR_WEIGHT_TO_PASS_COUNT[0].Value;
					if (messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT != null) {
						if (messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT)) {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.MAX_CAR_WEIGHT_TO_PASS_COUNT + "}.");
						}
					}
				}

				if (content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR != null) {
					messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR = content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR[0].Value;
					if (messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR != null) {
						if (messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR expected to be length of 1, has length of {" + messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR)) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR expected to be Alphabetic, has value of {" + messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR + "}.");
						}
						if (messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR != "Y" && messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR != "N") {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR is a Mandatory field but was found to be missing from the message");
				}

				if (content.MAX_CAR_HEIGHT != null) {
					messagecontent.MAX_CAR_HEIGHT = content.MAX_CAR_HEIGHT[0].Value;
					if (messagecontent.MAX_CAR_HEIGHT != null) {
						if (messagecontent.MAX_CAR_HEIGHT.Length < 1 || messagecontent.MAX_CAR_HEIGHT.Length > 4) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT expected to be length between or equal to 1 and 4, has length of {" + messagecontent.MAX_CAR_HEIGHT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.MAX_CAR_HEIGHT)) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT expected to be Numeric, has value of {" + messagecontent.MAX_CAR_HEIGHT + "}.");
						}
					}
				}

				if (content.MAX_CAR_HEIGHT_TO != null) {
					messagecontent.MAX_CAR_HEIGHT_TO = content.MAX_CAR_HEIGHT_TO[0].Value;
					if (messagecontent.MAX_CAR_HEIGHT_TO != null) {
						if (messagecontent.MAX_CAR_HEIGHT_TO.Length < 1 || messagecontent.MAX_CAR_HEIGHT_TO.Length > 6) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO expected to be length between or equal to 1 and 6, has length of {" + messagecontent.MAX_CAR_HEIGHT_TO.Length.ToString() + "}.");
						}
					}
				}

				if (content.MAX_CAR_HEIGHT_TO_PASS_COUNT != null) {
					messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT = content.MAX_CAR_HEIGHT_TO_PASS_COUNT[0].Value;
					if (messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT != null) {
						if (messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT)) {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.MAX_CAR_HEIGHT_TO_PASS_COUNT + "}.");
						}
					}
				}

				if (content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR != null) {
					messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR = content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR[0].Value;
					if (messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR != null) {
						if (messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_CONSTRAINT_INDICATOR expected to be length of 1, has length of {" + messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR)) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_CONSTRAINT_INDICATOR expected to be Alphabetic, has value of {" + messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR + "}.");
						}
						if (messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR != "Y" && messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR != "N") {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_CONSTRAINT_INDICATOR expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field MAX_CAR_WIDTH_CONSTRAINT_INDICATOR is a Mandatory field but was found to be missing from the message");
				}

				if (content.MAX_CAR_WIDTH != null) {
					messagecontent.MAX_CAR_WIDTH = content.MAX_CAR_WIDTH[0].Value;
					if (messagecontent.MAX_CAR_WIDTH != null) {
						if (messagecontent.MAX_CAR_WIDTH.Length < 1 || messagecontent.MAX_CAR_WIDTH.Length > 4) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH expected to be length between or equal to 1 and 4, has length of {" + messagecontent.MAX_CAR_WIDTH.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.MAX_CAR_WIDTH)) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH expected to be Numeric, has value of {" + messagecontent.MAX_CAR_WIDTH + "}.");
						}
					}
				}

				if (content.MAX_CAR_WIDTH_TO != null) {
					messagecontent.MAX_CAR_WIDTH_TO = content.MAX_CAR_WIDTH_TO[0].Value;
					if (messagecontent.MAX_CAR_WIDTH_TO != null) {
						if (messagecontent.MAX_CAR_WIDTH_TO.Length < 1 || messagecontent.MAX_CAR_WIDTH_TO.Length > 6) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO expected to be length between or equal to 1 and 6, has length of {" + messagecontent.MAX_CAR_WIDTH_TO.Length.ToString() + "}.");
						}
					}
				}

				if (content.MAX_CAR_WIDTH_TO_PASS_COUNT != null) {
					messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT = content.MAX_CAR_WIDTH_TO_PASS_COUNT[0].Value;
					if (messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT != null) {
						if (messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT)) {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.MAX_CAR_WIDTH_TO_PASS_COUNT + "}.");
						}
					}
				}

				if (content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR != null) {
					messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR = content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR[0].Value;
					if (messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR != null) {
						if (messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR.Length != 1) {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_CONSTRAINT_INDICATOR expected to be length of 1, has length of {" + messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR)) {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_CONSTRAINT_INDICATOR expected to be Alphabetic, has value of {" + messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR + "}.");
						}
						if (messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR != "Y" && messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR != "N") {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_CONSTRAINT_INDICATOR expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.HAZMAT_TRAIN_CONSTRAINT_INDICATOR + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field HAZMAT_TRAIN_CONSTRAINT_INDICATOR is a Mandatory field but was found to be missing from the message");
				}

				if (content.KEY_TRAIN_INDICATOR != null) {
					messagecontent.KEY_TRAIN_INDICATOR = content.KEY_TRAIN_INDICATOR[0].Value;
					if (messagecontent.KEY_TRAIN_INDICATOR != null) {
						if (messagecontent.KEY_TRAIN_INDICATOR.Length != 1) {
							Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR expected to be length of 1, has length of {" + messagecontent.KEY_TRAIN_INDICATOR.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.KEY_TRAIN_INDICATOR)) {
							Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR expected to be Alphabetic, has value of {" + messagecontent.KEY_TRAIN_INDICATOR + "}.");
						}
					}
				}

				if (content.HAZMAT_TRAIN_TO != null) {
					messagecontent.HAZMAT_TRAIN_TO = content.HAZMAT_TRAIN_TO[0].Value;
					if (messagecontent.HAZMAT_TRAIN_TO != null) {
						if (messagecontent.HAZMAT_TRAIN_TO.Length < 1 || messagecontent.HAZMAT_TRAIN_TO.Length > 6) {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_TO expected to be length between or equal to 1 and 6, has length of {" + messagecontent.HAZMAT_TRAIN_TO.Length.ToString() + "}.");
						}
					}
				}

				if (content.HAZMAT_TRAIN_TO_PASS_COUNT != null) {
					messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT = content.HAZMAT_TRAIN_TO_PASS_COUNT[0].Value;
					if (messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT != null) {
						if (messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_TO_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT)) {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_TO_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.HAZMAT_TRAIN_TO_PASS_COUNT + "}.");
						}
					}
				}

				if (content.NUMBER_OF_PICKUP_SETOUT_RECORDS != null) {
					messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS = content.NUMBER_OF_PICKUP_SETOUT_RECORDS[0].Value;
					if (messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS != null) {
						if (messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS.Length != 1) {
							Ranorex.Report.Failure("Field NUMBER_OF_PICKUP_SETOUT_RECORDS expected to be length of 1, has length of {" + messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_PICKUP_SETOUT_RECORDS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS);
							if (intConvertedValue < 0 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field NUMBER_OF_PICKUP_SETOUT_RECORDS expected to have value between 0 and 9, but was found to have a value of " + messagecontent.NUMBER_OF_PICKUP_SETOUT_RECORDS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_PICKUP_SETOUT_RECORDS is a Mandatory field but was found to be missing from the message");
				}
				if (content.PICKUP_SETOUT_RECORD != null) {
					for (int i = 0; i < content.PICKUP_SETOUT_RECORD.Length; i++) {
						MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48 pickup_setout_record = new MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48();

						if (content.PICKUP_SETOUT_RECORD[i].REPORT_CONSIST_CHANGE_FLAG != null) {
							pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG = content.PICKUP_SETOUT_RECORD[i].REPORT_CONSIST_CHANGE_FLAG[0].Value;
							if (pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG != null) {
								if (pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG.Length != 1) {
									Ranorex.Report.Failure("Field REPORT_CONSIST_CHANGE_FLAG expected to be length of 1, has length of {" + pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG.Length.ToString() + "}.");
								}
								if (pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG != "Y" && pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG != "N") {
									Ranorex.Report.Failure("Field REPORT_CONSIST_CHANGE_FLAG expected to be one of the following values {Y, N}, but was found to be {" + pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field REPORT_CONSIST_CHANGE_FLAG is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].CONSIST_OPERATION != null) {
							pickup_setout_record.CONSIST_OPERATION = content.PICKUP_SETOUT_RECORD[i].CONSIST_OPERATION[0].Value;
							if (pickup_setout_record.CONSIST_OPERATION != null) {
								if (pickup_setout_record.CONSIST_OPERATION.Length != 1) {
									Ranorex.Report.Failure("Field CONSIST_OPERATION expected to be length of 1, has length of {" + pickup_setout_record.CONSIST_OPERATION.Length.ToString() + "}.");
								}
								if (ContainsDigits(pickup_setout_record.CONSIST_OPERATION)) {
									Ranorex.Report.Failure("Field CONSIST_OPERATION expected to be Alphabetic, has value of {" + pickup_setout_record.CONSIST_OPERATION + "}.");
								}
								if (pickup_setout_record.CONSIST_OPERATION != "P" && pickup_setout_record.CONSIST_OPERATION != "S" && pickup_setout_record.CONSIST_OPERATION != "O") {
									Ranorex.Report.Failure("Field CONSIST_OPERATION expected to be one of the following values {P, S, O}, but was found to be {" + pickup_setout_record.CONSIST_OPERATION + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field CONSIST_OPERATION is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].NUMBER_OF_LOADS != null) {
							pickup_setout_record.NUMBER_OF_LOADS = content.PICKUP_SETOUT_RECORD[i].NUMBER_OF_LOADS[0].Value;
							if (pickup_setout_record.NUMBER_OF_LOADS != null) {
								if (pickup_setout_record.NUMBER_OF_LOADS.Length < 1 || pickup_setout_record.NUMBER_OF_LOADS.Length > 3) {
									Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to be length between or equal to 1 and 3, has length of {" + pickup_setout_record.NUMBER_OF_LOADS.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.NUMBER_OF_LOADS)) {
									Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to be Numeric, has value of {" + pickup_setout_record.NUMBER_OF_LOADS + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.NUMBER_OF_LOADS);
									if (intConvertedValue < 0 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to have value between 0 and 999, but was found to have a value of " + pickup_setout_record.NUMBER_OF_LOADS + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field NUMBER_OF_LOADS is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].NUMBER_OF_EMPTIES != null) {
							pickup_setout_record.NUMBER_OF_EMPTIES = content.PICKUP_SETOUT_RECORD[i].NUMBER_OF_EMPTIES[0].Value;
							if (pickup_setout_record.NUMBER_OF_EMPTIES != null) {
								if (pickup_setout_record.NUMBER_OF_EMPTIES.Length < 1 || pickup_setout_record.NUMBER_OF_EMPTIES.Length > 3) {
									Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to be length between or equal to 1 and 3, has length of {" + pickup_setout_record.NUMBER_OF_EMPTIES.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.NUMBER_OF_EMPTIES)) {
									Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to be Numeric, has value of {" + pickup_setout_record.NUMBER_OF_EMPTIES + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.NUMBER_OF_EMPTIES);
									if (intConvertedValue < 0 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to have value between 0 and 999, but was found to have a value of " + pickup_setout_record.NUMBER_OF_EMPTIES + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].TONNAGE != null) {
							pickup_setout_record.TONNAGE = content.PICKUP_SETOUT_RECORD[i].TONNAGE[0].Value;
							if (pickup_setout_record.TONNAGE != null) {
								if (pickup_setout_record.TONNAGE.Length < 1 || pickup_setout_record.TONNAGE.Length > 5) {
									Ranorex.Report.Failure("Field TONNAGE expected to be length between or equal to 1 and 5, has length of {" + pickup_setout_record.TONNAGE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.TONNAGE)) {
									Ranorex.Report.Failure("Field TONNAGE expected to be Numeric, has value of {" + pickup_setout_record.TONNAGE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.TONNAGE);
									if (intConvertedValue < 0 || intConvertedValue > 99999) {
										Ranorex.Report.Failure("Field TONNAGE expected to have value between 0 and 99999, but was found to have a value of " + pickup_setout_record.TONNAGE + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field TONNAGE is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].LENGTH != null) {
							pickup_setout_record.LENGTH = content.PICKUP_SETOUT_RECORD[i].LENGTH[0].Value;
							if (pickup_setout_record.LENGTH != null) {
								if (pickup_setout_record.LENGTH.Length < 1 || pickup_setout_record.LENGTH.Length > 5) {
									Ranorex.Report.Failure("Field LENGTH expected to be length between or equal to 1 and 5, has length of {" + pickup_setout_record.LENGTH.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.LENGTH)) {
									Ranorex.Report.Failure("Field LENGTH expected to be Numeric, has value of {" + pickup_setout_record.LENGTH + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.LENGTH);
									if (intConvertedValue < 0 || intConvertedValue > 99999) {
										Ranorex.Report.Failure("Field LENGTH expected to have value between 0 and 99999, but was found to have a value of " + pickup_setout_record.LENGTH + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field LENGTH is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].COAL_INDICATOR != null) {
							pickup_setout_record.COAL_INDICATOR = content.PICKUP_SETOUT_RECORD[i].COAL_INDICATOR[0].Value;
							if (pickup_setout_record.COAL_INDICATOR != null) {
								if (pickup_setout_record.COAL_INDICATOR.Length != 1) {
									Ranorex.Report.Failure("Field COAL_INDICATOR expected to be length of 1, has length of {" + pickup_setout_record.COAL_INDICATOR.Length.ToString() + "}.");
								}
								if (ContainsDigits(pickup_setout_record.COAL_INDICATOR)) {
									Ranorex.Report.Failure("Field COAL_INDICATOR expected to be Alphabetic, has value of {" + pickup_setout_record.COAL_INDICATOR + "}.");
								}
								if (pickup_setout_record.COAL_INDICATOR != "Y" && pickup_setout_record.COAL_INDICATOR != "N") {
									Ranorex.Report.Failure("Field COAL_INDICATOR expected to be one of the following values {Y, N}, but was found to be {" + pickup_setout_record.COAL_INDICATOR + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field COAL_INDICATOR is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].COAL_PERMIT_NUMBER != null) {
							pickup_setout_record.COAL_PERMIT_NUMBER = content.PICKUP_SETOUT_RECORD[i].COAL_PERMIT_NUMBER[0].Value;
							if (pickup_setout_record.COAL_PERMIT_NUMBER != null) {
								if (pickup_setout_record.COAL_PERMIT_NUMBER.Length < 0 || pickup_setout_record.COAL_PERMIT_NUMBER.Length > 8) {
									Ranorex.Report.Failure("Field COAL_PERMIT_NUMBER expected to be length between or equal to 0 and 8, has length of {" + pickup_setout_record.COAL_PERMIT_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.COAL_PERMIT_NUMBER)) {
									Ranorex.Report.Failure("Field COAL_PERMIT_NUMBER expected to be Numeric, has value of {" + pickup_setout_record.COAL_PERMIT_NUMBER + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field COAL_PERMIT_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.PICKUP_SETOUT_RECORD[i].NOTE != null) {
							pickup_setout_record.NOTE = content.PICKUP_SETOUT_RECORD[i].NOTE[0].Value;
							if (pickup_setout_record.NOTE != null) {
								if (pickup_setout_record.NOTE.Length < 0 || pickup_setout_record.NOTE.Length > 500) {
									Ranorex.Report.Failure("Field NOTE expected to be length between or equal to 0 and 500, has length of {" + pickup_setout_record.NOTE.Length.ToString() + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].COMPLETION_STATUS != null) {
							pickup_setout_record.COMPLETION_STATUS = content.PICKUP_SETOUT_RECORD[i].COMPLETION_STATUS[0].Value;
							if (pickup_setout_record.COMPLETION_STATUS != null) {
								if (pickup_setout_record.COMPLETION_STATUS.Length != 1) {
									Ranorex.Report.Failure("Field COMPLETION_STATUS expected to be length of 1, has length of {" + pickup_setout_record.COMPLETION_STATUS.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.COMPLETION_STATUS)) {
									Ranorex.Report.Failure("Field COMPLETION_STATUS expected to be Numeric, has value of {" + pickup_setout_record.COMPLETION_STATUS + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.COMPLETION_STATUS);
									if (intConvertedValue < 1 || intConvertedValue > 4) {
										Ranorex.Report.Failure("Field COMPLETION_STATUS expected to have value between 1 and 4, but was found to have a value of " + pickup_setout_record.COMPLETION_STATUS + ".");
									}
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].COMPLETION_DATE != null) {
							pickup_setout_record.COMPLETION_DATE = content.PICKUP_SETOUT_RECORD[i].COMPLETION_DATE[0].Value;
							if (pickup_setout_record.COMPLETION_DATE != null) {
								if (pickup_setout_record.COMPLETION_DATE.Length != 8) {
									Ranorex.Report.Failure("Field COMPLETION_DATE expected to be length of 8, has length of {" + pickup_setout_record.COMPLETION_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.COMPLETION_DATE)) {
									Ranorex.Report.Failure("Field COMPLETION_DATE expected to be Numeric, has value of {" + pickup_setout_record.COMPLETION_DATE + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].COMPLETION_TIME != null) {
							pickup_setout_record.COMPLETION_TIME = content.PICKUP_SETOUT_RECORD[i].COMPLETION_TIME[0].Value;
							if (pickup_setout_record.COMPLETION_TIME != null) {
								if (pickup_setout_record.COMPLETION_TIME.Length != 4) {
									Ranorex.Report.Failure("Field COMPLETION_TIME expected to be length of 4, has length of {" + pickup_setout_record.COMPLETION_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.COMPLETION_TIME)) {
									Ranorex.Report.Failure("Field COMPLETION_TIME expected to be Numeric, has value of {" + pickup_setout_record.COMPLETION_TIME + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].COMPLETION_TIME_ZONE != null) {
							pickup_setout_record.COMPLETION_TIME_ZONE = content.PICKUP_SETOUT_RECORD[i].COMPLETION_TIME_ZONE[0].Value;
							if (pickup_setout_record.COMPLETION_TIME_ZONE != null) {
								if (pickup_setout_record.COMPLETION_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field COMPLETION_TIME_ZONE expected to be length of 1, has length of {" + pickup_setout_record.COMPLETION_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(pickup_setout_record.COMPLETION_TIME_ZONE)) {
									Ranorex.Report.Failure("Field COMPLETION_TIME_ZONE expected to be Alphabetic, has value of {" + pickup_setout_record.COMPLETION_TIME_ZONE + "}.");
								}
								if (pickup_setout_record.COMPLETION_TIME_ZONE != "E" && pickup_setout_record.COMPLETION_TIME_ZONE != "C") {
									Ranorex.Report.Failure("Field COMPLETION_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + pickup_setout_record.COMPLETION_TIME_ZONE + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].NEED_DATE != null) {
							pickup_setout_record.NEED_DATE = content.PICKUP_SETOUT_RECORD[i].NEED_DATE[0].Value;
							if (pickup_setout_record.NEED_DATE != null) {
								if (pickup_setout_record.NEED_DATE.Length != 8) {
									Ranorex.Report.Failure("Field NEED_DATE expected to be length of 8, has length of {" + pickup_setout_record.NEED_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.NEED_DATE)) {
									Ranorex.Report.Failure("Field NEED_DATE expected to be Numeric, has value of {" + pickup_setout_record.NEED_DATE + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].NEED_TIME != null) {
							pickup_setout_record.NEED_TIME = content.PICKUP_SETOUT_RECORD[i].NEED_TIME[0].Value;
							if (pickup_setout_record.NEED_TIME != null) {
								if (pickup_setout_record.NEED_TIME.Length != 4) {
									Ranorex.Report.Failure("Field NEED_TIME expected to be length of 4, has length of {" + pickup_setout_record.NEED_TIME.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.NEED_TIME)) {
									Ranorex.Report.Failure("Field NEED_TIME expected to be Numeric, has value of {" + pickup_setout_record.NEED_TIME + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].NEED_TIME_ZONE != null) {
							pickup_setout_record.NEED_TIME_ZONE = content.PICKUP_SETOUT_RECORD[i].NEED_TIME_ZONE[0].Value;
							if (pickup_setout_record.NEED_TIME_ZONE != null) {
								if (pickup_setout_record.NEED_TIME_ZONE.Length != 1) {
									Ranorex.Report.Failure("Field NEED_TIME_ZONE expected to be length of 1, has length of {" + pickup_setout_record.NEED_TIME_ZONE.Length.ToString() + "}.");
								}
								if (ContainsDigits(pickup_setout_record.NEED_TIME_ZONE)) {
									Ranorex.Report.Failure("Field NEED_TIME_ZONE expected to be Alphabetic, has value of {" + pickup_setout_record.NEED_TIME_ZONE + "}.");
								}
								if (pickup_setout_record.NEED_TIME_ZONE != "E" && pickup_setout_record.NEED_TIME_ZONE != "C") {
									Ranorex.Report.Failure("Field NEED_TIME_ZONE expected to be one of the following values {E, C}, but was found to be {" + pickup_setout_record.NEED_TIME_ZONE + "}.");
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].AXLES != null) {
							pickup_setout_record.AXLES = content.PICKUP_SETOUT_RECORD[i].AXLES[0].Value;
							if (pickup_setout_record.AXLES != null) {
								if (pickup_setout_record.AXLES.Length < 1 || pickup_setout_record.AXLES.Length > 4) {
									Ranorex.Report.Failure("Field AXLES expected to be length between or equal to 1 and 4, has length of {" + pickup_setout_record.AXLES.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.AXLES)) {
									Ranorex.Report.Failure("Field AXLES expected to be Numeric, has value of {" + pickup_setout_record.AXLES + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.AXLES);
									if (intConvertedValue < 0 || intConvertedValue > 3996) {
										Ranorex.Report.Failure("Field AXLES expected to have value between 0 and 3996, but was found to have a value of " + pickup_setout_record.AXLES + ".");
									}
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].OPERATIVE_BRAKES != null) {
							pickup_setout_record.OPERATIVE_BRAKES = content.PICKUP_SETOUT_RECORD[i].OPERATIVE_BRAKES[0].Value;
							if (pickup_setout_record.OPERATIVE_BRAKES != null) {
								if (pickup_setout_record.OPERATIVE_BRAKES.Length < 1 || pickup_setout_record.OPERATIVE_BRAKES.Length > 3) {
									Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to be length between or equal to 1 and 3, has length of {" + pickup_setout_record.OPERATIVE_BRAKES.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.OPERATIVE_BRAKES)) {
									Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to be Numeric, has value of {" + pickup_setout_record.OPERATIVE_BRAKES + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.OPERATIVE_BRAKES);
									if (intConvertedValue < 0 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to have value between 0 and 999, but was found to have a value of " + pickup_setout_record.OPERATIVE_BRAKES + ".");
									}
								}
							}
						}

						if (content.PICKUP_SETOUT_RECORD[i].TOTAL_BRAKING_FORCE != null) {
							pickup_setout_record.TOTAL_BRAKING_FORCE = content.PICKUP_SETOUT_RECORD[i].TOTAL_BRAKING_FORCE[0].Value;
							if (pickup_setout_record.TOTAL_BRAKING_FORCE != null) {
								if (pickup_setout_record.TOTAL_BRAKING_FORCE.Length < 1 || pickup_setout_record.TOTAL_BRAKING_FORCE.Length > 8) {
									Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to be length between or equal to 1 and 8, has length of {" + pickup_setout_record.TOTAL_BRAKING_FORCE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(pickup_setout_record.TOTAL_BRAKING_FORCE)) {
									Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to be Numeric, has value of {" + pickup_setout_record.TOTAL_BRAKING_FORCE + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(pickup_setout_record.TOTAL_BRAKING_FORCE);
									if (intConvertedValue < 0 || intConvertedValue > 30000000) {
										Ranorex.Report.Failure("Field TOTAL_BRAKING_FORCE expected to have value between 0 and 30000000, but was found to have a value of " + pickup_setout_record.TOTAL_BRAKING_FORCE + ".");
									}
								}
							}
						}

						messagecontent.addPICKUP_SETOUT_RECORD(pickup_setout_record);
					}
				}

				if (content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS != null) {
					messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS = content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS[0].Value;
					if (messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS != null) {
						if (messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS.Length != 1) {
							Ranorex.Report.Failure("Field NUMBER_OF_COAL_CLASSIFICATION_RECORDS expected to be length of 1, has length of {" + messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_COAL_CLASSIFICATION_RECORDS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS);
							if (intConvertedValue < 0 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field NUMBER_OF_COAL_CLASSIFICATION_RECORDS expected to have value between 0 and 9, but was found to have a value of " + messagecontent.NUMBER_OF_COAL_CLASSIFICATION_RECORDS + ".");
							}
						}
					}
				}
				if (content.COAL_CLASSIFICATION_RECORD != null) {
					for (int i = 0; i < content.COAL_CLASSIFICATION_RECORD.Length; i++) {
						MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48 coal_classification_record = new MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48();

						if (content.COAL_CLASSIFICATION_RECORD[i].COAL_CLASSIFICATION != null) {
							coal_classification_record.COAL_CLASSIFICATION = content.COAL_CLASSIFICATION_RECORD[i].COAL_CLASSIFICATION[0].Value;
							if (coal_classification_record.COAL_CLASSIFICATION != null) {
								if (coal_classification_record.COAL_CLASSIFICATION.Length < 1 || coal_classification_record.COAL_CLASSIFICATION.Length > 8) {
									Ranorex.Report.Failure("Field COAL_CLASSIFICATION expected to be length between or equal to 1 and 8, has length of {" + coal_classification_record.COAL_CLASSIFICATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.COAL_CLASSIFICATION_RECORD[i].NUMBER_OF_CARS != null) {
							coal_classification_record.NUMBER_OF_CARS = content.COAL_CLASSIFICATION_RECORD[i].NUMBER_OF_CARS[0].Value;
							if (coal_classification_record.NUMBER_OF_CARS != null) {
								if (coal_classification_record.NUMBER_OF_CARS.Length < 1 || coal_classification_record.NUMBER_OF_CARS.Length > 3) {
									Ranorex.Report.Failure("Field NUMBER_OF_CARS expected to be length between or equal to 1 and 3, has length of {" + coal_classification_record.NUMBER_OF_CARS.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(coal_classification_record.NUMBER_OF_CARS)) {
									Ranorex.Report.Failure("Field NUMBER_OF_CARS expected to be Numeric, has value of {" + coal_classification_record.NUMBER_OF_CARS + "}.");
								}
							}
						}

						messagecontent.addCOAL_CLASSIFICATION_RECORD(coal_classification_record);
					}
				}

				ns_trainconsistactivity_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_trainconsistactivity_48;
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

		public static void createNS_TrainConsistActivity_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_location,
			string content_pass_count,
			string content_reporting_source,
			string content_estimated_dwell_interval,
			string content_max_car_weight_constraint_indicator,
			string content_max_car_weight,
			string content_max_car_weight_to,
			string content_max_car_weight_to_pass_count,
			string content_max_car_height_constraint_indicator,
			string content_max_car_height,
			string content_max_car_height_to,
			string content_max_car_height_to_pass_count,
			string content_max_car_width_constraint_indicator,
			string content_max_car_width,
			string content_max_car_width_to,
			string content_max_car_width_to_pass_count,
			string content_hazmat_train_constraint_indicator,
			string content_key_train_indicator,
			string content_hazmat_train_to,
			string content_hazmat_train_to_pass_count,
			string content_number_of_pickup_setout_records,
			string content_pickup_setout_record,
			string content_number_of_coal_classification_records,
			string content_coal_classification_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainConsistActivity_48 mis_ns_trainconsistactivity = buildMIS_NS_TrainConsistActivity_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_location, content_pass_count, content_reporting_source, content_estimated_dwell_interval, content_max_car_weight_constraint_indicator, content_max_car_weight, content_max_car_weight_to, content_max_car_weight_to_pass_count, content_max_car_height_constraint_indicator, content_max_car_height, content_max_car_height_to, content_max_car_height_to_pass_count, content_max_car_width_constraint_indicator, content_max_car_width, content_max_car_width_to, content_max_car_width_to_pass_count, content_hazmat_train_constraint_indicator, content_key_train_indicator, content_hazmat_train_to, content_hazmat_train_to_pass_count, content_number_of_pickup_setout_records, content_pickup_setout_record, content_number_of_coal_classification_records, content_coal_classification_record);

			NS_TrainConsistActivity_48 ns_trainconsistactivity = mis_ns_trainconsistactivity.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainConsistActivity_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_trainconsistactivity);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainconsistactivity.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainconsistactivity.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainConsistActivity_48 buildMIS_NS_TrainConsistActivity_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_location,
			string content_pass_count,
			string content_reporting_source,
			string content_estimated_dwell_interval,
			string content_max_car_weight_constraint_indicator,
			string content_max_car_weight,
			string content_max_car_weight_to,
			string content_max_car_weight_to_pass_count,
			string content_max_car_height_constraint_indicator,
			string content_max_car_height,
			string content_max_car_height_to,
			string content_max_car_height_to_pass_count,
			string content_max_car_width_constraint_indicator,
			string content_max_car_width,
			string content_max_car_width_to,
			string content_max_car_width_to_pass_count,
			string content_hazmat_train_constraint_indicator,
			string content_key_train_indicator,
			string content_hazmat_train_to,
			string content_hazmat_train_to_pass_count,
			string content_number_of_pickup_setout_records,
			string content_pickup_setout_record,
			string content_number_of_coal_classification_records,
			string content_coal_classification_record
		) {

			MIS_NS_TrainConsistActivity_48 mis_ns_trainconsistactivity = new MIS_NS_TrainConsistActivity_48();

			MIS_NS_TrainConsistActivityHEADER_48 header = new MIS_NS_TrainConsistActivityHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainConsistActivityCONTENT_48 content = new MIS_NS_TrainConsistActivityCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.LOCATION = content_location;
			content.PASS_COUNT = content_pass_count;
			content.REPORTING_SOURCE = content_reporting_source;
			content.ESTIMATED_DWELL_INTERVAL = content_estimated_dwell_interval;
			content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR = content_max_car_weight_constraint_indicator;
			content.MAX_CAR_WEIGHT = content_max_car_weight;
			content.MAX_CAR_WEIGHT_TO = content_max_car_weight_to;
			content.MAX_CAR_WEIGHT_TO_PASS_COUNT = content_max_car_weight_to_pass_count;
			content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR = content_max_car_height_constraint_indicator;
			content.MAX_CAR_HEIGHT = content_max_car_height;
			content.MAX_CAR_HEIGHT_TO = content_max_car_height_to;
			content.MAX_CAR_HEIGHT_TO_PASS_COUNT = content_max_car_height_to_pass_count;
			content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR = content_max_car_width_constraint_indicator;
			content.MAX_CAR_WIDTH = content_max_car_width;
			content.MAX_CAR_WIDTH_TO = content_max_car_width_to;
			content.MAX_CAR_WIDTH_TO_PASS_COUNT = content_max_car_width_to_pass_count;
			content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR = content_hazmat_train_constraint_indicator;
			content.KEY_TRAIN_INDICATOR = content_key_train_indicator;
			content.HAZMAT_TRAIN_TO = content_hazmat_train_to;
			content.HAZMAT_TRAIN_TO_PASS_COUNT = content_hazmat_train_to_pass_count;
			content.NUMBER_OF_PICKUP_SETOUT_RECORDS = content_number_of_pickup_setout_records;
			if (content_pickup_setout_record != "") {
				string[] pickup_setout_recordList = content_pickup_setout_record.Split('|');
				for (int i = 0; i < pickup_setout_recordList.Length;) {
					MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48 pickup_setout_records = new MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48();
					pickup_setout_records.REPORT_CONSIST_CHANGE_FLAG = pickup_setout_recordList[i];i++;
					pickup_setout_records.CONSIST_OPERATION = pickup_setout_recordList[i];i++;
					pickup_setout_records.NUMBER_OF_LOADS = pickup_setout_recordList[i];i++;
					pickup_setout_records.NUMBER_OF_EMPTIES = pickup_setout_recordList[i];i++;
					pickup_setout_records.TONNAGE = pickup_setout_recordList[i];i++;
					pickup_setout_records.LENGTH = pickup_setout_recordList[i];i++;
					pickup_setout_records.COAL_INDICATOR = pickup_setout_recordList[i];i++;
					pickup_setout_records.COAL_PERMIT_NUMBER = pickup_setout_recordList[i];i++;
					pickup_setout_records.NOTE = pickup_setout_recordList[i];i++;
					pickup_setout_records.COMPLETION_STATUS = pickup_setout_recordList[i];i++;
					pickup_setout_records.COMPLETION_DATE = pickup_setout_recordList[i];i++;
					pickup_setout_records.COMPLETION_TIME = pickup_setout_recordList[i];i++;
					pickup_setout_records.COMPLETION_TIME_ZONE = pickup_setout_recordList[i];i++;
					pickup_setout_records.NEED_DATE = pickup_setout_recordList[i];i++;
					pickup_setout_records.NEED_TIME = pickup_setout_recordList[i];i++;
					pickup_setout_records.NEED_TIME_ZONE = pickup_setout_recordList[i];i++;
					pickup_setout_records.AXLES = pickup_setout_recordList[i];i++;
					pickup_setout_records.OPERATIVE_BRAKES = pickup_setout_recordList[i];i++;
					pickup_setout_records.TOTAL_BRAKING_FORCE = pickup_setout_recordList[i];i++;
					content.addPICKUP_SETOUT_RECORD(pickup_setout_records);
				}
			}
			content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS = content_number_of_coal_classification_records;
			if (content_coal_classification_record != "") {
				string[] coal_classification_recordList = content_coal_classification_record.Split('|');
				for (int i = 0; i < coal_classification_recordList.Length;) {
					MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48 coal_classification_records = new MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48();
					coal_classification_records.COAL_CLASSIFICATION = coal_classification_recordList[i];i++;
					coal_classification_records.NUMBER_OF_CARS = coal_classification_recordList[i];i++;
					content.addCOAL_CLASSIFICATION_RECORD(coal_classification_records);
				}
			}

			mis_ns_trainconsistactivity.HEADER = header;
			mis_ns_trainconsistactivity.CONTENT = content;
			return mis_ns_trainconsistactivity;
		}

		public NS_TrainConsistActivity_48 toSerializableObject() {
			NS_TrainConsistActivity_48 ns_trainconsistactivity_48 = new NS_TrainConsistActivity_48();
			ns_trainconsistactivity_48.Items = new object[2];

			NS_TrainConsistActivityHEADER_48 header = new NS_TrainConsistActivityHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainConsistActivityHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_TrainConsistActivityHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainConsistActivityHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_TrainConsistActivityHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_TrainConsistActivityHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_TrainConsistActivityHEADER_TRACE_ID_48();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_TrainConsistActivityHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_TrainConsistActivityHEADER_MESSAGE_VERSION_48();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_TrainConsistActivityCONTENT_48 content = new NS_TrainConsistActivityCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_TrainConsistActivityCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_TrainConsistActivityCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_TrainConsistActivityCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_TrainConsistActivityCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_TrainConsistActivityCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_TrainConsistActivityCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_TrainConsistActivityCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_TrainConsistActivityCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.LOCATION != "Null") {
					content.LOCATION = new NS_TrainConsistActivityCONTENT_LOCATION_48[1];
					content.LOCATION[0] = new NS_TrainConsistActivityCONTENT_LOCATION_48();
					content.LOCATION[0].Value = CONTENT.LOCATION;
				}

				if (CONTENT.PASS_COUNT != "Null") {
					content.PASS_COUNT = new NS_TrainConsistActivityCONTENT_PASS_COUNT_48[1];
					content.PASS_COUNT[0] = new NS_TrainConsistActivityCONTENT_PASS_COUNT_48();
					content.PASS_COUNT[0].Value = CONTENT.PASS_COUNT;
				}

				if (CONTENT.REPORTING_SOURCE != null && CONTENT.REPORTING_SOURCE != "") {
					content.REPORTING_SOURCE = new NS_TrainConsistActivityCONTENT_REPORTING_SOURCE_48[1];
					content.REPORTING_SOURCE[0] = new NS_TrainConsistActivityCONTENT_REPORTING_SOURCE_48();
					if (CONTENT.REPORTING_SOURCE == "Empty") {
						content.REPORTING_SOURCE[0].Value = "";
					} else {
						content.REPORTING_SOURCE[0].Value = CONTENT.REPORTING_SOURCE;
					}
				}

				if (CONTENT.ESTIMATED_DWELL_INTERVAL != null && CONTENT.ESTIMATED_DWELL_INTERVAL != "") {
					content.ESTIMATED_DWELL_INTERVAL = new NS_TrainConsistActivityCONTENT_ESTIMATED_DWELL_INTERVAL_48[1];
					content.ESTIMATED_DWELL_INTERVAL[0] = new NS_TrainConsistActivityCONTENT_ESTIMATED_DWELL_INTERVAL_48();
					if (CONTENT.ESTIMATED_DWELL_INTERVAL == "Empty") {
						content.ESTIMATED_DWELL_INTERVAL[0].Value = "";
					} else {
						content.ESTIMATED_DWELL_INTERVAL[0].Value = CONTENT.ESTIMATED_DWELL_INTERVAL;
					}
				}

				if (CONTENT.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR != "Null") {
					content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR_48[1];
					content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR_48();
					content.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR[0].Value = CONTENT.MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR;
				}

				if (CONTENT.MAX_CAR_WEIGHT != null && CONTENT.MAX_CAR_WEIGHT != "") {
					content.MAX_CAR_WEIGHT = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_48[1];
					content.MAX_CAR_WEIGHT[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_48();
					if (CONTENT.MAX_CAR_WEIGHT == "Empty") {
						content.MAX_CAR_WEIGHT[0].Value = "";
					} else {
						content.MAX_CAR_WEIGHT[0].Value = CONTENT.MAX_CAR_WEIGHT;
					}
				}

				if (CONTENT.MAX_CAR_WEIGHT_TO != null && CONTENT.MAX_CAR_WEIGHT_TO != "") {
					content.MAX_CAR_WEIGHT_TO = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_48[1];
					content.MAX_CAR_WEIGHT_TO[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_48();
					if (CONTENT.MAX_CAR_WEIGHT_TO == "Empty") {
						content.MAX_CAR_WEIGHT_TO[0].Value = "";
					} else {
						content.MAX_CAR_WEIGHT_TO[0].Value = CONTENT.MAX_CAR_WEIGHT_TO;
					}
				}

				if (CONTENT.MAX_CAR_WEIGHT_TO_PASS_COUNT != null && CONTENT.MAX_CAR_WEIGHT_TO_PASS_COUNT != "") {
					content.MAX_CAR_WEIGHT_TO_PASS_COUNT = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_PASS_COUNT_48[1];
					content.MAX_CAR_WEIGHT_TO_PASS_COUNT[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_PASS_COUNT_48();
					if (CONTENT.MAX_CAR_WEIGHT_TO_PASS_COUNT == "Empty") {
						content.MAX_CAR_WEIGHT_TO_PASS_COUNT[0].Value = "";
					} else {
						content.MAX_CAR_WEIGHT_TO_PASS_COUNT[0].Value = CONTENT.MAX_CAR_WEIGHT_TO_PASS_COUNT;
					}
				}

				if (CONTENT.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR != "Null") {
					content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR_48[1];
					content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR_48();
					content.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR[0].Value = CONTENT.MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR;
				}

				if (CONTENT.MAX_CAR_HEIGHT != null && CONTENT.MAX_CAR_HEIGHT != "") {
					content.MAX_CAR_HEIGHT = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_48[1];
					content.MAX_CAR_HEIGHT[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_48();
					if (CONTENT.MAX_CAR_HEIGHT == "Empty") {
						content.MAX_CAR_HEIGHT[0].Value = "";
					} else {
						content.MAX_CAR_HEIGHT[0].Value = CONTENT.MAX_CAR_HEIGHT;
					}
				}

				if (CONTENT.MAX_CAR_HEIGHT_TO != null && CONTENT.MAX_CAR_HEIGHT_TO != "") {
					content.MAX_CAR_HEIGHT_TO = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_48[1];
					content.MAX_CAR_HEIGHT_TO[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_48();
					if (CONTENT.MAX_CAR_HEIGHT_TO == "Empty") {
						content.MAX_CAR_HEIGHT_TO[0].Value = "";
					} else {
						content.MAX_CAR_HEIGHT_TO[0].Value = CONTENT.MAX_CAR_HEIGHT_TO;
					}
				}

				if (CONTENT.MAX_CAR_HEIGHT_TO_PASS_COUNT != null && CONTENT.MAX_CAR_HEIGHT_TO_PASS_COUNT != "") {
					content.MAX_CAR_HEIGHT_TO_PASS_COUNT = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_PASS_COUNT_48[1];
					content.MAX_CAR_HEIGHT_TO_PASS_COUNT[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_PASS_COUNT_48();
					if (CONTENT.MAX_CAR_HEIGHT_TO_PASS_COUNT == "Empty") {
						content.MAX_CAR_HEIGHT_TO_PASS_COUNT[0].Value = "";
					} else {
						content.MAX_CAR_HEIGHT_TO_PASS_COUNT[0].Value = CONTENT.MAX_CAR_HEIGHT_TO_PASS_COUNT;
					}
				}

				if (CONTENT.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR != "Null") {
					content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_CONSTRAINT_INDICATOR_48[1];
					content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_CONSTRAINT_INDICATOR_48();
					content.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR[0].Value = CONTENT.MAX_CAR_WIDTH_CONSTRAINT_INDICATOR;
				}

				if (CONTENT.MAX_CAR_WIDTH != null && CONTENT.MAX_CAR_WIDTH != "") {
					content.MAX_CAR_WIDTH = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_48[1];
					content.MAX_CAR_WIDTH[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_48();
					if (CONTENT.MAX_CAR_WIDTH == "Empty") {
						content.MAX_CAR_WIDTH[0].Value = "";
					} else {
						content.MAX_CAR_WIDTH[0].Value = CONTENT.MAX_CAR_WIDTH;
					}
				}

				if (CONTENT.MAX_CAR_WIDTH_TO != null && CONTENT.MAX_CAR_WIDTH_TO != "") {
					content.MAX_CAR_WIDTH_TO = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_48[1];
					content.MAX_CAR_WIDTH_TO[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_48();
					if (CONTENT.MAX_CAR_WIDTH_TO == "Empty") {
						content.MAX_CAR_WIDTH_TO[0].Value = "";
					} else {
						content.MAX_CAR_WIDTH_TO[0].Value = CONTENT.MAX_CAR_WIDTH_TO;
					}
				}

				if (CONTENT.MAX_CAR_WIDTH_TO_PASS_COUNT != null && CONTENT.MAX_CAR_WIDTH_TO_PASS_COUNT != "") {
					content.MAX_CAR_WIDTH_TO_PASS_COUNT = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_PASS_COUNT_48[1];
					content.MAX_CAR_WIDTH_TO_PASS_COUNT[0] = new NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_PASS_COUNT_48();
					if (CONTENT.MAX_CAR_WIDTH_TO_PASS_COUNT == "Empty") {
						content.MAX_CAR_WIDTH_TO_PASS_COUNT[0].Value = "";
					} else {
						content.MAX_CAR_WIDTH_TO_PASS_COUNT[0].Value = CONTENT.MAX_CAR_WIDTH_TO_PASS_COUNT;
					}
				}

				if (CONTENT.HAZMAT_TRAIN_CONSTRAINT_INDICATOR != "Null") {
					content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_CONSTRAINT_INDICATOR_48[1];
					content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR[0] = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_CONSTRAINT_INDICATOR_48();
					content.HAZMAT_TRAIN_CONSTRAINT_INDICATOR[0].Value = CONTENT.HAZMAT_TRAIN_CONSTRAINT_INDICATOR;
				}

				if (CONTENT.KEY_TRAIN_INDICATOR != null && CONTENT.KEY_TRAIN_INDICATOR != "") {
					content.KEY_TRAIN_INDICATOR = new NS_TrainConsistActivityCONTENT_KEY_TRAIN_INDICATOR_48[1];
					content.KEY_TRAIN_INDICATOR[0] = new NS_TrainConsistActivityCONTENT_KEY_TRAIN_INDICATOR_48();
					if (CONTENT.KEY_TRAIN_INDICATOR == "Empty") {
						content.KEY_TRAIN_INDICATOR[0].Value = "";
					} else {
						content.KEY_TRAIN_INDICATOR[0].Value = CONTENT.KEY_TRAIN_INDICATOR;
					}
				}

				if (CONTENT.HAZMAT_TRAIN_TO != null && CONTENT.HAZMAT_TRAIN_TO != "") {
					content.HAZMAT_TRAIN_TO = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_48[1];
					content.HAZMAT_TRAIN_TO[0] = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_48();
					if (CONTENT.HAZMAT_TRAIN_TO == "Empty") {
						content.HAZMAT_TRAIN_TO[0].Value = "";
					} else {
						content.HAZMAT_TRAIN_TO[0].Value = CONTENT.HAZMAT_TRAIN_TO;
					}
				}

				if (CONTENT.HAZMAT_TRAIN_TO_PASS_COUNT != null && CONTENT.HAZMAT_TRAIN_TO_PASS_COUNT != "") {
					content.HAZMAT_TRAIN_TO_PASS_COUNT = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_PASS_COUNT_48[1];
					content.HAZMAT_TRAIN_TO_PASS_COUNT[0] = new NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_PASS_COUNT_48();
					if (CONTENT.HAZMAT_TRAIN_TO_PASS_COUNT == "Empty") {
						content.HAZMAT_TRAIN_TO_PASS_COUNT[0].Value = "";
					} else {
						content.HAZMAT_TRAIN_TO_PASS_COUNT[0].Value = CONTENT.HAZMAT_TRAIN_TO_PASS_COUNT;
					}
				}

				if (CONTENT.NUMBER_OF_PICKUP_SETOUT_RECORDS != "Null") {
					content.NUMBER_OF_PICKUP_SETOUT_RECORDS = new NS_TrainConsistActivityCONTENT_NUMBER_OF_PICKUP_SETOUT_RECORDS_48[1];
					content.NUMBER_OF_PICKUP_SETOUT_RECORDS[0] = new NS_TrainConsistActivityCONTENT_NUMBER_OF_PICKUP_SETOUT_RECORDS_48();
					content.NUMBER_OF_PICKUP_SETOUT_RECORDS[0].Value = CONTENT.NUMBER_OF_PICKUP_SETOUT_RECORDS;
				}

				if (CONTENT.PICKUP_SETOUT_RECORD.Count != 0) {
					int pickup_setout_recordIndex = 0;
					content.PICKUP_SETOUT_RECORD = new NS_TrainConsistActivityCONTENT_PICKUP_SETOUT_RECORD_48[CONTENT.PICKUP_SETOUT_RECORD.Count];
					foreach (MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48 PICKUP_SETOUT_RECORD in CONTENT.PICKUP_SETOUT_RECORD) {
						NS_TrainConsistActivityCONTENT_PICKUP_SETOUT_RECORD_48 pickup_setout_record = new NS_TrainConsistActivityCONTENT_PICKUP_SETOUT_RECORD_48();
						if (PICKUP_SETOUT_RECORD.REPORT_CONSIST_CHANGE_FLAG != "Null") {
							pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_REPORT_CONSIST_CHANGE_FLAG_48[1];
							pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_REPORT_CONSIST_CHANGE_FLAG_48();
							pickup_setout_record.REPORT_CONSIST_CHANGE_FLAG[0].Value = PICKUP_SETOUT_RECORD.REPORT_CONSIST_CHANGE_FLAG;
						}

						if (PICKUP_SETOUT_RECORD.CONSIST_OPERATION != "Null") {
							pickup_setout_record.CONSIST_OPERATION = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_CONSIST_OPERATION_48[1];
							pickup_setout_record.CONSIST_OPERATION[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_CONSIST_OPERATION_48();
							pickup_setout_record.CONSIST_OPERATION[0].Value = PICKUP_SETOUT_RECORD.CONSIST_OPERATION;
						}

						if (PICKUP_SETOUT_RECORD.NUMBER_OF_LOADS != "Null") {
							pickup_setout_record.NUMBER_OF_LOADS = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_LOADS_48[1];
							pickup_setout_record.NUMBER_OF_LOADS[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_LOADS_48();
							pickup_setout_record.NUMBER_OF_LOADS[0].Value = PICKUP_SETOUT_RECORD.NUMBER_OF_LOADS;
						}

						if (PICKUP_SETOUT_RECORD.NUMBER_OF_EMPTIES != "Null") {
							pickup_setout_record.NUMBER_OF_EMPTIES = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_EMPTIES_48[1];
							pickup_setout_record.NUMBER_OF_EMPTIES[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_EMPTIES_48();
							pickup_setout_record.NUMBER_OF_EMPTIES[0].Value = PICKUP_SETOUT_RECORD.NUMBER_OF_EMPTIES;
						}

						if (PICKUP_SETOUT_RECORD.TONNAGE != "Null") {
							pickup_setout_record.TONNAGE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TONNAGE_48[1];
							pickup_setout_record.TONNAGE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TONNAGE_48();
							pickup_setout_record.TONNAGE[0].Value = PICKUP_SETOUT_RECORD.TONNAGE;
						}

						if (PICKUP_SETOUT_RECORD.LENGTH != "Null") {
							pickup_setout_record.LENGTH = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_LENGTH_48[1];
							pickup_setout_record.LENGTH[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_LENGTH_48();
							pickup_setout_record.LENGTH[0].Value = PICKUP_SETOUT_RECORD.LENGTH;
						}

						if (PICKUP_SETOUT_RECORD.COAL_INDICATOR != "Null") {
							pickup_setout_record.COAL_INDICATOR = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_INDICATOR_48[1];
							pickup_setout_record.COAL_INDICATOR[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_INDICATOR_48();
							pickup_setout_record.COAL_INDICATOR[0].Value = PICKUP_SETOUT_RECORD.COAL_INDICATOR;
						}

						if (PICKUP_SETOUT_RECORD.COAL_PERMIT_NUMBER != "Null") {
							pickup_setout_record.COAL_PERMIT_NUMBER = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_PERMIT_NUMBER_48[1];
							pickup_setout_record.COAL_PERMIT_NUMBER[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_PERMIT_NUMBER_48();
							pickup_setout_record.COAL_PERMIT_NUMBER[0].Value = PICKUP_SETOUT_RECORD.COAL_PERMIT_NUMBER;
						}

						if (PICKUP_SETOUT_RECORD.NOTE != null && PICKUP_SETOUT_RECORD.NOTE != "") {
							pickup_setout_record.NOTE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NOTE_48[1];
							pickup_setout_record.NOTE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NOTE_48();
							if (PICKUP_SETOUT_RECORD.NOTE == "Empty") {
								pickup_setout_record.NOTE[0].Value = "";
							} else {
								pickup_setout_record.NOTE[0].Value = PICKUP_SETOUT_RECORD.NOTE;
							}
						}

						if (PICKUP_SETOUT_RECORD.COMPLETION_STATUS != null && PICKUP_SETOUT_RECORD.COMPLETION_STATUS != "") {
							pickup_setout_record.COMPLETION_STATUS = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_STATUS_48[1];
							pickup_setout_record.COMPLETION_STATUS[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_STATUS_48();
							if (PICKUP_SETOUT_RECORD.COMPLETION_STATUS == "Empty") {
								pickup_setout_record.COMPLETION_STATUS[0].Value = "";
							} else {
								pickup_setout_record.COMPLETION_STATUS[0].Value = PICKUP_SETOUT_RECORD.COMPLETION_STATUS;
							}
						}

						if (PICKUP_SETOUT_RECORD.COMPLETION_DATE != null && PICKUP_SETOUT_RECORD.COMPLETION_DATE != "") {
							pickup_setout_record.COMPLETION_DATE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_DATE_48[1];
							pickup_setout_record.COMPLETION_DATE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_DATE_48();
							if (PICKUP_SETOUT_RECORD.COMPLETION_DATE == "Empty") {
								pickup_setout_record.COMPLETION_DATE[0].Value = "";
							} else {
								pickup_setout_record.COMPLETION_DATE[0].Value = PICKUP_SETOUT_RECORD.COMPLETION_DATE;
							}
						}

						if (PICKUP_SETOUT_RECORD.COMPLETION_TIME != null && PICKUP_SETOUT_RECORD.COMPLETION_TIME != "") {
							pickup_setout_record.COMPLETION_TIME = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_48[1];
							pickup_setout_record.COMPLETION_TIME[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_48();
							if (PICKUP_SETOUT_RECORD.COMPLETION_TIME == "Empty") {
								pickup_setout_record.COMPLETION_TIME[0].Value = "";
							} else {
								pickup_setout_record.COMPLETION_TIME[0].Value = PICKUP_SETOUT_RECORD.COMPLETION_TIME;
							}
						}

						if (PICKUP_SETOUT_RECORD.COMPLETION_TIME_ZONE != null && PICKUP_SETOUT_RECORD.COMPLETION_TIME_ZONE != "") {
							pickup_setout_record.COMPLETION_TIME_ZONE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_ZONE_48[1];
							pickup_setout_record.COMPLETION_TIME_ZONE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_ZONE_48();
							if (PICKUP_SETOUT_RECORD.COMPLETION_TIME_ZONE == "Empty") {
								pickup_setout_record.COMPLETION_TIME_ZONE[0].Value = "";
							} else {
								pickup_setout_record.COMPLETION_TIME_ZONE[0].Value = PICKUP_SETOUT_RECORD.COMPLETION_TIME_ZONE;
							}
						}

						if (PICKUP_SETOUT_RECORD.NEED_DATE != null && PICKUP_SETOUT_RECORD.NEED_DATE != "") {
							pickup_setout_record.NEED_DATE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_DATE_48[1];
							pickup_setout_record.NEED_DATE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_DATE_48();
							if (PICKUP_SETOUT_RECORD.NEED_DATE == "Empty") {
								pickup_setout_record.NEED_DATE[0].Value = "";
							} else {
								pickup_setout_record.NEED_DATE[0].Value = PICKUP_SETOUT_RECORD.NEED_DATE;
							}
						}

						if (PICKUP_SETOUT_RECORD.NEED_TIME != null && PICKUP_SETOUT_RECORD.NEED_TIME != "") {
							pickup_setout_record.NEED_TIME = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_48[1];
							pickup_setout_record.NEED_TIME[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_48();
							if (PICKUP_SETOUT_RECORD.NEED_TIME == "Empty") {
								pickup_setout_record.NEED_TIME[0].Value = "";
							} else {
								pickup_setout_record.NEED_TIME[0].Value = PICKUP_SETOUT_RECORD.NEED_TIME;
							}
						}

						if (PICKUP_SETOUT_RECORD.NEED_TIME_ZONE != null && PICKUP_SETOUT_RECORD.NEED_TIME_ZONE != "") {
							pickup_setout_record.NEED_TIME_ZONE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_ZONE_48[1];
							pickup_setout_record.NEED_TIME_ZONE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_ZONE_48();
							if (PICKUP_SETOUT_RECORD.NEED_TIME_ZONE == "Empty") {
								pickup_setout_record.NEED_TIME_ZONE[0].Value = "";
							} else {
								pickup_setout_record.NEED_TIME_ZONE[0].Value = PICKUP_SETOUT_RECORD.NEED_TIME_ZONE;
							}
						}

						if (PICKUP_SETOUT_RECORD.AXLES != null && PICKUP_SETOUT_RECORD.AXLES != "") {
							pickup_setout_record.AXLES = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_AXLES_48[1];
							pickup_setout_record.AXLES[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_AXLES_48();
							if (PICKUP_SETOUT_RECORD.AXLES == "Empty") {
								pickup_setout_record.AXLES[0].Value = "";
							} else {
								pickup_setout_record.AXLES[0].Value = PICKUP_SETOUT_RECORD.AXLES;
							}
						}

						if (PICKUP_SETOUT_RECORD.OPERATIVE_BRAKES != null && PICKUP_SETOUT_RECORD.OPERATIVE_BRAKES != "") {
							pickup_setout_record.OPERATIVE_BRAKES = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_OPERATIVE_BRAKES_48[1];
							pickup_setout_record.OPERATIVE_BRAKES[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_OPERATIVE_BRAKES_48();
							if (PICKUP_SETOUT_RECORD.OPERATIVE_BRAKES == "Empty") {
								pickup_setout_record.OPERATIVE_BRAKES[0].Value = "";
							} else {
								pickup_setout_record.OPERATIVE_BRAKES[0].Value = PICKUP_SETOUT_RECORD.OPERATIVE_BRAKES;
							}
						}

						if (PICKUP_SETOUT_RECORD.TOTAL_BRAKING_FORCE != null && PICKUP_SETOUT_RECORD.TOTAL_BRAKING_FORCE != "") {
							pickup_setout_record.TOTAL_BRAKING_FORCE = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TOTAL_BRAKING_FORCE_48[1];
							pickup_setout_record.TOTAL_BRAKING_FORCE[0] = new NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TOTAL_BRAKING_FORCE_48();
							if (PICKUP_SETOUT_RECORD.TOTAL_BRAKING_FORCE == "Empty") {
								pickup_setout_record.TOTAL_BRAKING_FORCE[0].Value = "";
							} else {
								pickup_setout_record.TOTAL_BRAKING_FORCE[0].Value = PICKUP_SETOUT_RECORD.TOTAL_BRAKING_FORCE;
							}
						}

						content.PICKUP_SETOUT_RECORD[pickup_setout_recordIndex] = pickup_setout_record;
						pickup_setout_recordIndex++;
					}
				}

				if (CONTENT.NUMBER_OF_COAL_CLASSIFICATION_RECORDS != null && CONTENT.NUMBER_OF_COAL_CLASSIFICATION_RECORDS != "") {
					content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS = new NS_TrainConsistActivityCONTENT_NUMBER_OF_COAL_CLASSIFICATION_RECORDS_48[1];
					content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS[0] = new NS_TrainConsistActivityCONTENT_NUMBER_OF_COAL_CLASSIFICATION_RECORDS_48();
					if (CONTENT.NUMBER_OF_COAL_CLASSIFICATION_RECORDS == "Empty") {
						content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS[0].Value = "";
					} else {
						content.NUMBER_OF_COAL_CLASSIFICATION_RECORDS[0].Value = CONTENT.NUMBER_OF_COAL_CLASSIFICATION_RECORDS;
					}
				}

				if (CONTENT.COAL_CLASSIFICATION_RECORD.Count != 0) {
					int coal_classification_recordIndex = 0;
					content.COAL_CLASSIFICATION_RECORD = new NS_TrainConsistActivityCONTENT_COAL_CLASSIFICATION_RECORD_48[CONTENT.COAL_CLASSIFICATION_RECORD.Count];
					foreach (MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48 COAL_CLASSIFICATION_RECORD in CONTENT.COAL_CLASSIFICATION_RECORD) {
						NS_TrainConsistActivityCONTENT_COAL_CLASSIFICATION_RECORD_48 coal_classification_record = new NS_TrainConsistActivityCONTENT_COAL_CLASSIFICATION_RECORD_48();
						if (COAL_CLASSIFICATION_RECORD.COAL_CLASSIFICATION != null && COAL_CLASSIFICATION_RECORD.COAL_CLASSIFICATION != "") {
							coal_classification_record.COAL_CLASSIFICATION = new NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_COAL_CLASSIFICATION_48[1];
							coal_classification_record.COAL_CLASSIFICATION[0] = new NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_COAL_CLASSIFICATION_48();
							if (COAL_CLASSIFICATION_RECORD.COAL_CLASSIFICATION == "Empty") {
								coal_classification_record.COAL_CLASSIFICATION[0].Value = "";
							} else {
								coal_classification_record.COAL_CLASSIFICATION[0].Value = COAL_CLASSIFICATION_RECORD.COAL_CLASSIFICATION;
							}
						}

						if (COAL_CLASSIFICATION_RECORD.NUMBER_OF_CARS != null && COAL_CLASSIFICATION_RECORD.NUMBER_OF_CARS != "") {
							coal_classification_record.NUMBER_OF_CARS = new NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_NUMBER_OF_CARS_48[1];
							coal_classification_record.NUMBER_OF_CARS[0] = new NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_NUMBER_OF_CARS_48();
							if (COAL_CLASSIFICATION_RECORD.NUMBER_OF_CARS == "Empty") {
								coal_classification_record.NUMBER_OF_CARS[0].Value = "";
							} else {
								coal_classification_record.NUMBER_OF_CARS[0].Value = COAL_CLASSIFICATION_RECORD.NUMBER_OF_CARS;
							}
						}

						content.COAL_CLASSIFICATION_RECORD[coal_classification_recordIndex] = coal_classification_record;
						coal_classification_recordIndex++;
					}
				}

			}

			ns_trainconsistactivity_48.Items[0] = header;
			ns_trainconsistactivity_48.Items[1] = content;
			return ns_trainconsistactivity_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNCNA,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNCNA,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainConsistActivityHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainConsistActivityCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string LOCATION = "";
		public string PASS_COUNT = "";
		public string REPORTING_SOURCE = "";
		public string ESTIMATED_DWELL_INTERVAL = "";
		public string MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR = "";
		public string MAX_CAR_WEIGHT = "";
		public string MAX_CAR_WEIGHT_TO = "";
		public string MAX_CAR_WEIGHT_TO_PASS_COUNT = "";
		public string MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR = "";
		public string MAX_CAR_HEIGHT = "";
		public string MAX_CAR_HEIGHT_TO = "";
		public string MAX_CAR_HEIGHT_TO_PASS_COUNT = "";
		public string MAX_CAR_WIDTH_CONSTRAINT_INDICATOR = "";
		public string MAX_CAR_WIDTH = "";
		public string MAX_CAR_WIDTH_TO = "";
		public string MAX_CAR_WIDTH_TO_PASS_COUNT = "";
		public string HAZMAT_TRAIN_CONSTRAINT_INDICATOR = "";
		public string KEY_TRAIN_INDICATOR = "";
		public string HAZMAT_TRAIN_TO = "";
		public string HAZMAT_TRAIN_TO_PASS_COUNT = "";
		public string NUMBER_OF_PICKUP_SETOUT_RECORDS = "";
		public ArrayList PICKUP_SETOUT_RECORD = new ArrayList();
		public string NUMBER_OF_COAL_CLASSIFICATION_RECORDS = "";
		public ArrayList COAL_CLASSIFICATION_RECORD = new ArrayList();

		public void addPICKUP_SETOUT_RECORD(MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48 pickup_setout_record) {
			this.PICKUP_SETOUT_RECORD.Add(pickup_setout_record);
		}

		public void addCOAL_CLASSIFICATION_RECORD(MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48 coal_classification_record) {
			this.COAL_CLASSIFICATION_RECORD.Add(coal_classification_record);
		}
	}

	public partial class MIS_NS_TrainConsistActivityPICKUP_SETOUT_RECORD_48 {
		public string REPORT_CONSIST_CHANGE_FLAG = "";
		public string CONSIST_OPERATION = "";
		public string NUMBER_OF_LOADS = "";
		public string NUMBER_OF_EMPTIES = "";
		public string TONNAGE = "";
		public string LENGTH = "";
		public string COAL_INDICATOR = "";
		public string COAL_PERMIT_NUMBER = "";
		public string NOTE = "";
		public string COMPLETION_STATUS = "";
		public string COMPLETION_DATE = "";
		public string COMPLETION_TIME = "";
		public string COMPLETION_TIME_ZONE = "";
		public string NEED_DATE = "";
		public string NEED_TIME = "";
		public string NEED_TIME_ZONE = "";
		public string AXLES = "";
		public string OPERATIVE_BRAKES = "";
		public string TOTAL_BRAKING_FORCE = "";
	}

	public partial class MIS_NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_48 {
		public string COAL_CLASSIFICATION = "";
		public string NUMBER_OF_CARS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainConsistActivity", IsNullable = false)]
	public partial class NS_TrainConsistActivity_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainConsistActivityHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainConsistActivityCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_LOCATION_48[] LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_PASS_COUNT_48[] PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_SOURCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_REPORTING_SOURCE_48[] REPORTING_SOURCE;

		[System.Xml.Serialization.XmlElementAttribute("ESTIMATED_DWELL_INTERVAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_ESTIMATED_DWELL_INTERVAL_48[] ESTIMATED_DWELL_INTERVAL;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR_48[] MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_48[] MAX_CAR_WEIGHT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_48[] MAX_CAR_WEIGHT_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_PASS_COUNT_48[] MAX_CAR_WEIGHT_TO_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR_48[] MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_48[] MAX_CAR_HEIGHT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_48[] MAX_CAR_HEIGHT_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_PASS_COUNT_48[] MAX_CAR_HEIGHT_TO_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_CONSTRAINT_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_CONSTRAINT_INDICATOR_48[] MAX_CAR_WIDTH_CONSTRAINT_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_48[] MAX_CAR_WIDTH;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_48[] MAX_CAR_WIDTH_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_PASS_COUNT_48[] MAX_CAR_WIDTH_TO_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("HAZMAT_TRAIN_CONSTRAINT_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_CONSTRAINT_INDICATOR_48[] HAZMAT_TRAIN_CONSTRAINT_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("KEY_TRAIN_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_KEY_TRAIN_INDICATOR_48[] KEY_TRAIN_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("HAZMAT_TRAIN_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_48[] HAZMAT_TRAIN_TO;

		[System.Xml.Serialization.XmlElementAttribute("HAZMAT_TRAIN_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_PASS_COUNT_48[] HAZMAT_TRAIN_TO_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_PICKUP_SETOUT_RECORDS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_NUMBER_OF_PICKUP_SETOUT_RECORDS_48[] NUMBER_OF_PICKUP_SETOUT_RECORDS;

		[System.Xml.Serialization.XmlElementAttribute("PICKUP_SETOUT_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_PICKUP_SETOUT_RECORD_48[] PICKUP_SETOUT_RECORD;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_COAL_CLASSIFICATION_RECORDS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_NUMBER_OF_COAL_CLASSIFICATION_RECORDS_48[] NUMBER_OF_COAL_CLASSIFICATION_RECORDS;

		[System.Xml.Serialization.XmlElementAttribute("COAL_CLASSIFICATION_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCONTENT_COAL_CLASSIFICATION_RECORD_48[] COAL_CLASSIFICATION_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_REPORTING_SOURCE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_ESTIMATED_DWELL_INTERVAL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WEIGHT_TO_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_HEIGHT_TO_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_CONSTRAINT_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_MAX_CAR_WIDTH_TO_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_CONSTRAINT_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_KEY_TRAIN_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_HAZMAT_TRAIN_TO_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_NUMBER_OF_PICKUP_SETOUT_RECORDS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_PICKUP_SETOUT_RECORD_48 {
		[System.Xml.Serialization.XmlElementAttribute("REPORT_CONSIST_CHANGE_FLAG", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_REPORT_CONSIST_CHANGE_FLAG_48[] REPORT_CONSIST_CHANGE_FLAG;

		[System.Xml.Serialization.XmlElementAttribute("CONSIST_OPERATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_CONSIST_OPERATION_48[] CONSIST_OPERATION;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_LOADS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_LOADS_48[] NUMBER_OF_LOADS;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_EMPTIES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_EMPTIES_48[] NUMBER_OF_EMPTIES;

		[System.Xml.Serialization.XmlElementAttribute("TONNAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TONNAGE_48[] TONNAGE;

		[System.Xml.Serialization.XmlElementAttribute("LENGTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_LENGTH_48[] LENGTH;

		[System.Xml.Serialization.XmlElementAttribute("COAL_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_INDICATOR_48[] COAL_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("COAL_PERMIT_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_PERMIT_NUMBER_48[] COAL_PERMIT_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("NOTE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NOTE_48[] NOTE;

		[System.Xml.Serialization.XmlElementAttribute("COMPLETION_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_STATUS_48[] COMPLETION_STATUS;

		[System.Xml.Serialization.XmlElementAttribute("COMPLETION_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_DATE_48[] COMPLETION_DATE;

		[System.Xml.Serialization.XmlElementAttribute("COMPLETION_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_48[] COMPLETION_TIME;

		[System.Xml.Serialization.XmlElementAttribute("COMPLETION_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_ZONE_48[] COMPLETION_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("NEED_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_DATE_48[] NEED_DATE;

		[System.Xml.Serialization.XmlElementAttribute("NEED_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_48[] NEED_TIME;

		[System.Xml.Serialization.XmlElementAttribute("NEED_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_ZONE_48[] NEED_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("AXLES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_AXLES_48[] AXLES;

		[System.Xml.Serialization.XmlElementAttribute("OPERATIVE_BRAKES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_OPERATIVE_BRAKES_48[] OPERATIVE_BRAKES;

		[System.Xml.Serialization.XmlElementAttribute("TOTAL_BRAKING_FORCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TOTAL_BRAKING_FORCE_48[] TOTAL_BRAKING_FORCE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_REPORT_CONSIST_CHANGE_FLAG_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_CONSIST_OPERATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_LOADS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NUMBER_OF_EMPTIES_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TONNAGE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_LENGTH_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_INDICATOR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COAL_PERMIT_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NOTE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_STATUS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_COMPLETION_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_NEED_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_AXLES_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_OPERATIVE_BRAKES_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityPICKUP_SETOUT_RECORD_TOTAL_BRAKING_FORCE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_NUMBER_OF_COAL_CLASSIFICATION_RECORDS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCONTENT_COAL_CLASSIFICATION_RECORD_48 {
		[System.Xml.Serialization.XmlElementAttribute("COAL_CLASSIFICATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_COAL_CLASSIFICATION_48[] COAL_CLASSIFICATION;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_CARS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_NUMBER_OF_CARS_48[] NUMBER_OF_CARS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_COAL_CLASSIFICATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistActivityCOAL_CLASSIFICATION_RECORD_NUMBER_OF_CARS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}