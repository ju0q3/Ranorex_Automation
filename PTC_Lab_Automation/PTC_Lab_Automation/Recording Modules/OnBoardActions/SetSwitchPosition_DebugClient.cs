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

namespace PTC_Lab_Automation.Recording_Modules.OnBoardActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SetSwitchPosition_DebugClient recording.
    /// </summary>
    [TestModule("b9886e9b-ae93-489e-ac5f-b845941191ff", ModuleType.Recording, 1)]
    public partial class SetSwitchPosition_DebugClient : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static SetSwitchPosition_DebugClient instance = new SetSwitchPosition_DebugClient();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetSwitchPosition_DebugClient()
        {
            position = "";
            enableOrDisable = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SetSwitchPosition_DebugClient Instance
        {
            get { return instance; }
        }

#region Variables

        string _position;

        /// <summary>
        /// Gets or sets the value of variable position.
        /// </summary>
        [TestVariable("706ac51d-6de8-4e5c-b324-e62e58389e37")]
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

        string _enableOrDisable;

        /// <summary>
        /// Gets or sets the value of variable enableOrDisable.
        /// </summary>
        [TestVariable("78642e93-b99d-4a1d-b660-7ecc43042a53")]
        public string enableOrDisable
        {
            get { return _enableOrDisable; }
            set { _enableOrDisable = value; }
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

            SetSwitchPosition_DebugClientSession(position, enableOrDisable);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
