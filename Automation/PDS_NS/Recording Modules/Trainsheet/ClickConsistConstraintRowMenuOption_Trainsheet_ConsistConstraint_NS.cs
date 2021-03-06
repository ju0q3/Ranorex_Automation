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

namespace PDS_NS.Recording_Modules.Trainsheet
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS recording.
    /// </summary>
    [TestModule("a18b835a-bce5-4b8f-98a5-214982037cdf", ModuleType.Recording, 1)]
    public partial class ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS instance = new ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS()
        {
            trainSeed = "";
            fromOpsta = "";
            toOpsta = "";
            type = "";
            menuOption = "";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("e1a1c649-e8a3-4ddb-bc57-c1c8a2192882")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _fromOpsta;

        /// <summary>
        /// Gets or sets the value of variable fromOpsta.
        /// </summary>
        [TestVariable("e04410db-d152-40dc-9fbd-148feaf17b51")]
        public string fromOpsta
        {
            get { return _fromOpsta; }
            set { _fromOpsta = value; }
        }

        string _toOpsta;

        /// <summary>
        /// Gets or sets the value of variable toOpsta.
        /// </summary>
        [TestVariable("9b40c580-f90c-43f6-ae89-1ecbc81debd5")]
        public string toOpsta
        {
            get { return _toOpsta; }
            set { _toOpsta = value; }
        }

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("f9b238c2-6dc3-47db-a6d6-ed02f428fc41")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        string _menuOption;

        /// <summary>
        /// Gets or sets the value of variable menuOption.
        /// </summary>
        [TestVariable("ed201b6a-05cc-419e-80ef-c44b41a6c353")]
        public string menuOption
        {
            get { return _menuOption; }
            set { _menuOption = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("0373ea70-7a6c-4ee1-8e6c-8b4b04adcd58")]
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

            UserCodeCollections.NS_Trainsheet.NS_ClickConsistConstraintRowMenuOption_Trainsheet_ConsistConstraint(trainSeed, fromOpsta, toOpsta, type, menuOption, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
