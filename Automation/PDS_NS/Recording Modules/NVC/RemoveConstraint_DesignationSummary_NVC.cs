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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The RemoveConstraint_DesignationSummary_NVC recording.
    /// </summary>
    [TestModule("c0a73e13-8d9a-4c8c-b823-363eee6927d0", ModuleType.Recording, 1)]
    public partial class RemoveConstraint_DesignationSummary_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static RemoveConstraint_DesignationSummary_NVC instance = new RemoveConstraint_DesignationSummary_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RemoveConstraint_DesignationSummary_NVC()
        {
            trackFeatureId = "";
            clickRemoveConstraint = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static RemoveConstraint_DesignationSummary_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _trackFeatureId;

        /// <summary>
        /// Gets or sets the value of variable trackFeatureId.
        /// </summary>
        [TestVariable("6f07c4c8-113c-41ea-a76c-3343d296fadc")]
        public string trackFeatureId
        {
            get { return _trackFeatureId; }
            set { _trackFeatureId = value; }
        }

        string _clickRemoveConstraint;

        /// <summary>
        /// Gets or sets the value of variable clickRemoveConstraint.
        /// </summary>
        [TestVariable("49dcdf2c-55da-4064-b1f0-718b791cf6e3")]
        public string clickRemoveConstraint
        {
            get { return _clickRemoveConstraint; }
            set { _clickRemoveConstraint = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("61bf8033-7a2d-454b-86e5-da3bdc3c62d0")]
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

            UserCodeCollections.NS_NVC.NS_RemoveConstraint_DesignationSummary_NVC(trackFeatureId, ValueConverter.ArgumentFromString<bool>("clickRemoveConstraint", clickRemoveConstraint), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
