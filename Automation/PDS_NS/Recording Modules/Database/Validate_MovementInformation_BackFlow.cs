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
    ///The Validate_MovementInformation_BackFlow recording.
    /// </summary>
    [TestModule("71bb5ec2-cea2-4077-b0ce-4c63a8d13fff", ModuleType.Recording, 1)]
    public partial class Validate_MovementInformation_BackFlow : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_MovementInformation_BackFlow instance = new Validate_MovementInformation_BackFlow();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_MovementInformation_BackFlow()
        {
            trainSeed = "";
            opstaLocation = "";
            Ispresent = "True";
            optAverageSpeed = "";
            optTrainLength = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_MovementInformation_BackFlow Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("7854fa25-7880-4d42-8188-7b7aefc9fd69")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _opstaLocation;

        /// <summary>
        /// Gets or sets the value of variable opstaLocation.
        /// </summary>
        [TestVariable("a612c7f2-c6bf-4ac1-9b60-0cf707877488")]
        public string opstaLocation
        {
            get { return _opstaLocation; }
            set { _opstaLocation = value; }
        }

        string _Ispresent;

        /// <summary>
        /// Gets or sets the value of variable Ispresent.
        /// </summary>
        [TestVariable("e2080af8-7870-428f-ad2b-c196891bd8c4")]
        public string Ispresent
        {
            get { return _Ispresent; }
            set { _Ispresent = value; }
        }

        string _optAverageSpeed;

        /// <summary>
        /// Gets or sets the value of variable optAverageSpeed.
        /// </summary>
        [TestVariable("c26e0314-9660-4fb3-891c-292af28d30c7")]
        public string optAverageSpeed
        {
            get { return _optAverageSpeed; }
            set { _optAverageSpeed = value; }
        }

        string _optTrainLength;

        /// <summary>
        /// Gets or sets the value of variable optTrainLength.
        /// </summary>
        [TestVariable("714341a8-29db-48c4-8367-aab2dc18e35d")]
        public string optTrainLength
        {
            get { return _optTrainLength; }
            set { _optTrainLength = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_validate_MovementInformation_BackFlow(trainSeed, opstaLocation, optAverageSpeed, optTrainLength, ValueConverter.ArgumentFromString<bool>("IsPresent", Ispresent));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}