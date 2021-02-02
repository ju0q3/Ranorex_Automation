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

namespace PDS_CORE.Recording_Modules.Signaling.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Validate_Stop_Signal recording.
    /// </summary>
    [TestModule("4d2492ce-f004-4377-a0fd-add8a364ca00", ModuleType.Recording, 1)]
    public partial class Validate_Stop_Signal : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static Validate_Stop_Signal instance = new Validate_Stop_Signal();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_Stop_Signal()
        {
            window = "Desk 05: McComb 1-CrstlSprngs";
            tdmsId = "500161";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_Stop_Signal Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable window.
        /// </summary>
        [TestVariable("535ddb58-5987-48ed-ab3b-d10e70481d2c")]
        public string window
        {
            get { return repo.window; }
            set { repo.window = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable tdmsId.
        /// </summary>
        [TestVariable("491947d3-9813-4e5e-b535-ad3ff8de01cc")]
        public string tdmsId
        {
            get { return repo.tdmsID; }
            set { repo.tdmsID = value; }
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

            Code_Utils.Signaling.StopSignalValidate(window, tdmsId);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
