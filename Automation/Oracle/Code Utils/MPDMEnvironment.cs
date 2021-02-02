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
    
    [UserCodeCollection]
    public class MPDMEnvironment
    {
        private static Oracle.Code_Utils.DataLoader MPDMDataLoader; //don't need it yet, but to keep with standards in other oracle db collections, it's here
        private static Oracle.Code_Utils.OracleConnectionContext ora;
        
        //user code method to get dataloader oracle database connections
        [UserCodeMethod]
        public static void GetMPDMDataLoaderOracleConnections()
        {
        	VMEnvironment vm = VMEnvironment.Instance();
        	if(!string.IsNullOrEmpty(vm.dbUser))
        	{
        		MPDMDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user));
        	}
        	else
        	{
        		MPDMDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("MPDM", vm.dbPw, vm.user));
        	}
       	}
        
        //user code method to get oracle database connections
        [UserCodeMethod]
        public static void GetMPDMOracleConnections()
        {
        	VMEnvironment vm = VMEnvironment.Instance();
        	if(!string.IsNullOrEmpty(vm.dbUser))
        	{
	    		ora = new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, vm.dbPw, vm.user);
        	}
        	else
        	{
        		ora = new Oracle.Code_Utils.OracleConnectionContext("MPDM", vm.dbPw, vm.user);
        	}
        }
    	
        public static string GetObstructionTimeIntervals () {
        	GetMPDMDataLoaderOracleConnections();
        	string qry = "Select VALUE from MPDM.SUGGESTION_CONFIG where KEY= 'obstructionTimeInterval'";
        	DataTable configTable = new DataTable();
        	configTable = MPDMDataLoader.ReadOracleDataToTable(qry);
        	if (!(configTable.Rows.Count == 0))
        	{
        		return configTable.Rows[0][0].ToString();
        	} else
        	{
        		Ranorex.Report.Failure("Couldn't find the config in MPDM Database.");
        		return "";
        	}
        }
        //TODO Just turn MPDM into an obj with current configs?
        public static string GetSuggestionEndTimeIntervals () {
        	GetMPDMDataLoaderOracleConnections();
        	string qry = "Select VALUE from MPDM.SUGGESTION_CONFIG where KEY= 'suggestionEndTimeInterval'";
        	DataTable configTable = new DataTable();
        	configTable = MPDMDataLoader.ReadOracleDataToTable(qry);
        	if (!(configTable.Rows.Count == 0))
        	{
        		return configTable.Rows[0][0].ToString();
        	} else
        	{
        		Ranorex.Report.Failure("Couldn't find the config in MPDM Database.");
        		return "";
        	}
        }
        
	    [UserCodeMethod]
	    public static void ChangeObstructionTimeConfigurable (string territoryId, string timeInMinutes)
	    {
	
	    	GetMPDMOracleConnections();
	    	string currentConfig = GetObstructionTimeIntervals();
	    	
	    	string connectionString = ora.BuildConnectionString();
	    	if (currentConfig.Contains(territoryId))
	    	{
	    		int location = currentConfig.IndexOf(territoryId, 0) - 1; //should get the quotation marks
	    		int endOfString = currentConfig.IndexOf(',', location); //edge case where territory is lasst key piar in entry
	    		if (endOfString == -1)
	    		{
	    			endOfString = currentConfig.IndexOf('}', location);
	    		}
	    		string oldConfig = currentConfig.Substring(location, endOfString - location);
	    		currentConfig = currentConfig.Replace(oldConfig, "\""+territoryId+"\" : \"PT"+timeInMinutes+"M\"");
	    	}
	    	else
	    	{
	    		string newQueryString = ", \""+territoryId+"\" : \"PT"+timeInMinutes+"M\"";
	    		currentConfig = currentConfig.Insert(currentConfig.Length-1, newQueryString);
	    	}
	    	
	    	using (OracleConnection con = new OracleConnection(connectionString))
    		{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
		    	cmd.CommandText = "UPDATE \"MPDM\".\"SUGGESTION_CONFIG\" SET VALUE = '{"+currentConfig.TrimEnd('}').TrimStart('{')+"}' WHERE key='obstructionTimeInterval'";
			
	    		cmd.ExecuteNonQuery();
	    	}
	    	
	    	//TODO Sorry, this was hacked in real quick, feel free to make any changs for efficiency in this whole function
	    }
	    
	    [UserCodeMethod]
	    public static void ChangeSuggestionEndTimeConfigurable (string territoryId, string timeInMinutes)
	    {
	
	    	GetMPDMOracleConnections();
	    	string currentConfig = GetSuggestionEndTimeIntervals();
	    	
	    	string connectionString = ora.BuildConnectionString();
	    	if (currentConfig.Contains(territoryId))
	    	{
	    		int location = currentConfig.IndexOf(territoryId, 0) - 1; //should get the quotation marks
	    		int endOfString = currentConfig.IndexOf(',', location); //edge case where territory is lasst key piar in entry
	    		if (endOfString == -1)
	    		{
	    			endOfString = currentConfig.IndexOf('}', location);
	    		}
	    		string oldConfig = currentConfig.Substring(location, endOfString - location);
	    		currentConfig = currentConfig.Replace(oldConfig, "\""+territoryId+"\" : \"PT"+timeInMinutes+"M\"");
	    	}
	    	else
	    	{
	    		string newQueryString = ", \""+territoryId+"\" : \"PT"+timeInMinutes+"M\"";
	    		currentConfig = currentConfig.Insert(currentConfig.Length-1, newQueryString);
	    	}
	    	ExecuteQuery("UPDATE \"MPDM\".\"SUGGESTION_CONFIG\" SET VALUE = '"+currentConfig+"' WHERE key='suggestionEndTimeInterval'");

	    }
	    	
	    [UserCodeMethod]
	    public static void ChangeSuggestionExtendBackConfigurable (string lengthInFeet)
	    {
	
	    	GetMPDMOracleConnections();
	    	
	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
    		{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
		    	cmd.CommandText = "UPDATE \"MPDM\".\"SUGGESTION_CONFIG\" SET VALUE = '\""+lengthInFeet+"\"' WHERE key='extendFromLocationDistance'";
			
	    		cmd.ExecuteNonQuery();
	    	}
	    }
	    
	    [UserCodeMethod]
	    public static void RemoveMPDMEntry (string table, string key, string keyValue)
	    {
	    	string query = "DELETE FROM \"MPDM\".\""+table+"\" WHERE "+key+"='"+keyValue+"'";
	    	ExecuteQuery(query);
	    }
	    
	    [UserCodeMethod]
	    public static void AddMPDMEntry (string table, string valueNames, string values)
	    {
	    	if (values == null || valueNames == null || valueNames.Length == 0 || values.Length == 0)
	    	{
	    		Report.Error("Invalid number of keys or values. Must Exceed 0.");
	    		return;
	    	}
	    	string[] valueNameList = valueNames.Split('|');
	    	string[] valueList = values.Split('|');
	    	if (valueNameList.Length != valueList.Length)
	    	{
	    		Report.Error("Number of data columns and values do not match.");
	    		return;
	    	}
	    	string queryValueNames = "";
	    	foreach (string val in valueNameList)
	    	{
	    		queryValueNames += val + ", ";
	    	}
	    	queryValueNames = queryValueNames.Substring(0, queryValueNames.Length-2);
	    	
	    	string queryValues = "";
	    	foreach (string val in valueList)
	    	{
	    		queryValues += "'"+ val + "', ";
	    	}
	    	queryValues = queryValues.Substring(0, queryValues.Length-2);
	    	
	    	string query = "INSERT INTO MPDM."+table+" ("+queryValueNames+") VALUES ("+queryValues+")";
	    	ExecuteQuery(query);
	    }
	    
	    private static void ExecuteQuery (string query)
	    {
	    	GetMPDMOracleConnections();
	    	
	    	string connectionString = ora.BuildConnectionString();
	    	using (OracleConnection con = new OracleConnection(connectionString))
    		{
	    		con.Open();
	    		OracleCommand cmd = con.CreateCommand();
	    		cmd.CommandType = CommandType.Text;
		    	cmd.CommandText = query;
			
	    		cmd.ExecuteNonQuery();
	    	}
	    }
    }
}
