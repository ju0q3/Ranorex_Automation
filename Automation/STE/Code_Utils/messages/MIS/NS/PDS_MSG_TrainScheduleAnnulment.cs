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
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using STE.Code_Utils.MessageQueues;

// 
// This source code was auto-generated by xsd, Version=4.7.2556.0.
// 
namespace STE.Code_Utils.messages.MIS.NS
{
    public partial class MIS_TrainScheduleAnnulmentConfig {
        private string thisMSGINFO;
		private string thisJSONHeader;
        private MIS_TrainScheduleAnnulmentConfigHEADER thisHEADER;
        private MIS_TrainScheduleAnnulmentConfigCONTENT thisCONTENT;

        public string MSGINFO {
            get { return this.thisMSGINFO; }
            set { this.thisMSGINFO = value; }
        }
        
        public string JSONHeader {
            get { return this.thisJSONHeader; }
            set { this.thisJSONHeader = value; }
        }

        public MIS_TrainScheduleAnnulmentConfigHEADER HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public MIS_TrainScheduleAnnulmentConfigCONTENT CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }

        private static MIS_TrainScheduleAnnulmentConfig buildTrainScheduleAnnulmentConfig(
            string scac, 
            string section, 
            string train_symbol,
            string originDate = ""
        ) {
            MIS_TrainScheduleAnnulmentConfig trainScheduleAnnulmentConfig = new MIS_TrainScheduleAnnulmentConfig();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            System.DateTime now = System.DateTime.Now;

            MIS_TrainScheduleAnnulmentConfigCONTENT content = new MIS_TrainScheduleAnnulmentConfigCONTENT();
            content.SCAC = scac;
            content.SECTION = section;
            if (scac.ToUpper().Equals("CN"))
            {
              content.TRAIN_SYMBOL = train_symbol.Substring(0, train_symbol.Length - 1);
              
            }
            else
            {
                content.TRAIN_SYMBOL = train_symbol;
            }
            if (String.IsNullOrEmpty(originDate))
            {
                content.ORIGIN_DATE = now.ToString("MMddyyyy");
            }
            else
            {
                // If only the day code is passed in, create the remaining part of the date
                if (originDate.Length == 2)
                {
                    content.ORIGIN_DATE = now.ToString("MM") + originDate + now.ToString("yyyy");
                }
                // if anything else is passed in, assume it is the full date string
                else
                {
                    content.ORIGIN_DATE = originDate;
                }
            }

            trainScheduleAnnulmentConfig.CONTENT = content;
            
            return trainScheduleAnnulmentConfig;
        }

