/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/3/2019
 * Time: 1:03 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Oracle.Code_Utils;
using Env.Code_Utils;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_NS.UserCodeCollections
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class NS_Tasks
    {
        /// <summary>
    	/// Edits the CFG_TAC_TERRITORY table in CDMS to enable/disable limit suggestions
    	/// </summary>
    	/// <param name="territory">Input:territory to edit limit suggestions for, i.e. GSF, South End</param>
    	/// <param name="enable">Input:True to enable, false to disable</param>
    	[UserCodeMethod]
    	public static void NS_EnableDisableLimitSuggestionsForTerritory(string territory, bool enable)
        {
    		//if territory for some blankety reason has a space due to some weird ranorex defect, remove the space
    		if (territory.EndsWith(" "))
    		{
    			territory = territory.Substring(0, territory.Length-1);
    		}
    		VMEnvironment vm = VMEnvironment.Instance();
        	Oracle.Code_Utils.TDMSActions TDMSActions = new Oracle.Code_Utils.TDMSActions(vm.dbPw,vm.user);
        	Oracle.Code_Utils.CDMSActions CDMSActions = new Oracle.Code_Utils.CDMSActions(vm.dbPw,vm.user);
        	
    		string territoryId = TDMSActions.GetTerritoryIdFromTerritoryName(territory);
    		if (territoryId == "")
    		{
    			Ranorex.Report.Error("Territory Id not found in TERRITORY_MV table for Territory Name {"+territory+"} in TDMS Database");
    			return;
    		}
    		
    		CDMSActions.InsertOrSetTerritoryIdInCfgTacTerritoryTable(territoryId, enable);
    		return;
    	}
    }
}
