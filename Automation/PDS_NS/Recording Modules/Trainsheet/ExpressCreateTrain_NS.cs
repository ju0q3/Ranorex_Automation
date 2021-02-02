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

namespace PDS_NS.Recording_Modules.Trainsheet
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ExpressCreateTrain_NS recording.
    /// </summary>
    [TestModule("fdd08901-1d40-4e4c-9721-99dde9bd2ce1", ModuleType.Recording, 1)]
    public partial class ExpressCreateTrain_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ExpressCreateTrain_NS instance = new ExpressCreateTrain_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ExpressCreateTrain_NS()
        {
            newTrainSeed = "";
            templateTrainSeed = "";
            expectedFeedBack = "";
            reset = "False";
            clickOnOk = "False";
            closeForm = "False";
            closeTrainSheet = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ExpressCreateTrain_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _newTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable newTrainSeed.
        /// </summary>
        [TestVariable("86a6dc37-2a92-4a7e-ab69-6e0e74c8838c")]
        public string newTrainSeed
        {
            get { return _newTrainSeed; }
            set { _newTrainSeed = value; }
        }

        string _templateTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable templateTrainSeed.
        /// </summary>
        [TestVariable("0b1b80da-7218-4413-ad33-889161126266")]
        public string templateTrainSeed
        {
            get { return _templateTrainSeed; }
            set { _templateTrainSeed = value; }
        }

        string _expectedFeedBack;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedBack.
        /// </summary>
        [TestVariable("a17b5fe3-67e4-41da-be77-bb165395cf5c")]
        public string expectedFeedBack
        {
            get { return _expectedFeedBack; }
            set { _expectedFeedBack = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("c2ae4cb8-355d-4f8d-b6c6-28c005b33118")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _clickOnOk;

        /// <summary>
        /// Gets or sets the value of variable clickOnOk.
        /// </summary>
        [TestVariable("6cef6874-5a08-440a-8fd0-f4100d33885e")]
        public string clickOnOk
        {
            get { return _clickOnOk; }
            set { _clickOnOk = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("e0df565d-38b8-4a0c-97e8-5f518487ff03")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _closeTrainSheet;

        /// <summary>
        /// Gets or sets the value of variable closeTrainSheet.
        /// </summary>
        [TestVariable("50dd6fbd-6667-422e-91ec-51245536420a")]
        public string closeTrainSheet
        {
            get { return _closeTrainSheet; }
            set { _closeTrainSheet = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ExpressCreateTrain(newTrainSeed, templateTrainSeed, expectedFeedBack, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("clickOnOk", clickOnOk), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm), ValueConverter.ArgumentFromString<bool>("closeTrainSheet", closeTrainSheet));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}