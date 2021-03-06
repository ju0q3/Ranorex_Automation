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

namespace PDS_NS.Recording_Modules.DRA
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ValidateTrainInformationInProjectedTable recording.
    /// </summary>
    [TestModule("6e3a21d7-790c-4fa2-aae8-b66569849704", ModuleType.Recording, 1)]
    public partial class NS_ValidateTrainInformationInProjectedTable : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateTrainInformationInProjectedTable instance = new NS_ValidateTrainInformationInProjectedTable();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateTrainInformationInProjectedTable()
        {
            trainSeed = "";
            draName = "";
            divisionName = "";
            validateTrainPresent = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateTrainInformationInProjectedTable Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("fafa2dc0-c78f-440b-87d2-14d6293399ab")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _draName;

        /// <summary>
        /// Gets or sets the value of variable draName.
        /// </summary>
        [TestVariable("7da749be-1b6c-4930-abb1-57641e259e94")]
        public string draName
        {
            get { return _draName; }
            set { _draName = value; }
        }

        string _divisionName;

        /// <summary>
        /// Gets or sets the value of variable divisionName.
        /// </summary>
        [TestVariable("67358fb2-d4ab-43ff-be74-3b8d45845f27")]
        public string divisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        string _validateTrainPresent;

        /// <summary>
        /// Gets or sets the value of variable validateTrainPresent.
        /// </summary>
        [TestVariable("d12d503c-64d5-44a5-978b-7e1990fa5a1f")]
        public string validateTrainPresent
        {
            get { return _validateTrainPresent; }
            set { _validateTrainPresent = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("1855c411-3e9d-40f6-8bb4-9c08e3f41f66")]
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

            UserCodeCollections.NS_DRA.NS_ValidateInformationInProjectedTable(trainSeed, draName, divisionName, ValueConverter.ArgumentFromString<bool>("validateTrainPresent", validateTrainPresent), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
