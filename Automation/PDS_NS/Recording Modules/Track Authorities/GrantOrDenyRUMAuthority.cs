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
    ///The GrantOrDenyRUMAuthority recording.
    /// </summary>
    [TestModule("ab222ee1-d521-41cc-b6ac-4bf4d21b8d6b", ModuleType.Recording, 1)]
    public partial class GrantOrDenyRUMAuthority : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static GrantOrDenyRUMAuthority instance = new GrantOrDenyRUMAuthority();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GrantOrDenyRUMAuthority()
        {
            grantAuthority = "True";
            closeForms = "False";
            authoritySeed = "";
            expectedFeedback = "";
            box8EngineSeed1 = "";
            box8Engine1Direction = "";
            box8EngineSeed2 = "";
            box8Engine2Direction = "";
            box8EngineSeed3 = "";
            box8Engine3Direction = "";
            box10Between1 = "";
            box10Between2 = "";
            box11StopShort = "";
            box11Track = "";
            commentsText = "";
            closeAuthorityForm = "False";
            optexpectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static GrantOrDenyRUMAuthority Instance
        {
            get { return instance; }
        }

#region Variables

        string _grantAuthority;

        /// <summary>
        /// Gets or sets the value of variable grantAuthority.
        /// </summary>
        [TestVariable("5eb24f53-24a6-41df-96ef-947a2e600e6f")]
        public string grantAuthority
        {
            get { return _grantAuthority; }
            set { _grantAuthority = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("c7e2d468-ea37-40e9-b41d-944057c391b6")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
        }

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("85285455-f7ca-4f5b-9c2c-9ef134da0b51")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("c1e6b966-0884-4fce-a2b4-3ef642b5f218")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _box8EngineSeed1;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed1.
        /// </summary>
        [TestVariable("364cdd74-fa88-463f-a9ca-b1c1afaa43d2")]
        public string box8EngineSeed1
        {
            get { return _box8EngineSeed1; }
            set { _box8EngineSeed1 = value; }
        }

        string _box8Engine1Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine1Direction.
        /// </summary>
        [TestVariable("f1709339-eeff-49a1-9b02-17ad671c9832")]
        public string box8Engine1Direction
        {
            get { return _box8Engine1Direction; }
            set { _box8Engine1Direction = value; }
        }

        string _box8EngineSeed2;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed2.
        /// </summary>
        [TestVariable("babc6192-9e39-4a56-8dcd-534eeee934ca")]
        public string box8EngineSeed2
        {
            get { return _box8EngineSeed2; }
            set { _box8EngineSeed2 = value; }
        }

        string _box8Engine2Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine2Direction.
        /// </summary>
        [TestVariable("dc195aa8-a051-4ccb-945d-a01f569e5f6e")]
        public string box8Engine2Direction
        {
            get { return _box8Engine2Direction; }
            set { _box8Engine2Direction = value; }
        }

        string _box8EngineSeed3;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed3.
        /// </summary>
        [TestVariable("415b19d4-d8f0-403e-ad90-c4811c70a510")]
        public string box8EngineSeed3
        {
            get { return _box8EngineSeed3; }
            set { _box8EngineSeed3 = value; }
        }

        string _box8Engine3Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine3Direction.
        /// </summary>
        [TestVariable("0e3e47ff-9bc7-4d1c-9825-36414f205ee1")]
        public string box8Engine3Direction
        {
            get { return _box8Engine3Direction; }
            set { _box8Engine3Direction = value; }
        }

        string _box10Between1;

        /// <summary>
        /// Gets or sets the value of variable box10Between1.
        /// </summary>
        [TestVariable("d655144e-0ecc-4f74-9a98-eacaacf4a983")]
        public string box10Between1
        {
            get { return _box10Between1; }
            set { _box10Between1 = value; }
        }

        string _box10Between2;

        /// <summary>
        /// Gets or sets the value of variable box10Between2.
        /// </summary>
        [TestVariable("6aa1a9fa-8b50-466a-b85d-15bddd33a796")]
        public string box10Between2
        {
            get { return _box10Between2; }
            set { _box10Between2 = value; }
        }

        string _box11StopShort;

        /// <summary>
        /// Gets or sets the value of variable box11StopShort.
        /// </summary>
        [TestVariable("a63e1d70-b2b7-4e05-99be-8cc47c7f35d5")]
        public string box11StopShort
        {
            get { return _box11StopShort; }
            set { _box11StopShort = value; }
        }

        string _box11Track;

        /// <summary>
        /// Gets or sets the value of variable box11Track.
        /// </summary>
        [TestVariable("f7cece63-88d5-4269-8f8f-d16b7176d02c")]
        public string box11Track
        {
            get { return _box11Track; }
            set { _box11Track = value; }
        }

        string _commentsText;

        /// <summary>
        /// Gets or sets the value of variable commentsText.
        /// </summary>
        [TestVariable("10509483-bcd0-4614-ab9f-e8139b5ef20e")]
        public string commentsText
        {
            get { return _commentsText; }
            set { _commentsText = value; }
        }

        string _closeAuthorityForm;

        /// <summary>
        /// Gets or sets the value of variable closeAuthorityForm.
        /// </summary>
        [TestVariable("85843436-b22a-4f38-90e0-39d969ffd3d6")]
        public string closeAuthorityForm
        {
            get { return _closeAuthorityForm; }
            set { _closeAuthorityForm = value; }
        }

        string _optexpectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable optexpectedFeedback.
        /// </summary>
        [TestVariable("ed6b74bd-fdb8-44b4-8d5c-8cecd1bf4bf6")]
        public string optexpectedFeedback
        {
            get { return _optexpectedFeedback; }
            set { _optexpectedFeedback = value; }
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

            UserCodeCollections.NS_Authorities.NS_GrantOrDenyRUMAuthority(authoritySeed, box8EngineSeed1, box8Engine1Direction, box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction, box10Between1, box10Between2, box11StopShort, box11Track, commentsText, ValueConverter.ArgumentFromString<bool>("grantAuthority", grantAuthority), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms), expectedFeedback, ValueConverter.ArgumentFromString<bool>("closeAuthorityForm", closeAuthorityForm), optexpectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}