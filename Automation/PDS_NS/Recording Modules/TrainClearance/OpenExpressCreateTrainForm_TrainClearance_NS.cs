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

namespace PDS_NS.Recording_Modules.TrainClearance
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenExpressCreateTrainForm_TrainClearance_NS recording.
    /// </summary>
    [TestModule("e43cec11-8859-4918-b7d9-fd3cf6e30ac3", ModuleType.Recording, 1)]
    public partial class OpenExpressCreateTrainForm_TrainClearance_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static OpenExpressCreateTrainForm_TrainClearance_NS instance = new OpenExpressCreateTrainForm_TrainClearance_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenExpressCreateTrainForm_TrainClearance_NS()
        {
            newTrainSeed = "";
            clickOnYes = "False";
            validateFormExists = "False";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenExpressCreateTrainForm_TrainClearance_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _newTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable newTrainSeed.
        /// </summary>
        [TestVariable("66f9589d-5067-42ed-87e8-87b3fe6ab701")]
        public string newTrainSeed
        {
            get { return _newTrainSeed; }
            set { _newTrainSeed = value; }
        }

        string _clickOnYes;

        /// <summary>
        /// Gets or sets the value of variable clickOnYes.
        /// </summary>
        [TestVariable("b8c2dda6-37d6-4992-8a88-693f06ae58fc")]
        public string clickOnYes
        {
            get { return _clickOnYes; }
            set { _clickOnYes = value; }
        }

        string _validateFormExists;

        /// <summary>
        /// Gets or sets the value of variable validateFormExists.
        /// </summary>
        [TestVariable("85f4b79a-b319-4d5d-8b41-3eaf2353961f")]
        public string validateFormExists
        {
            get { return _validateFormExists; }
            set { _validateFormExists = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("37447323-2e64-4074-bace-42bc4d3142c1")]
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

            UserCodeCollections.NS_TrainClearance.NS_OpenExpressCreateTrainForm_TrainClearance(newTrainSeed, ValueConverter.ArgumentFromString<bool>("clickOnYes", clickOnYes), ValueConverter.ArgumentFromString<bool>("validateFormExists", validateFormExists), ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
