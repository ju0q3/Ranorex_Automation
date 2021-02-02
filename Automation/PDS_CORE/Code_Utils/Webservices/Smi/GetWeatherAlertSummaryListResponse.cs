using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of GetWeatherAlertSummaryListResponse
    /// </summary>
    public class GetWeatherAlertSummaryListResponse
    {
        public List<GetWeatherAlertSummaryListRecord> GetWeatherAlertSummaryListList = new List<GetWeatherAlertSummaryListRecord>();

        public GetWeatherAlertSummaryListResponse()
        {
        }

        public static GetWeatherAlertSummaryListResponse loadXml(string xml)
        {
            GetWeatherAlertSummaryListResponse response = new GetWeatherAlertSummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                GetWeatherAlertSummaryListRecord GetWeatherAlertSummaryList = new GetWeatherAlertSummaryListRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "wx_report_id":
                            GetWeatherAlertSummaryList.wx_report_id = elemList[j].Attributes["value"].Value;
                            break;

                        case "wx_condition":
                            GetWeatherAlertSummaryList.wx_condition = elemList[j].Attributes["value"].Value;
                            break;

                        case "wx_severity":
                            GetWeatherAlertSummaryList.wx_severity = elemList[j].Attributes["value"].Value;
                            break;

                        case "generated_date":
                            GetWeatherAlertSummaryList.generated_date = elemList[j].Attributes["value"].Value;
                            break;

                        case "in_effect_date":
                            GetWeatherAlertSummaryList.in_effect_date = elemList[j].Attributes["value"].Value;
                            break;

                        case "until_date":
                            GetWeatherAlertSummaryList.until_date = elemList[j].Attributes["value"].Value;
                            break;

                        case "subdivision":
                            GetWeatherAlertSummaryList.subdivision = elemList[j].Attributes["value"].Value;
                            break;

                        case "mprange":
                            GetWeatherAlertSummaryList.mprange = elemList[j].Attributes["value"].Value;
                            break;

                        case "station_list":
                            GetWeatherAlertSummaryList.station_list = elemList[j].Attributes["value"].Value;
                            break;

                        case "unique_id":
                            GetWeatherAlertSummaryList.unique_id = elemList[j].Attributes["value"].Value;
                            break;

                        case "wx_msg_type":
                            GetWeatherAlertSummaryList.wx_msg_type = elemList[j].Attributes["value"].Value;
                            break;

                        default:
                            Console.WriteLine("Need to add " + name + "element to object");
                            break;
                    }  
                }
                
                XmlNodeList subTableList = rowList[i].SelectNodes("element-sub-table");
                for (int j = 0; j < subTableList.Count; j++)
                {
                    string subTableName = subTableList[j].Attributes["name"].Value;
                    switch (subTableName)
                    {
                        default:
                            Console.WriteLine("Need to add " + subTableName + "element to object");
                            break;
                    }
                }

                
                response.GetWeatherAlertSummaryListList.Add(GetWeatherAlertSummaryList);
            }    
            return response;
        }    
    }


    public class GetWeatherAlertSummaryListRecord
    {
        public string wx_report_id;
        public string wx_condition;
        public string wx_severity;
        public string generated_date;
        public string in_effect_date;
        public string until_date;
        public string subdivision;
        public string mprange;
        public string station_list;
        public string unique_id;
        public string wx_msg_type;

        public GetWeatherAlertSummaryListRecord()
        {
        }
    }

}
