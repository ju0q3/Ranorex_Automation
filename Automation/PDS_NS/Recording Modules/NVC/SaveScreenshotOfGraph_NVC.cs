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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SaveScreenshotOfGraph_NVC recording.
    /// </summary>
    [TestModule("59febddd-7eba-4ca0-8a47-9c709b3f7253", ModuleType.Recording, 1)]
    public partial class SaveScreenshotOfGraph_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SaveScreenshotOfGraph_NVC instance = new SaveScreenshotOfGraph_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SaveScreenshotOfGraph_NVC()
        {
            fileName = "";
            clickSave = "False";
            clickCancel = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SaveScreenshotOfGraph_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _fileName;

        /// <summary>
        /// Gets or sets the value of variable fileName.
        /// </summary>
        [TestVariable("a3f2a0d9-f00f-4cd9-bbcd-8d0d93cb9047")]
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        string _clickSave;

        /// <summary>
        /// Gets or sets the value of variable clickSave.
        /// </summary>
        [TestVariable("097233e1-3f71-4e84-91b5-a6a2ac506527")]
        public string clickSave
        {
            get { return _clickSave; }
            set { _clickSave = value; }
        }

        string _clickCancel;

        /// <summary>
        /// Gets or sets the value of variable clickCancel.
        /// </summary>
        [TestVariable("ca0fee3b-84c3-4d09-93e3-8ee8528859c9")]
        public string clickCancel
        {
            get { return _clickCancel; }
            set { _clickCancel = value; }
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

            UserCodeCollections.NS_NVC.NS_SaveScreenshotOfGraph_NVC(fileName, ValueConverter.ArgumentFromString<bool>("clickSave", clickSave), ValueConverter.ArgumentFromString<bool>("clickCancel", clickCancel));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
