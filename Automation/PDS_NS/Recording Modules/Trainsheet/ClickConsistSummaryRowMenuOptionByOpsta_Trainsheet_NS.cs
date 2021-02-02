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

namespace PDS_NS.Recording_Modules.Trainsheet
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS recording.
    /// </summary>
    [TestModule("15ac6b50-af32-417f-82bf-4a4a716540c8", ModuleType.Recording, 1)]
    public partial class ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS instance = new ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS()
        {
            trainSeed = "";
            opsta = "";
            menuOption = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("4795e9db-9e47-4300-bd1e-d5efd3d18868")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("a862fee6-bf75-4487-8139-46be26ca241a")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _menuOption;

        /// <summary>
        /// Gets or sets the value of variable menuOption.
        /// </summary>
        [TestVariable("1e84494f-435f-4975-ad31-8d62fca0fd53")]
        public string menuOption
        {
            get { return _menuOption; }
            set { _menuOption = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("9692f663-6670-4f1d-a9b6-7a38f041e6fd")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ClickConsistSummaryRowMenuOptionByOpsta_Trainsheet_ConsistSummary(trainSeed, opsta, menuOption, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
