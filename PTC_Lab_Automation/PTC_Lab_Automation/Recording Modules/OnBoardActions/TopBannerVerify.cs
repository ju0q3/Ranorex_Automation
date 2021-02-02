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

namespace PTC_Lab_Automation.Recording_Modules.OnBoardActions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The TopBannerVerify recording.
    /// </summary>
    [TestModule("a386c864-1e0f-40da-be73-24e5483e0f5a", ModuleType.Recording, 1)]
    public partial class TopBannerVerify : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PTC_Lab_Automation.Test_ExecutionRepository repository.
        /// </summary>
        public static global::PTC_Lab_Automation.Test_ExecutionRepository repo = global::PTC_Lab_Automation.Test_ExecutionRepository.Instance;

        static TopBannerVerify instance = new TopBannerVerify();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TopBannerVerify()
        {
            banner = "";
            textReplace1 = "";
            textReplacement1Type = "";
            textReplace2 = "";
            textReplacement2Type = "";
            textReplace3 = "";
            textReplacement3Type = "";
            textReplace4 = "";
            textReplacement4Type = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static TopBannerVerify Instance
        {
            get { return instance; }
        }

#region Variables

        string _banner;

        /// <summary>
        /// Gets or sets the value of variable banner.
        /// </summary>
        [TestVariable("16d18360-706e-439b-8b62-b2f69daa9a0e")]
        public string banner
        {
            get { return _banner; }
            set { _banner = value; }
        }

        string _textReplace1;

        /// <summary>
        /// Gets or sets the value of variable textReplace1.
        /// </summary>
        [TestVariable("7e19ca73-5574-434b-9b0e-aacb4ebec63d")]
        public string textReplace1
        {
            get { return _textReplace1; }
            set { _textReplace1 = value; }
        }

        string _textReplacement1Type;

        /// <summary>
        /// Gets or sets the value of variable textReplacement1Type.
        /// </summary>
        [TestVariable("54ddc0b5-5695-4a85-8bb6-8f3d9c83ff32")]
        public string textReplacement1Type
        {
            get { return _textReplacement1Type; }
            set { _textReplacement1Type = value; }
        }

        string _textReplace2;

        /// <summary>
        /// Gets or sets the value of variable textReplace2.
        /// </summary>
        [TestVariable("62cc1b2b-f88e-4ea8-8afb-2abe53efd2ab")]
        public string textReplace2
        {
            get { return _textReplace2; }
            set { _textReplace2 = value; }
        }

        string _textReplacement2Type;

        /// <summary>
        /// Gets or sets the value of variable textReplacement2Type.
        /// </summary>
        [TestVariable("70d469ce-41cd-406d-a73c-1794833cd97a")]
        public string textReplacement2Type
        {
            get { return _textReplacement2Type; }
            set { _textReplacement2Type = value; }
        }

        string _textReplace3;

        /// <summary>
        /// Gets or sets the value of variable textReplace3.
        /// </summary>
        [TestVariable("a1f9aaf5-7249-4e35-8c2b-7931ffd05a84")]
        public string textReplace3
        {
            get { return _textReplace3; }
            set { _textReplace3 = value; }
        }

        string _textReplacement3Type;

        /// <summary>
        /// Gets or sets the value of variable textReplacement3Type.
        /// </summary>
        [TestVariable("4005c331-e33f-4a0e-9bb2-848ed6caddf7")]
        public string textReplacement3Type
        {
            get { return _textReplacement3Type; }
            set { _textReplacement3Type = value; }
        }

        string _textReplace4;

        /// <summary>
        /// Gets or sets the value of variable textReplace4.
        /// </summary>
        [TestVariable("fbeef109-46de-4eb1-96e4-b181e641a828")]
        public string textReplace4
        {
            get { return _textReplace4; }
            set { _textReplace4 = value; }
        }

        string _textReplacement4Type;

        /// <summary>
        /// Gets or sets the value of variable textReplacement4Type.
        /// </summary>
        [TestVariable("a1394dcf-5692-4456-bc5e-4241f0218b1a")]
        public string textReplacement4Type
        {
            get { return _textReplacement4Type; }
            set { _textReplacement4Type = value; }
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

            banner = UserCodeCollections.Utilities.SubstituteStringValues(banner, textReplace1, textReplacement1Type, textReplace2, textReplacement2Type, textReplace3, textReplacement3Type, textReplace4, textReplacement4Type);
            Delay.Milliseconds(0);
            
            TopBannerVerify_Onboard(banner);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
