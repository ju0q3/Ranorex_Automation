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
    ///The CreateFullTrainMIS_NS recording.
    /// </summary>
    [TestModule("208aca81-a903-4cbe-840a-db4f5d2eb8ce", ModuleType.Recording, 1)]
    public partial class CreateFullTrainMIS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateFullTrainMIS_NS instance = new CreateFullTrainMIS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateFullTrainMIS_NS()
        {
            scac = "";
            section = "";
            trainSeed = "";
            reportType = "";
            trainCategory = "";
            trainGroup = "";
            trainOrigin = "";
            trainDestination = "";
            stations = "";
            passCount = "";
            time = "";
            timeZone = "";
            timeType = "";
            reportingSource = "";
            numberOfLoads = "";
            numberOfEmpties = "";
            trailingTonnage = "";
            trainLength = "";
            axleCount = "";
            operativeBrakes = "";
            totalBrakingForce = "";
            maxCarWeights = "";
            maxCarHeights = "";
            maxCarWidths = "";
            hazmatConstraints = "";
            crewID = "";
            crewLineSegment = "";
            sequenceNumber = "";
            crewMemberRecords = "";
            division = "";
            helperCrewPoolID = "";
            defaultDataApplied = "";
            purpose = "";
            engines = "";
            carData = "";
            equipmentCode = "";
            initial = "";
            number = "";
            workingStatus = "";
            reportingSourceEngine = "";
            consistSeed = "";
            engineSeed = "";
            speedClass = "Freight";
            maxPlateSize = "D";
            TIHConstraints = "";
            originDay = "";
            crewSeed = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateFullTrainMIS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _scac;

        /// <summary>
        /// Gets or sets the value of variable scac.
        /// </summary>
        [TestVariable("e64e4bdf-ee8d-4418-b8a3-2fe93bb9bf81")]
        public string scac
        {
            get { return _scac; }
            set { _scac = value; }
        }

        string _section;

        /// <summary>
        /// Gets or sets the value of variable section.
        /// </summary>
        [TestVariable("45e361fd-1db2-4aef-a4fd-c0adce21a291")]
        public string section
        {
            get { return _section; }
            set { _section = value; }
        }

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("d1bea342-3f66-48d5-9758-51d5a2e92c74")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _reportType;

        /// <summary>
        /// Gets or sets the value of variable reportType.
        /// </summary>
        [TestVariable("ae3f2fbf-e8ef-413e-8d05-d13e4eca55bf")]
        public string reportType
        {
            get { return _reportType; }
            set { _reportType = value; }
        }

        string _trainCategory;

        /// <summary>
        /// Gets or sets the value of variable trainCategory.
        /// </summary>
        [TestVariable("c622fa03-6cd3-4eb4-92f7-7fb3b7b73da9")]
        public string trainCategory
        {
            get { return _trainCategory; }
            set { _trainCategory = value; }
        }

        string _trainGroup;

        /// <summary>
        /// Gets or sets the value of variable trainGroup.
        /// </summary>
        [TestVariable("eedab17b-e43b-46f1-be51-4431c1d691e5")]
        public string trainGroup
        {
            get { return _trainGroup; }
            set { _trainGroup = value; }
        }

        string _trainOrigin;

        /// <summary>
        /// Gets or sets the value of variable trainOrigin.
        /// </summary>
        [TestVariable("e0421d85-3a9e-4f26-a648-956667ad72b7")]
        public string trainOrigin
        {
            get { return _trainOrigin; }
            set { _trainOrigin = value; }
        }

        string _trainDestination;

        /// <summary>
        /// Gets or sets the value of variable trainDestination.
        /// </summary>
        [TestVariable("9a7b2031-20b0-407b-8921-59a71cddde46")]
        public string trainDestination
        {
            get { return _trainDestination; }
            set { _trainDestination = value; }
        }

        string _stations;

        /// <summary>
        /// Gets or sets the value of variable stations.
        /// </summary>
        [TestVariable("72ed1ebe-ec80-408a-91ef-7b5e3f2d9689")]
        public string stations
        {
            get { return _stations; }
            set { _stations = value; }
        }

        string _passCount;

        /// <summary>
        /// Gets or sets the value of variable passCount.
        /// </summary>
        [TestVariable("90ee771b-6a09-4abf-9945-874dbb8e134f")]
        public string passCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        string _time;

        /// <summary>
        /// Gets or sets the value of variable time.
        /// </summary>
        [TestVariable("d7317034-06ca-4658-9b46-e66aec8c0632")]
        public string time
        {
            get { return _time; }
            set { _time = value; }
        }

        string _timeZone;

        /// <summary>
        /// Gets or sets the value of variable timeZone.
        /// </summary>
        [TestVariable("38fd0570-a162-4000-a41c-b0015710d06b")]
        public string timeZone
        {
            get { return _timeZone; }
            set { _timeZone = value; }
        }

        string _timeType;

        /// <summary>
        /// Gets or sets the value of variable timeType.
        /// </summary>
        [TestVariable("ef10c809-d94e-4e11-9d32-0d3003540a34")]
        public string timeType
        {
            get { return _timeType; }
            set { _timeType = value; }
        }

        string _reportingSource;

        /// <summary>
        /// Gets or sets the value of variable reportingSource.
        /// </summary>
        [TestVariable("e3690907-fe30-40ae-9369-68f19ad8a23f")]
        public string reportingSource
        {
            get { return _reportingSource; }
            set { _reportingSource = value; }
        }

        string _numberOfLoads;

        /// <summary>
        /// Gets or sets the value of variable numberOfLoads.
        /// </summary>
        [TestVariable("2ea241db-767a-4753-afae-7ebe9b6d37de")]
        public string numberOfLoads
        {
            get { return _numberOfLoads; }
            set { _numberOfLoads = value; }
        }

        string _numberOfEmpties;

        /// <summary>
        /// Gets or sets the value of variable numberOfEmpties.
        /// </summary>
        [TestVariable("c037d563-3b0d-4a08-b2b3-c646e0ff0401")]
        public string numberOfEmpties
        {
            get { return _numberOfEmpties; }
            set { _numberOfEmpties = value; }
        }

        string _trailingTonnage;

        /// <summary>
        /// Gets or sets the value of variable trailingTonnage.
        /// </summary>
        [TestVariable("d25c34e6-3954-41d1-990f-75c8423168a1")]
        public string trailingTonnage
        {
            get { return _trailingTonnage; }
            set { _trailingTonnage = value; }
        }

        string _trainLength;

        /// <summary>
        /// Gets or sets the value of variable trainLength.
        /// </summary>
        [TestVariable("fe11700a-cccb-4dbf-a56b-48526f656455")]
        public string trainLength
        {
            get { return _trainLength; }
            set { _trainLength = value; }
        }

        string _axleCount;

        /// <summary>
        /// Gets or sets the value of variable axleCount.
        /// </summary>
        [TestVariable("310b49c2-fb8f-42fa-9e53-20ee752ece56")]
        public string axleCount
        {
            get { return _axleCount; }
            set { _axleCount = value; }
        }

        string _operativeBrakes;

        /// <summary>
        /// Gets or sets the value of variable operativeBrakes.
        /// </summary>
        [TestVariable("fdf7b5de-f3d4-46d2-85c8-261b2ca5674f")]
        public string operativeBrakes
        {
            get { return _operativeBrakes; }
            set { _operativeBrakes = value; }
        }

        string _totalBrakingForce;

        /// <summary>
        /// Gets or sets the value of variable totalBrakingForce.
        /// </summary>
        [TestVariable("adb8d9d0-3a20-4553-8cb1-3233ab2dfd5d")]
        public string totalBrakingForce
        {
            get { return _totalBrakingForce; }
            set { _totalBrakingForce = value; }
        }

        string _maxCarWeights;

        /// <summary>
        /// Gets or sets the value of variable maxCarWeights.
        /// </summary>
        [TestVariable("1120de85-c786-4bd2-914b-0c88a11176a9")]
        public string maxCarWeights
        {
            get { return _maxCarWeights; }
            set { _maxCarWeights = value; }
        }

        string _maxCarHeights;

        /// <summary>
        /// Gets or sets the value of variable maxCarHeights.
        /// </summary>
        [TestVariable("106d15b5-e38c-4327-837e-92cf5651f62a")]
        public string maxCarHeights
        {
            get { return _maxCarHeights; }
            set { _maxCarHeights = value; }
        }

        string _maxCarWidths;

        /// <summary>
        /// Gets or sets the value of variable maxCarWidths.
        /// </summary>
        [TestVariable("a6962440-5e41-4d20-b487-95c5fe66cf62")]
        public string maxCarWidths
        {
            get { return _maxCarWidths; }
            set { _maxCarWidths = value; }
        }

        string _hazmatConstraints;

        /// <summary>
        /// Gets or sets the value of variable hazmatConstraints.
        /// </summary>
        [TestVariable("dc31bd5c-8a44-46fc-a4fa-46f54205255a")]
        public string hazmatConstraints
        {
            get { return _hazmatConstraints; }
            set { _hazmatConstraints = value; }
        }

        string _crewID;

        /// <summary>
        /// Gets or sets the value of variable crewID.
        /// </summary>
        [TestVariable("30f45f7d-d4a6-46ff-9c6d-f06c2196145b")]
        public string crewID
        {
            get { return _crewID; }
            set { _crewID = value; }
        }

        string _crewLineSegment;

        /// <summary>
        /// Gets or sets the value of variable crewLineSegment.
        /// </summary>
        [TestVariable("2c7906c1-4447-418f-933f-1810b885c9d0")]
        public string crewLineSegment
        {
            get { return _crewLineSegment; }
            set { _crewLineSegment = value; }
        }

        string _sequenceNumber;

        /// <summary>
        /// Gets or sets the value of variable sequenceNumber.
        /// </summary>
        [TestVariable("4f15d15d-bab9-416a-a118-cb9fd8581ae5")]
        public string sequenceNumber
        {
            get { return _sequenceNumber; }
            set { _sequenceNumber = value; }
        }

        string _crewMemberRecords;

        /// <summary>
        /// Gets or sets the value of variable crewMemberRecords.
        /// </summary>
        [TestVariable("8820aa2f-cf12-41c1-afd4-9960b5da4dca")]
        public string crewMemberRecords
        {
            get { return _crewMemberRecords; }
            set { _crewMemberRecords = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("19eef2db-1d90-4811-938c-3ce603ec58cd")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _helperCrewPoolID;

        /// <summary>
        /// Gets or sets the value of variable helperCrewPoolID.
        /// </summary>
        [TestVariable("261baec1-4042-4ed1-bc35-c8bca3c7f2de")]
        public string helperCrewPoolID
        {
            get { return _helperCrewPoolID; }
            set { _helperCrewPoolID = value; }
        }

        string _defaultDataApplied;

        /// <summary>
        /// Gets or sets the value of variable defaultDataApplied.
        /// </summary>
        [TestVariable("04b72810-e6af-44c6-824b-b1ef1b0f34c9")]
        public string defaultDataApplied
        {
            get { return _defaultDataApplied; }
            set { _defaultDataApplied = value; }
        }

        string _purpose;

        /// <summary>
        /// Gets or sets the value of variable purpose.
        /// </summary>
        [TestVariable("7548e999-514c-4c8a-b93b-d54c1cd367fd")]
        public string purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        string _engines;

        /// <summary>
        /// Gets or sets the value of variable engines.
        /// </summary>
        [TestVariable("abbd198c-507a-4453-bfb8-93ab58e9918b")]
        public string engines
        {
            get { return _engines; }
            set { _engines = value; }
        }

        string _carData;

        /// <summary>
        /// Gets or sets the value of variable carData.
        /// </summary>
        [TestVariable("7543e3bb-6a53-4f3c-9cef-755234077329")]
        public string carData
        {
            get { return _carData; }
            set { _carData = value; }
        }

        string _equipmentCode;

        /// <summary>
        /// Gets or sets the value of variable equipmentCode.
        /// </summary>
        [TestVariable("c7488209-57b0-4179-bba5-47304bc9fdad")]
        public string equipmentCode
        {
            get { return _equipmentCode; }
            set { _equipmentCode = value; }
        }

        string _initial;

        /// <summary>
        /// Gets or sets the value of variable initial.
        /// </summary>
        [TestVariable("79b49e19-9f82-4b03-b5de-090655f1020d")]
        public string initial
        {
            get { return _initial; }
            set { _initial = value; }
        }

        string _number;

        /// <summary>
        /// Gets or sets the value of variable number.
        /// </summary>
        [TestVariable("dbdc69d4-568b-48a0-bfec-c8ec79fd98c6")]
        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        string _workingStatus;

        /// <summary>
        /// Gets or sets the value of variable workingStatus.
        /// </summary>
        [TestVariable("43e3172a-91c4-4481-815d-c16e798e4900")]
        public string workingStatus
        {
            get { return _workingStatus; }
            set { _workingStatus = value; }
        }

        string _reportingSourceEngine;

        /// <summary>
        /// Gets or sets the value of variable reportingSourceEngine.
        /// </summary>
        [TestVariable("d2d0cfeb-fd39-49df-9174-beab5e847657")]
        public string reportingSourceEngine
        {
            get { return _reportingSourceEngine; }
            set { _reportingSourceEngine = value; }
        }

        string _consistSeed;

        /// <summary>
        /// Gets or sets the value of variable consistSeed.
        /// </summary>
        [TestVariable("e5790b91-5be3-4186-97c6-b2dc485b006f")]
        public string consistSeed
        {
            get { return _consistSeed; }
            set { _consistSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("6dca87a3-40bf-4887-bca0-789dbb6eec8e")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _speedClass;

        /// <summary>
        /// Gets or sets the value of variable speedClass.
        /// </summary>
        [TestVariable("8c144054-d305-407f-bffb-d24733b0e10f")]
        public string speedClass
        {
            get { return _speedClass; }
            set { _speedClass = value; }
        }

        string _maxPlateSize;

        /// <summary>
        /// Gets or sets the value of variable maxPlateSize.
        /// </summary>
        [TestVariable("5e950986-8f47-44e8-8995-83e7195a9bd5")]
        public string maxPlateSize
        {
            get { return _maxPlateSize; }
            set { _maxPlateSize = value; }
        }

        string _TIHConstraints;

        /// <summary>
        /// Gets or sets the value of variable TIHConstraints.
        /// </summary>
        [TestVariable("c0f0704d-5f79-4ab0-aa10-7dbe5a6f4f55")]
        public string TIHConstraints
        {
            get { return _TIHConstraints; }
            set { _TIHConstraints = value; }
        }

        string _originDay;

        /// <summary>
        /// Gets or sets the value of variable originDay.
        /// </summary>
        [TestVariable("75a8a895-67e2-4d71-90eb-9ac3667366c8")]
        public string originDay
        {
            get { return _originDay; }
            set { _originDay = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("7e2fc8a9-5de6-4314-ba5f-0d6de29bb2ec")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("f91e5fff-b883-4593-8560-02c339e15493")]
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

            UserCodeCollections.NS_MIS_Messages.NS_SendCreateSchedule_43Simple(trainSeed, scac, section, originDay, reportType, trainCategory, trainGroup, trainOrigin, trainDestination, stations, hostname);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_MIS_Messages.NS_SendTrainSegment_48Simple(trainSeed, trainOrigin, passCount, "0", time, timeZone, timeType, trainOrigin, trainDestination, hostname);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_MIS_Messages.NS_SendTrainConsistSummary_43Simple(trainSeed, consistSeed, trainOrigin, passCount, reportingSource, TIHConstraints, maxPlateSize, numberOfLoads, numberOfEmpties, trailingTonnage, trainLength, axleCount, operativeBrakes, totalBrakingForce, speedClass, maxCarWeights, maxCarHeights, maxCarWidths, hazmatConstraints, hostname);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_MIS_Messages.NS_SendCrewMember_48Simple(trainSeed, crewSeed, crewID, crewLineSegment, sequenceNumber, crewMemberRecords, hostname);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_MIS_Messages.NS_SendEngineConsist_48Simple(trainSeed, engineSeed, division, helperCrewPoolID, reportingSource, trainOrigin, passCount, defaultDataApplied, purpose, engines, hostname);
            Delay.Milliseconds(0);
            
            STE.Code_Utils.SendMISFileCollection_NS.NS_CreateRailCarConsist(scac, section, trainSeed, trainOrigin, passCount, carData);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_MIS_Messages.NS_SendEOTCaboose_48Simple(trainSeed, equipmentCode, trainOrigin, trainDestination, initial, number, workingStatus, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
