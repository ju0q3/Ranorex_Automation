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
    ///The InputFuelConservationDirectiveNSBulletin recording.
    /// </summary>
    [TestModule("8172ba56-7f98-4abc-a04e-c6694420acf5", ModuleType.Recording, 1)]
    public partial class InputFuelConservationDirectiveNSBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputFuelConservationDirectiveNSBulletin instance = new InputFuelConservationDirectiveNSBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputFuelConservationDirectiveNSBulletin()
        {
            bulletinSeed = "";
            district = "";
            districtInput = "";
            milepost1 = "";
            milepost2 = "";
            maxTonnage = "";
            NS = "";
            H5 = "";
            coalGrain = "";
            freight = "";
            imml = "";
            ip = "";
            maximumPoweredAxles = "";
            eachDirection = "";
            trailingTonnage = "";
            currentMaximumPower = "";
            r5 = "";
            accurateLoco = "";
            ipTrains = "";
            effectiveTimeDifference = "";
            expectedFeedback = "";
            pressComplete = "False";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputFuelConservationDirectiveNSBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("38f3d3ce-d50d-4682-be4a-c2c2d6004c66")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("9c97b424-63d0-425e-8286-ba793873c38d")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _districtInput;

        /// <summary>
        /// Gets or sets the value of variable districtInput.
        /// </summary>
        [TestVariable("bced2d14-69ca-4c16-a58a-1fd9f644b295")]
        public string districtInput
        {
            get { return _districtInput; }
            set { _districtInput = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("b3d20716-c852-4c0a-9a4a-1b879b1e7818")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("51716ec8-7da4-4b6a-b853-f8963c49a2f5")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _maxTonnage;

        /// <summary>
        /// Gets or sets the value of variable maxTonnage.
        /// </summary>
        [TestVariable("8aa2daa0-c736-4158-afe8-d9453b7ee955")]
        public string maxTonnage
        {
            get { return _maxTonnage; }
            set { _maxTonnage = value; }
        }

        string _NS;

        /// <summary>
        /// Gets or sets the value of variable NS.
        /// </summary>
        [TestVariable("0a56b0bd-d697-4469-98e6-e226fda6edcc")]
        public string NS
        {
            get { return _NS; }
            set { _NS = value; }
        }

        string _H5;

        /// <summary>
        /// Gets or sets the value of variable H5.
        /// </summary>
        [TestVariable("467ccdaf-675d-4d02-8114-d8f0bf729ee6")]
        public string H5
        {
            get { return _H5; }
            set { _H5 = value; }
        }

        string _coalGrain;

        /// <summary>
        /// Gets or sets the value of variable coalGrain.
        /// </summary>
        [TestVariable("2aaded4c-b169-42f5-8e63-dc05d191bca8")]
        public string coalGrain
        {
            get { return _coalGrain; }
            set { _coalGrain = value; }
        }

        string _freight;

        /// <summary>
        /// Gets or sets the value of variable freight.
        /// </summary>
        [TestVariable("4c9e2000-5b95-4b01-ac75-41278b22a717")]
        public string freight
        {
            get { return _freight; }
            set { _freight = value; }
        }

        string _imml;

        /// <summary>
        /// Gets or sets the value of variable imml.
        /// </summary>
        [TestVariable("9ce75694-ad17-4cd3-9b81-18e38208a724")]
        public string imml
        {
            get { return _imml; }
            set { _imml = value; }
        }

        string _ip;

        /// <summary>
        /// Gets or sets the value of variable ip.
        /// </summary>
        [TestVariable("dc86b196-6414-406d-ad06-f34a1543b7a1")]
        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        string _maximumPoweredAxles;

        /// <summary>
        /// Gets or sets the value of variable maximumPoweredAxles.
        /// </summary>
        [TestVariable("72dafd53-21b0-4d78-80bc-316dcd659d4e")]
        public string maximumPoweredAxles
        {
            get { return _maximumPoweredAxles; }
            set { _maximumPoweredAxles = value; }
        }

        string _eachDirection;

        /// <summary>
        /// Gets or sets the value of variable eachDirection.
        /// </summary>
        [TestVariable("184054aa-dca1-402e-b2fe-5943e4255b68")]
        public string eachDirection
        {
            get { return _eachDirection; }
            set { _eachDirection = value; }
        }

        string _trailingTonnage;

        /// <summary>
        /// Gets or sets the value of variable trailingTonnage.
        /// </summary>
        [TestVariable("9446abba-c960-4a80-b61d-3bb5c8cff1ca")]
        public string trailingTonnage
        {
            get { return _trailingTonnage; }
            set { _trailingTonnage = value; }
        }

        string _currentMaximumPower;

        /// <summary>
        /// Gets or sets the value of variable currentMaximumPower.
        /// </summary>
        [TestVariable("f25e7e2a-2d24-4bfc-99f5-53e0eee3da51")]
        public string currentMaximumPower
        {
            get { return _currentMaximumPower; }
            set { _currentMaximumPower = value; }
        }

        string _r5;

        /// <summary>
        /// Gets or sets the value of variable r5.
        /// </summary>
        [TestVariable("6d2fc0cd-fbde-46b6-9155-b7840c08dede")]
        public string r5
        {
            get { return _r5; }
            set { _r5 = value; }
        }

        string _accurateLoco;

        /// <summary>
        /// Gets or sets the value of variable accurateLoco.
        /// </summary>
        [TestVariable("95b52bca-b39c-45be-bcc6-44c6ad52420b")]
        public string accurateLoco
        {
            get { return _accurateLoco; }
            set { _accurateLoco = value; }
        }

        string _ipTrains;

        /// <summary>
        /// Gets or sets the value of variable ipTrains.
        /// </summary>
        [TestVariable("84ed683b-d0ba-4494-a364-79b2420b83a1")]
        public string ipTrains
        {
            get { return _ipTrains; }
            set { _ipTrains = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("8cacf2cf-bd91-4bad-a69f-f879390479c6")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("67e24a10-de4e-4ee3-b43f-8da57b42bd6c")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("2f99f7da-51d2-47c3-92a3-887b49f45c42")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("caa2785c-dd4a-403c-ba66-c29a769a826f")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputFuelConservationDirectiveNSBulletin(bulletinSeed, district, districtInput, milepost1, milepost2, maxTonnage, NS, H5, coalGrain, freight, imml, ip, maximumPoweredAxles, eachDirection, trailingTonnage, currentMaximumPower, r5, accurateLoco, ipTrains, effectiveTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
