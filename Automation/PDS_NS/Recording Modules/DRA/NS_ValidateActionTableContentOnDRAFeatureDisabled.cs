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

namespace PDS_NS.Recording_Modules.DRA
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ValidateActionTableContentOnDRAFeatureDisabled recording.
    /// </summary>
    [TestModule("a79313c5-fb2d-41d0-8ce4-7ac267efae33", ModuleType.Recording, 1)]
    public partial class NS_ValidateActionTableContentOnDRAFeatureDisabled : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateActionTableContentOnDRAFeatureDisabled instance = new NS_ValidateActionTableContentOnDRAFeatureDisabled();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateActionTableContentOnDRAFeatureDisabled()
        {
            validateProjectedEntries = "False";
            validateEnteredEntries = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateActionTableContentOnDRAFeatureDisabled Instance
        {
            get { return instance; }
        }

#region Variables

        string _validateProjectedEntries;

        /// <summary>
        /// Gets or sets the value of variable validateProjectedEntries.
        /// </summary>
        [TestVariable("af7e1723-b989-4013-8813-a8bd5191b53f")]
        public string validateProjectedEntries
        {
            get { return _validateProjectedEntries; }
            set { _validateProjectedEntries = value; }
        }

        string _validateEnteredEntries;

        /// <summary>
        /// Gets or sets the value of variable validateEnteredEntries.
        /// </summary>
        [TestVariable("08d67f36-39c2-4354-bb23-55f20f696e0c")]
        public string validateEnteredEntries
        {
            get { return _validateEnteredEntries; }
            set { _validateEnteredEntries = value; }
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

            UserCodeCollections.NS_DRA.NS_ValidateDRAFeatureDisabledActionTableContent(ValueConverter.ArgumentFromString<bool>("validateProjectedEntries", validateProjectedEntries), ValueConverter.ArgumentFromString<bool>("validateEnteredEntries", validateEnteredEntries));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}