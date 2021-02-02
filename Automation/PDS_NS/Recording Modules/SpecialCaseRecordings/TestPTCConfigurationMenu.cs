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

namespace PDS_NS.Recording_Modules.SpecialCaseRecordings
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The TestPTCConfigurationMenu recording.
    /// </summary>
    [TestModule("dabc65b0-142c-43b8-bd2c-4f8921b707cc", ModuleType.Recording, 1)]
    public partial class TestPTCConfigurationMenu : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static TestPTCConfigurationMenu instance = new TestPTCConfigurationMenu();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TestPTCConfigurationMenu()
        {
            Iterations = "100";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static TestPTCConfigurationMenu Instance
        {
            get { return instance; }
        }

#region Variables

        string _Iterations;

        /// <summary>
        /// Gets or sets the value of variable Iterations.
        /// </summary>
        [TestVariable("7503b5a9-5777-48a5-802d-b9f30e52960d")]
        public string Iterations
        {
            get { return _Iterations; }
            set { _Iterations = value; }
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

            PTCConfigTest(ValueConverter.ArgumentFromString<int>("Iterations", Iterations));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
