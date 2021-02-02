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

namespace PDS_NS.Recording_Modules.MIS
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateTrainConsistActivity_MISSimple_NS recording.
    /// </summary>
    [TestModule("c3cd101c-e547-4600-8cf0-60e5e7aadaae", ModuleType.Recording, 1)]
    public partial class CreateTrainConsistActivity_MISSimple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateTrainConsistActivity_MISSimple_NS instance = new CreateTrainConsistActivity_MISSimple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateTrainConsistActivity_MISSimple_NS()
        {
            trainSeed = "";
            location = "";
            passCount = "";
            reportingSource = "";
            estimatedDwellInterval = "";
            maxCarWeightConstrainIndicator = "";
            maxCarWeight = "";
            maxCarWeightTo = "";
            maxCarWeightToPassCount = "";
            maxCarHeightConstraintIndicator = "";
            maxCarHeight = "";
            maxCarHeightTo = "";
            maxCarHeightToPassCount = "";
            maxCarWidthConstrainIndicator = "";
            maxCarWidth = "";
            maxCarWidthTo = "";
            maxCarWidthToPassCount = "";
            hazmatTrainConstrainIndicator = "";
            keyTrainIndicator = "";
            hazmatTrainTo = "";
            hazmatTrainToPassCount = "";
            pickupsetOutRecords = "";
            coalClassificationRecords = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateTrainConsistActivity_MISSimple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("85b39f08-8b08-4d0f-8268-604472c434e7")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _location;

        /// <summary>
        /// Gets or sets the value of variable location.
        /// </summary>
        [TestVariable("979a694d-0fbe-449b-8cc7-e9ee03f154d1")]
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }

        string _passCount;

        /// <summary>
        /// Gets or sets the value of variable passCount.
        /// </summary>
        [TestVariable("e0fa91bd-9bd9-4f8f-954f-0e809ceca576")]
        public string passCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        string _reportingSource;

        /// <summary>
        /// Gets or sets the value of variable reportingSource.
        /// </summary>
        [TestVariable("e81b8be3-b414-41fa-9821-29997d7aad8d")]
        public string reportingSource
        {
            get { return _reportingSource; }
            set { _reportingSource = value; }
        }

        string _estimatedDwellInterval;

        /// <summary>
        /// Gets or sets the value of variable estimatedDwellInterval.
        /// </summary>
        [TestVariable("a42d9a83-5b24-4e1e-baff-47c64710d083")]
        public string estimatedDwellInterval
        {
            get { return _estimatedDwellInterval; }
            set { _estimatedDwellInterval = value; }
        }

        string _maxCarWeightConstrainIndicator;

        /// <summary>
        /// Gets or sets the value of variable maxCarWeightConstrainIndicator.
        /// </summary>
        [TestVariable("eff6e09f-cb5f-4bd4-b30a-83d8a9fb2a27")]
        public string maxCarWeightConstrainIndicator
        {
            get { return _maxCarWeightConstrainIndicator; }
            set { _maxCarWeightConstrainIndicator = value; }
        }

        string _maxCarWeight;

        /// <summary>
        /// Gets or sets the value of variable maxCarWeight.
        /// </summary>
        [TestVariable("5a26a370-7407-483c-9f00-472b60346936")]
        public string maxCarWeight
        {
            get { return _maxCarWeight; }
            set { _maxCarWeight = value; }
        }

        string _maxCarWeightTo;

        /// <summary>
        /// Gets or sets the value of variable maxCarWeightTo.
        /// </summary>
        [TestVariable("f4bcdaca-a219-48f6-bbc3-901dc804bb03")]
        public string maxCarWeightTo
        {
            get { return _maxCarWeightTo; }
            set { _maxCarWeightTo = value; }
        }

        string _maxCarWeightToPassCount;

        /// <summary>
        /// Gets or sets the value of variable maxCarWeightToPassCount.
        /// </summary>
        [TestVariable("cdc9ecf2-5891-4ef2-8bdd-9bee3a334412")]
        public string maxCarWeightToPassCount
        {
            get { return _maxCarWeightToPassCount; }
            set { _maxCarWeightToPassCount = value; }
        }

        string _maxCarHeightConstraintIndicator;

        /// <summary>
        /// Gets or sets the value of variable maxCarHeightConstraintIndicator.
        /// </summary>
        [TestVariable("9f9b5c9a-27ff-40eb-8023-9bc43f4d8d9e")]
        public string maxCarHeightConstraintIndicator
        {
            get { return _maxCarHeightConstraintIndicator; }
            set { _maxCarHeightConstraintIndicator = value; }
        }

        string _maxCarHeight;

        /// <summary>
        /// Gets or sets the value of variable maxCarHeight.
        /// </summary>
        [TestVariable("94ad1725-094f-4c88-a907-6b02447d1990")]
        public string maxCarHeight
        {
            get { return _maxCarHeight; }
            set { _maxCarHeight = value; }
        }

        string _maxCarHeightTo;

        /// <summary>
        /// Gets or sets the value of variable maxCarHeightTo.
        /// </summary>
        [TestVariable("8e240547-196f-4d92-8b5a-f3a690f478c5")]
        public string maxCarHeightTo
        {
            get { return _maxCarHeightTo; }
            set { _maxCarHeightTo = value; }
        }

        string _maxCarHeightToPassCount;

        /// <summary>
        /// Gets or sets the value of variable maxCarHeightToPassCount.
        /// </summary>
        [TestVariable("97a61022-d16d-44c3-9474-3faeb4992a3e")]
        public string maxCarHeightToPassCount
        {
            get { return _maxCarHeightToPassCount; }
            set { _maxCarHeightToPassCount = value; }
        }

        string _maxCarWidthConstrainIndicator;

        /// <summary>
        /// Gets or sets the value of variable maxCarWidthConstrainIndicator.
        /// </summary>
        [TestVariable("0c4c5efa-155c-4e45-9773-2e6a6cac8c54")]
        public string maxCarWidthConstrainIndicator
        {
            get { return _maxCarWidthConstrainIndicator; }
            set { _maxCarWidthConstrainIndicator = value; }
        }

        string _maxCarWidth;

        /// <summary>
        /// Gets or sets the value of variable maxCarWidth.
        /// </summary>
        [TestVariable("071e566f-68cb-4e5f-a7b4-0227b3f9024c")]
        public string maxCarWidth
        {
            get { return _maxCarWidth; }
            set { _maxCarWidth = value; }
        }

        string _maxCarWidthTo;

        /// <summary>
        /// Gets or sets the value of variable maxCarWidthTo.
        /// </summary>
        [TestVariable("9137b497-93d8-4b77-9ddc-5d96a221d41f")]
        public string maxCarWidthTo
        {
            get { return _maxCarWidthTo; }
            set { _maxCarWidthTo = value; }
        }

        string _maxCarWidthToPassCount;

        /// <summary>
        /// Gets or sets the value of variable maxCarWidthToPassCount.
        /// </summary>
        [TestVariable("dd305674-1e1d-41a3-91bf-3e54a229ab95")]
        public string maxCarWidthToPassCount
        {
            get { return _maxCarWidthToPassCount; }
            set { _maxCarWidthToPassCount = value; }
        }

        string _hazmatTrainConstrainIndicator;

        /// <summary>
        /// Gets or sets the value of variable hazmatTrainConstrainIndicator.
        /// </summary>
        [TestVariable("e0ec475c-580a-435e-96ac-ac9dad98f276")]
        public string hazmatTrainConstrainIndicator
        {
            get { return _hazmatTrainConstrainIndicator; }
            set { _hazmatTrainConstrainIndicator = value; }
        }

        string _keyTrainIndicator;

        /// <summary>
        /// Gets or sets the value of variable keyTrainIndicator.
        /// </summary>
        [TestVariable("afffdeb9-2a75-4f74-b4c0-c7980e774837")]
        public string keyTrainIndicator
        {
            get { return _keyTrainIndicator; }
            set { _keyTrainIndicator = value; }
        }

        string _hazmatTrainTo;

        /// <summary>
        /// Gets or sets the value of variable hazmatTrainTo.
        /// </summary>
        [TestVariable("9fecf7fb-6365-4499-a42d-827fe8f54d6a")]
        public string hazmatTrainTo
        {
            get { return _hazmatTrainTo; }
            set { _hazmatTrainTo = value; }
        }

        string _hazmatTrainToPassCount;

        /// <summary>
        /// Gets or sets the value of variable hazmatTrainToPassCount.
        /// </summary>
        [TestVariable("cf7502fc-c68a-4020-b9e1-a147d40cdac3")]
        public string hazmatTrainToPassCount
        {
            get { return _hazmatTrainToPassCount; }
            set { _hazmatTrainToPassCount = value; }
        }

        string _pickupsetOutRecords;

        /// <summary>
        /// Gets or sets the value of variable pickupsetOutRecords.
        /// </summary>
        [TestVariable("9e7201c3-819a-474b-b5ef-f655a9420faf")]
        public string pickupsetOutRecords
        {
            get { return _pickupsetOutRecords; }
            set { _pickupsetOutRecords = value; }
        }

        string _coalClassificationRecords;

        /// <summary>
        /// Gets or sets the value of variable coalClassificationRecords.
        /// </summary>
        [TestVariable("02a747b2-11fe-43f6-a8d8-ac0d29b42f32")]
        public string coalClassificationRecords
        {
            get { return _coalClassificationRecords; }
            set { _coalClassificationRecords = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("cbd96b81-d4a0-4d20-bb55-f2fe84b8f4f1")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_SendTrainConsistActivity_48Simple(trainSeed, location, passCount, reportingSource, estimatedDwellInterval, maxCarWeightConstrainIndicator, maxCarWeight, maxCarWeightTo, maxCarWeightToPassCount, maxCarHeightConstraintIndicator, maxCarHeight, maxCarHeightTo, maxCarHeightToPassCount, maxCarWidthConstrainIndicator, maxCarWidth, maxCarWidthTo, maxCarWidthToPassCount, hazmatTrainConstrainIndicator, keyTrainIndicator, hazmatTrainTo, hazmatTrainToPassCount, pickupsetOutRecords, coalClassificationRecords, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
