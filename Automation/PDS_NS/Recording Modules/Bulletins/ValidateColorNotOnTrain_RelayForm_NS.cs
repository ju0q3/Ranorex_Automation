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
    ///The ValidateColorNotOnTrain_RelayForm_NS recording.
    /// </summary>
    [TestModule("9a13f811-eb7b-49d8-a965-1536eea89ca7", ModuleType.Recording, 1)]
    public partial class ValidateColorNotOnTrain_RelayForm_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateColorNotOnTrain_RelayForm_NS instance = new ValidateColorNotOnTrain_RelayForm_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateColorNotOnTrain_RelayForm_NS()
        {
            trainSeed = "";
            color = "";
            closeBulletinRelayForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateColorNotOnTrain_RelayForm_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("dd599851-86ae-4e39-8b92-365569f536dc")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _color;

        /// <summary>
        /// Gets or sets the value of variable color.
        /// </summary>
        [TestVariable("b34d0c78-ce97-4589-830f-c2a5b397642a")]
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        string _closeBulletinRelayForm;

        /// <summary>
        /// Gets or sets the value of variable closeBulletinRelayForm.
        /// </summary>
        [TestVariable("452ff9ad-0023-4d3a-861a-090c8c6f6818")]
        public string closeBulletinRelayForm
        {
            get { return _closeBulletinRelayForm; }
            set { _closeBulletinRelayForm = value; }
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

            UserCodeCollections.NS_Bulletin.NS_Validate_ColorNotOnTrain_RelayForm(trainSeed, color, ValueConverter.ArgumentFromString<bool>("closeBulletinRelayForm", closeBulletinRelayForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
