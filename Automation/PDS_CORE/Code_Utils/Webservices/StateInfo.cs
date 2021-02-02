using System;
using System.Collections.Generic;
using System.Xml;

namespace PDS_CORE.Code_Utils.Webservices
{
	/// <summary>
	/// Description of StateInfo.
	/// </summary>
	public class StateInfo
	{
		public FBA_MARecord FBA_MA;
		
		public StateInfo()
		{
		}
		
		//loadXML will take the StateInfo xml received from the server and fill in a partial StateInfo object.
		//This will only support a R/W Line 6 authority.  It can be expanded later should the need arise, but going minimalist 
		//approach for load/performance
		public static StateInfo loadXml(string xml)
		{
			if (xml == null)
			{
				return null;
			}
			
			StateInfo stateInfo = new StateInfo();
			
			XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            
            XmlNode fba_ma = root.SelectSingleNode("FBA_MA");
            if (fba_ma != null)
            {
            	FBA_MARecord FBA_MA = new FBA_MARecord();
            	FBA_MA.id = fba_ma.Attributes["id"].Value;
            	
            	//ADDRESSEE INFO
            	ADDRESSEERecord ADDRESSEE = new ADDRESSEERecord();
            	
            	ADDRESSEE.ADDRESSEE_TYPE = fba_ma.SelectSingleNode(".//ADDRESSEE/ADDRESSEE_TYPE/Value/Field").InnerText.ToString();
            	ADDRESSEE.EMPLOYEE = fba_ma.SelectSingleNode(".//ADDRESSEE/EMPLOYEE/Value/Field").InnerText.ToString();

            	FBA_MA.ADDRESSEE = ADDRESSEE;
            	
            	//LOCATION INFO
            	FBA_MA.LOCATION = fba_ma.SelectSingleNode(".//LOCATION/Value/Field").InnerText.ToString();
            	
            	//LIMITS
            	LIMITSRecord LIMITS = new LIMITSRecord();
            	WORKRecord WORK = new WORKRecord();
            	WORK.CHECK =  fba_ma.SelectSingleNode(".//LIMITS/WORK/CHECK/Value/Field").InnerText.ToString();
            	
            	WORK_LIMITSRecord WORK_LIMITS = new WORK_LIMITSRecord();
            	
            	
            	XmlNodeList sublines = fba_ma.SelectNodes(".//LIMITS/WORK/WORK_LIMITS/SUBLINE");
            	for (int i = 0; i < sublines.Count; i++)
            	{
            		if (sublines[i].Attributes["id"].Value == "31")
            		{
            			SUBLINE_31Record SUBLINE = new SUBLINE_31Record();
            			SUBLINE.SUBLINE_id = sublines[i].Attributes["id"].Value;
            				
		            	BEGINRecord BEGIN = new BEGINRecord();
		            	BEGIN.POINT = sublines[i].SelectSingleNode(".//BEGIN/POINT/Value/Field").InnerText.ToString();
		            	BEGIN.INCLUDE = sublines[i].SelectSingleNode(".//BEGIN/INCLUDE/Value/Field").InnerText.ToString();
		            	BEGIN.NAMED_BOUNDARY = sublines[i].SelectSingleNode(".//BEGIN/NAMED_BOUNDARY/Value/Field").InnerText.ToString();
		            	BEGIN.NAMED_BOUNDARY_id = sublines[i].SelectSingleNode(".//BEGIN/NAMED_BOUNDARY/Value/Field").Attributes["id"].Value;
		            	BEGIN.SHOW_INCLUDE_DIALOG = sublines[i].SelectSingleNode(".//BEGIN/SHOW_INCLUDE_DIALOG/Value/Field").InnerText.ToString();
		            	BEGIN.RESPONSE = sublines[i].SelectSingleNode(".//BEGIN/RESPONSE/Value/Field").InnerText.ToString();
		            	SUBLINE.BEGIN = BEGIN;
		            	
		            	ENDRecord END = new ENDRecord();
		            	END.POINT = sublines[i].SelectSingleNode(".//END/POINT/Value/Field").InnerText.ToString();
		            	END.INCLUDE = sublines[i].SelectSingleNode(".//END/INCLUDE/Value/Field").InnerText.ToString();
		            	END.NAMED_BOUNDARY = sublines[i].SelectSingleNode(".//END/NAMED_BOUNDARY/Value/Field").InnerText.ToString();
		            	END.NAMED_BOUNDARY_id = sublines[i].SelectSingleNode(".//END/NAMED_BOUNDARY/Value/Field").Attributes["id"].Value;
		            	END.SHOW_INCLUDE_DIALOG = sublines[i].SelectSingleNode(".//END/SHOW_INCLUDE_DIALOG/Value/Field").InnerText.ToString();
		            	END.RESPONSE = sublines[i].SelectSingleNode(".//END/RESPONSE/Value/Field").InnerText.ToString();
		            	SUBLINE.END = END;
		            	
		            	SUBLINE.TRACK = sublines[i].SelectSingleNode(".//TRACK/Value/Field").InnerText.ToString();
		            	
		            	WORK_LIMITS.SUBLINE.Add(SUBLINE);
            		}
            	}
            		

            	
            	WORK.WORK_LIMITS = WORK_LIMITS;
            	LIMITS.WORK = WORK;
            	FBA_MA.LIMITS = LIMITS;
            	
            	
            	FBA_MA.ISSUE_BTN = fba_ma.SelectSingleNode(".//ISSUE_BTN/Value/Field").InnerText.ToString();
            	
            	
            	if (fba_ma.SelectSingleNode(".//CONTINUE_BTN/Value/Field") != null)
            	{
            	    FBA_MA.CONTINUE_BTN = fba_ma.SelectSingleNode(".//CONTINUE_BTN/Value/Field").InnerText.ToString();
            	}
            	
            	if (fba_ma.SelectSingleNode(".//ACKNOWLEDGED_BTN/Value/Field") != null)
            	{
            	    FBA_MA.ACKNOWLEDGED_BTN = fba_ma.SelectSingleNode(".//ACKNOWLEDGED_BTN/Value/Field").InnerText.ToString();            	
            	}
            	
            	stateInfo.FBA_MA = FBA_MA;
            }
			
			
			return stateInfo;
		}
	}
	
