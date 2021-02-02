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

namespace STE.Recording_Modules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The STE_SetDeviceMessage recording.
    /// </summary>
    [TestModule("59d4b256-29ba-4f8c-b139-d5cec00e370e", ModuleType.Recording, 1)]
    public partial class STE_SetDeviceMessage : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::STE.STERepository repository.
        /// </summary>
        public static global::STE.STERepository repo = global::STE.STERepository.Instance;

        static STE_SetDeviceMessage instance = new STE_SetDeviceMessage();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public STE_SetDeviceMessage()
        {
            deviceId = "";
            deviceAction = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static STE_SetDeviceMessage Instance
        {
            get { return instance; }
        }

#region Variables

        string _deviceId;

        /// <summary>
        /// Gets or sets the value of variable deviceId.
        /// </summary>
        [TestVariable("939fdcf4-1d5b-4241-82ac-0db9ac3c43b8")]
        public string deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        string _deviceAction;

        /// <summary>
        /// Gets or sets the value of variable deviceAction.
        /// </summary>
        [TestVariable("57c008d2-9ed7-4c2f-87fe-ca0a0431c0c4")]
        public string deviceAction
        {
            get { return _deviceAction; }
            set { _deviceAction = value; }
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

            Code_Utils.SteOccupancyCollection.SetDevice(deviceId, deviceAction);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}