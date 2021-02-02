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

namespace PDS_NS.Recording_Modules.Task_List
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateLimitSuggestionPresentForTrain recording.
    /// </summary>
    [TestModule("8805137f-d3cd-43af-932f-3563388cbf1f", ModuleType.Recording, 1)]
    public partial class ValidateLimitSuggestionPresentForTrain : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateLimitSuggestionPresentForTrain instance = new ValidateLimitSuggestionPresentForTrain();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateLimitSuggestionPresentForTrain()
        {
            trainSeed = "";
            expectedPresence = "True";
            closeForms = "true";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateLimitSuggestionPresentForTrain Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("cea0d862-bd8b-42ae-b486-37c5c1e01f33")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _expectedPresence;

        /// <summary>
        /// Gets or sets the value of variable expectedPresence.
        /// </summary>
        [TestVariable("51e0539b-9578-46c0-ae68-0454c30dacdc")]
        public string expectedPresence
        {
            get { return _expectedPresence; }
            set { _expectedPresence = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("e73ee1ca-8f41-40f3-bea6-fe15405f5dd9")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_Miscellaneous.NS_ValidateLimitSuggestionPresentForTrain(trainSeed, ValueConverter.ArgumentFromString<bool>("expectedPresence", expectedPresence), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}