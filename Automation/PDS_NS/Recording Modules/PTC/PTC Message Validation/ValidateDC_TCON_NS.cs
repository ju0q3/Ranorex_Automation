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
    ///The ValidateDC_TCON_NS recording.
    /// </summary>
    [TestModule("9ac9d387-b945-4f23-8df2-f0be030c2522", ModuleType.Recording, 1)]
    public partial class ValidateDC_TCON_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDC_TCON_NS instance = new ValidateDC_TCON_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDC_TCON_NS()
        {
            msgFilters = "";
            timeInSeconds = "5";
            validateDoesExist = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDC_TCON_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _msgFilters;

        /// <summary>
        /// Gets or sets the value of variable msgFilters.
        /// </summary>
        [TestVariable("a0d2355d-a720-44aa-b74b-976dfbc7c857")]
        public string msgFilters
        {
            get { return _msgFilters; }
            set { _msgFilters = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("841d8efd-7e1d-49f7-a36c-53bcacb2f0ef")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _validateDoesExist;

        /// <summary>
        /// Gets or sets the value of variable validateDoesExist.
        /// </summary>
        [TestVariable("fa1e9422-dcaa-4883-bc7e-4cac34057664")]
        public string validateDoesExist
        {
            get { return _validateDoesExist; }
            set { _validateDoesExist = value; }
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

            STE.Code_Utils.ReceivePTCFileCollection_NS.validateDC_TCON_7_ForTrain(msgFilters, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", validateDoesExist), ValueConverter.ArgumentFromString<bool>("validateDoesExist", validateDoesExist));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}