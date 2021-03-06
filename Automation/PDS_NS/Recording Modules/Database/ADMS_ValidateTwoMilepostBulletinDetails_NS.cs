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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ADMS_ValidateTwoMilepostBulletinDetails_NS recording.
    /// </summary>
    [TestModule("9aa69770-349c-4b32-8b07-0e9907c2b6d9", ModuleType.Recording, 1)]
    public partial class ADMS_ValidateTwoMilepostBulletinDetails_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ADMS_ValidateTwoMilepostBulletinDetails_NS instance = new ADMS_ValidateTwoMilepostBulletinDetails_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_ValidateTwoMilepostBulletinDetails_NS()
        {
            bulletinSeed = "";
            bulletinState = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_ValidateTwoMilepostBulletinDetails_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("25ab761b-bbb7-4b44-9f48-bdbab8e29697")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _bulletinState;

        /// <summary>
        /// Gets or sets the value of variable bulletinState.
        /// </summary>
        [TestVariable("cba5222a-183c-424c-ba5d-6c0906bfd870")]
        public string bulletinState
        {
            get { return _bulletinState; }
            set { _bulletinState = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateTwoMilepostBulletinDetailsInADMS(bulletinSeed, bulletinState);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
