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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_validate_ETA_record_BackFlow recording.
    /// </summary>
    [TestModule("f160bdf7-8a36-4604-bdc4-fe3f461e22cb", ModuleType.Recording, 1)]
    public partial class NS_validate_ETA_record_BackFlow : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_validate_ETA_record_BackFlow instance = new NS_validate_ETA_record_BackFlow();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_validate_ETA_record_BackFlow()
        {
            trainSeed = "";
            opstaLocation = "";
            isPresent = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_validate_ETA_record_BackFlow Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("e3cb5401-383c-4e5a-bb39-9ba090e4a7ce")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opstaLocation;

        /// <summary>
        /// Gets or sets the value of variable opstaLocation.
        /// </summary>
        [TestVariable("5d48394e-37cf-48b3-aa4d-3794a0d6c7ae")]
        public string opstaLocation
        {
            get { return _opstaLocation; }
            set { _opstaLocation = value; }
        }

        string _isPresent;

        /// <summary>
        /// Gets or sets the value of variable isPresent.
        /// </summary>
        [TestVariable("dd77736e-0277-4cfd-86bd-f70a2056ba24")]
        public string isPresent
        {
            get { return _isPresent; }
            set { _isPresent = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_validate_ETArecord_BackFlow(trainSeed, opstaLocation, ValueConverter.ArgumentFromString<bool>("IsPresent", isPresent));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
