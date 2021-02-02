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
    ///The InputXMFBadFootingAreaBulletin recording.
    /// </summary>
    [TestModule("f68ffa21-721a-4192-a8fe-8d4d4d63e2c2", ModuleType.Recording, 1)]
    public partial class InputXMFBadFootingAreaBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputXMFBadFootingAreaBulletin instance = new InputXMFBadFootingAreaBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputXMFBadFootingAreaBulletin()
        {
            bulletinSeed = "";
            district = "";
            milepost1 = "";
            milepost2 = "";
            tracks = "";
            account = "";
            issuedBy = "";
            effectiveTimeDifference = "";
            nearMilepost = "";
            expectedFeedback = "";
            pressComplete = "False";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputXMFBadFootingAreaBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("2aeca405-cfb2-4887-b4a6-495edfca2710")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("a30b0d71-a0ab-414f-90fc-bc26cd375eb9")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("ce2d5c3c-76e6-48bb-893e-b9f03cbcb01a")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("464c92f5-4d3f-440e-ac5d-d3e9a1328c84")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _tracks;

        /// <summary>
        /// Gets or sets the value of variable tracks.
        /// </summary>
        [TestVariable("a55a69d6-5702-426e-a0c2-1c7a2d12ba61")]
        public string tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        string _account;

        /// <summary>
        /// Gets or sets the value of variable account.
        /// </summary>
        [TestVariable("118b1a38-8f62-444a-9bae-845a436b26b0")]
        public string account
        {
            get { return _account; }
            set { _account = value; }
        }

        string _issuedBy;

        /// <summary>
        /// Gets or sets the value of variable issuedBy.
        /// </summary>
        [TestVariable("719425e1-f975-46b8-957d-4545066934fb")]
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("e4809b97-a833-40fc-88b3-6d7c091d3975")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _nearMilepost;

        /// <summary>
        /// Gets or sets the value of variable nearMilepost.
        /// </summary>
        [TestVariable("c471ea77-f2fb-4dc5-8087-9f0101e63ebb")]
        public string nearMilepost
        {
            get { return _nearMilepost; }
            set { _nearMilepost = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("749e16d2-d292-4f1a-991a-63c3138e0bbb")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("64494a69-430c-4a2b-aea2-015cc6fa6cb1")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("852b7a26-555f-44cb-9495-6dbdadb29aeb")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputXMFBadFootingAreaBulletin(bulletinSeed, district, milepost1, milepost2, tracks, account, issuedBy, effectiveTimeDifference, nearMilepost, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
