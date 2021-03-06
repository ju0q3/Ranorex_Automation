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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Train_Clearance
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS recording.
    /// </summary>
    [TestModule("85f26a5a-32d9-48c7-976e-9257c9455f4b", ModuleType.Recording, 1)]
    public partial class ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS instance = new ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS()
        {
            numberRangeAvailableToTrainClearancesMinimum = "";
            numberRangeAvailableToTrainClearancesMaximum = "";
            numberRangeAvailableToBulletinItemsMinimum = "";
            numberRangeAvailableToBulletinItemsMaximum = "";
            prohibitedTrackAlertEventIntervalHour = "";
            prohibitedTrackAlertEventIntervalMinute = "";
            expectedFeedback = "";
            reset = "False";
            clickApply = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyTrainClearanceParams_ConfigureTrainClearanceParams_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _numberRangeAvailableToTrainClearancesMinimum;

        /// <summary>
        /// Gets or sets the value of variable numberRangeAvailableToTrainClearancesMinimum.
        /// </summary>
        [TestVariable("cd511f35-322e-4ac0-b074-b66ff320d2eb")]
        public string numberRangeAvailableToTrainClearancesMinimum
        {
            get { return _numberRangeAvailableToTrainClearancesMinimum; }
            set { _numberRangeAvailableToTrainClearancesMinimum = value; }
        }

        string _numberRangeAvailableToTrainClearancesMaximum;

        /// <summary>
        /// Gets or sets the value of variable numberRangeAvailableToTrainClearancesMaximum.
        /// </summary>
        [TestVariable("17768376-f37c-4ac4-850d-81d8180de6fd")]
        public string numberRangeAvailableToTrainClearancesMaximum
        {
            get { return _numberRangeAvailableToTrainClearancesMaximum; }
            set { _numberRangeAvailableToTrainClearancesMaximum = value; }
        }

        string _numberRangeAvailableToBulletinItemsMinimum;

        /// <summary>
        /// Gets or sets the value of variable numberRangeAvailableToBulletinItemsMinimum.
        /// </summary>
        [TestVariable("641eb954-dc23-4d96-934e-69845d6abf99")]
        public string numberRangeAvailableToBulletinItemsMinimum
        {
            get { return _numberRangeAvailableToBulletinItemsMinimum; }
            set { _numberRangeAvailableToBulletinItemsMinimum = value; }
        }

        string _numberRangeAvailableToBulletinItemsMaximum;

        /// <summary>
        /// Gets or sets the value of variable numberRangeAvailableToBulletinItemsMaximum.
        /// </summary>
        [TestVariable("2b89d280-6053-402d-9b19-25a5e8aa4437")]
        public string numberRangeAvailableToBulletinItemsMaximum
        {
            get { return _numberRangeAvailableToBulletinItemsMaximum; }
            set { _numberRangeAvailableToBulletinItemsMaximum = value; }
        }

        string _prohibitedTrackAlertEventIntervalHour;

        /// <summary>
        /// Gets or sets the value of variable prohibitedTrackAlertEventIntervalHour.
        /// </summary>
        [TestVariable("8e16482f-66cd-4c0d-a4f8-267f5c42bd24")]
        public string prohibitedTrackAlertEventIntervalHour
        {
            get { return _prohibitedTrackAlertEventIntervalHour; }
            set { _prohibitedTrackAlertEventIntervalHour = value; }
        }

        string _prohibitedTrackAlertEventIntervalMinute;

        /// <summary>
        /// Gets or sets the value of variable prohibitedTrackAlertEventIntervalMinute.
        /// </summary>
        [TestVariable("4d933bec-b985-403e-a25a-8ef16d2a5777")]
        public string prohibitedTrackAlertEventIntervalMinute
        {
            get { return _prohibitedTrackAlertEventIntervalMinute; }
            set { _prohibitedTrackAlertEventIntervalMinute = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("1e8bc42b-e449-46c6-a58c-78dd51e7b819")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("6f78d454-fce9-4005-8a00-d0458e308333")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("bd454041-d03b-4bb4-b93a-74d9aef33f8a")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("217143ce-d900-4835-bdf6-3acce1f9c04b")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyTrainClearanceParams_ConfigureTrainClearanceParams(numberRangeAvailableToTrainClearancesMinimum, numberRangeAvailableToTrainClearancesMaximum, numberRangeAvailableToBulletinItemsMinimum, numberRangeAvailableToBulletinItemsMaximum, prohibitedTrackAlertEventIntervalHour, prohibitedTrackAlertEventIntervalMinute, expectedFeedback, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
