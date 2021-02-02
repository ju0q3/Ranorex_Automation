/*
 * Created by Ranorex
 * User: arteja
 * Date: 19-03-2019
 * Time: 20:36
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */

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

namespace STE.Code_Utils.messages.PTC
{
	
	public partial class PTC_CD_CODS_7
	{
		private PTC_CD_CODSHEADER_7 thisHEADER;
		private PTC_CD_CODSCONTENT_7 thisCONTENT;

		public PTC_CD_CODSHEADER_7 HEADER {
			get { return this.thisHEADER; }
			set { this.thisHEADER = value; }
		}

		public PTC_CD_CODSCONTENT_7 CONTENT {
			get { return this.thisCONTENT; }
			set { this.thisCONTENT = value; }
		}

		public static void createCD_CODS_7(
			string header_message_version,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string TCON_Sequence_number,
			string scac,
			string symbol,
			string section,
			string Status_code,
			string ptc_engine_initial,
			string ptc_engine_number
		) {
			
			PTC_CD_CODS_7 cD_CODS = buildCD_CODS_7Config(header_message_version,  header_district_name,  header_district_scac,  header_user_id,  header_track_file_version,  header_htrn_scac,  header_htrn_symbol,  header_htrn_section,  header_heng_engine_initial,  header_heng_engine_number, TCON_Sequence_number,   scac,  symbol,  section, Status_code, ptc_engine_initial,  ptc_engine_number);
			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			System.DateTime now = System.DateTime.Now;
			FileStream fs;
			string request = "";


			CD_CODS_7 ptc_cd_cods = cD_CODS.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(CD_CODS_7));
			var writer = new SteXmlTextWriter(fs);
			 serializer.Serialize(writer, ptc_cd_cods);
			 Ranorex.Report.Info("fs"+ fs);
			fs.Close();

			request = File.ReadAllText(temp+"/temp.request");
			request = cD_CODS.toSteMessageHeader(request);
			 Ranorex.Report.Info("request" + request);
			System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
		}
		
		public static void createCD_CODS_7(
			string header_message_version,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string TCON_Sequence_number,
			string scac,
			string symbol,
			string section,
			string Status_code,
			string ptc_engine_initial,
			string ptc_engine_number,string hostname
		){
			int receiver_port = 2500;
			PTC_CD_CODS_7 cD_CODS = buildCD_CODS_7Config(header_message_version,  header_district_name,  header_district_scac,  header_user_id,  header_track_file_version,  header_htrn_scac,  header_htrn_symbol,  header_htrn_section,  header_heng_engine_initial,  header_heng_engine_number, TCON_Sequence_number,   scac,  symbol,  section, Status_code,ptc_engine_initial,  ptc_engine_number);

			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			
			XmlSerializer serializer;
			System.DateTime now = System.DateTime.Now;
			FileStream fs;
			string request = "";

			CD_CODS_7 ptc_cd_cods = cD_CODS.toSerializableObject();
			fs = File.Create(temp+"/temp.request");
			serializer = new XmlSerializer(typeof(CD_CODS_7));
			var writer = new SteXmlTextWriter(fs);
			serializer.Serialize(writer, ptc_cd_cods);
			fs.Close();
			
			
			request = File.ReadAllText(temp+"/temp.request");
			request = cD_CODS.toSteMessageHeader(request, true);
			
			//For loop for testing sending 20k messages to automation receiver.
			//for (int i = 0; i < 500000; i++)
			//{
			using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {
				NetworkStream nw = tcp.GetStream();
				nw.ReadTimeout = 5000; //5 second timeout for read response
				Ranorex.Report.Info(String.Format("Encoding Message {0} for STE {1}:2500",request, hostname));
				//byte[] bytesToSend = UTF8Encoding.UTF8.GetBytes(request);
				Byte[] data = System.Text.Encoding.ASCII.GetBytes(request);
				//log to record we are sending exec
				nw.Write(data, 0, data.Length);
				
				Thread.Sleep(5);
				nw.Close();
			}
			
		}

