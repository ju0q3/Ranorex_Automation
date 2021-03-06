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

namespace PDS_NS.Recording_Modules.Trackline
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The TurnTraceOnOff_Trackline_NS recording.
    /// </summary>
    [TestModule("b3370217-44ef-4e68-ab5f-5118fedba998", ModuleType.Recording, 1)]
    public partial class TurnTraceOnOff_Trackline_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static TurnTraceOnOff_Trackline_NS instance = new TurnTraceOnOff_Trackline_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TurnTraceOnOff_Trackline_NS()
        {
            trainSeed = "";
            tracemodeOn = "False";
            expectedFeedback = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static TurnTraceOnOff_Trackline_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("d0bd1eac-6867-4a28-997c-cdf463906abb")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _tracemodeOn;

        /// <summary>
        /// Gets or sets the value of variable tracemodeOn.
        /// </summary>
        [TestVariable("ce61dc18-a772-4c14-b6d0-f1281b421ac7")]
        public string tracemodeOn
        {
            get { return _tracemodeOn; }
            set { _tracemodeOn = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("dc7a7412-aa1d-4350-b558-3ac22fc2d484")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
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

            UserCodeCollections.NS_Trackline.NS_TrainTraceMode_Trackline(trainSeed, ValueConverter.ArgumentFromString<bool>("tracemodeOn", tracemodeOn), expectedFeedback);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
