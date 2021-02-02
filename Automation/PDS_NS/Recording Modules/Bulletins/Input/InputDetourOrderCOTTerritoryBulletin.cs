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
    ///The InputDetourOrderCOTTerritoryBulletin recording.
    /// </summary>
    [TestModule("084b5658-8f0f-4638-bcd4-f11135400cca", ModuleType.Recording, 1)]
    public partial class InputDetourOrderCOTTerritoryBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputDetourOrderCOTTerritoryBulletin instance = new InputDetourOrderCOTTerritoryBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputDetourOrderCOTTerritoryBulletin()
        {
            bulletinSeed = "";
            district = "";
            effectiveTimeDifference = "";
            direction = "";
            location1 = "";
            milepost1 = "";
            location2 = "";
            milepost2 = "";
            tracks = "";
            trackAuthorityMilepostDirection = "";
            trackAuthorityMilepost = "";
            trainDispatcherMilepostDirection = "";
            trainDispatcherMilepost = "";
            doNotExceedMph = "";
            doNotExceedMphTrack = "";
            doNotExceedMphGangName = "";
            doNotExceedMphTrack2 = "";
            doNotExceedMphMilepost1 = "";
            doNotExceedMphMilepost2 = "";
            soundWhistleGangName = "";
            leadingEndTrack = "";
            leadingEndMilepost1 = "";
            leadingEndMilepost2 = "";
            issuedBy = "";
            expectedFeedback = "";
            pressComplete = "False";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputDetourOrderCOTTerritoryBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("0a1bcc09-c45f-4cfa-b7ab-1367f61ed8d0")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("bccc02dd-1423-4dd3-ba5e-5ee8d42176ee")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("0036873d-83a0-46df-a6d4-d18c18b1435e")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _direction;

        /// <summary>
        /// Gets or sets the value of variable direction.
        /// </summary>
        [TestVariable("4bb8925c-452a-402b-9a64-0b63745f08d2")]
        public string direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        string _location1;

        /// <summary>
        /// Gets or sets the value of variable location1.
        /// </summary>
        [TestVariable("e31c95c2-b6ef-49f9-8c2a-6c34a40ea246")]
        public string location1
        {
            get { return _location1; }
            set { _location1 = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("0831a698-bb9d-4a6a-ac79-e41ddadb4c30")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _location2;

        /// <summary>
        /// Gets or sets the value of variable location2.
        /// </summary>
        [TestVariable("94619770-5f54-4438-bff4-fbb3894914c9")]
        public string location2
        {
            get { return _location2; }
            set { _location2 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("88dfabbb-cbd8-45d9-956a-a961824414b9")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _tracks;

        /// <summary>
        /// Gets or sets the value of variable tracks.
        /// </summary>
        [TestVariable("103bce74-a2e8-45ed-963f-54de9a9a4d1f")]
        public string tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        string _trackAuthorityMilepostDirection;

        /// <summary>
        /// Gets or sets the value of variable trackAuthorityMilepostDirection.
        /// </summary>
        [TestVariable("7e8fc735-99e8-4aea-9b1b-b2509aef3a0f")]
        public string trackAuthorityMilepostDirection
        {
            get { return _trackAuthorityMilepostDirection; }
            set { _trackAuthorityMilepostDirection = value; }
        }

        string _trackAuthorityMilepost;

        /// <summary>
        /// Gets or sets the value of variable trackAuthorityMilepost.
        /// </summary>
        [TestVariable("e51e6dfc-33b9-4c2c-8b0b-d8468b51e145")]
        public string trackAuthorityMilepost
        {
            get { return _trackAuthorityMilepost; }
            set { _trackAuthorityMilepost = value; }
        }

        string _trainDispatcherMilepostDirection;

        /// <summary>
        /// Gets or sets the value of variable trainDispatcherMilepostDirection.
        /// </summary>
        [TestVariable("2a3d06f0-071c-405e-aed0-d7d2f7b729d8")]
        public string trainDispatcherMilepostDirection
        {
            get { return _trainDispatcherMilepostDirection; }
            set { _trainDispatcherMilepostDirection = value; }
        }

        string _trainDispatcherMilepost;

        /// <summary>
        /// Gets or sets the value of variable trainDispatcherMilepost.
        /// </summary>
        [TestVariable("023e450f-c792-43b5-ba20-e348a40c1b73")]
        public string trainDispatcherMilepost
        {
            get { return _trainDispatcherMilepost; }
            set { _trainDispatcherMilepost = value; }
        }

        string _doNotExceedMph;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMph.
        /// </summary>
        [TestVariable("b4e65a61-cc57-44f7-8080-04e7a36af671")]
        public string doNotExceedMph
        {
            get { return _doNotExceedMph; }
            set { _doNotExceedMph = value; }
        }

        string _doNotExceedMphTrack;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMphTrack.
        /// </summary>
        [TestVariable("9e84b7a5-b0ed-4ffd-a42c-d96b72655af8")]
        public string doNotExceedMphTrack
        {
            get { return _doNotExceedMphTrack; }
            set { _doNotExceedMphTrack = value; }
        }

        string _doNotExceedMphGangName;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMphGangName.
        /// </summary>
        [TestVariable("39464336-459c-4f51-94c9-3fd70c4541fc")]
        public string doNotExceedMphGangName
        {
            get { return _doNotExceedMphGangName; }
            set { _doNotExceedMphGangName = value; }
        }

        string _doNotExceedMphTrack2;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMphTrack2.
        /// </summary>
        [TestVariable("f8b3e262-b1ed-4b11-b808-5e14be2c4a29")]
        public string doNotExceedMphTrack2
        {
            get { return _doNotExceedMphTrack2; }
            set { _doNotExceedMphTrack2 = value; }
        }

        string _doNotExceedMphMilepost1;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMphMilepost1.
        /// </summary>
        [TestVariable("d7dc5336-6f32-4944-9548-1b4e6aaabb14")]
        public string doNotExceedMphMilepost1
        {
            get { return _doNotExceedMphMilepost1; }
            set { _doNotExceedMphMilepost1 = value; }
        }

        string _doNotExceedMphMilepost2;

        /// <summary>
        /// Gets or sets the value of variable doNotExceedMphMilepost2.
        /// </summary>
        [TestVariable("0e214ee4-fdbf-43ee-ae28-5d6888835149")]
        public string doNotExceedMphMilepost2
        {
            get { return _doNotExceedMphMilepost2; }
            set { _doNotExceedMphMilepost2 = value; }
        }

        string _soundWhistleGangName;

        /// <summary>
        /// Gets or sets the value of variable soundWhistleGangName.
        /// </summary>
        [TestVariable("ffa68cc0-caa9-4429-8030-8617792d1bb8")]
        public string soundWhistleGangName
        {
            get { return _soundWhistleGangName; }
            set { _soundWhistleGangName = value; }
        }

        string _leadingEndTrack;

        /// <summary>
        /// Gets or sets the value of variable leadingEndTrack.
        /// </summary>
        [TestVariable("cba7bb51-fc36-48cb-8b9a-0484993960b0")]
        public string leadingEndTrack
        {
            get { return _leadingEndTrack; }
            set { _leadingEndTrack = value; }
        }

        string _leadingEndMilepost1;

        /// <summary>
        /// Gets or sets the value of variable leadingEndMilepost1.
        /// </summary>
        [TestVariable("2e64b353-1d5b-48b4-9826-4812c572cb61")]
        public string leadingEndMilepost1
        {
            get { return _leadingEndMilepost1; }
            set { _leadingEndMilepost1 = value; }
        }

        string _leadingEndMilepost2;

        /// <summary>
        /// Gets or sets the value of variable leadingEndMilepost2.
        /// </summary>
        [TestVariable("36f30161-2e0d-44bc-93fd-4e72d78f330a")]
        public string leadingEndMilepost2
        {
            get { return _leadingEndMilepost2; }
            set { _leadingEndMilepost2 = value; }
        }

        string _issuedBy;

        /// <summary>
        /// Gets or sets the value of variable issuedBy.
        /// </summary>
        [TestVariable("1803a16a-8bfc-44b2-85e4-4e2f83c76994")]
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("070d16c6-b1c9-4ff6-8f0a-8b9b78827382")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("61c44d84-268e-47fc-a3f6-b7aa51c3d2bf")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("e8afcc60-e25e-4148-a1a9-2959f807e721")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputDetourOrderCOTTerritoryBulletin(bulletinSeed, district, effectiveTimeDifference, direction, location1, milepost1, location2, milepost2, tracks, trackAuthorityMilepostDirection, trackAuthorityMilepost, trainDispatcherMilepostDirection, trainDispatcherMilepost, doNotExceedMph, doNotExceedMphTrack, doNotExceedMphGangName, doNotExceedMphTrack2, doNotExceedMphMilepost1, doNotExceedMphMilepost2, soundWhistleGangName, leadingEndTrack, leadingEndMilepost1, leadingEndMilepost2, issuedBy, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete), ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}