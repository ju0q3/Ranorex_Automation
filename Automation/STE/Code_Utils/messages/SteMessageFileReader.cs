/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/2/2018
 * Time: 12:53 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using STE.Code_Utils;
using STE.Code_Utils.messages.MIS.NS;
using STE.Code_Utils.messages.PTC;
using STE.Code_Utils.messages.RUM;
using System.Text.RegularExpressions;





namespace STE.Code_Utils.messages
{
    /// <summary>
    /// Description of SteMessageReader.
    /// </summary>
    public class SteMessageFileReader
    {
        public SteMessageFileReader()
        {
        }
        
        /*
         * getFilesWithinTimeFrame checks the specified directory for files within the specified time frame for messages of the 
         * specified type and version
         */
        private static List<string> getFilesWithinTimeframe(string directory, string messageType, string version, int timeInSeconds)
        {
            DateTime fromDate = DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
            DateTime toDate = DateTime.Now;
            
            List<string> paths = Directory.EnumerateFiles(directory, "*" +messageType+ "*", SearchOption.AllDirectories)
                .Where(path => {
                   DateTime lastWriteTime = File.GetLastWriteTime(path);
                   return lastWriteTime >= fromDate && lastWriteTime <= toDate;
                })
            .ToList();
            
            List<string> files = new List<string>();
            
            foreach (var path in paths)
            {
            	string contents = "";
            	bool success = false;
            	int retries = 0;
            	
            	if(path.ToString().Contains("MQ_ERROR") && messageType != "MQ_ERROR")
            	{
            		continue;
            	}
            	
            	while (!success && retries < 10)
            	{
            		try {
            			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            			{
            				using (StreamReader sr = new StreamReader(fs))
            				{
            					success = true;
            					contents = sr.ReadToEnd();
            					if (version != "")
            					{
            						StringBuilder msgIdBuilder = new StringBuilder();
            						msgIdBuilder.Append("<MESSAGE_ID>");
            						msgIdBuilder.Append(messageType);
            						msgIdBuilder.Append("</MESSAGE_ID>");
            						string messageId = msgIdBuilder.ToString();
            						
            						StringBuilder msgVersionBuilder = new StringBuilder();
            						msgVersionBuilder.Append("<MESSAGE_VERSION>");
            						msgVersionBuilder.Append(version);
            						msgVersionBuilder.Append("</MESSAGE_VERSION>");
            						string messageVersion = msgVersionBuilder.ToString();
            						
            						//string contents = sr.ReadToEnd();
            						if ((contents.Contains(messageId)) && (contents.Contains(messageVersion)))
            						{
            							files.Add(path);
            						}
            					} else {
            						files.Add(path);
            					}
            				}
            			}
            		} catch (IOException) {
            			retries++;
            			Thread.Sleep(50);
            		}
            	}
            }
            
            return files;
        }
        
        private static List<string> getMIMFilesWithinTimeframe_MIS(string directory, string messageType, string version, int timeInSeconds)
        {
            DateTime fromDate = DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
            DateTime toDate = DateTime.Now;
            List<string> paths = Directory.EnumerateFiles(directory, "*"+messageType+"*", SearchOption.AllDirectories)
                .Where(path => {
                   DateTime lastWriteTime = File.GetLastWriteTime(path);
                   return lastWriteTime >= fromDate && lastWriteTime <= toDate;
                })
            .ToList();
            
            List<string> files = new List<string>();
            
            foreach (var path in paths)
            {
            	string contents = "";
            	FileStream messageFileStream = WaitForFile(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(messageFileStream))
                {
                	contents = sr.ReadToEnd();
                }
                messageFileStream.Close();
                if (version != "")
                {
                    StringBuilder msgIdBuilder = new StringBuilder();
                    msgIdBuilder.Append("<MSGID>");
                    msgIdBuilder.Append(messageType);
                    msgIdBuilder.Append("</MSGID>");
                    string messageId = msgIdBuilder.ToString();
                    
                    if (contents.Contains(messageId))
                    {
                        files.Add(path);
                    }
                } else {
                	files.Add(path);
                }
            }
            
            return files;
        }
        
        private static List<string> getFilesWithinTimeframe_MIS(string directory, string messageType, int timeInSeconds)
        {
            DateTime fromDate = DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
            DateTime toDate = DateTime.Now;
            List<string> paths = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories)
                .Where(path => {
                   DateTime lastWriteTime = File.GetLastWriteTime(path);
                   return lastWriteTime >= fromDate && lastWriteTime <= toDate;
                })
            .ToList();
            
            List<string> files = new List<string>();
            
            StringBuilder msgIdBuilder = new StringBuilder();
            msgIdBuilder.Append("<MSGID>");
            msgIdBuilder.Append(messageType);
            msgIdBuilder.Append("</MSGID>");
            string messageId = msgIdBuilder.ToString();   
            
            foreach (var path in paths)
            {
            	string contents = "";
            	FileStream messageFileStream = WaitForFile(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(messageFileStream))
                {
                	contents = sr.ReadToEnd();
                }
                messageFileStream.Close();
                             
            	//string contents = sr.ReadToEnd();
                if ((contents.Contains(messageId)))
                {
                    files.Add(path);
                }
                    
            }
            
            return files;
        }
        
        private static string getSpecificFileWithinTimeframe_MIS(string directory, string[] messageFilters, int timeInSeconds)
        {
            DateTime fromDate = DateTime.Now.AddSeconds(-System.Math.Abs(timeInSeconds));
            DateTime toDate = DateTime.Now;
            bool found = false;
            List<string> paths = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories)
                .Where(path => {
                   DateTime lastWriteTime = File.GetLastWriteTime(path);
                   return lastWriteTime >= fromDate && lastWriteTime <= toDate;
                })
            .ToList();
            
            List<string> files = new List<string>();  
            
            foreach (var path in paths)
            {
            	string contents = "";
            	FileStream messageFileStream = WaitForFile(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(messageFileStream))
                {
                	contents = sr.ReadToEnd();
                }
                messageFileStream.Close();
                             
                if (checkFilters(path, messageFilters))
                {
                	found = true;
            	}
                if (found)
                	return path;
                    
            }
            
