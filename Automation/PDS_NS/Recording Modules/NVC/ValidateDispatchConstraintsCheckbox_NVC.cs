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

namespace PDS_NS.Recording_Modules.NVC
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateDispatchConstraintsCheckbox_NVC recording.
    /// </summary>
    [TestModule("ba0a685a-9b76-4420-a1ed-bbe5802a8b89", ModuleType.Recording, 1)]
    public partial class ValidateDispatchConstraintsCheckbox_NVC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateDispatchConstraintsCheckbox_NVC instance = new ValidateDispatchConstraintsCheckbox_NVC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateDispatchConstraintsCheckbox_NVC()
        {
            isTrackBlockChecked = "False";
            isMofWReservationsChecked = "False";
            isAuthoritiesToTrainsChecked = "False";
            isOtherAuthoritiesChecked = "False";
            isStopShortChecked = "False";
            isPermissionToEnterMainChecked = "False";
            isSwitchBlockChecked = "False";
            isSignalAuthorityChecked = "False";
            isInferredSignalAuthoritiesChecked = "False";
            isSignalBlockChecked = "False";
            isSpeedRestrictionsChecked = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateDispatchConstraintsCheckbox_NVC Instance
        {
            get { return instance; }
        }

#region Variables

        string _isTrackBlockChecked;

        /// <summary>
        /// Gets or sets the value of variable isTrackBlockChecked.
        /// </summary>
        [TestVariable("b8afa496-9007-4676-b27c-fbacd1c3afa5")]
        public string isTrackBlockChecked
        {
            get { return _isTrackBlockChecked; }
            set { _isTrackBlockChecked = value; }
        }

        string _isMofWReservationsChecked;

        /// <summary>
        /// Gets or sets the value of variable isMofWReservationsChecked.
        /// </summary>
        [TestVariable("09b85a87-1640-467d-ba54-6e3fd968d5a2")]
        public string isMofWReservationsChecked
        {
            get { return _isMofWReservationsChecked; }
            set { _isMofWReservationsChecked = value; }
        }

        string _isAuthoritiesToTrainsChecked;

        /// <summary>
        /// Gets or sets the value of variable isAuthoritiesToTrainsChecked.
        /// </summary>
        [TestVariable("d311a2b0-8811-4fb0-8ae0-ee17a9ae6dcf")]
        public string isAuthoritiesToTrainsChecked
        {
            get { return _isAuthoritiesToTrainsChecked; }
            set { _isAuthoritiesToTrainsChecked = value; }
        }

        string _isOtherAuthoritiesChecked;

        /// <summary>
        /// Gets or sets the value of variable isOtherAuthoritiesChecked.
        /// </summary>
        [TestVariable("ce5b1d35-f9b6-43e3-bd33-ed302c095364")]
        public string isOtherAuthoritiesChecked
        {
            get { return _isOtherAuthoritiesChecked; }
            set { _isOtherAuthoritiesChecked = value; }
        }

        string _isStopShortChecked;

        /// <summary>
        /// Gets or sets the value of variable isStopShortChecked.
        /// </summary>
        [TestVariable("44abaed9-9c63-4e8b-9fba-72838d9cd5d1")]
        public string isStopShortChecked
        {
            get { return _isStopShortChecked; }
            set { _isStopShortChecked = value; }
        }

        string _isPermissionToEnterMainChecked;

        /// <summary>
        /// Gets or sets the value of variable isPermissionToEnterMainChecked.
        /// </summary>
        [TestVariable("ee6d2ee5-3ef7-41f8-98c5-ef48447cec1b")]
        public string isPermissionToEnterMainChecked
        {
            get { return _isPermissionToEnterMainChecked; }
            set { _isPermissionToEnterMainChecked = value; }
        }

        string _isSwitchBlockChecked;

        /// <summary>
        /// Gets or sets the value of variable isSwitchBlockChecked.
        /// </summary>
        [TestVariable("1bad9fc5-ca45-45fa-9a60-9a00d6f34f7f")]
        public string isSwitchBlockChecked
        {
            get { return _isSwitchBlockChecked; }
            set { _isSwitchBlockChecked = value; }
        }

        string _isSignalAuthorityChecked;

        /// <summary>
        /// Gets or sets the value of variable isSignalAuthorityChecked.
        /// </summary>
        [TestVariable("e0767800-6733-4bc2-90c7-8017ea28b51e")]
        public string isSignalAuthorityChecked
        {
            get { return _isSignalAuthorityChecked; }
            set { _isSignalAuthorityChecked = value; }
        }

        string _isInferredSignalAuthoritiesChecked;

        /// <summary>
        /// Gets or sets the value of variable isInferredSignalAuthoritiesChecked.
        /// </summary>
        [TestVariable("346a832b-fd58-4bb2-90da-27fa3fa1bb26")]
        public string isInferredSignalAuthoritiesChecked
        {
            get { return _isInferredSignalAuthoritiesChecked; }
            set { _isInferredSignalAuthoritiesChecked = value; }
        }

        string _isSignalBlockChecked;

        /// <summary>
        /// Gets or sets the value of variable isSignalBlockChecked.
        /// </summary>
        [TestVariable("6311f7f5-72fe-4fba-8623-6194fe654048")]
        public string isSignalBlockChecked
        {
            get { return _isSignalBlockChecked; }
            set { _isSignalBlockChecked = value; }
        }

        string _isSpeedRestrictionsChecked;

        /// <summary>
        /// Gets or sets the value of variable isSpeedRestrictionsChecked.
        /// </summary>
        [TestVariable("d7f43d16-f859-4ffb-adeb-afd05d239b5d")]
        public string isSpeedRestrictionsChecked
        {
            get { return _isSpeedRestrictionsChecked; }
            set { _isSpeedRestrictionsChecked = value; }
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

            UserCodeCollections.NS_NVC.NS_ValidateDispatchConstraintsCheckbox_NVC(ValueConverter.ArgumentFromString<bool>("isSpeedRestrictionsChecked", isSpeedRestrictionsChecked), ValueConverter.ArgumentFromString<bool>("isTrackBlockChecked", isTrackBlockChecked), ValueConverter.ArgumentFromString<bool>("isMofWReservationsChecked", isMofWReservationsChecked), ValueConverter.ArgumentFromString<bool>("isAuthoritiesToTrainsChecked", isAuthoritiesToTrainsChecked), ValueConverter.ArgumentFromString<bool>("isOtherAuthoritiesChecked", isOtherAuthoritiesChecked), ValueConverter.ArgumentFromString<bool>("isStopShortChecked", isStopShortChecked), ValueConverter.ArgumentFromString<bool>("isPermissionToEnterMainChecked", isPermissionToEnterMainChecked), ValueConverter.ArgumentFromString<bool>("isSwitchBlockChecked", isSwitchBlockChecked), ValueConverter.ArgumentFromString<bool>("isSignalAuthorityChecked", isSignalAuthorityChecked), ValueConverter.ArgumentFromString<bool>("isInferredSignalAuthoritiesChecked", isInferredSignalAuthoritiesChecked), ValueConverter.ArgumentFromString<bool>("isSignalBlockChecked", isSignalBlockChecked));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
