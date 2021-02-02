/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/2/2018
 * Time: 9:39 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using Env.Code_Utils;

namespace PDS_CORE.Code_Utils
{
	/// <summary>
	/// Description of shutdownUtils.
	/// </summary>
	public class ShutdownUtils
	{
		public static void shutdownPdsUi()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			LinuxUtils.runBatchScript(vm, "kill_pds_ui.bat", "");
			return;
		}
		
		public static void shutdownPds()
		{
			VMEnvironment vm = VMEnvironment.Instance();

			if (!vm.lastLabel.Equals("Not_Applicable")) {
				LinuxUtils.runStartupScript(vm, "stopprevview.sh", "NA", "NA");
			}
			return;
		}
	}
}
