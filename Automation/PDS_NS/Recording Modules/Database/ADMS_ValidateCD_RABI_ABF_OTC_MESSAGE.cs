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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE recording.
    /// </summary>
    [TestModule("f3d93e29-19c8-4d4c-9f08-b85ab83ca0c0", ModuleType.Recording, 1)]
    public partial class ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE instance = new ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE()
        {
            trainSymbolTrainSeed = "";
            trainClearanceNumberTrainSeed = "";
            engineNumberTrainSeed = "";
            engineNumberEngineSeed = "";
            requestType = "";
            minutesBeforeNow = "";
            expectedCount = "";
            validateExists = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_ValidateCD_RABI_ABF_OTC_MESSAGE Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSymbolTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSymbolTrainSeed.
        /// </summary>
        [TestVariable("412cbaa7-bf62-4b6b-9876-fdb4bd3359cf")]
        public string trainSymbolTrainSeed
        {
            get { return _trainSymbolTrainSeed; }
            set { _trainSymbolTrainSeed = value; }
        }

        string _trainClearanceNumberTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainClearanceNumberTrainSeed.
        /// </summary>
        [TestVariable("683c3c41-9593-4982-a05a-ea57158fdb90")]
        public string trainClearanceNumberTrainSeed
        {
            get { return _trainClearanceNumberTrainSeed; }
            set { _trainClearanceNumberTrainSeed = value; }
        }

        string _engineNumberTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable engineNumberTrainSeed.
        /// </summary>
        [TestVariable("82354bfb-ca75-4ffb-a6fc-1e24f2a0783e")]
        public string engineNumberTrainSeed
        {
            get { return _engineNumberTrainSeed; }
            set { _engineNumberTrainSeed = value; }
        }

        string _engineNumberEngineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineNumberEngineSeed.
        /// </summary>
        [TestVariable("9ae94736-7121-497b-863f-614350ed1d78")]
        public string engineNumberEngineSeed
        {
            get { return _engineNumberEngineSeed; }
            set { _engineNumberEngineSeed = value; }
        }

        string _requestType;

        /// <summary>
        /// Gets or sets the value of variable requestType.
        /// </summary>
        [TestVariable("7a816009-b804-4055-b865-999aff47bbaa")]
        public string requestType
        {
            get { return _requestType; }
            set { _requestType = value; }
        }

        string _minutesBeforeNow;

        /// <summary>
        /// Gets or sets the value of variable minutesBeforeNow.
        /// </summary>
        [TestVariable("83c1c59e-59bd-4955-b80c-d455b864964c")]
        public string minutesBeforeNow
        {
            get { return _minutesBeforeNow; }
            set { _minutesBeforeNow = value; }
        }

        string _expectedCount;

        /// <summary>
        /// Gets or sets the value of variable expectedCount.
        /// </summary>
        [TestVariable("3d1adc39-3f22-47fe-b7cb-fcb58ee68207")]
        public string expectedCount
        {
            get { return _expectedCount; }
            set { _expectedCount = value; }
        }

        string _validateExists;

        /// <summary>
        /// Gets or sets the value of variable validateExists.
        /// </summary>
        [TestVariable("a3a7e581-939d-4cb1-abae-6b6d92b3ddb5")]
        public string validateExists
        {
            get { return _validateExists; }
            set { _validateExists = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateCD_RABI_ABF_OTC_MESSAGE_ADMS(trainSymbolTrainSeed, trainClearanceNumberTrainSeed, engineNumberTrainSeed, engineNumberEngineSeed, requestType, minutesBeforeNow, expectedCount, ValueConverter.ArgumentFromString<bool>("validateExists", validateExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
