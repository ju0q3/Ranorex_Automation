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
    ///The ValidateBulletinNameAndColor_TrackLine_NS recording.
    /// </summary>
    [TestModule("1575eb3a-acaa-428c-afd0-08343efda479", ModuleType.Recording, 1)]
    public partial class ValidateBulletinNameAndColor_TrackLine_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateBulletinNameAndColor_TrackLine_NS instance = new ValidateBulletinNameAndColor_TrackLine_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateBulletinNameAndColor_TrackLine_NS()
        {
            bulletinSeed = "";
            expBulletinName = "";
            color = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateBulletinNameAndColor_TrackLine_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("a720de59-8a75-47f9-8d73-1b6f37a775dd")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _expBulletinName;

        /// <summary>
        /// Gets or sets the value of variable expBulletinName.
        /// </summary>
        [TestVariable("34f7f2cb-fdc2-481c-8aa4-16cd89bf916f")]
        public string expBulletinName
        {
            get { return _expBulletinName; }
            set { _expBulletinName = value; }
        }

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("1d5926ac-d8dc-4863-b7ca-c0ede714305f")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
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

            UserCodeCollections.NS_Bulletin.NS_ValidateBulletinNameAndColor_TrackLine(bulletinSeed, expBulletinName, color);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
