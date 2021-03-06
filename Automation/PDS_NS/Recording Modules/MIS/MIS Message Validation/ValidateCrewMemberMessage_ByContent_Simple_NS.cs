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

namespace PDS_NS.Recording_Modules.MIS.MIS_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateCrewMemberMessage_ByContent_Simple_NS recording.
    /// </summary>
    [TestModule("2e2c9e29-02a2-4dd4-ad87-4e0f8177c19f", ModuleType.Recording, 1)]
    public partial class ValidateCrewMemberMessage_ByContent_Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateCrewMemberMessage_ByContent_Simple_NS instance = new ValidateCrewMemberMessage_ByContent_Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateCrewMemberMessage_ByContent_Simple_NS()
        {
            trainSeed = "";
            crewSeed = "";
            otherFilters = "";
            validateDoesExist = "True";
            timeInSeconds = "5";
            retry = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateCrewMemberMessage_ByContent_Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("27acfef5-bb5d-40c7-b9a7-46f74f1660f2")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("a2dd1ff8-56ca-4831-8958-083ffbaf94ef")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _otherFilters;

        /// <summary>
        /// Gets or sets the value of variable otherFilters.
        /// </summary>
        [TestVariable("161484a2-a49a-4458-b8ee-b03a24f96bed")]
        public string otherFilters
        {
            get { return _otherFilters; }
            set { _otherFilters = value; }
        }

        string _validateDoesExist;

        /// <summary>
        /// Gets or sets the value of variable validateDoesExist.
        /// </summary>
        [TestVariable("8667f311-be2d-423b-9a98-06f7482da44e")]
        public string validateDoesExist
        {
            get { return _validateDoesExist; }
            set { _validateDoesExist = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("324f7a56-a2c1-4cdc-a8d4-c9561878b2ac")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("ee63d2c3-4744-4abf-a74e-28763b69a737")]
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

            UserCodeCollections.NS_MIS_Messages.NS_ValidateCrewMemberMessage_ByContent_Simple(trainSeed, crewSeed, otherFilters, ValueConverter.ArgumentFromString<bool>("validateDoesExist", validateDoesExist), ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
