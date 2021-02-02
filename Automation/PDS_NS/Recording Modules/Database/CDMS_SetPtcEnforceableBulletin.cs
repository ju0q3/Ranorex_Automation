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
    ///The CDMS_SetPtcEnforceableBulletin recording.
    /// </summary>
    [TestModule("716dec21-d0d1-4de9-a336-62f96bf544d6", ModuleType.Recording, 1)]
    public partial class CDMS_SetPtcEnforceableBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_SetPtcEnforceableBulletin instance = new CDMS_SetPtcEnforceableBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_SetPtcEnforceableBulletin()
        {
            bulletinName = "";
            updateValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_SetPtcEnforceableBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinName;

        /// <summary>
        /// Gets or sets the value of variable bulletinName.
        /// </summary>
        [TestVariable("de0813dd-db1f-4ac9-aadb-fd73f36226b6")]
        public string bulletinName
        {
            get { return _bulletinName; }
            set { _bulletinName = value; }
        }

        string _updateValue;

        /// <summary>
        /// Gets or sets the value of variable updateValue.
        /// </summary>
        [TestVariable("27269cc6-c51d-44a2-89da-db637ef599f0")]
        public string updateValue
        {
            get { return _updateValue; }
            set { _updateValue = value; }
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

            Oracle.Code_Utils.CDMSEnvironment.SetPtcEnforceableBulletin_CDMS(bulletinName, updateValue);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}