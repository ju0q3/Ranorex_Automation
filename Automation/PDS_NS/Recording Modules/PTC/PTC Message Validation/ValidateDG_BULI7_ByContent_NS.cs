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
    ///The ValidateDG_BULI7_ByContent_NS recording.
    /// </summary>
    [TestModule("69b1e3e8-b697-4eba-beea-fcb99bc96673", ModuleType.Recording, 1)]
    public partial class ValidateDG_BULI7_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDG_BULI7_ByContent_NS instance = new ValidateDG_BULI7_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDG_BULI7_ByContent_NS()
        {
            bulletinSeed = "";
            optMessageVersion = "";
            optMessageRevision = "";
            timeInSeconds = "5";
            retry = "True";
            optRouteCount = "";
            optDistrict = "";
            optAction = "";
            optSpeedRestrictCount = "";
            optRouteDistrictCount = "";
            optRouteDistrictName = "";
            optCrossingDistrictCount = "";
            optCrossingId = "";
            optCrossingDistrictName = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDG_BULI7_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("fc7698d8-8ac9-477a-8ad2-8dd784bc9a62")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _optMessageVersion;

        /// <summary>
        /// Gets or sets the value of variable optMessageVersion.
        /// </summary>
        [TestVariable("2e542f6d-2b96-4e39-9ce7-abc89273e2e9")]
        public string optMessageVersion
        {
            get { return _optMessageVersion; }
            set { _optMessageVersion = value; }
        }

        string _optMessageRevision;

        /// <summary>
        /// Gets or sets the value of variable optMessageRevision.
        /// </summary>
        [TestVariable("a0136aa9-1244-4f47-9572-5ec440d7ec00")]
        public string optMessageRevision
        {
            get { return _optMessageRevision; }
            set { _optMessageRevision = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("92824b14-04b8-4e72-acd3-e293fac3ebca")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("ca5f9be6-63f4-4ae1-853d-5215fe06b978")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        string _optRouteCount;

        /// <summary>
        /// Gets or sets the value of variable optRouteCount.
        /// </summary>
        [TestVariable("c189007c-c585-4c8d-901f-f7006e23bbc4")]
        public string optRouteCount
        {
            get { return _optRouteCount; }
            set { _optRouteCount = value; }
        }

        string _optDistrict;

        /// <summary>
        /// Gets or sets the value of variable optDistrict.
        /// </summary>
        [TestVariable("a78cb1e1-4583-4205-82ff-b5ef8cdec0ff")]
        public string optDistrict
        {
            get { return _optDistrict; }
            set { _optDistrict = value; }
        }

        string _optAction;

        /// <summary>
        /// Gets or sets the value of variable optAction.
        /// </summary>
        [TestVariable("99b87de1-f892-4baa-ba1f-7e8934fc9e6b")]
        public string optAction
        {
            get { return _optAction; }
            set { _optAction = value; }
        }

        string _optSpeedRestrictCount;

        /// <summary>
        /// Gets or sets the value of variable optSpeedRestrictCount.
        /// </summary>
        [TestVariable("af24f1b7-b608-496f-9f68-852fb10826b2")]
        public string optSpeedRestrictCount
        {
            get { return _optSpeedRestrictCount; }
            set { _optSpeedRestrictCount = value; }
        }

        string _optRouteDistrictCount;

        /// <summary>
        /// Gets or sets the value of variable optRouteDistrictCount.
        /// </summary>
        [TestVariable("c70aad51-8fd5-41ed-894a-e38fc7a97146")]
        public string optRouteDistrictCount
        {
            get { return _optRouteDistrictCount; }
            set { _optRouteDistrictCount = value; }
        }

        string _optRouteDistrictName;

        /// <summary>
        /// Gets or sets the value of variable optRouteDistrictName.
        /// </summary>
        [TestVariable("5165129f-6ba6-4a56-a845-c253cef8104c")]
        public string optRouteDistrictName
        {
            get { return _optRouteDistrictName; }
            set { _optRouteDistrictName = value; }
        }

        string _optCrossingDistrictCount;

        /// <summary>
        /// Gets or sets the value of variable optCrossingDistrictCount.
        /// </summary>
        [TestVariable("ab3269ce-595c-46b8-b839-1fe347591146")]
        public string optCrossingDistrictCount
        {
            get { return _optCrossingDistrictCount; }
            set { _optCrossingDistrictCount = value; }
        }

        string _optCrossingId;

        /// <summary>
        /// Gets or sets the value of variable optCrossingId.
        /// </summary>
        [TestVariable("be20cab3-fc53-4fc5-ba20-39f78efdbace")]
        public string optCrossingId
        {
            get { return _optCrossingId; }
            set { _optCrossingId = value; }
        }

        string _optCrossingDistrictName;

        /// <summary>
        /// Gets or sets the value of variable optCrossingDistrictName.
        /// </summary>
        [TestVariable("b42dae89-3e2a-4dd4-9757-9faea3ce584d")]
        public string optCrossingDistrictName
        {
            get { return _optCrossingDistrictName; }
            set { _optCrossingDistrictName = value; }
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

            UserCodeCollections.NS_PTC_Message_Validations.ValidateDG_BULI7_ByContent(bulletinSeed, optMessageVersion, optMessageRevision, optAction, optRouteCount, optDistrict, optSpeedRestrictCount, optRouteDistrictCount, optRouteDistrictName, optCrossingDistrictCount, optCrossingId, optCrossingDistrictName, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
