using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.MessageQueues;

namespace STE.Code_Utils.messages.MIS.NS
{
	public partial class MIS_NS_TrainSchedule_43 {
		public MIS_NS_TrainScheduleHEADER_43 HEADER;
		public MIS_NS_TrainScheduleCONTENT_43 CONTENT;

		public static void createNS_TrainSchedule_43(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_report_type,
			string content_train_category,
			string content_train_group,
			string content_origin_location,
			string content_termination_location,
			string content_number_of_stations,
			string content_station,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_TrainSchedule_43 mis_ns_trainschedule = buildMIS_NS_TrainSchedule_43(header_protocolid, header_msgid, header_trace_id, header_message_version, content_scac, content_section, content_train_symbol, content_origin_date, content_report_type, content_train_category, content_train_group, content_origin_location, content_termination_location, content_number_of_stations, content_station);

			NS_TrainSchedule_43 ns_trainschedule = mis_ns_trainschedule.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_TrainSchedule_43));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_trainschedule);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainschedule.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_trainschedule.toSteMessageHeader(request, true);
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

		public static MIS_NS_TrainSchedule_43 buildMIS_NS_TrainSchedule_43(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_scac,
			string content_section,
			string content_train_symbol,
			string content_origin_date,
			string content_report_type,
			string content_train_category,
			string content_train_group,
			string content_origin_location,
			string content_termination_location,
			string content_number_of_stations,
			string content_station
		) {

			MIS_NS_TrainSchedule_43 mis_ns_trainschedule = new MIS_NS_TrainSchedule_43();

			MIS_NS_TrainScheduleHEADER_43 header = new MIS_NS_TrainScheduleHEADER_43();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_TrainScheduleCONTENT_43 content = new MIS_NS_TrainScheduleCONTENT_43();
			content.SCAC = content_scac;
			content.SECTION = content_section;
			content.TRAIN_SYMBOL = content_train_symbol;
			content.ORIGIN_DATE = content_origin_date;
			content.REPORT_TYPE = content_report_type;
			content.TRAIN_CATEGORY = content_train_category;
			content.TRAIN_GROUP = content_train_group;
			content.ORIGIN_LOCATION = content_origin_location;
			content.TERMINATION_LOCATION = content_termination_location;
			content.NUMBER_OF_STATIONS = content_number_of_stations;
			if (content_station != "") {
				string[] stationList = content_station.Split('|');
				for (int i = 0; i < stationList.Length;) {
					MIS_NS_TrainScheduleSTATION_43 stations = new MIS_NS_TrainScheduleSTATION_43();
					stations.STATION_SEQ_NUM = stationList[i];i++;
					stations.STATION_LOCATION = stationList[i];i++;
					stations.DAY_OF_STA = stationList[i];i++;
					stations.STA = stationList[i];i++;
					stations.STA_ZONE = stationList[i];i++;
					stations.DAY_OF_STD = stationList[i];i++;
					stations.STD = stationList[i];i++;
					stations.STD_ZONE = stationList[i];i++;
					stations.CREW_CHANGE = stationList[i];i++;
					stations.CREW_LINE_SEGMENT = stationList[i];i++;
					stations.SETOUT = stationList[i];i++;
					stations.PICKUP = stationList[i];i++;
					stations.FUEL = stationList[i];i++;
					stations.INSPECTION = stationList[i];i++;
					stations.PASSENGER_STOP = stationList[i];i++;
					stations.EXIT_TO_FOREIGN_RAILROAD = stationList[i];i++;
					stations.TURN_POINT = stationList[i];i++;
					stations.PTC_TRAIN_ARRIVAL = stationList[i];i++;
					stations.PTC_TRAIN_DEPARTURE = stationList[i];i++;
					content.addSTATION(stations);
				}
			}

			mis_ns_trainschedule.HEADER = header;
			mis_ns_trainschedule.CONTENT = content;
			return mis_ns_trainschedule;
		}

		public NS_TrainSchedule_43 toSerializableObject() {
			NS_TrainSchedule_43 ns_trainschedule_43 = new NS_TrainSchedule_43();
			ns_trainschedule_43.Items = new object[2];

			NS_TrainScheduleHEADER_43 header = new NS_TrainScheduleHEADER_43();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_TrainScheduleHEADER_PROTOCOLID_43[1];
					header.PROTOCOLID[0] = new NS_TrainScheduleHEADER_PROTOCOLID_43();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_TrainScheduleHEADER_MSGID_43[1];
					header.MSGID[0] = new NS_TrainScheduleHEADER_MSGID_43();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != "Null") {
					header.TRACE_ID = new NS_TrainScheduleHEADER_TRACE_ID_43[1];
					header.TRACE_ID[0] = new NS_TrainScheduleHEADER_TRACE_ID_43();
					header.TRACE_ID[0].Value = HEADER.TRACE_ID;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new NS_TrainScheduleHEADER_MESSAGE_VERSION_43[1];
					header.MESSAGE_VERSION[0] = new NS_TrainScheduleHEADER_MESSAGE_VERSION_43();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

			}

			NS_TrainScheduleCONTENT_43 content = new NS_TrainScheduleCONTENT_43();
			if (this.CONTENT != null) {
				if (CONTENT.SCAC != "Null") {
					content.SCAC = new NS_TrainScheduleCONTENT_SCAC_43[1];
					content.SCAC[0] = new NS_TrainScheduleCONTENT_SCAC_43();
					content.SCAC[0].Value = CONTENT.SCAC;
				}

				if (CONTENT.SECTION != "Null") {
					content.SECTION = new NS_TrainScheduleCONTENT_SECTION_43[1];
					content.SECTION[0] = new NS_TrainScheduleCONTENT_SECTION_43();
					content.SECTION[0].Value = CONTENT.SECTION;
				}

				if (CONTENT.TRAIN_SYMBOL != "Null") {
					content.TRAIN_SYMBOL = new NS_TrainScheduleCONTENT_TRAIN_SYMBOL_43[1];
					content.TRAIN_SYMBOL[0] = new NS_TrainScheduleCONTENT_TRAIN_SYMBOL_43();
					content.TRAIN_SYMBOL[0].Value = CONTENT.TRAIN_SYMBOL;
				}

				if (CONTENT.ORIGIN_DATE != "Null") {
					content.ORIGIN_DATE = new NS_TrainScheduleCONTENT_ORIGIN_DATE_43[1];
					content.ORIGIN_DATE[0] = new NS_TrainScheduleCONTENT_ORIGIN_DATE_43();
					content.ORIGIN_DATE[0].Value = CONTENT.ORIGIN_DATE;
				}

				if (CONTENT.REPORT_TYPE != null && CONTENT.REPORT_TYPE != "") {
					content.REPORT_TYPE = new NS_TrainScheduleCONTENT_REPORT_TYPE_43[1];
					content.REPORT_TYPE[0] = new NS_TrainScheduleCONTENT_REPORT_TYPE_43();
					if (CONTENT.REPORT_TYPE == "Empty") {
						content.REPORT_TYPE[0].Value = "";
					} else {
						content.REPORT_TYPE[0].Value = CONTENT.REPORT_TYPE;
					}
				}

				if (CONTENT.TRAIN_CATEGORY != "Null") {
					content.TRAIN_CATEGORY = new NS_TrainScheduleCONTENT_TRAIN_CATEGORY_43[1];
					content.TRAIN_CATEGORY[0] = new NS_TrainScheduleCONTENT_TRAIN_CATEGORY_43();
					content.TRAIN_CATEGORY[0].Value = CONTENT.TRAIN_CATEGORY;
				}

				if (CONTENT.TRAIN_GROUP != "Null") {
					content.TRAIN_GROUP = new NS_TrainScheduleCONTENT_TRAIN_GROUP_43[1];
					content.TRAIN_GROUP[0] = new NS_TrainScheduleCONTENT_TRAIN_GROUP_43();
					content.TRAIN_GROUP[0].Value = CONTENT.TRAIN_GROUP;
				}

				if (CONTENT.ORIGIN_LOCATION != "Null") {
					content.ORIGIN_LOCATION = new NS_TrainScheduleCONTENT_ORIGIN_LOCATION_43[1];
					content.ORIGIN_LOCATION[0] = new NS_TrainScheduleCONTENT_ORIGIN_LOCATION_43();
					content.ORIGIN_LOCATION[0].Value = CONTENT.ORIGIN_LOCATION;
				}

				if (CONTENT.TERMINATION_LOCATION != "Null") {
					content.TERMINATION_LOCATION = new NS_TrainScheduleCONTENT_TERMINATION_LOCATION_43[1];
					content.TERMINATION_LOCATION[0] = new NS_TrainScheduleCONTENT_TERMINATION_LOCATION_43();
					content.TERMINATION_LOCATION[0].Value = CONTENT.TERMINATION_LOCATION;
				}

				if (CONTENT.NUMBER_OF_STATIONS != "Null") {
					content.NUMBER_OF_STATIONS = new NS_TrainScheduleCONTENT_NUMBER_OF_STATIONS_43[1];
					content.NUMBER_OF_STATIONS[0] = new NS_TrainScheduleCONTENT_NUMBER_OF_STATIONS_43();
					content.NUMBER_OF_STATIONS[0].Value = CONTENT.NUMBER_OF_STATIONS;
				}

				if (CONTENT.STATION.Count != 0) {
					int stationIndex = 0;
					content.STATION = new NS_TrainScheduleCONTENT_STATION_43[CONTENT.STATION.Count];
					foreach (MIS_NS_TrainScheduleSTATION_43 STATION in CONTENT.STATION) {
						NS_TrainScheduleCONTENT_STATION_43 station = new NS_TrainScheduleCONTENT_STATION_43();
						if (STATION.STATION_SEQ_NUM != "Null") {
							station.STATION_SEQ_NUM = new NS_TrainScheduleSTATION_STATION_SEQ_NUM_43[1];
							station.STATION_SEQ_NUM[0] = new NS_TrainScheduleSTATION_STATION_SEQ_NUM_43();
							station.STATION_SEQ_NUM[0].Value = STATION.STATION_SEQ_NUM;
						}

						if (STATION.STATION_LOCATION != "Null") {
							station.STATION_LOCATION = new NS_TrainScheduleSTATION_STATION_LOCATION_43[1];
							station.STATION_LOCATION[0] = new NS_TrainScheduleSTATION_STATION_LOCATION_43();
							station.STATION_LOCATION[0].Value = STATION.STATION_LOCATION;
						}

						if (STATION.DAY_OF_STA != "Null") {
							station.DAY_OF_STA = new NS_TrainScheduleSTATION_DAY_OF_STA_43[1];
							station.DAY_OF_STA[0] = new NS_TrainScheduleSTATION_DAY_OF_STA_43();
							station.DAY_OF_STA[0].Value = STATION.DAY_OF_STA;
						}

						if (STATION.STA != "Null") {
							station.STA = new NS_TrainScheduleSTATION_STA_43[1];
							station.STA[0] = new NS_TrainScheduleSTATION_STA_43();
							station.STA[0].Value = STATION.STA;
						}

						if (STATION.STA_ZONE != "Null") {
							station.STA_ZONE = new NS_TrainScheduleSTATION_STA_ZONE_43[1];
							station.STA_ZONE[0] = new NS_TrainScheduleSTATION_STA_ZONE_43();
							station.STA_ZONE[0].Value = STATION.STA_ZONE;
						}

						if (STATION.DAY_OF_STD != "Null") {
							station.DAY_OF_STD = new NS_TrainScheduleSTATION_DAY_OF_STD_43[1];
							station.DAY_OF_STD[0] = new NS_TrainScheduleSTATION_DAY_OF_STD_43();
							station.DAY_OF_STD[0].Value = STATION.DAY_OF_STD;
						}

						if (STATION.STD != "Null") {
							station.STD = new NS_TrainScheduleSTATION_STD_43[1];
							station.STD[0] = new NS_TrainScheduleSTATION_STD_43();
							station.STD[0].Value = STATION.STD;
						}

						if (STATION.STD_ZONE != "Null") {
							station.STD_ZONE = new NS_TrainScheduleSTATION_STD_ZONE_43[1];
							station.STD_ZONE[0] = new NS_TrainScheduleSTATION_STD_ZONE_43();
							station.STD_ZONE[0].Value = STATION.STD_ZONE;
						}

						if (STATION.CREW_CHANGE != null && STATION.CREW_CHANGE != "") {
							station.CREW_CHANGE = new NS_TrainScheduleSTATION_CREW_CHANGE_43[1];
							station.CREW_CHANGE[0] = new NS_TrainScheduleSTATION_CREW_CHANGE_43();
							if (STATION.CREW_CHANGE == "Empty") {
								station.CREW_CHANGE[0].Value = "";
							} else {
								station.CREW_CHANGE[0].Value = STATION.CREW_CHANGE;
							}
						}

						if (STATION.CREW_LINE_SEGMENT != null && STATION.CREW_LINE_SEGMENT != "") {
							station.CREW_LINE_SEGMENT = new NS_TrainScheduleSTATION_CREW_LINE_SEGMENT_43[1];
							station.CREW_LINE_SEGMENT[0] = new NS_TrainScheduleSTATION_CREW_LINE_SEGMENT_43();
							if (STATION.CREW_LINE_SEGMENT == "Empty") {
								station.CREW_LINE_SEGMENT[0].Value = "";
							} else {
								station.CREW_LINE_SEGMENT[0].Value = STATION.CREW_LINE_SEGMENT;
							}
						}

						if (STATION.SETOUT != null && STATION.SETOUT != "") {
							station.SETOUT = new NS_TrainScheduleSTATION_SETOUT_43[1];
							station.SETOUT[0] = new NS_TrainScheduleSTATION_SETOUT_43();
							if (STATION.SETOUT == "Empty") {
								station.SETOUT[0].Value = "";
							} else {
								station.SETOUT[0].Value = STATION.SETOUT;
							}
						}

						if (STATION.PICKUP != null && STATION.PICKUP != "") {
							station.PICKUP = new NS_TrainScheduleSTATION_PICKUP_43[1];
							station.PICKUP[0] = new NS_TrainScheduleSTATION_PICKUP_43();
							if (STATION.PICKUP == "Empty") {
								station.PICKUP[0].Value = "";
							} else {
								station.PICKUP[0].Value = STATION.PICKUP;
							}
						}

						if (STATION.FUEL != null && STATION.FUEL != "") {
							station.FUEL = new NS_TrainScheduleSTATION_FUEL_43[1];
							station.FUEL[0] = new NS_TrainScheduleSTATION_FUEL_43();
							if (STATION.FUEL == "Empty") {
								station.FUEL[0].Value = "";
							} else {
								station.FUEL[0].Value = STATION.FUEL;
							}
						}

						if (STATION.INSPECTION != null && STATION.INSPECTION != "") {
							station.INSPECTION = new NS_TrainScheduleSTATION_INSPECTION_43[1];
							station.INSPECTION[0] = new NS_TrainScheduleSTATION_INSPECTION_43();
							if (STATION.INSPECTION == "Empty") {
								station.INSPECTION[0].Value = "";
							} else {
								station.INSPECTION[0].Value = STATION.INSPECTION;
							}
						}

						if (STATION.PASSENGER_STOP != null && STATION.PASSENGER_STOP != "") {
							station.PASSENGER_STOP = new NS_TrainScheduleSTATION_PASSENGER_STOP_43[1];
							station.PASSENGER_STOP[0] = new NS_TrainScheduleSTATION_PASSENGER_STOP_43();
							if (STATION.PASSENGER_STOP == "Empty") {
								station.PASSENGER_STOP[0].Value = "";
							} else {
								station.PASSENGER_STOP[0].Value = STATION.PASSENGER_STOP;
							}
						}

						if (STATION.EXIT_TO_FOREIGN_RAILROAD != null && STATION.EXIT_TO_FOREIGN_RAILROAD != "") {
							station.EXIT_TO_FOREIGN_RAILROAD = new NS_TrainScheduleSTATION_EXIT_TO_FOREIGN_RAILROAD_43[1];
							station.EXIT_TO_FOREIGN_RAILROAD[0] = new NS_TrainScheduleSTATION_EXIT_TO_FOREIGN_RAILROAD_43();
							if (STATION.EXIT_TO_FOREIGN_RAILROAD == "Empty") {
								station.EXIT_TO_FOREIGN_RAILROAD[0].Value = "";
							} else {
								station.EXIT_TO_FOREIGN_RAILROAD[0].Value = STATION.EXIT_TO_FOREIGN_RAILROAD;
							}
						}

						if (STATION.TURN_POINT != null && STATION.TURN_POINT != "") {
							station.TURN_POINT = new NS_TrainScheduleSTATION_TURN_POINT_43[1];
							station.TURN_POINT[0] = new NS_TrainScheduleSTATION_TURN_POINT_43();
							if (STATION.TURN_POINT == "Empty") {
								station.TURN_POINT[0].Value = "";
							} else {
								station.TURN_POINT[0].Value = STATION.TURN_POINT;
							}
						}

						if (STATION.PTC_TRAIN_ARRIVAL != null && STATION.PTC_TRAIN_ARRIVAL != "") {
							station.PTC_TRAIN_ARRIVAL = new NS_TrainScheduleSTATION_PTC_TRAIN_ARRIVAL_43[1];
							station.PTC_TRAIN_ARRIVAL[0] = new NS_TrainScheduleSTATION_PTC_TRAIN_ARRIVAL_43();
							if (STATION.PTC_TRAIN_ARRIVAL == "Empty") {
								station.PTC_TRAIN_ARRIVAL[0].Value = "";
							} else {
								station.PTC_TRAIN_ARRIVAL[0].Value = STATION.PTC_TRAIN_ARRIVAL;
							}
						}

						if (STATION.PTC_TRAIN_DEPARTURE != null && STATION.PTC_TRAIN_DEPARTURE != "") {
							station.PTC_TRAIN_DEPARTURE = new NS_TrainScheduleSTATION_PTC_TRAIN_DEPARTURE_43[1];
							station.PTC_TRAIN_DEPARTURE[0] = new NS_TrainScheduleSTATION_PTC_TRAIN_DEPARTURE_43();
							if (STATION.PTC_TRAIN_DEPARTURE == "Empty") {
								station.PTC_TRAIN_DEPARTURE[0].Value = "";
							} else {
								station.PTC_TRAIN_DEPARTURE[0].Value = STATION.PTC_TRAIN_DEPARTURE;
							}
						}

						content.STATION[stationIndex] = station;
						stationIndex++;
					}
				}

			}

			ns_trainschedule_43.Items[0] = header;
			ns_trainschedule_43.Items[1] = content;
			return ns_trainschedule_43;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,TRNSCH,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,TRNSCH,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_TrainScheduleHEADER_43 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_TrainScheduleCONTENT_43 {
		public string SCAC = "";
		public string SECTION = "";
		public string TRAIN_SYMBOL = "";
		public string ORIGIN_DATE = "";
		public string REPORT_TYPE = "";
		public string TRAIN_CATEGORY = "";
		public string TRAIN_GROUP = "";
		public string ORIGIN_LOCATION = "";
		public string TERMINATION_LOCATION = "";
		public string NUMBER_OF_STATIONS = "";
		public ArrayList STATION = new ArrayList();

		public void addSTATION(MIS_NS_TrainScheduleSTATION_43 station) {
			this.STATION.Add(station);
		}
	}

	public partial class MIS_NS_TrainScheduleSTATION_43 {
		public string STATION_SEQ_NUM = "";
		public string STATION_LOCATION = "";
		public string DAY_OF_STA = "";
		public string STA = "";
		public string STA_ZONE = "";
		public string DAY_OF_STD = "";
		public string STD = "";
		public string STD_ZONE = "";
		public string CREW_CHANGE = "";
		public string CREW_LINE_SEGMENT = "";
		public string SETOUT = "";
		public string PICKUP = "";
		public string FUEL = "";
		public string INSPECTION = "";
		public string PASSENGER_STOP = "";
		public string EXIT_TO_FOREIGN_RAILROAD = "";
		public string TURN_POINT = "";
		public string PTC_TRAIN_ARRIVAL = "";
		public string PTC_TRAIN_DEPARTURE = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "TrainSchedule", IsNullable = false)]
	public partial class NS_TrainSchedule_43 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_TrainScheduleHEADER_43), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_TrainScheduleCONTENT_43), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleHEADER_43 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleHEADER_PROTOCOLID_43[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleHEADER_MSGID_43[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleHEADER_TRACE_ID_43[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleHEADER_MESSAGE_VERSION_43[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleHEADER_PROTOCOLID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleHEADER_MSGID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleHEADER_TRACE_ID_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleHEADER_MESSAGE_VERSION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_43 {
		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_SCAC_43[] SCAC;

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_SECTION_43[] SECTION;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_TRAIN_SYMBOL_43[] TRAIN_SYMBOL;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_ORIGIN_DATE_43[] ORIGIN_DATE;

		[System.Xml.Serialization.XmlElementAttribute("REPORT_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_REPORT_TYPE_43[] REPORT_TYPE;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_CATEGORY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_TRAIN_CATEGORY_43[] TRAIN_CATEGORY;

		[System.Xml.Serialization.XmlElementAttribute("TRAIN_GROUP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_TRAIN_GROUP_43[] TRAIN_GROUP;

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_ORIGIN_LOCATION_43[] ORIGIN_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("TERMINATION_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_TERMINATION_LOCATION_43[] TERMINATION_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("NUMBER_OF_STATIONS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_NUMBER_OF_STATIONS_43[] NUMBER_OF_STATIONS;

		[System.Xml.Serialization.XmlElementAttribute("STATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleCONTENT_STATION_43[] STATION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_SCAC_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_SECTION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_TRAIN_SYMBOL_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_ORIGIN_DATE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_REPORT_TYPE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_TRAIN_CATEGORY_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_TRAIN_GROUP_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_ORIGIN_LOCATION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_TERMINATION_LOCATION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_NUMBER_OF_STATIONS_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleCONTENT_STATION_43 {
		[System.Xml.Serialization.XmlElementAttribute("STATION_SEQ_NUM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STATION_SEQ_NUM_43[] STATION_SEQ_NUM;

		[System.Xml.Serialization.XmlElementAttribute("STATION_LOCATION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STATION_LOCATION_43[] STATION_LOCATION;

		[System.Xml.Serialization.XmlElementAttribute("DAY_OF_STA", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_DAY_OF_STA_43[] DAY_OF_STA;

		[System.Xml.Serialization.XmlElementAttribute("STA", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STA_43[] STA;

		[System.Xml.Serialization.XmlElementAttribute("STA_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STA_ZONE_43[] STA_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("DAY_OF_STD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_DAY_OF_STD_43[] DAY_OF_STD;

		[System.Xml.Serialization.XmlElementAttribute("STD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STD_43[] STD;

		[System.Xml.Serialization.XmlElementAttribute("STD_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_STD_ZONE_43[] STD_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("CREW_CHANGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_CREW_CHANGE_43[] CREW_CHANGE;

		[System.Xml.Serialization.XmlElementAttribute("CREW_LINE_SEGMENT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_CREW_LINE_SEGMENT_43[] CREW_LINE_SEGMENT;

		[System.Xml.Serialization.XmlElementAttribute("SETOUT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_SETOUT_43[] SETOUT;

		[System.Xml.Serialization.XmlElementAttribute("PICKUP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_PICKUP_43[] PICKUP;

		[System.Xml.Serialization.XmlElementAttribute("FUEL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_FUEL_43[] FUEL;

		[System.Xml.Serialization.XmlElementAttribute("INSPECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_INSPECTION_43[] INSPECTION;

		[System.Xml.Serialization.XmlElementAttribute("PASSENGER_STOP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_PASSENGER_STOP_43[] PASSENGER_STOP;

		[System.Xml.Serialization.XmlElementAttribute("EXIT_TO_FOREIGN_RAILROAD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_EXIT_TO_FOREIGN_RAILROAD_43[] EXIT_TO_FOREIGN_RAILROAD;

		[System.Xml.Serialization.XmlElementAttribute("TURN_POINT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_TURN_POINT_43[] TURN_POINT;

		[System.Xml.Serialization.XmlElementAttribute("PTC_TRAIN_ARRIVAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_PTC_TRAIN_ARRIVAL_43[] PTC_TRAIN_ARRIVAL;

		[System.Xml.Serialization.XmlElementAttribute("PTC_TRAIN_DEPARTURE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_TrainScheduleSTATION_PTC_TRAIN_DEPARTURE_43[] PTC_TRAIN_DEPARTURE;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STATION_SEQ_NUM_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STATION_LOCATION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_DAY_OF_STA_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STA_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STA_ZONE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_DAY_OF_STD_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STD_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_STD_ZONE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_CREW_CHANGE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_CREW_LINE_SEGMENT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_SETOUT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_PICKUP_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_FUEL_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_INSPECTION_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_PASSENGER_STOP_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_EXIT_TO_FOREIGN_RAILROAD_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_TURN_POINT_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_PTC_TRAIN_ARRIVAL_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_TrainScheduleSTATION_PTC_TRAIN_DEPARTURE_43 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}