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
    ///The GetBulletinSummaryList recording.
    /// </summary>
    [TestModule("1733eb91-6497-4784-bfa3-7b1a9853e9a1", ModuleType.Recording, 1)]
    public partial class GetBulletinSummaryList : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_CORE.PDS_CORERepository repository.
        /// </summary>
        public static global::PDS_CORE.PDS_CORERepository repo = global::PDS_CORE.PDS_CORERepository.Instance;

        static GetBulletinSummaryList instance = new GetBulletinSummaryList();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public GetBulletinSummaryList()
        {
            factory = "div1";
            user = "sdisp1";
            logicalPosition = "G2UA6181MM4E_JHarrison";
            client = "\"\"";
            arguments = "Desk 02: Champaign;Desk 02: Champaign:3";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static GetBulletinSummaryList Instance
        {
            get { return instance; }
        }

#region Variables

        string _factory;

        /// <summary>
        /// Gets or sets the value of variable factory.
        /// </summary>
        [TestVariable("2eba77f1-472a-4d77-9d29-519a0f4d517e")]
        public string factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        string _user;

        /// <summary>
        /// Gets or sets the value of variable user.
        /// </summary>
        [TestVariable("c2375420-fc4a-491c-bb3e-25d425ef095a")]
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        string _logicalPosition;

        /// <summary>
        /// Gets or sets the value of variable logicalPosition.
        /// </summary>
        [TestVariable("f090a318-ad59-41fe-a258-7108cb2e02ee")]
        public string logicalPosition
        {
            get { return _logicalPosition; }
            set { _logicalPosition = value; }
        }

        string _client;

        /// <summary>
        /// Gets or sets the value of variable client.
        /// </summary>
        [TestVariable("9d68b51d-6079-43d0-bde7-187e73f8d45f")]
        public string client
        {
            get { return _client; }
            set { _client = value; }
        }

        string _arguments;

        /// <summary>
        /// Gets or sets the value of variable arguments.
        /// </summary>
        [TestVariable("db4fcbef-4a7e-4ed0-8b1f-089c11ad824f")]
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

            Code_Utils.Webservices.HeadlessActions.GetBulletinSummaryListCall(factory, user, logicalPosition, client, arguments);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
