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
    ///The ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE recording.
    /// </summary>
    [TestModule("8ee7e243-1ae6-401d-9b37-f98f13bbf56c", ModuleType.Recording, 1)]
    public partial class ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE instance = new ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE()
        {
            trainSymbolTrainSeed = "";
            originDateTrainSeed = "";
            minutesBeforeNow = "";
            expectedCount = "";
            validateExists = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_ValidateDC_MESS_ABF_OTC_MESSAGE Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSymbolTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSymbolTrainSeed.
        /// </summary>
        [TestVariable("4690cb2e-c4c6-4c9b-8b02-fabc850f25f1")]
        public string trainSymbolTrainSeed
        {
            get { return _trainSymbolTrainSeed; }
            set { _trainSymbolTrainSeed = value; }
        }

        string _originDateTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable originDateTrainSeed.
        /// </summary>
        [TestVariable("ec89f81b-47c8-4a90-b9fe-c89a05756ca9")]
        public string originDateTrainSeed
        {
            get { return _originDateTrainSeed; }
            set { _originDateTrainSeed = value; }
        }

        string _minutesBeforeNow;

        /// <summary>
        /// Gets or sets the value of variable minutesBeforeNow.
        /// </summary>
        [TestVariable("eb5861c9-3734-40ce-8c48-334596aeb645")]
        public string minutesBeforeNow
        {
            get { return _minutesBeforeNow; }
            set { _minutesBeforeNow = value; }
        }

        string _expectedCount;

        /// <summary>
        /// Gets or sets the value of variable expectedCount.
        /// </summary>
        [TestVariable("2790499c-4ee9-4306-894b-87477a28cc78")]
        public string expectedCount
        {
            get { return _expectedCount; }
            set { _expectedCount = value; }
        }

        string _validateExists;

        /// <summary>
        /// Gets or sets the value of variable validateExists.
        /// </summary>
        [TestVariable("7c2cd3af-8c2c-4cd8-97a9-3e349bed403a")]
        public string validateExists
        {
            get { return _validateExists; }
            set { _validateExists = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateDC_MESS_ABF_OTC_MESSAGE_ADMS(trainSymbolTrainSeed, originDateTrainSeed, minutesBeforeNow, expectedCount, ValueConverter.ArgumentFromString<bool>("validateExists", validateExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
