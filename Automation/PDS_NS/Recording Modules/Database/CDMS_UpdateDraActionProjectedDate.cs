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

namespace PDS_NS.Recording_Modules.Database
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CDMS_UpdateDraActionProjectedDate recording.
    /// </summary>
    [TestModule("3b168a60-7040-4c1a-af93-698ce14df85c", ModuleType.Recording, 1)]
    public partial class CDMS_UpdateDraActionProjectedDate : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_UpdateDraActionProjectedDate instance = new CDMS_UpdateDraActionProjectedDate();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_UpdateDraActionProjectedDate()
        {
            trainSeed = "";
            fromOpsta = "";
            toOpsta = "";
            projectedDateOffset = "0";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_UpdateDraActionProjectedDate Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("6f64bdf3-d6d4-46ca-8957-5d96c163482a")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _fromOpsta;

        /// <summary>
        /// Gets or sets the value of variable fromOpsta.
        /// </summary>
        [TestVariable("143cc378-39c9-45a6-bfd4-46cac18b029a")]
        public string fromOpsta
        {
            get { return _fromOpsta; }
            set { _fromOpsta = value; }
        }

        string _toOpsta;

        /// <summary>
        /// Gets or sets the value of variable toOpsta.
        /// </summary>
        [TestVariable("73836b77-9de2-4e57-9edd-266b0f3843f5")]
        public string toOpsta
        {
            get { return _toOpsta; }
            set { _toOpsta = value; }
        }

        string _projectedDateOffset;

        /// <summary>
        /// Gets or sets the value of variable projectedDateOffset.
        /// </summary>
        [TestVariable("2e00659a-8300-43cd-b769-cfaf8b694a6f")]
        public string projectedDateOffset
        {
            get { return _projectedDateOffset; }
            set { _projectedDateOffset = value; }
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

            UserCodeCollections.NS_DRA.NS_UpdateProjectedDateActionTable(trainSeed, fromOpsta, toOpsta, ValueConverter.ArgumentFromString<int>("projectedDateOffset", projectedDateOffset));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
