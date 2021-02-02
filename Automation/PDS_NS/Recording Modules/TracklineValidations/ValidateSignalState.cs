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

namespace PDS_NS.Recording_Modules.TracklineValidations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateSignalState recording.
    /// </summary>
    [TestModule("dd96b516-70f6-4022-881d-b22f0cad4ae2", ModuleType.Recording, 1)]
    public partial class ValidateSignalState : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateSignalState instance = new ValidateSignalState();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateSignalState()
        {
            signalId = "";
            validateSignalClear = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateSignalState Instance
        {
            get { return instance; }
        }

#region Variables

        string _signalId;

        /// <summary>
        /// Gets or sets the value of variable signalId.
        /// </summary>
        [TestVariable("3bcc6059-023b-4f99-9baa-011b20aeff0e")]
        public string signalId
        {
            get { return _signalId; }
            set { _signalId = value; }
        }

        string _validateSignalClear;

        /// <summary>
        /// Gets or sets the value of variable validateSignalClear.
        /// </summary>
        [TestVariable("d70d7e63-d5db-4816-80bf-cf699b3bd214")]
        public string validateSignalClear
        {
            get { return _validateSignalClear; }
            set { _validateSignalClear = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ValidateStateOfSignal(signalId, ValueConverter.ArgumentFromString<bool>("validateSignalClear", validateSignalClear));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
