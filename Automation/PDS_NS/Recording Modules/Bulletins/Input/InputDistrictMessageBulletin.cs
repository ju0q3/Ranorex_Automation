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

namespace PDS_NS.Recording_Modules.Bulletins.Input
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The InputDistrictMessageBulletin recording.
    /// </summary>
    [TestModule("81b93dbf-a5c6-44c4-a9fb-8f701536202f", ModuleType.Recording, 1)]
    public partial class InputDistrictMessageBulletin : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static InputDistrictMessageBulletin instance = new InputDistrictMessageBulletin();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InputDistrictMessageBulletin()
        {
            district = "";
            messageDistrict = "";
            message = "";
            issuedBy = "";
            effectiveTimeDifference = "";
            untilTimeDifference = "";
            expectedFeedback = "";
            bulletinSeed = "";
            pressComplete = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InputDistrictMessageBulletin Instance
        {
            get { return instance; }
        }

#region Variables

        string _district;

        /// <summary>
        /// Gets or sets the value of variable district.
        /// </summary>
        [TestVariable("d9021b58-377d-4f02-a934-da55adcb5c06")]
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }

        string _messageDistrict;

        /// <summary>
        /// Gets or sets the value of variable messageDistrict.
        /// </summary>
        [TestVariable("32d91344-1bd9-4fe5-9a2a-6bf54cbd25b8")]
        public string messageDistrict
        {
            get { return _messageDistrict; }
            set { _messageDistrict = value; }
        }

        string _message;

        /// <summary>
        /// Gets or sets the value of variable message.
        /// </summary>
        [TestVariable("481e1dc5-b4a2-472d-8e48-71e7c16ca174")]
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        string _issuedBy;

        /// <summary>
        /// Gets or sets the value of variable issuedBy.
        /// </summary>
        [TestVariable("e69e7531-1376-4ba0-83b7-5d022024f8d6")]
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }

        string _effectiveTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable effectiveTimeDifference.
        /// </summary>
        [TestVariable("15131240-e540-465a-a047-b8425e4ad9b2")]
        public string effectiveTimeDifference
        {
            get { return _effectiveTimeDifference; }
            set { _effectiveTimeDifference = value; }
        }

        string _untilTimeDifference;

        /// <summary>
        /// Gets or sets the value of variable untilTimeDifference.
        /// </summary>
        [TestVariable("3da9ab2b-e481-43c7-b64a-291f34a3f29f")]
        public string untilTimeDifference
        {
            get { return _untilTimeDifference; }
            set { _untilTimeDifference = value; }
        }

        string _expectedFeedback;

        /// <summary>
        /// Gets or sets the value of variable expectedFeedback.
        /// </summary>
        [TestVariable("aaa24c11-4c0c-4959-9c44-e9181f1d0cba")]
        public string expectedFeedback
        {
            get { return _expectedFeedback; }
            set { _expectedFeedback = value; }
        }

        string _bulletinSeed;

        /// <summary>
        /// Gets or sets the value of variable bulletinSeed.
        /// </summary>
        [TestVariable("7a4c1d08-f34b-45a2-96e2-78c8d6389fe5")]
        public string bulletinSeed
        {
            get { return _bulletinSeed; }
            set { _bulletinSeed = value; }
        }

        string _pressComplete;

        /// <summary>
        /// Gets or sets the value of variable pressComplete.
        /// </summary>
        [TestVariable("f6bcf6c7-1542-4cbb-8677-5824d7f2de6d")]
        public string pressComplete
        {
            get { return _pressComplete; }
            set { _pressComplete = value; }
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

            UserCodeCollections.NS_InputBulletins.NS_InputDistrictMessageBulletin(bulletinSeed, district, messageDistrict, message, issuedBy, effectiveTimeDifference, untilTimeDifference, expectedFeedback, ValueConverter.ArgumentFromString<bool>("pressComplete", pressComplete));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
