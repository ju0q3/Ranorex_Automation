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
namespace STE.Code_Utils.messages.MIS.CN
{
    public partial class MIS_DeleteTrainScheduleConfig {
        private string thisMSGINFO;
        private MIS_DeleteTrainScheduleConfigHEADER thisHEADER;
        private MIS_DeleteTrainScheduleConfigCONTENT thisCONTENT;

        public string MSGINFO {
            get { return this.thisMSGINFO; }
            set { this.thisMSGINFO = value; }
        }

        public MIS_DeleteTrainScheduleConfigHEADER HEADER {
            get { return this.thisHEADER; }
            set { this.thisHEADER = value; }
        }

        public MIS_DeleteTrainScheduleConfigCONTENT CONTENT {
            get { return this.thisCONTENT; }
            set { this.thisCONTENT = value; }
        }


        private static MIS_DeleteTrainScheduleConfig buildDeleteTrainScheduleConfig(
            string scac, 
            string section, 
            string trainsymbol
        ) {
            MIS_DeleteTrainScheduleConfig deleteTrainScheduleConfig = new MIS_DeleteTrainScheduleConfig();

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            System.DateTime now = System.DateTime.Now;

            MIS_DeleteTrainScheduleConfigCONTENT content = new MIS_DeleteTrainScheduleConfigCONTENT();
            content.SCAC = scac;
            content.SECTION = section;
            content.TRAINSYMBOL = trainsymbol;
            content.ORIGINDATE = now.ToString("MMddyyyy");

            deleteTrainScheduleConfig.CONTENT = content;

            return deleteTrainScheduleConfig;
        }

