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

namespace PDS_NS.Recording_Modules.TrainClearance
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The IssueTrainClearanceForChangeRoute_TrainClearanceForm recording.
    /// </summary>
    [TestModule("9efd1a24-8a1b-44e3-9457-c04dd15e8e8a", ModuleType.Recording, 1)]
    public partial class IssueTrainClearanceForChangeRoute_TrainClearanceForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static IssueTrainClearanceForChangeRoute_TrainClearanceForm instance = new IssueTrainClearanceForChangeRoute_TrainClearanceForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public IssueTrainClearanceForChangeRoute_TrainClearanceForm()
        {
            trainSeed = "";
            crewOrigin = "";
            crewDestination = "";
            expectedFeedback = "";
            closeForms = "False";
            originPasscount = "";
            destPasscount = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static IssueTrainClearanceForChangeRoute_TrainClearanceForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("aa18a965-6b4f-47a3-9462-c50431c7c07d")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewOrigin;

        /// <summary>
        /// Gets or sets the value of variable crewOrigin.
        /// </summary>
        [TestVariable("93bc3b4f-0712-4276-9d33-3e67ae2c268b")]
        public string crewOrigin
        {
            get { return _crewOrigin; }
            set { _crewOrigin = value; }
        }

        string _crewDestination;

        /// <summary>
        /// Gets or sets the value of variable crewDestination.
        /// </summary>
        [TestVariable("f46b3da4-5589-4443-954c-c2c0928a7b1a")]
        public string crewDestination
        {
            get { return _crewDestination; }
            set { _crewDestination = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("5c43f9c1-3937-41b0-ade9-23432d98ad4a")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("27b6fc2c-9280-46a9-a55a-5d1d9cd75b85")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _originPasscount;

        /// <summary>
        /// Gets or sets the value of variable originPasscount.
        /// </summary>
        [TestVariable("9dab629d-6a56-4b8e-90b3-4f437529df52")]
        public string originPasscount
        {
            get { return _originPasscount; }
            set { _originPasscount = value; }
        }

        string _destPasscount;

        /// <summary>
        /// Gets or sets the value of variable destPasscount.
        /// </summary>
        [TestVariable("f1f1e294-290c-4ca7-9bfe-838d4afe599d")]
        public string destPasscount
        {
            get { return _destPasscount; }
            set { _destPasscount = value; }
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

            UserCodeCollections.NS_TrainClearance.NS_IssueTrainClearanceForChangeRoute_TrainClearanceForm(trainSeed, crewOrigin, originPasscount, crewDestination, destPasscount, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}