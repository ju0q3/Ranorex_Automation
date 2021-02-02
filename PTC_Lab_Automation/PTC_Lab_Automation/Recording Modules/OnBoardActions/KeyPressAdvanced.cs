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
    ///The KeyPressAdvanced recording.
    /// </summary>
    [TestModule("7ec0a9f6-dd78-4881-82b7-d3aec509adb6", ModuleType.Recording, 1)]
    public partial class KeyPressAdvanced : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static KeyPressAdvanced instance = new KeyPressAdvanced();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public KeyPressAdvanced()
        {
            key = "";
            numberOfPresses = "1";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static KeyPressAdvanced Instance
        {
            get { return instance; }
        }

#region Variables

        string _key;

        /// <summary>
        /// Gets or sets the value of variable key.
        /// </summary>
        [TestVariable("e599cfec-6b1b-4dc6-bc34-3653c3852aa7")]
        public string key
        {
            get { return _key; }
            set { _key = value; }
        }

        string _numberOfPresses;

        /// <summary>
        /// Gets or sets the value of variable numberOfPresses.
        /// </summary>
        [TestVariable("cd7bcfc9-950c-4f34-8f39-baddc16b3157")]
        public string numberOfPresses
        {
            get { return _numberOfPresses; }
            set { _numberOfPresses = value; }
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

            KeyPressAdvanced_OnBoard(key, numberOfPresses);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}