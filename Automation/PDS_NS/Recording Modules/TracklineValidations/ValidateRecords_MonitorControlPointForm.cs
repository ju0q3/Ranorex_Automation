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
    ///The ValidateRecords_MonitorControlPointForm recording.
    /// </summary>
    [TestModule("25f6e956-9be3-4a55-bd69-26acfcf748ac", ModuleType.Recording, 1)]
    public partial class ValidateRecords_MonitorControlPointForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateRecords_MonitorControlPointForm instance = new ValidateRecords_MonitorControlPointForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateRecords_MonitorControlPointForm()
        {
            type = "";
            closeForms = "False";
            bitArray = "";
            atcsAddress = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateRecords_MonitorControlPointForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("654cdb94-b1fc-4c86-825c-1a1704247532")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("577cf8f1-02da-43d4-9ffe-b8d90682f004")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _bitArray;

        /// <summary>
        /// Gets or sets the value of variable bitArray.
        /// </summary>
        [TestVariable("eaaa8bbb-fb8b-4641-ab89-9f9f0795f683")]
        public string bitArray
        {
            get { return _bitArray; }
            set { _bitArray = value; }
        }

        string _atcsAddress;

        /// <summary>
        /// Gets or sets the value of variable atcsAddress.
        /// </summary>
        [TestVariable("8535f50b-305c-4212-8212-6c7a0ce5df7f")]
        public string atcsAddress
        {
            get { return _atcsAddress; }
            set { _atcsAddress = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ValidateRecords_MonitorControlPointForm(type, atcsAddress, bitArray, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}