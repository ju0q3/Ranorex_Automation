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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CDMS_ValidateBIVoiceAckByDistrict_NS recording.
    /// </summary>
    [TestModule("2e25690d-1d8c-48bb-9126-c38546added3", ModuleType.Recording, 1)]
    public partial class CDMS_ValidateBIVoiceAckByDistrict_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_ValidateBIVoiceAckByDistrict_NS instance = new CDMS_ValidateBIVoiceAckByDistrict_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_ValidateBIVoiceAckByDistrict_NS()
        {
            districtName = "";
            isBIVoiceAckEnabled = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_ValidateBIVoiceAckByDistrict_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _districtName;

        /// <summary>
        /// Gets or sets the value of variable districtName.
        /// </summary>
        [TestVariable("f7d23cfa-7720-48e6-802a-95a211e83955")]
        public string districtName
        {
            get { return _districtName; }
            set { _districtName = value; }
        }

        string _isBIVoiceAckEnabled;

        /// <summary>
        /// Gets or sets the value of variable isBIVoiceAckEnabled.
        /// </summary>
        [TestVariable("2d3353d9-a68d-4d9d-b86a-7baeccc2c289")]
        public string isBIVoiceAckEnabled
        {
            get { return _isBIVoiceAckEnabled; }
            set { _isBIVoiceAckEnabled = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateBIVoiceAckByDistrict_PTCConfiguration(districtName, ValueConverter.ArgumentFromString<bool>("isBIVoiceAckEnabled", isBIVoiceAckEnabled));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
