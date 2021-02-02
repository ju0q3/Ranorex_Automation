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
	public partial class MIS_NS_HourlyWeather_48 {
		public MIS_NS_HourlyWeatherHEADER_48 HEADER;
		public MIS_NS_HourlyWeatherCONTENT_48 CONTENT;

		public static void createNS_HourlyWeather_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_operator_initials,
			string content_state,
			string content_division,
			string content_station_id,
			string content_station_name,
			string content_date,
			string content_time,
			string content_time_zone,
			string content_tmpf,
			string content_dwpf,
			string content_hum,
			string content_flk,
			string content_wdr,
			string content_wsp,
			string content_gst,
			string content_max,
			string content_min,
			string content_pc1hr,
			string content_pc6hr,
			string content_ssm,
			string content_ssp,
			string content_brmtr,
			string content_vis,
			string content_weather,
			string content_cvr,
			string content_wxw,
			string content_cond,
			string content_sunr,
			string content_suns,
			string hostname
		) {
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			FileStream fs;

			MIS_NS_HourlyWeather_48 mis_ns_hourlyweather = buildMIS_NS_HourlyWeather_48(header_protocolid, header_msgid, header_trace_id, header_message_version, content_operator_initials, content_state, content_division, content_station_id, content_station_name, content_date, content_time, content_time_zone, content_tmpf, content_dwpf, content_hum, content_flk, content_wdr, content_wsp, content_gst, content_max, content_min, content_pc1hr, content_pc6hr, content_ssm, content_ssp, content_brmtr, content_vis, content_weather, content_cvr, content_wxw, content_cond, content_sunr, content_suns);

			NS_HourlyWeather_48 ns_hourlyweather = mis_ns_hourlyweather.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(NS_HourlyWeather_48));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ns_hourlyweather);
			fs.Close();

			if (hostname == "" || hostname == "Local") {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_hourlyweather.toSteMessageHeader(request, false);
				System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
			} else {
				string request = File.ReadAllText(temp+"/temp.request");
				request = mis_ns_hourlyweather.toSteMessageHeader(request, true);
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

		public static MIS_NS_HourlyWeather_48 buildMIS_NS_HourlyWeather_48(
			string header_protocolid,
			string header_msgid,
			string header_trace_id,
			string header_message_version,
			string content_operator_initials,
			string content_state,
			string content_division,
			string content_station_id,
			string content_station_name,
			string content_date,
			string content_time,
			string content_time_zone,
			string content_tmpf,
			string content_dwpf,
			string content_hum,
			string content_flk,
			string content_wdr,
			string content_wsp,
			string content_gst,
			string content_max,
			string content_min,
			string content_pc1hr,
			string content_pc6hr,
			string content_ssm,
			string content_ssp,
			string content_brmtr,
			string content_vis,
			string content_weather,
			string content_cvr,
			string content_wxw,
			string content_cond,
			string content_sunr,
			string content_suns
		) {

			MIS_NS_HourlyWeather_48 mis_ns_hourlyweather = new MIS_NS_HourlyWeather_48();

			MIS_NS_HourlyWeatherHEADER_48 header = new MIS_NS_HourlyWeatherHEADER_48();
			header.PROTOCOLID = header_protocolid;
			header.MSGID = header_msgid;
			header.TRACE_ID = header_trace_id;
			header.MESSAGE_VERSION = header_message_version;

			MIS_NS_HourlyWeatherCONTENT_48 content = new MIS_NS_HourlyWeatherCONTENT_48();
			content.OPERATOR_INITIALS = content_operator_initials;
			content.STATE = content_state;
			content.DIVISION = content_division;
			content.STATION_ID = content_station_id;
			content.STATION_NAME = content_station_name;
			content.DATE = content_date;
			content.TIME = content_time;
			content.TIME_ZONE = content_time_zone;
			content.TMPF = content_tmpf;
			content.DWPF = content_dwpf;
			content.HUM = content_hum;
			content.FLK = content_flk;
			content.WDR = content_wdr;
			content.WSP = content_wsp;
			content.GST = content_gst;
			content.MAX = content_max;
			content.MIN = content_min;
			content.PC1HR = content_pc1hr;
			content.PC6HR = content_pc6hr;
			content.SSM = content_ssm;
			content.SSP = content_ssp;
			content.BRMTR = content_brmtr;
			content.VIS = content_vis;
			content.WEATHER = content_weather;
			content.CVR = content_cvr;
			content.WXW = content_wxw;
			content.COND = content_cond;
			content.SUNR = content_sunr;
			content.SUNS = content_suns;

			mis_ns_hourlyweather.HEADER = header;
			mis_ns_hourlyweather.CONTENT = content;
			return mis_ns_hourlyweather;
		}

		public NS_HourlyWeather_48 toSerializableObject() {
			NS_HourlyWeather_48 ns_hourlyweather_48 = new NS_HourlyWeather_48();
			ns_hourlyweather_48.Items = new object[2];

			NS_HourlyWeatherHEADER_48 header = new NS_HourlyWeatherHEADER_48();
			if (this.HEADER != null) {
				if (HEADER.PROTOCOLID != "Null") {
					header.PROTOCOLID = new NS_HourlyWeatherHEADER_PROTOCOLID_48[1];
					header.PROTOCOLID[0] = new NS_HourlyWeatherHEADER_PROTOCOLID_48();
					header.PROTOCOLID[0].Value = HEADER.PROTOCOLID;
				}

				if (HEADER.MSGID != "Null") {
					header.MSGID = new NS_HourlyWeatherHEADER_MSGID_48[1];
					header.MSGID[0] = new NS_HourlyWeatherHEADER_MSGID_48();
					header.MSGID[0].Value = HEADER.MSGID;
				}

				if (HEADER.TRACE_ID != "Null") {
					header.TRACE_ID = new NS_HourlyWeatherHEADER_TRACE_ID_48[1];
					header.TRACE_ID[0] = new NS_HourlyWeatherHEADER_TRACE_ID_48();
					header.TRACE_ID[0].Value = HEADER.TRACE_ID;
				}

				if (HEADER.MESSAGE_VERSION != "Null") {
					header.MESSAGE_VERSION = new NS_HourlyWeatherHEADER_MESSAGE_VERSION_48[1];
					header.MESSAGE_VERSION[0] = new NS_HourlyWeatherHEADER_MESSAGE_VERSION_48();
					header.MESSAGE_VERSION[0].Value = HEADER.MESSAGE_VERSION;
				}

			}

			NS_HourlyWeatherCONTENT_48 content = new NS_HourlyWeatherCONTENT_48();
			if (this.CONTENT != null) {
				if (CONTENT.OPERATOR_INITIALS != "Null") {
					content.OPERATOR_INITIALS = new NS_HourlyWeatherCONTENT_OPERATOR_INITIALS_48[1];
					content.OPERATOR_INITIALS[0] = new NS_HourlyWeatherCONTENT_OPERATOR_INITIALS_48();
					content.OPERATOR_INITIALS[0].Value = CONTENT.OPERATOR_INITIALS;
				}

				if (CONTENT.STATE != "Null") {
					content.STATE = new NS_HourlyWeatherCONTENT_STATE_48[1];
					content.STATE[0] = new NS_HourlyWeatherCONTENT_STATE_48();
					content.STATE[0].Value = CONTENT.STATE;
				}

				if (CONTENT.DIVISION != "Null") {
					content.DIVISION = new NS_HourlyWeatherCONTENT_DIVISION_48[1];
					content.DIVISION[0] = new NS_HourlyWeatherCONTENT_DIVISION_48();
					content.DIVISION[0].Value = CONTENT.DIVISION;
				}

				if (CONTENT.STATION_ID != "Null") {
					content.STATION_ID = new NS_HourlyWeatherCONTENT_STATION_ID_48[1];
					content.STATION_ID[0] = new NS_HourlyWeatherCONTENT_STATION_ID_48();
					content.STATION_ID[0].Value = CONTENT.STATION_ID;
				}

				if (CONTENT.STATION_NAME != "Null") {
					content.STATION_NAME = new NS_HourlyWeatherCONTENT_STATION_NAME_48[1];
					content.STATION_NAME[0] = new NS_HourlyWeatherCONTENT_STATION_NAME_48();
					content.STATION_NAME[0].Value = CONTENT.STATION_NAME;
				}

				if (CONTENT.DATE != "Null") {
					content.DATE = new NS_HourlyWeatherCONTENT_DATE_48[1];
					content.DATE[0] = new NS_HourlyWeatherCONTENT_DATE_48();
					content.DATE[0].Value = CONTENT.DATE;
				}

				if (CONTENT.TIME != "Null") {
					content.TIME = new NS_HourlyWeatherCONTENT_TIME_48[1];
					content.TIME[0] = new NS_HourlyWeatherCONTENT_TIME_48();
					content.TIME[0].Value = CONTENT.TIME;
				}

				if (CONTENT.TIME_ZONE != "Null") {
					content.TIME_ZONE = new NS_HourlyWeatherCONTENT_TIME_ZONE_48[1];
					content.TIME_ZONE[0] = new NS_HourlyWeatherCONTENT_TIME_ZONE_48();
					content.TIME_ZONE[0].Value = CONTENT.TIME_ZONE;
				}

				if (CONTENT.TMPF != "Null") {
					content.TMPF = new NS_HourlyWeatherCONTENT_TMPF_48[1];
					content.TMPF[0] = new NS_HourlyWeatherCONTENT_TMPF_48();
					content.TMPF[0].Value = CONTENT.TMPF;
				}

				if (CONTENT.DWPF != null && CONTENT.DWPF != "") {
					content.DWPF = new NS_HourlyWeatherCONTENT_DWPF_48[1];
					content.DWPF[0] = new NS_HourlyWeatherCONTENT_DWPF_48();
					if (CONTENT.DWPF == "Empty") {
						content.DWPF[0].Value = "";
					} else {
						content.DWPF[0].Value = CONTENT.DWPF;
					}
				}

				if (CONTENT.HUM != null && CONTENT.HUM != "") {
					content.HUM = new NS_HourlyWeatherCONTENT_HUM_48[1];
					content.HUM[0] = new NS_HourlyWeatherCONTENT_HUM_48();
					if (CONTENT.HUM == "Empty") {
						content.HUM[0].Value = "";
					} else {
						content.HUM[0].Value = CONTENT.HUM;
					}
				}

				if (CONTENT.FLK != "Null") {
					content.FLK = new NS_HourlyWeatherCONTENT_FLK_48[1];
					content.FLK[0] = new NS_HourlyWeatherCONTENT_FLK_48();
					content.FLK[0].Value = CONTENT.FLK;
				}

				if (CONTENT.WDR != "Null") {
					content.WDR = new NS_HourlyWeatherCONTENT_WDR_48[1];
					content.WDR[0] = new NS_HourlyWeatherCONTENT_WDR_48();
					content.WDR[0].Value = CONTENT.WDR;
				}

				if (CONTENT.WSP != "Null") {
					content.WSP = new NS_HourlyWeatherCONTENT_WSP_48[1];
					content.WSP[0] = new NS_HourlyWeatherCONTENT_WSP_48();
					content.WSP[0].Value = CONTENT.WSP;
				}

				if (CONTENT.GST != null && CONTENT.GST != "") {
					content.GST = new NS_HourlyWeatherCONTENT_GST_48[1];
					content.GST[0] = new NS_HourlyWeatherCONTENT_GST_48();
					if (CONTENT.GST == "Empty") {
						content.GST[0].Value = "";
					} else {
						content.GST[0].Value = CONTENT.GST;
					}
				}

				if (CONTENT.MAX != null && CONTENT.MAX != "") {
					content.MAX = new NS_HourlyWeatherCONTENT_MAX_48[1];
					content.MAX[0] = new NS_HourlyWeatherCONTENT_MAX_48();
					if (CONTENT.MAX == "Empty") {
						content.MAX[0].Value = "";
					} else {
						content.MAX[0].Value = CONTENT.MAX;
					}
				}

				if (CONTENT.MIN != null && CONTENT.MIN != "") {
					content.MIN = new NS_HourlyWeatherCONTENT_MIN_48[1];
					content.MIN[0] = new NS_HourlyWeatherCONTENT_MIN_48();
					if (CONTENT.MIN == "Empty") {
						content.MIN[0].Value = "";
					} else {
						content.MIN[0].Value = CONTENT.MIN;
					}
				}

				if (CONTENT.PC1HR != null && CONTENT.PC1HR != "") {
					content.PC1HR = new NS_HourlyWeatherCONTENT_PC1HR_48[1];
					content.PC1HR[0] = new NS_HourlyWeatherCONTENT_PC1HR_48();
					if (CONTENT.PC1HR == "Empty") {
						content.PC1HR[0].Value = "";
					} else {
						content.PC1HR[0].Value = CONTENT.PC1HR;
					}
				}

				if (CONTENT.PC6HR != null && CONTENT.PC6HR != "") {
					content.PC6HR = new NS_HourlyWeatherCONTENT_PC6HR_48[1];
					content.PC6HR[0] = new NS_HourlyWeatherCONTENT_PC6HR_48();
					if (CONTENT.PC6HR == "Empty") {
						content.PC6HR[0].Value = "";
					} else {
						content.PC6HR[0].Value = CONTENT.PC6HR;
					}
				}

				if (CONTENT.SSM != null && CONTENT.SSM != "") {
					content.SSM = new NS_HourlyWeatherCONTENT_SSM_48[1];
					content.SSM[0] = new NS_HourlyWeatherCONTENT_SSM_48();
					if (CONTENT.SSM == "Empty") {
						content.SSM[0].Value = "";
					} else {
						content.SSM[0].Value = CONTENT.SSM;
					}
				}

				if (CONTENT.SSP != null && CONTENT.SSP != "") {
					content.SSP = new NS_HourlyWeatherCONTENT_SSP_48[1];
					content.SSP[0] = new NS_HourlyWeatherCONTENT_SSP_48();
					if (CONTENT.SSP == "Empty") {
						content.SSP[0].Value = "";
					} else {
						content.SSP[0].Value = CONTENT.SSP;
					}
				}

				if (CONTENT.BRMTR != null && CONTENT.BRMTR != "") {
					content.BRMTR = new NS_HourlyWeatherCONTENT_BRMTR_48[1];
					content.BRMTR[0] = new NS_HourlyWeatherCONTENT_BRMTR_48();
					if (CONTENT.BRMTR == "Empty") {
						content.BRMTR[0].Value = "";
					} else {
						content.BRMTR[0].Value = CONTENT.BRMTR;
					}
				}

				if (CONTENT.VIS != "Null") {
					content.VIS = new NS_HourlyWeatherCONTENT_VIS_48[1];
					content.VIS[0] = new NS_HourlyWeatherCONTENT_VIS_48();
					content.VIS[0].Value = CONTENT.VIS;
				}

				if (CONTENT.WEATHER != null && CONTENT.WEATHER != "") {
					content.WEATHER = new NS_HourlyWeatherCONTENT_WEATHER_48[1];
					content.WEATHER[0] = new NS_HourlyWeatherCONTENT_WEATHER_48();
					if (CONTENT.WEATHER == "Empty") {
						content.WEATHER[0].Value = "";
					} else {
						content.WEATHER[0].Value = CONTENT.WEATHER;
					}
				}

				if (CONTENT.CVR != null && CONTENT.CVR != "") {
					content.CVR = new NS_HourlyWeatherCONTENT_CVR_48[1];
					content.CVR[0] = new NS_HourlyWeatherCONTENT_CVR_48();
					if (CONTENT.CVR == "Empty") {
						content.CVR[0].Value = "";
					} else {
						content.CVR[0].Value = CONTENT.CVR;
					}
				}

				if (CONTENT.WXW != "Null") {
					content.WXW = new NS_HourlyWeatherCONTENT_WXW_48[1];
					content.WXW[0] = new NS_HourlyWeatherCONTENT_WXW_48();
					content.WXW[0].Value = CONTENT.WXW;
				}

				if (CONTENT.COND != "Null") {
					content.COND = new NS_HourlyWeatherCONTENT_COND_48[1];
					content.COND[0] = new NS_HourlyWeatherCONTENT_COND_48();
					content.COND[0].Value = CONTENT.COND;
				}

				if (CONTENT.SUNR != "Null") {
					content.SUNR = new NS_HourlyWeatherCONTENT_SUNR_48[1];
					content.SUNR[0] = new NS_HourlyWeatherCONTENT_SUNR_48();
					content.SUNR[0].Value = CONTENT.SUNR;
				}

				if (CONTENT.SUNS != "Null") {
					content.SUNS = new NS_HourlyWeatherCONTENT_SUNS_48[1];
					content.SUNS[0] = new NS_HourlyWeatherCONTENT_SUNS_48();
					content.SUNS[0].Value = CONTENT.SUNS;
				}

			}

			ns_hourlyweather_48.Items[0] = header;
			ns_hourlyweather_48.Items[1] = content;
			return ns_hourlyweather_48;
		}

		public string toSteMessageHeader(string serializedXml, bool remote = false) {
			//int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			//int headerTo = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo = serializedXml.LastIndexOf("</CONTENT>");

			string preScript = "";
			if (!remote) {
				preScript = "PASSTHRU,MHRWTHR,";
			} else {
				preScript = "RanorexAgent:PASSTHRU,MHRWTHR,";
			}

			string result = preScript + /*serializedXml.Substring(headerFrom, headerTo-headerFrom) + */serializedXml.Substring(contentFrom, contentTo-contentFrom);
			return result;
		}
	}
	public partial class MIS_NS_HourlyWeatherHEADER_48 {
		public string PROTOCOLID = "";
		public string MSGID = "";
		public string TRACE_ID = "";
		public string MESSAGE_VERSION = "";
	}

	public partial class MIS_NS_HourlyWeatherCONTENT_48 {
		public string OPERATOR_INITIALS = "";
		public string STATE = "";
		public string DIVISION = "";
		public string STATION_ID = "";
		public string STATION_NAME = "";
		public string DATE = "";
		public string TIME = "";
		public string TIME_ZONE = "";
		public string TMPF = "";
		public string DWPF = "";
		public string HUM = "";
		public string FLK = "";
		public string WDR = "";
		public string WSP = "";
		public string GST = "";
		public string MAX = "";
		public string MIN = "";
		public string PC1HR = "";
		public string PC6HR = "";
		public string SSM = "";
		public string SSP = "";
		public string BRMTR = "";
		public string VIS = "";
		public string WEATHER = "";
		public string CVR = "";
		public string WXW = "";
		public string COND = "";
		public string SUNR = "";
		public string SUNS = "";
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "HourlyWeather", IsNullable = false)]
	public partial class NS_HourlyWeather_48 {
		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(NS_HourlyWeatherHEADER_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(NS_HourlyWeatherCONTENT_48), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		public object[] Items;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherHEADER_48 {
		[System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherHEADER_PROTOCOLID_48[] PROTOCOLID;

		[System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherHEADER_MSGID_48[] MSGID;

		[System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherHEADER_TRACE_ID_48[] TRACE_ID;

		[System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherHEADER_MESSAGE_VERSION_48[] MESSAGE_VERSION;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherHEADER_PROTOCOLID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherHEADER_MSGID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherHEADER_TRACE_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherHEADER_MESSAGE_VERSION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_48 {
		[System.Xml.Serialization.XmlElementAttribute("OPERATOR_INITIALS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_OPERATOR_INITIALS_48[] OPERATOR_INITIALS;

		[System.Xml.Serialization.XmlElementAttribute("STATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_STATE_48[] STATE;

		[System.Xml.Serialization.XmlElementAttribute("DIVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_DIVISION_48[] DIVISION;

		[System.Xml.Serialization.XmlElementAttribute("STATION_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_STATION_ID_48[] STATION_ID;

		[System.Xml.Serialization.XmlElementAttribute("STATION_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_STATION_NAME_48[] STATION_NAME;

		[System.Xml.Serialization.XmlElementAttribute("DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_DATE_48[] DATE;

		[System.Xml.Serialization.XmlElementAttribute("TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_TIME_48[] TIME;

		[System.Xml.Serialization.XmlElementAttribute("TIME_ZONE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_TIME_ZONE_48[] TIME_ZONE;

		[System.Xml.Serialization.XmlElementAttribute("TMPF", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_TMPF_48[] TMPF;

		[System.Xml.Serialization.XmlElementAttribute("DWPF", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_DWPF_48[] DWPF;

		[System.Xml.Serialization.XmlElementAttribute("HUM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_HUM_48[] HUM;

		[System.Xml.Serialization.XmlElementAttribute("FLK", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_FLK_48[] FLK;

		[System.Xml.Serialization.XmlElementAttribute("WDR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_WDR_48[] WDR;

		[System.Xml.Serialization.XmlElementAttribute("WSP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_WSP_48[] WSP;

		[System.Xml.Serialization.XmlElementAttribute("GST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_GST_48[] GST;

		[System.Xml.Serialization.XmlElementAttribute("MAX", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_MAX_48[] MAX;

		[System.Xml.Serialization.XmlElementAttribute("MIN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_MIN_48[] MIN;

		[System.Xml.Serialization.XmlElementAttribute("PC1HR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_PC1HR_48[] PC1HR;

		[System.Xml.Serialization.XmlElementAttribute("PC6HR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_PC6HR_48[] PC6HR;

		[System.Xml.Serialization.XmlElementAttribute("SSM", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_SSM_48[] SSM;

		[System.Xml.Serialization.XmlElementAttribute("SSP", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_SSP_48[] SSP;

		[System.Xml.Serialization.XmlElementAttribute("BRMTR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_BRMTR_48[] BRMTR;

		[System.Xml.Serialization.XmlElementAttribute("VIS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_VIS_48[] VIS;

		[System.Xml.Serialization.XmlElementAttribute("WEATHER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_WEATHER_48[] WEATHER;

		[System.Xml.Serialization.XmlElementAttribute("CVR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_CVR_48[] CVR;

		[System.Xml.Serialization.XmlElementAttribute("WXW", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_WXW_48[] WXW;

		[System.Xml.Serialization.XmlElementAttribute("COND", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_COND_48[] COND;

		[System.Xml.Serialization.XmlElementAttribute("SUNR", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_SUNR_48[] SUNR;

		[System.Xml.Serialization.XmlElementAttribute("SUNS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public NS_HourlyWeatherCONTENT_SUNS_48[] SUNS;

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_OPERATOR_INITIALS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_STATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_DIVISION_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_STATION_ID_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_STATION_NAME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_DATE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_TIME_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_TIME_ZONE_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_TMPF_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_DWPF_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_HUM_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_FLK_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_WDR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_WSP_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_GST_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_MAX_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_MIN_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_PC1HR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_PC6HR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_SSM_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_SSP_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_BRMTR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_VIS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_WEATHER_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_CVR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_WXW_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_COND_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_SUNR_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class NS_HourlyWeatherCONTENT_SUNS_48 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value;
	}

}