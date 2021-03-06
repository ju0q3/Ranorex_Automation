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

namespace PDS_NS.Recording_Modules.RUM.RUM_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDR_BULI_Message recording.
    /// </summary>
    [TestModule("5c456e76-afa1-4224-8094-6de4ca53217f", ModuleType.Recording, 1)]
    public partial class ValidateDR_BULI_Message : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDR_BULI_Message instance = new ValidateDR_BULI_Message();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDR_BULI_Message()
        {
            timeInSecond = "0";
            retry = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDR_BULI_Message Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeInSecond;

        /// <summary>
        /// Gets or sets the value of variable timeInSecond.
        /// </summary>
        [TestVariable("7521171a-ae36-4c8b-93aa-38a77f7f5c93")]
        public string timeInSecond
        {
            get { return _timeInSecond; }
            set { _timeInSecond = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("72756c44-e351-4a9b-b5fb-542722906e56")]
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

            STE.Code_Utils.ReceiveRumFileCollection_NS.validateDR_BULI_1(ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSecond), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
