/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/15/2018
 * Time: 8:00 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of GetBulletinSummaryListResponse
    /// </summary>
    public class GetBulletinSummaryListResponse
    {
        public List<GetBulletinSummaryListRecord> GetBulletinSummaryListList = new List<GetBulletinSummaryListRecord>();

        public GetBulletinSummaryListResponse()
        {
        }

        public static GetBulletinSummaryListResponse loadXml(string xml)
        {
            GetBulletinSummaryListResponse response = new GetBulletinSummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                GetBulletinSummaryListRecord GetBulletinSummaryList = new GetBulletinSummaryListRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "bulletintype":
                            GetBulletinSummaryList.bulletintype = elemList[j].Attributes["value"].Value;
                            break;

                        case "bulletinnumber":
                            GetBulletinSummaryList.bulletinnumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "effectivedateandtime":
                            GetBulletinSummaryList.effectivedateandtime = elemList[j].Attributes["value"].Value;
                            break;

                        case "expirationdateandtime":
                            GetBulletinSummaryList.expirationdateandtime = elemList[j].Attributes["value"].Value;
                            break;

                        case "okdateandtime":
                            GetBulletinSummaryList.okdateandtime = elemList[j].Attributes["value"].Value;
                            break;

                        case "firstlimit":
                            GetBulletinSummaryList.firstlimit = elemList[j].Attributes["value"].Value;
                            break;

                        case "secondlimit":
                            GetBulletinSummaryList.secondlimit = elemList[j].Attributes["value"].Value;
                            break;

                        case "trackname":
                            GetBulletinSummaryList.trackname = elemList[j].Attributes["value"].Value;
                            break;

                        case "summarylisttext":
                            GetBulletinSummaryList.summarylisttext = elemList[j].Attributes["value"].Value;
                            break;

                        case "dispatcherinitial":
                            GetBulletinSummaryList.dispatcherinitial = elemList[j].Attributes["value"].Value;
                            break;

                        case "division":
                            GetBulletinSummaryList.division = elemList[j].Attributes["value"].Value;
                            break;

                        case "district":
                            GetBulletinSummaryList.district = elemList[j].Attributes["value"].Value;
                            break;

                        case "startmilepost":
                            GetBulletinSummaryList.startmilepost = elemList[j].Attributes["value"].Value;
                            break;

                        case "index":
                            GetBulletinSummaryList.index = elemList[j].Attributes["value"].Value;
                            break;

                        case "ascendingflag":
                            GetBulletinSummaryList.ascendingflag = elemList[j].Attributes["value"].Value;
                            break;

                        case "dispatchterritoryid":
                            GetBulletinSummaryList.dispatchterritoryid = elemList[j].Attributes["value"].Value;
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

                
                response.GetBulletinSummaryListList.Add(GetBulletinSummaryList);
            }    
            return response;
        }    
    }


    public class GetBulletinSummaryListRecord
    {
        public string bulletintype;
        public string bulletinnumber;
        public string effectivedateandtime;
        public string expirationdateandtime;
        public string okdateandtime;
        public string firstlimit;
        public string secondlimit;
        public string trackname;
        public string summarylisttext;
        public string dispatcherinitial;
        public string division;
        public string district;
        public string startmilepost;
        public string index;
        public string ascendingflag;
        public string dispatchterritoryid;

        public GetBulletinSummaryListRecord()
        {
        }
    }

}


