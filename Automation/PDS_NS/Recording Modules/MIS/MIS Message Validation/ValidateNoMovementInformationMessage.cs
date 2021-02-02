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
    ///The ValidateNoMovementInformationMessage recording.
    /// </summary>
    [TestModule("4ef8cc65-6c7b-464c-80ad-f760b469d73f", ModuleType.Recording, 1)]
    public partial class ValidateNoMovementInformationMessage : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateNoMovementInformationMessage instance = new ValidateNoMovementInformationMessage();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateNoMovementInformationMessage()
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
        public static ValidateNoMovementInformationMessage Instance
        {
            get { return instance; }
        }

#region Variables

        string _timeInSeconds;

        /// <summary>
        /// Gets or sets the value of variable timeInSeconds.
        /// </summary>
        [TestVariable("6d9c563b-7343-45b5-955d-00ce5b5d61aa")]
        public string timeInSeconds
        {
            get { return _timeInSeconds; }
            set { _timeInSeconds = value; }
        }

        string _retry;

        /// <summary>
        /// Gets or sets the value of variable retry.
        /// </summary>
        [TestVariable("492c5092-d0da-4e15-98df-6172b6e7102a")]
        public string retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("198913dd-c30a-41b6-bb41-ad1e0f47f009")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opstaLocation;

        /// <summary>
        /// Gets or sets the value of variable opstaLocation.
        /// </summary>
        [TestVariable("1426a98a-39eb-4d64-9294-740cc46304e1")]
        public string opstaLocation
        {
            get { return _opstaLocation; }
            set { _opstaLocation = value; }
        }

        string _locationType;

        /// <summary>
        /// Gets or sets the value of variable locationType.
        /// </summary>
        [TestVariable("deb38d7b-ad51-423a-9555-1f7989b47ffd")]
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

            UserCodeCollections.NS_MIS_Messages.NS_validateNoMovementInformationMessage(trainSeed, opstaLocation, locationType, ValueConverter.ArgumentFromString<int>("timeInSeconds", timeInSeconds), ValueConverter.ArgumentFromString<bool>("retry", retry));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
