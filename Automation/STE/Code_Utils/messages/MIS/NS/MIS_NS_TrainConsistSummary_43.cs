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
	public partial class MIS_NS_TrainConsistSummary_43 {
		public MIS_NS_TrainConsistSummaryHEADER_43 HEADER;
		public MIS_NS_TrainConsistSummaryCONTENT_43 CONTENT;

		public static MIS_NS_TrainConsistSummary_43 fromSerializableObject(NS_TrainConsistSummary_43 message) {
			MIS_NS_TrainConsistSummary_43 ns_trainconsistsummary_43 = new MIS_NS_TrainConsistSummary_43();
			NS_TrainConsistSummaryHEADER_43 header = null;
			NS_TrainConsistSummaryCONTENT_43 content = null;
			header = (NS_TrainConsistSummaryHEADER_43) message.Items[0];
			content = (NS_TrainConsistSummaryCONTENT_43) message.Items[1];

			if (header != null) {
				MIS_NS_TrainConsistSummaryHEADER_43 messageheader = new MIS_NS_TrainConsistSummaryHEADER_43();

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

				ns_trainconsistsummary_43.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_TrainConsistSummaryCONTENT_43 messagecontent = new MIS_NS_TrainConsistSummaryCONTENT_43();

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

				if (content.REPORTING_LOCATION != null) {
					messagecontent.REPORTING_LOCATION = content.REPORTING_LOCATION[0].Value;
					if (messagecontent.REPORTING_LOCATION != null) {
						if (messagecontent.REPORTING_LOCATION.Length < 1 || messagecontent.REPORTING_LOCATION.Length > 6) {
							Ranorex.Report.Failure("Field REPORTING_LOCATION expected to be length between or equal to 1 and 6, has length of {" + messagecontent.REPORTING_LOCATION.Length.ToString() + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field REPORTING_LOCATION is a Mandatory field but was found to be missing from the message");
				}

				if (content.REPORTING_PASS_COUNT != null) {
					messagecontent.REPORTING_PASS_COUNT = content.REPORTING_PASS_COUNT[0].Value;
					if (messagecontent.REPORTING_PASS_COUNT != null) {
						if (messagecontent.REPORTING_PASS_COUNT.Length != 1) {
							Ranorex.Report.Failure("Field REPORTING_PASS_COUNT expected to be length of 1, has length of {" + messagecontent.REPORTING_PASS_COUNT.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.REPORTING_PASS_COUNT)) {
							Ranorex.Report.Failure("Field REPORTING_PASS_COUNT expected to be Numeric, has value of {" + messagecontent.REPORTING_PASS_COUNT + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field REPORTING_PASS_COUNT is a Mandatory field but was found to be missing from the message");
				}

				if (content.REPORTING_DATE != null) {
					messagecontent.REPORTING_DATE = content.REPORTING_DATE[0].Value;
					if (messagecontent.REPORTING_DATE != null) {
						if (messagecontent.REPORTING_DATE.Length != 8) {
							Ranorex.Report.Failure("Field REPORTING_DATE expected to be length of 8, has length of {" + messagecontent.REPORTING_DATE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.REPORTING_DATE)) {
							Ranorex.Report.Failure("Field REPORTING_DATE expected to be Numeric, has value of {" + messagecontent.REPORTING_DATE + "}.");
						}
					}
				}

				if (content.REPORTING_TIME != null) {
					messagecontent.REPORTING_TIME = content.REPORTING_TIME[0].Value;
					if (messagecontent.REPORTING_TIME != null) {
						if (messagecontent.REPORTING_TIME.Length != 12) {
							Ranorex.Report.Failure("Field REPORTING_TIME expected to be length of 12, has length of {" + messagecontent.REPORTING_TIME.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.REPORTING_TIME)) {
							Ranorex.Report.Failure("Field REPORTING_TIME expected to be Numeric, has value of {" + messagecontent.REPORTING_TIME + "}.");
						}
					}
				}

				if (content.REPORTING_TIME_ZONE != null) {
					messagecontent.REPORTING_TIME_ZONE = content.REPORTING_TIME_ZONE[0].Value;
					if (messagecontent.REPORTING_TIME_ZONE != null) {
						if (messagecontent.REPORTING_TIME_ZONE.Length != 1) {
							Ranorex.Report.Failure("Field REPORTING_TIME_ZONE expected to be length of 1, has length of {" + messagecontent.REPORTING_TIME_ZONE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.REPORTING_TIME_ZONE)) {
							Ranorex.Report.Failure("Field REPORTING_TIME_ZONE expected to be Alphabetic, has value of {" + messagecontent.REPORTING_TIME_ZONE + "}.");
						}
						if (messagecontent.REPORTING_TIME_ZONE != "E" && messagecontent.REPORTING_TIME_ZONE != "C" && messagecontent.REPORTING_TIME_ZONE != "U") {
							Ranorex.Report.Failure("Field REPORTING_TIME_ZONE expected to be one of the following values {E, C, U}, but was found to be {" + messagecontent.REPORTING_TIME_ZONE + "}.");
						}
					}
				}

				if (content.REPORTING_SOURCE != null) {
					messagecontent.REPORTING_SOURCE = content.REPORTING_SOURCE[0].Value;
					if (messagecontent.REPORTING_SOURCE != null) {
						if (messagecontent.REPORTING_SOURCE.Length != 1) {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be length of 1, has length of {" + messagecontent.REPORTING_SOURCE.Length.ToString() + "}.");
						}
						if (messagecontent.REPORTING_SOURCE != "D" && messagecontent.REPORTING_SOURCE != "T" && messagecontent.REPORTING_SOURCE != "O" && messagecontent.REPORTING_SOURCE != "E" && messagecontent.REPORTING_SOURCE != "C" && messagecontent.REPORTING_SOURCE != "G" && messagecontent.REPORTING_SOURCE != "U") {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be one of the following values {D, T, O, E, C, G, U}, but was found to be {" + messagecontent.REPORTING_SOURCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field REPORTING_SOURCE is a Mandatory field but was found to be missing from the message");
				}

				if (content.NUMBER_OF_TIH_CONSTRAINTS != null) {
					messagecontent.NUMBER_OF_TIH_CONSTRAINTS = content.NUMBER_OF_TIH_CONSTRAINTS[0].Value;
					if (messagecontent.NUMBER_OF_TIH_CONSTRAINTS != null) {
						if (messagecontent.NUMBER_OF_TIH_CONSTRAINTS.Length < 1 || messagecontent.NUMBER_OF_TIH_CONSTRAINTS.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_TIH_CONSTRAINTS expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_TIH_CONSTRAINTS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_TIH_CONSTRAINTS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_TIH_CONSTRAINTS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_TIH_CONSTRAINTS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_TIH_CONSTRAINTS);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field NUMBER_OF_TIH_CONSTRAINTS expected to have value between 0 and 99, but was found to have a value of " + messagecontent.NUMBER_OF_TIH_CONSTRAINTS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_TIH_CONSTRAINTS is a Mandatory field but was found to be missing from the message");
				}
				if (content.TIH_CONSTRAINT != null) {
					for (int i = 0; i < content.TIH_CONSTRAINT.Length; i++) {
						MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43 tih_constraint = new MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43();

						if (content.TIH_CONSTRAINT[i].TIH_INDICATOR != null) {
							tih_constraint.TIH_INDICATOR = content.TIH_CONSTRAINT[i].TIH_INDICATOR[0].Value;
							if (tih_constraint.TIH_INDICATOR != null) {
								if (tih_constraint.TIH_INDICATOR.Length < 0 || tih_constraint.TIH_INDICATOR.Length > 1) {
									Ranorex.Report.Failure("Field TIH_INDICATOR expected to be length between or equal to 0 and 1, has length of {" + tih_constraint.TIH_INDICATOR.Length.ToString() + "}.");
								}
								if (ContainsDigits(tih_constraint.TIH_INDICATOR)) {
									Ranorex.Report.Failure("Field TIH_INDICATOR expected to be Alphabetic, has value of {" + tih_constraint.TIH_INDICATOR + "}.");
								}
								if (tih_constraint.TIH_INDICATOR != "L" && tih_constraint.TIH_INDICATOR != "E" && tih_constraint.TIH_INDICATOR != "") {
									Ranorex.Report.Failure("Field TIH_INDICATOR expected to be one of the following values {L, E, }, but was found to be {" + tih_constraint.TIH_INDICATOR + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field TIH_INDICATOR is a Mandatory field but was found to be missing from the message");
						}

						if (content.TIH_CONSTRAINT[i].TIH_TRAIN_TO != null) {
							tih_constraint.TIH_TRAIN_TO = content.TIH_CONSTRAINT[i].TIH_TRAIN_TO[0].Value;
							if (tih_constraint.TIH_TRAIN_TO != null) {
								if (tih_constraint.TIH_TRAIN_TO.Length < 1 || tih_constraint.TIH_TRAIN_TO.Length > 6) {
									Ranorex.Report.Failure("Field TIH_TRAIN_TO expected to be length between or equal to 1 and 6, has length of {" + tih_constraint.TIH_TRAIN_TO.Length.ToString() + "}.");
								}
							}
						}

						if (content.TIH_CONSTRAINT[i].TIH_TRAIN_TO_PASS_COUNT != null) {
							tih_constraint.TIH_TRAIN_TO_PASS_COUNT = content.TIH_CONSTRAINT[i].TIH_TRAIN_TO_PASS_COUNT[0].Value;
							if (tih_constraint.TIH_TRAIN_TO_PASS_COUNT != null) {
								if (tih_constraint.TIH_TRAIN_TO_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field TIH_TRAIN_TO_PASS_COUNT expected to be length of 1, has length of {" + tih_constraint.TIH_TRAIN_TO_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(tih_constraint.TIH_TRAIN_TO_PASS_COUNT)) {
									Ranorex.Report.Failure("Field TIH_TRAIN_TO_PASS_COUNT expected to be Numeric, has value of {" + tih_constraint.TIH_TRAIN_TO_PASS_COUNT + "}.");
								}
							}
						}

						messagecontent.addTIH_CONSTRAINT(tih_constraint);
					}
				}

				if (content.MAX_PLATE_SIZE != null) {
					messagecontent.MAX_PLATE_SIZE = content.MAX_PLATE_SIZE[0].Value;
					if (messagecontent.MAX_PLATE_SIZE != null) {
						if (messagecontent.MAX_PLATE_SIZE.Length != 1) {
							Ranorex.Report.Failure("Field MAX_PLATE_SIZE expected to be length of 1, has length of {" + messagecontent.MAX_PLATE_SIZE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.MAX_PLATE_SIZE)) {
							Ranorex.Report.Failure("Field MAX_PLATE_SIZE expected to be Alphabetic, has value of {" + messagecontent.MAX_PLATE_SIZE + "}.");
						}
						if (messagecontent.MAX_PLATE_SIZE != "D" && messagecontent.MAX_PLATE_SIZE != "E" && messagecontent.MAX_PLATE_SIZE != "F" && messagecontent.MAX_PLATE_SIZE != "G") {
							Ranorex.Report.Failure("Field MAX_PLATE_SIZE expected to be one of the following values {D, E, F, G}, but was found to be {" + messagecontent.MAX_PLATE_SIZE + "}.");
						}
					}
				}

				if (content.NUMBER_OF_LOADS != null) {
					messagecontent.NUMBER_OF_LOADS = content.NUMBER_OF_LOADS[0].Value;
					if (messagecontent.NUMBER_OF_LOADS != null) {
						if (messagecontent.NUMBER_OF_LOADS.Length < 1 || messagecontent.NUMBER_OF_LOADS.Length > 3) {
							Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to be length between or equal to 1 and 3, has length of {" + messagecontent.NUMBER_OF_LOADS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_LOADS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_LOADS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_LOADS);
							if (intConvertedValue < 0 || intConvertedValue > 999) {
								Ranorex.Report.Failure("Field NUMBER_OF_LOADS expected to have value between 0 and 999, but was found to have a value of " + messagecontent.NUMBER_OF_LOADS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_LOADS is a Mandatory field but was found to be missing from the message");
				}

				if (content.NUMBER_OF_EMPTIES != null) {
					messagecontent.NUMBER_OF_EMPTIES = content.NUMBER_OF_EMPTIES[0].Value;
					if (messagecontent.NUMBER_OF_EMPTIES != null) {
						if (messagecontent.NUMBER_OF_EMPTIES.Length < 1 || messagecontent.NUMBER_OF_EMPTIES.Length > 3) {
							Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to be length between or equal to 1 and 3, has length of {" + messagecontent.NUMBER_OF_EMPTIES.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_EMPTIES)) {
							Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_EMPTIES + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_EMPTIES);
							if (intConvertedValue < 0 || intConvertedValue > 999) {
								Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES expected to have value between 0 and 999, but was found to have a value of " + messagecontent.NUMBER_OF_EMPTIES + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_EMPTIES is a Mandatory field but was found to be missing from the message");
				}

				if (content.TRAILING_TONNAGE != null) {
					messagecontent.TRAILING_TONNAGE = content.TRAILING_TONNAGE[0].Value;
					if (messagecontent.TRAILING_TONNAGE != null) {
						if (messagecontent.TRAILING_TONNAGE.Length < 1 || messagecontent.TRAILING_TONNAGE.Length > 5) {
							Ranorex.Report.Failure("Field TRAILING_TONNAGE expected to be length between or equal to 1 and 5, has length of {" + messagecontent.TRAILING_TONNAGE.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TRAILING_TONNAGE)) {
							Ranorex.Report.Failure("Field TRAILING_TONNAGE expected to be Numeric, has value of {" + messagecontent.TRAILING_TONNAGE + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.TRAILING_TONNAGE);
							if (intConvertedValue < 0 || intConvertedValue > 99999) {
								Ranorex.Report.Failure("Field TRAILING_TONNAGE expected to have value between 0 and 99999, but was found to have a value of " + messagecontent.TRAILING_TONNAGE + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field TRAILING_TONNAGE is a Mandatory field but was found to be missing from the message");
				}

				if (content.TRAIN_LENGTH != null) {
					messagecontent.TRAIN_LENGTH = content.TRAIN_LENGTH[0].Value;
					if (messagecontent.TRAIN_LENGTH != null) {
						if (messagecontent.TRAIN_LENGTH.Length < 1 || messagecontent.TRAIN_LENGTH.Length > 5) {
							Ranorex.Report.Failure("Field TRAIN_LENGTH expected to be length between or equal to 1 and 5, has length of {" + messagecontent.TRAIN_LENGTH.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.TRAIN_LENGTH)) {
							Ranorex.Report.Failure("Field TRAIN_LENGTH expected to be Numeric, has value of {" + messagecontent.TRAIN_LENGTH + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.TRAIN_LENGTH);
							if (intConvertedValue < 0 || intConvertedValue > 99999) {
								Ranorex.Report.Failure("Field TRAIN_LENGTH expected to have value between 0 and 99999, but was found to have a value of " + messagecontent.TRAIN_LENGTH + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field TRAIN_LENGTH is a Mandatory field but was found to be missing from the message");
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
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.OPERATIVE_BRAKES);
							if (intConvertedValue < 0 || intConvertedValue > 999) {
								Ranorex.Report.Failure("Field OPERATIVE_BRAKES expected to have value between 0 and 999, but was found to have a value of " + messagecontent.OPERATIVE_BRAKES + ".");
							}
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

				if (content.SPEED_CLASS != null) {
					messagecontent.SPEED_CLASS = content.SPEED_CLASS[0].Value;
					if (messagecontent.SPEED_CLASS != null) {
						if (messagecontent.SPEED_CLASS.Length < 1 || messagecontent.SPEED_CLASS.Length > 15) {
							Ranorex.Report.Failure("Field SPEED_CLASS expected to be length between or equal to 1 and 15, has length of {" + messagecontent.SPEED_CLASS.Length.ToString() + "}.");
						}
						if (messagecontent.SPEED_CLASS != "Freight" && messagecontent.SPEED_CLASS != "Intermodal" && messagecontent.SPEED_CLASS != "Passenger") {
							Ranorex.Report.Failure("Field SPEED_CLASS expected to be one of the following values {Freight, Intermodal, Passenger}, but was found to be {" + messagecontent.SPEED_CLASS + "}.");
						}
					}
				}

				if (content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS != null) {
					messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS = content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS[0].Value;
					if (messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS != null) {
						if (messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS.Length < 1 || messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS expected to have value between 0 and 99, but was found to have a value of " + messagecontent.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS is a Mandatory field but was found to be missing from the message");
				}
				if (content.MAX_CAR_WEIGHT_CONSTRAINT != null) {
					for (int i = 0; i < content.MAX_CAR_WEIGHT_CONSTRAINT.Length; i++) {
						MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43 max_car_weight_constraint = new MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43();

						if (content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT != null) {
							max_car_weight_constraint.MAX_CAR_WEIGHT = content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT[0].Value;
							if (max_car_weight_constraint.MAX_CAR_WEIGHT != null) {
								if (max_car_weight_constraint.MAX_CAR_WEIGHT.Length < 1 || max_car_weight_constraint.MAX_CAR_WEIGHT.Length > 6) {
									Ranorex.Report.Failure("Field MAX_CAR_WEIGHT expected to be length between or equal to 1 and 6, has length of {" + max_car_weight_constraint.MAX_CAR_WEIGHT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_weight_constraint.MAX_CAR_WEIGHT)) {
									Ranorex.Report.Failure("Field MAX_CAR_WEIGHT expected to be Numeric, has value of {" + max_car_weight_constraint.MAX_CAR_WEIGHT + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(max_car_weight_constraint.MAX_CAR_WEIGHT);
									if (intConvertedValue < 0 || intConvertedValue > 600000) {
										Ranorex.Report.Failure("Field MAX_CAR_WEIGHT expected to have value between 0 and 600000, but was found to have a value of " + max_car_weight_constraint.MAX_CAR_WEIGHT + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT_TO != null) {
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO = content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT_TO[0].Value;
							if (max_car_weight_constraint.MAX_CAR_WEIGHT_TO != null) {
								if (max_car_weight_constraint.MAX_CAR_WEIGHT_TO.Length < 1 || max_car_weight_constraint.MAX_CAR_WEIGHT_TO.Length > 6) {
									Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO expected to be length between or equal to 1 and 6, has length of {" + max_car_weight_constraint.MAX_CAR_WEIGHT_TO.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT_TO_PASS_COUNT != null) {
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT = content.MAX_CAR_WEIGHT_CONSTRAINT[i].MAX_CAR_WEIGHT_TO_PASS_COUNT[0].Value;
							if (max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT != null) {
								if (max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO_PASS_COUNT expected to be length of 1, has length of {" + max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT)) {
									Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO_PASS_COUNT expected to be Numeric, has value of {" + max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WEIGHT_TO_PASS_COUNT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addMAX_CAR_WEIGHT_CONSTRAINT(max_car_weight_constraint);
					}
				}

				if (content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS != null) {
					messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS = content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS[0].Value;
					if (messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS != null) {
						if (messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS.Length < 1 || messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS expected to have value between 0 and 99, but was found to have a value of " + messagecontent.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS is a Mandatory field but was found to be missing from the message");
				}
				if (content.MAX_CAR_HEIGHT_CONSTRAINT != null) {
					for (int i = 0; i < content.MAX_CAR_HEIGHT_CONSTRAINT.Length; i++) {
						MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43 max_car_height_constraint = new MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43();

						if (content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT != null) {
							max_car_height_constraint.MAX_CAR_HEIGHT = content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT[0].Value;
							if (max_car_height_constraint.MAX_CAR_HEIGHT != null) {
								if (max_car_height_constraint.MAX_CAR_HEIGHT.Length < 1 || max_car_height_constraint.MAX_CAR_HEIGHT.Length > 4) {
									Ranorex.Report.Failure("Field MAX_CAR_HEIGHT expected to be length between or equal to 1 and 4, has length of {" + max_car_height_constraint.MAX_CAR_HEIGHT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_height_constraint.MAX_CAR_HEIGHT)) {
									Ranorex.Report.Failure("Field MAX_CAR_HEIGHT expected to be Numeric, has value of {" + max_car_height_constraint.MAX_CAR_HEIGHT + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT_TO != null) {
							max_car_height_constraint.MAX_CAR_HEIGHT_TO = content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT_TO[0].Value;
							if (max_car_height_constraint.MAX_CAR_HEIGHT_TO != null) {
								if (max_car_height_constraint.MAX_CAR_HEIGHT_TO.Length < 1 || max_car_height_constraint.MAX_CAR_HEIGHT_TO.Length > 6) {
									Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO expected to be length between or equal to 1 and 6, has length of {" + max_car_height_constraint.MAX_CAR_HEIGHT_TO.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT_TO_PASS_COUNT != null) {
							max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT = content.MAX_CAR_HEIGHT_CONSTRAINT[i].MAX_CAR_HEIGHT_TO_PASS_COUNT[0].Value;
							if (max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT != null) {
								if (max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO_PASS_COUNT expected to be length of 1, has length of {" + max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT)) {
									Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO_PASS_COUNT expected to be Numeric, has value of {" + max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_HEIGHT_TO_PASS_COUNT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addMAX_CAR_HEIGHT_CONSTRAINT(max_car_height_constraint);
					}
				}

				if (content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS != null) {
					messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS = content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS[0].Value;
					if (messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS != null) {
						if (messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS.Length < 1 || messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS is a Mandatory field but was found to be missing from the message");
				}
				if (content.MAX_CAR_WIDTH_CONSTRAINT != null) {
					for (int i = 0; i < content.MAX_CAR_WIDTH_CONSTRAINT.Length; i++) {
						MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43 max_car_width_constraint = new MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43();

						if (content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH != null) {
							max_car_width_constraint.MAX_CAR_WIDTH = content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH[0].Value;
							if (max_car_width_constraint.MAX_CAR_WIDTH != null) {
								if (max_car_width_constraint.MAX_CAR_WIDTH.Length < 1 || max_car_width_constraint.MAX_CAR_WIDTH.Length > 4) {
									Ranorex.Report.Failure("Field MAX_CAR_WIDTH expected to be length between or equal to 1 and 4, has length of {" + max_car_width_constraint.MAX_CAR_WIDTH.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_width_constraint.MAX_CAR_WIDTH)) {
									Ranorex.Report.Failure("Field MAX_CAR_WIDTH expected to be Numeric, has value of {" + max_car_width_constraint.MAX_CAR_WIDTH + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH_TO != null) {
							max_car_width_constraint.MAX_CAR_WIDTH_TO = content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH_TO[0].Value;
							if (max_car_width_constraint.MAX_CAR_WIDTH_TO != null) {
								if (max_car_width_constraint.MAX_CAR_WIDTH_TO.Length < 1 || max_car_width_constraint.MAX_CAR_WIDTH_TO.Length > 6) {
									Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO expected to be length between or equal to 1 and 6, has length of {" + max_car_width_constraint.MAX_CAR_WIDTH_TO.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO is a Mandatory field but was found to be missing from the message");
						}

						if (content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH_TO_PASS_COUNT != null) {
							max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT = content.MAX_CAR_WIDTH_CONSTRAINT[i].MAX_CAR_WIDTH_TO_PASS_COUNT[0].Value;
							if (max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT != null) {
								if (max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO_PASS_COUNT expected to be length of 1, has length of {" + max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT)) {
									Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO_PASS_COUNT expected to be Numeric, has value of {" + max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field MAX_CAR_WIDTH_TO_PASS_COUNT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addMAX_CAR_WIDTH_CONSTRAINT(max_car_width_constraint);
					}
				}

				if (content.NUMBER_OF_HAZMAT_CONSTRAINTS != null) {
					messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS = content.NUMBER_OF_HAZMAT_CONSTRAINTS[0].Value;
					if (messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS != null) {
						if (messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS.Length < 1 || messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_HAZMAT_CONSTRAINTS expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS)) {
							Ranorex.Report.Failure("Field NUMBER_OF_HAZMAT_CONSTRAINTS expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_HAZMAT_CONSTRAINTS + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_HAZMAT_CONSTRAINTS is a Mandatory field but was found to be missing from the message");
				}
				if (content.HAZMAT_CONSTRAINT != null) {
					for (int i = 0; i < content.HAZMAT_CONSTRAINT.Length; i++) {
						MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43 hazmat_constraint = new MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43();

						if (content.HAZMAT_CONSTRAINT[i].KEY_TRAIN_INDICATOR != null) {
							hazmat_constraint.KEY_TRAIN_INDICATOR = content.HAZMAT_CONSTRAINT[i].KEY_TRAIN_INDICATOR[0].Value;
							if (hazmat_constraint.KEY_TRAIN_INDICATOR != null) {
								if (hazmat_constraint.KEY_TRAIN_INDICATOR.Length != 1) {
									Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR expected to be length of 1, has length of {" + hazmat_constraint.KEY_TRAIN_INDICATOR.Length.ToString() + "}.");
								}
								if (ContainsDigits(hazmat_constraint.KEY_TRAIN_INDICATOR)) {
									Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR expected to be Alphabetic, has value of {" + hazmat_constraint.KEY_TRAIN_INDICATOR + "}.");
								}
								if (hazmat_constraint.KEY_TRAIN_INDICATOR != "Y" && hazmat_constraint.KEY_TRAIN_INDICATOR != "N" && hazmat_constraint.KEY_TRAIN_INDICATOR != "X" && hazmat_constraint.KEY_TRAIN_INDICATOR != "Z" && hazmat_constraint.KEY_TRAIN_INDICATOR != "") {
									Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR expected to be one of the following values {Y, N, X, Z, }, but was found to be {" + hazmat_constraint.KEY_TRAIN_INDICATOR + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field KEY_TRAIN_INDICATOR is a Mandatory field but was found to be missing from the message");
						}

						if (content.HAZMAT_CONSTRAINT[i].HAZMAT_TRAIN_TO != null) {
							hazmat_constraint.HAZMAT_TRAIN_TO = content.HAZMAT_CONSTRAINT[i].HAZMAT_TRAIN_TO[0].Value;
							if (hazmat_constraint.HAZMAT_TRAIN_TO != null) {
								if (hazmat_constraint.HAZMAT_TRAIN_TO.Length < 1 || hazmat_constraint.HAZMAT_TRAIN_TO.Length > 6) {
									Ranorex.Report.Failure("Field HAZMAT_TRAIN_TO expected to be length between or equal to 1 and 6, has length of {" + hazmat_constraint.HAZMAT_TRAIN_TO.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field HAZMAT_TRAIN_TO is a Mandatory field but was found to be missing from the message");
						}

						if (content.HAZMAT_CONSTRAINT[i].KEY_TRAIN_TO_PASS_COUNT != null) {
							hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT = content.HAZMAT_CONSTRAINT[i].KEY_TRAIN_TO_PASS_COUNT[0].Value;
							if (hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT != null) {
								if (hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field KEY_TRAIN_TO_PASS_COUNT expected to be length of 1, has length of {" + hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT)) {
									Ranorex.Report.Failure("Field KEY_TRAIN_TO_PASS_COUNT expected to be Numeric, has value of {" + hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field KEY_TRAIN_TO_PASS_COUNT is a Mandatory field but was found to be missing from the message");
						}

						messagecontent.addHAZMAT_CONSTRAINT(hazmat_constraint);
					}
				}

				ns_trainconsistsummary_43.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_trainconsistsummary_43;
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

		public static void createNS_TrainConsistSummary_43(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_reporting_location,
			string content_reporting_pass_count,
			string content_reporting_date,
			string content_reporting_time,
			string content_reporting_time_zone,
			string content_reporting_source,
			string content_number_of_tih_constraints,
			string content_tih_constraint,
			string content_max_plate_size,
			string content_number_of_loads,
			string content_number_of_empties,
			string content_trailing_tonnage,
			string content_train_length,
			string content_axles,
			string content_operative_brakes,
			string content_total_braking_force,
			string content_speed_class,
			string content_number_of_max_car_weight_constraints,
			string content_max_car_weight_constraint,
			string content_number_of_max_car_height_constraints,
			string content_max_car_height_constraint,
			string content_number_of_max_car_width_constraints,
			string content_max_car_width_constraint,
			string content_number_of_hazmat_constraints,
			string content_hazmat_constraint,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainConsistSummary_43 mis_ns_trainconsistsummary = buildMIS_NS_TrainConsistSummary_43(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_reporting_location, content_reporting_pass_count, content_reporting_date, content_reporting_time, content_reporting_time_zone, content_reporting_source, content_number_of_tih_constraints, content_tih_constraint, content_max_plate_size, content_number_of_loads, content_number_of_empties, content_trailing_tonnage, content_train_length, content_axles, content_operative_brakes, content_total_braking_force, content_speed_class, content_number_of_max_car_weight_constraints, content_max_car_weight_constraint, content_number_of_max_car_height_constraints, content_max_car_height_constraint, content_number_of_max_car_width_constraints, content_max_car_width_constraint, content_number_of_hazmat_constraints, content_hazmat_constraint);

			NS_TrainConsistSummary_43 ns_trainconsistsummary = mis_ns_trainconsistsummary.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainConsistSummary_43));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_trainconsistsummary);
			fs.Close();

			string request = File.ReadAllText(temp+"/temp.request");
			if (hostname == "" || hostname == "Local") {
				
				request = mis_ns_trainconsistsummary.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else if (hostname == "RanorexRemote") {
				request = mis_ns_trainconsistsummary.toSteMessageHeader(request, false);
				Server.SendCommandToSTE(request);
			} else {
				request = mis_ns_trainconsistsummary.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainConsistSummary_43 buildMIS_NS_TrainConsistSummary_43(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_reporting_location,
			string content_reporting_pass_count,
			string content_reporting_date,
			string content_reporting_time,
			string content_reporting_time_zone,
			string content_reporting_source,
			string content_number_of_tih_constraints,
			string content_tih_constraint,
			string content_max_plate_size,
			string content_number_of_loads,
			string content_number_of_empties,
			string content_trailing_tonnage,
			string content_train_length,
			string content_axles,
			string content_operative_brakes,
			string content_total_braking_force,
			string content_speed_class,
			string content_number_of_max_car_weight_constraints,
			string content_max_car_weight_constraint,
			string content_number_of_max_car_height_constraints,
			string content_max_car_height_constraint,
			string content_number_of_max_car_width_constraints,
			string content_max_car_width_constraint,
			string content_number_of_hazmat_constraints,
			string content_hazmat_constraint
		) {

			MIS_NS_TrainConsistSummary_43 mis_ns_trainconsistsummary = new MIS_NS_TrainConsistSummary_43();

			MIS_NS_TrainConsistSummaryHEADER_43 header = new MIS_NS_TrainConsistSummaryHEADER_43();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainConsistSummaryCONTENT_43 content = new MIS_NS_TrainConsistSummaryCONTENT_43();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.REPORTING_LOCATION = content_reporting_location;
			content.REPORTING_PASS_COUNT = content_reporting_pass_count;
			content.REPORTING_DATE = content_reporting_date;
			content.REPORTING_TIME = content_reporting_time;
			content.REPORTING_TIME_ZONE = content_reporting_time_zone;
			content.REPORTING_SOURCE = content_reporting_source;
			content.NUMBER_OF_TIH_CONSTRAINTS = content_number_of_tih_constraints;
			if (content_tih_constraint != "") {
				string[] tih_constraintList = content_tih_constraint.Split('|');
				for (int i = 0; i < tih_constraintList.Length;) {
					MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43 tih_constraints = new MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43();
					tih_constraints.TIH_INDICATOR = tih_constraintList[i];i++;
					tih_constraints.TIH_TRAIN_TO = tih_constraintList[i];i++;
					tih_constraints.TIH_TRAIN_TO_PASS_COUNT = tih_constraintList[i];i++;
					content.addTIH_CONSTRAINT(tih_constraints);
				}
			}
			content.MAX_PLATE_SIZE = content_max_plate_size;
			content.NUMBER_OF_LOADS = content_number_of_loads;
			content.NUMBER_OF_EMPTIES = content_number_of_empties;
			content.TRAILING_TONNAGE = content_trailing_tonnage;
			content.TRAIN_LENGTH = content_train_length;
			content.AXLES = content_axles;
			content.OPERATIVE_BRAKES = content_operative_brakes;
			content.TOTAL_BRAKING_FORCE = content_total_braking_force;
			content.SPEED_CLASS = content_speed_class;
			content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS = content_number_of_max_car_weight_constraints;
			if (content_max_car_weight_constraint != "") {
				string[] max_car_weight_constraintList = content_max_car_weight_constraint.Split('|');
				for (int i = 0; i < max_car_weight_constraintList.Length;) {
					MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43 max_car_weight_constraints = new MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43();
					max_car_weight_constraints.MAX_CAR_WEIGHT = max_car_weight_constraintList[i];i++;
					max_car_weight_constraints.MAX_CAR_WEIGHT_TO = max_car_weight_constraintList[i];i++;
					max_car_weight_constraints.MAX_CAR_WEIGHT_TO_PASS_COUNT = max_car_weight_constraintList[i];i++;
					content.addMAX_CAR_WEIGHT_CONSTRAINT(max_car_weight_constraints);
				}
			}
			content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS = content_number_of_max_car_height_constraints;
			if (content_max_car_height_constraint != "") {
				string[] max_car_height_constraintList = content_max_car_height_constraint.Split('|');
				for (int i = 0; i < max_car_height_constraintList.Length;) {
					MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43 max_car_height_constraints = new MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43();
					max_car_height_constraints.MAX_CAR_HEIGHT = max_car_height_constraintList[i];i++;
					max_car_height_constraints.MAX_CAR_HEIGHT_TO = max_car_height_constraintList[i];i++;
					max_car_height_constraints.MAX_CAR_HEIGHT_TO_PASS_COUNT = max_car_height_constraintList[i];i++;
					content.addMAX_CAR_HEIGHT_CONSTRAINT(max_car_height_constraints);
				}
			}
			content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS = content_number_of_max_car_width_constraints;
			if (content_max_car_width_constraint != "") {
				string[] max_car_width_constraintList = content_max_car_width_constraint.Split('|');
				for (int i = 0; i < max_car_width_constraintList.Length;) {
					MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43 max_car_width_constraints = new MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43();
					max_car_width_constraints.MAX_CAR_WIDTH = max_car_width_constraintList[i];i++;
					max_car_width_constraints.MAX_CAR_WIDTH_TO = max_car_width_constraintList[i];i++;
					max_car_width_constraints.MAX_CAR_WIDTH_TO_PASS_COUNT = max_car_width_constraintList[i];i++;
					content.addMAX_CAR_WIDTH_CONSTRAINT(max_car_width_constraints);
				}
			}
			content.NUMBER_OF_HAZMAT_CONSTRAINTS = content_number_of_hazmat_constraints;
			if (content_hazmat_constraint != "") {
				string[] hazmat_constraintList = content_hazmat_constraint.Split('|');
				for (int i = 0; i < hazmat_constraintList.Length;) {
					MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43 hazmat_constraints = new MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43();
					hazmat_constraints.KEY_TRAIN_INDICATOR = hazmat_constraintList[i];i++;
					hazmat_constraints.HAZMAT_TRAIN_TO = hazmat_constraintList[i];i++;
					hazmat_constraints.KEY_TRAIN_TO_PASS_COUNT = hazmat_constraintList[i];i++;
					content.addHAZMAT_CONSTRAINT(hazmat_constraints);
				}
			}

			mis_ns_trainconsistsummary.HEADER = header;
			mis_ns_trainconsistsummary.CONTENT = content;
			return mis_ns_trainconsistsummary;
		}

		public NS_TrainConsistSummary_43 toSerializableObject() {
			NS_TrainConsistSummary_43 ns_trainconsistsummary_43 = new NS_TrainConsistSummary_43();
			ns_trainconsistsummary_43.Items = new object[2];

			NS_TrainConsistSummaryHEADER_43 header = new NS_TrainConsistSummaryHEADER_43();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainConsistSummaryHEADER_PROTOCOLID_43[1];
					header.PROTOCOLID[0] = new NS_TrainConsistSummaryHEADER_PROTOCOLID_43();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainConsistSummaryHEADER_MSGID_43[1];
					header.MSGID[0] = new NS_TrainConsistSummaryHEADER_MSGID_43();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_TrainConsistSummaryHEADER_TRACE_ID_43[1];
					header.TRACE_ID[0] = new NS_TrainConsistSummaryHEADER_TRACE_ID_43();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_TrainConsistSummaryHEADER_MESSAGE_VERSION_43[1];
					header.MESSAGE_VERSION[0] = new NS_TrainConsistSummaryHEADER_MESSAGE_VERSION_43();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_TrainConsistSummaryCONTENT_43 content = new NS_TrainConsistSummaryCONTENT_43();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_TrainConsistSummaryCONTENT_SCAC_43[1];
					content.SCAC[0] = new NS_TrainConsistSummaryCONTENT_SCAC_43();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_TrainConsistSummaryCONTENT_SECTION_43[1];
					content.SECTION[0] = new NS_TrainConsistSummaryCONTENT_SECTION_43();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_TrainConsistSummaryCONTENT_TRAIN_SYMBOL_43[1];
					content.TRAIN_SYMBOL[0] = new NS_TrainConsistSummaryCONTENT_TRAIN_SYMBOL_43();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_TrainConsistSummaryCONTENT_ORIGIN_DATE_43[1];
					content.ORIGIN_DATE[0] = new NS_TrainConsistSummaryCONTENT_ORIGIN_DATE_43();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.REPORTING_LOCATION != "Null") {
					content.REPORTING_LOCATION = new NS_TrainConsistSummaryCONTENT_REPORTING_LOCATION_43[1];
					content.REPORTING_LOCATION[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_LOCATION_43();
					content.REPORTING_LOCATION[0].Value = CONTENT.REPORTING_LOCATION;
				}

				if (CONTENT.REPORTING_PASS_COUNT != "Null") {
					content.REPORTING_PASS_COUNT = new NS_TrainConsistSummaryCONTENT_REPORTING_PASS_COUNT_43[1];
					content.REPORTING_PASS_COUNT[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_PASS_COUNT_43();
					content.REPORTING_PASS_COUNT[0].Value = CONTENT.REPORTING_PASS_COUNT;
				}

				if (CONTENT.REPORTING_DATE != null && CONTENT.REPORTING_DATE != "") {
					content.REPORTING_DATE = new NS_TrainConsistSummaryCONTENT_REPORTING_DATE_43[1];
					content.REPORTING_DATE[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_DATE_43();
					if (CONTENT.REPORTING_DATE == "Empty") {
						content.REPORTING_DATE[0].Value = "";
					} else {
						content.REPORTING_DATE[0].Value = CONTENT.REPORTING_DATE;
					}
				}

				if (CONTENT.REPORTING_TIME != null && CONTENT.REPORTING_TIME != "") {
					content.REPORTING_TIME = new NS_TrainConsistSummaryCONTENT_REPORTING_TIME_43[1];
					content.REPORTING_TIME[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_TIME_43();
					if (CONTENT.REPORTING_TIME == "Empty") {
						content.REPORTING_TIME[0].Value = "";
					} else {
						content.REPORTING_TIME[0].Value = CONTENT.REPORTING_TIME;
					}
				}

				if (CONTENT.REPORTING_TIME_ZONE != null && CONTENT.REPORTING_TIME_ZONE != "") {
					content.REPORTING_TIME_ZONE = new NS_TrainConsistSummaryCONTENT_REPORTING_TIME_ZONE_43[1];
					content.REPORTING_TIME_ZONE[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_TIME_ZONE_43();
					if (CONTENT.REPORTING_TIME_ZONE == "Empty") {
						content.REPORTING_TIME_ZONE[0].Value = "";
					} else {
						content.REPORTING_TIME_ZONE[0].Value = CONTENT.REPORTING_TIME_ZONE;
					}
				}

				if (CONTENT.REPORTING_SOURCE != "Null") {
					content.REPORTING_SOURCE = new NS_TrainConsistSummaryCONTENT_REPORTING_SOURCE_43[1];
					content.REPORTING_SOURCE[0] = new NS_TrainConsistSummaryCONTENT_REPORTING_SOURCE_43();
					content.REPORTING_SOURCE[0].Value = CONTENT.REPORTING_SOURCE;
				}

				if (CONTENT.NUMBER_OF_TIH_CONSTRAINTS != "Null") {
					content.NUMBER_OF_TIH_CONSTRAINTS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_TIH_CONSTRAINTS_43[1];
					content.NUMBER_OF_TIH_CONSTRAINTS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_TIH_CONSTRAINTS_43();
					content.NUMBER_OF_TIH_CONSTRAINTS[0].Value = CONTENT.NUMBER_OF_TIH_CONSTRAINTS;
				}

				if (CONTENT.TIH_CONSTRAINT.Count != 0) {
					int tih_constraintIndex = 0;
					content.TIH_CONSTRAINT = new NS_TrainConsistSummaryCONTENT_TIH_CONSTRAINT_43[CONTENT.TIH_CONSTRAINT.Count];
					foreach (MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43 TIH_CONSTRAINT in CONTENT.TIH_CONSTRAINT) {
						NS_TrainConsistSummaryCONTENT_TIH_CONSTRAINT_43 tih_constraint = new NS_TrainConsistSummaryCONTENT_TIH_CONSTRAINT_43();
						if (TIH_CONSTRAINT.TIH_INDICATOR != "Null") {
							tih_constraint.TIH_INDICATOR = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_INDICATOR_43[1];
							tih_constraint.TIH_INDICATOR[0] = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_INDICATOR_43();
							tih_constraint.TIH_INDICATOR[0].Value = TIH_CONSTRAINT.TIH_INDICATOR;
						}

						if (TIH_CONSTRAINT.TIH_TRAIN_TO != null && TIH_CONSTRAINT.TIH_TRAIN_TO != "") {
							tih_constraint.TIH_TRAIN_TO = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_43[1];
							tih_constraint.TIH_TRAIN_TO[0] = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_43();
							if (TIH_CONSTRAINT.TIH_TRAIN_TO == "Empty") {
								tih_constraint.TIH_TRAIN_TO[0].Value = "";
							} else {
								tih_constraint.TIH_TRAIN_TO[0].Value = TIH_CONSTRAINT.TIH_TRAIN_TO;
							}
						}

						if (TIH_CONSTRAINT.TIH_TRAIN_TO_PASS_COUNT != null && TIH_CONSTRAINT.TIH_TRAIN_TO_PASS_COUNT != "") {
							tih_constraint.TIH_TRAIN_TO_PASS_COUNT = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_PASS_COUNT_43[1];
							tih_constraint.TIH_TRAIN_TO_PASS_COUNT[0] = new NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_PASS_COUNT_43();
							if (TIH_CONSTRAINT.TIH_TRAIN_TO_PASS_COUNT == "Empty") {
								tih_constraint.TIH_TRAIN_TO_PASS_COUNT[0].Value = "";
							} else {
								tih_constraint.TIH_TRAIN_TO_PASS_COUNT[0].Value = TIH_CONSTRAINT.TIH_TRAIN_TO_PASS_COUNT;
							}
						}

						content.TIH_CONSTRAINT[tih_constraintIndex] = tih_constraint;
						tih_constraintIndex++;
					}
				}

				if (CONTENT.MAX_PLATE_SIZE != null && CONTENT.MAX_PLATE_SIZE != "") {
					content.MAX_PLATE_SIZE = new NS_TrainConsistSummaryCONTENT_MAX_PLATE_SIZE_43[1];
					content.MAX_PLATE_SIZE[0] = new NS_TrainConsistSummaryCONTENT_MAX_PLATE_SIZE_43();
					if (CONTENT.MAX_PLATE_SIZE == "Empty") {
						content.MAX_PLATE_SIZE[0].Value = "";
					} else {
						content.MAX_PLATE_SIZE[0].Value = CONTENT.MAX_PLATE_SIZE;
					}
				}

				if (CONTENT.NUMBER_OF_LOADS != "Null") {
					content.NUMBER_OF_LOADS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_LOADS_43[1];
					content.NUMBER_OF_LOADS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_LOADS_43();
					content.NUMBER_OF_LOADS[0].Value = CONTENT.NUMBER_OF_LOADS;
				}

				if (CONTENT.NUMBER_OF_EMPTIES != "Null") {
					content.NUMBER_OF_EMPTIES = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_EMPTIES_43[1];
					content.NUMBER_OF_EMPTIES[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_EMPTIES_43();
					content.NUMBER_OF_EMPTIES[0].Value = CONTENT.NUMBER_OF_EMPTIES;
				}

				if (CONTENT.TRAILING_TONNAGE != "Null") {
					content.TRAILING_TONNAGE = new NS_TrainConsistSummaryCONTENT_TRAILING_TONNAGE_43[1];
					content.TRAILING_TONNAGE[0] = new NS_TrainConsistSummaryCONTENT_TRAILING_TONNAGE_43();
					content.TRAILING_TONNAGE[0].Value = CONTENT.TRAILING_TONNAGE;
				}

				if (CONTENT.TRAIN_LENGTH != "Null") {
					content.TRAIN_LENGTH = new NS_TrainConsistSummaryCONTENT_TRAIN_LENGTH_43[1];
					content.TRAIN_LENGTH[0] = new NS_TrainConsistSummaryCONTENT_TRAIN_LENGTH_43();
					content.TRAIN_LENGTH[0].Value = CONTENT.TRAIN_LENGTH;
				}

				if (CONTENT.AXLES != null && CONTENT.AXLES != "") {
					content.AXLES = new NS_TrainConsistSummaryCONTENT_AXLES_43[1];
					content.AXLES[0] = new NS_TrainConsistSummaryCONTENT_AXLES_43();
					if (CONTENT.AXLES == "Empty") {
						content.AXLES[0].Value = "";
					} else {
						content.AXLES[0].Value = CONTENT.AXLES;
					}
				}

				if (CONTENT.OPERATIVE_BRAKES != null && CONTENT.OPERATIVE_BRAKES != "") {
					content.OPERATIVE_BRAKES = new NS_TrainConsistSummaryCONTENT_OPERATIVE_BRAKES_43[1];
					content.OPERATIVE_BRAKES[0] = new NS_TrainConsistSummaryCONTENT_OPERATIVE_BRAKES_43();
					if (CONTENT.OPERATIVE_BRAKES == "Empty") {
						content.OPERATIVE_BRAKES[0].Value = "";
					} else {
						content.OPERATIVE_BRAKES[0].Value = CONTENT.OPERATIVE_BRAKES;
					}
				}

				if (CONTENT.TOTAL_BRAKING_FORCE != null && CONTENT.TOTAL_BRAKING_FORCE != "") {
					content.TOTAL_BRAKING_FORCE = new NS_TrainConsistSummaryCONTENT_TOTAL_BRAKING_FORCE_43[1];
					content.TOTAL_BRAKING_FORCE[0] = new NS_TrainConsistSummaryCONTENT_TOTAL_BRAKING_FORCE_43();
					if (CONTENT.TOTAL_BRAKING_FORCE == "Empty") {
						content.TOTAL_BRAKING_FORCE[0].Value = "";
					} else {
						content.TOTAL_BRAKING_FORCE[0].Value = CONTENT.TOTAL_BRAKING_FORCE;
					}
				}

				if (CONTENT.SPEED_CLASS != null && CONTENT.SPEED_CLASS != "") {
					content.SPEED_CLASS = new NS_TrainConsistSummaryCONTENT_SPEED_CLASS_43[1];
					content.SPEED_CLASS[0] = new NS_TrainConsistSummaryCONTENT_SPEED_CLASS_43();
					if (CONTENT.SPEED_CLASS == "Empty") {
						content.SPEED_CLASS[0].Value = "";
					} else {
						content.SPEED_CLASS[0].Value = CONTENT.SPEED_CLASS;
					}
				}

				if (CONTENT.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS != "Null") {
					content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS_43[1];
					content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS_43();
					content.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS[0].Value = CONTENT.NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS;
				}

				if (CONTENT.MAX_CAR_WEIGHT_CONSTRAINT.Count != 0) {
					int max_car_weight_constraintIndex = 0;
					content.MAX_CAR_WEIGHT_CONSTRAINT = new NS_TrainConsistSummaryCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_43[CONTENT.MAX_CAR_WEIGHT_CONSTRAINT.Count];
					foreach (MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43 MAX_CAR_WEIGHT_CONSTRAINT in CONTENT.MAX_CAR_WEIGHT_CONSTRAINT) {
						NS_TrainConsistSummaryCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_43 max_car_weight_constraint = new NS_TrainConsistSummaryCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_43();
						if (MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT != "Null") {
							max_car_weight_constraint.MAX_CAR_WEIGHT = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_43[1];
							max_car_weight_constraint.MAX_CAR_WEIGHT[0] = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_43();
							max_car_weight_constraint.MAX_CAR_WEIGHT[0].Value = MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT;
						}

						if (MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT_TO != "Null") {
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_43[1];
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO[0] = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_43();
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO[0].Value = MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT_TO;
						}

						if (MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT_TO_PASS_COUNT != "Null") {
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_PASS_COUNT_43[1];
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT[0] = new NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_PASS_COUNT_43();
							max_car_weight_constraint.MAX_CAR_WEIGHT_TO_PASS_COUNT[0].Value = MAX_CAR_WEIGHT_CONSTRAINT.MAX_CAR_WEIGHT_TO_PASS_COUNT;
						}

						content.MAX_CAR_WEIGHT_CONSTRAINT[max_car_weight_constraintIndex] = max_car_weight_constraint;
						max_car_weight_constraintIndex++;
					}
				}

				if (CONTENT.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS != "Null") {
					content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS_43[1];
					content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS_43();
					content.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS[0].Value = CONTENT.NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS;
				}

				if (CONTENT.MAX_CAR_HEIGHT_CONSTRAINT.Count != 0) {
					int max_car_height_constraintIndex = 0;
					content.MAX_CAR_HEIGHT_CONSTRAINT = new NS_TrainConsistSummaryCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_43[CONTENT.MAX_CAR_HEIGHT_CONSTRAINT.Count];
					foreach (MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43 MAX_CAR_HEIGHT_CONSTRAINT in CONTENT.MAX_CAR_HEIGHT_CONSTRAINT) {
						NS_TrainConsistSummaryCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_43 max_car_height_constraint = new NS_TrainConsistSummaryCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_43();
						if (MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT != "Null") {
							max_car_height_constraint.MAX_CAR_HEIGHT = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_43[1];
							max_car_height_constraint.MAX_CAR_HEIGHT[0] = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_43();
							max_car_height_constraint.MAX_CAR_HEIGHT[0].Value = MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT;
						}

						if (MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT_TO != "Null") {
							max_car_height_constraint.MAX_CAR_HEIGHT_TO = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_43[1];
							max_car_height_constraint.MAX_CAR_HEIGHT_TO[0] = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_43();
							max_car_height_constraint.MAX_CAR_HEIGHT_TO[0].Value = MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT_TO;
						}

						if (MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT_TO_PASS_COUNT != "Null") {
							max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_PASS_COUNT_43[1];
							max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT[0] = new NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_PASS_COUNT_43();
							max_car_height_constraint.MAX_CAR_HEIGHT_TO_PASS_COUNT[0].Value = MAX_CAR_HEIGHT_CONSTRAINT.MAX_CAR_HEIGHT_TO_PASS_COUNT;
						}

						content.MAX_CAR_HEIGHT_CONSTRAINT[max_car_height_constraintIndex] = max_car_height_constraint;
						max_car_height_constraintIndex++;
					}
				}

				if (CONTENT.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS != "Null") {
					content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS_43[1];
					content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS_43();
					content.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS[0].Value = CONTENT.NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS;
				}

				if (CONTENT.MAX_CAR_WIDTH_CONSTRAINT.Count != 0) {
					int max_car_width_constraintIndex = 0;
					content.MAX_CAR_WIDTH_CONSTRAINT = new NS_TrainConsistSummaryCONTENT_MAX_CAR_WIDTH_CONSTRAINT_43[CONTENT.MAX_CAR_WIDTH_CONSTRAINT.Count];
					foreach (MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43 MAX_CAR_WIDTH_CONSTRAINT in CONTENT.MAX_CAR_WIDTH_CONSTRAINT) {
						NS_TrainConsistSummaryCONTENT_MAX_CAR_WIDTH_CONSTRAINT_43 max_car_width_constraint = new NS_TrainConsistSummaryCONTENT_MAX_CAR_WIDTH_CONSTRAINT_43();
						if (MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH != "Null") {
							max_car_width_constraint.MAX_CAR_WIDTH = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_43[1];
							max_car_width_constraint.MAX_CAR_WIDTH[0] = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_43();
							max_car_width_constraint.MAX_CAR_WIDTH[0].Value = MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH;
						}

						if (MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH_TO != "Null") {
							max_car_width_constraint.MAX_CAR_WIDTH_TO = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_43[1];
							max_car_width_constraint.MAX_CAR_WIDTH_TO[0] = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_43();
							max_car_width_constraint.MAX_CAR_WIDTH_TO[0].Value = MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH_TO;
						}

						if (MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH_TO_PASS_COUNT != "Null") {
							max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_PASS_COUNT_43[1];
							max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT[0] = new NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_PASS_COUNT_43();
							max_car_width_constraint.MAX_CAR_WIDTH_TO_PASS_COUNT[0].Value = MAX_CAR_WIDTH_CONSTRAINT.MAX_CAR_WIDTH_TO_PASS_COUNT;
						}

						content.MAX_CAR_WIDTH_CONSTRAINT[max_car_width_constraintIndex] = max_car_width_constraint;
						max_car_width_constraintIndex++;
					}
				}

				if (CONTENT.NUMBER_OF_HAZMAT_CONSTRAINTS != "Null") {
					content.NUMBER_OF_HAZMAT_CONSTRAINTS = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_HAZMAT_CONSTRAINTS_43[1];
					content.NUMBER_OF_HAZMAT_CONSTRAINTS[0] = new NS_TrainConsistSummaryCONTENT_NUMBER_OF_HAZMAT_CONSTRAINTS_43();
					content.NUMBER_OF_HAZMAT_CONSTRAINTS[0].Value = CONTENT.NUMBER_OF_HAZMAT_CONSTRAINTS;
				}

				if (CONTENT.HAZMAT_CONSTRAINT.Count != 0) {
					int hazmat_constraintIndex = 0;
					content.HAZMAT_CONSTRAINT = new NS_TrainConsistSummaryCONTENT_HAZMAT_CONSTRAINT_43[CONTENT.HAZMAT_CONSTRAINT.Count];
					foreach (MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43 HAZMAT_CONSTRAINT in CONTENT.HAZMAT_CONSTRAINT) {
						NS_TrainConsistSummaryCONTENT_HAZMAT_CONSTRAINT_43 hazmat_constraint = new NS_TrainConsistSummaryCONTENT_HAZMAT_CONSTRAINT_43();
						if (HAZMAT_CONSTRAINT.KEY_TRAIN_INDICATOR != "Null") {
							hazmat_constraint.KEY_TRAIN_INDICATOR = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_INDICATOR_43[1];
							hazmat_constraint.KEY_TRAIN_INDICATOR[0] = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_INDICATOR_43();
							hazmat_constraint.KEY_TRAIN_INDICATOR[0].Value = HAZMAT_CONSTRAINT.KEY_TRAIN_INDICATOR;
						}

						if (HAZMAT_CONSTRAINT.HAZMAT_TRAIN_TO != "Null") {
							hazmat_constraint.HAZMAT_TRAIN_TO = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_HAZMAT_TRAIN_TO_43[1];
							hazmat_constraint.HAZMAT_TRAIN_TO[0] = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_HAZMAT_TRAIN_TO_43();
							hazmat_constraint.HAZMAT_TRAIN_TO[0].Value = HAZMAT_CONSTRAINT.HAZMAT_TRAIN_TO;
						}

						if (HAZMAT_CONSTRAINT.KEY_TRAIN_TO_PASS_COUNT != "Null") {
							hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_TO_PASS_COUNT_43[1];
							hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT[0] = new NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_TO_PASS_COUNT_43();
							hazmat_constraint.KEY_TRAIN_TO_PASS_COUNT[0].Value = HAZMAT_CONSTRAINT.KEY_TRAIN_TO_PASS_COUNT;
						}

						content.HAZMAT_CONSTRAINT[hazmat_constraintIndex] = hazmat_constraint;
						hazmat_constraintIndex++;
					}
				}

			}

			ns_trainconsistsummary_43.Items[0] = header;
			ns_trainconsistsummary_43.Items[1] = content;
			return ns_trainconsistsummary_43;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNCON,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNCON,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainConsistSummaryHEADER_43 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainConsistSummaryCONTENT_43 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string REPORTING_LOCATION = "";
		public string REPORTING_PASS_COUNT = "";
		public string REPORTING_DATE = "";
		public string REPORTING_TIME = "";
		public string REPORTING_TIME_ZONE = "";
		public string REPORTING_SOURCE = "";
		public string NUMBER_OF_TIH_CONSTRAINTS = "";
		public ArrayList TIH_CONSTRAINT = new ArrayList();
		public string MAX_PLATE_SIZE = "";
		public string NUMBER_OF_LOADS = "";
		public string NUMBER_OF_EMPTIES = "";
		public string TRAILING_TONNAGE = "";
		public string TRAIN_LENGTH = "";
		public string AXLES = "";
		public string OPERATIVE_BRAKES = "";
		public string TOTAL_BRAKING_FORCE = "";
		public string SPEED_CLASS = "";
		public string NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS = "";
		public ArrayList MAX_CAR_WEIGHT_CONSTRAINT = new ArrayList();
		public string NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS = "";
		public ArrayList MAX_CAR_HEIGHT_CONSTRAINT = new ArrayList();
		public string NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS = "";
		public ArrayList MAX_CAR_WIDTH_CONSTRAINT = new ArrayList();
		public string NUMBER_OF_HAZMAT_CONSTRAINTS = "";
		public ArrayList HAZMAT_CONSTRAINT = new ArrayList();

		public void addTIH_CONSTRAINT(MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43 tih_constraint) {
			this.TIH_CONSTRAINT.Add(tih_constraint);
		}

		public void addMAX_CAR_WEIGHT_CONSTRAINT(MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43 max_car_weight_constraint) {
			this.MAX_CAR_WEIGHT_CONSTRAINT.Add(max_car_weight_constraint);
		}

		public void addMAX_CAR_HEIGHT_CONSTRAINT(MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43 max_car_height_constraint) {
			this.MAX_CAR_HEIGHT_CONSTRAINT.Add(max_car_height_constraint);
		}

		public void addMAX_CAR_WIDTH_CONSTRAINT(MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43 max_car_width_constraint) {
			this.MAX_CAR_WIDTH_CONSTRAINT.Add(max_car_width_constraint);
		}

		public void addHAZMAT_CONSTRAINT(MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43 hazmat_constraint) {
			this.HAZMAT_CONSTRAINT.Add(hazmat_constraint);
		}
	}

	public partial class MIS_NS_TrainConsistSummaryTIH_CONSTRAINT_43 {
		public string TIH_INDICATOR = "";
		public string TIH_TRAIN_TO = "";
		public string TIH_TRAIN_TO_PASS_COUNT = "";
	}

	public partial class MIS_NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_43 {
		public string MAX_CAR_WEIGHT = "";
		public string MAX_CAR_WEIGHT_TO = "";
		public string MAX_CAR_WEIGHT_TO_PASS_COUNT = "";
	}

	public partial class MIS_NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_43 {
		public string MAX_CAR_HEIGHT = "";
		public string MAX_CAR_HEIGHT_TO = "";
		public string MAX_CAR_HEIGHT_TO_PASS_COUNT = "";
	}

	public partial class MIS_NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_43 {
		public string MAX_CAR_WIDTH = "";
		public string MAX_CAR_WIDTH_TO = "";
		public string MAX_CAR_WIDTH_TO_PASS_COUNT = "";
	}

	public partial class MIS_NS_TrainConsistSummaryHAZMAT_CONSTRAINT_43 {
		public string KEY_TRAIN_INDICATOR = "";
		public string HAZMAT_TRAIN_TO = "";
		public string KEY_TRAIN_TO_PASS_COUNT = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainConsistSummary", IsNullable = false)]
	public partial class NS_TrainConsistSummary_43 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainConsistSummaryHEADER_43), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainConsistSummaryCONTENT_43), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHEADER_43 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHEADER_PROTOCOLID_43[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHEADER_MSGID_43[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHEADER_TRACE_ID_43[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHEADER_MESSAGE_VERSION_43[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHEADER_PROTOCOLID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHEADER_MSGID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHEADER_TRACE_ID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHEADER_MESSAGE_VERSION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_43 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_SCAC_43[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_SECTION_43[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_TRAIN_SYMBOL_43[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_ORIGIN_DATE_43[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_LOCATION_43[] REPORTING_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_PASS_COUNT_43[] REPORTING_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_DATE_43[] REPORTING_DATE;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_TIME_43[] REPORTING_TIME;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_TIME_ZONE_43[] REPORTING_TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_SOURCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_REPORTING_SOURCE_43[] REPORTING_SOURCE;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_TIH_CONSTRAINTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_TIH_CONSTRAINTS_43[] NUMBER_OF_TIH_CONSTRAINTS;

		[System.Xml.Serialization.XmlElementAttribute("TIH_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_TIH_CONSTRAINT_43[] TIH_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_PLATE_SIZE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_MAX_PLATE_SIZE_43[] MAX_PLATE_SIZE;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_LOADS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_LOADS_43[] NUMBER_OF_LOADS;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_EMPTIES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_EMPTIES_43[] NUMBER_OF_EMPTIES;

		[System.Xml.Serialization.XmlElementAttribute("TRAILING_TONNAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_TRAILING_TONNAGE_43[] TRAILING_TONNAGE;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_LENGTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_TRAIN_LENGTH_43[] TRAIN_LENGTH;

		[System.Xml.Serialization.XmlElementAttribute("AXLES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_AXLES_43[] AXLES;

		[System.Xml.Serialization.XmlElementAttribute("OPERATIVE_BRAKES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_OPERATIVE_BRAKES_43[] OPERATIVE_BRAKES;

		[System.Xml.Serialization.XmlElementAttribute("TOTAL_BRAKING_FORCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_TOTAL_BRAKING_FORCE_43[] TOTAL_BRAKING_FORCE;

		[System.Xml.Serialization.XmlElementAttribute("SPEED_CLASS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_SPEED_CLASS_43[] SPEED_CLASS;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS_43[] NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_43[] MAX_CAR_WEIGHT_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS_43[] NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_43[] MAX_CAR_HEIGHT_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS_43[] NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_MAX_CAR_WIDTH_CONSTRAINT_43[] MAX_CAR_WIDTH_CONSTRAINT;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_HAZMAT_CONSTRAINTS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_NUMBER_OF_HAZMAT_CONSTRAINTS_43[] NUMBER_OF_HAZMAT_CONSTRAINTS;

		[System.Xml.Serialization.XmlElementAttribute("HAZMAT_CONSTRAINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryCONTENT_HAZMAT_CONSTRAINT_43[] HAZMAT_CONSTRAINT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_SCAC_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_SECTION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_TRAIN_SYMBOL_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_ORIGIN_DATE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_LOCATION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_DATE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_TIME_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_TIME_ZONE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_REPORTING_SOURCE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_TIH_CONSTRAINTS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_TIH_CONSTRAINT_43 {
		[System.Xml.Serialization.XmlElementAttribute("TIH_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_INDICATOR_43[] TIH_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("TIH_TRAIN_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_43[] TIH_TRAIN_TO;

		[System.Xml.Serialization.XmlElementAttribute("TIH_TRAIN_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_PASS_COUNT_43[] TIH_TRAIN_TO_PASS_COUNT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_INDICATOR_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryTIH_CONSTRAINT_TIH_TRAIN_TO_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_MAX_PLATE_SIZE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_LOADS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_EMPTIES_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_TRAILING_TONNAGE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_TRAIN_LENGTH_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_AXLES_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_OPERATIVE_BRAKES_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_TOTAL_BRAKING_FORCE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_SPEED_CLASS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WEIGHT_CONSTRAINTS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_MAX_CAR_WEIGHT_CONSTRAINT_43 {
		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_43[] MAX_CAR_WEIGHT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_43[] MAX_CAR_WEIGHT_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WEIGHT_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_PASS_COUNT_43[] MAX_CAR_WEIGHT_TO_PASS_COUNT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WEIGHT_CONSTRAINT_MAX_CAR_WEIGHT_TO_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_HEIGHT_CONSTRAINTS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_MAX_CAR_HEIGHT_CONSTRAINT_43 {
		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_43[] MAX_CAR_HEIGHT;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_43[] MAX_CAR_HEIGHT_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_HEIGHT_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_PASS_COUNT_43[] MAX_CAR_HEIGHT_TO_PASS_COUNT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_HEIGHT_CONSTRAINT_MAX_CAR_HEIGHT_TO_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_MAX_CAR_WIDTH_CONSTRAINTS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_MAX_CAR_WIDTH_CONSTRAINT_43 {
		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_43[] MAX_CAR_WIDTH;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_43[] MAX_CAR_WIDTH_TO;

		[System.Xml.Serialization.XmlElementAttribute("MAX_CAR_WIDTH_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_PASS_COUNT_43[] MAX_CAR_WIDTH_TO_PASS_COUNT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryMAX_CAR_WIDTH_CONSTRAINT_MAX_CAR_WIDTH_TO_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_NUMBER_OF_HAZMAT_CONSTRAINTS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryCONTENT_HAZMAT_CONSTRAINT_43 {
		[System.Xml.Serialization.XmlElementAttribute("KEY_TRAIN_INDICATOR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_INDICATOR_43[] KEY_TRAIN_INDICATOR;

		[System.Xml.Serialization.XmlElementAttribute("HAZMAT_TRAIN_TO", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHAZMAT_CONSTRAINT_HAZMAT_TRAIN_TO_43[] HAZMAT_TRAIN_TO;

		[System.Xml.Serialization.XmlElementAttribute("KEY_TRAIN_TO_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_TO_PASS_COUNT_43[] KEY_TRAIN_TO_PASS_COUNT;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_INDICATOR_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHAZMAT_CONSTRAINT_HAZMAT_TRAIN_TO_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainConsistSummaryHAZMAT_CONSTRAINT_KEY_TRAIN_TO_PASS_COUNT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}