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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateRapidRoute_Full_Trackline_NS recording.
    /// </summary>
    [TestModule("f3e0e368-a19b-450a-b4e4-8802d2d95d6b", ModuleType.Recording, 1)]
    public partial class CreateRapidRoute_Full_Trackline_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateRapidRoute_Full_Trackline_NS instance = new CreateRapidRoute_Full_Trackline_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateRapidRoute_Full_Trackline_NS()
        {
            objectId1 = "";
            objectType1 = "";
            rapidRouteOption1 = "";
            expectedFeedback1 = "";
            objectId2 = "";
            objectType2 = "";
            rapidRouteOption2 = "";
            transmit = "True";
            clickAcknowledgeIfExists = "True";
            expectedFeedback2 = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateRapidRoute_Full_Trackline_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _objectId1;

        /// <summary>
        /// Gets or sets the value of variable objectId1.
        /// </summary>
        [TestVariable("13358969-fd9f-40f9-89f9-d689ab4e0108")]
        public string objectId1
        {
            get { return _objectId1; }
            set { _objectId1 = value; }
        }

        string _objectType1;

        /// <summary>
        /// Gets or sets the value of variable objectType1.
        /// </summary>
        [TestVariable("b2089600-133b-4cc5-bc8b-e497d006f23f")]
        public string objectType1
        {
            get { return _objectType1; }
            set { _objectType1 = value; }
        }

        string _rapidRouteOption1;

        /// <summary>
        /// Gets or sets the value of variable rapidRouteOption1.
        /// </summary>
        [TestVariable("affc9fe2-ddd0-48c9-ac96-451a4dbbe7f7")]
        public string rapidRouteOption1
        {
            get { return _rapidRouteOption1; }
            set { _rapidRouteOption1 = value; }
        }

        string _expectedFeedback1;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback1.
        /// </summary>
        [TestVariable("4de4ddf6-8b15-467f-a399-30ee17babe2b")]
        public string expectedFeedback1
        {
            get { return _expectedFeedback1; }
            set { _expectedFeedback1 = value; }
        }

        string _objectId2;

        /// <summary>
        /// Gets or sets the value of variable objectId2.
        /// </summary>
        [TestVariable("83308ef9-9829-4c7c-860d-2e065079d21a")]
        public string objectId2
        {
            get { return _objectId2; }
            set { _objectId2 = value; }
        }

        string _objectType2;

        /// <summary>
        /// Gets or sets the value of variable objectType2.
        /// </summary>
        [TestVariable("8768a9ad-dcc7-428f-ab7e-140dbc780ad5")]
        public string objectType2
        {
            get { return _objectType2; }
            set { _objectType2 = value; }
        }

        string _rapidRouteOption2;

        /// <summary>
        /// Gets or sets the value of variable rapidRouteOption2.
        /// </summary>
        [TestVariable("4a6849ef-70f4-454a-b8e3-0ee46f7d04fc")]
        public string rapidRouteOption2
        {
            get { return _rapidRouteOption2; }
            set { _rapidRouteOption2 = value; }
        }

        string _transmit;

        /// <summary>
        /// Gets or sets the value of variable transmit.
        /// </summary>
        [TestVariable("3f73f18a-d24c-4849-8d20-e7a548be8a2a")]
        public string transmit
        {
            get { return _transmit; }
            set { _transmit = value; }
        }

        string _clickAcknowledgeIfExists;

        /// <summary>
        /// Gets or sets the value of variable clickAcknowledgeIfExists.
        /// </summary>
        [TestVariable("709ff7b6-386e-4710-9515-e963301da517")]
        public string clickAcknowledgeIfExists
        {
            get { return _clickAcknowledgeIfExists; }
            set { _clickAcknowledgeIfExists = value; }
        }

        string _expectedFeedback2;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback2.
        /// </summary>
        [TestVariable("d0b2b7b2-675a-41fd-bc2a-f88514cc7adb")]
        public string expectedFeedback2
        {
            get { return _expectedFeedback2; }
            set { _expectedFeedback2 = value; }
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

            UserCodeCollections.NS_Trackline.NS_CreateRapidRoute_Full_Trackline(objectId1, objectType1, rapidRouteOption1, expectedFeedback1, objectId2, objectType2, rapidRouteOption2, expectedFeedback2, ValueConverter.ArgumentFromString<bool>("transmit", transmit), ValueConverter.ArgumentFromString<bool>("clickAcknowledgeIfExists", clickAcknowledgeIfExists));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
