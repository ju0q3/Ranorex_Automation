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
    ///The Validate_PTCCrewLogoffMessage_TrainHistory_NS recording.
    /// </summary>
    [TestModule("24e7509f-0dd0-4f55-8004-7916f4eb278f", ModuleType.Recording, 1)]
    public partial class Validate_PTCCrewLogoffMessage_TrainHistory_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_PTCCrewLogoffMessage_TrainHistory_NS instance = new Validate_PTCCrewLogoffMessage_TrainHistory_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_PTCCrewLogoffMessage_TrainHistory_NS()
        {
            trainSeed = "";
            optDistrict = "";
            signoffType = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_PTCCrewLogoffMessage_TrainHistory_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("252e5fcb-13d7-41f5-bcae-e27f8688a056")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _optDistrict;

        /// <summary>
        /// Gets or sets the value of variable optDistrict.
        /// </summary>
        [TestVariable("6a50b543-f0f1-4c53-8714-33f88526876c")]
        public string optDistrict
        {
            get { return _optDistrict; }
            set { _optDistrict = value; }
        }

        string _signoffType;

        /// <summary>
        /// Gets or sets the value of variable signoffType.
        /// </summary>
        [TestVariable("95f4be46-9f6d-4f11-a49b-b50fad814609")]
        public string signoffType
        {
            get { return _signoffType; }
            set { _signoffType = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("418127c2-2a4e-4718-8c56-4d50555357f2")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_Validate_PTCCrewLogoffMessage_TrainHistory(trainSeed, optDistrict, signoffType, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}