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

namespace Oracle.Recording_Modules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The MPDM_RemoveExtendFromLocationDistance recording.
    /// </summary>
    [TestModule("456400de-9a89-48e7-ac38-9e61b909df48", ModuleType.Recording, 1)]
    public partial class MPDM_RemoveExtendFromLocationDistance : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::Oracle.OracleRepository repository.
        /// </summary>
        public static global::Oracle.OracleRepository repo = global::Oracle.OracleRepository.Instance;

        static MPDM_RemoveExtendFromLocationDistance instance = new MPDM_RemoveExtendFromLocationDistance();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public MPDM_RemoveExtendFromLocationDistance()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static MPDM_RemoveExtendFromLocationDistance Instance
        {
            get { return instance; }
        }

#region Variables

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

            Code_Utils.MPDMEnvironment.RemoveMPDMEntry("SUGGESTION_CONFIG", "KEY", "extendFromLocationDistance");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
