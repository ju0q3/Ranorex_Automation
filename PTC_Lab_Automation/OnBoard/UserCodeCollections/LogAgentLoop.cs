/*
 * Created by Wabtec
 * User: Roger Olson
 * Date: 1/14/2020
 * Time: 9:40 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace OnBoard.UserCodeCollections
{
	
	public static class StreamReaderExtensions
	{
		public static StringBuilder ReadLineWithNewLine(this StreamReader reader)
        {
			var builder = new StringBuilder();
			try
			{
				while (!reader.EndOfStream)
				{
					int c = reader.Read();
					
					builder.Append((char) c);
					if (c == 10)
					{
						break;
					}
				}
				return builder;
			}
			catch(Exception ex)
			{
				Report.Info("Builder String: "+builder.ToString());
				Report.Info("Capacity: "+builder.Capacity.ToString());
				Report.Info("Max Capacity: "+builder.MaxCapacity.ToString());
				Report.Info("Length: "+builder.Length.ToString());
				Ranorex.Report.Failure("Exception in String builder: "+ex.StackTrace.ToString());
				return null;
			}
        }
	}
	
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class LogAgentLoop
    {
        //Class variable to check when the log manager is ready for other things to run
        public static bool logAgentReady = false;
        public static bool readLog = true;
        public static bool skipLog = false;
        public static bool hornValidate = false;
        public static string onBoardLogFilePath;
        public static Thread logAgentTask;
        
        public static string[] buttons = new string[]{"","","","","","","",""};
        public static string lastButton = "";
        public static string locationInfo = "";
        public static string banner = "";
        public static string lastBanner = "";
        public static string topBanner = "";
        public static string lastTopBanner = "";
        public static string trainInfo = "";
        public static string controlInfo = "";
        public static string bhInfo = "";
        public static string hornPattern = "";
        public static string hornState = "OFF";
        public static string currentHornDOT = "";
        public static int lastHornDuration = 0;
        public static string gpsInfo = "";
        public static System.DateTime hornStartTime = System.DateTime.Now;
        public static System.DateTime hornEndTime = System.DateTime.Now;
        public static Dictionary<string, LinkedList<System.DateTime>> messageTimeStamps = new Dictionary<string, LinkedList<System.DateTime>>();
        public static Dictionary<string, LinkedList<System.DateTime>> topBannerTimeStamps = new Dictionary<string, LinkedList<System.DateTime>>();
        public static Dictionary<string, LinkedList<System.DateTime>> bannerTimeStamps = new Dictionary<string, LinkedList<System.DateTime>>();
        public static Dictionary<System.DateTime, int> HornTimeStamps = new Dictionary<System.DateTime, int>();
        
        public static OnBoard.OnBoardRepository OnBoardRepo = OnBoard.OnBoardRepository.Instance;
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static void InitializeLogAgentFunction(string logFilePath)
        {
        	onBoardLogFilePath = logFilePath;
        	//Check if the Log Manager is currently recording, and if so, read the file
        	try
        	{
        		if (LogFunctions.CheckOnboardLoggingOn_LogManager())
        		{
        			//StartLogAgent();
        			using (var fs = new FileStream(onBoardLogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        			{
        				using (var sr = new StreamReader(fs, Encoding.Default))
        				{
        					while (true)
        					{
        						string line = sr.ReadLine();
        						
        						if (line != null) {
        							ProcessLogFileLine(line);
        						} else {
        							break;
        						}
        					}
        				}
        			}
        		}
        		else
        		{
        			Ranorex.Report.Failure("Logging off");
        		}
        	}
        	
        	catch(Exception e)
        	{
        		Ranorex.Report.Failure("Exception while reading logfile: "+e.StackTrace.ToString());
        	}
        }
        
        public static void StartLogAgent()
        {
        	
        	logAgentTask = new Thread(()=>ExecuteLogAgent(onBoardLogFilePath));
        	Report.Info("Thread State Before: "+logAgentTask.ThreadState.ToString());
        	if(!logAgentTask.IsAlive)
        	{
        		Report.Info("Thread was not Alive, starting it");
        		logAgentTask.Start();
        	}
        	Report.Info("Thread State After: "+logAgentTask.ThreadState.ToString());
        	
        }
        
        public static void StopLogAgent()
        {
        	Ranorex.Report.Info("Stopping Log Agent");
        	readLog = false;
        	logAgentTask.Join();
        }
        
        /// <summary>
        /// Creates a new Queue if needed and keeps it limited to the last 10 occurences of the message from the log
        /// </summary>
        public static void AddToDictionaryMessageLinkedList(string key, System.DateTime timeStamp)
        {
        	try
        	{
        		if (!messageTimeStamps.ContainsKey(key))
        		{
        			messageTimeStamps.Add(key, new LinkedList<System.DateTime>());
        		} else if (messageTimeStamps[key].Count == 10)
        		{
        			//messageTimeStamps[key].RemoveLast();
        			messageTimeStamps.Remove(key);
        			messageTimeStamps.Add(key, new LinkedList<System.DateTime>());
        		}
        		
        		messageTimeStamps[key].AddFirst(timeStamp);
        	}
        	catch(Exception e)
        	{
        		Report.Info("Message to Remove:"+messageTimeStamps[key].Last.Value.ToString());
        		Ranorex.Report.Failure("Message Linked list exception: "+e.StackTrace.ToString());
        	}
            
            return;
        }
        
        /// <summary>
        /// Creates a new Queue if needed and keeps it limited to the last 10 occurences of the message from the log
        /// </summary>
        public static void AddToDictionaryHornDuration(System.DateTime key, int hornDuration)
        {
            if (!HornTimeStamps.ContainsKey(key))
            {
                HornTimeStamps.Add(key, hornDuration);
            }
            return;
        }
        
        /// <summary>
        /// Log Agent Loop for reading the onboard log
        /// </summary>
        [UserCodeMethod]
        public static void ExecuteLogAgent(string onBoardLogFilePath)
        {
            //Wait up to 5 seconds for file to exist
            int retries = 0;
            while (!System.IO.File.Exists(onBoardLogFilePath) && retries < 5)
            {
                Thread.Sleep(1000);
                retries++;
            }
            
            //Ensure file exists even asking for human intervention if it does not
            if (!System.IO.File.Exists(onBoardLogFilePath))
            {
                System.Windows.Forms.MessageBox.Show("File: {" + onBoardLogFilePath + "} is not being created, check the log agent and make sure it is storing in that file location");
                //Check one more time, if someone didn't intervene to generate this file, then throw an exception
                if (!System.IO.File.Exists(onBoardLogFilePath))
                {
                    throw new System.Exception("File: {" + onBoardLogFilePath + "} was not created");
                }
            }
            
            //Begin reading file to the end parsing data
            //TODO may need a way to increase the efficiency of this, as the file could be extremely long
            //Note: if we were to wipe out the file, we may lose what state we're in, but that may have to just be done everytime this is started
//            using (var fs = new FileStream(onBoardLogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//            {
//            	using (var sr = new StreamReader(fs, Encoding.Default))
//            	{
//	                while (true) 
//	                {
//	                    string line = sr.ReadLine();
//	                    if (sr.BaseStream.Length < sr.BaseStream.Position) 
//	                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
//	    
//	                    if (line != null)
//	                    {
//	                        ProcessLogFileLine(line);
//	                    } else {
//	                        break;
//	                    }
//	                }
//            	}
//            }
            
            //Once we've finished reading the totality of what's currently in the log file, we will begin a less resource intensive reading of the log file
            //TODO may need handling for when someone rewrites the log file
            StringBuilder line = new StringBuilder();
            try
            {
            	
            	using (var fs = new FileStream(onBoardLogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            	{
            		using (var sr = new StreamReader(fs, Encoding.Default))
            		{
            			//bool checkNextLine = false;
            			while (true)
            			{
            				
            				if (sr.BaseStream.Length < sr.BaseStream.Position)
            					sr.BaseStream.Seek(0, SeekOrigin.Begin);

            				line.Clear();
            				line = sr.ReadLineWithNewLine();
            				
            				if (!readLog) {
            					break;
            				} else if (line == null) {
            					Thread.Sleep(500);
            				} else {
            					if (!line.ToString().Contains("\n"))
            					{
            						//Ranorex.Report.Info(line);
            						sr.BaseStream.Seek((-1 * line.Length), SeekOrigin.Current);
            						//checkNextLine = true;
            						Thread.Sleep(500);
            					} else {
            						
            						line = line.Replace("\r", "");
            						line = line.Replace("\n", "");
            						if(skipLog)
            						{
            							if((line.ToString(0,4) == "CHR "))
            							{
            								ProcessLogFileLine(line.ToString());
            							}
            						}
            						else
            						{
            							if((line.ToString(0,4) == "OTX ") || (line.ToString(0,4) == "ORX ") || (line.ToString(0,4) == "SYS ")
            							   || (line.ToString(0,4) == "CHR "))
            							{
            								if((line.ToString(0,4) == "SYS ") && !hornValidate)
            								{
            									//Do nothing if line is SYS and hornValidate = false; Not adding any Horn details to avoid system running out of memory
            								}
            								else
            								{
            									ProcessLogFileLine(line.ToString());
            								}
            								
            							}
            						}
            						line.Clear();
            					}
            				}
            			}
            			sr.Dispose();
            		}
            		fs.Dispose();
            	}
            	Ranorex.Report.Info("Terminating FileStream");
            }
            catch(OutOfMemoryException e)
            {
            	Ranorex.Report.Info("Total Memory:"+GC.GetTotalMemory(true).ToString());
            	//Report.Info("Builder String: "+line.ToString());
				Report.Info("Capacity: "+line.Capacity.ToString());
				Report.Info("Max Capacity: "+line.MaxCapacity.ToString());
				Report.Info("Length: "+line.Length.ToString());
            	Ranorex.Report.Info("FileStream OOM: "+e.StackTrace.ToString());
            	line.Clear();
            	StopLogAgent();
            	StartLogAgent();
            }
            catch(Exception e)
            {
            	Ranorex.Report.Info("Total Memory:"+GC.GetTotalMemory(true).ToString());
            	Report.Info("Builder String: "+line.ToString());
				Report.Info("Capacity: "+line.Capacity.ToString());
				Report.Info("Max Capacity: "+line.MaxCapacity.ToString());
				Report.Info("Length: "+line.Length.ToString());
            	Ranorex.Report.Info("FileStream: "+e.StackTrace.ToString());
            	line.Clear();
            	StopLogAgent();
            	StartLogAgent();
            }
            
            
        }
        
        
        
        /// <summary>
        /// Log Agent Loop for reading the onboard log
        /// </summary>
        public static void ProcessLogFileLine(string logFileLine)
        {
        	if (logFileLine.Length < 5)
        	{
        		return;
        	}
        	string logType = logFileLine.Substring(0, 4);
        	
        	try{
        		switch (logType)
        		{
        			case "OTX ":
        				//OTX :2014/05/23 13:30:01.830:OTC:Sending Office msg [2087]
        			case "ORX ":
        				//ORX :2014/05/23 14:35:07.107:OTC:Rcvd Office msg [1040] from AG
        				if (!logFileLine.Contains("["))
        				{
        					break;
        				}
        				AddToDictionaryMessageLinkedList(logFileLine.Split('[')[1].Split(']')[0], System.DateTime.ParseExact(logFileLine.Substring(5).Split(new string[]{":OTC"}, StringSplitOptions.None)[0], "yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        				break;
        				//For Horn Manager SYS :2020/08/24 17:43:13.528:HORN_MGR:hm_send_horn_msg(APPLY)
        			case "SYS ":
        				if(logFileLine.Contains("APPLY") && logFileLine.Contains("HORN_MGR"))
        				{
        					//Report.Info("Horn Start: "+logFileLine);
        					if((hornStartTime != hornEndTime) && hornState == "OFF")
        					{
        						if((hornStartTime < hornEndTime))
        						{
        							hornStartTime = System.DateTime.ParseExact(logFileLine.Substring(5).Split(new string[]{":HORN_MGR"}, StringSplitOptions.None)[0], "yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        						}
        					}
        					
        					hornState = "ON";
        					
        				}
        				if(logFileLine.Contains("RELEASE") && logFileLine.Contains("HORN_MGR"))
        				{
        					
        					//Report.Info("Horn End: "+logFileLine);
        					hornEndTime = System.DateTime.ParseExact(logFileLine.Substring(5).Split(new string[]{":HORN_MGR"}, StringSplitOptions.None)[0], "yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        					
        					if((hornEndTime > hornStartTime) && hornState == "ON")
        					{
        						lastHornDuration = ((TimeSpan) (hornEndTime - hornStartTime)).Seconds;
        						//Report.Info("Horn End Time: "+hornEndTime.ToString());
        						AddToDictionaryHornDuration(hornEndTime.ToLocalTime(), lastHornDuration);
        						//Report.Info("Last Blast duration: "+lastHornDuration.ToString());
        					}
        					hornState = "OFF";
        					
        				}
        				break;
        			case "CHR ":
        				//CHR :2014/05/29 16:39:13.151:VETMS_CHM_RECORDER:NAL|0|1|0|NS|1509|1010|7314|NS|1509|1013|26401|SWITCH UNKNOWN|0|0|0|NS|1509|1011|9280|NS|1509|1013|26401|SWITCH UNKNOWN|0|0|0|NS|1509|1012|1520|NS|1509|1013|26401|SWITCH UNKNOWN|0|0|0
        				//CHR :2014/05/23 14:37:21.934:VETMS_CHM_RECORDER:2014/05/23|14:37:21.934|1|SYS|3|CO|5|1|1|1|1|0|0|1|0|0|0
        				//CHR :2014/06/23 14:30:04.629:VETMS_CHM_RECORDER:2014/06/23|14:30:04.629|1|SYS|3|DS|16|1|1|1|1|0|0|1|0|0|0
        				string[] pipeSplitLogFileLine = logFileLine.Split(new char[] {'|'}, 4);
        				if (pipeSplitLogFileLine.Length < 4)
        				{
        					break;
        				}
        				string chrType = pipeSplitLogFileLine[2];
        				//We don't care about NAL, AL, or L Types
        				if (!pipeSplitLogFileLine[1].Contains(":"))
        				{
        					break;
        				}
        				switch (chrType)
        				{
        					case "1":
        						//CHR :2014/05/23 14:37:21.934:VETMS_CHM_RECORDER:2014/05/23|14:37:21.934|1|SYS|3|CO|5|1|1|1|1|0|0|1|0|0|0
        						//CHR :2014/06/23 14:30:04.629:VETMS_CHM_RECORDER:2014/06/23|14:30:04.629|1|SYS|3|DS|16|1|1|1|1|0|0|1|0|0|0
        						controlInfo = pipeSplitLogFileLine[3];
        						break;
        					case "3":
        						//CHR :2014/04/22 12:16:51.111:VETMS_CHM_RECORDER:04/22/2014|12:16:51.107|3|TRN|2|NS    9989||||0||FR|F|1|0|0|0|150|0|0|0|0
        						//CHR :2014/05/23 14:37:26.942:VETMS_CHM_RECORDER:2014/05/23|14:37:26.942|3|TRN|4|NS    9989|1|NS.G63.0.05232014|NS|155|||0|155|FR|F|2|2925|100|100|5390|60|15|500000|0
        						//CHR :2014/05/30 14:02:13.343:VETMS_CHM_RECORDER:2014/05/30|14:02:13.342|3|TRN|4|NS    9989|0|||0||FR|F|1|0|0|0|40|0|0|0|0 - Found 22 - expected 25?
        						trainInfo = pipeSplitLogFileLine[3];
        						break;
        					case "5":
        						//CHR :2014/04/22 12:06:53.513:VETMS_CHM_RECORDER:04/22/2014|12:06:53.509|5|GPS|3|1|34:30.6137|N|81:8.8055|W|2|08|1.4
        						//CHR :2014/04/22 12:06:53.516:VETMS_CHM_RECORDER:04/22/2014|12:06:53.513|5|GPS|3|2|34:30.6137|N|81:8.8055|W|2|08|1.4
        						gpsInfo = pipeSplitLogFileLine[3];
        						break;
        					case "6":
        						//CHR :2014/04/25 12:02:37.542:VETMS_CHM_RECORDER:04/25/2014|12:02:37.542|6|LOC|2|0.01||||||||||||||0|50
        						locationInfo = pipeSplitLogFileLine[3];
        						break;
        					case "12":
        						//CHR :2014/06/17 18:46:44.536:VETMS_CHM_RECORDER:2014/06/17|18:46:44.536|12|BNR|1|D|BRAKING IN PROGRESS
        						//CHR :2014/06/17 18:47:29.510:VETMS_CHM_RECORDER:2014/06/17|18:47:29.509|12|BNR|1|R|BRAKING IN PROGRESS
        						string topBannerType = pipeSplitLogFileLine[3].Split('|')[2];
        						if (topBannerType == "D")
        						{
        							//Report.Info("topBanner: "+logFileLine);
        							//Report.Info("TopBannerSplit: "+logFileLine.Substring(5).Split(new string[]{":VETMS_CHM_RECORDER"}, StringSplitOptions.None)[0].ToString());
        							topBanner = pipeSplitLogFileLine[3].Split('|')[3];
        						} else if (topBannerType == "R")
        						{
        							topBanner = "";
        							//Report.Info("lastTopBanner: "+logFileLine);
        							//Report.Info("LastTopBannerSplit: "+logFileLine.Substring(5).Split(new string[]{":VETMS_CHM_RECORDER"}, StringSplitOptions.None)[0].ToString());
        							lastTopBanner = pipeSplitLogFileLine[3].Split('|')[3];
        						}
        						break;
        					case "13":
        						//CHR :2014/04/21 17:35:18.429:VETMS_CHM_RECORDER:04/21/2014|17:35:18.425|13|PRM|1|R|SELECT CONSIST ACTION
        						//CHR :2020-08-21 18:50:50.041:VETMS_CHM_RECORDER:2020/08/21|18:50:50.041|13|PRM|1|D|MAXIMUM SPEED IS 35 MPH
        						if (pipeSplitLogFileLine[3].Split('|').Length < 3)
        						{
        							break;
        						}
        						string bannerType = pipeSplitLogFileLine[3].Split('|')[2];
        						if (bannerType == "D")
        						{
        							//Report.Info("Banner: "+logFileLine);
        							//Report.Info("BannerSplit: "+logFileLine.Substring(5).Split(new string[]{":VETMS_CHM_RECORDER"}, StringSplitOptions.None)[0].ToString());
        							banner = pipeSplitLogFileLine[3].Split('|')[3];
        							//Report.Info("Banner: "+pipeSplitLogFileLine[3]);
        							//Report.Info("Logfile: "+logFileLine);
        						} else if (bannerType == "R")
        						{
        							banner = "";
        							//Report.Info("lastBanner: "+logFileLine);
        							//Report.Info("LastBannerSplit: "+logFileLine.Substring(5).Split(new string[]{":VETMS_CHM_RECORDER"}, StringSplitOptions.None)[0].ToString());
        							lastBanner = pipeSplitLogFileLine[3].Split('|')[3];
        						}
        						break;
        					case "14":
        						//CHR :2014/04/25 12:02:42.113:VETMS_CHM_RECORDER:04/25/2014|12:02:42.112|14|KDP|2|Train Type|Locos|Weight|Operative Brakes|Length|Car / Axle Counts|Eqp-Spd Restrict|Accept
        						if (pipeSplitLogFileLine[3] == "")
        						{
        							break;
        						}
        						buttons = pipeSplitLogFileLine[3].Split(new char[] {'|'}, 3)[2].Replace("[", "").Replace("]", "").Split('|');
        						break;
        					case "15":
        						//CHR :2014/04/22 12:52:18.753:VETMS_CHM_RECORDER:04/22/2014|12:52:18.749|15|KPR|1|Main
        						lastButton = pipeSplitLogFileLine[3].Split('|')[2].Replace("[", "").Replace("]", "");
        						break;
        					case "17":
        						//CHR :2014/06/24 14:04:33.283:VETMS_CHM_RECORDER:2014/06/24|14:04:33.282|17|BHA|3|64|64|1|0|0|
        						bhInfo = pipeSplitLogFileLine[3];
        						currentHornDOT = pipeSplitLogFileLine[3].Split('|')[7];
        						//Report.Info("Current Dot Info: "+logFileLine);
        						//Report.Info("Current Horn Dot: "+currentHornDOT);
        						break;
        				}
        				break;
        		}
        		
        	}
        	catch(Exception e)
        	{
        		Report.Info("Log file: "+logFileLine.ToString());
        		Ranorex.Report.Failure("Log File Exception: "+e.StackTrace.ToString());
        		Ranorex.Report.Failure("Log File Message: "+e.Message.ToString());
        	}
            
        }
    }
}