		public static PTC_CD_CODS_7 buildCD_CODS_7Config(
			string header_message_version,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string TCON_Sequence_number,
			string scac,
			string symbol,
			string section,
			string Status_code,
			string ptc_engine_initial,
			string ptc_engine_number
		){
			PTC_CD_CODS_7 cD_CODS = new PTC_CD_CODS_7();

			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			System.DateTime now = System.DateTime.Now;
			
			PTC_CD_CODSHEADER_7 header = new PTC_CD_CODSHEADER_7();
			header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
			header.HEADER_EVENT_TIME = now.ToString("HHmmss");
			header.HEADER_MESSAGE_ID = "CD-CODS";
			header.HEADER_SEQUENCE_NUMBER = "default";
			header.HEADER_MESSAGE_VERSION = "7";
			header.HEADER_MESSAGE_REVISION = "0";
			header.HEADER_SOURCE_SYS = "CI";
			header.HEADER_DESTINATION_SYS = "CAD";
			header.HEADER_DISTRICT_NAME = "MCCOMB";
			header.HEADER_DISTRICT_SCAC = header_district_scac;
			header.HEADER_USER_ID = "USER_ID";
			header.HEADER_TRACK_FILE_VERSION = "1234";
			header.HEADER_HTRN_SCAC = scac;
			header.HEADER_HTRN_SYMBOL = symbol;
			header.HEADER_HTRN_SECTION = section;
			header.HEADER_HTRN_ORIGIN_DATE = now.ToString("MMddyyyy");
			header.HEADER_HENG_ENGINE_INITIAL = header_heng_engine_initial;
			header.HEADER_HENG_ENGINE_NUMBER = header_heng_engine_number;

			PTC_CD_CODSCONTENT_7 content = new PTC_CD_CODSCONTENT_7();
			content.TCON_SEQUENCE_NUMBER = TCON_Sequence_number;
			content.SCAC = scac;
			content.SYMBOL = symbol;
			content.SECTION = section;
			content.STATUS_CODE = Status_code;
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.PTC_ENGINE_INITIAL = ptc_engine_initial;
			content.PTC_ENGINE_NUMBER = ptc_engine_number;
	

			cD_CODS.HEADER = header;
			cD_CODS.CONTENT = content;
			
			return cD_CODS;
			
		}
		
		public static void createCD_CODS_7Msmq(
			string header_message_version,
			string header_district_name,
			string header_district_scac,
			string header_user_id,
			string header_track_file_version,
			string header_htrn_scac,
			string header_htrn_symbol,
			string header_htrn_section,
			string header_heng_engine_initial,
			string header_heng_engine_number,
			string TCON_Sequence_number,
			string scac,
			string symbol,
			string section,
			string Status_code,
			string ptc_engine_initial,
			string ptc_engine_number
		) {
			PTC_CD_CODS_7 cD_CODS = new PTC_CD_CODS_7();

			string temp = System.Environment.GetEnvironmentVariable("TEMP");
			XmlSerializer serializer;
			System.DateTime now = System.DateTime.Now;
			string request = "";


			PTC_CD_CODSHEADER_7 header = new PTC_CD_CODSHEADER_7();
			header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
			header.HEADER_EVENT_TIME = now.ToString("HHmmss");
			header.HEADER_MESSAGE_ID = "CD-CODS";
			header.HEADER_SEQUENCE_NUMBER = "default";
			header.HEADER_MESSAGE_VERSION = "7";
			header.HEADER_MESSAGE_REVISION = "0";
			header.HEADER_SOURCE_SYS = "CI";
			header.HEADER_DESTINATION_SYS = "CAD";
			header.HEADER_DISTRICT_NAME = "MCCOMB";
			header.HEADER_DISTRICT_SCAC = header_district_scac;
			header.HEADER_USER_ID = "USER_ID";
			header.HEADER_TRACK_FILE_VERSION = "1234";
			header.HEADER_HTRN_SCAC = scac;
			header.HEADER_HTRN_SYMBOL = symbol;
			header.HEADER_HTRN_SECTION = section;
			header.HEADER_HTRN_ORIGIN_DATE = now.ToString("MMddyyyy");
			header.HEADER_HENG_ENGINE_INITIAL = header_heng_engine_initial;
			header.HEADER_HENG_ENGINE_NUMBER = header_heng_engine_number;

			PTC_CD_CODSCONTENT_7 content = new PTC_CD_CODSCONTENT_7();
			content.TCON_SEQUENCE_NUMBER = TCON_Sequence_number;
			content.SCAC = scac;
			content.SYMBOL = symbol;
			content.SECTION = section;
			content.STATUS_CODE = Status_code;
			content.ORIGIN_DATE = now.ToString("MMddyyyy");
			content.PTC_ENGINE_INITIAL = ptc_engine_initial;
			content.PTC_ENGINE_NUMBER = ptc_engine_number;
			
			
			cD_CODS.HEADER = header;
			cD_CODS.CONTENT = content;

			CD_CODS_7 ptc_cd_cods = cD_CODS.toSerializableObject();
			Ranorex.Report.Info("ptc_cd_cods" +ptc_cd_cods);
			serializer = new XmlSerializer(typeof(PTC_CD_CODS_7));
			StringWriter writer = new StringWriter();
			serializer.Serialize(writer, ptc_cd_cods);
			request = cD_CODS.toSteMessageHeader(writer.ToString());
			SteMessageQueue.Instance().Send(request, "PTC_CD-CODS");
		}

