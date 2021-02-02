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
    ///The WaitForTrainToArriveAtTrackSection recording.
    /// </summary>
    [TestModule("a6b02640-dacd-48a9-aa93-fe3485689129", ModuleType.Recording, 1)]
    public partial class WaitForTrainToArriveAtTrackSection : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static WaitForTrainToArriveAtTrackSection instance = new WaitForTrainToArriveAtTrackSection();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public WaitForTrainToArriveAtTrackSection()
        {
            trainSeed = "";
            trackSection = "";
            maxWaitSeconds = "60";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static WaitForTrainToArriveAtTrackSection Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("b3f0f4eb-acee-4c0c-8213-01504fd3deb4")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _trackSection;

        /// <summary>
        /// Gets or sets the value of variable trackSection.
        /// </summary>
        [TestVariable("3d5f4719-be1c-4628-bcf8-0e4ec5227398")]
        public string trackSection
        {
            get { return _trackSection; }
            set { _trackSection = value; }
        }

        string _maxWaitSeconds;

        /// <summary>
        /// Gets or sets the value of variable maxWaitSeconds.
        /// </summary>
        [TestVariable("e5b5850c-5afc-42db-b5ff-dc65abf39ad9")]
        public string maxWaitSeconds
        {
            get { return _maxWaitSeconds; }
            set { _maxWaitSeconds = value; }
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

            try {
                UserCodeCollections.NS_Trackline.NS_WaitForTrainToArriveAtTrackSection(trainSeed, trackSection, ValueConverter.ArgumentFromString<int>("maxWaitSeconds", maxWaitSeconds));
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
