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

namespace PDS_NS.Recording_Modules.SystemConfiguration.AlertEvents
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateAlertColor_AlertQueueSummary recording.
    /// </summary>
    [TestModule("495a3293-9193-4d4f-9db0-5b861340e34f", ModuleType.Recording, 1)]
    public partial class ValidateAlertColor_AlertQueueSummary : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateAlertColor_AlertQueueSummary instance = new ValidateAlertColor_AlertQueueSummary();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateAlertColor_AlertQueueSummary()
        {
            color = "";
            closeForms = "False";
            alertIndex = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateAlertColor_AlertQueueSummary Instance
        {
            get { return instance; }
        }

#region Variables

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("61547125-30a1-482e-be69-0b024eed179c")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("08fd6c84-6599-4a5b-ab84-cd5a885e2c7e")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _alertIndex;

        /// <summary>
        /// Gets or sets the value of variable alertIndex.
        /// </summary>
        [TestVariable("d0b43114-d89f-4280-84d2-9cf52beb4d4a")]
        public string alertIndex
        {
            get { return _alertIndex; }
            set { _alertIndex = value; }
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

            UserCodeCollections.NS_Miscellaneous.ValidateAlertColor_AlertEventQueueSummary(color, ValueConverter.ArgumentFromString<int>("alertIndex", alertIndex), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