		public CD_CODS_7 toSerializableObject() {
			CD_CODS_7 cd_cods_7 = new CD_CODS_7();
			cd_cods_7.Items = new object[2];

			CD_CODSHEADER_7 header = new CD_CODSHEADER_7();
			if (this.HEADER != null) {
				if (this.HEADER.HEADER_EVENT_DATE != null) {
					header.HEADER_EVENT_DATE = new CD_CODSHEADERHEADER_EVENT_DATE_7[1];
					CD_CODSHEADERHEADER_EVENT_DATE_7 header_event_date = new CD_CODSHEADERHEADER_EVENT_DATE_7();
					header_event_date.Value = this.HEADER.HEADER_EVENT_DATE;
					header.HEADER_EVENT_DATE[0] = header_event_date;
				}

				if (this.HEADER.HEADER_EVENT_TIME != null) {
					header.HEADER_EVENT_TIME = new CD_CODSHEADERHEADER_EVENT_TIME_7[1];
					CD_CODSHEADERHEADER_EVENT_TIME_7 header_event_time = new CD_CODSHEADERHEADER_EVENT_TIME_7();
					header_event_time.Value = this.HEADER.HEADER_EVENT_TIME;
					header.HEADER_EVENT_TIME[0] = header_event_time;
				}

				if (this.HEADER.HEADER_MESSAGE_ID != null) {
					header.HEADER_MESSAGE_ID = new CD_CODSHEADERHEADER_MESSAGE_ID_7[1];
					CD_CODSHEADERHEADER_MESSAGE_ID_7 header_message_id = new CD_CODSHEADERHEADER_MESSAGE_ID_7();
					header_message_id.Value = this.HEADER.HEADER_MESSAGE_ID;
					header.HEADER_MESSAGE_ID[0] = header_message_id;
				}

				if (this.HEADER.HEADER_SEQUENCE_NUMBER != null) {
					header.HEADER_SEQUENCE_NUMBER = new CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7[1];
					CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7 header_sequence_number = new CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7();
					header_sequence_number.Value = this.HEADER.HEADER_SEQUENCE_NUMBER;
					header.HEADER_SEQUENCE_NUMBER[0] = header_sequence_number;
				}

				if (this.HEADER.HEADER_MESSAGE_VERSION != null) {
					header.HEADER_MESSAGE_VERSION = new CD_CODSHEADERHEADER_MESSAGE_VERSION_7[1];
					CD_CODSHEADERHEADER_MESSAGE_VERSION_7 header_message_version = new CD_CODSHEADERHEADER_MESSAGE_VERSION_7();
					header_message_version.Value = this.HEADER.HEADER_MESSAGE_VERSION;
					header.HEADER_MESSAGE_VERSION[0] = header_message_version;
				}

				if (this.HEADER.HEADER_MESSAGE_REVISION != null) {
					header.HEADER_MESSAGE_REVISION = new CD_CODSHEADERHEADER_MESSAGE_REVISION_7[1];
					CD_CODSHEADERHEADER_MESSAGE_REVISION_7 header_message_revision = new CD_CODSHEADERHEADER_MESSAGE_REVISION_7();
					header_message_revision.Value = this.HEADER.HEADER_MESSAGE_REVISION;
					header.HEADER_MESSAGE_REVISION[0] = header_message_revision;
				}

				if (this.HEADER.HEADER_SOURCE_SYS != null) {
					header.HEADER_SOURCE_SYS = new CD_CODSHEADERHEADER_SOURCE_SYS_7[1];
					CD_CODSHEADERHEADER_SOURCE_SYS_7 header_source_sys = new CD_CODSHEADERHEADER_SOURCE_SYS_7();
					header_source_sys.Value = this.HEADER.HEADER_SOURCE_SYS;
					header.HEADER_SOURCE_SYS[0] = header_source_sys;
				}

				if (this.HEADER.HEADER_DESTINATION_SYS != null) {
					header.HEADER_DESTINATION_SYS = new CD_CODSHEADERHEADER_DESTINATION_SYS_7[1];
					CD_CODSHEADERHEADER_DESTINATION_SYS_7 header_destination_sys = new CD_CODSHEADERHEADER_DESTINATION_SYS_7();
					header_destination_sys.Value = this.HEADER.HEADER_DESTINATION_SYS;
					header.HEADER_DESTINATION_SYS[0] = header_destination_sys;
				}

				if (this.HEADER.HEADER_DISTRICT_NAME != null) {
					header.HEADER_DISTRICT_NAME = new CD_CODSHEADERHEADER_DISTRICT_NAME_7[1];
					CD_CODSHEADERHEADER_DISTRICT_NAME_7 header_district_name = new CD_CODSHEADERHEADER_DISTRICT_NAME_7();
					header_district_name.Value = this.HEADER.HEADER_DISTRICT_NAME;
					header.HEADER_DISTRICT_NAME[0] = header_district_name;
				}

				if (this.HEADER.HEADER_DISTRICT_SCAC != null) {
					header.HEADER_DISTRICT_SCAC = new CD_CODSHEADERHEADER_DISTRICT_SCAC_7[1];
					CD_CODSHEADERHEADER_DISTRICT_SCAC_7 header_district_scac = new CD_CODSHEADERHEADER_DISTRICT_SCAC_7();
					header_district_scac.Value = this.HEADER.HEADER_DISTRICT_SCAC;
					header.HEADER_DISTRICT_SCAC[0] = header_district_scac;
				}

				if (this.HEADER.HEADER_USER_ID != null) {
					header.HEADER_USER_ID = new CD_CODSHEADERHEADER_USER_ID_7[1];
					CD_CODSHEADERHEADER_USER_ID_7 header_user_id = new CD_CODSHEADERHEADER_USER_ID_7();
					header_user_id.Value = this.HEADER.HEADER_USER_ID;
					header.HEADER_USER_ID[0] = header_user_id;
				}

				if (this.HEADER.HEADER_TRACK_FILE_VERSION != null) {
					header.HEADER_TRACK_FILE_VERSION = new CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7[1];
					CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7 header_track_file_version = new CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7();
					header_track_file_version.Value = this.HEADER.HEADER_TRACK_FILE_VERSION;
					header.HEADER_TRACK_FILE_VERSION[0] = header_track_file_version;
				}

				if (this.HEADER.HEADER_HTRN_SCAC != null) {
					header.HEADER_HTRN_SCAC = new CD_CODSHEADERHEADER_HTRN_SCAC_7[1];
					CD_CODSHEADERHEADER_HTRN_SCAC_7 header_htrn_scac = new CD_CODSHEADERHEADER_HTRN_SCAC_7();
					header_htrn_scac.Value = this.HEADER.HEADER_HTRN_SCAC;
					header.HEADER_HTRN_SCAC[0] = header_htrn_scac;
				}

				if (this.HEADER.HEADER_HTRN_SYMBOL != null) {
					header.HEADER_HTRN_SYMBOL = new CD_CODSHEADERHEADER_HTRN_SYMBOL_7[1];
					CD_CODSHEADERHEADER_HTRN_SYMBOL_7 header_htrn_symbol = new CD_CODSHEADERHEADER_HTRN_SYMBOL_7();
					header_htrn_symbol.Value = this.HEADER.HEADER_HTRN_SYMBOL;
					header.HEADER_HTRN_SYMBOL[0] = header_htrn_symbol;
				}

				if (this.HEADER.HEADER_HTRN_SECTION != null) {
					header.HEADER_HTRN_SECTION = new CD_CODSHEADERHEADER_HTRN_SECTION_7[1];
					CD_CODSHEADERHEADER_HTRN_SECTION_7 header_htrn_section = new CD_CODSHEADERHEADER_HTRN_SECTION_7();
					header_htrn_section.Value = this.HEADER.HEADER_HTRN_SECTION;
					header.HEADER_HTRN_SECTION[0] = header_htrn_section;
				}

				if (this.HEADER.HEADER_HTRN_ORIGIN_DATE != null) {
					header.HEADER_HTRN_ORIGIN_DATE = new CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7[1];
					CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7 header_htrn_origin_date = new CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7();
					header_htrn_origin_date.Value = this.HEADER.HEADER_HTRN_ORIGIN_DATE;
					header.HEADER_HTRN_ORIGIN_DATE[0] = header_htrn_origin_date;
				}

				if (this.HEADER.HEADER_HENG_ENGINE_INITIAL != null) {
					header.HEADER_HENG_ENGINE_INITIAL = new CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7[1];
					CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7 header_heng_engine_initial = new CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7();
					header_heng_engine_initial.Value = this.HEADER.HEADER_HENG_ENGINE_INITIAL;
					header.HEADER_HENG_ENGINE_INITIAL[0] = header_heng_engine_initial;
				}

				if (this.HEADER.HEADER_HENG_ENGINE_NUMBER != null) {
					header.HEADER_HENG_ENGINE_NUMBER = new CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7[1];
					CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7 header_heng_engine_number = new CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7();
					header_heng_engine_number.Value = this.HEADER.HEADER_HENG_ENGINE_NUMBER;
					header.HEADER_HENG_ENGINE_NUMBER[0] = header_heng_engine_number;
				}

			}

			CD_CODSCONTENT_7 content = new CD_CODSCONTENT_7();
			if (this.CONTENT.TCON_SEQUENCE_NUMBER != null) {
				content.TCON_SEQUENCE_NUMBER = new CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7[1];
				CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7 TCON_Sequence_number = new CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7();
				TCON_Sequence_number.Value = this.CONTENT.TCON_SEQUENCE_NUMBER;
				content.TCON_SEQUENCE_NUMBER[0] = TCON_Sequence_number;
			}
			
			if (this.CONTENT != null) {
				if (this.CONTENT.SCAC != null) {
					content.SCAC = new CD_CODSCONTENTSCAC_7[1];
					CD_CODSCONTENTSCAC_7 scac = new CD_CODSCONTENTSCAC_7();
					scac.Value = this.CONTENT.SCAC;
					content.SCAC[0] = scac;
				}

				if (this.CONTENT.SYMBOL != null) {
					content.SYMBOL = new CD_CODSCONTENTSYMBOL_7[1];
					CD_CODSCONTENTSYMBOL_7 symbol = new CD_CODSCONTENTSYMBOL_7();
					symbol.Value = this.CONTENT.SYMBOL;
					content.SYMBOL[0] = symbol;
				}

				if (this.CONTENT.SECTION != null) {
					content.SECTION = new CD_CODSCONTENTSECTION_7[1];
					CD_CODSCONTENTSECTION_7 section = new CD_CODSCONTENTSECTION_7();
					section.Value = this.CONTENT.SECTION;
					content.SECTION[0] = section;
				}
				
							
				if (this.CONTENT.STATUS_CODE != null) {
					content.STATUS_CODE = new CD_CODSCONTENTSTATUS_CODE_7[1];
					CD_CODSCONTENTSTATUS_CODE_7 Status_code = new CD_CODSCONTENTSTATUS_CODE_7();
					Status_code.Value = this.CONTENT.STATUS_CODE;
					content.STATUS_CODE[0] = Status_code;
				}

				if (this.CONTENT.ORIGIN_DATE != null) {
					content.ORIGIN_DATE = new CD_CODSCONTENTORIGIN_DATE_7[1];
					CD_CODSCONTENTORIGIN_DATE_7 origin_date = new CD_CODSCONTENTORIGIN_DATE_7();
					origin_date.Value = this.CONTENT.ORIGIN_DATE;
					content.ORIGIN_DATE[0] = origin_date;
				}

				if (this.CONTENT.PTC_ENGINE_INITIAL != null) {
					content.PTC_ENGINE_INITIAL = new CD_CODSCONTENTPTC_ENGINE_INITIAL_7[1];
					CD_CODSCONTENTPTC_ENGINE_INITIAL_7 ptc_engine_initial = new CD_CODSCONTENTPTC_ENGINE_INITIAL_7();
					ptc_engine_initial.Value = this.CONTENT.PTC_ENGINE_INITIAL;
					content.PTC_ENGINE_INITIAL[0] = ptc_engine_initial;
				}

				if (this.CONTENT.PTC_ENGINE_NUMBER != null) {
					content.PTC_ENGINE_NUMBER = new CD_CODSCONTENTPTC_ENGINE_NUMBER_7[1];
					CD_CODSCONTENTPTC_ENGINE_NUMBER_7 ptc_engine_number = new CD_CODSCONTENTPTC_ENGINE_NUMBER_7();
					ptc_engine_number.Value = this.CONTENT.PTC_ENGINE_NUMBER;
					content.PTC_ENGINE_NUMBER[0] = ptc_engine_number;
				}
											
	
			}

			cd_cods_7.Items[0] = header;
			cd_cods_7.Items[1] = content;
			return cd_cods_7;
		}

