/*
 * Created by Ranorex
 * User: 210058208
 * Date: 10/18/2018
 * Time: 9:06 AM
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
	/// Description of TDMSData_PSS.
	/// </summary>
	public partial class TDMSDataGenerationUtility
	{
		
		/// <summary>
		/// ODP parametereized query to refresh data in csv used by recording modules in 
		/// data content based regression testing.
		/// </summary>
		/// <param name="subdiv">subdivision name to filter results</param>
		/// <param name="SqlConnection">standard ODP.NET connection string for access to TDMS.
		/// 	see https://www.connectionstrings.com/oracle-data-provider-for-net-odp-net/ for examples
		/// </param>
        [UserCodeMethod]
        public static void PopulatePSSDataFromTDMS(string subdiv, string SqlConnection) {  
        	var query = String.Format(@"
with 
switch_legs as (
    select lamp_route_id, legtype, lrs.section_id, section_sequence, switch_point_id
    from
    DV_LAMP_ROUTE_REPAIR lrs
    join DV_SWITCHPOINT_SECTION sps on
        sps.project_id = lrs.project_id 
        and sps.project_version = lrs.project_version
        and sps.section_id = lrs.section_id
    join cm_label_project lb on
        lb.project_id = lrs.project_id
        and lb.project_version = lrs.project_version
        and lb.label_id = lrs.label_id
    join cdms.ff_tls_config_params ff on
        ff.target_label_id = lrs.label_id
    where
        --no leading legs needed 
        legtype <> 'L'
),
/* 
dependent on switch_legs, listagg the switches needed to be in place for lamp route to succeed
*/
switches_to_move as (
    select 
        sl.lamp_route_id,
        (select 
            listagg(switch_point_id, '|') within group (order by section_sequence asc)
            from switch_legs 
            where legtype = 'R'
            and lamp_route_id = sl.lamp_route_id 
            group by lamp_route_id, legtype) as ""Set Manual Switch Reverse"",
        (select 
            listagg(switch_point_id, '|') within group (order by section_sequence asc)
            from switch_legs 
            where legtype = 'N' 
            and lamp_route_id = sl.lamp_route_id
            group by lamp_route_id, legtype) as ""Set Manual Switch Normal""
    from switch_legs sl
),
/*
Lamp Route Section info view
*/
lamp_route_sections as ( 
select lrr.*, lr.lamp_id
from 
dv_lamp_route lr
join DV_LAMP_ROUTE_REPAIR lrr on
    lrr.lamp_route_id = lr.lamp_route_id
    and lrr.project_id = lr.project_id
    and lrr.project_version = lr.project_version
join cm_label_project lb on
    lb.project_id = lrr.project_id
    and lb.project_version = lrr.project_version
    and lb.label_id = lrr.label_id
join cdms.ff_tls_config_params ff on
    ff.target_label_id = lrr.label_id
),
route_names as 
(
    select lrs.*, 
    ts.section_id as first_section_id, 
    ts.named_track_id as first_section_nt,
    sec0.from_mp_number, 
    sec0.to_mp_number,
    sec0.section_id as before_section_id,
    sec0.named_track_id as before_section_nt,
    secN.section_id as last_section_id,
    secN.named_track_id as last_section_nt,  
    ts.district_id, 
    ts.dispatch_territory_id
    from (
        select distinct project_id, project_version, lamp_route_id, lamp_id, 
        first_value(section_id) over (partition by lamp_route_id order by section_sequence) as first_section,
        first_value(section_id) over (partition by lamp_route_id order by section_sequence desc) as last_section
        from lamp_route_sections
    ) lrs
    join dv_lamp l on 
        l.lamp_id = lrs.lamp_id
        and l.project_id = lrs.project_id
        and l.project_version = lrs.project_version
    join tp_track_section ts on 
        ts.section_id = first_section
        and ts.project_id = lrs.project_id
        and ts.project_version = lrs.project_version
    join tp_track_section sec0 on
        --section_id = ...
        case 
            when l.section_offset = 0 and sec0.section_id = ts.low_normal_section_id then 1
            when l.section_offset > 0 and sec0.section_id = ts.high_normal_section_id then 1 
        else 0 end = 1  
        and sec0.project_id = ts.project_id
        and sec0.project_version = ts.project_version
    join tp_track_section secN on
        secN.section_id = last_section
        and secN.project_id = ts.project_id
        and secN.project_version = ts.project_version
),

