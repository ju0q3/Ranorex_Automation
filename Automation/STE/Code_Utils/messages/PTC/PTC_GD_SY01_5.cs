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
    public partial class PTC_GD_SY01_5 {
        private PTC_GD_SY01HEADER_5 thisHEADER;
        private PTC_GD_SY01CONTENT_5 thisCONTENT;

        public PTC_GD_SY01HEADER_5 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_GD_SY01CONTENT_5 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createGD_SY01_5(
            //string header_event_time, 
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
            string synch_req_type, 
            string district_version
        ) {
            PTC_GD_SY01_5 gD_SY01 = new PTC_GD_SY01_5();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";


            PTC_GD_SY01HEADER_5 header = new PTC_GD_SY01HEADER_5();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "GD-SY01";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "5";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "GD";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_GD_SY01CONTENT_5 content = new PTC_GD_SY01CONTENT_5();
            content.SYNCH_REQ_TYPE = synch_req_type;
            content.DISTRICT_VERSION = district_version;

            gD_SY01.HEADER = header;
            gD_SY01.CONTENT = content;

            GD_SY01_5 ptc_gd_sy01 = gD_SY01.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(GD_SY01_5));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, ptc_gd_sy01);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = gD_SY01.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createGD_SY01_5Msmq(
            //string header_event_time, 
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
            string synch_req_type, 
            string district_version
        ) {
            PTC_GD_SY01_5 gD_SY01 = new PTC_GD_SY01_5();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";


            PTC_GD_SY01HEADER_5 header = new PTC_GD_SY01HEADER_5();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "GD-SY01";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "5";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "GD";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_GD_SY01CONTENT_5 content = new PTC_GD_SY01CONTENT_5();
            content.SYNCH_REQ_TYPE = synch_req_type;
            content.DISTRICT_VERSION = district_version;

            gD_SY01.HEADER = header;
            gD_SY01.CONTENT = content;

            GD_SY01_5 ptc_gd_sy01 = gD_SY01.toSerializableObject();
            serializer = new XmlSerializer(typeof(PTC_GD_SY01_5));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, ptc_gd_sy01);
            request = gD_SY01.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "PTC_GD-SY01");
        }

        public GD_SY01_5 toSerializableObject() {
            GD_SY01_5 gd_sy01_5 = new GD_SY01_5();
            gd_sy01_5.Items = new object[2];

            GD_SY01HEADER_5 header = new GD_SY01HEADER_5();
            if (this.HEADER != null) {
                if (this.HEADER.HEADER_EVENT_DATE != null) {
                    header.HEADER_EVENT_DATE = new GD_SY01HEADERHEADER_EVENT_DATE_5[1];
                    GD_SY01HEADERHEADER_EVENT_DATE_5 header_event_date = new GD_SY01HEADERHEADER_EVENT_DATE_5();
                    header_event_date.Value = this.HEADER.HEADER_EVENT_DATE;
                    header.HEADER_EVENT_DATE[0] = header_event_date;
                }

                if (this.HEADER.HEADER_EVENT_TIME != null) {
                    header.HEADER_EVENT_TIME = new GD_SY01HEADERHEADER_EVENT_TIME_5[1];
                    GD_SY01HEADERHEADER_EVENT_TIME_5 header_event_time = new GD_SY01HEADERHEADER_EVENT_TIME_5();
                    header_event_time.Value = this.HEADER.HEADER_EVENT_TIME;
                    header.HEADER_EVENT_TIME[0] = header_event_time;
                }

                if (this.HEADER.HEADER_MESSAGE_ID != null) {
                    header.HEADER_MESSAGE_ID = new GD_SY01HEADERHEADER_MESSAGE_ID_5[1];
                    GD_SY01HEADERHEADER_MESSAGE_ID_5 header_message_id = new GD_SY01HEADERHEADER_MESSAGE_ID_5();
                    header_message_id.Value = this.HEADER.HEADER_MESSAGE_ID;
                    header.HEADER_MESSAGE_ID[0] = header_message_id;
                }

                if (this.HEADER.HEADER_SEQUENCE_NUMBER != null) {
                    header.HEADER_SEQUENCE_NUMBER = new GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5[1];
                    GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5 header_sequence_number = new GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5();
                    header_sequence_number.Value = this.HEADER.HEADER_SEQUENCE_NUMBER;
                    header.HEADER_SEQUENCE_NUMBER[0] = header_sequence_number;
                }

                if (this.HEADER.HEADER_MESSAGE_VERSION != null) {
                    header.HEADER_MESSAGE_VERSION = new GD_SY01HEADERHEADER_MESSAGE_VERSION_5[1];
                    GD_SY01HEADERHEADER_MESSAGE_VERSION_5 header_message_version = new GD_SY01HEADERHEADER_MESSAGE_VERSION_5();
                    header_message_version.Value = this.HEADER.HEADER_MESSAGE_VERSION;
                    header.HEADER_MESSAGE_VERSION[0] = header_message_version;
                }

                if (this.HEADER.HEADER_MESSAGE_REVISION != null) {
                    header.HEADER_MESSAGE_REVISION = new GD_SY01HEADERHEADER_MESSAGE_REVISION_5[1];
                    GD_SY01HEADERHEADER_MESSAGE_REVISION_5 header_message_revision = new GD_SY01HEADERHEADER_MESSAGE_REVISION_5();
                    header_message_revision.Value = this.HEADER.HEADER_MESSAGE_REVISION;
                    header.HEADER_MESSAGE_REVISION[0] = header_message_revision;
                }

                if (this.HEADER.HEADER_SOURCE_SYS != null) {
                    header.HEADER_SOURCE_SYS = new GD_SY01HEADERHEADER_SOURCE_SYS_5[1];
                    GD_SY01HEADERHEADER_SOURCE_SYS_5 header_source_sys = new GD_SY01HEADERHEADER_SOURCE_SYS_5();
                    header_source_sys.Value = this.HEADER.HEADER_SOURCE_SYS;
                    header.HEADER_SOURCE_SYS[0] = header_source_sys;
                }

                if (this.HEADER.HEADER_DESTINATION_SYS != null) {
                    header.HEADER_DESTINATION_SYS = new GD_SY01HEADERHEADER_DESTINATION_SYS_5[1];
                    GD_SY01HEADERHEADER_DESTINATION_SYS_5 header_destination_sys = new GD_SY01HEADERHEADER_DESTINATION_SYS_5();
                    header_destination_sys.Value = this.HEADER.HEADER_DESTINATION_SYS;
                    header.HEADER_DESTINATION_SYS[0] = header_destination_sys;
                }

                if (this.HEADER.HEADER_DISTRICT_NAME != null) {
                    header.HEADER_DISTRICT_NAME = new GD_SY01HEADERHEADER_DISTRICT_NAME_5[1];
                    GD_SY01HEADERHEADER_DISTRICT_NAME_5 header_district_name = new GD_SY01HEADERHEADER_DISTRICT_NAME_5();
                    header_district_name.Value = this.HEADER.HEADER_DISTRICT_NAME;
                    header.HEADER_DISTRICT_NAME[0] = header_district_name;
                }

                if (this.HEADER.HEADER_DISTRICT_SCAC != null) {
                    header.HEADER_DISTRICT_SCAC = new GD_SY01HEADERHEADER_DISTRICT_SCAC_5[1];
                    GD_SY01HEADERHEADER_DISTRICT_SCAC_5 header_district_scac = new GD_SY01HEADERHEADER_DISTRICT_SCAC_5();
                    header_district_scac.Value = this.HEADER.HEADER_DISTRICT_SCAC;
                    header.HEADER_DISTRICT_SCAC[0] = header_district_scac;
                }

                if (this.HEADER.HEADER_USER_ID != null) {
                    header.HEADER_USER_ID = new GD_SY01HEADERHEADER_USER_ID_5[1];
                    GD_SY01HEADERHEADER_USER_ID_5 header_user_id = new GD_SY01HEADERHEADER_USER_ID_5();
                    header_user_id.Value = this.HEADER.HEADER_USER_ID;
                    header.HEADER_USER_ID[0] = header_user_id;
                }

            }

            GD_SY01CONTENT_5 content = new GD_SY01CONTENT_5();
            if (this.CONTENT != null) {
                if (this.CONTENT.SYNCH_REQ_TYPE != null) {
                    content.SYNCH_REQ_TYPE = new GD_SY01CONTENTSYNCH_REQ_TYPE_5[1];
                    GD_SY01CONTENTSYNCH_REQ_TYPE_5 synch_req_type = new GD_SY01CONTENTSYNCH_REQ_TYPE_5();
                    synch_req_type.Value = this.CONTENT.SYNCH_REQ_TYPE;
                    content.SYNCH_REQ_TYPE[0] = synch_req_type;
                }

                if (this.CONTENT.DISTRICT_VERSION != null) {
                    content.DISTRICT_VERSION = new GD_SY01CONTENTDISTRICT_VERSION_5[1];
                    GD_SY01CONTENTDISTRICT_VERSION_5 district_version = new GD_SY01CONTENTDISTRICT_VERSION_5();
                    district_version.Value = this.CONTENT.DISTRICT_VERSION;
                    content.DISTRICT_VERSION[0] = district_version;
                }

            }

            gd_sy01_5.Items[0] = header;
            gd_sy01_5.Items[1] = content;
            return gd_sy01_5;
        }

        public string toSteMessageHeader(string serializedXml) {
            int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
            int headerTo   = serializedXml.LastIndexOf("</HEADER>");
            int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
            int contentTo   = serializedXml.LastIndexOf("</CONTENT>");
            string header = "PASSTHRUOTC|GD-SY01|";
            string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
            return result;
        }

    }

    public partial class PTC_GD_SY01HEADER_5 {
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

    public partial class PTC_GD_SY01CONTENT_5 {
        private string thisSYNCH_REQ_TYPE = "";
        private string thisDISTRICT_VERSION = "";

        public string SYNCH_REQ_TYPE {
            get { return this.thisSYNCH_REQ_TYPE; }
            set { this.thisSYNCH_REQ_TYPE = value; }
        }

        public string DISTRICT_VERSION {
            get { return this.thisDISTRICT_VERSION; }
            set { this.thisDISTRICT_VERSION = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GD_SY01_5 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(GD_SY01HEADER_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(GD_SY01CONTENT_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class GD_SY01HEADER_5 {
        private GD_SY01HEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATEField;
        private GD_SY01HEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIMEField;
        private GD_SY01HEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_IDField;
        private GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBERField;
        private GD_SY01HEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSIONField;
        private GD_SY01HEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISIONField;
        private GD_SY01HEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYSField;
        private GD_SY01HEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYSField;
        private GD_SY01HEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAMEField;
        private GD_SY01HEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCACField;
        private GD_SY01HEADERHEADER_USER_ID_5[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01HEADERHEADER_USER_ID_5[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_EVENT_DATE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_EVENT_TIME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_MESSAGE_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_SEQUENCE_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_MESSAGE_VERSION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_MESSAGE_REVISION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_SOURCE_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_DESTINATION_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_DISTRICT_NAME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_DISTRICT_SCAC_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01HEADERHEADER_USER_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01CONTENT_5 {
        private GD_SY01CONTENTSYNCH_REQ_TYPE_5[] SYNCH_REQ_TYPEField;
        private GD_SY01CONTENTDISTRICT_VERSION_5[] DISTRICT_VERSIONField;

        [System.Xml.Serialization.XmlElementAttribute("SYNCH_REQ_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01CONTENTSYNCH_REQ_TYPE_5[] SYNCH_REQ_TYPE {
            get { return this.SYNCH_REQ_TYPEField; }
            set { this.SYNCH_REQ_TYPEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("DISTRICT_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_SY01CONTENTDISTRICT_VERSION_5[] DISTRICT_VERSION {
            get { return this.DISTRICT_VERSIONField; }
            set { this.DISTRICT_VERSIONField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01CONTENTSYNCH_REQ_TYPE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_SY01CONTENTDISTRICT_VERSION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}