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

namespace PTC_Lab_Automation.Recording_Modules.LogManagerActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateMessageReceived recording.
    /// </summary>
    [TestModule("4894e14a-1609-411a-a4b1-f6f333143f68", ModuleType.Recording, 1)]
    public partial class ValidateMessageReceived : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static ValidateMessageReceived instance = new ValidateMessageReceived();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateMessageReceived()
        {
            message = "";
            timeFrameInSeconds = "180";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateMessageReceived Instance
        {
            get { return instance; }
        }

#region Variables

        string _message;

        /// <summary>
        /// Gets or sets the value of variable message.
        /// </summary>
        [TestVariable("e42dd457-6d4a-4e10-a271-d0c287cf5ec6")]
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        string _timeFrameInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeFrameInSeconds.
        /// </summary>
        [TestVariable("5250f55c-d4b6-4395-a70b-e2e52f434ee9")]
        public string timeFrameInSeconds
        {
            get { return _timeFrameInSeconds; }
            set { _timeFrameInSeconds = value; }
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

            ValidateMessageReceived_LogManager(message, timeFrameInSeconds);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}