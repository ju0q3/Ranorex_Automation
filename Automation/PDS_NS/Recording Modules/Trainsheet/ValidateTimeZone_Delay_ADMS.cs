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
    ///The ValidateTimeZone_Delay_ADMS recording.
    /// </summary>
    [TestModule("56406591-7d7b-4a2a-ad23-07473d5f110d", ModuleType.Recording, 1)]
    public partial class ValidateTimeZone_Delay_ADMS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateTimeZone_Delay_ADMS instance = new ValidateTimeZone_Delay_ADMS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTimeZone_Delay_ADMS()
        {
            trainSeed = "";
            fromTimeZone = "";
            toTimeZone = "";
            delayCode = "";
            fromOpsta = "";
            toOpsta = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTimeZone_Delay_ADMS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("60ba9b16-59d7-49a7-86dc-43668bec7d17")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _fromTimeZone;

        /// <summary>
        /// Gets or sets the value of variable fromTimeZone.
        /// </summary>
        [TestVariable("0a6bfdab-c384-4dc9-b53a-ebb86984bb20")]
        public string fromTimeZone
        {
            get { return _fromTimeZone; }
            set { _fromTimeZone = value; }
        }

        string _toTimeZone;

        /// <summary>
        /// Gets or sets the value of variable toTimeZone.
        /// </summary>
        [TestVariable("198ff155-5a9c-41e6-88a1-0825932631bb")]
        public string toTimeZone
        {
            get { return _toTimeZone; }
            set { _toTimeZone = value; }
        }

        string _delayCode;

        /// <summary>
        /// Gets or sets the value of variable delayCode.
        /// </summary>
        [TestVariable("dbf9ef0d-5e76-4c15-acc5-6290890afc24")]
        public string delayCode
        {
            get { return _delayCode; }
            set { _delayCode = value; }
        }

        string _fromOpsta;

        /// <summary>
        /// Gets or sets the value of variable fromOpsta.
        /// </summary>
        [TestVariable("0947e1fd-ffd5-46b0-a339-02528333a17d")]
        public string fromOpsta
        {
            get { return _fromOpsta; }
            set { _fromOpsta = value; }
        }

        string _toOpsta;

        /// <summary>
        /// Gets or sets the value of variable toOpsta.
        /// </summary>
        [TestVariable("5cf6e71c-bf2d-4b43-b07e-d6a2c773dad7")]
        public string toOpsta
        {
            get { return _toOpsta; }
            set { _toOpsta = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_ValidateTimeZone_Delay_ADMS(trainSeed, delayCode, fromOpsta, toOpsta, fromTimeZone, toTimeZone);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}