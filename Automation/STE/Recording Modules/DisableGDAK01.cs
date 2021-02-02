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

namespace STE.Recording_Modules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DisableGDAK01 recording.
    /// </summary>
    [TestModule("c61cb32c-8c8b-4c20-8345-430b464417a6", ModuleType.Recording, 1)]
    public partial class DisableGDAK01 : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::STE.STERepository repository.
        /// </summary>
        public static global::STE.STERepository repo = global::STE.STERepository.Instance;

        static DisableGDAK01 instance = new DisableGDAK01();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DisableGDAK01()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DisableGDAK01 Instance
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

            PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.FormTestInterface.SettingsInfo, repo.FormTestInterface.TIAutoAcknowledage.SelfInfo);
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.UnCheckCheckboxAdapterAndVerify(repo.FormTestInterface.TIAutoAcknowledage.CheckBoxGDInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
