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
    ///The ConfigurePTCDistrictsMonitor_NS recording.
    /// </summary>
    [TestModule("b0277e01-baf1-4ba3-bf94-4a777a4cb380", ModuleType.Recording, 1)]
    public partial class ConfigurePTCDistrictsMonitor_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ConfigurePTCDistrictsMonitor_NS instance = new ConfigurePTCDistrictsMonitor_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigurePTCDistrictsMonitor_NS()
        {
            division = "";
            districts = "";
            clickApply = "True";
            enablePTCMessages = "False";
            closePTCConfigurationForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConfigurePTCDistrictsMonitor_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("5f6009f6-6c42-4fc7-96c6-3b4a0623b8e3")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _districts;

        /// <summary>
        /// Gets or sets the value of variable districts.
        /// </summary>
        [TestVariable("efcc14a8-3333-45e6-b5b3-9c02afae04c6")]
        public string districts
        {
            get { return _districts; }
            set { _districts = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("1794b678-90bc-4de1-b8f2-1a1bdacca77c")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _enablePTCMessages;

        /// <summary>
        /// Gets or sets the value of variable enablePTCMessages.
        /// </summary>
        [TestVariable("6e660e68-1c0f-4b4f-aa18-5643cffaefa3")]
        public string enablePTCMessages
        {
            get { return _enablePTCMessages; }
            set { _enablePTCMessages = value; }
        }

        string _closePTCConfigurationForm;

        /// <summary>
        /// Gets or sets the value of variable closePTCConfigurationForm.
        /// </summary>
        [TestVariable("2c7cd4fc-6f2c-4e8e-80b1-2cdce6ad114d")]
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

            UserCodeCollections.NS_PTC_Configuration.NS_ConfigurePTCDistricts(division, districts, "Monitor", ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("enablePTCMessages", enablePTCMessages), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closePTCConfigurationForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
