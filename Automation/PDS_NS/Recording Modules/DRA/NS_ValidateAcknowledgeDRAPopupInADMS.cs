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

namespace PDS_NS.Recording_Modules.DRA
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ValidateAcknowledgeDRAPopupInADMS recording.
    /// </summary>
    [TestModule("6ff7a431-49c4-4b3d-a1c4-2e357615d5c3", ModuleType.Recording, 1)]
    public partial class NS_ValidateAcknowledgeDRAPopupInADMS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateAcknowledgeDRAPopupInADMS instance = new NS_ValidateAcknowledgeDRAPopupInADMS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateAcknowledgeDRAPopupInADMS()
        {
            trainSeed = "";
            fromOpsta = "";
            toOpsta = "";
            verifyPopUpAcknowledged = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateAcknowledgeDRAPopupInADMS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("4a26e52c-34c7-4379-8eb3-18dbb47303c7")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _fromOpsta;

        /// <summary>
        /// Gets or sets the value of variable fromOpsta.
        /// </summary>
        [TestVariable("bff50325-0682-419b-b435-6023efbcabd6")]
        public string fromOpsta
        {
            get { return _fromOpsta; }
            set { _fromOpsta = value; }
        }

        string _toOpsta;

        /// <summary>
        /// Gets or sets the value of variable toOpsta.
        /// </summary>
        [TestVariable("6cb4571e-e2c8-4055-8407-57dd1acfd859")]
        public string toOpsta
        {
            get { return _toOpsta; }
            set { _toOpsta = value; }
        }

        string _verifyPopUpAcknowledged;

        /// <summary>
        /// Gets or sets the value of variable verifyPopUpAcknowledged.
        /// </summary>
        [TestVariable("499314b2-9427-4a98-8df1-39d5a2b0632d")]
        public string verifyPopUpAcknowledged
        {
            get { return _verifyPopUpAcknowledged; }
            set { _verifyPopUpAcknowledged = value; }
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

            UserCodeCollections.NS_DRA.NS_ValidateDRAPopUPAcknowledgedInADMS(trainSeed, fromOpsta, toOpsta, ValueConverter.ArgumentFromString<bool>("verifyPopUpAcknowledged", verifyPopUpAcknowledged));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
