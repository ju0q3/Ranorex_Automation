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

namespace PDS_NS.Recording_Modules.PTC.PTC_Messages
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendLLM_3Simple_NS recording.
    /// </summary>
    [TestModule("67791d43-4441-4405-b22d-ad511f33addd", ModuleType.Recording, 1)]
    public partial class SendLLM_3Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendLLM_3Simple_NS instance = new SendLLM_3Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendLLM_3Simple_NS()
        {
            trainSeed = "";
            engineSeed = "";
            milepost = "";
            division = "";
            track = "";
            source = "";
            district = "";
            speed = "";
            locationEventDateTime = "";
            locationEventTimeZone = "";
            reportDateTime = "";
            reportTimeZone = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendLLM_3Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("fe0c7704-4a21-4d6a-b195-7408443764f2")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("b152ed02-6127-4b23-b3ab-64daa8760483")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _milepost;

        /// <summary>
        /// Gets or sets the value of variable milepost.
        /// </summary>
        [TestVariable("42864c6a-1fa7-44ef-80ec-f94105b90fac")]
        public string milepost
        {
            get { return _milepost; }
            set { _milepost = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("48ba03c4-01bd-47c7-886f-f89e857ccd10")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _track;

        /// <summary>
        /// Gets or sets the value of variable track.
        /// </summary>
        [TestVariable("f6f8e757-a42b-48e8-b9f8-346a1711a275")]
        public string track
        {
            get { return _track; }
            set { _track = value; }
        }

        string _source;

        /// <summary>
        /// Gets or sets the value of variable source.
        /// </summary>
        [TestVariable("a2f7e6e2-023e-4937-ba21-06bb4953b121")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("50d15705-3c32-4c3a-9c31-2329277ffa9a")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _speed;

        /// <summary>
        /// Gets or sets the value of variable speed.
        /// </summary>
        [TestVariable("113ba92d-d282-4100-ba7f-11ce46d5829b")]
        public string speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        string _locationEventDateTime;

        /// <summary>
        /// Gets or sets the value of variable locationEventDateTime.
        /// </summary>
        [TestVariable("a196c246-e572-403d-98b5-cb00d78cae1d")]
        public string locationEventDateTime
        {
            get { return _locationEventDateTime; }
            set { _locationEventDateTime = value; }
        }

        string _locationEventTimeZone;

        /// <summary>
        /// Gets or sets the value of variable locationEventTimeZone.
        /// </summary>
        [TestVariable("986db560-b615-4826-a9b8-7827c7acf72a")]
        public string locationEventTimeZone
        {
            get { return _locationEventTimeZone; }
            set { _locationEventTimeZone = value; }
        }

        string _reportDateTime;

        /// <summary>
        /// Gets or sets the value of variable reportDateTime.
        /// </summary>
        [TestVariable("1eb8a139-c900-424d-868f-9b6373fa2b98")]
        public string reportDateTime
        {
            get { return _reportDateTime; }
            set { _reportDateTime = value; }
        }

        string _reportTimeZone;

        /// <summary>
        /// Gets or sets the value of variable reportTimeZone.
        /// </summary>
        [TestVariable("2014b7af-db9f-4b9a-832d-5adb9ca4d291")]
        public string reportTimeZone
        {
            get { return _reportTimeZone; }
            set { _reportTimeZone = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("9d263f28-5cd9-44ba-90e4-f4053cf2a3a6")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_PTC_Messages.SendLLM_3Simple(trainSeed, engineSeed, milepost, division, track, source, district, speed, locationEventDateTime, locationEventTimeZone, reportDateTime, reportTimeZone, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}