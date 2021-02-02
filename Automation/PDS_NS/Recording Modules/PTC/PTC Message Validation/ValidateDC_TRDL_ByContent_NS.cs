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
    ///The ValidateDC_TRDL_ByContent_NS recording.
    /// </summary>
    [TestModule("a4ed6cc2-c6d9-47ab-bcfb-27aca915b1b9", ModuleType.Recording, 1)]
    public partial class ValidateDC_TRDL_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDC_TRDL_ByContent_NS instance = new ValidateDC_TRDL_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDC_TRDL_ByContent_NS()
        {
            optDistrict = "";
            optMessageVersion = "";
            optMessageRevision = "";
            timeInSeconds = "5";
            retry = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDC_TRDL_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _optDistrict;

        /// <summary>
        /// Gets or sets the value of variable optDistrict.
        /// </summary>
        [TestVariable("38701438-c495-41e3-8559-f5612b139744")]
        public string optDistrict
        {
            get { return _optDistrict; }
            set { _optDistrict = value; }
        }

        string _optMessageVersion;

        /// <summary>
        /// Gets or sets the value of variable optMessageVersion.
        /// </summary>
        [TestVariable("35b221f8-4a1b-435e-a84d-48b5489f4e08")]
        public string optMessageVersion
        {
            get { return _optMessageVersion; }
            set { _optMessageVersion = value; }
        }

        string _optMessageRevision;

        /// <summary>
        /// Gets or sets the value of variable optMessageRevision.
        /// </summary>
        [TestVariable("c3da3da5-b5cd-49d7-99fb-dba907e0c2a1")]
        public string optMessageRevision
        {
            get { return _optMessageRevision; }
            set { _optMessageRevision = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("034cc1f9-b568-47fb-9fb7-ed20a68b2d0e")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("31d096cf-7591-445c-9f57-9cb5456ba015")]
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

            UserCodeCollections.NS_PTC_Message_Validations.ValidateDC_TRDL_ByContent(optDistrict, optMessageVersion, optMessageRevision, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}