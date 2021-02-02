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

namespace STE.Code_Utils.messages.PTC
{
    public partial class PTC_DC_TLST_5 {
        private PTC_DC_TLSTHEADER_5 thisHEADER;
        private PTC_DC_TLSTCONTENT_5 thisCONTENT;

        public PTC_DC_TLSTHEADER_5 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_DC_TLSTCONTENT_5 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static PTC_DC_TLST_5 fromSerializableObject(DC_TLST_5 message) {
            PTC_DC_TLST_5 dc_tlst_5 = new PTC_DC_TLST_5();
            DC_TLSTHEADER_5 header = null;
            DC_TLSTCONTENT_5 content = null;
            if (message.Items.Length == 1) {
                content = (DC_TLSTCONTENT_5) message.Items[0];
            }
            else {
                header = (DC_TLSTHEADER_5) message.Items[0];
                content = (DC_TLSTCONTENT_5) message.Items[1];
            }

            if (header != null) {
                PTC_DC_TLSTHEADER_5 head = new PTC_DC_TLSTHEADER_5();
                if (header.HEADER_EVENT_DATE != null && header.HEADER_EVENT_DATE.Length > 0) {
                    head.HEADER_EVENT_DATE = header.HEADER_EVENT_DATE[0].Value;
                }

                if (header.HEADER_EVENT_TIME != null && header.HEADER_EVENT_TIME.Length > 0) {
                    head.HEADER_EVENT_TIME = header.HEADER_EVENT_TIME[0].Value;
                }

                if (header.HEADER_MESSAGE_ID != null && header.HEADER_MESSAGE_ID.Length > 0) {
                    head.HEADER_MESSAGE_ID = header.HEADER_MESSAGE_ID[0].Value;
                }

                if (header.HEADER_SEQUENCE_NUMBER != null && header.HEADER_SEQUENCE_NUMBER.Length > 0) {
                    head.HEADER_SEQUENCE_NUMBER = header.HEADER_SEQUENCE_NUMBER[0].Value;
                }

                if (header.HEADER_MESSAGE_VERSION != null && header.HEADER_MESSAGE_VERSION.Length > 0) {
                    head.HEADER_MESSAGE_VERSION = header.HEADER_MESSAGE_VERSION[0].Value;
                }

                if (header.HEADER_MESSAGE_REVISION != null && header.HEADER_MESSAGE_REVISION.Length > 0) {
                    head.HEADER_MESSAGE_REVISION = header.HEADER_MESSAGE_REVISION[0].Value;
                }

                if (header.HEADER_SOURCE_SYS != null && header.HEADER_SOURCE_SYS.Length > 0) {
                    head.HEADER_SOURCE_SYS = header.HEADER_SOURCE_SYS[0].Value;
                }

                if (header.HEADER_DESTINATION_SYS != null && header.HEADER_DESTINATION_SYS.Length > 0) {
                    head.HEADER_DESTINATION_SYS = header.HEADER_DESTINATION_SYS[0].Value;
                }

                if (header.HEADER_DISTRICT_NAME != null && header.HEADER_DISTRICT_NAME.Length > 0) {
                    head.HEADER_DISTRICT_NAME = header.HEADER_DISTRICT_NAME[0].Value;
                }

                if (header.HEADER_DISTRICT_SCAC != null && header.HEADER_DISTRICT_SCAC.Length > 0) {
                    head.HEADER_DISTRICT_SCAC = header.HEADER_DISTRICT_SCAC[0].Value;
                }

                if (header.HEADER_USER_ID != null && header.HEADER_USER_ID.Length > 0) {
                    head.HEADER_USER_ID = header.HEADER_USER_ID[0].Value;
                }

                dc_tlst_5.HEADER = head;

            }

            if (content != null) {
                PTC_DC_TLSTCONTENT_5 cont = new PTC_DC_TLSTCONTENT_5();
                if (content.TRAIN_CLEARANCE_NUMBER != null && content.TRAIN_CLEARANCE_NUMBER.Length > 0) {
                    cont.TRAIN_CLEARANCE_NUMBER = content.TRAIN_CLEARANCE_NUMBER[0].Value;
                }

                if (content.ENGINE_INITIAL != null && content.ENGINE_INITIAL.Length > 0) {
                    cont.ENGINE_INITIAL = content.ENGINE_INITIAL[0].Value;
                }

                if (content.ENGINE_NUMBER != null && content.ENGINE_NUMBER.Length > 0) {
                    cont.ENGINE_NUMBER = content.ENGINE_NUMBER[0].Value;
                }

                if (content.TRAIN_ID_COUNT != null && content.TRAIN_ID_COUNT.Length > 0) {
                    cont.TRAIN_ID_COUNT = content.TRAIN_ID_COUNT[0].Value;
                }

                if (content.TRAIN_ID_RECORD != null && content.TRAIN_ID_RECORD.Length > 0) {
                    for (int i = 0; i < content.TRAIN_ID_RECORD.Length; i++) {
                        PTC_DC_TLSTTRAIN_ID_RECORD_5 train_id_record = new PTC_DC_TLSTTRAIN_ID_RECORD_5();
                        if (content.TRAIN_ID_RECORD[i].SCAC != null && content.TRAIN_ID_RECORD[i].SCAC.Length > 0) {
                            train_id_record.SCAC = content.TRAIN_ID_RECORD[i].SCAC[0].Value;
                        }

                        if (content.TRAIN_ID_RECORD[i].SYMBOL != null && content.TRAIN_ID_RECORD[i].SYMBOL.Length > 0) {
                            train_id_record.SYMBOL = content.TRAIN_ID_RECORD[i].SYMBOL[0].Value;
                        }

                        if (content.TRAIN_ID_RECORD[i].SECTION != null && content.TRAIN_ID_RECORD[i].SECTION.Length > 0) {
                            train_id_record.SECTION = content.TRAIN_ID_RECORD[i].SECTION[0].Value;
                        }

                        if (content.TRAIN_ID_RECORD[i].ORIGIN_DATE != null && content.TRAIN_ID_RECORD[i].ORIGIN_DATE.Length > 0) {
                            train_id_record.ORIGIN_DATE = content.TRAIN_ID_RECORD[i].ORIGIN_DATE[0].Value;
                        }

                        if (content.TRAIN_ID_RECORD[i].DISPLAY_TRAIN_ID != null && content.TRAIN_ID_RECORD[i].DISPLAY_TRAIN_ID.Length > 0) {
                            train_id_record.DISPLAY_TRAIN_ID = content.TRAIN_ID_RECORD[i].DISPLAY_TRAIN_ID[0].Value;
                        }

                        cont.addTRAIN_ID_RECORD(train_id_record);
                    }

                }

                dc_tlst_5.CONTENT = cont;

            }

            return dc_tlst_5;
        }
    }

