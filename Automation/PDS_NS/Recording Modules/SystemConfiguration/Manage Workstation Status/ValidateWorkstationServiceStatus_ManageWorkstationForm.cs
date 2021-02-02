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

namespace PDS_NS.Recording_Modules.SystemConfiguration.Manage_Workstation_Status
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateWorkstationServiceStatus_ManageWorkstationForm recording.
    /// </summary>
    [TestModule("4e80f940-c5d2-4881-a42e-b6233dca0e16", ModuleType.Recording, 1)]
    public partial class ValidateWorkstationServiceStatus_ManageWorkstationForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateWorkstationServiceStatus_ManageWorkstationForm instance = new ValidateWorkstationServiceStatus_ManageWorkstationForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateWorkstationServiceStatus_ManageWorkstationForm()
        {
            workstation = "";
            officeLocation = "";
            status = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateWorkstationServiceStatus_ManageWorkstationForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _workstation;

        /// <summary>
        /// Gets or sets the value of variable workstation.
        /// </summary>
        [TestVariable("01a2c562-72a6-42dd-b9d3-9d4b47311e42")]
        public string workstation
        {
            get { return _workstation; }
            set { _workstation = value; }
        }

        string _officeLocation;

        /// <summary>
        /// Gets or sets the value of variable officeLocation.
        /// </summary>
        [TestVariable("b131defe-cee4-494d-ac9d-24326e7551df")]
        public string officeLocation
        {
            get { return _officeLocation; }
            set { _officeLocation = value; }
        }

        string _status;

        /// <summary>
        /// Gets or sets the value of variable status.
        /// </summary>
        [TestVariable("0beb20fb-5740-41fa-bb95-0a9f50365210")]
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("6f8b09fd-a73d-4f60-974c-821b251eafa8")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateWorkstationServiceStatus_ManageWorkstationForm(workstation, officeLocation, status, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}