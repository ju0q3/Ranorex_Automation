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
    ///The AddConsistSummary_Trainsheet_NS recording.
    /// </summary>
    [TestModule("7f13aa57-d824-42f3-928f-40e6d95f8fdc", ModuleType.Recording, 1)]
    public partial class AddConsistSummary_Trainsheet_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static AddConsistSummary_Trainsheet_NS instance = new AddConsistSummary_Trainsheet_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddConsistSummary_Trainsheet_NS()
        {
            trainSeed = "";
            opsta = "";
            passCount = "";
            loads = "";
            empties = "";
            tons = "";
            length = "";
            expectedFeedback = "";
            closeForms = "False";
            optConsistSeed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddConsistSummary_Trainsheet_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("0853920c-230f-49ce-8077-20e38e5e4c53")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("9e9b6e8c-21c8-4dd8-aa8f-1a12d1fad4d4")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _passCount;

        /// <summary>
        /// Gets or sets the value of variable passCount.
        /// </summary>
        [TestVariable("e733895e-70c7-4173-8286-d6afa911d551")]
        public string passCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        string _loads;

        /// <summary>
        /// Gets or sets the value of variable loads.
        /// </summary>
        [TestVariable("d6695264-ff83-4f14-85df-05adc67a32f3")]
        public string loads
        {
            get { return _loads; }
            set { _loads = value; }
        }

        string _empties;

        /// <summary>
        /// Gets or sets the value of variable empties.
        /// </summary>
        [TestVariable("fef4d582-7847-40d7-9290-9bd96e74927f")]
        public string empties
        {
            get { return _empties; }
            set { _empties = value; }
        }

        string _tons;

        /// <summary>
        /// Gets or sets the value of variable tons.
        /// </summary>
        [TestVariable("7980fb28-20bc-4d69-a63b-f83f1c30e044")]
        public string tons
        {
            get { return _tons; }
            set { _tons = value; }
        }

        string _length;

        /// <summary>
        /// Gets or sets the value of variable length.
        /// </summary>
        [TestVariable("b50e7122-deaa-49c0-ad0e-0d773b62da20")]
        public string length
        {
            get { return _length; }
            set { _length = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("270cce02-eccc-479c-8b71-c30ade9fb60b")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("05e2e7ae-2fcb-436e-ae48-a0fe731f3d30")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _optConsistSeed;

        /// <summary>
        /// Gets or sets the value of variable optConsistSeed.
        /// </summary>
        [TestVariable("416325da-89d2-45fd-9f9c-6c914eb45c95")]
        public string optConsistSeed
        {
            get { return _optConsistSeed; }
            set { _optConsistSeed = value; }
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

            UserCodeCollections.NS_Trainsheet.AddConsistSummary_Trainsheet(trainSeed, opsta, passCount, loads, empties, tons, length, optConsistSeed, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
