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
    ///The InputMiscInstructionsAreaBulletin recording.
    /// </summary>
    [TestModule("12f16361-fbbb-44e4-aea8-f14b11b6fcf1", ModuleType.Recording, 1)]
    public partial class InputMiscInstructionsAreaBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputMiscInstructionsAreaBulletin instance = new InputMiscInstructionsAreaBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputMiscInstructionsAreaBulletin()
        {
            district = "";
            milepost1 = "";
            milepost2 = "";
            miscInstructions = "";
            effectiveTimeDifference = "";
            untilTimeDifference = "";
            expectedFeedback = "";
            bulletinSeed = "";
            pressComplete = "False";
            issuedBy = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputMiscInstructionsAreaBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("fffc48bc-a1e0-4a2a-afdd-b52562065609")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _milepost1;

        /// <summary>
        /// Gets or sets the value of variable milepost1.
        /// </summary>
        [TestVariable("ead61e66-5b0c-4514-bf58-f3342055486a")]
        public string milepost1
        {
            get { return _milepost1; }
            set { _milepost1 = value; }
        }

        string _milepost2;

        /// <summary>
        /// Gets or sets the value of variable milepost2.
        /// </summary>
        [TestVariable("ccfe89b6-0a0b-4548-aa9f-ef7e6a770888")]
        public string milepost2
        {
            get { return _milepost2; }
            set { _milepost2 = value; }
        }

        string _miscInstructions;

        /// <summary>
        /// Gets or sets the value of variable miscInstructions.
        /// </summary>
        [TestVariable("5d793c05-3895-44af-87db-3274b7ff39c2")]
        public string miscInstructions
        {
            get { return _miscInstructions; }
            set { _miscInstructions = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("84ed887d-d9d8-47bc-b502-e303e900556f")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _untilTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable untilTimeDifference.
        /// </summary>
        [TestVariable("e1f51b79-c197-4372-9ac4-5a6e706c096a")]
        public string untilTimeDifference
        {
            get { return _untilTimeDifference; }
            set { _untilTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("4bea46c4-8a3f-400d-9560-49b75374e14d")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("cd5a7937-769e-4248-931e-17d2e7e5701d")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("76cf3c58-fb45-40a8-a8e8-dca8368efa99")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
        }

        string _issuedBy;

        /// <summary>
        /// Gets or sets the value of variable issuedBy.
        /// </summary>
        [TestVariable("908db08c-b736-4272-9e6d-ecab265b4e9a")]
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
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

            UserCodeCollections.NS_InputBulletins.NS_InputMiscInstructionsAreaBulletin(bulletinSeed, district, milepost1, milepost2, miscInstructions, issuedBy, effectiveTimeDifference, untilTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
