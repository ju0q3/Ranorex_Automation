/*
 * Created by Ranorex
 * User: r07000021
 * Date: 1/29/2018
 * Time: 2:21 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using STE.Code_Utils.messages.MIS.NS;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace STE.Code_Utils
{
    /// <summary>
    /// Description of ReceiveMISMessageCollection.
    /// </summary>
    [UserCodeCollection]
    public class ReceiveMISMsmqCollectionNS
    {
        [UserCodeMethod]
        public static MIS_PrintFax getMessagePrintFaxMsmq(string[] filters, int timeInSeconds=5, bool retry=true)
        {
            MIS_PrintFax printFax = null;
            printFax = messages.SteMessageQueueReader.getMessagePrintFaxNSMsmq(filters, timeInSeconds, retry);
            return printFax;
        }

        [UserCodeMethod]
        public static MIS_ErrorMessageConfig getErrorMessageMsmq(string[] filters, int timeInSeconds=5, bool retry=true)
        {
            MIS_ErrorMessageConfig errorMessage = null;
            errorMessage = messages.SteMessageQueueReader.getMessageErrorNSMsmq(filters, timeInSeconds, retry);
            return errorMessage;
        }
        
        [UserCodeMethod]
        public static MIS_ErrorMessagesConfig getErrorMessagesMsmq(string[] filters, int timeInSeconds=5, bool retry=true)
        {
            MIS_ErrorMessagesConfig errorMessages = null;
            errorMessages = messages.SteMessageQueueReader.getMessageErrorsNSMsmq(filters, timeInSeconds, retry);
            return errorMessages;
        }        
    }
}
