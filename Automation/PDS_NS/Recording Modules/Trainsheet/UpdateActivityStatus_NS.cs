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
    ///The UpdateActivityStatus_NS recording.
    /// </summary>
    [TestModule("75e6681a-a999-4b66-921e-ac9922b5d556", ModuleType.Recording, 1)]
    public partial class UpdateActivityStatus_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static UpdateActivityStatus_NS instance = new UpdateActivityStatus_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public UpdateActivityStatus_NS()
        {
            trainSeed = "";
            activityState = "";
            activityType = "";
            closeForm = "True";
            opsta = "";
            moveTrain = "yes";
            pressApply = "True";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static UpdateActivityStatus_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("0464bc7f-d9f0-4976-b5cc-b4c0eceae29f")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _activityState;

        /// <summary>
        /// Gets or sets the value of variable activityState.
        /// </summary>
        [TestVariable("29f4ed25-8960-407d-8988-871c97d513af")]
        public string activityState
        {
            get { return _activityState; }
            set { _activityState = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("6797eb3a-0723-414d-b290-c90f906faa52")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("a1879c0c-7ec3-45ad-9cad-71c344a5e406")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("9df89351-8a5f-41f0-beb8-452790105996")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _moveTrain;

        /// <summary>
        /// Gets or sets the value of variable moveTrain.
        /// </summary>
        [TestVariable("4179f4a8-980b-4588-9b8e-bb15ec55622f")]
        public string moveTrain
        {
            get { return _moveTrain; }
            set { _moveTrain = value; }
        }

        string _pressApply;

        /// <summary>
        /// Gets or sets the value of variable pressApply.
        /// </summary>
        [TestVariable("51d5f3a0-94d0-4898-99a9-535104e46835")]
        public string pressApply
        {
            get { return _pressApply; }
            set { _pressApply = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("00a41474-5cd4-420f-b4cc-1a684e397d92")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_UpdateActivityStatus_TrainSheet(trainSeed, activityState, activityType, opsta, moveTrain, ValueConverter.ArgumentFromString<bool>("pressApply", pressApply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm), expectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
