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

namespace PDS_NS.Recording_Modules.PTC.PTC_Messages
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendCD_CSGN_7Simple_NS recording.
    /// </summary>
    [TestModule("a1bda08a-542b-4301-bd0a-ff4407407760", ModuleType.Recording, 1)]
    public partial class SendCD_CSGN_7Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendCD_CSGN_7Simple_NS instance = new SendCD_CSGN_7Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendCD_CSGN_7Simple_NS()
        {
            trainSeed = "";
            crewSeed = "";
            engineSeed = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendCD_CSGN_7Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("64cf24b0-0934-4468-bed3-3ba5ab1cad8d")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("c6073f54-3b34-4955-90ee-e734f124c119")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("d85c034f-b7a8-4014-a7ef-9948038462f3")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("b5ee0628-4360-4bed-9efd-df3e7c4d0a37")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            Report.Log(ReportLevel.Info, "User", "Send CSGN", new RecordItemIndex(0));
            
            UserCodeCollections.NS_PTC_Messages.SendCD_CSGN_7Simple(trainSeed, crewSeed, engineSeed, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
