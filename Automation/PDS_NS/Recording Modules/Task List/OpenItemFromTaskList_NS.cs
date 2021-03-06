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

namespace PDS_NS.Recording_Modules.Task_List
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenItemFromTaskList_NS recording.
    /// </summary>
    [TestModule("7c66a23f-7c2f-4623-a846-bbd852b379bf", ModuleType.Recording, 1)]
    public partial class OpenItemFromTaskList_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.Miscellaneous_Repo repository.
        /// </summary>
        public static global::PDS_NS.Miscellaneous_Repo repo = global::PDS_NS.Miscellaneous_Repo.Instance;

        static OpenItemFromTaskList_NS instance = new OpenItemFromTaskList_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenItemFromTaskList_NS()
        {
            description = "";
            employeeName = "";
            expectTask = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenItemFromTaskList_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _description;

        /// <summary>
        /// Gets or sets the value of variable description.
        /// </summary>
        [TestVariable("c1930a9d-9f97-4c58-b6bb-8ce87a913085")]
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _employeeName;

        /// <summary>
        /// Gets or sets the value of variable employeeName.
        /// </summary>
        [TestVariable("041014e2-701c-4728-90b9-9969a6138c16")]
        public string employeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        string _expectTask;

        /// <summary>
        /// Gets or sets the value of variable expectTask.
        /// </summary>
        [TestVariable("8da0c54d-ee17-4d5a-a8a5-ced60762baf9")]
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

            UserCodeCollections.NS_Miscellaneous.NS_OpenTaskByDescriptionAndEmployeeName(description, employeeName, ValueConverter.ArgumentFromString<bool>("expectTask", expectTask));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
