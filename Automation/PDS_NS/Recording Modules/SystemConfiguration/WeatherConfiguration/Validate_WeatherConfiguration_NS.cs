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

namespace PDS_NS.Recording_Modules.SystemConfiguration.WeatherConfiguration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Validate_WeatherConfiguration_NS recording.
    /// </summary>
    [TestModule("b21497bb-ecfc-4ac8-98dd-e35833985a3c", ModuleType.Recording, 1)]
    public partial class Validate_WeatherConfiguration_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_WeatherConfiguration_NS instance = new Validate_WeatherConfiguration_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_WeatherConfiguration_NS()
        {
            division = "";
            expStationName = "";
            expWeatherReporting = "true";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_WeatherConfiguration_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("7852e8a0-7a1e-4288-9bab-160147e7243e")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _expStationName;

        /// <summary>
        /// Gets or sets the value of variable expStationName.
        /// </summary>
        [TestVariable("90921e40-b4b9-4a1b-96fa-443e14d4bd03")]
        public string expStationName
        {
            get { return _expStationName; }
            set { _expStationName = value; }
        }

        string _expWeatherReporting;

        /// <summary>
        /// Gets or sets the value of variable expWeatherReporting.
        /// </summary>
        [TestVariable("025e1bf8-71cc-4166-9a2e-5b55aab3aab4")]
        public string expWeatherReporting
        {
            get { return _expWeatherReporting; }
            set { _expWeatherReporting = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("83624d41-ba8c-4520-a5f8-780055162007")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateWeatherConfiguration(division, expStationName, expWeatherReporting, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
