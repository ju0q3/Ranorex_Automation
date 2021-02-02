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

namespace PDS_CORE.Recording_Modules.WebLogic.SummaryLists
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The GetTrainSheetStatusSummaryList recording.
    /// </summary>
    [TestModule("8fd4d3bf-82ca-487a-8ff7-df20e9a4d4d4", ModuleType.Recording, 1)]
    public partial class GetTrainSheetStatusSummaryList : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static GetTrainSheetStatusSummaryList instance = new GetTrainSheetStatusSummaryList();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GetTrainSheetStatusSummaryList()
        {
            factory = "TRT_TRAIN_SHEET_SMI_div1";
            user = "sdisp1";
            logicalPosition = "G2UA6181MM4E_JHarrison";
            client = "\"\"";
            arguments = "Desk 02: Champaign;Desk 02: Champaign:3";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static GetTrainSheetStatusSummaryList Instance
        {
            get { return instance; }
        }

#region Variables

        string _factory;

        /// <summary>
        /// Gets or sets the value of variable factory.
        /// </summary>
        [TestVariable("3614a683-bd08-425c-a6f3-d9a4e01fdc04")]
        public string factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        string _user;

        /// <summary>
        /// Gets or sets the value of variable user.
        /// </summary>
        [TestVariable("9c01631f-ea52-49c4-a3da-77e02d8efe4a")]
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        string _logicalPosition;

        /// <summary>
        /// Gets or sets the value of variable logicalPosition.
        /// </summary>
        [TestVariable("f0bb4d53-3701-40a4-9216-b337f6e87344")]
        public string logicalPosition
        {
            get { return _logicalPosition; }
            set { _logicalPosition = value; }
        }

        string _client;

        /// <summary>
        /// Gets or sets the value of variable client.
        /// </summary>
        [TestVariable("dd743be4-c3a9-4914-b2c0-aa07da04421b")]
        public string client
        {
            get { return _client; }
            set { _client = value; }
        }

        string _arguments;

        /// <summary>
        /// Gets or sets the value of variable arguments.
        /// </summary>
        [TestVariable("f0ec2356-eecc-4f34-8d69-602b26904cf4")]
        public string arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
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

            Code_Utils.Webservices.HeadlessActions.GetTrainSheetStatusSummaryListCall(factory, user, logicalPosition, client, arguments);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
