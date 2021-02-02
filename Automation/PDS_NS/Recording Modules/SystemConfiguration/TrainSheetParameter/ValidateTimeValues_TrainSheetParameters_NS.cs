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

namespace PDS_NS.Recording_Modules.SystemConfiguration.TrainSheetParameter
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTimeValues_TrainSheetParameters_NS recording.
    /// </summary>
    [TestModule("bfb2b012-4e73-458f-8c89-b702fe8dff54", ModuleType.Recording, 1)]
    public partial class ValidateTimeValues_TrainSheetParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTimeValues_TrainSheetParameters_NS instance = new ValidateTimeValues_TrainSheetParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTimeValues_TrainSheetParameters_NS()
        {
            exp_TerminateTrainTimeWithCrewTieUp = "";
            exp_TerminateTrainTimeWithoutCrewTieUp = "";
            exp_TerminateTrainTimeWithUnknownTrainLocation = "";
            exp_RemovePlanDataOlderThan = "";
            closeForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTimeValues_TrainSheetParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _exp_TerminateTrainTimeWithCrewTieUp;

        /// <summary>
        /// Gets or sets the value of variable exp_TerminateTrainTimeWithCrewTieUp.
        /// </summary>
        [TestVariable("6d21fc34-1c9d-46c3-a91d-89024b1e96b9")]
        public string exp_TerminateTrainTimeWithCrewTieUp
        {
            get { return _exp_TerminateTrainTimeWithCrewTieUp; }
            set { _exp_TerminateTrainTimeWithCrewTieUp = value; }
        }

        string _exp_TerminateTrainTimeWithoutCrewTieUp;

        /// <summary>
        /// Gets or sets the value of variable exp_TerminateTrainTimeWithoutCrewTieUp.
        /// </summary>
        [TestVariable("94510135-201a-4e27-a51c-6e3c17c28b73")]
        public string exp_TerminateTrainTimeWithoutCrewTieUp
        {
            get { return _exp_TerminateTrainTimeWithoutCrewTieUp; }
            set { _exp_TerminateTrainTimeWithoutCrewTieUp = value; }
        }

        string _exp_TerminateTrainTimeWithUnknownTrainLocation;

        /// <summary>
        /// Gets or sets the value of variable exp_TerminateTrainTimeWithUnknownTrainLocation.
        /// </summary>
        [TestVariable("ee88d7fb-f2d9-422a-8bed-adca60736401")]
        public string exp_TerminateTrainTimeWithUnknownTrainLocation
        {
            get { return _exp_TerminateTrainTimeWithUnknownTrainLocation; }
            set { _exp_TerminateTrainTimeWithUnknownTrainLocation = value; }
        }

        string _exp_RemovePlanDataOlderThan;

        /// <summary>
        /// Gets or sets the value of variable exp_RemovePlanDataOlderThan.
        /// </summary>
        [TestVariable("616f68ba-3670-4f14-ad5d-6be3f3ea57d5")]
        public string exp_RemovePlanDataOlderThan
        {
            get { return _exp_RemovePlanDataOlderThan; }
            set { _exp_RemovePlanDataOlderThan = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("004f73a7-3724-4bd6-b010-f2b9dca4fb77")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateTimeValues_TrainSheetParameters(exp_TerminateTrainTimeWithCrewTieUp, exp_TerminateTrainTimeWithoutCrewTieUp, exp_TerminateTrainTimeWithUnknownTrainLocation, exp_RemovePlanDataOlderThan, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
