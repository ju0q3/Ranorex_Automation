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

namespace PDS_NS.Recording_Modules.Trainsheet
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_CopyCrewfromTraintoTrain_TrainSheet recording.
    /// </summary>
    [TestModule("d5b114b8-bcd0-4011-a611-a68f635a64e8", ModuleType.Recording, 1)]
    public partial class NS_CopyCrewfromTraintoTrain_TrainSheet : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_CopyCrewfromTraintoTrain_TrainSheet instance = new NS_CopyCrewfromTraintoTrain_TrainSheet();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_CopyCrewfromTraintoTrain_TrainSheet()
        {
            fromTrainSeed = "";
            toTrainSeed = "";
            crewSeed = "";
            copy = "false";
            closeForms = "false";
            expectedFeedback = "";
            crewMemberRecord = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_CopyCrewfromTraintoTrain_TrainSheet Instance
        {
            get { return instance; }
        }

#region Variables

        string _fromTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable fromTrainSeed.
        /// </summary>
        [TestVariable("39a1b701-74b7-400a-8104-e23d382b6e71")]
        public string fromTrainSeed
        {
            get { return _fromTrainSeed; }
            set { _fromTrainSeed = value; }
        }

        string _toTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable toTrainSeed.
        /// </summary>
        [TestVariable("f6046f2d-8e4f-407a-b98d-f123831e89bd")]
        public string toTrainSeed
        {
            get { return _toTrainSeed; }
            set { _toTrainSeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("d3c2aa78-9206-43b7-8106-c5c37d07596e")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _copy;

        /// <summary>
        /// Gets or sets the value of variable copy.
        /// </summary>
        [TestVariable("c16e1182-2153-4caa-953f-a80e80043675")]
        public string copy
        {
            get { return _copy; }
            set { _copy = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("212075b8-e3c4-4bf6-8fbf-7d2608869ed8")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("ffea2366-271a-4fb5-a5d7-926ed99e9f74")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _crewMemberRecord;

        /// <summary>
        /// Gets or sets the value of variable crewMemberRecord.
        /// </summary>
        [TestVariable("476f316e-83db-4d8b-8b3c-26e3f48381bb")]
        public string crewMemberRecord
        {
            get { return _crewMemberRecord; }
            set { _crewMemberRecord = value; }
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

            UserCodeCollections.NS_Trainsheet.CopyCrewFromTrainToTrain_TrainSheet(fromTrainSeed, toTrainSeed, crewSeed, crewMemberRecord, expectedFeedback, ValueConverter.ArgumentFromString<bool>("copy", copy), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
