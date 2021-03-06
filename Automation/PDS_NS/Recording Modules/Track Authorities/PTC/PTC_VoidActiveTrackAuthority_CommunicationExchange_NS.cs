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

namespace PDS_NS.Recording_Modules.Track_Authorities.PTC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PTC_VoidActiveTrackAuthority_CommunicationExchange_NS recording.
    /// </summary>
    [TestModule("fe66727a-850f-47f6-8703-f683e5690b2b", ModuleType.Recording, 1)]
    public partial class PTC_VoidActiveTrackAuthority_CommunicationExchange_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static PTC_VoidActiveTrackAuthority_CommunicationExchange_NS instance = new PTC_VoidActiveTrackAuthority_CommunicationExchange_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PTC_VoidActiveTrackAuthority_CommunicationExchange_NS()
        {
            releaseBy = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PTC_VoidActiveTrackAuthority_CommunicationExchange_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _releaseBy;

        /// <summary>
        /// Gets or sets the value of variable releaseBy.
        /// </summary>
        [TestVariable("9dc44e3d-e535-4f4b-8d81-033990ee0f27")]
        public string releaseBy
        {
            get { return _releaseBy; }
            set { _releaseBy = value; }
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

            UserCodeCollections.NS_Authorities.PTC_VoidActiveTrackAuthority_CommunicationExchange(releaseBy);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
