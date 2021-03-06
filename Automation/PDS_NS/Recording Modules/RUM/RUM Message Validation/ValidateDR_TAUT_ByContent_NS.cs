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
    ///The ValidateDR_TAUT_ByContent_NS recording.
    /// </summary>
    [TestModule("b261189f-9813-4026-a9aa-8c476f81d2f5", ModuleType.Recording, 1)]
    public partial class ValidateDR_TAUT_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDR_TAUT_ByContent_NS instance = new ValidateDR_TAUT_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDR_TAUT_ByContent_NS()
        {
            authoritySeed = "";
            action = "";
            district = "";
            crewAckRequired = "False";
            timeInSeconds = "5";
            retry = "False";
            optAdditionalFilters = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDR_TAUT_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("f43e7dcf-5ee6-4f1c-8d4d-ea8f3a37738e")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("c5104534-1294-4051-80ef-92648eedc709")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("a7b4a2af-6de3-4d8e-8d23-17b4b63b0853")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _crewAckRequired;

        /// <summary>
        /// Gets or sets the value of variable crewAckRequired.
        /// </summary>
        [TestVariable("e8a43de9-3817-4fd8-895d-d705450f3fd7")]
        public string crewAckRequired
        {
            get { return _crewAckRequired; }
            set { _crewAckRequired = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("6cfdf13a-2cc1-4bbf-b7dc-e501882825a3")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("e928f069-7e8b-4137-8870-6e870e38dbf9")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        string _optAdditionalFilters;

        /// <summary>
        /// Gets or sets the value of variable optAdditionalFilters.
        /// </summary>
        [TestVariable("08598f16-ab7f-4df9-b953-67ace2e8a40f")]
        public string optAdditionalFilters
        {
            get { return _optAdditionalFilters; }
            set { _optAdditionalFilters = value; }
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

            UserCodeCollections.NS_RUM_Message_Validations.ValidateDR_TAUT_ByContent(authoritySeed, action, district, ValueConverter.ArgumentFromString<bool>("crewAckRequired", crewAckRequired), optAdditionalFilters, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
