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
    ///The ConfigurePTCDistrictsEnabled_NS recording.
    /// </summary>
    [TestModule("b37c47b9-f500-4240-9e1a-61cace1d4b5c", ModuleType.Recording, 1)]
    public partial class ConfigurePTCDistrictsEnabled_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static ConfigurePTCDistrictsEnabled_NS instance = new ConfigurePTCDistrictsEnabled_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigurePTCDistrictsEnabled_NS()
        {
            division = "";
            districts = "";
            enablePTCMessages = "True";
            closePTCConfigurationForm = "False";
            clickApply = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConfigurePTCDistrictsEnabled_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _districts;

        /// <summary>
        /// Gets or sets the value of variable districts.
        /// </summary>
        [TestVariable("dab2ce91-be51-40c1-9c0c-a3aec5745302")]
        public string districts
        {
            get { return _districts; }
            set { _districts = value; }
        }

        string _enablePTCMessages;

        /// <summary>
        /// Gets or sets the value of variable enablePTCMessages.
        /// </summary>
        [TestVariable("cbad04e5-d18f-4456-baad-46329df1416f")]
        public string enablePTCMessages
        {
            get { return _enablePTCMessages; }
            set { _enablePTCMessages = value; }
        }

        string _closePTCConfigurationForm;

        /// <summary>
        /// Gets or sets the value of variable closePTCConfigurationForm.
        /// </summary>
        [TestVariable("819f950a-75d4-46e6-aa67-e4ebf3422170")]
        public string closePTCConfigurationForm
        {
            get { return _closePTCConfigurationForm; }
            set { _closePTCConfigurationForm = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("06009a67-8c71-4b4d-93f0-a397ddb68b9e")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("a3dce1a7-2c99-41f6-b9cd-21e9335dd78e")]
        public string division
        {
            get { return repo.Division; }
            set { repo.Division = value; }
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

            UserCodeCollections.NS_PTC_Configuration.NS_ConfigurePTCDistricts(division, districts, "Enable", ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("enablePTCMessages", enablePTCMessages), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closePTCConfigurationForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