    public partial class PTC_DC_TLSTHEADER_5 {
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

    public partial class PTC_DC_TLSTCONTENT_5 {
        private string thisTRAIN_CLEARANCE_NUMBER = "";
        private string thisENGINE_INITIAL = "";
        private string thisENGINE_NUMBER = "";
        private string thisTRAIN_ID_COUNT = "";
        private ArrayList thisTRAIN_ID_RECORD = new ArrayList();

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

        public string TRAIN_ID_COUNT {
            get { return this.thisTRAIN_ID_COUNT; }
            set { this.thisTRAIN_ID_COUNT = value; }
        }

        public ArrayList TRAIN_ID_RECORD {
            get { return this.thisTRAIN_ID_RECORD; }
            set { this.thisTRAIN_ID_RECORD = value; }
        }

        public void addTRAIN_ID_RECORD(PTC_DC_TLSTTRAIN_ID_RECORD_5 train_id_record) {
            this.TRAIN_ID_RECORD.Add(train_id_record);
            this.TRAIN_ID_COUNT = this.TRAIN_ID_RECORD.Count.ToString();
        }

        public void removeTRAIN_ID_RECORD(int index) {
            this.TRAIN_ID_RECORD.RemoveAt(index);
            this.TRAIN_ID_COUNT = this.TRAIN_ID_RECORD.Count.ToString();
        }

    }

    public partial class PTC_DC_TLSTTRAIN_ID_RECORD_5 {
        private string thisSCAC = "";
        private string thisSYMBOL = "";
        private string thisSECTION = "";
        private string thisORIGIN_DATE = "";
        private string thisDISPLAY_TRAIN_ID = "";

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

