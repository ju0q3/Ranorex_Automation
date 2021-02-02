/*
 * Created by Ranorex
 * User: r07000021
 * Date: 6/5/2018
 * Time: 7:00 AM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace PDS_CORE.Code_Utils.Webservices
{
    /// <summary>
    /// Description of HeadlessLogin.
    /// </summary>
    [TestModule("5E6EC055-0896-4DAB-B4A7-54EA9CC28B08", ModuleType.UserCode, 1)]
    public class HeadlessLogin : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public HeadlessLogin()
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
        }
        
        
        public void startService()
        {
          
        }
    }
}
