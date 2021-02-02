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
    ///The NS_VoidAuthorityFromTrackLine recording.
    /// </summary>
    [TestModule("e75c3165-efb5-4040-8c01-90682409ddd0", ModuleType.Recording, 1)]
    public partial class NS_VoidAuthorityFromTrackLine : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_VoidAuthorityFromTrackLine instance = new NS_VoidAuthorityFromTrackLine();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_VoidAuthorityFromTrackLine()
        {
            authoritySeed = "";
            jointOccupantsValue = "";
            extendTime = "";
            clearByPerson = "";
            expectedFeedback = "";
            updateBtn = "FALSE";
            clearBtn = "FALSE";
            closeBtn = "FALSE";
            cancelBtn = "FALSE";
            expNotificationsPopupHeader = "";
            expNotificationsPopupText = "";
            notificationPopupValue = "";
            expRNCPopupHeader = "";
            expRNCPopupText = "";
            releaserNotCopierPopupValue = "";
            issueAuthorityPTCVoice = "FALSE";
            completeAcknowledge = "FALSE";
            closeForms = "FALSE";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_VoidAuthorityFromTrackLine Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("3d475f3e-17f1-450e-9a17-eca909020e7b")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _jointOccupantsValue;

        /// <summary>
        /// Gets or sets the value of variable jointOccupantsValue.
        /// </summary>
        [TestVariable("acfebc15-4563-4447-818c-f6e9c9545c5b")]
        public string jointOccupantsValue
        {
            get { return _jointOccupantsValue; }
            set { _jointOccupantsValue = value; }
        }

        string _extendTime;

        /// <summary>
        /// Gets or sets the value of variable extendTime.
        /// </summary>
        [TestVariable("4da5be90-9500-42d0-970a-8ce20aa22f58")]
        public string extendTime
        {
            get { return _extendTime; }
            set { _extendTime = value; }
        }

        string _clearByPerson;

        /// <summary>
        /// Gets or sets the value of variable clearByPerson.
        /// </summary>
        [TestVariable("89fbed5d-0749-4754-b9db-9b22a8b6e016")]
        public string clearByPerson
        {
            get { return _clearByPerson; }
            set { _clearByPerson = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("2479c99a-aa31-45a7-82ac-cfd5f2e0f97d")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _updateBtn;

        /// <summary>
        /// Gets or sets the value of variable updateBtn.
        /// </summary>
        [TestVariable("5d39e38d-f330-40a9-bd83-c2a481890634")]
        public string updateBtn
        {
            get { return _updateBtn; }
            set { _updateBtn = value; }
        }

        string _clearBtn;

        /// <summary>
        /// Gets or sets the value of variable clearBtn.
        /// </summary>
        [TestVariable("6ae525a2-e39a-49be-acb1-9881b460dbd2")]
        public string clearBtn
        {
            get { return _clearBtn; }
            set { _clearBtn = value; }
        }

        string _closeBtn;

        /// <summary>
        /// Gets or sets the value of variable closeBtn.
        /// </summary>
        [TestVariable("1f1baa1b-152e-4afb-99d2-ca83133658bb")]
        public string closeBtn
        {
            get { return _closeBtn; }
            set { _closeBtn = value; }
        }

        string _cancelBtn;

        /// <summary>
        /// Gets or sets the value of variable cancelBtn.
        /// </summary>
        [TestVariable("08191138-b034-43cb-8d39-6d9b75488c6f")]
        public string cancelBtn
        {
            get { return _cancelBtn; }
            set { _cancelBtn = value; }
        }

        string _expNotificationsPopupHeader;

        /// <summary>
        /// Gets or sets the value of variable expNotificationsPopupHeader.
        /// </summary>
        [TestVariable("96f59fa8-0c63-4a59-bd3b-3c079c7230e0")]
        public string expNotificationsPopupHeader
        {
            get { return _expNotificationsPopupHeader; }
            set { _expNotificationsPopupHeader = value; }
        }

        string _expNotificationsPopupText;

        /// <summary>
        /// Gets or sets the value of variable expNotificationsPopupText.
        /// </summary>
        [TestVariable("5c4b9cde-fc37-4701-921e-98833997d6a0")]
        public string expNotificationsPopupText
        {
            get { return _expNotificationsPopupText; }
            set { _expNotificationsPopupText = value; }
        }

        string _notificationPopupValue;

        /// <summary>
        /// Gets or sets the value of variable notificationPopupValue.
        /// </summary>
        [TestVariable("833e6dce-8958-4ce8-8936-b6e0d323599f")]
        public string notificationPopupValue
        {
            get { return _notificationPopupValue; }
            set { _notificationPopupValue = value; }
        }

        string _expRNCPopupHeader;

        /// <summary>
        /// Gets or sets the value of variable expRNCPopupHeader.
        /// </summary>
        [TestVariable("3d358aff-9589-4b88-91e2-99da780137c4")]
        public string expRNCPopupHeader
        {
            get { return _expRNCPopupHeader; }
            set { _expRNCPopupHeader = value; }
        }

        string _expRNCPopupText;

        /// <summary>
        /// Gets or sets the value of variable expRNCPopupText.
        /// </summary>
        [TestVariable("722b4321-7b91-42f8-bcf3-8f29a513f8a4")]
        public string expRNCPopupText
        {
            get { return _expRNCPopupText; }
            set { _expRNCPopupText = value; }
        }

        string _releaserNotCopierPopupValue;

        /// <summary>
        /// Gets or sets the value of variable releaserNotCopierPopupValue.
        /// </summary>
        [TestVariable("92bade6b-2353-4ba7-b922-0568a0daf202")]
        public string releaserNotCopierPopupValue
        {
            get { return _releaserNotCopierPopupValue; }
            set { _releaserNotCopierPopupValue = value; }
        }

        string _issueAuthorityPTCVoice;

        /// <summary>
        /// Gets or sets the value of variable issueAuthorityPTCVoice.
        /// </summary>
        [TestVariable("bedffc60-1bf4-4f16-b170-3529f36aa3aa")]
        public string issueAuthorityPTCVoice
        {
            get { return _issueAuthorityPTCVoice; }
            set { _issueAuthorityPTCVoice = value; }
        }

        string _completeAcknowledge;

        /// <summary>
        /// Gets or sets the value of variable completeAcknowledge.
        /// </summary>
        [TestVariable("d177470e-3555-4b83-bb2b-b01b60b68b7e")]
        public string completeAcknowledge
        {
            get { return _completeAcknowledge; }
            set { _completeAcknowledge = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("0c4e6ffc-3a70-4268-8dfe-b8b76ee9510c")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_Authorities.VoidAuthorityWithAllFlows(authoritySeed, "TrackLine", jointOccupantsValue, extendTime, clearByPerson, expectedFeedback, ValueConverter.ArgumentFromString<bool>("updateBtn", updateBtn), ValueConverter.ArgumentFromString<bool>("clearBtn", clearBtn), ValueConverter.ArgumentFromString<bool>("closeBtn", closeBtn), ValueConverter.ArgumentFromString<bool>("cancelBtn", cancelBtn), expNotificationsPopupHeader, expNotificationsPopupText, notificationPopupValue, expRNCPopupHeader, expRNCPopupText, releaserNotCopierPopupValue, ValueConverter.ArgumentFromString<bool>("issueAuthorityPTCVoice", issueAuthorityPTCVoice), ValueConverter.ArgumentFromString<bool>("completeAcknowledge", completeAcknowledge), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}