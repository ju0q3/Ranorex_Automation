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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC recording.
    /// </summary>
    [TestModule("d29fcf02-77e4-49f8-9119-252eed1d32f8", ModuleType.Recording, 1)]
    public partial class ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC instance = new ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC()
        {
            trainSeed = "";
            trainGroup = "";
            scheduleStatus = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("a9ac4663-435e-4243-be83-7a071bc3c3e9")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _trainGroup;

        /// <summary>
        /// Gets or sets the value of variable trainGroup.
        /// </summary>
        [TestVariable("92729d9b-3013-43ff-b577-393067c17f69")]
        public string trainGroup
        {
            get { return _trainGroup; }
            set { _trainGroup = value; }
        }

        string _scheduleStatus;

        /// <summary>
        /// Gets or sets the value of variable scheduleStatus.
        /// </summary>
        [TestVariable("9cb7c09b-bc63-47ef-874d-03f6998b8f2c")]
        public string scheduleStatus
        {
            get { return _scheduleStatus; }
            set { _scheduleStatus = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidatePlannedTrainsDetails_RequestStatisticsTab_NVC(trainSeed, trainGroup, scheduleStatus);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
