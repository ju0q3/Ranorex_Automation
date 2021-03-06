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
    ///The ValidateTopologyTerritoryCheckbox_NVC recording.
    /// </summary>
    [TestModule("df252cef-c05d-4884-9419-101ea6089858", ModuleType.Recording, 1)]
    public partial class ValidateTopologyTerritoryCheckbox_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTopologyTerritoryCheckbox_NVC instance = new ValidateTopologyTerritoryCheckbox_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTopologyTerritoryCheckbox_NVC()
        {
            division = "";
            territory = "";
            expectChecked = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTopologyTerritoryCheckbox_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("e55c2099-0a89-433d-a71d-a9c8b25f9fe6")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _territory;

        /// <summary>
        /// Gets or sets the value of variable territory.
        /// </summary>
        [TestVariable("80735076-fdf6-4597-958d-cb68230f453c")]
        public string territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        string _expectChecked;

        /// <summary>
        /// Gets or sets the value of variable expectChecked.
        /// </summary>
        [TestVariable("6f4d12c1-bf6f-47d5-ac04-59dc51cd5964")]
        public string expectChecked
        {
            get { return _expectChecked; }
            set { _expectChecked = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateTopologyTerritoryCheckbox_NVC(division, territory, ValueConverter.ArgumentFromString<bool>("expectChecked", expectChecked));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
