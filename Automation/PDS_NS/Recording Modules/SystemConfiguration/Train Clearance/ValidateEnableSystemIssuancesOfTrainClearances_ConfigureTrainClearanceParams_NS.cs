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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Train_Clearance
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS recording.
    /// </summary>
    [TestModule("e2b5ce6c-62ca-450c-ada6-58d2c7bc9848", ModuleType.Recording, 1)]
    public partial class ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS instance = new ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS()
        {
            enableSystemIssuancesOfTrainClearances = "False";
            enableSystemIssuancesOfTrainClearancesHours = "";
            enableSystemIssuancesOfTrainClearancesMinutes = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _enableSystemIssuancesOfTrainClearances;

        /// <summary>
        /// Gets or sets the value of variable enableSystemIssuancesOfTrainClearances.
        /// </summary>
        [TestVariable("4dfcd24b-55b0-4ab1-be22-67bc148d01ba")]
        public string enableSystemIssuancesOfTrainClearances
        {
            get { return _enableSystemIssuancesOfTrainClearances; }
            set { _enableSystemIssuancesOfTrainClearances = value; }
        }

        string _enableSystemIssuancesOfTrainClearancesHours;

        /// <summary>
        /// Gets or sets the value of variable enableSystemIssuancesOfTrainClearancesHours.
        /// </summary>
        [TestVariable("c2779700-7b72-4b00-ae3b-266ea986233c")]
        public string enableSystemIssuancesOfTrainClearancesHours
        {
            get { return _enableSystemIssuancesOfTrainClearancesHours; }
            set { _enableSystemIssuancesOfTrainClearancesHours = value; }
        }

        string _enableSystemIssuancesOfTrainClearancesMinutes;

        /// <summary>
        /// Gets or sets the value of variable enableSystemIssuancesOfTrainClearancesMinutes.
        /// </summary>
        [TestVariable("b58ad420-7250-4cb7-8fb0-265bb3032152")]
        public string enableSystemIssuancesOfTrainClearancesMinutes
        {
            get { return _enableSystemIssuancesOfTrainClearancesMinutes; }
            set { _enableSystemIssuancesOfTrainClearancesMinutes = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("1279b8fa-49b6-46e6-95a0-65413e066fea")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateEnableSystemIssuancesOfTrainClearances_ConfigureTrainClearanceParams(ValueConverter.ArgumentFromString<bool>("enableSystemIssuancesOfTrainClearances", enableSystemIssuancesOfTrainClearances), enableSystemIssuancesOfTrainClearancesHours, enableSystemIssuancesOfTrainClearancesMinutes, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}