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
    ///The ValidateBulletinTypeExistsInInputForm recording.
    /// </summary>
    [TestModule("a74fe213-4a73-47c5-b3f2-9b6439293703", ModuleType.Recording, 1)]
    public partial class ValidateBulletinTypeExistsInInputForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateBulletinTypeExistsInInputForm instance = new ValidateBulletinTypeExistsInInputForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateBulletinTypeExistsInInputForm()
        {
            bulletinName = "";
            isDisplayed = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateBulletinTypeExistsInInputForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _bulletinName;

        /// <summary>
        /// Gets or sets the value of variable bulletinName.
        /// </summary>
        [TestVariable("123b9796-3e26-47a1-adee-0e6a70cebb07")]
        public string bulletinName
        {
            get { return _bulletinName; }
            set { _bulletinName = value; }
        }

        string _isDisplayed;

        /// <summary>
        /// Gets or sets the value of variable isDisplayed.
        /// </summary>
        [TestVariable("8d7f95a1-927b-4665-8431-625014501adf")]
        public string isDisplayed
        {
            get { return _isDisplayed; }
            set { _isDisplayed = value; }
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

            UserCodeCollections.NS_Bulletin.NS_ValidateBulletinTypeExistsInInputForm(bulletinName, ValueConverter.ArgumentFromString<bool>("isDisplayed", isDisplayed));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
