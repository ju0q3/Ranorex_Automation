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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateMaximumLevelsValue_StationLabels_NVC recording.
    /// </summary>
    [TestModule("1e843345-b293-4e95-9abe-0542970abead", ModuleType.Recording, 1)]
    public partial class ValidateMaximumLevelsValue_StationLabels_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateMaximumLevelsValue_StationLabels_NVC instance = new ValidateMaximumLevelsValue_StationLabels_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateMaximumLevelsValue_StationLabels_NVC()
        {
            maxLevelValue = "";
            expectExists = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateMaximumLevelsValue_StationLabels_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _maxLevelValue;

        /// <summary>
        /// Gets or sets the value of variable maxLevelValue.
        /// </summary>
        [TestVariable("41265d69-9b44-4356-9246-628751d42c80")]
        public string maxLevelValue
        {
            get { return _maxLevelValue; }
            set { _maxLevelValue = value; }
        }

        string _expectExists;

        /// <summary>
        /// Gets or sets the value of variable expectExists.
        /// </summary>
        [TestVariable("69e8b4fc-710e-4112-9be2-948c91a9b1a4")]
        public string expectExists
        {
            get { return _expectExists; }
            set { _expectExists = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateMaximumLevelsValue_StationLabels_NVC(maxLevelValue, ValueConverter.ArgumentFromString<bool>("expectExists", expectExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
