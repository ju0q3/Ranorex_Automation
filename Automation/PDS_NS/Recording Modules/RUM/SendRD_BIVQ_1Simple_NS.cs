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
    ///The SendRD_BIVQ_1Simple_NS recording.
    /// </summary>
    [TestModule("e6ed17d8-a7b7-4380-9f5d-c29f3ef1849c", ModuleType.Recording, 1)]
    public partial class SendRD_BIVQ_1Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendRD_BIVQ_1Simple_NS instance = new SendRD_BIVQ_1Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendRD_BIVQ_1Simple_NS()
        {
            district = "";
            division = "";
            pfAddress = "";
            pfAddressType = "";
            employeeName = "";
            employeeNameNote = "";
            hostname = "";
            bulletinSeed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendRD_BIVQ_1Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("e3e79b3d-c39d-45ab-b1dc-3d2674e584d8")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("e2e5d0bb-049a-4b40-8f56-9d2210c81b46")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _pfAddress;

        /// <summary>
        /// Gets or sets the value of variable pfAddress.
        /// </summary>
        [TestVariable("d0640b4f-c19f-45d5-b996-1e8faeffd482")]
        public string pfAddress
        {
            get { return _pfAddress; }
            set { _pfAddress = value; }
        }

        string _pfAddressType;

        /// <summary>
        /// Gets or sets the value of variable pfAddressType.
        /// </summary>
        [TestVariable("3014b8b6-34b3-4b3e-b520-dbb1c13f82d0")]
        public string pfAddressType
        {
            get { return _pfAddressType; }
            set { _pfAddressType = value; }
        }

        string _employeeName;

        /// <summary>
        /// Gets or sets the value of variable employeeName.
        /// </summary>
        [TestVariable("9f187a52-ac23-48b5-b50e-1dc6bb00e270")]
        public string employeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        string _employeeNameNote;

        /// <summary>
        /// Gets or sets the value of variable employeeNameNote.
        /// </summary>
        [TestVariable("3b8b1d67-1c0b-4bf2-99b3-e81c0c002663")]
        public string employeeNameNote
        {
            get { return _employeeNameNote; }
            set { _employeeNameNote = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("c5b13dd8-fdc5-4ba2-8d23-db7f133cf107")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("e816725f-cd56-4f93-b16c-4cebbe11809c")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
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

            UserCodeCollections.NS_RUM_Messages.sendRD_BIVQ_1Simple(bulletinSeed, district, division, pfAddress, pfAddressType, employeeName, employeeNameNote, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}