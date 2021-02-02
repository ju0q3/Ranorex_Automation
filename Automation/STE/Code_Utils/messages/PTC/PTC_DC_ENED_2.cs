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
    public partial class PTC_DC_ENED_2 {
        private PTC_DC_ENEDHEADER_2 thisHEADER;
        private PTC_DC_ENEDCONTENT_2 thisCONTENT;

        public PTC_DC_ENEDHEADER_2 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_DC_ENEDCONTENT_2 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static PTC_DC_ENED_2 fromSerializableObject(DC_ENED_2 message) {
            PTC_DC_ENED_2 dc_ened_2 = new PTC_DC_ENED_2();
            DC_ENEDHEADER_2 header = null;
            DC_ENEDCONTENT_2 content = null;
            if (message.Items.Length == 1) {
                content = (DC_ENEDCONTENT_2) message.Items[0];
            }
            else {
                header = (DC_ENEDHEADER_2) message.Items[0];
                content = (DC_ENEDCONTENT_2) message.Items[1];
            }

            if (header != null) {
                PTC_DC_ENEDHEADER_2 head = new PTC_DC_ENEDHEADER_2();
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

                dc_ened_2.HEADER = head;

            }

            if (content != null) {
                PTC_DC_ENEDCONTENT_2 cont = new PTC_DC_ENEDCONTENT_2();
                if (content.SCAC != null && content.SCAC.Length > 0) {
                    cont.SCAC = content.SCAC[0].Value;
                }

                if (content.SYMBOL != null && content.SYMBOL.Length > 0) {
                    cont.SYMBOL = content.SYMBOL[0].Value;
                }

                if (content.SECTION != null && content.SECTION.Length > 0) {
                    cont.SECTION = content.SECTION[0].Value;
                }

                if (content.ORIGIN_DATE != null && content.ORIGIN_DATE.Length > 0) {
                    cont.ORIGIN_DATE = content.ORIGIN_DATE[0].Value;
                }

                if (content.ENABLE_DISABLE != null && content.ENABLE_DISABLE.Length > 0) {
                    cont.ENABLE_DISABLE = content.ENABLE_DISABLE[0].Value;
                }

                if (content.ENABLE_DISABLE_REASON != null && content.ENABLE_DISABLE_REASON.Length > 0) {
                    cont.ENABLE_DISABLE_REASON = content.ENABLE_DISABLE_REASON[0].Value;
                }

                if (content.DISPATCH_TERRITORY != null && content.DISPATCH_TERRITORY.Length > 0) {
                    cont.DISPATCH_TERRITORY = content.DISPATCH_TERRITORY[0].Value;
                }

                dc_ened_2.CONTENT = cont;

            }

            return dc_ened_2;
        }
    }

    public partial class PTC_DC_ENEDHEADER_2 {
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

    public partial class PTC_DC_ENEDCONTENT_2 {
        private string thisSCAC = "";
        private string thisSYMBOL = "";
        private string thisSECTION = "";
        private string thisORIGIN_DATE = "";
        private string thisENABLE_DISABLE = "";
        private string thisENABLE_DISABLE_REASON = "";
        private string thisDISPATCH_TERRITORY = "";

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

        public string ENABLE_DISABLE {
            get { return this.thisENABLE_DISABLE; }
            set { this.thisENABLE_DISABLE = value; }
        }

        public string ENABLE_DISABLE_REASON {
            get { return this.thisENABLE_DISABLE_REASON; }
            set { this.thisENABLE_DISABLE_REASON = value; }
        }

        public string DISPATCH_TERRITORY {
            get { return this.thisDISPATCH_TERRITORY; }
            set { this.thisDISPATCH_TERRITORY = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class DC_ENED_2 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DC_ENEDHEADER_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DC_ENEDCONTENT_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class DC_ENEDHEADER_2 {
        private DC_ENEDHEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATEField;
        private DC_ENEDHEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIMEField;
        private DC_ENEDHEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_IDField;
        private DC_ENEDHEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBERField;
        private DC_ENEDHEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSIONField;
        private DC_ENEDHEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISIONField;
        private DC_ENEDHEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYSField;
        private DC_ENEDHEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYSField;
        private DC_ENEDHEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAMEField;
        private DC_ENEDHEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCACField;
        private DC_ENEDHEADERHEADER_USER_ID_2[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDHEADERHEADER_USER_ID_2[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_EVENT_DATE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_EVENT_TIME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_MESSAGE_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_SEQUENCE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_MESSAGE_VERSION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_MESSAGE_REVISION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_SOURCE_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_DESTINATION_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_DISTRICT_NAME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_DISTRICT_SCAC_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDHEADERHEADER_USER_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENT_2 {
        private DC_ENEDCONTENTSCAC_2[] SCACField;
        private DC_ENEDCONTENTSYMBOL_2[] SYMBOLField;
        private DC_ENEDCONTENTSECTION_2[] SECTIONField;
        private DC_ENEDCONTENTORIGIN_DATE_2[] ORIGIN_DATEField;
        private DC_ENEDCONTENTENABLE_DISABLE_2[] ENABLE_DISABLEField;
        private DC_ENEDCONTENTENABLE_DISABLE_REASON_2[] ENABLE_DISABLE_REASONField;
        private DC_ENEDCONTENTDISPATCH_TERRITORY_2[] DISPATCH_TERRITORYField;

        [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTSCAC_2[] SCAC {
            get { return this.SCACField; }
            set { this.SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTSYMBOL_2[] SYMBOL {
            get { return this.SYMBOLField; }
            set { this.SYMBOLField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTSECTION_2[] SECTION {
            get { return this.SECTIONField; }
            set { this.SECTIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTORIGIN_DATE_2[] ORIGIN_DATE {
            get { return this.ORIGIN_DATEField; }
            set { this.ORIGIN_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENABLE_DISABLE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTENABLE_DISABLE_2[] ENABLE_DISABLE {
            get { return this.ENABLE_DISABLEField; }
            set { this.ENABLE_DISABLEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ENABLE_DISABLE_REASON", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTENABLE_DISABLE_REASON_2[] ENABLE_DISABLE_REASON {
            get { return this.ENABLE_DISABLE_REASONField; }
            set { this.ENABLE_DISABLE_REASONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("DISPATCH_TERRITORY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DC_ENEDCONTENTDISPATCH_TERRITORY_2[] DISPATCH_TERRITORY {
            get { return this.DISPATCH_TERRITORYField; }
            set { this.DISPATCH_TERRITORYField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTSCAC_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTSYMBOL_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTSECTION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTORIGIN_DATE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTENABLE_DISABLE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTENABLE_DISABLE_REASON_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DC_ENEDCONTENTDISPATCH_TERRITORY_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
