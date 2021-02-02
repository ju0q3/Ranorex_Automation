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

namespace PDS_NS.Recording_Modules.SystemConfiguration.TrainSheetParameter
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateCrewandEngineData_TrainSheetParameters recording.
    /// </summary>
    [TestModule("0fd3fdcd-df84-4e47-8be1-565d843ee713", ModuleType.Recording, 1)]
    public partial class ValidateCrewandEngineData_TrainSheetParameters : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateCrewandEngineData_TrainSheetParameters instance = new ValidateCrewandEngineData_TrainSheetParameters();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateCrewandEngineData_TrainSheetParameters()
        {
            trainGroup = "";
            exp_MinimumCrewMembers = "";
            exp_EngineAtDeparture = "";
            exp_EngineAtArrival = "";
            closeForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateCrewandEngineData_TrainSheetParameters Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainGroup;

        /// <summary>
        /// Gets or sets the value of variable trainGroup.
        /// </summary>
        [TestVariable("8b85b01e-f004-4a75-8511-a9baa5d35de5")]
        public string trainGroup
        {
            get { return _trainGroup; }
            set { _trainGroup = value; }
        }

        string _exp_MinimumCrewMembers;

        /// <summary>
        /// Gets or sets the value of variable exp_MinimumCrewMembers.
        /// </summary>
        [TestVariable("2b550ad4-1b5f-479c-ad09-2484e4f9e177")]
        public string exp_MinimumCrewMembers
        {
            get { return _exp_MinimumCrewMembers; }
            set { _exp_MinimumCrewMembers = value; }
        }

        string _exp_EngineAtDeparture;

        /// <summary>
        /// Gets or sets the value of variable exp_EngineAtDeparture.
        /// </summary>
        [TestVariable("8d67287a-a68e-4ac8-b3bd-a04908df30bc")]
        public string exp_EngineAtDeparture
        {
            get { return _exp_EngineAtDeparture; }
            set { _exp_EngineAtDeparture = value; }
        }

        string _exp_EngineAtArrival;

        /// <summary>
        /// Gets or sets the value of variable exp_EngineAtArrival.
        /// </summary>
        [TestVariable("dca9efae-6741-4bfa-92d8-71a6a8127525")]
        public string exp_EngineAtArrival
        {
            get { return _exp_EngineAtArrival; }
            set { _exp_EngineAtArrival = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("9885b068-1e74-4a60-a529-7245d17bb046")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateCrewandEngineData_TrainSheetParameter(trainGroup, exp_MinimumCrewMembers, exp_EngineAtDeparture, exp_EngineAtArrival, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}