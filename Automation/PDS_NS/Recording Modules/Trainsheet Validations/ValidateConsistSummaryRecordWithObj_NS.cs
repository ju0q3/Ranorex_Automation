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

namespace PDS_NS.Recording_Modules.Trainsheet_Validations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateConsistSummaryRecordWithObj_NS recording.
    /// </summary>
    [TestModule("aef77218-415b-4f24-8f72-5f2cb0770305", ModuleType.Recording, 1)]
    public partial class ValidateConsistSummaryRecordWithObj_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateConsistSummaryRecordWithObj_NS instance = new ValidateConsistSummaryRecordWithObj_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateConsistSummaryRecordWithObj_NS()
        {
            trainSeed = "";
            consistSeed = "";
            nameOfOpsta = "";
            closeForms = "true";
            validateDoesExist = "True";
            iteration = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateConsistSummaryRecordWithObj_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("82a720cc-33b1-4c54-802f-b61a4f17753f")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _consistSeed;

        /// <summary>
        /// Gets or sets the value of variable consistSeed.
        /// </summary>
        [TestVariable("1b712edd-1076-4e9b-86e4-cbf7fdbc5bc4")]
        public string consistSeed
        {
            get { return _consistSeed; }
            set { _consistSeed = value; }
        }

        string _nameOfOpsta;

        /// <summary>
        /// Gets or sets the value of variable nameOfOpsta.
        /// </summary>
        [TestVariable("4f45fb5c-d7bd-4bc8-af2b-f2c90b2e3083")]
        public string nameOfOpsta
        {
            get { return _nameOfOpsta; }
            set { _nameOfOpsta = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("419c3244-2805-4870-8164-53bf82bf0003")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _validateDoesExist;

        /// <summary>
        /// Gets or sets the value of variable validateDoesExist.
        /// </summary>
        [TestVariable("dded3a82-2727-4c75-b650-a8ce7839d14d")]
        public string validateDoesExist
        {
            get { return _validateDoesExist; }
            set { _validateDoesExist = value; }
        }

        string _iteration;

        /// <summary>
        /// Gets or sets the value of variable iteration.
        /// </summary>
        [TestVariable("d84a7559-cd82-464d-8aea-e6d7e07028b5")]
        public string iteration
        {
            get { return _iteration; }
            set { _iteration = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateConsistSummaryRecordWithObj_TrainSheet(trainSeed, consistSeed, nameOfOpsta, ValueConverter.ArgumentFromString<bool>("closeTrainSheet", closeForms), ValueConverter.ArgumentFromString<bool>("validateDoesExist", validateDoesExist), ValueConverter.ArgumentFromString<int>("iteration", iteration));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
