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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_FillCopiedBy_CommunicationsExchangeForm recording.
    /// </summary>
    [TestModule("beba5fc9-364d-4eb7-8557-dee1e13b0c5d", ModuleType.Recording, 1)]
    public partial class NS_FillCopiedBy_CommunicationsExchangeForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static NS_FillCopiedBy_CommunicationsExchangeForm instance = new NS_FillCopiedBy_CommunicationsExchangeForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_FillCopiedBy_CommunicationsExchangeForm()
        {
            copiedBy = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_FillCopiedBy_CommunicationsExchangeForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _copiedBy;

        /// <summary>
        /// Gets or sets the value of variable copiedBy.
        /// </summary>
        [TestVariable("6080eb90-3ff5-4a96-ae07-3d1333541cf6")]
        public string copiedBy
        {
            get { return _copiedBy; }
            set { _copiedBy = value; }
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Communications_Exchange_Ok_Authority.CopiedByText' at Center.", repo.Communications_Exchange_Ok_Authority.CopiedByTextInfo, new RecordItemIndex(0));
            repo.Communications_Exchange_Ok_Authority.CopiedByText.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable '$copiedBy' with focus on 'Communications_Exchange_Ok_Authority.CopiedByText'.", repo.Communications_Exchange_Ok_Authority.CopiedByTextInfo, new RecordItemIndex(1));
            repo.Communications_Exchange_Ok_Authority.CopiedByText.PressKeys(copiedBy);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Tab' Press with focus on 'Communications_Exchange_Ok_Authority.CopiedByText'.", repo.Communications_Exchange_Ok_Authority.CopiedByTextInfo, new RecordItemIndex(2));
            Keyboard.PrepareFocus(repo.Communications_Exchange_Ok_Authority.CopiedByText);
            Keyboard.Press(System.Windows.Forms.Keys.Tab, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