            return null;
        }
        
		private static FileStream WaitForFile (string fullPath, FileMode mode, FileAccess access, FileShare share)
		{
    		for (int numTries = 0; numTries < 10; numTries++) {
        		FileStream fs = null;
        		try {
            		fs = new FileStream (fullPath, mode, access, share);
            		return fs;
        		}
        		catch (IOException) {
            		if (fs != null) {
                		fs.Dispose ();
            		}
            		Thread.Sleep(50);
        		}
    		}

    		return null;
		}
        
        // updateMessageHeader needs to be called to make the message match the class
        // Because we cannot have - in classnames, we had to convert messages to use _
        // We also have to have all the tags between <HEADER> and </HEADER> prepended with HEADER_
        // so the objects can be filled upon deserialization.
        private static void updateMessageHeader(string file, string messageId, string className)
        {
            StreamReader sr = new StreamReader(file);
            String input = sr.ReadToEnd();
            sr.Close();
            
            StreamWriter sw = new StreamWriter(file);
            //Replace message baseTag
            if (input.Contains(messageId))
            {
                input = input.Replace(messageId+">", className+">");
            }
            
            string startTag = "<HEADER>";
            string endTag = "</HEADER>";
            
            int startIndex = input.IndexOf(startTag) + startTag.Length;
            int endIndex = input.IndexOf(endTag, startIndex);
            string headerSubstring = input.Substring(startIndex, endIndex - startIndex);
            
            //prepend HEADER_ to header attribute tags.
            string replaceString = headerSubstring.Replace("</", "</HEADER_");
            replaceString = replaceString.Replace("<", "<HEADER_");
            replaceString = replaceString.Replace("<HEADER_/", "</");
            
            input = input.Replace(headerSubstring, replaceString);
            
            sw.WriteLine(input);
            sw.Close();
        }
        
        /// <summary>
        /// checkFilters verifies all string patterns are in a particular file.  Returns true if all are found, false otherwise
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        private static bool checkFilters(string file, string[] filters)
        {
         bool filterCheck = true;
			bool success = false;
			int retries = 0;
			while (!success && retries < 10)
			{
				try {
					using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						using (StreamReader sr = new StreamReader(fs))
						{
							success = true;
							if (filters != null && filters.Length > 0)
							{
								string message = sr.ReadToEnd().ToString();
								foreach (string filter in filters)
								{
									Regex filterRegex = new Regex(@".*"+@filter+@".*");
									if (!filterRegex.IsMatch(message.Trim()))
									{
										Ranorex.Report.Info("Filter not matched: "+filter);
										filterCheck = false;
										break;
									}
								}
							}
						}
					}
				} catch (IOException) {
					retries++;
					Thread.Sleep(50);
				}
			}
            
            return filterCheck;
        }
        
        private static bool checkFiltersOR(string file, string[] filters)
        {
         bool filterCheck = false;
			bool success = false;
			int retries = 0;
			while (!success && retries < 10)
			{
				try {
					using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						using (StreamReader sr = new StreamReader(fs))
						{
							success = true;
							if (filters != null && filters.Length > 0)
							{
								string message = sr.ReadToEnd().ToString();
								foreach (string filter in filters)
								{
									Regex filterRegex = new Regex(@".*"+@filter+@".*");
									if (filterRegex.IsMatch(message.Trim()))
									{
										Ranorex.Report.Info("Filter matched: "+filter);
										filterCheck = true;
										break;
									}
								}
							}
						}
					}
				} catch (IOException) {
					retries++;
					Thread.Sleep(50);
				}
			}
            
            return filterCheck;
        }
        
        private static string getFilteredFile(string messageType, string version, string[] filters, int timeInSeconds=5)
        {
        	List<string> files = getFilesWithinTimeframe(SteUtils.getInboundPtcDir(), messageType, version, timeInSeconds);
			string file = null;
			
			if (files.Count > 0)
			{
			    foreach (string checkFile in files)
			    {
			    	if (checkFilters(checkFile, filters))
			        {
			            file = checkFile;
			            break;
			        }
			    }
			}
			
			return file;
        }
        
        private static string getFilteredFileOR(string messageType, string version, string[] filters, int timeInSeconds=5)
        {
        	List<string> files = getFilesWithinTimeframe(SteUtils.getInboundPtcDir(), messageType, version, timeInSeconds);
			string file = null;
			
			if (files.Count > 0)
			{
			    foreach (string checkFile in files)
			    {
			    	if (checkFiltersOR(checkFile, filters))
			        {
			            file = checkFile;
			            break;
			        }
			    }
			}
			
			return file;
        }

        public static string GetFilteredFile(string messageType, string version, string[] filters, int timeInSeconds = 5)
        {
            // This is part of a POC. Please refrain from change requests at this time. 

            return getFilteredFile(messageType, version, filters, timeInSeconds);
        }
        
        private static string getFilteredFile_MIS(string messageType, string[] filters, int timeInSeconds=5)
        {
        	List<string> files = getFilesWithinTimeframe_MIS(SteUtils.getInboundMisDir(), messageType, timeInSeconds);
			string file = null;
			
			if (files.Count > 0)
			{
			    foreach (string checkFile in files)
			    {
			        if (checkFilters(checkFile, filters))
			        {
			            file = checkFile;
			            break;
			        }
			    }
			}
			
			return file;
        }
        
        private static string getMIMFilteredFile_MIS(string messageType, string version, string[] filters, int timeInSeconds=5)
        {
        	List<string> files = getMIMFilesWithinTimeframe_MIS(SteUtils.getInboundMisDir(), messageType, version, timeInSeconds);
			string file = null;
			
			if (files.Count > 0)
			{
			    foreach (string checkFile in files)
			    {
			        if (checkFilters(checkFile, filters))
			        {
			            file = checkFile;
			            break;
			        }
			    }
			}
			
			return file;
        }
        
        private static string getMIMFilteredFile_MISPerf(string messageType, string version, string[] filters, int timeInSeconds=5)
        {
        	List<string> files = getMIMFilesWithinTimeframe_MIS(SteUtils.getInboundMisDir(), messageType, version, timeInSeconds);
			string file = null;
			
			if (files.Count > 0)
			{
			    foreach (string checkFile in files)
			    {
			        if (checkFiltersOR(checkFile, filters))
			        {
			            file = checkFile;
			            break;
			        }
			    }
			}
			
			return file;
        }
        
        public static bool getMessagePrintFax(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            bool result = false;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(PrintFax));
			
			file = getFilteredFile_MIS("PrintFax", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getFilteredFile_MIS("PrintFax", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
    			result = true;
		    }
			
			return result;
        }
        
        public static bool getSpecificMessage(string[] filters, int timeInSeconds=5, bool retry=true)
        {
        	bool result = false;
            string file = null;
			
            file = getSpecificFileWithinTimeframe_MIS(SteUtils.getInboundMisDir(), filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getSpecificFileWithinTimeframe_MIS(SteUtils.getInboundMisDir(), filters, timeInSeconds);
			}
			
		    if (file != null)
		    {
		       result = true;
		    }
			
			return result;
        }
        
        public static bool getMessageError(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            bool result = false;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessageConfig));
			
			file = getFilteredFile_MIS("ErrorMessage", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getFilteredFile_MIS("ErrorMessage", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
		       result = true;
		    }
			
			return result;
        }
        
        public static bool getMovementInformationMessage(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            bool result = false;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessageConfig));
			
			file = getFilteredFile_MIS("MovementInformation", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getFilteredFile_MIS("MovementInformation", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
		       result = true;
		    }
			
			return result;
        }        
                
        public static MIS.CN.MIS_ErrorMessagesConfig getMessageErrorsCN(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.ErrorMessagesConfig errormessages = null;
            MIS.CN.MIS_ErrorMessagesConfig mis_errormessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.ErrorMessagesConfig));
			
			file = getFilteredFile("ErrorMessages", "1", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getFilteredFile("ErrorMessages", "1", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			errormessages = (MIS.CN.ErrorMessagesConfig) serializer.Deserialize(stream);
    			mis_errormessages = MIS.CN.MIS_ErrorMessagesConfig.fromSerializableObject(errormessages);
		    }
			
			return mis_errormessages;
        }
        
        public static MIS_ErrorMessagesConfig getMessageErrorsNS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.ErrorMessagesConfig errormessages = null;
            MIS.NS.MIS_ErrorMessagesConfig mis_errormessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.ErrorMessagesConfig));
			
			file = getFilteredFile("ErrorMessages", "1", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getFilteredFile("ErrorMessages", "1", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			errormessages = (MIS.NS.ErrorMessagesConfig) serializer.Deserialize(stream);
    			mis_errormessages = MIS.NS.MIS_ErrorMessagesConfig.fromSerializableObject(errormessages);
		    }
			
			return mis_errormessages;
        }
        
        public static MIS.CN.MIS_MovementInformationConfig getMovementInformationMessageContent_CN(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.MovementInformationConfig movementMessages = null;
            MIS.CN.MIS_MovementInformationConfig mis_movementmessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.MovementInformationConfig));
			
			file = getMIMFilteredFile_MIS("MovementInformation", "1", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getMIMFilteredFile_MIS("MovementInformation", "1", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			movementMessages = (MIS.CN.MovementInformationConfig) serializer.Deserialize(stream);
    			mis_movementmessages = MIS.CN.MIS_MovementInformationConfig.fromSerializableObject(movementMessages);
		    }
			
			return mis_movementmessages;
        }
        
        public static MIS.CN.MIS_MovementInformationConfig getMovementInformationMessageContent_CNPerf(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.MovementInformationConfig movementMessages = null;
            MIS.CN.MIS_MovementInformationConfig mis_movementmessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.MovementInformationConfig));
			
			file = getMIMFilteredFile_MISPerf("MovementInformation", "1", filters, timeInSeconds);
			
			
			while (file == null && retry)
			{
				
                Thread.Sleep(3000);
                file = getMIMFilteredFile_MISPerf("MovementInformation", "1", filters, timeInSeconds + 5);
                //Ranorex.Report.Info (" waiting for Inbound message");
			}
			
		    if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			movementMessages = (MIS.CN.MovementInformationConfig) serializer.Deserialize(stream);
    			mis_movementmessages = MIS.CN.MIS_MovementInformationConfig.fromSerializableObject(movementMessages);
		    }
			
			return mis_movementmessages;
        }
        
        public static MIS.NS.MIS_MovementInformationConfig getMovementInformationMessageContent_NS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.MovementInformationConfig movementMessages = null;
            MIS.NS.MIS_MovementInformationConfig mis_movementmessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.MovementInformationConfig));
			
			file = getMIMFilteredFile_MIS("MovementInformation", "1", filters, timeInSeconds);
			
			if (file == null && retry)
			{
                Thread.Sleep(5000);
                file = getMIMFilteredFile_MIS("MovementInformation", "1", filters, timeInSeconds + 5);
			}
			
		    if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			movementMessages = (MIS.NS.MovementInformationConfig) serializer.Deserialize(stream);
    			mis_movementmessages = MIS.NS.MIS_MovementInformationConfig.fromSerializableObject(movementMessages);
		    }
			
			return mis_movementmessages;
        }
        
        public static MIS.CN.MIS_ETAInformationConfig getETAInformationMessageContent_CN(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.CN.ETAInformationConfig etaMessages = null;
            MIS.CN.MIS_ETAInformationConfig mis_etamessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.CN.ETAInformationConfig));
			
			file = getFilteredFile_MIS("ETAInformation", filters, timeInSeconds);
			
			if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			etaMessages = (MIS.CN.ETAInformationConfig) serializer.Deserialize(stream);
    			mis_etamessages = MIS.CN.MIS_ETAInformationConfig.fromSerializableObject(etaMessages);
		    }
			
			return mis_etamessages;
        }
        
        public static MIS.NS.MIS_ETAInformationConfig getETAInformationMessageContent_NS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.ETAInformationConfig etaMessages = null;
            MIS.NS.MIS_ETAInformationConfig mis_etamessages = null;
            string file = null;
			XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.ETAInformationConfig));
			
			file = getFilteredFile_MIS("ETAInformation", filters, timeInSeconds);
			
			if (file != null)
		    {
    			FileStream stream = new FileStream(file, FileMode.Open);
    			etaMessages = (MIS.NS.ETAInformationConfig) serializer.Deserialize(stream);
    			mis_etamessages = MIS.NS.MIS_ETAInformationConfig.fromSerializableObject(etaMessages);
		    }
			
			return mis_etamessages;
        }


        /// <summary>
        /// getMessageDC_ERROR_1 retrieves a DC-ERROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ERROR_1</returns>
        public static PTC_DC_ERROR_1 getMessageDC_ERROR_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ERROR_1 dc_error = null;
            PTC_DC_ERROR_1 ptc_dc_error = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ERROR_1));
            
            file = getFilteredFile("DC-ERROR", "1", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-ERROR", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-ERROR", "DC_ERROR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_error = (DC_ERROR_1) serializer.Deserialize(stream);
                ptc_dc_error = PTC_DC_ERROR_1.fromSerializableObject(dc_error);
            }
            
            return ptc_dc_error;
        }

        /// <summary>
        /// getMessageDG_ERROR_1 retrieves a DG-ERROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_ERROR_1</returns>
        public static PTC_DG_ERROR_1 getMessageDG_ERROR_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_ERROR_1 dg_error = null;
            PTC_DG_ERROR_1 ptc_dg_error = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_ERROR_1));
            
            file = getFilteredFile("DG-ERROR", "1", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-ERROR", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-ERROR", "DG_ERROR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_error = (DG_ERROR_1) serializer.Deserialize(stream);
                ptc_dg_error = PTC_DG_ERROR_1.fromSerializableObject(dg_error);
            }
            
            return ptc_dg_error;
        }

        /// <summary>
        /// getMessageDC_AK01_2 retrieves a DC-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_AK01_2</returns>
        public static PTC_DC_AK01_2 getMessageDC_AK01_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_AK01_2 dc_ak01 = null;
            PTC_DC_AK01_2 ptc_dc_ak01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_AK01_2));
            
            file = getFilteredFile("DC-AK01", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-AK01", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-AK01", "DC_AK01_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ak01 = (DC_AK01_2) serializer.Deserialize(stream);
                ptc_dc_ak01 = PTC_DC_AK01_2.fromSerializableObject(dc_ak01);
            }
            
            return ptc_dc_ak01;
        }

        /// <summary>
        /// getMessageDC_AK01_7 retrieves a DC-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_AK01_7</returns>
        public static PTC_DC_AK01_7 getMessageDC_AK01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_AK01_7 dc_ak01 = null;
            PTC_DC_AK01_7 ptc_dc_ak01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_AK01_7));
            
            file = getFilteredFile("DC-AK01", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-AK01", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-AK01", "DC_AK01_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ak01 = (DC_AK01_7) serializer.Deserialize(stream);
                ptc_dc_ak01 = PTC_DC_AK01_7.fromSerializableObject(dc_ak01);
            }
            
            return ptc_dc_ak01;
        }

        /// <summary>
        /// getMessageDC_ASBI_2 retrieves a DC-ASBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ASBI_2</returns>
        public static PTC_DC_ASBI_2 getMessageDC_ASBI_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ASBI_2 dc_asbi = null;
            PTC_DC_ASBI_2 ptc_dc_asbi = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ASBI_2));
            
            file = getFilteredFile("DC-ASBI", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-ASBI", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-ASBI", "DC_ASBI_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_asbi = (DC_ASBI_2) serializer.Deserialize(stream);
                ptc_dc_asbi = PTC_DC_ASBI_2.fromSerializableObject(dc_asbi);
            }
            
            return ptc_dc_asbi;
        }

        /// <summary>
        /// getMessageDC_ASBI_7 retrieves a DC-ASBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ASBI_7</returns>
        public static PTC_DC_ASBI_7 getMessageDC_ASBI_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ASBI_7 dc_asbi = null;
            PTC_DC_ASBI_7 ptc_dc_asbi = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ASBI_7));
            
            file = getFilteredFile("DC-ASBI", "7", filters, timeInSeconds);
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
            while (System.DateTime.Now < future && file == null) {
                file = getFilteredFile("DC-ASBI", "7", filters, timeInSeconds);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-ASBI", "DC_ASBI_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_asbi = (DC_ASBI_7) serializer.Deserialize(stream);
                ptc_dc_asbi = PTC_DC_ASBI_7.fromSerializableObject(dc_asbi);
            }
            
            return ptc_dc_asbi;
        }

        /// <summary>
        /// getMessageDC_DIBS_2 retrieves a DC-DIBS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DIBS_2</returns>
        public static PTC_DC_DIBS_2 getMessageDC_DIBS_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DIBS_2 dc_dibs = null;
            PTC_DC_DIBS_2 ptc_dc_dibs = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DIBS_2));
            
            file = getFilteredFile("DC-DIBS", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-DIBS", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-DIBS", "DC_DIBS_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_dibs = (DC_DIBS_2) serializer.Deserialize(stream);
                ptc_dc_dibs = PTC_DC_DIBS_2.fromSerializableObject(dc_dibs);
            }
            
            return ptc_dc_dibs;
        }

        /// <summary>
        /// getMessageDC_DIBS_7 retrieves a DC-DIBS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DIBS_7</returns>
        public static PTC_DC_DIBS_7 getMessageDC_DIBS_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DIBS_7 dc_dibs = null;
            PTC_DC_DIBS_7 ptc_dc_dibs = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DIBS_7));
            
            file = getFilteredFile("DC-DIBS", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-DIBS", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-DIBS", "DC_DIBS_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_dibs = (DC_DIBS_7) serializer.Deserialize(stream);
                ptc_dc_dibs = PTC_DC_DIBS_7.fromSerializableObject(dc_dibs);
            }
            
            return ptc_dc_dibs;
        }

        /// <summary>
        /// getMessageDC_ENED_2 retrieves a DC-ENED message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ENED_2</returns>
        public static PTC_DC_ENED_2 getMessageDC_ENED_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ENED_2 dc_ened = null;
            PTC_DC_ENED_2 ptc_dc_ened = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ENED_2));
            
            file = getFilteredFile("DC-ENED", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-ENED", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-ENED", "DC_ENED_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ened = (DC_ENED_2) serializer.Deserialize(stream);
                ptc_dc_ened = PTC_DC_ENED_2.fromSerializableObject(dc_ened);
            }
            
            return ptc_dc_ened;
        }

        /// <summary>
        /// getMessageDC_ENED_7 retrieves a DC-ENED message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_ENED_7</returns>
        public static PTC_DC_ENED_7 getMessageDC_ENED_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_ENED_7 dc_ened = null;
            PTC_DC_ENED_7 ptc_dc_ened = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_ENED_7));
            
            file = getFilteredFile("DC-ENED", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-ENED", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-ENED", "DC_ENED_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ened = (DC_ENED_7) serializer.Deserialize(stream);
                ptc_dc_ened = PTC_DC_ENED_7.fromSerializableObject(dc_ened);
            }
            
            return ptc_dc_ened;
        }

        /// <summary>
        /// getMessageDC_KA01_2 retrieves a DC-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_KA01_2</returns>
        public static PTC_DC_KA01_2 getMessageDC_KA01_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_KA01_2 dc_ka01 = null;
            PTC_DC_KA01_2 ptc_dc_ka01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_KA01_2));
            
            file = getFilteredFile("DC-KA01", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-KA01", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-KA01", "DC_KA01_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ka01 = (DC_KA01_2) serializer.Deserialize(stream);
                ptc_dc_ka01 = PTC_DC_KA01_2.fromSerializableObject(dc_ka01);
            }
            
            return ptc_dc_ka01;
        }

        /// <summary>
        /// getMessageDC_KA01_7 retrieves a DC-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_KA01_7</returns>
        public static PTC_DC_KA01_7 getMessageDC_KA01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_KA01_7 dc_ka01 = null;
            PTC_DC_KA01_7 ptc_dc_ka01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_KA01_7));
            
            file = getFilteredFile("DC-KA01", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-KA01", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-KA01", "DC_KA01_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_ka01 = (DC_KA01_7) serializer.Deserialize(stream);
                ptc_dc_ka01 = PTC_DC_KA01_7.fromSerializableObject(dc_ka01);
            }
            
            return ptc_dc_ka01;
        }

        /// <summary>
        /// getMessageDC_MESS_2 retrieves a DC-MESS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_MESS_2</returns>
        public static PTC_DC_MESS_2 getMessageDC_MESS_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_MESS_2 dc_mess = null;
            PTC_DC_MESS_2 ptc_dc_mess = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_MESS_2));
            
            file = getFilteredFile("DC-MESS", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-MESS", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-MESS", "DC_MESS_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_mess = (DC_MESS_2) serializer.Deserialize(stream);
                ptc_dc_mess = PTC_DC_MESS_2.fromSerializableObject(dc_mess);
            }
            
            return ptc_dc_mess;
        }

        /// <summary>
        /// getMessageDC_MESS_7 retrieves a DC-MESS message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_MESS_7</returns>
        public static PTC_DC_MESS_7 getMessageDC_MESS_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_MESS_7 dc_mess = null;
            PTC_DC_MESS_7 ptc_dc_mess = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_MESS_7));
            
            file = getFilteredFile("DC-MESS", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-MESS", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-MESS", "DC_MESS_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_mess = (DC_MESS_7) serializer.Deserialize(stream);
                ptc_dc_mess = PTC_DC_MESS_7.fromSerializableObject(dc_mess);
            }
            
            return ptc_dc_mess;
        }

        /// <summary>
        /// getMessageDC_TCON_6 retrieves a DC-TCON message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TCON_6</returns>
        public static PTC_DC_TCON_6 getMessageDC_TCON_6(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TCON_6 dc_tcon = null;
            PTC_DC_TCON_6 ptc_dc_tcon = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TCON_6));
            
            file = getFilteredFile("DC-TCON", "6", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-TCON", "6", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TCON", "DC_TCON_6");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_tcon = (DC_TCON_6) serializer.Deserialize(stream);
                ptc_dc_tcon = PTC_DC_TCON_6.fromSerializableObject(dc_tcon);
            }
            
            return ptc_dc_tcon;
        }

        /// <summary>
        /// getMessageDC_TCON_7 retrieves a DC-TCON message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TCON_7</returns>
        public static PTC_DC_TCON_7 getMessageDC_TCON_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TCON_7 dc_tcon = null;
            PTC_DC_TCON_7 ptc_dc_tcon = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TCON_7));
            
            file = getFilteredFile("DC-TCON", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
			while (System.DateTime.Now < future && file == null)
			{
                file = getFilteredFile("DC-TCON", "7", filters, timeInSeconds+5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TCON", "DC_TCON_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_tcon = (DC_TCON_7) serializer.Deserialize(stream);
                ptc_dc_tcon = PTC_DC_TCON_7.fromSerializableObject(dc_tcon);
            }
            
            return ptc_dc_tcon;
        }

        /// <summary>
        /// getMessageDC_TLST_5 retrieves a DC-TLST message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TLST_5</returns>
        public static PTC_DC_TLST_5 getMessageDC_TLST_5(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TLST_5 dc_tlst = null;
            PTC_DC_TLST_5 ptc_dc_tlst = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TLST_5));
            
            file = getFilteredFile("DC-TLST", "5", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-TLST", "5", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TLST", "DC_TLST_5");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_tlst = (DC_TLST_5) serializer.Deserialize(stream);
                ptc_dc_tlst = PTC_DC_TLST_5.fromSerializableObject(dc_tlst);
            }
            
            return ptc_dc_tlst;
        }

        /// <summary>
        /// getMessageDC_TLST_7 retrieves a DC-TLST message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TLST_7</returns>
        public static PTC_DC_TLST_7 getMessageDC_TLST_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TLST_7 dc_tlst = null;
            PTC_DC_TLST_7 ptc_dc_tlst = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TLST_7));
            
            file = getFilteredFile("DC-TLST", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-TLST", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TLST", "DC_TLST_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_tlst = (DC_TLST_7) serializer.Deserialize(stream);
                ptc_dc_tlst = PTC_DC_TLST_7.fromSerializableObject(dc_tlst);
            }
            
            return ptc_dc_tlst;
        }

        /// <summary>
        /// getMessageDC_TRDL_2 retrieves a DC-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TRDL_2</returns>
        public static PTC_DC_TRDL_2 getMessageDC_TRDL_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TRDL_2 dc_trdl = null;
            PTC_DC_TRDL_2 ptc_dc_trdl = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TRDL_2));
            
            file = getFilteredFile("DC-TRDL", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-TRDL", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TRDL", "DC_TRDL_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_trdl = (DC_TRDL_2) serializer.Deserialize(stream);
                ptc_dc_trdl = PTC_DC_TRDL_2.fromSerializableObject(dc_trdl);
            }
            
            return ptc_dc_trdl;
        }

        /// <summary>
        /// getMessageDC_TRDL_7 retrieves a DC-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_TRDL_7</returns>
        public static PTC_DC_TRDL_7 getMessageDC_TRDL_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_TRDL_7 dc_trdl = null;
            PTC_DC_TRDL_7 ptc_dc_trdl = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_TRDL_7));
            
            file = getFilteredFile("DC-TRDL", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
            while (System.DateTime.Now < future && file == null) {
                file = getFilteredFile("DC-TRDL", "7", filters, timeInSeconds);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-TRDL", "DC_TRDL_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_trdl = (DC_TRDL_7) serializer.Deserialize(stream);
                ptc_dc_trdl = PTC_DC_TRDL_7.fromSerializableObject(dc_trdl);
            }
            
            return ptc_dc_trdl;
        }

        /// <summary>
        /// getMessageDC_VDME_2 retrieves a DC-VDME message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_VDME_2</returns>
        public static PTC_DC_VDME_2 getMessageDC_VDME_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_VDME_2 dc_vdme = null;
            PTC_DC_VDME_2 ptc_dc_vdme = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_VDME_2));
            
            file = getFilteredFile("DC-VDME", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-VDME", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-VDME", "DC_VDME_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_vdme = (DC_VDME_2) serializer.Deserialize(stream);
                ptc_dc_vdme = PTC_DC_VDME_2.fromSerializableObject(dc_vdme);
            }
            
            return ptc_dc_vdme;
        }

        /// <summary>
        /// getMessageDC_VDME_7 retrieves a DC-VDME message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_VDME_7</returns>
        public static PTC_DC_VDME_7 getMessageDC_VDME_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_VDME_7 dc_vdme = null;
            PTC_DC_VDME_7 ptc_dc_vdme = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_VDME_7));
            
            file = getFilteredFile("DC-VDME", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-VDME", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-VDME", "DC_VDME_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_vdme = (DC_VDME_7) serializer.Deserialize(stream);
                ptc_dc_vdme = PTC_DC_VDME_7.fromSerializableObject(dc_vdme);
            }
            
            return ptc_dc_vdme;
        }

        /// <summary>
        /// getMessageDC_DSSR_7 retrieves a DC-DSSR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DC_DSSR_7</returns>
        public static PTC_DC_DSSR_7 getMessageDC_DSSR_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DC_DSSR_7 dc_dssr = null;
            PTC_DC_DSSR_7 ptc_dc_dssr = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DC_DSSR_7));
            
            file = getFilteredFile("DC-DSSR", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DC-DSSR", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DC-DSSR", "DC_DSSR_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dc_dssr = (DC_DSSR_7) serializer.Deserialize(stream);
                ptc_dc_dssr = PTC_DC_DSSR_7.fromSerializableObject(dc_dssr);
            }
            
            return ptc_dc_dssr;
        }

        /// <summary>
        /// getMessageDG_AK01_2 retrieves a DG-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_AK01_2</returns>
        public static PTC_DG_AK01_2 getMessageDG_AK01_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_AK01_2 dg_ak01 = null;
            PTC_DG_AK01_2 ptc_dg_ak01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_AK01_2));
            
            file = getFilteredFile("DG-AK01", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-AK01", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-AK01", "DG_AK01_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_ak01 = (DG_AK01_2) serializer.Deserialize(stream);
                ptc_dg_ak01 = PTC_DG_AK01_2.fromSerializableObject(dg_ak01);
            }
            
            return ptc_dg_ak01;
        }

        /// <summary>
        /// getMessageDG_AK01_7 retrieves a DG-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_AK01_7</returns>
        public static PTC_DG_AK01_7 getMessageDG_AK01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_AK01_7 dg_ak01 = null;
            PTC_DG_AK01_7 ptc_dg_ak01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_AK01_7));
            
            file = getFilteredFile("DG-AK01", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-AK01", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-AK01", "DG_AK01_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_ak01 = (DG_AK01_7) serializer.Deserialize(stream);
                ptc_dg_ak01 = PTC_DG_AK01_7.fromSerializableObject(dg_ak01);
            }
            
            return ptc_dg_ak01;
        }

        /// <summary>
        /// getMessageDG_BULI_3 retrieves a DG-BULI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_BULI_3</returns>
        public static PTC_DG_BULI_3 getMessageDG_BULI_3(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_BULI_3 dg_buli = null;
            PTC_DG_BULI_3 ptc_dg_buli = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_BULI_3));
            
            file = getFilteredFile("DG-BULI", "3", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-BULI", "3", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-BULI", "DG_BULI_3");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_buli = (DG_BULI_3) serializer.Deserialize(stream);
                ptc_dg_buli = PTC_DG_BULI_3.fromSerializableObject(dg_buli);
            }
            
            return ptc_dg_buli;
        }

        /// <summary>
        /// getMessageDG_BULI_7 retrieves a DG-BULI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_BULI_7</returns>
        public static PTC_DG_BULI_7 getMessageDG_BULI_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_BULI_7 dg_buli = null;
            PTC_DG_BULI_7 ptc_dg_buli = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_BULI_7));
            
            file = getFilteredFile("DG-BULI", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-BULI", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-BULI", "DG_BULI_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_buli = (DG_BULI_7) serializer.Deserialize(stream);
                ptc_dg_buli = PTC_DG_BULI_7.fromSerializableObject(dg_buli);
            }
            
            return ptc_dg_buli;
        }

        /// <summary>
        /// getMessageDG_KA01_2 retrieves a DG-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_KA01_2</returns>
        public static PTC_DG_KA01_2 getMessageDG_KA01_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_KA01_2 dg_ka01 = null;
            PTC_DG_KA01_2 ptc_dg_ka01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_KA01_2));
            
            file = getFilteredFile("DG-KA01", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-KA01", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-KA01", "DG_KA01_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_ka01 = (DG_KA01_2) serializer.Deserialize(stream);
                ptc_dg_ka01 = PTC_DG_KA01_2.fromSerializableObject(dg_ka01);
            }
            
            return ptc_dg_ka01;
        }

        /// <summary>
        /// getMessageDG_KA01_7 retrieves a DG-KA01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_KA01_7</returns>
        public static PTC_DG_KA01_7 getMessageDG_KA01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_KA01_7 dg_ka01 = null;
            PTC_DG_KA01_7 ptc_dg_ka01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_KA01_7));
            
            file = getFilteredFile("DG-KA01", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-KA01", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-KA01", "DG_KA01_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_ka01 = (DG_KA01_7) serializer.Deserialize(stream);
                ptc_dg_ka01 = PTC_DG_KA01_7.fromSerializableObject(dg_ka01);
            }
            
            return ptc_dg_ka01;
        }

        /// <summary>
        /// getMessageDG_SGCN_2 retrieves a DG-SGCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGCN_2</returns>
        public static PTC_DG_SGCN_2 getMessageDG_SGCN_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGCN_2 dg_sgcn = null;
            PTC_DG_SGCN_2 ptc_dg_sgcn = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGCN_2));
            
            file = getFilteredFile("DG-SGCN", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SGCN", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SGCN", "DG_SGCN_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sgcn = (DG_SGCN_2) serializer.Deserialize(stream);
                ptc_dg_sgcn = PTC_DG_SGCN_2.fromSerializableObject(dg_sgcn);
            }
            
            return ptc_dg_sgcn;
        }

        /// <summary>
        /// getMessageDG_SGCN_7 retrieves a DG-SGCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGCN_7</returns>
        public static PTC_DG_SGCN_7 getMessageDG_SGCN_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGCN_7 dg_sgcn = null;
            PTC_DG_SGCN_7 ptc_dg_sgcn = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGCN_7));
            
            file = getFilteredFile("DG-SGCN", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SGCN", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SGCN", "DG_SGCN_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sgcn = (DG_SGCN_7) serializer.Deserialize(stream);
                ptc_dg_sgcn = PTC_DG_SGCN_7.fromSerializableObject(dg_sgcn);
            }
            
            return ptc_dg_sgcn;
        }

        /// <summary>
        /// getMessageDG_SGIN_2 retrieves a DG-SGIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGIN_2</returns>
        public static PTC_DG_SGIN_2 getMessageDG_SGIN_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGIN_2 dg_sgin = null;
            PTC_DG_SGIN_2 ptc_dg_sgin = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGIN_2));
            
            file = getFilteredFile("DG-SGIN", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SGIN", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SGIN", "DG_SGIN_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sgin = (DG_SGIN_2) serializer.Deserialize(stream);
                ptc_dg_sgin = PTC_DG_SGIN_2.fromSerializableObject(dg_sgin);
            }
            
            return ptc_dg_sgin;
        }

        /// <summary>
        /// getMessageDG_SGIN_7 retrieves a DG-SGIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SGIN_7</returns>
        public static PTC_DG_SGIN_7 getMessageDG_SGIN_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SGIN_7 dg_sgin = null;
            PTC_DG_SGIN_7 ptc_dg_sgin = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SGIN_7));
            
            file = getFilteredFile("DG-SGIN", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SGIN", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SGIN", "DG_SGIN_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sgin = (DG_SGIN_7) serializer.Deserialize(stream);
                ptc_dg_sgin = PTC_DG_SGIN_7.fromSerializableObject(dg_sgin);
            }
            
            return ptc_dg_sgin;
        }

        /// <summary>
        /// getMessageDG_SWCN_2 retrieves a DG-SWCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWCN_2</returns>
        public static PTC_DG_SWCN_2 getMessageDG_SWCN_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWCN_2 dg_swcn = null;
            PTC_DG_SWCN_2 ptc_dg_swcn = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWCN_2));
            
            file = getFilteredFile("DG-SWCN", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SWCN", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SWCN", "DG_SWCN_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_swcn = (DG_SWCN_2) serializer.Deserialize(stream);
                ptc_dg_swcn = PTC_DG_SWCN_2.fromSerializableObject(dg_swcn);
            }
            
            return ptc_dg_swcn;
        }

        /// <summary>
        /// getMessageDG_SWCN_7 retrieves a DG-SWCN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWCN_7</returns>
        public static PTC_DG_SWCN_7 getMessageDG_SWCN_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWCN_7 dg_swcn = null;
            PTC_DG_SWCN_7 ptc_dg_swcn = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWCN_7));
            
            file = getFilteredFile("DG-SWCN", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SWCN", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SWCN", "DG_SWCN_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_swcn = (DG_SWCN_7) serializer.Deserialize(stream);
                ptc_dg_swcn = PTC_DG_SWCN_7.fromSerializableObject(dg_swcn);
            }
            
            return ptc_dg_swcn;
        }

        /// <summary>
        /// getMessageDG_SWIN_2 retrieves a DG-SWIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWIN_2</returns>
        public static PTC_DG_SWIN_2 getMessageDG_SWIN_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWIN_2 dg_swin = null;
            PTC_DG_SWIN_2 ptc_dg_swin = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWIN_2));
            
            file = getFilteredFile("DG-SWIN", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SWIN", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SWIN", "DG_SWIN_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_swin = (DG_SWIN_2) serializer.Deserialize(stream);
                ptc_dg_swin = PTC_DG_SWIN_2.fromSerializableObject(dg_swin);
            }
            
            return ptc_dg_swin;
        }

        /// <summary>
        /// getMessageDG_SWIN_7 retrieves a DG-SWIN message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SWIN_7</returns>
        public static PTC_DG_SWIN_7 getMessageDG_SWIN_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SWIN_7 dg_swin = null;
            PTC_DG_SWIN_7 ptc_dg_swin = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SWIN_7));
            
            file = getFilteredFile("DG-SWIN", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SWIN", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SWIN", "DG_SWIN_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_swin = (DG_SWIN_7) serializer.Deserialize(stream);
                ptc_dg_swin = PTC_DG_SWIN_7.fromSerializableObject(dg_swin);
            }
            
            return ptc_dg_swin;
        }

        /// <summary>
        /// getMessageDG_SY01_2 retrieves a DG-SY01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SY01_2</returns>
        public static PTC_DG_SY01_2 getMessageDG_SY01_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SY01_2 dg_sy01 = null;
            PTC_DG_SY01_2 ptc_dg_sy01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SY01_2));
            
            file = getFilteredFile("DG-SY01", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SY01", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SY01", "DG_SY01_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sy01 = (DG_SY01_2) serializer.Deserialize(stream);
                ptc_dg_sy01 = PTC_DG_SY01_2.fromSerializableObject(dg_sy01);
            }
            
            return ptc_dg_sy01;
        }

        /// <summary>
        /// getMessageDG_SY01_7 retrieves a DG-SY01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_SY01_7</returns>
        public static PTC_DG_SY01_7 getMessageDG_SY01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_SY01_7 dg_sy01 = null;
            PTC_DG_SY01_7 ptc_dg_sy01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_SY01_7));
            
            file = getFilteredFile("DG-SY01", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-SY01", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-SY01", "DG_SY01_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_sy01 = (DG_SY01_7) serializer.Deserialize(stream);
                ptc_dg_sy01 = PTC_DG_SY01_7.fromSerializableObject(dg_sy01);
            }
            
            return ptc_dg_sy01;
        }

        /// <summary>
        /// getMessageDG_TAUT_3 retrieves a DG-TAUT message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TAUT_3</returns>
        public static PTC_DG_TAUT_3 getMessageDG_TAUT_3(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TAUT_3 dg_taut = null;
            PTC_DG_TAUT_3 ptc_dg_taut = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TAUT_3));
            
            file = getFilteredFile("DG-TAUT", "3", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-TAUT", "3", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-TAUT", "DG_TAUT_3");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_taut = (DG_TAUT_3) serializer.Deserialize(stream);
                ptc_dg_taut = PTC_DG_TAUT_3.fromSerializableObject(dg_taut);
            }
            
            return ptc_dg_taut;
        }

        /// <summary>
        /// getMessageDG_TAUT_7 retrieves a DG-TAUT message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TAUT_7</returns>
        public static PTC_DG_TAUT_7 getMessageDG_TAUT_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TAUT_7 dg_taut = null;
            PTC_DG_TAUT_7 ptc_dg_taut = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TAUT_7));
            
            file = getFilteredFile("DG-TAUT", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-TAUT", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-TAUT", "DG_TAUT_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_taut = (DG_TAUT_7) serializer.Deserialize(stream);
                ptc_dg_taut = PTC_DG_TAUT_7.fromSerializableObject(dg_taut);
            }
            
            return ptc_dg_taut;
        }

        /// <summary>
        /// getMessageDG_TRDL_2 retrieves a DG-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TRDL_2</returns>
        public static PTC_DG_TRDL_2 getMessageDG_TRDL_2(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TRDL_2 dg_trdl = null;
            PTC_DG_TRDL_2 ptc_dg_trdl = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TRDL_2));
            
            file = getFilteredFile("DG-TRDL", "2", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-TRDL", "2", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-TRDL", "DG_TRDL_2");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_trdl = (DG_TRDL_2) serializer.Deserialize(stream);
                ptc_dg_trdl = PTC_DG_TRDL_2.fromSerializableObject(dg_trdl);
            }
            
            return ptc_dg_trdl;
        }

        /// <summary>
        /// getMessageDG_TRDL_7 retrieves a DG-TRDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_TRDL_7</returns>
        public static PTC_DG_TRDL_7 getMessageDG_TRDL_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_TRDL_7 dg_trdl = null;
            PTC_DG_TRDL_7 ptc_dg_trdl = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_TRDL_7));
            
            file = getFilteredFile("DG-TRDL", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-TRDL", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-TRDL", "DG_TRDL_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_trdl = (DG_TRDL_7) serializer.Deserialize(stream);
                ptc_dg_trdl = PTC_DG_TRDL_7.fromSerializableObject(dg_trdl);
            }
            
            return ptc_dg_trdl;
        }

        /// <summary>
        /// getMessageDG_UDIE_5 retrieves a DG-UDIE message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_UDIE_5</returns>
        public static PTC_DG_UDIE_5 getMessageDG_UDIE_5(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_UDIE_5 dg_udie = null;
            PTC_DG_UDIE_5 ptc_dg_udie = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_UDIE_5));
            
            file = getFilteredFile("DG-UDIE", "5", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-UDIE", "5", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-UDIE", "DG_UDIE_5");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_udie = (DG_UDIE_5) serializer.Deserialize(stream);
                ptc_dg_udie = PTC_DG_UDIE_5.fromSerializableObject(dg_udie);
            }
            
            return ptc_dg_udie;
        }
        
        /// <summary>
        /// getMessageMQ_ERROR retrieves a MQ_ERROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>bool</returns>
        public static PTC_MQ_ERROR_1 getMessageMQ_ERROR(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MQ_ERROR_1 mq_error = null;
            PTC_MQ_ERROR_1 ptc_mq_error = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MQ_ERROR_1));
            
            file = getFilteredFile("MQ_ERROR", "", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("MQ_ERROR", "", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                //updateMessageHeader(file, "ERROR", "MQ_ERROR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                mq_error = (MQ_ERROR_1) serializer.Deserialize(stream);
                ptc_mq_error = PTC_MQ_ERROR_1.fromSerializableObject(mq_error);
                stream.Close();
                
            }
            
            return ptc_mq_error;
        }

        /// <summary>
        /// getMessageDG_UDIE_7 retrieves a DG-UDIE message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_UDIE_7</returns>
        public static PTC_DG_UDIE_7 getMessageDG_UDIE_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_UDIE_7 dg_udie = null;
            PTC_DG_UDIE_7 ptc_dg_udie = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_UDIE_7));
            
            file = getFilteredFile("DG-UDIE", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-UDIE", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-UDIE", "DG_UDIE_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_udie = (DG_UDIE_7) serializer.Deserialize(stream);
                ptc_dg_udie = PTC_DG_UDIE_7.fromSerializableObject(dg_udie);
            }
            
            return ptc_dg_udie;
        }

        /// <summary>
        /// getMessageDG_VDBI_4 retrieves a DG-VDBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_VDBI_4</returns>
        public static PTC_DG_VDBI_4 getMessageDG_VDBI_4(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_VDBI_4 dg_vdbi = null;
            PTC_DG_VDBI_4 ptc_dg_vdbi = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_VDBI_4));
            
            file = getFilteredFile("DG-VDBI", "4", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-VDBI", "4", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-VDBI", "DG_VDBI_4");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_vdbi = (DG_VDBI_4) serializer.Deserialize(stream);
                ptc_dg_vdbi = PTC_DG_VDBI_4.fromSerializableObject(dg_vdbi);
            }
            
            return ptc_dg_vdbi;
        }

        /// <summary>
        /// getMessageDG_VDBI_7 retrieves a DG-VDBI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_VDBI_7</returns>
        public static PTC_DG_VDBI_7 getMessageDG_VDBI_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_VDBI_7 dg_vdbi = null;
            PTC_DG_VDBI_7 ptc_dg_vdbi = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_VDBI_7));
            
            file = getFilteredFile("DG-VDBI", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-VDBI", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-VDBI", "DG_VDBI_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_vdbi = (DG_VDBI_7) serializer.Deserialize(stream);
                ptc_dg_vdbi = PTC_DG_VDBI_7.fromSerializableObject(dg_vdbi);
            }
            
            return ptc_dg_vdbi;
        }

        /// <summary>
        /// getMessageDG_DSSR_7 retrieves a DG-DSSR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_DG_DSSR_7</returns>
        public static PTC_DG_DSSR_7 getMessageDG_DSSR_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DG_DSSR_7 dg_dssr = null;
            PTC_DG_DSSR_7 ptc_dg_dssr = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DG_DSSR_7));
            
            file = getFilteredFile("DG-DSSR", "7", filters, timeInSeconds);
            
            System.DateTime future = System.DateTime.Now.AddSeconds(timeInSeconds);
				while (System.DateTime.Now < future && file == null)
				{
                file = getFilteredFile("DG-DSSR", "7", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DG-DSSR", "DG_DSSR_7");
                FileStream stream = new FileStream(file, FileMode.Open);
                dg_dssr = (DG_DSSR_7) serializer.Deserialize(stream);
                ptc_dg_dssr = PTC_DG_DSSR_7.fromSerializableObject(dg_dssr);
            }
            
            return ptc_dg_dssr;
        }
        
        /// <summary>
        /// getMessageGD_RTDL_7 retrieves a DG-DSSR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_GD_RTDL_7</returns>
        public static bool getMessageGD_RTDL_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            string file = getFilteredFile("GD-RTDL", "7", filters, timeInSeconds);
            if (file != null) {
            	return true;
            }
            return false;
        }
        
        /// <summary>
        /// getMessageGD_AK01_7 retrieves a GD-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_GD_AK01_7</returns>
        public static bool getMessageGD_AK01_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            string file = getFilteredFile("GD-AK01", "7", filters, timeInSeconds);
            if (file != null) {
            	return true;
            }
            return false;
        }
        

        /// <summary>
        /// getMessageCD_RTDL_7 retrieves a CD-RTDL message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>PTC_GD_RTDL_7</returns>
        public static bool getMessageCD_RTDL_7(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            string file = getFilteredFile("CD-RTDL", "7", filters, timeInSeconds);
            if (file != null) {
            	return true;
            }
            return false;
        }
        
        
        
                /// <summary>
        /// getMessageDR_EROR_1 retrieves a DR-EROR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_EROR_1</returns>
        public static RUM_DR_EROR_1 getMessageDR_EROR_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_EROR_1 dr_eror = null;
            RUM_DR_EROR_1 rum_dr_eror = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_EROR_1));
            
            file = getFilteredFile("DR-EROR", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-EROR", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-EROR", "DR_EROR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_eror = (DR_EROR_1) serializer.Deserialize(stream);
                rum_dr_eror = RUM_DR_EROR_1.fromSerializableObject(dr_eror);
            }
            
            return rum_dr_eror;
        }

        /// <summary>
        /// getMessageDR_TAUT_1 retrieves a DR-TAUT message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_TAUT_1</returns>
        public static RUM_DR_TAUT_1 getMessageDR_TAUT_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_TAUT_1 dr_taut = null;
            RUM_DR_TAUT_1 rum_dr_taut = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_TAUT_1));
            file = getFilteredFile("DR-TAUT", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-TAUT", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-TAUT", "DR_TAUT_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_taut = (DR_TAUT_1) serializer.Deserialize(stream);
                rum_dr_taut = RUM_DR_TAUT_1.fromSerializableObject(dr_taut);
            }
            
            return rum_dr_taut;
        }

        /// <summary>
        /// getMessageDR_RTED_1 retrieves a DR-RTED message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_RTED_1</returns>
        public static RUM_DR_RTED_1 getMessageDR_RTED_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_RTED_1 dr_rted = null;
            RUM_DR_RTED_1 rum_dr_rted = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_RTED_1));
            
            file = getFilteredFile("DR-RTED", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-RTED", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-RTED", "DR_RTED_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_rted = (DR_RTED_1) serializer.Deserialize(stream);
                rum_dr_rted = RUM_DR_RTED_1.fromSerializableObject(dr_rted);
            }
            
            return rum_dr_rted;
        }

        /// <summary>
        /// getMessageDR_AK01_1 retrieves a DR-AK01 message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_AK01_1</returns>
        public static RUM_DR_AK01_1 getMessageDR_AK01_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_AK01_1 dr_ak01 = null;
            RUM_DR_AK01_1 rum_dr_ak01 = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_AK01_1));
            
            file = getFilteredFile("DR-AK01", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-AK01", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-AK01", "DR_AK01_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_ak01 = (DR_AK01_1) serializer.Deserialize(stream);
                rum_dr_ak01 = RUM_DR_AK01_1.fromSerializableObject(dr_ak01);
            }
            
            return rum_dr_ak01;
        }

        /// <summary>
        /// getMessageDR_BICD_1 retrieves a DR-BICD message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_BICD_1</returns>
        public static RUM_DR_BICD_1 getMessageDR_BICD_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_BICD_1 dr_bicd = null;
            RUM_DR_BICD_1 rum_dr_bicd = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_BICD_1));
            
            file = getFilteredFile("DR-BICD", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-BICD", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-BICD", "DR_BICD_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_bicd = (DR_BICD_1) serializer.Deserialize(stream);
                rum_dr_bicd = RUM_DR_BICD_1.fromSerializableObject(dr_bicd);
            }
            
            return rum_dr_bicd;
        }

        /// <summary>
        /// getMessageDR_BICR_1 retrieves a DR-BICR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_BICR_1</returns>
        public static RUM_DR_BICR_1 getMessageDR_BICR_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_BICR_1 dr_bicr = null;
            RUM_DR_BICR_1 rum_dr_bicr = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_BICR_1));
            
            file = getFilteredFile("DR-BICR", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-BICR", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-BICR", "DR_BICR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_bicr = (DR_BICR_1) serializer.Deserialize(stream);
                rum_dr_bicr = RUM_DR_BICR_1.fromSerializableObject(dr_bicr);
            }
            
            return rum_dr_bicr;
        }

        /// <summary>
        /// getMessageDR_BIVA_1 retrieves a DR-BIVA message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_BIVA_1</returns>
        public static RUM_DR_BIVA_1 getMessageDR_BIVA_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_BIVA_1 dr_biva = null;
            RUM_DR_BIVA_1 rum_dr_biva = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_BIVA_1));
            
            file = getFilteredFile("DR-BIVA", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-BIVA", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-BIVA", "DR_BIVA_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_biva = (DR_BIVA_1) serializer.Deserialize(stream);
                rum_dr_biva = RUM_DR_BIVA_1.fromSerializableObject(dr_biva);
            }
            
            return rum_dr_biva;
        }

        /// <summary>
        /// getMessageDR_BIVD_1 retrieves a DR-BIVD message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_BIVD_1</returns>
        public static RUM_DR_BIVD_1 getMessageDR_BIVD_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_BIVD_1 dr_bivd = null;
            RUM_DR_BIVD_1 rum_dr_bivd = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_BIVD_1));
            
            file = getFilteredFile("DR-BIVD", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-BIVD", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-BIVD", "DR_BIVD_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_bivd = (DR_BIVD_1) serializer.Deserialize(stream);
                rum_dr_bivd = RUM_DR_BIVD_1.fromSerializableObject(dr_bivd);
            }
            
            return rum_dr_bivd;
        }

        /// <summary>
        /// getMessageDR_BULI_1 retrieves a DR-BULI message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_BULI_1</returns>
        public static RUM_DR_BULI_1 getMessageDR_BULI_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_BULI_1 dr_buli = null;
            RUM_DR_BULI_1 rum_dr_buli = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_BULI_1));
            
            file = getFilteredFile("DR-BULI", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-BULI", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-BULI", "DR_BULI_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_buli = (DR_BULI_1) serializer.Deserialize(stream);
                rum_dr_buli = RUM_DR_BULI_1.fromSerializableObject(dr_buli);
            }
            
            return rum_dr_buli;
        }

        /// <summary>
        /// getMessageDR_PTUR_1 retrieves a DR-PTUR message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_PTUR_1</returns>
        public static RUM_DR_PTUR_1 getMessageDR_PTUR_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_PTUR_1 dr_ptur = null;
            RUM_DR_PTUR_1 rum_dr_ptur = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_PTUR_1));
            
            file = getFilteredFile("DR-PTUR", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-PTUR", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-PTUR", "DR_PTUR_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_ptur = (DR_PTUR_1) serializer.Deserialize(stream);
                rum_dr_ptur = RUM_DR_PTUR_1.fromSerializableObject(dr_ptur);
            }
            
            return rum_dr_ptur;
        }

        /// <summary>
        /// getMessageDR_RTCD_1 retrieves a DR-RTCD message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_RTCD_1</returns>
        public static RUM_DR_RTCD_1 getMessageDR_RTCD_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_RTCD_1 dr_rtcd = null;
            RUM_DR_RTCD_1 rum_dr_rtcd = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_RTCD_1));
            
            file = getFilteredFile("DR-RTCD", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-RTCD", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-RTCD", "DR_RTCD_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_rtcd = (DR_RTCD_1) serializer.Deserialize(stream);
                rum_dr_rtcd = RUM_DR_RTCD_1.fromSerializableObject(dr_rtcd);
            }
            
            return rum_dr_rtcd;
        }

        /// <summary>
        /// getMessageDR_RTRD_1 retrieves a DR-RTRD message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_RTRD_1</returns>
        public static RUM_DR_RTRD_1 getMessageDR_RTRD_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_RTRD_1 dr_rtrd = null;
            RUM_DR_RTRD_1 rum_dr_rtrd = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_RTRD_1));
            
            file = getFilteredFile("DR-RTRD", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-RTRD", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-RTRD", "DR_RTRD_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_rtrd = (DR_RTRD_1) serializer.Deserialize(stream);
                rum_dr_rtrd = RUM_DR_RTRD_1.fromSerializableObject(dr_rtrd);
            }
            
            return rum_dr_rtrd;
        }

        /// <summary>
        /// getMessageDR_RTVD_1 retrieves a DR-RTVD message that contains the listed filters, in x seconds.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="timeInSeconds"></param>
        /// <param name="retry"></param>
        /// <returns>RUM_DR_RTVD_1</returns>
        public static RUM_DR_RTVD_1 getMessageDR_RTVD_1(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            DR_RTVD_1 dr_rtvd = null;
            RUM_DR_RTVD_1 rum_dr_rtvd = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DR_RTVD_1));
            
            file = getFilteredFile("DR-RTVD", "1", filters, timeInSeconds);
            
            if (file == null && retry)
            {
                Thread.Sleep(5000);
                file = getFilteredFile("DR-RTVD", "1", filters, timeInSeconds + 5);
            }

            if (file != null)
            {
                updateMessageHeader(file, "DR-RTVD", "DR_RTVD_1");
                FileStream stream = new FileStream(file, FileMode.Open);
                dr_rtvd = (DR_RTVD_1) serializer.Deserialize(stream);
                rum_dr_rtvd = RUM_DR_RTVD_1.fromSerializableObject(dr_rtvd);
            }
            
            return rum_dr_rtvd;
        }


        
        public static MIS.NS.MIS_NS_RemedyBulletin_48 getRemedyBulletinMessageContent_NS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
            MIS.NS.NS_RemedyBulletin_48 remedyBulletinMessage = null;
        	MIS.NS.MIS_NS_RemedyBulletin_48 mis_remedyBulletinMessage = null;
        	string file = null;
        	XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_RemedyBulletin_48));
        	file = getFilteredFile_MIS("RemedyBulletin", filters, timeInSeconds);
        	if (file != null)
        	{
        		FileStream stream = new FileStream(file, FileMode.Open);
        		remedyBulletinMessage = (MIS.NS.NS_RemedyBulletin_48) serializer.Deserialize(stream);
        		mis_remedyBulletinMessage = MIS.NS.MIS_NS_RemedyBulletin_48.fromSerializableObject(remedyBulletinMessage);

        	}

        	return mis_remedyBulletinMessage;
        }
        
        public static MIS.NS.MIS_ExternalAlertEvent getExternalAlertEventContent_NS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
        	MIS.NS.ExternalAlertEvent externalAlertEventMessage = null;
        	MIS.NS.MIS_ExternalAlertEvent misExternalAlertEventMessage = null;
        	string file = null;
        	XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.ExternalAlertEvent));
        	file = getFilteredFile_MIS("ExternalAlertEvent", filters, timeInSeconds);
        	
        	if(file == null && retry)
        	{
        		Thread.Sleep(5000);
        		file = getFilteredFile_MIS("ExternalAlertEvent", filters, timeInSeconds + 5);
        	}
        	
        	if(file != null)
        	{
        		Ranorex.Report.Info("Found File");
        		FileStream stream = new FileStream(file, FileMode.Open);
        		externalAlertEventMessage = (MIS.NS.ExternalAlertEvent) serializer.Deserialize(stream);
        		misExternalAlertEventMessage = MIS.NS.MIS_ExternalAlertEvent.fromSerializableObject(externalAlertEventMessage);
        	}
        	return misExternalAlertEventMessage;
        }

        public static MIS.NS.MIS_NS_EngineConsist_48 GetEngineConsistMessageContent_NS(string[] filters = null, int timeInSeconds = 5, bool retry = true)
        {
            MIS.NS.NS_EngineConsist_48 engineConsistMessage = null;
            MIS.NS.MIS_NS_EngineConsist_48 mis_engineConsistMessage = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_EngineConsist_48));
            file = getFilteredFile_MIS("EngineConsist", filters, timeInSeconds);
            if (file != null)
            {
                FileStream stream = new FileStream(file, FileMode.Open);
                engineConsistMessage = (MIS.NS.NS_EngineConsist_48)serializer.Deserialize(stream);
                mis_engineConsistMessage = MIS.NS.MIS_NS_EngineConsist_48.fromSerializableObject(engineConsistMessage);
                stream.Close();
            }
            return mis_engineConsistMessage;
        }

        public static MIS.NS.MIS_NS_EOTCaboose_48 GetEotCabooseMessageContent_NS(string[] filters = null, int timeInSeconds = 5, bool retry = true)
        {
            MIS.NS.NS_EOTCaboose_48 eotCabooseMessage = null;
            MIS.NS.MIS_NS_EOTCaboose_48 mis_eotCabooseMessage = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_EOTCaboose_48));
            file = getFilteredFile_MIS("EOTCaboose", filters, timeInSeconds);
            if (file != null)
            {
                FileStream stream = new FileStream(file, FileMode.Open);
                eotCabooseMessage = (MIS.NS.NS_EOTCaboose_48)serializer.Deserialize(stream);
                mis_eotCabooseMessage = MIS.NS.MIS_NS_EOTCaboose_48.fromSerializableObject(eotCabooseMessage);
            }
            return mis_eotCabooseMessage;
        }

        public static MIS.NS.MIS_NS_CrewMember_48 GetCrewMemberMessageContent_NS(string[] filters = null, int timeInSeconds = 5, bool retry = true)
        {
            MIS.NS.NS_CrewMember_48 crewMemberMessage = null;
            MIS.NS.MIS_NS_CrewMember_48 mis_crewMemberMessage = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_CrewMember_48));
            file = getFilteredFile_MIS("CrewMember", filters, timeInSeconds);
            if (file != null)
            {
                FileStream stream = new FileStream(file, FileMode.Open);
                crewMemberMessage = (MIS.NS.NS_CrewMember_48)serializer.Deserialize(stream);
                mis_crewMemberMessage = MIS.NS.MIS_NS_CrewMember_48.fromSerializableObject(crewMemberMessage);
            }
            return mis_crewMemberMessage;
        }
        
        public static MIS.NS.MIS_NS_TrainConsistActivity_48 GetTrainConsistActivityMessageContent_NS(string[] filters = null, int timeInSeconds = 5, bool retry = true)
        {
            MIS.NS.NS_TrainConsistActivity_48 tcamMessage = null;
            MIS.NS.MIS_NS_TrainConsistActivity_48 mis_tcamMessage = null;
            string file = null;
            XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_TrainConsistActivity_48));
            file = getFilteredFile_MIS("TrainConsistActivity", filters, timeInSeconds);
            if (file != null)
            {
                FileStream stream = new FileStream(file, FileMode.Open);
                tcamMessage = (MIS.NS.NS_TrainConsistActivity_48)serializer.Deserialize(stream);
                mis_tcamMessage = MIS.NS.MIS_NS_TrainConsistActivity_48.fromSerializableObject(tcamMessage);
            }
            return mis_tcamMessage;
        }

        public static MIS.NS.MIS_NS_TrainConsistSummary_43 getTrainConsistMessageContent_NS(string[] filters=null, int timeInSeconds=5, bool retry=true)
        {
        	MIS.NS.NS_TrainConsistSummary_43 trainConsistMessage = null;
        	MIS.NS.MIS_NS_TrainConsistSummary_43 mis_trainConsistMessage = null;
        	string file = null;
        	XmlSerializer serializer = new XmlSerializer(typeof(MIS.NS.NS_TrainConsistSummary_43));
        	file = getFilteredFile_MIS("TrainConsistSummary", filters, timeInSeconds);
        	if (file != null)
        	{
        		FileStream stream = new FileStream(file, FileMode.Open);
        		trainConsistMessage = (MIS.NS.NS_TrainConsistSummary_43) serializer.Deserialize(stream);
        		mis_trainConsistMessage = MIS.NS.MIS_NS_TrainConsistSummary_43.fromSerializableObject(trainConsistMessage);

        	}

        	return mis_trainConsistMessage;
        }
    }
}