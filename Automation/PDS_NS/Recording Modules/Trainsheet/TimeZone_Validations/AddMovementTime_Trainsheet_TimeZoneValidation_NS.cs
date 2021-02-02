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

namespace PDS_NS.Recording_Modules.Trainsheet.TimeZone_Validations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The AddMovementTime_Trainsheet_TimeZoneValidation_NS recording.
    /// </summary>
    [TestModule("d89c6679-5743-49b4-a432-c931df522650", ModuleType.Recording, 1)]
    public partial class AddMovementTime_Trainsheet_TimeZoneValidation_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AddMovementTime_Trainsheet_TimeZoneValidation_NS instance = new AddMovementTime_Trainsheet_TimeZoneValidation_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddMovementTime_Trainsheet_TimeZoneValidation_NS()
        {
            trainSeed = "";
            inputTimeZone = "";
            closeforms = "False";
            expectedFeedback = "";
            OpSta = "";
            reportType = "";
            rowNumber = "0";
            useInvalidDaylightTime = "False";
            expectedFeedbackLocation = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddMovementTime_Trainsheet_TimeZoneValidation_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("1ddbd157-fcdc-4fa8-b7ac-7d66685088fb")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _inputTimeZone;

        /// <summary>
        /// Gets or sets the value of variable inputTimeZone.
        /// </summary>
        [TestVariable("369ac017-340f-40fa-a91b-9f46affbc0f9")]
        public string inputTimeZone
        {
            get { return _inputTimeZone; }
            set { _inputTimeZone = value; }
        }

        string _closeforms;

        /// <summary>
        /// Gets or sets the value of variable closeforms.
        /// </summary>
        [TestVariable("bf56134f-b894-4844-b32c-7458477ce0bd")]
        public string closeforms
        {
            get { return _closeforms; }
            set { _closeforms = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("02a2701d-6121-4b7b-85db-a09ad67c4b3e")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _OpSta;

        /// <summary>
        /// Gets or sets the value of variable OpSta.
        /// </summary>
        [TestVariable("c4b98036-c060-4506-b521-b8dc20a1a625")]
        public string OpSta
        {
            get { return _OpSta; }
            set { _OpSta = value; }
        }

        string _reportType;

        /// <summary>
        /// Gets or sets the value of variable reportType.
        /// </summary>
        [TestVariable("1cdeb94d-f5ef-452c-b6f9-30ae17adeeae")]
        public string reportType
        {
            get { return _reportType; }
            set { _reportType = value; }
        }

        string _rowNumber;

        /// <summary>
        /// Gets or sets the value of variable rowNumber.
        /// </summary>
        [TestVariable("5df534d4-151d-4b54-b29e-4508eff16b36")]
        public string rowNumber
        {
            get { return _rowNumber; }
            set { _rowNumber = value; }
        }

        string _useInvalidDaylightTime;

        /// <summary>
        /// Gets or sets the value of variable useInvalidDaylightTime.
        /// </summary>
        [TestVariable("ae9c0572-d0a8-4b29-bc0a-c3212af2aa60")]
        public string useInvalidDaylightTime
        {
            get { return _useInvalidDaylightTime; }
            set { _useInvalidDaylightTime = value; }
        }

        string _expectedFeedbackLocation;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedbackLocation.
        /// </summary>
        [TestVariable("73cf1cad-9966-4a66-9b36-7a27ddfe3bd8")]
        public string expectedFeedbackLocation
        {
            get { return _expectedFeedbackLocation; }
            set { _expectedFeedbackLocation = value; }
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

            UserCodeCollections.NS_Trainsheet.Add_DateTime_TimeZone_Movement_Tab(trainSeed, OpSta, reportType, inputTimeZone, ValueConverter.ArgumentFromString<bool>("useInvalidDaylightTime", useInvalidDaylightTime), ValueConverter.ArgumentFromString<bool>("closeForms", closeforms), expectedFeedback, ValueConverter.ArgumentFromString<int>("rowNumber", rowNumber), ValueConverter.ArgumentFromString<int>("expectedFeedbackLocation", expectedFeedbackLocation));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}