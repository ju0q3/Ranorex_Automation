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

namespace PDS_NS.Recording_Modules.Bulletins
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenTaskListWithValidateFeedback_NS recording.
    /// </summary>
    [TestModule("a94b7aa9-1980-461d-a552-cefcc48bc167", ModuleType.Recording, 1)]
    public partial class OpenTaskListWithValidateFeedback_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static OpenTaskListWithValidateFeedback_NS instance = new OpenTaskListWithValidateFeedback_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenTaskListWithValidateFeedback_NS()
        {
            expectedFeedback = "";
            employeeName = "";
            description = "";
            expectTask = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenTaskListWithValidateFeedback_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("f02da065-8355-491b-9016-716c6d8de349")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _employeeName;

        /// <summary>
        /// Gets or sets the value of variable employeeName.
        /// </summary>
        [TestVariable("f75dd1e0-7a5f-4b17-b181-eddfa1f7eff4")]
        public string employeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        string _description;

        /// <summary>
        /// Gets or sets the value of variable description.
        /// </summary>
        [TestVariable("c2033222-18f9-4a79-aaa7-8f2056b9312b")]
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _expectTask;

        /// <summary>
        /// Gets or sets the value of variable expectTask.
        /// </summary>
        [TestVariable("1921b7d8-f38a-4077-9075-c72a4d3cada8")]
        public string expectTask
        {
            get { return _expectTask; }
            set { _expectTask = value; }
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

            UserCodeCollections.NS_Bulletin.NS_OpenTaskListWithValidateFeedback(description, employeeName, expectedFeedback, ValueConverter.ArgumentFromString<bool>("expectTask", expectTask));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}