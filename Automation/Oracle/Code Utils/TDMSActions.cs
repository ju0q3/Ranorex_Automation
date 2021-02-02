/*
 * Created by Ranorex
 * User: r07000021
 * Date: 11/30/2018
 * Time: 8:43 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Data;

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
    public class TDMSActions
    {
    	private Oracle.Code_Utils.DataLoader TDMSDataLoader;
    	
    	public TDMSActions(string dbPw, string user)
		{
    		VMEnvironment vm = VMEnvironment.Instance();
        	string dbUsername = vm.dbUser;
        	if(!string.IsNullOrEmpty(dbUsername))
        	{
        		TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Code_Utils.OracleConnectionContext(dbUsername, dbPw, user));
        	}
        	else
        	{
        		TDMSDataLoader = new Oracle.Code_Utils.DataLoader(new Code_Utils.OracleConnectionContext("TDMS", dbPw, user));
        	}
        	 
		}
    	
    	/// <summary>
    	/// Gets the track section via the Id from the UI element above it.
    	/// Useful for finding what track section a train is currently on.
    	/// </summary>
    	/// <param name="trackLabelId">Id of the ui element above a track section</param>
        public string GetSectionIdfromAssociatedTrackLabel(string trackLabelId)
        {
        	//Query pulls the last associated clearance number. If the train no longer has a train id, the last one will be populated. If the train never had a clearance, no results will be populated
        	string qry = "Select SECTION_ID from TDMS.TP_TRACK_SECTION where TRACK_LABEL_SYMBOL_ID= '"+trackLabelId+"' order by PROJECT_ID desc, PROJECT_VERSION desc fetch FIRST 1 rows only";
        	DataTable trackSection = new DataTable();
        	trackSection = TDMSDataLoader.ReadOracleDataToTable(qry);
        	if (!(trackSection.Rows.Count == 0)) {
        		return trackSection.Rows[0][0].ToString();
        	} else {
        		Ranorex.Report.Failure("Track Section Number not found for Track Label Id {"+trackLabelId+"} in TDMS Database");
        		return "";
        	}
        }
        
        /// <summary>
    	/// Gets the track section via the Id from the UI element above it.
    	/// Useful for finding what track section a train is currently on.
    	/// </summary>
    	/// <param name="trackSectionId">Id of the ui element below the track label id</param>
        public string GetTrackLabelfromAssociatedTrackSectionId(string trackSectionId)
        {
        	//Query pulls the last associated clearance number. If the train no longer has a train id, the last one will be populated. If the train never had a clearance, no results will be populated
        	string qry = "Select TRACK_LABEL_SYMBOL_ID from TDMS.TP_TRACK_SECTION where SECTION_ID= '"+trackSectionId+"' order by PROJECT_ID desc, PROJECT_VERSION desc fetch FIRST 1 rows only";
        	DataTable trackLabel = new DataTable();
        	trackLabel = TDMSDataLoader.ReadOracleDataToTable(qry);
        	if (!(trackLabel.Rows.Count == 0)) {
        		return trackLabel.Rows[0][0].ToString();
        	} else {
        		Ranorex.Report.Failure("Track Label ID not found for Track Section Id {"+trackSectionId+"} in TDMS Database");
        		return "";
        	}
        }
        
        public string GetTerritoryIdFromTerritoryName(string territoryName)
        {
        	
        	string qry = "Select TERRITORY_ID from TDMS.TERRITORY_MV where TERRITORY_NAME= '"+territoryName+"'";
        	DataTable territoryId = new DataTable();
        	territoryId = TDMSDataLoader.ReadOracleDataToTable(qry);
        	if (!(territoryId.Rows.Count == 0)) {
        		return territoryId.Rows[0][0].ToString();
        	} else {
        		return "";
        	}
        }
        
    }
}
