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
    ///The RevalidateIssueAuthorityForm recording.
    /// </summary>
    [TestModule("f46b81e3-abad-46e8-8db9-5d33c14c8a1b", ModuleType.Recording, 1)]
    public partial class RevalidateIssueAuthorityForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static RevalidateIssueAuthorityForm instance = new RevalidateIssueAuthorityForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RevalidateIssueAuthorityForm()
        {
            issueAuthorityCopiedBy = "";
            issueAuthorityRelayingEmployee = "";
            issueAuthorityAt = "";
            issueAuthorityPTCVoice = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static RevalidateIssueAuthorityForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _issueAuthorityCopiedBy;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityCopiedBy.
        /// </summary>
        [TestVariable("38ccd208-dba6-4e40-ad83-4c09504356b3")]
        public string issueAuthorityCopiedBy
        {
            get { return _issueAuthorityCopiedBy; }
            set { _issueAuthorityCopiedBy = value; }
        }

        string _issueAuthorityRelayingEmployee;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityRelayingEmployee.
        /// </summary>
        [TestVariable("1f76ab95-f2ce-4347-a4d8-33d9f75cc513")]
        public string issueAuthorityRelayingEmployee
        {
            get { return _issueAuthorityRelayingEmployee; }
            set { _issueAuthorityRelayingEmployee = value; }
        }

        string _issueAuthorityAt;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityAt.
        /// </summary>
        [TestVariable("3feb3fb9-06dc-494d-9647-e02c31579c9e")]
        public string issueAuthorityAt
        {
            get { return _issueAuthorityAt; }
            set { _issueAuthorityAt = value; }
        }

        string _issueAuthorityPTCVoice;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityPTCVoice.
        /// </summary>
        [TestVariable("2d7c7d15-6fab-48a8-b10b-762cd7972f06")]
        public string issueAuthorityPTCVoice
        {
            get { return _issueAuthorityPTCVoice; }
            set { _issueAuthorityPTCVoice = value; }
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

            PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.Create_Track_Authority.RibbonMenu.RevalidateInfo, repo.Create_Track_Authority.Revalidate_Warning.SelfInfo);
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.clickItemIfItExists(repo.Create_Track_Authority.Revalidate_Warning.YesButtonInfo);
            Delay.Milliseconds(0);
            
            PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.Create_Track_Authority.IssueButtonInfo, repo.Communications_Exchange_Ok_Authority.ContinueButtonInfo);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_Authorities.CompleteAuthorityIssue(issueAuthorityCopiedBy, issueAuthorityRelayingEmployee, issueAuthorityAt, ValueConverter.ArgumentFromString<bool>("issueAuthorityPTCVoice", "False"));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
