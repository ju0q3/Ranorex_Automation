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
    public partial class PTC_ERROR_1 {
        private PTC_ERRORCONTENT_1 thisCONTENT;

        public PTC_ERRORCONTENT_1 CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createERROR_1(
            string error_text, 
            string reason, 
            string message
        ) {
            PTC_ERROR_1 eRROR = new PTC_ERROR_1();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";


            PTC_ERRORCONTENT_1 content = new PTC_ERRORCONTENT_1();
            content.ERROR_TEXT = error_text;
            content.REASON = reason;
            content.MESSAGE = message;

            eRROR.CONTENT = content;

            ERROR_1 ptc_error = eRROR.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(ERROR_1));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, ptc_error);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = eRROR.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public ERROR_1 toSerializableObject() {
            ERROR_1 error_1 = new ERROR_1();
            error_1.Items = new object[2];

            ERRORCONTENT_1 content = new ERRORCONTENT_1();
            if (this.CONTENT.ERROR_TEXT != null) {
                content.ERROR_TEXT = new ERRORCONTENTERROR_TEXT_1[1];
                ERRORCONTENTERROR_TEXT_1 error_text = new ERRORCONTENTERROR_TEXT_1();
                error_text.Value = this.CONTENT.ERROR_TEXT;
                content.ERROR_TEXT[0] = error_text;
            }

            if (this.CONTENT.REASON != null) {
                content.REASON = new ERRORCONTENTREASON_1[1];
                ERRORCONTENTREASON_1 reason = new ERRORCONTENTREASON_1();
                reason.Value = this.CONTENT.REASON;
                content.REASON[0] = reason;
            }

            if (this.CONTENT.MESSAGE != null) {
                content.MESSAGE = new ERRORCONTENTMESSAGE_1[1];
                ERRORCONTENTMESSAGE_1 message = new ERRORCONTENTMESSAGE_1();
                message.Value = this.CONTENT.MESSAGE;
                content.MESSAGE[0] = message;
            }

            error_1.Items[0] = content;
            return error_1;
        }

        public string toSteMessageHeader(string serializedXml) {
            int headerFrom = serializedXml.IndexOf("<HEADER>") + "<HEADER>".Length;
            int headerTo   = serializedXml.LastIndexOf("</HEADER>");
            int contentFrom = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
            int contentTo   = serializedXml.LastIndexOf("</CONTENT>");
            string header = "PASSTHRUOTC|ERROR|";
            string result = header + serializedXml.Substring(headerFrom, headerTo-headerFrom) + serializedXml.Substring(contentFrom, contentTo-contentFrom);
            return result;
        }

    }

    public partial class PTC_ERRORCONTENT_1 {
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
    public partial class ERROR_1 {
        private object[] itemsField;

        [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(ERRORCONTENT_1), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]


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
    public partial class ERRORCONTENT_1 {
        private ERRORCONTENTERROR_TEXT_1[] ERROR_TEXTField;
        private ERRORCONTENTREASON_1[] REASONField;
        private ERRORCONTENTMESSAGE_1[] MESSAGEField;

        [System.Xml.Serialization.XmlElementAttribute("ERROR_TEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ERRORCONTENTERROR_TEXT_1[] ERROR_TEXT {
            get { return this.ERROR_TEXTField; }
            set { this.ERROR_TEXTField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("REASON", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ERRORCONTENTREASON_1[] REASON {
            get { return this.REASONField; }
            set { this.REASONField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("MESSAGE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ERRORCONTENTMESSAGE_1[] MESSAGE {
            get { return this.MESSAGEField; }
            set { this.MESSAGEField = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ERRORCONTENTERROR_TEXT_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ERRORCONTENTREASON_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ERRORCONTENTMESSAGE_1 {
       	[System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }

}