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
    ///The NS_NotificationPopup recording.
    /// </summary>
    [TestModule("04914bbb-daba-414a-a420-8d4fe3bde429", ModuleType.Recording, 1)]
    public partial class NS_NotificationPopup : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_NotificationPopup instance = new NS_NotificationPopup();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_NotificationPopup()
        {
            text = "";
            yesOrNo = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_NotificationPopup Instance
        {
            get { return instance; }
        }

#region Variables

        string _text;

        /// <summary>
        /// Gets or sets the value of variable text.
        /// </summary>
        [TestVariable("4b838a5a-ba1c-4965-8dd9-2e41580e155f")]
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        string _yesOrNo;

        /// <summary>
        /// Gets or sets the value of variable yesOrNo.
        /// </summary>
        [TestVariable("0d6914ac-2e09-4570-8f0e-d6f0ad85558a")]
        public string yesOrNo
        {
            get { return _yesOrNo; }
            set { _yesOrNo = value; }
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

            UserCodeCollections.NS_Authorities.NotificationDialog(text, yesOrNo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
