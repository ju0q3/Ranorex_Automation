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

namespace PDS_NS.Recording_Modules.SystemConfiguration.TrackingParameter
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ModifyTrackingTolerance_TrackingParameters_NS recording.
    /// </summary>
    [TestModule("beaf83a3-7e8e-40fa-93c5-fb27bfad5d56", ModuleType.Recording, 1)]
    public partial class ModifyTrackingTolerance_TrackingParameters_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyTrackingTolerance_TrackingParameters_NS instance = new ModifyTrackingTolerance_TrackingParameters_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyTrackingTolerance_TrackingParameters_NS()
        {
            minimumCheckDistance = "";
            expectedFeedback = "";
            reset = "False";
            apply = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyTrackingTolerance_TrackingParameters_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _minimumCheckDistance;

        /// <summary>
        /// Gets or sets the value of variable minimumCheckDistance.
        /// </summary>
        [TestVariable("627e0e44-472e-434f-a6d9-2c03049ac435")]
        public string minimumCheckDistance
        {
            get { return _minimumCheckDistance; }
            set { _minimumCheckDistance = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("c49a68b2-bb24-47b0-8e01-8a3e14942f8e")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("9381a257-55da-46aa-8760-d5af4984b198")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("407146e4-a86b-437b-b865-dc3cc3936115")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("80f1a429-2c07-4fe6-b66b-32811807671b")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ModifyTrackingTolerance_TrackingParameters(minimumCheckDistance, expectedFeedback, ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
