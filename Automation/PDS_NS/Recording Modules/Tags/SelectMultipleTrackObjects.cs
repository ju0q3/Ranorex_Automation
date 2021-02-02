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

namespace PDS_NS.Recording_Modules.Tags
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SelectMultipleTrackObjects recording.
    /// </summary>
    [TestModule("6bdd0def-a252-4747-b3bc-c3f64dbeaa9e", ModuleType.Recording, 1)]
    public partial class SelectMultipleTrackObjects : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SelectMultipleTrackObjects instance = new SelectMultipleTrackObjects();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectMultipleTrackObjects()
        {
            tagType = "";
            objectIDs = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SelectMultipleTrackObjects Instance
        {
            get { return instance; }
        }

#region Variables

        string _tagType;

        /// <summary>
        /// Gets or sets the value of variable tagType.
        /// </summary>
        [TestVariable("f2b48f3f-fb13-4a3a-b91c-59d76b06bab0")]
        public string tagType
        {
            get { return _tagType; }
            set { _tagType = value; }
        }

        string _objectIDs;

        /// <summary>
        /// Gets or sets the value of variable objectIDs.
        /// </summary>
        [TestVariable("3b5e641b-634c-4a8e-bbdc-35c4d6299409")]
        public string objectIDs
        {
            get { return _objectIDs; }
            set { _objectIDs = value; }
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

            UserCodeCollections.NS_Tags.NS_HoldCtrlSelectMultipleTrackObjects(tagType, objectIDs);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}