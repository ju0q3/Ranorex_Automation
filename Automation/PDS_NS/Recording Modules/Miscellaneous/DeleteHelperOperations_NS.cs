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

namespace PDS_NS.Recording_Modules.Miscellaneous
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DeleteHelperOperations_NS recording.
    /// </summary>
    [TestModule("72b8eafd-3bcb-4ed3-a5ea-f983ddabc785", ModuleType.Recording, 1)]
    public partial class DeleteHelperOperations_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DeleteHelperOperations_NS instance = new DeleteHelperOperations_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DeleteHelperOperations_NS()
        {
            division = "";
            assistedTrainseed = "";
            expectedFeedback = "";
            apply = "False";
            reset = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DeleteHelperOperations_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("7a03a3e9-5bda-4b4e-ab16-df4888c985cd")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _assistedTrainseed;

        /// <summary>
        /// Gets or sets the value of variable assistedTrainseed.
        /// </summary>
        [TestVariable("5d939215-2ed3-44a9-ae31-57df0d3e795d")]
        public string assistedTrainseed
        {
            get { return _assistedTrainseed; }
            set { _assistedTrainseed = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("41f6a7c0-0d06-49fb-be50-42fa4cd4ca53")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("015bc58f-4f83-44f5-9c51-c1f83bd178c8")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("b3cd5eb5-06d7-4320-8a12-85b1475a4f82")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("1e1fa3bb-9a9b-4605-9a03-0ef74ebf838a")]
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

            UserCodeCollections.NS_Miscellaneous.DeleteHelperOperations(division, assistedTrainseed, expectedFeedback, ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}