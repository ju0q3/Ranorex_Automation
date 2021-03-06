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
    ///The WaitForBulletinToAppearOnTrackline recording.
    /// </summary>
    [TestModule("10c9e071-f9b3-43e5-b6a0-bad59d18ec01", ModuleType.Recording, 1)]
    public partial class WaitForBulletinToAppearOnTrackline : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static WaitForBulletinToAppearOnTrackline instance = new WaitForBulletinToAppearOnTrackline();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public WaitForBulletinToAppearOnTrackline()
        {
            bulletinSeed = "";
            maxWaitMinutes = "1";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static WaitForBulletinToAppearOnTrackline Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("11fe8884-4ad7-4f94-b359-f81bc6006eb4")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _maxWaitMinutes;

        /// <summary>
        /// Gets or sets the value of variable maxWaitMinutes.
        /// </summary>
        [TestVariable("1845e77e-cb8d-4221-9d0f-94acc27497d0")]
        public string maxWaitMinutes
        {
            get { return _maxWaitMinutes; }
            set { _maxWaitMinutes = value; }
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

            UserCodeCollections.NS_Bulletin.WaitForBulletinToAppear_NS(bulletinSeed, ValueConverter.ArgumentFromString<int>("maxWaitMinutes", maxWaitMinutes));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
