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

namespace PDS_NS.Recording_Modules.Trains
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreatePTCLabTrainConsistSummary_NS recording.
    /// </summary>
    [TestModule("e683d23e-ea8b-41f3-a90d-cb4fcf48c872", ModuleType.Recording, 1)]
    public partial class CreatePTCLabTrainConsistSummary_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreatePTCLabTrainConsistSummary_NS instance = new CreatePTCLabTrainConsistSummary_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreatePTCLabTrainConsistSummary_NS()
        {
            misOrManual = "";
            trainSeed = "";
            consistSeed = "";
            trainConsist_reportingLocation = "";
            trainConsist_reportingPassCount = "";
            trainConsist_reportingSource = "";
            trainConsist_tihConstraintRecord = "";
            trainConsist_maxPlateSize = "";
            trainConsist_numberOfLoads = "";
            trainConsist_numberOfEmpties = "";
            trainConsist_trailingTonnage = "";
            trainConsist_trainLength = "";
            trainConsist_axles = "";
            trainConsist_operativeBrakes = "";
            trainConsist_totalBrakingForce = "";
            trainConsist_speedClass = "";
            trainConsist_maxCarWeightConstraintRecord = "";
            trainConsist_maxCarHeightConstraintRecord = "";
            trainConsist_maxCarWidthConstraintRecord = "";
            trainConsist_hazmatConstraintRecord = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreatePTCLabTrainConsistSummary_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _misOrManual;

        /// <summary>
        /// Gets or sets the value of variable misOrManual.
        /// </summary>
        [TestVariable("5e3e9677-ab7c-464e-98bf-cb70e6381b66")]
        public string misOrManual
        {
            get { return _misOrManual; }
            set { _misOrManual = value; }
        }

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("7ec2d40d-d38d-4ce2-8aa4-95eba29bbb4b")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _consistSeed;

        /// <summary>
        /// Gets or sets the value of variable consistSeed.
        /// </summary>
        [TestVariable("0e357c50-03ce-4e12-91bb-d2b1da8f0095")]
        public string consistSeed
        {
            get { return _consistSeed; }
            set { _consistSeed = value; }
        }

        string _trainConsist_reportingLocation;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_reportingLocation.
        /// </summary>
        [TestVariable("2557efa7-09b9-48fd-a884-7506ab4b1395")]
        public string trainConsist_reportingLocation
        {
            get { return _trainConsist_reportingLocation; }
            set { _trainConsist_reportingLocation = value; }
        }

        string _trainConsist_reportingPassCount;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_reportingPassCount.
        /// </summary>
        [TestVariable("40bf4c01-c59c-4162-8462-c132bc016c02")]
        public string trainConsist_reportingPassCount
        {
            get { return _trainConsist_reportingPassCount; }
            set { _trainConsist_reportingPassCount = value; }
        }

        string _trainConsist_reportingSource;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_reportingSource.
        /// </summary>
        [TestVariable("4441e86b-a31f-4f3a-88bf-6496fe086b5f")]
        public string trainConsist_reportingSource
        {
            get { return _trainConsist_reportingSource; }
            set { _trainConsist_reportingSource = value; }
        }

        string _trainConsist_tihConstraintRecord;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_tihConstraintRecord.
        /// </summary>
        [TestVariable("c758129a-3b7d-4862-b30d-3bb9153288cb")]
        public string trainConsist_tihConstraintRecord
        {
            get { return _trainConsist_tihConstraintRecord; }
            set { _trainConsist_tihConstraintRecord = value; }
        }

        string _trainConsist_maxPlateSize;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_maxPlateSize.
        /// </summary>
        [TestVariable("448a3f27-c750-4f9b-a570-dbf2d8594dd1")]
        public string trainConsist_maxPlateSize
        {
            get { return _trainConsist_maxPlateSize; }
            set { _trainConsist_maxPlateSize = value; }
        }

        string _trainConsist_numberOfLoads;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_numberOfLoads.
        /// </summary>
        [TestVariable("8d826042-ee62-42bb-935f-35762c24cb23")]
        public string trainConsist_numberOfLoads
        {
            get { return _trainConsist_numberOfLoads; }
            set { _trainConsist_numberOfLoads = value; }
        }

        string _trainConsist_numberOfEmpties;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_numberOfEmpties.
        /// </summary>
        [TestVariable("c9fac109-8f22-4a72-985f-d503281f9704")]
        public string trainConsist_numberOfEmpties
        {
            get { return _trainConsist_numberOfEmpties; }
            set { _trainConsist_numberOfEmpties = value; }
        }

        string _trainConsist_trailingTonnage;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_trailingTonnage.
        /// </summary>
        [TestVariable("eefb7a3b-2fa7-47ce-a242-bb67d3235067")]
        public string trainConsist_trailingTonnage
        {
            get { return _trainConsist_trailingTonnage; }
            set { _trainConsist_trailingTonnage = value; }
        }

        string _trainConsist_trainLength;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_trainLength.
        /// </summary>
        [TestVariable("dd2c058b-bca2-429f-ace2-c529dd44b9ca")]
        public string trainConsist_trainLength
        {
            get { return _trainConsist_trainLength; }
            set { _trainConsist_trainLength = value; }
        }

        string _trainConsist_axles;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_axles.
        /// </summary>
        [TestVariable("f6060a46-61be-4381-b9a3-2f08a3d24766")]
        public string trainConsist_axles
        {
            get { return _trainConsist_axles; }
            set { _trainConsist_axles = value; }
        }

        string _trainConsist_operativeBrakes;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_operativeBrakes.
        /// </summary>
        [TestVariable("8567fa6f-306e-4bce-8a1e-80c4ebd4ea35")]
        public string trainConsist_operativeBrakes
        {
            get { return _trainConsist_operativeBrakes; }
            set { _trainConsist_operativeBrakes = value; }
        }

        string _trainConsist_totalBrakingForce;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_totalBrakingForce.
        /// </summary>
        [TestVariable("958f03ea-827d-416d-b51f-20e28be55ea6")]
        public string trainConsist_totalBrakingForce
        {
            get { return _trainConsist_totalBrakingForce; }
            set { _trainConsist_totalBrakingForce = value; }
        }

        string _trainConsist_speedClass;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_speedClass.
        /// </summary>
        [TestVariable("22b3445a-25f9-45ac-9a27-15c3df0e0db8")]
        public string trainConsist_speedClass
        {
            get { return _trainConsist_speedClass; }
            set { _trainConsist_speedClass = value; }
        }

        string _trainConsist_maxCarWeightConstraintRecord;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_maxCarWeightConstraintRecord.
        /// </summary>
        [TestVariable("8f8bc40b-4de3-477e-a0ba-0a56fade6f4f")]
        public string trainConsist_maxCarWeightConstraintRecord
        {
            get { return _trainConsist_maxCarWeightConstraintRecord; }
            set { _trainConsist_maxCarWeightConstraintRecord = value; }
        }

        string _trainConsist_maxCarHeightConstraintRecord;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_maxCarHeightConstraintRecord.
        /// </summary>
        [TestVariable("0f95fd22-f67b-4bb5-afba-12fd871f22c8")]
        public string trainConsist_maxCarHeightConstraintRecord
        {
            get { return _trainConsist_maxCarHeightConstraintRecord; }
            set { _trainConsist_maxCarHeightConstraintRecord = value; }
        }

        string _trainConsist_maxCarWidthConstraintRecord;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_maxCarWidthConstraintRecord.
        /// </summary>
        [TestVariable("2282b477-d608-4140-9b6e-edde885dd7fb")]
        public string trainConsist_maxCarWidthConstraintRecord
        {
            get { return _trainConsist_maxCarWidthConstraintRecord; }
            set { _trainConsist_maxCarWidthConstraintRecord = value; }
        }

        string _trainConsist_hazmatConstraintRecord;

        /// <summary>
        /// Gets or sets the value of variable trainConsist_hazmatConstraintRecord.
        /// </summary>
        [TestVariable("3ed5dd2f-929b-47ac-8737-dfdc397ba4ef")]
        public string trainConsist_hazmatConstraintRecord
        {
            get { return _trainConsist_hazmatConstraintRecord; }
            set { _trainConsist_hazmatConstraintRecord = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("1e64f8ab-ad2f-48c6-96fd-4ec35e46d140")]
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

            UserCodeCollections.NS_LabTrains.CreatePTCLabTrainConsistSummary_Trainsheet_MIS(misOrManual, trainSeed, consistSeed, trainConsist_reportingLocation, trainConsist_reportingPassCount, trainConsist_reportingSource, trainConsist_tihConstraintRecord, trainConsist_maxPlateSize, trainConsist_numberOfLoads, trainConsist_numberOfEmpties, trainConsist_trailingTonnage, trainConsist_trainLength, trainConsist_axles, trainConsist_operativeBrakes, trainConsist_totalBrakingForce, trainConsist_speedClass, trainConsist_maxCarWeightConstraintRecord, trainConsist_maxCarHeightConstraintRecord, trainConsist_maxCarWidthConstraintRecord, trainConsist_hazmatConstraintRecord, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}