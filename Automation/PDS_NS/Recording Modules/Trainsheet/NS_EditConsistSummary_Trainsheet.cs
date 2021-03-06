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
    ///The NS_EditConsistSummary_Trainsheet recording.
    /// </summary>
    [TestModule("68dd5838-8d00-4efd-8631-e463da563242", ModuleType.Recording, 1)]
    public partial class NS_EditConsistSummary_Trainsheet : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_EditConsistSummary_Trainsheet instance = new NS_EditConsistSummary_Trainsheet();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_EditConsistSummary_Trainsheet()
        {
            trainSeed = "";
            filterOpsta = "";
            updatePass = "";
            updateLoads = "";
            updateEmpties = "";
            updateTons = "";
            updateLength = "";
            expectedFeedback = "";
            closeForms = "False";
            updateOpsta = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_EditConsistSummary_Trainsheet Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("ed760bee-652c-4292-8bcf-7bd12615b6f5")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _filterOpsta;

        /// <summary>
        /// Gets or sets the value of variable filterOpsta.
        /// </summary>
        [TestVariable("b3df1f55-d0b5-4581-9494-870806e4f882")]
        public string filterOpsta
        {
            get { return _filterOpsta; }
            set { _filterOpsta = value; }
        }

        string _updatePass;

        /// <summary>
        /// Gets or sets the value of variable updatePass.
        /// </summary>
        [TestVariable("fcbf17ef-d825-4206-a61f-7be592e70fb2")]
        public string updatePass
        {
            get { return _updatePass; }
            set { _updatePass = value; }
        }

        string _updateLoads;

        /// <summary>
        /// Gets or sets the value of variable updateLoads.
        /// </summary>
        [TestVariable("b055bc91-22f0-42bb-a5d1-1a1bcf8a248d")]
        public string updateLoads
        {
            get { return _updateLoads; }
            set { _updateLoads = value; }
        }

        string _updateEmpties;

        /// <summary>
        /// Gets or sets the value of variable updateEmpties.
        /// </summary>
        [TestVariable("bd5a6fea-cb2d-40ac-8428-89a4eeaca4ae")]
        public string updateEmpties
        {
            get { return _updateEmpties; }
            set { _updateEmpties = value; }
        }

        string _updateTons;

        /// <summary>
        /// Gets or sets the value of variable updateTons.
        /// </summary>
        [TestVariable("53b3ea02-4c40-4081-abe0-77cae205785f")]
        public string updateTons
        {
            get { return _updateTons; }
            set { _updateTons = value; }
        }

        string _updateLength;

        /// <summary>
        /// Gets or sets the value of variable updateLength.
        /// </summary>
        [TestVariable("a98848c9-1ca3-4e37-8e73-580ddca8cd53")]
        public string updateLength
        {
            get { return _updateLength; }
            set { _updateLength = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("432dc123-1dd5-4cc1-81de-aa9109a68035")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("310f8240-e85b-4af9-aaee-5dad28954504")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _updateOpsta;

        /// <summary>
        /// Gets or sets the value of variable updateOpsta.
        /// </summary>
        [TestVariable("0272deca-8f98-467b-8dcf-03cdbd9600dc")]
        public string updateOpsta
        {
            get { return _updateOpsta; }
            set { _updateOpsta = value; }
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

            UserCodeCollections.NS_Trainsheet.EditConsistSummary_Trainsheet(trainSeed, filterOpsta, updateOpsta, updatePass, updateLoads, updateEmpties, updateTons, updateLength, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
