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
    ///The InputMofWRestSpeedBulletin recording.
    /// </summary>
    [TestModule("20d02e92-cdb5-4df6-a58f-c9d7a3f64829", ModuleType.Recording, 1)]
    public partial class InputMofWRestSpeedBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputMofWRestSpeedBulletin instance = new InputMofWRestSpeedBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputMofWRestSpeedBulletin()
        {
            district = "";
            employee = "";
            milepost1 = "";
            milepost2 = "";
            tracks = "";
            zones = "";
            effectiveTimeDifference = "";
            untilTimeDifference = "";
            restrictedSpeed = "";
            expectedFeedback = "";
            bulletinSeed = "";
            pressComplete = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputMofWRestSpeedBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("6fe07842-a37b-4168-a50a-accaa545a9a2")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _employee;

        /// <summary>
        /// Gets or sets the value of variable employee.
        /// </summary>
        [TestVariable("b0a599d0-6dde-4d9d-9648-580dcd361589")]
        public string employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("34f1253f-2092-4ce4-8098-ff1eadb88110")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("034828d4-e99b-428f-803b-a72179bd0e56")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _tracks;

        /// <summary>
        /// Gets or sets the value of variable tracks.
        /// </summary>
        [TestVariable("115fde3d-a3ff-4559-8502-a9a7e8401525")]
        public string tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        string _zones;

        /// <summary>
        /// Gets or sets the value of variable zones.
        /// </summary>
        [TestVariable("8b78c765-d32d-4632-969b-ddcbf2b308ef")]
        public string zones
        {
            get { return _zones; }
            set { _zones = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("c38ef28e-6784-4826-a7b1-1b6033a239e1")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _untilTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable untilTimeDifference.
        /// </summary>
        [TestVariable("ccff68fd-5d68-407a-87c8-47e58ae8453d")]
        public string untilTimeDifference
        {
            get { return _untilTimeDifference; }
            set { _untilTimeDifference = value; }
        }

        string _restrictedSpeed;

        /// <summary>
        /// Gets or sets the value of variable restrictedSpeed.
        /// </summary>
        [TestVariable("0066db3b-efad-4c5f-a6fd-aed2953aba61")]
        public string restrictedSpeed
        {
            get { return _restrictedSpeed; }
            set { _restrictedSpeed = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("48ac44b5-ba64-4dfc-ac11-217ec0d619a4")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("3be6d01c-3f7f-455d-959f-3bccf58d4792")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("68854b79-20c9-4922-aa99-ca046e37a5dd")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
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

            UserCodeCollections.NS_InputBulletins.NS_InputMofWReservationRestSpeedBulletin(bulletinSeed, district, employee, milepost1, milepost2, tracks, zones, effectiveTimeDifference, untilTimeDifference, restrictedSpeed, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
