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
    ///The ValidateMovemenDataPopulated recording.
    /// </summary>
    [TestModule("cb1808e9-9899-4908-966c-fa769d756bac", ModuleType.Recording, 1)]
    public partial class ValidateMovemenDataPopulated : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateMovemenDataPopulated instance = new ValidateMovemenDataPopulated();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateMovemenDataPopulated()
        {
            TrainSeed = "";
            closeTrainSheet = "True";
            PlaybackMode = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateMovemenDataPopulated Instance
        {
            get { return instance; }
        }

#region Variables

        string _TrainSeed;

        /// <summary>
        /// Gets or sets the value of variable TrainSeed.
        /// </summary>
        [TestVariable("7de1b0be-7764-4f69-a536-eb603caa87e0")]
        public string TrainSeed
        {
            get { return _TrainSeed; }
            set { _TrainSeed = value; }
        }

        string _closeTrainSheet;

        /// <summary>
        /// Gets or sets the value of variable closeTrainSheet.
        /// </summary>
        [TestVariable("26b5b9a8-5049-4583-8bd0-3db3aefa9291")]
        public string closeTrainSheet
        {
            get { return _closeTrainSheet; }
            set { _closeTrainSheet = value; }
        }

        string _PlaybackMode;

        /// <summary>
        /// Gets or sets the value of variable PlaybackMode.
        /// </summary>
        [TestVariable("aaa9481c-4a81-4b83-894e-04be8e17eab5")]
        public string PlaybackMode
        {
            get { return _PlaybackMode; }
            set { _PlaybackMode = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateMovement_Populated(TrainSeed, ValueConverter.ArgumentFromString<bool>("closeTrainsheet", closeTrainSheet));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}