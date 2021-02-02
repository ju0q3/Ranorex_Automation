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
    ///The SendWeatherAlertMIS_NS recording.
    /// </summary>
    [TestModule("08c05180-a4ef-44b5-9868-652a80361552", ModuleType.Recording, 1)]
    public partial class SendWeatherAlertMIS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendWeatherAlertMIS_NS instance = new SendWeatherAlertMIS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendWeatherAlertMIS_NS()
        {
            wx_report_id = "";
            operator_initials = "";
            state = "";
            division = "";
            wx_msg_type = "";
            wx_code = "";
            wx_condition = "";
            wx_severity = "";
            wx_description = "";
            wx_details = "";
            time_zone = "";
            in_effect_time_offset_minutes = "";
            until_time_offset_minutes = "";
            wx_recipient_id = "";
            wx_warning_number = "";
            wx_warning_version = "";
            stations = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendWeatherAlertMIS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _wx_report_id;

        /// <summary>
        /// Gets or sets the value of variable wx_report_id.
        /// </summary>
        [TestVariable("c3ca531e-0e6f-485f-a02d-095b6e1fd8ff")]
        public string wx_report_id
        {
            get { return _wx_report_id; }
            set { _wx_report_id = value; }
        }

        string _operator_initials;

        /// <summary>
        /// Gets or sets the value of variable operator_initials.
        /// </summary>
        [TestVariable("679482fc-7d3f-48a0-b742-00aa440e0547")]
        public string operator_initials
        {
            get { return _operator_initials; }
            set { _operator_initials = value; }
        }

        string _state;

        /// <summary>
        /// Gets or sets the value of variable state.
        /// </summary>
        [TestVariable("59ee2f63-ef0d-4491-ba0b-8f9d54721bad")]
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("dc8f7b67-40e7-4bab-8622-5027bc666624")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _wx_msg_type;

        /// <summary>
        /// Gets or sets the value of variable wx_msg_type.
        /// </summary>
        [TestVariable("66ed0adb-7d81-4505-81b2-7e253c0e8844")]
        public string wx_msg_type
        {
            get { return _wx_msg_type; }
            set { _wx_msg_type = value; }
        }

        string _wx_code;

        /// <summary>
        /// Gets or sets the value of variable wx_code.
        /// </summary>
        [TestVariable("f25eecf4-6d6f-4991-99e2-b963fedbb03b")]
        public string wx_code
        {
            get { return _wx_code; }
            set { _wx_code = value; }
        }

        string _wx_condition;

        /// <summary>
        /// Gets or sets the value of variable wx_condition.
        /// </summary>
        [TestVariable("580277d1-ef87-4725-aba6-d2e066cc7376")]
        public string wx_condition
        {
            get { return _wx_condition; }
            set { _wx_condition = value; }
        }

        string _wx_severity;

        /// <summary>
        /// Gets or sets the value of variable wx_severity.
        /// </summary>
        [TestVariable("04c63cba-2a6e-4e9f-979c-627ed800d7c4")]
        public string wx_severity
        {
            get { return _wx_severity; }
            set { _wx_severity = value; }
        }

        string _wx_description;

        /// <summary>
        /// Gets or sets the value of variable wx_description.
        /// </summary>
        [TestVariable("57e51164-300c-44a7-82a6-da78ca690142")]
        public string wx_description
        {
            get { return _wx_description; }
            set { _wx_description = value; }
        }

        string _wx_details;

        /// <summary>
        /// Gets or sets the value of variable wx_details.
        /// </summary>
        [TestVariable("35b0a15f-c2ed-46d8-a29e-bb9b6adb3d0d")]
        public string wx_details
        {
            get { return _wx_details; }
            set { _wx_details = value; }
        }

        string _time_zone;

        /// <summary>
        /// Gets or sets the value of variable time_zone.
        /// </summary>
        [TestVariable("316c5e73-3af5-4c26-bbbb-0c9221442452")]
        public string time_zone
        {
            get { return _time_zone; }
            set { _time_zone = value; }
        }

        string _in_effect_time_offset_minutes;

        /// <summary>
        /// Gets or sets the value of variable in_effect_time_offset_minutes.
        /// </summary>
        [TestVariable("ff5a6d4f-546a-4390-86c4-adc88c1ec014")]
        public string in_effect_time_offset_minutes
        {
            get { return _in_effect_time_offset_minutes; }
            set { _in_effect_time_offset_minutes = value; }
        }

        string _until_time_offset_minutes;

        /// <summary>
        /// Gets or sets the value of variable until_time_offset_minutes.
        /// </summary>
        [TestVariable("e18f3530-d10d-4035-afe2-c064b57b2ef5")]
        public string until_time_offset_minutes
        {
            get { return _until_time_offset_minutes; }
            set { _until_time_offset_minutes = value; }
        }

        string _wx_recipient_id;

        /// <summary>
        /// Gets or sets the value of variable wx_recipient_id.
        /// </summary>
        [TestVariable("cdd24deb-bdb2-4ec9-8763-148519f3308b")]
        public string wx_recipient_id
        {
            get { return _wx_recipient_id; }
            set { _wx_recipient_id = value; }
        }

        string _wx_warning_number;

        /// <summary>
        /// Gets or sets the value of variable wx_warning_number.
        /// </summary>
        [TestVariable("0edefbc9-9def-46cd-9f1a-4d1f3d5491f4")]
        public string wx_warning_number
        {
            get { return _wx_warning_number; }
            set { _wx_warning_number = value; }
        }

        string _wx_warning_version;

        /// <summary>
        /// Gets or sets the value of variable wx_warning_version.
        /// </summary>
        [TestVariable("6d4ab3bd-e7c8-4aac-893e-c50ccddba57d")]
        public string wx_warning_version
        {
            get { return _wx_warning_version; }
            set { _wx_warning_version = value; }
        }

        string _stations;

        /// <summary>
        /// Gets or sets the value of variable stations.
        /// </summary>
        [TestVariable("19a66cc1-e008-4546-9587-03eac90b9293")]
        public string stations
        {
            get { return _stations; }
            set { _stations = value; }
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

            STE.Code_Utils.SendMISFileCollection_NS.NS_SendWeatherAlert(wx_report_id, operator_initials, state, division, wx_msg_type, wx_code, wx_condition, wx_severity, wx_description, wx_details, time_zone, in_effect_time_offset_minutes, until_time_offset_minutes, wx_recipient_id, wx_warning_number, wx_warning_version, stations);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}