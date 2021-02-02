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

namespace PDS_NS.Recording_Modules.SystemConfiguration.CTC_Parameters
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS recording.
    /// </summary>
    [TestModule("f7ab28a0-d3b2-4959-b4bb-66babd5ee59a", ModuleType.Recording, 1)]
    public partial class ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS instance = new ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS()
        {
            closeForms = "False";
            expSwitchAlert = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("e119e1e6-90c5-4610-a1fb-b1e4056ac73d")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _expSwitchAlert;

        /// <summary>
        /// Gets or sets the value of variable expSwitchAlert.
        /// </summary>
        [TestVariable("1a93760f-35d5-4b60-890e-2f0410d9f550")]
        public string expSwitchAlert
        {
            get { return _expSwitchAlert; }
            set { _expSwitchAlert = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateDisableUnresponsiveSwitchAlertCheckbox_CTCParameters(ValueConverter.ArgumentFromString<bool>("expSwitchAlert", expSwitchAlert), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
