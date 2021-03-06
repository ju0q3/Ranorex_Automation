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

namespace PDS_NS.Recording_Modules.EMT
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Validate_EMT_OnTrackLine_NS recording.
    /// </summary>
    [TestModule("3c4245db-760a-4f55-a198-21a7657dd293", ModuleType.Recording, 1)]
    public partial class Validate_EMT_OnTrackLine_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_EMT_OnTrackLine_NS instance = new Validate_EMT_OnTrackLine_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_EMT_OnTrackLine_NS()
        {
            trainSeed = "";
            trackSectionId = "";
            validateExist = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_EMT_OnTrackLine_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("a5e7aeae-335b-4ce7-ab37-8eb11a4839f4")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _trackSectionId;

        /// <summary>
        /// Gets or sets the value of variable trackSectionId.
        /// </summary>
        [TestVariable("0b91016c-ebb2-4155-bb76-3f0a8708d28e")]
        public string trackSectionId
        {
            get { return _trackSectionId; }
            set { _trackSectionId = value; }
        }

        string _validateExist;

        /// <summary>
        /// Gets or sets the value of variable validateExist.
        /// </summary>
        [TestVariable("788b0cdd-42fa-46fd-8b7b-2d454af7ed6b")]
        public string validateExist
        {
            get { return _validateExist; }
            set { _validateExist = value; }
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

            UserCodeCollections.NS_Trackline_Validations.ValidateEMTOnTrackline(trainSeed, trackSectionId, ValueConverter.ArgumentFromString<bool>("validateExists", validateExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
