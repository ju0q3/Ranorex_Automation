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

namespace PDS_NS.Recording_Modules.PTC.PTC_Messages
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendCD_BARS_7Full_NS recording.
    /// </summary>
    [TestModule("a8a6e036-80ec-487b-9980-d5621bc45a9d", ModuleType.Recording, 1)]
    public partial class SendCD_BARS_7Full_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendCD_BARS_7Full_NS instance = new SendCD_BARS_7Full_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendCD_BARS_7Full_NS()
        {
            header_event_date_offset_days = "";
            header_event_time_offset_minutes = "";
            header_sequence_number = "";
            header_message_version = "";
            header_message_revision = "";
            header_source_sys = "";
            header_destination_sys = "";
            header_district_name = "";
            header_district_scac = "";
            header_user_id = "";
            header_track_file_version = "";
            header_htrn_scac_trainSeed = "";
            header_htrn_symbol_trainSeed = "";
            header_htrn_section_trainSeed = "";
            header_htrn_origin_date_trainSeed = "";
            header_heng_engine_initial_trainSeed = "";
            header_heng_engine_initial_engineSeed = "";
            header_heng_engine_number_trainSeed = "";
            header_heng_engine_number_engineSeed = "";
            header_uid1_type = "";
            header_uid1 = "";
            header_uid2_type = "";
            header_uid2 = "";
            content_bulletin_item_number_bulletinSeed = "";
            content_scac_trainSeed = "";
            content_symbol_trainSeed = "";
            content_section_trainSeed = "";
            content_origin_date_trainSeed = "";
            content_crew_ack_required = "";
            content_electronic_ack_required = "";
            content_status_code = "";
            content_engine_initial_trainSeed = "";
            content_engine_intial_engineSeed = "";
            content_engine_number_trainSeed = "";
            content_engine_number_engineSeed = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendCD_BARS_7Full_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _header_event_date_offset_days;

        /// <summary>
        /// Gets or sets the value of variable header_event_date_offset_days.
        /// </summary>
        [TestVariable("c1d0a480-3a61-4cef-b3fa-63304e8a0b50")]
        public string header_event_date_offset_days
        {
            get { return _header_event_date_offset_days; }
            set { _header_event_date_offset_days = value; }
        }

        string _header_event_time_offset_minutes;

        /// <summary>
        /// Gets or sets the value of variable header_event_time_offset_minutes.
        /// </summary>
        [TestVariable("45102214-c91a-42f5-89dc-0e4adb55564b")]
        public string header_event_time_offset_minutes
        {
            get { return _header_event_time_offset_minutes; }
            set { _header_event_time_offset_minutes = value; }
        }

        string _header_sequence_number;

        /// <summary>
        /// Gets or sets the value of variable header_sequence_number.
        /// </summary>
        [TestVariable("82da87a9-25cb-45d1-b260-488f2357b387")]
        public string header_sequence_number
        {
            get { return _header_sequence_number; }
            set { _header_sequence_number = value; }
        }

        string _header_message_version;

        /// <summary>
        /// Gets or sets the value of variable header_message_version.
        /// </summary>
        [TestVariable("6289806d-5699-45e6-b52f-697776dcd2d0")]
        public string header_message_version
        {
            get { return _header_message_version; }
            set { _header_message_version = value; }
        }

        string _header_message_revision;

        /// <summary>
        /// Gets or sets the value of variable header_message_revision.
        /// </summary>
        [TestVariable("dd5acb83-f7d3-48a9-8b55-c2490f1a1145")]
        public string header_message_revision
        {
            get { return _header_message_revision; }
            set { _header_message_revision = value; }
        }

        string _header_source_sys;

        /// <summary>
        /// Gets or sets the value of variable header_source_sys.
        /// </summary>
        [TestVariable("72d99edb-b67f-49ad-844b-0cf49e1a6d2c")]
        public string header_source_sys
        {
            get { return _header_source_sys; }
            set { _header_source_sys = value; }
        }

        string _header_destination_sys;

        /// <summary>
        /// Gets or sets the value of variable header_destination_sys.
        /// </summary>
        [TestVariable("209d108e-addc-4a63-9a30-ae4466585258")]
        public string header_destination_sys
        {
            get { return _header_destination_sys; }
            set { _header_destination_sys = value; }
        }

        string _header_district_name;

        /// <summary>
        /// Gets or sets the value of variable header_district_name.
        /// </summary>
        [TestVariable("5b7f07fb-ee5f-4039-88e0-4eb089e317f6")]
        public string header_district_name
        {
            get { return _header_district_name; }
            set { _header_district_name = value; }
        }

        string _header_district_scac;

        /// <summary>
        /// Gets or sets the value of variable header_district_scac.
        /// </summary>
        [TestVariable("8753141d-c73d-48f0-a0a4-991a3e2aca47")]
        public string header_district_scac
        {
            get { return _header_district_scac; }
            set { _header_district_scac = value; }
        }

        string _header_user_id;

        /// <summary>
        /// Gets or sets the value of variable header_user_id.
        /// </summary>
        [TestVariable("36b5c81e-b563-444c-8693-96312bbd9b6d")]
        public string header_user_id
        {
            get { return _header_user_id; }
            set { _header_user_id = value; }
        }

        string _header_track_file_version;

        /// <summary>
        /// Gets or sets the value of variable header_track_file_version.
        /// </summary>
        [TestVariable("fb0903f2-02e6-4883-a4b8-91eb573f638b")]
        public string header_track_file_version
        {
            get { return _header_track_file_version; }
            set { _header_track_file_version = value; }
        }

        string _header_htrn_scac_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_htrn_scac_trainSeed.
        /// </summary>
        [TestVariable("05a1c91f-454d-435f-801d-a90d92aae3bb")]
        public string header_htrn_scac_trainSeed
        {
            get { return _header_htrn_scac_trainSeed; }
            set { _header_htrn_scac_trainSeed = value; }
        }

        string _header_htrn_symbol_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_htrn_symbol_trainSeed.
        /// </summary>
        [TestVariable("863cfa74-1fed-45dc-974a-1e86ef48025e")]
        public string header_htrn_symbol_trainSeed
        {
            get { return _header_htrn_symbol_trainSeed; }
            set { _header_htrn_symbol_trainSeed = value; }
        }

        string _header_htrn_section_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_htrn_section_trainSeed.
        /// </summary>
        [TestVariable("ed5edb82-13c5-449a-9cb4-8c39a7d1dd26")]
        public string header_htrn_section_trainSeed
        {
            get { return _header_htrn_section_trainSeed; }
            set { _header_htrn_section_trainSeed = value; }
        }

        string _header_htrn_origin_date_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_htrn_origin_date_trainSeed.
        /// </summary>
        [TestVariable("a1c7ad7c-7a0a-4754-a78c-586e596564f1")]
        public string header_htrn_origin_date_trainSeed
        {
            get { return _header_htrn_origin_date_trainSeed; }
            set { _header_htrn_origin_date_trainSeed = value; }
        }

        string _header_heng_engine_initial_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_heng_engine_initial_trainSeed.
        /// </summary>
        [TestVariable("ec228769-472f-4868-a3de-55a057fef167")]
        public string header_heng_engine_initial_trainSeed
        {
            get { return _header_heng_engine_initial_trainSeed; }
            set { _header_heng_engine_initial_trainSeed = value; }
        }

        string _header_heng_engine_initial_engineSeed;

        /// <summary>
        /// Gets or sets the value of variable header_heng_engine_initial_engineSeed.
        /// </summary>
        [TestVariable("d547dd87-45ca-43a3-ace8-204f15a7676f")]
        public string header_heng_engine_initial_engineSeed
        {
            get { return _header_heng_engine_initial_engineSeed; }
            set { _header_heng_engine_initial_engineSeed = value; }
        }

        string _header_heng_engine_number_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable header_heng_engine_number_trainSeed.
        /// </summary>
        [TestVariable("aeaf7e18-2626-4eb5-80ee-171deee8c5e5")]
        public string header_heng_engine_number_trainSeed
        {
            get { return _header_heng_engine_number_trainSeed; }
            set { _header_heng_engine_number_trainSeed = value; }
        }

        string _header_heng_engine_number_engineSeed;

        /// <summary>
        /// Gets or sets the value of variable header_heng_engine_number_engineSeed.
        /// </summary>
        [TestVariable("54668a79-45f8-4ce5-bbe5-6c6028acd590")]
        public string header_heng_engine_number_engineSeed
        {
            get { return _header_heng_engine_number_engineSeed; }
            set { _header_heng_engine_number_engineSeed = value; }
        }

        string _header_uid1_type;

        /// <summary>
        /// Gets or sets the value of variable header_uid1_type.
        /// </summary>
        [TestVariable("7b9f713e-5962-408a-a5f7-a72a3cd29075")]
        public string header_uid1_type
        {
            get { return _header_uid1_type; }
            set { _header_uid1_type = value; }
        }

        string _header_uid1;

        /// <summary>
        /// Gets or sets the value of variable header_uid1.
        /// </summary>
        [TestVariable("3a785b0e-25d9-4fb3-af99-1e7b44b38b77")]
        public string header_uid1
        {
            get { return _header_uid1; }
            set { _header_uid1 = value; }
        }

        string _header_uid2_type;

        /// <summary>
        /// Gets or sets the value of variable header_uid2_type.
        /// </summary>
        [TestVariable("5df781af-2e06-4ead-b2f9-f8291c080ec0")]
        public string header_uid2_type
        {
            get { return _header_uid2_type; }
            set { _header_uid2_type = value; }
        }

        string _header_uid2;

        /// <summary>
        /// Gets or sets the value of variable header_uid2.
        /// </summary>
        [TestVariable("5375bbc7-1f2c-43a8-ba08-46b6b2ed2abc")]
        public string header_uid2
        {
            get { return _header_uid2; }
            set { _header_uid2 = value; }
        }

        string _content_bulletin_item_number_bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable content_bulletin_item_number_bulletinSeed.
        /// </summary>
        [TestVariable("c71dab12-c273-472c-a44b-e8005da363be")]
        public string content_bulletin_item_number_bulletinSeed
        {
            get { return _content_bulletin_item_number_bulletinSeed; }
            set { _content_bulletin_item_number_bulletinSeed = value; }
        }

        string _content_scac_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_scac_trainSeed.
        /// </summary>
        [TestVariable("8ec19785-0d77-4ce8-abad-d97a21a8ca39")]
        public string content_scac_trainSeed
        {
            get { return _content_scac_trainSeed; }
            set { _content_scac_trainSeed = value; }
        }

        string _content_symbol_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_symbol_trainSeed.
        /// </summary>
        [TestVariable("27edb318-f9dc-4e95-874f-4013e128d306")]
        public string content_symbol_trainSeed
        {
            get { return _content_symbol_trainSeed; }
            set { _content_symbol_trainSeed = value; }
        }

        string _content_section_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_section_trainSeed.
        /// </summary>
        [TestVariable("0c9d12e4-5c37-4def-b020-8118e48090ca")]
        public string content_section_trainSeed
        {
            get { return _content_section_trainSeed; }
            set { _content_section_trainSeed = value; }
        }

        string _content_origin_date_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_origin_date_trainSeed.
        /// </summary>
        [TestVariable("286d2a6e-0063-4dd0-bd8c-d06019aa7e3e")]
        public string content_origin_date_trainSeed
        {
            get { return _content_origin_date_trainSeed; }
            set { _content_origin_date_trainSeed = value; }
        }

        string _content_crew_ack_required;

        /// <summary>
        /// Gets or sets the value of variable content_crew_ack_required.
        /// </summary>
        [TestVariable("7fd021c4-5e15-4a0b-9653-c75dda356606")]
        public string content_crew_ack_required
        {
            get { return _content_crew_ack_required; }
            set { _content_crew_ack_required = value; }
        }

        string _content_electronic_ack_required;

        /// <summary>
        /// Gets or sets the value of variable content_electronic_ack_required.
        /// </summary>
        [TestVariable("6a7ab458-b33c-44a9-b626-e1629cc86f28")]
        public string content_electronic_ack_required
        {
            get { return _content_electronic_ack_required; }
            set { _content_electronic_ack_required = value; }
        }

        string _content_status_code;

        /// <summary>
        /// Gets or sets the value of variable content_status_code.
        /// </summary>
        [TestVariable("67123770-f1be-4dde-a217-8f46020b13e1")]
        public string content_status_code
        {
            get { return _content_status_code; }
            set { _content_status_code = value; }
        }

        string _content_engine_initial_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_engine_initial_trainSeed.
        /// </summary>
        [TestVariable("a506d4dd-3dd4-497a-97bd-979949012fc7")]
        public string content_engine_initial_trainSeed
        {
            get { return _content_engine_initial_trainSeed; }
            set { _content_engine_initial_trainSeed = value; }
        }

        string _content_engine_intial_engineSeed;

        /// <summary>
        /// Gets or sets the value of variable content_engine_intial_engineSeed.
        /// </summary>
        [TestVariable("dfeb5dbf-a170-48b4-8de6-1f02f1eb0254")]
        public string content_engine_intial_engineSeed
        {
            get { return _content_engine_intial_engineSeed; }
            set { _content_engine_intial_engineSeed = value; }
        }

        string _content_engine_number_trainSeed;

        /// <summary>
        /// Gets or sets the value of variable content_engine_number_trainSeed.
        /// </summary>
        [TestVariable("c9d6e493-f5ab-445b-9710-8a6ec6861de2")]
        public string content_engine_number_trainSeed
        {
            get { return _content_engine_number_trainSeed; }
            set { _content_engine_number_trainSeed = value; }
        }

        string _content_engine_number_engineSeed;

        /// <summary>
        /// Gets or sets the value of variable content_engine_number_engineSeed.
        /// </summary>
        [TestVariable("1f2d8a94-b376-4dc6-be0b-3bb89d553e2a")]
        public string content_engine_number_engineSeed
        {
            get { return _content_engine_number_engineSeed; }
            set { _content_engine_number_engineSeed = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("34666c8c-553c-4202-9537-833ae0b09bb6")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_PTC_Messages.sendCD_BARS_7(header_event_date_offset_days, header_event_time_offset_minutes, header_sequence_number, header_message_version, header_message_revision, header_source_sys, header_destination_sys, header_district_name, header_district_scac, header_user_id, header_track_file_version, header_htrn_scac_trainSeed, header_htrn_symbol_trainSeed, header_htrn_section_trainSeed, header_htrn_origin_date_trainSeed, header_heng_engine_initial_trainSeed, header_heng_engine_initial_engineSeed, header_heng_engine_number_trainSeed, header_heng_engine_number_engineSeed, header_uid1_type, header_uid1, header_uid2_type, header_uid2, content_bulletin_item_number_bulletinSeed, content_scac_trainSeed, content_symbol_trainSeed, content_section_trainSeed, content_origin_date_trainSeed, content_crew_ack_required, content_electronic_ack_required, content_status_code, content_engine_initial_trainSeed, content_engine_intial_engineSeed, content_engine_number_trainSeed, content_engine_number_engineSeed, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
