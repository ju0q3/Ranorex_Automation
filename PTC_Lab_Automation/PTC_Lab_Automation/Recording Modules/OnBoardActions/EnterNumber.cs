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
    ///The EnterNumber recording.
    /// </summary>
    [TestModule("8d8e725b-96e2-403a-9c08-b72059027455", ModuleType.Recording, 1)]
    public partial class EnterNumber : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static EnterNumber instance = new EnterNumber();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EnterNumber()
        {
            numericDigits = "";
            numberType = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EnterNumber Instance
        {
            get { return instance; }
        }

#region Variables

        string _numericDigits;

        /// <summary>
        /// Gets or sets the value of variable numericDigits.
        /// </summary>
        [TestVariable("1083f7ea-dcc2-42b8-9a45-57b2a73b09ee")]
        public string numericDigits
        {
            get { return _numericDigits; }
            set { _numericDigits = value; }
        }

        string _numberType;

        /// <summary>
        /// Gets or sets the value of variable numberType.
        /// </summary>
        [TestVariable("d9d02013-f6c1-4399-8795-d85b95ee5913")]
        public string numberType
        {
            get { return _numberType; }
            set { _numberType = value; }
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

            EnterNumber_OnBoard(numericDigits, numberType);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
