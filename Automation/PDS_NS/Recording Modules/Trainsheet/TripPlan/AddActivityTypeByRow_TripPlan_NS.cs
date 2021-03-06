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
    ///The AddActivityTypeByRow_TripPlan_NS recording.
    /// </summary>
    [TestModule("62523b7b-fe84-404b-a044-ee9ca31c8173", ModuleType.Recording, 1)]
    public partial class AddActivityTypeByRow_TripPlan_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AddActivityTypeByRow_TripPlan_NS instance = new AddActivityTypeByRow_TripPlan_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddActivityTypeByRow_TripPlan_NS()
        {
            trainSeed = "";
            activityType = "";
            opsta = "";
            expectedFeedback = "";
            optionalRowNo = "";
            dwell = "";
            fromActivityMP = "";
            toActivityMP = "";
            overlapActivity = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddActivityTypeByRow_TripPlan_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("0cbfc50d-bb83-4ca1-9bff-9f4557a4a0e3")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("950a66b5-5b50-4534-bd64-5c1162ed034c")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("fef55c45-b5a6-46ef-b6d5-ec70a2375a02")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("a729fce2-649b-4a62-8646-12d56ebbdebd")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _optionalRowNo;

        /// <summary>
        /// Gets or sets the value of variable optionalRowNo.
        /// </summary>
        [TestVariable("ea63f3bb-b6ea-4a52-9a0a-3d746d5cd2a3")]
        public string optionalRowNo
        {
            get { return _optionalRowNo; }
            set { _optionalRowNo = value; }
        }

        string _dwell;

        /// <summary>
        /// Gets or sets the value of variable dwell.
        /// </summary>
        [TestVariable("4ee889d2-8948-40cc-a47d-b7e83e5c60ae")]
        public string dwell
        {
            get { return _dwell; }
            set { _dwell = value; }
        }

        string _fromActivityMP;

        /// <summary>
        /// Gets or sets the value of variable fromActivityMP.
        /// </summary>
        [TestVariable("e1f5d146-c628-491a-a57a-10bfcfb642cd")]
        public string fromActivityMP
        {
            get { return _fromActivityMP; }
            set { _fromActivityMP = value; }
        }

        string _toActivityMP;

        /// <summary>
        /// Gets or sets the value of variable toActivityMP.
        /// </summary>
        [TestVariable("8c51e01a-17b5-49c5-92dd-65f81dbe6582")]
        public string toActivityMP
        {
            get { return _toActivityMP; }
            set { _toActivityMP = value; }
        }

        string _overlapActivity;

        /// <summary>
        /// Gets or sets the value of variable overlapActivity.
        /// </summary>
        [TestVariable("c2d7bf1e-b4d8-49d9-a04d-5af441214d8f")]
        public string overlapActivity
        {
            get { return _overlapActivity; }
            set { _overlapActivity = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_AddActivityTypeByRow_TripPlan(trainSeed, activityType, opsta, dwell, fromActivityMP, toActivityMP, expectedFeedback, optionalRowNo, overlapActivity);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
