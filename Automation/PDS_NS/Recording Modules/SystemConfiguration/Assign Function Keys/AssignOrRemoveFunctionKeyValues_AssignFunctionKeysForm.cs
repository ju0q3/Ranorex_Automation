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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Assign_Function_Keys
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm recording.
    /// </summary>
    [TestModule("111fbd43-0712-4735-a18b-bed54932c1b2", ModuleType.Recording, 1)]
    public partial class AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm instance = new AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm()
        {
            function = "";
            functionKey = "";
            closeForms = "False";
            apply = "False";
            reset = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _function;

        /// <summary>
        /// Gets or sets the value of variable function.
        /// </summary>
        [TestVariable("e65585fd-c2a8-4e33-9af0-bd227bc03f92")]
        public string function
        {
            get { return _function; }
            set { _function = value; }
        }

        string _functionKey;

        /// <summary>
        /// Gets or sets the value of variable functionKey.
        /// </summary>
        [TestVariable("d450e84f-fe94-49bd-81d7-7788be3228eb")]
        public string functionKey
        {
            get { return _functionKey; }
            set { _functionKey = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("88cf123f-c180-47d6-8ddf-09096670b123")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("716d5a13-1787-4a47-b3bf-6a430cd51499")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("f6c346bf-1931-434e-8d6e-a696717b9c1e")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_AssignOrRemoveFunctionKeyValues_AssignFunctionKeysForm(function, functionKey, ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