	public class FBA_MARecord
	{
		public string id;
		public ADDRESSEERecord ADDRESSEE;
	    public string LOCATION;
	    public LIMITSRecord LIMITS;
	    public string ISSUE_BTN;
	    public string CONTINUE_BTN;
	    public string ACKNOWLEDGED_BTN;
		
		public FBA_MARecord()
		{
			
		}
	}
	
	public class ADDRESSEERecord
	{
		public string ADDRESSEE_TYPE;
		public string EMPLOYEE;
		
		public ADDRESSEERecord()
		{
			
		}
	}
	
	
	public class LIMITSRecord
	{
		public WORKRecord WORK;
		
		public LIMITSRecord()
		{
			
		}
	}
	
	public class WORKRecord
	{
		public string CHECK;
		public WORK_LIMITSRecord WORK_LIMITS;
		
		public WORKRecord()
		{
			
		}
	}
	
	public class WORK_LIMITSRecord
	{
		public List<SUBLINE_31Record> SUBLINE = new List<SUBLINE_31Record>();
		
		public WORK_LIMITSRecord()
		{
			
		}
	}
	
	public class SUBLINE_31Record
	{
		public string SUBLINE_id;
		public BEGINRecord BEGIN;
		public ENDRecord END;
		public string TRACK;
		
		public SUBLINE_31Record()
		{
			
		}
	}
	
	public class BEGINRecord
	{
		public string POINT;
		public string INCLUDE;
		public string NAMED_BOUNDARY;
		public string NAMED_BOUNDARY_id;
		public string SHOW_INCLUDE_DIALOG;
		public string RESPONSE;
		
		public BEGINRecord()
		{
			
		}
	}

	public class ENDRecord
	{
		public string POINT;
		public string INCLUDE;
		public string NAMED_BOUNDARY;
		public string NAMED_BOUNDARY_id;
		public string SHOW_INCLUDE_DIALOG;
		public string RESPONSE;
		
		public ENDRecord()
		{
			
		}
	}	

}
