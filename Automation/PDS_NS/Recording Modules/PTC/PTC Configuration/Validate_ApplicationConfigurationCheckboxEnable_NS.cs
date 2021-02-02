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
    ///The Validate_ApplicationConfigurationCheckboxEnable_NS recording.
    /// </summary>
    [TestModule("3f96d07f-27e0-4eb3-9b35-3730492ea4c0", ModuleType.Recording, 1)]
    public partial class Validate_ApplicationConfigurationCheckboxEnable_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_ApplicationConfigurationCheckboxEnable_NS instance = new Validate_ApplicationConfigurationCheckboxEnable_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_ApplicationConfigurationCheckboxEnable_NS()
        {
            bulletinVoiceAckCheckboxEnabled = "False";
            bulletinCrewAckCheckboxEnabled = "False";
            trackAuthorityCrewAckCheckboxEnabled = "False";
            gpsTrackingCheckboxEnabled = "False";
            switchPositionCheckboxEnabled = "False";
            ptcCIBOSDataTrafficCheckboxEnabled = "False";
            tconMsgCheckboxEnabled = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_ApplicationConfigurationCheckboxEnable_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinVoiceAckCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable bulletinVoiceAckCheckboxEnabled.
        /// </summary>
        [TestVariable("8b2f5334-913f-4faf-88c3-e4725e59773c")]
        public string bulletinVoiceAckCheckboxEnabled
        {
            get { return _bulletinVoiceAckCheckboxEnabled; }
            set { _bulletinVoiceAckCheckboxEnabled = value; }
        }

        string _bulletinCrewAckCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable bulletinCrewAckCheckboxEnabled.
        /// </summary>
        [TestVariable("aedc75c8-b7cb-46f5-af2c-10cae3fab49e")]
        public string bulletinCrewAckCheckboxEnabled
        {
            get { return _bulletinCrewAckCheckboxEnabled; }
            set { _bulletinCrewAckCheckboxEnabled = value; }
        }

        string _trackAuthorityCrewAckCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable trackAuthorityCrewAckCheckboxEnabled.
        /// </summary>
        [TestVariable("39a5868d-d4d3-49da-bb2e-828db7923ee4")]
        public string trackAuthorityCrewAckCheckboxEnabled
        {
            get { return _trackAuthorityCrewAckCheckboxEnabled; }
            set { _trackAuthorityCrewAckCheckboxEnabled = value; }
        }

        string _gpsTrackingCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable gpsTrackingCheckboxEnabled.
        /// </summary>
        [TestVariable("4ff327ee-9637-412c-9bd0-63e25b44ddeb")]
        public string gpsTrackingCheckboxEnabled
        {
            get { return _gpsTrackingCheckboxEnabled; }
            set { _gpsTrackingCheckboxEnabled = value; }
        }

        string _switchPositionCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable switchPositionCheckboxEnabled.
        /// </summary>
        [TestVariable("653078b9-467c-4fe9-b4bd-de38e0247208")]
        public string switchPositionCheckboxEnabled
        {
            get { return _switchPositionCheckboxEnabled; }
            set { _switchPositionCheckboxEnabled = value; }
        }

        string _ptcCIBOSDataTrafficCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable ptcCIBOSDataTrafficCheckboxEnabled.
        /// </summary>
        [TestVariable("d9bd7cd7-6ace-46d8-acc7-e5b13d2e0a29")]
        public string ptcCIBOSDataTrafficCheckboxEnabled
        {
            get { return _ptcCIBOSDataTrafficCheckboxEnabled; }
            set { _ptcCIBOSDataTrafficCheckboxEnabled = value; }
        }

        string _tconMsgCheckboxEnabled;

        /// <summary>
        /// Gets or sets the value of variable tconMsgCheckboxEnabled.
        /// </summary>
        [TestVariable("4a7569ab-72d1-41ca-9a91-660d33b8ab14")]
        public string tconMsgCheckboxEnabled
        {
            get { return _tconMsgCheckboxEnabled; }
            set { _tconMsgCheckboxEnabled = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("de4aef6b-4be2-4328-b3df-05771202c7fe")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_PTC_Configuration.NS_Validate_ApplicationConfigurationCheckboxEnable(ValueConverter.ArgumentFromString<bool>("bulletinVoiceAckCheckboxEnabled", bulletinVoiceAckCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("bulletinCrewAckCheckboxEnabled", bulletinCrewAckCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("trackAuthorityCrewAckCheckboxEnabled", trackAuthorityCrewAckCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("gpsTrackingCheckboxEnabled", gpsTrackingCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("switchPositionCheckboxEnabled", switchPositionCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("ptcCIBOSDataTrafficCheckboxEnabled", ptcCIBOSDataTrafficCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("tconMsgCheckboxEnabled", tconMsgCheckboxEnabled), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
