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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Consist_Defaults
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS recording.
    /// </summary>
    [TestModule("19f7bafc-9177-44c5-88a2-8057b83ca03b", ModuleType.Recording, 1)]
    public partial class DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS instance = new DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS()
        {
            locomotiveKey = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _locomotiveKey;

        /// <summary>
        /// Gets or sets the value of variable locomotiveKey.
        /// </summary>
        [TestVariable("127cf06f-96bb-45f1-963a-efdcbe29b5af")]
        public string locomotiveKey
        {
            get { return _locomotiveKey; }
            set { _locomotiveKey = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("a39e0acb-103c-494f-b33a-195a740cf07b")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_DeleteEngineConfigtRowByLocomotiveKey_TrainDefaultData(locomotiveKey, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
