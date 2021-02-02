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
    ///The NS_EditAssignedWork_Trainsheet recording.
    /// </summary>
    [TestModule("47da4f30-32fe-4d8a-b67e-72dd4d7cd9bd", ModuleType.Recording, 1)]
    public partial class NS_EditAssignedWork_Trainsheet : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_EditAssignedWork_Trainsheet instance = new NS_EditAssignedWork_Trainsheet();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_EditAssignedWork_Trainsheet()
        {
            trainSeed = "";
            filterOpsta = "";
            operation = "";
            opsta = "";
            passCount = "";
            loads = "";
            empties = "";
            tons = "";
            length = "";
            note = "";
            coal = "False";
            needDateTimeOffset = "";
            needDateTimeZone = "";
            completionDateTimeOffset = "";
            completionDateTimeZone = "";
            coalPermit = "";
            coalCarsRecords = "";
            expectedFeedback = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_EditAssignedWork_Trainsheet Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("a2eb2c2c-483e-4c98-aa49-4960ed63ba26")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _filterOpsta;

        /// <summary>
        /// Gets or sets the value of variable filterOpsta.
        /// </summary>
        [TestVariable("c51d77fa-3440-4878-b97c-52949df25aca")]
        public string filterOpsta
        {
            get { return _filterOpsta; }
            set { _filterOpsta = value; }
        }

        string _operation;

        /// <summary>
        /// Gets or sets the value of variable operation.
        /// </summary>
        [TestVariable("222789d2-2045-4254-8e89-d102e21c0ead")]
        public string operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        string _opsta;

        /// <summary>
        /// Gets or sets the value of variable opsta.
        /// </summary>
        [TestVariable("35213f4f-1b13-4ab8-9589-bba200090787")]
        public string opsta
        {
            get { return _opsta; }
            set { _opsta = value; }
        }

        string _passCount;

        /// <summary>
        /// Gets or sets the value of variable passCount.
        /// </summary>
        [TestVariable("96266cfd-1921-4f32-87f5-660c7b2fe34c")]
        public string passCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        string _loads;

        /// <summary>
        /// Gets or sets the value of variable loads.
        /// </summary>
        [TestVariable("52797839-2559-410b-931d-72a8a3b7f792")]
        public string loads
        {
            get { return _loads; }
            set { _loads = value; }
        }

        string _empties;

        /// <summary>
        /// Gets or sets the value of variable empties.
        /// </summary>
        [TestVariable("661d71d0-0b6e-4975-9a52-e46061024a49")]
        public string empties
        {
            get { return _empties; }
            set { _empties = value; }
        }

        string _tons;

        /// <summary>
        /// Gets or sets the value of variable tons.
        /// </summary>
        [TestVariable("b867a0d3-c4ae-4166-90eb-1f81aac473fc")]
        public string tons
        {
            get { return _tons; }
            set { _tons = value; }
        }

        string _length;

        /// <summary>
        /// Gets or sets the value of variable length.
        /// </summary>
        [TestVariable("8ac5b128-a773-4fd6-84a4-f7455eaa987a")]
        public string length
        {
            get { return _length; }
            set { _length = value; }
        }

        string _note;

        /// <summary>
        /// Gets or sets the value of variable note.
        /// </summary>
        [TestVariable("3b66c991-3910-43a9-8fbc-44f8c46fafa7")]
        public string note
        {
            get { return _note; }
            set { _note = value; }
        }

        string _coal;

        /// <summary>
        /// Gets or sets the value of variable coal.
        /// </summary>
        [TestVariable("b26902c4-3598-4f26-b64c-e54f23005cfd")]
        public string coal
        {
            get { return _coal; }
            set { _coal = value; }
        }

        string _needDateTimeOffset;

        /// <summary>
        /// Gets or sets the value of variable needDateTimeOffset.
        /// </summary>
        [TestVariable("fc6fe8d4-1508-4bd6-a907-2ec41252f38e")]
        public string needDateTimeOffset
        {
            get { return _needDateTimeOffset; }
            set { _needDateTimeOffset = value; }
        }

        string _needDateTimeZone;

        /// <summary>
        /// Gets or sets the value of variable needDateTimeZone.
        /// </summary>
        [TestVariable("f5ed75b8-0ff5-4251-89fd-256619bc7e1c")]
        public string needDateTimeZone
        {
            get { return _needDateTimeZone; }
            set { _needDateTimeZone = value; }
        }

        string _completionDateTimeOffset;

        /// <summary>
        /// Gets or sets the value of variable completionDateTimeOffset.
        /// </summary>
        [TestVariable("480245c0-5c88-4f08-8328-b35219ce16f5")]
        public string completionDateTimeOffset
        {
            get { return _completionDateTimeOffset; }
            set { _completionDateTimeOffset = value; }
        }

        string _completionDateTimeZone;

        /// <summary>
        /// Gets or sets the value of variable completionDateTimeZone.
        /// </summary>
        [TestVariable("bbab2b5e-f69b-4b6d-b719-e27755ef7bc3")]
        public string completionDateTimeZone
        {
            get { return _completionDateTimeZone; }
            set { _completionDateTimeZone = value; }
        }

        string _coalPermit;

        /// <summary>
        /// Gets or sets the value of variable coalPermit.
        /// </summary>
        [TestVariable("7ba847fe-ff9a-4815-90db-bd264b917e13")]
        public string coalPermit
        {
            get { return _coalPermit; }
            set { _coalPermit = value; }
        }

        string _coalCarsRecords;

        /// <summary>
        /// Gets or sets the value of variable coalCarsRecords.
        /// </summary>
        [TestVariable("69e7d707-1e14-48e6-b341-a80ea5033ae4")]
        public string coalCarsRecords
        {
            get { return _coalCarsRecords; }
            set { _coalCarsRecords = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("e4dd7994-e2c0-4d73-967e-632d3095783b")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("e063c031-00d9-4d66-a613-c994659a86d1")]
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

            UserCodeCollections.NS_Trainsheet.EditAssignedWork_Trainsheet(trainSeed, filterOpsta, operation, opsta, passCount, loads, empties, tons, length, note, ValueConverter.ArgumentFromString<bool>("coal", coal), needDateTimeOffset, needDateTimeZone, completionDateTimeOffset, completionDateTimeZone, coalPermit, coalCarsRecords, expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
