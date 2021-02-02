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

namespace PDS_NS.Recording_Modules.SystemConfiguration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateRow_TrainClearanceRouteConfiguration recording.
    /// </summary>
    [TestModule("aa136804-0195-4162-b6ea-27484f891ba4", ModuleType.Recording, 1)]
    public partial class ValidateRow_TrainClearanceRouteConfiguration : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateRow_TrainClearanceRouteConfiguration instance = new ValidateRow_TrainClearanceRouteConfiguration();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateRow_TrainClearanceRouteConfiguration()
        {
            crewLineSegment = "";
            trainGroup = "";
            originateOpsta = "";
            terminateOpsta = "";
            limit1Opsta = "";
            limit2Opsta = "";
            validateExists = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateRow_TrainClearanceRouteConfiguration Instance
        {
            get { return instance; }
        }

#region Variables

        string _crewLineSegment;

        /// <summary>
        /// Gets or sets the value of variable crewLineSegment.
        /// </summary>
        [TestVariable("6dfba357-5e65-4d71-996e-65eded1d60e6")]
        public string crewLineSegment
        {
            get { return _crewLineSegment; }
            set { _crewLineSegment = value; }
        }

        string _trainGroup;

        /// <summary>
        /// Gets or sets the value of variable trainGroup.
        /// </summary>
        [TestVariable("ecc5c624-5a91-4e3a-b64e-5fb857860993")]
        public string trainGroup
        {
            get { return _trainGroup; }
            set { _trainGroup = value; }
        }

        string _originateOpsta;

        /// <summary>
        /// Gets or sets the value of variable originateOpsta.
        /// </summary>
        [TestVariable("a2f3bab9-9f92-4ad8-8dc0-a5208139316e")]
        public string originateOpsta
        {
            get { return _originateOpsta; }
            set { _originateOpsta = value; }
        }

        string _terminateOpsta;

        /// <summary>
        /// Gets or sets the value of variable terminateOpsta.
        /// </summary>
        [TestVariable("834af236-af0b-4445-83cd-b094b8f053f0")]
        public string terminateOpsta
        {
            get { return _terminateOpsta; }
            set { _terminateOpsta = value; }
        }

        string _limit1Opsta;

        /// <summary>
        /// Gets or sets the value of variable limit1Opsta.
        /// </summary>
        [TestVariable("c5658889-7f97-4935-a0cf-f940d9e6f2ed")]
        public string limit1Opsta
        {
            get { return _limit1Opsta; }
            set { _limit1Opsta = value; }
        }

        string _limit2Opsta;

        /// <summary>
        /// Gets or sets the value of variable limit2Opsta.
        /// </summary>
        [TestVariable("4b6ba115-9cc3-4c3f-9425-ff0c4c8c9702")]
        public string limit2Opsta
        {
            get { return _limit2Opsta; }
            set { _limit2Opsta = value; }
        }

        string _validateExists;

        /// <summary>
        /// Gets or sets the value of variable validateExists.
        /// </summary>
        [TestVariable("a1fe3ee3-ccb7-4833-b313-7a225a9cb6bc")]
        public string validateExists
        {
            get { return _validateExists; }
            set { _validateExists = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("0e6f64a2-4882-4a16-9544-8ecfef1f0a2d")]
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

            UserCodeCollections.NS_SystemConfiguration.NS_ValidateRow_TrainClearanceRouteConfiguration(crewLineSegment, trainGroup, originateOpsta, terminateOpsta, limit1Opsta, limit2Opsta, ValueConverter.ArgumentFromString<bool>("validateExists", validateExists), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}