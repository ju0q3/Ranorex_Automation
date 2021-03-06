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
    ///The NS_ManuallyAddEOTCaboose_Trainsheet recording.
    /// </summary>
    [TestModule("a7bb358b-32a0-4f5e-9a93-b35ba917af8d", ModuleType.Recording, 1)]
    public partial class NS_ManuallyAddEOTCaboose_Trainsheet : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ManuallyAddEOTCaboose_Trainsheet instance = new NS_ManuallyAddEOTCaboose_Trainsheet();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ManuallyAddEOTCaboose_Trainsheet()
        {
            trainSeed = "";
            type = "";
            workingStatus = "";
            origin = "";
            destination = "";
            expectedFeedback = "";
            closeForms = "False";
            initial = "";
            number = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ManuallyAddEOTCaboose_Trainsheet Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("9064adc5-0a6b-41d4-930d-525012f52b1e")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("c9a62f09-ed83-4d51-957a-cb8c81cdc899")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        string _workingStatus;

        /// <summary>
        /// Gets or sets the value of variable workingStatus.
        /// </summary>
        [TestVariable("ac527e6d-cd88-4462-b504-f6394b854858")]
        public string workingStatus
        {
            get { return _workingStatus; }
            set { _workingStatus = value; }
        }

        string _origin;

        /// <summary>
        /// Gets or sets the value of variable origin.
        /// </summary>
        [TestVariable("e10c3cc5-4556-40b6-9919-d5ff759e5e8f")]
        public string origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        string _destination;

        /// <summary>
        /// Gets or sets the value of variable destination.
        /// </summary>
        [TestVariable("78ad9c5c-0ac9-461c-970b-7f363dcbe40d")]
        public string destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("31a08669-be30-40e0-8615-752bd68ab13d")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("47e4af94-164c-40a2-b7ec-60b00e4a7a1e")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _initial;

        /// <summary>
        /// Gets or sets the value of variable initial.
        /// </summary>
        [TestVariable("6916321d-beeb-45ce-b69b-c3132152f577")]
        public string initial
        {
            get { return _initial; }
            set { _initial = value; }
        }

        string _number;

        /// <summary>
        /// Gets or sets the value of variable number.
        /// </summary>
        [TestVariable("b4b02697-17e7-4d9d-8fb2-fa7902ab9092")]
        public string number
        {
            get { return _number; }
            set { _number = value; }
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

            UserCodeCollections.NS_Trainsheet.ManuallyAddEOTCaboose_Trainsheet_NS(trainSeed, type, workingStatus, initial, number, origin, destination, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
