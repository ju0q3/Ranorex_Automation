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

namespace PDS_NS.Recording_Modules.RUM
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendRD_CATA_1Simple_NS recording.
    /// </summary>
    [TestModule("93f358a5-08fe-4612-9327-f8829ae78878", ModuleType.Recording, 1)]
    public partial class SendRD_CATA_1Simple_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendRD_CATA_1Simple_NS instance = new SendRD_CATA_1Simple_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendRD_CATA_1Simple_NS()
        {
            authoritySeed = "";
            crewSeed = "";
            district = "";
            division = "";
            action = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendRD_CATA_1Simple_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _authoritySeed;

        /// <summary>
        /// Gets or sets the value of variable authoritySeed.
        /// </summary>
        [TestVariable("0c3effca-fea3-4bd3-972e-175a1f3b7d35")]
        public string authoritySeed
        {
            get { return _authoritySeed; }
            set { _authoritySeed = value; }
        }

        string _crewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewSeed.
        /// </summary>
        [TestVariable("6e682cda-a8f8-4f56-93ed-182c24b5ba96")]
        public string crewSeed
        {
            get { return _crewSeed; }
            set { _crewSeed = value; }
        }

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("99b56fbe-f33d-43a8-9a64-580ee58d9291")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _division;

        /// <summary>
        /// Gets or sets the value of variable division.
        /// </summary>
        [TestVariable("51f94acd-fc14-48ef-9530-6cd0a4d443c7")]
        public string division
        {
            get { return _division; }
            set { _division = value; }
        }

        string _action;

        /// <summary>
        /// Gets or sets the value of variable action.
        /// </summary>
        [TestVariable("0724a66b-2891-4b13-8eed-bde4d75cc2ff")]
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("ffa4e011-58e5-408e-86de-ae6cede8f30b")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_RUM_Messages.SendRD_CATA_1Simple(authoritySeed, crewSeed, district, division, action, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}