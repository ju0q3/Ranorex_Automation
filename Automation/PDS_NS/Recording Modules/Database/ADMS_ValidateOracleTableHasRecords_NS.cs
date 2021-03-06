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
    ///The ADMS_ValidateOracleTableHasRecords_NS recording.
    /// </summary>
    [TestModule("c2be6c6c-b9b7-4c5d-a331-156a45498414", ModuleType.Recording, 1)]
    public partial class ADMS_ValidateOracleTableHasRecords_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ADMS_ValidateOracleTableHasRecords_NS instance = new ADMS_ValidateOracleTableHasRecords_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ADMS_ValidateOracleTableHasRecords_NS()
        {
            tableName = "";
            validateHasRecords = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ADMS_ValidateOracleTableHasRecords_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _tableName;

        /// <summary>
        /// Gets or sets the value of variable tableName.
        /// </summary>
        [TestVariable("b02f927b-e4d0-4c10-b8ad-e3f5736ecf9c")]
        public string tableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        string _validateHasRecords;

        /// <summary>
        /// Gets or sets the value of variable validateHasRecords.
        /// </summary>
        [TestVariable("6ef199be-f15c-487f-ab63-999e6a556816")]
        public string validateHasRecords
        {
            get { return _validateHasRecords; }
            set { _validateHasRecords = value; }
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

            UserCodeCollections.NS_Oracle.NS_OracleValidation.NS_ValidateOracleTableHasRecords("ADMS", tableName, ValueConverter.ArgumentFromString<bool>("validateHasRecords", validateHasRecords));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
