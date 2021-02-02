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
    ///The FleetingSignal_NS recording.
    /// </summary>
    [TestModule("8ccc9feb-9779-4b4a-b57d-d4c644d88f97", ModuleType.Recording, 1)]
    public partial class FleetingSignal_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static FleetingSignal_NS instance = new FleetingSignal_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FleetingSignal_NS()
        {
            signalId = "";
            Transmit = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static FleetingSignal_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _signalId;

        /// <summary>
        /// Gets or sets the value of variable signalId.
        /// </summary>
        [TestVariable("12a6b6b8-04da-45f9-a626-4b1336b132b1")]
        public string signalId
        {
            get { return _signalId; }
            set { _signalId = value; }
        }

        string _Transmit;

        /// <summary>
        /// Gets or sets the value of variable Transmit.
        /// </summary>
        [TestVariable("2fab26b3-129f-451c-b65e-37746faa6184")]
        public string Transmit
        {
            get { return _Transmit; }
            set { _Transmit = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_FleetingSignal(signalId, ValueConverter.ArgumentFromString<bool>("Transmit", Transmit));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
