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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CDMS_UpdateARDispTerrConfig recording.
    /// </summary>
    [TestModule("505919cb-1582-4d1e-9bbc-9d67339394e9", ModuleType.Recording, 1)]
    public partial class CDMS_UpdateARDispTerrConfig : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_UpdateARDispTerrConfig instance = new CDMS_UpdateARDispTerrConfig();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_UpdateARDispTerrConfig()
        {
            dispatchTerrId = "";
            configValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_UpdateARDispTerrConfig Instance
        {
            get { return instance; }
        }

#region Variables

        string _dispatchTerrId;

        /// <summary>
        /// Gets or sets the value of variable dispatchTerrId.
        /// </summary>
        [TestVariable("329d8389-5e38-477e-945b-fdf31398c97f")]
        public string dispatchTerrId
        {
            get { return _dispatchTerrId; }
            set { _dispatchTerrId = value; }
        }

        string _configValue;

        /// <summary>
        /// Gets or sets the value of variable configValue.
        /// </summary>
        [TestVariable("a37617d7-42b7-42f4-8df9-db07e8d724f2")]
        public string configValue
        {
            get { return _configValue; }
            set { _configValue = value; }
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

            Oracle.Code_Utils.CDMSEnvironment.update_AR_Disp_Terr_Config(dispatchTerrId, configValue);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
