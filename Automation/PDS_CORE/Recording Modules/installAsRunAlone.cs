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
    ///The installAsRunAlone recording.
    /// </summary>
    [TestModule("6205a691-23ed-46d2-8a82-211134acff83", ModuleType.Recording, 1)]
    public partial class installAsRunAlone : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static installAsRunAlone instance = new installAsRunAlone();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public installAsRunAlone()
        {
            label = "";
            db = "";
            type = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static installAsRunAlone Instance
        {
            get { return instance; }
        }

#region Variables

        string _label;

        /// <summary>
        /// Gets or sets the value of variable label.
        /// </summary>
        [TestVariable("3adad7a1-cc92-457c-a420-73a824165522")]
        public string label
        {
            get { return _label; }
            set { _label = value; }
        }

        string _db;

        /// <summary>
        /// Gets or sets the value of variable db.
        /// </summary>
        [TestVariable("bfdf2c6f-f0be-465c-8840-cfd31e16cba3")]
        public string db
        {
            get { return _db; }
            set { _db = value; }
        }

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("6c14b985-666d-45cd-83f3-f2c9a92a2e70")]
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

            installRunAloneFunction(label, db, type);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
