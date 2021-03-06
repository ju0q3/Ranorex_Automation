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
    ///The CDMS_SetBulletinConfiguration_NS recording.
    /// </summary>
    [TestModule("6148e307-ddc3-4c7a-b11e-1a081dc7c7df", ModuleType.Recording, 1)]
    public partial class CDMS_SetBulletinConfiguration_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_SetBulletinConfiguration_NS instance = new CDMS_SetBulletinConfiguration_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_SetBulletinConfiguration_NS()
        {
            bulletinType = "";
            ptcTransfer = "3";
            operable = "";
            toTransfer = "3";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_SetBulletinConfiguration_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinType;

        /// <summary>
        /// Gets or sets the value of variable bulletinType.
        /// </summary>
        [TestVariable("833330a5-5599-4ae5-bfc7-b3b9fe2727bd")]
        public string bulletinType
        {
            get { return _bulletinType; }
            set { _bulletinType = value; }
        }

        string _ptcTransfer;

        /// <summary>
        /// Gets or sets the value of variable ptcTransfer.
        /// </summary>
        [TestVariable("5d25611a-9f0d-459a-b9d4-e5a1b9d9efb8")]
        public string ptcTransfer
        {
            get { return _ptcTransfer; }
            set { _ptcTransfer = value; }
        }

        string _operable;

        /// <summary>
        /// Gets or sets the value of variable operable.
        /// </summary>
        [TestVariable("1e44cea4-17de-4627-98ea-9e7cf1d7d2c3")]
        public string operable
        {
            get { return _operable; }
            set { _operable = value; }
        }

        string _toTransfer;

        /// <summary>
        /// Gets or sets the value of variable toTransfer.
        /// </summary>
        [TestVariable("0aeb2814-1d92-4090-930c-9b5959015a51")]
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

            Oracle.Code_Utils.CDMSEnvironment.SetBulletinConfiguration_CDMS(bulletinType, ValueConverter.ArgumentFromString<int>("ptcTransfer", ptcTransfer), operable, ValueConverter.ArgumentFromString<int>("toTransfer", toTransfer));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
