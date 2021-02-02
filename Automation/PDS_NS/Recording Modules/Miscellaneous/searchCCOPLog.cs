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
    ///The searchCCOPLog recording.
    /// </summary>
    [TestModule("8fd8eaa2-8058-4bf8-9dcf-49c93d842de5", ModuleType.Recording, 1)]
    public partial class SearchCCOPLog : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SearchCCOPLog instance = new SearchCCOPLog();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SearchCCOPLog()
        {
            fromTime = "";
            toTime = "";
            textToSearch = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SearchCCOPLog Instance
        {
            get { return instance; }
        }

#region Variables

        string _fromTime;

        /// <summary>
        /// Gets or sets the value of variable fromTime.
        /// </summary>
        [TestVariable("81e038eb-3d7d-45ea-be6a-28bb3f6b9967")]
        public string fromTime
        {
            get { return _fromTime; }
            set { _fromTime = value; }
        }

        string _toTime;

        /// <summary>
        /// Gets or sets the value of variable toTime.
        /// </summary>
        [TestVariable("0a7ec340-37ef-455b-8f62-1e19978c4e09")]
        public string toTime
        {
            get { return _toTime; }
            set { _toTime = value; }
        }

        string _textToSearch;

        /// <summary>
        /// Gets or sets the value of variable textToSearch.
        /// </summary>
        [TestVariable("6aefd051-e0ea-4935-920f-e969a3c1b1a1")]
        public string textToSearch
        {
            get { return _textToSearch; }
            set { _textToSearch = value; }
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

            UserCodeCollections.NS_CCOP.latestLogFileName(fromTime, toTime, textToSearch);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}