/*
 * Created by Ranorex
 * User: 503000062
 * Date: 10/2/2018
 * Time: 11:48 AM
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

namespace PDS_CORE.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class invokePDSUI
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
       
        /// <summary>
		/// This function invokes the PDS UI batch file [PDS or MOW] present at C:\PDS_SIM
		/// </summary>
		/// <param name="waitFor">Input: Repo Item to check the existence of Network Logon Form</param>
		/// <param name="batType">Input: Batch File Type: PDS or MOW</param>
		[UserCodeMethod]
		public static void invokeBatPDSUI(Ranorex.Core.Repository.RepoItemInfo waitFor, String batType)
		{
			var repo = PDS_CORERepository.Instance;
				
			Delay.Milliseconds(15000);
			
			if(waitFor.Exists(1000))
			{
				repo.NetworkLogon.Close.Click();
				repo.Form_WarningBox.buttonYes.Click();
				Delay.Milliseconds(10000);
			}
			
			try
			{
				while(!waitFor.Exists(1000))
				{
					if(batType == "PDS" | batType == "MOW")
					{
						Host.Local.RunApplication("C:\\PDS_SIM\\lastPDS_" + batType + ".bat", "", "C:\\PDS_SIM", false);
						Delay.Milliseconds(0);
						
						Report.Log(ReportLevel.Info, "Wait", "Waiting 30s to exist. Associated repository item: 'NetworkLogon'", repo.NetworkLogon.SelfInfo, new ActionTimeout(30000), new RecordItemIndex(2));
						repo.NetworkLogon.SelfInfo.WaitForExists(30000);
					}
					else
					{
						Report.Failure("Failure: Batch File Type can be either 'PDS' or 'MOW'.");
					}
				}
			}
			catch (Exception e)
			{
				Report.Failure(String.Format("Failure {0}: Batch File Type can be either 'PDS' or 'MOW'.", e));
			}
		}
		
		/// <summary>
		/// This function is specifically for terminating the Network Logon Credential Screen which spawns again after exit.
		/// This is a temporary function and will be updated in the future based on improvements to the PDS system.
		/// </summary>
		[UserCodeMethod]
		public static void killNetworkLogon()
		{
			var repo = PDS_CORERepository.Instance;

			for(int spawnCounter=1; spawnCounter<=2; spawnCounter++)
			{
				Delay.Milliseconds(15000);

				if(repo.NetworkLogon.SelfInfo.Exists(0))
				{
					repo.NetworkLogon.Close.Click();
					repo.Form_WarningBox.buttonYes.Click();
					Delay.Milliseconds(5000);
				}
			}
		}
    }
}
