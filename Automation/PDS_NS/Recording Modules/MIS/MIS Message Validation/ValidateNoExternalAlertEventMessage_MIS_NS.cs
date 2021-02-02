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

namespace PDS_NS.Recording_Modules.MIS.MIS_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateNoExternalAlertEventMessage_MIS_NS recording.
    /// </summary>
    [TestModule("2d8e3ae9-1551-40f5-b90a-f9203de1c06b", ModuleType.Recording, 1)]
    public partial class ValidateNoExternalAlertEventMessage_MIS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateNoExternalAlertEventMessage_MIS_NS instance = new ValidateNoExternalAlertEventMessage_MIS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateNoExternalAlertEventMessage_MIS_NS()
        {
            alertEventType = "";
            deviceId = "0";
            timeInSeconds = "0";
            retry = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateNoExternalAlertEventMessage_MIS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _alertEventType;

        /// <summary>
        /// Gets or sets the value of variable alertEventType.
        /// </summary>
        [TestVariable("3da6fc10-f21c-468a-b89f-108e86e1a3bb")]
        public string alertEventType
        {
            get { return _alertEventType; }
            set { _alertEventType = value; }
        }

        string _deviceId;

        /// <summary>
        /// Gets or sets the value of variable deviceId.
        /// </summary>
        [TestVariable("a304d33f-5b7a-409a-80b2-83b107d96b48")]
        public string deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("6601498f-2918-47d9-a5e0-26082d157cc9")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("831be545-85b7-4d28-a358-2fb95b0f6b2e")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
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

            UserCodeCollections.NS_MIS_Messages.ValidateNoExternalAlertEventMessage(alertEventType, deviceId, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
