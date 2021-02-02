using Env.Code_Utils;

namespace PDS_CORE.WebLogic
{
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RanorexStudio", "8.0.1+git.8a3e1a6f")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SmiBridgePortBinding", Namespace="http://ws.tms.trans.ge.com/")]
    public partial class SmiBridgeService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        
        /// <remarks/>
        public SmiBridgeService()
        {
        	VMEnvironment vm = VMEnvironment.Instance();
            this.Url = "https://"+vm.wapServer+":"+vm.port+"/trackline-initialization-ws/SmiBridgeService?wsdl";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.tms.trans.ge.com/", ResponseNamespace="http://ws.tms.trans.ge.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result", IsNullable=true)]
        public stringArray[] smiBridge([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aFactory, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aDomain, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aMethod, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aLanguage, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aUser, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aLogicalPosition, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string aClientId, [System.Xml.Serialization.XmlElementAttribute("anArguements", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)] stringArray[] anArguements)
        {
            object[] results = this.Invoke("smiBridge", new object[] {
                        aFactory,
                        aDomain,
                        aMethod,
                        aLanguage,
                        aUser,
                        aLogicalPosition,
                        aClientId,
                        anArguements});
            return ((stringArray[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginsmiBridge(string aFactory, string aDomain, string aMethod, string aLanguage, string aUser, string aLogicalPosition, string aClientId, stringArray[] anArguements, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("smiBridge", new object[] {
                        aFactory,
                        aDomain,
                        aMethod,
                        aLanguage,
                        aUser,
                        aLogicalPosition,
                        aClientId,
                        anArguements}, callback, asyncState);
        }
        
        /// <remarks/>
        public stringArray[] EndsmiBridge(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((stringArray[])(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RanorexStudio", "8.0.1+git.8a3e1a6f")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://jaxb.dev.java.net/array")]
    public partial class stringArray
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string[] item;
    }
}
