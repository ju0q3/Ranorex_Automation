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
    ///The ValidateNoETAInformationMessage recording.
    /// </summary>
    [TestModule("12f894fd-aa46-45a3-acbb-2b1bd3114f66", ModuleType.Recording, 1)]
    public partial class ValidateNoETAInformationMessage : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateNoETAInformationMessage instance = new ValidateNoETAInformationMessage();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateNoETAInformationMessage()
        {
            timeInSeconds = "5";
            retry = "True";
            trainSeed = "";
            opstaLocation = "";
            locationType = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateNoETAInformationMessage Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("555e8dd0-b042-4f94-bbc9-dc75d3280843")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("730a568f-c1df-4c6f-ac33-35ef1816e934")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("16207a01-1ac0-4f69-bdd4-9823ef57b1fe")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opstaLocation;

        /// <summary>
        /// Gets or sets the value of variable opstaLocation.
        /// </summary>
        [TestVariable("79d624c0-806c-429a-98ea-937c081a8cb8")]
        public string opstaLocation
        {
            get { return _opstaLocation; }
            set { _opstaLocation = value; }
        }

        string _locationType;

        /// <summary>
        /// Gets or sets the value of variable locationType.
        /// </summary>
        [TestVariable("5b859c1e-071e-4b60-82b1-7df4b7179791")]
        public string locationType
        {
            get { return _locationType; }
            set { _locationType = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_validateNoETAInformationMessage(trainSeed, opstaLocation, locationType, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}