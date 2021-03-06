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

namespace PDS_NS.Recording_Modules.PTC.PTC_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDC_TCON_ByContent_NS recording.
    /// </summary>
    [TestModule("2f14d483-7bcd-4036-9c38-d945b0521eb3", ModuleType.Recording, 1)]
    public partial class ValidateDC_TCON_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDC_TCON_ByContent_NS instance = new ValidateDC_TCON_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDC_TCON_ByContent_NS()
        {
            trainSeed = "";
            engineSeed = "";
            timeInSeconds = "5";
            retry = "True";
            optTriggerType = "";
            optPtcLocoOrientation = "";
            isPTCLocoOrientationPresent = "True";
            optLoads = "";
            optEmpties = "";
            optTonnage = "";
            optLength = "";
            optAxles = "";
            optOperativeBrakes = "";
            optTotalBrakingForce = "";
            isAxleCountPresent = "True";
            isOperativeBrakesPresent = "True";
            isTotalBrakingForcePresent = "True";
            engineRecords = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDC_TCON_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("67fc3894-cd1c-4755-a76c-cd9d1218f46d")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("f67d2827-4aec-477b-b6a5-8e3fb4058136")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("209913ac-0499-4799-b21d-c21c2d22bfdc")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("4852942e-6629-433e-9134-c3905bd78953")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        string _optTriggerType;

        /// <summary>
        /// Gets or sets the value of variable optTriggerType.
        /// </summary>
        [TestVariable("def5befa-8cbf-4ca8-8861-9f337c20525d")]
        public string optTriggerType
        {
            get { return _optTriggerType; }
            set { _optTriggerType = value; }
        }

        string _optPtcLocoOrientation;

        /// <summary>
        /// Gets or sets the value of variable optPtcLocoOrientation.
        /// </summary>
        [TestVariable("89b7efec-36e8-4ed8-b496-20a5f0498546")]
        public string optPtcLocoOrientation
        {
            get { return _optPtcLocoOrientation; }
            set { _optPtcLocoOrientation = value; }
        }

        string _isPTCLocoOrientationPresent;

        /// <summary>
        /// Gets or sets the value of variable isPTCLocoOrientationPresent.
        /// </summary>
        [TestVariable("bbfa95a6-9b2f-461d-aa3e-3cd0c6a4694a")]
        public string isPTCLocoOrientationPresent
        {
            get { return _isPTCLocoOrientationPresent; }
            set { _isPTCLocoOrientationPresent = value; }
        }

        string _optLoads;

        /// <summary>
        /// Gets or sets the value of variable optLoads.
        /// </summary>
        [TestVariable("1b3e5546-50fc-4bd0-9b13-676545ce45cc")]
        public string optLoads
        {
            get { return _optLoads; }
            set { _optLoads = value; }
        }

        string _optEmpties;

        /// <summary>
        /// Gets or sets the value of variable optEmpties.
        /// </summary>
        [TestVariable("98efe079-68a5-4a02-ac2c-60b0e162407d")]
        public string optEmpties
        {
            get { return _optEmpties; }
            set { _optEmpties = value; }
        }

        string _optTonnage;

        /// <summary>
        /// Gets or sets the value of variable optTonnage.
        /// </summary>
        [TestVariable("eca08f6c-a51d-410f-9f47-14e2e43d8048")]
        public string optTonnage
        {
            get { return _optTonnage; }
            set { _optTonnage = value; }
        }

        string _optLength;

        /// <summary>
        /// Gets or sets the value of variable optLength.
        /// </summary>
        [TestVariable("5726bcb0-956d-4bb9-a043-945b9aa6e035")]
        public string optLength
        {
            get { return _optLength; }
            set { _optLength = value; }
        }

        string _optAxles;

        /// <summary>
        /// Gets or sets the value of variable optAxles.
        /// </summary>
        [TestVariable("d5f19183-e678-452d-9aad-40e803ec208d")]
        public string optAxles
        {
            get { return _optAxles; }
            set { _optAxles = value; }
        }

        string _optOperativeBrakes;

        /// <summary>
        /// Gets or sets the value of variable optOperativeBrakes.
        /// </summary>
        [TestVariable("7a77c03e-11cb-4702-a12a-34312a9561ed")]
        public string optOperativeBrakes
        {
            get { return _optOperativeBrakes; }
            set { _optOperativeBrakes = value; }
        }

        string _optTotalBrakingForce;

        /// <summary>
        /// Gets or sets the value of variable optTotalBrakingForce.
        /// </summary>
        [TestVariable("67030983-6ba6-491b-ad07-dc1d3fd5cc04")]
        public string optTotalBrakingForce
        {
            get { return _optTotalBrakingForce; }
            set { _optTotalBrakingForce = value; }
        }

        string _isAxleCountPresent;

        /// <summary>
        /// Gets or sets the value of variable isAxleCountPresent.
        /// </summary>
        [TestVariable("dc909c98-9185-477d-892d-2803bd192332")]
        public string isAxleCountPresent
        {
            get { return _isAxleCountPresent; }
            set { _isAxleCountPresent = value; }
        }

        string _isOperativeBrakesPresent;

        /// <summary>
        /// Gets or sets the value of variable isOperativeBrakesPresent.
        /// </summary>
        [TestVariable("cbe0d787-fab1-4a7f-b1e0-750ed79a3abd")]
        public string isOperativeBrakesPresent
        {
            get { return _isOperativeBrakesPresent; }
            set { _isOperativeBrakesPresent = value; }
        }

        string _isTotalBrakingForcePresent;

        /// <summary>
        /// Gets or sets the value of variable isTotalBrakingForcePresent.
        /// </summary>
        [TestVariable("0e636a06-c03c-49d9-8ee3-1c10f40dc9fc")]
        public string isTotalBrakingForcePresent
        {
            get { return _isTotalBrakingForcePresent; }
            set { _isTotalBrakingForcePresent = value; }
        }

        string _engineRecords;

        /// <summary>
        /// Gets or sets the value of variable engineRecords.
        /// </summary>
        [TestVariable("09c1a8f7-2292-43e8-ae06-012bbf74a8a0")]
        public string engineRecords
        {
            get { return _engineRecords; }
            set { _engineRecords = value; }
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

            UserCodeCollections.NS_PTC_Message_Validations.ValidateDC_TCON_ByContent(trainSeed, engineSeed, engineRecords, optTriggerType, optPtcLocoOrientation, optLoads, optEmpties, optTonnage, optLength, optAxles, optOperativeBrakes, optTotalBrakingForce, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry), ValueConverter.ArgumentFromString<bool>("isPTCLocoOrientationPresent", isPTCLocoOrientationPresent), ValueConverter.ArgumentFromString<bool>("isAxleCountPresent", isAxleCountPresent), ValueConverter.ArgumentFromString<bool>("isOperativeBrakesPresent", isOperativeBrakesPresent), ValueConverter.ArgumentFromString<bool>("isTotalBrakingForcePresent", isTotalBrakingForcePresent));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
