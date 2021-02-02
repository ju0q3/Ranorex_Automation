/*
 * Created by Ranorex
 * User: 210057585
 * Date: 11/28/2017
 * Time: 7:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.Globalization;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Env.Code_Utils;

namespace PDS_CORE.Code_Utils
{
	
	public class TrainObject
	{
		public string TrainId { get; set; }
		public string TrainIdNoDate { get; set; }
		public string TrainIdNoDateNoSection { get; set; }
		public string section { get; set; }
		public string PTCEngineId { get; set; }
		public string PTCCrewMember { get; set; }
		public string TrainClearance { get; set; }
		public string TriggerType { get; set; }
		public string LocoState { get; set; }
		public string OriginDate {get ; set;}
		public string StatusCode { get; set; }
		public string EnginesString { get; set; } // pipe delimited list of engines
		public string originOpsta { get; set; }
		public string destOpsta { get; set; }
		public string ResponseCode { get; set; }
		public Dictionary<string, string> CrewIds = new Dictionary<string, string>();
		public TrainEMTObject EMTObject = new TrainEMTObject();
	}
	
	public class TrainEMTObject
	{
		public string engineId { get; set; }
		public string milePost { get; set; }
		public string track { get; set; }
		public string direction { get; set; }
	}
	
	[UserCodeCollection]
	public class CN_TrainID
	{
		public static Dictionary<string, TrainObject> TrainObjectDictionary = new Dictionary<string, TrainObject>();
		
		/// <summary>
		/// createTrainID will recieve a trainID "seed" from a .csv file and
		/// modify it to make it unique, giving it a SCAC and date
		/// </summary>
		/// <param name="trainSeed"> Must follow the format "(1 A-Z char)(1 0-9 digit)", Ex. N1, A5, T8
		/// </param>
		[UserCodeMethod]
		public static string createTrainID(string trainSeed, string originOpsta, string destOpsta, string sectionID = "1", bool datePartAdded = false)
		{
			TrainObject TrainObj = new TrainObject();
			if (trainSeed.Length != 2 && trainSeed.Length != 5) {
				Report.Error("Error", "Improper train seed. Train Seed must either be 2 characters (Ex. 'A1') or a full trainID (Ex. 'A1234').");
				return "Error";
			}
			string uniqueString = "";
			if (trainSeed.Length == 2) {
				uniqueString = getMilitaryTime();
				uniqueString = uniqueString.Substring(1); //Clip first digit to ensure most possible permutations using military time
			}
			
			string dayOfMonth = getDayOfMonth();
			TrainObj.TrainIdNoDateNoSection = trainSeed + uniqueString;
			TrainObj.TrainIdNoDate = TrainObj.TrainIdNoDateNoSection + sectionID;
			TrainObj.TrainId = TrainObj.TrainIdNoDate + " " + dayOfMonth;
			
			if (!TrainObjectDictionary.ContainsKey(trainSeed)){
				TrainObjectDictionary.Add(trainSeed, TrainObj);
			} else {
				TrainObjectDictionary[trainSeed] = TrainObj;
			}
			//string trainSeedNoDate = trainSeed + "ND";
			//TestSuite.Current.Parameters.Add(trainSeedNoDate, trainNoDate);
			
			Ranorex.Report.Info("Train id: "+TrainObj.TrainId.ToString());
			SetTrainSection(trainSeed, sectionID);
			setOriginOpsta(trainSeed, originOpsta);
			setDestinationOpsta(trainSeed, destOpsta);
			
			if (datePartAdded)
			{
				return TrainObj.TrainId;
			}
			else
			{
				//We return the train with no date for being used in an MIS message
				return TrainObj.TrainIdNoDate;
			}
			
		}
		
		[UserCodeMethod]
		public static string createTrainIDWithFutureDate(string trainSeed, string offsetWithDays)
		{
		    if(trainSeed.Length != 2 && trainSeed.Length != 6)
		    {
		        Report.Error("Improper train Seed, train seed must be 2 characters (Ex. 'A1') or a full train symbol (Ex. 'A12345')");
		        return "Error";
		    }
		    
		    int dayOfMonth = System.DateTime.Now.AddDays(Convert.ToInt32(offsetWithDays)).Day;
		    string dayOfMonthStr = null;
		    dayOfMonthStr = dayOfMonth.ToString("D2");
		    string trainID = null;
		    
		    if(trainSeed.Length == 2)
		    {
		        trainID = createTrainID(trainSeed, "", "" ,"1");
		        trainID =  trainID + " " + dayOfMonthStr;
		        return trainID;
		    }
		    else
		    {
		        trainID =  trainSeed + " " + dayOfMonthStr;
		        return trainID;
		    }
		}
		
		//public static void SetPTCEngineId(string trainSeed
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the full trainID in the current testing context.
		/// </summary>
		[UserCodeMethod]
		public static string getTrainID(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].TrainId;
			}
			else
			{
				Ranorex.Report.Info("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="TrainSeed"></param>
		/// <returns></returns>
		[UserCodeMethod]
		public static string getTrainIDNoDate(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].TrainIdNoDate;
			}
			else
			{
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the full originDate in the current testing context.
		/// added by load / performance team.
		/// </summary>
		[UserCodeMethod]
		public static string getOriginDate(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].OriginDate;
			}
			else
			{
				//Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the full originDate in the current testing context.
		/// added by load / performance team.
		/// </summary>
		[UserCodeMethod]
		public static void setOriginDate(string TrainSeed,string OriginDate)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				TrainObjectDictionary[TrainSeed].OriginDate = OriginDate;
			}
			else
			{
				Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to set
		/// origin opsta in the current testing context.
		/// </summary>
		[UserCodeMethod]
		public static void setOriginOpsta(string TrainSeed,string originOpsta)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				TrainObjectDictionary[TrainSeed].originOpsta = originOpsta;
			}
			else
			{
				Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the origin opsta in the current testing context
		/// </summary>
		[UserCodeMethod]
		public static string getOriginOpsta(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].originOpsta;
			} else {
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to set
		/// the destination opsta in the current testing context.
		/// </summary>
		[UserCodeMethod]
		public static void setDestinationOpsta(string TrainSeed,string destOpsta)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				TrainObjectDictionary[TrainSeed].destOpsta = destOpsta;
			}
			else
			{
				Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the destination opsta in the current testing context
		/// </summary>
		[UserCodeMethod]
		public static string getDestinationOpsta(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].destOpsta;
			} else {
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the full train section in the current testing context.
		/// added by CN Whiz team.
		/// </summary>
		[UserCodeMethod]
		public static void SetTrainSection(string TrainSeed,string sectionId)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				TrainObjectDictionary[TrainSeed].section = sectionId;
			}
			else
			{
				Ranorex.Report.Error("Train with train seed of "+TrainSeed+" Not Found");
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and looks to find
		/// the section in the current testing context
		/// </summary>
		[UserCodeMethod]
		public static string GetTrainSection(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].section;
			} else {
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and section from a CSV file and looks to find
		/// the trainID in the current testing context, then trims off the value of the section.
		/// </summary>
		[UserCodeMethod]
		public static string getTrainIDNoDateNoSection(string TrainSeed, string section)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].TrainIdNoDateNoSection;
			} else {
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and section from a CSV file and looks to find
		/// the trainID in the current testing context, then trims off the value of the section.
		/// </summary>
		[UserCodeMethod]
		public static string getTrainIDNoDateNoSection(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if(wasTrainFound)
			{
				return TrainObjectDictionary[TrainSeed].TrainIdNoDateNoSection;
			} else {
				//Ranorex.Report.Failure("Train with train seed of "+TrainSeed+" Not Found");
				return "";
			}
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and an engineId and stored it in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetPTCEngineId(string TrainSeed, string engineId)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].PTCEngineId = engineId;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns an engineId stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetPTCEngineId(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].PTCEngineId;
			
		}
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and an locoState and stored it in the Train Object
		/// </summary>
		
		public static void SetLocoState(string TrainSeed, string locoState)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].LocoState = locoState;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns an locoState stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetLocoState(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].LocoState;
			
		}
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and the crewName and stored it in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetPTCCrewName(string TrainSeed, string crewMember)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].PTCCrewMember = crewMember;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a crewName stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetPTCCrewName(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].PTCCrewMember;
			
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and stores a train clearance in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetTrainClearance(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].TrainClearance = Oracle.Code_Utils.ADMSEnvironment.GetTrainClearanceNumber(TrainObjectDictionary[TrainSeed].TrainId);
			return;
		}
		
		/// <summary>
		/// This method add TrainClearance id into TrainObject :  This overload method written by Perf team to set and get between recordings.
		/// Ideally this method will be used after TrainClearance SMI Call to store for future use.
		/// </summary>
		[UserCodeMethod]
		public static void SetTrainClearance(string TrainSeed,string TrainClearance)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].TrainClearance = TrainClearance;		
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetTrainClearance(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			if (TrainObjectDictionary[TrainSeed].TrainClearance == null) {
				TrainObjectDictionary[TrainSeed].TrainClearance = Oracle.Code_Utils.ADMSEnvironment.GetTrainClearanceNumber(TrainObjectDictionary[TrainSeed].TrainId);
			}
			return TrainObjectDictionary[TrainSeed].TrainClearance;	
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and an engineId and stored it in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetTriggerType(string TrainSeed, string triggerType)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].TriggerType = triggerType;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns an engineId stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetTriggerType(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].TriggerType;
			
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetCrewMemberId(string TrainSeed, string CrewMemberName)
		{
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			bool wasCrewIdFound = TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"CREWID");
			if (!wasCrewIdFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"CREWID"];
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetCrewMemberId(string TrainSeed, string CrewMemberName, string CrewId)
		{
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			if (TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"CREWID")) {
				TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"CREWID"] = CrewId;
			} else {
				TrainObjectDictionary[TrainSeed].CrewIds.Add(CrewMemberName+"CREWID", CrewId);
			}
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetCrewOnTrainTime(string TrainSeed, string CrewMemberName)
		{
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			bool wasOnTrainTimeFound = TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"ONTRAINTIME");
			if (!wasOnTrainTimeFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"ONTRAINTIME"];
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetCrewOnTrainTime(string TrainSeed, string CrewMemberName, string OnTrainTime) {
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			if (TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"ONTRAINTIME")) {
				TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"ONTRAINTIME"] = OnTrainTime;
			} else {
				TrainObjectDictionary[TrainSeed].CrewIds.Add(CrewMemberName+"ONTRAINTIME", OnTrainTime);
			}
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetCrewOffTrainTime(string TrainSeed, string CrewMemberName)
		{
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			bool wasOnTrainTimeFound = TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"OFFTRAINTIME");
			if (!wasOnTrainTimeFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"OFFTRAINTIME"];
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns a train clearance stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static void SetCrewOffTrainTime(string TrainSeed, string CrewMemberName, string OffTrainTime) {
			CrewMemberName = CrewMemberName.ToUpper();
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			if (TrainObjectDictionary[TrainSeed].CrewIds.ContainsKey(CrewMemberName+"OFFTRAINTIME")) {
				TrainObjectDictionary[TrainSeed].CrewIds[CrewMemberName+"OFFTRAINTIME"] = OffTrainTime;
			} else {
				TrainObjectDictionary[TrainSeed].CrewIds.Add(CrewMemberName+"OFFTRAINTIME", OffTrainTime);
			}
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns the pipe delimited engiens string
		/// </summary>
		[UserCodeMethod]
		public static string GetEnginesStringByTrainseed(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].EnginesString;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and sets the pipe delimited engines string
		/// </summary>
		[UserCodeMethod]
		public static void SetEnginesStringByTrainseed(string TrainSeed, string enginesString) 
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) 
			{
			    Report.Failure("No Train exists for train seed " + TrainSeed);
			    return;
			}
			TrainObjectDictionary[TrainSeed].EnginesString = enginesString;
		}		
		
		/// <summary>
		/// Returns the Train Object
		/// </summary>
		[UserCodeMethod]
		public static TrainObject getTrainObject(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			return TrainObjectDictionary[TrainSeed];
		}
		
		
		
		// Returns the day of the month
		// November 28, 2017 would return 28
		public static string getDayOfMonth()
		{
			int dayOfMonth = System.DateTime.Now.Day;
			string dayOfMonthStr = null;
			dayOfMonthStr = dayOfMonth.ToString("D2");
			
			return dayOfMonthStr;
		}
		
		//Returns current military time to add onto the seed
		//so we can have a unique trainid
		public static string getMilitaryTime()
		{
			string militaryTime = System.DateTime.Now.ToString("HHmm");
			return militaryTime;
		}

		
		/// <summary>
		/// This is a placeholder text. Please describe the purpose of the
		/// user code method here. The method is published to the user code library
		/// within a user code collection.
		/// </summary>
		[UserCodeMethod]
		public static void clearTrainDictionary()
		{
			TrainObjectDictionary.Clear();
		}
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and an StatusCode and stored it in the Train Object
		/// </summary>
		
		public static void SetStatusCode(string TrainSeed, string StatusCode)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].StatusCode = StatusCode;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns an StatusCode stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetStatusCode(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].StatusCode;
			
		}
		/// <summary>
		/// This method recieves a trainID "Seed" from a CSV file and an ResponseCode and stored it in the Train Object
		/// </summary>		
		public static void SetResponseCode(string TrainSeed, string ResponseCode)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				TrainObjectDictionary.Add(TrainSeed, new TrainObject());
			}
			TrainObjectDictionary[TrainSeed].ResponseCode = ResponseCode;
			return;
		}
		
		/// <summary>
		/// This method recieves a trainID "Seed" and returns an ResponseCode stored in the Train Object
		/// </summary>
		[UserCodeMethod]
		public static string GetResponseCode(string TrainSeed)
		{
			bool wasTrainFound = TrainObjectDictionary.ContainsKey(TrainSeed);
			if (!wasTrainFound) {
				return "";
			}
			return TrainObjectDictionary[TrainSeed].ResponseCode;
			
		}
		
		public static string GetTrainSeedFromTrainId(string trainId)
		{
			List<string> trainSeeds = getTrainSeeds();
			string aTrainId = "";
			foreach (string seed in trainSeeds)
			{
				aTrainId = getTrainIDNoDate(seed);
				if (trainId.Trim() == aTrainId)
				{
					return seed;
				}
			}
			Ranorex.Report.Failure("Seed not found for train ID: " + trainId + ".");
			return null; //debugging purposes
		}
		
		private static List<string> getTrainSeeds()
    	{
    		List<string> keyList = new List<string>(TrainObjectDictionary.Keys);
    		return keyList;
    	}
		
	}
}
