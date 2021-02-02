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
    ///The SetNewScheduleTemplate_DailyShiftSchedule recording.
    /// </summary>
    [TestModule("b0f6b1aa-28f2-4af0-9bb9-330c1bd7c31c", ModuleType.Recording, 1)]
    public partial class SetNewScheduleTemplate_DailyShiftSchedule : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SetNewScheduleTemplate_DailyShiftSchedule instance = new SetNewScheduleTemplate_DailyShiftSchedule();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetNewScheduleTemplate_DailyShiftSchedule()
        {
            division = "";
            selectScheduleTemplate = "";
            scheduleTemplateName = "";
            scheduleTemplateDesc = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SetNewScheduleTemplate_DailyShiftSchedule Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("2c73a2a8-32d1-48d7-bbe9-c28eb54c063e")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _selectScheduleTemplate;

        /// <summary>
        /// Gets or sets the value of variable selectScheduleTemplate.
        /// </summary>
        [TestVariable("723c8a86-0daa-465a-9f02-cee811a71a8b")]
        public string selectScheduleTemplate
        {
            get { return _selectScheduleTemplate; }
            set { _selectScheduleTemplate = value; }
        }

        string _scheduleTemplateName;

        /// <summary>
        /// Gets or sets the value of variable scheduleTemplateName.
        /// </summary>
        [TestVariable("67bfaba4-3917-423c-a0f6-1cd60fa17186")]
        public string scheduleTemplateName
        {
            get { return _scheduleTemplateName; }
            set { _scheduleTemplateName = value; }
        }

        string _scheduleTemplateDesc;

        /// <summary>
        /// Gets or sets the value of variable scheduleTemplateDesc.
        /// </summary>
        [TestVariable("d3a8c13a-163a-4b07-9cbc-e55a335d18d7")]
        public string scheduleTemplateDesc
        {
            get { return _scheduleTemplateDesc; }
            set { _scheduleTemplateDesc = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("d628eaf9-3de7-4b50-b1c6-9dad1f5bcf82")]
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

            UserCodeCollections.NS_Assignments.NS_SetNewScheduleTemplate_DailyShiftSchedule(division, selectScheduleTemplate, scheduleTemplateName, scheduleTemplateDesc, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
