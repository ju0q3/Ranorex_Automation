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
    ///The CDMS_SetCommonConfiguration_NS recording.
    /// </summary>
    [TestModule("6f1e3b0b-d763-43f4-9202-3fecc56e0f5b", ModuleType.Recording, 1)]
    public partial class CDMS_SetCommonConfiguration_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_SetCommonConfiguration_NS instance = new CDMS_SetCommonConfiguration_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_SetCommonConfiguration_NS()
        {
            configName = "";
            configValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_SetCommonConfiguration_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _configName;

        /// <summary>
        /// Gets or sets the value of variable configName.
        /// </summary>
        [TestVariable("ede58c90-7659-47f7-9713-e797e26bdc89")]
        public string configName
        {
            get { return _configName; }
            set { _configName = value; }
        }

        string _configValue;

        /// <summary>
        /// Gets or sets the value of variable configValue.
        /// </summary>
        [TestVariable("ad6e59a5-34ba-4942-b148-a6f4bd82f077")]
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

            Oracle.Code_Utils.CDMSEnvironment.updateCFGCommonConfigTab(configName, configValue);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
