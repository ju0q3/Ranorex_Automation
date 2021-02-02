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
    ///The TrackCircuitToManual_NS recording.
    /// </summary>
    [TestModule("84bdac42-89e4-4cb7-9768-6bcb6ee9eb81", ModuleType.Recording, 1)]
    public partial class TrackCircuitToManual_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static TrackCircuitToManual_NS instance = new TrackCircuitToManual_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TrackCircuitToManual_NS()
        {
            deviceID = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static TrackCircuitToManual_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _deviceID;

        /// <summary>
        /// Gets or sets the value of variable deviceID.
        /// </summary>
        [TestVariable("419a9e3f-1311-4b5d-af70-e75088691605")]
        public string deviceID
        {
            get { return _deviceID; }
            set { _deviceID = value; }
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

            UserCodeCollections.NS_Trackline.TrackSectionContextAction(deviceID, "MANUAL:CIRCUITS");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
