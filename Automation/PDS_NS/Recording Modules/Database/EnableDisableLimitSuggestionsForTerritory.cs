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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The EnableDisableLimitSuggestionsForTerritory recording.
    /// </summary>
    [TestModule("01451053-541e-46c3-9e5e-f4995bf24090", ModuleType.Recording, 1)]
    public partial class EnableDisableLimitSuggestionsForTerritory : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static EnableDisableLimitSuggestionsForTerritory instance = new EnableDisableLimitSuggestionsForTerritory();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EnableDisableLimitSuggestionsForTerritory()
        {
            territory = "South End";
            enable = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EnableDisableLimitSuggestionsForTerritory Instance
        {
            get { return instance; }
        }

#region Variables

        string _territory;

        /// <summary>
        /// Gets or sets the value of variable territory.
        /// </summary>
        [TestVariable("09dc5333-4a94-4dad-9443-6b4db1463c45")]
        public string territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        string _enable;

        /// <summary>
        /// Gets or sets the value of variable enable.
        /// </summary>
        [TestVariable("824f2e1f-29bc-4fab-9279-37414fcb5400")]
        public string enable
        {
            get { return _enable; }
            set { _enable = value; }
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

            UserCodeCollections.NS_Tasks.NS_EnableDisableLimitSuggestionsForTerritory(territory, ValueConverter.ArgumentFromString<bool>("enable", enable));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
