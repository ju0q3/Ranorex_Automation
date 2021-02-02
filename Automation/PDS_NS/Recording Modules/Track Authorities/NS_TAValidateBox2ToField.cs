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
    ///The NS_TAValidateBox2ToField recording.
    /// </summary>
    [TestModule("1ce5d044-8d96-44d3-9c23-d201d02eeda5", ModuleType.Recording, 1)]
    public partial class NS_TAValidateBox2ToField : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.TrackAuthorities_Repo repository.
        /// </summary>
        public static global::PDS_NS.TrackAuthorities_Repo repo = global::PDS_NS.TrackAuthorities_Repo.Instance;

        static NS_TAValidateBox2ToField instance = new NS_TAValidateBox2ToField();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_TAValidateBox2ToField()
        {
            toLimit = "yourValue";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_TAValidateBox2ToField Instance
        {
            get { return instance; }
        }

#region Variables

        string _toLimit;

        /// <summary>
        /// Gets or sets the value of variable toLimit.
        /// </summary>
        [TestVariable("4847f0a2-30c1-4f63-b21f-081df1d8d6d2")]
        public string toLimit
        {
            get { return _toLimit; }
            set { _toLimit = value; }
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

            UserCodeCollections.NS_Authorities.ValidateToLimitWithTolerance(toLimit);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
