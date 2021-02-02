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
    ///The SendGD_ADSR_7Simple_NS recording.
    /// </summary>
    [TestModule("7975ab0f-d7df-4e17-9004-4094d39e8911", ModuleType.Recording, 1)]
    public partial class SendGD_ADSR_7Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendGD_ADSR_7Simple_NS instance = new SendGD_ADSR_7Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendGD_ADSR_7Simple_NS()
        {
            trainSeed = "";
            engineSeed = "";
            authoritySeed = "";
            action = "";
            statusCode = "";
            crewAckRequired = "";
            electronicAckRequested = "";
            hostname = "";
            districtScac = "";
            districtName = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendGD_ADSR_7Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("e0df7355-1f45-4765-8b52-3dd58518418b")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("7da468ca-3196-4db1-9f83-a30b9f1c1b93")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("6b43460e-4968-412f-9e5d-de0c6864d468")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("5aa1ecbf-f01c-47bf-b1d4-94a2fc2237a2")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        string _statusCode;

        /// <summary>
        /// Gets or sets the value of variable statusCode.
        /// </summary>
        [TestVariable("e2f6e959-4c89-4c3a-8e65-6598bd012eaa")]
        public string statusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        string _crewAckRequired;

        /// <summary>
        /// Gets or sets the value of variable crewAckRequired.
        /// </summary>
        [TestVariable("c654cadd-88cd-41c7-807a-e007d9624568")]
        public string crewAckRequired
        {
            get { return _crewAckRequired; }
            set { _crewAckRequired = value; }
        }

        string _electronicAckRequested;

        /// <summary>
        /// Gets or sets the value of variable electronicAckRequested.
        /// </summary>
        [TestVariable("86679527-c2d3-4672-a8ff-3a151394fd46")]
        public string electronicAckRequested
        {
            get { return _electronicAckRequested; }
            set { _electronicAckRequested = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("a2b48b1d-5695-4079-ad3a-7973669c7651")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        string _districtScac;

        /// <summary>
        /// Gets or sets the value of variable districtScac.
        /// </summary>
        [TestVariable("d8526220-5b9e-40ae-b34d-70babf3a5c61")]
        public string districtScac
        {
            get { return _districtScac; }
            set { _districtScac = value; }
        }

        string _districtName;

        /// <summary>
        /// Gets or sets the value of variable districtName.
        /// </summary>
        [TestVariable("f5844f1c-ae04-4a2b-8216-fe376caf3479")]
        public string districtName
        {
            get { return _districtName; }
            set { _districtName = value; }
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

            UserCodeCollections.NS_PTC_Messages.SendGD_ADSR_7Simple(trainSeed, engineSeed, authoritySeed, districtScac, districtName, action, statusCode, crewAckRequired, electronicAckRequested, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
