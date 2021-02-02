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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The validateTrackline_MenuOptions_Enabled_or_Disabled recording.
    /// </summary>
    [TestModule("d28b66ab-6dba-457a-a89e-39e2c6cfaa92", ModuleType.Recording, 1)]
    public partial class validateTrackline_MenuOptions_Enabled_or_Disabled : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static validateTrackline_MenuOptions_Enabled_or_Disabled instance = new validateTrackline_MenuOptions_Enabled_or_Disabled();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTrackline_MenuOptions_Enabled_or_Disabled()
        {
            trackSectionId = "";
            isAutomaticEnabled = "";
            isManualEnabled = "";
            isRREnabled = "";
            isRemoveSignalAuthorityEnabled = "";
            isPlaceTagEnabled = "";
            isIssueTrainOREngineTrackAuthorityEnabled = "";
            isDBPropertyEnabled = "";
            isGetOrderOfTrainsEnabled = "";
            isPendingActivitySummaryEnabled = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static validateTrackline_MenuOptions_Enabled_or_Disabled Instance
        {
            get { return instance; }
        }

#region Variables

        string _trackSectionId;

        /// <summary>
        /// Gets or sets the value of variable trackSectionId.
        /// </summary>
        [TestVariable("b637cb44-ae1e-44a4-a771-426ad278741f")]
        public string trackSectionId
        {
            get { return _trackSectionId; }
            set { _trackSectionId = value; }
        }

        string _isAutomaticEnabled;

        /// <summary>
        /// Gets or sets the value of variable isAutomaticEnabled.
        /// </summary>
        [TestVariable("3ae047a6-c71a-4612-8bff-c0ffdb74a486")]
        public string isAutomaticEnabled
        {
            get { return _isAutomaticEnabled; }
            set { _isAutomaticEnabled = value; }
        }

        string _isManualEnabled;

        /// <summary>
        /// Gets or sets the value of variable isManualEnabled.
        /// </summary>
        [TestVariable("d80f6359-6a0d-4def-8887-cdaf25e58f3c")]
        public string isManualEnabled
        {
            get { return _isManualEnabled; }
            set { _isManualEnabled = value; }
        }

        string _isRREnabled;

        /// <summary>
        /// Gets or sets the value of variable isRREnabled.
        /// </summary>
        [TestVariable("df0d4cc3-ccc1-4311-b067-b8663bdc1c68")]
        public string isRREnabled
        {
            get { return _isRREnabled; }
            set { _isRREnabled = value; }
        }

        string _isRemoveSignalAuthorityEnabled;

        /// <summary>
        /// Gets or sets the value of variable isRemoveSignalAuthorityEnabled.
        /// </summary>
        [TestVariable("569638b7-b39f-4b74-bf9b-ad351f7b977c")]
        public string isRemoveSignalAuthorityEnabled
        {
            get { return _isRemoveSignalAuthorityEnabled; }
            set { _isRemoveSignalAuthorityEnabled = value; }
        }

        string _isPlaceTagEnabled;

        /// <summary>
        /// Gets or sets the value of variable isPlaceTagEnabled.
        /// </summary>
        [TestVariable("4e012b9a-f5f3-4eba-ad57-b97e0853e984")]
        public string isPlaceTagEnabled
        {
            get { return _isPlaceTagEnabled; }
            set { _isPlaceTagEnabled = value; }
        }

        string _isIssueTrainOREngineTrackAuthorityEnabled;

        /// <summary>
        /// Gets or sets the value of variable isIssueTrainOREngineTrackAuthorityEnabled.
        /// </summary>
        [TestVariable("1882abc3-1f45-4788-a9ce-9bf2997f4b5b")]
        public string isIssueTrainOREngineTrackAuthorityEnabled
        {
            get { return _isIssueTrainOREngineTrackAuthorityEnabled; }
            set { _isIssueTrainOREngineTrackAuthorityEnabled = value; }
        }

        string _isDBPropertyEnabled;

        /// <summary>
        /// Gets or sets the value of variable isDBPropertyEnabled.
        /// </summary>
        [TestVariable("f4ddb5b6-f190-404b-acfa-63dfe8d2cc57")]
        public string isDBPropertyEnabled
        {
            get { return _isDBPropertyEnabled; }
            set { _isDBPropertyEnabled = value; }
        }

        string _isGetOrderOfTrainsEnabled;

        /// <summary>
        /// Gets or sets the value of variable isGetOrderOfTrainsEnabled.
        /// </summary>
        [TestVariable("6519e921-90fd-4214-82ec-72e5c138bcba")]
        public string isGetOrderOfTrainsEnabled
        {
            get { return _isGetOrderOfTrainsEnabled; }
            set { _isGetOrderOfTrainsEnabled = value; }
        }

        string _isPendingActivitySummaryEnabled;

        /// <summary>
        /// Gets or sets the value of variable isPendingActivitySummaryEnabled.
        /// </summary>
        [TestVariable("4c3fbe46-089d-4ddc-90d8-98c30bec5855")]
        public string isPendingActivitySummaryEnabled
        {
            get { return _isPendingActivitySummaryEnabled; }
            set { _isPendingActivitySummaryEnabled = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_validateTrackline_MenuOptions_Enabled_or_Disabled(trackSectionId, isAutomaticEnabled, isManualEnabled, isRREnabled, isRemoveSignalAuthorityEnabled, isPlaceTagEnabled, isIssueTrainOREngineTrackAuthorityEnabled, isDBPropertyEnabled, isGetOrderOfTrainsEnabled, isPendingActivitySummaryEnabled);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
