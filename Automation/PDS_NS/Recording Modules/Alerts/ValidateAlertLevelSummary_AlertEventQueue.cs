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

namespace PDS_NS.Recording_Modules.Alerts
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateAlertLevelSummary_AlertEventQueue recording.
    /// </summary>
    [TestModule("cbf23364-df29-413a-8654-2044a8a29e67", ModuleType.Recording, 1)]
    public partial class ValidateAlertLevelSummary_AlertEventQueue : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateAlertLevelSummary_AlertEventQueue instance = new ValidateAlertLevelSummary_AlertEventQueue();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateAlertLevelSummary_AlertEventQueue()
        {
            closeForms = "True";
            alertLevelSummary = "";
            validateExist = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateAlertLevelSummary_AlertEventQueue Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("320b4dc0-60b8-42a8-ac44-5e626f05bab5")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _alertLevelSummary;

        /// <summary>
        /// Gets or sets the value of variable alertLevelSummary.
        /// </summary>
        [TestVariable("8b0139e9-c7ee-4678-918c-e020c21f3d20")]
        public string alertLevelSummary
        {
            get { return _alertLevelSummary; }
            set { _alertLevelSummary = value; }
        }

        string _validateExist;

        /// <summary>
        /// Gets or sets the value of variable validateExist.
        /// </summary>
        [TestVariable("b062397a-4c73-460d-a08d-0e8812df9598")]
        public string validateExist
        {
            get { return _validateExist; }
            set { _validateExist = value; }
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

            UserCodeCollections.NS_Miscellaneous.NS_ValidateAlertlevelSummary_AlertQueueSummary(alertLevelSummary, ValueConverter.ArgumentFromString<bool>("validateExist", validateExist), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
