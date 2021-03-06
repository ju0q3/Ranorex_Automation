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

namespace PDS_NS.Recording_Modules.TAC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateSuggestionInSummaryList recording.
    /// </summary>
    [TestModule("f4efab12-4651-4a49-a7b6-bfb339790f3c", ModuleType.Recording, 1)]
    public partial class ValidateSuggestionInSummaryList : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateSuggestionInSummaryList instance = new ValidateSuggestionInSummaryList();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateSuggestionInSummaryList()
        {
            trainSeed = "";
            expectedAt = "";
            expectedFrom = "";
            expectedTo = "";
            clearMain = "False";
            holdMain = "False";
            territory = "";
            engineSeed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateSuggestionInSummaryList Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("2d1468b3-1a82-494b-aa93-66e9c04ca8a6")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _expectedAt;

        /// <summary>
        /// Gets or sets the value of variable expectedAt.
        /// </summary>
        [TestVariable("bdb68cd7-14bb-479f-bfe8-7a9f8999af2b")]
        public string expectedAt
        {
            get { return _expectedAt; }
            set { _expectedAt = value; }
        }

        string _expectedFrom;

        /// <summary>
        /// Gets or sets the value of variable expectedFrom.
        /// </summary>
        [TestVariable("7a47ea1d-5743-470f-8b2d-9d32c81b32c7")]
        public string expectedFrom
        {
            get { return _expectedFrom; }
            set { _expectedFrom = value; }
        }

        string _expectedTo;

        /// <summary>
        /// Gets or sets the value of variable expectedTo.
        /// </summary>
        [TestVariable("056d4466-14d3-4d3c-ab06-d60307283719")]
        public string expectedTo
        {
            get { return _expectedTo; }
            set { _expectedTo = value; }
        }

        string _clearMain;

        /// <summary>
        /// Gets or sets the value of variable clearMain.
        /// </summary>
        [TestVariable("1d82e274-2990-4315-990b-dc9adf2122fa")]
        public string clearMain
        {
            get { return _clearMain; }
            set { _clearMain = value; }
        }

        string _holdMain;

        /// <summary>
        /// Gets or sets the value of variable holdMain.
        /// </summary>
        [TestVariable("4f3ab18f-1713-4649-990d-9615354e734a")]
        public string holdMain
        {
            get { return _holdMain; }
            set { _holdMain = value; }
        }

        string _territory;

        /// <summary>
        /// Gets or sets the value of variable territory.
        /// </summary>
        [TestVariable("7792d244-ac50-4080-9b06-5cffb47213be")]
        public string territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("6a60c2e9-c628-4730-84f1-5f0871baf1fe")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
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

            UserCodeCollections.NS_Miscellaneous.NS_ValidateLimitSuggestionContentInSummaryList(trainSeed, engineSeed, expectedAt, expectedFrom, expectedTo, ValueConverter.ArgumentFromString<bool>("clearMain", clearMain), ValueConverter.ArgumentFromString<bool>("holdMain", holdMain), territory);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
