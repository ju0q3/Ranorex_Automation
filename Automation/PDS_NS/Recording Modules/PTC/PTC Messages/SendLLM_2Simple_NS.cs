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
    ///The SendLLM_2Simple_NS recording.
    /// </summary>
    [TestModule("edd17ada-d906-4c1d-8496-6b3df8aa5bb6", ModuleType.Recording, 1)]
    public partial class SendLLM_2Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendLLM_2Simple_NS instance = new SendLLM_2Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendLLM_2Simple_NS()
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
            locationEventDay = "";
            reportDay = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendLLM_2Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("fd623334-4004-4f14-a4f6-5c4e64038783")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _engineSeed;

        /// <summary>
        /// Gets or sets the value of variable engineSeed.
        /// </summary>
        [TestVariable("00e64ed4-8a4c-4902-bbc0-53dd819535ee")]
        public string engineSeed
        {
            get { return _engineSeed; }
            set { _engineSeed = value; }
        }

        string _milepost;

        /// <summary>
        /// Gets or sets the value of variable milepost.
        /// </summary>
        [TestVariable("5f856bd7-2312-4838-8c74-dcf67a69f200")]
        public string milepost
        {
            get { return _milepost; }
            set { _milepost = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("189318f4-860c-4de6-ac26-8b72c4c39df7")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _track;

        /// <summary>
        /// Gets or sets the value of variable track.
        /// </summary>
        [TestVariable("dba0c698-6a47-4e6d-90d6-1da67edb30a2")]
        public string track
        {
            get { return _track; }
            set { _track = value; }
        }

        string _source;

        /// <summary>
        /// Gets or sets the value of variable source.
        /// </summary>
        [TestVariable("26f860b3-05de-47fa-acfd-b155fb122c55")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("027720a3-3857-48ee-8b0c-6384fe241065")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _speed;

        /// <summary>
        /// Gets or sets the value of variable speed.
        /// </summary>
        [TestVariable("786488f8-f1ac-42bf-a5a1-9dd84db8958e")]
        public string speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        string _locationEventDateTime;

        /// <summary>
        /// Gets or sets the value of variable locationEventDateTime.
        /// </summary>
        [TestVariable("e1d65c71-4be3-45b5-b7fd-13bbe2124e43")]
        public string locationEventDateTime
        {
            get { return _locationEventDateTime; }
            set { _locationEventDateTime = value; }
        }

        string _locationEventTimeZone;

        /// <summary>
        /// Gets or sets the value of variable locationEventTimeZone.
        /// </summary>
        [TestVariable("64e6b624-a385-466f-ab82-418a78501416")]
        public string locationEventTimeZone
        {
            get { return _locationEventTimeZone; }
            set { _locationEventTimeZone = value; }
        }

        string _reportDateTime;

        /// <summary>
        /// Gets or sets the value of variable reportDateTime.
        /// </summary>
        [TestVariable("c2f0c8f8-1da4-422d-8b03-41b48e903f1b")]
        public string reportDateTime
        {
            get { return _reportDateTime; }
            set { _reportDateTime = value; }
        }

        string _reportTimeZone;

        /// <summary>
        /// Gets or sets the value of variable reportTimeZone.
        /// </summary>
        [TestVariable("1e01c7b2-9fa8-465e-97fd-5d98afcff0f1")]
        public string reportTimeZone
        {
            get { return _reportTimeZone; }
            set { _reportTimeZone = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("7bbcdd52-e8bb-4219-9c02-9e16a639939a")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        string _locationEventDay;

        /// <summary>
        /// Gets or sets the value of variable locationEventDay.
        /// </summary>
        [TestVariable("eef89d52-10fb-43c6-9701-05deb7c56dda")]
        public string locationEventDay
        {
            get { return _locationEventDay; }
            set { _locationEventDay = value; }
        }

        string _reportDay;

        /// <summary>
        /// Gets or sets the value of variable reportDay.
        /// </summary>
        [TestVariable("e7f5ed4e-5b91-4a3f-9dca-4da362df1534")]
        public string reportDay
        {
            get { return _reportDay; }
            set { _reportDay = value; }
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

            UserCodeCollections.NS_PTC_Messages.SendLLM_2Simple(trainSeed, engineSeed, milepost, division, track, source, district, speed, locationEventDay, locationEventDateTime, locationEventTimeZone, reportDay, reportDateTime, reportTimeZone, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
