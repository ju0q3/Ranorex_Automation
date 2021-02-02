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

namespace PDS_NS.Recording_Modules.Alerts
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OkAudibleAlert recording.
    /// </summary>
    [TestModule("a2d46318-2818-4dd0-9e1a-47c4326ac246", ModuleType.Recording, 1)]
    public partial class OkAudibleAlert : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.Miscellaneous_Repo repository.
        /// </summary>
        public static global::PDS_NS.Miscellaneous_Repo repo = global::PDS_NS.Miscellaneous_Repo.Instance;

        static OkAudibleAlert instance = new OkAudibleAlert();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OkAudibleAlert()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OkAudibleAlert Instance
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

            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Activate() on item 'Audible_Alert_Checkout'.", repo.Audible_Alert_Checkout.SelfInfo, new RecordItemIndex(0));
            repo.Audible_Alert_Checkout.Self.Activate();
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.Audible_Alert_Checkout.OkButtonInfo, repo.Audible_Alert_Checkout.SelfInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}