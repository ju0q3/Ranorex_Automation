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

namespace PDS_NS.Recording_Modules.Train_Movement
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Set_MovementInformationCommonConfig recording.
    /// </summary>
    [TestModule("81a14c7c-dd8b-40fe-9f63-68709689a761", ModuleType.Recording, 1)]
    public partial class Set_MovementInformationCommonConfig : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Set_MovementInformationCommonConfig instance = new Set_MovementInformationCommonConfig();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Set_MovementInformationCommonConfig()
        {
            configName = "TR_MOVEMENTINFO_AGE_TIME ";
            configValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Set_MovementInformationCommonConfig Instance
        {
            get { return instance; }
        }

#region Variables

        string _configName;

        /// <summary>
        /// Gets or sets the value of variable configName.
        /// </summary>
        [TestVariable("cb11ee7f-b4f9-43d4-8f6d-b1ff3f6654b9")]
        public string configName
        {
            get { return _configName; }
            set { _configName = value; }
        }

        string _configValue;

        /// <summary>
        /// Gets or sets the value of variable configValue.
        /// </summary>
        [TestVariable("df0a6e1e-0b06-43bf-9ca7-5c197516d88f")]
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
