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
    ///The CheckTopologyTerritoryCheckbox_NVC recording.
    /// </summary>
    [TestModule("164d990e-7096-4281-8209-df7ec290882d", ModuleType.Recording, 1)]
    public partial class CheckTopologyTerritoryCheckbox_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CheckTopologyTerritoryCheckbox_NVC instance = new CheckTopologyTerritoryCheckbox_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckTopologyTerritoryCheckbox_NVC()
        {
            division = "GA";
            territory = "Inman";
            doCheck = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckTopologyTerritoryCheckbox_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("81e7a1be-e63b-4f61-98e3-fa98c5c85837")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _territory;

        /// <summary>
        /// Gets or sets the value of variable territory.
        /// </summary>
        [TestVariable("c3ffb021-fcd7-415b-8ebe-f1e6a05eafdc")]
        public string territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        string _doCheck;

        /// <summary>
        /// Gets or sets the value of variable doCheck.
        /// </summary>
        [TestVariable("98d9d3bf-347d-4c50-9824-6ce3b03e31a7")]
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

            UserCodeCollections.NS_NVC.NS_CheckTopologyTerritoryCheckbox_NVC(division, territory, ValueConverter.ArgumentFromString<bool>("doCheck", doCheck));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
