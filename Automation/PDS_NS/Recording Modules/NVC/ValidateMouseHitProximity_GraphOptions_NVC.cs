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
    ///The ValidateMouseHitProximity_GraphOptions_NVC recording.
    /// </summary>
    [TestModule("30fdc7c1-4934-42e1-bf57-2813a32e3022", ModuleType.Recording, 1)]
    public partial class ValidateMouseHitProximity_GraphOptions_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateMouseHitProximity_GraphOptions_NVC instance = new ValidateMouseHitProximity_GraphOptions_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateMouseHitProximity_GraphOptions_NVC()
        {
            mouseHitProximity = "";
            expectExist = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateMouseHitProximity_GraphOptions_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _mouseHitProximity;

        /// <summary>
        /// Gets or sets the value of variable mouseHitProximity.
        /// </summary>
        [TestVariable("45d2074b-69f7-4e95-8dbb-82fbf87822a0")]
        public string mouseHitProximity
        {
            get { return _mouseHitProximity; }
            set { _mouseHitProximity = value; }
        }

        string _expectExist;

        /// <summary>
        /// Gets or sets the value of variable expectExist.
        /// </summary>
        [TestVariable("186cb724-07f2-4317-bd53-d69f67c000b5")]
        public string expectExist
        {
            get { return _expectExist; }
            set { _expectExist = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateMouseHitProximity_GraphOptions_NVC(mouseHitProximity, ValueConverter.ArgumentFromString<bool>("expectExist", expectExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}