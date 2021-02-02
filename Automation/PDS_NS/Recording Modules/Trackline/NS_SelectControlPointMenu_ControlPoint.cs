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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_SelectControlPointMenu_ControlPoint recording.
    /// </summary>
    [TestModule("686d4c32-e996-49f0-8462-ebdf47d62a46", ModuleType.Recording, 1)]
    public partial class NS_SelectControlPointMenu_ControlPoint : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_SelectControlPointMenu_ControlPoint instance = new NS_SelectControlPointMenu_ControlPoint();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_SelectControlPointMenu_ControlPoint()
        {
            deviceName = "";
            controlpointMenuOption = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_SelectControlPointMenu_ControlPoint Instance
        {
            get { return instance; }
        }

#region Variables

        string _deviceName;

        /// <summary>
        /// Gets or sets the value of variable deviceName.
        /// </summary>
        [TestVariable("1f82b15c-538f-4382-baea-286e0f5d174e")]
        public string deviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        string _controlpointMenuOption;

        /// <summary>
        /// Gets or sets the value of variable controlpointMenuOption.
        /// </summary>
        [TestVariable("c85f7cb0-80a1-4030-a4af-7b61f29f7c39")]
        public string controlpointMenuOption
        {
            get { return _controlpointMenuOption; }
            set { _controlpointMenuOption = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_SelectControlMenuOption_ControlPoint(deviceName, controlpointMenuOption);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
