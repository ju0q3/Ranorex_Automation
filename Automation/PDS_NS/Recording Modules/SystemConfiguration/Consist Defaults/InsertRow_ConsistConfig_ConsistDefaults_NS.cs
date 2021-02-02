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
    ///The InsertRow_ConsistConfig_ConsistDefaults_NS recording.
    /// </summary>
    [TestModule("6e42eb32-da00-4240-b903-efb0f1e19da2", ModuleType.Recording, 1)]
    public partial class InsertRow_ConsistConfig_ConsistDefaults_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InsertRow_ConsistConfig_ConsistDefaults_NS instance = new InsertRow_ConsistConfig_ConsistDefaults_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InsertRow_ConsistConfig_ConsistDefaults_NS()
        {
            trainGroup = "";
            trainCategory = "";
            loads = "";
            empties = "";
            tonnage = "";
            length = "";
            carCategory = "";
            enginesNumbers = "";
            locomotiveKey = "";
            height = "";
            expectedFeedback = "";
            reset = "False";
            apply = "True";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InsertRow_ConsistConfig_ConsistDefaults_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainGroup;

        /// <summary>
        /// Gets or sets the value of variable trainGroup.
        /// </summary>
        [TestVariable("cb8f13fa-4c60-446b-9bc7-03ec28038b71")]
        public string trainGroup
        {
            get { return _trainGroup; }
            set { _trainGroup = value; }
        }

        string _trainCategory;

        /// <summary>
        /// Gets or sets the value of variable trainCategory.
        /// </summary>
        [TestVariable("9a187843-5b26-4340-97ea-4d4e4ae37906")]
        public string trainCategory
        {
            get { return _trainCategory; }
            set { _trainCategory = value; }
        }

        string _loads;

        /// <summary>
        /// Gets or sets the value of variable loads.
        /// </summary>
        [TestVariable("56d33593-6cf9-446c-bcbd-3c36957f56ce")]
        public string loads
        {
            get { return _loads; }
            set { _loads = value; }
        }

        string _empties;

        /// <summary>
        /// Gets or sets the value of variable empties.
        /// </summary>
        [TestVariable("dd84ee7a-12de-4716-98be-bbb5a1ec8767")]
        public string empties
        {
            get { return _empties; }
            set { _empties = value; }
        }

        string _tonnage;

        /// <summary>
        /// Gets or sets the value of variable tonnage.
        /// </summary>
        [TestVariable("d45d39c0-8655-4754-8dea-c6f7869581d0")]
        public string tonnage
        {
            get { return _tonnage; }
            set { _tonnage = value; }
        }

        string _length;

        /// <summary>
        /// Gets or sets the value of variable length.
        /// </summary>
        [TestVariable("bf5af0d6-a680-4e2f-8f64-f8e45660262b")]
        public string length
        {
            get { return _length; }
            set { _length = value; }
        }

        string _carCategory;

        /// <summary>
        /// Gets or sets the value of variable carCategory.
        /// </summary>
        [TestVariable("5bbe364d-407d-4b6a-ba84-d441b9f01d8c")]
        public string carCategory
        {
            get { return _carCategory; }
            set { _carCategory = value; }
        }

        string _enginesNumbers;

        /// <summary>
        /// Gets or sets the value of variable enginesNumbers.
        /// </summary>
        [TestVariable("dc074a72-2fc5-44ba-978b-3a0c66296f17")]
        public string enginesNumbers
        {
            get { return _enginesNumbers; }
            set { _enginesNumbers = value; }
        }

        string _locomotiveKey;

        /// <summary>
        /// Gets or sets the value of variable locomotiveKey.
        /// </summary>
        [TestVariable("848d9e79-60e1-4d33-b39f-02a16fc30121")]
        public string locomotiveKey
        {
            get { return _locomotiveKey; }
            set { _locomotiveKey = value; }
        }

        string _height;

        /// <summary>
        /// Gets or sets the value of variable height.
        /// </summary>
        [TestVariable("5c0292b0-624c-49f2-b8a0-674a02a34698")]
        public string height
        {
            get { return _height; }
            set { _height = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("e037eb27-10f2-4c61-906e-64f673d4b590")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("35d3d16f-4690-4ad1-8105-ffb62b62fb20")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("eab0ae20-f43d-44bc-ba0f-69294175f0eb")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("e4cfeb0f-1d68-4396-91ee-74de7eafaa6a")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_InsertRow_ConsistConfig_ConsistDefaults(trainGroup, trainCategory, loads, empties, tonnage, length, carCategory, enginesNumbers, locomotiveKey, height, expectedFeedback, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}