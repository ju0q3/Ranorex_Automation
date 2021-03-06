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

namespace PDS_NS.Recording_Modules.SystemConfiguration.AlertEvents
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateAcknowledgeAvail_AlertQueueSummary recording.
    /// </summary>
    [TestModule("aaac0c72-60ad-48a5-80a1-b1eedeb3c2e5", ModuleType.Recording, 1)]
    public partial class ValidateAcknowledgeAvail_AlertQueueSummary : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateAcknowledgeAvail_AlertQueueSummary instance = new ValidateAcknowledgeAvail_AlertQueueSummary();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateAcknowledgeAvail_AlertQueueSummary()
        {
            acknowledgeAvail = "true";
            closeForms = "False";
            alertIndex = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateAcknowledgeAvail_AlertQueueSummary Instance
        {
            get { return instance; }
        }

#region Variables

        string _acknowledgeAvail;

        /// <summary>
        /// Gets or sets the value of variable acknowledgeAvail.
        /// </summary>
        [TestVariable("8da75eaf-633c-42aa-a71a-06440302bee4")]
        public string acknowledgeAvail
        {
            get { return _acknowledgeAvail; }
            set { _acknowledgeAvail = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("7833ad16-89a3-4f65-b09e-6eca13e0308e")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _alertIndex;

        /// <summary>
        /// Gets or sets the value of variable alertIndex.
        /// </summary>
        [TestVariable("41f41ce1-5f43-47db-84f8-9f75a01dc3ff")]
        public string alertIndex
        {
            get { return _alertIndex; }
            set { _alertIndex = value; }
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

            UserCodeCollections.NS_Miscellaneous.ValidateAcknowledgeOptionAvail_AlertEventQueueSummary(ValueConverter.ArgumentFromString<int>("alertIndex", alertIndex), ValueConverter.ArgumentFromString<bool>("acknowledgeAvail", acknowledgeAvail), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
