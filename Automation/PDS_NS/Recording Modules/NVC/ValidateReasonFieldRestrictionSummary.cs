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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateReasonFieldRestrictionSummary recording.
    /// </summary>
    [TestModule("820b4888-2f68-42ac-a2e2-7a604b9ae174", ModuleType.Recording, 1)]
    public partial class ValidateReasonFieldRestrictionSummary : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateReasonFieldRestrictionSummary instance = new ValidateReasonFieldRestrictionSummary();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateReasonFieldRestrictionSummary()
        {
            Type = "";
            StartMP = "";
            EndMP = "";
            Reason = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateReasonFieldRestrictionSummary Instance
        {
            get { return instance; }
        }

#region Variables

        string _Type;

        /// <summary>
        /// Gets or sets the value of variable Type.
        /// </summary>
        [TestVariable("de9ff979-c8c6-4a82-9b89-65927f3c97f6")]
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        string _StartMP;

        /// <summary>
        /// Gets or sets the value of variable StartMP.
        /// </summary>
        [TestVariable("f674250e-279d-493c-aac7-fa9d9dfdb56c")]
        public string StartMP
        {
            get { return _StartMP; }
            set { _StartMP = value; }
        }

        string _EndMP;

        /// <summary>
        /// Gets or sets the value of variable EndMP.
        /// </summary>
        [TestVariable("b6dcc196-d281-4bdd-81ba-baeae47705e9")]
        public string EndMP
        {
            get { return _EndMP; }
            set { _EndMP = value; }
        }

        string _Reason;

        /// <summary>
        /// Gets or sets the value of variable Reason.
        /// </summary>
        [TestVariable("6955194e-6195-433d-ae7a-c361af3bf8ce")]
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateReasonFieldRestrictionSummary(Type, StartMP, EndMP, Reason);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
