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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Consist_Defaults
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateRowExists_EngineConfig_ConsistDefaults_NS recording.
    /// </summary>
    [TestModule("99db6dde-3aa4-48ee-a241-165a03ecc1b8", ModuleType.Recording, 1)]
    public partial class ValidateRowExists_EngineConfig_ConsistDefaults_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateRowExists_EngineConfig_ConsistDefaults_NS instance = new ValidateRowExists_EngineConfig_ConsistDefaults_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateRowExists_EngineConfig_ConsistDefaults_NS()
        {
            expLocomotiveKey = "";
            expMaxSpeed = "";
            expWeight = "";
            expLength = "";
            expHP = "";
            expAxles = "";
            expCrossSection = "";
            expStreamLiningCoeffL = "";
            expStreamLiningCoeffT = "";
            expValidateExist = "True";
            closeForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateRowExists_EngineConfig_ConsistDefaults_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expLocomotiveKey;

        /// <summary>
        /// Gets or sets the value of variable expLocomotiveKey.
        /// </summary>
        [TestVariable("531ed842-8de9-44c8-bc89-6eae78bd0a74")]
        public string expLocomotiveKey
        {
            get { return _expLocomotiveKey; }
            set { _expLocomotiveKey = value; }
        }

        string _expMaxSpeed;

        /// <summary>
        /// Gets or sets the value of variable expMaxSpeed.
        /// </summary>
        [TestVariable("f3190d1b-3982-4bec-8987-1219511d00d7")]
        public string expMaxSpeed
        {
            get { return _expMaxSpeed; }
            set { _expMaxSpeed = value; }
        }

        string _expWeight;

        /// <summary>
        /// Gets or sets the value of variable expWeight.
        /// </summary>
        [TestVariable("20958cd9-a930-4d81-a8b8-1037851e0f91")]
        public string expWeight
        {
            get { return _expWeight; }
            set { _expWeight = value; }
        }

        string _expLength;

        /// <summary>
        /// Gets or sets the value of variable expLength.
        /// </summary>
        [TestVariable("b2ed682c-0b30-4032-820c-01177fd8fbce")]
        public string expLength
        {
            get { return _expLength; }
            set { _expLength = value; }
        }

        string _expHP;

        /// <summary>
        /// Gets or sets the value of variable expHP.
        /// </summary>
        [TestVariable("60308fcc-a498-4aae-83c8-fead30808791")]
        public string expHP
        {
            get { return _expHP; }
            set { _expHP = value; }
        }

        string _expAxles;

        /// <summary>
        /// Gets or sets the value of variable expAxles.
        /// </summary>
        [TestVariable("b9466cd4-2c18-4bfe-9bd1-64228e0bc31c")]
        public string expAxles
        {
            get { return _expAxles; }
            set { _expAxles = value; }
        }

        string _expCrossSection;

        /// <summary>
        /// Gets or sets the value of variable expCrossSection.
        /// </summary>
        [TestVariable("26016bd5-a980-4965-a290-5c75217d2db0")]
        public string expCrossSection
        {
            get { return _expCrossSection; }
            set { _expCrossSection = value; }
        }

        string _expStreamLiningCoeffL;

        /// <summary>
        /// Gets or sets the value of variable expStreamLiningCoeffL.
        /// </summary>
        [TestVariable("1d524b65-366c-4df1-afc2-f18d0d3fd19a")]
        public string expStreamLiningCoeffL
        {
            get { return _expStreamLiningCoeffL; }
            set { _expStreamLiningCoeffL = value; }
        }

        string _expStreamLiningCoeffT;

        /// <summary>
        /// Gets or sets the value of variable expStreamLiningCoeffT.
        /// </summary>
        [TestVariable("b660e084-993d-4b83-a21c-94acfc5f7805")]
        public string expStreamLiningCoeffT
        {
            get { return _expStreamLiningCoeffT; }
            set { _expStreamLiningCoeffT = value; }
        }

        string _expValidateExist;

        /// <summary>
        /// Gets or sets the value of variable expValidateExist.
        /// </summary>
        [TestVariable("4d850417-c5b7-4ad6-afb9-892d4cb7b860")]
        public string expValidateExist
        {
            get { return _expValidateExist; }
            set { _expValidateExist = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("b6c503e7-007e-4ae3-9c80-a1b67e51d3b6")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateRowExists_EngineConfig_ConsistDefaults(expLocomotiveKey, expMaxSpeed, expWeight, expLength, expHP, expAxles, expCrossSection, expStreamLiningCoeffL, expStreamLiningCoeffT, ValueConverter.ArgumentFromString<bool>("expValidateExist", expValidateExist), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
