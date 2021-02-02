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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyTrackOptions_NVC recording.
    /// </summary>
    [TestModule("b103ef77-ccdf-4289-96c2-ceedddeeef16", ModuleType.Recording, 1)]
    public partial class ModifyTrackOptions_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyTrackOptions_NVC instance = new ModifyTrackOptions_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyTrackOptions_NVC()
        {
            doCheckShowFirstOverTrack = "False";
            doCheckShowUnblockableCrossings = "False";
            doCheckShowDisconnectedTracks = "False";
            doCheckCompensateForCrossingsWithGaps = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyTrackOptions_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _doCheckShowFirstOverTrack;

        /// <summary>
        /// Gets or sets the value of variable doCheckShowFirstOverTrack.
        /// </summary>
        [TestVariable("4f9ed820-3bc0-4dca-ae25-d32d7a91b3ca")]
        public string doCheckShowFirstOverTrack
        {
            get { return _doCheckShowFirstOverTrack; }
            set { _doCheckShowFirstOverTrack = value; }
        }

        string _doCheckShowUnblockableCrossings;

        /// <summary>
        /// Gets or sets the value of variable doCheckShowUnblockableCrossings.
        /// </summary>
        [TestVariable("ebd7ffc1-523f-4ade-99ae-f26697fc06e1")]
        public string doCheckShowUnblockableCrossings
        {
            get { return _doCheckShowUnblockableCrossings; }
            set { _doCheckShowUnblockableCrossings = value; }
        }

        string _doCheckShowDisconnectedTracks;

        /// <summary>
        /// Gets or sets the value of variable doCheckShowDisconnectedTracks.
        /// </summary>
        [TestVariable("e2cb7ad5-3bce-4133-b728-0954f0f809d9")]
        public string doCheckShowDisconnectedTracks
        {
            get { return _doCheckShowDisconnectedTracks; }
            set { _doCheckShowDisconnectedTracks = value; }
        }

        string _doCheckCompensateForCrossingsWithGaps;

        /// <summary>
        /// Gets or sets the value of variable doCheckCompensateForCrossingsWithGaps.
        /// </summary>
        [TestVariable("9dae3244-b327-41b3-a2b9-c143b1ee527c")]
        public string doCheckCompensateForCrossingsWithGaps
        {
            get { return _doCheckCompensateForCrossingsWithGaps; }
            set { _doCheckCompensateForCrossingsWithGaps = value; }
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

            UserCodeCollections.NS_NVC.NS_ModifyTrackOptions_NVC(ValueConverter.ArgumentFromString<bool>("doCheckShowFirstOverTrack", doCheckShowFirstOverTrack), ValueConverter.ArgumentFromString<bool>("doCheckShowUnblockableCrossings", doCheckShowUnblockableCrossings), ValueConverter.ArgumentFromString<bool>("doCheckShowDisconnectedTracks", doCheckShowDisconnectedTracks), ValueConverter.ArgumentFromString<bool>("doCheckCompensateForCrossingsWithGaps", doCheckCompensateForCrossingsWithGaps));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
