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

namespace PDS_NS.Recording_Modules.MIS
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateCrewMemberMISSimple_NS recording.
    /// </summary>
    [TestModule("af366954-6bff-4761-a2df-863935676346", ModuleType.Recording, 1)]
    public partial class CreateCrewMemberMISSimple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateCrewMemberMISSimple_NS instance = new CreateCrewMemberMISSimple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateCrewMemberMISSimple_NS()
        {
            trainSeed = "";
            crewID = "";
            crewLineSegment = "";
            sequenceNumber = "";
            crewMemberRecords = "";
            crewSeed = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateCrewMemberMISSimple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("c337ea39-0256-4349-930a-4c90c57d8205")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _crewID;

        /// <summary>
        /// Gets or sets the value of variable crewID.
        /// </summary>
        [TestVariable("85a91041-ba81-4bf2-95cf-947e7f2f86b7")]
        public string crewID
        {
            get { return _crewID; }
            set { _crewID = value; }
        }

        string _crewLineSegment;

        /// <summary>
        /// Gets or sets the value of variable crewLineSegment.
        /// </summary>
        [TestVariable("7833b797-f165-4282-9ccf-455aae884dea")]
        public string crewLineSegment
        {
            get { return _crewLineSegment; }
            set { _crewLineSegment = value; }
        }

        string _sequenceNumber;

        /// <summary>
        /// Gets or sets the value of variable sequenceNumber.
        /// </summary>
        [TestVariable("a2223902-bac3-414c-a601-61092108ebaf")]
        public string sequenceNumber
        {
            get { return _sequenceNumber; }
            set { _sequenceNumber = value; }
        }

        string _crewMemberRecords;

        /// <summary>
        /// Gets or sets the value of variable crewMemberRecords.
        /// </summary>
        [TestVariable("cd053468-4866-4112-95c8-2c89eac9c9f0")]
        public string crewMemberRecords
        {
            get { return _crewMemberRecords; }
            set { _crewMemberRecords = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("4921fc50-1270-43a6-9c47-06d867c53197")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("edee52d2-bf02-4175-a0c4-9018f847a0a2")]
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

            UserCodeCollections.NS_MIS_Messages.NS_SendCrewMember_48Simple(trainSeed, crewSeed, crewID, crewLineSegment, sequenceNumber, crewMemberRecords, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}