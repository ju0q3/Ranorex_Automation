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
    ///The OpenBulletin_BulletinSummaryList recording.
    /// </summary>
    [TestModule("6277b2a8-e3af-4cbd-8796-0c7ac72bb211", ModuleType.Recording, 1)]
    public partial class OpenBulletin_BulletinSummaryList : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static OpenBulletin_BulletinSummaryList instance = new OpenBulletin_BulletinSummaryList();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenBulletin_BulletinSummaryList()
        {
            bulletinSeed = "";
            closeBulletinSummaryList = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenBulletin_BulletinSummaryList Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("e82d8b19-04ba-4362-9704-70e6580cedad")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _closeBulletinSummaryList;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinSummaryList.
        /// </summary>
        [TestVariable("b835a90a-3bbf-4a35-b6c8-6a075891147d")]
        public string closeBulletinSummaryList
        {
            get { return _closeBulletinSummaryList; }
            set { _closeBulletinSummaryList = value; }
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

            UserCodeCollections.NS_Bulletin.NS_OpenBulletin_BulletinSummaryList(bulletinSeed, ValueConverter.ArgumentFromString<bool>("closeBulletinSummaryList", closeBulletinSummaryList));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
