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

namespace PTC_Lab_Automation.Recording_Modules.LogManagerActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The HornLogAction recording.
    /// </summary>
    [TestModule("cc67bc53-af93-495e-b0dd-aa0d90dd6086", ModuleType.Recording, 1)]
    public partial class HornLogAction : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static HornLogAction instance = new HornLogAction();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public HornLogAction()
        {
            action = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static HornLogAction Instance
        {
            get { return instance; }
        }

#region Variables

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("c0b7dc05-3aa9-46b2-90a1-9062bfb3de32")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
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

            HornLogAction_OnBoard(action);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}