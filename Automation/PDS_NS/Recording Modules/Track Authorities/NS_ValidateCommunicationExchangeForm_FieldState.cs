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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ValidateCommunicationExchangeForm_FieldState recording.
    /// </summary>
    [TestModule("cd0e331e-a75a-42e2-9dfc-e28137ec1364", ModuleType.Recording, 1)]
    public partial class NS_ValidateCommunicationExchangeForm_FieldState : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateCommunicationExchangeForm_FieldState instance = new NS_ValidateCommunicationExchangeForm_FieldState();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateCommunicationExchangeForm_FieldState()
        {
            closeForm = "False";
            extendUntilEnabled = "False";
            rollupLocationEnabled = "False";
            recordedAtEnabled = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateCommunicationExchangeForm_FieldState Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("82eaae9d-7531-46bf-9fa7-ea4534ea0415")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _extendUntilEnabled;

        /// <summary>
        /// Gets or sets the value of variable extendUntilEnabled.
        /// </summary>
        [TestVariable("029190fd-5732-4c72-85b1-49398b22c4e1")]
        public string extendUntilEnabled
        {
            get { return _extendUntilEnabled; }
            set { _extendUntilEnabled = value; }
        }

        string _rollupLocationEnabled;

        /// <summary>
        /// Gets or sets the value of variable rollupLocationEnabled.
        /// </summary>
        [TestVariable("cb959d17-13c0-4f04-a7a3-8624b55409ba")]
        public string rollupLocationEnabled
        {
            get { return _rollupLocationEnabled; }
            set { _rollupLocationEnabled = value; }
        }

        string _recordedAtEnabled;

        /// <summary>
        /// Gets or sets the value of variable recordedAtEnabled.
        /// </summary>
        [TestVariable("8d3c89df-d5fd-4f55-b8da-d97151c0b32c")]
        public string recordedAtEnabled
        {
            get { return _recordedAtEnabled; }
            set { _recordedAtEnabled = value; }
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

            UserCodeCollections.NS_Authorities.NS_ValidateCommunicationExchangeFormState(ValueConverter.ArgumentFromString<bool>("extendUntilEnabled", extendUntilEnabled), ValueConverter.ArgumentFromString<bool>("rollupLocationEnabled", rollupLocationEnabled), ValueConverter.ArgumentFromString<bool>("recordedAtEnabled", recordedAtEnabled), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
