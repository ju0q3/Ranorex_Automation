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

namespace PDS_CORE.Recording_Modules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The startPDS recording.
    /// </summary>
    [TestModule("123c069e-d4a9-42d4-8701-c0a1fa66b770", ModuleType.Recording, 1)]
    public partial class startPDS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static startPDS instance = new startPDS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public startPDS()
        {
            serverLabel = "CN-PDS_2018-06-15-1200";
            db = "CN";
            type = "Label";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static startPDS Instance
        {
            get { return instance; }
        }

#region Variables

        string _serverLabel;

        /// <summary>
        /// Gets or sets the value of variable serverLabel.
        /// </summary>
        [TestVariable("3155761b-1057-48f5-a378-942729a3157f")]
        public string serverLabel
        {
            get { return _serverLabel; }
            set { _serverLabel = value; }
        }

        string _db;

        /// <summary>
        /// Gets or sets the value of variable db.
        /// </summary>
        [TestVariable("21dbf267-6802-463f-803a-ccec7fe56b16")]
        public string db
        {
            get { return _db; }
            set { _db = value; }
        }

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("59a604e4-58bf-4fb6-85d3-5061928b01b9")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
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

            preparePDS(serverLabel, db, "$type");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}