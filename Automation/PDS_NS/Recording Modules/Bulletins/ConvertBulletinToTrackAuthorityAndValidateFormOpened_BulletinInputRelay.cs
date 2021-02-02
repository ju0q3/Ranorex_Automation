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
    ///The ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay recording.
    /// </summary>
    [TestModule("024ac06c-ecf1-4970-b4cf-340ce643b27f", ModuleType.Recording, 1)]
    public partial class ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay instance = new ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay()
        {
            bulletinSeed = "";
            optionConvertFrom = "bulletinInputRelay";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConvertBulletinToTrackAuthorityAndValidateFormOpened_BulletinInputRelay Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("bf622e95-581e-4e27-a229-59961aaba553")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _optionConvertFrom;

        /// <summary>
        /// Gets or sets the value of variable optionConvertFrom.
        /// </summary>
        [TestVariable("ccff5b7d-2149-47bc-ad08-1f099aa44628")]
        public string optionConvertFrom
        {
            get { return _optionConvertFrom; }
            set { _optionConvertFrom = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("b4ed7fdb-7c2a-47ed-86a1-da92655df45b")]
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

            UserCodeCollections.NS_Bulletin.NS_ConvertBulletinToTrackAuthorityAndValidateFormOpened(bulletinSeed, optionConvertFrom, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
