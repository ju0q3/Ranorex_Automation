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

namespace PDS_NS.Recording_Modules.Playback
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PlaybackDivisionTerritoryRequest recording.
    /// </summary>
    [TestModule("8f3e34ce-552b-4822-825b-ba36c643f144", ModuleType.Recording, 1)]
    public partial class PlaybackDivisionTerritoryRequest : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static PlaybackDivisionTerritoryRequest instance = new PlaybackDivisionTerritoryRequest();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PlaybackDivisionTerritoryRequest()
        {
            divisionName = "";
            territoryName = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PlaybackDivisionTerritoryRequest Instance
        {
            get { return instance; }
        }

#region Variables

        string _divisionName;

        /// <summary>
        /// Gets or sets the value of variable divisionName.
        /// </summary>
        [TestVariable("6afc2df7-7c3b-4418-bc3d-5154e9724c77")]
        public string divisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        string _territoryName;

        /// <summary>
        /// Gets or sets the value of variable territoryName.
        /// </summary>
        [TestVariable("6335ed92-8171-42b8-a9a9-0ab1ac870d89")]
        public string territoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
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

            UserCodeCollections.NS_Playback.NS_PlaybackDivisionTerritoryRequest(divisionName, territoryName);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}