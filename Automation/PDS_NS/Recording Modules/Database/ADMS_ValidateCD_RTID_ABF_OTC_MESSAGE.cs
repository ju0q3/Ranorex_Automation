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
    ///The ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE recording.
    /// </summary>
    [TestModule("5a3edc99-f80a-4c2a-839f-0779d3730fc7", ModuleType.Recording, 1)]
    public partial class ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE instance = new ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE()
        {
            trainClearanceNumberTrainSeed = "";
            engineNumberTrainSeed = "";
            engineNumberEngineSeed = "";
            minutesBeforeNow = "";
            expectedCount = "";
            validateExists = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_ValidateCD_RTID_ABF_OTC_MESSAGE Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainClearanceNumberTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainClearanceNumberTrainSeed.
        /// </summary>
        [TestVariable("740c8a3b-459b-4fc6-a41e-c7f35b1d2f4a")]
        public string trainClearanceNumberTrainSeed
        {
            get { return _trainClearanceNumberTrainSeed; }
            set { _trainClearanceNumberTrainSeed = value; }
        }

        string _engineNumberTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable engineNumberTrainSeed.
        /// </summary>
        [TestVariable("f7c36b83-2f5d-4001-83e0-da209a5f8ec7")]
        public string engineNumberTrainSeed
        {
            get { return _engineNumberTrainSeed; }
            set { _engineNumberTrainSeed = value; }
        }

        string _engineNumberEngineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineNumberEngineSeed.
        /// </summary>
        [TestVariable("f08c8827-3566-46bd-9064-f1f3f6e41d7a")]
        public string engineNumberEngineSeed
        {
            get { return _engineNumberEngineSeed; }
            set { _engineNumberEngineSeed = value; }
        }

        string _minutesBeforeNow;

        /// <summary>
        /// Gets or sets the value of variable minutesBeforeNow.
        /// </summary>
        [TestVariable("0d219f7f-321d-4134-9697-131f4d9cc1ab")]
        public string minutesBeforeNow
        {
            get { return _minutesBeforeNow; }
            set { _minutesBeforeNow = value; }
        }

        string _expectedCount;

        /// <summary>
        /// Gets or sets the value of variable expectedCount.
        /// </summary>
        [TestVariable("aaa214d3-eda4-4af2-a675-ef4e9be31b94")]
        public string expectedCount
        {
            get { return _expectedCount; }
            set { _expectedCount = value; }
        }

        string _validateExists;

        /// <summary>
        /// Gets or sets the value of variable validateExists.
        /// </summary>
        [TestVariable("298e3311-550d-4300-915d-7cb8044b3936")]
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateCD_RTID_ABF_OTC_MESSAGE_ADMS(trainClearanceNumberTrainSeed, engineNumberTrainSeed, engineNumberEngineSeed, minutesBeforeNow, expectedCount, ValueConverter.ArgumentFromString<bool>("validateExists", validateExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}