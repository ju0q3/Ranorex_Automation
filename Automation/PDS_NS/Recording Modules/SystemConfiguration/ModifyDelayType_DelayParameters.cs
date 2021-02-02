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

namespace PDS_NS.Recording_Modules.SystemConfiguration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyDelayType_DelayParameters recording.
    /// </summary>
    [TestModule("56d0020d-e121-494d-bb6a-efb831b25176", ModuleType.Recording, 1)]
    public partial class ModifyDelayType_DelayParameters : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyDelayType_DelayParameters instance = new ModifyDelayType_DelayParameters();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyDelayType_DelayParameters()
        {
            delayTypeCode = "";
            description = "";
            priority = "";
            reviewNeeded = "False";
            delayEnabled = "False";
            deleteEnabled = "False";
            mechanical = "False";
            delayCap = "";
            expectedFeedback = "";
            apply = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyDelayType_DelayParameters Instance
        {
            get { return instance; }
        }

#region Variables

        string _delayTypeCode;

        /// <summary>
        /// Gets or sets the value of variable delayTypeCode.
        /// </summary>
        [TestVariable("85deb7d9-5591-410b-869b-df8ff3df2153")]
        public string delayTypeCode
        {
            get { return _delayTypeCode; }
            set { _delayTypeCode = value; }
        }

        string _description;

        /// <summary>
        /// Gets or sets the value of variable description.
        /// </summary>
        [TestVariable("2a3d9846-1271-4df0-aa98-c8a6d896b65a")]
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _priority;

        /// <summary>
        /// Gets or sets the value of variable priority.
        /// </summary>
        [TestVariable("4bc77b6a-eab2-477b-8ced-602abd6c2855")]
        public string priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        string _reviewNeeded;

        /// <summary>
        /// Gets or sets the value of variable reviewNeeded.
        /// </summary>
        [TestVariable("75335f5d-84c6-4014-8309-46ce7ea7028c")]
        public string reviewNeeded
        {
            get { return _reviewNeeded; }
            set { _reviewNeeded = value; }
        }

        string _delayEnabled;

        /// <summary>
        /// Gets or sets the value of variable delayEnabled.
        /// </summary>
        [TestVariable("56bd7ba3-1318-45e9-a486-9c17cf4a82e8")]
        public string delayEnabled
        {
            get { return _delayEnabled; }
            set { _delayEnabled = value; }
        }

        string _deleteEnabled;

        /// <summary>
        /// Gets or sets the value of variable deleteEnabled.
        /// </summary>
        [TestVariable("dc9a252a-52bd-45e7-ac92-f9208127176d")]
        public string deleteEnabled
        {
            get { return _deleteEnabled; }
            set { _deleteEnabled = value; }
        }

        string _mechanical;

        /// <summary>
        /// Gets or sets the value of variable mechanical.
        /// </summary>
        [TestVariable("d83e49ae-84e4-4e97-b40c-c623e4612127")]
        public string mechanical
        {
            get { return _mechanical; }
            set { _mechanical = value; }
        }

        string _delayCap;

        /// <summary>
        /// Gets or sets the value of variable delayCap.
        /// </summary>
        [TestVariable("ec37ac62-de09-45b6-99f2-cd03613c3542")]
        public string delayCap
        {
            get { return _delayCap; }
            set { _delayCap = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("06c871cf-6da5-4c85-bb5b-8f497d001f02")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("3a3224f7-548c-4063-a926-add874998222")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("3b05f90e-4641-4324-9d59-f7e4ff2775db")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyDelayType_DelayParameters(delayTypeCode, description, priority, ValueConverter.ArgumentFromString<bool>("reviewNeeded", reviewNeeded), ValueConverter.ArgumentFromString<bool>("delayEnabled", delayEnabled), ValueConverter.ArgumentFromString<bool>("deleteEnabled", deleteEnabled), ValueConverter.ArgumentFromString<bool>("mechanical", mechanical), delayCap, expectedFeedback, ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
