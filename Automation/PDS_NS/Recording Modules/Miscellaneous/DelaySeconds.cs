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

namespace PDS_NS.Recording_Modules.Miscellaneous
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DelaySeconds recording.
    /// </summary>
    [TestModule("b49b5971-f370-48d9-abd5-dd8fedb2b1f4", ModuleType.Recording, 1)]
    public partial class DelaySeconds : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DelaySeconds instance = new DelaySeconds();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DelaySeconds()
        {
            numberOfSeconds = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DelaySeconds Instance
        {
            get { return instance; }
        }

#region Variables

        string _numberOfSeconds;

        /// <summary>
        /// Gets or sets the value of variable numberOfSeconds.
        /// </summary>
        [TestVariable("e2453ac8-1cec-48f1-b831-e0511975151b")]
        public string numberOfSeconds
        {
            get { return _numberOfSeconds; }
            set { _numberOfSeconds = value; }
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

            DelaySecondsFunction(ValueConverter.ArgumentFromString<int>("numberOfSeconds", numberOfSeconds));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}