		public string toSteMessageHeader(string serializedXml , bool remote=false) {
			int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
			int headerTo   = serializedXml.LastIndexOf("</HEADER>");
			int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
			int contentTo   = serializedXml.LastIndexOf("</CONTENT>");
			
			string header = "";
			
			if (!remote)
			{
				header = "PASSTHRUOTC|CD-CODS|";
			}
			else
			{
				header = "RanorexAgent:PASSTHRUOTC|CD-CODS|";
			}
			
			string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
			Ranorex.Report.Info("result" + result);
			return result;
		}

	}

	public partial class PTC_CD_CODSHEADER_7 {
		private string thisHEADER_EVENT_DATE = "";
		private string thisHEADER_EVENT_TIME = "";
		private string thisHEADER_MESSAGE_ID = "";
		private string thisHEADER_SEQUENCE_NUMBER = "";
		private string thisHEADER_MESSAGE_VERSION = "";
		private string thisHEADER_MESSAGE_REVISION = "";
		private string thisHEADER_SOURCE_SYS = "";
		private string thisHEADER_DESTINATION_SYS = "";
		private string thisHEADER_DISTRICT_NAME = "";
		private string thisHEADER_DISTRICT_SCAC = "";
		private string thisHEADER_USER_ID = "";
		private string thisHEADER_TRACK_FILE_VERSION = "";
		private string thisHEADER_HTRN_SCAC = "";
		private string thisHEADER_HTRN_SYMBOL = "";
		private string thisHEADER_HTRN_SECTION = "";
		private string thisHEADER_HTRN_ORIGIN_DATE = "";
		private string thisHEADER_HENG_ENGINE_INITIAL = "";
		private string thisHEADER_HENG_ENGINE_NUMBER = "";
		

		public string HEADER_EVENT_DATE {
			get { return this.thisHEADER_EVENT_DATE; }
			set { this.thisHEADER_EVENT_DATE = value; }
		}

		public string HEADER_EVENT_TIME {
			get { return this.thisHEADER_EVENT_TIME; }
			set { this.thisHEADER_EVENT_TIME = value; }
		}

		public string HEADER_MESSAGE_ID {
			get { return this.thisHEADER_MESSAGE_ID; }
			set { this.thisHEADER_MESSAGE_ID = value; }
		}

		public string HEADER_SEQUENCE_NUMBER {
			get { return this.thisHEADER_SEQUENCE_NUMBER; }
			set { this.thisHEADER_SEQUENCE_NUMBER = value; }
		}

		public string HEADER_MESSAGE_VERSION {
			get { return this.thisHEADER_MESSAGE_VERSION; }
			set { this.thisHEADER_MESSAGE_VERSION = value; }
		}

		public string HEADER_MESSAGE_REVISION {
			get { return this.thisHEADER_MESSAGE_REVISION; }
			set { this.thisHEADER_MESSAGE_REVISION = value; }
		}

		public string HEADER_SOURCE_SYS {
			get { return this.thisHEADER_SOURCE_SYS; }
			set { this.thisHEADER_SOURCE_SYS = value; }
		}

		public string HEADER_DESTINATION_SYS {
			get { return this.thisHEADER_DESTINATION_SYS; }
			set { this.thisHEADER_DESTINATION_SYS = value; }
		}

		public string HEADER_DISTRICT_NAME {
			get { return this.thisHEADER_DISTRICT_NAME; }
			set { this.thisHEADER_DISTRICT_NAME = value; }
		}

		public string HEADER_DISTRICT_SCAC {
			get { return this.thisHEADER_DISTRICT_SCAC; }
			set { this.thisHEADER_DISTRICT_SCAC = value; }
		}

		public string HEADER_USER_ID {
			get { return this.thisHEADER_USER_ID; }
			set { this.thisHEADER_USER_ID = value; }
		}

		public string HEADER_TRACK_FILE_VERSION {
			get { return this.thisHEADER_TRACK_FILE_VERSION; }
			set { this.thisHEADER_TRACK_FILE_VERSION = value; }
		}

		public string HEADER_HTRN_SCAC {
			get { return this.thisHEADER_HTRN_SCAC; }
			set { this.thisHEADER_HTRN_SCAC = value; }
		}

		public string HEADER_HTRN_SYMBOL {
			get { return this.thisHEADER_HTRN_SYMBOL; }
			set { this.thisHEADER_HTRN_SYMBOL = value; }
		}

		public string HEADER_HTRN_SECTION {
			get { return this.thisHEADER_HTRN_SECTION; }
			set { this.thisHEADER_HTRN_SECTION = value; }
		}

		public string HEADER_HTRN_ORIGIN_DATE {
			get { return this.thisHEADER_HTRN_ORIGIN_DATE; }
			set { this.thisHEADER_HTRN_ORIGIN_DATE = value; }
		}

		public string HEADER_HENG_ENGINE_INITIAL {
			get { return this.thisHEADER_HENG_ENGINE_INITIAL; }
			set { this.thisHEADER_HENG_ENGINE_INITIAL = value; }
		}

		public string HEADER_HENG_ENGINE_NUMBER {
			get { return this.thisHEADER_HENG_ENGINE_NUMBER; }
			set { this.thisHEADER_HENG_ENGINE_NUMBER = value; }
		}


	}

	public partial class PTC_CD_CODSCONTENT_7 {
		private string thisTCON_SEQUENCE_NUMBER = "";
		private string thisSCAC = "";
		private string thisSYMBOL = "";
		private string thisSECTION = "";
		private string thisSTATUS_CODE = "";
		private string thisORIGIN_DATE = "";
		private string thisPTC_ENGINE_INITIAL = "";
		private string thisPTC_ENGINE_NUMBER = "";
		
		public string TCON_SEQUENCE_NUMBER {
			get { return this.thisTCON_SEQUENCE_NUMBER; }
			set { this.thisTCON_SEQUENCE_NUMBER = value; }
		}
	
		public string SCAC {
			get { return this.thisSCAC; }
			set { this.thisSCAC = value; }
		}

		public string SYMBOL {
			get { return this.thisSYMBOL; }
			set { this.thisSYMBOL = value; }
		}

		public string SECTION {
			get { return this.thisSECTION; }
			set { this.thisSECTION = value; }
		}
		
		public string STATUS_CODE {
			get { return this.thisSTATUS_CODE; }
			set { this.thisSTATUS_CODE = value; }
		}

		public string ORIGIN_DATE {
			get { return this.thisORIGIN_DATE; }
			set { this.thisORIGIN_DATE = value; }
		}

		public string PTC_ENGINE_INITIAL {
			get { return this.thisPTC_ENGINE_INITIAL; }
			set { this.thisPTC_ENGINE_INITIAL = value; }
		}

		public string PTC_ENGINE_NUMBER {
			get { return this.thisPTC_ENGINE_NUMBER; }
			set { this.thisPTC_ENGINE_NUMBER = value; }
		}

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
	public partial class CD_CODS_7 {
		private object[] itemsField;

		[System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(CD_CODSHEADER_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

		[System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(CD_CODSCONTENT_7), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


		public object[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADER_7 {
		private CD_CODSHEADERHEADER_EVENT_DATE_7[] HEADER_EVENT_DATEField;
		private CD_CODSHEADERHEADER_EVENT_TIME_7[] HEADER_EVENT_TIMEField;
		private CD_CODSHEADERHEADER_MESSAGE_ID_7[] HEADER_MESSAGE_IDField;
		private CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7[] HEADER_SEQUENCE_NUMBERField;
		private CD_CODSHEADERHEADER_MESSAGE_VERSION_7[] HEADER_MESSAGE_VERSIONField;
		private CD_CODSHEADERHEADER_MESSAGE_REVISION_7[] HEADER_MESSAGE_REVISIONField;
		private CD_CODSHEADERHEADER_SOURCE_SYS_7[] HEADER_SOURCE_SYSField;
		private CD_CODSHEADERHEADER_DESTINATION_SYS_7[] HEADER_DESTINATION_SYSField;
		private CD_CODSHEADERHEADER_DISTRICT_NAME_7[] HEADER_DISTRICT_NAMEField;
		private CD_CODSHEADERHEADER_DISTRICT_SCAC_7[] HEADER_DISTRICT_SCACField;
		private CD_CODSHEADERHEADER_USER_ID_7[] HEADER_USER_IDField;
		private CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7[] HEADER_TRACK_FILE_VERSIONField;
		private CD_CODSHEADERHEADER_HTRN_SCAC_7[] HEADER_HTRN_SCACField;
		private CD_CODSHEADERHEADER_HTRN_SYMBOL_7[] HEADER_HTRN_SYMBOLField;
		private CD_CODSHEADERHEADER_HTRN_SECTION_7[] HEADER_HTRN_SECTIONField;
		private CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7[] HEADER_HTRN_ORIGIN_DATEField;
		private CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7[] HEADER_HENG_ENGINE_INITIALField;
		private CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7[] HEADER_HENG_ENGINE_NUMBERField;


		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_EVENT_DATE_7[] HEADER_EVENT_DATE {
			get { return this.HEADER_EVENT_DATEField; }
			set { this.HEADER_EVENT_DATEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_EVENT_TIME_7[] HEADER_EVENT_TIME {
			get { return this.HEADER_EVENT_TIMEField; }
			set { this.HEADER_EVENT_TIMEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_MESSAGE_ID_7[] HEADER_MESSAGE_ID {
			get { return this.HEADER_MESSAGE_IDField; }
			set { this.HEADER_MESSAGE_IDField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7[] HEADER_SEQUENCE_NUMBER {
			get { return this.HEADER_SEQUENCE_NUMBERField; }
			set { this.HEADER_SEQUENCE_NUMBERField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_MESSAGE_VERSION_7[] HEADER_MESSAGE_VERSION {
			get { return this.HEADER_MESSAGE_VERSIONField; }
			set { this.HEADER_MESSAGE_VERSIONField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_MESSAGE_REVISION_7[] HEADER_MESSAGE_REVISION {
			get { return this.HEADER_MESSAGE_REVISIONField; }
			set { this.HEADER_MESSAGE_REVISIONField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_SOURCE_SYS_7[] HEADER_SOURCE_SYS {
			get { return this.HEADER_SOURCE_SYSField; }
			set { this.HEADER_SOURCE_SYSField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_DESTINATION_SYS_7[] HEADER_DESTINATION_SYS {
			get { return this.HEADER_DESTINATION_SYSField; }
			set { this.HEADER_DESTINATION_SYSField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_DISTRICT_NAME_7[] HEADER_DISTRICT_NAME {
			get { return this.HEADER_DISTRICT_NAMEField; }
			set { this.HEADER_DISTRICT_NAMEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_DISTRICT_SCAC_7[] HEADER_DISTRICT_SCAC {
			get { return this.HEADER_DISTRICT_SCACField; }
			set { this.HEADER_DISTRICT_SCACField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_USER_ID_7[] HEADER_USER_ID {
			get { return this.HEADER_USER_IDField; }
			set { this.HEADER_USER_IDField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_TRACK_FILE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7[] HEADER_TRACK_FILE_VERSION {
			get { return this.HEADER_TRACK_FILE_VERSIONField; }
			set { this.HEADER_TRACK_FILE_VERSIONField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HTRN_SCAC_7[] HEADER_HTRN_SCAC {
			get { return this.HEADER_HTRN_SCACField; }
			set { this.HEADER_HTRN_SCACField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HTRN_SYMBOL_7[] HEADER_HTRN_SYMBOL {
			get { return this.HEADER_HTRN_SYMBOLField; }
			set { this.HEADER_HTRN_SYMBOLField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HTRN_SECTION_7[] HEADER_HTRN_SECTION {
			get { return this.HEADER_HTRN_SECTIONField; }
			set { this.HEADER_HTRN_SECTIONField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HTRN_ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7[] HEADER_HTRN_ORIGIN_DATE {
			get { return this.HEADER_HTRN_ORIGIN_DATEField; }
			set { this.HEADER_HTRN_ORIGIN_DATEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7[] HEADER_HENG_ENGINE_INITIAL {
			get { return this.HEADER_HENG_ENGINE_INITIALField; }
			set { this.HEADER_HENG_ENGINE_INITIALField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("HEADER_HENG_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7[] HEADER_HENG_ENGINE_NUMBER {
			get { return this.HEADER_HENG_ENGINE_NUMBERField; }
			set { this.HEADER_HENG_ENGINE_NUMBERField = value; }
		}

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_EVENT_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_EVENT_TIME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_MESSAGE_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_MESSAGE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_MESSAGE_REVISION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_SOURCE_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_DESTINATION_SYS_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_DISTRICT_NAME_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_DISTRICT_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_USER_ID_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_TRACK_FILE_VERSION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HTRN_SCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HTRN_SYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HTRN_SECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HTRN_ORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}
	
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HENG_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSHEADERHEADER_HENG_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENT_7 {
		private CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7[] TCON_SEQUENCE_NUMBERField;
		private CD_CODSCONTENTSCAC_7[] SCACField;
		private CD_CODSCONTENTSYMBOL_7[] SYMBOLField;
		private CD_CODSCONTENTSECTION_7[] SECTIONField;
		private CD_CODSCONTENTSTATUS_CODE_7[] STATUS_CODEField;
		private CD_CODSCONTENTORIGIN_DATE_7[] ORIGIN_DATEField;
		private CD_CODSCONTENTPTC_ENGINE_INITIAL_7[] PTC_ENGINE_INITIALField;
		private CD_CODSCONTENTPTC_ENGINE_NUMBER_7[] PTC_ENGINE_NUMBERField;
		
		
		
		[System.Xml.Serialization.XmlElementAttribute("TCON_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7[] TCON_SEQUENCE_NUMBER {
			get { return this.TCON_SEQUENCE_NUMBERField; }
			set { this.TCON_SEQUENCE_NUMBERField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTSCAC_7[] SCAC {
			get { return this.SCACField; }
			set { this.SCACField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTSYMBOL_7[] SYMBOL {
			get { return this.SYMBOLField; }
			set { this.SYMBOLField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTSECTION_7[] SECTION {
			get { return this.SECTIONField; }
			set { this.SECTIONField = value; }
		}
		[System.Xml.Serialization.XmlElementAttribute("STATUS_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTSTATUS_CODE_7[] STATUS_CODE {
			get { return this.STATUS_CODEField; }
			set { this.STATUS_CODEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTORIGIN_DATE_7[] ORIGIN_DATE {
			get { return this.ORIGIN_DATEField; }
			set { this.ORIGIN_DATEField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTPTC_ENGINE_INITIAL_7[] PTC_ENGINE_INITIAL {
			get { return this.PTC_ENGINE_INITIALField; }
			set { this.PTC_ENGINE_INITIALField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("PTC_ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public CD_CODSCONTENTPTC_ENGINE_NUMBER_7[] PTC_ENGINE_NUMBER {
			get { return this.PTC_ENGINE_NUMBERField; }
			set { this.PTC_ENGINE_NUMBERField = value; }
		}

	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTTCON_SEQUENCE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTSCAC_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTSYMBOL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTSECTION_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}
	
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTSTATUS_CODE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CODSCONTENTORIGIN_DATE_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTPTC_ENGINE_INITIAL_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class CD_CODSCONTENTPTC_ENGINE_NUMBER_7 {
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {get; set;}
	}
	
}
