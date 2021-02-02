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

namespace PDS_NS.Recording_Modules.Playback
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ConfigurePlaybackForm recording.
    /// </summary>
    [TestModule("ce6d636f-f0f7-44b3-b0eb-dbe8b1fa66cf", ModuleType.Recording, 1)]
    public partial class ConfigurePlaybackForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ConfigurePlaybackForm instance = new ConfigurePlaybackForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigurePlaybackForm()
        {
            expectedFeedback = "";
            playbackMonth = "";
            playbackYear = "";
            playbackDay = "";
            playbackStart = "";
            playbackSliderDistance = "0";
            admsOperational = "True";
            tdmsOperational = "True";
            GMT = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConfigurePlaybackForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("209848e6-f9a0-4ee0-98c0-8ba874652d4e")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _playbackMonth;

        /// <summary>
        /// Gets or sets the value of variable playbackMonth.
        /// </summary>
        [TestVariable("ed6875b2-efd0-4568-9fc3-5a34dba5198d")]
        public string playbackMonth
        {
            get { return _playbackMonth; }
            set { _playbackMonth = value; }
        }

        string _playbackYear;

        /// <summary>
        /// Gets or sets the value of variable playbackYear.
        /// </summary>
        [TestVariable("d44f3c53-a6c8-404c-a541-406bf891170f")]
        public string playbackYear
        {
            get { return _playbackYear; }
            set { _playbackYear = value; }
        }

        string _playbackDay;

        /// <summary>
        /// Gets or sets the value of variable playbackDay.
        /// </summary>
        [TestVariable("b17baf9c-2316-4671-b7cf-4ad109090ce6")]
        public string playbackDay
        {
            get { return _playbackDay; }
            set { _playbackDay = value; }
        }

        string _playbackStart;

        /// <summary>
        /// Gets or sets the value of variable playbackStart.
        /// </summary>
        [TestVariable("e989e77e-5070-4546-b9a5-5df2967fa736")]
        public string playbackStart
        {
            get { return _playbackStart; }
            set { _playbackStart = value; }
        }

        string _playbackSliderDistance;

        /// <summary>
        /// Gets or sets the value of variable playbackSliderDistance.
        /// </summary>
        [TestVariable("eb22a413-df60-44c2-8dbb-88a4f2fb071f")]
        public string playbackSliderDistance
        {
            get { return _playbackSliderDistance; }
            set { _playbackSliderDistance = value; }
        }

        string _admsOperational;

        /// <summary>
        /// Gets or sets the value of variable admsOperational.
        /// </summary>
        [TestVariable("f9f93bb0-4b3a-4a1e-a536-6dd0df2da671")]
        public string admsOperational
        {
            get { return _admsOperational; }
            set { _admsOperational = value; }
        }

        string _tdmsOperational;

        /// <summary>
        /// Gets or sets the value of variable tdmsOperational.
        /// </summary>
        [TestVariable("a3854d28-e956-4e75-ab42-8a2c719f63db")]
        public string tdmsOperational
        {
            get { return _tdmsOperational; }
            set { _tdmsOperational = value; }
        }

        string _GMT;

        /// <summary>
        /// Gets or sets the value of variable GMT.
        /// </summary>
        [TestVariable("bff50e02-85e8-4f96-bdf4-23d44a1632af")]
        public string GMT
        {
            get { return _GMT; }
            set { _GMT = value; }
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

            UserCodeCollections.NS_Playback.NS_ConfigurePlaybackForm(ValueConverter.ArgumentFromString<bool>("admsOperational", admsOperational), ValueConverter.ArgumentFromString<bool>("tdmsOperational", tdmsOperational), "", "", "", "", "", "", playbackMonth, playbackYear, playbackDay, playbackStart, ValueConverter.ArgumentFromString<int>("playbackSliderDistance", playbackSliderDistance), ValueConverter.ArgumentFromString<bool>("GMT", GMT), expectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}