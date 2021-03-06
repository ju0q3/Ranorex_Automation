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

namespace PDS_NS.Recording_Modules.MIS
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendTrainScheduleComboMessagMIS_NS recording.
    /// </summary>
    [TestModule("fc589955-1c40-424e-86ee-e83f0c5d664d", ModuleType.Recording, 1)]
    public partial class SendTrainScheduleComboMessagMIS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendTrainScheduleComboMessagMIS_NS instance = new SendTrainScheduleComboMessagMIS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendTrainScheduleComboMessagMIS_NS()
        {
            from_trainSeed = "";
            from_origin_time = "";
            to_trainSeed = "";
            to_origin_time = "";
            link_and_annul_from_location = "";
            link_and_annul_from_pass_count = "";
            unlink_and_annul_to_location = "";
            unlink_and_annul_to_pass_count = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendTrainScheduleComboMessagMIS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _from_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable from_trainSeed.
        /// </summary>
        [TestVariable("92fe744a-586f-4b6b-97c0-f3ac14bd684c")]
        public string from_trainSeed
        {
            get { return _from_trainSeed; }
            set { _from_trainSeed = value; }
        }

        string _from_origin_time;

        /// <summary>
        /// Gets or sets the value of variable from_origin_time.
        /// </summary>
        [TestVariable("c6a3dc78-e39a-47a8-95ab-e5e6e6db63e7")]
        public string from_origin_time
        {
            get { return _from_origin_time; }
            set { _from_origin_time = value; }
        }

        string _to_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable to_trainSeed.
        /// </summary>
        [TestVariable("f911e49b-c4f3-4537-9e0b-337cde2c2724")]
        public string to_trainSeed
        {
            get { return _to_trainSeed; }
            set { _to_trainSeed = value; }
        }

        string _to_origin_time;

        /// <summary>
        /// Gets or sets the value of variable to_origin_time.
        /// </summary>
        [TestVariable("9615b666-674f-4c04-86c6-c6dffa9c4447")]
        public string to_origin_time
        {
            get { return _to_origin_time; }
            set { _to_origin_time = value; }
        }

        string _link_and_annul_from_location;

        /// <summary>
        /// Gets or sets the value of variable link_and_annul_from_location.
        /// </summary>
        [TestVariable("56f01caf-bcad-429b-8bba-d2295dc95d50")]
        public string link_and_annul_from_location
        {
            get { return _link_and_annul_from_location; }
            set { _link_and_annul_from_location = value; }
        }

        string _link_and_annul_from_pass_count;

        /// <summary>
        /// Gets or sets the value of variable link_and_annul_from_pass_count.
        /// </summary>
        [TestVariable("114179f6-0e61-4095-911a-0d1110b05a5c")]
        public string link_and_annul_from_pass_count
        {
            get { return _link_and_annul_from_pass_count; }
            set { _link_and_annul_from_pass_count = value; }
        }

        string _unlink_and_annul_to_location;

        /// <summary>
        /// Gets or sets the value of variable unlink_and_annul_to_location.
        /// </summary>
        [TestVariable("dd62af7b-e5aa-4571-b979-eb29839d5ee3")]
        public string unlink_and_annul_to_location
        {
            get { return _unlink_and_annul_to_location; }
            set { _unlink_and_annul_to_location = value; }
        }

        string _unlink_and_annul_to_pass_count;

        /// <summary>
        /// Gets or sets the value of variable unlink_and_annul_to_pass_count.
        /// </summary>
        [TestVariable("c03f7477-6bd9-416b-9e8f-3a26e47aa7aa")]
        public string unlink_and_annul_to_pass_count
        {
            get { return _unlink_and_annul_to_pass_count; }
            set { _unlink_and_annul_to_pass_count = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_SendTrainScheduleComboMessage(from_trainSeed, from_origin_time, to_trainSeed, to_origin_time, link_and_annul_from_location, link_and_annul_from_pass_count, unlink_and_annul_to_location, unlink_and_annul_to_pass_count);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
