/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/13/2017
 * Time: 8:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using Ranorex;
using Env.Code_Utils;

namespace PDS_CORE.Code_Utils
{
	/// <summary>
	/// Description of StartPDS.
	/// </summary>
	public class StartPDSUtils
	{
		public StartPDSUtils()
		{
		}
		
		
		public static void preparePDS(string labelName, string db, string type="Label")
		{
			VMEnvironment vm = VMEnvironment.Instance();
			
			Report.Info("Running prepcurrentview.sh");
			LinuxUtils.runStartupScript(vm,"prepcurrentview.sh",labelName,db,type); //Create View
			Report.Info("Running createPds.sh");
			LinuxUtils.runStartupScript(vm,"createPds.sh",labelName,db,type); //createPds DB connection
			
			if (!type.Equals("Existing"))
			{
			    Report.Info("Running winkview.sh");
			    LinuxUtils.runStartupScript(vm,"winkview.sh",labelName,db,type); //winkbuild
			}
			Report.Info("Running startview.sh");
			LinuxUtils.runStartupScript(vm,"startview.sh",labelName,db,type); //Start View
			
			//Update user temp directory with last started view and last DB
         	System.IO.File.WriteAllText(vm.userTempDirectory+"launcher_last_label_name.txt",labelName);
         	System.IO.File.WriteAllText(vm.userTempDirectory+"launcher_last_db_name.txt",db);
		}
	}
}
