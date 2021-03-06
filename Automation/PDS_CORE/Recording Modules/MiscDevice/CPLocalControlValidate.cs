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

namespace PDS_CORE.Recording_Modules.MiscDevice
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CPLocalControlValidate recording.
    /// </summary>
    [TestModule("f8a357e4-01a7-42d9-8728-2a9408291f4e", ModuleType.Recording, 1)]
    public partial class CPLocalControlValidate : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static CPLocalControlValidate instance = new CPLocalControlValidate();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CPLocalControlValidate()
        {
            window = "";
            deviceId = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CPLocalControlValidate Instance
        {
            get { return instance; }
        }

#region Variables

        string _deviceId;

        /// <summary>
        /// Gets or sets the value of variable deviceId.
        /// </summary>
        [TestVariable("ef310ce6-1ce1-4165-b56a-d2feb5f32dbe")]
        public string deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable window.
        /// </summary>
        [TestVariable("6d2eadc1-25c7-4c8c-a5b9-489d39280bd9")]
        public string window
        {
            get { return repo.window; }
            set { repo.window = value; }
        }

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

            Report.Log(ReportLevel.Info, "Delay", "Waiting for 5s.", new RecordItemIndex(0));
            Delay.Duration(5000, false);
            
            Code_Utils.TracklineActions.DeviceStateValidation(window, deviceId, "LCI, ON");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
