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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateBox5_CreateTrackAuthority_NS recording.
    /// </summary>
    [TestModule("9d7a361f-b6c2-46ad-8dad-322c1db3829d", ModuleType.Recording, 1)]
    public partial class ValidateBox5_CreateTrackAuthority_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateBox5_CreateTrackAuthority_NS instance = new ValidateBox5_CreateTrackAuthority_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateBox5_CreateTrackAuthority_NS()
        {
            box5_yn = "";
            box5_time = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateBox5_CreateTrackAuthority_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _box5_yn;

        /// <summary>
        /// Gets or sets the value of variable box5_yn.
        /// </summary>
        [TestVariable("98d0c984-d2db-4df0-9091-16a2b36b9e78")]
        public string box5_yn
        {
            get { return _box5_yn; }
            set { _box5_yn = value; }
        }

        string _box5_time;

        /// <summary>
        /// Gets or sets the value of variable box5_time.
        /// </summary>
        [TestVariable("a1295097-3244-41a4-8dbb-41a90c65abe2")]
        public string box5_time
        {
            get { return _box5_time; }
            set { _box5_time = value; }
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

            UserCodeCollections.NS_Authorities.ValidateBox5_CreateTrackAuthority(box5_yn, box5_time);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
