using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of GetBulletinsNeededSummaryListResponse
    /// </summary>
    public class GetBulletinsNeededSummaryListResponse
    {
        public List<GetBulletinsNeededSummaryListRecord> GetBulletinsNeededSummaryListList = new List<GetBulletinsNeededSummaryListRecord>();

        public GetBulletinsNeededSummaryListResponse()
        {
        }

        public static GetBulletinsNeededSummaryListResponse loadXml(string xml)
        {
            GetBulletinsNeededSummaryListResponse response = new GetBulletinsNeededSummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                GetBulletinsNeededSummaryListRecord GetBulletinsNeededSummaryList = new GetBulletinsNeededSummaryListRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "bulletinnumber":
                            GetBulletinsNeededSummaryList.bulletinnumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "district":
                            GetBulletinsNeededSummaryList.district = elemList[j].Attributes["value"].Value;
                            break;

                        case "division":
                            GetBulletinsNeededSummaryList.division = elemList[j].Attributes["value"].Value;
                            break;

                        case "shorttrainid":
                            GetBulletinsNeededSummaryList.shorttrainid = elemList[j].Attributes["value"].Value;
                            break;

                        case "trainpdid":
                            GetBulletinsNeededSummaryList.trainpdid = elemList[j].Attributes["value"].Value;
                            break;

                        case "dispatchterritoryid":
                            GetBulletinsNeededSummaryList.dispatchterritoryid = elemList[j].Attributes["value"].Value;
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

                
                response.GetBulletinsNeededSummaryListList.Add(GetBulletinsNeededSummaryList);
            }    
            return response;
        }    
    }


    public class GetBulletinsNeededSummaryListRecord
    {
        public string bulletinnumber;
        public string district;
        public string division;
        public string shorttrainid;
        public string trainpdid;
        public string dispatchterritoryid;

        public GetBulletinsNeededSummaryListRecord()
        {
        }
    }

}