        public static void createTrainScheduleAnnulmentConfig(
            string scac, 
            string section, 
            string train_symbol,
            string dateDay = ""
        ) {
            MIS_TrainScheduleAnnulmentConfig trainScheduleAnnulmentConfig = buildTrainScheduleAnnulmentConfig(scac, section, train_symbol, dateDay);

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            FileStream fs;
            string request = "";

            TrainScheduleAnnulmentConfig trainscheduleannulmentconfig = trainScheduleAnnulmentConfig.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(TrainScheduleAnnulmentConfig));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, trainscheduleannulmentconfig);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = trainScheduleAnnulmentConfig.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createTrainScheduleAnnulmentConfigMsmq(
            string scac, 
            string section, 
            string train_symbol
        ) {
        	MIS_TrainScheduleAnnulmentConfig trainScheduleAnnulmentConfig = buildTrainScheduleAnnulmentConfig(scac, section, train_symbol);

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            string request = "";

            TrainScheduleAnnulmentConfig trainscheduleannulmentconfig = trainScheduleAnnulmentConfig.toSerializableObject();
            serializer = new XmlSerializer(typeof(TrainScheduleAnnulmentConfig));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, trainscheduleannulmentconfig);
            request = trainScheduleAnnulmentConfig.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "MIS-TrainScheduleAnnulmentConfig");
        }

        public static void createTrainScheduleAnnulmentConfigRemote(
            string scac, 
            string section, 
            string train_symbol,
            string hostname,
            string originDate
        ) {
        	
            MIS_TrainScheduleAnnulmentConfig trainScheduleAnnulmentConfig = buildTrainScheduleAnnulmentConfig(scac, section, train_symbol, originDate);

			trainScheduleAnnulmentConfig.JSONHeader="{  \"CMD\":\"SendTo\",  \"Destination\":\"MQServer\",  \"MSGID\"\":\"TrainScheduleAnnulment\",  \"Queue\"\":\"Auto\"}";
            
            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            FileStream fs;
            string request = "";

            TrainScheduleAnnulmentConfig trainscheduleannulmentconfig = trainScheduleAnnulmentConfig.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(TrainScheduleAnnulmentConfig));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, trainscheduleannulmentconfig);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = trainScheduleAnnulmentConfig.toSteMessageHeader(request);
            
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
           
        }

        public TrainScheduleAnnulmentConfig toSerializableObject() {
            TrainScheduleAnnulmentConfig trainScheduleAnnulmentConfig = new TrainScheduleAnnulmentConfig();
            trainScheduleAnnulmentConfig.Items = new object[2];

            TrainScheduleAnnulmentConfigHEADER header = new TrainScheduleAnnulmentConfigHEADER();
            if (this.HEADER != null)
            {
                if (this.HEADER.PROTOCOLID != null) {
                    header.PROTOCOLID = new TrainScheduleAnnulmentConfigHEADERPROTOCOLID[1];
                    TrainScheduleAnnulmentConfigHEADERPROTOCOLID protocolid = new TrainScheduleAnnulmentConfigHEADERPROTOCOLID();
                    protocolid.Value = this.HEADER.PROTOCOLID;
                    header.PROTOCOLID[0] = protocolid;
                }
    
                if (this.HEADER.MSGID != null) {
                    header.MSGID = new TrainScheduleAnnulmentConfigHEADERMSGID[1];
                    TrainScheduleAnnulmentConfigHEADERMSGID msgid = new TrainScheduleAnnulmentConfigHEADERMSGID();
                    msgid.Value = this.HEADER.MSGID;
                    header.MSGID[0] = msgid;
                }
    
                if (this.HEADER.TRACE_ID != null) {
                    header.TRACE_ID = new TrainScheduleAnnulmentConfigHEADERTRACE_ID[1];
                    TrainScheduleAnnulmentConfigHEADERTRACE_ID trace_id = new TrainScheduleAnnulmentConfigHEADERTRACE_ID();
                    trace_id.Value = this.HEADER.TRACE_ID;
                    header.TRACE_ID[0] = trace_id;
                }
    
                if (this.HEADER.MESSAGE_VERSION != null) {
                    header.MESSAGE_VERSION = new TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION[1];
                    TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION message_version = new TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION();
                    message_version.Value = this.HEADER.MESSAGE_VERSION;
                    header.MESSAGE_VERSION[0] = message_version;
                }
            }

            TrainScheduleAnnulmentConfigCONTENT content = new TrainScheduleAnnulmentConfigCONTENT();
            if (this.CONTENT != null)
            {
                if (this.CONTENT.SCAC != null) {
                    content.SCAC = new TrainScheduleAnnulmentConfigCONTENTSCAC[1];
                    TrainScheduleAnnulmentConfigCONTENTSCAC scac = new TrainScheduleAnnulmentConfigCONTENTSCAC();
                    scac.Value = this.CONTENT.SCAC;
                    content.SCAC[0] = scac;
                }
    
                if (this.CONTENT.SECTION != null) {
                    content.SECTION = new TrainScheduleAnnulmentConfigCONTENTSECTION[1];
                    TrainScheduleAnnulmentConfigCONTENTSECTION section = new TrainScheduleAnnulmentConfigCONTENTSECTION();
                    section.Value = this.CONTENT.SECTION;
                    content.SECTION[0] = section;
                }
    
                if (this.CONTENT.TRAIN_SYMBOL != null) {
                    content.TRAIN_SYMBOL = new TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL[1];
                    TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL train_symbol = new TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL();
                    train_symbol.Value = this.CONTENT.TRAIN_SYMBOL;
                    content.TRAIN_SYMBOL[0] = train_symbol;
                }
    
                if (this.CONTENT.ORIGIN_DATE != null) {
                    content.ORIGIN_DATE = new TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE[1];
                    TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE origin_date = new TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE();
                    origin_date.Value = this.CONTENT.ORIGIN_DATE;
                    content.ORIGIN_DATE[0] = origin_date;
                }
            }

            trainScheduleAnnulmentConfig.Items[0] = header;
            trainScheduleAnnulmentConfig.Items[1] = content;
            return trainScheduleAnnulmentConfig;
        }

        public string toSteMessageHeader(string serializedXml, bool remote = false) {
        	int from = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
        	int to   = serializedXml.LastIndexOf("</CONTENT>");
        	
        	string header = "";
        	
        	if (!remote)
        	{
        	    header = "PASSTHRU,MTRNTSA,";
        	}
        	else
        	{
        	    header = "RanorexAgent:PASSTHRU,MTRNTSA,";
        	}
        	string result = header + serializedXml.Substring(from, to-from);
        	
        	return result;
        }
    }

    public partial class MIS_TrainScheduleAnnulmentConfigHEADER {
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

    public partial class MIS_TrainScheduleAnnulmentConfigCONTENT {
        private string thisSCAC = "";
        private string thisSECTION = "";
        private string thisTRAIN_SYMBOL = "";
        private string thisORIGIN_DATE = "";

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

    }


    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class TrainScheduleAnnulmentConfig {
	    
	    private object[] itemsField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(TrainScheduleAnnulmentConfigCONTENT), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(TrainScheduleAnnulmentConfigHEADER), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("MSGINFO", typeof(TrainScheduleAnnulmentConfigMSGINFO), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
    public partial class TrainScheduleAnnulmentConfigCONTENT {
	    
	    private TrainScheduleAnnulmentConfigCONTENTSCAC[] sCACField;
	    
	    private TrainScheduleAnnulmentConfigCONTENTSECTION[] sECTIONField;
	    
	    private TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL[] tRAIN_SYMBOLField;
	    
	    private TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE[] oRIGIN_DATEField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigCONTENTSCAC[] SCAC {
	        get {
	            return this.sCACField;
	        }
	        set {
	            this.sCACField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigCONTENTSECTION[] SECTION {
	        get {
	            return this.sECTIONField;
	        }
	        set {
	            this.sECTIONField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRAIN_SYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL[] TRAIN_SYMBOL {
	        get {
	            return this.tRAIN_SYMBOLField;
	        }
	        set {
	            this.tRAIN_SYMBOLField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("ORIGIN_DATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE[] ORIGIN_DATE {
	        get {
	            return this.oRIGIN_DATEField;
	        }
	        set {
	            this.oRIGIN_DATEField = value;
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
    public partial class TrainScheduleAnnulmentConfigCONTENTSCAC {
	    
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
    public partial class TrainScheduleAnnulmentConfigCONTENTSECTION {
	    
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
    public partial class TrainScheduleAnnulmentConfigCONTENTTRAIN_SYMBOL {
	    
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
    public partial class TrainScheduleAnnulmentConfigCONTENTORIGIN_DATE {
	    
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
    public partial class TrainScheduleAnnulmentConfigHEADER {
	    
	    private TrainScheduleAnnulmentConfigHEADERPROTOCOLID[] pROTOCOLIDField;
	    
	    private TrainScheduleAnnulmentConfigHEADERMSGID[] mSGIDField;
	    
	    private TrainScheduleAnnulmentConfigHEADERTRACE_ID[] tRACE_IDField;
	    
	    private TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION[] mESSAGE_VERSIONField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigHEADERPROTOCOLID[] PROTOCOLID {
	        get {
	            return this.pROTOCOLIDField;
	        }
	        set {
	            this.pROTOCOLIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigHEADERMSGID[] MSGID {
	        get {
	            return this.mSGIDField;
	        }
	        set {
	            this.mSGIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigHEADERTRACE_ID[] TRACE_ID {
	        get {
	            return this.tRACE_IDField;
	        }
	        set {
	            this.tRACE_IDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION[] MESSAGE_VERSION {
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
    public partial class TrainScheduleAnnulmentConfigHEADERPROTOCOLID {
	    
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
    public partial class TrainScheduleAnnulmentConfigHEADERMSGID {
	    
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
    public partial class TrainScheduleAnnulmentConfigHEADERTRACE_ID {
	    
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
    public partial class TrainScheduleAnnulmentConfigHEADERMESSAGE_VERSION {
	    
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
    public partial class TrainScheduleAnnulmentConfigMSGINFO {
	    
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