        public string DISPLAY_TRAIN_ID {
            get { return this.thisDISPLAY_TRAIN_ID; }
            set { this.thisDISPLAY_TRAIN_ID = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class DC_TLST_5 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DC_TLSTHEADER_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DC_TLSTCONTENT_5), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class DC_TLSTHEADER_5 {
        private DC_TLSTHEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATEField;
        private DC_TLSTHEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIMEField;
        private DC_TLSTHEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_IDField;
        private DC_TLSTHEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBERField;
        private DC_TLSTHEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSIONField;
        private DC_TLSTHEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISIONField;
        private DC_TLSTHEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYSField;
        private DC_TLSTHEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYSField;
        private DC_TLSTHEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAMEField;
        private DC_TLSTHEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCACField;
        private DC_TLSTHEADERHEADER_USER_ID_5[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_EVENT_DATE_5[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_EVENT_TIME_5[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_MESSAGE_ID_5[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_SEQUENCE_NUMBER_5[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_MESSAGE_VERSION_5[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_MESSAGE_REVISION_5[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_SOURCE_SYS_5[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_DESTINATION_SYS_5[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_DISTRICT_NAME_5[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_DISTRICT_SCAC_5[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTHEADERHEADER_USER_ID_5[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_EVENT_DATE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_EVENT_TIME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_MESSAGE_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_SEQUENCE_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_MESSAGE_VERSION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_MESSAGE_REVISION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_SOURCE_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_DESTINATION_SYS_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_DISTRICT_NAME_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_DISTRICT_SCAC_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTHEADERHEADER_USER_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENT_5 {
        private DC_TLSTCONTENTTRAIN_CLEARANCE_NUMBER_5[] TRAIN_CLEARANCE_NUMBERField;
        private DC_TLSTCONTENTENGINE_INITIAL_5[] ENGINE_INITIALField;
        private DC_TLSTCONTENTENGINE_NUMBER_5[] ENGINE_NUMBERField;
        private DC_TLSTCONTENTTRAIN_ID_COUNT_5[] TRAIN_ID_COUNTField;
        private DC_TLSTCONTENTTRAIN_ID_RECORD_5[] TRAIN_ID_RECORDField;

        [System.Xml.Serialization.XmlElementAttribute("TRAIN_CLEARANCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTCONTENTTRAIN_CLEARANCE_NUMBER_5[] TRAIN_CLEARANCE_NUMBER {
            get { return this.TRAIN_CLEARANCE_NUMBERField; }
            set { this.TRAIN_CLEARANCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_INITIAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTCONTENTENGINE_INITIAL_5[] ENGINE_INITIAL {
            get { return this.ENGINE_INITIALField; }
            set { this.ENGINE_INITIALField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENGINE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTCONTENTENGINE_NUMBER_5[] ENGINE_NUMBER {
            get { return this.ENGINE_NUMBERField; }
            set { this.ENGINE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("TRAIN_ID_COUNT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTCONTENTTRAIN_ID_COUNT_5[] TRAIN_ID_COUNT {
            get { return this.TRAIN_ID_COUNTField; }
            set { this.TRAIN_ID_COUNTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("TRAIN_ID_RECORD", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTCONTENTTRAIN_ID_RECORD_5[] TRAIN_ID_RECORD {
            get { return this.TRAIN_ID_RECORDField; }
            set { this.TRAIN_ID_RECORDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENTTRAIN_CLEARANCE_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENTENGINE_INITIAL_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENTENGINE_NUMBER_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENTTRAIN_ID_COUNT_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTCONTENTTRAIN_ID_RECORD_5 {
        private DC_TLSTTRAIN_ID_RECORDSCAC_5[] SCACField;
        private DC_TLSTTRAIN_ID_RECORDSYMBOL_5[] SYMBOLField;
        private DC_TLSTTRAIN_ID_RECORDSECTION_5[] SECTIONField;
        private DC_TLSTTRAIN_ID_RECORDORIGIN_DATE_5[] ORIGIN_DATEField;
        private DC_TLSTTRAIN_ID_RECORDDISPLAY_TRAIN_ID_5[] DISPLAY_TRAIN_IDField;

        [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTTRAIN_ID_RECORDSCAC_5[] SCAC {
            get { return this.SCACField; }
            set { this.SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTTRAIN_ID_RECORDSYMBOL_5[] SYMBOL {
            get { return this.SYMBOLField; }
            set { this.SYMBOLField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTTRAIN_ID_RECORDSECTION_5[] SECTION {
            get { return this.SECTIONField; }
            set { this.SECTIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTTRAIN_ID_RECORDORIGIN_DATE_5[] ORIGIN_DATE {
            get { return this.ORIGIN_DATEField; }
            set { this.ORIGIN_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("DISPLAY_TRAIN_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_TLSTTRAIN_ID_RECORDDISPLAY_TRAIN_ID_5[] DISPLAY_TRAIN_ID {
            get { return this.DISPLAY_TRAIN_IDField; }
            set { this.DISPLAY_TRAIN_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTTRAIN_ID_RECORDSCAC_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTTRAIN_ID_RECORDSYMBOL_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTTRAIN_ID_RECORDSECTION_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTTRAIN_ID_RECORDORIGIN_DATE_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_TLSTTRAIN_ID_RECORDDISPLAY_TRAIN_ID_5 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
