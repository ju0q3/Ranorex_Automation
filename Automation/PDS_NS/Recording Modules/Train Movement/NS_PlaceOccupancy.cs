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
    ///The NS_PlaceOccupancy recording.
    /// </summary>
    [TestModule("8a4d72e6-7a32-4b1c-b753-5ed4ad447f0f", ModuleType.Recording, 1)]
    public partial class NS_PlaceOccupancy : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_PlaceOccupancy instance = new NS_PlaceOccupancy();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_PlaceOccupancy()
        {
            trackSection = "";
            waitForExists = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_PlaceOccupancy Instance
        {
            get { return instance; }
        }

#region Variables

        string _trackSection;

        /// <summary>
        /// Gets or sets the value of variable trackSection.
        /// </summary>
        [TestVariable("fa3962f6-ce58-4e80-9ffd-4327c03a3a91")]
        public string trackSection
        {
            get { return _trackSection; }
            set { _trackSection = value; }
        }

        string _waitForExists;

        /// <summary>
        /// Gets or sets the value of variable waitForExists.
        /// </summary>
        [TestVariable("d100af30-7309-4544-bd2f-da103a2a0b07")]
        public string waitForExists
        {
            get { return _waitForExists; }
            set { _waitForExists = value; }
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

            UserCodeCollections.NS_Trackline.NS_PlaceOccupancyFunction(trackSection, ValueConverter.ArgumentFromString<bool>("waitForExists", waitForExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
