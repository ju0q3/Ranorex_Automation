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

namespace PDS_NS.Recording_Modules.SpecialCaseRecordings
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The IssuePSS_Iterative_NS recording.
    /// </summary>
    [TestModule("27143866-7023-45fe-af7a-9767c15ce308", ModuleType.Recording, 1)]
    public partial class IssuePSS_Iterative_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static IssuePSS_Iterative_NS instance = new IssuePSS_Iterative_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public IssuePSS_Iterative_NS()
        {
            signalId = "";
            iterationCount = "100";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static IssuePSS_Iterative_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _signalId;

        /// <summary>
        /// Gets or sets the value of variable signalId.
        /// </summary>
        [TestVariable("eaa81ed8-16df-488d-959b-c359a32a8899")]
        public string signalId
        {
            get { return _signalId; }
            set { _signalId = value; }
        }

        string _iterationCount;

        /// <summary>
        /// Gets or sets the value of variable iterationCount.
        /// </summary>
        [TestVariable("91332709-f3b3-4904-b586-7963f946ecf2")]
        public string iterationCount
        {
            get { return _iterationCount; }
            set { _iterationCount = value; }
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

            Iterate_PSS_Issuance("42765", ValueConverter.ArgumentFromString<int>("iterationCount", "200"));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
