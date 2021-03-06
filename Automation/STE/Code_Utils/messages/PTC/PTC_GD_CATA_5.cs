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
    public partial class PTC_GD_CATA_5 {
        private PTC_GD_CATAHEADER_5 thisHEADER;
        private PTC_GD_CATACONTENT_5 thisCONTENT;

        public PTC_GD_CATAHEADER_5 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_GD_CATACONTENT_5 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createGD_CATA_5(
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
            string track_authority_number, 
            string action, 
            string employee_first, 
            string employee_middle, 
            string employee_last
        ) {
            PTC_GD_CATA_5 gD_CATA = new PTC_GD_CATA_5();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";


            PTC_GD_CATAHEADER_5 header = new PTC_GD_CATAHEADER_5();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "GD-CATA";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "5";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "GD";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_GD_CATACONTENT_5 content = new PTC_GD_CATACONTENT_5();
            content.TRACK_AUTHORITY_NUMBER = track_authority_number;
            content.ACTION = action;
            content.EMPLOYEE_FIRST = employee_first;
            content.EMPLOYEE_MIDDLE = employee_middle;
            content.EMPLOYEE_LAST = employee_last;

            gD_CATA.HEADER = header;
            gD_CATA.CONTENT = content;

            GD_CATA_5 ptc_gd_cata = gD_CATA.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(GD_CATA_5));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, ptc_gd_cata);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = gD_CATA.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createGD_CATA_5Msmq(
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
            string track_authority_number, 
            string action, 
            string employee_first, 
            string employee_middle, 
            string employee_last
        ) {
            PTC_GD_CATA_5 gD_CATA = new PTC_GD_CATA_5();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";


            PTC_GD_CATAHEADER_5 header = new PTC_GD_CATAHEADER_5();
            header.HEADER_EVENT_DATE = now.ToString("MMddyyyy");
            header.HEADER_EVENT_TIME = now.ToString("HHmm");
            header.HEADER_MESSAGE_ID = "GD-CATA";
            header.HEADER_SEQUENCE_NUMBER = "1";
            header.HEADER_MESSAGE_VERSION = "5";
            header.HEADER_MESSAGE_REVISION = "0";
            header.HEADER_SOURCE_SYS = "GD";
            header.HEADER_DESTINATION_SYS = "CAD";
            header.HEADER_DISTRICT_NAME = header_district_name;
            header.HEADER_DISTRICT_SCAC = header_district_scac;
            header.HEADER_USER_ID = header_user_id;

            PTC_GD_CATACONTENT_5 content = new PTC_GD_CATACONTENT_5();
            content.TRACK_AUTHORITY_NUMBER = track_authority_number;
            content.ACTION = action;
            content.EMPLOYEE_FIRST = employee_first;
            content.EMPLOYEE_MIDDLE = employee_middle;
            content.EMPLOYEE_LAST = employee_last;

            gD_CATA.HEADER = header;
            gD_CATA.CONTENT = content;

            GD_CATA_5 ptc_gd_cata = gD_CATA.toSerializableObject();
            serializer = new XmlSerializer(typeof(PTC_GD_CATA_5));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, ptc_gd_cata);
            request = gD_CATA.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "PTC_GD-CATA");
        }

        public GD_CATA_5 toSerializableObject() {
            GD_CATA_5 gd_cata_5 = new GD_CATA_5();
            gd_cata_5.Items = new object[2];

            GD_CATAHEADER_5 header = new GD_CATAHEADER_5();
            if (this.HEADER != null) {
                if (this.HEADER.HEADER_EVENT_DATE != null) {
                    header.HEADER_EVENT_DATE = new GD_CATAHEADERHEADER_EVENT_DATE_5[1];
                    GD_CATAHEADERHEADER_EVENT_DATE_5 header_event_date = new GD_CATAHEADERHEADER_EVENT_DATE_5();
                    header_event_date.Value = this.HEADER.HEADER_EVENT_DATE;
                    header.HEADER_EVENT_DATE[0] = header_event_date;
                }

                if (this.HEADER.HEADER_EVENT_TIME != null) {
                    header.HEADER_EVENT_TIME = new GD_CATAHEADERHEADER_EVENT_TIME_5[1];
                    GD_CATAHEADERHEADER_EVENT_TIME_5 header_event_time = new GD_CATAHEADERHEADER_EVENT_TIME_5();
                    header_event_time.Value = this.HEADER.HEADER_EVENT_TIME;
                    header.HEADER_EVENT_TIME[0] = header_event_time;
                }

                if (this.HEADER.HEADER_MESSAGE_ID != null) {
                    header.HEADER_MESSAGE_ID = new GD_CATAHEADERHEADER_MESSAGE_ID_5[1];
                    GD_CATAHEADERHEADER_MESSAGE_ID_5 header_message_id = new GD_CATAHEADERHEADER_MESSAGE_ID_5();
                    header_message_id.Value = this.HEADER.HEADER_MESSAGE_ID;
                    header.HEADER_MESSAGE_ID[0] = header_message_id;
                }

                if (this.HEADER.HEADER_SEQUENCE_NUMBER != null) {
                    header.HEADER_SEQUENCE_NUMBER = new GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5[1];
                    GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5 header_sequence_number = new GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5();
                    header_sequence_number.Value = this.HEADER.HEADER_SEQUENCE_NUMBER;
                    header.HEADER_SEQUENCE_NUMBER[0] = header_sequence_number;
                }

                if (this.HEADER.HEADER_MESSAGE_VERSION != null) {
                    header.HEADER_MESSAGE_VERSION = new GD_CATAHEADERHEADER_MESSAGE_VERSION_5[1];
                    GD_CATAHEADERHEADER_MESSAGE_VERSION_5 header_message_version = new GD_CATAHEADERHEADER_MESSAGE_VERSION_5();
                    header_message_version.Value = this.HEADER.HEADER_MESSAGE_VERSION;
                    header.HEADER_MESSAGE_VERSION[0] = header_message_version;
                }

                if (this.HEADER.HEADER_MESSAGE_REVISION != null) {
                    header.HEADER_MESSAGE_REVISION = new GD_CATAHEADERHEADER_MESSAGE_REVISION_5[1];
                    GD_CATAHEADERHEADER_MESSAGE_REVISION_5 header_message_revision = new GD_CATAHEADERHEADER_MESSAGE_REVISION_5();
                    header_message_revision.Value = this.HEADER.HEADER_MESSAGE_REVISION;
                    header.HEADER_MESSAGE_REVISION[0] = header_message_revision;
                }

                if (this.HEADER.HEADER_SOURCE_SYS != null) {
                    header.HEADER_SOURCE_SYS = new GD_CATAHEADERHEADER_SOURCE_SYS_5[1];
                    GD_CATAHEADERHEADER_SOURCE_SYS_5 header_source_sys = new GD_CATAHEADERHEADER_SOURCE_SYS_5();
                    header_source_sys.Value = this.HEADER.HEADER_SOURCE_SYS;
                    header.HEADER_SOURCE_SYS[0] = header_source_sys;
                }

                if (this.HEADER.HEADER_DESTINATION_SYS != null) {
                    header.HEADER_DESTINATION_SYS = new GD_CATAHEADERHEADER_DESTINATION_SYS_5[1];
                    GD_CATAHEADERHEADER_DESTINATION_SYS_5 header_destination_sys = new GD_CATAHEADERHEADER_DESTINATION_SYS_5();
                    header_destination_sys.Value = this.HEADER.HEADER_DESTINATION_SYS;
                    header.HEADER_DESTINATION_SYS[0] = header_destination_sys;
                }

                if (this.HEADER.HEADER_DISTRICT_NAME != null) {
                    header.HEADER_DISTRICT_NAME = new GD_CATAHEADERHEADER_DISTRICT_NAME_5[1];
                    GD_CATAHEADERHEADER_DISTRICT_NAME_5 header_district_name = new GD_CATAHEADERHEADER_DISTRICT_NAME_5();
                    header_district_name.Value = this.HEADER.HEADER_DISTRICT_NAME;
                    header.HEADER_DISTRICT_NAME[0] = header_district_name;
                }

                if (this.HEADER.HEADER_DISTRICT_SCAC != null) {
                    header.HEADER_DISTRICT_SCAC = new GD_CATAHEADERHEADER_DISTRICT_SCAC_5[1];
                    GD_CATAHEADERHEADER_DISTRICT_SCAC_5 header_district_scac = new GD_CATAHEADERHEADER_DISTRICT_SCAC_5();
                    header_district_scac.Value = this.HEADER.HEADER_DISTRICT_SCAC;
                    header.HEADER_DISTRICT_SCAC[0] = header_district_scac;
                }

                if (this.HEADER.HEADER_USER_ID != null) {
                    header.HEADER_USER_ID = new GD_CATAHEADERHEADER_USER_ID_5[1];
                    GD_CATAHEADERHEADER_USER_ID_5 header_user_id = new GD_CATAHEADERHEADER_USER_ID_5();
                    header_user_id.Value = this.HEADER.HEADER_USER_ID;
                    header.HEADER_USER_ID[0] = header_user_id;
                }

            }

            GD_CATACONTENT_5 content = new GD_CATACONTENT_5();
            if (this.CONTENT != null) {
                if (this.CONTENT.TRACK_AUTHORITY_NUMBER != null) {
                    content.TRACK_AUTHORITY_NUMBER = new GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5[1];
                    GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5 track_authority_number = new GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5();
                    track_authority_number.Value = this.CONTENT.TRACK_AUTHORITY_NUMBER;
                    content.TRACK_AUTHORITY_NUMBER[0] = track_authority_number;
                }

                if (this.CONTENT.ACTION != null) {
                    content.ACTION = new GD_CATACONTENTACTION_5[1];
                    GD_CATACONTENTACTION_5 action = new GD_CATACONTENTACTION_5();
                    action.Value = this.CONTENT.ACTION;
                    content.ACTION[0] = action;
                }

                if (this.CONTENT.EMPLOYEE_FIRST != null) {
                    content.EMPLOYEE_FIRST = new GD_CATACONTENTEMPLOYEE_FIRST_5[1];
                    GD_CATACONTENTEMPLOYEE_FIRST_5 employee_first = new GD_CATACONTENTEMPLOYEE_FIRST_5();
                    employee_first.Value = this.CONTENT.EMPLOYEE_FIRST;
                    content.EMPLOYEE_FIRST[0] = employee_first;
                }

                if (this.CONTENT.EMPLOYEE_MIDDLE != null) {
                    content.EMPLOYEE_MIDDLE = new GD_CATACONTENTEMPLOYEE_MIDDLE_5[1];
                    GD_CATACONTENTEMPLOYEE_MIDDLE_5 employee_middle = new GD_CATACONTENTEMPLOYEE_MIDDLE_5();
                    employee_middle.Value = this.CONTENT.EMPLOYEE_MIDDLE;
                    content.EMPLOYEE_MIDDLE[0] = employee_middle;
                }

                if (this.CONTENT.EMPLOYEE_LAST != null) {
                    content.EMPLOYEE_LAST = new GD_CATACONTENTEMPLOYEE_LAST_5[1];
                    GD_CATACONTENTEMPLOYEE_LAST_5 employee_last = new GD_CATACONTENTEMPLOYEE_LAST_5();
                    employee_last.Value = this.CONTENT.EMPLOYEE_LAST;
                    content.EMPLOYEE_LAST[0] = employee_last;
                }

            }

            gd_cata_5.Items[0] = header;
            gd_cata_5.Items[1] = content;
            return gd_cata_5;
        }

        public string toSteMessageHeader(string serializedXml) {
            int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
            int headerTo   = serializedXml.LastIndexOf("</HEADER>");
            int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
            int contentTo   = serializedXml.LastIndexOf("</CONTENT>");
            string header = "PASSTHRUOTC|GD-CATA|";
            string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
            return result;
        }

    }

    public partial class PTC_GD_CATAHEADER_5 {
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

    public partial class PTC_GD_CATACONTENT_5 {
        private string thisTRACK_AUTHORITY_NUMBER = "";
        private string thisACTION = "";
        private string thisEMPLOYEE_FIRST = "";
        private string thisEMPLOYEE_MIDDLE = "";
        private string thisEMPLOYEE_LAST = "";

        public string TRACK_AUTHORITY_NUMBER {
            get { return this.thisTRACK_AUTHORITY_NUMBER; }
            set { this.thisTRACK_AUTHORITY_NUMBER = value; }
        }

        public string ACTION {
            get { return this.thisACTION; }
            set { this.thisACTION = value; }
        }

        public string EMPLOYEE_FIRST {
            get { return this.thisEMPLOYEE_FIRST; }
            set { this.thisEMPLOYEE_FIRST = value; }
        }

        public string EMPLOYEE_MIDDLE {
            get { return this.thisEMPLOYEE_MIDDLE; }
            set { this.thisEMPLOYEE_MIDDLE = value; }
        }

        public string EMPLOYEE_LAST {
            get { return this.thisEMPLOYEE_LAST; }
            set { this.thisEMPLOYEE_LAST = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GD_CATA_5 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(GD_CATAHEADER_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(GD_CATACONTENT_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class GD_CATAHEADER_5 {
        private GD_CATAHEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATEField;
        private GD_CATAHEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIMEField;
        private GD_CATAHEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_IDField;
        private GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBERField;
        private GD_CATAHEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSIONField;
        private GD_CATAHEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISIONField;
        private GD_CATAHEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYSField;
        private GD_CATAHEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYSField;
        private GD_CATAHEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAMEField;
        private GD_CATAHEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCACField;
        private GD_CATAHEADERHEADER_USER_ID_5[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATAHEADERHEADER_USER_ID_5[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_EVENT_DATE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_EVENT_TIME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_MESSAGE_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_SEQUENCE_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_MESSAGE_VERSION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_MESSAGE_REVISION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_SOURCE_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_DESTINATION_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_DISTRICT_NAME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_DISTRICT_SCAC_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATAHEADERHEADER_USER_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENT_5 {
        private GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5[] TRACK_AUTHORITY_NUMBERField;
        private GD_CATACONTENTACTION_5[] ACTIONField;
        private GD_CATACONTENTEMPLOYEE_FIRST_5[] EMPLOYEE_FIRSTField;
        private GD_CATACONTENTEMPLOYEE_MIDDLE_5[] EMPLOYEE_MIDDLEField;
        private GD_CATACONTENTEMPLOYEE_LAST_5[] EMPLOYEE_LASTField;

        [System.Xml.Serialization.XmlElementAttribute("TRACK_AUTHORITY_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5[] TRACK_AUTHORITY_NUMBER {
            get { return this.TRACK_AUTHORITY_NUMBERField; }
            set { this.TRACK_AUTHORITY_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ACTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATACONTENTACTION_5[] ACTION {
            get { return this.ACTIONField; }
            set { this.ACTIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_FIRST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATACONTENTEMPLOYEE_FIRST_5[] EMPLOYEE_FIRST {
            get { return this.EMPLOYEE_FIRSTField; }
            set { this.EMPLOYEE_FIRSTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_MIDDLE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATACONTENTEMPLOYEE_MIDDLE_5[] EMPLOYEE_MIDDLE {
            get { return this.EMPLOYEE_MIDDLEField; }
            set { this.EMPLOYEE_MIDDLEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("EMPLOYEE_LAST", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GD_CATACONTENTEMPLOYEE_LAST_5[] EMPLOYEE_LAST {
            get { return this.EMPLOYEE_LASTField; }
            set { this.EMPLOYEE_LASTField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENTTRACK_AUTHORITY_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENTACTION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENTEMPLOYEE_FIRST_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENTEMPLOYEE_MIDDLE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class GD_CATACONTENTEMPLOYEE_LAST_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
