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

namespace PTC_Lab_Automation.Recording_Modules.MotionControlActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SetPosition recording.
    /// </summary>
    [TestModule("9d8594b3-a3aa-4f26-9f54-833fb2e1827b", ModuleType.Recording, 1)]
    public partial class SetPosition : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static SetPosition instance = new SetPosition();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetPosition()
        {
            subdivision = "";
            position = "";
            track = "";
            isPositionDecimal_Bool = "false";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SetPosition Instance
        {
            get { return instance; }
        }

#region Variables

        string _subdivision;

        /// <summary>
        /// Gets or sets the value of variable subdivision.
        /// </summary>
        [TestVariable("aa921ce7-1d4f-4cff-92d9-cdbf8e97c200")]
        public string subdivision
        {
            get { return _subdivision; }
            set { _subdivision = value; }
        }

        string _position;

        /// <summary>
        /// Gets or sets the value of variable position.
        /// </summary>
        [TestVariable("c1ab84bc-2d2b-49b9-b7c2-b397f29bce37")]
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

        string _track;

        /// <summary>
        /// Gets or sets the value of variable track.
        /// </summary>
        [TestVariable("52fc9a07-7055-468f-881d-8b6d2b114438")]
        public string track
        {
            get { return _track; }
            set { _track = value; }
        }

        string _isPositionDecimal_Bool;

        /// <summary>
        /// Gets or sets the value of variable isPositionDecimal_Bool.
        /// </summary>
        [TestVariable("ab0bde4a-5071-40b3-8589-e4b714bb0164")]
        public string isPositionDecimal_Bool
        {
            get { return _isPositionDecimal_Bool; }
            set { _isPositionDecimal_Bool = value; }
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

            SetPosition_MotionControl(subdivision, position, track, isPositionDecimal_Bool);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
