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

namespace PDS_NS.Recording_Modules.RUM
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendRD_RTER_1Simple_NS recording.
    /// </summary>
    [TestModule("fa75ac45-85b5-4902-b245-5364aef97df6", ModuleType.Recording, 1)]
    public partial class SendRD_RTER_1Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendRD_RTER_1Simple_NS instance = new SendRD_RTER_1Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendRD_RTER_1Simple_NS()
        {
            authoritySeed = "";
            crewSeed = "";
            district = "";
            division = "";
            pfAddressee = "";
            pfAddresseeType = "";
            requestingEmployee = "";
            requestedTimeExtensionOffsetMinutes = "";
            ruComments = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendRD_RTER_1Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("2239f058-c001-4c40-82d2-27b4c8d7447e")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("e4c7853a-594f-48bd-8928-b4aaae3e80ec")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("af0c3a69-f3ef-4e11-8147-b06d36590c9e")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("0df23f24-0284-4bc6-9f91-17cb4e6eb18b")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _pfAddressee;

        /// <summary>
        /// Gets or sets the value of variable pfAddressee.
        /// </summary>
        [TestVariable("e1976736-7fba-478e-82b5-c22914dfca0f")]
        public string pfAddressee
        {
            get { return _pfAddressee; }
            set { _pfAddressee = value; }
        }

        string _pfAddresseeType;

        /// <summary>
        /// Gets or sets the value of variable pfAddresseeType.
        /// </summary>
        [TestVariable("d1b387fb-04fb-4d8c-8019-d63a538735ae")]
        public string pfAddresseeType
        {
            get { return _pfAddresseeType; }
            set { _pfAddresseeType = value; }
        }

        string _requestingEmployee;

        /// <summary>
        /// Gets or sets the value of variable requestingEmployee.
        /// </summary>
        [TestVariable("f15c8fa2-e9d5-4fda-81fb-71eb447c0139")]
        public string requestingEmployee
        {
            get { return _requestingEmployee; }
            set { _requestingEmployee = value; }
        }

        string _requestedTimeExtensionOffsetMinutes;

        /// <summary>
        /// Gets or sets the value of variable requestedTimeExtensionOffsetMinutes.
        /// </summary>
        [TestVariable("93bbf7f6-5a75-4cfa-927b-e1d177e08c3b")]
        public string requestedTimeExtensionOffsetMinutes
        {
            get { return _requestedTimeExtensionOffsetMinutes; }
            set { _requestedTimeExtensionOffsetMinutes = value; }
        }

        string _ruComments;

        /// <summary>
        /// Gets or sets the value of variable ruComments.
        /// </summary>
        [TestVariable("6cb5ef52-0c25-4a04-8346-0ac80ab87921")]
        public string ruComments
        {
            get { return _ruComments; }
            set { _ruComments = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("cc488c28-7af5-4cd2-a211-85f2b264bfd1")]
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

            UserCodeCollections.NS_RUM_Messages.sendRD_RTER_1Simple(authoritySeed, crewSeed, district, division, pfAddressee, pfAddresseeType, requestingEmployee, requestedTimeExtensionOffsetMinutes, ruComments, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}