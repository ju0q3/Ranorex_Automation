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
    ///The NS_ConfigTrainETAMessagesFrequency recording.
    /// </summary>
    [TestModule("ad907c21-d0c9-495a-ba2b-7af2644762f9", ModuleType.Recording, 1)]
    public partial class NS_ConfigTrainETAMessagesFrequency : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ConfigTrainETAMessagesFrequency instance = new NS_ConfigTrainETAMessagesFrequency();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ConfigTrainETAMessagesFrequency()
        {
            configName = "";
            configValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ConfigTrainETAMessagesFrequency Instance
        {
            get { return instance; }
        }

#region Variables

        string _configName;

        /// <summary>
        /// Gets or sets the value of variable configName.
        /// </summary>
        [TestVariable("21c16134-b047-486d-8c12-bbf6b51d8976")]
        public string configName
        {
            get { return _configName; }
            set { _configName = value; }
        }

        string _configValue;

        /// <summary>
        /// Gets or sets the value of variable configValue.
        /// </summary>
        [TestVariable("5a6541b4-da09-4c44-bdab-28a9ecc329ec")]
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