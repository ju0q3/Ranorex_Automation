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

namespace PDS_NS.Recording_Modules.MIS.MIS_Message_Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateEotCabooseMessage_ByContent_NS recording.
    /// </summary>
    [TestModule("aa63d7ac-e8b8-4d73-a1a4-95d263df7d72", ModuleType.Recording, 1)]
    public partial class ValidateEotCabooseMessage_ByContent_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateEotCabooseMessage_ByContent_NS instance = new ValidateEotCabooseMessage_ByContent_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateEotCabooseMessage_ByContent_NS()
        {
            trainSeed = "";
            equipmentCode = "";
            origin = "";
            destination = "";
            initial = "";
            number = "";
            workingStatus = "";
            validateDoesExist = "True";
            timeInSeconds = "5";
            retry = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateEotCabooseMessage_ByContent_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("419b2b72-6252-4e8e-a301-a21957331760")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _equipmentCode;

        /// <summary>
        /// Gets or sets the value of variable equipmentCode.
        /// </summary>
        [TestVariable("2def0fd0-d9d2-4166-9de9-57bb2025da87")]
        public string equipmentCode
        {
            get { return _equipmentCode; }
            set { _equipmentCode = value; }
        }

        string _origin;

        /// <summary>
        /// Gets or sets the value of variable origin.
        /// </summary>
        [TestVariable("0d010e50-fbe2-4c90-9621-d077fa826253")]
        public string origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        string _destination;

        /// <summary>
        /// Gets or sets the value of variable destination.
        /// </summary>
        [TestVariable("88aef660-504d-47d1-ac83-45d729168c2c")]
        public string destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        string _initial;

        /// <summary>
        /// Gets or sets the value of variable initial.
        /// </summary>
        [TestVariable("096a25ac-d431-4c75-85ef-f092e7e21412")]
        public string initial
        {
            get { return _initial; }
            set { _initial = value; }
        }

        string _number;

        /// <summary>
        /// Gets or sets the value of variable number.
        /// </summary>
        [TestVariable("7fbeae64-a911-4146-8864-ec8f38464a44")]
        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        string _workingStatus;

        /// <summary>
        /// Gets or sets the value of variable workingStatus.
        /// </summary>
        [TestVariable("68db48e6-9610-4df2-b394-d4120657a717")]
        public string workingStatus
        {
            get { return _workingStatus; }
            set { _workingStatus = value; }
        }

        string _validateDoesExist;

        /// <summary>
        /// Gets or sets the value of variable validateDoesExist.
        /// </summary>
        [TestVariable("c4d2d9a6-5b5d-4c39-ac68-cc8c3075bbb9")]
        public string validateDoesExist
        {
            get { return _validateDoesExist; }
            set { _validateDoesExist = value; }
        }

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("a69c33ce-a71f-4d8c-b4fa-85ef571c4698")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("bf02221b-fbaf-4396-b9c1-4f39e2186c99")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_ValidateEotCabooseMessage_ByContent(trainSeed, equipmentCode, origin, destination, initial, number, workingStatus, ValueConverter.ArgumentFromString<bool>("validateDoesExist", validateDoesExist), ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
