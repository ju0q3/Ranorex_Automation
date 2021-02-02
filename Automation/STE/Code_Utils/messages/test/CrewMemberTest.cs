/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/2/2017
 * Time: 2:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Xml.Serialization;

using STE.Code_Utils.messages.MIS.CN;

namespace STE.Code_Utils.messages.test
{
	/// <summary>
	/// Description of CrewMemberTest.
	/// ";
	public class CrewMemberTest
	{
		public CrewMemberTest()
		{
		}
		
		public CrewMemberConfig xmlToObject()
		{
			CrewMemberConfig crewMember;
			XmlSerializer serializer = new XmlSerializer(typeof(CrewMemberConfig));
			FileStream stream = new FileStream("C:/Ste/Runtime/stesim/intmsg/RawMIS/20170926125716_100_CrewMember.xml", FileMode.Open);
			crewMember = (CrewMemberConfig) serializer.Deserialize(stream);

			CrewMemberConfigHEADER header = (CrewMemberConfigHEADER) crewMember.Items[0];
			string protocol = header.PROTOCOLID[0].Value;
			string msgid = header.MSGID[0].Value;

			
			CrewMemberConfigCONTENT content = (CrewMemberConfigCONTENT) crewMember.Items[1];
			string scac = content.SCAC[0].Value;
			string section = content.SECTION[0].Value;
			string trainSymbol = content.TRAIN_SYMBOL[0].Value;
			string originDate = content.ORIGIN_DATE[0].Value;
			string crewId = content.CREW_ID[0].Value;
			string crewLineSegment = content.CREW_LINE_SEGMENT[0].Value;
			string sequenceNumber = content.SEQUENCE_NUMBER[0].Value;
			string numberOfCrewMembers = content.NUMBER_OF_CREW_MEMBERS[0].Value;

			StreamWriter outstream = new StreamWriter(@"C:/Users/r07000021/AppData/Local/Temp/Joe.xml");
			serializer.Serialize(outstream, crewMember);
			
		    return crewMember;
		}
		
		public static T DeserializeXMLFileToObject<T>(string XmlFilename)
	    {
	        T returnObject = default(T);
	        if (string.IsNullOrEmpty(XmlFilename)) return default(T);
	
	        try
	        {
	            StreamReader xmlStream = new StreamReader(XmlFilename);
	            XmlSerializer serializer = new XmlSerializer(typeof(T));
	            returnObject = (T)serializer.Deserialize(xmlStream);
	        }
	        catch (Exception ex)
	        {
	            String error = ex.ToString();
	        }
	        return returnObject;
	    }
	}
}
