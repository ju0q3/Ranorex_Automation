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
    ///The NS_OpenSubdividedLimits recording.
    /// </summary>
    [TestModule("199b69eb-bed4-4f87-8594-57675e9acfb5", ModuleType.Recording, 1)]
    public partial class NS_OpenSubdividedLimits : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static NS_OpenSubdividedLimits instance = new NS_OpenSubdividedLimits();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_OpenSubdividedLimits()
        {
            SDLChecked = "true";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_OpenSubdividedLimits Instance
        {
            get { return instance; }
        }

#region Variables

        string _SDLChecked;

        /// <summary>
        /// Gets or sets the value of variable SDLChecked.
        /// </summary>
        [TestVariable("82c4a46d-c633-435d-bb7a-c004ff1abb09")]
        public string SDLChecked
        {
            get { return _SDLChecked; }
            set { _SDLChecked = value; }
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Create_Track_Authority.Box13.SubdivideLimitsCheckbox' at Center.", repo.Create_Track_Authority.Box13.SubdivideLimitsCheckboxInfo, new RecordItemIndex(0));
            repo.Create_Track_Authority.Box13.SubdivideLimitsCheckbox.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(1));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked=$SDLChecked) on item 'Create_Track_Authority.Box13.SubdivideLimitsCheckbox'.", repo.Create_Track_Authority.Box13.SubdivideLimitsCheckboxInfo, new RecordItemIndex(2));
            Validate.AttributeEqual(repo.Create_Track_Authority.Box13.SubdivideLimitsCheckboxInfo, "Checked", SDLChecked);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s to exist. Associated repository item: 'Create_Track_Authority.Specify_Subdivided_Limits'", repo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo, new ActionTimeout(5000), new RecordItemIndex(3));
            repo.Create_Track_Authority.Specify_Subdivided_Limits.SelfInfo.WaitForExists(5000);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
