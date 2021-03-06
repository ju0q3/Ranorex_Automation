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

namespace PDS_NS.Recording_Modules.TrainClearance
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS recording.
    /// </summary>
    [TestModule("67ae92dc-0f11-4277-bd6a-1baaef716c42", ModuleType.Recording, 1)]
    public partial class ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS instance = new ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS()
        {
            validateExists = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _validateExists;

        /// <summary>
        /// Gets or sets the value of variable validateExists.
        /// </summary>
        [TestVariable("cf4f5610-6ff2-4831-a258-085d712525db")]
        public string validateExists
        {
            get { return _validateExists; }
            set { _validateExists = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("15ba3a92-48ce-43a5-b02e-75a32c3842eb")]
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

            UserCodeCollections.NS_TrainClearance_Validations.NS_ValidateTrainClearanceTableExistsOrNot_TrainClearanceSummaryList(ValueConverter.ArgumentFromString<bool>("validateExists", validateExists), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
