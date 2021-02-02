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
    ///The ValidateDG_BULI7_NS recording.
    /// </summary>
    [TestModule("d69bb4fc-ab2b-4b9d-bdc4-bfa498ec3a3f", ModuleType.Recording, 1)]
    public partial class ValidateDG_BULI7_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDG_BULI7_NS instance = new ValidateDG_BULI7_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDG_BULI7_NS()
        {
            filterValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDG_BULI7_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _filterValue;

        /// <summary>
        /// Gets or sets the value of variable filterValue.
        /// </summary>
        [TestVariable("3d42e264-2982-421d-802d-e62fd440f94d")]
        public string filterValue
        {
            get { return _filterValue; }
            set { _filterValue = value; }
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

            STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
            Delay.Milliseconds(0);
            
            STE.Code_Utils.ReceivePTCFileCollection_NS.addValueToFilters(filterValue);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "User", "Validate DG-BULI Received", new RecordItemIndex(2));
            
            STE.Code_Utils.ReceivePTCFileCollection_NS.validateDG_BULI_7(ValueConverter.ArgumentFromString<int>("timeInSeconds", "30"), ValueConverter.ArgumentFromString<bool>("retry", "True"));
            Delay.Milliseconds(0);
            
            STE.Code_Utils.ReceivePTCFileCollection_NS.clearFilters();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
