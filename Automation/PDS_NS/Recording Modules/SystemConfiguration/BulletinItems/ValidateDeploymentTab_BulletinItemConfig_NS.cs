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
    ///The ValidateDeploymentTab_BulletinItemConfig_NS recording.
    /// </summary>
    [TestModule("7aea891c-5a22-4bc9-93e5-3893e03ff6f2", ModuleType.Recording, 1)]
    public partial class ValidateDeploymentTab_BulletinItemConfig_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static ValidateDeploymentTab_BulletinItemConfig_NS instance = new ValidateDeploymentTab_BulletinItemConfig_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDeploymentTab_BulletinItemConfig_NS()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDeploymentTab_BulletinItemConfig_NS Instance
        {
            get { return instance; }
        }

#region Variables

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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.Deployment' at Center.", repo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.DeploymentInfo, new RecordItemIndex(0));
            repo.Bulletin_Item_Type_Configuration.BulletinItemTypeConfigurationTabs.Deployment.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='FALSE') on item 'Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBox'.", repo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBoxInfo, new RecordItemIndex(1));
            Validate.AttributeEqual(repo.Bulletin_Item_Type_Configuration.Deployment.DispatcherViewEnabledCheckBoxInfo, "Enabled", "FALSE");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='FALSE') on item 'Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBox'.", repo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBoxInfo, new RecordItemIndex(2));
            Validate.AttributeEqual(repo.Bulletin_Item_Type_Configuration.Deployment.PTCTransferEnabledCheckBoxInfo, "Enabled", "FALSE");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}