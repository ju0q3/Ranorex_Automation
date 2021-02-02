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
    ///The AddDelay_Trainsheet_TimeZoneValidation_NS recording.
    /// </summary>
    [TestModule("6b009f81-705b-4140-9a1c-dbc848f9d229", ModuleType.Recording, 1)]
    public partial class AddDelay_Trainsheet_TimeZoneValidation_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AddDelay_Trainsheet_TimeZoneValidation_NS instance = new AddDelay_Trainsheet_TimeZoneValidation_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddDelay_Trainsheet_TimeZoneValidation_NS()
        {
            trainSeed = "";
            FromLocation = "";
            comments = "";
            fromTimeZone = "";
            toTimeZone = "";
            ToLocation = "";
            DelayCode = "";
            Duration = "";
            expectedFeedback = "";
            closeForms = "False";
            crewSegment = "";
            crewID = "";
            expectedFeedbackLocation = "0";
            useInvalidDaylightTime = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddDelay_Trainsheet_TimeZoneValidation_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("0dc181ca-1c57-4d4f-a68a-f8608412b8b8")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _FromLocation;

        /// <summary>
        /// Gets or sets the value of variable FromLocation.
        /// </summary>
        [TestVariable("ae0a8ab7-7c99-463d-ab4c-8ba89947ae99")]
        public string FromLocation
        {
            get { return _FromLocation; }
            set { _FromLocation = value; }
        }

        string _comments;

        /// <summary>
        /// Gets or sets the value of variable comments.
        /// </summary>
        [TestVariable("cfe65179-91f7-45ea-893b-cbd50d57f4f8")]
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        string _fromTimeZone;

        /// <summary>
        /// Gets or sets the value of variable fromTimeZone.
        /// </summary>
        [TestVariable("d347abb4-3921-4b10-b064-2417b0d6a7a0")]
        public string fromTimeZone
        {
            get { return _fromTimeZone; }
            set { _fromTimeZone = value; }
        }

        string _toTimeZone;

        /// <summary>
        /// Gets or sets the value of variable toTimeZone.
        /// </summary>
        [TestVariable("eadd279f-ad80-4c1c-a79a-ac43fe7af725")]
        public string toTimeZone
        {
            get { return _toTimeZone; }
            set { _toTimeZone = value; }
        }

        string _ToLocation;

        /// <summary>
        /// Gets or sets the value of variable ToLocation.
        /// </summary>
        [TestVariable("afc8edae-26ab-49a6-b1ca-1d6708673837")]
        public string ToLocation
        {
            get { return _ToLocation; }
            set { _ToLocation = value; }
        }

        string _DelayCode;

        /// <summary>
        /// Gets or sets the value of variable DelayCode.
        /// </summary>
        [TestVariable("ea580eb4-ad98-423e-962f-c26f86e0fb61")]
        public string DelayCode
        {
            get { return _DelayCode; }
            set { _DelayCode = value; }
        }

        string _Duration;

        /// <summary>
        /// Gets or sets the value of variable Duration.
        /// </summary>
        [TestVariable("f417b593-039f-432d-89e2-111541d27a79")]
        public string Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("3660400b-4c60-4b68-9ef3-a04e61a0ce75")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("2f7a926e-7366-44e8-a4e6-85f0051028a2")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _crewSegment;

        /// <summary>
        /// Gets or sets the value of variable crewSegment.
        /// </summary>
        [TestVariable("d23205f5-1723-4d2a-8f33-88acb28d52f2")]
        public string crewSegment
        {
            get { return _crewSegment; }
            set { _crewSegment = value; }
        }

        string _crewID;

        /// <summary>
        /// Gets or sets the value of variable crewID.
        /// </summary>
        [TestVariable("8ba601c7-e940-42b5-9eae-9ae25934a6e3")]
        public string crewID
        {
            get { return _crewID; }
            set { _crewID = value; }
        }

        string _expectedFeedbackLocation;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedbackLocation.
        /// </summary>
        [TestVariable("ca255167-70cb-478f-91e0-738f497af330")]
        public string expectedFeedbackLocation
        {
            get { return _expectedFeedbackLocation; }
            set { _expectedFeedbackLocation = value; }
        }

        string _useInvalidDaylightTime;

        /// <summary>
        /// Gets or sets the value of variable useInvalidDaylightTime.
        /// </summary>
        [TestVariable("3a3ad125-55f0-4f88-a60d-692b44ca216e")]
        public string useInvalidDaylightTime
        {
            get { return _useInvalidDaylightTime; }
            set { _useInvalidDaylightTime = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_AddDelayManually_TimeZoneValidation(trainSeed, FromLocation, ValueConverter.ArgumentFromString<bool>("useInvalidDaylightTime", useInvalidDaylightTime), fromTimeZone, toTimeZone, ToLocation, DelayCode, Duration, crewID, crewSegment, comments, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms), ValueConverter.ArgumentFromString<int>("expectedFeedbackLocation", expectedFeedbackLocation));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}