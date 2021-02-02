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

namespace PDS_NS.Recording_Modules.SystemConfiguration.CTC_Parameters
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS recording.
    /// </summary>
    [TestModule("f1320c67-4c38-45d6-bdef-bfa874a427de", ModuleType.Recording, 1)]
    public partial class ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS instance = new ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS()
        {
            timeOutValue = "";
            expectedFeedback = "";
            reset = "False";
            clickApply = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyGlobalSwitchRequestTimeOutValue_CTCParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeOutValue;

        /// <summary>
        /// Gets or sets the value of variable timeOutValue.
        /// </summary>
        [TestVariable("3019cb67-1a87-4232-9e61-589fb8d419ab")]
        public string timeOutValue
        {
            get { return _timeOutValue; }
            set { _timeOutValue = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("b7a3652f-c665-4817-87f7-a3ad27a6a6a9")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("acf0ee60-9b8d-4ba4-9f7e-5eac411751e5")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("c2fb4207-48a2-4520-aa73-e4c8f5da99c8")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("c4eeda7c-b9e1-43a9-848c-56aa03bf37a8")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyGlobalSwitchRequestTimeOutValue_CTCParameters(timeOutValue, expectedFeedback, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
