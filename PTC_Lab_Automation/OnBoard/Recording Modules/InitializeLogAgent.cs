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

namespace OnBoard.Recording_Modules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The InitializeLogAgent recording.
    /// </summary>
    [TestModule("c56b228b-d367-4c20-8f7a-61741ebe7ed8", ModuleType.Recording, 1)]
    public partial class InitializeLogAgent : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::OnBoard.OnBoardRepository repository.
        /// </summary>
        public static global::OnBoard.OnBoardRepository repo = global::OnBoard.OnBoardRepository.Instance;

        static InitializeLogAgent instance = new InitializeLogAgent();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InitializeLogAgent()
        {
            onBoardLogFilePath = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InitializeLogAgent Instance
        {
            get { return instance; }
        }

#region Variables

        string _onBoardLogFilePath;

        /// <summary>
        /// Gets or sets the value of variable onBoardLogFilePath.
        /// </summary>
        [TestVariable("42ce66a7-5b51-4090-b05c-3c053da2d567")]
        public string onBoardLogFilePath
        {
            get { return _onBoardLogFilePath; }
            set { _onBoardLogFilePath = value; }
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

            UserCodeCollections.LogAgentLoop.InitializeLogAgentFunction(onBoardLogFilePath);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
