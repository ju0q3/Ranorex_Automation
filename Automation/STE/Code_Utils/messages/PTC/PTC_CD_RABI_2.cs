//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a buildPTCMessages.py.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.messages;
using STE.Code_Utils.MessageQueues;

namespace STE.Code_Utils.messages.PTC
{
    public partial class PTC_CD_RABI_2 {
        private PTC_CD_RABIHEADER_2 thisHEADER;
        private PTC_CD_RABICONTENT_2 thisCONTENT;

        public PTC_CD_RABIHEADER_2 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_CD_RABICONTENT_2 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createCD_RABI_2(
            //string header_event_date, 
            //string header_event_time, 
            //string header_message_id, 
            //string header_sequence_number, 
            //string header_message_version, 
            //string header_message_revision, 
            //string header_source_sys, 
            //string header_destination_sys,  
            string header_district_name, 
            string header_district_scac, 
            string header_user_id, 
            string scac, 
            string symbol, 
            string section, 
            //string origin_date, 
            string train_clearance_number, 
            string engine_initial, 
            string engine_number, 
            string request_type
        ) {
            PTC_CD_RABI_2 cD_RABI = new PTC_CD_RABI_2();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";


            PTC_CD_RABIHEADER_2 header = new PTC_CD_RABIHEADER_2();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "CD-RABI";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "2";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "CI";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_CD_RABICONTENT_2 content = new PTC_CD_RABICONTENT_2();
            content.SCAC = scac;
            content.SYMBOL = symbol;
            content.SECTION = section;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.TRAIN_CLEARANCE_NUMBER = train_clearance_number;
            content.ENGINE_INITIAL = engine_initial;
            content.ENGINE_NUMBER = engine_number;
            content.REQUEST_TYPE = request_type;

            cD_RABI.HEADER = header;
            cD_RABI.CONTENT = content;

            CD_RABI_2 ptc_cd_rabi = cD_RABI.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(CD_RABI_2));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, ptc_cd_rabi);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = cD_RABI.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createCD_RABI_2Msmq(
            //string header_event_date, 
            //string header_event_time, 
            //string header_message_id, 
            //string header_sequence_number, 
            //string header_message_version, 
            //string header_message_revision, 
            //string header_source_sys, 
            //string header_destination_sys,  
            string header_district_name, 
            string header_district_scac, 
            string header_user_id, 
            string scac, 
            string symbol, 
            string section, 
            //string origin_date, 
            string train_clearance_number, 
            string engine_initial, 
            string engine_number, 
            string request_type
        ) {
            PTC_CD_RABI_2 cD_RABI = new PTC_CD_RABI_2();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";


            PTC_CD_RABIHEADER_2 header = new PTC_CD_RABIHEADER_2();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "CD-RABI";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "2";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "CI";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_CD_RABICONTENT_2 content = new PTC_CD_RABICONTENT_2();
            content.SCAC = scac;
            content.SYMBOL = symbol;
            content.SECTION = section;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.TRAIN_CLEARANCE_NUMBER = train_clearance_number;
            content.ENGINE_INITIAL = engine_initial;
            content.ENGINE_NUMBER = engine_number;
            content.REQUEST_TYPE = request_type;

            cD_RABI.HEADER = header;
            cD_RABI.CONTENT = content;

            CD_RABI_2 ptc_cd_rabi = cD_RABI.toSerializableObject();
            serializer = new XmlSerializer(typeof(PTC_CD_RABI_2));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, ptc_cd_rabi);
            request = cD_RABI.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "PTC_CD-RABI");
        }

        public CD_RABI_2 toSerializableObject() {
            CD_RABI_2 cd_rabi_2 = new CD_RABI_2();
            cd_rabi_2.Items = new object[2];

            CD_RABIHEADER_2 header = new CD_RABIHEADER_2();
            if (this.HEADER != null) {
                if (this.HEADER.HEADER_EVENT_DATE != null) {
                    header.HEADER_EVENT_DATE = new CD_RABIHEADERHEADER_EVENT_DATE_2[1];
                    CD_RABIHEADERHEADER_EVENT_DATE_2 header_event_date = new CD_RABIHEADERHEADER_EVENT_DATE_2();
                    header_event_date.Value = this.HEADER.HEADER_EVENT_DATE;
                    header.HEADER_EVENT_DATE[0] = header_event_date;
                }

                if (this.HEADER.HEADER_EVENT_TIME != null) {
                    header.HEADER_EVENT_TIME = new CD_RABIHEADERHEADER_EVENT_TIME_2[1];
                    CD_RABIHEADERHEADER_EVENT_TIME_2 header_event_time = new CD_RABIHEADERHEADER_EVENT_TIME_2();
                    header_event_time.Value = this.HEADER.HEADER_EVENT_TIME;
                    header.HEADER_EVENT_TIME[0] = header_event_time;
                }

                if (this.HEADER.HEADER_MESSAGE_ID != null) {
                    header.HEADER_MESSAGE_ID = new CD_RABIHEADERHEADER_MESSAGE_ID_2[1];
                    CD_RABIHEADERHEADER_MESSAGE_ID_2 header_message_id = new CD_RABIHEADERHEADER_MESSAGE_ID_2();
                    header_message_id.Value = this.HEADER.HEADER_MESSAGE_ID;
                    header.HEADER_MESSAGE_ID[0] = header_message_id;
                }

                if (this.HEADER.HEADER_SEQUENCE_NUMBER != null) {
                    header.HEADER_SEQUENCE_NUMBER = new CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2[1];
                    CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2 header_sequence_number = new CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2();
                    header_sequence_number.Value = this.HEADER.HEADER_SEQUENCE_NUMBER;
                    header.HEADER_SEQUENCE_NUMBER[0] = header_sequence_number;
                }

                if (this.HEADER.HEADER_MESSAGE_VERSION != null) {
                    header.HEADER_MESSAGE_VERSION = new CD_RABIHEADERHEADER_MESSAGE_VERSION_2[1];
                    CD_RABIHEADERHEADER_MESSAGE_VERSION_2 header_message_version = new CD_RABIHEADERHEADER_MESSAGE_VERSION_2();
                    header_message_version.Value = this.HEADER.HEADER_MESSAGE_VERSION;
                    header.HEADER_MESSAGE_VERSION[0] = header_message_version;
                }

                if (this.HEADER.HEADER_MESSAGE_REVISION != null) {
                    header.HEADER_MESSAGE_REVISION = new CD_RABIHEADERHEADER_MESSAGE_REVISION_2[1];
                    CD_RABIHEADERHEADER_MESSAGE_REVISION_2 header_message_revision = new CD_RABIHEADERHEADER_MESSAGE_REVISION_2();
                    header_message_revision.Value = this.HEADER.HEADER_MESSAGE_REVISION;
                    header.HEADER_MESSAGE_REVISION[0] = header_message_revision;
                }

                if (this.HEADER.HEADER_SOURCE_SYS != null) {
                    header.HEADER_SOURCE_SYS = new CD_RABIHEADERHEADER_SOURCE_SYS_2[1];
                    CD_RABIHEADERHEADER_SOURCE_SYS_2 header_source_sys = new CD_RABIHEADERHEADER_SOURCE_SYS_2();
                    header_source_sys.Value = this.HEADER.HEADER_SOURCE_SYS;
                    header.HEADER_SOURCE_SYS[0] = header_source_sys;
                }

                if (this.HEADER.HEADER_DESTINATION_SYS != null) {
                    header.HEADER_DESTINATION_SYS = new CD_RABIHEADERHEADER_DESTINATION_SYS_2[1];
                    CD_RABIHEADERHEADER_DESTINATION_SYS_2 header_destination_sys = new CD_RABIHEADERHEADER_DESTINATION_SYS_2();
                    header_destination_sys.Value = this.HEADER.HEADER_DESTINATION_SYS;
                    header.HEADER_DESTINATION_SYS[0] = header_destination_sys;
                }

                if (this.HEADER.HEADER_DISTRICT_NAME != null) {
                    header.HEADER_DISTRICT_NAME = new CD_RABIHEADERHEADER_DISTRICT_NAME_2[1];
                    CD_RABIHEADERHEADER_DISTRICT_NAME_2 header_district_name = new CD_RABIHEADERHEADER_DISTRICT_NAME_2();
                    header_district_name.Value = this.HEADER.HEADER_DISTRICT_NAME;
                    header.HEADER_DISTRICT_NAME[0] = header_district_name;
                }

                if (this.HEADER.HEADER_DISTRICT_SCAC != null) {
                    header.HEADER_DISTRICT_SCAC = new CD_RABIHEADERHEADER_DISTRICT_SCAC_2[1];
                    CD_RABIHEADERHEADER_DISTRICT_SCAC_2 header_district_scac = new CD_RABIHEADERHEADER_DISTRICT_SCAC_2();
                    header_district_scac.Value = this.HEADER.HEADER_DISTRICT_SCAC;
                    header.HEADER_DISTRICT_SCAC[0] = header_district_scac;
                }

                if (this.HEADER.HEADER_USER_ID != null) {
                    header.HEADER_USER_ID = new CD_RABIHEADERHEADER_USER_ID_2[1];
                    CD_RABIHEADERHEADER_USER_ID_2 header_user_id = new CD_RABIHEADERHEADER_USER_ID_2();
                    header_user_id.Value = this.HEADER.HEADER_USER_ID;
                    header.HEADER_USER_ID[0] = header_user_id;
                }

            }

            CD_RABICONTENT_2 content = new CD_RABICONTENT_2();
            if (this.CONTENT != null) {
                if (this.CONTENT.SCAC != null) {
                    content.SCAC = new CD_RABICONTENTSCAC_2[1];
                    CD_RABICONTENTSCAC_2 scac = new CD_RABICONTENTSCAC_2();
                    scac.Value = this.CONTENT.SCAC;
                    content.SCAC[0] = scac;
                }

                if (this.CONTENT.SYMBOL != null) {
                    content.SYMBOL = new CD_RABICONTENTSYMBOL_2[1];
                    CD_RABICONTENTSYMBOL_2 symbol = new CD_RABICONTENTSYMBOL_2();
                    symbol.Value = this.CONTENT.SYMBOL;
                    content.SYMBOL[0] = symbol;
                }

                if (this.CONTENT.SECTION != null) {
                    content.SECTION = new CD_RABICONTENTSECTION_2[1];
                    CD_RABICONTENTSECTION_2 section = new CD_RABICONTENTSECTION_2();
                    section.Value = this.CONTENT.SECTION;
                    content.SECTION[0] = section;
                }

                if (this.CONTENT.ORIGIN_DATE != null) {
                    content.ORIGIN_DATE = new CD_RABICONTENTORIGIN_DATE_2[1];
                    CD_RABICONTENTORIGIN_DATE_2 origin_date = new CD_RABICONTENTORIGIN_DATE_2();
                    origin_date.Value = this.CONTENT.ORIGIN_DATE;
                    content.ORIGIN_DATE[0] = origin_date;
                }

                if (this.CONTENT.TRAIN_CLEARANCE_NUMBER != null) {
                    content.TRAIN_CLEARANCE_NUMBER = new CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2[1];
                    CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2 train_clearance_number = new CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2();
                    train_clearance_number.Value = this.CONTENT.TRAIN_CLEARANCE_NUMBER;
                    content.TRAIN_CLEARANCE_NUMBER[0] = train_clearance_number;
                }

                if (this.CONTENT.ENGINE_INITIAL != null) {
                    content.ENGINE_INITIAL = new CD_RABICONTENTENGINE_INITIAL_2[1];
                    CD_RABICONTENTENGINE_INITIAL_2 engine_initial = new CD_RABICONTENTENGINE_INITIAL_2();
                    engine_initial.Value = this.CONTENT.ENGINE_INITIAL;
                    content.ENGINE_INITIAL[0] = engine_initial;
                }

                if (this.CONTENT.ENGINE_NUMBER != null) {
                    content.ENGINE_NUMBER = new CD_RABICONTENTENGINE_NUMBER_2[1];
                    CD_RABICONTENTENGINE_NUMBER_2 engine_number = new CD_RABICONTENTENGINE_NUMBER_2();
                    engine_number.Value = this.CONTENT.ENGINE_NUMBER;
                    content.ENGINE_NUMBER[0] = engine_number;
                }

                if (this.CONTENT.REQUEST_TYPE != null) {
                    content.REQUEST_TYPE = new CD_RABICONTENTREQUEST_TYPE_2[1];
                    CD_RABICONTENTREQUEST_TYPE_2 request_type = new CD_RABICONTENTREQUEST_TYPE_2();
                    request_type.Value = this.CONTENT.REQUEST_TYPE;
                    content.REQUEST_TYPE[0] = request_type;
                }

            }

            cd_rabi_2.Items[0] = header;
            cd_rabi_2.Items[1] = content;
            return cd_rabi_2;
        }

        public string toSteMessageHeader(string serializedXml) {
            int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
            int headerTo   = serializedXml.LastIndexOf("</HEADER>");
            int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
            int contentTo   = serializedXml.LastIndexOf("</CONTENT>");
            string header = "PASSTHRUOTC|CD-RABI|";
            string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
            return result;
        }

    }

    public partial class PTC_CD_RABIHEADER_2 {
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

    }

    public partial class PTC_CD_RABICONTENT_2 {
        private string thisSCAC = "";
        private string thisSYMBOL = "";
        private string thisSECTION = "";
        private string thisORIGIN_DATE = "";
        private string thisTRAIN_CLEARANCE_NUMBER = "";
        private string thisENGINE_INITIAL = "";
        private string thisENGINE_NUMBER = "";
        private string thisREQUEST_TYPE = "";

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

        public string ORIGIN_DATE {
            get { return this.thisORIGIN_DATE; }
            set { this.thisORIGIN_DATE = value; }
        }

        public string TRAIN_CLEARANCE_NUMBER {
            get { return this.thisTRAIN_CLEARANCE_NUMBER; }
            set { this.thisTRAIN_CLEARANCE_NUMBER = value; }
        }

        public string ENGINE_INITIAL {
            get { return this.thisENGINE_INITIAL; }
            set { this.thisENGINE_INITIAL = value; }
        }

        public string ENGINE_NUMBER {
            get { return this.thisENGINE_NUMBER; }
            set { this.thisENGINE_NUMBER = value; }
        }

        public string REQUEST_TYPE {
            get { return this.thisREQUEST_TYPE; }
            set { this.thisREQUEST_TYPE = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class CD_RABI_2 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(CD_RABIHEADER_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(CD_RABICONTENT_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class CD_RABIHEADER_2 {
        private CD_RABIHEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATEField;
        private CD_RABIHEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIMEField;
        private CD_RABIHEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_IDField;
        private CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBERField;
        private CD_RABIHEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSIONField;
        private CD_RABIHEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISIONField;
        private CD_RABIHEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYSField;
        private CD_RABIHEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYSField;
        private CD_RABIHEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAMEField;
        private CD_RABIHEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCACField;
        private CD_RABIHEADERHEADER_USER_ID_2[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABIHEADERHEADER_USER_ID_2[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_EVENT_DATE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_EVENT_TIME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_MESSAGE_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_SEQUENCE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_MESSAGE_VERSION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_MESSAGE_REVISION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_SOURCE_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_DESTINATION_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_DISTRICT_NAME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_DISTRICT_SCAC_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABIHEADERHEADER_USER_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENT_2 {
        private CD_RABICONTENTSCAC_2[] SCACField;
        private CD_RABICONTENTSYMBOL_2[] SYMBOLField;
        private CD_RABICONTENTSECTION_2[] SECTIONField;
        private CD_RABICONTENTORIGIN_DATE_2[] ORIGIN_DATEField;
        private CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2[] TRAIN_CLEARANCE_NUMBERField;
        private CD_RABICONTENTENGINE_INITIAL_2[] ENGINE_INITIALField;
        private CD_RABICONTENTENGINE_NUMBER_2[] ENGINE_NUMBERField;
        private CD_RABICONTENTREQUEST_TYPE_2[] REQUEST_TYPEField;

        [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTSCAC_2[] SCAC {
            get { return this.SCACField; }
            set { this.SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTSYMBOL_2[] SYMBOL {
            get { return this.SYMBOLField; }
            set { this.SYMBOLField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTSECTION_2[] SECTION {
            get { return this.SECTIONField; }
            set { this.SECTIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTORIGIN_DATE_2[] ORIGIN_DATE {
            get { return this.ORIGIN_DATEField; }
            set { this.ORIGIN_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("TRAIN_CLEARANCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2[] TRAIN_CLEARANCE_NUMBER {
            get { return this.TRAIN_CLEARANCE_NUMBERField; }
            set { this.TRAIN_CLEARANCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTENGINE_INITIAL_2[] ENGINE_INITIAL {
            get { return this.ENGINE_INITIALField; }
            set { this.ENGINE_INITIALField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTENGINE_NUMBER_2[] ENGINE_NUMBER {
            get { return this.ENGINE_NUMBERField; }
            set { this.ENGINE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("REQUEST_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CD_RABICONTENTREQUEST_TYPE_2[] REQUEST_TYPE {
            get { return this.REQUEST_TYPEField; }
            set { this.REQUEST_TYPEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTSCAC_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTSYMBOL_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTSECTION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTORIGIN_DATE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTTRAIN_CLEARANCE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTENGINE_INITIAL_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTENGINE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class CD_RABICONTENTREQUEST_TYPE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}