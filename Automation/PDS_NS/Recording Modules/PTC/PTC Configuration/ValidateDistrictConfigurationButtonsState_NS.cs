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
    ///The ValidateDistrictConfigurationButtonsState_NS recording.
    /// </summary>
    [TestModule("0b33a53e-9d47-42e3-8fa7-f32c2a6e80da", ModuleType.Recording, 1)]
    public partial class ValidateDistrictConfigurationButtonsState_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDistrictConfigurationButtonsState_NS instance = new ValidateDistrictConfigurationButtonsState_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDistrictConfigurationButtonsState_NS()
        {
            loadButtonEnabled = "False";
            saveButtonEnabled = "False";
            disableAllButtonEnabled = "False";
            okButtonEnabled = "False";
            applyButtonEnabled = "False";
            resetButtonEnabled = "False";
            cancelButtonEnabled = "False";
            closePTCConfigurationForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDistrictConfigurationButtonsState_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _loadButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable loadButtonEnabled.
        /// </summary>
        [TestVariable("5b3cad9c-3a4b-49c4-8ece-115b52cb7096")]
        public string loadButtonEnabled
        {
            get { return _loadButtonEnabled; }
            set { _loadButtonEnabled = value; }
        }

        string _saveButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable saveButtonEnabled.
        /// </summary>
        [TestVariable("901943bf-7b7f-4261-ac7c-aa376a94869a")]
        public string saveButtonEnabled
        {
            get { return _saveButtonEnabled; }
            set { _saveButtonEnabled = value; }
        }

        string _disableAllButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable disableAllButtonEnabled.
        /// </summary>
        [TestVariable("e46b24c4-dde7-4e6c-bdfc-f0203986a7fc")]
        public string disableAllButtonEnabled
        {
            get { return _disableAllButtonEnabled; }
            set { _disableAllButtonEnabled = value; }
        }

        string _okButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable okButtonEnabled.
        /// </summary>
        [TestVariable("25499352-e770-456e-8ec6-38bc8542d18f")]
        public string okButtonEnabled
        {
            get { return _okButtonEnabled; }
            set { _okButtonEnabled = value; }
        }

        string _applyButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable applyButtonEnabled.
        /// </summary>
        [TestVariable("dcd2420e-e6ec-4bc3-a33c-ea3507534c1e")]
        public string applyButtonEnabled
        {
            get { return _applyButtonEnabled; }
            set { _applyButtonEnabled = value; }
        }

        string _resetButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable resetButtonEnabled.
        /// </summary>
        [TestVariable("280a0bf8-11ee-4458-a3e1-9c57647f6be3")]
        public string resetButtonEnabled
        {
            get { return _resetButtonEnabled; }
            set { _resetButtonEnabled = value; }
        }

        string _cancelButtonEnabled;

        /// <summary>
        /// Gets or sets the value of variable cancelButtonEnabled.
        /// </summary>
        [TestVariable("566d4881-75fa-49dc-abdd-91fda4217f2d")]
        public string cancelButtonEnabled
        {
            get { return _cancelButtonEnabled; }
            set { _cancelButtonEnabled = value; }
        }

        string _closePTCConfigurationForm;

        /// <summary>
        /// Gets or sets the value of variable closePTCConfigurationForm.
        /// </summary>
        [TestVariable("0cb030ad-aeda-4bf0-9077-61e535fd86f6")]
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

            UserCodeCollections.NS_PTC_Configuration.ValidateDistrictConfigurationTabButtonsState(ValueConverter.ArgumentFromString<bool>("loadButtonEnabled", loadButtonEnabled), ValueConverter.ArgumentFromString<bool>("saveButtonEnabled", saveButtonEnabled), ValueConverter.ArgumentFromString<bool>("disableAllButtonEnabled", disableAllButtonEnabled), ValueConverter.ArgumentFromString<bool>("okButtonEnabled", okButtonEnabled), ValueConverter.ArgumentFromString<bool>("applyButtonEnabled", applyButtonEnabled), ValueConverter.ArgumentFromString<bool>("resetButtonEnabled", resetButtonEnabled), ValueConverter.ArgumentFromString<bool>("cancelButtonEnabled", cancelButtonEnabled), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closePTCConfigurationForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
