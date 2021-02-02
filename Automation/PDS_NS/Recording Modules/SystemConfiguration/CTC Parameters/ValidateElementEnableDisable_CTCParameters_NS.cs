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

namespace PDS_NS.Recording_Modules.SystemConfiguration.CTC_Parameters
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateElementEnableDisable_CTCParameters_NS recording.
    /// </summary>
    [TestModule("fe23a1f7-d9d7-4437-abbb-7a10a42c8600", ModuleType.Recording, 1)]
    public partial class ValidateElementEnableDisable_CTCParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateElementEnableDisable_CTCParameters_NS instance = new ValidateElementEnableDisable_CTCParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateElementEnableDisable_CTCParameters_NS()
        {
            elementType = "";
            closeForms = "False";
            enabledDisabled = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateElementEnableDisable_CTCParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _elementType;

        /// <summary>
        /// Gets or sets the value of variable elementType.
        /// </summary>
        [TestVariable("4b789463-90aa-430b-aeaa-396d22334124")]
        public string elementType
        {
            get { return _elementType; }
            set { _elementType = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("5fde9535-8e45-4d47-b86a-7506727c8599")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _enabledDisabled;

        /// <summary>
        /// Gets or sets the value of variable enabledDisabled.
        /// </summary>
        [TestVariable("73643466-b788-45a1-a11f-0bb5671d3710")]
        public string enabledDisabled
        {
            get { return _enabledDisabled; }
            set { _enabledDisabled = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateElementEnableDisable_CTCParameters(elementType, ValueConverter.ArgumentFromString<bool>("enabledDisabled", enabledDisabled), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}