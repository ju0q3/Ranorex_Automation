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

namespace PDS_NS.Recording_Modules.SystemConfiguration.TrackingParameter
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDepartureTimeInterval_TrackingParameter_NS recording.
    /// </summary>
    [TestModule("20ac0df5-59c4-4127-8e3f-b61ed85a63de", ModuleType.Recording, 1)]
    public partial class ValidateDepartureTimeInterval_TrackingParameter_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDepartureTimeInterval_TrackingParameter_NS instance = new ValidateDepartureTimeInterval_TrackingParameter_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDepartureTimeInterval_TrackingParameter_NS()
        {
            expDepartureListVisibility = "";
            expDepartureEligibilityLimit = "";
            closeForm = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDepartureTimeInterval_TrackingParameter_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _expDepartureListVisibility;

        /// <summary>
        /// Gets or sets the value of variable expDepartureListVisibility.
        /// </summary>
        [TestVariable("d42574e0-c4b2-4373-99fb-37ed0e0bb432")]
        public string expDepartureListVisibility
        {
            get { return _expDepartureListVisibility; }
            set { _expDepartureListVisibility = value; }
        }

        string _expDepartureEligibilityLimit;

        /// <summary>
        /// Gets or sets the value of variable expDepartureEligibilityLimit.
        /// </summary>
        [TestVariable("5805433b-7a52-44a3-bc55-ebec0b7a39a2")]
        public string expDepartureEligibilityLimit
        {
            get { return _expDepartureEligibilityLimit; }
            set { _expDepartureEligibilityLimit = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("81dbe075-e4b9-4583-a153-0f6089cb62c2")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateDepartureTimeInterval_TrackingParameter(expDepartureListVisibility, expDepartureEligibilityLimit, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
