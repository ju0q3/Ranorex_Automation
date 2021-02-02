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

namespace PDS_NS.Recording_Modules.Movement_Planner
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The StartPlanningCycleForRegion recording.
    /// </summary>
    [TestModule("a34a58c4-f1a1-41b9-8e22-9faca0ffefcb", ModuleType.Recording, 1)]
    public partial class StartPlanningCycleForRegion : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static StartPlanningCycleForRegion instance = new StartPlanningCycleForRegion();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public StartPlanningCycleForRegion()
        {
            regionName = "Default Planning Region";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static StartPlanningCycleForRegion Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("f3c7e273-55d7-4789-a7a0-3d15f9c50102")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable regionName.
        /// </summary>
        [TestVariable("d0fac67a-0183-4295-a43b-eecd472ff54b")]
        public string regionName
        {
            get { return repo.RegionName; }
            set { repo.RegionName = value; }
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

            UserCodeCollections.NS_MovementPlanner.NS_StartPlanningForRegion(regionName, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
