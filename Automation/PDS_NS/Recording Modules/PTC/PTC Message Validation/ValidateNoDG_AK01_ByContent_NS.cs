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

namespace PDS_NS.Recording_Modules.PTC.PTC_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateNoDG_AK01_ByContent_NS recording.
    /// </summary>
    [TestModule("eb9328fd-a970-466a-ab24-8bf33361cafd", ModuleType.Recording, 1)]
    public partial class ValidateNoDG_AK01_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateNoDG_AK01_ByContent_NS instance = new ValidateNoDG_AK01_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateNoDG_AK01_ByContent_NS()
        {
            msgId = "";
            timeInSeconds = "0";
            retry = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateNoDG_AK01_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _msgId;

        /// <summary>
        /// Gets or sets the value of variable msgId.
        /// </summary>
        [TestVariable("f6e5c1d0-ba80-482d-aedb-2a5cc5c32ad3")]
        public string msgId
        {
            get { return _msgId; }
            set { _msgId = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("06bef8c8-460b-4da4-aca4-81c3bff5836d")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("924e3fbd-efd6-4079-b46a-924943769fdf")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
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

            UserCodeCollections.NS_PTC_Message_Validations.ValidateNoDG_AK01_ByContent(msgId, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}