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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenAuthorityFromDTAD recording.
    /// </summary>
    [TestModule("18f11e25-ef5c-4bcf-bc53-b1bd410c4fe9", ModuleType.Recording, 1)]
    public partial class OpenAuthorityFromDTAD : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static OpenAuthorityFromDTAD instance = new OpenAuthorityFromDTAD();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenAuthorityFromDTAD()
        {
            AuthoritySeed = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenAuthorityFromDTAD Instance
        {
            get { return instance; }
        }

#region Variables

        string _AuthoritySeed;

        /// <summary>
        /// Gets or sets the value of variable AuthoritySeed.
        /// </summary>
        [TestVariable("d936a0ca-19b5-4144-ac04-3c2871b3ba95")]
        public string AuthoritySeed
        {
            get { return _AuthoritySeed; }
            set { _AuthoritySeed = value; }
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

            UserCodeCollections.NS_Authorities.NS_OpenAuthority_DTAD(AuthoritySeed);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
