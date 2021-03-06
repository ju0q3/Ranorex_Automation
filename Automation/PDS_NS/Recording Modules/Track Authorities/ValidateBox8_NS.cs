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
    ///The ValidateBox8_NS recording.
    /// </summary>
    [TestModule("4544fc20-be9e-4edd-a0a9-6556c03a62d8", ModuleType.Recording, 1)]
    public partial class ValidateBox8_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateBox8_NS instance = new ValidateBox8_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateBox8_NS()
        {
            box8EngineSeed1 = "";
            box8Engine1Direction = "";
            box8EngineSeed2 = "";
            box8Engine2Direction = "";
            box8EngineSeed3 = "";
            box8Engine3Direction = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateBox8_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _box8EngineSeed1;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed1.
        /// </summary>
        [TestVariable("5d5c5092-50a6-4bee-a78a-5852d43f37ad")]
        public string box8EngineSeed1
        {
            get { return _box8EngineSeed1; }
            set { _box8EngineSeed1 = value; }
        }

        string _box8Engine1Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine1Direction.
        /// </summary>
        [TestVariable("7af944ba-d2df-4547-af70-05e76db013cd")]
        public string box8Engine1Direction
        {
            get { return _box8Engine1Direction; }
            set { _box8Engine1Direction = value; }
        }

        string _box8EngineSeed2;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed2.
        /// </summary>
        [TestVariable("e650dc04-e812-427a-8167-b942f5519b4d")]
        public string box8EngineSeed2
        {
            get { return _box8EngineSeed2; }
            set { _box8EngineSeed2 = value; }
        }

        string _box8Engine2Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine2Direction.
        /// </summary>
        [TestVariable("e2372e07-85f0-4e59-9402-f33fe55f65ab")]
        public string box8Engine2Direction
        {
            get { return _box8Engine2Direction; }
            set { _box8Engine2Direction = value; }
        }

        string _box8EngineSeed3;

        /// <summary>
        /// Gets or sets the value of variable box8EngineSeed3.
        /// </summary>
        [TestVariable("d2916829-8c65-4dd9-a415-ae57ba4fdfcc")]
        public string box8EngineSeed3
        {
            get { return _box8EngineSeed3; }
            set { _box8EngineSeed3 = value; }
        }

        string _box8Engine3Direction;

        /// <summary>
        /// Gets or sets the value of variable box8Engine3Direction.
        /// </summary>
        [TestVariable("51c46bfa-47a2-40ea-9a04-a81988493c83")]
        public string box8Engine3Direction
        {
            get { return _box8Engine3Direction; }
            set { _box8Engine3Direction = value; }
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

            UserCodeCollections.NS_Authorities.NS_ValidateBox8(box8EngineSeed1, box8Engine1Direction, box8EngineSeed2, box8Engine2Direction, box8EngineSeed3, box8Engine3Direction);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
