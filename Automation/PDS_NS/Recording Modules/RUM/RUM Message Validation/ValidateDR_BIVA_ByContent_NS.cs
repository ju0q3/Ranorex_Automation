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

namespace PDS_NS.Recording_Modules.RUM.RUM_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDR_BIVA_ByContent_NS recording.
    /// </summary>
    [TestModule("da5d907a-5fa0-42ab-9e16-24fcad8e48a0", ModuleType.Recording, 1)]
    public partial class ValidateDR_BIVA_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDR_BIVA_ByContent_NS instance = new ValidateDR_BIVA_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDR_BIVA_ByContent_NS()
        {
            bulletinSeed = "";
            optDistrict = "";
            optMessageVersion = "";
            timeInSeconds = "5";
            retry = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDR_BIVA_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("7a2ea9e2-6937-4d93-8a30-346b03f55c95")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _optDistrict;

        /// <summary>
        /// Gets or sets the value of variable optDistrict.
        /// </summary>
        [TestVariable("b18d6aa9-1fe1-4471-82e2-c84696988b71")]
        public string optDistrict
        {
            get { return _optDistrict; }
            set { _optDistrict = value; }
        }

        string _optMessageVersion;

        /// <summary>
        /// Gets or sets the value of variable optMessageVersion.
        /// </summary>
        [TestVariable("d12ef6c4-ac51-4d25-8c63-9e982eb998c9")]
        public string optMessageVersion
        {
            get { return _optMessageVersion; }
            set { _optMessageVersion = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("5a9cab8c-2a83-4601-820f-196d5528bc47")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("3096a109-0a71-440c-9d2e-48d16b187db8")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
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

            UserCodeCollections.NS_RUM_Message_Validations.ValidateDR_BIVA_ByContent(bulletinSeed, optDistrict, optMessageVersion, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}