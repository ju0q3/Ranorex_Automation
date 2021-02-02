/*
 * Created by Ranorex
 * User: 210057585
 * Date: 10/16/2017
 * Time: 8:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using System.Data;

namespace Oracle.Code_Modules
{
    /// <summary>
    /// Description of OracleTest.
    /// </summary>
    [TestModule("EE9DFEA9-EBDE-47DC-96A4-D3697A58990A", ModuleType.UserCode, 1)]
    public class OracleTest : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OracleTest()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Code_Utils.DataLoader dl = new Oracle.Code_Utils.DataLoader(new Code_Utils.OracleConnectionContext("CDMS", "hello", "cntst15"));
            
            DataTable dt =  dl.ReadOracleDataToTable("select * from CFG_COMMON_CONFIG_TAB");
            int sucess = dt.Columns.Count;
            sucess++;
            
            Ranorex.Report.Info("rawr");
            Ranorex.Report.Success(sucess.ToString());
        }
    }
}
