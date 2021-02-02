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

namespace PDS_NS.Recording_Modules.Playback
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PlaybackGMTTime recording.
    /// </summary>
    [TestModule("0b9a7392-944f-4db1-b928-c3caf92fd804", ModuleType.Recording, 1)]
    public partial class PlaybackGMTTime : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static PlaybackGMTTime instance = new PlaybackGMTTime();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PlaybackGMTTime()
        {
            PlaybackstartTime = "";
            EST = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PlaybackGMTTime Instance
        {
            get { return instance; }
        }

#region Variables

        string _PlaybackstartTime;

        /// <summary>
        /// Gets or sets the value of variable PlaybackstartTime.
        /// </summary>
        [TestVariable("98ee130d-b78a-44fd-82a3-72048a21f401")]
        public string PlaybackstartTime
        {
            get { return _PlaybackstartTime; }
            set { _PlaybackstartTime = value; }
        }

        string _EST;

        /// <summary>
        /// Gets or sets the value of variable EST.
        /// </summary>
        [TestVariable("c2056030-f561-4940-bc2f-28ba9cb8cb06")]
        public string EST
        {
            get { return _EST; }
            set { _EST = value; }
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

            PlaybackstartTime = UserCodeCollections.NS_Playback.NS_PlaybackStatTime(PlaybackstartTime, ValueConverter.ArgumentFromString<bool>("EST", EST));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}