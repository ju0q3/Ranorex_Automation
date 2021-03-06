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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ExpandTrackAuthorityForm recording.
    /// </summary>
    [TestModule("fe06ba4c-4540-499d-81bc-2d3897983667", ModuleType.Recording, 1)]
    public partial class NS_ExpandTrackAuthorityForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static NS_ExpandTrackAuthorityForm instance = new NS_ExpandTrackAuthorityForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ExpandTrackAuthorityForm()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ExpandTrackAuthorityForm Instance
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

            PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.Create_Track_Authority.RibbonMenu.LongFormInfo, repo.Create_Track_Authority.Box6.Box6CheckboxInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
