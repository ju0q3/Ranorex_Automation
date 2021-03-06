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

namespace PTC_Lab_Automation.Recording_Modules.OnBoardActions
{
    public partial class ValidateDiagnosticSystemItemSummary
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void ValidateDiagnosticSystemItemSummary_LogManager(string diagnosticSystemItem, string summary)
        {
            string parameters = string.Join("|", new string[]{diagnosticSystemItem, summary});
            STE.Code_Utils.Server.SendCommandToOnboard("LogManager", "ValidateDiagnosticSystemItemSummary_LogManager", parameters);
        }

    }
}
