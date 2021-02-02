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
    ///The NS_ValidateSuggestionInTaskList recording.
    /// </summary>
    [TestModule("1a2ba87a-2bdb-4987-86e4-2bd579d513c5", ModuleType.Recording, 1)]
    public partial class NS_ValidateSuggestionInTaskList : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateSuggestionInTaskList instance = new NS_ValidateSuggestionInTaskList();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateSuggestionInTaskList()
        {
            trainSeed = "";
            expectedAt = "";
            expectedFrom = "";
            expectedTo = "";
            clearMain = "False";
            holdMain = "False";
            engineSeed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateSuggestionInTaskList Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("61ac978c-7b0c-4988-bf92-f16f6d9b7e47")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _expectedAt;

        /// <summary>
        /// Gets or sets the value of variable expectedAt.
        /// </summary>
        [TestVariable("857cd57b-254a-4d85-9e73-be67f8666263")]
        public string expectedAt
        {
            get { return _expectedAt; }
            set { _expectedAt = value; }
        }

        string _expectedFrom;

        /// <summary>
        /// Gets or sets the value of variable expectedFrom.
        /// </summary>
        [TestVariable("c718a9c6-5243-41cf-b1f6-6513a5c310bf")]
        public string expectedFrom
        {
            get { return _expectedFrom; }
            set { _expectedFrom = value; }
        }

        string _expectedTo;

        /// <summary>
        /// Gets or sets the value of variable expectedTo.
        /// </summary>
        [TestVariable("d86b0778-bab9-4e05-ac06-c8ad863ec64c")]
        public string expectedTo
        {
            get { return _expectedTo; }
            set { _expectedTo = value; }
        }

        string _clearMain;

        /// <summary>
        /// Gets or sets the value of variable clearMain.
        /// </summary>
        [TestVariable("e7d35941-33c6-4742-b3b0-7b07807a30dd")]
        public string clearMain
        {
            get { return _clearMain; }
            set { _clearMain = value; }
        }

        string _holdMain;

        /// <summary>
        /// Gets or sets the value of variable holdMain.
        /// </summary>
        [TestVariable("ce861e2d-730d-4fdc-8c52-a621d4426f5e")]
        public string holdMain
        {
            get { return _holdMain; }
            set { _holdMain = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("9b38f78e-e6d7-498e-befd-295799622bd0")]
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

            UserCodeCollections.NS_Miscellaneous.NS_ValidateLimitSuggestionContentInTaskList(trainSeed, engineSeed, expectedAt, expectedFrom, expectedTo, ValueConverter.ArgumentFromString<bool>("clearMain", clearMain), ValueConverter.ArgumentFromString<bool>("holdMain", holdMain));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}