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
    ///The ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS recording.
    /// </summary>
    [TestModule("90d2db26-a00e-486b-ba9e-a99ae11dc520", ModuleType.Recording, 1)]
    public partial class ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS instance = new ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS()
        {
            locomotiveKey = "";
            newMaxSpeed = "";
            newWeight = "";
            newLength = "";
            newHP = "";
            newAxles = "";
            newCrossSection = "";
            newStreamLiningCoeffL = "";
            newStreamLiningCoeffT = "";
            expectedFeedback = "";
            apply = "True";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyEngineConfigByLocomotiveKey_TrainDefaultData_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _locomotiveKey;

        /// <summary>
        /// Gets or sets the value of variable locomotiveKey.
        /// </summary>
        [TestVariable("db4a4b77-15da-4c26-89d1-26f8504ebbce")]
        public string locomotiveKey
        {
            get { return _locomotiveKey; }
            set { _locomotiveKey = value; }
        }

        string _newMaxSpeed;

        /// <summary>
        /// Gets or sets the value of variable newMaxSpeed.
        /// </summary>
        [TestVariable("803ffb56-e87b-4847-adb2-4ad8ebea412e")]
        public string newMaxSpeed
        {
            get { return _newMaxSpeed; }
            set { _newMaxSpeed = value; }
        }

        string _newWeight;

        /// <summary>
        /// Gets or sets the value of variable newWeight.
        /// </summary>
        [TestVariable("d8d558bc-c096-4a9b-bab1-a9cef11b9dbc")]
        public string newWeight
        {
            get { return _newWeight; }
            set { _newWeight = value; }
        }

        string _newLength;

        /// <summary>
        /// Gets or sets the value of variable newLength.
        /// </summary>
        [TestVariable("ebed3447-a70a-4cb9-afd7-5ad537dd3fe0")]
        public string newLength
        {
            get { return _newLength; }
            set { _newLength = value; }
        }

        string _newHP;

        /// <summary>
        /// Gets or sets the value of variable newHP.
        /// </summary>
        [TestVariable("3e098060-5282-4a3b-889b-8b26e830faab")]
        public string newHP
        {
            get { return _newHP; }
            set { _newHP = value; }
        }

        string _newAxles;

        /// <summary>
        /// Gets or sets the value of variable newAxles.
        /// </summary>
        [TestVariable("30ab6cf4-fd25-4da7-b8fb-e3481390a18b")]
        public string newAxles
        {
            get { return _newAxles; }
            set { _newAxles = value; }
        }

        string _newCrossSection;

        /// <summary>
        /// Gets or sets the value of variable newCrossSection.
        /// </summary>
        [TestVariable("a427a6ef-a439-4517-b99a-619abc01b7cd")]
        public string newCrossSection
        {
            get { return _newCrossSection; }
            set { _newCrossSection = value; }
        }

        string _newStreamLiningCoeffL;

        /// <summary>
        /// Gets or sets the value of variable newStreamLiningCoeffL.
        /// </summary>
        [TestVariable("f91f9963-6572-4fdb-9fd7-8de1901544f8")]
        public string newStreamLiningCoeffL
        {
            get { return _newStreamLiningCoeffL; }
            set { _newStreamLiningCoeffL = value; }
        }

        string _newStreamLiningCoeffT;

        /// <summary>
        /// Gets or sets the value of variable newStreamLiningCoeffT.
        /// </summary>
        [TestVariable("e1555c8e-5b30-42e8-9613-510bfaaf14b5")]
        public string newStreamLiningCoeffT
        {
            get { return _newStreamLiningCoeffT; }
            set { _newStreamLiningCoeffT = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("a33e43ab-1d8e-4123-9db2-0a85f8b24f1f")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("8b4d6b4c-cb38-49b9-a44d-f76393e046ed")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("2b7ace1e-3a01-4c13-a24b-cbac3921eb93")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyEngineConfigByLocomotiveKey_TrainDefaultData(locomotiveKey, newMaxSpeed, newWeight, newLength, newHP, newAxles, newCrossSection, newStreamLiningCoeffL, newStreamLiningCoeffT, expectedFeedback, ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
