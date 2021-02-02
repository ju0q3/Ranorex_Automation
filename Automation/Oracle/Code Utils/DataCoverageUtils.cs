/*
 * Created by Ranorex
 * User: r07000021
 * Date: 10/25/2017
 * Time: 2:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Collections.Generic;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess;

using System.Linq;
using Ranorex.Core.Data;

namespace Oracle.Code_Utils
{
	/// <summary>
	/// Description of DataCoverageUtils.
	/// </summary>
	public class DataCoverageUtils
	{
		public DataCoverageUtils()
		{
			
		}
		
		/// <summary>
		/// Wrapper function for linq query to find DataCache from active test suite's known data connections
		/// </summary>
		/// <param name="currentCache">Current TestSuite DataCache Passed To Static Method</param>
		/// <param name="name">Name of DataConnection we're looking for</param>
		/// <returns>Reference to DataCache object searched for</returns>
		public static DataCache getCache(IList<DataCache> currentCache, string name) 
		{
        	DataCache seek = null;
        	try 
        	{
        		seek = currentCache.OfType<DataCache>()
	        		.Where(con => con.Connector != null)
	            	.Where(con => con.Connector.Name == name)
	            	.FirstOrDefault();
     
        	}
        	catch(Exception) {
        		Console.WriteLine("Unalbe to find cached connector " + name);
        	}
        
        	if(seek == null) throw new ArgumentException("Unknown configuration for dynamic data : " + name);
        	return seek;
        }
		
			
		public DataTable getRapidRoutesByControlPoint(int controlPointID) 
		{
			var ctx = new OracleConnectionContext("tduser", "TrackMap2", "CNTDMS"); 
			DataLoader dl = new DataLoader(ctx);

			var rrquery = @"			
with
lrs_max_section as (
select 
lrs.project_id, 
lrs.project_version, 
lrs.lamp_route_id, 
lrs.section_id
from dv_lamp_route_section lrs
 where  (lrs.project_id, lrs.project_version, lrs.lamp_route_id, lrs.section_sequence) in (select x.project_id, x.project_version, x.lamp_route_id, max(x.section_sequence) from dv_lamp_route_section x group by x.project_id, x.project_version, x.lamp_route_id)    
)
select 
    lr.lamp_route_id,
    l.lamp_id, 
    l.lamp_name, 
    s.control_point_id,
    lrs.section_id as endpoint
from 
dv_lamp_route lr
join dv_lamp l on
    l.project_id = lr.project_id
    and l.project_version = lr.project_version
    and l.lamp_id = lr.lamp_id
join dv_signal s on
    s.project_id = l.project_id
    and s.project_version = l.project_version
    and s.signal_id = l.primary_signal_id   
join lrs_max_section lrs on
    lrs.project_id = l.project_id 
    and lrs.project_version = l.project_version 
    and lrs.lamp_route_id = lr.lamp_route_id      
join cm_label_project lb on
    lb.project_id = l.project_id
    and lb.project_version = l.project_version
--left join te_dispatch_view_striplet     
where label_id = (select target_label_id from cdms.ff_tls_config_params)     
and control_point_id = :control_point_id
";
				
			List<OracleParameter> prms =  new List<OracleParameter>();
			
			OracleParameter param = new OracleParameter(":control_point_id", 
                                                            OracleDbType.Int32,
                                                            controlPointID, 
                                                            ParameterDirection.Input);
			prms.Add(param);
			return dl.ReadOracleDataToTable(rrquery, prms);
		
		}
	}
}
