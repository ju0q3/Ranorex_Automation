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
    ///The ValidateGeneralTimeOptions_GraphOptions_NVC recording.
    /// </summary>
    [TestModule("c0dd06b0-6541-469e-8634-7a9dd2acfaa0", ModuleType.Recording, 1)]
    public partial class ValidateGeneralTimeOptions_GraphOptions_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateGeneralTimeOptions_GraphOptions_NVC instance = new ValidateGeneralTimeOptions_GraphOptions_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateGeneralTimeOptions_GraphOptions_NVC()
        {
            timeOption = "";
            expectSelected = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateGeneralTimeOptions_GraphOptions_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeOption;

        /// <summary>
        /// Gets or sets the value of variable timeOption.
        /// </summary>
        [TestVariable("fd885880-39be-42b3-bd75-3a65ca902015")]
        public string timeOption
        {
            get { return _timeOption; }
            set { _timeOption = value; }
        }

        string _expectSelected;

        /// <summary>
        /// Gets or sets the value of variable expectSelected.
        /// </summary>
        [TestVariable("5e91ecbc-5c1c-4e56-8cd5-6c10d2c37e04")]
        public string expectSelected
        {
            get { return _expectSelected; }
            set { _expectSelected = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateGeneralTimeOptions_GraphOptions_NVC(timeOption, ValueConverter.ArgumentFromString<bool>("expectSelected", expectSelected));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
