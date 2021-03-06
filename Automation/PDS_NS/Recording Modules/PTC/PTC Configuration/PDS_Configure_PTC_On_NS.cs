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

namespace PDS_NS.Recording_Modules.PTC.PTC_Configuration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PDS_Configure_PTC_On_NS recording.
    /// </summary>
    [TestModule("f18510be-556b-46aa-afc6-a24b77b74560", ModuleType.Recording, 1)]
    public partial class PDS_Configure_PTC_On_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static PDS_Configure_PTC_On_NS instance = new PDS_Configure_PTC_On_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PDS_Configure_PTC_On_NS()
        {
            closeForm = "False";
            enable_unsolicited_tcon = "False";
            enable_ptc_ci_bos_traffic = "True";
            enable_switch_position_awareness = "False";
            enable_gps_tracking = "False";
            enable_track_auth_crew_ack = "True";
            enable_bulletin_crew_ack = "True";
            enable_bulletin_voice_ack = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PDS_Configure_PTC_On_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("4f0a54c1-183c-4352-9a6d-2d255dafe85f")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _enable_unsolicited_tcon;

        /// <summary>
        /// Gets or sets the value of variable enable_unsolicited_tcon.
        /// </summary>
        [TestVariable("6299470c-e852-4889-be73-ada936e6b69e")]
        public string enable_unsolicited_tcon
        {
            get { return _enable_unsolicited_tcon; }
            set { _enable_unsolicited_tcon = value; }
        }

        string _enable_ptc_ci_bos_traffic;

        /// <summary>
        /// Gets or sets the value of variable enable_ptc_ci_bos_traffic.
        /// </summary>
        [TestVariable("03a68313-40d0-4d9f-8ed5-43ef7b63e2fa")]
        public string enable_ptc_ci_bos_traffic
        {
            get { return _enable_ptc_ci_bos_traffic; }
            set { _enable_ptc_ci_bos_traffic = value; }
        }

        string _enable_switch_position_awareness;

        /// <summary>
        /// Gets or sets the value of variable enable_switch_position_awareness.
        /// </summary>
        [TestVariable("f15db682-15d8-4877-bb01-929e5ec66fca")]
        public string enable_switch_position_awareness
        {
            get { return _enable_switch_position_awareness; }
            set { _enable_switch_position_awareness = value; }
        }

        string _enable_gps_tracking;

        /// <summary>
        /// Gets or sets the value of variable enable_gps_tracking.
        /// </summary>
        [TestVariable("0d9df27d-5478-4b3f-a107-dd842f75960a")]
        public string enable_gps_tracking
        {
            get { return _enable_gps_tracking; }
            set { _enable_gps_tracking = value; }
        }

        string _enable_track_auth_crew_ack;

        /// <summary>
        /// Gets or sets the value of variable enable_track_auth_crew_ack.
        /// </summary>
        [TestVariable("15c4217d-891d-4b1f-b050-6d1536e57a5a")]
        public string enable_track_auth_crew_ack
        {
            get { return _enable_track_auth_crew_ack; }
            set { _enable_track_auth_crew_ack = value; }
        }

        string _enable_bulletin_crew_ack;

        /// <summary>
        /// Gets or sets the value of variable enable_bulletin_crew_ack.
        /// </summary>
        [TestVariable("d5800e84-d278-4405-8ce4-a2ff5b4f67d8")]
        public string enable_bulletin_crew_ack
        {
            get { return _enable_bulletin_crew_ack; }
            set { _enable_bulletin_crew_ack = value; }
        }

        string _enable_bulletin_voice_ack;

        /// <summary>
        /// Gets or sets the value of variable enable_bulletin_voice_ack.
        /// </summary>
        [TestVariable("5545e3c4-a25e-4f0c-bdc1-9a24bc5dd0c2")]
        public string enable_bulletin_voice_ack
        {
            get { return _enable_bulletin_voice_ack; }
            set { _enable_bulletin_voice_ack = value; }
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

            UserCodeCollections.NS_PTC_Configuration.PTCApplicationConfiguration(ValueConverter.ArgumentFromString<bool>("enableBulletinVoiceAcknowledgement", enable_bulletin_voice_ack), ValueConverter.ArgumentFromString<bool>("enableBulletinCrewAcknowledgement", enable_bulletin_crew_ack), ValueConverter.ArgumentFromString<bool>("enableTrackAuthorityCrewAcknowledgement", enable_track_auth_crew_ack), ValueConverter.ArgumentFromString<bool>("enableGPSTracking", enable_gps_tracking), ValueConverter.ArgumentFromString<bool>("enableSwitchPositionAwareness", enable_switch_position_awareness), ValueConverter.ArgumentFromString<bool>("enablePTCCIBOSTraffic", enable_ptc_ci_bos_traffic), ValueConverter.ArgumentFromString<bool>("enableUnsolictedTCON", enable_unsolicited_tcon), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
