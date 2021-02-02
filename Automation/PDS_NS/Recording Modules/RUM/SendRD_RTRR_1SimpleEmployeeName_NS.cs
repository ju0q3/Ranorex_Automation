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
    ///The SendRD_RTRR_1SimpleEmployeeName_NS recording.
    /// </summary>
    [TestModule("96102799-b1d4-43e7-9656-cd81344b40a2", ModuleType.Recording, 1)]
    public partial class SendRD_RTRR_1SimpleEmployeeName_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendRD_RTRR_1SimpleEmployeeName_NS instance = new SendRD_RTRR_1SimpleEmployeeName_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendRD_RTRR_1SimpleEmployeeName_NS()
        {
            authoritySeed = "";
            district = "";
            pfAddressee = "";
            pfAddresseeType = "";
            requestingEmployee = "";
            rollupLocation = "";
            spafAck = "";
            division = "";
            ruComments = "";
            employeeFirstName = "";
            employeeMiddleName = "";
            employeeLastName = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendRD_RTRR_1SimpleEmployeeName_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("6573666a-ea7c-455b-8206-1e0abab50dec")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("b6532f36-38ca-43cd-bbba-9441ed562575")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _pfAddressee;

        /// <summary>
        /// Gets or sets the value of variable pfAddressee.
        /// </summary>
        [TestVariable("b375a188-4559-4c29-ab6b-f88561c2577c")]
        public string pfAddressee
        {
            get { return _pfAddressee; }
            set { _pfAddressee = value; }
        }

        string _pfAddresseeType;

        /// <summary>
        /// Gets or sets the value of variable pfAddresseeType.
        /// </summary>
        [TestVariable("928e8350-4491-41f4-a0f2-549dea8124e5")]
        public string pfAddresseeType
        {
            get { return _pfAddresseeType; }
            set { _pfAddresseeType = value; }
        }

        string _requestingEmployee;

        /// <summary>
        /// Gets or sets the value of variable requestingEmployee.
        /// </summary>
        [TestVariable("273877c0-163b-48cd-8c97-40fc737689e5")]
        public string requestingEmployee
        {
            get { return _requestingEmployee; }
            set { _requestingEmployee = value; }
        }

        string _rollupLocation;

        /// <summary>
        /// Gets or sets the value of variable rollupLocation.
        /// </summary>
        [TestVariable("01247845-04ff-4422-b063-b8eb8dc6dbec")]
        public string rollupLocation
        {
            get { return _rollupLocation; }
            set { _rollupLocation = value; }
        }

        string _spafAck;

        /// <summary>
        /// Gets or sets the value of variable spafAck.
        /// </summary>
        [TestVariable("e5a1c376-0ab2-4c88-96fd-7dcee9bb1d0e")]
        public string spafAck
        {
            get { return _spafAck; }
            set { _spafAck = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("19fd822e-90c3-46f4-a054-ba2ceeaad614")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _ruComments;

        /// <summary>
        /// Gets or sets the value of variable ruComments.
        /// </summary>
        [TestVariable("8580d3b3-a803-421f-9eb1-bba71c431df0")]
        public string ruComments
        {
            get { return _ruComments; }
            set { _ruComments = value; }
        }

        string _employeeFirstName;

        /// <summary>
        /// Gets or sets the value of variable employeeFirstName.
        /// </summary>
        [TestVariable("32f2b3cb-63be-4ece-a207-9d68e3619f0b")]
        public string employeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; }
        }

        string _employeeMiddleName;

        /// <summary>
        /// Gets or sets the value of variable employeeMiddleName.
        /// </summary>
        [TestVariable("b90b60ee-3106-4e3d-8370-19186488ac23")]
        public string employeeMiddleName
        {
            get { return _employeeMiddleName; }
            set { _employeeMiddleName = value; }
        }

        string _employeeLastName;

        /// <summary>
        /// Gets or sets the value of variable employeeLastName.
        /// </summary>
        [TestVariable("a91b5005-8682-4b85-bc62-2d9b47e4b7c0")]
        public string employeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("9d1f5326-3546-412f-8c8a-c3dc9e9de4d0")]
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

            UserCodeCollections.NS_RUM_Messages.sendRD_RTRR_1SimpleEmployeeName(authoritySeed, district, division, pfAddressee, pfAddresseeType, requestingEmployee, rollupLocation, employeeFirstName, employeeMiddleName, employeeLastName, spafAck, ruComments, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}