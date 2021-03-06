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

namespace PDS_NS.Recording_Modules.Bulletins
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS recording.
    /// </summary>
    [TestModule("cfa5b45f-4a51-4f78-916f-ac6a04462644", ModuleType.Recording, 1)]
    public partial class InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS instance = new InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS()
        {
            district = "";
            betweenMilepost1 = "";
            andMilepost1 = "";
            betweenMilepost2 = "";
            andMilepost2 = "";
            betweenMilepost3 = "";
            andMilepost3 = "";
            betweenMilepost4 = "";
            andMilepost4 = "";
            generateOrViewReport = "False";
            reset = "True";
            closeForm = "True";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputDistrictBetweenAndMileposts_BulletinSummaryReport_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("23b6a51d-ae62-48d8-83a3-a9ef7e6a6507")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _betweenMilepost1;

        /// <summary>
        /// Gets or sets the value of variable betweenMilepost1.
        /// </summary>
        [TestVariable("43f10412-cd39-4e2c-a115-53e3279b1af9")]
        public string betweenMilepost1
        {
            get { return _betweenMilepost1; }
            set { _betweenMilepost1 = value; }
        }

        string _andMilepost1;

        /// <summary>
        /// Gets or sets the value of variable andMilepost1.
        /// </summary>
        [TestVariable("c9d353aa-9612-40f1-8179-3ff04e7f5c7d")]
        public string andMilepost1
        {
            get { return _andMilepost1; }
            set { _andMilepost1 = value; }
        }

        string _betweenMilepost2;

        /// <summary>
        /// Gets or sets the value of variable betweenMilepost2.
        /// </summary>
        [TestVariable("25d21ef1-2e79-4da0-9770-44239fb409d2")]
        public string betweenMilepost2
        {
            get { return _betweenMilepost2; }
            set { _betweenMilepost2 = value; }
        }

        string _andMilepost2;

        /// <summary>
        /// Gets or sets the value of variable andMilepost2.
        /// </summary>
        [TestVariable("93b455ac-ddf7-4061-b9c1-1a300e119823")]
        public string andMilepost2
        {
            get { return _andMilepost2; }
            set { _andMilepost2 = value; }
        }

        string _betweenMilepost3;

        /// <summary>
        /// Gets or sets the value of variable betweenMilepost3.
        /// </summary>
        [TestVariable("1c01a796-a7d4-4410-97ed-29acdd4e7323")]
        public string betweenMilepost3
        {
            get { return _betweenMilepost3; }
            set { _betweenMilepost3 = value; }
        }

        string _andMilepost3;

        /// <summary>
        /// Gets or sets the value of variable andMilepost3.
        /// </summary>
        [TestVariable("f23ecbf0-5518-420b-904e-3b899c7654ce")]
        public string andMilepost3
        {
            get { return _andMilepost3; }
            set { _andMilepost3 = value; }
        }

        string _betweenMilepost4;

        /// <summary>
        /// Gets or sets the value of variable betweenMilepost4.
        /// </summary>
        [TestVariable("13d96ecd-e4ca-4acc-9740-c12962b0c64f")]
        public string betweenMilepost4
        {
            get { return _betweenMilepost4; }
            set { _betweenMilepost4 = value; }
        }

        string _andMilepost4;

        /// <summary>
        /// Gets or sets the value of variable andMilepost4.
        /// </summary>
        [TestVariable("4cea2cfa-974e-4d80-998a-bfc61dd17e1b")]
        public string andMilepost4
        {
            get { return _andMilepost4; }
            set { _andMilepost4 = value; }
        }

        string _generateOrViewReport;

        /// <summary>
        /// Gets or sets the value of variable generateOrViewReport.
        /// </summary>
        [TestVariable("1591de30-8963-46e5-a8d9-49bdac2f3896")]
        public string generateOrViewReport
        {
            get { return _generateOrViewReport; }
            set { _generateOrViewReport = value; }
        }

        string _reset;

        /// <summary>
        /// Gets or sets the value of variable reset.
        /// </summary>
        [TestVariable("506a4a5a-3dc2-4ae6-8b87-78cd6b5accf9")]
        public string reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("ccc735cb-0cb0-46fb-b187-d5248b04c857")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("da08ef14-5b9e-4fb4-85e9-23e7ea83ce5a")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_Bulletin.NS_InputDistrictBetweenAndMileposts_BulletinSummaryReport(district, betweenMilepost1, andMilepost1, betweenMilepost2, andMilepost2, betweenMilepost3, andMilepost3, betweenMilepost4, andMilepost4, expectedFeedback, ValueConverter.ArgumentFromString<bool>("clickGenerateOrViewReport", generateOrViewReport), ValueConverter.ArgumentFromString<bool>("reset", reset), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
