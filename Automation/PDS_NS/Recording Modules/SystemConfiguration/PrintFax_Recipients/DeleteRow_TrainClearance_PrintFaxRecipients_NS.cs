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

namespace PDS_NS.Recording_Modules.SystemConfiguration.PrintFax_Recipients
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DeleteRow_TrainClearance_PrintFaxRecipients_NS recording.
    /// </summary>
    [TestModule("9415dc74-403a-4c70-a12c-2e3f12ec9f9e", ModuleType.Recording, 1)]
    public partial class DeleteRow_TrainClearance_PrintFaxRecipients_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DeleteRow_TrainClearance_PrintFaxRecipients_NS instance = new DeleteRow_TrainClearance_PrintFaxRecipients_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DeleteRow_TrainClearance_PrintFaxRecipients_NS()
        {
            CrewChangeOpSta = "";
            RouteOpSta = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DeleteRow_TrainClearance_PrintFaxRecipients_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _CrewChangeOpSta;

        /// <summary>
        /// Gets or sets the value of variable CrewChangeOpSta.
        /// </summary>
        [TestVariable("3fe5de1e-9f4e-44f4-a43c-61c84e27b1a5")]
        public string CrewChangeOpSta
        {
            get { return _CrewChangeOpSta; }
            set { _CrewChangeOpSta = value; }
        }

        string _RouteOpSta;

        /// <summary>
        /// Gets or sets the value of variable RouteOpSta.
        /// </summary>
        [TestVariable("70e9c029-7e28-4bbf-918c-9d4079a94741")]
        public string RouteOpSta
        {
            get { return _RouteOpSta; }
            set { _RouteOpSta = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("0cc9ab6b-1ca0-4d4c-9bb9-efed6a159527")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_DeleteRow_TrainClearance_PrintFaxRecipients(CrewChangeOpSta, RouteOpSta, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
