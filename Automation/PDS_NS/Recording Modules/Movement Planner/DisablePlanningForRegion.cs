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
    ///The DisablePlanningForRegion recording.
    /// </summary>
    [TestModule("cdef0c71-7076-4059-b966-1ab489e816a8", ModuleType.Recording, 1)]
    public partial class DisablePlanningForRegion : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.SystemConfiguration_Repo repository.
        /// </summary>
        public static global::PDS_NS.SystemConfiguration_Repo repo = global::PDS_NS.SystemConfiguration_Repo.Instance;

        static DisablePlanningForRegion instance = new DisablePlanningForRegion();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DisablePlanningForRegion()
        {
            regionName = "";
            closeForms = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DisablePlanningForRegion Instance
        {
            get { return instance; }
        }

#region Variables

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("455c0ac4-001b-4299-b036-62387045180b")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        /// <summary>
        /// Gets or sets the value of variable regionName.
        /// </summary>
        [TestVariable("b9b8ef35-76e0-468e-858f-3f56e57743a6")]
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

            UserCodeCollections.NS_MovementPlanner.NS_DisablePlanningForRegion(regionName, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
