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
    ///The ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC recording.
    /// </summary>
    [TestModule("08874a1e-aa76-45fa-9672-9517eeb2aa6c", ModuleType.Recording, 1)]
    public partial class ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC instance = new ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC()
        {
            inputVariationOptionName = "";
            doCheck = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _inputVariationOptionName;

        /// <summary>
        /// Gets or sets the value of variable inputVariationOptionName.
        /// </summary>
        [TestVariable("419fa7eb-002c-4b68-a861-c128c2fd57ac")]
        public string inputVariationOptionName
        {
            get { return _inputVariationOptionName; }
            set { _inputVariationOptionName = value; }
        }

        string _doCheck;

        /// <summary>
        /// Gets or sets the value of variable doCheck.
        /// </summary>
        [TestVariable("0379f065-daeb-4aa2-877c-0d8b612a3926")]
        public string doCheck
        {
            get { return _doCheck; }
            set { _doCheck = value; }
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

            UserCodeCollections.NS_NVC.NS_ModifyTrainVariabilityOptionsCheckbox_GraphOptions_NVC(inputVariationOptionName, ValueConverter.ArgumentFromString<bool>("doCheck", doCheck));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
