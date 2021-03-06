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
    ///The ValidateTrackOptionsCheckbox_NVC recording.
    /// </summary>
    [TestModule("f9dd2028-a6cf-423f-a35b-bc760a1df7db", ModuleType.Recording, 1)]
    public partial class ValidateTrackOptionsCheckbox_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTrackOptionsCheckbox_NVC instance = new ValidateTrackOptionsCheckbox_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTrackOptionsCheckbox_NVC()
        {
            isShowFirstOverTrackChecked = "False";
            isShowUnblockableCrossingsChecked = "False";
            isShowDisconnectedChecked = "False";
            isCompensateForCrossingsWithGapsChecked = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTrackOptionsCheckbox_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _isShowFirstOverTrackChecked;

        /// <summary>
        /// Gets or sets the value of variable isShowFirstOverTrackChecked.
        /// </summary>
        [TestVariable("ed16954b-4bf6-4209-af5f-03218398cba5")]
        public string isShowFirstOverTrackChecked
        {
            get { return _isShowFirstOverTrackChecked; }
            set { _isShowFirstOverTrackChecked = value; }
        }

        string _isShowUnblockableCrossingsChecked;

        /// <summary>
        /// Gets or sets the value of variable isShowUnblockableCrossingsChecked.
        /// </summary>
        [TestVariable("deb5708f-6f2f-4e58-b6c4-a14f1f3db1eb")]
        public string isShowUnblockableCrossingsChecked
        {
            get { return _isShowUnblockableCrossingsChecked; }
            set { _isShowUnblockableCrossingsChecked = value; }
        }

        string _isShowDisconnectedChecked;

        /// <summary>
        /// Gets or sets the value of variable isShowDisconnectedChecked.
        /// </summary>
        [TestVariable("92b037f9-3133-484e-8e66-94b969afa022")]
        public string isShowDisconnectedChecked
        {
            get { return _isShowDisconnectedChecked; }
            set { _isShowDisconnectedChecked = value; }
        }

        string _isCompensateForCrossingsWithGapsChecked;

        /// <summary>
        /// Gets or sets the value of variable isCompensateForCrossingsWithGapsChecked.
        /// </summary>
        [TestVariable("b869f582-7da3-438e-86c5-fee4076d6c1b")]
        public string isCompensateForCrossingsWithGapsChecked
        {
            get { return _isCompensateForCrossingsWithGapsChecked; }
            set { _isCompensateForCrossingsWithGapsChecked = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateTrackOptionsCheckbox_NVC(ValueConverter.ArgumentFromString<bool>("isShowFirstOverTrackChecked", isShowFirstOverTrackChecked), ValueConverter.ArgumentFromString<bool>("isShowUnblockableCrossingsChecked", isShowUnblockableCrossingsChecked), ValueConverter.ArgumentFromString<bool>("isShowDisconnectedChecked", isShowDisconnectedChecked), ValueConverter.ArgumentFromString<bool>("isCompensateForCrossingsWithGapsChecked", isCompensateForCrossingsWithGapsChecked));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
