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
    ///The ValidateEOTCabooseRecord_NS recording.
    /// </summary>
    [TestModule("c9d701c4-7891-4351-a12b-f6194165fb38", ModuleType.Recording, 1)]
    public partial class ValidateEOTCabooseRecord_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateEOTCabooseRecord_NS instance = new ValidateEOTCabooseRecord_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateEOTCabooseRecord_NS()
        {
            trainSeed = "";
            engineInitial = "";
            engineNumber = "";
            validateDoesExist = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateEOTCabooseRecord_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("0209c6b7-58ba-4446-bd5a-1ce3bb0b4328")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _engineInitial;

        /// <summary>
        /// Gets or sets the value of variable engineInitial.
        /// </summary>
        [TestVariable("65d0aa2a-d90c-4321-9cd5-41d95c476e76")]
        public string engineInitial
        {
            get { return _engineInitial; }
            set { _engineInitial = value; }
        }

        string _engineNumber;

        /// <summary>
        /// Gets or sets the value of variable engineNumber.
        /// </summary>
        [TestVariable("a7d8ed79-d039-4512-af4d-5d6b29ea468a")]
        public string engineNumber
        {
            get { return _engineNumber; }
            set { _engineNumber = value; }
        }

        string _validateDoesExist;

        /// <summary>
        /// Gets or sets the value of variable validateDoesExist.
        /// </summary>
        [TestVariable("891cee05-41c9-48d2-9b11-873bbe032651")]
        public string validateDoesExist
        {
            get { return _validateDoesExist; }
            set { _validateDoesExist = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateEOTCabooseRecord_TrainSheet(trainSeed, engineInitial, engineNumber, ValueConverter.ArgumentFromString<bool>("validateDoesExist", validateDoesExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
