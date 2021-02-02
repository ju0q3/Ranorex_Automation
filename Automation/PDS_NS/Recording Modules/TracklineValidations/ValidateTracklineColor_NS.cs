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

namespace PDS_NS.Recording_Modules.TracklineValidations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateTracklineColor_NS recording.
    /// </summary>
    [TestModule("f10c7073-1265-458c-a439-a9645f71b8be", ModuleType.Recording, 1)]
    public partial class ValidateTracklineColor_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTracklineColor_NS instance = new ValidateTracklineColor_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTracklineColor_NS()
        {
            objectType = "";
            sectionId = "";
            color = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTracklineColor_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _objectType;

        /// <summary>
        /// Gets or sets the value of variable objectType.
        /// </summary>
        [TestVariable("c436ded5-d3fd-48fe-9dc7-3e4a5da7d4e1")]
        public string objectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        string _sectionId;

        /// <summary>
        /// Gets or sets the value of variable sectionId.
        /// </summary>
        [TestVariable("d57a7d39-b742-4b24-811c-3a2a901cdd49")]
        public string sectionId
        {
            get { return _sectionId; }
            set { _sectionId = value; }
        }

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("20817a77-932c-4734-839c-a7a505d5cac6")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ValidateTracklineObjectColor(objectType, sectionId, color);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}