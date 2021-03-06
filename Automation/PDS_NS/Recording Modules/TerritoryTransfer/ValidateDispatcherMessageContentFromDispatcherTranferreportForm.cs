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

namespace PDS_NS.Recording_Modules.TerritoryTransfer
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDispatcherMessageContentFromDispatcherTranferreportForm recording.
    /// </summary>
    [TestModule("9bb73826-3fcf-4204-95f8-5275c4c0709c", ModuleType.Recording, 1)]
    public partial class ValidateDispatcherMessageContentFromDispatcherTranferreportForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDispatcherMessageContentFromDispatcherTranferreportForm instance = new ValidateDispatcherMessageContentFromDispatcherTranferreportForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDispatcherMessageContentFromDispatcherTranferreportForm()
        {
            division = "";
            dispatchTerritory = "";
            dispatcherMessageContent = "";
            expectedTask = "False";
            closeForm = "False";
            optDivision = "";
            optLogicalPosition = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDispatcherMessageContentFromDispatcherTranferreportForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("635fa7c0-13b9-4227-a8f1-4fab95524930")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _dispatchTerritory;

        /// <summary>
        /// Gets or sets the value of variable dispatchTerritory.
        /// </summary>
        [TestVariable("0135dec5-f01a-4616-8bd6-3d806171ec80")]
        public string dispatchTerritory
        {
            get { return _dispatchTerritory; }
            set { _dispatchTerritory = value; }
        }

        string _dispatcherMessageContent;

        /// <summary>
        /// Gets or sets the value of variable dispatcherMessageContent.
        /// </summary>
        [TestVariable("17b7755c-7923-40ae-af2b-1cef3ac70f3c")]
        public string dispatcherMessageContent
        {
            get { return _dispatcherMessageContent; }
            set { _dispatcherMessageContent = value; }
        }

        string _expectedTask;

        /// <summary>
        /// Gets or sets the value of variable expectedTask.
        /// </summary>
        [TestVariable("97a315f0-ddcc-4e58-8fc7-eb8b9f2b5e58")]
        public string expectedTask
        {
            get { return _expectedTask; }
            set { _expectedTask = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("9e3dd077-62b7-463d-8258-5ddff6ad6c1d")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

        string _optDivision;

        /// <summary>
        /// Gets or sets the value of variable optDivision.
        /// </summary>
        [TestVariable("adc8d680-a358-4b99-be32-03a7c5d74422")]
        public string optDivision
        {
            get { return _optDivision; }
            set { _optDivision = value; }
        }

        string _optLogicalPosition;

        /// <summary>
        /// Gets or sets the value of variable optLogicalPosition.
        /// </summary>
        [TestVariable("da657a19-a49e-4b1a-bdb8-8db42f6ea292")]
        public string optLogicalPosition
        {
            get { return _optLogicalPosition; }
            set { _optLogicalPosition = value; }
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

            CodeUtils.NS_TerritoryTransfer_Validations.NS_ValidateDispatcherMessageContentFromDispatcherTranferreportForm(optDivision, optLogicalPosition, division, dispatchTerritory, dispatcherMessageContent, ValueConverter.ArgumentFromString<bool>("expectedTask", expectedTask), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
