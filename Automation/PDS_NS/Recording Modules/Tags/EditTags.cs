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
    ///The EditTags recording.
    /// </summary>
    [TestModule("7783bdbb-7c9b-46b1-a71c-a3b8f6e1343c", ModuleType.Recording, 1)]
    public partial class EditTags : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static EditTags instance = new EditTags();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EditTags()
        {
            editTagName = "";
            editTagType = "";
            editTagComments = "";
            tagType = "";
            tagName = "";
            objectId = "";
            comments = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EditTags Instance
        {
            get { return instance; }
        }

#region Variables

        string _editTagName;

        /// <summary>
        /// Gets or sets the value of variable editTagName.
        /// </summary>
        [TestVariable("5a94358d-11ab-4e49-8c30-ab1bc0f717ba")]
        public string editTagName
        {
            get { return _editTagName; }
            set { _editTagName = value; }
        }

        string _editTagType;

        /// <summary>
        /// Gets or sets the value of variable editTagType.
        /// </summary>
        [TestVariable("f3ab0c08-7d3f-48fa-b38e-17fa5325064e")]
        public string editTagType
        {
            get { return _editTagType; }
            set { _editTagType = value; }
        }

        string _editTagComments;

        /// <summary>
        /// Gets or sets the value of variable editTagComments.
        /// </summary>
        [TestVariable("852e07b8-3fa3-4aaf-88d3-429f316e5e18")]
        public string editTagComments
        {
            get { return _editTagComments; }
            set { _editTagComments = value; }
        }

        string _tagType;

        /// <summary>
        /// Gets or sets the value of variable tagType.
        /// </summary>
        [TestVariable("ea755b52-bd41-4328-a27e-846f2840562d")]
        public string tagType
        {
            get { return _tagType; }
            set { _tagType = value; }
        }

        string _tagName;

        /// <summary>
        /// Gets or sets the value of variable tagName.
        /// </summary>
        [TestVariable("31925135-6355-41ad-8c2c-3ecc9fbe5f19")]
        public string tagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        string _objectId;

        /// <summary>
        /// Gets or sets the value of variable objectId.
        /// </summary>
        [TestVariable("e6af1404-4428-4473-975c-f2e63f41b176")]
        public string objectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        string _comments;

        /// <summary>
        /// Gets or sets the value of variable comments.
        /// </summary>
        [TestVariable("f34d17f6-75ae-46e6-9640-fd64b6ed669c")]
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
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

            UserCodeCollections.NS_Tags.NS_EditTags(editTagName, editTagType, editTagComments, tagType, tagName, comments, objectId);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
