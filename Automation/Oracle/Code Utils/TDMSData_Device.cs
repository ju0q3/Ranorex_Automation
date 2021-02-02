/*
 * Created by Ranorex
 * User: 210058208
 * Date: 11/26/2018
 * Time: 12:49 PM
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchViewName"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void populateMiscDeviceSheetsFromTDMS(string dispatchViewName, string SqlConnection) {
      
			var query = @"
select VW.DISPATCH_VIEW_NAME as DISPATCHVIEW,
md.misc_device_id as DEVICEID,
md.misc_device_name as NAME,
md.misc_device_type as TYPE,
md.on_synonym as ON_SYNONYM,
md.off_synonym as OFF_SYNONYM
from 
TDMS.DVC_MISCELLANEOUS_DEVICE md
join tdms.cm_label_project lb on 
    lb.project_id = md.project_id 
    and lb.project_version = md.project_version
join tdms.te_striplet_object so on
    so.project_id = md.project_id 
    and so.project_version = md.project_version
    and so.object_id = md.misc_device_id 
join tdms.te_dispatch_view_striplet vs on 
    vs.striplet_project_id = so.project_id
    and vs.striplet_project_version = so.project_version
    and vs.striplet_id = so.striplet_id
join tdms.te_dispatch_view vw on 
    vw.dispatch_view_id = vs.dispatch_view_id
    and vw.project_id = vs.project_id
    and vw.project_version = vs.project_version
where
label_id = (select target_label_id from cdms.ff_tls_config_params)    
and dispatch_view_name = :dispatch_view_name
and md.controlled_d = 1";
        	
        	
		    string filename = getCsvFileNameForConnector("DataTest_Device_CtrlIndMiscDevice");
		    
			Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);

			List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":dispatch_view_name", OracleDbType.Varchar2, dispatchViewName, ParameterDirection.Input)
        	};
						
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0)
				Report.Error("No return data from database");
			
			DataTableToCSV(dt, filename);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchViewName"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
        public static void populateMiscDeviceIndOnlySheetsFromTDMS(string dispatchViewName, string SqlConnection) {
        	
        	var query = @"
select VW.DISPATCH_VIEW_NAME as DISPATCHVIEW,
md.misc_device_id as DEVICEID,
md.misc_device_name as NAME,
md.misc_device_type as TYPE,
md.on_synonym as ON_SYNONYM,
md.off_synonym as OFF_SYNONYM
from 
TDMS.DVC_MISCELLANEOUS_DEVICE md
join tdms.cm_label_project lb on 
    lb.project_id = md.project_id 
    and lb.project_version = md.project_version
join tdms.te_striplet_object so on
    so.project_id = md.project_id 
    and so.project_version = md.project_version
    and so.object_id = md.misc_device_id 
join tdms.te_dispatch_view_striplet vs on 
    vs.striplet_project_id = so.project_id
    and vs.striplet_project_version = so.project_version
    and vs.striplet_id = so.striplet_id
join tdms.te_dispatch_view vw on 
    vw.dispatch_view_id = vs.dispatch_view_id
    and vw.project_id = vs.project_id
    and vw.project_version = vs.project_version
where
label_id = (select target_label_id from cdms.ff_tls_config_params)    
and dispatch_view_name = :dispatch_view_name
and md.controlled_d = 0
and md.indicating_d = 1";                          
        	
		    string filename = getCsvFileNameForConnector("DataTest_Device_IndOnlyMiscDevice");
		    
			Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);

			List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":dispatch_view_name", OracleDbType.Varchar2, dispatchViewName, ParameterDirection.Input)
        	};
						
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0)
				Report.Error("No return data from database");
			
			DataTableToCSV(dt, filename);
		}
	  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchViewName"></param>
        /// <param name="SqlConnection"></param>
        [UserCodeMethod]
	    public static void populateControlPointsSheetFromTDMS(string dispatchViewName, string SqlConnection) {
		    
	    	var query = @"
select VW.DISPATCH_VIEW_NAME as DispatchView,
cp.control_point_id as DeviceId,
cp.display_name as ControlPointName
from 
tdms.dvc_control_point cp 
join tdms.cm_label_project lb on 
    lb.project_id = cp.project_id 
    and lb.project_version = cp.project_version
join tdms.te_striplet_object so on
    so.project_id = cp.project_id 
    and so.project_version = cp.project_version
    and so.object_id = cp.control_point_id
join tdms.te_dispatch_view_striplet vs on 
    vs.striplet_project_id = so.project_id
    and vs.striplet_project_version = so.project_version
    and vs.striplet_id = so.striplet_id
join tdms.te_dispatch_view vw on 
    vw.dispatch_view_id = vs.dispatch_view_id
    and vw.project_id = vs.project_id
    and vw.project_version = vs.project_version
where
label_id = (select target_label_id from cdms.ff_tls_config_params)    
and dispatch_view_name = :dispatch_view_name";
		    
		    string filename = getCsvFileNameForConnector("DataTest_Device_ControlPoints");
			Oracle.Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(SqlConnection);

			List<OracleParameter> prms =  new List<OracleParameter>() {
				new OracleParameter(":dispatch_view_name", OracleDbType.Varchar2, dispatchViewName, ParameterDirection.Input)
        	};
						
			DataTable dt =  dl.ReadOracleDataToTable(query, prms);
			
			if(dt.Rows.Count == 0)
				Report.Error("No return data from database");
			
			DataTableToCSV(dt, filename);
	    }
    }
}
