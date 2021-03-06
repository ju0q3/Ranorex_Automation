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

namespace PDS_NS.Recording_Modules.RUM.RUM_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDR_BICD_ByContent_NS recording.
    /// </summary>
    [TestModule("e6cf90d2-4c54-415d-9680-09a495a0e2a6", ModuleType.Recording, 1)]
    public partial class ValidateDR_BICD_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDR_BICD_ByContent_NS instance = new ValidateDR_BICD_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDR_BICD_ByContent_NS()
        {
            messageId = "";
            optDistrict = "";
            requestingEmployee = "";
            errorFeedback = "";
            dispatcherResponse = "";
            optMessageVersion = "";
            timeInSeconds = "0";
            retry = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDR_BICD_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _messageId;

        /// <summary>
        /// Gets or sets the value of variable messageId.
        /// </summary>
        [TestVariable("731a2d53-901e-42d2-941e-be2c26961c83")]
        public string messageId
        {
            get { return _messageId; }
            set { _messageId = value; }
        }

        string _optDistrict;

        /// <summary>
        /// Gets or sets the value of variable optDistrict.
        /// </summary>
        [TestVariable("c1bd28c8-7d55-41e7-9e21-3e6684b17052")]
        public string optDistrict
        {
            get { return _optDistrict; }
            set { _optDistrict = value; }
        }

        string _requestingEmployee;

        /// <summary>
        /// Gets or sets the value of variable requestingEmployee.
        /// </summary>
        [TestVariable("13bf422a-f0da-4a7e-ab48-9e8909e94972")]
        public string requestingEmployee
        {
            get { return _requestingEmployee; }
            set { _requestingEmployee = value; }
        }

        string _errorFeedback;

        /// <summary>
        /// Gets or sets the value of variable errorFeedback.
        /// </summary>
        [TestVariable("f3c19fa8-d7fe-4a38-8819-c0762d7369ee")]
        public string errorFeedback
        {
            get { return _errorFeedback; }
            set { _errorFeedback = value; }
        }

        string _dispatcherResponse;

        /// <summary>
        /// Gets or sets the value of variable dispatcherResponse.
        /// </summary>
        [TestVariable("32fb3a2c-a949-47af-a0da-c50db3fa3a1f")]
        public string dispatcherResponse
        {
            get { return _dispatcherResponse; }
            set { _dispatcherResponse = value; }
        }

        string _optMessageVersion;

        /// <summary>
        /// Gets or sets the value of variable optMessageVersion.
        /// </summary>
        [TestVariable("230f95c7-6801-47d5-9ca5-cabbc5621f85")]
        public string optMessageVersion
        {
            get { return _optMessageVersion; }
            set { _optMessageVersion = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("0194a5aa-e3f5-4855-9f87-32d11b04306a")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("d7139432-a290-48b7-8596-f06f91ffe921")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
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

            UserCodeCollections.NS_RUM_Message_Validations.ValidateDR_BICD_ByContent(messageId, optDistrict, requestingEmployee, errorFeedback, dispatcherResponse, optMessageVersion, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
