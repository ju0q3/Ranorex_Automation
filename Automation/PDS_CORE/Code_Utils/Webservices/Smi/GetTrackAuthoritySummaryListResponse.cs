using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace PDS_CORE.Code_Utils.Webservices.Smi
{
    /// <summary>
    /// Description of Man_Summary_InfoResponse
    /// </summary>
    public class GetTrackAuthoritySummaryListResponse
    {
        public List<Man_Summary_InfoRecord> Man_Summary_InfoList = new List<Man_Summary_InfoRecord>();

        public GetTrackAuthoritySummaryListResponse()
        {
        }

        public static GetTrackAuthoritySummaryListResponse loadXml(string xml)
        {
            GetTrackAuthoritySummaryListResponse response = new GetTrackAuthoritySummaryListResponse();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            
            XmlElement root = doc.DocumentElement;
            XmlNodeList rowList = root.SelectNodes("row");
            for (int i = 0; i < rowList.Count; i++)
            {
                Man_Summary_InfoRecord Man_Summary_Info = new Man_Summary_InfoRecord();
                
                XmlNodeList elemList = rowList[i].SelectNodes("element");
                for (int j = 0; j< elemList.Count; j++)
                {
                    string name = elemList[j].Attributes["name"].Value;
                    
                    switch (name)
                    {
                        case "AddVoidWatermark":
                            Man_Summary_Info.AddVoidWatermark = elemList[j].Attributes["value"].Value;
                            break;

                        case "District":
                            Man_Summary_Info.District = elemList[j].Attributes["value"].Value;
                            break;

                        case "DispatchTerritoryName":
                            Man_Summary_Info.DispatchTerritoryName = elemList[j].Attributes["value"].Value;
                            break;

                        case "DispatchTerritoryId":
                            Man_Summary_Info.DispatchTerritoryId = elemList[j].Attributes["value"].Value;
                            break;

                        case "UserId":
                            Man_Summary_Info.UserId = elemList[j].Attributes["value"].Value;
                            break;

                        case "LogicalPosition":
                            Man_Summary_Info.LogicalPosition = elemList[j].Attributes["value"].Value;
                            break;

                        case "AuthorityType":
                            Man_Summary_Info.AuthorityType = elemList[j].Attributes["value"].Value;
                            break;

                        case "AuthorityNumber":
                            Man_Summary_Info.AuthorityNumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "AddresseeType":
                            Man_Summary_Info.AddresseeType = elemList[j].Attributes["value"].Value;
                            break;

                        case "Addressee":
                            Man_Summary_Info.Addressee = elemList[j].Attributes["value"].Value;
                            break;

                        case "ShortTrainId":
                            Man_Summary_Info.ShortTrainId = elemList[j].Attributes["value"].Value;
                            break;

                        case "PrintDate":
                            Man_Summary_Info.PrintDate = elemList[j].Attributes["value"].Value;
                            break;

                        case "AtLocation":
                            Man_Summary_Info.AtLocation = elemList[j].Attributes["value"].Value;
                            break;

                        case "VoidCk":
                            Man_Summary_Info.VoidCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "VoidNumber":
                            Man_Summary_Info.VoidNumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "PTCStatus":
                            Man_Summary_Info.PTCStatus = elemList[j].Attributes["value"].Value;
                            break;

                        case "LimitsSummary":
                            Man_Summary_Info.LimitsSummary = elemList[j].Attributes["value"].Value;
                            break;

                        case "OsLocation":
                            Man_Summary_Info.OsLocation = elemList[j].Attributes["value"].Value;
                            break;

                        case "Expiration":
                            Man_Summary_Info.Expiration = elemList[j].Attributes["value"].Value;
                            break;

                        case "ExtendCk":
                            Man_Summary_Info.ExtendCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "ExpiresAt":
                            Man_Summary_Info.ExpiresAt = elemList[j].Attributes["value"].Value;
                            break;

                        case "HoldMain":
                            Man_Summary_Info.HoldMain = elemList[j].Attributes["value"].Value;
                            break;

                        case "HoldMainCk":
                            Man_Summary_Info.HoldMainCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "FollowCk":
                            Man_Summary_Info.FollowCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "ClearMain":
                            Man_Summary_Info.ClearMain = elemList[j].Attributes["value"].Value;
                            break;

                        case "ClearMainCk":
                            Man_Summary_Info.ClearMainCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "TERestrictionCk":
                            Man_Summary_Info.TERestrictionCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "TERestrictionLimitsBetween":
                            Man_Summary_Info.TERestrictionLimitsBetween = elemList[j].Attributes["value"].Value;
                            break;

                        case "TERestrictionLimitsAnd":
                            Man_Summary_Info.TERestrictionLimitsAnd = elemList[j].Attributes["value"].Value;
                            break;

                        case "OTRestrictionCk":
                            Man_Summary_Info.OTRestrictionCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "OTRestrictionLimitsBetween":
                            Man_Summary_Info.OTRestrictionLimitsBetween = elemList[j].Attributes["value"].Value;
                            break;

                        case "OTRestrictionLimitsAnd":
                            Man_Summary_Info.OTRestrictionLimitsAnd = elemList[j].Attributes["value"].Value;
                            break;

                        case "JointCk":
                            Man_Summary_Info.JointCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "InstructionsCk":
                            Man_Summary_Info.InstructionsCk = elemList[j].Attributes["value"].Value;
                            break;

                        case "InstructionsSystem":
                            Man_Summary_Info.InstructionsSystem = elemList[j].Attributes["value"].Value;
                            break;

                        case "InstructionsUser":
                            Man_Summary_Info.InstructionsUser = elemList[j].Attributes["value"].Value;
                            break;

                        case "OkTime":
                            Man_Summary_Info.OkTime = elemList[j].Attributes["value"].Value;
                            break;

                        case "SubdividedLimitsBegin":
                            Man_Summary_Info.SubdividedLimitsBegin = elemList[j].Attributes["value"].Value;
                            break;

                        case "SubDividedMilepost":
                            Man_Summary_Info.SubDividedMilepost = elemList[j].Attributes["value"].Value;
                            break;

                        case "SubdividedLimitsEnd":
                            Man_Summary_Info.SubdividedLimitsEnd = elemList[j].Attributes["value"].Value;
                            break;

                        case "IssueTime":
                            Man_Summary_Info.IssueTime = elemList[j].Attributes["value"].Value;
                            break;

                        case "IssueDispatcher":
                            Man_Summary_Info.IssueDispatcher = elemList[j].Attributes["value"].Value;
                            break;

                        case "RollupInProgress":
                            Man_Summary_Info.RollupInProgress = elemList[j].Attributes["value"].Value;
                            break;

                        case "IssueCopiedBy":
                            Man_Summary_Info.IssueCopiedBy = elemList[j].Attributes["value"].Value;
                            break;

                        case "HaveJointOccupants":
                            Man_Summary_Info.HaveJointOccupants = elemList[j].Attributes["value"].Value;
                            break;

                        case "ReleaseTime":
                            Man_Summary_Info.ReleaseTime = elemList[j].Attributes["value"].Value;
                            break;

                        case "ReleaseBy":
                            Man_Summary_Info.ReleaseBy = elemList[j].Attributes["value"].Value;
                            break;

                        case "StartMilepost":
                            Man_Summary_Info.StartMilepost = elemList[j].Attributes["value"].Value;
                            break;

                        case "SequenceNumber":
                            Man_Summary_Info.SequenceNumber = elemList[j].Attributes["value"].Value;
                            break;

                        case "AscendingFlag":
                            Man_Summary_Info.AscendingFlag = elemList[j].Attributes["value"].Value;
                            break;

                        case "IssueDt":
                            Man_Summary_Info.IssueDt = elemList[j].Attributes["value"].Value;
                            break;

                        case "OkTm":
                            Man_Summary_Info.OkTm = elemList[j].Attributes["value"].Value;
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
                        case "Man_SubLines":
                            Man_SubLinesRecord Man_SubLines = new Man_SubLinesRecord();
                            XmlNodeList Man_SubLineselementSubTableList = subTableList[j].SelectNodes("row");

                            for (int l = 0; l < Man_SubLineselementSubTableList.Count; l++)
                            {
                                string rowName = Man_SubLineselementSubTableList[l].Attributes["name"].Value;
                                switch (rowName)
                                {
                                    case "Proceed1":
                                        Proceed1Record Proceed1 = new Proceed1Record();
                                        XmlNodeList Proceed1subElemList = Man_SubLineselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Proceed1subElemList.Count; m++)
                                        {
                                            string elementName = Proceed1subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "Proceed1Ck":
                                                    Proceed1.Proceed1Ck = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "FirstSwitch1":
                                                    Proceed1.FirstSwitch1 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "From11":
                                                    Proceed1.From11 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "To11":
                                                    Proceed1.To11 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track11":
                                                    Proceed1.Track11 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "ThenTo12":
                                                    Proceed1.ThenTo12 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track12":
                                                    Proceed1.Track12 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "ThenTo13":
                                                    Proceed1.ThenTo13 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track13":
                                                    Proceed1.Track13 = Proceed1subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Man_SubLines.Proceed1 = Proceed1;
                                        break;

                                    case "Work":
                                        WorkRecord Work = new WorkRecord();
                                        XmlNodeList WorksubElemList = Man_SubLineselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < WorksubElemList.Count; m++)
                                        {
                                            string elementName = WorksubElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "WorkCk":
                                                    Work.WorkCk = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Between":
                                                    Work.Between = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "IncludeBeginCp":
                                                    Work.IncludeBeginCp = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "And":
                                                    Work.And = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "IncludeEndCp":
                                                    Work.IncludeEndCp = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track1":
                                                    Work.Track1 = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track2":
                                                    Work.Track2 = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track3":
                                                    Work.Track3 = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track4":
                                                    Work.Track4 = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track5":
                                                    Work.Track5 = WorksubElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Man_SubLines.Work = Work;
                                        break;

                                    case "Proceed2":
                                        Proceed2Record Proceed2 = new Proceed2Record();
                                        XmlNodeList Proceed2subElemList = Man_SubLineselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Proceed2subElemList.Count; m++)
                                        {
                                            string elementName = Proceed2subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "Proceed2Ck":
                                                    Proceed2.Proceed2Ck = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "FirstSwitch2":
                                                    Proceed2.FirstSwitch2 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "From21":
                                                    Proceed2.From21 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "To21":
                                                    Proceed2.To21 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track21":
                                                    Proceed2.Track21 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "ThenTo22":
                                                    Proceed2.ThenTo22 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track22":
                                                    Proceed2.Track22 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "ThenTo23":
                                                    Proceed2.ThenTo23 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track23":
                                                    Proceed2.Track23 = Proceed2subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Man_SubLines.Proceed2 = Proceed2;
                                        break;

                                    case "StopShort":
                                        StopShortRecord StopShort = new StopShortRecord();
                                        XmlNodeList StopShortsubElemList = Man_SubLineselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < StopShortsubElemList.Count; m++)
                                        {
                                            string elementName = StopShortsubElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "SSCk":
                                                    StopShort.SSCk = StopShortsubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "StopShortAt":
                                                    StopShort.StopShortAt = StopShortsubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "StopShortTrack":
                                                    StopShort.StopShortTrack = StopShortsubElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Man_SubLines.StopShort = StopShort;
                                        break;

                                    default:
                                        Console.WriteLine("Need to add " + rowName + "element to object");
                                        break;
                                }
                            }
                            Man_Summary_Info.Man_SubLines = Man_SubLines;
                            break;

                        case "Boxes":
                            BoxesRecord Boxes = new BoxesRecord();
                            XmlNodeList BoxeselementSubTableList = subTableList[j].SelectNodes("row");

                            for (int l = 0; l < BoxeselementSubTableList.Count; l++)
                            {
                                string rowName = BoxeselementSubTableList[l].Attributes["name"].Value;
                                switch (rowName)
                                {
                                    case "Box1":
                                        Box1Record Box1 = new Box1Record();
                                        XmlNodeList Box1subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box1subElemList.Count; m++)
                                        {
                                            string elementName = Box1subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "VoidCk":
                                                    Box1.VoidCk = Box1subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "VoidNumber":
                                                    Box1.VoidNumber = Box1subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box1 = Box1;
                                        break;

                                    case "Box2":
                                        Box2Record Box2 = new Box2Record();
                                        XmlNodeList Box2subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box2subElemList.Count; m++)
                                        {
                                            string elementName = Box2subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "ProceedCk":
                                                    Box2.ProceedCk = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin21":
                                                    Box2.Begin21 = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin21Include":
                                                    Box2.Begin21Include = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End21":
                                                    Box2.End21 = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End21Include":
                                                    Box2.End21Include = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track21":
                                                    Box2.Track21 = Box2subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box2 = Box2;
                                        break;

                                    case "Box3":
                                        Box3Record Box3 = new Box3Record();
                                        XmlNodeList Box3subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box3subElemList.Count; m++)
                                        {
                                            string elementName = Box3subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "ClearMain1Ck":
                                                    Box3.ClearMain1Ck = Box3subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Location":
                                                    Box3.Location = Box3subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box3 = Box3;
                                        break;

                                    case "Box4":
                                        Box4Record Box4 = new Box4Record();
                                        XmlNodeList Box4subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box4subElemList.Count; m++)
                                        {
                                            string elementName = Box4subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "MeetProceedCk":
                                                    Box4.MeetProceedCk = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin41":
                                                    Box4.Begin41 = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin41Include":
                                                    Box4.Begin41Include = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End41":
                                                    Box4.End41 = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End41Include":
                                                    Box4.End41Include = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track41":
                                                    Box4.Track41 = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "MeetTrain":
                                                    Box4.MeetTrain = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "MeetLocation":
                                                    Box4.MeetLocation = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "MeetInclude":
                                                    Box4.MeetInclude = Box4subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box4 = Box4;
                                        break;

                                    case "Box5":
                                        Box5Record Box5 = new Box5Record();
                                        XmlNodeList Box5subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box5subElemList.Count; m++)
                                        {
                                            string elementName = Box5subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "ClearMain2Ck":
                                                    Box5.ClearMain2Ck = Box5subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Location":
                                                    Box5.Location = Box5subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box5 = Box5;
                                        break;

                                    case "Box6":
                                        Box6Record Box6 = new Box6Record();
                                        XmlNodeList Box6subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box6subElemList.Count; m++)
                                        {
                                            string elementName = Box6subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "WorkCk":
                                                    Box6.WorkCk = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin61":
                                                    Box6.Begin61 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin61Include":
                                                    Box6.Begin61Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End61":
                                                    Box6.End61 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End61Include":
                                                    Box6.End61Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track61":
                                                    Box6.Track61 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin62":
                                                    Box6.Begin62 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin62Include":
                                                    Box6.Begin62Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End62":
                                                    Box6.End62 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End62Include":
                                                    Box6.End62Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track62":
                                                    Box6.Track62 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin63":
                                                    Box6.Begin63 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin63Include":
                                                    Box6.Begin63Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End63":
                                                    Box6.End63 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End63Include":
                                                    Box6.End63Include = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track63":
                                                    Box6.Track63 = Box6subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box6 = Box6;
                                        break;

                                    case "Box7":
                                        Box7Record Box7 = new Box7Record();
                                        XmlNodeList Box7subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box7subElemList.Count; m++)
                                        {
                                            string elementName = Box7subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "FollowCk":
                                                    Box7.FollowCk = Box7subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Train1":
                                                    Box7.Train1 = Box7subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Train2":
                                                    Box7.Train2 = Box7subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box7 = Box7;
                                        break;

                                    case "Box8":
                                        Box8Record Box8 = new Box8Record();
                                        XmlNodeList Box8subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box8subElemList.Count; m++)
                                        {
                                            string elementName = Box8subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "JointCk":
                                                    Box8.JointCk = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin8":
                                                    Box8.Begin8 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin8Include":
                                                    Box8.Begin8Include = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End8":
                                                    Box8.End8 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End8Include":
                                                    Box8.End8Include = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Employee2":
                                                    Box8.Employee2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin2":
                                                    Box8.Begin2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "BeginInclude2":
                                                    Box8.BeginInclude2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End2":
                                                    Box8.End2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "EndInclude2":
                                                    Box8.EndInclude2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track2":
                                                    Box8.Track2 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Employee3":
                                                    Box8.Employee3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Begin3":
                                                    Box8.Begin3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "BeginInclude3":
                                                    Box8.BeginInclude3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "End3":
                                                    Box8.End3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "EndInclude3":
                                                    Box8.EndInclude3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Track3":
                                                    Box8.Track3 = Box8subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box8 = Box8;
                                        break;

                                    case "Box9":
                                        Box9Record Box9 = new Box9Record();
                                        XmlNodeList Box9subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box9subElemList.Count; m++)
                                        {
                                            string elementName = Box9subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "StopAtCk":
                                                    Box9.StopAtCk = Box9subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Location1":
                                                    Box9.Location1 = Box9subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Location2":
                                                    Box9.Location2 = Box9subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box9 = Box9;
                                        break;

                                    case "Box10":
                                        Box10Record Box10 = new Box10Record();
                                        XmlNodeList Box10subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box10subElemList.Count; m++)
                                        {
                                            string elementName = Box10subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "PermissionToLeaveCk":
                                                    Box10.PermissionToLeaveCk = Box10subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Switch1":
                                                    Box10.Switch1 = Box10subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Switch2":
                                                    Box10.Switch2 = Box10subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Switch3":
                                                    Box10.Switch3 = Box10subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Switch4":
                                                    Box10.Switch4 = Box10subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box10 = Box10;
                                        break;

                                    case "Box11":
                                        Box11Record Box11 = new Box11Record();
                                        XmlNodeList Box11subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box11subElemList.Count; m++)
                                        {
                                            string elementName = Box11subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "InstructionsCk":
                                                    Box11.InstructionsCk = Box11subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "SystemInstructions":
                                                    Box11.SystemInstructions = Box11subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "UserInstructions":
                                                    Box11.UserInstructions = Box11subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box11 = Box11;
                                        break;

                                    case "Box12":
                                        Box12Record Box12 = new Box12Record();
                                        XmlNodeList Box12subElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < Box12subElemList.Count; m++)
                                        {
                                            string elementName = Box12subElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "MeetCk":
                                                    Box12.MeetCk = Box12subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "MeetLocation":
                                                    Box12.MeetLocation = Box12subElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "MeetInclude":
                                                    Box12.MeetInclude = Box12subElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.Box12 = Box12;
                                        break;

                                    case "BoxesLine":
                                        BoxesLineRecord BoxesLine = new BoxesLineRecord();
                                        XmlNodeList BoxesLinesubElemList = BoxeselementSubTableList[l].SelectNodes("element");

                                        for (int m = 0; m < BoxesLinesubElemList.Count; m++)
                                        {
                                            string elementName = BoxesLinesubElemList[m].Attributes["name"].Value;
                                            switch (elementName)
                                            {
                                                case "BoxesLineCk":
                                                    BoxesLine.BoxesLineCk = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "NumOfBoxes":
                                                    BoxesLine.NumOfBoxes = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box1":
                                                    BoxesLine.Box1 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box2":
                                                    BoxesLine.Box2 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box3":
                                                    BoxesLine.Box3 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box4":
                                                    BoxesLine.Box4 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box5":
                                                    BoxesLine.Box5 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box6":
                                                    BoxesLine.Box6 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box7":
                                                    BoxesLine.Box7 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box8":
                                                    BoxesLine.Box8 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                                case "Box9":
                                                    BoxesLine.Box9 = BoxesLinesubElemList[m].Attributes["value"].Value;
                                                    break;

                                               default:
                                                   Console.WriteLine("Need to add " + elementName + "element to object");
                                                   break;
                                            }
                                        }
                                        Boxes.BoxesLine = BoxesLine;
                                        break;

                                    default:
                                        Console.WriteLine("Need to add " + rowName + "element to object");
                                        break;
                                }
                            }
                            Man_Summary_Info.Boxes = Boxes;
                            break;

                        default:
                            Console.WriteLine("Need to add " + subTableName + "element to object");
                            break;
                    }
                }

                
                response.Man_Summary_InfoList.Add(Man_Summary_Info);
            }    
            return response;
        }    
    }


    public class Man_Summary_InfoRecord
    {
        public string AddVoidWatermark;
        public string District;
        public string DispatchTerritoryName;
        public string DispatchTerritoryId;
        public string UserId;
        public string LogicalPosition;
        public string AuthorityType;
        public string AuthorityNumber;
        public string AddresseeType;
        public string Addressee;
        public string ShortTrainId;
        public string PrintDate;
        public string AtLocation;
        public string VoidCk;
        public string VoidNumber;
        public string PTCStatus;
        public string LimitsSummary;
        public Man_SubLinesRecord Man_SubLines;
        public string OsLocation;
        public string Expiration;
        public string ExtendCk;
        public string ExpiresAt;
        public string HoldMain;
        public string HoldMainCk;
        public string FollowCk;
        public string ClearMain;
        public string ClearMainCk;
        public string TERestrictionCk;
        public string TERestrictionLimitsBetween;
        public string TERestrictionLimitsAnd;
        public string OTRestrictionCk;
        public string OTRestrictionLimitsBetween;
        public string OTRestrictionLimitsAnd;
        public string JointCk;
        public string InstructionsCk;
        public string InstructionsSystem;
        public string InstructionsUser;
        public string OkTime;
        public string SubdividedLimitsBegin;
        public string SubDividedMilepost;
        public string SubdividedLimitsEnd;
        public string IssueTime;
        public string IssueDispatcher;
        public string RollupInProgress;
        public string IssueCopiedBy;
        public string HaveJointOccupants;
        public string ReleaseTime;
        public string ReleaseBy;
        public string StartMilepost;
        public string SequenceNumber;
        public string AscendingFlag;
        public string IssueDt;
        public string OkTm;
        public BoxesRecord Boxes;

        public Man_Summary_InfoRecord()
        {
        }
    }

    public class Man_SubLinesRecord
    {
        public Proceed1Record Proceed1;
        public WorkRecord Work;
        public Proceed2Record Proceed2;
        public StopShortRecord StopShort;

        public Man_SubLinesRecord()
        {
        }
    }

    public class Proceed1Record
    {
        public string Proceed1Ck;
        public string FirstSwitch1;
        public string From11;
        public string To11;
        public string Track11;
        public string ThenTo12;
        public string Track12;
        public string ThenTo13;
        public string Track13;

        public Proceed1Record()
        {
        }
    }

    public class WorkRecord
    {
        public string WorkCk;
        public string Between;
        public string IncludeBeginCp;
        public string And;
        public string IncludeEndCp;
        public string Track1;
        public string Track2;
        public string Track3;
        public string Track4;
        public string Track5;

        public WorkRecord()
        {
        }
    }

    public class Proceed2Record
    {
        public string Proceed2Ck;
        public string FirstSwitch2;
        public string From21;
        public string To21;
        public string Track21;
        public string ThenTo22;
        public string Track22;
        public string ThenTo23;
        public string Track23;

        public Proceed2Record()
        {
        }
    }

    public class StopShortRecord
    {
        public string SSCk;
        public string StopShortAt;
        public string StopShortTrack;

        public StopShortRecord()
        {
        }
    }

    public class BoxesRecord
    {
        public Box1Record Box1;
        public Box2Record Box2;
        public Box3Record Box3;
        public Box4Record Box4;
        public Box5Record Box5;
        public Box6Record Box6;
        public Box7Record Box7;
        public Box8Record Box8;
        public Box9Record Box9;
        public Box10Record Box10;
        public Box11Record Box11;
        public Box12Record Box12;
        public BoxesLineRecord BoxesLine;

        public BoxesRecord()
        {
        }
    }

    public class Box1Record
    {
        public string VoidCk;
        public string VoidNumber;

        public Box1Record()
        {
        }
    }

    public class Box2Record
    {
        public string ProceedCk;
        public string Begin21;
        public string Begin21Include;
        public string End21;
        public string End21Include;
        public string Track21;

        public Box2Record()
        {
        }
    }

    public class Box3Record
    {
        public string ClearMain1Ck;
        public string Location;

        public Box3Record()
        {
        }
    }

    public class Box4Record
    {
        public string MeetProceedCk;
        public string Begin41;
        public string Begin41Include;
        public string End41;
        public string End41Include;
        public string Track41;
        public string MeetTrain;
        public string MeetLocation;
        public string MeetInclude;

        public Box4Record()
        {
        }
    }

    public class Box5Record
    {
        public string ClearMain2Ck;
        public string Location;

        public Box5Record()
        {
        }
    }

    public class Box6Record
    {
        public string WorkCk;
        public string Begin61;
        public string Begin61Include;
        public string End61;
        public string End61Include;
        public string Track61;
        public string Begin62;
        public string Begin62Include;
        public string End62;
        public string End62Include;
        public string Track62;
        public string Begin63;
        public string Begin63Include;
        public string End63;
        public string End63Include;
        public string Track63;

        public Box6Record()
        {
        }
    }

    public class Box7Record
    {
        public string FollowCk;
        public string Train1;
        public string Train2;

        public Box7Record()
        {
        }
    }

    public class Box8Record
    {
        public string JointCk;
        public string Begin8;
        public string Begin8Include;
        public string End8;
        public string End8Include;
        public string Employee2;
        public string Begin2;
        public string BeginInclude2;
        public string End2;
        public string EndInclude2;
        public string Track2;
        public string Employee3;
        public string Begin3;
        public string BeginInclude3;
        public string End3;
        public string EndInclude3;
        public string Track3;

        public Box8Record()
        {
        }
    }

    public class Box9Record
    {
        public string StopAtCk;
        public string Location1;
        public string Location2;

        public Box9Record()
        {
        }
    }

    public class Box10Record
    {
        public string PermissionToLeaveCk;
        public string Switch1;
        public string Switch2;
        public string Switch3;
        public string Switch4;

        public Box10Record()
        {
        }
    }

    public class Box11Record
    {
        public string InstructionsCk;
        public string SystemInstructions;
        public string UserInstructions;

        public Box11Record()
        {
        }
    }

    public class Box12Record
    {
        public string MeetCk;
        public string MeetLocation;
        public string MeetInclude;

        public Box12Record()
        {
        }
    }

    public class BoxesLineRecord
    {
        public string BoxesLineCk;
        public string NumOfBoxes;
        public string Box1;
        public string Box2;
        public string Box3;
        public string Box4;
        public string Box5;
        public string Box6;
        public string Box7;
        public string Box8;
        public string Box9;

        public BoxesLineRecord()
        {
        }
    }

}
