/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/16/2018
 * Time: 8:52 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
	/// <summary>
	/// Description of GetTrainSheetSummaryListResponse.
	/// </summary>
	public class GetTrainSheetStatusSummaryResponse
	{
		public List<Train_Sheet_Status_Summary_Record> Train_Sheet_Status_SummaryList = new List <Train_Sheet_Status_Summary_Record>();
		
		public GetTrainSheetStatusSummaryResponse()
		{
		}
		public static GetTrainSheetStatusSummaryResponse loadXml(string xml)
		{
			GetTrainSheetStatusSummaryResponse response = new GetTrainSheetStatusSummaryResponse ();
			
			XmlDocument doc = new XmlDocument(); 
			doc.LoadXml(xml);
			
			XmlElement root = doc.DocumentElement;
			XmlNodeList rowlist = root.SelectNodes("row");
			for (int i = 0; i < rowlist.Count; i++)
			{ 
				Train_Sheet_Status_Summary_Record TrainSheetStatus = new Train_Sheet_Status_Summary_Record ();
				
				XmlNodeList elemList = rowlist [i].SelectNodes("item");
				for (int j = 0; j < elemList.Count; j++)
				{
					//string result = elemList[j].Attributes["
				}
			}
			
			return response;
		}
	}  

    public class Train_Sheet_Status_Summary_Record
    {
    	public Train_Sheet_Status_Summary_Record()
    	{
    		
    	}
    }
		
}

	
