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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Track_Authority
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS recording.
    /// </summary>
    [TestModule("e3f6a788-3e0f-4998-a3ff-680781ac4f81", ModuleType.Recording, 1)]
    public partial class ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS instance = new ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS()
        {
            newMinimum = "";
            newMaximum = "";
            clickApply = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _newMinimum;

        /// <summary>
        /// Gets or sets the value of variable newMinimum.
        /// </summary>
        [TestVariable("1f9551b7-fd76-482e-ba9e-209f2b29eae5")]
        public string newMinimum
        {
            get { return _newMinimum; }
            set { _newMinimum = value; }
        }

        string _newMaximum;

        /// <summary>
        /// Gets or sets the value of variable newMaximum.
        /// </summary>
        [TestVariable("dbbf7b9b-25eb-4013-b1f6-1413e8857817")]
        public string newMaximum
        {
            get { return _newMaximum; }
            set { _newMaximum = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("e1df8759-c1bc-4131-aaa7-d3b47292ea86")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("77318db8-d67d-4bb5-a9dd-4a2935729b2e")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyTrackAuthorityNumberRange_TrackAuthorityNumberRange(newMinimum, newMaximum, ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
