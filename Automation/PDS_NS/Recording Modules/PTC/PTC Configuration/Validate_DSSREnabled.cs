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

namespace PDS_NS.Recording_Modules.PTC.PTC_Configuration
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Validate_DSSREnabled recording.
    /// </summary>
    [TestModule("270b1d0e-29d3-4287-9034-94cdd34849d6", ModuleType.Recording, 1)]
    public partial class Validate_DSSREnabled : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static Validate_DSSREnabled instance = new Validate_DSSREnabled();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_DSSREnabled()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Validate_DSSREnabled Instance
        {
            get { return instance; }
        }

#region Variables

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

            UserCodeCollections.NS_PTC_Configuration.NS_OpenPTCConfigurationForm_MainMenu();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s to exist. Associated repository item: 'Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckbox'", repo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckboxInfo, new ActionTimeout(5000), new RecordItemIndex(1));
            repo.Positive_Train_Control_Configuration.ApplicationConfiguration.EnablePTCCIBOSDataTrafficCheckboxInfo.WaitForExists(5000);
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating Exists on item 'Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAll'.", repo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAllInfo, new RecordItemIndex(2));
                Validate.Exists(repo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchSuspendAllInfo, null, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating Exists on item 'Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAll'.", repo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAllInfo, new RecordItemIndex(3));
                Validate.Exists(repo.Positive_Train_Control_Configuration.ApplicationConfiguration.DispatchResumeAllInfo, null, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(3)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating Exists on item 'Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStates'.", repo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStatesInfo, new RecordItemIndex(4));
                Validate.Exists(repo.Positive_Train_Control_Configuration.ApplicationConfiguration.SaveCurrentDistrictStatesInfo, null, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(4)); }
            
            UserCodeCollections.NS_PTC_Configuration.NS_OpenPTCConfigurationForm_CommunicationConfiguration_MainMenu();
            Delay.Milliseconds(0);
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating Exists on item 'Positive_Train_Control_Configuration.CommunicationConfiguration.SuspendDurationText'.", repo.Positive_Train_Control_Configuration.CommunicationConfiguration.SuspendDurationTextInfo, new RecordItemIndex(6));
                Validate.Exists(repo.Positive_Train_Control_Configuration.CommunicationConfiguration.SuspendDurationTextInfo, null, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(6)); }
            
            PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.Positive_Train_Control_Configuration.CancelButtonInfo, repo.Positive_Train_Control_Configuration.SelfInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
