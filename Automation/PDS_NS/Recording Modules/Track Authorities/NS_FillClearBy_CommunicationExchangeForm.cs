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
    ///The NS_FillClearBy_CommunicationExchangeForm recording.
    /// </summary>
    [TestModule("8715c0a4-ebbf-4e8b-8e41-a75202c38a4a", ModuleType.Recording, 1)]
    public partial class NS_FillClearBy_CommunicationExchangeForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_FillClearBy_CommunicationExchangeForm instance = new NS_FillClearBy_CommunicationExchangeForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_FillClearBy_CommunicationExchangeForm()
        {
            authoritySeed = "";
            copiedBy = "";
            expectedFeedback = "";
            clickYes = "True";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_FillClearBy_CommunicationExchangeForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("2b72cbc4-b9db-49e1-959f-5b73052ddd2e")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _copiedBy;

        /// <summary>
        /// Gets or sets the value of variable copiedBy.
        /// </summary>
        [TestVariable("3da1c052-0e46-4bda-86a8-48dabcb87261")]
        public string copiedBy
        {
            get { return _copiedBy; }
            set { _copiedBy = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("2d1676ae-0669-4623-ad61-4c89651b9d6d")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _clickYes;

        /// <summary>
        /// Gets or sets the value of variable clickYes.
        /// </summary>
        [TestVariable("7143f023-8af2-412d-9ae4-ece172e7a5be")]
        public string clickYes
        {
            get { return _clickYes; }
            set { _clickYes = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("2fb8a449-fec6-4234-a1a0-0bb2783df621")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_Authorities.NS_Fill_ClearByField_CommunicationExchangeForm(authoritySeed, copiedBy, expectedFeedback, ValueConverter.ArgumentFromString<bool>("clickYes", clickYes), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
