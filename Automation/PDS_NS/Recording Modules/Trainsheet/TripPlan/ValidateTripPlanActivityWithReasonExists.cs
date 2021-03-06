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

namespace PDS_NS.Recording_Modules.Trainsheet.TripPlan
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTripPlanActivityWithReasonExists recording.
    /// </summary>
    [TestModule("5e24fa9a-0dae-4e69-89b8-779f7eb544f1", ModuleType.Recording, 1)]
    public partial class ValidateTripPlanActivityWithReasonExists : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTripPlanActivityWithReasonExists instance = new ValidateTripPlanActivityWithReasonExists();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTripPlanActivityWithReasonExists()
        {
            trainSeed = "";
            activityType = "";
            reason = "";
            validateExist = "True";
            closeForms = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTripPlanActivityWithReasonExists Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("511bc957-6b4c-4be9-a903-08929a75e464")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("d295a8e9-4a13-496b-8516-dd72c2866b7a")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        string _reason;

        /// <summary>
        /// Gets or sets the value of variable reason.
        /// </summary>
        [TestVariable("8acef161-9554-44c9-95ff-ec015cc659d0")]
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        string _validateExist;

        /// <summary>
        /// Gets or sets the value of variable validateExist.
        /// </summary>
        [TestVariable("00703733-1e88-45d4-a9e9-cba8f31a4116")]
        public string validateExist
        {
            get { return _validateExist; }
            set { _validateExist = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("e898a553-0ee6-4a4e-a8d8-f0d755dafab4")]
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateTripPlanActivityWithReasonExists(trainSeed, activityType, reason, ValueConverter.ArgumentFromString<bool>("validateExist", validateExist), ValueConverter.ArgumentFromString<bool>("closeForms", validateExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
