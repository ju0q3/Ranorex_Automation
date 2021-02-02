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
    ///The AddQuickStopToTrain recording.
    /// </summary>
    [TestModule("2790efe3-aa58-43a9-8439-051100884f01", ModuleType.Recording, 1)]
    public partial class AddQuickStopToTrain : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AddQuickStopToTrain instance = new AddQuickStopToTrain();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddQuickStopToTrain()
        {
            trainSeed = "";
            stopDuration = "0";
            trackSection = "";
            mp = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddQuickStopToTrain Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("88e8d26d-6495-4e20-a901-4917701b3d1a")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _stopDuration;

        /// <summary>
        /// Gets or sets the value of variable stopDuration.
        /// </summary>
        [TestVariable("bb04ba09-5c2f-49f2-96d0-c533fe67ddda")]
        public string stopDuration
        {
            get { return _stopDuration; }
            set { _stopDuration = value; }
        }

        string _trackSection;

        /// <summary>
        /// Gets or sets the value of variable trackSection.
        /// </summary>
        [TestVariable("d2115387-9366-4f29-8e47-e6a3a989ceb0")]
        public string trackSection
        {
            get { return _trackSection; }
            set { _trackSection = value; }
        }

        string _mp;

        /// <summary>
        /// Gets or sets the value of variable mp.
        /// </summary>
        [TestVariable("4083ec12-82f7-478b-9adb-33cd49e00ae7")]
        public string mp
        {
            get { return _mp; }
            set { _mp = value; }
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

            UserCodeCollections.NS_Trackline.AddQuickStop(trainSeed, ValueConverter.ArgumentFromString<int>("duration", stopDuration), trackSection, mp);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
