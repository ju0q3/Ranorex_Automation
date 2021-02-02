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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ClearSignal_NS recording.
    /// </summary>
    [TestModule("d4b41e63-dc0d-4ef0-9a55-2d586f475af1", ModuleType.Recording, 1)]
    public partial class ClearSignal_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ClearSignal_NS instance = new ClearSignal_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClearSignal_NS()
        {
            signal = "";
            transmit = "True";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ClearSignal_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _signal;

        /// <summary>
        /// Gets or sets the value of variable signal.
        /// </summary>
        [TestVariable("1aca97fb-8cd5-4a79-982c-8ffb3728275a")]
        public string signal
        {
            get { return _signal; }
            set { _signal = value; }
        }

        string _transmit;

        /// <summary>
        /// Gets or sets the value of variable transmit.
        /// </summary>
        [TestVariable("dd875712-792a-48a3-a134-a68b58b38b05")]
        public string transmit
        {
            get { return _transmit; }
            set { _transmit = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("207a10f9-50a1-49ad-9180-b15f1bcd17be")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ClearSignal(signal, ValueConverter.ArgumentFromString<bool>("Transmit", transmit), expectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}