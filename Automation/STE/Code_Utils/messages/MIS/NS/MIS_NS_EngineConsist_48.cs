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
	public partial class MIS_NS_EngineConsist_48 {
		public MIS_NS_EngineConsistHEADER_48 HEADER;
		public MIS_NS_EngineConsistCONTENT_48 CONTENT;

		public static MIS_NS_EngineConsist_48 fromSerializableObject(NS_EngineConsist_48 message) {
			MIS_NS_EngineConsist_48 ns_engineconsist_48 = new MIS_NS_EngineConsist_48();
			NS_EngineConsistHEADER_48 header = null;
			NS_EngineConsistCONTENT_48 content = null;
			header = (NS_EngineConsistHEADER_48) message.Items[0];
			content = (NS_EngineConsistCONTENT_48) message.Items[1];

			if (header != null) {
				MIS_NS_EngineConsistHEADER_48 messageheader = new MIS_NS_EngineConsistHEADER_48();

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

				ns_engineconsist_48.HEADER = messageheader;

			} else {
				Ranorex.Report.Failure("Field HEADER is a Mandatory field but was found to be missing from the message");
			}

			if (content != null) {
				MIS_NS_EngineConsistCONTENT_48 messagecontent = new MIS_NS_EngineConsistCONTENT_48();

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

				if (content.ASSIGNED_DIVISION != null) {
					messagecontent.ASSIGNED_DIVISION = content.ASSIGNED_DIVISION[0].Value;
					if (messagecontent.ASSIGNED_DIVISION != null) {
						if (messagecontent.ASSIGNED_DIVISION.Length < 0 || messagecontent.ASSIGNED_DIVISION.Length > 24) {
							Ranorex.Report.Failure("Field ASSIGNED_DIVISION expected to be length between or equal to 0 and 24, has length of {" + messagecontent.ASSIGNED_DIVISION.Length.ToString() + "}.");
						}
					}
				}

				if (content.HELPER_CREW_POOL_ID != null) {
					messagecontent.HELPER_CREW_POOL_ID = content.HELPER_CREW_POOL_ID[0].Value;
					if (messagecontent.HELPER_CREW_POOL_ID != null) {
						if (messagecontent.HELPER_CREW_POOL_ID.Length < 0 || messagecontent.HELPER_CREW_POOL_ID.Length > 4) {
							Ranorex.Report.Failure("Field HELPER_CREW_POOL_ID expected to be length between or equal to 0 and 4, has length of {" + messagecontent.HELPER_CREW_POOL_ID.Length.ToString() + "}.");
						}
					}
				}

				if (content.REPORTING_SOURCE != null) {
					messagecontent.REPORTING_SOURCE = content.REPORTING_SOURCE[0].Value;
					if (messagecontent.REPORTING_SOURCE != null) {
						if (messagecontent.REPORTING_SOURCE.Length != 1) {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be length of 1, has length of {" + messagecontent.REPORTING_SOURCE.Length.ToString() + "}.");
						}
						if (messagecontent.REPORTING_SOURCE != "P" && messagecontent.REPORTING_SOURCE != "O" && messagecontent.REPORTING_SOURCE != "T" && messagecontent.REPORTING_SOURCE != "D" && messagecontent.REPORTING_SOURCE != "L" && messagecontent.REPORTING_SOURCE != "G" && messagecontent.REPORTING_SOURCE != "C") {
							Ranorex.Report.Failure("Field REPORTING_SOURCE expected to be one of the following values {P, O, T, D, L, G, C (A is obsolete)}, but was found to be {" + messagecontent.REPORTING_SOURCE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field REPORTING_SOURCE is a Mandatory field but was found to be missing from the message");
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
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.REPORTING_PASS_COUNT);
							if (intConvertedValue < 1 || intConvertedValue > 9) {
								Ranorex.Report.Failure("Field REPORTING_PASS_COUNT expected to have value between 1 and 9, but was found to have a value of " + messagecontent.REPORTING_PASS_COUNT + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field REPORTING_PASS_COUNT is a Mandatory field but was found to be missing from the message");
				}

				if (content.DEFAULT_DATA_APPLIED != null) {
					messagecontent.DEFAULT_DATA_APPLIED = content.DEFAULT_DATA_APPLIED[0].Value;
					if (messagecontent.DEFAULT_DATA_APPLIED != null) {
						if (messagecontent.DEFAULT_DATA_APPLIED.Length != 1) {
							Ranorex.Report.Failure("Field DEFAULT_DATA_APPLIED expected to be length of 1, has length of {" + messagecontent.DEFAULT_DATA_APPLIED.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.DEFAULT_DATA_APPLIED)) {
							Ranorex.Report.Failure("Field DEFAULT_DATA_APPLIED expected to be Alphabetic, has value of {" + messagecontent.DEFAULT_DATA_APPLIED + "}.");
						}
						if (messagecontent.DEFAULT_DATA_APPLIED != "Y" && messagecontent.DEFAULT_DATA_APPLIED != "N") {
							Ranorex.Report.Failure("Field DEFAULT_DATA_APPLIED expected to be one of the following values {Y, N}, but was found to be {" + messagecontent.DEFAULT_DATA_APPLIED + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field DEFAULT_DATA_APPLIED is a Mandatory field but was found to be missing from the message");
				}

				if (content.PURPOSE != null) {
					messagecontent.PURPOSE = content.PURPOSE[0].Value;
					if (messagecontent.PURPOSE != null) {
						if (messagecontent.PURPOSE.Length != 1) {
							Ranorex.Report.Failure("Field PURPOSE expected to be length of 1, has length of {" + messagecontent.PURPOSE.Length.ToString() + "}.");
						}
						if (ContainsDigits(messagecontent.PURPOSE)) {
							Ranorex.Report.Failure("Field PURPOSE expected to be Alphabetic, has value of {" + messagecontent.PURPOSE + "}.");
						}
						if (messagecontent.PURPOSE != "A" && messagecontent.PURPOSE != "D" && messagecontent.PURPOSE != "R") {
							Ranorex.Report.Failure("Field PURPOSE expected to be one of the following values {A, D, R}, but was found to be {" + messagecontent.PURPOSE + "}.");
						}
					}
				} else {
					Ranorex.Report.Failure("Field PURPOSE is a Mandatory field but was found to be missing from the message");
				}

				if (content.NUMBER_OF_ENGINES != null) {
					messagecontent.NUMBER_OF_ENGINES = content.NUMBER_OF_ENGINES[0].Value;
					if (messagecontent.NUMBER_OF_ENGINES != null) {
						if (messagecontent.NUMBER_OF_ENGINES.Length < 1 || messagecontent.NUMBER_OF_ENGINES.Length > 2) {
							Ranorex.Report.Failure("Field NUMBER_OF_ENGINES expected to be length between or equal to 1 and 2, has length of {" + messagecontent.NUMBER_OF_ENGINES.Length.ToString() + "}.");
						}
						if (!IsDigitsOnly(messagecontent.NUMBER_OF_ENGINES)) {
							Ranorex.Report.Failure("Field NUMBER_OF_ENGINES expected to be Numeric, has value of {" + messagecontent.NUMBER_OF_ENGINES + "}.");
						} else {
							int intConvertedValue = Convert.ToInt32(messagecontent.NUMBER_OF_ENGINES);
							if (intConvertedValue < 0 || intConvertedValue > 99) {
								Ranorex.Report.Failure("Field NUMBER_OF_ENGINES expected to have value between 0 and 99, but was found to have a value of " + messagecontent.NUMBER_OF_ENGINES + ".");
							}
						}
					}
				} else {
					Ranorex.Report.Failure("Field NUMBER_OF_ENGINES is a Mandatory field but was found to be missing from the message");
				}
				if (content.ENGINE_RECORD != null) {
					for (int i = 0; i < content.ENGINE_RECORD.Length; i++) {
						MIS_NS_EngineConsistENGINE_RECORD_48 engine_record = new MIS_NS_EngineConsistENGINE_RECORD_48();

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
								if (engine_record.ENGINE_NUMBER.Length < 1 || engine_record.ENGINE_NUMBER.Length > 6) {
									Ranorex.Report.Failure("Field ENGINE_NUMBER expected to be length between or equal to 1 and 6, has length of {" + engine_record.ENGINE_NUMBER.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.ENGINE_NUMBER)) {
									Ranorex.Report.Failure("Field ENGINE_NUMBER expected to be Numeric, has value of {" + engine_record.ENGINE_NUMBER + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.ENGINE_NUMBER);
									if (intConvertedValue < 0 || intConvertedValue > 999999) {
										Ranorex.Report.Failure("Field ENGINE_NUMBER expected to have value between 0 and 999999, but was found to have a value of " + engine_record.ENGINE_NUMBER + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_POSITION != null) {
							engine_record.ENGINE_POSITION = content.ENGINE_RECORD[i].ENGINE_POSITION[0].Value;
							if (engine_record.ENGINE_POSITION != null) {
								if (engine_record.ENGINE_POSITION.Length < 1 || engine_record.ENGINE_POSITION.Length > 3) {
									Ranorex.Report.Failure("Field ENGINE_POSITION expected to be length between or equal to 1 and 3, has length of {" + engine_record.ENGINE_POSITION.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.ENGINE_POSITION)) {
									Ranorex.Report.Failure("Field ENGINE_POSITION expected to be Numeric, has value of {" + engine_record.ENGINE_POSITION + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.ENGINE_POSITION);
									if (intConvertedValue < 0 || intConvertedValue > 999) {
										Ranorex.Report.Failure("Field ENGINE_POSITION expected to have value between 0 and 999, but was found to have a value of " + engine_record.ENGINE_POSITION + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_POSITION is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ENGINE_ORIENTATION != null) {
							engine_record.ENGINE_ORIENTATION = content.ENGINE_RECORD[i].ENGINE_ORIENTATION[0].Value;
							if (engine_record.ENGINE_ORIENTATION != null) {
								if (engine_record.ENGINE_ORIENTATION.Length < 4 || engine_record.ENGINE_ORIENTATION.Length > 5) {
									Ranorex.Report.Failure("Field ENGINE_ORIENTATION expected to be length between or equal to 4 and 5, has length of {" + engine_record.ENGINE_ORIENTATION.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.ENGINE_ORIENTATION)) {
									Ranorex.Report.Failure("Field ENGINE_ORIENTATION expected to be Alphabetic, has value of {" + engine_record.ENGINE_ORIENTATION + "}.");
								}
								if (engine_record.ENGINE_ORIENTATION != "FRONT" && engine_record.ENGINE_ORIENTATION != "BACK") {
									Ranorex.Report.Failure("Field ENGINE_ORIENTATION expected to be one of the following values {FRONT, BACK}, but was found to be {" + engine_record.ENGINE_ORIENTATION + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].ENGINE_LOCK != null) {
							engine_record.ENGINE_LOCK = content.ENGINE_RECORD[i].ENGINE_LOCK[0].Value;
							if (engine_record.ENGINE_LOCK != null) {
								if (engine_record.ENGINE_LOCK.Length != 1) {
									Ranorex.Report.Failure("Field ENGINE_LOCK expected to be length of 1, has length of {" + engine_record.ENGINE_LOCK.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.ENGINE_LOCK)) {
									Ranorex.Report.Failure("Field ENGINE_LOCK expected to be Alphabetic, has value of {" + engine_record.ENGINE_LOCK + "}.");
								}
								if (engine_record.ENGINE_LOCK != "Y" && engine_record.ENGINE_LOCK != "N") {
									Ranorex.Report.Failure("Field ENGINE_LOCK expected to be one of the following values {Y, N}, but was found to be {" + engine_record.ENGINE_LOCK + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_LOCK is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].ORIGIN_PASS_COUNT != null) {
							engine_record.ORIGIN_PASS_COUNT = content.ENGINE_RECORD[i].ORIGIN_PASS_COUNT[0].Value;
							if (engine_record.ORIGIN_PASS_COUNT != null) {
								if (engine_record.ORIGIN_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field ORIGIN_PASS_COUNT expected to be length of 1, has length of {" + engine_record.ORIGIN_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.ORIGIN_PASS_COUNT)) {
									Ranorex.Report.Failure("Field ORIGIN_PASS_COUNT expected to be Numeric, has value of {" + engine_record.ORIGIN_PASS_COUNT + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.ORIGIN_PASS_COUNT);
									if (intConvertedValue < 1 || intConvertedValue > 9) {
										Ranorex.Report.Failure("Field ORIGIN_PASS_COUNT expected to have value between 1 and 9, but was found to have a value of " + engine_record.ORIGIN_PASS_COUNT + ".");
									}
								}
							}
						}

						if (content.ENGINE_RECORD[i].ORIGIN_LOCATION != null) {
							engine_record.ORIGIN_LOCATION = content.ENGINE_RECORD[i].ORIGIN_LOCATION[0].Value;
							if (engine_record.ORIGIN_LOCATION != null) {
								if (engine_record.ORIGIN_LOCATION.Length < 0 || engine_record.ORIGIN_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field ORIGIN_LOCATION expected to be length between or equal to 0 and 6, has length of {" + engine_record.ORIGIN_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].DESTINATION_PASS_COUNT != null) {
							engine_record.DESTINATION_PASS_COUNT = content.ENGINE_RECORD[i].DESTINATION_PASS_COUNT[0].Value;
							if (engine_record.DESTINATION_PASS_COUNT != null) {
								if (engine_record.DESTINATION_PASS_COUNT.Length != 1) {
									Ranorex.Report.Failure("Field DESTINATION_PASS_COUNT expected to be length of 1, has length of {" + engine_record.DESTINATION_PASS_COUNT.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.DESTINATION_PASS_COUNT)) {
									Ranorex.Report.Failure("Field DESTINATION_PASS_COUNT expected to be Numeric, has value of {" + engine_record.DESTINATION_PASS_COUNT + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.DESTINATION_PASS_COUNT);
									if (intConvertedValue < 1 || intConvertedValue > 9) {
										Ranorex.Report.Failure("Field DESTINATION_PASS_COUNT expected to have value between 1 and 9, but was found to have a value of " + engine_record.DESTINATION_PASS_COUNT + ".");
									}
								}
							}
						}

						if (content.ENGINE_RECORD[i].DESTINATION_LOCATION != null) {
							engine_record.DESTINATION_LOCATION = content.ENGINE_RECORD[i].DESTINATION_LOCATION[0].Value;
							if (engine_record.DESTINATION_LOCATION != null) {
								if (engine_record.DESTINATION_LOCATION.Length < 0 || engine_record.DESTINATION_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field DESTINATION_LOCATION expected to be length between or equal to 0 and 6, has length of {" + engine_record.DESTINATION_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].COMPENSATED_HP != null) {
							engine_record.COMPENSATED_HP = content.ENGINE_RECORD[i].COMPENSATED_HP[0].Value;
							if (engine_record.COMPENSATED_HP != null) {
								if (engine_record.COMPENSATED_HP.Length < 1 || engine_record.COMPENSATED_HP.Length > 5) {
									Ranorex.Report.Failure("Field COMPENSATED_HP expected to be length between or equal to 1 and 5, has length of {" + engine_record.COMPENSATED_HP.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.COMPENSATED_HP)) {
									Ranorex.Report.Failure("Field COMPENSATED_HP expected to be Numeric, has value of {" + engine_record.COMPENSATED_HP + "}.");
								} else {
									int intConvertedValue = Convert.ToInt32(engine_record.COMPENSATED_HP);
									if (intConvertedValue < 0 || intConvertedValue > 99999) {
										Ranorex.Report.Failure("Field COMPENSATED_HP expected to have value between 0 and 99999, but was found to have a value of " + engine_record.COMPENSATED_HP + ".");
									}
								}
							}
						} else {
							Ranorex.Report.Failure("Field COMPENSATED_HP is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].GROUP_NUMBER != null) {
							engine_record.GROUP_NUMBER = content.ENGINE_RECORD[i].GROUP_NUMBER[0].Value;
							if (engine_record.GROUP_NUMBER != null) {
								if (engine_record.GROUP_NUMBER.Length != 1) {
									Ranorex.Report.Failure("Field GROUP_NUMBER expected to be length of 1, has length of {" + engine_record.GROUP_NUMBER.Length.ToString() + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field GROUP_NUMBER is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].MODEL != null) {
							engine_record.MODEL = content.ENGINE_RECORD[i].MODEL[0].Value;
							if (engine_record.MODEL != null) {
								if (engine_record.MODEL.Length < 0 || engine_record.MODEL.Length > 12) {
									Ranorex.Report.Failure("Field MODEL expected to be length between or equal to 0 and 12, has length of {" + engine_record.MODEL.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].ENGINE_STATUS != null) {
							engine_record.ENGINE_STATUS = content.ENGINE_RECORD[i].ENGINE_STATUS[0].Value;
							if (engine_record.ENGINE_STATUS != null) {
								if (engine_record.ENGINE_STATUS.Length < 0 || engine_record.ENGINE_STATUS.Length > 1) {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be length between or equal to 0 and 1, has length of {" + engine_record.ENGINE_STATUS.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.ENGINE_STATUS)) {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be Alphabetic, has value of {" + engine_record.ENGINE_STATUS + "}.");
								}
								if (engine_record.ENGINE_STATUS != "W" && engine_record.ENGINE_STATUS != "T" && engine_record.ENGINE_STATUS != "D" && engine_record.ENGINE_STATUS != "R" && engine_record.ENGINE_STATUS != "") {
									Ranorex.Report.Failure("Field ENGINE_STATUS expected to be one of the following values {W, T, D, R, }, but was found to be {" + engine_record.ENGINE_STATUS + "}.");
								}
							}
						} else {
							Ranorex.Report.Failure("Field ENGINE_STATUS is a Mandatory field but was found to be missing from the message");
						}

						if (content.ENGINE_RECORD[i].DPU_STATUS != null) {
							engine_record.DPU_STATUS = content.ENGINE_RECORD[i].DPU_STATUS[0].Value;
							if (engine_record.DPU_STATUS != null) {
								if (engine_record.DPU_STATUS.Length != 1) {
									Ranorex.Report.Failure("Field DPU_STATUS expected to be length of 1, has length of {" + engine_record.DPU_STATUS.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.DPU_STATUS)) {
									Ranorex.Report.Failure("Field DPU_STATUS expected to be Alphabetic, has value of {" + engine_record.DPU_STATUS + "}.");
								}
								if (engine_record.DPU_STATUS != "Y" && engine_record.DPU_STATUS != "N") {
									Ranorex.Report.Failure("Field DPU_STATUS expected to be one of the following values {Y, N}, but was found to be {" + engine_record.DPU_STATUS + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].PTS_EQUIPPED != null) {
							engine_record.PTS_EQUIPPED = content.ENGINE_RECORD[i].PTS_EQUIPPED[0].Value;
							if (engine_record.PTS_EQUIPPED != null) {
								if (engine_record.PTS_EQUIPPED.Length != 1) {
									Ranorex.Report.Failure("Field PTS_EQUIPPED expected to be length of 1, has length of {" + engine_record.PTS_EQUIPPED.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.PTS_EQUIPPED)) {
									Ranorex.Report.Failure("Field PTS_EQUIPPED expected to be Alphabetic, has value of {" + engine_record.PTS_EQUIPPED + "}.");
								}
								if (engine_record.PTS_EQUIPPED != "Y" && engine_record.PTS_EQUIPPED != "N") {
									Ranorex.Report.Failure("Field PTS_EQUIPPED expected to be one of the following values {Y, N}, but was found to be {" + engine_record.PTS_EQUIPPED + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].PTC_EQUIPPED != null) {
							engine_record.PTC_EQUIPPED = content.ENGINE_RECORD[i].PTC_EQUIPPED[0].Value;
							if (engine_record.PTC_EQUIPPED != null) {
								if (engine_record.PTC_EQUIPPED.Length != 1) {
									Ranorex.Report.Failure("Field PTC_EQUIPPED expected to be length of 1, has length of {" + engine_record.PTC_EQUIPPED.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.PTC_EQUIPPED)) {
									Ranorex.Report.Failure("Field PTC_EQUIPPED expected to be Alphabetic, has value of {" + engine_record.PTC_EQUIPPED + "}.");
								}
								if (engine_record.PTC_EQUIPPED != "Y" && engine_record.PTC_EQUIPPED != "N") {
									Ranorex.Report.Failure("Field PTC_EQUIPPED expected to be one of the following values {Y, N}, but was found to be {" + engine_record.PTC_EQUIPPED + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].LSL_EQUIPPED != null) {
							engine_record.LSL_EQUIPPED = content.ENGINE_RECORD[i].LSL_EQUIPPED[0].Value;
							if (engine_record.LSL_EQUIPPED != null) {
								if (engine_record.LSL_EQUIPPED.Length != 1) {
									Ranorex.Report.Failure("Field LSL_EQUIPPED expected to be length of 1, has length of {" + engine_record.LSL_EQUIPPED.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.LSL_EQUIPPED)) {
									Ranorex.Report.Failure("Field LSL_EQUIPPED expected to be Alphabetic, has value of {" + engine_record.LSL_EQUIPPED + "}.");
								}
								if (engine_record.LSL_EQUIPPED != "Y" && engine_record.LSL_EQUIPPED != "N") {
									Ranorex.Report.Failure("Field LSL_EQUIPPED expected to be one of the following values {Y, N}, but was found to be {" + engine_record.LSL_EQUIPPED + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].CS_EQUIPPED != null) {
							engine_record.CS_EQUIPPED = content.ENGINE_RECORD[i].CS_EQUIPPED[0].Value;
							if (engine_record.CS_EQUIPPED != null) {
								if (engine_record.CS_EQUIPPED.Length != 1) {
									Ranorex.Report.Failure("Field CS_EQUIPPED expected to be length of 1, has length of {" + engine_record.CS_EQUIPPED.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.CS_EQUIPPED)) {
									Ranorex.Report.Failure("Field CS_EQUIPPED expected to be Alphabetic, has value of {" + engine_record.CS_EQUIPPED + "}.");
								}
								if (engine_record.CS_EQUIPPED != "Y" && engine_record.CS_EQUIPPED != "N") {
									Ranorex.Report.Failure("Field CS_EQUIPPED expected to be one of the following values {Y, N}, but was found to be {" + engine_record.CS_EQUIPPED + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].NOTES != null) {
							engine_record.NOTES = content.ENGINE_RECORD[i].NOTES[0].Value;
							if (engine_record.NOTES != null) {
								if (engine_record.NOTES.Length < 0 || engine_record.NOTES.Length > 240) {
									Ranorex.Report.Failure("Field NOTES expected to be length between or equal to 0 and 240, has length of {" + engine_record.NOTES.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].NEXT_SERVICE_DATE != null) {
							engine_record.NEXT_SERVICE_DATE = content.ENGINE_RECORD[i].NEXT_SERVICE_DATE[0].Value;
							if (engine_record.NEXT_SERVICE_DATE != null) {
								if (engine_record.NEXT_SERVICE_DATE.Length < 0 || engine_record.NEXT_SERVICE_DATE.Length > 8) {
									Ranorex.Report.Failure("Field NEXT_SERVICE_DATE expected to be length between or equal to 0 and 8, has length of {" + engine_record.NEXT_SERVICE_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.NEXT_SERVICE_DATE)) {
									Ranorex.Report.Failure("Field NEXT_SERVICE_DATE expected to be Numeric, has value of {" + engine_record.NEXT_SERVICE_DATE + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].NEXT_SERVICE_LOCATION != null) {
							engine_record.NEXT_SERVICE_LOCATION = content.ENGINE_RECORD[i].NEXT_SERVICE_LOCATION[0].Value;
							if (engine_record.NEXT_SERVICE_LOCATION != null) {
								if (engine_record.NEXT_SERVICE_LOCATION.Length < 0 || engine_record.NEXT_SERVICE_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field NEXT_SERVICE_LOCATION expected to be length between or equal to 0 and 6, has length of {" + engine_record.NEXT_SERVICE_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].SHUCKER_DEVICE != null) {
							engine_record.SHUCKER_DEVICE = content.ENGINE_RECORD[i].SHUCKER_DEVICE[0].Value;
							if (engine_record.SHUCKER_DEVICE != null) {
								if (engine_record.SHUCKER_DEVICE.Length < 0 || engine_record.SHUCKER_DEVICE.Length > 1) {
									Ranorex.Report.Failure("Field SHUCKER_DEVICE expected to be length between or equal to 0 and 1, has length of {" + engine_record.SHUCKER_DEVICE.Length.ToString() + "}.");
								}
								if (ContainsDigits(engine_record.SHUCKER_DEVICE)) {
									Ranorex.Report.Failure("Field SHUCKER_DEVICE expected to be Alphabetic, has value of {" + engine_record.SHUCKER_DEVICE + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].FRA_TEST_DUE_DATE != null) {
							engine_record.FRA_TEST_DUE_DATE = content.ENGINE_RECORD[i].FRA_TEST_DUE_DATE[0].Value;
							if (engine_record.FRA_TEST_DUE_DATE != null) {
								if (engine_record.FRA_TEST_DUE_DATE.Length < 0 || engine_record.FRA_TEST_DUE_DATE.Length > 8) {
									Ranorex.Report.Failure("Field FRA_TEST_DUE_DATE expected to be length between or equal to 0 and 8, has length of {" + engine_record.FRA_TEST_DUE_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.FRA_TEST_DUE_DATE)) {
									Ranorex.Report.Failure("Field FRA_TEST_DUE_DATE expected to be Numeric, has value of {" + engine_record.FRA_TEST_DUE_DATE + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].FRA_TEST_DUE_LOCATION != null) {
							engine_record.FRA_TEST_DUE_LOCATION = content.ENGINE_RECORD[i].FRA_TEST_DUE_LOCATION[0].Value;
							if (engine_record.FRA_TEST_DUE_LOCATION != null) {
								if (engine_record.FRA_TEST_DUE_LOCATION.Length < 0 || engine_record.FRA_TEST_DUE_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field FRA_TEST_DUE_LOCATION expected to be length between or equal to 0 and 6, has length of {" + engine_record.FRA_TEST_DUE_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].LAST_FUEL_DATE != null) {
							engine_record.LAST_FUEL_DATE = content.ENGINE_RECORD[i].LAST_FUEL_DATE[0].Value;
							if (engine_record.LAST_FUEL_DATE != null) {
								if (engine_record.LAST_FUEL_DATE.Length < 0 || engine_record.LAST_FUEL_DATE.Length > 8) {
									Ranorex.Report.Failure("Field LAST_FUEL_DATE expected to be length between or equal to 0 and 8, has length of {" + engine_record.LAST_FUEL_DATE.Length.ToString() + "}.");
								}
								if (!IsDigitsOnly(engine_record.LAST_FUEL_DATE)) {
									Ranorex.Report.Failure("Field LAST_FUEL_DATE expected to be Numeric, has value of {" + engine_record.LAST_FUEL_DATE + "}.");
								}
							}
						}

						if (content.ENGINE_RECORD[i].LAST_FUEL_LOCATION != null) {
							engine_record.LAST_FUEL_LOCATION = content.ENGINE_RECORD[i].LAST_FUEL_LOCATION[0].Value;
							if (engine_record.LAST_FUEL_LOCATION != null) {
								if (engine_record.LAST_FUEL_LOCATION.Length < 0 || engine_record.LAST_FUEL_LOCATION.Length > 6) {
									Ranorex.Report.Failure("Field LAST_FUEL_LOCATION expected to be length between or equal to 0 and 6, has length of {" + engine_record.LAST_FUEL_LOCATION.Length.ToString() + "}.");
								}
							}
						}

						messagecontent.addENGINE_RECORD(engine_record);
					}
				} else {
					Ranorex.Report.Failure("Field ENGINE_RECORD is a Mandatory field but was found to be missing from the message");
				}

				ns_engineconsist_48.CONTENT = messagecontent;

			} else {
				Ranorex.Report.Failure("Field CONTENT is a Mandatory field but was found to be missing from the message");
			}
			return ns_engineconsist_48;
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

		public static void createNS_EngineConsist_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_assigned_division,
			string content_helper_crew_pool_id,
			string content_reporting_source,
			string content_reporting_location,
			string content_reporting_pass_count,
			string content_default_data_applied,
			string content_purpose,
			string content_number_of_engines,
			string content_engine_record,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_EngineConsist_48 mis_ns_engineconsist = buildMIS_NS_EngineConsist_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_assigned_division, content_helper_crew_pool_id, content_reporting_source, content_reporting_location, content_reporting_pass_count, content_default_data_applied, content_purpose, content_number_of_engines, content_engine_record);

			NS_EngineConsist_48 ns_engineconsist = mis_ns_engineconsist.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_EngineConsist_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_engineconsist);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_engineconsist.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_engineconsist.toSteMessageHeader(request, true);
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

		public static MIS_NS_EngineConsist_48 buildMIS_NS_EngineConsist_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_assigned_division,
			string content_helper_crew_pool_id,
			string content_reporting_source,
			string content_reporting_location,
			string content_reporting_pass_count,
			string content_default_data_applied,
			string content_purpose,
			string content_number_of_engines,
			string content_engine_record
		) {

			MIS_NS_EngineConsist_48 mis_ns_engineconsist = new MIS_NS_EngineConsist_48();

			MIS_NS_EngineConsistHEADER_48 header = new MIS_NS_EngineConsistHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_EngineConsistCONTENT_48 content = new MIS_NS_EngineConsistCONTENT_48();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.ASSIGNED_DIVISION = content_assigned_division;
			content.HELPER_CREW_POOL_ID = content_helper_crew_pool_id;
			content.REPORTING_SOURCE = content_reporting_source;
			content.REPORTING_LOCATION = content_reporting_location;
			content.REPORTING_PASS_COUNT = content_reporting_pass_count;
			content.DEFAULT_DATA_APPLIED = content_default_data_applied;
			content.PURPOSE = content_purpose;
			content.NUMBER_OF_ENGINES = content_number_of_engines;
			if (content_engine_record != "") {
				string[] engine_recordList = content_engine_record.Split('|');
				for (int i = 0; i < engine_recordList.Length;) {
					MIS_NS_EngineConsistENGINE_RECORD_48 engine_records = new MIS_NS_EngineConsistENGINE_RECORD_48();
					engine_records.ENGINE_INITIAL = engine_recordList[i];i++;
					engine_records.ENGINE_NUMBER = engine_recordList[i];i++;
					engine_records.ENGINE_POSITION = engine_recordList[i];i++;
					engine_records.ENGINE_ORIENTATION = engine_recordList[i];i++;
					engine_records.ENGINE_LOCK = engine_recordList[i];i++;
					engine_records.ORIGIN_PASS_COUNT = engine_recordList[i];i++;
					engine_records.ORIGIN_LOCATION = engine_recordList[i];i++;
					engine_records.DESTINATION_PASS_COUNT = engine_recordList[i];i++;
					engine_records.DESTINATION_LOCATION = engine_recordList[i];i++;
					engine_records.COMPENSATED_HP = engine_recordList[i];i++;
					engine_records.GROUP_NUMBER = engine_recordList[i];i++;
					engine_records.MODEL = engine_recordList[i];i++;
					engine_records.ENGINE_STATUS = engine_recordList[i];i++;
					engine_records.DPU_STATUS = engine_recordList[i];i++;
					engine_records.PTS_EQUIPPED = engine_recordList[i];i++;
					engine_records.PTC_EQUIPPED = engine_recordList[i];i++;
					engine_records.LSL_EQUIPPED = engine_recordList[i];i++;
					engine_records.CS_EQUIPPED = engine_recordList[i];i++;
					engine_records.NOTES = engine_recordList[i];i++;
					engine_records.NEXT_SERVICE_DATE = engine_recordList[i];i++;
					engine_records.NEXT_SERVICE_LOCATION = engine_recordList[i];i++;
					engine_records.SHUCKER_DEVICE = engine_recordList[i];i++;
					engine_records.FRA_TEST_DUE_DATE = engine_recordList[i];i++;
					engine_records.FRA_TEST_DUE_LOCATION = engine_recordList[i];i++;
					engine_records.LAST_FUEL_DATE = engine_recordList[i];i++;
					engine_records.LAST_FUEL_LOCATION = engine_recordList[i];i++;
					content.addENGINE_RECORD(engine_records);
				}
			}

			mis_ns_engineconsist.HEADER = header;
			mis_ns_engineconsist.CONTENT = content;
			return mis_ns_engineconsist;
		}

		public NS_EngineConsist_48 toSerializableObject() {
			NS_EngineConsist_48 ns_engineconsist_48 = new NS_EngineConsist_48();
			ns_engineconsist_48.Items = new object[2];

			NS_EngineConsistHEADER_48 header = new NS_EngineConsistHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_EngineConsistHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_EngineConsistHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_EngineConsistHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_EngineConsistHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != null && HEADER.TRACE_ID != "") {
					header.TRACE_ID = new NS_EngineConsistHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_EngineConsistHEADER_TRACE_ID_48();
					if (HEADER.TRACE_ID == "Empty") {
						header.TRACE_ID[0].Value = "";
					} else {
						header.TRACE_ID[0].Value = HEADER.TRACE_ID;
					}
				}

				if (HEADER.MESSAGE_VERSION != null && HEADER.MESSAGE_VERSION != "") {
					header.MESSAGE_VERSION = new NS_EngineConsistHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_EngineConsistHEADER_MESSAGE_VERSION_48();
					if (HEADER.MESSAGE_VERSION == "Empty") {
						header.MESSAGE_VERSION[0].Value = "";
					} else {
						header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
					}
				}

			}

			NS_EngineConsistCONTENT_48 content = new NS_EngineConsistCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_EngineConsistCONTENT_SCAC_48[1];
					content.SCAC[0] = new NS_EngineConsistCONTENT_SCAC_48();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_EngineConsistCONTENT_SECTION_48[1];
					content.SECTION[0] = new NS_EngineConsistCONTENT_SECTION_48();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_EngineConsistCONTENT_TRAIN_SYMBOL_48[1];
					content.TRAIN_SYMBOL[0] = new NS_EngineConsistCONTENT_TRAIN_SYMBOL_48();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_EngineConsistCONTENT_ORIGIN_DATE_48[1];
					content.ORIGIN_DATE[0] = new NS_EngineConsistCONTENT_ORIGIN_DATE_48();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.ASSIGNED_DIVISION != null && CONTENT.ASSIGNED_DIVISION != "") {
					content.ASSIGNED_DIVISION = new NS_EngineConsistCONTENT_ASSIGNED_DIVISION_48[1];
					content.ASSIGNED_DIVISION[0] = new NS_EngineConsistCONTENT_ASSIGNED_DIVISION_48();
					if (CONTENT.ASSIGNED_DIVISION == "Empty") {
						content.ASSIGNED_DIVISION[0].Value = "";
					} else {
						content.ASSIGNED_DIVISION[0].Value = CONTENT.ASSIGNED_DIVISION;
					}
				}

				if (CONTENT.HELPER_CREW_POOL_ID != null && CONTENT.HELPER_CREW_POOL_ID != "") {
					content.HELPER_CREW_POOL_ID = new NS_EngineConsistCONTENT_HELPER_CREW_POOL_ID_48[1];
					content.HELPER_CREW_POOL_ID[0] = new NS_EngineConsistCONTENT_HELPER_CREW_POOL_ID_48();
					if (CONTENT.HELPER_CREW_POOL_ID == "Empty") {
						content.HELPER_CREW_POOL_ID[0].Value = "";
					} else {
						content.HELPER_CREW_POOL_ID[0].Value = CONTENT.HELPER_CREW_POOL_ID;
					}
				}

				if (CONTENT.REPORTING_SOURCE != "Null") {
					content.REPORTING_SOURCE = new NS_EngineConsistCONTENT_REPORTING_SOURCE_48[1];
					content.REPORTING_SOURCE[0] = new NS_EngineConsistCONTENT_REPORTING_SOURCE_48();
					content.REPORTING_SOURCE[0].Value = CONTENT.REPORTING_SOURCE;
				}

				if (CONTENT.REPORTING_LOCATION != "Null") {
					content.REPORTING_LOCATION = new NS_EngineConsistCONTENT_REPORTING_LOCATION_48[1];
					content.REPORTING_LOCATION[0] = new NS_EngineConsistCONTENT_REPORTING_LOCATION_48();
					content.REPORTING_LOCATION[0].Value = CONTENT.REPORTING_LOCATION;
				}

				if (CONTENT.REPORTING_PASS_COUNT != "Null") {
					content.REPORTING_PASS_COUNT = new NS_EngineConsistCONTENT_REPORTING_PASS_COUNT_48[1];
					content.REPORTING_PASS_COUNT[0] = new NS_EngineConsistCONTENT_REPORTING_PASS_COUNT_48();
					content.REPORTING_PASS_COUNT[0].Value = CONTENT.REPORTING_PASS_COUNT;
				}

				if (CONTENT.DEFAULT_DATA_APPLIED != "Null") {
					content.DEFAULT_DATA_APPLIED = new NS_EngineConsistCONTENT_DEFAULT_DATA_APPLIED_48[1];
					content.DEFAULT_DATA_APPLIED[0] = new NS_EngineConsistCONTENT_DEFAULT_DATA_APPLIED_48();
					content.DEFAULT_DATA_APPLIED[0].Value = CONTENT.DEFAULT_DATA_APPLIED;
				}

				if (CONTENT.PURPOSE != "Null") {
					content.PURPOSE = new NS_EngineConsistCONTENT_PURPOSE_48[1];
					content.PURPOSE[0] = new NS_EngineConsistCONTENT_PURPOSE_48();
					content.PURPOSE[0].Value = CONTENT.PURPOSE;
				}

				if (CONTENT.NUMBER_OF_ENGINES != "Null") {
					content.NUMBER_OF_ENGINES = new NS_EngineConsistCONTENT_NUMBER_OF_ENGINES_48[1];
					content.NUMBER_OF_ENGINES[0] = new NS_EngineConsistCONTENT_NUMBER_OF_ENGINES_48();
					content.NUMBER_OF_ENGINES[0].Value = CONTENT.NUMBER_OF_ENGINES;
				}

				if (CONTENT.ENGINE_RECORD.Count != 0) {
					int engine_recordIndex = 0;
					content.ENGINE_RECORD = new NS_EngineConsistCONTENT_ENGINE_RECORD_48[CONTENT.ENGINE_RECORD.Count];
					foreach (MIS_NS_EngineConsistENGINE_RECORD_48 ENGINE_RECORD in CONTENT.ENGINE_RECORD) {
						NS_EngineConsistCONTENT_ENGINE_RECORD_48 engine_record = new NS_EngineConsistCONTENT_ENGINE_RECORD_48();
						if (ENGINE_RECORD.ENGINE_INITIAL != "Null") {
							engine_record.ENGINE_INITIAL = new NS_EngineConsistENGINE_RECORD_ENGINE_INITIAL_48[1];
							engine_record.ENGINE_INITIAL[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_INITIAL_48();
							engine_record.ENGINE_INITIAL[0].Value = ENGINE_RECORD.ENGINE_INITIAL;
						}

						if (ENGINE_RECORD.ENGINE_NUMBER != "Null") {
							engine_record.ENGINE_NUMBER = new NS_EngineConsistENGINE_RECORD_ENGINE_NUMBER_48[1];
							engine_record.ENGINE_NUMBER[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_NUMBER_48();
							engine_record.ENGINE_NUMBER[0].Value = ENGINE_RECORD.ENGINE_NUMBER;
						}

						if (ENGINE_RECORD.ENGINE_POSITION != "Null") {
							engine_record.ENGINE_POSITION = new NS_EngineConsistENGINE_RECORD_ENGINE_POSITION_48[1];
							engine_record.ENGINE_POSITION[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_POSITION_48();
							engine_record.ENGINE_POSITION[0].Value = ENGINE_RECORD.ENGINE_POSITION;
						}

						if (ENGINE_RECORD.ENGINE_ORIENTATION != null && ENGINE_RECORD.ENGINE_ORIENTATION != "") {
							engine_record.ENGINE_ORIENTATION = new NS_EngineConsistENGINE_RECORD_ENGINE_ORIENTATION_48[1];
							engine_record.ENGINE_ORIENTATION[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_ORIENTATION_48();
							if (ENGINE_RECORD.ENGINE_ORIENTATION == "Empty") {
								engine_record.ENGINE_ORIENTATION[0].Value = "";
							} else {
								engine_record.ENGINE_ORIENTATION[0].Value = ENGINE_RECORD.ENGINE_ORIENTATION;
							}
						}

						if (ENGINE_RECORD.ENGINE_LOCK != "Null") {
							engine_record.ENGINE_LOCK = new NS_EngineConsistENGINE_RECORD_ENGINE_LOCK_48[1];
							engine_record.ENGINE_LOCK[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_LOCK_48();
							engine_record.ENGINE_LOCK[0].Value = ENGINE_RECORD.ENGINE_LOCK;
						}

						if (ENGINE_RECORD.ORIGIN_PASS_COUNT != null && ENGINE_RECORD.ORIGIN_PASS_COUNT != "") {
							engine_record.ORIGIN_PASS_COUNT = new NS_EngineConsistENGINE_RECORD_ORIGIN_PASS_COUNT_48[1];
							engine_record.ORIGIN_PASS_COUNT[0] = new NS_EngineConsistENGINE_RECORD_ORIGIN_PASS_COUNT_48();
							if (ENGINE_RECORD.ORIGIN_PASS_COUNT == "Empty") {
								engine_record.ORIGIN_PASS_COUNT[0].Value = "";
							} else {
								engine_record.ORIGIN_PASS_COUNT[0].Value = ENGINE_RECORD.ORIGIN_PASS_COUNT;
							}
						}

						if (ENGINE_RECORD.ORIGIN_LOCATION != null && ENGINE_RECORD.ORIGIN_LOCATION != "") {
							engine_record.ORIGIN_LOCATION = new NS_EngineConsistENGINE_RECORD_ORIGIN_LOCATION_48[1];
							engine_record.ORIGIN_LOCATION[0] = new NS_EngineConsistENGINE_RECORD_ORIGIN_LOCATION_48();
							if (ENGINE_RECORD.ORIGIN_LOCATION == "Empty") {
								engine_record.ORIGIN_LOCATION[0].Value = "";
							} else {
								engine_record.ORIGIN_LOCATION[0].Value = ENGINE_RECORD.ORIGIN_LOCATION;
							}
						}

						if (ENGINE_RECORD.DESTINATION_PASS_COUNT != null && ENGINE_RECORD.DESTINATION_PASS_COUNT != "") {
							engine_record.DESTINATION_PASS_COUNT = new NS_EngineConsistENGINE_RECORD_DESTINATION_PASS_COUNT_48[1];
							engine_record.DESTINATION_PASS_COUNT[0] = new NS_EngineConsistENGINE_RECORD_DESTINATION_PASS_COUNT_48();
							if (ENGINE_RECORD.DESTINATION_PASS_COUNT == "Empty") {
								engine_record.DESTINATION_PASS_COUNT[0].Value = "";
							} else {
								engine_record.DESTINATION_PASS_COUNT[0].Value = ENGINE_RECORD.DESTINATION_PASS_COUNT;
							}
						}

						if (ENGINE_RECORD.DESTINATION_LOCATION != null && ENGINE_RECORD.DESTINATION_LOCATION != "") {
							engine_record.DESTINATION_LOCATION = new NS_EngineConsistENGINE_RECORD_DESTINATION_LOCATION_48[1];
							engine_record.DESTINATION_LOCATION[0] = new NS_EngineConsistENGINE_RECORD_DESTINATION_LOCATION_48();
							if (ENGINE_RECORD.DESTINATION_LOCATION == "Empty") {
								engine_record.DESTINATION_LOCATION[0].Value = "";
							} else {
								engine_record.DESTINATION_LOCATION[0].Value = ENGINE_RECORD.DESTINATION_LOCATION;
							}
						}

						if (ENGINE_RECORD.COMPENSATED_HP != "Null") {
							engine_record.COMPENSATED_HP = new NS_EngineConsistENGINE_RECORD_COMPENSATED_HP_48[1];
							engine_record.COMPENSATED_HP[0] = new NS_EngineConsistENGINE_RECORD_COMPENSATED_HP_48();
							engine_record.COMPENSATED_HP[0].Value = ENGINE_RECORD.COMPENSATED_HP;
						}

						if (ENGINE_RECORD.GROUP_NUMBER != "Null") {
							engine_record.GROUP_NUMBER = new NS_EngineConsistENGINE_RECORD_GROUP_NUMBER_48[1];
							engine_record.GROUP_NUMBER[0] = new NS_EngineConsistENGINE_RECORD_GROUP_NUMBER_48();
							engine_record.GROUP_NUMBER[0].Value = ENGINE_RECORD.GROUP_NUMBER;
						}

						if (ENGINE_RECORD.MODEL != null && ENGINE_RECORD.MODEL != "") {
							engine_record.MODEL = new NS_EngineConsistENGINE_RECORD_MODEL_48[1];
							engine_record.MODEL[0] = new NS_EngineConsistENGINE_RECORD_MODEL_48();
							if (ENGINE_RECORD.MODEL == "Empty") {
								engine_record.MODEL[0].Value = "";
							} else {
								engine_record.MODEL[0].Value = ENGINE_RECORD.MODEL;
							}
						}

						if (ENGINE_RECORD.ENGINE_STATUS != "Null") {
							engine_record.ENGINE_STATUS = new NS_EngineConsistENGINE_RECORD_ENGINE_STATUS_48[1];
							engine_record.ENGINE_STATUS[0] = new NS_EngineConsistENGINE_RECORD_ENGINE_STATUS_48();
							engine_record.ENGINE_STATUS[0].Value = ENGINE_RECORD.ENGINE_STATUS;
						}

						if (ENGINE_RECORD.DPU_STATUS != null && ENGINE_RECORD.DPU_STATUS != "") {
							engine_record.DPU_STATUS = new NS_EngineConsistENGINE_RECORD_DPU_STATUS_48[1];
							engine_record.DPU_STATUS[0] = new NS_EngineConsistENGINE_RECORD_DPU_STATUS_48();
							if (ENGINE_RECORD.DPU_STATUS == "Empty") {
								engine_record.DPU_STATUS[0].Value = "";
							} else {
								engine_record.DPU_STATUS[0].Value = ENGINE_RECORD.DPU_STATUS;
							}
						}

						if (ENGINE_RECORD.PTS_EQUIPPED != null && ENGINE_RECORD.PTS_EQUIPPED != "") {
							engine_record.PTS_EQUIPPED = new NS_EngineConsistENGINE_RECORD_PTS_EQUIPPED_48[1];
							engine_record.PTS_EQUIPPED[0] = new NS_EngineConsistENGINE_RECORD_PTS_EQUIPPED_48();
							if (ENGINE_RECORD.PTS_EQUIPPED == "Empty") {
								engine_record.PTS_EQUIPPED[0].Value = "";
							} else {
								engine_record.PTS_EQUIPPED[0].Value = ENGINE_RECORD.PTS_EQUIPPED;
							}
						}

						if (ENGINE_RECORD.PTC_EQUIPPED != null && ENGINE_RECORD.PTC_EQUIPPED != "") {
							engine_record.PTC_EQUIPPED = new NS_EngineConsistENGINE_RECORD_PTC_EQUIPPED_48[1];
							engine_record.PTC_EQUIPPED[0] = new NS_EngineConsistENGINE_RECORD_PTC_EQUIPPED_48();
							if (ENGINE_RECORD.PTC_EQUIPPED == "Empty") {
								engine_record.PTC_EQUIPPED[0].Value = "";
							} else {
								engine_record.PTC_EQUIPPED[0].Value = ENGINE_RECORD.PTC_EQUIPPED;
							}
						}

						if (ENGINE_RECORD.LSL_EQUIPPED != null && ENGINE_RECORD.LSL_EQUIPPED != "") {
							engine_record.LSL_EQUIPPED = new NS_EngineConsistENGINE_RECORD_LSL_EQUIPPED_48[1];
							engine_record.LSL_EQUIPPED[0] = new NS_EngineConsistENGINE_RECORD_LSL_EQUIPPED_48();
							if (ENGINE_RECORD.LSL_EQUIPPED == "Empty") {
								engine_record.LSL_EQUIPPED[0].Value = "";
							} else {
								engine_record.LSL_EQUIPPED[0].Value = ENGINE_RECORD.LSL_EQUIPPED;
							}
						}

						if (ENGINE_RECORD.CS_EQUIPPED != null && ENGINE_RECORD.CS_EQUIPPED != "") {
							engine_record.CS_EQUIPPED = new NS_EngineConsistENGINE_RECORD_CS_EQUIPPED_48[1];
							engine_record.CS_EQUIPPED[0] = new NS_EngineConsistENGINE_RECORD_CS_EQUIPPED_48();
							if (ENGINE_RECORD.CS_EQUIPPED == "Empty") {
								engine_record.CS_EQUIPPED[0].Value = "";
							} else {
								engine_record.CS_EQUIPPED[0].Value = ENGINE_RECORD.CS_EQUIPPED;
							}
						}

						if (ENGINE_RECORD.NOTES != null && ENGINE_RECORD.NOTES != "") {
							engine_record.NOTES = new NS_EngineConsistENGINE_RECORD_NOTES_48[1];
							engine_record.NOTES[0] = new NS_EngineConsistENGINE_RECORD_NOTES_48();
							if (ENGINE_RECORD.NOTES == "Empty") {
								engine_record.NOTES[0].Value = "";
							} else {
								engine_record.NOTES[0].Value = ENGINE_RECORD.NOTES;
							}
						}

						if (ENGINE_RECORD.NEXT_SERVICE_DATE != null && ENGINE_RECORD.NEXT_SERVICE_DATE != "") {
							engine_record.NEXT_SERVICE_DATE = new NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_DATE_48[1];
							engine_record.NEXT_SERVICE_DATE[0] = new NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_DATE_48();
							if (ENGINE_RECORD.NEXT_SERVICE_DATE == "Empty") {
								engine_record.NEXT_SERVICE_DATE[0].Value = "";
							} else {
								engine_record.NEXT_SERVICE_DATE[0].Value = ENGINE_RECORD.NEXT_SERVICE_DATE;
							}
						}

						if (ENGINE_RECORD.NEXT_SERVICE_LOCATION != null && ENGINE_RECORD.NEXT_SERVICE_LOCATION != "") {
							engine_record.NEXT_SERVICE_LOCATION = new NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_LOCATION_48[1];
							engine_record.NEXT_SERVICE_LOCATION[0] = new NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_LOCATION_48();
							if (ENGINE_RECORD.NEXT_SERVICE_LOCATION == "Empty") {
								engine_record.NEXT_SERVICE_LOCATION[0].Value = "";
							} else {
								engine_record.NEXT_SERVICE_LOCATION[0].Value = ENGINE_RECORD.NEXT_SERVICE_LOCATION;
							}
						}

						if (ENGINE_RECORD.SHUCKER_DEVICE != null && ENGINE_RECORD.SHUCKER_DEVICE != "") {
							engine_record.SHUCKER_DEVICE = new NS_EngineConsistENGINE_RECORD_SHUCKER_DEVICE_48[1];
							engine_record.SHUCKER_DEVICE[0] = new NS_EngineConsistENGINE_RECORD_SHUCKER_DEVICE_48();
							if (ENGINE_RECORD.SHUCKER_DEVICE == "Empty") {
								engine_record.SHUCKER_DEVICE[0].Value = "";
							} else {
								engine_record.SHUCKER_DEVICE[0].Value = ENGINE_RECORD.SHUCKER_DEVICE;
							}
						}

						if (ENGINE_RECORD.FRA_TEST_DUE_DATE != null && ENGINE_RECORD.FRA_TEST_DUE_DATE != "") {
							engine_record.FRA_TEST_DUE_DATE = new NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_DATE_48[1];
							engine_record.FRA_TEST_DUE_DATE[0] = new NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_DATE_48();
							if (ENGINE_RECORD.FRA_TEST_DUE_DATE == "Empty") {
								engine_record.FRA_TEST_DUE_DATE[0].Value = "";
							} else {
								engine_record.FRA_TEST_DUE_DATE[0].Value = ENGINE_RECORD.FRA_TEST_DUE_DATE;
							}
						}

						if (ENGINE_RECORD.FRA_TEST_DUE_LOCATION != null && ENGINE_RECORD.FRA_TEST_DUE_LOCATION != "") {
							engine_record.FRA_TEST_DUE_LOCATION = new NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_LOCATION_48[1];
							engine_record.FRA_TEST_DUE_LOCATION[0] = new NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_LOCATION_48();
							if (ENGINE_RECORD.FRA_TEST_DUE_LOCATION == "Empty") {
								engine_record.FRA_TEST_DUE_LOCATION[0].Value = "";
							} else {
								engine_record.FRA_TEST_DUE_LOCATION[0].Value = ENGINE_RECORD.FRA_TEST_DUE_LOCATION;
							}
						}

						if (ENGINE_RECORD.LAST_FUEL_DATE != null && ENGINE_RECORD.LAST_FUEL_DATE != "") {
							engine_record.LAST_FUEL_DATE = new NS_EngineConsistENGINE_RECORD_LAST_FUEL_DATE_48[1];
							engine_record.LAST_FUEL_DATE[0] = new NS_EngineConsistENGINE_RECORD_LAST_FUEL_DATE_48();
							if (ENGINE_RECORD.LAST_FUEL_DATE == "Empty") {
								engine_record.LAST_FUEL_DATE[0].Value = "";
							} else {
								engine_record.LAST_FUEL_DATE[0].Value = ENGINE_RECORD.LAST_FUEL_DATE;
							}
						}

						if (ENGINE_RECORD.LAST_FUEL_LOCATION != null && ENGINE_RECORD.LAST_FUEL_LOCATION != "") {
							engine_record.LAST_FUEL_LOCATION = new NS_EngineConsistENGINE_RECORD_LAST_FUEL_LOCATION_48[1];
							engine_record.LAST_FUEL_LOCATION[0] = new NS_EngineConsistENGINE_RECORD_LAST_FUEL_LOCATION_48();
							if (ENGINE_RECORD.LAST_FUEL_LOCATION == "Empty") {
								engine_record.LAST_FUEL_LOCATION[0].Value = "";
							} else {
								engine_record.LAST_FUEL_LOCATION[0].Value = ENGINE_RECORD.LAST_FUEL_LOCATION;
							}
						}

						content.ENGINE_RECORD[engine_recordIndex] = engine_record;
						engine_recordIndex++;
					}
				}

			}

			ns_engineconsist_48.Items[0] = header;
			ns_engineconsist_48.Items[1] = content;
			return ns_engineconsist_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MTRNLOC,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MTRNLOC,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_EngineConsistHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_EngineConsistCONTENT_48 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string ASSIGNED_DIVISION = "";
		public string HELPER_CREW_POOL_ID = "";
		public string REPORTING_SOURCE = "";
		public string REPORTING_LOCATION = "";
		public string REPORTING_PASS_COUNT = "";
		public string DEFAULT_DATA_APPLIED = "";
		public string PURPOSE = "";
		public string NUMBER_OF_ENGINES = "";
		public ArrayList ENGINE_RECORD = new ArrayList();

		public void addENGINE_RECORD(MIS_NS_EngineConsistENGINE_RECORD_48 engine_record) {
			this.ENGINE_RECORD.Add(engine_record);
		}
	}

	public partial class MIS_NS_EngineConsistENGINE_RECORD_48 {
		public string ENGINE_INITIAL = "";
		public string ENGINE_NUMBER = "";
		public string ENGINE_POSITION = "";
		public string ENGINE_ORIENTATION = "";
		public string ENGINE_LOCK = "";
		public string ORIGIN_PASS_COUNT = "";
		public string ORIGIN_LOCATION = "";
		public string DESTINATION_PASS_COUNT = "";
		public string DESTINATION_LOCATION = "";
		public string COMPENSATED_HP = "";
		public string GROUP_NUMBER = "";
		public string MODEL = "";
		public string ENGINE_STATUS = "";
		public string DPU_STATUS = "";
		public string PTS_EQUIPPED = "";
		public string PTC_EQUIPPED = "";
		public string LSL_EQUIPPED = "";
		public string CS_EQUIPPED = "";
		public string NOTES = "";
		public string NEXT_SERVICE_DATE = "";
		public string NEXT_SERVICE_LOCATION = "";
		public string SHUCKER_DEVICE = "";
		public string FRA_TEST_DUE_DATE = "";
		public string FRA_TEST_DUE_LOCATION = "";
		public string LAST_FUEL_DATE = "";
		public string LAST_FUEL_LOCATION = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "EngineConsist", IsNullable = false)]
	public partial class NS_EngineConsist_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_EngineConsistHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_EngineConsistCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_SCAC_48[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_SECTION_48[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_TRAIN_SYMBOL_48[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_ORIGIN_DATE_48[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("ASSIGNED_DIVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_ASSIGNED_DIVISION_48[] ASSIGNED_DIVISION;

		[System.Xml.Serialization.XmlElementAttribute("HELPER_CREW_POOL_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_HELPER_CREW_POOL_ID_48[] HELPER_CREW_POOL_ID;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_SOURCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_REPORTING_SOURCE_48[] REPORTING_SOURCE;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_REPORTING_LOCATION_48[] REPORTING_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("REPORTING_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_REPORTING_PASS_COUNT_48[] REPORTING_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("DEFAULT_DATA_APPLIED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_DEFAULT_DATA_APPLIED_48[] DEFAULT_DATA_APPLIED;

		[System.Xml.Serialization.XmlElementAttribute("PURPOSE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_PURPOSE_48[] PURPOSE;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_ENGINES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_NUMBER_OF_ENGINES_48[] NUMBER_OF_ENGINES;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistCONTENT_ENGINE_RECORD_48[] ENGINE_RECORD;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_SCAC_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_SECTION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_TRAIN_SYMBOL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_ORIGIN_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_ASSIGNED_DIVISION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_HELPER_CREW_POOL_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_REPORTING_SOURCE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_REPORTING_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_REPORTING_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_DEFAULT_DATA_APPLIED_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_PURPOSE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_NUMBER_OF_ENGINES_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistCONTENT_ENGINE_RECORD_48 {
		[System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_INITIAL_48[] ENGINE_INITIAL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_NUMBER_48[] ENGINE_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_POSITION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_POSITION_48[] ENGINE_POSITION;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_ORIENTATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_ORIENTATION_48[] ENGINE_ORIENTATION;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_LOCK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_LOCK_48[] ENGINE_LOCK;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ORIGIN_PASS_COUNT_48[] ORIGIN_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ORIGIN_LOCATION_48[] ORIGIN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("DESTINATION_PASS_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_DESTINATION_PASS_COUNT_48[] DESTINATION_PASS_COUNT;

		[System.Xml.Serialization.XmlElementAttribute("DESTINATION_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_DESTINATION_LOCATION_48[] DESTINATION_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("COMPENSATED_HP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_COMPENSATED_HP_48[] COMPENSATED_HP;

		[System.Xml.Serialization.XmlElementAttribute("GROUP_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_GROUP_NUMBER_48[] GROUP_NUMBER;

		[System.Xml.Serialization.XmlElementAttribute("MODEL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_MODEL_48[] MODEL;

		[System.Xml.Serialization.XmlElementAttribute("ENGINE_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_ENGINE_STATUS_48[] ENGINE_STATUS;

		[System.Xml.Serialization.XmlElementAttribute("DPU_STATUS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_DPU_STATUS_48[] DPU_STATUS;

		[System.Xml.Serialization.XmlElementAttribute("PTS_EQUIPPED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_PTS_EQUIPPED_48[] PTS_EQUIPPED;

		[System.Xml.Serialization.XmlElementAttribute("PTC_EQUIPPED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_PTC_EQUIPPED_48[] PTC_EQUIPPED;

		[System.Xml.Serialization.XmlElementAttribute("LSL_EQUIPPED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_LSL_EQUIPPED_48[] LSL_EQUIPPED;

		[System.Xml.Serialization.XmlElementAttribute("CS_EQUIPPED", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_CS_EQUIPPED_48[] CS_EQUIPPED;

		[System.Xml.Serialization.XmlElementAttribute("NOTES", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_NOTES_48[] NOTES;

		[System.Xml.Serialization.XmlElementAttribute("NEXT_SERVICE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_DATE_48[] NEXT_SERVICE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("NEXT_SERVICE_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_LOCATION_48[] NEXT_SERVICE_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("SHUCKER_DEVICE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_SHUCKER_DEVICE_48[] SHUCKER_DEVICE;

		[System.Xml.Serialization.XmlElementAttribute("FRA_TEST_DUE_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_DATE_48[] FRA_TEST_DUE_DATE;

		[System.Xml.Serialization.XmlElementAttribute("FRA_TEST_DUE_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_LOCATION_48[] FRA_TEST_DUE_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("LAST_FUEL_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_LAST_FUEL_DATE_48[] LAST_FUEL_DATE;

		[System.Xml.Serialization.XmlElementAttribute("LAST_FUEL_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_EngineConsistENGINE_RECORD_LAST_FUEL_LOCATION_48[] LAST_FUEL_LOCATION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_INITIAL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_POSITION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_ORIENTATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_LOCK_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ORIGIN_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ORIGIN_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_DESTINATION_PASS_COUNT_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_DESTINATION_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_COMPENSATED_HP_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_GROUP_NUMBER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_MODEL_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_ENGINE_STATUS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_DPU_STATUS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_PTS_EQUIPPED_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_PTC_EQUIPPED_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_LSL_EQUIPPED_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_CS_EQUIPPED_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_NOTES_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_NEXT_SERVICE_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_SHUCKER_DEVICE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_FRA_TEST_DUE_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_LAST_FUEL_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_EngineConsistENGINE_RECORD_LAST_FUEL_LOCATION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}