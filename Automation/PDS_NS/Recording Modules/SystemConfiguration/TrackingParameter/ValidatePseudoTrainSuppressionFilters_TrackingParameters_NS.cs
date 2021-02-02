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

namespace PDS_NS.Recording_Modules.SystemConfiguration.TrackingParameter
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS recording.
    /// </summary>
    [TestModule("9599458c-f7cf-4f90-8fb6-4a17658e5fc5", ModuleType.Recording, 1)]
    public partial class ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS instance = new ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS()
        {
            expNoPseudoTrainID = "False";
            expSignalSystemSuspended = "False";
            expSwitchBlock = "False";
            expTrackBlock = "False";
            expLocalorField = "False";
            expSignalTechControl = "False";
            expControlPointFailed = "False";
            expTrackandTime = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePseudoTrainSuppressionFilters_TrackingParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expNoPseudoTrainID;

        /// <summary>
        /// Gets or sets the value of variable expNoPseudoTrainID.
        /// </summary>
        [TestVariable("065be4c8-37a4-437d-8bf9-7efd5fa4536f")]
        public string expNoPseudoTrainID
        {
            get { return _expNoPseudoTrainID; }
            set { _expNoPseudoTrainID = value; }
        }

        string _expSignalSystemSuspended;

        /// <summary>
        /// Gets or sets the value of variable expSignalSystemSuspended.
        /// </summary>
        [TestVariable("0c51ba27-1490-4ecb-a834-94319cf5a262")]
        public string expSignalSystemSuspended
        {
            get { return _expSignalSystemSuspended; }
            set { _expSignalSystemSuspended = value; }
        }

        string _expSwitchBlock;

        /// <summary>
        /// Gets or sets the value of variable expSwitchBlock.
        /// </summary>
        [TestVariable("13f67d2a-0fa1-4d71-868f-031a8181d76c")]
        public string expSwitchBlock
        {
            get { return _expSwitchBlock; }
            set { _expSwitchBlock = value; }
        }

        string _expTrackBlock;

        /// <summary>
        /// Gets or sets the value of variable expTrackBlock.
        /// </summary>
        [TestVariable("d0dff56c-5d7c-49db-b879-2da07304a5d5")]
        public string expTrackBlock
        {
            get { return _expTrackBlock; }
            set { _expTrackBlock = value; }
        }

        string _expLocalorField;

        /// <summary>
        /// Gets or sets the value of variable expLocalorField.
        /// </summary>
        [TestVariable("9e3cab97-9ff9-4f81-8cfa-550f70343a3d")]
        public string expLocalorField
        {
            get { return _expLocalorField; }
            set { _expLocalorField = value; }
        }

        string _expSignalTechControl;

        /// <summary>
        /// Gets or sets the value of variable expSignalTechControl.
        /// </summary>
        [TestVariable("6d4e58ec-fe51-477d-b389-9f7c8985bb14")]
        public string expSignalTechControl
        {
            get { return _expSignalTechControl; }
            set { _expSignalTechControl = value; }
        }

        string _expControlPointFailed;

        /// <summary>
        /// Gets or sets the value of variable expControlPointFailed.
        /// </summary>
        [TestVariable("94c85a49-9330-4124-a65a-8e9c249be47b")]
        public string expControlPointFailed
        {
            get { return _expControlPointFailed; }
            set { _expControlPointFailed = value; }
        }

        string _expTrackandTime;

        /// <summary>
        /// Gets or sets the value of variable expTrackandTime.
        /// </summary>
        [TestVariable("67d9a7e2-3b7a-43d8-a75f-68522f60a896")]
        public string expTrackandTime
        {
            get { return _expTrackandTime; }
            set { _expTrackandTime = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("c83be3f0-8920-476e-9492-ae054ee2b583")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidatePseudoTrainSuppressionFilters_TrackingParameters(ValueConverter.ArgumentFromString<bool>("expNoPseudoTrainID", expNoPseudoTrainID), ValueConverter.ArgumentFromString<bool>("expSignalSystemSuspended", expSignalSystemSuspended), ValueConverter.ArgumentFromString<bool>("expSwitchBlock", expSwitchBlock), ValueConverter.ArgumentFromString<bool>("expTrackBlock", expTrackBlock), ValueConverter.ArgumentFromString<bool>("expLocalorField", expLocalorField), ValueConverter.ArgumentFromString<bool>("expControlPointFailed", expControlPointFailed), ValueConverter.ArgumentFromString<bool>("expSignalTechControl", expSignalTechControl), ValueConverter.ArgumentFromString<bool>("expTrackandTime", expTrackandTime), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}