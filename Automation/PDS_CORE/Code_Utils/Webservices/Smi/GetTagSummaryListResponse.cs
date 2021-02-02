using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of GetTagSummaryListResponse
    /// </summary>
    public class GetTagSummaryListResponse
    {
        public List<GetTagSummaryListRecord> GetTagSummaryListList = new List<GetTagSummaryListRecord>();

        public GetTagSummaryListResponse()
        {
        }

        public static GetTagSummaryListResponse loadXml(string xml)
        {
            GetTagSummaryListResponse response = new GetTagSummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                GetTagSummaryListRecord GetTagSummaryList = new GetTagSummaryListRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "District":
                            GetTagSummaryList.District = elemList[j].Attributes["value"].Value;
                            break;

                        case "DispatchTerritoryName":
                            GetTagSummaryList.DispatchTerritoryName = elemList[j].Attributes["value"].Value;
                            break;

                        case "DispatchTerritoryId":
                            GetTagSummaryList.DispatchTerritoryId = elemList[j].Attributes["value"].Value;
                            break;

                        case "UserId":
                            GetTagSummaryList.UserId = elemList[j].Attributes["value"].Value;
                            break;

                        case "LogicalPosition":
                            GetTagSummaryList.LogicalPosition = elemList[j].Attributes["value"].Value;
                            break;

                        case "TagName":
                            GetTagSummaryList.TagName = elemList[j].Attributes["value"].Value;
                            break;

                        case "TagType":
                            GetTagSummaryList.TagType = elemList[j].Attributes["value"].Value;
                            break;

                        case "PlacedDateTime":
                            GetTagSummaryList.PlacedDateTime = elemList[j].Attributes["value"].Value;
                            break;

                        case "Blocking":
                            GetTagSummaryList.Blocking = elemList[j].Attributes["value"].Value;
                            break;

                        case "EstRemovalDateTime":
                            GetTagSummaryList.EstRemovalDateTime = elemList[j].Attributes["value"].Value;
                            break;

                        case "Comments":
                            GetTagSummaryList.Comments = elemList[j].Attributes["value"].Value;
                            break;

                        case "DispatcherInitials":
                            GetTagSummaryList.DispatcherInitials = elemList[j].Attributes["value"].Value;
                            break;

                        case "PlanThrough":
                            GetTagSummaryList.PlanThrough = elemList[j].Attributes["value"].Value;
                            break;

                        case "Between/At":
                            GetTagSummaryList.Between_At = elemList[j].Attributes["value"].Value;
                            break;

                        case "And":
                            GetTagSummaryList.And = elemList[j].Attributes["value"].Value;
                            break;

                        case "Track":
                            GetTagSummaryList.Track = elemList[j].Attributes["value"].Value;
                            break;

                        case "Device":
                            GetTagSummaryList.Device = elemList[j].Attributes["value"].Value;
                            break;

                        case "StartMilepost":
                            GetTagSummaryList.StartMilepost = elemList[j].Attributes["value"].Value;
                            break;

                        case "SequenceNumber":
                            GetTagSummaryList.SequenceNumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "AscendingFlag":
                            GetTagSummaryList.AscendingFlag = elemList[j].Attributes["value"].Value;
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

                
                response.GetTagSummaryListList.Add(GetTagSummaryList);
            }    
            return response;
        }    
    }


    public class GetTagSummaryListRecord
    {
        public string District;
        public string DispatchTerritoryName;
        public string DispatchTerritoryId;
        public string UserId;
        public string LogicalPosition;
        public string TagName;
        public string TagType;
        public string PlacedDateTime;
        public string Blocking;
        public string EstRemovalDateTime;
        public string Comments;
        public string DispatcherInitials;
        public string PlanThrough;
        public string Between_At;
        public string And;
        public string Track;
        public string Device;
        public string StartMilepost;
        public string SequenceNumber;
        public string AscendingFlag;

        public GetTagSummaryListRecord()
        {
        }
    }

}


