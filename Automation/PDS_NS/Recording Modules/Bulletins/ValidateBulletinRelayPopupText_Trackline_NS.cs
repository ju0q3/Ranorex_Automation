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
    ///The ValidateBulletinRelayPopupText_Trackline_NS recording.
    /// </summary>
    [TestModule("1a7b5d83-25f9-475b-9881-05a27ff7471f", ModuleType.Recording, 1)]
    public partial class ValidateBulletinRelayPopupText_Trackline_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateBulletinRelayPopupText_Trackline_NS instance = new ValidateBulletinRelayPopupText_Trackline_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateBulletinRelayPopupText_Trackline_NS()
        {
            trainSeed = "";
            bulletinSeed = "";
            deviceId = "";
            validateFormExists = "False";
            validateText = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateBulletinRelayPopupText_Trackline_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("12165bb1-451b-4c6a-a97c-9ccf18594e51")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("1fa32fdc-011a-47ac-88fb-27981477ed86")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _deviceId;

        /// <summary>
        /// Gets or sets the value of variable deviceId.
        /// </summary>
        [TestVariable("7296e1f3-9339-434a-a126-feba9f7e8950")]
        public string deviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        string _validateFormExists;

        /// <summary>
        /// Gets or sets the value of variable validateFormExists.
        /// </summary>
        [TestVariable("87975ff5-a50a-4187-beb0-827660963ffa")]
        public string validateFormExists
        {
            get { return _validateFormExists; }
            set { _validateFormExists = value; }
        }

        string _validateText;

        /// <summary>
        /// Gets or sets the value of variable validateText.
        /// </summary>
        [TestVariable("411d7e71-170c-47be-ad50-957bc03ea57a")]
        public string validateText
        {
            get { return _validateText; }
            set { _validateText = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("45424496-b557-4a82-84af-a1f9449f7b25")]
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

            UserCodeCollections.NS_Bulletin.NS_ValidateBulletinRelayPopupText_Trackline(trainSeed, bulletinSeed, deviceId, ValueConverter.ArgumentFromString<bool>("validateFormExists", validateFormExists), ValueConverter.ArgumentFromString<bool>("validateText", validateText), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
