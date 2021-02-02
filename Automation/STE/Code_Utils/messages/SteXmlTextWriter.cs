/*
 * Created by Ranorex
 * User: r07000021
 * Date: 12/6/2017
 * Time: 11:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace STE.Code_Utils.messages
{
    /// <summary>
    /// Description of SteXmlTextWriter.
    /// </summary>
    public class SteXmlTextWriter : XmlTextWriter
    {
        public SteXmlTextWriter(Stream stream) : base(stream, Encoding.UTF8)
	    {
	
	    }
	
	    public override void WriteEndElement()
	    {
	        base.WriteFullEndElement();
	    }
	}
}
