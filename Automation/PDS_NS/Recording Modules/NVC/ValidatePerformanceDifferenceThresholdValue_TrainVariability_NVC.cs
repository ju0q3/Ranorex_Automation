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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC recording.
    /// </summary>
    [TestModule("449a3a24-9a88-4fa9-933b-373d5c3086c2", ModuleType.Recording, 1)]
    public partial class ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC instance = new ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC()
        {
            thresholdValue = "25";
            thresholdUnit = "Minutes";
            expectExists = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _thresholdValue;

        /// <summary>
        /// Gets or sets the value of variable thresholdValue.
        /// </summary>
        [TestVariable("4485cd2b-5155-4475-9149-e39e21896106")]
        public string thresholdValue
        {
            get { return _thresholdValue; }
            set { _thresholdValue = value; }
        }

        string _thresholdUnit;

        /// <summary>
        /// Gets or sets the value of variable thresholdUnit.
        /// </summary>
        [TestVariable("4fa3ddb2-c114-41fa-b95e-6ec3a8fd6fb5")]
        public string thresholdUnit
        {
            get { return _thresholdUnit; }
            set { _thresholdUnit = value; }
        }

        string _expectExists;

        /// <summary>
        /// Gets or sets the value of variable expectExists.
        /// </summary>
        [TestVariable("008c5490-a258-45e8-95b8-9abcd61a1125")]
        public string expectExists
        {
            get { return _expectExists; }
            set { _expectExists = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidatePerformanceDifferenceThresholdValue_TrainVariability_NVC(thresholdValue, thresholdUnit, ValueConverter.ArgumentFromString<bool>("expectExists", expectExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
