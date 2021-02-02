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
    ///The ValidateActivityStatus_NS recording.
    /// </summary>
    [TestModule("47e85f5e-986d-4126-9534-b16c27c5ab8e", ModuleType.Recording, 1)]
    public partial class ValidateActivityStatus_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateActivityStatus_NS instance = new ValidateActivityStatus_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateActivityStatus_NS()
        {
            trainSeed = "";
            expectedActivityState = "";
            activityType = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateActivityStatus_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("b227a30a-ca3e-47a1-b3bc-01ebb2b21f3a")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _expectedActivityState;

        /// <summary>
        /// Gets or sets the value of variable expectedActivityState.
        /// </summary>
        [TestVariable("bba41a54-df7b-4342-b324-16445080776b")]
        public string expectedActivityState
        {
            get { return _expectedActivityState; }
            set { _expectedActivityState = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("4e9e84d9-0b92-45b5-92b1-5318601244e4")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateActivityStatus_TrainSheet(trainSeed, expectedActivityState, activityType);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}