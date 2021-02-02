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

namespace PDS_NS.Recording_Modules.Switch_Heater
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The RightClickSnowMelterOn_Trackline recording.
    /// </summary>
    [TestModule("4e207506-c863-4b9b-bf78-3d308b8e21cd", ModuleType.Recording, 1)]
    public partial class RightClickSnowMelterOn_Trackline : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static RightClickSnowMelterOn_Trackline instance = new RightClickSnowMelterOn_Trackline();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RightClickSnowMelterOn_Trackline()
        {
            snowMelterDeviceId = "";
            expectedDeviceBlink = "True";
            transmit = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static RightClickSnowMelterOn_Trackline Instance
        {
            get { return instance; }
        }

#region Variables

        string _snowMelterDeviceId;

        /// <summary>
        /// Gets or sets the value of variable snowMelterDeviceId.
        /// </summary>
        [TestVariable("efc1934e-8ccc-4a00-a980-0463fe9464e0")]
        public string snowMelterDeviceId
        {
            get { return _snowMelterDeviceId; }
            set { _snowMelterDeviceId = value; }
        }

        string _expectedDeviceBlink;

        /// <summary>
        /// Gets or sets the value of variable expectedDeviceBlink.
        /// </summary>
        [TestVariable("a5b297cb-9205-4411-9453-80ce435f4591")]
        public string expectedDeviceBlink
        {
            get { return _expectedDeviceBlink; }
            set { _expectedDeviceBlink = value; }
        }

        string _transmit;

        /// <summary>
        /// Gets or sets the value of variable transmit.
        /// </summary>
        [TestVariable("36c0822d-328e-47b6-bb18-b9ebcb6e3303")]
        public string transmit
        {
            get { return _transmit; }
            set { _transmit = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_TurnOnOffSnowMelter_Trackline(snowMelterDeviceId, "Right", ValueConverter.ArgumentFromString<bool>("turnOn", "True"), ValueConverter.ArgumentFromString<bool>("transmit", transmit), ValueConverter.ArgumentFromString<bool>("expectDeviceBlink", expectedDeviceBlink));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
