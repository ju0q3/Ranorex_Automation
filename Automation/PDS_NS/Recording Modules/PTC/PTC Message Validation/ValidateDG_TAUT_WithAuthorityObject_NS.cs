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
    ///The ValidateDG_TAUT_WithAuthorityObject_NS recording.
    /// </summary>
    [TestModule("8b545435-2a29-4f2f-a32f-ebfd293b55e5", ModuleType.Recording, 1)]
    public partial class ValidateDG_TAUT_WithAuthorityObject_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDG_TAUT_WithAuthorityObject_NS instance = new ValidateDG_TAUT_WithAuthorityObject_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDG_TAUT_WithAuthorityObject_NS()
        {
            authoritySeed = "";
            action = "";
            district = "";
            crewAck = "False";
            electronicAck = "False";
            messageVersion = "7";
            messageRevision = "0";
            time = "120";
            retry = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDG_TAUT_WithAuthorityObject_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("48357be5-d500-40c5-a512-c6cb91ec537a")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("ad35d97d-e936-4e8f-aeb4-8d5cbb7bdc0c")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("8644076e-ab4a-485c-a06d-f02c16596857")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _crewAck;

        /// <summary>
        /// Gets or sets the value of variable crewAck.
        /// </summary>
        [TestVariable("0d4e3235-0ace-474c-96dd-d00fbdfbaa88")]
        public string crewAck
        {
            get { return _crewAck; }
            set { _crewAck = value; }
        }

        string _electronicAck;

        /// <summary>
        /// Gets or sets the value of variable electronicAck.
        /// </summary>
        [TestVariable("de6fa448-0b86-4f69-8610-36500d638f7d")]
        public string electronicAck
        {
            get { return _electronicAck; }
            set { _electronicAck = value; }
        }

        string _messageVersion;

        /// <summary>
        /// Gets or sets the value of variable messageVersion.
        /// </summary>
        [TestVariable("5ce61b0c-03d1-4f78-88f9-7f0664a532e7")]
        public string messageVersion
        {
            get { return _messageVersion; }
            set { _messageVersion = value; }
        }

        string _messageRevision;

        /// <summary>
        /// Gets or sets the value of variable messageRevision.
        /// </summary>
        [TestVariable("cee000cc-76bb-48de-92f8-961368793b64")]
        public string messageRevision
        {
            get { return _messageRevision; }
            set { _messageRevision = value; }
        }

        string _time;

        /// <summary>
        /// Gets or sets the value of variable time.
        /// </summary>
        [TestVariable("47ecada8-d0a1-439f-a6b1-05a45826272e")]
        public string time
        {
            get { return _time; }
            set { _time = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("fba18c29-e304-4678-94db-d3e28cf93ffb")]
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

            try {
                UserCodeCollections.NS_PTC_Message_Validations.ValidateDG_TAUT_WithAuthorityObj(authoritySeed, action, district, ValueConverter.ArgumentFromString<bool>("crewAckRequired", crewAck), ValueConverter.ArgumentFromString<bool>("electronicAckRequired", electronicAck), messageVersion, messageRevision, ValueConverter.ArgumentFromString<int>("timeInSeconds", time), ValueConverter.ArgumentFromString<bool>("retry", retry));
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}