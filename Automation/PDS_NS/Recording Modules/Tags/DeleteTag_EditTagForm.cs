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

namespace PDS_NS.Recording_Modules.Tags
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The DeleteTag_EditTagForm recording.
    /// </summary>
    [TestModule("f92de718-1f22-4c42-aeba-621784207773", ModuleType.Recording, 1)]
    public partial class DeleteTag_EditTagForm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static DeleteTag_EditTagForm instance = new DeleteTag_EditTagForm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public DeleteTag_EditTagForm()
        {
            tagName = "";
            betweenAtValue = "";
            andValue = "";
            onTrackValue = "";
            closeForms = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static DeleteTag_EditTagForm Instance
        {
            get { return instance; }
        }

#region Variables

        string _tagName;

        /// <summary>
        /// Gets or sets the value of variable tagName.
        /// </summary>
        [TestVariable("2648aaba-18ec-4f40-8a5e-ab2567925004")]
        public string tagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        string _betweenAtValue;

        /// <summary>
        /// Gets or sets the value of variable betweenAtValue.
        /// </summary>
        [TestVariable("54cefc52-a5ba-4550-a5b2-bc4ecd2216de")]
        public string betweenAtValue
        {
            get { return _betweenAtValue; }
            set { _betweenAtValue = value; }
        }

        string _andValue;

        /// <summary>
        /// Gets or sets the value of variable andValue.
        /// </summary>
        [TestVariable("c2120511-923a-41d0-997a-e5974d181800")]
        public string andValue
        {
            get { return _andValue; }
            set { _andValue = value; }
        }

        string _onTrackValue;

        /// <summary>
        /// Gets or sets the value of variable onTrackValue.
        /// </summary>
        [TestVariable("ce0d47bf-8942-4cc7-84dd-34f9dd35960d")]
        public string onTrackValue
        {
            get { return _onTrackValue; }
            set { _onTrackValue = value; }
        }

        string _closeForms;

        /// <summary>
        /// Gets or sets the value of variable closeForms.
        /// </summary>
        [TestVariable("48ec775c-143e-45b7-8041-e693dda9b629")]
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

            UserCodeCollections.NS_Tags.NS_DeleteTag_EditTagForm(tagName, betweenAtValue, andValue, onTrackValue, ValueConverter.ArgumentFromString<bool>("closeForms", closeForms));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
