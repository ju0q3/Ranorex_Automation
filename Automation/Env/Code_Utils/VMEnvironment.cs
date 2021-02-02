/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/11/2017
 * Time: 2:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;


using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;


namespace Env.Code_Utils
{
    /// <summary>
    /// Description of VMEnvironment.
    /// </summary>
    public sealed class VMEnvironment
    {
        private static VMEnvironment instance;
        
        public string computer;
        public string ste;
        public string server;
        public string user;
        public string dbUser;
        public string dbPw;
        public string domain;
        public string ipAddress;
        public string vncPw;
        public string project;  //NS, CN, other	
        public string port;
        public string lastLabel;
        public string wapServer;
        public string pdsUser;
        
        public string baseDir;
        public string baseCoreDir;
        public string userTempDirectory = System.Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Temp\automation\");

        public static VMEnvironment Instance()
        {
            if (instance == null)
            {
                instance = new VMEnvironment();
            }
            return instance;
        }
        
        private VMEnvironment()
        {
            findBaseDirectory();
            loadVMEnvironment();
        }
        
        private int loadVMEnvironment()
        {
            string computerName = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
         
            string line;
            string[] variables = null;
            
            string vmDir = baseCoreDir+@"Data/Environment/VMEnvironment.csv";
            
            if (!File.Exists(userTempDirectory+@"launcher_last_label_name.txt")) {
            	if (!Directory.Exists(userTempDirectory)) {
            		Directory.CreateDirectory(userTempDirectory);
            	}
            	System.IO.File.Create(userTempDirectory+@"launcher_last_label_name.txt");
				lastLabel = "Not_Applicable";
			} else {
				lastLabel = System.IO.File.ReadAllText(userTempDirectory+@"launcher_last_label_name.txt");
			}
            
            
            System.IO.StreamReader executionList = new System.IO.StreamReader(@vmDir);
            while((line = executionList.ReadLine()) != null)
            {
            	char[] delimiters = new Char[] { ',' };
                variables = line.Split(delimiters);
                if (variables[0].Equals(computerName))
                {
                    computer  = variables[0];
                    ste       = variables[1].Remove(0,4);
                    server    = variables[2];
                    user      = variables[3];
                    domain    = variables[4];
                    ipAddress = variables[5];
                    dbUser 	  =	variables[6];
                    dbPw      = variables[7];
                    vncPw     = variables[8];
                    project   = variables[9];
                    port      = variables[10];
                    wapServer = variables[11];
                    pdsUser   = variables[12];
                    
                    
                  
                    break;
                }
            }
            executionList.Close();
            
            if (variables == null)
            {
                return 1;
            }
            
            return 0;
        }
        
        private void findBaseDirectory()
        {
        	string path = Directory.GetCurrentDirectory();
        	baseCoreDir = path+@"\";
		}
    }
}
