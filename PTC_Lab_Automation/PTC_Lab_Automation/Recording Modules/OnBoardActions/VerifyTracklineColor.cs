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

namespace PTC_Lab_Automation.Recording_Modules.OnBoardActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The VerifyTracklineColor recording.
    /// </summary>
    [TestModule("5304bb3c-346a-42d7-8546-03f415d5f762", ModuleType.Recording, 1)]
    public partial class VerifyTracklineColor : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static VerifyTracklineColor instance = new VerifyTracklineColor();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyTracklineColor()
        {
            color = "";
            direction = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VerifyTracklineColor Instance
        {
            get { return instance; }
        }

#region Variables

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("95e6d8a0-f5f1-4615-a972-58692042c364")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        string _direction;

        /// <summary>
        /// Gets or sets the value of variable direction.
        /// </summary>
        [TestVariable("63d97e69-144c-4213-9847-715c2277bdaa")]
        public string direction
        {
            get { return _direction; }
            set { _direction = value; }
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

            Report.Log(ReportLevel.Failure, "User", "This is not implemented yet", new RecordItemIndex(0));
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}