/*
 * Created by Ranorex
 * User: 502589202
 * Date: 10/23/2018
 * Time: 8:25 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Text;

namespace PDS_CORE.Code_Utils.Webservices
{
	/// <summary>
	/// Description of HeadlessAuthority.
	/// </summary>
	public class HeadlessAuthority
	{
		public HeadlessAuthority()
		{
		}
		
		
		public static string BuildAuthorityDataString(string fieldType, string keyValues)
        {
        	StringBuilder builder;
        	string xml = "";
        	string[] argumentList;
        	string key = "";
        	string value = "";
        	
        	
        	string data = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><StateInfo><FBA_MA>";
        	
        	
        	switch (fieldType)
        	{
        		case ("TO"):
        		case ("EMPLOYEE") :
        		{
        			//Should be TO_FIELD|value
        			argumentList = keyValues.Split('|');
        	        key = argumentList[0];
        	        value = argumentList[1];
        			xml = "<ADDRESSEE><EMPLOYEE><Value><Field>TO_FIELD</Field></Value></EMPLOYEE></ADDRESSEE>";
        			builder = new StringBuilder(xml);
        			builder.Replace("TO_FIELD", value);
        			data = data + builder.ToString();
        			break;
        		}
        		case ("AT"):
        		case ("LOCATION"):
        		{
        			//Should be AT_FIELD|value
        			argumentList = keyValues.Split('|');
        	        key = argumentList[0];
        	        value = argumentList[1];
        	        xml = "<LOCATION><Value><Field>AT_FIELD</Field></Value></LOCATION>";
        			builder = new StringBuilder(xml);
        			builder.Replace("AT_FIELD", value);
        			data = data + builder.ToString();
        			break;
        		}
        		case ("COPIED_BY"):
        		{
        			data = data + "<ISSUE><COPIED_BY><Value><Field>"+value+"</Field></Value></COPIED_BY></ISSUE>";
        		    break;
        		}
        	    case ("BOX6BEGIN"):
        		{
        		    xml = "<LIMITS><WORK><CHECK><Value><Field>Y</Field></Value></CHECK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>BOX6BEGIN_FIELD</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field/></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field/></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS>";
        		    builder = new StringBuilder(xml);
        		    builder.Replace("BOX6BEGIN_FIELD", value);
        		    data = data + builder.ToString();
        		    break;
        		}
        		case ("BOX6END"):
        		{
        			xml = "<LIMITS><WORK><WORK_LIMITS><SUBLINE id=\"31\"><BEGIN><POINT><Value><Field>BOX6BEGIN_FIELD</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"1782299552532421400\">CHAMPAIGN</Field></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></BEGIN><END><POINT><Value><Field>BOX6END_FIELD</Field></Value></POINT><INCLUDE><Value><Field>N</Field></Value></INCLUDE><NAMED_BOUNDARY><Value><Field id=\"0\"/></Value></NAMED_BOUNDARY><SHOW_INCLUDE_DIALOG><Value><Field>N</Field></Value></SHOW_INCLUDE_DIALOG><RESPONSE><Value><Field>N</Field></Value></RESPONSE></END><TRACK><Value><Field/></Value></TRACK></SUBLINE></WORK_LIMITS></WORK></LIMITS>";
        		    builder = new StringBuilder(xml);
        		    builder.Replace("BOX6BEGIN_FIELD", value);
        		    data = data + builder.ToString();
        		    break;
        		}

        			

        	    default:
        			break;

        	}
        	
        	
        	
        	data = data + "</FBA_MA></StateInfo>";
        	return data;
        	
        }
	}
}