/*
Main Content of the query
*/
lr_info as (
    select 
        div.division_name, 
        dist.district_name, 
        dt.dispatch_Territory_name, 
        lrr.lamp_id as ""Signal ID"",
        lrr.lamp_route_id,
        st.display_name,
        nt0.named_track_name as ""Train Track"",
        nt1.named_track_name as ""PSS Track 1"",
        ntN.named_track_name as ""PSS Track 2"",
        from_mp_number, 
        to_mp_number,
        case 
            when l.TIMETABLE_DIRECTION = 'N' then 'NORTH'
            when l.TIMETABLE_DIRECTION = 'S' then 'SOUTH'
            when l.TIMETABLE_DIRECTION = 'E' then 'EAST'
            when l.TIMETABLE_DIRECTION = 'W' then 'WEST'
        end as direction
    from 
    route_names lrr
    join cm_label_project lb on
        lb.project_id = lrr.project_id
        and lb.project_version = lrr.project_version
        --and lb.label_id = lrr.label_id
    join dv_lamp l on 
        l.lamp_id = lrr.lamp_id
        and l.project_id = lb.project_id
        and l.project_version = lb.project_version
    join tp_station st on 
        st.station_id = l.logging_station_id
        and st.project_id = l.project_id
        and st.project_version = l.project_version 
    join cdms.ff_tls_config_params ff on
        ff.target_label_id = lb.label_id
    join cm_label lb on 
        lb.label_id = ff.target_label_id    
    join cd_district dist on 
        dist.district_id = lrr.district_id
        and dist.config_version = lb.config_version
    join cd_division div on 
        div.division_id = dist.division_id
        and div.config_version = dist.config_version
    join cd_dispatch_territory dt on 
        dt.dispatch_territory_id = lrr.dispatch_territory_id 
        and dt.config_version = lb.config_version
        
    join tp_named_track nt1 on
        nt1.named_track_id = lrr.first_section_nt
        and nt1.project_id = lrr.project_id
        and nt1.project_version = lrr.project_version    
    join tp_named_track nt0 on
        nt0.named_track_id = before_section_nt
        and nt0.project_id = lrr.project_id
        and nt0.project_version = lrr.project_version    
    join tp_named_track ntN on
        ntN.named_track_id = last_section_nt
        and ntN.project_id = lrr.project_id
        and ntN.project_version = lrr.project_version
       
    where district_name = :district_name
),

/*
List Aggregator for the sections in lamp route
*/
lr_aggregator as (
    select
        lamp_route_id, 
        listagg(section_id, '|') within group (order by section_sequence asc) as ""Track Section(s)"" 
    from lamp_route_sections group by lamp_route_id
)
select
    division_name as ""Division"", 
    district_name as ""Subdivision"", 
    dispatch_Territory_name as ""Territory"",
    '' as  ""Train Schedule OPSTA 1"",
    '' as ""Train Schedule OPSTA 2"", 
    from_mp_number as ""Train Milepost"", 
    --to_mp_number,
    ""Train Track"",
    ""Signal ID"",
    ""Track Section(s)"",
    display_name as ""Signal Station Name"",
    ""PSS Track 1"",
    ""PSS Track 2"",
    direction as ""PSS Direction"",
    ""Set Manual Switch Reverse"",
    ""Set Manual Switch Normal""
from 
lr_aggregator la 
join lr_info lri on 
    lri.lamp_route_id = la.lamp_route_id
join switches_to_move stm on 
    stm.lamp_route_id = lri.lamp_route_id
where district_name = :district_name
order by lri.lamp_route_id");
        	
        	Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);
        	
        	List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":district_name", OracleDbType.Varchar2, subdiv, ParameterDirection.Input)
        	};
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			string filename = getCsvFileNameForConnector(PSS_DATA_SHEET);
			
			if(dt.Rows.Count == 0)
				Report.Error("No return data from database");
			
			//enrichment to do train routes
			AddTrainRoutesToDt(dt, "Territory", "Train Schedule OPSTA 1", "Train Schedule OPSTA 2");
			DataTableToCSV(dt, filename);
        }
	}
}
