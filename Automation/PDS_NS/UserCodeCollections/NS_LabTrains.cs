/*
 * Created by Ranorex
 * User: 212719544
 * Date: 2/17/2020
 * Time: 11:35 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_LabTrains
    {
        public static string PrimaryTrainSeed = "";
        public static string SecondaryTrainSeed = "";
        
        [UserCodeMethod]
        public static void CreatePTCLabPrimaryTrainObject(string trainSeed, string scac, string section)
        {
            PrimaryTrainSeed = trainSeed;
            CreatePTCLabTrainObject(trainSeed, scac, section);
        }
        
        [UserCodeMethod]
        public static void CreatePTCLabSecondaryTrainObject(string trainSeed, string scac, string section)
        {
            SecondaryTrainSeed = trainSeed;
            CreatePTCLabTrainObject(trainSeed, scac, section);
        }
        
        
        [UserCodeMethod]
        public static void CreatePTCLabTrainObject(string trainSeed, string scac, string section)
        {
            System.DateTime trainTime = System.DateTime.Now;
            int currentDay = trainTime.Day;
            string trainSymbol = "";
            int trainDay = 0;
            //If trainSeed contains a space, implies this is a Train Symbol and date, else we assume it is the Train Symbol and assign it a current date
            string[] splitTrainSeed = trainSeed.Split(' ');
            if (splitTrainSeed.Length > 1)
            {
                if (splitTrainSeed[1] != "")
                {
                    trainSymbol = splitTrainSeed[0];
                    trainDay = int.Parse(splitTrainSeed[1]);
                    Ranorex.Report.Info("Train Day:"+trainDay);
                    if (trainDay > currentDay)
                    {
                        trainTime = System.DateTime.Now.AddMonths(-1);
                        Ranorex.Report.Info("Train Day Greater:"+trainDay);
                        Ranorex.Report.Info("Train Time Greater:"+trainTime);
                    }
                    trainTime = trainTime.AddDays(trainDay - currentDay);
                    Ranorex.Report.Info("Train Time:"+trainTime.ToString());
                }
            } else {
                trainSymbol = trainSeed;
            }
            
            PDS_CORE.Code_Utils.NS_TrainObject newTrainObject = new PDS_CORE.Code_Utils.NS_TrainObject();
            newTrainObject.TrainSymbol = trainSymbol;
            newTrainObject.SCAC = scac;
            newTrainObject.TrainSection = section;
            newTrainObject.TrainOriginDateTime = trainTime;
            newTrainObject.TrainOriginDate = trainTime.ToString("MMddyyyy");
            newTrainObject.TrainOriginDayOfMonth = trainTime.Day.ToString("D2");
            string trainId = newTrainObject.TrainSymbol + " " + newTrainObject.TrainOriginDayOfMonth;
            if (section == "")
            {
                newTrainObject.TrainId = trainId;
            } else {
                newTrainObject.TrainId = trainId + "-" + section;
            }
            
            if (PDS_CORE.Code_Utils.NS_TrainID.trainObjectDictionary.ContainsKey(trainSeed))
            {
                PDS_CORE.Code_Utils.NS_TrainID.trainObjectDictionary[trainSeed] = newTrainObject;
            } else {
                PDS_CORE.Code_Utils.NS_TrainID.trainObjectDictionary.Add(trainSeed, newTrainObject);
            }
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void CreatePTCLabTrainIfDoesNotExist_Trainsheet_MIS(string misOrManual, string trainSeed, string schedule_reportType, string schedule_trainCategory, string schedule_trainGroup, string schedule_trainOrigin, string schedule_trainDestination, string schedule_stations, string trainSegment_effectiveLocation, string trainSegment_effectivePasscount, string trainSegment_dateOffsetDays, string trainSegment_timeOffsetMinutes, string trainSegment_timeZone, string trainSegment_timeType, string trainSegment_trainOrigin, string trainSegment_trainDestination, string consistSeed, string trainConsist_reportingLocation, string trainConsist_reportingPassCount, string trainConsist_reportingSource, string trainConsist_tihConstraintRecord, string trainConsist_maxPlateSize, string trainConsist_numberOfLoads, string trainConsist_numberOfEmpties, string trainConsist_trailingTonnage, string trainConsist_trainLength, string trainConsist_axles, string trainConsist_operativeBrakes, string trainConsist_totalBrakingForce, string trainConsist_speedClass, string trainConsist_maxCarWeightConstraintRecord, string trainConsist_maxCarHeightConstraintRecord, string trainConsist_maxCarWidthConstraintRecord, string trainConsist_hazmatConstraintRecord, string engineSeeds, string engineConsist_assignedDivision, string engineConsist_helperCrewPoolID, string engineConsist_reportingSource, string engineConsist_reportingLocation, string engineConsist_reportingPassCount, string engineConsist_defaultDataApplied, string engineConsist_purpose, string engineConsist_engines, string hostname)
        {
            bool useMIS = false;
            if (misOrManual.Equals("MIS", StringComparison.OrdinalIgnoreCase))
            {
                useMIS = true;
            }
            
            string scac = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSCAC(trainSeed);
            string section = PDS_CORE.Code_Utils.NS_TrainID.GetTrainSection(trainSeed);
            System.DateTime originDate = PDS_CORE.Code_Utils.NS_TrainID.GetTrainOriginDateTime(trainSeed);
            
            if (!NS_Trainsheet.NS_OpenTrainsheetIfTrainExists_MainMenu(trainSeed))
            {
                //If the train doesn't exist, we need to create it.
                if (useMIS)
                {
                    
                    PDS_NS.UserCodeCollections.NS_MIS_Messages.NS_SendCreateSchedule_43Simple_ExistingTrainId(trainSeed, schedule_reportType, schedule_trainCategory, 
        	    	                                                                                          schedule_trainGroup, schedule_trainOrigin, schedule_trainDestination,
        	    	                                                                                          schedule_stations, hostname);
                    
                    PDS_NS.UserCodeCollections.NS_MIS_Messages.NS_SendTrainSegment_48Simple(trainSeed, trainSegment_effectiveLocation, trainSegment_effectivePasscount, 
                                                                                            trainSegment_dateOffsetDays, trainSegment_timeOffsetMinutes, trainSegment_timeZone, 
                                                                                            trainSegment_timeType, trainSegment_trainOrigin, trainSegment_trainDestination, hostname);
                    
                    PDS_NS.UserCodeCollections.NS_MIS_Messages.NS_SendTrainConsistSummary_43Simple(trainSeed, consistSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, 
                                                                                                   trainConsist_reportingSource, trainConsist_tihConstraintRecord, trainConsist_maxPlateSize, 
                                                                                                   trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, 
                                                                                                   trainConsist_trainLength, trainConsist_axles, trainConsist_operativeBrakes, 
                                                                                                   trainConsist_totalBrakingForce, trainConsist_speedClass, 
                                                                                                   trainConsist_maxCarWeightConstraintRecord, trainConsist_maxCarHeightConstraintRecord, 
                                                                                                   trainConsist_maxCarWidthConstraintRecord, trainConsist_hazmatConstraintRecord, hostname);
        	    	
                    PDS_NS.UserCodeCollections.NS_MIS_Messages.NS_SendEngineConsist_48Simple(trainSeed, engineSeeds, engineConsist_assignedDivision, engineConsist_helperCrewPoolID, 
                                                                                             engineConsist_reportingSource, engineConsist_reportingLocation, engineConsist_reportingPassCount, 
                                                                                             engineConsist_defaultDataApplied, engineConsist_purpose, engineConsist_engines, hostname);
                } else {
                    NS_Trainsheet.NS_CreateTrainSchedulePipedStations_UI(trainSeed, section, scac, originDate.ToString("MM-dd-yyyy"), schedule_trainGroup, schedule_trainCategory, schedule_reportType, schedule_stations, true);
                    
                    NS_Trainsheet.NS_CreateTrain_CreateTrainForm(trainSeed, "Start", trainSegment_timeOffsetMinutes, trainSegment_timeZone, "", false);
                    
                    NS_Trainsheet.AddConsistSummary_Trainsheet(trainSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, trainConsist_trainLength, consistSeed, "", false);
                    
                    NS_Trainsheet.NS_ManuallyAddPipedEngine_Trainsheet(trainSeed, engineSeeds, engineConsist_engines, "", true);
                }
            } else {
                //TODO: We could add stuff here to make sure the schedule/consist/etc are correct before calling it done
                
                //Put train Consist into object
                PDS_CORE.Code_Utils.NS_TrainID.CreateConsistSummaryRecord(trainSeed, consistSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, trainConsist_reportingSource, trainConsist_speedClass, trainConsist_maxPlateSize, 
                                                                          trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, trainConsist_trainLength, trainConsist_axles, trainConsist_operativeBrakes, 
                                                                          trainConsist_totalBrakingForce, trainConsist_maxCarWeightConstraintRecord, trainConsist_maxCarHeightConstraintRecord, trainConsist_maxCarWidthConstraintRecord, 
                                                                          trainConsist_hazmatConstraintRecord, trainConsist_tihConstraintRecord);
                
                //Put engine Record(s) into objects
                string[] splitEngineSeeds = engineSeeds.Split('|');
                string[] splitEngineRecords = engineConsist_engines.Split('|');
                for (int i = 0; i < splitEngineSeeds.Length; i++)
                {
                    string engineRecord = splitEngineRecords[i*26 + 0] + "|" + splitEngineRecords[i*26 + 1] + "|" + splitEngineRecords[i*26 + 2] + "|" + splitEngineRecords[i*26 + 3] + "|" + splitEngineRecords[i*26 + 4] + "|" + 
                        splitEngineRecords[i*26 + 5] + "|" + splitEngineRecords[i*26 + 6] + "|" + splitEngineRecords[i*26 + 7] + "|" + splitEngineRecords[i*26 + 8] + "|" + splitEngineRecords[i*26 + 9] + "|" + splitEngineRecords[i*26 + 10] + 
                        "|" + splitEngineRecords[i*26 + 11] + "|" + splitEngineRecords[i*26 + 12] + "|" + splitEngineRecords[i*26 + 13] + "|" + splitEngineRecords[i*26 + 14] + "|" + splitEngineRecords[i*26 + 15] + "|" + 
                        splitEngineRecords[i*26 + 16] + "|" + splitEngineRecords[i*26 + 17] + "|" + splitEngineRecords[i*26 + 18] + "|" + splitEngineRecords[i*26 + 19] + "|" + splitEngineRecords[i*26 + 20] + "|" + splitEngineRecords[i*26 + 21] + 
                        "|" + splitEngineRecords[i*26 + 22] + "|" + splitEngineRecords[i*26 + 23] + "|" + splitEngineRecords[i*26 + 24] + "|" + splitEngineRecords[i*26 + 25];
                    PDS_CORE.Code_Utils.NS_TrainID.CreateEngineConsistRecord(trainSeed, splitEngineSeeds[i], engineRecord, engineConsist_assignedDivision, engineConsist_helperCrewPoolID, engineConsist_defaultDataApplied, engineConsist_reportingPassCount,
                                                                             engineConsist_reportingLocation, engineConsist_reportingSource, engineConsist_purpose);
                }
            }
        }
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void CreatePTCLabTrainConsistSummary_Trainsheet_MIS(string misOrManual, string trainSeed, string consistSeed, string trainConsist_reportingLocation, string trainConsist_reportingPassCount, string trainConsist_reportingSource, string trainConsist_tihConstraintRecord, string trainConsist_maxPlateSize, string trainConsist_numberOfLoads, string trainConsist_numberOfEmpties, string trainConsist_trailingTonnage, string trainConsist_trainLength, string trainConsist_axles, string trainConsist_operativeBrakes, string trainConsist_totalBrakingForce, string trainConsist_speedClass, string trainConsist_maxCarWeightConstraintRecord, string trainConsist_maxCarHeightConstraintRecord, string trainConsist_maxCarWidthConstraintRecord, string trainConsist_hazmatConstraintRecord, string hostname)
        {
            bool useMIS = false;
            if (misOrManual.Equals("MIS", StringComparison.OrdinalIgnoreCase))
            {
                useMIS = true;
            }
            
            if (useMIS)
            {
                PDS_NS.UserCodeCollections.NS_MIS_Messages.NS_SendTrainConsistSummary_43Simple(trainSeed, consistSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, 
                                                                                               trainConsist_reportingSource, trainConsist_tihConstraintRecord, trainConsist_maxPlateSize, 
                                                                                               trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, 
                                                                                               trainConsist_trainLength, trainConsist_axles, trainConsist_operativeBrakes, 
                                                                                               trainConsist_totalBrakingForce, trainConsist_speedClass, 
                                                                                               trainConsist_maxCarWeightConstraintRecord, trainConsist_maxCarHeightConstraintRecord, 
                                                                                               trainConsist_maxCarWidthConstraintRecord, trainConsist_hazmatConstraintRecord, hostname);
            } else {
                NS_Trainsheet.AddConsistSummary_Trainsheet(trainSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, trainConsist_trainLength, consistSeed, "", true);
            }
        }
    }
}
