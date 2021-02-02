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
    ///The Rollup_Authority_NS recording.
    /// </summary>
    [TestModule("144277ff-9f0a-471c-a26c-8d979dc9da28", ModuleType.Recording, 1)]
    public partial class Rollup_Authority_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Rollup_Authority_NS instance = new Rollup_Authority_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Rollup_Authority_NS()
        {
            Rollup_Location = "";
            authoritySeed = "";
            expectedFeedback = "";
            openFromSummaryList = "True";
            closeForms = "False";
            issueAuthorityPTCVoice = "False";
            pressCancel = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Rollup_Authority_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _Rollup_Location;

        /// <summary>
        /// Gets or sets the value of variable Rollup_Location.
        /// </summary>
        [TestVariable("834dad26-8ce2-4f31-b6c8-0ca8a9b2c818")]
        public string Rollup_Location
        {
            get { return _Rollup_Location; }
            set { _Rollup_Location = value; }
        }

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("16014513-d8a2-48ad-998e-0d7b564e97f6")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("0a079d8f-a504-452a-b854-85d609b12f28")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _openFromSummaryList;

        /// <summary>
        /// Gets or sets the value of variable openFromSummaryList.
        /// </summary>
        [TestVariable("d1e945cd-6743-40a2-a9e9-2c1d5c65ad0c")]
        public string openFromSummaryList
        {
            get { return _openFromSummaryList; }
            set { _openFromSummaryList = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("ce0068b8-0157-407c-9f20-43b6a3c8922a")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _issueAuthorityPTCVoice;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityPTCVoice.
        /// </summary>
        [TestVariable("e4ff6474-d9de-4084-b685-9b21ed6b66e0")]
        public string issueAuthorityPTCVoice
        {
            get { return _issueAuthorityPTCVoice; }
            set { _issueAuthorityPTCVoice = value; }
        }

        string _pressCancel;

        /// <summary>
        /// Gets or sets the value of variable pressCancel.
        /// </summary>
        [TestVariable("c3a0fe8b-a641-425c-96e8-8baa24920406")]
        public string pressCancel
        {
            get { return _pressCancel; }
            set { _pressCancel = value; }
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

            UserCodeCollections.NS_Authorities.NS_Rollup_Authority(Rollup_Location, authoritySeed, expectedFeedback, ValueConverter.ArgumentFromString<bool>("openFromSummaryList", openFromSummaryList), ValueConverter.ArgumentFromString<bool>("issueAuthorityPTCVoice", issueAuthorityPTCVoice), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms), ValueConverter.ArgumentFromString<bool>("pressCancel", pressCancel));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}