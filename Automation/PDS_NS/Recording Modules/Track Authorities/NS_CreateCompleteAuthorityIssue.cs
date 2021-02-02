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
    ///The NS_CreateCompleteAuthorityIssue recording.
    /// </summary>
    [TestModule("c4772b23-9f9d-43f7-8a70-4cafa6f4e20b", ModuleType.Recording, 1)]
    public partial class NS_CreateCompleteAuthorityIssue : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static NS_CreateCompleteAuthorityIssue instance = new NS_CreateCompleteAuthorityIssue();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_CreateCompleteAuthorityIssue()
        {
            copiedBy = "Automation";
            relayingEmployee = "";
            at = "";
            PTC = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_CreateCompleteAuthorityIssue Instance
        {
            get { return instance; }
        }

#region Variables

        string _copiedBy;

        /// <summary>
        /// Gets or sets the value of variable copiedBy.
        /// </summary>
        [TestVariable("9698b9e3-36b8-4e77-9b6e-20387ced4195")]
        public string copiedBy
        {
            get { return _copiedBy; }
            set { _copiedBy = value; }
        }

        string _relayingEmployee;

        /// <summary>
        /// Gets or sets the value of variable relayingEmployee.
        /// </summary>
        [TestVariable("71c64fba-e252-4ca3-b4cf-91175510f714")]
        public string relayingEmployee
        {
            get { return _relayingEmployee; }
            set { _relayingEmployee = value; }
        }

        string _at;

        /// <summary>
        /// Gets or sets the value of variable at.
        /// </summary>
        [TestVariable("d1092967-ca12-4f9c-9596-4d194bbe4eaf")]
        public string at
        {
            get { return _at; }
            set { _at = value; }
        }

        string _PTC;

        /// <summary>
        /// Gets or sets the value of variable PTC.
        /// </summary>
        [TestVariable("215c3e2e-b7ca-43de-a505-a52727a60e29")]
        public string PTC
        {
            get { return _PTC; }
            set { _PTC = value; }
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

            PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.Create_Track_Authority.IssueButtonInfo, repo.Communications_Exchange_Ok_Authority.SelfInfo);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_Authorities.CompleteAuthorityIssue(copiedBy, relayingEmployee, at, ValueConverter.ArgumentFromString<bool>("issueAuthorityPTCVoice", PTC));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
