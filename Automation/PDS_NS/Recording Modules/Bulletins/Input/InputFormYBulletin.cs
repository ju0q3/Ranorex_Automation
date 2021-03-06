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
    ///The InputFormYBulletin recording.
    /// </summary>
    [TestModule("80eb42b0-95cb-4888-819f-8f052800753c", ModuleType.Recording, 1)]
    public partial class InputFormYBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputFormYBulletin instance = new InputFormYBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputFormYBulletin()
        {
            district = "";
            direction1 = "";
            milepost1 = "";
            direction2 = "";
            milepost2 = "";
            person = "";
            effectiveTimeDifference = "";
            untilTimeDifference = "";
            maxSpeed = "";
            expectedFeedback = "";
            bulletinSeed = "";
            closeForms = "False";
            pressComplete = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputFormYBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("fe1f0b6d-61e5-4701-94bd-e3e887bb2dce")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _direction1;

        /// <summary>
        /// Gets or sets the value of variable direction1.
        /// </summary>
        [TestVariable("84265d44-5280-4a94-b541-9c7cc33b5ef9")]
        public string direction1
        {
            get { return _direction1; }
            set { _direction1 = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("3666bf1b-ca1e-4261-bdc6-fa6c15c8a924")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _direction2;

        /// <summary>
        /// Gets or sets the value of variable direction2.
        /// </summary>
        [TestVariable("619ed21c-8a0e-4c05-b8b2-3532e6d58d2e")]
        public string direction2
        {
            get { return _direction2; }
            set { _direction2 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("5f33e1ac-f612-4e99-911f-8ea034db0064")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _person;

        /// <summary>
        /// Gets or sets the value of variable person.
        /// </summary>
        [TestVariable("a0cd3a68-89cf-41fb-bb13-07133462c52d")]
        public string person
        {
            get { return _person; }
            set { _person = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("1757a341-245c-47f7-8175-00de471148b2")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _untilTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable untilTimeDifference.
        /// </summary>
        [TestVariable("8c1b3830-a6d9-4419-b86f-6b4c7f6186e7")]
        public string untilTimeDifference
        {
            get { return _untilTimeDifference; }
            set { _untilTimeDifference = value; }
        }

        string _maxSpeed;

        /// <summary>
        /// Gets or sets the value of variable maxSpeed.
        /// </summary>
        [TestVariable("030c1546-0f7a-410c-b407-a52dfcae21ba")]
        public string maxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("9ac2dcb5-8c0c-450f-a9c5-f09a4ce3013c")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("a79ebc75-0910-46ae-ab3b-2c32961d4880")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("c9b7b4df-d5a0-422a-9dda-169f9daec34d")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("2d995aa8-52eb-4dda-bab5-ba0d2fafeb18")]
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

            UserCodeCollections.NS_InputBulletins.NS_InputFormYBulletin(bulletinSeed, district, direction1, milepost1, direction2, milepost2, person, effectiveTimeDifference, untilTimeDifference, maxSpeed, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForm", closeForms), ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
