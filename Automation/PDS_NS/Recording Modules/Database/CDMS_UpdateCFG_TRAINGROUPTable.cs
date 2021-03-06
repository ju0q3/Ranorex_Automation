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
    ///The CDMS_UpdateCFG_TRAINGROUPTable recording.
    /// </summary>
    [TestModule("40a87bb7-2725-48ec-a894-1977fb1d2cce", ModuleType.Recording, 1)]
    public partial class CDMS_UpdateCFG_TRAINGROUPTable : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CDMS_UpdateCFG_TRAINGROUPTable instance = new CDMS_UpdateCFG_TRAINGROUPTable();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CDMS_UpdateCFG_TRAINGROUPTable()
        {
            columnName = "";
            configValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CDMS_UpdateCFG_TRAINGROUPTable Instance
        {
            get { return instance; }
        }

#region Variables

        string _columnName;

        /// <summary>
        /// Gets or sets the value of variable columnName.
        /// </summary>
        [TestVariable("0c130e5f-b019-4661-ac6c-02df71cd4221")]
        public string columnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        string _configValue;

        /// <summary>
        /// Gets or sets the value of variable configValue.
        /// </summary>
        [TestVariable("433962e9-45e1-4387-9c1c-bb275413e6de")]
        public string configValue
        {
            get { return _configValue; }
            set { _configValue = value; }
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

            Oracle.Code_Utils.CDMSEnvironment.UpdateCFG_TRAINGROUPTable(columnName, configValue);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
