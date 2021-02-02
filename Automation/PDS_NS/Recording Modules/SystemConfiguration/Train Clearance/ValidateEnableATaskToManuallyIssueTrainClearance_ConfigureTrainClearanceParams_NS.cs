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
    ///The ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS recording.
    /// </summary>
    [TestModule("afa45805-51e5-4a57-bbac-426fec32af63", ModuleType.Recording, 1)]
    public partial class ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS instance = new ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS()
        {
            enableATaskToManuallyIssueTrainClearance = "False";
            enableATaskToManuallyIssueTrainClearanceHours = "";
            enableATaskToManuallyIssueTrainClearanceMinutes = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _enableATaskToManuallyIssueTrainClearance;

        /// <summary>
        /// Gets or sets the value of variable enableATaskToManuallyIssueTrainClearance.
        /// </summary>
        [TestVariable("a48edcdc-f3e5-434b-a037-3f54f129f23e")]
        public string enableATaskToManuallyIssueTrainClearance
        {
            get { return _enableATaskToManuallyIssueTrainClearance; }
            set { _enableATaskToManuallyIssueTrainClearance = value; }
        }

        string _enableATaskToManuallyIssueTrainClearanceHours;

        /// <summary>
        /// Gets or sets the value of variable enableATaskToManuallyIssueTrainClearanceHours.
        /// </summary>
        [TestVariable("d08fa33b-1831-42bd-8fdb-1a3f9282870a")]
        public string enableATaskToManuallyIssueTrainClearanceHours
        {
            get { return _enableATaskToManuallyIssueTrainClearanceHours; }
            set { _enableATaskToManuallyIssueTrainClearanceHours = value; }
        }

        string _enableATaskToManuallyIssueTrainClearanceMinutes;

        /// <summary>
        /// Gets or sets the value of variable enableATaskToManuallyIssueTrainClearanceMinutes.
        /// </summary>
        [TestVariable("03f5e405-9efc-4d2c-bda7-1368590aeea0")]
        public string enableATaskToManuallyIssueTrainClearanceMinutes
        {
            get { return _enableATaskToManuallyIssueTrainClearanceMinutes; }
            set { _enableATaskToManuallyIssueTrainClearanceMinutes = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("1a96aaff-b098-4cfd-9bef-d8689d2a7720")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateEnableATaskToManuallyIssueTrainClearance_ConfigureTrainClearanceParams(ValueConverter.ArgumentFromString<bool>("enableATaskToManuallyIssueTrainClearance", enableATaskToManuallyIssueTrainClearance), enableATaskToManuallyIssueTrainClearanceHours, enableATaskToManuallyIssueTrainClearanceMinutes, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
