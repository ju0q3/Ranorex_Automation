/*
 * Created by Ranorex
 * User: 503036149
 * Date: 8/13/2019
 * Time: 1:54 PM
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
using System.IO;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_CCOP
    {
        [UserCodeMethod]
        public static bool searchCCOPLogFile(string textToSearch)
        {
        	bool foundMatch = false;
        	//StreamReader file = new StreamReader();
        	if(File.Exists("C:\\cygwin64\\home\\r07000021\\output.log"))
        	{
        		string[] text = File.ReadAllLines("C:\\cygwin64\\home\\r07000021\\output.log");
        		Regex stringToSearch = new Regex(textToSearch);
        		foreach (string Line in text)
        		{
        			if(stringToSearch.IsMatch(Line))
        			{
        				Ranorex.Report.Info("Line found: " +Line);
        				foundMatch = true;
        				break;
        			}
        		}
			}
        	else
        	{
        		Ranorex.Report.Failure(@"File not found in directory: C:\cygwin64\home\r07000021");
        	}
        	
        	return foundMatch;
        }
        
        [UserCodeMethod]
        public static void latestLogFileName(string fromTime, string toTime, string textToSearch)
        {
        	fromTime = "["+fromTime;
        	toTime = "["+toTime;
        	Ranorex.Report.Info(Env.Code_Utils.LinuxUtils.getCCOPLog_Betweentimestamp(fromTime, toTime));
        	
        	Validate.IsTrue(searchCCOPLogFile(textToSearch));
        }
    }
}
