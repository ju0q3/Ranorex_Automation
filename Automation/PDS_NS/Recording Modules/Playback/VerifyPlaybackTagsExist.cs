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
    ///The VerifyPlaybackTagsExist recording.
    /// </summary>
    [TestModule("1baeefe9-b584-4bbd-8134-8e7230c236f5", ModuleType.Recording, 1)]
    public partial class VerifyPlaybackTagsExist : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static VerifyPlaybackTagsExist instance = new VerifyPlaybackTagsExist();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyPlaybackTagsExist()
        {
            tagType = "";
            ActionPerformed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VerifyPlaybackTagsExist Instance
        {
            get { return instance; }
        }

#region Variables

        string _tagType;

        /// <summary>
        /// Gets or sets the value of variable tagType.
        /// </summary>
        [TestVariable("93f47d0f-ea01-41bf-9ced-2360043c90ac")]
        public string tagType
        {
            get { return _tagType; }
            set { _tagType = value; }
        }

        string _ActionPerformed;

        /// <summary>
        /// Gets or sets the value of variable ActionPerformed.
        /// </summary>
        [TestVariable("424d6467-df69-41be-81d5-a287311e6ef5")]
        public string ActionPerformed
        {
            get { return _ActionPerformed; }
            set { _ActionPerformed = value; }
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

            UserCodeCollections.NS_Playback.NS_VerifyPlaybackTagsExist(tagType, ActionPerformed);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}