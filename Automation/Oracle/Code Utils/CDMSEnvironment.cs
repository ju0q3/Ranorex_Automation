/*
 * Created by Ranorex
 * User: 503073759
 * Date: 12/4/2018
 * Time: 7:14 AM
 *
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Globalization;
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
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class CDMSEnvironment
    {
        private static Oracle.Code_Utils.DataLoader CDMSDataLoader;
        private static Oracle.Code_Utils.OracleConnectionContext ora;

        //User code method to get dataloader oracle database connections
        [UserCodeMethod]
        public static DataLoader GetCDMSDataLoaderOracleConnections()
        {
        	VMEnvironment vm = VMEnvironment.Instance();
        	if(!string.IsNullOrEmpty(vm.dbUser))
        	{
        		CDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user));
        	}
        	else
        	{
        		CDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("CDMS", vm.dbPw, vm.user));
        	}
			return CDMSDataLoader;
        }

        //User code method to get oracle database connections
        [UserCodeMethod]
        public static OracleConnectionContext GetCDMSOracleConnections()
        {
        	VMEnvironment vm = VMEnvironment.Instance();
        	if(!string.IsNullOrEmpty(vm.dbUser))
        	{
	    		ora = new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user);
        	}
        	else
        	{
        		ora = new Oracle.Code_Utils.OracleConnectionContext("CDMS", vm.dbPw, vm.user);
        	}
			return ora;
        }

        [UserCodeMethod]
        // Some of these private methods are here temporarily. I'll be creating a DB helper class shortly. -DK
        private static void executeQuery(string query)
	    {

	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
	    	ora = GetCDMSOracleConnections();
	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
	    	{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		OracleTransaction transaction;
	    		transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
	    		cmd.Transaction = transaction;
	    		cmd.CommandType = CommandType.Text;
	    		try
	    		{
	    			cmd.CommandText = query;
	    			cmd.ExecuteNonQuery();
	    			transaction.Commit();
	    		}
	    		catch(Exception e)
	    		{
	    			Report.Failure("Failure exception "+e.Message);
	    			transaction.Rollback();
	    		}
	    		transaction.Dispose();
	    		con.Close();
	    	}
	    }

		private static System.DateTime convertCharTimestampToDateTime(string charTimestamp)
		{
			System.DateTime outTime = System.DateTime.ParseExact(charTimestamp, csharp_timestamp, CultureInfo.InvariantCulture);
			return outTime;
		}

		private static string formatDateTimeToString(System.DateTime inputTime)
		{
			string outTime = inputTime.ToString("dd-MMMM-yyyy HH:mm:ss.ffffff");
			return outTime;
		}

        private static string oracle_timestamp = "YYYYMMDDHH24MISS";
        private static string csharp_timestamp = "yyyyMMddHHmmss";

		[UserCodeMethod]
        public static string GetPTCConfiguration_CDMS(string cfgAttribute)
        {
        	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

        	string qry = "SELECT CONFIG_VALUE FROM CDMS.OTC_CFG_TAB WHERE CONFIG_NAME = " + "'" + cfgAttribute + "'";

        	DataTable output = new DataTable();
        	output = CDMSDataLoader.ReadOracleDataToTable(qry);

        	if (output.Rows.Count == 0)
        	{
        		Ranorex.Report.Failure("There is no return value for " + cfgAttribute);
        		return null;
        	} else {
        		string result = output.Rows[0][0].ToString();
        		return result;
        	}
        }

        [UserCodeMethod]
	    public static void SetPTCConfiguration_CDMS(string cfgAttribute, string cfgValue)
	    {
	    	ora = GetCDMSOracleConnections();

	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
	    	{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
	    		cmd.CommandText = "update CDMS.OTC_CFG_TAB set config_value = '"+cfgValue+"' where config_name = '"+cfgAttribute+"'";
	    		cmd.ExecuteNonQuery();
	    	}

	    }

		[UserCodeMethod]
		public static void SetBulletinConfiguration_CDMS(string bulletinType, int ptcTransfer, string operable, int toTransfer)
		{
			ora = GetCDMSOracleConnections();

			string connectionString = ora.BuildConnectionString();
			using (OracleConnection con = new OracleConnection(connectionString))
			{
				con.Open();
				OracleCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = string.Format("UPDATE CDMS.RST_BULI_TYPE_CFG SET PTC_TRANSFER = {0}, OPERABLE = '{1}', TO_TRANSFER = {2} WHERE BULLETIN_TYPE = '{3}'", ptcTransfer.ToString(), operable, toTransfer.ToString(), bulletinType);
				cmd.ExecuteNonQuery();
			}
			Delay.Seconds(1); //just in case, lets give it time to take effect before opening bulletin forms
		}

		[UserCodeMethod]
        public static DataTable GetRowCount(string tableName)
        {
            CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
			string qry = string.Format("SELECT COUNT(*) AS ROW_COUNT FROM (SELECT * FROM CDMS.{0})", tableName.ToUpper());

			DataTable output = new DataTable();
            output = CDMSDataLoader.ReadOracleDataToTable(qry);

			return output;
        }

		public static bool TableExists(string tableName)
        {
            CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

            string qry = string.Format("SELECT * FROM ALL_TAB_COLUMNS WHERE OWNER = 'CDMS' AND TABLE_NAME = '{0}'", tableName.ToUpper());

            DataTable output = new DataTable();
            output = CDMSDataLoader.ReadOracleDataToTable(qry);

            bool tableExists = false;
            if (output.Rows.Count > 0)
            {
                tableExists = true;
            }

            return tableExists;
        }

		public static DataTable GetPTCConfigurationByDistrict_CDMS(string districtName)
		{
			CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

	    	string query = string.Format(
				"WITH DISTRICT_TABLE AS " +
				"(" +
				"SELECT DISTINCT TBL.*, UPPER(VW.DISTRICT_NAME) AS DISTRICT_NAME " +
				"FROM CDMS.OTC_COMMUNICATION_CFG TBL, OTC_COMMUNICATION_CFG_VW VW " +
				"WHERE TBL.DISTRICT_ID = VW.DISTRICT_ID " +
				") " +
				"SELECT * FROM DISTRICT_TABLE WHERE DISTRICT_NAME = '{0}'",
				districtName.ToUpper()
			);
    		DataTable ptcConfig = new DataTable();
    		ptcConfig = CDMSDataLoader.ReadOracleDataToTable(query);
			return ptcConfig;
		}

	    /// <summary>
    	/// Sets version ofspecified PTC or RUM Message
    	/// </summary>
    	/// <param name="message">Input:RUM Or PTC message</param>
    	/// <param name="messageVersion">Input:Message version of ptc or RUM messages</param>
	    [UserCodeMethod]
	    public static void SetPTCOrRUMMessageVersion_CDMS(string message, string messageVersion)
	    {
	    	ora = GetCDMSOracleConnections();

	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
	    	{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
	    		// Note that VERSION column in table is numeric, not string.
	    		// This becomes relevant when concatenating the string for the below query.
	    		cmd.CommandText = "update CDMS.PTC_MSG_VERSION_CFG set version = "+messageVersion+" where msg_name = '"+message+"'";
	    		cmd.ExecuteNonQuery();
	    	}
	    }

	    /// <summary>
    	/// Sets all PTC Messages to a specific version
    	/// </summary>
    	/// <param name="ptcVersion">Input:Message version of ptc messages</param>
	    [UserCodeMethod]
	    public static void SetAllPTCMessageVersion_CDMS(string ptcVersion)
	    {
	    	ora = GetCDMSOracleConnections();
	    	//Ranorex.Report.Info("User and password"+vm.dbPw+vm.user+vm.computer);
	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
	    	{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
	    		// Note that VERSION column in table is numeric, not string.
	    		// This becomes relevant when concatenating the string for the below query.
	    		cmd.CommandText = "update CDMS.PTC_MSG_VERSION_CFG set version = "+ptcVersion+" where MSG_NAME NOT like 'DR%'";
	    		cmd.ExecuteNonQuery();
	    	}
	    }

	    /// <summary>
    	/// Sets all RUM Messages to a specific version
    	/// </summary>
    	/// <param name="rumVersion">Input:Message version of rum messages</param>
	    [UserCodeMethod]
	    public static void SetAllRUMMessageVersion_CDMS(string rumVersion)
	    {
	    	ora = GetCDMSOracleConnections();

	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
	    	{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
	    		// Note that VERSION column in table is numeric, not string.
	    		// This becomes relevant when concatenating the string for the below query.
	    		cmd.CommandText = "update CDMS.PTC_MSG_VERSION_CFG set version = "+rumVersion+" where MSG_NAME like 'DR%'";
	    		cmd.ExecuteNonQuery();
	    	}
	    }

	    [UserCodeMethod]
	    public static HashSet<string> GetDRAConfig()
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	HashSet<string> result = CDMSEnvironment.GetDRAConfig();

	    	return result;

	    }

        [UserCodeMethod]
	    public static bool insertDRAConfig(string draName, string fromOpsta, string toOpsta, string fromOpstaDisplay, string toOpstaDisplay, string fromMP, string toMP,
    	                            string fromTerritoryId, string toTerritoryId, string active)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	bool result = CDMSEnvironment.insertDRAConfig(draName, fromOpsta, toOpsta, fromOpstaDisplay, toOpstaDisplay, fromMP, toMP,
    	                            fromTerritoryId, toTerritoryId, active);

	    	return result;

	    }

        [UserCodeMethod]
	    public static bool updateDRAConfig(string draName, string fromOpsta, string toOpsta, string fromMP, string toMP)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	bool result = CDMSEnvironment.updateDRAConfig(draName, fromOpsta, toOpsta, fromMP, toMP);

	    	return result;

	    }

	    [UserCodeMethod]
	    public static bool deleteDRAConfig(string draName)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	bool result = CDMSEnvironment.deleteDRAConfig(draName);

	    	return result;

	    }

	    [UserCodeMethod]
	    public static bool updateCFGCommonConfigTab(string configName, string configValue)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	bool result = CDMSEnvironment.updateCFGCommonConfigTab(configName, configValue);

	    	return result;

	    }

	    [UserCodeMethod]
	    public static string GetDRAActionTableComments(string trainKey)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	string result = CDMSEnvironment.GetDRAActionTableComments(trainKey);

	    	return result;

	    }

	    [UserCodeMethod]
	    public static string GetDRAActionTableEnteredTime(string trainKey, string fromOpsta, string toOpsta)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	string result = CDMSEnvironment.GetDRAActionTableEnteredTime(trainKey, fromOpsta, toOpsta);

	    	return result;

	    }

	    [UserCodeMethod]
	    public static string GetDRAActionTableProjectedTime(string trainKey, string fromOpsta, string toOpsta)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	string result = CDMSEnvironment.GetDRAActionTableProjectedTime(trainKey, fromOpsta, toOpsta);

	    	return result;

	    }


    	/// <summary>
    	/// Validating if the train is present in CFG_DRA_ACTION table
    	/// </summary>
    	/// <param name="trainKey">Train Key from the ADMS table</param>
    	/// <param name="fromOpsta">DRA FromOpsta</param>
    	/// <param name="toOpsta">DRA To Opsta</param>
    	/// <returns></returns>
    	[UserCodeMethod]
    	public static string ValidateIfTrainPresentInActionTable(string trainKey, string fromOpsta, string toOpsta)
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

    		//Retrieve the Projected for a TIH train and send it, else throw failure and return ""
    		string qry = "Select TRAIN_KEY from CDMS.CFG_DRA_ACTION where TRAIN_KEY = '"+trainKey+"' and FROM_OPSTA = '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"'";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (DRAActionTable.Rows.Count == 1)
    		{
    			return DRAActionTable.Rows[0][0].ToString();
    		}

    		int retry = 0;
        	while (DRAActionTable.Rows.Count == 0 && retry < 5)
        	{
        		Delay.Seconds(1);
        		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (DRAActionTable.Rows.Count == 1)
        	{
        		return DRAActionTable.Rows[0][0].ToString();
        	} else
        	{
        		Ranorex.Report.Warn("Train not found for train key "+trainKey+" in CDMS Database");
        		return "";
        	}

    	}

    	public static bool CheckProjectedEntriesRemovedInActionTable()
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

    		//Retrieve the Projected for a TIH train and send it, else throw failure and return ""
    		string qry = "Select PROJECTED from CDMS.CFG_DRA_ACTION where ENTERED is null";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (DRAActionTable.Rows.Count == 0)
    		{
    			return true;
    		}

    		int retry = 0;
    		while (!(DRAActionTable.Rows.Count == 0) && retry < 120)
        	{
        		Delay.Seconds(1);
        		Ranorex.Report.Info("Count is: " +DRAActionTable.Rows.Count.ToString());
        		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}

    		if (DRAActionTable.Rows.Count == 0)
        	{
        		return true;
        	} else
        	{
        		Ranorex.Report.Warn("Projected Entries Still Exist in CFG_DRA_ACTION table");
        		return false;
        	}

    	}

      /// <summary>
    	/// Updating the OTC_CFG_Tab table to the value provided for the Config Name
    	/// </summary>
    	/// <param name="configName"></param>
    	/// <param name="configValue"></param>
    	/// <returns></returns>
    	[UserCodeMethod]
    	public static bool updateOTCCFGTabTable(string configName, string configValue)
    	{
    		//Check in table if the Config exists or not, if exists then only update it, else throw failure
    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

    		string qry = "Select CONFIG_NAME from CDMS.OTC_CFG_TAB where CONFIG_NAME = '"+configName+"'";
    		DataTable otcConfigTab = new DataTable();
    		otcConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (!(otcConfigTab.Rows.Count == 0))
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.OTC_CFG_TAB set CONFIG_VALUE = '"+configValue+"' where CONFIG_NAME = '"+configName+"'";
    			otcConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//Validate if the updated values are present
    			qry = "Select CONFIG_NAME from CDMS.OTC_CFG_TAB where CONFIG_NAME = '"+configName+"' and CONFIG_VALUE = '"+configValue+"'";
    			otcConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//If after updating the Config select query returns value then it was successfully updated.
    			if(!(otcConfigTab.Rows.Count == 0))
    			{
    				Ranorex.Report.Info("Successfully updated Config {"+configName+"} with value {"+configValue+"} in OTC_CFG_Tab.");
    				return true;
    			} else {
    				Ranorex.Report.Error("Unable to update the Config for value {"+configValue+"} in OTC_CFG_Tab.");
    				return false;
    			}
    		} else {
    			Ranorex.Report.Error("Could not locate Config Name {"+configName+"} in OTC_CFG_Tab.");
    			return false;
    		}

    	}

    	public static bool CheckEnteredEntriesRetainedInActionTable()
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

    		//Retrieve the Projected for a TIH train and send it, else throw failure and return ""
    		string qry = "Select TRAIN_KEY from CDMS.CFG_DRA_ACTION where ENTERED is Not Null";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (DRAActionTable.Rows.Count > 0)
    		{
    			return true;
    		}

    		int retry = 0;
        	while (DRAActionTable.Rows.Count == 0 && retry < 120)
        	{
        		Delay.Seconds(1);
        		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
        		retry++;
        	}
        	if (DRAActionTable.Rows.Count > 0)
        	{
        		return true;
        	} else
        	{
        		Ranorex.Report.Warn("Entered Entries are not retained in CFG_DRA_ACTION table");
        		return false;
        	}

    	}

    	/// <summary>
    	/// Validate the table contents for the Bulletin Type
    	/// </summary>
    	/// <param name="bulletinName">Name of the bulletin for which contents needs to validate</param>
    	/// <param name="ptcTransfer">validate the ptcTransfer value</param>
    	/// <param name="operable">Operable value to validate in CDMS</param>
    	/// <param name="toTransfer">toTransfer value to validate in CDMS</param>
    	/// <returns></returns>
    	public static bool validateRSTBuliTypeCFG(string bulletinName, string ptcTransfer, string operable, string toTransfer)
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

	    	bool result = false;
    		//Retrieve the Bulletin_TYPE data and validate it, else throw failure and return ""
    		string qry = "Select BULLETIN_TYPE, PTC_TRANSFER, OPERABLE, TO_TRANSFER, EFFECTIVE_TIME_DELAY from CDMS.RST_BULI_TYPE_CFG where BULLETIN_TYPE like '%"+bulletinName+"%'";
    		DataTable BuliTypeConfig = new DataTable();
    		BuliTypeConfig = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (BuliTypeConfig.Rows.Count > 0)
    		{
    			result = true;
    			if(!BuliTypeConfig.Rows[0][1].ToString().Equals(ptcTransfer) && ptcTransfer != "")
    			{
    				Ranorex.Report.Info("PTC Transfer Value Present in CDMS table: "+BuliTypeConfig.Rows[0][1].ToString());
    				Ranorex.Report.Error("PTC Transfer Field Does not match");
    				result = false;
    			}

    			if(!BuliTypeConfig.Rows[0][2].ToString().Equals(operable) && operable != "")
    			{
    				Ranorex.Report.Info("Operable Value Present in CDMS table: "+BuliTypeConfig.Rows[0][2].ToString());
    				Ranorex.Report.Error("Operable Field Does not match");
    				result = false;
    			}

    			if(!BuliTypeConfig.Rows[0][3].ToString().Equals(toTransfer) && toTransfer != "")
    			{
    				Ranorex.Report.Info("To Transfer Value Present in CDMS table: "+BuliTypeConfig.Rows[0][3].ToString());
    				Ranorex.Report.Error("To Transfer Field Does not match");
    				result = false;
    			}

    		}


        	if (BuliTypeConfig.Rows.Count == 0)
        	{
        		Ranorex.Report.Error("No Entry found in RST_BULI_TYPE_CFG for bulletin like "+bulletinName);
        		return false;
        	}

        	return result;

    	}

    	[UserCodeMethod]
    	public static void updateRSTBuliTypeCfg(string bulletinName, string ptcTransfer, string operable, string toTransfer)
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

    		string updatePTC = "";
	    	string updateOperable = "";
	    	string updateToTransfer = "";
	    	string finalQuery = "";

    		//Retrieve the Bulletin_TYPE data and validate it, else throw failure and return ""
    		if(!string.IsNullOrEmpty(ptcTransfer))
    		{
    			updatePTC = "PTC_TRANSFER = '"+ptcTransfer+"'";
    		}

    		if(!string.IsNullOrEmpty(operable))
    		{
    			updateOperable = "OPERABLE = '"+operable+"'";
    		}

    		if(!string.IsNullOrEmpty(toTransfer))
    		{
    			updateToTransfer = "TO_TRANSFER = '"+toTransfer+"'";
    		}

    		string updateClause = "Update CDMS.RST_BULI_TYPE_CFG Set ";
    		string whereClause = string.Format(" where BULLETIN_TYPE like '%{0}%'", bulletinName);

    		finalQuery = finalQuery + updateClause;

    		if(updatePTC != "" ){
    			finalQuery = finalQuery + updatePTC ;
    		}

    		if(updateOperable != "" && finalQuery.Contains("PTC_TRANSFER"))
    		{
    			finalQuery = finalQuery + "," + updateOperable;
    		} else if(updateOperable != "")
    		{
    			finalQuery = finalQuery + updateOperable;
    		}

    		if(updateToTransfer != "" && (finalQuery.Contains("PTC_TRANSFER") || finalQuery.Contains("OPERABLE")))
    		{
    			finalQuery = finalQuery + "," + updateToTransfer;
    		} else if(updateToTransfer != "")
    		{
    			finalQuery = finalQuery + updateToTransfer;
    		}

    		finalQuery = finalQuery + whereClause;
    		Ranorex.Report.Info(finalQuery);
    		DataTable BuliTypeConfig = new DataTable();
    		BuliTypeConfig = CDMSDataLoader.ReadOracleDataToTable(finalQuery);

    		string selectQuery = "Select BULLETIN_TYPE, PTC_TRANSFER, OPERABLE, TO_TRANSFER from CDMS.RST_BULI_TYPE_CFG where BULLETIN_TYPE like '%"+bulletinName+"%'";
    		BuliTypeConfig = CDMSDataLoader.ReadOracleDataToTable(selectQuery);

    		if (BuliTypeConfig.Rows.Count == 1)
    		{

    			if(!BuliTypeConfig.Rows[0][1].ToString().Equals(ptcTransfer) && ptcTransfer != "")
    			{
    				Ranorex.Report.Info("PTC Transfer Value Present in CDMS table: "+BuliTypeConfig.Rows[0][1].ToString());
    				Ranorex.Report.Failure("PTC Transfer Field did not update");
    				return;
    			}

    			if(!BuliTypeConfig.Rows[0][2].ToString().Equals(operable) && operable != "")
    			{
    				Ranorex.Report.Info("Operable Value Present in CDMS table: "+BuliTypeConfig.Rows[0][2].ToString());
    				Ranorex.Report.Failure("Operable Field did not update");
    				return;
    			}

    			if(!BuliTypeConfig.Rows[0][3].ToString().Equals(toTransfer) && toTransfer != "")
    			{
    				Ranorex.Report.Info("To Transfer Value Present in CDMS table: "+BuliTypeConfig.Rows[0][3].ToString());
    				Ranorex.Report.Failure("To Transfer Field did not update");
    				return;
    			}

    			Ranorex.Report.Success("Updates were correctly done");

    		} else
        	{
        		Ranorex.Report.Failure("No Entry found in RST_BULI_TYPE_CFG for bulletin like "+bulletinName);
        		return ;
        	}


        	return;

    	}


	    /// <summary>
		/// Update Projected Date in CFG_DRA_ACTION table in CDMS
		/// </summary>
		/// <param name="trainSeed">Input: trainSeed to get trainkey</param>
		/// <param name="fromOpsta">Input:fromOpsta to execute Query for Update projected column in CFG_DRA_ACTION Table</param>
		/// <param name="toOpsta">Input:toOpsta to execute Query for Update projected column in CFG_DRA_ACTION Table</param>
		/// <param name="projectedDateOffset">Input: projectedDateOffset for date offset ex. +1, -1, +2, -2 </param>
	    public static bool updateDRAActionTableProjectedDate(string trainKey, string fromOpsta, string toOpsta, int projectedDateOffset)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
	    	string qry = string.Format(
	    		"SELECT TO_CHAR(PROJECTED, '{0}') PROJECTED FROM CDMS.CFG_DRA_ACTION WHERE TRAIN_KEY = '{1}' AND FROM_OPSTA = '{2}' AND TO_OPSTA = '{3}'",
	    		oracle_timestamp, trainKey, fromOpsta, toOpsta
	    	);

	    	DataTable DRAActionTable = new DataTable();
	    	DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);

	    	int retry = 0;
	    	while (DRAActionTable.Rows.Count == 0 && retry < 10)
	    	{
	    		Delay.Seconds(1);
	    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retry++;
	    	}

	    	if (DRAActionTable.Rows.Count == 1)
	    	{
	    		bool updated  = false;
	    		if(!projectedDateOffset.Equals(""))
	    		{
	    			// Test the results. What is the timestamp?
					System.DateTime initialDateTime = convertCharTimestampToDateTime(DRAActionTable.Rows[0][0].ToString());

					// This is solely for presentation in report
					string initialTimeString = formatDateTimeToString(initialDateTime);
					Ranorex.Report.Info(string.Format("The initial time provided is: {0}", initialTimeString));

					// Add Days here
					System.DateTime updatedDateTime = initialDateTime.AddDays(projectedDateOffset);
					string updatedTimeString = updatedDateTime.ToString(csharp_timestamp);
					string timestampString = string.Format("TO_TIMESTAMP('{0}','{1}')", updatedTimeString, oracle_timestamp);

					string updateQuery = string.Format(
						"UPDATE CDMS.CFG_DRA_ACTION SET PROJECTED = {0} WHERE TRAIN_KEY = '{1}' AND FROM_OPSTA = '{2}' AND TO_OPSTA = '{3}'",
						timestampString, trainKey, fromOpsta, toOpsta
					);
	    			executeQuery(updateQuery);

	    			DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    			retry = 0;
	    			while (DRAActionTable.Rows.Count == 0 && retry < 12)
	    			{
	    				Delay.Seconds(1);
	    				DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    				retry++;
	    			}

	    			if(DRAActionTable.Rows.Count == 1)
	    			{

						// Test the results. What is the timestamp?
						System.DateTime validateDateTime = convertCharTimestampToDateTime(DRAActionTable.Rows[0][0].ToString());

						// This is solely for presentation in report
						string validateTimeString = formatDateTimeToString(validateDateTime);
						Ranorex.Report.Info(string.Format("The adjusted time provided is: {0}", validateTimeString));

						if (updatedDateTime == validateDateTime)
						{
							updated = true;
							Ranorex.Report.Success("Successfully updated Projected date for " + trainKey);
							return updated;
						}
						// else condition for the above statement is satisfied below -DK
	    			}
	    			else
	    			{
	    				Ranorex.Report.Failure(string.Format("The following query did not successfully update CFG_DRA_ACTION: {0}", qry));
	    			}
	    		}
	    		return updated;
	    	}

	    	else
	    	{
	    		Ranorex.Report.Failure("Train not found for train key "+trainKey+" in CDMS Database");
	    		return false;
	    	}
	    }


	    /// <summary>
	    /// Validate Reason field has updated as expected in CDMS
	    /// </summary>
	    [UserCodeMethod]
	    public static void ValidateReasonField_CFG_Lamp_Route(string LampRouteId, string Reason)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

			string qry = string.Format("Select * from CDMS.CFG_LAMP_ROUTE where EVENT_TIME = (Select max(EVENT_TIME) from CDMS.CFG_LAMP_ROUTE) and REASON ='{1}' and LAMP_ROUTE_ID = '{0}'", LampRouteId,Reason);

	    	DataTable LampRouteTable = new DataTable();
	    	LampRouteTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    	int retries = 0;
	    	while (LampRouteTable.Rows.Count == 0 && retries < 5)
	    	{
	    		Delay.Seconds(1);
	    		LampRouteTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retries++;
	    	}
	    	if (LampRouteTable.Rows.Count == 1)
	    	{
	    		Ranorex.Report.Success(" Reason Field is updated in CDMS Database as expected " );
	    	}
	    	else
	    	{
	    		Ranorex.Report.Failure("Reason Field is not updated in CDMS Database ");
	    	}
	    }

	    /// <summary>
	    /// Validate Reason field in Track Designation has updated as expected in CDMS
	    /// </summary>
	    [UserCodeMethod]
	    public static void ValidateReasonField_MP_Track_Designation(string TrackId, string Reason)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

			string qry = string.Format("Select * from CDMS.MP_TRACK_DESIGNATION where EVENT_TIME = (Select max(EVENT_TIME) from CDMS.MP_TRACK_DESIGNATION) and REASON ='{1}' and TRACK_ID = '{0}'", TrackId,Reason);

	    	DataTable TrackDesignationTable = new DataTable();
	    	TrackDesignationTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    	int retries = 0;
	    	while (TrackDesignationTable.Rows.Count == 0 && retries < 5)
	    	{
	    		Delay.Seconds(1);
	    		TrackDesignationTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retries++;
	    	}
	    	if (TrackDesignationTable.Rows.Count == 1)
	    	{
	    		Ranorex.Report.Success(" Reason Field is updated in CDMS Database as expected " );
	    	}
	    	else
	    	{
	    		Ranorex.Report.Failure("Reason Field is not updated in CDMS Database ");
	    	}
	    }

	    /// <summary>
	    /// Validate Reason field in Track restriction has updated as expected in CDMS
	    /// </summary>
	    [UserCodeMethod]
	    public static void ValidateReasonField_MP_Track_Restriction(string Reason)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();

			string qry = string.Format("Select * from CDMS.MP_TRACK_RESTRICTION where EVENT_TIME = (Select max(EVENT_TIME) from CDMS.MP_TRACK_RESTRICTION) and REASON ='{0}'", Reason);

	    	DataTable TrackRestrictionTable = new DataTable();
	    	TrackRestrictionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    	int retries = 0;
	    	while (TrackRestrictionTable.Rows.Count == 0 && retries < 5)
	    	{
	    		Delay.Seconds(1);
	    		TrackRestrictionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retries++;
	    	}
	    	if (TrackRestrictionTable.Rows.Count == 1)
	    	{
	    		Ranorex.Report.Success(" Reason Field is updated in CDMS Database as expected " );
	    	}
	    	else
	    	{
	    		Ranorex.Report.Failure("Reason Field is not updated in CDMS Database ");
	    	}
	    }

	    [UserCodeMethod]
	    public static void update_AR_Disp_Terr_Config(string dispatchTerrId, string configValue)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
	    	dispatchTerrId = dispatchTerrId.Trim();
	    	string qry = "Select DISPATCH_TERR_ID from CDMS.AR_DISP_TERR_CFG where DISPATCH_TERR_ID = '"+dispatchTerrId+"'";
    		DataTable arDispTerrConfig = new DataTable();
    		arDispTerrConfig = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (arDispTerrConfig.Rows.Count == 1)
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.AR_DISP_TERR_CFG set ENABLE_AR = '"+configValue.ToUpper()+"' where DISPATCH_TERR_ID = '"+dispatchTerrId+"'";
    			arDispTerrConfig = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//Validate if the updated values are present
    			qry = "Select DISPATCH_TERR_ID from CDMS.AR_DISP_TERR_CFG where DISPATCH_TERR_ID = '"+dispatchTerrId+"' and ENABLE_AR = '"+configValue.ToUpper()+"'";
    			arDispTerrConfig = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//If after updating the Config select query returns value then it was successfully updated.
    			if(arDispTerrConfig.Rows.Count == 1)
    			{
    				Ranorex.Report.Success("Successfully updated Config " + dispatchTerrId);
    				return;
    			}
    			else
    			{
    				Ranorex.Report.Failure("Unable to update the Config for value " + configValue);
    				return;
    			}
    		} else
    		{
    			Ranorex.Report.Failure("Unable to find the Config for Config Name " + dispatchTerrId);
    			return;
    		}
	    }
	    public static string GetCommonConfigValue_CDMS(string cfgAttribute)
	    {
	    	CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
	    	string qry = "SELECT CONFIG_VALUE FROM CDMS.CFG_COMMON_CONFIG_TAB WHERE CONFIG_NAME = '"+cfgAttribute+"'";
	    	DataTable commonConfigTab = new DataTable();
	    	commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
	    	int retries = 0;
	    	while (commonConfigTab.Rows.Count == 0 && retries < 3)
	    	{
	    		Delay.Seconds(1);
	    		commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retries++;
	    	}
	    	if (commonConfigTab.Rows.Count == 1)
	    	{
	    		return commonConfigTab.Rows[0][0].ToString();
	    	}
	    	else
	    	{
	    		Ranorex.Report.Failure("Config value not found with "+cfgAttribute+" in CDMS Database");
	    		return "";
	    	}
	    }

	    /// <summary>
	    /// Update Tracking parameters in CDMS given configName and configValue
	    /// </summary>
	    /// <param name="configName">Input: tracking paramter config name</param>
	    /// <param name="configValue">Input: Config Value</param>
	    /// <returns></returns>
	    [UserCodeMethod]
	    public static bool SetTrackingParamtersConfig_CDMS(string configName, string configValue)
	    {
	    	VMEnvironment vm = VMEnvironment.Instance();
	    	Oracle.Code_Utils.CDMSActions CDMSEnvironment = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);

	    	bool result = CDMSEnvironment.UpdateTrackingParameters(configName, configValue);

	    	return result;

	    }

	   	/// <summary>
    	/// Updating the CFG_TRAINGROUP table to the value provided for the Column Name
    	/// </summary>
    	/// <param name="columnName">Input: columnName (e.g THRESHOLD, TIMEFACTOR)</param>
    	/// <param name="configValue">Input: configValue</param>
    	/// <returns></returns>
    	[UserCodeMethod]
    	public static bool UpdateCFG_TRAINGROUPTable(string columnName, string configValue)
    	{
    		//Check in table if the Config exists or not, if exists then only update it, else throw failure
    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
    		string qry = "Select "+columnName+" from CDMS.CFG_TRAINGROUP";
    		DataTable cfgCommonConfigTab = new DataTable();
    		cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (!(cfgCommonConfigTab.Rows.Count == 0))
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.CFG_TRAINGROUP set CDMS.CFG_TRAINGROUP."+columnName+ " = "+configValue;
    			cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//Validate if the updated values are present
    			qry = "Select "+columnName+" from CDMS.CFG_TRAINGROUP where "+columnName+" = "+configValue;
    			cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			Ranorex.Report.Info("No of rows got updated:- " +cfgCommonConfigTab.Rows.Count);

    			//If after updating the Config select query returns value then it was successfully updated.
    			if(!(cfgCommonConfigTab.Rows.Count == 0))
    			{
    				Ranorex.Report.Info("Successfully updated Column {"+columnName+"} with value {"+configValue+"} in CFG_TRAINGROUP Table.");
    				return true;
    			} else
    			{
    				Ranorex.Report.Error("Unable to update the Column for value {"+configValue+"} in CFG_TRAINGROUP Table.");
    				return false;
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Could not locate Column Name {"+columnName+"} in CFG_COMMON_CONFIG Table.");
    			return false;
    		}
    	}

    	/// <summary>
    	/// Updating the CFG_DELAY_CORRIDOR table to the value provided for the Config Name
    	/// </summary>
    	/// <param name="columnName">Input: columnName (e.g MTT)</param>
    	/// <param name="configValue">Input: configValue</param>
    	/// <returns></returns>
    	[UserCodeMethod]
    	public static bool UpdateCFG_DELAY_CORRIDORTable(string columnName, string configValue)
    	{
    		//Check in table if the Config exists or not, if exists then only update it, else throw failure
    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
    		string qry = "Select "+columnName+" from CDMS.CFG_DELAY_CORRIDOR";
    		DataTable cfgCommonConfigTab = new DataTable();
    		cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    		if (!(cfgCommonConfigTab.Rows.Count == 0))
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.CFG_DELAY_CORRIDOR set CDMS.CFG_DELAY_CORRIDOR."+columnName+ " = "+configValue;
    			cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			//Validate if the updated values are present
    			qry = "Select "+columnName+" from CDMS.CFG_DELAY_CORRIDOR where "+columnName+" = "+configValue;
    			cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);

    			Ranorex.Report.Info("No of rows got updated:- " +cfgCommonConfigTab.Rows.Count);

    			//If after updating the Config select query returns value then it was successfully updated.
    			if(!(cfgCommonConfigTab.Rows.Count == 0))
    			{
    				Ranorex.Report.Info("Successfully updated Coulmn {"+columnName+"} with value {"+configValue+"} in CFG_DELAY_CORRIDOR Table.");
    				return true;
    			} else
    			{
    				Ranorex.Report.Error("Unable to update the Column for value {"+configValue+"} in CFG_DELAY_CORRIDOR Table.");
    				return false;
    			}
    		}
    		else
    		{
    			Ranorex.Report.Error("Could not locate Column Name {"+columnName+"} in CFG_DELAY_CORRIDOR Table.");
    			return false;
    		}
    	}

    	/// <summary>
    	/// Enable or disable DSSR feature
    	/// </summary>
    	/// <param name="enable">Input: true (enabled) or false (disabled)</param>
    	/// <returns></returns>
    	[UserCodeMethod]
    	public static void EnableDSSR(bool enable)
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
    		string qry = "Select CONFIG_VALUE from CDMS.OTC_CFG_TAB where CONFIG_NAME = 'ENG_PTC_DSSR_ENABLE'";
    		DataTable cfgCommonConfigTab = new DataTable();
    		cfgCommonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    		string toggle = (enable) ? "YES" : "NO";

    		if (!cfgCommonConfigTab.Rows[0][0].Equals(toggle))
    		{
    			executeQuery("Update CDMS.OTC_CFG_TAB Set CONFIG_VALUE = '"+toggle+"' Where CONFIG_NAME = 'ENG_PTC_DSSR_ENABLE'");
    		}
    		else
    		{
    			Ranorex.Report.Info("DSSR already in desired state.");
    			return;
    		}
    	}


    	[UserCodeMethod]
    	public static void ValidateCDMSTableValue(string table, string row, string column, string valueColumn, string expectedValue)
    	{

    		CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
    		string qry = "Select "+valueColumn+" from CDMS."+table+" where  "+column+"= '"+row+"'";
    		DataTable cdmstab = new DataTable();
    		cdmstab = CDMSDataLoader.ReadOracleDataToTable(qry);
    		string found = cdmstab.Rows[0][0].ToString();

    		if (found.Equals(expectedValue))
    		{
    			Report.Success("Found expected entry.'");
    		}
    		else
    		{
    			Ranorex.Report.Failure("Expected value = "+expectedValue+". Actual = "+found+".");
    		}
    	}
    	
		[UserCodeMethod]
    	public static void UpdateSnowMelterTimerForSubdivision(string subdivision, string timerValue)
    	{
    			string qry = "UPDATE CDMS.CFG_DISTRICTWIDE_OPTIONS SET SNOWMELTER_RESTORE_TIME_SEC="+timerValue+" WHERE DISTRICT_ID=(SELECT DISTRICT_ID FROM CDMS.SNOWMELTER_DISTRICT_VW WHERE DISTRICT_NAME='"+subdivision+"')";
    			Report.Info(qry);
    			executeQuery(qry.Trim());
    	}

    	[UserCodeMethod]
    	public static void SetPtcEnforceableBulletin_CDMS(string bulletinName, string updateValue)
    	{
    	    string qry = string.Format(
    	        "UPDATE CDMS.RST_BULI_TYPE_CFG " +
    	        "SET PTC_ENFORCEABLE = '{0}' " +
    	        "WHERE BULLETIN_TYPE = '{1}'",
    	        updateValue, bulletinName
    	       );
    	    executeQuery(qry);
    	}

		[UserCodeMethod]
		public static void ValidatePtcEnforceableBulletin_CDMS(string bulletinName, string expectedValue)
		{
			CDMSDataLoader = GetCDMSDataLoaderOracleConnections();
	    	
			string qry = string.Format("SELECT * FROM CDMS.RST_BULI_TYPE_CFG WHERE BULLETIN_TYPE = '{0}' AND PTC_ENFORCEABLE = '{1}'", bulletinName, expectedValue);
	    	 
	    	DataTable ptcEnforceTable = new DataTable();
	    	ptcEnforceTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    	int retries = 0;
	    	while (ptcEnforceTable.Rows.Count == 0 && retries < 5)
	    	{
	    		Delay.Seconds(1);
	    		ptcEnforceTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		retries++;
	    	}
	    	if (ptcEnforceTable.Rows.Count == 1)
	    	{
	    		Ranorex.Report.Success(string.Format("Bulletin '{0}' has PTC enforceable value correctly set to: '{1}'", bulletinName, expectedValue));
	    	}
	    	else
	    	{
	    		Ranorex.Report.Failure(string.Format("Bulletin '{0}' does not have PTC enforceable value correctly set to: '{1}'", bulletinName, expectedValue));
	    	}
		}
    }
}
