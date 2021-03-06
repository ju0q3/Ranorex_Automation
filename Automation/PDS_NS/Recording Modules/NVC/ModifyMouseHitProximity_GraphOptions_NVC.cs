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
    ///The ModifyMouseHitProximity_GraphOptions_NVC recording.
    /// </summary>
    [TestModule("04c82ca2-1cb6-4140-bda6-2504966529cb", ModuleType.Recording, 1)]
    public partial class ModifyMouseHitProximity_GraphOptions_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyMouseHitProximity_GraphOptions_NVC instance = new ModifyMouseHitProximity_GraphOptions_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyMouseHitProximity_GraphOptions_NVC()
        {
            mouseHitProximity = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyMouseHitProximity_GraphOptions_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _mouseHitProximity;

        /// <summary>
        /// Gets or sets the value of variable mouseHitProximity.
        /// </summary>
        [TestVariable("17cd82a4-604a-4745-9d0d-1b7727e339e9")]
        public string mouseHitProximity
        {
            get { return _mouseHitProximity; }
            set { _mouseHitProximity = value; }
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

            UserCodeCollections.NS_NVC.NS_ModifyMouseHitProximity_GraphOptions_NVC(mouseHitProximity);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
