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
    ///The ValidatePTCMessageTrafficSettingsButtons recording.
    /// </summary>
    [TestModule("fe724197-bfe2-4f47-9772-27d808eaccde", ModuleType.Recording, 1)]
    public partial class ValidatePTCMessageTrafficSettingsButtons : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePTCMessageTrafficSettingsButtons instance = new ValidatePTCMessageTrafficSettingsButtons();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePTCMessageTrafficSettingsButtons()
        {
            configurationTabName = "";
            buttonExist = "False";
            closePTCConfigurationForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePTCMessageTrafficSettingsButtons Instance
        {
            get { return instance; }
        }

#region Variables

        string _configurationTabName;

        /// <summary>
        /// Gets or sets the value of variable configurationTabName.
        /// </summary>
        [TestVariable("dcac75a5-f34b-4e82-b037-931682ea42c9")]
        public string configurationTabName
        {
            get { return _configurationTabName; }
            set { _configurationTabName = value; }
        }

        string _buttonExist;

        /// <summary>
        /// Gets or sets the value of variable buttonExist.
        /// </summary>
        [TestVariable("18370a47-1f10-4d80-8e61-ff49fafb9074")]
        public string buttonExist
        {
            get { return _buttonExist; }
            set { _buttonExist = value; }
        }

        string _closePTCConfigurationForm;

        /// <summary>
        /// Gets or sets the value of variable closePTCConfigurationForm.
        /// </summary>
        [TestVariable("3998e614-61ee-42ed-aac6-ea6c23a89a9c")]
        public string closePTCConfigurationForm
        {
            get { return _closePTCConfigurationForm; }
            set { _closePTCConfigurationForm = value; }
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

            UserCodeCollections.NS_PTC_Configuration.ValidatePTCMessageTrafficSettingsButtonState_NS(configurationTabName, ValueConverter.ArgumentFromString<bool>("buttonsExist", buttonExist), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closePTCConfigurationForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
