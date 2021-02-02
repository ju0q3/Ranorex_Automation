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

namespace PDS_NS.Recording_Modules.Train_Status_Summary
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The FillTerminateShort_NS recording.
    /// </summary>
    [TestModule("3ca4fda8-f8a1-4096-9237-b123cc2d9cc5", ModuleType.Recording, 1)]
    public partial class FillTerminateShort_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static FillTerminateShort_NS instance = new FillTerminateShort_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FillTerminateShort_NS()
        {
            fromTrainSeed = "";
            toTrainSeed = "";
            opsta = "";
            copyTrainEngine = "False";
            additionalInfo = "";
            expectedFeedback = "";
            clickOk = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static FillTerminateShort_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _fromTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable fromTrainSeed.
        /// </summary>
        [TestVariable("9d67d71f-f69a-4d0c-bae4-d772259ab742")]
        public string fromTrainSeed
        {
            get { return _fromTrainSeed; }
            set { _fromTrainSeed = value; }
        }

        string _toTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable toTrainSeed.
        /// </summary>
        [TestVariable("e77dedaf-dd46-4ea0-b862-ab9da4cd252d")]
        public string toTrainSeed
        {
            get { return _toTrainSeed; }
            set { _toTrainSeed = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("954d54d2-e3d2-4ade-b8ca-ac1ffb50f513")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _copyTrainEngine;

        /// <summary>
        /// Gets or sets the value of variable copyTrainEngine.
        /// </summary>
        [TestVariable("25d51d3e-b353-4949-8e5e-e7e80727ee0d")]
        public string copyTrainEngine
        {
            get { return _copyTrainEngine; }
            set { _copyTrainEngine = value; }
        }

        string _additionalInfo;

        /// <summary>
        /// Gets or sets the value of variable additionalInfo.
        /// </summary>
        [TestVariable("3e7f1d3b-d81b-4626-9d77-36daf654096f")]
        public string additionalInfo
        {
            get { return _additionalInfo; }
            set { _additionalInfo = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("cf360368-e544-402e-8978-97f30f1b750f")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _clickOk;

        /// <summary>
        /// Gets or sets the value of variable clickOk.
        /// </summary>
        [TestVariable("c5b11ae9-b96e-4bf9-b2f6-d831b24987cb")]
        public string clickOk
        {
            get { return _clickOk; }
            set { _clickOk = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("1ee01458-e57c-4024-a44e-8700f37c324f")]
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

            UserCodeCollections.NS_Trainsheet.NS_FillTerminateShort(fromTrainSeed, toTrainSeed, opsta, ValueConverter.ArgumentFromString<bool>("copyTrainEngine", copyTrainEngine), additionalInfo, expectedFeedback, ValueConverter.ArgumentFromString<bool>("clickOk", clickOk), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
