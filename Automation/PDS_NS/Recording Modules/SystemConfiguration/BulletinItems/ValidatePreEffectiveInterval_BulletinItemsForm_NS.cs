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

namespace PDS_NS.Recording_Modules.SystemConfiguration.BulletinItems
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePreEffectiveInterval_BulletinItemsForm_NS recording.
    /// </summary>
    [TestModule("30340048-1afc-4765-81cb-fc5c8d918c0f", ModuleType.Recording, 1)]
    public partial class ValidatePreEffectiveInterval_BulletinItemsForm_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePreEffectiveInterval_BulletinItemsForm_NS instance = new ValidatePreEffectiveInterval_BulletinItemsForm_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePreEffectiveInterval_BulletinItemsForm_NS()
        {
            bulletinName = "";
            expPreEffcetiveIntervalHours = "";
            expPreEffcetiveIntervalDays = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePreEffectiveInterval_BulletinItemsForm_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinName;

        /// <summary>
        /// Gets or sets the value of variable bulletinName.
        /// </summary>
        [TestVariable("e89b623f-208b-480d-ad95-f8747f7554ae")]
        public string bulletinName
        {
            get { return _bulletinName; }
            set { _bulletinName = value; }
        }

        string _expPreEffcetiveIntervalHours;

        /// <summary>
        /// Gets or sets the value of variable expPreEffcetiveIntervalHours.
        /// </summary>
        [TestVariable("15a00cb7-7af4-428c-8444-9758771e04d0")]
        public string expPreEffcetiveIntervalHours
        {
            get { return _expPreEffcetiveIntervalHours; }
            set { _expPreEffcetiveIntervalHours = value; }
        }

        string _expPreEffcetiveIntervalDays;

        /// <summary>
        /// Gets or sets the value of variable expPreEffcetiveIntervalDays.
        /// </summary>
        [TestVariable("4aed0bd0-58f7-48f5-bec0-26730469611a")]
        public string expPreEffcetiveIntervalDays
        {
            get { return _expPreEffcetiveIntervalDays; }
            set { _expPreEffcetiveIntervalDays = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidatePreEffectiveInterval_BulletinItemsForm(bulletinName, expPreEffcetiveIntervalHours, expPreEffcetiveIntervalDays);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
