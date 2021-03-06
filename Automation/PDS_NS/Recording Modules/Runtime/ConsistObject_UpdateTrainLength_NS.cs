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

namespace PDS_NS.Recording_Modules.Runtime
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ConsistObject_UpdateTrainLength_NS recording.
    /// </summary>
    [TestModule("77495fa4-b35a-4265-b0dc-1998a1a70f19", ModuleType.Recording, 1)]
    public partial class ConsistObject_UpdateTrainLength_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ConsistObject_UpdateTrainLength_NS instance = new ConsistObject_UpdateTrainLength_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConsistObject_UpdateTrainLength_NS()
        {
            trainSeed = "";
            consistSeed = "";
            lengthIncrease = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConsistObject_UpdateTrainLength_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("22e0f684-5984-48f1-80ff-ced04fbde1a5")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _consistSeed;

        /// <summary>
        /// Gets or sets the value of variable consistSeed.
        /// </summary>
        [TestVariable("42a30a2a-3be2-4206-9d7a-4556b1fc12df")]
        public string consistSeed
        {
            get { return _consistSeed; }
            set { _consistSeed = value; }
        }

        string _lengthIncrease;

        /// <summary>
        /// Gets or sets the value of variable lengthIncrease.
        /// </summary>
        [TestVariable("a5e7b753-6bf3-4d49-8150-60c2ee113587")]
        public string lengthIncrease
        {
            get { return _lengthIncrease; }
            set { _lengthIncrease = value; }
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

            PDS_CORE.Code_Utils.NS_TrainID.UpdateConsistTrainLength(trainSeed, consistSeed, ValueConverter.ArgumentFromString<int>("lengthIncrease", lengthIncrease));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
