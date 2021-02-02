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
    public partial class TDMSDataGenerationUtility
    {  
    	       
        public static DataTable populateFBABaseNetworkDataFromTDMS(string subdiv, string SqlConnection) {
        	var query = @"
with stations as (
    select st.*, sal.section_id from 
    cm_label_project lb
    join cdms.ff_tls_config_params ff on 
        ff.target_label_id = lb.label_id
    join tp_station_authority_location sal on 
        sal.project_id = lb.project_id
        and sal.project_version = lb.project_version 
    join tp_station st on 
        st.station_id = sal.station_id
        and st.project_id = sal.project_id
        and st.project_version = sal.project_version
        and st.AUTHORITY_ENABLE = 1   
)
select
	ts.section_id, ts.low_normal_section_id, ts.low_reverse_section_id, ts.high_normal_section_id, ts.high_reverse_section_id,
	nt.named_track_type, 
	'' as authority_territory_type, 
	'' as misc_authority_territory_type, 
	dist.district_id, dist.district_name,
	div.division_id, div.division_name, 
	dt.dispatch_territory_id, dt.dispatch_territory_name,
	nvl(ts.station_id, st.station_id) as station_id,
	nvl(st1.display_name, st.display_name) as station_name,
	--altered to display name to avoid FBA form issues
	--nvl(st1.station_name, st.station_name) as station_name,
	nvl(st1.station_identifier, st.station_identifier) as station_identifier,
	nt.named_Track_name
from 
tp_track_section ts
join tp_named_track nt on
    nt.named_Track_id = ts.named_track_id
    and nt.project_id = ts.project_id
    and nt.project_version = ts.project_version 
left join stations st on 
    st.section_id = ts.section_id    
left join tp_station st1 on 
    st1.station_id = ts.station_id
    and st1.project_id = ts.project_id
    and st1.project_version = ts.project_version
join cm_label_project lb on
    lb.project_id = ts.project_id
    and lb.project_version = ts.project_version
join cm_label l on
    l.label_id = lb.label_id
join cd_dispatch_territory dt on 
    dt.dispatch_territory_id = ts.dispatch_territory_id
    and dt.config_version = l.config_version
join cd_district dist on 
    dist.district_id = ts.district_id
    and dist.config_version = l.config_version
join cd_division div on 
    div.division_id = dist.division_id
    and div.config_version = l.config_version
where l.label_id = (select target_label_id from cdms.ff_tls_config_params)    ";
        	
        	
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	DataTable dt =  dl.ReadOracleDataToTable(query, new List<OracleParameter>() /* prms */);
        	/*
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
        	*/
        	
        	return dt; 
        }
    }
}
