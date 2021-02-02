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

namespace PDS_NS.Recording_Modules.TerritoryTransfer
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_OpenTrackline recording.
    /// </summary>
    [TestModule("a4704a3c-089c-45b7-9253-b419e3944120", ModuleType.Recording, 1)]
    public partial class NS_OpenTrackline : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_OpenTrackline instance = new NS_OpenTrackline();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_OpenTrackline()
        {
            divisionName = "";
            territoryName = "";
            pressOk = "False";
            closeForms = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_OpenTrackline Instance
        {
            get { return instance; }
        }

#region Variables

        string _divisionName;

        /// <summary>
        /// Gets or sets the value of variable divisionName.
        /// </summary>
        [TestVariable("c02d1d97-2619-4196-a622-312c59a77042")]
        public string divisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        string _territoryName;

        /// <summary>
        /// Gets or sets the value of variable territoryName.
        /// </summary>
        [TestVariable("7fbc4860-42c2-4167-bc42-2333ca2010bf")]
        public string territoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
        }

        string _pressOk;

        /// <summary>
        /// Gets or sets the value of variable pressOk.
        /// </summary>
        [TestVariable("b68bf165-cc52-4681-a26c-986731aa3954")]
        public string pressOk
        {
            get { return _pressOk; }
            set { _pressOk = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("022f2749-fff7-4d9d-b467-9593e71573d1")]
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

            CodeUtils.NS_TerritoryTransfer.NS_Territory_Open_Trackline(divisionName, territoryName, ValueConverter.ArgumentFromString<bool>("pressOk", pressOk), ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
