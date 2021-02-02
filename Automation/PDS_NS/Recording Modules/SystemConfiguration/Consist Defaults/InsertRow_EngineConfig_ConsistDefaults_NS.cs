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
    ///The InsertRow_EngineConfig_ConsistDefaults_NS recording.
    /// </summary>
    [TestModule("b322ad35-0385-4eca-a1c3-4777744c1322", ModuleType.Recording, 1)]
    public partial class InsertRow_EngineConfig_ConsistDefaults_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InsertRow_EngineConfig_ConsistDefaults_NS instance = new InsertRow_EngineConfig_ConsistDefaults_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InsertRow_EngineConfig_ConsistDefaults_NS()
        {
            locomotiveKey = "";
            maxSpeed = "";
            weight = "";
            length = "";
            hp = "";
            axles = "";
            crossSection = "";
            streamLiningCoeffL = "";
            streamLiningCoeffT = "";
            expectedFeedback = "";
            reset = "False";
            apply = "True";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InsertRow_EngineConfig_ConsistDefaults_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _locomotiveKey;

        /// <summary>
        /// Gets or sets the value of variable locomotiveKey.
        /// </summary>
        [TestVariable("4e981b55-e4f0-4b59-a144-c503ccc9428e")]
        public string locomotiveKey
        {
            get { return _locomotiveKey; }
            set { _locomotiveKey = value; }
        }

        string _maxSpeed;

        /// <summary>
        /// Gets or sets the value of variable maxSpeed.
        /// </summary>
        [TestVariable("75a3cfe7-3c00-4684-a32e-37c8f3018ab2")]
        public string maxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        string _weight;

        /// <summary>
        /// Gets or sets the value of variable weight.
        /// </summary>
        [TestVariable("0add1dda-5dce-4235-9d10-0acb4b8075cb")]
        public string weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        string _length;

        /// <summary>
        /// Gets or sets the value of variable length.
        /// </summary>
        [TestVariable("b4b22870-6f85-4dc3-b70d-776cbc4c028d")]
        public string length
        {
            get { return _length; }
            set { _length = value; }
        }

        string _hp;

        /// <summary>
        /// Gets or sets the value of variable hp.
        /// </summary>
        [TestVariable("f2c43cdf-bc57-42dd-bc98-07bd2a2060fb")]
        public string hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        string _axles;

        /// <summary>
        /// Gets or sets the value of variable axles.
        /// </summary>
        [TestVariable("67b42220-70c6-4460-86d2-a5d0ab89af05")]
        public string axles
        {
            get { return _axles; }
            set { _axles = value; }
        }

        string _crossSection;

        /// <summary>
        /// Gets or sets the value of variable crossSection.
        /// </summary>
        [TestVariable("23112b5d-8acc-4fd5-b870-db64c3beb2bf")]
        public string crossSection
        {
            get { return _crossSection; }
            set { _crossSection = value; }
        }

        string _streamLiningCoeffL;

        /// <summary>
        /// Gets or sets the value of variable streamLiningCoeffL.
        /// </summary>
        [TestVariable("f1f7cdd8-7a61-4ae3-b7f9-cc6a1938f8b4")]
        public string streamLiningCoeffL
        {
            get { return _streamLiningCoeffL; }
            set { _streamLiningCoeffL = value; }
        }

        string _streamLiningCoeffT;

        /// <summary>
        /// Gets or sets the value of variable streamLiningCoeffT.
        /// </summary>
        [TestVariable("cc361ca9-af29-45ed-8836-c533d41eab0b")]
        public string streamLiningCoeffT
        {
            get { return _streamLiningCoeffT; }
            set { _streamLiningCoeffT = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("80eb41cd-6fd3-46b1-8be4-fac0bfca2833")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("2a607493-01c7-4d0b-b427-752110dda54f")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("f2b58833-a761-4ecc-913e-441bacad84dd")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("4ef6d667-0d54-40ae-9981-9b37e7c8de14")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_InsertRow_EngineConfig_ConsistDefaults(locomotiveKey, maxSpeed, weight, length, hp, axles, crossSection, streamLiningCoeffL, streamLiningCoeffT, expectedFeedback, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
