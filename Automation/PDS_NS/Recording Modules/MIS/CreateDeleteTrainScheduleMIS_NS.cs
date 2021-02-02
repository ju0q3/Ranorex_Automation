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

namespace PDS_NS.Recording_Modules.MIS
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateDeleteTrainScheduleMIS_NS recording.
    /// </summary>
    [TestModule("a33bb13d-7d5b-49cd-8eb5-bb25dd90e572", ModuleType.Recording, 1)]
    public partial class CreateDeleteTrainScheduleMIS_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateDeleteTrainScheduleMIS_NS instance = new CreateDeleteTrainScheduleMIS_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateDeleteTrainScheduleMIS_NS()
        {
            scac = "";
            section = "";
            trainSeed = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateDeleteTrainScheduleMIS_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _scac;

        /// <summary>
        /// Gets or sets the value of variable scac.
        /// </summary>
        [TestVariable("c508d1ed-2732-480f-9259-4633407fcc74")]
        public string scac
        {
            get { return _scac; }
            set { _scac = value; }
        }

        string _section;

        /// <summary>
        /// Gets or sets the value of variable section.
        /// </summary>
        [TestVariable("77758f0e-3cb9-45b8-8c18-d16969d9fd4e")]
        public string section
        {
            get { return _section; }
            set { _section = value; }
        }

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("7018c8f9-6504-4134-b9da-520723c044f5")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("b84d73cd-dcfe-4224-a56e-42f056afc64b")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            STE.Code_Utils.SendMISFileCollection_NS.NS_DeleteTrainSchedule(scac, section, trainSeed, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
