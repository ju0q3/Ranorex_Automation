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

namespace PDS_NS.Recording_Modules.Bulletins.Input
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The InputFuelConservationDirectiveBulletin recording.
    /// </summary>
    [TestModule("44bc1d33-6c2a-4505-9fff-d49b8cf99179", ModuleType.Recording, 1)]
    public partial class InputFuelConservationDirectiveBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputFuelConservationDirectiveBulletin instance = new InputFuelConservationDirectiveBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputFuelConservationDirectiveBulletin()
        {
            bulletinSeed = "";
            district = "";
            districtInput = "";
            milepost1 = "";
            milepost2 = "";
            maxTonnage = "";
            EW = "";
            H5 = "";
            coalGrain = "";
            freight = "";
            imml = "";
            ip = "";
            maximumPoweredAxles = "";
            eachDirection = "";
            trailingTonnage = "";
            currentMaximumPower = "";
            r4 = "";
            r5 = "";
            ip1 = "";
            ip2 = "";
            effectiveTimeDifference = "";
            expectedFeedback = "";
            pressComplete = "False";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputFuelConservationDirectiveBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("4323687c-ee0d-42c3-8559-19417392c0c1")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("ded3f37c-6bce-4cdb-b405-cc4a4457a75e")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _districtInput;

        /// <summary>
        /// Gets or sets the value of variable districtInput.
        /// </summary>
        [TestVariable("d9c4c197-f4c4-4bd7-b30f-5a6646ef48c4")]
        public string districtInput
        {
            get { return _districtInput; }
            set { _districtInput = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("ed5bdd04-8d41-4585-8852-1b3509eb9ce0")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("7cb3d3f2-87a7-49d1-b47d-9741a8d8d07a")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _maxTonnage;

        /// <summary>
        /// Gets or sets the value of variable maxTonnage.
        /// </summary>
        [TestVariable("b7bdce15-1b9b-4a16-b399-8435390e1bbe")]
        public string maxTonnage
        {
            get { return _maxTonnage; }
            set { _maxTonnage = value; }
        }

        string _EW;

        /// <summary>
        /// Gets or sets the value of variable EW.
        /// </summary>
        [TestVariable("6c5a780f-f3c1-4edd-bbcd-ca02c75e6135")]
        public string EW
        {
            get { return _EW; }
            set { _EW = value; }
        }

        string _H5;

        /// <summary>
        /// Gets or sets the value of variable H5.
        /// </summary>
        [TestVariable("65830448-055d-478c-8f53-2d488d7a9722")]
        public string H5
        {
            get { return _H5; }
            set { _H5 = value; }
        }

        string _coalGrain;

        /// <summary>
        /// Gets or sets the value of variable coalGrain.
        /// </summary>
        [TestVariable("6fcc0898-681e-41a0-aaf3-d1b0f56ec834")]
        public string coalGrain
        {
            get { return _coalGrain; }
            set { _coalGrain = value; }
        }

        string _freight;

        /// <summary>
        /// Gets or sets the value of variable freight.
        /// </summary>
        [TestVariable("c76e52cd-4ece-40bf-bbb4-e3be96d0744e")]
        public string freight
        {
            get { return _freight; }
            set { _freight = value; }
        }

        string _imml;

        /// <summary>
        /// Gets or sets the value of variable imml.
        /// </summary>
        [TestVariable("c57a277a-df71-4238-9510-1f5690d20e68")]
        public string imml
        {
            get { return _imml; }
            set { _imml = value; }
        }

        string _ip;

        /// <summary>
        /// Gets or sets the value of variable ip.
        /// </summary>
        [TestVariable("a4478173-75fd-4d5c-a25c-1959d78b56a0")]
        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        string _maximumPoweredAxles;

        /// <summary>
        /// Gets or sets the value of variable maximumPoweredAxles.
        /// </summary>
        [TestVariable("453146c7-7a2d-4d2d-9fde-d3e88718c83e")]
        public string maximumPoweredAxles
        {
            get { return _maximumPoweredAxles; }
            set { _maximumPoweredAxles = value; }
        }

        string _eachDirection;

        /// <summary>
        /// Gets or sets the value of variable eachDirection.
        /// </summary>
        [TestVariable("0ec0c19c-3869-4c59-a39d-bd98087214a5")]
        public string eachDirection
        {
            get { return _eachDirection; }
            set { _eachDirection = value; }
        }

        string _trailingTonnage;

        /// <summary>
        /// Gets or sets the value of variable trailingTonnage.
        /// </summary>
        [TestVariable("af4eb715-005d-4016-ae8f-1a6eeba90894")]
        public string trailingTonnage
        {
            get { return _trailingTonnage; }
            set { _trailingTonnage = value; }
        }

        string _currentMaximumPower;

        /// <summary>
        /// Gets or sets the value of variable currentMaximumPower.
        /// </summary>
        [TestVariable("d1d5b8be-6b17-4d5f-81bb-95dfd89294a4")]
        public string currentMaximumPower
        {
            get { return _currentMaximumPower; }
            set { _currentMaximumPower = value; }
        }

        string _r4;

        /// <summary>
        /// Gets or sets the value of variable r4.
        /// </summary>
        [TestVariable("1b0eeaf2-f219-473a-b6ae-b112b2ba0afc")]
        public string r4
        {
            get { return _r4; }
            set { _r4 = value; }
        }

        string _r5;

        /// <summary>
        /// Gets or sets the value of variable r5.
        /// </summary>
        [TestVariable("868da5f8-2b67-4d35-a390-f8a63e7b3662")]
        public string r5
        {
            get { return _r5; }
            set { _r5 = value; }
        }

        string _ip1;

        /// <summary>
        /// Gets or sets the value of variable ip1.
        /// </summary>
        [TestVariable("75f25f2b-7b79-44bb-b077-626faebabb90")]
        public string ip1
        {
            get { return _ip1; }
            set { _ip1 = value; }
        }

        string _ip2;

        /// <summary>
        /// Gets or sets the value of variable ip2.
        /// </summary>
        [TestVariable("098fd156-aaa7-4e07-b769-0911d43f8edb")]
        public string ip2
        {
            get { return _ip2; }
            set { _ip2 = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("5ddb2c0b-a7f2-46bc-b5bc-3f6a3e59e3c2")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("a302914b-b96a-4f95-b44c-51674759504f")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("29ac0f9e-1057-4a1d-ba0e-c7f90ab2d4c1")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("a04d6a2d-cbc1-428c-801f-134660dcf68c")]
        public string closeBulletinRelayForm
        {
            get { return _closeBulletinRelayForm; }
            set { _closeBulletinRelayForm = value; }
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

            UserCodeCollections.NS_InputBulletins.NS_InputFuelConservationDirectiveBulletin(bulletinSeed, district, districtInput, milepost1, milepost2, maxTonnage, EW, H5, coalGrain, freight, imml, ip, maximumPoweredAxles, eachDirection, trailingTonnage, currentMaximumPower, r4, r5, ip1, ip2, effectiveTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
