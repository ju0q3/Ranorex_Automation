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

namespace PDS_NS.Recording_Modules.Assignments
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SetScheduleTimeForDispaterTerritory_DailyShiftSchedule recording.
    /// </summary>
    [TestModule("defb1100-144f-4883-b062-74f7cd39fb39", ModuleType.Recording, 1)]
    public partial class SetScheduleTimeForDispaterTerritory_DailyShiftSchedule : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SetScheduleTimeForDispaterTerritory_DailyShiftSchedule instance = new SetScheduleTimeForDispaterTerritory_DailyShiftSchedule();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetScheduleTimeForDispaterTerritory_DailyShiftSchedule()
        {
            division = "";
            selectScheduleTemplate = "";
            time = "";
            timeColumnNumber = "";
            apply = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SetScheduleTimeForDispaterTerritory_DailyShiftSchedule Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("99d7ffac-c4e8-4211-9bb7-97880a8122cd")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _selectScheduleTemplate;

        /// <summary>
        /// Gets or sets the value of variable selectScheduleTemplate.
        /// </summary>
        [TestVariable("59503944-1a8c-4f71-9ee2-888b6a57a1d7")]
        public string selectScheduleTemplate
        {
            get { return _selectScheduleTemplate; }
            set { _selectScheduleTemplate = value; }
        }

        string _time;

        /// <summary>
        /// Gets or sets the value of variable time.
        /// </summary>
        [TestVariable("c2733982-88c8-4617-9995-ea6748d8acfd")]
        public string time
        {
            get { return _time; }
            set { _time = value; }
        }

        string _timeColumnNumber;

        /// <summary>
        /// Gets or sets the value of variable timeColumnNumber.
        /// </summary>
        [TestVariable("fe457aac-46d7-4d00-8f2c-4f29a0f84085")]
        public string timeColumnNumber
        {
            get { return _timeColumnNumber; }
            set { _timeColumnNumber = value; }
        }

        string _apply;

        /// <summary>
        /// Gets or sets the value of variable apply.
        /// </summary>
        [TestVariable("aad0115d-ae2d-4254-a921-ba1933f8a25f")]
        public string apply
        {
            get { return _apply; }
            set { _apply = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("45cf52fe-3a62-4e8a-9b40-32116052c531")]
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

            UserCodeCollections.NS_Assignments.NS_SetScheduleTimeForDispaterTerritory_DailyShiftSchedule(division, selectScheduleTemplate, time, timeColumnNumber, ValueConverter.ArgumentFromString<bool>("apply", apply), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
