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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_RemoveSignalAuthority_Trackline recording.
    /// </summary>
    [TestModule("3c67dde6-5421-4e5a-adc3-5223e61eb849", ModuleType.Recording, 1)]
    public partial class NS_RemoveSignalAuthority_Trackline : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_RemoveSignalAuthority_Trackline instance = new NS_RemoveSignalAuthority_Trackline();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_RemoveSignalAuthority_Trackline()
        {
            trackSection = "";
            expectedFeedback = "";
            removeAuthority = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_RemoveSignalAuthority_Trackline Instance
        {
            get { return instance; }
        }

#region Variables

        string _trackSection;

        /// <summary>
        /// Gets or sets the value of variable trackSection.
        /// </summary>
        [TestVariable("41c6682b-aabb-47a8-af53-d248337405a7")]
        public string trackSection
        {
            get { return _trackSection; }
            set { _trackSection = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("22ae295c-ba84-4ac7-9ddf-78e573ae9aca")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _removeAuthority;

        /// <summary>
        /// Gets or sets the value of variable removeAuthority.
        /// </summary>
        [TestVariable("9d636c14-8544-4ba1-8fdb-3090b3b5f732")]
        public string removeAuthority
        {
            get { return _removeAuthority; }
            set { _removeAuthority = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_RemoveSignalAuthority(trackSection, expectedFeedback, ValueConverter.ArgumentFromString<bool>("removeAuthority", removeAuthority));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
