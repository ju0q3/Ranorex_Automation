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
    public partial class MIS_ExternalAlertEventAck {
        private string thisMSGINFO;
        private MIS_ExternalAlertEventAckHEADER thisHEADER;
        private MIS_ExternalAlertEventAckCONTENT thisCONTENT;

        public string MSGINFO {
            get { return this.thisMSGINFO; }
            set { this.thisMSGINFO = value; }
        }

        public MIS_ExternalAlertEventAckHEADER HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public MIS_ExternalAlertEventAckCONTENT CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createExternalAlertEventAck(
            string alert_event_key, 
            string device_type, 
            string device_id
        ) {

            MIS_ExternalAlertEventAck externalAlertEventAck = new MIS_ExternalAlertEventAck();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";

            MIS_ExternalAlertEventAckCONTENT content = new MIS_ExternalAlertEventAckCONTENT();
            content.ALERT_EVENT_KEY = alert_event_key;
            content.DEVICE_TYPE = device_type;
            content.DEVICE_ID = device_id;

            externalAlertEventAck.CONTENT = content;

            ExternalAlertEventAck externalalerteventack = externalAlertEventAck.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(ExternalAlertEventAck));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, externalalerteventack);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = externalAlertEventAck.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createExternalAlertEventAckMsmq(
            string alert_event_key, 
            string device_type, 
            string device_id
        ) {

            MIS_ExternalAlertEventAck externalAlertEventAck = new MIS_ExternalAlertEventAck();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";

            MIS_ExternalAlertEventAckCONTENT content = new MIS_ExternalAlertEventAckCONTENT();
            content.ALERT_EVENT_KEY = alert_event_key;
            content.DEVICE_TYPE = device_type;
            content.DEVICE_ID = device_id;

            externalAlertEventAck.CONTENT = content;

            ExternalAlertEventAck externalalerteventack = externalAlertEventAck.toSerializableObject();
            serializer = new XmlSerializer(typeof(ExternalAlertEventAck));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, externalalerteventack);
            request = externalAlertEventAck.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "MIS-ExternalAlertEventAck");
        }

        public ExternalAlertEventAck toSerializableObject() {
            ExternalAlertEventAck externalAlertEventAck = new ExternalAlertEventAck();
            externalAlertEventAck.Items = new object[2];

            ExternalAlertEventAckHEADER header = new ExternalAlertEventAckHEADER();
            if (this.HEADER != null)
            {
                if (this.HEADER.PROTOCOLID != null) {
                    header.PROTOCOLID = new ExternalAlertEventAckHEADERPROTOCOLID[1];
                    ExternalAlertEventAckHEADERPROTOCOLID protocolid = new ExternalAlertEventAckHEADERPROTOCOLID();
                    protocolid.Value = this.HEADER.PROTOCOLID;
                    header.PROTOCOLID[0] = protocolid;
                }
    
                if (this.HEADER.MSGID != null) {
                    header.MSGID = new ExternalAlertEventAckHEADERMSGID[1];
                    ExternalAlertEventAckHEADERMSGID msgid = new ExternalAlertEventAckHEADERMSGID();
                    msgid.Value = this.HEADER.MSGID;
                    header.MSGID[0] = msgid;
                }
    
                if (this.HEADER.TRACE_ID != null) {
                    header.TRACE_ID = new ExternalAlertEventAckHEADERTRACE_ID[1];
                    ExternalAlertEventAckHEADERTRACE_ID trace_id = new ExternalAlertEventAckHEADERTRACE_ID();
                    trace_id.Value = this.HEADER.TRACE_ID;
                    header.TRACE_ID[0] = trace_id;
                }
    
                if (this.HEADER.MESSAGE_VERSION != null) {
                    header.MESSAGE_VERSION = new ExternalAlertEventAckHEADERMESSAGE_VERSION[1];
                    ExternalAlertEventAckHEADERMESSAGE_VERSION message_version = new ExternalAlertEventAckHEADERMESSAGE_VERSION();
                    message_version.Value = this.HEADER.MESSAGE_VERSION;
                    header.MESSAGE_VERSION[0] = message_version;
                }
            }

            ExternalAlertEventAckCONTENT content = new ExternalAlertEventAckCONTENT();
            if (this.CONTENT != null)
            {
                if (this.CONTENT.ALERT_EVENT_KEY != null) {
                    content.ALERT_EVENT_KEY = new ExternalAlertEventAckCONTENTALERT_EVENT_KEY[1];
                    ExternalAlertEventAckCONTENTALERT_EVENT_KEY alert_event_key = new ExternalAlertEventAckCONTENTALERT_EVENT_KEY();
                    alert_event_key.Value = this.CONTENT.ALERT_EVENT_KEY;
                    content.ALERT_EVENT_KEY[0] = alert_event_key;
                }
    
                if (this.CONTENT.DEVICE_TYPE != null) {
                    content.DEVICE_TYPE = new ExternalAlertEventAckCONTENTDEVICE_TYPE[1];
                    ExternalAlertEventAckCONTENTDEVICE_TYPE device_type = new ExternalAlertEventAckCONTENTDEVICE_TYPE();
                    device_type.Value = this.CONTENT.DEVICE_TYPE;
                    content.DEVICE_TYPE[0] = device_type;
                }
    
                if (this.CONTENT.DEVICE_ID != null) {
                    content.DEVICE_ID = new ExternalAlertEventAckCONTENTDEVICE_ID[1];
                    ExternalAlertEventAckCONTENTDEVICE_ID device_id = new ExternalAlertEventAckCONTENTDEVICE_ID();
                    device_id.Value = this.CONTENT.DEVICE_ID;
                    content.DEVICE_ID[0] = device_id;
                }
            }

            externalAlertEventAck.Items[0] = header;
            externalAlertEventAck.Items[1] = content;
            return externalAlertEventAck;
        }

        public string toSteMessageHeader(string serializedXml) {
        	int from = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
        	int to   = serializedXml.LastIndexOf("</CONTENT>");
        	
        	string header = "PASSTHRU,MEXTATA,";
        	string result = header + serializedXml.Substring(from, to-from);
        	
        	return result;
        }
    }

    public partial class MIS_ExternalAlertEventAckHEADER {
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

    public partial class MIS_ExternalAlertEventAckCONTENT {
        private string thisALERT_EVENT_KEY = "";
        private string thisDEVICE_TYPE = "";
        private string thisDEVICE_ID = "";

        public string ALERT_EVENT_KEY {
            get { return this.thisALERT_EVENT_KEY; }
            set { this.thisALERT_EVENT_KEY = value; }
        }

        public string DEVICE_TYPE {
            get { return this.thisDEVICE_TYPE; }
            set { this.thisDEVICE_TYPE = value; }
        }

        public string DEVICE_ID {
            get { return this.thisDEVICE_ID; }
            set { this.thisDEVICE_ID = value; }
        }

    }


    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ExternalAlertEventAck  {
	    
	    private object[] itemsField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(ExternalAlertEventAckCONTENT), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(ExternalAlertEventAckHEADER), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("MSGINFO", typeof(ExternalAlertEventAckMSGINFO), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
    public partial class ExternalAlertEventAckCONTENT {
	    
	    private ExternalAlertEventAckCONTENTALERT_EVENT_KEY[] aLERT_EVENT_KEYField;
	    
	    private ExternalAlertEventAckCONTENTDEVICE_TYPE[] dEVICE_TYPEField;
	    
	    private ExternalAlertEventAckCONTENTDEVICE_ID[] dEVICE_IDField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("ALERT_EVENT_KEY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckCONTENTALERT_EVENT_KEY[] ALERT_EVENT_KEY {
	        get {
	            return this.aLERT_EVENT_KEYField;
	        }
	        set {
	            this.aLERT_EVENT_KEYField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("DEVICE_TYPE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckCONTENTDEVICE_TYPE[] DEVICE_TYPE {
	        get {
	            return this.dEVICE_TYPEField;
	        }
	        set {
	            this.dEVICE_TYPEField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("DEVICE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckCONTENTDEVICE_ID[] DEVICE_ID {
	        get {
	            return this.dEVICE_IDField;
	        }
	        set {
	            this.dEVICE_IDField = value;
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
    public partial class ExternalAlertEventAckCONTENTALERT_EVENT_KEY {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    private string pds_msg_businesskeyField;
	    
	    private string pds_msg_alphanumericField;
	    
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
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_businesskey {
	        get {
	            return this.pds_msg_businesskeyField;
	        }
	        set {
	            this.pds_msg_businesskeyField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_alphanumeric {
	        get {
	            return this.pds_msg_alphanumericField;
	        }
	        set {
	            this.pds_msg_alphanumericField = value;
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
    public partial class ExternalAlertEventAckCONTENTDEVICE_TYPE {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    private string pds_msg_businesskeyField;
	    
	    private string pds_msg_alphanumericField;
	    
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
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_businesskey {
	        get {
	            return this.pds_msg_businesskeyField;
	        }
	        set {
	            this.pds_msg_businesskeyField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_alphanumeric {
	        get {
	            return this.pds_msg_alphanumericField;
	        }
	        set {
	            this.pds_msg_alphanumericField = value;
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
    public partial class ExternalAlertEventAckCONTENTDEVICE_ID {
	    
	    private string pds_msg_lengthField;
	    
	    private string pds_msg_loopField;
	    
	    private string pds_msg_mvcelementnameField;
	    
	    private string pds_msg_reqdField;
	    
	    private string pds_msg_businesskeyField;
	    
	    private string pds_msg_alphanumericField;
	    
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
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_businesskey {
	        get {
	            return this.pds_msg_businesskeyField;
	        }
	        set {
	            this.pds_msg_businesskeyField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlAttributeAttribute()]
	    public string pds_msg_alphanumeric {
	        get {
	            return this.pds_msg_alphanumericField;
	        }
	        set {
	            this.pds_msg_alphanumericField = value;
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
    public partial class ExternalAlertEventAckHEADER {
	    
	    private ExternalAlertEventAckHEADERPROTOCOLID[] pROTOCOLIDField;
	    
	    private ExternalAlertEventAckHEADERMSGID[] mSGIDField;
	    
	    private ExternalAlertEventAckHEADERTRACE_ID[] tRACE_IDField;
	    
	    private ExternalAlertEventAckHEADERMESSAGE_VERSION[] mESSAGE_VERSIONField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckHEADERPROTOCOLID[] PROTOCOLID {
	        get {
	            return this.pROTOCOLIDField;
	        }
	        set {
	            this.pROTOCOLIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckHEADERMSGID[] MSGID {
	        get {
	            return this.mSGIDField;
	        }
	        set {
	            this.mSGIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckHEADERTRACE_ID[] TRACE_ID {
	        get {
	            return this.tRACE_IDField;
	        }
	        set {
	            this.tRACE_IDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public ExternalAlertEventAckHEADERMESSAGE_VERSION[] MESSAGE_VERSION {
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
    public partial class ExternalAlertEventAckHEADERPROTOCOLID {
	    
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
    public partial class ExternalAlertEventAckHEADERMSGID {
	    
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
    public partial class ExternalAlertEventAckHEADERTRACE_ID {
	    
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
    public partial class ExternalAlertEventAckHEADERMESSAGE_VERSION {
	    
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
    public partial class ExternalAlertEventAckMSGINFO {
	    
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