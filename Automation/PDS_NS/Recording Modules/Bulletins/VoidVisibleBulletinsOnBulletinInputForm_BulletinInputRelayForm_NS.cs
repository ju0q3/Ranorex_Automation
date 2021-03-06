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
    ///The VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS recording.
    /// </summary>
    [TestModule("2f28e6e5-a210-4403-8c5e-7df4d44799ac", ModuleType.Recording, 1)]
    public partial class VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS instance = new VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS()
        {
            optionalDistrict = "";
            optionalType = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _optionalDistrict;

        /// <summary>
        /// Gets or sets the value of variable optionalDistrict.
        /// </summary>
        [TestVariable("3805ee7f-a515-4991-ad53-170ce9b6549c")]
        public string optionalDistrict
        {
            get { return _optionalDistrict; }
            set { _optionalDistrict = value; }
        }

        string _optionalType;

        /// <summary>
        /// Gets or sets the value of variable optionalType.
        /// </summary>
        [TestVariable("2bc8094a-4719-40ab-bfb2-e4e7ea6dc563")]
        public string optionalType
        {
            get { return _optionalType; }
            set { _optionalType = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("cd89e258-d4e5-4eac-bc8f-4bbdf8e10cf4")]
        public string closeForms
        {
            get { return _closeForms; }
            set { _closeForms = value; }
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

            UserCodeCollections.NS_Bulletin.NS_VoidVisibleBulletinsOnBulletinInputForm_BulletinInputRelayForm(optionalDistrict, optionalType, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
