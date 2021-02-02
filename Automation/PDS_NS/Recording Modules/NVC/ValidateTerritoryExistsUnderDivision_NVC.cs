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
    ///The ValidateTerritoryExistsUnderDivision_NVC recording.
    /// </summary>
    [TestModule("bcf653f5-1822-4171-b99c-c5d02fb4f813", ModuleType.Recording, 1)]
    public partial class ValidateTerritoryExistsUnderDivision_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTerritoryExistsUnderDivision_NVC instance = new ValidateTerritoryExistsUnderDivision_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTerritoryExistsUnderDivision_NVC()
        {
            division = "";
            territory = "";
            expExists = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTerritoryExistsUnderDivision_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("bc202648-c89c-4e79-816b-0113cda6aa20")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _territory;

        /// <summary>
        /// Gets or sets the value of variable territory.
        /// </summary>
        [TestVariable("90b4209b-a0e0-4a90-b62b-c12dba9e2d44")]
        public string territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        string _expExists;

        /// <summary>
        /// Gets or sets the value of variable expExists.
        /// </summary>
        [TestVariable("1fd2ddbc-d546-46c9-afd4-b20a274e2ec8")]
        public string expExists
        {
            get { return _expExists; }
            set { _expExists = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateTerritoryExistsUnderDivision_NVC(division, territory, ValueConverter.ArgumentFromString<bool>("expectExists", expExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
