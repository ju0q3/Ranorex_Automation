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

namespace PDS_NS.Recording_Modules.PTC.PTC_Messages
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendGD_CTER_7Simple_NS recording.
    /// </summary>
    [TestModule("311446df-2789-4bca-a0be-1afb9f8061c4", ModuleType.Recording, 1)]
    public partial class SendGD_CTER_7Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendGD_CTER_7Simple_NS instance = new SendGD_CTER_7Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendGD_CTER_7Simple_NS()
        {
            trainSeed = "";
            crewSeed = "";
            engineSeed = "";
            authorityseed = "";
            req_time_extension = "";
            districtScac = "";
            districtName = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendGD_CTER_7Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("ced2eaf2-e28a-49ac-a752-79c657adcfd6")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("fb0f7cdc-144f-4d3c-bee0-bb6ab2c4168e")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("a142e753-07c0-436c-b3cf-a26af16cd66e")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _authorityseed;

        /// <summary>
        /// Gets or sets the value of variable authorityseed.
        /// </summary>
        [TestVariable("9e98c175-b7c9-4fb4-8c9d-1f8cd201001e")]
        public string authorityseed
        {
            get { return _authorityseed; }
            set { _authorityseed = value; }
        }

        string _req_time_extension;

        /// <summary>
        /// Gets or sets the value of variable req_time_extension.
        /// </summary>
        [TestVariable("e8c67973-72cd-497e-a86e-bf8cc7437bbc")]
        public string req_time_extension
        {
            get { return _req_time_extension; }
            set { _req_time_extension = value; }
        }

        string _districtScac;

        /// <summary>
        /// Gets or sets the value of variable districtScac.
        /// </summary>
        [TestVariable("9697a7dd-97ed-4ed0-87b9-3506bc95e68e")]
        public string districtScac
        {
            get { return _districtScac; }
            set { _districtScac = value; }
        }

        string _districtName;

        /// <summary>
        /// Gets or sets the value of variable districtName.
        /// </summary>
        [TestVariable("957aa769-94f4-45b8-86fb-332f42144c28")]
        public string districtName
        {
            get { return _districtName; }
            set { _districtName = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("bbf24624-5552-4343-8354-186829da6e01")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_PTC_Messages.SendGD_CTER_7Simple(trainSeed, crewSeed, engineSeed, authorityseed, req_time_extension, districtScac, districtName, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}