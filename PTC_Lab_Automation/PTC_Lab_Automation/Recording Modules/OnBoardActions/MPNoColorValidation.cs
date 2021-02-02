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
    ///The MPNoColorValidation recording.
    /// </summary>
    [TestModule("8f70f494-0b90-4117-b0c9-d7c68a030628", ModuleType.Recording, 1)]
    public partial class MPNoColorValidation : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static MPNoColorValidation instance = new MPNoColorValidation();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public MPNoColorValidation()
        {
            color = "";
            milepost = "Not implented yet";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static MPNoColorValidation Instance
        {
            get { return instance; }
        }

#region Variables

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("23c50051-78d9-4829-841b-4a23861c64c2")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        string _milepost;

        /// <summary>
        /// Gets or sets the value of variable milepost.
        /// </summary>
        [TestVariable("b6af940c-ff92-4cec-90b6-8e43de27b36f")]
        public string milepost
        {
            get { return _milepost; }
            set { _milepost = value; }
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

            // Not implemented yet
            Report.Log(ReportLevel.Failure, "User", milepost, new RecordItemIndex(0));
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
