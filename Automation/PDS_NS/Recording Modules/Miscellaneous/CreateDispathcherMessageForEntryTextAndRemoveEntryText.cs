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

namespace PDS_NS.Recording_Modules.Miscellaneous
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateDispathcherMessageForEntryTextAndRemoveEntryText recording.
    /// </summary>
    [TestModule("9fa509b4-d42f-4347-a80e-bdddeb846e1d", ModuleType.Recording, 1)]
    public partial class CreateDispathcherMessageForEntryTextAndRemoveEntryText : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateDispathcherMessageForEntryTextAndRemoveEntryText instance = new CreateDispathcherMessageForEntryTextAndRemoveEntryText();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateDispathcherMessageForEntryTextAndRemoveEntryText()
        {
            divisionName = "";
            territoryName = "";
            entryText = "";
            okButton = "False";
            apply = "False";
            closeForms = "False";
            removeEntryText = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateDispathcherMessageForEntryTextAndRemoveEntryText Instance
        {
            get { return instance; }
        }

#region Variables

        string _divisionName;

        /// <summary>
        /// Gets or sets the value of variable divisionName.
        /// </summary>
        [TestVariable("20e04fbb-094e-469b-9b6b-9f2d31183f33")]
        public string divisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        string _territoryName;

        /// <summary>
        /// Gets or sets the value of variable territoryName.
        /// </summary>
        [TestVariable("e03146e0-fbd2-4ba0-9c44-ec8817f8989c")]
        public string territoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
        }

        string _entryText;

        /// <summary>
        /// Gets or sets the value of variable entryText.
        /// </summary>
        [TestVariable("14516b4e-f7ba-4a61-9022-9f0847ca095f")]
        public string entryText
        {
            get { return _entryText; }
            set { _entryText = value; }
        }

        string _okButton;

        /// <summary>
        /// Gets or sets the value of variable okButton.
        /// </summary>
        [TestVariable("9587e35d-d719-4574-8ab4-f2f32653ff21")]
        public string okButton
        {
            get { return _okButton; }
            set { _okButton = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("eae1e467-c462-4239-82a1-662d8dd0f863")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("0ae0b206-4262-435d-b775-ec8ee367d395")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _removeEntryText;

        /// <summary>
        /// Gets or sets the value of variable removeEntryText.
        /// </summary>
        [TestVariable("d5cae463-c196-4ae2-b8b7-5a0c8ae2d730")]
        public string removeEntryText
        {
            get { return _removeEntryText; }
            set { _removeEntryText = value; }
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

            UserCodeCollections.NS_Miscellaneous.NS_CreateDispathcherMessageForEntryTextAndRemoveEntryText(divisionName, territoryName, entryText, removeEntryText, ValueConverter.ArgumentFromString<bool>("okButton", okButton), ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
