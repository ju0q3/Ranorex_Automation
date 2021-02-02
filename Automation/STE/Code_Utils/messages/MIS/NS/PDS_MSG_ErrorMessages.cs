﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using STE.Code_Utils.MessageQueues;

// 
// This source code was auto-generated by xsd, Version=4.7.2556.0.
// 
namespace STE.Code_Utils.messages.MIS.NS
{
    public partial class MIS_ErrorMessagesConfig {
        private string thisMSGINFO;
        private MIS_ErrorMessagesConfigHEADER thisHEADER;
        private MIS_ErrorMessagesConfigCONTENT thisCONTENT;

        public string MSGINFO {
            get { return this.thisMSGINFO; }
            set { this.thisMSGINFO = value; }
        }

        public MIS_ErrorMessagesConfigHEADER HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public MIS_ErrorMessagesConfigCONTENT CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }
        
        public static MIS_ErrorMessagesConfig fromSerializableObject(ErrorMessagesConfig message) {
            MIS_ErrorMessagesConfig ErrorMessagesConfig = new MIS_ErrorMessagesConfig();
            ErrorMessagesConfigHEADER header = null;
            ErrorMessagesConfigCONTENT content = null;
            if (message.Items.Length == 1) {
                content = (ErrorMessagesConfigCONTENT) message.Items[0];
            }
            else {
                header = (ErrorMessagesConfigHEADER) message.Items[0];
                content = (ErrorMessagesConfigCONTENT) message.Items[1];
            }

            if (header != null) {
                MIS_ErrorMessagesConfigHEADER head = new MIS_ErrorMessagesConfigHEADER();
                if (header.PROTOCOLID != null && header.PROTOCOLID.Length > 0) {
                    head.PROTOCOLID = header.PROTOCOLID[0].Value;
                }

                if (header.MSGID != null && header.MSGID.Length > 0) {
                    head.MSGID = header.MSGID[0].Value;
                }

                if (header.TRACE_ID != null && header.TRACE_ID.Length > 0) {
                    head.TRACE_ID = header.TRACE_ID[0].Value;
                }

                if (header.MESSAGE_VERSION != null && header.MESSAGE_VERSION.Length > 0) {
                    head.MESSAGE_VERSION = header.MESSAGE_VERSION[0].Value;
                }

                ErrorMessagesConfig.HEADER = head;

            }

            if (content != null) {
                MIS_ErrorMessagesConfigCONTENT cont = new MIS_ErrorMessagesConfigCONTENT();
                if (content.SCAC != null && content.SCAC.Length > 0) {
                    cont.SCAC = content.SCAC[0].Value;
                }

                if (content.MESSAGECODE != null && content.MESSAGECODE.Length > 0) {
                    cont.MESSAGECODE = content.MESSAGECODE[0].Value;
                }

                if (content.MESSAGETEXT != null && content.MESSAGETEXT.Length > 0) {
                    cont.MESSAGETEXT = content.MESSAGETEXT[0].Value;
                }
                
                ErrorMessagesConfig.CONTENT = cont;

            }

            return ErrorMessagesConfig;
        }
    }

    public partial class MIS_ErrorMessagesConfigHEADER {
        private string thisPROTOCOLID = "";
        private string thisMSGID = "";
        private string thisTRACE_ID = "";
        private string thisMESSAGE_VERSION = "";

        public string PROTOCOLID {
            get { return this.thisPROTOCOLID; }
            set { this.thisPROTOCOLID = value; }
        }

        public string MSGID {
            get { return this.thisMSGID; }
            set { this.thisMSGID = value; }
        }

        public string TRACE_ID {
            get { return this.thisTRACE_ID; }
            set { this.thisTRACE_ID = value; }
        }

        public string MESSAGE_VERSION {
            get { return this.thisMESSAGE_VERSION; }
            set { this.thisMESSAGE_VERSION = value; }
        }

    }

    public partial class MIS_ErrorMessagesConfigCONTENT {
        private string thisSCAC = "";
        private string thisMESSAGECODE = "";
        private string thisMESSAGETEXT = "";

        public string SCAC {
            get { return this.thisSCAC; }
            set { this.thisSCAC = value; }
        }

        public string MESSAGECODE {
            get { return this.thisMESSAGECODE; }
            set { this.thisMESSAGECODE = value; }
        }

        public string MESSAGETEXT {
            get { return this.thisMESSAGETEXT; }
            set { this.thisMESSAGETEXT = value; }
        }

    }


    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ErrorMessagesConfig  {
	    
	    private object[] itemsField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(ErrorMessagesConfigCONTENT), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(ErrorMessagesConfigHEADER), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("MSGINFO", typeof(ErrorMessagesConfigMSGINFO), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public object[] Items {
	        get {
	            return this.itemsField;
	        }
	        set {
	            this.itemsField = value;
	        }
	    }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigCONTENT {
	    
	    private ErrorMessagesConfigCONTENTSCAC[] sCACField;
	    
	    private ErrorMessagesConfigCONTENTMESSAGECODE[] mESSAGECODEField;
	    
	    private ErrorMessagesConfigCONTENTMESSAGETEXT[] mESSAGETEXTField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigCONTENTSCAC[] SCAC {
	        get {
	            return this.sCACField;
	        }
	        set {
	            this.sCACField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGECODE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigCONTENTMESSAGECODE[] MESSAGECODE {
	        get {
	            return this.mESSAGECODEField;
	        }
	        set {
	            this.mESSAGECODEField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGETEXT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigCONTENTMESSAGETEXT[] MESSAGETEXT {
	        get {
	            return this.mESSAGETEXTField;
	        }
	        set {
	            this.mESSAGETEXTField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigCONTENTSCAC {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_loop {
	        get {
	            return this.pds_msg_loopField;
	        }
	        set {
	            this.pds_msg_loopField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigCONTENTMESSAGECODE {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_loop {
	        get {
	            return this.pds_msg_loopField;
	        }
	        set {
	            this.pds_msg_loopField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigCONTENTMESSAGETEXT {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_loop {
	        get {
	            return this.pds_msg_loopField;
	        }
	        set {
	            this.pds_msg_loopField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigHEADER {
	    
	    private ErrorMessagesConfigHEADERPROTOCOLID[] pROTOCOLIDField;
	    
	    private ErrorMessagesConfigHEADERMSGID[] mSGIDField;
	    
	    private ErrorMessagesConfigHEADERTRACE_ID[] tRACE_IDField;
	    
	    private ErrorMessagesConfigHEADERMESSAGE_VERSION[] mESSAGE_VERSIONField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigHEADERPROTOCOLID[] PROTOCOLID {
	        get {
	            return this.pROTOCOLIDField;
	        }
	        set {
	            this.pROTOCOLIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigHEADERMSGID[] MSGID {
	        get {
	            return this.mSGIDField;
	        }
	        set {
	            this.mSGIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigHEADERTRACE_ID[] TRACE_ID {
	        get {
	            return this.tRACE_IDField;
	        }
	        set {
	            this.tRACE_IDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ErrorMessagesConfigHEADERMESSAGE_VERSION[] MESSAGE_VERSION {
	        get {
	            return this.mESSAGE_VERSIONField;
	        }
	        set {
	            this.mESSAGE_VERSIONField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigHEADERPROTOCOLID {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigHEADERMSGID {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigHEADERTRACE_ID {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigHEADERMESSAGE_VERSION {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_length {
	        get {
	            return this.pds_msg_lengthField;
	        }
	        set {
	            this.pds_msg_lengthField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_mvcelementname {
	        get {
	            return this.pds_msg_mvcelementnameField;
	        }
	        set {
	            this.pds_msg_mvcelementnameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_reqd {
	        get {
	            return this.pds_msg_reqdField;
	        }
	        set {
	            this.pds_msg_reqdField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ErrorMessagesConfigMSGINFO {
	    
	    private string pds_msg_delimiterField;
	    
	    private string pds_msg_msgtypeField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_delimiter {
	        get {
	            return this.pds_msg_delimiterField;
	        }
	        set {
	            this.pds_msg_delimiterField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_msgtype {
	        get {
	            return this.pds_msg_msgtypeField;
	        }
	        set {
	            this.pds_msg_msgtypeField = value;
	        }
	    }
     	    
	    [System.Xml.Serialization.XmlTextAttribute()]
	    public string Value {get; set;}
    }
}