﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

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
using Ranorex.Core.Repository;

namespace PDS_NS.Recording_Modules.PTC.PTC_Configuration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePTCBulletinConfigFormNotExist recording.
    /// </summary>
    [TestModule("9b107988-bbd1-462c-97d4-e7fbb8e3b32d", ModuleType.Recording, 1)]
    public partial class ValidatePTCBulletinConfigFormNotExist : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static ValidatePTCBulletinConfigFormNotExist instance = new ValidatePTCBulletinConfigFormNotExist();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePTCBulletinConfigFormNotExist()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePTCBulletinConfigFormNotExist Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Validation", "Validating NotExists on item 'Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.BulletinConfigurationTab'.", repo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.BulletinConfigurationTabInfo, new RecordItemIndex(0));
            Validate.NotExists(repo.Positive_Train_Control_Configuration.PositiveTrainControlConfigurationTabs.BulletinConfigurationTabInfo);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Positive_Train_Control_Configuration.WindowControls.Close' at Center.", repo.Positive_Train_Control_Configuration.WindowControls.CloseInfo, new RecordItemIndex(1));
            repo.Positive_Train_Control_Configuration.WindowControls.Close.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
