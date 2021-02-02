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
    ///The DenyAuthority_CommunicationsExchangeForm recording.
    /// </summary>
    [TestModule("304adcec-2a86-4e89-9b95-1243a125a9ff", ModuleType.Recording, 1)]
    public partial class DenyAuthority_CommunicationsExchangeForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DenyAuthority_CommunicationsExchangeForm instance = new DenyAuthority_CommunicationsExchangeForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DenyAuthority_CommunicationsExchangeForm()
        {
            commentsText = "";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DenyAuthority_CommunicationsExchangeForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _commentsText;

        /// <summary>
        /// Gets or sets the value of variable commentsText.
        /// </summary>
        [TestVariable("b25b395c-a5d5-44df-8820-7ee68fd523bd")]
        public string commentsText
        {
            get { return _commentsText; }
            set { _commentsText = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("371d799a-070d-4d23-93c9-5b99625cf2db")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_Authorities.NS_DenyAuthority_CommunicationsExchangeForm(commentsText, expectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
