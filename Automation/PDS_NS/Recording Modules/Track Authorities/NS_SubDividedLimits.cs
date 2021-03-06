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
    ///The NS_SubDividedLimits recording.
    /// </summary>
    [TestModule("ea9d9b1e-ee8d-4c52-8303-2a615c9da830", ModuleType.Recording, 1)]
    public partial class NS_SubDividedLimits : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_SubDividedLimits instance = new NS_SubDividedLimits();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_SubDividedLimits()
        {
            authoritySeed = "";
            limit = "";
            betweenSide = "False";
            andSide = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_SubDividedLimits Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("893dad5a-dbf5-4311-9555-de1176615709")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _limit;

        /// <summary>
        /// Gets or sets the value of variable limit.
        /// </summary>
        [TestVariable("c6fe3070-3f0d-4714-859d-28ed7a855b22")]
        public string limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        string _betweenSide;

        /// <summary>
        /// Gets or sets the value of variable betweenSide.
        /// </summary>
        [TestVariable("ab3c7faa-e2e7-4bc5-9b99-cbf789691516")]
        public string betweenSide
        {
            get { return _betweenSide; }
            set { _betweenSide = value; }
        }

        string _andSide;

        /// <summary>
        /// Gets or sets the value of variable andSide.
        /// </summary>
        [TestVariable("108ace49-4ca3-4ef1-b4b8-574c49e5154f")]
        public string andSide
        {
            get { return _andSide; }
            set { _andSide = value; }
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

            UserCodeCollections.NS_Authorities.FillBox13_SelectSubdividedLimits(authoritySeed, limit, ValueConverter.ArgumentFromString<bool>("betweenSide", betweenSide), ValueConverter.ArgumentFromString<bool>("andSide", andSide));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
