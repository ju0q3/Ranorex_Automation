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
    public partial class PTC_DG_ERROR_1 {
        private PTC_DG_ERRORCONTENT_1 thisCONTENT;

        public PTC_DG_ERRORCONTENT_1 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static PTC_DG_ERROR_1 fromSerializableObject(DG_ERROR_1 message) {
            PTC_DG_ERROR_1 dg_error_1 = new PTC_DG_ERROR_1();

            DG_ERRORCONTENT_1 content = null;
            if (message.Items.Length == 1) {
                content = (DG_ERRORCONTENT_1) message.Items[0];
            }

            if (content != null) {
                PTC_DG_ERRORCONTENT_1 cont = new PTC_DG_ERRORCONTENT_1();
                if (content.ERROR_TEXT != null && content.ERROR_TEXT.Length > 0) {
                    cont.ERROR_TEXT = content.ERROR_TEXT[0].Value;
                }

                if (content.REASON != null && content.REASON.Length > 0) {
                    cont.REASON = content.REASON[0].Value;
                }

                if (content.MESSAGE != null && content.MESSAGE.Length > 0) {
                    cont.MESSAGE = content.MESSAGE[0].Value;
                }

                dg_error_1.CONTENT = cont;

            }

            return dg_error_1;
        }
    }

    public partial class PTC_DG_ERRORCONTENT_1 {
        private string thisERROR_TEXT = "";
        private string thisREASON = "";
        private string thisMESSAGE = "";

        public string ERROR_TEXT {
            get { return this.thisERROR_TEXT; }
            set { this.thisERROR_TEXT = value; }
        }

        public string REASON {
            get { return this.thisREASON; }
            set { this.thisREASON = value; }
        }

        public string MESSAGE {
            get { return this.thisMESSAGE; }
            set { this.thisMESSAGE = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class DG_ERROR_1 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DG_ERRORCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class DG_ERRORCONTENT_1 {
        private DG_ERRORCONTENTERROR_TEXT_1[] ERROR_TEXTField;
        private DG_ERRORCONTENTREASON_1[] REASONField;
        private DG_ERRORCONTENTMESSAGE_1[] MESSAGEField;

        [System.Xml.Serialization.XmlElementAttribute("ERROR_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_ERRORCONTENTERROR_TEXT_1[] ERROR_TEXT {
            get { return this.ERROR_TEXTField; }
            set { this.ERROR_TEXTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("REASON", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_ERRORCONTENTREASON_1[] REASON {
            get { return this.REASONField; }
            set { this.REASONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("MESSAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DG_ERRORCONTENTMESSAGE_1[] MESSAGE {
            get { return this.MESSAGEField; }
            set { this.MESSAGEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_ERRORCONTENTERROR_TEXT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_ERRORCONTENTREASON_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DG_ERRORCONTENTMESSAGE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}
