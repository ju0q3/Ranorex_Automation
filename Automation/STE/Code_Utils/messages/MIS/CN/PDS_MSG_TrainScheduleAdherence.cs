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
namespace STE.Code_Utils.messages.MIS.CN
{
    public partial class MIS_TrainScheduleAdherence {
        private string thisMSGINFO;
        private MIS_TrainScheduleAdherenceHEADER thisHEADER;
        private MIS_TrainScheduleAdherenceCONTENT thisCONTENT;

        public string MSGINFO {
            get { return this.thisMSGINFO; }
            set { this.thisMSGINFO = value; }
        }

        public MIS_TrainScheduleAdherenceHEADER HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public MIS_TrainScheduleAdherenceCONTENT CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        public static void createTrainScheduleAdherence(
            string scac, 
            string section, 
            string train_symbol,  
            string adherence
        ) {

            MIS_TrainScheduleAdherence trainScheduleAdherence = new MIS_TrainScheduleAdherence();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            FileStream fs;
            string request = "";

            MIS_TrainScheduleAdherenceCONTENT content = new MIS_TrainScheduleAdherenceCONTENT();
            content.SCAC = scac;
            content.SECTION = section;
            content.TRAIN_SYMBOL = train_symbol;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.ADHERENCE = adherence;

            trainScheduleAdherence.CONTENT = content;

            TrainScheduleAdherence trainscheduleadherence = trainScheduleAdherence.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(TrainScheduleAdherence));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, trainscheduleadherence);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = trainScheduleAdherence.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createTrainScheduleAdherenceMsmq(
            string scac, 
            string section, 
            string train_symbol,  
            string adherence
        ) {

            MIS_TrainScheduleAdherence trainScheduleAdherence = new MIS_TrainScheduleAdherence();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            System.DateTime now = System.DateTime.Now;
            string request = "";

            MIS_TrainScheduleAdherenceCONTENT content = new MIS_TrainScheduleAdherenceCONTENT();
            content.SCAC = scac;
            content.SECTION = section;
            content.TRAIN_SYMBOL = train_symbol;
            content.ORIGIN_DATE = now.ToString("MMddyyyy");
            content.ADHERENCE = adherence;

            trainScheduleAdherence.CONTENT = content;

            TrainScheduleAdherence trainscheduleadherence = trainScheduleAdherence.toSerializableObject();
            serializer = new XmlSerializer(typeof(TrainScheduleAdherence));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, trainscheduleadherence);
            request = trainScheduleAdherence.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "MIS-TrainScheduleAdherence");
        }

        public TrainScheduleAdherence toSerializableObject() {
            TrainScheduleAdherence trainScheduleAdherence = new TrainScheduleAdherence();
            trainScheduleAdherence.Items = new object[2];

            TrainScheduleAdherenceHEADER header = new TrainScheduleAdherenceHEADER();
            if (this.HEADER != null)
            {
                if (this.HEADER.PROTOCOLID != null) {
                    header.PROTOCOLID = new TrainScheduleAdherenceHEADERPROTOCOLID[1];
                    TrainScheduleAdherenceHEADERPROTOCOLID protocolid = new TrainScheduleAdherenceHEADERPROTOCOLID();
                    protocolid.Value = this.HEADER.PROTOCOLID;
                    header.PROTOCOLID[0] = protocolid;
                }
    
                if (this.HEADER.MSGID != null) {
                    header.MSGID = new TrainScheduleAdherenceHEADERMSGID[1];
                    TrainScheduleAdherenceHEADERMSGID msgid = new TrainScheduleAdherenceHEADERMSGID();
                    msgid.Value = this.HEADER.MSGID;
                    header.MSGID[0] = msgid;
                }
    
                if (this.HEADER.TRACE_ID != null) {
                    header.TRACE_ID = new TrainScheduleAdherenceHEADERTRACE_ID[1];
                    TrainScheduleAdherenceHEADERTRACE_ID trace_id = new TrainScheduleAdherenceHEADERTRACE_ID();
                    trace_id.Value = this.HEADER.TRACE_ID;
                    header.TRACE_ID[0] = trace_id;
                }
    
                if (this.HEADER.MESSAGE_VERSION != null) {
                    header.MESSAGE_VERSION = new TrainScheduleAdherenceHEADERMESSAGE_VERSION[1];
                    TrainScheduleAdherenceHEADERMESSAGE_VERSION message_version = new TrainScheduleAdherenceHEADERMESSAGE_VERSION();
                    message_version.Value = this.HEADER.MESSAGE_VERSION;
                    header.MESSAGE_VERSION[0] = message_version;
                }
            }

            TrainScheduleAdherenceCONTENT content = new TrainScheduleAdherenceCONTENT();
            if (this.CONTENT != null)
            {
                if (this.CONTENT.SCAC != null) {
                    content.SCAC = new TrainScheduleAdherenceCONTENTSCAC[1];
                    TrainScheduleAdherenceCONTENTSCAC scac = new TrainScheduleAdherenceCONTENTSCAC();
                    scac.Value = this.CONTENT.SCAC;
                    content.SCAC[0] = scac;
                }
    
                if (this.CONTENT.SECTION != null) {
                    content.SECTION = new TrainScheduleAdherenceCONTENTSECTION[1];
                    TrainScheduleAdherenceCONTENTSECTION section = new TrainScheduleAdherenceCONTENTSECTION();
                    section.Value = this.CONTENT.SECTION;
                    content.SECTION[0] = section;
                }
    
                if (this.CONTENT.TRAIN_SYMBOL != null) {
                    content.TRAIN_SYMBOL = new TrainScheduleAdherenceCONTENTTRAIN_SYMBOL[1];
                    TrainScheduleAdherenceCONTENTTRAIN_SYMBOL train_symbol = new TrainScheduleAdherenceCONTENTTRAIN_SYMBOL();
                    train_symbol.Value = this.CONTENT.TRAIN_SYMBOL;
                    content.TRAIN_SYMBOL[0] = train_symbol;
                }
    
                if (this.CONTENT.ORIGIN_DATE != null) {
                    content.ORIGIN_DATE = new TrainScheduleAdherenceCONTENTORIGIN_DATE[1];
                    TrainScheduleAdherenceCONTENTORIGIN_DATE origin_date = new TrainScheduleAdherenceCONTENTORIGIN_DATE();
                    origin_date.Value = this.CONTENT.ORIGIN_DATE;
                    content.ORIGIN_DATE[0] = origin_date;
                }
    
                if (this.CONTENT.ADHERENCE != null) {
                    content.ADHERENCE = new TrainScheduleAdherenceCONTENTADHERENCE[1];
                    TrainScheduleAdherenceCONTENTADHERENCE adherence = new TrainScheduleAdherenceCONTENTADHERENCE();
                    adherence.Value = this.CONTENT.ADHERENCE;
                    content.ADHERENCE[0] = adherence;
                }
            }

            trainScheduleAdherence.Items[0] = header;
            trainScheduleAdherence.Items[1] = content;
            return trainScheduleAdherence;
        }
 
        public string toSteMessageHeader(string serializedXml) {
        	int from = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
        	int to   = serializedXml.LastIndexOf("</CONTENT>");
        	
        	string header = "PASSTHRU,MSCHADH,";
        	string result = header + serializedXml.Substring(from, to-from);
        	
        	return result;
        }
   }

    public partial class MIS_TrainScheduleAdherenceHEADER {
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

    public partial class MIS_TrainScheduleAdherenceCONTENT {
        private string thisSCAC = "";
        private string thisSECTION = "";
        private string thisTRAIN_SYMBOL = "";
        private string thisORIGIN_DATE = "";
        private string thisADHERENCE = "";

        public string SCAC {
            get { return this.thisSCAC; }
            set { this.thisSCAC = value; }
        }

        public string SECTION {
            get { return this.thisSECTION; }
            set { this.thisSECTION = value; }
        }

        public string TRAIN_SYMBOL {
            get { return this.thisTRAIN_SYMBOL; }
            set { this.thisTRAIN_SYMBOL = value; }
        }

        public string ORIGIN_DATE {
            get { return this.thisORIGIN_DATE; }
            set { this.thisORIGIN_DATE = value; }
        }

        public string ADHERENCE {
            get { return this.thisADHERENCE; }
            set { this.thisADHERENCE = value; }
        }

    }


    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class TrainScheduleAdherence  {
	    
	    private object[] itemsField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(TrainScheduleAdherenceCONTENT), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(TrainScheduleAdherenceHEADER), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("MSGINFO", typeof(TrainScheduleAdherenceMSGINFO), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
    public partial class TrainScheduleAdherenceCONTENT {
	    
	    private TrainScheduleAdherenceCONTENTSCAC[] sCACField;
	    
	    private TrainScheduleAdherenceCONTENTSECTION[] sECTIONField;
	    
	    private TrainScheduleAdherenceCONTENTTRAIN_SYMBOL[] tRAIN_SYMBOLField;
	    
	    private TrainScheduleAdherenceCONTENTORIGIN_DATE[] oRIGIN_DATEField;
	    
	    private TrainScheduleAdherenceCONTENTADHERENCE[] aDHERENCEField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceCONTENTSCAC[] SCAC {
	        get {
	            return this.sCACField;
	        }
	        set {
	            this.sCACField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceCONTENTSECTION[] SECTION {
	        get {
	            return this.sECTIONField;
	        }
	        set {
	            this.sECTIONField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceCONTENTTRAIN_SYMBOL[] TRAIN_SYMBOL {
	        get {
	            return this.tRAIN_SYMBOLField;
	        }
	        set {
	            this.tRAIN_SYMBOLField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceCONTENTORIGIN_DATE[] ORIGIN_DATE {
	        get {
	            return this.oRIGIN_DATEField;
	        }
	        set {
	            this.oRIGIN_DATEField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("ADHERENCE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceCONTENTADHERENCE[] ADHERENCE {
	        get {
	            return this.aDHERENCEField;
	        }
	        set {
	            this.aDHERENCEField = value;
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
    public partial class TrainScheduleAdherenceCONTENTSCAC {
	    
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
    public partial class TrainScheduleAdherenceCONTENTSECTION {
	    
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
    public partial class TrainScheduleAdherenceCONTENTTRAIN_SYMBOL {
	    
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
    public partial class TrainScheduleAdherenceCONTENTORIGIN_DATE {
	    
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
    public partial class TrainScheduleAdherenceCONTENTADHERENCE {
	    
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
    public partial class TrainScheduleAdherenceHEADER {
	    
	    private TrainScheduleAdherenceHEADERPROTOCOLID[] pROTOCOLIDField;
	    
	    private TrainScheduleAdherenceHEADERMSGID[] mSGIDField;
	    
	    private TrainScheduleAdherenceHEADERTRACE_ID[] tRACE_IDField;
	    
	    private TrainScheduleAdherenceHEADERMESSAGE_VERSION[] mESSAGE_VERSIONField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceHEADERPROTOCOLID[] PROTOCOLID {
	        get {
	            return this.pROTOCOLIDField;
	        }
	        set {
	            this.pROTOCOLIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceHEADERMSGID[] MSGID {
	        get {
	            return this.mSGIDField;
	        }
	        set {
	            this.mSGIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceHEADERTRACE_ID[] TRACE_ID {
	        get {
	            return this.tRACE_IDField;
	        }
	        set {
	            this.tRACE_IDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAdherenceHEADERMESSAGE_VERSION[] MESSAGE_VERSION {
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
    public partial class TrainScheduleAdherenceHEADERPROTOCOLID {
	    
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
    public partial class TrainScheduleAdherenceHEADERMSGID {
	    
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
    public partial class TrainScheduleAdherenceHEADERTRACE_ID {
	    
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
    public partial class TrainScheduleAdherenceHEADERMESSAGE_VERSION {
	    
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
    public partial class TrainScheduleAdherenceMSGINFO {
	    
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