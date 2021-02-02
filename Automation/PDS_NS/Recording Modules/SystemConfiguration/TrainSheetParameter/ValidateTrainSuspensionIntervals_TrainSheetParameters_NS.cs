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
    ///The ValidateTrainSuspensionIntervals_TrainSheetParameters_NS recording.
    /// </summary>
    [TestModule("d21b0d8d-4bcd-4efe-bdb1-e48e074e6bd2", ModuleType.Recording, 1)]
    public partial class ValidateTrainSuspensionIntervals_TrainSheetParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTrainSuspensionIntervals_TrainSheetParameters_NS instance = new ValidateTrainSuspensionIntervals_TrainSheetParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTrainSuspensionIntervals_TrainSheetParameters_NS()
        {
            expDepartureSuspensionInterval = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTrainSuspensionIntervals_TrainSheetParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expDepartureSuspensionInterval;

        /// <summary>
        /// Gets or sets the value of variable expDepartureSuspensionInterval.
        /// </summary>
        [TestVariable("e27a4904-0db5-4fdf-9338-77263b9f4e3b")]
        public string expDepartureSuspensionInterval
        {
            get { return _expDepartureSuspensionInterval; }
            set { _expDepartureSuspensionInterval = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("965b7504-d6d2-4b38-80f2-ccbb42c284f7")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateTrainSuspensionIntervals_TrainSheetParameters(expDepartureSuspensionInterval, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
