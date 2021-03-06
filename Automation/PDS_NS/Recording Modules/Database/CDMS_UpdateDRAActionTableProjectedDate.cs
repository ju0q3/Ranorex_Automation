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
    ///The CDMS_UpdateDRAActionTableProjectedDate recording.
    /// </summary>
    [TestModule("b636da83-c623-4c74-b12a-bc0daee7e054", ModuleType.Recording, 1)]
    public partial class CDMS_UpdateDRAActionTableProjectedDate : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_UpdateDRAActionTableProjectedDate instance = new CDMS_UpdateDRAActionTableProjectedDate();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_UpdateDRAActionTableProjectedDate()
        {
            trainSeed = "";
            fromOpsta = "";
            toOpsta = "";
            tomorrowDate = "False";
            yesterdayDate = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_UpdateDRAActionTableProjectedDate Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("063f3740-e83c-4f1b-b4cf-daa5922e58a6")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _fromOpsta;

        /// <summary>
        /// Gets or sets the value of variable fromOpsta.
        /// </summary>
        [TestVariable("6fd69ea8-b29d-4a1a-adbc-6874d23dfcba")]
        public string fromOpsta
        {
            get { return _fromOpsta; }
            set { _fromOpsta = value; }
        }

        string _toOpsta;

        /// <summary>
        /// Gets or sets the value of variable toOpsta.
        /// </summary>
        [TestVariable("373622e8-6caf-4f98-970f-87f62eaf1bcd")]
        public string toOpsta
        {
            get { return _toOpsta; }
            set { _toOpsta = value; }
        }

        string _tomorrowDate;

        /// <summary>
        /// Gets or sets the value of variable tomorrowDate.
        /// </summary>
        [TestVariable("44cb1123-1a67-460c-8b54-063f79422524")]
        public string tomorrowDate
        {
            get { return _tomorrowDate; }
            set { _tomorrowDate = value; }
        }

        string _yesterdayDate;

        /// <summary>
        /// Gets or sets the value of variable yesterdayDate.
        /// </summary>
        [TestVariable("a7360a86-d105-4c00-a521-2b511b2a2f4c")]
        public string yesterdayDate
        {
            get { return _yesterdayDate; }
            set { _yesterdayDate = value; }
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

            UserCodeCollections.NS_DRA.NS_UpdateProjectedDateActionTable(trainSeed, fromOpsta, toOpsta, ValueConverter.ArgumentFromString<bool>("tomorrowDate", tomorrowDate), ValueConverter.ArgumentFromString<bool>("yesterdayDate", yesterdayDate));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
