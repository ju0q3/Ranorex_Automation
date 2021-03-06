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

namespace PDS_NS.Recording_Modules.Train_Movement
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_RemoveOccupancy recording.
    /// </summary>
    [TestModule("bf37f86e-cb39-42d5-b63e-f0dd111cc163", ModuleType.Recording, 1)]
    public partial class NS_RemoveOccupancy : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_RemoveOccupancy instance = new NS_RemoveOccupancy();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_RemoveOccupancy()
        {
            trackSection = "";
            waitForNotExist = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_RemoveOccupancy Instance
        {
            get { return instance; }
        }

#region Variables

        string _trackSection;

        /// <summary>
        /// Gets or sets the value of variable trackSection.
        /// </summary>
        [TestVariable("ee7a2497-59bb-476d-b72e-2ee8e6ef8a67")]
        public string trackSection
        {
            get { return _trackSection; }
            set { _trackSection = value; }
        }

        string _waitForNotExist;

        /// <summary>
        /// Gets or sets the value of variable waitForNotExist.
        /// </summary>
        [TestVariable("3172f9f8-dfa8-4ec7-92b8-09a62453eb0a")]
        public string waitForNotExist
        {
            get { return _waitForNotExist; }
            set { _waitForNotExist = value; }
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

            UserCodeCollections.NS_Trackline.NS_RemoveOccupancyFunction(trackSection, ValueConverter.ArgumentFromString<bool>("waitForNotExist", waitForNotExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
