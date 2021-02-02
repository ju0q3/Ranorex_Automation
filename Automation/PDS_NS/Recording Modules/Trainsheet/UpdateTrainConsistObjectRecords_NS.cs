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
    ///The UpdateTrainConsistObjectRecords_NS recording.
    /// </summary>
    [TestModule("130316da-f966-45d9-80fd-f66bad69135a", ModuleType.Recording, 1)]
    public partial class UpdateTrainConsistObjectRecords_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static UpdateTrainConsistObjectRecords_NS instance = new UpdateTrainConsistObjectRecords_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public UpdateTrainConsistObjectRecords_NS()
        {
            trainSeed = "";
            consistSeed = "";
            opsta = "";
            loads = "";
            empties = "";
            tons = "";
            length = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static UpdateTrainConsistObjectRecords_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("5a9e6501-9b3b-475c-96d3-3a94a3cbde4e")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _consistSeed;

        /// <summary>
        /// Gets or sets the value of variable consistSeed.
        /// </summary>
        [TestVariable("45c89888-e153-4030-8c99-475a4abb02ac")]
        public string consistSeed
        {
            get { return _consistSeed; }
            set { _consistSeed = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("9e76c986-c712-4d19-80f7-72ae9a34ccc3")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _loads;

        /// <summary>
        /// Gets or sets the value of variable loads.
        /// </summary>
        [TestVariable("714f7cda-17ce-4539-94b5-87628ddd32ef")]
        public string loads
        {
            get { return _loads; }
            set { _loads = value; }
        }

        string _empties;

        /// <summary>
        /// Gets or sets the value of variable empties.
        /// </summary>
        [TestVariable("c09b107e-2404-4ae5-a05a-aa4b5e0e96c7")]
        public string empties
        {
            get { return _empties; }
            set { _empties = value; }
        }

        string _tons;

        /// <summary>
        /// Gets or sets the value of variable tons.
        /// </summary>
        [TestVariable("547660cd-be14-4f45-9778-e443167d616a")]
        public string tons
        {
            get { return _tons; }
            set { _tons = value; }
        }

        string _length;

        /// <summary>
        /// Gets or sets the value of variable length.
        /// </summary>
        [TestVariable("53ce2e40-7e2c-46fe-907e-196475abcf7d")]
        public string length
        {
            get { return _length; }
            set { _length = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_UpdateTrainConsistSummaryConsistObjectRecords_NS(trainSeed, consistSeed, opsta, loads, empties, tons, length);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}