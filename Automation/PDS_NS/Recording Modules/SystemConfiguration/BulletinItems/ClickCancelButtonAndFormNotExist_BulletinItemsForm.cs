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

namespace PDS_NS.Recording_Modules.SystemConfiguration.BulletinItems
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ClickCancelButtonAndFormNotExist_BulletinItemsForm recording.
    /// </summary>
    [TestModule("1f41d1d2-2c2d-45f9-aff5-7eac0885d29c", ModuleType.Recording, 1)]
    public partial class ClickCancelButtonAndFormNotExist_BulletinItemsForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static ClickCancelButtonAndFormNotExist_BulletinItemsForm instance = new ClickCancelButtonAndFormNotExist_BulletinItemsForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClickCancelButtonAndFormNotExist_BulletinItemsForm()
        {
            acknowledgeCancelPopup = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ClickCancelButtonAndFormNotExist_BulletinItemsForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _acknowledgeCancelPopup;

        /// <summary>
        /// Gets or sets the value of variable acknowledgeCancelPopup.
        /// </summary>
        [TestVariable("01cafac5-5db1-4d06-b4f3-9532079c16eb")]
        public string acknowledgeCancelPopup
        {
            get { return _acknowledgeCancelPopup; }
            set { _acknowledgeCancelPopup = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_CancelChangesInBulletinItems(ValueConverter.ArgumentFromString<bool>("acknowledgeCancelPopup", acknowledgeCancelPopup));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
