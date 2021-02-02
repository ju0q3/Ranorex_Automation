/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/3/2019
 * Time: 1:12 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Env.Code_Utils;

namespace Oracle.Code_Utils
{
    public class CDMSActions
    {
    	private Oracle.Code_Utils.DataLoader CDMSDataLoader;
    	
    	public CDMSActions(string dbPw, string user)
    	{
    		VMEnvironment vm = VMEnvironment.Instance();
    		if(!string.IsNullOrEmpty(vm.dbUser))
        	{
        		CDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext(vm.dbUser, dbPw, user));
        	}
        	else
        	{
        		CDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Oracle.Code_Utils.OracleConnectionContext("CDMS", dbPw, user));
        	}
        	
    	}
    	
    	/// <summary>
    	/// Edits the CFG_TAC_TERRITORY table in CDMS to enable/disable limit suggestions
    	/// </summary>
    	public void InsertOrSetTerritoryIdInCfgTacTerritoryTable(string territoryId, bool enable)
    	{
    		string qry = "Select ENABLE_TAC from CDMS.CFG_TAC_TERRITORY where DISPATCH_TERRITORY_ID= '"+territoryId+"'";
    		DataTable territoryIdTable = new DataTable();
    		territoryIdTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (!(territoryIdTable.Rows.Count == 0)) {
    		    if (territoryIdTable.Rows[0][0].ToString() != (enable ? "TRUE":"FALSE"))
    			{
    				qry = "Update CDMS.CFG_TAC_TERRITORY set ENABLE_TAC = '"+(enable ? "TRUE":"FALSE")+"' where DISPATCH_TERRITORY_ID= '"+territoryId+"'";
    				CDMSDataLoader.ReadOracleDataToTable(qry);
    			}
    			
    		} else {
    			qry = "Insert Into CDMS.CFG_TAC_TERRITORY (DISPATCH_TERRITORY_ID, ENABLE_TAC) VALUES ('"+territoryId+"', '"+(enable ? "TRUE":"FALSE")+"')";
    			CDMSDataLoader.ReadOracleDataToTable(qry);
    		}
    	}
    	
    	/// <summary>
    	/// Gets the list of DRA Config Name and returns it as a Hashset in Ascending Order
    	/// </summary>
    	/// <returns></returns>
    	public HashSet<string> GetDRAConfig()
    	{
    		HashSet<string> DRAConfig = new HashSet<string>();
    		string qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where Active = 'Y' Order by DRA_NAME";
    		DataTable DRAConfigTable = new DataTable();
    		DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (!(DRAConfigTable.Rows.Count == 0)) 
    		{
    			//return a hasset of DRA Names in Ascending order
    			for(int i =0; i<DRAConfigTable.Rows.Count; i++)
    			{
    				DRAConfig.Add(DRAConfigTable.Rows[i][0].ToString());
    			}
    			
    			Ranorex.Report.Success("Returning DRA Config in Ascending Order");
    			return DRAConfig;
    		} else 
    		{
    			Ranorex.Report.Failure("There are no records in DRA Config to return");
    			return null;
    		}
    		
    	}
    	
    	/// <summary>
    	/// Inserts a new entry of DRA Config
    	/// </summary>
    	/// <param name="draName"></param>
    	/// <param name="fromOpsta"></param>
    	/// <param name="toOpsta"></param>
    	/// <param name="fromOpstaDisplay"></param>
    	/// <param name="toOpstaDisplay"></param>
    	/// <param name="fromMP"></param>
    	/// <param name="toMP"></param>
    	/// <param name="fromTerritoryId"></param>
    	/// <param name="toTerritoryId"></param>
    	/// <param name="active"></param>
    	/// <returns></returns>
    	public bool insertDRAConfig(string draName, string fromOpsta, string toOpsta, string fromOpstaDisplay, string toOpstaDisplay, string fromMP, string toMP,
    	                            string fromTerritoryId, string toTerritoryId, string active)
    	{
    		//Validate if the Config is not already present in the table, if not then only Insert new entry
    		string qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where DRA_NAME = '"+draName+"'";
    		DataTable DRAConfigTable = new DataTable();
    		DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (DRAConfigTable.Rows.Count == 0) 
    		{
    			
    			System.DateTime dateTime = System.DateTime.Now.ToUniversalTime();
    			string date = dateTime.ToString("dd-MMM-yy");
    			date = String.Concat(date, " 01:00:00.000000 AM");
    			
    			Ranorex.Report.Info("Date is " +date);
    			qry = "Insert into CDMS.CFG_DRA_CONFIG (DRA_NAME,FROM_OPSTA,TO_OPSTA,FROM_OPSTA_DISPLAY,TO_OPSTA_DISPLAY,FROM_MP,TO_MP,FROM_TERRITORY_ID,TO_TERRITORY_ID,DATE_ADDED,LAST_UPDATED,ACTIVE) " +
    				"values ('"+draName+"','"+fromOpsta+"','"+toOpsta+"','"+fromOpstaDisplay+"','"+toOpstaDisplay+"','"+fromMP+"','"+toMP+"','"+fromTerritoryId+"','"+toTerritoryId+"','"+date+"','"+date+"','"+active+"')";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//Once the entry is inserted validate if the entry exists in table using select statement
    			qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where FROM_OPSTA =  '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"' and FROM_MP = '"+fromMP+"' and TO_MP = '"+toMP+"'";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			if(DRAConfigTable.Rows.Count == 1)
    			{
    				Ranorex.Report.Success("Successfully Inserted new DRA Config");
    				return true;
    			}
    			else 
    			{
    				Ranorex.Report.Failure("Unable to insert new DRA Config");
    				return false;
    			}
    		} else 
    		{
    			Ranorex.Report.Info("DRA Config Already Exists");
    			return false;
    		}
    		
    	}
    	
    	/// <summary>
    	/// Updates the existing DRA Config Opsta and Milepost values 
    	/// </summary>
    	/// <param name="draName"></param>
    	/// <param name="fromOpsta"></param>
    	/// <param name="toOpsta"></param>
    	/// <param name="fromMP"></param>
    	/// <param name="toMP"></param>
    	/// <returns></returns>
    	public bool updateDRAConfig(string draName, string fromOpsta, string toOpsta, string fromMP, string toMP)
    	{
    		//Validate if the dra name is there in the table then only update it
    		string qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where DRA_NAME = '"+draName+"'";
    		DataTable DRAConfigTable = new DataTable();
    		DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (!(DRAConfigTable.Rows.Count == 0)) 
    		{
    			
    			qry = "Update CDMS.CFG_DRA_CONFIG set FROM_OPSTA =  '"+fromOpsta+"' , TO_OPSTA = '"+toOpsta+"' , FROM_MP = '"+fromMP+"' , TO_MP = '"+toMP+"' where DRA_NAME = '"+draName+"'";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//Once the Config is updated then validate if the Config was actually updated with Select statement
    			qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where FROM_OPSTA =  '"+fromOpsta+"' , TO_OPSTA = '"+toOpsta+"' , FROM_MP = '"+fromMP+"' , TO_MP = '"+toMP+"'";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			if(DRAConfigTable.Rows[0][0].ToString().Equals(draName))
    			{
    				Ranorex.Report.Success("Successfully Updated DRA Config for " + draName);
    				return true;
    			}
    			else 
    			{
    				Ranorex.Report.Failure("Unable to Update DRA Config for " + draName);
    				return false;
    			}
    		} else 
    		{
    			Ranorex.Report.Failure("Unable to find DRA Config for " + draName);
    			return false;
    		}
    		
    	}
    	
    	/// <summary>
    	/// Deletes the DRA Config for the Config Name provided
    	/// </summary>
    	/// <param name="draName"></param>
    	/// <returns></returns>
    	public bool deleteDRAConfig(string draName)
    	{
    		//Validate if the DRA Name is already present in the table then only delete the entry
    		string qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where DRA_NAME = '"+draName+"'";
    		DataTable DRAConfigTable = new DataTable();
    		DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (!(DRAConfigTable.Rows.Count == 0)) 
    		{
    			
    			qry = "Delete from CDMS.CFG_DRA_CONFIG where DRA_NAME = '"+draName+"'";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//Once dra entry deleted again validate if it still exists in the table or not
    			qry = "Select DRA_NAME from CDMS.CFG_DRA_CONFIG where DRA_NAME = '"+draName+"'";
    			DRAConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			if(DRAConfigTable.Rows.Count == 0){
    				Ranorex.Report.Success("Successfully Deleted DRA Config for " + draName);
    				return true;
    			}
    			else 
    			{
    				Ranorex.Report.Failure("Unable to delete DRA Config for " + draName);
    				return false;
    			}
    		} else 
    		{
    			Ranorex.Report.Failure("Unable to find the DRA Config for " + draName);
    			return false;
    		}
    		
    	}
    	
    	/// <summary>
    	/// Updating the CFG_COMMON_CONFIG_TAB table to the value provided for the Config Name
    	/// </summary>
    	/// <param name="configName"></param>
    	/// <param name="configValue"></param>
    	/// <returns></returns>
    	public bool updateCFGCommonConfigTab(string configName, string configValue)
    	{
    		//Check in table if the Config exists or not, if exists then only update it, else throw failure
    		string qry = "Select CONFIG_NAME from CDMS.CFG_COMMON_CONFIG_TAB where CONFIG_NAME = '"+configName+"'";
    		DataTable commonConfigTab = new DataTable();
    		commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (commonConfigTab.Rows.Count == 1) 
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.CFG_COMMON_CONFIG_TAB set CONFIG_VALUE = '"+configValue+"' where CONFIG_NAME = '"+configName+"'";
    			commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//Validate if the updated values are present
    			qry = "Select CONFIG_NAME from CDMS.CFG_COMMON_CONFIG_TAB where CONFIG_NAME = '"+configName+"' and CONFIG_VALUE = '"+configValue+"'";
    			commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//If after updating the Config select query returns value then it was successfully updated.
    			if(commonConfigTab.Rows.Count == 1)
    			{
    				Ranorex.Report.Success("Successfully updated Config " + configName);
    				return true;
    			}
    			else 
    			{
    				Ranorex.Report.Failure("Unable to update the Config for value " + configValue);
    				return false;
    			}
    		} else 
    		{
    			Ranorex.Report.Failure("Unable to find the Config for Config Name " + configName);
    			return false;
    		}
    		
    	}
    	
    	/// <summary>
    	/// Updating the CFG_COMMON_CONFIG_TAB table to the value provided for the Config Name
    	/// </summary>
    	/// <param name="configName"></param>
    	/// <param name="configValue"></param>
    	/// <returns></returns>
    	public string GetDRAActionTableComments(string trainKey)
    	{
    		//Retrieve the comments for a TIH train and send it, else throw failure and return null
    		string qry = "Select COMMENTS from CDMS.CFG_DRA_ACTION where TRAIN_KEY = '"+trainKey+"'";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (DRAActionTable.Rows.Count == 1) 
    		{
    			return DRAActionTable.Rows[0][0].ToString();
    		}
    		
    		int retry = 0;
        	while (DRAActionTable.Rows.Count == 0 && retry < 10) 
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
        		Ranorex.Report.Failure("Train not found for train key "+trainKey+" in CDMS Database");
        		return "";
        	}
    		
    	}
    	
    	/// <summary>
    	/// Retrieving the DRA Train Entered Time
    	/// </summary>
    	/// <param name="trainKey">Train Key from the ADMS table</param>
    	/// <returns></returns>
    	public string GetDRAActionTableEnteredTime(string trainKey, string fromOpsta, string toOpsta)
    	{
    		//Retrieve the Entered for a TIH train and send it, else throw failure and return ""
    		string qry = "Select ENTERED from CDMS.CFG_DRA_ACTION where TRAIN_KEY = '"+trainKey+"' and FROM_OPSTA = '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"'";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (DRAActionTable.Rows.Count == 1) 
    		{
    			return DRAActionTable.Rows[0][0].ToString();
    		}
    		
    		int retry = 0;
        	while (DRAActionTable.Rows.Count == 0 && retry < 10) 
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
        		Ranorex.Report.Failure("Train not found for train key "+trainKey+" in CDMS Database");
        		return "";
        	}
    		
    	}
    	
    	/// <summary>
    	/// Retrieving the Projected Time for a Train from the table
    	/// </summary>
    	/// <param name="trainKey">Train Key from the ADMS table</param>
    	/// <returns></returns>
    	public string GetDRAActionTableProjectedTime(string trainKey, string fromOpsta, string toOpsta)
    	{
    		//Retrieve the Projected for a TIH train and send it, else throw failure and return ""
    		string qry = "Select PROJECTED from CDMS.CFG_DRA_ACTION where TRAIN_KEY = '"+trainKey+"' and FROM_OPSTA = '"+fromOpsta+"' and TO_OPSTA = '"+toOpsta+"'";
    		DataTable DRAActionTable = new DataTable();
    		DRAActionTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (DRAActionTable.Rows.Count == 1) 
    		{
    			return DRAActionTable.Rows[0][0].ToString();
    		}
    		
    		int retry = 0;
        	while (DRAActionTable.Rows.Count == 0 && retry < 10) 
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
        		Ranorex.Report.Failure("Train not found for train key "+trainKey+" in CDMS Database");
        		return "";
        	}
    		
    	}
    	
    	/// <summary>
    	/// Updates AR_PASSENGER_HOLD_BACK_ENABLED in CDMS.CFG_COMMON_CONFIG_TAB to desired boolean value.
    	/// </summary>
    	/// <param name="enabled">Enable or Disable AR_PASSENGER_HOLD_BACK_ENABLED</param>
    	/// <returns></returns>
    	public void updateARPassengerHoldBack(bool enabled)
    	{ 		
    		string enabledString = enabled.ToString().ToUpper();
    		string qry = "SELECT CONFIG_VALUE from CDMS.CFG_COMMON_CONFIG_TAB where CONFIG_NAME='AR_PASSENGER_HOLD_BACK_ENABLED'";
    		DataTable ConfigTable = new DataTable();
			qry = "UPDATE CDMS.CFG_COMMON_CONFIG_TAB SET CONFIG_VALUE='"+ enabled +"' where CONFIG_NAME='AR_PASSENGER_HOLD_BACK_ENABLED'";
    		ConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		Ranorex.Delay.Seconds(1);
    		
    		qry = "SELECT CONFIG_VALUE from CDMS.CFG_COMMON_CONFIG_TAB where CONFIG_NAME='AR_PASSENGER_HOLD_BACK_ENABLED'";
    		ConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (ConfigTable.Rows[0][0].ToString().Equals(enabled))
    		{
    		    Ranorex.Report.Info("AR_PASSENGER_HOLD_BACK_ENABLED updated to desired value.");
    		}
    		else
    		{
    			Ranorex.Report.Failure("AR_PASSENGER_HOLD_BACK_ENABLED unsuccessfully updated. Current configuration: {"+ConfigTable.Rows[0][0].ToString()+"}.");
    		}
    	}
    	
    	/// <summary>
    	/// Updates AR_SIDING_SIGNAL_CLEAR_TIME in CDMS.CFG_COMMON_CONFIG_TAB to desired boolean value.
    	/// </summary>
    	/// <param name="clearTime">New Siding Signal Clear Time in seconds.</param>
    	/// <returns></returns>
    	public void updateARSidingSignalClearTime(int clearTime)
    	{ 		
    		string clearTimeString = clearTime.ToString();
    		string qry = "SELECT CONFIG_VALUE from CDMS.CFG_COMMON_CONFIG_TAB where CONFIG_NAME='AR_SIDING_SIGNAL_CLEAR_TIME'";
    		DataTable ConfigTable = new DataTable();
    		ConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
    		int retry = 0;
    		while (!ConfigTable.Rows[0][0].ToString().Equals(clearTimeString) || retry > 5)
    		{
    			qry = "UPDATE CDMS.CFG_COMMON_CONFIG_TAB SET CONFIG_VALUE='"+clearTimeString+"' where CONFIG_NAME='AR_SIDING_SIGNAL_CLEAR_TIME'";
	    		ConfigTable = CDMSDataLoader.ReadOracleDataToTable(qry);
	    		Ranorex.Delay.Seconds(1);
    		}
    		
    		//Try one last time
    		if (!ConfigTable.Rows[0][0].ToString().Equals(clearTimeString))
    		{
    		    Ranorex.Report.Failure("AR_SIDING_SIGNAL_CLEAR_TIME unsuccessfully updated. Current configuration: {"+ConfigTable.Rows[0][0].ToString()+"}.");
				return;
    		}
    		
    		Ranorex.Report.Info("AR_SIDING_SIGNAL_CLEAR_TIME successfully updated.");
    		
    	}
    	
    	/// <summary>
    	/// Updating the TNS_TRACKING_CFG_TAB table to the value provided for the Config Name
    	/// </summary>
    	/// <param name="configName"></param>
    	/// <param name="configValue"></param>
    	/// <returns></returns>
    	public bool UpdateTrackingParameters(string configName, string configValue)
    	{
    		//Check in table if the Config exists or not, if exists then only update it, else throw failure
    		string qry = "Select CONFIG_NAME from CDMS.TNS_TRACKING_CFG_TAB where CONFIG_NAME = '"+configName+"'";
    		DataTable commonConfigTab = new DataTable();
    		commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    		if (commonConfigTab.Rows.Count == 1) 
    		{
    			//Update the Config with the value provided
    			qry = "Update CDMS.TNS_TRACKING_CFG_TAB set CONFIG_VALUE = '"+configValue+"' where CONFIG_NAME = '"+configName+"'";
    			commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//Validate if the updated values are present
    			qry = "Select CONFIG_NAME from CDMS.TNS_TRACKING_CFG_TAB where CONFIG_NAME = '"+configName+"' and CONFIG_VALUE = '"+configValue+"'";
    			commonConfigTab = CDMSDataLoader.ReadOracleDataToTable(qry);
    			
    			//If after updating the Config select query returns value then it was successfully updated.
    			if(commonConfigTab.Rows.Count == 1)
    			{
    				Ranorex.Report.Success("Successfully updated Config " + configName);
    				return true;
    			}
    			else 
    			{
    				Ranorex.Report.Failure("Unable to update the Config for value " + configValue);
    				return false;
    			}
    		} else 
    		{
    			Ranorex.Report.Failure("Unable to find the Config for Config Name " + configName);
    			return false;
    		}
    		
    	}
    	
    }
}
