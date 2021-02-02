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

namespace PDS_NS.Recording_Modules.Trainsheet.PrintFax
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PrintFax_RailCarConsist_NS recording.
    /// </summary>
    [TestModule("ee4c4d47-62be-428b-bd1d-db664762cc43", ModuleType.Recording, 1)]
    public partial class PrintFax_RailCarConsist_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static PrintFax_RailCarConsist_NS instance = new PrintFax_RailCarConsist_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PrintFax_RailCarConsist_NS()
        {
            trainSeed = "";
            name = "";
            address = "";
            quantity = "1";
            printType = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PrintFax_RailCarConsist_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("f73de4c3-8c65-4ab2-a05f-e3d003627ccb")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _name;

        /// <summary>
        /// Gets or sets the value of variable name.
        /// </summary>
        [TestVariable("2f32eda2-6119-4b9a-953d-8154cf48a042")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _address;

        /// <summary>
        /// Gets or sets the value of variable address.
        /// </summary>
        [TestVariable("c0fd70a4-29aa-4f05-be07-e44ce05dd352")]
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        string _quantity;

        /// <summary>
        /// Gets or sets the value of variable quantity.
        /// </summary>
        [TestVariable("5e0bd395-807a-48c6-8f04-948811a8d7ac")]
        public string quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        string _printType;

        /// <summary>
        /// Gets or sets the value of variable printType.
        /// </summary>
        [TestVariable("d79ddf45-4e34-4c0b-96e1-0a17cf64e347")]
        public string printType
        {
            get { return _printType; }
            set { _printType = value; }
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

            UserCodeCollections.NS_Trainsheet.NS_OpenTrainsheetRailcar_MainMenu(trainSeed);
            Delay.Milliseconds(0);
            
            UserCodeCollections.NS_Trainsheet.NS_PrintFax_PrintDialog_Trainsheet(name, address, ValueConverter.ArgumentFromString<int>("quantity", quantity), printType);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
