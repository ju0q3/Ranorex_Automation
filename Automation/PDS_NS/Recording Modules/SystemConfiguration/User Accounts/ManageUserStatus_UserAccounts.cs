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

namespace PDS_NS.Recording_Modules.SystemConfiguration.User_Accounts
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ManageUserStatus_UserAccounts recording.
    /// </summary>
    [TestModule("dbdee5e0-d96a-4175-ac1a-fba75bce65c2", ModuleType.Recording, 1)]
    public partial class ManageUserStatus_UserAccounts : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ManageUserStatus_UserAccounts instance = new ManageUserStatus_UserAccounts();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ManageUserStatus_UserAccounts()
        {
            userId = "sysmgr1";
            activityType = "delete";
            closeForm = "False";
            expectedFeedback = "Operational Database Error. Please retry and if condition repeats, refer to the server system logs. Caught PError: 5006 (15689.0.3110)";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ManageUserStatus_UserAccounts Instance
        {
            get { return instance; }
        }

#region Variables

        string _userId;

        /// <summary>
        /// Gets or sets the value of variable userId.
        /// </summary>
        [TestVariable("3e17e463-c402-40c2-81a9-38d5a6707845")]
        public string userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        string _activityType;

        /// <summary>
        /// Gets or sets the value of variable activityType.
        /// </summary>
        [TestVariable("fc8013c2-3e5a-4da3-86d1-f56957b2141d")]
        public string activityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("dbeb8cdc-8ede-45ae-b7ec-052876c470a1")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("6ccb10fa-8224-42b5-a25c-3d0f65a10712")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ManageUserStatus_UserAccounts(userId, activityType, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
