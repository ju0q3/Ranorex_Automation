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

namespace PDS_NS.Recording_Modules.TerritoryTransfer
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ReleaseTerritory recording.
    /// </summary>
    [TestModule("1eb2286b-2ae5-41a2-962f-71c9dbcad825", ModuleType.Recording, 1)]
    public partial class NS_ReleaseTerritory : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ReleaseTerritory instance = new NS_ReleaseTerritory();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ReleaseTerritory()
        {
            territoryName = "South End";
            removeButton = "False";
            pressApply = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ReleaseTerritory Instance
        {
            get { return instance; }
        }

#region Variables

        string _territoryName;

        /// <summary>
        /// Gets or sets the value of variable territoryName.
        /// </summary>
        [TestVariable("daa17638-c66a-4867-82b5-91adf0f34e93")]
        public string territoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
        }

        string _removeButton;

        /// <summary>
        /// Gets or sets the value of variable removeButton.
        /// </summary>
        [TestVariable("6d5b8d15-506e-473c-89b6-48280b1aa2c0")]
        public string removeButton
        {
            get { return _removeButton; }
            set { _removeButton = value; }
        }

        string _pressApply;

        /// <summary>
        /// Gets or sets the value of variable pressApply.
        /// </summary>
        [TestVariable("306a446d-ae00-4b7f-a955-e4ed982655b5")]
        public string pressApply
        {
            get { return _pressApply; }
            set { _pressApply = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("22bbda25-c1a8-4ab6-bebf-e5a01c30e2ba")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            releaseTerritoryFunction(territoryName, ValueConverter.ArgumentFromString<bool>("removeButton", removeButton), ValueConverter.ArgumentFromString<bool>("pressApply", pressApply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
