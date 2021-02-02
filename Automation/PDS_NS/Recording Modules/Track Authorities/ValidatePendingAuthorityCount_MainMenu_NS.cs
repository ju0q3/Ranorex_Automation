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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidatePendingAuthorityCount_MainMenu_NS recording.
    /// </summary>
    [TestModule("3c4987ba-4881-48f0-8aa2-2957f9cc4a17", ModuleType.Recording, 1)]
    public partial class ValidatePendingAuthorityCount_MainMenu_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidatePendingAuthorityCount_MainMenu_NS instance = new ValidatePendingAuthorityCount_MainMenu_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidatePendingAuthorityCount_MainMenu_NS()
        {
            expauthorityCount = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidatePendingAuthorityCount_MainMenu_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expauthorityCount;

        /// <summary>
        /// Gets or sets the value of variable expauthorityCount.
        /// </summary>
        [TestVariable("20faa197-14e0-4e35-9b45-f8c5655961d2")]
        public string expauthorityCount
        {
            get { return _expauthorityCount; }
            set { _expauthorityCount = value; }
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

            UserCodeCollections.NS_Authorities.NS_ValidatePendingAuthorityCount(ValueConverter.ArgumentFromString<int>("expauthorityCount", expauthorityCount));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
