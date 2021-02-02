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

namespace PDS_NS.Recording_Modules.Trainsheet_Validations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTripPlanActivityAlternativeDetails recording.
    /// </summary>
    [TestModule("a60853ee-ed92-47b0-9048-3da73e2df1d1", ModuleType.Recording, 1)]
    public partial class ValidateTripPlanActivityAlternativeDetails : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTripPlanActivityAlternativeDetails instance = new ValidateTripPlanActivityAlternativeDetails();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTripPlanActivityAlternativeDetails()
        {
            trainseed = "";
            activityType = "";
            opsta = "";
            passCount = "";
            activityAlternativesCount = "0";
            activityAlternativesRecord = "";
            validateExist = "True";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTripPlanActivityAlternativeDetails Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainseed;

        /// <summary>
        /// Gets or sets the value of variable trainseed.
        /// </summary>
        [TestVariable("480dd5e6-5bed-4d14-832b-5b6720d998c9")]
        public string trainseed
        {
            get { return _trainseed; }
            set { _trainseed = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("fff5b243-fb59-4ff5-88df-f4907f75ec41")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("ac3acfba-bf9f-4dd8-88ae-0e0b03f6fcca")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _passCount;

        /// <summary>
        /// Gets or sets the value of variable passCount.
        /// </summary>
        [TestVariable("24fcb87f-c7ec-4479-b532-cf446abd3420")]
        public string passCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        string _activityAlternativesCount;

        /// <summary>
        /// Gets or sets the value of variable activityAlternativesCount.
        /// </summary>
        [TestVariable("46a81455-c1c1-4121-8495-e30036e7381a")]
        public string activityAlternativesCount
        {
            get { return _activityAlternativesCount; }
            set { _activityAlternativesCount = value; }
        }

        string _activityAlternativesRecord;

        /// <summary>
        /// Gets or sets the value of variable activityAlternativesRecord.
        /// </summary>
        [TestVariable("c60988ae-3e3a-456c-985a-d01c4d429b8e")]
        public string activityAlternativesRecord
        {
            get { return _activityAlternativesRecord; }
            set { _activityAlternativesRecord = value; }
        }

        string _validateExist;

        /// <summary>
        /// Gets or sets the value of variable validateExist.
        /// </summary>
        [TestVariable("7c2a062a-efb0-462b-92d9-1c97c759fce1")]
        public string validateExist
        {
            get { return _validateExist; }
            set { _validateExist = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("d98edc8b-2fc1-46fb-87a5-bfe78b7845e5")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateTripPlanActivityAllAlternativeDetails(trainseed, activityType, opsta, passCount, ValueConverter.ArgumentFromString<int>("activityAlternativesCount", activityAlternativesCount), activityAlternativesRecord, ValueConverter.ArgumentFromString<bool>("validateExist", validateExist), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}