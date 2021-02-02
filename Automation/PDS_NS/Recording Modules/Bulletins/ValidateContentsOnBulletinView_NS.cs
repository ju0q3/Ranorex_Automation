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

namespace PDS_NS.Recording_Modules.Bulletins
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateContentsOnBulletinView_NS recording.
    /// </summary>
    [TestModule("2feb2b86-350b-4397-be42-2ec3314703cb", ModuleType.Recording, 1)]
    public partial class ValidateContentsOnBulletinView_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateContentsOnBulletinView_NS instance = new ValidateContentsOnBulletinView_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateContentsOnBulletinView_NS()
        {
            bulletinSeed = "";
            bulletinObjectMenu = "";
            validateFrom = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateContentsOnBulletinView_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("f4b9b295-c1aa-44d6-8983-2bf392aa33fa")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _bulletinObjectMenu;

        /// <summary>
        /// Gets or sets the value of variable bulletinObjectMenu.
        /// </summary>
        [TestVariable("af3189de-deab-43de-b411-98abe9d30852")]
        public string bulletinObjectMenu
        {
            get { return _bulletinObjectMenu; }
            set { _bulletinObjectMenu = value; }
        }

        string _validateFrom;

        /// <summary>
        /// Gets or sets the value of variable validateFrom.
        /// </summary>
        [TestVariable("58e4317f-0f3b-4b08-a5b5-80e0a775ea33")]
        public string validateFrom
        {
            get { return _validateFrom; }
            set { _validateFrom = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("f41945b9-faf1-48c0-a832-0e0c7b310509")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
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

            UserCodeCollections.NS_Bulletin.NS_validateContentsOnBulletinView(bulletinSeed, bulletinObjectMenu, validateFrom, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}