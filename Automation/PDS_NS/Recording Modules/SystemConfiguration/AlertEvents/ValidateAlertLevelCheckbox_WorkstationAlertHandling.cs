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

namespace PDS_NS.Recording_Modules.SystemConfiguration.AlertEvents
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateAlertLevelCheckbox_WorkstationAlertHandling recording.
    /// </summary>
    [TestModule("932ac487-c486-4846-8cd5-ace82172294d", ModuleType.Recording, 1)]
    public partial class ValidateAlertLevelCheckbox_WorkstationAlertHandling : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateAlertLevelCheckbox_WorkstationAlertHandling instance = new ValidateAlertLevelCheckbox_WorkstationAlertHandling();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateAlertLevelCheckbox_WorkstationAlertHandling()
        {
            alertEventNumber = "0";
            userType = "";
            alertLevel = "";
            closeForms = "False";
            validateIsChecked = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateAlertLevelCheckbox_WorkstationAlertHandling Instance
        {
            get { return instance; }
        }

#region Variables

        string _alertEventNumber;

        /// <summary>
        /// Gets or sets the value of variable alertEventNumber.
        /// </summary>
        [TestVariable("44acf324-07db-42eb-a161-25e7db74908b")]
        public string alertEventNumber
        {
            get { return _alertEventNumber; }
            set { _alertEventNumber = value; }
        }

        string _userType;

        /// <summary>
        /// Gets or sets the value of variable userType.
        /// </summary>
        [TestVariable("758dcc1f-c026-450c-aca9-5c15db5b77c6")]
        public string userType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        string _alertLevel;

        /// <summary>
        /// Gets or sets the value of variable alertLevel.
        /// </summary>
        [TestVariable("72ede89a-f1c7-4847-b650-355770b33998")]
        public string alertLevel
        {
            get { return _alertLevel; }
            set { _alertLevel = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("5f2cf90a-a524-4e79-adfe-08a3913997dc")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _validateIsChecked;

        /// <summary>
        /// Gets or sets the value of variable validateIsChecked.
        /// </summary>
        [TestVariable("14a62a9a-866f-4e60-a358-e93467903fb2")]
        public string validateIsChecked
        {
            get { return _validateIsChecked; }
            set { _validateIsChecked = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateAlertLevelCheckbox_WorkstationAlertHandling(ValueConverter.ArgumentFromString<int>("alertEventNumber", alertEventNumber), userType, alertLevel, ValueConverter.ArgumentFromString<bool>("validateIsChecked", validateIsChecked), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
