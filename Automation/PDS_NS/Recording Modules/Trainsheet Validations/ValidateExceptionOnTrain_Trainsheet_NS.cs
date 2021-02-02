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
    ///The ValidateExceptionOnTrain_Trainsheet_NS recording.
    /// </summary>
    [TestModule("519eb32a-d8c6-42fa-8f56-820ddce58948", ModuleType.Recording, 1)]
    public partial class ValidateExceptionOnTrain_Trainsheet_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateExceptionOnTrain_Trainsheet_NS instance = new ValidateExceptionOnTrain_Trainsheet_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateExceptionOnTrain_Trainsheet_NS()
        {
            trainSeed_toValidate = "";
            trainSeed_inException = "";
            expExceptionMsg = "";
            validateExist = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateExceptionOnTrain_Trainsheet_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed_toValidate;

        /// <summary>
        /// Gets or sets the value of variable trainSeed_toValidate.
        /// </summary>
        [TestVariable("e9e0501a-f612-4b5a-9927-d182c8ed766d")]
        public string trainSeed_toValidate
        {
            get { return _trainSeed_toValidate; }
            set { _trainSeed_toValidate = value; }
        }

        string _trainSeed_inException;

        /// <summary>
        /// Gets or sets the value of variable trainSeed_inException.
        /// </summary>
        [TestVariable("b8e8c65d-21ae-4d6e-b27b-0b1da609bcc0")]
        public string trainSeed_inException
        {
            get { return _trainSeed_inException; }
            set { _trainSeed_inException = value; }
        }

        string _expExceptionMsg;

        /// <summary>
        /// Gets or sets the value of variable expExceptionMsg.
        /// </summary>
        [TestVariable("70596688-cdc6-435d-a26b-7c33e3b1afa4")]
        public string expExceptionMsg
        {
            get { return _expExceptionMsg; }
            set { _expExceptionMsg = value; }
        }

        string _validateExist;

        /// <summary>
        /// Gets or sets the value of variable validateExist.
        /// </summary>
        [TestVariable("34f86455-1c94-4c43-9c5a-3cfa3fb95212")]
        public string validateExist
        {
            get { return _validateExist; }
            set { _validateExist = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("40d7a50e-560d-48b2-933d-f25e2fc51bc5")]
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateExceptionOnTrain_Trainsheet(trainSeed_toValidate, trainSeed_inException, expExceptionMsg, ValueConverter.ArgumentFromString<bool>("validateExist", validateExist), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}