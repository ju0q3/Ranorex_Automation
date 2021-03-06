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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC recording.
    /// </summary>
    [TestModule("a1f9c5fb-8f16-47e6-831b-64d5355c1b6b", ModuleType.Recording, 1)]
    public partial class SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC instance = new SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC()
        {
            timeValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeValue;

        /// <summary>
        /// Gets or sets the value of variable timeValue.
        /// </summary>
        [TestVariable("0d95e2ad-365c-46bb-90c9-c920a81b9c10")]
        public string timeValue
        {
            get { return _timeValue; }
            set { _timeValue = value; }
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

            UserCodeCollections.NS_NVC.NS_SetTimeValue_OnlyShowItemsByTimeCheckbox_NVC(timeValue);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
