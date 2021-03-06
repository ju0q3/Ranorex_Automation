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
    ///The ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule recording.
    /// </summary>
    [TestModule("d716edf3-cdb9-4224-8fb7-e92a0a9c2b2c", ModuleType.Recording, 1)]
    public partial class ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule instance = new ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule()
        {
            scheduleTemplate = "";
            clickOk = "False";
            closeForm = "False";
            dayOfTheWeek = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule Instance
        {
            get { return instance; }
        }

#region Variables

        string _scheduleTemplate;

        /// <summary>
        /// Gets or sets the value of variable scheduleTemplate.
        /// </summary>
        [TestVariable("516e72f2-c758-4457-9294-5f8b1117afa5")]
        public string scheduleTemplate
        {
            get { return _scheduleTemplate; }
            set { _scheduleTemplate = value; }
        }

        string _clickOk;

        /// <summary>
        /// Gets or sets the value of variable clickOk.
        /// </summary>
        [TestVariable("5a9fdeaf-6a9b-42cb-9f23-e30487e7ade4")]
        public string clickOk
        {
            get { return _clickOk; }
            set { _clickOk = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("f4c26803-a2f9-4634-a57c-f42b9d13bc13")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _dayOfTheWeek;

        /// <summary>
        /// Gets or sets the value of variable dayOfTheWeek.
        /// </summary>
        [TestVariable("dd24718a-73d9-4274-8778-5d38b8b219fc")]
        public string dayOfTheWeek
        {
            get { return _dayOfTheWeek; }
            set { _dayOfTheWeek = value; }
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

            UserCodeCollections.NS_Assignments.NS_ModifyScheduleTemplateForDayOfTheWeek_MasterShiftSchedule(scheduleTemplate, dayOfTheWeek, ValueConverter.ArgumentFromString<bool>("clickOk", clickOk), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
