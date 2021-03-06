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
    ///The InputFuelConservationDirectiveEWBulletin recording.
    /// </summary>
    [TestModule("755182fc-6030-48b8-95a7-f28b1300f2f4", ModuleType.Recording, 1)]
    public partial class InputFuelConservationDirectiveEWBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputFuelConservationDirectiveEWBulletin instance = new InputFuelConservationDirectiveEWBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputFuelConservationDirectiveEWBulletin()
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
        public static InputFuelConservationDirectiveEWBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("4b304c4d-d72a-4877-b012-975b0ca04bf7")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("ac981407-e48c-4c1b-bbcd-733e5ee57d5d")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _districtInput;

        /// <summary>
        /// Gets or sets the value of variable districtInput.
        /// </summary>
        [TestVariable("7fdbdab3-8265-4a6d-ba00-647ac9ac20db")]
        public string districtInput
        {
            get { return _districtInput; }
            set { _districtInput = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("16b4eaa1-431a-4ab6-b875-093985db19c3")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("a7e6b453-862d-4f7a-9f3e-cc7ba4bb1e2b")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _maxTonnage;

        /// <summary>
        /// Gets or sets the value of variable maxTonnage.
        /// </summary>
        [TestVariable("aafef83a-5f8b-488a-afe7-ec3974e5312b")]
        public string maxTonnage
        {
            get { return _maxTonnage; }
            set { _maxTonnage = value; }
        }

        string _EW;

        /// <summary>
        /// Gets or sets the value of variable EW.
        /// </summary>
        [TestVariable("b06e8bc1-a340-4a1e-aeb5-f228036da77e")]
        public string EW
        {
            get { return _EW; }
            set { _EW = value; }
        }

        string _H5;

        /// <summary>
        /// Gets or sets the value of variable H5.
        /// </summary>
        [TestVariable("1245b86c-385f-4a3a-956a-61529bd9c8be")]
        public string H5
        {
            get { return _H5; }
            set { _H5 = value; }
        }

        string _coalGrain;

        /// <summary>
        /// Gets or sets the value of variable coalGrain.
        /// </summary>
        [TestVariable("741718c5-28ff-4e6e-8f51-7a4b704716b7")]
        public string coalGrain
        {
            get { return _coalGrain; }
            set { _coalGrain = value; }
        }

        string _freight;

        /// <summary>
        /// Gets or sets the value of variable freight.
        /// </summary>
        [TestVariable("fd7dd3bb-5b55-4bd0-9b5a-654e9fc65ac2")]
        public string freight
        {
            get { return _freight; }
            set { _freight = value; }
        }

        string _imml;

        /// <summary>
        /// Gets or sets the value of variable imml.
        /// </summary>
        [TestVariable("573056f6-74df-43e9-a47f-8dabf94df0bf")]
        public string imml
        {
            get { return _imml; }
            set { _imml = value; }
        }

        string _ip;

        /// <summary>
        /// Gets or sets the value of variable ip.
        /// </summary>
        [TestVariable("54096ae0-847a-43d3-a12e-e067c67c6747")]
        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        string _maximumPoweredAxles;

        /// <summary>
        /// Gets or sets the value of variable maximumPoweredAxles.
        /// </summary>
        [TestVariable("99af088b-9111-4790-bedb-634713e4d947")]
        public string maximumPoweredAxles
        {
            get { return _maximumPoweredAxles; }
            set { _maximumPoweredAxles = value; }
        }

        string _eachDirection;

        /// <summary>
        /// Gets or sets the value of variable eachDirection.
        /// </summary>
        [TestVariable("b85a3b0a-c167-4119-995b-21b19356be04")]
        public string eachDirection
        {
            get { return _eachDirection; }
            set { _eachDirection = value; }
        }

        string _trailingTonnage;

        /// <summary>
        /// Gets or sets the value of variable trailingTonnage.
        /// </summary>
        [TestVariable("daf9b1ec-d428-4183-a600-c2a2d43b6630")]
        public string trailingTonnage
        {
            get { return _trailingTonnage; }
            set { _trailingTonnage = value; }
        }

        string _currentMaximumPower;

        /// <summary>
        /// Gets or sets the value of variable currentMaximumPower.
        /// </summary>
        [TestVariable("c8f05542-34f2-467d-8d99-23fb8694124c")]
        public string currentMaximumPower
        {
            get { return _currentMaximumPower; }
            set { _currentMaximumPower = value; }
        }

        string _r5;

        /// <summary>
        /// Gets or sets the value of variable r5.
        /// </summary>
        [TestVariable("f1547567-fe91-4977-8943-51906ca5365d")]
        public string r5
        {
            get { return _r5; }
            set { _r5 = value; }
        }

        string _accurateLoco;

        /// <summary>
        /// Gets or sets the value of variable accurateLoco.
        /// </summary>
        [TestVariable("cdabccb7-b160-4a57-80fd-018947d08c75")]
        public string accurateLoco
        {
            get { return _accurateLoco; }
            set { _accurateLoco = value; }
        }

        string _ipTrains;

        /// <summary>
        /// Gets or sets the value of variable ipTrains.
        /// </summary>
        [TestVariable("1a33e79a-7205-40ac-b4d1-d5517e28733b")]
        public string ipTrains
        {
            get { return _ipTrains; }
            set { _ipTrains = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("e0258d32-69ab-4cb2-8c5a-114368c1c58a")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("16e42a44-379c-4fde-a438-03ba76103003")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("9963a28b-3e11-414b-9995-ce45995f94ac")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("abef5aa4-b56c-4d1b-a921-fcf016d4816b")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputFuelConservationDirectiveEWBulletin(bulletinSeed, district, districtInput, milepost1, milepost2, maxTonnage, EW, H5, coalGrain, freight, imml, ip, maximumPoweredAxles, eachDirection, trailingTonnage, currentMaximumPower, r5, accurateLoco, ipTrains, effectiveTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
