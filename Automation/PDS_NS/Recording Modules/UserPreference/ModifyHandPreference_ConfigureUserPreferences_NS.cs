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

namespace PDS_NS.Recording_Modules.UserPreference
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyHandPreference_ConfigureUserPreferences_NS recording.
    /// </summary>
    [TestModule("075a94e4-1010-4a1c-bef3-afc598b8f7cb", ModuleType.Recording, 1)]
    public partial class ModifyHandPreference_ConfigureUserPreferences_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyHandPreference_ConfigureUserPreferences_NS instance = new ModifyHandPreference_ConfigureUserPreferences_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyHandPreference_ConfigureUserPreferences_NS()
        {
            handPreference = "";
            reset = "False";
            clickApply = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyHandPreference_ConfigureUserPreferences_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _handPreference;

        /// <summary>
        /// Gets or sets the value of variable handPreference.
        /// </summary>
        [TestVariable("f9ec1bd3-c16f-4c0b-902b-22df663403da")]
        public string handPreference
        {
            get { return _handPreference; }
            set { _handPreference = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("5c7958a0-e216-4c3d-a4c4-d0944b3c985a")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("65e612aa-8907-4362-aa1b-b2b2d6bd60f4")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("17fddf55-8a69-4927-b160-d7ca35455dfc")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_UserDetails.NS_ModifyHandPreference_ConfigureUserPreferences(handPreference, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}