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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource recording.
    /// </summary>
    [TestModule("7d047c24-cb9f-45de-95bf-678e3efc6f84", ModuleType.Recording, 1)]
    public partial class ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.Trains_Repo repository.
        /// </summary>
        public static global::PDS_NS.Trains_Repo repo = global::PDS_NS.Trains_Repo.Instance;

        static ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource instance = new ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource()
        {
            trainSeed = "";
            source = "";
            reportingSource = "";
            eventSubtype = "";
            timeFrameInSeconds = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_Validate_ABF_TRC_CONSIST_SUMMARY_ReportingSource Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("517f9347-345b-43d9-a295-1a06d3b3e439")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _source;

        /// <summary>
        /// Gets or sets the value of variable source.
        /// </summary>
        [TestVariable("05fea50b-44c9-4a9b-be68-00d27b310c92")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        string _reportingSource;

        /// <summary>
        /// Gets or sets the value of variable reportingSource.
        /// </summary>
        [TestVariable("aa65c11f-02d7-4104-9ee9-a77eeac96d81")]
        public string reportingSource
        {
            get { return _reportingSource; }
            set { _reportingSource = value; }
        }

        string _eventSubtype;

        /// <summary>
        /// Gets or sets the value of variable eventSubtype.
        /// </summary>
        [TestVariable("78245083-fa85-4159-98bb-229a76d840eb")]
        public string eventSubtype
        {
            get { return _eventSubtype; }
            set { _eventSubtype = value; }
        }

        string _timeFrameInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeFrameInSeconds.
        /// </summary>
        [TestVariable("5a36a8c8-0b7c-45fb-830c-22cce011b4f3")]
        public string timeFrameInSeconds
        {
            get { return _timeFrameInSeconds; }
            set { _timeFrameInSeconds = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateTCSMReportingSource(trainSeed, source, reportingSource, eventSubtype, timeFrameInSeconds);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
