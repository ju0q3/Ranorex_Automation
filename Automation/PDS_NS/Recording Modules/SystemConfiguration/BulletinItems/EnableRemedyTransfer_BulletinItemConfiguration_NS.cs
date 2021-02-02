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
    ///The EnableRemedyTransfer_BulletinItemConfiguration_NS recording.
    /// </summary>
    [TestModule("8dc7a127-241d-4bc8-ac53-99252ec122d5", ModuleType.Recording, 1)]
    public partial class EnableRemedyTransfer_BulletinItemConfiguration_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static EnableRemedyTransfer_BulletinItemConfiguration_NS instance = new EnableRemedyTransfer_BulletinItemConfiguration_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EnableRemedyTransfer_BulletinItemConfiguration_NS()
        {
            bulletinName = "";
            doEnable = "False";
            clickApply = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EnableRemedyTransfer_BulletinItemConfiguration_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinName;

        /// <summary>
        /// Gets or sets the value of variable bulletinName.
        /// </summary>
        [TestVariable("e8848d28-92bf-4868-9333-04093bca99ac")]
        public string bulletinName
        {
            get { return _bulletinName; }
            set { _bulletinName = value; }
        }

        string _doEnable;

        /// <summary>
        /// Gets or sets the value of variable doEnable.
        /// </summary>
        [TestVariable("c8682e53-3ccf-4535-a1be-8a6cacf70ef0")]
        public string doEnable
        {
            get { return _doEnable; }
            set { _doEnable = value; }
        }

        string _clickApply;

        /// <summary>
        /// Gets or sets the value of variable clickApply.
        /// </summary>
        [TestVariable("d9ba74fa-c4f8-4447-beec-4f3d1e16cd69")]
        public string clickApply
        {
            get { return _clickApply; }
            set { _clickApply = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("a5dfe156-71ca-44a2-badc-74ef424a00e2")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_EnableRemedyTransfer_BulletinItemConfiguration(bulletinName, ValueConverter.ArgumentFromString<bool>("doEnable", doEnable), ValueConverter.ArgumentFromString<bool>("clickApply", clickApply), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}