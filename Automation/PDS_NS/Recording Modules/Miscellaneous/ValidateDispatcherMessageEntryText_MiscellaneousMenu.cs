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
    ///The ValidateDispatcherMessageEntryText_MiscellaneousMenu recording.
    /// </summary>
    [TestModule("b04cb656-326a-4a49-ac5d-62a7bfb47886", ModuleType.Recording, 1)]
    public partial class ValidateDispatcherMessageEntryText_MiscellaneousMenu : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDispatcherMessageEntryText_MiscellaneousMenu instance = new ValidateDispatcherMessageEntryText_MiscellaneousMenu();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDispatcherMessageEntryText_MiscellaneousMenu()
        {
            closeForm = "False";
            expectEntryText = "";
            divisionName = "";
            territoryName = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDispatcherMessageEntryText_MiscellaneousMenu Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("a6a6de32-f473-4771-8646-f2c9da87f736")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _expectEntryText;

        /// <summary>
        /// Gets or sets the value of variable expectEntryText.
        /// </summary>
        [TestVariable("998b6a50-7e29-408a-a167-fc7ebf3c82a8")]
        public string expectEntryText
        {
            get { return _expectEntryText; }
            set { _expectEntryText = value; }
        }

        string _divisionName;

        /// <summary>
        /// Gets or sets the value of variable divisionName.
        /// </summary>
        [TestVariable("bd8e4a82-9c84-4958-8eba-6aa703d9a81f")]
        public string divisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        string _territoryName;

        /// <summary>
        /// Gets or sets the value of variable territoryName.
        /// </summary>
        [TestVariable("ce705ca2-b9e5-425f-8b36-023eb02b7e53")]
        public string territoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
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

            UserCodeCollections.NS_Miscellaneous.NS_ValidateDispatcherMessageEntryText_MiscellaneousMenu(divisionName, territoryName, expectEntryText, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
