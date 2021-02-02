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
    public partial class PTC_DG_AK01_2 {
        private PTC_DG_AK01HEADER_2 thisHEADER;
        private PTC_DG_AK01CONTENT_2 thisCONTENT;

        public PTC_DG_AK01HEADER_2 HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public PTC_DG_AK01CONTENT_2 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static PTC_DG_AK01_2 fromSerializableObject(DG_AK01_2 message) {
            PTC_DG_AK01_2 dg_ak01_2 = new PTC_DG_AK01_2();
            DG_AK01HEADER_2 header = null;
            DG_AK01CONTENT_2 content = null;
            if (message.Items.Length == 1) {
                content = (DG_AK01CONTENT_2) message.Items[0];
            }
            else {
                header = (DG_AK01HEADER_2) message.Items[0];
                content = (DG_AK01CONTENT_2) message.Items[1];
            }

            if (header != null) {
                PTC_DG_AK01HEADER_2 head = new PTC_DG_AK01HEADER_2();
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

                dg_ak01_2.HEADER = head;

            }

            if (content != null) {
                PTC_DG_AK01CONTENT_2 cont = new PTC_DG_AK01CONTENT_2();
                if (content.ACK_MESSAGE_ID != null && content.ACK_MESSAGE_ID.Length > 0) {
                    cont.ACK_MESSAGE_ID = content.ACK_MESSAGE_ID[0].Value;
                }

                if (content.ACK_SEQUENCE_NUMBER != null && content.ACK_SEQUENCE_NUMBER.Length > 0) {
                    cont.ACK_SEQUENCE_NUMBER = content.ACK_SEQUENCE_NUMBER[0].Value;
                }

                if (content.RESPONSE_CODE != null && content.RESPONSE_CODE.Length > 0) {
                    cont.RESPONSE_CODE = content.RESPONSE_CODE[0].Value;
                }

                if (content.TEXT != null && content.TEXT.Length > 0) {
                    cont.TEXT = content.TEXT[0].Value;
                }

                dg_ak01_2.CONTENT = cont;

            }

            return dg_ak01_2;
        }
    }

    public partial class PTC_DG_AK01HEADER_2 {
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

    public partial class PTC_DG_AK01CONTENT_2 {
        private string thisACK_MESSAGE_ID = "";
        private string thisACK_SEQUENCE_NUMBER = "";
        private string thisRESPONSE_CODE = "";
        private string thisTEXT = "";

        public string ACK_MESSAGE_ID {
            get { return this.thisACK_MESSAGE_ID; }
            set { this.thisACK_MESSAGE_ID = value; }
        }

        public string ACK_SEQUENCE_NUMBER {
            get { return this.thisACK_SEQUENCE_NUMBER; }
            set { this.thisACK_SEQUENCE_NUMBER = value; }
        }

        public string RESPONSE_CODE {
            get { return this.thisRESPONSE_CODE; }
            set { this.thisRESPONSE_CODE = value; }
        }

        public string TEXT {
            get { return this.thisTEXT; }
            set { this.thisTEXT = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class DG_AK01_2 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DG_AK01HEADER_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DG_AK01CONTENT_2), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class DG_AK01HEADER_2 {
        private DG_AK01HEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATEField;
        private DG_AK01HEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIMEField;
        private DG_AK01HEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_IDField;
        private DG_AK01HEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBERField;
        private DG_AK01HEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSIONField;
        private DG_AK01HEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISIONField;
        private DG_AK01HEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYSField;
        private DG_AK01HEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYSField;
        private DG_AK01HEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAMEField;
        private DG_AK01HEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCACField;
        private DG_AK01HEADERHEADER_USER_ID_2[] HEADER_USER_IDField;

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_EVENT_DATE_2[] HEADER_EVENT_DATE {
            get { return this.HEADER_EVENT_DATEField; }
            set { this.HEADER_EVENT_DATEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_EVENT_TIME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_EVENT_TIME_2[] HEADER_EVENT_TIME {
            get { return this.HEADER_EVENT_TIMEField; }
            set { this.HEADER_EVENT_TIMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_MESSAGE_ID_2[] HEADER_MESSAGE_ID {
            get { return this.HEADER_MESSAGE_IDField; }
            set { this.HEADER_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_SEQUENCE_NUMBER_2[] HEADER_SEQUENCE_NUMBER {
            get { return this.HEADER_SEQUENCE_NUMBERField; }
            set { this.HEADER_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_MESSAGE_VERSION_2[] HEADER_MESSAGE_VERSION {
            get { return this.HEADER_MESSAGE_VERSIONField; }
            set { this.HEADER_MESSAGE_VERSIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_MESSAGE_REVISION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_MESSAGE_REVISION_2[] HEADER_MESSAGE_REVISION {
            get { return this.HEADER_MESSAGE_REVISIONField; }
            set { this.HEADER_MESSAGE_REVISIONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_SOURCE_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_SOURCE_SYS_2[] HEADER_SOURCE_SYS {
            get { return this.HEADER_SOURCE_SYSField; }
            set { this.HEADER_SOURCE_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DESTINATION_SYS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_DESTINATION_SYS_2[] HEADER_DESTINATION_SYS {
            get { return this.HEADER_DESTINATION_SYSField; }
            set { this.HEADER_DESTINATION_SYSField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_NAME", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_DISTRICT_NAME_2[] HEADER_DISTRICT_NAME {
            get { return this.HEADER_DISTRICT_NAMEField; }
            set { this.HEADER_DISTRICT_NAMEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_DISTRICT_SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_DISTRICT_SCAC_2[] HEADER_DISTRICT_SCAC {
            get { return this.HEADER_DISTRICT_SCACField; }
            set { this.HEADER_DISTRICT_SCACField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("HEADER_USER_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01HEADERHEADER_USER_ID_2[] HEADER_USER_ID {
            get { return this.HEADER_USER_IDField; }
            set { this.HEADER_USER_IDField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_EVENT_DATE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_EVENT_TIME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_MESSAGE_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_SEQUENCE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_MESSAGE_VERSION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_MESSAGE_REVISION_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_SOURCE_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_DESTINATION_SYS_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_DISTRICT_NAME_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_DISTRICT_SCAC_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01HEADERHEADER_USER_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01CONTENT_2 {
        private DG_AK01CONTENTACK_MESSAGE_ID_2[] ACK_MESSAGE_IDField;
        private DG_AK01CONTENTACK_SEQUENCE_NUMBER_2[] ACK_SEQUENCE_NUMBERField;
        private DG_AK01CONTENTRESPONSE_CODE_2[] RESPONSE_CODEField;
        private DG_AK01CONTENTTEXT_2[] TEXTField;

        [System.Xml.Serialization.XmlElementAttribute("ACK_MESSAGE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01CONTENTACK_MESSAGE_ID_2[] ACK_MESSAGE_ID {
            get { return this.ACK_MESSAGE_IDField; }
            set { this.ACK_MESSAGE_IDField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("ACK_SEQUENCE_NUMBER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01CONTENTACK_SEQUENCE_NUMBER_2[] ACK_SEQUENCE_NUMBER {
            get { return this.ACK_SEQUENCE_NUMBERField; }
            set { this.ACK_SEQUENCE_NUMBERField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("RESPONSE_CODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01CONTENTRESPONSE_CODE_2[] RESPONSE_CODE {
            get { return this.RESPONSE_CODEField; }
            set { this.RESPONSE_CODEField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_AK01CONTENTTEXT_2[] TEXT {
            get { return this.TEXTField; }
            set { this.TEXTField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01CONTENTACK_MESSAGE_ID_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01CONTENTACK_SEQUENCE_NUMBER_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01CONTENTRESPONSE_CODE_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_AK01CONTENTTEXT_2 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
