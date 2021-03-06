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
    ///The EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS recording.
    /// </summary>
    [TestModule("02601254-b505-468e-8afd-df9da0321bb1", ModuleType.Recording, 1)]
    public partial class EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS instance = new EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS()
        {
            division = "";
            districts = "";
            clickApply = "True";
            closePTCConfigurationForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EnableBIAcknowledgmentByDistrict_PTCConfiguration_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("a332b21d-73ee-4bd9-9688-2c875e5c4f9e")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _districts;

        /// <summary>
        /// Gets or sets the value of variable districts.
        /// </summary>
        [TestVariable("7b672e01-02b9-4228-a286-18b432989dba")]
        public string districts
        {
            get { return _districts; }
            set { _districts = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("b91a2bd7-a769-44ee-a9d6-cf409ad7eb35")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closePTCConfigurationForm;

        /// <summary>
        /// Gets or sets the value of variable closePTCConfigurationForm.
        /// </summary>
        [TestVariable("3e922537-1e47-48a1-aa34-c5a1dcc999ca")]
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

            UserCodeCollections.NS_PTC_Configuration.NS_ConfigurePTCDistricts_EnableBIAck(division, districts, ValueConverter.ArgumentFromString<bool>("enableBIAck", "True"), ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closePTCConfigurationForm", closePTCConfigurationForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
