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
    ///The InputRightOfWayCondPointBulletin recording.
    /// </summary>
    [TestModule("ec0e18d7-bcb6-4b4e-8377-a70941fd00bd", ModuleType.Recording, 1)]
    public partial class InputRightOfWayCondPointBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputRightOfWayCondPointBulletin instance = new InputRightOfWayCondPointBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputRightOfWayCondPointBulletin()
        {
            bulletinSeed = "";
            district = "";
            milepost = "";
            tracks = "";
            account = "";
            issuedBy = "";
            effectiveTimeDifference = "";
            untilTimeDifference = "";
            expectedFeedback = "";
            pressComplete = "False";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputRightOfWayCondPointBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("57b1d2d4-a12a-48bd-94da-33d499366669")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("26d0265f-07b4-41f8-bb8d-c9c86fd7271b")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _milepost;

        /// <summary>
        /// Gets or sets the value of variable milepost.
        /// </summary>
        [TestVariable("a9d2aed2-3c94-4eac-8983-4653e59b3d80")]
        public string milepost
        {
            get { return _milepost; }
            set { _milepost = value; }
        }

        string _tracks;

        /// <summary>
        /// Gets or sets the value of variable tracks.
        /// </summary>
        [TestVariable("c9a393a1-5efb-439f-91e3-ab7ea35f0e71")]
        public string tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        string _account;

        /// <summary>
        /// Gets or sets the value of variable account.
        /// </summary>
        [TestVariable("dea60595-59dc-4bb9-99c2-5457ff40c99e")]
        public string account
        {
            get { return _account; }
            set { _account = value; }
        }

        string _issuedBy;

        /// <summary>
        /// Gets or sets the value of variable issuedBy.
        /// </summary>
        [TestVariable("1ac10cf3-95e5-455a-b16b-50aaccbbc4bd")]
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("82fd267f-606e-4c7f-a99e-d09563bb4181")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _untilTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable untilTimeDifference.
        /// </summary>
        [TestVariable("b553b0ed-9388-4e05-9c8e-f32b641893c4")]
        public string untilTimeDifference
        {
            get { return _untilTimeDifference; }
            set { _untilTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("3d8e5eeb-e940-49a1-8d97-7ad2be7f4cb0")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("22fa27c1-da62-49de-94a2-453885e31799")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("57081825-7f3f-4732-a5a3-ab17982d6992")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputRightOfWayCondPointBulletin(bulletinSeed, district, milepost, tracks, account, issuedBy, effectiveTimeDifference, untilTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
