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

namespace PDS_NS.Recording_Modules.TracklineValidations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_Validate_SignalBlinking recording.
    /// </summary>
    [TestModule("fd930350-db68-4e6f-a93a-b74598a3fca5", ModuleType.Recording, 1)]
    public partial class NS_Validate_SignalBlinking : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_Validate_SignalBlinking instance = new NS_Validate_SignalBlinking();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_Validate_SignalBlinking()
        {
            signalId = "00000";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_Validate_SignalBlinking Instance
        {
            get { return instance; }
        }

#region Variables

        string _signalId;

        /// <summary>
        /// Gets or sets the value of variable signalId.
        /// </summary>
        [TestVariable("c57a6409-ba2a-4a2f-af5e-14bbcd73dbb6")]
        public string signalId
        {
            get { return _signalId; }
            set { _signalId = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ValidateSignalBlinking(signalId);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
