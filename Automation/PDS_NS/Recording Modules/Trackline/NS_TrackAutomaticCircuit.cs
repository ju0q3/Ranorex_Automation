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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_TrackAutomaticCircuit recording.
    /// </summary>
    [TestModule("ca0d4ed5-440e-4254-a098-848139cb41a0", ModuleType.Recording, 1)]
    public partial class NS_TrackAutomaticCircuit : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.Trackline_Repo repository.
        /// </summary>
        public static global::PDS_NS.Trackline_Repo repo = global::PDS_NS.Trackline_Repo.Instance;

        static NS_TrackAutomaticCircuit instance = new NS_TrackAutomaticCircuit();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_TrackAutomaticCircuit()
        {
            TrackSectionId = "41402";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_TrackAutomaticCircuit Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable TrackSectionId.
        /// </summary>
        [TestVariable("b6a68d15-fee3-4523-88eb-7f65907ab915")]
        public string TrackSectionId
        {
            get { return repo.TrackSectionId; }
            set { repo.TrackSectionId = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.3")]
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
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.3")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            PDS_CORE.Code_Utils.GeneralUtilities.RightClickAndWaitForWithRetry(repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectInfo, repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Automatic.SelfInfo);
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Automatic.SelfInfo, repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Automatic.CircuitsInfo);
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(repo.Trackline_Form_By_TrackSection_Id.TrackSectionObjectMenu.Automatic.CircuitsInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}