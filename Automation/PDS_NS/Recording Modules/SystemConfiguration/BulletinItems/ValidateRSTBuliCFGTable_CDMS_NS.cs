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
    ///The ValidateRSTBuliCFGTable_CDMS_NS recording.
    /// </summary>
    [TestModule("70c6f45e-c7dd-45c2-9b36-e10d2fd780a5", ModuleType.Recording, 1)]
    public partial class ValidateRSTBuliCFGTable_CDMS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateRSTBuliCFGTable_CDMS_NS instance = new ValidateRSTBuliCFGTable_CDMS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateRSTBuliCFGTable_CDMS_NS()
        {
            bulletinName = "";
            ptcTransfer = "";
            operable = "";
            toTransfer = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateRSTBuliCFGTable_CDMS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinName;

        /// <summary>
        /// Gets or sets the value of variable bulletinName.
        /// </summary>
        [TestVariable("01fab147-4d20-4ac2-8b07-1fba4f05cb72")]
        public string bulletinName
        {
            get { return _bulletinName; }
            set { _bulletinName = value; }
        }

        string _ptcTransfer;

        /// <summary>
        /// Gets or sets the value of variable ptcTransfer.
        /// </summary>
        [TestVariable("225ee8f1-cf50-4611-b0f8-78b06389e9d4")]
        public string ptcTransfer
        {
            get { return _ptcTransfer; }
            set { _ptcTransfer = value; }
        }

        string _operable;

        /// <summary>
        /// Gets or sets the value of variable operable.
        /// </summary>
        [TestVariable("1ee4eba6-306f-4aab-8587-65088cb0b67f")]
        public string operable
        {
            get { return _operable; }
            set { _operable = value; }
        }

        string _toTransfer;

        /// <summary>
        /// Gets or sets the value of variable toTransfer.
        /// </summary>
        [TestVariable("52f48c96-fe51-4183-b775-d0437f014d6e")]
        public string toTransfer
        {
            get { return _toTransfer; }
            set { _toTransfer = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateRSTBuliTableInfo(bulletinName, ptcTransfer, operable, toTransfer);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
