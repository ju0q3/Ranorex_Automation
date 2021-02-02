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
    ///The ControlRequestList_ValidateEntry_NS recording.
    /// </summary>
    [TestModule("9cca5480-5146-4246-b30b-0fbca3d511c7", ModuleType.Recording, 1)]
    public partial class ControlRequestList_ValidateEntry_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ControlRequestList_ValidateEntry_NS instance = new ControlRequestList_ValidateEntry_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ControlRequestList_ValidateEntry_NS()
        {
            controlPointName = "";
            switchPosition = "";
            validateEntryExists = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ControlRequestList_ValidateEntry_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _controlPointName;

        /// <summary>
        /// Gets or sets the value of variable controlPointName.
        /// </summary>
        [TestVariable("7cb54ee3-a3d3-49cb-9ee1-b8758fb192fe")]
        public string controlPointName
        {
            get { return _controlPointName; }
            set { _controlPointName = value; }
        }

        string _switchPosition;

        /// <summary>
        /// Gets or sets the value of variable switchPosition.
        /// </summary>
        [TestVariable("7039252d-5658-49f3-aa71-b27e581f1bec")]
        public string switchPosition
        {
            get { return _switchPosition; }
            set { _switchPosition = value; }
        }

        string _validateEntryExists;

        /// <summary>
        /// Gets or sets the value of variable validateEntryExists.
        /// </summary>
        [TestVariable("ff700ac9-f557-43c0-9b23-e12c45c44d50")]
        public string validateEntryExists
        {
            get { return _validateEntryExists; }
            set { _validateEntryExists = value; }
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

            CodeUtils.NS_TerritoryTransfer_Validations.NS_ValidateEntry_ControlRequestList(controlPointName, switchPosition, ValueConverter.ArgumentFromString<bool>("validateRecordExists", validateEntryExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}