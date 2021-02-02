/*
 * Created by Ranorex
 * User: 503052222
 * Date: 10/2/2019
 * Time: 11:43 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using Env.Code_Utils;

namespace Oracle.Code_Utils
{
	/// <summary>
	/// Description of TDMSEnvironment.
	/// </summary>
	[UserCodeCollection]
	public class TDMSEnvironment
	{
		private static Oracle.Code_Utils.DataLoader TDMSDataLoader;
		
		//user code method to get dataloader oracle database connections
		[UserCodeMethod]
		public static DataLoader GetTDMSDataLoaderOracleConnections()
		{
			VMEnvironment vm = VMEnvironment.Instance();
			if(!string.IsNullOrEmpty(vm.dbUser))
			{
				TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user));
			}
			else
			{
				TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("TDMS", vm.dbPw, vm.user));
			}
			return TDMSDataLoader;
		}
		
		public static void InitializeTDMSEnvironment()
        {
                VMEnvironment vm = VMEnvironment.Instance();
                if(!string.IsNullOrEmpty(vm.dbUser))
                {
                    TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user));
                }
                else
                {
                    TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("TDMS", vm.dbPw, vm.user));
                }
            
        }
		
		/// <summary>
		/// Gets the track lavel id via the Id from the UI element above it.
		/// Useful for finding what track section a train is currently on.
		/// </summary>
		/// <param name="trackSectionId">Id of the ui element above a track section</param>
		public static string GetTrackLabeldfromAssociatedSectionId(string trackSectionId)
		{
			TDMSDataLoader = GetTDMSDataLoaderOracleConnections();
			string qry = "SELECT TRACK_LABEL_SYMBOL_ID FROM TDMS.TP_TRACK_SECTION WHERE SECTION_ID = '"+trackSectionId+"' order by PROJECT_ID desc, PROJECT_VERSION desc fetch FIRST 1 rows only";
			DataTable trackLabelId = new DataTable();
			trackLabelId = TDMSDataLoader.ReadOracleDataToTable(qry);
			if (!(trackLabelId.Rows.Count == 0))
			{
				return trackLabelId.Rows[0][0].ToString();
			}
			else
			{
				Ranorex.Report.Failure("Track Label Id not found for Track Section {"+trackSectionId+"} in TDMS Database");
				return "";
			}
		}
		
		/// <summary>
        /// Runs an TDMS Query
        /// </summary>
        [UserCodeMethod]
    	public static void UpdateTDMSQuery(string qry)
    	{
    	    InitializeTDMSEnvironment();
    	    string [] qryArray = qry.Split(';');
    	    foreach(string query in qryArray)
    	    {
    	    	Ranorex.Report.Info("No of Rows Impacted: "+TDMSDataLoader.ExecuteUpdateQueryToTable(query).ToString());
    	    }
    	}
		
		/// <summary>
		///	Method to fetch the indicating bit for the given deviceID
		/// Useful for Snow Melter and Miscellaneous device
		/// </summary>
		/// <param name="deviceId">Device Id of the trackline objects</param>
		public static bool GetIndicatingStateMiscellaneousDevice(string deviceId)
		{
			TDMSDataLoader = GetTDMSDataLoaderOracleConnections();
			string qry = "SELECT INDICATING FROM TDMS.CS_MISCDEVICE_PK_VW WHERE MISC_DEVICE_ID = '"+deviceId+"' order by PROJECT_ID desc, PROJECT_VERSION desc fetch FIRST 1 rows only";
			DataTable indicatingBit = new DataTable();
			indicatingBit = TDMSDataLoader.ReadOracleDataToTable(qry);
			if (!(indicatingBit.Rows.Count == 0))
			{
				if(indicatingBit.Rows[0][0].ToString() == "1")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				Ranorex.Report.Failure("Miscellaneous Device ID {"+deviceId+"} could not be found in TDMS Database");
				return false;
			}
		}
	}
}
