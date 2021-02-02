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
    ///The OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS recording.
    /// </summary>
    [TestModule("98fa343f-37a5-4bc9-a004-d5eec7a498c7", ModuleType.Recording, 1)]
    public partial class OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS instance = new OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS()
        {
            trainSeed = "";
            crewOriginStation = "";
            originPassCount = "";
            intermediateStation = "";
            crewDestinationStation = "";
            destinationPasscount = "";
            pressOk = "False";
            closeForm = "False";
            issueNew = "False";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenAndEditTrainClearanceRouteForm_TrainClearanceForm_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("f6d4cf21-237b-48e1-9793-630a4df866ea")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewOriginStation;

        /// <summary>
        /// Gets or sets the value of variable crewOriginStation.
        /// </summary>
        [TestVariable("cbb12d2c-1754-4430-bd14-db9882afed17")]
        public string crewOriginStation
        {
            get { return _crewOriginStation; }
            set { _crewOriginStation = value; }
        }

        string _originPassCount;

        /// <summary>
        /// Gets or sets the value of variable originPassCount.
        /// </summary>
        [TestVariable("3c6bdb62-c3fe-4aa4-a1cd-eae6d82c85de")]
        public string originPassCount
        {
            get { return _originPassCount; }
            set { _originPassCount = value; }
        }

        string _intermediateStation;

        /// <summary>
        /// Gets or sets the value of variable intermediateStation.
        /// </summary>
        [TestVariable("48de7f2d-d506-4da4-afb4-0edcaa3cf173")]
        public string intermediateStation
        {
            get { return _intermediateStation; }
            set { _intermediateStation = value; }
        }

        string _crewDestinationStation;

        /// <summary>
        /// Gets or sets the value of variable crewDestinationStation.
        /// </summary>
        [TestVariable("8cd6b1d3-c7fa-4292-9a16-268d7c2b768e")]
        public string crewDestinationStation
        {
            get { return _crewDestinationStation; }
            set { _crewDestinationStation = value; }
        }

        string _destinationPasscount;

        /// <summary>
        /// Gets or sets the value of variable destinationPasscount.
        /// </summary>
        [TestVariable("b73adff0-e853-4b22-962b-99cb24a67335")]
        public string destinationPasscount
        {
            get { return _destinationPasscount; }
            set { _destinationPasscount = value; }
        }

        string _pressOk;

        /// <summary>
        /// Gets or sets the value of variable pressOk.
        /// </summary>
        [TestVariable("253c28b3-65e6-443d-b56d-ea2673144418")]
        public string pressOk
        {
            get { return _pressOk; }
            set { _pressOk = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("cb74511e-ff74-45aa-8973-188848a53a24")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _issueNew;

        /// <summary>
        /// Gets or sets the value of variable issueNew.
        /// </summary>
        [TestVariable("d1d3442e-c4cf-4cf0-9ca8-a9d2ba1c5370")]
        public string issueNew
        {
            get { return _issueNew; }
            set { _issueNew = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("71d8765b-f0f3-4559-a739-dcc48c9d5231")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_TrainClearance.NS_OpenAndEditTrainClearanceRouteForm_TrainClearanceForm(trainSeed, crewOriginStation, originPassCount, intermediateStation, crewDestinationStation, destinationPasscount, ValueConverter.ArgumentFromString<bool>("issueNew", issueNew), expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressOk", pressOk), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}