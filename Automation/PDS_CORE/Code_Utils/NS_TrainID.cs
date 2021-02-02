/*
 * Created by Ranorex
 * User: 503073759
 * Date: 11/14/2018
 * Time: 7:45 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.Linq;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using Oracle;
using Env;


namespace PDS_CORE.Code_Utils
{
	public class NS_TrainScheduleRowTimes
	{
		public string STATime { get; set; }
		public string STDTime { get; set; }
	}
	
    public class NS_TrainObject
	{
		public string TrainId { get; set; }
		public string TrainSymbol { get; set; }
		public string TrainSection { get; set; }
		public string SCAC { get; set; }
		public string PTCEngineId { get; set; } // meh
		public string PTCCrewMember { get; set; } // meh
		public string TrainClearance { get; set; }
		public string LocoState { get; set; } // meh
		public string TrainOriginDate = System.DateTime.Now.Day.ToString("D2");
		public System.DateTime TrainOriginDateTime = System.DateTime.Now;
		public string TrainOriginDayOfMonth { get; set; }
		public string TrainOriginDateTimeZone { get; set; }
		public string TrainKey = null;
		
		public List<NS_TrainScheduleRowTimes> TrainScheduleTimeRowList = new List<NS_TrainScheduleRowTimes>();
		private Dictionary<string, NS_EngineConsistObject> engineDictionary = new Dictionary<string, NS_EngineConsistObject>();
		private Dictionary<string, NS_ConsistObject> consistDictionary = new Dictionary<string, NS_ConsistObject>();
		private Dictionary<string, NS_TrainHistoryMessageObject> trainHistoryDictionary = new Dictionary<string, NS_TrainHistoryMessageObject>();
		
//		public void AddCrewGroupObject(string crewSeed, NS_CrewGroupObject crew)
//		{
//			if (!CrewGroupExists(crewSeed))
//			{
//				crewGroupDictionary.Add(crewSeed, crew);
//			}
//		}
		
		public void AddEngineObject(string engineSeed, NS_EngineConsistObject engines)
		{
			if (!EngineRecordExists(engineSeed))
			{
				engineDictionary.Add(engineSeed, engines);
			}
		}
		
		public void AddConsistObject(string consistSeed, NS_ConsistObject consist)
		{
			if (!ConsistRecordExists(consistSeed))
			{
				consistDictionary.Add(consistSeed, consist);
			}
		}
		
//		public NS_CrewGroupObject GetCrewGroupObject(string crewSeed)
//		{
//			NS_CrewGroupObject crew = crewGroupDictionary[crewSeed];
//			return crew;
//		}
		
		public NS_EngineConsistObject GetEngineObject(string engineSeed)
		{
			if (!engineDictionary.ContainsKey(engineSeed))
		    {
		    	return null;
		    }
			NS_EngineConsistObject engine = engineDictionary[engineSeed];
			return engine;
		}
		
		public NS_EngineConsistObject GetFirstEngineObject()
		{
			if (engineDictionary.Count <= 0)
		    {
		    	return null;
		    }
			NS_EngineConsistObject engine = engineDictionary.ElementAt(0).Value;
			return engine;
		}
		
		public NS_ConsistObject GetConsistObject(string consistSeed)
		{
			NS_ConsistObject consist = consistDictionary[consistSeed];
			return consist;
		}
//		
//		public void SetCrewGroupObject(string crewSeed, NS_CrewGroupObject crew)
//		{
//			crewGroupDictionary[crewSeed] = crew;
//		}
		
		public void SetEngineObject(string engineSeed, NS_EngineConsistObject engine)
		{
			engineDictionary[engineSeed] = engine;
		}
		
		public void SetConsistObject(string consistSeed, NS_ConsistObject consist)
		{
			consistDictionary[consistSeed] = consist;
		}
		
//		public void RemoveCrewObject(string crewSeed)
//		{
//			crewGroupDictionary.Remove(crewSeed);
//		}
		
		public void RemoveEngineObject(string engineSeed)
		{
			engineDictionary.Remove(engineSeed);
		}
		
		public void RemoveConsistObject(string consistSeed)
		{
			consistDictionary.Remove(consistSeed);
		}
		
//		public bool CrewGroupExists(string crewSeed)
//		{
//			return crewGroupDictionary.ContainsKey(crewSeed);
//		}
		
		public bool EngineRecordExists(string engineSeed)
		{
			return engineDictionary.ContainsKey(engineSeed);
		}
		
		public bool ConsistRecordExists(string consistSeed)
		{
			return consistDictionary.ContainsKey(consistSeed);
		}
		
		public bool HistoryRecordExists(string messageType)
		{
			return trainHistoryDictionary.ContainsKey(messageType);
		}
		
		public void OffsetTrainOriginDate(string originDay)
		{
				System.DateTime origin = System.DateTime.Now;

				if (!originDay.Equals("") && !originDay.Equals("current", StringComparison.OrdinalIgnoreCase))
    			{
					// Create conditional variables
					System.DateTime outDateTime;
					int numDays = 0;

					// First, attempt to parse the originDay as a valid date in the format of MMddyyyy
					// TODO: Ensure that this does not result in a midnight origin date each time. 
					// If it does, then it would impact objects which rely on this time, such as crew on duty time. 
					if (System.DateTime.TryParseExact(originDay, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime))
					{
						origin = outDateTime;
					} 
					else if (Int32.TryParse(originDay, out numDays))  
					{
						origin = origin.AddDays(Convert.ToDouble(numDays));
					}
				}

				TrainOriginDate = origin.ToString("MMddyyyy");
				TrainOriginDayOfMonth = origin.Day.ToString("D2");
				TrainOriginDateTime = origin;
		}

		


		
		/// <summary>
		/// Finds the associated engineSeed of an engine for a particular train
		/// </summary>
		/// <param name="engineId">ID of the desired engine should be in format "{SCAC} {Engine Number}"</param>
		/// <returns></returns>
		public string GetEngineSeedfromEngineId (string engineId)
		{
			string[] engineDetails = engineId.Split(' '); //[0] -> SCAC, [1] => eEngine number
			List<string> keyList = new List<string> (engineDictionary.Keys);
			NS_EngineConsistObject engineObj = null;
			foreach (string engineSeed in keyList)
			{
				engineObj = GetEngineObject(engineSeed);
				if (engineObj.SCAC.Equals(engineDetails[0]) && engineObj.EngineNumber.Equals(engineDetails[1]))
				{
					return engineSeed;
				}
			}
			Ranorex.Report.Info("Engine " + engineDetails[0] + " " + engineDetails[1] + " is not an associated engine of " + TrainId);
			return "";
		}
		
		public void AddTrainScheduleSTASTDRow(string sta, string std)
		{
			NS_TrainScheduleRowTimes newRow = new NS_TrainScheduleRowTimes();
			newRow.STATime = sta;
			newRow.STDTime = std;
			TrainScheduleTimeRowList.Add(newRow);
			return;
		}
		
		public void EditTrainScheduleSTASTDRow(int row, string sta, string std)
		{
			if (TrainScheduleTimeRowList.ElementAt(row) != null)
			{
				TrainScheduleTimeRowList[row].STATime = sta;
				TrainScheduleTimeRowList[row].STDTime = std;
			} else {
				Ranorex.Report.Error("Could not edit sta and std row {" + row.ToString() + "} because it doesn't exist int he list");
			}
			return;
		}
		
		public void InsertTrainScheduleSTASTDRow(int row, string sta, string std)
		{
			NS_TrainScheduleRowTimes newRow = new NS_TrainScheduleRowTimes();
			newRow.STATime = sta;
			newRow.STDTime = std;
			TrainScheduleTimeRowList.Insert(row, newRow);
			return;
		}
		
		public NS_TrainScheduleRowTimes GetTrainScheduleSTASTDForRow(int rowNumber)
		{
			if (rowNumber >= TrainScheduleTimeRowList.Count)
			{
				Ranorex.Report.Error("No Train Schedule STA STD stored on row " + rowNumber.ToString());
				return null;
			}
			return TrainScheduleTimeRowList[rowNumber];
		}
	}
    
    // Used during runtime to increase successive crews' employee id values by one unit.
    // The members of this class keep the information in memory over runtime.
    public static class NS_EmployeeId
    {
    	public static bool EmployeeIdHasBeenQueried = false;
    	public static string EmployeeId { get { return getNewEmployeeId();}}
    	private static int _EmployeeId = 0;
    	
    	private static string getNewEmployeeId()
        {
        	if (!EmployeeIdHasBeenQueried)
        	{
        		// Finds existing crew information from the database.
        		// This is used to set the crew employee id, which must be unique from existing records. 
        		try
        		{
            		_EmployeeId = Oracle.Code_Utils.ADMSEnvironment.GetMaxCrewEmployeeId();        		
        		}
        		catch(Exception)
        		{
        		    Report.Info("Could not connect to ADMS for maxEmployeeId. Ignoring ADMS and using Zero (0)");
        		}
        		EmployeeIdHasBeenQueried = true;
        	}
        	_EmployeeId++;
        	return _EmployeeId.ToString();
        }
    }
    
	public class NS_CrewMemberObject
	{
		public string crewSeed {get; set;}
		public string onDutyLocation {get; set;}
		public string offDutyLocation {get; set;}
		public string onTrainLocation {get; set;}
		public string onPassCount {get; set;}
		public string onLocationMP {get; set;}
		public string offTrainLocation {get; set;}
		public string offPassCount {get; set;}
		public string offLocationMP {get; set;}
		public string crewPosition {get; set;}
		public string crewMemberType {get; set;}
		public string firstInitial {get; set;}
		public string middleInitial {get; set;}
		public string lastName {get; set;}
		public string ssn {get; set;}
		public string employeeId {get; set;}
		public string onDutyDate {get; set;}
		public string onDutyTime {get; set;}
		public string onDutyTimezone {get; set;}
		public System.DateTime? onDutyDateTime {get; set;}
		public string onTrainDate {get; set;}
		public string onTrainTime {get; set;}
		public string onTrainTimezone {get; set;}
		public System.DateTime? onTrainDateTime {get; set;}
		public string hosExpireDate {get; set;}
		public string hosExpireTime {get; set;}
		public string hosExpireTimezone {get; set;}
		public System.DateTime? hosExpireDateTime {get; set;}
		public string offDutyDate {get; set;}
		public string offDutyTime {get; set;}
		public string offDutyTimezone {get; set;}
		public System.DateTime? offDutyDateTime {get; set;}
		public string offTrainDate {get; set;}
		public string offTrainTime {get; set;}
		public string offTrainTimezone {get; set;}
		public System.DateTime? offTrainDateTime {get; set;}
		public string scac {get; set;}
		public string section {get; set;}
		public string originDate {get; set;}
		public string crewId {get; set;}
		public string segment {get; set;}
	}
	
	public static class NS_CrewClass
	{
		public static Dictionary<string, NS_CrewMemberObject> crewMemberDictionary = new Dictionary<string, NS_CrewMemberObject>();
		public static Dictionary<string, List<NS_CrewMemberObject>> crewGroupDictionary = new Dictionary<string, List<NS_CrewMemberObject>>();
		
		public static void CreateCrewMemberObject(string crewSeed, string onDutyLocation, string offDutyLocation, string onTrainLocation, string onPassCount, 
		                                          string onLocationMP, string offTrainLocation, string offPassCount, string offLocationMP, string crewPosition, 
		                                          string crewMemberType, string firstInitial, string middleInitial, string lastName, string ssn, string employeeId, 
		                                          string onDutyDate, string onDutyTime, string onDutyTimezone, string onTrainDate, string onTrainTime, string onTrainTimezone, 
		                                          string hosExpireDate, string hosExpireTime, string hosExpireTimezone, string offDutyDate, string offDutyTime, 
		                                          string offDutyTimezone, string offTrainDate, string offTrainTime, string offTrainTimezone, string crewId, string segment)
		{
			CultureInfo enUS = new CultureInfo("en-US");
			System.DateTime parsedDateTime;
			NS_CrewMemberObject crewMemberObject = new NS_CrewMemberObject();
			crewMemberObject.crewSeed = crewSeed;
			crewMemberObject.onDutyLocation = onDutyLocation;
			crewMemberObject.offDutyLocation = offDutyLocation;
			crewMemberObject.onTrainLocation = onTrainLocation;
			crewMemberObject.onPassCount = onPassCount;
			crewMemberObject.onLocationMP = onLocationMP;
			crewMemberObject.offTrainLocation = offTrainLocation;
			crewMemberObject.offPassCount = offPassCount;
			crewMemberObject.offLocationMP = offLocationMP;
			crewMemberObject.crewPosition = crewPosition;
			crewMemberObject.crewMemberType = crewMemberType;
			crewMemberObject.firstInitial = firstInitial;
			crewMemberObject.middleInitial = middleInitial;
			crewMemberObject.lastName = lastName;
			crewMemberObject.ssn = ssn;
			crewMemberObject.employeeId = employeeId;
			crewMemberObject.onDutyDate = onDutyDate;
			crewMemberObject.onDutyTime = onDutyTime;
			crewMemberObject.onDutyTimezone = onDutyTimezone;
			if (!string.IsNullOrEmpty(onDutyDate) && !string.IsNullOrEmpty(onDutyTime))
			{
				if (System.DateTime.TryParseExact(onDutyDate + " " + onDutyTime, "MMddyyyy HHmm", enUS, DateTimeStyles.None, out parsedDateTime))
				{
					crewMemberObject.onDutyDateTime = parsedDateTime;
				}
			}
			crewMemberObject.onTrainDate = onTrainDate;
			crewMemberObject.onTrainTime = onTrainTime;
			crewMemberObject.onTrainTimezone = onTrainTimezone;
			if (!string.IsNullOrEmpty(onTrainDate) && !string.IsNullOrEmpty(onTrainTime))
			{
				if (System.DateTime.TryParseExact(onTrainDate + " " + onTrainTime, "MMddyyyy HHmm", enUS, DateTimeStyles.None, out parsedDateTime))
				{
					crewMemberObject.onTrainDateTime = parsedDateTime;
				}
			}
			crewMemberObject.hosExpireTime = hosExpireTime;
			crewMemberObject.hosExpireDate = hosExpireDate;
			crewMemberObject.hosExpireTimezone = hosExpireTimezone;
			if (!string.IsNullOrEmpty(hosExpireDate) && !string.IsNullOrEmpty(hosExpireTime))
			{
				if (System.DateTime.TryParseExact(hosExpireDate + " " + hosExpireTime, "MMddyyyy HHmm", enUS, DateTimeStyles.None, out parsedDateTime))
				{
					crewMemberObject.hosExpireDateTime = parsedDateTime;
				}
			}
			crewMemberObject.offDutyDate = offDutyDate;
			crewMemberObject.offDutyTime = offDutyTime;
			crewMemberObject.offDutyTimezone = offDutyTimezone;
			if (!string.IsNullOrEmpty(offDutyDate) && !string.IsNullOrEmpty(offDutyTime))
			{
				if (System.DateTime.TryParseExact(offDutyDate + " " + offDutyTime, "MMddyyyy HHmm", enUS, DateTimeStyles.None, out parsedDateTime))
				{
					crewMemberObject.offDutyDateTime = parsedDateTime;
				}
			}
			crewMemberObject.offTrainDate = offTrainDate;
			crewMemberObject.offTrainTime = offTrainTime;
			crewMemberObject.offTrainTimezone = offTrainTimezone;
			if (!string.IsNullOrEmpty(offTrainDate) && !string.IsNullOrEmpty(offTrainTime))
			{
				if (System.DateTime.TryParseExact(offTrainDate + " " + offTrainTime, "MMddyyyy HHmm", enUS, DateTimeStyles.None, out parsedDateTime))
				{
					crewMemberObject.offTrainDateTime = parsedDateTime;
				}
			}
			crewMemberObject.crewId = crewId;
			crewMemberObject.segment = segment;
			AddCrewMemberObjectToDictionary(crewSeed, crewMemberObject);
			if (crewId != "")
			{
				AddCrewMemberToCrewGroup(crewSeed, crewId);
			}
			return;
		}
		
		public static string RefactorAndCreateCrewMemberObject_CrewMemberRecords(string crewSeed, string crewRecord, string crewId, string segment)
		{
			string[] crewSeeds = crewSeed.Split('|');
			string[] crewRecords = crewRecord.Split('|');
			string refactoredCrewRecord = "";
			
			System.DateTime now = System.DateTime.Now;
			
			int smallCrewElementCount = 28;
			int fullCrewElementCount = 34;
			int numberOfSeeds = crewSeeds.Length;
			
			//Refactor the crew member record
			
			if (crewRecord.Length == 0)
			{
				return crewRecord;
			}
			
			if (crewRecords.Length%smallCrewElementCount != 0 && crewRecords.Length%fullCrewElementCount != 0)
			{
				Ranorex.Report.Error("Crew Record should be a factor of 28 or 33, found to be {"+crewRecords.Length+"}.");
				return crewRecord;
			}
			
			//Shorthand version of the crews not including date variations
			if (crewRecords.Length%smallCrewElementCount == 0)
			{
				for (int i=0; i<crewRecords.Length/smallCrewElementCount; i++)
				{
                    string onDutyLocation = crewRecords[smallCrewElementCount*i];
                    string offDutyLocation = crewRecords[smallCrewElementCount*i+1];
                    string onTrainLocation = crewRecords[smallCrewElementCount*i+2];
                    string onPassCount = crewRecords[smallCrewElementCount*i+3];
                    string onLocationMP = crewRecords[smallCrewElementCount*i+4];
                    string offTrainLocation = crewRecords[smallCrewElementCount*i+5];
                    string offPassCount = crewRecords[smallCrewElementCount*i+6];
                    string offLocationMP = crewRecords[smallCrewElementCount*i+7];
                    string crewPosition = crewRecords[smallCrewElementCount*i+8];
                    string crewMemberType = crewRecords[smallCrewElementCount*i+9];
                    string firstInitial = crewRecords[smallCrewElementCount*i+10];
                    string middleInitial = crewRecords[smallCrewElementCount*i+11];
                    string lastName = crewRecords[smallCrewElementCount*i+12];
                    string ssn = crewRecords[smallCrewElementCount*i+13];
                    string employeeId = crewRecords[smallCrewElementCount*i+14];
                    //Generates employee ID for blank string due to legacy issues
                    if (employeeId.ToLower().Equals("default") || employeeId.Equals(""))
                    {
                    	if (i < numberOfSeeds)
                    	{
	                    	NS_CrewMemberObject CrewObject = NS_CrewClass.GetCrewMemberObject(crewSeeds[i]);
	                    	if (CrewObject != null)
	                    	{
		                    	if (CrewObject.firstInitial == firstInitial && CrewObject.middleInitial == middleInitial && CrewObject.lastName == lastName)
		                    	{
		                    		employeeId = CrewObject.employeeId;
		                    	} else {
		                    		employeeId = NS_EmployeeId.EmployeeId;
		                    	}
	                    	} else {
	                    		employeeId = NS_EmployeeId.EmployeeId;
	                    	}
                    	} else {
                    		employeeId = NS_EmployeeId.EmployeeId;
                    	}
                    }
                    
                    string onDutyDate = "";
                    string onDutyTime = "";
                    if (crewRecords[smallCrewElementCount*i+15] != "") {
                    	System.DateTime onDutyDateTime = now.AddMinutes(Convert.ToDouble(crewRecords[smallCrewElementCount*i+15]));
                    	onDutyDate = onDutyDateTime.ToString("MMddyyyy");
                    	onDutyTime = onDutyDateTime.ToString("HHmm");
                    }
                    string onDutyTimezone = crewRecords[smallCrewElementCount*i+16];
                    
                    string onTrainDate = "";
                    string onTrainTime = "";
                    if (crewRecords[smallCrewElementCount*i+17] != "") {
	                    System.DateTime onTrainDateTime = now.AddMinutes(Convert.ToDouble(crewRecords[smallCrewElementCount*i+17]));
	                    onTrainDate = onTrainDateTime.ToString("MMddyyyy");
	                    onTrainTime = onTrainDateTime.ToString("HHmm"); 
                    }
                    string onTrainTimezone = crewRecords[smallCrewElementCount*i+18]; 
                    
                    string hosExpireDate = "";
                    string hosExpireTime = "";
                    if (crewRecords[smallCrewElementCount*i+19] != "")
                    {
                    	System.DateTime hosDateTime = now.AddMinutes(Convert.ToDouble(crewRecords[smallCrewElementCount*i+19]));
                    	hosExpireDate = hosDateTime.ToString("MMddyyyy");
                    	hosExpireTime = hosDateTime.ToString("HHmm");
                    }
                    string hosExpireTimezone = crewRecords[smallCrewElementCount*i+20];
                    
                    string offDutyDate = "";
                    string offDutyTime = "";
                    if (crewRecords[smallCrewElementCount*i+21] != "")
                    {
                    	System.DateTime offDutyDateTime = now.AddMinutes(Convert.ToDouble(crewRecords[smallCrewElementCount*i+21]));
                    	offDutyDate = offDutyDateTime.ToString("MMddyyyy");
                    	offDutyTime = offDutyDateTime.ToString("HHmm");
                    }
                    string offDutyTimezone = crewRecords[smallCrewElementCount*i+22];
                    
                    string offTrainDate = "";
                    string offTrainTime = "";
                    if (crewRecords[smallCrewElementCount*i+23] != "") {
                    	System.DateTime offTrainDateTime = now.AddMinutes(Convert.ToDouble(crewRecords[smallCrewElementCount*i+23]));
                    	offTrainDate = offTrainDateTime.ToString("MMddyyyy");
                    	offTrainTime = offTrainDateTime.ToString("HHmm");
                    }
                    string offTrainTimezone = crewRecords[smallCrewElementCount*i+24];
                    
                    string destinationTrainScacTrainSeed = crewRecords[smallCrewElementCount*i+25];
                    string storedScac = NS_TrainID.GetTrainSCAC(destinationTrainScacTrainSeed);
                    if (storedScac != null)
                    {
                    	destinationTrainScacTrainSeed = storedScac;
                    }
                    
                    string destinationTrainSectionTrainSeed = crewRecords[smallCrewElementCount*i+26];
                    string storedSection = NS_TrainID.GetTrainSection(destinationTrainSectionTrainSeed);
                    if (storedSection != null)
                    {
                    	destinationTrainSectionTrainSeed = storedSection;
                    }
                    
                    string destinationTrainSymbolTrainSeed = crewRecords[smallCrewElementCount*i+27];
                    string storedSymbol = NS_TrainID.GetTrainSymbol(destinationTrainSymbolTrainSeed);
                    if (storedSymbol != null)
                    {
                    	destinationTrainSymbolTrainSeed = storedSymbol;
                    }
                    
                    string destinationTrainOriginDate = now.ToString("MMddyyyy");
                    if (i < numberOfSeeds)
                    {
                    	NS_CrewMemberObject crewMemberObject = new NS_CrewMemberObject();
                    	CreateCrewMemberObject(crewSeeds[i], onDutyLocation, offDutyLocation, onTrainLocation, onPassCount, onLocationMP, offTrainLocation, offPassCount, offLocationMP, 
                    	                       crewPosition, crewMemberType, firstInitial, middleInitial, lastName, ssn, employeeId, onDutyDate, onDutyTime, onDutyTimezone, onTrainDate, 
                    	                       onTrainTime, onTrainTimezone, hosExpireDate, hosExpireTime, hosExpireTimezone, offDutyDate, offDutyTime, offDutyTimezone, offTrainDate, 
                    	                       offTrainTime, offTrainTimezone, crewId, segment);
                    } else {
                    	Ranorex.Report.Warn("No crew seed given for crew member record");
                    }
                    
                    if (i == 0)
                    {
                    	refactoredCrewRecord = onDutyLocation;
                    } else {
                    	refactoredCrewRecord = refactoredCrewRecord + "|" + onDutyLocation;
                    }
                    
                    refactoredCrewRecord = string.Join("|", new string[] {refactoredCrewRecord, offDutyLocation, onTrainLocation, onPassCount, onLocationMP, offTrainLocation, offPassCount,
                                                                              	offLocationMP, crewPosition, crewMemberType, firstInitial, middleInitial, lastName, ssn, employeeId, onDutyDate, onDutyTime, 
                                                                              	onDutyTimezone, onTrainDate, onTrainTime, onTrainTimezone, hosExpireDate, hosExpireTime, hosExpireTimezone, offDutyDate, 
                                                                              	offDutyTime, offDutyTimezone, offTrainDate, offTrainTime, offTrainTimezone, destinationTrainScacTrainSeed, 
                                                                              	destinationTrainSectionTrainSeed, destinationTrainSymbolTrainSeed, destinationTrainOriginDate});
				}
			} else {
				for (int i=0; i<crewRecords.Length/fullCrewElementCount; i++)
				{
                    string onDutyLocation = crewRecords[fullCrewElementCount*i];
                    string offDutyLocation = crewRecords[fullCrewElementCount*i+1];
                    string onTrainLocation = crewRecords[fullCrewElementCount*i+2];
                    string onPassCount = crewRecords[fullCrewElementCount*i+3];
                    string onLocationMP = crewRecords[fullCrewElementCount*i+4];
                    string offTrainLocation = crewRecords[fullCrewElementCount*i+5];
                    string offPassCount = crewRecords[fullCrewElementCount*i+6];
                    string offLocationMP = crewRecords[fullCrewElementCount*i+7];
                    string crewPosition = crewRecords[fullCrewElementCount*i+8];
                    string crewMemberType = crewRecords[fullCrewElementCount*i+9];
                    string firstInitial = crewRecords[fullCrewElementCount*i+10];
                    string middleInitial = crewRecords[fullCrewElementCount*i+11];
                    string lastName = crewRecords[fullCrewElementCount*i+12];
                    string ssn = crewRecords[fullCrewElementCount*i+13];
                    string employeeIdCrewSeed = crewRecords[fullCrewElementCount*i+14];
                    string employeeId = employeeIdCrewSeed;
                    if (employeeIdCrewSeed.ToLower() == "default")
                    {
                    	if (i < numberOfSeeds)
                    	{
	                    	NS_CrewMemberObject CrewObject = NS_CrewClass.GetCrewMemberObject(crewSeeds[i]);
	                    	if (CrewObject != null)
	                    	{
		                    	if (CrewObject.firstInitial == firstInitial && CrewObject.middleInitial == middleInitial && CrewObject.lastName == lastName)
		                    	{
		                    		employeeId = CrewObject.employeeId;
		                    	} else {
		                    		employeeId = NS_EmployeeId.EmployeeId;
		                    	}
	                    	} else {
	                    		employeeId = NS_EmployeeId.EmployeeId;
	                    	}
                    	} else {
                    		employeeId = NS_EmployeeId.EmployeeId;
                    	}
                    }
                    
                    
                    string onDutyDate = crewRecords[fullCrewElementCount*i+15];
                    int onDutyDateDayOffset;
                    if (int.TryParse(onDutyDate, out onDutyDateDayOffset))
                    {
                    	onDutyDate = now.AddDays(onDutyDateDayOffset).ToString("MMddyyyy");
                    }
                    string onDutyTime = crewRecords[fullCrewElementCount*i+16];
                    int onDutyTimeMinuteOffset;
                    if (int.TryParse(onDutyTime, out onDutyTimeMinuteOffset))
                    {
                    	onDutyTime = now.AddMinutes(onDutyTimeMinuteOffset).ToString("HHmm");
                    }
                    string onDutyTimezone = crewRecords[fullCrewElementCount*i+17];
                    
                    
                    string onTrainDate = crewRecords[fullCrewElementCount*i+18];
                    int onTrainDateDayOffset;
                    if (int.TryParse(onTrainDate, out onTrainDateDayOffset))
                    {
                    	onTrainDate = now.AddDays(onTrainDateDayOffset).ToString("MMddyyyy");
                    }
                    string onTrainTime = crewRecords[fullCrewElementCount*i+19];
                    int onTrainTimeMinuteOffset;
                    if (int.TryParse(onTrainTime, out onTrainTimeMinuteOffset))
                    {
                    	onTrainTime = now.AddMinutes(onTrainTimeMinuteOffset).ToString("HHmm");
                    }
                    string onTrainTimezone = crewRecords[fullCrewElementCount*i+20]; 
                    
                    
                    string hosExpireDate = crewRecords[fullCrewElementCount*i+21];
                    int hosExpireDateDayOffset;
                    if (int.TryParse(hosExpireDate, out hosExpireDateDayOffset))
                    {
                    	hosExpireDate = now.AddDays(hosExpireDateDayOffset).ToString("MMddyyyy");
                    }
                    string hosExpireTime = crewRecords[fullCrewElementCount*i+22];
                    int hosExpireTimeMinuteOffset;
                    if (int.TryParse(hosExpireTime, out hosExpireTimeMinuteOffset))
                    {
                    	hosExpireTime = now.AddMinutes(hosExpireTimeMinuteOffset).ToString("HHmm");
                    }
                    string hosExpireTimezone = crewRecords[fullCrewElementCount*i+23]; 
                    
                    
                    string offDutyDate = crewRecords[fullCrewElementCount*i+24];
                    int offDutyDateDayOffset;
                    if (int.TryParse(offDutyDate, out offDutyDateDayOffset))
                    {
                    	offDutyDate = now.AddDays(offDutyDateDayOffset).ToString("MMddyyyy");
                    }
                    string offDutyTime = crewRecords[fullCrewElementCount*i+25];
                    int offDutyTimeMinuteOffset;
                    if (int.TryParse(offDutyTime, out offDutyTimeMinuteOffset))
                    {
                    	offDutyTime = now.AddMinutes(offDutyTimeMinuteOffset).ToString("HHmm");
                    }
                    string offDutyTimezone = crewRecords[fullCrewElementCount*i+26]; 
                    
                    
                    string offTrainDate = crewRecords[fullCrewElementCount*i+27];
                    int offTrainDateDayOffset;
                    if (int.TryParse(offTrainDate, out offTrainDateDayOffset))
                    {
                    	offTrainDate = now.AddDays(offTrainDateDayOffset).ToString("MMddyyyy");
                    }
                    string offTrainTime = crewRecords[fullCrewElementCount*i+28];
                    int offTrainTimeMinuteOffset;
                    if (int.TryParse(offTrainTime, out offTrainTimeMinuteOffset))
                    {
                    	offTrainTime = now.AddMinutes(offTrainTimeMinuteOffset).ToString("HHmm");
                    }
                    string offTrainTimezone = crewRecords[fullCrewElementCount*i+29]; 
                    
                    
                    string destinationTrainScacTrainSeed = crewRecords[i+30];
                    string storedScac = NS_TrainID.GetTrainSCAC(destinationTrainScacTrainSeed);
                    if (storedScac != null)
                    {
                    	destinationTrainScacTrainSeed = storedScac;
                    }
                    
                    string destinationTrainSectionTrainSeed = crewRecords[i+31];
                    string storedSection = NS_TrainID.GetTrainSection(destinationTrainSectionTrainSeed);
                    if (storedSection != null)
                    {
                    	destinationTrainSectionTrainSeed = storedSection;
                    }
                    
                    string destinationTrainSymbolTrainSeed = crewRecords[i+32];
                    string storedSymbol = NS_TrainID.GetTrainSymbol(destinationTrainSymbolTrainSeed);
                    if (storedSymbol != null)
                    {
                    	destinationTrainSymbolTrainSeed = storedSymbol;
                    }
                    
                    string destinationTrainOriginDateTrainSeed = crewRecords[i+33];
                    string storedOriginDate = NS_TrainID.getOriginDate(destinationTrainOriginDateTrainSeed);
                    int destinationTrainOriginDateDayOffset;
                    if (storedOriginDate != null)
                    {
                    	destinationTrainSymbolTrainSeed = storedOriginDate;
                    } else if (int.TryParse(destinationTrainOriginDateTrainSeed, out destinationTrainOriginDateDayOffset))
                    {
                    	destinationTrainOriginDateTrainSeed = now.AddDays(destinationTrainOriginDateDayOffset).ToString("MMddyyyy");
                    }
                    
                    if (i < numberOfSeeds)
                    {
                    	NS_CrewMemberObject crewMemberObject = new NS_CrewMemberObject();
                    	CreateCrewMemberObject(crewSeeds[i], onDutyLocation, offDutyLocation, onTrainLocation, onPassCount, onLocationMP, offTrainLocation, offPassCount, offLocationMP, 
                    	                       crewPosition, crewMemberType, firstInitial, middleInitial, lastName, ssn, employeeId, onDutyDate, onDutyTime, onDutyTimezone, onTrainDate, 
                    	                       onTrainTime, onTrainTimezone, hosExpireDate, hosExpireTime, hosExpireTimezone, offDutyDate, offDutyTime, offDutyTimezone, offTrainDate, 
                    	                       offTrainTime, offTrainTimezone, crewId, segment);
                    } else {
                    	Ranorex.Report.Warn("No crew seed given for crew member record");
                    }
                    
                    if (i == 0)
                    {
                    	refactoredCrewRecord = onDutyLocation;
                    } else {
                    	refactoredCrewRecord = refactoredCrewRecord + "|" + onDutyLocation;
                    }
                    
                    refactoredCrewRecord = string.Join("|", new string[] {refactoredCrewRecord, offDutyLocation, onTrainLocation, onPassCount, onLocationMP, offTrainLocation, offPassCount,
                                                                              	offLocationMP, crewPosition, crewMemberType, firstInitial, middleInitial, lastName, ssn, employeeId, onDutyDate, onDutyTime, 
                                                                              	onDutyTimezone, onTrainDate, onTrainTime, onTrainTimezone, hosExpireDate, hosExpireTime, hosExpireTimezone, offDutyDate, 
                                                                              	offDutyTime, offDutyTimezone, offTrainDate, offTrainTime, offTrainTimezone, destinationTrainScacTrainSeed, 
                                                                              	destinationTrainSectionTrainSeed, destinationTrainSymbolTrainSeed, destinationTrainOriginDateTrainSeed});
				}
			}
			return refactoredCrewRecord;
		}
		
		public static void AddCrewMemberObjectToDictionary(string crewSeed, NS_CrewMemberObject crewMemberObject)
		{
			if (!crewMemberDictionary.ContainsKey(crewSeed))
			{
				crewMemberDictionary.Add(crewSeed, crewMemberObject);
			} else {
				crewMemberDictionary[crewSeed] = crewMemberObject;
			}
			return;
		}
		
		public static NS_CrewMemberObject GetCrewMemberObject(string crewSeed)
		{
			NS_CrewMemberObject crewMember = null;
			if (crewMemberDictionary.ContainsKey(crewSeed))
			{
				crewMember = crewMemberDictionary[crewSeed];
			}
			return crewMember;
		}
		
		public static void AddCrewMemberToCrewGroup(string crewSeed, string optionalCrewId)
		{
			if (!crewMemberDictionary.ContainsKey(crewSeed))
			{
				Ranorex.Report.Error("Crew Seed {" + crewSeed + "} does not exist in the crew dictionary");
				return;
			}
			string crewId = crewMemberDictionary[crewSeed].crewId;
			if (optionalCrewId != "")
			{
				crewId = optionalCrewId;
			}
			
			if (crewId == "")
			{
				Ranorex.Report.Info("No Crew ID present, not added to internal crew group");
				return;
			}
			
			if (!crewGroupDictionary.ContainsKey(crewId))
			{
				List<NS_CrewMemberObject> newCrewMemberList = new List<NS_CrewMemberObject>();
				crewGroupDictionary.Add(crewId, newCrewMemberList);
			}
			if (!crewGroupDictionary[crewId].Contains(crewMemberDictionary[crewSeed]))
			{
				crewGroupDictionary[crewId].Add(crewMemberDictionary[crewSeed]);
			}
			return;
		}
		
		public static void AddCrewObjectToCrewGroup(NS_CrewMemberObject crewObject, string crewId)
		{
			if (crewId == "")
			{
				Ranorex.Report.Info("No Crew ID present, not added to internal crew group");
			} else {
				if (!crewGroupDictionary.ContainsKey(crewId))
				{
					List<NS_CrewMemberObject> newCrewMemberList = new List<NS_CrewMemberObject>();
					crewGroupDictionary.Add(crewId, newCrewMemberList);
				}
				crewGroupDictionary[crewId].Add(crewObject);
			}
			return;
		}
		
		public static List<NS_CrewMemberObject> GetCrewMembersFromGroup(string crewIdOrCrewSeed)
		{
			List<NS_CrewMemberObject> crewMemberList = new List<NS_CrewMemberObject>();
			bool crewId = false;
			bool crewSeed = false;
			crewId = crewGroupDictionary.ContainsKey(crewIdOrCrewSeed);
			crewSeed = crewMemberDictionary.ContainsKey(crewIdOrCrewSeed);
			if (!crewId && !crewSeed)
			{
				Ranorex.Report.Info("No Crew Members found for crew/group {" + crewIdOrCrewSeed + "}");
			} else if (crewId) {
				crewMemberList = crewGroupDictionary[crewIdOrCrewSeed];
			} else if (crewSeed) {
				string crewGroup = crewMemberDictionary[crewIdOrCrewSeed].crewId;
				if (crewGroupDictionary.ContainsKey(crewGroup))
				{
					crewMemberList = crewGroupDictionary[crewGroup];
				} else {
					Ranorex.Report.Info("No Crew Members found for group {" + crewGroup + "} from Crew Seed {" + crewIdOrCrewSeed + "}");
				}
			}
			return crewMemberList;
		}
		
		public static string GetCrewMemberFirstInitial(string crewSeed)
        {
        	string firstInitial = null;
        	NS_CrewMemberObject crewMember = GetCrewMemberObject(crewSeed);
        	if (crewMember != null)
        	{
        		firstInitial = crewMember.firstInitial;
        	}
        	return firstInitial;
        }
        
        public static string GetCrewMemberMiddleInitial(string crewSeed)
        {
        	string middleInitial = null;
        	NS_CrewMemberObject crewMember = GetCrewMemberObject(crewSeed);
        	if (crewMember != null)
        	{
        		middleInitial = crewMember.middleInitial;
        	}
        	return middleInitial;
        }
        
        public static string GetCrewMemberLastName(string crewSeed)
        {
        	string lastName = null;
        	NS_CrewMemberObject crewMember = GetCrewMemberObject(crewSeed);
        	if (crewMember != null)
        	{
        		lastName = crewMember.lastName;
        	}
        	return lastName;
        }
        
        public static string GetCrewMemberEmployeeId(string crewSeed)
        {
        	string employeeId = null;
        	NS_CrewMemberObject crewMember = GetCrewMemberObject(crewSeed);
        	if (crewMember != null)
        	{
        		employeeId = crewMember.employeeId;
        	}
        	return employeeId;
        }
        
        public static string GetCrewMemberLineSegment(string crewSeed)
        {
        	string crewLineSegment = null;
        	NS_CrewMemberObject crewMember = GetCrewMemberObject(crewSeed);
        	if (crewMember != null)
        	{
        		crewLineSegment = crewMember.segment;
        	}
        	return crewLineSegment;
        }
	}
//    public class NS_CrewGroupObject
//    {
//    	public string SCAC { get; set; }
//    	public string Section { get; set; }
//    	public string TrainSymbol { get; set; }
//    	public string TrainOriginDate { get; set; }
//    	public string CrewId { get; set; }
//    	public string CrewLineSegment { get; set; }
//    	public string SequenceNumber { get; set; }
//    	
//    	private Dictionary<int, NS_CrewMemberObject> crewMemberDictionary = new Dictionary<int, NS_CrewMemberObject>();
//    	
//    	public NS_CrewMemberObject GetCrewMember_ByIndexPosition(int indexNumber)
//    	{
//    		NS_CrewMemberObject crewMember = null;
//    		if (crewMemberDictionary.Count > indexNumber)
//    		{
//    			List<int> keys = GetCrewMemberKeys();
//    			int key = keys[indexNumber];
//    			crewMember = crewMemberDictionary[key];
//    		}
//    		return crewMember;
//    	}
//
//		public NS_CrewMemberObject GetCrewMemberObject_LastName(string lastName)
//		{
//			NS_CrewMemberObject crewMember = null;
//			int memberNumber = GetCrewMemberNumberFromLastName(lastName);
//			if (memberNumber != -1)
//			{
//				crewMember = GetCrewMemberObject_CrewNumber(memberNumber);
//			}
//			return crewMember;
//		}		
//    	
//    	public NS_CrewMemberObject GetCrewMemberObject_CrewNumber(int crewMemberNumber = 1)
//    	{
//    		NS_CrewMemberObject crewMember = null;
//    		if (crewMemberDictionary.ContainsKey(crewMemberNumber))
//		    {
//		    	crewMember = GetCrewMemberObject(crewMemberNumber);
//		    }
//    		return crewMember;
//    	}
//
//		public int GetCrewMemberNumberFromLastName(string lastName)
//		{
//			int memberNumber = -1;
//			List<int> memberNumbers = GetCrewMemberKeys();
//
//			NS_CrewMemberObject crewMember = null;
//			foreach (int num in memberNumbers)
//			{
//				crewMember = GetCrewMemberObject_CrewNumber(num);
//				if (lastName.Equals(crewMember.LastName, StringComparison.OrdinalIgnoreCase))
//				{
//					memberNumber = num;
//				}
//			}
//			return memberNumber;
//		}
//
//		public bool RemoveCrewMember_ByLastName(string lastName)
//		{
//			bool isRemoved = false;
//
//			int memberNumber = GetCrewMemberNumberFromLastName(lastName);
//			if (memberNumber != -1)
//			{
//				removeCrewMemberObject(memberNumber);
//				isRemoved = true;
//			}
//			return isRemoved;
//		}
//    	
//    	public List<int> GetCrewMemberKeys()
//    	{
//    		List<int> keyList = new List<int>(crewMemberDictionary.Keys);
//    		return keyList;
//    	}
//
//		public List<NS_CrewMemberObject> GetCrewMembersFromGroup()
//		{
//			List<NS_CrewMemberObject> crewMemberList = new List<NS_CrewMemberObject>();
//			List<int> keys = GetCrewMemberKeys();
//			
//			foreach (int key in keys)
//			{
//				NS_CrewMemberObject crewMember = GetCrewMemberObject_CrewNumber(key);
//				if (crewMember != null)
//				{
//					crewMemberList.Add(crewMember);
//				}
//			}
//			return crewMemberList;
//		}
//		
//
//    	public void AddCrewMemberObject(int crewMemberNumber, NS_CrewMemberObject crew)
//		{
//			if (!CrewMemberExists(crewMemberNumber))
//			{
//				crewMemberDictionary.Add(crewMemberNumber, crew);
//			}
//		}
//    	
//    	private void setCrewMemberObject(int crewMemberNumber, NS_CrewMemberObject crew)
//		{
//			crewMemberDictionary[crewMemberNumber] = crew;
//		}
//
//		private void removeCrewMemberObject(int crewMemberNumber)
//		{
//			crewMemberDictionary.Remove(crewMemberNumber);
//		}
//    	
//    	public bool CrewMemberExists(int crewMemberNumber)
//		{
//			return crewMemberDictionary.ContainsKey(crewMemberNumber);
//		}
//
//		public bool CrewMemberExists_LastName(string lastName)
//		{
//			bool crewMemberExists = false;
//			NS_CrewMemberObject CrewMember = GetCrewMemberObject_LastName(lastName);
//			if (CrewMember != null)
//			{
//				crewMemberExists = true;
//			}
//			return crewMemberExists;
//		}
//    	
//    	public NS_CrewMemberObject GetCrewMemberObject(int crewMemberNumber)
//		{
//			NS_CrewMemberObject crew = crewMemberDictionary[crewMemberNumber];
//			return crew;
//		}
//    	
//    	public void CreateCrewMembers(string trainSeed, string crewMemberRecord) {
//        	        	
//        	string[] crewRecordElements = crewMemberRecord.Split('|');
//        	
//        	int crewMemberNumber = 1;
//        	if (crewRecordElements[0].Equals(""))
//        	{
//        		Ranorex.Report.Warn("Crew Record Empty. Crew not created.");
//        		return;
//        	}
//        	if (crewRecordElements.Length % 28 != 0)
//        	{
//        		Ranorex.Report.Failure("Invalid crew record lengths present. Crew not created.");
//             	return;
//        	}
//        	
//        	for (int i = 0; i < crewRecordElements.Length; i=i+28)
//        	{
//        		NS_CrewMemberObject CrewMemberObject = new NS_CrewMemberObject();
//        		
//	        	System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
//	        	System.DateTime onDutyTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(crewRecordElements[i+15]));
//	        	System.DateTime onTrainTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(crewRecordElements[i+17]));
//	        	System.DateTime hosTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(crewRecordElements[i+19]));
//	        	System.DateTime offDutyTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(crewRecordElements[i+21]));
//	        	System.DateTime offTrainTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(crewRecordElements[i+23]));
//
//        		CrewMemberObject.OnDutyLocation = crewRecordElements[i+0];
//	        	CrewMemberObject.OffDutyLocation = crewRecordElements[i+1];
//	        	CrewMemberObject.OnTrainLocation = crewRecordElements[i+2];
//	        	CrewMemberObject.OnTrainPassCount = crewRecordElements[i+3];
//	        	CrewMemberObject.OnTrainLocationMilepost = crewRecordElements[i+4];
//	        	CrewMemberObject.OffTrainLocation = crewRecordElements[i+5];
//	        	CrewMemberObject.OffTrainPassCount = crewRecordElements[i+6];
//	        	CrewMemberObject.OffTrainLocationMilepost = crewRecordElements[i+7];
//	        	CrewMemberObject.CrewPosition = crewRecordElements[i+8];
//	        	CrewMemberObject.CrewMemberType = crewRecordElements[i+9];
//	        	CrewMemberObject.FirstInitial = crewRecordElements[i+10];
//	        	CrewMemberObject.MiddleInitial = crewRecordElements[i+11];
//	        	CrewMemberObject.LastName = crewRecordElements[i+12];
//	        	CrewMemberObject.SocialSecurityNo = crewRecordElements[i+13];
//	        	
//	        	if (!String.IsNullOrEmpty(crewRecordElements[i+14]))
//	        	{
//	        		CrewMemberObject.EmployeeId = crewRecordElements[i+14];
//	        	} else {
//	        		CrewMemberObject.EmployeeId = getNewEmployeeId();
//	        	}
//	        	
//	        	if (String.IsNullOrEmpty(crewRecordElements[i+15])) 
//	        	{
//	        		CrewMemberObject.OnDutyDate = null;
//	        		CrewMemberObject.OnDutyTime = null;
//	        		CrewMemberObject.OnDutyTimeZone = null;
//					// CrewMemberObject.OnDutyDateTime = null;
//	        	} else {
//	        		CrewMemberObject.OnDutyDate = onDutyTime.ToString("MMddyyyy");
//	        		CrewMemberObject.OnDutyTime = onDutyTime.ToString("HHmm");
//	        		CrewMemberObject.OnDutyTimeZone = crewRecordElements[i+16];
//					CrewMemberObject.OnDutyDateTime = onDutyTime;
//	        	}
//	        	
//				if (String.IsNullOrEmpty(crewRecordElements[i+17]))
//				{
//					CrewMemberObject.OnTrainDate = null;
//					CrewMemberObject.OnTrainTime = null;
//					CrewMemberObject.OnTrainTimeZone = null;
//					// CrewMemberObject.OnTrainDateTime = null;
//				} else {
//					CrewMemberObject.OnTrainDate = onTrainTime.ToString("MMddyyyy");
//					CrewMemberObject.OnTrainTime = onTrainTime.ToString("HHmm");
//					CrewMemberObject.OnTrainTimeZone = crewRecordElements[i+18];
//					CrewMemberObject.OnTrainDateTime = onTrainTime;
//				}
//				
//	        	CrewMemberObject.HOSExpireDate = hosTime.ToString("MMddyyyy");
//	        	CrewMemberObject.HOSExpireTime = hosTime.ToString("HHmm");
//	        	CrewMemberObject.HOSTimeZone = crewRecordElements[i+20];
//				CrewMemberObject.HOSExpireDateTime = hosTime;
//	        	
//	        	CrewMemberObject.OffDutyDate = offDutyTime.ToString("MMddyyyy");
//	        	CrewMemberObject.OffDutyTime = offDutyTime.ToString("HHmm");
//	        	CrewMemberObject.OffDutyTimeZone = crewRecordElements[i+22];
//				CrewMemberObject.OffDutyDateTime = offDutyTime;
//	        	
//	        	if (String.IsNullOrEmpty(crewRecordElements[i+23]))
//	        	{
//	        		CrewMemberObject.OffTrainDate = null;
//	        		CrewMemberObject.OffTrainTime = null;
//	        		CrewMemberObject.OffTrainTimeZone = null;
//					// CrewMemberObject.OffTrainDateTime = null;
//	        	} else {
//	        		CrewMemberObject.OffTrainDate = offTrainTime.ToString("MMddyyyy");
//	        		CrewMemberObject.OffTrainTime = offTrainTime.ToString("HHmm");
//	        		CrewMemberObject.OffTrainTimeZone = crewRecordElements[i+24];
//					CrewMemberObject.OffTrainDateTime = offTrainTime;
//	        	}
//
//        		CrewMemberObject.DestinationTrainSCAC = crewRecordElements[i+25];
//	        	CrewMemberObject.DestinationTrainSection = crewRecordElements[i+26];
//	        	CrewMemberObject.DestinationTrainSymbol = crewRecordElements[i+27];
//	        	CrewMemberObject.DestinationOriginDate = offTrainTime.ToString("MMddyyyy");
//	
//	        	if (CrewMemberExists(crewMemberNumber))
//	        	{
//		        	
//	        		// Effectively replaces an existing crew object with the same key.
//	        		setCrewMemberObject(crewMemberNumber, CrewMemberObject);
//	        	} else {
//	        		AddCrewMemberObject(crewMemberNumber, CrewMemberObject);
//	        	}
//	        	
//	        	crewMemberNumber++;
//        	}
//        }
    	
    	
    
    public class NS_TrainHistoryMessageObject 
    {
    	public string TrainMessageInHistory { get; set; }
    	
    }

//    public class NS_CrewMemberObject
//    {
//    	public string FirstInitial { get; set; }
//    	public string MiddleInitial { get; set; }
//    	public string LastName { get; set; }
//    	public string OnDutyLocation { get; set; }
//		public System.DateTime OnDutyDateTime { get; set; }
//    	public string OnDutyDate { get; set; }
//    	public string OnDutyTime { get; set; }
//    	public string OnDutyTimeZone { get; set; }
//    	public string OffDutyLocation { get; set; }
//		public System.DateTime OffDutyDateTime { get; set; }
//    	public string OffDutyDate { get; set; }
//    	public string OffDutyTime { get; set; }
//    	public string OffDutyTimeZone { get; set; }
//    	public string OnTrainLocation { get; set; }
//    	public string OnTrainLocationMilepost { get; set; }
//    	public string OnTrainPassCount { get; set; }
//		public System.DateTime OnTrainDateTime { get; set; }
//    	public string OnTrainDate { get; set; }
//    	public string OnTrainTime { get; set; }
//    	public string OnTrainTimeZone { get; set; }
//    	public string OffTrainLocation { get; set; }
//    	public string OffTrainLocationMilepost { get; set; }
//    	public string OffTrainPassCount { get; set; }
//		public System.DateTime OffTrainDateTime { get; set; }
//    	public string OffTrainDate { get; set; }
//    	public string OffTrainTime { get; set; }
//    	public string OffTrainTimeZone { get; set; }
//    	public string CrewPosition { get; set; }
//    	public string CrewMemberType { get; set; }
//    	public string SocialSecurityNo { get; set; }
//    	public string EmployeeId { get; set; }
//		public System.DateTime HOSExpireDateTime { get; set; }
//    	public string HOSExpireDate { get; set; }
//    	public string HOSExpireTime { get; set; }
//    	public string HOSTimeZone { get; set; }
//    	public string DestinationTrainSCAC { get; set; }
//    	public string DestinationTrainSection { get; set; }
//    	public string DestinationTrainSymbol { get; set; }
//    	public string DestinationOriginDate { get; set; }
//    }

    
    public class NS_ConsistObject
    {
    	public string SCAC { get; set; }
    	public string Section { get; set; }
    	public string TrainSymbol { get; set; }
    	public string TrainOriginDate { get; set; }
    	public string ReportingLocation { get; set; }
    	public string ReportingPassCount { get; set; }
    	public string ReportingSource { get; set; }
    	public string SpeedClass { get; set; }
    	public string MaxPlateSize { get; set; }
    	public string NumberLoads { get; set; }
    	public string NumberEmpties { get; set; }
    	public string TrailingTonnage { get; set; }
    	public string TrainLength { get; set; }
    	public string AxleCount { get; set; }
    	public string OperativeBrakes { get; set; }
    	public string TotalBrakingForce { get; set; }
    	public string MaxCarHeightConstraints { get; set; }
    	public string MaxCarWeightConstraints { get; set; }
    	public string MaxCarWidthConstraints { get; set; }
    	public string HazmatConstraints { get; set; }
    	public string TIHConstraints { get; set; }
    }
    
    public class NS_EngineConsistObject
    {
    	public string SCAC { get; set; }
    	public string Section { get; set; }
    	public string TrainSymbol { get; set; }
    	public string TrainOriginDate { get; set; }
    	public string EngineInitial { get; set; }
    	public string EngineNumber { get; set; }
    	public string EnginePosition { get; set; }
    	public string EngineOrientation { get; set; }
    	public string EngineLock { get; set; }
    	public string OriginPassCount { get; set; }
    	public string OriginLocation { get; set; }
    	public string DestinationPassCount { get; set; }
    	public string DestinationLocation { get; set; }
    	public string CompensatedHP { get; set; }
    	public string GroupNumber { get; set; }
    	public string Model { get; set; }
    	public string EngineWeight { get; set; }
    	public string EngineLength { get; set; }
    	public string EngineStatus { get; set; }
    	public string DPU_Status { get; set; }
    	public string PTC_Equipped { get; set; }
    	public string PTS_Equipped { get; set; }
    	public string LSL_Equipped { get; set; }
    	public string CS_Equipped { get; set; }
    	public string Notes { get; set; }
    	public string LastServiceDate { get; set; }
    	public string LastServiceLocation { get; set; }
    	public string ShuckerDevice { get; set; }
    	public string TestDueDate { get; set; }
    	public string TestDueLocation { get; set; }
    	public string LastFuelDate { get; set; }
    	public string LastFuelLocation { get; set; }
    	public string ReportingPassCount { get; set; }
    	public string ReportingLocation { get; set; }
    	public string ReportingSource { get; set; }
    	public string MessagePurpose { get; set; }
    	public string DefaultDataApplied { get; set; }
    	public string AssignedDivision { get; set; }
    	public string HelperCrewPoolId { get; set; }
    }
	

    
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_TrainID
    {
    	public static Dictionary<string, NS_TrainObject> trainObjectDictionary = new Dictionary<string, NS_TrainObject>();
    	
        [UserCodeMethod]
        public static string CreateTrainID(string trainSeed, string section = "", string scac = "NS", string originDay = "")
        {
        	NS_TrainObject TrainObject = new NS_TrainObject();
        	TrainObject.TrainSymbol = trainSeed + getMilitaryTime();
        	        	
        	TrainObject.SCAC = scac;
        	TrainObject.TrainSection = section;

			// This now sets both the TrainOriginDate and TrainOriginDayOfMonth properties for the train object.            
        	TrainObject.OffsetTrainOriginDate(originDay);
        	
        	string trainId = TrainObject.TrainSymbol + " " + TrainObject.TrainOriginDayOfMonth;
        	
        	// Add section to train ID, conditionally
        	if (string.IsNullOrEmpty(section))
        	{
        		TrainObject.TrainId = trainId;
        	} else {
        		TrainObject.TrainId = trainId + "-" + section;
        	}

			if (!TrainExists(trainSeed))
        	{
        		trainObjectDictionary.Add(trainSeed, TrainObject);
        	} else {
        		trainObjectDictionary[trainSeed] = TrainObject;
        	}
        	
        	return TrainObject.TrainSymbol;
        }

        public static void setOriginDate(string TrainSeed,string OriginDate)
        {   
        	if (TrainExists(TrainSeed))
        	{    		
        		trainObjectDictionary[TrainSeed].TrainOriginDate = OriginDate;     	
        	}
        	else
        	{
        		Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");     		
        	}    			        	
        }
        
        public static string GetTrainKey(string TrainSeed)
        {   
        	string trainKey = null;
			if (TrainExists(TrainSeed))
        	{    		
        		 trainKey = trainObjectDictionary[TrainSeed].TrainKey;
        	}
        	else
        	{
        		Ranorex.Report.Error("Train key with train seed: "+TrainSeed+" not found");
        	}
			return trainKey;    			        	
        }

        public static void SetTrainKey(string TrainSeed,string TrainKey = null)
        {   
        	if(TrainExists(TrainSeed))
        	{    		
        		trainObjectDictionary[TrainSeed].TrainKey = TrainKey;
        	}
        	else
        	{
        		Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");     		
        	}    			        	
        }
        	
        	

//        [UserCodeMethod]
//        public static void CreateCrewMemberGroup(
//        	string trainSeed, 
//        	string crewSeed, 
//        	string crewMemberRecord, 
//        	string sequenceNumber, 
//        	string crewLineSegment
//        ) {
//        	// Assumes the corresponding train already exists
//        	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
//        	NS_CrewGroupObject CrewGroupObject = new NS_CrewGroupObject();
//        	
//        	CrewGroupObject.SCAC = TrainObject.SCAC;
//        	CrewGroupObject.Section = TrainObject.TrainSection;
//        	CrewGroupObject.TrainSymbol = TrainObject.TrainSymbol;
//        	CrewGroupObject.TrainOriginDate = TrainObject.TrainOriginDate;
//        	CrewGroupObject.CrewId = crewSeed;
//        	CrewGroupObject.CrewLineSegment = crewLineSegment;
//        	CrewGroupObject.SequenceNumber = sequenceNumber;
//        	
//        	CrewGroupObject.CreateCrewMembers(trainSeed, crewMemberRecord);
//        	
//        	if (TrainObject.CrewGroupExists(crewSeed))
//        	{
//        		// Effectively replaces an existing crew object with the same key.
//        		TrainObject.SetCrewGroupObject(crewSeed, CrewGroupObject);
//        	} else {
//        		TrainObject.AddCrewGroupObject(crewSeed, CrewGroupObject);
//        	}
//        	
//        }

        
        [UserCodeMethod]
        public static void CreateConsistSummaryRecord(string trainSeed, string consistSeed, string reportingLocation, string reportingPassCount, string reportingSource, string speedClass, string maxPlateSize,
                                                      string numberLoads, string numberEmpties, string trailingTonnage, string trainLength, string axleCount, string operativeBrakes,
                                                      string totalBrakingForce, string maxCarWeightConstraints, string maxCarHeightConstraints, 
                                                      string maxCarWidthConstraints, string hazmatConstraints, string TIHConstraints)
        {
        	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
        	NS_ConsistObject ConsistObject = new NS_ConsistObject();
        	
        	ConsistObject.SCAC = TrainObject.SCAC;
        	ConsistObject.Section = TrainObject.TrainSection;
        	ConsistObject.TrainSymbol = TrainObject.TrainSymbol;
        	ConsistObject.TrainOriginDate = TrainObject.TrainOriginDate;
        	ConsistObject.ReportingLocation = reportingLocation;
        	ConsistObject.ReportingPassCount = reportingPassCount;
        	ConsistObject.ReportingSource = reportingSource;
        	ConsistObject.SpeedClass = speedClass;
        	ConsistObject.MaxPlateSize = maxPlateSize;
        	ConsistObject.NumberLoads = numberLoads;
        	ConsistObject.NumberEmpties = numberEmpties;
        	ConsistObject.TrailingTonnage = trailingTonnage;
        	ConsistObject.TrainLength = trainLength;
        	ConsistObject.AxleCount = axleCount;
        	ConsistObject.OperativeBrakes = operativeBrakes;
        	ConsistObject.TotalBrakingForce = totalBrakingForce;
        	ConsistObject.MaxCarWeightConstraints = maxCarWeightConstraints;
        	ConsistObject.MaxCarHeightConstraints = maxCarHeightConstraints;
        	ConsistObject.MaxCarWidthConstraints = maxCarWidthConstraints;
        	ConsistObject.HazmatConstraints = hazmatConstraints;
        	ConsistObject.TIHConstraints = TIHConstraints;
        	
        	
        	if (TrainObject.ConsistRecordExists(consistSeed))
        	{
        		TrainObject.SetConsistObject(consistSeed, ConsistObject);
        	} else {
        		TrainObject.AddConsistObject(consistSeed, ConsistObject);
        	}
        	
        }
        
        [UserCodeMethod]
        public static void BuildTrainHistoryMessage(string trainSeed, string engineSeed, string messageType)
        {
        	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
        	NS_TrainHistoryMessageObject historyMessageObject = new NS_TrainHistoryMessageObject();
        	
//        	if (TrainObject.HistoryRecordExists(messageType))
//        	{
//        		TrainObject.SetConsistObject(messageType, historyMessageObject);
//        	} else {
//        		TrainObject.AddConsistObject(messageType, historyMessageObject);
//        	}
        	
        }
        
        public static void ReportEngineObjectStatus (string trainSeed, string engineSeed)
        {
        	NS_EngineConsistObject obj = GetEngineObjectFromTrain(trainSeed, engineSeed);
        	string report = string.Format("Status of engine object {0} is as follows: SCAC = {1}|Section = {2}|Train Symbol = {3}|Origin Date = {4}",
        	                              engineSeed, obj.SCAC, obj.Section, obj.TrainSymbol, obj.TrainOriginDate);
        	Report.Info(report);
        	report = string.Format("Engine Initial = {0}|Engine Number = {1}|Engine Position = {2}|Engine Orientation = {3}|Engine Lock = {4}",
        	                              obj.EngineInitial, obj.EngineNumber, obj.EnginePosition, obj.EngineOrientation, obj.EngineLock);
        	Report.Info(report);
        	report = string.Format("Origin Passcount = {0}|Origin Location = {1}|Destination Passcount = {2}|Destination Location = {3}|Compensated HP = {4}",
        	                              obj.OriginPassCount, obj.OriginLocation, obj.DestinationPassCount, obj.DestinationLocation, obj.CompensatedHP);
        	Report.Info(report);
        	report = string.Format("Group Number = {0}|Model = {1}|Engine Status = {2}|DPU Status = {3}|PTC Equipped = {4}",
        	                              obj.GroupNumber, obj.Model, obj.EngineStatus, obj.DPU_Status, obj.PTC_Equipped);
        	Report.Info(report);
        	report = string.Format("PTC_Equipped = {0}|LSL Equipped = {1}|CS Equipped = {2}|Notes = {3}|Last Service Date = {4}",
        	                              obj.PTC_Equipped, obj.LSL_Equipped, obj.CS_Equipped, obj.Notes, obj.LastServiceDate);
        	Report.Info(report);
        	report = string.Format("Last Service Location = {0}|Shucker Device = {1}|Test Due Date = {2}|Test Due Location = {3}|Last Fuel Date = {4}",
        	                              obj.LastServiceLocation, obj.ShuckerDevice, obj.TestDueDate, obj.TestDueLocation, obj.LastFuelDate);
        	Report.Info(report);
        	report = string.Format("Reporting Pass Count = {0}|Reporting Location = {1}|Reporting Source = {2}|Message Purpose = {3}|Default Data Applied = {4}",
        	                              obj.ReportingPassCount, obj.ReportingLocation, obj.ReportingSource, obj.MessagePurpose, obj.DefaultDataApplied);
	    	
        	Report.Info(report);
        	report = string.Format("Group Number = {0}|Model = {1}", obj.AssignedDivision, obj.HelperCrewPoolId);
        }
        [UserCodeMethod]
        public static NS_EngineConsistObject CreateEngineConsistRecord(string trainSeed, string engineSeed, string engineConsistRecord, string assignedDivision, string helperCrewPoolId, string defaultDataApplied,
                                                     string reportingPassCount, string reportingLocation, string reportingSource, string messagePurpose)
        {
        	NS_TrainObject TrainObject = NS_TrainID.getTrainObject(trainSeed);
        	NS_EngineConsistObject EngineObject = new NS_EngineConsistObject();
        	
        	string[] engineRecord = engineConsistRecord.Split('|');
        	
        	if (engineRecord.Length != 26)
        	{
        		Ranorex.Report.Failure("Invalid engine record length of "+engineRecord.Length.ToString()+".");
        		return null;
        	}
        	
        	System.DateTime trainOriginDateTime = NS_TrainID.GetTrainOriginDateTime(trainSeed);
        	System.DateTime lastServiceTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(engineRecord[19]));
        	System.DateTime testDueTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(engineRecord[22]));
        	System.DateTime lastFuelTime = trainOriginDateTime.AddMinutes(Convert.ToDouble(engineRecord[24]));
        	
        	EngineObject.AssignedDivision = assignedDivision;
        	EngineObject.HelperCrewPoolId = helperCrewPoolId;
        	EngineObject.DefaultDataApplied = defaultDataApplied;
        	EngineObject.ReportingPassCount = reportingPassCount;
        	EngineObject.ReportingLocation = reportingLocation;
        	EngineObject.ReportingSource = reportingSource;
        	EngineObject.MessagePurpose = messagePurpose;
        	EngineObject.SCAC = TrainObject.SCAC;
        	EngineObject.Section = TrainObject.TrainSection;
        	EngineObject.TrainSymbol = TrainObject.TrainSymbol;
        	EngineObject.TrainOriginDate = TrainObject.TrainOriginDate;
        	
        	EngineObject.EngineInitial = engineRecord[0];
        	EngineObject.EngineNumber = engineRecord[1];
        	EngineObject.EnginePosition = engineRecord[2];
        	EngineObject.EngineOrientation = engineRecord[3];
        	EngineObject.EngineLock = engineRecord[4];
        	EngineObject.OriginPassCount = engineRecord[5];
        	EngineObject.OriginLocation = engineRecord[6];
        	EngineObject.DestinationPassCount = engineRecord[7];
        	EngineObject.DestinationLocation = engineRecord[8];
        	EngineObject.CompensatedHP = engineRecord[9];
        	EngineObject.GroupNumber = engineRecord[10];
        	EngineObject.Model = engineRecord[11];
        	if (engineRecord[12].Equals(""))
        	{
        		EngineObject.EngineStatus = "D";
        	}
        	else
        	{
        		EngineObject.EngineStatus = engineRecord[12];
        	}
        	EngineObject.DPU_Status = engineRecord[13];
        	EngineObject.PTS_Equipped = engineRecord[14];
        	EngineObject.PTC_Equipped = engineRecord[15];
        	EngineObject.LSL_Equipped = engineRecord[16];
        	EngineObject.CS_Equipped = engineRecord[17];
        	EngineObject.Notes = engineRecord[18];
        	EngineObject.LastServiceDate = lastServiceTime.ToString("MMddyyyy");
        	EngineObject.LastServiceLocation = engineRecord[20];
        	EngineObject.ShuckerDevice = engineRecord[21];
        	EngineObject.TestDueDate = testDueTime.ToString("MMddyyyy");
        	EngineObject.TestDueLocation = engineRecord[23];
        	EngineObject.LastFuelDate = lastFuelTime.ToString("MMddyyyy");
        	EngineObject.LastFuelLocation = engineRecord[25];
        	
        	if (TrainObject.EngineRecordExists(engineSeed))
        	{
        		TrainObject.SetEngineObject(engineSeed, EngineObject);
        	} else {
        		TrainObject.AddEngineObject(engineSeed, EngineObject);
        	}
        	
        	 return EngineObject;
        }
        
        private static List<string> getTrainSeeds()
    	{
    		List<string> keyList = new List<string>(trainObjectDictionary.Keys);
    		return keyList;
    	}

		public static string GetTrainSeedFromTrainId(string trainId)
		{
			List<string> trainSeeds = getTrainSeeds();
			string aTrainId = "";
			foreach (string seed in trainSeeds)
			{
				aTrainId = GetTrainSymbol(seed);
				if (trainId == aTrainId)
				{
					return seed;
				}
			}
			Ranorex.Report.Failure("Seed not found for train ID: " + trainId + ".");
			return null; //debugging purposes
		}
		
        public static NS_TrainObject getTrainObject(string trainSeed)
        {
        	NS_TrainObject trainObject = null;
        	if (TrainExists(trainSeed))
        	{
        		trainObject = trainObjectDictionary[trainSeed];
        	}
        	return trainObject;
        }
        
        private static void setTrainObject(string trainSeed, NS_TrainObject trainObject)
		{
        	trainObjectDictionary[trainSeed] = trainObject;
		}

//		private static void removeCrewMemberOnTrain_LastName(string trainSeed, string crewSeed, string lastName)
//		{
//			if (CrewMemberExists_LastName(trainSeed, crewSeed, lastName))
//			{
//				// If crew member exists, then so does crew group as well as train object
//				NS_CrewGroupObject CrewGroup = GetCrewGroupObjectFromTrain(trainSeed, crewSeed);
//				CrewGroup.RemoveCrewMember_ByLastName(lastName);
//
//				NS_TrainObject TrainObject = getTrainObject(trainSeed); // get train object from dictionary
//				TrainObject.SetCrewGroupObject(crewSeed, CrewGroup); // update crew group in dictionary to reflect absent member
//				setTrainObject(trainSeed, TrainObject); // set train object, which no longer has member in group
//			}
//		}
        
        private static void addTrainObject(string trainSeed, NS_TrainObject trainObject)
		{
			if (!trainObjectDictionary.ContainsKey(trainSeed))
			{
				trainObjectDictionary.Add(trainSeed, trainObject);
			}
		}
        
//        public static bool CrewGroupExists(string trainSeed, string crewSeed)
//        {
//        	bool crewExists = false;
//        	NS_TrainObject trainObject = getTrainObject(trainSeed);
//        	if (trainObject != null)
//        	{
//        		crewExists = trainObject.CrewGroupExists(crewSeed);
//        	}
//        	return crewExists;
//        }

//		public static bool CrewMemberExists_LastName(string trainSeed, string crewSeed, string lastName)
//		{
//			bool memberExists = false;
//			NS_CrewGroupObject CrewGroup = GetCrewGroupObjectFromTrain(trainSeed, crewSeed);
//			if (CrewGroup != null)
//			{
//				memberExists = CrewGroup.CrewMemberExists_LastName(lastName);
//			}
//			return memberExists;
//		}
        
        public static bool EngineRecordExists(string trainSeed, string engineSeed)
        {
        	bool engineExists = false;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		engineExists = trainObject.EngineRecordExists(engineSeed);
        	}
        	return engineExists;
        }
        public static bool ConsistRecordExists(string trainSeed, string consistSeed)
        {
        	bool consistExists = false;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		consistExists = trainObject.ConsistRecordExists(consistSeed);
        	}
        	return consistExists;
        }
        
        public static bool TrainHistoryExists(string trainSeed, string messageType)
        {
        	bool historyExists = false;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		historyExists = trainObject.HistoryRecordExists(messageType);
        	}
        	return historyExists;
        }
        
//        public static NS_CrewGroupObject GetCrewGroupObjectFromTrain(string trainSeed, string crewSeed)
//        {
//        	NS_CrewGroupObject crewMember = null;
//        	NS_TrainObject trainObject = getTrainObject(trainSeed);
//        	if (trainObject != null)
//        	{
//        		crewMember = trainObject.GetCrewGroupObject(crewSeed);
//        	}
//        	return crewMember; 
//        }
        
//        public static NS_CrewMemberObject GetCrewMemberFromTrain_CrewNumber(string trainSeed, string crewSeed, int crewMemberNumber = 1)
//        {
//        	NS_CrewMemberObject CrewMember = null;
//        	NS_CrewGroupObject CrewGroup = GetCrewGroupObjectFromTrain(trainSeed, crewSeed);
//        	if (CrewGroup != null)
//        	{
//        		CrewMember = CrewGroup.GetCrewMemberObject_CrewNumber(crewMemberNumber);
//        	}
//        	return CrewMember;
//        }
//
//		public static NS_CrewMemberObject GetCrewMemberFromTrain_LastName(string trainSeed, string crewSeed, string lastName)
//        {
//        	NS_CrewMemberObject CrewMember = null;
//        	NS_CrewGroupObject CrewGroup = GetCrewGroupObjectFromTrain(trainSeed, crewSeed);
//        	if (CrewGroup != null)
//        	{
//        		CrewMember = CrewGroup.GetCrewMemberObject_LastName(lastName);
//        	}
//        	return CrewMember;
//        }
        
        public static NS_EngineConsistObject GetEngineObjectFromTrain(string trainSeed, string engineSeed)
        {
        	NS_EngineConsistObject engine = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		engine = trainObject.GetEngineObject(engineSeed);
        	}
        	return engine;
        }
        
        public static NS_ConsistObject GetConsistObjectFromTrain(string trainSeed, string consistSeed)
        {
        	NS_ConsistObject consist = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		consist = trainObject.GetConsistObject(consistSeed);
        	}
        	return consist;
        }
        
        [UserCodeMethod]
        public static string GetTrainSymbol(string trainSeed)
        {
        	string trainSymbol = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainSymbol = trainObject.TrainSymbol;
        	}
        	return trainSymbol;
        }
        
        [UserCodeMethod]
        public static string GetTrainId(string trainSeed)
        {
        	string trainId = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainId = trainObject.TrainId;
        	}
        	return trainId;
        }
        
        [UserCodeMethod]
        public static string getOriginDate(string trainSeed)
        {   string originDate = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		originDate = trainObject.TrainOriginDate;
        	}
        	return originDate; 			        	
        }
        
        [UserCodeMethod]
        public static string GetTrainSection(string trainSeed)
        {
        	string trainSection = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainSection = trainObject.TrainSection;
        	}
        	return trainSection;
        }
        
        [UserCodeMethod]
        public static string GetTrainSCAC(string trainSeed)
        {
        	string trainSCAC = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainSCAC = trainObject.SCAC;
        	}
        	return trainSCAC;
        }
        	
        
        [UserCodeMethod]
        public static string GetConsistNumberOfLoads(string trainSeed, string consistSeed)
        {
        	string field = null;
        	NS_ConsistObject consistRecord = GetConsistObjectFromTrain(trainSeed, consistSeed);
        	if (consistRecord != null)
        	{
        		field = consistRecord.NumberLoads;
        	}
        	return field;
        }

		/// <summary>
		/// Returns the train length from an NS_ConsistObject, if there is a valid object provided by the train seed and consist seed. 
		/// If no object exists, this method will return null, by design.
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed</param>
		/// <param name="consistSeed">Input: consistSeed</param>
		/// <returns></returns>
		public static string GetConsistTrainLength(string trainSeed, string consistSeed)
		{
			string length = null;
			NS_ConsistObject trainConsist = GetConsistObjectFromTrain(trainSeed, consistSeed);
			if (trainConsist != null)
			{
				length = trainConsist.TrainLength;
			}
			return length;
		}
		
		/// <summary>
		/// Updates consist objects reporting location
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed</param>
		/// <param name="consistSeed">Input: consistSeed</param>
		/// <param name="reportingLocation">Input: Integer for length increase. This will increase the train length by the provided input.</param>
		[UserCodeMethod]
		public static void UpdateConsistReportingLocation(string trainSeed, string consistSeed, string reportingLocation)
		{
			NS_TrainObject trainObject = getTrainObject(trainSeed);
			if (trainObject != null)
			{
				NS_ConsistObject consistObject = trainObject.GetConsistObject(consistSeed);
				if (consistObject != null)
				{
					consistObject.ReportingLocation = reportingLocation;
				} else {
					Report.Info(string.Format("No consist object exists for the corresponding train seed '{0}' and engine seed '{1}'.", trainSeed, consistSeed));
				}
			} else {
				Report.Info(string.Format("No train object exists for the corresponding train seed '{0}'.", trainSeed));
			}
		}

		/// <summary>
		/// Given a consist object as well as an integer of a length increase, this method will increase the train consist object's train length property.
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed</param>
		/// <param name="consistSeed">Input: consistSeed</param>
		/// <param name="lengthIncrease">Input: Integer for length increase. This will increase the train length by the provided input.</param>
		[UserCodeMethod]
		public static void UpdateConsistTrainLength(string trainSeed, string consistSeed, int lengthIncrease)
		{
			NS_TrainObject trainObject = getTrainObject(trainSeed);
			if (trainObject != null)
			{
				NS_ConsistObject consistObject = trainObject.GetConsistObject(consistSeed);
				if (consistObject != null)
				{
					int initialLength;
					int finalLength = lengthIncrease;
					// Property could be uninitialized, and therefore not a number
					if (Int32.TryParse(consistObject.TrainLength, out initialLength))
					{
						finalLength = initialLength + lengthIncrease;
						Report.Info(string.Format("The length of train with train seed '{0}' and consist seed '{1}' is given as '{2}'", trainSeed, consistSeed, finalLength.ToString()));
					}
					consistObject.TrainLength = finalLength.ToString();
					trainObject.SetConsistObject(consistSeed, consistObject);
					setTrainObject(trainSeed, trainObject);
				} else {
					Report.Info(string.Format("No consist object exists for the corresponding train seed '{0}' and engine seed '{1}'.", trainSeed, consistSeed));
				}
			} else {
				Report.Info(string.Format("No train object exists for the corresponding train seed '{0}'.", trainSeed));
			}
		}
        
		
		[UserCodeMethod]
		public static void UpdateEngineStatus(string trainSeed, string engineSeed, string status)
		{
			NS_TrainObject trainObject = getTrainObject(trainSeed);
			if (trainObject != null)
			{
				NS_EngineConsistObject engineObject = trainObject.GetEngineObject(engineSeed);
				if (engineObject != null)
				{
					engineObject.EngineStatus = status;
					trainObject.SetEngineObject(engineSeed, engineObject);
					setTrainObject(trainSeed, trainObject);
				} else {
					Report.Info(string.Format("No engine consist object exists for the corresponding train seed '{0}' and engine seed '{1}'.", trainSeed, engineSeed));
				}
			} else {
				Report.Info(string.Format("No train object exists for the corresponding train seed '{0}'.", trainSeed));
			}
		}
		
        [UserCodeMethod]
        public static void SetTrainClearanceNumber(string trainSeed, string trainClearanceNumber)
        {
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainObject.TrainClearance = trainClearanceNumber;
        		setTrainObject(trainSeed, trainObject);
        	}
        }
        
        [UserCodeMethod]
        public static string GetTrainClearanceNumber(string trainSeed)
        {
        	string trainClearanceNumber = null;
        	NS_TrainObject trainObject = getTrainObject(trainSeed);
        	if (trainObject != null)
        	{
        		trainClearanceNumber = trainObject.TrainClearance;
        		if (string.IsNullOrEmpty(trainClearanceNumber))
	        	{
        			trainClearanceNumber = Oracle.Code_Utils.ADMSEnvironment.GetTrainClearanceNumber(trainObject.TrainId);
        			int trainClearanceint;
        			if (int.TryParse(trainClearanceNumber, out trainClearanceint))
        			{
        			    SetTrainClearanceNumber(trainSeed, trainClearanceNumber);
        			}
	        	}
        	}
        	
        	return trainClearanceNumber;
        }

		public static System.DateTime GetTrainOriginDateTime(string trainSeed)
		{
			System.DateTime trainOriginDateTime = System.DateTime.Now;
			NS_TrainObject trainObject = getTrainObject(trainSeed);
			if (trainObject != null)
			{
				trainOriginDateTime = trainObject.TrainOriginDateTime;
			} else {
				Report.Error(string.Format("No train object exists for train seed '{0}'."));
			}
			return trainOriginDateTime;
		}
        
        [UserCodeMethod]
        public static string GetEngineNumber(string trainSeed, string engineSeed)
        {
        	string engineNumber = null;
        	NS_EngineConsistObject engine = GetEngineObjectFromTrain(trainSeed, engineSeed);
        	if (engine != null)
        	{
        		engineNumber = engine.EngineNumber;
        	}
        	return engineNumber;
        }
        
//        
//
//		public static string GetCrewMemberEmployeeId(string trainSeed, string crewSeed, string lastName)
//		{
//			string employeeId = null;
//			NS_CrewMemberObject crewMember = GetCrewMemberFromTrain_LastName(trainSeed, crewSeed, lastName);
//			if (crewMember != null)
//			{
//				employeeId = crewMember.EmployeeId;
//			}
//			return employeeId;
//		}
        
        public static string GetEngineInitial(string trainSeed, string engineSeed)
        {
        	string engineInitial = null;
        	NS_EngineConsistObject engine = GetEngineObjectFromTrain(trainSeed, engineSeed);
        	if (engine != null)
        	{
        		engineInitial = engine.EngineInitial;
        	}
        	return engineInitial;
        }
        
        private static string getMilitaryTime()
        {               	
        	return System.DateTime.Now.ToString("HHmm");
        }
		
		public static bool TrainExists(string trainSeed)
		{
			return trainObjectDictionary.ContainsKey(trainSeed);
		}
		
		private void clearTrainObjectDictionary()
		{
			trainObjectDictionary.Clear();
		}
		
		public static string FindEngineSeedFromEngineId (string engineId)
		{
			string foundEngineSeed = null;
			List<string> listOfTrainSeeds = getTrainSeeds();
			foreach (string seed in listOfTrainSeeds)
			{
				foundEngineSeed = getTrainObject(seed).GetEngineSeedfromEngineId(engineId); //returns null if not found
				if (!foundEngineSeed.Equals(""))
				{
					//match found, break'em
					break;
				}
			}
			
			if (foundEngineSeed.Equals(""))
			{
				Ranorex.Report.Info("Could not find engineSeed for {"+engineId+"}.");
			}
			else
			{
				Ranorex.Report.Info("engineSeed {"+foundEngineSeed+"} found for engine {"+engineId+"}.");
			}
			
			return foundEngineSeed;
		}
		
		public static string FindEngineIdFromEngineSeed(string engineSeed)
		{
			string foundEngineId = null;
			List<string> listOfTrainSeeds = getTrainSeeds();
			NS_EngineConsistObject currentEngine = null;
			foreach (string seed in listOfTrainSeeds)
			{
				Ranorex.Report.Info("TrainSeed:"+seed);
				 //returns null if not found
				if (getTrainObject(seed).EngineRecordExists(engineSeed))
				{
					currentEngine = getTrainObject(seed).GetEngineObject(engineSeed);
					break;
				}
			}
			
			if (currentEngine == null)
			{
				Ranorex.Report.Info("Could not find engineId for {"+engineSeed+"}.");
			}
			else
			{
				foundEngineId = currentEngine.EngineInitial + " " + currentEngine.EngineNumber;
				Ranorex.Report.Info("engineId {"+foundEngineId+"} found for engineSeed {"+engineSeed+"}.");
			}
			
			return foundEngineId;
		}
    }
}