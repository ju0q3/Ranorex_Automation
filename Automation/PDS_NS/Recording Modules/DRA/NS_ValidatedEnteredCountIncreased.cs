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
    ///The NS_ValidatedEnteredCountIncreased recording.
    /// </summary>
    [TestModule("4a6dd16c-6b47-4fb0-a77d-da31e57a439e", ModuleType.Recording, 1)]
    public partial class NS_ValidatedEnteredCountIncreased : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidatedEnteredCountIncreased instance = new NS_ValidatedEnteredCountIncreased();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidatedEnteredCountIncreased()
        {
            draName = "";
            enteredCount = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidatedEnteredCountIncreased Instance
        {
            get { return instance; }
        }

#region Variables

        string _draName;

        /// <summary>
        /// Gets or sets the value of variable draName.
        /// </summary>
        [TestVariable("8c3a230f-5157-4615-9263-40d235ed4fec")]
        public string draName
        {
            get { return _draName; }
            set { _draName = value; }
        }

        string _enteredCount;

        /// <summary>
        /// Gets or sets the value of variable enteredCount.
        /// </summary>
        [TestVariable("ac7ef7d5-37ea-432c-a951-721cb0eb91b5")]
        public string enteredCount
        {
            get { return _enteredCount; }
            set { _enteredCount = value; }
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

            UserCodeCollections.NS_DRA.NS_ValidatedDRAEnteredCountIncreased(draName, enteredCount);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}