        public static void createDeleteTrainScheduleConfig(
            string scac, 
            string section, 
            string trainsymbol
        ) {
        	MIS_DeleteTrainScheduleConfig deleteTrainScheduleConfig = buildDeleteTrainScheduleConfig(scac, section, trainsymbol);

        	string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            FileStream fs;
            string request = "";
            
            DeleteTrainScheduleConfig deletetrainscheduleconfig = deleteTrainScheduleConfig.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(DeleteTrainScheduleConfig));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, deletetrainscheduleconfig);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = deleteTrainScheduleConfig.toSteMessageHeader(request);
            System.IO.File.WriteAllText(SteUtils.getOutboundDir()+SteUtils.getFileName(), request);
        }

        public static void createDeleteTrainScheduleConfigMsmq(
            string scac, 
            string section, 
            string trainsymbol
        ) {
            MIS_DeleteTrainScheduleConfig deleteTrainScheduleConfig = buildDeleteTrainScheduleConfig(scac, section, trainsymbol);

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            string request = "";
            
            DeleteTrainScheduleConfig deletetrainscheduleconfig = deleteTrainScheduleConfig.toSerializableObject();
            serializer = new XmlSerializer(typeof(DeleteTrainScheduleConfig));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, deletetrainscheduleconfig);
            request = deleteTrainScheduleConfig.toSteMessageHeader(writer.ToString());
            SteMessageQueue.Instance().Send(request, "MIS-DeleteTrainScheduleConfig");
        }

         public static void createDeleteTrainScheduleConfigRemote(
            string scac, 
            string section, 
            string trainsymbol,
            string hostname
        ) {
        	int receiver_port = 2500;
        	
        	MIS_DeleteTrainScheduleConfig deleteTrainScheduleConfig = buildDeleteTrainScheduleConfig(scac, section, trainsymbol);
        	
        	string temp = System.Environment.GetEnvironmentVariable("TEMP");
            XmlSerializer serializer;
            FileStream fs;
            string request = "";

            DeleteTrainScheduleConfig deletetrainscheduleconfig = deleteTrainScheduleConfig.toSerializableObject();
            fs = File.Create(temp+"/temp.request");
            serializer = new XmlSerializer(typeof(DeleteTrainScheduleConfig));
            var writer = new SteXmlTextWriter(fs);
            serializer.Serialize(writer, deletetrainscheduleconfig);
            fs.Close();

            request = File.ReadAllText(temp+"/temp.request");
            request = deleteTrainScheduleConfig.toSteMessageHeader(request, true);
            
            using(TcpClient tcp = new TcpClient(hostname, receiver_port)) {
                NetworkStream nw = tcp.GetStream();
                nw.ReadTimeout = 5000; //5 second timeout for read response
                
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(request); 
                Ranorex.Report.Info(String.Format("Encoding Message {0} for STE {1}:2500",request, hostname));
                nw.Write(data, 0, data.Length);
                
                Thread.Sleep(5);
                nw.Close();
            }
        }
       
        public DeleteTrainScheduleConfig toSerializableObject() {
            DeleteTrainScheduleConfig deleteTrainScheduleConfig = new DeleteTrainScheduleConfig();
            deleteTrainScheduleConfig.Items = new object[2];

            DeleteTrainScheduleConfigHEADER header = new DeleteTrainScheduleConfigHEADER();
            if (this.HEADER != null)
            {
                if (this.HEADER.PROTOCOLID != null) {
                    header.PROTOCOLID = new DeleteTrainScheduleConfigHEADERPROTOCOLID[1];
                    DeleteTrainScheduleConfigHEADERPROTOCOLID protocolid = new DeleteTrainScheduleConfigHEADERPROTOCOLID();
                    protocolid.Value = this.HEADER.PROTOCOLID;
                    header.PROTOCOLID[0] = protocolid;
                }
    
                if (this.HEADER.MSGID != null) {
                    header.MSGID = new DeleteTrainScheduleConfigHEADERMSGID[1];
                    DeleteTrainScheduleConfigHEADERMSGID msgid = new DeleteTrainScheduleConfigHEADERMSGID();
                    msgid.Value = this.HEADER.MSGID;
                    header.MSGID[0] = msgid;
                }
    
                if (this.HEADER.TRACE_ID != null) {
                    header.TRACE_ID = new DeleteTrainScheduleConfigHEADERTRACE_ID[1];
                    DeleteTrainScheduleConfigHEADERTRACE_ID trace_id = new DeleteTrainScheduleConfigHEADERTRACE_ID();
                    trace_id.Value = this.HEADER.TRACE_ID;
                    header.TRACE_ID[0] = trace_id;
                }
    
                if (this.HEADER.MESSAGE_VERSION != null) {
                    header.MESSAGE_VERSION = new DeleteTrainScheduleConfigHEADERMESSAGE_VERSION[1];
                    DeleteTrainScheduleConfigHEADERMESSAGE_VERSION message_version = new DeleteTrainScheduleConfigHEADERMESSAGE_VERSION();
                    message_version.Value = this.HEADER.MESSAGE_VERSION;
                    header.MESSAGE_VERSION[0] = message_version;
                }
            }

            DeleteTrainScheduleConfigCONTENT content = new DeleteTrainScheduleConfigCONTENT();
            if (this.CONTENT != null)
            {
                if (this.CONTENT.SCAC != null) {
                    content.SCAC = new DeleteTrainScheduleConfigCONTENTSCAC[1];
                    DeleteTrainScheduleConfigCONTENTSCAC scac = new DeleteTrainScheduleConfigCONTENTSCAC();
                    scac.Value = this.CONTENT.SCAC;
                    content.SCAC[0] = scac;
                }
    
                if (this.CONTENT.SECTION != null) {
                    content.SECTION = new DeleteTrainScheduleConfigCONTENTSECTION[1];
                    DeleteTrainScheduleConfigCONTENTSECTION section = new DeleteTrainScheduleConfigCONTENTSECTION();
                    section.Value = this.CONTENT.SECTION;
                    content.SECTION[0] = section;
                }
    
                if (this.CONTENT.TRAINSYMBOL != null) {
                    content.TRAINSYMBOL = new DeleteTrainScheduleConfigCONTENTTRAINSYMBOL[1];
                    DeleteTrainScheduleConfigCONTENTTRAINSYMBOL trainsymbol = new DeleteTrainScheduleConfigCONTENTTRAINSYMBOL();
                    trainsymbol.Value = this.CONTENT.TRAINSYMBOL;
                    content.TRAINSYMBOL[0] = trainsymbol;
                }
    
                if (this.CONTENT.ORIGINDATE != null) {
                    content.ORIGINDATE = new DeleteTrainScheduleConfigCONTENTORIGINDATE[1];
                    DeleteTrainScheduleConfigCONTENTORIGINDATE origindate = new DeleteTrainScheduleConfigCONTENTORIGINDATE();
                    origindate.Value = this.CONTENT.ORIGINDATE;
                    content.ORIGINDATE[0] = origindate;
                }
            }

            deleteTrainScheduleConfig.Items[0] = header;
            deleteTrainScheduleConfig.Items[1] = content;
            return deleteTrainScheduleConfig;
        }

        public string toSteMessageHeader(string serializedXml, bool remote = false) {
        	int from = serializedXml.IndexOf("<CONTENT>") + "<CONTENT>".Length;
        	int to   = serializedXml.LastIndexOf("</CONTENT>");
            
            string header = "";
            
            if (!remote)
            {
                header = "PASSTHRU,MTRNTSA";
            }
            else
            {
                header = "RanorexAgent:PASSTHRU,MTRNTSA,";
            }
        	string result = header + serializedXml.Substring(from, to-from);
        	
        	return result;
        }
    }

    public partial class MIS_DeleteTrainScheduleConfigHEADER {
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

    public partial class MIS_DeleteTrainScheduleConfigCONTENT {
        private string thisSCAC = "";
        private string thisSECTION = "";
        private string thisTRAINSYMBOL = "";
        private string thisORIGINDATE = "";

        public string SCAC {
            get { return this.thisSCAC; }
            set { this.thisSCAC = value; }
        }

        public string SECTION {
            get { return this.thisSECTION; }
            set { this.thisSECTION = value; }
        }

        public string TRAINSYMBOL {
            get { return this.thisTRAINSYMBOL; }
            set { this.thisTRAINSYMBOL = value; }
        }

        public string ORIGINDATE {
            get { return this.thisORIGINDATE; }
            set { this.thisORIGINDATE = value; }
        }

    }


    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class DeleteTrainScheduleConfig  {
	    
	    private object[] itemsField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("CONTENT", typeof(DeleteTrainScheduleConfigCONTENT), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("HEADER", typeof(DeleteTrainScheduleConfigHEADER), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    [System.Xml.Serialization.XmlElementAttribute("MSGINFO", typeof(DeleteTrainScheduleConfigMSGINFO), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
    public partial class DeleteTrainScheduleConfigCONTENT {
	    
	    private DeleteTrainScheduleConfigCONTENTSCAC[] sCACField;
	    
	    private DeleteTrainScheduleConfigCONTENTSECTION[] sECTIONField;
	    
	    private DeleteTrainScheduleConfigCONTENTTRAINSYMBOL[] tRAINSYMBOLField;
	    
	    private DeleteTrainScheduleConfigCONTENTORIGINDATE[] oRIGINDATEField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SCAC", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigCONTENTSCAC[] SCAC {
	        get {
	            return this.sCACField;
	        }
	        set {
	            this.sCACField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("SECTION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigCONTENTSECTION[] SECTION {
	        get {
	            return this.sECTIONField;
	        }
	        set {
	            this.sECTIONField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRAINSYMBOL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigCONTENTTRAINSYMBOL[] TRAINSYMBOL {
	        get {
	            return this.tRAINSYMBOLField;
	        }
	        set {
	            this.tRAINSYMBOLField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("ORIGINDATE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigCONTENTORIGINDATE[] ORIGINDATE {
	        get {
	            return this.oRIGINDATEField;
	        }
	        set {
	            this.oRIGINDATEField = value;
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
    public partial class DeleteTrainScheduleConfigCONTENTSCAC {
	    
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
    public partial class DeleteTrainScheduleConfigCONTENTSECTION {
	    
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
    public partial class DeleteTrainScheduleConfigCONTENTTRAINSYMBOL {
	    
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
    public partial class DeleteTrainScheduleConfigCONTENTORIGINDATE {
	    
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
    public partial class DeleteTrainScheduleConfigHEADER {
	    
	    private DeleteTrainScheduleConfigHEADERPROTOCOLID[] pROTOCOLIDField;
	    
	    private DeleteTrainScheduleConfigHEADERMSGID[] mSGIDField;
	    
	    private DeleteTrainScheduleConfigHEADERTRACE_ID[] tRACE_IDField;
	    
	    private DeleteTrainScheduleConfigHEADERMESSAGE_VERSION[] mESSAGE_VERSIONField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("PROTOCOLID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigHEADERPROTOCOLID[] PROTOCOLID {
	        get {
	            return this.pROTOCOLIDField;
	        }
	        set {
	            this.pROTOCOLIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MSGID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigHEADERMSGID[] MSGID {
	        get {
	            return this.mSGIDField;
	        }
	        set {
	            this.mSGIDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("TRACE_ID", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigHEADERTRACE_ID[] TRACE_ID {
	        get {
	            return this.tRACE_IDField;
	        }
	        set {
	            this.tRACE_IDField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("MESSAGE_VERSION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public DeleteTrainScheduleConfigHEADERMESSAGE_VERSION[] MESSAGE_VERSION {
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
    public partial class DeleteTrainScheduleConfigHEADERPROTOCOLID {
	    
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
    public partial class DeleteTrainScheduleConfigHEADERMSGID {
	    
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
    public partial class DeleteTrainScheduleConfigHEADERTRACE_ID {
	    
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
    public partial class DeleteTrainScheduleConfigHEADERMESSAGE_VERSION {
	    
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
    public partial class DeleteTrainScheduleConfigMSGINFO {
	    
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