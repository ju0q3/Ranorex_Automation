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
    ///The ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule recording.
    /// </summary>
    [TestModule("950fa798-f8c5-4176-8c86-feaa5f09a725", ModuleType.Recording, 1)]
    public partial class ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule instance = new ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule()
        {
            scheduleTemplate = "";
            dayOfTheWeek = "";
            expectExists = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule Instance
        {
            get { return instance; }
        }

#region Variables

        string _scheduleTemplate;

        /// <summary>
        /// Gets or sets the value of variable scheduleTemplate.
        /// </summary>
        [TestVariable("3a23b867-4a23-496d-bfc5-3552204c72e3")]
        public string scheduleTemplate
        {
            get { return _scheduleTemplate; }
            set { _scheduleTemplate = value; }
        }

        string _dayOfTheWeek;

        /// <summary>
        /// Gets or sets the value of variable dayOfTheWeek.
        /// </summary>
        [TestVariable("f2a7bdd4-d14d-44ce-bda0-5408e82b131d")]
        public string dayOfTheWeek
        {
            get { return _dayOfTheWeek; }
            set { _dayOfTheWeek = value; }
        }

        string _expectExists;

        /// <summary>
        /// Gets or sets the value of variable expectExists.
        /// </summary>
        [TestVariable("d945b416-159a-4b9b-a911-8a1ce1eff08a")]
        public string expectExists
        {
            get { return _expectExists; }
            set { _expectExists = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("b2406d2d-73d5-4b44-9f0e-d6b32b2e10e8")]
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

            UserCodeCollections.NS_Assignments.NS_ValidateScheduleTemplateForDayOfTheWeekExists_MasterShiftSchedule(scheduleTemplate, dayOfTheWeek, ValueConverter.ArgumentFromString<bool>("expectExists", expectExists), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
