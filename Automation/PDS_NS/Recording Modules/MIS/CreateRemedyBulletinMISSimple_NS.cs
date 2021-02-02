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
    ///The CreateRemedyBulletinMISSimple_NS recording.
    /// </summary>
    [TestModule("61e98abf-d197-4ea6-848d-fc626b6896fe", ModuleType.Recording, 1)]
    public partial class CreateRemedyBulletinMISSimple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateRemedyBulletinMISSimple_NS instance = new CreateRemedyBulletinMISSimple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateRemedyBulletinMISSimple_NS()
        {
            bulletinSeed = "";
            division = "";
            district = "";
            source = "";
            sourceId = "";
            action = "";
            comments = "";
            bulletinItemType = "";
            fieldRecord = "";
            hostname = "";
            sequence_number = "";
            bulletin_seed_void = "";
            effectiveDateOffsetDays = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateRemedyBulletinMISSimple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("d940dbe3-b63b-4266-921e-4cb0e6c70ca6")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("82db9739-456f-49f1-a4f2-1a5fef1de3d8")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("d0b2366f-ee82-4ee9-8ae8-909bc7b8ad09")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _source;

        /// <summary>
        /// Gets or sets the value of variable source.
        /// </summary>
        [TestVariable("e0c3baeb-4044-490d-8ad7-7ee50537dc37")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        string _sourceId;

        /// <summary>
        /// Gets or sets the value of variable sourceId.
        /// </summary>
        [TestVariable("b9308aba-46e2-4155-832e-21542a4c249f")]
        public string sourceId
        {
            get { return _sourceId; }
            set { _sourceId = value; }
        }

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("e44485ed-47a0-486d-94c2-75b9dea81aab")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        string _comments;

        /// <summary>
        /// Gets or sets the value of variable comments.
        /// </summary>
        [TestVariable("b59bfb09-e53d-415a-b74f-63a0fdf0f2f0")]
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        string _bulletinItemType;

        /// <summary>
        /// Gets or sets the value of variable bulletinItemType.
        /// </summary>
        [TestVariable("802c85c2-5cb3-4c3e-a00d-09061f1d4525")]
        public string bulletinItemType
        {
            get { return _bulletinItemType; }
            set { _bulletinItemType = value; }
        }

        string _fieldRecord;

        /// <summary>
        /// Gets or sets the value of variable fieldRecord.
        /// </summary>
        [TestVariable("406c9cf4-0228-448e-9a7c-b90b8da6424a")]
        public string fieldRecord
        {
            get { return _fieldRecord; }
            set { _fieldRecord = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("219902ea-b47f-40f3-9807-b415ff38a8e7")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        string _sequence_number;

        /// <summary>
        /// Gets or sets the value of variable sequence_number.
        /// </summary>
        [TestVariable("5da5323b-2c8e-4839-8a0f-c80b51ab50ab")]
        public string sequence_number
        {
            get { return _sequence_number; }
            set { _sequence_number = value; }
        }

        string _bulletin_seed_void;

        /// <summary>
        /// Gets or sets the value of variable bulletin_seed_void.
        /// </summary>
        [TestVariable("d62fa8d5-b203-4801-917e-061c1f6b1ab4")]
        public string bulletin_seed_void
        {
            get { return _bulletin_seed_void; }
            set { _bulletin_seed_void = value; }
        }

        string _effectiveDateOffsetDays;

        /// <summary>
        /// Gets or sets the value of variable effectiveDateOffsetDays.
        /// </summary>
        [TestVariable("3e6f61a8-b7e4-4e30-98f9-2358f1efe7ae")]
        public string effectiveDateOffsetDays
        {
            get { return _effectiveDateOffsetDays; }
            set { _effectiveDateOffsetDays = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_SendRemedyBulletin_48Simple(bulletinSeed, division, district, sequence_number, source, sourceId, action, comments, bulletinItemType, fieldRecord, bulletin_seed_void, effectiveDateOffsetDays, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
