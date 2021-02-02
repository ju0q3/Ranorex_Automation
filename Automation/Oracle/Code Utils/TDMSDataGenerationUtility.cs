/*
 * Created by Ranorex
 * User: 210058208
 * Date: 10/3/2018
 * Time: 2:57 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Data;
using System.Linq;
using WinForms = System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Oracle.Code_Utils
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public partial class TDMSDataGenerationUtility
    {            		
    	/// <summary>
    	/// Sheet locations and enrichment data store files
    	/// </summary>
		private const string EMT_DATA_SHEET = "EMT_Data";
		private const string DOT_DATA_SHEET = "Temp_DOT";	
		private const string PSS_DATA_SHEET = "PSS_Data";	
		private const string DUAL_MP_GBO_DATA_SHEET = "Temp_Double_MP";
		
		private const string ROUTE_MAP = "data\\DataTesting\\DispatchRouteMap.xml";
    	
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        public TDMSDataGenerationUtility() {        	
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="SqlConneciton"></param>
        [UserCodeMethod]
        //TODO: fix method signature, connection spelt wrong
        public static void PopulateEMTDataFromTDMS(string subdiv, string SqlConneciton) {        	
        	var query = String.Format(@"
SELECT
    DIV.DIVISION_NAME AS ""Division"",
    DIS.DISTRICT_NAME AS ""Subdivision"",
    DT.DISPATCH_TERRITORY_NAME AS ""Territory"",
    null as ""Train Schedule OPSTA 1"",
    null as ""Train Schedule OPSTA 2"",
    TS.SECTION_ID AS ""Track Section"",
    NL.MP_PREFIX || NL.MP_NUMBER || NL.MP_SUFFIX AS ""Milepost""
FROM 
    TDMS.TP_NAMED_LOCATION NL
JOIN TDMS.CM_LABEL_PROJECT LP ON
    LP.PROJECT_ID = NL.PROJECT_ID
    AND LP.PROJECT_VERSION = NL.PROJECT_VERSION
JOIN TDMS.CM_LABEL LAB ON
    LP.LABEL_ID = LAB.LABEL_ID
JOIN CDMS.FF_TLS_CONFIG_PARAMS FFU ON
    LP.LABEL_ID = FFU.CURRENT_LABEL_ID
JOIN TDMS.TP_TRACK_SECTION TS ON
    LP.PROJECT_ID = TS.PROJECT_ID
    AND LP.PROJECT_VERSION = TS.PROJECT_VERSION
    AND NL.SECTION_ID = TS.SECTION_ID
JOIN TDMS.CD_DISTRICT DIS ON
    LAB.CONFIG_VERSION = DIS.CONFIG_VERSION
    AND TS.DISTRICT_ID = DIS.DISTRICT_ID
JOIN TDMS.CD_DIVISION DIV ON
    LAB.CONFIG_VERSION = DIV.CONFIG_VERSION
    AND DIV.DIVISION_ID = DIS.DIVISION_ID
JOIN TDMS.CD_DISPATCH_TERRITORY DT ON
    LAB.CONFIG_VERSION = DT.CONFIG_VERSION
    AND TS.DISPATCH_TERRITORY_ID = DT.DISPATCH_TERRITORY_ID
WHERE 
    dis.district_name = :district_name
    and NL.EMT_ONLY = 1
order by DT.DISPATCH_TERRITORY_NAME", subdiv);
        	
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConneciton);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			string filename = getCsvFileNameForConnector(EMT_DATA_SHEET);
			
			if(dt.Rows.Count == 0)
				Report.Error("No return data from database");
			
			//enrichment to do train routes
			AddTrainRoutesToDt(dt, "Territory", "Train Schedule OPSTA 1", "Train Schedule OPSTA 2");
			DataTableToCSV(dt, filename);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void PopulateDOTDataFromTDMS(string subdiv, string SqlConnection) {
        	var query = String.Format(@"
SELECT
    DIV.DIVISION_NAME AS DISIVIONS,
    DIS.DISTRICT_NAME AS SUBDIVISION,
    DT.DISPATCH_TERRITORY_NAME AS TERRITORY,
    '' as ""Train Schedule OPSTA 1"",
    '' as ""Train Schedule OPSTA 2"",
    HCAG.DEPT_OF_TRANSPORTATION_NAME AS DOT
FROM 
    TDMS.TPM_HIGHWAY_CROSSING_AT_GRADE HCAG
JOIN TDMS.CM_LABEL_PROJECT LP ON
    LP.PROJECT_ID = HCAG.PROJECT_ID
    AND LP.PROJECT_VERSION = HCAG.PROJECT_VERSION
JOIN TDMS.CM_LABEL LAB ON
    LP.LABEL_ID = LAB.LABEL_ID
JOIN CDMS.FF_TLS_CONFIG_PARAMS FFU ON
    LAB.LABEL_ID = FFU.CURRENT_LABEL_ID
JOIN TDMS.TP_TRACK_SECTION TS ON
    LP.PROJECT_ID = TS.PROJECT_ID
    AND LP.PROJECT_VERSION = TS.PROJECT_VERSION
    AND HCAG.SECTION_ID = TS.SECTION_ID
JOIN TDMS.CD_DISTRICT DIS ON
    LAB.CONFIG_VERSION = DIS.CONFIG_VERSION
    AND TS.DISTRICT_ID = DIS.DISTRICT_ID
JOIN TDMS.CD_DIVISION DIV ON
    LAB.CONFIG_VERSION = DIV.CONFIG_VERSION
    AND DIS.DIVISION_ID = DIV.DIVISION_ID
JOIN TDMS.CD_DISPATCH_TERRITORY DT ON
    LAB.CONFIG_VERSION = DT.CONFIG_VERSION
    AND TS.DISPATCH_TERRITORY_ID = DT.DISPATCH_TERRITORY_ID
where dis.district_name = :district_name 
order by DT.DISPATCH_TERRITORY_NAME, DIS.DISTRICT_NAME", subdiv);   

        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			string filename = getCsvFileNameForConnector(DOT_DATA_SHEET);
			
			if(dt.Rows.Count == 0) {
				Report.Error("No return data from database");
			} else {
				//enrichment to do train routes
				AddTrainRoutesToDt(dt, "TERRITORY", "Train Schedule OPSTA 1", "Train Schedule OPSTA 2");
				DataTableToCSV(dt, filename);
			}
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void PopulateDoubleMPGBODataFromTDMS(string subdiv, string SqlConnection) {
        	var query = @"
select 
    div.division_name as ""Division"", 
    dist.district_name as ""Subdivision"", 
    dt.dispatch_territory_name as ""Territory"", 
    '' as ""Train Schedule OPSTA 1"",
    '' as ""Train Schedule OPSTA 2"",
    round(mp.from_mp_number,2) as ""MilePost"", 
    round(mp.to_mp_number,2) as ""Milepost2"",
    nt.named_track_name as ""Track(s)"" 
from 
tp_named_track nt  
join tp_track_mp_range mp on
    nt.named_track_id = mp.named_track_id
    and nt.project_id = mp.project_id
    and nt.project_version = mp.project_version
left join TP_NAMED_TRACK_SECTION nts on 
    nts.named_track_id = mp.named_track_id
    and nts.project_id = mp.project_id
    and nts.project_version = mp.project_version
    and nts.TIMETABLE_SEQ = 0
join tp_named_track nt on
     nt.named_track_id = mp.named_track_id
    and nt.project_id = mp.project_id
    and nt.project_version = mp.project_version   
join tp_track_section ts on 
    ts.section_id = nts.section_id
    and ts.project_id = nts.project_id
    and ts.project_version = nts.project_version
join cm_label_project lb on
    lb.project_id = mp.project_id
    and lb.project_version = mp.project_version
join cdms.ff_tls_config_params on
    target_label_id = lb.label_id
join cm_label l on 
    l.label_id = lb.label_id
join cd_district dist on 
    dist.config_version = l.config_version
    and dist.district_id = ts.district_id
join cd_division div on 
    div.config_version = l.config_version    
    and div.division_id = dist.division_id
join cd_dispatch_territory dt on
    dt.config_version = l.config_version 
    and dt.dispatch_territory_id = ts.dispatch_territory_id   
where district_name = :district_name
and nt.named_track_type = 'MAIN'
and nt.named_track_name not like '%XOVER' ";
        	
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
        	
        	string filename = getCsvFileNameForConnector(DUAL_MP_GBO_DATA_SHEET);
        	
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0) {
				Report.Error("No return data from database");
			} else {
				//enrichment to do train routes
				AddTrainRoutesToDt(dt, "TERRITORY", "Train Schedule OPSTA 1", "Train Schedule OPSTA 2");
				DataTableToCSV(dt, filename);
			} 
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchViewName"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void populateRapidRouteDataFromTDMS(string dispatchViewName, string SqlConnection) {
        	
            var query = @"
select
    lr.lamp_route_id, l.lamp_id, l.lamp_name, s.control_point_id, lrs.section_id as endpoint, dv.dispatch_view_name, terr.dispatch_territory_name
from 
dv_lamp_route lr
join dv_lamp l on
    l.project_id = lr.project_id and l.project_version = lr.project_version and l.lamp_id = lr.lamp_id
join dv_signal s on
    s.project_id = l.project_id and s.project_version = l.project_version and s.signal_id = l.primary_signal_id   
join (
    select 
    lrs.project_id, lrs.project_version, lrs.lamp_route_id, lrs.section_id
    from dv_lamp_route_section lrs
     where  (lrs.project_id, lrs.project_version, lrs.lamp_route_id, lrs.section_sequence) 
     in (select x.project_id, x.project_version, x.lamp_route_id, max(x.section_sequence) 
            from dv_lamp_route_section x group by x.project_id, x.project_version, x.lamp_route_id)
) lrs on
    lrs.project_id = l.project_id 
    and lrs.project_version = l.project_version 
    and lrs.lamp_route_id = lr.lamp_route_id
join cm_label_project lb on
    lb.project_id = l.project_id
    and lb.project_version = l.project_version
join cm_label lbl on
    lb.label_id = lbl.label_id    
join cd_dispatch_territory terr on
    terr.dispatch_territory_id = l.controlling_disp_terr_id
    and terr.config_version = lbl.config_version       
join TE_STRIPLET_OBJECT tso on
    tso.project_id = lr.project_id
    and tso.project_version = lr.project_version
    and tso.object_id = lr.lamp_id
join TE_DISPATCH_VIEW_STRIPLET dvs on
    dvs.striplet_project_id = tso.project_id 
    and dvs.striplet_project_version = tso.project_version 
    and dvs.striplet_id = tso.striplet_id
join TE_DISPATCH_VIEW dv on
    dv.project_id = dvs.project_id 
    and dv.project_version = dvs.project_version 
    and dv.dispatch_view_id = dvs.dispatch_view_id
where 
lbl.label_id = (select target_label_id from cdms.ff_tls_config_params)     
and dv.dispatch_view_name = :dispatch_view_name 
and OP_SIGNAL_CLEAR = 1
order by s.control_point_id";
            	
            //added op signal clear to reduce false positives from indicating only signals
            //added order by to make the test jump around less. makes you sick trying to watch it lol
            
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":dispatch_view_name", OracleDbType.Varchar2, dispatchViewName, ParameterDirection.Input)
        	};
        	
        	string filename = getCsvFileNameForConnector("DataTest_RR");
        	
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0) {
				Report.Error("No return data from database");
			} else {
				//enrichment to do train routes
				DataTableToCSV(dt, filename);
			} 
			
			
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void populateGBODataFor1103TestFromTDMS(string subdiv, string SqlConnection) {
        	            var query = @"
select 
    'TSO 1103 for an area' as ""Type"",
    'automation' as ""requestedBy"",
    ROUND(mp.FROM_MP_NUMBER, 2) as ""firstLimit"",
    ROUND(mp.TO_MP_NUMBER, 2) as ""secondLimit"",
    nt.named_track_name as ""tracks"",
    'comments of 1103 Area' as ""comments"", 
    DIV.DIVISION_ABBREVIATION || ' - ' || d.district_name as ""SubDivision"",
    ' ' as ""feedbackText"", 
    1 as ""maxMphFreight"",
    1 as ""maxMphPassenger"",
    'AC - ALIGNMENT CONDITION' as ""reasonCode"",
    decode(mp.prohibit_bulletin, 0, 'FALSE', 1, 'TRUE') as ""nonControlledTrack""
FROM TP_NAMED_TRACK nt
JOIN TP_TRACK_SECTION mp on
    nt.NAMED_TRACK_ID = mp.NAMED_TRACK_ID
    and mp.project_id = nt.project_id 
    and mp.project_version = nt.project_version
join TDMS.CM_LABEL_PROJECT lb on
    lb.project_id = nt.project_id
    and lb.project_version = nt.project_version
join TDMS.CM_LABEL l on 
    l.label_id = lb.label_id     
join TDMS.CD_DISTRICT d on 
    d.config_version = l.config_version
    and d.district_id = mp.district_id
join TDMS.CD_DIVISION div on 
    div.config_version = d.config_version
    and div.division_id = d.division_id
WHERE 
	mp.PROHIBIT_BULLETIN = 0
	and lb.label_id = (select target_label_id from CDMS.FF_TLS_CONFIG_PARAMS)
	and d.district_name = :district_name
ORDER BY mp.FROM_MP_NUMBER ";

            	
            //added op signal clear to reduce false positives from indicating only signals
            //added order by to make the test jump around less. makes you sick trying to watch it lol
            
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
        	
        	string filename = getCsvFileNameForConnector("GBO_TSO1103Area_Data");
        	
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0) {
				Report.Error("No return data from database");
			} else {
				//enrichment to do train routes
				DataTableToCSV(dt, filename);
			} 
        }

        /// <summary>
        /// Takes a datatable object and runs a match through DispatchRouteEnrichmentMap to determine 
        /// if more information needs to be added to query for train routes
        /// </summary>
        /// <param name="dt">DataTable that needs to be updated wtihout extra data</param>
        /// <param name="column_match">The column to match the info to (Territory of Subdiv)</param>
        /// <param name="column_opsta1">The first leg of the route (opsta 1)</param>
        /// <param name="column_opsta2">The last leg of the route (opsta 2)</param>
        /// <returns></returns>
        public static void AddTrainRoutesToDt(DataTable dt, String column_match, String column_opsta1, String column_opsta2) {
        	var routeMap = DispatchRouteEnrichmentMap.GetFromFile(ROUTE_MAP);
        	
        	//set all the columns to writeable
        	foreach (DataColumn col in dt.Columns) col.ReadOnly = false; 
        	dt.Columns[column_opsta1].MaxLength = 10;
			dt.Columns[column_opsta2].MaxLength = 10;        	
        	
        	foreach(DataRow r in dt.Rows) {
        		//if i can find a row in DispatchRouteEnrichmentMap that has this...
        		
        		DispatchRoute lookup = routeMap
        			.RouteMap
        			.Where(t => t.Territory == r[column_match].ToString())
        			.First();
        		
        		if(lookup != null) {
        			r[column_opsta1] = lookup.TerritoryRoute.StartOPTSA;
        			r[column_opsta2] = lookup.TerritoryRoute.EndOPSTA;
        		}
    		}
        	
        }
        
                
        public static string getCsvFileNameForConnector(string connector) {
		    //get the file name from our connector
		    var testdata = Oracle.Code_Utils.DataCoverageUtils.getCache(TestSuite.Current.DataConnectorCaches, connector);
		    Ranorex.Core.Data.FileDataConnector filedata =  ((Ranorex.Core.Data.FileDataConnector)testdata.Connector);
		    
		    return filedata.ResolvedFileName;
        }
        
	    public static void DataTableToCSV(DataTable dt, string filename) {
	    	StringBuilder sb = new StringBuilder(); 
			
			IEnumerable<string> columnNames = dt.Columns
				.Cast<DataColumn>()
				.Select(column => column.ColumnName);
			
			sb.AppendLine(string.Join(",", columnNames));
			
			foreach (DataRow row in dt.Rows)
			{
			    IEnumerable<string> fields = row
			    	.ItemArray
			    	.Select(field => field.ToString());
			    
			    sb.AppendLine(string.Join(",", fields));
			}
			
			try 
			{
				System.IO.File.WriteAllText(filename, sb.ToString());
			} 
			catch(Exception ex) 
			{
				Report.Error(ex.Message);
			}
	
	    }
        
    }
   
    

}
