﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
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
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace PDS_NS.Recording_Modules.AboutPDS
{
    public partial class ValidatePDSLabel
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void validatePDSLabelInfo(string serverVersion, string clientVersion, string copyRight, bool validateLabelInfo)
        {
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.PDS_Main_Menu.MainMenuBar.HelpButtonInfo, repo.PDS_Main_Menu.HelpMenu.AboutPDSInfo);
        	PDS_CORE.Code_Utils.GeneralUtilities.LeftClickAndWaitForWithRetry(repo.PDS_Main_Menu.HelpMenu.AboutPDSInfo, repo.AboutPDS.SelfInfo);
        	
        	int retries = 0;
        	while (repo.AboutPDS.ServerVersion.TextValue == "Server version: Unknown" && retries < 3)
        	{
        		Ranorex.Delay.Milliseconds(500);
        		retries++;
        	}
        	
        	Report.Screenshot(ReportLevel.Info, "User", "", repo.AboutPDS.Self, false, new RecordItemIndex(2));
        	
        	if(validateLabelInfo)
        	{
        		Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$serverVersion) on item 'AboutPDS.ServerVersion'.", repo.AboutPDS.ServerVersionInfo, new RecordItemIndex(3));
        		Validate.AttributeContains(repo.AboutPDS.ServerVersionInfo, "Text", serverVersion);

        		Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$clientVersion) on item 'AboutPDS.ClientVersion'.", repo.AboutPDS.ClientVersionInfo, new RecordItemIndex(3));
        		Validate.AttributeContains(repo.AboutPDS.ClientVersionInfo, "Text", clientVersion);
        		
        		Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$copyRight) on item 'AboutPDS.CopyRight'.", repo.AboutPDS.CopyrightInfo, new RecordItemIndex(3));
        		Validate.AttributeContains(repo.AboutPDS.CopyrightInfo, "Text", copyRight);
        	}
        	
        	PDS_CORE.Code_Utils.GeneralUtilities.ClickAndWaitForNotExistWithRetry(repo.AboutPDS.OkButtonInfo, repo.AboutPDS.SelfInfo);
        }

    }
}
