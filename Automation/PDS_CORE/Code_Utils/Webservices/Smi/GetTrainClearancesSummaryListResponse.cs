using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of Train_Clearance_SummaryResponse
    /// </summary>
    public class GetTrainClearancesSummaryListResponse
    {
        public List<Train_Clearance_SummaryRecord> Train_Clearance_SummaryList = new List<Train_Clearance_SummaryRecord>();

        public GetTrainClearancesSummaryListResponse()
        {
        }

        public static GetTrainClearancesSummaryListResponse loadXml(string xml)
        {
            GetTrainClearancesSummaryListResponse response = new GetTrainClearancesSummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                Train_Clearance_SummaryRecord Train_Clearance_Summary = new Train_Clearance_SummaryRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "shorttrainid":
                            Train_Clearance_Summary.shorttrainid = elemList[j].Attributes["value"].Value;
                            break;

                        case "creworigin":
                            Train_Clearance_Summary.creworigin = elemList[j].Attributes["value"].Value;
                            break;

                        case "crewdestination":
                            Train_Clearance_Summary.crewdestination = elemList[j].Attributes["value"].Value;
                            break;

                        case "qtyofbulletins":
                            Train_Clearance_Summary.qtyofbulletins = elemList[j].Attributes["value"].Value;
                            break;

                        case "qtyofmessages":
                            Train_Clearance_Summary.qtyofmessages = elemList[j].Attributes["value"].Value;
                            break;

                        case "associationtimestamp":
                            Train_Clearance_Summary.associationtimestamp = elemList[j].Attributes["value"].Value;
                            break;

                        case "associationdispatcherinitial":
                            Train_Clearance_Summary.associationdispatcherinitial = elemList[j].Attributes["value"].Value;
                            break;

                        case "status":
                            Train_Clearance_Summary.status = elemList[j].Attributes["value"].Value;
                            break;

                        case "trainclearancenumber":
                            Train_Clearance_Summary.trainclearancenumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "trainpdid":
                            Train_Clearance_Summary.trainpdid = elemList[j].Attributes["value"].Value;
                            break;

                        case "trainclearancemodel":
                            Train_Clearance_Summary.trainclearancemodel = elemList[j].Attributes["value"].Value;
                            break;

                        case "effectivedate":
                            Train_Clearance_Summary.effectivedate = elemList[j].Attributes["value"].Value;
                            break;

                        case "tcCreationTS":
                            Train_Clearance_Summary.tcCreationTS = elemList[j].Attributes["value"].Value;
                            break;

                        case "tcIssuedToID":
                            Train_Clearance_Summary.tcIssuedToID = elemList[j].Attributes["value"].Value;
                            break;

                        case "dispatchterritoryid":
                            Train_Clearance_Summary.dispatchterritoryid = elemList[j].Attributes["value"].Value;
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

                
                response.Train_Clearance_SummaryList.Add(Train_Clearance_Summary);
            }    
            return response;
        }    
    }


    public class Train_Clearance_SummaryRecord
    {
        public string shorttrainid;
        public string creworigin;
        public string crewdestination;
        public string qtyofbulletins;
        public string qtyofmessages;
        public string associationtimestamp;
        public string associationdispatcherinitial;
        public string status;
        public string trainclearancenumber;
        public string trainpdid;
        public string trainclearancemodel;
        public string effectivedate;
        public string tcCreationTS;
        public string tcIssuedToID;
        public string dispatchterritoryid;

        public Train_Clearance_SummaryRecord()
        {
        }
    }

}


