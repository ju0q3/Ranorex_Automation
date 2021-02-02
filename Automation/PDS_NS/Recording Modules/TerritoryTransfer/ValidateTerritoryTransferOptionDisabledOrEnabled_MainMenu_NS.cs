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

namespace PDS_NS.Recording_Modules.TerritoryTransfer
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS recording.
    /// </summary>
    [TestModule("95f3ee6c-d0b5-4eb1-9ccf-fde6a5f04ced", ModuleType.Recording, 1)]
    public partial class ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS instance = new ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS()
        {
            enabled = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _enabled;

        /// <summary>
        /// Gets or sets the value of variable enabled.
        /// </summary>
        [TestVariable("16459d08-2c53-4047-bd0a-28264a254d41")]
        public string enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
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

            CodeUtils.NS_TerritoryTransfer_Validations.NS_ValidateTerritoryTransferOptionDisabledOrEnabled_MainMenu(ValueConverter.ArgumentFromString<bool>("enabled", enabled));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
