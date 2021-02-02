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
    ///The ValidateTagName recording.
    /// </summary>
    [TestModule("4d5bd7ba-a459-4161-9265-98d1242f2038", ModuleType.Recording, 1)]
    public partial class ValidateTagName : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.Trackline_Repo repository.
        /// </summary>
        public static global::PDS_NS.Trackline_Repo repo = global::PDS_NS.Trackline_Repo.Instance;

        static ValidateTagName instance = new ValidateTagName();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateTagName()
        {
            tagName = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateTagName Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable tagName.
        /// </summary>
        [TestVariable("2f00e351-d736-4e38-bf60-ee42e8baa005")]
        public string tagName
        {
            get { return repo.TagName; }
            set { repo.TagName = value; }
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

            UserCodeCollections.NS_Trackline_Validations.NS_ValidateTagName(tagName);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}